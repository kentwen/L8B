Public Class TimeChart_CVTR
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
            Case "01E1", "01E4", "01E7", "01EA", "01ED"
                If nOnOff = 1 Then
                    Me.B01E1.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01E1.BackColor = BackColorForSignalOFF
                End If
            Case "01E2", "01E5", "01E8", "01EB", "01EE"
                If nOnOff = 1 Then
                    Me.B01E2.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01E2.BackColor = BackColorForSignalOFF
                End If
            Case "01E0", "01E3", "01E6", "01E9", "01EC"
                If nOnOff = 1 Then
                    Me.B01E0.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01E0.BackColor = BackColorForSignalOFF
                End If        
            Case "13D1", "13D3", "13D5", "13D7", "13D9"
                If nOnOff = 1 Then
                    Me.B13D1.BackColor = BackColorForCVSignalON
                Else
                    Me.B13D1.BackColor = BackColorForSignalOFF
                End If
            Case "1326", "1327", "1328", "1329", "132A"
                If nOnOff = 1 Then
                    Me.B1326.BackColor = BackColorForCVSignalON
                Else
                    Me.B1326.BackColor = BackColorForSignalOFF
                End If
            Case "13D0", "13D2", "13D4", "13D6", "13D8"
                If nOnOff = 1 Then
                    Me.B13D0.BackColor = BackColorForCVSignalON
                Else
                    Me.B13D0.BackColor = BackColorForSignalOFF
                End If             
        End Select
    End Sub

End Class
