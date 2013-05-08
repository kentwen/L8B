Imports Nini.Config


Module ModuleINI
    Public Const SYS_SECTION = "SYSTEM"
    Public Const TIMEOUT_SECTION = "TIMEOUT"
    Public Const SAMPLEGX_SECTION = "SAMPLEGLASS"
    Public Const TRACEADDR_SECTION = "TRACEADDR"

    Public Const SYS_PLC_IP = "PLCTCPIP"
    Public Const SYS_PLC_PORT = "PLCTCPPORT"
    Public Const SYS_PLC_MODE = "PLCMODE"
    Public Const SYS_CV_MAXCV = "MAXCV"
    Public Const SYS_CV1_MAXPORT = "CV1_MAX_PORT"
    Public Const SYS_CV2_MAXPORT = "CV2_MAX_PORT"

    Private Const MAX_TIMER_PARAMETER = 80

    Public g_mstrPLCIP As String
    Public g_mnPLCPORT As Integer
    Public g_mfPLCMode As Boolean

    Public g_mnMaxCV As Integer
    Public g_mnCV1MaxPort As Integer
    Public g_mnCV2MaxPort As Integer

    Public g_strINI_PATH As String

    Public source As IniConfigSource

    Public Structure CV1TimeoutSetting
        Dim nLinkEstablishmentT1 As Integer
        Dim nRobotT1 As Integer
        Dim nRobotT5 As Integer
        Dim nCSTLoadReqT2 As Integer
        Dim nCSTLoadCompT2 As Integer
        Dim nCSTProcessReqT1 As Integer
        Dim nCSTProcessReqT3 As Integer
        Dim nGXGlowOutT2 As Integer
        Dim nGXFlowInT2 As Integer
        Dim nGXDataReqT2 As Integer
        Dim nCSTUnloadReqT2 As Integer
        Dim nCSTUnloadCompT2 As Integer
        Dim nPortChangeReqT1 As Integer
        Dim nPortChangeReqT3 As Integer
        Dim nGXSlotUnmatchT2 As Integer
        Dim nGXAbnormalT2 As Integer
        Dim nTransferResetT1 As Integer
        Dim nTransferResetT3 As Integer
        Dim nPresentT2 As Integer
        Dim nRemoveT2 As Integer

        Dim nCSTUnloadReqT0 As Integer
        Dim nPauseT1 As Integer
        Dim nPauseT3 As Integer
        Dim nResumeT1 As Integer
        Dim nResumeT3 As Integer
        Dim nDummyCancelT1 As Integer
        Dim nDummyCancelT3 As Integer

    End Structure

    Public Structure CV2TimeoutSetting
        Dim nLinkEstablishmentT1 As Integer
        Dim nRobotT1 As Integer
        Dim nRobotT5 As Integer
        Dim nCSTLoadReqT2 As Integer
        Dim nCSTLoadCompT2 As Integer
        Dim nCSTProcessReqT1 As Integer
        Dim nCSTProcessReqT3 As Integer
        Dim nGXGlowOutT2 As Integer
        Dim nGXFlowInT2 As Integer
        Dim nGXDataReqT2 As Integer
        Dim nCSTUnloadReqT2 As Integer
        Dim nCSTUnloadCompT2 As Integer
        Dim nPortChangeReqT1 As Integer
        Dim nPortChangeReqT3 As Integer
        Dim nGXSlotUnmatchT2 As Integer
        Dim nGXAbnormalT2 As Integer
        Dim nTransferResetT1 As Integer
        Dim nTransferResetT3 As Integer
    End Structure

    Public Structure EQTimeoutSetting
        Dim nEQLinkEstablishmentT1 As Integer
        Dim nEQLoadGXT1 As Integer
        Dim nEQLoadGXT5 As Integer
        Dim nEQUnloadGXT1 As Integer
        Dim nEQUnloadGXT5 As Integer
        Dim nEQExchangeGXT1 As Integer
        Dim nEQExchangeGXT5 As Integer
        Dim nEQRecipeModifyT2 As Integer
        Dim nEQRecipeExistCheckT1 As Integer
        Dim nEQRecipeExistCheckT3 As Integer
        Dim nEQGXEraseT2 As Integer
        Dim nEQTransferResetT1 As Integer
        Dim nEQTransferResetT3 As Integer
        Dim nEQRecipeQueryT1 As Integer
        Dim nEQRecipeQueryT3 As Integer
    End Structure

    'Public Structure EQ2TimeoutSetting
    '    Dim nEQLinkEstablishmentT1 As Integer
    '    Dim nEQLoadGXT1 As Integer
    '    Dim nEQLoadGXT5 As Integer
    '    Dim nEQUnloadGXT1 As Integer
    '    Dim nEQUnloadGXT5 As Integer
    '    Dim nEQExchangeGXT1 As Integer
    '    Dim nEQExchangeGXT5 As Integer
    '    Dim nEQRecipeModifyT2 As Integer
    '    Dim nEQRecipeExistCheckT1 As Integer
    '    Dim nEQRecipeExistCheckT3 As Integer
    '    Dim nEQGXEraseT2 As Integer
    '    Dim nEQTransferResetT1 As Integer
    '    Dim nEQTransferResetT3 As Integer
    '    Dim EQRecipeQueryT1 As Integer
    '    Dim EQRecipeQueryT3 As Integer
    'End Structure

    'Public Structure EQ3TimeoutSetting
    '    Dim nEQLinkEstablishmentT1 As Integer
    '    Dim nEQLoadGXT1 As Integer
    '    Dim nEQLoadGXT5 As Integer
    '    Dim nEQUnloadGXT1 As Integer
    '    Dim nEQUnloadGXT5 As Integer
    '    Dim nEQExchangeGXT1 As Integer
    '    Dim nEQExchangeGXT5 As Integer
    '    Dim nEQRecipeModifyT2 As Integer
    '    Dim nEQRecipeExistCheckT1 As Integer
    '    Dim nEQRecipeExistCheckT3 As Integer
    '    Dim nEQGXEraseT2 As Integer
    '    Dim nEQTransferResetT1 As Integer
    '    Dim nEQTransferResetT3 As Integer
    '    Dim EQRecipeQueryT1 As Integer
    '    Dim EQRecipeQueryT3 As Integer
    'End Structure

    Public Structure SampleGxSetting
        Dim nHour1 As Integer
        Dim nHour2 As Integer
        Dim nHour3 As Integer
        Dim nHour4 As Integer
        Dim nMinute1 As Integer
        Dim nMinute2 As Integer
        Dim nMinute3 As Integer
        Dim nMinute4 As Integer
        Dim nSampleGxEnable1 As Integer
        Dim nSampleGxEnable2 As Integer
        Dim nSampleGxEnable3 As Integer
        Dim nSampleGxEnable4 As Integer
        Dim nEQ1Week As Integer
        Dim nEQ2Week As Integer
    End Structure

    Public Structure TraceData
        Dim nCount As Integer
        Dim nTraceAddr() As Integer
    End Structure

    Public MyCV1TimeoutSetting As CV1TimeoutSetting
    Public MyCV2TimeoutSetting As CV2TimeoutSetting
    Public MyEQ1TimeoutSetting As EQTimeoutSetting
    Public MyEQ2TimeoutSetting As EQTimeoutSetting
    Public MyEQ3TimeoutSetting As EQTimeoutSetting
    Public MySampleGxSetting As SampleGxSetting
    Public MyTraceAddr As TraceData


    Public Sub LoadConfigs()

        source = New IniConfigSource(g_strINI_PATH)
        Dim config As IConfig

        config = source.Configs(SYS_SECTION)
        g_mstrPLCIP = config.Get(SYS_PLC_IP)
        g_mnPLCPORT = config.Get(SYS_PLC_PORT)
        g_mfPLCMode = IIf(config.Get(SYS_PLC_MODE) = 1, True, False)

        g_mnMaxCV = config.Get(SYS_CV_MAXCV)
        g_mnCV1MaxPort = config.Get(SYS_CV1_MAXPORT)
        g_mnCV2MaxPort = config.Get(SYS_CV2_MAXPORT)


        '-----------------Time Out Setting--------------------------
        config = source.Configs(TIMEOUT_SECTION)

        MyCV1TimeoutSetting.nLinkEstablishmentT1 = config.Get("CV1Linkestablishment")
        MyCV1TimeoutSetting.nRobotT1 = config.Get("CV1RobotT1")
        MyCV1TimeoutSetting.nRobotT5 = config.Get("CV1RobotT5")
        MyCV1TimeoutSetting.nCSTLoadReqT2 = config.Get("CV1CSTLoadReqT2")
        MyCV1TimeoutSetting.nCSTLoadCompT2 = config.Get("CV1CSTLoadCompT2")
        MyCV1TimeoutSetting.nCSTProcessReqT1 = config.Get("CV1CSTProcessReqT1")
        MyCV1TimeoutSetting.nCSTProcessReqT3 = config.Get("CV1CSTProcessReqT3")
        MyCV1TimeoutSetting.nGXGlowOutT2 = config.Get("CV1GXGlowOutT2")
        MyCV1TimeoutSetting.nGXFlowInT2 = config.Get("CV1GXFlowInT2")
        MyCV1TimeoutSetting.nGXDataReqT2 = config.Get("CV1GXDataReqT2")
        MyCV1TimeoutSetting.nCSTUnloadReqT2 = config.Get("CV1CSTUnloadReqT2")
        MyCV1TimeoutSetting.nCSTUnloadCompT2 = config.Get("CV1CSTUnloadCompT2")
        MyCV1TimeoutSetting.nPortChangeReqT1 = config.Get("CV1PortChangeReqT1")
        MyCV1TimeoutSetting.nPortChangeReqT3 = config.Get("CV1PortChangeReqT3")
        MyCV1TimeoutSetting.nGXSlotUnmatchT2 = config.Get("CV1GXSlotUnmatchT2")
        MyCV1TimeoutSetting.nGXAbnormalT2 = config.Get("CV1GXAbnormalT2")
        MyCV1TimeoutSetting.nTransferResetT1 = config.Get("CV1TransferResetT1")
        MyCV1TimeoutSetting.nTransferResetT3 = config.Get("CV1TransferResetT3")

        MyCV1TimeoutSetting.nPresentT2 = config.Get("CV1PresentT2")
        MyCV1TimeoutSetting.nRemoveT2 = config.Get("CV1RemoveT2")

        MyCV1TimeoutSetting.nCSTUnloadReqT0 = config.Get("CV1UnoadReqT0")
        MyCV1TimeoutSetting.nPauseT1 = config.Get("CV1PauseT1")
        MyCV1TimeoutSetting.nPauseT3 = config.Get("CV1PauseT3")
        MyCV1TimeoutSetting.nResumeT1 = config.Get("CV1ResumeT1")
        MyCV1TimeoutSetting.nResumeT3 = config.Get("CV1ResumeT3")
        MyCV1TimeoutSetting.nDummyCancelT1 = config.Get("CV1DummyCancelT1")
        MyCV1TimeoutSetting.nDummyCancelT3 = config.Get("CV1DummyCancelT3")

        'MyCV2TimeoutSetting.nLinkEstablishmentT1 = config.Get("CV2Linkestablishment")
        'MyCV2TimeoutSetting.nRobotT1 = config.Get("CV2RobotT1")
        'MyCV2TimeoutSetting.nRobotT5 = config.Get("CV2RobotT5")
        'MyCV2TimeoutSetting.nCSTLoadReqT2 = config.Get("CV2CSTLoadReqT2")
        'MyCV2TimeoutSetting.nCSTLoadCompT2 = config.Get("CV2CSTLoadCompT2")
        'MyCV2TimeoutSetting.nCSTProcessReqT1 = config.Get("CV2CSTProcessReqT1")
        'MyCV2TimeoutSetting.nCSTProcessReqT3 = config.Get("CV2CSTProcessReqT3")
        'MyCV2TimeoutSetting.nGXGlowOutT2 = config.Get("CV2GXGlowOutT2")
        'MyCV2TimeoutSetting.nGXFlowInT2 = config.Get("CV2GXFlowInT2")
        'MyCV2TimeoutSetting.nGXDataReqT2 = config.Get("CV2GXDataReqT2")
        'MyCV2TimeoutSetting.nCSTUnloadReqT2 = config.Get("CV2CSTUnloadReqT2")
        'MyCV2TimeoutSetting.nCSTUnloadCompT2 = config.Get("CV2CSTUnloadCompT2")
        'MyCV2TimeoutSetting.nPortChangeReqT1 = config.Get("CV2PortChangeReqT1")
        'MyCV2TimeoutSetting.nPortChangeReqT3 = config.Get("CV2PortChangeReqT3")
        'MyCV2TimeoutSetting.nGXSlotUnmatchT2 = config.Get("CV2GXSlotUnmatchT2")
        'MyCV2TimeoutSetting.nGXAbnormalT2 = config.Get("CV2GXAbnormalT2")
        'MyCV2TimeoutSetting.nTransferResetT1 = config.Get("CV2TransferResetT1")
        'MyCV2TimeoutSetting.nTransferResetT3 = config.Get("CV2TransferResetT3")

        MyEQ1TimeoutSetting.nEQLinkEstablishmentT1 = config.Get("EQ1LinkEstablishmentT1")
        MyEQ1TimeoutSetting.nEQLoadGXT1 = config.Get("EQ1LoadGXT1")
        MyEQ1TimeoutSetting.nEQLoadGXT5 = config.Get("EQ1LoadGXT5")
        MyEQ1TimeoutSetting.nEQUnloadGXT1 = config.Get("EQ1UnloadGXT1")
        MyEQ1TimeoutSetting.nEQUnloadGXT5 = config.Get("EQ1UnloadGXT5")
        MyEQ1TimeoutSetting.nEQExchangeGXT1 = config.Get("EQ1ExchangeGXT1")
        MyEQ1TimeoutSetting.nEQExchangeGXT5 = config.Get("EQ1ExchangeGXT5")
        MyEQ1TimeoutSetting.nEQRecipeModifyT2 = config.Get("EQ1RecipeModifyT2")
        MyEQ1TimeoutSetting.nEQRecipeExistCheckT1 = config.Get("EQ1RecipeExistCheckT1")
        MyEQ1TimeoutSetting.nEQRecipeExistCheckT3 = config.Get("EQ1RecipeExistCheckT3")
        MyEQ1TimeoutSetting.nEQGXEraseT2 = config.Get("EQ1GXEraseT2")
        MyEQ1TimeoutSetting.nEQTransferResetT1 = config.Get("EQ1TransferResetT1")
        MyEQ1TimeoutSetting.nEQTransferResetT3 = config.Get("EQ1TransferResetT3")
        MyEQ1TimeoutSetting.nEQRecipeQueryT1 = config.Get("EQ1RecipeQueryT1")
        MyEQ1TimeoutSetting.nEQRecipeQueryT3 = config.Get("EQ1RecipeQueryT3")

        MyEQ2TimeoutSetting.nEQLinkEstablishmentT1 = config.Get("EQ2LinkEstablishmentT1")
        MyEQ2TimeoutSetting.nEQLoadGXT1 = config.Get("EQ2LoadGXT1")
        MyEQ2TimeoutSetting.nEQLoadGXT5 = config.Get("EQ2LoadGXT5")
        MyEQ2TimeoutSetting.nEQUnloadGXT1 = config.Get("EQ2UnloadGXT1")
        MyEQ2TimeoutSetting.nEQUnloadGXT5 = config.Get("EQ2UnloadGXT5")
        MyEQ2TimeoutSetting.nEQExchangeGXT1 = config.Get("EQ2ExchangeGXT1")
        MyEQ2TimeoutSetting.nEQExchangeGXT5 = config.Get("EQ2ExchangeGXT5")
        MyEQ2TimeoutSetting.nEQRecipeModifyT2 = config.Get("EQ2RecipeModifyT2")
        MyEQ2TimeoutSetting.nEQRecipeExistCheckT1 = config.Get("EQ2RecipeExistCheckT1")
        MyEQ2TimeoutSetting.nEQRecipeExistCheckT3 = config.Get("EQ2RecipeExistCheckT3")
        MyEQ2TimeoutSetting.nEQGXEraseT2 = config.Get("EQ2GXEraseT2")
        MyEQ2TimeoutSetting.nEQTransferResetT1 = config.Get("EQ2TransferResetT1")
        MyEQ2TimeoutSetting.nEQTransferResetT3 = config.Get("EQ2TransferResetT3")
        MyEQ2TimeoutSetting.nEQRecipeQueryT1 = config.Get("EQ2RecipeQueryT1")
        MyEQ2TimeoutSetting.nEQRecipeQueryT3 = config.Get("EQ2RecipeQueryT3")

        MyEQ3TimeoutSetting.nEQLinkEstablishmentT1 = config.Get("EQ3LinkEstablishmentT1")
        MyEQ3TimeoutSetting.nEQLoadGXT1 = config.Get("EQ3LoadGXT1")
        MyEQ3TimeoutSetting.nEQLoadGXT5 = config.Get("EQ3LoadGXT5")
        MyEQ3TimeoutSetting.nEQUnloadGXT1 = config.Get("EQ3UnloadGXT1")
        MyEQ3TimeoutSetting.nEQUnloadGXT5 = config.Get("EQ3UnloadGXT5")
        MyEQ3TimeoutSetting.nEQExchangeGXT1 = config.Get("EQ3ExchangeGXT1")
        MyEQ3TimeoutSetting.nEQExchangeGXT5 = config.Get("EQ3ExchangeGXT5")
        MyEQ3TimeoutSetting.nEQRecipeModifyT2 = config.Get("EQ3RecipeModifyT2")
        MyEQ3TimeoutSetting.nEQRecipeExistCheckT1 = config.Get("EQ3RecipeExistCheckT1")
        MyEQ3TimeoutSetting.nEQRecipeExistCheckT3 = config.Get("EQ3RecipeExistCheckT3")
        MyEQ3TimeoutSetting.nEQGXEraseT2 = config.Get("EQ3GXEraseT2")
        MyEQ3TimeoutSetting.nEQTransferResetT1 = config.Get("EQ3TransferResetT1")
        MyEQ3TimeoutSetting.nEQTransferResetT3 = config.Get("EQ3TransferResetT3")
        MyEQ3TimeoutSetting.nEQRecipeQueryT1 = config.Get("EQ3RecipeQueryT1")
        MyEQ3TimeoutSetting.nEQRecipeQueryT3 = config.Get("EQ3RecipeQueryT3")

        '-----------------Sample Glass Setting--------------------------
        config = source.Configs(SAMPLEGX_SECTION)

        MySampleGxSetting.nSampleGxEnable1 = config.Get("Time1_Enable")
        MySampleGxSetting.nSampleGxEnable2 = config.Get("Time2_Enable")
        MySampleGxSetting.nSampleGxEnable3 = config.Get("Time3_Enable")
        MySampleGxSetting.nSampleGxEnable4 = config.Get("Time4_Enable")

        MySampleGxSetting.nHour1 = config.Get("Time1_Hour")
        MySampleGxSetting.nHour2 = config.Get("Time2_Hour")
        MySampleGxSetting.nHour3 = config.Get("Time3_Hour")
        MySampleGxSetting.nHour4 = config.Get("Time4_Hour")

        MySampleGxSetting.nMinute1 = config.Get("Time1_Minute")
        MySampleGxSetting.nMinute2 = config.Get("Time2_Minute")
        MySampleGxSetting.nMinute3 = config.Get("Time3_Minute")
        MySampleGxSetting.nMinute4 = config.Get("Time4_Minute")
        MySampleGxSetting.nEQ1Week = config.Get("EQ1Week")
        MySampleGxSetting.nEQ2Week = config.Get("EQ2Week")

        '-----------------TraceAddress--------------------------
        config = source.Configs(TRACEADDR_SECTION)

        ReDim MyTraceAddr.nTraceAddr(20)

        MyTraceAddr.nCount = config.Get("Trace_Count")
        MyTraceAddr.nTraceAddr(0) = config.Get("Trace_Addr1")
        MyTraceAddr.nTraceAddr(1) = config.Get("Trace_Addr2")
        MyTraceAddr.nTraceAddr(2) = config.Get("Trace_Addr3")
        MyTraceAddr.nTraceAddr(3) = config.Get("Trace_Addr4")
        MyTraceAddr.nTraceAddr(4) = config.Get("Trace_Addr5")
        MyTraceAddr.nTraceAddr(5) = config.Get("Trace_Addr6")
        MyTraceAddr.nTraceAddr(6) = config.Get("Trace_Addr7")
        MyTraceAddr.nTraceAddr(7) = config.Get("Trace_Addr8")
        MyTraceAddr.nTraceAddr(8) = config.Get("Trace_Addr9")
        MyTraceAddr.nTraceAddr(9) = config.Get("Trace_Addr10")
        MyTraceAddr.nTraceAddr(10) = config.Get("Trace_Addr11")
        MyTraceAddr.nTraceAddr(11) = config.Get("Trace_Addr12")
        MyTraceAddr.nTraceAddr(12) = config.Get("Trace_Addr13")
        MyTraceAddr.nTraceAddr(13) = config.Get("Trace_Addr14")
        MyTraceAddr.nTraceAddr(14) = config.Get("Trace_Addr15")
        MyTraceAddr.nTraceAddr(15) = config.Get("Trace_Addr16")
        MyTraceAddr.nTraceAddr(16) = config.Get("Trace_Addr17")
        MyTraceAddr.nTraceAddr(17) = config.Get("Trace_Addr18")
        MyTraceAddr.nTraceAddr(18) = config.Get("Trace_Addr19")
        MyTraceAddr.nTraceAddr(19) = config.Get("Trace_Addr20")

    End Sub

    Public Sub WriteTimeOutParameter()
        Dim anWriteTimeOutData(MAX_TIMER_PARAMETER) As Integer
        Dim nStartAddr As Integer
        Dim nTimeValue As Integer

        nStartAddr = 1500
        nTimeValue = 10

        'PLC Time unit is 0.1 Sec.
        'PLC Time All Value * 10

        anWriteTimeOutData(0) = MyCV1TimeoutSetting.nLinkEstablishmentT1 * nTimeValue
        anWriteTimeOutData(1) = MyCV1TimeoutSetting.nRobotT1 * nTimeValue
        anWriteTimeOutData(2) = MyCV1TimeoutSetting.nRobotT5 * nTimeValue
        anWriteTimeOutData(3) = MyCV1TimeoutSetting.nCSTLoadReqT2 * nTimeValue
        anWriteTimeOutData(4) = MyCV1TimeoutSetting.nCSTLoadCompT2 * nTimeValue
        anWriteTimeOutData(5) = MyCV1TimeoutSetting.nCSTProcessReqT1 * nTimeValue
        anWriteTimeOutData(6) = MyCV1TimeoutSetting.nCSTProcessReqT3 * nTimeValue
        anWriteTimeOutData(7) = MyCV1TimeoutSetting.nGXGlowOutT2 * nTimeValue
        anWriteTimeOutData(8) = MyCV1TimeoutSetting.nGXFlowInT2 * nTimeValue
        anWriteTimeOutData(9) = MyCV1TimeoutSetting.nGXDataReqT2 * nTimeValue
        anWriteTimeOutData(10) = MyCV1TimeoutSetting.nCSTUnloadReqT2 * nTimeValue
        anWriteTimeOutData(11) = MyCV1TimeoutSetting.nCSTUnloadCompT2 * nTimeValue
        anWriteTimeOutData(12) = MyCV1TimeoutSetting.nPortChangeReqT1 * nTimeValue
        anWriteTimeOutData(13) = MyCV1TimeoutSetting.nPortChangeReqT3 * nTimeValue
        anWriteTimeOutData(14) = MyCV1TimeoutSetting.nGXSlotUnmatchT2 * nTimeValue
        anWriteTimeOutData(15) = MyCV1TimeoutSetting.nGXAbnormalT2 * nTimeValue
        anWriteTimeOutData(16) = MyCV1TimeoutSetting.nTransferResetT1 * nTimeValue
        anWriteTimeOutData(17) = MyCV1TimeoutSetting.nTransferResetT3 * nTimeValue

        anWriteTimeOutData(18) = MyCV1TimeoutSetting.nPresentT2 * nTimeValue
        anWriteTimeOutData(19) = MyCV1TimeoutSetting.nRemoveT2 * nTimeValue

        anWriteTimeOutData(20) = MyCV1TimeoutSetting.nCSTUnloadReqT0 * nTimeValue
        anWriteTimeOutData(21) = MyCV1TimeoutSetting.nPauseT1 * nTimeValue
        anWriteTimeOutData(22) = MyCV1TimeoutSetting.nPauseT3 * nTimeValue
        anWriteTimeOutData(23) = MyCV1TimeoutSetting.nResumeT1 * nTimeValue
        anWriteTimeOutData(24) = MyCV1TimeoutSetting.nResumeT3 * nTimeValue
        anWriteTimeOutData(25) = MyCV1TimeoutSetting.nDummyCancelT1 * nTimeValue
        anWriteTimeOutData(26) = MyCV1TimeoutSetting.nDummyCancelT3 * nTimeValue

        'anWriteTimeOutData(18) = MyCV2TimeoutSetting.nLinkEstablishmentT1 * nTimeValue
        'anWriteTimeOutData(19) = MyCV2TimeoutSetting.nRobotT1 * nTimeValue
        'anWriteTimeOutData(20) = MyCV2TimeoutSetting.nRobotT5 * nTimeValue
        'anWriteTimeOutData(21) = MyCV2TimeoutSetting.nCSTLoadReqT2 * nTimeValue
        'anWriteTimeOutData(22) = MyCV2TimeoutSetting.nCSTLoadCompT2 * nTimeValue
        'anWriteTimeOutData(23) = MyCV2TimeoutSetting.nCSTProcessReqT1 * nTimeValue
        'anWriteTimeOutData(24) = MyCV2TimeoutSetting.nCSTProcessReqT3 * nTimeValue
        'anWriteTimeOutData(25) = MyCV2TimeoutSetting.nGXGlowOutT2 * nTimeValue
        'anWriteTimeOutData(26) = MyCV2TimeoutSetting.nGXFlowInT2 * nTimeValue
        'anWriteTimeOutData(27) = MyCV2TimeoutSetting.nGXDataReqT2 * nTimeValue
        'anWriteTimeOutData(28) = MyCV2TimeoutSetting.nCSTUnloadReqT2 * nTimeValue
        'anWriteTimeOutData(29) = MyCV2TimeoutSetting.nCSTUnloadCompT2 * nTimeValue
        'anWriteTimeOutData(30) = MyCV2TimeoutSetting.nPortChangeReqT1 * nTimeValue
        'anWriteTimeOutData(31) = MyCV2TimeoutSetting.nPortChangeReqT3 * nTimeValue
        'anWriteTimeOutData(32) = MyCV2TimeoutSetting.nGXSlotUnmatchT2 * nTimeValue
        'anWriteTimeOutData(33) = MyCV2TimeoutSetting.nGXAbnormalT2 * nTimeValue
        'anWriteTimeOutData(34) = MyCV2TimeoutSetting.nTransferResetT1 * nTimeValue
        'anWriteTimeOutData(35) = MyCV2TimeoutSetting.nTransferResetT3 * nTimeValue

        anWriteTimeOutData(36) = MyEQ1TimeoutSetting.nEQLinkEstablishmentT1 * nTimeValue
        anWriteTimeOutData(37) = MyEQ1TimeoutSetting.nEQLoadGXT1 * nTimeValue
        anWriteTimeOutData(38) = MyEQ1TimeoutSetting.nEQLoadGXT5 * nTimeValue
        anWriteTimeOutData(39) = MyEQ1TimeoutSetting.nEQUnloadGXT1 * nTimeValue
        anWriteTimeOutData(40) = MyEQ1TimeoutSetting.nEQUnloadGXT5 * nTimeValue
        anWriteTimeOutData(41) = MyEQ1TimeoutSetting.nEQExchangeGXT1 * nTimeValue
        anWriteTimeOutData(42) = MyEQ1TimeoutSetting.nEQExchangeGXT5 * nTimeValue
        anWriteTimeOutData(43) = MyEQ1TimeoutSetting.nEQRecipeModifyT2 * nTimeValue
        anWriteTimeOutData(44) = MyEQ1TimeoutSetting.nEQRecipeExistCheckT1 * nTimeValue
        anWriteTimeOutData(45) = MyEQ1TimeoutSetting.nEQRecipeExistCheckT3 * nTimeValue
        anWriteTimeOutData(46) = MyEQ1TimeoutSetting.nEQGXEraseT2 * nTimeValue
        anWriteTimeOutData(47) = MyEQ1TimeoutSetting.nEQTransferResetT1 * nTimeValue
        anWriteTimeOutData(48) = MyEQ1TimeoutSetting.nEQTransferResetT3 * nTimeValue
        anWriteTimeOutData(49) = MyEQ1TimeoutSetting.nEQRecipeQueryT1 * nTimeValue
        anWriteTimeOutData(50) = MyEQ1TimeoutSetting.nEQRecipeQueryT3 * nTimeValue

        anWriteTimeOutData(51) = MyEQ2TimeoutSetting.nEQLinkEstablishmentT1 * nTimeValue
        anWriteTimeOutData(52) = MyEQ2TimeoutSetting.nEQLoadGXT1 * nTimeValue
        anWriteTimeOutData(53) = MyEQ2TimeoutSetting.nEQLoadGXT5 * nTimeValue
        anWriteTimeOutData(54) = MyEQ2TimeoutSetting.nEQUnloadGXT1 * nTimeValue
        anWriteTimeOutData(55) = MyEQ2TimeoutSetting.nEQUnloadGXT5 * nTimeValue
        anWriteTimeOutData(56) = MyEQ2TimeoutSetting.nEQExchangeGXT1 * nTimeValue
        anWriteTimeOutData(57) = MyEQ2TimeoutSetting.nEQExchangeGXT5 * nTimeValue
        anWriteTimeOutData(58) = MyEQ2TimeoutSetting.nEQRecipeModifyT2 * nTimeValue
        anWriteTimeOutData(59) = MyEQ2TimeoutSetting.nEQRecipeExistCheckT1 * nTimeValue
        anWriteTimeOutData(60) = MyEQ2TimeoutSetting.nEQRecipeExistCheckT3 * nTimeValue
        anWriteTimeOutData(61) = MyEQ2TimeoutSetting.nEQGXEraseT2 * nTimeValue
        anWriteTimeOutData(62) = MyEQ2TimeoutSetting.nEQTransferResetT1 * nTimeValue
        anWriteTimeOutData(63) = MyEQ2TimeoutSetting.nEQTransferResetT3 * nTimeValue
        anWriteTimeOutData(64) = MyEQ2TimeoutSetting.nEQRecipeQueryT1 * nTimeValue
        anWriteTimeOutData(65) = MyEQ2TimeoutSetting.nEQRecipeQueryT3 * nTimeValue

        anWriteTimeOutData(66) = MyEQ3TimeoutSetting.nEQLinkEstablishmentT1 * nTimeValue
        anWriteTimeOutData(67) = MyEQ3TimeoutSetting.nEQLoadGXT1 * nTimeValue
        anWriteTimeOutData(68) = MyEQ3TimeoutSetting.nEQLoadGXT5 * nTimeValue
        anWriteTimeOutData(69) = MyEQ3TimeoutSetting.nEQUnloadGXT1 * nTimeValue
        anWriteTimeOutData(70) = MyEQ3TimeoutSetting.nEQUnloadGXT5 * nTimeValue
        anWriteTimeOutData(71) = MyEQ3TimeoutSetting.nEQExchangeGXT1 * nTimeValue
        anWriteTimeOutData(72) = MyEQ3TimeoutSetting.nEQExchangeGXT5 * nTimeValue
        anWriteTimeOutData(73) = MyEQ3TimeoutSetting.nEQRecipeModifyT2 * nTimeValue
        anWriteTimeOutData(74) = MyEQ3TimeoutSetting.nEQRecipeExistCheckT1 * nTimeValue
        anWriteTimeOutData(75) = MyEQ3TimeoutSetting.nEQRecipeExistCheckT3 * nTimeValue
        anWriteTimeOutData(76) = MyEQ3TimeoutSetting.nEQGXEraseT2 * nTimeValue
        anWriteTimeOutData(77) = MyEQ3TimeoutSetting.nEQTransferResetT1 * nTimeValue
        anWriteTimeOutData(78) = MyEQ3TimeoutSetting.nEQTransferResetT3 * nTimeValue
        anWriteTimeOutData(79) = MyEQ3TimeoutSetting.nEQRecipeQueryT1 * nTimeValue
        anWriteTimeOutData(80) = MyEQ3TimeoutSetting.nEQRecipeQueryT3 * nTimeValue

        Call WriteZRArrayAddr(nStartAddr, anWriteTimeOutData)

    End Sub

    Public Sub WriteSampleGlassSettingParameter()
        Dim nDefValue As Integer
        Dim nSampleGxHour1 As Integer = 0
        Dim nSampleGxHour3 As Integer = 0
        Dim nSampleGxMinute1 As Integer = 0
        Dim nSampleGxMinute3 As Integer = 0
        Dim nEQ1Week As Integer = 0
        Dim nEQ2Week As Integer = 0

        nDefValue = &HFFFF

        nEQ1Week = MySampleGxSetting.nEQ1Week
        nEQ2Week = MySampleGxSetting.nEQ2Week

        If MySampleGxSetting.nSampleGxEnable1 = SIGNAL_ON Then
            nSampleGxHour1 = MySampleGxSetting.nHour1
            nSampleGxMinute1 = MySampleGxSetting.nMinute1
        Else
            nSampleGxHour1 = nDefValue
            nSampleGxMinute1 = nDefValue
        End If

        If MySampleGxSetting.nSampleGxEnable3 = SIGNAL_ON Then
            nSampleGxHour3 = MySampleGxSetting.nHour3
            nSampleGxMinute3 = MySampleGxSetting.nMinute3
        Else
            nSampleGxHour3 = nDefValue
            nSampleGxMinute3 = nDefValue
        End If

        WriteZRAddr(MyRSTZRAddr.EQ1SampleGxWeek, nEQ1Week)
        WriteZRAddr(MyRSTZRAddr.RobotSampleGxHour1, nSampleGxHour1)
        WriteZRAddr(MyRSTZRAddr.RobotSampleGxMinute1, nSampleGxMinute1)

        WriteZRAddr(MyRSTZRAddr.EQ2SampleGxWeek, nEQ2Week)
        WriteZRAddr(MyRSTZRAddr.RobotSampleGxHour3, nSampleGxHour3)
        WriteZRAddr(MyRSTZRAddr.RobotSampleGxMinute3, nSampleGxMinute3)


    End Sub

End Module
