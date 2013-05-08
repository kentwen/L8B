Public Class TimeChart_CSTUnloadReqByRST
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
            Case "01B0", "01B1", "01B2", "01B3", "01B4"
                If nOnOff = 1 Then
                    Me.B01B0.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01B0.BackColor = BackColorForSignalOFF
                End If
            Case "01AB", "01AC", "01AD", "01AE", "01AF"
                If nOnOff = 1 Then
                    Me.B01AB.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01AB.BackColor = BackColorForSignalOFF
                End If
            Case "01A0", "01A1", "01A2", "01A3", "01A4"
                If nOnOff = 1 Then
                    Me.B01A0.BackColor = BackColorForRSTSignalON
                Else
                    Me.B01A0.BackColor = BackColorForSignalOFF
                End If

            Case "1370", "1371", "1372", "1373", "1374"
                If nOnOff = 1 Then
                    Me.B1370.BackColor = BackColorForCVSignalON
                Else
                    Me.B1370.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub
End Class
