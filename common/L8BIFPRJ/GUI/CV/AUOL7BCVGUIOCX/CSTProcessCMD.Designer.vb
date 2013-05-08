<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSTProcessCMD
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdWriteWord = New System.Windows.Forms.Button
        Me.txtCSTID = New System.Windows.Forms.TextBox
        Me.txtPortNumber = New System.Windows.Forms.TextBox
        Me.txtCSTSlotInfo = New System.Windows.Forms.TextBox
        Me.txtProcessGxQTY = New System.Windows.Forms.TextBox
        Me.txtProcessCMD = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdCSTProcessReq = New System.Windows.Forms.Button
        Me.lblSignalCSTProcessReqAck = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabPort1 = New System.Windows.Forms.TabPage
        Me.tabPort2 = New System.Windows.Forms.TabPage
        Me.tabPort3 = New System.Windows.Forms.TabPage
        Me.tabPort4 = New System.Windows.Forms.TabPage
        Me.tabPort5 = New System.Windows.Forms.TabPage
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdWriteWord)
        Me.Panel1.Controls.Add(Me.txtCSTID)
        Me.Panel1.Controls.Add(Me.txtPortNumber)
        Me.Panel1.Controls.Add(Me.txtCSTSlotInfo)
        Me.Panel1.Controls.Add(Me.txtProcessGxQTY)
        Me.Panel1.Controls.Add(Me.txtProcessCMD)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'cmdWriteWord
        '
        Me.cmdWriteWord.Location = New System.Drawing.Point(370, 194)
        Me.cmdWriteWord.Name = "cmdWriteWord"
        Me.cmdWriteWord.Size = New System.Drawing.Size(75, 23)
        Me.cmdWriteWord.TabIndex = 15
        Me.cmdWriteWord.Text = "Set"
        Me.cmdWriteWord.UseVisualStyleBackColor = True
        Me.cmdWriteWord.Visible = False
        '
        'txtCSTID
        '
        Me.txtCSTID.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtCSTID.Location = New System.Drawing.Point(258, 115)
        Me.txtCSTID.Name = "txtCSTID"
        Me.txtCSTID.Size = New System.Drawing.Size(187, 27)
        Me.txtCSTID.TabIndex = 14
        '
        'txtPortNumber
        '
        Me.txtPortNumber.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPortNumber.Location = New System.Drawing.Point(258, 23)
        Me.txtPortNumber.Name = "txtPortNumber"
        Me.txtPortNumber.Size = New System.Drawing.Size(187, 27)
        Me.txtPortNumber.TabIndex = 13
        '
        'txtCSTSlotInfo
        '
        Me.txtCSTSlotInfo.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtCSTSlotInfo.Location = New System.Drawing.Point(258, 69)
        Me.txtCSTSlotInfo.Name = "txtCSTSlotInfo"
        Me.txtCSTSlotInfo.Size = New System.Drawing.Size(187, 27)
        Me.txtCSTSlotInfo.TabIndex = 12
        '
        'txtProcessGxQTY
        '
        Me.txtProcessGxQTY.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtProcessGxQTY.Location = New System.Drawing.Point(258, 92)
        Me.txtProcessGxQTY.Name = "txtProcessGxQTY"
        Me.txtProcessGxQTY.Size = New System.Drawing.Size(187, 27)
        Me.txtProcessGxQTY.TabIndex = 11
        '
        'txtProcessCMD
        '
        Me.txtProcessCMD.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtProcessCMD.Location = New System.Drawing.Point(258, 46)
        Me.txtProcessCMD.Name = "txtProcessCMD"
        Me.txtProcessCMD.Size = New System.Drawing.Size(187, 27)
        Me.txtProcessCMD.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(238, 23)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Cassette ID[6A]"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Process Glass Quantity[1W]"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(249, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cassette Slot Information[4A]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Process Command[1W]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCSTProcessReq
        '
        Me.cmdCSTProcessReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdCSTProcessReq.Location = New System.Drawing.Point(521, 90)
        Me.cmdCSTProcessReq.Name = "cmdCSTProcessReq"
        Me.cmdCSTProcessReq.Size = New System.Drawing.Size(133, 43)
        Me.cmdCSTProcessReq.TabIndex = 0
        Me.cmdCSTProcessReq.Text = "CST Process Request"
        Me.cmdCSTProcessReq.UseVisualStyleBackColor = True
        '
        'lblSignalCSTProcessReqAck
        '
        Me.lblSignalCSTProcessReqAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalCSTProcessReqAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalCSTProcessReqAck.Location = New System.Drawing.Point(3, 9)
        Me.lblSignalCSTProcessReqAck.Name = "lblSignalCSTProcessReqAck"
        Me.lblSignalCSTProcessReqAck.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalCSTProcessReqAck.TabIndex = 1
        Me.lblSignalCSTProcessReqAck.Text = "CST Process Request Ack"
        Me.lblSignalCSTProcessReqAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdCSTProcessReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalCSTProcessReqAck)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabPort1)
        Me.TabControl1.Controls.Add(Me.tabPort2)
        Me.TabControl1.Controls.Add(Me.tabPort3)
        Me.TabControl1.Controls.Add(Me.tabPort4)
        Me.TabControl1.Controls.Add(Me.tabPort5)
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
        'CSTProcessCMD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "CSTProcessCMD"
        Me.Size = New System.Drawing.Size(781, 515)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdCSTProcessReq As System.Windows.Forms.Button
    Friend WithEvents lblSignalCSTProcessReqAck As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCSTID As System.Windows.Forms.TextBox
    Friend WithEvents txtPortNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCSTSlotInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessGxQTY As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessCMD As System.Windows.Forms.TextBox
    Friend WithEvents cmdWriteWord As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPort1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort4 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort5 As System.Windows.Forms.TabPage

End Class
