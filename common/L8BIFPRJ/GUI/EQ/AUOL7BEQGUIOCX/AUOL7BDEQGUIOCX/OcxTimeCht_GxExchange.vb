Imports System.Drawing
Public Class OcxTimeCht_GxExchange
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
            Case "30", "B0", "130"
                If nOnOff = 1 Then
                    Me.shpRSTTTReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTTTReq.BackColor = BackColorForSignalOFF
                End If
            Case "31", "B1", "131"
                If nOnOff = 1 Then
                    Me.shpRSTTBTGetBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTTBTGetBusy.BackColor = BackColorForSignalOFF
                End If
            Case "32", "B2", "132"
                If nOnOff = 1 Then
                    Me.shpRSTRBTPutBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTRBTPutBusy.BackColor = BackColorForSignalOFF
                End If
            Case "33", "B3", "133"
                If nOnOff = 1 Then
                    Me.shpRSTExComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.shpRSTExComp.BackColor = BackColorForSignalOFF
                End If
            
            Case "330", "730", "1030"
                If nOnOff = 1 Then
                    Me.shpEQExReq.BackColor = BackColorForCVSignalON
                Else
                    Me.shpEQExReq.BackColor = BackColorForSignalOFF
                End If
            Case "331", "731", "1031"
                If nOnOff = 1 Then
                    Me.shpEQReady .BackColor = BackColorForCVSignalON
                Else
                    Me.shpEQReady.BackColor = BackColorForSignalOFF
                End If
            Case "312", "712", "1012"
                If nOnOff = 1 Then
                    Me.shpEQHandoff.BackColor = BackColorForCVSignalON
                Else
                    Me.shpEQHandoff.BackColor = BackColorForSignalOFF
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
        Me.shpEQExReq.BackColor = BackColorForSignalOFF
        Me.shpEQHandoff.BackColor = BackColorForSignalOFF
        Me.shpEQReady.BackColor = BackColorForSignalOFF
        Me.shpRSTExComp.BackColor = BackColorForSignalOFF
        Me.shpRSTRBTPutBusy.BackColor = BackColorForSignalOFF
        Me.shpRSTTBTGetBusy.BackColor = BackColorForSignalOFF
        Me.shpRSTTTReq.BackColor = BackColorForSignalOFF
    End Sub
End Class
