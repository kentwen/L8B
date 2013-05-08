<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxPPIDChk
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
        Me.cmdEPPIDChkReq = New System.Windows.Forms.Button
        Me.lblWCheckResult = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtEPPID = New System.Windows.Forms.TextBox
        Me.lblSignalEPPIDChkAck = New System.Windows.Forms.Label
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdEPPIDChkReq
        '
        Me.cmdEPPIDChkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdEPPIDChkReq.Location = New System.Drawing.Point(491, 6)
        Me.cmdEPPIDChkReq.Name = "cmdEPPIDChkReq"
        Me.cmdEPPIDChkReq.Size = New System.Drawing.Size(167, 30)
        Me.cmdEPPIDChkReq.TabIndex = 0
        Me.cmdEPPIDChkReq.Text = "EPPID Check Request"
        Me.cmdEPPIDChkReq.UseVisualStyleBackColor = True
        '
        'lblWCheckResult
        '
        Me.lblWCheckResult.BackColor = System.Drawing.Color.White
        Me.lblWCheckResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWCheckResult.Location = New System.Drawing.Point(250, 18)
        Me.lblWCheckResult.Name = "lblWCheckResult"
        Me.lblWCheckResult.Size = New System.Drawing.Size(187, 22)
        Me.lblWCheckResult.TabIndex = 96
        Me.lblWCheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(238, 23)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "EPPID Check Result[W1]"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtEPPID)
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 222)
        Me.Panel2.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(238, 23)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "EPPID[A4]"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEPPID
        '
        Me.txtEPPID.Location = New System.Drawing.Point(250, 9)
        Me.txtEPPID.Name = "txtEPPID"
        Me.txtEPPID.Size = New System.Drawing.Size(187, 22)
        Me.txtEPPID.TabIndex = 40
        '
        'lblSignalEPPIDChkAck
        '
        Me.lblSignalEPPIDChkAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalEPPIDChkAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalEPPIDChkAck.Location = New System.Drawing.Point(491, 11)
        Me.lblSignalEPPIDChkAck.Name = "lblSignalEPPIDChkAck"
        Me.lblSignalEPPIDChkAck.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalEPPIDChkAck.TabIndex = 1
        Me.lblSignalEPPIDChkAck.Text = "EPPID Check Ack"
        Me.lblSignalEPPIDChkAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdEPPIDChkReq)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalEPPIDChkAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWCheckResult)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 222)
        Me.Panel1.TabIndex = 0
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabEQ1)
        Me.TabControl1.Controls.Add(Me.tabEQ2)
        Me.TabControl1.Controls.Add(Me.tabEQ3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 8
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
        'OcxPPIDChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OcxPPIDChk"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdEPPIDChkReq As System.Windows.Forms.Button
    Friend WithEvents lblWCheckResult As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtEPPID As System.Windows.Forms.TextBox
    Friend WithEvents lblSignalEPPIDChkAck As System.Windows.Forms.Label
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage

End Class
