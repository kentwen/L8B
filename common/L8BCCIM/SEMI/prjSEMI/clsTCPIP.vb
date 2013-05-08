Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Net.NetworkInformation
Imports System.Timers

Public Enum eConnectState
    None = 0
    Listen
    Opening
    Opened
    Connected
End Enum


Public Class clsTCPIP
    Private WithEvents ThradChk As System.Timers.Timer



#Region "Define parameter"
    Protected m_fPassive As Boolean
    Protected m_nPortNum As Integer
    Protected m_strIPAddress As String
    Protected m_eConnectState As eConnectState
    Protected m_ServerSocket As Socket
    Protected m_ClientSocket As Socket
    Protected TCPThread As Thread
    Protected m_fStop As Boolean

    Private LocalIPProperty As IPGlobalProperties
    Private LocalTCPConnectionInfo As TcpConnectionInformation()
#End Region

    Public Overridable Sub TCPLoop()

        'While Not m_fStop
        '    If m_eConnectState < eConnectState.Connected Then

        '        If m_fPassive Then 'Server端
        '            'Server side listening or not
        '            If m_eConnectState = eConnectState.Listen Then
        '                m_ClientSocket = m_ServerSocket.Accept
        '                m_eConnectState = eConnectState.Connected
        '            Else
        '                If ServerListen() Then m_eConnectState = eConnectState.Listen
        '            End If
        '        Else 'Client端
        '            If m_eConnectState < eConnectState.Connected Then
        '                If ClientConnect() Then
        '                    m_eConnectState = eConnectState.Connected
        '                Else
        '                    m_eConnectState = eConnectState.Opening
        '                End If
        '            End If
        '        End If
        '    End If

        '    If m_eConnectState = eConnectState.Connected Then
        '        If Not IsConnected(m_nPortNum) Then CloseSocket()
        '    End If
        '    Thread.Sleep(100)
        'End While
    End Sub

    Protected Function ReadSocket(ByRef MyBuffer() As Byte) As Integer
        Dim nRecLen As Integer = -1
        Dim MyRecByte(1941) As Byte

        If m_eConnectState = eConnectState.Connected Then
            Try
                nRecLen = m_ClientSocket.Receive(MyRecByte)
                ReDim MyBuffer(nRecLen)
                Array.Copy(MyRecByte, MyBuffer, nRecLen)
                If nRecLen = 0 Then
                    nRecLen = -1
                    CloseSocket()
                End If
            Catch ex As Exception
                nRecLen = -1
            End Try
        End If

        Return nRecLen
    End Function

    Protected Function ReadSocket(ByRef MyBuffer() As Byte, ByRef nReqLen As Long)
        Dim nGotLen As Integer = 0
        Dim nTCPLen As Integer = 0
        Dim nRemainLen As Integer = nReqLen
        Dim RecByte(1000) As Byte
        ReDim MyBuffer(nReqLen - 1)
        ReDim RecByte(nReqLen - 1)

        Do
            Try
                
                nTCPLen = m_ClientSocket.Receive(RecByte, nRemainLen, SocketFlags.None)

                If nTCPLen > 0 Then
                    Array.Copy(RecByte, 0, MyBuffer, nGotLen, nTCPLen)
                    nGotLen += nTCPLen
                    nRemainLen = nReqLen - nGotLen
                ElseIf nTCPLen = 0 Then
                    nGotLen = -1
                    CloseSocket()
                    Return nGotLen
                End If
            Catch ex As SocketException
                nGotLen = -1
                Return nGotLen
            Catch ex As Exception
                nGotLen = -1
                Return nGotLen
            End Try
        Loop While nGotLen < nReqLen

        Return nGotLen
    End Function

    Protected Function SendSocket(ByVal SendByte() As Byte, ByVal nSize As Integer) As Integer
        Dim nSendLen As Integer = 0

        Try
            nSendLen = m_ClientSocket.Send(SendByte, nSize, SocketFlags.None)
        Catch ex As SocketException
            nSendLen = -1
        Catch ex As Exception
            nSendLen = -1
        End Try
        Return nSendLen
    End Function

    Public Sub InitialTCP(ByVal strIPAddress As String, ByVal nPortNo As Integer, ByVal fPassive As Boolean)
        m_strIPAddress = strIPAddress
        m_nPortNum = nPortNo
        m_fPassive = fPassive

        Dim starter As New ThreadStart(AddressOf Me.TCPLoop)

        TCPThread = New Thread(starter)
        TCPThread.Start()
        TCPThread.Join(10)

    End Sub

    Public Sub InitialTCP()
        Dim starter As New ThreadStart(AddressOf Me.TCPLoop)

        TCPThread = New Thread(starter)
        TCPThread.Start()
        TCPThread.Join(10)
    End Sub

    Protected Function ServerListen() As Boolean
        Try
            m_ServerSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            m_ServerSocket.Bind(New IPEndPoint(IPAddress.Parse(m_strIPAddress), m_nPortNum))
            m_ServerSocket.Listen(10)
            Return True
        Catch ex As Exception
            m_ServerSocket = Nothing
            System.GC.Collect()
            Thread.Sleep(100)
            Return False
        End Try
    End Function

    Protected Function ClientConnect() As Boolean
        Try
            m_eConnectState = eConnectState.Opening
            m_ClientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            m_ClientSocket.Connect(IPAddress.Parse(m_strIPAddress), m_nPortNum)

            Return True
        Catch eee As SocketException
            m_ClientSocket = Nothing
            System.GC.Collect()
            Thread.Sleep(1000)
            Return False
        Catch ex As Exception
            m_ClientSocket = Nothing
            System.GC.Collect()
            Thread.Sleep(1000)
            Return False

        End Try
    End Function

    Protected Function IsConnected(ByVal nPortNo As Integer) As Boolean
        Dim fConnected As Boolean
        Dim TCPInfo As TcpConnectionInformation

        LocalIPProperty = IPGlobalProperties.GetIPGlobalProperties
        LocalTCPConnectionInfo = LocalIPProperty.GetActiveTcpConnections


        If LocalTCPConnectionInfo.Length > 0 Then
            For Each TCPInfo In LocalTCPConnectionInfo
                If TCPInfo.State = TcpState.Established And TCPInfo.RemoteEndPoint.Port = nPortNo Then
                    fConnected = True
                    Exit For
                End If
            Next
        End If
        Return fConnected
    End Function

    Protected Sub CloseSocket()

        m_ClientSocket.Close()
        If m_fPassive Then
            m_eConnectState = eConnectState.Listen
        Else
            m_eConnectState = eConnectState.Opening
        End If
        Thread.Sleep(2000)
    End Sub

    Public Function GetConnectStatusByString() As String
        Return m_eConnectState.ToString
    End Function

    Public Function GetConnectStatusByInt() As Integer
        Return m_eConnectState
    End Function
End Class
