Imports System.Drawing
Public Class OcxTimeCht_GxUnload
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
            Case "28", "A8", "128"
                If nOnOff = 1 Then
                    Me.shpRSTTRReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTTRReq.BackColor = BackColorForSignalOFF
                End If
            Case "29", "A9", "129"
                If nOnOff = 1 Then
                    Me.shpRSTRBTBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTRBTBusy.BackColor = BackColorForSignalOFF
                End If
            Case "2A", "AA", "12A"
                If nOnOff = 1 Then
                    Me.shpRSTUnloadComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTUnloadComp.BackColor = BackColorForSignalOFF
                End If
            Case "328", "728", "1028"
                If nOnOff = 1 Then
                    Me.shpEQUnloadReq.BackColor = BackColorForCVSignalON
                Else
                    Me.shpEQUnloadReq.BackColor = BackColorForSignalOFF
                End If
            Case "329", "729", "1029"
                If nOnOff = 1 Then
                    Me.shpEQReady.BackColor = BackColorForCVSignalON
                Else
                    Me.shpEQReady.BackColor = BackColorForSignalOFF
                End If
            Case "312", "712", "1012"
                If nOnOff = 1 Then
                    Me.shpHandoff.BackColor = BackColorForCVSignalON
                Else
                    Me.shpHandoff.BackColor = BackColorForSignalOFF
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
        Me.shpEQReady.BackColor = BackColorForSignalOFF
        Me.shpEQUnloadReq.BackColor = BackColorForSignalOFF
        Me.shpHandoff.BackColor = BackColorForSignalOFF
        Me.shpRSTRBTBusy.BackColor = BackColorForSignalOFF
        Me.shpRSTTRReq.BackColor = BackColorForSignalOFF
        Me.shpRSTUnloadComp.BackColor = BackColorForSignalOFF
    End Sub
End Class
