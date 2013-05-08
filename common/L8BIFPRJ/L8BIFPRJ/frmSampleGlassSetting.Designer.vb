<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSampleGlassSetting
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
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkboxEnableT3 = New System.Windows.Forms.CheckBox
        Me.chkboxEnableT1 = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMinuteT1 = New System.Windows.Forms.TextBox
        Me.txtHourT1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.txtMinuteT3 = New System.Windows.Forms.TextBox
        Me.txtHourT3 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.cboEQ1Week = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboEQ2Week = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(142, 323)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(266, 323)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboEQ1Week)
        Me.GroupBox1.Controls.Add(Me.chkboxEnableT1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtMinuteT1)
        Me.GroupBox1.Controls.Add(Me.txtHourT1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 134)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sample Glass For EQ1"
        '
        'chkboxEnableT3
        '
        Me.chkboxEnableT3.AutoSize = True
        Me.chkboxEnableT3.Location = New System.Drawing.Point(378, 89)
        Me.chkboxEnableT3.Name = "chkboxEnableT3"
        Me.chkboxEnableT3.Size = New System.Drawing.Size(15, 14)
        Me.chkboxEnableT3.TabIndex = 29
        Me.chkboxEnableT3.UseVisualStyleBackColor = True
        '
        'chkboxEnableT1
        '
        Me.chkboxEnableT1.AutoSize = True
        Me.chkboxEnableT1.Location = New System.Drawing.Point(378, 82)
        Me.chkboxEnableT1.Name = "chkboxEnableT1"
        Me.chkboxEnableT1.Size = New System.Drawing.Size(15, 14)
        Me.chkboxEnableT1.TabIndex = 27
        Me.chkboxEnableT1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(270, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 12)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "0-59 Minute"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(270, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 12)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "0-23 Hour"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(201, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 12)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Minute"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(166, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Hour"
        '
        'txtMinuteT1
        '
        Me.txtMinuteT1.Location = New System.Drawing.Point(203, 82)
        Me.txtMinuteT1.Name = "txtMinuteT1"
        Me.txtMinuteT1.Size = New System.Drawing.Size(32, 22)
        Me.txtMinuteT1.TabIndex = 10
        '
        'txtHourT1
        '
        Me.txtHourT1.Location = New System.Drawing.Point(165, 82)
        Me.txtHourT1.Name = "txtHourT1"
        Me.txtHourT1.Size = New System.Drawing.Size(32, 22)
        Me.txtHourT1.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "EQ 1:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(366, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Enable"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(261, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Value Range"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Default Value"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 18)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(428, 113)
        Me.ShapeContainer1.TabIndex = 4
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 0
        Me.LineShape1.X2 = 427
        Me.LineShape1.Y1 = 36
        Me.LineShape1.Y2 = 36
        '
        'txtMinuteT3
        '
        Me.txtMinuteT3.Location = New System.Drawing.Point(201, 89)
        Me.txtMinuteT3.Name = "txtMinuteT3"
        Me.txtMinuteT3.Size = New System.Drawing.Size(32, 22)
        Me.txtMinuteT3.TabIndex = 25
        '
        'txtHourT3
        '
        Me.txtHourT3.Location = New System.Drawing.Point(165, 89)
        Me.txtHourT3.Name = "txtHourT3"
        Me.txtHourT3.Size = New System.Drawing.Size(32, 22)
        Me.txtHourT3.TabIndex = 24
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.cboEQ2Week)
        Me.GroupBox2.Controls.Add(Me.chkboxEnableT3)
        Me.GroupBox2.Controls.Add(Me.txtHourT3)
        Me.GroupBox2.Controls.Add(Me.txtMinuteT3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.ShapeContainer2)
        Me.GroupBox2.Location = New System.Drawing.Point(36, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(434, 139)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sample Glass For EQ2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(273, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "0-59 Minute"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(273, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "0-23 Hour"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(199, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 12)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Minute"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(166, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Hour"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 92)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 12)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "EQ 2:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(366, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 12)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Enable"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(261, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Value Range"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(104, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 12)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Default Value"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(21, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 12)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Name"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(3, 18)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2})
        Me.ShapeContainer2.Size = New System.Drawing.Size(428, 118)
        Me.ShapeContainer2.TabIndex = 4
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape1"
        Me.LineShape2.X1 = 0
        Me.LineShape2.X2 = 427
        Me.LineShape2.Y1 = 36
        Me.LineShape2.Y2 = 36
        '
        'cboEQ1Week
        '
        Me.cboEQ1Week.FormattingEnabled = True
        Me.cboEQ1Week.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.cboEQ1Week.Location = New System.Drawing.Point(59, 82)
        Me.cboEQ1Week.Name = "cboEQ1Week"
        Me.cboEQ1Week.Size = New System.Drawing.Size(89, 20)
        Me.cboEQ1Week.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(70, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 12)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Week"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(73, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 12)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Week"
        '
        'cboEQ2Week
        '
        Me.cboEQ2Week.FormattingEnabled = True
        Me.cboEQ2Week.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.cboEQ2Week.Location = New System.Drawing.Point(59, 89)
        Me.cboEQ2Week.Name = "cboEQ2Week"
        Me.cboEQ2Week.Size = New System.Drawing.Size(89, 20)
        Me.cboEQ2Week.TabIndex = 30
        '
        'frmSampleGlassSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 367)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmSampleGlassSetting"
        Me.Text = "frmSampleGlassSetting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents txtHourT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMinuteT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkboxEnableT3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxEnableT1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtMinuteT3 As System.Windows.Forms.TextBox
    Friend WithEvents txtHourT3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents cboEQ1Week As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboEQ2Week As System.Windows.Forms.ComboBox
End Class
