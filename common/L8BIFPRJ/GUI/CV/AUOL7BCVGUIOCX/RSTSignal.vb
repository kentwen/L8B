Imports System.Drawing

Public Class RSTSignal

    Private mvarSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color

    Public Event SignalClick(ByVal strSignalID As String)

    Private Sub ConvertSignalID(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd01A0.Click, cmd0180.Click, cmd0181.Click, cmd0183.Click, cmd0184.Click, cmd0190.Click, cmd0191.Click, cmd0192.Click, cmd0193.Click, cmd0194.Click, cmd0197.Click, cmd0198.Click, cmd0199.Click, cmd019A.Click, cmd019B.Click, cmd019F.Click, cmd01A0.Click, cmd01A1.Click, cmd01A2.Click, cmd01A3.Click, cmd01A4.Click, cmd01AB.Click, cmd01AC.Click, cmd01AD.Click, cmd01AE.Click, cmd01AF.Click, cmd01B0.Click, cmd01B1.Click, cmd01B2.Click, cmd01B3.Click, cmd01B4.Click, cmd01B8.Click, cmd01B9.Click, cmd01BA.Click, cmd01BB.Click, cmd01BC.Click, cmd01C0.Click, cmd01C1.Click, cmd01C2.Click, cmd01C3.Click, cmd01C4.Click, cmd01C8.Click, cmd01C9.Click, cmd01CA.Click, cmd01CB.Click, cmd01CC.Click, cmd01D0.Click, cmd01D1.Click, cmd01D3.Click, cmd01D5.Click, cmd01D7.Click, cmd01DB.Click, cmd01DC.Click, cmd01DD.Click, cmd01DE.Click, cmd01DF.Click, cmd01F0.Click, cmd01F1.Click, cmd01F2.Click, cmd01F3.Click, cmd01F4.Click, cmd01F5.Click, cmd01F6.Click, cmd01F7.Click, cmd01F8.Click, cmd01F9.Click, cmd01FA.Click, cmd01FB.Click, cmd01FC.Click, cmd01FD.Click, cmd01FE.Click, cmd0200.Click, cmd0201.Click, cmd0202.Click, cmd0203.Click, cmd0204.Click, cmd0210.Click, cmd0211.Click, cmd0212.Click, cmd0213.Click, cmd0214.Click, cmd0218.Click, cmd0219.Click, cmd021A.Click, cmd021A.Click, cmd021B.Click, cmd021C.Click, cmd0220.Click, cmd0221.Click, cmd0221.Click, cmd0222.Click, cmd0223.Click, cmd0224.Click, cmd0228.Click, cmd0229.Click, cmd022A.Click, cmd022B.Click, cmd022C.Click, cmd01E0.Click, cmd01E1.Click, cmd01E2.Click, cmd01E3.Click, cmd01E4.Click, cmd01E5.Click, cmd01E6.Click, cmd01E7.Click, cmd01E8.Click, cmd01E9.Click, cmd01EA.Click, cmd01EB.Click, cmd01EC.Click, cmd01ED.Click, cmd01EE.Click
        Dim strIndex As String
        strIndex = Mid(sender.Name, 4)
        RaiseEvent SignalClick(strIndex)
    End Sub

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Dim objTemp As Object

        For Each objTemp In Me.Controls
            If objTemp.Name = "cmd" & CStr(strSignalID) Then
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
