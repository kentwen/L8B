Imports System.Windows.Forms

Public Class DialogMachineSetting

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        WriteLog(Me.Name & ": user click [OK_Button] to Save Machine Settings", LogMessageType.Info)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        With _L8B.Setting.Main
            If .MachineType <> ListBoxMachineType.SelectedIndex And CassetteOnAnyPort() Then
                WriteLog("MachineType change")
            End If
            .MachineType = ListBoxMachineType.SelectedIndex
            .NumberEQ = NumericUpDownEQ.Value
            .NumberCV = NumericUpDownCV.Value
            .NumberPort = NumericUpDownPort.Value
            .NumberBufferSlot(1) = NumericUpDownBufferSlot1.Value
            .NumberBufferSlot(2) = NumericUpDownBufferSlot2.Value
            .NumberBufferSlot(3) = NumericUpDownBufferSlot3.Value
            .NumberBuffer = NumericUpDownBuffer.Value
            .RecipeMode = ComboBoxRecipeMode.SelectedIndex
            .RobotArmUse = ComboBoxRobotArmUse.SelectedIndex
            .UnloaderOfflineAutoStart = CheckBoxUnloaderOfflineAutoStart.Checked
            .GlassPreload = CheckBoxGlassPreload.Checked
            .FIReportGGradeRecipeEndChar = ComboBoxFIRecipeEndChar.Text
            _L8B.PLC.SetGlassPreload(.GlassPreload)
            _L8B.PLC.RobotArmUse(.RobotArmUse)
            .CVSectionPort(1) = NumericUpDown1.Value
            .CVSectionPort(2) = NumericUpDown2.Value
            .CVSectionPort(3) = NumericUpDown3.Value
            .CVSectionPort(4) = NumericUpDown4.Value
            .CVSectionPort(5) = NumericUpDown5.Value
            .CVSectionPort(6) = NumericUpDown6.Value
            .CVSectionID(1) = NumericUpDownS1.Value
            .CVSectionID(2) = NumericUpDownS2.Value
            .CVSectionID(3) = NumericUpDownS3.Value
            .CVSectionID(4) = NumericUpDownS4.Value
            .CVSectionID(5) = NumericUpDownS5.Value
            .CVSectionID(6) = NumericUpDownS6.Value
            .MacroEQID = NumericUpDownMacroEQID.Value
            Select Case .MachineType
                Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR 'ClsSetting.Ini.EMACHINETYPE.FI,
                    UIModeSave(prjSECS.clsEnumCtl.ePortType.TYPE_U, False)
            End Select

        End With
        With _L8B.Setting.DataBaseSetting
            .DataProvide = "System.Data.SQLite"
            .SqliteDbFile = TextBoxDatabaseFile.Text
            .ConnectionString = "data source=" & TextBoxDatabaseFile.Text
        End With

        With _L8B.Setting.ExtraIniFile
            .CIM = TextBoxCIMini.Text
            .PLC = TextBoxPLCini.Text
        End With
        _L8B.Setting.IniSave()
        _L8B.frmMain.UpdateGUI()
        _L8B.frmMain.UpdateBufferContentMenu()
        '_L8B.frmMain.ComboBoxModule.DataSource = Nothing
        _L8B.frmMain.UpdateArmMode()
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub ButtonDatabaseFileSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDatabaseFileSelect.Click
        Dim ReadDialog As New OpenFileDialog

        ReadDialog.Filter = "Sqlite3 files (*.db3)|*.db3|All files (*.*)|*.*"
        ReadDialog.FilterIndex = 2
        ReadDialog.RestoreDirectory = True

        If ReadDialog.ShowDialog() = DialogResult.OK Then
            TextBoxDatabaseFile.Text = ReadDialog.FileName
        End If
    End Sub


    Public Sub ShowMe()
        'CreateMachineTypeDataSource()
        With _L8B.Setting.Main
            ListBoxMachineType.SelectedIndex = .MachineType
            NumericUpDownEQ.Value = System.Math.Max(.NumberEQ, NumericUpDownEQ.Minimum)
            NumericUpDownCV.Value = System.Math.Max(.NumberCV, NumericUpDownCV.Minimum)
            NumericUpDownPort.Value = System.Math.Max(.NumberPort, NumericUpDownPort.Minimum)
            NumericUpDownBufferSlot1.Value = System.Math.Max(.NumberBufferSlot(1), NumericUpDownBufferSlot1.Minimum)
            NumericUpDownBufferSlot2.Value = System.Math.Max(.NumberBufferSlot(2), NumericUpDownBufferSlot2.Minimum)
            NumericUpDownBufferSlot3.Value = System.Math.Max(.NumberBufferSlot(3), NumericUpDownBufferSlot3.Minimum)
            NumericUpDownBuffer.Value = System.Math.Max(.NumberBuffer, NumericUpDownBuffer.Minimum)
            ComboBoxRecipeMode.SelectedIndex = .RecipeMode
            ComboBoxRobotArmUse.SelectedIndex = .RobotArmUse
            CheckBoxUnloaderOfflineAutoStart.Checked = .UnloaderOfflineAutoStart
            CheckBoxGlassPreload.Checked = .GlassPreload
            ComboBoxFIRecipeEndChar.Text = .FIReportGGradeRecipeEndChar
            If .MachineType = ClsSetting.EMACHINETYPE.FI Then
                PanelFIRecipeFormat.Visible = True
            ElseIf .MachineType = ClsSetting.EMACHINETYPE.ButterFly Then
                GroupBoxButterflyMacro.Visible = True
            Else
                GroupBoxButterflyMacro.Visible = False
                PanelFIRecipeFormat.Visible = False
            End If
            NumericUpDown1.Value = .CVSectionPort(1)
            NumericUpDown2.Value = .CVSectionPort(2)
            NumericUpDown3.Value = .CVSectionPort(3)
            NumericUpDown4.Value = .CVSectionPort(4)
            NumericUpDown5.Value = .CVSectionPort(5)
            NumericUpDown6.Value = .CVSectionPort(6)
            NumericUpDownS1.Value = .CVSectionID(1)
            NumericUpDownS2.Value = .CVSectionID(2)
            NumericUpDownS3.Value = .CVSectionID(3)
            NumericUpDownS4.Value = .CVSectionID(4)
            NumericUpDownS5.Value = .CVSectionID(5)
            NumericUpDownS6.Value = .CVSectionID(6)
            NumericUpDownMacroEQID.Value = .MacroEQID
        End With
        TextBoxDatabaseFile.Text = _L8B.Setting.DataBaseSetting.SqliteDbFile

        With _L8B.Setting.ExtraIniFile
            TextBoxCIMini.Text = .CIM
            TextBoxPLCini.Text = .PLC
        End With


        BufferGUI()
        Me.Show()
    End Sub

    Private Sub ButtonCIMini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCIMini.Click
        Dim ReadDialog As New OpenFileDialog

        ReadDialog.Filter = "Ini files (*.ini)|*.ini|All files (*.*)|*.*"
        ReadDialog.FilterIndex = 2
        ReadDialog.RestoreDirectory = True

        If ReadDialog.ShowDialog() = DialogResult.OK Then
            TextBoxCIMini.Text = ReadDialog.FileName
        End If
    End Sub

    Private Sub ButtonSecsXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSecsXML.Click
        Dim ReadDialog As New OpenFileDialog

        ReadDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        ReadDialog.FilterIndex = 2
        ReadDialog.RestoreDirectory = True

        If ReadDialog.ShowDialog() = DialogResult.OK Then
            TextBoxSecsXML.Text = ReadDialog.FileName
        End If
    End Sub

    Private Sub ButtonPLCini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPLCini.Click
        Dim ReadDialog As New OpenFileDialog

        ReadDialog.Filter = "Ini files (*.ini)|*.ini|All files (*.*)|*.*"
        ReadDialog.FilterIndex = 2
        ReadDialog.RestoreDirectory = True

        If ReadDialog.ShowDialog() = DialogResult.OK Then
            TextBoxPLCini.Text = ReadDialog.FileName
        End If
    End Sub

    Private Sub ListBoxMachineType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxMachineType.SelectedIndexChanged
        If ListBoxMachineType.Text = "FI" Then
            PanelFIRecipeFormat.Visible = True
        ElseIf ListBoxMachineType.Text = "ButterFly" Then
            GroupBoxButterflyMacro.Visible = True
            PanelFIRecipeFormat.Visible = IIf(NumericUpDownMacroEQID.Value > 0, True, False)
        Else
            PanelFIRecipeFormat.Visible = False
            GroupBoxButterflyMacro.Visible = False
        End If
    End Sub

    Private Sub NumericUpDownBuffer_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownBuffer.ValueChanged
        BufferGUI()
    End Sub

    Private Sub BufferGUI()
        Select Case NumericUpDownBuffer.Value
            Case 1
                NumericUpDownBufferSlot1.Enabled = True
                NumericUpDownBufferSlot2.Enabled = False
                NumericUpDownBufferSlot3.Enabled = False
            Case 2
                NumericUpDownBufferSlot1.Enabled = True
                NumericUpDownBufferSlot2.Enabled = True
                NumericUpDownBufferSlot3.Enabled = False
            Case 3
                NumericUpDownBufferSlot1.Enabled = True
                NumericUpDownBufferSlot2.Enabled = True
                NumericUpDownBufferSlot3.Enabled = True
        End Select
    End Sub

    Private Sub NumericUpDownMacroEQID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDownMacroEQID.ValueChanged
        If NumericUpDownMacroEQID.Value > 0 Then
            PanelFIRecipeFormat.Visible = True
        Else
            PanelFIRecipeFormat.Visible = False
        End If
    End Sub
End Class

