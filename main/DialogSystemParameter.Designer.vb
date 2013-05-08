<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSystemParameter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.NumericUpDownLogFileKeepDays = New System.Windows.Forms.NumericUpDown
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.ButtonAlarmFilePLC = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBoxAlarmFilePLC = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ButtonAlarmFileEQ3 = New System.Windows.Forms.Button
        Me.ButtonAlarmFileEQ2 = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBoxEQ3ToolID = New System.Windows.Forms.TextBox
        Me.TextBoxEQ2ToolID = New System.Windows.Forms.TextBox
        Me.TextBoxEQ1ToolID = New System.Windows.Forms.TextBox
        Me.TextBoxToolID = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxCVToolID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxRSTToolID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxLineID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckBoxEQ3 = New System.Windows.Forms.CheckBox
        Me.CheckBoxEQ2 = New System.Windows.Forms.CheckBox
        Me.CheckBoxEQ1 = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ButtonAlarmFileCV = New System.Windows.Forms.Button
        Me.ButtonAlarmFileEQ1 = New System.Windows.Forms.Button
        Me.TextBoxAlarmFileCV = New System.Windows.Forms.TextBox
        Me.TextBoxAlarmFileEQ3 = New System.Windows.Forms.TextBox
        Me.TextBoxAlarmFileEQ2 = New System.Windows.Forms.TextBox
        Me.TextBoxAlarmFileEQ1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.ButtonLoad = New System.Windows.Forms.Button
        Me.ComboBoxGlassTMode = New System.Windows.Forms.ComboBox
        Me.RstguiCtrlSlots3 = New RSTShapFlowGUI.RSTGUICtrlSlots
        Me.RstguiCtrlSlots2 = New RSTShapFlowGUI.RSTGUICtrlSlots
        Me.RstguiCtrlSlots1 = New RSTShapFlowGUI.RSTGUICtrlSlots
        Me.ButtonMachineSetting = New System.Windows.Forms.Button
        Me.LDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CASSETTE1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CASSETTE2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EQ1SampleGlassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EQ2SampleGlassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStripBufferSlotType = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BufferSlotToolStripMenuItem = New System.Windows.Forms.ToolStripTextBox
        Me.InkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CASSETTE3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ButtonCassetteInfoColumnSelect = New System.Windows.Forms.Button
        CType(Me.NumericUpDownLogFileKeepDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.ContextMenuStripBufferSlotType.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumericUpDownLogFileKeepDays
        '
        Me.NumericUpDownLogFileKeepDays.Location = New System.Drawing.Point(343, 196)
        Me.NumericUpDownLogFileKeepDays.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.NumericUpDownLogFileKeepDays.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDownLogFileKeepDays.Name = "NumericUpDownLogFileKeepDays"
        Me.NumericUpDownLogFileKeepDays.Size = New System.Drawing.Size(38, 22)
        Me.NumericUpDownLogFileKeepDays.TabIndex = 5
        Me.NumericUpDownLogFileKeepDays.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(16, 39)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&Apply"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Close"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(308, 487)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(76, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 21)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Close"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Location = New System.Drawing.Point(368, 408)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 21)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Apply"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(327, 360)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(38, 22)
        Me.NumericUpDown1.TabIndex = 5
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'ButtonAlarmFilePLC
        '
        Me.ButtonAlarmFilePLC.Location = New System.Drawing.Point(399, 134)
        Me.ButtonAlarmFilePLC.Name = "ButtonAlarmFilePLC"
        Me.ButtonAlarmFilePLC.Size = New System.Drawing.Size(22, 23)
        Me.ButtonAlarmFilePLC.TabIndex = 17
        Me.ButtonAlarmFilePLC.Text = "..."
        Me.ButtonAlarmFilePLC.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(229, 364)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 12)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "LogFile Keep days"
        '
        'TextBoxAlarmFilePLC
        '
        Me.TextBoxAlarmFilePLC.Location = New System.Drawing.Point(113, 134)
        Me.TextBoxAlarmFilePLC.Name = "TextBoxAlarmFilePLC"
        Me.TextBoxAlarmFilePLC.Size = New System.Drawing.Size(286, 22)
        Me.TextBoxAlarmFilePLC.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 140)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "PLC Alarm List File"
        '
        'ButtonAlarmFileEQ3
        '
        Me.ButtonAlarmFileEQ3.Location = New System.Drawing.Point(399, 78)
        Me.ButtonAlarmFileEQ3.Name = "ButtonAlarmFileEQ3"
        Me.ButtonAlarmFileEQ3.Size = New System.Drawing.Size(22, 23)
        Me.ButtonAlarmFileEQ3.TabIndex = 12
        Me.ButtonAlarmFileEQ3.Text = "..."
        Me.ButtonAlarmFileEQ3.UseVisualStyleBackColor = True
        '
        'ButtonAlarmFileEQ2
        '
        Me.ButtonAlarmFileEQ2.Location = New System.Drawing.Point(399, 51)
        Me.ButtonAlarmFileEQ2.Name = "ButtonAlarmFileEQ2"
        Me.ButtonAlarmFileEQ2.Size = New System.Drawing.Size(22, 23)
        Me.ButtonAlarmFileEQ2.TabIndex = 11
        Me.ButtonAlarmFileEQ2.Text = "..."
        Me.ButtonAlarmFileEQ2.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(375, 364)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(28, 12)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Days"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.NumericUpDown1)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(446, 435)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "System"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxEQ3ToolID)
        Me.GroupBox1.Controls.Add(Me.TextBoxEQ2ToolID)
        Me.GroupBox1.Controls.Add(Me.TextBoxEQ1ToolID)
        Me.GroupBox1.Controls.Add(Me.TextBoxToolID)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBoxCVToolID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBoxRSTToolID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBoxLineID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 166)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ID Setup"
        '
        'TextBoxEQ3ToolID
        '
        Me.TextBoxEQ3ToolID.Location = New System.Drawing.Point(292, 128)
        Me.TextBoxEQ3ToolID.Name = "TextBoxEQ3ToolID"
        Me.TextBoxEQ3ToolID.Size = New System.Drawing.Size(117, 22)
        Me.TextBoxEQ3ToolID.TabIndex = 15
        '
        'TextBoxEQ2ToolID
        '
        Me.TextBoxEQ2ToolID.Location = New System.Drawing.Point(292, 93)
        Me.TextBoxEQ2ToolID.Name = "TextBoxEQ2ToolID"
        Me.TextBoxEQ2ToolID.Size = New System.Drawing.Size(117, 22)
        Me.TextBoxEQ2ToolID.TabIndex = 14
        '
        'TextBoxEQ1ToolID
        '
        Me.TextBoxEQ1ToolID.Location = New System.Drawing.Point(292, 58)
        Me.TextBoxEQ1ToolID.Name = "TextBoxEQ1ToolID"
        Me.TextBoxEQ1ToolID.Size = New System.Drawing.Size(117, 22)
        Me.TextBoxEQ1ToolID.TabIndex = 13
        '
        'TextBoxToolID
        '
        Me.TextBoxToolID.Location = New System.Drawing.Point(292, 26)
        Me.TextBoxToolID.Name = "TextBoxToolID"
        Me.TextBoxToolID.Size = New System.Drawing.Size(117, 22)
        Me.TextBoxToolID.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(223, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 12)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "EQ3 Tool ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(223, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "EQ2 Tool ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(223, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "EQ1 Tool ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(247, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tool ID"
        '
        'TextBoxCVToolID
        '
        Me.TextBoxCVToolID.Location = New System.Drawing.Point(87, 93)
        Me.TextBoxCVToolID.Name = "TextBoxCVToolID"
        Me.TextBoxCVToolID.Size = New System.Drawing.Size(127, 22)
        Me.TextBoxCVToolID.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "CV Tool ID"
        '
        'TextBoxRSTToolID
        '
        Me.TextBoxRSTToolID.Location = New System.Drawing.Point(87, 58)
        Me.TextBoxRSTToolID.Name = "TextBoxRSTToolID"
        Me.TextBoxRSTToolID.Size = New System.Drawing.Size(127, 22)
        Me.TextBoxRSTToolID.TabIndex = 3
        Me.TextBoxRSTToolID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "RST Tool ID"
        Me.Label2.Visible = False
        '
        'TextBoxLineID
        '
        Me.TextBoxLineID.Location = New System.Drawing.Point(87, 26)
        Me.TextBoxLineID.Name = "TextBoxLineID"
        Me.TextBoxLineID.Size = New System.Drawing.Size(127, 22)
        Me.TextBoxLineID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Line ID"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxEQ3)
        Me.GroupBox2.Controls.Add(Me.CheckBoxEQ2)
        Me.GroupBox2.Controls.Add(Me.CheckBoxEQ1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 353)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(177, 47)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "EQ Recipe Check"
        '
        'CheckBoxEQ3
        '
        Me.CheckBoxEQ3.AutoSize = True
        Me.CheckBoxEQ3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxEQ3.Location = New System.Drawing.Point(118, 20)
        Me.CheckBoxEQ3.Name = "CheckBoxEQ3"
        Me.CheckBoxEQ3.Size = New System.Drawing.Size(42, 16)
        Me.CheckBoxEQ3.TabIndex = 2
        Me.CheckBoxEQ3.Text = "EQ3"
        Me.CheckBoxEQ3.UseVisualStyleBackColor = True
        '
        'CheckBoxEQ2
        '
        Me.CheckBoxEQ2.AutoSize = True
        Me.CheckBoxEQ2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxEQ2.Location = New System.Drawing.Point(70, 20)
        Me.CheckBoxEQ2.Name = "CheckBoxEQ2"
        Me.CheckBoxEQ2.Size = New System.Drawing.Size(42, 16)
        Me.CheckBoxEQ2.TabIndex = 1
        Me.CheckBoxEQ2.Text = "EQ2"
        Me.CheckBoxEQ2.UseVisualStyleBackColor = True
        '
        'CheckBoxEQ1
        '
        Me.CheckBoxEQ1.AutoSize = True
        Me.CheckBoxEQ1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxEQ1.Location = New System.Drawing.Point(19, 20)
        Me.CheckBoxEQ1.Name = "CheckBoxEQ1"
        Me.CheckBoxEQ1.Size = New System.Drawing.Size(42, 16)
        Me.CheckBoxEQ1.TabIndex = 0
        Me.CheckBoxEQ1.Text = "EQ1"
        Me.CheckBoxEQ1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonAlarmFilePLC)
        Me.GroupBox3.Controls.Add(Me.TextBoxAlarmFilePLC)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.ButtonAlarmFileCV)
        Me.GroupBox3.Controls.Add(Me.ButtonAlarmFileEQ3)
        Me.GroupBox3.Controls.Add(Me.ButtonAlarmFileEQ2)
        Me.GroupBox3.Controls.Add(Me.ButtonAlarmFileEQ1)
        Me.GroupBox3.Controls.Add(Me.TextBoxAlarmFileCV)
        Me.GroupBox3.Controls.Add(Me.TextBoxAlarmFileEQ3)
        Me.GroupBox3.Controls.Add(Me.TextBoxAlarmFileEQ2)
        Me.GroupBox3.Controls.Add(Me.TextBoxAlarmFileEQ1)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(426, 169)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Alarm List File(csv)"
        '
        'ButtonAlarmFileCV
        '
        Me.ButtonAlarmFileCV.Location = New System.Drawing.Point(399, 105)
        Me.ButtonAlarmFileCV.Name = "ButtonAlarmFileCV"
        Me.ButtonAlarmFileCV.Size = New System.Drawing.Size(22, 23)
        Me.ButtonAlarmFileCV.TabIndex = 13
        Me.ButtonAlarmFileCV.Text = "..."
        Me.ButtonAlarmFileCV.UseVisualStyleBackColor = True
        '
        'ButtonAlarmFileEQ1
        '
        Me.ButtonAlarmFileEQ1.Location = New System.Drawing.Point(399, 24)
        Me.ButtonAlarmFileEQ1.Name = "ButtonAlarmFileEQ1"
        Me.ButtonAlarmFileEQ1.Size = New System.Drawing.Size(22, 23)
        Me.ButtonAlarmFileEQ1.TabIndex = 10
        Me.ButtonAlarmFileEQ1.Text = "..."
        Me.ButtonAlarmFileEQ1.UseVisualStyleBackColor = True
        '
        'TextBoxAlarmFileCV
        '
        Me.TextBoxAlarmFileCV.Location = New System.Drawing.Point(113, 106)
        Me.TextBoxAlarmFileCV.Name = "TextBoxAlarmFileCV"
        Me.TextBoxAlarmFileCV.Size = New System.Drawing.Size(286, 22)
        Me.TextBoxAlarmFileCV.TabIndex = 8
        '
        'TextBoxAlarmFileEQ3
        '
        Me.TextBoxAlarmFileEQ3.Location = New System.Drawing.Point(113, 79)
        Me.TextBoxAlarmFileEQ3.Name = "TextBoxAlarmFileEQ3"
        Me.TextBoxAlarmFileEQ3.Size = New System.Drawing.Size(286, 22)
        Me.TextBoxAlarmFileEQ3.TabIndex = 7
        '
        'TextBoxAlarmFileEQ2
        '
        Me.TextBoxAlarmFileEQ2.Location = New System.Drawing.Point(113, 52)
        Me.TextBoxAlarmFileEQ2.Name = "TextBoxAlarmFileEQ2"
        Me.TextBoxAlarmFileEQ2.Size = New System.Drawing.Size(286, 22)
        Me.TextBoxAlarmFileEQ2.TabIndex = 6
        '
        'TextBoxAlarmFileEQ1
        '
        Me.TextBoxAlarmFileEQ1.Location = New System.Drawing.Point(113, 25)
        Me.TextBoxAlarmFileEQ1.Name = "TextBoxAlarmFileEQ1"
        Me.TextBoxAlarmFileEQ1.Size = New System.Drawing.Size(286, 22)
        Me.TextBoxAlarmFileEQ1.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 12)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "CV Alarm List File"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 12)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "EQ3 Alarm List File"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 12)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "EQ2 Alarm List File"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "EQ1 Alarm List File"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(454, 461)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ButtonSave)
        Me.TabPage2.Controls.Add(Me.ButtonLoad)
        Me.TabPage2.Controls.Add(Me.ComboBoxGlassTMode)
        Me.TabPage2.Controls.Add(Me.RstguiCtrlSlots3)
        Me.TabPage2.Controls.Add(Me.RstguiCtrlSlots2)
        Me.TabPage2.Controls.Add(Me.RstguiCtrlSlots1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(446, 435)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Buffer Setting"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(228, 6)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(52, 21)
        Me.ButtonSave.TabIndex = 5
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'ButtonLoad
        '
        Me.ButtonLoad.Location = New System.Drawing.Point(170, 6)
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(52, 21)
        Me.ButtonLoad.TabIndex = 4
        Me.ButtonLoad.Text = "Load"
        Me.ButtonLoad.UseVisualStyleBackColor = True
        Me.ButtonLoad.Visible = False
        '
        'ComboBoxGlassTMode
        '
        Me.ComboBoxGlassTMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxGlassTMode.FormattingEnabled = True
        Me.ComboBoxGlassTMode.Location = New System.Drawing.Point(16, 6)
        Me.ComboBoxGlassTMode.Name = "ComboBoxGlassTMode"
        Me.ComboBoxGlassTMode.Size = New System.Drawing.Size(148, 20)
        Me.ComboBoxGlassTMode.TabIndex = 3
        '
        'RstguiCtrlSlots3
        '
        Me.RstguiCtrlSlots3.BufferID = "3"
        Me.RstguiCtrlSlots3.GxExtraDataShow = False
        Me.RstguiCtrlSlots3.GxIDShow = False
        Me.RstguiCtrlSlots3.Location = New System.Drawing.Point(16, 35)
        Me.RstguiCtrlSlots3.MaxSlots = 25
        Me.RstguiCtrlSlots3.Name = "RstguiCtrlSlots3"
        Me.RstguiCtrlSlots3.SetLblFont = Nothing
        Me.RstguiCtrlSlots3.SetSlotTitle = ""
        Me.RstguiCtrlSlots3.ShowBufferID = True
        Me.RstguiCtrlSlots3.Size = New System.Drawing.Size(140, 394)
        Me.RstguiCtrlSlots3.SloIndexStep = 1
        Me.RstguiCtrlSlots3.SlotIndexBackColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots3.SlotIndexWidth = 17
        Me.RstguiCtrlSlots3.TabIndex = 2
        Me.RstguiCtrlSlots3.Visible = False
        Me.RstguiCtrlSlots3.WithGxColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots3.WithoutGxColor = System.Drawing.Color.Empty
        '
        'RstguiCtrlSlots2
        '
        Me.RstguiCtrlSlots2.BufferID = "2"
        Me.RstguiCtrlSlots2.GxExtraDataShow = False
        Me.RstguiCtrlSlots2.GxIDShow = False
        Me.RstguiCtrlSlots2.Location = New System.Drawing.Point(162, 35)
        Me.RstguiCtrlSlots2.MaxSlots = 25
        Me.RstguiCtrlSlots2.Name = "RstguiCtrlSlots2"
        Me.RstguiCtrlSlots2.SetLblFont = Nothing
        Me.RstguiCtrlSlots2.SetSlotTitle = Nothing
        Me.RstguiCtrlSlots2.ShowBufferID = True
        Me.RstguiCtrlSlots2.Size = New System.Drawing.Size(127, 394)
        Me.RstguiCtrlSlots2.SloIndexStep = 1
        Me.RstguiCtrlSlots2.SlotIndexBackColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots2.SlotIndexWidth = 17
        Me.RstguiCtrlSlots2.TabIndex = 1
        Me.RstguiCtrlSlots2.Visible = False
        Me.RstguiCtrlSlots2.WithGxColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots2.WithoutGxColor = System.Drawing.Color.Empty
        '
        'RstguiCtrlSlots1
        '
        Me.RstguiCtrlSlots1.BufferID = "1"
        Me.RstguiCtrlSlots1.GxExtraDataShow = False
        Me.RstguiCtrlSlots1.GxIDShow = False
        Me.RstguiCtrlSlots1.Location = New System.Drawing.Point(292, 35)
        Me.RstguiCtrlSlots1.MaxSlots = 25
        Me.RstguiCtrlSlots1.Name = "RstguiCtrlSlots1"
        Me.RstguiCtrlSlots1.SetLblFont = Nothing
        Me.RstguiCtrlSlots1.SetSlotTitle = Nothing
        Me.RstguiCtrlSlots1.ShowBufferID = True
        Me.RstguiCtrlSlots1.Size = New System.Drawing.Size(140, 394)
        Me.RstguiCtrlSlots1.SloIndexStep = 1
        Me.RstguiCtrlSlots1.SlotIndexBackColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots1.SlotIndexWidth = 17
        Me.RstguiCtrlSlots1.TabIndex = 0
        Me.RstguiCtrlSlots1.Visible = False
        Me.RstguiCtrlSlots1.WithGxColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots1.WithoutGxColor = System.Drawing.Color.Empty
        '
        'ButtonMachineSetting
        '
        Me.ButtonMachineSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonMachineSetting.Location = New System.Drawing.Point(19, 484)
        Me.ButtonMachineSetting.Name = "ButtonMachineSetting"
        Me.ButtonMachineSetting.Size = New System.Drawing.Size(75, 32)
        Me.ButtonMachineSetting.TabIndex = 10
        Me.ButtonMachineSetting.Text = "Machine Parameters"
        Me.ButtonMachineSetting.UseVisualStyleBackColor = True
        '
        'LDToolStripMenuItem
        '
        Me.LDToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LDToolStripMenuItem.Name = "LDToolStripMenuItem"
        Me.LDToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.LDToolStripMenuItem.Text = "LD"
        '
        'CASSETTE1ToolStripMenuItem
        '
        Me.CASSETTE1ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CASSETTE1ToolStripMenuItem.Name = "CASSETTE1ToolStripMenuItem"
        Me.CASSETTE1ToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CASSETTE1ToolStripMenuItem.Text = "CASSETTE1"
        '
        'CASSETTE2ToolStripMenuItem
        '
        Me.CASSETTE2ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CASSETTE2ToolStripMenuItem.Name = "CASSETTE2ToolStripMenuItem"
        Me.CASSETTE2ToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CASSETTE2ToolStripMenuItem.Text = "CASSETTE2"
        '
        'EQ1SampleGlassToolStripMenuItem
        '
        Me.EQ1SampleGlassToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EQ1SampleGlassToolStripMenuItem.Name = "EQ1SampleGlassToolStripMenuItem"
        Me.EQ1SampleGlassToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.EQ1SampleGlassToolStripMenuItem.Text = "EQ1 Sample Glass "
        '
        'EQ2SampleGlassToolStripMenuItem
        '
        Me.EQ2SampleGlassToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EQ2SampleGlassToolStripMenuItem.Name = "EQ2SampleGlassToolStripMenuItem"
        Me.EQ2SampleGlassToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.EQ2SampleGlassToolStripMenuItem.Text = "EQ2 Sample Glass "
        '
        'GrayToolStripMenuItem
        '
        Me.GrayToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GrayToolStripMenuItem.Name = "GrayToolStripMenuItem"
        Me.GrayToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.GrayToolStripMenuItem.Text = "Gray"
        '
        'NGToolStripMenuItem
        '
        Me.NGToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.NGToolStripMenuItem.Name = "NGToolStripMenuItem"
        Me.NGToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.NGToolStripMenuItem.Text = "NG"
        '
        'OKToolStripMenuItem
        '
        Me.OKToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.OKToolStripMenuItem.Name = "OKToolStripMenuItem"
        Me.OKToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.OKToolStripMenuItem.Text = "OK"
        '
        'ContextMenuStripBufferSlotType
        '
        Me.ContextMenuStripBufferSlotType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ContextMenuStripBufferSlotType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BufferSlotToolStripMenuItem, Me.OKToolStripMenuItem, Me.NGToolStripMenuItem, Me.GrayToolStripMenuItem, Me.LDToolStripMenuItem, Me.InkToolStripMenuItem, Me.CASSETTE1ToolStripMenuItem, Me.CASSETTE2ToolStripMenuItem, Me.CASSETTE3ToolStripMenuItem, Me.EQ1SampleGlassToolStripMenuItem, Me.EQ2SampleGlassToolStripMenuItem})
        Me.ContextMenuStripBufferSlotType.Name = "ContextMenuStripBufferSlotType"
        Me.ContextMenuStripBufferSlotType.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStripBufferSlotType.ShowImageMargin = False
        Me.ContextMenuStripBufferSlotType.ShowItemToolTips = False
        Me.ContextMenuStripBufferSlotType.Size = New System.Drawing.Size(166, 271)
        '
        'BufferSlotToolStripMenuItem
        '
        Me.BufferSlotToolStripMenuItem.Name = "BufferSlotToolStripMenuItem"
        Me.BufferSlotToolStripMenuItem.ReadOnly = True
        Me.BufferSlotToolStripMenuItem.Size = New System.Drawing.Size(130, 23)
        Me.BufferSlotToolStripMenuItem.Text = "Buffer#     Slot#"
        Me.BufferSlotToolStripMenuItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InkToolStripMenuItem
        '
        Me.InkToolStripMenuItem.Name = "InkToolStripMenuItem"
        Me.InkToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.InkToolStripMenuItem.Text = "Ink"
        '
        'CASSETTE3ToolStripMenuItem
        '
        Me.CASSETTE3ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CASSETTE3ToolStripMenuItem.Name = "CASSETTE3ToolStripMenuItem"
        Me.CASSETTE3ToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CASSETTE3ToolStripMenuItem.Text = "CASSETTE3"
        '
        'ButtonCassetteInfoColumnSelect
        '
        Me.ButtonCassetteInfoColumnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCassetteInfoColumnSelect.Location = New System.Drawing.Point(110, 484)
        Me.ButtonCassetteInfoColumnSelect.Name = "ButtonCassetteInfoColumnSelect"
        Me.ButtonCassetteInfoColumnSelect.Size = New System.Drawing.Size(103, 32)
        Me.ButtonCassetteInfoColumnSelect.TabIndex = 12
        Me.ButtonCassetteInfoColumnSelect.Text = "CassetteInfo Column Selection"
        Me.ButtonCassetteInfoColumnSelect.UseVisualStyleBackColor = True
        '
        'DialogSystemParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.ButtonMachineSetting)
        Me.Controls.Add(Me.ButtonCassetteInfoColumnSelect)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogSystemParameter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System Parameter"
        CType(Me.NumericUpDownLogFileKeepDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ContextMenuStripBufferSlotType.ResumeLayout(False)
        Me.ContextMenuStripBufferSlotType.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NumericUpDownLogFileKeepDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonAlarmFilePLC As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAlarmFilePLC As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ButtonAlarmFileEQ3 As System.Windows.Forms.Button
    Friend WithEvents ButtonAlarmFileEQ2 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxEQ3ToolID As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEQ2ToolID As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEQ1ToolID As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxToolID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCVToolID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRSTToolID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxLineID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxEQ3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEQ2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEQ1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonAlarmFileCV As System.Windows.Forms.Button
    Friend WithEvents ButtonAlarmFileEQ1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxAlarmFileCV As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAlarmFileEQ3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAlarmFileEQ2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAlarmFileEQ1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ComboBoxGlassTMode As System.Windows.Forms.ComboBox
    Friend WithEvents RstguiCtrlSlots3 As RSTShapFlowGUI.RSTGUICtrlSlots
    Friend WithEvents RstguiCtrlSlots2 As RSTShapFlowGUI.RSTGUICtrlSlots
    Friend WithEvents RstguiCtrlSlots1 As RSTShapFlowGUI.RSTGUICtrlSlots
    Friend WithEvents ButtonMachineSetting As System.Windows.Forms.Button
    Friend WithEvents LDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CASSETTE1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CASSETTE2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EQ1SampleGlassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EQ2SampleGlassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OKToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripBufferSlotType As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BufferSlotToolStripMenuItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ButtonCassetteInfoColumnSelect As System.Windows.Forms.Button
    Friend WithEvents InkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CASSETTE3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ButtonLoad As System.Windows.Forms.Button

End Class
