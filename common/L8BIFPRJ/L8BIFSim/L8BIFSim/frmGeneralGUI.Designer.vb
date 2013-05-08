<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneralGUI
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
        Me.CtlGeneralGUI1 = New L8BIFPRJ.ctlGeneralGUI
        Me.SuspendLayout()
        '
        'CtlGeneralGUI1
        '
        Me.CtlGeneralGUI1.Location = New System.Drawing.Point(12, 12)
        Me.CtlGeneralGUI1.Name = "CtlGeneralGUI1"
        Me.CtlGeneralGUI1.Size = New System.Drawing.Size(947, 687)
        Me.CtlGeneralGUI1.TabIndex = 0
        '
        'frmGeneralGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 766)
        Me.Controls.Add(Me.CtlGeneralGUI1)
        Me.Name = "frmGeneralGUI"
        Me.Text = "frmGeneralGUI"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlGeneralGUI1 As L8BIFPRJ.ctlGeneralGUI
End Class
