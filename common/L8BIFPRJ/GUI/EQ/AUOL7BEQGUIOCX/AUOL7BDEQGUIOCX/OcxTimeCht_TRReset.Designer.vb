<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxTimeCht_TRReset
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OcxTimeCht_TRReset))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.shpTRResetAck = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.shpTRResetReq = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.tabEQ1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabEQ1)
        Me.TabControl1.Controls.Add(Me.tabEQ2)
        Me.TabControl1.Controls.Add(Me.tabEQ3)
        Me.TabControl1.Location = New System.Drawing.Point(53, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 11
        '
        'tabEQ1
        '
        Me.tabEQ1.Controls.Add(Me.Label1)
        Me.tabEQ1.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ1.Name = "tabEQ1"
        Me.tabEQ1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEQ1.Size = New System.Drawing.Size(318, 0)
        Me.tabEQ1.TabIndex = 0
        Me.tabEQ1.Text = "EQ1"
        Me.tabEQ1.UseVisualStyleBackColor = True
        '
        'tabEQ2
        '
        Me.tabEQ2.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ2.Name = "tabEQ2"
        Me.tabEQ2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEQ2.Size = New System.Drawing.Size(142, 0)
        Me.tabEQ2.TabIndex = 1
        Me.tabEQ2.Text = "EQ2"
        Me.tabEQ2.UseVisualStyleBackColor = True
        '
        'tabEQ3
        '
        Me.tabEQ3.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ3.Name = "tabEQ3"
        Me.tabEQ3.Size = New System.Drawing.Size(142, 0)
        Me.tabEQ3.TabIndex = 2
        Me.tabEQ3.Text = "EQ3"
        Me.tabEQ3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(53, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(660, 151)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.shpTRResetAck, Me.shpTRResetReq})
        Me.ShapeContainer1.Size = New System.Drawing.Size(730, 500)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        'shpTRResetAck
        '
        Me.shpTRResetAck.BackColor = System.Drawing.Color.White
        Me.shpTRResetAck.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpTRResetAck.Location = New System.Drawing.Point(30, 119)
        Me.shpTRResetAck.Name = "shpTRResetAck"
        Me.shpTRResetAck.Size = New System.Drawing.Size(20, 20)
        '
        'shpTRResetReq
        '
        Me.shpTRResetReq.BackColor = System.Drawing.Color.White
        Me.shpTRResetReq.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpTRResetReq.Location = New System.Drawing.Point(30, 71)
        Me.shpTRResetReq.Name = "shpTRResetReq"
        Me.shpTRResetReq.Size = New System.Drawing.Size(20, 20)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'OcxTimeCht_TRReset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "OcxTimeCht_TRReset"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.TabControl1.ResumeLayout(False)
        Me.tabEQ1.ResumeLayout(False)
        Me.tabEQ1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents shpTRResetAck As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents shpTRResetReq As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
