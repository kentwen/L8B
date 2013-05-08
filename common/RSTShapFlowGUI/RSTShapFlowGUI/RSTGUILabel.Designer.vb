<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSTGUILabel
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
        Me.components = New System.ComponentModel.Container
        Me.tmrNow = New System.Windows.Forms.Timer(Me.components)
        Me.cmdFrameInter = New System.Windows.Forms.Button
        Me.cmdOuterframe = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'tmrNow
        '
        '
        'cmdFrameInter
        '
        Me.cmdFrameInter.Location = New System.Drawing.Point(18, 13)
        Me.cmdFrameInter.Name = "cmdFrameInter"
        Me.cmdFrameInter.Size = New System.Drawing.Size(140, 46)
        Me.cmdFrameInter.TabIndex = 3
        Me.cmdFrameInter.UseVisualStyleBackColor = True
        '
        'cmdOuterframe
        '
        Me.cmdOuterframe.Location = New System.Drawing.Point(3, 3)
        Me.cmdOuterframe.Name = "cmdOuterframe"
        Me.cmdOuterframe.Size = New System.Drawing.Size(171, 66)
        Me.cmdOuterframe.TabIndex = 4
        Me.cmdOuterframe.UseVisualStyleBackColor = True
        '
        'RSTGUILabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdFrameInter)
        Me.Controls.Add(Me.cmdOuterframe)
        Me.Name = "RSTGUILabel"
        Me.Size = New System.Drawing.Size(201, 95)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrNow As System.Windows.Forms.Timer
    Friend WithEvents cmdFrameInter As System.Windows.Forms.Button
    Friend WithEvents cmdOuterframe As System.Windows.Forms.Button

End Class
