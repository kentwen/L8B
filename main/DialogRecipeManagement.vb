Imports System.Windows.Forms
Imports System.Data
Public Class DialogRecipeManagement
    Dim Saving As Boolean

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub


    Public Sub UpdateRecipeList()
        Try
            Dim dt As DataTable = _L8B.db.QueryRecipeList
            DataGridViewRecipe.DataSource = dt
            ComboBoxRecipeID.DisplayMember = "ID"
            ComboBoxRecipeID.DataSource = dt

            Select Case _L8B.Setting.Main.RecipeMode
                Case ClsSetting.eRECIPEMODE.SAME
                    GroupBoxEQSettingDifferent.Visible = False
                    GroupBoxRecipeSame.Visible = True
                    If Not Saving Then
                        ComboBoxEQrecipe.DataSource = Nothing
                        ComboBoxEQrecipe.DataSource = _L8B.db.EQRecipeList(1)
                    End If

                Case ClsSetting.eRECIPEMODE.DIFFERENT
                    GroupBoxRecipeSame.Visible = False
                    GroupBoxEQSettingDifferent.Visible = True
                    If Not Saving Then
                        ComboBoxRecipeEQ1.DataSource = Nothing
                        ComboBoxRecipeEQ1.DataSource = _L8B.db.EQRecipeList(1)
                        ComboBoxRecipeEQ2.DataSource = Nothing
                        'Add  2010-11-09 for Ink repair as EQ3
                        If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.COLORREPAIR Then
                            ComboBoxRecipeEQ2.DataSource = _L8B.db.EQRecipeList(3)
                        Else
                            ComboBoxRecipeEQ2.DataSource = _L8B.db.EQRecipeList(2)
                        End If
                    End If
            End Select

            GroupBoxColorRepair.Visible = False
            GroupBoxGlassSelection.Visible = False

            NumericUpDownSampleGlass.Visible = True
            Label5.Visible = True

            Select Case _L8B.Setting.Main.MachineType
                Case ClsSetting.EMACHINETYPE.ButterFly
                    GroupBoxGlassSelection.Visible = True
                    GroupBoxFIReport.Visible = False
                    CheckBoxEQ1.Visible = True
                    CheckBoxEQ2.Visible = True
                    LabelTapeRepair.Visible = False
                    LabelInkRepair.Visible = False

                Case ClsSetting.EMACHINETYPE.FI
                    GroupBoxGlassSelection.Visible = True
                    GroupBoxFIReport.Visible = True
                    'NumericUpDownSampleGlass.Visible = True
                    'Label5.Visible = True

                Case ClsSetting.EMACHINETYPE.REPAIR
                    GroupBoxColorRepair.Visible = False
                    NumericUpDownSampleGlass.Visible = False
                    GroupBoxGlassSelection.Visible = False
                    GroupBoxFIReport.Visible = False
                    Label5.Visible = False

                Case ClsSetting.EMACHINETYPE.COLORREPAIR
                    GroupBoxColorRepair.Visible = True
                    NumericUpDownSampleGlass.Visible = False
                    GroupBoxGlassSelection.Visible = False
                    GroupBoxFIReport.Visible = False
                    Label5.Visible = False
                    CheckBoxEQ1.Visible = False
                    CheckBoxEQ2.Visible = False
                    LabelTapeRepair.Visible = True
                    LabelInkRepair.Visible = True
            End Select

            'LabelMode.Visible = False
            'ComboBoxModeEQ1.Enabled = False
            'ComboBoxModeEQ2.Enabled = False

            'If _L8b.Setting.Main.AOIEQID = 1 Then
            '    LabelMode.Visible = True
            '    ComboBoxModeEQ1.Visible = True
            'ElseIf _L8b.Setting.Main.AOIEQID = 2 Then
            '    LabelMode.Visible = True
            '    ComboBoxModeEQ2.Visible = True

            'End If
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecipeSave.Click

        Dim RecipeID As String = ComboBoxRecipeID.Text
        Dim bChange As Boolean
        WriteLog(Me.Name & ": user click [Save] to Save Recipe=" & RecipeID, LogMessageType.Info)
        Try

            If RecipeID.Length = 0 Then
                Exit Sub
            End If
            ButtonRecipeSave.Enabled = False
            If _L8B.db.CheckRecipe(RecipeID) Then
                'Old Recipe
                Dim myRecipe As cRecipe = _L8B.db.LoadRecipe(MyTrim(ComboBoxRecipeID.Text))
                If TextBoxRemark.Text <> myRecipe.Remark Then bChange = True
                If ComboBoxVCRPos.Text <> myRecipe.VCRPosition Then bChange = True
                If ComboBoxGlassType.SelectedIndex <> myRecipe.GlassType Then bChange = True
                If ComboBoxRobotSpeed.SelectedIndex <> myRecipe.RobotSpeed Then bChange = True
                If ComboBoxRecipeEQ1.Text <> myRecipe.EQPPID(1) Then bChange = True
                If ComboBoxRecipeEQ2.Text <> myRecipe.EQPPID(2) Then bChange = True
                If ComboBoxEQrecipe.Text <> myRecipe.EQPPID Then bChange = True
                If myRecipe.FICIMResult = cRecipe.eFICIMGradeReport.DMQC And RadioButtonDGrade.Checked Then
                Else
                    bChange = True
                End If

                If myRecipe.FICIMResult = cRecipe.eFICIMGradeReport.GLASS And RadioButtonGGrade.Checked Then
                Else
                    bChange = True
                End If

                If myRecipe.FICIMResult = cRecipe.eFICIMGradeReport.NOTHING And Not RadioButtonGGrade.Checked And Not RadioButtonDGrade.Checked Then
                Else
                    bChange = True
                End If
                'ComboBoxRepair.text = myRecipe.

                If NumericUpDownSampleGlass.Value <> Val(myRecipe.SampleGlass) Then bChange = True

                For i As Integer = 1 To MAXCASSETTESLOT
                    If myRecipe.SelectGlass(i - 1) = "1" And SelectCheckBox(i).Checked = False Then
                        bChange = True
                    ElseIf myRecipe.SelectGlass(i - 1) = "0" And SelectCheckBox(i).Checked = True Then
                        bChange = True
                    End If
                Next


                If CheckBoxEQ1.Checked <> myRecipe.EQRecipe(1).bSelect Then bChange = True
                If CheckBoxEQ2.Checked <> myRecipe.EQRecipe(2).bSelect Then bChange = True
            Else
                WriteLog("New Recipe " & RecipeID)
                bChange = True
            End If

            If Not bChange Then
                _L8B.Log.Hide()
                MsgBox(String.Format("No Chnage RecipeID = {0}.", ComboBoxRecipeID.Text), MsgBoxStyle.YesNo, "L7B Recipe management")
                ButtonRecipeSave.Enabled = True
                Exit Sub
            End If

            _L8B.Log.Hide()
            If MsgBox(String.Format("Save RecipeID = {0}?", ComboBoxRecipeID.Text), MsgBoxStyle.YesNo, "L7B Recipe management") = MsgBoxResult.Yes Then
                Dim Version As String = GetAUODateTime(Now)
                Dim remark As String = TextBoxRemark.Text
                Dim RobotSpeed As String = ComboBoxRobotSpeed.SelectedIndex
                Dim GlassType As String = ComboBoxGlassType.SelectedIndex
                Dim VCRPos As String = Val(ComboBoxVCRPos.Text)
                Dim Recipe(2) As cDataBase.EQrecipe
                Dim SampleGlass As String = NumericUpDownSampleGlass.Value
                Dim SelectGlass As String = GetSelectGlass()
                Dim EQRecipe As String = ComboBoxEQrecipe.Text
                Dim EQSelection As Integer = 1  'default =1; in case of butterfly is set as the EQ selection

                Dim FICIMReport As cRecipe.eFICIMGradeReport
                Dim ColorRepairMode As L8BIFPRJ.clsPLC.eColorRepairMode = ComboBoxRepair.SelectedIndex

                If RadioButtonDGrade.Checked Then
                    FICIMReport = cRecipe.eFICIMGradeReport.DMQC
                ElseIf RadioButtonGGrade.Checked Then
                    FICIMReport = cRecipe.eFICIMGradeReport.GLASS
                Else
                    FICIMReport = cRecipe.eFICIMGradeReport.NOTHING
                End If


                If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.ButterFly Then
                    EQSelection = IIf(CheckBoxEQ1.Checked, 1, 0) + IIf(CheckBoxEQ2.Checked, 2, 0)
                End If

                If Val(SampleGlass) <= 0 Then
                    _L8B.Log.Hide()
                    MsgBox("[I Mode]  Sample Glass = 0!  Please select some and try again.", MsgBoxStyle.OkOnly, "Recipe Managenemt")
                End If

                With Recipe(1)
                    .PPID = ComboBoxRecipeEQ1.Text
                End With

                With Recipe(2)
                    .PPID = ComboBoxRecipeEQ2.Text
                End With


                If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.DIFFERENT Then
                    _L8B.db.ThreeEQRecipeUpdate(RecipeID, Version, remark, VCRPos, GlassType, RobotSpeed, EQSelection, SampleGlass, SelectGlass, Recipe, FICIMReport, ColorRepairMode)
                ElseIf _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.SAME Then
                    _L8B.db.OneEQRecipeUpdate(RecipeID, Version, remark, VCRPos, GlassType, RobotSpeed, EQRecipe, SampleGlass, SelectGlass, FICIMReport, ColorRepairMode)
                End If

                Saving = True
                UpdateRecipeList()
                ComboBoxRecipeID.Text = RecipeID
                UpdateContent(ComboBoxRecipeID.Text)
                _L8B.CIM.RecipeChangedReport(mInfo.Robot.UnitID, RecipeID)
                Saving = False
            Else

            End If
            UpdateContent(ComboBoxRecipeID.Text)
            ButtonRecipeSave.Enabled = True
        Catch ex As Exception
            ButtonRecipeSave.Enabled = True
            WriteLog(ex.ToString)
        End Try

    End Sub


    Private Function GetSelectGlass() As String
        Dim sTmp As String = ""
        Dim isSelected As Boolean = False
        For i As Integer = 1 To MAXCASSETTESLOT
            If SelectCheckBox(i).Checked Then
                sTmp &= "1"
                isSelected = True
            Else
                sTmp &= "0"
            End If
        Next

        If Not isSelected Then
            _L8B.Log.Hide()
            MsgBox("[U Mode]  No Sample Glass Selected!  Please select some and try again.", MsgBoxStyle.OkOnly, "Recipe Managenemt")
        End If
        Return sTmp
    End Function

    Dim SelectCheckBox As Dictionary(Of Integer, CheckBox)

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SelectCheckBox = New Dictionary(Of Integer, CheckBox)

        SelectCheckBox.Add(1, CheckBox1)
        SelectCheckBox.Add(2, CheckBox2)
        SelectCheckBox.Add(3, CheckBox3)
        SelectCheckBox.Add(4, CheckBox4)
        SelectCheckBox.Add(5, CheckBox5)
        SelectCheckBox.Add(6, CheckBox6)
        SelectCheckBox.Add(7, CheckBox7)
        SelectCheckBox.Add(8, CheckBox8)
        SelectCheckBox.Add(9, CheckBox9)
        SelectCheckBox.Add(10, CheckBox10)
        SelectCheckBox.Add(11, CheckBox11)
        SelectCheckBox.Add(12, CheckBox12)
        SelectCheckBox.Add(13, CheckBox13)
        SelectCheckBox.Add(14, CheckBox14)
        SelectCheckBox.Add(15, CheckBox15)
        SelectCheckBox.Add(16, CheckBox16)
        SelectCheckBox.Add(17, CheckBox17)
        SelectCheckBox.Add(18, CheckBox18)
        SelectCheckBox.Add(19, CheckBox19)
        SelectCheckBox.Add(20, CheckBox20)
        SelectCheckBox.Add(21, CheckBox21)
        SelectCheckBox.Add(22, CheckBox22)
        SelectCheckBox.Add(23, CheckBox23)
        SelectCheckBox.Add(24, CheckBox24)
        SelectCheckBox.Add(25, CheckBox25)
        SelectCheckBox.Add(26, CheckBox26)
        SelectCheckBox.Add(27, CheckBox27)
        SelectCheckBox.Add(28, CheckBox28)
        SelectCheckBox.Add(29, CheckBox29)
        SelectCheckBox.Add(30, CheckBox30)
        SelectCheckBox.Add(31, CheckBox31)
        SelectCheckBox.Add(32, CheckBox32)
        SelectCheckBox.Add(33, CheckBox33)
        SelectCheckBox.Add(34, CheckBox34)
        SelectCheckBox.Add(35, CheckBox35)
        SelectCheckBox.Add(36, CheckBox36)
        SelectCheckBox.Add(37, CheckBox37)
        SelectCheckBox.Add(38, CheckBox38)
        SelectCheckBox.Add(39, CheckBox39)
        SelectCheckBox.Add(40, CheckBox40)
        SelectCheckBox.Add(41, CheckBox41)
        SelectCheckBox.Add(42, CheckBox42)
        SelectCheckBox.Add(43, CheckBox43)
        SelectCheckBox.Add(44, CheckBox44)
        SelectCheckBox.Add(45, CheckBox45)
        SelectCheckBox.Add(46, CheckBox46)
        SelectCheckBox.Add(47, CheckBox47)
        SelectCheckBox.Add(48, CheckBox48)
        SelectCheckBox.Add(49, CheckBox49)
        SelectCheckBox.Add(50, CheckBox50)
        SelectCheckBox.Add(51, CheckBox51)
        SelectCheckBox.Add(52, CheckBox52)
        SelectCheckBox.Add(53, CheckBox53)
        SelectCheckBox.Add(54, CheckBox54)
        SelectCheckBox.Add(55, CheckBox55)
        SelectCheckBox.Add(56, CheckBox56)

    End Sub

    Public Sub ShowMe(ByVal Parent As System.Windows.Forms.IWin32Window)
        UpdateRecipeList()
        UpdateContent(ComboBoxRecipeID.Text)
        Me.Visible = False
        Me.Show(Parent)
    End Sub

    Private Sub DataGridViewRecipe_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridViewRecipe.RowPostPaint
        Using b As SolidBrush = New SolidBrush(sender.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex + 1.ToString(System.Globalization.CultureInfo.CurrentUICulture), sender.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub ComboBoxRecipeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxRecipeID.TextChanged
        'Debug.WriteLine("ComboBoxRecipeID_TextChanged " & ComboBoxRecipeID.Text)
        UpdateContent(ComboBoxRecipeID.Text)
    End Sub

    Private Sub UpdateContent(ByVal PPID As String)
        Try

            If ComboBoxRecipeID.SelectedIndex = -1 Or ComboBoxRecipeID.Text = "" Or Saving Then
                If PPID.Length = 3 AndAlso PPID.Chars(PPID.Length - 1) = _L8B.Setting.Main.FIReportGGradeRecipeEndChar Then
                    RadioButtonDGrade.Checked = False
                    RadioButtonGGrade.Checked = True
                    GroupBoxFIReport.Enabled = False
                Else
                    GroupBoxFIReport.Enabled = True
                    RadioButtonDGrade.Checked = True
                    RadioButtonGGrade.Checked = False
                End If
                Exit Sub
            End If

            'Debug.WriteLine(PPID)
            Dim myRecipe As cRecipe = _L8B.db.LoadRecipe(PPID)
            If myRecipe Is Nothing Then
                Exit Sub
            End If

            TextBoxRemark.Text = myRecipe.Remark
            ComboBoxVCRPos.Text = myRecipe.VCRPosition
            ComboBoxGlassType.SelectedIndex = myRecipe.GlassType
            ComboBoxRobotSpeed.SelectedIndex = myRecipe.RobotSpeed
            ComboBoxRecipeEQ1.Text = myRecipe.EQPPID(1)
            ComboBoxRecipeEQ2.Text = myRecipe.EQPPID(2)
            ComboBoxEQrecipe.Text = myRecipe.EQPPID
            ComboBoxRepair.SelectedIndex = myRecipe.ColorRepairMode
            If NumericUpDownSampleGlass.Visible Then
                NumericUpDownSampleGlass.Value = Val(myRecipe.SampleGlass)
            End If

            For i As Integer = 1 To MAXCASSETTESLOT
                If myRecipe.SelectGlass(i) = 1 Then
                    SelectCheckBox(i).Checked = True
                Else
                    SelectCheckBox(i).Checked = False
                End If
            Next

            Select Case myRecipe.FICIMResult
                Case cRecipe.eFICIMGradeReport.DMQC
                    RadioButtonGGrade.Checked = False
                    RadioButtonDGrade.Checked = True
                Case cRecipe.eFICIMGradeReport.GLASS
                    RadioButtonGGrade.Checked = True
                    RadioButtonDGrade.Checked = False
                Case Else
                    RadioButtonGGrade.Checked = True
                    RadioButtonDGrade.Checked = False
            End Select

            CheckBoxEQ1.Checked = myRecipe.EQRecipe(1).bSelect
            CheckBoxEQ2.Checked = myRecipe.EQRecipe(2).bSelect

            If PPID.Length = 3 AndAlso PPID.Chars(PPID.Length - 1) = _L8B.Setting.Main.FIReportGGradeRecipeEndChar Then
                RadioButtonDGrade.Checked = False
                RadioButtonGGrade.Checked = True
                GroupBoxFIReport.Enabled = False
            Else
                GroupBoxFIReport.Enabled = True
            End If

            If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.FI OrElse (_L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.ButterFly AndAlso _L8B.Setting.Main.MacroEQID > 0) Then
                GroupBoxFIReport.Visible = True
            Else
                GroupBoxFIReport.Visible = False
            End If

        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridViewRecipe_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRecipe.SelectionChanged
        If DataGridViewRecipe.SelectedRows.Count = 1 Then
            ComboBoxRecipeID.Text = DataGridViewRecipe.SelectedRows.Item(0).Cells(0).Value
        End If
    End Sub

    Private Sub ButtonRecipeDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecipeDelete.Click
        If MyTrim(ComboBoxRecipeID.Text).Length = 0 Then
            Exit Sub
        End If
        _L8B.Log.Hide()
        If MsgBox(String.Format("Delete RecipeID = {0}?", ComboBoxRecipeID.Text), MsgBoxStyle.YesNo, "L7B Recipe management") = MsgBoxResult.Yes Then
            If _L8B.db.DeleteRecipe(ComboBoxRecipeID.Text) Then
                UpdateRecipeList()
            End If
        End If
    End Sub

    Private Sub ComboBoxRobotSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxRobotSpeed.SelectedIndexChanged
        Debug.WriteLine("ComboBoxRobotSpeed SelectIndex=" & ComboBoxRobotSpeed.SelectedIndex)
    End Sub

    Private Sub RadioButtonGGrade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonGGrade.CheckedChanged
        RadioButtonDGrade.Checked = Not RadioButtonGGrade.Checked
    End Sub

    Private Sub RadioButtonDGrade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonDGrade.CheckedChanged
        RadioButtonGGrade.Checked = Not RadioButtonDGrade.Checked
    End Sub

    Private Sub ComboBoxRepair_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRepair.SelectedIndexChanged
        If ComboBoxRepair.Text = "TAPE" Then
            Try
                ComboBoxRecipeEQ1.Enabled = True
                LabelTapeRepair.Enabled = True
                Dim myRecipe As cRecipe = _L8B.db.LoadRecipe(ComboBoxRecipeID.Text)
                If myRecipe Is Nothing Then
                    ComboBoxRecipeEQ1.SelectedIndex = -1
                Else
                    ComboBoxRecipeEQ1.Text = myRecipe.EQPPID(1)
                End If
            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try

        ElseIf ComboBoxRepair.Text = "INK" Then
            ComboBoxRecipeEQ1.Enabled = False
            LabelTapeRepair.Enabled = False
            ComboBoxRecipeEQ1.SelectedIndex = -1
        End If
    End Sub
End Class
