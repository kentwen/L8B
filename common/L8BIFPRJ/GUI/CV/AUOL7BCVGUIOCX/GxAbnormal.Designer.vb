<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GxAbnormal
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
        Me.lblWSourceGxID = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblSignalGxAbnormalReport = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdGxAbnormalAck = New System.Windows.Forms.Button
        Me.lblSignalGxAbnormalReportAck = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblWGxPosition = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblWVCRGxID = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblWAbnormalCase = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblWSourceGxID
        '
        Me.lblWSourceGxID.BackColor = System.Drawing.Color.White
        Me.lblWSourceGxID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWSourceGxID.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWSourceGxID.Location = New System.Drawing.Point(258, 44)
        Me.lblWSourceGxID.Name = "lblWSourceGxID"
        Me.lblWSourceGxID.Size = New System.Drawing.Size(187, 23)
        Me.lblWSourceGxID.TabIndex = 3
        Me.lblWSourceGxID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Source Glass ID[12A]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSignalGxAbnormalReport
        '
        Me.lblSignalGxAbnormalReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxAbnormalReport.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxAbnormalReport.Location = New System.Drawing.Point(587, 5)
        Me.lblSignalGxAbnormalReport.Name = "lblSignalGxAbnormalReport"
        Me.lblSignalGxAbnormalReport.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalGxAbnormalReport.TabIndex = 1
        Me.lblSignalGxAbnormalReport.Text = "Glass Abnormal Report"
        Me.lblSignalGxAbnormalReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Abnormal Case[1W]"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGxAbnormalAck)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxAbnormalReportAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxAbnormalReport)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 7
        '
        'cmdGxAbnormalAck
        '
        Me.cmdGxAbnormalAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdGxAbnormalAck.Location = New System.Drawing.Point(3, 4)
        Me.cmdGxAbnormalAck.Name = "cmdGxAbnormalAck"
        Me.cmdGxAbnormalAck.Size = New System.Drawing.Size(133, 43)
        Me.cmdGxAbnormalAck.TabIndex = 0
        Me.cmdGxAbnormalAck.Text = "Glass Abnormal Ack"
        Me.cmdGxAbnormalAck.UseVisualStyleBackColor = True
        '
        'lblSignalGxAbnormalReportAck
        '
        Me.lblSignalGxAbnormalReportAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxAbnormalReportAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxAbnormalReportAck.Location = New System.Drawing.Point(587, 52)
        Me.lblSignalGxAbnormalReportAck.Name = "lblSignalGxAbnormalReportAck"
        Me.lblSignalGxAbnormalReportAck.Size = New System.Drawing.Size(133, 43)
        Me.lblSignalGxAbnormalReportAck.TabIndex = 2
        Me.lblSignalGxAbnormalReportAck.Text = "Glass Abnormal Report Ack"
        Me.lblSignalGxAbnormalReportAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWGxPosition)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblWVCRGxID)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblWSourceGxID)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblWAbnormalCase)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWGxPosition
        '
        Me.lblWGxPosition.BackColor = System.Drawing.Color.White
        Me.lblWGxPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWGxPosition.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWGxPosition.Location = New System.Drawing.Point(258, 91)
        Me.lblWGxPosition.Name = "lblWGxPosition"
        Me.lblWGxPosition.Size = New System.Drawing.Size(187, 23)
        Me.lblWGxPosition.TabIndex = 7
        Me.lblWGxPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 23)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Glass Position[1W]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWVCRGxID
        '
        Me.lblWVCRGxID.BackColor = System.Drawing.Color.White
        Me.lblWVCRGxID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWVCRGxID.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWVCRGxID.Location = New System.Drawing.Point(258, 68)
        Me.lblWVCRGxID.Name = "lblWVCRGxID"
        Me.lblWVCRGxID.Size = New System.Drawing.Size(187, 23)
        Me.lblWVCRGxID.TabIndex = 5
        Me.lblWVCRGxID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 23)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "VCR Glass ID[12A]"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWAbnormalCase
        '
        Me.lblWAbnormalCase.BackColor = System.Drawing.Color.White
        Me.lblWAbnormalCase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWAbnormalCase.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWAbnormalCase.Location = New System.Drawing.Point(258, 21)
        Me.lblWAbnormalCase.Name = "lblWAbnormalCase"
        Me.lblWAbnormalCase.Size = New System.Drawing.Size(187, 23)
        Me.lblWAbnormalCase.TabIndex = 1
        Me.lblWAbnormalCase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GxAbnormal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "GxAbnormal"
        Me.Size = New System.Drawing.Size(738, 503)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblWSourceGxID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblSignalGxAbnormalReport As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdGxAbnormalAck As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWAbnormalCase As System.Windows.Forms.Label
    Friend WithEvents lblWGxPosition As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblWVCRGxID As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSignalGxAbnormalReportAck As System.Windows.Forms.Label

End Class
