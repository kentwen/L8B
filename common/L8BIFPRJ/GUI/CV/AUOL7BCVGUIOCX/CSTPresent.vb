Imports System.Drawing
Public Class CSTPresent
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
            Case "0210", "0211", "0212", "0213", "0214"
                If nOnOff = 1 Then
                    Me.cmdCSTPresentAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdCSTPresentAck.BackColor = BackColorForSignalOFF
                End If
            Case "1348", "1349", "134A", "134B", "134C"
                If nOnOff = 1 Then
                    Me.lblSignalCSTPresentReport.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCSTPresentReport.BackColor = BackColorForSignalOFF
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

    Private Sub ResetSignal()
        Me.cmdCSTPresentAck.BackColor = BackColorForSignalOFF
        Me.lblSignalCSTPresentReport.BackColor = BackColorForSignalOFF       
    End Sub

    Private Sub cmdCSTPresentAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSTPresentAck.Click
        Dim nConvertPortIndex As Integer
        If Not ENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("0210")
            Case "1"
                RaiseEvent RSTSignalClick("0211")
            Case "2"
                RaiseEvent RSTSignalClick("0212")
            Case "3"
                RaiseEvent RSTSignalClick("0213")
            Case "4"
                RaiseEvent RSTSignalClick("0214")
        End Select
    End Sub
End Class
