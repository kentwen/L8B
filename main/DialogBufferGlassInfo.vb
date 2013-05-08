Imports System.Windows.Forms
Imports System.Data


Public Class DialogBufferGlassInfo

    Dim Chip As New Dictionary(Of Integer, CheckBox)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.TopMost = False
        Me.Hide()
    End Sub

    Private Sub ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click
        Dim GlassInfo As New L8BIFPRJ.clsBufferGlassInfo

        WriteLog("ButtonUpdate ->" & TextBoxGlassID.Text)
        With GlassInfo
            .AOIFunctionMode = L8BIFPRJ.clsPLC.eAOIFunction.NONE
            .CSTID = TextBoxCassetteID.Text
            .CurrentRecipe = ComboBoxRecipeID.Text
            .DMQCGrade = DGradeConvertCIMToPLC(ComboBoxDMQCGrade.SelectedIndex)
            .EPPID(1) = TextBoxEQPPID1.Text
            .EPPID(2) = TextBoxEQPPID2.Text
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
            .RepairReviewFlag = IIf(CheckBoxRepairReview.Checked, 1, 0)
            .RepairInkFlag = IIf(CheckBoxRepairInkFlag.Checked, 1, 0)
        End With
        _L8B.PLC.WriteBufferGlassInfo(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text)) = GlassInfo

        _L8B.PLC.GetBufferGlass(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text))
        _L8B.frmMain.UpdateBufferGUI(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text))

    End Sub

    Dim fEditable As Boolean
    Public Sub ShowMe(Optional ByVal fEdit As Boolean = True)
        fEditable = fEdit
        ButtonUpdate.Enabled = fEditable
        ButtonErease.Enabled = fEditable
        UpdateComboBox()
        Me.Visible = False
        Me.Show()
        Me.TopMost = True

        If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.DIFFERENT Then
            LabelTargetEQ.Visible = True
            ComboBoxTarget.Visible = True
        Else
            LabelTargetEQ.Visible = False
            ComboBoxTarget.Visible = False
        End If

    End Sub


    Private Sub UpdateComboBox()
        Dim BufferList As New ArrayList
        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
            BufferList.Add(i)
        Next
        ComboBoxBuffer.DataSource = Nothing
        ComboBoxBuffer.DataSource = BufferList

        Dim dt As DataTable = _L8B.db.QueryRecipeList
        ComboBoxRecipeID.DisplayMember = "ID"
        ComboBoxRecipeID.DataSource = dt
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
        ComboBoxTarget.DataSource = EnumNamesList(GetType(L8BIFPRJ.clsPLC.eGlassTargetPosition), 0)
    End Sub

    Private Sub NumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown.ValueChanged
        If Chip.Count = 0 Then
            Exit Sub
        End If
        If NumericUpDown.Value < 72 Then
            For i As Integer = 1 To NumericUpDown.Value
                If Chip(i).CheckState = CheckState.Indeterminate Then
                    Chip(i).CheckState = CheckState.Unchecked
                End If
                Chip(i).Enabled = True
            Next
            For i As Integer = NumericUpDown.Value + 1 To 72
                Chip(i).CheckState = CheckState.Indeterminate
                Chip(i).Enabled = False
            Next
        Else
            For i As Integer = 1 To 72
                If Chip(i).CheckState = CheckState.Indeterminate Then
                    Chip(i).CheckState = CheckState.Unchecked
                End If
                Chip(i).Enabled = True
            Next
        End If
    End Sub

    Private Sub ButtonRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRead.Click
        Read()
    End Sub

    Private Sub Read()
        Dim GlassInfo As L8BIFPRJ.clsBufferGlassInfo = _L8B.PLC.GetBufferGlassInfo(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text))

        With GlassInfo
            '.AOIFunctionMode = L8BIFPRJ.clsPLC.eAOIFunction.NONE
            TextBoxCassetteID.Text = MyTrim(.CSTID)
            LabelPPID.Text = MyTrim(.CurrentRecipe) 'Lot PPID
            Try
                ComboBoxRecipeID.Text = MyTrim(.CurrentRecipe) 'Lot PPID
            Catch ex As Exception
                ComboBoxRecipeID.Text = ""
            End Try
            TextBoxEQPPID1.Text = MyTrim(.EPPID(1))  'EQ recipe name
            TextBoxEQPPID2.Text = MyTrim(.EPPID(2))  'EQ recipe name
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
            TextBoxPortNo.Text = Val(.PortNo)
            CheckBoxRepairReview.Checked = IIf(.RepairReviewFlag = 1, True, False)
            CheckBoxRepairInkFlag.Checked = IIf(.RepairInkFlag = 1, True, False)

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
                Case Else
                    ComboBoxTarget.SelectedIndex = 0
            End Select
        End With
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

    Private Sub ButtonErease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonErease.Click
        If MsgBox(String.Format("Erease Buffer Glass in Buffer ({0}, {1})(刪除Buffer基板資料); GlassID=[{2}]", eRobotPosition.Buffer1 + Val(ComboBoxBuffer.Text) - 1, Val(ComboBoxSlot.Text), MyTrim(TextBoxGlassID.Text)), MsgBoxStyle.YesNo, "Delete Buffer Glass(刪除Buffer基板資料)") = MsgBoxResult.Yes Then
            WriteLog(String.Format("User Click [OK] for Erease Buffer Glass in Buffer ({0}, {1}); GlassID=[{2}]", eRobotPosition.Buffer1 + Val(ComboBoxBuffer.Text) - 1, Val(ComboBoxSlot.Text), MyTrim(TextBoxGlassID.Text)), LogMessageType.SYS)
            Dim GlassInfo As New L8BIFPRJ.clsBufferGlassInfo
            GlassDelete(eRobotPosition.Buffer1 + Val(ComboBoxBuffer.Text) - 1, Val(ComboBoxSlot.Text), MyTrim(TextBoxGlassID.Text))

            With GlassInfo
                .AOIFunctionMode = L8BIFPRJ.clsPLC.eAOIFunction.NONE
                .CSTID = ""
                .CurrentRecipe = ""
                .DMQCGrade = L8BIFPRJ.clsPLC.eDGRADE.NO_GLASS
                .EPPID(1) = ""
                .EPPID(2) = ""
                .GlassGrade = L8BIFPRJ.clsPLC.eGGRADE.NO_GLASS
                .GlassID = ""
                .MESID = ""
                .OperationID = ""
                .PLINEID = ""
                .POPERID = ""
                .ProductCategory = L8BIFPRJ.clsPLC.eProductCategory.PROD
                .ProductCode = ""
                .PTOOLID = ""
                .SampleGlassFlag = IIf(CheckBoxProcFlag.Checked, 1, 0)
                .SlotInfo = ComboBoxSlot.Text
                .GlassScrapFlag = L8BIFPRJ.clsPLC.eSCRPFLAG.MARKED_SCRAP
                .POPERID = ""
                .TargetPosition = L8BIFPRJ.clsPLC.eGlassTargetPosition.EQ1
                .RobotSpeed = ComboBoxRobotSpeed.SelectedIndex
            End With
            _L8B.PLC.WriteBufferGlassInfo(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text)) = GlassInfo
            _L8B.PLC.BufferGlassErease(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text))

            TextBoxCassetteID.Text = ""
            ComboBoxRecipeID.Text = ""
            ComboBoxDMQCGrade.SelectedIndex = 0
            TextBoxEQPPID1.Text = ""
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
            TextBoxSlotNo.Text = 1
            TextBoxOperatorID.Text = ""
            ComboBoxRobotSpeed.SelectedIndex = 0

            _L8B.PLC.GetBufferGlass(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text))
            _L8B.frmMain.UpdateBufferGUI(Val(ComboBoxBuffer.Text), Val(ComboBoxSlot.Text))
        End If
    End Sub

    Private Sub ComboBoxBuffer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxBuffer.SelectedIndexChanged
        Dim BufferSlotList As New ArrayList
        For i As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(Val(ComboBoxBuffer.Text))
            BufferSlotList.Add(i)
        Next
        ComboBoxSlot.DataSource = Nothing
        ComboBoxSlot.DataSource = BufferSlotList
        EnableButton()
        If Not fEditable AndAlso Val(ComboBoxBuffer.Text) > 0 AndAlso Val(ComboBoxSlot.Text) > 0 Then
            Read()
        End If
    End Sub

    Private Sub ComboBoxSlot_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxSlot.SelectedIndexChanged
        EnableButton()
        If Not fEditable AndAlso Val(ComboBoxBuffer.Text) > 0 AndAlso Val(ComboBoxSlot.Text) > 0 Then
            Read()
        End If
    End Sub

    Private Sub EnableButton()
        If ComboBoxSlot.Text <> "" And ComboBoxBuffer.Text <> "" Then
            ButtonRead.Enabled = True
            ButtonUpdate.Enabled = fEditable
            ButtonErease.Enabled = fEditable
        Else
            ButtonRead.Enabled = False
            ButtonUpdate.Enabled = False
            ButtonErease.Enabled = False
        End If
    End Sub

    Private Sub RstguiCtrlSlots1_SlotMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles RstguiCtrlSlots1.SlotMouseUP
        ComboBoxBuffer.Text = 1
        ComboBoxSlot.Text = nSlot
    End Sub

    Private Sub RstguiCtrlSlots2_SlotMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles RstguiCtrlSlots2.SlotMouseUP
        ComboBoxBuffer.Text = 2
        ComboBoxSlot.Text = nSlot
    End Sub

    Private Sub RstguiCtrlSlots3_SlotMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single) Handles RstguiCtrlSlots3.SlotMouseUP
        ComboBoxBuffer.Text = 3
        ComboBoxSlot.Text = nSlot
    End Sub

    Private Sub ComboBoxTarget_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTarget.SelectedIndexChanged
        UpdateEQPPID()
    End Sub

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

End Class
