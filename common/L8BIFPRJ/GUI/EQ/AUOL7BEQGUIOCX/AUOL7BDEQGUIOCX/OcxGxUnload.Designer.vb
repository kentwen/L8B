<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxGxUnload
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
        Me.cmdTRRequest = New System.Windows.Forms.Button
        Me.cmdTRResetReq = New System.Windows.Forms.Button
        Me.lblSignalEQReady = New System.Windows.Forms.Label
        Me.cmdUnloadComp = New System.Windows.Forms.Button
        Me.cmdRBTBusy = New System.Windows.Forms.Button
        Me.lblSignalUnloadReq = New System.Windows.Forms.Label
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblSignalTRResetAck = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblWChipGraade = New System.Windows.Forms.Label
        Me.lblWGxID = New System.Windows.Forms.Label
        Me.lblWPSH = New System.Windows.Forms.Label
        Me.lblWProcessResult = New System.Windows.Forms.Label
        Me.lblWSlotInfo = New System.Windows.Forms.Label
        Me.lblWSampleGxFlag = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdTRRequest
        '
        Me.cmdTRRequest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRRequest.Location = New System.Drawing.Point(10, 3)
        Me.cmdTRRequest.Name = "cmdTRRequest"
        Me.cmdTRRequest.Size = New System.Drawing.Size(167, 30)
        Me.cmdTRRequest.TabIndex = 0
        Me.cmdTRRequest.Text = "Transfer Request"
        Me.cmdTRRequest.UseVisualStyleBackColor = True
        '
        'cmdTRResetReq
        '
        Me.cmdTRResetReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRResetReq.Location = New System.Drawing.Point(529, 4)
        Me.cmdTRResetReq.Name = "cmdTRResetReq"
        Me.cmdTRResetReq.Size = New System.Drawing.Size(167, 30)
        Me.cmdTRResetReq.TabIndex = 6
        Me.cmdTRResetReq.Text = "Transfer Reset Request"
        Me.cmdTRResetReq.UseVisualStyleBackColor = True
        '
        'lblSignalEQReady
        '
        Me.lblSignalEQReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalEQReady.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalEQReady.Location = New System.Drawing.Point(491, 46)
        Me.lblSignalEQReady.Name = "lblSignalEQReady"
        Me.lblSignalEQReady.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalEQReady.TabIndex = 2
        Me.lblSignalEQReady.Text = "EQ Ready"
        Me.lblSignalEQReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdUnloadComp
        '
        Me.cmdUnloadComp.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdUnloadComp.Location = New System.Drawing.Point(356, 3)
        Me.cmdUnloadComp.Name = "cmdUnloadComp"
        Me.cmdUnloadComp.Size = New System.Drawing.Size(167, 30)
        Me.cmdUnloadComp.TabIndex = 4
        Me.cmdUnloadComp.Text = "Unload Complete"
        Me.cmdUnloadComp.UseVisualStyleBackColor = True
        '
        'cmdRBTBusy
        '
        Me.cmdRBTBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdRBTBusy.Location = New System.Drawing.Point(183, 4)
        Me.cmdRBTBusy.Name = "cmdRBTBusy"
        Me.cmdRBTBusy.Size = New System.Drawing.Size(167, 30)
        Me.cmdRBTBusy.TabIndex = 2
        Me.cmdRBTBusy.Text = "Robot Busy"
        Me.cmdRBTBusy.UseVisualStyleBackColor = True
        '
        'lblSignalUnloadReq
        '
        Me.lblSignalUnloadReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalUnloadReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalUnloadReq.Location = New System.Drawing.Point(491, 11)
        Me.lblSignalUnloadReq.Name = "lblSignalUnloadReq"
        Me.lblSignalUnloadReq.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalUnloadReq.TabIndex = 1
        Me.lblSignalUnloadReq.Text = "Unload Request"
        Me.lblSignalUnloadReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRResetReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdUnloadComp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRBTBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRRequest)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalTRResetAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalEQReady)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalUnloadReq)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 9
        '
        'lblSignalTRResetAck
        '
        Me.lblSignalTRResetAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalTRResetAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalTRResetAck.Location = New System.Drawing.Point(491, 81)
        Me.lblSignalTRResetAck.Name = "lblSignalTRResetAck"
        Me.lblSignalTRResetAck.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalTRResetAck.TabIndex = 3
        Me.lblSignalTRResetAck.Text = "Transfer Reset Ack"
        Me.lblSignalTRResetAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblWChipGraade)
        Me.Panel1.Controls.Add(Me.lblWGxID)
        Me.Panel1.Controls.Add(Me.lblWPSH)
        Me.Panel1.Controls.Add(Me.lblWProcessResult)
        Me.Panel1.Controls.Add(Me.lblWSlotInfo)
        Me.Panel1.Controls.Add(Me.lblWSampleGxFlag)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 222)
        Me.Panel1.TabIndex = 0
        '
        'lblWChipGraade
        '
        Me.lblWChipGraade.BackColor = System.Drawing.Color.White
        Me.lblWChipGraade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWChipGraade.Location = New System.Drawing.Point(199, 132)
        Me.lblWChipGraade.Name = "lblWChipGraade"
        Me.lblWChipGraade.Size = New System.Drawing.Size(252, 22)
        Me.lblWChipGraade.TabIndex = 113
        Me.lblWChipGraade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWGxID
        '
        Me.lblWGxID.BackColor = System.Drawing.Color.White
        Me.lblWGxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWGxID.Location = New System.Drawing.Point(199, 109)
        Me.lblWGxID.Name = "lblWGxID"
        Me.lblWGxID.Size = New System.Drawing.Size(252, 22)
        Me.lblWGxID.TabIndex = 112
        Me.lblWGxID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWPSH
        '
        Me.lblWPSH.BackColor = System.Drawing.Color.White
        Me.lblWPSH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWPSH.Location = New System.Drawing.Point(199, 86)
        Me.lblWPSH.Name = "lblWPSH"
        Me.lblWPSH.Size = New System.Drawing.Size(252, 22)
        Me.lblWPSH.TabIndex = 111
        Me.lblWPSH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWProcessResult
        '
        Me.lblWProcessResult.BackColor = System.Drawing.Color.White
        Me.lblWProcessResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWProcessResult.Location = New System.Drawing.Point(199, 63)
        Me.lblWProcessResult.Name = "lblWProcessResult"
        Me.lblWProcessResult.Size = New System.Drawing.Size(252, 22)
        Me.lblWProcessResult.TabIndex = 110
        Me.lblWProcessResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWSlotInfo
        '
        Me.lblWSlotInfo.BackColor = System.Drawing.Color.White
        Me.lblWSlotInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWSlotInfo.Location = New System.Drawing.Point(199, 39)
        Me.lblWSlotInfo.Name = "lblWSlotInfo"
        Me.lblWSlotInfo.Size = New System.Drawing.Size(252, 22)
        Me.lblWSlotInfo.TabIndex = 109
        Me.lblWSlotInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWSampleGxFlag
        '
        Me.lblWSampleGxFlag.BackColor = System.Drawing.Color.White
        Me.lblWSampleGxFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWSampleGxFlag.Location = New System.Drawing.Point(199, 15)
        Me.lblWSampleGxFlag.Name = "lblWSampleGxFlag"
        Me.lblWSampleGxFlag.Size = New System.Drawing.Size(252, 22)
        Me.lblWSampleGxFlag.TabIndex = 108
        Me.lblWSampleGxFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 23)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Chip Grade[W9]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 85)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(180, 23)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "PS-H Grouping[A1]"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 62)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(180, 23)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Process Result[W1]"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 108)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(180, 23)
        Me.Label21.TabIndex = 104
        Me.Label21.Text = "Glass ID[A12]"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.Location = New System.Drawing.Point(13, 38)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(180, 23)
        Me.Label22.TabIndex = 103
        Me.Label22.Text = "Slot Information[W1]"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(13, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(180, 23)
        Me.Label23.TabIndex = 102
        Me.Label23.Text = "Sample Glass Flag[W1]"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabEQ1)
        Me.TabControl1.Controls.Add(Me.tabEQ2)
        Me.TabControl1.Controls.Add(Me.tabEQ3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 8
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
        'OcxGxUnload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OcxGxUnload"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdTRRequest As System.Windows.Forms.Button
    Friend WithEvents cmdTRResetReq As System.Windows.Forms.Button
    Friend WithEvents lblSignalEQReady As System.Windows.Forms.Label
    Friend WithEvents cmdUnloadComp As System.Windows.Forms.Button
    Friend WithEvents cmdRBTBusy As System.Windows.Forms.Button
    Friend WithEvents lblSignalUnloadReq As System.Windows.Forms.Label
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblSignalTRResetAck As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents lblWChipGraade As System.Windows.Forms.Label
    Friend WithEvents lblWGxID As System.Windows.Forms.Label
    Friend WithEvents lblWPSH As System.Windows.Forms.Label
    Friend WithEvents lblWProcessResult As System.Windows.Forms.Label
    Friend WithEvents lblWSlotInfo As System.Windows.Forms.Label
    Friend WithEvents lblWSampleGxFlag As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label

End Class
