Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.IO
Imports System.Runtime.InteropServices
Imports prjSEMI.clsTCPIP
Imports System.Timers

Public Class clsHSMS

    '繼承 clsTCPIP
    Inherits clsTCPIP

    Private MyRecQue As New Queue(Of clsSECSMessage)
    Private MySendQue As New Queue(Of clsSECSMessage)
    Private MyT3 As New List(Of T3Body)

    Private MyLogger As New clsHSMSLog
    Private MyLinkTickBuffer As Long = System.DateTime.Now.Ticks


    Private mvarLocalSysByte As ULong
    Private mvarSECSName As String
    Private mvarDeviceID As String
    Private mvarSECSMode As String
    Private mvarLogPath As String
    Private mvarLogRawData As Boolean
    Private mvarLogCtlMsg As Boolean
    Private mvarT3 As Integer
    Private mvarT5 As Integer
    Private mvarT6 As Integer
    Private mvarT7 As Integer
    Private mvarT8 As Integer
    Private mvarLinkInterval As Integer = 30
    Private mvarConnectStat As eConnectState

    Const SECSDATA_NO = 0
    Const SELECTREQ_NO = 1
    Const SELECTRSP_NO = 2
    Const LINKREQ_NO = 5
    Const LINKRSP_NO = 6
    Const REJECTREQ_NO = 7
    Const SEPARATER_NO = 9
    Const S9F11_NO = 999

    'Format Code
    Const LIST_NO = &H1
    Const BINARY_NO = &H21
    Const BOOLEAN_NO = &H25
    Const ASC1_NO = &H41
    Const JIS_NO = &H45
    Const I1_NO = &H65
    Const I2_NO = &H69
    Const I4_NO = &H71
    Const I8_NO = &H61
    Const U1_NO = &HA5
    Const U2_NO = &HA9
    Const U4_NO = &HB1
    Const U8_NO = &HA1
    Const F8_NO = &H81
    Const F4_NO = &H91


    Public Event LogReport(ByVal strLog As String)
    Public Event TCPConnectChange(ByVal nStat As eConnectState)

    'Message
    Const WM_USER = &H400
    Const WM_HSMSTIMEOUT = WM_USER + 1

    Dim HSMSThread As Thread
    Private WithEvents ThradChk As New System.Timers.Timer

#Region "Property setting"

    Public Property zSECSName() As String
        Get
            zSECSName = mvarSECSName
        End Get
        Set(ByVal value As String)
            mvarSECSName = value
        End Set
    End Property

    Public Property zTCPIPAddress() As String
        Get
            zTCPIPAddress = m_strIPAddress
        End Get
        Set(ByVal value As String)
            m_strIPAddress = value
        End Set
    End Property

    Public Property zTCPPort() As Integer
        Get
            zTCPPort = m_nPortNum
        End Get
        Set(ByVal value As Integer)
            m_nPortNum = value
        End Set
    End Property

    Public Property zDeviceID() As Integer
        Get
            zDeviceID = CInt(mvarDeviceID)
        End Get
        Set(ByVal value As Integer)
            mvarDeviceID = CStr(value)
        End Set
    End Property

    Public Property zTCPMode() As eTCPMode
        Get
            If m_fPassive Then
                zTCPMode = eTCPMode.Passive
            Else
                zTCPMode = eTCPMode.Active
            End If
        End Get
        Set(ByVal value As eTCPMode)
            If value = eTCPMode.Active Then
                m_fPassive = False
            Else
                m_fPassive = True
            End If
        End Set
    End Property

    Public Property zLogPath() As String
        Get
            zLogPath = mvarLogPath
        End Get
        Set(ByVal value As String)
            mvarLogPath = value
        End Set
    End Property

    Public Property zLogRawdata() As Integer
        Get
            If mvarLogRawData Then
                zLogRawdata = 1
            Else
                zLogRawdata = 0
            End If
        End Get
        Set(ByVal value As Integer)
            If value = 0 Then
                mvarLogRawData = False
            Else
                mvarLogRawData = True
            End If
        End Set
    End Property

    Public Property zLogContrlMsg() As Integer
        Get
            If mvarLogCtlMsg Then
                zLogContrlMsg = 1
            Else
                zLogContrlMsg = 0
            End If
        End Get
        Set(ByVal value As Integer)
            If value = 0 Then
                mvarLogCtlMsg = False
            Else
                mvarLogCtlMsg = True
            End If

        End Set
    End Property

    Public Property zT3() As Integer
        Get
            zT3 = mvarT3
        End Get
        Set(ByVal value As Integer)
            mvarT3 = value
        End Set
    End Property

    Public Property zT5() As Integer
        Get
            zT5 = mvarT5
        End Get
        Set(ByVal value As Integer)
            mvarT5 = value
        End Set
    End Property

    Public Property zT6() As Integer
        Get
            zT6 = mvarT6
        End Get
        Set(ByVal value As Integer)
            mvarT6 = value
        End Set
    End Property

    Public Property zT7() As Integer
        Get
            zT7 = mvarT7
        End Get
        Set(ByVal value As Integer)
            mvarT7 = value
        End Set
    End Property

    Public Property zT8() As Integer
        Get
            zT8 = mvarT8
        End Get
        Set(ByVal value As Integer)
            mvarT8 = value
        End Set
    End Property

    Public Property zLinkInterval() As Integer
        Get
            zLinkInterval = mvarLinkInterval
        End Get
        Set(ByVal value As Integer)
            mvarLinkInterval = value

        End Set
    End Property

    Public ReadOnly Property ReceiveCount() As Integer
        Get
            ReceiveCount = MyRecQue.Count
        End Get
    End Property

    Public ReadOnly Property ReceiveQueue() As Queue(Of clsSECSMessage)
        Get
            ReceiveQueue = MyRecQue
        End Get
    End Property

    Public Property ConnectStatus() As eConnectState
        Get
            ConnectStatus = mvarConnectStat
        End Get
        Set(ByVal value As eConnectState)
            mvarConnectStat = value        
        End Set
    End Property

#End Region

    Public Overrides Sub TCPLoop()
        Dim nDataLen As ULong
        Dim btyRevBuf1(0) As Byte
        Dim btyRevBuf2(0) As Byte

        While Not m_fStop
            If m_eConnectState < eConnectState.Opened Then
                If m_fPassive Then
                    If m_eConnectState = eConnectState.Listen Then
                        m_ClientSocket = m_ServerSocket.Accept
                        m_eConnectState = eConnectState.Opened
                    Else
                        'Server Socket is not Listening
                        If ServerListen() Then m_eConnectState = eConnectState.Listen
                    End If
                Else
                    If ClientConnect() Then
                        m_eConnectState = eConnectState.Opened
                    Else
                        m_eConnectState = eConnectState.Opening
                        ConnectStatus = eConnectState.Opening
                    End If
                End If
            Else
                '建立TCP 連線

                If m_eConnectState = eConnectState.Opened AndAlso Not m_fPassive Then SendSelReq()

                'If m_eConnectState = eConnectState.Connected Then
                ReadSocket(btyRevBuf1, 4)

                If btyRevBuf1.Length = 4 Then
                    nDataLen = CULng(btyRevBuf1(0)) * &H1000000 + CLng(btyRevBuf1(1)) * &H10000 + CLng(btyRevBuf1(2)) * &H100 + CLng(btyRevBuf1(3))
                    Me.ReadSocket(btyRevBuf2, nDataLen)
                    If btyRevBuf2.Length > 0 Then PackRecData(btyRevBuf2, nDataLen)
                End If
                'End If
            End If

            If m_eConnectState = eConnectState.Connected OrElse m_eConnectState = eConnectState.Opened Then
                If Not IsConnected(m_nPortNum) Then
                    CloseSocket()
                End If
                If ConnectStatus <> m_eConnectState Then ConnectStatus = m_eConnectState
            End If

            If Not ThradChk.Enabled Then ThradChk.Enabled = True

            Thread.Sleep(10)
        End While

    End Sub

    Private Sub ThradChk_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles ThradChk.Elapsed
        If MyBase.TCPThread.IsAlive = False Then
            TCPThread = Nothing
            InitialTCP(m_strIPAddress, m_nPortNum, m_fPassive)
        End If
    End Sub

    Private Sub HSMSLoop()
        While Not m_fStop

            If MySendQue.Count > 0 Then
                SyncLock Me
                    SendMessage(MySendQue.Dequeue)
                    CheckT3Timeout()
                    IntervalLinkTest()
                End SyncLock
            End If
            System.GC.Collect()
            Thread.Sleep(40) 'Modify By William 2010/10/11
        End While

    End Sub

    Public Sub Fn_AddSendMessage(ByVal Message As clsSECSMessage)
        MySendQue.Enqueue(Message)
    End Sub

    Public Function Fn_IncSysByte() As ULong
        If mvarLocalSysByte > 10000 Then
            mvarLocalSysByte = 0
        End If

        mvarLocalSysByte = mvarLocalSysByte + 1
        Return mvarLocalSysByte
    End Function

    Public Sub Fn_Close()
        SendSeparate()
        Thread.Sleep(50)
        m_fStop = True
        HSMSThread.Abort()
        CloseSocket()
    End Sub

    Private Sub PackRecData(ByVal Receive() As Byte, ByVal nLength As Integer)
        Dim lngLenIndex As Long = 10
        Dim ArraySize As Integer
        Dim nFor As Integer = 10
        Dim strHeader As String = ""

        Dim SECSBodyArrayTemp As New List(Of clsSECSBody)


        Dim RecMsgTag As New clsSECSMessage(CByte(Receive(2) And &H7F), CULng(Receive(3)))

        RecMsgTag.MessageHeader.DeviceID = CUInt(Receive(0) + CUInt(Receive(1)) * &H100)
        RecMsgTag.MessageHeader.PType = Receive(4)
        RecMsgTag.MessageHeader.SType = Receive(5)
        RecMsgTag.MessageHeader.WaitBit = Convert.ToBoolean(Receive(2) And &H80)

        RecMsgTag.MessageHeader.SystemByte = CLng(CLng(Receive(6)) * &H1000000 + CLng(Receive(7)) * &H10000 + CLng(Receive(8)) * &H100 + CLng(Receive(9)))

        For nFor = 0 To 9
            If nFor <> 9 Then
                strHeader = strHeader & CStr(Receive(nFor)) & "-"
            Else
                strHeader = strHeader & CStr(Receive(nFor))
            End If
        Next
        RecMsgTag.MessageHeader.HeaderByte = strHeader

        Select Case Receive(5)

            Case SECSDATA_NO ' receive data
                m_eConnectState = eConnectState.Connected
            Case SELECTREQ_NO ' Select.Req
                m_eConnectState = eConnectState.Connected
                RecMsgTag.Fn_SetMessageID("SelectReq")
                SendSelRsp(RecMsgTag.MessageHeader.SystemByte)
            Case SELECTRSP_NO 'Select.Rsp
                m_eConnectState = eConnectState.Connected
                RecMsgTag.Fn_SetMessageID("SelectRsp")
            Case LINKREQ_NO 'Link.Req
                m_eConnectState = eConnectState.Connected
                RecMsgTag.Fn_SetMessageID("LinkReq")
                SendLinkRsp(RecMsgTag.MessageHeader.SystemByte)

            Case LINKRSP_NO 'Link.Rsp
                m_eConnectState = eConnectState.Connected
                RecMsgTag.Fn_SetMessageID("LinkRsp")
            Case REJECTREQ_NO 'Reject.Req
                m_eConnectState = eConnectState.Connected
                RecMsgTag.Fn_SetMessageID("RejectReq")
            Case SEPARATER_NO 'Seperate.Req
                Me.CloseSocket()
                RecMsgTag.Fn_SetMessageID("SeparateReq")
        End Select

        If Receive(5) = SECSDATA_NO Then
            Dim lngIdx As ULong
            While lngLenIndex < nLength
                Dim SECSBodyTemp As New clsSECSBody
                lngIdx = lngIdx + 1
                Select Case (Receive(lngLenIndex))
                    Case LIST_NO 'When List With NLB will not be 0x1 it will failed.

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.LIST
                        SECSBodyTemp.List = Receive(lngLenIndex + 1)
                        lngLenIndex = lngLenIndex + 2
                    Case BINARY_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.BINARY
                        SECSBodyTemp.ItemSize = ArraySize

                        If (ArraySize > 0) Then
                            SECSBodyTemp.ItemValue = BitConverter.ToString(Receive, CInt(lngLenIndex + 2), ArraySize)
                            lngLenIndex = lngLenIndex + Receive(lngLenIndex + 1) + 2
                        End If
                    Case I1_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.I1
                        SECSBodyTemp.ItemValue = Encoding.UTF8.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case U1_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.U1
                        SECSBodyTemp.ItemValue = Encoding.UTF8.GetString(Receive, CInt(lngLenIndex), ArraySize)
                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case I2_NO

                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.I2
                        SECSBodyTemp.ItemValue = Encoding.UTF8.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case U2_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.U2
                        SECSBodyTemp.ItemValue = Encoding.UTF8.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case I4_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.I4
                        SECSBodyTemp.ItemValue = Encoding.UTF32.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case U4_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.U4
                        SECSBodyTemp.ItemValue = Encoding.UTF32.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case I8_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.I8
                        SECSBodyTemp.ItemValue = Encoding.UTF32.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case U8_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.U8
                        SECSBodyTemp.ItemValue = Encoding.UTF32.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case F4_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.F4
                        SECSBodyTemp.ItemValue = Encoding.UTF32.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case F8_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.F8
                        SECSBodyTemp.ItemValue = Encoding.UTF32.GetString(Receive, CInt(lngLenIndex), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case ASC1_NO
                        ArraySize = Receive(lngLenIndex + 1)

                        SECSBodyTemp.ItemIdx = lngIdx
                        SECSBodyTemp.FormateCode = eFormatCode.ASCII
                        SECSBodyTemp.ItemSize = ArraySize
                        SECSBodyTemp.ItemValue = Encoding.UTF8.GetString(Receive, CInt(lngLenIndex + 2), ArraySize)

                        lngLenIndex = lngLenIndex + ArraySize + 2
                    Case Else

                End Select

                If lngLenIndex > nLength Then
                    'Data Too Long  Err Send S9F11
                    GoTo S9F11Handle
                End If
                SECSBodyArrayTemp.Add(SECSBodyTemp)
            End While
            RecMsgTag.MessageBody = SECSBodyArrayTemp
        End If



        MyRecQue.Enqueue(RecMsgTag)
        RemoveT3Element(RecMsgTag)
        Exit Sub
S9F11Handle:
        'S9F11 Data Too Long
        Dim SECSBodyArrayErr As New List(Of clsSECSBody)
        Dim SECSBodyErr As New clsSECSBody
        SECSBodyErr.ItemIdx = 1
        SECSBodyErr.FormateCode = eFormatCode.S9F11
        SECSBodyErr.ItemSize = 0
        SECSBodyErr.ItemValue = ""
        SECSBodyArrayErr.Add(SECSBodyErr)
        RecMsgTag.MessageBody = SECSBodyArrayErr
        MyRecQue.Enqueue(RecMsgTag)
        RemoveT3Element(RecMsgTag)


    End Sub

    Public Sub SaveRecLog(ByRef LogMsg As clsSECSMessage, ByVal StreamType As eStreamType)
        MyLogger.MakeLog(LogMsg, eStreamType.TYPE_GET)
    End Sub

    Private Function String_To_Bytes(ByVal strInput As String) As Byte
        Dim bytes As Byte

        Dim lngDecimal As Long = Convert.ToInt32(strInput.Substring(0, 2), 16)
        bytes = Convert.ToByte(lngDecimal)

        Return bytes
    End Function

    Private Sub SendMessage(ByVal SendMsg As clsSECSMessage)
        Dim ByteTemp = New List(Of Byte)
        Dim btySendLen(4) As Byte
        Dim btySendArr() As Byte
        Dim nFor As Integer = 0
        Dim nLoop As Integer = 0
        Dim vGet() As String
       

        ByteTemp.AddRange(HeadToByte(SendMsg.MessageHeader))

        If m_eConnectState = eConnectState.Connected Or SendMsg.MessageHeader.SType <> 0 Then
            If Not SendMsg.MessageBody Is Nothing Then
                If SendMsg.MessageBody.Count > 0 Then
                    For nFor = 0 To SendMsg.MessageBody.Count - 1
                        Select Case SendMsg.MessageBody(nFor).FormateCode
                            Case eFormatCode.ASCII
                                ByteTemp.Add(ASC1_NO)
                                ByteTemp.Add(CByte(SendMsg.MessageBody(nFor).ItemSize))
                                ByteTemp.AddRange(Encoding.UTF8.GetBytes(SendMsg.MessageBody(nFor).ItemValue))
                            Case eFormatCode.LIST
                                ByteTemp.Add(LIST_NO)
                                ByteTemp.Add(CByte(SendMsg.MessageBody(nFor).List))
                            Case eFormatCode.BINARY
                                ByteTemp.Add(BINARY_NO)
                                ByteTemp.Add(CByte(SendMsg.MessageBody(nFor).ItemSize))
                                vGet = Split(SendMsg.MessageBody(nFor).ItemValue, "-")

                                For nLoop = 0 To SendMsg.MessageBody(nFor).ItemSize - 1

                                    ByteTemp.Add(String_To_Bytes(vGet(nLoop)))
                                Next nLoop
                            Case eFormatCode.I1
                                ByteTemp.Add(I1_NO)
                            Case eFormatCode.U1
                                ByteTemp.Add(U1_NO)
                            Case eFormatCode.I2
                                ByteTemp.Add(I2_NO)
                            Case eFormatCode.U2
                                ByteTemp.Add(U2_NO)
                            Case eFormatCode.I4
                                ByteTemp.Add(I4_NO)
                            Case eFormatCode.U4
                                ByteTemp.Add(U4_NO)
                            Case eFormatCode.I8
                                ByteTemp.Add(I8_NO)
                            Case eFormatCode.U8
                                ByteTemp.Add(U8_NO)
                            Case eFormatCode.F4
                                ByteTemp.Add(F4_NO)
                            Case eFormatCode.F8
                                ByteTemp.Add(F8_NO)
                        End Select
                    Next
                End If
            End If



            btySendArr = ByteTemp.ToArray
            btySendLen = LongToBytes(CULng(btySendArr.Length))

            If SendMsg.MessageHeader.SType = 0 Or mvarLogCtlMsg Then
                MyLogger.MakeLog(SendMsg, btySendArr, eStreamType.TYPE_SEND)
            End If

            SendSocket(btySendLen, 4)
            SendSocket(btySendArr, btySendArr.Length)
        
            If SendMsg.MessageHeader.WaitBit = True Then
                AddT3Array(SendMsg)
            End If
        End If
    End Sub

    Private Sub AddT3Array(ByRef SendTag As clsSECSMessage)
        Dim Temp As T3Body

        If SendTag.MessageHeader.SType = 0 And SendTag.MessageHeader.FunctionID Mod 2 = 1 Then
            Temp.lngT3_Time = System.DateTime.Now.Ticks
            Temp.MsgTag = SendTag
            MyT3.Add(Temp)
        End If
    End Sub

    Private Sub RemoveT3Element(ByRef T3Info As clsSECSMessage)
        Dim nFor As Integer = 0
        Try

            SyncLock MyT3
Recheck:
                If MyT3.Count > 0 Then
                    For nFor = 0 To MyT3.Count - 1
                        If MyT3(nFor).MsgTag.MessageHeader.SystemByte = T3Info.MessageHeader.SystemByte Then
                            MyT3.RemoveAt(nFor)
                            GoTo Recheck
                        End If
                    Next
                End If
            End SyncLock
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckT3Timeout()
        Dim lngTickNow As ULong = System.DateTime.Now.Ticks
        Dim lngTickTemp As ULong
        Dim nFor As Integer
        Dim strErrInfo As String = ""
        Dim MyHeaderByte(9) As Byte
        Dim nHeaderByte As Integer = 0
        On Error Resume Next
Recheck:
        For nFor = 0 To MyT3.Count - 1
            If MyT3.Count > 0 Then
                strErrInfo = ""
                lngTickTemp = (MyT3(nFor).lngT3_Time + Math.Pow(10, 7) * mvarT3)
                If lngTickNow > lngTickTemp Then
                    strErrInfo = System.DateTime.Now.ToString & " " & _
                   (MyT3(nFor).MsgTag.MessageID & _
                    " T3 TimeOut SystemByte:" & _
                    MyT3(nFor).MsgTag.MessageHeader.SystemByte.ToString)

                    ShowErrorLog(strErrInfo)
                    MyT3.RemoveAt(nFor)

                    SendPrivateS9F9(MyT3(nFor).MsgTag.MessageHeader.ToString)
                    GoTo Recheck
                End If
            End If
        Next
    End Sub

    Private Sub ShowErrorLog(ByVal strError As String)
        MyLog.WriteLog(strError)
    End Sub

    Private Sub IntervalLinkTest()
        If System.DateTime.Now.Ticks > MyLinkTickBuffer + mvarLinkInterval * Math.Pow(10, 7) And m_eConnectState = eConnectState.Connected Then
            SendLinkReq()
            MyLinkTickBuffer = System.DateTime.Now.Ticks
        End If
    End Sub
   
    Private Function HeadToByte(ByVal Header As clsSECSHead) As Byte()
        Dim nFor As Integer
        Dim btyHeater(9) As Byte
        For nFor = 0 To 9
            btyHeater(nFor) = New Byte
        Next

        If Header.SType = 0 Then
            btyHeater(0) = Byte.Parse((Header.DeviceID \ &H100).ToString)
            btyHeater(1) = Byte.Parse((Header.DeviceID Mod &H100).ToString)
        Else
            btyHeater(0) = &HFF
            btyHeater(1) = &HFF
        End If

        btyHeater(2) = (CByte(Header.WaitBit) And &H80) + Header.StreamID
        btyHeater(3) = Header.FunctionID
        btyHeater(4) = 0
        btyHeater(5) = Header.SType

        Array.Copy(LongToBytes(Header.SystemByte), 0, btyHeater, 6, 4)
        Return btyHeater
    End Function


    Private Function GetIntSystemByte(ByVal Bytes() As Byte) As ULong
        Dim ulngSystemByte As ULong = 0
        If Bytes.Length = 4 Then
            ulngSystemByte = ULong.Parse(CULng(0) * &H1000000 + CLng(Bytes(1)) * &H10000 + CLng(Bytes(2)) * &H100 + CLng(Bytes(3))).ToString
        End If
        Return ulngSystemByte
    End Function

    Private Function LongToBytes(ByVal LongData As ULong) As Byte()
        Dim nFor As Integer
        Dim btyBytes(3) As Byte
        Dim ulngTemp1 As ULong
        Dim ulngTemp2 As ULong

        For nFor = 0 To 3
            btyBytes(nFor) = New Byte
        Next

        ulngTemp1 = LongData \ &H10000
        ulngTemp2 = LongData Mod &H10000
        btyBytes(0) = CByte(ulngTemp1 \ &H100)
        btyBytes(1) = CByte(ulngTemp1 Mod &H100)
        btyBytes(2) = CByte(ulngTemp2 \ &H100)
        btyBytes(3) = CByte(ulngTemp2 Mod &H100)
        Return btyBytes
    End Function

    Private Sub SendSelReq()
        Dim SelectReq As New clsSECSMessage
        SelectReq.Fn_SetMessageID("SelectReq")
        SelectReq.MessageHeader.SType = &H1
        SelectReq.MessageHeader.SystemByte = mvarLocalSysByte + 1
        MySendQue.Enqueue(SelectReq)
    End Sub

    Private Sub SendSelRsp(ByVal SysByte As ULong)
        Dim SelectRsp As New clsSECSMessage
        SelectRsp.Fn_SetMessageID("SelectRsp")
        SelectRsp.MessageHeader.SType = &H2
        SelectRsp.MessageHeader.SystemByte = SysByte
        MySendQue.Enqueue(SelectRsp)
    End Sub

    Private Sub SendLinkReq()
        Dim LinkReq As New clsSECSMessage
        LinkReq.Fn_SetMessageID("LinkReq")
        LinkReq.MessageHeader.SType = &H5
        LinkReq.MessageHeader.SystemByte = mvarLocalSysByte + 1
        MySendQue.Enqueue(LinkReq)
    End Sub

    Private Sub SendLinkRsp(ByVal SysByte As ULong)
        Dim LinkRsp As New clsSECSMessage
        LinkRsp.Fn_SetMessageID("LinkReq")
        LinkRsp.MessageHeader.SType = &H6
        LinkRsp.MessageHeader.SystemByte = SysByte
        MySendQue.Enqueue(LinkRsp)
    End Sub

    Private Sub SendSeparate()
        Dim SeparateReq As New clsSECSMessage
        SeparateReq.Fn_SetMessageID("SeparateReq")
        SeparateReq.MessageHeader.SType = &H9
        SeparateReq.MessageHeader.SystemByte = mvarLocalSysByte + 1
        MySendQue.Enqueue(SeparateReq)
    End Sub

    Private Sub SendPrivateS9F9(ByVal MSGHeader As String)
        Dim SeparateReq As New clsSECSMessage
        SeparateReq.MessageHeader.SystemByte = mvarLocalSysByte + 1

        Dim PrivateS9F9 As New clsSECSMessage(9, 9, False, SeparateReq.MessageHeader.SystemByte)
        Dim vByte(9) As Byte
        Dim strByte(9) As String
        Dim nFor As Integer = 0

        strByte = Split(MSGHeader, "-")
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

        PrivateS9F9.Fn_Add_Binary(vByte, 10, "SHEAD")
        MySendQue.Enqueue(PrivateS9F9)
    End Sub

    Public Sub New()
        MyLog.InitLogObj("SEMI")
    End Sub

    Public Sub New(ByVal strName As String)
        
    End Sub

    Public Sub InitialHSMS(ByVal strName As String)
        mvarSECSName = strName

        InitialTCP()
        MyLogger.Initial(mvarSECSName, mvarLogPath, mvarLogRawData)

        Dim starter As New ThreadStart(AddressOf HSMSLoop)
        m_fStop = False
        HSMSThread = New Thread(starter)

        HSMSThread.Start()
        ThradChk.Interval = 1000
        ThradChk.Enabled = True

    End Sub
End Class