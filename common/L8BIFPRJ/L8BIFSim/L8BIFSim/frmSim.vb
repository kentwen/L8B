Imports RaibBow

Public Class frmSim

    Public WithEvents MyPLC As New L8BIFPRJ.clsPLC
    Public MyWriteIniLog As New clsLogParameter
    Dim mnCount As Integer = 1


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        End
    End Sub

    Private Sub btnCVTransferResetReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MyPLC.CVTransferReset(True)
    End Sub

    Private Sub btnCVTransferResetReqOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MyPLC.CVTransferReset(False)
    End Sub

    Private Sub btnDummyCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyPLC.CVDummyCancel(Val(Me.txtDCPortNo.Text))
    End Sub

    Private Sub btnS765DataDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS765DataDownload.Click
        Dim MyLotInfo As New L8BIFPRJ.clsS765LotInfo
        Dim nFor As Integer
        Dim n765Slot1 As Integer
        Dim n765Slot2 As Integer

        n765Slot1 = Val(Me.txtS756Slot1.Text)
        n765Slot2 = Val(Me.txtS756Slot2.Text)

        With MyLotInfo
            .LineID = "FDF10"
            .ToolID = "FDFRST10"
            .CassetteID = "FD0812"
            .ProductCode = "T420HW06-VA210P210"
            .ProductCategory = 0
            .MeasurementID = "OP-FI"
            .OperationID = "FI"
            .EPPIDEQ1 = "001"
            .EPPIDEQ2 = "002"
            .TargetPosition = Me.cobTargetPos.SelectedIndex
            .AOIFunction = 0
            .RunningMode = Me.cobRunningMode.SelectedIndex

            .RobotSpeed = 3
            .GlassType = Me.cobRepairmode.SelectedIndex   '0 Tape 1 Ink
            .VCRPosition = 1
            .CurrentRecipe = "100"
        End With

        For nFor = n765Slot1 To n765Slot2
            With MyLotInfo.Slots(nFor)
                .GlassID = (Me.txtGlassID.Text) & mnCount
                .POPERID = "PS"
                .PLINEID = "FDS10"
                .PTOOLID = "FDSALN11"
                .DMQCToolID = ""
                .GlassGrade = "G"
                .DMQCGrade = "O"
                .PSHGroup = "AA"
                .ReworkFlag = "R"
                .ScrapFlag = "S"
                .FIRemarkFlag = "M"
                .FIFCFlag = 1
                .ProcessedFlag = 1
            End With
            mnCount = mnCount + 1
        Next

        MyPLC.S765DataDownload(Val(Me.txtPortNo.Text), MyLotInfo)
        MyLotInfo = Nothing
    End Sub

    Private Sub btnRecipeCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecipeCheck.Click
        MyPLC.EQRecipeCheck(Me.txtEQIndex.Text, Me.txtRecipeCheckID.Text)
    End Sub

    Private Sub btnRSTCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTCommand.Click

        MyPLC.RSTCommand(Me.cobRobotToGo.SelectedIndex, Me.cobRobotArm.SelectedIndex, Me.cobRobotAction.SelectedIndex, Me.cobRSTPosition.SelectedIndex, Me.txtRobotSlotNo.Text, Me.txtRSTGlassType.Text, Me.cobRSTSpeed.SelectedIndex)
    End Sub

    Private Sub btnSyncDateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSyncDateTime.Click
        Dim MyDateTime As New L8BIFPRJ.clsDateTime

        MyDateTime.nYear = Val(Me.txtYear.Text)
        MyDateTime.nMonth = Val(Me.txtMonth.Text)
        MyDateTime.nDay = Val(Me.txtDay.Text)
        MyDateTime.nHour = Val(Me.txtHour.Text)
        MyDateTime.nMinute = Val(Me.txtMinute.Text)
        MyDateTime.nSecond = Val(Me.txtSecond.Text)
        MyDateTime.nWeek = Val(Me.txtWeek.Text)

        MyPLC.SyncDateTime(MyDateTime)
    End Sub

    Private Sub btnShowGUICV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowGUICV.Click
        MyPLC.OpenCVGUISignal() = True
        MyPLC.CVGUIEngineerMode = True

        frmCVGUITest.Show()
    End Sub

    Private Sub btnSetBAddr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBAddr.Click
        Dim strAddr As String = ""
        Dim nAddr As Integer

        strAddr = "&H" & Me.txtSetAddr.Text
        nAddr = Val(strAddr)

        Call MyPLC.TestFuctcionWriteBAddr(nAddr, IIf(Me.txtSetValue.Text = 1, True, False))
    End Sub

    Private Sub btnShowGUIEQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowGUIEQ.Click
        MyPLC.OpenEQGUISignal() = True
        MyPLC.EQGUIEngineerMode = True

        frmEQGUITest.Show()
    End Sub



    Private Sub btnCVOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVOnline.Click
        MyPLC.CVRSTOnline(True)
    End Sub

    Private Sub btnCVOnlineOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVOnlineOff.Click
        MyPLC.CVRSTOnline(False)
    End Sub

    Private Sub btnCVREQUnloadCST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVREQUnloadCST.Click
        MyPLC.CVRequestUnloadCST(Val(Me.txtREQUnloadCST.Text))
    End Sub

    Private Sub btnCVDummyCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVDummyCancel.Click
        MyPLC.CVDummyCancel(Val(Me.txtDCPortNo.Text))
    End Sub

    Private Sub btnCVTransferResetReq_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVTransferResetReq.Click
        MyPLC.CVTransferReset(True)
    End Sub

    Private Sub btnCVTransferResetReqOff_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVTransferResetReqOff.Click
        MyPLC.CVTransferReset(False)
    End Sub

    Private Sub btnCVPortPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVPortPause.Click
        MyPLC.CVPortPause(Val(Me.txtPausePortNo.Text))
    End Sub

    Private Sub btnCVPortResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVPortResume.Click
        MyPLC.CVPortResume(Val(Me.txtPausePortNo.Text))
    End Sub

    Private Sub btnEQRSTOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEQRSTOnline.Click
        MyPLC.EQRSTOnline(Me.txtEQIndex.Text, True)
    End Sub

    Private Sub btnEQRSTOnlineOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEQRSTOnlineOff.Click
        MyPLC.EQRSTOnline(Me.txtEQIndex.Text, False)
    End Sub

    Private Sub btnEQTransferReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEQTransferReset.Click
        MyPLC.EQTransferReset(Me.txtEQIndex.Text, True)
    End Sub

    Private Sub btnRSTErrorReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTErrorReset.Click
        MyPLC.RSTAlarmReset()
    End Sub

    Private Sub btnRSTPauseRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTPauseRequest.Click
        MyPLC.RSTPauseRequest()
    End Sub

    Private Sub btnRSTResumeRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTResumeRequest.Click
        MyPLC.RSTResumeRequest()
    End Sub

    Private Sub RSTInterfaceCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RSTInterfaceCheck.Click
        MyPLC.RSTInterfaceCheck(True)
    End Sub

    Private Sub btnRSTInterfaceCheckOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTInterfaceCheckOff.Click
        MyPLC.RSTInterfaceCheck(False)
    End Sub


    Private Sub btnProcessCmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessCmd.Click
        Dim nPort As Integer
        Dim nProceCmd As Integer
        Dim naArray1(64) As Integer
        Dim nProcessCount As Integer
        Dim strCSTID As String = ""
        Dim nFor As Integer
        Dim nProcessFlag As Integer
        Dim n765Slot1 As Integer
        Dim n765Slot2 As Integer

        n765Slot1 = Val(Me.txtS756Slot1.Text)
        n765Slot2 = Val(Me.txtS756Slot2.Text)
        nProcessFlag = Val(Me.txtProcessFlag.Text)

        For nFor = n765Slot1 To n765Slot2
            naArray1(nFor) = nProcessFlag
        Next

        nProcessCount = Val(Me.txtnProcessCount.Text)
        nPort = Val(Me.txtProcesscmdPort.Text)
        nProceCmd = 1
        strCSTID = Me.txtProcesscmdCSTID.Text

        MyPLC.CVCSTProcessCommand(nPort, strCSTID, nProceCmd, naArray1, nProcessCount)
    End Sub

    Private Sub btnSetWAddr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetWAddr.Click
        Dim anValue(0) As Integer
        Dim strAddr As String = ""
        Dim nAddr As Integer

        strAddr = "&H" & Me.txtSetWAddr.Text
        nAddr = Val(strAddr)

        anValue(0) = Me.txtSetWAddrValue.Text

        MyPLC.TestFuctcionWriteWAddr(nAddr, anValue)
    End Sub


    Private Sub ASCStringConvert(ByVal strData As String, ByVal nMaxLen As Integer, ByVal alValue() As Integer)
        Dim i As Integer
        Dim j As Integer
        Dim nFor As Integer

        nMaxLen = nMaxLen + 1
        If Len(strData) <> (nMaxLen * 2) Then
            For i = Len(strData) To (nMaxLen * 2) - 1
                strData = strData & " "
            Next i
        End If

        For nFor = 1 To nMaxLen
            alValue(j) = WordStringConvert(Mid(strData, (nFor * 2) - 1, 2))
            j = j + 1
        Next nFor

    End Sub

    Private Function WordStringConvert(ByVal strData As String) As Integer
        WordStringConvert = Asc(Mid(strData, 2, 1)) * 256 + Asc(Mid(strData, 1, 1))
    End Function

    Private Sub btnSetWAddrArray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetWAddrArray.Click
        Dim anValue() As Integer
        Dim strAddr As String = ""
        Dim nAddr As Integer

        ReDim anValue(Me.txtArrayLen.Text)

        strAddr = "&H" & Me.txtSetWAddr.Text
        nAddr = Val(strAddr)


        ASCStringConvert(Me.txtSetWAddrValue.Text, Me.txtArrayLen.Text, anValue)

        MyPLC.TestFuctcionWriteWAddr(nAddr, anValue)
    End Sub

    Private Sub btnShowTimeoutSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowTimeoutSet.Click
        MyPLC.ShowTimeOutForm()
    End Sub

    Private Sub btnSetZRAddrArray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetZRAddrArray.Click
        Dim anValue() As Integer
        Dim strAddr As String = ""
        Dim nAddr As Integer

        ReDim anValue(Me.txtArrayLen.Text)

        strAddr = Me.txtSetWAddr.Text
        nAddr = Val(strAddr)


        ASCStringConvert(Me.txtSetWAddrValue.Text, Me.txtArrayLen.Text, anValue)

        MyPLC.TestFuctcionWriteZRAddr(nAddr, anValue)
    End Sub

    Private Sub btnSetZRAddr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetZRAddr.Click
        Dim anValue(0) As Integer
        Dim strAddr As String = ""
        Dim nAddr As Integer

        strAddr = Me.txtSetWAddr.Text
        nAddr = Val(strAddr)

        anValue(0) = Me.txtSetWAddrValue.Text

        MyPLC.TestFuctcionWriteZRAddr(nAddr, anValue)
    End Sub

    Private Sub MyPLC_CVINIT167data(ByVal nPortNo As Integer, ByVal LotStructure As L8BIFPRJ.clsS167LotInfo) Handles MyPLC.CVINIT167data
        Dim strDateTime As String = ""
        strDateTime = Format(Now, "yyyyMMddhhmmss")

        Debug.Print(LotStructure.CassetteStatus.ToString)
        Debug.Print("Port = " & nPortNo)
        Debug.Print(strDateTime)
    End Sub

    Private Sub MyPLC_CVS167dataUploadRequest(ByVal nPortNo As Integer, ByVal LotStructure As L8BIFPRJ.clsS167LotInfo) Handles MyPLC.CVS167dataUploadRequest
        'Dim nFor As Integer

        'Debug.Print(LotStructure.CassetteStatus)

        'For nFor = 1 To 50
        '    If nFor = 1 Or nFor = 50 Then
        '        Debug.Print(LotStructure.Slots(nFor).GlassID)

        '    End If
        'Next
    End Sub

    Private Sub frmSim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyWriteIniLog.StartAutoSaveLog(GenerateLogFile, 0)

        MyWriteIniLog.AutoClear = True
        MyWriteIniLog.Max = 3000
        MyWriteIniLog.AutoCreateLogFile = True
        MyWriteIniLog.LogVisible = True

        Dim strFullPath As String = ""

        strFullPath = "C:\L8BIFPRJ\L8BIFINI.ini"

        MyPLC.PLCInitial(strFullPath)
    End Sub

    Private Function GenerateLogFile() As String
        Dim strLogFile As String
        Dim nYear As Integer
        Dim nMonth As Integer
        Dim nDay As Integer
        Dim nHour As Integer
        Dim nMinute As Integer
        Dim nSecond As Integer

10:     On Error GoTo GenerateLogFile_Error

20:     nYear = Microsoft.VisualBasic.DateAndTime.Year(Now)
30:     nMonth = Microsoft.VisualBasic.DateAndTime.Month(Now)
40:     nDay = Microsoft.VisualBasic.DateAndTime.Day(Now)
50:     nHour = Microsoft.VisualBasic.DateAndTime.Hour(Now)
60:     nMinute = Microsoft.VisualBasic.DateAndTime.Minute(Now)
70:     nSecond = Microsoft.VisualBasic.DateAndTime.Second(Now)

80:     strLogFile = "C:\LOG\" & CStr(nYear) & Microsoft.VisualBasic.Right("0" & CStr(nMonth), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nDay), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nHour), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nMinute), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nSecond), 2) & ".log"

        '90:     GenerateLogFile = Microsoft.VisualBasic.Left(My.Application.Info.DirectoryPath, 3) & "PSTi" & strLogFile
        GenerateLogFile = strLogFile
        'On Error GoTo 0
100:    Exit Function

GenerateLogFile_Error:
        '110:    Globwritelog(Type_ProcessErr, "Code Err " & Err.Number & "/" & Err.Source & " (" & Err.Description & ") at Line " & Erl & " in procedure GenerateLogFile of Form frmMain")

    End Function

    Private Sub btnRSTBuzzerControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTBuzzerControl.Click
        MyPLC.RSTBuzzerControl(Me.txtBuzzerMode.Text, True)
    End Sub

    Private Sub btnRSTBuzzerControlOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTBuzzerControlOff.Click
        MyPLC.RSTBuzzerControl(Me.txtBuzzerMode.Text, False)
    End Sub

    Private Sub btnRSTLightTowerControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTLightTowerControl.Click
        MyPLC.RSTLightTowerControl(Me.cobLightTower.SelectedIndex, Me.cobLightTowerStatus.SelectedIndex)
    End Sub

    Private Sub btnRSTBufferGlassEraseRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTBufferGlassEraseRequest.Click
        MyPLC.RSTBufferGlassEraseRequest(Me.txtBufEraseSlot.Text, Me.txtBufErasePosition.Text)
    End Sub

    Private Sub btnRSTArmGxErase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTArmGxErase.Click
        MyPLC.RSTArmGlassErase(Me.cobArmGxErase.SelectedIndex)
    End Sub

    Private Sub btnSetNGGlasstoMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetNGGlasstoMachine.Click
        MyPLC.SetNGGlasstoMachine(Me.txtSetNgGxPort.Text, Me.txtSetNgGxSlot.Text, Me.cobMachine.SelectedIndex)
    End Sub

    Private Sub btnEQIgnoreTimeout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEQIgnoreTimeout.Click
        MyPLC.EQIgnoreTimeout(Me.txtEQIndex.Text) = True
    End Sub

    Private Sub IgnoreTimeoutOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IgnoreTimeoutOff.Click
        MyPLC.EQIgnoreTimeout(Me.txtEQIndex.Text) = False
    End Sub

    Private Sub btnEQArmMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEQArmMode.Click
        MyPLC.EQArmMode = Me.cobArmMode.SelectedIndex
    End Sub

    Private Sub btnEQTranfserMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEQTranfserMode.Click
        MyPLC.EQTranfserMode(Me.txtEQIndex.Text) = 1
    End Sub

    Private Sub btnEQTranfserModeOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEQTranfserModeOff.Click
        MyPLC.EQTranfserMode(Me.txtEQIndex.Text) = 0
    End Sub

    Private Sub btnPortChangeRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPortChangeRequest.Click
        MyPLC.CVPortChange(Me.txtPortChangePortNo.Text, Me.cobPortMode.SelectedIndex, Me.cobPortType.SelectedIndex)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MyPLC.EQRunningMode = cobRunningMode1.SelectedIndex
    End Sub

    Private Sub btnShowGUICVOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowGUICVOff.Click
        MyPLC.OpenCVGUISignal() = False
        MyPLC.CVGUIEngineerMode = False

        frmCVGUITest.Close()
    End Sub

    Private Sub btnShowGUIEQOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowGUIEQOff.Click
        MyPLC.OpenEQGUISignal() = False
        MyPLC.EQGUIEngineerMode = False

        frmEQGUITest.Close()
    End Sub

    Private Sub btnSetBufferSlotStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBufferSlotStatus.Click

        MyPLC.BufferSlotStatus(1, 1) = L8BIFPRJ.clsPLC.eBufferStatus.Ink
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btnRSTRemoteStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTRemoteStatus.Click
        MyPLC.RSTRemoteStatus = Me.cobRSTRemoteStatus.SelectedIndex
    End Sub

    Private Sub btnGetToolID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetToolID.Click
        Dim strToolID As String

        strToolID = MyPLC.EQToolID(Me.txtEQIndex.Text)

    End Sub

    Private Sub btnShowGeneralGUI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowGeneralGUI.Click
        MyPLC.OpenGeneralGUISignal = True
        frmGeneralGUI.Show()
    End Sub

    Private Sub btnCloseGeneralGUI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseGeneralGUI.Click
        MyPLC.OpenGeneralGUISignal = False
        frmGeneralGUI.Close()
    End Sub

    Private Sub btnWriteBufferGxInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteBufferGxInfo.Click
        Dim MyBufferGxInfo As New L8BIFPRJ.clsBufferGlassInfo

        With MyBufferGxInfo
            '.GlassDataRef = 1
            .SampleGlassFlag = 0
            .ProductCategory = 1
            .SlotInfo = 30
            .GlassID = "GX001"
            .EPPID(1) = "001"
            .EPPID(2) = "002"
            .MESID = "MESID"
            .ProductCode = "ProductCode001"
            .CurrentRecipe = "CurrRecipe001"
            .POPERID = "POPERID"
            .PLINEID = "PLINEID1"
            .PTOOLID = "PTOOLID1"
            .CSTID = "CST001"
            .OperationID = "OperationID1"
            .GlassGrade = "A"
            .DMQCGrade = "B"
            .GlassScrapFlag = "K"
            .AOIFunctionMode = 1
            '.RDGRADE = 2
            '.DGRADE = 3
            '.GGRADE = 4
            '.PSHGrade = "ABCD"
            '.PToolIDIndex = 1
            '.DMQCToolID = "DMQC1234"
            '.ChipGrade = "GOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO"

            '.FIRMFLAG = 1
            '.SCRPFLAG = 2
            '.RWKFLAG = 3
        End With

        MyPLC.WriteBufferGlassInfo(1, 1) = MyBufferGxInfo

    End Sub

    Private Sub btnWriteArmGxInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteArmGxInfo.Click
        Dim MyArmGxInfo As New L8BIFPRJ.clsArmGlassInfo

        With MyArmGxInfo
            '.GlassDataRef = 1
            .SampleGlassFlag = 0
            .ProductCategory = 1
            .SlotInfo = 30
            .GlassID = "GX002"
            .EPPID(1) = "001"
            .EPPID(2) = "002"
            .MESID = "MESID"
            .ProductCode = "ProductCode001"
            .CurrentRecipe = "CurrRecipe001"
            .POPERID = "POPERID"
            .PLINEID = "PLINEID1"
            .PTOOLID = "PTOOLID1"
            .CSTID = "CST001"
            .OperationID = "OperationID1"
            .GlassGrade = "A"
            .DMQCGrade = "B"
            .GlassScrapFlag = "K"
            .AOIFunctionMode = 1
            '.RDGRADE = 2
            '.DGRADE = 3
            '.GGRADE = 4
            '.PSHGrade = "ABCD"
            '.PToolIDIndex = 1
            '.DMQCToolID = "DMQC1234"
            '.ChipGrade = "GOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO"

            '.FIRMFLAG = 1
            '.SCRPFLAG = 2
            '.RWKFLAG = 3
        End With

        MyPLC.WriteArmGlassInfo(Me.cobWriteArmGxInfo.SelectedIndex) = MyArmGxInfo
    End Sub

    Private Sub btnGetEQStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetEQStatus.Click
        Dim nStatus As Integer

        nStatus = MyPLC.EQStatus(Me.txtEQIndex.Text)
    End Sub


    Private Sub btnShowSampleGxSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowSampleGxSetting.Click
        MyPLC.ShowSampleGlassSetting()
    End Sub

    Private Sub btnGetArmGxInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetArmGxInfo.Click
        Dim ArmGxInfo As L8BIFPRJ.clsArmGlassInfo

        ArmGxInfo = MyPLC.GetArmGlassInfo(Me.cobWriteArmGxInfo.SelectedIndex)
    End Sub

    Private Sub btnSetRSTMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetRSTMode.Click
        MyPLC.RSTSetRobotMode = Me.cobSetRSTMode.SelectedIndex
    End Sub

    Private Sub btnRSTCMDMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTCMDMode.Click
        MyPLC.RSTSetRobotCommandMode = Me.cobRSTCMDMode.SelectedIndex
    End Sub

    Private Sub btnRSTInitial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSTInitial.Click
        MyPLC.RSTSetRobotInitial = True
    End Sub

    Private Sub btnGetCSTSlotData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCSTSlotData.Click
        Dim vTemp As L8BIFPRJ.clsS167SlotInfo


        vTemp = MyPLC.GetCSTSlotInfo(Val(Me.txtGCSTPort.Text), Val(Me.txtGCSTSlot.Text))
    End Sub

    Private Sub btnModeChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModeChange.Click

        MyPLC.RSTColorRepairRunMode = Val(Me.txtModeChange.Text)
    End Sub

    Private Sub btnRecipeQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecipeQuery.Click
        MyPLC.EQRecipeParameterQuery(Me.txtEQIndex.Text, Me.txtRecipeCheckID.Text)
    End Sub


    Private Sub MyPLC_EQRecipeQueryResult(ByVal nEQIndex As Integer, ByVal fExists As Boolean, ByVal strPPID As String, ByVal nParameterData() As Integer) Handles MyPLC.EQRecipeQueryResult
        '
    End Sub
End Class
