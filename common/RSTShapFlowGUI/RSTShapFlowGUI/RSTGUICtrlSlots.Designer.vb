<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSTGUICtrlSlots
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
        Me.components = New System.ComponentModel.Container
        Me.lblSlot = New System.Windows.Forms.Label
        Me.lblSlotIndex = New System.Windows.Forms.Label
        Me.lblBufferID = New System.Windows.Forms.Label
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'lblSlot
        '
        Me.lblSlot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSlot.Font = New System.Drawing.Font("新細明體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSlot.Location = New System.Drawing.Point(28, 14)
        Me.lblSlot.Name = "lblSlot"
        Me.lblSlot.Size = New System.Drawing.Size(174, 23)
        Me.lblSlot.TabIndex = 0
        Me.lblSlot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSlot.Visible = False
        '
        'lblSlotIndex
        '
        Me.lblSlotIndex.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblSlotIndex.AutoSize = True
        Me.lblSlotIndex.Location = New System.Drawing.Point(3, 14)
        Me.lblSlotIndex.Name = "lblSlotIndex"
        Me.lblSlotIndex.Size = New System.Drawing.Size(17, 12)
        Me.lblSlotIndex.TabIndex = 1
        Me.lblSlotIndex.Text = "##"
        Me.lblSlotIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSlotIndex.Visible = False
        '
        'lblBufferID
        '
        Me.lblBufferID.AutoSize = True
        Me.lblBufferID.Location = New System.Drawing.Point(64, 96)
        Me.lblBufferID.Name = "lblBufferID"
        Me.lblBufferID.Size = New System.Drawing.Size(51, 12)
        Me.lblBufferID.TabIndex = 2
        Me.lblBufferID.Text = "Buffer ##"
        '
        'RSTGUICtrlSlots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblBufferID)
        Me.Controls.Add(Me.lblSlotIndex)
        Me.Controls.Add(Me.lblSlot)
        Me.Name = "RSTGUICtrlSlots"
        Me.Size = New System.Drawing.Size(240, 139)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSlot As System.Windows.Forms.Label
    Friend WithEvents lblSlotIndex As System.Windows.Forms.Label
    Friend WithEvents lblBufferID As System.Windows.Forms.Label
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip

End Class
