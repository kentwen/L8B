Imports System.Drawing
Public Class OcxTimeCht_PPIDModify
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarTabIdx As Integer

    Public ReadOnly Property TabIdx() As Integer
        Get
            TabIdx = Me.TabControl1.SelectedIndex
        End Get
    End Property

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "40", "C0", "140"
                If nOnOff = 1 Then
                    Me.shpPPIDModifyAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpPPIDModifyAck.BackColor = BackColorForSignalOFF
                End If
            Case "340", "740", "1040"
                If nOnOff = 1 Then
                    Me.shpPPIDModifyReport.BackColor = BackColorForCVSignalON
                Else
                    Me.shpPPIDModifyReport.BackColor = BackColorForSignalOFF
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
        Me.shpPPIDModifyAck.BackColor = BackColorForSignalOFF
        Me.shpPPIDModifyReport.BackColor = BackColorForSignalOFF
    End Sub
End Class
