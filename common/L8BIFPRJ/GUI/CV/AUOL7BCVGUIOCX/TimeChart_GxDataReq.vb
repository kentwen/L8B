﻿Public Class TimeChart_GxDataReq
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
            Case "01D1"
                If nOnOff = 1 Then
                    Me.B01D1.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01D1.BackColor = BackColorForSignalOFF
                End If
            Case "01D0"
                If nOnOff = 1 Then
                    Me.B01D0.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01D0.BackColor = BackColorForSignalOFF
                End If
            Case "13B0"
                If nOnOff = 1 Then
                    Me.B13B0.BackColor = BackColorForCVSignalON
                Else
                    Me.B13B0.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

End Class
