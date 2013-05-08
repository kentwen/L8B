<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GxInfoUnmatch
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
        Me.lblWUnmatchCase = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblWSlotNo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblWPortNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdGxSlotUnmatchedAck = New System.Windows.Forms.Button
        Me.lblSignalGxUnmatchReport = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWUnmatchCase)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblWSlotNo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblWPortNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWUnmatchCase
        '
        Me.lblWUnmatchCase.BackColor = System.Drawing.Color.White
        Me.lblWUnmatchCase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWUnmatchCase.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWUnmatchCase.Location = New System.Drawing.Point(258, 67)
        Me.lblWUnmatchCase.Name = "lblWUnmatchCase"
        Me.lblWUnmatchCase.Size = New System.Drawing.Size(187, 23)
        Me.lblWUnmatchCase.TabIndex = 5
        Me.lblWUnmatchCase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Unmatched Case[1W]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWSlotNo
        '
        Me.lblWSlotNo.BackColor = System.Drawing.Color.White
        Me.lblWSlotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWSlotNo.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWSlotNo.Location = New System.Drawing.Point(258, 44)
        Me.lblWSlotNo.Name = "lblWSlotNo"
        Me.lblWSlotNo.Size = New System.Drawing.Size(187, 23)
        Me.lblWSlotNo.TabIndex = 3
        Me.lblWSlotNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Slot Number[1W]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWPortNo
        '
        Me.lblWPortNo.BackColor = System.Drawing.Color.White
        Me.lblWPortNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWPortNo.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWPortNo.Location = New System.Drawing.Point(258, 21)
        Me.lblWPortNo.Name = "lblWPortNo"
        Me.lblWPortNo.Size = New System.Drawing.Size(187, 23)
        Me.lblWPortNo.TabIndex = 1
        Me.lblWPortNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port Number[1W]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGxSlotUnmatchedAck
        '
        Me.cmdGxSlotUnmatchedAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdGxSlotUnmatchedAck.Location = New System.Drawing.Point(3, 4)
        Me.cmdGxSlotUnmatchedAck.Name = "cmdGxSlotUnmatchedAck"
        Me.cmdGxSlotUnmatchedAck.Size = New System.Drawing.Size(133, 43)
        Me.cmdGxSlotUnmatchedAck.TabIndex = 0
        Me.cmdGxSlotUnmatchedAck.Text = "Glass Slot Unmatched Ack"
        Me.cmdGxSlotUnmatchedAck.UseVisualStyleBackColor = True
        '
        'lblSignalGxUnmatchReport
        '
        Me.lblSignalGxUnmatchReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxUnmatchReport.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxUnmatchReport.Location = New System.Drawing.Point(587, 5)
        Me.lblSignalGxUnmatchReport.Name = "lblSignalGxUnmatchReport"
        Me.lblSignalGxUnmatchReport.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalGxUnmatchReport.TabIndex = 1
        Me.lblSignalGxUnmatchReport.Text = "Glass Info Unmatched Report"
        Me.lblSignalGxUnmatchReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGxSlotUnmatchedAck)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxUnmatchReport)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 13
        '
        'GxInfoUnmatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "GxInfoUnmatch"
        Me.Size = New System.Drawing.Size(734, 503)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWUnmatchCase As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblWSlotNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblWPortNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGxSlotUnmatchedAck As System.Windows.Forms.Button
    Friend WithEvents lblSignalGxUnmatchReport As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
