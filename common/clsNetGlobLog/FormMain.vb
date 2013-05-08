Imports System.Windows.Forms
Imports System
Imports System.Threading


Public Class FormMain
    Public LogQueue As New Queue(Int16.MaxValue)

    Private Const LB_SETHORIZONTALEXTENT = &H194

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
            (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, _
    ByVal lParam As Object) As Long

    Dim preMax As Integer

    Public Sub AppendLogToGrid(ByVal szText As String, ByVal szCaption As String, ByVal Ctrl As Object)
        Static prevCtrl As Object

        If prevCtrl Is Nothing Then
            lstGlobal.Items.Add("******************** " & szCaption & " ********************")
        Else
            If Not prevCtrl Is Ctrl Then
                lstGlobal.Items.Add("******************** " & szCaption & " ********************")
            End If
        End If

        prevCtrl = Ctrl
    End Sub

    Public Function AddListBox(ByVal szCaption As String) As System.Windows.Forms.ListBox
        Dim myListBox As New System.Windows.Forms.ListBox
        Dim myTabpage As New TabPage

        Dim Index = TabControl.TabPages.Count
        myTabpage.Name = "Tabpage" & Index
        myTabpage.Text = szCaption

        'myTabpage.
        'TabControl.TabPages.Add(myTabpage)

        myListBox.Name = "List" & Index
        myListBox.Font = lstGlobal.Font
        myTabpage.Controls.Add(myListBox)

        FF.TabPageQueue.Enqueue(myTabpage)

        myListBox.Left = lstGlobal.Left '- 9
        myListBox.Top = lstGlobal.Top '- 9
        myListBox.Width = lstGlobal.Width
        myListBox.Height = lstGlobal.Height
        myListBox.HorizontalScrollbar = True
        AddHandler myListBox.DoubleClick, AddressOf ListDoubleClick
        Return myListBox
    End Function

    Public Sub myListboxClear()
        For Each sTabpage As Control In TabControl.Controls
            If TypeOf (sTabpage) Is TabPage Then
                For Each sListbox As Control In sTabpage.Controls
                    If TypeOf (sListbox) Is ListBox Then
                        DirectCast(sListbox, ListBox).Items.Clear()
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub optPilledC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFilledC.CheckedChanged
        MyParameter.AutoClear = optFilledC.Checked
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStopShowLog.CheckedChanged
        MyParameter.Hold = IIf(CheckBoxStopShowLog.Checked, True, False)

    End Sub

    Private Sub cmdLogClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogClear.Click
        MyParameter.ClearLogAll()
        myListboxClear()
    End Sub

    Private Sub cmdSaveLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLog.Click
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.OverwritePrompt = True
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            Dim szFile As String = saveFileDialog1.FileName
            SaveToFileSub(szFile)
        End If

    End Sub

    Public Sub HideMe()
        FF.fShow = False
    End Sub

    Public Sub ShowMe()
        FF.fShow = True
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim SC_CLOSE As Integer = 61536
        Dim WM_SYSCOMMAND As Integer = 274

        '判斷是不是按Alt+F4
        'Case &HF060 'SC_Close 'User clicked on "X"

        If m.Msg = WM_SYSCOMMAND AndAlso m.WParam.ToInt32 = SC_CLOSE Then
            If Me.Visible Then
                FF.fShow = False
            End If
            Debug.Print("User 按Alt+F4; will be ignored.")
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub frmMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        For Each tp As Control In Me.Controls
            If TypeOf (tp) Is TabPage Then
                For Each lb As ListBox In tp.Controls
                    lb.Font = lstGlobal.Font
                    lb.Left = lstGlobal.Left '- 9
                    lb.Top = lstGlobal.Top '- 9
                    lb.Width = lstGlobal.Width
                    lb.Height = lstGlobal.Height
                Next
            End If
        Next
    End Sub

    Private Sub ListDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try


            Dim saveFileDialog1 As New SaveFileDialog

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.OverwritePrompt = True
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim szFile As String = saveFileDialog1.FileName
                Dim SW As New System.IO.StreamWriter(szFile)
                Dim nFor As Integer

                For nFor = 0 To sender.Items.Count - 1
                    SW.WriteLine(sender.Items.Item(nFor))
                Next
                SW.Flush()
                SW.Close()
                SW = Nothing
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub LogTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogTimer.Tick
        Static Running As Boolean
        If Running Then
            Exit Sub
        End If
        Running = True

        While FF.TabPageQueue.Count > 0
            TabControl.Controls.Add(FF.TabPageQueue.Dequeue)
        End While

        'SyncLock NumericUpDownMaxLog
        '    NumericUpDownMaxLog.Value = g_nMaxLine
        'End SyncLock


        Me.Visible = FF.fShow

        If LogQueue.Count > 0 Then
            While LogQueue.Count > 0
                Me.Visible = FF.fShow
                System.Windows.Forms.Application.DoEvents()
                myWritelogGUI()
            End While
            If LogQueue.Count = 0 AndAlso Me.Visible AndAlso CheckBoxGotoLast.Checked Then
                If MyForm.lstGlobal.Items.Count > 0 Then
                    lstGlobal.SetSelected(MyForm.lstGlobal.Items.Count - 1, True)
                End If
                For i As Integer = 0 To MyAllLogCtrl.Count - 1
                    If MyAllLogCtrl(i).Items.Count > 0 Then
                        MyAllLogCtrl(i).SetSelected(MyAllLogCtrl(i).Items.Count - 1, True)
                    End If
                Next
            End If
        End If

        Running = False
    End Sub


    Private Sub myWritelogGUI()
        Try
            SyncLock LogQueue
                LogInfo = LogQueue.Dequeue
            End SyncLock

            'If mvarfAutoSaveFile Then
            '    DriveWriteLog(LogInfo.Str)
            'End If

            If Not MyParameter.Hold Then

                If mvarfAutoCLSFile And (MyForm.lstGlobal.Items.Count < g_nMaxLine) Then
                    AppendLogToGrid(LogInfo.Str, LogInfo.LogTitle, LogInfo.oListBox)
                    Try
                        lstGlobal.Items.Add(LogInfo.Str)
                    Catch ex As Exception
                        Debug.Print(ex.ToString)
                    End Try
                    Try
                        If LogInfo.oListBox IsNot Nothing Then
                            LogInfo.oListBox.Items.Add(LogInfo.Str)
                        End If
                    Catch ex As Exception
                        Debug.Print(ex.ToString)
                    End Try
                ElseIf mvarfAutoCLSFile And (MyForm.lstGlobal.Items.Count >= g_nMaxLine) Then
                    If Not mvarfStopWrite Then
                        If MyForm.lstGlobal.Items.Count >= g_nMaxLine Then
                            FF.fClearLogAll = True
                        End If
                    End If
                End If

                If FF.fClearLogAll Then
                    FF.fClearLogAll = False
                    ClearAllListItem()
                End If

            End If


        Catch ex As Exception
            lstGlobal.Items.Add(ex.ToString)
        End Try

    End Sub


    Public Sub ClearAllListItem()
        MyForm.lstGlobal.Items.Clear()
        For Each mListbox As ListBox In MyAllLogCtrl
            mListbox.Items.Clear()
        Next
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lstGlobal.HorizontalScrollbar = True
    End Sub



    Private Sub optFilledS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFilledS.CheckedChanged
        MyParameter.AutoClear = Not optFilledS.Checked
    End Sub

    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        optFilledC.Checked = True
        CheckBoxGotoLast.Checked = True
    End Sub

    Private Sub NumericUpDownMaxLog_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownMaxLog.ValueChanged
        SyncLock NumericUpDownMaxLog
            g_nMaxLine = NumericUpDownMaxLog.Value
        End SyncLock
    End Sub
End Class
