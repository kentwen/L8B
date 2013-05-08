<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeChart_GxSlotUnmatch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeChart_GxSlotUnmatch))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.B13BB = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.B01D3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(53, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(627, 174)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'B13BB
        '
        Me.B13BB.BackColor = System.Drawing.Color.White
        Me.B13BB.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B13BB.Location = New System.Drawing.Point(31, 112)
        Me.B13BB.Name = "B13BB"
        Me.B13BB.Size = New System.Drawing.Size(20, 19)
        '
        'B01D3
        '
        Me.B01D3.BackColor = System.Drawing.Color.White
        Me.B01D3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B01D3.Location = New System.Drawing.Point(31, 155)
        Me.B01D3.Name = "B01D3"
        Me.B01D3.Size = New System.Drawing.Size(20, 19)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.B01D3, Me.B13BB})
        Me.ShapeContainer1.Size = New System.Drawing.Size(693, 217)
        Me.ShapeContainer1.TabIndex = 25
        Me.ShapeContainer1.TabStop = False
        '
        'TimeChart_GxSlotUnmatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "TimeChart_GxSlotUnmatch"
        Me.Size = New System.Drawing.Size(693, 217)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents B13BB As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents B01D3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer

End Class
