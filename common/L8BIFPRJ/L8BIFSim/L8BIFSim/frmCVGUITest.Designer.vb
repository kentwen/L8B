<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCVGUITest
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
        Me.CtlCVGUIMain1 = New L8BIFPRJ.ctlCVGUIMain
        Me.SuspendLayout()
        '
        'CtlCVGUIMain1
        '
        Me.CtlCVGUIMain1.ENGMode = False
        Me.CtlCVGUIMain1.Location = New System.Drawing.Point(2, 1)
        Me.CtlCVGUIMain1.Name = "CtlCVGUIMain1"
        Me.CtlCVGUIMain1.Size = New System.Drawing.Size(990, 790)
        Me.CtlCVGUIMain1.TabIndex = 0
        '
        'frmCVGUITest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 766)
        Me.Controls.Add(Me.CtlCVGUIMain1)
        Me.Name = "frmCVGUITest"
        Me.Text = "frmCVGUITest"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlCVGUIMain1 As L8BIFPRJ.ctlCVGUIMain
End Class
