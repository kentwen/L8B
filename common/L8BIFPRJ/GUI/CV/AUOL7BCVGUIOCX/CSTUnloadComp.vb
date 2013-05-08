Imports System.Drawing
Public Class CSTUnloadComp
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
            Case "01B8", "01B9", "01BA", "01BB", "01BC"
                If nOnOff = 1 Then
                    Me.cmdCSTUnloadCompAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdCSTUnloadCompAck.BackColor = BackColorForSignalOFF
                End If
            Case "1378", "1379", "137A", "137B", "137C"
                If nOnOff = 1 Then
                    Me.lblSignalCSTUnloadComp.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCSTUnloadComp.BackColor = BackColorForSignalOFF
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

    Private Sub ResetSignal()
        Me.lblSignalCSTUnloadComp.BackColor = BackColorForSignalOFF
        Me.cmdCSTUnloadCompAck.BackColor = BackColorForSignalOFF

    End Sub

    Private Sub cmdCSTUnloadCompAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSTUnloadCompAck.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01B8")
            Case "1"
                RaiseEvent RSTSignalClick("01B9")
            Case "2"
                RaiseEvent RSTSignalClick("01BA")
            Case "3"
                RaiseEvent RSTSignalClick("01BB")
            Case "4"
                RaiseEvent RSTSignalClick("01BC")
        End Select
    End Sub
End Class
