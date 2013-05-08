<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSTGUICtrlRBT
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.picFrame = New System.Windows.Forms.PictureBox
        Me.lblRBTCaption = New System.Windows.Forms.Label
        Me.lblLowArmText = New System.Windows.Forms.Label
        Me.lblUpArmText = New System.Windows.Forms.Label
        Me.lblLowArmGxID = New System.Windows.Forms.Label
        Me.lblUpArmGxID = New System.Windows.Forms.Label
        Me.lblLowArm = New System.Windows.Forms.Label
        Me.lblUpArm = New System.Windows.Forms.Label
        Me.lblRBT = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.OvalShape2 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.OvalShape1 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.LabelUVacuum = New System.Windows.Forms.Label
        Me.LabelUSensor = New System.Windows.Forms.Label
        Me.LabelLSensor = New System.Windows.Forms.Label
        Me.LabelLVacuum = New System.Windows.Forms.Label
        CType(Me.picFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picFrame
        '
        Me.picFrame.BackColor = System.Drawing.Color.White
        Me.picFrame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFrame.Location = New System.Drawing.Point(0, -7)
        Me.picFrame.Name = "picFrame"
        Me.picFrame.Size = New System.Drawing.Size(216, 154)
        Me.picFrame.TabIndex = 35
        Me.picFrame.TabStop = False
        '
        'lblRBTCaption
        '
        Me.lblRBTCaption.BackColor = System.Drawing.Color.Black
        Me.lblRBTCaption.ForeColor = System.Drawing.Color.Yellow
        Me.lblRBTCaption.Location = New System.Drawing.Point(87, 112)
        Me.lblRBTCaption.Name = "lblRBTCaption"
        Me.lblRBTCaption.Size = New System.Drawing.Size(51, 15)
        Me.lblRBTCaption.TabIndex = 43
        Me.lblRBTCaption.Text = "Robort"
        Me.lblRBTCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLowArmText
        '
        Me.lblLowArmText.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLowArmText.ForeColor = System.Drawing.Color.Yellow
        Me.lblLowArmText.Location = New System.Drawing.Point(149, 93)
        Me.lblLowArmText.Name = "lblLowArmText"
        Me.lblLowArmText.Size = New System.Drawing.Size(8, 13)
        Me.lblLowArmText.TabIndex = 42
        Me.lblLowArmText.Text = "L"
        Me.lblLowArmText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUpArmText
        '
        Me.lblUpArmText.BackColor = System.Drawing.Color.Green
        Me.lblUpArmText.ForeColor = System.Drawing.Color.Yellow
        Me.lblUpArmText.Location = New System.Drawing.Point(59, 93)
        Me.lblUpArmText.Name = "lblUpArmText"
        Me.lblUpArmText.Size = New System.Drawing.Size(9, 14)
        Me.lblUpArmText.TabIndex = 41
        Me.lblUpArmText.Text = "U"
        Me.lblUpArmText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLowArmGxID
        '
        Me.lblLowArmGxID.BackColor = System.Drawing.Color.White
        Me.lblLowArmGxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLowArmGxID.Location = New System.Drawing.Point(110, 9)
        Me.lblLowArmGxID.Name = "lblLowArmGxID"
        Me.lblLowArmGxID.Size = New System.Drawing.Size(82, 78)
        Me.lblLowArmGxID.TabIndex = 40
        Me.lblLowArmGxID.Text = "Glass ID"
        Me.lblLowArmGxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUpArmGxID
        '
        Me.lblUpArmGxID.BackColor = System.Drawing.Color.White
        Me.lblUpArmGxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUpArmGxID.Location = New System.Drawing.Point(22, 9)
        Me.lblUpArmGxID.Name = "lblUpArmGxID"
        Me.lblUpArmGxID.Size = New System.Drawing.Size(82, 78)
        Me.lblUpArmGxID.TabIndex = 39
        Me.lblUpArmGxID.Text = "Glass ID"
        Me.lblUpArmGxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLowArm
        '
        Me.lblLowArm.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLowArm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLowArm.Location = New System.Drawing.Point(143, 4)
        Me.lblLowArm.Name = "lblLowArm"
        Me.lblLowArm.Size = New System.Drawing.Size(19, 116)
        Me.lblLowArm.TabIndex = 38
        '
        'lblUpArm
        '
        Me.lblUpArm.BackColor = System.Drawing.Color.Green
        Me.lblUpArm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUpArm.Location = New System.Drawing.Point(54, 4)
        Me.lblUpArm.Name = "lblUpArm"
        Me.lblUpArm.Size = New System.Drawing.Size(19, 116)
        Me.lblUpArm.TabIndex = 37
        '
        'lblRBT
        '
        Me.lblRBT.BackColor = System.Drawing.Color.Black
        Me.lblRBT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRBT.Location = New System.Drawing.Point(44, 108)
        Me.lblRBT.Name = "lblRBT"
        Me.lblRBT.Size = New System.Drawing.Size(127, 23)
        Me.lblRBT.TabIndex = 36
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.OvalShape2, Me.OvalShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(218, 150)
        Me.ShapeContainer1.TabIndex = 44
        Me.ShapeContainer1.TabStop = False
        '
        'OvalShape2
        '
        Me.OvalShape2.FillColor = System.Drawing.Color.White
        Me.OvalShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.OvalShape2.Location = New System.Drawing.Point(82, 72)
        Me.OvalShape2.Name = "OvalShape2"
        Me.OvalShape2.Size = New System.Drawing.Size(52, 50)
        '
        'OvalShape1
        '
        Me.OvalShape1.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.OvalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.OvalShape1.Location = New System.Drawing.Point(67, 57)
        Me.OvalShape1.Name = "OvalShape1"
        Me.OvalShape1.Size = New System.Drawing.Size(81, 82)
        '
        'LabelUVacuum
        '
        Me.LabelUVacuum.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LabelUVacuum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelUVacuum.Location = New System.Drawing.Point(3, 123)
        Me.LabelUVacuum.Name = "LabelUVacuum"
        Me.LabelUVacuum.Size = New System.Drawing.Size(46, 15)
        Me.LabelUVacuum.TabIndex = 46
        Me.LabelUVacuum.Text = "Vacuum"
        Me.LabelUVacuum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelUVacuum.Visible = False
        '
        'LabelUSensor
        '
        Me.LabelUSensor.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LabelUSensor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelUSensor.Location = New System.Drawing.Point(3, 108)
        Me.LabelUSensor.Name = "LabelUSensor"
        Me.LabelUSensor.Size = New System.Drawing.Size(46, 15)
        Me.LabelUSensor.TabIndex = 47
        Me.LabelUSensor.Text = "Sensor"
        Me.LabelUSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelUSensor.Visible = False
        '
        'LabelLSensor
        '
        Me.LabelLSensor.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LabelLSensor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelLSensor.Location = New System.Drawing.Point(170, 108)
        Me.LabelLSensor.Name = "LabelLSensor"
        Me.LabelLSensor.Size = New System.Drawing.Size(46, 15)
        Me.LabelLSensor.TabIndex = 48
        Me.LabelLSensor.Text = "Sensor"
        Me.LabelLSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelLSensor.Visible = False
        '
        'LabelLVacuum
        '
        Me.LabelLVacuum.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LabelLVacuum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelLVacuum.Location = New System.Drawing.Point(170, 123)
        Me.LabelLVacuum.Name = "LabelLVacuum"
        Me.LabelLVacuum.Size = New System.Drawing.Size(46, 15)
        Me.LabelLVacuum.TabIndex = 49
        Me.LabelLVacuum.Text = "Vacuum"
        Me.LabelLVacuum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelLVacuum.Visible = False
        '
        'RSTGUICtrlRBT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelUSensor)
        Me.Controls.Add(Me.LabelUVacuum)
        Me.Controls.Add(Me.lblRBT)
        Me.Controls.Add(Me.LabelLVacuum)
        Me.Controls.Add(Me.LabelLSensor)
        Me.Controls.Add(Me.lblRBTCaption)
        Me.Controls.Add(Me.lblUpArmGxID)
        Me.Controls.Add(Me.lblLowArmText)
        Me.Controls.Add(Me.lblUpArmText)
        Me.Controls.Add(Me.lblLowArmGxID)
        Me.Controls.Add(Me.lblLowArm)
        Me.Controls.Add(Me.lblUpArm)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Controls.Add(Me.picFrame)
        Me.Name = "RSTGUICtrlRBT"
        Me.Size = New System.Drawing.Size(218, 150)
        CType(Me.picFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picFrame As System.Windows.Forms.PictureBox
    Friend WithEvents lblRBTCaption As System.Windows.Forms.Label
    Friend WithEvents lblLowArmText As System.Windows.Forms.Label
    Friend WithEvents lblUpArmText As System.Windows.Forms.Label
    Friend WithEvents lblLowArmGxID As System.Windows.Forms.Label
    Friend WithEvents lblUpArmGxID As System.Windows.Forms.Label
    Friend WithEvents lblLowArm As System.Windows.Forms.Label
    Friend WithEvents lblUpArm As System.Windows.Forms.Label
    Friend WithEvents lblRBT As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents OvalShape2 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents LabelUVacuum As System.Windows.Forms.Label
    Friend WithEvents LabelUSensor As System.Windows.Forms.Label
    Friend WithEvents LabelLSensor As System.Windows.Forms.Label
    Friend WithEvents LabelLVacuum As System.Windows.Forms.Label

End Class
