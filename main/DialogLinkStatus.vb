Imports System.Windows.Forms

Public Class DialogLinkStatus

    Private EQOnlineDict As New Dictionary(Of Integer, RadioButton)
    Private EQOfflineDict As New Dictionary(Of Integer, RadioButton)
    Private EQDisplayDict As New Dictionary(Of Integer, Label)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub


    Private Sub ButtonMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMaintenance.Click
        Try
            _L8B.frmMaintenance.ShowMe()
            _L8B.PLC.PM(True)
        Catch ex As Exception
            _L8B.PLC.PM(False)
        End Try

    End Sub

    Public Sub UpdateEQLinkStatusGUI(ByVal nEQ As Integer)
        Select Case mInfo.EQ(nEQ).Link
            Case L8BIFPRJ.clsPLC.eLinkStatus.LINKING
                EQOnlineDict(nEQ).Checked = True
                EQDisplayDict(nEQ).Text = "Online"
                EQDisplayDict(nEQ).BackColor = Color.GreenYellow
            Case L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE
                EQOfflineDict(nEQ).Checked = True
                EQDisplayDict(nEQ).Text = "Offline"
                EQDisplayDict(nEQ).BackColor = Color.Transparent
            Case L8BIFPRJ.clsPLC.eLinkStatus.TRYING
                EQDisplayDict(nEQ).Text = "Trying"
                EQDisplayDict(nEQ).BackColor = Color.Yellow
            Case Else
        End Select
    End Sub


    Public Sub UpdateCVLinkStatusGUI()
        Select Case mInfo.CV.Link
            Case L8BIFPRJ.clsPLC.eLinkStatus.LINKING
                RadioButtonOnlineCV.Checked = True
                LabelLinkStatusCV.Text = "Online"
                LabelLinkStatusCV.BackColor = Color.GreenYellow
            Case L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE
                RadioButtonOfflineCV.Checked = True
                LabelLinkStatusCV.Text = "Offline"
                LabelLinkStatusCV.BackColor = Color.Transparent
            Case L8BIFPRJ.clsPLC.eLinkStatus.TRYING
                LabelLinkStatusCV.Text = "Trying"
                LabelLinkStatusCV.BackColor = Color.Yellow
        End Select
    End Sub

    Private Sub MYUpdateSECSStatusGUI()
        Select Case _L8B.CIM.RemoteMode
            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
                RadioButtonCIMOffline.Checked = True

            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
                RadioButtonCIMOnlineControl.Checked = True

            Case prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
                RadioButtonCIMOnlineMonitor.Checked = True
        End Select

    End Sub

    Private Sub RadioButtonOnlineEQ1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOnlineEQ1.CheckedChanged
        WriteLog("User Click [OnlineEQ1]", LogMessageType.SYS)
        If mInfo.EQ(1).Link = L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE And sender.Checked Then
            _L8B.PLC.EQOnline(1, True)
        End If
        'RadioButtonOfflineEQ1.Checked = True
    End Sub

    Private Sub RadioButtonOfflineEQ1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOfflineEQ1.CheckedChanged
        WriteLog("User Click [OfflineEQ1]", LogMessageType.SYS)
        If mInfo.EQ(1).Link <> L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE And sender.Checked Then
            _L8B.PLC.EQOnline(1, False)
        End If
        'RadioButtonOnlineEQ1.Checked = True
    End Sub

    Private Sub RadioButtonOnlineEQ2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOnlineEQ2.CheckedChanged
        WriteLog("User Click [OnlineEQ2]", LogMessageType.SYS)
        If mInfo.EQ(2).Link = L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE And sender.Checked Then
            _L8B.PLC.EQOnline(2, True)
        End If
        'RadioButtonOfflineEQ2.Checked = True
    End Sub

    Private Sub RadioButtonOfflineEQ2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOfflineEQ2.CheckedChanged
        WriteLog("User Click [OfflineEQ2]", LogMessageType.SYS)
        If mInfo.EQ(2).Link <> L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE And sender.Checked Then
            _L8B.PLC.EQOnline(2, False)
        End If
        'RadioButtonOnlineEQ2.Checked = True
    End Sub

    Private Sub RadioButtonOnlineEQ3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOnlineEQ3.CheckedChanged
        WriteLog("User Click [OnlineEQ3]", LogMessageType.SYS)
        If mInfo.EQ(3).Link = L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE And sender.Checked Then
            _L8B.PLC.EQOnline(3, True)
        End If
        'RadioButtonOfflineEQ3.Checked = True
    End Sub

    Private Sub RadioButtonOfflineEQ3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOfflineEQ3.CheckedChanged
        WriteLog("User Click [OfflineEQ3]", LogMessageType.SYS)
        If mInfo.EQ(3).Link <> L8BIFPRJ.clsPLC.eLinkStatus.OFF_LINE And sender.Checked Then
            _L8B.PLC.EQOnline(3, False)
        End If
        'RadioButtonOnlineEQ3.Checked = True
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EQOnlineDict.Add(1, RadioButtonOnlineEQ1)
        EQOnlineDict.Add(2, RadioButtonOnlineEQ2)
        EQOnlineDict.Add(3, RadioButtonOnlineEQ3)

        EQOfflineDict.Add(1, RadioButtonOfflineEQ1)
        EQOfflineDict.Add(2, RadioButtonOfflineEQ2)
        EQOfflineDict.Add(3, RadioButtonOfflineEQ3)

        EQDisplayDict.Add(1, LabelLinkStatusEQ1)
        EQDisplayDict.Add(2, LabelLinkStatusEQ2)
        EQDisplayDict.Add(3, LabelLinkStatusEQ3)
    End Sub

    Private Sub RadioButtonCIMOnlineControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonCIMOnlineControl.CheckedChanged
        ''
    End Sub

    Private Sub RadioButtonCIMOnlineMonitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonCIMOnlineMonitor.CheckedChanged
        '
    End Sub

    Private Sub RadioButtonCIMOffline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonCIMOffline.CheckedChanged
        '
    End Sub

    Public Sub UpdateSECSStatusGUI()
        MYUpdateSECSStatusGUI()
        GroupBoxSECSMODE.Enabled = True
    End Sub

    Private Sub RadioButtonOnlineCV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOnlineCV.CheckedChanged
        WriteLog("User Click [OnlineCV]", LogMessageType.SYS)
        If Me.Visible Then
            _L8B.PLC.CVOnline(RadioButtonOnlineCV.Checked, 1)
        End If
    End Sub


    Public Sub Showme()
        WriteLog("dlgLinkStatus Showme", LogMessageType.SYS)
        _L8B.PLC.RemoteModeChange()
        If _L8B.Setting.Main.NumberEQ = 1 Then
            GroupBoxEQ1.Enabled = True
            GroupBoxEQ2.Enabled = False
            GroupBoxEQ3.Enabled = False
        ElseIf _L8B.Setting.Main.NumberEQ = 2 Then
            GroupBoxEQ1.Enabled = True
            GroupBoxEQ2.Enabled = True
            GroupBoxEQ3.Enabled = False
        ElseIf _L8B.Setting.Main.NumberEQ = 3 Then
            GroupBoxEQ1.Enabled = True
            GroupBoxEQ2.Enabled = True
            GroupBoxEQ3.Enabled = True
        End If
        Me.Show()
    End Sub

    Private Sub RadioButtonOfflineCV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOfflineCV.CheckedChanged
        WriteLog("User Click [OfflineCV]", LogMessageType.SYS)
        If Me.Visible Then
            _L8B.PLC.CVOnline(RadioButtonOnlineCV.Checked, 0)
        End If
    End Sub

    Private Sub RadioButtonCIMOnlineControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonCIMOnlineControl.Click
        WriteLog("User Click [CIMOnlineControl]", LogMessageType.SYS)
        UpdateRemoteStatus()
        If _L8B.CIM.TCPIPConnect Then
            If _L8B.PLC.AnyEQOnline OrElse _L8B.CIM.RemoteMode <> prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                'If Me.Visible And sender.Checked Then
                GroupBoxSECSMODE.Enabled = False
                _L8B.CIM.Online(prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL)
                'End If
            Else
                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "All Unit need to Linking. try again ", DialogMessage.MESSAGELEVEL.Info)
            End If
        Else
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "TCP is not connect with HSMS Host. try again later", DialogMessage.MESSAGELEVEL.Info)
        End If
    End Sub

    Private Sub RadioButtonCIMOnlineMonitor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonCIMOnlineMonitor.Click
        WriteLog("User Click [CIMOnlineMonitor]", LogMessageType.SYS)
        UpdateRemoteStatus()
        If _L8B.CIM.TCPIPConnect Then
            If _L8B.PLC.AnyEQOnline OrElse _L8B.CIM.RemoteMode <> prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                'If Me.Visible And sender.Checked Then
                GroupBoxSECSMODE.Enabled = False
                _L8B.CIM.Online(prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR)

            Else
                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "All Unit need to Linking. try again ", DialogMessage.MESSAGELEVEL.Info)
            End If
        Else
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "TCP is not connect with HSMS Host. try again later", DialogMessage.MESSAGELEVEL.Info)

        End If
    End Sub

    Private Sub RadioButtonCIMOffline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonCIMOffline.Click
        WriteLog("User Click [CIMOffline]", LogMessageType.SYS)
        'If Me.Visible And sender.Checked Then
        UpdateRemoteStatus()
        If _L8B.CIM.RemoteMode <> prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
            If MsgBox("SECS-> Offline?", MsgBoxStyle.YesNo, "L8B SA SECS Mode-> OffLine") = MsgBoxResult.Yes Then
                WriteLog("User select [YES] in {SECS-> Offline?}", LogMessageType.SYS)
                GroupBoxSECSMODE.Enabled = False
                _L8B.CIM.Offline()
            Else
                WriteLog("User select [NO] in {SECS-> Offline?}", LogMessageType.SYS)
            End If
        Else
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Already in SECS [Offline]!! ", DialogMessage.MESSAGELEVEL.Info, 5)
        End If

        'End If
    End Sub
End Class
