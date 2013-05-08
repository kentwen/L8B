<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PortChangeReq
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
        Me.txtPortMode = New System.Windows.Forms.TextBox
        Me.tabPort4 = New System.Windows.Forms.TabPage
        Me.txtPortType = New System.Windows.Forms.TextBox
        Me.tabPort3 = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabPort2 = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblWChangeResult = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.tabPort1 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabPort5 = New System.Windows.Forms.TabPage
        Me.cmdPortChangeReq = New System.Windows.Forms.Button
        Me.lblSignalPortChangeReqAck = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdWriteWord = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPortMode
        '
        Me.txtPortMode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPortMode.Location = New System.Drawing.Point(258, 47)
        Me.txtPortMode.Name = "txtPortMode"
        Me.txtPortMode.Size = New System.Drawing.Size(187, 27)
        Me.txtPortMode.TabIndex = 12
        Me.txtPortMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtPortType
        '
        Me.txtPortType.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPortType.Location = New System.Drawing.Point(258, 80)
        Me.txtPortType.Name = "txtPortType"
        Me.txtPortType.Size = New System.Drawing.Size(187, 27)
        Me.txtPortType.TabIndex = 11
        Me.txtPortType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdWriteWord)
        Me.Panel1.Controls.Add(Me.txtPortMode)
        Me.Panel1.Controls.Add(Me.txtPortType)
        Me.Panel1.Controls.Add(Me.txtProductCode)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'txtProductCode
        '
        Me.txtProductCode.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtProductCode.Location = New System.Drawing.Point(258, 21)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(187, 21)
        Me.txtProductCode.TabIndex = 8
        Me.txtProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Port Type[1W]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Port Mode[1W]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblWChangeResult)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(450, 222)
        Me.Panel2.TabIndex = 2
        '
        'lblWChangeResult
        '
        Me.lblWChangeResult.BackColor = System.Drawing.Color.White
        Me.lblWChangeResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWChangeResult.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWChangeResult.Location = New System.Drawing.Point(258, 21)
        Me.lblWChangeResult.Name = "lblWChangeResult"
        Me.lblWChangeResult.Size = New System.Drawing.Size(187, 23)
        Me.lblWChangeResult.TabIndex = 10
        Me.lblWChangeResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(238, 23)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Change Result[1W]"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'tabPort5
        '
        Me.tabPort5.Location = New System.Drawing.Point(4, 21)
        Me.tabPort5.Name = "tabPort5"
        Me.tabPort5.Size = New System.Drawing.Size(318, 0)
        Me.tabPort5.TabIndex = 4
        Me.tabPort5.Text = "Port5"
        Me.tabPort5.UseVisualStyleBackColor = True
        '
        'cmdPortChangeReq
        '
        Me.cmdPortChangeReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdPortChangeReq.Location = New System.Drawing.Point(587, 3)
        Me.cmdPortChangeReq.Name = "cmdPortChangeReq"
        Me.cmdPortChangeReq.Size = New System.Drawing.Size(133, 43)
        Me.cmdPortChangeReq.TabIndex = 0
        Me.cmdPortChangeReq.Text = "Port Change Request"
        Me.cmdPortChangeReq.UseVisualStyleBackColor = True
        '
        'lblSignalPortChangeReqAck
        '
        Me.lblSignalPortChangeReqAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalPortChangeReqAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalPortChangeReqAck.Location = New System.Drawing.Point(587, 5)
        Me.lblSignalPortChangeReqAck.Name = "lblSignalPortChangeReqAck"
        Me.lblSignalPortChangeReqAck.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalPortChangeReqAck.TabIndex = 1
        Me.lblSignalPortChangeReqAck.Text = "Port Change Request Ack"
        Me.lblSignalPortChangeReqAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdPortChangeReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalPortChangeReqAck)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 15
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
        'PortChangeReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PortChangeReq"
        Me.Size = New System.Drawing.Size(733, 501)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPortMode As System.Windows.Forms.TextBox
    Friend WithEvents tabPort4 As System.Windows.Forms.TabPage
    Friend WithEvents txtPortType As System.Windows.Forms.TextBox
    Friend WithEvents tabPort3 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabPort2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblWChangeResult As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tabPort1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPort5 As System.Windows.Forms.TabPage
    Friend WithEvents cmdPortChangeReq As System.Windows.Forms.Button
    Friend WithEvents lblSignalPortChangeReqAck As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdWriteWord As System.Windows.Forms.Button

End Class
