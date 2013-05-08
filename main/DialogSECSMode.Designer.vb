<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSECSRemoteMode
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
        Me.GroupBoxOffline = New System.Windows.Forms.GroupBox
        Me.ButtonOffline = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.ButtonOnlineMonitor = New System.Windows.Forms.Button
        Me.GroupBoxOnline = New System.Windows.Forms.GroupBox
        Me.ButtonOnlineControl = New System.Windows.Forms.Button
        Me.GroupBoxOffline.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBoxOnline.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxOffline
        '
        Me.GroupBoxOffline.Controls.Add(Me.ButtonOffline)
        Me.GroupBoxOffline.Location = New System.Drawing.Point(3, 92)
        Me.GroupBoxOffline.Name = "GroupBoxOffline"
        Me.GroupBoxOffline.Size = New System.Drawing.Size(235, 83)
        Me.GroupBoxOffline.TabIndex = 6
        Me.GroupBoxOffline.TabStop = False
        Me.GroupBoxOffline.Text = "Off Line"
        '
        'ButtonOffline
        '
        Me.ButtonOffline.Location = New System.Drawing.Point(23, 21)
        Me.ButtonOffline.Name = "ButtonOffline"
        Me.ButtonOffline.Size = New System.Drawing.Size(75, 45)
        Me.ButtonOffline.TabIndex = 1
        Me.ButtonOffline.Text = "Off line"
        Me.ButtonOffline.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(264, 148)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(74, 27)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(3, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Close"
        '
        'ButtonOnlineMonitor
        '
        Me.ButtonOnlineMonitor.Location = New System.Drawing.Point(130, 21)
        Me.ButtonOnlineMonitor.Name = "ButtonOnlineMonitor"
        Me.ButtonOnlineMonitor.Size = New System.Drawing.Size(75, 44)
        Me.ButtonOnlineMonitor.TabIndex = 1
        Me.ButtonOnlineMonitor.Text = "Monitor"
        Me.ButtonOnlineMonitor.UseVisualStyleBackColor = True
        '
        'GroupBoxOnline
        '
        Me.GroupBoxOnline.Controls.Add(Me.ButtonOnlineMonitor)
        Me.GroupBoxOnline.Controls.Add(Me.ButtonOnlineControl)
        Me.GroupBoxOnline.Location = New System.Drawing.Point(3, 5)
        Me.GroupBoxOnline.Name = "GroupBoxOnline"
        Me.GroupBoxOnline.Size = New System.Drawing.Size(235, 81)
        Me.GroupBoxOnline.TabIndex = 5
        Me.GroupBoxOnline.TabStop = False
        Me.GroupBoxOnline.Text = "On Line"
        '
        'ButtonOnlineControl
        '
        Me.ButtonOnlineControl.Location = New System.Drawing.Point(23, 21)
        Me.ButtonOnlineControl.Name = "ButtonOnlineControl"
        Me.ButtonOnlineControl.Size = New System.Drawing.Size(75, 44)
        Me.ButtonOnlineControl.TabIndex = 0
        Me.ButtonOnlineControl.Text = "Control"
        Me.ButtonOnlineControl.UseVisualStyleBackColor = True
        '
        'DialogSECSRemoteMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBoxOffline)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBoxOnline)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogSECSRemoteMode"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SECS Remote Status"
        Me.GroupBoxOffline.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBoxOnline.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxOffline As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOffline As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ButtonOnlineMonitor As System.Windows.Forms.Button
    Friend WithEvents GroupBoxOnline As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOnlineControl As System.Windows.Forms.Button

End Class
