Public Class TimeChart_RSTTR
    Public Event PortTabChange(ByVal nPort As Integer)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarTabIdx As Integer

    Public ReadOnly Property TabIdx() As Integer
        Get
            TabIdx = Me.TabControl1.SelectedIndex
        End Get
    End Property

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

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "01F1", "01F4", "01F7", "01FA", "01FD"
                If nOnOff = 1 Then
                    Me.B01F1.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01F1.BackColor = BackColorForSignalOFF
                End If
            Case "01F2", "01F5", "01F8", "01FB", "01FE"
                If nOnOff = 1 Then
                    Me.B01F2.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01F2.BackColor = BackColorForSignalOFF
                End If
            Case "01F0", "01F3", "01F6", "01F9", "01FC"
                If nOnOff = 1 Then
                    Me.B01F0.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01F0.BackColor = BackColorForSignalOFF
                End If            
            Case "13E0", "13E1", "13E2", "13E3", "13E4"
                If nOnOff = 1 Then
                    Me.B13E0.BackColor = BackColorForCVSignalON
                Else
                    Me.B13E0.BackColor = BackColorForSignalOFF
                End If
                'Case "13E1", "13E3", "13E5", "13E7", "13E9"
                '    If nOnOff = 1 Then
                '        Me.B13E1.BackColor = BackColorForCVSignalON
                '    Else
                '        Me.B13E1.BackColor = BackColorForSignalOFF
                '    End If
            Case "1326", "1327", "1328", "1329", "132A"
                If nOnOff = 1 Then
                    Me.B1326.BackColor = BackColorForCVSignalON
                Else
                    Me.B1326.BackColor = BackColorForSignalOFF
                End If 
        End Select
    End Sub
End Class
