<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogAlarmInfo
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxRemark = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxMessage = New System.Windows.Forms.TextBox
        Me.LabelType = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LabelOccurreTime = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LabelCode = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LabelSource = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TimerClose = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 370)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 226)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 12)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Remark"
        '
        'TextBoxRemark
        '
        Me.TextBoxRemark.Enabled = False
        Me.TextBoxRemark.Location = New System.Drawing.Point(56, 224)
        Me.TextBoxRemark.Multiline = True
        Me.TextBoxRemark.Name = "TextBoxRemark"
        Me.TextBoxRemark.Size = New System.Drawing.Size(364, 140)
        Me.TextBoxRemark.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Message"
        '
        'TextBoxMessage
        '
        Me.TextBoxMessage.Enabled = False
        Me.TextBoxMessage.Location = New System.Drawing.Point(56, 116)
        Me.TextBoxMessage.Multiline = True
        Me.TextBoxMessage.Name = "TextBoxMessage"
        Me.TextBoxMessage.Size = New System.Drawing.Size(364, 87)
        Me.TextBoxMessage.TabIndex = 21
        '
        'LabelType
        '
        Me.LabelType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelType.Location = New System.Drawing.Point(45, 57)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(76, 15)
        Me.LabelType.TabIndex = 20
        Me.LabelType.Text = "Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Type"
        '
        'LabelOccurreTime
        '
        Me.LabelOccurreTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelOccurreTime.Location = New System.Drawing.Point(71, 86)
        Me.LabelOccurreTime.Name = "LabelOccurreTime"
        Me.LabelOccurreTime.Size = New System.Drawing.Size(142, 14)
        Me.LabelOccurreTime.TabIndex = 18
        Me.LabelOccurreTime.Text = "Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 12)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Occurr Time"
        '
        'LabelCode
        '
        Me.LabelCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCode.Location = New System.Drawing.Point(45, 30)
        Me.LabelCode.Name = "LabelCode"
        Me.LabelCode.Size = New System.Drawing.Size(76, 15)
        Me.LabelCode.TabIndex = 16
        Me.LabelCode.Text = "Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Code"
        '
        'LabelSource
        '
        Me.LabelSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSource.Location = New System.Drawing.Point(45, 4)
        Me.LabelSource.Name = "LabelSource"
        Me.LabelSource.Size = New System.Drawing.Size(76, 15)
        Me.LabelSource.TabIndex = 14
        Me.LabelSource.Text = "Source"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Source"
        '
        'TimerClose
        '
        Me.TimerClose.Enabled = True
        Me.TimerClose.Interval = 1000
        '
        'DialogAlarmInfo
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 408)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxRemark)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxMessage)
        Me.Controls.Add(Me.LabelType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LabelOccurreTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelSource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogAlarmInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Alarm Info"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMessage As System.Windows.Forms.TextBox
    Friend WithEvents LabelType As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabelOccurreTime As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelCode As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelSource As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TimerClose As System.Windows.Forms.Timer

End Class
