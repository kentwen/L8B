<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCVGUIMain
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
        Me.CvguiMain1 = New CVGUIMain.CVGUIMain
        Me.SuspendLayout()
        '
        'CvguiMain1
        '
        Me.CvguiMain1.ENGMode = True
        Me.CvguiMain1.Location = New System.Drawing.Point(-3, 0)
        Me.CvguiMain1.Name = "CvguiMain1"
        Me.CvguiMain1.Size = New System.Drawing.Size(805, 610)
        Me.CvguiMain1.TabIndex = 0
        '
        'frmCVGUIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 610)
        Me.Controls.Add(Me.CvguiMain1)
        Me.Name = "frmCVGUIMain"
        Me.Text = "frmCVGUIMain"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CvguiMain1 As CVGUIMain.CVGUIMain
End Class
