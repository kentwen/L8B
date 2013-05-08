<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSTGUICtrlCV2L
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
        Me.lblGlassQuantity = New System.Windows.Forms.Label
        Me.lblPortIndex = New System.Windows.Forms.Label
        Me.lblCVStatus = New System.Windows.Forms.Label
        Me.lblLUTip = New System.Windows.Forms.Label
        Me.lblRunningMode = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblProductCode = New System.Windows.Forms.Label
        Me.lblRecipeID = New System.Windows.Forms.Label
        Me.lblCSTID = New System.Windows.Forms.Label
        Me.picWireCST = New System.Windows.Forms.PictureBox
        Me.lblPortEnableStatus = New System.Windows.Forms.Label
        Me.chkDummyCanecl = New System.Windows.Forms.CheckBox
        Me.lblConveyorIndex = New System.Windows.Forms.Label
        Me.picParent = New System.Windows.Forms.PictureBox
        Me.picContainer = New System.Windows.Forms.PictureBox
        Me.lblLineID = New System.Windows.Forms.Label
        CType(Me.picWireCST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picParent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGlassQuantity
        '
        Me.lblGlassQuantity.AutoSize = True
        Me.lblGlassQuantity.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblGlassQuantity.Location = New System.Drawing.Point(61, 53)
        Me.lblGlassQuantity.Name = "lblGlassQuantity"
        Me.lblGlassQuantity.Size = New System.Drawing.Size(17, 16)
        Me.lblGlassQuantity.TabIndex = 34
        Me.lblGlassQuantity.Text = "0"
        '
        'lblPortIndex
        '
        Me.lblPortIndex.AutoSize = True
        Me.lblPortIndex.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPortIndex.Location = New System.Drawing.Point(126, 67)
        Me.lblPortIndex.Name = "lblPortIndex"
        Me.lblPortIndex.Size = New System.Drawing.Size(42, 13)
        Me.lblPortIndex.TabIndex = 32
        Me.lblPortIndex.Text = "Port #"
        '
        'lblCVStatus
        '
        Me.lblCVStatus.BackColor = System.Drawing.Color.White
        Me.lblCVStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCVStatus.Location = New System.Drawing.Point(19, 219)
        Me.lblCVStatus.Name = "lblCVStatus"
        Me.lblCVStatus.Size = New System.Drawing.Size(177, 21)
        Me.lblCVStatus.TabIndex = 31
        Me.lblCVStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLUTip
        '
        Me.lblLUTip.AutoSize = True
        Me.lblLUTip.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblLUTip.ForeColor = System.Drawing.Color.Green
        Me.lblLUTip.Location = New System.Drawing.Point(19, 200)
        Me.lblLUTip.Name = "lblLUTip"
        Me.lblLUTip.Size = New System.Drawing.Size(87, 16)
        Me.lblLUTip.TabIndex = 30
        Me.lblLUTip.Text = "Loader OK"
        '
        'lblRunningMode
        '
        Me.lblRunningMode.BackColor = System.Drawing.Color.White
        Me.lblRunningMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRunningMode.Location = New System.Drawing.Point(43, 177)
        Me.lblRunningMode.Name = "lblRunningMode"
        Me.lblRunningMode.Size = New System.Drawing.Size(153, 20)
        Me.lblRunningMode.TabIndex = 29
        Me.lblRunningMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 12)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "CST"
        '
        'lblProductCode
        '
        Me.lblProductCode.BackColor = System.Drawing.Color.White
        Me.lblProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductCode.Location = New System.Drawing.Point(19, 139)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(177, 20)
        Me.lblProductCode.TabIndex = 27
        Me.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecipeID
        '
        Me.lblRecipeID.BackColor = System.Drawing.Color.White
        Me.lblRecipeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecipeID.Location = New System.Drawing.Point(19, 120)
        Me.lblRecipeID.Name = "lblRecipeID"
        Me.lblRecipeID.Size = New System.Drawing.Size(177, 20)
        Me.lblRecipeID.TabIndex = 26
        Me.lblRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCSTID
        '
        Me.lblCSTID.BackColor = System.Drawing.Color.White
        Me.lblCSTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCSTID.Location = New System.Drawing.Point(19, 101)
        Me.lblCSTID.Name = "lblCSTID"
        Me.lblCSTID.Size = New System.Drawing.Size(177, 20)
        Me.lblCSTID.TabIndex = 25
        Me.lblCSTID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picWireCST
        '
        Me.picWireCST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picWireCST.Location = New System.Drawing.Point(19, 29)
        Me.picWireCST.Name = "picWireCST"
        Me.picWireCST.Size = New System.Drawing.Size(100, 69)
        Me.picWireCST.TabIndex = 24
        Me.picWireCST.TabStop = False
        '
        'lblPortEnableStatus
        '
        Me.lblPortEnableStatus.AutoSize = True
        Me.lblPortEnableStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPortEnableStatus.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPortEnableStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblPortEnableStatus.Location = New System.Drawing.Point(144, 41)
        Me.lblPortEnableStatus.Name = "lblPortEnableStatus"
        Me.lblPortEnableStatus.Size = New System.Drawing.Size(15, 14)
        Me.lblPortEnableStatus.TabIndex = 22
        Me.lblPortEnableStatus.Text = "E"
        '
        'chkDummyCanecl
        '
        Me.chkDummyCanecl.AutoSize = True
        Me.chkDummyCanecl.Location = New System.Drawing.Point(105, 6)
        Me.chkDummyCanecl.Name = "chkDummyCanecl"
        Me.chkDummyCanecl.Size = New System.Drawing.Size(97, 16)
        Me.chkDummyCanecl.TabIndex = 19
        Me.chkDummyCanecl.Text = "Dummy Cancel"
        Me.chkDummyCanecl.UseVisualStyleBackColor = True
        '
        'lblConveyorIndex
        '
        Me.lblConveyorIndex.AutoSize = True
        Me.lblConveyorIndex.Location = New System.Drawing.Point(7, 7)
        Me.lblConveyorIndex.Name = "lblConveyorIndex"
        Me.lblConveyorIndex.Size = New System.Drawing.Size(55, 12)
        Me.lblConveyorIndex.TabIndex = 18
        Me.lblConveyorIndex.Text = "Conveyor "
        '
        'picParent
        '
        Me.picParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picParent.Location = New System.Drawing.Point(11, 24)
        Me.picParent.Name = "picParent"
        Me.picParent.Size = New System.Drawing.Size(195, 220)
        Me.picParent.TabIndex = 20
        Me.picParent.TabStop = False
        '
        'picContainer
        '
        Me.picContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picContainer.Location = New System.Drawing.Point(2, 3)
        Me.picContainer.Name = "picContainer"
        Me.picContainer.Size = New System.Drawing.Size(210, 246)
        Me.picContainer.TabIndex = 35
        Me.picContainer.TabStop = False
        '
        'lblLineID
        '
        Me.lblLineID.BackColor = System.Drawing.Color.White
        Me.lblLineID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLineID.Location = New System.Drawing.Point(19, 158)
        Me.lblLineID.Name = "lblLineID"
        Me.lblLineID.Size = New System.Drawing.Size(177, 20)
        Me.lblLineID.TabIndex = 36
        Me.lblLineID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLineID.Visible = False
        '
        'RSTGUICtrlCV2L
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblLineID)
        Me.Controls.Add(Me.lblGlassQuantity)
        Me.Controls.Add(Me.lblPortIndex)
        Me.Controls.Add(Me.lblCVStatus)
        Me.Controls.Add(Me.lblLUTip)
        Me.Controls.Add(Me.lblRunningMode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblProductCode)
        Me.Controls.Add(Me.lblRecipeID)
        Me.Controls.Add(Me.lblCSTID)
        Me.Controls.Add(Me.picWireCST)
        Me.Controls.Add(Me.lblPortEnableStatus)
        Me.Controls.Add(Me.chkDummyCanecl)
        Me.Controls.Add(Me.lblConveyorIndex)
        Me.Controls.Add(Me.picParent)
        Me.Controls.Add(Me.picContainer)
        Me.Name = "RSTGUICtrlCV2L"
        Me.Size = New System.Drawing.Size(214, 251)
        CType(Me.picWireCST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picParent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGlassQuantity As System.Windows.Forms.Label
    Friend WithEvents lblPortIndex As System.Windows.Forms.Label
    Friend WithEvents lblCVStatus As System.Windows.Forms.Label
    Friend WithEvents lblLUTip As System.Windows.Forms.Label
    Friend WithEvents lblRunningMode As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents lblRecipeID As System.Windows.Forms.Label
    Friend WithEvents lblCSTID As System.Windows.Forms.Label
    Friend WithEvents picWireCST As System.Windows.Forms.PictureBox
    Friend WithEvents lblPortEnableStatus As System.Windows.Forms.Label
    Friend WithEvents chkDummyCanecl As System.Windows.Forms.CheckBox
    Friend WithEvents lblConveyorIndex As System.Windows.Forms.Label
    Friend WithEvents picParent As System.Windows.Forms.PictureBox
    Friend WithEvents picContainer As System.Windows.Forms.PictureBox
    Friend WithEvents lblLineID As System.Windows.Forms.Label

End Class
