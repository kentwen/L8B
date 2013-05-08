Imports Nini.Config
Imports prjSECS.clsEnumCtl

Public Class clsCCIM

#Region "Ver For AUO L8B"
    '
#End Region

#Region "Setting..."
    Public MySECS As New prjSECS.clsSECSMain

    Const ACTION_DONE = 0           ' action is taken
    Const ACTION_SKIP = 1           ' skip this step

    Const MAX_LOOPBACK = 9
    Const MAX_RECIPE = 100

    Dim m_HSMST3 As Integer
    Dim m_HSMST5 As Integer
    Dim m_HSMST6 As Integer
    Dim m_HSMST7 As Integer
    Dim m_HSMST8 As Integer
    Dim m_HSMST9 As Integer

    Dim m_RetryLimit As Integer
    Dim m_LinkTestTimer As Integer
    Dim m_IPAddressLocal As String
    Dim m_IPAddressRemote As String
    Dim m_LineID As String
    Dim m_LoaderToolID As String
    Dim m_TCPPortLocal As Integer
    Dim m_TCPPortRemote As Integer
    Dim m_DefaultDeviceID As Integer
    Dim m_TimeOut As Integer
    Dim m_ConnectionMode As Integer
    Dim m_ConversationTimeout As Integer
    Dim mEQRemoteCMD As eRemoteReplyCMD

    Public m_strIniFileFullName As String


    Dim m_OperatorIDAGV As String
    Dim m_OperatorIDMGV As String
    Dim m_LineType As eLineType

    Dim m_fAutoSyncTime As Boolean
    Dim MyGlassProcessInfo() As prjSECS.clsGxReport
    Dim MyWIPInfo() As prjSECS.clsWIPDataInTool

    Enum eReqType
        REQ_S1F5
        REQ_S1F89
    End Enum

    ' definition of <CMDA>
    Enum eCMDA
        CMDA_OK = 0
        CMDA_INVALIDCMD = 1
        CMDA_CANNOTEXECUTE = 2
        CMDA_PARAERROR = 3
    End Enum

    Enum eLineType
        LTYPE_NONE = 0
        LTYPE_FIMACRO
    End Enum

    Dim m_S1F1CountDown As Integer
    Dim m_S2F17CountDown As Integer

    ' === to store data from app ===

    ' S5F65
    'Dim m_nUnitNoAlarm As Integer
    'Dim m_aGlassAffect() As String

    ' S6F69


    ' S6F85
    Dim m_strToolID As String
    Dim m_strGlassIDErase As String

    ' S6F87
    Dim m_nUnitNoWorkID As Integer
    Dim m_strGlassIDHost As String
    Dim m_strGlassIDVCR As String
    ' =================================

    Dim WithEvents MySecxX As prjSECS.clsSECSMain

    Dim mAlarmIn As New Collection              ' alarms waiting to report
    Dim mAlarmOut As New Collection             ' alarms already report (wait for release)
    Dim mAlarmOfflineCol As New Collection      ' record alarm released in online which occurred in online

    '========================== For L8B ====================
    Dim colSnFn As New Collection
    Dim colSnFnSecend As New Collection
    Private mvarCurrentSn As Integer
    Private mvarCurrentFn As Integer
    Private mvarWaitReply As Boolean
    Private mvarIniSECSFilePath As String
    '=======================================================
#End Region

#Region "Event Define"
    Public Event OffLineComplete(ByVal nAckCode As Integer)
    Public Event S1F66UnitStatusReply(ByVal nAckCode As Integer) 'S1F66
    Public Event S1F74LoadRequestStart(ByVal nPortPos As Integer)
    Public Event S1F74LoadCompleted(ByVal nPortPos As Integer)
    Public Event S1F76UnloadRequestStart(ByVal nPortPos As Integer)
    Public Event S1F76UnloadCompleted(ByVal nPortPos As Integer)
    Public Event S1F68CSTStatusReply(ByVal nPortPos As Integer, ByVal nReturnCode As Integer, ByVal strNGGlassID As String)
    Public Event S1F87WIPRequest()
    Public Event S1F90OnLineComplete(ByVal nOnLineMode As Integer)

    Public Event S2F18SyncDateTime(ByVal dtDateTime As String)
    Public Event S2F21RemoteCommand(ByVal nPortPos As Integer, ByVal strCommand As String, ByVal strCIMMsg As String)
    Public Event S2F25LoopBackResult(ByVal fResult As Boolean)
    Public Event S2F41EQRemoteCommand(ByVal strToolID As String, ByVal strCSTID As String, ByVal strCMD As String, ByVal strSaveFlag As String, ByVal strMSG As String)

    Public Event S7F4RSTRecipeParameterQuery(ByVal strLineID As String, ByVal strToolID As String, ByVal strPPID As String)
    Public Event S7F72ReplyCassetteDataRequest(ByVal nPortPos As Integer, ByVal nGrantCode As Integer)
    Public Event S7F67RecipeModifyLastTimeQuery(ByVal strPPID As String)
    Public Event S7F65CassetteDataDownloaded(ByVal LotInfo As prjSECS.clsLotStructure)

    Public Event S10F5TerminalRequest(ByVal nTerminalID As eTerminalID, ByVal fBuzzer As Boolean, ByVal strText As String)

    Public Event EQStatusReply(ByVal nAckCode As Integer) 'S1F66

    Public Event S9F13ConversationTimeoutOccur(ByVal nPortPos As Integer, ByVal nStream As Integer, ByVal nFunction As Integer)
    Public Event HSMSConnectChanged(ByVal fConnect As Boolean)
        
    'For L8B Add===========================================
    Public Event HOSTOnLineRequest()   'S1F1
    Public Event HOSTOnLineReply()    'S1F2
    Public Event HOSTReplyCode(ByVal nReplySF As eSECSStatusReplyType, ByVal nCode As Integer)
    '======================================================



    Dim WithEvents MyTimeout As New System.Windows.Forms.Timer
    Dim WithEvents MyDispatcher As New System.Windows.Forms.Timer
    Dim WithEvents MyReportAlarm As New System.Windows.Forms.Timer
    Dim WithEvents MyReportRecipe As New System.Windows.Forms.Timer
    Dim WithEvents MyHeartBeat As New System.Windows.Forms.Timer       ' 10 seconds

    Dim WithEvents MySnFnTimer As New System.Windows.Forms.Timer

#End Region

#Region "Property Setting"

    Public Property SecsMonitor() As Boolean
        Get
            'SecsMonitor = MySECS.MonitorSecsStatus
        End Get

        Set(ByVal value As Boolean)
            'MySECS.MonitorSecsStatus = value
        End Set
    End Property

    Public ReadOnly Property GetUnitStatus(ByVal nIndex As Integer) As Integer
        Get
            GetUnitStatus = MyUnitInfo(nIndex).EQStatus
        End Get
    End Property

    Public Property LineID() As String
        Get
            LineID = m_LineID
        End Get
        Set(ByVal value As String)
            m_LineID = value
            WriteLogInfo(eLogType.TYPE_PROPERTY, "LineID=" & value)

            MySECS.RST_LineName = value
        End Set
    End Property

    Public Property LoaderToolID() As String
        Set(ByVal value As String)
            WriteLogInfo(eLogType.TYPE_PROPERTY, "Loader ToolID=" & value)

            m_LoaderToolID = value
            MySECS.RST_LineToolName = value
        End Set
        Get
            LoaderToolID = m_LoaderToolID
        End Get
    End Property

    Public Property DisplayLinkTest() As Boolean
        Get
            'DisplayLinkTest = MySECS.DisplayLinkTest
        End Get
        Set(ByVal value As Boolean)
            'MySECS.DisplayLinkTest = value
        End Set
    End Property

    Public Property OperatorIDAGV() As String
        Get
            OperatorIDAGV = m_OperatorIDAGV
        End Get
        Set(ByVal value As String)
            WriteLogInfo(eLogType.TYPE_PROPERTY, "OPID AGV=" & value)
            m_OperatorIDAGV = value
        End Set
    End Property

    Public Property OperatorIDMGV() As String
        Get
            OperatorIDMGV = m_OperatorIDMGV
        End Get
        Set(ByVal value As String)
            WriteLogInfo(eLogType.TYPE_PROPERTY, "OPID MGV=" & value)
            m_OperatorIDMGV = value
        End Set
    End Property

    Public Property MaxEQ() As Integer
        Get
            MaxEQ = g_nMaxUnits
        End Get
        Set(ByVal value As Integer)
            Dim nFor As Integer

            WriteLogInfo(eLogType.TYPE_PROPERTY, "Max EQ=" & value)

            g_nMaxUnits = value

            ReDim MyUnitInfo(value)

            For nFor = 0 To value
                MyUnitInfo(nFor) = New prjSECS.clsUnitStructure
            Next
        End Set
    End Property

    Public Property MaxPorts() As Integer
        Get
            MaxPorts = g_nMaxPorts
        End Get
        Set(ByVal value As Integer)
            Dim nFor As Integer

            WriteLogInfo(eLogType.TYPE_PROPERTY, "Max Port = " & value)

            g_nMaxPorts = value
            g_nMaxLots = value

            ReDim MyPortInfo(value)
            ReDim MyPortStateControl(5)
            ReDim MyLotInfo(value)
            ReDim MyProcessEndInfo(value)
            ReDim g_afCassetteRemoveReq(value)
            ReDim g_afCassetteUnloadReq(value)
            ReDim g_afCSTVLoad(value)

            ReDim g_fRemotePause(value)
            ReDim g_fRemoteResume(value)
            For nFor = 0 To value
                g_fRemotePause(nFor) = False
                g_fRemoteResume(nFor) = False

                MyPortInfo(nFor) = New prjSECS.clsPortStructure
                'MyPortStateControl(nFor) = New clsStateControl
                'MyPortStateControl(nFor).nCurrStep = 1
                MyLotInfo(nFor) = New prjSECS.clsLotStructure
                MyProcessEndInfo(nFor) = New prjSECS.clsLotStructure
            Next

            For nFor = 0 To 5
                MyPortStateControl(nFor) = New clsStateControl
                MyPortStateControl(nFor).nCurrStep = 1
            Next
        End Set
    End Property

    Public Property IniCIMFilePath() As String
        Get
            IniCIMFilePath = m_strIniFileFullName
        End Get
        Set(ByVal value As String)
            WriteLogInfo(eLogType.TYPE_PROPERTY, "HSMS Ini File Full Name=" & value)
            m_strIniFileFullName = value
            SECS_ReadSetting(m_strIniFileFullName)
        End Set

    End Property

    Public Property MGVBufRunCIM() As Boolean
        Get
            MGVBufRunCIM = g_fRunMGVBufCIM
        End Get
        Set(ByVal value As Boolean)
            WriteLogInfo(eLogType.TYPE_PROPERTY, " Buffer port run CIM is " & IIf(value, "ON", "OFF"))
            g_fRunMGVBufCIM = value
        End Set
    End Property

    Public Property ConversationTimeout() As Integer
        Get
            ConversationTimeout = m_ConversationTimeout
        End Get
        Set(ByVal value As Integer)
            m_ConversationTimeout = value
        End Set
    End Property

    Public Property LineType() As eLineType
        Get
            LineType = m_LineType
        End Get
        Set(ByVal value As eLineType)
            WriteLogInfo(eLogType.TYPE_PROPERTY, "Line Type=" & value.ToString)
            m_LineType = value
        End Set
    End Property
#End Region

#Region " Method "

    'For Sim Only
    Public Sub ShowSECSSim()
        MySecxX.ShowSim()
    End Sub

    Public Sub InitPortInfo(ByRef mvarPortInfo() As prjSECS.clsPortStructure)
        Try
            Dim i As Integer
            WriteLogInfo(eLogType.TYPE_METHOD, "InitPortInfo Ports = " & CStr(UBound(mvarPortInfo)))

            For i = 1 To UBound(MyPortInfo)
                UpdatePortInfo(i, mvarPortInfo(i))
            Next i

            Call ReinitStateInfo()

            ' init port position
            For i = 1 To UBound(MyPortInfo)
                MyPortStateControl(i).nPortNo = MyPortInfo(i).PortPosition
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub InitPortInfo", ex.ToString)
        End Try
    End Sub

    Public Sub InitUnitInfo(ByRef mvarUnitInfo() As prjSECS.clsUnitStructure)
        Try
            Dim i As Integer
            Dim nMaxUnit As Integer

            nMaxUnit = UBound(mvarUnitInfo)
            g_nMaxUnits = nMaxUnit

            ReDim MyUnitInfo(nMaxUnit)

            For nFor = 0 To nMaxUnit
                MyUnitInfo(nFor) = New prjSECS.clsUnitStructure
            Next


            WriteLogInfo(eLogType.TYPE_METHOD, "InitUnitInfo, Units = " & CStr(UBound(mvarUnitInfo)))

            For i = 0 To UBound(mvarUnitInfo)
                UpdateUnitInfo(i, mvarUnitInfo(i))
            Next i

        Catch ex As Exception
            WrigeExceptionLog("Sub InitPortInfo", ex.ToString)
        End Try


    End Sub

    ' determine which Unit content changes
    ' 1. check whether <Status> & <SubStatus> changed
    ' 2. it also check whether online mode changes (main unit only)
    ' Main/Sub Unit => report S1F65

    

    ' update port information only, allow port enable/disable report
    Public Sub PortInfoChanged(ByRef PortInfo As prjSECS.clsPortStructure)
        Try
            Dim i As Integer

            WriteLogInfo(eLogType.TYPE_METHOD, "PortInfoChanged: Port=" & CStr(PortInfo.PortPosition) & ",Status=" & PortInfo.PortStatus)

            For i = 1 To g_nMaxPorts
                If MyPortInfo(i).PortPosition = PortInfo.PortPosition Then
                    UpdatePortInfo(i, PortInfo)
                    Exit Sub
                End If
            Next i

            WriteLogInfo(eLogType.TYPE_SYS, vbTab & "PortInfoChanged, no match PortNo->" & CStr(PortInfo.PortPosition))
        Catch ex As Exception
            WrigeExceptionLog("Sub PortInfoChanged", ex.ToString)
        End Try
    End Sub

    'Open HSMS TCP/IP Connection
    Public Sub OpenPort()
        Try
            MySECS.HSMST3 = m_HSMST3
            MySECS.HSMST5 = m_HSMST5
            MySECS.HSMST6 = m_HSMST6
            MySECS.HSMST7 = m_HSMST7
            MySECS.HSMST8 = m_HSMST8

            MySECS.HSMSLinkTestTimer = m_LinkTestTimer
            MySECS.HSMSRetryTimes = m_RetryLimit

            MySECS.ConnectTimeout = m_ConversationTimeout
            MySECS.ConnetcMode = m_ConnectionMode
            MySECS.HSMSHOSTIP = m_IPAddressRemote
            MySECS.HSMSHOSTTCPPort = m_TCPPortRemote
            MySECS.HSMSDeviceID = m_DefaultDeviceID

            MySECS.RST_PortOpen()

            WriteLogInfo(eLogType.TYPE_METHOD, "Open Port")
        Catch ex As Exception
            WrigeExceptionLog("Sub OpenPort", ex.ToString)
        End Try
    End Sub

    'Close HSMS TCP/IP Connection
    Public Sub ClosePort()
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "Close Port")
            MySECS.RST_PortCloase()
        Catch ex As Exception
            WrigeExceptionLog("Sub ClosePort", ex.ToString)
        End Try
    End Sub

#Region "S1F1 Get On Line"
    Public Function S1F1GetOnLine(ByVal nChangedMode As eRemoteStatus) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "GetOnLine, Mode = " & CStr(nChangedMode))

            'If nChangedMode = g_nCurrOnlineMode Then
            '    WriteLogInfo(eLogType.TYPE_SYS, "GetOnLine, mode is not changed")
            '    S1F1GetOnLine = -1
            '    Exit Function
            'End If

            g_nChangedMode = nChangedMode
            If nChangedMode = eRemoteStatus.MODE_OFFLINE Then Exit Function
            g_fTryOnOffLine = True

            SnFnAdd(0, 1, 1, 1)
        Catch ex As Exception
            WrigeExceptionLog("Sub GetOnLine", ex.ToString)
        End Try
    End Function
#End Region

#Region "S1F2"
    Public Sub S1F2OnLineReply(ByVal strMDLN As String, ByVal strVer As String)
        If strMDLN = "" And MySECS.S1F1_MDLN = "" Then
            MySECS.S1F1_MDLN = "Rainbow"
        Else
            MySECS.S1F1_MDLN = strMDLN
        End If

        If strVer = "" And MySECS.S1F1_Version = "" Then
            MySECS.S1F1_Version = "V1.0.0"
        Else
            MySECS.S1F1_Version = strVer
        End If
        SnFnAdd(0, 1, 2, 0)
    End Sub
#End Region

#Region "S1F65 EQ Status Change"
    Public Sub S1F65UnitInfoChanged(ByRef UnitInfo As prjSECS.clsUnitStructure, Optional ByVal nPortPos As Integer = 0)
        Try
            Dim nPrevStatus As eEQStatus
            Dim nPrevSubStatus As eEQSubStatus
            Dim nPrevOnlineMode As eRemoteStatus
            Dim fSent As Boolean
            Dim i As Integer


            WriteLogInfo(eLogType.TYPE_METHOD, "UnitInfoChanged, UnitNo=" & CStr(UnitInfo.UnitNo) & ",Status=" & UnitInfo.EQStatus & ",SubStatus=" & UnitInfo.EQSubStatus)

            ' match unit id first
            For i = 0 To g_nMaxUnits
                If MyUnitInfo(i).UnitNo = UnitInfo.UnitNo Then
                    nPrevStatus = MyUnitInfo(i).EQStatus
                    nPrevSubStatus = MyUnitInfo(i).EQSubStatus
                    nPrevOnlineMode = MyUnitInfo(i).RemoteStatus

                    If UnitInfo.UnitNo = 1 Then
                        MySecxX.CCIMOnLineMode = UnitInfo.RemoteStatus
                        If Trim(MyUnitInfo(0).ToolID) = "" Then MyUnitInfo(0).ToolID = MyUnitInfo(1).ToolID
                    End If

                    UpdateUnitInfo(i, UnitInfo)

                    If IsOnLineMode() Then
                        If i = MAIN_RST Then
                            ' check whether online mode changes
                            'If nPrevOnlineMode <> UnitInfo.RemoteStatus Then
                            fSent = True
                            If UnitInfo.RemoteStatus = eRemoteStatus.MODE_OFFLINE Then
                                If g_fHSMSConnected Then
                                    g_fOfflineReq = True
                                    g_fOfflineReqPending = True

                                    SnFnAdd(1, 1, 65, 1)
                                Else
                                    Call HandleOffline()
                                End If
                            Else
                                If g_fHSMSConnected Then
                                    g_nChangedMode = UnitInfo.RemoteStatus
                                    ' online mode changes  
                                    SnFnAdd(nPortPos, 1, 65, 1)
                                Else
                                    'if not connected, post event directly
                                    Call HandleOffline()
                                End If
                            End If

                            'End If
                        End If

                        If Not fSent Then
                            ' check whether <Status> & <SubStaus> changes
                            'If nPrevStatus <> UnitInfo.EQStatus Or nPrevSubStatus <> UnitInfo.EQSubStatus Then
                            If i <> MAIN_UNIT Then
                                If g_fHSMSConnected Then
                                    AddReportUnitNo(i)
                                    ' sub unit, report S1F65
                                    SnFnAdd(UnitInfo.UnitNo, 1, 65, 1, 0)
                                End If
                            End If
                            'End If
                        End If
                    End If

                    Exit Sub
                End If
            Next i

            WriteLogInfo(eLogType.TYPE_SYS, vbTab & "UnitInfoChanged, no match UnitID->" & CStr(UnitInfo.UnitNo))
        Catch ex As Exception
            WrigeExceptionLog("Sub UnitInfoChanged", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S1F67 CST status change"
    Public Function S1F67CassetteStatusChanged(ByVal nPortPos As Integer, ByVal nNewStatus As eCassetteStatus) As Integer
        Try
            Dim idxLot As Integer

            WriteLogInfo(eLogType.TYPE_METHOD, "CassetteStatusChanged, PortPos = " & CStr(nPortPos) & ", Status = " & CStr(nNewStatus))

            idxLot = SearchLotByPort(nPortPos)
            If idxLot <= 0 Then
                WriteLogInfo(eLogType.TYPE_METHOD, "CassetteStatusChanged, Cannot find PortInfo!")
                Exit Function
            End If

            If nNewStatus = eCassetteStatus.CSTA_END Then
                WriteLogInfo(eLogType.TYPE_METHOD, "No report CSTA_END, use CassetteProcessEnd!")
                Exit Function
            End If

            If MyLotInfo(idxLot).CassetteStatus = nNewStatus Then
                WriteLogInfo(eLogType.TYPE_METHOD, "Cassette status is not changed")
                Exit Function
            End If

            MyLotInfo(idxLot).CassetteStatus = nNewStatus

            If IsOnLineMode() Then
                If IsLotRunningBeforeOnLine(nPortPos) Then Exit Function
                If Not IsMGVRunCIM(nPortPos) Then Exit Function

                AddReportLotStatus(nNewStatus, nPortPos)
                SnFnAdd(nPortPos, 1, 67, 1)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub CassetteStatusChanged", ex.ToString)
        End Try
    End Function

    'S1F67 could be normal end or aborted by op or cancel recipe confirm
    Public Function CassetteProcessEnd(ByVal nPortPos As Integer, ByVal nEndCode As eProcessENDCode) As Integer
        Try
            Dim idxLot As Integer
            Dim idxState As Integer

            WriteLogInfo(eLogType.TYPE_METHOD, "CassetteProcessEnd, PortPos = " & CStr(nPortPos) & ", EndCode = " & CStr(nEndCode))

            idxLot = SearchLotByPort(nPortPos)
            If idxLot <= 0 Then
                WriteLogInfo(eLogType.TYPE_METHOD, "CassetteProcessEnd, Cannot find PortInfo!")
                Exit Function
            End If

            MyLotInfo(idxLot).CassetteStatus = eCassetteStatus.CSTA_END
            MyLotInfo(idxLot).ProcessEndCode = nEndCode
            MyPortInfo(nPortPos).PortStatus = ePortStatus.TSIP_END

            idxState = GetStateIndex(nPortPos)
            MyPortStateControl(idxState).fProcessEnd = True
            m_LineType = eLineType.LTYPE_FIMACRO


            If IsOnLineMode() Then
                ' report even Online->Offline->Online
                ' If IsLotRunningBeforeOnLine(nPortPos) Then Exit Function
                If Not IsMGVRunCIM(nPortPos) Then Exit Function

                SnFnAdd(nPortPos, 1, 67, 1, 1)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub CassetteProcessEnd", ex.ToString)
        End Try

    End Function
#End Region

#Region "S1F73"
    Public Sub S1F73CSTLoadReq(ByVal nPort As Integer)
        WriteLogInfo(eLogType.TYPE_METHOD, "S1F73CSTLoadReq, PortPos = " & nPort.ToString)
        SnFnAdd(nPort, 1, 73, 1, 0)
    End Sub

    Public Function S1F73PortDisable(ByVal nPortPos As Integer) As Integer
        Try
            Dim idxLot As Integer
            'Add By William 2009/08/05
            'Bebore CST Arrive CLS LotInfor first and delete timeout setting
            'RemoveLot(nPortPos)

            WriteLogInfo(eLogType.TYPE_METHOD, "CassetteArrived, PortPos = " & CStr(nPortPos))
            g_afCassetteUnloadReq(nPortPos) = False
            g_afCassetteRemoveReq(nPortPos) = False
            MyPortInfo(nPortPos).PortStatus = ePortStatus.TSIP_DISABLE

            If IsOnLineMode() Then
                If Not IsMGVRunCIM(nPortPos) Then Exit Function
                SnFnAdd(GetStateIndex(nPortPos), 1, 73, 1, 2)
            Else
                MyPortInfo(nPortPos).PortStatus = ePortStatus.TSIP_DISABLE
                idxLot = SearchLotByPort(nPortPos)
                If idxLot <= 0 Then
                    AddLot(nPortPos)
                End If
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub CassetteArrived", ex.ToString)
        End Try
    End Function

    Public Function S1F73CassetteArrived(ByVal nPortPos As Integer) As Integer
        Try
            Dim idxLot As Integer
            'Add By William 2009/08/05
            'Bebore CST Arrive CLS LotInfor first and delete timeout setting
            'RemoveLot(nPortPos)

            WriteLogInfo(eLogType.TYPE_METHOD, "CassetteArrived, PortPos = " & CStr(nPortPos))
            g_afCassetteUnloadReq(nPortPos) = False
            g_afCassetteRemoveReq(nPortPos) = False

            If IsOnLineMode() Then
                If Not IsMGVRunCIM(nPortPos) Then Exit Function
                SnFnAdd(GetStateIndex(nPortPos), 1, 73, 1, 1)
            Else
                MyPortInfo(nPortPos).PortStatus = ePortStatus.TSIP_CST_PRESENT
                idxLot = SearchLotByPort(nPortPos)
                If idxLot <= 0 Then
                    AddLot(nPortPos)
                End If
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub CassetteArrived", ex.ToString)
        End Try
    End Function

    Public Sub S1F73VirtualCSTLoadComp(ByVal nPortPos As Integer)
        If IsOnLineMode() Then
            'Loader port change to Unloader Port,re-issue load complete
            WriteLogInfo(eLogType.TYPE_SYS, "Update Port Info Step:3(Change Loader Mode to Unloader Mode")
            SnFnAdd(GetStateIndex(nPortPos), 1, 73, 1, 1)

            'InsertSequence(eOnLineStep.ONL_ANYTIME_LOADCOMPLETE, nPortPos)
            g_afCSTVLoad(nPortPos) = True
        End If
    End Sub
#End Region

#Region "S1F75"
    Public Function S1F75CassetteUnclamped(ByVal nPortPos As Integer) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "CassetteUnclamped, PortPos = " & CStr(nPortPos))

            If IsOnLineMode() Then
                If Not IsMGVRunCIM(nPortPos) Then Exit Function

                g_afCassetteUnloadReq(nPortPos) = True
                SnFnAdd(GetStateIndex(nPortPos), 1, 75, 1, 0)
            Else
                MyPortInfo(nPortPos).PortStatus = ePortStatus.TSIP_END_WITHUNLOAD
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub CassetteUnclamped", ex.ToString)
        End Try

    End Function

    'S1F75
    Public Function S1F75CassetteRemoved(ByVal nPortPos As Integer) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "CassetteRemoved, PortPos = " & CStr(nPortPos))

            If IsOnLineMode() Then
                If Not IsMGVRunCIM(nPortPos) Then Exit Function

                g_afCassetteRemoveReq(nPortPos) = True

                SnFnAdd(GetStateIndex(nPortPos), 1, 75, 1, 1)
            Else
                PortRemove(nPortPos)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub CassetteRemoved", ex.ToString)
        End Try
    End Function    

#End Region

#Region "S1F88 Reply WIP Data"    'S1F88 
    Public Function S1F88ReplyWIPData(ByRef WIPInfo() As prjSECS.clsWIPDataInTool) As Integer
        Try
            Dim nFor As Integer
            ReDim MyWIPInfo(UBound(WIPInfo))
            For nFor = 1 To UBound(WIPInfo)
                MyWIPInfo(nFor) = New prjSECS.clsWIPDataInTool
            Next

            WriteLogInfo(eLogType.TYPE_METHOD, "ReplyWIPData")
            MyWIPInfo = WIPInfo
            'SnFnAdd(0, 1, 88, 0)
            MySECS.RST_ReplyWIPData(WIPInfo)
        Catch ex As Exception
            WrigeExceptionLog("S1F88ReplyWIPData", ex.ToString)
        End Try

    End Function
#End Region

#Region " S1F97 RecipeChanged"
    Public Function S1F97RecipeChanged(ByVal nUnitNo As Integer, ByRef strPPID As String) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "RecipeChanged, UnitNo = " & CStr(nUnitNo) & ", PPID = " & strPPID)

            If IsOnLineMode() Then
                If g_fHSMSConnected Then
                    AddReportRecipeChange(MyUnitInfo(nUnitNo).ToolID, strPPID, GetNow)
                    SnFnAdd(0, 1, 97, 1)                    
                End If
            Else
                AddRecipeToIni(MyUnitInfo(nUnitNo).ToolID, GetNow, strPPID)
            End If
        Catch ex As Exception
            WrigeExceptionLog("S1F97RecipeChanged", ex.ToString)
        End Try
    End Function
#End Region

#Region "S2F22 Reply Remote CMD<Reply S2F21>"
    'S2F21
    Public Function S2F22ReplyRemoteCommand(ByVal nPortPos As Integer, ByVal nReplyCode As eRemoteReplyCMD) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, " ReplyRemoteCommand, PortPos = " & CStr(nPortPos) & ", Code = " & CStr(nReplyCode))

            MyPortStateControl(GetStateIndex(nPortPos)).nCMDA = nReplyCode

            If IsOnLineMode() Then
                If Not IsMGVRunCIM(nPortPos) Then Exit Function

                If g_fRemotePause(nPortPos) Then
                    SnFnAdd(nPortPos, 2, 22, 0, nReplyCode)
                ElseIf g_fRemoteResume(nPortPos) Then
                    WriteLogInfo(eLogType.TYPE_SYS, "Port " & CStr(nPortPos) & " S2F21:Remote Resume==>Set timer(Remote Resume)")
                    TimerAdd(nPortPos, eTimerType.TIMER_WAITS2F21, m_ConversationTimeout)
                    SnFnAdd(nPortPos, 2, 22, 0, nReplyCode, 0)
                Else
                    SnFnAdd(GetStateIndex(nPortPos), 2, 22, 0, nReplyCode)
                End If
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub S2F22ReplyRemoteCommand", ex.ToString)
        End Try
    End Function

    'S2F21 For Online Monitor Mode
    Public Function S2F22MonitorRecipeConfirmed(ByVal nPortPos As Integer, Optional ByRef strNewRecipe As String = "") As Integer
        Try
            Dim idxLot As Integer

            WriteLogInfo(eLogType.TYPE_METHOD, "MonitorRecipeConfirmed, PortPos = " & CStr(nPortPos))

            idxLot = SearchLotByPort(nPortPos)
            If idxLot <= 0 Then
                WriteLogInfo(eLogType.TYPE_METHOD, "MonitorRecipeConfirmed, Cannot find PortInfo!")
                Exit Function
            End If

            If strNewRecipe <> "" Then
                MyPortInfo(nPortPos).CPPID = strNewRecipe

                MyLotInfo(idxLot).RecipeName = strNewRecipe
            End If

            MyLotInfo(idxLot).RecipeNeedConfirm = False
        Catch ex As Exception
            WrigeExceptionLog("Sub S2F22MonitorRecipeConfirmed", ex.ToString)
        End Try

    End Function
#End Region

#Region "S2F25 Loop-Back Test"
    Public Sub S2F25LoopBackTest()
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "LoopBackTest")

            If Not g_fHSMSConnected Then
                RaiseEvent S2F25LoopBackResult(False)
                Exit Sub
            End If

            SnFnAdd(0, 2, 25, 1)
        Catch ex As Exception
            WrigeExceptionLog("Sub LoopBackTest", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S2F42 EQ Eemote CMD Reply"
    Public Sub S2F42ReplyEQRemoteCMD(ByVal nCMD As eRemoteReplyCMD)
        Try
            If IsOnLineMode() Then
                WriteLogInfo(eLogType.TYPE_METHOD, "S2F42 CMD=" & nCMD)
                SnFnAdd(0, 2, 42, 0, nCMD)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub ReplyEQRemoteCMD", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S5F65 Alarm Report"
    'record the alarm released which occur in online
    Private Sub RecordOfflineReleaseAlarm(ByRef vXAlarmInfo As clsMyAlarmStructure)
        Try
            Dim i As Integer
            Dim vXAlarm As clsMyAlarmStructure

            For i = 1 To mAlarmOut.Count
                vXAlarm = mAlarmOut.Item(i)
                If vXAlarm.MyUnitNo = vXAlarmInfo.MyUnitNo And vXAlarm.MyAlarmStructrue.AlarmType = vXAlarmInfo.MyAlarmStructrue.AlarmType And vXAlarm.MyAlarmStructrue.AlarmID = vXAlarmInfo.MyAlarmStructrue.AlarmID Then
                    mAlarmOfflineCol.Add(vXAlarmInfo)
                    mAlarmOut.Remove(i)
                    vXAlarm.MyAlarmStructrue = Nothing
                    vXAlarm = Nothing
                    Exit For
                End If
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub RecordOfflineReleaseAlarm", ex.ToString)
        End Try
    End Sub

    ' report S5F65 then S1F65
    Public Function S5F65ReportAlarm(ByRef vXAlarmInfo As clsMyAlarmStructure, ByRef UnitInfo As prjSECS.clsUnitStructure) As Integer
        Try
            Dim vXAlarm As clsMyAlarmStructure
            Dim fRelease As Boolean

            If vXAlarmInfo.MyAlarmStructrue.AlarmType Then
                WriteLogInfo(eLogType.TYPE_METHOD, "ReportAlarmExt -> Occurred, UnitNo = " & CStr(vXAlarmInfo.MyUnitNo) & ", ID=" & vXAlarmInfo.MyAlarmStructrue.AlarmID)
            Else
                WriteLogInfo(eLogType.TYPE_METHOD, "ReportAlarmExt -> Released, UnitNo = " & CStr(vXAlarmInfo.MyUnitNo) & ", ID=" & vXAlarmInfo.MyAlarmStructrue.AlarmID)
            End If

            ' copy to local
            vXAlarm = New clsMyAlarmStructure
            vXAlarm.MyAlarmStructrue = New prjSECS.clsAlarmStructure

            vXAlarm.MyUnitNo = vXAlarmInfo.MyUnitNo
            vXAlarm.GlassAffect = vXAlarmInfo.GlassAffect
            vXAlarm.DateTimeInfo = vXAlarmInfo.DateTimeInfo
            vXAlarm.WithGx = vXAlarmInfo.WithGx
            With vXAlarmInfo
                vXAlarm.MyAlarmStructrue.AlarmFlag = .MyAlarmStructrue.AlarmFlag
                vXAlarm.MyAlarmStructrue.AlarmType = .MyAlarmStructrue.AlarmType
                vXAlarm.MyAlarmStructrue.AlarmID = .MyAlarmStructrue.AlarmID
                vXAlarm.MyAlarmStructrue.AlarmText = .MyAlarmStructrue.AlarmText

            End With

            If vXAlarm.MyAlarmStructrue.AlarmFlag = eAlarmFlag.TYPE_RELEASE Then
                fRelease = True
            End If

            If IsOnLineMode() Then
                mAlarmIn.Add(vXAlarm)
                SnFnAdd(0, 5, 65, 1)
            Else
                ' find any alarm released offline which occurred in online
                If vXAlarm.MyAlarmStructrue.AlarmFlag = eAlarmFlag.TYPE_RELEASE Then
                    RecordOfflineReleaseAlarm(vXAlarm)
                Else
                    ' free useless memory
                    mAlarmOfflineCol.Add(vXAlarmInfo)
                    vXAlarm.MyAlarmStructrue = Nothing
                    vXAlarm = Nothing
                End If
            End If

            ' update unit info
            If fRelease Then
                'clear alarm ID to prevent from host query (still exist alarm code)
                UnitInfo.Alarm.AlarmID = 0
            End If

            WriteLogInfo(eLogType.TYPE_SYS, "ReportAlarmExt call UnitInfoChanged")
            UpdateUnitInfo(UnitInfo.UnitNo, UnitInfo)
        Catch ex As Exception
            WrigeExceptionLog("Sub ReportAlarm", ex.ToString)
        End Try
    End Function
#End Region

#Region "S6F85 Glass erase "
    Public Sub S6F85GlassErase(ByRef strToolID As String, ByRef strGlassID As String)
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "GlassErase, GlassID = " & strGlassID)

            If IsOnLineMode() Then
                m_strToolID = strToolID
                m_strGlassIDErase = strGlassID
                SnFnAdd(0, 6, 85, 1, , , strToolID, strGlassID)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub S6F85GlassErase", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S6F87 GlassID Unmatch"
    Public Function S6F87WorkIDUnmatch(ByVal nUnitNo As Integer, ByRef strGlassIDHost As String, ByRef strGlassIDVCR As String) As Integer
        Try

            WriteLogInfo(eLogType.TYPE_METHOD, "WorkIDUnmatch, Host = " & strGlassIDHost & ", VCR = " & strGlassIDVCR)

            m_nUnitNoWorkID = nUnitNo
            m_strGlassIDHost = strGlassIDHost
            m_strGlassIDVCR = strGlassIDVCR

            If IsOnLineMode() Then
                SnFnAdd(0, 6, 87, 1, , , strGlassIDHost, strGlassIDVCR)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub S6F87WorkIDUnmatch", ex.ToString)
        End Try
    End Function
#End Region

#Region "S6F91 Slot process complete "
    Public Sub S6F91SlotProcessComplete(ByRef GlassProcessInfo() As prjSECS.clsGxReport) 'ByRef strGlassID As String, ByRef strEQToolID As String, ByRef strRSTPPID As String, ByRef strStartTime As String, ByRef strEndTime As String) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "SlotProcessComplete") ', GlassID = " & strGlassID & ", EQToolID = " & strEQToolID & ", RSTPPID = " & strRSTPPID)

            If IsOnLineMode() Then
                MyGlassProcessInfo = GlassProcessInfo
                SnFnAdd(0, 6, 91, 1)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub S6F91SlotProcessComplete", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S7F4 Recipe Parameter Report"
    Public Sub S7F4ReportRecipeParameter(ByRef vRecipeInfo As prjSECS.clsRecipeStructure)
        Try
            If IsOnLineMode() Then
                MyRecipeParameterReport = vRecipeInfo
                SnFnAdd(0, 7, 4, 0)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub S7F4ReportRecipeParameter", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S7F68 PPID Modify Reply"
    Public Sub S7F68ReplyPPIDModifyLasTime(ByVal strPPID As String, ByVal nAck As Integer, ByVal strDate As String)
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "Reply Last Modify Recipe Info..." & strPPID & "/" & nAck & "/" & strDate)

            g_colRecipeLastModifyInfo.Add(strPPID & "," & nAck & "," & strDate)
            SnFnAdd(0, 7, 68, 0)
        Catch ex As Exception
            WrigeExceptionLog("Sub ReplyPPIDModifyLasTime", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S7F71 Request Lot Info"
    Public Function S7F71MappingCompleted(ByVal nPortPos As Integer, ByRef anSlotMaps() As Integer) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "MappingCompleted, PortPos = " & CStr(nPortPos))

            If IsOnLineMode() Then
                If Not IsMGVRunCIM(nPortPos) Then Exit Function
                SnFnAdd(nPortPos, 7, 71, 1)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub S7F71MappingCompleted", ex.ToString)
        End Try
    End Function

#End Region

#Region "S7F65 Lot Data Download Confirm"
    Public Function S7F65CassetteDataConfirm(ByVal nPortPos As Integer, ByVal nReplyCode As Integer) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "CassetteDataConfirm, PortPos = " & CStr(nPortPos) & ", Code = " & CStr(nReplyCode))

            MyPortStateControl(GetStateIndex(nPortPos)).nAckC7 = nReplyCode

            If IsOnLineMode() Then
                If Not IsMGVRunCIM(nPortPos) Then Exit Function
                SnFnAdd(GetStateIndex(nPortPos), 7, 66, 0)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub S7F65CassetteDataConfirm", ex.ToString)
        End Try
    End Function    
#End Region

#Region "S7F65 Copy Lot Data By PortNo"
    Public Function S7F65FillLot(ByRef LotData As prjSECS.clsLotStructure) As Boolean

        Try
            Dim idxLot As Integer
            Dim i As Integer
            Dim MySlotInfo(MAX_SLOTS) As prjSECS.clsSlotStructure
            Dim nIdxSlot As Integer = 0

            idxLot = SearchLotByPort(LotData.PortPosition)
            If idxLot <= 0 Then
                idxLot = AddLot(LotData.PortPosition)
                If idxLot <= 0 Then
                    Exit Function
                End If
            End If

            'FillLot = True

            MyLotInfo(idxLot).CassetteID = LotData.CassetteID
            MyLotInfo(idxLot).CassetteStatus = LotData.CassetteStatus
            MyLotInfo(idxLot).ProductCode = LotData.ProductCode
            MyLotInfo(idxLot).ProductCategory = LotData.ProductCategory
            MyLotInfo(idxLot).MeasurementID = LotData.MeasurementID
            MyLotInfo(idxLot).OperationID = LotData.OperationID
            MyLotInfo(idxLot).RecipeName = LotData.RecipeName
            MyLotInfo(idxLot).RecipeCode = LotData.RecipeCode
            MyLotInfo(idxLot).PPIDChanged = LotData.PPIDChanged
            MyLotInfo(idxLot).ProcessEndCode = LotData.ProcessEndCode
            MyLotInfo(idxLot).LotCancel = LotData.LotCancel
            MyLotInfo(idxLot).IsLotDataReceived = LotData.IsLotDataReceived
            MyLotInfo(idxLot).UnderSlotsSelection = LotData.UnderSlotsSelection
            MyPortInfo(idxLot).CPPID = LotData.RecipeName

            'Modify 2009/08/10 Create 56 Empty Slot First==>Write the lot's slot to right slot position
            For i = 1 To MAX_SLOTS
                MySlotInfo(i) = New prjSECS.clsSlotStructure
            Next

            For i = 1 To MAX_SLOTS
                MySlotInfo(i) = New prjSECS.clsSlotStructure

                MySlotInfo(i).SlotNo = LotData.Slots(i).SlotNo
                MySlotInfo(i).GlassID = LotData.Slots(i).GlassID
                MySlotInfo(i).LastOperationID = ""
                MySlotInfo(i).PLineID = ""
                MySlotInfo(i).ProcessToolID = ""
                MySlotInfo(i).DMQCToolID = ""
                MySlotInfo(i).GlassGradeByString = ""
                MySlotInfo(i).DMQCGradeByString = ""

                MySlotInfo(i).PSHGroup = ""
                MySlotInfo(i).ChipGradeByString = LotData.Slots(i).ChipGradeByString
                MySlotInfo(i).ReworkByString = ""
                MySlotInfo(i).ScrapByString = ""
                MySlotInfo(i).FIRemarkByString = ""
                MySlotInfo(i).FIFCFlagByString = ""
            Next

            For i = 1 To MAX_SLOTS
                UpdateSlotInfo(MyLotInfo(idxLot).Slots(i), MySlotInfo(i))
            Next i

            S7F65FillLot = True
        Catch ex As Exception
            WrigeExceptionLog("Sub FillLot", ex.ToString)
        End Try
    End Function
#End Region

#Region "S10F1 Terminal Send"
    Public Function S10F1TerminalSend(ByRef strText As String) As Integer
        Try
            WriteLogInfo(eLogType.TYPE_METHOD, "TerminalSend")

            'If IsOnLineMode() Then
            SnFnAdd(0, 10, 1, 0, , , strText)
            'End If
        Catch ex As Exception
            WrigeExceptionLog("Sub TerminalSend", ex.ToString)
        End Try
    End Function
#End Region


    'When Slot Insert to CST Port Complete
    Public Function InsertSlotToPort(ByVal nPortPos As Integer, ByRef SlotInfo As prjSECS.clsSlotStructure, ByVal fIsSlotProcess As Boolean, Optional ByVal ProductCategory As eProductCategory = eProductCategory.PRODCAT_NONE, Optional ByVal strPPID As String = "") As Integer
        Try
            Dim idxPort As Integer
            Dim idxLot As Integer
            Dim i As Integer
            Dim nFirstNonEmpty As Integer
            Dim idxSlotPos As Integer

            WriteLogInfo(eLogType.TYPE_METHOD, "InsertSlotToPort, PortPos = " & CStr(nPortPos) & ", SlotNo = " & CStr(SlotInfo.SlotNo) & " ; " & SlotInfo.GlassGradeByString & " ; " & SlotInfo.ChipGradeByString & "; IsProcessed=" & fIsSlotProcess)

            idxPort = GetPortIndex(nPortPos)
            If idxPort <= 0 Then
                WriteLogInfo(eLogType.TYPE_SYS, "InsertSlotToPort, Cannot find related PortPos = " & CStr(nPortPos))
                Exit Function
            End If

            idxLot = SearchLotByPort(nPortPos)
            If idxLot > 0 Then
                'Find first non-empty from the top
                For i = MAX_SLOTS To 1 Step -1
                    If MyLotInfo(idxLot).Slots(i).SlotNo <> 0 Then
                        nFirstNonEmpty = i
                        Exit For
                    End If
                Next i

                ' if not found, place from the top
                If nFirstNonEmpty = 0 Then
                    nFirstNonEmpty = MAX_SLOTS
                End If


                If SlotInfo.SlotNo <> 0 Then
                    idxSlotPos = SlotInfo.SlotNo
                    If MyLotInfo(idxLot).Slots(idxSlotPos).SlotNo <> 0 Then
                        For i = nFirstNonEmpty To 1 Step -1
                            If MyLotInfo(idxLot).Slots(i).SlotNo = 0 Then
                                idxSlotPos = i
                                Exit For
                            End If
                        Next i
                    End If
                Else
                    WriteLogInfo(eLogType.TYPE_SYS, "InsertSlotToPort, Cannot find related SloNo = " & CStr(SlotInfo.SlotNo))
                    Exit Function
                End If

                'If idxSlotPos > 0 Then
                If SlotInfo.SlotNo = MAX_SLOTS Then

                    MyLotInfo(idxLot).ProductCategory = ProductCategory
                    MyLotInfo(idxLot).RecipeName = strPPID
                    MyPortInfo(idxLot).CPPID = strPPID
                    MyPortInfo(idxLot).PortCategory = ProductCategory

                    WriteLogInfo(eLogType.TYPE_SYS, "ProductCategory = " & CStr(ProductCategory))
                    WriteLogInfo(eLogType.TYPE_SYS, "RecipeName = " & CStr(strPPID))
                End If


                UpdateSlotInfo(MyLotInfo(idxLot).Slots(idxSlotPos), SlotInfo)
                MyProcessEndInfo(idxLot).Slots(idxSlotPos).IsGlassProecssed = fIsSlotProcess

            Else
                WriteLogInfo(eLogType.TYPE_SYS, "InsertSlotToPort, Cannot find Lotinfo")
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub InsertSlotToPort", ex.ToString)
        End Try

    End Function

    'When Slot Out From CV CST Port Complete
    Public Sub RemoveSlotFromPort(ByVal nPortPos As Integer, ByVal nSlotNo As Integer)
        Try
            Dim idxPort As Integer
            Dim idxLot As Integer
            Dim idxSlot As Integer

            WriteLogInfo(eLogType.TYPE_METHOD, "RemoveSlotFromPort, PortPos = " & CStr(nPortPos) & ", SlotNo = " & CStr(nSlotNo))

            idxPort = GetPortIndex(nPortPos)
            If idxPort <= 0 Then
                WriteLogInfo(eLogType.TYPE_SYS, "RemoveSlotFromPort, Cannot find related PortPos = " & CStr(nPortPos))
                Exit Sub
            End If

            idxLot = SearchLotByPort(nPortPos)
            If idxLot > 0 Then
                idxSlot = GetSlotIndex(idxLot, nSlotNo)

                If idxSlot > 0 Then
                    ' remove slot information
                    RemoveSlotInfo(idxLot, idxSlot)
                Else
                    WriteLogInfo(eLogType.TYPE_SYS, "RemoveSlotFromPort, Cannot find slot info, Slot = " & CStr(nSlotNo))
                End If
            Else
                WriteLogInfo(eLogType.TYPE_SYS, "RemoveSlotFromPort, Cannot find Lotinfo")
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub RemoveSlotFromPort", ex.ToString)
        End Try
    End Sub

    Public Function GetOperatorID(ByVal idxPort As Integer) As String
        If MyPortInfo(idxPort).AGVMode Then
            GetOperatorID = m_OperatorIDAGV
        Else
            GetOperatorID = m_OperatorIDAGV
        End If
    End Function

    Public Sub ShowHSMSSetting()
        Dim MyHSMSForm As New frmHSMSSetting
        MyHSMSForm.ShowHSMSSetting(Me)
        MyHSMSForm.LoadCIMIniValue()
    End Sub

    'HSMS RJ45 Connect Status
    Public Sub HSMSIsChanged()
        Try
            ' check whether online or not
            ' if not, close port and re-open again to reflect the setting
            If MyUnitInfo(MAIN_UNIT).RemoteStatus = eRemoteStatus.MODE_OFFLINE And Not g_fTryOnOffLine Then
                WriteLogInfo(eLogType.TYPE_SYS, "ClosePort - Change setting")
                MySecxX.RST_PortCloase()

                SECS_ReadSetting(m_strIniFileFullName)
                WriteLogInfo(eLogType.TYPE_SYS, "OpenPort - Change setting")
                MySecxX.RST_PortOpen()
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub HSMSIsChanged", ex.ToString)
        End Try
    End Sub

    'Don't Use....
    Public Sub New()
        Try
            MyTimeout.Interval = 1000
            MyDispatcher.Interval = 1000
            MyReportAlarm.Interval = 1000
            MyReportRecipe.Interval = 1000
            MySnFnTimer.Interval = 1000
            MyHeartBeat.Interval = 1000 * 60

            MySecxX = MySECS
            MyLog.InitLogObj("CCIM")

            'm_strIniFileFullName = "D:\AUO\L8BCCIM\" & STR_HSMSINI
            ' set default value
            'SECS_ReadSetting(m_strIniFileFullName)

            ' set default value
            ' default to false
            'MySecxX.DisplayLinkTest = False
            Call InitEquipment()

            MyTimeout.Enabled = True
            MyDispatcher.Enabled = True
            MyHeartBeat.Enabled = True
            MySnFnTimer.Enabled = True
            MyReportRecipe.Enabled = True
            MyReportAlarm.Enabled = True
        Catch ex As Exception
            WrigeExceptionLog("Sub New...", ex.ToString)
        End Try
    End Sub

    ' insert a sequence into the flow
    ' it will check whether the driver is waiting for message or not
    ' if YES => delay sending the sequence until driver is ok to send
    ' if NO  => trigger, send now

    ''Public Sub InsertSequence(ByVal nSequence As Integer, ByVal nInsertPort As Integer)
    ''    Try
    ''        Dim idxInsertedState As Integer
    ''        Dim nTable As Integer

    ''        If IsCompletelyOffline() Then Exit Sub

    ''        If nInsertPort <> 0 Then
    ''            If Not IsMGVRunCIM(nInsertPort) Then Exit Sub
    ''        End If

    ''        If Not g_fHSMSConnected Then
    ''            WriteLogInfo(eLogType.TYPE_SYS, "HSMS is disconnected, skip InsertSequence")
    ''            Exit Sub
    ''        End If

    ''        WriteLogInfo(eLogType.TYPE_SYS, "InsertSequence <" & GetSeqName(nSequence) & "> at Port " & CStr(nInsertPort))

    ''        nTable = TABLE_ONLINE

    ''        ' if not specify port to insert, insert at non-suspended port
    ''        If nInsertPort = 0 Then
    ''            idxInsertedState = GetNotSuspendedPort()
    ''        Else
    ''            idxInsertedState = GetStateIndex(nInsertPort)
    ''        End If

    ''        EnqueueSeq(idxInsertedState, nTable, nSequence)

    ''        'more accurate
    ''        If g_colEventQueue.Count <= 0 And g_colInsertSeq.Count = 1 And Not g_fInsideEventTrigger Then
    ''            ExecInsertSequence(idxInsertedState, nTable, nSequence)
    ''        Else
    ''            WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Sequence inserted is buffered")
    ''        End If
    ''    Catch ex As Exception
    ''        WrigeExceptionLog("Sub InsertSequence", ex.ToString)
    ''    End Try
    ''End Sub

    Public Function IsActiveStep(ByVal idxState As Integer) As Boolean
        Try
            Select Case MyPortStateControl(idxState).idxTable
                Case TABLE_OFFLINE
                    IsActiveStep = MyOffLineTable(MyPortStateControl(idxState).nCurrStep).Active

                Case TABLE_ONLINE
                    IsActiveStep = MyOnLineTable(MyPortStateControl(idxState).nCurrStep).Active

            End Select
        Catch ex As Exception
            WrigeExceptionLog("Sub IsActiveStep", ex.ToString)
        End Try
    End Function

    '    Public Sub EventTrigger(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunc As Integer)
    '        Try
    '            Dim nNextStep As Integer
    '            Dim fMatched As Boolean
    '            Dim strTrace As String
    '            Dim fInsertedExecuting As Boolean

    '            Dim idxInserted As Integer
    '            Dim idxEvent As Integer
    '            Dim Seq As New clsInsertSeq
    '            Dim evt As New clsEventItem

    '            ' check whether online or not
    '            ' if not online, have to reject the request except loopback test
    '            ' (loopback test is handled in the SECS driver)
    '            If IsCompletelyOffline() Then
    '                ' it will not receive the last message if offline (S1F66)
    '                ' => offline request is categorize as "not completely offline"
    '                MySecxX.RST_TransactionAbort(nStream)

    '                Exit Sub
    '            End If


    '            If Not g_fHSMSConnected Then Exit Sub

    '            If MsgPreProcess(idxState, nStream, nFunc) Then
    '                ' this message is queued...
    '                Exit Sub
    '            Else
    '                If nStream = 7 And nFunc = 71 Then
    '                    WriteLogInfo(eLogType.TYPE_SYS, "EVENT Trigger S7F71...")
    '                    MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_REQLOTDATA
    '                End If
    '            End If

    '            g_fInsideEventTrigger = True

    '            strTrace = "Port " & CStr(MyPortStateControl(idxState).nPortNo) & " Stream: " & CStr(nStream) & " Func: " & CStr(nFunc)
    '            WriteLogInfo(eLogType.TYPE_SYS, strTrace)

    'L50:
    '            fMatched = MatchSnFm(idxState, nStream, nFunc)
    '            WriteLogInfo(eLogType.TYPE_SYS, "========================================Current Step" & MyPortStateControl(idxState).nCurrStep)
    '            If Not fMatched Then
    '                ' not expected msg, check whether to dequeu or not
    '                MsgUnmatchProcess(idxState, nStream, nFunc)

    '                strTrace = vbTab & "No matched stream/function, skipped"
    '                WriteLogInfo(eLogType.TYPE_SYS, strTrace)
    '                g_fInsideEventTrigger = False
    '                Exit Sub
    '            End If

    '            If MyPortStateControl(idxState).fWait2NdMSG Then
    '                ' msg matched, determine next step
    'L100:
    '                MyPortStateControl(idxState).fWait2NdMSG = False
    '                nNextStep = RspHandler(idxState, MyPortStateControl(idxState).nCurrStep)

    '                ' check whether this is returned from inserted sequence
    '                If MyPortStateControl(idxState).nPrevStep <> 0 Then
    '                    If nNextStep <> 0 Then
    '                        ' special treatment for the following msg
    '                        ' EQSTATUS & LOTSTATUS should be no nextstep
    '                        ' if the nextstep is designated, it means we cannot
    '                        ' remove the msg from the insert buffer
    '                        ' => dequeue first then continue the designated nextstep
    '                        If MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_ANYTIME_EQSTATUS Or _
    '                           MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_ANYTIME_LOTSTATUS Then
    '                            ' do nothing...
    '                        Else
    '                            ' this sequence contain "multiple steps"
    '                            ' executing till no next step...
    '                            fInsertedExecuting = True
    '                            GoTo L150
    '                        End If
    '                    End If

    '                    WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Sequence inserted is ended")

    '                    Seq = DequeueSeq(idxState)

    '                    ' switch back to original
    '                    MyPortStateControl(idxState).idxTable = MyPortStateControl(idxState).idxPrevTable
    '                    MyPortStateControl(idxState).nCurrStep = MyPortStateControl(idxState).nPrevStep

    '                    MyPortStateControl(idxState).idxPrevTable = 0
    '                    MyPortStateControl(idxState).nPrevStep = 0
    '                End If
    'L150:
    '                If nNextStep <> 0 Then
    '                    ProceedNextStep(idxState, nNextStep)
    '                End If


    '                ' Do not check event queue while inserted sequence is running
    '                If Not fInsertedExecuting Then
    '                    idxInserted = GetInsertedSeqPending(idxState)
    '                    If idxInserted Then
    '                        Seq = PokeSeq(idxInserted)

    '                        WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Execute inserted sequence " & CStr(Seq.InsertSeq))
    '                        ' remember new state's current status
    '                        MyPortStateControl(idxState).idxPrevTable = MyPortStateControl(idxState).idxTable
    '                        MyPortStateControl(idxState).nPrevStep = MyPortStateControl(idxState).nCurrStep

    '                        ' start new state
    '                        MyPortStateControl(idxState).idxTable = Seq.InsertTable
    '                        MyPortStateControl(idxState).nCurrStep = Seq.InsertSeq

    '                        ' could be passive step, force to execute, such as S2F21
    '                        MyPortStateControl(idxState).fForceExecute = True
    '                    Else
    '                        idxEvent = GetFirstBufMsg(idxState)
    '                        If idxEvent = 1 Then
    '                            evt = GetBufMsgByIndex(idxEvent)
    '                            idxState = evt.Index
    '                            nStream = evt.StreamID
    '                            nFunc = evt.FunctionID

    '                            ' Oops... check it out
    '                            WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Get message from queue - " & EventFormat(evt.Index, evt.StreamID, evt.FunctionID))

    '                            'check whether offline request
    '                            If g_fOfflineReq Then
    '                                If evt.StreamID = 1 And evt.FunctionID = 65 Then
    '                                    MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_EQSTATUS_OFFLINE
    '                                End If
    '                            Else
    '                                If evt.StreamID = 7 And evt.FunctionID = 71 Then
    '                                    MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_REQLOTDATA
    '                                End If
    '                            End If

    '                            GoTo L50
    '                        End If
    '                    End If
    '                End If

    '                If (IsActiveStep(idxState) Or MyPortStateControl(idxState).fForceExecute) And Not MyPortStateControl(idxState).fSuspend Then
    '                    If MyPortStateControl(idxState).fForceExecute Then
    '                        MyPortStateControl(idxState).fForceExecute = False
    '                    End If

    '                    ' send primary message
    '                    GoTo L200
    '                End If
    '            Else
    'L200:
    '                ' action routine: could be send or reply msg
    '                If ActionRoutine(idxState, MyPortStateControl(idxState).nCurrStep) = ACTION_SKIP Then
    '                    WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Skip action")
    '                    GoTo L100
    '                End If

    '                ' Host send, EQP reply => dequeue (trans is finished)
    '                ' EQP send out => enqueue (wait Host's reply)
    '                MsgPostProcess(idxState, MyPortStateControl(idxState).nCurrStep)

    '                ' if this is a replied msg, go to next step!
    '                If Not MyPortStateControl(idxState).fWait2NdMSG Then GoTo L100
    '            End If

    '            g_fInsideEventTrigger = False
    '        Catch ex As Exception
    '            WrigeExceptionLog("Sub EventTrigger", ex.ToString)
    '        End Try

    '    End Sub

    ' there are 3 types of drive method
    ' 1. drive by reply of Host
    ' 2. EQ activate by calling EventTrigger
    ' 3. timer driven (dispatcher)

    ' this procedure is drived by timer

    'Public Sub T3TimeoutHandler()
    '    Try
    '        Dim idxState As Integer

    '        idxState = GetReplyState()
    '        If idxState <= 0 Then Exit Sub

    '        Select Case MyPortStateControl(idxState).idxTable
    '            Case TABLE_OFFLINE
    '                EventTrigger(idxState, MyOffLineTable(MyPortStateControl(idxState).nCurrStep).StreamID, MyOffLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID + 1)

    '            Case TABLE_ONLINE
    '                EventTrigger(idxState, MyOnLineTable(MyPortStateControl(idxState).nCurrStep).StreamID, MyOnLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID + 1)
    '        End Select
    '    Catch ex As Exception
    '        WrigeExceptionLog("Sub T3TimeoutHandler", ex.ToString)
    '    End Try

    'End Sub

    Public Sub GetOnLineTimeout(ByVal idxState As Integer)
        Try
            g_fTryOnOffLine = False
            MyUnitInfo(MAIN_UNIT).RemoteStatus = eRemoteStatus.MODE_OFFLINE

            Call ClearAllQueue()
            MyPortStateControl(idxState).idxTable = TABLE_OFFLINE
            MyPortStateControl(idxState).nCurrStep = 1
            MyPortStateControl(idxState).fWait2NdMSG = False

            RaiseEvent S1F90OnLineComplete(-1)
        Catch ex As Exception
            WrigeExceptionLog("Sub GetOnLineTimeout", ex.ToString)
        End Try
    End Sub

    Public Sub WaitHostTimeout(ByVal idxState As Integer)
        Try
            If MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_LOTDATA Then
                WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Port " & CStr(idxState) & ", Download recipe timeout!")
                g_nCTStream = 7
                g_nCTFunction = 65
                RaiseEvent S9F13ConversationTimeoutOccur(MyPortStateControl(idxState).nPortNo, g_nCTStream, g_nCTFunction)
                'Me.S9F13ReportConversationTimeout(7, 65)
            ElseIf MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_REMOTECMD Then
                WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Port " & CStr(idxState) & ", Remote command timeout")
                g_nCTStream = 2
                g_nCTFunction = 21
                RaiseEvent S9F13ConversationTimeoutOccur(MyPortStateControl(idxState).nPortNo, g_nCTStream, g_nCTFunction)
                'Me.S9F13ReportConversationTimeout(2, 21)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub WaitHostTimeout", ex.ToString)
        End Try
    End Sub

#End Region

    ' ================= Equip Event ======================
    ' in order to simulate from client, make all events public
#Region "Private Function/Sub"

    Private Function MatchSnFm(ByVal idxState As Integer, ByVal nStream As Integer, ByVal nFunc As Integer) As Boolean
        Try
            Dim nInc As Integer
            Dim i As Integer

            ' for secondary message, plus 1 before searching
            nInc = IIf(nFunc Mod 2 = 0, 1, 0)

            ' do not match "offline request" in normal sequence
            ' to prevent from matching other normal S1F65 message

            ' more accurate => offline request could be issued
            ' when previous reply is not received
            ' if we don't check the stream & function, the sequence would be wrong
            If g_fOfflineReq And nStream = 1 And nFunc = 65 Then
                g_fOfflineReq = False
                WriteLogInfo(eLogType.TYPE_SYS, "IN S1F65 OFF-LINE !!!")
            Else
                Select Case MyPortStateControl(idxState).idxTable
                    Case TABLE_OFFLINE
                        MatchSnFm = IIf(MyOffLineTable(MyPortStateControl(idxState).nCurrStep).StreamID = nStream _
                                        And (MyOffLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID + nInc) = nFunc, True, False)

                        WriteLogInfo(eLogType.TYPE_SYS, "Table= OFF LINE SS=" & MyOffLineTable(MyPortStateControl(idxState).nCurrStep).StreamID)
                        WriteLogInfo(eLogType.TYPE_SYS, "Table= OFF LINE DS=" & nStream)
                        WriteLogInfo(eLogType.TYPE_SYS, "Table= OFF LINE SF=" & MyOffLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID + nInc)
                        WriteLogInfo(eLogType.TYPE_SYS, "Table= OFF LINE DF=" & nFunc)

                    Case TABLE_ONLINE
                        MatchSnFm = IIf(MyOnLineTable(MyPortStateControl(idxState).nCurrStep).StreamID = nStream _
                                        And (MyOnLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID + nInc) = nFunc, True, False)

                        If g_afCassetteUnloadReq(MyPortStateControl(idxState).nPortNo) Then
                            If nStream = 1 And nFunc = 75 Then
                                MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_UNLOADREQ
                                MatchSnFm = True
                            End If
                        End If

                        If g_afCassetteRemoveReq(MyPortStateControl(idxState).nPortNo) Then
                            If nStream = 1 And nFunc = 75 Then
                                MyPortStateControl(idxState).nCurrStep = eOnLineStep.ONL_UNLOADCOMPLETE
                                MatchSnFm = True
                            End If
                        End If

                        WriteLogInfo(eLogType.TYPE_SYS, "Table= ON LINE SS=" & MyOnLineTable(MyPortStateControl(idxState).nCurrStep).StreamID)
                        WriteLogInfo(eLogType.TYPE_SYS, "Table= ON LINE DS=" & nStream)
                        WriteLogInfo(eLogType.TYPE_SYS, "Table= ON LINE SF=" & MyOnLineTable(MyPortStateControl(idxState).nCurrStep).FunctionID + nInc)
                        WriteLogInfo(eLogType.TYPE_SYS, "Table= ON LINE DF=" & nFunc)
                End Select
            End If

            If Not MatchSnFm Then
                WriteLogInfo(eLogType.TYPE_SYS, "Search abnormal- Stream: " & CStr(nStream) & " Function: " & CStr(nFunc))

                ' search the unexpected msg
                For i = START_OF_ABNORMAL To END_OF_ABNORMAL
                    MatchSnFm = IIf(MyOnLineTable(i).StreamID = nStream And (MyOnLineTable(i).FunctionID + nInc) = nFunc, True, False)
                    If MatchSnFm Then
                        '                If i = ONL_ALARM Then
                        '                    ' keep the current step
                        '                    MyPortStateControl(idxState).idxPrevTable = MyPortStateControl(idxState).idxTable
                        '                    MyPortStateControl(idxState).nPrevStep = MyPortStateControl(idxState).nCurrStep
                        '                End If

                        ' change current step since it is out of sequence
                        MyPortStateControl(idxState).idxTable = TABLE_ONLINE
                        MyPortStateControl(idxState).nCurrStep = i

                        'Change Abnormal S1F65 
                        If i = 9 Then 'ONL_EQSTATUS_OFFLINE 
                            MyPortStateControl(idxState).nCurrStep = 13
                        End If

                        Exit For
                    End If
                Next i
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MatchSnFm", ex.ToString)
        End Try
    End Function

    Private Function CalcCSTWIP() As Integer
        Try
            Dim i As Integer
            Dim nEQGlassCount As Integer

            ' calc WIP
            ' 1. get the total WIP from the main unit
            ' 2. substract the glass from EQ -> total WIP in CST

            ' calc glasscount in EQ
            For i = 1 To g_nMaxUnits - 1
                nEQGlassCount = nEQGlassCount + MyUnitInfo(i).WIPCount
            Next i

            MyUnitInfo(g_nMaxUnits).WIPCount = MyUnitInfo(MAIN_UNIT).WIPCount - nEQGlassCount
            CalcCSTWIP = MyUnitInfo(g_nMaxUnits).WIPCount
        Catch ex As Exception
            WrigeExceptionLog("Sub CalcCSTWIP", ex.ToString)
        End Try
    End Function

    'No USE S6F65
    Private Sub HandleLotAPD(ByVal idxState As Integer)
        'Dim idxLot As Integer
        '        Dim i As Integer
        '        Dim vItemData() As prjSECS.clsItemFormat

        '        idxLot = SearchLotByPort(MyPortStateControl(idxState).nPortNo)


        '
        '    MyEquip.ReportLotAPD MyUnitInfo(0).ToolID, MyLotInfo(idxLot).RecipeName, m_vItemS6F69
        '
        '        MySECS.RST_LotDataConfirm()
        '        If UBound(m_vItemS6F69) > 0 Then
        '            For i = 1 To UBound(m_vItemS6F69)
        '                m_vItemS6F69(i) = Nothing
        '            Next i
        '        End If
    End Sub

    'No USE S6F66
    Private Sub HandleWorkAPD(ByVal idxState As Integer)
        'Dim idxLot As Integer
        '        Dim nPortPos As Integer
        '        Dim nUnitNo As Integer
        '        Dim nSlotNo As Integer
        '        Dim strPhysicalRecipe As String
        '        Dim fAbort As Boolean
        '        Dim i As Integer
        '        Dim vItemData() As prjSECS.clsItemFormat
        '        Dim SlotInfo As New prjSECS.clsSlotStructure

        '        idxLot = SearchLotByPort(MyPortStateControl(idxState).nPortNo)

        '        GetReportWorkAPD(nPortPos, SlotInfo, nUnitNo, strPhysicalRecipe, vItemData, fAbort)


        '
        '    MyEquip.ReportWorkAPD MyUnitInfo(nUnitNo).ToolID, fAbort, MyLotInfo(idxLot), SlotInfo, strPhysicalRecipe, vItemData
        '

        '        If UBound(vItemData) > 0 Then
        '            For i = 1 To UBound(vItemData)
        '                vItemData(i) = Nothing
        '            Next i
        '        End If
        '        SlotInfo = Nothing
    End Sub

    Private Sub HandleGlassRun(ByVal idxState As Integer)
        Try
            'GetReportGlassRun(MyEQGlassReport1, MyEQGlassReport2)
            MySECS.RST_ReportGlassRun(MyGlassProcessInfo)
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleGlassRun", ex.ToString)
        End Try
    End Sub

    Private Sub HandleLotStatus(ByVal nPortPos As Integer)
        Try
            Dim i As Integer
            Dim nTotalSlots As Integer
            Dim idxPort As Integer
            Dim idxLot As Integer
            Dim aSlotInfo() As prjSECS.clsSlotStructure
            Dim nCnt As Integer = 1
            Dim nCSTStatus As eCassetteStatus

            idxPort = GetPortIndex(nPortPos)
            idxLot = SearchLotByPort(nPortPos)

            ' find out how many slots in the cassette
            For i = 1 To MAX_SLOTS
                If MyLotInfo(idxLot).Slots(i).SlotNo <> 0 Then
                    nTotalSlots = nTotalSlots + 1
                End If
            Next i

            If nTotalSlots > 0 Then
                ReDim aSlotInfo(nTotalSlots)
            Else
                ReDim aSlotInfo(0) ' no slots to report
            End If

            'nCnt = 1
            For i = 1 To MAX_SLOTS
                If MyLotInfo(idxLot).Slots(i).SlotNo <> 0 Then
                    aSlotInfo(nCnt) = New prjSECS.clsSlotStructure
                    UpdateSlotInfo(aSlotInfo(nCnt), MyLotInfo(idxLot).Slots(i))
                    nCnt = nCnt + 1
                End If
            Next i

            nCSTStatus = GetReportLotStatus(nPortPos)
            If MyPortInfo(idxPort).CPPID <> "" Then
                WriteLogInfo(eLogType.TYPE_SYS, "MyLotInfo=>" & MyLotInfo(idxLot).RecipeName & ",idxLot=" & idxLot & ",MyPortInfo=>" & MyPortInfo(idxPort).CPPID & ",idxPort=" & idxPort)
                MyLotInfo(idxLot).RecipeName = MyPortInfo(idxPort).CPPID
            End If

            MySecxX.RST_ReportCSTStatus(MyPortInfo(idxPort).PortMode, MyLotInfo(idxLot), aSlotInfo, MyPortInfo(idxPort).PortCategory, nCSTStatus)
            For i = 1 To nTotalSlots
                aSlotInfo(i) = Nothing
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleLotStatus", ex.ToString)
        End Try
    End Sub

    Private Sub HandleCSTProcessEnd(ByVal nPortPos As Integer)
        Try
            Dim i As Integer
            Dim nTotalSlots As Integer
            Dim idxPort As Integer
            Dim idxLot As Integer
            Dim aSlotInfo() As prjSECS.clsSlotStructure
            Dim nCnt As Integer = 1
            Dim nCSTStatus As eCassetteStatus

            idxPort = GetPortIndex(nPortPos)
            idxLot = SearchLotByPort(nPortPos)

            ' find out how many slots in the cassette
            For i = 1 To MAX_SLOTS
                If MyLotInfo(idxLot).Slots(i).SlotNo <> 0 Then
                    nTotalSlots = nTotalSlots + 1
                End If
            Next i

            If nTotalSlots > 0 Then
                ReDim aSlotInfo(nTotalSlots)
            Else
                ReDim aSlotInfo(0) ' no slots to report
            End If

            'nCnt = 1
            For i = 1 To MAX_SLOTS
                If MyLotInfo(idxLot).Slots(i).SlotNo <> 0 Then
                    aSlotInfo(nCnt) = New prjSECS.clsSlotStructure
                    IsGlassProcessed(aSlotInfo(nCnt), MyLotInfo(idxLot).Slots(i), MyProcessEndInfo(idxLot).Slots(i))
                    nCnt = nCnt + 1
                End If
            Next i

            nCSTStatus = GetReportLotStatus(nPortPos)

            If MyLotInfo(idxLot).ProcessEndCode = eProcessENDCode.EMPT_EMPTY Then
                MySecxX.RST_CSTProcessEndReport(MyPortInfo(idxPort).PortMode, MyLotInfo(idxLot), aSlotInfo, MyPortInfo(idxPort).PortCategory, nCSTStatus, True)
                For i = 1 To nTotalSlots
                    aSlotInfo(i) = Nothing
                Next i
            Else

                MySecxX.RST_CSTProcessEndReport(MyPortInfo(idxPort).PortMode, MyLotInfo(idxLot), aSlotInfo, MyPortInfo(idxPort).PortCategory, nCSTStatus, False)
                For i = 1 To nTotalSlots
                    aSlotInfo(i) = Nothing
                Next i
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleLotStatus", ex.ToString)
        End Try
    End Sub

    Private Sub HandleUnitStatus()
        Try
            Dim i As Integer
            Dim nUnitNo As Integer
            Dim vAlarm As clsMyAlarmStructure
            Dim fWarningExist As Boolean
            Dim fAlarmExist As Boolean

            GetReportUnitNo(nUnitNo)
            ' copy remote status from main unit
            MyUnitInfo(nUnitNo).RemoteStatus = MyUnitInfo(MAIN_UNIT).RemoteStatus


            ' determine SubStatus = "W" or blank
            ' check whether alarm is occurred if yes set SubStatus to blank
            ' restore back to "W" if warning exist
            For i = 1 To mAlarmOut.Count
                vAlarm = mAlarmOut.Item(i)
                If vAlarm.MyUnitNo = nUnitNo Then
                    If vAlarm.MyAlarmStructrue.AlarmType = eAlarmType.TYPE_ALARM Then
                        fAlarmExist = True
                        MyUnitInfo(nUnitNo).EQSubStatus = eEQSubStatus.SUBSTATUS_NO
                        Exit For
                    Else
                        ' warning exist
                        fWarningExist = True
                    End If
                End If
            Next i

            If fWarningExist Then
                If fAlarmExist Then
                    MyUnitInfo(nUnitNo).EQSubStatus = eEQSubStatus.SUBSTATUS_NO
                Else
                    MyUnitInfo(nUnitNo).EQSubStatus = eEQSubStatus.SUBSTATUS_WARNING
                End If
            Else
                MyUnitInfo(nUnitNo).EQSubStatus = eEQSubStatus.SUBSTATUS_NO
            End If

            MySecxX.RST_ReportMachineStatus(MyUnitInfo(nUnitNo))
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleUnitStatus", ex.ToString)
        End Try
    End Sub

    Private Sub HandleRecipeChanged()
        Try
            Dim strToolID As String = ""
            Dim strPPID As String = ""
            Dim strDateTime As String = ""
            Dim fFound As Boolean

            fFound = GetReportRecipeChange(strToolID, strPPID, strDateTime)

            If fFound Then
                MySecxX.RST_ReportRecipeChanged(strToolID, strPPID, strDateTime)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleRecipeChanged", ex.ToString)
        End Try

    End Sub

    Private Sub HandleRecipeParameterReport()
        Try
            MySecxX.RST_RecipeParameterQueryReply(MyRecipeParameterReport)
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleRecipeParematerReport", ex.ToString)
        End Try
    End Sub

    Private Sub HandleRecipeLastModifyInfoReport()
        Dim nAck As Integer
        Dim strPPID As String = ""
        Dim strDate As String = ""
        Dim vGet As Object

        If g_colRecipeLastModifyInfo.Count > 0 Then
            vGet = Split(g_colRecipeLastModifyInfo.Item(1), ",")
            g_colRecipeLastModifyInfo.Remove(1)
            strPPID = vGet(0)
            nAck = vGet(1)
            strDate = vGet(2)

        End If

        MySecxX.RST_RecipeLastModifyDateTimeReport(nAck, strPPID, strDate)
    End Sub

    Private Sub HandleOffline()
        Try
            Dim i As Integer

            g_fOfflineReq = False '03/07/2011
            g_fOfflineReqPending = False
            MyPortStateControl(1).fWait2NdMSG = False    ' 08/24/2004 turn off for next online

            g_nCurrOnlineMode = eRemoteStatus.MODE_OFFLINE
            For i = 0 To g_nMaxUnits
                MyUnitInfo(i).RemoteStatus = g_nCurrOnlineMode
            Next i

            RaiseEvent OffLineComplete(0)

            ' clean up
            Call ClearAllQueue()
            Call ReinitStateInfo()
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleOffline", ex.ToString)
        End Try
    End Sub


    ' mark the port which is running before online
    Private Sub CheckCSTOnPort()
        Try
            Dim i As Integer
            Dim idxState As Integer

            For i = 1 To g_nMaxPorts
                If MyPortInfo(i).PortStatus = ePortStatus.TSIP_PROCESSING Then
                    idxState = GetStateIndex(i)
                    MyPortStateControl(idxState).fCSTRunningOnLine = True
                End If
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub HandleOffline", ex.ToString)
        End Try
    End Sub

    Private Function ActionRoutine(ByVal idxState As Integer, ByVal nStep As Integer) As Integer
        Try
            Dim idxLot As Integer
            Dim strTrace As String = ""
            Dim vXAlarmInfo As clsMyAlarmStructure
            Static IsIniRSTReport As Boolean = False

            If MyPortStateControl(idxState).idxTable = TABLE_OFFLINE Then
                strTrace = vbTab & "Port: " & CStr(MyPortStateControl(idxState).nPortNo) & " Table: " & CStr(MyPortStateControl(idxState).idxTable) & " Step: " & CStr(nStep) & " = " & OffLineDesc(nStep)
            ElseIf MyPortStateControl(idxState).idxTable = TABLE_ONLINE Then
                strTrace = vbTab & "Port: " & CStr(MyPortStateControl(idxState).nPortNo) & " Table: " & CStr(MyPortStateControl(idxState).idxTable) & " Step: " & CStr(nStep) & " = " & OnLineDesc(nStep)
            End If
            WriteLogInfo(eLogType.TYPE_SYS, strTrace)

            ActionRoutine = ACTION_DONE

            Select Case MyPortStateControl(idxState).idxTable
                Case TABLE_OFFLINE
                    Select Case nStep
                        Case eOfflineStep.OFL_AYT  ' S1F1
                            MySecxX.RST_Connect()

                            WriteLogInfo(eLogType.TYPE_SYS, "S1F1: Set timer")
                            TimerAdd(idxState, eTimerType.TIMER_ONLINE, m_ConversationTimeout)

                        Case eOfflineStep.OFL_REQDATE
                            MySecxX.RST_RequestDateTime()
                        Case eOfflineStep.OFL_ONLINESUMMARY
                            MySecxX.RST_ReportWholeStatus(eRiportType.TYPE_S1F89, MyUnitInfo)

                            ' change to designated online mode
                            MyUnitInfo(MAIN_UNIT).RemoteStatus = g_nChangedMode
                        Case eOfflineStep.OFL_RSTREPORT
                            Call HandleUnitStatus()
                        Case eOfflineStep.OFL_PORTSTATE  ' S1F73 port disabled
                            MySecxX.RST_LoadStatus(eLDSTA.CST_PORT_DISABLE, MyPortInfo(idxState).PortMode, Space(LEN_CASID), MyPortInfo(idxState).PortPosition, MyPortInfo(idxState).AGVMode, MyPortInfo(idxState).PortCategory)
                    End Select

                    MyPortStateControl(idxState).fWait2NdMSG = MyOffLineTable(nStep).Reply
                    '============================================================ON LINE TABLE================================================

                Case TABLE_ONLINE
                    Select Case nStep
                        Case eOnLineStep.ONL_LOADREQ, eOnLineStep.ONL_ANYTIME_LOADREQ    ' S1F73, CST load request
                            MyPortInfo(MyPortInfo(idxState).PortPosition).PortStatus = ePortStatus.TSIP_LOADREQ
                            'RaiseEvent LoadRequestStart(MyPortInfo(idxState).PortPosition)

                            MySecxX.RST_LoadStatus(eLDSTA.CST_LOAD_REQ, MyPortInfo(idxState).PortMode, Space(LEN_CASID), MyPortInfo(idxState).PortPosition, MyPortInfo(idxState).AGVMode, MyPortInfo(idxState).PortCategory)

                        Case eOnLineStep.ONL_LOADCOMPLETE, eOnLineStep.ONL_ANYTIME_LOADCOMPLETE   ' S1F73 CST load complete
                            'create lot info
                            idxLot = SearchLotByPort(MyPortStateControl(idxState).nPortNo)
                            If idxLot <= 0 Then
                                AddLot(MyPortStateControl(idxState).nPortNo)
                            End If

                            MyPortInfo(MyPortStateControl(idxState).nPortNo).PortStatus = ePortStatus.TSIP_CST_PRESENT

                            MySecxX.RST_LoadStatus(eLDSTA.CST_LOAD_COMP, MyPortInfo(idxState).PortMode, MyPortInfo(idxState).CassetteID, MyPortInfo(idxState).PortPosition, MyPortInfo(idxState).AGVMode, MyPortInfo(idxState).PortCategory)


                        Case eOnLineStep.ONL_REQLOTDATA    ' S7F71, cassette data request
                            idxLot = SearchLotByPort(MyPortStateControl(idxState).nPortNo)

                            MySecxX.RST_LotDataRequest(MyPortInfo(idxState).PortPosition, MyPortInfo(idxState).CassetteID, GetOperatorID(MyPortStateControl(idxState).nPortNo), MyPortInfo(idxState).PortMode, MyPortInfo(idxState).PortCategory)
                        Case eOnLineStep.ONL_LOTDATA    ' S7F65 cassette data downloaded
                            g_fRemotePause(idxState) = False
                            g_fRemoteResume(idxState) = False

                            MySecxX.RST_LotDataConfirm(MyPortStateControl(idxState).nAckC7)
                        Case eOnLineStep.ONL_REMOTECMD, eOnLineStep.ONL_REMOTECANCEL_X   ' S2F21 remote command
                            MySecxX.RST_ReplyRemoteCommand(MyPortStateControl(idxState).nCMDA)

                        Case eOnLineStep.ONL_ANYTIME_GLASSRUN
                            HandleGlassRun(idxState)

                        Case eOnLineStep.ONL_ANYTIME_WORKAPD
                            HandleWorkAPD(idxState)

                        Case eOnLineStep.ONL_ANYTIME_LOTAPD
                            HandleLotAPD(idxState)
                        Case eOnLineStep.ONL_ANYTIME_REQLOTDATA

                        Case eOnLineStep.ONL_UNLOADREQ
                            MyPortInfo(MyPortInfo(idxState).PortPosition).PortStatus = ePortStatus.TSIP_END_WITHUNLOAD
                            'RaiseEvent UnloadRequestStart(MyPortInfo(idxState).PortPosition)
                            g_afCassetteUnloadReq(MyPortStateControl(idxState).nPortNo) = False
                            MySecxX.RST_UnloadStatus(eULDSTA.CST_UNLOAD_REQ, MyPortInfo(idxState).PortMode, MyPortInfo(idxState).CassetteID, MyPortInfo(idxState).PortPosition, MyPortInfo(idxState).AGVMode, MyPortInfo(idxState).PortCategory)

                        Case eOnLineStep.ONL_UNLOADCOMPLETE
                            g_afCassetteRemoveReq(MyPortStateControl(idxState).nPortNo) = False

                            MySecxX.RST_UnloadStatus(eULDSTA.CST_UNLOAD_COMP, MyPortInfo(idxState).PortMode, MyPortInfo(idxState).CassetteID, MyPortInfo(idxState).PortPosition, MyPortInfo(idxState).AGVMode, MyPortInfo(idxState).PortCategory)

                        Case eOnLineStep.ONL_ANYTIME_EQSTATUS, eOnLineStep.ONL_EQSTATUS_OFFLINE, eOnLineStep.ONL_ANYTIME_ONLINEMODECHANGE
                            MySecxX.RST_ReportMachineStatus(MyUnitInfo(MAIN_RST))

                        Case eOnLineStep.ONL_ANYTIME_UNITSTATUS
                            Call HandleUnitStatus()

                        Case eOnLineStep.ONL_ANYTIME_LOTSTATUS
                            Call HandleLotStatus(MyPortStateControl(idxState).nPortNo)
                        Case eOnLineStep.ONL_ANYTIME_CSTPROCESSEND
                            Call HandleCSTProcessEnd(MyPortStateControl(idxState).nPortNo)
                        Case eOnLineStep.ONL_ANYTIME_RECIPEMODIFIED
                            Call HandleRecipeChanged()
                        Case eOnLineStep.ONL_ANYTIME_RECIPE_LAST_MODIFY_REPORT
                            Call HandleRecipeLastModifyInfoReport()
                        Case eOnLineStep.ONL_ANYTIME_RECIPE_PARAMETER_REPORT
                            Call HandleRecipeParameterReport()
                        Case eOnLineStep.ONL_ANYTIME_WORKIDUNMATCH
                            MySecxX.RST_ReportGxIDUnmatch(MyUnitInfo(m_nUnitNoWorkID).ToolID, m_strGlassIDHost, m_strGlassIDVCR)

                        Case eOnLineStep.ONL_ANYTIME_ALARM
                            If mAlarmIn.Count > 0 Then
                                vXAlarmInfo = mAlarmIn.Item(1)

                                MySecxX.RST_ReportAlarm(MyUnitInfo(vXAlarmInfo.MyUnitNo), vXAlarmInfo.MyAlarmStructrue, vXAlarmInfo.GlassAffect, vXAlarmInfo.WithGx, vXAlarmInfo.DateTimeInfo)

                                If vXAlarmInfo.MyAlarmStructrue.AlarmFlag = eAlarmFlag.TYPE_RELEASE Then
                                    MyUnitInfo(vXAlarmInfo.MyUnitNo).Alarm.AlarmID = 0
                                    RemoveOutAlarm(vXAlarmInfo)
                                Else
                                    ' copy to "out" collection
                                    CopyToOutAlarm(vXAlarmInfo)
                                End If

                                ' clear In
                                vXAlarmInfo.MyAlarmStructrue = Nothing
                                vXAlarmInfo = Nothing
                                mAlarmIn.Remove(1)
                            End If

                        Case eOnLineStep.ONL_ANYTIME_OFFLINEALARM
                            If mAlarmOfflineCol.Count > 0 Then
                                vXAlarmInfo = mAlarmOfflineCol.Item(1)

                                MySecxX.RST_ReportAlarm(MyUnitInfo(vXAlarmInfo.MyUnitNo), vXAlarmInfo.MyAlarmStructrue, vXAlarmInfo.GlassAffect, vXAlarmInfo.WithGx, vXAlarmInfo.DateTimeInfo)

                                If vXAlarmInfo.MyAlarmStructrue.AlarmFlag = eAlarmFlag.TYPE_RELEASE Then
                                    MyUnitInfo(vXAlarmInfo.MyUnitNo).Alarm.AlarmID = 0
                                End If
                                mAlarmOfflineCol.Remove(1)
                                vXAlarmInfo = Nothing
                            End If

                        Case eOnLineStep.ONL_ANYTIME_GLASSERASE
                            MySecxX.RST_GlassErase(m_strToolID, m_strGlassIDErase)

                        Case eOnLineStep.ONL_ANYTIME_PORTSTATE  ' S1F73 port disabled
                            MySecxX.RST_LoadStatus(eLDSTA.CST_PORT_DISABLE, MyPortInfo(idxState).PortMode, Space(LEN_CASID), MyPortInfo(idxState).PortPosition, MyPortInfo(idxState).AGVMode, MyPortInfo(idxState).PortCategory)

                        Case eOnLineStep.ONL_QUERY_FORMATTED_STATUS
                            MySecxX.RST_ReportWholeStatus(eRiportType.TYPE_S1F5_SFCD8, MyUnitInfo)

                        Case eOnLineStep.ONL_CONVERSATION_TIMEOUT
                            MySecxX.RST_ReportConversationTimeout(g_nCTStream, g_nCTFunction)
                    End Select

                    MyPortStateControl(idxState).fWait2NdMSG = MyOnLineTable(nStep).Reply
            End Select

            If ActionRoutine = ACTION_SKIP Then Exit Function

            If MyPortStateControl(idxState).fWait2NdMSG Then
                g_colReplyStateCtl.Add(idxState)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub ActionRoutine", ex.ToString)
        End Try
    End Function

    'Private Function RspHandler(ByVal idxState As Integer, ByVal nStep As Integer) As Integer
    '    Try
    '        Dim idxLot As Integer
    '        Dim i As Integer
    '        Dim objIniSetting = New IniConfigSource(Me.IniFileFullName)
    '        Dim ConfigInfo As IConfig
    '        Dim nRecipeReport As Integer

    '        Select Case MyPortStateControl(idxState).idxTable
    '            Case TABLE_OFFLINE
    '                ' default to pre-set value
    '                RspHandler = MyOffLineTable(nStep).NextStep

    '                Select Case nStep
    '                    Case eOfflineStep.OFL_AYT
    '                        WriteLogInfo(eLogType.TYPE_SYS, "S1F1: Delete timer")
    '                        TimerDelete(idxState, eTimerType.TIMER_ONLINE)

    '                    Case eOfflineStep.OFL_REQDATE
    '                        '            RaiseEvent ReqSummaryStatus(REQ_S1F89)
    '                    Case eOfflineStep.OFL_ONLINESUMMARY

    '                    Case eOfflineStep.OFL_RSTREPORT
    '                        Call CheckCSTOnPort()
    '                        If MyPortInfo(MyPortInfo(idxState).PortPosition).PortStatus <> ePortStatus.TSIP_DISABLE Then
    '                            RspHandler = 2  ' jump to online without report port 1 disabled
    '                        End If

    '                        If mAlarmOfflineCol.Count > 0 Then
    '                            MyReportAlarm.Enabled = True
    '                        End If

    '                        ConfigInfo = objIniSetting.Configs(RECIPE_SECTION)
    '                        nRecipeReport = ConfigInfo.Get(RECIPE_EXIST)

    '                        If nRecipeReport = 1 Then
    '                            MyReportRecipe.Enabled = True
    '                        End If

    '                        ConfigInfo = objIniSetting.Configs(STR_SYSTEMSEC)

    '                        m_S1F1CountDown = ConfigInfo.Get(STR_S1F1INTERNAL)
    '                        m_S2F17CountDown = ConfigInfo.Get(STR_S2F17INTERNAL)
    '                End Select

    '            Case TABLE_ONLINE
    '                ' default to pre-set value
    '                RspHandler = MyOnLineTable(nStep).NextStep

    '                Select Case nStep
    '                    Case eOnLineStep.ONL_LOADREQ

    '                    Case eOnLineStep.ONL_LOADCOMPLETE
    '                        RaiseEvent S1F74LoadCompleted(MyPortInfo(idxState).PortPosition)
    '                    Case eOnLineStep.ONL_ANYTIME_LOADCOMPLETE
    '                        If g_afCSTVLoad(idxState) = True Then

    '                            WriteLogInfo(eLogType.TYPE_SYS, "S7F71[V]: Set timer")
    '                            TimerAdd(idxState, eTimerType.TIMER_SENDS7F71, 2)

    '                        End If
    '                    Case eOnLineStep.ONL_REQLOTDATA
    '                        If MyPortStateControl(idxState).nGrantCode <> 0 Then
    '                            RspHandler = -eOnLineStep.ONL_UNLOADREQ
    '                        Else
    '                            WriteLogInfo(eLogType.TYPE_SYS, "S7F71: Set timer")
    '                            TimerAdd(idxState, eTimerType.TIMER_WAITS7F65, m_ConversationTimeout)
    '                        End If

    '                    Case eOnLineStep.ONL_LOTDATA
    '                        If MyPortStateControl(idxState).nAckC7 <> 0 Then
    '                            RspHandler = -eOnLineStep.ONL_UNLOADREQ
    '                        Else
    '                            WriteLogInfo(eLogType.TYPE_SYS, "S7F65: Set timer")
    '                            TimerAdd(idxState, eTimerType.TIMER_WAITS2F21, m_ConversationTimeout)
    '                        End If

    '                    Case eOnLineStep.ONL_REMOTECMD
    '                        'If MyPortStateControl(idxState).strRemoteCommand <> CMD_START Then
    '                        If MyPortStateControl(idxState).strRemoteCommand = CMD_CANCEL Then
    '                            RspHandler = -eOnLineStep.ONL_UNLOADREQ
    '                        End If
    '                    Case eOnLineStep.ONL_UNLOADREQ
    '                        RspHandler = -eOnLineStep.ONL_UNLOADREQ
    '                    Case eOnLineStep.ONL_UNLOADCOMPLETE
    '                        RaiseEvent S1F76UnloadCompleted(MyPortInfo(idxState).PortPosition)
    '                        PortRemove(MyPortStateControl(idxState).nPortNo)

    '                    Case eOnLineStep.ONL_EQSTATUS_OFFLINE
    '                        Call HandleOffline()

    '                    Case eOnLineStep.ONL_ANYTIME_UNITSTATUS
    '                        RaiseEvent S1F66UnitStatusReply(MyPortStateControl(idxState).nGrantCode)

    '                    Case eOnLineStep.ONL_ANYTIME_EQSTATUS
    '                        RaiseEvent EQStatusReply(MyPortStateControl(idxState).nGrantCode)

    '                        ' check whether need to do unload request
    '                        '            If MyUnitInfo(MAIN_UNIT).Status = MCSTA_IDLE And MyPortStateControl(idxState).fProcessEnd Then
    '                        '                MyPortStateControl(idxState).fProcessEnd = False
    '                        '                RspHandler = -ONL_UNLOADREQ
    '                        '            End If

    '                    Case eOnLineStep.ONL_ANYTIME_ONLINEMODECHANGE
    '                        If g_nCurrOnlineMode <> g_nChangedMode Then
    '                            g_nCurrOnlineMode = g_nChangedMode
    '                        End If
    '                        'all the unit should change remote status too
    '                        For i = 0 To g_nMaxUnits
    '                            MyUnitInfo(i).RemoteStatus = g_nCurrOnlineMode
    '                        Next i

    '                        RaiseEvent S1F90OnLineComplete(g_nCurrOnlineMode)

    '                    Case eOnLineStep.ONL_ANYTIME_LOTSTATUS
    '                        ' check process end code to determine the next step
    '                        idxLot = SearchLotByPort(MyPortStateControl(idxState).nPortNo)
    '                        '            If MyLotInfo(idxLot).ProcEndCode = PEC_CANCEL And MyPortStateControl(idxState).fProcessEnd Then
    '                        '                RspHandler = -ONL_UNLOADREQ
    '                        '            End If
    '                        If MyLotInfo(idxLot).ProcessEndCode <> 0 And MyPortStateControl(idxState).fProcessEnd Then
    '                            RspHandler = -eOnLineStep.ONL_UNLOADREQ
    '                        End If

    '                        '        Case ONL_EQSTATUS_DOWN, ONL_EQSTATUS_PREVIOUS
    '                        '            RaiseEvent EQStatusReply(MyPortStateControl(idxState).nGrantCode)
    '                        '
    '                        '        Case ONL_EQSTATUS_PREVIOUS
    '                        '            ' return to previous state after all settle down
    '                        '            MyPortStateControl(idxState).idxTable = MyPortStateControl(idxState).idxPrevTable
    '                        '            MyPortStateControl(idxState).nCurrStep = MyPortStateControl(idxState).nPrevStep
    '                        '            MyPortStateControl(idxState).idxPrevTable = 0
    '                        '            MyPortStateControl(idxState).nPrevStep = 0
    '                        '            RaiseEvent EQStatusReply(MyPortStateControl(idxState).nGrantCode)

    '                    Case eOnLineStep.ONL_CONVERSATION_TIMEOUT
    '                        RaiseEvent S9F13ConversationTimeoutOccur(MyPortStateControl(idxState).nPortNo, g_nCTStream, g_nCTFunction)
    '                    Case eOnLineStep.ONL_ANYTIME_OFFLINEALARM
    '                        If mAlarmOfflineCol.Count > 0 Then
    '                            MyReportAlarm.Enabled = True
    '                        End If
    '                End Select
    '        End Select

    '        objIniSetting = Nothing
    '    Catch ex As Exception
    '        WrigeExceptionLog("Sub RspHandler", ex.ToString)
    '    End Try


    'End Function

    Private Function GetNotSuspendedPort() As Integer
        Try
            Dim i As Integer

            For i = 1 To g_nMaxPorts
                If Not MyPortStateControl(i).fSuspend Then
                    GetNotSuspendedPort = i
                    Exit Function
                End If
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub GetNotSuspendedPort", ex.ToString)
        End Try
    End Function

    'Private Sub ExecInsertSequence(ByVal idxState As Integer, ByVal nTable As Integer, ByVal nSequence As Integer)
    '    Try
    '        WriteLogInfo(eLogType.TYPE_SYS, vbTab & "Sequence inserted is executing")

    '        ' remember new state's current status
    '        MyPortStateControl(idxState).idxPrevTable = MyPortStateControl(idxState).idxTable
    '        MyPortStateControl(idxState).nPrevStep = MyPortStateControl(idxState).nCurrStep

    '        ' start new state
    '        MyPortStateControl(idxState).idxTable = nTable
    '        MyPortStateControl(idxState).nCurrStep = nSequence

    '        Select Case nTable
    '            Case TABLE_ONLINE
    '                EventTrigger(idxState, MyOnLineTable(nSequence).StreamID, MyOnLineTable(nSequence).FunctionID)
    '        End Select
    '    Catch ex As Exception
    '        WrigeExceptionLog("Sub ExecInsertSequence", ex.ToString)
    '    End Try
    'End Sub

    Private Sub ReinitStateInfo()
        Try
            Dim i As Integer

            For i = 1 To UBound(MyPortInfo)
                ' init control state
                ' for the first port, set the starting table at OFFLINE table
                ' otherwsie set to ONLINE table and suspend the execution
                MyPortStateControl(i).nCurrStep = 1
                If i = 1 Then
                    MyPortStateControl(i).idxTable = TABLE_OFFLINE

                    ' to prevent switch back to previous step
                    ' (it will block online next time)
                    ' since offline could be issued anytime
                    MyPortStateControl(i).idxPrevTable = 0
                    MyPortStateControl(i).nPrevStep = 0
                Else
                    MyPortStateControl(i).idxTable = TABLE_ONLINE
                    MyPortStateControl(i).fSuspend = True
                End If
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub ReinitStateInfo", ex.ToString)
        End Try
    End Sub

    Private Sub UpdatePortInfo(ByVal idx As Integer, ByRef PortInfo As prjSECS.clsPortStructure)
        Try
            MyPortInfo(idx).PortPosition = PortInfo.PortPosition
            MyPortInfo(idx).PortType = PortInfo.PortType
            MyPortInfo(idx).CassetteID = PortInfo.CassetteID
            MyPortInfo(idx).WithCassette = PortInfo.WithCassette
            MyPortInfo(idx).PortCategory = PortInfo.PortCategory
            MyPortInfo(idx).AGVMode = PortInfo.AGVMode
            MyPortInfo(idx).CPPID = PortInfo.CPPID

            ' check whether portstatus changed between DISABLED & EMPTY
            If PortInfo.PortStatus = ePortStatus.TSIP_DISABLE And (MyPortInfo(idx).PortStatus = ePortStatus.TSIP_EMPTY Or MyPortInfo(idx).PortStatus = ePortStatus.TSIP_LOADREQ) Then
                ' port is disabled
                If IsOnLineMode() Then
                    WriteLogInfo(eLogType.TYPE_SYS, "Update Port Info Step:1")
                    MyPortInfo(idx).PortStatus = PortInfo.PortStatus
                    SnFnAdd(idx, 1, 73, 1, eLDSTA.CST_PORT_DISABLE)
                    Exit Sub
                End If
            End If

            If PortInfo.PortStatus = ePortStatus.TSIP_EMPTY Then

                ' port is enabled
                If IsOnLineMode() Then
                    WriteLogInfo(eLogType.TYPE_SYS, "Update Port Info Step:2")
                    MyPortInfo(idx).PortStatus = PortInfo.PortStatus

                    SnFnAdd(idx, 1, 73, 1, eLDSTA.CST_LOAD_REQ)
                    Exit Sub
                End If
            End If

            If PortInfo.PortMode <> MyPortInfo(idx).PortMode Then
                MyPortInfo(idx).PortMode = PortInfo.PortMode
                If (MyPortInfo(idx).PortStatus = ePortStatus.TSIP_LOADREQ Or PortInfo.PortStatus = ePortStatus.TSIP_EMPTY) Or (MyPortInfo(idx).PortStatus = ePortStatus.TSIP_EMPTY Or MyPortInfo(idx).PortStatus = ePortStatus.TSIP_LOADREQ) Then
                    ' port is enabled
                    If IsOnLineMode() Then
                        WriteLogInfo(eLogType.TYPE_SYS, "Update Port Info Step:3")
                        MyPortInfo(idx).PortStatus = PortInfo.PortStatus

                        SnFnAdd(idx, 1, 73, 1, eLDSTA.CST_LOAD_REQ)
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub UpdatePortInfo", ex.ToString)
        End Try
    End Sub

    Private Sub UpdateUnitInfo(ByVal idx As Integer, ByRef UnitInfo As prjSECS.clsUnitStructure)
        Try
            Dim a As String = ""
            MyUnitInfo(idx).UnitNo = UnitInfo.UnitNo
            MyUnitInfo(idx).ToolID = UnitInfo.ToolID
            'If UnitInfo.RemoteStatus = eRemoteStatus.MODE_OFFLINE Then
            '    a = ""
            'End If
            MyUnitInfo(idx).RemoteStatus = MySecxX.CCIMOnLineMode
            MyUnitInfo(idx).EQStatus = UnitInfo.EQStatus
            MyUnitInfo(idx).EQSubStatus = UnitInfo.EQSubStatus
            MyUnitInfo(idx).ProcessMode = UnitInfo.ProcessMode
            MyUnitInfo(idx).CPPID = UnitInfo.CPPID
            MyUnitInfo(idx).WIPCount = UnitInfo.WIPCount
            MyUnitInfo(idx).Alarm.AlarmType = UnitInfo.Alarm.AlarmType
            MyUnitInfo(idx).Alarm.AlarmFlag = UnitInfo.Alarm.AlarmFlag
            MyUnitInfo(idx).Alarm.AlarmID = UnitInfo.Alarm.AlarmID
            MyUnitInfo(idx).Alarm.AlarmText = UnitInfo.Alarm.AlarmText
            If idx = 1 Then
                MyUnitInfo(0).ToolID = UnitInfo.ToolID
                'If UnitInfo.RemoteStatus = eRemoteStatus.MODE_OFFLINE Then
                '    a = ""
                'End If
                MyUnitInfo(0).RemoteStatus = MySecxX.CCIMOnLineMode
                MyUnitInfo(0).EQStatus = UnitInfo.EQStatus
                MyUnitInfo(0).EQSubStatus = UnitInfo.EQSubStatus
                MyUnitInfo(0).ProcessMode = UnitInfo.ProcessMode
                MyUnitInfo(0).CPPID = UnitInfo.CPPID
                MyUnitInfo(0).WIPCount = UnitInfo.WIPCount
                MyUnitInfo(0).Alarm.AlarmType = UnitInfo.Alarm.AlarmType
                MyUnitInfo(0).Alarm.AlarmFlag = UnitInfo.Alarm.AlarmFlag
                MyUnitInfo(0).Alarm.AlarmID = UnitInfo.Alarm.AlarmID
                MyUnitInfo(0).Alarm.AlarmText = UnitInfo.Alarm.AlarmText
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub UpdateUnitInfo", ex.ToString)
        End Try
    End Sub

    Private Function IsLotRunningBeforeOnLine(ByVal nPortNo As Integer) As Boolean
        Try
            Dim idxState As Integer

            idxState = GetStateIndex(nPortNo)

            If idxState > 0 Then
                IsLotRunningBeforeOnLine = MyPortStateControl(idxState).fCSTRunningOnLine
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub IsLotRunningBeforeOnLine", ex.ToString)
        End Try
    End Function

    Private Sub RemoveOutAlarm(ByRef vXAlarmInfo As clsMyAlarmStructure)
        Try
            Dim i As Integer
            Dim vXAlarm As clsMyAlarmStructure

            For i = 1 To mAlarmOut.Count
                vXAlarm = mAlarmOut.Item(i)

                If vXAlarm.MyUnitNo = vXAlarmInfo.MyUnitNo And vXAlarm.MyAlarmStructrue.AlarmType = vXAlarmInfo.MyAlarmStructrue.AlarmType And vXAlarm.MyAlarmStructrue.AlarmID = vXAlarmInfo.MyAlarmStructrue.AlarmID Then
                    mAlarmOut.Remove(i)
                    vXAlarm.MyAlarmStructrue = Nothing
                    vXAlarm = Nothing
                    Exit For
                End If
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub RemoveOutAlarm", ex.ToString)
        End Try
    End Sub

    Private Sub CopyToOutAlarm(ByRef vXAlarmInfo As clsMyAlarmStructure)
        Try
            Dim vXAlarm As clsMyAlarmStructure

            vXAlarm = New clsMyAlarmStructure
            vXAlarm.MyAlarmStructrue = New prjSECS.clsAlarmStructure
            vXAlarm.MyUnitNo = vXAlarmInfo.MyUnitNo

            With vXAlarmInfo
                vXAlarm.MyAlarmStructrue.AlarmFlag = .MyAlarmStructrue.AlarmFlag
                vXAlarm.MyAlarmStructrue.AlarmType = .MyAlarmStructrue.AlarmType
                vXAlarm.MyAlarmStructrue.AlarmID = .MyAlarmStructrue.AlarmID
                vXAlarm.MyAlarmStructrue.AlarmText = .MyAlarmStructrue.AlarmText
            End With

            mAlarmOut.Add(vXAlarm)
        Catch ex As Exception
            WrigeExceptionLog("Sub CopyToOutAlarm", ex.ToString)
        End Try
    End Sub

    Private Sub AddRecipeToIni(ByRef strToolID As String, ByRef strTime As String, ByRef strPPID As String)
        Try
            Dim objIniSetting = New IniConfigSource(IniCIMFilePath)
            Dim ConfigInfo As IConfig

            ConfigInfo = objIniSetting.Configs(RECIPE_SECTION)

            Dim i As Integer
            Dim nKey As Integer
            Dim strRecipe As String

            Dim vGet As Object
            Dim fFound As Boolean

            For i = MAX_RECIPE To 1 Step -1
                strRecipe = ConfigInfo.Get(CStr(i))

                If strRecipe <> "" Then
                    Exit For
                End If
            Next i

            nKey = i + 1
            If nKey > MAX_RECIPE Then Exit Sub

            ' check whether recipe exist before
            For i = 1 To MAX_RECIPE
                strRecipe = ConfigInfo.Get(CStr(i))
                If strRecipe <> "" Then
                    ' 0 = ToolID, 1 = time, 2 = PPID
                    vGet = Split(strRecipe, ",")
                    If Trim(strToolID) = Trim(vGet(0)) And strPPID = Trim(vGet(2)) Then
                        fFound = True
                        Exit For
                    End If
                End If
            Next i

            If fFound Then
                nKey = i
            End If

            If nKey > MAX_RECIPE Then Exit Sub

            strRecipe = strToolID & "," & strTime & "," & strPPID
            objIniSetting.Configs(RECIPE_SECTION).Set(RECIPE_EXIST, "1")
            objIniSetting.Configs(RECIPE_SECTION).Set(CStr(nKey), strRecipe)
            objIniSetting.Save()
        Catch ex As Exception
            WrigeExceptionLog("Sub AddRecipeToIni", ex.ToString)
        End Try
    End Sub
#End Region

#Region "SEMI SECS Event"
    Private Sub SECS_ReadSetting(ByVal strIniFile As String)
        Try
            Dim objIniSetting = New IniConfigSource(IniCIMFilePath)
            Dim ConfigInfo As IConfig

            'Dim strHostIP As String
            'Dim strAGVOPID As String

            ConfigInfo = objIniSetting.Configs(STR_SYSTEMSEC)
            m_HSMST3 = ConfigInfo.Get(STR_T3)
            m_HSMST5 = ConfigInfo.Get(STR_T5)
            m_HSMST6 = ConfigInfo.Get(STR_T6)
            m_HSMST7 = ConfigInfo.Get(STR_T7)
            m_HSMST8 = ConfigInfo.Get(STR_T8)

            m_ConversationTimeout = ConfigInfo.Get(STR_CT)
            m_LinkTestTimer = ConfigInfo.Get(STR_LINKTEST)
            m_RetryLimit = ConfigInfo.Get(STR_RETRYLIMIT)
            m_ConnectionMode = ConfigInfo.Get(STR_CONNECTMODE)
            m_TCPPortLocal = ConfigInfo.Get(STR_EQPTCP)
            m_TCPPortRemote = ConfigInfo.Get(STR_HOSTTCP)
            m_DefaultDeviceID = Val(ConfigInfo.Get(STR_DEVICEID))

            '    GetPrivateProfileString STR_SYSTEMSEC, STR_EQPIP, "0.0.0.0", strEQPIP, Len(strEQPIP), strIniFile
            'm_IPAddressLocal = GetHostIPAddress

            m_IPAddressRemote = ConfigInfo.Get(STR_HOSTIP)
            m_OperatorIDAGV = ConfigInfo.Get(STR_AGVOPID)

            MySECS.HSMSDeviceID = m_DefaultDeviceID
            MySECS.HSMSHOSTIP = m_IPAddressRemote
            MySECS.HSMSHOSTTCPPort = m_TCPPortRemote
            MySECS.HSMSLinkTestTimer = m_LinkTestTimer
            MySECS.HSMSRetryTimes = m_RetryLimit
            MySECS.HSMST3 = m_HSMST3
            MySECS.HSMST5 = m_HSMST5
            MySECS.HSMST6 = m_HSMST6
            MySECS.HSMST7 = m_HSMST7
            MySECS.HSMST8 = m_HSMST8

            m_S2F17CountDown = ConfigInfo.Get(STR_S2F17INTERNAL)
            m_S1F1CountDown = ConfigInfo.Get(STR_S1F1INTERNAL)

            objIniSetting = Nothing
        Catch ex As Exception
            WrigeExceptionLog("Sub SECS_ReadSetting", ex.ToString)
        End Try
    End Sub

    'S2F41
    Private Sub MySecxX_EQRemoteCommand(ByVal strToolID As String, ByVal strCSTID As String, ByVal strCMD As String, ByVal strSaveFlag As String, ByVal strMSG As String) Handles MySecxX.EQRemoteCommand
        Try
            RaiseEvent S2F41EQRemoteCommand(strToolID, strCSTID, strCMD, strSaveFlag, strMSG)
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_EQRemoteCommand", ex.ToString)
        End Try
    End Sub

    'S1F5 
    Private Sub MySecxX_EQStatusRequest(ByVal nRequestType As prjSECS.clsSECSMain.eS1F6SFCD, ByVal strLineID As String, ByVal strToolID As String) Handles MySecxX.EQStatusRequest
        Try
            Dim i As Integer
            Dim idxTool As Integer

            If nRequestType = prjSECS.clsSECSMain.eS1F6SFCD.SFCD_EQStatusDataReport Then
                ' 01: query Tool(EQ) status
                For i = 0 To g_nMaxUnits
                    If MyUnitInfo(i).ToolID = strToolID Then
                        idxTool = i
                    End If
                Next i
                'Report EQ Status
                SnFnAdd(idxTool, 1, 6, 0, 1)
            ElseIf nRequestType = prjSECS.clsSECSMain.eS1F6SFCD.SFCD_EDSReport Then
                'Report EDS SFCD=7
                SnFnAdd(0, 1, 6, 0, 7)
            Else
                'Report S1F98 OR SFCD=8
                SnFnAdd(0, 1, 6, 0, 8)
            End If            
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_EQStatusRequest", ex.ToString)
        End Try


    End Sub

    Private Sub MySecxX_HOSTConnectStatus(ByVal fConnect As Boolean) Handles MySecxX.HOSTConnectStatus
        Try
            If fConnect Then
                WriteLogInfo(eLogType.TYPE_EVENT, " HSMS Connect")
                g_fHSMSConnected = True
                RaiseEvent HSMSConnectChanged(True)

                MyTimeout.Enabled = True
                MyDispatcher.Enabled = True
                MyHeartBeat.Enabled = True
            Else
                WriteLogInfo(eLogType.TYPE_EVENT, " HSMS Disconnect")

                If g_fOfflineReqPending Then
                    Call HandleOffline()
                End If

                Call ClearAllQueue()

                ' note: state control is running!!!
                ' the eventqueue is not cleared yet here...
                ' have to clear up eventqueue before next online
                g_fHSMSConnected = False

                RaiseEvent HSMSConnectChanged(False)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_HOSTConnectStatus", ex.ToString)
        End Try
    End Sub

    'S1F2
    Private Sub MySecxX_HOSTOnlineReply() Handles MySecxX.HOSTOnlineReply
        Try
            Dim idxState As Integer

            idxState = GetReplySnFn()
            'If idxState > 0 Then
            If g_fIsAreYouThereSend Then
                g_fIsAreYouThereSend = False
            Else
                RaiseEvent HOSTOnLineReply()
            End If
            'End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_HOSTOnlineReply", ex.ToString)
        End Try
    End Sub

    'S1F1 /Reply S1F2
    Private Sub MySecxX_HOSTOnlineReq() Handles MySecxX.HOSTOnlineReq
        Try
            If IsCompletelyOffline() Then
                MySECS.RST_TransactionAbort(1)
            Else
                RaiseEvent HOSTOnLineRequest()
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_HOSTOnlineReq", ex.ToString)
        End Try
    End Sub

    Private Sub MySecxX_HSMSMonitor(ByVal Sent As Boolean, ByVal ByteType As Long, ByVal Description As String) Handles MySecxX.HSMSMonitor

    End Sub

    'S7F67
    Private Sub MySecxX_LastRecipeModifyTime(ByVal strRecipe As String) Handles MySecxX.LastRecipeModifyTime
        RaiseEvent S7F67RecipeModifyLastTimeQuery(strRecipe)
    End Sub

    'S2F25
    Private Sub MySecxX_LoopBackReply(ByVal abyData() As Byte) Handles MySecxX.LoopBackReply
        Try
            Dim i As Integer
            Dim fOK As Boolean

            fOK = True

            ' check whether return bytes are same
            For i = 0 To MAX_LOOPBACK - 1
                If abyData(i) <> i + 1 Then
                    ' data is not matched
                    fOK = False
                    Exit For
                End If
            Next i

            RaiseEvent S2F25LoopBackResult(fOK)
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_LoopBackReply", ex.ToString)
        End Try
    End Sub

    'S7F65
    Private Sub MySecxX_LotDataReply(ByVal vLotInfo As prjSECS.clsLotStructure) Handles MySecxX.LotDataReply
        Try
            Dim idxState As Integer
            Dim idxLot As Integer
            Dim idxPort As Integer

            'idxState = GetStateIndex(vLotInfo.PortPosition)
            idxState = vLotInfo.PortPosition
            WriteLogInfo(eLogType.TYPE_SYS, "S7F65: Delete timer ,Port=" & idxState.ToString)

            TimerDelete(idxState, eTimerType.TIMER_WAITS7F65)

            ' update lot info
            S7F65FillLot(vLotInfo)

            ' update the port info too
            MyPortInfo(vLotInfo.PortPosition).CassetteID = vLotInfo.CassetteID

            idxLot = SearchLotByPort(vLotInfo.PortPosition)

            ' add OperatorID (Will be used in S1F67)
            idxPort = GetPortIndex(vLotInfo.PortPosition)
            MyLotInfo(idxLot).OperatorID = GetOperatorID(idxPort)

            If vLotInfo.RecipeCode Or g_nCurrOnlineMode = eRemoteStatus.MODE_ONLINEMONITOR Then
                ' buffer port => no monitor mode!!!
                idxPort = GetPortIndex(vLotInfo.PortPosition)
                If MyPortInfo(idxPort).PortMode = ePortMode.MODE_LOADER Or MyPortInfo(idxPort).PortMode = ePortMode.MODE_LDULD Then
                    MyLotInfo(idxLot).RecipeNeedConfirm = True
                    vLotInfo.RecipeNeedConfirm = True
                End If
            End If

            WriteLogInfo(eLogType.TYPE_SYS, "STEP(Lot data download)=================" & MyPortStateControl(idxPort).nCurrStep)
            RaiseEvent S7F65CassetteDataDownloaded(vLotInfo)
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_LotDataReply", ex.ToString)
        End Try
    End Sub

    'S1F67/S1F68
    Private Sub MySecxX_LotStatusChangeReply(ByVal nPortNo As Integer, ByVal nRetCode As Integer, ByVal strNGGxFlag As String) Handles MySecxX.LotStatusChangeReply
        Try
            Dim idxState As Integer
            idxState = GetReplySnFn()

            If idxState > 0 Then
                RaiseEvent S1F68CSTStatusReply(MyPortStateControl(nPortNo).nPortNo, nRetCode, strNGGxFlag)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_LotStatusChangeReply", ex.ToString)
        End Try
    End Sub

    Private Sub MySecxX_ReceiveMSGReplyCode(ByVal nCodeType As eSECSStatusReplyType, ByVal nCode As Integer) Handles MySecxX.ReceiveMSGReplyCode
        Try
            Dim idxState As Integer
            Dim nParA As Integer = -1
            Dim nParB As Integer = -1
            Dim strParA As String = ""
            Dim strParB As String = ""

            idxState = GetReplySnFn(nParA, nParB, strParA, strParB)
            If idxState <= 0 Then Exit Sub

            MyPortStateControl(idxState).nGrantCode = nCode
            If IsCompletelyOffline() Then
                ' it will not receive the last message if offline (S1F66)
                ' => offline request is categorize as "not completely offline"
                MySecxX.RST_TransactionAbort(Mid(nCodeType.ToString, 4, 1))

                Exit Sub
            End If

            If Not g_fHSMSConnected Then Exit Sub

            Select Case nCodeType
                Case eSECSStatusReplyType.T_S1F66                    
                    RaiseEvent S1F66UnitStatusReply(MyPortStateControl(idxState).nGrantCode)
                    If g_fOfflineReq = True Then
                        Call HandleOffline()
                    End If
                Case eSECSStatusReplyType.T_S1F74
                    'idxState = GetReplySnFn(nParA, nParB, strParA, strParB, 1, 74)
                    If nParA = 0 Then
                        RaiseEvent S1F74LoadRequestStart(idxState)
                    Else
                        RaiseEvent S1F74LoadCompleted(MyPortInfo(idxState).PortPosition)
                    End If

                Case eSECSStatusReplyType.T_S1F76
                    'idxState = GetReplySnFn(nParA, nParB, strParA, strParB, 1, 76)
                    If nParA = 0 Then
                        RaiseEvent S1F76UnloadRequestStart(idxState)
                    Else
                        RaiseEvent S1F76UnloadCompleted(MyPortInfo(idxState).PortPosition)
                    End If
                Case eSECSStatusReplyType.T_S1F90                    
                    Call OnLineComplete()
                     
                Case eSECSStatusReplyType.T_S1F98
                    'EventTrigger(idxState, 1, 98)
                    'HOST Always reply OK...
                    RaiseEvent HOSTReplyCode(nCodeType, MyPortStateControl(idxState).nGrantCode)
                Case eSECSStatusReplyType.T_S5F66
                    'EventTrigger(idxState, 5, 66)
                    RaiseEvent HOSTReplyCode(nCodeType, MyPortStateControl(idxState).nGrantCode)
                    'Case eSECSStatusReplyType.T_S6F66
                    '    ' check whether all slots are processed
                    '    ' if not, stay at the same step
                    '    'EventTrigger(idxState, 6, 66)
                    'Case eSECSStatusReplyType.T_S6F70
                    '    'EventTrigger(idxState, 6, 70)

                Case eSECSStatusReplyType.T_S6F86                    
                    RaiseEvent HOSTReplyCode(nCodeType, MyPortStateControl(idxState).nGrantCode)
                Case eSECSStatusReplyType.T_S6F88                    
                    RaiseEvent HOSTReplyCode(nCodeType, MyPortStateControl(idxState).nGrantCode)
                Case eSECSStatusReplyType.T_S6F92                    
                    RaiseEvent HOSTReplyCode(nCodeType, MyPortStateControl(idxState).nGrantCode)
                Case eSECSStatusReplyType.T_S7F72
                    MyPortStateControl(idxState).nGrantCode = nCode
                    TimerDelete(idxState, eTimerType.TIMER_SENDS7F71)
                    If nCode = 0 Then
                        TimerAdd(idxState, eTimerType.TIMER_WAITS7F65, m_ConversationTimeout)
                    End If

                    RaiseEvent S7F72ReplyCassetteDataRequest(MyPortStateControl(idxState).nPortNo, nCode)
            End Select
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_ReceiveMSGReplyCode", ex.ToString)
        End Try
    End Sub

    'S7F4
    Private Sub MySecxX_RecipeParameterQuery(ByVal strLineID As String, ByVal strToolID As String, ByVal strPPID As String) Handles MySecxX.RecipeParameterQuery
        Try
            RaiseEvent S7F4RSTRecipeParameterQuery(strLineID, strToolID, strPPID)
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_RecipeParameterQuery", ex.ToString)
        End Try
    End Sub

    'S2F21
    Private Sub MySecxX_RemoteCommand(ByVal strCommand As String, ByVal nLoadPos As Integer, ByVal strCSTID As String, ByVal strRemoteCMD As String) Handles MySecxX.RemoteCommand
        Try

            Dim idxLot As Integer
            Dim idxState As Integer
            Dim strCmd As String

            strCmd = strCommand
            strCmd = Trim(strCmd)

            'idxState = GetStateIndex(nLoadPos)
            idxState = nLoadPos

            TimerDelete(idxState, eTimerType.TIMER_SENDS7F71)
            TimerDelete(idxState, eTimerType.TIMER_WAITS7F65)

            WriteLogInfo(eLogType.TYPE_SYS, "S2F21: Delete timer ,Port=" & idxState.ToString)

            TimerDelete(idxState, eTimerType.TIMER_WAITS2F21)


            MyPortStateControl(idxState).strRemoteCommand = strCmd

            ' check whether under recipe confirm
            ' if yes, reply the command directly
            If strCmd = CMD_START Then
                g_fRemotePause(idxState) = False
                g_fRemoteResume(idxState) = False

                idxLot = SearchLotByPort(nLoadPos)
                If idxLot <= 0 Then
                    ' block illegal remote command
                    SnFnAdd(nLoadPos, 2, 22, 0, 0, 2)
                    Exit Sub
                Else
                    If MyLotInfo(idxLot).RecipeNeedConfirm Then
                        WriteLogInfo(eLogType.TYPE_SYS, "Port " & CStr(nLoadPos) & " S2F21: Recipe under confirm, reply directly (CANNOTEXECUTE)...")
                        SnFnAdd(nLoadPos, 2, 22, 0, 0, 1)
                        Exit Sub
                    End If
                End If
            ElseIf strCmd = CMD_RESUME Then
                g_fRemotePause(idxState) = False
                g_fRemoteResume(idxState) = True
            ElseIf strCmd = CMD_SUSPND Then
                g_fRemotePause(idxState) = True
            ElseIf strCmd = CMD_CANCEL Then
                TimerDelete(idxState, eTimerType.TIMER_SENDS7F71)
                TimerDelete(idxState, eTimerType.TIMER_WAITS7F65)
            End If

            RaiseEvent S2F21RemoteCommand(nLoadPos, strCmd, strRemoteCMD)
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_RemoteCommand", ex.ToString)
        End Try
    End Sub

    Private Sub MySecxX_SECSTransactionError(ByVal strErrMsg As String) Handles MySecxX.SECSTransactionError

    End Sub

    'S2F18
    Private Sub MySecxX_SYNCDateTime(ByVal vDateTime As String) Handles MySecxX.SYNCDateTime
        GetReplySnFn()
        RaiseEvent S2F18SyncDateTime(vDateTime)

        ' do not drive state if auto sync request
        If m_fAutoSyncTime Then
            m_fAutoSyncTime = False            
        End If
    End Sub

    'S10F5
    Private Sub MySecxX_TerminalDisplay(ByVal nTerminalID As eTerminalID, ByVal strToolID As String, ByVal fBuzzer As Boolean, ByVal strText As String) Handles MySecxX.TerminalDisplay
        Try
            RaiseEvent S10F5TerminalRequest(nTerminalID, fBuzzer, strText)
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_TerminalDisplay", ex.ToString)
        End Try
    End Sub

    ' S1F87
    Private Sub MySecxX_WIPDataRequest() Handles MySecxX.WIPDataRequest
        Try
            WriteLogInfo(eLogType.TYPE_EVENT, "CCIM, WIPRequest")

            RaiseEvent S1F87WIPRequest()
        Catch ex As Exception
            WrigeExceptionLog("Sub MySecxX_WIPDataRequest", ex.ToString)
        End Try
    End Sub
#End Region

#Region "Timer obj Handle"
    Private Sub MyReportAlarm_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyReportAlarm.Tick '?????????????
        Dim vXAlarm As clsMyAlarmStructure
        Dim vXAlarmInfo As clsMyAlarmStructure
        Dim nFor As Integer


        vXAlarm = New clsMyAlarmStructure
        vXAlarm.MyAlarmStructrue = New prjSECS.clsAlarmStructure
        If Not IsOnLineMode() Then Exit Sub
        Try
            If mAlarmOfflineCol.Count = 0 And IsOnLineMode() Then
                MyReportAlarm.Enabled = False
                Exit Sub
            End If

            If g_fHSMSConnected Then
                'InsertSequence(eOnLineStep.ONL_ANYTIME_OFFLINEALARM, 0)

                If mAlarmOfflineCol.Count > 0 Then
                    For nFor = 0 To mAlarmOfflineCol.Count - 1
                        vXAlarmInfo = mAlarmOfflineCol.Item(1)

                        vXAlarm.MyUnitNo = vXAlarmInfo.MyUnitNo
                        vXAlarm.GlassAffect = vXAlarmInfo.GlassAffect
                        vXAlarm.DateTimeInfo = vXAlarmInfo.DateTimeInfo
                        vXAlarm.WithGx = vXAlarmInfo.WithGx
                        With vXAlarmInfo
                            vXAlarm.MyAlarmStructrue.AlarmFlag = .MyAlarmStructrue.AlarmFlag
                            vXAlarm.MyAlarmStructrue.AlarmType = .MyAlarmStructrue.AlarmType
                            vXAlarm.MyAlarmStructrue.AlarmID = .MyAlarmStructrue.AlarmID
                            vXAlarm.MyAlarmStructrue.AlarmText = .MyAlarmStructrue.AlarmText

                        End With
                        mAlarmIn.Add(vXAlarm)
                        SnFnAdd(0, 5, 65, 1)

                        If vXAlarmInfo.MyAlarmStructrue.AlarmFlag = eAlarmFlag.TYPE_RELEASE Then
                            MyUnitInfo(vXAlarmInfo.MyUnitNo).Alarm.AlarmID = 0
                        End If
                        mAlarmOfflineCol.Remove(1)
                    Next

                    vXAlarmInfo = Nothing
                End If
                MyReportAlarm.Enabled = False
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MyReportAlarm_Tick", ex.ToString)
        End Try
    End Sub

    Private Sub MyReportRecipe_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyReportRecipe.Tick
        Try
            Dim objIniSetting = New IniConfigSource(IniCIMFilePath)
            Dim ConfigInfo As IConfig

            Dim i As Integer
            Dim strRecipe As String
            Dim vGet As Object
            Dim fFound As Boolean
            If Not IsOnLineMode() Then Exit Sub
            ConfigInfo = objIniSetting.Configs(RECIPE_SECTION)

            If ConfigInfo.Get(RECIPE_EXIST) Then
                For i = 1 To MAX_RECIPE
                    strRecipe = ConfigInfo.Get(CStr(i))
                    If strRecipe <> "" Then
                        fFound = True
                        ' 0 = ToolID, 1 = time, 2 = PPID
                        vGet = Split(strRecipe, ",")
                        If g_fHSMSConnected Then
                            AddReportRecipeChange(vGet(0), vGet(2), vGet(1))
                            SnFnAdd(0, 1, 97, 1)                            
                        End If

                        objIniSetting.Configs(RECIPE_SECTION).Set(CStr(i), "")
                        objIniSetting.Save()
                        Exit For
                    End If
                Next i

                If Not fFound Then
                    objIniSetting.Configs(RECIPE_SECTION).Set(RECIPE_EXIST, "0")
                    objIniSetting.Save()
                    MyReportRecipe.Enabled = False
                End If
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MyReportRecipe_Tick", ex.ToString)
        End Try
    End Sub

    'Private Sub MyDispatcher_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyDispatcher.Tick
    '    Try
    '        Dim i As Integer
    '        Dim idxEvent As Integer
    '        Dim nStream As Integer
    '        Dim nFunction As Integer

    '        Dim idxItem As Integer

    '        Dim evt As New clsEventItem
    '        Dim Seq As New clsInsertSeq
    '        Dim f1stAutoUnloadReq As Boolean

    '        For i = 1 To g_nMaxPorts
    '            ' the conditions before drive event
    '            ' 1. whether EventTrigger is executing, if yes, wait for next chance
    '            If g_fInsideEventTrigger Then Exit For

    '            ' MGV buffer -> no CIM sequence
    '            If MyPortInfo(i).PortMode = ePortMode.MODE_BUFFER And Not g_fRunMGVBufCIM Then
    '                ' skip
    '            Else
    '                ' 2. whether any buffermsg pending
    '                ' 3. whether port is suspended
    '                ' 4. whether current step is ok to execute

    '                idxEvent = GetFirstBufMsg(i)
    '                If idxEvent > 0 Then
    '                    ' drive only it is the first one to execute
    '                    If idxEvent = 1 And g_colEventQueue.Count = 0 Then
    '                        ' skip if waiting for reply (could be queued by EventTrigger)
    '                        If Not MyPortStateControl(i).fWait2NdMSG Then
    '                            evt = GetBufMsgByIndex(idxEvent)
    '                            nStream = evt.StreamID
    '                            nFunction = evt.FunctionID

    '                            EventTrigger(i, nStream, nFunction)
    '                        End If
    '                    End If
    '                Else
    '                    ' check no event pending
    '                    If g_colEventQueue.Count = 0 Then
    '                        If Not MyPortStateControl(i).fSuspend Then
    '                            If (IsActiveStep(i) Or MyPortStateControl(i).fForceExecute) Then
    '                                ' cannot issue <LoadReq> to non-empty port, jump to unload request
    '                                ' should exclude the disabled state
    '                                If MyPortStateControl(i).nCurrStep = eOnLineStep.ONL_LOADREQ Then
    '                                    If MyPortInfo(i).PortStatus = 0 Or MyPortInfo(i).PortStatus = ePortStatus.TSIP_EMPTY Or MyPortInfo(i).PortStatus = ePortStatus.TSIP_LOADREQ Then
    '                                        ' keep going
    '                                        GetCurrSnFm(i, nStream, nFunction)
    '                                        EventTrigger(i, nStream, nFunction)
    '                                    ElseIf MyPortInfo(i).PortStatus = ePortStatus.TSIP_DISABLE Then
    '                                        ' no action
    '                                    Else
    '                                        MyPortStateControl(i).nCurrStep = eOnLineStep.ONL_UNLOADREQ
    '                                    End If
    '                                Else
    '                                    ' to stop execute after first unload request - online
    '                                    If MyPortStateControl(i).nCurrStep = eOnLineStep.ONL_UNLOADREQ Then
    '                                        f1stAutoUnloadReq = True
    '                                    End If
    '                                    GetCurrSnFm(i, nStream, nFunction)
    '                                    EventTrigger(i, nStream, nFunction)
    '                                    If f1stAutoUnloadReq Then
    '                                        f1stAutoUnloadReq = False
    '                                        MyPortStateControl(i).fForceExecute = False
    '                                    End If
    '                                End If
    '                            Else
    '                                ' check whether any inserted message
    '                                idxItem = GetInsertedSeqPending(i)
    '                                If idxItem > 0 Then
    '                                    Seq = PokeSeq(idxItem)
    '                                    ExecInsertSequence(Seq.InsertState, Seq.InsertTable, Seq.InsertSeq)
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        Next i
    '    Catch ex As Exception
    '        WrigeExceptionLog("Sub MyDispatcher_Tick", ex.ToString)
    '    End Try
    'End Sub

    Private Sub MyTimeout_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTimeout.Tick
        Try
            Dim i As Integer
            Dim vGet As Object
            Dim lngCurrTicks As Long = My.Computer.Clock.TickCount



            For i = 1 To g_colTimer.Count
                ' to prevent the evualtion error
                ' check the count again, it maybe decrement inside the loop
                If i > g_colTimer.Count Then Exit For

                vGet = Split(g_colTimer.Item(i), ",")

                ' vGet(2) = due ticks

                If lngCurrTicks > CLng(vGet(2)) Then
                    ' timeout occur
                    g_colTimer.Remove(i)

                    ' drive timeout event, vGet(1) = timer type
                    Select Case vGet(1)
                        Case eTimerType.TIMER_ONLINE
                            GetOnLineTimeout(vGet(0))
                        Case eTimerType.TIMER_WAITS7F65
                            WaitHostTimeout(vGet(0))

                            S9F13ReportConversationTimeout(7, 65, vGet(0))
                        Case eTimerType.TIMER_WAITS2F21
                            MyPortStateControl(vGet(0)).nCurrStep = eOnLineStep.ONL_REMOTECMD
                            WaitHostTimeout(vGet(0))
                            S9F13ReportConversationTimeout(2, 21, vGet(0))
                        Case eTimerType.TIMER_SENDS7F71

                            'EventTrigger(GetStateIndex(vGet(0)), 7, 65)
                            S9F13ReportConversationTimeout(7, 65, vGet(0))
                            g_afCSTVLoad(vGet(0)) = False
                    End Select

                    ' adjust index after removal
                    If g_colTimer.Count >= i Then
                        i = i - 1
                    ElseIf g_colTimer.Count = 0 Then
                        Exit For
                    End If
                End If
            Next i
        Catch ex As Exception
            WrigeExceptionLog("Sub MyTimeout_Tick", ex.ToString)
        End Try
    End Sub

    Private Sub MyHeartBeat_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyHeartBeat.Tick
        Try

            Dim objIniSetting = New IniConfigSource(IniCIMFilePath)
            Dim ConfigInfo As IConfig
            ConfigInfo = objIniSetting.Configs(STR_SYSTEMSEC)


            ' in unit of 10 seconds
            ' every 10 minutes (Count = 60), send S1F1
            ' every hour (Count = 360), send S2F17



            m_S2F17CountDown = m_S2F17CountDown - 1
            If m_S2F17CountDown <= 0 Then
                If IsOnLineMode() And g_fHSMSConnected Then
                    m_fAutoSyncTime = True
                    MySecxX.RST_RequestDateTime()
                End If
                m_S2F17CountDown = ConfigInfo.Get(STR_S2F17INTERNAL)
            End If
        Catch ex As Exception
            WrigeExceptionLog("Sub MyTimeout_Tick", ex.ToString)
        End Try
    End Sub
#End Region

    Protected Overrides Sub Finalize()
        Dim nFor As Integer

        For nFor = 1 To mAlarmIn.Count
            mAlarmIn.Remove(1)
        Next
        mAlarmIn = Nothing
        For nFor = 1 To mAlarmOut.Count
            mAlarmOut.Remove(1)
        Next
        mAlarmOut = Nothing
        For nFor = 1 To mAlarmOfflineCol.Count
            mAlarmOfflineCol.Remove(1)
        Next
        mAlarmOfflineCol = Nothing

        g_colReplyStateCtl = Nothing
        g_colEventQueue = Nothing
        g_colBufferMsg = Nothing
        g_colInsertSeq = Nothing
        g_colTimer = Nothing
        g_colWorkAPD = Nothing
        g_colGlassRun = Nothing
        g_colUnitNo = Nothing
        g_colRecipeChanged = Nothing
        g_colLotStatus = Nothing
        g_colRecipeLastModifyInfo = Nothing
        MySECS = Nothing

        MyBase.Finalize()

    End Sub

    Public Sub SimEDS()
        MySecxX_EQStatusRequest(prjSECS.clsSECSMain.eS1F6SFCD.SFCD_EDSReport, "", "")
    End Sub

 
    Private Sub SnFnAdd(ByVal nPos As Integer, ByVal nStream As Integer, ByVal nFunction As Integer, ByVal nSendByEQ As Integer, Optional ByVal nSPCodeA As Integer = -1, Optional ByVal nSPCodeB As Integer = -1, Optional ByVal strParA As String = "", Optional ByVal strParB As String = "")
        Dim fAddCol As Boolean

        If IsOnLineMode() Then
            fAddCol = True
        Else
            If nStream = 1 Then
                If nFunction = 1 Or nFunction = 89 Then
                    fAddCol = True
                End If
            End If

            If nStream = 2 Then
                If nFunction = 17 Or nFunction = 25 Then
                    fAddCol = True
                End If
            End If
        End If

        If fAddCol Then
            Me.colSnFn.Add(nPos & "," & nStream & "," & nFunction & "," & nSendByEQ & "," & nSPCodeA & "," & nSPCodeB & "," & strParA & "," & strParB)

            If nSendByEQ Then 'Append Wait receive SnFn
                colSnFnSecend.Add(nPos & "," & nStream & "," & nFunction + 1 & ",0," & nSPCodeA & "," & nSPCodeB & "," & strParA & "," & strParB)
            End If
        End If
    End Sub

    Private Function GetReplySnFn(Optional ByRef nParA As Integer = -1, Optional ByRef nParB As Integer = -1, Optional ByRef strParA As String = "", Optional ByRef strParB As String = "", Optional ByVal mysn As Integer = 0, Optional ByVal myfn As Integer = 0) As Integer
        Dim vGet As Object
        Dim nPos As Integer
        Dim nSn As Integer
        Dim nFn As Integer
        Dim nSendByEQ As Integer

        Dim nFor As Integer

        If colSnFnSecend.Count > 0 Then
            WaitReply = False
            For nFor = 1 To colSnFnSecend.Count
                vGet = Split(colSnFnSecend.Item(nFor), ",")

                nPos = vGet(0)
                nSn = vGet(1)
                nFn = vGet(2)
                nSendByEQ = vGet(3)
                nParA = vGet(4)
                nParB = vGet(5)
                strParA = vGet(6)
                strParB = vGet(7)

                If mysn <> 0 And myfn <> 0 Then
                    If nSn = mysn And nFn = myfn + 1 Then
                        WriteLogInfo(eLogType.TYPE_METHOD, "GetReplySnFn, CurrentSn=" & CurrentSn.ToString & ",Pos=" & vGet(0).ToString & ",Sn=" & vGet(1).ToString & ",Fn=" & vGet(2).ToString & ",SendByEQ=" & vGet(3).ToString _
                                     & ",nParA=" & vGet(4).ToString & ",nParB=" & vGet(5).ToString & ",strParA=" & vGet(6).ToString & ",strParB=" & vGet(7).ToString)
                        colSnFnSecend.Remove(nFor)
                        Me.WaitReply = False
                        GetReplySnFn = nPos
                        Exit Function
                    End If
                Else
                    If nSn = CurrentSn And nFn = CurrentFn + 1 Then
                        WriteLogInfo(eLogType.TYPE_METHOD, "GetReplySnFn, CurrentSn=" & CurrentSn.ToString & ",Pos=" & vGet(0).ToString & ",Sn=" & vGet(1).ToString & ",Fn=" & vGet(2).ToString & ",SendByEQ=" & vGet(3).ToString _
                                     & ",nParA=" & vGet(4).ToString & ",nParB=" & vGet(5).ToString & ",strParA=" & vGet(6).ToString & ",strParB=" & vGet(7).ToString)
                        colSnFnSecend.Remove(nFor)
                        Me.WaitReply = False
                        GetReplySnFn = nPos
                        Exit Function
                    End If
                End If
            Next nFor
        End If
    End Function

    Private Sub SnFnProcess()
        Dim vGet As Object
        Dim nPos As Integer
        Dim nSn As Integer
        Dim nFn As Integer
        Dim nSendByEQ As Integer
        Dim nParA As Integer
        Dim nParB As Integer
        Dim strParA As String
        Dim strParB As String


        If colSnFn.Count > 0 Then
            'If WaitReply Then Exit Sub

            vGet = Split(colSnFn.Item(1), ",")
            colSnFn.Remove(1)
            nPos = vGet(0)
            nSn = vGet(1)
            nFn = vGet(2)
            nSendByEQ = vGet(3)
            nParA = vGet(4)
            nParB = vGet(5)
            strParA = vGet(6)
            strParB = vGet(7)


            CurrentSn = nSn
            CurrentFn = nFn

            If nSendByEQ = 1 Then WaitReply = True
            HandleSECSFunction(nPos, nSn, nFn, nParA, nParB, strParA, strParB)
        End If
    End Sub

    Private Sub SnFnRemove()
        If colSnFn.Count > 0 Then
            colSnFn.Remove(1)
        End If
    End Sub

    Private Property CurrentSn() As Integer
        Get
            CurrentSn = mvarCurrentSn
        End Get
        Set(ByVal value As Integer)
            mvarCurrentSn = value
        End Set
    End Property

    Private Property CurrentFn() As Integer
        Get
            CurrentFn = mvarCurrentFn
        End Get
        Set(ByVal value As Integer)
            mvarCurrentFn = value
        End Set
    End Property

    Private Property WaitReply() As Boolean
        Get
            WaitReply = mvarWaitReply
        End Get
        Set(ByVal value As Boolean)
            mvarWaitReply = value
        End Set
    End Property

    Private Sub HandleSECSFunction(ByVal nPos As Integer, ByVal nSn As Integer, ByVal nFn As Integer, Optional ByVal nParA As Integer = 0, Optional ByVal nParB As Integer = 0, Optional ByVal strParA As String = "", Optional ByVal strParB As String = "", Optional ByRef vObj As Object = Nothing)
        Dim idxLot As Integer
        Dim vXAlarmInfo As clsMyAlarmStructure
        Dim mEDSReportInfo(0) As prjSECS.clsEDSStructure


        Select Case nSn
            Case 1
                Select Case nFn
                    Case 1 'S1F1           
                        MySecxX.RST_Connect()

                        WriteLogInfo(eLogType.TYPE_SYS, "S1F1: Set timer")
                        TimerAdd(nPos, eTimerType.TIMER_ONLINE, m_ConversationTimeout)
                        'kent 2011/02/16
                    Case 65 'S1F65 EQ Status change report
                        Select Case nParA
                            Case 0
                                'MySecxX.RST_ReportMachineStatus(MyUnitInfo(MAIN_RST))
                                MySecxX.RST_ReportMachineStatus(MyUnitInfo(nPos))
                            Case Else
                                Call HandleUnitStatus()
                        End Select

                    Case 67 'S1F67 CST Status change report
                        If nParA = 1 Then
                            Call HandleCSTProcessEnd(nPos)
                        Else
                            Call HandleLotStatus(nPos)
                        End If

                    Case 73 'S1F73 CST LoadReq/LoadComp report
                        Select Case nParA
                            Case 0 'Load Req
                                MyPortInfo(MyPortInfo(nPos).PortPosition).PortStatus = ePortStatus.TSIP_LOADREQ
                                'RaiseEvent LoadRequestStart(MyPortInfo(nPos).PortPosition)
                                MySecxX.RST_LoadStatus(eLDSTA.CST_LOAD_REQ, MyPortInfo(nPos).PortMode, Space(LEN_CASID), MyPortInfo(nPos).PortPosition, MyPortInfo(nPos).AGVMode, MyPortInfo(nPos).PortCategory)

                            Case 1 'Load Comp
                                idxLot = SearchLotByPort(MyPortStateControl(nPos).nPortNo)
                                If idxLot <= 0 Then
                                    AddLot(MyPortStateControl(nPos).nPortNo)
                                End If

                                MyPortInfo(MyPortStateControl(nPos).nPortNo).PortStatus = ePortStatus.TSIP_CST_PRESENT
                                MyPortInfo(nPos).CassetteID = ""
                                MySecxX.RST_LoadStatus(eLDSTA.CST_LOAD_COMP, MyPortInfo(nPos).PortMode, MyPortInfo(nPos).CassetteID, MyPortInfo(nPos).PortPosition, MyPortInfo(nPos).AGVMode, MyPortInfo(nPos).PortCategory)

                            Case 2 'Port Disable
                                MyPortInfo(MyPortInfo(nPos).PortPosition).PortStatus = ePortStatus.TSIP_DISABLE
                                MySecxX.RST_LoadStatus(eLDSTA.CST_PORT_DISABLE, MyPortInfo(nPos).PortMode, MyPortInfo(nPos).CassetteID, MyPortInfo(nPos).PortPosition, MyPortInfo(nPos).AGVMode, MyPortInfo(nPos).PortCategory)
                        End Select
                    Case 75 'S1F75 CST UnloadReq/UnloadComp report    
                        Select Case nParA
                            Case 0 'Unload Req
                                MyPortInfo(MyPortInfo(nPos).PortPosition).PortStatus = ePortStatus.TSIP_END_WITHUNLOAD
                                'RaiseEvent UnloadRequestStart(MyPortInfo(nPos).PortPosition)
                                g_afCassetteUnloadReq(MyPortStateControl(nPos).nPortNo) = False
                                MyPortInfo(nPos).CassetteID = ""
                                MySecxX.RST_UnloadStatus(eULDSTA.CST_UNLOAD_REQ, MyPortInfo(nPos).PortMode, MyPortInfo(nPos).CassetteID, MyPortInfo(nPos).PortPosition, MyPortInfo(nPos).AGVMode, MyPortInfo(nPos).PortCategory)

                            Case 1 'Unload Comp
                                g_afCassetteRemoveReq(MyPortStateControl(nPos).nPortNo) = False
                                MySecxX.RST_UnloadStatus(eULDSTA.CST_UNLOAD_COMP, MyPortInfo(nPos).PortMode, MyPortInfo(nPos).CassetteID, MyPortInfo(nPos).PortPosition, MyPortInfo(nPos).AGVMode, MyPortInfo(nPos).PortCategory)
                        End Select
                    Case 89 'Online summary status report
                        MySecxX.RST_ReportWholeStatus(eRiportType.TYPE_S1F89, MyUnitInfo)

                        ' change to designated online mode
                        MyUnitInfo(MAIN_UNIT).RemoteStatus = g_nChangedMode
                    Case 97 'Recipe modifyed report
                        Call HandleRecipeChanged()
                    Case 2 'S1F2
                        MySECS.RST_ReplyConnect()
                    Case 6 'S1F6 reply EDS
                        Select Case nParA
                            Case 1
                                MySECS.RST_ReportToolStatus(MyUnitInfo(nPos))
                            Case 7
                                mEDSReportInfo(0) = New prjSECS.clsEDSStructure
                                mEDSReportInfo(0).EDSName = "NA"
                                mEDSReportInfo(0).EDSValue = "NA"

                                MySECS.RST_ReportEDS(MyUnitInfo(1).EQStatus, mEDSReportInfo)

                                mEDSReportInfo = Nothing
                            Case 8
                                MySECS.RST_ReportWholeStatus(eRiportType.TYPE_S1F5_SFCD8, MyUnitInfo)
                        End Select

                    Case 88 'S1F88 Reply S1F87(HOST=>EQ) WIP Data Query
                        MySECS.RST_ReplyWIPData(MyWIPInfo)
                End Select
            Case 2
                Select Case nFn
                    Case 17 'S2F17 Date and time req
                        MySecxX.RST_RequestDateTime()
                    Case 25 'S2F25 Loop-Back
                        MySECS.RST_LoopBackTest()
                    Case 22 'S2F22 reply S2F21 Remote command
                        If nParA = 0 Then
                            MySECS.RST_ReplyRemoteCommand(eRemoteReplyCMD.CMD_ACCEPTED)
                        ElseIf nParA = 1 Then
                            MySecxX.RST_ReplyRemoteCommand(eRemoteReplyCMD.CMD_CMD_NO_DEFINE)
                        ElseIf nParA = 2 Then
                            MySECS.RST_ReplyRemoteCommand(eRemoteReplyCMD.CMD_CANT_EXECUTE)
                        Else
                            MySecxX.RST_ReplyRemoteCommand(nParA)
                        End If
                    Case 26 'S2F26 reply S2F25 Loop-Back
                    Case 42 'S2F42 reply S2F41 HOST command send
                        MySecxX.RST_EQRemoteCMD(nParA)
                End Select
            Case 5
                If nFn = 65 Then 'S5F65 Alarm occurred/removed report
                    If mAlarmIn.Count > 0 Then
                        vXAlarmInfo = mAlarmIn.Item(1)

                        MySecxX.RST_ReportAlarm(MyUnitInfo(vXAlarmInfo.MyUnitNo), vXAlarmInfo.MyAlarmStructrue, vXAlarmInfo.GlassAffect, vXAlarmInfo.WithGx, vXAlarmInfo.DateTimeInfo)

                        If vXAlarmInfo.MyAlarmStructrue.AlarmFlag = eAlarmFlag.TYPE_RELEASE Then
                            MyUnitInfo(vXAlarmInfo.MyUnitNo).Alarm.AlarmID = 0
                            RemoveOutAlarm(vXAlarmInfo)
                        Else
                            ' copy to "out" collection
                            CopyToOutAlarm(vXAlarmInfo)
                        End If

                        ' clear In
                        vXAlarmInfo.MyAlarmStructrue = Nothing
                        vXAlarmInfo = Nothing
                        mAlarmIn.Remove(1)
                    End If
                End If
            Case 6
                Select Case nFn
                    Case 85 'S6F85 Work removd data report
                        MySecxX.RST_GlassErase(strParA, strParB)

                    Case 87 'S6F87 Work ID un-match report
                        MySecxX.RST_ReportGxIDUnmatch(MyUnitInfo(m_nUnitNoWorkID).ToolID, strParA, strParB)

                    Case 91 'S6F91 Class process start/end data report
                        HandleGlassRun(nPos)
                End Select
            Case 7
                Select Case nFn                   
                    Case 4 'S7F4 reply S7F3  Recipe Par Query

                        Call HandleRecipeParameterReport()
                    Case 66 'S7F66 reply S7F65 Inline Proces data transfer
                        g_fRemotePause(nPos) = False
                        g_fRemoteResume(nPos) = False

                        'Monitor S7F56<=>S2F21 T9
                        WriteLogInfo(eLogType.TYPE_SYS, "S7F65: Set timer")

                        TimerAdd(nPos, eTimerType.TIMER_WAITS2F21, m_ConversationTimeout)

                        MySecxX.RST_LotDataConfirm(MyPortStateControl(nPos).nAckC7)

                    Case 68 'S7F68 reply S7F67 Inquire last modification date/time of recipe id
                        Call HandleRecipeLastModifyInfoReport()
                    Case 71 'S7F71 Process Data Request
                        'Monitor S7F71<=>S7F65 T9
                        WriteLogInfo(eLogType.TYPE_SYS, "S7F71[V]: Set timer")
                        TimerAdd(nPos, eTimerType.TIMER_SENDS7F71, m_ConversationTimeout)
                        MyPortInfo(nPos).CassetteID = ""
                        MySecxX.RST_LotDataRequest(MyPortInfo(nPos).PortPosition, MyPortInfo(nPos).CassetteID, GetOperatorID(MyPortStateControl(nPos).nPortNo), MyPortInfo(nPos).PortMode, MyPortInfo(nPos).PortCategory)

                End Select
            Case 9
                Select Case nFn
                    Case 1 'S9F1 Unrecognized device id
                    Case 3 'S9F3 unrecognized stream function
                    Case 5 'S9F5 unrecognized function type
                    Case 7 'S9F7 unrecognizedIllegal data
                    Case 9 'S9F9 transaction timer time-out
                    Case 11 'S9F11 data too long
                    Case 13 'S9F13 conversation time-out
                        MySecxX.RST_ReportConversationTimeout(nParA, nParB)
                End Select
            Case 10
                If nFn = 1 Then 'S10F1 Terminal request
                    MySECS.RST_TerminaSend(strParA)
                End If
        End Select
    End Sub


    Public Sub S2F17RequestDateAnadTime()
        SnFnAdd(1, 2, 17, 1)
    End Sub

    Public Sub S1F89SummaryStatusReport()
        WriteLogInfo(eLogType.TYPE_METHOD, "Send S1F89 Online summary status report")
        SnFnAdd(1, 1, 89, 1)
    End Sub

    'S9F13
    Public Sub S9F13ReportConversationTimeout(ByVal nStream As Integer, ByVal nFunction As Integer, Optional ByVal nPort As Integer = 0)
        RaiseEvent S9F13ConversationTimeoutOccur(nPort, nStream, nFunction)
        'MySecxX.RST_ReportConversationTimeout(nStream, nFunction)
        SnFnAdd(0, 9, 13, 0, nStream, nFunction)
    End Sub

    Private Sub MySnFnTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MySnFnTimer.Tick


        SnFnProcess()
    End Sub

    Private Sub OnLineComplete()
        TimerDelete(0, eTimerType.TIMER_ONLINE)
        g_nCurrOnlineMode = g_nChangedMode
        MyUnitInfo(MAIN_UNIT).RemoteStatus = g_nCurrOnlineMode
        g_fTryOnOffLine = False

        'all the unit should change remote status too
        For i = 1 To g_nMaxUnits
            MyUnitInfo(i).RemoteStatus = g_nCurrOnlineMode
        Next i

        RaiseEvent S1F90OnLineComplete(g_nCurrOnlineMode)
        Call ReportOffLineRSTInfo()
    End Sub

    Private Sub ReportOffLineRSTInfo()
        Try
            Dim objIniSetting = New IniConfigSource(Me.IniCIMFilePath)
            Dim ConfigInfo As IConfig
            Dim nRecipeReport As Integer

            'If mAlarmOfflineCol.Count > 0 Then
            '    MyReportAlarm.Enabled = True
            'End If

            ConfigInfo = objIniSetting.Configs(RECIPE_SECTION)
            nRecipeReport = ConfigInfo.Get(RECIPE_EXIST)



            ConfigInfo = objIniSetting.Configs(STR_SYSTEMSEC)

            m_S1F1CountDown = ConfigInfo.Get(STR_S1F1INTERNAL)
            m_S2F17CountDown = ConfigInfo.Get(STR_S2F17INTERNAL)
            objIniSetting = Nothing
            If nRecipeReport = 1 Then
                MyReportRecipe.Enabled = True
                MyReportRecipe.Start()
            End If
        Catch ex As Exception
            WrigeExceptionLog("ReportOffLineRSTInfo ", ex.ToString)
        End Try
        
    End Sub

    Public Sub CIMStepOnLineComp(ByVal nMode As eRemoteStatus)
        Dim nFor As Integer = 0
        g_nChangedMode = nMode
        g_nCurrOnlineMode = g_nChangedMode
        MyUnitInfo(MAIN_UNIT).RemoteStatus = g_nCurrOnlineMode
        g_fTryOnOffLine = False

        'all the unit should change remote status too
        For i = 0 To g_nMaxUnits
            MyUnitInfo(i).UnitNo = i
            MyUnitInfo(i).RemoteStatus = g_nCurrOnlineMode
        Next i
        For i = 0 To g_nMaxUnits
            Me.UpdateUnitInfo(i, MyUnitInfo(i))
        Next
    End Sub

    Public Sub ReOnLine(ByVal nChangedMode As eRemoteStatus, ByVal sLotInfo() As prjSECS.clsLotStructure)
        Dim nFor As Integer
        For nFor = 1 To UBound(sLotInfo)
            MyLotInfo(nFor) = sLotInfo(nFor)
        Next
    End Sub

    Public Sub CIMStepFillPortInfo(ByVal vPortInfo As prjSECS.clsPortStructure)
        MyPortInfo(vPortInfo.PortPosition) = vPortInfo
        Me.PortInfoChanged(vPortInfo)
    End Sub

    Public Sub CIMStepFillUnitInfo(ByVal vUnitInfo As prjSECS.clsUnitStructure)
        MyUnitInfo(vUnitInfo.UnitNo) = vUnitInfo
    End Sub
End Class