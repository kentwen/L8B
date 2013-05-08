<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSTGUIStatusTower
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
        Me.lblTowerName = New System.Windows.Forms.Label
        Me.lblFram = New System.Windows.Forms.Label
        Me.TextBoxStatus = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblTowerName
        '
        Me.lblTowerName.Location = New System.Drawing.Point(15, 1)
        Me.lblTowerName.Name = "lblTowerName"
        Me.lblTowerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTowerName.Size = New System.Drawing.Size(72, 12)
        Me.lblTowerName.TabIndex = 5
        Me.lblTowerName.Text = "Tower Name"
        Me.lblTowerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFram
        '
        Me.lblFram.Location = New System.Drawing.Point(0, 0)
        Me.lblFram.Name = "lblFram"
        Me.lblFram.Size = New System.Drawing.Size(70, 19)
        Me.lblFram.TabIndex = 6
        Me.lblFram.Text = "          "
        '
        'TextBoxStatus
        '
        Me.TextBoxStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBoxStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBoxStatus.Enabled = False
        Me.TextBoxStatus.Location = New System.Drawing.Point(2, 1)
        Me.TextBoxStatus.Multiline = True
        Me.TextBoxStatus.Name = "TextBoxStatus"
        Me.TextBoxStatus.ReadOnly = True
        Me.TextBoxStatus.Size = New System.Drawing.Size(12, 13)
        Me.TextBoxStatus.TabIndex = 8
        '
        'RSTGUIStatusTower
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBoxStatus)
        Me.Controls.Add(Me.lblTowerName)
        Me.Controls.Add(Me.lblFram)
        Me.Name = "RSTGUIStatusTower"
        Me.Size = New System.Drawing.Size(92, 16)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTowerName As System.Windows.Forms.Label
    Friend WithEvents lblFram As System.Windows.Forms.Label
    Friend WithEvents TextBoxStatus As System.Windows.Forms.TextBox

End Class
