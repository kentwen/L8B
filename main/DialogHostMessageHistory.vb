Imports System.Windows.Forms
Imports System.Data

Public Class DialogHostMessageHistory

    Public Sub ShowMe()
        SetDataSource()
        Me.ShowDialog()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim SC_CLOSE As Integer = 61536
        Dim WM_SYSCOMMAND As Integer = 274

        '判斷是不是按Alt+F4
        If m.Msg = WM_SYSCOMMAND AndAlso m.WParam.ToInt32 = SC_CLOSE Then
            'Debug.Print("User 按Alt+F4; will be ignored.")
            Me.Hide()
        Else
            MyBase.WndProc(m)
        End If
    End Sub


    Public Sub SetDataSource()
        Dim History As DataTable = _L8B.db.QueryHostMessageHistory
        'DataGridViewHostMessageHistory.DataSource = Nothing
        'DataGridViewHostMessageHistory.DataSource = History
        UpdateListViewMsgHistory(History)
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.Hide()
        _L8B.frmMain.Focus()
        '_L8b.frmMain.TopMost = True
    End Sub

    Private Sub UpdateListViewMsgHistory(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        With ListViewMsgHistory

            .Clear()

            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .MultiSelect = False
            .Columns.Add("Index", 40)
            .Columns.Add("DateTiem", 140)
            .Columns.Add("SRC", 35)
            .Columns.Add("Type", 70)
            .Columns.Add("Message", 250)
            .BeginUpdate()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim ViewItem As System.Windows.Forms.ListViewItem = .Items.Add(i + 1)
                    ViewItem.SubItems.Add(dt.Rows(i)("DateTime"))
                    ViewItem.SubItems.Add(dt.Rows(i)("Source"))
                    Dim MsgType As String = IIf(IsDBNull(dt.Rows(i)("Type")), "", dt.Rows(i)("Type"))
                    ViewItem.SubItems.Add(MsgType)
                    ViewItem.SubItems.Add(dt.Rows(i)("Message"))
                    Dim fontBold As New Font(ViewItem.Font.FontFamily, ViewItem.Font.Size, FontStyle.Bold)
                    'Dim fontNotBold As New Font(viewitem.Font.FontFamily, viewitem.Font.Size, FontStyle.Regular)
                    ViewItem.Font = fontBold
                    If MsgType = "Warning" Then
                        ViewItem.ForeColor = Color.Red
                        ViewItem.BackColor = Color.White
                    ElseIf MsgType = "" Then
                        ViewItem.ForeColor = Color.Blue
                        ViewItem.BackColor = Color.White
                    End If
                Next
                .Items(.Items.Count - 1).EnsureVisible()
                .Items(.Items.Count - 1).Focused = True
                .Items(.Items.Count - 1).Selected = True
            End If
            .EndUpdate()
        End With



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListViewMsgHistory.Items(ListViewMsgHistory.Items.Count - 2).EnsureVisible()
        ListViewMsgHistory.Items(ListViewMsgHistory.Items.Count - 2).Focused = True
        ListViewMsgHistory.Items(ListViewMsgHistory.Items.Count - 2).Selected = True
    End Sub
End Class


