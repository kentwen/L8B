<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSTGUICtrlCV
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
        Me.lblConveyorIndex = New System.Windows.Forms.Label
        Me.chkDummyCanecl = New System.Windows.Forms.CheckBox
        Me.picParent = New System.Windows.Forms.PictureBox
        Me.lblNetHPortIndex = New System.Windows.Forms.Label
        Me.lblPortEnableStatus = New System.Windows.Forms.Label
        Me.picWireBuffer = New System.Windows.Forms.PictureBox
        Me.lblCSTID = New System.Windows.Forms.Label
        Me.lblRecipeID = New System.Windows.Forms.Label
        Me.lblProductCode = New System.Windows.Forms.Label
        Me.LabelCST = New System.Windows.Forms.Label
        Me.lblRunningMode = New System.Windows.Forms.Label
        Me.lblLUTip = New System.Windows.Forms.Label
        Me.lblCVStatus = New System.Windows.Forms.Label
        Me.lblPortIndex = New System.Windows.Forms.Label
        Me.chkPortEnableChk = New System.Windows.Forms.CheckBox
        Me.lblGlassQuantity = New System.Windows.Forms.Label
        Me.picContainer = New System.Windows.Forms.PictureBox
        Me.LabelCSTID = New System.Windows.Forms.Label
        Me.LabelPPID = New System.Windows.Forms.Label
        Me.LabelProductCode = New System.Windows.Forms.Label
        Me.picWireCST = New System.Windows.Forms.PictureBox
        Me.ButtonPause = New System.Windows.Forms.Button
        Me.ButtonRelease = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabelFlowoutGlassID = New System.Windows.Forms.Label
        CType(Me.picParent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWireBuffer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWireCST, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblConveyorIndex
        '
        Me.lblConveyorIndex.AutoSize = True
        Me.lblConveyorIndex.Location = New System.Drawing.Point(7, 6)
        Me.lblConveyorIndex.Name = "lblConveyorIndex"
        Me.lblConveyorIndex.Size = New System.Drawing.Size(77, 12)
        Me.lblConveyorIndex.TabIndex = 0
        Me.lblConveyorIndex.Text = "Conveyor  Port"
        '
        'chkDummyCanecl
        '
        Me.chkDummyCanecl.Location = New System.Drawing.Point(110, 4)
        Me.chkDummyCanecl.Name = "chkDummyCanecl"
        Me.chkDummyCanecl.Size = New System.Drawing.Size(107, 14)
        Me.chkDummyCanecl.TabIndex = 1
        Me.chkDummyCanecl.Text = "Dummy Cancel"
        Me.chkDummyCanecl.UseVisualStyleBackColor = True
        '
        'picParent
        '
        Me.picParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picParent.Location = New System.Drawing.Point(4, 21)
        Me.picParent.Name = "picParent"
        Me.picParent.Size = New System.Drawing.Size(213, 222)
        Me.picParent.TabIndex = 2
        Me.picParent.TabStop = False
        '
        'lblNetHPortIndex
        '
        Me.lblNetHPortIndex.AutoSize = True
        Me.lblNetHPortIndex.Location = New System.Drawing.Point(8, 26)
        Me.lblNetHPortIndex.Name = "lblNetHPortIndex"
        Me.lblNetHPortIndex.Size = New System.Drawing.Size(63, 12)
        Me.lblNetHPortIndex.TabIndex = 3
        Me.lblNetHPortIndex.Text = "NET/H Port "
        Me.lblNetHPortIndex.Visible = False
        '
        'lblPortEnableStatus
        '
        Me.lblPortEnableStatus.AutoSize = True
        Me.lblPortEnableStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPortEnableStatus.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPortEnableStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblPortEnableStatus.Location = New System.Drawing.Point(77, 25)
        Me.lblPortEnableStatus.Name = "lblPortEnableStatus"
        Me.lblPortEnableStatus.Size = New System.Drawing.Size(15, 14)
        Me.lblPortEnableStatus.TabIndex = 4
        Me.lblPortEnableStatus.Text = "E"
        '
        'picWireBuffer
        '
        Me.picWireBuffer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picWireBuffer.Location = New System.Drawing.Point(162, 53)
        Me.picWireBuffer.Name = "picWireBuffer"
        Me.picWireBuffer.Size = New System.Drawing.Size(116, 12)
        Me.picWireBuffer.TabIndex = 5
        Me.picWireBuffer.TabStop = False
        Me.picWireBuffer.Visible = False
        '
        'lblCSTID
        '
        Me.lblCSTID.BackColor = System.Drawing.Color.White
        Me.lblCSTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCSTID.Location = New System.Drawing.Point(43, 136)
        Me.lblCSTID.Name = "lblCSTID"
        Me.lblCSTID.Size = New System.Drawing.Size(170, 17)
        Me.lblCSTID.TabIndex = 7
        Me.lblCSTID.Text = "Cassette ID:"
        Me.lblCSTID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecipeID
        '
        Me.lblRecipeID.BackColor = System.Drawing.Color.White
        Me.lblRecipeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecipeID.Location = New System.Drawing.Point(43, 152)
        Me.lblRecipeID.Name = "lblRecipeID"
        Me.lblRecipeID.Size = New System.Drawing.Size(170, 17)
        Me.lblRecipeID.TabIndex = 8
        Me.lblRecipeID.Text = "Recipe ID:"
        Me.lblRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductCode
        '
        Me.lblProductCode.BackColor = System.Drawing.Color.White
        Me.lblProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductCode.Location = New System.Drawing.Point(71, 168)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(142, 17)
        Me.lblProductCode.TabIndex = 9
        Me.lblProductCode.Text = "ProductCode:"
        Me.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCST
        '
        Me.LabelCST.AutoSize = True
        Me.LabelCST.Location = New System.Drawing.Point(8, 187)
        Me.LabelCST.Name = "LabelCST"
        Me.LabelCST.Size = New System.Drawing.Size(26, 12)
        Me.LabelCST.TabIndex = 10
        Me.LabelCST.Text = "CST"
        '
        'lblRunningMode
        '
        Me.lblRunningMode.BackColor = System.Drawing.Color.White
        Me.lblRunningMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRunningMode.Location = New System.Drawing.Point(33, 184)
        Me.lblRunningMode.Name = "lblRunningMode"
        Me.lblRunningMode.Size = New System.Drawing.Size(180, 16)
        Me.lblRunningMode.TabIndex = 11
        Me.lblRunningMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLUTip
        '
        Me.lblLUTip.AutoSize = True
        Me.lblLUTip.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblLUTip.ForeColor = System.Drawing.Color.Green
        Me.lblLUTip.Location = New System.Drawing.Point(13, 203)
        Me.lblLUTip.Name = "lblLUTip"
        Me.lblLUTip.Size = New System.Drawing.Size(87, 16)
        Me.lblLUTip.TabIndex = 12
        Me.lblLUTip.Text = "Loader OK"
        '
        'lblCVStatus
        '
        Me.lblCVStatus.BackColor = System.Drawing.Color.White
        Me.lblCVStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCVStatus.Location = New System.Drawing.Point(10, 222)
        Me.lblCVStatus.Name = "lblCVStatus"
        Me.lblCVStatus.Size = New System.Drawing.Size(202, 18)
        Me.lblCVStatus.TabIndex = 13
        Me.lblCVStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPortIndex
        '
        Me.lblPortIndex.AutoSize = True
        Me.lblPortIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPortIndex.Location = New System.Drawing.Point(128, 26)
        Me.lblPortIndex.Name = "lblPortIndex"
        Me.lblPortIndex.Size = New System.Drawing.Size(63, 29)
        Me.lblPortIndex.TabIndex = 14
        Me.lblPortIndex.Text = "Port "
        '
        'chkPortEnableChk
        '
        Me.chkPortEnableChk.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPortEnableChk.BackColor = System.Drawing.Color.Yellow
        Me.chkPortEnableChk.Enabled = False
        Me.chkPortEnableChk.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chkPortEnableChk.Location = New System.Drawing.Point(132, 63)
        Me.chkPortEnableChk.Name = "chkPortEnableChk"
        Me.chkPortEnableChk.Size = New System.Drawing.Size(72, 48)
        Me.chkPortEnableChk.TabIndex = 15
        Me.chkPortEnableChk.Text = "Enable Change"
        Me.chkPortEnableChk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPortEnableChk.UseVisualStyleBackColor = False
        Me.chkPortEnableChk.Visible = False
        '
        'lblGlassQuantity
        '
        Me.lblGlassQuantity.AutoSize = True
        Me.lblGlassQuantity.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblGlassQuantity.Location = New System.Drawing.Point(57, 72)
        Me.lblGlassQuantity.Name = "lblGlassQuantity"
        Me.lblGlassQuantity.Size = New System.Drawing.Size(17, 16)
        Me.lblGlassQuantity.TabIndex = 16
        Me.lblGlassQuantity.Text = "0"
        '
        'picContainer
        '
        Me.picContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picContainer.Location = New System.Drawing.Point(0, 0)
        Me.picContainer.Name = "picContainer"
        Me.picContainer.Size = New System.Drawing.Size(221, 245)
        Me.picContainer.TabIndex = 17
        Me.picContainer.TabStop = False
        '
        'LabelCSTID
        '
        Me.LabelCSTID.AutoSize = True
        Me.LabelCSTID.Location = New System.Drawing.Point(8, 138)
        Me.LabelCSTID.Name = "LabelCSTID"
        Me.LabelCSTID.Size = New System.Drawing.Size(38, 12)
        Me.LabelCSTID.TabIndex = 18
        Me.LabelCSTID.Text = "CSTID"
        '
        'LabelPPID
        '
        Me.LabelPPID.AutoSize = True
        Me.LabelPPID.Location = New System.Drawing.Point(8, 154)
        Me.LabelPPID.Name = "LabelPPID"
        Me.LabelPPID.Size = New System.Drawing.Size(29, 12)
        Me.LabelPPID.TabIndex = 19
        Me.LabelPPID.Text = "PPID"
        '
        'LabelProductCode
        '
        Me.LabelProductCode.AutoSize = True
        Me.LabelProductCode.Location = New System.Drawing.Point(8, 171)
        Me.LabelProductCode.Name = "LabelProductCode"
        Me.LabelProductCode.Size = New System.Drawing.Size(66, 12)
        Me.LabelProductCode.TabIndex = 20
        Me.LabelProductCode.Text = "ProductCode"
        '
        'picWireCST
        '
        Me.picWireCST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picWireCST.Location = New System.Drawing.Point(8, 41)
        Me.picWireCST.Name = "picWireCST"
        Me.picWireCST.Size = New System.Drawing.Size(116, 78)
        Me.picWireCST.TabIndex = 21
        Me.picWireCST.TabStop = False
        '
        'ButtonPause
        '
        Me.ButtonPause.Location = New System.Drawing.Point(133, 63)
        Me.ButtonPause.Name = "ButtonPause"
        Me.ButtonPause.Size = New System.Drawing.Size(70, 25)
        Me.ButtonPause.TabIndex = 22
        Me.ButtonPause.Text = "Pause"
        Me.ButtonPause.UseVisualStyleBackColor = True
        '
        'ButtonRelease
        '
        Me.ButtonRelease.Location = New System.Drawing.Point(133, 88)
        Me.ButtonRelease.Name = "ButtonRelease"
        Me.ButtonRelease.Size = New System.Drawing.Size(70, 25)
        Me.ButtonRelease.TabIndex = 23
        Me.ButtonRelease.Text = "Release"
        Me.ButtonRelease.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'LabelFlowoutGlassID
        '
        Me.LabelFlowoutGlassID.BackColor = System.Drawing.Color.White
        Me.LabelFlowoutGlassID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelFlowoutGlassID.Font = New System.Drawing.Font("新細明體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelFlowoutGlassID.Location = New System.Drawing.Point(8, 120)
        Me.LabelFlowoutGlassID.Name = "LabelFlowoutGlassID"
        Me.LabelFlowoutGlassID.Size = New System.Drawing.Size(116, 12)
        Me.LabelFlowoutGlassID.TabIndex = 24
        Me.LabelFlowoutGlassID.Text = "."
        Me.LabelFlowoutGlassID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RSTGUICtrlCV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblRunningMode)
        Me.Controls.Add(Me.lblProductCode)
        Me.Controls.Add(Me.lblRecipeID)
        Me.Controls.Add(Me.LabelFlowoutGlassID)
        Me.Controls.Add(Me.ButtonPause)
        Me.Controls.Add(Me.ButtonRelease)
        Me.Controls.Add(Me.lblGlassQuantity)
        Me.Controls.Add(Me.lblCSTID)
        Me.Controls.Add(Me.LabelProductCode)
        Me.Controls.Add(Me.LabelPPID)
        Me.Controls.Add(Me.LabelCSTID)
        Me.Controls.Add(Me.chkPortEnableChk)
        Me.Controls.Add(Me.lblPortIndex)
        Me.Controls.Add(Me.lblCVStatus)
        Me.Controls.Add(Me.lblLUTip)
        Me.Controls.Add(Me.LabelCST)
        Me.Controls.Add(Me.picWireBuffer)
        Me.Controls.Add(Me.lblPortEnableStatus)
        Me.Controls.Add(Me.lblNetHPortIndex)
        Me.Controls.Add(Me.chkDummyCanecl)
        Me.Controls.Add(Me.lblConveyorIndex)
        Me.Controls.Add(Me.picWireCST)
        Me.Controls.Add(Me.picParent)
        Me.Controls.Add(Me.picContainer)
        Me.Name = "RSTGUICtrlCV"
        Me.Size = New System.Drawing.Size(223, 248)
        CType(Me.picParent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWireBuffer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWireCST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblConveyorIndex As System.Windows.Forms.Label
    Friend WithEvents chkDummyCanecl As System.Windows.Forms.CheckBox
    Friend WithEvents picParent As System.Windows.Forms.PictureBox
    Friend WithEvents lblNetHPortIndex As System.Windows.Forms.Label
    Friend WithEvents lblPortEnableStatus As System.Windows.Forms.Label
    Friend WithEvents picWireBuffer As System.Windows.Forms.PictureBox
    Friend WithEvents lblCSTID As System.Windows.Forms.Label
    Friend WithEvents lblRecipeID As System.Windows.Forms.Label
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents LabelCST As System.Windows.Forms.Label
    Friend WithEvents lblRunningMode As System.Windows.Forms.Label
    Friend WithEvents lblLUTip As System.Windows.Forms.Label
    Friend WithEvents lblCVStatus As System.Windows.Forms.Label
    Friend WithEvents lblPortIndex As System.Windows.Forms.Label
    Friend WithEvents chkPortEnableChk As System.Windows.Forms.CheckBox
    Friend WithEvents lblGlassQuantity As System.Windows.Forms.Label
    Friend WithEvents picContainer As System.Windows.Forms.PictureBox

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'On Error Resume Next
        'lMyWidth = picContainer.Width
        'lMyHeight = picContainer.Height

        lblGlassQuantity.Text = ""

        'Exit Sub

        'Dim vCtrl As Object

        'For Each vCtrl In Me.Controls
        '    With vCtrl
        '        If TypeOf vCtrl Is System.Windows.Forms.Label Or TypeOf vCtrl Is System.Windows.Forms.TextBox Or TypeOf vCtrl Is System.Windows.Forms.GroupBox Or TypeOf vCtrl Is System.Windows.Forms.CheckBox Then
        '            .Tag = .Left & ";" & .Top & ";" & .Width & ";" & .Height & ";" & .FontSize
        '        Else
        '            .Tag = .Left & ";" & .Top & ";" & .Width & ";" & .Height
        '        End If
        '    End With
        'Next
        ControlsPosLocation = New ArrayList
        Dim PosLocation As ControlPL

        For Each ctl As Object In Me.Controls
            PosLocation.Location = ctl.Location
            PosLocation.Size = ctl.size
            If ctl.Font IsNot Nothing Then
                PosLocation.Font = ctl.font
            Else
                PosLocation.Font = Nothing
            End If
            ControlsPosLocation.Add(PosLocation)
        Next

        'picWireCSTGraphics = picWireCST.CreateGraphics
        'picWireBufferGraphics = picWireCST.CreateGraphics
        OldcontrolSize.Size = Me.Size
        OldcontrolSize.Location = Me.Location

        ButtonMouseUpDownAddHandle()

    End Sub
    Friend WithEvents LabelCSTID As System.Windows.Forms.Label
    Friend WithEvents LabelPPID As System.Windows.Forms.Label
    Friend WithEvents LabelProductCode As System.Windows.Forms.Label
    Friend WithEvents picWireCST As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonPause As System.Windows.Forms.Button
    Friend WithEvents ButtonRelease As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelFlowoutGlassID As System.Windows.Forms.Label


End Class
