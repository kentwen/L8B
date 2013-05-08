Imports System.Drawing
Public Class OcxTimeCht_GxErase
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
            Case "43", "C3", "143" 'Glass Erase Ack
                If nOnOff = 1 Then
                    Me.shpGxEraseAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpGxEraseAck.BackColor = BackColorForSignalOFF
                End If
            Case "343", "743", "1043" 'Glass Erase Report
                If nOnOff = 1 Then
                    Me.shpGxEraseReport.BackColor = BackColorForCVSignalON
                Else
                    Me.shpGxEraseReport.BackColor = BackColorForSignalOFF
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
        Me.shpGxEraseReport.BackColor = BackColorForSignalOFF
        Me.shpGxEraseAck.BackColor = BackColorForSignalOFF
    End Sub
End Class
