Imports System.Drawing
Public Class GxAbnormal

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
            Case "01D7"
                If nOnOff = 1 Then
                    Me.cmdGxAbnormalAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdGxAbnormalAck.BackColor = BackColorForSignalOFF
                End If
            Case "13B6"
                If nOnOff = 1 Then
                    Me.lblSignalGxAbnormalReport.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxAbnormalReport.BackColor = BackColorForSignalOFF
                End If
            Case "13F0"
                If nOnOff = 1 Then
                    Me.lblSignalGxAbnormalReportAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxAbnormalReportAck.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nAbnormalCase As Integer, ByVal nGxPos As Integer, ByVal strSourceGxID As String, ByVal strVCRGxID As String)
        'Me.lblWAbnormalCase.Text = nAbnormalCase
        'Me.lblWGxPosition.Text = nGxPos
        'Me.lblWSourceGxID.Text = strSourceGxID
        'Me.lblWVCRGxID.Text = strVCRGxID
        MyUpdataCVGlassAbnormalCase.nAbnormalCase = nAbnormalCase
        MyUpdataCVGlassAbnormalCase.nGxPosition = nGxPos
        MyUpdataCVGlassAbnormalCase.strSourceGxID = strSourceGxID
        MyUpdataCVGlassAbnormalCase.strVCRGxID = strVCRGxID
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
        Me.lblWAbnormalCase.Text = ""
        Me.lblWGxPosition.Text = ""
        Me.lblWSourceGxID.Text = ""
        Me.lblWVCRGxID.Text = ""
        Me.lblSignalGxAbnormalReport.BackColor = BackColorForSignalOFF
        Me.lblSignalGxAbnormalReport.BackColor = BackColorForSignalOFF
        Me.cmdGxAbnormalAck.BackColor = BackColorForSignalOFF

    End Sub

    Private Sub cmdGxAbnormalAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGxAbnormalAck.Click
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("01D7")
    End Sub

    Public Sub ShowGUIGlassAbnormalCaseReport()
        Me.lblWAbnormalCase.Text = MyUpdataCVGlassAbnormalCase.nAbnormalCase
        Me.lblWGxPosition.Text = MyUpdataCVGlassAbnormalCase.nGxPosition
        Me.lblWSourceGxID.Text = MyUpdataCVGlassAbnormalCase.strSourceGxID
        Me.lblWVCRGxID.Text = MyUpdataCVGlassAbnormalCase.strVCRGxID
    End Sub
End Class
