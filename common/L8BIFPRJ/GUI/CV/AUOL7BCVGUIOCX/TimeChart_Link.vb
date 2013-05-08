Public Class TimeChart_Link
    Public Event PortTabChange(ByVal nPort As Integer)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color

    Public Property BackColorForRSTSignalON() As System.Drawing.Color
        Get
            BackColorForRSTSignalON = mvarRSTSignalONColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarRSTSignalONColor = value
        End Set
    End Property

    Public Property BackColorForCVSignalON() As System.Drawing.Color
        Get
            BackColorForCVSignalON = mvarCVSignalONColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarCVSignalONColor = value
        End Set
    End Property

    Public Property BackColorForSignalOFF() As System.Drawing.Color
        Get
            BackColorForSignalOFF = mvarSignalOFFColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSignalOFFColor = value
        End Set
    End Property

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "0180"
                If nOnOff = 1 Then
                    Me.B0180.BackColor = BackColorForRSTSignalON
                Else
                    Me.B0180.BackColor = BackColorForSignalOFF
                End If
            Case "0181"
                If nOnOff = 1 Then
                    Me.B0181.BackColor = BackColorForRSTSignalON
                Else
                    Me.B0181.BackColor = BackColorForSignalOFF
                End If
            Case "1300"
                If nOnOff = 1 Then
                    Me.B1300.BackColor = BackColorForCVSignalON
                Else
                    Me.B1300.BackColor = BackColorForSignalOFF
                End If
            Case "1301"
                If nOnOff = 1 Then
                    Me.B1301.BackColor = BackColorForCVSignalON
                Else
                    Me.B1301.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

End Class
