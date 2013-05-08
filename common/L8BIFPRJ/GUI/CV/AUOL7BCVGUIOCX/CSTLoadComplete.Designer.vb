<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSTLoadComplete
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabPort1 = New System.Windows.Forms.TabPage
        Me.tabPort2 = New System.Windows.Forms.TabPage
        Me.tabPort3 = New System.Windows.Forms.TabPage
        Me.tabPort4 = New System.Windows.Forms.TabPage
        Me.tabPort5 = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblWMiniSlot = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblWCSTID = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdCSTLoadCompAck = New System.Windows.Forms.Button
        Me.llbSignalCSTLoadComp = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TabControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabPort1)
        Me.TabControl1.Controls.Add(Me.tabPort2)
        Me.TabControl1.Controls.Add(Me.tabPort3)
        Me.TabControl1.Controls.Add(Me.tabPort4)
        Me.TabControl1.Controls.Add(Me.tabPort5)
        Me.TabControl1.Location = New System.Drawing.Point(3, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 2
        '
        'tabPort1
        '
        Me.tabPort1.Location = New System.Drawing.Point(4, 21)
        Me.tabPort1.Name = "tabPort1"
        Me.tabPort1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPort1.Size = New System.Drawing.Size(318, 0)
        Me.tabPort1.TabIndex = 0
        Me.tabPort1.Text = "Port1"
        Me.tabPort1.UseVisualStyleBackColor = True
        '
        'tabPort2
        '
        Me.tabPort2.Location = New System.Drawing.Point(4, 21)
        Me.tabPort2.Name = "tabPort2"
        Me.tabPort2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPort2.Size = New System.Drawing.Size(318, 0)
        Me.tabPort2.TabIndex = 1
        Me.tabPort2.Text = "Port2"
        Me.tabPort2.UseVisualStyleBackColor = True
        '
        'tabPort3
        '
        Me.tabPort3.Location = New System.Drawing.Point(4, 21)
        Me.tabPort3.Name = "tabPort3"
        Me.tabPort3.Size = New System.Drawing.Size(318, 0)
        Me.tabPort3.TabIndex = 2
        Me.tabPort3.Text = "Port3"
        Me.tabPort3.UseVisualStyleBackColor = True
        '
        'tabPort4
        '
        Me.tabPort4.Location = New System.Drawing.Point(4, 21)
        Me.tabPort4.Name = "tabPort4"
        Me.tabPort4.Size = New System.Drawing.Size(318, 0)
        Me.tabPort4.TabIndex = 3
        Me.tabPort4.Text = "Port4"
        Me.tabPort4.UseVisualStyleBackColor = True
        '
        'tabPort5
        '
        Me.tabPort5.Location = New System.Drawing.Point(4, 21)
        Me.tabPort5.Name = "tabPort5"
        Me.tabPort5.Size = New System.Drawing.Size(318, 0)
        Me.tabPort5.TabIndex = 4
        Me.tabPort5.Text = "Port5"
        Me.tabPort5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mini Slot[1W]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWMiniSlot
        '
        Me.lblWMiniSlot.BackColor = System.Drawing.Color.White
        Me.lblWMiniSlot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWMiniSlot.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWMiniSlot.Location = New System.Drawing.Point(258, 21)
        Me.lblWMiniSlot.Name = "lblWMiniSlot"
        Me.lblWMiniSlot.Size = New System.Drawing.Size(187, 23)
        Me.lblWMiniSlot.TabIndex = 1
        Me.lblWMiniSlot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWCSTID)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblWMiniSlot)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWCSTID
        '
        Me.lblWCSTID.BackColor = System.Drawing.Color.White
        Me.lblWCSTID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWCSTID.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWCSTID.Location = New System.Drawing.Point(258, 44)
        Me.lblWCSTID.Name = "lblWCSTID"
        Me.lblWCSTID.Size = New System.Drawing.Size(187, 23)
        Me.lblWCSTID.TabIndex = 3
        Me.lblWCSTID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cassette ID[6A]"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCSTLoadCompAck
        '
        Me.cmdCSTLoadCompAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdCSTLoadCompAck.Location = New System.Drawing.Point(3, 4)
        Me.cmdCSTLoadCompAck.Name = "cmdCSTLoadCompAck"
        Me.cmdCSTLoadCompAck.Size = New System.Drawing.Size(133, 43)
        Me.cmdCSTLoadCompAck.TabIndex = 0
        Me.cmdCSTLoadCompAck.Text = "CST Load Complete Ack"
        Me.cmdCSTLoadCompAck.UseVisualStyleBackColor = True
        '
        'llbSignalCSTLoadComp
        '
        Me.llbSignalCSTLoadComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.llbSignalCSTLoadComp.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.llbSignalCSTLoadComp.Location = New System.Drawing.Point(491, 102)
        Me.llbSignalCSTLoadComp.Name = "llbSignalCSTLoadComp"
        Me.llbSignalCSTLoadComp.Size = New System.Drawing.Size(133, 43)
        Me.llbSignalCSTLoadComp.TabIndex = 1
        Me.llbSignalCSTLoadComp.Text = "CST Load Complete"
        Me.llbSignalCSTLoadComp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 31)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdCSTLoadCompAck)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.llbSignalCSTLoadComp)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 3
        '
        'CSTLoadComplete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "CSTLoadComplete"
        Me.Size = New System.Drawing.Size(731, 506)
        Me.TabControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPort1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort4 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort5 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblWMiniSlot As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWCSTID As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCSTLoadCompAck As System.Windows.Forms.Button
    Friend WithEvents llbSignalCSTLoadComp As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
