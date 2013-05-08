<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GxFlowIn
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
        Me.cmdGxFlowInAck = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabPort1 = New System.Windows.Forms.TabPage
        Me.tabPort2 = New System.Windows.Forms.TabPage
        Me.tabPort3 = New System.Windows.Forms.TabPage
        Me.tabPort4 = New System.Windows.Forms.TabPage
        Me.tabPort5 = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblSignalGxFlowIn = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblWSlotNumber = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblWCVGxID = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblWProductCode = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdGxFlowInAck
        '
        Me.cmdGxFlowInAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdGxFlowInAck.Location = New System.Drawing.Point(3, 4)
        Me.cmdGxFlowInAck.Name = "cmdGxFlowInAck"
        Me.cmdGxFlowInAck.Size = New System.Drawing.Size(133, 43)
        Me.cmdGxFlowInAck.TabIndex = 0
        Me.cmdGxFlowInAck.Text = "Glass Flow In Ack"
        Me.cmdGxFlowInAck.UseVisualStyleBackColor = True
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
        Me.TabControl1.TabIndex = 10
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
        Me.Label1.Text = "Product Code[26A]"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGxFlowInAck)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxFlowIn)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 11
        '
        'lblSignalGxFlowIn
        '
        Me.lblSignalGxFlowIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxFlowIn.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxFlowIn.Location = New System.Drawing.Point(587, 5)
        Me.lblSignalGxFlowIn.Name = "lblSignalGxFlowIn"
        Me.lblSignalGxFlowIn.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalGxFlowIn.TabIndex = 1
        Me.lblSignalGxFlowIn.Text = "Glass Flow In"
        Me.lblSignalGxFlowIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWSlotNumber)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblWCVGxID)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblWProductCode)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWSlotNumber
        '
        Me.lblWSlotNumber.BackColor = System.Drawing.Color.White
        Me.lblWSlotNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWSlotNumber.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWSlotNumber.Location = New System.Drawing.Point(258, 67)
        Me.lblWSlotNumber.Name = "lblWSlotNumber"
        Me.lblWSlotNumber.Size = New System.Drawing.Size(187, 23)
        Me.lblWSlotNumber.TabIndex = 5
        Me.lblWSlotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Slot Number[1W]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWCVGxID
        '
        Me.lblWCVGxID.BackColor = System.Drawing.Color.White
        Me.lblWCVGxID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWCVGxID.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWCVGxID.Location = New System.Drawing.Point(258, 44)
        Me.lblWCVGxID.Name = "lblWCVGxID"
        Me.lblWCVGxID.Size = New System.Drawing.Size(187, 23)
        Me.lblWCVGxID.TabIndex = 3
        Me.lblWCVGxID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Glass ID[12A]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWProductCode
        '
        Me.lblWProductCode.BackColor = System.Drawing.Color.White
        Me.lblWProductCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWProductCode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWProductCode.Location = New System.Drawing.Point(258, 21)
        Me.lblWProductCode.Name = "lblWProductCode"
        Me.lblWProductCode.Size = New System.Drawing.Size(187, 23)
        Me.lblWProductCode.TabIndex = 1
        Me.lblWProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GxFlowIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "GxFlowIn"
        Me.Size = New System.Drawing.Size(735, 504)
        Me.TabControl1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdGxFlowInAck As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPort1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort4 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort5 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblSignalGxFlowIn As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWProductCode As System.Windows.Forms.Label
    Friend WithEvents lblWSlotNumber As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblWCVGxID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
