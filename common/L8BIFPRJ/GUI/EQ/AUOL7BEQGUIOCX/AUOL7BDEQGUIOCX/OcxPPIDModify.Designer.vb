<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxPPIDModify
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblWModifyType = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblWEPPID = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdEPPIDModifyAck = New System.Windows.Forms.Button
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblSignalEPPIDModifyReport = New System.Windows.Forms.Label
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWModifyType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblWEPPID)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWModifyType
        '
        Me.lblWModifyType.BackColor = System.Drawing.Color.White
        Me.lblWModifyType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWModifyType.Location = New System.Drawing.Point(250, 42)
        Me.lblWModifyType.Name = "lblWModifyType"
        Me.lblWModifyType.Size = New System.Drawing.Size(187, 22)
        Me.lblWModifyType.TabIndex = 98
        Me.lblWModifyType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 23)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Modify Type[W1]"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWEPPID
        '
        Me.lblWEPPID.BackColor = System.Drawing.Color.White
        Me.lblWEPPID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWEPPID.Location = New System.Drawing.Point(250, 18)
        Me.lblWEPPID.Name = "lblWEPPID"
        Me.lblWEPPID.Size = New System.Drawing.Size(187, 22)
        Me.lblWEPPID.TabIndex = 96
        Me.lblWEPPID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(238, 23)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "EPPID [A4]"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdEPPIDModifyAck
        '
        Me.cmdEPPIDModifyAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdEPPIDModifyAck.Location = New System.Drawing.Point(10, 4)
        Me.cmdEPPIDModifyAck.Name = "cmdEPPIDModifyAck"
        Me.cmdEPPIDModifyAck.Size = New System.Drawing.Size(167, 30)
        Me.cmdEPPIDModifyAck.TabIndex = 0
        Me.cmdEPPIDModifyAck.Text = "EPPID Modify Ack"
        Me.cmdEPPIDModifyAck.UseVisualStyleBackColor = True
        '
        'tabEQ2
        '
        Me.tabEQ2.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ2.Name = "tabEQ2"
        Me.tabEQ2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEQ2.Size = New System.Drawing.Size(318, 0)
        Me.tabEQ2.TabIndex = 1
        Me.tabEQ2.Text = "EQ2"
        Me.tabEQ2.UseVisualStyleBackColor = True
        '
        'tabEQ3
        '
        Me.tabEQ3.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ3.Name = "tabEQ3"
        Me.tabEQ3.Size = New System.Drawing.Size(318, 0)
        Me.tabEQ3.TabIndex = 2
        Me.tabEQ3.Text = "EQ3"
        Me.tabEQ3.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdEPPIDModifyAck)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalEPPIDModifyReport)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 11
        '
        'lblSignalEPPIDModifyReport
        '
        Me.lblSignalEPPIDModifyReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalEPPIDModifyReport.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalEPPIDModifyReport.Location = New System.Drawing.Point(491, 11)
        Me.lblSignalEPPIDModifyReport.Name = "lblSignalEPPIDModifyReport"
        Me.lblSignalEPPIDModifyReport.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalEPPIDModifyReport.TabIndex = 1
        Me.lblSignalEPPIDModifyReport.Text = "EPPID Modify Report"
        Me.lblSignalEPPIDModifyReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabEQ1
        '
        Me.tabEQ1.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ1.Name = "tabEQ1"
        Me.tabEQ1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEQ1.Size = New System.Drawing.Size(318, 0)
        Me.tabEQ1.TabIndex = 0
        Me.tabEQ1.Text = "EQ1"
        Me.tabEQ1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabEQ1)
        Me.TabControl1.Controls.Add(Me.tabEQ2)
        Me.TabControl1.Controls.Add(Me.tabEQ3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 10
        '
        'OcxPPIDModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OcxPPIDModify"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWEPPID As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmdEPPIDModifyAck As System.Windows.Forms.Button
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblSignalEPPIDModifyReport As System.Windows.Forms.Label
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents lblWModifyType As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
