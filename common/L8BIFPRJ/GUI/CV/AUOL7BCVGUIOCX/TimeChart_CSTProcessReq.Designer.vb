<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeChart_CSTProcessReq
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeChart_CSTProcessReq))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.B1360 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.B019F = New Microsoft.VisualBasic.PowerPacks.RectangleShape
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
        Me.PictureBox1.Size = New System.Drawing.Size(627, 168)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'B1360
        '
        Me.B1360.BackColor = System.Drawing.Color.White
        Me.B1360.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B1360.Location = New System.Drawing.Point(31, 155)
        Me.B1360.Name = "B1360"
        Me.B1360.Size = New System.Drawing.Size(20, 19)
        '
        'B019F
        '
        Me.B019F.BackColor = System.Drawing.Color.White
        Me.B019F.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B019F.Location = New System.Drawing.Point(31, 114)
        Me.B019F.Name = "B019F"
        Me.B019F.Size = New System.Drawing.Size(20, 19)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.B019F, Me.B1360})
        Me.ShapeContainer1.Size = New System.Drawing.Size(694, 212)
        Me.ShapeContainer1.TabIndex = 17
        Me.ShapeContainer1.TabStop = False
        '
        'TimeChart_CSTProcessReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "TimeChart_CSTProcessReq"
        Me.Size = New System.Drawing.Size(694, 212)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents B1360 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents B019F As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer

End Class
