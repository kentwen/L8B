Imports Nini.Config

Public Class frmHSMSSetting

    Dim clsParent As clsCCIM

    Public Sub ShowHSMSSetting(ByVal cls As prjCCIM.clsCCIM)
        clsParent = cls
        Me.Show()
        LoadCIMIniValue()
    End Sub

    Public Sub LoadCIMIniValue()
        Dim objIniSetting = New IniConfigSource(clsParent.IniCIMFilePath)
        Dim ConfigInfo As IConfig

        ConfigInfo = objIniSetting.Configs(STR_SYSTEMSEC)

        txtT3.Text = ConfigInfo.Get(STR_T3)
        txtT5.Text = ConfigInfo.Get(STR_T5)
        txtT6.Text = ConfigInfo.Get(STR_T6)
        txtT7.Text = ConfigInfo.Get(STR_T7)
        txtT8.Text = ConfigInfo.Get(STR_T8)
        txtT9.Text = ConfigInfo.Get(STR_CT) 'T9

        Me.cboConnectMode.SelectedIndex = ConfigInfo.Get(STR_CONNECTMODE)
        txtRetryCount.Text = ConfigInfo.Get(STR_RETRYLIMIT)
        txtLinkTestInterval.Text = ConfigInfo.Get(STR_LINKTEST)
        txtDeviceID.Text = ConfigInfo.Get(STR_DEVICEID)
        txtHOSTIP.Text = ConfigInfo.Get(STR_HOSTIP)
        txtHOSTTCPPort.Text = ConfigInfo.Get(STR_HOSTTCP)
        txtOPIDInAGV.Text = ConfigInfo.Get(STR_AGVOPID)
        txtSYNC.Text = ConfigInfo.Get(STR_S2F17INTERNAL)
        objIniSetting = Nothing
    End Sub

    Private Sub WriteCIMIniValue()
        Dim objIniSetting = New IniConfigSource(clsParent.IniCIMFilePath)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_T3, Me.txtT3.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_T5, Me.txtT5.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_T6, Me.txtT6.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_T7, Me.txtT7.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_T8, Me.txtT8.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_CT, Me.txtT9.Text)

        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_CONNECTMODE, Me.cboConnectMode.SelectedIndex)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_RETRYLIMIT, Me.txtRetryCount.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_LINKTEST, Me.txtLinkTestInterval.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_DEVICEID, Me.txtDeviceID.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_HOSTIP, Me.txtHOSTIP.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_HOSTTCP, Me.txtHOSTTCPPort.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_AGVOPID, Me.txtOPIDInAGV.Text)
        objIniSetting.Configs(STR_SYSTEMSEC).Set(STR_S2F17INTERNAL, Me.txtSYNC.Text)
        objIniSetting.Save()
        objIniSetting = Nothing
    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If Not IsSetingDataRight(Me.txtT3, 1, 120) Then Exit Sub
        If Not IsSetingDataRight(Me.txtT5, 1, 240) Then Exit Sub
        If Not IsSetingDataRight(Me.txtT6, 1, 240) Then Exit Sub
        If Not IsSetingDataRight(Me.txtT7, 1, 240) Then Exit Sub
        If Not IsSetingDataRight(Me.txtT8, 1, 120) Then Exit Sub
        If Not IsSetingDataRight(Me.txtT9, 1, 240) Then Exit Sub
        If Not IsSetingDataRight(Me.txtLinkTestInterval, 1, 600) Then Exit Sub
        If Not IsSetingDataRight(Me.txtDeviceID, -1, -1) Then Exit Sub
        If Not IsSetingDataRight(Me.txtRetryCount, 0, 31) Then Exit Sub
        If Not IsSetingDataRight(Me.txtHOSTTCPPort, -1, -1) Then Exit Sub

        Call WriteCIMIniValue()
        clsParent.HSMSIsChanged()
    End Sub

    Private Function IsSetingDataRight(ByVal nSetVal As Object, ByVal nMin As Integer, ByVal nMax As Integer) As Boolean

        If Not IsNumeric(nSetVal.Text) Then
            nSetVal.Text = ""
            IsSetingDataRight = False
        End If


        'Port/Device
        If nMin <= 0 Then
            IsSetingDataRight = True
            Exit Function
        End If

        If CInt(nSetVal.Text) < 0 Then
            nSetVal.Text = ""
            IsSetingDataRight = False
            Exit Function
        End If

        If Mid(nSetVal.Text, 1, 1) = "0" Then
            nSetVal.Text = ""
            IsSetingDataRight = False
        End If

        If CInt(nSetVal.Text) < nMin Then
            nSetVal.Text = ""
            IsSetingDataRight = False
            Exit Function
        End If

        If CInt(nSetVal.Text) > nMax Then
            nSetVal.Text = ""
            IsSetingDataRight = False
            Exit Function
        End If

        IsSetingDataRight = True
    End Function

    Private Sub frmHSMSSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cboConnectMode.Items.Add("Passive")
        Me.cboConnectMode.Items.Add("Active")

    End Sub

    Private Sub cmdAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbort.Click
        clsParent = Nothing
        Me.Close()
    End Sub
End Class