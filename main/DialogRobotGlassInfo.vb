Imports System.Windows.Forms
Imports System.Data
Public Class DialogRobotGlassInfo
    Dim Chip As New Dictionary(Of Integer, CheckBox)

    Public Sub ShowMe()
        Me.Visible = False
        Me.Show()
        Me.TopMost = True

        Dim dt As DataTable = _L8B.db.QueryRecipeList
        ComboBoxRecipeID.DisplayMember = "ID"
        ComboBoxRecipeID.DataSource = dt

        If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.DIFFERENT Then
            LabelTargetEQ.Visible = True
            ComboBoxTarget.Visible = True
        Else
            LabelTargetEQ.Visible = False
            ComboBoxTarget.Visible = False
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Chip.Add(1, CheckBox1)
        Chip.Add(2, CheckBox2)
        Chip.Add(3, CheckBox3)
        Chip.Add(4, CheckBox4)
        Chip.Add(5, CheckBox5)
        Chip.Add(6, CheckBox6)
        Chip.Add(7, CheckBox7)
        Chip.Add(8, CheckBox8)
        Chip.Add(9, CheckBox9)
        Chip.Add(10, CheckBox10)
        Chip.Add(11, CheckBox11)
        Chip.Add(12, CheckBox12)
        Chip.Add(13, CheckBox13)
        Chip.Add(14, CheckBox14)
        Chip.Add(15, CheckBox15)
        Chip.Add(16, CheckBox16)
        Chip.Add(17, CheckBox17)
        Chip.Add(18, CheckBox18)
        Chip.Add(19, CheckBox19)
        Chip.Add(20, CheckBox20)
        Chip.Add(21, CheckBox21)
        Chip.Add(22, CheckBox22)
        Chip.Add(23, CheckBox23)
        Chip.Add(24, CheckBox24)
        Chip.Add(25, CheckBox25)
        Chip.Add(26, CheckBox26)
        Chip.Add(27, CheckBox27)
        Chip.Add(28, CheckBox28)
        Chip.Add(29, CheckBox29)
        Chip.Add(30, CheckBox30)
        Chip.Add(31, CheckBox31)
        Chip.Add(32, CheckBox32)
        Chip.Add(33, CheckBox33)
        Chip.Add(34, CheckBox34)
        Chip.Add(35, CheckBox35)
        Chip.Add(36, CheckBox36)
        Chip.Add(37, CheckBox37)
        Chip.Add(38, CheckBox38)
        Chip.Add(39, CheckBox39)
        Chip.Add(40, CheckBox40)
        Chip.Add(41, CheckBox41)
        Chip.Add(42, CheckBox42)
        Chip.Add(43, CheckBox43)
        Chip.Add(44, CheckBox44)
        Chip.Add(45, CheckBox45)
        Chip.Add(46, CheckBox46)
        Chip.Add(47, CheckBox47)
        Chip.Add(48, CheckBox48)
        Chip.Add(49, CheckBox49)
        Chip.Add(50, CheckBox50)
        Chip.Add(51, CheckBox51)
        Chip.Add(52, CheckBox52)
        Chip.Add(53, CheckBox53)
        Chip.Add(54, CheckBox54)
        Chip.Add(55, CheckBox55)
        Chip.Add(56, CheckBox56)
        Chip.Add(57, CheckBox57)
        Chip.Add(58, CheckBox58)
        Chip.Add(59, CheckBox59)
        Chip.Add(60, CheckBox60)
        Chip.Add(61, CheckBox61)
        Chip.Add(62, CheckBox62)
        Chip.Add(63, CheckBox63)
        Chip.Add(64, CheckBox64)
        Chip.Add(65, CheckBox65)
        Chip.Add(66, CheckBox66)
        Chip.Add(67, CheckBox67)
        Chip.Add(68, CheckBox68)
        Chip.Add(69, CheckBox69)
        Chip.Add(70, CheckBox70)
        Chip.Add(71, CheckBox71)
        Chip.Add(72, CheckBox72)

        ComboBoxGlassGrade.DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eGlassGrade), 0)
        ComboBoxDMQCGrade.DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eDMQCGrade), 0)
        'ComboBoxTarget.DataSource = EnumNamesList(GetType(L8BIFPRJ.clsPLC.eGlassTargetPosition), 0)
    End Sub

    Private Sub NumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown.ValueChanged

    End Sub

    Private Function GetChipGrade() As String
        Dim tmpStr As String = ""
        For i As Integer = 1 To NumericUpDown.Value
            If Chip(i).CheckState = CheckState.Checked Then
                tmpStr &= "O"
            ElseIf Chip(i).CheckState = CheckState.Unchecked Then
                tmpStr &= "X"
            Else
                tmpStr &= "G"
            End If
            'tmpStr &= IIf(ChipGradeDict(i).Checked, "O", "X")
        Next
        Return tmpStr
    End Function

    Private Sub ComboBoxRecipeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRecipeID.SelectedIndexChanged
        UpdateEQPPID()
    End Sub

    Private Sub UpdateEQPPID()
        If _L8B.db Is Nothing Then
            Exit Sub
        End If

        Dim PPID As String = MyTrim(ComboBoxRecipeID.Text)

        If ComboBoxRecipeID.SelectedIndex = -1 Or ComboBoxRecipeID.Text = "" Then
            Exit Sub
        End If

        Dim myRecipe As cRecipe = _L8B.db.LoadRecipe(PPID)

        If myRecipe Is Nothing Then Exit Sub

        If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.DIFFERENT Then
            Select Case ComboBoxTarget.Text
                Case "EQ1"
                    TextBoxEQPPID1.Text = myRecipe.EQPPID(1)
                    TextBoxEQPPID2.Text = ""
                Case "EQ2"
                    TextBoxEQPPID1.Text = ""
                    TextBoxEQPPID2.Text = myRecipe.EQPPID(2)
                Case Else
                    TextBoxEQPPID1.Text = myRecipe.EQPPID(1)
                    TextBoxEQPPID2.Text = myRecipe.EQPPID(2)
            End Select
        Else
            TextBoxEQPPID1.Text = myRecipe.EQPPID
            TextBoxEQPPID2.Text = ""
        End If


    End Sub


    Private Sub ButtonRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRead.Click
        Dim nArm As L8BIFPRJ.clsPLC.eRSTArm
        If RadioButtonUpperArm.Checked Then
            nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER
        ElseIf RadioButtonLowerArm.Checked Then
            nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER
        End If
        Dim GlassInfo As L8BIFPRJ.clsArmGlassInfo = _L8B.PLC.GetArmGlassInfo(nArm)

        With GlassInfo
            TextBoxCassetteID.Text = MyTrim(.CSTID)
            ComboBoxRecipeID.Text = MyTrim(.CurrentRecipe)
            TextBoxEQPPID1.Text = MyTrim(.EPPID(1))
            TextBoxEQPPID2.Text = MyTrim(.EPPID(2))
            ComboBoxDMQCGrade.SelectedIndex = DGradeConvertPLCToCIM(.DMQCGrade)
            ComboBoxGlassGrade.SelectedIndex = GGradeConvertPLCToCIM(.GlassGrade)
            TextBoxGlassID.Text = MyTrim(.GlassID)
            ComboBoxScrap.SelectedIndex = .GlassScrapFlag
            TextBoxMeasurementID.Text = MyTrim(.MESID)
            TextBoxOperationID.Text = MyTrim(.OperationID)
            TextBoxLineID.Text = MyTrim(.PLINEID)
            'TextBoxOperationID.Text = MyTrim(.POPERID)
            ComboBoxProductCategory.SelectedIndex = ProductCategoryConvertPLCToCIM(.ProductCategory)
            TextBoxProductCode.Text = MyTrim(.ProductCode)
            TextBoxProcessToolID.Text = MyTrim(.PTOOLID)
            CheckBoxProcFlag.Checked = IIf(.SampleGlassFlag = 1, True, False)
            TextBoxSlotNo.Text = Val(.SlotInfo)
            TextBoxOperatorID.Text = MyTrim(.POPERID)
            ComboBoxScrap.SelectedIndex = .GlassScrapFlag
            CheckBoxFIRemark.Checked = IIf(.FIinspectionFlag = 1, True, False)
            CheckBoxProcFlag.Checked = IIf(.ProcessFlag = 1, True, False)
            CheckBoxRepairInkFlag.Checked = IIf(.RepairInkFlag = 1, True, False)

            TextBoxPortNo.Text = Val(.PortNo)
            If .RobotSpeed = L8BIFPRJ.clsPLC.eRobotSpeed.NA Then
                ComboBoxRobotSpeed.SelectedIndex = L8BIFPRJ.clsPLC.eRobotSpeed.LOW
            Else
                ComboBoxRobotSpeed.SelectedIndex = .RobotSpeed
            End If


            Select Case .TargetPosition
                Case L8BIFPRJ.clsPLC.eGlassTargetPosition.EQ1
                    ComboBoxTarget.SelectedIndex = 0
                Case L8BIFPRJ.clsPLC.eGlassTargetPosition.EQ2
                    ComboBoxTarget.SelectedIndex = 1
                Case L8BIFPRJ.clsPLC.eGlassTargetPosition.EQ1EQ2
                    ComboBoxTarget.SelectedIndex = 2
            End Select
        End With
    End Sub

    Private Sub ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click
        Dim nArm As L8BIFPRJ.clsPLC.eRSTArm
        If RadioButtonUpperArm.Checked Then
            nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER
        ElseIf RadioButtonLowerArm.Checked Then
            nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER
        End If
        Dim GlassInfo As New L8BIFPRJ.clsArmGlassInfo

        With GlassInfo
            .AOIFunctionMode = L8BIFPRJ.clsPLC.eAOIFunction.NONE
            .CSTID = TextBoxCassetteID.Text
            .CurrentRecipe = ComboBoxRecipeID.Text
            .EPPID(1) = TextBoxEQPPID1.Text
            .EPPID(2) = TextBoxEQPPID2.Text
            .DMQCGrade = DGradeConvertCIMToPLC(ComboBoxDMQCGrade.SelectedIndex)
            .GlassGrade = GGradeConvertCIMToPLC(ComboBoxGlassGrade.SelectedIndex)
            .GlassID = TextBoxGlassID.Text
            .MESID = TextBoxMeasurementID.Text
            .OperationID = TextBoxOperationID.Text
            .PLINEID = TextBoxLineID.Text
            '.POPERID = TextBoxOperationID.Text
            .ProductCategory = ProductCategoryConvertCIMToPLC(ComboBoxProductCategory.SelectedIndex)
            .ProductCode = TextBoxProductCode.Text
            .PTOOLID = TextBoxProcessToolID.Text
            .SampleGlassFlag = IIf(CheckBoxProcFlag.Checked, 1, 0)
            .SlotInfo = Val(TextBoxSlotNo.Text)
            .GlassScrapFlag = ComboBoxScrap.SelectedIndex
            .POPERID = TextBoxOperatorID.Text
            .TargetPosition = ComboBoxTarget.SelectedIndex + 1
            .RobotSpeed = ComboBoxRobotSpeed.SelectedIndex
            .PortNo = Val(TextBoxPortNo.Text)
            .RepairInkFlag = IIf(CheckBoxRepairInkFlag.Checked, 1, 0)
        End With
        _L8B.PLC.WriteArmGlassInfo(nArm) = GlassInfo

        If RadioButtonUpperArm.Checked Then
            _L8B.PLC.GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER)
        ElseIf RadioButtonLowerArm.Checked Then
            _L8B.PLC.GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER)
        End If
    End Sub

    Private Sub ButtonErease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonErease.Click
        Dim nArm As L8BIFPRJ.clsPLC.eRSTArm
        If RadioButtonUpperArm.Checked Then
            nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER
        ElseIf RadioButtonLowerArm.Checked Then
            nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER
        End If
        If MsgBox(String.Format("Erease Buffer Glass in Robot({0})(刪除手臂基板資料); GlassID=[{1}]", nArm.ToString, MyTrim(TextBoxGlassID.Text)), MsgBoxStyle.YesNo, "Delete Buffer Glass(刪除手臂基板資料)") = MsgBoxResult.Yes Then
            WriteLog(String.Format("User Click [OK] for Erease Robot Glass in ({0}); GlassID=[{1}]", nArm.ToString, MyTrim(TextBoxGlassID.Text)), LogMessageType.SYS)

            If MyTrim(mInfo.Robot.Glass(nArm + 1).GlassID).Length > 0 Then
                GlassDelete(eRobotPosition.ROBOT, nArm + 1, mInfo.Robot.Glass(nArm + 1).GlassID)
            End If

            Dim GlassInfo As New L8BIFPRJ.clsArmGlassInfo

            With GlassInfo
                .AOIFunctionMode = L8BIFPRJ.clsPLC.eAOIFunction.NONE
                .CSTID = ""
                .CurrentRecipe = ""
                .DMQCGrade = ComboBoxDMQCGrade.SelectedIndex
                .EPPID(1) = ""
                .EPPID(1) = ""
                .GlassGrade = ComboBoxGlassGrade.SelectedIndex
                .GlassID = ""
                .MESID = ""
                .OperationID = ""
                .PLINEID = ""
                .POPERID = ""
                .ProductCategory = ComboBoxProductCategory.SelectedIndex
                .ProductCode = ""
                .PTOOLID = ""
                .SampleGlassFlag = IIf(CheckBoxProcFlag.Checked, 1, 0)
                .SlotInfo = Val(TextBoxSlotNo.Text)
                .GlassScrapFlag = L8BIFPRJ.clsPLC.eSCRPFLAG.MARKED_SCRAP
                .POPERID = ""
                .TargetPosition = L8BIFPRJ.clsPLC.eGlassTargetPosition.EQ1
                .RobotSpeed = ComboBoxRobotSpeed.SelectedIndex
            End With
            TextBoxCassetteID.Text = ""
            TextBoxEQPPID1.Text = ""
            ComboBoxDMQCGrade.SelectedIndex = 0
            ComboBoxRecipeID.Text = ""
            ComboBoxGlassGrade.SelectedIndex = 0
            TextBoxGlassID.Text = ""
            ComboBoxScrap.SelectedIndex = 0
            TextBoxMeasurementID.Text = ""
            TextBoxOperationID.Text = ""
            TextBoxLineID.Text = ""
            TextBoxOperationID.Text = ""
            ComboBoxProductCategory.SelectedIndex = 0
            TextBoxProductCode.Text = ""
            TextBoxProcessToolID.Text = ""
            CheckBoxProcFlag.Checked = False
            TextBoxSlotNo.Text = 0
            TextBoxOperatorID.Text = ""
            ComboBoxScrap.SelectedIndex = 0
            ComboBoxTarget.SelectedIndex = 0
            ComboBoxRecipeID.Text = ""

            _L8B.PLC.L8BPLC.RSTArmGlassErase(nArm)
            _L8B.PLC.WriteArmGlassInfo(nArm) = GlassInfo

            If RadioButtonUpperArm.Checked Then
                _L8B.PLC.GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER)
            ElseIf RadioButtonLowerArm.Checked Then
                _L8B.PLC.GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER)
            End If

        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

End Class
