Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Module ModuleRobotMonitor

    Public WithEvents SocketServer As New AsynchronousSocketListener
    Public Const ServerPort = 2001

    Public Sub InitRobotMonitor()
        _L8B.RobotMon = SocketServer
        _L8B.RobotMon.Initial("127.0.0.1")
    End Sub


    Private Sub SocketServer_DataReceive(ByVal handler As System.Net.Sockets.Socket, ByVal Data As String) Handles SocketServer.DataReceive
        If Data.Contains("RobotInfoRequest") Then
            _L8B.RobotMon.Send(handler, RobotInfo)
        End If
    End Sub


    Private Function RobotInfo() As String
        Return String.Format("Alarm={0}" & vbCrLf & _
                             "MileageAxis1={1}" & vbCrLf & _
                             "MileageAxis2={2}" & vbCrLf & _
                             "MileageAxis3={3}" & vbCrLf & _
                             "MileageAxis4={4}" & vbCrLf & _
                             "MileageAxis5={5}" & vbCrLf & _
                             "MileageAxis6={6}", _
                             _L8B.PLC.GetRobotAlarm, _
                             _L8B.PLC.Mileage(1).ToString, _
                             _L8B.PLC.Mileage(2).ToString, _
                             _L8B.PLC.Mileage(3).ToString, _
                             _L8B.PLC.Mileage(4).ToString, _
                             _L8B.PLC.Mileage(5).ToString, _
                             _L8B.PLC.Mileage(6).ToString)

    End Function

    Public Class StateObject
        ' Client  socket.
        Public workSocket As Socket = Nothing
        ' Size of receive buffer.
        Public Const BufferSize As Integer = 1024
        ' Receive buffer.
        Public buffer(BufferSize) As Byte
        'To-Do: Make a reference to some playerdata
    End Class 'StateObject



    Public Class AsynchronousSocketListener
        Private WithEvents TimerCheck As New System.Timers.Timer
        ' Thread signal.
        Public allDone As New ManualResetEvent(False)
        'Mutex
        Private mut As New Mutex()
        'Clients
        Public clients As New List(Of StateObject)
        Public mainThread As Thread
        Private HostIP As String

        Public Event DataReceive(ByVal handler As Socket, ByVal Data As String)

        Delegate Sub WriteToLogDelegate(ByVal entry As String)

        Public Sub Initial(ByVal mHostIP As String) 'ByRef log_ As TextBox)
            WriteLog("[Listener]Asynchronous server socket initializing")
            HostIP = mHostIP
            mainThread = New Thread(AddressOf StartListener)
            mainThread.Start()
        End Sub

        '20100108   server IP address no set ->IPAddress.Any
        Public Sub StartListener()
            ' Data buffer for incoming data.
            Dim bytes() As Byte = New [Byte](1023) {}
            Dim localEndPoint As New IPEndPoint(IPAddress.Any, ServerPort)

            ' Create a TCP/IP socket.
            Dim listener As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            ' Bind the socket to the local endpoint and listen for incoming connections.
            listener.Bind(localEndPoint)
            listener.Listen(100)

            While True
                ' Set the event to nonsignaled state.
                allDone.Reset()

                ' Start an asynchronous socket to listen for connections.
                WriteLog("[Listener]Waiting for a connection...")
                listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)
                ' Wait until a connection is made and processed before continuing.
                allDone.WaitOne()
            End While
        End Sub 'Main


        Public Sub AcceptCallback(ByVal ar As IAsyncResult)
            ' Get the socket that handles the client request.
            Dim listener As Socket = CType(ar.AsyncState, Socket)
            ' End the operation.
            Dim handler As Socket = listener.EndAccept(ar)

            ' Create the state object for the async receive.
            Dim state As New StateObject
            state.workSocket = handler
            state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
            'Add the client socket to a list for easy reference: Note: Not sure if the mutex is necessary
            mut.WaitOne()
            SyncLock clients
                clients.Add(state)
            End SyncLock
            mut.ReleaseMutex()

            WriteLog("[Listener] Connection to " & state.workSocket.RemoteEndPoint.ToString)

            'Signal the main thread to continue.
            allDone.Set()
        End Sub 'AcceptCallback

        'state.workSocket.BeginDisconnect(True, New AsyncCallback(AddressOf AcceptDisconnect), state)

        Public Sub AcceptDisconnect(ByVal ar As IAsyncResult)
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim handler As Socket = state.workSocket
            WriteLog("[Listener] AcceptDisconnect " & handler.RemoteEndPoint.ToString)
            clients.Remove(state)
        End Sub

        Public Sub ReceiveCallback(ByVal ar As IAsyncResult)
            Dim content As String = String.Empty
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim handler As Socket = state.workSocket

            Try
                ' Retrieve the state object and the handler socket
                ' from the asynchronous state object.

                ' Read data from the client socket. 

                If handler.Connected Then
                    Dim bytesRead As Integer = handler.EndReceive(ar)

                    If bytesRead > 0 Then
                        ' There  might be more data, so store the data received so far.
                        content = Encoding.ASCII.GetString(state.buffer, 0, bytesRead)

                        'Send the Security Policy Data If Flash 9 Requests it
                        'Dim policyFileNeeded As Boolean = False
                        'If content.Length >= 22 Then
                        '    If content.Substring(0, 22) = "<policy-file-request/>" Then
                        '        WriteToLog("Policy File Sent")
                        '        '<?xml version=" & Chr(34) & "1.0" & Chr(34) & "?><!DOCTYPE cross-domain-policy SYSTEM " & Chr(34) & "http://www.adobe.com/xml/dtds/cross-domain-policy.dtd" & Chr(34) & ">
                        '        Send(handler, "<cross-domain-policy><allow-access-from domain=" & Chr(34) & "*" & Chr(34) & "to-ports=" & Chr(34) & "30303" & Chr(34) & "/></cross-domain-policy>")
                        '        policyFileNeeded = True
                        '    End If
                        'End If
                        'If Not policyFileNeeded Then
                        '    WriteToLog("Data Received: " & content)
                        '    Send(handler, "Data Received")
                        'End If
                        WriteLog("[Listener] Data Receive from " & handler.RemoteEndPoint.ToString & " Data:{" & content & "}")
                        RaiseEvent DataReceive(handler, content)

                        'Begin waiting to receive on the socket
                    End If
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
                Else
                    'SyncLock clients
                    '    clients.Remove(state)
                    'End SyncLock
                End If
            Catch ex As Exception
                'SyncLock clients
                '    clients.Remove(state)
                'End SyncLock
                WriteLog(ex.ToString)
            End Try
        End Sub 'ReceiveCallback

        Public Sub Send(ByVal handler As Socket, ByVal data As String)
            ' Convert the string data to byte data using ASCII encoding.
            Dim byteData As Byte() = Encoding.ASCII.GetBytes(data)

            WriteLog("[Listener] Data Sent:{" & data & "} to " & handler.RemoteEndPoint.ToString)
            ' Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), handler)
        End Sub 'Send

        Private Sub SendCallback(ByVal ar As IAsyncResult)
            ' Retrieve the socket from the state object.
            Dim handler As Socket = CType(ar.AsyncState, Socket)

            ' Complete sending the data to the remote device.
            Dim bytesSent As Integer = handler.EndSend(ar)
            'Console.WriteLine("Sent {0} bytes to client.", bytesSent)

            WriteLog("[Listener] Data Sent Bytes: " & bytesSent)

            'handler.Shutdown(SocketShutdown.Both)
            'handler.Close()

            'I HAVE NO IDEA WHERE TO PUT THIS allDone.Set()
            'Signal the main thread to continue.
            'allDone.Set()
        End Sub 'SendCallback

        'Public Sub PingAllClients()
        '    'Not sure if the mutex is necessary
        '    mut.WaitOne()
        '    For i As UInteger = 0 To clients.Count - 1
        '        Send(clients(i).workSocket, "ping")
        '    Next
        '    mut.ReleaseMutex()
        'End Sub 'PingAllClients

        Private Sub TimerCheck_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles TimerCheck.Elapsed
            Try
                SyncLock clients
                    Try
                        For Each mClient As StateObject In clients
                            If Not mClient.workSocket.Connected Then
                                WriteLog("clients Disconnect " & mClient.workSocket.RemoteEndPoint.ToString)
                                clients.Remove(mClient)
                            End If
                        Next
                    Catch ex As Exception
                        Debug.Print(ex.ToString)
                    End Try

                End SyncLock
            Catch ex As Exception
                Debug.Print(ex.ToString)
            End Try

        End Sub
    End Class 'AsynchronousSocketListener
End Module
