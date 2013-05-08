<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.RstguiCtrlSlots1 = New RSTShapFlowGUI.RSTGUICtrlSlots
        Me.RstguiLabel1 = New RSTShapFlowGUI.RSTGUILabel
        Me.RstguiCtrlEQ1 = New RSTShapFlowGUI.RSTGUICtrlEQ
        Me.RstguiCtrlCV1 = New RSTShapFlowGUI.RSTGUICtrlCV
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(366, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(366, 126)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(366, 187)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(366, 217)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(302, 342)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(384, 343)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 9
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(502, 343)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'RstguiCtrlSlots1
        '
        Me.RstguiCtrlSlots1.BufferID = Nothing
        Me.RstguiCtrlSlots1.GxIDShow = False
        Me.RstguiCtrlSlots1.Location = New System.Drawing.Point(337, 21)
        Me.RstguiCtrlSlots1.MaxSlots = 20
        Me.RstguiCtrlSlots1.Name = "RstguiCtrlSlots1"
        Me.RstguiCtrlSlots1.SetLblFont = Nothing
        Me.RstguiCtrlSlots1.SetSlotTitle = ""
        Me.RstguiCtrlSlots1.ShowBufferID = True
        Me.RstguiCtrlSlots1.Size = New System.Drawing.Size(240, 315)
        Me.RstguiCtrlSlots1.SloIndexStep = 1
        Me.RstguiCtrlSlots1.SlotIndexBackColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots1.SlotIndexWidth = 38
        Me.RstguiCtrlSlots1.TabIndex = 11
        Me.RstguiCtrlSlots1.WithGxColor = System.Drawing.Color.Empty
        Me.RstguiCtrlSlots1.WithoutGxColor = System.Drawing.Color.Empty
        '
        'RstguiLabel1
        '
        Me.RstguiLabel1.ChangeDisplayMode = RSTShapFlowGUI.RSTGUILabel.eDisplayMode.TYPE_TEXT
        Me.RstguiLabel1.EnableTimer = True
        Me.RstguiLabel1.FontColor = System.Drawing.Color.Empty
        Me.RstguiLabel1.FontInfo = Nothing
        Me.RstguiLabel1.InterFrameColer = System.Drawing.Color.Empty
        Me.RstguiLabel1.Location = New System.Drawing.Point(277, 215)
        Me.RstguiLabel1.Name = "RstguiLabel1"
        Me.RstguiLabel1.OuterFrameColer = System.Drawing.Color.Empty
        Me.RstguiLabel1.SetCaption = Nothing
        Me.RstguiLabel1.ShowOuterFrame = True
        Me.RstguiLabel1.Size = New System.Drawing.Size(201, 95)
        Me.RstguiLabel1.TabIndex = 6
        '
        'RstguiCtrlEQ1
        '
        Me.RstguiCtrlEQ1.ConnectColor = System.Drawing.Color.Empty
        Me.RstguiCtrlEQ1.DisConnectColor = System.Drawing.Color.Empty
        Me.RstguiCtrlEQ1.EQConnect = False
        Me.RstguiCtrlEQ1.EQName = Nothing
        Me.RstguiCtrlEQ1.EQRunningMode = Nothing
        Me.RstguiCtrlEQ1.GlassID = Nothing
        Me.RstguiCtrlEQ1.Location = New System.Drawing.Point(17, 12)
        Me.RstguiCtrlEQ1.Name = "RstguiCtrlEQ1"
        Me.RstguiCtrlEQ1.SetFont = Nothing
        Me.RstguiCtrlEQ1.SetGlassColor = System.Drawing.Color.Empty
        Me.RstguiCtrlEQ1.Size = New System.Drawing.Size(127, 78)
        Me.RstguiCtrlEQ1.TabIndex = 5
        Me.RstguiCtrlEQ1.WithGlass = False
        '
        'RstguiCtrlCV1
        '
        Me.RstguiCtrlCV1.CVBackColer = System.Drawing.Color.Empty
        Me.RstguiCtrlCV1.CSTDummyCancel = False
        Me.RstguiCtrlCV1.CSTStatusCaption = Nothing
        Me.RstguiCtrlCV1.CVCaption = Nothing
        Me.RstguiCtrlCV1.CVStatusCaption = Nothing
        Me.RstguiCtrlCV1.Location = New System.Drawing.Point(140, 12)
        Me.RstguiCtrlCV1.MaxBufferSlot = 3
        Me.RstguiCtrlCV1.MaxCSTSlot = 60
        Me.RstguiCtrlCV1.Name = "RstguiCtrlCV1"
        Me.RstguiCtrlCV1.NetHCaption = Nothing
        Me.RstguiCtrlCV1.PortCaption = Nothing
        Me.RstguiCtrlCV1.PortEnableCaption = False
        Me.RstguiCtrlCV1.Size = New System.Drawing.Size(220, 316)
        Me.RstguiCtrlCV1.TabIndex = 0
        Me.RstguiCtrlCV1.TipCaption = Nothing
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 377)
        Me.Controls.Add(Me.RstguiCtrlSlots1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.RstguiLabel1)
        Me.Controls.Add(Me.RstguiCtrlEQ1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RstguiCtrlCV1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RstguiCtrlCV1 As RSTShapFlowGUI.RSTGUICtrlCV
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents RstguiCtrlEQ1 As RSTShapFlowGUI.RSTGUICtrlEQ
    Friend WithEvents RstguiLabel1 As RSTShapFlowGUI.RSTGUILabel

    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents RstguiCtrlSlots1 As RSTShapFlowGUI.RSTGUICtrlSlots




End Class
