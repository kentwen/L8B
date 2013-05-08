<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogHostMessageHistory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ListViewMsgHistory = New System.Windows.Forms.ListView
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListViewMsgHistory
        '
        Me.ListViewMsgHistory.CheckBoxes = True
        Me.ListViewMsgHistory.Location = New System.Drawing.Point(1, 1)
        Me.ListViewMsgHistory.Name = "ListViewMsgHistory"
        Me.ListViewMsgHistory.Size = New System.Drawing.Size(629, 459)
        Me.ListViewMsgHistory.TabIndex = 6
        Me.ListViewMsgHistory.UseCompatibleStateImageBehavior = False
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(636, 437)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 5
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'DialogHostMessageHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 468)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListViewMsgHistory)
        Me.Controls.Add(Me.ButtonClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogHostMessageHistory"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Host Message History"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListViewMsgHistory As System.Windows.Forms.ListView
    Friend WithEvents ButtonClose As System.Windows.Forms.Button

End Class
