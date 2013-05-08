<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinkStatus
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
        Me.cmdConnect = New System.Windows.Forms.Button
        Me.cmdDisconnect = New System.Windows.Forms.Button
        Me.cmdLinkReq = New System.Windows.Forms.Button
        Me.lblSignalCVLinkReq = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdLinkTest = New System.Windows.Forms.Button
        Me.lblSignalCVLinkTest = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdConnect)
        Me.Panel1.Controls.Add(Me.cmdDisconnect)
        Me.Panel1.Location = New System.Drawing.Point(3, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'cmdConnect
        '
        Me.cmdConnect.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdConnect.Location = New System.Drawing.Point(3, 3)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(133, 43)
        Me.cmdConnect.TabIndex = 2
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdDisconnect.Location = New System.Drawing.Point(138, 3)
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Size = New System.Drawing.Size(133, 43)
        Me.cmdDisconnect.TabIndex = 1
        Me.cmdDisconnect.Text = "Disconnect"
        Me.cmdDisconnect.UseVisualStyleBackColor = True
        '
        'cmdLinkReq
        '
        Me.cmdLinkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLinkReq.Location = New System.Drawing.Point(587, 3)
        Me.cmdLinkReq.Name = "cmdLinkReq"
        Me.cmdLinkReq.Size = New System.Drawing.Size(133, 43)
        Me.cmdLinkReq.TabIndex = 0
        Me.cmdLinkReq.Text = "RST Link Request"
        Me.cmdLinkReq.UseVisualStyleBackColor = True
        '
        'lblSignalCVLinkReq
        '
        Me.lblSignalCVLinkReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalCVLinkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalCVLinkReq.Location = New System.Drawing.Point(3, 9)
        Me.lblSignalCVLinkReq.Name = "lblSignalCVLinkReq"
        Me.lblSignalCVLinkReq.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalCVLinkReq.TabIndex = 1
        Me.lblSignalCVLinkReq.Text = "Conveyor Link Request"
        Me.lblSignalCVLinkReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLinkTest)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLinkReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalCVLinkTest)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalCVLinkReq)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 15
        '
        'cmdLinkTest
        '
        Me.cmdLinkTest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLinkTest.Location = New System.Drawing.Point(587, 60)
        Me.cmdLinkTest.Name = "cmdLinkTest"
        Me.cmdLinkTest.Size = New System.Drawing.Size(133, 43)
        Me.cmdLinkTest.TabIndex = 1
        Me.cmdLinkTest.Text = "Link Test Request"
        Me.cmdLinkTest.UseVisualStyleBackColor = True
        '
        'lblSignalCVLinkTest
        '
        Me.lblSignalCVLinkTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalCVLinkTest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalCVLinkTest.Location = New System.Drawing.Point(142, 9)
        Me.lblSignalCVLinkTest.Name = "lblSignalCVLinkTest"
        Me.lblSignalCVLinkTest.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalCVLinkTest.TabIndex = 2
        Me.lblSignalCVLinkTest.Text = "Link Test Response"
        Me.lblSignalCVLinkTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "LinkStatus"
        Me.Size = New System.Drawing.Size(733, 499)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdLinkReq As System.Windows.Forms.Button
    Friend WithEvents lblSignalCVLinkReq As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents cmdDisconnect As System.Windows.Forms.Button
    Friend WithEvents cmdLinkTest As System.Windows.Forms.Button
    Friend WithEvents lblSignalCVLinkTest As System.Windows.Forms.Label

End Class
