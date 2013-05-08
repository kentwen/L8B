<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GxTR_RST2CV
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
        Me.lblSignalTRResetAck = New System.Windows.Forms.Label
        Me.cmdTRResetRequest = New System.Windows.Forms.Button
        Me.cmdTRComplete = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabPort1 = New System.Windows.Forms.TabPage
        Me.tabPort2 = New System.Windows.Forms.TabPage
        Me.tabPort3 = New System.Windows.Forms.TabPage
        Me.tabPort4 = New System.Windows.Forms.TabPage
        Me.cmdRBTBusy = New System.Windows.Forms.Button
        Me.lblSignalCVReady = New System.Windows.Forms.Label
        Me.lblSignalHandOff = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdWriteWord = New System.Windows.Forms.Button
        Me.txtPSHGroup = New System.Windows.Forms.TextBox
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.txtCVGxID = New System.Windows.Forms.TextBox
        Me.txtVCRReadPos = New System.Windows.Forms.TextBox
        Me.txtGxJudgment = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdTRRequest = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSignalTRResetAck
        '
        Me.lblSignalTRResetAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalTRResetAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalTRResetAck.Location = New System.Drawing.Point(281, 18)
        Me.lblSignalTRResetAck.Name = "lblSignalTRResetAck"
        Me.lblSignalTRResetAck.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalTRResetAck.TabIndex = 4
        Me.lblSignalTRResetAck.Text = "Transfer Reset Ack"
        Me.lblSignalTRResetAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdTRResetRequest
        '
        Me.cmdTRResetRequest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRResetRequest.Location = New System.Drawing.Point(587, 150)
        Me.cmdTRResetRequest.Name = "cmdTRResetRequest"
        Me.cmdTRResetRequest.Size = New System.Drawing.Size(133, 43)
        Me.cmdTRResetRequest.TabIndex = 3
        Me.cmdTRResetRequest.Text = "Transfer Reset Request"
        Me.cmdTRResetRequest.UseVisualStyleBackColor = True
        '
        'cmdTRComplete
        '
        Me.cmdTRComplete.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRComplete.Location = New System.Drawing.Point(587, 101)
        Me.cmdTRComplete.Name = "cmdTRComplete"
        Me.cmdTRComplete.Size = New System.Drawing.Size(133, 43)
        Me.cmdTRComplete.TabIndex = 2
        Me.cmdTRComplete.Text = "Transfer Complete"
        Me.cmdTRComplete.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabPort1)
        Me.TabControl1.Controls.Add(Me.tabPort2)
        Me.TabControl1.Controls.Add(Me.tabPort3)
        Me.TabControl1.Controls.Add(Me.tabPort4)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 14
        '
        'tabPort1
        '
        Me.tabPort1.Location = New System.Drawing.Point(4, 21)
        Me.tabPort1.Name = "tabPort1"
        Me.tabPort1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPort1.Size = New System.Drawing.Size(318, 0)
        Me.tabPort1.TabIndex = 0
        Me.tabPort1.Text = "Position1"
        Me.tabPort1.UseVisualStyleBackColor = True
        '
        'tabPort2
        '
        Me.tabPort2.Location = New System.Drawing.Point(4, 21)
        Me.tabPort2.Name = "tabPort2"
        Me.tabPort2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPort2.Size = New System.Drawing.Size(318, 0)
        Me.tabPort2.TabIndex = 1
        Me.tabPort2.Text = "Position2"
        Me.tabPort2.UseVisualStyleBackColor = True
        '
        'tabPort3
        '
        Me.tabPort3.Location = New System.Drawing.Point(4, 21)
        Me.tabPort3.Name = "tabPort3"
        Me.tabPort3.Size = New System.Drawing.Size(318, 0)
        Me.tabPort3.TabIndex = 2
        Me.tabPort3.Text = "Position3"
        Me.tabPort3.UseVisualStyleBackColor = True
        '
        'tabPort4
        '
        Me.tabPort4.Location = New System.Drawing.Point(4, 21)
        Me.tabPort4.Name = "tabPort4"
        Me.tabPort4.Size = New System.Drawing.Size(318, 0)
        Me.tabPort4.TabIndex = 3
        Me.tabPort4.Text = "Position4"
        Me.tabPort4.UseVisualStyleBackColor = True
        '
        'cmdRBTBusy
        '
        Me.cmdRBTBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdRBTBusy.Location = New System.Drawing.Point(587, 52)
        Me.cmdRBTBusy.Name = "cmdRBTBusy"
        Me.cmdRBTBusy.Size = New System.Drawing.Size(133, 43)
        Me.cmdRBTBusy.TabIndex = 1
        Me.cmdRBTBusy.Text = "Robot Busy"
        Me.cmdRBTBusy.UseVisualStyleBackColor = True
        '
        'lblSignalCVReady
        '
        Me.lblSignalCVReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalCVReady.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalCVReady.Location = New System.Drawing.Point(3, 18)
        Me.lblSignalCVReady.Name = "lblSignalCVReady"
        Me.lblSignalCVReady.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalCVReady.TabIndex = 2
        Me.lblSignalCVReady.Text = "Conveyor Ready"
        Me.lblSignalCVReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalHandOff
        '
        Me.lblSignalHandOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalHandOff.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalHandOff.Location = New System.Drawing.Point(142, 18)
        Me.lblSignalHandOff.Name = "lblSignalHandOff"
        Me.lblSignalHandOff.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalHandOff.TabIndex = 3
        Me.lblSignalHandOff.Text = "HandOff Available"
        Me.lblSignalHandOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(238, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "VCR Read Position[1W]"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Glass ID[12A]"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdWriteWord)
        Me.Panel1.Controls.Add(Me.txtPSHGroup)
        Me.Panel1.Controls.Add(Me.txtProductCode)
        Me.Panel1.Controls.Add(Me.txtCVGxID)
        Me.Panel1.Controls.Add(Me.txtVCRReadPos)
        Me.Panel1.Controls.Add(Me.txtGxJudgment)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'cmdWriteWord
        '
        Me.cmdWriteWord.Location = New System.Drawing.Point(370, 194)
        Me.cmdWriteWord.Name = "cmdWriteWord"
        Me.cmdWriteWord.Size = New System.Drawing.Size(75, 23)
        Me.cmdWriteWord.TabIndex = 16
        Me.cmdWriteWord.Text = "Set"
        Me.cmdWriteWord.UseVisualStyleBackColor = True
        Me.cmdWriteWord.Visible = False
        '
        'txtPSHGroup
        '
        Me.txtPSHGroup.Location = New System.Drawing.Point(258, 44)
        Me.txtPSHGroup.Name = "txtPSHGroup"
        Me.txtPSHGroup.Size = New System.Drawing.Size(187, 22)
        Me.txtPSHGroup.TabIndex = 14
        '
        'txtProductCode
        '
        Me.txtProductCode.Location = New System.Drawing.Point(258, 67)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(187, 22)
        Me.txtProductCode.TabIndex = 13
        '
        'txtCVGxID
        '
        Me.txtCVGxID.Location = New System.Drawing.Point(258, 90)
        Me.txtCVGxID.Name = "txtCVGxID"
        Me.txtCVGxID.Size = New System.Drawing.Size(187, 22)
        Me.txtCVGxID.TabIndex = 12
        '
        'txtVCRReadPos
        '
        Me.txtVCRReadPos.Location = New System.Drawing.Point(258, 113)
        Me.txtVCRReadPos.Name = "txtVCRReadPos"
        Me.txtVCRReadPos.Size = New System.Drawing.Size(187, 22)
        Me.txtVCRReadPos.TabIndex = 11
        '
        'txtGxJudgment
        '
        Me.txtGxJudgment.Location = New System.Drawing.Point(258, 21)
        Me.txtGxJudgment.Name = "txtGxJudgment"
        Me.txtGxJudgment.Size = New System.Drawing.Size(187, 22)
        Me.txtGxJudgment.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Product Code[26A]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "PS-H Group[1A]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Glass Judgment[1W]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRResetRequest)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRComplete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRBTBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRRequest)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalTRResetAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalHandOff)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalCVReady)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 15
        '
        'cmdTRRequest
        '
        Me.cmdTRRequest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRRequest.Location = New System.Drawing.Point(587, 3)
        Me.cmdTRRequest.Name = "cmdTRRequest"
        Me.cmdTRRequest.Size = New System.Drawing.Size(133, 43)
        Me.cmdTRRequest.TabIndex = 0
        Me.cmdTRRequest.Text = "Transfer Request"
        Me.cmdTRRequest.UseVisualStyleBackColor = True
        '
        'GxTR_RST2CV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "GxTR_RST2CV"
        Me.Size = New System.Drawing.Size(734, 501)
        Me.TabControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSignalTRResetAck As System.Windows.Forms.Label
    Friend WithEvents cmdTRResetRequest As System.Windows.Forms.Button
    Friend WithEvents cmdTRComplete As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPort1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort4 As System.Windows.Forms.TabPage
    Friend WithEvents cmdRBTBusy As System.Windows.Forms.Button
    Friend WithEvents lblSignalCVReady As System.Windows.Forms.Label
    Friend WithEvents lblSignalHandOff As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdTRRequest As System.Windows.Forms.Button
    Friend WithEvents txtPSHGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCVGxID As System.Windows.Forms.TextBox
    Friend WithEvents txtVCRReadPos As System.Windows.Forms.TextBox
    Friend WithEvents txtGxJudgment As System.Windows.Forms.TextBox
    Friend WithEvents cmdWriteWord As System.Windows.Forms.Button

End Class
