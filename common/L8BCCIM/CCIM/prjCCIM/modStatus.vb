Imports prjSECS.clsEnumCtl
Public Module modStatus


    ' changed log
    '
    ' 08/05/2003 S1F75 unload request, changed to passive step. need to drive by app (CassetteUnclamped)
    '            (apply to all cassette type whatever wired or normal cassette)
    '
    ' 08/08/2003 delay the addlot till LoadComplete is executed
    '            only loader port support Online monitor mode
    '
    ' 08/09/2003 add interface RemoveSlotFromLoader
    '            for I-type loader, SlotProcessCompleted will not remove the slot from the loader (use RemoveSlotFromLoader)
    '            SlotProcessCompleted, for I-type loader, do not refer to lot information for glass data
    '            change ReportAlarm to stateless
    '
    ' 08/15/2003 InsertSlotToUnloader, filled slot from top -> bottom
    '            InsertSlotToUnloader & RemoveSlotFromLoader is alsp apply to U-Type loader/unloader.
    '
    ' 09/05/2003 Add HSMS connect/disconnect, once the HSMS disconnected, do not send message till connected back on
    '
    ' 10/14/2003 1. MyDispatcher, add check insert sequence during scan period
    '            2. Can jump to Unload request when cassette status is "Waiting for process"
    '
    ' 10/16/2003 Manual port need to report S6F65 (but no S6F91)
    '
    ' 01/30/2004 Phase II changes
    '            Under monitor mode, the start command is sent only once
    '
    ' 02/05/2004 S6F65 change to dynamic (no check sequence)
    '            (Phase I already modified, forget to sync)
    '
    ' 02/09/2004 CassetteProcessEnd, add LoHold flag
    '
    ' 05/06/2004 SlotProcessCompleted, need to store ItemData by slot
    '            cannot use global storage (EQs have the chance to report at the same time)
    '
    ' 05/14/2004 ManualPortProcessCompleted, add 3 parameters to report LineID/ToolID1/ToolID2
    '
    ' 05/26/2004 S2F21 add CIMMSG
    '
    ' Revised for AUO C10
    ' 08/10/2004 1. support "cst on port" online
    '            2. port disable report (enable->load request)
    '
    ' 08/11/2004 1. monitor mode, START command could be received many times
    '
    ' 08/24/2004 1. add datetime to RecipeChanged
    '            2. online->offline, line is disconnected, should enable to report Offline
    '
    ' 09/09/2004 1. if slot is not processed, clear GGRADE/DGRADE/RDGRADE/RWKFLAG/SCRPFLAG/FIRMFLAG
    '            when process end
    '            2. if HSMS is not connected(unlpug line), when get offline (UnitInfoChanged),post offline event directly
    '
    ' 12/23/2004 1. Maintain PortStatus
    '
    ' Revised for AUO C11 CF
    ' 03/10/2006 1. Queue the CassetteStatusChanged
    '
    ' 03/13/2006 1. ReportAlarm release which happened in online and release in offline
    '
    ' 03/16/2006 1. SubStatus = Blank when alarm is occurred and restore back to "W" if alarm is released
    '
    ' 06/02/2006 1. support CassetteRemoved at any time
    '
    ' 07/09/2006 1. ReportAlarmExt bug, cannot take alarm to report from last one in collection
    '               the client could call several times before CCIM report out
    '
    ' 07/31/2006 1. report LogOff even cassette on port
    '
    ' 08/02/2006 1. Public FillLot to client app
    '
    ' 10/10/2006 1. Do not drive state when auto sync time hourly (S2F17)
    '
    ' 11/23/2006 Add/GetReportLotStatus: add PortNo to prevent the disorder of multiple lotstatus report
    '




    Public g_nCurrOnlineMode As prjSECS.clsEnumCtl.eRemoteStatus       ' current online mode
    Public g_nChangedMode As prjSECS.clsEnumCtl.eRemoteStatus       ' mode expected to switch

    Public g_fTryOnOffLine As Boolean
    Public g_fHSMSConnected As Boolean

    Public g_colReplyStateCtl As New Collection
    Public g_colEventQueue As New Collection
    Public g_colBufferMsg As New Collection
    Public g_colInsertSeq As New Collection
    Public g_colTimer As New Collection
    Public g_colGlassRun As New Collection      ' slotno waiting to report S6F91
    Public g_colWorkAPD As New Collection       ' slotno waiting to report S6F65
    Public g_colUnitNo As New Collection        ' unitno waiting to report S1F63
    Public g_colRecipeChanged As New Collection ' recipe waiting to report S1F97
    Public g_colRecipeLastModifyInfo As New Collection  'Recipe last modify info waiting to report S7F68
    Public MyRecipeParameterReport As New prjSECS.clsRecipeStructure  'Recipe parameter report waiting to report S7F3

    Public g_colLotStatus As New Collection
    Public g_fOfflineReq As Boolean
    Public g_fOfflineReqPending As Boolean
    Public g_afCassetteRemoveReq() As Boolean
    Public g_afCassetteUnloadReq() As Boolean
    Public g_afCSTVLoad() As Boolean
    Public m_vItemS6F69() As prjSECS.clsItemFormat

    Public Const MAIN_UNIT = 0
    Public Const MAIN_RST = 1
    Public Const MAX_SLOTS = 56
    Public Const MAX_CHIPS = 72

    Public Const LEN_RECIPEID = 32
    Public Const LEN_CASID = 6
    Public Const LEN_OPID = 10

    Public Const CMD_START = "$START"
    Public Const CMD_CANCEL = "$CANCEL"
    Public Const CMD_SUSPND = "$SUSPND"
    Public Const CMD_RESUME = "$RESUME"
    ' definition of load state/unload state
    Public Const LDSTA_LOADREQUEST = 0
    Public Const LDSTA_LOADCOMPLETE = 1
    Public Const LDSTA_DISABLED = 2
    Public Const ULDSTA_UNLOADREQUEST = 0
    Public Const ULDSTA_UNLOADCOMPLETE = 1

    Public g_fRemotePause() As Boolean
    Public g_fRemoteResume() As Boolean
    Public g_fIsAreYouThereSend As Boolean


    Public Enum enumDebugOutput
        DEBUG_NONE = 0
        DEBUG_WARN = 1
        DEBUG_ERROR = 2
        DEBUG_EVENT = 3
    End Enum
    Enum eLogType
        TYPE_PROPERTY
        TYPE_SYS
        TYPE_METHOD
        TYPE_EVENT
        TYPE_ERR
        TYPE_OPSET
    End Enum
    Enum eOfflineStep
        OFL_AYT = 1
        OFL_REQDATE = 2
        OFL_ONLINESUMMARY = 3
        OFL_RSTREPORT = 4
        OFL_PORTSTATE = 5
    End Enum
    Enum eOnLineStep
        ONL_LOADREQ = 1
        ONL_LOADCOMPLETE = 2
        ONL_REQLOTDATA = 3
        ONL_LOTDATA = 4
        ONL_REMOTECMD = 5
        ONL_UNLOADREQ = 6
        ONL_UNLOADCOMPLETE = 7

        ' ----- place unexpected msg here -----
        ONL_REMOTECANCEL_X = 8
        ONL_EQSTATUS_OFFLINE = 9
        ONL_CONVERSATION_TIMEOUT = 10
        ' -------------------------------------

        ' EQ initiated -----
        ONL_ANYTIME_WORKAPD = 11
        ONL_ANYTIME_GLASSRUN = 12
        ONL_ANYTIME_UNITSTATUS = 13
        ONL_ANYTIME_EQSTATUS = 14
        ONL_ANYTIME_ONLINEMODECHANGE = 15
        ONL_ANYTIME_LOTSTATUS = 16
        ONL_ANYTIME_PORTSTATE = 17
        ONL_ANYTIME_LOADREQ = 18
        ONL_ANYTIME_RECIPEMODIFIED = 19
        ONL_ANYTIME_WORKIDUNMATCH = 20
        ONL_ANYTIME_ALARM = 21
        ONL_ANYTIME_GLASSERASE = 22
        ONL_ANYTIME_LOTAPD = 23
        ONL_ANYTIME_OFFLINEALARM = 24
        ONL_ANYTIME_LOADCOMPLETE = 25
        'ONL_ANYTIME_LOADCOMPLETE = 2
        ONL_ANYTIME_CSTPROCESSEND = 26
        ONL_ANYTIME_RECIPE_PARAMETER_REPORT = 27
        ONL_ANYTIME_RECIPE_LAST_MODIFY_REPORT = 28
        ONL_ANYTIME_UNLOADREQUEST = 29
        ONL_ANYTIME_REQLOTDATA = 30
        ' Host initiated  -----
        ONL_QUERY_FORMATTED_STATUS = 31
    End Enum
    Enum eTimerType
        TIMER_ONLINE = 1
        TIMER_WAITS7F65 = 2
        TIMER_WAITS2F21 = 3
        TIMER_SENDS7F71 = 4
    End Enum

 

    Const NUM_TABLES = 1
    Public Const TABLE_OFFLINE = 0
    Public Const TABLE_ONLINE = 1

    Public Const MAX_OFFLINE = eOfflineStep.OFL_PORTSTATE
    Public Const MAX_ONLINE = eOnLineStep.ONL_QUERY_FORMATTED_STATUS
    Public Const MAX_MESSAGES = 31

    Public Const START_OF_ABNORMAL = eOnLineStep.ONL_REMOTECANCEL_X
    Public Const END_OF_ABNORMAL = eOnLineStep.ONL_CONVERSATION_TIMEOUT

    Private MyOffLineStepDesc(MAX_OFFLINE) As String
    Private MyOnLineDesc(MAX_ONLINE) As String

    Public MyOffLineTable(MAX_OFFLINE) As clsStateTable
    Public MyOnLineTable(MAX_ONLINE) As clsStateTable

    Private MyMSGTable(MAX_MESSAGES) As clsMessageItem
    Private MyMaxTableSteps(NUM_TABLES) As Integer

    Public MyUnitInfo() As prjSECS.clsUnitStructure   ' 0-based array
    Public MyPortInfo() As prjSECS.clsPortStructure     ' 1-based array
    Public MyLotInfo() As prjSECS.clsLotStructure       ' 1-based array
    Public MyProcessEndInfo() As prjSECS.clsLotStructure

    Public MyPortStateControl() As clsStateControl     ' state control for each port

    Public g_nCTStream As Integer          ' S9F13 stream/function expect
    Public g_nCTFunction As Integer        ' S9F13
    Public g_fInsideEventTrigger As Boolean

    Public g_nMaxPorts As Integer           ' max ports
    Public g_nMaxUnits As Integer           ' total units in machine
    Public g_nMaxLots As Integer            ' number of max lots
    Public g_nTotalLots As Integer          ' total lots received
    Public g_fRunMGVBufCIM As Boolean       ' whether run MGV buffer CIM sequence

    'Public g_fAlarm As Boolean              ' alarm exist ?
    'Public MyAlarmInfo As prjsecs.clsAlarmStructure
    'Private m_nStatusBeforeAlarm As Integer
    'Public g_fAbortRequest As Boolean       ' abort button

    Private m_nCurrentPortPriority As Integer

    Private Sub InitOffLineState(ByVal nStep As Integer, ByVal nStream As Integer, ByVal nFunc As Integer, ByVal fActive As Boolean, ByVal fReply As Boolean, ByVal nNextStep As Integer)
        MyOffLineTable(nStep).StreamID = nStream
        MyOffLineTable(nStep).FunctionID = nFunc
        MyOffLineTable(nStep).Active = fActive
        MyOffLineTable(nStep).Reply = fReply
        MyOffLineTable(nStep).NextStep = nNextStep
    End Sub

    Private Sub InitOnLineState(ByVal nStep As Integer, ByVal nStream As Integer, ByVal nFunc As Integer, ByVal fActive As Boolean, ByVal fReply As Boolean, ByVal nNextStep As Integer)
        MyOnLineTable(nStep).StreamID = nStream
        MyOnLineTable(nStep).FunctionID = nFunc
        MyOnLineTable(nStep).Active = fActive
        MyOnLineTable(nStep).Reply = fReply
        MyOnLineTable(nStep).NextStep = nNextStep
    End Sub

    Private Sub InitStateTable()
        ' offline->online sequence
        InitOffLineState(eOfflineStep.OFL_AYT, 1, 1, False, True, 1)
        InitOffLineState(eOfflineStep.OFL_REQDATE, 2, 17, True, True, 1)
        InitOffLineState(eOfflineStep.OFL_ONLINESUMMARY, 1, 89, True, True, 1)
        InitOffLineState(eOfflineStep.OFL_RSTREPORT, 1, 65, True, True, 1)
        InitOffLineState(eOfflineStep.OFL_PORTSTATE, 1, 73, True, True, 1)        ' 12/10/2003 only for disabled report

        ' online control/monitor sequence
        InitOnLineState(eOnLineStep.ONL_LOADREQ, 1, 73, True, True, 1)
        InitOnLineState(eOnLineStep.ONL_LOADCOMPLETE, 1, 73, False, True, 1)
        InitOnLineState(eOnLineStep.ONL_REQLOTDATA, 7, 71, False, True, 1)           ' should wait til "map complete"
        InitOnLineState(eOnLineStep.ONL_LOTDATA, 7, 65, False, False, 1)             ' for online control mode
        InitOnLineState(eOnLineStep.ONL_REMOTECMD, 2, 21, False, False, 1)
        InitOnLineState(eOnLineStep.ONL_UNLOADREQ, 1, 75, False, True, 1)            ' 08/05/2003 change to passive step, wait action from app
        InitOnLineState(eOnLineStep.ONL_UNLOADCOMPLETE, 1, 75, False, True, -eOnLineStep.ONL_LOADREQ)

        ' ----- abnormal case searching -------------------------
        'InitOnLineState(eOnLineStep.ONL_REMOTECANCEL_X, 2, 21, True, False, -eOnLineStep.ONL_UNLOADREQ)
        'InitOnLineState(eOnLineStep.ONL_EQSTATUS_OFFLINE, 1, 65, True, True, 0)
        'InitOnLineState(eOnLineStep.ONL_CONVERSATION_TIMEOUT, 9, 13, True, False, -eOnLineStep.ONL_UNLOADREQ)

        InitOnLineState(eOnLineStep.ONL_REMOTECANCEL_X, 2, 21, True, False, -eOnLineStep.ONL_UNLOADREQ)
        InitOnLineState(eOnLineStep.ONL_EQSTATUS_OFFLINE, 1, 65, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_CONVERSATION_TIMEOUT, 9, 13, True, False, -eOnLineStep.ONL_UNLOADREQ)

        ' ----- end of abnormal case ----------------------------

        ' EQ initiated anytime event
        InitOnLineState(eOnLineStep.ONL_ANYTIME_WORKAPD, 6, 65, False, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_GLASSRUN, 6, 91, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_UNITSTATUS, 1, 65, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_EQSTATUS, 1, 65, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_ONLINEMODECHANGE, 1, 65, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_LOTSTATUS, 1, 67, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_CSTPROCESSEND, 1, 67, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_PORTSTATE, 1, 73, True, True, 0)     ' port enable/disable
        InitOnLineState(eOnLineStep.ONL_ANYTIME_LOADREQ, 1, 73, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_LOADREQ, 1, 73, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_LOADCOMPLETE, 1, 73, True, True, 0) 'L7B U Mode L/U Type Change Report
        InitOnLineState(eOnLineStep.ONL_ANYTIME_UNLOADREQUEST, 7, 71, True, True, 0) 'L7B U Mode L/U Type Change Report

        InitOnLineState(eOnLineStep.ONL_ANYTIME_RECIPEMODIFIED, 1, 97, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_RECIPE_LAST_MODIFY_REPORT, 7, 67, True, False, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_RECIPE_PARAMETER_REPORT, 7, 3, True, False, 0)

        InitOnLineState(eOnLineStep.ONL_ANYTIME_WORKIDUNMATCH, 6, 87, True, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_ALARM, 5, 65, False, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_GLASSERASE, 6, 85, False, True, 0)
        InitOnLineState(eOnLineStep.ONL_ANYTIME_LOTAPD, 6, 69, False, True, 0) 'No Use
        InitOnLineState(eOnLineStep.ONL_ANYTIME_OFFLINEALARM, 5, 65, False, True, 0)

        ' Host initiated, used as inserted sequence (can reply directly such as S2F31 ???)
        InitOnLineState(eOnLineStep.ONL_QUERY_FORMATTED_STATUS, 1, 5, False, False, 0)
    End Sub

    Private Sub InitMessageItem(ByVal idx As Integer, ByVal nStream As Integer, ByVal nFunction As Integer, ByVal fReplyExpected As Boolean, ByVal fHostSend As Boolean)
        MyMSGTable(idx).StreamID = nStream
        MyMSGTable(idx).FunctionID = nFunction
        MyMSGTable(idx).RelyExpected = fReplyExpected
        MyMSGTable(idx).HOSTSend = fHostSend
    End Sub

    Private Sub InitMessageTable()
        ' list all transactions
        ' Index, Stream, Function, ReplyExpected, HostSend
        InitMessageItem(1, 1, 1, True, False)
        InitMessageItem(2, 1, 5, True, True)
        InitMessageItem(3, 1, 65, True, False)
        InitMessageItem(4, 1, 67, True, False)
        InitMessageItem(5, 1, 73, True, False)
        InitMessageItem(6, 1, 75, True, False)
        InitMessageItem(7, 1, 87, True, True)
        InitMessageItem(8, 1, 89, True, False)
        InitMessageItem(9, 1, 97, True, False)
        InitMessageItem(10, 2, 17, True, False)

        InitMessageItem(11, 2, 21, True, True)
        InitMessageItem(12, 2, 25, True, True)

        InitMessageItem(13, 5, 65, True, False)
        InitMessageItem(14, 6, 65, True, False)
        InitMessageItem(15, 6, 69, True, False)
        InitMessageItem(16, 6, 85, True, False)
        InitMessageItem(17, 6, 87, True, False)
        InitMessageItem(18, 6, 91, True, False)

        InitMessageItem(19, 7, 65, True, True)

        InitMessageItem(20, 7, 71, True, False)

        InitMessageItem(21, 9, 1, False, False)
        InitMessageItem(22, 9, 3, False, False)
        InitMessageItem(23, 9, 5, False, False)
        InitMessageItem(24, 9, 7, False, False)
        InitMessageItem(25, 9, 9, False, False)
        InitMessageItem(26, 9, 11, False, False)
        InitMessageItem(27, 9, 13, False, False)
        InitMessageItem(28, 10, 1, False, False)

        InitMessageItem(29, 10, 5, False, True)

        'Add By William
        InitMessageItem(30, 7, 3, True, True)
        InitMessageItem(31, 7, 67, True, True)

    End Sub

    Public Sub InitEquipment()
        Dim nFor As Integer


        For nFor = 0 To MAX_OFFLINE
            MyOffLineTable(nFor) = New clsStateTable
        Next

        For nFor = 0 To MAX_ONLINE
            MyOnLineTable(nFor) = New clsStateTable
        Next

        For nFor = 0 To MAX_MESSAGES
            MyMSGTable(nFor) = New clsMessageItem
        Next

        MyMaxTableSteps(TABLE_OFFLINE) = MAX_OFFLINE
        MyMaxTableSteps(TABLE_ONLINE) = MAX_ONLINE

        MyOffLineStepDesc(eOfflineStep.OFL_AYT) = "Are You There"
        MyOffLineStepDesc(eOfflineStep.OFL_REQDATE) = "REQ Date Time"
        MyOffLineStepDesc(eOfflineStep.OFL_ONLINESUMMARY) = "OnLine Summary Report"
        MyOffLineStepDesc(eOfflineStep.OFL_RSTREPORT) = "RST Status Report"
        MyOffLineStepDesc(eOfflineStep.OFL_PORTSTATE) = "Port State"

        MyOnLineDesc(eOnLineStep.ONL_LOADREQ) = "Load REQ"
        MyOnLineDesc(eOnLineStep.ONL_LOADCOMPLETE) = "Load Complete"
        MyOnLineDesc(eOnLineStep.ONL_REQLOTDATA) = "REQ Lot Data"
        MyOnLineDesc(eOnLineStep.ONL_LOTDATA) = "Host Send Lot Data"
        MyOnLineDesc(eOnLineStep.ONL_REMOTECMD) = "Remote Command"

        MyOnLineDesc(eOnLineStep.ONL_UNLOADREQ) = "Unload REQ"
        MyOnLineDesc(eOnLineStep.ONL_UNLOADCOMPLETE) = "Unload Complete"
        MyOnLineDesc(eOnLineStep.ONL_REMOTECANCEL_X) = "Remote Cancel"
        MyOnLineDesc(eOnLineStep.ONL_EQSTATUS_OFFLINE) = "OffLine Request"

        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_WORKAPD) = "Work APD Report"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_REQLOTDATA) = "V Lot Download"

        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_GLASSRUN) = "Glass run Report"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_UNITSTATUS) = "Unit Status - Anytime"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_EQSTATUS) = "EQ Status - Anytime"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_ONLINEMODECHANGE) = "Online mode change"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_LOTSTATUS) = "Lot Status"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_CSTPROCESSEND) = "CST Process END"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_PORTSTATE) = "Port Enable/Disable - Anytime"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_LOADREQ) = "Port Enable - Load Request"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_LOADCOMPLETE) = "Port Enable - Load Complete"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_UNLOADREQUEST) = "OnLine Request Unload CST"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_RECIPEMODIFIED) = "Recipe Modified"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_RECIPE_LAST_MODIFY_REPORT) = "Recipe Last Modify Info Report"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_RECIPE_PARAMETER_REPORT) = "Recipe Parameter Report"

        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_WORKIDUNMATCH) = "Work ID Unmatch"
        MyOnLineDesc(eOnLineStep.ONL_CONVERSATION_TIMEOUT) = "Conversation Timeout"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_ALARM) = "Alarm Report"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_GLASSERASE) = "Glass Erase Report"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_LOTAPD) = "Lot APD Report"
        MyOnLineDesc(eOnLineStep.ONL_ANYTIME_OFFLINEALARM) = "Offline Alarm Release"

        MyOnLineDesc(eOnLineStep.ONL_QUERY_FORMATTED_STATUS) = "Formatted Status"

        Call InitStateTable()         ' init state control table
        Call InitMessageTable()       ' init message table
    End Sub

    Public Function GetSeqName(ByVal nSeq As Integer) As String
        GetSeqName = MyOnLineDesc(nSeq)
    End Function

    Public Function GetPortPriority() As Integer
        m_nCurrentPortPriority = m_nCurrentPortPriority + 1
        If m_nCurrentPortPriority >= 32767 Then
            m_nCurrentPortPriority = 1
        End If
        GetPortPriority = m_nCurrentPortPriority
    End Function

    Public Function OffLineDesc(ByVal nStep As Integer) As String
        OffLineDesc = MyOffLineStepDesc(nStep)
    End Function

    Public Function OnLineDesc(ByVal nStep As Integer) As String
        OnLineDesc = MyOnLineDesc(nStep)
    End Function

    Public Sub RemoveSlotInfo(ByVal idx As Integer, ByVal nSlotNo As Integer)
        Dim i As Integer

        MyLotInfo(idx).Slots(nSlotNo).SlotNo = 0
        MyLotInfo(idx).Slots(nSlotNo).GlassID = ""
        MyLotInfo(idx).Slots(nSlotNo).GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO
        MyLotInfo(idx).Slots(nSlotNo).DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
        MyLotInfo(idx).Slots(nSlotNo).DMQCToolID = "'"
        MyLotInfo(idx).Slots(nSlotNo).LastOperationID = ""
        MyLotInfo(idx).Slots(nSlotNo).ProcessToolID = ""
        MyLotInfo(idx).Slots(nSlotNo).PLineID = ""
        MyLotInfo(idx).Slots(nSlotNo).Rework = False
        MyLotInfo(idx).Slots(nSlotNo).Scrap = prjSECS.clsEnumCtl.eScrapType.NONE
        MyLotInfo(idx).Slots(nSlotNo).FIRemark = False
        MyLotInfo(idx).Slots(nSlotNo).DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
        MyLotInfo(idx).Slots(nSlotNo).ProcFlag = False
        MyLotInfo(idx).Slots(nSlotNo).IsGlassProecssed = False

        MyProcessEndInfo(idx).Slots(nSlotNo).SlotNo = 0
        MyProcessEndInfo(idx).Slots(nSlotNo).GlassID = ""
        MyProcessEndInfo(idx).Slots(nSlotNo).GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO
        MyProcessEndInfo(idx).Slots(nSlotNo).DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
        MyProcessEndInfo(idx).Slots(nSlotNo).DMQCToolID = "'"
        MyProcessEndInfo(idx).Slots(nSlotNo).LastOperationID = ""
        MyProcessEndInfo(idx).Slots(nSlotNo).ProcessToolID = ""
        MyProcessEndInfo(idx).Slots(nSlotNo).PLineID = ""
        MyProcessEndInfo(idx).Slots(nSlotNo).Rework = False
        MyProcessEndInfo(idx).Slots(nSlotNo).Scrap = prjSECS.clsEnumCtl.eScrapType.NONE
        MyProcessEndInfo(idx).Slots(nSlotNo).FIRemark = False
        MyProcessEndInfo(idx).Slots(nSlotNo).DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
        MyProcessEndInfo(idx).Slots(nSlotNo).ProcFlag = False
        MyProcessEndInfo(idx).Slots(nSlotNo).IsGlassProecssed = False

        For i = 1 To MAX_CHIPS
            MyLotInfo(idx).Slots(nSlotNo).ChipGrade(i) = prjSECS.clsEnumCtl.eGlassGrade.NO
            MyProcessEndInfo(idx).Slots(nSlotNo).ChipGrade(i) = prjSECS.clsEnumCtl.eGlassGrade.NO
        Next i


    End Sub

    Public Function RemoveLot(ByVal nPortPos As Integer) As Integer
        Dim idx As Integer
        Dim i As Integer

        idx = SearchLotByPort(nPortPos)

        If idx > 0 Then
            ' clean up all information
            MyLotInfo(idx).PortPosition = 0
            MyLotInfo(idx).CassetteID = ""
            MyLotInfo(idx).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE
            MyLotInfo(idx).ProductCode = ""
            MyLotInfo(idx).ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_NONE
            MyLotInfo(idx).MeasurementID = ""
            MyLotInfo(idx).OperatorID = ""
            MyLotInfo(idx).OperationID = ""
            MyLotInfo(idx).RecipeName = ""
            MyLotInfo(idx).RecipeCode = False
            MyLotInfo(idx).PPIDChanged = False
            MyLotInfo(idx).RecipeNeedConfirm = False   ' 08/13/2003
            MyLotInfo(idx).ProcessEndCode = prjSECS.clsEnumCtl.eProcessENDCode.NONE
            MyLotInfo(idx).LotCancel = False
            MyLotInfo(idx).IsLotDataReceived = False
            MyLotInfo(idx).UnderSlotsSelection = False

            MyProcessEndInfo(idx).PortPosition = 0
            MyProcessEndInfo(idx).CassetteID = ""
            MyProcessEndInfo(idx).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE
            MyProcessEndInfo(idx).ProductCode = ""
            MyProcessEndInfo(idx).ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_NONE
            MyProcessEndInfo(idx).MeasurementID = ""
            MyProcessEndInfo(idx).OperatorID = ""
            MyProcessEndInfo(idx).OperationID = ""
            MyProcessEndInfo(idx).RecipeName = ""
            MyProcessEndInfo(idx).RecipeCode = False
            MyProcessEndInfo(idx).PPIDChanged = False
            MyProcessEndInfo(idx).RecipeNeedConfirm = False   ' 08/13/2003
            MyProcessEndInfo(idx).ProcessEndCode = prjSECS.clsEnumCtl.eProcessENDCode.NONE
            MyProcessEndInfo(idx).LotCancel = False
            MyProcessEndInfo(idx).IsLotDataReceived = False
            MyProcessEndInfo(idx).UnderSlotsSelection = False

            For i = 1 To MAX_SLOTS
                RemoveSlotInfo(idx, i)

            Next i

            g_nTotalLots = g_nTotalLots - 1
        End If
    End Function

    ' return lot index by Port No
    Public Function SearchLotByPort(ByVal nPortPos As Integer) As Integer
        Dim idx As Integer = 1
        Dim nCount As Integer = 1
        Dim fFound As Boolean = False

        ' init....
        SearchLotByPort = -1

        If g_nTotalLots = 0 Then
            Exit Function
        End If

        'idx = 1
        'nCount = 1
        'fFound = False
        While nCount <= g_nMaxLots And Not fFound
            If MyLotInfo(idx).PortPosition = nPortPos Then
                fFound = True
                SearchLotByPort = idx
            Else
                idx = idx + 1
                If idx > g_nMaxLots Then
                    idx = 1
                End If
            End If
            nCount = nCount + 1
        End While
    End Function

    Public Sub ClearAllQueue()
        Dim i As Integer

        For i = 1 To g_colEventQueue.Count
            g_colEventQueue.Remove(1)
        Next i

        For i = 1 To g_colReplyStateCtl.Count
            g_colReplyStateCtl.Remove(1)
        Next i

        For i = 1 To g_colBufferMsg.Count
            g_colBufferMsg.Remove(1)
        Next i

        For i = 1 To g_colInsertSeq.Count
            g_colInsertSeq.Remove(1)
        Next i

        For i = 1 To g_colTimer.Count
            g_colTimer.Remove(1)
        Next i

        For i = 1 To g_colGlassRun.Count
            g_colGlassRun.Remove(1)
        Next i

        For i = 1 To g_colWorkAPD.Count
            g_colWorkAPD.Remove(1)
        Next i

        For i = 1 To g_colUnitNo.Count
            g_colUnitNo.Remove(1)
        Next i

        For i = 1 To g_colRecipeChanged.Count
            g_colRecipeChanged.Remove(1)
        Next i

        For i = 1 To g_colLotStatus.Count
            g_colLotStatus.Remove(1)
        Next i

        For i = 1 To g_colRecipeLastModifyInfo.Count
            g_colRecipeLastModifyInfo.Remove(1)
        Next


    End Sub

    ' add new lot to the tail of pool
    Public Function AddLot(ByVal nPortPos As Integer) As Integer
        Dim idx As Integer = 1
        Dim fFound As Boolean = False
        Dim nCount As Integer = 1

        ' check whether all lots occupied
        If g_nTotalLots = g_nMaxLots Then
            AddLot = 0
            Exit Function
        End If

        ' find a empty slot
        'idx = 1
        'nCount = 1
        'fFound = False

        While nCount <= g_nMaxLots And Not fFound
            If MyLotInfo(idx).PortPosition = 0 Then
                MyLotInfo(idx).PortPosition = nPortPos

                g_nTotalLots = g_nTotalLots + 1

                fFound = True
            Else
                idx = idx + 1
                If idx > g_nMaxLots Then
                    idx = 1
                End If
            End If
            nCount = nCount + 1
        End While

        AddLot = IIf(fFound, idx, 0)
    End Function

    Public Function GetSlotIndex(ByVal idxLot As Integer, ByVal nSlotNo As Integer) As Integer
        Dim i As Integer

        For i = 1 To MAX_SLOTS
            If MyLotInfo(idxLot).Slots(i).SlotNo = nSlotNo Then
                GetSlotIndex = i
                Exit For
            End If
        Next i
    End Function

    Public Sub UpdateSlotInfo(ByRef DstSlot As prjSECS.clsSlotStructure, ByRef SrcSlot As prjSECS.clsSlotStructure)
        Dim i As Integer

        DstSlot.SlotNo = SrcSlot.SlotNo
        DstSlot.GlassID = SrcSlot.GlassID
        DstSlot.GlassGrade = SrcSlot.GlassGrade
        DstSlot.DMQCGrade = SrcSlot.DMQCGrade
        DstSlot.DMQCToolID = SrcSlot.DMQCToolID
        DstSlot.LastOperationID = SrcSlot.LastOperationID
        DstSlot.ProcessToolID = SrcSlot.ProcessToolID
        DstSlot.PLineID = SrcSlot.PLineID
        DstSlot.Rework = SrcSlot.Rework
        DstSlot.Scrap = SrcSlot.Scrap
        DstSlot.FIRemark = SrcSlot.FIRemark
        DstSlot.DMQCResult = SrcSlot.DMQCResult
        DstSlot.ProcFlag = SrcSlot.ProcFlag
        DstSlot.PSHGroup = SrcSlot.PSHGroup
        DstSlot.IsGlassProecssed = SrcSlot.IsGlassProecssed

        For i = 1 To MAX_CHIPS
            DstSlot.ChipGrade(i) = SrcSlot.ChipGrade(i)
        Next i
    End Sub

    Public Sub IsGlassProcessed(ByRef DstSlot As prjSECS.clsSlotStructure, ByRef SrcSlot As prjSECS.clsSlotStructure, ByRef EndSlot As prjSECS.clsSlotStructure)
        Dim i As Integer

        DstSlot.SlotNo = SrcSlot.SlotNo
        DstSlot.GlassID = SrcSlot.GlassID
        DstSlot.GlassGrade = SrcSlot.GlassGrade
        DstSlot.DMQCGrade = SrcSlot.DMQCGrade
        DstSlot.DMQCToolID = SrcSlot.DMQCToolID
        DstSlot.LastOperationID = SrcSlot.LastOperationID
        DstSlot.ProcessToolID = SrcSlot.ProcessToolID
        DstSlot.PLineID = SrcSlot.PLineID
        DstSlot.Rework = SrcSlot.Rework
        DstSlot.Scrap = SrcSlot.Scrap
        DstSlot.FIRemark = SrcSlot.FIRemark
        DstSlot.DMQCResult = SrcSlot.DMQCResult
        DstSlot.ProcFlag = SrcSlot.ProcFlag
        DstSlot.PSHGroup = SrcSlot.PSHGroup
        DstSlot.IsGlassProecssed = EndSlot.IsGlassProecssed
        For i = 1 To MAX_CHIPS
            DstSlot.ChipGrade(i) = SrcSlot.ChipGrade(i)
        Next i
    End Sub


    ' process when port removed
    Public Sub PortRemove(ByVal nPortPos As Integer)
        Dim idxPort As Integer
        Dim idxState As Integer

        idxState = GetStateIndex(nPortPos)
        If idxState > 0 Then
            MyPortStateControl(idxState).fProcessEnd = False
            MyPortStateControl(idxState).fCSTRunningOnLine = False
        End If

        ' clear certain port info
        idxPort = GetPortIndex(nPortPos)
        MyPortInfo(idxPort).CassetteID = ""
        MyPortInfo(idxPort).WithCassette = False
        MyPortInfo(idxPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY

        RemoveLot(nPortPos)
    End Sub

    Public Function GetReplyState() As Integer
        If g_colReplyStateCtl.Count > 0 Then
            GetReplyState = g_colReplyStateCtl.Item(1)
            g_colReplyStateCtl.Remove(1)

            If g_colReplyStateCtl.Count > 0 Then
                WriteLogInfo(eLogType.TYPE_SYS, "Reply State is existing!!! Count = " & g_colReplyStateCtl.Count)
            End If
        End If
    End Function

    ' timer collection content
    ' "PortNo,TimerType, DueTicks"
    Public Sub TimerAdd(ByVal nPortNo As Integer, ByVal nTimerType As Integer, ByVal nCountDown As Integer)
        Dim strFormat As String
        Dim lngDue As Long = My.Computer.Clock.TickCount
        SyncLock g_colTimer
            lngDue = lngDue + CLng(nCountDown) * 1000
            strFormat = CStr(nPortNo) & "," & CStr(nTimerType) & "," & CStr(lngDue)
            g_colTimer.Add(strFormat)
        End SyncLock
    End Sub

    Public Function TimerDelete(ByVal nPortNo As Integer, ByVal nTimerType As Integer) As Boolean
        Dim i As Integer
        Dim vGet As Object
        Try
            SyncLock g_colTimer
                For i = 1 To g_colTimer.Count
                    vGet = Split(g_colTimer.Item(i), ",")
                    If vGet(0) = nPortNo And vGet(1) = nTimerType Then
                        g_colTimer.Remove(i)
                        TimerDelete = True
                        Exit Function
                    End If
                Next i
            End SyncLock
        Catch ex As Exception
            WriteLogInfo(eLogType.TYPE_ERR, ex.ToString)
        End Try

    End Function

    Public Sub AddReportGlassRun(ByRef strGlassID As String, ByRef strEQToolID As String, ByRef strRSTPPID As String, ByRef strStartTime As String, ByRef strEndTime As String)
        g_colGlassRun.Add(strGlassID & "," & strEQToolID & "," & strRSTPPID & "," & strStartTime & "," & strEndTime)
    End Sub

    'Public Function GetReportGlassRun(ByRef strGlassID As String, ByRef strEQToolID As String, ByRef strRSTPPID As String, ByRef strStartTime As String, ByRef strEndTime As String) As Boolean
    '    Dim strData As String
    '    Dim vGet As Object

    '    If g_colGlassRun.Count > 0 Then
    '        strData = g_colGlassRun.Item(1)
    '        g_colGlassRun.Remove(1)

    '        vGet = Split(strData, ",")
    '        strGlassID = vGet(0)
    '        strEQToolID = vGet(1)
    '        strRSTPPID = vGet(2)
    '        strStartTime = vGet(3)
    '        strEndTime = vGet(4)

    '        GetReportGlassRun = True
    '    End If
    'End Function

    ' idxSlot is the slotindex of the cassette (it is not identical to SlotNo)
    Public Sub AddReportWorkAPD(ByVal nPortPos As Integer, ByVal SlotInfo As prjSECS.clsSlotStructure, ByVal nUnitNo As Integer, ByRef strPhysicalRecipe As String, ByRef ItemData() As prjSECS.clsItemFormat, ByVal fAbort As Boolean)
        Dim vItemData() As prjSECS.clsItemFormat
        Dim i As Integer
        Dim strChip As String = ""

        For i = 1 To MAX_CHIPS
            strChip = strChip & SlotInfo.ChipGrade(i)
        Next i

        ' slotno waiting to send work report
        ' 09/09/2004 add SlotInfo as collection has problem
        ' use stupid method...
        g_colWorkAPD.Add(CStr(nPortPos) & "," & CStr(nUnitNo) & "," & strPhysicalRecipe & "," & fAbort & "," & _
                         CStr(SlotInfo.SlotNo) & "," & SlotInfo.GlassID & "," & CStr(SlotInfo.GlassGrade) & "," & _
                         CStr(SlotInfo.DMQCGrade) & "," & CStr(SlotInfo.DMQCResult) & "," & SlotInfo.DMQCToolID & "," & _
                         strChip & "," & SlotInfo.LastOperationID & "," & SlotInfo.ProcessToolID & "," & SlotInfo.PLineID & "," & _
                         SlotInfo.Rework & "," & CStr(SlotInfo.Scrap) & "," & SlotInfo.FIRemark)

        ' 05/06/2004 store the itemformat too
        ' copy the data (the client will free the memory)

        ReDim vItemData(UBound(ItemData))
        For i = 1 To UBound(ItemData)
            vItemData(i) = New prjSECS.clsItemFormat

            vItemData(i).ItemName = ItemData(i).ItemName
            vItemData(i).ItemValue = ItemData(i).ItemValue
        Next i
        g_colWorkAPD.Add(vItemData)
    End Sub

    Public Function GetReportWorkAPD(ByRef nPortPos As Integer, ByRef SlotInfo As prjSECS.clsSlotStructure, ByRef nUnitNo As Integer, ByRef strPhysicalRecipe As String, ByRef vItemData As Object, ByRef fAbort As Boolean) As Boolean
        Dim strData As String
        Dim vGet As Object
        Dim i As Integer

        If g_colWorkAPD.Count > 0 Then
            strData = g_colWorkAPD.Item(1)
            g_colWorkAPD.Remove(1)

            vGet = Split(strData, ",")
            nPortPos = Val(vGet(0))
            nUnitNo = Val(vGet(1))
            strPhysicalRecipe = vGet(2)
            fAbort = vGet(3)

            SlotInfo.SlotNo = Val(vGet(4))
            SlotInfo.GlassID = vGet(5)
            SlotInfo.GlassGrade = Val(vGet(6))
            SlotInfo.DMQCGrade = Val(vGet(7))
            SlotInfo.DMQCResult = Val(vGet(8))
            SlotInfo.DMQCToolID = vGet(9)
            For i = 1 To MAX_CHIPS
                SlotInfo.ChipGrade(i) = Mid(vGet(10), i, 1)
            Next i
            SlotInfo.LastOperationID = vGet(11)
            SlotInfo.ProcessToolID = vGet(12)
            SlotInfo.PLineID = vGet(13)
            SlotInfo.Rework = vGet(14)
            SlotInfo.Scrap = Val(vGet(15))
            SlotInfo.FIRemark = vGet(16)

            If g_colWorkAPD.Count > 0 Then
                vItemData = g_colWorkAPD.Item(1)
                g_colWorkAPD.Remove(1)
            End If

            GetReportWorkAPD = True
        End If
    End Function


    Public Sub StoreLotAPD(ByVal nPortPos As Integer, ByRef ItemData() As prjSECS.clsItemFormat)
        'Dim vItemData() As prjsecs.clsItemFormat
        Dim i As Integer

        ReDim m_vItemS6F69(UBound(ItemData))
        For i = 1 To UBound(ItemData)
            m_vItemS6F69(i) = New prjSECS.clsItemFormat

            m_vItemS6F69(i).ItemName = ItemData(i).ItemName
            m_vItemS6F69(i).ItemValue = ItemData(i).ItemValue
        Next i
    End Sub

    Public Sub AddReportUnitNo(ByVal nUnitNo As Integer)
        g_colUnitNo.Add(CStr(nUnitNo))
    End Sub

    Public Function GetReportUnitNo(ByRef nUnitNo As Integer) As Boolean
        If g_colUnitNo.Count > 0 Then
            nUnitNo = Val(g_colUnitNo.Item(1))
            g_colUnitNo.Remove(1)
            GetReportUnitNo = True
        End If
    End Function

    Public Sub AddReportRecipeChange(ByVal strToolID As String, ByVal strPPID As String, ByVal strDate As String)
        g_colRecipeChanged.Add(strToolID & "," & strPPID & "," & strDate)
    End Sub



    Public Function GetReportRecipeChange(ByRef strToolID As String, ByRef strPPID As String, ByRef strDateTime As String) As Boolean
        Dim vGet As Object

        If g_colRecipeChanged.Count > 0 Then
            vGet = Split(g_colRecipeChanged.Item(1), ",")
            g_colRecipeChanged.Remove(1)
            strToolID = vGet(0)
            strPPID = AppendSpace(CStr(vGet(1)), LEN_RECIPEID)
            strDateTime = vGet(2)
            GetReportRecipeChange = True
        End If
    End Function

    Private Function IsReplyExpected(ByVal nStream As Integer, ByVal nFunc As Integer) As Boolean
        IsReplyExpected = True

        If nStream = 9 Then IsReplyExpected = False
        If nStream = 10 Then IsReplyExpected = False
    End Function

    Private Function IsEventHostSend(ByVal nStream As Integer, ByVal nFunction As Integer) As Boolean
        Dim i As Integer

        For i = 1 To MAX_MESSAGES
            If MyMSGTable(i).StreamID = nStream And MyMSGTable(i).FunctionID = nFunction Then
                IsEventHostSend = MyMSGTable(i).HOSTSend
                Exit For
            End If
        Next i
    End Function

    Public Function EventFormat(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunction As Integer) As String
        ' format = state + Sm + Fn
        EventFormat = CStr(idxState) & "S" & CStr(nStream) & "F" & CStr(nFunction)
    End Function

    Public Sub Enqueue(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunction As Integer)
        Dim strEvent As String

        strEvent = EventFormat(idxState, nStream, nFunction)

        g_colEventQueue.Add(strEvent)
    End Sub

    Public Sub Dequeue(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunction As Integer)
        Dim i As Integer
        Dim strEvent As String

        strEvent = EventFormat(idxState, nStream, nFunction)

        For i = 1 To g_colEventQueue.Count
            If g_colEventQueue.Item(i) = strEvent Then
                g_colEventQueue.Remove(i)
                Exit For
            End If
        Next i
    End Sub

    Public Function DequeueByIndex(ByVal idx As Integer) As clsEventItem
        Dim strEvent As String
        Dim MyEvent As New clsEventItem

        If g_colEventQueue.Count > 0 Then
            strEvent = g_colEventQueue.Item(idx)
            g_colEventQueue.Remove(idx)

            MyEvent.Index = Val(Left(strEvent, 1))
            MyEvent.StreamID = CInt(Mid(strEvent, 3, InStr(strEvent, "F") - 3))
            MyEvent.FunctionID = CInt(Right(strEvent, Len(strEvent) - InStr(strEvent, "F")))
        End If
        DequeueByIndex = MyEvent
    End Function

    Public Function GetEventPending(ByVal idxState As Integer) As Integer
        Dim i As Integer
        Dim strEvent As String

        For i = 1 To g_colEventQueue.Count
            strEvent = g_colEventQueue.Item(i)

            ' check whether the same state
            If idxState = Val(Left(strEvent, 1)) Then
                GetEventPending = i
                Exit For
            End If
        Next i
    End Function

    Public Sub AddBufMsg(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunction As Integer)
        Dim strEvent As String

        strEvent = EventFormat(idxState, nStream, nFunction)

        g_colBufferMsg.Add(strEvent)
    End Sub

    Public Sub RemoveBufMsg(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunction As Integer)
        Dim i As Integer
        Dim strEvent As String

        strEvent = EventFormat(idxState, nStream, nFunction)

        For i = 1 To g_colBufferMsg.Count
            If g_colBufferMsg.Item(i) = strEvent Then
                g_colBufferMsg.Remove(i)
                Exit For
            End If
        Next i
    End Sub

    Public Function GetFirstBufMsg(ByVal idxState As Integer) As Integer
        Dim i As Integer
        Dim strEvent As String

        For i = 1 To g_colBufferMsg.Count
            strEvent = g_colBufferMsg.Item(i)

            ' check whether the same state
            If idxState = Val(Left(strEvent, 1)) Then
                GetFirstBufMsg = i
                Exit For
            End If
        Next i
    End Function

    Public Function GetBufMsgByIndex(ByVal idx As Integer) As clsEventItem
        Dim strEvent As String
        Dim MyEvent As New clsEventItem

        If g_colBufferMsg.Count > 0 Then
            strEvent = g_colBufferMsg.Item(idx)
            g_colBufferMsg.Remove(idx)

            MyEvent.Index = Val(Left(strEvent, 1))
            MyEvent.StreamID = CInt(Mid(strEvent, 3, InStr(strEvent, "F") - 3))
            MyEvent.FunctionID = CInt(Right(strEvent, Len(strEvent) - InStr(strEvent, "F")))
        End If
        GetBufMsgByIndex = MyEvent
    End Function

    Public Sub EnqueueSeq(ByVal idxState As Integer, ByVal idxTable As Integer, ByVal nSequence As Integer)
        Dim strSeq As String

        ' convert into string => state(1 byte) + table(1 byte) +  sequence(2 bytes)
        strSeq = CStr(idxState) & CStr(idxTable) & Right("0" & CStr(nSequence), 2)
        g_colInsertSeq.Add(strSeq)
    End Sub

    Public Function DequeueSeq(ByVal idxState As Integer) As clsInsertSeq
        Dim strSeq As String
        Dim i As Integer
        Dim nStateInQue As Integer
        Dim MySeq As New clsInsertSeq

        For i = 1 To g_colInsertSeq.Count
            strSeq = g_colInsertSeq.Item(i)
            nStateInQue = Val(Left(strSeq, 1))

            ' check only the same state
            If idxState = nStateInQue Then
                MySeq.InsertState = nStateInQue
                MySeq.InsertTable = Val(Mid(strSeq, 2, 1))
                MySeq.InsertSeq = Val(Mid(strSeq, 3, 2))
                g_colInsertSeq.Remove(i)
                Exit For
            End If
        Next i
        DequeueSeq = MySeq
    End Function

    Public Function PokeSeq(ByVal idx As Integer) As clsInsertSeq
        Dim strSeq As String
        Dim MySeq As New clsInsertSeq

        If g_colInsertSeq.Count > 0 Then
            strSeq = g_colInsertSeq.Item(idx)
            MySeq.InsertState = Val(Left(strSeq, 1))
            MySeq.InsertTable = Val(Mid(strSeq, 2, 1))
            MySeq.InsertSeq = Val(Mid(strSeq, 3, 2))
        End If
        PokeSeq = MySeq
    End Function

    Public Function GetInsertedSeqPending(ByVal idxState As Integer) As Integer
        Dim strSeq As String
        Dim i As Integer

        For i = 1 To g_colInsertSeq.Count
            strSeq = g_colInsertSeq.Item(i)
            If idxState = Val(Left(strSeq, 1)) Then
                GetInsertedSeqPending = i
                Exit For
            End If
        Next i
    End Function

    Public Sub GetCurrSnFm(ByVal idxState As Integer, ByRef nStream As Integer, ByRef nFunction As Integer)
        Select Case MyPortStateControl(idxState).idxTable
            Case TABLE_OFFLINE
                nStream = MyOffLineTable(MyPortStateControl(idxState).nCurrStep).StreamID
                nFunction = MyOffLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID

            Case TABLE_ONLINE
                nStream = MyOnLineTable(MyPortStateControl(idxState).nCurrStep).StreamID
                nFunction = MyOnLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID

        End Select
    End Sub

    Public Function MsgUnmatchProcess(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunc As Integer) As Boolean
        Dim fPrimary As Boolean
        Dim nFuncAdjust As Integer

        fPrimary = ((nFunc Mod 2) = 1)
        If fPrimary Then
            nFuncAdjust = nFunc
        ElseIf nFunc <> 0 Then
            nFuncAdjust = nFunc - 1
        End If

        ' 08/18/2003 remove unmatch msg from queue
        If fPrimary Then
            If IsEventHostSend(nStream, nFuncAdjust) Then
                Dequeue(idxState, nStream, nFunc)
                MsgUnmatchProcess = True
            End If
        End If
    End Function

    Public Function MsgPreProcess(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunc As Integer) As Boolean
        Dim fPrimary As Boolean
        Dim fHostSend As Boolean
        Dim nFuncAdjust As Integer

        fPrimary = ((nFunc Mod 2) = 1)
        If fPrimary Then
            nFuncAdjust = nFunc
        ElseIf nFunc <> 0 Then
            nFuncAdjust = nFunc - 1
        End If

        fHostSend = IsEventHostSend(nStream, nFuncAdjust)

        If fPrimary Then
            ' cannot send conitnuous primary message
            ' if the queue is not empty, enqueue and exit
            If g_colEventQueue.Count > 0 Or g_fInsideEventTrigger Then
                AddBufMsg(idxState, nStream, nFuncAdjust)
                WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Msg buffered " & EventFormat(idxState, nStream, nFuncAdjust))
                Return True
            End If

            ' this message is sent by Host, enqueue it
            If fHostSend Then
                Enqueue(idxState, nStream, nFuncAdjust)
            End If

            ' EQP message is queued till msg it sent
            ' since it could be skipped
        Else
            ' secondary, remove its primary message
            Dequeue(idxState, nStream, nFuncAdjust)
        End If
        Return False
    End Function

    Public Sub MsgPostProcess(ByVal idxState As Integer, ByVal nCurrStep As Integer)
        Dim nStream As Integer
        Dim nFunction As Integer
        Dim strEvent As String

        ' find its stream & function
        GetCurrSnFm(idxState, nStream, nFunction)
        strEvent = CStr(idxState) & "S" & CStr(nStream) & "F" & CStr(nFunction)

        ' if this is a reply message to Host, dequeue
        If IsEventHostSend(nStream, nFunction) Then
            Dequeue(idxState, nStream, nFunction)
        Else
            ' if this is a EQP send message, enqueue
            If IsReplyExpected(nStream, nFunction) Then
                Enqueue(idxState, nStream, nFunction)
            End If
        End If
    End Sub

    ' return whether table is switched!
    Public Function ProceedNextStep(ByVal idxState As Integer, ByVal nNextStep As Integer) As Boolean
        Dim i As Integer
        '    Dim nStartPort As Integer

        ' negative value: jump to absolute step
        If nNextStep < 0 Then
            MyPortStateControl(idxState).nCurrStep = -nNextStep
        Else
            ' increment step
            MyPortStateControl(idxState).nCurrStep = MyPortStateControl(idxState).nCurrStep + nNextStep

            ' check whether cross to other table ?
            If MyPortStateControl(idxState).nCurrStep > MyMaxTableSteps(MyPortStateControl(idxState).idxTable) Then
                ' reset
                MyPortStateControl(idxState).nCurrStep = 1
                MyPortStateControl(idxState).fWait2NdMSG = False

                If MyPortStateControl(idxState).idxTable = TABLE_OFFLINE Then
                    ' proceed to next table based on RMS
                    MyPortStateControl(idxState).idxTable = TABLE_ONLINE

                    ' table is switched
                    ProceedNextStep = True

                    ' switch online, enable the other ports
                    If idxState = 1 Then
                        For i = 1 To g_nMaxPorts
                            If i <> 1 Then
                                MyPortStateControl(i).fSuspend = False
                            End If
                        Next i
                    End If

                    ' 08/10/2004 set current step for the disabled port in the beginning
                    For i = 1 To g_nMaxPorts
                        If MyPortInfo(i).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_DISABLE Then
                            ' since the port is enabled when online, the <LoadRequest> will be issued right after enabled
                            ' so we have to alter the initial step
                            MyPortStateControl(i).nCurrStep = eOnLineStep.ONL_LOADCOMPLETE

                            If i <> 1 Then
                                'insert port disabled sequence
                                MyPortStateControl(i).nLoadState = LDSTA_DISABLED
                                EnqueueSeq(i, TABLE_ONLINE, eOnLineStep.ONL_ANYTIME_PORTSTATE)
                            End If
                        ElseIf MyPortInfo(i).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_END_WITHUNLOAD Then
                            MyPortStateControl(i).fForceExecute = True
                            MyPortStateControl(i).nCurrStep = eOnLineStep.ONL_UNLOADREQ
                        ElseIf MyPortInfo(i).PortStatus > prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY Then
                            ' cannot issue <UnloadReq>, still passive step
                            MyPortStateControl(i).nCurrStep = eOnLineStep.ONL_UNLOADREQ
                        End If
                    Next i

                    If MyPortInfo(idxState).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_DISABLE Then
                        ' 12/10/2003 stop further action (i.e. No <LoadReq>)
                        ProceedNextStep = True
                    End If
                Else
                    ' just starting from the beginning in online mode
                    ' unless need to switch to offline
                End If
            End If
        End If
    End Function

    Public Function IsCompletelyOffline() As Boolean
        IsCompletelyOffline = IIf(g_nCurrOnlineMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE And Not g_fTryOnOffLine, True, False)
    End Function

    Public Function IsOnLineMode() As Boolean
        If g_fHSMSConnected = True Then
            IsOnLineMode = IIf(g_nCurrOnlineMode <> prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE, True, False)
        Else
            Return False
        End If
    End Function

    Public Function GetStateIndex(ByVal nPortPos As Integer) As Integer
        Dim i As Integer

        For i = 1 To g_nMaxPorts
            If MyPortStateControl(i).nPortNo = nPortPos Then
                GetStateIndex = i
                Exit Function
            End If
        Next i
    End Function

    Public Function GetPortIndex(ByVal nPortPos As Integer) As Integer
        Dim i As Integer

        For i = 1 To g_nMaxPorts
            If MyPortInfo(i).PortPosition = nPortPos Then
                GetPortIndex = i
                Exit Function
            End If
        Next i
    End Function

    Public Function IsMGVRunCIM(ByVal nPortPos As Integer)
        Dim idxPort As Integer

        idxPort = GetPortIndex(nPortPos)

        If MyPortInfo(idxPort).PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_BUFFER Then
            IsMGVRunCIM = g_fRunMGVBufCIM
        Else
            IsMGVRunCIM = True
        End If
    End Function

    ' 11/23/2006 also add PortNo to prevent disorder when multiple lotstatus request
    Public Sub AddReportLotStatus(ByVal nLotStatus As Integer, ByVal nPortNo As Integer)
        g_colLotStatus.Add(nLotStatus & "," & nPortNo)
    End Sub

    Public Function GetReportLotStatus(ByVal nPortNo As Integer) As Integer
        Dim i As Integer
        Dim strStatus As String
        Dim vGet As Object

        If g_colLotStatus.Count > 0 Then
            For i = 1 To g_colLotStatus.Count
                strStatus = g_colLotStatus.Item(i)
                vGet = Split(strStatus, ",")
                If Val(vGet(1)) = nPortNo Then
                    GetReportLotStatus = vGet(0)
                    g_colLotStatus.Remove(i)
                    Exit Function
                End If
            Next i

            ' no match with PortNo,always get first one
            strStatus = g_colLotStatus.Item(1)
            vGet = Split(strStatus, ",")
            GetReportLotStatus = vGet(0)
            g_colLotStatus.Remove(1)
        End If
    End Function

    Public Sub WrigeExceptionLog(ByVal strCMDName As String, ByVal strException As String)
        WriteLogInfo(prjSECS.clsEnumCtl.eZLogType.TYPE_ERR, "CMD==>" & strCMDName & " MSG==>" & strException)
    End Sub

    Public Sub WriteLogInfo(ByVal nLogType As eLogType, ByVal strMsg As String)
        Dim strHeader As String = String.Format("[{0}]", nLogType.ToString)
        Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")

        Select Case nLogType
            Case eLogType.TYPE_ERR
                strHeader = "[ERR]"
            Case eLogType.TYPE_EVENT
                strHeader = "[EVENT]"
            Case eLogType.TYPE_METHOD
                strHeader = "[METHOD]"
            Case eLogType.TYPE_OPSET
                strHeader = "[OPSET]"
            Case eLogType.TYPE_PROPERTY
                strHeader = "[PROPERTY]"
            Case eLogType.TYPE_SYS
                strHeader = "[SYS]"
        End Select

        strHeader = strHeader & Space(10 - strHeader.Length)
        MyLog.WriteLog(MyTime & Space(1) & "CCIM      >" & strHeader & Space(5) & strMsg)
    End Sub

End Module
