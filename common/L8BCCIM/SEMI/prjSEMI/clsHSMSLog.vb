Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO

Public Class clsHSMSLog
    Private mvarLogPath As String
    Private mvarSECSName As String
    Private mvarLogRawData As Boolean
    Private mvarLogString As String

    Public Event LogReport(ByVal strLog As String)

    Public Sub Initial(ByVal SECSName As String, ByVal LogPath As String, ByVal LogRawData As Boolean)
        mvarLogPath = LogPath
        mvarSECSName = SECSName
        mvarLogRawData = LogRawData
    End Sub

    Public Sub MakeLog(ByRef LogMsg As clsSECSMessage, ByRef RawData() As Byte, ByVal StreamType As eStreamType)
        Dim strLog As String = "", strTemp As String = ""
        Dim strBody As String = ""
        Dim strHexData As String = ""
        Dim nLay As Integer = 0
        Dim nCont As Integer = 0
        Dim nFor As Integer = 0
        Dim nLoop As Integer = 0
        Dim LayCont As New Stack

        strLog = System.DateTime.Now.ToString & Space(5) & LogMsg.MessageID & Space(5) & StreamType.ToString & vbTab


        If LogMsg.MessageHeader.SType = 0 Then
            SaveLog("[" & LogMsg.MessageID & "]", True)
            For nFor = 0 To LogMsg.MessageBody.Count - 1
                nLay = LayCont.Count
                'If nLay = 0 Then
                '    SaveLog("[S" & LogMsg.MessageHeader.StreamID & "F" & LogMsg.MessageHeader.FunctionID & "]")
                'End If
                If nLay > 1 Then
                    For nLoop = 0 To LayCont.Count
                        If LayCont.Peek > 0 Then
                            strBody = strBody & vbTab
                        Else
                            LayCont.Pop()
                        End If
                    Next nLoop
                End If
                If LogMsg.MessageBody(nFor).FormateCode = eFormatCode.LIST Then
                    If LayCont.Count > 0 Then
                        nCont = LayCont.Pop - 1
                        LayCont.Push(nCont)
                    End If
                    LayCont.Push(LogMsg.MessageBody(nFor).List)
                    strBody = "L[" & LogMsg.MessageBody(nFor).List.ToString & "]" & vbCrLf
                    SaveLog(strBody)
                Else
                    Select Case LogMsg.MessageBody(nFor).FormateCode
                        Case eFormatCode.ASCII
                            strTemp = vbTab & "A "
                        Case eFormatCode.BINARY
                            strTemp = vbTab & "B "
                        Case eFormatCode.BOOLEAN1
                            strTemp = vbTab & "BL "
                        Case eFormatCode.F4
                            strTemp = vbTab & "F4 "
                        Case eFormatCode.F8
                            strTemp = vbTab & "F8 "
                        Case eFormatCode.I1
                            strTemp = vbTab & "I1 "
                        Case eFormatCode.I2
                            strTemp = vbTab & "I2 "
                        Case eFormatCode.I4
                            strTemp = vbTab & "I4 "
                        Case eFormatCode.I8
                            strTemp = vbTab & "I8 "
                        Case eFormatCode.JIS
                            strTemp = vbTab & "JIS "
                        Case eFormatCode.U1
                            strTemp = vbTab & "U1 "
                        Case eFormatCode.U2
                            strTemp = vbTab & "U2 "
                        Case eFormatCode.U4
                            strTemp = vbTab & "U4 "
                        Case eFormatCode.U8
                            strTemp = vbTab & "U8 "
                    End Select
                    strTemp = strTemp & "[" & LogMsg.MessageBody(nFor).ItemSize.ToString & "]" & vbTab & "<" & _
                    LogMsg.MessageBody(nFor).TagName & ">" & vbTab & _
                    "'" & LogMsg.MessageBody(nFor).ItemValue & "'" & vbCrLf
                    'strBody = strBody & strTemp
                    SaveLog(strTemp)
                End If

            Next

            'strLog = strLog & strBody & vbCrLf
            'mvarLogString = strLog
        End If

        If mvarLogRawData Then
            For nFor = 0 To RawData.Length
                If nFor = 0 Then strHexData = LogMsg.MessageID & "  Raw Data" & Space(5) & StreamType.ToString & vbCrLf & "Header ("
                strHexData = strHexData & RawData(nFor).ToString("X2")

                If nFor = 9 Then strHexData = strHexData & " )" & vbCrLf & "Data ("
                If ((nFor - 9) Mod 30 = 0) And nFor > 10 Then strHexData = strHexData & vbCrLf & Space(5)
            Next
            strHexData = strHexData & " )" & vbCrLf
            strLog = strLog & strHexData & vbCrLf
            SaveLog(strBody)
        End If
        'SaveLog(strLog)

        Exit Sub
    End Sub

    Public Sub MakeLog(ByRef LogMsg As clsSECSMessage, ByVal StreamType As eStreamType)
        Dim strLog As String = "", strTemp As String = ""
        Dim strBody As String = ""
        Dim strHexData As String = ""
        Dim nLay As Integer = 0
        Dim nCont As Integer = 0
        Dim nFor As Integer = 0
        Dim nLoop As Integer = 0
        Dim LayCont As New Stack
        Dim strTab As String = ""
        strLog = System.DateTime.Now.ToString & Space(5) & LogMsg.MessageID & Space(5) & StreamType.ToString & vbTab

        SaveLog("[S" & LogMsg.MessageHeader.StreamID & "F" & LogMsg.MessageHeader.FunctionID & "]", True)
        If LogMsg.MessageHeader.SType = 0 Then
            For nFor = 0 To LogMsg.MessageBody.Count - 1
                nLay = LayCont.Count


                If nLay > 1 Then
                    For nLoop = 0 To LayCont.Count
                        If LayCont.Peek > 0 Then
                            strBody = strBody & vbTab
                        Else
                            LayCont.Pop()
                        End If
                    Next nLoop
                End If
                If LogMsg.MessageBody(nFor).FormateCode = eFormatCode.LIST Then
                    If LayCont.Count > 0 Then
                        nCont = LayCont.Pop - 1
                        LayCont.Push(nCont)
                    End If

                    LayCont.Push(LogMsg.MessageBody(nFor).List)
                    strBody = "L[" & LogMsg.MessageBody(nFor).List.ToString & "]" & vbCrLf
                    SaveLog(strBody)
                Else
                    Select Case LogMsg.MessageBody(nFor).FormateCode
                        Case eFormatCode.ASCII
                            strTemp = vbTab & "A "
                        Case eFormatCode.BINARY
                            strTemp = vbTab & "B "
                        Case eFormatCode.BOOLEAN1
                            strTemp = vbTab & "BL "
                        Case eFormatCode.F4
                            strTemp = vbTab & "F4 "
                        Case eFormatCode.F8
                            strTemp = vbTab & "F8 "
                        Case eFormatCode.I1
                            strTemp = vbTab & "I1 "
                        Case eFormatCode.I2
                            strTemp = vbTab & "I2 "
                        Case eFormatCode.I4
                            strTemp = vbTab & "I4 "
                        Case eFormatCode.I8
                            strTemp = vbTab & "I8 "
                        Case eFormatCode.JIS
                            strTemp = vbTab & "JIS "
                        Case eFormatCode.U1
                            strTemp = vbTab & "U1 "
                        Case eFormatCode.U2
                            strTemp = vbTab & "U2 "
                        Case eFormatCode.U4
                            strTemp = vbTab & "U4 "
                        Case eFormatCode.U8
                            strTemp = vbTab & "U8 "
                    End Select
                    strTemp = strTemp & "[" & LogMsg.MessageBody(nFor).ItemSize.ToString & "]" & vbTab & "<" & _
                    LogMsg.MessageBody(nFor).TagName & ">" & vbTab & _
                    "'" & LogMsg.MessageBody(nFor).ItemValue & "'" & vbCrLf
                    'strBody = strBody & strTemp
                    SaveLog(strTemp)
                End If

            Next
        End If
        Exit Sub
    End Sub

    Public Sub SaveLog(ByVal strLog As String, Optional ByVal fWithTime As Boolean = False)
        Dim strLogTitle As String = Space(5)
        Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")
        If fWithTime Then
            MyLog.WriteLog(MyTime & Space(1) & "SEMI      >" & strLogTitle & " " & strLog)
        Else
            MyLog.WriteLog(Space(60) & ">" & strLogTitle & " " & strLog)
        End If
    End Sub
End Class
