Public Class frmSampleGlassSetting

    Private Sub frmSampleGlassSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If MySampleGxSetting.nSampleGxEnable1 = SIGNAL_ON Then
            Me.chkboxEnableT1.Checked = True
        Else
            Me.chkboxEnableT1.Checked = False
        End If

        If MySampleGxSetting.nSampleGxEnable3 = SIGNAL_ON Then
            Me.chkboxEnableT3.Checked = True
        Else
            Me.chkboxEnableT3.Checked = False
        End If

        Me.cboEQ1Week.SelectedIndex = MySampleGxSetting.nEQ1Week
        Me.txtHourT1.Text = MySampleGxSetting.nHour1
        Me.txtHourT3.Text = MySampleGxSetting.nHour3

        Me.cboEQ2Week.SelectedIndex = MySampleGxSetting.nEQ2Week
        Me.txtMinuteT1.Text = MySampleGxSetting.nMinute1
        Me.txtMinuteT3.Text = MySampleGxSetting.nMinute3

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim nHourT1 As Integer = 0
        Dim nHourT3 As Integer = 0
        Dim nMinute1 As Integer = 0
        Dim nMinute3 As Integer = 0
        Dim nEQ1Week As Integer = 0
        Dim nEQ2week As Integer = 0


        If Me.chkboxEnableT1.Checked = True Then
            MySampleGxSetting.nSampleGxEnable1 = SIGNAL_ON
        Else
            MySampleGxSetting.nSampleGxEnable1 = SIGNAL_OFF
        End If

        If Me.chkboxEnableT3.Checked = True Then
            MySampleGxSetting.nSampleGxEnable3 = SIGNAL_ON
        Else
            MySampleGxSetting.nSampleGxEnable3 = SIGNAL_OFF
        End If

        nEQ1Week = Me.cboEQ1Week.SelectedIndex
        nHourT1 = Val(Me.txtHourT1.Text)
        nHourT3 = Val(Me.txtHourT3.Text)

        nEQ2week = Me.cboEQ2Week.SelectedIndex
        nMinute1 = Val(Me.txtMinuteT1.Text)
        nMinute3 = Val(Me.txtMinuteT3.Text)

        If nHourT1 < 0 Or nHourT1 > 23 Then
            Me.txtHourT1.Text = MySampleGxSetting.nHour1
        End If

        If nHourT3 < 0 Or nHourT3 > 23 Then
            Me.txtHourT3.Text = MySampleGxSetting.nHour3
        End If

        If nMinute1 < 0 Or nMinute1 > 59 Then
            Me.txtMinuteT1.Text = MySampleGxSetting.nMinute1
        End If

        If nMinute3 < 0 Or nMinute3 > 59 Then
            Me.txtMinuteT3.Text = MySampleGxSetting.nMinute3
        End If

        MySampleGxSetting.nEQ1Week = nEQ1Week
        MySampleGxSetting.nHour1 = Val(Me.txtHourT1.Text)
        MySampleGxSetting.nHour3 = Val(Me.txtHourT3.Text)

        MySampleGxSetting.nEQ2Week = nEQ2week
        MySampleGxSetting.nMinute1 = Val(Me.txtMinuteT1.Text)
        MySampleGxSetting.nMinute3 = Val(Me.txtMinuteT3.Text)

        source.Configs(SAMPLEGX_SECTION).Set("Time1_Enable", MySampleGxSetting.nSampleGxEnable1)
        source.Configs(SAMPLEGX_SECTION).Set("Time3_Enable", MySampleGxSetting.nSampleGxEnable3)

        source.Configs(SAMPLEGX_SECTION).Set("Time1_Hour", Val(Me.txtHourT1.Text))
        source.Configs(SAMPLEGX_SECTION).Set("Time3_Hour", Val(Me.txtHourT3.Text))
        source.Configs(SAMPLEGX_SECTION).Set("Time1_Minute", Val(Me.txtMinuteT1.Text))
        source.Configs(SAMPLEGX_SECTION).Set("Time3_Minute", Val(Me.txtMinuteT3.Text))

        source.Configs(SAMPLEGX_SECTION).Set("EQ1Week", nEQ1Week)
        source.Configs(SAMPLEGX_SECTION).Set("EQ2Week", nEQ2week)

        source.Save()

        WriteSampleGlassSettingParameter()

    End Sub
End Class