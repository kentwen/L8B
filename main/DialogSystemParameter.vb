Imports System.Windows.Forms

Public Class DialogSystemParameter
    Dim BufferDict As New Dictionary(Of Integer, RSTShapFlowGUI.RSTGUICtrlSlots)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        With _L8B.Setting.AlarmFile
            .EQ1 = TextBoxAlarmFileEQ1.Text
            .EQ2 = TextBoxAlarmFileEQ2.Text
            .EQ3 = TextBoxAlarmFileEQ3.Text
            .CV = TextBoxAlarmFileCV.Text
            .PLC = TextBoxAlarmFilePLC.Text
        End With

        With _L8B.Setting.ID
            .Line = TextBoxLineID.Text
            .Tool = TextBoxToolID.Text
            .RST = TextBoxToolID.Text
            .EQ1 = TextBoxEQ1ToolID.Text
            .EQ2 = TextBoxEQ2ToolID.Text
            .EQ3 = TextBoxEQ3ToolID.Text
            .CV = TextBoxCVToolID.Text

        End With

        With _L8B.Setting.Main
            .EQRecipeCheck(1) = CheckBoxEQ1.Checked
            .EQRecipeCheck(2) = CheckBoxEQ2.Checked
            .EQRecipeCheck(3) = CheckBoxEQ3.Checked
            .LogDayKeep = NumericUpDownLogFileKeepDays.Value
        End With

        _L8B.Setting.IniSave()
        '_L8B.Alarm.LoadCSVFile()
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub


    Private Sub FileSelection(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LoadDialog As New OpenFileDialog

        LoadDialog.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*"
        LoadDialog.FilterIndex = 1
        LoadDialog.RestoreDirectory = True

        If LoadDialog.ShowDialog() = DialogResult.OK Then
            Select Case DirectCast(sender, Button).Name
                Case "ButtonAlarmFileEQ1"
                    TextBoxAlarmFileEQ1.Text = LoadDialog.FileName

                Case "ButtonAlarmFileEQ2"
                    TextBoxAlarmFileEQ2.Text = LoadDialog.FileName

                Case "ButtonAlarmFileEQ3"
                    TextBoxAlarmFileEQ3.Text = LoadDialog.FileName

                Case "ButtonAlarmFileCV"
                    TextBoxAlarmFileCV.Text = LoadDialog.FileName

                Case "ButtonAlarmFilePLC"
                    TextBoxAlarmFilePLC.Text = LoadDialog.FileName
            End Select
        End If
    End Sub

    Private Sub DialogSystemParameter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler ButtonAlarmFileEQ1.Click, AddressOf FileSelection
        AddHandler ButtonAlarmFileEQ2.Click, AddressOf FileSelection
        AddHandler ButtonAlarmFileEQ3.Click, AddressOf FileSelection
        AddHandler ButtonAlarmFileCV.Click, AddressOf FileSelection
        AddHandler ButtonAlarmFilePLC.Click, AddressOf FileSelection

    End Sub


    Private Sub ButtonMachineSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMachineSetting.Click
        _L8B.dlgMachineSetting.ShowMe()
    End Sub


    Public Sub ShowMe(ByVal Parent As System.Windows.Forms.IWin32Window)
        With _L8B.Setting.AlarmFile
            TextBoxAlarmFileCV.Text = .CV
            TextBoxAlarmFilePLC.Text = .PLC
        End With

        With _L8B.Setting.Main
            CheckBoxEQ1.Checked = .EQRecipeCheck(1)
            CheckBoxEQ2.Checked = .EQRecipeCheck(2)
            CheckBoxEQ3.Checked = .EQRecipeCheck(3)
            NumericUpDownLogFileKeepDays.Value = .LogDayKeep
        End With

        With _L8B.Setting.ID
            TextBoxLineID.Text = .Line
            TextBoxToolID.Text = .Tool
            TextBoxRSTToolID.Text = .RST

            TextBoxCVToolID.Text = .CV

            If _L8B.Setting.Main.NumberEQ = 1 Then
                TextBoxEQ1ToolID.Enabled = True
                TextBoxEQ2ToolID.Enabled = False
                TextBoxEQ3ToolID.Enabled = False
                TextBoxEQ1ToolID.Text = .EQ1
                TextBoxEQ2ToolID.Text = "N/A"
                TextBoxEQ3ToolID.Text = "N/A"

                TextBoxAlarmFileEQ1.Enabled = True
                TextBoxAlarmFileEQ2.Enabled = False
                TextBoxAlarmFileEQ3.Enabled = False
                TextBoxAlarmFileEQ1.Text = _L8B.Setting.AlarmFile.EQ1
                TextBoxAlarmFileEQ2.Text = "N/A"
                TextBoxAlarmFileEQ3.Text = "N/A"

            ElseIf _L8B.Setting.Main.NumberEQ = 2 Then
                TextBoxEQ1ToolID.Enabled = True
                TextBoxEQ2ToolID.Enabled = True
                TextBoxEQ3ToolID.Enabled = False
                TextBoxEQ1ToolID.Text = .EQ1
                TextBoxEQ2ToolID.Text = .EQ2
                TextBoxEQ3ToolID.Text = "N/A"

                TextBoxAlarmFileEQ1.Enabled = True
                TextBoxAlarmFileEQ2.Enabled = True
                TextBoxAlarmFileEQ3.Enabled = False
                TextBoxAlarmFileEQ1.Text = _L8B.Setting.AlarmFile.EQ1
                TextBoxAlarmFileEQ2.Text = _L8B.Setting.AlarmFile.EQ2
                TextBoxAlarmFileEQ3.Text = "N/A"
            ElseIf _L8B.Setting.Main.NumberEQ = 3 Then
                TextBoxEQ1ToolID.Enabled = True
                TextBoxEQ2ToolID.Enabled = True
                TextBoxEQ3ToolID.Enabled = True
                TextBoxEQ1ToolID.Text = .EQ1
                TextBoxEQ2ToolID.Text = .EQ2
                TextBoxEQ3ToolID.Text = .EQ3

                TextBoxAlarmFileEQ1.Enabled = True
                TextBoxAlarmFileEQ2.Enabled = True
                TextBoxAlarmFileEQ3.Enabled = True
                TextBoxAlarmFileEQ1.Text = _L8B.Setting.AlarmFile.EQ1
                TextBoxAlarmFileEQ2.Text = _L8B.Setting.AlarmFile.EQ2
                TextBoxAlarmFileEQ3.Text = _L8B.Setting.AlarmFile.EQ3
            End If

            ButtonAlarmFileEQ1.Enabled = TextBoxAlarmFileEQ1.Enabled
            ButtonAlarmFileEQ2.Enabled = TextBoxAlarmFileEQ2.Enabled
            ButtonAlarmFileEQ3.Enabled = TextBoxAlarmFileEQ3.Enabled

        End With

        If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.REPAIR Then 'OrElse _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.FI Then
            If Me.TabControl1.Controls.Contains(Me.TabPage2) Then
                Me.TabControl1.Controls.Remove(Me.TabPage2)
            End If
        ElseIf _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.NONE Then
            If Not Me.TabControl1.Controls.Contains(Me.TabPage2) Then
                Me.TabControl1.Controls.Add(Me.TabPage2)
            End If
        End If
        Try
            Me.Show(Parent)
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedTab.Name
            Case "TabPage1"
            Case "TabPage2"
                For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                    BufferDict(i).Visible = True
                Next

                For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                    BufferDict(i).MaxSlots = _L8B.Setting.Main.NumberBufferSlot(i)
                    BufferDict(i).GxIDShow = True
                    For j As Integer = 1 To BufferDict(i).MaxSlots
                        'BufferDict(i).GxID(j) = _L8B.Setting.Main.bufferDictIMode(i)(j).ToString
                        BufferDict(i).WithGx(j) = True
                    Next
                Next
                Select Case _L8B.Setting.Main.MachineType
                    Case ClsSetting.EMACHINETYPE.ButterFly, ClsSetting.EMACHINETYPE.FI
                        ComboBoxGlassTMode.Items.Clear()
                        ComboBoxGlassTMode.Items.Add("Through(U) Mode")
                        ComboBoxGlassTMode.Items.Add("MQC(I) Mode")

                    Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR
                        ComboBoxGlassTMode.Items.Clear()
                        ComboBoxGlassTMode.Items.Add("Repair Tape Mode")
                        ComboBoxGlassTMode.Items.Add("Repair Tape/Ink Mode")
                End Select

                Try
                    ComboBoxGlassTMode.SelectedIndex = 0
                Catch ex As Exception
                    WriteLog(ex.ToString)
                End Try
        End Select
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BufferDict.Add(1, RstguiCtrlSlots1)
        BufferDict.Add(2, RstguiCtrlSlots2)
        BufferDict.Add(3, RstguiCtrlSlots3)
    End Sub

    Private Sub ButtonCassetteInfoColumnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCassetteInfoColumnSelect.Click
        DialogCassetteInfoColumnSelection.showMe()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        With _L8B.Setting.AlarmFile
            .EQ1 = TextBoxAlarmFileEQ1.Text
            .EQ2 = TextBoxAlarmFileEQ2.Text
            .EQ3 = TextBoxAlarmFileEQ3.Text
            .CV = TextBoxAlarmFileCV.Text
            .PLC = TextBoxAlarmFilePLC.Text
        End With

        With _L8B.Setting.ID
            .Line = TextBoxLineID.Text
            .Tool = TextBoxToolID.Text
            .RST = TextBoxToolID.Text
            .EQ1 = TextBoxEQ1ToolID.Text
            .EQ2 = TextBoxEQ2ToolID.Text
            .EQ3 = TextBoxEQ3ToolID.Text
            .CV = TextBoxCVToolID.Text

        End With

        With _L8B.Setting.Main
            .EQRecipeCheck(1) = CheckBoxEQ1.Checked
            .EQRecipeCheck(2) = CheckBoxEQ2.Checked
            .EQRecipeCheck(3) = CheckBoxEQ3.Checked
            .LogDayKeep = NumericUpDownLogFileKeepDays.Value
        End With

        _L8B.Setting.IniSave()
        _L8B.Alarm.LoadCSVFile()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub


    Dim BufferSelect As Integer
    Dim BufferSlotSelect As Integer

    Private Sub RstguiCtrlSlots1_SlotLBLMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles RstguiCtrlSlots1.SlotLBLMouseUP
        Debug.WriteLine("RstguiCtrlSlots11_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 1
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = RstguiCtrlSlots1.Left + X
        Point.Y = RstguiCtrlSlots1.Top + Y
        BufferSlotToolStripMenuItem.Text = "Buffer#1     Slot#" & nSlot
        ContextMenuStripBufferSlotType.Show(Me, Point)
    End Sub

    Private Sub RstguiCtrlSlots2_SlotLBLMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles RstguiCtrlSlots2.SlotLBLMouseUP
        Debug.WriteLine("RstguiCtrlSlots2_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 2
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = RstguiCtrlSlots2.Left + X
        Point.Y = RstguiCtrlSlots2.Top + Y
        BufferSlotToolStripMenuItem.Text = "Buffer#2     Slot#" & nSlot
        ContextMenuStripBufferSlotType.Show(Me, Point)
    End Sub

    Private Sub RstguiCtrlSlots3_SlotLBLMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles RstguiCtrlSlots3.SlotLBLMouseUP
        Debug.WriteLine("RstguiCtrlSlots3_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 3
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = RstguiCtrlSlots3.Left + X
        Point.Y = RstguiCtrlSlots3.Top + Y
        BufferSlotToolStripMenuItem.Text = "Buffer#3     Slot#" & nSlot
        ContextMenuStripBufferSlotType.Show(Me, Point)
    End Sub

    Private Sub OKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.OK
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub NGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NGToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NG
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub GrayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrayToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.GRAY
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub InkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InkToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.INK
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub LDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LDToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.LD
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub CASSETTE1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASSETTE1ToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.CASSETTE1
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub CASSETTE2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASSETTE2ToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.CASSETTE2
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub CASSETTE3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASSETTE3ToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.CASSETTE3
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub EQ1SampleGlassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ1SampleGlassToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.STDGLX_EQ1
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Sub EQ2SampleGlassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ2SampleGlassToolStripMenuItem.Click
        BufferDict(BufferSelect).SlotType(BufferSlotSelect) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.STDGLX_EQ2
        BufferDict(BufferSelect).GxID(BufferSlotSelect) = BufferDict(BufferSelect).SlotType(BufferSlotSelect).ToString
    End Sub

    Private Function GetRunningMode(ByVal mText As String) As eRunningMode
        Select Case mText
            Case "Through(U) Mode"
                Return eRunningMode.THROUGH

            Case "MQC(I) Mode"
                Return eRunningMode.MQC

            Case "Repair Tape Mode"
                Return eRunningMode.TAPE

            Case "Repair Tape/Ink Mode"
                Return eRunningMode.TAPEINK

            Case Else
                Return eRunningMode.NA

        End Select
    End Function

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim mRunningMode As eRunningMode = GetRunningMode(ComboBoxGlassTMode.Text)

        ButtonSave.Enabled = False
        If mRunningMode <> eRunningMode.NA Then
            For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                    _L8B.Setting.Main.BufferSlotType(mRunningMode)(i)(j) = BufferDict(i).SlotType(j)
                Next
            Next
            _L8B.Setting.SaveBuffer(mRunningMode)
        End If
        ButtonSave.Enabled = True
        ButtonSave.Focus()
    End Sub

    Private Sub ComboBoxGlassTMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxGlassTMode.SelectedIndexChanged
        LoadBufferSetting()
    End Sub


    Private Sub LoadBufferSetting()
        Dim mRunningMode As eRunningMode = GetRunningMode(ComboBoxGlassTMode.Text)

        If mRunningMode <> eRunningMode.NA Then
            _L8B.Setting.LoadBuffer()
            For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                    BufferDict(i).SlotType(j) = _L8B.Setting.Main.BufferSlotType(mRunningMode)(i)(j)
                    If BufferDict(i).SlotType(j) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NA Then
                        BufferDict(i).GxID(j) = ""
                    Else
                        BufferDict(i).GxID(j) = BufferDict(i).SlotType(j).ToString
                    End If
                Next
            Next
        Else
            For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                    BufferDict(i).SlotType(j) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NA
                    If BufferDict(i).SlotType(j) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NA Then
                        BufferDict(i).GxID(j) = ""
                    Else
                        BufferDict(i).GxID(j) = BufferDict(i).SlotType(j).ToString
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub ButtonLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoad.Click
        ButtonLoad.Enabled = False
        LoadBufferSetting()
        ButtonLoad.Enabled = True
    End Sub

End Class
