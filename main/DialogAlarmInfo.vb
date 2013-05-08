Imports System.Windows.Forms

Public Class DialogAlarmInfo
    Dim TimeOut As Integer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        TimerClose.Enabled = False
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        TimerClose.Enabled = False
        Me.Close()
    End Sub

    Private Sub TimerClose_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerClose.Tick
        TimerClose.Enabled = False
        TimeOut = TimeOut - 1
        Cancel_Button.Text = "Close (" & TimeOut & ")"
        If TimeOut <= 0 Then
            Me.Close()
        Else
            TimerClose.Enabled = True
        End If
    End Sub

    Public Sub Showme(ByVal AlarmIndex As Integer)
        Dim mCount As Integer = 0
        Try
            For Each AlarmInfoPair In _L8B.Alarm.AlarmList
                If mCount = AlarmIndex Then
                    With _L8B.Alarm.AlarmList.Item(AlarmInfoPair.Key) '(mMain.Alarm.AlarmList.Keys(AlarmIndex)))
                        LabelSource.Text = .Source.ToString
                        LabelCode.Text = .Code
                        LabelType.Text = .Type.ToString
                        TextBoxMessage.Text = .Message
                        TextBoxRemark.Text = .Remark
                        Dim DateOccurr As Date = CDate(String.Format("{0}{1}{2}{3}/{4}{5}/{6}{7} {8}{9}:{10}{11}:{12}{13}", _
                           .OccurrTime(0), .OccurrTime(1), .OccurrTime(2), .OccurrTime(3), .OccurrTime(4), _
                            .OccurrTime(5), .OccurrTime(6), .OccurrTime(7), .OccurrTime(8), .OccurrTime(9), _
                            .OccurrTime(10), .OccurrTime(11), .OccurrTime(12), .OccurrTime(13)))
                        LabelOccurreTime.Text = String.Format("{0:yyyy/MM/dd HH:mm:ss}", DateOccurr)
                    End With
                    Exit For
                End If
                mCount += 1
            Next

        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
        Me.Visible = True
        Me.TopMost = True
        TimeOut = 30
        Me.Show()
    End Sub
End Class
