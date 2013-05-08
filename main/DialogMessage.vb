Imports System.Windows.Forms

Public Class DialogMessage

    Public Enum MESSAGE
        None
        ProgramEnd
        AlarmReset
        InitialLoader
        PauseLoader
        ResumeLoader
        StopLoader
        SwitchToOnlineAuto
        SwitchToOnlineMonitor
        SwitchToOffline
        CancelCassette
        ChangeToLoader
        ChangeToUnloader
    End Enum

    Public Enum MESSAGELEVEL
        [Info]
        [Warnning]
        [Error]
    End Enum

    Private MessageType As MESSAGE
    Private Level As MESSAGELEVEL
    Private MessageString As String
    Private Seconds As Integer
    Private SetTimeOut As Integer
    Private mPassSecond As Integer
    Private DefaultAnswer As Microsoft.VisualBasic.MsgBoxResult
    Private fBuzzer As Boolean
    Private myPort As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        WriteLog("Messagebox-" & Level.ToString & " -- " & MessageString & " User click[" & OK_Button.Text & "]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If MessageType = MESSAGE.CancelCassette AndAlso _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then
            'Host will send $CANCEL
            MessageType = MESSAGE.None
        End If
        ''ShowMessagePostProcess(MessageType, Level, MessageString, myPort)
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        WriteLog("Messagebox-" & Level.ToString & " -- " & MessageString & " User click[" & Cancel_Button.Text & "]", LogMessageType.Info)
        Me.Close()
    End Sub

    Public Sub ShowMessage(ByVal MType As MESSAGE, ByVal vLevel As MESSAGELEVEL, ByVal vMessage As String, ByVal vButtonStyle As Microsoft.VisualBasic.MsgBoxStyle, ByVal dSecond As Double, ByVal vDefaultAnswer As Microsoft.VisualBasic.MsgBoxResult, ByVal bBuzzewrOffButton As Boolean, ByVal nPort As Integer)
        myPort = nPort
        Select Case vLevel
            Case MESSAGELEVEL.Info
                PictureBox.Image = My.Resources.info_48x48
                LabelMessage.ForeColor = Color.Green
            Case MESSAGELEVEL.Warnning
                PictureBox.Image = My.Resources.warning_48x48
                LabelMessage.ForeColor = Color.Orange
            Case MESSAGELEVEL.Error
                PictureBox.Image = My.Resources.Error_48x48
                LabelMessage.ForeColor = Color.Red
        End Select

        Select Case vButtonStyle
            Case MsgBoxStyle.OkCancel
                Cancel_Button.Visible = True
                OldText = Cancel_Button.Text

            Case MsgBoxStyle.YesNo
                OK_Button.Text = "Yes"
                Cancel_Button.Text = "No"
                OldText = Cancel_Button.Text

            Case MsgBoxStyle.OkOnly
                Cancel_Button.Visible = False
                OldText = OK_Button.Text

            Case MsgBoxStyle.YesNoCancel
                OK_Button.Text = "Yes"
                Cancel_Button.Text = "No"
                OldText = Cancel_Button.Text
        End Select

        ButtonBuzzerOff.Visible = bBuzzewrOffButton
        If bBuzzewrOffButton Then
            _L8B.PLC.Buzzer(clsMainPLC.eBuzzerMode.BUZZER1)
            _L8B.PLC.SECSSignalTowerRed(L8BIFPRJ.clsPLC.eLightTowerStatus.TOWER_BLINK)
        End If

        Level = vLevel
        MessageType = MType
        MessageString = vMessage
        DefaultAnswer = vDefaultAnswer
        fBuzzer = bBuzzewrOffButton

        If dSecond > 0 Then
            SetTimeOut = dSecond
            mPassSecond = dSecond * 1000
            TimerCountDown.Enabled = False
            TimerCountDown.Interval = 1000
            TimerCountDown.Enabled = True
            TimerCountDown.Start()
        End If
        Me.Text = vLevel.ToString & " Message   " & Now.ToLocalTime
        LabelMessage.Text = "        " & vMessage
        WriteLog("Messagebox-" & vLevel.ToString & " -- " & vMessage & " Shown", LogMessageType.Info)
        SyncLock _L8B.frmShowQueue
            _L8B.frmShowQueue.Enqueue(Me)
        End SyncLock
    End Sub

    Dim OldText As String

    Private Sub TimerCountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCountDown.Tick
        mPassSecond -= 1000
        If Cancel_Button.Visible Then
            Cancel_Button.Text = OldText & " (" & mPassSecond \ 1000 & ")"
        Else
            OK_Button.Text = OldText & " (" & mPassSecond \ 1000 & ")"
        End If
        If mPassSecond <= 0 Then
            If fBuzzer Then
                _L8B.PLC.Buzzer(clsMainPLC.eBuzzerMode.OFF)
            End If
            WriteLog("Messagebox-" & Level.ToString & " -- " & MessageString & " TIMEOUT", LogMessageType.Info)
            'RaiseEvent Timeout(MessageType, "", SetTimeOut)
            If DefaultAnswer = MsgBoxResult.Ok OrElse DefaultAnswer = MsgBoxResult.Yes Then
                ''ShowMessagePostProcess(MessageType, Level, MessageString, myPort)
            End If
            Me.Close()
        End If
    End Sub

    Private Sub ButtonBuzzerOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuzzerOff.Click
        _L8B.PLC.Buzzer(clsMainPLC.eBuzzerMode.OFF)
        _L8B.PLC.SECSSignalTowerRed(L8BIFPRJ.clsPLC.eLightTowerStatus.TOWER_OFF)
    End Sub

    Private Sub DialogMessage_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If ButtonBuzzerOff.Visible Then
            _L8B.PLC.Buzzer(clsMainPLC.eBuzzerMode.OFF)
            _L8B.PLC.SECSSignalTowerRed(L8BIFPRJ.clsPLC.eLightTowerStatus.TOWER_OFF)
        End If
    End Sub

End Class
