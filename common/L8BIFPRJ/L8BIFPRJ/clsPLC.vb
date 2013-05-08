Imports PLC

'2008/11/30 Modify WriteArmGlassInfo , WriteBufferGlassInfo ; Add Event CVINIT167data
'2008/12/28 Modify 765 and 167 Addr ,Modify WriteArmGlassInfo , WriteBufferGlassInfo,Modify PortChange,Modify Interlock
'2009/3/2 Modify Port Change Addr
'2009/3/23 Add Property CVFlowInQty CVFlowOutQty CVProcessStartQty
'2009/4/21 Add RSTSetPMMode
'2009/4/25 Add SetBufferDisable RSTBufferDisable
'2009/5/17 Add SetRobotStandBy RobotStandBy
'2009/5/20 Add ClearBufferTarget
'2009/8/14 Add Write GlassAbnormalReport Log
'2009/09/06 Add CheckUnloaderPortType Log
'2009/09/21 Add CheckTimeoutFunction , CheckRobotCommandError
'2009/10/10 Add RobotIOInput , GetRobotIOInput
'2010/2/23 Modify 167Function
'2020/3/8 Modify SampleGlassSetting ,Get765LotData


Public Class clsPLC
    'Dim m_anLineIDBlock(LEN_LINEID_BLOCK) As Integer
    'Dim m_anGlassIDbySlot(LEN_GLASS_ID_BY_SLOT) As Integer
    'Dim m_fSyncDateTime As Boolean
    Dim m_fRSTAlive As Boolean

    Private mvarCVVCREnable(MAX_CST_PORT) As Boolean
    Private mvarCVWithCassette(MAX_CST_PORT) As Boolean
    Private mvarCVPortMode(MAX_CST_PORT) As ePortMode
    Private mvaCVPortType(MAX_CST_PORT) As eUnloadType
    Private mvarCVPortEnable(MAX_CST_PORT) As Boolean
    Private mvarCVStatus As eEQStatus
    Private mvarCVPortWIP(MAX_CST_PORT) As Integer
    Private mvarCVPortProdCode(MAX_CST_PORT) As String

    Private mvarCVGlassExistOnConveyor As Integer
    Private mvarCVToolID As String
    Private mvarEQToolID(MAX_EQ) As String
    Private mvarCVPortStatus(MAX_CST_PORT) As Integer

    Private mvarShowCVGUI As Boolean
    Private mvarShowEQGUI As Boolean
    Private mvarShowCVEQGUI As Boolean

    Private mvarEQStatus(MAX_EQ) As eEQStatus
    Private mvarEQWithGlass(MAX_EQ) As Boolean

    Private mvarRSTCommandPossible As Boolean
    Private mvarEQArmMode As Integer
    Private mvarEQIgnoreTimeout(MAX_EQ) As Boolean
    Private mvarEQTranfserMode(MAX_EQ) As Integer
    Private mvarEQRunningMode As eEQMode

    Private mvarRSTOperationMode As Integer
    Private mvarRSTRemoteStatus As eRMS
    Private mvarRSTColorRepairRunMode As eColorRepairMode
    Private mvarRepairReviewMode As Integer

    Private mvarRobotCommandMode As eRSTCommandMode
    Private mvarRobotInitialRequest As Boolean
    Private mvarRSTSetRobotMode As eRSTMode

    Private mvarArmGlassID(MAX_EQ) As String

    Private mvarBufferDisable(3, MAX_BUFFER_SLOT) As Boolean

    Private WithEvents MyScanIFSignal As New Timer
    Private WithEvents MyScanGUISignal As New Timer
    Private WithEvents MyTimeOutSetting As New Timer

    Dim MyCheckDeleteEQGlassDataFlag(MAX_EQ) As Boolean

    Dim MyTimeoutfrm As New frmTimeOutSetting
    Dim MySampleGlassSettingfrm As New frmSampleGlassSetting

    Dim MyCheck167DataFlag As Boolean
    Dim MyCheckInitializeComplete As Boolean
    Dim myCheckFlowInOutFlag As Boolean

    Dim mfINITAlarm As Boolean

    Enum eArmMode
        ARM_DOUBLE = 0
        ARM_SINGLE_UPPER = 1
        ARM_SINGLE_LOWER = 2
    End Enum

    Enum eEQMode
        EQM_NONE = 0
        EQM_MQC = 1
        EQM_THROUGH = 2
    End Enum

    Enum eRMS
        RMS_OFFLINE = 0
        RMS_ONLINECONTROL = 1
        RMS_ONLINEMONITOR = 2
    End Enum

    Enum eEQRSTMode
        RSTMODE_INIT = 0
        RSTMODE_AUTO = 1
        RSTMODE_MANUAL = 2
        RSTMODE_ENGINEER = 3
        '------------------
        RSTMODE_STOP = 4
        RSTMODE_PM = 5
    End Enum

    Enum eRSTCommandMode
        [NA] = 0
        [START] = 1
        [STOP] = 2
    End Enum

    Enum eTrfMode
        TRF_PROCESS = 0
        TRF_TRANSFER = 1        ' pass mode, no process
    End Enum

    Enum eGlassAbnormal
        [NA] = 0
        [GLASSERASE] = 1
        [GLASSIDMODIFY] = 2
        [GLASSINSERT] = 3
        [VCRNG] = 4
    End Enum

    Enum eEQStatus
        [NONE] = 0
        [RUNNING] = 1
        [IDLE] = 2
        [DOWN] = 3
        [SETUP] = 4
        [STOPPED] = 5
    End Enum

    Enum eRSTStatus
        [NONE] = 0
        [RUNNING] = 1
        [IDLE] = 2
        [DOWN] = 3
        [SETUP] = 4
        [STOPPED] = 5
        [PM] = 6
    End Enum

    Enum eGlassJudge
        JUDGE_NONE = 0
        JUDGE_OK = 1
        JUDGE_NG = 2
        JUDGE_GRAY = 3
        JUDGE_MIX = 4           ' to share with CV I/F
    End Enum

    Enum eUnmatchStatus
        UMS_REALGLASS = 1 'No data, but sensor detect glass
        UMS_NOGLASS = 2 'Have data, but no glass detected by sensor.
    End Enum

    Enum eProcessCommand
        CMD_NONE = 0
        CMD_START = 1
    End Enum

    Enum eRecipeModify
        [NA] = 0
        [ADD] = 1
        [DELETE] = 2
        [MODIFY] = 3
    End Enum

    Enum eRSTMode
        [NA] = 0
        [AUTO] = 1
        [MANUAL] = 2
        [ENGINEER] = 3
    End Enum

    Enum ePortMode
        [NA] = 0
        [LOAD] = 1
        [UNLOAD] = 2
    End Enum

    Enum eUnloadType
        [NA] = 0
        [AUTO] = 1
        [OK] = 2
        [NG] = 3
        [GRAY] = 4
        [MIX] = 5
        [MIXNG] = 6
    End Enum

    Enum eLightTower
        TOWER_R = 0
        TOWER_Y = 1
        TOWER_G = 2
    End Enum

    Enum eLightTowerStatus
        TOWER_OFF = 0
        TOWER_ON = 1
        TOWER_BLINK = 2
    End Enum

    Enum eRSTArm
        ARM_UPPER = 0
        ARM_LOWER = 1
    End Enum

    Enum eLinkStatus
        [NA] = 0
        [OFF_LINE] = 1
        [TRYING] = 2
        [LINKING] = 3
    End Enum

    Enum eNGGXToMachine
        [NA] = 0
        IDX_CV_PORT1 = 1
        IDX_CV_PORT2 = 2
        IDX_CV_PORT3 = 3
        IDX_EQ1 = 4
        IDX_EQ2 = 5
        IDX_EQ3 = 6
    End Enum

    Enum eProductCategory
        [PROD] = 0
        [INIT] = 1
        [MONI] = 2
        [DUMY] = 3
        [NA] = 4
    End Enum

    Enum eEQGlassInfoDeleteResult
        [Success] = 1
        [Failure] = 2
    End Enum

    Enum eAOIFunction
        [NONE] = 0
        [AOI] = 1
        [CD] = 2
        [REVIEW] = 3
    End Enum

    Enum eRSTAction
        [GET] = 1
        [PUT] = 2
        [EXCHANGE] = 3
        [GET_WAIT] = 4
        [PUT_WAIT] = 5
        [HOME] = 6
    End Enum

    Enum eGlassType
        [TAPE] = 0
        [INK] = 1
    End Enum

    Enum eGlassThickness
        [MM_05] = 1
        [MM_06] = 2
        [MM_07] = 3
    End Enum

    Enum eRSTPOSITIONTYPE
        [EQ] = 0
        [BUFFER] = 1
        [CV] = 2
    End Enum

    Enum eRobotSpeed
        [NA] = 0
        [LOW] = 1
        [MID] = 2
        [HI] = 3
    End Enum

    Enum eRunningMode
        [NONE] = 0
        [I_MODE] = 1
        [U_MODE] = 2
    End Enum

    Enum eTargetPosition
        [NONE] = 0
        [EQ1] = 1
        [EQ2] = 2
        [EQ3] = 3
        [EQ1EQ2] = 4
        [EQ1EQ3] = 5
        [EQ2EQ3] = 6
        [EQ1EQ2EQ3] = 7
    End Enum

    Enum eGlassTargetPosition
        [EQ1] = 1
        [EQ2] = 2
        [EQ1EQ2] = 3
    End Enum

    Enum eUnloadStatus
        [NA] = 0
        [NORMAL] = 1
        [ABNORMAL] = 2
    End Enum

    Enum eCassetteStatus
        [NONE] = 0
        [WAIT_PROCESS] = 1
        [PROCESSING] = 2
        [END] = 3
        [SUSPENDING] = 4
    End Enum

    Enum eFIFCFlag
        [BY_PASS] = 0
        [FI_FORCE] = 1
    End Enum

    Enum eProcessedFlag
        [NONE] = 0
        [PROCESS] = 1
    End Enum

    Enum eRDGRADE
        [OK] = 1
        [REVIEW] = 2
        [NG] = 3
        [NO_GLASS] = 4
    End Enum

    Enum eDGRADE
        [OK] = 1
        [REVIEW] = 2
        [NG] = 3
        [NO_GLASS] = 4
    End Enum

    Enum eGGRADE
        [OK] = 1
        [NG] = 2
        [GRAY] = 3
        [NO_GLASS] = 4
    End Enum

    Enum eFIRMFLAG
        [FI_MACRO] = 1
        [OTHERS] = 2
    End Enum

    Enum eSCRPFLAG
        [MARKED_SCRAP] = 1
        [MARKED_RECYCLED] = 2
    End Enum

    Enum eRWKFLAG
        [REWORK] = 1
        [NORMAL_GLASS] = 2
    End Enum

    Enum eBufferStatus
        [NONE] = 0
        [OK] = 1
        [NG] = 2
        [GRAY] = 3
        [LD] = 4
        [INK] = 5
        [CASSETTE1] = 6
        [CASSETTE2] = 7
        [CASSETTE3] = 8
        [STANDARDGLASS_EQ1] = 9
        [STANDARDGLASS_EQ2] = 10
        [STANDARDGLASS_EQ3] = 11
    End Enum

    Enum eCSTCmdStatus
        [NA] = 0
        [LOAD_REQ] = 1
        [LOAD_COMP] = 2
        [UNLOAD_REQ] = 3
        [UNLOAD_COMP] = 4
    End Enum

    Enum eGlassResult
        [UN_INSPECTION] = 0
        [OK] = 1
        [NG] = 2
        [GRAY] = 3
        [REVIEW] = 4
    End Enum

    Enum eColorRepairMode
        [COLOR_MODE] = 0
        [NORMAL_MODE] = 1
    End Enum

    Enum eModifyGlassInfo
        [U_ARM] = 1
        [L_ARM] = 2
        [BUFFER1] = 3
        [BUFFER2] = 4
        [BUFFER3] = 5
        [EQ1] = 6
        [EQ2] = 7
        [EQ3] = 8
    End Enum

    Enum eRobotTarget
        [EQ] = 0
        [BUFFER] = 1
        [CV] = 2
    End Enum

    Enum eRobotCommand
        [DO] = 0
        [WAIT] = 1
    End Enum

    Enum eRobotAction
        [GET] = 0
        [PUT] = 1
        [EXCHANGE] = 2
        [DOUBLE_GET] = 3
        [DOUBLE_PUT] = 4
    End Enum

    Enum eRobotActualStatus
        [UP_ARM_SENSOR] = 0
        [LOW_ARM_SENSOR] = 1
        [UP_ARM_VACCUM] = 2
        [LOW_ARM_VACCUM] = 3
        [SERVO_ON] = 4
        [READY] = 5
        [CMD_BUSY] = 6
        [FORK_EXTEND] = 7
    End Enum

    Enum eCVControlStatus
        [AUTO] = 1
        [MANUAL] = 2
        [RUN] = 3
        [STOP] = 4
    End Enum


#Region "CV IF RaiseEvents"
    Public Event CVCSTUnloadRequest(ByVal nPortNo As Integer, ByVal fUnloadNormal As Boolean, ByVal nGlassQty As Integer)
    Public Event CVGlassAbnormal(ByVal nAbnormal As eGlassAbnormal, ByVal nPosition As Integer, ByVal strSourceGlassID As String, ByVal strNewGlassID As String)
    Public Event CVPortTypeChangeResult(ByVal nPortNo As Integer, ByVal fSuccess As Boolean, ByVal nPortMode As ePortMode, ByVal nPortType As eUnloadType)
    Public Event CVCSTLoadRequest(ByVal nPortNo As Integer)
    Public Event CVCSTLoadComplete(ByVal nPortNo As Integer, ByVal nFirstNonEmptySlot As Integer, ByVal CASID As String)
    Public Event CVCSTUnloadComplete(ByVal nPortNo As Integer)
    Public Event CVStatusChanged(ByVal nNewStatus As eEQStatus)
    Public Event CVVCRStatusChange(ByVal nVCRPos As Integer, ByVal fEnabled As Boolean)
    Public Event CVPortDisable(ByVal nPortNo As Integer, ByVal fDisable As Boolean)
    Public Event CVCSTArrived(ByVal nPortNo As Integer)
    Public Event CVCSTRemoved(ByVal nPortNo As Integer)
    Public Event CVHandOffAvailable(ByVal nPosition As Integer, ByVal fOnOff As Boolean)
    Public Event CVPortSubStatus(ByVal nPortNo As Integer, ByVal fPortPause As Boolean)
    Public Event CVSlotNoUnmatch(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nUnmatchStatus As eUnmatchStatus)
    Public Event CVGlassFlowIn(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal strGlassID As String, ByVal strProdCode As String, ByVal strStartTime() As String, ByVal strEndTime() As String)
    Public Event CVGlassFlowOut(ByVal nPortNo As Integer, ByVal nSlotNo As Integer)
    Public Event CVDummyCancelResult(ByVal nPortNo As Integer, ByVal fSuccess As Boolean)
    Public Event CVS765datadownloadAck(ByVal nPortNo As Integer)
    Public Event CVS167dataUploadRequest(ByVal nPortNo As Integer, ByVal LotStructure As clsS167LotInfo)
    Public Event CVAlarm(ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer)
    Public Event CVLinkStatus(ByVal nCVIndex As Integer, ByVal nStatus As eLinkStatus)
    Public Event CVCassettePresent(ByVal nPortNo As Integer)
    Public Event CVPositionGxIDChange(ByVal nPosition As Integer, ByVal strNewGxID As String)
    Public Event CVLoaderEmpty(ByVal nPortNo As Integer)
    Public Event CVUnloaderFull(ByVal nPortNo As Integer)
    Public Event CVProcessCommandAck(ByVal nPortNo As Integer)
    Public Event CVCassetteRemoveReport(ByVal nPortNo As Integer)
    Public Event CVINIT167data(ByVal nPortNo As Integer, ByVal LotStructure As clsS167LotInfo)

    Public Event CVControlStatusA(ByVal nStatus As eCVControlStatus)
    Public Event CVControlStatusR(ByVal nStatus As eCVControlStatus)

#End Region

#Region "EQ IF RaiseEvents"
    Public Event EQGlassErase(ByVal nEQIndex As Integer, ByVal strGxID As String)
    Public Event EQRecipeCheckResult(ByVal nEQIndex As Integer, ByVal fExists As Boolean, ByVal strPPID As String)
    Public Event EQRecipeChanged(ByVal nEQIndex As Integer, ByVal nModifyType As eRecipeModify, ByVal strPPID As String)
    Public Event EQStatusChanged(ByVal nEQIndex As Integer, ByVal eNewStatus As eEQStatus)
    Public Event EQGlassExistChanged(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean)
    Public Event EQInProcess(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean)
    Public Event EQHandOffChanged(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean)
    Public Event EQMPAStop(ByVal nEQIndex As Integer, ByVal nMPANo As Integer, ByVal fStopped As Boolean)

    Public Event EQProcessResult(ByVal nEQIndex As Integer, ByVal nSampleGlassFlag As Integer, ByVal nSlotInfo As Integer, ByVal nProcessResult As eGlassResult, ByVal strChipGrade As String, ByVal strPSHGroup As String, ByVal strGlassID As String)
    Public Event EQProcessStart(ByVal nEQIndex As Integer, ByVal strGlassID As String)

    Public Event EQAlarm(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer)

    Public Event EQLinkStatus(ByVal nEQIndex As Integer, ByVal nStatus As eLinkStatus)

    Public Event RSTDeltetEQGlassDataComplete(ByVal nEQIndex As Integer, ByVal nResult As eEQGlassInfoDeleteResult)

    Public Event EQGlassDataChange(ByVal nEQIndex As Integer, ByVal strGlassID As String)

    Public Event EQRecipeQueryResult(ByVal nEQIndex As Integer, ByVal fExists As Boolean, ByVal strPPID As String, ByVal nParameterData() As Integer)
#End Region

#Region "RST IF RaiseEvents"
    'Public Event RobotCommandAck(ByVal fOk As Boolean)
    Public Event RobotCommandAck()
    Public Event RobotManualComplete()
    Public Event RobotModeChange(ByVal nMode As eRSTMode)
    Public Event RSTAlarm(ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer)
    Public Event RobotStatusChange(ByVal nNewStatus As eRSTStatus)
    Public Event RSTBufferPortGlassInfoChange(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal fGlassExist As Boolean)
    Public Event RSTBufferPortGlassInfoWriteComplete(ByVal nPortNo As Integer, ByVal nSlotNo As Integer)

    Public Event RSTArmWithGlass(ByVal nArm As eRSTArm, ByVal fWithGlass As Boolean, ByVal strGlassID As String)

    Public Event InterfaceInitializeComplete()

    Public Event RobotMotionStart(ByVal nTarget As eRobotTarget, ByVal nArm As eRSTArm, ByVal nCMD As eRobotCommand, ByVal nAction As eRobotAction, ByVal nPosition As Integer, ByVal nBufferSlot As Integer)
    Public Event RobotMotionStartComplete(ByVal nTarget As eRobotTarget, ByVal nArm As eRSTArm, ByVal nCMD As eRobotCommand, ByVal nAction As eRobotAction, ByVal nPosition As Integer, ByVal nBufferSlot As Integer)

    Public Event RobotActionCommmandChange(ByVal nCommandChange As eRSTCommandMode)
    Public Event RobotRobotInitialRequest()
    Public Event RobotCommandPossible(ByVal fOn As Boolean)

    Public Event RobotStandBy(ByVal fOnOff As Boolean)

    Public Event RSTBufferDisable(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal fDisable As Boolean)

    Public Event RobotIOInput(ByRef nItem As eRobotActualStatus, ByVal fOnOff As Boolean)

    Public Event RobotAlarm(ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer)

    Public Event INITAlarmComplete()
#End Region

#Region "PLC IF RaiseEvents"
    Public Event TCPIPConnect(ByVal fConnect As Boolean)
#End Region

#Region "PLC Initialize"

    Public Sub PLCInitial(ByVal strFullPath As String)
        g_strINI_PATH = strFullPath

        If g_strINI_PATH = "" Or (g_strINI_PATH Is Nothing) Then
            g_strINI_PATH = "C:\L8BIFPRJ\L8BIFINI.ini"
        End If

        Call GetCVLinkMap()

        Call GetEQLinkMap()

        Call GetRSTLinkMap()

        Call GetPLCLinkMap()

        MyWriteLog.InitLogObj("Main_IF")

        Call LoadConfigs()

        Call PLCTCPIPOpen()


        MyScanIFSignal.Interval = 200
        MyScanIFSignal.Enabled = True

        MyScanGUISignal.Interval = 800
        MyScanGUISignal.Enabled = True

        MyTimeOutSetting.Interval = 2000
        MyTimeOutSetting.Enabled = True
    End Sub

    Protected Overrides Sub Finalize()

        'System.Windows.Forms.Application.DoEvents()

        MyBase.Finalize()

        MyScanIFSignal.Enabled = False
        MyScanGUISignal.Enabled = False

        MyWriteLog = Nothing
    End Sub

#End Region


#Region "Timer"

    Private Sub CheckINITAlarm()
        If Not mfINITAlarm Then
            RaiseEvent INITAlarmComplete()
            mfINITAlarm = True
        End If
    End Sub

    Private Sub MyScanIFSignal_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyScanIFSignal.Tick

        Call checkTcpipConnect()

        If MyCheckTcpip.nNewConnect = SIGNAL_ON Then

            If Not myCheckFlowInOutFlag Then
                Call ClearFlowInOut()
                Call CheckTraceAddress()

                myCheckFlowInOutFlag = True
            End If

            'Read Data from PLC
            Call ScanCVZRWordAddr()
            Call ScanEQZRWordAddr()
            Call ScanRSTZRWordAddr()
            '-----------------------------------------------------

            If Not MyCheck167DataFlag Then
                INIT167Data(1)
                INIT167Data(2)
                INIT167Data(3)
                MyCheck167DataFlag = True
            End If

            If Not MyCheckInitializeComplete Then
                Call ClearBufferTarget()

                MyCheckInitializeComplete = True
                RaiseEvent InterfaceInitializeComplete()
            End If

            Call CheckPortExist()

            Call CheckCVLinkStatus()
            Call CheckEQLinkStatus()

            Call CheckRobotStandBy()

            'CST 1:LoadRequest,2:LoadComplete,3:UnloadRequest,4:UnloadComplete
            Call CheckPortActionStatus()

            Call S765datadownloadAck()
            Call S167dataUploadRequest()
            Call GlassAbnormalReport()
            Call GlassInfoUnmatchedReport()


            Call CheckCVStatus()
            Call CheckVCREnable()
            Call CheckCVPortDisable()
            Call PortChangeReport()


            Call CheckHandOffAvailable()
            Call CheckPortSubStatus()
            Call CheckCassetteRemoveReport() '
            Call CheckDummyCancelAck()
            Call CheckProcessCommandAck()

            Call CheckCVCassettePresentReport()
            Call CheckCVGlassRequestReport()
            'Call CheckGlassDataReqEmptyFlag()

            Call CheckGxFlowIn()
            Call CheckGxFlowOut()

            'Log
            Call ChekmnFlowInReport()
            Call ChekmnFlowOutReport()

            'Call CheckEQResultReport() 'EQ -> RST ???
            Call CheckEQInfoReport() 'RST -> EQ

            Call CheckUnloaderPortType()

            Call CheckCVPositionGxID()

            Call CheckCV1PositionRST()
            Call CheckCV1PositionCV()

            Call CheckThroughModeLoaderEmpty()
            Call CheckThroughModeUnloaderFull()

            Call CheckCVAlarm()

            Call CheckRobotStart()
            Call CheckRobotStartComplete()

            '--------------------------------------
            Call EQGlassEraseReport()
            Call EQRecipeCheckReport()
            Call EQRecipeModifiedReport()
            Call EQStatusChange()
            Call EQGlassDataResultReport() 'EQ -> RST 

            'Call CheckEQWithGlass()
            Call CheckEQWithGlassID()
            Call EQGlassExist()

            Call CheckEQInProcess()
            Call CheckEQHandOffChanged()
            Call CheckEQInterlock()
            Call CheckAlarmOccured()

            'Call CheckEQStageGlassDataExist()

            Call CheckEQAlarm()
            '--------------------------------------

            Call CheckRSTStatus()

            Call RSTCmdPossible()
            Call RSTCmdAck()
            Call RSTModeChange()
            Call CheckRobotActionCommmandChange()
            Call CheckRobotInitialRequest()
            Call CheckRSTAlive()

            Call CheckUpperArmGlassExist()
            Call CheckLowerArmGlassExist()

            Call CheckRobotCommandError()
            Call CheckInterfaceLogCount()

            Call RobotPauseAck()
            Call ResumeRequestAck()

            Call CheckBufferPortGxInfo()
            Call CheckBufferDisable()

            Call CheckTimeoutFunction()

            Call CheckRSTAlarm()
            Call CheckRobotAlarm()

            Call CheckRobotActualStatus()
            Call CheckPortCancel()
            Call EQRecipeQueryReport()

            Call CheckCVOpMode()
            Call CheckINITAlarm()

        End If
    End Sub

    Private Sub MyScanGUISignal_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyScanGUISignal.Tick
        If MyCheckTcpip.nNewConnect = SIGNAL_ON Then

            If mvarShowCVGUI Then
                Call ScanGUICVBitAddr()
            End If

            If mvarShowEQGUI Then
                Call ScanGUIEQBitAddr()
            End If

            'CVGUI Bit Word ,EQGUI Bit Word
            '-------------------------------------------
            Call ScanCVGUIProcesscmd()
            Call ScanCVGUIStatusReport()
            Call ScanCVGUIPortStatus()
            Call ScanCVGUIGlassDataRequest()
            Call ScanCVGUIGlassAbnormalCaseReport()
            Call ScanGxSlotUnmatch()
            Call ScanCVGUICSTLoadComplete()
            Call ScanReadCVGUIGxFlowOut()
            Call ScanCVGUIGxFlowIn()
            Call ScanCVGUIUnloadRequestByCV()
            Call ScanCVGUIUnloadRequestByRST()
            Call ScanCVGUIDummyCancelResult()
            Call ScanCVGUIPortChangeRequest()
            Call ScanCVGUITransferRequestCVtoRST()
            Call ScanCVGUITransferRequestRSTtoCV()

            '-------------------------------------------
            Call ScanEQGUIStatus()
            Call ScanEQGUILoadGx()
            Call ScanEQGUIUnloadGx()
            Call ScanEQGUIRecipeModify()
            Call ScanEQGUIGxErase()
            Call ScanEQGUIRecipeCheck()

        End If
    End Sub

    Private Sub MyTimeOutSetting_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTimeOutSetting.Tick
        If MyCheckTcpip.nNewConnect = SIGNAL_ON Then

            WriteTimeOutParameter()

            WriteSampleGlassSettingParameter()

            MyTimeOutSetting.Enabled = False
            MyTimeOutSetting = Nothing
        End If
    End Sub
#End Region

#Region "Updata EQ GUI Word"
    Private Sub ScanEQGUIRecipeCheck()
        Dim strPPID(3) As String
        Dim nRecipeCheckResult(3) As Integer

        ReadEQGUIRecipeCheck(strPPID, nRecipeCheckResult)

        MyctlEQGUIMain.OcxPPIDChk1.SetWordData(strPPID, nRecipeCheckResult)

    End Sub

    Private Sub ScanEQGUIGxErase()
        Dim strGxID(3) As String

        ReadEQGUIGxErase(strGxID)

        MyctlEQGUIMain.OcxGxErase1.SetWordData(strGxID)

    End Sub

    Private Sub ScanEQGUIRecipeModify()
        Dim strPPID(3) As String
        Dim nModifyType(3) As Integer

        ReadEQGUIRecipeModify(strPPID, nModifyType)

        MyctlEQGUIMain.OcxPPIDModify1.SetWordData(strPPID, nModifyType)
    End Sub

    Private Sub ScanEQGUIUnloadGx()
        Dim strChipGraade(3) As String
        Dim strGxID(3) As String
        Dim nProcessResult(3) As Integer
        Dim strPSH(3) As String
        Dim nSampleGxFlag(3) As Integer
        Dim nSlotInfo(3) As Integer


        ReadEQGUIUnloadGx(strChipGraade, strGxID, nProcessResult, strPSH, nSampleGxFlag, nSlotInfo)

        MyctlEQGUIMain.OcxGxUnload1.SetWordData(strChipGraade, strGxID, nProcessResult, strPSH, nSampleGxFlag, nSlotInfo)
    End Sub

    Private Sub ScanEQGUILoadGx()
        Dim strCSTID(3) As String
        Dim strCurrentRecipe(3) As String
        Dim strDMQCGrade(3) As String
        Dim strEPPID(3) As String
        Dim strGxGrade(3) As String
        Dim strGxID(3) As String
        Dim strGxScrapFlag(3) As String
        Dim strMESID(3) As String
        Dim nMPAFlag(3) As Integer
        Dim strOperationID(3) As String
        Dim strPLineID(3) As String
        Dim strPoperID(3) As String
        Dim nProductCategory(3) As Integer
        Dim strProductCode(3) As String
        Dim strPToolID(3) As String
        Dim nSampleGxFlag(3) As Integer
        Dim nSlotInfo(3) As Integer

        ReadEQGUILoadGx1(strCSTID, strCurrentRecipe, strDMQCGrade, strEPPID, strGxGrade, strGxID)
        ReadEQGUILoadGx2(strGxScrapFlag, strMESID, nMPAFlag, strOperationID, strPLineID, strPoperID)
        ReadEQGUILoadGx3(nProductCategory, strProductCode, strPToolID, nSampleGxFlag, nSlotInfo)

        MyctlEQGUIMain.OcxGxLoad1.SetWordData(strCSTID, strCurrentRecipe, strDMQCGrade, strEPPID, strGxGrade, strGxID, strGxScrapFlag, strMESID, nMPAFlag, strOperationID, strPLineID, strPoperID, nProductCategory, strProductCode, strPToolID, nSampleGxFlag, nSlotInfo)
    End Sub

    Private Sub ScanEQGUIStatus()
        Dim nEQStatus(MAX_EQ) As Integer
        Dim strToolID(MAX_EQ) As String
        Dim nGxExistOnStage(MAX_EQ) As Integer
        Dim nGxInProcess(MAX_EQ) As Integer
        Dim nHandoffAvailable(MAX_EQ) As Integer
        Dim nAlarmOccurred(MAX_EQ) As Integer
        Dim nMPA1Stop(MAX_EQ) As Integer
        Dim nMPA2Stop(MAX_EQ) As Integer
        Dim nStationMode(MAX_EQ) As Integer
        Dim nRemoteStatus(MAX_EQ) As Integer

        ReadEQGUIStatus(nEQStatus, strToolID, nGxExistOnStage, nGxInProcess, nHandoffAvailable, nAlarmOccurred, nMPA1Stop, nMPA2Stop, nStationMode, nRemoteStatus)

        MyctlEQGUIMain.OcxStatus1.SetWordData(nRemoteStatus, nStationMode, nAlarmOccurred, nEQStatus, nGxInProcess, nGxExistOnStage, nHandoffAvailable, strToolID)
    End Sub
#End Region

#Region "Updata CV GUI Word"
    Private Sub ScanCVGUITransferRequestRSTtoCV()
        Dim strGxID(4) As String
        Dim nGxJudge(4) As Integer
        Dim strProductCode(4) As String
        Dim strPSHGroup(4) As String
        Dim nVCRPosition(4) As Integer

        ReadCVGUITransferRequestRSTtoCV1(strGxID(1), strGxID(2), strGxID(3), strGxID(4), nGxJudge(1), nGxJudge(2), nGxJudge(3), nGxJudge(4))
        ReadCVGUITransferRequestRSTtoCV2(strProductCode(1), strProductCode(2), strProductCode(3), strProductCode(4), strPSHGroup(1), strPSHGroup(2), strPSHGroup(3), strPSHGroup(4))
        ReadCVGUITransferRequestRSTtoCV3(nVCRPosition(1), nVCRPosition(2), nVCRPosition(3), nVCRPosition(4))

        MyctlCVGUIMain.GxTR_RST2CV1.SetWordData(strGxID, nGxJudge, strProductCode, strPSHGroup, nVCRPosition)
    End Sub

    Private Sub ScanCVGUITransferRequestCVtoRST()
        Dim strGxID(4) As String
        Dim nGxJudge(4) As Integer
        Dim strProductCode(4) As String
        Dim strPSHGroup(4) As String
        Dim nVCRPosition As Integer

        ReadCVGUITransferRequestCVtoRST1(strGxID(1), strGxID(2), strGxID(3), strGxID(4), nGxJudge(1), nGxJudge(2), nGxJudge(3), nGxJudge(4), nVCRPosition)
        ReadCVGUITransferRequestCVtoRST2(strProductCode(1), strProductCode(2), strProductCode(3), strProductCode(4), strPSHGroup(1), strPSHGroup(2), strPSHGroup(3), strPSHGroup(4))

        MyctlCVGUIMain.GxtR_CV2RST1.SetWordData(strGxID, nGxJudge, strProductCode, strPSHGroup, nVCRPosition)
    End Sub

    Private Sub ScanCVGUIPortChangeRequest()
        Dim nPortMode As Integer
        Dim nPortType As Integer
        Dim strProductCode As String = ""
        Dim nChangeResult As Integer

        ReadCVGUIPortChangeRequest(nPortMode, nPortType, nChangeResult, strProductCode)

        MyctlCVGUIMain.PortChangeReq1.SetWordData(nPortMode, nPortType, strProductCode, nChangeResult)
    End Sub

    Private Sub ScanCVGUIDummyCancelResult()
        Dim nDummyCancelResult As Integer

        ReadCVGUICVDummyCancelResult(nDummyCancelResult)
        MyctlCVGUIMain.CstDummyCancel1.SetWordData(nDummyCancelResult)
    End Sub

    Private Sub ScanCVGUIUnloadRequestByRST()
        Dim nUnloadStatus(5) As Integer
        Dim nTotalGxQty(5) As Integer

        ReadCVGUIUnloadRequestByCV(nUnloadStatus(1), nUnloadStatus(2), nUnloadStatus(3), nUnloadStatus(4), nUnloadStatus(5), nTotalGxQty(1), nTotalGxQty(2), nTotalGxQty(3), nTotalGxQty(4), nTotalGxQty(5))

        MyctlCVGUIMain.CstUnloadByRST1.SetWordData(nTotalGxQty, nUnloadStatus)
    End Sub

    Private Sub ScanCVGUIUnloadRequestByCV()
        Dim nUnloadStatus(5) As Integer
        Dim nTotalGxQty(5) As Integer

        ReadCVGUIUnloadRequestByCV(nUnloadStatus(1), nUnloadStatus(2), nUnloadStatus(3), nUnloadStatus(4), nUnloadStatus(5), nTotalGxQty(1), nTotalGxQty(2), nTotalGxQty(3), nTotalGxQty(4), nTotalGxQty(5))

        MyctlCVGUIMain.CstUnloadByCV1.SetWordData(nTotalGxQty, nUnloadStatus)
    End Sub

    Private Sub ScanCVGUIGxFlowIn()
        Dim strGxID As String = ""
        Dim strProductCode As String = ""
        Dim nSlotNumber As Integer

        ReadCVGUIGxFlowIn(strGxID, strProductCode, nSlotNumber)
        MyctlCVGUIMain.GxFlowIn1.SetWordData(strGxID, strProductCode, nSlotNumber)
    End Sub

    Private Sub ScanReadCVGUIGxFlowOut()
        Dim strGxID As String = ""
        Dim strProductCode As String = ""
        Dim strPSHGroup As String = ""
        Dim nVCRPosition As Integer
        Dim nGxJudgement As Integer
        Dim nSlotNumber(5) As Integer
        Dim nFor As Integer
        Dim astrProductGxId(3) As String
        Dim anGxflowoutInfo(2) As Integer

        'ReadCVGUIGxFlowOut1(strGxID, strProductCode, strPSHGroup, nVCRPosition, nGxJudgement)
        ReadCVGUIGxFlowOut2(nSlotNumber(1), nSlotNumber(2), nSlotNumber(3), nSlotNumber(4), nSlotNumber(5))

        For nFor = 1 To 3
            astrProductGxId = GetCVGUIGxFlowOut1(nFor)
            strProductCode = astrProductGxId(1)
            strGxID = astrProductGxId(2)
            strPSHGroup = astrProductGxId(3)

            anGxflowoutInfo = GetCVGUIGxFlowOut2(nFor)
            nGxJudgement = anGxflowoutInfo(1)
            nVCRPosition = anGxflowoutInfo(2)

            MyctlCVGUIMain.GxFlowOut1.SetWordData(nFor, strGxID, nGxJudgement, strPSHGroup, nVCRPosition, strProductCode, nSlotNumber)
        Next
    End Sub

    Private Sub ScanCVGUICSTLoadComplete()
        Dim nMiniSlot(5) As Integer
        Dim strCSTID(5) As String

        ReadCVGUICSTLoadComplete(strCSTID(1), strCSTID(2), strCSTID(3), strCSTID(4), strCSTID(5), nMiniSlot(1), nMiniSlot(2), nMiniSlot(3), nMiniSlot(4), nMiniSlot(5))

        MyctlCVGUIMain.CstLoadComplete1.SetWordData(nMiniSlot, strCSTID)
    End Sub

    Private Sub ScanGxSlotUnmatch()
        Dim nPortNo As Integer
        Dim nSlotNumber As Integer
        Dim nUnmatchCase As Integer

        ReadCVGUIGxSlotUnmatch(nPortNo, nSlotNumber, nUnmatchCase)

        MyctlCVGUIMain.GxInfoUnmatch1.SetWordData(nPortNo, nSlotNumber, nUnmatchCase)

    End Sub

    Private Sub ScanCVGUIGlassAbnormalCaseReport()
        Dim nAbnormalCase As Integer
        Dim nGxPosition As Integer
        Dim strSourceGxID As String = ""
        Dim strVCRGxID As String = ""

        ReadCVGUIGlassAbnormalCase(nAbnormalCase, nGxPosition, strSourceGxID, strVCRGxID)

        MyctlCVGUIMain.GxAbnormal1.SetWordData(nAbnormalCase, nGxPosition, strSourceGxID, strVCRGxID)

    End Sub

    Private Sub ScanCVGUIGlassDataRequest()
        Dim strProductCode As String = ""
        Dim strPSHGrade As String = ""
        Dim nGxJudgment As Integer
        Dim nVCRPos As Integer
        Dim strGXID As String = ""

        ReadCVGUIGlassDataRequest(strProductCode, strPSHGrade, nGxJudgment, nVCRPos, strGXID)

        MyctlCVGUIMain.GxDataReq1.SetWordData(strGXID, nGxJudgment, strProductCode, strPSHGrade, nVCRPos)

    End Sub

    Private Sub ScanCVGUIPortStatus()
        Dim nPortMode(5) As Integer
        Dim nPortType(5) As Integer

        ReadCVGUIPortStatus(nPortMode(1), nPortMode(2), nPortMode(3), nPortMode(4), nPortMode(5), nPortType(1), nPortType(2), nPortType(3), nPortType(4), nPortType(5))

        MyctlCVGUIMain.PortStatus1.SetWordData(nPortMode, nPortType)
    End Sub

    'Private Sub ScanCVGUIProcesscmd()
    '    Dim strCSTID As String = ""
    '    Dim strSlotNo As String = ""
    '    Dim strPortNo As String = ""
    '    Dim strProcessCommand As String = ""
    '    Dim strGXQty As String = ""

    '    ReadCVGUIProcessCmd(strCSTID, strSlotNo, strPortNo, strProcessCommand, strGXQty)

    '    MyctlCVGUIMain.CstProcessCMD1.SetWordData(strCSTID, strSlotNo, strPortNo, strProcessCommand, strGXQty)
    'End Sub

    Private Sub ScanCVGUIProcesscmd()
        Dim strCSTID As String = ""
        Dim strSlotNo As String = ""
        Dim strPortNo As String = ""
        Dim strProcessCommand As String = ""
        Dim strGXQty As String = ""

        Dim astrSlotCSTID(2) As String
        Dim anPNumberCmdQty(3) As Integer
        Dim nFor As Integer


        For nFor = 1 To 3
            astrSlotCSTID = GetProcessComd1(nFor)
            strSlotNo = astrSlotCSTID(1)
            strCSTID = astrSlotCSTID(2)

            anPNumberCmdQty = GetProcessComd2(nFor)
            strPortNo = anPNumberCmdQty(1).ToString
            strProcessCommand = anPNumberCmdQty(2).ToString
            strGXQty = anPNumberCmdQty(3).ToString

            MyctlCVGUIMain.CstProcessCMD1.SetWordData(nFor, strCSTID, strSlotNo, strPortNo, strProcessCommand, strGXQty)
        Next
    End Sub

    Private Sub ScanCVGUIStatusReport()
        Dim strRunningMode As String = ""
        Dim strAlarmOccurred As String = ""
        Dim strCSTProductCode1 As String = ""
        Dim strCSTProductCode2 As String = ""
        Dim strCSTProductCode3 As String = ""
        Dim strCSTProductCode4 As String = ""
        Dim strCSTProductCode5 As String = ""
        Dim strCVStatus As String = ""
        Dim strGxExistInfo1 As String = ""
        Dim strGxExistInfo2 As String = ""
        Dim strGxExistInfo3 As String = ""
        Dim strGxExistInfo4 As String = ""
        Dim strGxExistInfo5 As String = ""
        Dim strGxQTYInCST1 As String = ""
        Dim strGxQTYInCST2 As String = ""
        Dim strGxQTYInCST3 As String = ""
        Dim strGxQTYInCST4 As String = ""
        Dim strGxQTYInCST5 As String = ""
        Dim strToolId As String = ""


        ReadCVGUIStatus1(strRunningMode, strAlarmOccurred, strCSTProductCode1, strCSTProductCode2, strCSTProductCode3, strCSTProductCode4, strCSTProductCode5, strCVStatus)
        ReadCVGUIStatus2(strGxExistInfo1, strGxExistInfo2, strGxExistInfo3, strGxExistInfo4, strGxExistInfo5, strGxQTYInCST1, strGxQTYInCST2, strGxQTYInCST3, strGxQTYInCST4, strGxQTYInCST5, strToolId)

        MyctlCVGUIMain.StatusReport1.SetWordData(strRunningMode, strAlarmOccurred, strCSTProductCode1, strCSTProductCode2, strCSTProductCode3, strCSTProductCode4, strCSTProductCode5, strCVStatus, strGxExistInfo1, strGxExistInfo2, strGxExistInfo3, strGxExistInfo4, strGxExistInfo5, strGxQTYInCST1, strGxQTYInCST2, strGxQTYInCST3, strGxQTYInCST4, strGxQTYInCST5, strToolId)
    End Sub

#End Region

    Public Sub ShowTimeOutForm()
        If MyTimeoutfrm.IsDisposed Then
            MyTimeoutfrm = Nothing
            MyTimeoutfrm = New frmTimeOutSetting
        End If

        If Not MyTimeoutfrm.Visible And (Not MyTimeoutfrm.IsDisposed) Then
            MyTimeoutfrm.Show()
        End If
    End Sub

    Public Sub ShowSampleGlassSetting()

        If MySampleGlassSettingfrm.IsDisposed Then
            MySampleGlassSettingfrm = Nothing
            MySampleGlassSettingfrm = New frmSampleGlassSetting
        End If

        If Not MySampleGlassSettingfrm.Visible And (Not MySampleGlassSettingfrm.IsDisposed) Then
            MySampleGlassSettingfrm.Show()
        End If
    End Sub

    Private Sub checkTcpipConnect()
        If MyTCPIPIF.ConnectStatus = "Connected" Then
            MyCheckTcpip.nNewConnect = 1
        Else
            MyCheckTcpip.nNewConnect = 0
        End If

        If MyCheckTcpip.nOldConnect <> MyCheckTcpip.nNewConnect Then
            If MyCheckTcpip.nNewConnect = SIGNAL_ON Then
                DebugLog(eIFIndex.INDEX_PLC, eLogType.[SYS], "TCPIP Connect ...")
                RaiseEvent TCPIPConnect(True)
            Else
                DebugLog(eIFIndex.INDEX_PLC, eLogType.[SYS], "TCPIP Disconnect ...")
                RaiseEvent TCPIPConnect(False)
            End If
            MyCheckTcpip.nOldConnect = MyCheckTcpip.nNewConnect
        End If
    End Sub

#Region "PLC IF Method"

    Public ReadOnly Property GetRobotIOInput(ByVal nItem As eRobotActualStatus) As Integer
        Get
            Select Case nItem
                Case eRobotActualStatus.UP_ARM_SENSOR
                    Return MyRSTNewWord.mnUpArmSensor

                Case eRobotActualStatus.LOW_ARM_SENSOR
                    Return MyRSTNewWord.mnLowArmSensor

                Case eRobotActualStatus.UP_ARM_VACCUM
                    Return MyRSTNewWord.mnUpArmVaccum

                Case eRobotActualStatus.LOW_ARM_VACCUM
                    Return MyRSTNewWord.mnLowArmVaccum

                Case eRobotActualStatus.SERVO_ON
                    Return MyRSTNewWord.mnRSTServoOn

                Case eRobotActualStatus.READY
                    Return MyRSTNewWord.mnRSTReady

                Case eRobotActualStatus.CMD_BUSY
                    Return MyRSTNewWord.mnCMDBusy

                Case eRobotActualStatus.FORK_EXTEND
                    Return MyRSTNewWord.mnForkExtend
            End Select
        End Get
    End Property

    Public ReadOnly Property GetBufferGlassInfo(ByVal nBufferPortNo As Integer, ByVal nSlotNo As Integer) As clsBufferGlassInfo
        Get
            Dim BufferGlassInfo As New clsBufferGlassInfo

            Dim nGlassDataRef As Integer = 0
            Dim nSampleGlassFlag As Integer = 0
            Dim nProductcategory As eProductCategory
            Dim nSlotInfo As Integer = 0
            Dim strGlassID As String = ""
            Dim strEQ1EPPID As String = ""
            Dim strEQ2EPPID As String = ""
            Dim strMESID As String = ""
            Dim strProductCode As String = ""
            Dim strCurrentRecipe As String = ""
            Dim strPOPERID As String = ""
            Dim strPLINEID As String = ""
            Dim strPTOOLID As String = ""
            Dim strCSTID As String = ""
            Dim strOperationID As String = ""
            Dim strGxGrade As String = ""
            Dim strDMQCGrade As String = ""
            Dim strGlassScrapFlag As String = ""
            Dim nAOIFUNMode As Integer = 0

            Dim nRDGRADE As Integer = 0
            Dim nDGRADE As Integer = 0
            Dim nGGRADE As Integer = 0
            Dim strPSHGrade As String = ""
            Dim nPToolIDIdx As Integer = 0
            Dim strDMQCToolID As String = ""
            Dim strChipGrade As String = ""
            Dim nFIRMFLAG As Integer = 0
            Dim nSCRPFLAG As Integer = 0
            Dim nRWKFLAG As Integer = 0
            Dim nPortNo As Integer = 0
            Dim nTargetPosition As Integer = 0
            Dim nRobotSpeed As Integer = 0

            Dim nGxGrade As eGGRADE
            Dim nDMQCGrade As eDGRADE
            Dim nGlassScrapFlag As eSCRPFLAG

            Dim strTrimGxGrade As String = ""
            Dim strTrimDMQCGrade As String = ""
            Dim strTrimGlassScrapFlag As String = ""

            Dim nRSTSpeed As clsPLC.eRobotSpeed

            Dim nPort As Integer = 0
            Dim nSlot As Integer = 0

            '-------------------------------------------------------
            Dim nALNflag As Integer = 0
            Dim nFIinspectionFlag As Integer = 0
            Dim nRepairInkFlag As Integer = 0
            Dim nProcessFlag As Integer = 0
            Dim nFIFCFFlag As Integer = 0
            Dim strEQ1StartTime As String = ""
            Dim strEQ1EndTime As String = ""
            Dim strEQ2StartTime As String = ""
            Dim strEQ2EndTime As String = ""
            Dim strEQ3StartTime As String = ""
            Dim strEQ3EndTime As String = ""
            '-------------------------------------------------------
            Dim nRepairReviewFlag As Integer

            Try

                Select Case nBufferPortNo
                    Case 1
                        ReadZRAddr(BUFFER_PORT1_START_ADDR + (200 * (nSlotNo - 1)), g_anBufferPort1SlotInfo)

                    Case 2
                        ReadZRAddr(BUFFER_PORT2_START_ADDR + (200 * (nSlotNo - 1)), g_anBufferPort2SlotInfo)

                    Case 3
                        ReadZRAddr(BUFFER_PORT3_START_ADDR + (200 * (nSlotNo - 1)), g_anBufferPort3SlotInfo)
                End Select

                ReadBufGxInfo1(nBufferPortNo, nGlassDataRef, nSampleGlassFlag, nProductcategory, nSlotInfo, strGlassID, strEQ1EPPID, strEQ2EPPID, strMESID, strProductCode, strCurrentRecipe, strPOPERID, strPLINEID, strPTOOLID, strCSTID, strOperationID, strGxGrade, strDMQCGrade, strGlassScrapFlag, nAOIFUNMode, nALNflag, nFIinspectionFlag)
                ReadBufGxInfo2(nBufferPortNo, nRDGRADE, nDGRADE, nGGRADE, strPSHGrade, nPToolIDIdx, strDMQCToolID, strChipGrade, nFIRMFLAG, nSCRPFLAG, nRWKFLAG, nPortNo, nTargetPosition, nRobotSpeed, nRepairInkFlag, nProcessFlag, nFIFCFFlag, strEQ1StartTime, strEQ1EndTime, strEQ2StartTime, strEQ2EndTime, strEQ3StartTime, strEQ3EndTime, nRepairReviewFlag)

                With BufferGlassInfo
                    '.GlassDataRef = nGlassDataRef
                    .SampleGlassFlag = nSampleGlassFlag
                    .ProductCategory = nProductcategory

                    nSlot = nSlotInfo
                    If nSlot > MAX_SLOTS Or nSlot < 0 Then
                        .SlotInfo = 0
                    Else
                        .SlotInfo = nSlotInfo
                    End If

                    .GlassID = strGlassID
                    .EPPID(1) = strEQ1EPPID
                    .EPPID(2) = strEQ2EPPID
                    .MESID = strMESID
                    .ProductCode = strProductCode
                    .CurrentRecipe = strCurrentRecipe
                    .POPERID = strPOPERID
                    .PLINEID = strPLINEID
                    .PTOOLID = strPTOOLID
                    .CSTID = strCSTID
                    .OperationID = strOperationID

                    strTrimGxGrade = Trim(strGxGrade)

                    If strTrimGxGrade = "O" Then
                        nGxGrade = eGGRADE.OK
                    ElseIf strTrimGxGrade = "G" Then
                        nGxGrade = eGGRADE.GRAY
                    ElseIf strTrimGxGrade = "N" Then
                        nGxGrade = eGGRADE.NG
                    Else
                        nGxGrade = eGGRADE.NO_GLASS
                    End If

                    strTrimDMQCGrade = Trim(strDMQCGrade)

                    If strTrimDMQCGrade = "O" Then
                        nDMQCGrade = eDGRADE.OK
                    ElseIf strTrimDMQCGrade = "R" Then
                        nDMQCGrade = eDGRADE.REVIEW
                    ElseIf strTrimDMQCGrade = "N" Then
                        nDMQCGrade = eDGRADE.NG
                    Else
                        nDMQCGrade = eDGRADE.NO_GLASS
                    End If

                    strTrimGlassScrapFlag = Trim(strGlassScrapFlag)

                    If strTrimGlassScrapFlag = "S" Then
                        nGlassScrapFlag = eSCRPFLAG.MARKED_SCRAP
                    ElseIf strTrimGlassScrapFlag = "C" Then
                        nGlassScrapFlag = eSCRPFLAG.MARKED_RECYCLED
                    Else
                        nGlassScrapFlag = 0
                    End If

                    .GlassGrade = nGxGrade
                    .DMQCGrade = nDMQCGrade
                    .GlassScrapFlag = nGlassScrapFlag
                    .AOIFunctionMode = nAOIFUNMode

                    nPort = nPortNo
                    If nPort > MAX_PORTS Or nPort < 0 Then
                        .PortNo = 0
                    Else
                        .PortNo = nPortNo
                    End If

                    .FIinspectionFlag = nFIinspectionFlag

                    .TargetPosition = nTargetPosition

                    .RepairInkFlag = nRepairInkFlag

                    .ProcessFlag = nProcessFlag

                    nRSTSpeed = nRobotSpeed
                    Select Case nRSTSpeed
                        Case eRobotSpeed.LOW
                            .RobotSpeed = nRSTSpeed
                        Case eRobotSpeed.MID
                            .RobotSpeed = nRSTSpeed
                        Case eRobotSpeed.HI
                            .RobotSpeed = nRSTSpeed
                        Case Else
                            .RobotSpeed = eRobotSpeed.NA
                    End Select

                    If nRepairReviewFlag <> 0 Then
                        .RepairReviewFlag = 1
                    End If

                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get Buffer Glass Info ,GlassID=" & "[" & .GlassID & "]" & ",PortNo=" & .PortNo & ",SlotNo=" & .SlotInfo & ",LotPPID=[" & .CurrentRecipe & "],EQ1 EPPID=[" & .EPPID(1) & "],EQ2 EPPID=[" & .EPPID(2) & "],ProductCode=[" & .ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get Buffer Glass Info ,CassetteID=" & "[" & .CSTID & "]" & ",TargetPosition=" & .TargetPosition & ",RobotSpeed=" & .RobotSpeed & ",MESID=[" & .MESID & "],POPERID=[" & .POPERID & "],PLINEID=[" & .PLINEID & "],PTOOLID=[" & .PTOOLID & "]" & " ,RepairInkFlag=" & .RepairInkFlag & " ,ProcessFlag" & .ProcessFlag)
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get Buffer Glass Info ,GlassGrade=" & "[" & .GlassGrade & "]" & ",DMQCGrade=[" & .DMQCGrade & "],ProductCategory=" & .ProductCategory & ",OperationID=[" & .OperationID & "],SampleGlassFlag=" & .SampleGlassFlag & ",GlassScrapFlag=" & .GlassScrapFlag & ",AOIFunctionMode=" & .AOIFunctionMode & ",RepairReviewFlag=" & nRepairReviewFlag)


                    '.RDGRADE = nRDGRADE
                    '.DGRADE = nDGRADE
                    '.GGRADE = nGGRADE
                    '.PSHGrade = strPSHGrade
                    '.PToolIDIndex = nPToolIDIdx
                    '.DMQCToolID = strDMQCToolID
                    '.ChipGrade = strChipGrade
                    .FIRMFLAG = nFIRMFLAG
                    .SCRPFLAG = nSCRPFLAG
                    .RWKFLAG = nRWKFLAG
                End With

            Catch ex As Exception
                DebugLog(eIFIndex.INDEX_PLC, eLogType.ERR, ex.ToString.ToString)
            End Try

            Return BufferGlassInfo
        End Get
    End Property

    Public WriteOnly Property WriteBufferGlassInfo(ByVal nBufferPortNo As Integer, ByVal nSlotNo As Integer) As clsBufferGlassInfo

        Set(ByVal value As clsBufferGlassInfo)
            Dim anWriteBufferGlassInfo(LEN_GLASS_DATA1) As Integer

            Dim anGlassID(LEN_A_GLASS_ID) As Integer
            Dim anEQ1EPPID(LEN_A_EPPID) As Integer
            Dim anEQ2EPPID(LEN_A_EPPID) As Integer
            Dim anMESID(LEN_A_MESID) As Integer
            Dim anProductCode(LEN_A_PRODUCT_CODE) As Integer
            Dim anCurrentRecipe(LEN_A_CURRENT_RECIPE) As Integer
            Dim anPOPERID(LEN_A_POPERID) As Integer
            Dim anPLineID(LEN_A_PLINEID) As Integer
            Dim anPToolID(LEN_A_PTOOLID) As Integer
            Dim anCSTID(LEN_A_CST_ID) As Integer
            Dim anOperationID(LEN_A_OP_ID) As Integer
            Dim anGlassGrade(LEN_A_GLASS_GRADE) As Integer
            Dim anDMQCGrade(LEN_A_DMQC_GRADE) As Integer
            Dim anGlassScrapFlag(LEN_A_SCRPFLAG) As Integer
            Dim anPSHGrade(LEN_A_PSH_GROUP) As Integer
            Dim anDMQCToolID(LEN_A_DMQC_TOOL_ID) As Integer

            Dim nChipGradeData(9) As Integer

            Dim strGlassID As String = ""
            Dim nPortNoSlotNoSetting As Integer

            Dim strGlassGrade As String = ""
            Dim strDMQCGrade As String = ""
            Dim strGXScrapFlag As String = ""

            Dim strRWKFLAG As String = ""
            Dim anRWKFLAG(LEN_A_RWKFLAG) As Integer
            Dim strFIRMFLAG As String = ""
            Dim anFIRMFLAG(LEN_A_FIRMFLAG) As Integer


            With value
                anWriteBufferGlassInfo(0) = .SampleGlassFlag
                anWriteBufferGlassInfo(1) = .ProductCategory
                anWriteBufferGlassInfo(2) = .SlotInfo

                strGlassID = Trim(.GlassID)

                ASCStringConvert(.GlassID, LEN_A_GLASS_ID, anGlassID)
                anWriteBufferGlassInfo(3) = anGlassID(0)
                anWriteBufferGlassInfo(4) = anGlassID(1)
                anWriteBufferGlassInfo(5) = anGlassID(2)
                anWriteBufferGlassInfo(6) = anGlassID(3)
                anWriteBufferGlassInfo(7) = anGlassID(4)
                anWriteBufferGlassInfo(8) = anGlassID(5)

                ASCStringConvert(.EPPID(1), LEN_A_EPPID, anEQ1EPPID)
                anWriteBufferGlassInfo(9) = anEQ1EPPID(0)
                anWriteBufferGlassInfo(10) = anEQ1EPPID(1)

                ASCStringConvert(.EPPID(2), LEN_A_EPPID, anEQ2EPPID)
                anWriteBufferGlassInfo(11) = anEQ2EPPID(0)
                anWriteBufferGlassInfo(12) = anEQ2EPPID(1)

                ASCStringConvert(.MESID, LEN_A_MESID, anMESID)
                anWriteBufferGlassInfo(13) = anMESID(0)
                anWriteBufferGlassInfo(14) = anMESID(1)
                anWriteBufferGlassInfo(15) = anMESID(2)
                anWriteBufferGlassInfo(16) = anMESID(3)

                ASCStringConvert(.ProductCode, LEN_A_PRODUCT_CODE, anProductCode)
                anWriteBufferGlassInfo(17) = anProductCode(0)
                anWriteBufferGlassInfo(18) = anProductCode(1)
                anWriteBufferGlassInfo(19) = anProductCode(2)
                anWriteBufferGlassInfo(20) = anProductCode(3)
                anWriteBufferGlassInfo(21) = anProductCode(4)
                anWriteBufferGlassInfo(22) = anProductCode(5)
                anWriteBufferGlassInfo(23) = anProductCode(6)
                anWriteBufferGlassInfo(24) = anProductCode(7)
                anWriteBufferGlassInfo(25) = anProductCode(8)
                anWriteBufferGlassInfo(26) = anProductCode(9)
                anWriteBufferGlassInfo(27) = anProductCode(10)
                anWriteBufferGlassInfo(28) = anProductCode(11)
                anWriteBufferGlassInfo(29) = anProductCode(12)

                ASCStringConvert(.CurrentRecipe, LEN_A_CURRENT_RECIPE, anCurrentRecipe)
                anWriteBufferGlassInfo(30) = anCurrentRecipe(0)
                anWriteBufferGlassInfo(31) = anCurrentRecipe(1)
                anWriteBufferGlassInfo(32) = anCurrentRecipe(2)
                anWriteBufferGlassInfo(33) = anCurrentRecipe(3)
                anWriteBufferGlassInfo(34) = anCurrentRecipe(4)
                anWriteBufferGlassInfo(35) = anCurrentRecipe(5)
                anWriteBufferGlassInfo(36) = anCurrentRecipe(6)
                anWriteBufferGlassInfo(37) = anCurrentRecipe(7)
                anWriteBufferGlassInfo(38) = anCurrentRecipe(8)
                anWriteBufferGlassInfo(39) = anCurrentRecipe(9)
                anWriteBufferGlassInfo(40) = anCurrentRecipe(10)
                anWriteBufferGlassInfo(41) = anCurrentRecipe(11)
                anWriteBufferGlassInfo(42) = anCurrentRecipe(12)
                anWriteBufferGlassInfo(43) = anCurrentRecipe(13)
                anWriteBufferGlassInfo(44) = anCurrentRecipe(14)
                anWriteBufferGlassInfo(45) = anCurrentRecipe(15)

                ASCStringConvert(.POPERID, LEN_A_POPERID, anPOPERID)
                anWriteBufferGlassInfo(46) = anPOPERID(0)
                anWriteBufferGlassInfo(47) = anPOPERID(1)
                anWriteBufferGlassInfo(48) = anPOPERID(2)
                anWriteBufferGlassInfo(49) = anPOPERID(3)
                anWriteBufferGlassInfo(50) = anPOPERID(4)
                anWriteBufferGlassInfo(51) = anPOPERID(5)
                anWriteBufferGlassInfo(52) = anPOPERID(6)
                anWriteBufferGlassInfo(53) = anPOPERID(7)
                anWriteBufferGlassInfo(54) = anPOPERID(8)
                anWriteBufferGlassInfo(55) = anPOPERID(9)
                anWriteBufferGlassInfo(56) = anPOPERID(10)
                anWriteBufferGlassInfo(57) = anPOPERID(11)
                anWriteBufferGlassInfo(58) = anPOPERID(12)

                ASCStringConvert(.PLINEID, LEN_A_PLINEID, anPLineID)
                anWriteBufferGlassInfo(59) = anPLineID(0)
                anWriteBufferGlassInfo(60) = anPLineID(1)
                anWriteBufferGlassInfo(61) = anPLineID(2)
                anWriteBufferGlassInfo(62) = anPLineID(3)

                ASCStringConvert(.PTOOLID, LEN_A_PTOOLID, anPToolID)
                anWriteBufferGlassInfo(63) = anPToolID(0)
                anWriteBufferGlassInfo(64) = anPToolID(1)
                anWriteBufferGlassInfo(65) = anPToolID(2)
                anWriteBufferGlassInfo(66) = anPToolID(3)

                ASCStringConvert(.CSTID, LEN_A_CST_ID, anCSTID)
                anWriteBufferGlassInfo(67) = anCSTID(0)
                anWriteBufferGlassInfo(68) = anCSTID(1)
                anWriteBufferGlassInfo(69) = anCSTID(2)

                ASCStringConvert(.OperationID, LEN_A_OP_ID, anOperationID)
                anWriteBufferGlassInfo(70) = anOperationID(0)
                anWriteBufferGlassInfo(71) = anOperationID(1)
                anWriteBufferGlassInfo(72) = anOperationID(2)
                anWriteBufferGlassInfo(73) = anOperationID(3)
                anWriteBufferGlassInfo(74) = anOperationID(4)
                anWriteBufferGlassInfo(75) = anOperationID(5)
                anWriteBufferGlassInfo(76) = anOperationID(6)
                anWriteBufferGlassInfo(77) = anOperationID(7)
                anWriteBufferGlassInfo(78) = anOperationID(8)
                anWriteBufferGlassInfo(79) = anOperationID(9)
                anWriteBufferGlassInfo(80) = anOperationID(10)
                anWriteBufferGlassInfo(81) = anOperationID(11)
                anWriteBufferGlassInfo(82) = anOperationID(12)


                Select Case .GlassGrade
                    Case eGGRADE.OK
                        strGlassGrade = "O"
                    Case eGGRADE.NG
                        strGlassGrade = "N"
                    Case eGGRADE.GRAY
                        strGlassGrade = "G"
                    Case eGGRADE.NO_GLASS
                        strGlassGrade = " "
                End Select

                ASCStringConvert(strGlassGrade, LEN_A_GLASS_GRADE, anGlassGrade)
                anWriteBufferGlassInfo(83) = anGlassGrade(0)

                Select Case .DMQCGrade
                    Case eDGRADE.OK
                        strDMQCGrade = "O"
                    Case eDGRADE.REVIEW
                        strDMQCGrade = "R"
                    Case eDGRADE.NG
                        strDMQCGrade = "N"
                    Case eDGRADE.NO_GLASS
                        strDMQCGrade = " "
                End Select

                ASCStringConvert(strDMQCGrade, LEN_A_DMQC_GRADE, anDMQCGrade)
                anWriteBufferGlassInfo(84) = anDMQCGrade(0)

                Select Case .GlassScrapFlag
                    Case eSCRPFLAG.MARKED_SCRAP
                        strGXScrapFlag = "S"
                    Case eSCRPFLAG.MARKED_RECYCLED
                        strGXScrapFlag = "C"
                    Case Else
                        strGXScrapFlag = " "
                End Select

                ASCStringConvert(strGXScrapFlag, LEN_A_SCRPFLAG, anGlassScrapFlag)
                anWriteBufferGlassInfo(85) = anGlassScrapFlag(0)

                anWriteBufferGlassInfo(86) = .AOIFunctionMode

                anWriteBufferGlassInfo(87) = .PortNo
                anWriteBufferGlassInfo(88) = .TargetPosition
                anWriteBufferGlassInfo(89) = .RobotSpeed

                Select Case .RWKFLAG
                    Case eRWKFLAG.REWORK
                        strRWKFLAG = "R"
                    Case eRWKFLAG.NORMAL_GLASS
                        strRWKFLAG = " "
                    Case Else
                        strRWKFLAG = " "
                End Select

                ASCStringConvert(strRWKFLAG, LEN_A_RWKFLAG, anRWKFLAG)
                anWriteBufferGlassInfo(90) = anRWKFLAG(0)

                Select Case .FIRMFLAG
                    Case eFIRMFLAG.FI_MACRO
                        strFIRMFLAG = "M"
                    Case eFIRMFLAG.OTHERS
                        strFIRMFLAG = " "
                    Case Else
                        strFIRMFLAG = " "
                End Select

                ASCStringConvert(strFIRMFLAG, LEN_A_FIRMFLAG, anFIRMFLAG)
                anWriteBufferGlassInfo(91) = anFIRMFLAG(0)

                anWriteBufferGlassInfo(92) = .RepairInkFlag
            End With

            DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Buffer Glass Info ,GlassID=" & "[" & value.GlassID & "]" & ",PortNo=" & value.PortNo & ",SlotNo=" & value.SlotInfo & ",LotPPID=[" & value.CurrentRecipe & "],EQ1 EPPID=[" & value.EPPID(1) & "],EQ2 EPPID=[" & value.EPPID(2) & "],ProductCode=[" & value.ProductCode & "]")
            DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Buffer Glass Info ,CassetteID=" & "[" & value.CSTID & "]" & ",TargetPosition=" & value.TargetPosition & ",RobotSpeed=" & value.RobotSpeed & ",MESID=[" & value.MESID & "],POPERID=[" & value.POPERID & "],PLINEID=[" & value.PLINEID & "],PTOOLID=[" & value.PTOOLID & "]")
            DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Buffer Glass Info ,GlassGrade=" & "[" & strGlassGrade & "]" & ",DMQCGrade=[" & strDMQCGrade & "],ProductCategory=" & value.ProductCategory & ",OperationID=[" & value.OperationID & "],SampleGlassFlag=" & value.SampleGlassFlag & ",GlassScrapFlag=" & value.GlassScrapFlag & ",AOIFunctionMode=" & value.AOIFunctionMode & ",InkFlag=" & value.RepairInkFlag)

            Select Case nBufferPortNo
                Case 1
                    nPortNoSlotNoSetting = (nSlotNo * 256) + eModifyGlassInfo.BUFFER1

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, nPortNoSlotNoSetting)

                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anWriteBufferGlassInfo)

                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)

                    RaiseEvent RSTBufferPortGlassInfoWriteComplete(nBufferPortNo, nSlotNo)
                Case 2
                    nPortNoSlotNoSetting = (nSlotNo * 256) + eModifyGlassInfo.BUFFER2

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, nPortNoSlotNoSetting)

                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anWriteBufferGlassInfo)

                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)

                    RaiseEvent RSTBufferPortGlassInfoWriteComplete(nBufferPortNo, nSlotNo)
                Case 3
                    nPortNoSlotNoSetting = (nSlotNo * 256) + eModifyGlassInfo.BUFFER3

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, nPortNoSlotNoSetting)

                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anWriteBufferGlassInfo)

                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)

                    RaiseEvent RSTBufferPortGlassInfoWriteComplete(nBufferPortNo, nSlotNo)
                Case 4

                    'RaiseEvent RSTBufferPortGlassInfoWriteComplete(nBufferPortNo, nSlotNo)
            End Select
        End Set
    End Property


    Public WriteOnly Property WriteArmGlassInfo(ByVal nArm As eRSTArm) As clsArmGlassInfo
        Set(ByVal value As clsArmGlassInfo)
            Dim anArmGlassInfo(LEN_GLASS_DATA1) As Integer

            Dim anGlassID(LEN_A_GLASS_ID) As Integer
            Dim anEQ1EPPID(LEN_A_EPPID) As Integer
            Dim anEQ2EPPID(LEN_A_EPPID) As Integer

            Dim anMESID(LEN_A_MESID) As Integer
            Dim anProductCode(LEN_A_PRODUCT_CODE) As Integer
            Dim anCurrentRecipe(LEN_A_CURRENT_RECIPE) As Integer
            Dim anPOPERID(LEN_A_POPERID) As Integer
            Dim anPLineID(LEN_A_PLINEID) As Integer
            Dim anPToolID(LEN_A_PTOOLID) As Integer
            Dim anCSTID(LEN_A_CST_ID) As Integer
            Dim anOperationID(LEN_A_OP_ID) As Integer
            Dim anGlassGrade(LEN_A_GLASS_GRADE) As Integer
            Dim anDMQCGrade(LEN_A_DMQC_GRADE) As Integer
            Dim anGlassScrapFlag(LEN_A_SCRPFLAG) As Integer
            Dim anPSHGrade(LEN_A_PSH_GROUP) As Integer
            Dim anDMQCToolID(LEN_A_DMQC_TOOL_ID) As Integer
            Dim nChipGradeData(9) As Integer

            Dim strGlassID As String = ""
            Dim strGlassGrade As String = ""
            Dim strDMQCGrade As String = ""
            Dim strGXScrapFlag As String = ""

            Dim strRWKFLAG As String = ""
            Dim anRWKFLAG(LEN_A_RWKFLAG) As Integer
            Dim strFIRMFLAG As String = ""
            Dim anFIRMFLAG(LEN_A_FIRMFLAG) As Integer

            With value
                anArmGlassInfo(0) = .SampleGlassFlag
                anArmGlassInfo(1) = .ProductCategory
                anArmGlassInfo(2) = .SlotInfo

                strGlassID = Trim(.GlassID)

                ASCStringConvert(.GlassID, LEN_A_GLASS_ID, anGlassID)
                anArmGlassInfo(3) = anGlassID(0)
                anArmGlassInfo(4) = anGlassID(1)
                anArmGlassInfo(5) = anGlassID(2)
                anArmGlassInfo(6) = anGlassID(3)
                anArmGlassInfo(7) = anGlassID(4)
                anArmGlassInfo(8) = anGlassID(5)

                ASCStringConvert(.EPPID(1), LEN_A_EPPID, anEQ1EPPID)
                anArmGlassInfo(9) = anEQ1EPPID(0)
                anArmGlassInfo(10) = anEQ1EPPID(1)

                ASCStringConvert(.EPPID(2), LEN_A_EPPID, anEQ2EPPID)
                anArmGlassInfo(11) = anEQ2EPPID(0)
                anArmGlassInfo(12) = anEQ2EPPID(1)

                ASCStringConvert(.MESID, LEN_A_MESID, anMESID)
                anArmGlassInfo(13) = anMESID(0)
                anArmGlassInfo(14) = anMESID(1)
                anArmGlassInfo(15) = anMESID(2)
                anArmGlassInfo(16) = anMESID(3)

                ASCStringConvert(.ProductCode, LEN_A_PRODUCT_CODE, anProductCode)
                anArmGlassInfo(17) = anProductCode(0)
                anArmGlassInfo(18) = anProductCode(1)
                anArmGlassInfo(19) = anProductCode(2)
                anArmGlassInfo(20) = anProductCode(3)
                anArmGlassInfo(21) = anProductCode(4)
                anArmGlassInfo(22) = anProductCode(5)
                anArmGlassInfo(23) = anProductCode(6)
                anArmGlassInfo(24) = anProductCode(7)
                anArmGlassInfo(25) = anProductCode(8)
                anArmGlassInfo(26) = anProductCode(9)
                anArmGlassInfo(27) = anProductCode(10)
                anArmGlassInfo(28) = anProductCode(11)
                anArmGlassInfo(29) = anProductCode(12)

                ASCStringConvert(.CurrentRecipe, LEN_A_CURRENT_RECIPE, anCurrentRecipe)
                anArmGlassInfo(30) = anCurrentRecipe(0)
                anArmGlassInfo(31) = anCurrentRecipe(1)
                anArmGlassInfo(32) = anCurrentRecipe(2)
                anArmGlassInfo(33) = anCurrentRecipe(3)
                anArmGlassInfo(34) = anCurrentRecipe(4)
                anArmGlassInfo(35) = anCurrentRecipe(5)
                anArmGlassInfo(36) = anCurrentRecipe(6)
                anArmGlassInfo(37) = anCurrentRecipe(7)
                anArmGlassInfo(38) = anCurrentRecipe(8)
                anArmGlassInfo(39) = anCurrentRecipe(9)
                anArmGlassInfo(40) = anCurrentRecipe(10)
                anArmGlassInfo(41) = anCurrentRecipe(11)
                anArmGlassInfo(42) = anCurrentRecipe(12)
                anArmGlassInfo(43) = anCurrentRecipe(13)
                anArmGlassInfo(44) = anCurrentRecipe(14)
                anArmGlassInfo(45) = anCurrentRecipe(15)

                ASCStringConvert(.POPERID, LEN_A_POPERID, anPOPERID)
                anArmGlassInfo(46) = anPOPERID(0)
                anArmGlassInfo(47) = anPOPERID(1)
                anArmGlassInfo(48) = anPOPERID(2)
                anArmGlassInfo(49) = anPOPERID(3)
                anArmGlassInfo(50) = anPOPERID(4)
                anArmGlassInfo(51) = anPOPERID(5)
                anArmGlassInfo(52) = anPOPERID(6)
                anArmGlassInfo(53) = anPOPERID(7)
                anArmGlassInfo(54) = anPOPERID(8)
                anArmGlassInfo(55) = anPOPERID(9)
                anArmGlassInfo(56) = anPOPERID(10)
                anArmGlassInfo(57) = anPOPERID(11)
                anArmGlassInfo(58) = anPOPERID(12)

                ASCStringConvert(.PLINEID, LEN_A_PLINEID, anPLineID)
                anArmGlassInfo(59) = anPLineID(0)
                anArmGlassInfo(60) = anPLineID(1)
                anArmGlassInfo(61) = anPLineID(2)
                anArmGlassInfo(62) = anPLineID(3)

                ASCStringConvert(.PTOOLID, LEN_A_PTOOLID, anPToolID)
                anArmGlassInfo(63) = anPToolID(0)
                anArmGlassInfo(64) = anPToolID(1)
                anArmGlassInfo(65) = anPToolID(2)
                anArmGlassInfo(66) = anPToolID(3)

                ASCStringConvert(.CSTID, LEN_A_CST_ID, anCSTID)
                anArmGlassInfo(67) = anCSTID(0)
                anArmGlassInfo(68) = anCSTID(1)
                anArmGlassInfo(69) = anCSTID(2)

                ASCStringConvert(.OperationID, LEN_A_OP_ID, anOperationID)
                anArmGlassInfo(70) = anOperationID(0)
                anArmGlassInfo(71) = anOperationID(1)
                anArmGlassInfo(72) = anOperationID(2)
                anArmGlassInfo(73) = anOperationID(3)
                anArmGlassInfo(74) = anOperationID(4)
                anArmGlassInfo(75) = anOperationID(5)
                anArmGlassInfo(76) = anOperationID(6)
                anArmGlassInfo(77) = anOperationID(7)
                anArmGlassInfo(78) = anOperationID(8)
                anArmGlassInfo(79) = anOperationID(9)
                anArmGlassInfo(80) = anOperationID(10)
                anArmGlassInfo(81) = anOperationID(11)
                anArmGlassInfo(82) = anOperationID(12)

                Select Case .GlassGrade
                    Case eGGRADE.OK
                        strGlassGrade = "O"
                    Case eGGRADE.NG
                        strGlassGrade = "N"
                    Case eGGRADE.GRAY
                        strGlassGrade = "G"
                    Case eGGRADE.NO_GLASS
                        strGlassGrade = " "
                End Select

                ASCStringConvert(strGlassGrade, LEN_A_GLASS_GRADE, anGlassGrade)
                anArmGlassInfo(83) = anGlassGrade(0)

                Select Case .DMQCGrade
                    Case eDGRADE.OK
                        strDMQCGrade = "O"
                    Case eDGRADE.REVIEW
                        strDMQCGrade = "R"
                    Case eDGRADE.NG
                        strDMQCGrade = "N"
                    Case eDGRADE.NO_GLASS
                        strDMQCGrade = " "
                End Select

                ASCStringConvert(strDMQCGrade, LEN_A_DMQC_GRADE, anDMQCGrade)
                anArmGlassInfo(84) = anDMQCGrade(0)

                Select Case .GlassScrapFlag
                    Case eSCRPFLAG.MARKED_SCRAP
                        strGXScrapFlag = "S"
                    Case eSCRPFLAG.MARKED_RECYCLED
                        strGXScrapFlag = "C"
                    Case Else
                        strGXScrapFlag = " "
                End Select

                ASCStringConvert(strGXScrapFlag, LEN_A_SCRPFLAG, anGlassScrapFlag)
                anArmGlassInfo(85) = anGlassScrapFlag(0)

                anArmGlassInfo(86) = .AOIFunctionMode

                anArmGlassInfo(87) = .PortNo
                anArmGlassInfo(88) = .TargetPosition
                anArmGlassInfo(89) = .RobotSpeed

                Select Case .RWKFLAG
                    Case eRWKFLAG.REWORK
                        strRWKFLAG = "R"
                    Case eRWKFLAG.NORMAL_GLASS
                        strRWKFLAG = " "
                    Case Else
                        strRWKFLAG = " "
                End Select

                ASCStringConvert(strRWKFLAG, LEN_A_RWKFLAG, anRWKFLAG)
                anArmGlassInfo(90) = anRWKFLAG(0)

                Select Case .FIRMFLAG
                    Case eFIRMFLAG.FI_MACRO
                        strFIRMFLAG = "M"
                    Case eFIRMFLAG.OTHERS
                        strFIRMFLAG = " "
                    Case Else
                        strFIRMFLAG = " "
                End Select

                ASCStringConvert(strFIRMFLAG, LEN_A_FIRMFLAG, anFIRMFLAG)
                anArmGlassInfo(91) = anFIRMFLAG(0)

                anArmGlassInfo(92) = .RepairInkFlag
            End With

            Select Case nArm
                Case eRSTArm.ARM_UPPER
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Upper Arm Glass Info ,GlassID=" & "[" & value.GlassID & "]" & ",PortNo=" & value.PortNo & ",SlotNo=" & value.SlotInfo & ",LotPPID=[" & value.CurrentRecipe & "],EQ1 EPPID=[" & value.EPPID(1) & "],EQ2 EPPID=[" & value.EPPID(2) & "],ProductCode=[" & value.ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Upper Arm Glass Info ,CassetteID=" & "[" & value.CSTID & "]" & ",TargetPosition=" & value.TargetPosition & ",RobotSpeed=" & value.RobotSpeed & ",MESID=[" & value.MESID & "],POPERID=[" & value.POPERID & "],PLINEID=[" & value.PLINEID & "],PTOOLID=[" & value.PTOOLID & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Upper Arm Glass Info ,GlassGrade=" & "[" & strGlassGrade & "]" & ",DMQCGrade=[" & strDMQCGrade & "],ProductCategory=" & value.ProductCategory & ",OperationID=[" & value.OperationID & "],SampleGlassFlag=" & value.SampleGlassFlag & ",GlassScrapFlag=" & value.GlassScrapFlag & ",AOIFunctionMode=" & value.AOIFunctionMode & ",InkFlag=" & value.RepairInkFlag)

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, eModifyGlassInfo.U_ARM)

                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anArmGlassInfo)

                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)

                    If strGlassID = "" Then
                        RaiseEvent RSTArmWithGlass(nArm, False, value.GlassID)
                    Else
                        RaiseEvent RSTArmWithGlass(nArm, True, value.GlassID)
                    End If
                Case eRSTArm.ARM_LOWER
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Lower Arm Glass Info ,GlassID=" & "[" & value.GlassID & "]" & ",PortNo=" & value.PortNo & ",SlotNo=" & value.SlotInfo & ",LotPPID=[" & value.CurrentRecipe & "],EQ1 EPPID=[" & value.EPPID(1) & "],EQ2 EPPID=[" & value.EPPID(2) & "],ProductCode=[" & value.ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Lower Arm Glass Info ,CassetteID=" & "[" & value.CSTID & "]" & ",TargetPosition=" & value.TargetPosition & ",RobotSpeed=" & value.RobotSpeed & ",MESID=[" & value.MESID & "],POPERID=[" & value.POPERID & "],PLINEID=[" & value.PLINEID & "],PTOOLID=[" & value.PTOOLID & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write Lower Arm Glass Info ,GlassGrade=" & "[" & strGlassGrade & "]" & ",DMQCGrade=[" & strDMQCGrade & "],ProductCategory=" & value.ProductCategory & ",OperationID=[" & value.OperationID & "],SampleGlassFlag=" & value.SampleGlassFlag & ",GlassScrapFlag=" & value.GlassScrapFlag & ",AOIFunctionMode=" & value.AOIFunctionMode & ",InkFlag=" & value.RepairInkFlag)

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, eModifyGlassInfo.L_ARM)

                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anArmGlassInfo)

                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)

                    If strGlassID = "" Then
                        RaiseEvent RSTArmWithGlass(nArm, False, value.GlassID)
                    Else
                        RaiseEvent RSTArmWithGlass(nArm, True, value.GlassID)
                    End If

                Case Else
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.ERR, "Write Arm Glass Info Error...")

            End Select

        End Set
    End Property


    Public ReadOnly Property GetArmGlassInfo(ByVal nArm As eRSTArm) As clsArmGlassInfo
        Get
            Dim ArmGlassInfo As New clsArmGlassInfo
            Dim anGlassInfo(GLASS_INFO_WORD_LEN) As Integer

            Dim nFor As Integer
            Dim strGlassID As String = ""
            Dim strEQ1EPPID As String = ""
            Dim strEQ2EPPID As String = ""
            Dim strMESID As String = ""
            Dim strProductCode As String = ""
            Dim strCurrentRecipe As String = ""
            Dim strPOPERID As String = ""
            Dim strPLINEID As String = ""
            Dim strPTOOLID As String = ""
            Dim strCSTID As String = ""
            Dim strOperationID As String = ""
            Dim strGxGrade As String = ""
            Dim strDMQCGrade As String = ""
            Dim strGlassScrapFlag As String = ""
            Dim strPSHGrade As String = ""
            Dim strDMQCToolID As String = ""

            Dim strTemp As String = ""
            Dim strChip As String = ""
            Dim strChipGrade As String = ""
            Dim anBit(MAX_BIT) As Short

            Dim strHexData As String = ""
            Dim nfirstWord As Integer = 0
            Dim nSecondWord As Integer = 0
            Dim nThirdWord As Integer = 0
            Dim nFourthWord As Integer = 0
            Dim nRWKFLAG As Integer
            Dim nSCRPFLAG As Integer
            Dim nFIRMFLAG As Integer
            Dim nProductCategory As clsPLC.eProductCategory

            Dim nGxGrade As eGGRADE
            Dim nDMQCGrade As eDGRADE
            Dim nGlassScrapFlag As eSCRPFLAG

            Dim strTrimGxGrade As String = ""
            Dim strTrimDMQCGrade As String = ""
            Dim strTrimGlassScrapFlag As String = ""

            Dim nRSTSpeed As clsPLC.eRobotSpeed
            Dim nPort As Integer = 0
            Dim nSlot As Integer = 0

            Try
                Select Case nArm
                    Case eRSTArm.ARM_UPPER
                        DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get UpperArm Data..")
                        ReadZRAddr(UPPER_ARM_START_ADDR, anGlassInfo)
                    Case eRSTArm.ARM_LOWER
                        DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get LowerArm Data..")
                        ReadZRAddr(LOWER_ARM_START_ADDR, anGlassInfo)
                End Select


                For nFor = eBufferPortDevicNo.GXID_W1 To eBufferPortDevicNo.GXID_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.EQ1PPID_W1 To eBufferPortDevicNo.EQ1PPID_W2
                    strEQ1EPPID = strEQ1EPPID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.EQ2PPID_W1 To eBufferPortDevicNo.EQ2PPID_W2
                    strEQ2EPPID = strEQ2EPPID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.MESID_W1 To eBufferPortDevicNo.MESID_W4
                    strMESID = strMESID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PRODUCT_CODE_W1 To eBufferPortDevicNo.PRODUCT_CODE_W13
                    strProductCode = strProductCode & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CURRENT_RECIPE_W1 To eBufferPortDevicNo.CURRENT_RECIPE_W16
                    strCurrentRecipe = strCurrentRecipe & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.POPERID_W1 To eBufferPortDevicNo.POPERID_W13
                    strPOPERID = strPOPERID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PLINEID_W1 To eBufferPortDevicNo.PLINEID_W4
                    strPLINEID = strPLINEID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PTOOLID_W1 To eBufferPortDevicNo.PTOOLID_W4
                    strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CSTID_W1 To eBufferPortDevicNo.CSTID_W3
                    strCSTID = strCSTID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.OPERATIONID_W1 To eBufferPortDevicNo.OPERATIONID_W13
                    strOperationID = strOperationID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                strGxGrade = ConvertHiLowASCIIToString(anGlassInfo(eBufferPortDevicNo.GLASS_GRADE))
                strDMQCGrade = ConvertHiLowASCIIToString(anGlassInfo(eBufferPortDevicNo.DMQC_GRADE))
                strGlassScrapFlag = ConvertHiLowASCIIToString(anGlassInfo(eBufferPortDevicNo.GX_SCRAP_FLAG))

                For nFor = eBufferPortDevicNo.PSH_GRADE_W1 To eBufferPortDevicNo.PSH_GRADE_W2
                    strPSHGrade = strPSHGrade & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.DMQC_TOOLID_W1 To eBufferPortDevicNo.DMQC_TOOLID_W4
                    strDMQCToolID = strDMQCToolID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CHIP_GRADE_W1 To eBufferPortDevicNo.CHIP_GRADE_W9
                    strTemp = WordConvertToBin(anGlassInfo(nFor), anBit)

                    strChip = strChip & ProcessChipGrade(strTemp)
                    strTemp = ""
                Next
                strChipGrade = strChip


                strHexData = HexLeadZero(anGlassInfo(eBufferPortDevicNo.FIRMFLAG_SCRPFLAG_RWKFLAG))
                GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
                nRWKFLAG = nfirstWord
                nSCRPFLAG = nSecondWord
                nFIRMFLAG = nThirdWord

                With ArmGlassInfo
                    '.GlassDataRef = anGlassInfo(eBufferPortDevicNo.GX_DATA_REF)
                    .SampleGlassFlag = anGlassInfo(eBufferPortDevicNo.SAMPLE_GXFLAGE)

                    nProductCategory = anGlassInfo(eBufferPortDevicNo.PRODUCT_CATEGORY)

                    Select Case nProductCategory
                        Case eProductCategory.PROD
                            .ProductCategory = nProductCategory
                        Case eProductCategory.INIT
                            .ProductCategory = nProductCategory
                        Case eProductCategory.MONI
                            .ProductCategory = nProductCategory
                        Case eProductCategory.DUMY
                            .ProductCategory = nProductCategory
                        Case Else
                            .ProductCategory = eProductCategory.NA
                    End Select

                    nSlot = anGlassInfo(eBufferPortDevicNo.SLOT_INFO)
                    If nSlot > MAX_SLOTS Or nSlot < 0 Then
                        .SlotInfo = 0
                    Else
                        .SlotInfo = anGlassInfo(eBufferPortDevicNo.SLOT_INFO)
                    End If


                    .GlassID = strGlassID
                    .EPPID(1) = strEQ1EPPID
                    .EPPID(2) = strEQ2EPPID
                    .MESID = strMESID
                    .ProductCode = strProductCode
                    .CurrentRecipe = strCurrentRecipe
                    .POPERID = strPOPERID
                    .PLINEID = strPLINEID
                    .PTOOLID = strPTOOLID
                    .CSTID = strCSTID
                    .OperationID = strOperationID

                    strTrimGxGrade = Trim(strGxGrade)

                    If strTrimGxGrade = "O" Then
                        nGxGrade = eGGRADE.OK
                    ElseIf strTrimGxGrade = "G" Then
                        nGxGrade = eGGRADE.GRAY
                    ElseIf strTrimGxGrade = "N" Then
                        nGxGrade = eGGRADE.NG
                    Else
                        nGxGrade = eGGRADE.NO_GLASS
                    End If

                    strTrimDMQCGrade = Trim(strDMQCGrade)

                    If strTrimDMQCGrade = "O" Then
                        nDMQCGrade = eDGRADE.OK
                    ElseIf strTrimDMQCGrade = "R" Then
                        nDMQCGrade = eDGRADE.REVIEW
                    ElseIf strTrimDMQCGrade = "N" Then
                        nDMQCGrade = eDGRADE.NG
                    Else
                        nDMQCGrade = eDGRADE.NO_GLASS
                    End If

                    strTrimGlassScrapFlag = Trim(strGlassScrapFlag)

                    If strTrimGlassScrapFlag = "S" Then
                        nGlassScrapFlag = eSCRPFLAG.MARKED_SCRAP
                    ElseIf strTrimGlassScrapFlag = "C" Then
                        nGlassScrapFlag = eSCRPFLAG.MARKED_RECYCLED
                    Else
                        nGlassScrapFlag = 0
                    End If

                    .GlassGrade = nGxGrade
                    .DMQCGrade = nDMQCGrade
                    .GlassScrapFlag = nGlassScrapFlag
                    .AOIFunctionMode = anGlassInfo(eBufferPortDevicNo.AOI_FUNCTION_MODE)
                    nRSTSpeed = anGlassInfo(eBufferPortDevicNo.RST_SPEED)

                    Select Case nRSTSpeed
                        Case eRobotSpeed.LOW
                            .RobotSpeed = nRSTSpeed
                        Case eRobotSpeed.MID
                            .RobotSpeed = nRSTSpeed
                        Case eRobotSpeed.HI
                            .RobotSpeed = nRSTSpeed
                        Case Else
                            .RobotSpeed = eRobotSpeed.NA
                    End Select

                    nPort = anGlassInfo(eBufferPortDevicNo.PORT_NO)

                    If nPort > MAX_PORTS Or nPort < 0 Then
                        .PortNo = 0
                    Else
                        .PortNo = nPort
                    End If

                    .FIinspectionFlag = anGlassInfo(eBufferPortDevicNo.FI_INSPECTION_FLAG)

                    .RepairInkFlag = anGlassInfo(eBufferPortDevicNo.REPAIR_INK_FLAG)

                    .ProcessFlag = anGlassInfo(eBufferPortDevicNo.PROCESS_FLAG)

                    .TargetPosition = anGlassInfo(eBufferPortDevicNo.TARGET_POSITION)


                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get Arm Glass Info ,GlassID=" & "[" & .GlassID & "]" & ",PortNo=" & .PortNo & ",SlotNo=" & .SlotInfo & ",LotPPID=[" & .CurrentRecipe & "],EQ1 EPPID=[" & .EPPID(1) & "],EQ2 EPPID=[" & .EPPID(2) & "],ProductCode=[" & .ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get Arm Glass Info ,CassetteID=" & "[" & .CSTID & "]" & ",TargetPosition=" & .TargetPosition & ",RobotSpeed=" & .RobotSpeed & ",MESID=[" & .MESID & "],POPERID=[" & .POPERID & "],PLINEID=[" & .PLINEID & "],PTOOLID=[" & .PTOOLID & "]" & " ,RepairInkFlag=" & .RepairInkFlag & " ,ProcessFlag" & .ProcessFlag)
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get Arm Glass Info ,GlassGrade=" & "[" & .GlassGrade & "]" & ",DMQCGrade=[" & .DMQCGrade & "],ProductCategory=" & .ProductCategory & ",OperationID=[" & .OperationID & "],SampleGlassFlag=" & .SampleGlassFlag & ",GlassScrapFlag=" & .GlassScrapFlag & ",AOIFunctionMode=" & .AOIFunctionMode)

                    '.RDGRADE = anGlassInfo(eBufferPortDevicNo.RDGRADE)
                    '.DGRADE = anGlassInfo(eBufferPortDevicNo.DGRADE)
                    '.GGRADE = anGlassInfo(eBufferPortDevicNo.GGRADE)
                    '.PSHGrade = strPSHGrade
                    '.PToolIDIndex = anGlassInfo(eBufferPortDevicNo.PTOOLID_IDX)
                    '.DMQCToolID = strDMQCToolID
                    '.ChipGrade = strChipGrade
                    .RWKFLAG = nRWKFLAG
                    .SCRPFLAG = nSCRPFLAG
                    .FIRMFLAG = nFIRMFLAG
                End With


            Catch ex As Exception
                DebugLog(eIFIndex.INDEX_PLC, eLogType.ERR, ex.ToString)
            End Try

            Return ArmGlassInfo
        End Get
    End Property

    '2011/03/21
    Public WriteOnly Property WriteEQGlassInfo(ByVal nEQ As Integer) As clsArmGlassInfo
        Set(ByVal value As clsArmGlassInfo)
            Dim anArmGlassInfo(LEN_GLASS_DATA1) As Integer

            Dim anGlassID(LEN_A_GLASS_ID) As Integer
            Dim anEQ1EPPID(LEN_A_EPPID) As Integer
            Dim anEQ2EPPID(LEN_A_EPPID) As Integer

            Dim anMESID(LEN_A_MESID) As Integer
            Dim anProductCode(LEN_A_PRODUCT_CODE) As Integer
            Dim anCurrentRecipe(LEN_A_CURRENT_RECIPE) As Integer
            Dim anPOPERID(LEN_A_POPERID) As Integer
            Dim anPLineID(LEN_A_PLINEID) As Integer
            Dim anPToolID(LEN_A_PTOOLID) As Integer
            Dim anCSTID(LEN_A_CST_ID) As Integer
            Dim anOperationID(LEN_A_OP_ID) As Integer
            Dim anGlassGrade(LEN_A_GLASS_GRADE) As Integer
            Dim anDMQCGrade(LEN_A_DMQC_GRADE) As Integer
            Dim anGlassScrapFlag(LEN_A_SCRPFLAG) As Integer
            Dim anPSHGrade(LEN_A_PSH_GROUP) As Integer
            Dim anDMQCToolID(LEN_A_DMQC_TOOL_ID) As Integer
            Dim nChipGradeData(9) As Integer

            Dim strGlassID As String = ""
            Dim strGlassGrade As String = ""
            Dim strDMQCGrade As String = ""
            Dim strGXScrapFlag As String = ""

            Dim strRWKFLAG As String = ""
            Dim anRWKFLAG(LEN_A_RWKFLAG) As Integer
            Dim strFIRMFLAG As String = ""
            Dim anFIRMFLAG(LEN_A_FIRMFLAG) As Integer


            With value
                anArmGlassInfo(0) = .SampleGlassFlag
                anArmGlassInfo(1) = .ProductCategory
                anArmGlassInfo(2) = .SlotInfo

                strGlassID = Trim(.GlassID)

                ASCStringConvert(.GlassID, LEN_A_GLASS_ID, anGlassID)
                anArmGlassInfo(3) = anGlassID(0)
                anArmGlassInfo(4) = anGlassID(1)
                anArmGlassInfo(5) = anGlassID(2)
                anArmGlassInfo(6) = anGlassID(3)
                anArmGlassInfo(7) = anGlassID(4)
                anArmGlassInfo(8) = anGlassID(5)

                ASCStringConvert(.EPPID(1), LEN_A_EPPID, anEQ1EPPID)
                anArmGlassInfo(9) = anEQ1EPPID(0)
                anArmGlassInfo(10) = anEQ1EPPID(1)

                ASCStringConvert(.EPPID(2), LEN_A_EPPID, anEQ2EPPID)
                anArmGlassInfo(11) = anEQ2EPPID(0)
                anArmGlassInfo(12) = anEQ2EPPID(1)

                ASCStringConvert(.MESID, LEN_A_MESID, anMESID)
                anArmGlassInfo(13) = anMESID(0)
                anArmGlassInfo(14) = anMESID(1)
                anArmGlassInfo(15) = anMESID(2)
                anArmGlassInfo(16) = anMESID(3)

                ASCStringConvert(.ProductCode, LEN_A_PRODUCT_CODE, anProductCode)
                anArmGlassInfo(17) = anProductCode(0)
                anArmGlassInfo(18) = anProductCode(1)
                anArmGlassInfo(19) = anProductCode(2)
                anArmGlassInfo(20) = anProductCode(3)
                anArmGlassInfo(21) = anProductCode(4)
                anArmGlassInfo(22) = anProductCode(5)
                anArmGlassInfo(23) = anProductCode(6)
                anArmGlassInfo(24) = anProductCode(7)
                anArmGlassInfo(25) = anProductCode(8)
                anArmGlassInfo(26) = anProductCode(9)
                anArmGlassInfo(27) = anProductCode(10)
                anArmGlassInfo(28) = anProductCode(11)
                anArmGlassInfo(29) = anProductCode(12)

                ASCStringConvert(.CurrentRecipe, LEN_A_CURRENT_RECIPE, anCurrentRecipe)
                anArmGlassInfo(30) = anCurrentRecipe(0)
                anArmGlassInfo(31) = anCurrentRecipe(1)
                anArmGlassInfo(32) = anCurrentRecipe(2)
                anArmGlassInfo(33) = anCurrentRecipe(3)
                anArmGlassInfo(34) = anCurrentRecipe(4)
                anArmGlassInfo(35) = anCurrentRecipe(5)
                anArmGlassInfo(36) = anCurrentRecipe(6)
                anArmGlassInfo(37) = anCurrentRecipe(7)
                anArmGlassInfo(38) = anCurrentRecipe(8)
                anArmGlassInfo(39) = anCurrentRecipe(9)
                anArmGlassInfo(40) = anCurrentRecipe(10)
                anArmGlassInfo(41) = anCurrentRecipe(11)
                anArmGlassInfo(42) = anCurrentRecipe(12)
                anArmGlassInfo(43) = anCurrentRecipe(13)
                anArmGlassInfo(44) = anCurrentRecipe(14)
                anArmGlassInfo(45) = anCurrentRecipe(15)

                ASCStringConvert(.POPERID, LEN_A_POPERID, anPOPERID)
                anArmGlassInfo(46) = anPOPERID(0)
                anArmGlassInfo(47) = anPOPERID(1)
                anArmGlassInfo(48) = anPOPERID(2)
                anArmGlassInfo(49) = anPOPERID(3)
                anArmGlassInfo(50) = anPOPERID(4)
                anArmGlassInfo(51) = anPOPERID(5)
                anArmGlassInfo(52) = anPOPERID(6)
                anArmGlassInfo(53) = anPOPERID(7)
                anArmGlassInfo(54) = anPOPERID(8)
                anArmGlassInfo(55) = anPOPERID(9)
                anArmGlassInfo(56) = anPOPERID(10)
                anArmGlassInfo(57) = anPOPERID(11)
                anArmGlassInfo(58) = anPOPERID(12)

                ASCStringConvert(.PLINEID, LEN_A_PLINEID, anPLineID)
                anArmGlassInfo(59) = anPLineID(0)
                anArmGlassInfo(60) = anPLineID(1)
                anArmGlassInfo(61) = anPLineID(2)
                anArmGlassInfo(62) = anPLineID(3)

                ASCStringConvert(.PTOOLID, LEN_A_PTOOLID, anPToolID)
                anArmGlassInfo(63) = anPToolID(0)
                anArmGlassInfo(64) = anPToolID(1)
                anArmGlassInfo(65) = anPToolID(2)
                anArmGlassInfo(66) = anPToolID(3)

                ASCStringConvert(.CSTID, LEN_A_CST_ID, anCSTID)
                anArmGlassInfo(67) = anCSTID(0)
                anArmGlassInfo(68) = anCSTID(1)
                anArmGlassInfo(69) = anCSTID(2)

                ASCStringConvert(.OperationID, LEN_A_OP_ID, anOperationID)
                anArmGlassInfo(70) = anOperationID(0)
                anArmGlassInfo(71) = anOperationID(1)
                anArmGlassInfo(72) = anOperationID(2)
                anArmGlassInfo(73) = anOperationID(3)
                anArmGlassInfo(74) = anOperationID(4)
                anArmGlassInfo(75) = anOperationID(5)
                anArmGlassInfo(76) = anOperationID(6)
                anArmGlassInfo(77) = anOperationID(7)
                anArmGlassInfo(78) = anOperationID(8)
                anArmGlassInfo(79) = anOperationID(9)
                anArmGlassInfo(80) = anOperationID(10)
                anArmGlassInfo(81) = anOperationID(11)
                anArmGlassInfo(82) = anOperationID(12)

                Select Case .GlassGrade
                    Case eGGRADE.OK
                        strGlassGrade = "O"
                    Case eGGRADE.NG
                        strGlassGrade = "N"
                    Case eGGRADE.GRAY
                        strGlassGrade = "G"
                    Case eGGRADE.NO_GLASS
                        strGlassGrade = " "
                End Select

                ASCStringConvert(strGlassGrade, LEN_A_GLASS_GRADE, anGlassGrade)
                anArmGlassInfo(83) = anGlassGrade(0)

                Select Case .DMQCGrade
                    Case eDGRADE.OK
                        strDMQCGrade = "O"
                    Case eDGRADE.REVIEW
                        strDMQCGrade = "R"
                    Case eDGRADE.NG
                        strDMQCGrade = "N"
                    Case eDGRADE.NO_GLASS
                        strDMQCGrade = " "
                End Select

                ASCStringConvert(strDMQCGrade, LEN_A_DMQC_GRADE, anDMQCGrade)
                anArmGlassInfo(84) = anDMQCGrade(0)

                Select Case .GlassScrapFlag
                    Case eSCRPFLAG.MARKED_SCRAP
                        strGXScrapFlag = "S"
                    Case eSCRPFLAG.MARKED_RECYCLED
                        strGXScrapFlag = "C"
                    Case Else
                        strGXScrapFlag = " "
                End Select

                ASCStringConvert(strGXScrapFlag, LEN_A_SCRPFLAG, anGlassScrapFlag)
                anArmGlassInfo(85) = anGlassScrapFlag(0)

                anArmGlassInfo(86) = .AOIFunctionMode

                anArmGlassInfo(87) = .PortNo
                anArmGlassInfo(88) = .TargetPosition
                anArmGlassInfo(89) = .RobotSpeed

                Select Case .RWKFLAG
                    Case eRWKFLAG.REWORK
                        strRWKFLAG = "R"
                    Case eRWKFLAG.NORMAL_GLASS
                        strRWKFLAG = " "
                    Case Else
                        strRWKFLAG = " "
                End Select

                ASCStringConvert(strRWKFLAG, LEN_A_RWKFLAG, anRWKFLAG)
                anArmGlassInfo(90) = anRWKFLAG(0)

                Select Case .FIRMFLAG
                    Case eFIRMFLAG.FI_MACRO
                        strFIRMFLAG = "M"
                    Case eFIRMFLAG.OTHERS
                        strFIRMFLAG = " "
                    Case Else
                        strFIRMFLAG = " "
                End Select

                ASCStringConvert(strFIRMFLAG, LEN_A_FIRMFLAG, anFIRMFLAG)
                anArmGlassInfo(91) = anFIRMFLAG(0)

                anArmGlassInfo(92) = .RepairInkFlag
            End With

            Select Case nEQ
                Case 1
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ1 Glass Info ,GlassID=" & "[" & value.GlassID & "]" & ",PortNo=" & value.PortNo & ",SlotNo=" & value.SlotInfo & ",LotPPID=[" & value.CurrentRecipe & "],EQ1 EPPID=[" & value.EPPID(1) & "],EQ2 EPPID=[" & value.EPPID(2) & "],ProductCode=[" & value.ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ1 Glass Info ,CassetteID=" & "[" & value.CSTID & "]" & ",TargetPosition=" & value.TargetPosition & ",RobotSpeed=" & value.RobotSpeed & ",MESID=[" & value.MESID & "],POPERID=[" & value.POPERID & "],PLINEID=[" & value.PLINEID & "],PTOOLID=[" & value.PTOOLID & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ1 Glass Info ,GlassGrade=" & "[" & strGlassGrade & "]" & ",DMQCGrade=[" & strDMQCGrade & "],ProductCategory=" & value.ProductCategory & ",OperationID=[" & value.OperationID & "],SampleGlassFlag=" & value.SampleGlassFlag & ",GlassScrapFlag=" & value.GlassScrapFlag & ",AOIFunctionMode=" & value.AOIFunctionMode & ",InkFlag=" & value.RepairInkFlag)

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, eModifyGlassInfo.EQ1)
                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anArmGlassInfo)
                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)
                Case 2
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ2 Glass Info ,GlassID=" & "[" & value.GlassID & "]" & ",PortNo=" & value.PortNo & ",SlotNo=" & value.SlotInfo & ",LotPPID=[" & value.CurrentRecipe & "],EQ1 EPPID=[" & value.EPPID(1) & "],EQ2 EPPID=[" & value.EPPID(2) & "],ProductCode=[" & value.ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ2 Glass Info ,CassetteID=" & "[" & value.CSTID & "]" & ",TargetPosition=" & value.TargetPosition & ",RobotSpeed=" & value.RobotSpeed & ",MESID=[" & value.MESID & "],POPERID=[" & value.POPERID & "],PLINEID=[" & value.PLINEID & "],PTOOLID=[" & value.PTOOLID & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ2 Glass Info ,GlassGrade=" & "[" & strGlassGrade & "]" & ",DMQCGrade=[" & strDMQCGrade & "],ProductCategory=" & value.ProductCategory & ",OperationID=[" & value.OperationID & "],SampleGlassFlag=" & value.SampleGlassFlag & ",GlassScrapFlag=" & value.GlassScrapFlag & ",AOIFunctionMode=" & value.AOIFunctionMode & ",InkFlag=" & value.RepairInkFlag)

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, eModifyGlassInfo.EQ2)
                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anArmGlassInfo)
                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)
                Case 3
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ3 Glass Info ,GlassID=" & "[" & value.GlassID & "]" & ",PortNo=" & value.PortNo & ",SlotNo=" & value.SlotInfo & ",LotPPID=[" & value.CurrentRecipe & "],EQ1 EPPID=[" & value.EPPID(1) & "],EQ2 EPPID=[" & value.EPPID(2) & "],ProductCode=[" & value.ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ3 Glass Info ,CassetteID=" & "[" & value.CSTID & "]" & ",TargetPosition=" & value.TargetPosition & ",RobotSpeed=" & value.RobotSpeed & ",MESID=[" & value.MESID & "],POPERID=[" & value.POPERID & "],PLINEID=[" & value.PLINEID & "],PTOOLID=[" & value.PTOOLID & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Write EQ3 Glass Info ,GlassGrade=" & "[" & strGlassGrade & "]" & ",DMQCGrade=[" & strDMQCGrade & "],ProductCategory=" & value.ProductCategory & ",OperationID=[" & value.OperationID & "],SampleGlassFlag=" & value.SampleGlassFlag & ",GlassScrapFlag=" & value.GlassScrapFlag & ",AOIFunctionMode=" & value.AOIFunctionMode & ",InkFlag=" & value.RepairInkFlag)

                    WriteZRAddr(GLASS_MODIFY_DATA_ADDR, eModifyGlassInfo.EQ3)
                    WriteZRArrayAddr(GLASS_MODIFY_DATA_ADDR1, anArmGlassInfo)
                    WriteMAddr(MyRSTMAddr.mnRSTGlassModify, True)
                Case Else
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.ERR, "Write EQ Glass Info Error...")
            End Select

        End Set
    End Property

    '2011/03/21
    Public ReadOnly Property GetEQGlassInfo(ByVal nEQ As Integer) As clsArmGlassInfo
        Get
            Dim EQGlassInfo As New clsArmGlassInfo
            Dim anGlassInfo(GLASS_INFO_WORD_LEN) As Integer

            Dim nFor As Integer
            Dim strGlassID As String = ""
            Dim strEQ1EPPID As String = ""
            Dim strEQ2EPPID As String = ""
            Dim strMESID As String = ""
            Dim strProductCode As String = ""
            Dim strCurrentRecipe As String = ""
            Dim strPOPERID As String = ""
            Dim strPLINEID As String = ""
            Dim strPTOOLID As String = ""
            Dim strCSTID As String = ""
            Dim strOperationID As String = ""
            Dim strGxGrade As String = ""
            Dim strDMQCGrade As String = ""
            Dim strGlassScrapFlag As String = ""
            Dim strPSHGrade As String = ""
            Dim strDMQCToolID As String = ""

            Dim strTemp As String = ""
            Dim strChip As String = ""
            Dim strChipGrade As String = ""
            Dim anBit(MAX_BIT) As Short

            Dim strHexData As String = ""
            Dim nfirstWord As Integer = 0
            Dim nSecondWord As Integer = 0
            Dim nThirdWord As Integer = 0
            Dim nFourthWord As Integer = 0
            Dim nRWKFLAG As Integer
            Dim nSCRPFLAG As Integer
            Dim nFIRMFLAG As Integer
            Dim nProductCategory As clsPLC.eProductCategory

            Dim nGxGrade As eGGRADE
            Dim nDMQCGrade As eDGRADE
            Dim nGlassScrapFlag As eSCRPFLAG

            Dim strTrimGxGrade As String = ""
            Dim strTrimDMQCGrade As String = ""
            Dim strTrimGlassScrapFlag As String = ""

            Dim nRSTSpeed As clsPLC.eRobotSpeed
            Dim nPort As Integer = 0
            Dim nSlot As Integer = 0
            Dim nEQ1Addr As Integer = 17400
            Dim nEQ2Addr As Integer = 17600
            Dim nEQ3Addr As Integer = 17800


            Try
                Select Case nEQ
                    Case 1
                        DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get EQ1 Data..")
                        ReadZRAddr(nEQ1Addr, anGlassInfo)
                    Case 2
                        DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get EQ2 Data..")
                        ReadZRAddr(nEQ2Addr, anGlassInfo)
                    Case 3
                        DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get EQ3 Data..")
                        ReadZRAddr(nEQ3Addr, anGlassInfo)
                    Case Else
                        DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get EQData Error")
                End Select


                For nFor = eBufferPortDevicNo.GXID_W1 To eBufferPortDevicNo.GXID_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.EQ1PPID_W1 To eBufferPortDevicNo.EQ1PPID_W2
                    strEQ1EPPID = strEQ1EPPID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.EQ2PPID_W1 To eBufferPortDevicNo.EQ2PPID_W2
                    strEQ2EPPID = strEQ2EPPID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.MESID_W1 To eBufferPortDevicNo.MESID_W4
                    strMESID = strMESID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PRODUCT_CODE_W1 To eBufferPortDevicNo.PRODUCT_CODE_W13
                    strProductCode = strProductCode & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CURRENT_RECIPE_W1 To eBufferPortDevicNo.CURRENT_RECIPE_W16
                    strCurrentRecipe = strCurrentRecipe & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.POPERID_W1 To eBufferPortDevicNo.POPERID_W13
                    strPOPERID = strPOPERID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PLINEID_W1 To eBufferPortDevicNo.PLINEID_W4
                    strPLINEID = strPLINEID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PTOOLID_W1 To eBufferPortDevicNo.PTOOLID_W4
                    strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CSTID_W1 To eBufferPortDevicNo.CSTID_W3
                    strCSTID = strCSTID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.OPERATIONID_W1 To eBufferPortDevicNo.OPERATIONID_W13
                    strOperationID = strOperationID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                strGxGrade = ConvertHiLowASCIIToString(anGlassInfo(eBufferPortDevicNo.GLASS_GRADE))
                strDMQCGrade = ConvertHiLowASCIIToString(anGlassInfo(eBufferPortDevicNo.DMQC_GRADE))
                strGlassScrapFlag = ConvertHiLowASCIIToString(anGlassInfo(eBufferPortDevicNo.GX_SCRAP_FLAG))

                For nFor = eBufferPortDevicNo.PSH_GRADE_W1 To eBufferPortDevicNo.PSH_GRADE_W2
                    strPSHGrade = strPSHGrade & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.DMQC_TOOLID_W1 To eBufferPortDevicNo.DMQC_TOOLID_W4
                    strDMQCToolID = strDMQCToolID & ConvertHiLowASCIIToString(anGlassInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CHIP_GRADE_W1 To eBufferPortDevicNo.CHIP_GRADE_W9
                    strTemp = WordConvertToBin(anGlassInfo(nFor), anBit)

                    strChip = strChip & ProcessChipGrade(strTemp)
                    strTemp = ""
                Next
                strChipGrade = strChip


                strHexData = HexLeadZero(anGlassInfo(eBufferPortDevicNo.FIRMFLAG_SCRPFLAG_RWKFLAG))
                GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
                nRWKFLAG = nfirstWord
                nSCRPFLAG = nSecondWord
                nFIRMFLAG = nThirdWord

                With EQGlassInfo
                    '.GlassDataRef = anGlassInfo(eBufferPortDevicNo.GX_DATA_REF)
                    .SampleGlassFlag = anGlassInfo(eBufferPortDevicNo.SAMPLE_GXFLAGE)

                    nProductCategory = anGlassInfo(eBufferPortDevicNo.PRODUCT_CATEGORY)

                    Select Case nProductCategory
                        Case eProductCategory.PROD
                            .ProductCategory = nProductCategory
                        Case eProductCategory.INIT
                            .ProductCategory = nProductCategory
                        Case eProductCategory.MONI
                            .ProductCategory = nProductCategory
                        Case eProductCategory.DUMY
                            .ProductCategory = nProductCategory
                        Case Else
                            .ProductCategory = eProductCategory.NA
                    End Select

                    nSlot = anGlassInfo(eBufferPortDevicNo.SLOT_INFO)
                    If nSlot > MAX_SLOTS Or nSlot < 0 Then
                        .SlotInfo = 0
                    Else
                        .SlotInfo = anGlassInfo(eBufferPortDevicNo.SLOT_INFO)
                    End If


                    .GlassID = strGlassID
                    .EPPID(1) = strEQ1EPPID
                    .EPPID(2) = strEQ2EPPID
                    .MESID = strMESID
                    .ProductCode = strProductCode
                    .CurrentRecipe = strCurrentRecipe
                    .POPERID = strPOPERID
                    .PLINEID = strPLINEID
                    .PTOOLID = strPTOOLID
                    .CSTID = strCSTID
                    .OperationID = strOperationID

                    strTrimGxGrade = Trim(strGxGrade)

                    If strTrimGxGrade = "O" Then
                        nGxGrade = eGGRADE.OK
                    ElseIf strTrimGxGrade = "G" Then
                        nGxGrade = eGGRADE.GRAY
                    ElseIf strTrimGxGrade = "N" Then
                        nGxGrade = eGGRADE.NG
                    Else
                        nGxGrade = eGGRADE.NO_GLASS
                    End If

                    strTrimDMQCGrade = Trim(strDMQCGrade)

                    If strTrimDMQCGrade = "O" Then
                        nDMQCGrade = eDGRADE.OK
                    ElseIf strTrimDMQCGrade = "R" Then
                        nDMQCGrade = eDGRADE.REVIEW
                    ElseIf strTrimDMQCGrade = "N" Then
                        nDMQCGrade = eDGRADE.NG
                    Else
                        nDMQCGrade = eDGRADE.NO_GLASS
                    End If

                    strTrimGlassScrapFlag = Trim(strGlassScrapFlag)

                    If strTrimGlassScrapFlag = "S" Then
                        nGlassScrapFlag = eSCRPFLAG.MARKED_SCRAP
                    ElseIf strTrimGlassScrapFlag = "C" Then
                        nGlassScrapFlag = eSCRPFLAG.MARKED_RECYCLED
                    Else
                        nGlassScrapFlag = 0
                    End If

                    .GlassGrade = nGxGrade
                    .DMQCGrade = nDMQCGrade
                    .GlassScrapFlag = nGlassScrapFlag
                    .AOIFunctionMode = anGlassInfo(eBufferPortDevicNo.AOI_FUNCTION_MODE)
                    nRSTSpeed = anGlassInfo(eBufferPortDevicNo.RST_SPEED)

                    Select Case nRSTSpeed
                        Case eRobotSpeed.LOW
                            .RobotSpeed = nRSTSpeed
                        Case eRobotSpeed.MID
                            .RobotSpeed = nRSTSpeed
                        Case eRobotSpeed.HI
                            .RobotSpeed = nRSTSpeed
                        Case Else
                            .RobotSpeed = eRobotSpeed.NA
                    End Select

                    nPort = anGlassInfo(eBufferPortDevicNo.PORT_NO)

                    If nPort > MAX_PORTS Or nPort < 0 Then
                        .PortNo = 0
                    Else
                        .PortNo = nPort
                    End If

                    .FIinspectionFlag = anGlassInfo(eBufferPortDevicNo.FI_INSPECTION_FLAG)

                    .RepairInkFlag = anGlassInfo(eBufferPortDevicNo.REPAIR_INK_FLAG)

                    .ProcessFlag = anGlassInfo(eBufferPortDevicNo.PROCESS_FLAG)

                    .TargetPosition = anGlassInfo(eBufferPortDevicNo.TARGET_POSITION)


                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get EQ Glass Info ,GlassID=" & "[" & .GlassID & "]" & ",PortNo=" & .PortNo & ",SlotNo=" & .SlotInfo & ",LotPPID=[" & .CurrentRecipe & "],EQ1 EPPID=[" & .EPPID(1) & "],EQ2 EPPID=[" & .EPPID(2) & "],ProductCode=[" & .ProductCode & "]")
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get EQ Glass Info ,CassetteID=" & "[" & .CSTID & "]" & ",TargetPosition=" & .TargetPosition & ",RobotSpeed=" & .RobotSpeed & ",MESID=[" & .MESID & "],POPERID=[" & .POPERID & "],PLINEID=[" & .PLINEID & "],PTOOLID=[" & .PTOOLID & "]" & " ,RepairInkFlag=" & .RepairInkFlag & " ,ProcessFlag" & .ProcessFlag)
                    DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Get EQ Glass Info ,GlassGrade=" & "[" & .GlassGrade & "]" & ",DMQCGrade=[" & .DMQCGrade & "],ProductCategory=" & .ProductCategory & ",OperationID=[" & .OperationID & "],SampleGlassFlag=" & .SampleGlassFlag & ",GlassScrapFlag=" & .GlassScrapFlag & ",AOIFunctionMode=" & .AOIFunctionMode)

                    '.RDGRADE = anGlassInfo(eBufferPortDevicNo.RDGRADE)
                    '.DGRADE = anGlassInfo(eBufferPortDevicNo.DGRADE)
                    '.GGRADE = anGlassInfo(eBufferPortDevicNo.GGRADE)
                    '.PSHGrade = strPSHGrade
                    '.PToolIDIndex = anGlassInfo(eBufferPortDevicNo.PTOOLID_IDX)
                    '.DMQCToolID = strDMQCToolID
                    '.ChipGrade = strChipGrade
                    .RWKFLAG = nRWKFLAG
                    .SCRPFLAG = nSCRPFLAG
                    .FIRMFLAG = nFIRMFLAG
                End With


            Catch ex As Exception
                DebugLog(eIFIndex.INDEX_PLC, eLogType.ERR, ex.ToString)
            End Try

            Return EQGlassInfo
        End Get
    End Property

    Private Function FSRFlagConvertToWord(ByVal nFIRMFLAG As Integer, ByVal nSCRPFLAG As Integer, ByVal nRWKFLAG As Integer) As Integer
        'Format==> Hex ==>FIRMFLAG SCRPFLAG RWKFLAG

        FSRFlagConvertToWord = nRWKFLAG + (nSCRPFLAG * (2 ^ 4)) + (nFIRMFLAG * (2 ^ 8))
    End Function

    Private Sub strChipGradeConvertTonWord(ByVal strChipGrade As String, ByRef nChipGradeData() As Integer)
        Dim strTemp(72) As String
        Dim strTempGradeCode As String = ""
        Dim strTempGradeID As String = ""

        Dim nFor As Integer
        Dim nWordInx As Integer
        Dim strWordByte(9) As String
        Dim nWordLoop As Integer
        Dim nLoop As Integer

        Const nWordStep = 8

        For nFor = 1 To 72
            strTempGradeCode = Mid(strChipGrade, nFor, 1)
            Select Case strTempGradeCode
                Case "O"
                    strTempGradeID = "00"
                Case "X"
                    strTempGradeID = "01"
                Case "G"
                    strTempGradeID = "10"
            End Select
            strTemp(nFor) = strTempGradeID
        Next

        For nFor = 1 To 72 Step nWordStep
            nWordInx = nWordInx + 1
            nWordLoop = nWordStep * nWordInx

            For nLoop = nWordStep To 1 Step -1
                strWordByte(nWordInx) = strTemp(nWordLoop - nLoop + 1) + strWordByte(nWordInx)
            Next
        Next

        For nFor = 1 To 9
            nChipGradeData(nFor) = BinStringConvertToWord(strWordByte(nFor))
        Next

    End Sub

    Private Function BinStringConvertToWord(ByVal strData As String) As Integer
        Dim nLen As Integer
        Dim nSum As Integer
        Dim n As Integer = 0

        For nLen = Len(strData) To 1 Step -1
            nSum = nSum + (CInt(Mid(strData, nLen, 1)) * (2 ^ n))
            n = n + 1
        Next
        BinStringConvertToWord = nSum
    End Function

    Private Sub ClearBufferTarget()
        Dim anTargetValue(74) As Integer

        WriteZRArrayAddr(MyPLCBufferPortTargetBit.nPort1StartAddr, anTargetValue)
    End Sub

    Private Sub ClearFlowInOut()
        WriteMAddr(MyRSTMAddr.mnRobotResetInOutBit, SIGNAL_ON)
    End Sub

    Private Sub CheckTraceAddress()
        Dim nFor As Integer = 0
        Dim nAddr As Integer = 55200

        If MyTraceAddr.nCount > 0 Or MyTraceAddr.nCount <= 20 Then

            Dim anValue(MyTraceAddr.nCount - 1) As Integer
            If MyTraceAddr.nCount > 0 Then
                For nFor = 0 To MyTraceAddr.nCount - 1
                    anValue(nFor) = MyTraceAddr.nTraceAddr(nFor)
                Next
                WriteZRArrayAddr(nAddr, anValue)
            End If

        End If

    End Sub

    Public Sub SetNGGlasstoMachine(ByVal nBufferPortNo As Integer, ByVal nSlotNo As Integer, ByVal nMachine As eNGGXToMachine)
        If nSlotNo <= 0 Or nSlotNo > 25 Then Exit Sub

        DebugLog(eIFIndex.INDEX_PLC, eLogType.[METHOD], "Set BufferSlot Destination ,Buffer=" & nBufferPortNo & " ,SlotNo=" & nSlotNo & " -> [" & nMachine.ToString & "]")

        Select Case nBufferPortNo
            Case 1
                WriteZRAddr(MyPLCBufferPortTargetBit.nPort1StartAddr + nSlotNo - 1, nMachine)
            Case 2
                WriteZRAddr(MyPLCBufferPortTargetBit.nPort2StartAddr + nSlotNo - 1, nMachine)
            Case 3
                WriteZRAddr(MyPLCBufferPortTargetBit.nPort3StartAddr + nSlotNo - 1, nMachine)
            Case 4
                WriteZRAddr(MyPLCBufferPortTargetBit.nPort4StartAddr + nSlotNo - 1, nMachine)
        End Select
    End Sub

    Public Property BufferSlotStatus(ByVal nBufferPortNo As Integer, ByVal nSlotNo As Integer) As eBufferStatus
        Get
            Dim nStatus(0) As Integer

            Select Case nBufferPortNo
                Case 1
                    ReadZRAddr(MyPLCBufferSlotStatusSetting.nPort1StartAddr + nSlotNo - 1, nStatus)
                Case 2
                    ReadZRAddr(MyPLCBufferSlotStatusSetting.nPort2StartAddr + nSlotNo - 1, nStatus)
                Case 3
                    ReadZRAddr(MyPLCBufferSlotStatusSetting.nPort3StartAddr + nSlotNo - 1, nStatus)
                Case 4
                    ReadZRAddr(MyPLCBufferSlotStatusSetting.nPort4StartAddr + nSlotNo - 1, nStatus)
            End Select
            Return nStatus(0)
        End Get

        Set(ByVal value As eBufferStatus)

            DebugLog(eIFIndex.INDEX_PLC, eLogType.PROPERTY, "Buffer=" & nBufferPortNo & " ,SlotNo=" & nSlotNo & " Type=[" & value.ToString & "]")

            Select Case nBufferPortNo
                Case 1
                    WriteZRAddr(MyPLCBufferSlotStatusSetting.nPort1StartAddr + nSlotNo - 1, value)
                Case 2
                    WriteZRAddr(MyPLCBufferSlotStatusSetting.nPort2StartAddr + nSlotNo - 1, value)
                Case 3
                    WriteZRAddr(MyPLCBufferSlotStatusSetting.nPort3StartAddr + nSlotNo - 1, value)
                Case 4
                    WriteZRAddr(MyPLCBufferSlotStatusSetting.nPort4StartAddr + nSlotNo - 1, value)
            End Select
        End Set
    End Property

    Public Sub S765DataDownload(ByVal nPortNo As Integer, ByVal LotStructure As clsS765LotInfo)
        Dim anLineID(LEN_A_LINE_ID) As Integer
        Dim anToolID(LEN_A_TOOL_ID) As Integer
        Dim anCSTID(LEN_A_CST_ID) As Integer
        Dim anProductCode(LEN_A_PRODUCT_CODE) As Integer
        Dim anProductCategory1(0) As Integer
        Dim anProductCategory2(0) As Integer
        Dim anMeasurementID(LEN_A_MEASUREMENT_ID) As Integer
        Dim anOperationID(LEN_A_OP_ID) As Integer
        Dim anEPPID1(LEN_A_EPPID1) As Integer
        Dim anEPPID2(LEN_A_EPPID2) As Integer
        Dim anTargetPosition(LEN_A_TARGET_POSITION) As Integer
        Dim anAOIFunction(LEN_A_AOIFUNCTION) As Integer
        Dim anRunningmode(LEN_A_RUNNING_MODE) As Integer
        Dim anRobotSpeed(LEN_A_ROBOT_SPEED) As Integer
        Dim anGlassType(LEN_A_GLASS_TYPE) As Integer
        Dim anVCRPosition(LEN_A_VCR_POSITION) As Integer
        Dim nFor As Integer
        Dim anGlassID(LEN_A_GLASS_ID) As Integer
        Dim anPOPERID(LEN_A_POPERID) As Integer
        Dim anPLINEID(LEN_A_PLINEID) As Integer
        Dim anPTOOLID(LEN_A_PTOOLID) As Integer
        Dim anDMQCTOOLID(LEN_A_DMQC_TOOLID) As Integer
        Dim anGGRADE(LEN_A_GGRADE) As Integer
        Dim anDGRADE(LEN_A_DGRADE) As Integer
        Dim anPSHGROUP(LEN_A_PSH_GROUP) As Integer
        Dim anRWKFLAG(LEN_A_RWKFLAG) As Integer
        Dim anSCRPFLAG(LEN_A_SCRPFLAG) As Integer
        Dim anFIRMFLAG(LEN_A_FIRMFLAG) As Integer
        Dim anFIFCFLAG(LEN_A_FIFCFLAG) As Integer
        Dim anProcessFlag(LEN_A_PROCESSFLAG) As Integer
        Dim anCurrentRecipe(LEN_A_CURRENT_RECIPE) As Integer

        Dim anSlotInfo1(799) As Integer
        Dim anSlotInfo2(799) As Integer
        Dim anSlotInfo3(639) As Integer


        If nPortNo > MAX_PORTS Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.ERR, "CV Port[" & nPortNo & "]S765 Data Download Request Error...")
            Exit Sub
        End If

        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]S765 Data Download Start")

        With LotStructure
            ASCStringConvert(.LineID, LEN_A_LINE_ID, anLineID)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.LINEID, anLineID)

            ASCStringConvert(.ToolID, LEN_A_TOOL_ID, anToolID)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.TOOLID, anToolID)

            ASCStringConvert(.CassetteID, LEN_A_CST_ID, anCSTID)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.CASSETTEID, anCSTID)

            ASCStringConvert(.ProductCode, LEN_A_PRODUCT_CODE, anProductCode)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.PRODUCT_CODE, anProductCode)

            anProductCategory1(0) = .ProductCategory
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.PRODUCT_CATEGORY1, anProductCategory1)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.PRODUCT_CATEGORY2, anProductCategory2)

            ASCStringConvert(.MeasurementID, LEN_A_MEASUREMENT_ID, anMeasurementID)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.MEASUREMENT_ID, anMeasurementID)

            ASCStringConvert(.OperationID, LEN_A_OP_ID, anOperationID)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.OP_ID, anOperationID)

            ASCStringConvert(.EPPIDEQ1, LEN_A_EPPID1, anEPPID1)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.EPPID_EQ1, anEPPID1)

            ASCStringConvert(.EPPIDEQ2, LEN_A_EPPID2, anEPPID2)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.EPPID_EQ2, anEPPID2)

            'Target Position(Bit 0 : EQ1  Bit 1: EQ 2  Bit 2: EQ 3)
            anTargetPosition(0) = .TargetPosition
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.TARGET_POSITION, anTargetPosition)

            anAOIFunction(0) = .AOIFunction
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.AOI_FUNCTION, anAOIFunction)

            anRunningmode(0) = .RunningMode
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.RUNNING_MODE, anRunningmode)

            anRobotSpeed(0) = .RobotSpeed
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.ROBOT_SPEED, anRobotSpeed)

            anGlassType(0) = .GlassType
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.GLASS_TYPE, anGlassType)

            anVCRPosition(0) = .VCRPosition
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.VCR_POSITION, anVCRPosition)

            ASCStringConvert(.CurrentRecipe, LEN_A_CURRENT_RECIPE, anCurrentRecipe)
            Call SetS765ArrayDataBlock1(nPortNo, ePLC_DeviceNo.CURRENT_RECIPE, anCurrentRecipe)
        End With

        'Write Lot Info
        Select Case nPortNo
            Case 1
                WriteZRArrayAddr(MyPLC_S765_Addr.LotData(nPortNo), My765LotInfoPort1)
            Case 2
                WriteZRArrayAddr(MyPLC_S765_Addr.LotData(nPortNo), My765LotInfoPort2)
            Case 3
                WriteZRArrayAddr(MyPLC_S765_Addr.LotData(nPortNo), My765LotInfoPort3)
        End Select


        For nFor = 1 To MAX_SLOTS
            With LotStructure.Slots(nFor)
                ASCStringConvert(.GlassID, LEN_A_GLASS_ID, anGlassID)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.GLASS_ID_BY_SLOT, anGlassID)

                ASCStringConvert(.POPERID, LEN_A_POPERID, anPOPERID)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.POPERID, anPOPERID)

                ASCStringConvert(.PLINEID, LEN_A_PLINEID, anPLINEID)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.PLINEID, anPLINEID)

                ASCStringConvert(.PTOOLID, LEN_A_PTOOLID, anPTOOLID)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.PTOOLID, anPTOOLID)

                ASCStringConvert(.DMQCToolID, LEN_A_DMQC_TOOLID, anDMQCTOOLID)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.DMQCTOOL_ID, anDMQCTOOLID)

                ASCStringConvert(.GlassGrade, LEN_A_GGRADE, anGGRADE)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.GGRADE, anGGRADE)

                ASCStringConvert(.DMQCGrade, LEN_A_DGRADE, anDGRADE)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.DGRADE, anDGRADE)

                ASCStringConvert(.PSHGroup, LEN_A_PSH_GROUP, anPSHGROUP)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.PSH_GROUP, anPSHGROUP)

                ASCStringConvert(.ReworkFlag, LEN_A_RWKFLAG, anRWKFLAG)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.RWKFLAG, anRWKFLAG)

                ASCStringConvert(.ScrapFlag, LEN_A_SCRPFLAG, anSCRPFLAG)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.SCRPFlAG, anSCRPFLAG)

                ASCStringConvert(.FIRemarkFlag, LEN_A_FIRMFLAG, anFIRMFLAG)
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.FIRMFLAG, anFIRMFLAG)

                anFIFCFLAG(0) = .FIFCFlag
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.FIFCFLAG, anFIFCFLAG)

                anProcessFlag(0) = .ProcessedFlag
                Call SetS765ArrayDataBlock2(nPortNo, nFor, ePLC_DeviceNo.PROCESS_FLAG, anProcessFlag)
            End With
        Next

        'Write Slot Info
        Select Case nPortNo
            Case 1
                '20 Slot
                For nFor = 0 To 799
                    'anSlotInfo1
                    anSlotInfo1(nFor) = My765SlotInfoPort1(nFor)
                Next

                For nFor = 0 To 799
                    anSlotInfo2(nFor) = My765SlotInfoPort1(800 + nFor)
                Next

                '41~56 Slot
                For nFor = 0 To 639
                    anSlotInfo3(nFor) = My765SlotInfoPort1(1600 + nFor)
                Next
            Case 2
                '20 Slot
                For nFor = 0 To 799
                    anSlotInfo1(nFor) = My765SlotInfoPort2(nFor)
                Next

                For nFor = 0 To 799
                    anSlotInfo2(nFor) = My765SlotInfoPort2(800 + nFor)
                Next

                '41~56 Slot
                For nFor = 0 To 639
                    anSlotInfo3(nFor) = My765SlotInfoPort2(1600 + nFor)
                Next
            Case 3
                '20 Slot
                For nFor = 0 To 799
                    anSlotInfo1(nFor) = My765SlotInfoPort3(nFor)
                Next

                For nFor = 0 To 799
                    anSlotInfo2(nFor) = My765SlotInfoPort3(800 + nFor)
                Next

                '41~56 Slot
                For nFor = 0 To 639
                    anSlotInfo3(nFor) = My765SlotInfoPort3(1600 + nFor)
                Next
        End Select

        '1~20 Slot
        WriteZRArrayAddr(MyPLC_S765_Addr.SlotData(nPortNo, 1), anSlotInfo1)
        '21~40 Slot
        WriteZRArrayAddr(MyPLC_S765_Addr.SlotData(nPortNo, 21), anSlotInfo2)
        '41~56 Slot
        WriteZRArrayAddr(MyPLC_S765_Addr.SlotData(nPortNo, 41), anSlotInfo3)

        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]S765 Data Download Request On")
        WriteMAddr(MyCVMAddr.m_nS765DataDownloadRequest(nPortNo), True)

    End Sub
#End Region

#Region "PLC IF S765 Flag"
    Private Sub SetS765ArrayDataBlock1(ByVal nPortNo As Integer, ByVal nStartDeviceNo As Integer, ByVal anWordData() As Integer)
        Dim nLen As Integer
        Dim nFor As Integer

        nLen = anWordData.Length - 1

        Select Case nPortNo
            Case 1
                For nFor = 0 To nLen
                    My765LotInfoPort1(nStartDeviceNo + nFor) = anWordData(nFor)
                Next
            Case 2
                For nFor = 0 To nLen
                    My765LotInfoPort2(nStartDeviceNo + nFor) = anWordData(nFor)
                Next
            Case 3
                For nFor = 0 To nLen
                    My765LotInfoPort3(nStartDeviceNo + nFor) = anWordData(nFor)
                Next
        End Select
    End Sub

    Private Sub SetS765ArrayDataBlock2(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nStartDeviceNo As Integer, ByVal anWordData() As Integer)
        Dim nLen As Integer
        Dim nFor As Integer
        Dim nAppendAddr As Integer = 0

        nAppendAddr = 40 * (nSlotNo - 1)
        nLen = anWordData.Length - 1

        Select Case nPortNo
            Case 1
                For nFor = 0 To nLen
                    My765SlotInfoPort1(nStartDeviceNo + nAppendAddr + nFor) = anWordData(nFor)
                Next
            Case 2
                For nFor = 0 To nLen
                    My765SlotInfoPort2(nStartDeviceNo + nAppendAddr + nFor) = anWordData(nFor)
                Next
            Case 3
                For nFor = 0 To nLen
                    My765SlotInfoPort3(nStartDeviceNo + nAppendAddr + nFor) = anWordData(nFor)
                Next
        End Select

    End Sub

    Public ReadOnly Property Get765LotData(ByVal nPortNo As Integer) As clsS765LotInfo
        Get
            Dim vLotInfo As New clsS765LotInfo
            Dim anReceiveData(LEN_LINEID_BLOCK) As Integer
            Dim nFor As Integer = 0
            Dim strLineID As String = ""
            Dim strToolID As String = ""
            Dim strCassetteID As String = ""
            Dim strProductCode As String = ""
            Dim nProductCategory1 As Integer = 0
            Dim nProductCategory2 As Integer = 0
            Dim strMESID As String = ""
            Dim strOPID As String = ""
            Dim strEQ1PPID As String = ""
            Dim strEQ2PPID As String = ""

            Dim nAOIFunction As Integer = 0
            Dim nRunningmode As Integer = 0
            Dim nRobotSpeed As Integer = 0
            Dim nGlassType As Integer = 0
            Dim nVCRPosition As Integer = 0
            Dim strCurrentRecipe As String = ""

            ReadZRAddr(MyPLC_S765_Addr.LotData(nPortNo), anReceiveData)

            For nFor = ePLC_S765_DeviceNo.LINEID_W1 To ePLC_S765_DeviceNo.LINEID_W4
                strLineID = strLineID & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            For nFor = ePLC_S765_DeviceNo.TOOLID_W1 To ePLC_S765_DeviceNo.TOOLID_W4
                strToolID = strToolID & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            For nFor = ePLC_S765_DeviceNo.CASSETTEID_W1 To ePLC_S765_DeviceNo.CASSETTEID_W3
                strCassetteID = strCassetteID & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            For nFor = ePLC_S765_DeviceNo.PRODUCT_CODE_W1 To ePLC_S765_DeviceNo.PRODUCT_CODE_W13
                strProductCode = strProductCode & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            nProductCategory1 = anReceiveData(ePLC_S765_DeviceNo.PRODUCT_CATEGORY1)
            nProductCategory2 = anReceiveData(ePLC_S765_DeviceNo.PRODUCT_CATEGORY2)

            For nFor = ePLC_S765_DeviceNo.MEASUREMENT_ID_W1 To ePLC_S765_DeviceNo.MEASUREMENT_ID_W4
                strMESID = strMESID & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            For nFor = ePLC_S765_DeviceNo.OP_ID_W1 To ePLC_S765_DeviceNo.OP_ID_W13
                strOPID = strOPID & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            For nFor = ePLC_S765_DeviceNo.EPPID_EQ1_W1 To ePLC_S765_DeviceNo.EPPID_EQ1_W2
                strEQ1PPID = strEQ1PPID & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            For nFor = ePLC_S765_DeviceNo.EPPID_EQ2_W1 To ePLC_S765_DeviceNo.EPPID_EQ2_W2
                strEQ2PPID = strEQ2PPID & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            nAOIFunction = anReceiveData(ePLC_S765_DeviceNo.AOI_FUNCTION)
            nRunningmode = anReceiveData(ePLC_S765_DeviceNo.RUNNING_MODE)
            nRobotSpeed = anReceiveData(ePLC_S765_DeviceNo.ROBOT_SPEED)
            nGlassType = anReceiveData(ePLC_S765_DeviceNo.GLASS_TYPE)
            nVCRPosition = anReceiveData(ePLC_S765_DeviceNo.VCR_POSITION)

            For nFor = ePLC_S765_DeviceNo.CURRENT_RECIPE_W1 To ePLC_S765_DeviceNo.CURRENT_RECIPE_W16
                strCurrentRecipe = strCurrentRecipe & ConvertHiLowASCIIToString(anReceiveData(nFor))
            Next

            With vLotInfo
                .LineID = strLineID
                .ToolID = strToolID
                .CassetteID = strCassetteID
                .ProductCode = strProductCode
                .ProductCategory = nProductCategory1
                .MeasurementID = strMESID
                .OperationID = strOPID
                .EPPIDEQ1 = strEQ1PPID
                .EPPIDEQ2 = strEQ2PPID
                .AOIFunction = nAOIFunction
                .RunningMode = nRunningmode
                .RobotSpeed = nRobotSpeed
                .GlassType = nGlassType
                .VCRPosition = nVCRPosition
                .CurrentRecipe = strCurrentRecipe
            End With

            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "PortNo[" & nPortNo & "] Get765 Data, LineID =" & vLotInfo.LineID & " ,ToolID =" & vLotInfo.ToolID & " ,CassetteID =" & vLotInfo.CassetteID _
            & ", ProductCode =" & vLotInfo.ProductCode & " ,ProductCategory =" & vLotInfo.ProductCategory & " ,MeasurementID =" & vLotInfo.MeasurementID & " ,OperationID =" & vLotInfo.OperationID & " ,EPPIDEQ1 =" & vLotInfo.EPPIDEQ1 & " ,EPPIDEQ2 =" & vLotInfo.EPPIDEQ2 _
            & ", CurrentRecipe =" & vLotInfo.CurrentRecipe & ", RunningMode =" & vLotInfo.RunningMode.ToString & ", RobotSpeed =" & vLotInfo.RobotSpeed.ToString)

            Return vLotInfo
        End Get
    End Property

#End Region

#Region "S167 Data Upload"

    Public ReadOnly Property GetCSTSlotInfo(ByVal nPortNo As Integer, ByVal nSlotNo As Integer) As clsS167SlotInfo
        Get
            Dim vCSTSlotInfo As New clsS167SlotInfo
            Dim anSlotArray(LEN_S167_BLOCK2) As Integer

            Dim strGlassID As String = ""
            Dim nFor As Integer
            Dim strPSHGroup As String = ""
            Dim strPTOOLID As String = ""
            Dim strDMQCTOOLID As String = ""
            Dim strTemp As String = ""
            Dim anBit(MAX_BIT) As Short
            Dim strChipGrade As String = ""
            Dim strCurrRecipe As String = ""
            Dim strEQ1PPID As String = ""
            Dim strEQ2PPID As String = ""

            Dim nEQStartTime(MAX_EQ, 3) As Integer
            Dim nEQEndTime(MAX_EQ, 3) As Integer

            Dim strEQ1StartTiem1 As String = ""
            Dim strEQ1StartTiem2 As String = ""
            Dim strEQ1StartTiem3 As String = ""
            Dim strEQ2StartTiem1 As String = ""
            Dim strEQ2StartTiem2 As String = ""
            Dim strEQ2StartTiem3 As String = ""
            Dim strEQ3StartTiem1 As String = ""
            Dim strEQ3StartTiem2 As String = ""
            Dim strEQ3StartTiem3 As String = ""

            Dim strEQ1EndTiem1 As String = ""
            Dim strEQ1EndTiem2 As String = ""
            Dim strEQ1EndTiem3 As String = ""
            Dim strEQ2EndTiem1 As String = ""
            Dim strEQ2EndTiem2 As String = ""
            Dim strEQ2EndTiem3 As String = ""
            Dim strEQ3EndTiem1 As String = ""
            Dim strEQ3EndTiem2 As String = ""
            Dim strEQ3EndTiem3 As String = ""

            Dim strEQStartTime(MAX_EQ) As String
            Dim strEQEndTime(MAX_EQ) As String
            Dim nProductCategory As Integer


            ReadZRAddr(MyPLC_S167_Addr.SlotData(nPortNo, nSlotNo), anSlotArray)


            For nFor = ePLC_S167_DeviceNo.GLASS_ID_SLOT_WORD1 To ePLC_S167_DeviceNo.GLASS_ID_SLOT_WORD6
                strGlassID = strGlassID & ConvertHiLowASCIIToString(anSlotArray(nFor))
            Next

            Call ReadRD_DG_GG_Grade1(nPortNo, nSlotNo, anSlotArray(ePLC_S167_DeviceNo.RDRAGE_DGRADE_GGRADE))

            For nFor = ePLC_S167_DeviceNo.PSH_GROUP_WORD1 To ePLC_S167_DeviceNo.PSH_GROUP_WORD2
                strPSHGroup = strPSHGroup & ConvertHiLowASCIIToString(anSlotArray(nFor))
            Next

            For nFor = ePLC_S167_DeviceNo.PTOOLID_WORD1 To ePLC_S167_DeviceNo.PTOOLID_WORD4
                strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(anSlotArray(nFor))
            Next

            For nFor = ePLC_S167_DeviceNo.DMQC_TOOL_ID_WORD1 To ePLC_S167_DeviceNo.DMQC_TOOL_ID_WORD4
                strDMQCTOOLID = strDMQCTOOLID & ConvertHiLowASCIIToString(anSlotArray(nFor))
            Next

            For nFor = ePLC_S167_DeviceNo.CHIP_GRADE_WORD1 To ePLC_S167_DeviceNo.CHIP_GRADE_WORD9
                'DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "SlotNo=" & nSlotNo & " ,ChipGrade(Hex)=" & HexLeadZero(anReceiveWordDataBlock2(nFor)))
                strTemp = WordConvertToBin(anSlotArray(nFor), anBit)

                strChipGrade = strChipGrade & ProcessChipGrade(strTemp)
                strTemp = ""
            Next

            Call ReadFIRM_SCRP_RWK_FLAG1(nPortNo, nSlotNo, anSlotArray(ePLC_S167_DeviceNo.FIRMFLAG_SCRPFLAG_RWKFLAG))

            nProductCategory = anSlotArray(ePLC_S167_DeviceNo.PRODUCT_CATEGORY)

            For nFor = ePLC_S167_DeviceNo.CURR_RECIPEIDW1 To ePLC_S167_DeviceNo.CURR_RECIPEIDW16
                strCurrRecipe = strCurrRecipe & ConvertHiLowASCIIToString(anSlotArray(nFor))
            Next

            For nFor = ePLC_S167_DeviceNo.EQ1_TAPE_EPPIDW1 To ePLC_S167_DeviceNo.EQ1_TAPE_EPPIDW2
                strEQ1PPID = strEQ1PPID & ConvertHiLowASCIIToString(anSlotArray(nFor))
            Next

            For nFor = ePLC_S167_DeviceNo.EQ2_INK_EPPIDW1 To ePLC_S167_DeviceNo.EQ2_INK_EPPIDW2
                strEQ2PPID = strEQ2PPID & ConvertHiLowASCIIToString(anSlotArray(nFor))
            Next


            nEQStartTime(1, 1) = anSlotArray(ePLC_S167_DeviceNo.EQ1_START_TIME_1)
            nEQStartTime(1, 2) = anSlotArray(ePLC_S167_DeviceNo.EQ1_START_TIME_2)
            nEQStartTime(1, 3) = anSlotArray(ePLC_S167_DeviceNo.EQ1_START_TIME_3)

            nEQStartTime(2, 1) = anSlotArray(ePLC_S167_DeviceNo.EQ2_START_TIME_1)
            nEQStartTime(2, 2) = anSlotArray(ePLC_S167_DeviceNo.EQ2_START_TIME_2)
            nEQStartTime(2, 3) = anSlotArray(ePLC_S167_DeviceNo.EQ2_START_TIME_3)

            nEQStartTime(3, 1) = anSlotArray(ePLC_S167_DeviceNo.EQ3_START_TIME_1)
            nEQStartTime(3, 2) = anSlotArray(ePLC_S167_DeviceNo.EQ3_START_TIME_2)
            nEQStartTime(3, 3) = anSlotArray(ePLC_S167_DeviceNo.EQ3_START_TIME_3)

            If nEQStartTime(1, 1) <> 0 Then
                strEQ1StartTiem1 = GetProcessTime(nEQStartTime(1, 1))
                strEQ1StartTiem2 = GetProcessTime(nEQStartTime(1, 2))
                strEQ1StartTiem3 = GetProcessTime(nEQStartTime(1, 3))
                strEQStartTime(1) = strEQ1StartTiem1 & strEQ1StartTiem2 & strEQ1StartTiem3
            Else
                strEQStartTime(1) = ""
            End If

            If nEQStartTime(2, 1) <> 0 Then
                strEQ2StartTiem1 = GetProcessTime(nEQStartTime(2, 1))
                strEQ2StartTiem2 = GetProcessTime(nEQStartTime(2, 2))
                strEQ2StartTiem3 = GetProcessTime(nEQStartTime(2, 3))
                strEQStartTime(2) = strEQ2StartTiem1 & strEQ2StartTiem2 & strEQ2StartTiem3
            Else
                strEQStartTime(2) = ""
            End If

            If nEQStartTime(3, 1) <> 0 Then
                strEQ3StartTiem1 = GetProcessTime(nEQStartTime(3, 1))
                strEQ3StartTiem2 = GetProcessTime(nEQStartTime(3, 2))
                strEQ3StartTiem3 = GetProcessTime(nEQStartTime(3, 3))
                strEQStartTime(3) = strEQ3StartTiem1 & strEQ3StartTiem2 & strEQ3StartTiem3
            Else
                strEQStartTime(3) = ""
            End If

            nEQEndTime(1, 1) = anSlotArray(ePLC_S167_DeviceNo.EQ1_END_TIME_1)
            nEQEndTime(1, 2) = anSlotArray(ePLC_S167_DeviceNo.EQ1_END_TIME_2)
            nEQEndTime(1, 3) = anSlotArray(ePLC_S167_DeviceNo.EQ1_END_TIME_3)

            nEQEndTime(2, 1) = anSlotArray(ePLC_S167_DeviceNo.EQ2_END_TIME_1)
            nEQEndTime(2, 2) = anSlotArray(ePLC_S167_DeviceNo.EQ2_END_TIME_2)
            nEQEndTime(2, 3) = anSlotArray(ePLC_S167_DeviceNo.EQ2_END_TIME_3)

            nEQEndTime(3, 1) = anSlotArray(ePLC_S167_DeviceNo.EQ3_END_TIME_1)
            nEQEndTime(3, 2) = anSlotArray(ePLC_S167_DeviceNo.EQ3_END_TIME_2)
            nEQEndTime(3, 3) = anSlotArray(ePLC_S167_DeviceNo.EQ3_END_TIME_3)

            If nEQEndTime(1, 1) <> 0 Then
                strEQ1EndTiem1 = GetProcessTime(nEQEndTime(1, 1))
                strEQ1EndTiem2 = GetProcessTime(nEQEndTime(1, 2))
                strEQ1EndTiem3 = GetProcessTime(nEQEndTime(1, 3))
                strEQEndTime(1) = strEQ1EndTiem1 & strEQ1EndTiem2 & strEQ1EndTiem3
            Else
                strEQEndTime(1) = ""
            End If

            If nEQEndTime(2, 1) <> 0 Then
                strEQ2EndTiem1 = GetProcessTime(nEQEndTime(2, 1))
                strEQ2EndTiem2 = GetProcessTime(nEQEndTime(2, 2))
                strEQ2EndTiem3 = GetProcessTime(nEQEndTime(2, 3))
                strEQEndTime(2) = strEQ2EndTiem1 & strEQ2EndTiem2 & strEQ2EndTiem3
            Else
                strEQEndTime(2) = ""
            End If

            If nEQEndTime(3, 1) <> 0 Then
                strEQ3EndTiem1 = GetProcessTime(nEQEndTime(3, 1))
                strEQ3EndTiem2 = GetProcessTime(nEQEndTime(3, 2))
                strEQ3EndTiem3 = GetProcessTime(nEQEndTime(3, 3))
                strEQEndTime(3) = strEQ3EndTiem1 & strEQ3EndTiem2 & strEQ3EndTiem3
            Else
                strEQEndTime(3) = ""
            End If

            With vCSTSlotInfo
                .GlassID = strGlassID
                .GGRADE = MySlotInfo.nGGRADE(nPortNo, nSlotNo)
                .DGRADE = MySlotInfo.nDGRADE(nPortNo, nSlotNo)
                .RDRAGE = MySlotInfo.nRDRAGE(nPortNo, nSlotNo)
                .PSHGroup = strPSHGroup
                .PTOOLID = strPTOOLID
                .DMQCToolID = strDMQCTOOLID
                .ChipGrade = strChipGrade
                .RWKFLAG = MySlotInfo.nRWKFLAG(nPortNo, nSlotNo)
                .SCRPFLAG = MySlotInfo.nSCRPFLAG(nPortNo, nSlotNo)
                .FIRMFLAG = MySlotInfo.nFIRMFLAG(nPortNo, nSlotNo)
                .ProductCategory = nProductCategory
                .LotRecipeID = strCurrRecipe
                .EQ1PPID = strEQ1PPID
                .EQ2PPID = strEQ2PPID
                .EQStartTime(1) = strEQStartTime(1)
                .EQStartTime(2) = strEQStartTime(2)
                .EQStartTime(3) = strEQStartTime(3)
                .EQEndTime(1) = strEQEndTime(1)
                .EQEndTime(2) = strEQEndTime(2)
                .EQEndTime(3) = strEQEndTime(3)

                'DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "GetCSTSlotData, SlotNo =" & nSlotNo & " ,GXID=" & .GlassID & ", GGRADE=" & .GGRADE & " ,DGRADE=" & .DGRADE _
                '& " ,RDRAGE=" & .RDRAGE & " ,PSHGroup=" & .PSHGroup & " ,PTOOLID=" & .PTOOLID & " ,DMQCToolID=" & .DMQCToolID & " ,RWKFLAG=" & .RWKFLAG _
                '& " ,SCRPFLAG=" & .SCRPFLAG & " ,FIRMFLAG=" & .FIRMFLAG)

                'DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "GetCSTSlotData, SlotNo =" & nSlotNo & " ,ProductCategory[" & .ProductCategory & "] ,LotRecipeID[" & .LotRecipeID & "] ,EQ1PPID[" & .EQ1PPID & "] ,EQ2PPID[" & .EQ2PPID _
                '         & "] ,EQ1StartTime[" & .EQStartTime(1) & "], EQ2StartTime[" & .EQStartTime(2) & "] ,EQ3StartTime[" & .EQStartTime(3) & "] ,EQ1EndTime[" & .EQEndTime(1) & "] ,EQ2EndTime[" & .EQEndTime(2) & "] ,EQ3EndTime[" & .EQEndTime(3) & "]")

                'DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "GetCSTSlotData, SlotNo =" & nSlotNo & " ,ChipGrade =" & .ChipGrade)
            End With


            Return vCSTSlotInfo
        End Get
    End Property

    'Private ReadOnly Property Get167Data(ByVal nPortNo As Integer) As clsS167LotInfo
    '    Get
    '        Dim anReceiveWordDataBlock1(LEN_S167_BLOCK1) As Integer
    '        Dim vLotInfo As New clsS167LotInfo
    '        Dim nFor As Integer
    '        Dim nCassetteStatus As Integer
    '        Dim strPortTypeMode As String = ""
    '        Dim nPortType As Integer
    '        Dim nPortMode As Integer
    '        Dim nTotalQtyInCst As Integer
    '        Dim nCassetteUnloadStatus As Integer
    '        Dim strCassetteID As String = ""
    '        Dim strOperationID As String = ""

    '        Call ReadZRAddr(MyPLC_S167_Addr.LotData(nPortNo), anReceiveWordDataBlock1)

    '        For nFor = ePLC_S167_DeviceNo.CASSETTE_ID_WORD1 To ePLC_S167_DeviceNo.CASSETTE_ID_WORD3
    '            strCassetteID = strCassetteID & ConvertHiLowASCIIToString(anReceiveWordDataBlock1(nFor))
    '        Next

    '        nCassetteStatus = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.CASSETTE_STATUS)

    '        For nFor = ePLC_S167_DeviceNo.OPERATION_ID_W1 To ePLC_S167_DeviceNo.OPERATION_ID_W13
    '            strOperationID = strOperationID & ConvertHiLowASCIIToString(anReceiveWordDataBlock1(nFor))
    '        Next

    '        strPortTypeMode = HexLeadZero(anReceiveWordDataBlock1(ePLC_S167_DeviceNo.PORT_TYPE_MODE))
    '        Call GetHIbyteLibyte(strPortTypeMode, nPortType, nPortMode)

    '        nCassetteUnloadStatus = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.CST_UNLOAD_STATUS)

    '        nTotalQtyInCst = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.TOTAL_QTY_IN_CST)

    '        With vLotInfo
    '            .OperationID = strOperationID
    '            .CassetteID = strCassetteID
    '            .CassetteStatus = nCassetteStatus
    '            .PortMode = nPortMode
    '            .PortType = nPortType
    '            .CassetteUnloadStatus = nCassetteUnloadStatus '1:Normal,2:Abnormal
    '            .TotalQtyInCassette = nTotalQtyInCst
    '        End With

    '        ProcessPLC167SlotData(nPortNo)

    '        For nFor = 1 To MAX_SLOTS
    '            With vLotInfo.Slots(nFor)
    '                .GlassID = MyCSTSlotInfo.strSlotGlassID(nPortNo, nFor)
    '                .GGRADE = MyCSTSlotInfo.nGGRADE(nPortNo, nFor)
    '                .DGRADE = MyCSTSlotInfo.nDGRADE(nPortNo, nFor)
    '                .RDRAGE = MyCSTSlotInfo.nRDRAGE(nPortNo, nFor)
    '                .PSHGroup = MyCSTSlotInfo.strPSHGroup(nPortNo, nFor)
    '                .PTOOLID = MyCSTSlotInfo.strPTOOLID(nPortNo, nFor)
    '                .DMQCToolID = MyCSTSlotInfo.strDMQCToolID(nPortNo, nFor)
    '                .ChipGrade = MyCSTSlotInfo.strChipGrade(nPortNo, nFor)
    '                .RWKFLAG = MyCSTSlotInfo.nRWKFLAG(nPortNo, nFor)
    '                .SCRPFLAG = MyCSTSlotInfo.nSCRPFLAG(nPortNo, nFor)
    '                .FIRMFLAG = MyCSTSlotInfo.nFIRMFLAG(nPortNo, nFor)

    '                .ProductCategory = MyCSTSlotInfo.nProductCategory(nPortNo, nFor)
    '                .LotRecipeID = MyCSTSlotInfo.strCurrentRecipe(nPortNo, nFor)
    '                .EQ1PPID = MyCSTSlotInfo.strEQ1Tape(nPortNo, nFor)
    '                .EQ2PPID = MyCSTSlotInfo.strEQ2Ink(nPortNo, nFor)

    '                .EQStartTime(1) = MyCSTSlotInfo.strEQ1StartTime(nPortNo, nFor)
    '                .EQStartTime(2) = MyCSTSlotInfo.strEQ2StartTime(nPortNo, nFor)
    '                .EQStartTime(3) = MyCSTSlotInfo.strEQ3StartTime(nPortNo, nFor)

    '                .EQEndTime(1) = MyCSTSlotInfo.strEQ1EndTime(nPortNo, nFor)
    '                .EQEndTime(2) = MyCSTSlotInfo.strEQ2EndTime(nPortNo, nFor)
    '                .EQEndTime(3) = MyCSTSlotInfo.strEQ3EndTime(nPortNo, nFor)

    '            End With
    '        Next

    '        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Get S167 Data, CassetteStatus =" & vLotInfo.CassetteStatus.ToString & " ,PortMode =" & vLotInfo.PortMode.ToString & " ,PortType =" & vLotInfo.PortType.ToString _
    '                 & ", CassetteUnloadStatus =" & vLotInfo.CassetteUnloadStatus.ToString & " ,TotalQtyInCassette =" & vLotInfo.TotalQtyInCassette & " ,CassetteID =" & vLotInfo.CassetteID & " ,OperationID =" & vLotInfo.OperationID)

    '        'For nFor = 1 To MAX_SLOTS
    '        '    With vLotInfo.Slots(nFor)
    '        '        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Get S167Data, SlotNo =" & nFor & " ,GXID=" & .GlassID & ", GGRADE=" & .GGRADE & " ,DGRADE=" & .DGRADE _
    '        '        & " ,RDRAGE=" & .RDRAGE & " ,PSHGroup=" & .PSHGroup & " ,PTOOLID=" & .PTOOLID & " ,DMQCToolID=" & .DMQCToolID & " ,RWKFLAG=" & .RWKFLAG _
    '        '        & " ,SCRPFLAG=" & .SCRPFLAG & " ,FIRMFLAG=" & .FIRMFLAG)

    '        '        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Get S167Data, SlotNo =" & nFor & " ,ProductCategory[" & .ProductCategory & "] ,LotRecipeID[" & .LotRecipeID & "] ,EQ1PPID[" & .EQ1PPID & "] ,EQ2PPID[" & .EQ2PPID _
    '        '                 & "] ,EQ1StartTime[" & .EQStartTime(1) & "], EQ2StartTime[" & .EQStartTime(2) & "] ,EQ3StartTime[" & .EQStartTime(3) & "] ,EQ1EndTime[" & .EQEndTime(1) & "] ,EQ2EndTime[" & .EQEndTime(2) & "] ,EQ3EndTime[" & .EQEndTime(3) & "]")

    '        '        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Get S167Data, SlotNo =" & nFor & " ,ChipGrade =" & vLotInfo.Slots(nFor).ChipGrade)
    '        '    End With
    '        'Next

    '        Return vLotInfo

    '    End Get
    'End Property

    Private Sub INIT167Data(ByVal nPortNo As Integer)
        Dim anReceiveWordDataBlock1(LEN_S167_BLOCK1) As Integer
        Dim vLotInfo As New clsS167LotInfo
        Dim nFor As Integer
        Dim nCassetteStatus As Integer
        Dim strPortTypeMode As String = ""
        Dim nPortType As Integer
        Dim nPortMode As Integer
        Dim nTotalQtyInCst As Integer
        Dim nCassetteUnloadStatus As Integer
        Dim strCassetteID As String = ""
        Dim strOperationID As String = ""
        Dim nSlotTermination As Integer

        Call ReadZRAddr(MyPLC_S167_Addr.LotData(nPortNo), anReceiveWordDataBlock1)

        For nFor = ePLC_S167_DeviceNo.CASSETTE_ID_WORD1 To ePLC_S167_DeviceNo.CASSETTE_ID_WORD3
            strCassetteID = strCassetteID & ConvertHiLowASCIIToString(anReceiveWordDataBlock1(nFor))
        Next

        nCassetteStatus = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.CASSETTE_STATUS)

        For nFor = ePLC_S167_DeviceNo.OPERATION_ID_W1 To ePLC_S167_DeviceNo.OPERATION_ID_W13
            strOperationID = strOperationID & ConvertHiLowASCIIToString(anReceiveWordDataBlock1(nFor))
        Next

        strPortTypeMode = HexLeadZero(anReceiveWordDataBlock1(ePLC_S167_DeviceNo.PORT_TYPE_MODE))
        Call GetHIbyteLibyte(strPortTypeMode, nPortType, nPortMode)

        nCassetteUnloadStatus = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.CST_UNLOAD_STATUS)

        nTotalQtyInCst = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.TOTAL_QTY_IN_CST)

        With vLotInfo
            .OperationID = strOperationID
            .CassetteID = strCassetteID
            .CassetteStatus = nCassetteStatus
            .PortMode = nPortMode
            .PortType = nPortType
            .CassetteUnloadStatus = nCassetteUnloadStatus '1:Normal,2:Abnormal
            .TotalQtyInCassette = nTotalQtyInCst
        End With

        ProcessPLC167SlotData(nPortNo)

        If nTotalQtyInCst = 0 Or nTotalQtyInCst > MAX_SLOTS Then
            For nFor = 1 To MAX_SLOTS
                With vLotInfo.Slots(nFor)
                    .GlassID = ""
                    .GGRADE = eDGRADE.NO_GLASS
                    .DGRADE = eDGRADE.NO_GLASS
                    .RDRAGE = eRDGRADE.NO_GLASS
                    .PSHGroup = ""
                    .PTOOLID = ""
                    .DMQCToolID = ""
                    .ChipGrade = ""
                    .RWKFLAG = eRWKFLAG.NORMAL_GLASS
                    .SCRPFLAG = 0
                    .FIRMFLAG = 0

                    .ProductCategory = eProductCategory.NA
                    .LotRecipeID = ""
                    .EQ1PPID = ""
                    .EQ2PPID = ""

                    .EQStartTime(1) = ""
                    .EQStartTime(2) = ""
                    .EQStartTime(3) = ""

                    .EQEndTime(1) = ""
                    .EQEndTime(2) = ""
                    .EQEndTime(3) = ""
                End With
            Next
        Else
            nSlotTermination = MAX_SLOTS - nTotalQtyInCst + 1

            'For nFor = 1 To MAX_SLOTS
            For nFor = MAX_SLOTS To nSlotTermination Step -1
                With vLotInfo.Slots(nFor)
                    .SlotNo = nFor
                    .GlassID = MyCSTSlotInfo.strSlotGlassID(nPortNo, nFor)
                    .GGRADE = MyCSTSlotInfo.nGGRADE(nPortNo, nFor)
                    .DGRADE = MyCSTSlotInfo.nDGRADE(nPortNo, nFor)
                    .RDRAGE = MyCSTSlotInfo.nRDRAGE(nPortNo, nFor)
                    .PSHGroup = MyCSTSlotInfo.strPSHGroup(nPortNo, nFor)
                    .PTOOLID = MyCSTSlotInfo.strPTOOLID(nPortNo, nFor)
                    .DMQCToolID = MyCSTSlotInfo.strDMQCToolID(nPortNo, nFor)
                    .ChipGrade = MyCSTSlotInfo.strChipGrade(nPortNo, nFor)
                    .RWKFLAG = MyCSTSlotInfo.nRWKFLAG(nPortNo, nFor)
                    .SCRPFLAG = MyCSTSlotInfo.nSCRPFLAG(nPortNo, nFor)
                    .FIRMFLAG = MyCSTSlotInfo.nFIRMFLAG(nPortNo, nFor)

                    .ProductCategory = MyCSTSlotInfo.nProductCategory(nPortNo, nFor)
                    .LotRecipeID = MyCSTSlotInfo.strCurrentRecipe(nPortNo, nFor)
                    .EQ1PPID = MyCSTSlotInfo.strEQ1Tape(nPortNo, nFor)
                    .EQ2PPID = MyCSTSlotInfo.strEQ2Ink(nPortNo, nFor)

                    .EQStartTime(1) = MyCSTSlotInfo.strEQ1StartTime(nPortNo, nFor)
                    .EQStartTime(2) = MyCSTSlotInfo.strEQ2StartTime(nPortNo, nFor)
                    .EQStartTime(3) = MyCSTSlotInfo.strEQ3StartTime(nPortNo, nFor)

                    .EQEndTime(1) = MyCSTSlotInfo.strEQ1EndTime(nPortNo, nFor)
                    .EQEndTime(2) = MyCSTSlotInfo.strEQ2EndTime(nPortNo, nFor)
                    .EQEndTime(3) = MyCSTSlotInfo.strEQ3EndTime(nPortNo, nFor)
                End With
            Next
        End If

        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "INIT S167Events, CassetteStatus =" & vLotInfo.CassetteStatus.ToString & " ,PortMode =" & vLotInfo.PortMode.ToString & " ,PortType =" & vLotInfo.PortType.ToString _
                 & ", CassetteUnloadStatus =" & vLotInfo.CassetteUnloadStatus.ToString & " ,TotalQtyInCassette =" & vLotInfo.TotalQtyInCassette & " ,CassetteID =" & vLotInfo.CassetteID & " ,OperationID =" & vLotInfo.OperationID)

        'For nFor = 1 To MAX_SLOTS
        '    With vLotInfo.Slots(nFor)
        '        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "S167Events, SlotNo =" & nFor & " ,GXID=" & .GlassID & ", GGRADE=" & .GGRADE & " ,DGRADE=" & .DGRADE _
        '        & " ,RDRAGE=" & .RDRAGE & " ,PSHGroup=" & .PSHGroup & " ,PTOOLID=" & .PTOOLID & " ,DMQCToolID=" & .DMQCToolID & " ,RWKFLAG=" & .RWKFLAG _
        '        & " ,SCRPFLAG=" & .SCRPFLAG & " ,FIRMFLAG=" & .FIRMFLAG)

        '        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "S167Events, SlotNo =" & nFor & " ,ProductCategory[" & .ProductCategory & "] ,LotRecipeID[" & .LotRecipeID & "] ,EQ1PPID[" & .EQ1PPID & "] ,EQ2PPID[" & .EQ2PPID _
        '                 & "] ,EQ1StartTime[" & .EQStartTime(1) & "], EQ2StartTime[" & .EQStartTime(2) & "] ,EQ3StartTime[" & .EQStartTime(3) & "] ,EQ1EndTime[" & .EQEndTime(1) & "] ,EQ2EndTime[" & .EQEndTime(2) & "] ,EQ3EndTime[" & .EQEndTime(3) & "]")

        '        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "S167Events, SlotNo =" & nFor & " ,ChipGrade =" & vLotInfo.Slots(nFor).ChipGrade)
        '    End With
        'Next

        RaiseEvent CVINIT167data(nPortNo, vLotInfo)
    End Sub


    Private Sub ReadS167Data(ByVal nPortNo As Integer)
        Dim anReceiveWordDataBlock1(LEN_S167_BLOCK1) As Integer
        Dim vLotInfo As New clsS167LotInfo
        Dim nFor As Integer
        Dim nCassetteStatus As Integer
        Dim strPortTypeMode As String = ""
        Dim nPortType As Integer
        Dim nPortMode As Integer
        Dim nTotalQtyInCst As Integer
        Dim nCassetteUnloadStatus As Integer
        Dim strCassetteID As String = ""
        Dim strOperationID As String = ""
        Dim nSlotTermination As Integer

        Call ReadZRAddr(MyPLC_S167_Addr.LotData(nPortNo), anReceiveWordDataBlock1)

        For nFor = ePLC_S167_DeviceNo.CASSETTE_ID_WORD1 To ePLC_S167_DeviceNo.CASSETTE_ID_WORD3
            strCassetteID = strCassetteID & ConvertHiLowASCIIToString(anReceiveWordDataBlock1(nFor))
        Next

        nCassetteStatus = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.CASSETTE_STATUS)

        For nFor = ePLC_S167_DeviceNo.OPERATION_ID_W1 To ePLC_S167_DeviceNo.OPERATION_ID_W13
            strOperationID = strOperationID & ConvertHiLowASCIIToString(anReceiveWordDataBlock1(nFor))
        Next

        strPortTypeMode = HexLeadZero(anReceiveWordDataBlock1(ePLC_S167_DeviceNo.PORT_TYPE_MODE))
        Call GetHIbyteLibyte(strPortTypeMode, nPortType, nPortMode)

        nCassetteUnloadStatus = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.CST_UNLOAD_STATUS)

        nTotalQtyInCst = anReceiveWordDataBlock1(ePLC_S167_DeviceNo.TOTAL_QTY_IN_CST)

        With vLotInfo
            .OperationID = strOperationID
            .CassetteID = strCassetteID
            .CassetteStatus = MyRSTNewWord.mnCSTStatus(nPortNo)
            .PortMode = nPortMode
            .PortType = nPortType
            .CassetteUnloadStatus = nCassetteUnloadStatus '1:Normal,2:Abnormal
            .TotalQtyInCassette = MyRSTNewWord.mnCSTGxCount(nPortNo)
        End With

        ProcessPLC167SlotData(nPortNo)

        If MyRSTNewWord.mnCSTGxCount(nPortNo) = 0 Or MyRSTNewWord.mnCSTGxCount(nPortNo) > MAX_SLOTS Then
            For nFor = 1 To MAX_SLOTS
                With vLotInfo.Slots(nFor)
                    .GlassID = ""
                    .GGRADE = eDGRADE.NO_GLASS
                    .DGRADE = eDGRADE.NO_GLASS
                    .RDRAGE = eRDGRADE.NO_GLASS
                    .PSHGroup = ""
                    .PTOOLID = ""
                    .DMQCToolID = ""
                    .ChipGrade = ""
                    .RWKFLAG = eRWKFLAG.NORMAL_GLASS
                    .SCRPFLAG = 0
                    .FIRMFLAG = 0

                    .ProductCategory = eProductCategory.NA
                    .LotRecipeID = ""
                    .EQ1PPID = ""
                    .EQ2PPID = ""

                    .EQStartTime(1) = ""
                    .EQStartTime(2) = ""
                    .EQStartTime(3) = ""

                    .EQEndTime(1) = ""
                    .EQEndTime(2) = ""
                    .EQEndTime(3) = ""
                End With
            Next
        Else
            nSlotTermination = MAX_SLOTS - MyRSTNewWord.mnCSTGxCount(nPortNo) + 1

            'For nFor = 1 To MAX_SLOTS
            For nFor = MAX_SLOTS To nSlotTermination Step -1
                With vLotInfo.Slots(nFor)
                    .SlotNo = nFor
                    .GlassID = MyCSTSlotInfo.strSlotGlassID(nPortNo, nFor)
                    .GGRADE = MyCSTSlotInfo.nGGRADE(nPortNo, nFor)
                    .DGRADE = MyCSTSlotInfo.nDGRADE(nPortNo, nFor)
                    .RDRAGE = MyCSTSlotInfo.nRDRAGE(nPortNo, nFor)
                    .PSHGroup = MyCSTSlotInfo.strPSHGroup(nPortNo, nFor)
                    .PTOOLID = MyCSTSlotInfo.strPTOOLID(nPortNo, nFor)
                    .DMQCToolID = MyCSTSlotInfo.strDMQCToolID(nPortNo, nFor)
                    .ChipGrade = MyCSTSlotInfo.strChipGrade(nPortNo, nFor)
                    .RWKFLAG = MyCSTSlotInfo.nRWKFLAG(nPortNo, nFor)
                    .SCRPFLAG = MyCSTSlotInfo.nSCRPFLAG(nPortNo, nFor)
                    .FIRMFLAG = MyCSTSlotInfo.nFIRMFLAG(nPortNo, nFor)

                    .ProductCategory = MyCSTSlotInfo.nProductCategory(nPortNo, nFor)
                    .LotRecipeID = MyCSTSlotInfo.strCurrentRecipe(nPortNo, nFor)
                    .EQ1PPID = MyCSTSlotInfo.strEQ1Tape(nPortNo, nFor)
                    .EQ2PPID = MyCSTSlotInfo.strEQ2Ink(nPortNo, nFor)

                    .EQStartTime(1) = MyCSTSlotInfo.strEQ1StartTime(nPortNo, nFor)
                    .EQStartTime(2) = MyCSTSlotInfo.strEQ2StartTime(nPortNo, nFor)
                    .EQStartTime(3) = MyCSTSlotInfo.strEQ3StartTime(nPortNo, nFor)

                    .EQEndTime(1) = MyCSTSlotInfo.strEQ1EndTime(nPortNo, nFor)
                    .EQEndTime(2) = MyCSTSlotInfo.strEQ2EndTime(nPortNo, nFor)
                    .EQEndTime(3) = MyCSTSlotInfo.strEQ3EndTime(nPortNo, nFor)
                End With
            Next
        End If



        DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "S167Events, CassetteStatus =" & vLotInfo.CassetteStatus.ToString & " ,PortMode =" & vLotInfo.PortMode.ToString & " ,PortType =" & vLotInfo.PortType.ToString _
                 & ", CassetteUnloadStatus =" & vLotInfo.CassetteUnloadStatus.ToString & " ,TotalQtyInCassette =" & vLotInfo.TotalQtyInCassette & " ,CassetteID =" & vLotInfo.CassetteID & " ,OperationID =" & vLotInfo.OperationID)

        For nFor = 1 To MAX_SLOTS
            With vLotInfo.Slots(nFor)
                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "S167Events, SlotNo =" & nFor & " ,GXID=" & .GlassID & ", GGRADE=" & .GGRADE & " ,DGRADE=" & .DGRADE _
                & " ,RDRAGE=" & .RDRAGE & " ,PSHGroup=" & .PSHGroup & " ,PTOOLID=" & .PTOOLID & " ,DMQCToolID=" & .DMQCToolID & " ,RWKFLAG=" & .RWKFLAG _
                & " ,SCRPFLAG=" & .SCRPFLAG & " ,FIRMFLAG=" & .FIRMFLAG)

                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "S167Events, SlotNo =" & nFor & " ,ProductCategory[" & .ProductCategory & "] ,LotRecipeID[" & .LotRecipeID & "] ,EQ1PPID[" & .EQ1PPID & "] ,EQ2PPID[" & .EQ2PPID _
                         & "] ,EQ1StartTime[" & .EQStartTime(1) & "], EQ2StartTime[" & .EQStartTime(2) & "] ,EQ3StartTime[" & .EQStartTime(3) & "] ,EQ1EndTime[" & .EQEndTime(1) & "] ,EQ2EndTime[" & .EQEndTime(2) & "] ,EQ3EndTime[" & .EQEndTime(3) & "]")

                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "S167Events, SlotNo =" & nFor & " ,ChipGrade =" & vLotInfo.Slots(nFor).ChipGrade)
            End With
        Next

        RaiseEvent CVS167dataUploadRequest(nPortNo, vLotInfo)

        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]S167 Data Upload Ack On")
        Call WriteMAddr(MyCVMAddr.m_nS167DataUploadAck(nPortNo), True)
    End Sub

    Private Sub ProcessPLC167SlotData(ByVal nPortNo As Integer)
        Dim j As Integer = 0
        Dim i As Integer = 0
        Dim nSlot As Integer = 0
        Dim anReceiveSlotData1(LEN_S1F67_SLOT_ARRAY1) As Integer
        Dim anReceiveSlotData2(LEN_S1F67_SLOT_ARRAY1) As Integer
        Dim anReceiveSlotData3(LEN_S1F67_SLOT_ARRAY1) As Integer
        Dim anReceiveSlotData4(LEN_S1F67_SLOT_ARRAY1) As Integer
        Dim anReceiveSlotData5(LEN_S1F67_SLOT_ARRAY1) As Integer
        Dim anReceiveSlotData6(LEN_S1F67_SLOT_ARRAY2) As Integer


        Dim nStartLocation As Integer = 0
        Dim anSlotArray(LEN_S167_BLOCK2) As Integer

        Dim nSlotStartFlag1 As Integer = 660
        Dim nSlotStartFlag2 As Integer = 1320
        Dim nSlotStartFlag3 As Integer = 1980
        Dim nSlotStartFlag4 As Integer = 2640
        Dim nSlotStartFlag5 As Integer = 3300

        Dim MySlotData(MAX_PORTS, LEN_MAX_SLOT_QTY) As Integer


        ReadZRAddr(MyPLC_S167_Addr.SlotData(nPortNo, 1), anReceiveSlotData1)
        ReadZRAddr(MyPLC_S167_Addr.SlotData(nPortNo, 11), anReceiveSlotData2)
        ReadZRAddr(MyPLC_S167_Addr.SlotData(nPortNo, 21), anReceiveSlotData3)
        ReadZRAddr(MyPLC_S167_Addr.SlotData(nPortNo, 31), anReceiveSlotData4)
        ReadZRAddr(MyPLC_S167_Addr.SlotData(nPortNo, 41), anReceiveSlotData5)
        ReadZRAddr(MyPLC_S167_Addr.SlotData(nPortNo, 51), anReceiveSlotData6)

        For i = 0 To LEN_S1F67_SLOT_ARRAY1
            '1~10 Slot
            MySlotData(nPortNo, i) = anReceiveSlotData1(i)

            '11~20 Slot
            MySlotData(nPortNo, i + nSlotStartFlag1) = anReceiveSlotData2(i)
            '21~30 Slot
            MySlotData(nPortNo, i + nSlotStartFlag2) = anReceiveSlotData3(i)
            '31~40 Slot
            MySlotData(nPortNo, i + nSlotStartFlag3) = anReceiveSlotData4(i)
            '41~50 Slot
            MySlotData(nPortNo, i + nSlotStartFlag4) = anReceiveSlotData5(i)
        Next

        For i = 0 To LEN_S1F67_SLOT_ARRAY2
            '51~56 Slot
            MySlotData(nPortNo, i + nSlotStartFlag5) = anReceiveSlotData6(i)
        Next

        '1~56 Slot
        For nSlot = 1 To MAX_SLOTS
            nStartLocation = 66 * (nSlot - 1)
            For j = 0 To LEN_S167_BLOCK2
                anSlotArray(j) = MySlotData(nPortNo, (j + nStartLocation))
            Next
            ReportS167SlotData(nPortNo, nSlot, anSlotArray)
        Next
    End Sub

    Private Sub ReportS167SlotData(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal anSlotData() As Integer)
        Dim strGlassID As String = ""
        Dim nFor As Integer
        Dim strPSHGroup As String = ""
        Dim strPTOOLID As String = ""
        Dim strDMQCTOOLID As String = ""
        Dim strTemp As String = ""
        Dim anBit(MAX_BIT) As Short
        Dim strChipGrade As String = ""
        Dim strCurrRecipe As String = ""
        Dim strEQ1PPID As String = ""
        Dim strEQ2PPID As String = ""

        Dim nEQStartTime(MAX_EQ, 3) As Integer
        Dim nEQEndTime(MAX_EQ, 3) As Integer

        Dim strEQ1StartTiem1 As String = ""
        Dim strEQ1StartTiem2 As String = ""
        Dim strEQ1StartTiem3 As String = ""
        Dim strEQ2StartTiem1 As String = ""
        Dim strEQ2StartTiem2 As String = ""
        Dim strEQ2StartTiem3 As String = ""
        Dim strEQ3StartTiem1 As String = ""
        Dim strEQ3StartTiem2 As String = ""
        Dim strEQ3StartTiem3 As String = ""

        Dim strEQ1EndTiem1 As String = ""
        Dim strEQ1EndTiem2 As String = ""
        Dim strEQ1EndTiem3 As String = ""
        Dim strEQ2EndTiem1 As String = ""
        Dim strEQ2EndTiem2 As String = ""
        Dim strEQ2EndTiem3 As String = ""
        Dim strEQ3EndTiem1 As String = ""
        Dim strEQ3EndTiem2 As String = ""
        Dim strEQ3EndTiem3 As String = ""


        For nFor = ePLC_S167_DeviceNo.GLASS_ID_SLOT_WORD1 To ePLC_S167_DeviceNo.GLASS_ID_SLOT_WORD6
            strGlassID = strGlassID & ConvertHiLowASCIIToString(anSlotData(nFor))
        Next
        MyCSTSlotInfo.strSlotGlassID(nPortNo, nSlotNo) = strGlassID

        Call ReadRD_DG_GG_Grade(nPortNo, nSlotNo, anSlotData(ePLC_S167_DeviceNo.RDRAGE_DGRADE_GGRADE))

        For nFor = ePLC_S167_DeviceNo.PSH_GROUP_WORD1 To ePLC_S167_DeviceNo.PSH_GROUP_WORD2
            strPSHGroup = strPSHGroup & ConvertHiLowASCIIToString(anSlotData(nFor))
        Next
        MyCSTSlotInfo.strPSHGroup(nPortNo, nSlotNo) = strPSHGroup

        For nFor = ePLC_S167_DeviceNo.PTOOLID_WORD1 To ePLC_S167_DeviceNo.PTOOLID_WORD4
            strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(anSlotData(nFor))
        Next
        MyCSTSlotInfo.strPTOOLID(nPortNo, nSlotNo) = strPTOOLID

        For nFor = ePLC_S167_DeviceNo.DMQC_TOOL_ID_WORD1 To ePLC_S167_DeviceNo.DMQC_TOOL_ID_WORD4
            strDMQCTOOLID = strDMQCTOOLID & ConvertHiLowASCIIToString(anSlotData(nFor))
        Next
        MyCSTSlotInfo.strDMQCToolID(nPortNo, nSlotNo) = strDMQCTOOLID

        For nFor = ePLC_S167_DeviceNo.CHIP_GRADE_WORD1 To ePLC_S167_DeviceNo.CHIP_GRADE_WORD9
            'DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "SlotNo=" & nSlotNo & " ,ChipGrade(Hex)=" & HexLeadZero(anReceiveWordDataBlock2(nFor)))
            strTemp = WordConvertToBin(anSlotData(nFor), anBit)

            strChipGrade = strChipGrade & ProcessChipGrade(strTemp)
            strTemp = ""
        Next
        MyCSTSlotInfo.strChipGrade(nPortNo, nSlotNo) = strChipGrade

        Call ReadFIRM_SCRP_RWK_FLAG(nPortNo, nSlotNo, anSlotData(ePLC_S167_DeviceNo.FIRMFLAG_SCRPFLAG_RWKFLAG))

        MyCSTSlotInfo.nProductCategory(nPortNo, nSlotNo) = anSlotData(ePLC_S167_DeviceNo.PRODUCT_CATEGORY)

        For nFor = ePLC_S167_DeviceNo.CURR_RECIPEIDW1 To ePLC_S167_DeviceNo.CURR_RECIPEIDW16
            strCurrRecipe = strCurrRecipe & ConvertHiLowASCIIToString(anSlotData(nFor))
        Next
        MyCSTSlotInfo.strCurrentRecipe(nPortNo, nSlotNo) = strCurrRecipe

        For nFor = ePLC_S167_DeviceNo.EQ1_TAPE_EPPIDW1 To ePLC_S167_DeviceNo.EQ1_TAPE_EPPIDW2
            strEQ1PPID = strEQ1PPID & ConvertHiLowASCIIToString(anSlotData(nFor))
        Next
        MyCSTSlotInfo.strEQ1Tape(nPortNo, nSlotNo) = strEQ1PPID

        For nFor = ePLC_S167_DeviceNo.EQ2_INK_EPPIDW1 To ePLC_S167_DeviceNo.EQ2_INK_EPPIDW2
            strEQ2PPID = strEQ2PPID & ConvertHiLowASCIIToString(anSlotData(nFor))
        Next
        MyCSTSlotInfo.strEQ2Ink(nPortNo, nSlotNo) = strEQ2PPID

        nEQStartTime(1, 1) = anSlotData(ePLC_S167_DeviceNo.EQ1_START_TIME_1)
        nEQStartTime(1, 2) = anSlotData(ePLC_S167_DeviceNo.EQ1_START_TIME_2)
        nEQStartTime(1, 3) = anSlotData(ePLC_S167_DeviceNo.EQ1_START_TIME_3)

        nEQStartTime(2, 1) = anSlotData(ePLC_S167_DeviceNo.EQ2_START_TIME_1)
        nEQStartTime(2, 2) = anSlotData(ePLC_S167_DeviceNo.EQ2_START_TIME_2)
        nEQStartTime(2, 3) = anSlotData(ePLC_S167_DeviceNo.EQ2_START_TIME_3)

        nEQStartTime(3, 1) = anSlotData(ePLC_S167_DeviceNo.EQ3_START_TIME_1)
        nEQStartTime(3, 2) = anSlotData(ePLC_S167_DeviceNo.EQ3_START_TIME_2)
        nEQStartTime(3, 3) = anSlotData(ePLC_S167_DeviceNo.EQ3_START_TIME_3)

        If nEQStartTime(1, 1) <> 0 Then
            strEQ1StartTiem1 = GetProcessTime(nEQStartTime(1, 1))
            strEQ1StartTiem2 = GetProcessTime(nEQStartTime(1, 2))
            strEQ1StartTiem3 = GetProcessTime(nEQStartTime(1, 3))
            MyCSTSlotInfo.strEQ1StartTime(nPortNo, nSlotNo) = strEQ1StartTiem1 & strEQ1StartTiem2 & strEQ1StartTiem3
        Else
            MyCSTSlotInfo.strEQ1StartTime(nPortNo, nSlotNo) = ""
        End If

        If nEQStartTime(2, 1) <> 0 Then
            strEQ2StartTiem1 = GetProcessTime(nEQStartTime(2, 1))
            strEQ2StartTiem2 = GetProcessTime(nEQStartTime(2, 2))
            strEQ2StartTiem3 = GetProcessTime(nEQStartTime(2, 3))
            MyCSTSlotInfo.strEQ2StartTime(nPortNo, nSlotNo) = strEQ2StartTiem1 & strEQ2StartTiem2 & strEQ2StartTiem3
        Else
            MyCSTSlotInfo.strEQ2StartTime(nPortNo, nSlotNo) = ""
        End If

        If nEQStartTime(3, 1) <> 0 Then
            strEQ3StartTiem1 = GetProcessTime(nEQStartTime(3, 1))
            strEQ3StartTiem2 = GetProcessTime(nEQStartTime(3, 2))
            strEQ3StartTiem3 = GetProcessTime(nEQStartTime(3, 3))
            MyCSTSlotInfo.strEQ3StartTime(nPortNo, nSlotNo) = strEQ3StartTiem1 & strEQ3StartTiem2 & strEQ3StartTiem3
        Else
            MyCSTSlotInfo.strEQ3StartTime(nPortNo, nSlotNo) = ""
        End If

        nEQEndTime(1, 1) = anSlotData(ePLC_S167_DeviceNo.EQ1_END_TIME_1)
        nEQEndTime(1, 2) = anSlotData(ePLC_S167_DeviceNo.EQ1_END_TIME_2)
        nEQEndTime(1, 3) = anSlotData(ePLC_S167_DeviceNo.EQ1_END_TIME_3)

        nEQEndTime(2, 1) = anSlotData(ePLC_S167_DeviceNo.EQ2_END_TIME_1)
        nEQEndTime(2, 2) = anSlotData(ePLC_S167_DeviceNo.EQ2_END_TIME_2)
        nEQEndTime(2, 3) = anSlotData(ePLC_S167_DeviceNo.EQ2_END_TIME_3)

        nEQEndTime(3, 1) = anSlotData(ePLC_S167_DeviceNo.EQ3_END_TIME_1)
        nEQEndTime(3, 2) = anSlotData(ePLC_S167_DeviceNo.EQ3_END_TIME_2)
        nEQEndTime(3, 3) = anSlotData(ePLC_S167_DeviceNo.EQ3_END_TIME_3)

        If nEQEndTime(1, 1) <> 0 Then
            strEQ1EndTiem1 = GetProcessTime(nEQEndTime(1, 1))
            strEQ1EndTiem2 = GetProcessTime(nEQEndTime(1, 2))
            strEQ1EndTiem3 = GetProcessTime(nEQEndTime(1, 3))
            MyCSTSlotInfo.strEQ1EndTime(nPortNo, nSlotNo) = strEQ1EndTiem1 & strEQ1EndTiem2 & strEQ1EndTiem3
        Else
            MyCSTSlotInfo.strEQ1EndTime(nPortNo, nSlotNo) = ""
        End If

        If nEQEndTime(2, 1) <> 0 Then
            strEQ2EndTiem1 = GetProcessTime(nEQEndTime(2, 1))
            strEQ2EndTiem2 = GetProcessTime(nEQEndTime(2, 2))
            strEQ2EndTiem3 = GetProcessTime(nEQEndTime(2, 3))
            MyCSTSlotInfo.strEQ2EndTime(nPortNo, nSlotNo) = strEQ2EndTiem1 & strEQ2EndTiem2 & strEQ2EndTiem3
        Else
            MyCSTSlotInfo.strEQ2EndTime(nPortNo, nSlotNo) = ""
        End If

        If nEQEndTime(3, 1) <> 0 Then
            strEQ3EndTiem1 = GetProcessTime(nEQEndTime(3, 1))
            strEQ3EndTiem2 = GetProcessTime(nEQEndTime(3, 2))
            strEQ3EndTiem3 = GetProcessTime(nEQEndTime(3, 3))
            MyCSTSlotInfo.strEQ3EndTime(nPortNo, nSlotNo) = strEQ3EndTiem1 & strEQ3EndTiem2 & strEQ3EndTiem3
        Else
            MyCSTSlotInfo.strEQ3EndTime(nPortNo, nSlotNo) = ""
        End If

    End Sub

    Private Sub ReadFIRM_SCRP_RWK_FLAG(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nVaule As Integer)
        Dim strHexData As String = ""
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0

        strHexData = HexLeadZero(nVaule)
        Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)

        'r->1:MarkedRework,2:NormalGlass,s->1:MarkedScrap,2:MarkedRecycled,f->1:Marked for FI-Macro used,2:Others
        MyCSTSlotInfo.nRWKFLAG(nPortNo, nSlotNo) = nfirstWord
        MyCSTSlotInfo.nSCRPFLAG(nPortNo, nSlotNo) = nSecondWord
        MyCSTSlotInfo.nFIRMFLAG(nPortNo, nSlotNo) = nThirdWord
    End Sub

    Private Sub ReadRD_DG_GG_Grade(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nVaule As Integer)
        Dim strHexData As String = ""
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0

        strHexData = HexLeadZero(nVaule)
        Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
        MyCSTSlotInfo.nGGRADE(nPortNo, nSlotNo) = nfirstWord
        MyCSTSlotInfo.nDGRADE(nPortNo, nSlotNo) = nSecondWord
        MyCSTSlotInfo.nRDRAGE(nPortNo, nSlotNo) = nThirdWord
    End Sub


    '-----------------------------------------------------

    Private Sub ReadFIRM_SCRP_RWK_FLAG1(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nVaule As Integer)
        Dim strHexData As String = ""
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0

        strHexData = HexLeadZero(nVaule)
        Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)

        'r->1:MarkedRework,2:NormalGlass,s->1:MarkedScrap,2:MarkedRecycled,f->1:Marked for FI-Macro used,2:Others
        MySlotInfo.nRWKFLAG(nPortNo, nSlotNo) = nfirstWord
        MySlotInfo.nSCRPFLAG(nPortNo, nSlotNo) = nSecondWord
        MySlotInfo.nFIRMFLAG(nPortNo, nSlotNo) = nThirdWord
    End Sub

    Private Sub ReadRD_DG_GG_Grade1(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nVaule As Integer)
        Dim strHexData As String = ""
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0

        strHexData = HexLeadZero(nVaule)
        Call GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
        MySlotInfo.nGGRADE(nPortNo, nSlotNo) = nfirstWord
        MySlotInfo.nDGRADE(nPortNo, nSlotNo) = nSecondWord
        MySlotInfo.nRDRAGE(nPortNo, nSlotNo) = nThirdWord
    End Sub

#End Region

#Region "RST IF Events"
    Private Sub CheckRobotCommandError()
        If MyRSTOldWord.mnRobotCommandErrorLog <> MyRSTNewWord.mnRobotCommandErrorLog Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Command Error Report changed from " & MyRSTOldWord.mnRobotCommandErrorLog & " -> " & MyRSTNewWord.mnRobotCommandErrorLog)

            If MyRSTNewWord.mnRobotCommandErrorLog = SIGNAL_ON Then
                ReadRobotCommandError()
                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Command Error Code=" & MyRSTNewWord.mnRSTErrorCase.ToString & " ,Arm=" & MyRSTNewWord.mnRSTArm.ToString & " ,Position=" & MyRSTNewWord.mnPosition & " ,SlotNo=" & MyRSTNewWord.mnSlotNo & " ,Target=" & MyRSTNewWord.mnTarget.ToString _
                         & " ,JobNo=" & MyRSTNewWord.mnJobNo.ToString & " ,CMD=" & MyRSTNewWord.mnCMD.ToString & " ,Action=" & MyRSTNewWord.mnAction.ToString & " ,Handshake=" & MyRSTNewWord.mnHandshake)
            End If
            MyRSTOldWord.mnRobotCommandErrorLog = MyRSTNewWord.mnRobotCommandErrorLog
        End If
    End Sub

    Private Sub CheckRobotStandBy()
        'Get Prepare Status 1:Enable
        If MyRSTOldWord.mnRobotStandBy <> MyRSTNewWord.mnRobotStandBy Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot StandBy changed from " & MyRSTOldWord.mnRobotStandBy & " -> " & MyRSTNewWord.mnRobotStandBy)

            If MyRSTNewWord.mnRobotStandBy = SIGNAL_ON Then
                RaiseEvent RobotStandBy(True)
            Else
                RaiseEvent RobotStandBy(False)
            End If
            MyRSTOldWord.mnRobotStandBy = MyRSTNewWord.mnRobotStandBy
        End If
    End Sub

    Private Sub CheckRobotInitialRequest()
        If MyRSTOldWord.mnRobotInitialRequest <> MyRSTNewWord.mnRobotInitialRequest Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Initial Request Change[Start/Stop] changed from " & MyRSTOldWord.mnRobotInitialRequest & " -> " & MyRSTNewWord.mnRobotInitialRequest)

            If MyRSTNewWord.mnRobotInitialRequest = SIGNAL_ON Then
                RaiseEvent RobotRobotInitialRequest()
            End If
            MyRSTOldWord.mnRobotInitialRequest = MyRSTNewWord.mnRobotInitialRequest
        End If
    End Sub

    Private Sub CheckRobotActionCommmandChange()

        If MyRSTOldWord.mnRobotStartCommand <> MyRSTNewWord.mnRobotStartCommand Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot ActionCommand Change[Start/Stop] changed from " & MyRSTOldWord.mnRobotStartCommand & " -> " & MyRSTNewWord.mnRobotStartCommand)

            If MyRSTNewWord.mnRobotStartCommand = SIGNAL_ON Then
                RaiseEvent RobotActionCommmandChange(eRSTCommandMode.START)
            Else
                RaiseEvent RobotActionCommmandChange(eRSTCommandMode.STOP)
            End If
            MyRSTOldWord.mnRobotStartCommand = MyRSTNewWord.mnRobotStartCommand
        End If

    End Sub

    Private Sub CheckRobotStart()
        If MyRSTOldWord.mnRobotStart <> MyRSTNewWord.mnRobotStart Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Motion Start changed from " & MyRSTOldWord.mnRobotStart & " -> " & MyRSTNewWord.mnRobotStart)

            If MyRSTNewWord.mnRobotStart = SIGNAL_ON Then
                ReadRobotActionCommand()

                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Motion Start ,Target=" & MyRSTNewWord.mnRSTStartTarget.ToString & " ,Arm=" & MyRSTNewWord.mnRSTStartArm.ToString & " ,CMD=" & MyRSTNewWord.mnRSTStartCMD.ToString & " ,Action=" & MyRSTNewWord.mnRSTStartAction.ToString & " ,Position=" & MyRSTNewWord.mnRSTStartPosition & " ,BufferSlot=" & MyRSTNewWord.mnRSTStartSlot & " ,Handshake=" & MyRSTNewWord.mnRSTStartHandshake)

                RaiseEvent RobotMotionStart(MyRSTNewWord.mnRSTStartTarget, MyRSTNewWord.mnRSTStartArm, MyRSTNewWord.mnRSTStartCMD, MyRSTNewWord.mnRSTStartAction, MyRSTNewWord.mnRSTStartPosition, MyRSTNewWord.mnRSTStartSlot)
            End If

            MyRSTOldWord.mnRobotStart = MyRSTNewWord.mnRobotStart
        End If
    End Sub

    Private Sub CheckRobotStartComplete()
        If MyRSTOldWord.mnRobotStartComplete <> MyRSTNewWord.mnRobotStartComplete Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot MotionStartComplete changed from " & MyRSTOldWord.mnRobotStartComplete & " -> " & MyRSTNewWord.mnRobotStartComplete)

            If MyRSTNewWord.mnRobotStartComplete = SIGNAL_ON Then
                ReadRobotActionCommand()

                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot MotionStartComplete ,Target=" & MyRSTNewWord.mnRSTStartTarget.ToString & " ,Arm=" & MyRSTNewWord.mnRSTStartArm.ToString & " ,CMD=" & MyRSTNewWord.mnRSTStartCMD.ToString & " ,Action=" & MyRSTNewWord.mnRSTStartAction.ToString & " ,Position=" & MyRSTNewWord.mnRSTStartPosition & " ,BufferSlot=" & MyRSTNewWord.mnRSTStartSlot & " ,Handshake=" & MyRSTNewWord.mnRSTStartHandshake)

                RaiseEvent RobotMotionStartComplete(MyRSTNewWord.mnRSTStartTarget, MyRSTNewWord.mnRSTStartArm, MyRSTNewWord.mnRSTStartCMD, MyRSTNewWord.mnRSTStartAction, MyRSTNewWord.mnRSTStartPosition, MyRSTNewWord.mnRSTStartSlot)
            End If

            MyRSTOldWord.mnRobotStartComplete = MyRSTNewWord.mnRobotStartComplete
        End If
    End Sub

    Private Sub CheckUpperArmGlassExist()
        Dim strGlassID As String = ""
        'Dim nFor As Integer
        Dim nGlassID(5) As Integer

        If MyRSTOldWord.mnArmUpperGlassExist <> MyRSTNewWord.mnArmUpperGlassExist Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot UpperArm WithGlass changed from " & MyRSTOldWord.mnArmUpperGlassExist & " -> " & MyRSTNewWord.mnArmUpperGlassExist)
            If MyRSTNewWord.mnArmUpperGlassExist = SIGNAL_ON Then

                'ReadZRAddr(UPPER_ARM_GXID_ADDR_W1, nGlassID)
                'For nFor = 0 To 5
                '    strGlassID = strGlassID & ConvertHiLowASCIIToString(nGlassID(nFor))
                'Next

                strGlassID = GetArmGxInfo(eRSTArm.ARM_UPPER)
                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "UpperArm GlassID = " & strGlassID)
                RaiseEvent RSTArmWithGlass(eRSTArm.ARM_UPPER, True, strGlassID)
            Else
                RaiseEvent RSTArmWithGlass(eRSTArm.ARM_UPPER, False, "")
            End If

            MyRSTOldWord.mnArmUpperGlassExist = MyRSTNewWord.mnArmUpperGlassExist
        End If
    End Sub

    Private Sub CheckLowerArmGlassExist()
        Dim strGlassID As String = ""
        'Dim nFor As Integer
        Dim nGlassID(5) As Integer

        If MyRSTOldWord.mnArmLowerGlassExist <> MyRSTNewWord.mnArmLowerGlassExist Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot LowerArm WithGlass changed from " & MyRSTOldWord.mnArmLowerGlassExist & " -> " & MyRSTNewWord.mnArmLowerGlassExist)

            If MyRSTNewWord.mnArmLowerGlassExist = SIGNAL_ON Then
                'ReadZRAddr(LOWER_ARM_GXID_ADDR_W1, nGlassID)
                'For nFor = 0 To 5
                '    strGlassID = strGlassID & ConvertHiLowASCIIToString(nGlassID(nFor))
                'Next

                strGlassID = GetArmGxInfo(eRSTArm.ARM_LOWER)
                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "LowerArm GlassID = " & strGlassID)
                RaiseEvent RSTArmWithGlass(eRSTArm.ARM_LOWER, True, strGlassID)
            Else
                RaiseEvent RSTArmWithGlass(eRSTArm.ARM_LOWER, False, "")
            End If

            MyRSTOldWord.mnArmLowerGlassExist = MyRSTNewWord.mnArmLowerGlassExist
        End If
    End Sub

    Private Sub CheckRSTStatus()

        If MyRSTOldWord.mnRobotStatus <> MyRSTNewWord.mnRobotStatus Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Status changed from " & MyRSTOldWord.mnRobotStatus.ToString & " -> " & MyRSTNewWord.mnRobotStatus.ToString)

            RaiseEvent RobotStatusChange(MyRSTNewWord.mnRobotStatus)
            MyRSTOldWord.mnRobotStatus = MyRSTNewWord.mnRobotStatus
        End If
    End Sub

    Private Sub RobotPauseAck()
        If MyRSTOldWord.mnRobotPauseAck <> MyRSTNewWord.mnRobotPauseAck Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Pause Ack ok changed from " & MyRSTOldWord.mnRobotPauseAck & " -> " & MyRSTNewWord.mnRobotPauseAck)

            If MyRSTNewWord.mnRobotPauseAck = SIGNAL_ON Then
                DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Pause Request Off")
                Call WriteMAddr(MyRSTMAddr.mnRobotPauseRequest, False)
            End If
            MyRSTOldWord.mnRobotPauseAck = MyRSTNewWord.mnRobotPauseAck
        End If
    End Sub

    Private Sub ResumeRequestAck()
        If MyRSTOldWord.mnRobotResumeAck <> MyRSTNewWord.mnRobotResumeAck Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot ResumeAck ok changed from " & MyRSTOldWord.mnRobotResumeAck & " -> " & MyRSTNewWord.mnRobotResumeAck)

            If MyRSTNewWord.mnRobotResumeAck = SIGNAL_ON Then
                DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Resume Request Off")
                Call WriteMAddr(MyRSTMAddr.mnRobotResumeRequest, False)
            End If
            MyRSTOldWord.mnRobotResumeAck = MyRSTNewWord.mnRobotResumeAck
        End If
    End Sub

    Private Sub CheckRSTAlarm()
        Dim nFor As Integer
        Dim i As Integer
        Dim nIndex As Integer
        Dim anBit(MAX_BIT) As Short

        For nFor = 1 To RST_ALARM_WORD_LEN
            If MyRSTOldWord.mnRSTAlarmWord(nFor) <> MyRSTNewWord.mnRSTAlarmWord(nFor) Then
                WordConvertToBin(MyRSTNewWord.mnRSTAlarmWord(nFor), anBit)

                For i = 0 To MAX_BIT
                    nIndex = (i + 1) + (16 * (nFor - 1)) '1~304 Alarm
                    MyRSTNewWord.mnRSTAlarm(nIndex) = anBit(i)
                Next
                MyRSTOldWord.mnRSTAlarmWord(nFor) = MyRSTNewWord.mnRSTAlarmWord(nFor)
            End If
        Next

        For nFor = 1 To MAX_RST_ALARM_CODE
            If MyRSTOldWord.mnRSTAlarm(nFor) <> MyRSTNewWord.mnRSTAlarm(nFor) Then
                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "RST Alarm Code=" & nFor & " ,Alarm Signal changed  from " & MyRSTOldWord.mnRSTAlarm(nFor) & " -> " & MyRSTNewWord.mnRSTAlarm(nFor))

                RaiseEvent RSTAlarm(IIf(MyRSTNewWord.mnRSTAlarm(nFor) = SIGNAL_ON, True, False), nFor)
                MyRSTOldWord.mnRSTAlarm(nFor) = MyRSTNewWord.mnRSTAlarm(nFor)
            End If
        Next

    End Sub

    Private Sub CheckRobotAlarm()
        Dim nFor As Integer
        Dim i As Integer
        Dim nIndex As Integer
        Dim anBit(MAX_BIT) As Short

        For nFor = 1 To ROBOT_ALARM_WORD_LEN
            If MyRSTOldWord.mnRobotAlarmWord(nFor) <> MyRSTNewWord.mnRobotAlarmWord(nFor) Then
                WordConvertToBin(MyRSTNewWord.mnRobotAlarmWord(nFor), anBit)

                For i = 0 To MAX_BIT
                    nIndex = (i + 1) + (16 * (nFor - 1)) '1~48 Alarm
                    MyRSTNewWord.mnRobotAlarm(nIndex) = anBit(i)
                Next
                MyRSTOldWord.mnRobotAlarmWord(nFor) = MyRSTNewWord.mnRobotAlarmWord(nFor)
            End If
        Next

        For nFor = 1 To MAX_ROBOT_ALARM_CODE
            If MyRSTOldWord.mnRobotAlarm(nFor) <> MyRSTNewWord.mnRobotAlarm(nFor) Then
                DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "RobotAlarmCode=" & nFor & " ,Alarm Signal changed  from " & MyRSTOldWord.mnRobotAlarm(nFor) & " -> " & MyRSTNewWord.mnRobotAlarm(nFor))

                RaiseEvent RobotAlarm(IIf(MyRSTNewWord.mnRobotAlarm(nFor) = SIGNAL_ON, True, False), nFor)
                MyRSTOldWord.mnRobotAlarm(nFor) = MyRSTNewWord.mnRobotAlarm(nFor)
            End If
        Next

    End Sub


    Private Sub CheckRobotActualStatus()

        If MyRSTOldWord.mnUpArmSensor <> MyRSTNewWord.mnUpArmSensor Then
            If MyRSTNewWord.mnUpArmSensor = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.UP_ARM_SENSOR, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.UP_ARM_SENSOR, False)
            End If
            MyRSTOldWord.mnUpArmSensor = MyRSTNewWord.mnUpArmSensor
        End If

        '-----------------------------------------------------------------------
        If MyRSTOldWord.mnLowArmSensor <> MyRSTNewWord.mnLowArmSensor Then
            If MyRSTNewWord.mnLowArmSensor = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.LOW_ARM_SENSOR, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.LOW_ARM_SENSOR, False)
            End If
            MyRSTOldWord.mnLowArmSensor = MyRSTNewWord.mnLowArmSensor
        End If

        '-----------------------------------------------------------------------
        If MyRSTOldWord.mnUpArmVaccum <> MyRSTNewWord.mnUpArmVaccum Then
            If MyRSTNewWord.mnUpArmVaccum = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.UP_ARM_VACCUM, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.UP_ARM_VACCUM, False)
            End If
            MyRSTOldWord.mnUpArmVaccum = MyRSTNewWord.mnUpArmVaccum
        End If

        '-----------------------------------------------------------------------
        If MyRSTOldWord.mnLowArmVaccum <> MyRSTNewWord.mnLowArmVaccum Then
            If MyRSTNewWord.mnLowArmVaccum = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.LOW_ARM_VACCUM, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.LOW_ARM_VACCUM, False)
            End If
            MyRSTOldWord.mnLowArmVaccum = MyRSTNewWord.mnLowArmVaccum
        End If

        '-----------------------------------------------------------------------
        If MyRSTOldWord.mnRSTServoOn <> MyRSTNewWord.mnRSTServoOn Then
            If MyRSTNewWord.mnRSTServoOn = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.SERVO_ON, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.SERVO_ON, False)
            End If
            MyRSTOldWord.mnRSTServoOn = MyRSTNewWord.mnRSTServoOn
        End If

        '-----------------------------------------------------------------------
        If MyRSTOldWord.mnRSTReady <> MyRSTNewWord.mnRSTReady Then
            If MyRSTNewWord.mnRSTReady = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.READY, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.READY, False)
            End If
            MyRSTOldWord.mnRSTReady = MyRSTNewWord.mnRSTReady
        End If

        '-----------------------------------------------------------------------
        If MyRSTOldWord.mnCMDBusy <> MyRSTNewWord.mnCMDBusy Then
            If MyRSTNewWord.mnCMDBusy = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.CMD_BUSY, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.CMD_BUSY, False)
            End If
            MyRSTOldWord.mnCMDBusy = MyRSTNewWord.mnCMDBusy
        End If

        '-----------------------------------------------------------------------
        If MyRSTOldWord.mnForkExtend <> MyRSTNewWord.mnForkExtend Then
            If MyRSTNewWord.mnForkExtend = SIGNAL_ON Then
                RaiseEvent RobotIOInput(eRobotActualStatus.FORK_EXTEND, True)
            Else
                RaiseEvent RobotIOInput(eRobotActualStatus.FORK_EXTEND, False)
            End If
            MyRSTOldWord.mnForkExtend = MyRSTNewWord.mnForkExtend
        End If

    End Sub

    Private Sub CheckRSTAlive()
        If MyRSTOldWord.mnRSTAlive <> MyRSTNewWord.mnRSTAlive Then
            'DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Alive changed from " & MyRSTOldWord.mnRSTAlive & " -> " & MyRSTNewWord.mnRSTAlive)
            If MyRSTNewWord.mnRSTAlive = SIGNAL_ON Then
                'DebugLog(eIFIndex.INDEX_RST, eLogType.[SYS], "Robot CPC Alive On")
                Call WriteMAddr(MyRSTMAddr.mnCPCAlive, True)
            Else
                'DebugLog(eIFIndex.INDEX_RST, eLogType.[SYS], "Robot CPC Alive Off")
                Call WriteMAddr(MyRSTMAddr.mnCPCAlive, False)
            End If

            'm_fRSTAlive = True
            MyRSTOldWord.mnRSTAlive = MyRSTNewWord.mnRSTAlive
        End If
    End Sub

    Private Sub RSTModeChange()
        'ZR 909
        If MyRSTOldWord.mnAutomode <> MyRSTNewWord.mnAutomode Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Auto Mode changed from " & MyRSTOldWord.mnAutomode & " -> " & MyRSTNewWord.mnAutomode)
            If MyRSTNewWord.mnAutomode = SIGNAL_ON Then
                RaiseEvent RobotModeChange(eRSTMode.AUTO)
            End If
            MyRSTOldWord.mnAutomode = MyRSTNewWord.mnAutomode
        End If

        If MyRSTOldWord.mnManualmode <> MyRSTNewWord.mnManualmode Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Manual Mode changed from " & MyRSTOldWord.mnManualmode & " -> " & MyRSTNewWord.mnManualmode)
            If MyRSTNewWord.mnManualmode = SIGNAL_ON Then
                RaiseEvent RobotModeChange(eRSTMode.MANUAL)
            End If
            MyRSTOldWord.mnManualmode = MyRSTNewWord.mnManualmode
        End If

        If MyRSTOldWord.mnEngineerMode <> MyRSTNewWord.mnEngineerMode Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Engineer Mode changed from " & MyRSTOldWord.mnEngineerMode & " -> " & MyRSTNewWord.mnEngineerMode)
            If MyRSTNewWord.mnEngineerMode = SIGNAL_ON Then
                RaiseEvent RobotModeChange(eRSTMode.ENGINEER)
            End If
            MyRSTOldWord.mnEngineerMode = MyRSTNewWord.mnEngineerMode
        End If
    End Sub

    Private Sub RSTCmdAck()
        If MyRSTOldWord.mnRobotCommandAck <> MyRSTNewWord.mnRobotCommandAck Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Command ack ok changed from " & MyRSTOldWord.mnRobotCommandAck & " -> " & MyRSTNewWord.mnRobotCommandAck)
            If MyRSTNewWord.mnRobotCommandAck = SIGNAL_ON Then
                RaiseEvent RobotCommandAck()
                'DebugLog(eIFIndex.INDEX_RST, eLogType.[SYS], "Robot Start Off")
                'Call WriteMAddr(MyRSTMAddr.mnRobotStart, False)
            End If
            MyRSTOldWord.mnRobotCommandAck = MyRSTNewWord.mnRobotCommandAck
        End If

        If MyRSTOldWord.mnRobotManualComplete <> MyRSTNewWord.mnRobotManualComplete Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Manual Command Complete changed from " & MyRSTOldWord.mnRobotManualComplete & " -> " & MyRSTNewWord.mnRobotManualComplete)

            If MyRSTNewWord.mnRobotManualComplete = SIGNAL_ON Then
                RaiseEvent RobotManualComplete()
                'DebugLog(eIFIndex.INDEX_RST, eLogType.[SYS], "Robot Start Off")
                'Call WriteMAddr(MyRSTMAddr.mnRobotStart, False)
            End If
            MyRSTOldWord.mnRobotManualComplete = MyRSTNewWord.mnRobotManualComplete
        End If
    End Sub

    Private Sub RSTCmdPossible()
        If MyRSTOldWord.mnRobotcommandPossible <> MyRSTNewWord.mnRobotcommandPossible Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Command Possible changed from " & MyRSTOldWord.mnRobotcommandPossible & " -> " & MyRSTNewWord.mnRobotcommandPossible)

            If MyRSTNewWord.mnRobotcommandPossible = SIGNAL_ON Then
                mvarRSTCommandPossible = True
            Else
                mvarRSTCommandPossible = False
            End If
            MyRSTOldWord.mnRobotcommandPossible = MyRSTNewWord.mnRobotcommandPossible
            RaiseEvent RobotCommandPossible(mvarRSTCommandPossible)
        End If
    End Sub

    Private Sub CheckTraceLogCount()
        If MyRSTOldWord.mnRobotTraceDataCount <> MyRSTNewWord.mnRobotTraceDataCount Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot TraceData Log Count changed from " & MyRSTOldWord.mnRobotTraceDataCount & " -> " & MyRSTNewWord.mnRobotTraceDataCount)

            If MyRSTNewWord.mnRobotTraceDataCount > 0 Then
                WriteTraceDataFunLog(MyRSTNewWord.mnRobotTraceDataCount)

                DebugLog(eIFIndex.INDEX_RST, eLogType.[SYS], "Robot TraceData Log Count = 0")
                Call WriteZRAddr(MyRSTZRAddr.RobotResetTracedataLogCount, 0)
            End If
            MyRSTOldWord.mnRobotTraceDataCount = MyRSTNewWord.mnRobotTraceDataCount
        End If
    End Sub

    Private Sub CheckInterfaceLogCount()
        If MyRSTOldWord.mnRobotInterfaceLogCount <> MyRSTNewWord.mnRobotInterfaceLogCount Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Robot Interface Log Count changed from " & MyRSTOldWord.mnRobotInterfaceLogCount & " -> " & MyRSTNewWord.mnRobotInterfaceLogCount)

            If MyRSTNewWord.mnRobotInterfaceLogCount > 0 Then
                'Write ini
                WriteInterfaceLogData(MyRSTNewWord.mnRobotInterfaceLogCount)

                DebugLog(eIFIndex.INDEX_RST, eLogType.[SYS], "Robot Interface Log Count = 0")
                Call WriteZRAddr(MyRSTZRAddr.RobotInterfaceLogCount, 0)
            End If
            MyRSTOldWord.mnRobotInterfaceLogCount = MyRSTNewWord.mnRobotInterfaceLogCount
        End If
    End Sub

    Private Sub CheckTimeoutFunction()
        If MyRSTOldWord.mnCheckTimeoutFun <> MyRSTNewWord.mnCheckTimeoutFun Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "Timeout Count changed from " & MyRSTOldWord.mnCheckTimeoutFun & " -> " & MyRSTNewWord.mnCheckTimeoutFun)

            If MyRSTNewWord.mnCheckTimeoutFun > 0 Then
                WriteTimeoutFunLog(MyRSTNewWord.mnCheckTimeoutFun)

                DebugLog(eIFIndex.INDEX_RST, eLogType.[SYS], "Timeout Log Count = 0")
                Call WriteZRAddr(MyRSTZRAddr.RobotTimeoutCount, 0)
            End If
            MyRSTOldWord.mnCheckTimeoutFun = MyRSTNewWord.mnCheckTimeoutFun
        End If
    End Sub

    Private Sub CheckBufferPortGxInfo()
        Dim nPortIdx As Integer
        Dim nSlotNo As Integer

        For nPortIdx = 1 To MAX_BUFFER_PORT
            For nSlotNo = 1 To MAX_BUFFER_SLOT
                If MyRSTOldWord.mnBufferPortGxExist(nPortIdx, nSlotNo) <> MyRSTNewWord.mnBufferPortGxExist(nPortIdx, nSlotNo) Then
                    DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "RST Buffer Port[" & nPortIdx & "] ,SlotNo=" & nSlotNo & " ,Glass Info  changed  from " & MyRSTOldWord.mnBufferPortGxExist(nPortIdx, nSlotNo) & " -> " & MyRSTNewWord.mnBufferPortGxExist(nPortIdx, nSlotNo))

                    If MyRSTNewWord.mnBufferPortGxExist(nPortIdx, nSlotNo) = SIGNAL_ON Then
                        RaiseEvent RSTBufferPortGlassInfoChange(nPortIdx, nSlotNo, True)
                    Else
                        RaiseEvent RSTBufferPortGlassInfoChange(nPortIdx, nSlotNo, False)
                    End If
                    MyRSTOldWord.mnBufferPortGxExist(nPortIdx, nSlotNo) = MyRSTNewWord.mnBufferPortGxExist(nPortIdx, nSlotNo)
                End If
            Next
        Next
    End Sub

    Private Sub CheckBufferDisable()
        Dim nPortIdx As Integer
        Dim nSlotNo As Integer

        For nPortIdx = 1 To 3
            For nSlotNo = 1 To MAX_BUFFER_SLOT
                If MyRSTOldWord.mnBufferDisable(nPortIdx, nSlotNo) <> MyRSTNewWord.mnBufferDisable(nPortIdx, nSlotNo) Then
                    DebugLog(eIFIndex.INDEX_RST, eLogType.[EVENT], "RST Buffer[" & nPortIdx & "] ,SlotNo=" & nSlotNo & " ,Disable changed  from " & MyRSTOldWord.mnBufferDisable(nPortIdx, nSlotNo) & " -> " & MyRSTNewWord.mnBufferDisable(nPortIdx, nSlotNo))
                    If MyRSTNewWord.mnBufferDisable(nPortIdx, nSlotNo) = SIGNAL_ON Then
                        mvarBufferDisable(nPortIdx, nSlotNo) = True
                        RaiseEvent RSTBufferDisable(nPortIdx, nSlotNo, True)
                    Else
                        mvarBufferDisable(nPortIdx, nSlotNo) = False
                        RaiseEvent RSTBufferDisable(nPortIdx, nSlotNo, False)
                    End If

                    MyRSTOldWord.mnBufferDisable(nPortIdx, nSlotNo) = MyRSTNewWord.mnBufferDisable(nPortIdx, nSlotNo)
                End If
            Next
        Next
    End Sub

#End Region

#Region "EQ IF Events"

    Private Sub CheckEQWithGlassID()
        Dim nFor As Integer
        Dim strGlassID As String = ""

        For nFor = 1 To MAX_EQ
            If MyRSTOldWord.mnEQWithGlassID(nFor) <> MyRSTNewWord.mnEQWithGlassID(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Glass Data changed from " & MyRSTOldWord.mnEQWithGlassID(nFor) & " -> " & MyRSTNewWord.mnEQWithGlassID(nFor))

                If MyRSTNewWord.mnEQWithGlassID(nFor) = SIGNAL_ON Then
                    strGlassID = ReadEQGlassID(nFor)
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "],GlassID=[ " & strGlassID & "]")

                    RaiseEvent EQGlassDataChange(nFor, strGlassID)

                    'mvarEQWithGlass(nFor) = True
                    'RaiseEvent EQGlassExistChanged(nFor, True)
                Else

                    RaiseEvent EQGlassDataChange(nFor, "")

                    'mvarEQWithGlass(nFor) = False
                    'RaiseEvent EQGlassExistChanged(nFor, False)

                End If

                MyRSTOldWord.mnEQWithGlassID(nFor) = MyRSTNewWord.mnEQWithGlassID(nFor)
            End If
        Next
    End Sub

    Private Sub CheckEQStageGlassDataExist()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQStageGlassDataExist(nFor) <> MyEQNewWord.mnEQStageGlassDataExist(nFor) Then
                'ZR 700 701
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Glass Data Exist changed from " & MyEQOldWord.mnEQStageGlassDataExist(nFor) & " -> " & MyEQNewWord.mnEQStageGlassDataExist(nFor))

                If MyEQNewWord.mnEQStageGlassDataExist(nFor) = SIGNAL_ON Then
                Else
                    If MyCheckDeleteEQGlassDataFlag(nFor) Then
                        RaiseEvent RSTDeltetEQGlassDataComplete(nFor, eEQGlassInfoDeleteResult.Success)

                        DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] RST Delete Stage Glass Data Off")
                        WriteMAddr(MyEQMAddr.m_nEQDeleteStageGxData(nFor), False)

                        MyCheckDeleteEQGlassDataFlag(nFor) = False
                    End If
                End If
                MyEQOldWord.mnEQStageGlassDataExist(nFor) = MyEQNewWord.mnEQStageGlassDataExist(nFor)
            End If
        Next

    End Sub

    Private Sub CheckEQAlarm()
        Dim nFor As Integer
        Dim i As Integer
        Dim j
        Dim anBit(MAX_BIT) As Short
        Dim nEQAlarmIndex As Integer

        For nFor = 1 To MAX_EQ
            For i = 1 To EQ_ALARM_WORD_LEN

                If MyEQOldWord.mnEQAlarmWord(nFor, i) <> MyEQNewWord.mnEQAlarmWord(nFor, i) Then
                    WordConvertToBin(MyEQNewWord.mnEQAlarmWord(nFor, i), anBit)

                    For j = 0 To MAX_BIT
                        nEQAlarmIndex = (j + 1) + (16 * (i - 1)) '1~512 Alarm
                        MyEQNewWord.mnEQAlarm(nFor, nEQAlarmIndex) = anBit(j)
                    Next

                    MyEQOldWord.mnEQAlarmWord(nFor, i) = MyEQNewWord.mnEQAlarmWord(nFor, i)
                End If
            Next
            nEQAlarmIndex = 0
        Next

        For nFor = 1 To MAX_EQ
            For i = 1 To MAX_CV_ALARM_CODE
                If MyEQOldWord.mnEQAlarm(nFor, i) <> MyEQNewWord.mnEQAlarm(nFor, i) Then
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] ,EQ Alarm Code=" & i & " ,Alarm Signal changed  from " & MyEQOldWord.mnEQAlarm(nFor, i) & " -> " & MyEQNewWord.mnEQAlarm(nFor, i))

                    RaiseEvent EQAlarm(nFor, IIf(MyEQNewWord.mnEQAlarm(nFor, i) = SIGNAL_ON, True, False), i)
                    MyEQOldWord.mnEQAlarm(nFor, i) = MyEQNewWord.mnEQAlarm(nFor, i)
                End If
            Next
        Next

    End Sub

    Private Sub CheckAlarmOccured()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnAlarmOccured(nFor) <> MyEQNewWord.mnAlarmOccured(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Alarm Occured changed from " & MyEQOldWord.mnAlarmOccured(nFor) & " -> " & MyEQNewWord.mnAlarmOccured(nFor))
                MyEQOldWord.mnAlarmOccured(nFor) = MyEQNewWord.mnAlarmOccured(nFor)
            End If
        Next
    End Sub

    Private Sub CheckEQMPAStop()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQMPA1Stop(nFor) <> MyEQNewWord.mnEQMPA1Stop(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] MPA1Stop changed from " & MyEQOldWord.mnEQMPA1Stop(nFor) & " -> " & MyEQNewWord.mnEQMPA1Stop(nFor))
                If MyEQNewWord.mnEQMPA1Stop(nFor) = SIGNAL_ON Then
                    'RaiseEvent EQMPAStop(nFor, 1, True)
                Else
                    'RaiseEvent EQMPAStop(nFor, 1, False)
                End If
            End If
            MyEQOldWord.mnEQMPA1Stop(nFor) = MyEQNewWord.mnEQMPA1Stop(nFor)

            If MyEQOldWord.mnMPA2Stop(nFor) <> MyEQNewWord.mnMPA2Stop(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] MPA2Stop changed from " & MyEQOldWord.mnMPA2Stop(nFor) & " -> " & MyEQNewWord.mnMPA2Stop(nFor))
                If MyEQNewWord.mnMPA2Stop(nFor) = SIGNAL_ON Then
                    'RaiseEvent EQMPAStop(nFor, 2, True)
                Else
                    'RaiseEvent EQMPAStop(nFor, 2, False)
                End If
                MyEQOldWord.mnMPA2Stop(nFor) = MyEQNewWord.mnMPA2Stop(nFor)
            End If

        Next
    End Sub

    Private Sub CheckEQInterlock()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQInterlock(nFor) <> MyEQNewWord.mnEQInterlock(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Interlock changed from " & MyEQOldWord.mnEQInterlock(nFor) & " -> " & MyEQNewWord.mnEQInterlock(nFor))
                If MyEQNewWord.mnEQInterlock(nFor) = SIGNAL_ON Then
                    RaiseEvent EQHandOffChanged(nFor, True)
                    g_fEQInterlock(nFor) = True
                Else
                    RaiseEvent EQHandOffChanged(nFor, False)
                    g_fEQInterlock(nFor) = False
                End If
                MyEQOldWord.mnEQInterlock(nFor) = MyEQNewWord.mnEQInterlock(nFor)
            End If
        Next
    End Sub

    Private Sub CheckEQHandOffChanged()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQHandoff(nFor) <> MyEQNewWord.mnEQHandoff(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Handoff available changed from " & MyEQOldWord.mnEQHandoff(nFor) & " -> " & MyEQNewWord.mnEQHandoff(nFor))
                If MyEQNewWord.mnEQHandoff(nFor) = SIGNAL_ON Then
                    'RaiseEvent EQHandOffChanged(nFor, True)
                Else
                    'RaiseEvent EQHandOffChanged(nFor, False)
                End If
                MyEQOldWord.mnEQHandoff(nFor) = MyEQNewWord.mnEQHandoff(nFor)
            End If
        Next
    End Sub

    Private Sub CheckEQInProcess()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQInprocess(nFor) <> MyEQNewWord.mnEQInprocess(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] glass In process changed from " & MyEQOldWord.mnEQInprocess(nFor) & " -> " & MyEQNewWord.mnEQInprocess(nFor))
                If MyEQNewWord.mnEQInprocess(nFor) = SIGNAL_ON Then
                    RaiseEvent EQInProcess(nFor, True)
                Else
                    RaiseEvent EQInProcess(nFor, False)
                End If
                MyEQOldWord.mnEQInprocess(nFor) = MyEQNewWord.mnEQInprocess(nFor)
            End If
        Next
    End Sub

    'Private Sub CheckEQWithGlass()
    '    Dim nFor As Integer
    '    Dim strGlassID As String

    '    For nFor = 1 To MAX_EQ
    '        If MyRSTOldWord.mstrEQWithGXID(nFor) <> MyRSTNewWord.mstrEQWithGXID(nFor) Then
    '            strGlassID = MyStringTrim(MyRSTNewWord.mstrEQWithGXID(nFor))

    '            If Len(strGlassID) > 0 Then
    '                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ Index[" & nFor & "] WithGlass changed from True")
    '                'mvarEQWithGlass(nFor) = True
    '                'RaiseEvent EQGlassExistChanged(nFor, True)
    '            Else
    '                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ Index[" & nFor & "] WithGlass changed from False")
    '                'mvarEQWithGlass(nFor) = False
    '                'RaiseEvent EQGlassExistChanged(nFor, False)
    '            End If

    '            MyRSTOldWord.mstrEQWithGXID(nFor) = MyRSTNewWord.mstrEQWithGXID(nFor)
    '        End If
    '    Next
    'End Sub

    Private Sub EQGlassExist()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQGlassExist(nFor) <> MyEQNewWord.mnEQGlassExist(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Glass exist on stage changed from " & MyEQOldWord.mnEQGlassExist(nFor) & " -> " & MyEQNewWord.mnEQGlassExist(nFor))

                If MyEQNewWord.mnEQGlassExist(nFor) = SIGNAL_ON Then
                    'If mvarEQWithGlass(nFor) Then
                    'Else
                    '    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Glass exist On stage")
                    '    mvarEQWithGlass(nFor) = True
                    '    RaiseEvent EQGlassExistChanged(nFor, True)
                    'End If
                    mvarEQWithGlass(nFor) = True
                    RaiseEvent EQGlassExistChanged(nFor, True)
                Else
                    'If MyRSTNewWord.mnEQWithGlassID(nFor) = SIGNAL_ON Then
                    'Else
                    '    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Glass exist Not stage")
                    '    mvarEQWithGlass(nFor) = False
                    '    RaiseEvent EQGlassExistChanged(nFor, False)
                    'End If
                    mvarEQWithGlass(nFor) = False
                    RaiseEvent EQGlassExistChanged(nFor, False)
                End If
                MyEQOldWord.mnEQGlassExist(nFor) = MyEQNewWord.mnEQGlassExist(nFor)
            End If
        Next
    End Sub

    Private Sub EQGlassDataResultReport()
        Dim nFor As Integer
        Dim nSampleGlassFlag As Integer
        Dim nSlotNo As Integer
        Dim nProcessResult As Integer
        Dim strPSHGroup As String = ""
        Dim strGlassID As String = ""
        Dim strChipGrade As String = ""

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQGlassDataResultReport(nFor) <> MyEQNewWord.mnEQGlassDataResultReport(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] GlassData Result Report changed from " & MyEQOldWord.mnEQGlassDataResultReport(nFor) & " -> " & MyEQNewWord.mnEQGlassDataResultReport(nFor))

                If MyEQNewWord.mnEQGlassDataResultReport(nFor) = SIGNAL_ON Then
                    nSampleGlassFlag = ReadProcessResultSampleGlassFlag(nFor)
                    nSlotNo = ReadProcessResultSlotNo(nFor)
                    nProcessResult = ReadProcessResult(nFor)
                    strPSHGroup = ReadProcessResultPSHGroup(nFor)
                    strGlassID = ReadProcessResultGlassID(nFor)
                    strChipGrade = ReadProcessResultChipGrade(nFor)

                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Result Report" & ",Glass ID[" & strGlassID & "] ,SampleGlassFlag=" & nSampleGlassFlag & " ,SlotNO=" & nSlotNo & " ,Process Result=" & nProcessResult & " ,PSH Group[" & strPSHGroup & "]")
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Result Report,Chip Grade=" & strChipGrade)
                    RaiseEvent EQProcessResult(nFor, nSampleGlassFlag, nSlotNo, nProcessResult, strChipGrade, strPSHGroup, strGlassID)

                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Glass Data Result Ack On")
                    Call WriteMAddr(MyEQMAddr.m_nEQGlassDataResultAck(nFor), True)
                Else
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Glass Data Result Ack Off")
                    Call WriteMAddr(MyEQMAddr.m_nEQGlassDataResultAck(nFor), False)
                End If
                MyEQOldWord.mnEQGlassDataResultReport(nFor) = MyEQNewWord.mnEQGlassDataResultReport(nFor)
            End If
        Next
    End Sub

    Private Sub EQStatusChange()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQStatus(nFor) <> MyEQNewWord.mnEQStatus(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "]  EQStatus changed from " & MyEQOldWord.mnEQStatus(nFor).ToString & " -> " & MyEQNewWord.mnEQStatus(nFor).ToString)

                mvarEQStatus(nFor) = MyEQNewWord.mnEQStatus(nFor)
                RaiseEvent EQStatusChanged(nFor, MyEQNewWord.mnEQStatus(nFor))
                MyEQOldWord.mnEQStatus(nFor) = MyEQNewWord.mnEQStatus(nFor)
            End If
        Next
    End Sub

    Private Sub EQRecipeModifiedReport()
        Dim nFor As Integer
        Dim strModifyRecipeID As String = ""
        Dim nRecipeModifyType As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQRecipeModifiedReport(nFor) <> MyEQNewWord.mnEQRecipeModifiedReport(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Recipe Modify Report changed from " & MyEQOldWord.mnEQRecipeModifiedReport(nFor) & " -> " & MyEQNewWord.mnEQRecipeModifiedReport(nFor))

                If MyEQNewWord.mnEQRecipeModifiedReport(nFor) = SIGNAL_ON Then
                    '0:None,1=Add ,2=Delete ,3=Modify Content
                    nRecipeModifyType = ReadModifyType(nFor)
                    strModifyRecipeID = ReadEQRecipeModifiyID(nFor)

                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Recipe Modify Type=" & nRecipeModifyType & " ,PPID=" & strModifyRecipeID)
                    RaiseEvent EQRecipeChanged(nFor, nRecipeModifyType, strModifyRecipeID)

                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Recipe Modify Report Ack On")
                    Call WriteMAddr(MyEQMAddr.m_nEQRecipeModifyReportAck(nFor), True)
                Else
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Recipe Modify Report Ack Off")
                    Call WriteMAddr(MyEQMAddr.m_nEQRecipeModifyReportAck(nFor), False)
                End If
                MyEQOldWord.mnEQRecipeModifiedReport(nFor) = MyEQNewWord.mnEQRecipeModifiedReport(nFor)
            End If
        Next
    End Sub

    Private Sub EQRecipeCheckReport()
        Dim nFor As Integer
        Dim nRecipeCheckResult As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQRecipeCheckReport(nFor) <> MyEQNewWord.mnEQRecipeCheckReport(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Recipe Check Report changed from " & MyEQOldWord.mnEQRecipeCheckReport(nFor) & " -> " & MyEQNewWord.mnEQRecipeCheckReport(nFor))

                If MyEQNewWord.mnEQRecipeCheckReport(nFor) = SIGNAL_ON Then
                    '0:None,1:RecipeExist,2:RecipeNoneExist
                    nRecipeCheckResult = ReadRecipeCheckResult(nFor)
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Recipe Check Result=" & nRecipeCheckResult)
                    RaiseEvent EQRecipeCheckResult(nFor, IIf(nRecipeCheckResult = 1, True, False), g_strRecipeCheckPPID(nFor))
                Else
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Recipe Check Request Off")
                    Call WriteMAddr(MyEQMAddr.m_nRecipeCheckRequest(nFor), False)
                End If
                MyEQOldWord.mnEQRecipeCheckReport(nFor) = MyEQNewWord.mnEQRecipeCheckReport(nFor)
            End If
        Next
    End Sub

    Private Sub EQRecipeQueryReport()
        Dim nFor As Integer
        Dim nReciperesult As Integer
        Dim nParameter(EQ_PARAMETER_LEN) As Integer
        'Dim i As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQRecipeParameterQuery(nFor) <> MyEQNewWord.mnEQRecipeParameterQuery(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Recipe Query Report changed from " & MyEQOldWord.mnEQRecipeParameterQuery(nFor) & " -> " & MyEQNewWord.mnEQRecipeParameterQuery(nFor))

                If MyEQNewWord.mnEQRecipeParameterQuery(nFor) = SIGNAL_ON Then
                    nParameter(1) = MyEQNewWord.mnEQParameterReport(nFor, 1)
                    nParameter(2) = MyEQNewWord.mnEQParameterReport(nFor, 2)
                    nParameter(3) = MyEQNewWord.mnEQParameterReport(nFor, 3)
                    nParameter(4) = MyEQNewWord.mnEQParameterReport(nFor, 4)
                    nParameter(5) = MyEQNewWord.mnEQParameterReport(nFor, 5)
                    nParameter(6) = MyEQNewWord.mnEQParameterReport(nFor, 6)
                    nParameter(7) = MyEQNewWord.mnEQParameterReport(nFor, 7)
                    nParameter(8) = MyEQNewWord.mnEQParameterReport(nFor, 8)
                    nParameter(9) = MyEQNewWord.mnEQParameterReport(nFor, 9)
                    nParameter(10) = MyEQNewWord.mnEQParameterReport(nFor, 10)

                    'For i = 1 To 10
                    '    Debug.Print(nParameter(i).ToString)
                    'Next

                    nReciperesult = ReadRecipeQueryResult(nFor)
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Recipe Query Result=" & nReciperesult & ",RecipeID[" & g_strRecipeQueryPPID(nFor) & "]")
                    RaiseEvent EQRecipeQueryResult(nFor, IIf(nReciperesult = 1, True, False), g_strRecipeQueryPPID(nFor), nParameter)
                Else
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Recipe Query Request Off")
                    Call WriteMAddr(MyEQMAddr.m_nEQRecipeQueryReq(nFor), False)
                End If
                MyEQOldWord.mnEQRecipeParameterQuery(nFor) = MyEQNewWord.mnEQRecipeParameterQuery(nFor)
            End If
        Next
    End Sub

    Private Sub EQGlassEraseReport()
        Dim nFor As Integer
        Dim strGlassEraseID As String = ""

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQGlassEraseReport(nFor) <> MyEQNewWord.mnEQGlassEraseReport(nFor) Then
                DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Glass Erase Report changed from " & MyEQOldWord.mnEQGlassEraseReport(nFor) & " -> " & MyEQNewWord.mnEQGlassEraseReport(nFor))

                If MyEQNewWord.mnEQGlassEraseReport(nFor) = SIGNAL_ON Then
                    strGlassEraseID = ReadGlassErase(nFor)
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[EVENT], "EQ[" & nFor & "] Glass erase ID=" & strGlassEraseID)
                    RaiseEvent EQGlassErase(nFor, strGlassEraseID)

                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Glass Erase Report Ack On")
                    Call WriteMAddr(MyEQMAddr.m_nEQGlassEraseReportAck(nFor), True)
                Else
                    DebugLog(eIFIndex.INDEX_EQ, eLogType.[SYS], "EQ[" & nFor & "] Glass Erase Report Ack Off")
                    Call WriteMAddr(MyEQMAddr.m_nEQGlassEraseReportAck(nFor), False)
                End If
                MyEQOldWord.mnEQGlassEraseReport(nFor) = MyEQNewWord.mnEQGlassEraseReport(nFor)
            End If
        Next
    End Sub
#End Region

#Region "CV IF Events"

    Private Sub CheckCVOpMode()
        If MyCVOldWord.mCVAutoStatus <> MyCVNewWord.mCVAutoStatus Then
            If MyCVNewWord.mCVAutoStatus = SIGNAL_ON Then
                RaiseEvent CVControlStatusA(eCVControlStatus.AUTO)
            Else
                RaiseEvent CVControlStatusA(eCVControlStatus.MANUAL)
            End If
            MyCVOldWord.mCVAutoStatus = MyCVNewWord.mCVAutoStatus
        End If

        'If MyCVOldWord.mCVManualStatus <> MyCVNewWord.mCVManualStatus Then
        '    If MyCVNewWord.mCVManualStatus = SIGNAL_ON Then
        '        RaiseEvent CVControlStatusA(eCVControlStatus.MANUAL)
        '    End If
        '    MyCVOldWord.mCVManualStatus = MyCVNewWord.mCVManualStatus
        'End If

        If MyCVOldWord.mCVRunStatus <> MyCVNewWord.mCVRunStatus Then
            If MyCVNewWord.mCVRunStatus = SIGNAL_ON Then
                RaiseEvent CVControlStatusR(eCVControlStatus.RUN)
            Else
                RaiseEvent CVControlStatusR(eCVControlStatus.STOP)
            End If
            MyCVOldWord.mCVRunStatus = MyCVNewWord.mCVRunStatus
        End If

        'If MyCVOldWord.mCVStopStatus <> MyCVNewWord.mCVStopStatus Then
        '    If MyCVNewWord.mCVStopStatus = SIGNAL_ON Then
        '    End If
        '    MyCVOldWord.mCVStopStatus = MyCVNewWord.mCVStopStatus
        'End If
    End Sub

    Private Sub CheckPortCancel()
        Dim nFor As Integer
        Dim nPortCancelOwner As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.PortCancelReport(nFor) <> MyCVNewWord.PortCancelReport(nFor) Then

                If MyCVNewWord.PortCancelReport(nFor) = SIGNAL_ON Then
                    nPortCancelOwner = ReadPortCancel(nFor)
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "Port[" & nFor & "] PortCancel,Owner =" & nPortCancelOwner)
                End If
                MyCVOldWord.PortCancelReport(nFor) = MyCVNewWord.PortCancelReport(nFor)
            End If
        Next
    End Sub

    Private Sub CheckUnloaderPortType()
        Dim nFor As Integer

        For nFor = 1 To 3
            If MyCVOldWord.mnCVUnloadPortType(nFor) <> MyCVNewWord.mnCVUnloadPortType(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port [" & nFor & "] Unloader PortType changed from " & MyCVOldWord.mnCVUnloadPortType(nFor) & " -> " & MyCVNewWord.mnCVUnloadPortType(nFor))

                MyCVOldWord.mnCVUnloadPortType(nFor) = MyCVNewWord.mnCVUnloadPortType(nFor)
            End If
        Next
    End Sub

    Private Sub CheckProcessCommandAck()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnProceasCommandAck(nFor) <> MyCVNewWord.mnProceasCommandAck(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV[" & nFor & "] Process Command Ack changed from " & MyCVOldWord.mnProceasCommandAck(nFor) & " -> " & MyCVNewWord.mnProceasCommandAck(nFor))

                If MyCVNewWord.mnProceasCommandAck(nFor) = SIGNAL_ON Then
                    RaiseEvent CVProcessCommandAck(nFor)

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV[" & nFor & "] Process Command Start Off")
                    WriteMAddr(MyCVMAddr.m_nCassetteProcessCommandRequest(nFor), False)
                End If

                MyCVOldWord.mnProceasCommandAck(nFor) = MyCVNewWord.mnProceasCommandAck(nFor)
            End If
        Next

    End Sub

    Private Sub CheckThroughModeLoaderEmpty()
        Dim nFor As Integer

        For nFor = 1 To 3
            If MyCVOldWord.mnThroughModeLoaderEmpty(nFor) <> MyCVNewWord.mnThroughModeLoaderEmpty(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port [" & nFor & "] ThroughMode LoaderEmpty changed from " & MyCVOldWord.mnThroughModeLoaderEmpty(nFor) & " -> " & MyCVNewWord.mnThroughModeLoaderEmpty(nFor))
                If MyCVNewWord.mnThroughModeLoaderEmpty(nFor) = SIGNAL_ON Then
                    RaiseEvent CVLoaderEmpty(nFor)
                End If
                MyCVOldWord.mnThroughModeLoaderEmpty(nFor) = MyCVNewWord.mnThroughModeLoaderEmpty(nFor)
            End If
        Next
    End Sub

    Private Sub CheckThroughModeUnloaderFull()
        Dim nFor As Integer

        For nFor = 1 To 3
            If MyCVOldWord.mnThroughModeUnloaderFull(nFor) <> MyCVNewWord.mnThroughModeUnloaderFull(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port [" & nFor & "] ThroughMode UnloaderFull changed from " & MyCVOldWord.mnThroughModeUnloaderFull(nFor) & " -> " & MyCVNewWord.mnThroughModeUnloaderFull(nFor))
                If MyCVNewWord.mnThroughModeUnloaderFull(nFor) = SIGNAL_ON Then
                    RaiseEvent CVUnloaderFull(nFor)
                End If
                MyCVOldWord.mnThroughModeUnloaderFull(nFor) = MyCVNewWord.mnThroughModeUnloaderFull(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCVPositionGxID()
        Dim nFor As Integer

        For nFor = 1 To CV_POSITION
            If MyCVOldWord.mstrCVPositionGxID(nFor) <> MyCVNewWord.mstrCVPositionGxID(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Position-[" & nFor & "] Glass ID=" & MyCVNewWord.mstrCVPositionGxID(nFor))

                RaiseEvent CVPositionGxIDChange(nFor, MyCVNewWord.mstrCVPositionGxID(nFor))
                MyCVOldWord.mstrCVPositionGxID(nFor) = MyCVNewWord.mstrCVPositionGxID(nFor)
            End If
        Next

    End Sub

    Private Sub CheckCVGlassRequestReport()
        Dim strGxID As String = ""
        Dim strProductCode As String = ""
        Dim strPSHGrade As String = ""
        Dim nGxJudgment As Integer
        Dim nVCVReadPosition As Integer
        Dim nDataEmptyFlag As Integer

        If MyCVOldWord.mnCVGlassRequestReport <> MyCVNewWord.mnCVGlassRequestReport Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV GX Data Request Report changed from " & MyCVOldWord.mnCVGlassRequestReport & " -> " & MyCVNewWord.mnCVGlassRequestReport)

            If MyCVNewWord.mnCVGlassRequestReport = SIGNAL_ON Then
                ReadGxDataRequest(strGxID, strProductCode, strPSHGrade, nGxJudgment, nVCVReadPosition, nDataEmptyFlag)
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV GX Data Request , GlassID=" & strGxID & " ,ProductCode=" & strProductCode & " ,PSHGrade=" & strPSHGrade & " ,GlassJudgment=" & nGxJudgment & " ,VCR Position=" & nVCVReadPosition & "DataEmptyFlag=" & nDataEmptyFlag)

                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Glass Data Request Report Ack On")
                WriteMAddr(MyCVMAddr.m_nGxDataRequestReportAck, True)
            Else
                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Glass Data Request Report Ack Off")
                WriteMAddr(MyCVMAddr.m_nGxDataRequestReportAck, False)
            End If
            MyCVOldWord.mnCVGlassRequestReport = MyCVNewWord.mnCVGlassRequestReport
        End If
    End Sub

    'Private Sub CheckGlassDataReqEmptyFlag()

    '    If MyCVOldWord.mnDataEmptyFlag <> MyCVNewWord.mnDataEmptyFlag Then
    '        DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV DataEmptyFlag changed from " & MyCVOldWord.mnDataEmptyFlag & " -> " & MyCVNewWord.mnDataEmptyFlag)

    '        MyCVOldWord.mnDataEmptyFlag = MyCVNewWord.mnDataEmptyFlag
    '    End If
    'End Sub

    Private Sub CheckCVCassettePresentReport()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnCVCassettePresentReport(nFor) <> MyCVNewWord.mnCVCassettePresentReport(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] CST Present Report changed from " & MyCVOldWord.mnCVCassettePresentReport(nFor) & " -> " & MyCVNewWord.mnCVCassettePresentReport(nFor))

                If MyCVNewWord.mnCVCassettePresentReport(nFor) = SIGNAL_ON Then
                    RaiseEvent CVCassettePresent(nFor)
                End If

                MyCVOldWord.mnCVCassettePresentReport(nFor) = MyCVNewWord.mnCVCassettePresentReport(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCVLinkStatus()
        If MyCVOldWord.mnCVLinkStatus(1) <> MyCVNewWord.mnCVLinkStatus(1) Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV [" & 1 & "] Link Status changed from " & MyCVOldWord.mnCVLinkStatus(1).ToString & " -> " & MyCVNewWord.mnCVLinkStatus(1).ToString)
            RaiseEvent CVLinkStatus(1, MyCVNewWord.mnCVLinkStatus(1))
            MyCVOldWord.mnCVLinkStatus(1) = MyCVNewWord.mnCVLinkStatus(1)
        End If

    End Sub

    Private Sub CheckEQLinkStatus()
        Dim nFor As Integer

        For nFor = 1 To MAX_EQ
            If MyCVOldWord.mnEQLinkStatus(nFor) <> MyCVNewWord.mnEQLinkStatus(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "EQ [" & nFor & "] Link Status changed from " & MyCVOldWord.mnEQLinkStatus(nFor).ToString & " -> " & MyCVNewWord.mnEQLinkStatus(nFor).ToString)

                RaiseEvent EQLinkStatus(nFor, MyCVNewWord.mnEQLinkStatus(nFor))
                MyCVOldWord.mnEQLinkStatus(nFor) = MyCVNewWord.mnEQLinkStatus(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCV1PositionRST()
        Dim nFor As Integer
        Dim nGlassJudgment As Integer
        Dim strPSHGrade As String = ""
        Dim strProductCode As String = ""
        Dim strGlassID As String = ""
        Dim strOPID As String = ""

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnCV1PositionRST(nFor) <> MyCVNewWord.mnCV1PositionRST(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] RST==>CV changed from " & MyCVOldWord.mnCV1PositionRST(nFor) & " -> " & MyCVNewWord.mnCV1PositionRST(nFor))

                If MyCVNewWord.mnCV1PositionRST(nFor) = SIGNAL_ON Then

                    nGlassJudgment = ReadGlassJudgment(nFor)
                    strPSHGrade = ReadPSHGrade(nFor)
                    strProductCode = ReadProductCode(nFor)
                    strGlassID = ReadGlassID(nFor)
                    strOPID = ReadOPID(nFor)

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] RST==>CV ,GlassID=" & strGlassID & ",GlassJudgment=" & nGlassJudgment & " ,PSHGrade=" & strPSHGrade _
                             & " ,ProductCode=" & strProductCode & " ,OPID=" & strOPID)
                End If
                MyCVOldWord.mnCV1PositionRST(nFor) = MyCVNewWord.mnCV1PositionRST(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCV1PositionCV()
        Dim nFor As Integer
        Dim nGlassJudgment As Integer
        Dim strPSHGrade As String = ""
        Dim strProductCode As String = ""
        Dim strGlassID As String = ""
        Dim strOPID As String = ""

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnCV1PositionCV(nFor) <> MyCVNewWord.mnCV1PositionCV(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] CV==>RST changed from " & MyCVOldWord.mnCV1PositionCV(nFor) & " -> " & MyCVNewWord.mnCV1PositionCV(nFor))

                If MyCVNewWord.mnCV1PositionCV(nFor) = SIGNAL_ON Then

                    nGlassJudgment = ReadGlassJudgment(nFor)
                    strPSHGrade = ReadPSHGrade(nFor)
                    strProductCode = ReadProductCode(nFor)
                    strGlassID = ReadGlassID(nFor)
                    strOPID = ReadOPID(nFor)

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] CV==>RST ,GlassID=" & strGlassID & ",GlassJudgment=" & nGlassJudgment & " ,PSHGrade=" & strPSHGrade _
                             & " ,ProductCode=" & strProductCode & " ,OPID=" & strOPID)
                End If
                MyCVOldWord.mnCV1PositionCV(nFor) = MyCVNewWord.mnCV1PositionCV(nFor)
            End If
        Next
    End Sub

    'Private Sub CheckEQResultReport()
    '    Dim nFor As Integer
    '    Dim nSampleGlass As Integer
    '    Dim nSlotNo As Integer
    '    Dim strPSHGroup As String = ""
    '    Dim strChipGrade As String = ""
    '    Dim strGXID As String = ""
    '    Dim nEQResultReport As Integer

    '    For nFor = 1 To MAX_EQ
    '        If MyCVOldWord.mnEQResultReport(nFor) <> MyCVNewWord.mnEQResultReport(nFor) Then
    '            DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "EQ Index[" & nFor & "] Glass data[EQ -> RST] changed from " & MyCVOldWord.mnEQResultReport(nFor) & " -> " & MyCVNewWord.mnEQResultReport(nFor))

    '            If MyCVNewWord.mnEQResultReport(nFor) = SIGNAL_ON Then
    '                nEQResultReport = ReadEQResultReport(nFor, nSampleGlass, nSlotNo, strPSHGroup, strChipGrade, strGXID)
    '                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "EQ[" & nFor & "] Glass data[EQ -> RST], SlotNo =" & nSlotNo & " ,Result Report =" & nEQResultReport & " ,GlassID =" & strGXID & _
    '                         " ,PSHGroup =" & strPSHGroup & " ,SampleGlass =" & nSampleGlass)

    '                ArmGlassID(nFor) = strGXID

    '                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "EQ[" & nFor & "] Glass data[EQ -> RST], ChipGrade =" & strChipGrade)
    '            End If
    '            MyCVOldWord.mnEQResultReport(nFor) = MyCVNewWord.mnEQResultReport(nFor)
    '        End If
    '    Next
    'End Sub

    Private Sub CheckEQInfoReport()
        Dim nFor As Integer
        Dim nSampleGlass As Integer
        Dim nProductCategory As Integer
        Dim nSlotNo As Integer
        Dim strGXID As String = ""
        Dim strEPPID As String = ""
        Dim strMESID As String = ""
        Dim strProductCode As String = ""
        Dim strCurrPPID As String = ""
        Dim strPOPERID As String = ""
        Dim strPLINEID As String = ""
        Dim strPTOOLID As String = ""
        Dim strCSTID As String = ""
        Dim strOPID As String = ""
        Dim strGlassGrade As String = ""
        Dim strDMQCgrade As String = ""
        Dim strGlassScrapFlag As String = ""
        Dim nAOIfuctionMode As Integer
        Dim nMPAflag As Integer

        For nFor = 1 To MAX_EQ
            If MyEQOldWord.mnEQinformationReport(nFor) <> MyEQNewWord.mnEQinformationReport(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "EQ[" & nFor & "] Glass data[RST -> EQ] changed from " & MyEQOldWord.mnEQinformationReport(nFor) & " -> " & MyEQNewWord.mnEQinformationReport(nFor))

                If MyEQNewWord.mnEQinformationReport(nFor) = SIGNAL_ON Then
                    Call ReadEQinformationReport1(nSampleGlass, nProductCategory, nSlotNo, strGXID, strEPPID, strMESID, strProductCode, strCurrPPID, strPOPERID)

                    Call ReadEQinformationReport2(strPLINEID, strPTOOLID, strCSTID, strOPID, strGlassGrade, strDMQCgrade, strGlassScrapFlag, nAOIfuctionMode, nMPAflag)

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "EQ[" & nFor & "] Glass data[RST -> EQ] ,SlotNo =" & nSlotNo & " ,GlassID =" & strGXID & " ,ProductCategory =" & nProductCategory & " ,SampleGlass =" & nSampleGlass & _
                             " ,EPPID=" & strEPPID & " ,MESID =" & strMESID & " ,ProductCode=" & strProductCode & " ,CurrPPID= " & strCurrPPID & " ,POPERID =" & strPOPERID)

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "EQ[" & nFor & "] Glass data[RST -> EQ] ,PLINEID =" & strPLINEID & " ,PTOOLID =" & strPTOOLID & " ,CSTID =" & strCSTID & " ,OPID =" & strOPID & " ,GlassGrade =" & strGlassGrade & _
                             " ,DMQCgrade =" & strDMQCgrade & " ,GlassScrapFlag =" & strGlassScrapFlag & " ,AOI Fuction Mode =" & nAOIfuctionMode & " ,MPAflag =" & nMPAflag)

                    RaiseEvent EQProcessStart(nFor, strGXID)
                End If
                MyEQOldWord.mnEQinformationReport(nFor) = MyEQNewWord.mnEQinformationReport(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCVAlarm()
        Dim nFor As Integer
        Dim i As Integer
        Dim nIndex As Integer
        Dim anBit(MAX_BIT) As Short

        For nFor = 1 To CV_ALARM_WORD_LEN

            If MyCVOldWord.mnCVAlarmWord(nFor) <> MyCVNewWord.mnCVAlarmWord(nFor) Then
                WordConvertToBin(MyCVNewWord.mnCVAlarmWord(nFor), anBit)

                For i = 0 To MAX_BIT
                    nIndex = (i + 1) + (16 * (nFor - 1)) '1~512 Alarm
                    MyCVNewWord.mnCVAlarm(nIndex) = anBit(i)
                Next

                MyCVOldWord.mnCVAlarmWord(nFor) = MyCVNewWord.mnCVAlarmWord(nFor)
            End If
        Next

        For nFor = 1 To MAX_CV_ALARM_CODE
            If MyCVOldWord.mnCVAlarm(nFor) <> MyCVNewWord.mnCVAlarm(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Alarm Code=" & nFor & " ,Alarm Signal changed  from " & MyCVOldWord.mnCVAlarm(nFor) & " -> " & MyCVNewWord.mnCVAlarm(nFor))

                RaiseEvent CVAlarm(IIf(MyCVNewWord.mnCVAlarm(nFor) = SIGNAL_ON, True, False), nFor)
                MyCVOldWord.mnCVAlarm(nFor) = MyCVNewWord.mnCVAlarm(nFor)
            End If
        Next
    End Sub

    Private Sub ChekmnFlowOutReport()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnFlowoutReport(nFor) <> MyCVNewWord.mnFlowoutReport(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV GX Flow Out Report changed from " & MyCVOldWord.mnFlowoutReport(nFor) & " -> " & MyCVNewWord.mnFlowoutReport(nFor))

                If MyCVNewWord.mnFlowoutReport(nFor) = SIGNAL_ON Then
                    Call ReadGlassflowOutReport(nFor)

                    'DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Glass flow out / Slot Number=" & MyCVNewWord.mnGXFlowOutReportSlotNo(nFor) & ",Glass ID =" & MyCVNewWord.mstrGXFlowOutGXID(nFor))
                    'RaiseEvent CVGlassFlowOut(nFor, MyCVNewWord.mnGXFlowOutReportSlotNo(nFor))

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port Flow Out Ack On")
                    Call WriteMAddr(MyCVMAddr.m_nFlowOutAck(nFor), True)
                Else
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port Flow Out Ack Off")
                    'Call WriteMAddr(MyCVMAddr.m_nFlowOutAck(nFor), False)
                End If
                MyCVOldWord.mnFlowoutReport(nFor) = MyCVNewWord.mnFlowoutReport(nFor)
            End If
        Next

    End Sub

    Private Sub CheckGxFlowOut()
        Dim nSlot As Integer = 0
        Dim nPort As Integer = 0
        'Dim anReceiveSlotData(LEN_S167_BLOCK2) As Integer
        Dim i As Integer = 0
        Dim strGlassID As String = ""

        For nPort = 1 To MAX_PORTS
            For nSlot = 1 To MAX_SLOTS
                If MyRSTOldWord.mnGxFlowOut(nPort, nSlot) <> MyRSTNewWord.mnGxFlowOut(nPort, nSlot) Then
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nPort & "]Receive Gx Flow Out changed from " & MyRSTOldWord.mnGxFlowOut(nPort, nSlot) & " -> " & MyRSTNewWord.mnGxFlowOut(nPort, nSlot))

                    If MyRSTNewWord.mnGxFlowOut(nPort, nSlot) = SIGNAL_ON Then
                        DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nPort & "] Receive Glass flow out / SlotNo=" & nSlot)
                        RaiseEvent CVGlassFlowOut(nPort, nSlot)

                        'M9450~9599
                        WriteMAddr(MyRSTMAddr.mnGxFlowOutAck(nPort, nSlot), True)
                    End If

                    MyRSTOldWord.mnGxFlowOut(nPort, nSlot) = MyRSTNewWord.mnGxFlowOut(nPort, nSlot)
                End If
            Next
        Next

    End Sub

    Private Function ProcessGlassFlowInData(ByVal nPort As Integer, ByVal nSlot As Integer) As String
        Dim anReceiveSlotData(LEN_S167_BLOCK2) As Integer
        Dim strGlassID As String = ""
        Dim i As Integer = 0

        ReadZRAddr(MyPLC_S167_Addr.SlotData(nPort, nSlot), anReceiveSlotData)

        For i = ePLC_S167_DeviceNo.GLASS_ID_SLOT_WORD1 To ePLC_S167_DeviceNo.GLASS_ID_SLOT_WORD6
            strGlassID = strGlassID & ConvertHiLowASCIIToString(anReceiveSlotData(i))
        Next

        ProcessGlassFlowInData = strGlassID
    End Function

    Private Sub CheckGxFlowIn()
        Dim nSlot As Integer = 0
        Dim nPort As Integer = 0
        'Dim anReceiveSlotData(LEN_S167_BLOCK2) As Integer
        Dim i As Integer = 0
        Dim strGlassID As String = ""
        Dim strEQStartTime(3) As String
        Dim strEQEndTime(3) As String
        Dim strProductCode As String = ""


        For nPort = 1 To 3
            For nSlot = MAX_SLOTS To 1 Step -1
                If MyRSTOldWord.mnGxFlowIn(nPort, nSlot) <> MyRSTNewWord.mnGxFlowIn(nPort, nSlot) Then
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nPort & "]Receive Gx Flow In changed from " & MyRSTOldWord.mnGxFlowIn(nPort, nSlot) & " -> " & MyRSTNewWord.mnGxFlowIn(nPort, nSlot))

                    If MyRSTNewWord.mnGxFlowIn(nPort, nSlot) = SIGNAL_ON Then
                        Call ReadGlassflowInReport()
                        'strGlassID = ProcessGlassFlowInData(nPort, nSlot)
                        strGlassID = GetCSTSlotInfo(nPort, nSlot).GlassID
                        strEQStartTime(1) = GetCSTSlotInfo(nPort, nSlot).EQStartTime(1)
                        strEQStartTime(2) = GetCSTSlotInfo(nPort, nSlot).EQStartTime(2)
                        strEQStartTime(3) = GetCSTSlotInfo(nPort, nSlot).EQStartTime(3)

                        strEQEndTime(1) = GetCSTSlotInfo(nPort, nSlot).EQEndTime(1)
                        strEQEndTime(2) = GetCSTSlotInfo(nPort, nSlot).EQEndTime(2)
                        strEQEndTime(3) = GetCSTSlotInfo(nPort, nSlot).EQEndTime(3)

                        DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nPort & "] Receive Glass flow in / SlotNo=" & nSlot & " Glass ID[" & strGlassID & "] ,1STime[" & strEQStartTime(1) & "],1ETime[" & strEQEndTime(1) & "],2STime[" & strEQStartTime(2) & "],2ETime[" & strEQEndTime(2) & "],3STime[" & strEQStartTime(3) & "],3ETime[" & strEQEndTime(3) & "] ,ProductCode[" & MyCVNewWord.mstrGXFlowInReportProductCode & "]")
                        RaiseEvent CVGlassFlowIn(nPort, nSlot, strGlassID, MyCVNewWord.mstrGXFlowInReportProductCode, strEQStartTime, strEQEndTime)

                        WriteMAddr(MyRSTMAddr.mnGxFlowInAck(nPort, nSlot), True)
                    End If

                    MyRSTOldWord.mnGxFlowIn(nPort, nSlot) = MyRSTNewWord.mnGxFlowIn(nPort, nSlot)
                End If
            Next
        Next

    End Sub

    Private Sub ChekmnFlowInReport()
        If MyCVOldWord.mnFlowinReport <> MyCVNewWord.mnFlowinReport Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV GX Flow In Report changed from " & MyCVOldWord.mnFlowinReport & " -> " & MyCVNewWord.mnFlowinReport)

            If MyCVNewWord.mnFlowinReport = SIGNAL_ON Then
                'Call ReadGlassflowInReport()
                'DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & MyCVNewWord.mnGXFlowInReportPortIndex & "] Glass flow in / Slot Number=" & MyCVNewWord.mnGXFlowInReportSlotNo _
                '        & " Glass ID=" & MyCVNewWord.mstrGXFlowInReportGXID & " Product Code=" & MyCVNewWord.mstrGXFlowInReportProductCode)

                'RaiseEvent CVGlassFlowIn(MyCVNewWord.mnGXFlowInReportPortIndex, MyCVNewWord.mnGXFlowInReportSlotNo, MyCVNewWord.mstrGXFlowInReportGXID, MyCVNewWord.mstrGXFlowInReportProductCode)

                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port Flow In Ack On")
                Call WriteMAddr(MyCVMAddr.m_nFlowInAck, True)
            Else
                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port Flow In Ack Off")
                Call WriteMAddr(MyCVMAddr.m_nFlowInAck, False)
            End If
            MyCVOldWord.mnFlowinReport = MyCVNewWord.mnFlowinReport
        End If
    End Sub

    Dim mDummyCancelResult(MAX_PORTS) As Integer
    Private Sub CheckDummyCancelAck()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnPortDummyCancelAck(nFor) <> MyCVNewWord.mnPortDummyCancelAck(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Dummy Cancel Ack changed from " & MyCVOldWord.mnPortDummyCancelAck(nFor) & " -> " & MyCVNewWord.mnPortDummyCancelAck(nFor))

                If MyCVNewWord.mnPortDummyCancelAck(nFor) = SIGNAL_ON Then
                    Call ReadCassetteDummyCancelResult()

                    mDummyCancelResult(nFor) = MyCVNewWord.mnDummyCacncelResult
                    '0:Nnone,1:Accepted,2:Rejected
                    'DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "]Dummy Cancel Result =" & MyCVNewWord.mnDummyCacncelResult)
                    'RaiseEvent CVDummyCancelResult(nFor, IIf(MyCVNewWord.mnDummyCacncelResult = 1, True, False))

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port[" & nFor & "]Dummy Cancel Request Off")
                    Call WriteMAddr(MyCVMAddr.m_nDummyCancelRequest(nFor), False)
                Else
                    '2011-06-02
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "]Dummy Cancel Result =" & mDummyCancelResult(nFor))
                    RaiseEvent CVDummyCancelResult(nFor, IIf(mDummyCancelResult(nFor) = 1, True, False))
                End If
                MyCVOldWord.mnPortDummyCancelAck(nFor) = MyCVNewWord.mnPortDummyCancelAck(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCassetteRemoveReport()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnCassetteRemoveReport(nFor) <> MyCVNewWord.mnCassetteRemoveReport(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Cassette Remove Report changed from " & MyCVOldWord.mnCassetteRemoveReport(nFor) & " -> " & MyCVNewWord.mnCassetteRemoveReport(nFor))

                If MyCVNewWord.mnCassetteRemoveReport(nFor) = SIGNAL_ON Then
                    RaiseEvent CVCassetteRemoveReport(nFor)
                End If
                MyCVOldWord.mnCassetteRemoveReport(nFor) = MyCVNewWord.mnCassetteRemoveReport(nFor)
            End If
        Next
    End Sub

    Private Sub CheckPortSubStatus()
        Dim nFor As Integer

        For nFor = 1 To MAX_CST_PORT
            If MyCVOldWord.mnPortSubStatus(nFor) <> MyCVNewWord.mnPortSubStatus(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Port Sub Status changed from " & MyCVOldWord.mnPortSubStatus(nFor) & " -> " & MyCVNewWord.mnPortSubStatus(nFor))

                'PortSubStatus ==> 0 = Running 1 = Pause
                RaiseEvent CVPortSubStatus(nFor, IIf(MyCVNewWord.mnPortSubStatus(nFor) = SIGNAL_ON, True, False))
                MyCVOldWord.mnPortSubStatus(nFor) = MyCVNewWord.mnPortSubStatus(nFor)
            End If
        Next
    End Sub

    Private Sub CheckHandOffAvailable()
        Dim nFor As Integer

        For nFor = 1 To MAX_CST_PORT
            If MyCVOldWord.mnHandOffAvailable(nFor) <> MyCVNewWord.mnHandOffAvailable(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] HandOffAvailable changed from " & MyCVOldWord.mnHandOffAvailable(nFor) & " -> " & MyCVNewWord.mnHandOffAvailable(nFor))
                If MyCVNewWord.mnHandOffAvailable(nFor) = SIGNAL_ON Then
                    RaiseEvent CVHandOffAvailable(nFor, True)
                Else
                    RaiseEvent CVHandOffAvailable(nFor, False)
                End If
                MyCVOldWord.mnHandOffAvailable(nFor) = MyCVNewWord.mnHandOffAvailable(nFor)
            End If
        Next
    End Sub

    Private Sub CheckPortExist()
        Dim nFor As Integer

        For nFor = 1 To MAX_CST_PORT
            If MyCVOldWord.mnPortExist(nFor) <> MyCVNewWord.mnPortExist(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Port Exist changed from " & MyCVOldWord.mnPortExist(nFor) & " -> " & MyCVNewWord.mnPortExist(nFor))
                If MyCVNewWord.mnPortExist(nFor) = SIGNAL_ON Then
                    mvarCVWithCassette(nFor) = True
                    RaiseEvent CVCSTArrived(nFor)
                Else
                    mvarCVWithCassette(nFor) = False
                    RaiseEvent CVCSTRemoved(nFor)
                End If
                MyCVOldWord.mnPortExist(nFor) = MyCVNewWord.mnPortExist(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCVPortDisable()
        Dim nFor As Integer

        For nFor = 1 To MAX_CST_PORT
            If MyCVOldWord.mnPortDisable(nFor) <> MyCVNewWord.mnPortDisable(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Port Disable changed from " & MyCVOldWord.mnPortDisable(nFor) & " -> " & MyCVNewWord.mnPortDisable(nFor))

                mvarCVPortEnable(nFor) = IIf(MyCVNewWord.mnPortDisable(nFor) = SIGNAL_ON, False, True)
                RaiseEvent CVPortDisable(nFor, IIf(MyCVNewWord.mnPortDisable(nFor) = SIGNAL_ON, True, False))
                MyCVOldWord.mnPortDisable(nFor) = MyCVNewWord.mnPortDisable(nFor)
            End If
        Next
    End Sub

    Private Sub CheckVCREnable()
        Dim nFor As Integer

        For nFor = 1 To MAX_CST_PORT
            If MyCVOldWord.mnVCREnable(nFor) <> MyCVNewWord.mnVCREnable(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] VCR Enable changed from " & MyCVOldWord.mnVCREnable(nFor) & " -> " & MyCVNewWord.mnVCREnable(nFor))

                mvarCVVCREnable(nFor) = IIf(MyCVNewWord.mnVCREnable(nFor) = SIGNAL_ON, True, False)
                RaiseEvent CVVCRStatusChange(nFor, IIf(MyCVNewWord.mnVCREnable(nFor) = SIGNAL_ON, True, False))
                MyCVOldWord.mnVCREnable(nFor) = MyCVNewWord.mnVCREnable(nFor)
            End If
        Next
    End Sub

    Private Sub CheckCVStatus()
        If MyCVOldWord.mnCVStatus <> MyCVNewWord.mnCVStatus Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Status changed from " & MyCVOldWord.mnCVStatus.ToString & " -> " & MyCVNewWord.mnCVStatus.ToString)

            mvarCVStatus = MyCVNewWord.mnCVStatus
            RaiseEvent CVStatusChanged(MyCVNewWord.mnCVStatus)
            MyCVOldWord.mnCVStatus = MyCVNewWord.mnCVStatus
        End If
    End Sub

    Private Sub CheckPortActionStatus()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnPortActionStatus(nFor) <> MyCVNewWord.mnPortActionStatus(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Load/Unload Status changed from " & MyCVOldWord.mnPortActionStatus(nFor).ToString & " -> " & MyCVNewWord.mnPortActionStatus(nFor).ToString)

                mvarCVPortStatus(nFor) = MyCVNewWord.mnPortActionStatus(nFor)

                If MyCVNewWord.mnPortActionStatus(nFor) = ePAS.PAS_LOAD_REQUEST Then
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Load Request")

                    RaiseEvent CVCSTLoadRequest(nFor)
                ElseIf MyCVNewWord.mnPortActionStatus(nFor) = ePAS.PAS_LOAD_COMPLETE Then
                    Call ReadPortCSTID(nFor)

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Load Complete ,CSTID=" & MyCVNewWord.mstrPortCSTID(nFor) & " ,First Slot=" & MyCVNewWord.mnPortFirstSlot(nFor))
                    RaiseEvent CVCSTLoadComplete(nFor, MyCVNewWord.mnPortFirstSlot(nFor), MyCVNewWord.mstrPortCSTID(nFor))

                ElseIf MyCVNewWord.mnPortActionStatus(nFor) = ePAS.PAS_UNLOAD_REQUEST Then
                    Select Case nFor
                        Case 1
                            Call ReadUnloadStatusTotalGXQty(eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_1)
                        Case 2
                            Call ReadUnloadStatusTotalGXQty(eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_2)
                        Case 3
                            Call ReadUnloadStatusTotalGXQty(eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_3)
                    End Select

                    'Unload Status ==> 1:Normal,2:Abnormal
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Unload Request , Status=" & IIf(MyCVNewWord.mnUnloadStatus(nFor) = 1, "Normal", "Abnormal") & " ,Qty=" & MyCVNewWord.mnGlassQty(nFor))
                    RaiseEvent CVCSTUnloadRequest(nFor, IIf(MyCVNewWord.mnUnloadStatus(nFor) = 1, True, False), MyCVNewWord.mnGlassQty(nFor))

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port[" & nFor & "]Unload Request Off")
                    Call WriteMAddr(MyCVMAddr.m_nCassetteUnloadRequest(nFor), False)

                ElseIf MyCVNewWord.mnPortActionStatus(nFor) = ePAS.PAS_UNLOAD_COMPLETE Then
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Unload Complete")

                    RaiseEvent CVCSTUnloadComplete(nFor)
                End If

                MyCVOldWord.mnPortActionStatus(nFor) = MyCVNewWord.mnPortActionStatus(nFor)
            End If
        Next
    End Sub

    Private Sub S765datadownloadAck()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnS765datadownloadAck(nFor) <> MyCVNewWord.mnS765datadownloadAck(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] S765 datadownload Ack changed from " & MyCVOldWord.mnS765datadownloadAck(nFor) & " -> " & MyCVNewWord.mnS765datadownloadAck(nFor))

                If MyCVNewWord.mnS765datadownloadAck(nFor) = SIGNAL_ON Then
                    RaiseEvent CVS765datadownloadAck(nFor)
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port[" & nFor & "]S765 Data Download Request Off")
                    Call WriteMAddr(MyCVMAddr.m_nS765DataDownloadRequest(nFor), False)
                End If
                MyCVOldWord.mnS765datadownloadAck(nFor) = MyCVNewWord.mnS765datadownloadAck(nFor)
            End If
        Next
    End Sub

    Private Sub S167dataUploadRequest()
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnS167dataUploadRequest(nFor) <> MyCVNewWord.mnS167dataUploadRequest(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] S167 Data Upload Request changed from " & MyCVOldWord.mnS167dataUploadRequest(nFor) & " -> " & MyCVNewWord.mnS167dataUploadRequest(nFor))

                If MyCVNewWord.mnS167dataUploadRequest(nFor) = SIGNAL_ON Then
                    Call ReadS167Data(nFor)
                Else
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port[" & nFor & "]S167 Data Upload Ack Off")
                    Call WriteMAddr(MyCVMAddr.m_nS167DataUploadAck(nFor), False)
                End If
            End If
            MyCVOldWord.mnS167dataUploadRequest(nFor) = MyCVNewWord.mnS167dataUploadRequest(nFor)
        Next
    End Sub

    Private Sub GlassInfoUnmatchedReport()
        If MyCVOldWord.mnGlassinfoUnmatchedReport <> MyCVNewWord.mnGlassinfoUnmatchedReport Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Glass info Unmatch Report changed from " & MyCVOldWord.mnGlassinfoUnmatchedReport & " -> " & MyCVNewWord.mnGlassinfoUnmatchedReport)

            If MyCVNewWord.mnGlassinfoUnmatchedReport = SIGNAL_ON Then
                Call ReadGxUnmatchReport()

                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "Glass info unmatch report , PortNo=" & MyCVNewWord.mnUnmatchPortNumber & " ,SlotNo=" & MyCVNewWord.mnUnmatchSlotNumber & " ,Status=" & MyCVNewWord.mnUnmatchStatus)
                RaiseEvent CVSlotNoUnmatch(MyCVNewWord.mnUnmatchPortNumber, MyCVNewWord.mnUnmatchSlotNumber, MyCVNewWord.mnUnmatchStatus)
                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Glass info Unmatch Report Ack On")
                Call WriteMAddr(MyCVMAddr.m_nGlassinfoUnmatchedReportAck, True)
            Else
                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Glass info Unmatch Report Ack Off")
                Call WriteMAddr(MyCVMAddr.m_nGlassinfoUnmatchedReportAck, False)
            End If
            MyCVOldWord.mnGlassinfoUnmatchedReport = MyCVNewWord.mnGlassinfoUnmatchedReport
        End If
    End Sub

    Private Sub GlassAbnormalReport()
        If MyCVOldWord.mnGlassAbnormalReport <> MyCVNewWord.mnGlassAbnormalReport Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Glass Abnormal Report changed from " & MyCVOldWord.mnGlassAbnormalReport & " -> " & MyCVNewWord.mnGlassAbnormalReport)

            If MyCVNewWord.mnGlassAbnormalReport = SIGNAL_ON Then
                Call ReadAbnormalReport()

                ' report Code ==>1:GlassErase,2:GlassIDmodify,3:GlassInsert,4:GlassIDReadNG
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Glass Abnormal Report ,report Code=" & MyCVNewWord.mnGxAbnormalCase & " ,Position=" & MyCVNewWord.mnGxAbnormalPosition & " ,SGxID=" & MyCVNewWord.mstrAbnormalSGxID & " ,VCRGxID=" & MyCVNewWord.mstrAbnormalVCRGxID & " ,PLCchangedata=" & MyCVNewWord.mnPLCChangeData)
                RaiseEvent CVGlassAbnormal(MyCVNewWord.mnGxAbnormalCase, MyCVNewWord.mnGxAbnormalPosition, MyCVNewWord.mstrAbnormalSGxID, MyCVNewWord.mstrAbnormalVCRGxID)

                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Glass Abnormal Report Ack On")
                Call WriteMAddr(MyCVMAddr.m_nGlassAbnormalReportAck, True)
            Else
                DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Glass Abnormal Report Ack Off")
                Call WriteMAddr(MyCVMAddr.m_nGlassAbnormalReportAck, False)
            End If
            MyCVOldWord.mnGlassAbnormalReport = MyCVNewWord.mnGlassAbnormalReport
        End If
    End Sub

    Private Sub PortChangeReport()
        Dim strResult As String = ""
        Dim strOwner As String = ""
        Dim nFor As Integer

        For nFor = 1 To MAX_PORTS
            If MyCVOldWord.mnPortChangeReport(nFor) <> MyCVNewWord.mnPortChangeReport(nFor) Then
                DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] Port Change Report changed from " & MyCVOldWord.mnPortChangeReport(nFor) & " -> " & MyCVNewWord.mnPortChangeReport(nFor))

                If MyCVNewWord.mnPortChangeReport(nFor) = SIGNAL_ON Then
                    'MyProcessPortChangeFlag = True

                    Call ReadPortChangReport(nFor)
                    'PortChangeReportResult ==>0:None,1:Successedm2:Failred
                    strResult = IIf(MyCVNewWord.mnPortChangeReportResult(nFor) = 1, "Success", "Failure")

                    strOwner = IIf(MyCVNewWord.mnPortChangeOwner(nFor) = 1, "CPC", "PLC")

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[EVENT], "CV Port[" & nFor & "] PortChangeResult=" & strResult _
                             & ", PortMode=" & MyCVNewWord.mnPortChangeReportPortMode(nFor).ToString & " ,PortType=" & MyCVNewWord.mnPortChangeReportPortType(nFor).ToString & " ,Owner=" & strOwner)

                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port[" & nFor & "]  Port Change Report Ack On")
                    WriteMAddr(MyCVMAddr.m_nPortChangeReportAck(nFor), True)

                    RaiseEvent CVPortTypeChangeResult(nFor, IIf(MyCVNewWord.mnPortChangeReportResult(nFor) = 1, True, False), MyCVNewWord.mnPortChangeReportPortMode(nFor), MyCVNewWord.mnPortChangeReportPortType(nFor))
                Else
                    DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "CV Port[" & nFor & "] Port Change Report Ack Off")
                    WriteMAddr(MyCVMAddr.m_nPortChangeReportAck(nFor), False)

                    'MyProcessPortChangeFlag = False
                End If
                MyCVOldWord.mnPortChangeReport(nFor) = MyCVNewWord.mnPortChangeReport(nFor)
            End If
        Next


    End Sub

#End Region

#Region "CV IF Method"
    'Public Sub CVCassetteAbortRequest(ByVal nPortNo As Integer)
    '    If nPortNo < 1 Or nPortNo > 3 Then Exit Sub

    '    DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "] Casette Abort Request")
    '    WriteMAddr(MyCVMAddr.m_nCVCSTAbortRequest(nPortNo), True)
    'End Sub

    Public Sub CVPortChange(ByVal nPortNo As Integer, ByVal nPortMode As ePortMode, ByVal nPortType As eUnloadType, Optional ByVal strProductCode As String = "")
        Dim anProductCode(12) As Integer
        'Dim strCombination As String = ""
        'Dim nProductCodeLen As Integer

        'nProductCodeLen = Len(Trim(strProductCode))
        'DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "] Wait Port Change Request -> " & nPortMode.ToString & ",Add Buffer...")
        'strCombination = nPortNo & "," & nPortMode & "," & nPortType & "," & nProductCodeLen & "," & strProductCode
        'AddBufPortChange(strCombination)
        'ProcessBufPortChangeData()

        WriteZRAddr(MyCVZRAddr.m_nPortChangePortNo, nPortNo)
        WriteZRAddr(MyCVZRAddr.m_nPortChangePortMode, nPortMode)
        WriteZRAddr(MyCVZRAddr.m_nPortChangePortType, nPortType)
        'ASCStringConvert(strProductCode, 12, anProductCode)
        'WriteZRArrayAddr(MyCVZRAddr.m_nPortChangeProductCode, anProductCode)
        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "] Port Change Request ,PortMode[" & nPortMode.ToString & "] ,PortType[" & nPortType.ToString & "]")
        WriteMAddr(MyCVMAddr.m_nCVPortChangeRequest, True)
    End Sub

    Public Sub CVRSTOnline(ByVal fOnOff As Boolean)
        If fOnOff Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "[CV]RST Online...")
        Else
            DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "[CV]RST Offline...")
        End If
        WriteMAddr(MyCVMAddr.m_nRSTLinkRequest(1), IIf(fOnOff, True, False))
    End Sub

    Public Sub CVRequestUnloadCST(ByVal nPortNo As Integer)
        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]Unload Request...")
        WriteMAddr(MyCVMAddr.m_nCassetteUnloadRequest(nPortNo), True)
    End Sub

    Public Sub CVDummyCancel(ByVal nPortNo As Integer)
        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]Dummy Cancel Request On")
        WriteMAddr(MyCVMAddr.m_nDummyCancelRequest(nPortNo), True)
    End Sub

    Public Sub CVTransferReset(ByVal fOnOff As Boolean)
        If fOnOff Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Transfer Reset Request On")
        Else
            DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Transfer Reset Request Off")
        End If

        WriteMAddr(MyCVMAddr.m_nTransferResetRequest, fOnOff)
    End Sub

    Public Sub CVPortPause(ByVal nPortNo As Integer)
        If nPortNo > MAX_PORTS Then Exit Sub

        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]Pause Request On")
        WriteMAddr(MyCVMAddr.m_nPauseRequest(nPortNo), True)
    End Sub

    Public Sub CVPortResume(ByVal nPortNo As Integer)
        If nPortNo > MAX_PORTS Then Exit Sub

        DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]Resume Request On")
        WriteMAddr(MyCVMAddr.m_nResumeRequest(nPortNo), True)
    End Sub

    Public Sub CVCSTProcessCommand(ByVal nPortNo As Integer, ByVal strCSTID As String, ByVal nProcessCommand As eProcessCommand, ByRef anSlotInfo() As Integer, ByVal nProcessCount As Integer)
        Dim nTempSlotInfo(64) As Integer ' 4 Word
        Dim MyGlassInfo(3) As Integer
        Dim anTempSlot(15) As Integer
        Dim nFor As Integer
        Dim nCount As Integer
        Dim nLoop As Integer
        'Dim strSlotInfo As String = ""
        Dim strHexData As String = ""
        Dim anCSTID(2) As Integer

        If nProcessCommand = eProcessCommand.CMD_START Then
            DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "]Process Command Start")

            For nFor = LBound(anSlotInfo) To MAX_SLOTS
                nTempSlotInfo(nFor) = anSlotInfo(nFor)
            Next nFor

            For nFor = 0 To 3
                For nLoop = 0 To 15
                    nCount = nCount + 1
                    anTempSlot(nLoop) = nTempSlotInfo(nCount)
                    'strSlotInfo = strSlotInfo & CStr(anTempSlot(nLoop))
                Next

                MyGlassInfo(nFor) = ConvertProcessSlot(anTempSlot)
                strHexData = HexLeadZero(MyGlassInfo(nFor))
                Select Case nFor
                    Case 0
                        DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "Cassette Slot Information 1 (Hex)=" & strHexData)
                    Case 1
                        DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "Cassette Slot Information 2 (Hex)=" & strHexData)
                    Case 2
                        DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "Cassette Slot Information 3 (Hex)=" & strHexData)
                    Case 3
                        DebugLog(eIFIndex.INDEX_CV, eLogType.[SYS], "Cassette Slot Information 4 (Hex)=" & strHexData)
                End Select
                strHexData = ""
            Next

            DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Process Count=" & nProcessCount)
            'WriteZRAddr(MyCVZRAddr.m_nPortNumber, nPortNo)


            ASCStringConvert(strCSTID, 2, anCSTID)
            WriteZRArrayAddr(MyCVZRAddr.m_nProcessCmdCSTID(nPortNo), anCSTID)
            WriteZRAddr(MyCVZRAddr.m_nProcessCommand(nPortNo), nProcessCommand)
            WriteZRArrayAddr(MyCVZRAddr.m_nCassetteSlotInformation(nPortNo), MyGlassInfo)
            WriteZRAddr(MyCVZRAddr.m_nProcessGlassQuantity(nPortNo), nProcessCount)

            WriteMAddr(MyCVMAddr.m_nCassetteProcessCommandRequest(nPortNo), True)
        End If
    End Sub

    Private Function ConvertProcessSlot(ByVal nSlotInfo() As Integer) As Integer
        Dim nVal As Long
        Dim nFor As Integer

        For nFor = 0 To 15
            If nSlotInfo(nFor) = 1 Then
                nVal = nVal + (2 ^ nFor)
            End If
        Next nFor

        ConvertProcessSlot = nVal
    End Function

#End Region

#Region "EQ IF Method"

    'For GUI Glass Data
    'M9170~9172
    Public Sub RSTDeleteStageGlassData(ByVal nEQIndex As Integer)
        If MyEQNewWord.mnEQStageGlassDataExist(nEQIndex) = SIGNAL_ON Then
            DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] RST Delete Stage Glass Data On")

            MyCheckDeleteEQGlassDataFlag(nEQIndex) = True
            WriteMAddr(MyEQMAddr.m_nEQDeleteStageGxData(nEQIndex), True)
        Else
            DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] RST Delete Stage Glass Data Error ...")
            RaiseEvent RSTDeltetEQGlassDataComplete(nEQIndex, eEQGlassInfoDeleteResult.Failure)
        End If

    End Sub

    Public Sub EQRSTOnline(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean)
        If fOnOff Then
            DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] RST OnLine On")
        Else
            DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] RST OnLine Off")
        End If

        WriteMAddr(MyEQMAddr.m_nEQRSTLinkRequest(nEQIndex), IIf(fOnOff = True, True, False))
    End Sub

    Public Sub EQTransferReset(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean)
        If fOnOff Then
            DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] Transfer Reset On")
        Else
            DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] Transfer Reset Off")
        End If
        WriteMAddr(MyEQMAddr.m_nEQTransferReset(nEQIndex), IIf(fOnOff = True, True, False))
    End Sub

    Public Sub EQRecipeCheck(ByVal nEQIndex As Integer, ByVal strPPID As String)
        Dim anPPID(LEN_A_RECIPE_CHECK_REQUEST_ID) As Integer

        g_strRecipeCheckPPID(nEQIndex) = strPPID

        ASCStringConvert(strPPID, LEN_A_RECIPE_CHECK_REQUEST_ID, anPPID)
        WriteZRArrayAddr(MyEQZRAddr.m_nRecipeCheck(nEQIndex), anPPID)
        DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] RecipeID=" & strPPID)
        DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] Recipe Check Request On")
        WriteMAddr(MyEQMAddr.m_nRecipeCheckRequest(nEQIndex), True)
    End Sub

    Public Sub EQRecipeParameterQuery(ByVal nEQIndex As Integer, ByVal strPPID As String)
        Dim anPPID(LEN_A_RECIPE_QUERY_REQUEST_ID) As Integer

        g_strRecipeQueryPPID(nEQIndex) = strPPID

        ASCStringConvert(strPPID, LEN_A_RECIPE_QUERY_REQUEST_ID, anPPID)
        WriteZRArrayAddr(MyEQZRAddr.m_nRecipeQueryReq(nEQIndex), anPPID)

        DebugLog(eIFIndex.INDEX_EQ, eLogType.[METHOD], "EQ Index[" & nEQIndex & "] RecipeID[" & strPPID & "] ,Recipe Query Request On")
        WriteMAddr(MyEQMAddr.m_nEQRecipeQueryReq(nEQIndex), True)
    End Sub
#End Region

#Region "RST IF Method"

    Public Property SetBufferDisable(ByVal nBuffer As Integer, ByVal nSlot As Integer) As Boolean
        Get
            DebugLog(eIFIndex.INDEX_RST, eLogType.PROPERTY, "Get Buffer[" & nBuffer & "],Slot[" & nSlot & "] Disable = " & mvarBufferDisable(nBuffer, nSlot).ToString)
            Return mvarBufferDisable(nBuffer, nSlot)
        End Get
        Set(ByVal value As Boolean)
            DebugLog(eIFIndex.INDEX_RST, eLogType.PROPERTY, "Set Buffer[" & nBuffer & "],Slot[" & nSlot & "] Disable = " & value.ToString)
            Select Case nBuffer
                Case 1
                    WriteMAddr(MyRSTMAddr.mnBufferDisable1 + nSlot - 1, value)
                Case 2
                    WriteMAddr(MyRSTMAddr.mnBufferDisable2 + nSlot - 1, value)
                Case 3
                    WriteMAddr(MyRSTMAddr.mnBufferDisable3 + nSlot - 1, value)
            End Select

        End Set
    End Property

    Public Sub ManualProcessSampleGlass(ByVal nEQIndex As Integer)
        'M9021~9023
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Sampling For EQ[" & nEQIndex & "]")

        WriteMAddr(MyRSTMAddr.mnManualSampleGlass(nEQIndex), True)
    End Sub

    Public Sub RSTArmGlassErase(ByVal nArm As eRSTArm)
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Glass Erase Arm=" & IIf(nArm = eRSTArm.ARM_UPPER, "Upper", "Lower"))

        If nArm = eRSTArm.ARM_UPPER Then
            WriteMAddr(MyRSTMAddr.mnRSTUpperArmGlassErase, True)
        ElseIf nArm = eRSTArm.ARM_LOWER Then
            WriteMAddr(MyRSTMAddr.mnRSTLowerArmGlassErase, True)
        End If
    End Sub

    Public Sub RSTBufferGlassEraseRequest(ByVal nPosition As Integer, ByVal nSlotNo As Integer)
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Buffer Glass Erase Request ,SlotNo =" & nSlotNo & " ,Position =" & nPosition)

        WriteZRAddr(MyRSTZRAddr.RobotEraseBufSlot, nSlotNo)
        WriteZRAddr(MyRSTZRAddr.RobotEraseBufPosition, nPosition)

        WriteMAddr(MyRSTMAddr.mnRSTBufferGlassEraseRequest, True)
    End Sub

    Public Sub RSTBuzzerControl(ByVal nBuzzerMode As Integer, ByVal fOnOff As Boolean)
        Dim nResetBuzzerAddr As Integer = 9039

        If nBuzzerMode = 1 Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Buzzer1" & IIf(fOnOff, "On", "Off"))
            WriteMAddr(MyRSTMAddr.mnRSTBuzzer1, fOnOff)
            If Not fOnOff Then
                WriteMAddr(nResetBuzzerAddr, True)
            End If
        ElseIf nBuzzerMode = 2 Then
            DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Buzzer2" & IIf(fOnOff, "On", "Off"))
            WriteMAddr(MyRSTMAddr.mnRSTBuzzer2, fOnOff)
        End If
    End Sub

    Public Sub RSTLightTowerControl(ByVal nLightTower As eLightTower, ByVal nStatus As eLightTowerStatus)
        Select Case nLightTower
            Case eLightTower.TOWER_R
                If nStatus <> eLightTowerStatus.TOWER_BLINK Then
                    WriteMAddr(MyRSTMAddr.mnRSTTowerRBlink, False)

                    If nStatus = eLightTowerStatus.TOWER_ON Then
                        WriteMAddr(MyRSTMAddr.mnRSTTowerR, True)
                    Else
                        WriteMAddr(MyRSTMAddr.mnRSTTowerR, False)
                    End If
                Else
                    WriteMAddr(MyRSTMAddr.mnRSTTowerR, False)
                    WriteMAddr(MyRSTMAddr.mnRSTTowerRBlink, True)
                End If
            Case eLightTower.TOWER_Y
                If nStatus <> eLightTowerStatus.TOWER_BLINK Then
                    WriteMAddr(MyRSTMAddr.mnRSTTowerYBlink, False)

                    If nStatus = eLightTowerStatus.TOWER_ON Then
                        WriteMAddr(MyRSTMAddr.mnRSTTowerY, True)
                    Else
                        WriteMAddr(MyRSTMAddr.mnRSTTowerY, False)
                    End If
                Else
                    WriteMAddr(MyRSTMAddr.mnRSTTowerY, False)
                    WriteMAddr(MyRSTMAddr.mnRSTTowerYBlink, True)
                End If
            Case eLightTower.TOWER_G
                If nStatus <> eLightTowerStatus.TOWER_BLINK Then
                    WriteMAddr(MyRSTMAddr.mnRSTTowerGBlink, False)

                    If nStatus = eLightTowerStatus.TOWER_ON Then
                        WriteMAddr(MyRSTMAddr.mnRSTTowerG, True)
                    Else
                        WriteMAddr(MyRSTMAddr.mnRSTTowerG, False)
                    End If
                Else
                    WriteMAddr(MyRSTMAddr.mnRSTTowerG, False)
                    WriteMAddr(MyRSTMAddr.mnRSTTowerGBlink, True)
                End If
        End Select
    End Sub

    Public Sub RSTHomePosition()

        WriteZRAddr(MyRSTZRAddr.RobotCmdAction, eRSTAction.HOME)
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Manual,Robot Position=Home")
        WriteMAddr(MyRSTMAddr.mnRobotStart, True)
    End Sub

    Public Sub RSTCommand(ByVal nRobotToGo As eRSTPOSITIONTYPE, ByVal nRobotArm As eRSTArm, ByVal nRobotAction As eRSTAction, ByVal nRSTPosition As Integer, ByVal nSlotNo As Integer, ByVal nGlassType As eGlassThickness, ByVal nRSTSpeed As eRobotSpeed)

        WriteZRAddr(MyRSTZRAddr.RobotCmdToGo, nRobotToGo)

        WriteZRAddr(MyRSTZRAddr.RobotCmdArm, nRobotArm)

        WriteZRAddr(MyRSTZRAddr.RobotCmdAction, nRobotAction)

        WriteZRAddr(MyRSTZRAddr.RoborPosition, nRSTPosition)

        WriteZRAddr(MyRSTZRAddr.RobotCmdSlotInfo, nSlotNo)

        WriteZRAddr(MyRSTZRAddr.RobotCmdGlassType, nGlassType)

        WriteZRAddr(MyRSTZRAddr.RobotSpeed, nRSTSpeed)

        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "StageType=" & nRobotToGo.ToString & "," & nRobotArm.ToString & ",Command=" & nRobotAction.ToString & ",Position=" & nRSTPosition & ",Slot=" & nSlotNo & " ,Robot Manual Command...")
        WriteMAddr(MyRSTMAddr.mnRobotStart, True)
    End Sub

    Public Sub RSTAlarmReset()
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Alarm Reset On")
        WriteMAddr(MyRSTMAddr.mnRobotErrorReset, True)
    End Sub

    Public Sub SyncDateTime(ByVal DateTime As clsDateTime)
        'Dim strYear As String = ""
        'Dim nYear As Integer
        'Dim nDataWord1 As Integer
        'Dim nDataWord2 As Integer
        'Dim nDataWord3 As Integer

        'strYear = Mid(CStr(DateTime.nYear), 3, 2)
        'nYear = Val(strYear)
        'nDataWord1 = (nYear * 256) + DateTime.nMonth
        'nDataWord2 = (DateTime.nDay * 256) + DateTime.nHour
        'nDataWord3 = (DateTime.nMinute * 256) + DateTime.nSecond


        With DateTime
            WriteZRAddr(MyRSTZRAddr.RobotYear, .nYear)
            WriteZRAddr(MyRSTZRAddr.RobotMonth, .nMonth)
            WriteZRAddr(MyRSTZRAddr.RobotDay, .nDay)
            WriteZRAddr(MyRSTZRAddr.RobotHour, .nHour)
            WriteZRAddr(MyRSTZRAddr.RobotMinute, .nMinute)
            WriteZRAddr(MyRSTZRAddr.RobotSeacond, .nSecond)
            WriteZRAddr(MyRSTZRAddr.RobotWeek, .nWeek)
        End With

        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Syn Data On")
        WriteMAddr(MyRSTMAddr.mnSyncDateTime, True)
        'm_fSyncDateTime = True
    End Sub

    Public Sub RSTPauseRequest()
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Pause Request")
        Call WriteMAddr(MyRSTMAddr.mnRobotPauseRequest, True)
    End Sub

    Public Sub RSTResumeRequest()
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Resume Request")
        Call WriteMAddr(MyRSTMAddr.mnRobotResumeRequest, True)
    End Sub

    Public Sub RSTInterfaceCheck(ByVal fByPass As Boolean)
        DebugLog(eIFIndex.INDEX_RST, eLogType.[METHOD], "Robot Interface Check " & IIf(fByPass, "On", "Off"))
        Call WriteMAddr(MyRSTMAddr.mnRobotInterfaceCheck, fByPass)
    End Sub

#End Region

#Region "CV IF Property"
    Public ReadOnly Property CVLink(ByVal nCV As Integer) As Boolean
        Get
            Return IIf(MyCVNewWord.mnCVLinkStatus(nCV) = eLinkStatus.LINKING, True, False)
        End Get
    End Property

    Public ReadOnly Property CVPortStatus(ByVal nPortNo As Integer) As eCSTCmdStatus
        Get
            Return mvarCVPortStatus(nPortNo)
        End Get
    End Property

    Public ReadOnly Property CVToolID() As String
        Get
            mvarCVToolID = ReadCVToolID()
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV ToolID =" & mvarCVToolID)
            Return mvarCVToolID
        End Get
    End Property

    Public ReadOnly Property EQToolID(ByVal nEQIndex As Integer) As String
        'ZR511~522
        Get
            mvarEQToolID(nEQIndex) = ReadEQToolID(nEQIndex)
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "EQ[" & nEQIndex & "] ToolID =" & mvarEQToolID(nEQIndex))
            Return mvarEQToolID(nEQIndex)
        End Get
    End Property

    Public ReadOnly Property CVGlassExistOnConveyor() As Integer
        Get
            mvarCVGlassExistOnConveyor = ReadGxExistOnCV()
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV GxExistOnCV =" & mvarCVGlassExistOnConveyor)
            Return mvarCVGlassExistOnConveyor
        End Get
    End Property

    Public ReadOnly Property CVVCREnable(ByVal nVCRPos As Integer) As Boolean
        Get
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Port[" & nVCRPos & "] CV VCR Enable " & IIf(mvarCVVCREnable(nVCRPos), "On", "Off"))
            Return mvarCVVCREnable(nVCRPos)
        End Get
    End Property

    Public ReadOnly Property CVWithCassette(ByVal nPortNo As Integer) As Boolean
        Get
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Port[" & nPortNo & "] CV With Cassette " & IIf(mvarCVWithCassette(nPortNo), "On", "Off"))
            Return mvarCVWithCassette(nPortNo)
        End Get
    End Property

    Public ReadOnly Property CVPortMode(ByVal nPortNo As Integer) As ePortMode
        Get
            mvarCVPortMode(nPortNo) = ReadCVPortMode(nPortNo)
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Port[" & nPortNo & "] Port Mode =" & mvarCVPortMode(nPortNo).ToString)
            Return mvarCVPortMode(nPortNo)
        End Get
    End Property

    Public ReadOnly Property CVPortType(ByVal nPortNo As Integer) As eUnloadType
        Get
            mvaCVPortType(nPortNo) = ReadCVPortType(nPortNo)
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Port[" & nPortNo & "] Port Type =" & mvaCVPortType(nPortNo).ToString)
            Return mvaCVPortType(nPortNo)
        End Get
    End Property

    Public ReadOnly Property CVPortEnable(ByVal nPortNo As Integer) As Boolean
        Get
            mvarCVPortEnable(nPortNo) = IIf(MyCVNewWord.mnPortDisable(nPortNo) = SIGNAL_ON, False, True)
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Port[" & nPortNo & "] Port Enable " & IIf(mvarCVPortEnable(nPortNo), "On", "Off"))
            Return mvarCVPortEnable(nPortNo)
        End Get
    End Property

    Public ReadOnly Property CVStatus() As eEQStatus
        Get
            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Status =" & mvarCVStatus.ToString)
            Return mvarCVStatus
        End Get
    End Property

    'For Status Report== CST Product Code ==
    Public ReadOnly Property CVPortProdCode(ByVal nPortNo As Integer) As String
        Get
            mvarCVPortProdCode(nPortNo) = ReadCSTProductCode(nPortNo)

            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Port[" & nPortNo & "] CST Product Code =" & mvarCVPortProdCode(nPortNo))
            Return mvarCVPortProdCode(nPortNo)
        End Get
    End Property

    'Total Gx In Specified Port
    Public ReadOnly Property CVPortWIP(ByVal nPortNo As Integer) As Integer
        Get
            Select Case nPortNo
                Case 1
                    Call ReadUnloadStatusTotalGXQty(eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_1)
                Case 2
                    Call ReadUnloadStatusTotalGXQty(eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_2)
                Case 3
                    Call ReadUnloadStatusTotalGXQty(eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_3)
                Case 4
                    Call ReadUnloadStatusTotalGXQty(eCVDevicNo.UNLOAD_STATUS_TOTAL_GX_QTY_4)
            End Select

            mvarCVPortWIP(nPortNo) = MyCVNewWord.mnGlassQty(nPortNo)

            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "CV Port[" & nPortNo & "] Total Glass Qty =" & mvarCVPortWIP(nPortNo))
            Return mvarCVPortWIP(nPortNo)
        End Get
    End Property
#End Region

#Region "EQ IF Property"
    Public Sub DeleteEQGlassInfo(ByVal nEQ As Integer)
        DebugLog(eIFIndex.INDEX_EQ, eLogType.[PROPERTY], "EQ[" & nEQ & "],Delete Glass Info=" & True.ToString)
        WriteMAddr(MyEQMAddr.m_nEQDeleteStageGxData(nEQ), True)
    End Sub

    Private Property ArmGlassID(ByVal nEQIndex As Integer) As String
        Get
            Return mvarArmGlassID(nEQIndex)
        End Get

        Set(ByVal value As String)
            mvarArmGlassID(nEQIndex) = value
        End Set
    End Property

    Public ReadOnly Property EQLink(ByVal nEQ As Integer) As Boolean
        Get
            Return IIf(MyCVNewWord.mnEQLinkStatus(nEQ) = eLinkStatus.LINKING, True, False)
        End Get
    End Property

    Public Property RSTSetRobotInitial() As Boolean
        Get
            Dim nInitialRequest As Integer = 0

            nInitialRequest = GetRobotInitialRequest()
            mvarRobotInitialRequest = IIf(nInitialRequest = 1, True, False)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Get Robot Initial Request =" & mvarRobotInitialRequest)

            Return mvarRobotInitialRequest
        End Get
        Set(ByVal value As Boolean)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Robot Initial Request =" & value)
            WriteMAddr(MyRSTMAddr.mnRobotInit, value)
        End Set
    End Property

    Public Property RSTSetRobotCommandMode() As eRSTCommandMode
        Get
            Dim nCommand As Integer = 0

            nCommand = GetRobotStartcommand()
            Select Case nCommand
                Case 0
                    mvarRobotCommandMode = eRSTCommandMode.STOP
                Case 1
                    mvarRobotCommandMode = eRSTCommandMode.START
                Case Else
                    mvarRobotCommandMode = eRSTCommandMode.NA
            End Select

            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Get Robot Command Mode =" & mvarRobotCommandMode.ToString)

            Return mvarRobotCommandMode
        End Get
        Set(ByVal value As eRSTCommandMode)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Robot Command Mode =" & value.ToString)

            Select Case value
                Case eRSTCommandMode.START
                    WriteMAddr(MyRSTMAddr.mnRobotStop, False)
                    WriteMAddr(MyRSTMAddr.mnRSTStart, True)

                Case eRSTCommandMode.STOP
                    WriteMAddr(MyRSTMAddr.mnRSTStart, False)
                    WriteMAddr(MyRSTMAddr.mnRobotStop, True)

            End Select

        End Set
    End Property

    Public Property RSTSetRobotMode() As eRSTMode
        Get
            mvarRSTSetRobotMode = GetRobotMode()
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Get Robot Station Mode =" & mvarRSTSetRobotMode.ToString)

            Return mvarRSTSetRobotMode
        End Get
        Set(ByVal value As eRSTMode)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Robot Station Mode =" & value.ToString)

            Select Case value
                Case eRSTMode.AUTO
                    WriteMAddr(MyRSTMAddr.mnRobotModeManual, False)
                    WriteMAddr(MyRSTMAddr.mnRobotModeEng, False)

                    WriteMAddr(MyRSTMAddr.mnRobotModeAuto, True)

                Case eRSTMode.MANUAL
                    WriteMAddr(MyRSTMAddr.mnRobotModeAuto, False)
                    WriteMAddr(MyRSTMAddr.mnRobotModeEng, False)

                    WriteMAddr(MyRSTMAddr.mnRobotModeManual, True)
                Case eRSTMode.ENGINEER
                    WriteMAddr(MyRSTMAddr.mnRobotModeAuto, False)
                    WriteMAddr(MyRSTMAddr.mnRobotModeManual, False)

                    WriteMAddr(MyRSTMAddr.mnRobotModeEng, True)
            End Select

        End Set
    End Property


    Public Property RSTRemoteStatus() As eRMS
        Get
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Robot Remote Status =" & mvarRSTRemoteStatus.ToString)
            Return mvarRSTRemoteStatus
        End Get

        Set(ByVal value As eRMS)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Robot Remote Status =" & value.ToString)
            WriteZRAddr(MyRSTZRAddr.RobotRemoteStatus, value)
            mvarRSTRemoteStatus = value
        End Set
    End Property

    Public Property RSTColorRepairMode() As eColorRepairMode
        'ZR119
        Get
            Dim anValue(0) As Integer
            ReadZRAddr(MyRSTZRAddr.RobotColorRepairRunMode, anValue)
            mvarRSTColorRepairRunMode = anValue(0)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Get Repair Mode =" & mvarRSTColorRepairRunMode.ToString)
            Return mvarRSTColorRepairRunMode
        End Get
        Set(ByVal value As eColorRepairMode)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Repair Mode =" & value.ToString)

            WriteZRAddr(MyRSTZRAddr.RobotColorRepairRunMode, value)
            mvarRSTColorRepairRunMode = value
        End Set
    End Property

    Public Property RepairReviewMode() As Integer
        Get
            Dim nAddr As Integer = 120
            Dim anValue(0) As Integer

            ReadZRAddr(nAddr, anValue)
            mvarRepairReviewMode = anValue(0)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Get RepairReviewMode =" & mvarRepairReviewMode.ToString)
            Return mvarRepairReviewMode
        End Get
        Set(ByVal value As Integer)
            Dim nAddr As Integer = 120

            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set RepairReviewMode =" & value.ToString)
            WriteZRAddr(nAddr, value)
            mvarRepairReviewMode = value
        End Set
    End Property


    Public ReadOnly Property EQStatus(ByVal nEQIndex As Integer) As eEQStatus
        Get
            mvarEQStatus(nEQIndex) = MyEQNewWord.mnEQStatus(nEQIndex)

            DebugLog(eIFIndex.INDEX_EQ, eLogType.[PROPERTY], "EQ[" & nEQIndex & "] Status = " & mvarEQStatus(nEQIndex).ToString)
            Return mvarEQStatus(nEQIndex)
        End Get
    End Property

    Public ReadOnly Property EQWithGlass(ByVal nEQIndex As Integer) As Boolean
        Get
            DebugLog(eIFIndex.INDEX_EQ, eLogType.[PROPERTY], "EQ With Glass " & IIf(mvarEQWithGlass(nEQIndex), "On", "Off"))
            Return mvarEQWithGlass(nEQIndex)
        End Get
    End Property

#End Region

#Region "RST IF Property"
    Public WriteOnly Property ResetMileage() As Boolean
        Set(ByVal value As Boolean)
            Dim nResetMileage As Integer = 9040
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "ResetMileage-" & value.ToString)

            WriteMAddr(nResetMileage, value)
        End Set
    End Property

    Public ReadOnly Property RobotMileageInfo() As Integer()
        Get
            Dim anMileageInfo(6) As Integer
            anMileageInfo = ReadRobotMileageInfo()
            'DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "RobotMileageInfo,1[" & anMileageInfo(1).ToString & "],2[" & anMileageInfo(2).ToString & "],3[" & anMileageInfo(3).ToString & "],4[" & anMileageInfo(4).ToString & "],5[" & anMileageInfo(5).ToString & "],6[" & anMileageInfo(6).ToString & "]")
            Return anMileageInfo
        End Get
    End Property

    Public WriteOnly Property SetRobotStandBy() As Boolean
        'M9037 
        Set(ByVal value As Boolean)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Robot StandyBy =" & value.ToString)

            WriteMAddr(MyRSTMAddr.mnRobotStandBy, value)
        End Set
    End Property


    Public WriteOnly Property RSTSetPMMode() As Boolean
        'M9033 
        Set(ByVal value As Boolean)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Robot PM Mode =" & value.ToString)

            WriteMAddr(MyRSTMAddr.mnRobotPM, value)
        End Set
    End Property


    Public ReadOnly Property CVPortMiniSlot(ByVal nPortNo As Integer) As Integer
        Get
            Dim nQty As Integer = 0

            nQty = ReadCVPortMiniSlot(nPortNo)

            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "Port[" & nPortNo & "]Get Mini Slot = " & nQty)

            Return nQty
        End Get
    End Property


    Public ReadOnly Property CVFlowInQty(ByVal nPortNo As Integer) As Integer
        Get
            Dim nQty As Integer = 0

            nQty = ReadFlowInQty(nPortNo)

            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "Port[" & nPortNo & "]Get FlowIn Qty = " & nQty)

            Return nQty
        End Get
    End Property

    Public ReadOnly Property CVFlowOutQty(ByVal nPortNo As Integer) As Integer
        Get
            Dim nQty As Integer = 0

            nQty = ReadFlowOutQty(nPortNo)

            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "Port[" & nPortNo & "]Get FlowOut Qty = " & nQty)

            Return nQty
        End Get
    End Property

    Public ReadOnly Property CVProcessStartQty(ByVal nPortNo As Integer) As Integer
        Get
            Dim nQty As Integer = 0

            nQty = ReadProcessStartQty(nPortNo)

            DebugLog(eIFIndex.INDEX_CV, eLogType.[PROPERTY], "Port[" & nPortNo & "]Get ProcessStart Qty = " & nQty)

            Return nQty
        End Get
    End Property

    Private WriteOnly Property RSTDIOTestMode() As Boolean
        Set(ByVal value As Boolean)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], " DIO Test mode =" & value)
            WriteMAddr(MyRSTMAddr.mnRobotDioTestMode, value)
        End Set
    End Property

    Public Property OpenCVGUISignal() As Boolean
        Get
            Return mvarShowCVGUI
        End Get
        Set(ByVal value As Boolean)
            If value Then
                g_fMyCVGUITimerStart = True
            Else
                g_fMyCVGUITimerStart = False
            End If
            mvarShowCVGUI = value
        End Set
    End Property

    Public Property CVGUIEngineerMode() As Boolean
        Get
            Return g_fCVEngineerMode
        End Get
        Set(ByVal value As Boolean)
            'RSTDIOTestMode = value
            g_fCVEngineerMode = value
        End Set
    End Property

    Public Property OpenEQGUISignal() As Boolean
        Get
            Return mvarShowEQGUI
        End Get
        Set(ByVal value As Boolean)
            If value Then
                g_fMyEQGUITimerStart = True
            Else
                g_fMyEQGUITimerStart = False
            End If
            mvarShowEQGUI = value
        End Set
    End Property

    Public Property EQGUIEngineerMode() As Boolean
        Get
            Return g_fEQEngineerMode
        End Get
        Set(ByVal value As Boolean)
            'RSTDIOTestMode = value
            g_fEQEngineerMode = value
        End Set
    End Property

    Public Property OpenGeneralGUISignal() As Boolean
        Get
            Return mvarShowCVEQGUI
        End Get
        Set(ByVal value As Boolean)
            If value Then
                g_fMyGeneralGUITimerStart = True
            Else
                g_fMyGeneralGUITimerStart = False
            End If
            mvarShowCVEQGUI = value
        End Set
    End Property

    Public ReadOnly Property RSTCommandConfirm() As Boolean
        Get
            Return mvarRSTCommandPossible
        End Get
    End Property

    Public Property EQTranfserMode(ByVal nEQindex As Integer) As eTrfMode
        Get
            Return mvarEQTranfserMode(nEQindex)
        End Get
        Set(ByVal value As eTrfMode)
            If nEQindex <= 0 Or nEQindex > MAX_EQ Then Exit Property

            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "EQ[" & nEQindex & "] Transfer mode =" & IIf(value = 1, "Transfer", "Process"))
            WriteMAddr(MyRSTMAddr.mnRSTEQTransferMode(nEQindex), IIf(value = 1, True, False))
            mvarEQTranfserMode(nEQindex) = value
        End Set
    End Property

    Public Property EQArmMode() As eArmMode
        Get
            Return mvarEQArmMode
        End Get
        Set(ByVal value As eArmMode)
            Select Case value
                Case eArmMode.ARM_DOUBLE
                    DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "EQ Arm mode =Double")
                Case eArmMode.ARM_SINGLE_UPPER
                    DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "EQ Arm mode =Single Upper")
                Case eArmMode.ARM_SINGLE_LOWER
                    DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "EQ Arm mode =Single Lower")
            End Select

            WriteZRAddr(MyRSTZRAddr.RobotEQArmMode, value)
            mvarEQArmMode = value
        End Set
    End Property

    Public Property EQIgnoreTimeout(ByVal nEQindex As Integer) As Boolean
        Get
            Return mvarEQIgnoreTimeout(nEQindex)
        End Get

        Set(ByVal fOnOff As Boolean)
            If nEQindex <= 0 Or nEQindex > MAX_EQ Then Exit Property

            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "EQ[" & nEQindex & "] IgnoreTimeout " & IIf(fOnOff, "On", "Off"))
            WriteMAddr(MyRSTMAddr.mnRSTEQIgnoreTimeout(nEQindex), fOnOff)
            mvarEQIgnoreTimeout(nEQindex) = fOnOff
        End Set
    End Property

    Public Property EQRunningMode() As eEQMode
        Get
            Dim nAddr As Integer = 116
            Dim anValue(0) As Integer

            ReadZRAddr(nAddr, anValue)
            mvarEQRunningMode = anValue(0)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Get Running Mode=" & mvarEQRunningMode.ToString)
            Return mvarEQRunningMode
        End Get
        Set(ByVal value As eEQMode)
            DebugLog(eIFIndex.INDEX_RST, eLogType.[PROPERTY], "Set Running Mode=" & value.ToString)
            mvarEQRunningMode = value
            WriteZRAddr(MyRSTZRAddr.RobotRunningMode, value)
            WriteMAddr(MyRSTMAddr.mnRSTRunningMode, True)
        End Set
    End Property

#End Region

#Region "Test Method"

    Public Sub TestFuctcionWriteBAddr(ByVal nAddr As Integer, ByVal fOnOff As Boolean)
        Call WriteBAddr(nAddr, fOnOff)
    End Sub

    Public Sub TestFuctcionWriteWAddr(ByVal nAddr As Integer, ByVal aWriteData() As Integer)
        Call WriteWArrayAddr(nAddr, aWriteData)
    End Sub

    Public Sub TestFuctcionWriteZRAddr(ByVal nAddr As Integer, ByVal aWriteData() As Integer)
        Call WriteZRArrayAddr(nAddr, aWriteData)
    End Sub

    'Public Sub test(ByVal nPortNo As Integer)
    '    Dim nFor As Integer
    '    Dim anReceiveData(2) As Integer
    '    Dim strTemp As String = ""
    '    Dim strTemp1 As String = ""

    '    ReadZRAddr(0, anReceiveData)

    '    For nFor = 0 To 2
    '        strTemp = strTemp & ConvertHiLowASCIIToString(anReceiveData(nFor))
    '    Next

    '    strTemp1 = MyStringTrim(strTemp)
    '    Debug.Print(Len(strTemp1))

    'End Sub

    'Public Sub TestGG(ByVal nPort As Integer)
    '    'Dim vG167Data As New clsS167LotInfo

    '    'ReadS167Data(nPort)
    '    'vG167Data = Get167Data(nPort)
    'End Sub

#End Region


End Class
