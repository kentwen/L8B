<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSTGUICtrlEQ
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
        Me.picContainer = New System.Windows.Forms.PictureBox
        Me.picEQConnectStats = New System.Windows.Forms.PictureBox
        Me.picGlass = New System.Windows.Forms.PictureBox
        Me.lblGlassID = New System.Windows.Forms.Label
        Me.lblEQName = New System.Windows.Forms.Label
        Me.lblEQRunningMode = New System.Windows.Forms.Label
        Me.LabelAlias = New System.Windows.Forms.Label
        CType(Me.picContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEQConnectStats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGlass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picContainer
        '
        Me.picContainer.BackColor = System.Drawing.SystemColors.Control
        Me.picContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picContainer.Location = New System.Drawing.Point(0, 0)
        Me.picContainer.Name = "picContainer"
        Me.picContainer.Size = New System.Drawing.Size(148, 98)
        Me.picContainer.TabIndex = 0
        Me.picContainer.TabStop = False
        '
        'picEQConnectStats
        '
        Me.picEQConnectStats.BackColor = System.Drawing.Color.White
        Me.picEQConnectStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picEQConnectStats.Location = New System.Drawing.Point(122, 3)
        Me.picEQConnectStats.Name = "picEQConnectStats"
        Me.picEQConnectStats.Size = New System.Drawing.Size(21, 18)
        Me.picEQConnectStats.TabIndex = 1
        Me.picEQConnectStats.TabStop = False
        '
        'picGlass
        '
        Me.picGlass.BackColor = System.Drawing.Color.White
        Me.picGlass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picGlass.Location = New System.Drawing.Point(4, 23)
        Me.picGlass.Name = "picGlass"
        Me.picGlass.Size = New System.Drawing.Size(139, 57)
        Me.picGlass.TabIndex = 2
        Me.picGlass.TabStop = False
        '
        'lblGlassID
        '
        Me.lblGlassID.BackColor = System.Drawing.Color.White
        Me.lblGlassID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblGlassID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGlassID.Location = New System.Drawing.Point(8, 44)
        Me.lblGlassID.Name = "lblGlassID"
        Me.lblGlassID.Size = New System.Drawing.Size(130, 16)
        Me.lblGlassID.TabIndex = 3
        Me.lblGlassID.Text = "AAAAAAAAAAAAAAAA"
        Me.lblGlassID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEQName
        '
        Me.lblEQName.AutoSize = True
        Me.lblEQName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEQName.Location = New System.Drawing.Point(5, 5)
        Me.lblEQName.Name = "lblEQName"
        Me.lblEQName.Size = New System.Drawing.Size(66, 14)
        Me.lblEQName.TabIndex = 4
        Me.lblEQName.Text = "Equipment"
        '
        'lblEQRunningMode
        '
        Me.lblEQRunningMode.AutoSize = True
        Me.lblEQRunningMode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEQRunningMode.Location = New System.Drawing.Point(99, 83)
        Me.lblEQRunningMode.Name = "lblEQRunningMode"
        Me.lblEQRunningMode.Size = New System.Drawing.Size(35, 14)
        Me.lblEQRunningMode.TabIndex = 5
        Me.lblEQRunningMode.Text = "NONE"
        '
        'LabelAlias
        '
        Me.LabelAlias.AutoSize = True
        Me.LabelAlias.Location = New System.Drawing.Point(8, 83)
        Me.LabelAlias.Name = "LabelAlias"
        Me.LabelAlias.Size = New System.Drawing.Size(8, 12)
        Me.LabelAlias.TabIndex = 6
        Me.LabelAlias.Text = "."
        '
        'RSTGUICtrlEQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelAlias)
        Me.Controls.Add(Me.lblGlassID)
        Me.Controls.Add(Me.lblEQRunningMode)
        Me.Controls.Add(Me.lblEQName)
        Me.Controls.Add(Me.picGlass)
        Me.Controls.Add(Me.picEQConnectStats)
        Me.Controls.Add(Me.picContainer)
        Me.Name = "RSTGUICtrlEQ"
        Me.Size = New System.Drawing.Size(149, 99)
        CType(Me.picContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEQConnectStats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGlass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picContainer As System.Windows.Forms.PictureBox
    Friend WithEvents picEQConnectStats As System.Windows.Forms.PictureBox
    Friend WithEvents picGlass As System.Windows.Forms.PictureBox
    Friend WithEvents lblGlassID As System.Windows.Forms.Label
    Friend WithEvents lblEQName As System.Windows.Forms.Label
    Friend WithEvents lblEQRunningMode As System.Windows.Forms.Label
    Friend WithEvents LabelAlias As System.Windows.Forms.Label

End Class
