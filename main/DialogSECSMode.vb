Imports System.Windows.Forms

Public Class DialogSECSRemoteMode
    'Dim WithEvents FlashTimer As New System.Timers.Timer
    Dim FlashButtonID As New ArrayList

    'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    Me.Close()
    'End Sub
    Private bFlashStatus As Boolean

    Private SwitchingMode As prjSECS.clsEnumCtl.eRemoteStatus

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub StartTimer() 'ByVal vControl As Object)
        'FlashButtonID.Add(vControl.name)
        'FlashTimer.Interval = 1000
        'FlashTimer.Enabled = True
        'FlashTimer.Start()
    End Sub

    Private Sub ButtonOnlineControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOnlineControl.Click
        'If _L8B.PLC.AnyEQOnline Then
        '    ButtonDisable()
        '    SwitchingMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
        '    _L8B.CIM.Online(SwitchingMode)
        '    StartTimer()
        'Else
        '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "All Unit need to Linking. try again ", DialogMessage.MESSAGELEVEL.Info)
        'End If
    End Sub

    Private Sub ButtonOnlineMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOnlineMonitor.Click
        'If _L8B.PLC.AnyEQOnline Then
        '    ButtonDisable()
        '    SwitchingMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
        '    _L8B.CIM.Online(SwitchingMode)
        '    StartTimer()
        'Else
        '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "All Unit need to Linking. try again ", DialogMessage.MESSAGELEVEL.Info)
        'End If
    End Sub

    Private Sub ButtonOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOffline.Click
        'ButtonDisable()
        'SwitchingMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
        '_L8B.CIM.Offline()
        'StartTimer()
    End Sub

    'Private Sub FlashTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles FlashTimer.Elapsed
    '    If bFlashStatus Then
    '        bFlashStatus = False
    '    Else
    '        bFlashStatus = True
    '    End If

    '    'For Each con As Control In Me.Controls
    '    '    If TypeOf (con) Is Button Then

    '    '    End If
    '    'Next

    '    Dim myButton As Button
    '    Select Case SwitchingMode
    '        Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
    '            myButton = ButtonOffline
    '        Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
    '            myButton = ButtonOnlineControl
    '        Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
    '            myButton = ButtonOnlineMonitor
    '        Case Else
    '            myButton = Nothing
    '    End Select

    '    If bFlashStatus Then
    '        myButton.BackColor = Color.Yellow
    '    Else
    '        myButton.BackColor = ButtonOldBackColor
    '    End If

    'End Sub

    Private Sub ButtonDisable()
        ButtonOnlineControl.Enabled = False
        ButtonOnlineMonitor.Enabled = False
        ButtonOffline.Enabled = True
    End Sub

    Private Sub ButtonEnable()
        ButtonOnlineControl.Enabled = True
        ButtonOnlineMonitor.Enabled = True
        ButtonOffline.Enabled = True
    End Sub

    Dim ButtonOldBackColor As System.Drawing.Color

    Private Sub DialogSECSRemoteMode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ButtonOldBackColor = Me.BackColor
    End Sub

    Public Sub UpdateGUI()
        'FlashTimer.Stop()
        'FlashTimer.Enabled = False
        ButtonEnable()

        Select Case _L8B.CIM.RemoteMode
            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
                ButtonOffline.BackColor = Color.GreenYellow
                ButtonOnlineControl.BackColor = ButtonOldBackColor
                ButtonOnlineMonitor.BackColor = ButtonOldBackColor
                ButtonOffline.Enabled = False

            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
                ButtonOffline.BackColor = ButtonOldBackColor
                ButtonOnlineControl.BackColor = Color.GreenYellow
                ButtonOnlineMonitor.BackColor = ButtonOldBackColor
                ButtonOnlineControl.Enabled = False

            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
                ButtonOffline.BackColor = ButtonOldBackColor
                ButtonOnlineControl.BackColor = ButtonOldBackColor
                ButtonOnlineMonitor.BackColor = Color.GreenYellow
                ButtonOnlineMonitor.Enabled = False
        End Select

    End Sub
End Class
