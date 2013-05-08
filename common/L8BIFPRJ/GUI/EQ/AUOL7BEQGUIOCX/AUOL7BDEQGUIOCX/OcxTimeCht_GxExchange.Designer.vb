<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxTimeCht_GxExchange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OcxTimeCht_GxExchange))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.shpEQHandoff = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.shpRSTExComp = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.shpRSTRBTPutBusy = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.shpRSTTBTGetBusy = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.shpEQExReq = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.shpRSTTTReq = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.shpEQReady = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.TabControl1.SuspendLayout()
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
        Me.tabEQ2.Size = New System.Drawing.Size(318, 0)
        Me.tabEQ2.TabIndex = 1
        Me.tabEQ2.Text = "EQ2"
        Me.tabEQ2.UseVisualStyleBackColor = True
        '
        'tabEQ3
        '
        Me.tabEQ3.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ3.Name = "tabEQ3"
        Me.tabEQ3.Size = New System.Drawing.Size(318, 0)
        Me.tabEQ3.TabIndex = 2
        Me.tabEQ3.Text = "EQ3"
        Me.tabEQ3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(53, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(658, 463)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'shpEQHandoff
        '
        Me.shpEQHandoff.BackColor = System.Drawing.Color.White
        Me.shpEQHandoff.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpEQHandoff.Location = New System.Drawing.Point(30, 453)
        Me.shpEQHandoff.Name = "shpEQHandoff"
        Me.shpEQHandoff.Size = New System.Drawing.Size(20, 20)
        '
        'shpRSTExComp
        '
        Me.shpRSTExComp.BackColor = System.Drawing.Color.White
        Me.shpRSTExComp.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpRSTExComp.Location = New System.Drawing.Point(30, 405)
        Me.shpRSTExComp.Name = "shpRSTExComp"
        Me.shpRSTExComp.Size = New System.Drawing.Size(20, 20)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.shpRSTRBTPutBusy, Me.shpRSTTBTGetBusy, Me.shpEQExReq, Me.shpRSTTTReq, Me.shpEQReady, Me.shpRSTExComp, Me.shpEQHandoff})
        Me.ShapeContainer1.Size = New System.Drawing.Size(730, 500)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        'shpRSTRBTPutBusy
        '
        Me.shpRSTRBTPutBusy.BackColor = System.Drawing.Color.White
        Me.shpRSTRBTPutBusy.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpRSTRBTPutBusy.Location = New System.Drawing.Point(30, 357)
        Me.shpRSTRBTPutBusy.Name = "shpRSTRBTPutBusy"
        Me.shpRSTRBTPutBusy.Size = New System.Drawing.Size(20, 20)
        '
        'shpRSTTBTGetBusy
        '
        Me.shpRSTTBTGetBusy.BackColor = System.Drawing.Color.White
        Me.shpRSTTBTGetBusy.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpRSTTBTGetBusy.Location = New System.Drawing.Point(30, 311)
        Me.shpRSTTBTGetBusy.Name = "shpRSTTBTGetBusy"
        Me.shpRSTTBTGetBusy.Size = New System.Drawing.Size(20, 20)
        '
        'shpEQExReq
        '
        Me.shpEQExReq.BackColor = System.Drawing.Color.White
        Me.shpEQExReq.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpEQExReq.Location = New System.Drawing.Point(30, 117)
        Me.shpEQExReq.Name = "shpEQExReq"
        Me.shpEQExReq.Size = New System.Drawing.Size(20, 20)
        '
        'shpRSTTTReq
        '
        Me.shpRSTTTReq.BackColor = System.Drawing.Color.White
        Me.shpRSTTTReq.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpRSTTTReq.Location = New System.Drawing.Point(30, 215)
        Me.shpRSTTTReq.Name = "shpRSTTTReq"
        Me.shpRSTTTReq.Size = New System.Drawing.Size(20, 20)
        '
        'shpEQReady
        '
        Me.shpEQReady.BackColor = System.Drawing.Color.White
        Me.shpEQReady.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.shpEQReady.Location = New System.Drawing.Point(30, 263)
        Me.shpEQReady.Name = "shpEQReady"
        Me.shpEQReady.Size = New System.Drawing.Size(20, 20)
        '
        'OcxTimeCht_GxExchange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "OcxTimeCht_GxExchange"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.TabControl1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents shpEQHandoff As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents shpRSTExComp As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents shpRSTRBTPutBusy As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents shpRSTTBTGetBusy As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents shpEQExReq As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents shpRSTTTReq As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents shpEQReady As Microsoft.VisualBasic.PowerPacks.OvalShape

End Class
