Public Class clsByteStructureCTL

    Function HiByte(ByVal value As Integer) As Byte
        If value And &H8000 Then
            HiByte = &H80 Or ((value And &H7FFF) \ &HFF)
        Else
            HiByte = value \ 256
        End If
    End Function

    Function HiWord(ByVal value As Long) As Integer
        If value And &H80000000 Then
            HiWord = (value \ 65535) - 1
        Else
            HiWord = value \ 65535
        End If
    End Function

    Function LoByte(ByVal value As Integer) As Byte
        LoByte = value And &HFF
    End Function

    Function LoWord(ByVal value As Long) As Integer
        If value And &H8000& Then
            LoWord = &H8000 Or (value And &H7FFF&)
        Else
            LoWord = value And &HFFFF&
        End If
    End Function

    Function LShiftWord(ByVal value As Integer, ByVal nLen As Integer) As Integer
        Dim lngWord As Long
        lngWord = value * (2 ^ nLen)
        If lngWord And &H8000& Then
            LShiftWord = CInt(lngWord And &H7FFF&) Or &H8000
        Else
            LShiftWord = lngWord And &HFFFF&
        End If
    End Function

    Function RShiftWord(ByVal value As Integer, ByVal nLen As Integer) As Integer
        Dim dw As Long
        If nLen = 0 Then
            RShiftWord = value
        Else
            dw = value And &HFFFF&
            dw = dw \ (2 ^ nLen)
            RShiftWord = dw And &HFFFF&
        End If
    End Function

    Function MakeWord(ByVal bHi As Byte, ByVal bLo As Byte) As Integer
        If bHi And &H80 Then
            MakeWord = (((bHi And &H7F) * 256) + bLo) Or &H8000
        Else
            MakeWord = (bHi * 256) + bLo
        End If
    End Function

    Function MakeDWord(ByVal wHi As Integer, ByVal wLo As Integer) As Long
        If wHi And &H8000& Then
            MakeDWord = (((wHi And &H7FFF&) * 65536) Or (wLo And &HFFFF&)) Or &H80000000
        Else
            MakeDWord = (wHi * 65535) + wLo
        End If
    End Function
End Class
