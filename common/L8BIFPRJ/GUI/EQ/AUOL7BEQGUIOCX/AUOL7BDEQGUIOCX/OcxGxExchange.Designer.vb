<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxGxExchange
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
        Me.lblSignalExchangeReq = New System.Windows.Forms.Label
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
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdTRReset = New System.Windows.Forms.Button
        Me.cmdExchangeStatus = New System.Windows.Forms.Button
        Me.cmdExchangeComp = New System.Windows.Forms.Button
        Me.cmdRBTPutBusy = New System.Windows.Forms.Button
        Me.cmdRBTGetBusy = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSampleGxFlag = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtProductCategory = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSlotInfo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtGxID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEPPID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtMESID = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCurrentRecipe = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPoperID = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPLineID = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPToolID = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCSTID = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtOperationID = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtGxGrade = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtDMQCGrade = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtGxScrapFlag = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtMPAFlag = New System.Windows.Forms.TextBox
        Me.lblSignalTRRresetAck = New System.Windows.Forms.Label
        Me.lblSignalEQReady = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdTRRequest
        '
        Me.cmdTRRequest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRRequest.Location = New System.Drawing.Point(491, 6)
        Me.cmdTRRequest.Name = "cmdTRRequest"
        Me.cmdTRRequest.Size = New System.Drawing.Size(167, 30)
        Me.cmdTRRequest.TabIndex = 0
        Me.cmdTRRequest.Text = "Transfer Request"
        Me.cmdTRRequest.UseVisualStyleBackColor = True
        '
        'lblSignalExchangeReq
        '
        Me.lblSignalExchangeReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalExchangeReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalExchangeReq.Location = New System.Drawing.Point(491, 11)
        Me.lblSignalExchangeReq.Name = "lblSignalExchangeReq"
        Me.lblSignalExchangeReq.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalExchangeReq.TabIndex = 1
        Me.lblSignalExchangeReq.Text = "Exchange Request"
        Me.lblSignalExchangeReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.lblWChipGraade.Location = New System.Drawing.Point(198, 135)
        Me.lblWChipGraade.Name = "lblWChipGraade"
        Me.lblWChipGraade.Size = New System.Drawing.Size(255, 22)
        Me.lblWChipGraade.TabIndex = 101
        Me.lblWChipGraade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWGxID
        '
        Me.lblWGxID.BackColor = System.Drawing.Color.White
        Me.lblWGxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWGxID.Location = New System.Drawing.Point(198, 112)
        Me.lblWGxID.Name = "lblWGxID"
        Me.lblWGxID.Size = New System.Drawing.Size(255, 22)
        Me.lblWGxID.TabIndex = 100
        Me.lblWGxID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWPSH
        '
        Me.lblWPSH.BackColor = System.Drawing.Color.White
        Me.lblWPSH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWPSH.Location = New System.Drawing.Point(198, 89)
        Me.lblWPSH.Name = "lblWPSH"
        Me.lblWPSH.Size = New System.Drawing.Size(255, 22)
        Me.lblWPSH.TabIndex = 99
        Me.lblWPSH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWProcessResult
        '
        Me.lblWProcessResult.BackColor = System.Drawing.Color.White
        Me.lblWProcessResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWProcessResult.Location = New System.Drawing.Point(198, 66)
        Me.lblWProcessResult.Name = "lblWProcessResult"
        Me.lblWProcessResult.Size = New System.Drawing.Size(255, 22)
        Me.lblWProcessResult.TabIndex = 98
        Me.lblWProcessResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWSlotInfo
        '
        Me.lblWSlotInfo.BackColor = System.Drawing.Color.White
        Me.lblWSlotInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWSlotInfo.Location = New System.Drawing.Point(198, 42)
        Me.lblWSlotInfo.Name = "lblWSlotInfo"
        Me.lblWSlotInfo.Size = New System.Drawing.Size(255, 22)
        Me.lblWSlotInfo.TabIndex = 97
        Me.lblWSlotInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWSampleGxFlag
        '
        Me.lblWSampleGxFlag.BackColor = System.Drawing.Color.White
        Me.lblWSampleGxFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWSampleGxFlag.Location = New System.Drawing.Point(198, 18)
        Me.lblWSampleGxFlag.Name = "lblWSampleGxFlag"
        Me.lblWSampleGxFlag.Size = New System.Drawing.Size(255, 22)
        Me.lblWSampleGxFlag.TabIndex = 96
        Me.lblWSampleGxFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 23)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Chip Grade[W9]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 23)
        Me.Label19.TabIndex = 93
        Me.Label19.Text = "PS-H Grouping[A1]"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 65)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(181, 23)
        Me.Label20.TabIndex = 91
        Me.Label20.Text = "Process Result[W1]"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 111)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(181, 23)
        Me.Label21.TabIndex = 89
        Me.Label21.Text = "Glass ID[A12]"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(181, 23)
        Me.Label22.TabIndex = 87
        Me.Label22.Text = "Slot Information[W1]"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(181, 23)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "Sample Glass Flag[W1]"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabEQ1)
        Me.TabControl1.Controls.Add(Me.tabEQ2)
        Me.TabControl1.Controls.Add(Me.tabEQ3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 6
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
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRReset)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExchangeStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExchangeComp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRBTPutBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRBTGetBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRRequest)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalTRRresetAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalEQReady)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalExchangeReq)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 468)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 7
        '
        'cmdTRReset
        '
        Me.cmdTRReset.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRReset.Location = New System.Drawing.Point(491, 182)
        Me.cmdTRReset.Name = "cmdTRReset"
        Me.cmdTRReset.Size = New System.Drawing.Size(167, 30)
        Me.cmdTRReset.TabIndex = 6
        Me.cmdTRReset.Text = "Transfer Reset Request"
        Me.cmdTRReset.UseVisualStyleBackColor = True
        '
        'cmdExchangeStatus
        '
        Me.cmdExchangeStatus.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExchangeStatus.Location = New System.Drawing.Point(491, 146)
        Me.cmdExchangeStatus.Name = "cmdExchangeStatus"
        Me.cmdExchangeStatus.Size = New System.Drawing.Size(167, 30)
        Me.cmdExchangeStatus.TabIndex = 5
        Me.cmdExchangeStatus.Text = "Exchange Status"
        Me.cmdExchangeStatus.UseVisualStyleBackColor = True
        '
        'cmdExchangeComp
        '
        Me.cmdExchangeComp.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExchangeComp.Location = New System.Drawing.Point(491, 110)
        Me.cmdExchangeComp.Name = "cmdExchangeComp"
        Me.cmdExchangeComp.Size = New System.Drawing.Size(167, 30)
        Me.cmdExchangeComp.TabIndex = 4
        Me.cmdExchangeComp.Text = "Exchange Complete"
        Me.cmdExchangeComp.UseVisualStyleBackColor = True
        '
        'cmdRBTPutBusy
        '
        Me.cmdRBTPutBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdRBTPutBusy.Location = New System.Drawing.Point(491, 75)
        Me.cmdRBTPutBusy.Name = "cmdRBTPutBusy"
        Me.cmdRBTPutBusy.Size = New System.Drawing.Size(167, 30)
        Me.cmdRBTPutBusy.TabIndex = 3
        Me.cmdRBTPutBusy.Text = "Robot Put Busy"
        Me.cmdRBTPutBusy.UseVisualStyleBackColor = True
        '
        'cmdRBTGetBusy
        '
        Me.cmdRBTGetBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdRBTGetBusy.Location = New System.Drawing.Point(491, 41)
        Me.cmdRBTGetBusy.Name = "cmdRBTGetBusy"
        Me.cmdRBTGetBusy.Size = New System.Drawing.Size(167, 30)
        Me.cmdRBTGetBusy.TabIndex = 2
        Me.cmdRBTGetBusy.Text = "Robot Get Busy"
        Me.cmdRBTGetBusy.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 222)
        Me.Panel2.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Label18)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtSampleGxFlag)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtProductCategory)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtSlotInfo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtGxID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtEPPID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtMESID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtProductCode)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label8)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtCurrentRecipe)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label9)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtPoperID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label10)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtPLineID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label11)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtPToolID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label12)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtCSTID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label13)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtOperationID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label14)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtGxGrade)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label15)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtDMQCGrade)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label16)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtGxScrapFlag)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label17)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtMPAFlag)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(459, 214)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(238, 23)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Sample Glass Flag[W1]"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSampleGxFlag
        '
        Me.txtSampleGxFlag.Location = New System.Drawing.Point(247, 3)
        Me.txtSampleGxFlag.Name = "txtSampleGxFlag"
        Me.txtSampleGxFlag.Size = New System.Drawing.Size(187, 22)
        Me.txtSampleGxFlag.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 23)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Product Category[W1]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProductCategory
        '
        Me.txtProductCategory.Location = New System.Drawing.Point(247, 31)
        Me.txtProductCategory.Name = "txtProductCategory"
        Me.txtProductCategory.Size = New System.Drawing.Size(187, 22)
        Me.txtProductCategory.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 23)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Slot Information[W1]"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSlotInfo
        '
        Me.txtSlotInfo.Location = New System.Drawing.Point(247, 59)
        Me.txtSlotInfo.Name = "txtSlotInfo"
        Me.txtSlotInfo.Size = New System.Drawing.Size(187, 22)
        Me.txtSlotInfo.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(238, 23)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Glass ID[A12]"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGxID
        '
        Me.txtGxID.Location = New System.Drawing.Point(247, 87)
        Me.txtGxID.Name = "txtGxID"
        Me.txtGxID.Size = New System.Drawing.Size(187, 22)
        Me.txtGxID.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 23)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "EPPID[A4]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEPPID
        '
        Me.txtEPPID.Location = New System.Drawing.Point(247, 115)
        Me.txtEPPID.Name = "txtEPPID"
        Me.txtEPPID.Size = New System.Drawing.Size(187, 22)
        Me.txtEPPID.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(238, 23)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "MESID[A8]"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMESID
        '
        Me.txtMESID.Location = New System.Drawing.Point(247, 143)
        Me.txtMESID.Name = "txtMESID"
        Me.txtMESID.Size = New System.Drawing.Size(187, 22)
        Me.txtMESID.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 23)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Product Code[A26]"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProductCode
        '
        Me.txtProductCode.Location = New System.Drawing.Point(247, 171)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(187, 22)
        Me.txtProductCode.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(238, 23)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Current Recipe[A32]"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCurrentRecipe
        '
        Me.txtCurrentRecipe.Location = New System.Drawing.Point(247, 199)
        Me.txtCurrentRecipe.Name = "txtCurrentRecipe"
        Me.txtCurrentRecipe.Size = New System.Drawing.Size(187, 22)
        Me.txtCurrentRecipe.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 224)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(238, 23)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "PoperID[A26]"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPoperID
        '
        Me.txtPoperID.Location = New System.Drawing.Point(247, 227)
        Me.txtPoperID.Name = "txtPoperID"
        Me.txtPoperID.Size = New System.Drawing.Size(187, 22)
        Me.txtPoperID.TabIndex = 54
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(238, 23)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "PLineID[A8]"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPLineID
        '
        Me.txtPLineID.Location = New System.Drawing.Point(247, 255)
        Me.txtPLineID.Name = "txtPLineID"
        Me.txtPLineID.Size = New System.Drawing.Size(187, 22)
        Me.txtPLineID.TabIndex = 56
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(238, 23)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "PToolID[A8]"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPToolID
        '
        Me.txtPToolID.Location = New System.Drawing.Point(247, 283)
        Me.txtPToolID.Name = "txtPToolID"
        Me.txtPToolID.Size = New System.Drawing.Size(187, 22)
        Me.txtPToolID.TabIndex = 58
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 308)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(238, 23)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "Cassette ID[A6]"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCSTID
        '
        Me.txtCSTID.Location = New System.Drawing.Point(247, 311)
        Me.txtCSTID.Name = "txtCSTID"
        Me.txtCSTID.Size = New System.Drawing.Size(187, 22)
        Me.txtCSTID.TabIndex = 60
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 336)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(238, 23)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Operation ID[A25]"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOperationID
        '
        Me.txtOperationID.Location = New System.Drawing.Point(247, 339)
        Me.txtOperationID.Name = "txtOperationID"
        Me.txtOperationID.Size = New System.Drawing.Size(187, 22)
        Me.txtOperationID.TabIndex = 62
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 364)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(238, 23)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Glass Grade[A1]"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGxGrade
        '
        Me.txtGxGrade.Location = New System.Drawing.Point(247, 367)
        Me.txtGxGrade.Name = "txtGxGrade"
        Me.txtGxGrade.Size = New System.Drawing.Size(187, 22)
        Me.txtGxGrade.TabIndex = 64
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 392)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(238, 23)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "DMQC Grade[A1]"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDMQCGrade
        '
        Me.txtDMQCGrade.Location = New System.Drawing.Point(247, 395)
        Me.txtDMQCGrade.Name = "txtDMQCGrade"
        Me.txtDMQCGrade.Size = New System.Drawing.Size(187, 22)
        Me.txtDMQCGrade.TabIndex = 66
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 420)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(238, 23)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "Glass Scrap Flag[A1]"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGxScrapFlag
        '
        Me.txtGxScrapFlag.Location = New System.Drawing.Point(247, 423)
        Me.txtGxScrapFlag.Name = "txtGxScrapFlag"
        Me.txtGxScrapFlag.Size = New System.Drawing.Size(187, 22)
        Me.txtGxScrapFlag.TabIndex = 68
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 448)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(238, 23)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "MPA Flag[W1]"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMPAFlag
        '
        Me.txtMPAFlag.Location = New System.Drawing.Point(247, 451)
        Me.txtMPAFlag.Name = "txtMPAFlag"
        Me.txtMPAFlag.Size = New System.Drawing.Size(187, 22)
        Me.txtMPAFlag.TabIndex = 70
        '
        'lblSignalTRRresetAck
        '
        Me.lblSignalTRRresetAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalTRRresetAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalTRRresetAck.Location = New System.Drawing.Point(491, 81)
        Me.lblSignalTRRresetAck.Name = "lblSignalTRRresetAck"
        Me.lblSignalTRRresetAck.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalTRRresetAck.TabIndex = 3
        Me.lblSignalTRRresetAck.Text = "Transfer Reset Ack"
        Me.lblSignalTRRresetAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'OcxGxExchange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OcxGxExchange"
        Me.Size = New System.Drawing.Size(730, 500)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdTRRequest As System.Windows.Forms.Button
    Friend WithEvents lblSignalExchangeReq As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSampleGxFlag As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProductCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSlotInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGxID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEPPID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMESID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentRecipe As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPoperID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPLineID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPToolID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCSTID As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOperationID As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGxGrade As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDMQCGrade As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtGxScrapFlag As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtMPAFlag As System.Windows.Forms.TextBox
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
    Friend WithEvents cmdExchangeStatus As System.Windows.Forms.Button
    Friend WithEvents cmdExchangeComp As System.Windows.Forms.Button
    Friend WithEvents cmdRBTPutBusy As System.Windows.Forms.Button
    Friend WithEvents cmdRBTGetBusy As System.Windows.Forms.Button
    Friend WithEvents cmdTRReset As System.Windows.Forms.Button
    Friend WithEvents lblSignalTRRresetAck As System.Windows.Forms.Label
    Friend WithEvents lblSignalEQReady As System.Windows.Forms.Label

End Class
