Module ModuleMain
    Public Const DateVersion = "20130319"

#If DEBUG Then
    Public Const INIFilePath = "D:\AUO\L8B\etc"
    Public Const LOGPATH = "D:\LOG\"
#Else
    Public Const INIFilePath = "D:\AUO\L8B\etc"
    Public Const LOGPATH = "D:\LOG\"
#End If

    Public Const MaxEQ = 3
    Public Const MaxCV = 1
    Public Const MaxPort = 3
    Public Const MaxBuffer = 3
    Public Const MaxbufferSlot = 25
    Public Const MAXCASSETTESLOT = 56
    Public Const MAXBUFFERSLOT12 = 12
    Public Const MAXBUFFERSLOT25 = 25
    Public Const MAXCONVEYSECtion = 6
    Public Const MAX_CHIPGRADE = 72

    Public Enum PORTSTATUS
        [NONE] = 0
        [DISABLE]
        '[EMPTY]
        [LOADREQUEST]
        [ARRIVAL]
        [PRESENT]
        [LOADCOMPLETE]
        [VIRTUALLOAD]
        '[VIRTUALLOADCOMPLETE]
        [READYTOSTART]
        [PROCESSWAIT]
        [PROCESSING]
        [LOTFINISHED]
        [CVUNLOADREQUEST]
        [CVUNLOADEDCOMPLETE]
        [UNLOADREQUEST]
        [REMOVE]
    End Enum

    Public Enum ePortFAStatus
        [NA]
        [LoadRequest]
        [Present]
        [LoadComplete]
        [PreUnload]
        [UnloadRequest]
        [UnloadComplete]
    End Enum

    Public Enum eSTATUS
        [NA] = 0
        [RUNNING]
        [IDLE]
        [DOWN]
        [INITIAL]
        [STOP]
    End Enum

    Public Enum eRobotPosition
        [NONE] = 0
        [Buffer1]
        [Buffer2]
        [Buffer3]
        [EQ1]
        [EQ2]
        [EQ3]
        [CVP1]
        [CVP2]
        [CVP3]
        [Port1]
        [Port2]
        [Port3]
        [ROBOT]
    End Enum

    Public Enum eRunningMode
        [NA] = 0
        [THROUGH]
        [MQC]
        [TAPE]
        [TAPEINK]
    End Enum

    Public Class MyMainStructure
        Public frmMain As FormMain
        Public frmShowQueue As New Queue
        Public frmCloseQueue As New Queue
        Public frmHideQueue As New Queue

        Public frmMaintenance As FormMaintenance
        Public dlgLinkStatus As DialogLinkStatus
        Public dlgParameters As DialogSystemParameter
        Public dlgMachineSetting As DialogMachineSetting
        Public dlgLogin As LoginForm
        Public dlgBufferGlassInfo As DialogBufferGlassInfo
        Public dlgRoboGlasInfo As DialogRobotGlassInfo
        Public dlgRecipeComfirm() As DialogRecipeComfirm
        Public dlgRecipeComfirmWGS() As DialogRecipeComfirmWithGlassSelection
        Public dlgCassetteInfo() As DialogCassetteInfo
        Public dlg765Timeout() As DialogMessage
        Public frmCassetteInfoText() As FormCassetteInfoText
        Public dlgChangePassword As LoginFormChangePassword

        Public dlgHostMessageHistory As DialogHostMessageHistory
        Public dlgRecipeManagement As DialogRecipeManagement
        Public dlgSECSRemoteMode As DialogSECSRemoteMode
        Public WithEvents dlgRetypePassWord As DialogRetypePassword

        Public CIM As clsCIMMain
        Public PLC As clsMainPLC
        Public Setting As ClsSetting
        Public Log As RainBowTech.clsLogFactory
        Public db As cDataBase
        Public Alarm As ClsAlarm
        Public RobotMon As AsynchronousSocketListener
        Public fBypassInterfaceCheck As Boolean


        Private Sub dlgRetypePassWord_ClickOK(ByVal vType As String, ByVal vPWD As String) Handles dlgRetypePassWord.ClickOK
            'Select Case vType
            '    Case "Close Program"
            '        ProgramEnd()
            'End Select

            If _L8B.Setting.User.Name = "" Then
                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Wrong User Name.", MsgBoxStyle.OkOnly, 5)
                WriteLog("UserID=" & _L8B.Setting.User.Name & " is not exist", LogMessageType.Warn)
            Else
                Dim Section As String = "Users"
                If vPWD = ReadINIString(Section, _L8B.Setting.User.Name & "Password") Then
                    If vType = "Close Program" Then
                        ProgramEnd()
                    End If
                Else
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Wrong Password.", MsgBoxStyle.OkOnly, 5)
                End If
            End If

        End Sub

        Public Sub New()
            ReDim dlgRecipeComfirm(MaxPort) 'as DialogRecipeComfirm
            ReDim dlgRecipeComfirmWGS(MaxPort) ' As DialogRecipeComfirmWithGlassSelection
            ReDim dlgCassetteInfo(MaxPort) 'As DialogCassetteInfo
            ReDim frmCassetteInfoText(MaxPort)
            ReDim dlg765Timeout(MaxPort) 'As DialogMessage

            For i As Integer = 1 To MaxPort
                dlgRecipeComfirm(i) = New DialogRecipeComfirm
                dlgRecipeComfirmWGS(i) = New DialogRecipeComfirmWithGlassSelection
                dlgCassetteInfo(i) = New DialogCassetteInfo
                dlgCassetteInfo(i).PortNo = i
                dlg765Timeout(i) = New DialogMessage
                frmCassetteInfoText(i) = New FormCassetteInfoText
                frmCassetteInfoText(i).PortNO = i
            Next
        End Sub
    End Class

    Public Class myInfoStructure
        Public Port() As CmyPortType
        Public Buffer() As CmyBuffer
        Public EQ() As CmyEQ
        Public CV As New CmyCV
        Public Robot As New CmyRobot
        Public PM As New CmyPM


        Public Class CmyPortType
            Public CassetteMode As L8BIFPRJ.clsPLC.ePortMode
            Public UnLoaderType As L8BIFPRJ.clsPLC.eUnloadType
            Public PortPos As Integer
            Public Present As Boolean
            Public PortFAStatus As ePortFAStatus
            Public PortEnable As Boolean
            Public FirstNonEmptySlot As Integer
            Public Recipe As cRecipe
            Public fPause As Boolean
            Public fDummyCancel As Boolean
            Public fLotDataCheckOK As Boolean
            Public HandOff As Boolean
            Public Glass() As L8BIFPRJ.clsS167SlotInfo    '56
            Public fGlassExist(MAXCASSETTESLOT) As Boolean  '56
            Public Map(MAXCASSETTESLOT) As Integer  '56
            Public InProcess As Boolean
            Public InProcessAbort As Boolean
            Public fUserCassetteUnLoadRequest As Boolean
            Public PortPauseRequest As Boolean
            Public PortPauseRequestDate As Date
            Public PPID As String
            Public Status As PORTSTATUS
            Public SuspendMessage As DialogMessage
            ''' ''''
            ''' 765
            Public MeasurementID As String
            Public ProductCategory As L8BIFPRJ.clsPLC.eProductCategory
            Public ProductCode As String


            ''  167
            Public CassetteID As String
            Public CassetteStatus As L8BIFPRJ.clsPLC.eCassetteStatus
            Public CassetteUnloadStatus As L8BIFPRJ.clsPLC.eUnloadStatus
            Public OperationID As String
            'Public PortMode As L8BIFPRJ.clsPLC.ePortMode
            Public PortType As L8BIFPRJ.clsPLC.eUnloadType
            Public TotalQtyInCassette As Integer


            Public fGlassExistFlowCV(3) As Boolean
            Public GlassFlowCV() As L8BIFPRJ.clsS167SlotInfo

            Public ReadOnly Property GlassCount()
                Get
                    Dim count = 0
                    For i As Integer = 1 To MAXCASSETTESLOT
                        If fGlassExist(i) Then
                            count += 1
                        End If
                    Next
                    Return count
                End Get
            End Property

            Public Sub CopyFrom167LotInfo(ByVal vLotInfo As L8BIFPRJ.clsS167LotInfo, ByVal v765Info As L8BIFPRJ.clsS765LotInfo)
                With vLotInfo
                    CassetteID = MyTrim(.CassetteID)
                    CassetteStatus = .CassetteStatus
                    CassetteUnloadStatus = .CassetteUnloadStatus
                    OperationID = .OperationID
                    CassetteMode = .PortMode
                    PortType = .PortType
                    TotalQtyInCassette = .TotalQtyInCassette

                    _L8B.CIM.LotInfo(PortPos).CassetteID = MyTrim(.CassetteID)
                    _L8B.CIM.LotInfo(PortPos).CassetteStatus = .CassetteStatus

                    _L8B.CIM.LotInfo(PortPos).OperationID = MyTrim(.OperationID)
                    TotalQtyInCassette = .TotalQtyInCassette

                    For i As Integer = MAXCASSETTESLOT To 1 Step -1
                        'add for Load mode no 
                        If .PortMode = L8BIFPRJ.clsPLC.ePortMode.LOAD Then
                            .Slots(i).GGRADE = v765Info.Slots(i).GlassGrade
                            .Slots(i).DGRADE = v765Info.Slots(i).DMQCGrade
                        End If
                        .Slots(i).CopyTo(mInfo.Port(PortPos).Glass(i))
                        If .Slots(i).GlassID.Length > 0 Then
                            mInfo.Port(PortPos).fGlassExist(i) = True
                            '_L8B.CIM.InserSlotToPort(PortPos, i)
                        End If
                    Next

                End With

            End Sub

            Public Sub CopyFrom765LotInfo(ByVal vLotInfo As L8BIFPRJ.clsS765LotInfo)
                With vLotInfo
                    CassetteID = MyTrim(.CassetteID)
                    PPID = MyTrim(.CurrentRecipe)

                    MeasurementID = MyTrim(.MeasurementID)
                    OperationID = MyTrim(.OperationID)
                    ProductCategory = .ProductCategory
                    If MyTrim(vLotInfo.ProductCode).Length > 0 Then
                        ProductCode = .ProductCode
                    Else
                        ProductCode = _L8B.PLC.L8BPLC.CVPortProdCode(PortPos)
                    End If

                    _L8B.CIM.LotInfo(PortPos).RecipeName = MyTrim(.CurrentRecipe)
                    _L8B.CIM.LotInfo(PortPos).ProductCode = ProductCode
                    _L8B.CIM.LotInfo(PortPos).ProductCategory = .ProductCategory
                    _L8B.CIM.LotInfo(PortPos).OperationID = MyTrim(.OperationID)
                End With
            End Sub

            Public Sub CopyToPortInfo()
                With _L8B.CIM.PortInfo(PortPos)
                    .CassetteID = CassetteID
                    .AGVMode = False
                    .CPPID = PPID

                    '.PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED


                    .PortPosition = PortPos
                    Select Case _L8B.Setting.Main.MachineType
                        Case ClsSetting.EMACHINETYPE.ButterFly
                            .PortType = _L8B.Setting.Main.GlassFlowMode
                            Select Case .PortType
                                Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                                    .PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_LDULD
                                    .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED
                                Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                                    .PortMode = CassetteMode

                            End Select

                        Case ClsSetting.EMACHINETYPE.FI
                            .PortType = prjSECS.clsEnumCtl.ePortType.TYPE_U
                            .PortMode = CassetteMode

                        Case ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                            .PortType = prjSECS.clsEnumCtl.ePortType.TYPE_U
                            .PortMode = CassetteMode

                    End Select

                    Select Case PortType
                        Case L8BIFPRJ.clsPLC.eUnloadType.AUTO
                            .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED

                        Case L8BIFPRJ.clsPLC.eUnloadType.GRAY
                            .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED

                        Case L8BIFPRJ.clsPLC.eUnloadType.MIX
                            .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_OK

                        Case L8BIFPRJ.clsPLC.eUnloadType.MIXNG
                            .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_NG

                        Case L8BIFPRJ.clsPLC.eUnloadType.NG
                            .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_NG

                        Case L8BIFPRJ.clsPLC.eUnloadType.OK
                            .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_OK

                    End Select

                    .WithCassette = _L8B.PLC.CassetteInPort(PortPos)
                End With
            End Sub

            Public Sub CopyToLotInfo(ByVal vLotInfo As L8BIFPRJ.clsS167LotInfo, ByVal v765Info As L8BIFPRJ.clsS765LotInfo)
                With _L8B.CIM.LotInfo(PortPos)
                    .CassetteID = CassetteID
                    .CassetteStatus = CassetteStatus
                    .CIMMessage = ""
                    .DateTime = Now
                    .DuringSlotsSelection = False
                    .IsLotDataReceived = _L8B.Setting.LoadLotDataDownload(PortPos)
                    .LotCancel = False
                    .MeasurementID = MeasurementID
                    .OperationID = OperationID
                    .OperatorID = ""
                    .PortPosition = PortPos
                    .PPIDChanged = False
                    .ProcessEndCode = prjSECS.clsEnumCtl.eProcessENDCode.NONE
                    .ProductCategory = ProductCategory
                    If vLotInfo.PortMode = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then
                        If mInfo.Port(PortPos).fGlassExist(MAXCASSETTESLOT) Then
                            .ProductCode = _L8B.PLC.L8BPLC.CVPortProdCode(PortPos)
                        End If
                    Else
                        .ProductCode = ProductCode
                    End If
                    .RecipeCode = False
                    If mInfo.Port(PortPos).fGlassExist(MAXCASSETTESLOT) Then
                        .RecipeName = mInfo.Port(PortPos).Glass(MAXCASSETTESLOT).LotRecipeID
                    Else
                        .RecipeName = ""
                    End If

                    .RecipeNeedConfirm = False
                    .ReturnCode = ""
                    .UnderSlotsSelection = False


                    For i As Integer = 1 To MAXCASSETTESLOT
                        If mInfo.Port(PortPos).fGlassExist(i) Then
                            With .Slots(i)
                                If MyTrim(vLotInfo.Slots(i).GlassID).Length > 0 Then
                                    If vLotInfo.PortMode = L8BIFPRJ.clsPLC.ePortMode.LOAD Then
                                        .GlassGrade = v765Info.Slots(i).GlassGrade
                                        .DMQCGrade = v765Info.Slots(i).DMQCGrade
                                    Else
                                        .GlassGrade = vLotInfo.Slots(i).GGRADE
                                        .DMQCGrade = vLotInfo.Slots(i).DGRADE
                                    End If
                                End If
                                .ChipGradeByString = vLotInfo.Slots(i).ChipGrade
                                .DMQCDownload = vLotInfo.Slots(i).DGRADE
                                .DMQCGrade = vLotInfo.Slots(i).DGRADE
                                .DMQCResult = vLotInfo.Slots(i).DGRADE
                                .DMQCToolID = vLotInfo.Slots(i).DMQCToolID
                                .FIFCFlag = vLotInfo.Slots(i).FIRMFLAG
                                .FIRemark = False
                                .GlassGrade = vLotInfo.Slots(i).GGRADE
                                .GlassGradeDownload = vLotInfo.Slots(i).GGRADE
                                .GlassID = MyTrim(vLotInfo.Slots(i).GlassID)
                                '.IsGlassProecssed = vLotInfo.Slots(i).
                                If GlassVisitEQ(mInfo.Port(PortPos).Glass(i)) > 0 Then
                                    .IsGlassProecssed = True
                                Else
                                    .IsGlassProecssed = False
                                End If
                                .LastLineID = v765Info.Slots(i).PLINEID
                                .LastOperationID = v765Info.Slots(i).POPERID
                                .LastPorcessToolID = v765Info.Slots(i).PTOOLID
                                .ProcessToolID = vLotInfo.Slots(i).PTOOLID
                                .ProcFlag = v765Info.Slots(i).ProcessedFlag
                                .PSHGroup = vLotInfo.Slots(i).PSHGroup
                                .Rework = vLotInfo.Slots(i).RWKFLAG
                                .Scrap = vLotInfo.Slots(i).SCRPFLAG
                            End With
                            _L8B.CIM.InserSlotToPort(PortPos, i)
                            _L8B.frmMain.RSTControl.CVGUIPort(PortPos).InsertGlassToCST(i)
                        Else
                            _L8B.frmMain.RSTControl.CVGUIPort(PortPos).RemoveGlassFromCST(i)
                        End If
                    Next
                End With
            End Sub

            Public Sub ClearProcessData()
                Present = False
                'PortFAStatus = ePortFAStatus.NA
                PortEnable = True
                CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE

                'CassetteInRemodeMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
                FirstNonEmptySlot = 0

                Recipe = Nothing
                fPause = False
                'fDummyCancel = False
                fLotDataCheckOK = False
                'Public HandOff As Boolean
                For i As Integer = 1 To MAXCASSETTESLOT
                    Glass(i).GlassID = ""
                    fGlassExist(i) = False
                Next
                'LotInfo = Nothing
                InProcess = False
                InProcessAbort = False
            End Sub

            Public Sub New()
                ReDim Glass(MAXCASSETTESLOT)
                ReDim GlassFlowCV(3)
                For i As Integer = 1 To MAXCASSETTESLOT
                    Glass(i) = New L8BIFPRJ.clsS167SlotInfo
                Next

                For i As Integer = 1 To 3
                    GlassFlowCV(i) = New L8BIFPRJ.clsS167SlotInfo
                Next
            End Sub
        End Class

        Public Class CmyEQ
            Public ID As Integer
            Public ToolID As String
            Public UnitID As Integer
            Public Status As eSTATUS
            Public Link As L8BIFPRJ.clsPLC.eLinkStatus
            Public HandOff As Boolean
            Public OnCheckingPPID As String
            Public fOnCheckingPPID As Boolean
            Public InProcess As Boolean
            Public fGlassExist As Boolean
            Public Glass As L8BIFPRJ.clsS167SlotInfo
            Public GlassIDShow As String
            Public fGlassExistShow As Boolean

            Public Sub New()
                Glass = New L8BIFPRJ.clsS167SlotInfo
            End Sub
        End Class

        Public Class CmyCV
            Public ID As Integer
            Public ToolID As String
            Public UnitID As Integer
            Public Status As L8BIFPRJ.clsPLC.eEQStatus
            Public Link As L8BIFPRJ.clsPLC.eLinkStatus
            Public VCREnable(3) As Boolean
            Public fGlassExistIDCVSection(6) As Boolean
            Public GlassIDCVSection(6) As String

            Public Sub New()
                UnitID = clsCIMMain.SECSUNIT.CV
            End Sub
        End Class

        Public Class CmyBuffer
            Public ID As Integer
            Public MaxSlot As Integer
            Public Glass(25) As L8BIFPRJ.clsS167SlotInfo
            Public fGlassExist(25) As Boolean
            Public BufferSlotType(25) As L8BIFPRJ.clsPLC.eBufferStatus
            Public GlassIDShow(25) As String
            Public fGlassExistShow(25) As Boolean
            Public fGlassReview(25) As Boolean

            Public Property BufferInfo(ByVal index As Integer) As L8BIFPRJ.clsPLC.eBufferStatus
                Get
                    'BufferSlotType(index) = _l8b.L8BPLC.BufferSlotType(ID, index)
                    Return BufferSlotType(index)
                End Get
                Set(ByVal value As L8BIFPRJ.clsPLC.eBufferStatus)
                    '_l8b.L8BPLC.BufferSlotType(ID, index) = value
                    BufferSlotType(index) = value
                End Set
            End Property
        End Class

        Public Class CmyRobot
            Public ID As Integer
            Public ToolID As String
            Public UnitID As Integer
            Public Mode As L8BIFPRJ.clsPLC.eRSTMode
            Public Status As L8BIFPRJ.clsPLC.eRSTStatus
            Public Glass(2) As L8BIFPRJ.clsS167SlotInfo
            Public fGlassExist(2) As Boolean
            Public GlassIDShow(2) As String
            Public fGlassExistShow(2) As Boolean

            Public Sub New()
                Glass(1) = New L8BIFPRJ.clsS167SlotInfo
                Glass(2) = New L8BIFPRJ.clsS167SlotInfo
                UnitID = clsCIMMain.SECSUNIT.RST
            End Sub
        End Class

        Public Class CmyPM
            Public Count As Integer
            Public RunCount As Integer
            Public Running As Boolean
            Public pFrom As Integer
            Public pTo As Integer
            Public Continued As Boolean
        End Class

        Public Sub New()
            Robot = New CmyRobot
            PM = New CmyPM

            ReDim Port(MaxPort)
            For i As Integer = 1 To MaxPort
                Port(i) = New CmyPortType
                With Port(i)
                    ReDim .Glass(MAXCASSETTESLOT)
                    ReDim .fGlassExist(MAXCASSETTESLOT)
                    ReDim .Map(MAXCASSETTESLOT)
                    .PortPos = i
                    .PortEnable = True
                    .HandOff = False
                    .fDummyCancel = False
                    .FirstNonEmptySlot = 0
                    .fLotDataCheckOK = False
                    .fPause = False
                    .Present = False
                End With
            Next

            ReDim Buffer(MaxBuffer)
            For i As Integer = 1 To MaxBuffer
                Buffer(i) = New CmyBuffer
                With Buffer(i)
                    ReDim .Glass(MAXBUFFERSLOT25)
                    ReDim .fGlassExist(MAXBUFFERSLOT25)
                    ReDim .BufferSlotType(MAXBUFFERSLOT25)
                    For j = 1 To MAXBUFFERSLOT25
                        .Glass(j) = New L8BIFPRJ.clsS167SlotInfo
                    Next
                End With
            Next

            ReDim EQ(MaxEQ)
            For i As Integer = 1 To MaxEQ
                EQ(i) = New CmyEQ
                Select Case i
                    Case 1
                        EQ(i).UnitID = clsCIMMain.SECSUNIT.EQ1

                    Case 2
                        EQ(i).UnitID = clsCIMMain.SECSUNIT.EQ2

                    Case 3
                        EQ(i).UnitID = clsCIMMain.SECSUNIT.EQ3

                End Select
            Next

        End Sub

    End Class

    Public _L8B As New MyMainStructure
    Public mInfo As New myInfoStructure

    Public Sub Main(ByVal vFrmMain As FormMain)
        _L8B.frmMain = vFrmMain
        With _L8B
            .dlgLinkStatus = New DialogLinkStatus
            .frmMaintenance = New FormMaintenance
            .dlgParameters = New DialogSystemParameter
            .dlgMachineSetting = New DialogMachineSetting
            .dlgHostMessageHistory = New DialogHostMessageHistory
            .dlgLogin = New LoginForm
            .dlgRecipeManagement = New DialogRecipeManagement
            .dlgSECSRemoteMode = New DialogSECSRemoteMode
            .dlgRetypePassWord = New DialogRetypePassword
            .dlgBufferGlassInfo = New DialogBufferGlassInfo
            .dlgRoboGlasInfo = New DialogRobotGlassInfo
            .dlgChangePassword = New LoginFormChangePassword
        End With

        InitialLog()
        InitSetting()
        InitDB()
        InitAlarm()
        InitPLC()
        InitCIM()
        InitRobotMonitor()
    End Sub

    Public Sub ProgramEnd()
        _L8B.Log.KillLogThreadProcess()

        With _L8B
            .CIM = Nothing
            .dlgLinkStatus.Close()
            .frmMaintenance.Close()
            .dlgParameters.Close()
            .dlgMachineSetting.Close()
            .dlgLogin.Close()
            .Setting = Nothing
            .frmMain.Close()
        End With

        End
    End Sub

    Public Sub ShowMessage(ByVal vType As DialogMessage.MESSAGE, ByVal vLevel As DialogMessage.MESSAGELEVEL, ByVal vMessage As String, Optional ByVal vButtonStyle As Microsoft.VisualBasic.MsgBoxStyle = MsgBoxStyle.OkCancel, Optional ByVal TimeOutSecond As Integer = 0, Optional ByVal vDefaultAnswer As Microsoft.VisualBasic.MsgBoxResult = MsgBoxResult.Cancel, Optional ByVal bBuzzeroffButton As Boolean = False, Optional ByVal nPort As Integer = 0)
        Dim dlgMessage As New DialogMessage
        dlgMessage.ShowMessage(vType, vLevel, vMessage, vButtonStyle, TimeOutSecond, vDefaultAnswer, bBuzzeroffButton, nPort)
    End Sub

    Public Function GetFreeBufferSlotForPort(ByVal nPort As Integer) As Integer
        Dim Count As Integer
        Select Case nPort
            Case 1
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE1, True)
            Case 2
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE2, True)
            Case 3
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE3, True)

            Case Else
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.LD, True)
        End Select
        WriteLog("GetTotalBufferSlotModeNumberForPort (" & nPort & ")=" & Count)
        Return Count
    End Function

    Public Function GetTotalBufferSlotModeNumber(ByVal eBufferMode As L8BIFPRJ.clsPLC.eBufferStatus, Optional ByVal bFreeCheck As Boolean = False) As Integer
        Dim nCount As Integer = 0
        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer 'NumberBufferSlot(eBufferMode - L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE1 + 1)
            nCount += GetBufferSlotModeNumber(i, eBufferMode, bFreeCheck)
        Next
        Return nCount
    End Function

    Public Function GetBufferSlotModeNumber(ByVal vBuffID As Integer, ByVal eBufferMode As L8BIFPRJ.clsPLC.eBufferStatus, ByVal bFreeCheck As Boolean) As Integer
        Dim nCount As Integer = 0

        If vBuffID <= MaxPort Then

            For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(vBuffID)
                If _L8B.PLC.BufferSlotType(vBuffID, i) = eBufferMode Then
                    If bFreeCheck Then
                        If Not mInfo.Buffer(vBuffID).fGlassExist(i) Then
                            nCount += 1
                        End If
                    Else
                        nCount += 1
                    End If
                End If
            Next
        Else

        End If
        Return nCount
    End Function

    Public Function GetTotalBufferSlotModeNumberForPort(ByVal nPort As Integer) As Integer
        Dim Count As Integer
        Select Case nPort
            Case 1
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE1)
            Case 2
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE2)
            Case 3
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.CASSETTE3)

            Case Else
                Count = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.LD)
        End Select
        WriteLog("GetTotalBufferSlotModeNumberForPort (" & nPort & ")=" & Count)
        Return Count
    End Function

    Public Function CassetteOnAnyPort() As Boolean
        For i As Integer = 1 To _L8B.Setting.Main.NumberPort
            If _L8B.PLC.CassetteInPort(i) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub SetPortStatus(ByVal nPort As Integer, ByVal eStatus As PORTSTATUS, Optional ByVal vMiniSlot As Integer = 0)
        Try

            If nPort > _L8B.Setting.Main.NumberPort OrElse nPort <= 0 Then
                Exit Sub
            End If

            _L8B.frmMain.UpdateCVPortGUI(nPort)
            _L8B.frmMain.GroupBoxGlassFlowMode.Enabled = Not CassetteOnAnyPort()
            'remark 20120524
            'UpdateUnitWIP(clsCIMMain.SECSUNIT.CV)
            '_L8B.CIM.UnitInfoChange(mInfo.CV.UnitID)

            If mInfo.Port(nPort).Status = eStatus Then
                WriteLog("[IGNORE] SetPortStaus PortID(" & nPort & ") Status =[" & mInfo.Port(nPort).Status.ToString & " ->" & eStatus.ToString & "]", LogMessageType.Info)
                Return
            ElseIf mInfo.Port(nPort).Status = PORTSTATUS.VIRTUALLOAD And eStatus = PORTSTATUS.LOADCOMPLETE Then
                WriteLog("[IGNORE] SetPortStaus PortID(" & nPort & ") Status =[" & mInfo.Port(nPort).Status.ToString & " ->" & eStatus.ToString & "]", LogMessageType.Info)
                Return
            ElseIf mInfo.Port(nPort).Status = PORTSTATUS.LOADCOMPLETE And eStatus = PORTSTATUS.VIRTUALLOAD Then
                WriteLog("[IGNORE] SetPortStaus PortID(" & nPort & ") Status =[" & mInfo.Port(nPort).Status.ToString & " ->" & eStatus.ToString & "]", LogMessageType.Info)
                Return
            Else
                WriteLog("SetPortStaus PortID(" & nPort & ") Status =[" & mInfo.Port(nPort).Status.ToString & " ->" & eStatus.ToString & "]", LogMessageType.Info)
            End If

            mInfo.Port(nPort).Status = eStatus
            Select Case eStatus
                Case PORTSTATUS.NONE

                Case PORTSTATUS.DISABLE
                    mInfo.Port(nPort).PortEnable = False
                    _L8B.CIM.PortDisable(nPort)
                    _L8B.CIM.PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_DISABLE
                    _L8B.CIM.PortInfoChanged(nPort)
                    _L8B.CIM.L8BCIM.S1F73PortDisable(nPort)

                    'Case PORTSTATUS.EMPTY
                    '    _L8B.frmMain.RSTControl.CVGUIPort(nPort).ResetCST()
                    '    _L8B.CIM.ClearLotData(nPort)
                    '    mInfo.Port(nPort).ClearProcessData()
                    '    mInfo.Port(nPort).PortEnable = True
                    '    _L8B.CIM.PortInfo(nPort).WithCassette = False
                    '    _L8B.CIM.PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY
                    '    '_L8B.CIM.PortInfoChanged(nPort)
                    '    _L8B.frmMain.RSTControl.CVGUIPort(nPort).PortRelease()
                    '    _L8B.frmMain.RSTControl.CVGUIPort(nPort).CSTDummyCancel = False

                Case PORTSTATUS.LOADREQUEST
                    mInfo.Port(nPort).PortEnable = True
                    _L8B.CIM.ClearLotData(nPort)
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).ResetCST()

                    With _L8B.CIM.PortInfo(nPort)
                        .WithCassette = False
                        .PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_LOADREQ
                    End With
                    _L8B.CIM.CassetteLoadRequest(nPort)
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).PortRelease()

                    With mInfo.Port(nPort)
                        For i As Integer = 1 To MAXCASSETTESLOT
                            .Glass(i).Clear()
                            .fGlassExist(i) = False
                        Next
                    End With

                Case PORTSTATUS.ARRIVAL
                    With mInfo.Port(nPort)
                        For i As Integer = 1 To MAXCASSETTESLOT
                            .Glass(i).Clear()
                            .fGlassExist(i) = False
                        Next
                    End With

                    mInfo.Port(nPort).CassetteMode = _L8B.PLC.CVPortMode(nPort)
                    With _L8B.CIM.PortInfo(nPort)
                        .WithCassette = True
                        .PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_CST_PRESENT
                    End With
                    _L8B.CIM.PortInfoChanged(nPort)
                    _L8B.CIM.CassetteArrived(nPort)

                Case PORTSTATUS.PRESENT
                    mInfo.Port(nPort).PortEnable = True
                    WriteLog("[IGNORE] not support in CV SetPortStaus PortID(" & nPort & ") Status =[" & mInfo.Port(nPort).Status.ToString & " ->" & eStatus.ToString & "]", LogMessageType.Info)

                Case PORTSTATUS.VIRTUALLOAD
                    If mInfo.Port(nPort).fDummyCancel Then
                        WriteLog("Dummy cancel finishing, cassette virtual Load.", LogMessageType.Info)
                    End If

                    _L8B.CIM.PortInfoExtra(nPort).CassetteInMode = _L8B.CIM.RemoteMode
                    _L8B.frmMain.SetRstguiCtrlCVCSTDummyCancelOff(nPort)
                    mInfo.Port(nPort).fDummyCancel = False

                    If vMiniSlot > 0 AndAlso _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then '_L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U
                        ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Non-Empty cassette In [U mode] as Unloader", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
                        _L8B.PLC.CassetteUnloadRequest(nPort)
                    ElseIf vMiniSlot = 0 AndAlso _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.LOAD Then 'AndAlso _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U
                        ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Empty cassette In MQC mode(U mode / Loader) cancel Cassette.", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
                        _L8B.PLC.CassetteUnloadRequest(nPort)
                        _L8B.CIM.SendHostMessage(GetAUODateTime(Now) & " Empty cassette arrival in Port:" & nPort & "as Loader ---> Cassette cancel.")
                        'ElseIf vMiniSlot = 0 AndAlso _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                        '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Empty cassette In MQC mode(I mode) cancel Cassette.", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
                        '    _L8B.PLC.CassetteUnloadRequest(nPort)
                        '    _L8B.CIM.SendHostMessage(GetAUODateTime(Now) & " Empty cassette arrival in Port:" & nPort & " in [MQC mode] ---> Cassette cancel.")
                    Else
                        _L8B.CIM.L8BCIM.S1F73VirtualCSTLoadComp(nPort)
                        _L8B.CIM.CassetteLoadComplete(nPort, vMiniSlot)
                    End If

                    If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                        If mInfo.Port(nPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.UNLOAD And _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                            If _L8B.Setting.Main.UnloaderOfflineAutoStart Then
                                _L8B.PLC.UploadLotData(nPort)
                            Else
                                _L8B.Log.Hide()
                                If MsgBox("Continue as Unload for Port=" & nPort & "?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                                    _L8B.PLC.UploadLotData(nPort)
                                End If
                            End If
                        Else
                            If vMiniSlot = 0 AndAlso _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.LOAD Then

                            Else
                                _L8B.dlgCassetteInfo(nPort).ShowMe(_L8B.frmMain)
                            End If
                        End If
                    End If


                Case PORTSTATUS.LOADCOMPLETE
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).ResetCST()
                    _L8B.CIM.PortInfoExtra(nPort).CassetteInMode = _L8B.CIM.RemoteMode
                    With _L8B.CIM.PortInfo(nPort)
                        .WithCassette = True
                        .PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_CST_PRESENT
                    End With

                    mInfo.Port(nPort).CassetteMode = _L8B.PLC.CVPortMode(nPort)
                    _L8B.CIM.PortInfoChanged(nPort)

                    If vMiniSlot > 0 AndAlso _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then '_L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U 
                        ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "not Empty cassette In [U mode] for unloader", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
                        _L8B.PLC.CassetteUnloadRequest(nPort)
                    ElseIf vMiniSlot = 0 AndAlso _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.LOAD Then ' AndAlso _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U
                        ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Empty cassette In MQC mode(U mode / Loader) cancel Cassette.", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
                        _L8B.PLC.CassetteUnloadRequest(nPort)
                        _L8B.CIM.SendHostMessage(GetAUODateTime(Now) & " Empty cassette Load in Port:" & nPort & " Loader ---> Cassette cancel.")
                        'ElseIf vMiniSlot = 0 AndAlso _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                        '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Empty cassette In MQC mode(I mode) cancel Cassette.", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
                        '    _L8B.PLC.CassetteUnloadRequest(nPort)
                        '    _L8B.CIM.SendHostMessage(GetAUODateTime(Now) & " Empty cassette Load in Port:" & nPort & " under [I mode] ---> Cassette cancel.")
                    Else
                        _L8B.CIM.CassetteLoadComplete(nPort, vMiniSlot)
                    End If

                    If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                        If mInfo.Port(nPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.UNLOAD And _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                            If vMiniSlot = 0 Then
                                If _L8B.Setting.Main.UnloaderOfflineAutoStart Then
                                    _L8B.PLC.UploadLotData(nPort)
                                Else
                                    _L8B.Log.Hide()
                                    If MsgBox("Continue as Unload for Port=" & nPort & "?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                                        _L8B.PLC.UploadLotData(nPort)
                                    End If
                                End If
                            End If
                        Else
                            If _L8B.Setting.User.Name <> "" Then
                                _L8B.dlgCassetteInfo(nPort).ShowMe(_L8B.frmMain)
                            End If
                        End If
                    End If

                Case PORTSTATUS.READYTOSTART

                Case PORTSTATUS.PROCESSWAIT
                    _L8B.CIM.PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_WAITSTART
                    If _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then
                        _L8B.CIM.LotInfo(nPort).RecipeName = _L8B.CIM.UnitInfo(0).CPPID
                        _L8B.CIM.PortInfo(nPort).CPPID = _L8B.CIM.UnitInfo(0).CPPID
                    Else
                        'for S1F89 PPID after online report
                        _L8B.CIM.PortInfo(nPort).CPPID = _L8B.CIM.LotInfo(nPort).RecipeName
                        If MyTrim(_L8B.CIM.LotInfo(nPort).RecipeName).Length > 0 Then
                            _L8B.CIM.UnitInfo(0).CPPID = _L8B.CIM.LotInfo(nPort).RecipeName
                            _L8B.CIM.UnitInfoChange(0)
                            _L8B.CIM.UnitInfo(1).CPPID = _L8B.CIM.LotInfo(nPort).RecipeName
                            _L8B.CIM.UnitInfoChange(1)
                        End If
                    End If
                    _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT)                    
                    _L8B.PLC.LotStart(nPort)

                Case PORTSTATUS.PROCESSING
                    _L8B.CIM.PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_PROCESSING
                    _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS)
                    mInfo.Port(nPort).InProcess = True
                    mInfo.Port(nPort).InProcessAbort = False

                Case PORTSTATUS.LOTFINISHED
                    _L8B.CIM.PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_END
                    _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_END)

                Case PORTSTATUS.CVUNLOADREQUEST
                    '2011-10-05 move to PLC_CVCSTUnloadRequest EVENT 
                    'If _L8B.CIM.LotInfo(nPort).IsLotDataReceived Then  'for only report which cassette has lotdata download 2011-10-04
                    '    If mInfo.Port(nPort).fUserCassetteUnLoadRequest Then 'And Not mInfo.Port(nPort).InProcessAbort Then
                    '        _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_END)
                    '    End If
                    'End If

                Case PORTSTATUS.CVUNLOADEDCOMPLETE
                    _L8B.CIM.PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_END_WITHUNLOAD
                    _L8B.CIM.CassetteUnloadRequest(nPort)

                Case PORTSTATUS.UNLOADREQUEST

                Case PORTSTATUS.REMOVE
                    _L8B.CIM.CassetteRemoved(nPort)
                    If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                        SetPortStatus(nPort, PORTSTATUS.LOADREQUEST)
                    End If
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).ResetCST()

            End Select
            _L8B.frmMain.UpdateCVPortGUI(nPort)

        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub


    Public Sub UpdateRemoteStatus()
        GUISECSModeChange()
        _L8B.dlgSECSRemoteMode.UpdateGUI()
        _L8B.dlgLinkStatus.UpdateSECSStatusGUI()
    End Sub

    Public Sub GUISECSModeChange()
        Select Case _L8B.CIM.RemoteMode
            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
                _L8B.frmMain.LabelRemodeMode.Text = "Off-Line"

            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
                _L8B.frmMain.LabelRemodeMode.Text = "On-Line Control"

            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
                _L8B.frmMain.LabelRemodeMode.Text = "On-Line Monitor"
        End Select
    End Sub

    Public Sub LoopBackResult(ByVal bResult As Boolean)
        _L8B.frmMain.ButtonLoopBack.Enabled = True
        If bResult Then
            _L8B.frmMain.ButtonLoopBack.BackColor = Color.Green
        Else
            _L8B.frmMain.ButtonLoopBack.BackColor = Color.Red
        End If
    End Sub

    Public Sub SetEQStatus(ByVal nEQ As Integer, ByVal nStatus As L8BIFPRJ.clsPLC.eEQStatus)
        If mInfo.EQ(nEQ).Status <> nStatus Then
            WriteLog(String.Format("EQ{0} status change --> {1}", nEQ, nStatus), LogMessageType.Info)
            mInfo.EQ(nEQ).Status = nStatus
            With _L8B.CIM.UnitInfo(mInfo.EQ(nEQ).UnitID)
                Select Case mInfo.EQ(nEQ).Status
                    Case eSTATUS.DOWN
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_DOWN

                    Case eSTATUS.IDLE
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_IDLE

                    Case eSTATUS.INITIAL
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_SETUP

                    Case eSTATUS.RUNNING
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING

                    Case eSTATUS.STOP
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_STOP

                End Select
            End With
            UpdateUnitWIP(mInfo.EQ(nEQ).UnitID)
            _L8B.CIM.UnitInfoChange(mInfo.EQ(nEQ).UnitID)
            _L8B.frmMain.UpdateEQStatus(nEQ)
        End If
    End Sub

    Public Sub UpdateUnitWIP(ByVal eUnit As clsCIMMain.SECSUNIT)
        Try


            Dim UnitID As Integer
            Dim WIP As Integer = GetWIP(eUnit)
            Select Case eUnit
                Case clsCIMMain.SECSUNIT.CV
                    UnitID = mInfo.CV.UnitID
                    With _L8B.CIM.UnitInfo(UnitID)
                        .WIPCount = WIP
                        .CPPID = ""
                        For i As Integer = 1 To MaxPort
                            For k As Integer = 1 To 3
                                If MyTrim(mInfo.Port(i).GlassFlowCV(k).GlassID).Length > 0 Then
                                    .CPPID = mInfo.Port(i).GlassFlowCV(k).LotRecipeID
                                    Exit For
                                End If
                            Next

                        Next
                    End With

                Case clsCIMMain.SECSUNIT.EQ1
                    UnitID = mInfo.EQ(1).UnitID
                    With _L8B.CIM.UnitInfo(UnitID)
                        .WIPCount = WIP
                        If WIP > 0 AndAlso mInfo.EQ(1).fGlassExist Then
                            .CPPID = mInfo.EQ(1).Glass.LotRecipeID
                        Else
                            .CPPID = ""
                        End If
                    End With

                Case clsCIMMain.SECSUNIT.EQ2
                    UnitID = mInfo.EQ(2).UnitID
                    With _L8B.CIM.UnitInfo(UnitID)
                        .WIPCount = WIP
                        If WIP > 0 AndAlso mInfo.EQ(2).fGlassExist Then
                            .CPPID = mInfo.EQ(2).Glass.LotRecipeID
                        Else
                            .CPPID = ""
                        End If
                    End With

                Case clsCIMMain.SECSUNIT.EQ3
                    UnitID = mInfo.EQ(3).UnitID
                    With _L8B.CIM.UnitInfo(UnitID)
                        .WIPCount = WIP
                        If WIP > 0 AndAlso mInfo.EQ(3).fGlassExist Then
                            .CPPID = mInfo.EQ(3).Glass.LotRecipeID
                        Else
                            .CPPID = ""
                        End If
                    End With

                Case clsCIMMain.SECSUNIT.RST
                    UnitID = mInfo.Robot.UnitID
                    With _L8B.CIM.UnitInfo(UnitID)
                        .WIPCount = WIP
                        If mInfo.Robot.Glass(1).GlassID <> "" AndAlso mInfo.Robot.fGlassExist(1) Then
                            .CPPID = mInfo.Robot.Glass(1).LotRecipeID
                        ElseIf mInfo.Robot.Glass(2).GlassID <> "" AndAlso mInfo.Robot.fGlassExist(2) Then
                            .CPPID = mInfo.Robot.Glass(2).LotRecipeID
                        Else
                            .CPPID = ""
                        End If
                    End With
            End Select


        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try

    End Sub

    Public Function GetWIP(ByVal eUnit As clsCIMMain.SECSUNIT) As Integer
        Dim count As Integer = 0

        Select Case eUnit
            Case clsCIMMain.SECSUNIT.CV
                For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                    For j = 1 To MAXCASSETTESLOT
                        With mInfo.Port(i)
                            'If .fGlassExist(j) And .Glass(j).GlassID <> "" Then
                            '    count += 1
                            'End If
                        End With
                    Next
                Next

                For i As Integer = 1 To 3
                    For k As Integer = 1 To 3
                        With mInfo.CV
                            If mInfo.Port(i).GlassFlowCV(k).GlassID <> "" Then
                                count += 1
                            End If
                        End With
                    Next

                Next

                Return count

            Case clsCIMMain.SECSUNIT.EQ1
                With mInfo.EQ(1)
                    If .fGlassExist And .Glass.GlassID <> "" Then
                        Return 1
                    Else
                        Return 0
                    End If
                End With

            Case clsCIMMain.SECSUNIT.EQ2

                With mInfo.EQ(2)
                    If .fGlassExist And .Glass.GlassID <> "" Then
                        Return 1
                    Else
                        Return 0
                    End If
                End With

            Case clsCIMMain.SECSUNIT.EQ3

                With mInfo.EQ(3)
                    If .fGlassExist And .Glass.GlassID <> "" Then
                        Return 1
                    Else
                        Return 0
                    End If
                End With

            Case clsCIMMain.SECSUNIT.RST
                For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                    With mInfo.Buffer(i)
                        For j = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                            If .fGlassExist(j) And .Glass(j).GlassID <> "" Then
                                count += 1
                            End If
                        Next
                    End With
                Next

                With mInfo.Robot
                    If .fGlassExist(1) And .Glass(1).GlassID <> "" Then
                        count += 1
                    End If

                    If .fGlassExist(2) And .Glass(2).GlassID <> "" Then
                        count += 1
                    End If
                End With
                Return count
        End Select
    End Function


    Public Sub SetCVStatus(ByVal nNewStatus As L8BIFPRJ.clsPLC.eEQStatus)
        If mInfo.CV.Status <> nNewStatus Then
            WriteLog(String.Format("CV status change --> {0}", nNewStatus), LogMessageType.Info)
            mInfo.CV.Status = nNewStatus
            _L8B.frmMain.UpdateCVStatus()
            With _L8B.CIM.UnitInfo(mInfo.CV.UnitID)
                Select Case mInfo.CV.Status
                    Case L8BIFPRJ.clsPLC.eEQStatus.DOWN
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_DOWN
                    Case L8BIFPRJ.clsPLC.eEQStatus.IDLE
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_IDLE
                    Case L8BIFPRJ.clsPLC.eEQStatus.RUNNING
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING
                    Case L8BIFPRJ.clsPLC.eEQStatus.SETUP
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_SETUP
                    Case L8BIFPRJ.clsPLC.eEQStatus.STOPPED
                        .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_STOP
                End Select
            End With
            UpdateUnitWIP(mInfo.CV.UnitID)
            _L8B.CIM.UnitInfoChange(mInfo.CV.UnitID)
        End If
    End Sub

    Public Function InsertPortGlassData(ByVal nPort As Integer) As Integer
        Dim mSlot As Integer
        Dim mRecipe As cRecipe = _L8B.db.LoadRecipe(_L8B.CIM.LotInfo(nPort).RecipeName)
        Dim mGlassCount As Integer = 0

        ClearPortGlassData(nPort)

        For i As Integer = 1 To MAXCASSETTESLOT
            With _L8B.CIM.LotInfo(nPort).Slots(i)
                mSlot = .SlotNo
                If mSlot > 0 AndAlso MyTrim(.GlassID).Length > 0 Then
                    mInfo.Port(nPort).Glass(mSlot).SlotNo = .SlotNo
                    mInfo.Port(nPort).Glass(mSlot).GlassID = MyTrim(.GlassID)
                    mInfo.Port(nPort).Glass(mSlot).RDRAGE = L8BIFPRJ.clsPLC.eRDGRADE.NO_GLASS
                    mInfo.Port(nPort).Glass(mSlot).DGRADE = .DMQCGrade
                    mInfo.Port(nPort).Glass(mSlot).GGRADE = .GlassGrade
                    mInfo.Port(nPort).Glass(mSlot).PSHGroup = .PSHGroup
                    mInfo.Port(nPort).Glass(mSlot).PTOOLID = .ProcessToolID
                    mInfo.Port(nPort).Glass(mSlot).DMQCToolID = .DMQCToolID
                    mInfo.Port(nPort).Glass(mSlot).ChipGrade = .ChipGradeByString
                    mInfo.Port(nPort).Glass(mSlot).FIRMFLAG = .FIFCFlag
                    mInfo.Port(nPort).Glass(mSlot).SCRPFLAG = .Scrap
                    mInfo.Port(nPort).Glass(mSlot).RWKFLAG = .Rework
                    mInfo.Port(nPort).Glass(mSlot).ProductCode = _L8B.CIM.LotInfo(nPort).ProductCode

                    mInfo.Port(nPort).Glass(mSlot).ProductCategory = _L8B.CIM.LotInfo(nPort).ProductCategory
                    mInfo.Port(nPort).Glass(mSlot).LotRecipeID = _L8B.CIM.LotInfo(nPort).RecipeName

                    mInfo.Port(nPort).Glass(mSlot).EQ1PPID = mRecipe.EQPPID(1)
                    mInfo.Port(nPort).Glass(mSlot).EQ2PPID = mRecipe.EQPPID(2)

                    mGlassCount += 1
                End If

            End With
        Next

        Return mGlassCount
    End Function

    Public Sub ClearPortGlassData(ByVal nPort As Integer)
        For i As Integer = 1 To MAXCASSETTESLOT
            With mInfo.Port(nPort).Glass(i)
                .GlassID = ""
                .RDRAGE = L8BIFPRJ.clsPLC.eRDGRADE.NO_GLASS
                .DGRADE = L8BIFPRJ.clsPLC.eDGRADE.NO_GLASS
                .GGRADE = L8BIFPRJ.clsPLC.eGGRADE.NO_GLASS
                .PSHGroup = ""
                .PTOOLID = ""
                .DMQCToolID = ""
                .ChipGrade = ""
                .FIRMFLAG = L8BIFPRJ.clsPLC.eFIRMFLAG.OTHERS
                .SCRPFLAG = L8BIFPRJ.clsPLC.eSCRPFLAG.MARKED_RECYCLED
                .RWKFLAG = L8BIFPRJ.clsPLC.eRWKFLAG.NORMAL_GLASS

                .ProductCategory = L8BIFPRJ.clsPLC.eProductCategory.NA
                .LotRecipeID = ""
                .EQ1PPID = ""
                .EQ2PPID = ""
                .EQEndTime(1) = ""
                .EQEndTime(2) = ""
                .EQEndTime(3) = ""
                .EQStartTime(1) = ""
                .EQStartTime(2) = ""
                .EQStartTime(3) = ""
            End With
        Next
    End Sub


    Public Sub UpdateProcessFlag(ByVal nPort As Integer)
        Try

            For i As Integer = 1 To MAXCASSETTESLOT
                With _L8B.CIM.LotInfo(nPort).Slots(i)
                    If .SlotNo > 0 Then
                        Select Case _L8B.Setting.Main.MachineType
                            Case ClsSetting.EMACHINETYPE.ButterFly

                                Select Case _L8B.Setting.Main.GlassFlowMode
                                    Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                                        If .SlotNo < mInfo.Port(nPort).FirstNonEmptySlot + mInfo.Port(nPort).Recipe.SampleGlass Then
                                            '20110315 by kent
                                            If mInfo.Port(nPort).Map(i) = 1 Then
                                                .ProcFlag = True
                                            Else
                                                .ProcFlag = False
                                            End If
                                        Else
                                            .ProcFlag = False
                                        End If
                                    Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                                        If mInfo.Port(nPort).Map(.SlotNo) = 1 And mInfo.Port(nPort).Recipe.SelectGlass(.SlotNo) = 1 Then
                                            .ProcFlag = True
                                        Else
                                            .ProcFlag = False
                                        End If
                                End Select

                            Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR
                                If mInfo.Port(nPort).Map(.SlotNo) = 1 And .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.GRAY Then
                                    .ProcFlag = True
                                Else
                                    .ProcFlag = False
                                End If

                            Case ClsSetting.EMACHINETYPE.FI
                                '20091105; now FI support I mode
                                Select Case _L8B.Setting.Main.GlassFlowMode
                                    Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                                        If .SlotNo < mInfo.Port(nPort).FirstNonEmptySlot + mInfo.Port(nPort).Recipe.SampleGlass Then
                                            '20110315 by kent
                                            If mInfo.Port(nPort).Map(i) = 1 Then
                                                .ProcFlag = True
                                            Else
                                                .ProcFlag = False
                                            End If
                                        Else
                                            .ProcFlag = False
                                        End If
                                    Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                                        If mInfo.Port(nPort).Map(.SlotNo) = 1 And mInfo.Port(nPort).Recipe.SelectGlass(.SlotNo) = 1 Then
                                            .ProcFlag = True
                                        Else
                                            .ProcFlag = False
                                        End If

                                        If mInfo.Port(nPort).Map(.SlotNo) = 1 And .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F Then
                                            .ProcFlag = True
                                        ElseIf mInfo.Port(nPort).Map(.SlotNo) = 1 And .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B Then
                                            .ProcFlag = False
                                        End If
                                End Select

                                'If mInfo.Port(nPort).Map(.SlotNo) = 1 And mInfo.Port(nPort).Recipe.SelectGlass(.SlotNo) = 1 Then
                                '    .ProcFlag = True
                                'Else
                                '    .ProcFlag = False
                                'End If
                                'If mInfo.Port(nPort).Map(.SlotNo) = 1 And .FIFCFlag = prjsecs.clsEnumCtl.eFIFCFlag.FLAG_F Then
                                '    .ProcFlag = True
                                'ElseIf mInfo.Port(nPort).Map(.SlotNo) = 1 And .FIFCFlag = prjsecs.clsEnumCtl.eFIFCFlag.FLAG_B Then
                                '    .ProcFlag = False
                                'End If
                        End Select
                        WriteLog(String.Format("PLC.S765DataDownload::Loader/{5}/({0}, {1}) =[{2}] / GLXGrd={6} / DMQCGrd={3} / ProcessFlag={4}", nPort, .SlotNo, .GlassID, .DMQCGrade.ToString, .ProcFlag, _L8B.Setting.Main.GlassFlowMode, .GlassGrade.ToString), LogMessageType.Info)
                    End If
                End With
            Next
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub


    Public Sub GlassTransfer(ByVal SourcePos As eRobotPosition, ByVal SourceSlot As Integer, ByVal TargetPos As eRobotPosition, ByVal TargetSlot As Integer)
        Dim SourceGlass As L8BIFPRJ.clsS167SlotInfo = GetGlassInfo(SourcePos, SourceSlot, False)
        Dim TargetGlass As L8BIFPRJ.clsS167SlotInfo = GetGlassInfo(TargetPos, TargetSlot, True)

        WriteLog(String.Format("Before GlassData Transfer [{4}] {0}.{1} -> {2}.{3} [{5}] {6}  (SRC) ST1:({7}) ET1:({8}) ST2:({9}) ET2:({10}) ST3:({11}) ET3:({12})", SourcePos.ToString, SourceSlot, TargetPos.ToString, TargetSlot, SourceGlass.GlassID, TargetGlass.GlassID, SourceGlass.SlotNo, SourceGlass.EQStartTime(1), SourceGlass.EQEndTime(1), SourceGlass.EQStartTime(2), SourceGlass.EQEndTime(2), SourceGlass.EQStartTime(3), SourceGlass.EQEndTime(3)))
        SourceGlass.CopyTo(TargetGlass)
        SourceGlass.Clear()
        WriteLog(String.Format("After  GlassData Transfer [{4}] {0}.{1} -> {2}.{3} [{5}] {6}  (DST) ST1:({7}) ET1:({8}) ST2:({9}) ET2:({10}) ST3:({11}) ET3:({12})", SourcePos.ToString, SourceSlot, TargetPos.ToString, TargetSlot, SourceGlass.GlassID, TargetGlass.GlassID, TargetGlass.SlotNo, TargetGlass.EQStartTime(1), TargetGlass.EQEndTime(1), TargetGlass.EQStartTime(2), TargetGlass.EQEndTime(2), TargetGlass.EQStartTime(3), TargetGlass.EQEndTime(3)))
    End Sub

    Public Function GetGlassInfo(ByVal vPos As eRobotPosition, ByVal vSlot As Integer, ByVal fGlassExist As Boolean) As L8BIFPRJ.clsS167SlotInfo
        Select Case vPos
            Case eRobotPosition.Buffer1
                mInfo.Buffer(1).fGlassExist(vSlot) = fGlassExist
                Return mInfo.Buffer(1).Glass(vSlot)

            Case eRobotPosition.Buffer2
                mInfo.Buffer(2).fGlassExist(vSlot) = fGlassExist
                Return mInfo.Buffer(2).Glass(vSlot)

            Case eRobotPosition.Buffer3
                mInfo.Buffer(3).fGlassExist(vSlot) = fGlassExist
                Return mInfo.Buffer(3).Glass(vSlot)

            Case eRobotPosition.CVP1
                mInfo.Port(1).fGlassExistFlowCV(vSlot) = fGlassExist
                Return mInfo.Port(1).GlassFlowCV(vSlot)
                'mInfo.CV.fGlassExist(1) = fGlassExist
                'Return mInfo.CV.Glass(1)

            Case eRobotPosition.CVP2
                mInfo.Port(2).fGlassExistFlowCV(vSlot) = fGlassExist
                Return mInfo.Port(2).GlassFlowCV(vSlot)
                'mInfo.CV.fGlassExist(2) = fGlassExist
                'Return mInfo.CV.Glass(2)

            Case eRobotPosition.CVP3
                mInfo.Port(3).fGlassExistFlowCV(vSlot) = fGlassExist
                Return mInfo.Port(3).GlassFlowCV(vSlot)
                'mInfo.CV.fGlassExist(3) = fGlassExist
                'Return mInfo.CV.Glass(3)

            Case eRobotPosition.EQ1
                mInfo.EQ(1).fGlassExist = fGlassExist
                Return mInfo.EQ(1).Glass

            Case eRobotPosition.EQ2
                mInfo.EQ(2).fGlassExist = fGlassExist
                Return mInfo.EQ(2).Glass

            Case eRobotPosition.EQ3
                mInfo.EQ(3).fGlassExist = fGlassExist
                Return mInfo.EQ(3).Glass

            Case eRobotPosition.Port1
                mInfo.Port(1).fGlassExist(vSlot) = fGlassExist
                Return mInfo.Port(1).Glass(vSlot)

            Case eRobotPosition.Port2
                mInfo.Port(2).fGlassExist(vSlot) = fGlassExist
                Return mInfo.Port(2).Glass(vSlot)

            Case eRobotPosition.Port3
                mInfo.Port(3).fGlassExist(vSlot) = fGlassExist
                Return mInfo.Port(3).Glass(vSlot)

            Case eRobotPosition.ROBOT
                mInfo.Robot.fGlassExist(vSlot) = fGlassExist
                Return mInfo.Robot.Glass(vSlot)

            Case Else
                Return Nothing
        End Select

    End Function

    Public Sub SetEQLinkStatus(ByVal nEQ As Integer, ByVal nLinkStatus As L8BIFPRJ.clsPLC.eLinkStatus)
        If mInfo.EQ(nEQ).Link <> nLinkStatus Then
            mInfo.EQ(nEQ).Link = nLinkStatus
            UpdateGUIEQLinkStatus(nEQ)

            Select Case mInfo.EQ(nEQ).Link
                Case L8BIFPRJ.clsPLC.eLinkStatus.LINKING
                    SetEQStatus(nEQ, _L8B.PLC.EQStatus(nEQ))

                Case L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE
                    SetEQStatus(nEQ, L8BIFPRJ.clsPLC.eEQStatus.DOWN)

                Case L8BIFPRJ.clsPLC.eLinkStatus.TRYING
            End Select

        End If
    End Sub

    Private Sub UpdateGUIEQLinkStatus(ByVal nEQ As Integer)
        _L8B.dlgLinkStatus.UpdateEQLinkStatusGUI(nEQ)
        _L8B.frmMain.UpdateEQLinkStatus(nEQ)
    End Sub

    Public Sub SetCVLinkStatus(ByVal nCV As Integer, ByVal nLinkStatus As L8BIFPRJ.clsPLC.eLinkStatus)
        If mInfo.CV.Link <> nLinkStatus Then
            mInfo.CV.Link = nLinkStatus
            UpdateGUICVLinkStatus(nCV)

            Select Case mInfo.CV.Link
                Case L8BIFPRJ.clsPLC.eLinkStatus.LINKING

                Case L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE
                    SetCVStatus(L8BIFPRJ.clsPLC.eEQStatus.DOWN)

                Case L8BIFPRJ.clsPLC.eLinkStatus.TRYING

            End Select

            'If nLinkStatus = L8BIFPRJ.clsPLC.eLinkStatus.LINKING Then
            '    For i As Integer = 1 To _L8B.Setting.Main.NumberPort
            '        Dim myPortType As L8BIFPRJ.clsPLC.eUnloadType = _L8B.PLC.PortType(i)
            '        Select Case myPortType
            '            Case L8BIFPRJ.clsPLC.eUnloadType.OK
            '                _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_OK
            '            Case L8BIFPRJ.clsPLC.eUnloadType.NG
            '                _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_NG
            '            Case L8BIFPRJ.clsPLC.eUnloadType.NA
            '                _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_NODEFINE
            '            Case Else
            '                _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED
            '        End Select
            '        _L8B.CIM.PortInfoChanged(i)
            '    Next
            'End If

        End If
    End Sub

    Private Sub UpdateGUICVLinkStatus(ByVal nCV As Integer)
        _L8B.dlgLinkStatus.UpdateCVLinkStatusGUI()
        _L8B.frmMain.UpdateCvLinkStatus()
    End Sub

    Public Sub UpdateUIModeToCv()
        Select Case _L8B.Setting.Main.GlassFlowMode
            Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                    If Not _L8B.PLC.CassetteInPort(i) Then
                        _L8B.PLC.CVPortChange(i, L8BIFPRJ.clsPLC.ePortMode.LOAD, L8BIFPRJ.clsPLC.eUnloadType.NA)
                    End If
                Next

            Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                If _L8B.Setting.Main.NumberPort < 3 Then
                    If Not _L8B.PLC.CassetteInPort(1) Then _L8B.PLC.CVPortChange(1, L8BIFPRJ.clsPLC.ePortMode.LOAD, L8BIFPRJ.clsPLC.eUnloadType.MIX)
                    If Not _L8B.PLC.CassetteInPort(2) Then _L8B.PLC.CVPortChange(2, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.MIX)
                ElseIf _L8B.Setting.Main.NumberPort = 3 Then
                    If Not _L8B.PLC.CassetteInPort(1) Then _L8B.PLC.CVPortChange(1, L8BIFPRJ.clsPLC.ePortMode.LOAD, L8BIFPRJ.clsPLC.eUnloadType.MIX)
                    If Not _L8B.PLC.CassetteInPort(2) Then _L8B.PLC.CVPortChange(2, L8BIFPRJ.clsPLC.ePortMode.LOAD, L8BIFPRJ.clsPLC.eUnloadType.MIX)
                    If Not _L8B.PLC.CassetteInPort(3) Then _L8B.PLC.CVPortChange(3, L8BIFPRJ.clsPLC.ePortMode.UNLOAD, L8BIFPRJ.clsPLC.eUnloadType.OK)
                End If
        End Select
    End Sub

    Public Sub SetPortSubStatus(ByVal nPort As Integer, ByVal bPause As Boolean)
        If mInfo.Port(nPort).fPause = bPause Then
            WriteLog("[IGNORE] SetPortStaus PortID(" & nPort & ") Pause =[" & mInfo.Port(nPort).fPause & " ->" & bPause & "]", LogMessageType.Info)
            Return
        Else
            mInfo.Port(nPort).fPause = bPause
            If bPause Then
                If _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.UNLOAD OrElse mInfo.Port(nPort).GlassCount = 0 Then
                    WriteLog("Unloader no Suspend for report.", LogMessageType.Info)
                    Exit Sub
                End If
                If Not mInfo.Port(nPort).InProcessAbort Then
                    _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_SUSPEND)
                End If
            Else
                Select Case mInfo.Port(nPort).Status
                    Case PORTSTATUS.PROCESSWAIT
                        _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT, True)
                    Case PORTSTATUS.PROCESSING
                        _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS, True)
                    Case PORTSTATUS.CVUNLOADEDCOMPLETE, PORTSTATUS.CVUNLOADREQUEST, PORTSTATUS.LOTFINISHED, PORTSTATUS.UNLOADREQUEST
                        _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_END)
                    Case Else
                        _L8B.CIM.CassetteStatusChange(nPort, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE)
                End Select
            End If
        End If

    End Sub

    Public Sub UpdateCVPositionGlassID(ByVal nPosition As Integer, ByVal strNewGxID As String)
        mInfo.CV.GlassIDCVSection(nPosition) = strNewGxID
        _L8B.frmMain.UpdateCVPositionGlassIDGUI(nPosition)
    End Sub

    Public Sub GlassDelete(ByVal ePos As eRobotPosition, ByVal nSlot As Integer, ByVal vGlassID As String)
        vGlassID = MyTrim(vGlassID)
        If ePos >= eRobotPosition.EQ1 And ePos <= eRobotPosition.EQ3 Then
            Dim mEQID As Integer = ePos - eRobotPosition.EQ1 + 1
            With mInfo.EQ(mEQID)
                .Glass.Clear()
                .fGlassExist = False
                .fGlassExistShow = False
                .GlassIDShow = ""
            End With
            _L8B.CIM.GlassErase(mInfo.EQ(mEQID).ToolID, vGlassID)
            _L8B.frmMain.UpdateEQStatus(mEQID)
        ElseIf ePos >= eRobotPosition.CVP1 AndAlso ePos <= eRobotPosition.CVP3 Then
            With mInfo.Port(ePos - eRobotPosition.CVP1 + 1)
                .fGlassExistFlowCV(nSlot) = False
                .GlassFlowCV(nSlot).Clear()
            End With
            _L8B.CIM.GlassErase(mInfo.CV.ToolID, vGlassID)
            _L8B.frmMain.UpdateCVPositionGlassIDGUI(nSlot)
        ElseIf ePos >= eRobotPosition.Buffer1 And ePos <= eRobotPosition.Buffer3 Then
            Dim mBufferID As Integer = ePos - eRobotPosition.Buffer1 + 1
            mInfo.Buffer(mBufferID).fGlassExist(nSlot) = False
            mInfo.Buffer(mBufferID).Glass(nSlot).Clear()
            mInfo.Buffer(mBufferID).fGlassExistShow(nSlot) = False
            mInfo.Buffer(mBufferID).GlassIDShow(nSlot) = ""
            _L8B.CIM.GlassErase(mInfo.Robot.ToolID, vGlassID)
        ElseIf ePos = eRobotPosition.ROBOT Then
            mInfo.Robot.fGlassExist(nSlot) = False
            mInfo.Robot.Glass(nSlot).Clear()
            mInfo.Robot.fGlassExistShow(nSlot) = False
            mInfo.Robot.GlassIDShow(nSlot) = ""
            _L8B.CIM.GlassErase(mInfo.Robot.ToolID, vGlassID)
        ElseIf ePos >= eRobotPosition.Port1 And ePos <= eRobotPosition.Port3 Then
            Dim mPortID As Integer = ePos - eRobotPosition.Port1 + 1
            mInfo.Port(mPortID).fGlassExist(nSlot) = False
            mInfo.Port(mPortID).Glass(nSlot).Clear()
            _L8B.CIM.RemoveSlotFromPort(mPortID, nSlot)
            _L8B.CIM.GlassErase(mInfo.CV.ToolID, vGlassID)
        End If
    End Sub


    Public Sub AbortProcess(ByVal nPort As Integer)
        Select Case mInfo.Port(nPort).Status
            Case PORTSTATUS.PROCESSING
                _L8B.PLC.CassetteUnloadRequest(nPort)
            Case Else
                WriteLog(String.Format("Can't perform AbortProcess({0}), since Port Status = {1}", nPort, mInfo.Port(nPort).Status.ToString), LogMessageType.Warn)
        End Select
    End Sub


    Public Sub CancelCassette(ByVal nPort As Integer, Optional ByVal bForce As Boolean = False)
        Select Case mInfo.Port(nPort).Status
            Case PORTSTATUS.PRESENT, PORTSTATUS.LOADCOMPLETE, PORTSTATUS.PROCESSING, PORTSTATUS.PROCESSWAIT, PORTSTATUS.READYTOSTART
                _L8B.PLC.CassetteUnloadRequest(nPort)
            Case Else
                If bForce Then
                    _L8B.PLC.CassetteUnloadRequest(nPort)
                Else
                    WriteLog(String.Format("Can't perform CancelCassette({0}), since Port Status = {1}", nPort, mInfo.Port(nPort).Status.ToString), LogMessageType.Warn)
                End If
        End Select


    End Sub

    Public Sub PMRobotStart()
        If mInfo.PM.Continued Then
            mInfo.PM.Running = True
        End If
    End Sub

    '2010/06/01
    Public Sub PMRobotComplete()
        With mInfo.PM
            If .Continued And .Running Then
                .pFrom = .pTo
                If .pTo = 1 Then
                    .pTo = 2
                Else
                    .pTo = 1
                End If
                _L8B.frmMain.PMTestRobotCommand(.pTo)
            ElseIf .Running Then
                .Running = False
                If mInfo.Robot.Mode <> L8BIFPRJ.clsPLC.eRSTMode.AUTO Then
                    _L8B.frmMain.GroupBoxMRobot.Enabled = True
                End If
                _L8B.frmMain.ButtonStartPMTest.Enabled = True
                _L8B.frmMain.ButtonStartPMTest.Text = "Start Test"
                WriteLog("PM Test runs " & mInfo.PM.Count & " cycles", LogMessageType.Info)

                Dim fontRegular As New Font(_L8B.frmMain.LabelPMPos1.Font.FontFamily, _L8B.frmMain.LabelPMPos1.Font.Size, FontStyle.Regular)
                _L8B.frmMain.LabelPMPos1.Font = fontRegular
                _L8B.frmMain.LabelPMPos2.Font = fontRegular
            End If
        End With
    End Sub

    Public Sub UpdatePassGlass(Optional ByVal NumberAdd As Integer = 0)
        With _L8B
            .Setting.Main.Pass += NumberAdd
            .Setting.Main.TotalPass += NumberAdd
            .frmMain.ButtonPass.Text = .Setting.Main.Pass
            .frmMain.ButtonTotalPass.Text = CStr(.Setting.Main.TotalPass)
            .Setting.SavePass()
        End With
    End Sub

    Public Function GGradeConvertPLCToCIM(ByVal GGrade As L8BIFPRJ.clsPLC.eGGRADE) As prjsecs.clsEnumCtl.eGlassGrade
        Select Case GGrade
            Case L8BIFPRJ.clsPLC.eGGRADE.GRAY
                Return prjsecs.clsEnumCtl.eGlassGrade.GRAY

            Case L8BIFPRJ.clsPLC.eGGRADE.NG
                Return prjsecs.clsEnumCtl.eGlassGrade.NG

            Case L8BIFPRJ.clsPLC.eGGRADE.NO_GLASS
                Return prjsecs.clsEnumCtl.eGlassGrade.NO

            Case L8BIFPRJ.clsPLC.eGGRADE.OK
                Return prjsecs.clsEnumCtl.eGlassGrade.OK

            Case Else
                Return prjsecs.clsEnumCtl.eGlassGrade.NO
        End Select
    End Function

    Public Function GGradeConvertCIMToPLC(ByVal GGrade As prjsecs.clsEnumCtl.eGlassGrade) As L8BIFPRJ.clsPLC.eGGRADE
        Select Case GGrade
            Case prjsecs.clsEnumCtl.eGlassGrade.GRAY
                Return L8BIFPRJ.clsPLC.eGGRADE.GRAY

            Case prjsecs.clsEnumCtl.eGlassGrade.NG
                Return L8BIFPRJ.clsPLC.eGGRADE.NG

            Case prjsecs.clsEnumCtl.eGlassGrade.NO
                Return L8BIFPRJ.clsPLC.eGGRADE.NO_GLASS

            Case prjsecs.clsEnumCtl.eGlassGrade.OK
                Return L8BIFPRJ.clsPLC.eGGRADE.OK

            Case Else
                Return L8BIFPRJ.clsPLC.eGGRADE.NO_GLASS
        End Select
    End Function


    Public Function DGradeConvertPLCToCIM(ByVal DGrade As L8BIFPRJ.clsPLC.eDGRADE) As prjsecs.clsEnumCtl.eDMQCGrade
        Select Case DGrade
            Case L8BIFPRJ.clsPLC.eDGRADE.NG
                Return prjsecs.clsEnumCtl.eDMQCGrade.NG

            Case L8BIFPRJ.clsPLC.eDGRADE.NO_GLASS
                Return prjsecs.clsEnumCtl.eDMQCGrade.NO

            Case L8BIFPRJ.clsPLC.eDGRADE.OK
                Return prjsecs.clsEnumCtl.eDMQCGrade.OK

            Case L8BIFPRJ.clsPLC.eDGRADE.REVIEW
                Return prjsecs.clsEnumCtl.eDMQCGrade.REVIEW

            Case Else
                Return prjsecs.clsEnumCtl.eDMQCGrade.NO
        End Select
    End Function

    Public Function DGradeConvertCIMToPLC(ByVal DGrade As prjsecs.clsEnumCtl.eDMQCGrade) As L8BIFPRJ.clsPLC.eDGRADE
        Select Case DGrade
            Case prjsecs.clsEnumCtl.eDMQCGrade.NG
                Return L8BIFPRJ.clsPLC.eDGRADE.NG

            Case prjsecs.clsEnumCtl.eDMQCGrade.NO
                Return L8BIFPRJ.clsPLC.eDGRADE.NO_GLASS

            Case prjsecs.clsEnumCtl.eDMQCGrade.OK
                Return L8BIFPRJ.clsPLC.eDGRADE.OK

            Case prjsecs.clsEnumCtl.eDMQCGrade.REVIEW
                Return L8BIFPRJ.clsPLC.eDGRADE.REVIEW

            Case Else
                Return L8BIFPRJ.clsPLC.eDGRADE.NO_GLASS
        End Select
    End Function

    Public Function ProductCategoryConvertCIMToPLC(ByVal mProductCategory As prjsecs.clsEnumCtl.eProductCategory) As L8BIFPRJ.clsPLC.eProductCategory
        Select Case mProductCategory
            Case prjsecs.clsEnumCtl.eProductCategory.PRODCAT_DUMMY
                Return L8BIFPRJ.clsPLC.eProductCategory.DUMY

            Case prjsecs.clsEnumCtl.eProductCategory.PRODCAT_INITIAL
                Return L8BIFPRJ.clsPLC.eProductCategory.INIT

            Case prjsecs.clsEnumCtl.eProductCategory.PRODCAT_MONITOR
                Return L8BIFPRJ.clsPLC.eProductCategory.MONI

            Case prjsecs.clsEnumCtl.eProductCategory.PRODCAT_NONE
                Return L8BIFPRJ.clsPLC.eProductCategory.NA

            Case prjsecs.clsEnumCtl.eProductCategory.PRODCAT_PRODUCT
                Return L8BIFPRJ.clsPLC.eProductCategory.PROD

            Case Else
                Return L8BIFPRJ.clsPLC.eProductCategory.NA
        End Select
    End Function

    Public Function ProductCategoryConvertPLCToCIM(ByVal mProductCategory As L8BIFPRJ.clsPLC.eProductCategory) As prjsecs.clsEnumCtl.eProductCategory
        Select Case mProductCategory
            Case L8BIFPRJ.clsPLC.eProductCategory.DUMY
                Return prjsecs.clsEnumCtl.eProductCategory.PRODCAT_DUMMY

            Case L8BIFPRJ.clsPLC.eProductCategory.INIT
                Return prjsecs.clsEnumCtl.eProductCategory.PRODCAT_INITIAL

            Case L8BIFPRJ.clsPLC.eProductCategory.MONI
                Return prjsecs.clsEnumCtl.eProductCategory.PRODCAT_MONITOR

            Case L8BIFPRJ.clsPLC.eProductCategory.NA
                Return prjsecs.clsEnumCtl.eProductCategory.PRODCAT_NONE

            Case L8BIFPRJ.clsPLC.eProductCategory.PROD
                Return prjsecs.clsEnumCtl.eProductCategory.PRODCAT_PRODUCT

            Case Else
                Return prjsecs.clsEnumCtl.eProductCategory.PRODCAT_NONE
        End Select
    End Function

    Public Function GlassVisitEQ(ByVal vGlass As L8BIFPRJ.clsS167SlotInfo) As Integer
        Dim nCount As Integer = 0

        For i As Integer = 1 To MaxEQ
            If vGlass.EQStartTime(i) <> "" AndAlso vGlass.EQEndTime(i) <> "" Then
                WriteLog("GlassID={" & vGlass.GlassID & "} visit EQ" & i)
                nCount += 1
            End If
        Next
        WriteLog("GlassID={" & vGlass.GlassID & "} visit " & nCount & "EQ(s)")
        Return nCount
    End Function

    'Public Function GlassVisitEQEncode(ByVal vGlass As L8BIFPRJ.clsS167SlotInfo) As Integer
    '    Dim nCount As Integer = 0
    '    Dim nEncode As Integer = 0

    '    For i As Integer = 1 To MaxEQ
    '        If vGlass.EQStartTime(i) <> "" AndAlso vGlass.EQEndTime(i) <> "" Then
    '            WriteLog("GlassID={" & vGlass.GlassID & "} visit EQ" & i)
    '            nCount += 1
    '            nEncode = nEncode + System.Math.Pow(2, i)
    '        End If
    '    Next
    '    WriteLog("GlassID={" & vGlass.GlassID & "} visit " & nCount & "EQ(s) encoed =" & nEncode)
    '    Return nEncode
    'End Function


    Public Function GlassEQEncode(ByVal vGlass As L8BIFPRJ.clsS167SlotInfo, ByRef fEQDone() As Boolean) As Integer
        Dim nCount As Integer = 0
        Dim nEncode As Integer = 0
        ReDim fEQDone(3)
        For i As Integer = 1 To MaxEQ
            If vGlass.EQStartTime(i) <> "" AndAlso vGlass.EQEndTime(i) <> "" Then
                WriteLog("GlassID={" & vGlass.GlassID & "} visit EQ" & i)
                nCount += 1
                nEncode = nEncode + System.Math.Pow(2, i)
                fEQDone(i) = True
            Else
                fEQDone(i) = False
            End If

        Next
        WriteLog("GlassID={" & vGlass.GlassID & "} visit " & nCount & "EQ(s) encoed =" & nEncode & " EQ1Done=" & fEQDone(1) & " EQ2Done=" & fEQDone(2) & " EQ3Done=" & fEQDone(3))
        Return nEncode
    End Function

    Public Sub UIModeSave(ByVal GlassFlowMode As prjSECS.clsEnumCtl.ePortType, Optional ByVal bCheck As Boolean = True)
        'If _L8B.PLC.CassetteInPort And bCheck Then
        '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Change Port Mode -> [I/U mode]; at lease one Cassette on Port", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
        '    Return
        'End If
        _L8B.Setting.Main.GlassFlowMode = GlassFlowMode
        _L8B.Setting.IniSave()
        _L8B.PLC.ChangeIUMode()
        UpdateUIModeToCv()
        _L8B.frmMain.UpdateGlassFlowMode()
    End Sub

    Public Sub RepairModeSave(ByVal vColorRrepairMode As L8BIFPRJ.clsPLC.eColorRepairMode, Optional ByVal bCheck As Boolean = True)
        If _L8B.PLC.CassetteInPort And bCheck Then
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Change Port Mode -> [I/U mode]; at lease one Cassette on Port", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok)
            Return
        End If
        _L8B.Setting.Main.ColorRepairMode = vColorRrepairMode
        _L8B.Setting.IniSave()
        _L8B.PLC.UpdateColorRepairMode()
        _L8B.frmMain.UpdatColorRepairMode()
    End Sub


    Public Function GetUnitID(ByVal nSrc As ClsAlarm.eUnitPosition) As Integer
        Select Case nSrc
            Case ClsAlarm.eUnitPosition.CV
                Return mInfo.CV.UnitID
            Case ClsAlarm.eUnitPosition.EQ1
                Return mInfo.EQ(1).UnitID
            Case ClsAlarm.eUnitPosition.EQ2
                Return mInfo.EQ(2).UnitID
            Case ClsAlarm.eUnitPosition.EQ3
                Return mInfo.EQ(3).UnitID
            Case ClsAlarm.eUnitPosition.Robot
                Return mInfo.Robot.UnitID
        End Select
    End Function


End Module


