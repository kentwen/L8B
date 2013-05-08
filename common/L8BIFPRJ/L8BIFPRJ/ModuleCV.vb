Module ModuleCV
    Private Const CV1_ZRADDR = 1000
    Private Const MAX_CV_ARRAY_LEN = 465
    Public Const CV_ALARM_WORD_LEN = 32
    Public Const MAX_CV_ALARM_CODE = 512
    Public Const CV_POSITION = 6


    Public MyCVNewWord As NEW_ZR_WordData
    Public MyCVOldWord As OLD_ZR_WordData
    Public MyCVMAddr As CV_M_Addr
    Public MyCVZRAddr As CV_ZR_Addr

    Public g_fCVEngineerMode As Boolean
    Public g_fEQEngineerMode As Boolean

    Public g_anCV_New_ZRWord(MAX_CV_ARRAY_LEN) As Integer

    Enum ePortMode
        PORTMODE_DEFAULT = 0
        PORTMODE_LOAD = 1
        PORTMODE_UNLOAD = 2
    End Enum

    Enum ePAS
        PAS_LOAD_REQUEST = 1
        PAS_LOAD_COMPLETE = 2
        PAS_UNLOAD_REQUEST = 3
        PAS_UNLOAD_COMPLETE = 4
    End Enum








    Public Structure NEW_ZR_WordData
        Dim mnPortFirstSlot() As Integer
        Dim mnPortActionStatus() As clsPLC.eCSTCmdStatus
        Dim mstrPortCSTID() As String
        Dim mnCVStatus As clsPLC.eEQStatus
        Dim mnGlassQtyInCST() As Integer
        Dim mnCVPortMode() As Integer
        Dim mnCVUnloadPortType() As Integer
        Dim mnVCREnable() As Integer
        Dim mnPortDisable() As Integer
        Dim mnPortExist() As Integer
        Dim mnHandOffAvailable() As Integer
        Dim mnPortSubStatus() As Integer
        Dim mnGlassJudgment() As Integer
        Dim mstrPSHGrade() As String
        Dim mstrProductCode() As String
        Dim mstrGlassID() As String
        Dim mstrOPID() As String
        Dim mnGlassQty() As Integer
        Dim mnUnloadStatus() As Integer
        Dim mnUnmatchPortNumber As Integer
        Dim mnUnmatchSlotNumber As Integer
        Dim mnUnmatchStatus As Integer
        'BitEvents
        'Dim mnCSTUnloadRequestReport() As Integer

        Dim mnGlassAbnormalReport As Integer
        Dim mnGlassinfoUnmatchedReport As Integer
        Dim mnPortChangeReport() As Integer
        Dim mnProceasCommandAck() As Integer

        Dim mnCassetteRemoveReport() As Integer
        Dim mnPortDummyCancelAck() As Integer
        'Dim mnCVLinkRequest As Integer
        'Dim mnCVLinkTestRequest As Integer
        Dim mnFlowinReport As Integer

        Dim mnFlowoutReport() As Integer

        Dim mnCV1PositionRST() As Integer
        Dim mnCV1PositionCV() As Integer

        Dim mnCVCassettePresentReport() As Integer
        Dim mnCVGlassRequestReport As Integer

        Dim mnCSTProcessCmdACK As Integer
        Dim mnS765datadownloadAck() As Integer
        Dim mnS167dataUploadRequest() As Integer

        Dim mnGxAbnormalCase As Integer
        Dim mstrAbnormalSGxID As String
        Dim mstrAbnormalVCRGxID As String
        Dim mnGxAbnormalPosition As Integer
        Dim mnPLCChangeData As Integer
        'Dim mnPortChangeReportPortNo As Integer
        Dim mnPortChangeOwner() As Integer
        Dim mnPortChangeReportResult() As Integer
        Dim mstrPortChangeReportProductCode As String
        Dim mnPortChangeReportPortMode() As clsPLC.ePortMode
        Dim mnPortChangeReportPortType() As clsPLC.eUnloadType

        Dim mnGXFlowInReportPortIndex As Integer
        Dim mstrGXFlowInReportProductCode As String
        Dim mstrGXFlowInReportGXID As String
        Dim mnGXFlowInReportSlotNo As Integer

        Dim mnGXFlowOutReportPortIndex() As Integer
        Dim mstrGXFlowOutProductCode() As String
        Dim mstrGXFlowOutGXID() As String
        Dim mnGXFlowOutReportSlotNo() As Integer

        Dim mnDummyCacncelResult As Integer
        Dim mnCVCassetteRemoveReportByPortNoWord As Integer

        Dim mnCVAlarmWord() As Integer
        Dim mnCVAlarm() As Integer

        Dim mnCVLinkStatus() As clsPLC.eLinkStatus
        Dim mnEQLinkStatus() As clsPLC.eLinkStatus

        Dim mstrCVPositionGxID() As String

        Dim mstrEQToolID() As String

        Dim mnThroughModeLoaderEmpty() As Integer
        Dim mnThroughModeUnloaderFull() As Integer
        Dim mnDataEmptyFlag As Integer

        Dim PortCancelReport() As Integer

        Dim mCVAutoStatus As Integer
        Dim mCVManualStatus As Integer
        Dim mCVRunStatus As Integer
        Dim mCVStopStatus As Integer
    End Structure

    Public Structure OLD_ZR_WordData
        'Dim mnPortFirstSlot() As Integer
        Dim mnPortActionStatus() As clsPLC.eCSTCmdStatus
        'Dim mstrPortCSTID() As String
        Dim mnCVStatus As clsPLC.eEQStatus
        Dim mnGlassQtyInCST() As Integer
        Dim mnCVPortMode() As Integer
        Dim mnCVUnloadPortType() As Integer
        Dim mnVCREnable() As Integer
        Dim mnPortDisable() As Integer
        Dim mnPortExist() As Integer
        Dim mnHandOffAvailable() As Integer
        Dim mnPortSubStatus() As Integer
        Dim mnGlassJudgment() As Integer
        Dim mstrPSHGrade() As String
        Dim mstrProductCode() As String
        Dim mstrGlassID() As String
        Dim mstrOPID() As String
        'Dim mnGlassQty() As Integer
        'Dim mnUnloadStatus() As Integer
        'Dim mnUnmatchPortNumber As Integer
        'Dim mnUnmatchSlotNumber As Integer
        'Dim mnUnmatchStatus As Integer

        'BitEvents
        'Dim mnCSTUnloadRequestReport() As Integer

        Dim mnGlassAbnormalReport As Integer
        Dim mnGlassinfoUnmatchedReport As Integer
        Dim mnPortChangeReport() As Integer
        Dim mnProceasCommandAck() As Integer

        Dim mnCassetteRemoveReport() As Integer
        Dim mnPortDummyCancelAck() As Integer
        Dim mnCVLinkRequest As Integer
        Dim mnCVLinkTestRequest As Integer
        Dim mnFlowinReport As Integer

        Dim mnFlowoutReport() As Integer
        'Dim mnEQResultReport() As Integer
        'Dim mnEQinformationReport() As Integer
        Dim mnCV1PositionRST() As Integer
        Dim mnCV1PositionCV() As Integer

        Dim mnCVCassettePresentReport() As Integer
        Dim mnCVGlassRequestReport As Integer

        Dim mnCSTProcessCmdACK As Integer
        Dim mnS765datadownloadAck() As Integer
        Dim mnS167dataUploadRequest() As Integer

        Dim mnCVAlarmWord() As Integer
        Dim mnCVAlarm() As Integer

        Dim mnCVLinkStatus() As clsPLC.eLinkStatus
        Dim mnEQLinkStatus() As clsPLC.eLinkStatus

        Dim mstrCVPositionGxID() As String

        Dim mnThroughModeLoaderEmpty() As Integer
        Dim mnThroughModeUnloaderFull() As Integer
        Dim mnDataEmptyFlag As Integer
        Dim PortCancelReport() As Integer

        Dim mCVAutoStatus As Integer
        Dim mCVManualStatus As Integer
        Dim mCVRunStatus As Integer
        Dim mCVStopStatus As Integer
    End Structure

    Public Structure CV_M_Addr
        Dim m_nTransferResetRequest As Integer
        Dim m_nGlassAbnormalReportAck As Integer
        Dim m_nGlassinfoUnmatchedReportAck As Integer
        Dim m_nPortChangeReportAck() As Integer
        Dim m_nCassetteProcessCommandRequest() As Integer
        Dim m_nS765DataDownloadRequest() As Integer
        Dim m_nS167DataUploadAck() As Integer
        Dim m_nDummyCancelRequest() As Integer
        Dim m_nPauseRequest() As Integer
        Dim m_nResumeRequest() As Integer
        Dim m_nRSTLinkRequest() As Integer '1:CV1 2:CV2 
        'Dim m_nCVCSTAbortRequest() As Integer

        'Dim m_nLinkTestRequest As Integer
        Dim m_nCassetteUnloadRequest() As Integer
        Dim m_nCVPortChangeRequest As Integer

        Dim m_nGxDataRequestReportAck As Integer

        Dim m_nFlowInAck As Integer
        Dim m_nFlowOutAck() As Integer

    End Structure

    Public Structure CV_ZR_Addr
        'Dim m_nPortNumber As Integer
        Dim m_nProcessCmdCSTID() As Integer
        Dim m_nProcessCommand() As Integer
        Dim m_nCassetteSlotInformation() As Integer
        Dim m_nProcessGlassQuantity() As Integer

        Dim m_nPortChangePortNo As Integer
        Dim m_nPortChangeProductCode As Integer
        Dim m_nPortChangePortMode As Integer
        Dim m_nPortChangePortType As Integer
    End Structure

    Public Sub ReDimCVArraySize()
        'M Addr
        ReDim MyCVMAddr.m_nS167DataUploadAck(MAX_PORTS)
        ReDim MyCVMAddr.m_nDummyCancelRequest(MAX_PORTS)
        ReDim MyCVMAddr.m_nPauseRequest(MAX_PORTS)
        ReDim MyCVMAddr.m_nResumeRequest(MAX_PORTS)
        ReDim MyCVMAddr.m_nCassetteUnloadRequest(MAX_PORTS)
        ReDim MyCVMAddr.m_nS765DataDownloadRequest(MAX_PORTS)
        ReDim MyCVMAddr.m_nPortChangeReportAck(MAX_PORTS)
        ReDim MyCVMAddr.m_nRSTLinkRequest(2)
        ReDim MyCVMAddr.m_nFlowOutAck(MAX_PORTS)


        'BitEvents
        ReDim MyCVNewWord.mnCassetteRemoveReport(MAX_PORTS)
        ReDim MyCVOldWord.mnCassetteRemoveReport(MAX_PORTS)

        ReDim MyCVNewWord.mnS765datadownloadAck(MAX_PORTS)
        ReDim MyCVOldWord.mnS765datadownloadAck(MAX_PORTS)

        ReDim MyCVNewWord.mnS167dataUploadRequest(MAX_PORTS)
        ReDim MyCVOldWord.mnS167dataUploadRequest(MAX_PORTS)

        ReDim MyCVNewWord.mnPortChangeReport(MAX_PORTS)
        ReDim MyCVOldWord.mnPortChangeReport(MAX_PORTS)
        'BitEvents



        ReDim MyCVNewWord.mnPortFirstSlot(MAX_PORTS)
        ReDim MyCVNewWord.mnPortActionStatus(MAX_PORTS)
        ReDim MyCVNewWord.mstrPortCSTID(MAX_PORTS)
        ReDim MyCVOldWord.mnPortActionStatus(MAX_PORTS)

        ReDim MyCVNewWord.mnPortDummyCancelAck(MAX_PORTS)
        ReDim MyCVOldWord.mnPortDummyCancelAck(MAX_PORTS)



        ReDim MyCVNewWord.mnGlassQtyInCST(MAX_CST_PORT)
        ReDim MyCVOldWord.mnGlassQtyInCST(MAX_CST_PORT)

        ReDim MyCVNewWord.mnCVPortMode(MAX_CST_PORT)
        ReDim MyCVOldWord.mnCVPortMode(MAX_CST_PORT)

        ReDim MyCVNewWord.mnCVUnloadPortType(MAX_CST_PORT)
        ReDim MyCVOldWord.mnCVUnloadPortType(MAX_CST_PORT)

        ReDim MyCVNewWord.mnVCREnable(MAX_CST_PORT)
        ReDim MyCVOldWord.mnVCREnable(MAX_CST_PORT)

        ReDim MyCVNewWord.mnPortDisable(MAX_CST_PORT)
        ReDim MyCVOldWord.mnPortDisable(MAX_CST_PORT)

        ReDim MyCVNewWord.mnPortExist(MAX_CST_PORT)
        ReDim MyCVOldWord.mnPortExist(MAX_CST_PORT)

        ReDim MyCVNewWord.mnHandOffAvailable(MAX_CST_PORT)
        ReDim MyCVOldWord.mnHandOffAvailable(MAX_CST_PORT)

        ReDim MyCVNewWord.mnPortSubStatus(MAX_CST_PORT)
        ReDim MyCVOldWord.mnPortSubStatus(MAX_CST_PORT)

        ReDim MyCVNewWord.mnGlassJudgment(MAX_CIMPCPORT)
        ReDim MyCVOldWord.mnGlassJudgment(MAX_CIMPCPORT)

        ReDim MyCVNewWord.mstrPSHGrade(MAX_CIMPCPORT)
        ReDim MyCVOldWord.mstrPSHGrade(MAX_CIMPCPORT)

        ReDim MyCVNewWord.mstrProductCode(MAX_CIMPCPORT)
        ReDim MyCVOldWord.mstrProductCode(MAX_CIMPCPORT)

        ReDim MyCVNewWord.mstrGlassID(MAX_CIMPCPORT)
        ReDim MyCVOldWord.mstrGlassID(MAX_CIMPCPORT)

        ReDim MyCVNewWord.mstrOPID(MAX_CIMPCPORT)
        ReDim MyCVOldWord.mstrOPID(MAX_CIMPCPORT)

        ReDim MyCVNewWord.mnGlassQty(MAX_CIMPCPORT)
        'ReDim MyCVOldWord.mnGlassQty(MAX_CIMPCPORT)

        ReDim MyCVNewWord.mnUnloadStatus(MAX_CIMPCPORT)
        'ReDim MyCVOldWord.mnUnloadStatus(MAX_CIMPCPORT)



        ReDim MyCVNewWord.mnCVAlarmWord(CV_ALARM_WORD_LEN)
        ReDim MyCVOldWord.mnCVAlarmWord(CV_ALARM_WORD_LEN)

        ReDim MyCVNewWord.mnCVAlarm(MAX_CV_ALARM_CODE)
        ReDim MyCVOldWord.mnCVAlarm(MAX_CV_ALARM_CODE)


        'ReDim MyCVNewWord.mnEQResultReport(MAX_EQ)
        'ReDim MyCVOldWord.mnEQResultReport(MAX_EQ)

        'ReDim MyCVNewWord.mnEQinformationReport(MAX_EQ)
        'ReDim MyCVOldWord.mnEQinformationReport(MAX_EQ)

        ReDim MyCVNewWord.mnCV1PositionRST(MAX_PORTS)
        ReDim MyCVOldWord.mnCV1PositionRST(MAX_PORTS)

        ReDim MyCVNewWord.mnCV1PositionCV(MAX_PORTS)
        ReDim MyCVOldWord.mnCV1PositionCV(MAX_PORTS)

        ReDim MyCVNewWord.mnCVLinkStatus(2)
        ReDim MyCVOldWord.mnCVLinkStatus(2)

        ReDim MyCVNewWord.mnEQLinkStatus(MAX_EQ)
        ReDim MyCVOldWord.mnEQLinkStatus(MAX_EQ)

        ReDim MyCVNewWord.mnCVCassettePresentReport(MAX_PORTS)
        ReDim MyCVOldWord.mnCVCassettePresentReport(MAX_PORTS)

        'Position 6
        ReDim MyCVNewWord.mstrCVPositionGxID(CV_POSITION)
        ReDim MyCVOldWord.mstrCVPositionGxID(CV_POSITION)

        ReDim MyCVNewWord.mstrEQToolID(MAX_EQ)

        ReDim MyCVNewWord.mnThroughModeLoaderEmpty(MAX_CST_PORT)
        ReDim MyCVOldWord.mnThroughModeLoaderEmpty(MAX_CST_PORT)

        ReDim MyCVNewWord.mnThroughModeUnloaderFull(MAX_CST_PORT)
        ReDim MyCVOldWord.mnThroughModeUnloaderFull(MAX_CST_PORT)

        ReDim MyCVNewWord.mnPortChangeOwner(MAX_CST_PORT)
        ReDim MyCVNewWord.mnPortChangeReportResult(MAX_CST_PORT)
        ReDim MyCVNewWord.mnPortChangeReportPortMode(MAX_CST_PORT)
        ReDim MyCVNewWord.mnPortChangeReportPortType(MAX_CST_PORT)


        ReDim MyCVNewWord.mnFlowoutReport(MAX_PORTS)
        ReDim MyCVOldWord.mnFlowoutReport(MAX_PORTS)

        ReDim MyCVNewWord.mnGXFlowOutReportPortIndex(MAX_PORTS)
        ReDim MyCVNewWord.mstrGXFlowOutProductCode(MAX_PORTS)
        ReDim MyCVNewWord.mstrGXFlowOutGXID(MAX_PORTS)
        ReDim MyCVNewWord.mnGXFlowOutReportSlotNo(MAX_PORTS)

        ReDim MyCVNewWord.PortCancelReport(MAX_PORTS)
        ReDim MyCVOldWord.PortCancelReport(MAX_PORTS)

        ReDim MyCVMAddr.m_nCassetteProcessCommandRequest(MAX_PORTS)

        ReDim MyCVNewWord.mnProceasCommandAck(MAX_PORTS)
        ReDim MyCVOldWord.mnProceasCommandAck(MAX_PORTS)


        ReDim MyCVZRAddr.m_nProcessCmdCSTID(MAX_PORTS)
        ReDim MyCVZRAddr.m_nProcessCommand(MAX_PORTS)
        ReDim MyCVZRAddr.m_nCassetteSlotInformation(MAX_PORTS)
        ReDim MyCVZRAddr.m_nProcessGlassQuantity(MAX_PORTS)
    End Sub

    Public Sub GetCVLinkMap()

        Call ReDimCVArraySize()

        MyCVMAddr.m_nTransferResetRequest = eCV_M_ADDR.TRANSFER_RESET_REQUEST
        MyCVMAddr.m_nGlassAbnormalReportAck = eCV_M_ADDR.GX_ABNORMAL_REPORT_ACT
        MyCVMAddr.m_nGlassinfoUnmatchedReportAck = eCV_M_ADDR.GX_INFO_UNMATCH_REPORT_ACK

        MyCVMAddr.m_nCassetteProcessCommandRequest(1) = 9100
        MyCVMAddr.m_nCassetteProcessCommandRequest(2) = 9101
        MyCVMAddr.m_nCassetteProcessCommandRequest(3) = 9102

        MyCVMAddr.m_nS765DataDownloadRequest(1) = eCV_M_ADDR.S765_DATA_DOWNLOAD_REQ_P1
        MyCVMAddr.m_nS765DataDownloadRequest(2) = eCV_M_ADDR.S765_DATA_DOWNLOAD_REQ_P2
        MyCVMAddr.m_nS765DataDownloadRequest(3) = eCV_M_ADDR.S765_DATA_DOWNLOAD_REQ_P3

        MyCVMAddr.m_nFlowInAck = eCV_M_ADDR.GX_FLOWIN_ACK

        MyCVMAddr.m_nS167DataUploadAck(1) = eCV_M_ADDR.S167_ACK_P1
        MyCVMAddr.m_nS167DataUploadAck(2) = eCV_M_ADDR.S167_ACK_P2
        MyCVMAddr.m_nS167DataUploadAck(3) = eCV_M_ADDR.S167_ACK_P3

        MyCVMAddr.m_nDummyCancelRequest(1) = eCV_M_ADDR.DUMMY_CANCEL_REQ_P1
        MyCVMAddr.m_nDummyCancelRequest(2) = eCV_M_ADDR.DUMMY_CANCEL_REQ_P2
        MyCVMAddr.m_nDummyCancelRequest(3) = eCV_M_ADDR.DUMMY_CANCEL_REQ_P3

        MyCVMAddr.m_nPauseRequest(1) = eCV_M_ADDR.PORT_PAUSE_REQ_P1
        MyCVMAddr.m_nPauseRequest(2) = eCV_M_ADDR.PORT_PAUSE_REQ_P2
        MyCVMAddr.m_nPauseRequest(3) = eCV_M_ADDR.PORT_PAUSE_REQ_P3

        MyCVMAddr.m_nResumeRequest(1) = eCV_M_ADDR.PORT_RESUME_RQE_P1
        MyCVMAddr.m_nResumeRequest(2) = eCV_M_ADDR.PORT_RESUME_RQE_P2
        MyCVMAddr.m_nResumeRequest(3) = eCV_M_ADDR.PORT_RESUME_RQE_P3

        MyCVMAddr.m_nRSTLinkRequest(1) = eCV_M_ADDR.RST_LINK_REQUEST_CV1
        MyCVMAddr.m_nRSTLinkRequest(2) = eCV_M_ADDR.RST_LINK_REQUEST_CV2

        MyCVMAddr.m_nCassetteUnloadRequest(1) = eCV_M_ADDR.CASSETTE_UNLOAD_REQUEST_P1
        MyCVMAddr.m_nCassetteUnloadRequest(2) = eCV_M_ADDR.CASSETTE_UNLOAD_REQUEST_P2
        MyCVMAddr.m_nCassetteUnloadRequest(3) = eCV_M_ADDR.CASSETTE_UNLOAD_REQUEST_P3

        MyCVMAddr.m_nCVPortChangeRequest = eCV_M_ADDR.PORT_CHANGE_REQUEST
        MyCVMAddr.m_nGxDataRequestReportAck = eCV_M_ADDR.GX_DATA_REQUEST_REPORT_ACK

        MyCVMAddr.m_nPortChangeReportAck(1) = eCV_M_ADDR.PORT1_CHANGE_REPORT_ACK
        MyCVMAddr.m_nPortChangeReportAck(2) = eCV_M_ADDR.PORT2_CHANGE_REPORT_ACK
        MyCVMAddr.m_nPortChangeReportAck(3) = eCV_M_ADDR.PORT3_CHANGE_REPORT_ACK

        MyCVMAddr.m_nFlowOutAck(1) = eCV_M_ADDR.GX_FLOWOUT_ACK_P1
        MyCVMAddr.m_nFlowOutAck(2) = eCV_M_ADDR.GX_FLOWOUT_ACK_P2
        MyCVMAddr.m_nFlowOutAck(3) = eCV_M_ADDR.GX_FLOWOUT_ACK_P3

        '--------------------------------------------------------
        'MyCVZRAddr.m_nPortNumber = eCV_ZR_ADDR.PORT_NUMBER

        MyCVZRAddr.m_nProcessCommand(1) = 167
        MyCVZRAddr.m_nCassetteSlotInformation(1) = 168
        MyCVZRAddr.m_nProcessGlassQuantity(1) = 172
        MyCVZRAddr.m_nProcessCmdCSTID(1) = 173

        MyCVZRAddr.m_nProcessCommand(2) = 176
        MyCVZRAddr.m_nCassetteSlotInformation(2) = 177
        MyCVZRAddr.m_nProcessGlassQuantity(2) = 181
        MyCVZRAddr.m_nProcessCmdCSTID(2) = 182

        MyCVZRAddr.m_nProcessCommand(3) = 185
        MyCVZRAddr.m_nCassetteSlotInformation(3) = 186
        MyCVZRAddr.m_nProcessGlassQuantity(3) = 190
        MyCVZRAddr.m_nProcessCmdCSTID(3) = 191

        '--------------------------------------------------------

        MyCVZRAddr.m_nPortChangePortNo = eCV_ZR_ADDR.PORT_CHANGE_PORTNO
        MyCVZRAddr.m_nPortChangeProductCode = eCV_ZR_ADDR.PORT_CHANGE_PRODUCTCODE
        MyCVZRAddr.m_nPortChangePortMode = eCV_ZR_ADDR.PORT_CHANGE_PORTMODE
        MyCVZRAddr.m_nPortChangePortType = eCV_ZR_ADDR.PORT_CHANGE_PORTTYPE

    End Sub


    Public Sub ScanCVZRWordAddr()
        Dim nFor As Integer
        Dim anReadWordData(MAX_CV_ARRAY_LEN) As Integer

        Call ReadZRAddr(CV1_ZRADDR, anReadWordData)

        'nFor ==> ZR Device No
        For nFor = 0 To MAX_CV_ARRAY_LEN
            g_anCV_New_ZRWord(nFor) = anReadWordData(nFor)
        Next

        Call ScanCVEventWord1()
        Call ScanCVEventWord2()
        Call ScanCVEventWord3()
        Call ScanCVEventWord4()

        Call ScanActionPortStatus()
        Call ScanCVStatus()
        Call ScanTotalGxInSpecifiedPort()
        Call ScanPortMode()
        Call ScanUnloadPortType()
        Call ScanVCR_Port_Status()
        Call ScanPortSubStatusHandOff()

        'Call ScanGlassDataReqEmptyFlag()
        Call ScanCVPositionGxID()

        Call ScanCVAlarm()
        Call ScanCVOpMode()
    End Sub

#Region "Timer Scan CV Addr Data Function"

    Private Sub ScanCVPositionGxID()
        Dim nFor As Integer
        Dim strPositionGxID(CV_POSITION) As String

        For nFor = eCVDevicNo.CV_POSITION1_GXID_W1 To eCVDevicNo.CV_POSITION1_GXID_W6
            strPositionGxID(1) = strPositionGxID(1) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        For nFor = eCVDevicNo.CV_POSITION2_GXID_W1 To eCVDevicNo.CV_POSITION2_GXID_W6
            strPositionGxID(2) = strPositionGxID(2) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        For nFor = eCVDevicNo.CV_POSITION3_GXID_W1 To eCVDevicNo.CV_POSITION3_GXID_W6
            strPositionGxID(3) = strPositionGxID(3) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        For nFor = eCVDevicNo.CV_POSITION4_GXID_W1 To eCVDevicNo.CV_POSITION4_GXID_W6
            strPositionGxID(4) = strPositionGxID(4) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        For nFor = eCVDevicNo.CV_POSITION5_GXID_W1 To eCVDevicNo.CV_POSITION5_GXID_W6
            strPositionGxID(5) = strPositionGxID(5) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        For nFor = eCVDevicNo.CV_POSITION6_GXID_W1 To eCVDevicNo.CV_POSITION6_GXID_W6
            strPositionGxID(6) = strPositionGxID(6) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        For nFor = 1 To CV_POSITION
            MyCVNewWord.mstrCVPositionGxID(nFor) = strPositionGxID(nFor)
        Next

    End Sub



    Private Sub ScanCVOpMode()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.CV_OPMODE), aBit)
        MyCVNewWord.mCVAutoStatus = Val(Mid(strBinaryData, 16, 1))
        MyCVNewWord.mCVManualStatus = Val(Mid(strBinaryData, 15, 1))
        MyCVNewWord.mCVRunStatus = Val(Mid(strBinaryData, 14, 1))
        MyCVNewWord.mCVStopStatus = Val(Mid(strBinaryData, 13, 1))

    End Sub

    Private Sub ScanCVStatus()
        MyCVNewWord.mnCVStatus = g_anCV_New_ZRWord(eCVDevicNo.CV_STATUS)
    End Sub

    Private Sub ScanCVEventWord1()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.EVENT_WORD1), aBit)
        'Debug.Print(strBinaryData)
        MyCVNewWord.mnCassetteRemoveReport(PORTNO1) = Val(Mid(strBinaryData, 16, 1))
        MyCVNewWord.mnCassetteRemoveReport(PORTNO2) = Val(Mid(strBinaryData, 15, 1))
        MyCVNewWord.mnCassetteRemoveReport(PORTNO3) = Val(Mid(strBinaryData, 14, 1))

        MyCVNewWord.mnS765datadownloadAck(PORTNO1) = Val(Mid(strBinaryData, 13, 1))
        MyCVNewWord.mnS765datadownloadAck(PORTNO2) = Val(Mid(strBinaryData, 12, 1))
        MyCVNewWord.mnS765datadownloadAck(PORTNO3) = Val(Mid(strBinaryData, 11, 1))


        MyCVNewWord.mnS167dataUploadRequest(PORTNO1) = Val(Mid(strBinaryData, 10, 1))
        MyCVNewWord.mnS167dataUploadRequest(PORTNO2) = Val(Mid(strBinaryData, 9, 1))
        MyCVNewWord.mnS167dataUploadRequest(PORTNO3) = Val(Mid(strBinaryData, 8, 1))


        MyCVNewWord.mnPortChangeReport(PORTNO1) = Val(Mid(strBinaryData, 7, 1))
        MyCVNewWord.mnPortChangeReport(PORTNO2) = Val(Mid(strBinaryData, 6, 1))
        MyCVNewWord.mnPortChangeReport(PORTNO3) = Val(Mid(strBinaryData, 5, 1))

        MyCVNewWord.mnProceasCommandAck(PORTNO1) = Val(Mid(strBinaryData, 4, 1))
        MyCVNewWord.mnProceasCommandAck(PORTNO2) = Val(Mid(strBinaryData, 3, 1))
        MyCVNewWord.mnProceasCommandAck(PORTNO3) = Val(Mid(strBinaryData, 2, 1))

        MyCVNewWord.mnGlassAbnormalReport = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCVEventWord2()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.EVENT_WORD2), aBit)

        MyCVNewWord.mnGlassinfoUnmatchedReport = Val(Mid(strBinaryData, 16, 1))
        'MyCVNewWord.mnPortChangeReport = Val(Mid(strBinaryData, 15, 1))
        'MyCVNewWord.mnProceasCommandAck = Val(Mid(strBinaryData, 14, 1))

        MyCVNewWord.mnPortDummyCancelAck(PORTNO1) = Val(Mid(strBinaryData, 13, 1))
        MyCVNewWord.mnPortDummyCancelAck(PORTNO2) = Val(Mid(strBinaryData, 12, 1))
        MyCVNewWord.mnPortDummyCancelAck(PORTNO3) = Val(Mid(strBinaryData, 11, 1))
        MyCVNewWord.mnFlowoutReport(1) = Val(Mid(strBinaryData, 10, 1))
        MyCVNewWord.mnFlowoutReport(2) = Val(Mid(strBinaryData, 9, 1))
        MyCVNewWord.mnFlowoutReport(3) = Val(Mid(strBinaryData, 8, 1))

        MyCVNewWord.mnFlowinReport = Val(Mid(strBinaryData, 6, 1))

        'MyCVNewWord.mnEQResultReport(1) = Val(Mid(strBinaryData, 4, 1))
        'MyCVNewWord.mnEQinformationReport(1) = Val(Mid(strBinaryData, 3, 1))
        'MyCVNewWord.mnEQResultReport(2) = Val(Mid(strBinaryData, 2, 1))
        'MyCVNewWord.mnEQinformationReport(2) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanCVEventWord3()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.EVENT_WORD3), aBit)

        'MyCVNewWord.mnEQResultReport(3) = Val(Mid(strBinaryData, 16, 1))
        'MyCVNewWord.mnEQinformationReport(3) = Val(Mid(strBinaryData, 15, 1))
        MyCVNewWord.mnCV1PositionRST(1) = Val(Mid(strBinaryData, 14, 1))
        MyCVNewWord.mnCV1PositionRST(2) = Val(Mid(strBinaryData, 13, 1))
        MyCVNewWord.mnCV1PositionRST(3) = Val(Mid(strBinaryData, 12, 1))
        'MyCVNewWord.mnCV1PositionRST(4) = Val(Mid(strBinaryData, 11, 1))
        'MyCVNewWord.mnCV1PositionRST(5) = Val(Mid(strBinaryData, 10, 1))

        MyCVNewWord.mnCV1PositionCV(1) = Val(Mid(strBinaryData, 9, 1))
        MyCVNewWord.mnCV1PositionCV(2) = Val(Mid(strBinaryData, 8, 1))
        MyCVNewWord.mnCV1PositionCV(3) = Val(Mid(strBinaryData, 7, 1))
        'MyCVNewWord.mnCV1PositionCV(4) = Val(Mid(strBinaryData, 6, 1))
        'MyCVNewWord.mnCV1PositionCV(5) = Val(Mid(strBinaryData, 5, 1))

        'MyCVNewWord.mnCVCassettePresentReport = Val(Mid(strBinaryData, 4, 1))
        MyCVNewWord.mnCVGlassRequestReport = Val(Mid(strBinaryData, 3, 1))

        MyCVNewWord.mnCVCassettePresentReport(1) = Val(Mid(strBinaryData, 2, 1))
        MyCVNewWord.mnCVCassettePresentReport(2) = Val(Mid(strBinaryData, 1, 1))

    End Sub

    Private Sub ScanCVEventWord4()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.EVENT_WORD4), aBit)

        MyCVNewWord.mnCVCassettePresentReport(3) = Val(Mid(strBinaryData, 16, 1))
        'MyCVNewWord.mnCVCassettePresentReport(4) = Val(Mid(strBinaryData, 15, 1))
        'MyCVNewWord.mnCVCassettePresentReport(5) = Val(Mid(strBinaryData, 14, 1))

        'For Through Mode
        MyCVNewWord.mnThroughModeLoaderEmpty(1) = Val(Mid(strBinaryData, 13, 1))
        MyCVNewWord.mnThroughModeLoaderEmpty(2) = Val(Mid(strBinaryData, 12, 1))
        MyCVNewWord.mnThroughModeLoaderEmpty(3) = Val(Mid(strBinaryData, 11, 1))
        'MyCVNewWord.mnThroughModeLoaderEmpty(4) = Val(Mid(strBinaryData, 10, 1))
        'MyCVNewWord.mnThroughModeLoaderEmpty(5) = Val(Mid(strBinaryData, 9, 1))

        MyCVNewWord.mnThroughModeUnloaderFull(1) = Val(Mid(strBinaryData, 8, 1))
        MyCVNewWord.mnThroughModeUnloaderFull(2) = Val(Mid(strBinaryData, 7, 1))
        MyCVNewWord.mnThroughModeUnloaderFull(3) = Val(Mid(strBinaryData, 6, 1))
        'MyCVNewWord.mnThroughModeUnloaderFull(4) = Val(Mid(strBinaryData, 5, 1))
        'MyCVNewWord.mnThroughModeUnloaderFull(5) = Val(Mid(strBinaryData, 4, 1))

        MyCVNewWord.PortCancelReport(1) = Val(Mid(strBinaryData, 3, 1))
        MyCVNewWord.PortCancelReport(2) = Val(Mid(strBinaryData, 2, 1))
        MyCVNewWord.PortCancelReport(3) = Val(Mid(strBinaryData, 1, 1))
    End Sub

    Private Sub ScanActionPortStatus()
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS

            Select Case nFor
                Case 1
                    strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.PORT1_ACTION_STATUS))
                Case 2
                    strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.PORT2_ACTION_STATUS))
                Case 3
                    strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.PORT3_ACTION_STATUS))
                Case 4
                    'strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.PORT4_ACTION_STATUS))
            End Select

            Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)
            strData = ""
            MyCVNewWord.mnPortFirstSlot(nFor) = nGetHibyte
            MyCVNewWord.mnPortActionStatus(nFor) = nGetLibyte
        Next
    End Sub

    Private Sub ScanTotalGxInSpecifiedPort()
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0
        Dim nFor As Integer

        For nFor = eCVDevicNo.GXQTYINCST_1_2 To eCVDevicNo.GXQTYINCST_5
            Select Case nFor
                Case eCVDevicNo.GXQTYINCST_1_2
                    strData = HexLeadZero(g_anCV_New_ZRWord(nFor))
                    Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)
                    MyCVNewWord.mnGlassQtyInCST(PORTNO1) = nGetLibyte
                    MyCVNewWord.mnGlassQtyInCST(PORTNO2) = nGetHibyte

                Case eCVDevicNo.GXQTYINCST_3_4
                    strData = HexLeadZero(g_anCV_New_ZRWord(nFor))
                    Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)
                    MyCVNewWord.mnGlassQtyInCST(PORTNO3) = nGetLibyte
                    MyCVNewWord.mnGlassQtyInCST(PORTNO4) = nGetHibyte

                Case eCVDevicNo.GXQTYINCST_5
                    strData = HexLeadZero(g_anCV_New_ZRWord(nFor))
                    Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)
                    MyCVNewWord.mnGlassQtyInCST(PORTNO5) = nGetLibyte
            End Select
            strData = ""
        Next
    End Sub

    Private Sub ScanPortMode()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""
        Dim i As Short
        Dim j As Short
        Dim strBinaryData_Port(MAX_CST_PORT) As String

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.PORTMODE), aBit)
        For i = 1 To MAX_CST_PORT
            strBinaryData_Port(i) = Mid(strBinaryData, (15 - j), 2)

            If strBinaryData_Port(i) = "01" Then
                MyCVNewWord.mnCVPortMode(i) = ePortMode.PORTMODE_LOAD
            ElseIf strBinaryData_Port(i) = "10" Then
                MyCVNewWord.mnCVPortMode(i) = ePortMode.PORTMODE_UNLOAD
            ElseIf strBinaryData_Port(i) = "00" Then
                MyCVNewWord.mnCVPortMode(i) = ePortMode.PORTMODE_DEFAULT
            End If
            j = j + 2
        Next
    End Sub

    Private Sub ScanUnloadPortType()
        Dim strHexData As String
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0
        Dim nFor As Integer

        For nFor = eCVDevicNo.UNLOAD_PORT_TYPE_1_4 To eCVDevicNo.UNLOAD_PORT_TYPE_5
            Select Case nFor
                Case eCVDevicNo.UNLOAD_PORT_TYPE_1_4
                    strHexData = HexLeadZero(g_anCV_New_ZRWord(nFor))
                    Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
                    MyCVNewWord.mnCVUnloadPortType(PORTNO1) = nfirstWord
                    MyCVNewWord.mnCVUnloadPortType(PORTNO2) = nSecondWord
                    MyCVNewWord.mnCVUnloadPortType(PORTNO3) = nThirdWord
                    MyCVNewWord.mnCVUnloadPortType(PORTNO4) = nFourthWord

                Case eCVDevicNo.UNLOAD_PORT_TYPE_5
                    strHexData = HexLeadZero(g_anCV_New_ZRWord(nFor))
                    Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
                    MyCVNewWord.mnCVUnloadPortType(PORTNO5) = nfirstWord

            End Select
            strHexData = ""
        Next
    End Sub

    Private Sub ScanVCR_Port_Status()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""
        Dim nFor As Integer

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.USEVCR_PEXIST_PDISABLE), aBit)

        For nFor = 1 To MAX_CST_PORT
            MyCVNewWord.mnVCREnable(nFor) = Val(Mid(strBinaryData, (16 - nFor + 1), 1))
            MyCVNewWord.mnPortDisable(nFor) = Val(Mid(strBinaryData, (11 - nFor + 1), 1))
            MyCVNewWord.mnPortExist(nFor) = Val(Mid(strBinaryData, (6 - nFor + 1), 1))
        Next
    End Sub

    Private Sub ScanPortSubStatusHandOff()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""
        Dim nFor As Integer

        strBinaryData = WordConvertToBin(g_anCV_New_ZRWord(eCVDevicNo.PORTSUBSTATUS_HANDOFF), aBit)
        For nFor = 1 To MAX_CST_PORT
            MyCVNewWord.mnHandOffAvailable(nFor) = Val(Mid(strBinaryData, (16 - nFor + 1), 1))
            MyCVNewWord.mnPortSubStatus(nFor) = Val(Mid(strBinaryData, (11 - nFor + 1), 1))
        Next
    End Sub

    Private Sub ScanCVAlarm()
        Dim nFor As Integer
        Dim nIndex As Integer

        For nFor = eCVDevicNo.CV_ALARM_WORD1 To eCVDevicNo.CV_ALARM_WORD32
            nIndex = nIndex + 1
            MyCVNewWord.mnCVAlarmWord(nIndex) = g_anCV_New_ZRWord(nFor)
        Next
    End Sub

#End Region

#Region "CV IF ReadData Function"

    Public Function ReadPortCancel(ByVal nPort As Integer) As Integer

        Select Case nPort
            Case 1
                ReadPortCancel = g_anCV_New_ZRWord(eCVDevicNo.PORT1_CANCEL_REPORT)
            Case 2
                ReadPortCancel = g_anCV_New_ZRWord(eCVDevicNo.PORT2_CANCEL_REPORT)
            Case 3
                ReadPortCancel = g_anCV_New_ZRWord(eCVDevicNo.PORT3_CANCEL_REPORT)
        End Select
    End Function

    Public Function ReadCVPortMiniSlot(ByVal nPortNo As Integer) As Integer
        ReadCVPortMiniSlot = MyCVNewWord.mnPortFirstSlot(nPortNo)
    End Function

    Public Function ReadCVToolID() As String
        Dim nFor As Integer
        Dim strCVToolID As String = ""

        For nFor = eCVDevicNo.CV_TOOL_ID_W1 To eCVDevicNo.CV_TOOL_ID_W6
            strCVToolID = strCVToolID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next
        ReadCVToolID = strCVToolID
    End Function

    Public Function ReadGxExistOnCV() As Integer
        Dim nFor As Integer
        Dim nReadValCV1(5) As Integer
        Dim nRet As Integer

        For nFor = 1 To 5
            nReadValCV1(nFor) = ProcessGxExistOnCV(nFor)
            nRet = nRet + nReadValCV1(nFor)
        Next
        ReadGxExistOnCV = nRet
    End Function

    Private Function ProcessGxExistOnCV(ByVal nPosition As Integer) As Integer
        Select Case nPosition
            Case 1
                ProcessGxExistOnCV = g_anCV_New_ZRWord(eCVDevicNo.GX_EXIST_ON_CV_POSITION1)
            Case 2
                ProcessGxExistOnCV = g_anCV_New_ZRWord(eCVDevicNo.GX_EXIST_ON_CV_POSITION2)
            Case 3
                ProcessGxExistOnCV = g_anCV_New_ZRWord(eCVDevicNo.GX_EXIST_ON_CV_POSITION3)
            Case 4
                ProcessGxExistOnCV = g_anCV_New_ZRWord(eCVDevicNo.GX_EXIST_ON_CV_POSITION4)
            Case 5
                ProcessGxExistOnCV = g_anCV_New_ZRWord(eCVDevicNo.GX_EXIST_ON_CV_POSITION5)
        End Select
    End Function

    'Private Sub ScanGlassDataReqEmptyFlag()
    '    Dim strData As String = ""
    '    Dim nGetHibyte As Integer = 0
    '    Dim nGetLibyte As Integer = 0

    '    strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.GX_DATA_REQ_VCR_READ_POSITION))

    '    Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

    '    MyCVNewWord.mnDataEmptyFlag = nGetHibyte
    'End Sub

    Public Sub ReadGxDataRequest(ByRef strGxID As String, ByRef strProductCode As String, ByRef strPSHGrade As String, ByRef nGxJudgment As Integer, ByRef nVCVReadPosition As Integer, ByRef nEmptyFlag As Integer)
        Dim nFor As Integer
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        For nFor = eCVDevicNo.GX_DATA_REQ_GXID_W1 To eCVDevicNo.GX_DATA_REQ_GXID_W6
            strGxID = strGxID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        For nFor = eCVDevicNo.GX_DATA_REQ_PRODUCT_W1 To eCVDevicNo.GX_DATA_REQ_PRODUCT_W13
            strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
        Next

        strPSHGrade = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_DATA_REQ_PSH_GRADE))
        nGxJudgment = g_anCV_New_ZRWord(eCVDevicNo.GX_DATA_REQ_GX_JUDGMENT)

        strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.GX_DATA_REQ_VCR_READ_POSITION))

        Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        nVCVReadPosition = nGetLibyte
        nEmptyFlag = nGetHibyte
        'nVCVReadPosition = g_anCV_New_ZRWord(eCVDevicNo.GX_DATA_REQ_VCR_READ_POSITION)
    End Sub



    'Public Function ReadEQResultReport(ByVal nEQIndex As Integer, ByRef nSampleGX As Integer, ByRef nSlotNo As Integer, ByRef strPSHGroup As String, ByRef strChipGrade As String, ByRef strGXID As String) As Integer
    '    Dim nFor As Integer
    '    Dim strTemp As String = ""
    '    Dim strChip As String = ""
    '    Dim anBit(MAX_BIT) As Short
    '    Dim strBinaryChip As String = ""

    '    nSampleGX = g_anCV_New_ZRWord(eCVDevicNo.EQ_RESULT_REPORT_SAMPLE_GX_FLAG)
    '    nSlotNo = g_anCV_New_ZRWord(eCVDevicNo.EQ_RESULT_REPORT_SLOT_NO)
    '    strPSHGroup = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.EQ_RESULT_REPORT_PSH_GROUP))

    '    For nFor = eCVDevicNo.EQ_RESULT_REPORT_CHIP_GRADE_WORD1 To eCVDevicNo.EQ_RESULT_REPORT_CHIP_GRADE_WORD9
    '        strTemp = WordConvertToBin(g_anCV_New_ZRWord(nFor), anBit)

    '        strBinaryChip = strBinaryChip & strTemp

    '        strChip = strChip & ProcessChipGrade(strTemp)
    '        strTemp = ""
    '    Next

    '    DebugLog(eIFIndex.INDEX_EQ, eLogType.EVENT, "EQ ChipGrade[" & strBinaryChip & "]")

    '    strChipGrade = strChip

    '    For nFor = eCVDevicNo.EQ_RESULT_REPORT_GX_ID_WORD1 To eCVDevicNo.EQ_RESULT_REPORT_GX_ID_WORD6
    '        strGXID = strGXID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
    '    Next

    '    ReadEQResultReport = g_anCV_New_ZRWord(eCVDevicNo.EQ_RESULT_REPORT_PROCESS_RESULT)
    'End Function

    Public Function ReadCSTProductCode(ByVal nPortNo As Integer) As String
        Dim nFor As Integer
        Dim strCSTProductCode As String = ""

        Select Case nPortNo
            Case 1
                For nFor = eCVDevicNo.CST_PPORT1_PRODUCT_CODE1 To eCVDevicNo.CST_PPORT1_PRODUCT_CODE13
                    strCSTProductCode = strCSTProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next
            Case 2
                For nFor = eCVDevicNo.CST_PPORT2_PRODUCT_CODE1 To eCVDevicNo.CST_PPORT2_PRODUCT_CODE13
                    strCSTProductCode = strCSTProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next
            Case 3
                For nFor = eCVDevicNo.CST_PPORT3_PRODUCT_CODE1 To eCVDevicNo.CST_PPORT3_PRODUCT_CODE13
                    strCSTProductCode = strCSTProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next
            Case 4
                For nFor = eCVDevicNo.CST_PPORT4_PRODUCT_CODE1 To eCVDevicNo.CST_PPORT4_PRODUCT_CODE13
                    strCSTProductCode = strCSTProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next
        End Select
        ReadCSTProductCode = strCSTProductCode
    End Function

    Public Function ReadCVPortType(ByVal nPortNo As Integer) As Integer
        ReadCVPortType = MyCVNewWord.mnCVUnloadPortType(nPortNo)
    End Function

    Public Function ReadCVPortMode(ByVal nPortNo As Integer) As Integer
        ReadCVPortMode = MyCVNewWord.mnCVPortMode(nPortNo)
    End Function

    Public Sub ReadPortCSTID(ByVal nPortNo As Integer)
        Dim astrCSTID As String = ""

        Select Case nPortNo
            Case 1
                astrCSTID = astrCSTID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT1_CSTID_WORD_1)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT1_CSTID_WORD_2)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT1_CSTID_WORD_3))
            Case 2
                astrCSTID = astrCSTID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT2_CSTID_WORD_1)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT2_CSTID_WORD_2)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT2_CSTID_WORD_3))
            Case 3
                astrCSTID = astrCSTID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT3_CSTID_WORD_1)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT3_CSTID_WORD_2)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT3_CSTID_WORD_3))
                'Case 4
                '    astrCSTID = astrCSTID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT4_CSTID_WORD_1)) _
                '    & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT4_CSTID_WORD_2)) _
                '    & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT4_CSTID_WORD_3))
                'Case 5
                '    astrCSTID = astrCSTID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT5_CSTID_WORD_1)) _
                '     & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT5_CSTID_WORD_2)) _
                '     & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PORT5_CSTID_WORD_3))
        End Select
        MyCVNewWord.mstrPortCSTID(nPortNo) = astrCSTID
    End Sub

    Public Sub ReadPortChangReport(ByVal nPortNo As Integer)
        Dim strPortChangeReportProductCode As String = ""
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        Select Case nPortNo
            Case 1
                MyCVNewWord.mnPortChangeOwner(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PORT_CHANG_REPORT_PORTNO1)
                MyCVNewWord.mnPortChangeReportResult(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PORT_CHANG_REPORT_RESULT1)
                MyCVNewWord.mnPortChangeReportPortMode(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PT_CHG_PORTMODE1)
                MyCVNewWord.mnPortChangeReportPortType(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PT_CHG_PORTTYPE1)
            Case 2
                MyCVNewWord.mnPortChangeOwner(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PORT_CHANG_REPORT_PORTNO2)
                MyCVNewWord.mnPortChangeReportResult(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PORT_CHANG_REPORT_RESULT2)
                MyCVNewWord.mnPortChangeReportPortMode(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PT_CHG_PORTMODE2)
                MyCVNewWord.mnPortChangeReportPortType(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PT_CHG_PORTTYPE2)
            Case 3
                MyCVNewWord.mnPortChangeOwner(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PORT_CHANG_REPORT_PORTNO3)
                MyCVNewWord.mnPortChangeReportResult(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PORT_CHANG_REPORT_RESULT3)
                MyCVNewWord.mnPortChangeReportPortMode(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PT_CHG_PORTMODE3)
                MyCVNewWord.mnPortChangeReportPortType(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.PT_CHG_PORTTYPE3)
        End Select
    End Sub

    Public Sub ReadAbnormalReport()
        Dim strAbnormalSourceGxID As String = ""
        Dim strAbnormalVCRGxID As String = ""
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        '1:GlassErase,2:GlassIDmodify,3:GlassInsert,4:GlassIDReadNG
        MyCVNewWord.mnGxAbnormalCase = g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_CASE)

        strAbnormalSourceGxID = strAbnormalSourceGxID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_SGID1)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_SGID2)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_SGID3)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_SGID4)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_SGID5)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_SGID6))

        MyCVNewWord.mstrAbnormalSGxID = strAbnormalSourceGxID

        strAbnormalVCRGxID = strAbnormalVCRGxID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_VCRGXID1)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_VCRGXID2)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_VCRGXID3)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_VCRGXID4)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_VCRGXID5)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_VCRGXID6))

        MyCVNewWord.mstrAbnormalVCRGxID = strAbnormalVCRGxID

        strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_POSITION))
        Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)
        MyCVNewWord.mnPLCChangeData = nGetHibyte
        MyCVNewWord.mnGxAbnormalPosition = nGetLibyte
        'MyCVNewWord.mnGxAbnormalPosition = g_anCV_New_ZRWord(eCVDevicNo.GX_ABNORMAL_POSITION)
    End Sub

    Public Sub ReadUnloadStatusTotalGXQty(ByVal sZRDevicNo As Short)
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(g_anCV_New_ZRWord(sZRDevicNo))
        Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)

        'Unload Status ==> 1:Normal,2:Abnormal
        If sZRDevicNo = eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_1 Then
            MyCVNewWord.mnUnloadStatus(PORTNO1) = nGetHibyte
            MyCVNewWord.mnGlassQty(PORTNO1) = nGetLibyte
        ElseIf sZRDevicNo = eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_2 Then
            MyCVNewWord.mnUnloadStatus(PORTNO2) = nGetHibyte
            MyCVNewWord.mnGlassQty(PORTNO2) = nGetLibyte
        ElseIf sZRDevicNo = eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_3 Then
            MyCVNewWord.mnUnloadStatus(PORTNO3) = nGetHibyte
            MyCVNewWord.mnGlassQty(PORTNO3) = nGetLibyte
        ElseIf sZRDevicNo = eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_4 Then
            MyCVNewWord.mnUnloadStatus(PORTNO4) = nGetHibyte
            MyCVNewWord.mnGlassQty(PORTNO4) = nGetLibyte
        End If
    End Sub

    Public Function ReadGlassJudgment(ByVal nPortNo As Integer) As Integer
        'Glass Judgment ==> 0:NonInspection,1:OK,2:Gray,3:NG
        Select Case nPortNo
            Case 1
                MyCVNewWord.mnGlassJudgment(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.GLASS_JUDGMENT_1)
            Case 2
                MyCVNewWord.mnGlassJudgment(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.GLASS_JUDGMENT_2)
            Case 3
                MyCVNewWord.mnGlassJudgment(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.GLASS_JUDGMENT_3)
            Case 4
                MyCVNewWord.mnGlassJudgment(nPortNo) = g_anCV_New_ZRWord(eCVDevicNo.GLASS_JUDGMENT_4)
        End Select

        ReadGlassJudgment = MyCVNewWord.mnGlassJudgment(nPortNo)
    End Function

    Public Function ReadPSHGrade(ByVal nPortNo As Integer) As String
        Select Case nPortNo
            Case 1
                MyCVNewWord.mstrPSHGrade(nPortNo) = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PS_H_GRADE_1))
            Case 2
                MyCVNewWord.mstrPSHGrade(nPortNo) = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PS_H_GRADE_2))
            Case 3
                MyCVNewWord.mstrPSHGrade(nPortNo) = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PS_H_GRADE_3))
            Case 4
                MyCVNewWord.mstrPSHGrade(nPortNo) = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PS_H_GRADE_4))
        End Select

        ReadPSHGrade = MyCVNewWord.mstrPSHGrade(nPortNo)
    End Function

    Public Function ReadProductCode(ByVal nPortNo As Integer) As String
        Dim strProductCode As String = ""

        Select Case nPortNo
            Case PORTNO1
                strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_1)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_2)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_3)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_4)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_5)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_6)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_7)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_8)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_9)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_10)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_11)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_12)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P1_13))
            Case PORTNO2
                strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_1)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_2)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_3)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_4)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_5)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_6)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_7)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_8)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_9)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_10)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_11)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_12)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P2_13))
            Case PORTNO3
                strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_1)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_2)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_3)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_4)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_5)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_6)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_7)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_8)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_9)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_10)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_11)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_12)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P3_13))
            Case PORTNO4
                strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_1)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_2)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_3)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_4)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_5)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_6)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_7)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_8)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_9)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_10)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_11)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_12)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.PRODUCT_CODE_P4_13))
        End Select

        'MyCVNewWord.mstrProductCode(nPortNo) = strProductCode
        ReadProductCode = strProductCode
    End Function

    Public Function ReadGlassID(ByVal nPortNo As Integer) As String
        Dim strGlassID As String = ""

        Select Case nPortNo
            Case PORTNO1
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P1_1)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P1_2)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P1_3)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P1_4)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P1_5)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P1_6))
            Case PORTNO2
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P2_1)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P2_2)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P2_3)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P2_4)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P2_5)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P2_6))
            Case PORTNO3
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P3_1)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P3_2)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P3_3)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P3_4)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P3_5)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P3_6))
            Case PORTNO4
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P4_1)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P4_2)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P4_3)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P4_4)) _
                & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P4_5)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GXID_P4_6))
        End Select
        'MyCVNewWord.mstrGlassID(nPortNo) = strGlassID
        ReadGlassID = strGlassID
    End Function

    Public Function ReadOPID(ByVal nPortNo As Integer) As String
        Dim strOPID As String = ""

        Select Case nPortNo
            Case 1
                strOPID = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.OPID_1))
            Case 2
                strOPID = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.OPID_2))
            Case 3
                strOPID = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.OPID_3))
            Case 4
                strOPID = ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.OPID_4))
        End Select

        'MyCVNewWord.mstrOPID(nPortNo) = strOPID
        ReadOPID = strOPID
    End Function

    Public Sub ReadGxUnmatchReport()
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0


        'Unmatch Status ==> 1:NoDatabutSensing,2:HaveDataNutNoSensing
        strData = HexLeadZero(g_anCV_New_ZRWord(eCVDevicNo.GLASS_UNMATCH_REPORT))
        Call GetWordBlock(strData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
        MyCVNewWord.mnUnmatchStatus = nFourthWord
        MyCVNewWord.mnUnmatchPortNumber = nThirdWord

        Call GetHIbyteLibyte(strData, nGetHibyte, nGetLibyte)
        MyCVNewWord.mnUnmatchSlotNumber = nGetLibyte
    End Sub

    Public Sub ReadGlassflowInReport()
        Dim strGXFlowInReportProductCode As String = ""
        Dim strGXFlowInReportGXID As String = ""

        strGXFlowInReportProductCode = strGXFlowInReportProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE1)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE2)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE3)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE4)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE5)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE6)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE7)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE8)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE9)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE10)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE11)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE12)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PRODUCT_CODE13))

        strGXFlowInReportGXID = strGXFlowInReportGXID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_GX_ID1)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_GX_ID2)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_GX_ID3)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_GX_ID4)) _
        & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_GX_ID5)) & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_GX_ID6))

        MyCVNewWord.mnGXFlowInReportPortIndex = g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_PORT_IDX)
        MyCVNewWord.mstrGXFlowInReportProductCode = strGXFlowInReportProductCode
        MyCVNewWord.mstrGXFlowInReportGXID = strGXFlowInReportGXID
        MyCVNewWord.mnGXFlowInReportSlotNo = g_anCV_New_ZRWord(eCVDevicNo.GX_F_IN_SLOT_NUMBER)
    End Sub

    Public Sub ReadGlassflowOutReport(ByVal nPort As Integer)
        Dim nFor As Integer
        Dim strCSTProductCode As String = ""
        Dim strGxID As String = ""

        Select Case nPort
            Case 1
                MyCVNewWord.mnGXFlowOutReportPortIndex(nPort) = g_anCV_New_ZRWord(eCVDevicNo.GX_F_OUT_PORT_IDX_P1)
                For nFor = eCVDevicNo.GX_F_OUT_PRODUCT_CODE1_P1 To eCVDevicNo.GX_F_OUT_PRODUCT_CODE13_P1
                    strCSTProductCode = strCSTProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next

                For nFor = eCVDevicNo.GX_F_OUT_GX_ID1_P1 To eCVDevicNo.GX_F_OUT_GX_ID2_P1
                    strGxID = strGxID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next
                MyCVNewWord.mnGXFlowOutReportSlotNo(nPort) = g_anCV_New_ZRWord(eCVDevicNo.GX_F_OUT_SLOT_NUMBER_P1)
            Case 2
                MyCVNewWord.mnGXFlowOutReportPortIndex(nPort) = g_anCV_New_ZRWord(eCVDevicNo.GX_F_OUT_PORT_IDX_P2)
                For nFor = eCVDevicNo.GX_F_OUT_PRODUCT_CODE1_P2 To eCVDevicNo.GX_F_OUT_PRODUCT_CODE13_P2
                    strCSTProductCode = strCSTProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next

                For nFor = eCVDevicNo.GX_F_OUT_GX_ID1_P2 To eCVDevicNo.GX_F_OUT_GX_ID2_P2
                    strGxID = strGxID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next
                MyCVNewWord.mnGXFlowOutReportSlotNo(nPort) = g_anCV_New_ZRWord(eCVDevicNo.GX_F_OUT_SLOT_NUMBER_P2)
            Case 3
                MyCVNewWord.mnGXFlowOutReportPortIndex(nPort) = g_anCV_New_ZRWord(eCVDevicNo.GX_F_OUT_PORT_IDX_P3)
                For nFor = eCVDevicNo.GX_F_OUT_PRODUCT_CODE1_P3 To eCVDevicNo.GX_F_OUT_PRODUCT_CODE13_P3
                    strCSTProductCode = strCSTProductCode & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next

                For nFor = eCVDevicNo.GX_F_OUT_GX_ID1_P3 To eCVDevicNo.GX_F_OUT_GX_ID2_P3
                    strGxID = strGxID & ConvertHiLowASCIIToString(g_anCV_New_ZRWord(nFor))
                Next
                MyCVNewWord.mnGXFlowOutReportSlotNo(nPort) = g_anCV_New_ZRWord(eCVDevicNo.GX_F_OUT_SLOT_NUMBER_P3)
        End Select

        MyCVNewWord.mstrGXFlowOutProductCode(nPort) = strCSTProductCode
        MyCVNewWord.mstrGXFlowOutGXID(nPort) = strGxID
    End Sub

    Public Sub ReadCassetteDummyCancelResult()
        MyCVNewWord.mnDummyCacncelResult = g_anCV_New_ZRWord(eCVDevicNo.DUMMY_CANCEL_RESULT)
    End Sub

    Public Sub ReadCVCassetteRemoveReportByZRWord()
        MyCVNewWord.mnCVCassetteRemoveReportByPortNoWord = g_anCV_New_ZRWord(eCVDevicNo.CV_CST_REMOVE_REPORT)
    End Sub

#End Region

End Module
