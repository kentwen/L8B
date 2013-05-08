<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogMessage
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogMessage))
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.ButtonBuzzerOff = New System.Windows.Forms.Button
        Me.TimerCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.LabelMessage = New System.Windows.Forms.Label
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.OK_Button, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonBuzzerOff, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(183, 209)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(242, 42)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(82, 5)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(72, 32)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(164, 5)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(72, 32)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'ButtonBuzzerOff
        '
        Me.ButtonBuzzerOff.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonBuzzerOff.Location = New System.Drawing.Point(3, 5)
        Me.ButtonBuzzerOff.Name = "ButtonBuzzerOff"
        Me.ButtonBuzzerOff.Size = New System.Drawing.Size(72, 32)
        Me.ButtonBuzzerOff.TabIndex = 3
        Me.ButtonBuzzerOff.Text = "Buzzer Off"
        Me.ButtonBuzzerOff.UseVisualStyleBackColor = True
        Me.ButtonBuzzerOff.Visible = False
        '
        'TimerCountDown
        '
        '
        'LabelMessage
        '
        Me.LabelMessage.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMessage.Location = New System.Drawing.Point(14, 26)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(411, 161)
        Me.LabelMessage.TabIndex = 4
        Me.LabelMessage.Text = "Put Message here"
        Me.LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox
        '
        Me.PictureBox.ErrorImage = CType(resources.GetObject("PictureBox.ErrorImage"), System.Drawing.Image)
        Me.PictureBox.Image = CType(resources.GetObject("PictureBox.Image"), System.Drawing.Image)
        Me.PictureBox.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox.TabIndex = 5
        Me.PictureBox.TabStop = False
        '
        'DialogMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 263)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.LabelMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogMessage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "L8B SA Message"
        Me.TopMost = True
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ButtonBuzzerOff As System.Windows.Forms.Button
    Friend WithEvents TimerCountDown As System.Windows.Forms.Timer
    Friend WithEvents LabelMessage As System.Windows.Forms.Label
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox

End Class
