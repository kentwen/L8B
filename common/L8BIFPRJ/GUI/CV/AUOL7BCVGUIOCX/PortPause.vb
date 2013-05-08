Imports System.Drawing
Public Class PortPause
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarENGType As Boolean
    Private mvarTabIdx As Integer

    Public ReadOnly Property TabIdx() As Integer
        Get
            TabIdx = Me.TabControl1.SelectedIndex
        End Get
    End Property

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
            Case "0220", "0221", "0222", "0223", "0224"
                If nOnOff = 1 Then
                    Me.cmdPauseReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdPauseReq.BackColor = BackColorForSignalOFF
                End If
            Case "1338", "1339", "133A", "133B", "133C"
                If nOnOff = 1 Then
                    Me.lblSignalPauseAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalPauseAck.BackColor = BackColorForSignalOFF
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

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex + 1
        RaiseEvent PortTabChange(nConvertPortIndex)
    End Sub

    Public Sub ResetSignal()
        Me.lblSignalPauseAck.BackColor = BackColorForSignalOFF
        Me.cmdPauseReq.BackColor = BackColorForSignalOFF         
    End Sub

    Private Sub cmdPauseReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPauseReq.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("0220")
            Case "1"
                RaiseEvent RSTSignalClick("0221")
            Case "2"
                RaiseEvent RSTSignalClick("0222")
            Case "3"
                RaiseEvent RSTSignalClick("0223")
            Case "4"
                RaiseEvent RSTSignalClick("0224")
        End Select
    End Sub
End Class
