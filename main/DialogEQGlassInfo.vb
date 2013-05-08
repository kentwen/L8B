Imports System.Windows.Forms

Public Class DialogEQGlassInfo
    Dim ChipGradeDict As New Dictionary(Of Integer, CheckBox)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Dim GlxInfo As New cGlassInfo
        'With GlxInfo
        '    .GlassID = TextBoxGlassID.Text
        '    .SrcSlotNo = TextBoxSlotNo.Text
        '    '.GlassIDVCR
        '    .GlassIDCIM = TextBoxGlassID.Text
        '    '.LotID = 

        '    .DMQCToolID = TextBoxDMQCToolID.Text
        '    .DMQCToolIDDownload = TextBoxDMQCToolIDDownload.Text
        '    .DMQCGrade = ComboBoxDMQCGrade.SelectedIndex
        '    .DMQCGradeDownload = ComboBoxDMQCGradeDownLoad.SelectedIndex
        '    .DMQCGradeResult = ComboBoxDMQCGradeResult.SelectedIndex

        '    .LastProcessOperationID = TextBoxLastOperationID.Text
        '    .LastProcessLineID = ""
        '    .ProcessToolID = TextBoxProcessToolID.Text
        '    .PSHGroup = TextBoxPSHGroup.Text
        '    .GlassGrade = ComboBoxGlassGrade.SelectedIndex

        '    .GlassGradeDownload = ComboBoxGlassGradeDownLoad.SelectedIndex
        '    '.GlassGradeResult = comboxgraderesult.SelectedIndex
        '    '.ChipGrade(0 To MAX_CHIPGRADE) 
        '    .Scrap = ComboBoxScrap.SelectedIndex
        '    .FIRemark = CheckBoxFIRemark.Checked

        '    .Rework = CheckBoxRework.Checked
        '    .FIFCFlag = CheckBoxFIRemark.Checked
        '    .ProcFlag = CheckBoxProcFlag.Checked
        '    With .Lot
        '        .CassetteID = TextBoxCassetteID.Text
        '        .CIMMessage = "User Keyin"
        '        .OperationID = TextBoxOperationID.Text
        '        .PortPosition = 0
        '        .ProductCode = ""
        '        .RecipeName = TextBoxRecipeName.Text
        '        .ReturnCode = ""
        '    End With
        'End With
        '_L8b.DB.InsertGlass(GlxInfo)
        'Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ChipGradeDict.Add(1, CheckBox1)
        ChipGradeDict.Add(2, CheckBox2)
        ChipGradeDict.Add(3, CheckBox3)
        ChipGradeDict.Add(4, CheckBox4)
        ChipGradeDict.Add(5, CheckBox5)
        ChipGradeDict.Add(6, CheckBox6)
        ChipGradeDict.Add(7, CheckBox7)
        ChipGradeDict.Add(8, CheckBox8)
        ChipGradeDict.Add(9, CheckBox9)
        ChipGradeDict.Add(10, CheckBox10)
        ChipGradeDict.Add(11, CheckBox11)
        ChipGradeDict.Add(12, CheckBox12)
        ChipGradeDict.Add(13, CheckBox13)
        ChipGradeDict.Add(14, CheckBox14)
        ChipGradeDict.Add(15, CheckBox15)
        ChipGradeDict.Add(16, CheckBox16)
        ChipGradeDict.Add(17, CheckBox17)
        ChipGradeDict.Add(18, CheckBox18)
        ChipGradeDict.Add(19, CheckBox19)
        ChipGradeDict.Add(20, CheckBox20)
        ChipGradeDict.Add(21, CheckBox21)
        ChipGradeDict.Add(22, CheckBox22)
        ChipGradeDict.Add(23, CheckBox23)
        ChipGradeDict.Add(24, CheckBox24)
        ChipGradeDict.Add(25, CheckBox25)
        ChipGradeDict.Add(26, CheckBox26)
        ChipGradeDict.Add(27, CheckBox27)
        ChipGradeDict.Add(28, CheckBox28)
        ChipGradeDict.Add(29, CheckBox29)
        ChipGradeDict.Add(30, CheckBox30)
        ChipGradeDict.Add(31, CheckBox31)
        ChipGradeDict.Add(32, CheckBox32)
        ChipGradeDict.Add(33, CheckBox33)
        ChipGradeDict.Add(34, CheckBox34)
        ChipGradeDict.Add(35, CheckBox35)
        ChipGradeDict.Add(36, CheckBox36)
        ChipGradeDict.Add(37, CheckBox37)
        ChipGradeDict.Add(38, CheckBox38)
        ChipGradeDict.Add(39, CheckBox39)
        ChipGradeDict.Add(40, CheckBox40)
        ChipGradeDict.Add(41, CheckBox41)
        ChipGradeDict.Add(42, CheckBox42)
        ChipGradeDict.Add(43, CheckBox43)
        ChipGradeDict.Add(44, CheckBox44)
        ChipGradeDict.Add(45, CheckBox45)
        ChipGradeDict.Add(46, CheckBox46)
        ChipGradeDict.Add(47, CheckBox47)
        ChipGradeDict.Add(48, CheckBox48)
        ChipGradeDict.Add(49, CheckBox49)
        ChipGradeDict.Add(50, CheckBox50)
        ChipGradeDict.Add(51, CheckBox51)
        ChipGradeDict.Add(52, CheckBox52)
        ChipGradeDict.Add(53, CheckBox53)
        ChipGradeDict.Add(54, CheckBox54)
        ChipGradeDict.Add(55, CheckBox55)
        ChipGradeDict.Add(56, CheckBox56)
        ChipGradeDict.Add(57, CheckBox57)
        ChipGradeDict.Add(58, CheckBox58)
        ChipGradeDict.Add(59, CheckBox59)
        ChipGradeDict.Add(60, CheckBox60)
        ChipGradeDict.Add(61, CheckBox61)
        ChipGradeDict.Add(62, CheckBox62)
        ChipGradeDict.Add(63, CheckBox63)
        ChipGradeDict.Add(64, CheckBox64)
        ChipGradeDict.Add(65, CheckBox65)
        ChipGradeDict.Add(66, CheckBox66)
        ChipGradeDict.Add(67, CheckBox67)
        ChipGradeDict.Add(68, CheckBox68)
        ChipGradeDict.Add(69, CheckBox69)
        ChipGradeDict.Add(70, CheckBox70)
        ChipGradeDict.Add(71, CheckBox71)
        ChipGradeDict.Add(72, CheckBox72)
    End Sub

End Class
