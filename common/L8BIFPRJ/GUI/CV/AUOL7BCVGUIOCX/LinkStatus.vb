Imports System.Drawing
Public Class LinkStatus
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarENGType As Boolean

    Public Property ENGType() As Boolean
        Get
            ENGType = mvarENGType
        End Get
        Set(ByVal value As Boolean)
            mvarENGType = value
        End Set
    End Property

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "0180"
                If nOnOff = 1 Then
                    Me.cmdLinkReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLinkReq.BackColor = BackColorForSignalOFF
                End If
            Case "0181"
                If nOnOff = 1 Then
                    Me.cmdLinkTest.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLinkTest.BackColor = BackColorForSignalOFF
                End If
            Case "1300"
                If nOnOff = 1 Then
                    Me.lblSignalCVLinkReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCVLinkReq.BackColor = BackColorForSignalOFF
                End If
            Case "1301"
                If nOnOff = 1 Then
                    Me.lblSignalCVLinkTest.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCVLinkTest.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

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

    Public Sub ResetSignal()
        Me.lblSignalCVLinkReq.BackColor = BackColorForSignalOFF
        Me.lblSignalCVLinkTest.BackColor = BackColorForSignalOFF
        Me.cmdConnect.BackColor = BackColorForSignalOFF
        Me.cmdDisconnect.BackColor = BackColorForSignalOFF
        Me.cmdLinkReq.BackColor = BackColorForSignalOFF
        Me.cmdLinkTest.BackColor = BackColorForSignalOFF

    End Sub

    Private Sub cmdLinkReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkReq.Click         
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("0180")
    End Sub

    Private Sub cmdLinkTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkTest.Click        
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("0181")
    End Sub
End Class
