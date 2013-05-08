<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxStatus
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
        Me.lblWAlarmOccurr = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblWToolID = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblWHandoff = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblWGxInProcess = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblWGxOnStage = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblWEQStatus = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdIgnoreTimeout = New System.Windows.Forms.Button
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.Label18 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdTransferMode = New System.Windows.Forms.Button
        Me.cmdArmMode = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRSTMode = New System.Windows.Forms.TextBox
        Me.txtRemoteStatus = New System.Windows.Forms.TextBox
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWAlarmOccurr)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lblWToolID)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lblWHandoff)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblWGxInProcess)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblWGxOnStage)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblWEQStatus)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWAlarmOccurr
        '
        Me.lblWAlarmOccurr.BackColor = System.Drawing.Color.White
        Me.lblWAlarmOccurr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWAlarmOccurr.Location = New System.Drawing.Point(250, 141)
        Me.lblWAlarmOccurr.Name = "lblWAlarmOccurr"
        Me.lblWAlarmOccurr.Size = New System.Drawing.Size(187, 22)
        Me.lblWAlarmOccurr.TabIndex = 110
        Me.lblWAlarmOccurr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(238, 23)
        Me.Label15.TabIndex = 109
        Me.Label15.Text = "Alarm Occurr[Bit]"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWToolID
        '
        Me.lblWToolID.BackColor = System.Drawing.Color.White
        Me.lblWToolID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWToolID.Location = New System.Drawing.Point(250, 117)
        Me.lblWToolID.Name = "lblWToolID"
        Me.lblWToolID.Size = New System.Drawing.Size(187, 22)
        Me.lblWToolID.TabIndex = 108
        Me.lblWToolID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(238, 23)
        Me.Label13.TabIndex = 107
        Me.Label13.Text = "ToolID[A8]"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWHandoff
        '
        Me.lblWHandoff.BackColor = System.Drawing.Color.White
        Me.lblWHandoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWHandoff.Location = New System.Drawing.Point(250, 92)
        Me.lblWHandoff.Name = "lblWHandoff"
        Me.lblWHandoff.Size = New System.Drawing.Size(187, 22)
        Me.lblWHandoff.TabIndex = 102
        Me.lblWHandoff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 23)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Handoff Available[Bit]"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWGxInProcess
        '
        Me.lblWGxInProcess.BackColor = System.Drawing.Color.White
        Me.lblWGxInProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWGxInProcess.Location = New System.Drawing.Point(250, 68)
        Me.lblWGxInProcess.Name = "lblWGxInProcess"
        Me.lblWGxInProcess.Size = New System.Drawing.Size(187, 22)
        Me.lblWGxInProcess.TabIndex = 100
        Me.lblWGxInProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 23)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Glass In Process[Bit]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWGxOnStage
        '
        Me.lblWGxOnStage.BackColor = System.Drawing.Color.White
        Me.lblWGxOnStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWGxOnStage.Location = New System.Drawing.Point(250, 44)
        Me.lblWGxOnStage.Name = "lblWGxOnStage"
        Me.lblWGxOnStage.Size = New System.Drawing.Size(187, 22)
        Me.lblWGxOnStage.TabIndex = 98
        Me.lblWGxOnStage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Glass Exist On Stage[Bit]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWEQStatus
        '
        Me.lblWEQStatus.BackColor = System.Drawing.Color.White
        Me.lblWEQStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWEQStatus.Location = New System.Drawing.Point(250, 20)
        Me.lblWEQStatus.Name = "lblWEQStatus"
        Me.lblWEQStatus.Size = New System.Drawing.Size(187, 22)
        Me.lblWEQStatus.TabIndex = 96
        Me.lblWEQStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(238, 23)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "EQ Status[W1]"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdIgnoreTimeout
        '
        Me.cmdIgnoreTimeout.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdIgnoreTimeout.Location = New System.Drawing.Point(491, 6)
        Me.cmdIgnoreTimeout.Name = "cmdIgnoreTimeout"
        Me.cmdIgnoreTimeout.Size = New System.Drawing.Size(167, 30)
        Me.cmdIgnoreTimeout.TabIndex = 0
        Me.cmdIgnoreTimeout.Text = "Ignore Timeout"
        Me.cmdIgnoreTimeout.UseVisualStyleBackColor = True
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
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(238, 23)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Remote Status[W1]"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTransferMode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdArmMode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdIgnoreTimeout)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 11
        '
        'cmdTransferMode
        '
        Me.cmdTransferMode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTransferMode.Location = New System.Drawing.Point(491, 78)
        Me.cmdTransferMode.Name = "cmdTransferMode"
        Me.cmdTransferMode.Size = New System.Drawing.Size(167, 30)
        Me.cmdTransferMode.TabIndex = 3
        Me.cmdTransferMode.Text = "Transfer Mode"
        Me.cmdTransferMode.UseVisualStyleBackColor = True
        '
        'cmdArmMode
        '
        Me.cmdArmMode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdArmMode.Location = New System.Drawing.Point(491, 42)
        Me.cmdArmMode.Name = "cmdArmMode"
        Me.cmdArmMode.Size = New System.Drawing.Size(167, 30)
        Me.cmdArmMode.TabIndex = 2
        Me.cmdArmMode.Text = "Arm Mode"
        Me.cmdArmMode.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtRSTMode)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtRemoteStatus)
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 222)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Robot Station Mode[W1]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRSTMode
        '
        Me.txtRSTMode.Location = New System.Drawing.Point(250, 37)
        Me.txtRSTMode.Name = "txtRSTMode"
        Me.txtRSTMode.Size = New System.Drawing.Size(187, 22)
        Me.txtRSTMode.TabIndex = 42
        '
        'txtRemoteStatus
        '
        Me.txtRemoteStatus.Location = New System.Drawing.Point(250, 9)
        Me.txtRemoteStatus.Name = "txtRemoteStatus"
        Me.txtRemoteStatus.Size = New System.Drawing.Size(187, 22)
        Me.txtRemoteStatus.TabIndex = 40
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
        'OcxStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OcxStatus"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWAlarmOccurr As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblWToolID As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblWHandoff As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblWGxInProcess As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblWGxOnStage As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblWEQStatus As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmdIgnoreTimeout As System.Windows.Forms.Button
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdTransferMode As System.Windows.Forms.Button
    Friend WithEvents cmdArmMode As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRSTMode As System.Windows.Forms.TextBox
    Friend WithEvents txtRemoteStatus As System.Windows.Forms.TextBox
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl

End Class
