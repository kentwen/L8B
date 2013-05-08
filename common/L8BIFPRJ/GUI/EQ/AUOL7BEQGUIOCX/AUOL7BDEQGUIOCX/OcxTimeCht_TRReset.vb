Imports System.Drawing
Public Class OcxTimeCht_TRReset
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarTabIdx As Integer
    Private mvarMaxEQ As Integer
    Public Property MaxEQ() As Integer
        Get
            MaxEQ = mvarMaxEQ
        End Get
        Set(ByVal value As Integer)
            mvarMaxEQ = value
        End Set
    End Property


    Public ReadOnly Property TabIdx() As Integer
        Get
            TabIdx = Me.TabControl1.SelectedIndex
        End Get
    End Property

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "42", "C2", "142"
                If nOnOff = 1 Then
                    Me.shpTRResetReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpTRResetReq.BackColor = BackColorForSignalOFF
                End If
            Case "342", "742", "1042"
                If nOnOff = 1 Then
                    Me.shpTRResetAck.BackColor = BackColorForCVSignalON
                Else
                    Me.shpTRResetAck.BackColor = BackColorForSignalOFF
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
        If TabControl1.SelectedIndex + 1 > MaxEQ Then TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1

        Call ResetSignal()
        nConvertPortIndex = TabControl1.SelectedIndex + 1
        RaiseEvent PortTabChange(nConvertPortIndex)
    End Sub

    Public Sub ResetSignal()
        Me.shpTRResetAck.BackColor = BackColorForSignalOFF
        Me.shpTRResetReq.BackColor = BackColorForSignalOFF
    End Sub
End Class
