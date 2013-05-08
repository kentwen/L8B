<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeChart_Link
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeChart_Link))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.B0181 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.B1300 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.B1301 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.B0180 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(53, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(627, 215)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'B0181
        '
        Me.B0181.BackColor = System.Drawing.Color.White
        Me.B0181.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B0181.Location = New System.Drawing.Point(31, 153)
        Me.B0181.Name = "B0181"
        Me.B0181.Size = New System.Drawing.Size(20, 19)
        '
        'B1300
        '
        Me.B1300.BackColor = System.Drawing.Color.White
        Me.B1300.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B1300.Location = New System.Drawing.Point(31, 110)
        Me.B1300.Name = "B1300"
        Me.B1300.Size = New System.Drawing.Size(20, 19)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.B1301, Me.B0180, Me.B1300, Me.B0181})
        Me.ShapeContainer1.Size = New System.Drawing.Size(693, 261)
        Me.ShapeContainer1.TabIndex = 35
        Me.ShapeContainer1.TabStop = False
        '
        'B1301
        '
        Me.B1301.BackColor = System.Drawing.Color.White
        Me.B1301.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B1301.Location = New System.Drawing.Point(31, 197)
        Me.B1301.Name = "B1301"
        Me.B1301.Size = New System.Drawing.Size(20, 19)
        '
        'B0180
        '
        Me.B0180.BackColor = System.Drawing.Color.White
        Me.B0180.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.B0180.Location = New System.Drawing.Point(31, 71)
        Me.B0180.Name = "RectangleShape2"
        Me.B0180.Size = New System.Drawing.Size(20, 19)
        '
        'TimeChart_Link
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "TimeChart_Link"
        Me.Size = New System.Drawing.Size(693, 261)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents B0181 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents B1300 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents B1301 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents B0180 As Microsoft.VisualBasic.PowerPacks.RectangleShape

End Class
