
Imports PLC
Imports RainBowTech


Module ModuleMain
    Public MyTCPIPIF As New PLC.CPLCRW
    Public MyWriteLog As New clsLogFactory
    Public g_colPortChange As New Collection

    Public MyProcessPortChangeFlag As Boolean

    Public Const MAX_BIT = 15

    Enum eIFIndex
        INDEX_CV = 1
        INDEX_EQ = 2
        INDEX_RST = 3
        INDEX_PLC = 4
    End Enum


    Enum eLogType
        [EVENT]
        [METHOD]
        [ERR]
        [SYS]
        [PROPERTY]
        [PLC]
    End Enum

    Public Sub PLCTCPIPOpen()
        DebugLog(eIFIndex.INDEX_PLC, eLogType.[SYS], "TCPIP Open...")

        MyTCPIPIF.TCPInitial(g_mstrPLCIP, g_mnPLCPORT, g_mfPLCMode)
    End Sub

#Region "Main Function"
    Public Function GetProcessTime(ByVal nValue As Integer) As String
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)

        GetProcessTime = Left(strData, 2) & Right(strData, 2)
    End Function


    Public Sub ProcessBufPortChangeData()
        Dim strCombination As String = ""
        Dim nPortNo As Integer
        Dim nPortMode As Integer
        Dim nPortType As Integer
        Dim strProductCode As String = ""
        Dim nProductCodeLen As Integer
        Dim anProductCode(12) As Integer

        If g_colPortChange.Count > 0 Then
            strCombination = GetFirstBufPortChange()
            RemoveBufPortChange()

            'strCombination => nPortNo & "," & nPortMode & "," & nPortType & "," & nProductCodeLen & "," & strProductCode
            nPortNo = CInt(Mid(strCombination, 1, 1))
            nPortMode = CInt(Mid(strCombination, 3, 1))
            nPortType = CInt(Mid(strCombination, 5, 1))
            nProductCodeLen = CInt(Mid(strCombination, 7, 1))

            strProductCode = Mid(strCombination, 9, nProductCodeLen)

            WriteZRAddr(MyCVZRAddr.m_nPortChangePortNo, nPortNo)
            WriteZRAddr(MyCVZRAddr.m_nPortChangePortMode, nPortMode)
            WriteZRAddr(MyCVZRAddr.m_nPortChangePortType, nPortType)

            ASCStringConvert(strProductCode, 12, anProductCode)
            WriteZRArrayAddr(MyCVZRAddr.m_nPortChangeProductCode, anProductCode)

            DebugLog(eIFIndex.INDEX_CV, eLogType.[METHOD], "CV Port[" & nPortNo & "] Port Change Request -> " & nPortMode.ToString)
            WriteMAddr(MyCVMAddr.m_nCVPortChangeRequest, True)
        End If
    End Sub

    Public Sub AddBufPortChange(ByVal strBufData As String)
        g_colPortChange.Add(strBufData)
    End Sub

    Public Function GetFirstBufPortChange() As String
        If g_colPortChange.Count > 0 Then
            GetFirstBufPortChange = g_colPortChange.Item(1)
        Else
            GetFirstBufPortChange = ""
        End If
    End Function

    Public Sub RemoveBufPortChange()
        If g_colPortChange.Count > 0 Then g_colPortChange.Remove(1)
    End Sub


    Public Function MyStringTrim(ByRef zStr As String) As String
        Return MyStartTrim(MyEndTrim(zStr))
    End Function

    Public Function MyStartTrim(ByRef zStr As String) As String
        Try
            If zStr Is Nothing Then Return ""

            Dim zTmp As String = ""
            Dim Index As Integer = -1

            For i As Integer = 0 To zStr.Length - 1
                If Asc(zStr(i)) <> &H20 AndAlso Asc(zStr(i)) <> 255 AndAlso Asc(zStr(i)) > 0 Then
                    Index = i
                    Exit For
                End If
            Next

            If Index < zStr.Length - 1 Then
                For i As Integer = Index To zStr.Length - 1
                    zTmp &= zStr(i)
                Next
            End If

            Return zTmp
        Catch ex As Exception
            DebugLog(eIFIndex.INDEX_PLC, eLogType.ERR, zStr & " " & ex.ToString)
            Return ""
        End Try
    End Function

    Public Function MyEndTrim(ByRef zStr As String) As String
        Try
            If zStr Is Nothing Then Return ""

            Dim zTmp As String = ""
            Dim Index As Integer = -1

            For i As Integer = zStr.Length - 1 To 0 Step -1
                If Asc(zStr(i)) <> &H20 AndAlso Asc(zStr(i)) <> 255 AndAlso Asc(zStr(i)) > 0 Then
                    Index = i
                    Exit For
                End If
            Next

            If Index > 0 Then
                For i As Integer = 0 To Index
                    zTmp &= zStr(i)
                Next
            End If

            Return zTmp
        Catch ex As Exception
            DebugLog(eIFIndex.INDEX_PLC, eLogType.ERR, zStr & " " & ex.ToString)
            Return ""
        End Try
    End Function
#End Region

#Region "TCP IP Function"
    Public Sub WriteMAddr(ByVal nAddr As Integer, ByVal fOnOff As Boolean)
        Dim bRet As Boolean

        bRet = MyTCPIPIF.WriteBit(fOnOff, nAddr, Device.M)
    End Sub

    Public Sub WriteMArrayAddr(ByVal nAddr As Integer, ByVal anWriteData() As Integer)
        Dim bRet As Boolean
        Dim sMaxLen As Short

        sMaxLen = UBound(anWriteData) + 1

        bRet = MyTCPIPIF.WriteWord(anWriteData, nAddr, Device.M, sMaxLen)
    End Sub

    Public Sub WriteZRAddr(ByVal nAddr As Integer, ByVal nWriteData As Integer)
        Dim bRet As Boolean

        bRet = MyTCPIPIF.WriteWord(nWriteData, nAddr, Device.ZR)
    End Sub

    Public Sub WriteZRArrayAddr(ByVal nAddr As Integer, ByVal anWriteData() As Integer)
        Dim bRet As Boolean
        Dim sMaxLen As Short

        sMaxLen = UBound(anWriteData) + 1

        bRet = MyTCPIPIF.WriteWord(anWriteData, nAddr, Device.ZR, sMaxLen)
    End Sub

    Public Sub ReadZRAddr(ByVal nAddr As Integer, ByRef anReceiveData() As Integer)
        Dim bRet As Boolean
        Dim sMaxLen As Short

        sMaxLen = UBound(anReceiveData) + 1

        bRet = MyTCPIPIF.ReadWord(nAddr, Device.ZR, anReceiveData, sMaxLen)
    End Sub

    '------------Bit Word----------------------------------------------------

    Public Sub WriteBAddr(ByVal nAddr As Integer, ByVal fOnOff As Boolean)
        Dim bRet As Boolean

        bRet = MyTCPIPIF.WriteBit(fOnOff, nAddr, Device.B)
    End Sub

    Public Sub ReadBAddr(ByVal nAddr As Integer, ByRef fOnOff() As Boolean)
        Dim bRet As Boolean
        Dim sMaxLen As Short

        sMaxLen = UBound(fOnOff) + 1

        bRet = MyTCPIPIF.ReadBit(nAddr, Device.B, fOnOff, sMaxLen)
    End Sub

    Public Sub ReadWAddr(ByVal nAddr As Integer, ByRef anReceiveData() As Integer)
        Dim bRet As Boolean
        Dim sMaxLen As Short

        sMaxLen = UBound(anReceiveData) + 1

        bRet = MyTCPIPIF.ReadWord(nAddr, Device.W, anReceiveData, sMaxLen)
    End Sub

    Public Sub WriteWArrayAddr(ByVal nAddr As Integer, ByVal anWriteData() As Integer)
        Dim bRet As Boolean
        Dim sMaxLen As Short

        sMaxLen = UBound(anWriteData) + 1

        bRet = MyTCPIPIF.WriteWord(anWriteData, nAddr, Device.W, sMaxLen)
    End Sub
#End Region

#Region "Write Log Function"
    Public Sub DebugLog(ByVal nIndex As eIFIndex, ByVal nLogType As eLogType, ByVal strMsgBody As String)
        Dim strIFName As String = ""
        Dim strHeader As String = String.Format("[{0}]", nLogType.ToString)
        Dim MyTime As String = String.Format("{0:yyyy/MM/dd HH:mm:ss}.{1:0##}", Now, Now.Millisecond)
        'Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")

        Select Case nIndex
            Case eIFIndex.INDEX_CV
                strIFName = "CV IF     >"
            Case eIFIndex.INDEX_EQ
                strIFName = "EQ IF     >"
            Case eIFIndex.INDEX_RST
                strIFName = "RST IF    >"
            Case eIFIndex.INDEX_PLC
                strIFName = "PLC IF    >"
        End Select

        strHeader = strHeader & Space(14 - strHeader.Length)

        MyWriteLog.WriteLog(MyTime & Space(1) & strIFName & strHeader & Space(5) & strMsgBody)

    End Sub

    Public Sub WritePLCLog(ByVal nMachineCategory As Integer, ByVal nCommand As Integer, ByVal nOnOff As Integer, ByVal strDataTime As String, ByVal strGxID As String)
        Dim strMachineCategory As String = ""
        Dim strCommand As String = ""
        Dim strOnOff As String = ""
        Dim strHeader As String = ""
        Dim MyTime As String = String.Format("{0:yyyy/MM/dd HH:mm:ss}.{1:0##}", Now, Now.Millisecond)
        'Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")

        strHeader = "[PLC]"

        '1:EQ1,2:EQ2,3:EQ3,4:EQ4,5:CV1,6:CV2
        Select Case nMachineCategory
            Case 1
                strMachineCategory = "EQ1"
            Case 2
                strMachineCategory = "EQ2"
            Case 3
                strMachineCategory = "EQ3"
            Case 4
                strMachineCategory = "EQ4"
            Case 5
                strMachineCategory = "CV1"
            Case 6
                strMachineCategory = "CV2"
        End Select

        strCommand = CommandCategory(nCommand)

        If nOnOff = 1 Then
            strOnOff = "On"
        Else
            strOnOff = "Off"
        End If

        strHeader = strHeader & Space(14 - strHeader.Length)

        MyWriteLog.WriteLog(MyTime & Space(1) & "PLC IF    >" & strHeader & Space(5) & "PLCLog " & strDataTime & " ," & strMachineCategory & " ,Command(" & strCommand & ") " & strOnOff & " ,GlassID=" & strGxID)
    End Sub

    Public Sub WriteTaceDataPLCLog(ByVal strDataTime As String, ByVal nDeviceAddress As Integer, ByVal nSerialNo As Integer, ByVal nOnOff As Integer)
        Dim strHeader As String = ""
        Dim MyTime As String = String.Format("{0:yyyy/MM/dd HH:mm:ss}.{1:0##}", Now, Now.Millisecond)
        'Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")
        strHeader = "[PLC]"
        strHeader = strHeader & Space(14 - strHeader.Length)

        MyWriteLog.WriteLog(MyTime & Space(1) & "PLC IF    >" & strHeader & Space(5) & "PLCLog " & strDataTime & " ,Address [" & nDeviceAddress.ToString & "]" & " ,SerialNo [" & nSerialNo.ToString & "]" & " ,Signal =>[" & nOnOff.ToString & "]")
    End Sub

    Public Sub WriteTimeoutPLCLog(ByVal strFunName As String, ByVal strDataTime As String)
        Dim strHeader As String = ""
        Dim MyTime As String = String.Format("{0:yyyy/MM/dd HH:mm:ss}.{1:0##}", Now, Now.Millisecond)
        'Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")

        strHeader = "[PLC]"
        strHeader = strHeader & Space(14 - strHeader.Length)

        MyWriteLog.WriteLog(MyTime & Space(1) & "PLC IF    >" & strHeader & Space(5) & "PLCLog " & strDataTime & " ,TimeoutCategory[" & strFunName & "]")
    End Sub

    Private Function CommandCategory(ByVal nCommand As Integer) As String
        Dim strCommandCategory As String = ""

        Select Case nCommand
            Case 1
                strCommandCategory = "Load Transfer Request"
            Case 2
                strCommandCategory = "Load Robot Busy"
            Case 3
                strCommandCategory = "Load Complete"
            Case 4
            Case 5
                strCommandCategory = "Unload Transfer Request"
            Case 6
                strCommandCategory = "Unload Robot Busy"
            Case 7
                strCommandCategory = "Unload Complete"
            Case 8
            Case 9
                strCommandCategory = "ExTransfer Request"
            Case 10
                strCommandCategory = "Ex Robot Get Busy"
            Case 11
                strCommandCategory = "Ex Robot Put Busy"
            Case 12
                strCommandCategory = "Exchange Complete"
            Case 13
                strCommandCategory = "Exchange Status"
            Case 14
            Case 15
            Case 16
                strCommandCategory = "RST->EQ Interlock"
            Case 17
                strCommandCategory = "Load Request"
            Case 18
                strCommandCategory = "Load EQ Ready"
            Case 19
            Case 20
            Case 21
                strCommandCategory = "Unload Request"
            Case 22
                strCommandCategory = "Unload EQ Ready"
            Case 23
            Case 24
            Case 25
                strCommandCategory = "Exchange Request"
            Case 26
                strCommandCategory = "Ex EQ Ready"
            Case 27
            Case 28
            Case 29
            Case 30
            Case 31
            Case 32
                strCommandCategory = "EQ->RST Interlock"
            Case 33
                strCommandCategory = "UD Transfer  Request(Position 01)"
            Case 34
                strCommandCategory = "UD Robot Busy(Position 01)"
            Case 35
                strCommandCategory = "UD Transfer Complete(Position 01)"
            Case 36
                strCommandCategory = "UD Transfer  Request(Position 02)"
            Case 37
                strCommandCategory = "UD Robot Busy(Position 02)"
            Case 38
                strCommandCategory = "UD Transfer Complete(Position 02)"
            Case 39
                strCommandCategory = "UD Transfer  Request(Position 03)"
            Case 40
                strCommandCategory = "UD Robot Busy(Position 03)"
            Case 41
                strCommandCategory = "UD Transfer Complete(Position 03)"
            Case 42
                strCommandCategory = "UD Transfer  Request(Position 04)"
            Case 43
                strCommandCategory = "UD Robot Busy(Position 04)"
            Case 44
                strCommandCategory = "UD Transfer Complete(Position 04)"
            Case 45
                strCommandCategory = "UD Transfer  Request(Position 05)"
            Case 46
                strCommandCategory = "UD Robot Busy(Position 05)"
            Case 47
            Case 48
            Case 49
                strCommandCategory = "LD Transfer  Request(Position 01)"
            Case 50
                strCommandCategory = "LD Robot Busy(Position 01)"
            Case 51
                strCommandCategory = "LD Transfer Complete(Position 01)"
            Case 52
                strCommandCategory = "LD Transfer  Request(Position 02)"
            Case 53
                strCommandCategory = "LD Robot Busy(Position 02)"
            Case 54
                strCommandCategory = "LD Transfer Complete(Position 02)"
            Case 55
                strCommandCategory = "LD Transfer  Request(Position 03)"
            Case 56
                strCommandCategory = "LD Robot Busy(Position 03)"
            Case 57
                strCommandCategory = "LD Transfer Complete(Position 03)"
            Case 58
                strCommandCategory = "LD Transfer  Request(Position 04)"
            Case 59
                strCommandCategory = "LD Robot Busy(Position 04)"
            Case 60
                strCommandCategory = "LD Transfer Complete(Position 04)"
            Case 61
                strCommandCategory = "LD Transfer  Request(Position 05)"
            Case 62
                strCommandCategory = "LD Robot Busy(Position 05)"
            Case 63
                strCommandCategory = "LD Transfer Complete(Position 05)"
            Case 64
            Case 65
                strCommandCategory = "UD Transfer Ready(Position 01)"
            Case 66
                strCommandCategory = "UD CV Ready(Position 01)"
            Case 67
                strCommandCategory = "UD Transfer Ready(Position 02)"
            Case 68
                strCommandCategory = "UD CV Ready(Position 02)"
            Case 69
                strCommandCategory = "UD Transfer Ready(Position 03)"
            Case 70
                strCommandCategory = "UD CV Ready(Position 03)"
            Case 71
                strCommandCategory = "UD Transfer Ready(Position 04)"
            Case 72
                strCommandCategory = "UD CV Ready(Position 04)"
            Case 73
                strCommandCategory = "UD Transfer Ready(Position 05)"
            Case 74
                strCommandCategory = "UD CV Ready(Position 05)"
            Case 75
            Case 76
            Case 77
            Case 78
            Case 79
            Case 80
            Case 81
                'strCommandCategory = "LD CV Possible(Position 01)"
                strCommandCategory = "LD CV Ready(Position 01)"
            Case 82
                strCommandCategory = "LD CV Ready(Position 02)"
            Case 83
                'strCommandCategory = "LD CV Possible(Position 02)"
                strCommandCategory = "LD CV Ready(Position 03)"
            Case 84
                strCommandCategory = "LD CV Ready(Position 04)"
            Case 85
                'strCommandCategory = "LD CV Possible(Position 03)"
                strCommandCategory = "LD CV Ready(Position 05)"
            Case 86
                'strCommandCategory = "LD CV Ready(Position 03)"
            Case 87
                'strCommandCategory = "LD CV Possible(Position 04)"
            Case 88
                'strCommandCategory = "LD CV Ready(Position 04)"
            Case 89
                'strCommandCategory = "LD CV Possible(Position 05)"
            Case 90
                'strCommandCategory = "LD CV Ready(Position 05)"
            Case 91
            Case 92
            Case 93
            Case 94
            Case 95
            Case 96
            Case 97
                strCommandCategory = "HandOff Available Position 01"
            Case 98
                strCommandCategory = "HandOff Available Position 02"
            Case 99
                strCommandCategory = "HandOff Available Position 03"
            Case 100
                strCommandCategory = "HandOff Available Position 04"
            Case 101
                strCommandCategory = "HandOff Available Position 05"
        End Select

        CommandCategory = strCommandCategory
    End Function

    'Public Function GetDateTime() As String
    '    Dim strDateTime As String = ""

    '    strDateTime = Format(Now, "yyyyMMddhhmmss")
    '    GetDateTime = Mid(strDateTime, 1, 4) & "/" & Mid(strDateTime, 5, 2) & "/" & Mid(strDateTime, 7, 2) & " " _
    '    & Mid(strDateTime, 9, 2) & ":" & Mid(strDateTime, 11, 2) & ":" & Mid(strDateTime, 13, 2) & "." & Right(Format(Now.Millisecond), 2)
    'End Function
#End Region
 
End Module
