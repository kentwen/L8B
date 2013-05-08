<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.CheckBoxGotoLast = New System.Windows.Forms.CheckBox
        Me.CheckBoxStopShowLog = New System.Windows.Forms.CheckBox
        Me.cmdSaveLog = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdLogClear = New System.Windows.Forms.Button
        Me.LogTimer = New System.Windows.Forms.Timer(Me.components)
        Me.optFilledS = New System.Windows.Forms.RadioButton
        Me.optFilledC = New System.Windows.Forms.RadioButton
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lstGlobal = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.NumericUpDownMaxLog = New System.Windows.Forms.NumericUpDown
        Me.GroupBox2.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDownMaxLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBoxGotoLast
        '
        Me.CheckBoxGotoLast.AutoSize = True
        Me.CheckBoxGotoLast.Location = New System.Drawing.Point(298, 507)
        Me.CheckBoxGotoLast.Name = "CheckBoxGotoLast"
        Me.CheckBoxGotoLast.Size = New System.Drawing.Size(127, 16)
        Me.CheckBoxGotoLast.TabIndex = 31
        Me.CheckBoxGotoLast.Text = "Goto the Newest  Line"
        Me.CheckBoxGotoLast.UseVisualStyleBackColor = True
        '
        'CheckBoxStopShowLog
        '
        Me.CheckBoxStopShowLog.AutoSize = True
        Me.CheckBoxStopShowLog.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.CheckBoxStopShowLog.Location = New System.Drawing.Point(6, 25)
        Me.CheckBoxStopShowLog.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.CheckBoxStopShowLog.Name = "CheckBoxStopShowLog"
        Me.CheckBoxStopShowLog.Size = New System.Drawing.Size(96, 16)
        Me.CheckBoxStopShowLog.TabIndex = 9
        Me.CheckBoxStopShowLog.Text = "Stop Show Log"
        Me.CheckBoxStopShowLog.UseVisualStyleBackColor = True
        '
        'cmdSaveLog
        '
        Me.cmdSaveLog.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.cmdSaveLog.Location = New System.Drawing.Point(764, 495)
        Me.cmdSaveLog.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmdSaveLog.Name = "cmdSaveLog"
        Me.cmdSaveLog.Size = New System.Drawing.Size(86, 39)
        Me.cmdSaveLog.TabIndex = 29
        Me.cmdSaveLog.Text = "Log Save"
        Me.cmdSaveLog.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxStopShowLog)
        Me.GroupBox2.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(173, 482)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(279, 52)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Other Setting"
        '
        'cmdLogClear
        '
        Me.cmdLogClear.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.cmdLogClear.Location = New System.Drawing.Point(866, 495)
        Me.cmdLogClear.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmdLogClear.Name = "cmdLogClear"
        Me.cmdLogClear.Size = New System.Drawing.Size(86, 39)
        Me.cmdLogClear.TabIndex = 28
        Me.cmdLogClear.Text = "Log Clear"
        Me.cmdLogClear.UseVisualStyleBackColor = True
        '
        'LogTimer
        '
        Me.LogTimer.Enabled = True
        '
        'optFilledS
        '
        Me.optFilledS.AutoSize = True
        Me.optFilledS.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.optFilledS.Location = New System.Drawing.Point(74, 24)
        Me.optFilledS.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.optFilledS.Name = "optFilledS"
        Me.optFilledS.Size = New System.Drawing.Size(88, 16)
        Me.optFilledS.TabIndex = 5
        Me.optFilledS.Text = "Stop write log"
        Me.optFilledS.UseVisualStyleBackColor = True
        '
        'optFilledC
        '
        Me.optFilledC.AutoSize = True
        Me.optFilledC.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.optFilledC.Location = New System.Drawing.Point(2, 24)
        Me.optFilledC.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.optFilledC.Name = "optFilledC"
        Me.optFilledC.Size = New System.Drawing.Size(66, 16)
        Me.optFilledC.TabIndex = 4
        Me.optFilledC.Text = "Clear log"
        Me.optFilledC.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.TabControl.Location = New System.Drawing.Point(-1, 2)
        Me.TabControl.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(957, 481)
        Me.TabControl.TabIndex = 30
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstGlobal)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TabPage1.Size = New System.Drawing.Size(949, 455)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Grobal"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lstGlobal
        '
        Me.lstGlobal.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGlobal.FormattingEnabled = True
        Me.lstGlobal.HorizontalScrollbar = True
        Me.lstGlobal.ItemHeight = 15
        Me.lstGlobal.Location = New System.Drawing.Point(0, 0)
        Me.lstGlobal.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.lstGlobal.Name = "lstGlobal"
        Me.lstGlobal.Size = New System.Drawing.Size(945, 454)
        Me.lstGlobal.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optFilledS)
        Me.GroupBox1.Controls.Add(Me.optFilledC)
        Me.GroupBox1.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 482)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(168, 52)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "When log filled"
        '
        'NumericUpDownMaxLog
        '
        Me.NumericUpDownMaxLog.Increment = New Decimal(New Integer() {200, 0, 0, 0})
        Me.NumericUpDownMaxLog.Location = New System.Drawing.Point(517, 500)
        Me.NumericUpDownMaxLog.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.NumericUpDownMaxLog.Minimum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDownMaxLog.Name = "NumericUpDownMaxLog"
        Me.NumericUpDownMaxLog.Size = New System.Drawing.Size(63, 22)
        Me.NumericUpDownMaxLog.TabIndex = 32
        Me.NumericUpDownMaxLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownMaxLog.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'FormMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(954, 537)
        Me.Controls.Add(Me.NumericUpDownMaxLog)
        Me.Controls.Add(Me.CheckBoxGotoLast)
        Me.Controls.Add(Me.cmdSaveLog)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdLogClear)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "FormMain"
        Me.Text = "Log V2.1 (Rainbow Tech.  2010/07)"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDownMaxLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBoxGotoLast As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxStopShowLog As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSaveLog As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLogClear As System.Windows.Forms.Button
    Friend WithEvents optFilledS As System.Windows.Forms.RadioButton
    Friend WithEvents optFilledC As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lstGlobal As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents LogTimer As System.Windows.Forms.Timer
    Friend WithEvents NumericUpDownMaxLog As System.Windows.Forms.NumericUpDown
End Class
