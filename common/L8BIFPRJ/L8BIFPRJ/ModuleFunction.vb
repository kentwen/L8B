

Module ModuleFunction

    Public Function ConvertDec2Hex(ByVal strValue As String) As Integer
        Dim nLen As Integer

        nLen = Len(strValue)
        If nLen > 0 Then
            Return Val("&H" & Left(strValue, nLen))
        End If
        Return -1
    End Function

    Public Sub ASCStringConvert(ByVal strData As String, ByVal nMaxLen As Integer, ByRef alValue() As Integer)
        Dim i As Integer
        Dim j As Integer
        Dim nFor As Integer

        nMaxLen = nMaxLen + 1
        If Len(strData) <> (nMaxLen * 2) Then
            For i = Len(strData) To (nMaxLen * 2) - 1
                strData = strData & " "
            Next i
        End If

        For nFor = 1 To nMaxLen
            alValue(j) = WordStringConvert(Mid(strData, (nFor * 2) - 1, 2))
            j = j + 1
        Next nFor
    End Sub

    Public Function WordStringConvert(ByVal strData As String) As Integer
        Return Asc(Mid(strData, 2, 1)) * 256 + Asc(Mid(strData, 1, 1))
    End Function

    Public Function ConvertHiLowASCIIToString(ByVal nWord As Integer) As String
        Dim nLen As Integer = 8
        Dim strData As String = ""

        strData = strData & (Chr(LShiftWord(nWord, nLen))) + (Chr(RShiftWord(nWord, nLen)))
        Return strData
    End Function

    'Public Function ConvertHiLowASCIIToString(ByVal nWord As Integer) As String
    '    Dim nLen As Integer
    '    Dim strData As String

    '    nLen = 8
    '    strData = ""
    '    strData = strData & Trim(Chr(LShiftWord(nWord, nLen))) + Trim(Chr(RShiftWord(nWord, nLen)))
    '    ConvertHiLowASCIIToString = strData
    'End Function

    Public Function LShiftWord(ByVal w As Integer, ByVal c As Integer) As Integer
        Dim dw As Integer = w * (2 ^ c)

        If dw And &H8000& Then
            Return CInt(dw And &H7FFF&) Or &H8000
        Else
            Return dw And &HFFFF&
        End If
    End Function

    Public Function RShiftWord(ByVal w As Integer, ByVal c As Integer) As Integer
        Dim dw As Integer
        If c = 0 Then
            Return w
        Else
            dw = w And &HFFFF&
            dw = dw \ (2 ^ c)
            Return dw And &HFFFF&
        End If
    End Function

    Public Function HexLeadZero(ByVal nData As Integer) As String
        Return Right("000" & Hex(nData), 4)
    End Function

    'Hex:FEDC
    'C = firstBlock D = SecondBlock E = ThirdBlock F = FourthBlock
    Public Sub GetWordBlock(ByVal strHexVal As String, ByRef firstBlock As Integer, ByRef SecondBlock As Integer, ByRef ThirdBlock As Integer, ByRef FourthBlock As Integer)
        firstBlock = Val("&H" & Mid(strHexVal, 4, 1))
        SecondBlock = Val("&H" & Mid(strHexVal, 3, 1))
        ThirdBlock = Val("&H" & Mid(strHexVal, 2, 1))
        FourthBlock = Val("&H" & Mid(strHexVal, 1, 1))
    End Sub

    'Hex:FF00
    'FF = Hibyte 00 = Libyte
    Public Sub GetHIbyteLibyte(ByVal strHexVal As String, ByRef HiByte As Integer, ByRef LiByte As Integer)
        HiByte = GetHIbyte(strHexVal)
        LiByte = GetLobyte(strHexVal)
    End Sub

    Public Function GetHIbyte(ByVal strHexVal As String) As Integer
        Return Val("&H" & Mid(strHexVal, 1, 2))
    End Function

    Public Function GetLobyte(ByVal strHexVal As String) As Integer
        Return Val("&H" & Mid(strHexVal, 3, 2))
    End Function

    Public Function WordConvertToBin(ByVal nWord As Integer, ByRef asbit() As Short) As String
        Dim anData(MAX_BIT) As Integer
        Dim strAssembler As String = ""
        Dim i As Integer

        For i = 0 To MAX_BIT
            anData(i) = nWord And (2 ^ i)
            If anData(i) <> 0 Then
                asbit(i) = 1
            Else
                asbit(i) = 0
            End If
        Next i

        'Assembler Binary
        For i = MAX_BIT To 0 Step -1
            strAssembler = strAssembler & asbit(i)
        Next i

        Return strAssembler
    End Function
End Module
