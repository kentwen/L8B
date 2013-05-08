Imports System.Data
Public Class FormMain

    Public Class RSTControlCollection
        Public CVGUIPort As New Dictionary(Of Integer, RSTShapFlowGUI.RSTGUICtrlCV)
        Public CVGUIBuffer As New Dictionary(Of Integer, RSTShapFlowGUI.RSTGUICtrlSlots)
        Public CVGUIBufferEdit As New Dictionary(Of Integer, RSTShapFlowGUI.RSTGUICtrlSlots)
        Public CVGUIBufferDialog As New Dictionary(Of Integer, RSTShapFlowGUI.RSTGUICtrlSlots)
        Public EQ As New Dictionary(Of Integer, RSTShapFlowGUI.RSTGUICtrlEQ)
        Public EQInterlock As New Dictionary(Of Integer, System.Windows.Forms.Label)
        Public EQHandOff As New Dictionary(Of Integer, Microsoft.VisualBasic.PowerPacks.OvalShape)
        Public TowerEQ As New Dictionary(Of Integer, RSTShapFlowGUI.RSTGUIStatusTower)
        Public CVHandOff As New Dictionary(Of Integer, Microsoft.VisualBasic.PowerPacks.OvalShape)
        Public CVSec As New Dictionary(Of Integer, System.Windows.Forms.TextBox)
        Public CVVCR As New Dictionary(Of Integer, System.Windows.Forms.PictureBox)
        Public AxisMileage As New Dictionary(Of Integer, System.Windows.Forms.Label)
        Public CVSectionIndex As New Dictionary(Of Integer, System.Windows.Forms.Label)
    End Class

    Public RSTControl As New RSTControlCollection
    Dim SelectPort As Integer

    Private Sub FormMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ProgramEnd()
    End Sub

    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Form.CheckForIllegalCrossThreadCalls = False
        ButtonTest.Visible = DebugMode()
        UcDate.Start()
        Main(Me)
        AddGUIControl()
        Me.Left = 0
        Me.Top = 0
        CloseButton.Disable(Me)
        Me.WindowState = FormWindowState.Minimized

        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
            RSTControl.CVGUIBuffer(i).Visible = True
            RSTControl.CVGUIBuffer(i).MaxSlots = _L8B.Setting.Main.NumberBufferSlot(i)
            RSTControl.CVGUIBufferEdit(i).Visible = True
            RSTControl.CVGUIBufferEdit(i).MaxSlots = _L8B.Setting.Main.NumberBufferSlot(i)
            RSTControl.CVGUIBufferDialog(i).Visible = True
            RSTControl.CVGUIBufferDialog(i).MaxSlots = _L8B.Setting.Main.NumberBufferSlot(i)
            InitialBufferGUI(i)
        Next

        For i As Integer = 1 To _L8B.Setting.Main.NumberPort
            RSTControl.CVGUIPort(i).MaxCSTSlot = 56
        Next

        For i As Integer = 1 To _L8B.frmMain.RSTControl.CVSec.Count
            If _L8B.Setting.Main.CVSectionPort(i) > 0 Then
                _L8B.frmMain.RSTControl.CVSectionIndex(i).Text = _L8B.Setting.Main.CVSectionPort(i) & "-" & _L8B.Setting.Main.CVSectionID(i)
                RSTControl.CVHandOff(_L8B.Setting.Main.CVSectionPort(i)).Visible = True
                _L8B.frmMain.RSTControl.CVSectionIndex(i).Visible = True
                _L8B.frmMain.RSTControl.CVSec(i).Visible = True
            Else
                _L8B.frmMain.RSTControl.CVSectionIndex(i).Visible = False
                _L8B.frmMain.RSTControl.CVSec(i).Visible = False
            End If
        Next

        Select Case _L8B.Setting.Main.NumberPort
            Case 2
                RSTControl.CVGUIPort(1).Visible = True
                RSTControl.CVGUIPort(2).Visible = True
                RSTControl.CVGUIPort(3).Visible = False
            Case 3
                RSTControl.CVGUIPort(1).Visible = True
                RSTControl.CVGUIPort(2).Visible = True
                RSTControl.CVGUIPort(3).Visible = True
        End Select

        For i As Integer = 1 To _L8B.Setting.Main.NumberEQ
            RSTControl.EQ(i).Visible = True
            RSTControl.EQHandOff(i).Visible = True
            RSTControl.TowerEQ(i).Visible = True
            RSTControl.EQInterlock(i).Visible = True
        Next

        Select Case _L8B.Setting.Main.NumberEQ
            Case 1
                RSTControl.EQ(1).Visible = True
                RSTControl.EQHandOff(1).Visible = True
                RSTControl.EQ(2).Visible = False
                RSTControl.EQHandOff(2).Visible = False
                RSTControl.EQ(3).Visible = False
                RSTControl.EQHandOff(3).Visible = False
                RSTControl.TowerEQ(1).Visible = True
                RSTControl.TowerEQ(2).Visible = False
                RSTControl.TowerEQ(3).Visible = False

            Case 2
                RSTControl.EQ(1).Visible = True
                RSTControl.EQHandOff(1).Visible = True
                RSTControl.EQ(2).Visible = True
                RSTControl.EQHandOff(2).Visible = True
                RSTControl.EQ(3).Visible = False
                RSTControl.EQHandOff(3).Visible = False
                RSTControl.TowerEQ(1).Visible = True
                RSTControl.TowerEQ(2).Visible = True
                RSTControl.TowerEQ(3).Visible = False
            Case 3
                RSTControl.EQ(1).Visible = True
                RSTControl.EQHandOff(1).Visible = True
                RSTControl.EQ(2).Visible = True
                RSTControl.EQHandOff(2).Visible = True
                RSTControl.EQ(3).Visible = True
                RSTControl.EQHandOff(3).Visible = True
                RSTControl.TowerEQ(1).Visible = True
                RSTControl.TowerEQ(2).Visible = True
                RSTControl.TowerEQ(3).Visible = True
        End Select

        If _L8B.db.State = ConnectionState.Open Then
            UpdateListViewHostMessage()
        End If

        UpdateGUI()
        UpdateRemoteStatus()

        LabelMachineID.Text = _L8B.Setting.ID.Tool
        UpdateBufferContentMenu()
        UpdateButtonStart()
        UpdateGlassFlowMode()
        UpdatePassGlass()
        UpdateArmMode()
        UpdatColorRepairMode()
        ComboBoxManualRobotSpeed.SelectedIndex = 0
        ComboBoxGlassType.SelectedIndex = 2

        WriteLog("DateVersion ->" & DateVersion.ToString)
        _L8B.dlgLogin.ShowDialog()
    End Sub

    Public Sub UpdateGUI()
        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.ButterFly, ClsSetting.EMACHINETYPE.FI
                UpdateGlassFlowMode()
                GroupBoxGlassFlowMode.Visible = True
            Case Else
                GroupBoxGlassFlowMode.Visible = False
        End Select

        For i As Integer = 1 To MaxEQ
            RSTControl.EQ(i).ConnectColor = Color.Green
            RSTControl.EQ(i).DisConnectColor = Color.Black
            RSTControl.EQ(i).SetGlassColor = Color.LightSkyBlue
            Select Case i
                Case 1
                    RSTControl.EQ(i).EQName = _L8B.Setting.ID.EQ1

                Case 2
                    RSTControl.EQ(i).EQName = _L8B.Setting.ID.EQ2

                Case 3
                    RSTControl.EQ(i).EQName = _L8B.Setting.ID.EQ3

            End Select
        Next

        LabelCVToolID.Text = _L8B.Setting.ID.CV

        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.ButterFly
                GroupBoxColorRepairMode.Visible = False
                GroupBoxGlassFlowMode.Visible = True
                CheckBoxReviewMode.Visible = False
                UpdateGlassFlowMode()

            Case ClsSetting.EMACHINETYPE.FI
                GroupBoxColorRepairMode.Visible = False
                GroupBoxGlassFlowMode.Visible = True
                CheckBoxReviewMode.Visible = False
                UpdateGlassFlowMode()

            Case ClsSetting.EMACHINETYPE.REPAIR
                GroupBoxColorRepairMode.Visible = False
                GroupBoxGlassFlowMode.Visible = False
                CheckBoxReviewMode.Visible = True

            Case ClsSetting.EMACHINETYPE.COLORREPAIR
                GroupBoxColorRepairMode.Visible = True
                GroupBoxGlassFlowMode.Visible = False
                CheckBoxReviewMode.Visible = True
        End Select

        For i As Integer = 1 To 2
            RstguiCtrlRBT.GxID(i) = mInfo.Robot.Glass(i).GlassID
            RstguiCtrlRBT.WithGx(i) = mInfo.Robot.fGlassExist(i)
        Next

        'If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.COLORREPAIR Then
        '    LabelColorRepairMode.Visible = True
        '    If mMain.Setting.Main.ColorRepairMode = L8BIFPRJ.clsPLC.eColorRepairMode.NORMAL_MODE Then
        '        LabelColorRepairMode.Text = "Normal Repair Mode"
        '    ElseIf mMain.Setting.Main.ColorRepairMode = L8BIFPRJ.clsPLC.eColorRepairMode.COLOR_MODE Then
        '        LabelColorRepairMode.Text = "Color Repair Mode"
        '    End If
        'Else
        '    LabelColorRepairMode.Visible = False
        'End If
    End Sub


    Public Sub UpdateGlassFlowMode()        
        Select Case _L8B.Setting.Main.GlassFlowMode
            Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                ButtonUMode.BackColor = Color.Transparent
                ButtonUMode.ForeColor = Color.Gray
                ButtonIMode.BackColor = Color.LightBlue
                ButtonIMode.ForeColor = Color.Black

                Select Case _L8B.Setting.Main.NumberPort
                    Case 1
                        Port1ToolStripMenuItem.Enabled = False
                        Port2ToolStripMenuItem.Enabled = False
                        Port3ToolStripMenuItem.Enabled = False
                    Case 2
                        Port1ToolStripMenuItem.Enabled = False
                        Port2ToolStripMenuItem.Enabled = False
                        Port3ToolStripMenuItem.Enabled = False
                    Case 3
                        Port1ToolStripMenuItem.Enabled = False
                        Port2ToolStripMenuItem.Enabled = False
                        Port3ToolStripMenuItem.Enabled = False
                End Select

            Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                ButtonUMode.BackColor = Color.LightBlue
                ButtonUMode.ForeColor = Color.Black
                ButtonIMode.BackColor = Color.Transparent
                ButtonIMode.ForeColor = Color.Gray

                Select Case _L8B.Setting.Main.NumberPort
                    Case 1
                        Port1ToolStripMenuItem.Enabled = True
                        Port2ToolStripMenuItem.Enabled = False
                        Port3ToolStripMenuItem.Enabled = False
                    Case 2
                        Port1ToolStripMenuItem.Enabled = True
                        Port2ToolStripMenuItem.Enabled = True
                        Port3ToolStripMenuItem.Enabled = False
                    Case 3
                        Port1ToolStripMenuItem.Enabled = True
                        Port2ToolStripMenuItem.Enabled = True
                        Port3ToolStripMenuItem.Enabled = True
                End Select

        End Select

    End Sub

    Public Sub UpdateButtonStart()
        Select Case _L8B.PLC.RSTRobotCommandMode
            Case L8BIFPRJ.clsPLC.eRSTCommandMode.START
                ButtonStart.Enabled = True
                ButtonStart.Text = "Start"
                ButtonStart.BackColor = Color.LightGreen

            Case L8BIFPRJ.clsPLC.eRSTCommandMode.STOP
                ButtonStart.Enabled = True
                ButtonStart.Text = "Stop"
                ButtonStart.BackColor = Color.LightPink
        End Select
    End Sub

    Public Sub UpdateBufferContentMenu()
        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.ButterFly
                OKToolStripMenuItem.Enabled = True
                NGToolStripMenuItem.Enabled = True
                GrayToolStripMenuItem.Enabled = True
                LDToolStripMenuItem.Enabled = True
                Select Case _L8B.Setting.Main.NumberPort
                    Case 1
                        CASSETTE1ToolStripMenuItem.Enabled = True
                        CASSETTE2ToolStripMenuItem.Enabled = False
                        CASSETTE3ToolStripMenuItem.Enabled = False
                    Case 2
                        CASSETTE1ToolStripMenuItem.Enabled = True
                        CASSETTE2ToolStripMenuItem.Enabled = True
                        CASSETTE3ToolStripMenuItem.Enabled = False
                    Case 3
                        CASSETTE1ToolStripMenuItem.Enabled = True
                        CASSETTE2ToolStripMenuItem.Enabled = True
                        CASSETTE3ToolStripMenuItem.Enabled = True
                End Select
                EQ1StandardGlassToolStripMenuItem.Enabled = True
                EQ2StandardGlassToolStripMenuItem.Enabled = True

            Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR
                OKToolStripMenuItem.Enabled = True
                NGToolStripMenuItem.Enabled = True
                GrayToolStripMenuItem.Enabled = True
                LDToolStripMenuItem.Enabled = True
                CASSETTE1ToolStripMenuItem.Visible = False
                CASSETTE2ToolStripMenuItem.Visible = False
                CASSETTE3ToolStripMenuItem.Visible = False
                EQ1StandardGlassToolStripMenuItem.Visible = False
                EQ2StandardGlassToolStripMenuItem.Visible = False

            Case ClsSetting.EMACHINETYPE.FI
                If _L8B.Setting.Main.NumberBuffer = 1 Then
                    OKToolStripMenuItem.Visible = False
                    NGToolStripMenuItem.Visible = False
                    GrayToolStripMenuItem.Visible = False
                    LDToolStripMenuItem.Visible = False
                    CASSETTE1ToolStripMenuItem.Visible = True
                    CASSETTE2ToolStripMenuItem.Visible = True
                    If _L8B.Setting.Main.NumberBuffer >= 3 Then
                        CASSETTE3ToolStripMenuItem.Visible = True
                    Else
                        CASSETTE3ToolStripMenuItem.Visible = False
                    End If
                    EQ1StandardGlassToolStripMenuItem.Visible = True
                    EQ2StandardGlassToolStripMenuItem.Visible = False
                Else
                    If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                        OKToolStripMenuItem.Visible = True
                        NGToolStripMenuItem.Visible = True
                        GrayToolStripMenuItem.Visible = True
                        LDToolStripMenuItem.Visible = True
                        CASSETTE1ToolStripMenuItem.Visible = False
                        CASSETTE2ToolStripMenuItem.Visible = False
                        CASSETTE3ToolStripMenuItem.Visible = False
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    Else
                        OKToolStripMenuItem.Visible = False
                        NGToolStripMenuItem.Visible = False
                        GrayToolStripMenuItem.Visible = False
                        LDToolStripMenuItem.Visible = False
                        CASSETTE1ToolStripMenuItem.Visible = True
                        CASSETTE2ToolStripMenuItem.Visible = True
                        CASSETTE3ToolStripMenuItem.Visible = True
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    End If
                End If
            Case Else
        End Select

        Select Case _L8B.Setting.Main.NumberPort
            Case 1
                Port1ToolStripMenuItem.Visible = True
                Port2ToolStripMenuItem.Visible = False
                Port3ToolStripMenuItem.Visible = False
            Case 2
                Port1ToolStripMenuItem.Visible = True
                Port2ToolStripMenuItem.Visible = True
                Port3ToolStripMenuItem.Visible = False
            Case 3
                Port1ToolStripMenuItem.Visible = True
                Port2ToolStripMenuItem.Visible = True
                Port3ToolStripMenuItem.Visible = True
        End Select

        Select Case _L8B.Setting.Main.NumberEQ
            Case 1
                EQ1ToolStripMenuItem1.Visible = True
                EQ2ToolStripMenuItem1.Visible = False
                EQ3ToolStripMenuItem1.Visible = False
            Case 2
                EQ1ToolStripMenuItem1.Visible = True
                EQ2ToolStripMenuItem1.Visible = True
                EQ3ToolStripMenuItem1.Visible = False
            Case 3
                EQ1ToolStripMenuItem1.Visible = True
                EQ2ToolStripMenuItem1.Visible = True
                EQ3ToolStripMenuItem1.Visible = True
        End Select
    End Sub

    Public Sub InitialBufferGUI(ByVal nBuffer As Integer)
        With RSTControl.CVGUIBuffer(nBuffer)
            .BufferID = nBuffer
            .GxIDShow = True
            .WithGxColor = Color.White
            .WithoutGxColor = Color.White
            For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(nBuffer)
                .GxID(i) = ""
                .WithGx(i) = False
            Next
        End With

        With RSTControl.CVGUIBufferEdit(nBuffer)
            .BufferID = nBuffer
            .GxIDShow = True
            .WithGxColor = Color.White
            .WithoutGxColor = Color.White
            For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(nBuffer)
                .GxID(i) = ""
                .WithGx(i) = False
            Next
        End With

        With RSTControl.CVGUIBufferDialog(nBuffer)
            .BufferID = nBuffer
            .GxIDShow = True
            .WithGxColor = Color.White
            .WithoutGxColor = Color.White
            For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(nBuffer)
                .GxID(i) = ""
                .WithGx(i) = False
            Next
        End With

        For i As Integer = 1 To MaxBuffer
            For j As Integer = 1 To MaxbufferSlot
                Try
                    RSTControl.CVGUIBufferEdit(i).SlotDisableRemark(j) = _L8B.Setting.Main.DisableRemark(i, j)
                Catch ex As Exception

                End Try
            Next
        Next
    End Sub

    Private Sub ButtonLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLog.Click
        _L8B.Log.Show()
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "GUI"

    Public Sub AddGUIControl()

        With RSTControl
            .CVGUIPort.Clear()
            .CVGUIPort.Add(1, guiCtrlCV1)
            .CVGUIPort.Add(2, guiCtrlCV2)
            .CVGUIPort.Add(3, guiCtrlCV3)

            .EQ.Clear()
            .EQ.Add(1, guiEQ1)
            .EQ.Add(2, guiEQ2)
            .EQ.Add(3, guiEQ3)
            .EQ(1).EQAlias = "EQ1"
            .EQ(2).EQAlias = "EQ2"
            .EQ(3).EQAlias = "EQ3"

            .EQHandOff.Clear()
            .EQHandOff.Add(1, OvalShapeHandOffEQ1)
            .EQHandOff.Add(2, OvalShapeHandOffEQ2)
            .EQHandOff.Add(3, OvalShapeHandOffEQ3)

            .EQInterlock.Clear()
            .EQInterlock.Add(1, LabelEQ1)
            .EQInterlock.Add(2, LabelEQ2)
            .EQInterlock.Add(3, LabelEQ3)

            .CVGUIBuffer.Clear()
            .CVGUIBuffer.Add(1, guiBuffer1)
            .CVGUIBuffer.Add(2, guiBuffer2)
            .CVGUIBuffer.Add(3, guiBuffer3)
            .CVGUIBuffer(1).GxEQDoneShow = False
            .CVGUIBuffer(2).GxEQDoneShow = False
            .CVGUIBuffer(3).GxEQDoneShow = False

            .CVGUIBufferEdit.Clear()
            .CVGUIBufferEdit.Add(1, guiCtrlSlots1)
            .CVGUIBufferEdit.Add(2, guiCtrlSlots2)
            .CVGUIBufferEdit.Add(3, guiCtrlSlots3)
            .CVGUIBufferEdit(1).MaxEQs = _L8B.Setting.Main.NumberEQ
            .CVGUIBufferEdit(2).MaxEQs = _L8B.Setting.Main.NumberEQ
            .CVGUIBufferEdit(3).MaxEQs = _L8B.Setting.Main.NumberEQ
            .CVGUIBufferEdit(1).GxEQDoneShow = True
            .CVGUIBufferEdit(2).GxEQDoneShow = True
            .CVGUIBufferEdit(3).GxEQDoneShow = True

            .CVGUIBufferDialog.Clear()
            .CVGUIBufferDialog.Add(1, _L8B.dlgBufferGlassInfo.RstguiCtrlSlots1)
            .CVGUIBufferDialog.Add(2, _L8B.dlgBufferGlassInfo.RstguiCtrlSlots2)
            .CVGUIBufferDialog.Add(3, _L8B.dlgBufferGlassInfo.RstguiCtrlSlots3)
            .CVGUIBufferDialog(1).GxEQDoneShow = False
            .CVGUIBufferDialog(2).GxEQDoneShow = False
            .CVGUIBufferDialog(3).GxEQDoneShow = False

            .TowerEQ.Clear()
            .TowerEQ.Add(1, guiTowerEQ1)
            .TowerEQ.Add(2, guiTowerEQ2)
            .TowerEQ.Add(3, guiTowerEQ3)

            .CVHandOff.Clear()
            .CVHandOff.Add(1, OvalShapeCV1)
            .CVHandOff.Add(2, OvalShapeCV2)
            .CVHandOff.Add(3, OvalShapeCV3)

            .CVSec.Clear()
            .CVSec.Add(1, TextBoxCVSec1)
            .CVSec.Add(2, TextBoxCVSec2)
            .CVSec.Add(3, TextBoxCVSec3)
            .CVSec.Add(4, TextBoxCVSec4)
            .CVSec.Add(5, TextBoxCVSec5)
            .CVSec.Add(6, TextBoxCVSec6)

            .CVSectionIndex.Clear()
            .CVSectionIndex.Add(1, lblCVSECID1)
            .CVSectionIndex.Add(2, lblCVSECID2)
            .CVSectionIndex.Add(3, lblCVSECID3)
            .CVSectionIndex.Add(4, lblCVSECID4)
            .CVSectionIndex.Add(5, lblCVSECID5)
            .CVSectionIndex.Add(6, lblCVSECID6)

            .CVVCR.Clear()
            .CVVCR.Add(1, PictureBoxCV1VCR1)
            .CVVCR.Add(2, PictureBoxCV1VCR2)
            .CVVCR.Add(3, PictureBoxCV1VCR3)

            .AxisMileage.Clear()
            .AxisMileage.Add(1, LabelAxis1)
            .AxisMileage.Add(2, LabelAxis2)
            .AxisMileage.Add(3, LabelAxis3)
            .AxisMileage.Add(4, LabelAxis4)
            .AxisMileage.Add(5, LabelAxis5)
            .AxisMileage.Add(6, LabelAxis6)

        End With
        AddHandlerRstguiCtrlCV()
    End Sub

    Private Sub AddHandlerRstguiCtrlCV()
        AddHandler guiCtrlCV1.GUIMouseUp, AddressOf guiCtrlCVMouseUp
        AddHandler guiCtrlCV2.GUIMouseUp, AddressOf guiCtrlCVMouseUp
        AddHandler guiCtrlCV3.GUIMouseUp, AddressOf guiCtrlCVMouseUp
        AddHandler guiCtrlCV1.CSTDummyCancelChange, AddressOf guiCtrlCV1_CSTDummyCancelChange
        AddHandler guiCtrlCV2.CSTDummyCancelChange, AddressOf guiCtrlCV2_CSTDummyCancelChange
        AddHandler guiCtrlCV3.CSTDummyCancelChange, AddressOf guiCtrlCV3_CSTDummyCancelChange

        AddHandler guiCtrlCV1.PortPauseRequest, AddressOf guiCtrlCV_PortPauseRequest
        AddHandler guiCtrlCV2.PortPauseRequest, AddressOf guiCtrlCV_PortPauseRequest
        AddHandler guiCtrlCV3.PortPauseRequest, AddressOf guiCtrlCV_PortPauseRequest
        AddHandler guiCtrlCV1.PortReleaseRequest, AddressOf guiCtrlCV_PortReleaseRequest
        AddHandler guiCtrlCV2.PortReleaseRequest, AddressOf guiCtrlCV_PortReleaseRequest
        AddHandler guiCtrlCV3.PortReleaseRequest, AddressOf guiCtrlCV_PortReleaseRequest

    End Sub

    Private Sub guiCtrlCV_PortPauseRequest(ByVal sender As Object)
        Dim sltPort As Integer
        Try
            WriteLog("guiCtrlCV_PortPauseRequest sender " & sender.name)
        Catch ex As Exception

        End Try
        Select Case DirectCast(sender, RSTShapFlowGUI.RSTGUICtrlCV).Name
            Case "guiCtrlCV1"
                sltPort = 1
            Case "guiCtrlCV2"
                sltPort = 2
            Case "guiCtrlCV3"
                sltPort = 3
        End Select

        If mInfo.CV.Link <> L8BIFPRJ.clsPLC.eLinkStatus.LINKING Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "CV Not link, Please try again after Linking.", MsgBoxStyle.OkOnly, 20)
            RSTControl.CVGUIPort(sltPort).PortRelease()
            Exit Sub
        End If

        If mInfo.Port(sltPort).Status = PORTSTATUS.PROCESSWAIT Or mInfo.Port(sltPort).Status = PORTSTATUS.PROCESSING Then
            _L8B.PLC.PortPause(sltPort)
            mInfo.Port(sltPort).PortPauseRequest = True
            mInfo.Port(sltPort).PortPauseRequestDate = Now
        Else
            WriteLog("[Ignore]No in processing or writting port=" & sltPort, LogMessageType.Info)
            RSTControl.CVGUIPort(sltPort).PortRelease()
            mInfo.Port(sltPort).PortPauseRequest = False
        End If

    End Sub

    Private Sub guiCtrlCV_PortReleaseRequest(ByVal sender As Object)
        Dim sltPort As Integer

        Select Case DirectCast(sender, RSTShapFlowGUI.RSTGUICtrlCV).Name
            Case "guiCtrlCV1"
                sltPort = 1
            Case "guiCtrlCV2"
                sltPort = 2
            Case "guiCtrlCV3"
                sltPort = 3
        End Select

        If mInfo.CV.Link <> L8BIFPRJ.clsPLC.eLinkStatus.LINKING Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "CV Not link, Please try again after Linking.", MsgBoxStyle.OkOnly, 20)
            Exit Sub
        End If

        _L8B.PLC.PortRelease(sltPort)
        mInfo.Port(sltPort).PortPauseRequest = False
    End Sub

    Private Sub guiCtrlCV1_CSTDummyCancelChange(ByVal fCancel As Boolean)
        RstguiCtrlCVCSTDummyCancelChange(1, guiCtrlCV1, fCancel)
    End Sub

    Private Sub guiCtrlCV2_CSTDummyCancelChange(ByVal fCancel As Boolean)
        RstguiCtrlCVCSTDummyCancelChange(2, guiCtrlCV2, fCancel)
    End Sub

    Private Sub guiCtrlCV3_CSTDummyCancelChange(ByVal fCancel As Boolean)
        RstguiCtrlCVCSTDummyCancelChange(3, guiCtrlCV3, fCancel)
    End Sub

    Private Sub RstguiCtrlCVCSTDummyCancelChange(ByVal nPort As Integer, ByVal sender As Object, ByVal fCancel As Boolean)
        If Not _L8B.PLC.CassetteInPort(nPort) OrElse mInfo.CV.Link <> L8BIFPRJ.clsPLC.eLinkStatus.LINKING Then
            DirectCast(sender, RSTShapFlowGUI.RSTGUICtrlCV).CSTDummyCancel = False
            Exit Sub
        End If

        ''
        If fCancel AndAlso (mInfo.Port(nPort).Status = PORTSTATUS.CVUNLOADEDCOMPLETE Or mInfo.Port(nPort).Status = PORTSTATUS.UNLOADREQUEST Or mInfo.Port(nPort).Status = PORTSTATUS.LOADCOMPLETE) Then
            _L8B.PLC.CassetteDummyCancel(nPort)
            mInfo.Port(nPort).fDummyCancel = True
            ''
        Else
            DirectCast(sender, RSTShapFlowGUI.RSTGUICtrlCV).CSTDummyCancel = False
            If fCancel Then
                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "[fail] Dummy Cancel", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok)
            End If
        End If
    End Sub

    Private Sub guiCtrlCVMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, ByVal vLocation As Point)
        If mInfo.CV.Link <> L8BIFPRJ.clsPLC.eLinkStatus.LINKING Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "CV Not link, Please try again after Linking.", MsgBoxStyle.OkOnly, 20)
            Exit Sub
        End If

        If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
            UnloaderToolStripMenuItem.Enabled = False
        Else
            UnloaderToolStripMenuItem.Enabled = True
        End If

        If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.FI OrElse _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.ButterFly Then
            AUTOToolStripMenuItem.Visible = True
            MIXNGToolStripMenuItem.Visible = False
        Else
            AUTOToolStripMenuItem.Visible = False
            MIXNGToolStripMenuItem.Visible = True
            If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.COLORREPAIR AndAlso _L8B.Setting.Main.ColorRepairMode = L8BIFPRJ.clsPLC.eColorRepairMode.COLOR_MODE Then
                GrayToolStripMenuItem1.Visible = False
            Else
                GrayToolStripMenuItem1.Visible = True
            End If
        End If

        Select Case DirectCast(sender, RSTShapFlowGUI.RSTGUICtrlCV).Name
            Case "guiCtrlCV1"
                'CancelToolStripMenuItem.Enabled = IIf(mInfo.Port(1).PortFAStatus = ePortFAStatus.LoadComplete, True, False) ' _L8B.PLC.CassetteInPort(1)
                CancelToolStripMenuItem.Visible = True
                CancelToolStripMenuItem.Enabled = True
                CancelToolStripMenuItem.ForeColor = Color.Black
                ContextMenuStripPortControl.Show(sender, e.Location + vLocation)
                WriteLog("CancelToolStripMenuItem.Enabled =" & _L8B.PLC.CassetteInPort(1))
                SelectPort = 1
            Case "guiCtrlCV2"
                'CancelToolStripMenuItem.Enabled = IIf(mInfo.Port(2).PortFAStatus = ePortFAStatus.LoadComplete, True, False) ' _L8B.PLC.CassetteInPort(2)
                CancelToolStripMenuItem.Enabled = True
                CancelToolStripMenuItem.Visible = True
                CancelToolStripMenuItem.ForeColor = Color.Black
                ContextMenuStripPortControl.Show(sender, e.Location + vLocation)
                WriteLog("CancelToolStripMenuItem.Enabled =" & _L8B.PLC.CassetteInPort(1))
                SelectPort = 2
            Case "guiCtrlCV3"
                'CancelToolStripMenuItem.Enabled = IIf(mInfo.Port(3).PortFAStatus = ePortFAStatus.LoadComplete, True, False) '_L8B.PLC.CassetteInPort(3)
                CancelToolStripMenuItem.Enabled = True
                CancelToolStripMenuItem.Visible = True
                CancelToolStripMenuItem.ForeColor = Color.Black
                ContextMenuStripPortControl.Show(sender, e.Location + vLocation)
                WriteLog("CancelToolStripMenuItem.Enabled =" & _L8B.PLC.CassetteInPort(1))
                SelectPort = 3
        End Select
        If _L8B.PLC.CassetteInPort(SelectPort) Then
            PortTypeLoaderToolStripMenuItem.Visible = True
            CassetteInfoToolStripMenuItem.Enabled = True
            Select Case mInfo.Port(SelectPort).Status
                Case PORTSTATUS.CVUNLOADEDCOMPLETE, PORTSTATUS.UNLOADREQUEST, PORTSTATUS.LOADREQUEST
                    PortTypeLoaderToolStripMenuItem.Enabled = True
                Case Else
                    PortTypeLoaderToolStripMenuItem.Enabled = False

            End Select
        Else
            PortTypeLoaderToolStripMenuItem.Visible = True
            PortTypeLoaderToolStripMenuItem.Enabled = True
            CassetteInfoToolStripMenuItem.Enabled = False
        End If

    End Sub


    Public Sub CassetteExistUpdate(ByVal nPort As Integer)
        If Not _L8B.PLC.CassetteInPort(nPort) Then
            RSTControl.CVGUIPort(nPort).CVBackColer = Color.Empty
        Else
            If mInfo.Port(nPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.LOAD Then
                RSTControl.CVGUIPort(nPort).CVBackColer = Color.LightBlue
            Else
                RSTControl.CVGUIPort(nPort).CVBackColer = Color.LightPink
            End If
        End If
    End Sub

    Public Sub SetRstguiCtrlCVCSTDummyCancelOff(ByVal nPort As Integer)
        Select Case nPort
            Case 1
                RSTControl.CVGUIPort(nPort).CSTDummyCancel = False

            Case 2
                RSTControl.CVGUIPort(nPort).CSTDummyCancel = False

            Case 3
                RSTControl.CVGUIPort(nPort).CSTDummyCancel = False
        End Select
    End Sub

    Public Sub UpdateEQStatus(ByVal nEQ As Integer) ', ByVal eNewStatus As L8BIFPRJ.clsPLC.eEQStatus)
        With RSTControl.EQ(nEQ)
            .WithGlass = False
            .GlassID = MyTrim(mInfo.EQ(nEQ).GlassIDShow)
            .WithGlass = mInfo.EQ(nEQ).fGlassExistShow
            .EQConnect = IIf(mInfo.EQ(nEQ).Link = L8BIFPRJ.clsPLC.eLinkStatus.LINKING, True, False)
            .EQRunningMode = mInfo.EQ(nEQ).Status.ToString
        End With
    End Sub

    Public Sub UpdatePLCMode(ByVal zMode As String)
        ButtonAutoManual.Text = zMode '& " Mode"
        _L8B.fBypassInterfaceCheck = False

        If InStr(zMode.ToUpper, "AUTO") Then
            GroupBoxMRobot.Enabled = False
            ButtonAutoManual.BackColor = Color.LightGreen
            If TabControlMain.Controls.Contains(TabPageManual) Then
                TabControlMain.Controls.Remove(TabPageManual)
            End If
            '2010/06/01 for interupt the PM test
            mInfo.PM.Continued = False
        Else
            GroupBoxMRobot.Enabled = True
            ButtonAutoManual.BackColor = Color.IndianRed
            If Not TabControlMain.Controls.Contains(TabPageManual) Then
                TabControlMain.Controls.Add(TabPageManual)
            End If
        End If
    End Sub

    Public Sub UpdateRobotStatus()
        LabelRobotStatus.Text = mInfo.Robot.Status.ToString
        Select Case mInfo.Robot.Status
            Case L8BIFPRJ.clsPLC.eRSTStatus.DOWN
                'ButtonInitial.Enabled = True

            Case L8BIFPRJ.clsPLC.eRSTStatus.STOPPED
                'ButtonStart.Text = "STOP"

            Case Else
                'ButtonInitial.Enabled = False
        End Select
    End Sub

    Public Sub UpdateRobotGUI(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm)
        RstguiCtrlRBT.GxID(nArm + 1) = mInfo.Robot.GlassIDShow(nArm + 1)
        RstguiCtrlRBT.WithGx(nArm + 1) = mInfo.Robot.fGlassExistShow(nArm + 1)
    End Sub

    Public Sub UpdateCVStatus() ', ByVal eNewStatus As L8BIFPRJ.clsPLC.eEQStatus)
        LabelCVStatus.Text = mInfo.CV.Status.ToString
    End Sub

    Public Sub UpdateCVPortGUI(ByVal nPort As Integer)
        With RSTControl.CVGUIPort(nPort)
            WriteLog("UpdateCVPortGUI -> CassetteInPort:" & nPort & " = " & _L8B.PLC.CassetteInPort(nPort), LogMessageType.Info)
            .CVBackColer = Color.Transparent
            'If _L8B.PLC.CassetteInPort(nPort) Then
            '    .CVBackColer = Color.LightSalmon
            'End If
            CassetteExistUpdate(nPort)
            .PortEnableCaption = mInfo.Port(nPort).PortEnable
            If _L8B.CIM.LotInfo(nPort) Is Nothing Then
                .CassetteID = ""
                .RecipeID = ""
                .ProductCode = ""
            Else
                .CassetteID = _L8B.CIM.LotInfo(nPort).CassetteID
                .RecipeID = _L8B.CIM.LotInfo(nPort).RecipeName
                .ProductCode = _L8B.CIM.LotInfo(nPort).ProductCode
            End If

            'If mInfo.Port(nPort).PortInfo Is Nothing Then
            '    .RunningMode = ""
            'Else
            '    .RunningMode = mInfo.Port(nPort).PortInfo.PortStatus.ToString
            'End If

            If .PortEnableCaption Then
                Select Case mInfo.Port(nPort).CassetteMode
                    Case L8BIFPRJ.clsPLC.ePortMode.LOAD
                        mInfo.Port(nPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.LOAD
                        .TipCaption = mInfo.Port(nPort).CassetteMode.ToString
                    Case L8BIFPRJ.clsPLC.ePortMode.UNLOAD
                        mInfo.Port(nPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.UNLOAD
                        .TipCaption = mInfo.Port(nPort).CassetteMode.ToString & " / " & mInfo.Port(nPort).UnLoaderType.ToString
                        WriteLog(.TipCaption & " " & nPort)
                End Select
                .CSTStatusCaption = mInfo.Port(nPort).CassetteStatus.ToString
                .CVStatusCaption = mInfo.Port(nPort).PortFAStatus.ToString
            Else
                .TipCaption = ""
                .CSTStatusCaption = ""
                .CVStatusCaption = ""
            End If
            .CVCaption = nPort
            .PortCaption = nPort


            Select Case mInfo.Port(nPort).CassetteStatus
                Case prjSECS.clsEnumCtl.eCassetteStatus.CSTA_END
                    .CSTStatusCaption = "End"
                Case prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS
                    .CSTStatusCaption = "IN-PROCESS"
                Case prjSECS.clsEnumCtl.eCassetteStatus.CSTA_SUSPEND
                    .CSTStatusCaption = "SUSPEND"
                Case prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT
                    .CSTStatusCaption = "WAIT"
                Case prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE
                    .CSTStatusCaption = ""

            End Select
        End With

    End Sub

    Public Sub InsertGlassToCst(ByVal nPort As Integer, ByVal nSlot As Integer)
        RSTControl.CVGUIPort(nPort).InsertGlassToCST(nSlot)
    End Sub

    Public Sub UpdateBufferGUI(ByVal nBuffer As Integer, ByVal nSlot As Integer)
        '2010-11-11
        If mInfo.Buffer(nBuffer).fGlassExistShow(nSlot) Then
            RSTControl.CVGUIBuffer(nBuffer).GxID(nSlot) = mInfo.Buffer(nBuffer).GlassIDShow(nSlot)
            RSTControl.CVGUIBuffer(nBuffer).WithGx(nSlot) = mInfo.Buffer(nBuffer).fGlassExistShow(nSlot)
            RSTControl.CVGUIBufferEdit(nBuffer).GxID(nSlot) = mInfo.Buffer(nBuffer).GlassIDShow(nSlot)
            RSTControl.CVGUIBufferEdit(nBuffer).WithGx(nSlot) = mInfo.Buffer(nBuffer).fGlassExistShow(nSlot)
            RSTControl.CVGUIBufferDialog(nBuffer).GxID(nSlot) = mInfo.Buffer(nBuffer).GlassIDShow(nSlot)
            RSTControl.CVGUIBufferDialog(nBuffer).WithGx(nSlot) = mInfo.Buffer(nBuffer).fGlassExistShow(nSlot)

            Dim myProductCode As String = mInfo.Buffer(nBuffer).Glass(nSlot).ProductCode
            If Len(myProductCode) = 0 Then
                Dim BufferGlassInfo As L8BIFPRJ.clsBufferGlassInfo = _L8B.PLC.GetBufferGlassInfo(nBuffer, nSlot)
                myProductCode = MyTrim(BufferGlassInfo.ProductCode)
            End If
            If Len(myProductCode) = 0 Then
                _L8B.frmMain.RSTControl.CVGUIBufferEdit(nBuffer).GxID(nSlot) = mInfo.Buffer(nBuffer).Glass(nSlot).GlassID & " - " & mInfo.Buffer(nBuffer).Glass(nSlot).LotRecipeID
            Else
                _L8B.frmMain.RSTControl.CVGUIBufferEdit(nBuffer).GxID(nSlot) = mInfo.Buffer(nBuffer).Glass(nSlot).GlassID & " - " & mInfo.Buffer(nBuffer).Glass(nSlot).ProductCode & " - " & mInfo.Buffer(nBuffer).Glass(nSlot).LotRecipeID
            End If

            '20110107
            Dim fEQDone(3) As Boolean
            Dim VisitEQ As Integer = GlassEQEncode(mInfo.Buffer(nBuffer).Glass(nSlot), fEQDone)
            RSTControl.CVGUIBuffer(nBuffer).Processed(nSlot) = VisitEQ
            RSTControl.CVGUIBufferEdit(nBuffer).Processed(nSlot) = VisitEQ
            RSTControl.CVGUIBufferEdit(nBuffer).EQDone(1, nSlot) = fEQDone(1)
            RSTControl.CVGUIBufferEdit(nBuffer).EQDone(2, nSlot) = fEQDone(2)
            RSTControl.CVGUIBufferEdit(nBuffer).EQDone(3, nSlot) = fEQDone(3)
            RSTControl.CVGUIBufferDialog(nBuffer).Processed(nSlot) = VisitEQ

            RSTControl.CVGUIBuffer(nBuffer).Reviewed(nSlot) = mInfo.Buffer(nBuffer).fGlassReview(nSlot)
            RSTControl.CVGUIBufferEdit(nBuffer).Reviewed(nSlot) = mInfo.Buffer(nBuffer).fGlassReview(nSlot)
            RSTControl.CVGUIBufferDialog(nBuffer).Reviewed(nSlot) = mInfo.Buffer(nBuffer).fGlassReview(nSlot)
        Else
            RSTControl.CVGUIBuffer(nBuffer).GxID(nSlot) = ""
            RSTControl.CVGUIBuffer(nBuffer).WithGx(nSlot) = False
            RSTControl.CVGUIBuffer(nBuffer).Processed(nSlot) = 0
            RSTControl.CVGUIBuffer(nBuffer).Reviewed(nSlot) = False

            RSTControl.CVGUIBufferEdit(nBuffer).GxID(nSlot) = ""
            RSTControl.CVGUIBufferEdit(nBuffer).WithGx(nSlot) = False
            RSTControl.CVGUIBufferEdit(nBuffer).Processed(nSlot) = 0
            RSTControl.CVGUIBufferEdit(nBuffer).Reviewed(nSlot) = False
            RSTControl.CVGUIBufferEdit(nBuffer).EQDone(1, nSlot) = False
            RSTControl.CVGUIBufferEdit(nBuffer).EQDone(2, nSlot) = False
            RSTControl.CVGUIBufferEdit(nBuffer).EQDone(3, nSlot) = False

            RSTControl.CVGUIBufferDialog(nBuffer).GxID(nSlot) = ""
            RSTControl.CVGUIBufferDialog(nBuffer).WithGx(nSlot) = False
            RSTControl.CVGUIBufferDialog(nBuffer).Processed(nSlot) = 0
            RSTControl.CVGUIBufferDialog(nBuffer).Reviewed(nSlot) = False

        End If
        UpdateBufferSlotDest(nBuffer, nSlot, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.NA)
    End Sub

    Public Sub UpdateEQLinkStatus(ByVal nEQ As Integer)
        If mInfo.EQ(nEQ).Link = L8BIFPRJ.clsPLC.eLinkStatus.LINKING Then
            RSTControl.TowerEQ(nEQ).Connect = True
        Else
            RSTControl.TowerEQ(nEQ).Connect = False
        End If
    End Sub

    Public Sub UpdateCVHandOff(ByVal nPosition As Integer)
        RSTControl.CVHandOff(nPosition).Visible = True
        If mInfo.Port(nPosition).HandOff Then
            RSTControl.CVHandOff(nPosition).FillColor = Color.LightGreen
        Else
            RSTControl.CVHandOff(nPosition).FillColor = Color.LightPink
        End If
    End Sub

    Public Sub UpdateCVLinkStatus()
        If mInfo.CV.Link = L8BIFPRJ.clsPLC.eLinkStatus.LINKING Then
            PictureBoxCVIndicate.BackColor = Color.Green
            RstguiStatusTowerCV.Connect = True
        Else
            PictureBoxCVIndicate.BackColor = Color.Red
            RstguiStatusTowerCV.Connect = False
        End If
    End Sub

    Public Sub UpdateCVPositionGlassIDGUI(ByVal vPosition As Integer)
        RSTControl.CVSec(vPosition).Text = mInfo.CV.GlassIDCVSection(vPosition)
    End Sub

    Public Sub UpdateCVVCR(ByVal nVCRPos As Integer)

        RSTControl.CVVCR(nVCRPos).Visible = True
        RSTControl.CVVCR(nVCRPos).BackColor = IIf(mInfo.CV.VCREnable(nVCRPos), Color.Green, Color.Red)

    End Sub

    Public Sub UpdateEQHandOff(ByVal nEQIndex As Integer)
        RSTControl.CVHandOff(nEQIndex).Visible = True
        If mInfo.EQ(nEQIndex).HandOff Then
            RSTControl.EQHandOff(nEQIndex).FillStyle = PowerPacks.FillStyle.Solid
            RSTControl.EQHandOff(nEQIndex).FillColor = Color.LightGreen
        Else
            RSTControl.EQHandOff(nEQIndex).FillStyle = PowerPacks.FillStyle.Solid
            RSTControl.EQHandOff(nEQIndex).FillColor = Color.Red
        End If

    End Sub

    Public Sub UpdatePLCConnection(ByVal bConnect As Boolean)
        RstguiStatusTowerPLC.Connect = bConnect
        If bConnect Then
            UpdateBufferSlotType()
        End If
    End Sub

    Public Sub UpdateBufferSlotType()
        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
            For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                RSTControl.CVGUIBuffer(i).SlotType(j) = _L8B.PLC.BufferSlotType(i, j)
                RSTControl.CVGUIBufferEdit(i).SlotType(j) = _L8B.PLC.BufferSlotType(i, j)
                RSTControl.CVGUIBufferDialog(i).SlotType(j) = _L8B.PLC.BufferSlotType(i, j)
            Next
        Next
    End Sub

    Public Sub UpdateListViewHostMessage()
        ListViewHostMessage.Clear()
        Dim dt As DataTable = _L8B.db.QueryHostMessageHistory

        If dt Is Nothing Then
            Exit Sub
        End If
        ListViewHostMessage.View = View.Details
        ListViewHostMessage.FullRowSelect = True
        ListViewHostMessage.GridLines = True
        ListViewHostMessage.MultiSelect = False

        ListViewHostMessage.Columns.Add("Message", 150)
        ListViewHostMessage.BeginUpdate()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim ViewItem As System.Windows.Forms.ListViewItem = ListViewHostMessage.Items.Add(dt.Rows(i)("Message"))
                Dim MsgType As String = IIf(IsDBNull(dt.Rows(i)("Type")), "", dt.Rows(i)("Type"))
                Dim fontBold As New Font(ViewItem.Font.FontFamily, ViewItem.Font.Size, FontStyle.Bold)
                ViewItem.Font = fontBold
                If MsgType = "Warning" Then
                    ViewItem.ForeColor = Color.Red
                    ViewItem.BackColor = Color.Black
                ElseIf MsgType = "" Then
                    ViewItem.ForeColor = Color.Blue
                    ViewItem.BackColor = Color.White
                Else
                    ViewItem.ForeColor = Color.Black
                    ViewItem.BackColor = Color.White
                End If
            Next
        End If
        ListViewHostMessage.EndUpdate()

    End Sub

    Public Sub RemoveGlassFromCst(ByVal nPort As Integer, ByVal nSlot As Integer)
        RSTControl.CVGUIPort(nPort).RemoveGlassFromCST(nSlot)
    End Sub

#End Region

    Private Sub ButtonLoopBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoopBack.Click
        ButtonLoopBack.Enabled = True
        ButtonLoopBack.BackColor = Color.Yellow
        _L8B.CIM.LookBack()
    End Sub

    Public Sub UpdatePassGlass(Optional ByVal NumberAdd As Integer = 0)
        _L8B.Setting.Main.Pass += NumberAdd
        _L8B.Setting.Main.TotalPass += NumberAdd
        _L8B.frmMain.ButtonPass.Text = _L8B.Setting.Main.Pass
        _L8B.frmMain.ButtonTotalPass.Text = CStr(_L8B.Setting.Main.TotalPass)
        _L8B.Setting.SavePass()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim SC_CLOSE As Integer = 61536
        Dim WM_SYSCOMMAND As Integer = 274

        '判斷是不是按Alt+F4
        If m.Msg = WM_SYSCOMMAND AndAlso m.WParam.ToInt32 = SC_CLOSE Then
            Debug.Print("User 按Alt+F4; will be ignored.")
            _L8B.dlgRetypePassWord.ShowMe("Close Program")
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        _L8B.dlgRetypePassWord.ShowMe("Close Program")
    End Sub

    Private Sub ButtonRecipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecipe.Click
        _L8B.dlgRecipeManagement.ShowMe(Me)
    End Sub

    Private Sub ButtonHSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHSMS.Click
        _L8B.CIM.Setting()
    End Sub

    Private Sub ButtonTimeOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTimeOut.Click
        _L8B.PLC.TimeoutSetting()
    End Sub

    Private Sub ButtonLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLink.Click
        WriteLog("User Click [ButtonLink]", LogMessageType.SYS)
        _L8B.dlgLinkStatus.Showme()
    End Sub

    Private Sub ButtonOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOther.Click
        ContextMenuStripOther.Show(Me, MousePosition.X - Me.Left, MousePosition.Y - Me.Top - 40)
    End Sub

    '2010/06/01
    Private Sub ButtonStopPMTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStopPMTest.Click
        With mInfo.PM
            .Continued = False
            If Not .Running Then
                PMTestStop()

            End If
        End With
        WriteLog("Stop PM Test ran " & mInfo.PM.Count & " cycles", LogMessageType.Info)
        ButtonStopPMTest.Enabled = False
    End Sub

    '2010/06/01
    Private Sub PMTestStop()
        With mInfo.PM
            .Continued = False
            .Running = False
        End With
        ButtonStartPMTest.Enabled = True
        ButtonStartPMTest.Text = "Start Test"
        ButtonStopPMTest.Enabled = False
        Dim fontRegular As New Font(LabelPMPos2.Font.FontFamily, LabelPMPos2.Font.Size, FontStyle.Regular)
        LabelPMPos1.Font = fontRegular
        LabelPMPos2.Font = fontRegular
        If mInfo.Robot.Mode <> L8BIFPRJ.clsPLC.eRSTMode.AUTO Then
            _L8B.frmMain.GroupBoxMRobot.Enabled = True
        End If
    End Sub

    '2010/06/01
    Public Sub PMTestRobotCommand(ByVal pTo As Integer)

        If mInfo.PM.RunCount > 0 Then
            ButtonStartPMTest.Text = "Start Test - " & mInfo.PM.RunCount - mInfo.PM.Count
            If mInfo.PM.Count >= mInfo.PM.RunCount Then
                PMTestStop()
                WriteLog("PM Test runs " & mInfo.PM.Count & " cycles", LogMessageType.Info)
                Exit Sub
            End If
        End If

        If ComboBoxPMModule1.Text = ComboBoxPMModule2.Text And ComboBoxPMSlot1.Text = ComboBoxPMSlot2.Text Then
            PMTestStop()
            WriteLog("PM Test runs " & mInfo.PM.Count & " cycles", LogMessageType.Info)
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "The 2 PM Test Positions are the same. PM Test Stop.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If pTo = 1 Then
            Dim fontBold As New Font(LabelPMPos1.Font.FontFamily, LabelPMPos1.Font.Size, FontStyle.Bold)
            Dim fontRegular As New Font(LabelPMPos2.Font.FontFamily, LabelPMPos2.Font.Size, FontStyle.Regular)
            LabelPMPos1.Font = fontBold
            LabelPMPos2.Font = fontRegular
            If _L8B.PLC.RobotArmWithGlass(ComboBoxPMArm.SelectedIndex) Then
                _L8B.PLC.RobotCommand(GetModule(ComboBoxPMModule1.Text), Val(ComboBoxPMSlot1.Text), ComboBoxPMArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.PUT_WAIT, ComboBoxPMGlassType.SelectedIndex + 1, ComboBoxPMRobotSpeed.SelectedIndex)
            Else
                _L8B.PLC.RobotCommand(GetModule(ComboBoxPMModule1.Text), Val(ComboBoxPMSlot1.Text), ComboBoxPMArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.GET_WAIT, ComboBoxPMGlassType.SelectedIndex + 1, ComboBoxPMRobotSpeed.SelectedIndex)
            End If
        Else
            Dim fontBold As New Font(LabelPMPos2.Font.FontFamily, LabelPMPos2.Font.Size, FontStyle.Bold)
            Dim fontRegular As New Font(LabelPMPos1.Font.FontFamily, LabelPMPos1.Font.Size, FontStyle.Regular)
            LabelPMPos1.Font = fontRegular
            LabelPMPos2.Font = fontBold

            If _L8B.PLC.RobotArmWithGlass(ComboBoxPMArm.SelectedIndex) Then
                _L8B.PLC.RobotCommand(GetModule(ComboBoxPMModule2.Text), Val(ComboBoxPMSlot2.Text), ComboBoxPMArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.PUT_WAIT, ComboBoxPMGlassType.SelectedIndex + 1, ComboBoxPMRobotSpeed.SelectedIndex)
            Else
                _L8B.PLC.RobotCommand(GetModule(ComboBoxPMModule2.Text), Val(ComboBoxPMSlot2.Text), ComboBoxPMArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.GET_WAIT, ComboBoxPMGlassType.SelectedIndex + 1, ComboBoxPMRobotSpeed.SelectedIndex)
            End If
        End If

        mInfo.PM.Count += 1
    End Sub

    Private Function GetModule(ByVal nName As String) As eRobotPosition
        Select Case nName
            Case "Buffer1"
                Return eRobotPosition.Buffer1

            Case "Buffer2"
                Return eRobotPosition.Buffer2

            Case "Buffer3"
                Return eRobotPosition.Buffer3

            Case "EQ1"
                Return eRobotPosition.EQ1

            Case "EQ2"
                Return eRobotPosition.EQ2

            Case "EQ3"
                Return eRobotPosition.EQ3

            Case "CV Port1"
                Return eRobotPosition.CVP1

            Case "CV Port2"
                Return eRobotPosition.CVP2

            Case "CV Port3"
                Return eRobotPosition.CVP3

            Case Else
                Return eRobotPosition.NONE
        End Select
    End Function

    Private Sub UpdateManualSlotSelection()
        If ComboBoxArm.Text = "" Then
            Exit Sub
        End If
        If GetModule(ComboBoxModule.Text) = eRobotPosition.NONE OrElse ComboBoxModule.Text = "" Then
            Exit Sub
        End If

        ComboBoxSlot.Enabled = False
        Dim SlotList As New ArrayList
        If _L8B.PLC.RobotArmWithGlass(ComboBoxArm.SelectedIndex) Then
            'show without glass slot
            ButtonmRstGetWait.Enabled = False
            ButtonmRstGet.Enabled = False
            ButtonmRstPutWait.Enabled = True
            ButtonmRstPut.Enabled = True
            Select Case GetModule(ComboBoxModule.Text)
                Case eRobotPosition.Buffer1
                    For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                        If Not mInfo.Buffer(1).fGlassExistShow(i) Then
                            SlotList.Add(i)
                        End If
                    Next

                    If SlotList.Count = 0 Then
                        ButtonmRstPutWait.Enabled = False
                        ButtonmRstPut.Enabled = False
                    End If
                    ComboBoxSlot.Enabled = True

                Case eRobotPosition.Buffer2
                    For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(2)
                        If Not mInfo.Buffer(2).fGlassExistShow(i) Then
                            SlotList.Add(i)
                        End If
                    Next
                    If SlotList.Count = 0 Then
                        ButtonmRstPutWait.Enabled = False
                        ButtonmRstPut.Enabled = False
                    End If
                    ComboBoxSlot.Enabled = True

                Case eRobotPosition.Buffer3
                    For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(3)
                        If Not mInfo.Buffer(3).fGlassExistShow(i) Then
                            SlotList.Add(i)
                        End If
                    Next
                    If SlotList.Count = 0 Then
                        ButtonmRstPutWait.Enabled = False
                        ButtonmRstPut.Enabled = False
                    End If
                    ComboBoxSlot.Enabled = True

                Case eRobotPosition.EQ1
                    If mInfo.EQ(1).fGlassExistShow Then
                        ButtonmRstPutWait.Enabled = False
                        ButtonmRstPut.Enabled = False
                    End If
                    SlotList.Add(0)

                Case eRobotPosition.EQ2
                    If mInfo.EQ(2).fGlassExistShow Then
                        ButtonmRstPutWait.Enabled = False
                        ButtonmRstPut.Enabled = False
                    End If
                    SlotList.Add(0)

                Case eRobotPosition.EQ3
                    If mInfo.EQ(3).fGlassExistShow Then
                        ButtonmRstPutWait.Enabled = False
                        ButtonmRstPut.Enabled = False
                    End If
                    SlotList.Add(0)

                Case eRobotPosition.CVP1
                    SlotList.Add(0)

                Case eRobotPosition.CVP2
                    SlotList.Add(0)

                Case eRobotPosition.CVP3
                    SlotList.Add(0)

            End Select

            ComboBoxSlot.DataSource = Nothing
            ComboBoxSlot.DataSource = SlotList
        Else
            'show with glass slot
            ButtonmRstGetWait.Enabled = True
            ButtonmRstGet.Enabled = True
            ButtonmRstPutWait.Enabled = False
            ButtonmRstPut.Enabled = False

            Select Case GetModule(ComboBoxModule.Text)
                Case eRobotPosition.Buffer1
                    For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                        If mInfo.Buffer(1).fGlassExistShow(i) Then
                            SlotList.Add(i)
                        End If
                    Next

                    If SlotList.Count = 0 Then
                        ButtonmRstGetWait.Enabled = False
                        ButtonmRstGet.Enabled = False
                    End If
                    ComboBoxSlot.Enabled = True

                Case eRobotPosition.Buffer2
                    For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(2)
                        If mInfo.Buffer(2).fGlassExistShow(i) Then
                            SlotList.Add(i)
                        End If
                    Next
                    If SlotList.Count = 0 Then
                        ButtonmRstGetWait.Enabled = False
                        ButtonmRstGet.Enabled = False
                    End If
                    ComboBoxSlot.Enabled = True

                Case eRobotPosition.Buffer3
                    For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(3)
                        If mInfo.Buffer(3).fGlassExistShow(i) Then
                            SlotList.Add(i)
                        End If
                    Next
                    If SlotList.Count = 0 Then
                        ButtonmRstGetWait.Enabled = False
                        ButtonmRstGet.Enabled = False
                    End If

                    ComboBoxSlot.Enabled = True
                Case eRobotPosition.EQ1
                    If Not mInfo.EQ(1).fGlassExistShow Then
                        ButtonmRstGetWait.Enabled = False
                        ButtonmRstGet.Enabled = False
                    End If
                    SlotList.Add(0)

                Case eRobotPosition.EQ2
                    If Not mInfo.EQ(2).fGlassExistShow Then
                        ButtonmRstGetWait.Enabled = False
                        ButtonmRstGet.Enabled = False
                    End If
                    SlotList.Add(0)

                Case eRobotPosition.EQ3
                    If Not mInfo.EQ(3).fGlassExistShow Then
                        ButtonmRstGetWait.Enabled = False
                        ButtonmRstGet.Enabled = False
                    End If
                    SlotList.Add(0)

                Case eRobotPosition.CVP1
                    SlotList.Add(0)

                Case eRobotPosition.CVP2
                    SlotList.Add(0)

                Case eRobotPosition.CVP3
                    SlotList.Add(0)

            End Select

            ComboBoxSlot.DataSource = Nothing
            ComboBoxSlot.DataSource = SlotList
        End If
    End Sub

    Private Sub TabControlMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlMain.SelectedIndexChanged

        _L8B.PLC.CVGUI = False
        _L8B.PLC.EQGUI = False
        _L8B.PLC.GeneralGUI = False

        Select Case TabControlMain.SelectedTab.Text
            Case "General"
                _L8B.PLC.GeneralGUI = True

            Case "Manual"
                'If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                '    CheckBoxPLCOnline.Enabled = True
                'Else
                '    CheckBoxPLCOnline.Enabled = False
                'End If

                If ComboBoxModule.DataSource Is Nothing Then
                    Dim mList As New ArrayList
                    Dim mList1 As New ArrayList
                    Dim mList2 As New ArrayList

                    Select Case _L8B.Setting.Main.NumberBuffer
                        Case 1
                            mList.Add("Buffer1")
                        Case 2
                            mList.Add("Buffer1")
                            mList.Add("Buffer2")
                        Case 3
                            mList.Add("Buffer1")
                            mList.Add("Buffer2")
                            mList.Add("Buffer3")
                    End Select

                    Select Case _L8B.Setting.Main.NumberEQ
                        Case 1
                            mList.Add("EQ1")
                        Case 2
                            mList.Add("EQ1")
                            mList.Add("EQ2")
                        Case 3
                            mList.Add("EQ1")
                            mList.Add("EQ2")
                            mList.Add("EQ3")
                    End Select

                    Select Case _L8B.Setting.Main.NumberPort
                        Case 1
                            mList.Add("CV Port1")
                        Case 2
                            mList.Add("CV Port1")
                            mList.Add("CV Port2")
                        Case 3
                            mList.Add("CV Port1")
                            mList.Add("CV Port2")
                            mList.Add("CV Port3")
                    End Select

                    mList1 = mList.Clone()
                    mList2 = mList.Clone()
                    ComboBoxModule.DataSource = Nothing
                    ComboBoxModule.DataSource = mList

                    ComboBoxPMModule1.DataSource = Nothing
                    ComboBoxPMModule1.DataSource = mList1
                    ComboBoxPMModule2.DataSource = Nothing
                    ComboBoxPMModule2.DataSource = mList2
                End If

                If ComboBoxPMGlassType.Text = "" Then
                    ComboBoxPMGlassType.SelectedIndex = 0
                End If

                If ComboBoxPMArm.Text = "" Then
                    ComboBoxPMArm.SelectedIndex = 0
                End If

                If ComboBoxPMRobotSpeed.Text = "" Then
                    ComboBoxPMRobotSpeed.SelectedIndex = 1
                End If

                If Not mInfo.PM.Continued And Not mInfo.PM.Running Then
                    ButtonStartPMTest.Enabled = True
                    ButtonStartPMTest.Text = "Start Test"
                    ButtonStopPMTest.Enabled = False
                End If

            Case "CV I/O"
                _L8B.PLC.CVGUI = True

            Case "EQ I/O"
                _L8B.PLC.EQGUI = True
        End Select
    End Sub

    Private Sub ButtonReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReset.Click
        '20110525 Modify by Turtle
        'If mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.AUTO Then
        '    ShowMessage(DialogMessage.MESSAGE.InitialLoader, DialogMessage.MESSAGELEVEL.Info, "Robto cannot initial in [AUTO] Mode", MsgBoxStyle.OkOnly, 20, MsgBoxResult.Ok)
        '    Exit Sub
        'End If

        'If mInfo.Robot.Status = L8BIFPRJ.clsPLC.eRSTStatus.RUNNING OrElse mInfo.Robot.Status = L8BIFPRJ.clsPLC.eRSTStatus.IDLE OrElse mInfo.Robot.Status = L8BIFPRJ.clsPLC.eRSTStatus.SETUP Then
        '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Please [STOP] Robot and try again.", MsgBoxStyle.OkOnly, 15, MsgBoxResult.Ok)
        '    Exit Sub
        'End If
        _L8B.Log.Hide()
        If MsgBox("Initial Robot?", MsgBoxStyle.YesNo, " Robot Initail after Robot Down.") = MsgBoxResult.Yes Then
            _L8B.PLC.AlarmReset()
            Threading.Thread.Sleep(2000)
            _L8B.PLC.RobotInitial()
        End If
    End Sub

    Private Sub ButtonHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHome.Click
        _L8B.Log.Hide()
        If MsgBox("Robot Home, Yes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            _L8B.PLC.RobotCommand(eRobotPosition.NONE, 0, L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER, L8BIFPRJ.clsPLC.eRSTAction.HOME, L8BIFPRJ.clsPLC.eGlassThickness.MM_07, L8BIFPRJ.clsPLC.eRobotSpeed.MID)
        End If
        _L8B.fBypassInterfaceCheck = False
    End Sub

    Private Sub ButtonPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPause.Click
        _L8B.PLC.RobotPause()
    End Sub

    Private Sub ButtonResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResume.Click
        _L8B.PLC.RobotResume()
    End Sub

    Private Sub ButtonmRstGetWait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonmRstGetWait.Click
        _L8B.fBypassInterfaceCheck = False
        If _L8B.PLC.RSTCommandAccept Then
            _L8B.PLC.RobotCommand(GetModule(ComboBoxModule.Text), Val(ComboBoxSlot.Text), ComboBoxArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.GET_WAIT, ComboBoxGlassType.SelectedIndex + 1, ComboBoxManualRobotSpeed.SelectedIndex + 1)
        End If
    End Sub

    Private Sub ButtonmRstGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonmRstGet.Click
        If _L8B.PLC.RSTCommandAccept Then
            _L8B.Log.Hide()
            If MsgBox("Robot Get Glass from " & ComboBoxModule.Text & " slot = " & Val(ComboBoxSlot.Text) & ", Yes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'RobotCommandButtom(False)
                _L8B.PLC.RobotCommand(GetModule(ComboBoxModule.Text), Val(ComboBoxSlot.Text), ComboBoxArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.GET, ComboBoxGlassType.SelectedIndex + 1, ComboBoxManualRobotSpeed.SelectedIndex + 1)
                _L8B.fBypassInterfaceCheck = CheckBoxBypassInterfaceCheck.Checked
                CheckBoxBypassInterfaceCheck.Checked = False
            End If
        End If
    End Sub

    Private Sub ButtonmRstPutWait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonmRstPutWait.Click
        _L8B.fBypassInterfaceCheck = False
        If _L8B.PLC.RSTCommandAccept Then
            'RobotCommandButtom(False)
            _L8B.PLC.RobotCommand(GetModule(ComboBoxModule.Text), Val(ComboBoxSlot.Text), ComboBoxArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.PUT_WAIT, ComboBoxGlassType.SelectedIndex + 1, ComboBoxManualRobotSpeed.SelectedIndex + 1)
        End If
    End Sub

    Private Sub ButtonmRstPut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonmRstPut.Click
        If _L8B.PLC.RSTCommandAccept Then
            _L8B.Log.Hide()
            If MsgBox("Robot Put Glass to " & ComboBoxModule.Text & " slot = " & Val(ComboBoxSlot.Text) & ", Yes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'RobotCommandButtom(False)
                _L8B.PLC.RobotCommand(GetModule(ComboBoxModule.Text), Val(ComboBoxSlot.Text), ComboBoxArm.SelectedIndex, L8BIFPRJ.clsPLC.eRSTAction.PUT, ComboBoxGlassType.SelectedIndex + 1, ComboBoxManualRobotSpeed.SelectedIndex + 1)
                _L8B.fBypassInterfaceCheck = CheckBoxBypassInterfaceCheck.Checked
                CheckBoxBypassInterfaceCheck.Checked = False
            End If
        End If
    End Sub

    'Dim dlgRoboGlasInfo As New DialogRobotGlassInfo
    'Dim dlgBufferGlasInfo As New DialogBufferGlassInfo

    Private Sub ButtonRobot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRobot.Click
        _L8B.dlgRoboGlasInfo.ShowMe()
    End Sub

    Private Sub ButtonBuffer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuffer.Click
        _L8B.dlgBufferGlassInfo.ShowMe()
    End Sub

    Private Sub ButtonAllGlassErease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAllGlassErease.Click
        'mInfo.GlassIDStore.Clear()
        'mMain.DB.ClearAllGlassData()
    End Sub

    Private Sub ButtonModulateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonModulateAccount.Click
        If MyTrim(ModulateSourcePos.Text).Length = 0 OrElse MyTrim(ModulateSourceSlot.Text).Length = 0 OrElse MyTrim(ModulateDestinationPos.Text).Length = 0 OrElse MyTrim(ModulateDestinationSlot.Text).Length = 0 Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Please fill out all blanks!!", MsgBoxStyle.OkOnly, 5, MsgBoxResult.Ok)
            Exit Sub
        End If
        ButtonModulateAccount.Enabled = False

        If MsgBox("Does GlassInfo Modulate from " & ModulateSourcePos.Text & "/" & ModulateSourceSlot.Text & " to " & ModulateDestinationPos.Text & "/" & ModulateDestinationSlot.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Select Case ModulateSourcePos.Text
                Case "Robot"
                    Select Case ModulateDestinationPos.Text
                        Case "Robot"   'robot-> robot
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.GetArmGlassInfo(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.RobotGlassErease(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.WriteArmGlassInfo(ModulateDestinationSlot.SelectedIndex) = SourceRobotGlassInfo
                            End If

                        Case "EQ1"  'robot-> EQ1
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.GetArmGlassInfo(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.RobotGlassErease(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(1) = SourceRobotGlassInfo
                            End If

                        Case "EQ2" 'robot-> EQ2
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.GetArmGlassInfo(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.RobotGlassErease(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(2) = SourceRobotGlassInfo
                            End If

                        Case "EQ3"  'robot-> EQ3
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.GetArmGlassInfo(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.RobotGlassErease(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(3) = SourceRobotGlassInfo
                            End If

                        Case Else   'robot-> buffer
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            Dim DestBufferGlassInfo As New L8BIFPRJ.clsBufferGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceRobotGlassInfo = _L8B.PLC.GetArmGlassInfo(ModulateSourceSlot.SelectedIndex)
                                _L8B.PLC.RobotGlassErease(ModulateSourceSlot.SelectedIndex)

                                With DestBufferGlassInfo
                                    .AOIFunctionMode = SourceRobotGlassInfo.AOIFunctionMode
                                    .CSTID = SourceRobotGlassInfo.CSTID
                                    .CurrentRecipe = SourceRobotGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceRobotGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceRobotGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceRobotGlassInfo.EPPID(2)
                                    .GlassGrade = SourceRobotGlassInfo.GlassGrade
                                    .GlassID = SourceRobotGlassInfo.GlassID
                                    .GlassScrapFlag = SourceRobotGlassInfo.GlassScrapFlag
                                    .MESID = SourceRobotGlassInfo.MESID
                                    .OperationID = SourceRobotGlassInfo.OperationID
                                    .PLINEID = SourceRobotGlassInfo.PLINEID
                                    .POPERID = SourceRobotGlassInfo.POPERID
                                    .PortNo = SourceRobotGlassInfo.PortNo
                                    .ProductCategory = SourceRobotGlassInfo.ProductCategory
                                    .ProductCode = SourceRobotGlassInfo.ProductCode
                                    .PTOOLID = SourceRobotGlassInfo.PTOOLID
                                    .RobotSpeed = SourceRobotGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceRobotGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceRobotGlassInfo.SlotInfo
                                    .TargetPosition = SourceRobotGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.WriteBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateDestinationPos.Text, 1)), Val(ModulateDestinationSlot.Text)) = DestBufferGlassInfo
                            End If

                    End Select

                Case "EQ1"
                    Select Case ModulateDestinationPos.Text
                        Case "Robot"   'EQ1-> robot
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(1)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(1) '20110323
                                _L8B.PLC.WriteArmGlassInfo(ModulateDestinationSlot.SelectedIndex) = SourceRobotGlassInfo
                            End If

                        Case "EQ2" 'robot-> EQ2 ?? 20110323 => EQ1-> EQ2
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(1)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(1) '20110323
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(2) = SourceRobotGlassInfo
                            End If

                        Case "EQ3"  'robot-> EQ3 ?? 20110323 => EQ1-> EQ3
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(1)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(1) '20110323
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(3) = SourceRobotGlassInfo
                            End If

                        Case Else   'EQ1-> buffer
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            Dim DestBufferGlassInfo As New L8BIFPRJ.clsBufferGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(1)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(1) '20110323

                                With DestBufferGlassInfo
                                    .AOIFunctionMode = SourceRobotGlassInfo.AOIFunctionMode
                                    .CSTID = SourceRobotGlassInfo.CSTID
                                    .CurrentRecipe = SourceRobotGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceRobotGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceRobotGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceRobotGlassInfo.EPPID(2)
                                    .GlassGrade = SourceRobotGlassInfo.GlassGrade
                                    .GlassID = SourceRobotGlassInfo.GlassID
                                    .GlassScrapFlag = SourceRobotGlassInfo.GlassScrapFlag
                                    .MESID = SourceRobotGlassInfo.MESID
                                    .OperationID = SourceRobotGlassInfo.OperationID
                                    .PLINEID = SourceRobotGlassInfo.PLINEID
                                    .POPERID = SourceRobotGlassInfo.POPERID
                                    .PortNo = SourceRobotGlassInfo.PortNo
                                    .ProductCategory = SourceRobotGlassInfo.ProductCategory
                                    .ProductCode = SourceRobotGlassInfo.ProductCode
                                    .PTOOLID = SourceRobotGlassInfo.PTOOLID
                                    .RobotSpeed = SourceRobotGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceRobotGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceRobotGlassInfo.SlotInfo
                                    .TargetPosition = SourceRobotGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.WriteBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateDestinationPos.Text, 1)), Val(ModulateDestinationSlot.Text)) = DestBufferGlassInfo
                            End If

                    End Select


                Case "EQ2"
                    Select Case ModulateDestinationPos.Text
                        Case "Robot"   'EQ2-> robot
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(2)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(2) '20110323
                                _L8B.PLC.WriteArmGlassInfo(ModulateDestinationSlot.SelectedIndex) = SourceRobotGlassInfo
                            End If

                        Case "EQ1" 'EQ2-> EQ1
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(2)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(2) '20110323
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(1) = SourceRobotGlassInfo
                            End If

                        Case "EQ3"  'EQ2-> EQ3
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(2)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(2) '20110323
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(3) = SourceRobotGlassInfo
                            End If

                        Case Else   'EQ2-> buffer
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            Dim DestBufferGlassInfo As New L8BIFPRJ.clsBufferGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(2)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(2) '20110323

                                With DestBufferGlassInfo
                                    .AOIFunctionMode = SourceRobotGlassInfo.AOIFunctionMode
                                    .CSTID = SourceRobotGlassInfo.CSTID
                                    .CurrentRecipe = SourceRobotGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceRobotGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceRobotGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceRobotGlassInfo.EPPID(2)
                                    .GlassGrade = SourceRobotGlassInfo.GlassGrade
                                    .GlassID = SourceRobotGlassInfo.GlassID
                                    .GlassScrapFlag = SourceRobotGlassInfo.GlassScrapFlag
                                    .MESID = SourceRobotGlassInfo.MESID
                                    .OperationID = SourceRobotGlassInfo.OperationID
                                    .PLINEID = SourceRobotGlassInfo.PLINEID
                                    .POPERID = SourceRobotGlassInfo.POPERID
                                    .PortNo = SourceRobotGlassInfo.PortNo
                                    .ProductCategory = SourceRobotGlassInfo.ProductCategory
                                    .ProductCode = SourceRobotGlassInfo.ProductCode
                                    .PTOOLID = SourceRobotGlassInfo.PTOOLID
                                    .RobotSpeed = SourceRobotGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceRobotGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceRobotGlassInfo.SlotInfo
                                    .TargetPosition = SourceRobotGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.WriteBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateDestinationPos.Text, 1)), Val(ModulateDestinationSlot.Text)) = DestBufferGlassInfo
                            End If

                    End Select

                Case "EQ3"
                    Select Case ModulateDestinationPos.Text
                        Case "Robot"   'EQ3-> robot
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(3)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(3) '20110323
                                _L8B.PLC.WriteArmGlassInfo(ModulateDestinationSlot.SelectedIndex) = SourceRobotGlassInfo
                            End If

                        Case "EQ1" 'EQ3-> EQ1
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(3)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(3) '20110323
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(1) = SourceRobotGlassInfo
                            End If

                        Case "EQ2"  'EQ3-> EQ2
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            'Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then
                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(3)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(3) '20110323
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(2) = SourceRobotGlassInfo
                            End If

                        Case Else   'EQ1-> buffer ??EQ3-> buffer
                            Dim SourceRobotGlassInfo As L8BIFPRJ.clsArmGlassInfo
                            Dim DestBufferGlassInfo As New L8BIFPRJ.clsBufferGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceRobotGlassInfo = _L8B.PLC.L8BPLC.GetEQGlassInfo(3)
                                _L8B.PLC.L8BPLC.DeleteEQGlassInfo(3) '20110323

                                With DestBufferGlassInfo
                                    .AOIFunctionMode = SourceRobotGlassInfo.AOIFunctionMode
                                    .CSTID = SourceRobotGlassInfo.CSTID
                                    .CurrentRecipe = SourceRobotGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceRobotGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceRobotGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceRobotGlassInfo.EPPID(2)
                                    .GlassGrade = SourceRobotGlassInfo.GlassGrade
                                    .GlassID = SourceRobotGlassInfo.GlassID
                                    .GlassScrapFlag = SourceRobotGlassInfo.GlassScrapFlag
                                    .MESID = SourceRobotGlassInfo.MESID
                                    .OperationID = SourceRobotGlassInfo.OperationID
                                    .PLINEID = SourceRobotGlassInfo.PLINEID
                                    .POPERID = SourceRobotGlassInfo.POPERID
                                    .PortNo = SourceRobotGlassInfo.PortNo
                                    .ProductCategory = SourceRobotGlassInfo.ProductCategory
                                    .ProductCode = SourceRobotGlassInfo.ProductCode
                                    .PTOOLID = SourceRobotGlassInfo.PTOOLID
                                    .RobotSpeed = SourceRobotGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceRobotGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceRobotGlassInfo.SlotInfo
                                    .TargetPosition = SourceRobotGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.WriteBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateDestinationPos.Text, 1)), Val(ModulateDestinationSlot.Text)) = DestBufferGlassInfo
                            End If

                    End Select


                Case Else
                    Select Case ModulateDestinationPos.Text
                        Case "Robot"     'Buffer-> robot
                            Dim SourceBufferGlassInfo As L8BIFPRJ.clsBufferGlassInfo
                            Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceBufferGlassInfo = _L8B.PLC.GetBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                _L8B.PLC.BufferGlassErease(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                With DestRobotGlassInfo
                                    .AOIFunctionMode = SourceBufferGlassInfo.AOIFunctionMode
                                    .CSTID = SourceBufferGlassInfo.CSTID
                                    .CurrentRecipe = SourceBufferGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceBufferGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceBufferGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceBufferGlassInfo.EPPID(2)
                                    .GlassGrade = SourceBufferGlassInfo.GlassGrade
                                    .GlassID = SourceBufferGlassInfo.GlassID
                                    .GlassScrapFlag = SourceBufferGlassInfo.GlassScrapFlag
                                    .MESID = SourceBufferGlassInfo.MESID
                                    .OperationID = SourceBufferGlassInfo.OperationID
                                    .PLINEID = SourceBufferGlassInfo.PLINEID
                                    .POPERID = SourceBufferGlassInfo.POPERID
                                    .PortNo = SourceBufferGlassInfo.PortNo
                                    .ProductCategory = SourceBufferGlassInfo.ProductCategory
                                    .ProductCode = SourceBufferGlassInfo.ProductCode
                                    .PTOOLID = SourceBufferGlassInfo.PTOOLID
                                    .RobotSpeed = SourceBufferGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceBufferGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceBufferGlassInfo.SlotInfo
                                    .TargetPosition = SourceBufferGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.WriteArmGlassInfo(ModulateDestinationSlot.SelectedIndex) = DestRobotGlassInfo
                            End If

                        Case "EQ1"  'Buffer-> EQ1
                            Dim SourceBufferGlassInfo As L8BIFPRJ.clsBufferGlassInfo
                            Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceBufferGlassInfo = _L8B.PLC.GetBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                _L8B.PLC.BufferGlassErease(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                With DestRobotGlassInfo
                                    .AOIFunctionMode = SourceBufferGlassInfo.AOIFunctionMode
                                    .CSTID = SourceBufferGlassInfo.CSTID
                                    .CurrentRecipe = SourceBufferGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceBufferGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceBufferGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceBufferGlassInfo.EPPID(2)
                                    .GlassGrade = SourceBufferGlassInfo.GlassGrade
                                    .GlassID = SourceBufferGlassInfo.GlassID
                                    .GlassScrapFlag = SourceBufferGlassInfo.GlassScrapFlag
                                    .MESID = SourceBufferGlassInfo.MESID
                                    .OperationID = SourceBufferGlassInfo.OperationID
                                    .PLINEID = SourceBufferGlassInfo.PLINEID
                                    .POPERID = SourceBufferGlassInfo.POPERID
                                    .PortNo = SourceBufferGlassInfo.PortNo
                                    .ProductCategory = SourceBufferGlassInfo.ProductCategory
                                    .ProductCode = SourceBufferGlassInfo.ProductCode
                                    .PTOOLID = SourceBufferGlassInfo.PTOOLID
                                    .RobotSpeed = SourceBufferGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceBufferGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceBufferGlassInfo.SlotInfo
                                    .TargetPosition = SourceBufferGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(1) = DestRobotGlassInfo
                            End If

                        Case "EQ2" 'buffer-> EQ2
                            Dim SourceBufferGlassInfo As L8BIFPRJ.clsBufferGlassInfo
                            Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceBufferGlassInfo = _L8B.PLC.GetBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                _L8B.PLC.BufferGlassErease(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                With DestRobotGlassInfo
                                    .AOIFunctionMode = SourceBufferGlassInfo.AOIFunctionMode
                                    .CSTID = SourceBufferGlassInfo.CSTID
                                    .CurrentRecipe = SourceBufferGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceBufferGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceBufferGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceBufferGlassInfo.EPPID(2)
                                    .GlassGrade = SourceBufferGlassInfo.GlassGrade
                                    .GlassID = SourceBufferGlassInfo.GlassID
                                    .GlassScrapFlag = SourceBufferGlassInfo.GlassScrapFlag
                                    .MESID = SourceBufferGlassInfo.MESID
                                    .OperationID = SourceBufferGlassInfo.OperationID
                                    .PLINEID = SourceBufferGlassInfo.PLINEID
                                    .POPERID = SourceBufferGlassInfo.POPERID
                                    .PortNo = SourceBufferGlassInfo.PortNo
                                    .ProductCategory = SourceBufferGlassInfo.ProductCategory
                                    .ProductCode = SourceBufferGlassInfo.ProductCode
                                    .PTOOLID = SourceBufferGlassInfo.PTOOLID
                                    .RobotSpeed = SourceBufferGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceBufferGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceBufferGlassInfo.SlotInfo
                                    .TargetPosition = SourceBufferGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(2) = DestRobotGlassInfo
                            End If


                        Case "EQ3"  'buffer-> EQ3
                            Dim SourceBufferGlassInfo As L8BIFPRJ.clsBufferGlassInfo
                            Dim DestRobotGlassInfo As New L8BIFPRJ.clsArmGlassInfo

                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceBufferGlassInfo = _L8B.PLC.GetBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                _L8B.PLC.BufferGlassErease(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                With DestRobotGlassInfo
                                    .AOIFunctionMode = SourceBufferGlassInfo.AOIFunctionMode
                                    .CSTID = SourceBufferGlassInfo.CSTID
                                    .CurrentRecipe = SourceBufferGlassInfo.CurrentRecipe
                                    .DMQCGrade = SourceBufferGlassInfo.DMQCGrade
                                    .EPPID(1) = SourceBufferGlassInfo.EPPID(1)
                                    .EPPID(2) = SourceBufferGlassInfo.EPPID(2)
                                    .GlassGrade = SourceBufferGlassInfo.GlassGrade
                                    .GlassID = SourceBufferGlassInfo.GlassID
                                    .GlassScrapFlag = SourceBufferGlassInfo.GlassScrapFlag
                                    .MESID = SourceBufferGlassInfo.MESID
                                    .OperationID = SourceBufferGlassInfo.OperationID
                                    .PLINEID = SourceBufferGlassInfo.PLINEID
                                    .POPERID = SourceBufferGlassInfo.POPERID
                                    .PortNo = SourceBufferGlassInfo.PortNo
                                    .ProductCategory = SourceBufferGlassInfo.ProductCategory
                                    .ProductCode = SourceBufferGlassInfo.ProductCode
                                    .PTOOLID = SourceBufferGlassInfo.PTOOLID
                                    .RobotSpeed = SourceBufferGlassInfo.RobotSpeed
                                    .SampleGlassFlag = SourceBufferGlassInfo.SampleGlassFlag
                                    .SlotInfo = SourceBufferGlassInfo.SlotInfo
                                    .TargetPosition = SourceBufferGlassInfo.TargetPosition
                                End With
                                _L8B.PLC.L8BPLC.WriteEQGlassInfo(3) = DestRobotGlassInfo
                            End If


                        Case Else        'buffer -> buffer
                            Dim SourceBufferGlassInfo As L8BIFPRJ.clsBufferGlassInfo
                            If ModulateSourceSlot.Text <> "" And ModulateDestinationSlot.Text <> "" Then

                                SourceBufferGlassInfo = _L8B.PLC.GetBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))
                                _L8B.PLC.BufferGlassErease(Val(Microsoft.VisualBasic.Strings.Right(ModulateSourcePos.Text, 1)), Val(ModulateSourceSlot.Text))

                                _L8B.PLC.WriteBufferGlassInfo(Val(Microsoft.VisualBasic.Strings.Right(ModulateDestinationPos.Text, 1)), Val(ModulateDestinationSlot.Text)) = SourceBufferGlassInfo
                            End If
                    End Select
            End Select

        End If

        ButtonModulateAccount.Enabled = True
    End Sub

    Private Sub CheckBoxBypassInterfaceCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxBypassInterfaceCheck.CheckedChanged
        _L8B.PLC.BypassHandshake(CheckBoxBypassInterfaceCheck.Checked)
    End Sub

    Private Sub CheckBoxPLCEngineerMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxPLCEngineerMode.CheckedChanged
        _L8B.PLC.EngineerMode = CheckBoxPLCEngineerMode.Checked
    End Sub

    Private Sub CheckBoxIgnoreTimeOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxIgnoreTimeOut.CheckedChanged
        _L8B.PLC.EQIgnoreTimeOut(1) = CheckBoxIgnoreTimeOut.Checked
        _L8B.PLC.EQIgnoreTimeOut(2) = CheckBoxIgnoreTimeOut.Checked
        _L8B.PLC.EQIgnoreTimeOut(3) = CheckBoxIgnoreTimeOut.Checked
    End Sub

    Private Sub ParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParameterToolStripMenuItem.Click
        _L8B.dlgParameters.ShowMe(Me)
    End Sub

    Private Sub StandardGlassTimeSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardGlassTimeSettingsToolStripMenuItem.Click
        _L8B.PLC.ShowStandardGlassSchedule()
    End Sub

    Private Sub AccountManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountManagementToolStripMenuItem.Click
        _L8B.Setting.ShowUserSetup()
    End Sub


    Dim BufferSelect As Integer
    Dim BufferSlotSelect As Integer

    Private Sub OKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.OK
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.OK Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.OK)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.OK.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Public Sub UpdateBufferSlotType(ByVal nBufferID As Integer, ByVal nBufferSlot As Integer, ByVal vType As RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType)
        RSTControl.CVGUIBuffer(nBufferID).SlotType(nBufferSlot) = vType
        RSTControl.CVGUIBufferEdit(nBufferID).SlotType(nBufferSlot) = vType
        RSTControl.CVGUIBufferDialog(nBufferID).SlotType(nBufferSlot) = vType
    End Sub

    Public Sub UpdateBufferSlotDest(ByVal nBufferID As Integer, ByVal nBufferSlot As Integer, ByVal vDest As RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination)
        RSTControl.CVGUIBuffer(nBufferID).SlotDest(nBufferSlot) = vDest
        RSTControl.CVGUIBufferEdit(nBufferID).SlotDest(nBufferSlot) = vDest
        RSTControl.CVGUIBufferDialog(nBufferID).SlotDest(nBufferSlot) = vDest
    End Sub

    Private Sub NGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NGToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.NG
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.NG Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NG)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.NG.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub GrayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrayToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.GRAY
            UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.GRAY)
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub CASSETTE1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASSETTE1ToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE1
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE1 Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.CASSETTE1)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE1.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub CASSETTE2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASSETTE2ToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE2
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE2 Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.CASSETTE2)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE2.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub CASSETTE3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASSETTE3ToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE3
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE3 Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.CASSETTE3)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE3.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub EQ1StandardGlassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ1StandardGlassToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.STANDARDGLASS_EQ1
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.STANDARDGLASS_EQ1 Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.STDGLX_EQ1)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.STANDARDGLASS_EQ1.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub EQ2StandardGlassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ2StandardGlassToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.STANDARDGLASS_EQ2
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.STANDARDGLASS_EQ2 Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.STDGLX_EQ2)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.STANDARDGLASS_EQ2.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub


    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripMenuItem.Click
        WriteLog("User select cassette cancel Port" & SelectPort)

        If mInfo.Port(SelectPort).Status = PORTSTATUS.CVUNLOADREQUEST Or mInfo.Port(SelectPort).Status = PORTSTATUS.CVUNLOADEDCOMPLETE Then
            WriteLog("Port= " & SelectPort & " is already in CVUNLOADREQUEST  or CVUNLOADEDCOMPLETE. Doesn't need call cassette cancel", LogMessageType.ERR)
        Else
            mInfo.Port(SelectPort).InProcessAbort = True
            If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I And mInfo.Port(SelectPort).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING Then
                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Don't force cancel in CV. Cassteet Cancel in [I Mode](MQC mode); Please wait for all Glass flow out and flow in. ", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok, True)
            End If
            _L8B.PLC.CassetteUnloadRequest(SelectPort)
        End If
        'End If
    End Sub

    Private Sub LoaderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoaderToolStripMenuItem.Click
        _L8B.PLC.CVPortChange(SelectPort, L8BIFPRJ.clsPLC.ePortMode.LOAD, L8BIFPRJ.clsPLC.eUnloadType.NA)
    End Sub

    Private Sub AUTOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AUTOToolStripMenuItem.Click
        _L8B.PLC.CVPortChange(SelectPort, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.AUTO)
    End Sub

    Private Sub OKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKToolStripMenuItem1.Click
        _L8B.PLC.CVPortChange(SelectPort, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.OK)
    End Sub

    Private Sub GrayToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrayToolStripMenuItem1.Click
        _L8B.PLC.CVPortChange(SelectPort, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.GRAY)
    End Sub

    Private Sub NGToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NGToolStripMenuItem1.Click
        _L8B.PLC.CVPortChange(SelectPort, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.NG)
    End Sub

    Private Sub MIXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIXToolStripMenuItem.Click
        _L8B.PLC.CVPortChange(SelectPort, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.MIX)
    End Sub

    Private Sub MIXNGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIXNGToolStripMenuItem.Click
        _L8B.PLC.CVPortChange(SelectPort, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.MIXNG)
    End Sub

    Private Sub EnableToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableToolStripMenuItem1.Click
        _L8B.PLC.BufferSlotEnable(BufferSelect, BufferSlotSelect) = True
        RSTControl.CVGUIBufferEdit(BufferSelect).SlotDisableRemark(BufferSlotSelect) = ""
        _L8B.Setting.SaveDisableRemark(BufferSelect, BufferSlotSelect, "")
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub DisableToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableToolStripMenuItem1.Click
        Dim InputText As String = InputBox("Please Input The reason of disable Buffer Slot on Buffer=" & BufferSelect & " / Slot=" & BufferSlotSelect & ".", "Input Slot Disable Remark", "")
        _L8B.Setting.SaveDisableRemark(BufferSelect, BufferSlotSelect, InputText)
        RSTControl.CVGUIBuffer(BufferSelect).SlotDisableRemark(BufferSlotSelect) = InputText
        RSTControl.CVGUIBufferEdit(BufferSelect).SlotDisableRemark(BufferSlotSelect) = InputText
        RSTControl.CVGUIBufferDialog(BufferSelect).SlotDisableRemark(BufferSlotSelect) = InputText
        _L8B.PLC.BufferSlotEnable(BufferSelect, BufferSlotSelect) = False

        If DebugMode() Then
            RSTControl.CVGUIBuffer(BufferSelect).SlotEnabled(BufferSlotSelect) = False
            RSTControl.CVGUIBufferEdit(BufferSelect).SlotEnabled(BufferSlotSelect) = False
            RSTControl.CVGUIBufferDialog(BufferSelect).SlotEnabled(BufferSlotSelect) = False
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub EQ1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ1ToolStripMenuItem.Click
        _L8B.PLC.EQSignalReset(1)
    End Sub

    Private Sub EQ2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ2ToolStripMenuItem.Click
        _L8B.PLC.EQSignalReset(2)
    End Sub

    Private Sub EQ3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ3ToolStripMenuItem.Click
        _L8B.PLC.EQSignalReset(3)
    End Sub

    Private Sub CVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CVToolStripMenuItem.Click
        _L8B.PLC.CVSignalReset()
    End Sub

    Private Sub Port1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Port1ToolStripMenuItem.Click
        _L8B.PLC.BufferSlotDestination(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eNGGXToMachine.IDX_CV_PORT1
        UpdateBufferSlotDest(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.PORT1)
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub Port2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Port2ToolStripMenuItem.Click
        _L8B.PLC.BufferSlotDestination(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eNGGXToMachine.IDX_CV_PORT2
        UpdateBufferSlotDest(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.PORT2)
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub Port3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Port3ToolStripMenuItem.Click
        _L8B.PLC.BufferSlotDestination(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eNGGXToMachine.IDX_CV_PORT3
        UpdateBufferSlotDest(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.PORT3)
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub EQ1ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ1ToolStripMenuItem1.Click
        _L8B.PLC.BufferSlotDestination(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eNGGXToMachine.IDX_EQ1
        UpdateBufferSlotDest(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.EQ1)
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub EQ2ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ2ToolStripMenuItem1.Click
        _L8B.PLC.BufferSlotDestination(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eNGGXToMachine.IDX_EQ2
        UpdateBufferSlotDest(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.EQ2)
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub EQ3ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EQ3ToolStripMenuItem1.Click
        _L8B.PLC.BufferSlotDestination(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eNGGXToMachine.IDX_EQ3
        UpdateBufferSlotDest(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.EQ3)
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub ButtonResetSignal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResetSignal.Click
        ContextMenuStripResetSignal.Show()
        ContextMenuStripResetSignal.Left = ButtonResetSignal.Left + Me.Left
        ContextMenuStripResetSignal.Top = ButtonResetSignal.Top + Me.Top
    End Sub

    Private Sub ButtonUMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUMode.Click
        If CheckBufferGlassWorking() Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Glass inside buffer, please remove it(them) and try again.", MsgBoxStyle.OkOnly, 20, MsgBoxResult.Ok)
        ElseIf _L8B.Setting.Main.GlassFlowMode <> prjSECS.clsEnumCtl.ePortType.TYPE_U Then
            UIModeSave(prjSECS.clsEnumCtl.ePortType.TYPE_U)
            ResetSlotsMode(eRunningMode.THROUGH)
            UpdateBufferSlotType()
        End If
    End Sub

    Private Sub ButtonIMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonIMode.Click
        If CheckBufferGlassWorking() Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Glass inside buffer, please remove it(them) and try again.", MsgBoxStyle.OkOnly, 20, MsgBoxResult.Ok)
        ElseIf _L8B.Setting.Main.GlassFlowMode <> prjSECS.clsEnumCtl.ePortType.TYPE_I Then
            UIModeSave(prjSECS.clsEnumCtl.ePortType.TYPE_I)
            ResetSlotsMode(eRunningMode.MQC)
            UpdateBufferSlotType()
        End If
    End Sub

    Private Sub ButtonMixRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMixRepair.Click
        If _L8B.PLC.CassetteInPort Then
            Exit Sub
        End If
        RepairModeSave(L8BIFPRJ.clsPLC.eColorRepairMode.COLOR_MODE)
        ResetSlotsMode(eRunningMode.TAPEINK)
        UpdateBufferSlotType()
    End Sub

    Private Sub ButtonNormalTapeRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNormalTapeRepair.Click
        If _L8B.PLC.CassetteInPort Then
            Exit Sub
        End If
        RepairModeSave(L8BIFPRJ.clsPLC.eColorRepairMode.NORMAL_MODE)
        ResetSlotsMode(eRunningMode.TAPE)
        UpdateBufferSlotType()
    End Sub

    Private Sub ResetSlotsMode(ByVal eMode As eRunningMode)
        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
            For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                If Not mInfo.Buffer(i).fGlassExist(j) Then
                    _L8B.PLC.SetBufferType(i, j, _L8B.Setting.Main.BufferSlotType(eMode)(i)(j))
                Else
                    WriteLog("Buffer=" & i & " Slot=" & j & " Glass exists; can't change buffet type")
                End If

            Next
        Next
    End Sub


    '20090430
    Public Function CheckBufferGlassWorking() As Boolean
        'For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
        '    For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
        '        If mInfo.Buffer(i).fGlassExist(j) Then
        '            If _L8B.PLC.BufferSlotEnable(i, j) Then

        '                Select Case mInfo.Buffer(i).BufferSlotType(j)
        '                    Case L8BIFPRJ.clsPLC.eBufferStatus.GRAY, L8BIFPRJ.clsPLC.eBufferStatus.LD, L8BIFPRJ.clsPLC.eBufferStatus.NG, L8BIFPRJ.clsPLC.eBufferStatus.OK & _
        '                         L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE1, L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE2, L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE3

        '                        Return True
        '                End Select

        '            End If    'slot enable
        '        End If    'glass exist
        '    Next    'for each slots
        '        Next    'for each buffers

        Return False
    End Function



    Private Sub ButtonPassReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPassReset.Click
        'WriteLog("User[" & _L8B.User.Name & "] reset pass glass[" & mMain.Setting.Main.Pass & "] to [0]", LogMessageType.Info)
        _L8B.Setting.Main.Pass = 0
        UpdatePassGlass(0)
    End Sub

    Private Sub ButtonInitial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInitial.Click
        If mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.AUTO Then
            ShowMessage(DialogMessage.MESSAGE.InitialLoader, DialogMessage.MESSAGELEVEL.Info, "Robto cannot initial in [AUTO] Mode", MsgBoxStyle.OkOnly, 20, MsgBoxResult.Ok)
            Exit Sub
        End If
        ButtonInitial.Enabled = False
        ButtonInitial.BackColor = Color.Transparent
        _L8B.Log.Hide()
        If MsgBox("Initial Robot?", MsgBoxStyle.YesNo, " Robot Initail after Robot Down.") = MsgBoxResult.Yes Then
            _L8B.PLC.AlarmReset()
            _L8B.PLC.RobotInitial()
        Else
            ButtonInitial.Enabled = True
            ButtonInitial.BackColor = Color.LightCoral
        End If
        _L8B.fBypassInterfaceCheck = False
    End Sub

    Private Sub ButtonAutoManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAutoManual.Click
        ButtonAutoManual.Enabled = False
        _L8B.Log.Hide()
        If mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.AUTO Then
            'If ButtonInitial.Enabled Then
            '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Can't switch to [AUTO] mode, please [INITIAL] robot first.", MsgBoxStyle.OkOnly, 5, MsgBoxResult.Ok)
            'Else
            If MsgBox("change Robot to [MANUAL] Mode?", MsgBoxStyle.YesNo, "Robot Running Mode Change") = MsgBoxResult.Yes Then
                'If Not TabControlMain.Controls.Contains(TabPageManual) Then
                '    TabControlMain.Controls.Add(TabPageManual)
                'End If
                _L8B.PLC.SetRobotMode(L8BIFPRJ.clsPLC.eRSTMode.MANUAL)
            End If
            'End If
        ElseIf mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.MANUAL Then
            If MsgBox("change Robot to [AUTO] Mode?", MsgBoxStyle.YesNo, "Robot Running Mode Change") = MsgBoxResult.Yes Then
                'If TabControlMain.Controls.Contains(TabPageManual) Then
                '    TabControlMain.Controls.Remove(TabPageManual)
                'End If
                _L8B.PLC.SetRobotMode(L8BIFPRJ.clsPLC.eRSTMode.AUTO)
            End If
        End If

        '2010/06/01 for interupt the PM test
        mInfo.PM.Continued = False

        ButtonAutoManual.Enabled = True
    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        'ButtonStart.Enabled = False
        _L8B.Log.Hide()
        Select Case mInfo.Robot.Status
            Case L8BIFPRJ.clsPLC.eRSTStatus.STOPPED
                If MsgBox("Start Robot?", MsgBoxStyle.YesNo, "Start Robot") = MsgBoxResult.Yes Then
                    _L8B.PLC.RobotStart()
                    '2010/06/01 for interupt the PM test
                    mInfo.PM.Continued = False
                Else
                    ButtonStart.Enabled = True
                End If
            Case Else
                If MsgBox("Stop Robot?", MsgBoxStyle.YesNo, "Stop Robot") = MsgBoxResult.Yes Then
                    _L8B.PLC.RobotStop()
                Else
                    ButtonStart.Enabled = True
                End If
        End Select
    End Sub

    Private Sub ButtonHostMessageHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHostMessageHistory.Click
        _L8B.dlgHostMessageHistory.ShowMe()

    End Sub

    Private Sub ButtonClearListBoxMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearListBoxMessage.Click
        ListViewHostMessage.Clear()
        _L8B.db.UpdateHostMessageHistoryDelete()
    End Sub

    Private Sub ButtonSentHostMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSentHostMessage.Click
        If _L8B.CIM.TCPIPConnect Then
            If _L8B.CIM.RemoteMode <> prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                If TextBoxSendHostMessage.Text.Trim.Length > 0 Then
                    _L8B.CIM.SendHostMessage(TextBoxSendHostMessage.Text)
                    _L8B.db.InsertHostMessageHistory("TX", TextBoxSendHostMessage.Text)
                    TextBoxSendHostMessage.Clear()
                    UpdateListViewHostMessage()
                End If
            Else
                WriteLog("SentHostMessage fail RemoteStatus=Offline", LogMessageType.ERR)
            End If
        Else
            WriteLog("SentHostMessage fail CIM Host is not connect", LogMessageType.ERR)
        End If
    End Sub


    Private Sub LabelRemodeMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelRemodeMode.Click
        '_L8B.dlgSECSRemoteMode.Show()
    End Sub

    Private Sub ButtonStartPMTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStartPMTest.Click
        If _L8B.PLC.RSTCommandAccept Then
            If mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.ENGINEER Or mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.MANUAL Then
                WriteLog("Strat PM Test for " & mInfo.PM.RunCount & " cycles", LogMessageType.Info)
                GroupBoxMRobot.Enabled = False
                ButtonStopPMTest.Enabled = True
                ButtonStartPMTest.Enabled = False
                With mInfo.PM
                    .RunCount = NumericUpDownPM.Value
                    .Continued = True
                    .Count = 0
                    .pFrom = 0
                    .pTo = 1
                    PMTestRobotCommand(.pTo)
                End With
            Else
                PMTestStop()
            End If
        End If
    End Sub

    Private Sub TimerUpdateRobotMileage_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerUpdateRobotMileage.Tick
        If _L8B.PLC.bTCPIPConnectFirstTime Then
            _L8B.PLC.Mileage = _L8B.PLC.GetRobotAxisMileage()

            For i As Integer = 1 To 6
                RSTControl.AxisMileage(i).Text = _L8B.PLC.Mileage(i).ToString
            Next
        End If
    End Sub

    Private Sub guiCtrlSlots1_SlotDestMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots1.SlotDestMouseUP
        'If Not _L8B.User.Right(Ini.enumUserRight.BufferDest) Then
        '    Debug.WriteLine("[no right]RstguiCtrlSlots21_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'End If
        If Not _L8B.PLC.BufferSlotEnable(1, nSlot) Then
            WriteLog("buffer 1 Slot=" & nSlot & " is disable; can't set slot dest")
            Return
        End If
        If mInfo.Buffer(1).fGlassExist(nSlot) Then
            Debug.WriteLine("RstguiCtrlSlots21_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
            BufferSelect = 1
            BufferSlotSelect = nSlot
            Dim Point As System.Drawing.Point
            Point.X = guiCtrlSlots1.Left + X
            Point.Y = Y
            ContextMenuStripBufferSlotTarget.Show(Me, Point)
            SelectToolStripMenuItem.Text = "Dest Buffer#1, Slot#" & nSlot
        Else
            Debug.WriteLine("[fail/no glass]guiCtrlSlots1_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        End If
    End Sub

    Private Sub guiCtrlSlots1_SlotLBLMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots1.SlotLBLMouseUP
        'If Not mMain.User.Right(Ini.enumUserRight.BufferType) Then
        '    Debug.WriteLine("[no right as BufferType]RstguiCtrlSlots21_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'End If
        Debug.WriteLine("guiCtrlSlots1_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 1
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = guiCtrlSlots1.Left + X + TabControlMain.Left
        Point.Y = Y + guiCtrlSlots1.Top + TabControlMain.Top
        If _L8B.PLC.BufferSlotEnable(1, nSlot) Then
            If mInfo.Buffer(1).fGlassExist(nSlot) AndAlso _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                'ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Disable Buffer Slot will cause process stop!!", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True)
                EnableToolStripMenuItem1.Enabled = False
                DisableToolStripMenuItem1.Enabled = False
            Else
                EnableToolStripMenuItem1.Enabled = False
                DisableToolStripMenuItem1.Enabled = True
            End If
        Else
            EnableToolStripMenuItem1.Enabled = True
            DisableToolStripMenuItem1.Enabled = False
        End If
        ContextMenuStripBufferSlotEnable.Show(Me, Point)
        SelectToolStripMenuItemBufferEnable.Text = "Buffer#1 Slot#" & nSlot
    End Sub

    Private Sub guiCtrlSlots1_SlotMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots1.SlotMouseUP
        'If Not _L8B.Setting.User.Right(Ini.enumUserRight.BufferType) Then
        '    Debug.WriteLine("[no right]RstguiCtrlSlots21_SlotMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'Else
        If mInfo.Buffer(1).fGlassExist(nSlot) Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Glass exist; can't change buffer type", MsgBoxStyle.OkOnly, 30, MsgBoxResult.Ok)
            Exit Sub
        End If
        Debug.WriteLine("guiCtrlSlots11_SlotMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 1
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = guiCtrlSlots1.Left + X
        Point.Y = Y
        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.FI
                InkToolStripMenuItem.Visible = False
                If _L8B.Setting.Main.NumberBuffer = 1 Then
                    OKToolStripMenuItem.Visible = False
                    NGToolStripMenuItem.Visible = False
                    GrayToolStripMenuItem.Visible = False
                    LDToolStripMenuItem.Visible = False
                    CASSETTE1ToolStripMenuItem.Visible = True
                    CASSETTE2ToolStripMenuItem.Visible = True
                    If _L8B.Setting.Main.NumberBuffer >= 3 Then
                        CASSETTE3ToolStripMenuItem.Visible = True
                    Else
                        CASSETTE3ToolStripMenuItem.Visible = False
                    End If
                    EQ1StandardGlassToolStripMenuItem.Visible = True
                    EQ2StandardGlassToolStripMenuItem.Visible = False
                Else
                    If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                        OKToolStripMenuItem.Visible = True
                        NGToolStripMenuItem.Visible = True
                        GrayToolStripMenuItem.Visible = True
                        LDToolStripMenuItem.Visible = True
                        CASSETTE1ToolStripMenuItem.Visible = False
                        CASSETTE2ToolStripMenuItem.Visible = False
                        CASSETTE3ToolStripMenuItem.Visible = False
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    Else
                        OKToolStripMenuItem.Visible = False
                        NGToolStripMenuItem.Visible = False
                        GrayToolStripMenuItem.Visible = False
                        LDToolStripMenuItem.Visible = False
                        CASSETTE1ToolStripMenuItem.Visible = True
                        CASSETTE2ToolStripMenuItem.Visible = True
                        CASSETTE3ToolStripMenuItem.Visible = True
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    End If
                End If
            Case ClsSetting.EMACHINETYPE.ButterFly
                OKToolStripMenuItem.Visible = False
                NGToolStripMenuItem.Visible = False
                GrayToolStripMenuItem.Visible = False
                LDToolStripMenuItem.Visible = False
                InkToolStripMenuItem.Visible = False
                CASSETTE1ToolStripMenuItem.Visible = True
                CASSETTE2ToolStripMenuItem.Visible = True
                If _L8B.Setting.Main.NumberBuffer >= 3 Then
                    CASSETTE3ToolStripMenuItem.Visible = True
                Else
                    CASSETTE3ToolStripMenuItem.Visible = False
                End If
                EQ1StandardGlassToolStripMenuItem.Visible = True
                EQ2StandardGlassToolStripMenuItem.Visible = True
            Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR
                If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.COLORREPAIR Then
                    InkToolStripMenuItem.Visible = True
                End If
                OKToolStripMenuItem.Visible = True
                NGToolStripMenuItem.Visible = True
                GrayToolStripMenuItem.Visible = True
                LDToolStripMenuItem.Visible = True
                CASSETTE1ToolStripMenuItem.Visible = False
                CASSETTE2ToolStripMenuItem.Visible = False
                CASSETTE3ToolStripMenuItem.Visible = False
                EQ1StandardGlassToolStripMenuItem.Visible = False
                EQ2StandardGlassToolStripMenuItem.Visible = False
            Case Else
                OKToolStripMenuItem.Visible = True
                NGToolStripMenuItem.Visible = True
                GrayToolStripMenuItem.Visible = True
                LDToolStripMenuItem.Visible = True
                InkToolStripMenuItem.Visible = False
                CASSETTE1ToolStripMenuItem.Visible = True
                CASSETTE2ToolStripMenuItem.Visible = True
                CASSETTE3ToolStripMenuItem.Visible = True
                EQ1StandardGlassToolStripMenuItem.Visible = True
                EQ2StandardGlassToolStripMenuItem.Visible = True
        End Select
        ContextMenuStripBufferSlotType.Show(Me, Point)
        BufferSlotToolStripMenuItem.Text = "Buffer#1,  Slot#" & nSlot & "  (Type)"
    End Sub

    Private Sub guiCtrlSlots2_SlotDestMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots2.SlotDestMouseUP
        'If Not mMain.User.Right(Ini.enumUserRight.BufferDest) Then
        '    Debug.WriteLine("[no right]RstguiCtrlSlots22_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'End If
        If Not _L8B.PLC.BufferSlotEnable(2, nSlot) Then
            WriteLog("buffer 2 Slot=" & nSlot & " is disable; can't set slot dest")
            Return
        End If
        If mInfo.Buffer(2).fGlassExist(nSlot) Then
            Debug.WriteLine("guiCtrlSlots2_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
            BufferSelect = 2
            BufferSlotSelect = nSlot
            Dim Point As System.Drawing.Point
            Point.X = guiCtrlSlots2.Left + X
            Point.Y = Y
            ContextMenuStripBufferSlotTarget.Show(Me, Point)
            SelectToolStripMenuItem.Text = "Dest Buffer#2, Slot#" & nSlot
        Else
            Debug.WriteLine("[fail/no glass]guiCtrlSlots2_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        End If
    End Sub

    Private Sub guiCtrlSlots2_SlotLBLMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots2.SlotLBLMouseUP
        'If Not mMain.User.Right(Ini.enumUserRight.BufferType) Then
        '    Debug.WriteLine("[no right as BufferType]RstguiCtrlSlots22_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'End If
        Debug.WriteLine("guiCtrlSlots2_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 2
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = guiCtrlSlots2.Left + X
        Point.Y = Y
        If _L8B.PLC.BufferSlotEnable(2, nSlot) Then
            If mInfo.Buffer(2).fGlassExist(nSlot) AndAlso _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                'ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Disable Buffer Slot will cause process stop!!", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True)
                EnableToolStripMenuItem1.Enabled = False
                DisableToolStripMenuItem1.Enabled = False
            Else
                EnableToolStripMenuItem1.Enabled = False
                DisableToolStripMenuItem1.Enabled = True
            End If
        Else
            EnableToolStripMenuItem1.Enabled = True
            DisableToolStripMenuItem1.Enabled = False
        End If

        ContextMenuStripBufferSlotEnable.Show(Me, Point)
        SelectToolStripMenuItemBufferEnable.Text = "Buffer#2 Slot#" & nSlot
    End Sub

    Private Sub guiCtrlSlots2_SlotMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots2.SlotMouseUP
        'If Not _L8B.User.Right(Ini.enumUserRight.BufferType) Then
        '    Debug.WriteLine("[no right]RstguiCtrlSlots21_SlotMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'Else
        If mInfo.Buffer(2).fGlassExist(nSlot) Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Glass exist; can't change buffer type", MsgBoxStyle.OkOnly, 30, MsgBoxResult.Ok)
            Exit Sub
        End If
        Debug.WriteLine("guiCtrlSlots2_SlotMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 2
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = guiCtrlSlots2.Left + X
        Point.Y = Y
        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.FI
                If _L8B.Setting.Main.NumberBuffer = 1 Then
                    OKToolStripMenuItem.Visible = False
                    NGToolStripMenuItem.Visible = False
                    GrayToolStripMenuItem.Visible = False
                    LDToolStripMenuItem.Visible = False
                    CASSETTE1ToolStripMenuItem.Visible = True
                    CASSETTE2ToolStripMenuItem.Visible = True
                    If _L8B.Setting.Main.NumberBuffer >= 3 Then
                        CASSETTE3ToolStripMenuItem.Visible = True
                    Else
                        CASSETTE3ToolStripMenuItem.Visible = False
                    End If
                    EQ1StandardGlassToolStripMenuItem.Visible = True
                    EQ2StandardGlassToolStripMenuItem.Visible = False
                Else
                    If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                        OKToolStripMenuItem.Visible = True
                        NGToolStripMenuItem.Visible = True
                        GrayToolStripMenuItem.Visible = True
                        LDToolStripMenuItem.Visible = True
                        CASSETTE1ToolStripMenuItem.Visible = False
                        CASSETTE2ToolStripMenuItem.Visible = False
                        CASSETTE3ToolStripMenuItem.Visible = False
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    Else
                        OKToolStripMenuItem.Visible = False
                        NGToolStripMenuItem.Visible = False
                        GrayToolStripMenuItem.Visible = False
                        LDToolStripMenuItem.Visible = False
                        CASSETTE1ToolStripMenuItem.Visible = True
                        CASSETTE2ToolStripMenuItem.Visible = True
                        CASSETTE3ToolStripMenuItem.Visible = True
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    End If
                End If
            Case ClsSetting.EMACHINETYPE.ButterFly
                OKToolStripMenuItem.Visible = False
                NGToolStripMenuItem.Visible = False
                GrayToolStripMenuItem.Visible = False
                LDToolStripMenuItem.Visible = False
                CASSETTE1ToolStripMenuItem.Visible = True
                CASSETTE2ToolStripMenuItem.Visible = True
                If _L8B.Setting.Main.NumberBuffer >= 3 Then
                    CASSETTE3ToolStripMenuItem.Visible = True
                Else
                    CASSETTE3ToolStripMenuItem.Visible = False
                End If
                EQ1StandardGlassToolStripMenuItem.Visible = True
                EQ2StandardGlassToolStripMenuItem.Visible = True
            Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR
                OKToolStripMenuItem.Visible = True
                NGToolStripMenuItem.Visible = True
                GrayToolStripMenuItem.Visible = True
                LDToolStripMenuItem.Visible = True
                CASSETTE1ToolStripMenuItem.Visible = False
                CASSETTE2ToolStripMenuItem.Visible = False
                CASSETTE3ToolStripMenuItem.Visible = False
                EQ1StandardGlassToolStripMenuItem.Visible = False
                EQ2StandardGlassToolStripMenuItem.Visible = False
            Case Else
                OKToolStripMenuItem.Visible = True
                NGToolStripMenuItem.Visible = True
                GrayToolStripMenuItem.Visible = True
                LDToolStripMenuItem.Visible = True
                CASSETTE1ToolStripMenuItem.Visible = True
                CASSETTE2ToolStripMenuItem.Visible = True
                CASSETTE3ToolStripMenuItem.Visible = True
                EQ1StandardGlassToolStripMenuItem.Visible = True
                EQ2StandardGlassToolStripMenuItem.Visible = True
        End Select
        ContextMenuStripBufferSlotType.Show(Me, Point)
        BufferSlotToolStripMenuItem.Text = "Buffer#2,  Slot#" & nSlot & "  (Type)"
    End Sub


    Private Sub guiCtrlSlots3_SlotDestMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots3.SlotDestMouseUP
        'If Not mMain.User.Right(Ini.enumUserRight.BufferDest) Then
        '    Debug.WriteLine("[no right]RstguiCtrlSlots23_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'End If
        If Not _L8B.PLC.BufferSlotEnable(3, nSlot) Then
            WriteLog("buffer 3 Slot=" & nSlot & " is disable; can't set slot dest")
            Return
        End If
        If mInfo.Buffer(3).fGlassExist(nSlot) Then
            Debug.WriteLine("RstguiCtrlSlots23_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
            BufferSelect = 3
            BufferSlotSelect = nSlot
            Dim Point As System.Drawing.Point
            Point.X = guiCtrlSlots3.Left + X
            Point.Y = Y
            ContextMenuStripBufferSlotTarget.Show(Me, Point)
            SelectToolStripMenuItem.Text = "Dest Buffer#3, Slot#" & nSlot
        Else
            Debug.WriteLine("[fail/no glass]guiCtrlSlots3_SlotDestMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        End If
    End Sub

    Private Sub guiCtrlSlots3_SlotLBLMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots3.SlotLBLMouseUP
        'If Not mMain.User.Right(Ini.enumUserRight.BufferType) Then
        '    Debug.WriteLine("[no right as BufferType]RstguiCtrlSlots23_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'End If
        Debug.WriteLine("guiCtrlSlots3_SlotLBLMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 3
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = guiCtrlSlots3.Left + X
        Point.Y = Y

        If _L8B.PLC.BufferSlotEnable(3, nSlot) Then
            If mInfo.Buffer(3).fGlassExist(nSlot) AndAlso _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                'ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Disable Buffer Slot will cause process stop!!", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True)
                EnableToolStripMenuItem1.Enabled = False
                DisableToolStripMenuItem1.Enabled = False
            Else
                EnableToolStripMenuItem1.Enabled = False
                DisableToolStripMenuItem1.Enabled = True
            End If
        Else
            EnableToolStripMenuItem1.Enabled = True
            DisableToolStripMenuItem1.Enabled = False
        End If
        ContextMenuStripBufferSlotEnable.Show(Me, Point)
        SelectToolStripMenuItemBufferEnable.Text = "Buffer#3 Slot#" & nSlot
    End Sub

    Private Sub guiCtrlSlots3_SlotMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots3.SlotMouseUP
        'If Not _L8B.User.Right(Ini.enumUserRight.BufferType) Then
        '    Debug.WriteLine("[no right]RstguiCtrlSlots21_SlotMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        '    Exit Sub
        'Else
        If mInfo.Buffer(3).fGlassExist(nSlot) Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Glass exist; can't change buffer type", MsgBoxStyle.OkOnly, 30, MsgBoxResult.Ok)
            Exit Sub
        End If
        Debug.WriteLine("guiCtrlSlots3_SlotMouseUP at slot=" & nSlot & " X=" & X & " Y=" & Y)
        BufferSelect = 3
        BufferSlotSelect = nSlot
        Dim Point As System.Drawing.Point
        Point.X = guiCtrlSlots3.Left + X
        Point.Y = Y
        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.FI
                If _L8B.Setting.Main.NumberBuffer = 1 Then
                    OKToolStripMenuItem.Visible = False
                    NGToolStripMenuItem.Visible = False
                    GrayToolStripMenuItem.Visible = False
                    LDToolStripMenuItem.Visible = False
                    CASSETTE1ToolStripMenuItem.Visible = True
                    CASSETTE2ToolStripMenuItem.Visible = True
                    If _L8B.Setting.Main.NumberBuffer >= 3 Then
                        CASSETTE3ToolStripMenuItem.Visible = True
                    Else
                        CASSETTE3ToolStripMenuItem.Visible = False
                    End If
                    EQ1StandardGlassToolStripMenuItem.Visible = True
                    EQ2StandardGlassToolStripMenuItem.Visible = False
                Else
                    If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                        OKToolStripMenuItem.Visible = True
                        NGToolStripMenuItem.Visible = True
                        GrayToolStripMenuItem.Visible = True
                        LDToolStripMenuItem.Visible = True
                        CASSETTE1ToolStripMenuItem.Visible = False
                        CASSETTE2ToolStripMenuItem.Visible = False
                        CASSETTE3ToolStripMenuItem.Visible = False
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    Else
                        OKToolStripMenuItem.Visible = False
                        NGToolStripMenuItem.Visible = False
                        GrayToolStripMenuItem.Visible = False
                        LDToolStripMenuItem.Visible = False
                        CASSETTE1ToolStripMenuItem.Visible = True
                        CASSETTE2ToolStripMenuItem.Visible = True
                        CASSETTE3ToolStripMenuItem.Visible = True
                        EQ1StandardGlassToolStripMenuItem.Visible = True
                        EQ2StandardGlassToolStripMenuItem.Visible = True
                    End If
                End If
            Case ClsSetting.EMACHINETYPE.ButterFly
                OKToolStripMenuItem.Visible = False
                NGToolStripMenuItem.Visible = False
                GrayToolStripMenuItem.Visible = False
                LDToolStripMenuItem.Visible = False
                CASSETTE1ToolStripMenuItem.Visible = True
                CASSETTE2ToolStripMenuItem.Visible = True
                If _L8B.Setting.Main.NumberBuffer >= 3 Then
                    CASSETTE3ToolStripMenuItem.Visible = True
                Else
                    CASSETTE3ToolStripMenuItem.Visible = False
                End If
                EQ1StandardGlassToolStripMenuItem.Visible = True
                EQ2StandardGlassToolStripMenuItem.Visible = True
            Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR
                OKToolStripMenuItem.Visible = True
                NGToolStripMenuItem.Visible = True
                GrayToolStripMenuItem.Visible = True
                LDToolStripMenuItem.Visible = True
                CASSETTE1ToolStripMenuItem.Visible = False
                CASSETTE2ToolStripMenuItem.Visible = False
                CASSETTE3ToolStripMenuItem.Visible = False
                EQ1StandardGlassToolStripMenuItem.Visible = False
                EQ2StandardGlassToolStripMenuItem.Visible = False
            Case Else
                OKToolStripMenuItem.Visible = True
                NGToolStripMenuItem.Visible = True
                GrayToolStripMenuItem.Visible = True
                LDToolStripMenuItem.Visible = True
                CASSETTE1ToolStripMenuItem.Visible = True
                CASSETTE2ToolStripMenuItem.Visible = True
                CASSETTE3ToolStripMenuItem.Visible = True
                EQ1StandardGlassToolStripMenuItem.Visible = True
                EQ2StandardGlassToolStripMenuItem.Visible = True
        End Select
        ContextMenuStripBufferSlotType.Show(Me, Point)
        BufferSlotToolStripMenuItem.Text = "Buffer#3,  Slot#" & nSlot & "  (Type)"
    End Sub

    Private Sub LDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LDToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.LD
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.LD Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.LD)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.LD.ToString), LogMessageType.SYS)

            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub InkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InkToolStripMenuItem.Click
        If BufferSelect > 0 And BufferSlotSelect > 0 Then
            _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.Ink
            If _L8B.PLC.BufferSlotType(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eBufferStatus.INK Then
                UpdateBufferSlotType(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.INK)
            Else
                WriteLog(String.Format("Set BufferSlotType Fail ({0},{1})->{2}", BufferSelect, BufferSlotSelect, L8BIFPRJ.clsPLC.eBufferStatus.INK.ToString), LogMessageType.SYS)
            End If
        End If
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub
    Dim OpenPort As Boolean
    Private Sub ButtonTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTest.Click
        'Select Case _L8B.Setting.Main.MachineType
        '    Case ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
        '        _L8B.dlgRecipeComfirm(1).ShowMe(1)
        '    Case Else
        '        _L8B.dlgRecipeComfirmWGS(1).ShowMe(1)
        'End Select
        '_L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.CV, 1, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR)
        '_L8B.PLC.Test()
        '_L8B.dlgCassetteInfo(1).ShowMe(_L8B.frmMain)
        'GUICVFlowUpdate()
        ' UpdateBufferSlotType(1, 1, RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.INK)
        'RSTControl.CVGUIBuffer(1).GxID(1) = "visit 1 EQ"
        'RSTControl.CVGUIBuffer(1).GxID(2) = "visit 2 EQ"
        'RSTControl.CVGUIBuffer(1).GxID(3) = "visit 3 EQ"
        'RSTControl.CVGUIBuffer(1).GxID(4) = "none"
        'RSTControl.CVGUIBuffer(1).Processed(1) = 1
        'RSTControl.CVGUIBuffer(1).Processed(2) = 2
        'RSTControl.CVGUIBuffer(1).Processed(3) = 3
        'RSTControl.CVGUIBuffer(1).Processed(4) = 0

        'If Not OpenPort Then
        '    OpenPort = True
        '    _L8B.CIM.L8BCIM.OpenPort()
        'Else
        '    'SetEQStatus(1, L8BIFPRJ.clsPLC.eEQStatus.IDLE)

        '    _L8B.CIM.UnitInfo(mInfo.Robot.UnitID).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING

        '    _L8B.CIM.UnitInfoChange(mInfo.Robot.UnitID)
        'End If

        RSTControl.CVGUIBufferEdit(1).GxID(3) = "KV5X020257" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(1).Processed(3) = 1
        RSTControl.CVGUIBufferEdit(1).EQDone(1, 3) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(2, 3) = False
        RSTControl.CVGUIBufferEdit(1).EQDone(3, 3) = False

        RSTControl.CVGUIBufferEdit(1).GxID(4) = "KV5X020258" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(1).Processed(4) = 2
        RSTControl.CVGUIBufferEdit(1).EQDone(1, 4) = False
        RSTControl.CVGUIBufferEdit(1).EQDone(2, 4) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(3, 4) = False

        RSTControl.CVGUIBufferEdit(1).GxID(5) = "KV5X020259" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(1).Processed(5) = 4
        RSTControl.CVGUIBufferEdit(1).EQDone(1, 5) = False
        RSTControl.CVGUIBufferEdit(1).EQDone(2, 5) = False
        RSTControl.CVGUIBufferEdit(1).EQDone(3, 5) = True

        RSTControl.CVGUIBufferEdit(1).GxID(6) = "KV5X020256" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(1).Processed(6) = 3
        RSTControl.CVGUIBufferEdit(1).EQDone(1, 6) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(2, 6) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(3, 6) = False

        RSTControl.CVGUIBufferEdit(1).GxID(7) = "KV5X020260" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(1).Processed(7) = 5
        RSTControl.CVGUIBufferEdit(1).EQDone(1, 7) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(2, 7) = False
        RSTControl.CVGUIBufferEdit(1).EQDone(3, 7) = True

        RSTControl.CVGUIBufferEdit(1).GxID(8) = "KV5X020261" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(1).Processed(8) = 6
        RSTControl.CVGUIBufferEdit(1).EQDone(1, 8) = False
        RSTControl.CVGUIBufferEdit(1).EQDone(2, 8) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(3, 8) = True

        RSTControl.CVGUIBufferEdit(1).GxID(9) = "KV5X020262" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(1).Processed(9) = 7
        RSTControl.CVGUIBufferEdit(1).EQDone(2, 9) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(3, 9) = True
        RSTControl.CVGUIBufferEdit(1).EQDone(1, 9) = True

        RSTControl.CVGUIBufferEdit(1).SlotDest(3) = RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.EQ1
        RSTControl.CVGUIBufferEdit(1).SlotType(3) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NG
        RSTControl.CVGUIBufferEdit(1).Reviewed(3) = True

        RSTControl.CVGUIBufferEdit(1).GxID(10) = "KV5X020280" & " - " & "V315XW06_VA2PS001" & " - 011"




        RSTControl.CVGUIBufferEdit(2).GxID(3) = "KV5X020257" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(2).Processed(3) = 1
        RSTControl.CVGUIBufferEdit(2).EQDone(1, 3) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(2, 3) = False
        RSTControl.CVGUIBufferEdit(2).EQDone(3, 3) = False

        RSTControl.CVGUIBufferEdit(2).GxID(4) = "KV5X020258" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(2).Processed(4) = 2
        RSTControl.CVGUIBufferEdit(2).EQDone(1, 4) = False
        RSTControl.CVGUIBufferEdit(2).EQDone(2, 4) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(3, 4) = False

        RSTControl.CVGUIBufferEdit(2).GxID(5) = "KV5X020259" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(2).Processed(5) = 4
        RSTControl.CVGUIBufferEdit(2).EQDone(1, 5) = False
        RSTControl.CVGUIBufferEdit(2).EQDone(2, 5) = False
        RSTControl.CVGUIBufferEdit(2).EQDone(3, 5) = True

        RSTControl.CVGUIBufferEdit(2).GxID(6) = "KV5X020256" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(2).Processed(6) = 3
        RSTControl.CVGUIBufferEdit(2).EQDone(1, 6) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(2, 6) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(3, 6) = False

        RSTControl.CVGUIBufferEdit(2).GxID(7) = "KV5X020260" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(2).Processed(7) = 5
        RSTControl.CVGUIBufferEdit(2).EQDone(1, 7) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(2, 7) = False
        RSTControl.CVGUIBufferEdit(2).EQDone(3, 7) = True

        RSTControl.CVGUIBufferEdit(2).GxID(8) = "KV5X020261" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(2).Processed(8) = 6
        RSTControl.CVGUIBufferEdit(2).EQDone(1, 8) = False
        RSTControl.CVGUIBufferEdit(2).EQDone(2, 8) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(3, 8) = True

        RSTControl.CVGUIBufferEdit(2).GxID(9) = "KV5X020262" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(2).Processed(9) = 7
        RSTControl.CVGUIBufferEdit(2).EQDone(2, 9) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(3, 9) = True
        RSTControl.CVGUIBufferEdit(2).EQDone(1, 9) = True

        RSTControl.CVGUIBufferEdit(2).SlotDest(3) = RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.EQ1
        RSTControl.CVGUIBufferEdit(2).SlotType(3) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NG
        RSTControl.CVGUIBufferEdit(2).Reviewed(3) = True

        RSTControl.CVGUIBufferEdit(2).GxID(10) = "KV5X020280" & " - " & "V315XW06_VA2PS001" & " - 011"





        RSTControl.CVGUIBufferEdit(3).GxID(3) = "KV5X020257" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(3).Processed(3) = 1
        RSTControl.CVGUIBufferEdit(3).EQDone(1, 3) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(2, 3) = False
        RSTControl.CVGUIBufferEdit(3).EQDone(3, 3) = False

        RSTControl.CVGUIBufferEdit(3).GxID(4) = "KV5X020258" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(3).Processed(4) = 2
        RSTControl.CVGUIBufferEdit(3).EQDone(1, 4) = False
        RSTControl.CVGUIBufferEdit(3).EQDone(2, 4) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(3, 4) = False

        RSTControl.CVGUIBufferEdit(3).GxID(5) = "KV5X020259" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(3).Processed(5) = 4
        RSTControl.CVGUIBufferEdit(3).EQDone(1, 5) = False
        RSTControl.CVGUIBufferEdit(3).EQDone(2, 5) = False
        RSTControl.CVGUIBufferEdit(3).EQDone(3, 5) = True

        RSTControl.CVGUIBufferEdit(3).GxID(6) = "KV5X020256" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(3).Processed(6) = 3
        RSTControl.CVGUIBufferEdit(3).EQDone(1, 6) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(2, 6) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(3, 6) = False

        RSTControl.CVGUIBufferEdit(3).GxID(7) = "KV5X020260" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(3).Processed(7) = 5
        RSTControl.CVGUIBufferEdit(3).EQDone(1, 7) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(2, 7) = False
        RSTControl.CVGUIBufferEdit(3).EQDone(3, 7) = True

        RSTControl.CVGUIBufferEdit(3).GxID(8) = "KV5X020261" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(3).Processed(8) = 6
        RSTControl.CVGUIBufferEdit(3).EQDone(1, 8) = False
        RSTControl.CVGUIBufferEdit(3).EQDone(2, 8) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(3, 8) = True

        RSTControl.CVGUIBufferEdit(3).GxID(9) = "KV5X020262" & " - " & "V315XW06_VA2PS001" & " - 011"
        RSTControl.CVGUIBufferEdit(3).Processed(9) = 7
        RSTControl.CVGUIBufferEdit(3).EQDone(2, 9) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(3, 9) = True
        RSTControl.CVGUIBufferEdit(3).EQDone(1, 9) = True

        RSTControl.CVGUIBufferEdit(3).SlotDest(3) = RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.EQ1
        RSTControl.CVGUIBufferEdit(3).SlotType(3) = RSTShapFlowGUI.RSTGUICtrlSlots.eSlotType.NG
        RSTControl.CVGUIBufferEdit(3).Reviewed(3) = True

        RSTControl.CVGUIBufferEdit(3).GxID(10) = "KV5X020280" & " - " & "V315XW06_VA2PS001" & " - 011"

        _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.CV, 4, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR)
        _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.Robot, 24, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR)

    End Sub

    Public Sub UpdatColorRepairMode()
        Select Case _L8B.Setting.Main.ColorRepairMode
            Case L8BIFPRJ.clsPLC.eColorRepairMode.COLOR_MODE
                ButtonNormalTapeRepair.ForeColor = Color.LightGray
                ButtonNormalTapeRepair.BackColor = Color.Transparent
                ButtonMixRepair.ForeColor = Color.Black
                ButtonMixRepair.BackColor = Color.LightGreen
            Case L8BIFPRJ.clsPLC.eColorRepairMode.NORMAL_MODE
                ButtonNormalTapeRepair.ForeColor = Color.Black
                ButtonNormalTapeRepair.BackColor = Color.LightGreen
                ButtonMixRepair.ForeColor = Color.LightGray
                ButtonMixRepair.BackColor = Color.Transparent
        End Select
    End Sub

    Private Sub TimerFormHandle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFormHandle.Tick
        SyncLock _L8B.frmShowQueue
            While _L8B.frmShowQueue.Count > 0
                Try
                    Dim frm = _L8B.frmShowQueue.Dequeue
                    If frm IsNot Nothing Then
                        frm.show()
                        frm.TopMost = True
                    End If
                Catch ex As Exception
                    WriteLog(ex.ToString)
                End Try
            End While
        End SyncLock


        SyncLock _L8B.frmHideQueue
            While _L8B.frmHideQueue.Count > 0
                Try
                    Dim frm = _L8B.frmHideQueue.Dequeue
                    If frm IsNot Nothing Then
                        frm.hide()
                    End If
                Catch ex As Exception
                    WriteLog(ex.ToString)
                End Try
            End While
        End SyncLock

        SyncLock _L8B.frmCloseQueue
            While _L8B.frmCloseQueue.Count > 0
                Try
                    Dim frm = _L8B.frmCloseQueue.Dequeue
                    If frm IsNot Nothing Then
                        frm.Close()
                    End If
                Catch ex As Exception
                    WriteLog(ex.ToString)
                End Try
            End While
        End SyncLock

    End Sub

    Public Sub UpdateDataGridViewAlarm()
        DataGridViewAlarm.DataSource = _L8B.db.QueryAlarm(DateTimePickerAlarmHistory.Value) '.AddHours(-8))
    End Sub

    Public Sub UpdateListViewAlarm()
        With ListViewAlarmView
            .Clear()
            If _L8B.Alarm.AlarmList.Count = 0 Then
                Exit Sub
            End If
            '.Height = 290
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            .MultiSelect = False
            .Columns.Add("Code", 50)
            .Columns.Add("Type", 60)
            .Columns.Add("Src", 70)
            .Columns.Add("OTime", 155)
            .Columns.Add("RTime", 155)
            .Columns.Add("Message", 500)
            .Columns.Add("Remark", 500)
            .BeginUpdate()

            For Each AlarmItem As ClsAlarm.STRUCTURE_ALARM In _L8B.Alarm.AlarmList.Values 'for As Integer = 0 To dt.Rows.Count - 1
                Dim ViewItem As System.Windows.Forms.ListViewItem = .Items.Add(AlarmItem.Code)
                ViewItem.SubItems.Add(IIf(AlarmItem.Type = prjSECS.clsEnumCtl.eAlarmType.TYPE_ALARM, "Alarm", "Warn"))
                ViewItem.SubItems.Add(AlarmItem.Source.ToString)
                ViewItem.SubItems.Add(AlarmItem.OccurrTime)
                ViewItem.SubItems.Add(AlarmItem.ReleaseTime)
                ViewItem.SubItems.Add(AlarmItem.Message)
                ViewItem.SubItems.Add(AlarmItem.Remark)
                Dim fontBold As New Font(ViewItem.Font.FontFamily, ViewItem.Font.Size + 1, FontStyle.Bold)
                ViewItem.Font = fontBold
                If AlarmItem.Type = prjSECS.clsEnumCtl.eAlarmType.TYPE_WARNING Then
                    ViewItem.ForeColor = Color.Blue
                    ViewItem.BackColor = Color.White
                ElseIf AlarmItem.Type = prjSECS.clsEnumCtl.eAlarmType.TYPE_ALARM Then
                    ViewItem.ForeColor = Color.Red
                    ViewItem.BackColor = Color.White
                End If
            Next
            .Items(.Items.Count - 1).EnsureVisible()
            .Items(.Items.Count - 1).Focused = True
            .Items(.Items.Count - 1).Selected = True
            .EndUpdate()
        End With
    End Sub

    Public Sub SetupUserAutherity()
        If _L8B.Setting.User.Name = "" Then
            TabControlMain.Enabled = False
        Else
            TabControlMain.Enabled = True
        End If
        ButtonRecipe.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Recipe)
        ButtonTimeOut.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.TimeOut)
        ButtonLog.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Log)
        ButtonHSMS.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.HSMS)
        ButtonLink.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Link)
        ButtonOther.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Others)
        ButtonExit.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Exit)

        TabPageGeneral.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.General)
        TabPageAlarm.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.AlarmHistory)
        TabPageShopFloor.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.ShopFloor)
        TabPageBuffer.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Buffer)
        TabPageCVIO.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.CVIOMonitor)
        TabPageEQIO.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.EQIOMonitor)
        TabPageManual.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Manual)

        TabPageGeneral.ForeColor = IIf(_L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.General), Color.Black, Color.Gray)
        TabPageAlarm.ForeColor = IIf(_L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.AlarmHistory), Color.Black, Color.Gray)
        TabPageShopFloor.ForeColor = IIf(_L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.ShopFloor), Color.Black, Color.Gray)
        TabPageBuffer.ForeColor = IIf(_L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Buffer), Color.Black, Color.Gray)
        TabPageCVIO.ForeColor = IIf(_L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.CVIOMonitor), Color.Black, Color.Gray)
        TabPageEQIO.ForeColor = IIf(_L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.EQIOMonitor), Color.Black, Color.Gray)
        TabPageManual.ForeColor = IIf(_L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Manual), Color.Black, Color.Gray)

        'ButtonInitial.Enabled = mMain.User.Right(Ini.enumUserRight.Initial)
        ButtonResetSignal.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.ResetSignal)
        ButtonAutoManual.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.GO)
        ButtonLoopBack.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.LookBack)
        AccountManagementToolStripMenuItem.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.Authority)

        GroupBoxGlassFlowMode.Enabled = _L8B.Setting.User.Right(ClsSetting.cUser.enumUserRight.UIMode)
    End Sub

    Private Sub ButtonLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogout.Click
        If _L8B.Setting.User.Name <> "" Then
            _L8B.Log.Hide()
            If MsgBox("Do user[" & _L8B.Setting.User.Name & "] want to logout?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                WriteLog("User[" & _L8B.Setting.User.Name & "] Logout", LogMessageType.Info)
                _L8B.Setting.User.Name = ""
                _L8B.Setting.User.Logout()
                SetupUserAutherity()
                ButtonLogout.Text = "Login"
                Me.Text = _L8B.Setting.ID.Tool & " -- " & Application.ProductVersion.ToString & "." & DateVersion
            End If
        Else
            _L8B.Setting.User.Logout()
            Me.Enabled = False
            _L8B.dlgLogin.LoginLoad()
        End If
    End Sub

    Private Sub GroupBoxColorLengend_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBoxColorLengend.MouseDoubleClick
        GroupBoxColorLengend.Height = 343
        ButtonColorLegendHide.Visible = True
    End Sub

    Private Sub ButtonColorLegendHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonColorLegendHide.Click
        GroupBoxColorLengend.Height = 23
        ButtonColorLegendHide.Visible = False
    End Sub

    Private Sub CassetteInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CassetteInfoToolStripMenuItem.Click
        If _L8B.PLC.CassetteInPort(SelectPort) Then
            WriteLog("User select CassetteInfo Port" & SelectPort)
            'Try
            ' _L8B.dlgCassetteInfo(SelectPort).CIMShowMe(_L8B.frmMain)
            'Catch ex As Exception
            '    _L8B.dlgCassetteInfo(SelectPort) = New DialogCassetteInfo
            '    _L8B.dlgCassetteInfo(SelectPort).PortNo = SelectPort
            '    _L8B.dlgCassetteInfo(SelectPort).CIMShowMe(_L8B.frmMain)
            'End Try
            Try
                _L8B.frmCassetteInfoText(SelectPort).ShowMe()
            Catch ex As Exception

            End Try
            'Else
            '    _L8B.frmCassetteInfoText(SelectPort).ShowMe()
        End If
    End Sub

    'Private Sub CheckBoxReviewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxReviewMode.CheckedChanged
    '    _L8B.PLC.RepairReviewMode = CheckBoxReviewMode.Checked

    '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Repair Review Mode -> " & CheckBoxReviewMode.Checked & "." & vbCrLf & " It will affect next glass go into Repair.", MsgBoxStyle.OkOnly, 20, MsgBoxResult.Ok, False, 0)
    'End Sub

    Private Sub ButtonSaveBufferType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveBufferType.Click
        Dim mRunningMode As eRunningMode

        If Not RstguiStatusTowerPLC.Connect Then
            Exit Sub
        End If

        ButtonSaveBufferType.Enabled = False
        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.ButterFly, ClsSetting.EMACHINETYPE.FI
                If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                    mRunningMode = eRunningMode.MQC
                Else
                    mRunningMode = eRunningMode.THROUGH
                End If
            Case ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                If _L8B.Setting.Main.ColorRepairMode = L8BIFPRJ.clsPLC.eColorRepairMode.COLOR_MODE Then
                    mRunningMode = eRunningMode.TAPEINK
                Else
                    mRunningMode = eRunningMode.TAPE
                End If
        End Select

        If mRunningMode <> eRunningMode.NA Then
            For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                    _L8B.Setting.Main.BufferSlotType(mRunningMode)(i)(j) = RSTControl.CVGUIBufferEdit(i).SlotType(j)
                Next
            Next
            _L8B.Setting.SaveBuffer(mRunningMode)
        End If
        ButtonSaveBufferType.Enabled = True
        ButtonSaveBufferType.Focus()
    End Sub

    Private Sub DateTimePickerAlarmHistory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerAlarmHistory.ValueChanged
        UpdateDataGridViewAlarm()
    End Sub

    Private Sub ButtonBuzzerOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuzzerOff.Click
        _L8B.PLC.Buzzer(clsMainPLC.eBuzzerMode.OFF)
    End Sub

    Private Sub ButtonAlarmReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAlarmReset.Click
        _L8B.PLC.AlarmReset()
    End Sub

    Private Sub ComboBoxArm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxArm.SelectedIndexChanged
        UpdateManualSlotSelection()
    End Sub

    Private Sub ComboBoxModule_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxModule.SelectedIndexChanged
        UpdateManualSlotSelection()
    End Sub

    Private Sub CheckBoxReviewMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxReviewMode.Click
        If _L8B.PLC.RepairReviewMode <> CheckBoxReviewMode.Checked Then
            _L8B.PLC.RepairReviewMode = CheckBoxReviewMode.Checked
            'ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Repair Review Mode -> " & CheckBoxReviewMode.Checked & ".", MsgBoxStyle.OkOnly, 20, MsgBoxResult.Ok, False, 0)
        End If
    End Sub

    Private Sub ModulateSourcePos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModulateSourcePos.SelectedIndexChanged
        Dim SlotList As New ArrayList

        ModulateSourceSlot.DataSource = Nothing

        Select Case ModulateSourcePos.Text
            Case "Robot"
                SlotList.Add("UpperArm")
                SlotList.Add("LowerArm")
                ModulateSourceSlot.DataSource = SlotList

            Case "Buffer1"
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next
                ModulateSourceSlot.DataSource = SlotList

            Case "Buffer2"
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next
                ModulateSourceSlot.DataSource = SlotList

            Case "Buffer3"
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next
                ModulateSourceSlot.DataSource = SlotList

            Case "EQ1"
                SlotList.Add("1")
                ModulateSourceSlot.DataSource = SlotList
                If ModulateSourcePos.Text = ModulateDestinationPos.Text Then
                    ModulateSourceSlot.DataSource = Nothing
                End If
            Case "EQ2"
                SlotList.Add("2")
                ModulateSourceSlot.DataSource = SlotList
                If ModulateSourcePos.Text = ModulateDestinationPos.Text Then
                    ModulateSourceSlot.DataSource = Nothing
                End If
            Case "EQ3"
                SlotList.Add("3")
                ModulateSourceSlot.DataSource = SlotList
                If ModulateSourcePos.Text = ModulateDestinationPos.Text Then
                    ModulateSourceSlot.DataSource = Nothing
                End If
            Case Else
                ModulateSourceSlot.DataSource = Nothing
        End Select
    End Sub

    Private Sub ModulateDestinationPos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModulateDestinationPos.SelectedIndexChanged
        Dim SlotList As New ArrayList
        ModulateDestinationSlot.DataSource = Nothing

        Select Case ModulateDestinationPos.Text
            Case "Robot"
                SlotList.Add("UpperArm")
                SlotList.Add("LowerArm")
                ModulateDestinationSlot.DataSource = SlotList

            Case "Buffer1"
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next
                ModulateDestinationSlot.DataSource = SlotList

            Case "Buffer2"
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next
                ModulateDestinationSlot.DataSource = SlotList

            Case "Buffer3"
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next
                ModulateDestinationSlot.DataSource = SlotList

            Case "EQ1"
                SlotList.Add("1")
                ModulateDestinationSlot.DataSource = SlotList
                If ModulateDestinationPos.Text = ModulateSourcePos.Text Then
                    ModulateDestinationSlot.DataSource = Nothing
                End If
            Case "EQ2"
                SlotList.Add("2")
                ModulateDestinationSlot.DataSource = SlotList
                If ModulateDestinationPos.Text = ModulateSourcePos.Text Then
                    ModulateDestinationSlot.DataSource = Nothing
                End If
            Case "EQ3"
                SlotList.Add("3")
                ModulateDestinationSlot.DataSource = SlotList
                If ModulateDestinationPos.Text = ModulateSourcePos.Text Then
                    ModulateDestinationSlot.DataSource = Nothing
                End If
            Case Else
                ModulateDestinationSlot.DataSource = Nothing
        End Select
    End Sub

    Private Sub ComboBoxPMModule1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPMModule1.SelectedIndexChanged
        Dim SlotList As New ArrayList

        ComboBoxPMSlot1.DataSource = Nothing

        Select Case GetModule(ComboBoxPMModule1.Text)
            Case eRobotPosition.Buffer1
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next

            Case eRobotPosition.Buffer2
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(2)
                    SlotList.Add(i)
                Next

            Case eRobotPosition.Buffer3
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(3)
                    SlotList.Add(i)
                Next

            Case eRobotPosition.EQ1
                SlotList.Add(0)

            Case eRobotPosition.EQ2
                SlotList.Add(0)

            Case eRobotPosition.EQ3
                SlotList.Add(0)

            Case eRobotPosition.CVP1
                SlotList.Add(0)

            Case eRobotPosition.CVP2
                SlotList.Add(0)

            Case eRobotPosition.CVP3
                SlotList.Add(0)

        End Select

        ComboBoxPMSlot1.DataSource = SlotList
    End Sub

    Private Sub ComboBoxPMModule2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPMModule2.SelectedIndexChanged
        Dim SlotList As New ArrayList

        ComboBoxPMSlot2.DataSource = Nothing


        Select Case GetModule(ComboBoxPMModule2.Text)
            Case eRobotPosition.Buffer1
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(1)
                    SlotList.Add(i)
                Next

            Case eRobotPosition.Buffer2
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(2)
                    SlotList.Add(i)
                Next

            Case eRobotPosition.Buffer3
                For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(3)
                    SlotList.Add(i)
                Next

            Case eRobotPosition.EQ1
                SlotList.Add(0)

            Case eRobotPosition.EQ2
                SlotList.Add(0)

            Case eRobotPosition.EQ3
                SlotList.Add(0)

            Case eRobotPosition.CVP1
                SlotList.Add(0)

            Case eRobotPosition.CVP2
                SlotList.Add(0)

            Case eRobotPosition.CVP3
                SlotList.Add(0)

        End Select

        ComboBoxPMSlot2.DataSource = SlotList
    End Sub

    Public Sub GUICVFlowUpdate()
        For i As Integer = 1 To _L8B.Setting.Main.NumberPort
            _L8B.frmMain.RSTControl.CVGUIPort(i).FlowoutGlassID = ""
            For j As Integer = 1 To 3
                If MyTrim(mInfo.Port(i).GlassFlowCV(j).GlassID).Length > 0 Then
                    _L8B.frmMain.RSTControl.CVGUIPort(i).FlowoutGlassID = mInfo.Port(i).GlassFlowCV(j).GlassID
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub SelectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectToolStripMenuItem.Click
        _L8B.PLC.BufferSlotDestination(BufferSelect, BufferSlotSelect) = L8BIFPRJ.clsPLC.eNGGXToMachine.NA
        UpdateBufferSlotDest(BufferSelect, BufferSlotSelect, RSTShapFlowGUI.RSTGUICtrlSlots.eBuffDestination.NA)
        BufferSelect = 0
        BufferSlotSelect = 0
    End Sub

    Private Sub ButtonBufferInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBufferInfo.Click
        _L8B.dlgBufferGlassInfo.ShowMe(False)
    End Sub


    Public Sub UpdateCVControlStatusA(ByVal nStatus As L8BIFPRJ.clsPLC.eCVControlStatus)
        LabelCVStatusA.Text = nStatus.ToString
        Select Case nStatus
            Case L8BIFPRJ.clsPLC.eCVControlStatus.AUTO
                OvalShapeAuto.FillColor = Color.Green
            Case L8BIFPRJ.clsPLC.eCVControlStatus.MANUAL
                OvalShapeAuto.FillColor = Color.Red
        End Select
    End Sub

    Public Sub UpdateCVControlStatusR(ByVal nStatus As L8BIFPRJ.clsPLC.eCVControlStatus)
        LabelCVStatusR.Text = nStatus.ToString
        Select Case nStatus
            Case L8BIFPRJ.clsPLC.eCVControlStatus.RUN
                OvalShapeRun.FillColor = Color.Green
            Case L8BIFPRJ.clsPLC.eCVControlStatus.STOP
                OvalShapeRun.FillColor = Color.Red
        End Select
    End Sub

    Private Sub ButtonClearEQ1GlassData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearEQ1GlassData.Click
        If MsgBox("Please confirm to erease EQ1" & _L8B.Setting.ID.EQ1 & " Glass Data", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            _L8B.PLC.L8BPLC.DeleteEQGlassInfo(1)
        End If
    End Sub

    Private Sub ButtonClearEQ2GlassData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearEQ2GlassData.Click
        If MsgBox("Please confirm to erease EQ2" & _L8B.Setting.ID.EQ1 & " Glass Data", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            _L8B.PLC.L8BPLC.DeleteEQGlassInfo(2)
        End If
    End Sub

    Private Sub ButtonClearEQ3GlassData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearEQ3GlassData.Click
        If MsgBox("Please confirm to erease EQ3" & _L8B.Setting.ID.EQ1 & " Glass Data", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            _L8B.PLC.L8BPLC.DeleteEQGlassInfo(3)
        End If
    End Sub

    Private Sub ButtonResetHHIRobotMiliage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResetHHIRobotMiliage.Click
        If MsgBox("Please confirm to Reset HHI Robot Milleage.", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            _L8B.PLC.L8BPLC.ResetMileage = True
        End If
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        _L8B.dlgChangePassword.LoginLoad()
    End Sub

    Private Sub ListViewAlarmView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewAlarmView.DoubleClick
        Dim dlgAlarmInfo As New DialogAlarmInfo
        dlgAlarmInfo.Showme(ListViewAlarmView.SelectedIndices.Item(0))
    End Sub

    Public Sub UpdateArmMode()
        Select Case _L8B.Setting.Main.RobotArmUse
            Case 0
                LabelArmMode.Text = "Dual Arm"
            Case 1
                LabelArmMode.Text = "Up Arm Only"
            Case 2
                LabelArmMode.Text = "Low Arm Only"
            Case Else
                LabelArmMode.Text = "[Arm use] setting error"
        End Select

        RstguiCtrlRBT.ArmMode = _L8B.Setting.Main.RobotArmUse
    End Sub

    ''20120203 for disable miss syn with PLC
    Private Sub guiCtrlSlots1_SlotMouseEnter(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots1.SlotMouseEnter
        guiCtrlSlots1.SlotEnabled(nSlot) = _L8B.PLC.BufferSlotEnable(1, nSlot)
    End Sub

    Private Sub guiCtrlSlots2_SlotMouseEnter(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots2.SlotMouseEnter
        guiCtrlSlots2.SlotEnabled(nSlot) = _L8B.PLC.BufferSlotEnable(2, nSlot)
    End Sub

    Private Sub guiCtrlSlots3_SlotMouseEnter(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles guiCtrlSlots3.SlotMouseEnter
        guiCtrlSlots3.SlotEnabled(nSlot) = _L8B.PLC.BufferSlotEnable(3, nSlot)
    End Sub

    ''20120203 to update buffer Glass Info
    Private Sub ButtonUpdateBufferGlassdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateBufferGlassdata.Click
        ButtonUpdateBufferGlassdata.Enabled = False
        ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Please Wait", MsgBoxStyle.OkOnly, 1, MsgBoxResult.Ok)

        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
            For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                _L8B.PLC.BufferSlotChange(i, j, mInfo.Buffer(i).fGlassExist(j))
            Next
        Next
        ButtonUpdateBufferGlassdata.Enabled = True
    End Sub

End Class
