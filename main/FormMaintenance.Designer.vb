<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMaintenance
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
        Me.GroupBoxLogin = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxUserID = New System.Windows.Forms.TextBox
        Me.LabelPassword = New System.Windows.Forms.Label
        Me.TextBoxPassword = New System.Windows.Forms.TextBox
        Me.ButtonLogin = New System.Windows.Forms.Button
        Me.TextBoxPhoneE = New System.Windows.Forms.TextBox
        Me.TextBoxPhoneC = New System.Windows.Forms.TextBox
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.ButtonBuzzerOff = New System.Windows.Forms.Button
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.GroupBoxLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxLogin
        '
        Me.GroupBoxLogin.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxLogin.Controls.Add(Me.Label1)
        Me.GroupBoxLogin.Controls.Add(Me.TextBoxUserID)
        Me.GroupBoxLogin.Controls.Add(Me.LabelPassword)
        Me.GroupBoxLogin.Controls.Add(Me.TextBoxPassword)
        Me.GroupBoxLogin.Controls.Add(Me.ButtonLogin)
        Me.GroupBoxLogin.Location = New System.Drawing.Point(49, 21)
        Me.GroupBoxLogin.Name = "GroupBoxLogin"
        Me.GroupBoxLogin.Size = New System.Drawing.Size(315, 74)
        Me.GroupBoxLogin.TabIndex = 18
        Me.GroupBoxLogin.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 21)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "User ID"
        '
        'TextBoxUserID
        '
        Me.TextBoxUserID.Location = New System.Drawing.Point(97, 14)
        Me.TextBoxUserID.Name = "TextBoxUserID"
        Me.TextBoxUserID.Size = New System.Drawing.Size(128, 22)
        Me.TextBoxUserID.TabIndex = 0
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.BackColor = System.Drawing.Color.Transparent
        Me.LabelPassword.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelPassword.Location = New System.Drawing.Point(3, 44)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(95, 21)
        Me.LabelPassword.TabIndex = 0
        Me.LabelPassword.Text = "Password"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(97, 43)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(128, 22)
        Me.TextBoxPassword.TabIndex = 1
        '
        'ButtonLogin
        '
        Me.ButtonLogin.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonLogin.Location = New System.Drawing.Point(236, 42)
        Me.ButtonLogin.Name = "ButtonLogin"
        Me.ButtonLogin.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLogin.TabIndex = 2
        Me.ButtonLogin.Text = "Login"
        Me.ButtonLogin.UseVisualStyleBackColor = True
        '
        'TextBoxPhoneE
        '
        Me.TextBoxPhoneE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxPhoneE.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPhoneE.Location = New System.Drawing.Point(664, 573)
        Me.TextBoxPhoneE.Multiline = True
        Me.TextBoxPhoneE.Name = "TextBoxPhoneE"
        Me.TextBoxPhoneE.ReadOnly = True
        Me.TextBoxPhoneE.Size = New System.Drawing.Size(564, 51)
        Me.TextBoxPhoneE.TabIndex = 17
        Me.TextBoxPhoneE.TabStop = False
        Me.TextBoxPhoneE.Text = "!234567890"
        Me.TextBoxPhoneE.WordWrap = False
        '
        'TextBoxPhoneC
        '
        Me.TextBoxPhoneC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxPhoneC.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPhoneC.Location = New System.Drawing.Point(652, 297)
        Me.TextBoxPhoneC.Multiline = True
        Me.TextBoxPhoneC.Name = "TextBoxPhoneC"
        Me.TextBoxPhoneC.ReadOnly = True
        Me.TextBoxPhoneC.Size = New System.Drawing.Size(562, 50)
        Me.TextBoxPhoneC.TabIndex = 16
        Me.TextBoxPhoneC.TabStop = False
        Me.TextBoxPhoneC.Text = "1234567890123123123"
        Me.TextBoxPhoneC.WordWrap = False
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(1220, 29)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExit.TabIndex = 15
        Me.ButtonExit.TabStop = False
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        Me.ButtonExit.Visible = False
        '
        'ButtonBuzzerOff
        '
        Me.ButtonBuzzerOff.Location = New System.Drawing.Point(1128, 29)
        Me.ButtonBuzzerOff.Name = "ButtonBuzzerOff"
        Me.ButtonBuzzerOff.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuzzerOff.TabIndex = 14
        Me.ButtonBuzzerOff.TabStop = False
        Me.ButtonBuzzerOff.Text = "Buzzer Off"
        Me.ButtonBuzzerOff.UseVisualStyleBackColor = True
        Me.ButtonBuzzerOff.Visible = False
        '
        'ButtonSave
        '
        Me.ButtonSave.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.Location = New System.Drawing.Point(1220, 305)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(68, 31)
        Me.ButtonSave.TabIndex = 13
        Me.ButtonSave.TabStop = False
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        Me.ButtonSave.Visible = False
        '
        'FormMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.L8Bmain.My.Resources.Resources.機台維修
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1350, 752)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBoxLogin)
        Me.Controls.Add(Me.TextBoxPhoneE)
        Me.Controls.Add(Me.TextBoxPhoneC)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonBuzzerOff)
        Me.Controls.Add(Me.ButtonSave)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMaintenance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBoxLogin.ResumeLayout(False)
        Me.GroupBoxLogin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBoxLogin As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUserID As System.Windows.Forms.TextBox
    Friend WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents ButtonLogin As System.Windows.Forms.Button
    Friend WithEvents TextBoxPhoneE As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPhoneC As System.Windows.Forms.TextBox
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents ButtonBuzzerOff As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
End Class
