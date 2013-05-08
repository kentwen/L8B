<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEQGUITest
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
        Me.CtlEQGUIMain1 = New L8BIFPRJ.ctlEQGUIMain
        Me.SuspendLayout()
        '
        'CtlEQGUIMain1
        '
        Me.CtlEQGUIMain1.ENGMode = False
        Me.CtlEQGUIMain1.Location = New System.Drawing.Point(2, 3)
        Me.CtlEQGUIMain1.Name = "CtlEQGUIMain1"
        Me.CtlEQGUIMain1.Size = New System.Drawing.Size(990, 790)
        Me.CtlEQGUIMain1.TabIndex = 0
        '
        'frmEQGUITest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 766)
        Me.Controls.Add(Me.CtlEQGUIMain1)
        Me.Name = "frmEQGUITest"
        Me.Text = "frmEQGUITest"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlEQGUIMain1 As L8BIFPRJ.ctlEQGUIMain
End Class
