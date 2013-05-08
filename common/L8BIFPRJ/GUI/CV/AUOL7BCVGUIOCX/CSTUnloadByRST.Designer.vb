<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSTUnloadByRST
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblSignalUnloadReq = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdRSTRequestUnloadCST = New System.Windows.Forms.Button
        Me.cmdCSTUnloadReqAck = New System.Windows.Forms.Button
        Me.cmdCSTUnloadPriority = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblWTotalGx = New System.Windows.Forms.Label
        Me.lblWUnloadStat = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabPort1 = New System.Windows.Forms.TabPage
        Me.tabPort2 = New System.Windows.Forms.TabPage
        Me.tabPort3 = New System.Windows.Forms.TabPage
        Me.tabPort4 = New System.Windows.Forms.TabPage
        Me.tabPort5 = New System.Windows.Forms.TabPage
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Total Glass QTY[1W]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSignalUnloadReq
        '
        Me.lblSignalUnloadReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalUnloadReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalUnloadReq.Location = New System.Drawing.Point(491, 102)
        Me.lblSignalUnloadReq.Name = "lblSignalUnloadReq"
        Me.lblSignalUnloadReq.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalUnloadReq.TabIndex = 1
        Me.lblSignalUnloadReq.Text = "CST Unload Request"
        Me.lblSignalUnloadReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRSTRequestUnloadCST)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdCSTUnloadReqAck)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdCSTUnloadPriority)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalUnloadReq)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 5
        '
        'cmdRSTRequestUnloadCST
        '
        Me.cmdRSTRequestUnloadCST.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdRSTRequestUnloadCST.Location = New System.Drawing.Point(281, 5)
        Me.cmdRSTRequestUnloadCST.Name = "cmdRSTRequestUnloadCST"
        Me.cmdRSTRequestUnloadCST.Size = New System.Drawing.Size(133, 43)
        Me.cmdRSTRequestUnloadCST.TabIndex = 2
        Me.cmdRSTRequestUnloadCST.Text = "RST Request Unload CST"
        Me.cmdRSTRequestUnloadCST.UseVisualStyleBackColor = True
        '
        'cmdCSTUnloadReqAck
        '
        Me.cmdCSTUnloadReqAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdCSTUnloadReqAck.Location = New System.Drawing.Point(142, 5)
        Me.cmdCSTUnloadReqAck.Name = "cmdCSTUnloadReqAck"
        Me.cmdCSTUnloadReqAck.Size = New System.Drawing.Size(133, 43)
        Me.cmdCSTUnloadReqAck.TabIndex = 1
        Me.cmdCSTUnloadReqAck.Text = "CST Unload Request Ack"
        Me.cmdCSTUnloadReqAck.UseVisualStyleBackColor = True
        '
        'cmdCSTUnloadPriority
        '
        Me.cmdCSTUnloadPriority.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdCSTUnloadPriority.Location = New System.Drawing.Point(3, 4)
        Me.cmdCSTUnloadPriority.Name = "cmdCSTUnloadPriority"
        Me.cmdCSTUnloadPriority.Size = New System.Drawing.Size(133, 43)
        Me.cmdCSTUnloadPriority.TabIndex = 0
        Me.cmdCSTUnloadPriority.Text = "CST Unload Priority"
        Me.cmdCSTUnloadPriority.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWTotalGx)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblWUnloadStat)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWTotalGx
        '
        Me.lblWTotalGx.BackColor = System.Drawing.Color.White
        Me.lblWTotalGx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWTotalGx.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWTotalGx.Location = New System.Drawing.Point(258, 44)
        Me.lblWTotalGx.Name = "lblWTotalGx"
        Me.lblWTotalGx.Size = New System.Drawing.Size(187, 23)
        Me.lblWTotalGx.TabIndex = 3
        Me.lblWTotalGx.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWUnloadStat
        '
        Me.lblWUnloadStat.BackColor = System.Drawing.Color.White
        Me.lblWUnloadStat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWUnloadStat.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWUnloadStat.Location = New System.Drawing.Point(258, 21)
        Me.lblWUnloadStat.Name = "lblWUnloadStat"
        Me.lblWUnloadStat.Size = New System.Drawing.Size(187, 23)
        Me.lblWUnloadStat.TabIndex = 1
        Me.lblWUnloadStat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unload Status[1W]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TabControl1.TabIndex = 4
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
        'CSTUnloadByRST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "CSTUnloadByRST"
        Me.Size = New System.Drawing.Size(738, 504)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblSignalUnloadReq As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdCSTUnloadReqAck As System.Windows.Forms.Button
    Friend WithEvents cmdCSTUnloadPriority As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWTotalGx As System.Windows.Forms.Label
    Friend WithEvents lblWUnloadStat As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPort1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort4 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort5 As System.Windows.Forms.TabPage
    Friend WithEvents cmdRSTRequestUnloadCST As System.Windows.Forms.Button

End Class
