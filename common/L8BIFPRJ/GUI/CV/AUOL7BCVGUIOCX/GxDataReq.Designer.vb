<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GxDataReq
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
        Me.lblSignalGxDataReq = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtVCRReadPos = New System.Windows.Forms.TextBox
        Me.txtGxJudgment = New System.Windows.Forms.TextBox
        Me.txtPSHGroup = New System.Windows.Forms.TextBox
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdDataEmptyFlag = New System.Windows.Forms.Button
        Me.cmdGxDataReqAck = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblWGxID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdWriteWord = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSignalGxDataReq
        '
        Me.lblSignalGxDataReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxDataReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxDataReq.Location = New System.Drawing.Point(587, 5)
        Me.lblSignalGxDataReq.Name = "lblSignalGxDataReq"
        Me.lblSignalGxDataReq.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalGxDataReq.TabIndex = 1
        Me.lblSignalGxDataReq.Text = "Glass Data Request"
        Me.lblSignalGxDataReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdDataEmptyFlag)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGxDataReqAck)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxDataReq)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmdWriteWord)
        Me.Panel2.Controls.Add(Me.txtVCRReadPos)
        Me.Panel2.Controls.Add(Me.txtGxJudgment)
        Me.Panel2.Controls.Add(Me.txtPSHGroup)
        Me.Panel2.Controls.Add(Me.txtProductCode)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(450, 222)
        Me.Panel2.TabIndex = 2
        '
        'txtVCRReadPos
        '
        Me.txtVCRReadPos.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtVCRReadPos.Location = New System.Drawing.Point(258, 93)
        Me.txtVCRReadPos.Name = "txtVCRReadPos"
        Me.txtVCRReadPos.Size = New System.Drawing.Size(187, 27)
        Me.txtVCRReadPos.TabIndex = 11
        '
        'txtGxJudgment
        '
        Me.txtGxJudgment.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtGxJudgment.Location = New System.Drawing.Point(258, 69)
        Me.txtGxJudgment.Name = "txtGxJudgment"
        Me.txtGxJudgment.Size = New System.Drawing.Size(187, 27)
        Me.txtGxJudgment.TabIndex = 10
        '
        'txtPSHGroup
        '
        Me.txtPSHGroup.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPSHGroup.Location = New System.Drawing.Point(258, 45)
        Me.txtPSHGroup.Name = "txtPSHGroup"
        Me.txtPSHGroup.Size = New System.Drawing.Size(187, 27)
        Me.txtPSHGroup.TabIndex = 9
        '
        'txtProductCode
        '
        Me.txtProductCode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtProductCode.Location = New System.Drawing.Point(258, 20)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(187, 27)
        Me.txtProductCode.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(238, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "VCR Read Position[1W]"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(238, 23)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Glass Judgment[1W]"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(238, 23)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "PS-H Group[1A]"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(238, 23)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Product Code[26A]"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdDataEmptyFlag
        '
        Me.cmdDataEmptyFlag.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdDataEmptyFlag.Location = New System.Drawing.Point(587, 52)
        Me.cmdDataEmptyFlag.Name = "cmdDataEmptyFlag"
        Me.cmdDataEmptyFlag.Size = New System.Drawing.Size(133, 43)
        Me.cmdDataEmptyFlag.TabIndex = 1
        Me.cmdDataEmptyFlag.Text = "Data Empty Flag"
        Me.cmdDataEmptyFlag.UseVisualStyleBackColor = True
        '
        'cmdGxDataReqAck
        '
        Me.cmdGxDataReqAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdGxDataReqAck.Location = New System.Drawing.Point(587, 3)
        Me.cmdGxDataReqAck.Name = "cmdGxDataReqAck"
        Me.cmdGxDataReqAck.Size = New System.Drawing.Size(133, 43)
        Me.cmdGxDataReqAck.TabIndex = 0
        Me.cmdGxDataReqAck.Text = "Glass Data Request Ack"
        Me.cmdGxDataReqAck.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWGxID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWGxID
        '
        Me.lblWGxID.BackColor = System.Drawing.Color.White
        Me.lblWGxID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWGxID.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWGxID.Location = New System.Drawing.Point(258, 21)
        Me.lblWGxID.Name = "lblWGxID"
        Me.lblWGxID.Size = New System.Drawing.Size(187, 23)
        Me.lblWGxID.TabIndex = 1
        Me.lblWGxID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Glass ID[12A]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'GxDataReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "GxDataReq"
        Me.Size = New System.Drawing.Size(739, 504)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSignalGxDataReq As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdGxDataReqAck As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWGxID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDataEmptyFlag As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtVCRReadPos As System.Windows.Forms.TextBox
    Friend WithEvents txtGxJudgment As System.Windows.Forms.TextBox
    Friend WithEvents txtPSHGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdWriteWord As System.Windows.Forms.Button

End Class
