Imports System.Drawing
Public Class CSTRemoved
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
            Case "0218", "0219", "021A", "021B", "021C"
                If nOnOff = 1 Then
                    Me.cmdCSTRemovedAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdCSTRemovedAck.BackColor = BackColorForSignalOFF
                End If
            Case "1358", "1359", "135A", "135B", "135C"
                If nOnOff = 1 Then
                    Me.lblSignalCSTRemoveReport.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCSTRemoveReport.BackColor = BackColorForSignalOFF
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
        Call ResetSignal()
        nConvertPortIndex = TabControl1.SelectedIndex + 1
        RaiseEvent PortTabChange(nConvertPortIndex)
    End Sub

    Public Sub ResetSignal()
        Me.cmdCSTRemovedAck.BackColor = BackColorForSignalOFF
        Me.lblSignalCSTRemoveReport.BackColor = BackColorForSignalOFF
    End Sub

    Private Sub cmdCSTRemovedAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSTRemovedAck.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("0218")
            Case "1"
                RaiseEvent RSTSignalClick("0219")
            Case "2"
                RaiseEvent RSTSignalClick("021A")
            Case "3"
                RaiseEvent RSTSignalClick("021B")
            Case "4"
                RaiseEvent RSTSignalClick("021C")
        End Select
    End Sub
End Class
