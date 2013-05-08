<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSTLoadReq
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
        Me.cmdLoadCSTReqAck = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabPort1 = New System.Windows.Forms.TabPage
        Me.tabPort2 = New System.Windows.Forms.TabPage
        Me.tabPort3 = New System.Windows.Forms.TabPage
        Me.tabPort4 = New System.Windows.Forms.TabPage
        Me.tabPort5 = New System.Windows.Forms.TabPage
        Me.lblSignalCSTLoadReq = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TabControl1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdLoadCSTReqAck
        '
        Me.cmdLoadCSTReqAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLoadCSTReqAck.Location = New System.Drawing.Point(3, 4)
        Me.cmdLoadCSTReqAck.Name = "cmdLoadCSTReqAck"
        Me.cmdLoadCSTReqAck.Size = New System.Drawing.Size(133, 43)
        Me.cmdLoadCSTReqAck.TabIndex = 0
        Me.cmdLoadCSTReqAck.Text = "CST Load Request Ack"
        Me.cmdLoadCSTReqAck.UseVisualStyleBackColor = True
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
        'lblSignalCSTLoadReq
        '
        Me.lblSignalCSTLoadReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalCSTLoadReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalCSTLoadReq.Location = New System.Drawing.Point(3, 10)
        Me.lblSignalCSTLoadReq.Name = "lblSignalCSTLoadReq"
        Me.lblSignalCSTLoadReq.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalCSTLoadReq.TabIndex = 1
        Me.lblSignalCSTLoadReq.Text = "CST Load Request"
        Me.lblSignalCSTLoadReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLoadCSTReqAck)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalCSTLoadReq)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 5
        '
        'CSTLoadReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "CSTLoadReq"
        Me.Size = New System.Drawing.Size(733, 503)
        Me.TabControl1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdLoadCSTReqAck As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPort1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort4 As System.Windows.Forms.TabPage
    Friend WithEvents tabPort5 As System.Windows.Forms.TabPage
    Friend WithEvents lblSignalCSTLoadReq As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
