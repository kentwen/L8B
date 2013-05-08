<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDate
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
        Me.LabelDate = New System.Windows.Forms.Label
        Me.Button = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LabelDate
        '
        Me.LabelDate.BackColor = System.Drawing.SystemColors.ControlText
        Me.LabelDate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.ForeColor = System.Drawing.Color.Chartreuse
        Me.LabelDate.Location = New System.Drawing.Point(9, 10)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Size = New System.Drawing.Size(141, 40)
        Me.LabelDate.TabIndex = 2
        Me.LabelDate.Text = "2000 - 01 - 01" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "12 : 00 : 00"
        Me.LabelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button
        '
        Me.Button.AutoEllipsis = True
        Me.Button.BackColor = System.Drawing.SystemColors.ControlText
        Me.Button.Location = New System.Drawing.Point(-1, 0)
        Me.Button.Name = "Button"
        Me.Button.Size = New System.Drawing.Size(160, 61)
        Me.Button.TabIndex = 3
        Me.Button.TabStop = False
        Me.Button.UseVisualStyleBackColor = False
        '
        'ucDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelDate)
        Me.Controls.Add(Me.Button)
        Me.Name = "ucDate"
        Me.Size = New System.Drawing.Size(160, 62)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelDate As System.Windows.Forms.Label
    Friend WithEvents Button As System.Windows.Forms.Button

End Class
