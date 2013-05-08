Imports System.Drawing

Public Class CVSignal
    Private mvarSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Dim objTemp As Object

        For Each objTemp In Me.Controls
            If objTemp.Name = "lbl" & CStr(strSignalID) Then
                If nOnOff = 1 Then
                    objTemp.BackColor = BackColorForSignalON
                Else
                    objTemp.BackColor = BackColorForSignalOFF
                End If
            End If
        Next
    End Sub

    Public Property BackColorForSignalON() As System.Drawing.Color
        Get
            BackColorForSignalON = mvarSignalONColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSignalONColor = value
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


End Class
