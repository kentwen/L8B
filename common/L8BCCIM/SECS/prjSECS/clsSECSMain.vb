Imports prjSECS.clsEnumCtl
Imports System.Threading

Public Class clsSECSMain
    'T3 Timeout Check By SEMI Level
    Dim ReceiveThread As Thread
    Dim m_fStop As Boolean = False

    Enum eSendMSGType
        SendS9F3 = 0
        SendS9F5 = 1
        SendS9F7 = 2
        SendS9F9 = 3
        SendS9F11 = 4
        SendS9F13 = 5
        TYPE_P = 6
        TYPE_S = 7
    End Enum

#Region "Reply MSG By Transaction"
    ' ''Dim ReplyTransactionS1F5 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS1F2 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS1F87 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS2F21 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS2F25 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS2F41 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS7F3 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS7F65 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS7F67 As New SecsWrapperOCX.SecsTransactionX
    ' ''Dim ReplyTransactionS10F5 As New SecsWrapperOCX.SecsTransactionX
#End Region

    Public Enum eTransactionError
        ERR_P = -1      'Primary Msg Send Fail
        ERR_S = -2       'Secondary Msg Send Fail
        ERR_T3 = -3     'T3 Timout Occurr
        ERR_DEVICE = -4  'Device ID Error
    End Enum

    Public Enum eS1F6SFCD
        SFCD_EQStatusDataReport = &H1
        SFCD_EDSReport = &H7
        SFCD_OverallReport = &H8
    End Enum

    'Dim SendMsgs As New Collection
    'Dim SendMsgsType As New Collection
    'Dim SendMsgsBuffer As New Collection
    Dim RecevieMsgs As New Collection

#Region "Event Define"

    Public WithEvents MySECSEvent As prjSEMI.clsHSMS

    Public Event LogReport(ByVal strLog As String)
    Public Event HOSTConnectStatus(ByVal fConnect As Boolean)

    Public Event TransactionAbortRequest(ByVal nStream As Integer) 'SnF0
    Public Event HOSTOnlineReq() 'S1F1
    Public Event HOSTOnlineReply() 'S1F2
    'S1F5
    Public Event EQStatusRequest(ByVal nRequestType As eS1F6SFCD, ByVal strLineID As String, ByVal strToolID As String)

    'RTNCD Event
    Public Event ReceiveMSGReplyCode(ByVal nCodeType As clsEnumCtl.eSECSStatusReplyType, ByVal nCode As Integer)

    'S1F68
    Public Event LotStatusChangeReply(ByVal nPortNo As Integer, ByVal nRetCode As Integer, ByVal strNGGxFlag As String)

    'S1F87
    Public Event WIPDataRequest()

    'S2F18
    Public Event SYNCDateTime(ByVal vDateTime As String)

    'S2F21
    Public Event RemoteCommand(ByVal strCommand As String, ByVal nLoadPos As Integer, ByVal strCSTID As String, ByVal strRemoteCMD As String)

    'S2F25
    Public Event LoopBackRequest(ByVal aData() As Byte)
    Public Event LoopBackReply(ByVal abyData() As Byte)

    'S2F41 
    Public Event EQRemoteCommand(ByVal strToolID As String, ByVal strCSTID As String, ByVal strCMD As String, ByVal strSaveFlag As String, ByVal strMSG As String)

    'S7F3
    Public Event RecipeParameterQuery(ByVal strLineID As String, ByVal strToolID As String, ByVal strPPID As String)
    'S7F65
    Public Event LotDataReply(ByVal vLotInfo As clsLotStructure)

    'S7F67
    Public Event LastRecipeModifyTime(ByVal strRecipe As String)
    Public Event ErrorOccurred(ByVal lCode As Long, ByVal strText As String)
    'S10F5
    Public Event TerminalDisplay(ByVal nTerminalID As clsEnumCtl.eTerminalID, ByVal strToolID As String, ByVal fBuzzer As Boolean, ByVal strText As String)

    Public Event HSMSMonitor(ByVal Sent As Boolean, ByVal ByteType As Long, ByVal Description As String)

    Public Event SECSTransactionError(ByVal strErrMsg As String)
    Public Event TRLog(ByVal strLog As String)

    Public Event ErrDataTooLongS9F11(ByVal nStreamID As Integer, ByVal nFunctionID As Integer)
    Public Event ErrIllegalDataS9F7(ByVal nStreamID As Integer, ByVal nFunctionID As Integer)

#End Region

#Region "SECS Driver Parameter Setting [IP/Port/DeviceID/Line Name/ Line Tool Name]"
    Private mvarSECSXMLIniFullName As String
    Private mvarHOSTIP As String
    Private mvarHOSTTCPPort As Integer
    Private mvarDeviceID As Integer
    Private mvarConnetcMode As Long
    Private mvarConnectTimeout As Integer
    Private mvarLineName As String
    Private mvarLineToolName As String
    Private mvarLinkTestTimer As Integer
    Private mvarHOSTConnectType As clsEnumCtl.eConnectType

    Private mvarHSMSRetryTimes As Integer
    Private mvarSimServerCMD As Boolean
    Private mvarCCIMOnLineMode As eRemoteStatus

    Public Property CCIMOnLineMode() As eRemoteStatus
        Get
            CCIMOnLineMode = mvarCCIMOnLineMode

        End Get
        Set(ByVal value As eRemoteStatus)
            mvarCCIMOnLineMode = value
            Writelog("Set Current OnLineMode=" & mvarCCIMOnLineMode, eZLogType.TYPE_PROPERTY)
        End Set
    End Property

    Public Property SimServerCMD() As Boolean
        Get
            SimServerCMD = mvarSimServerCMD
        End Get
        Set(ByVal value As Boolean)
            mvarSimServerCMD = value
        End Set
    End Property

    'Public Property SECSXMLIniFullName() As String
    '    Get
    '        SECSXMLIniFullName = mvarSECSXMLIniFullName
    '    End Get
    '    Set(ByVal value As String)
    '        Writelog("File=" & value, clsEnumCtl.eZLogType.TYPE_PROPERTY)
    '        mvarSECSXMLIniFullName = value
    '        'MyForm.AxSecsWrapperX1.SXMLFile = mvarSECSXMLIniFullName
    '    End Set
    'End Property

    Public Sub HSMSInit()
        Dim starter As New ThreadStart(AddressOf HandleReceive)

        ReceiveThread = New Thread(starter)
        ReceiveThread.SetApartmentState(ApartmentState.STA)
        ReceiveThread.Start()

        MySEMI.InitialHSMS("SECS1")
    End Sub


    Private Sub HandleReceive()
        Static MyConnectStatus As prjSEMI.eConnectState
        Static sfConnectSuccess As Boolean
        While Not m_fStop
            If MySEMI.ReceiveCount > 0 Then
                PasserReceive(MySEMI.ReceiveQueue.Dequeue)
                Thread.Sleep(5)
            Else
                Thread.Sleep(20)
            End If
            If MyConnectStatus <> MySEMI.ConnectStatus Then
                MyConnectStatus = MySEMI.ConnectStatus

                'Writelog("Connect Status=" & MySEMI.ConnectStatus.ToString)

                If MySEMI.ConnectStatus = prjSEMI.eConnectState.Connected Then
                    If sfConnectSuccess <> True Then
                        sfConnectSuccess = True
                        RaiseEvent HOSTConnectStatus(True)
                    End If
                Else
                    If sfConnectSuccess <> False Then
                        sfConnectSuccess = False
                        RaiseEvent HOSTConnectStatus(False)
                    End If
                End If
            End If

        End While
    End Sub

    Private Sub PasserReceive(ByVal MsgStruct As prjSEMI.clsSECSMessage)

        Dim nSn As String = 0
        Dim nFn As String = 0
        Dim fDeviceIDChk As Boolean = False
        If MsgStruct.MessageHeader.StreamID = 0 And MsgStruct.MessageHeader.FunctionID = 0 Then Exit Sub
        If MsgStruct.MessageHeader.DeviceID = Me.HSMSDeviceID Then
            fDeviceIDChk = True
        Else

            S9F1_DeviceIDNoDefine(MsgStruct)
            Exit Sub
        End If

        If CCIMOnLineMode = eRemoteStatus.MODE_OFFLINE Then
            If MsgStruct.MessageID = "S2F26" Then
                S2F26_LoopBackCheckRequestReply_HOST(MsgStruct)
            ElseIf MsgStruct.MessageID = "S2F25" Then
                S2F25_LoopBackCheckRequest_HOST(MsgStruct)
            ElseIf MsgStruct.MessageID = "S1F66" Then
                S1F66_EQStatusChangeReportReply(MsgStruct)
            ElseIf MsgStruct.MessageID = "S2F18" Then
                S2F18_DateTimeRequestReply(MsgStruct)
            ElseIf MsgStruct.MessageID = "S1F90" Then
                S1F90_OnLineSummaryStatusReportReply(MsgStruct)
            Else
                SECSTransactionAbort(MsgStruct.MessageHeader.StreamID)
                Writelog("Off Line Mode Recevive S" & MsgStruct.MessageHeader.StreamID & "F" & MsgStruct.MessageHeader.FunctionID & " Transaction Abort!!!")
                RaiseEvent TransactionAbortRequest(MsgStruct.MessageHeader.StreamID)
            End If
        Else
            If MsgStruct.MessageBody.Count > 0 Then
                If MsgStruct.MessageBody(0).FormateCode = prjSEMI.eFormatCode.S9F11 Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            End If

            Select Case MsgStruct.MessageID
                Case "S1F1"
                    Call S1F1_HOSTConnectReq_HOST(MsgStruct)
                Case "S1F2"
                    Call S1F2_HOSTConnectReply_HOST(MsgStruct)
                Case "S1F5"
                    Call S1F5_EQStatusQuery(MsgStruct)
                Case "S1F66"
                    S1F66_EQStatusChangeReportReply(MsgStruct)
                Case "S1F68"
                    S1F68_LotStatusChangeReportReply(MsgStruct)
                Case "S1F74"
                    S1F74_CassetteLoadRequestOrCompleteReply(MsgStruct)
                Case "S1F76"
                    S1F76_CassetteUnloadRequestOrCompleteReply(MsgStruct)
                Case "S1F87"
                    S1F87_WIPDataQuery(MsgStruct)
                Case "S1F90"
                    S1F90_OnLineSummaryStatusReportReply(MsgStruct)
                Case "S1F98"
                    S1F98_RecipeModifyReportReply(MsgStruct)
                Case "S2F18"
                    S2F18_DateTimeRequestReply(MsgStruct)
                Case "S2F21"
                    S2F21_HOSTRemoteCommand(MsgStruct)
                Case "S2F25"
                    S2F25_LoopBackCheckRequest_HOST(MsgStruct)
                Case "S2F26"
                    S2F26_LoopBackCheckRequestReply_HOST(MsgStruct)
                Case "S2F41"
                    S2F41_HOSTCommandSend(MsgStruct)
                Case "S5F66"
                    S5F66_AlarmOccurredReleaseReply(MsgStruct)
                Case "S6F86"
                    S6F86_GlassRemoveReportReply(MsgStruct)
                Case "S6F88"
                    S6F88_GlassIDUnmatchReportReply(MsgStruct)
                Case "S6F92"
                    S6F92_GlassProcessReportReply(MsgStruct)
                Case "S7F3"
                    S7F3_HOSTRecipeParameterQuery(MsgStruct)
                Case "S7F65"
                    S7F65_LotProcessDataDownload(MsgStruct)
                Case "S7F67"
                    S7F67_RecipeLastModifyDateTimeRequest(MsgStruct)
                Case "S7F72"
                    S7F72_LotProcessDataRequestReply(MsgStruct)
                Case "S10F5"
                    S10F5_HOSTTerinalDisplay(MsgStruct)
                Case "S1F0"
                    S9F9_TransactionAbort(1)
                Case "S2F0"
                    S9F9_TransactionAbort(2)
                Case "S3F0"
                    S9F9_TransactionAbort(3)
                Case "S4F0"
                    S9F9_TransactionAbort(4)
                Case "S5F0"
                    S9F9_TransactionAbort(5)
                Case "S6F0"
                    S9F9_TransactionAbort(6)
                Case "S7F0"
                    S9F9_TransactionAbort(7)
                Case "S8F0"
                    S9F9_TransactionAbort(8)
                Case "S9F0"
                    S9F9_TransactionAbort(9)
                Case "S10F0"
                    S9F9_TransactionAbort(10)
                Case Else
                    If MsgStruct.MessageHeader.StreamID = 0 And MsgStruct.MessageHeader.FunctionID = 0 Then
                    Else
                        nSn = CInt(MsgStruct.MessageHeader.StreamID)
                        nFn = CInt(MsgStruct.MessageHeader.FunctionID)
                        Select Case nSn
                            Case 0, 1, 2, 5, 7, 9, 10
                                'Function ID undefine
                                S9F5_FunctionNoDefine(MsgStruct.MessageHeader)
                            Case Else
                                'Stream ID undefine
                                S9F3_StreamNoDefine(MsgStruct.MessageHeader)
                        End Select
                    End If

            End Select
        End If
    End Sub

    Private Sub S9F1_DeviceIDNoDefine(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Dim SnFn As New prjSEMI.clsSECSMessage(9, 1, False, MySEMI.Fn_IncSysByte)
        Dim vByte(9) As Byte
        Dim strByte(9) As String
        Dim nFor As Integer = 0

        Writelog("Device ID Unmatch==> HOST=" & MsgStruct.MessageHeader.DeviceID & " Client=" & Me.HSMSDeviceID)

        strByte = Split(MsgStruct.MessageHeader.HeaderByte, "-")
        For nFor = 0 To 9
            Select Case nFor
                Case 2, 3
                    If Len(strByte(nFor)) = 2 Then
                        vByte(nFor) = (Mid(strByte(nFor), 1, 1) * 16) + Mid(strByte(nFor), 2, 1)
                    Else
                        vByte(nFor) = strByte(nFor)
                    End If
                Case Else
                    vByte(nFor) = strByte(nFor)
            End Select
        Next

        SnFn.Fn_Add_Binary(vByte, 10, "MHEAD")
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub

    Private Sub S9F3_StreamNoDefine(ByVal MsgStruct As prjSEMI.clsSECSHead)
        Dim SnFn As New prjSEMI.clsSECSMessage(9, 3, False, MySEMI.Fn_IncSysByte)
        Dim vByte(9) As Byte
        Dim strByte(9) As String
        Dim nFor As Integer = 0
        Writelog("Stream No Define==>" & MsgStruct.StreamID)

        strByte = Split(MsgStruct.HeaderByte, "-")
        For nFor = 0 To 9
            Select Case nFor
                Case 2, 3
                    If Len(strByte(nFor)) = 2 Then
                        vByte(nFor) = (Mid(strByte(nFor), 1, 1) * 16) + Mid(strByte(nFor), 2, 1)
                    Else
                        vByte(nFor) = strByte(nFor)
                    End If
                Case Else
                    vByte(nFor) = strByte(nFor)
            End Select
        Next

        SnFn.Fn_Add_Binary(vByte, 10, "MHEAD")
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub

    Private Sub S9F5_FunctionNoDefine(ByVal MsgStruct As prjSEMI.clsSECSHead)
        Dim SnFn As New prjSEMI.clsSECSMessage(9, 5, False, MySEMI.Fn_IncSysByte)
        Dim vByte(9) As Byte
        Dim strByte(9) As String
        Dim nFor As Integer = 0
        Writelog("Function No Define==>" & MsgStruct.FunctionID)

        strByte = Split(MsgStruct.HeaderByte, "-")
        For nFor = 0 To 9
            Select Case nFor
                Case 2, 3
                    If Len(strByte(nFor)) = 2 Then
                        vByte(nFor) = (Mid(strByte(nFor), 1, 1) * 16) + Mid(strByte(nFor), 2, 1)
                    Else
                        vByte(nFor) = strByte(nFor)
                    End If
                Case Else
                    vByte(nFor) = strByte(nFor)
            End Select
        Next

        SnFn.Fn_Add_Binary(vByte, 10, "MHEAD")
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub

    Private Sub S9F7_DataFormatErr(ByVal MsgStruct As prjSEMI.clsSECSHead)
        RaiseEvent ErrIllegalDataS9F7(MsgStruct.StreamID, MsgStruct.FunctionID)
        Writelog("Find Invalidate Data Formate In S" & MsgStruct.StreamID & "F" & MsgStruct.FunctionID)

        Dim SnFn As New prjSEMI.clsSECSMessage(9, 7, False, MySEMI.Fn_IncSysByte)
        Dim vByte(9) As Byte
        Dim strByte(9) As String
        Dim nFor As Integer = 0

        strByte = Split(MsgStruct.HeaderByte, "-")
        For nFor = 0 To 9
            Select Case nFor
                Case 2, 3
                    If Len(strByte(nFor)) = 2 Then
                        vByte(nFor) = (Mid(strByte(nFor), 1, 1) * 16) + Mid(strByte(nFor), 2, 1)
                    Else
                        vByte(nFor) = strByte(nFor)
                    End If
                Case Else
                    vByte(nFor) = strByte(nFor)
            End Select
        Next

        SnFn.Fn_Add_Binary(vByte, 10, "MHEAD")
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub

    Private Sub S9F9_TransactionAbort(ByVal nStreamID As Integer, ByVal MsgStruct As prjSEMI.clsSECSHead)
        Writelog("Add S9F9 Transaction Abort==>S" & MsgStruct.StreamID & "F" & MsgStruct.FunctionID)
        Dim SnFn As New prjSEMI.clsSECSMessage(nStreamID, 0, False, MsgStruct.SystemByte)
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub

    Private Sub S9F9_TransactionAbort(ByVal nStreamID As Integer)
        Writelog("Add S9F9 Transaction Abort==>S" & nStreamID)
        Dim SnFn As New prjSEMI.clsSECSMessage(nStreamID, 0, False, MySEMI.Fn_IncSysByte)
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub

    Private Sub S9F11_DataTooLong(ByVal MsgStruct As prjSEMI.clsSECSHead)
        RaiseEvent ErrDataTooLongS9F11(MsgStruct.StreamID, MsgStruct.FunctionID)
        Writelog("Add S9F11 Data Too Long==> S " & MsgStruct.StreamID & "F" & MsgStruct.FunctionID, eZLogType.TYPE_EVENT)

        Dim SnFn As New prjSEMI.clsSECSMessage(9, 11, False, MySEMI.Fn_IncSysByte)
        Dim vByte(9) As Byte
        Dim strByte(9) As String
        Dim nFor As Integer = 0

        strByte = Split(MsgStruct.HeaderByte, "-")
        For nFor = 0 To 9
            Select Case nFor
                Case 2, 3
                    If Len(strByte(nFor)) = 2 Then
                        vByte(nFor) = (Mid(strByte(nFor), 1, 1) * 16) + Mid(strByte(nFor), 2, 1)
                    Else
                        vByte(nFor) = strByte(nFor)
                    End If
                Case Else
                    vByte(nFor) = strByte(nFor)
            End Select
        Next

        SnFn.Fn_Add_Binary(vByte, 10, "MHEAD")
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub

    Public Property HSMSHOSTIP() As String
        Get
            HSMSHOSTIP = mvarHOSTIP
        End Get
        Set(ByVal strIP As String)
            Writelog("Set HOST IP" & strIP)
            mvarHOSTIP = strIP
            MySEMI.zTCPIPAddress = strIP
        End Set
    End Property

    Public Property HSMSHOSTConnectType() As clsEnumCtl.eConnectType
        Get
            HSMSHOSTConnectType = mvarHOSTConnectType
        End Get
        Set(ByVal value As clsEnumCtl.eConnectType)
            mvarHOSTConnectType = value

            If value = clsEnumCtl.eConnectType.TYPE_ACTIVE Then
                MySEMI.zTCPMode = prjSEMI.eTCPMode.Active
            Else
                MySEMI.zTCPMode = prjSEMI.eTCPMode.Passive
            End If
        End Set
    End Property

    Public Property HSMSHOSTTCPPort() As Integer
        Get
            HSMSHOSTTCPPort = mvarHOSTTCPPort
        End Get
        Set(ByVal nPortID As Integer)
            Writelog("Set HOST Port=" & nPortID)
            mvarHOSTTCPPort = nPortID
            MySEMI.zTCPPort = nPortID
        End Set
    End Property

    Public Property HSMSDeviceID() As Integer
        Get
            HSMSDeviceID = mvarDeviceID
        End Get
        Set(ByVal value As Integer)
            Writelog("Set Device ID=" & value)
            mvarDeviceID = value
            MySEMI.zDeviceID = value
        End Set
    End Property

    Public Sub ConnectToHOST(ByVal fConnect As Boolean)
        If fConnect Then

            MySEMI.InitialHSMS("SECS1")
        Else
            MySEMI.Fn_Close()
        End If
    End Sub

    Public Property ConnetcMode() As Long
        Get
            ConnetcMode = mvarConnetcMode
        End Get
        Set(ByVal value As Long)
            mvarConnetcMode = value
        End Set
    End Property

    Public Property ConnectTimeout() As Integer
        Get
            ConnectTimeout = mvarConnectTimeout
        End Get
        Set(ByVal value As Integer)
            mvarConnectTimeout = value
        End Set
    End Property

    Public Property RST_LineName() As String
        Get
            RST_LineName = SpaceCTL(mvarLineName, LEN_LINEID)
        End Get
        Set(ByVal value As String)
            mvarLineName = SpaceCTL(value, LEN_LINEID)
        End Set
    End Property

    Public Property RST_LineToolName() As String
        Get
            RST_LineToolName = SpaceCTL(mvarLineToolName, LEN_TOOLID)
        End Get
        Set(ByVal value As String)
            mvarLineToolName = value
        End Set
    End Property

    Public Property HSMSLinkTestTimer() As Integer 'Set Link Test Retry Time
        Get
            HSMSLinkTestTimer = mvarLinkTestTimer
        End Get
        Set(ByVal value As Integer)
            mvarLinkTestTimer = value
            SEMILinkTestInterval = value
        End Set
    End Property

    Public Property HSMSRetryTimes() As Integer
        Get
            HSMSRetryTimes = mvarHSMSRetryTimes
        End Get
        Set(ByVal value As Integer)
            mvarHSMSRetryTimes = value            
        End Set
    End Property

#Region "HSMS Timeout Setting"
    Public Property HSMST3() As Integer
        Get
            HSMST3 = MySEMI.zT3
        End Get
        Set(ByVal value As Integer)
            MySEMI.zT3 = value
        End Set
    End Property

    Public Property HSMST5() As Integer
        Get
            HSMST5 = MySEMI.zT5
        End Get
        Set(ByVal value As Integer)
            MySEMI.zT5 = value
        End Set
    End Property

    Public Property HSMST6() As Integer
        Get
            HSMST6 = MySEMI.zT6
        End Get
        Set(ByVal value As Integer)
            MySEMI.zT6 = value
        End Set
    End Property

    Public Property HSMST7() As Integer
        Get
            HSMST7 = MySEMI.zT7
        End Get
        Set(ByVal value As Integer)
            MySEMI.zT7 = value
        End Set
    End Property

    Public Property HSMST8() As Integer
        Get
            HSMST8 = HSMST7 = MySEMI.zT8
        End Get
        Set(ByVal value As Integer)
            MySEMI.zT8 = value
        End Set
    End Property

    Private Property SEMILinkTestInterval() As Integer
        Get
            SEMILinkTestInterval = MySEMI.zLinkInterval
        End Get
        Set(ByVal value As Integer)
            MySEMI.zLinkInterval = value
        End Set
    End Property
#End Region


#End Region

#Region "Method"

    Public Sub ShowSim()
        'Dim MySimFor As New frmSnFnSim
        'MySimFor.ShowME(Me)
    End Sub

    Public Sub RST_TransactionAbort(ByVal nStreamID As Integer)
        S9F9_TransactionAbort(nStreamID)
    End Sub

    Public Sub RST_PortOpen()
        Try
            'Log Ini
            Writelog("Device No:" & Me.HSMSDeviceID)
            Writelog("HOST ID:" & Me.HSMSHOSTIP)
            Writelog("HOST Port:" & Me.HSMSHOSTTCPPort)
            Writelog("Entity Type:" & Me.HSMSHOSTConnectType)
            Writelog("TCP/IP Port Open......")

            HSMSInit()
        Catch ex As Exception
            WrigeExceptionLog("RST_PortOpen", ex.ToString)
        End Try

    End Sub

    Public Sub RST_PortCloase()
        Try
            Writelog("TCP/IP Port Close")
            MySEMI.Fn_Close()
        Catch ex As Exception
            WrigeExceptionLog("RST_PortCloase", ex.ToString)
        End Try
    End Sub

    'S1F1
    Public Sub RST_Connect()
        Try
            Call S1F1_HOSTConnect_RST()
        Catch ex As Exception
            WrigeExceptionLog("RST_Connect[S1F1]", ex.ToString)
        End Try
    End Sub
    'S1F2
    Public Sub RST_ReplyConnect()
        Try
            S1F2_HOSTConnectReply_RST()
            RemoveRecevieMsgs("S1F1")
        Catch ex As Exception
            WrigeExceptionLog("RST_ReplyConnect[S1F2]", ex.ToString)
        End Try
    End Sub
    'S1F6 SFCD=1
    Public Sub RST_ReportToolStatus(ByVal UnitStatus As clsUnitStructure)
        Try
            S1F6_EQStatusQueryReplySFCD1(UnitStatus)
            RemoveRecevieMsgs("S1F5")
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportToolStatus[S1F6 SFCD1]", ex.ToString)
        End Try
    End Sub
    'S1F6 SFCD=8/S1F89
    Public Sub RST_ReportWholeStatus(ByVal nReportType As clsEnumCtl.eRiportType, ByVal UnitStatus() As clsUnitStructure)
        Try
            If nReportType = clsEnumCtl.eRiportType.TYPE_S1F5_SFCD8 Then
                S1F6_EQStatusQueryReplySFCD8(UnitStatus)
                RemoveRecevieMsgs("S1F5")
            Else
                OnLineSummaryStatusReport(UnitStatus)
            End If
        Catch ex As Exception
            If nReportType = clsEnumCtl.eRiportType.TYPE_S1F5_SFCD8 Then
                WrigeExceptionLog("RST_ReportWholeStatus[S1F6 SFCD8]", ex.ToString)
            Else
                WrigeExceptionLog("RST_ReportWholeStatus[S1F89]", ex.ToString)
            End If
        End Try
    End Sub
    'S1F6 SFCD=7
    Public Sub RST_ReportEDS(ByVal nMCMode As eEQStatus, ByRef vEDS() As clsEDSStructure, Optional ByVal fReportEDS As Boolean = False)
        S1F6_EQStatusQueryReplySFCD7(nMCMode, vEDS, fReportEDS)
    End Sub

    'S1F65
    Public Sub RST_ReportMachineStatus(ByVal UnitStatus As clsUnitStructure)
        Try
            EQStatusChangReport(UnitStatus)
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportMachineStatus[S1F65]", ex.ToString)
        End Try
    End Sub
    ' S1F67
    Public Sub RST_ReportCSTStatus(ByVal nPortMode As Integer, ByVal LotInfo As clsLotStructure, ByVal Slots() As clsSlotStructure, ByVal nPortType As clsEnumCtl.ePortType, ByVal nCSTStatus As clsEnumCtl.eCassetteStatus)
        Try
            LotStatusChangeReport(nPortMode, nPortType, LotInfo, Slots, nCSTStatus)
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportCSTStatus[S1F67]", ex.ToString)
        End Try
    End Sub

    Public Sub RST_CSTProcessEndReport(ByVal nPortMode As Integer, ByVal LotInfo As clsLotStructure, ByVal Slots() As clsSlotStructure, ByVal nPortType As clsEnumCtl.ePortType, ByVal nCSTStatus As clsEnumCtl.eCassetteStatus, ByVal fCSTEmpty As Boolean)
        Try
            CSTProcessEndReport(nPortMode, nPortType, LotInfo, Slots, nCSTStatus, fCSTEmpty)
        Catch ex As Exception
            WrigeExceptionLog("RST_CSTProcessEndReport[S1F67]", ex.ToString)
        End Try
    End Sub
    'S1F73
    Public Sub RST_LoadStatus(ByVal nLoadState As clsEnumCtl.eLDSTA, ByVal nPortMode As clsEnumCtl.ePortMode, ByVal strCassetteID As String, ByVal nLoadPos As Integer, ByVal fAGVMode As Boolean, ByVal nPortCategory As clsEnumCtl.ePortCategory)
        Try
            CassetteLoadRequestOrLoadComplete(nLoadState, nPortMode, strCassetteID, nLoadPos, fAGVMode, nPortCategory)
        Catch ex As Exception
            WrigeExceptionLog("RST_LoadStatus[S1F73]", ex.ToString)
        End Try
    End Sub
    'S1F75
    Public Sub RST_UnloadStatus(ByVal nUnloadState As clsEnumCtl.eULDSTA, ByVal nPortMode As clsEnumCtl.ePortMode, ByVal strCassetteID As String, ByVal nUnloadPos As Integer, ByVal fAGVMode As Boolean, ByVal nPortCategory As clsEnumCtl.ePortCategory)
        Try
            CassetteUnloadRequestOrUnloadComplete(nUnloadState, nPortMode, strCassetteID, nUnloadPos, fAGVMode, nPortCategory)
        Catch ex As Exception
            WrigeExceptionLog("RST_UnloadStatus[S1F75]", ex.ToString)
        End Try
    End Sub
    'S1F88
    Public Sub RST_ReplyWIPData(ByVal WIPInfo() As clsWIPDataInTool)
        Try
            S1F88_WIPDataQueryReply(WIPInfo)
            RemoveRecevieMsgs("S1F87")
        Catch ex As Exception
            WrigeExceptionLog("RST_ReplyWIPData[S1F87]", ex.ToString)
        End Try
    End Sub
    'S1F97
    Public Sub RST_ReportRecipeChanged(ByVal strToolID As String, ByVal strPPID As String, ByVal strDateTime As String)
        Try
            S1F97_RecipeModifyReport(strToolID, strPPID, strDateTime)
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportRecipeChanged[S1F97]", ex.ToString)
        End Try
    End Sub
    'S2F17
    Public Sub RST_RequestDateTime()
        Try
            DateTimeRequest()
        Catch ex As Exception
            WrigeExceptionLog("RST_RequestDateTime[S2F17]", ex.ToString)
        End Try
    End Sub
    'S2F22
    Public Sub RST_ReplyRemoteCommand(ByVal nReplyCode As clsEnumCtl.eRemoteReplyCMD)
        Try
            RemoteCommandReply(nReplyCode)
            RemoveRecevieMsgs("S2F21")
        Catch ex As Exception
            WrigeExceptionLog("RST_ReplyRemoteCommand[S2F22]", ex.ToString)
        End Try
    End Sub
    'S2F25
    Public Sub RST_LoopBackTest()
        Try
            LoopBackCheckRequest_RST()
        Catch ex As Exception
            WrigeExceptionLog("RST_LoopBackTest[S2F25]", ex.ToString)
        End Try

    End Sub
    'S2F42
    Public Sub RST_EQRemoteCMD(ByVal nCMD As clsEnumCtl.eRemoteReplyCMD)
        Try
            HOSTCommandSendReply(nCMD)
            RemoveRecevieMsgs("S2F41")
        Catch ex As Exception
            WrigeExceptionLog("RST_EQRemoteCMD[S2F42]", ex.ToString)
        End Try
    End Sub
    'S5F65
    Public Sub RST_ReportAlarm(ByVal UnitStatus As clsUnitStructure, ByVal AlarmInfo As clsAlarmStructure, ByVal GlassAffect As Object, ByVal fReportGlassAffect As Boolean, ByVal strDateTimeInfo As String)
        Try
            AlarmOccurredRelease(UnitStatus, AlarmInfo, GlassAffect, fReportGlassAffect, strDateTimeInfo)
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportAlarm[S5F65]", ex.ToString)
        End Try

    End Sub
    'S6F65
    'Public Sub RST_ReportWorkAPD(ByVal strToolID As String, ByVal fAbort As Boolean, ByRef LotInfo As clsLotStructure, ByRef SlotInfo As clsSlotStructure, ByVal strPhysicalRecipe As String, ByVal aItemFormat() As clsItemFormat)

    'End Sub
    ''S6F69
    'Public Sub RST_ReportLotAPD(ByVal strToolID As String, ByVal strRecipe As String, ByVal aItemFormat() As clsItemFormat)

    'End Sub
    'S6F85
    Public Sub RST_GlassErase(ByVal strToolID As String, ByVal strGlassID As String)
        Try
            GlassRemoveReport(strToolID, strGlassID)
        Catch ex As Exception
            WrigeExceptionLog("RST_GlassErase[S6F85]", ex.ToString)
        End Try

    End Sub
    'S6F87
    Public Sub RST_ReportGxIDUnmatch(ByVal strToolID As String, ByVal strGlassIDHost As String, ByVal strGlassIDVCR As String)
        Try
            GlassIDUnmatchReport(strToolID, strGlassIDHost, strGlassIDVCR)
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportGxIDUnmatch[S6F87]", ex.ToString)
        End Try

    End Sub
    'S6F91
    Public Sub RST_ReportGlassRun(ByRef EQProcessInfo() As clsGxReport) 'ByVal strToolID As String, ByVal strGlassID As String, ByVal strPPID As String, ByVal strProcessStartTime As String, ByVal strProcessEndTime As String)
        Try
            GlassProcessReport(EQProcessInfo)
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportGlassRun[S6F91]", ex.ToString)
        End Try

    End Sub
    'S7F4
    Public Sub RST_RecipeParameterQueryReply(ByVal RecipeInfo As clsRecipeStructure)
        Try
            RecipeParameterQueryReply(RecipeInfo)
            RemoveRecevieMsgs("S7F3")
        Catch ex As Exception
            WrigeExceptionLog("RST_RecipeParameterQueryReply[S7F4]", ex.ToString)
        End Try
    End Sub
    'S7F66
    Public Sub RST_LotDataConfirm(ByVal nReplyCode As Integer)
        Try
            S7F66_LotProcessDataDownloadReply(nReplyCode)
            RemoveRecevieMsgs("S7F65")
        Catch ex As Exception
            WrigeExceptionLog("RST_LotDataConfirm[S7F66]", ex.ToString)
        End Try
    End Sub
    'S7F68
    Public Sub RST_RecipeLastModifyDateTimeReport(ByVal nACKC7 As Integer, ByVal strPPID As String, ByVal strDatetime As String)
        Try
            RecipeLastModifyDateTimeReport(nACKC7, strPPID, strDatetime)
            RemoveRecevieMsgs("S7F67")
        Catch ex As Exception
            WrigeExceptionLog("RST_RecipeLastModifyDateTimeReport[S7F68]", ex.ToString)
        End Try
    End Sub
    'S7F71
    Public Sub RST_LotDataRequest(ByVal nLoadPos As Integer, ByVal strCassetteID As String, ByVal strOperatorID As String, ByVal nPortMode As clsEnumCtl.ePortMode, ByVal nPortCategory As clsEnumCtl.ePortCategory)
        Try
            LotProcessDataRequest(nPortMode, nPortCategory, nLoadPos, strOperatorID, strCassetteID)
        Catch ex As Exception
            WrigeExceptionLog("RST_LotDataRequest[S7F71]", ex.ToString)
        End Try
    End Sub
    'S9F9
    Public Sub RST_ReportT3Timeout()
        'TransactionTimeout()
    End Sub
    'S9F13
    Public Sub RST_ReportConversationTimeout(ByVal nStream As Integer, ByVal nFunction As Integer)
        Try
            Writelog("Report Conversation Timeout--> S" & nStream & "F" & nFunction, eZLogType.TYPE_METHOD, True)
            ConversationTimeout(nStream, nFunction)
        Catch ex As Exception
            WrigeExceptionLog("RST_ReportConversationTimeout[S9F13]", ex.ToString)
        End Try
    End Sub
    'S10F1
    Public Sub RST_TerminaSend(ByVal strText As String)
        Dim nFor As Integer
        Dim strTemp As String = ""

        Try
            For nFor = 1 To Len(strText) Step LEN_S10F1
                If Len(strText) > LEN_S10F1 Then
                    strTemp = Mid(strText, nFor, LEN_S10F1)
                Else
                    strTemp = strText
                End If

                SendMsgToHOST(strTemp)
            Next nFor
        Catch ex As Exception
            WrigeExceptionLog("RST_TerminaSend[S10F1]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "SECS Send / Receive Structural"

#Region "Transaction Abort"
    Private Sub SECSTransactionAbort(ByVal nStreamID As Integer)
        Try
            Dim SnFn As New prjSEMI.clsSECSMessage(nStreamID, 0, False, MySEMI.Fn_IncSysByte)
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("SECSTransactionAbort[SECS S0F1]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S1F1 Parameter"
    Private mvarS1F1_Version As String
    Private mvarS1F1_MDLN As String

    Public Property S1F1_Version() As String
        Get
            If mvarS1F1_Version = "" Then
                mvarS1F1_Version = "1.0.0"
            End If
            S1F1_Version = mvarS1F1_Version
        End Get
        Set(ByVal value As String)
            mvarS1F1_Version = value
        End Set
    End Property

    Public Property S1F1_MDLN() As String
        Get
            If mvarS1F1_MDLN = "" Then
                mvarS1F1_MDLN = " RB"
            End If
            S1F1_MDLN = mvarS1F1_MDLN
        End Get
        Set(ByVal value As String)
            mvarS1F1_MDLN = value
        End Set
    End Property
#End Region

#Region "S1F1 HOST Connect"
    Private Sub S1F1_HOSTConnect_RST() 'S1F1
        Try
            Writelog("Call RST-S1F1")
            Dim SnFn As New prjSEMI.clsSECSMessage(1, 1, True, MySEMI.Fn_IncSysByte)
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("HOSTConnect_RST[SECS S1F1]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F2_HOSTConnectReply_RST() 'S1F2
        Try
            Writelog("Call RST-S1F2")
            Dim SnFn As New prjSEMI.clsSECSMessage(1, 2, False, MySysByte.S1F1)
            SnFn.Fn_Add_List(2, "NOD1")
            SnFn.Fn_Add_ASC(Me.S1F1_MDLN, 16, "MDLN")
            SnFn.Fn_Add_ASC(Me.S1F1_Version, 16, "SOFTREV")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("HOSTConnectReply_RST[SECS S1F2]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F2_HOSTConnectReply_HOST(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Writelog("Receive HOST-S1F2")
        MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

        RaiseEvent HOSTOnlineReply()
    End Sub

    Private Sub S1F1_HOSTConnectReq_HOST(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Writelog("Receive HOST S1F1")
        MySysByte.S1F1 = MsgStruct.MessageHeader.SystemByte
        MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

        RaiseEvent HOSTOnlineReq()

        Writelog("Auto Reply RST-S1F2")
        S1F2_HOSTConnectReply_RST()
    End Sub
#End Region

#Region "S1F5 EQ Status Query ==> OK"
    Private Sub S1F5_EQStatusQuery(ByVal MsgStruct As prjSEMI.clsSECSMessage) 'S1F5       
        Try
            Writelog("Receive HOST S1F5")

            MsgStruct.MessageBody(0).TagName = "NOD"
            MsgStruct.MessageBody(1).TagName = "SFCD"
            MsgStruct.MessageBody(2).TagName = "LINEID"
            MsgStruct.MessageBody(3).TagName = "TOOLID"
            MsgStruct.MessageBody(4).TagName = "DATETIME"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.BINARY)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(4) = MsgStruct.MessageBody(4).FormateMatch(prjSEMI.eFormatCode.ASCII)

            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_BINARY)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_LINEID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_TOOLID)
            afSize(4) = MsgStruct.MessageBody(4).ItemSizeMatch(LEN_DATETIME)

            For lngFor = 0 To MsgStruct.MessageBody.Count - 1
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '============================================================================================================

            MySysByte.S1F5 = MsgStruct.MessageHeader.SystemByte

            Dim lngSFCD As Long = MsgStruct.MessageBody(1).ItemValue
            Dim strLineID As String = MsgStruct.MessageBody(2).ItemValue
            Dim strToolID As String = MsgStruct.MessageBody(3).ItemValue
            Dim strDateTime As String = MsgStruct.MessageBody(4).ItemValue



            RaiseEvent EQStatusRequest(lngSFCD, strLineID, strToolID)
        Catch ex As Exception
            WrigeExceptionLog("EQStatusQuery[SECS S1F5]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F6_EQStatusQueryReplySFCD1(ByVal vUnit As clsUnitStructure) 'S1F6        
        Try
            Writelog("Send RST-S1F6 SFCD=1")
            Dim SnFn As New prjSEMI.clsSECSMessage(1, 6, False, MySysByte.S1F5)
            'SFCD Code = 1

            SnFn.Fn_Add_List(8, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
            SnFn.Fn_Add_ASC(vUnit.ToolID, 8, "TOOLID")
            SnFn.Fn_Add_ASC(vUnit.EQStatusByString, 1, "MCSTATUS")
            SnFn.Fn_Add_ASC(vUnit.EQSubStatusByString, 1, "MCSUBST")
            If vUnit.Alarm.AlarmID = 0 Then
                SnFn.Fn_Add_ASC(Space(8), 8, "AWUNITCD")
            Else
                SnFn.Fn_Add_ASC(vUnit.UnitNo & Right("0000000" & Hex(vUnit.Alarm.AlarmID), 7), 8, "AWUNITCD")
            End If
            SnFn.Fn_Add_ASC(vUnit.RemoteStatusByString, 1, "RMSTATUS")
            SnFn.Fn_Add_ASC(vUnit.CPPID, 32, "CPPID")
            SnFn.Fn_Add_ASC(SpaceCTL(vUnit.WIPCount, LEN_4), 4, "WIPCNT")

            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing


            ''Unit ...????==> No Unit In
            ''For nFor = 1 To 2
            ''    strSECSMsg.RootItem.ItemsByName("NOD1").Items(nFor - 1) = mSecendItem
            ''    mSecendItem = strSECSMsg.RootItem.ItemsByName("NOD1").Items(nFor - 1)


            ''    mSecendItem.ItemsByName("UNITNO").AsString = SpaceCTL(CStr(nFor), 2)
            ''    mSecendItem.ItemsByName("UNITSn").AsString = "1"
            ''Next

            'ReplyTransactionS1F5.Secondary = strSECSMsg
            'ChkSendMSGBuffer(eSendMSGType.TYPE_S, , ReplyTransactionS1F5)
            'strSECSMsg = Nothing
        Catch ex As Exception
            WrigeExceptionLog("EQStatusQueryReplySFCD1[SECS S1F6]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F6_EQStatusQueryReplySFCD8(ByVal vUnit() As clsUnitStructure) 'SFCD Code = 8
        Try
            Writelog("Send RST-S1F6 SFCD=8")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 6, False, MySysByte.S1F5)
            Dim nFor As Integer
            Dim nTotlaGx As Integer

            SnFn.Fn_Add_List(3, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")

            For nFor = 1 To UBound(vUnit)
                nTotlaGx = nTotlaGx + vUnit(nFor).WIPCount
            Next

            SnFn.Fn_Add_ASC(SpaceCTL(nTotlaGx, 4), 4, "TOLWIP")

            For nFor = 1 To UBound(vUnit)
                nTotlaGx = nTotlaGx + vUnit(nFor).WIPCount
            Next

            SnFn.Fn_Add_List(UBound(vUnit), "NOD1")

            For nFor = 1 To UBound(vUnit)
                SnFn.Fn_Add_List(7, "NOD2")
                SnFn.Fn_Add_ASC(SpaceCTL(vUnit(nFor).ToolID, LEN_TOOLID), 8, "TOOLID")
                SnFn.Fn_Add_ASC(vUnit(nFor).EQStatusByString, 1, "MCSTATUS")
                SnFn.Fn_Add_ASC(vUnit(nFor).EQSubStatusByString, 1, "MCSUBST")
                If vUnit(nFor).Alarm.AlarmID = 0 Then
                    SnFn.Fn_Add_ASC(Space(8), 8, "AWUNITCD")
                Else
                    SnFn.Fn_Add_ASC(vUnit(nFor).UnitNo & Right("0000000" & Hex(vUnit(nFor).Alarm.AlarmID), 7), 8, "AWUNITCD")
                End If

                SnFn.Fn_Add_ASC(vUnit(nFor).RemoteStatusByString, 1, "RMSTATUS")
                SnFn.Fn_Add_ASC(vUnit(nFor).CPPID, 32, "CPPID")
                SnFn.Fn_Add_ASC(SpaceCTL(vUnit(nFor).WIPCount, LEN_4), 4, "WIPCNT")
            Next nFor

            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("EQStatusQueryReplySFCD8[SECS S1F6]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F6_EQStatusQueryReplySFCD7(ByVal nMCStatus As eEQStatus, ByVal vEDSInfo() As clsEDSStructure, Optional ByVal fReportEDS As Boolean = False)
        Try
            Writelog("Send RST-S1F6 SFCD=7")
            Dim SnFn As New prjSEMI.clsSECSMessage(1, 6, False, MySysByte.S1F5)
            Dim nFor As Integer
            Dim strRemote As String = ""

            If nMCStatus = eEQStatus.EQ_DOWN Then
                strRemote = "D"
            ElseIf nMCStatus = eEQStatus.EQ_IDLE Then
                strRemote = "I"
            ElseIf nMCStatus = eEQStatus.EQ_RUNNING Then
                strRemote = "R"
            ElseIf nMCStatus = eEQStatus.EQ_SETUP Then
                strRemote = "S"
            ElseIf nMCStatus = eEQStatus.EQ_STOP Then
                strRemote = "P"
            End If

            If fReportEDS = False Then
                SnFn.Fn_Add_List(3, "NOD0")
                SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
                SnFn.Fn_Add_ASC(RST_LineToolName, 8, "TOOLID")
                SnFn.Fn_Add_ASC(strRemote, 1, "MCSTATUS")
            Else
                SnFn.Fn_Add_List(4, "NOD0")
                SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
                SnFn.Fn_Add_ASC(RST_LineToolName, 8, "TOOLID")
                SnFn.Fn_Add_ASC(strRemote, 1, "MCSTATUS")
                SnFn.Fn_Add_List(UBound(vEDSInfo), "NOD1")
                For nFor = 0 To UBound(vEDSInfo) - 1
                    SnFn.Fn_Add_List(2, "NOD2")
                    SnFn.Fn_Add_ASC(vEDSInfo(nFor).EDSName, 14, "DVNAME")
                    SnFn.Fn_Add_ASC(vEDSInfo(nFor).EDSValue, 14, "DVVAL")
                Next nFor
            End If
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("EQStatusQueryReplySFCD7[SECS S1F6]", ex.ToString)
        End Try
    End Sub

#End Region

#Region "S1F65 EQ Status Chang Report"
    Private Sub EQStatusChangReport(ByVal vUnit As clsUnitStructure) 'S1F65       
        Try
            Writelog("Send RST-S1F65")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 65, True, MySEMI.Fn_IncSysByte)
            Dim strStatusCode As String

            SnFn.Fn_Add_List(4, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
            SnFn.Fn_Add_ASC(SpaceCTL(vUnit.ToolID, LEN_TOOLID), 8, "TOOLID")
            SnFn.Fn_Add_ASC(GetNow(), 14, "DATETIME")

            strStatusCode = vUnit.RemoteStatusByString & vUnit.EQStatusByString & vUnit.EQSubStatusByString & vUnit.ProcessModeByString
            SnFn.Fn_Add_ASC(strStatusCode, 4, "STATUS")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
            'ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
        Catch ex As Exception
            WrigeExceptionLog("EQStatusChangReport[SECS S1F65]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F66_EQStatusChangeReportReply(ByVal MsgStruct As prjSEMI.clsSECSMessage) 'S1F66        
        Try
            Writelog("Receive HOST S1F66")

            MsgStruct.MessageBody(0).TagName = "RTNCD"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_RTNCD7) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If
            '===================================================================================

            Dim strRetCode As String = MsgStruct.MessageBody(0).ItemValue
            Dim nRetCode As Integer

            If strRetCode = "0000000" Then
                nRetCode = 0
            Else
                nRetCode = 1
            End If

            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S1F66, nRetCode)
        Catch ex As Exception
            WrigeExceptionLog("EQStatusChangeReportReply[SECS S1F66]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S1F67 Lot Status Change Report"
    Public Sub LotStatusChangeReport(ByVal nPortMode As Integer, ByVal nPortType As clsEnumCtl.ePortType, ByVal vLotInfo As clsLotStructure, ByVal aSlotInfo() As clsSlotStructure, ByVal nCSTStatus As clsEnumCtl.eCassetteStatus) 'S1F67        

        Try

            Writelog("Send RST-S1F67 Lot Status Change Report")



            Dim SnFn As New prjSEMI.clsSECSMessage(1, 67, True, MySEMI.Fn_IncSysByte)



            Dim nFor As Integer

            Dim fIsCSTEmpty As Boolean = True

            Dim nPortPos(0) As Byte

            Dim nTotalSlotInCST As Integer



            For nFor = 1 To UBound(aSlotInfo)

                If Trim(aSlotInfo(nFor).GlassID) <> "" Then

                    fIsCSTEmpty = False

                    Exit For

                End If

            Next

            nPortPos(0) = vLotInfo.PortPosition



            'If fIsCSTEmpty Then

            '    SnFn.Fn_Add_List(12, "NOD0")

            'Else

            SnFn.Fn_Add_List(13, "NOD0")

            'End If



            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")

            SnFn.Fn_Add_ASC(RST_LineToolName, 8, "TOOLID")

            SnFn.Fn_Add_ASC(GetNow(), 14, "DATETIME")

            SnFn.Fn_Add_ASC(vLotInfo.ProductCategoryByString, 4, "PRODCATE")

            SnFn.Fn_Add_Binary(nPortPos, 1, "PORTNO")

            SnFn.Fn_Add_ASC(nPortMode, 1, "PMODE")

            SnFn.Fn_Add_ASC(vLotInfo.CassetteID, 6, "CASID")

            SnFn.Fn_Add_ASC(vLotInfo.CassetteStatusByString, 1, "CASSTATUS")

            SnFn.Fn_Add_ASC(vLotInfo.OperatorID, 20, "OPID")

            SnFn.Fn_Add_ASC(vLotInfo.ProcEndCodeByString, 4, "ENDCD")

            SnFn.Fn_Add_ASC(PortCategoryToString(nPortType), 1, "PORTTYPE")

            SnFn.Fn_Add_ASC(vLotInfo.RecipeName, 32, "PPID")



            If Not fIsCSTEmpty Then

                For nFor = 1 To UBound(aSlotInfo)

                    If Trim(aSlotInfo(nFor).GlassID) <> "" Then nTotalSlotInCST = nTotalSlotInCST + 1

                Next

                SnFn.Fn_Add_List(nTotalSlotInCST, "NOD1")

                For nFor = 1 To UBound(aSlotInfo)

                    If Trim(aSlotInfo(nFor).GlassID) <> "" Then

                        SnFn.Fn_Add_List(12, "NOD2")

                        SnFn.Fn_Add_ASC(Right("0" & CStr(aSlotInfo(nFor).SlotNo), 2), 2, "SLOTNO")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).GlassID, 12, "GLASSID")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).GlassGradeByString, 1, "GGRADE")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCGradeByString, 1, "DGRADE")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCGradeResultByString, 1, "RDGRADE")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).PSHGroup, 3, "PGROUP")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).ProcessToolID, 8, "PTOOLID")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCToolID, 8, "DMQCTOLID")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).ChipGradeByString, 72, "CHIPGRADE")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).ReworkByString, 1, "RWKFLAG")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).ScrapByString, 1, "SCRPFLAG")

                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).FIRemarkByString, 1, "FIRMFLAG")

                    End If

                Next nFor



                'SnFn.Fn_Add_List(UBound(aSlotInfo), "NOD1")

                'For nFor = 1 To UBound(aSlotInfo)

                '    SnFn.Fn_Add_List(12, "NOD2")

                '    SnFn.Fn_Add_ASC(Right("0" & CStr(aSlotInfo(nFor).SlotNo), 2), 2, "SLOTNO")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).GlassID, 12, "GLASSID")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).GlassGradeByString, 1, "GGRADE")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCGradeByString, 1, "DGRADE")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCGradeResultByString, 1, "RDGRADE")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).PSHGroup, 3, "PGROUP")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).ProcessToolID, 8, "PTOOLID")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCToolID, 8, "DMQCTOLID")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).ChipGradeByString, 72, "CHIPGRADE")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).ReworkByString, 1, "RWKFLAG")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).ScrapByString, 1, "SCRPFLAG")

                '    SnFn.Fn_Add_ASC(aSlotInfo(nFor).FIRemarkByString, 1, "FIRMFLAG")

                'Next nFor

            Else

                SnFn.Fn_Add_List(0, "NOD3")

            End If



            MySEMI.Fn_AddSendMessage(SnFn)

            SnFn = Nothing

        Catch ex As Exception

            WrigeExceptionLog("LotStatusChangeReport[SECS S1F67]", ex.ToString)

        End Try

    End Sub

    Public Sub CSTProcessEndReport(ByVal nPortMode As Integer, ByVal nPortType As clsEnumCtl.ePortType, ByVal vLotInfo As clsLotStructure, ByVal aSlotInfo() As clsSlotStructure, ByVal nCSTStatus As clsEnumCtl.eCassetteStatus, ByVal fCSTEmpty As Boolean) 'S1F67        
        Try
            Dim nTotalSlotInCST As Integer = 0
            Writelog("Send RST-S1F67 CST Process END Report")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 67, True, MySEMI.Fn_IncSysByte)
            Dim fIsCSTEmpty As Boolean = True
            Dim nPortPos(0) As Byte
            Dim nFor As Integer

            For nFor = 1 To UBound(aSlotInfo)
                If Trim(aSlotInfo(nFor).GlassID) <> "" Then
                    fIsCSTEmpty = False
                    Exit For
                End If
            Next

            For nFor = 1 To UBound(aSlotInfo)
                If Trim(aSlotInfo(nFor).GlassID) <> "" Then
                    fIsCSTEmpty = False
                    Exit For
                End If
            Next
            nPortPos(0) = vLotInfo.PortPosition

            'If fIsCSTEmpty Then
            '    SnFn.Fn_Add_List(12, "NOD0")
            'Else
            SnFn.Fn_Add_List(13, "NOD0")
            'End If

            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
            SnFn.Fn_Add_ASC(RST_LineToolName, 8, "TOOLID")
            SnFn.Fn_Add_ASC(GetNow(), 14, "DATETIME")
            SnFn.Fn_Add_ASC(vLotInfo.ProductCategoryByString, 4, "PRODCATE")
            SnFn.Fn_Add_Binary(nPortPos, 1, "PORTNO")
            SnFn.Fn_Add_ASC(nPortMode, 1, "PMODE")
            SnFn.Fn_Add_ASC(vLotInfo.CassetteID, 6, "CASID")
            SnFn.Fn_Add_ASC(vLotInfo.CassetteStatusByString, 1, "CASSTATUS")
            SnFn.Fn_Add_ASC(vLotInfo.OperatorID, 20, "OPID")
            SnFn.Fn_Add_ASC(vLotInfo.ProcEndCodeByString, 4, "ENDCD")
            SnFn.Fn_Add_ASC(PortCategoryToString(nPortType), 1, "PORTTYPE")
            SnFn.Fn_Add_ASC(vLotInfo.RecipeName, 32, "PPID")

            If Not fIsCSTEmpty Then
                For nFor = 1 To UBound(aSlotInfo)

                    If Trim(aSlotInfo(nFor).GlassID) <> "" Then nTotalSlotInCST = nTotalSlotInCST + 1

                Next

                SnFn.Fn_Add_List(nTotalSlotInCST, "NOD1")
                For nFor = 1 To UBound(aSlotInfo)

                    If Trim(aSlotInfo(nFor).GlassID) <> "" Then
                        SnFn.Fn_Add_List(12, "NOD2")
                        SnFn.Fn_Add_ASC(Right("0" & CStr(aSlotInfo(nFor).SlotNo), 2), 2, "SLOTNO")
                        SnFn.Fn_Add_ASC(aSlotInfo(nFor).GlassID, 12, "GLASSID")
                        If aSlotInfo(nFor).IsGlassProecssed Then
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).GlassGradeByString, 1, "GGRADE")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCGradeByString, 1, "DGRADE")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCGradeResultByString, 1, "RDGRADE")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).PSHGroup, 3, "PGROUP")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).ProcessToolID, 8, "PTOOLID")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).DMQCToolID, 8, "DMQCTOLID")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).ChipGradeByString, 72, "CHIPGRADE")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).ReworkByString, 1, "RWKFLAG")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).ScrapByString, 1, "SCRPFLAG")
                            SnFn.Fn_Add_ASC(aSlotInfo(nFor).FIRemarkByString, 1, "FIRMFLAG")
                        Else
                            SnFn.Fn_Add_ASC(Space(1), 1, "GGRADE")
                            SnFn.Fn_Add_ASC(Space(1), 1, "DGRADE")
                            SnFn.Fn_Add_ASC(Space(1), 1, "RDGRADE")
                            SnFn.Fn_Add_ASC(Space(1), 3, "PGROUP")
                            SnFn.Fn_Add_ASC(Space(8), 8, "PTOOLID")
                            SnFn.Fn_Add_ASC(Space(1), 8, "DMQCTOLID")
                            SnFn.Fn_Add_ASC(Space(72), 72, "CHIPGRADE")
                            SnFn.Fn_Add_ASC(Space(1), 1, "RWKFLAG")
                            SnFn.Fn_Add_ASC(Space(1), 1, "SCRPFLAG")
                            SnFn.Fn_Add_ASC(Space(1), 1, "FIRMFLAG")
                        End If
                    End If
                Next nFor
            Else
                SnFn.Fn_Add_List(0, "NOD3")
            End If

            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
            '            ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
        Catch ex As Exception
            WrigeExceptionLog("LotStatusChangeReport[SECS S1F67]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F68_LotStatusChangeReportReply(ByVal MsgStruct As prjSEMI.clsSECSMessage) 'S1F68        
        Try
            Writelog("Receive HOST-S1F68")

            MsgStruct.MessageBody(0).TagName = "NOD0"
            MsgStruct.MessageBody(1).TagName = "LINEID"
            MsgStruct.MessageBody(2).TagName = "TOOLID"
            MsgStruct.MessageBody(3).TagName = "PORTNO"
            MsgStruct.MessageBody(4).TagName = "RTNCD"
            MsgStruct.MessageBody(5).TagName = "NGGLASSID"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)


            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.BINARY)
            afFormate(4) = MsgStruct.MessageBody(4).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(5) = MsgStruct.MessageBody(5).FormateMatch(prjSEMI.eFormatCode.ASCII)

            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_LINEID)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_TOOLID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_BINARY)
            afSize(4) = MsgStruct.MessageBody(4).ItemSizeMatch(LEN_RTNCD7)
            afSize(5) = MsgStruct.MessageBody(5).ItemSizeMatch(LEN_GXID)

            For lngFor = 0 To MsgStruct.MessageBody.Count
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next

            '============================================================================================================
            Dim strLineID As String = MsgStruct.MessageBody(1).ItemValue
            Dim strToolID As String = MsgStruct.MessageBody(2).ItemValue
            Dim nPortNo As Integer = MsgStruct.MessageBody(3).ItemValue
            Dim strRTNCD As String = MsgStruct.MessageBody(4).ItemValue
            Dim strNGFlag As String = MsgStruct.MessageBody(5).ItemValue


            If strRTNCD = "0000000" Then
                strRTNCD = 0
            Else
                strRTNCD = 1
            End If
            RaiseEvent LotStatusChangeReply(nPortNo, CInt(strRTNCD), strNGFlag)
        Catch ex As Exception
            WrigeExceptionLog("LotStatusChangeReportReply[SECS S1F68]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S1F73 74 75 76 CST Load Unload Request / Complete"
    'S1F73
    Private Sub CassetteLoadRequestOrLoadComplete(ByVal nLoadState As clsEnumCtl.eLDSTA, ByVal nPortMode As Integer, ByVal strCassetteID As String, ByVal nLoadPos As Integer, ByVal fAGVMode As Boolean, ByVal nPortCategory As clsEnumCtl.ePortCategory) 'S1F73         
        Try
            Writelog("Send RST-S1F73 CST LReq/LComp")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 73, True, MySEMI.Fn_IncSysByte)
            Dim btyLoadPos(0) As Byte
            btyLoadPos(0) = nLoadPos

            SnFn.Fn_Add_List(9, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
            SnFn.Fn_Add_ASC(RST_LineToolName, 8, "TOOLID")
            SnFn.Fn_Add_ASC(GetNow(), 14, "DATETIME")
            SnFn.Fn_Add_ASC(SpaceCTL(strCassetteID, LEN_CSTID), 6, "CASID")
            SnFn.Fn_Add_ASC("8", 1, "AGVMODE")
            SnFn.Fn_Add_ASC(nLoadState, 1, "LDSTA")
            SnFn.Fn_Add_ASC(nPortMode, 1, "PMODE")
            SnFn.Fn_Add_ASC(PortCategoryToString(nPortCategory), 1, "PORTTYPE")
            SnFn.Fn_Add_Binary(btyLoadPos, 1, "LDPOS")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
            ' ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
        Catch ex As Exception
            WrigeExceptionLog("CassetteLoadRequestOrLoadComplete[SECS S1F73]", ex.ToString)
        End Try
    End Sub
    'S1F75
    Private Sub CassetteUnloadRequestOrUnloadComplete(ByVal nUnloadState As clsEnumCtl.eULDSTA, ByVal nPortMode As Integer, ByVal strCassetteID As String, ByVal nUnloadPos As Integer, ByVal fAGVMode As Boolean, ByVal nPortCategory As clsEnumCtl.ePortCategory) 'S1F75
        Try
            Writelog("Send RST-S1F75 CST ULReq/ULComp")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 75, True, MySEMI.Fn_IncSysByte)
            Dim btyULoadPos(0) As Byte
            btyULoadPos(0) = nUnloadPos

            SnFn.Fn_Add_List(9, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
            SnFn.Fn_Add_ASC(RST_LineToolName, 8, "TOOLID")
            SnFn.Fn_Add_ASC(GetNow(), 14, "DATETIME")
            SnFn.Fn_Add_ASC(SpaceCTL(strCassetteID, LEN_CSTID), 6, "CASID")
            SnFn.Fn_Add_ASC("8", 1, "AGVMODE")
            SnFn.Fn_Add_ASC(nUnloadState, 1, "ULDSTA")
            SnFn.Fn_Add_ASC(nPortMode, 1, "PMODE")
            SnFn.Fn_Add_ASC(PortCategoryToString(nPortCategory), 1, "PORTTYPE")
            SnFn.Fn_Add_Binary(btyULoadPos, 1, "ULDPOS")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
            ' ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
        Catch ex As Exception
            WrigeExceptionLog("CassetteUnloadRequestOrUnloadComplete[SECS S1F75]", ex.ToString)
        End Try
    End Sub
    'S1F74
    Private Sub S1F74_CassetteLoadRequestOrCompleteReply(ByVal MsgStruct As prjSEMI.clsSECSMessage) 'S1F74         
        Try
            Writelog("Receive HOST-S1F74")

            MsgStruct.MessageBody(0).TagName = "RTNCD"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If Not MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_RTNCD7) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If

            '============================================================================================================

            Dim strRetCode As String = MsgStruct.MessageBody(0).ItemValue
            Dim nRetCode As Integer

            If strRetCode <> "0000000" Then
                nRetCode = 1
            Else
                nRetCode = 0
            End If


            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S1F74, nRetCode)
        Catch ex As Exception
            WrigeExceptionLog("CassetteLoadRequestOrCompleteReply[SECS S1F74]", ex.ToString)
        End Try
    End Sub
    'S1F76
    Private Sub S1F76_CassetteUnloadRequestOrCompleteReply(ByVal MsgStruct As prjSEMI.clsSECSMessage) 'S1F76 
        Try
            Writelog("Receive HOST-S1F76")

            MsgStruct.MessageBody(0).TagName = "RTNCD"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If Not MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If
            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_RTNCD7) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If

            '=======================================================================================

            Dim strRetCode As String = MsgStruct.MessageBody(0).ItemValue
            Dim nRetCode As Integer

            If strRetCode <> "0000000" Then
                nRetCode = 1
            Else
                nRetCode = 0
            End If

            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S1F76, nRetCode)
        Catch ex As Exception
            WrigeExceptionLog("CassetteUnloadRequestOrCompleteReply[SECS S1F76]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S1F87 WIPDataQuery"
    Private Sub S1F87_WIPDataQuery(ByVal MsgStruct As prjSEMI.clsSECSMessage) 'S1F87        
        Try
            Writelog("Receive HOST S1F87 WIP Data Query")

            MsgStruct.MessageBody(0).TagName = "NOD0"
            MsgStruct.MessageBody(1).TagName = "LINEID"
            MsgStruct.MessageBody(2).TagName = "DATETIME"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)

            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_LINEID)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_DATETIME)

            For lngFor = 0 To MsgStruct.MessageBody.Count - 1
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '=========================================================================================================

            MySysByte.S1F87 = MsgStruct.MessageHeader.SystemByte

            Dim strLineID As String = MsgStruct.MessageBody(1).ItemValue
            Dim strDatetime As String = MsgStruct.MessageBody(2).ItemValue

            RaiseEvent WIPDataRequest()
        Catch ex As Exception
            WrigeExceptionLog("WIPDataQuery[SECS S1F87]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F88_WIPDataQueryReply(ByVal WIPData() As clsWIPDataInTool)
        Try
            Writelog("Send RST-S1F88 WIP Data Query Reply")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 88, False, MySysByte.S1F87)
            Dim tempWIPData As clsWIPStructure
            Dim fRSTWithGx As Boolean = False

            Dim nFor As Integer
            Dim nLoop As Integer

            For nFor = 1 To UBound(WIPData)
                If WIPData(nFor).ToolWithGx Then
                    fRSTWithGx = True
                    Exit For
                End If
            Next

            If Not fRSTWithGx Then
                SnFn.Fn_Add_List(2, "NOD0")
                SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
                SnFn.Fn_Add_List(0, "NOD1")
            Else
                SnFn.Fn_Add_List(2, "NOD0")
                SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
                SnFn.Fn_Add_List(UBound(WIPData), "NOD1")
                For nFor = 1 To UBound(WIPData)
                    SnFn.Fn_Add_List(2)
                    SnFn.Fn_Add_ASC(WIPData(nFor).ToolID, 8, "TOOLID")
                    SnFn.Fn_Add_List(WIPData(nFor).WIPItemCount, "NOD2")
                    For nLoop = 1 To WIPData(nFor).WIPItemCount
                        SnFn.Fn_Add_List(4, "NOD3")

                        tempWIPData = WIPData(nFor).WIPItem(nLoop)
                        SnFn.Fn_Add_ASC(SpaceCTL(tempWIPData.HOSTGxID, LEN_GXID), 12, "HGLASSID")
                        SnFn.Fn_Add_ASC(SpaceCTL(tempWIPData.VCRGxID, LEN_GXID), 12, "RGLASSID")
                        SnFn.Fn_Add_ASC(tempWIPData.GxGradeByString, 1, "GGRADE")
                        SnFn.Fn_Add_ASC(tempWIPData.DMQCGradeByString, 1, "DGRADE")
                    Next nLoop
                Next nFor

            End If
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
            'ChkSendMSGBuffer(eSendMSGType.TYPE_S, , ReplyTransactionS1F87)
        Catch ex As Exception
            WrigeExceptionLog("WIPDataQueryReply[SECS S1F88]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S1F89 OnLineSummaryStatusReport"
    Private Sub OnLineSummaryStatusReport(ByVal MyUnitStatus() As clsUnitStructure) 'S1F89        
        Try
            Writelog("Send S1F89 On Line Summary Status Report")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 89, True, MySEMI.Fn_IncSysByte)
            Dim nFor As Integer
            Dim nTotlaGx As Integer

            For nFor = 1 To UBound(MyUnitStatus)
                nTotlaGx = nTotlaGx + MyUnitStatus(nFor).WIPCount
            Next

            SnFn.Fn_Add_List(6, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
            SnFn.Fn_Add_ASC(GetNow(), 14, "DATETIME")
            SnFn.Fn_Add_ASC(MyUnitStatus(1).RemoteStatusByString, 1, "RMSTATUS")
            SnFn.Fn_Add_ASC(MyUnitStatus(1).CPPID, 32, "PPID")
            SnFn.Fn_Add_ASC(SpaceCTL(nTotlaGx, 4), 4, "WIPCNT")
            SnFn.Fn_Add_List(UBound(MyUnitStatus), "NOD1")
            For nFor = 1 To UBound(MyUnitStatus)
                SnFn.Fn_Add_List(4, "NOD2")
                SnFn.Fn_Add_ASC(MyUnitStatus(nFor).ToolID, 8, "TOOLID")
                SnFn.Fn_Add_ASC(MyUnitStatus(nFor).EQStatusByString, 1, "MCSTATUS")
                SnFn.Fn_Add_ASC(MyUnitStatus(nFor).EQSubStatusByString, 1, "MCSUBST")
                SnFn.Fn_Add_ASC("0" & Right("0000000" & Hex(MyUnitStatus(nFor).Alarm.AlarmID), 7), 8, "AWUNITCD")
            Next nFor

            ' ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
            MySEMI.Fn_AddSendMessage(SnFn)
        Catch ex As Exception
            WrigeExceptionLog("OnLineSummaryStatusReport[SECS S1F89]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F90_OnLineSummaryStatusReportReply(ByVal MsgStruct As prjSEMI.clsSECSMessage) 'S1F90        
        Try
            Writelog("Receive HOST-S1F90")

            MsgStruct.MessageBody(0).TagName = "RTNCD"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(7) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If
            '=================================================================

            Dim strRetCode As String = MsgStruct.MessageBody(0).ItemValue
            Dim nRetCode As Integer

            If strRetCode = "0000000" Then
                nRetCode = 0
            ElseIf strRetCode = "0000004" Then
                nRetCode = 4
            Else
                nRetCode = 255
            End If


            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S1F90, nRetCode)
        Catch ex As Exception
            WrigeExceptionLog("OnLineSummaryStatusReportReply[SECS S1F90]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S1F97 Recipe Modify Report"
    Private Sub S1F97_RecipeModifyReport(ByVal strToolID As String, ByVal strPPID As String, ByVal strDateTime As String)
        Try
            Writelog("Send RST-S1F97 Recipe Modify Report")

            Dim SnFn As New prjSEMI.clsSECSMessage(1, 97, True, MySEMI.Fn_IncSysByte)
            SnFn.Fn_Add_List(5, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, 8, "LINEID")
            SnFn.Fn_Add_ASC(strToolID, 8, "TOOLID")
            SnFn.Fn_Add_ASC(strDateTime, 14, "DATETIME")
            SnFn.Fn_Add_ASC(Space(2), 2, "SUBUNITNO")
            SnFn.Fn_Add_ASC(SpaceCTL(strPPID, LEN_PPID), 32, "PPID")
            MySEMI.Fn_AddSendMessage(SnFn)

            'ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("RecipeModifyReport[SECS S1F97]", ex.ToString)
        End Try
    End Sub

    Private Sub S1F98_RecipeModifyReportReply(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST S1F98")

            MsgStruct.MessageBody(0).TagName = "ACKC1"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.BINARY) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_BINARY) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If
            '=================================================================

            Dim nRetCode As Integer = MsgStruct.MessageBody(0).ItemValue


            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S1F98, nRetCode)
        Catch ex As Exception
            WrigeExceptionLog("RecipeModifyReportReply[SECS S1F98]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S2F17 Date and Time Request"
    Private Sub DateTimeRequest()
        Try
            Writelog("Send RST-S2F17 Date Time Request")

            Dim SnFn As New prjSEMI.clsSECSMessage(2, 17, True, MySEMI.Fn_IncSysByte)
            MySEMI.Fn_AddSendMessage(SnFn)

            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("DateTimeRequest[SECS S2F17]", ex.ToString)
        End Try
    End Sub

    Private Sub S2F18_DateTimeRequestReply(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S2F18")

            MsgStruct.MessageBody(0).TagName = "DATETIME"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_DATETIME) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If

            Dim strDatetime As String = MsgStruct.MessageBody(0).ItemValue

            RaiseEvent SYNCDateTime(strDatetime)
        Catch ex As Exception
            WrigeExceptionLog("DateTimeRequestReply[SECS S2F18]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S2F21 Remote Command"
    Private Sub S2F21_HOSTRemoteCommand(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S2F21")

            MySysByte.S2F21 = MsgStruct.MessageHeader.SystemByte
            MsgStruct.MessageBody(1).TagName = "LINEID"
            MsgStruct.MessageBody(2).TagName = "TOOLID"
            MsgStruct.MessageBody(3).TagName = "CASID"
            MsgStruct.MessageBody(4).TagName = "LDPOS"
            MsgStruct.MessageBody(5).TagName = "RCMD"
            MsgStruct.MessageBody(6).TagName = "RCOMMENT"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(4) = MsgStruct.MessageBody(4).FormateMatch(prjSEMI.eFormatCode.BINARY)
            afFormate(5) = MsgStruct.MessageBody(5).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(6) = MsgStruct.MessageBody(6).FormateMatch(prjSEMI.eFormatCode.ASCII)

            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_LINEID)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_TOOLID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_CSTID)
            afSize(4) = MsgStruct.MessageBody(4).ItemSizeMatch(LEN_BINARY)
            afSize(5) = MsgStruct.MessageBody(5).ItemSizeMatch(10)
            afSize(6) = MsgStruct.MessageBody(6).ItemSizeMatch(40)

            For lngFor = 0 To MsgStruct.MessageBody.Count
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '======================================================================================

            Dim strLineID As String = MsgStruct.MessageBody(1).ItemValue
            Dim strToolID As String = MsgStruct.MessageBody(2).ItemValue
            Dim strCSTID As String = MsgStruct.MessageBody(3).ItemValue
            Dim nLoaderPos As Integer = MsgStruct.MessageBody(4).ItemValue
            Dim strREMD As String = MsgStruct.MessageBody(5).ItemValue
            Dim strComment As String = MsgStruct.MessageBody(6).ItemValue

            RaiseEvent RemoteCommand(strREMD, nLoaderPos, strCSTID, strComment)
        Catch ex As Exception
            WrigeExceptionLog("HOSTRemoteCommand[SECS S2F21]", ex.ToString)
        End Try
    End Sub

    Private Sub RemoteCommandReply(ByVal nReplyCode As clsEnumCtl.eRemoteReplyCMD)
        Try
            Writelog("Send RST-S2F22 Remote CMD Reply")

            Dim SnFn As New prjSEMI.clsSECSMessage(2, 22, False, MySysByte.S2F21)
            Dim nFor As Integer
            Dim vByte(0) As Byte

            For nFor% = nReplyCode To nReplyCode
                vByte(0) = nFor%
            Next
            SnFn.Fn_Add_Binary(vByte, 1, "CMDA")
            MySEMI.Fn_AddSendMessage(SnFn)
            ' ChkSendMSGBuffer(eSendMSGType.TYPE_S, , ReplyTransactionS2F21)

            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("RemoteCommandReply[SECS S2F22]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S2F25 Loop Back Check Request "
    'Private Sub S2F25_LoopBackCheckRequest_HOST(ByVal MsgStruct As prjSEMI.clsSECSMessage)
    '    Try
    '        MsgStruct.MessageBody(0).TagName = "ABS"
    '        MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

    '        If Not MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.BINARY) Then
    '            S9F7_DataFormatErr(MsgStruct.MessageHeader)
    '            Exit Sub
    '        End If
    '        If MsgStruct.MessageBody(0).ItemSizeMatch(10) = False Then
    '            S9F11_DataTooLong(MsgStruct.MessageHeader)
    '            Exit Sub
    '        End If
    '        '==========================================================================

    '        MySysByte.S2F25 = MsgStruct.MessageHeader.SystemByte

    '        Dim vByteVal(9) As Byte
    '        Dim nFor As Integer
    '        Dim nTemp(9) As String
    '        nTemp = Split(MsgStruct.MessageBody(0).ItemValue, "-")
    '        For nFor = 0 To 9
    '            vByteVal(nFor) = CByte(nTemp(nFor))
    '        Next



    '        RaiseEvent LoopBackRequest(vByteVal)

    '        LoopBackCheckRequestReply_RST(vByteVal)
    '    Catch ex As Exception
    '        WrigeExceptionLog("LoopBackCheckRequest_HOST[SECS S2F25]", ex.ToString)
    '    End Try
    'End Sub

    ''S2F26 From HOST
    'Private Sub S2F26_LoopBackCheckRequestReply_HOST(ByVal MsgStruct As prjSEMI.clsSECSMessage)
    '    Try
    '        MsgStruct.MessageBody(0).TagName = "ABS"
    '        MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

    '        If Not MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.BINARY) Then
    '            S9F7_DataFormatErr(MsgStruct.MessageHeader)
    '            Exit Sub
    '        End If
    '        If MsgStruct.MessageBody(0).ItemSizeMatch(10) = False Then
    '            S9F11_DataTooLong(MsgStruct.MessageHeader)
    '            Exit Sub
    '        End If
    '        '==========================================================================

    '        Dim vByteVal(9) As Byte
    '        Dim nFor As Integer
    '        Dim strTemp(9) As String
    '        strTemp = Split(MsgStruct.MessageBody(0).ItemValue, "-")

    '        For nFor = 0 To 9
    '            vByteVal(nFor) = CByte(strTemp(nFor))
    '        Next

    '        'For nFor = 0 To 9
    '        '    vByteVal(nFor) = CByte(Mid(MsgStruct.MessageBody(0).ItemValue, nFor + 1, 1))
    '        'Next

    '        RaiseEvent LoopBackReply(vByteVal)

    '        LoopBackCheckRequestReply_RST(vByteVal)
    '    Catch ex As Exception
    '        WrigeExceptionLog("LoopBackCheckRequestReply_HOST[SECS S2F26]", ex.ToString)
    '    End Try
    'End Sub
    Private Sub S2F25_LoopBackCheckRequest_HOST(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST S2F25 LoopBack Req")

            MsgStruct.MessageBody(0).TagName = "ABS"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If Not MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.BINARY) Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If
            If MsgStruct.MessageBody(0).ItemSizeMatch(10) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If
            '==========================================================================

            MySysByte.S2F25 = MsgStruct.MessageHeader.SystemByte

            Dim vByteVal(9) As Byte
            Dim nFor As Integer
            Dim nTemp(9) As String
            nTemp = Split(MsgStruct.MessageBody(0).ItemValue, "-")
            For nFor = 0 To 9
                vByteVal(nFor) = CByte("&h" & nTemp(nFor).ToString) ' nTemp(nFor)
            Next



            RaiseEvent LoopBackRequest(vByteVal)

            LoopBackCheckRequestReply_RST(vByteVal)
        Catch ex As Exception
            WrigeExceptionLog("LoopBackCheckRequest_HOST[SECS S2F25]", ex.ToString)
        End Try
    End Sub

    Private Sub S2F26_LoopBackCheckRequestReply_HOST(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S2F26 Loop Back Reply")

            MsgStruct.MessageBody(0).TagName = "ABS"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If Not MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.BINARY) Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If
            If MsgStruct.MessageBody(0).ItemSizeMatch(10) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If
            '==========================================================================

            Dim vByteVal(9) As Byte
            Dim nFor As Integer
            Dim strTemp(9) As String
            strTemp = Split(MsgStruct.MessageBody(0).ItemValue, "-")

            For nFor = 0 To 9
                vByteVal(nFor) = CByte("&h" & strTemp(nFor))
            Next

            'For nFor = 0 To 9
            '    vByteVal(nFor) = CByte(Mid(MsgStruct.MessageBody(0).ItemValue, nFor + 1, 1))
            'Next

            RaiseEvent LoopBackReply(vByteVal)

            'LoopBackCheckRequestReply_RST(vByteVal)
        Catch ex As Exception
            WrigeExceptionLog("LoopBackCheckRequestReply_HOST[SECS S2F26]", ex.ToString)
        End Try
    End Sub
    'Send S2F25 To HOST
    Private Sub LoopBackCheckRequest_RST()
        Try
            Writelog("Send RST S2F25 Loop Back Req")

            Dim SnFn As New prjSEMI.clsSECSMessage(2, 25, True, MySEMI.Fn_IncSysByte)
            Dim nFor As Integer
            Dim vByte(9) As System.Byte
            Dim i As Integer = 1

            For nFor% = 0 To 9
                vByte(nFor) = i%
                i = i + 1
            Next
            SnFn.Fn_Add_Binary(vByte, 10, "ABS")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing

            'ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
        Catch ex As Exception
            WrigeExceptionLog("LoopBackCheckRequest_RST[S2F25]", ex.ToString)
        End Try

    End Sub

    'Reply S2F26 To HOST
    Private Sub LoopBackCheckRequestReply_RST(ByVal vByteVal() As System.Byte)
        Try
            Writelog("Send RST-S2F26 Loop Back Reply")

            Dim SnFn As New prjSEMI.clsSECSMessage(2, 26, False, MySysByte.S2F25)

            SnFn.Fn_Add_Binary(vByteVal, 10, "ABS")
            MySEMI.Fn_AddSendMessage(SnFn)

            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("LoopBackCheckRequestReply_RST[SECS S2F26]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S2F41 HOST Command Send"
    Private Sub S2F41_HOSTCommandSend(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST S2F41")

            MySysByte.S2F41 = MsgStruct.MessageHeader.SystemByte

            MsgStruct.MessageBody(0).TagName = "NOD0"
            MsgStruct.MessageBody(1).TagName = "LINEID"
            MsgStruct.MessageBody(2).TagName = "TOOLID"
            MsgStruct.MessageBody(3).TagName = "CASID"
            MsgStruct.MessageBody(4).TagName = "RCMD"
            MsgStruct.MessageBody(5).TagName = "NOD1"
            MsgStruct.MessageBody(6).TagName = "SAVFLG"
            MsgStruct.MessageBody(7).TagName = "RTXT"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(4) = MsgStruct.MessageBody(4).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(5) = MsgStruct.MessageBody(5).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(6) = MsgStruct.MessageBody(6).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(7) = MsgStruct.MessageBody(7).FormateMatch(prjSEMI.eFormatCode.ASCII)

            'afSize(0) = MsgStruct.MessageBody(0).ItemSizeMatch(prjSEMI.eFormatCode.LIST)
            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_LINEID)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_TOOLID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_CSTID)
            afSize(4) = MsgStruct.MessageBody(4).ItemSizeMatch(30)
            'afSize(5) = MsgStruct.MessageBody(5).ItemSizeMatch(prjSEMI.eFormatCode.LIST)
            afSize(6) = MsgStruct.MessageBody(6).ItemSizeMatch(1)
            afSize(7) = MsgStruct.MessageBody(7).ItemSizeMatch(80)

            For lngFor = 0 To MsgStruct.MessageBody.Count - 1
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '============================================================================================================


            Dim strLineID As String = MsgStruct.MessageBody(1).ItemValue
            Dim strToolID As String = MsgStruct.MessageBody(2).ItemValue
            Dim strCSTID As String = MsgStruct.MessageBody(3).ItemValue
            Dim strRCMD As String = MsgStruct.MessageBody(4).ItemValue
            Dim strSaveFlag As String = MsgStruct.MessageBody(6).ItemValue
            Dim strMessage As String = MsgStruct.MessageBody(7).ItemValue


            RaiseEvent EQRemoteCommand(strToolID, strCSTID, strRCMD, strSaveFlag, strMessage)
        Catch ex As Exception
            WrigeExceptionLog("HOSTCommandSend[SECS S2F41]", ex.ToString)
        End Try
    End Sub

    Private Sub HOSTCommandSendReply(ByVal nReplyCode As clsEnumCtl.eRemoteReplyCMD)
        Try
            Writelog("Send RST-S2F42")

            Dim SnFn As New prjSEMI.clsSECSMessage(2, 42, False, MySysByte.S2F41)
            Dim vByte(0) As Byte

            vByte(0) = nReplyCode
            SnFn.Fn_Add_Binary(vByte, 1, "CMDA")
            MySEMI.Fn_AddSendMessage(SnFn)

            'ReplyTransactionS2F41.Secondary = strSECSMsg

            'ChkSendMSGBuffer(eSendMSGType.TYPE_S, , ReplyTransactionS2F41)

            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("HOSTCommandSendReply[SECS S2F42]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S5F65 Alarm Occurred or Released"
    Private Sub AlarmOccurredRelease(ByVal UnitStructure As clsUnitStructure, ByVal AlarmStructure As clsAlarmStructure, ByVal GlassAffect As Object, ByVal fReportGlassAffect As Boolean, ByVal strDateTimeInfo As String)
        Try
            Writelog("Send RST-S5F65 Alarm Report")

            Dim SnFn As New prjSEMI.clsSECSMessage(5, 65, True, MySEMI.Fn_IncSysByte)
            Dim nFor As Integer
            Dim strAlarmType As String
            If AlarmStructure.AlarmType = eAlarmType.TYPE_ALARM Then
                strAlarmType = "A"
            Else
                strAlarmType = "W"
            End If

            'If Not fReportGlassAffect Then
            '    SnFn.Fn_Add_List(7, "NOD0")
            'Else
            SnFn.Fn_Add_List(8, "NOD0")
            'End If

            SnFn.Fn_Add_ASC(RST_LineName, LEN_LINEID, "LINEID")
            SnFn.Fn_Add_ASC(UnitStructure.ToolID, LEN_TOOLID, "TOOLID")
            SnFn.Fn_Add_ASC(strDateTimeInfo, LEN_DATETIME, "DATETIME")
            SnFn.Fn_Add_ASC(AlarmStructure.AlarmFlag, 1, "EVTFLG")
            SnFn.Fn_Add_ASC(strAlarmType, 1, "AWCATEGORY")
            SnFn.Fn_Add_ASC(UnitStructure.UnitNo & Right("0000000" & Hex(AlarmStructure.AlarmID), 7), 8, "AWUNITCD")
            SnFn.Fn_Add_ASC(SpaceCTL(AlarmStructure.AlarmText, 80), 80, "AWDESC")
            If fReportGlassAffect Then
                SnFn.Fn_Add_List(UBound(GlassAffect), "")
                For nFor = 1 To UBound(GlassAffect)
                    SnFn.Fn_Add_ASC(SpaceCTL(GlassAffect(nFor), LEN_GXID), LEN_GXID, "GLASSID")
                Next nFor
            Else
                SnFn.Fn_Add_List(0)
            End If

            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing

        Catch ex As Exception
            WrigeExceptionLog("AlarmOccurredRelease[SECS S5F65]", ex.ToString)
        End Try
    End Sub

    Private Sub S5F66_AlarmOccurredReleaseReply(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S5F66 Alarm Report Reply")

            MsgStruct.MessageBody(0).TagName = "RTNCD"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_RTNCD7) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If

            Dim strRet As String = MsgStruct.MessageBody(0).ItemValue

            If strRet = "0000000" Then
                strRet = 0
            Else
                strRet = 1
            End If


            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S5F66, strRet)
        Catch ex As Exception
            WrigeExceptionLog("AlarmOccurredReleaseReply[SECS S5F66]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S6F85 Glass RemoveData Report"
    Private Sub GlassRemoveReport(ByVal strToolID As String, ByVal strGlassID As String)
        Try
            Writelog("Send RST-S6F85 Glass Remove Report")

            Dim SnFn As New prjSEMI.clsSECSMessage(6, 85, True, MySEMI.Fn_IncSysByte)

            SnFn.Fn_Add_List(4, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, LEN_LINEID, "LINEID")
            SnFn.Fn_Add_ASC(SpaceCTL(strToolID, LEN_TOOLID), LEN_TOOLID, "TOOLID")
            SnFn.Fn_Add_ASC(GetNow(), LEN_DATETIME, "DATETIME")
            SnFn.Fn_Add_ASC(SpaceCTL(strGlassID, LEN_GXID), LEN_GXID, "GLASSID")

            MySEMI.Fn_AddSendMessage(SnFn)
            'ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)

            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("GlassRemoveReport[SECS S6F85]", ex.ToString)
        End Try
    End Sub

    Private Sub S6F86_GlassRemoveReportReply(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S6F86 Glass Remove Reply")

            MsgStruct.MessageBody(0).TagName = "RTNCD"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_RTNCD7) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If

            Dim strRet As String = MsgStruct.MessageBody(0).ItemValue

            If strRet = "0000000" Then
                strRet = 0
            Else
                strRet = 1
            End If

            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S6F86, strRet)
        Catch ex As Exception
            WrigeExceptionLog("GlassRemoveReportReply[SECS S6F86]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S6F87 Glass ID Unmatch Report"
    Private Sub GlassIDUnmatchReport(ByVal strToolID As String, ByVal strHostGlassID As String, ByVal strVCRGlassID As String)
        Try
            Writelog("Send RST-S6F87 GlassID Unmatch Report")

            Dim SnFn As New prjSEMI.clsSECSMessage(6, 87, True, MySEMI.Fn_IncSysByte)
            SnFn.Fn_Add_List(5, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, LEN_LINEID, "LINEID")
            SnFn.Fn_Add_ASC(SpaceCTL(strToolID, LEN_TOOLID), LEN_TOOLID, "TOOLID")
            SnFn.Fn_Add_ASC(GetNow(), LEN_DATETIME, "DATETIME")
            SnFn.Fn_Add_ASC(SpaceCTL(strHostGlassID, LEN_GXID), LEN_GXID, "HGLASSID")
            SnFn.Fn_Add_ASC(SpaceCTL(strVCRGlassID, LEN_GXID), LEN_GXID, "RGLASSID")

            'ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("GlassIDUnmatchReport[SECS S6F87]", ex.ToString)
        End Try
    End Sub

    Private Sub S6F88_GlassIDUnmatchReportReply(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S6F88 GlassID Unmatch Reply")

            MsgStruct.MessageBody(0).TagName = "RTNCD"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.ASCII) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_RTNCD7) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If

            Dim strRet As String = MsgStruct.MessageBody(0).ItemValue

            If strRet = "0000000" Then
                strRet = 0
            Else
                strRet = 1
            End If


            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S6F88, strRet)
        Catch ex As Exception
            WrigeExceptionLog("GlassIDUnmatchReportReply[SECS S6F88]", ex.ToString)
        End Try
    End Sub

#End Region

#Region "S6F91 Glass Process Start or END Report"

    Private Sub GlassProcessReport(ByRef EQGxProcessInfo() As clsGxReport)
        Try
            Writelog("Send RST-S6F91 Glass Process Report")

            Dim SnFn As New prjSEMI.clsSECSMessage(6, 91, True, MySEMI.Fn_IncSysByte)
            Dim nFor As Integer

            SnFn.Fn_Add_List(5, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, LEN_LINEID, "LINEID")
            SnFn.Fn_Add_ASC(SpaceCTL(SpaceCTL(EQGxProcessInfo(1).GxID, LEN_GXID), LEN_GXID), LEN_GXID, "GLASSID")
            SnFn.Fn_Add_ASC(GetNow(), LEN_DATETIME, "DATETIME")
            SnFn.Fn_Add_ASC(Space(2), LEN_2, "EVTFLG")
            SnFn.Fn_Add_List(UBound(EQGxProcessInfo), "NOD1")
            For nFor = 1 To UBound(EQGxProcessInfo)
                SnFn.Fn_Add_List(4, "NOD2")
                SnFn.Fn_Add_ASC(SpaceCTL(EQGxProcessInfo(nFor).ToolID, LEN_TOOLID), LEN_TOOLID, "TOOLID")
                SnFn.Fn_Add_ASC(SpaceCTL(EQGxProcessInfo(nFor).PPID, LEN_PPID), LEN_PPID, "ACTPPID")
                SnFn.Fn_Add_ASC(SpaceCTL(EQGxProcessInfo(nFor).ProcessStartTime, LEN_DATETIME), LEN_DATETIME, "PSTRTTIME")
                SnFn.Fn_Add_ASC(SpaceCTL(EQGxProcessInfo(nFor).ProcessEndTime, LEN_DATETIME), LEN_DATETIME, "PENDTTIME")
            Next
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing

        Catch ex As Exception
            WrigeExceptionLog("GlassProcessReport[SECS S6F91]", ex.ToString)
        End Try
    End Sub

    Private Sub S6F92_GlassProcessReportReply(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S6F92 Glass Process Reply")

            MsgStruct.MessageBody(0).TagName = "ACKC6"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.BINARY) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_BINARY) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If

            Dim nRet As Integer = MsgStruct.MessageBody(0).ItemValue


            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S6F92, nRet)
        Catch ex As Exception
            WrigeExceptionLog("GlassProcessReportReply[SECS S6F92]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S7F3 Recipe Parameter Query"
    Private Sub S7F3_HOSTRecipeParameterQuery(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S7F3 Recipe Parameter Query")

            MsgStruct.MessageBody(0).TagName = "NOD0"
            MsgStruct.MessageBody(1).TagName = "LINEID"
            MsgStruct.MessageBody(2).TagName = "TOOLID"
            MsgStruct.MessageBody(3).TagName = "PPID"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.ASCII)

            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_LINEID)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_TOOLID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_PPID16)


            For lngFor = 0 To MsgStruct.MessageBody.Count - 1
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '============================================================================================================
            MySysByte.S7F3 = MsgStruct.MessageHeader.SystemByte

            Dim strLineID As String = MsgStruct.MessageBody(1).ItemValue
            Dim strToolID As String = MsgStruct.MessageBody(2).ItemValue
            Dim strPPID As String = MsgStruct.MessageBody(3).ItemValue

            RaiseEvent RecipeParameterQuery(strLineID, strToolID, strPPID)
        Catch ex As Exception
            WrigeExceptionLog("HOSTRecipeParameterQuery[SECS S7F3]", ex.ToString)
        End Try
    End Sub

    Private Sub RecipeParameterQueryReply(ByVal Recipe As clsRecipeStructure)
        Try
            Writelog("Send RST-S7F4 Recipe Parameter Query Reply")

            Dim SnFn As New prjSEMI.clsSECSMessage(7, 4, False, MySysByte.S7F3)
            Dim nFor As Integer
            Dim btyAck(0) As Byte
            btyAck(0) = Recipe.AckCode
            If Recipe.AckCode <> eACKC7ReplyCMD.CMD_ACCEPTED Then
                SnFn.Fn_Add_List(4, "NOD0")
            Else
                SnFn.Fn_Add_List(5, "NOD0")
            End If
            SnFn.Fn_Add_ASC(RST_LineName, LEN_LINEID, "LINEID")
            SnFn.Fn_Add_ASC(RST_LineToolName, LEN_TOOLID, "TOOLID")
            SnFn.Fn_Add_Binary(btyAck, 1, "ACKC7")
            SnFn.Fn_Add_ASC(Recipe.RecipeName, LEN_PPID16, "PPID")
            If Recipe.AckCode = eACKC7ReplyCMD.CMD_ACCEPTED Then
                SnFn.Fn_Add_List(Recipe.TotalParmeter, "NOD1")
                For nFor = 1 To Recipe.TotalParmeter
                    SnFn.Fn_Add_List(2, "NOD2")
                    SnFn.Fn_Add_ASC(Recipe.ParmeterName(nFor), LEN_PPID16, "PARANAME")
                    SnFn.Fn_Add_ASC(Recipe.ParmeterValue(nFor), LEN_PPID16, "PARAVAL")
                Next
            End If

            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing

        Catch ex As Exception
            WrigeExceptionLog("RecipeParameterQueryReply[SECS S7F4]", ex.ToString)
        End Try
    End Sub

#End Region

#Region "S7F65 InLine Process Data Transfer"
    Private Sub S7F65_LotProcessDataDownload(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        MySysByte.S7F65 = MsgStruct.MessageHeader.SystemByte
        Try
            Writelog("Receive HOST-S7F65 Lot Process Data")

            Dim nIdx As Integer = 14
            Dim nGxCount As Integer = 1
            Dim nFor As Integer
            Dim strLineID As String
            Dim strToolID As String

            Dim LotStrucgture As New clsLotStructure

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next


            MsgStruct.MessageBody(1).TagName = "LINEID"
            MsgStruct.MessageBody(2).TagName = "TOOLID"
            MsgStruct.MessageBody(3).TagName = "DATETIME"
            MsgStruct.MessageBody(4).TagName = "RTNCD"
            MsgStruct.MessageBody(5).TagName = "CIMMSG"
            MsgStruct.MessageBody(6).TagName = "LDPOS"
            MsgStruct.MessageBody(7).TagName = "CASID"
            MsgStruct.MessageBody(8).TagName = "PRODCD"
            MsgStruct.MessageBody(9).TagName = "PRODCATE"
            MsgStruct.MessageBody(10).TagName = "MESID"
            MsgStruct.MessageBody(11).TagName = "OPERID"
            MsgStruct.MessageBody(12).TagName = "PPID"

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(4) = MsgStruct.MessageBody(4).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(5) = MsgStruct.MessageBody(5).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(6) = MsgStruct.MessageBody(6).FormateMatch(prjSEMI.eFormatCode.BINARY)
            afFormate(7) = MsgStruct.MessageBody(7).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(8) = MsgStruct.MessageBody(8).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(9) = MsgStruct.MessageBody(9).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(10) = MsgStruct.MessageBody(10).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(11) = MsgStruct.MessageBody(11).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(12) = MsgStruct.MessageBody(12).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(13) = MsgStruct.MessageBody(13).FormateMatch(prjSEMI.eFormatCode.LIST)

            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_LINEID)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_TOOLID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_DATETIME)
            afSize(4) = MsgStruct.MessageBody(4).ItemSizeMatch(LEN_RTNCD7)
            afSize(5) = MsgStruct.MessageBody(5).ItemSizeMatch(22)
            afSize(6) = MsgStruct.MessageBody(6).ItemSizeMatch(LEN_BINARY)
            afSize(7) = MsgStruct.MessageBody(7).ItemSizeMatch(LEN_CSTID)
            afSize(8) = MsgStruct.MessageBody(8).ItemSizeMatch(25)
            afSize(9) = MsgStruct.MessageBody(9).ItemSizeMatch(4)
            afSize(10) = MsgStruct.MessageBody(10).ItemSizeMatch(8)
            afSize(11) = MsgStruct.MessageBody(11).ItemSizeMatch(25)
            afSize(12) = MsgStruct.MessageBody(12).ItemSizeMatch(32)


            strLineID = MsgStruct.MessageBody(1).ItemValue
            strToolID = MsgStruct.MessageBody(2).ItemValue

            LotStrucgture.DateTime = MsgStruct.MessageBody(3).ItemValue
            LotStrucgture.ReturnCode = MsgStruct.MessageBody(4).ItemValue
            LotStrucgture.CIMMessage = MsgStruct.MessageBody(5).ItemValue
            LotStrucgture.PortPosition = MsgStruct.MessageBody(6).ItemValue
            LotStrucgture.CassetteID = MsgStruct.MessageBody(7).ItemValue
            LotStrucgture.ProductCode = MsgStruct.MessageBody(8).ItemValue
            LotStrucgture.ProductCategoryByString = MsgStruct.MessageBody(9).ItemValue
            LotStrucgture.MeasurementID = MsgStruct.MessageBody(10).ItemValue
            LotStrucgture.OperationID = MsgStruct.MessageBody(11).ItemValue
            LotStrucgture.RecipeName = MsgStruct.MessageBody(12).ItemValue

            If LotStrucgture.ReturnCode = EMPY_CST Then
                For nFor = 1 To MAX_SLOTS
                    LotStrucgture.Slots(nFor).SlotNo = 0
                    LotStrucgture.Slots(nFor).GlassID = ""
                    LotStrucgture.Slots(nFor).LastOperationID = ""
                    LotStrucgture.Slots(nFor).PLineID = ""
                    LotStrucgture.Slots(nFor).ProcessToolID = ""
                    LotStrucgture.Slots(nFor).DMQCToolID = ""
                    LotStrucgture.Slots(nFor).GlassGradeByString = ""
                    LotStrucgture.Slots(nFor).DMQCGradeByString = ""
                    LotStrucgture.Slots(nFor).PSHGroup = ""
                    LotStrucgture.Slots(nFor).ChipGradeByString = ""
                    LotStrucgture.Slots(nFor).ReworkByString = ""
                    LotStrucgture.Slots(nFor).ScrapByString = ""
                    LotStrucgture.Slots(nFor).FIRemarkByString = ""
                    LotStrucgture.Slots(nFor).FIFCFlagByString = ""
                Next
            Else


                MsgStruct.MessageBody(13).TagName = "NOD1"
100:
                MsgStruct.MessageBody(nIdx + 1).TagName = "SLOTNO"
                MsgStruct.MessageBody(nIdx + 2).TagName = "GLASSID"
                MsgStruct.MessageBody(nIdx + 3).TagName = "POPERID"
                MsgStruct.MessageBody(nIdx + 4).TagName = "PLINEID"
                MsgStruct.MessageBody(nIdx + 5).TagName = "PTOOLID"
                MsgStruct.MessageBody(nIdx + 6).TagName = "DMQCTOLID"
                MsgStruct.MessageBody(nIdx + 7).TagName = "GGRADE"
                MsgStruct.MessageBody(nIdx + 8).TagName = "DGRADE"
                MsgStruct.MessageBody(nIdx + 9).TagName = "PGROUP"
                MsgStruct.MessageBody(nIdx + 10).TagName = "CHIPGRADE"
                MsgStruct.MessageBody(nIdx + 11).TagName = "RWKFLAG"
                MsgStruct.MessageBody(nIdx + 12).TagName = "SCRPFLAG"
                MsgStruct.MessageBody(nIdx + 13).TagName = "FIRMFLAG"
                MsgStruct.MessageBody(nIdx + 14).TagName = "FIFCFLAG"
                '=====================================================================================
                afFormate(nIdx + 1) = MsgStruct.MessageBody(nIdx + 1).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 2) = MsgStruct.MessageBody(nIdx + 2).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 3) = MsgStruct.MessageBody(nIdx + 3).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 4) = MsgStruct.MessageBody(nIdx + 4).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 5) = MsgStruct.MessageBody(nIdx + 5).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 6) = MsgStruct.MessageBody(nIdx + 6).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 7) = MsgStruct.MessageBody(nIdx + 7).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 8) = MsgStruct.MessageBody(nIdx + 8).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 9) = MsgStruct.MessageBody(nIdx + 9).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 10) = MsgStruct.MessageBody(nIdx + 10).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 11) = MsgStruct.MessageBody(nIdx + 11).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 12) = MsgStruct.MessageBody(nIdx + 12).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 13) = MsgStruct.MessageBody(nIdx + 13).FormateMatch(prjSEMI.eFormatCode.ASCII)
                afFormate(nIdx + 14) = MsgStruct.MessageBody(nIdx + 14).FormateMatch(prjSEMI.eFormatCode.ASCII)

                afFormate(nIdx + 1) = MsgStruct.MessageBody(nIdx + 1).ItemSizeMatch(2)
                afFormate(nIdx + 2) = MsgStruct.MessageBody(nIdx + 2).ItemSizeMatch(LEN_GXID)
                afFormate(nIdx + 3) = MsgStruct.MessageBody(nIdx + 3).ItemSizeMatch(25)
                afFormate(nIdx + 4) = MsgStruct.MessageBody(nIdx + 4).ItemSizeMatch(8)
                afFormate(nIdx + 5) = MsgStruct.MessageBody(nIdx + 5).ItemSizeMatch(8)
                afFormate(nIdx + 6) = MsgStruct.MessageBody(nIdx + 6).ItemSizeMatch(8)
                afFormate(nIdx + 7) = MsgStruct.MessageBody(nIdx + 7).ItemSizeMatch(1)
                afFormate(nIdx + 8) = MsgStruct.MessageBody(nIdx + 8).ItemSizeMatch(1)
                afFormate(nIdx + 9) = MsgStruct.MessageBody(nIdx + 9).ItemSizeMatch(3)
                afFormate(nIdx + 10) = MsgStruct.MessageBody(nIdx + 10).ItemSizeMatch(72)
                afFormate(nIdx + 11) = MsgStruct.MessageBody(nIdx + 11).ItemSizeMatch(1)
                afFormate(nIdx + 12) = MsgStruct.MessageBody(nIdx + 12).ItemSizeMatch(1)
                afFormate(nIdx + 13) = MsgStruct.MessageBody(nIdx + 13).ItemSizeMatch(1)
                afFormate(nIdx + 14) = MsgStruct.MessageBody(nIdx + 14).ItemSizeMatch(1)

                '=====================================================================================
                LotStrucgture.Slots(nGxCount).SlotNo = CInt(IIf(MsgStruct.MessageBody(nIdx + 1).ItemValue <> "", MsgStruct.MessageBody(nIdx + 1).ItemValue, 0))
                LotStrucgture.Slots(nGxCount).GlassID = MsgStruct.MessageBody(nIdx + 2).ItemValue
                LotStrucgture.Slots(nGxCount).LastOperationID = MsgStruct.MessageBody(nIdx + 3).ItemValue
                LotStrucgture.Slots(nGxCount).PLineID = MsgStruct.MessageBody(nIdx + 4).ItemValue
                LotStrucgture.Slots(nGxCount).ProcessToolID = MsgStruct.MessageBody(nIdx + 5).ItemValue
                LotStrucgture.Slots(nGxCount).DMQCToolID = MsgStruct.MessageBody(nIdx + 6).ItemValue
                LotStrucgture.Slots(nGxCount).GlassGradeByString = MsgStruct.MessageBody(nIdx + 7).ItemValue
                LotStrucgture.Slots(nGxCount).DMQCGradeByString = MsgStruct.MessageBody(nIdx + 8).ItemValue
                LotStrucgture.Slots(nGxCount).PSHGroup = MsgStruct.MessageBody(nIdx + 9).ItemValue
                LotStrucgture.Slots(nGxCount).ChipGradeByString = MsgStruct.MessageBody(nIdx + 10).ItemValue
                LotStrucgture.Slots(nGxCount).ReworkByString = MsgStruct.MessageBody(nIdx + 11).ItemValue
                LotStrucgture.Slots(nGxCount).ScrapByString = MsgStruct.MessageBody(nIdx + 12).ItemValue
                LotStrucgture.Slots(nGxCount).FIRemarkByString = MsgStruct.MessageBody(nIdx + 13).ItemValue
                LotStrucgture.Slots(nGxCount).FIFCFlagByString = MsgStruct.MessageBody(nIdx + 14).ItemValue

                If MsgStruct.MessageBody(nIdx + 14).ItemIdx < MsgStruct.MessageBody.Count Then
                    Dim aa As ULong = MsgStruct.MessageBody(nIdx + 14).ItemIdx
                    nGxCount = nGxCount + 1
                    nIdx = nIdx + 15
                    GoTo 100
                End If
            End If

            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)


            '=====================================================================================
            For lngFor = 0 To MsgStruct.MessageBody.Count - 1
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '=====================================================================================

            RaiseEvent LotDataReply(LotStrucgture)

            LotStrucgture = Nothing
        Catch ex As Exception
            WrigeExceptionLog("LotProcessDataDownload[SECS S7F65]", ex.ToString)
        End Try
    End Sub

    Private Sub S7F66_LotProcessDataDownloadReply(ByVal nACKC7 As Integer)
        Try
            Writelog("Send RST-S7F66 Lot Process Data Reply")

            Dim SnFn As New prjSEMI.clsSECSMessage(7, 66, False, MySysByte.S7F65)
            Dim btyAck(0) As Byte
            btyAck(0) = nACKC7
            SnFn.Fn_Add_Binary(btyAck, 1, "ACKC7")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing

            'ChkSendMSGBuffer(eSendMSGType.TYPE_S, , ReplyTransactionS7F65)
        Catch ex As Exception
            WrigeExceptionLog("LotProcessDataDownloadReply[SECS S7F66]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S7F67 Inquire Last Modification Date Time Of Recipe ID"
    Private Sub S7F67_RecipeLastModifyDateTimeRequest(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S7F67 Recipe Last Modify DateTime Request")

            MySysByte.S7F67 = MsgStruct.MessageHeader.SystemByte
            MsgStruct.MessageBody(0).TagName = "NOD0"
            MsgStruct.MessageBody(1).TagName = "LINEID"
            MsgStruct.MessageBody(2).TagName = "TOOLID"
            MsgStruct.MessageBody(3).TagName = "PPID"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.ASCII)


            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_LINEID)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_TOOLID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_PPID16)


            For lngFor = 0 To MsgStruct.MessageBody.Count - 1
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '============================================================================================================


            Dim strLineID As String = MsgStruct.MessageBody(1).ItemValue
            Dim strToolID As String = MsgStruct.MessageBody(2).ItemValue
            Dim strPPID As String = MsgStruct.MessageBody(3).ItemValue


            RaiseEvent LastRecipeModifyTime(strPPID)
        Catch ex As Exception
            WrigeExceptionLog("RecipeLastModifyDateTimeRequest[SECS S7F67]", ex.ToString)
        End Try
    End Sub

    Private Sub RecipeLastModifyDateTimeReport(ByVal nACKC7 As Integer, ByVal strPPID As String, ByVal strDatetime As String)
        Try
            Writelog("Send RST-S7F68 Recipe Last Modify DateTime Reply")

            Dim SnFn As New prjSEMI.clsSECSMessage(7, 68, False, MySysByte.S7F67)
            Dim btyAck(0) As Byte

            btyAck(0) = nACKC7
            SnFn.Fn_Add_List(5, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, LEN_LINEID, "LINEID")
            SnFn.Fn_Add_ASC(RST_LineToolName, LEN_TOOLID, "TOOLID")
            SnFn.Fn_Add_Binary(btyAck, 1, "ACKC7")
            SnFn.Fn_Add_ASC(SpaceCTL(strPPID, LEN_PPID16), LEN_PPID16, "PPID")
            SnFn.Fn_Add_ASC(SpaceCTL(strDatetime, LEN_DATETIME), LEN_DATETIME, "DATETIME")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
        Catch ex As Exception
            WrigeExceptionLog("RecipeLastModifyDateTimeReport[SECS S7F68]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S7F71 Lot Process Data Request"
    Private Sub LotProcessDataRequest(ByVal nPortMode As clsEnumCtl.ePortMode, ByVal nPortType As clsEnumCtl.ePortCategory, ByVal nLDPOS As Integer, ByVal strOPID As String, ByVal strCSTID As String)
        Try
            Writelog("Send RST-S7F71 Lot Process Data Request")

            Dim SnFn As New prjSEMI.clsSECSMessage(7, 71, True, MySEMI.Fn_IncSysByte)
            Dim btyLDPos(0) As Byte

            btyLDPos(0) = CInt("&H" & nLDPOS)

            SnFn.Fn_Add_List(8, "NOD0")
            SnFn.Fn_Add_ASC(RST_LineName, LEN_LINEID, "LINEID")
            SnFn.Fn_Add_ASC(RST_LineToolName, LEN_TOOLID, "TOOLID")
            SnFn.Fn_Add_ASC(GetNow(), LEN_DATETIME, "DATETIME")
            SnFn.Fn_Add_ASC(nPortMode, 1, "PMODE")
            If nPortMode = clsEnumCtl.ePortMode.MODE_LOADER Then
                SnFn.Fn_Add_ASC(Space(1), 1, "PORTTYPE")
            Else
                SnFn.Fn_Add_ASC(PortCategoryToString(nPortType), 1, "PORTTYPE")
            End If
            SnFn.Fn_Add_Binary(btyLDPos, 1, "LDPOS")
            SnFn.Fn_Add_ASC(SpaceCTL(strOPID, LEN_OPID), LEN_OPID, "OPID")
            SnFn.Fn_Add_ASC(SpaceCTL(strCSTID, LEN_CSTID), LEN_CSTID, "CASID")

            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
            '            ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
        Catch ex As Exception
            WrigeExceptionLog("LotProcessDataRequest[SECS S7F71]", ex.ToString)
        End Try
    End Sub

    Private Sub S7F72_LotProcessDataRequestReply(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S7F72 Lot Process Data Request Reply")

            MsgStruct.MessageBody(0).TagName = "GRANT"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            If MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.BINARY) = False Then
                S9F7_DataFormatErr(MsgStruct.MessageHeader)
                Exit Sub
            End If

            If MsgStruct.MessageBody(0).ItemSizeMatch(LEN_BINARY) = False Then
                S9F11_DataTooLong(MsgStruct.MessageHeader)
                Exit Sub
            End If
            '=======================================================================

            Dim nRet As Integer = MsgStruct.MessageBody(0).ItemValue


            RaiseEvent ReceiveMSGReplyCode(clsEnumCtl.eSECSStatusReplyType.T_S7F72, nRet)
        Catch ex As Exception
            WrigeExceptionLog("LotProcessDataRequestReply[S7F72]", ex.ToString)
        End Try
    End Sub
#End Region

#Region "S9F1 Unrecognized Device ID"
    Public Sub UnrecognizedDeviceID()
        'Use SECS Driver's Function

        Writelog("Send RST-S9F1")

        Dim SnFn As New prjSEMI.clsSECSMessage(9, 1, False, MySEMI.Fn_IncSysByte)
        MySEMI.Fn_AddSendMessage(SnFn)
        SnFn = Nothing
    End Sub
#End Region

#Region "S9F3 Unecognized Stream Type"
    Public Sub UnrecognizedStreamType(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        'Dim SnFn As New prjSEMI.clsSECSMessage(9, 3, False, MySEMI.Fn_IncSysByte)
        'Dim btyMhead(9) As Byte
        'btyMhead(0) = MsgStruct.MessageHeader
        'SnFn.Fn_Add_Binary(btyMhead, 10, "MHEAD")
        'MySEMI.Fn_AddSendMessage(SnFn)
        'SnFn = Nothing
    End Sub
#End Region

#Region "S9F5 Unrecognized Function Type"
    Public Sub UnrecognizedFunctionType()
        'Use SECS Driver's Function
    End Sub
#End Region

#Region "S9F7 Illegal Data"
    Public Sub IllegalData()
        'Use SECS Driver's Function
    End Sub
#End Region

#Region "S9F9 Transaction Timer time out"
    Public Sub TransactionTimeout()
        'Try
        '    Dim nFor As Integer
        '    Dim vByte(9) As System.Byte
        '    Dim strByte(9) As String
        '    Dim strMsgHeader As String

        '    Dim strSECSMsg As New SecsMessageX
        '    Dim strTransaction As New SecsWrapperOCX.SecsTransactionX

        '    strSECSMsg = MyForm.AxSecsWrapperX1.LoadMessage(MSGDEF_S9F9)
        '    strTransaction.Primary = strSECSMsg
        '    strMsgHeader = MessageHeader(strTransaction, False)
        '    strByte = Split(strMsgHeader, ",")

        '    For nFor% = 0 To 9
        '        vByte(nFor) = CByte(strByte(nFor))
        '    Next

        '    strSECSMsg.RootItem.Value = vByte

        '    ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)

        '    strSECSMsg = Nothing
        '    strTransaction = Nothing
        'Catch ex As Exception
        '    WrigeExceptionLog("TransactionTimeout[SECS S9F9]", ex.ToString)
        'End Try


    End Sub
#End Region

#Region "S9F11 Data Too Long"
    Public Sub DataTooLong()
        'Use SECS Driver's Function
    End Sub
#End Region

#Region "S9F13 Conversation timeout"
    Private Sub ConversationTimeout(ByVal nStreamID As Integer, ByVal nFunctionID As Integer)
        Try


            Dim SnFn As New prjSEMI.clsSECSMessage(9, 13, False, MySEMI.Fn_IncSysByte)
            Dim strSnFn = "S" & Right("0" & CStr(nStreamID), 2) & "F" & Right("0" & CStr(nFunctionID), 2)
            Writelog("Send RST-S9F13==>" & strSnFn)
            SnFn.Fn_Add_List(2, "NOD0")
            SnFn.Fn_Add_ASC(strSnFn, 6, "MEXP")
            SnFn.Fn_Add_ASC(Space(10), 10, "EDID")

            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing


        Catch ex As Exception
            WrigeExceptionLog("ConversationTimeout[SECS S9F13]", ex.ToString)
        End Try


    End Sub
#End Region

#Region "S10F1 Terminal Request"
    Private Sub SendMsgToHOST(ByVal strMsg As String)
        Try
            Dim SnFn As New prjSEMI.clsSECSMessage(10, 1, False, MySEMI.Fn_IncSysByte)
            SnFn.Fn_Add_ASC(strMsg, LEN_S10F1, "TEXT")
            MySEMI.Fn_AddSendMessage(SnFn)
            SnFn = Nothing
            'ChkSendMSGBuffer(eSendMSGType.TYPE_P, strSECSMsg)
        Catch ex As Exception
            WrigeExceptionLog("SendMsgToHOST[SECS S10F1]", ex.ToString)
        End Try


    End Sub
#End Region

#Region "S10F5 Terinal Display"
    Private Sub S10F5_HOSTTerinalDisplay(ByVal MsgStruct As prjSEMI.clsSECSMessage)
        Try
            Writelog("Receive HOST-S10F5 Terinal Display")

            MsgStruct.MessageBody(0).TagName = "NOD0"
            MsgStruct.MessageBody(1).TagName = "TID"
            MsgStruct.MessageBody(2).TagName = "TOOLID"
            MsgStruct.MessageBody(3).TagName = "LINEID"
            MsgStruct.MessageBody(4).TagName = "TEXT"
            MsgStruct.MessageBody(5).TagName = "BUZZER"
            MySEMI.SaveRecLog(MsgStruct, prjSEMI.eStreamType.TYPE_GET)

            Dim lngFor As Long = 0
            Dim afFormate(MsgStruct.MessageBody.Count) As Boolean
            Dim afSize(MsgStruct.MessageBody.Count) As Boolean

            For lngFor = 0 To MsgStruct.MessageBody.Count
                afFormate(lngFor) = True
                afSize(lngFor) = True
            Next

            afFormate(0) = MsgStruct.MessageBody(0).FormateMatch(prjSEMI.eFormatCode.LIST)
            afFormate(1) = MsgStruct.MessageBody(1).FormateMatch(prjSEMI.eFormatCode.BINARY)
            afFormate(2) = MsgStruct.MessageBody(2).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(3) = MsgStruct.MessageBody(3).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(4) = MsgStruct.MessageBody(4).FormateMatch(prjSEMI.eFormatCode.ASCII)
            afFormate(5) = MsgStruct.MessageBody(5).FormateMatch(prjSEMI.eFormatCode.BINARY)

            afSize(1) = MsgStruct.MessageBody(1).ItemSizeMatch(LEN_BINARY)
            afSize(2) = MsgStruct.MessageBody(2).ItemSizeMatch(LEN_LINEID)
            afSize(3) = MsgStruct.MessageBody(3).ItemSizeMatch(LEN_TOOLID)
            afSize(4) = MsgStruct.MessageBody(4).ItemSizeMatch(22)
            afSize(5) = MsgStruct.MessageBody(5).ItemSizeMatch(LEN_BINARY)

            For lngFor = 0 To MsgStruct.MessageBody.Count - 1
                If afFormate(lngFor) = False Then
                    S9F7_DataFormatErr(MsgStruct.MessageHeader)
                    Exit Sub
                End If

                If afSize(lngFor) = False Then
                    S9F11_DataTooLong(MsgStruct.MessageHeader)
                    Exit Sub
                End If
            Next
            '============================================================================================================


            Dim nTID As Integer = MsgStruct.MessageBody(1).ItemValue
            Dim strToolID As String = MsgStruct.MessageBody(2).ItemValue
            Dim strLineID As String = MsgStruct.MessageBody(3).ItemValue
            Dim strMsg As String = MsgStruct.MessageBody(4).ItemValue
            Dim nBuzzer As Integer = MsgStruct.MessageBody(5).ItemValue


            RaiseEvent TerminalDisplay(nTID, strToolID, IIf(nBuzzer = 1, True, False), strMsg)
        Catch ex As Exception
            WrigeExceptionLog("HOSTTerinalDisplay[SECS S10F5]", ex.ToString)
        End Try
    End Sub
#End Region

#End Region

#Region "SECS Message Event Control"
    Friend Sub SimSECSConnect(ByVal fConnect As Boolean)
        If fConnect Then
            RaiseEvent HOSTConnectStatus(True)
        Else
            RaiseEvent HOSTConnectStatus(False)
        End If
    End Sub
#End Region

#Region "Msg Buffer Check Handle"
    'OK.
    'Private Sub CheckStreamFunction(ByVal MsgStruct As prjSEMI.clsSECSMessage)
    '    Try
    '        Dim fFindStream As Boolean

    '        Select Case MsgStruct.MessageHeader.StreamID
    '            Case 1, 2, 5, 6, 7, 10
    '                fFindStream = True
    '            Case Else
    '        End Select
    '    Catch ex As Exception
    '        WrigeExceptionLog("Sub CheckStreamFunction", ex.ToString)
    '    End Try
    'End Sub

    Private Function RemoveRecevieMsgs(ByVal szKey As String) As Boolean
        Try
            Dim nFor As Integer
            Dim szSF As String

            For nFor = 1 To RecevieMsgs.Count
                szSF = RecevieMsgs.Item(nFor)
                If szSF = szKey Then
                    RecevieMsgs.Remove(nFor)
                    Exit For
                End If
            Next
        Catch ex As Exception
            WrigeExceptionLog("Sub RemoveRecevieMsgs", ex.ToString)
        End Try
    End Function

    '    Private Function RemoveSendMsgs(ByVal szKey As String) As Boolean
    '        Try
    '            Dim nFor As Integer
    '            Dim szSF As String


    '            For nFor = 1 To SendMsgs.Count
    '                szSF = SendMsgs.Item(nFor)

    '                If UCase(szSF) = UCase(szKey) Then
    '                    SendMsgs.Remove(nFor)
    '                    Exit For
    '                End If
    '            Next
    '        Catch ex As Exception
    '            WrigeExceptionLog("Sub RemoveSendMsgs", ex.ToString)
    '        End Try
    '    End Function
#End Region

    '    Public Sub New()
    '        MyLog.InitLogObj("SECS")
    '    End Sub

    Private Sub MySECSEvent_TCPConnectChange(ByVal nStat As prjSEMI.eConnectState) Handles MySECSEvent.TCPConnectChange
        If nStat = prjSEMI.eConnectState.Connected Then
            RaiseEvent HOSTConnectStatus(True)
        Else
            RaiseEvent HOSTConnectStatus(False)
        End If
    End Sub

    Public Sub New()
        MyLog.InitLogObj("SECS")
    End Sub
End Class