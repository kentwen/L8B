Module ModuleRST

    Private Const RST_ADDR = 400
    Private Const MAX_RST_ARRAY_LEN = 599
    Public Const RST_ALARM_WORD_LEN = 19
    Public Const MAX_RST_ALARM_CODE = 304

    Public Const ROBOT_ALARM_WORD_LEN = 3
    Public Const MAX_ROBOT_ALARM_CODE = 48

    Private Const TRACEDATA_LOG_ADDR = 60000
    Private Const TRACEDATA_LEN = 491

    Private Const RST_LOG_ADDR = 59000
    Private Const WRITE_LOG_LEN = 801
    Private Const TIMEOUT_LOG_ADDR = 60500
    Private Const WRITE_TIMEOUT_FUN_LEN = 491

    Public MyRSTMAddr As RST_M_Addr
    Public MyRSTZRAddr As RST_ZR_Addr

    Public MyRSTNewWord As RST_NEW_ZR_WordData
    Public MyRSTOldWord As RST_OLD_ZR_WordData


    Public g_anRST_New_ZRWord(MAX_RST_ARRAY_LEN) As Integer
    Private g_anRST_ZRWriteLogWord(WRITE_LOG_LEN) As Integer
    Private m_anWriteTimeoutFunLog(WRITE_TIMEOUT_FUN_LEN) As Integer
    Private m_anWriteTraceData(TRACEDATA_LEN) As Integer


    


    

    Enum eTIMEOUT_ITEM
        S167_DATA_UPLOAD_REQ_P1 = 3306
        S167_DATA_UPLOAD_REQ_P2 = 3307
        S167_DATA_UPLOAD_REQ_P3 = 3308

        PORT_CHANGE_REPORT_P1 = 3309
        PORT_CHANGE_REPORT_P2 = 3310
        PORT_CHANGE_REPORT_P3 = 3311

        GLASS_ABNORMAL_REPORT = 3315
        GLASS_UNMATCHED_REPORT = 3316

        FLOW_OUT_REPORT_P1 = 3322
        FLOW_OUT_REPORT_P2 = 3323
        FLOW_OUT_REPORT_P3 = 3324

        FLOW_IN_REPORT = 3326

        GLASS_DATA_REQ_REPORT = 3345

        GLASS_DATA_ERASE_EQ1 = 3500
        GLASS_DATA_ERASE_EQ2 = 3501
        GLASS_DATA_ERASE_EQ3 = 3502

        RECIPE_MODIFIED_EQ1 = 3508
        RECIPE_MODIFIED_EQ2 = 3509
        RECIPE_MODIFIED_EQ3 = 3510

        EQ_RESULT_REPORT_EQ1 = 3512
        EQ_RESULT_REPORT_EQ2 = 3513
        EQ_RESULT_REPORT_EQ3 = 3514
    End Enum

    Public Structure RST_M_Addr
        Dim mnRobotStart As Integer
        Dim mnRobotErrorReset As Integer
        Dim mnSyncDateTime As Integer
        Dim mnCPCAlive As Integer
        Dim mnRobotPauseRequest As Integer
        Dim mnRobotResumeRequest As Integer
        Dim mnRobotInterfaceCheck As Integer

        Dim mnRSTTowerR As Integer
        Dim mnRSTTowerY As Integer
        Dim mnRSTTowerG As Integer
        Dim mnRSTTowerRBlink As Integer
        Dim mnRSTTowerYBlink As Integer
        Dim mnRSTTowerGBlink As Integer
        Dim mnRSTBuzzer1 As Integer
        Dim mnRSTBuzzer2 As Integer
        Dim mnRSTBufferGlassEraseRequest As Integer
        Dim mnRSTUpperArmGlassErase As Integer
        Dim mnRSTLowerArmGlassErase As Integer

        Dim mnRSTEQIgnoreTimeout() As Integer
        'Dim mnRSTEQArmMode() As Integer
        Dim mnRSTEQTransferMode() As Integer
        Dim mnRSTRunningMode As Integer

        Dim mnRobotModeManual As Integer
        Dim mnRobotModeAuto As Integer
        Dim mnRobotModeEng As Integer
        Dim mnRobotInit As Integer
        Dim mnRobotStop As Integer
        Dim mnRobotPM As Integer
        Dim mnRobotDioTestMode As Integer
        Dim mnRSTGlassModify As Integer

        Dim mnManualSampleGlass() As Integer
        Dim mnRSTStart As Integer
        Dim mnBufferDisable1 As Integer
        Dim mnBufferDisable2 As Integer
        Dim mnBufferDisable3 As Integer
        Dim mnRobotStandBy As Integer
        Dim mnRobotResetInOutBit As Integer

        Dim mnGxFlowInAck(,) As Integer
        Dim mnGxFlowOutAck(,) As Integer

    End Structure

    Public Structure RST_ZR_Addr
        Dim RobotCmdToGo As Integer
        Dim RobotCmdArm As Integer
        Dim RobotCmdAction As Integer
        Dim RoborPosition As Integer
        Dim RobotCmdSlotInfo As Integer
        Dim RobotCmdGlassType As Integer
        Dim RobotSpeed As Integer

        Dim RobotYear As Integer
        Dim RobotMonth As Integer
        Dim RobotDay As Integer
        Dim RobotHour As Integer
        Dim RobotMinute As Integer
        Dim RobotSeacond As Integer
        Dim RobotWeek As Integer


        Dim RobotEraseBufPosition As Integer
        Dim RobotEraseBufSlot As Integer
        Dim RobotInterfaceLogCount As Integer
        Dim RobotResetTracedataLogCount As Integer
        Dim RobotRunningMode As Integer
        Dim RobotRemoteStatus As Integer
        Dim RobotColorRepairRunMode As Integer
        Dim RobotEQArmMode As Integer

        Dim RobotSampleGxHour1 As Integer
        Dim RobotSampleGxMinute1 As Integer
        Dim RobotSampleGxHour2 As Integer
        Dim RobotSampleGxMinute2 As Integer
        Dim RobotSampleGxHour3 As Integer
        Dim RobotSampleGxMinute3 As Integer
        Dim RobotSampleGxHour4 As Integer
        Dim RobotSampleGxMinute4 As Integer
        Dim EQ1SampleGxWeek As Integer
        Dim EQ2SampleGxWeek As Integer

        Dim RobotTimeoutCount As Integer
    End Structure

    Public Structure RST_NEW_ZR_WordData
        Dim mnRobotcommandPossible As Integer
        Dim mnRobotCommandAck As Integer
        Dim mnRobotManualComplete As Integer
        Dim mnAutomode As Integer
        Dim mnManualmode As Integer
        Dim mnEngineerMode As Integer
        Dim mnRobotPauseAck As Integer
        Dim mnRobotResumeAck As Integer
        Dim mnRobotStart As Integer
        Dim mnRobotStartComplete As Integer

        Dim mnRobotStartCommand As Integer
        Dim mnRobotInitialRequest As Integer
        Dim mnRobotStandBy As Integer
        Dim mnRobotCommandErrorLog As Integer
        Dim mnRSTAlive As Integer
        Dim mnRSTAlarmWord() As Integer
        Dim mnRSTAlarm() As Integer
        Dim mnRobotInterfaceLogCount As Integer
        Dim mnRobotTraceDataCount As Integer
        Dim mnRobotStatus As clsPLC.eRSTStatus
        Dim mnBufferPortGxExist(,) As Integer
        Dim mnBufferDisable(,) As Integer
        Dim mnGxFlowIn(,) As Integer
        Dim mnGxFlowOut(,) As Integer
        Dim mnCSTGxExist(,) As Integer
        Dim mnCSTStatus() As Integer
        Dim mnCSTGxCount() As Integer

        Dim mnArmUpperGlassExist As Integer
        Dim mnArmLowerGlassExist As Integer
        Dim mnEQWithGlassID() As Integer
        Dim mstrEQWithGXID() As String
        Dim mnRSTStartArm As clsPLC.eRSTArm
        Dim mnRSTStartPosition As Integer
        Dim mnRSTStartSlot As Integer
        Dim mnRSTStartTarget As clsPLC.eRobotTarget
        Dim mnRSTStartCMD As clsPLC.eRobotCommand
        Dim mnRSTStartAction As clsPLC.eRobotAction
        Dim mnRSTStartHandshake As Integer
        Dim mnCheckTimeoutFun As Integer
        Dim mnRSTArm As clsPLC.eRSTArm
        Dim mnPosition As Integer
        Dim mnSlotNo As Integer
        Dim mnRSTErrorCase As Integer
        Dim mnTarget As clsPLC.eRobotTarget
        Dim mnJobNo As Integer
        Dim mnCMD As clsPLC.eRobotCommand
        Dim mnAction As clsPLC.eRobotAction
        Dim mnHandshake As Integer

        Dim mnUpArmSensor As Integer
        Dim mnLowArmSensor As Integer
        Dim mnUpArmVaccum As Integer
        Dim mnLowArmVaccum As Integer
        Dim mnRSTServoOn As Integer
        Dim mnRSTReady As Integer
        Dim mnCMDBusy As Integer
        Dim mnForkExtend As Integer

        Dim mnRobotAlarmWord() As Integer
        Dim mnRobotAlarm() As Integer
    End Structure

    Public Structure RST_OLD_ZR_WordData
        Dim mnRobotcommandPossible As Integer
        Dim mnRobotCommandAck As Integer
        Dim mnRobotManualComplete As Integer
        Dim mnAutomode As Integer
        Dim mnManualmode As Integer
        Dim mnEngineerMode As Integer
        Dim mnRobotPauseAck As Integer
        Dim mnRobotResumeAck As Integer
        Dim mnRobotStart As Integer
        Dim mnRobotStartComplete As Integer

        Dim mnRobotStartCommand As Integer
        Dim mnRobotInitialRequest As Integer
        Dim mnRobotStandBy As Integer
        Dim mnRobotCommandErrorLog As Integer
        Dim mnRSTAlive As Integer
        Dim mnRSTAlarmWord() As Integer
        Dim mnRSTAlarm() As Integer

        Dim mnRobotInterfaceLogCount As Integer
        Dim mnRobotTraceDataCount As Integer
        Dim mnRobotStatus As clsPLC.eRSTStatus

        Dim mnBufferPortGxExist(,) As Integer

        Dim mnBufferDisable(,) As Integer
        Dim mnGxFlowIn(,) As Integer
        Dim mnGxFlowOut(,) As Integer

        Dim mnArmUpperGlassExist As Integer
        Dim mnArmLowerGlassExist As Integer

        Dim mnEQWithGlassID() As Integer

        Dim mstrEQWithGXID() As String
        Dim mnCheckTimeoutFun As Integer

        Dim mnUpArmSensor As Integer
        Dim mnLowArmSensor As Integer
        Dim mnUpArmVaccum As Integer
        Dim mnLowArmVaccum As Integer
        Dim mnRSTServoOn As Integer
        Dim mnRSTReady As Integer
        Dim mnCMDBusy As Integer
        Dim mnForkExtend As Integer

        Dim mnRobotAlarmWord() As Integer
        Dim mnRobotAlarm() As Integer
    End Structure

    Public Sub ReDimRSTArraySize()
        ReDim MyRSTNewWord.mnRSTAlarmWord(RST_ALARM_WORD_LEN)
        ReDim MyRSTOldWord.mnRSTAlarmWord(RST_ALARM_WORD_LEN)

        ReDim MyRSTNewWord.mnRobotAlarmWord(ROBOT_ALARM_WORD_LEN)
        ReDim MyRSTOldWord.mnRobotAlarmWord(ROBOT_ALARM_WORD_LEN)

        ReDim MyRSTNewWord.mnRSTAlarm(MAX_RST_ALARM_CODE)
        ReDim MyRSTOldWord.mnRSTAlarm(MAX_RST_ALARM_CODE)

        ReDim MyRSTNewWord.mnRobotAlarm(MAX_ROBOT_ALARM_CODE)
        ReDim MyRSTOldWord.mnRobotAlarm(MAX_ROBOT_ALARM_CODE)

        ReDim MyRSTNewWord.mstrEQWithGXID(MAX_EQ)
        ReDim MyRSTOldWord.mstrEQWithGXID(MAX_EQ)

        ReDim MyRSTNewWord.mnEQWithGlassID(MAX_EQ)
        ReDim MyRSTOldWord.mnEQWithGlassID(MAX_EQ)

        ReDim MyRSTMAddr.mnRSTEQIgnoreTimeout(MAX_EQ)
        'ReDim MyRSTMAddr.mnRSTEQArmMode(MAX_EQ)
        ReDim MyRSTMAddr.mnRSTEQTransferMode(MAX_EQ)
        ReDim MyRSTMAddr.mnManualSampleGlass(MAX_EQ)

        ReDim MyRSTMAddr.mnGxFlowInAck(MAX_PORTS, MAX_SLOTS)
        ReDim MyRSTMAddr.mnGxFlowOutAck(MAX_PORTS, MAX_SLOTS)
        '------------------------------------------------------------------------------

        ReDim MyRSTNewWord.mnBufferPortGxExist(MAX_BUFFER_PORT, MAX_BUFFER_SLOT)
        ReDim MyRSTOldWord.mnBufferPortGxExist(MAX_BUFFER_PORT, MAX_BUFFER_SLOT)

        ReDim MyRSTNewWord.mnBufferDisable(3, MAX_BUFFER_SLOT)
        ReDim MyRSTOldWord.mnBufferDisable(3, MAX_BUFFER_SLOT)

        ReDim MyRSTNewWord.mnGxFlowIn(MAX_PORTS, MAX_SLOTS)
        ReDim MyRSTOldWord.mnGxFlowIn(MAX_PORTS, MAX_SLOTS)

        ReDim MyRSTNewWord.mnGxFlowOut(MAX_PORTS, MAX_SLOTS)
        ReDim MyRSTOldWord.mnGxFlowOut(MAX_PORTS, MAX_SLOTS)

        ReDim MyRSTNewWord.mnCSTGxExist(MAX_PORTS, MAX_SLOTS)

        ReDim MyRSTNewWord.mnCSTStatus(MAX_PORTS)
        ReDim MyRSTNewWord.mnCSTGxCount(MAX_PORTS)

    End Sub

    Public Sub GetRSTLinkMap()
        Dim nPort As Integer = 0
        Dim nSlot As Integer = 0

        Call ReDimRSTArraySize()
        MyRSTMAddr.mnRobotStart = eRST_M_ADDR.ROBOT_START
        MyRSTMAddr.mnRobotErrorReset = eRST_M_ADDR.ROBOT_ERROR_RESET
        MyRSTMAddr.mnSyncDateTime = eRST_M_ADDR.TIME_CALIBRATION
        MyRSTMAddr.mnCPCAlive = eRST_M_ADDR.CPC_ALIVE
        MyRSTMAddr.mnRobotPauseRequest = eRST_M_ADDR.ROBOT_PAUSE_REQUEST
        MyRSTMAddr.mnRobotResumeRequest = eRST_M_ADDR.ROBOT_RESUME_REQUEST
        MyRSTMAddr.mnRobotInterfaceCheck = eRST_M_ADDR.ROBOT_INTERFACE_CHECK
        MyRSTMAddr.mnRSTTowerR = eRST_M_ADDR.RST_TOWER_R
        MyRSTMAddr.mnRSTTowerY = eRST_M_ADDR.RST_TOWER_Y
        MyRSTMAddr.mnRSTTowerG = eRST_M_ADDR.RST_TOWER_G
        MyRSTMAddr.mnRSTTowerRBlink = eRST_M_ADDR.RST_TOWER_R_BLINK
        MyRSTMAddr.mnRSTTowerYBlink = eRST_M_ADDR.RST_TOWER_Y_BLINK
        MyRSTMAddr.mnRSTTowerGBlink = eRST_M_ADDR.RST_TOWER_G_BLINK
        MyRSTMAddr.mnRSTBuzzer1 = eRST_M_ADDR.RST_BUZZER1
        MyRSTMAddr.mnRSTBuzzer2 = eRST_M_ADDR.RST_BUZZER2
        MyRSTMAddr.mnRSTBufferGlassEraseRequest = eRST_M_ADDR.RST_BUF_GX_ERASE_REQ
        MyRSTMAddr.mnRSTUpperArmGlassErase = eRST_M_ADDR.RST_UPPER_ARM_GX_ERASE
        MyRSTMAddr.mnRSTLowerArmGlassErase = eRST_M_ADDR.RST_LOWER_ARM_GX_ERASE

        MyRSTMAddr.mnRSTEQIgnoreTimeout(1) = eRST_M_ADDR.EQ1_IGNORE_TIMEOUT
        MyRSTMAddr.mnRSTEQIgnoreTimeout(2) = eRST_M_ADDR.EQ2_IGNORE_TIMEOUT
        MyRSTMAddr.mnRSTEQIgnoreTimeout(3) = eRST_M_ADDR.EQ3_IGNORE_TIMEOUT

        MyRSTMAddr.mnManualSampleGlass(1) = eRST_M_ADDR.EQ1_MANUAL_SAMPLE_GX
        MyRSTMAddr.mnManualSampleGlass(2) = eRST_M_ADDR.EQ2_MANUAL_SAMPLE_GX
        MyRSTMAddr.mnManualSampleGlass(3) = eRST_M_ADDR.EQ3_MANUAL_SAMPLE_GX

        MyRSTMAddr.mnRSTEQTransferMode(1) = eRST_M_ADDR.EQ1_TRANSFER_MODE
        MyRSTMAddr.mnRSTEQTransferMode(2) = eRST_M_ADDR.EQ2_TRANSFER_MODE
        MyRSTMAddr.mnRSTEQTransferMode(3) = eRST_M_ADDR.EQ3_TRANSFER_MODE

        MyRSTMAddr.mnRSTRunningMode = eRST_M_ADDR.RST_RUNNING_MODE

        MyRSTMAddr.mnRobotModeManual = eRST_M_ADDR.RSTMODE_MANUAL
        MyRSTMAddr.mnRobotModeAuto = eRST_M_ADDR.RSTMODE_AUTO
        MyRSTMAddr.mnRobotModeEng = eRST_M_ADDR.RSTMODE_ENGINEER
        MyRSTMAddr.mnRobotInit = eRST_M_ADDR.RSTMODE_INIT
        MyRSTMAddr.mnRobotStop = eRST_M_ADDR.RSTMODE_STOP
        MyRSTMAddr.mnRobotPM = eRST_M_ADDR.RSTMODE_PM
        MyRSTMAddr.mnRSTStart = eRST_M_ADDR.RSTMODE_START
        MyRSTMAddr.mnRobotDioTestMode = eRST_M_ADDR.RSTDIO_TESTMODE
        MyRSTMAddr.mnRSTGlassModify = eRST_M_ADDR.RST_GLASS_MODIFY
        MyRSTMAddr.mnRobotStandBy = eRST_M_ADDR.RST_STANDBY
        MyRSTMAddr.mnRobotResetInOutBit = eRST_M_ADDR.RST_RESET_FOLW_IN_OUT_BIT

        For nPort = 1 To MAX_PORTS
            For nSlot = 1 To MAX_SLOTS
                Select Case nPort
                    Case 1
                        MyRSTMAddr.mnGxFlowInAck(nPort, nSlot) = eRST_M_ADDR.RST_GX_FLOW_IN_PORT1 + (nSlot - 1)
                        MyRSTMAddr.mnGxFlowOutAck(nPort, nSlot) = eRST_M_ADDR.RST_GX_FLOW_OUT_PORT1 + (nSlot - 1)
                    Case 2
                        MyRSTMAddr.mnGxFlowInAck(nPort, nSlot) = eRST_M_ADDR.RST_GX_FLOW_IN_PORT2 + (nSlot - 1)
                        MyRSTMAddr.mnGxFlowOutAck(nPort, nSlot) = eRST_M_ADDR.RST_GX_FLOW_OUT_PORT2 + (nSlot - 1)
                    Case 3
                        MyRSTMAddr.mnGxFlowInAck(nPort, nSlot) = eRST_M_ADDR.RST_GX_FLOW_IN_PORT3 + (nSlot - 1)
                        MyRSTMAddr.mnGxFlowOutAck(nPort, nSlot) = eRST_M_ADDR.RST_GX_FLOW_OUT_PORT3 + (nSlot - 1)
                End Select
            Next
        Next

        MyRSTMAddr.mnBufferDisable1 = eRST_M_ADDR.RST_BUFFER_DISABLE1
        MyRSTMAddr.mnBufferDisable2 = eRST_M_ADDR.RST_BUFFER_DISABLE2
        MyRSTMAddr.mnBufferDisable3 = eRST_M_ADDR.RST_BUFFER_DISABLE3

        '---------------------------------------------------------------------------

        MyRSTZRAddr.RobotCmdToGo = eRST_ZR_ADDR.ROBOT_CMD_GO
        MyRSTZRAddr.RobotCmdArm = eRST_ZR_ADDR.ROBOT_CMD_ARM
        MyRSTZRAddr.RobotCmdAction = eRST_ZR_ADDR.ROBOT_CMD_ACTION
        MyRSTZRAddr.RoborPosition = eRST_ZR_ADDR.ROBOT_CMD_POSITION
        MyRSTZRAddr.RobotCmdSlotInfo = eRST_ZR_ADDR.ROBOT_CMD_SLOT_INFO
        MyRSTZRAddr.RobotCmdGlassType = eRST_ZR_ADDR.ROBOT_CMD_GLASS_TYPE
        MyRSTZRAddr.RobotSpeed = eRST_ZR_ADDR.ROBOT_CMD_SPEED

        MyRSTZRAddr.RobotYear = eRST_ZR_ADDR.TIME_YEAR
        MyRSTZRAddr.RobotMonth = eRST_ZR_ADDR.TIME_MONTH
        MyRSTZRAddr.RobotDay = eRST_ZR_ADDR.TIME_DAY
        MyRSTZRAddr.RobotHour = eRST_ZR_ADDR.TIME_HOUR
        MyRSTZRAddr.RobotMinute = eRST_ZR_ADDR.TIME_MIN
        MyRSTZRAddr.RobotSeacond = eRST_ZR_ADDR.TIME_SEC
        MyRSTZRAddr.RobotWeek = eRST_ZR_ADDR.TIME_WEEK

        MyRSTZRAddr.RobotEraseBufPosition = eRST_ZR_ADDR.RST_ERASE_BUF_POSITION
        MyRSTZRAddr.RobotEraseBufSlot = eRST_ZR_ADDR.RST_ERASE_BUF_SLOT

        MyRSTZRAddr.RobotRunningMode = eRST_ZR_ADDR.RST_RUNNING_MODE
        MyRSTZRAddr.RobotRemoteStatus = eRST_ZR_ADDR.RST_REMOTE_STATUS
        MyRSTZRAddr.RobotEQArmMode = eRST_ZR_ADDR.RST_ARM_MODE
        MyRSTZRAddr.RobotColorRepairRunMode = eRST_ZR_ADDR.RST_COLOR_REPAIR_RUN_MODE

        MyRSTZRAddr.RobotSampleGxHour1 = eRST_ZR_ADDR.TIME1_SAMPLE_GX_HH
        MyRSTZRAddr.RobotSampleGxMinute1 = eRST_ZR_ADDR.TIME1_SAMPLE_GX_MM

        MyRSTZRAddr.RobotSampleGxHour2 = eRST_ZR_ADDR.TIME2_SAMPLE_GX_HH
        MyRSTZRAddr.RobotSampleGxMinute2 = eRST_ZR_ADDR.TIME2_SAMPLE_GX_MM

        MyRSTZRAddr.RobotSampleGxHour3 = eRST_ZR_ADDR.TIME3_SAMPLE_GX_HH
        MyRSTZRAddr.RobotSampleGxMinute3 = eRST_ZR_ADDR.TIME3_SAMPLE_GX_MM

        MyRSTZRAddr.RobotSampleGxHour4 = eRST_ZR_ADDR.TIME4_SAMPLE_GX_HH
        MyRSTZRAddr.RobotSampleGxMinute4 = eRST_ZR_ADDR.TIME4_SAMPLE_GX_MM

        MyRSTZRAddr.EQ1SampleGxWeek = eRST_ZR_ADDR.SAMPLE_GX_EQ1_DAY
        MyRSTZRAddr.EQ2SampleGxWeek = eRST_ZR_ADDR.SAMPLE_GX_EQ2_DAY

        MyRSTZRAddr.RobotInterfaceLogCount = eRST_ZR_ADDR.RST_RESET_INTERFACE_LOG_COUNT
        MyRSTZRAddr.RobotTimeoutCount = eRST_ZR_ADDR.RST_TIMEOUT_COUNT
        MyRSTZRAddr.RobotResetTracedataLogCount = eRST_ZR_ADDR.RST_TRACEDATA_LOG_COUNT
    End Sub

    Public Sub ScanRSTZRWordAddr()
        Dim nFor As Integer
        Dim anReadRSTWordData(MAX_RST_ARRAY_LEN) As Integer

        Call ReadZRAddr(RST_ADDR, anReadRSTWordData)

        For nFor = 0 To MAX_RST_ARRAY_LEN
            g_anRST_New_ZRWord(nFor) = anReadRSTWordData(nFor)
        Next


        Call ScanRobotStatusBitArray()

        Call ScanCVLinkStatus()
        Call ScanEQLinkStatus()


        'Call ScanEQWithGlassID()

        Call ScanArmGlassExist()

        ScanGlassFlowIn()
        ScanGlassFlowOut()

        Scan167PortStatus()

        Call ScanBufferData1()
        Call ScanBufferData2()
        Call ScanBufferData3()
        Call ScanBufferData4()
        Call ScanBufferData5()
        Call ScanBufferData6()
        Call ScanBufferData7()

        Call ScanBufferDisable1()
        Call ScanBufferDisable2()
        Call ScanBufferDisable3()
        Call ScanBufferDisable4()
        Call ScanBufferDisable5()

        Call ScanRSTStauts()

        Call ScanRSTAlarm()
        Call ScanRobotAlarm()

        Call ScanRSTInterfaceLogCount()

        Call ScanCPCTimeoutLogCount()

        Call ScanRobotActualStatus()
    End Sub


#Region "EQ Function"

    Public Function ReadEQToolID(ByVal nEQIndex As Integer) As String
        Dim nFor As Integer
        Dim strEQToolID As String = ""

        Select Case nEQIndex
            Case 1
                For nFor = eEQDevicNo.EQ1_TOOL_ID_W1 To eEQDevicNo.EQ1_TOOL_ID_W6
                    strEQToolID = strEQToolID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
                Next
            Case 2
                For nFor = eEQDevicNo.EQ2_TOOL_ID_W1 To eEQDevicNo.EQ2_TOOL_ID_W6
                    strEQToolID = strEQToolID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
                Next
            Case 3
                For nFor = eEQDevicNo.EQ3_TOOL_ID_W1 To eEQDevicNo.EQ3_TOOL_ID_W6
                    strEQToolID = strEQToolID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
                Next
        End Select

        ReadEQToolID = strEQToolID
    End Function

    Public Sub ReadEQinformationReport1(ByRef nSampleGX As Integer, ByRef nProductCategory As Integer, ByRef nSlotNo As Integer, ByRef strGXID As String, ByRef strEPPID As String, ByRef strMESID As String, ByRef strProductCode As String, ByRef strCurrPPID As String, ByRef strPOPERID As String)
        Dim nFor As Integer

        nSampleGX = g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_AMPLE_GX_FLAG)
        nProductCategory = g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_PRODUCT_CATEGORY)
        nSlotNo = g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_SLOT_NO)

        For nFor = eEQDevicNo.EQ_INFO_REPORT_GX_ID_WORD1 To eEQDevicNo.EQ_INFO_REPORT_GX_ID_WORD6
            strGXID = strGXID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_EPPID1 To eEQDevicNo.EQ_INFO_REPORT_EPPID2
            strEPPID = strEPPID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_MESID_WORD1 To eEQDevicNo.EQ_INFO_REPORT_MESID_WORD4
            strMESID = strMESID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_PRODUCT_CODE_W1 To eEQDevicNo.EQ_INFO_REPORT_PRODUCT_CODE_W13
            strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_CURR_PPID_W1 To eEQDevicNo.EQ_INFO_REPORT_CURR_PPID_W16
            strCurrPPID = strCurrPPID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_POPERID_W1 To eEQDevicNo.EQ_INFO_REPORT_POPERID_W13
            strPOPERID = strPOPERID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next
    End Sub

    Public Sub ReadEQinformationReport2(ByRef strPLINEID As String, ByRef strPTOOLID As String, ByRef strCSTID As String, ByRef strOPID As String, ByRef strGlassGrade As String, ByRef strDMQCgrade As String, ByRef strGlassScrapFlag As String, ByRef nAOIfuctionmode As Integer, ByRef nMPAflag As Integer)
        Dim nFor As Integer

        For nFor = eEQDevicNo.EQ_INFO_REPORT_PLINEID_W1 To eEQDevicNo.EQ_INFO_REPORT_PLINEID_W4
            strPLINEID = strPLINEID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_PTOOLID_W1 To eEQDevicNo.EQ_INFO_REPORT_PTOOLID_W4
            strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_CST_ID_W1 To eEQDevicNo.EQ_INFO_REPORT_CST_ID_W3
            strCSTID = strCSTID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        For nFor = eEQDevicNo.EQ_INFO_REPORT_OP_ID_W1 To eEQDevicNo.EQ_INFO_REPORT_OP_ID_W13
            strOPID = strOPID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
        Next

        strGlassGrade = ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_GX_GRADE))
        strDMQCgrade = ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_DMQC_GRADE))
        strGlassScrapFlag = ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_GX_SCRAP_FLAG))
        nAOIfuctionmode = g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_AIO_FUN_MODE)
        nMPAflag = g_anRST_New_ZRWord(eEQDevicNo.EQ_INFO_REPORT_MPA_FLAG)
    End Sub

    Public Function ReadEQGlassID(ByVal nEQIndex As Integer) As String
        Dim nFor As Integer
        Dim strGlassID As String = ""

        Select Case nEQIndex
            Case 1
                For nFor = eRSTDevicNo.RST_EQ1_WITH_GX_W1 To eRSTDevicNo.RST_EQ1_WITH_GX_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
                Next
            Case 2
                For nFor = eRSTDevicNo.RST_EQ2_WITH_GX_W1 To eRSTDevicNo.RST_EQ2_WITH_GX_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
                Next
            Case 3
                For nFor = eRSTDevicNo.RST_EQ3_WITH_GX_W1 To eRSTDevicNo.RST_EQ3_WITH_GX_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
                Next
        End Select
        ReadEQGlassID = strGlassID
    End Function

    'Private Sub ScanEQWithGlassID()
    '    Dim nFor As Integer
    '    Dim strEQGlassID(3) As String

    '    For nFor = eRSTDevicNo.RST_EQ1_WITH_GX_W1 To eRSTDevicNo.RST_EQ1_WITH_GX_W6
    '        strEQGlassID(1) = strEQGlassID(1) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
    '    Next
    '    MyRSTNewWord.mstrEQWithGXID(1) = strEQGlassID(1)

    '    For nFor = eRSTDevicNo.RST_EQ2_WITH_GX_W1 To eRSTDevicNo.RST_EQ2_WITH_GX_W6
    '        strEQGlassID(2) = strEQGlassID(2) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
    '    Next
    '    MyRSTNewWord.mstrEQWithGXID(2) = strEQGlassID(2)

    '    For nFor = eRSTDevicNo.RST_EQ3_WITH_GX_W1 To eRSTDevicNo.RST_EQ3_WITH_GX_W6
    '        strEQGlassID(3) = strEQGlassID(3) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
    '    Next
    '    MyRSTNewWord.mstrEQWithGXID(3) = strEQGlassID(3)

    'End Sub

#End Region

#Region "CV Function"

    Public Function ReadFlowInQty(ByVal nPortNo As Integer) As Integer
        Select Case nPortNo
            Case 1
                ReadFlowInQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_FLOW_IN_QTY_P1)
            Case 2
                ReadFlowInQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_FLOW_IN_QTY_P2)
            Case 3
                ReadFlowInQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_FLOW_IN_QTY_P3)
        End Select
    End Function

    Public Function ReadFlowOutQty(ByVal nPortNo As Integer) As Integer
        Select Case nPortNo
            Case 1
                ReadFlowOutQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_FLOW_OUT_QTY_P1)
            Case 2
                ReadFlowOutQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_FLOW_OUT_QTY_P2)
            Case 3
                ReadFlowOutQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_FLOW_OUT_QTY_P3)
        End Select
    End Function

    Public Function ReadProcessStartQty(ByVal nPortNo As Integer) As Integer
        Select Case nPortNo
            Case 1
                ReadProcessStartQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_PROCESS_STRAT_QTY_P1)
            Case 2
                ReadProcessStartQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_PROCESS_STRAT_QTY_P2)
            Case 3
                ReadProcessStartQty = g_anRST_New_ZRWord(eRSTDevicNo.RST_PROCESS_STRAT_QTY_P3)
        End Select
    End Function

#End Region

#Region "RST Function"
    Public Function ReadRobotMileageInfo() As Integer()
        Dim anMileage(6) As Integer

        anMileage(1) = g_anRST_New_ZRWord(eRSTDevicNo.RST_AXLE1)
        anMileage(2) = g_anRST_New_ZRWord(eRSTDevicNo.RST_AXLE2)
        anMileage(3) = g_anRST_New_ZRWord(eRSTDevicNo.RST_AXLE3)
        anMileage(4) = g_anRST_New_ZRWord(eRSTDevicNo.RST_AXLE4)
        anMileage(5) = g_anRST_New_ZRWord(eRSTDevicNo.RST_AXLE5)
        anMileage(6) = g_anRST_New_ZRWord(eRSTDevicNo.RST_AXLE6)
        Return anMileage
    End Function

    Public Sub ReadRobotActionCommand()
        MyRSTNewWord.mnRSTStartArm = g_anRST_New_ZRWord(eRSTDevicNo.RST_STRAT_ARM)
        MyRSTNewWord.mnRSTStartPosition = g_anRST_New_ZRWord(eRSTDevicNo.RST_STRAT_POSITION)
        MyRSTNewWord.mnRSTStartSlot = g_anRST_New_ZRWord(eRSTDevicNo.RST_STRAT_SLOT)
        MyRSTNewWord.mnRSTStartTarget = g_anRST_New_ZRWord(eRSTDevicNo.RST_STRAT_TARGET)
        MyRSTNewWord.mnRSTStartCMD = g_anRST_New_ZRWord(eRSTDevicNo.RST_STRAT_CMD)
        MyRSTNewWord.mnRSTStartAction = g_anRST_New_ZRWord(eRSTDevicNo.RST_STRAT_ACTION)
        MyRSTNewWord.mnRSTStartHandshake = g_anRST_New_ZRWord(eRSTDevicNo.RST_STRAT_HANDSHAKE)
    End Sub

    Public Sub ReadRobotCommandError()
        MyRSTNewWord.mnRSTArm = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_ARM)
        MyRSTNewWord.mnPosition = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_POSITION)
        MyRSTNewWord.mnSlotNo = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_SLOT)
        MyRSTNewWord.mnRSTErrorCase = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_CASE)
        MyRSTNewWord.mnTarget = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_TARGET)
        MyRSTNewWord.mnJobNo = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_JOB)
        MyRSTNewWord.mnCMD = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_CMD)
        MyRSTNewWord.mnAction = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_ACTION)
        MyRSTNewWord.mnHandshake = g_anRST_New_ZRWord(eRSTDevicNo.RST_COMMAND_ERR_HANDSHAKE)
    End Sub

    Public Function GetArmGxInfo(ByVal nArm As clsPLC.eRSTArm) As String
        Dim nFor As Integer
        Dim strGlassID As String = ""

        If nArm = clsPLC.eRSTArm.ARM_UPPER Then
            For nFor = eRSTDevicNo.RST_UPPER_ARM_GXINFO1 To eRSTDevicNo.RST_UPPER_ARM_GXINFO6
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
            Next
        ElseIf nArm = clsPLC.eRSTArm.ARM_LOWER Then
            For nFor = eRSTDevicNo.RST_LOWER_ARM_GXINFO1 To eRSTDevicNo.RST_LOWER_ARM_GXINFO6
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(nFor))
            Next
        End If
        GetArmGxInfo = strGlassID
    End Function

#End Region

#Region "Timer Scan Addr Data Function"

    Private Sub Scan167PortStatus()
        MyRSTNewWord.mnCSTStatus(1) = g_anRST_New_ZRWord(eRSTDevicNo.RST_167_STATUS_P1)
        MyRSTNewWord.mnCSTStatus(2) = g_anRST_New_ZRWord(eRSTDevicNo.RST_167_STATUS_P2)
        MyRSTNewWord.mnCSTStatus(3) = g_anRST_New_ZRWord(eRSTDevicNo.RST_167_STATUS_P3)

        MyRSTNewWord.mnCSTGxCount(1) = g_anRST_New_ZRWord(eRSTDevicNo.RST_167_GX_COUNT_P1)
        MyRSTNewWord.mnCSTGxCount(2) = g_anRST_New_ZRWord(eRSTDevicNo.RST_167_GX_COUNT_P2)
        MyRSTNewWord.mnCSTGxCount(3) = g_anRST_New_ZRWord(eRSTDevicNo.RST_167_GX_COUNT_P3)

        ScanCSTGxExist1()
        ScanCSTGxExist2()
        ScanCSTGxExist3()
        ScanCSTGxExist4()
        ScanCSTGxExist5()
        ScanCSTGxExist6()
        ScanCSTGxExist7()
        ScanCSTGxExist8()
        ScanCSTGxExist9()
        ScanCSTGxExist10()
        ScanCSTGxExist11()
        ScanCSTGxExist12()
    End Sub


    Private Sub ScanCSTGxExist1()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P1_1), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO1, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist2()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P1_2), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO1, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist3()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P1_3), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO1, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist4()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P1_4), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO1, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO1, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub

    Private Sub ScanCSTGxExist5()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P2_1), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO2, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist6()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P2_2), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO2, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist7()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P2_3), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO2, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist8()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P2_4), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO2, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO2, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub

    Private Sub ScanCSTGxExist9()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P3_1), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO3, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist10()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P3_2), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO3, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist11()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P3_3), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO3, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCSTGxExist12()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_167_CST_GX_P3_4), aBit)

        MyRSTNewWord.mnCSTGxExist(PORTNO3, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnCSTGxExist(PORTNO3, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub


    Private Sub ScanEQLinkStatus()
        MyCVNewWord.mnEQLinkStatus(1) = g_anRST_New_ZRWord(eRSTDevicNo.EQ1_LINK_STATUS)
        MyCVNewWord.mnEQLinkStatus(2) = g_anRST_New_ZRWord(eRSTDevicNo.EQ2_LINK_STATUS)
        MyCVNewWord.mnEQLinkStatus(3) = g_anRST_New_ZRWord(eRSTDevicNo.EQ3_LINK_STATUS)
    End Sub

    Private Sub ScanCVLinkStatus()
        MyCVNewWord.mnCVLinkStatus(1) = g_anRST_New_ZRWord(eRSTDevicNo.CV1_LINK_STATUS)
        MyCVNewWord.mnCVLinkStatus(2) = g_anRST_New_ZRWord(eRSTDevicNo.CV2_LINK_STATUS)
    End Sub

    Private Sub ScanRobotActualStatus()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_ACTUAL_STATUS), aBit)

        MyRSTNewWord.mnUpArmSensor = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnLowArmSensor = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnUpArmVaccum = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnLowArmVaccum = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnRSTServoOn = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnRSTReady = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnCMDBusy = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnForkExtend = Val(Mid(strBinaryData, 9, 1))

    End Sub

    Private Sub ScanCPCTimeoutLogCount()
        MyRSTNewWord.mnCheckTimeoutFun = g_anRST_New_ZRWord(eRSTDevicNo.CPC_TIMEOUT_COUNT)
    End Sub

    Private Sub ScanGlassFlowIn()
        ScanGxFlowIn1()
        ScanGxFlowIn2()
        ScanGxFlowIn3()
        ScanGxFlowIn4()
        ScanGxFlowIn5()
        ScanGxFlowIn6()
        ScanGxFlowIn7()
        ScanGxFlowIn8()
        ScanGxFlowIn9()
        ScanGxFlowIn10()
        ScanGxFlowIn11()
        ScanGxFlowIn12()
    End Sub

    Private Sub ScanGlassFlowOut()
        ScanGxFlowOut1()
        ScanGxFlowOut2()
        ScanGxFlowOut3()
        ScanGxFlowOut4()
        ScanGxFlowOut5()
        ScanGxFlowOut6()
        ScanGxFlowOut7()
        ScanGxFlowOut8()
        ScanGxFlowOut9()
        ScanGxFlowOut10()
        ScanGxFlowOut11()
        ScanGxFlowOut12()
    End Sub

    Private Sub ScanGxFlowOut1()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT1), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO1, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut2()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT2), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO1, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut3()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT3), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO1, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut4()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT4), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO1, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO1, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub

    Private Sub ScanGxFlowOut5()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT5), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO2, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut6()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT6), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO2, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut7()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT7), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO2, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut8()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT8), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO2, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO2, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub

    Private Sub ScanGxFlowOut9()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT9), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO3, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut10()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT10), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO3, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut11()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT11), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO3, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowOut12()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_OUT12), aBit)

        MyRSTNewWord.mnGxFlowOut(PORTNO3, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowOut(PORTNO3, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub

    '-----------------------------------------------------------------------------


    Private Sub ScanGxFlowIn1()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN1), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO1, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn2()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN2), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO1, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn3()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN3), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO1, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn4()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN4), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO1, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO1, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub

    Private Sub ScanGxFlowIn5()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN5), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO2, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn6()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN6), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO2, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn7()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN7), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO2, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn8()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN8), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO2, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO2, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub

    Private Sub ScanGxFlowIn9()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN9), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO3, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn10()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN10), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO3, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 26) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 27) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 28) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 29) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 30) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 31) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 32) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn11()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN11), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO3, 33) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 34) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 35) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 36) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 37) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 38) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 39) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 40) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 41) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 42) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 43) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 44) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 45) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 46) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 47) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 48) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanGxFlowIn12()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_GX_FLOW_IN12), aBit)

        MyRSTNewWord.mnGxFlowIn(PORTNO3, 49) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 50) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 51) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 52) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 53) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 54) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 55) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnGxFlowIn(PORTNO3, 56) = Val(Mid(strBinaryData, 9, 1))
    End Sub


    Private Sub ScanBufferDisable1()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_DISABLE1), aBit)

        MyRSTNewWord.mnBufferDisable(PORTNO1, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 16) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferDisable2()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_DISABLE2), aBit)

        MyRSTNewWord.mnBufferDisable(PORTNO1, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO1, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 1) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 2) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 3) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 4) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 5) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 6) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 7) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferDisable3()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_DISABLE3), aBit)

        MyRSTNewWord.mnBufferDisable(PORTNO2, 8) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 9) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 10) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 11) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 12) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 13) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 14) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 15) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 16) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 17) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 18) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 19) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 20) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 21) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 22) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 23) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferDisable4()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_DISABLE4), aBit)

        MyRSTNewWord.mnBufferDisable(PORTNO2, 24) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO2, 25) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 1) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 2) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 3) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 4) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 5) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 6) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 7) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 8) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 9) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 10) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 11) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 12) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 13) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 14) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferDisable5()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_DISABLE5), aBit)

        MyRSTNewWord.mnBufferDisable(PORTNO3, 15) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 16) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 17) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 18) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 19) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 20) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 21) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 22) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 23) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 24) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferDisable(PORTNO3, 25) = Val(Mid(strBinaryData, 6, 1))

    End Sub

    Private Sub ScanRSTStauts()
        MyRSTNewWord.mnRobotStatus = g_anRST_New_ZRWord(eRSTDevicNo.ROBOT_STATUS)
    End Sub

    Private Sub ScanRSTInterfaceLogCount()
        MyRSTNewWord.mnRobotInterfaceLogCount = g_anRST_New_ZRWord(eRSTDevicNo.RST_INTERFACE_LOG_COUNT)
    End Sub

    Private Sub ScanRSTTraceDataLogCount()
        MyRSTNewWord.mnRobotTraceDataCount = g_anRST_New_ZRWord(eRSTDevicNo.RST_TRACE_DATA_LOG_COUNT)
    End Sub

    Private Sub ScanRSTAlarm()
        Dim nFor As Integer
        Dim nIndex As Integer

        For nFor = eRSTDevicNo.RST_ALARM_WORD1 To eRSTDevicNo.RST_ALARM_WORD19
            nIndex = nIndex + 1
            MyRSTNewWord.mnRSTAlarmWord(nIndex) = g_anRST_New_ZRWord(nFor)
        Next
    End Sub

    Private Sub ScanRobotAlarm()
        Dim nFor As Integer
        Dim nIndex As Integer

        For nFor = 39 To 41
            nIndex = nIndex + 1
            MyRSTNewWord.mnRobotAlarmWord(nIndex) = g_anRST_New_ZRWord(nFor)
        Next
    End Sub

    Private Sub ScanRobotStatusBitArray()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.ROBOT_STATUS_BIT_ARRAY1), aBit)

        MyRSTNewWord.mnRobotcommandPossible = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnRobotCommandAck = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnRobotManualComplete = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnAutomode = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnManualmode = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnEngineerMode = Val(Mid(strBinaryData, 11, 1))

        MyRSTNewWord.mnRobotPauseAck = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnRobotResumeAck = Val(Mid(strBinaryData, 9, 1))

        MyRSTNewWord.mnRobotStart = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnRobotStartComplete = Val(Mid(strBinaryData, 6, 1))

        MyRSTNewWord.mnRobotStartCommand = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnRobotInitialRequest = Val(Mid(strBinaryData, 4, 1))

        MyRSTNewWord.mnRobotStandBy = Val(Mid(strBinaryData, 3, 1))

        MyRSTNewWord.mnRobotCommandErrorLog = Val(Mid(strBinaryData, 2, 1))

        MyRSTNewWord.mnRSTAlive = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferData1()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_GX_EXIST1), aBit)

        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 1) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 2) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 3) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 4) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 5) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 6) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 7) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 8) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 9) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 10) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 11) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 12) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 13) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 14) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 15) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 16) = Val(Mid(strBinaryData, 1, 1))

    End Sub

    Private Sub ScanBufferData2()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_GX_EXIST2), aBit)

        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 17) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 18) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 19) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 20) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 21) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 22) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 23) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 24) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO1, 25) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 1) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 2) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 3) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 4) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 5) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 6) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 7) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferData3()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_GX_EXIST3), aBit)

        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 8) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 9) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 10) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 11) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 12) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 13) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 14) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 15) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 16) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 17) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 18) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 19) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 20) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 21) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 22) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 23) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferData4()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_GX_EXIST4), aBit)

        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 24) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO2, 25) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 1) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 2) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 3) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 4) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 5) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 6) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 7) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 8) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 9) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 10) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 11) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 12) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 13) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 14) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferData5()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_GX_EXIST5), aBit)

        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 15) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 16) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 17) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 18) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 19) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 20) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 21) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 22) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 23) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 24) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO3, 25) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 1) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 2) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 3) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 4) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 5) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferData6()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_GX_EXIST6), aBit)

        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 6) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 7) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 8) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 9) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 10) = Val(Mid(strBinaryData, 12, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 11) = Val(Mid(strBinaryData, 11, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 12) = Val(Mid(strBinaryData, 10, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 13) = Val(Mid(strBinaryData, 9, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 14) = Val(Mid(strBinaryData, 8, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 15) = Val(Mid(strBinaryData, 7, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 16) = Val(Mid(strBinaryData, 6, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 17) = Val(Mid(strBinaryData, 5, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 18) = Val(Mid(strBinaryData, 4, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 19) = Val(Mid(strBinaryData, 3, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 20) = Val(Mid(strBinaryData, 2, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 21) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanBufferData7()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_BUFFER_GX_EXIST7), aBit)

        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 22) = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 23) = Val(Mid(strBinaryData, 15, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 24) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnBufferPortGxExist(PORTNO4, 25) = Val(Mid(strBinaryData, 13, 1))
    End Sub

    Private Sub ScanArmGlassExist()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eRSTDevicNo.RST_ARM_GX_EXIST), aBit)

        MyRSTNewWord.mnArmUpperGlassExist = Val(Mid(strBinaryData, 16, 1))
        MyRSTNewWord.mnArmLowerGlassExist = Val(Mid(strBinaryData, 15, 1))

        MyRSTNewWord.mnEQWithGlassID(1) = Val(Mid(strBinaryData, 14, 1))
        MyRSTNewWord.mnEQWithGlassID(2) = Val(Mid(strBinaryData, 13, 1))
        MyRSTNewWord.mnEQWithGlassID(3) = Val(Mid(strBinaryData, 12, 1))
    End Sub

#End Region

#Region "Get RST Data Function"

    Public Function GetRobotMode() As clsPLC.eRSTMode
        If MyRSTNewWord.mnAutomode = SIGNAL_ON Then
            GetRobotMode = clsPLC.eRSTMode.AUTO
        ElseIf MyRSTNewWord.mnManualmode = SIGNAL_ON Then
            GetRobotMode = clsPLC.eRSTMode.MANUAL
        ElseIf MyRSTNewWord.mnEngineerMode = SIGNAL_ON Then
            GetRobotMode = clsPLC.eRSTMode.ENGINEER
        Else
            GetRobotMode = clsPLC.eRSTMode.NA
        End If
    End Function

    Public Function GetRobotStartcommand() As Integer
        GetRobotStartcommand = MyRSTNewWord.mnRobotStartCommand
    End Function

    Public Function GetRobotInitialRequest() As Integer
        GetRobotInitialRequest = MyRSTNewWord.mnRobotInitialRequest
    End Function

#End Region

#Region "Read PLC Log"
    Private Sub ScanTraceFUNLog()
        Dim nFor As Integer = 0
        Dim anReadTraceDataFunLog(TRACEDATA_LEN) As Integer

        Call ReadZRAddr(TRACEDATA_LOG_ADDR, anReadTraceDataFunLog)

        For nFor = 0 To TRACEDATA_LEN
            m_anWriteTraceData(nFor) = anReadTraceDataFunLog(nFor)
        Next

    End Sub

    Public Sub WriteTraceDataFunLog(ByVal nCount As Integer)
        Dim nAppendAddr As Integer = 10
        Dim nFor As Integer = 0
        Dim nNumber As Integer = 0
        Dim i As Integer = 0
        Dim nDeviceAddress As Integer = 0
        Dim strDataTime1 As String = ""
        Dim strDataTime2 As String = ""
        Dim strDataTime3 As String = ""
        Dim strTime As String = ""

        Dim nSerialNo As Integer = 0
        Dim nOnOff As Integer = 0

        If nCount > 20 Then Exit Sub

        'Read ZR55200
        Call ScanTraceFUNLog()

        For nFor = 1 To nCount
            nNumber = i * nAppendAddr

            nDeviceAddress = m_anWriteTraceData(1 + nNumber)
            nSerialNo = ReadTraceInformation(m_anWriteTraceData(2 + nNumber))
            nOnOff = ReadTraceSignal(m_anWriteTraceData(2 + nNumber))

            strDataTime1 = ReadDataTime1(m_anWriteTraceData(3 + nNumber))
            strDataTime2 = ReadDataTime2(m_anWriteTraceData(4 + nNumber))
            strDataTime3 = ReadDataTime3(m_anWriteTraceData(5 + nNumber))

            strTime = strDataTime1 & strDataTime2 & strDataTime3

            WriteTaceDataPLCLog(strTime, nDeviceAddress, nSerialNo, nOnOff)
            i = i + 1
        Next
    End Sub

    Private Function ReadTraceInformation(ByVal nValue) As Integer
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)
        Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        ReadTraceInformation = nGetLibyte
    End Function

    Private Function ReadTraceSignal(ByVal nValue) As Integer
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)
        Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        ReadTraceSignal = nGetHibyte
    End Function

    'ZR60500
    Private Sub ScanTimeoutFUNLog()
        Dim nFor As Integer = 0
        Dim anReadTimeoutFunLog(WRITE_TIMEOUT_FUN_LEN) As Integer

        Call ReadZRAddr(TIMEOUT_LOG_ADDR, anReadTimeoutFunLog)

        For nFor = 0 To WRITE_TIMEOUT_FUN_LEN
            m_anWriteTimeoutFunLog(nFor) = anReadTimeoutFunLog(nFor)
        Next

    End Sub

    Public Sub WriteTimeoutFunLog(ByVal nCount As Integer)
        Dim nAppendAddr As Integer = 10
        Dim nFor As Integer = 0
        Dim nNumber As Integer = 0
        Dim i As Integer = 0
        Dim nCode As Integer = 0
        Dim strDataTime1 As String = ""
        Dim strDataTime2 As String = ""
        Dim strDataTime3 As String = ""
        Dim strTime As String = ""
        Dim strTimeoutFunName As String = ""

        If nCount > 48 Then Exit Sub

        'Read ZR60500
        Call ScanTimeoutFUNLog()

        For nFor = 1 To nCount
            nNumber = i * nAppendAddr
            nCode = m_anWriteTimeoutFunLog(1 + nNumber)

            strTimeoutFunName = ReportTimeoutFunName(nCode)

            strDataTime1 = ReadDataTime1(m_anWriteTimeoutFunLog(3 + nNumber))
            strDataTime2 = ReadDataTime2(m_anWriteTimeoutFunLog(4 + nNumber))
            strDataTime3 = ReadDataTime3(m_anWriteTimeoutFunLog(5 + nNumber))

            strTime = strDataTime1 & strDataTime2 & strDataTime3

            'Debug.Print(nCode)
            WriteTimeoutPLCLog(strTimeoutFunName, strTime)
            i = i + 1
        Next
    End Sub

    'ZR59000
    Private Sub ScanLogData()
        Dim nFor As Integer
        Dim anReadRSTLogWordData(WRITE_LOG_LEN) As Integer

        Call ReadZRAddr(RST_LOG_ADDR, anReadRSTLogWordData)

        For nFor = 0 To WRITE_LOG_LEN
            g_anRST_ZRWriteLogWord(nFor) = anReadRSTLogWordData(nFor)
        Next
    End Sub

    Public Sub WriteInterfaceLogData(ByVal nCount As Integer)
        Dim nAddrBlock As Integer
        Dim nFor As Integer
        Dim nNumber As Integer
        Dim i As Integer
        Dim nIdx As Integer
        Dim nOnOff As Integer
        Dim nMachineCategory As Integer
        Dim nCommand As Integer
        Dim strDataTime1 As String = ""
        Dim strDataTime2 As String = ""
        Dim strDataTime3 As String = ""
        Dim strWriteTime As String = ""
        Dim strGlassID As String = ""
        Dim strGlassIDWord1 As String = ""
        Dim strGlassIDWord2 As String = ""
        Dim strGlassIDWord3 As String = ""
        Dim strGlassIDWord4 As String = ""
        Dim strGlassIDWord5 As String = ""
        Dim strGlassIDWord6 As String = ""

        If nCount > 40 Then Exit Sub

        Call ScanLogData()

        nAddrBlock = 20

        For nFor = 1 To nCount
            nIdx = nIdx + 1
            nNumber = i * nAddrBlock

            nOnOff = ReadSignalOnOff(g_anRST_ZRWriteLogWord(1 + nNumber))
            nMachineCategory = ReadMachineCategory(g_anRST_ZRWriteLogWord(1 + nNumber))
            nCommand = ReadCommand(g_anRST_ZRWriteLogWord(1 + nNumber))

            strDataTime1 = ReadDataTime1(g_anRST_ZRWriteLogWord(2 + nNumber))
            strDataTime2 = ReadDataTime2(g_anRST_ZRWriteLogWord(3 + nNumber))
            strDataTime3 = ReadDataTime3(g_anRST_ZRWriteLogWord(4 + nNumber))

            strWriteTime = strDataTime1 & strDataTime2 & strDataTime3
            'Debug.Print(strWriteTime)

            strGlassIDWord1 = ConvertHiLowASCIIToString(g_anRST_ZRWriteLogWord(5 + nNumber))
            strGlassIDWord2 = ConvertHiLowASCIIToString(g_anRST_ZRWriteLogWord(6 + nNumber))
            strGlassIDWord3 = ConvertHiLowASCIIToString(g_anRST_ZRWriteLogWord(7 + nNumber))
            strGlassIDWord4 = ConvertHiLowASCIIToString(g_anRST_ZRWriteLogWord(8 + nNumber))
            strGlassIDWord5 = ConvertHiLowASCIIToString(g_anRST_ZRWriteLogWord(9 + nNumber))
            strGlassIDWord6 = ConvertHiLowASCIIToString(g_anRST_ZRWriteLogWord(10 + nNumber))

            strGlassID = strGlassIDWord1 & strGlassIDWord2 & strGlassIDWord3 & strGlassIDWord4 & strGlassIDWord5 & strGlassIDWord6
            'Debug.Print(strGlassID)

            WritePLCLog(nMachineCategory, nCommand, nOnOff, strWriteTime, strGlassID)
            i = i + 1
        Next
    End Sub

    Private Function ReadDataTime3(ByVal nValue As Integer) As String
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)
        'Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        'ReadDataTime3 = ":" & Hex(nGetHibyte) & ":" & Hex(nGetLibyte)
        ReadDataTime3 = ":" & Left(strData, 2) & ":" & Right(strData, 2)
    End Function

    Private Function ReadDataTime2(ByVal nValue As Integer) As String
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)
        'Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        'ReadDataTime2 = "/" & Hex(nGetHibyte) & " " & Hex(nGetLibyte)

        ReadDataTime2 = "/" & Left(strData, 2) & " " & Right(strData, 2)
    End Function

    Private Function ReadDataTime1(ByVal nValue As Integer) As String
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)
        'Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        'ReadDataTime1 = Hex(nGetHibyte) & "/" & Hex(nGetLibyte)
        ReadDataTime1 = Left(strData, 2) & "/" & Right(strData, 2)
    End Function

    Private Function ReadCommand(ByVal nValue) As Integer
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)
        Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        ReadCommand = nGetLibyte
    End Function

    Private Function ReadSignalOnOff(ByVal nValue As Integer) As Integer
        Dim strHexData As String = ""
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0

        strHexData = HexLeadZero(nValue)
        Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)

        ReadSignalOnOff = nFourthWord
    End Function

    Private Function ReadMachineCategory(ByVal nValue As Integer) As Integer
        Dim strHexData As String = ""
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0

        strHexData = HexLeadZero(nValue)
        Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)

        ReadMachineCategory = nThirdWord
    End Function

#End Region

#Region "PLC Timeout Name"
    Private Function ReportTimeoutFunName(ByVal nCategory As Integer) As String
        Dim strTimeoutFunCategory As String = ""

        Select Case nCategory
            Case eTIMEOUT_ITEM.S167_DATA_UPLOAD_REQ_P1
                strTimeoutFunCategory = "Port1 S167 data Upload Request"
            Case eTIMEOUT_ITEM.S167_DATA_UPLOAD_REQ_P2
                strTimeoutFunCategory = "Port2 S167 data Upload Request"
            Case eTIMEOUT_ITEM.S167_DATA_UPLOAD_REQ_P3
                strTimeoutFunCategory = "Port3 S167 data Upload Request"

            Case eTIMEOUT_ITEM.PORT_CHANGE_REPORT_P1
                strTimeoutFunCategory = "Port1 Change Report(ZR241)"
            Case eTIMEOUT_ITEM.PORT_CHANGE_REPORT_P2
                strTimeoutFunCategory = "Port2 Change Report(ZR245)"
            Case eTIMEOUT_ITEM.PORT_CHANGE_REPORT_P3
                strTimeoutFunCategory = "Port3 Change Report(ZR249)"

            Case eTIMEOUT_ITEM.GLASS_ABNORMAL_REPORT
                strTimeoutFunCategory = "Glass Abnormal Report"
            Case eTIMEOUT_ITEM.GLASS_UNMATCHED_REPORT
                strTimeoutFunCategory = "Glass info. Unmatched report"

            Case eTIMEOUT_ITEM.FLOW_IN_REPORT
                strTimeoutFunCategory = "Glass Flow in Report"
            Case eTIMEOUT_ITEM.FLOW_OUT_REPORT_P1
                strTimeoutFunCategory = "Port1 Glass Flow out Report"

            Case eTIMEOUT_ITEM.FLOW_OUT_REPORT_P2
                strTimeoutFunCategory = "Port2 Glass Flow out Report"

            Case eTIMEOUT_ITEM.FLOW_OUT_REPORT_P3
                strTimeoutFunCategory = "Port2 Glass Flow out Report"

            Case eTIMEOUT_ITEM.GLASS_DATA_REQ_REPORT
                strTimeoutFunCategory = "Glass Data Request Report"

            Case eTIMEOUT_ITEM.GLASS_DATA_ERASE_EQ1
                strTimeoutFunCategory = "EQ1 Glass Data Erase Report"
            Case eTIMEOUT_ITEM.GLASS_DATA_ERASE_EQ2
                strTimeoutFunCategory = "EQ2 Glass Data Erase Report"
            Case eTIMEOUT_ITEM.GLASS_DATA_ERASE_EQ3
                strTimeoutFunCategory = "EQ3 Glass Data Erase Report"

            Case eTIMEOUT_ITEM.RECIPE_MODIFIED_EQ1
                strTimeoutFunCategory = "EQ1 Recipe Modified Report"
            Case eTIMEOUT_ITEM.RECIPE_MODIFIED_EQ2
                strTimeoutFunCategory = "EQ2 Recipe Modified Report"
            Case eTIMEOUT_ITEM.RECIPE_MODIFIED_EQ3
                strTimeoutFunCategory = "EQ3 Recipe Modified Report"

            Case eTIMEOUT_ITEM.EQ_RESULT_REPORT_EQ1
                strTimeoutFunCategory = "EQ1 Glass Data Result Report"
            Case eTIMEOUT_ITEM.EQ_RESULT_REPORT_EQ2
                strTimeoutFunCategory = "EQ2 Glass Data Result Report"
            Case eTIMEOUT_ITEM.EQ_RESULT_REPORT_EQ3
                strTimeoutFunCategory = "EQ3 Glass Data Result Report"

            Case Else
                strTimeoutFunCategory = "???,Code=" & nCategory.ToString
        End Select

        ReportTimeoutFunName = strTimeoutFunCategory
    End Function
#End Region

    

End Module
