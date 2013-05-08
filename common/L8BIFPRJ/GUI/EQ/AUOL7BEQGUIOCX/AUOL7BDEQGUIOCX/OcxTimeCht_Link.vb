Imports System.Drawing
Public Class OcxTimeCht_Link
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
            Case "0", "80", "100"
                If nOnOff = 1 Then
                    Me.shpRSTLinkReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTLinkReq.BackColor = BackColorForSignalOFF
                End If
            Case "1", "81", "101"
                If nOnOff = 1 Then
                    Me.shpRSTLinkTest.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTLinkTest.BackColor = BackColorForSignalOFF
                End If
            Case "300", "700", "1000"
                If nOnOff = 1 Then
                    Me.shpEQLinkReq.BackColor = BackColorForCVSignalON
                Else
                    Me.shpEQLinkReq.BackColor = BackColorForSignalOFF
                End If
            Case "301", "701", "1001"
                If nOnOff = 1 Then
                    Me.shpEQLinkTest.BackColor = BackColorForCVSignalON
                Else
                    Me.shpEQLinkTest.BackColor = BackColorForSignalOFF
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
        Me.shpEQLinkReq.BackColor = BackColorForSignalOFF
        Me.shpEQLinkTest.BackColor = BackColorForSignalOFF
        Me.shpRSTLinkReq.BackColor = BackColorForSignalOFF
        Me.shpRSTLinkTest.BackColor = BackColorForSignalOFF
    End Sub
End Class
