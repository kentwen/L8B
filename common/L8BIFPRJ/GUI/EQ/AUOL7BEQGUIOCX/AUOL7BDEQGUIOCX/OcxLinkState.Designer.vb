<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxLinkState
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
        Me.cmdLinkReq = New System.Windows.Forms.Button
        Me.lblSignalLinkTest = New System.Windows.Forms.Label
        Me.cmdLinkTest = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmdDisconnect = New System.Windows.Forms.Button
        Me.cmdConnect = New System.Windows.Forms.Button
        Me.lblSignalLinkReq = New System.Windows.Forms.Label
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdLinkReq
        '
        Me.cmdLinkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLinkReq.Location = New System.Drawing.Point(491, 6)
        Me.cmdLinkReq.Name = "cmdLinkReq"
        Me.cmdLinkReq.Size = New System.Drawing.Size(167, 30)
        Me.cmdLinkReq.TabIndex = 0
        Me.cmdLinkReq.Text = "RST Link Request"
        Me.cmdLinkReq.UseVisualStyleBackColor = True
        '
        'lblSignalLinkTest
        '
        Me.lblSignalLinkTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalLinkTest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalLinkTest.Location = New System.Drawing.Point(180, 11)
        Me.lblSignalLinkTest.Name = "lblSignalLinkTest"
        Me.lblSignalLinkTest.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalLinkTest.TabIndex = 2
        Me.lblSignalLinkTest.Text = "Link Test Response"
        Me.lblSignalLinkTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdLinkTest
        '
        Me.cmdLinkTest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLinkTest.Location = New System.Drawing.Point(491, 41)
        Me.cmdLinkTest.Name = "cmdLinkTest"
        Me.cmdLinkTest.Size = New System.Drawing.Size(167, 30)
        Me.cmdLinkTest.TabIndex = 2
        Me.cmdLinkTest.Text = "Link Test Request"
        Me.cmdLinkTest.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmdDisconnect)
        Me.Panel2.Controls.Add(Me.cmdConnect)
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 222)
        Me.Panel2.TabIndex = 1
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdDisconnect.Location = New System.Drawing.Point(176, 3)
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Size = New System.Drawing.Size(167, 30)
        Me.cmdDisconnect.TabIndex = 6
        Me.cmdDisconnect.Text = "Disconnect"
        Me.cmdDisconnect.UseVisualStyleBackColor = True
        '
        'cmdConnect
        '
        Me.cmdConnect.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdConnect.Location = New System.Drawing.Point(3, 3)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(167, 30)
        Me.cmdConnect.TabIndex = 5
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'lblSignalLinkReq
        '
        Me.lblSignalLinkReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalLinkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalLinkReq.Location = New System.Drawing.Point(7, 11)
        Me.lblSignalLinkReq.Name = "lblSignalLinkReq"
        Me.lblSignalLinkReq.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalLinkReq.TabIndex = 1
        Me.lblSignalLinkReq.Text = "EQ Link Request"
        Me.lblSignalLinkReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLinkTest)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLinkReq)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalLinkTest)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalLinkReq)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 9
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
        'OcxLinkState
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OcxLinkState"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdLinkReq As System.Windows.Forms.Button
    Friend WithEvents lblSignalLinkTest As System.Windows.Forms.Label
    Friend WithEvents cmdLinkTest As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdDisconnect As System.Windows.Forms.Button
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents lblSignalLinkReq As System.Windows.Forms.Label
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage

End Class
