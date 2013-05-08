Imports System.Drawing
Public Class GxInfoUnmatch
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
            Case "01D3"
                If nOnOff = 1 Then
                    Me.cmdGxSlotUnmatchedAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdGxSlotUnmatchedAck.BackColor = BackColorForSignalOFF
                End If
            Case "13BB"
                If nOnOff = 1 Then
                    Me.lblSignalGxUnmatchReport.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxUnmatchReport.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nUnmatchCase As Integer)
        'Me.lblWPortNo.Text = nPortNo
        'Me.lblWSlotNo.Text = nSlotNo
        'Me.lblWUnmatchCase.Text = nUnmatchCase

        MyUpdataCVGlassSlotUnmatchedReport.nPortNo = nPortNo
        MyUpdataCVGlassSlotUnmatchedReport.nSlotNumber = nSlotNo
        MyUpdataCVGlassSlotUnmatchedReport.nUnmatchCase = nUnmatchCase
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
        Me.lblSignalGxUnmatchReport.BackColor = BackColorForSignalOFF
        Me.cmdGxSlotUnmatchedAck.BackColor = BackColorForSignalOFF
        Me.lblWPortNo.Text = ""
        Me.lblWSlotNo.Text = ""
        Me.lblWUnmatchCase.Text = ""
    End Sub

    Private Sub cmdGxSlotUnmatchedAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGxSlotUnmatchedAck.Click        
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("01D3")
    End Sub

    Public Sub ShowGUIGlassSlotUnmatchedReport()
        Me.lblWPortNo.Text = MyUpdataCVGlassSlotUnmatchedReport.nPortNo
        Me.lblWSlotNo.Text = MyUpdataCVGlassSlotUnmatchedReport.nSlotNumber
        Me.lblWUnmatchCase.Text = MyUpdataCVGlassSlotUnmatchedReport.nUnmatchCase
    End Sub
End Class
