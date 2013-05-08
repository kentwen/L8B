<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcxSignal
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
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.lblSignalLinkReq = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cmdInspectionFlag = New System.Windows.Forms.Button
        Me.cmdEPPIDQueryReq = New System.Windows.Forms.Button
        Me.cmdEPPIDChkReq = New System.Windows.Forms.Button
        Me.cmdGxEraseAck = New System.Windows.Forms.Button
        Me.cmdTRResetReq = New System.Windows.Forms.Button
        Me.cmdEPPIDModifyAck = New System.Windows.Forms.Button
        Me.cmdExComp = New System.Windows.Forms.Button
        Me.cmdExPutBusy = New System.Windows.Forms.Button
        Me.cmdExGetBusy = New System.Windows.Forms.Button
        Me.cmdExTR = New System.Windows.Forms.Button
        Me.cmdUnloadComp = New System.Windows.Forms.Button
        Me.cmdUnloadBusy = New System.Windows.Forms.Button
        Me.cmdUnloadTR = New System.Windows.Forms.Button
        Me.cmdExStatus = New System.Windows.Forms.Button
        Me.cmdLoadComp = New System.Windows.Forms.Button
        Me.cmdLoadBusy = New System.Windows.Forms.Button
        Me.cmdLoadTR = New System.Windows.Forms.Button
        Me.cmdTransferMode = New System.Windows.Forms.Button
        Me.cmdArmMode = New System.Windows.Forms.Button
        Me.cmdIgnoreTimeout = New System.Windows.Forms.Button
        Me.cmdLinkTest = New System.Windows.Forms.Button
        Me.cmdLinkReq = New System.Windows.Forms.Button
        Me.lblSignalEPPIDQueryAck = New System.Windows.Forms.Label
        Me.lblSignalEPPIDChkAck = New System.Windows.Forms.Label
        Me.lblSignalEPPIDModifyReport = New System.Windows.Forms.Label
        Me.lblSignalGxEraseReport = New System.Windows.Forms.Label
        Me.lblSignalTRResetAck = New System.Windows.Forms.Label
        Me.lblSignalExReady = New System.Windows.Forms.Label
        Me.lblSignalExReq = New System.Windows.Forms.Label
        Me.lblSignalUnloadReady = New System.Windows.Forms.Label
        Me.lblSignalUnloadReq = New System.Windows.Forms.Label
        Me.lblSignalLoadReady = New System.Windows.Forms.Label
        Me.lblSignalLoadReq = New System.Windows.Forms.Label
        Me.lblSignalAlarmOccurred = New System.Windows.Forms.Label
        Me.lblSignalHandoff = New System.Windows.Forms.Label
        Me.lblSignalGxInProcess = New System.Windows.Forms.Label
        Me.lblSignalGxOnStage = New System.Windows.Forms.Label
        Me.lblSignalLinkTest = New System.Windows.Forms.Label
        Me.cmdRepairReviewMode = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabEQ1)
        Me.TabControl1.Controls.Add(Me.tabEQ2)
        Me.TabControl1.Controls.Add(Me.tabEQ3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 23)
        Me.TabControl1.TabIndex = 12
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
        'lblSignalLinkReq
        '
        Me.lblSignalLinkReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalLinkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalLinkReq.Location = New System.Drawing.Point(10, 9)
        Me.lblSignalLinkReq.Name = "lblSignalLinkReq"
        Me.lblSignalLinkReq.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalLinkReq.TabIndex = 1
        Me.lblSignalLinkReq.Text = "EQ Link Request"
        Me.lblSignalLinkReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRepairReviewMode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdInspectionFlag)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdEPPIDQueryReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdEPPIDChkReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGxEraseAck)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTRResetReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdEPPIDModifyAck)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExComp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExPutBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExGetBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExTR)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdUnloadComp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdUnloadBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdUnloadTR)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLoadComp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLoadBusy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLoadTR)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTransferMode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdArmMode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdIgnoreTimeout)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLinkTest)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLinkReq)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalEPPIDQueryAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalEPPIDChkAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalEPPIDModifyReport)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxEraseReport)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalTRResetAck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalExReady)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalExReq)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalUnloadReady)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalUnloadReq)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalLoadReady)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalLoadReq)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalAlarmOccurred)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalHandoff)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxInProcess)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalGxOnStage)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalLinkTest)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignalLinkReq)
        Me.SplitContainer1.Size = New System.Drawing.Size(878, 653)
        Me.SplitContainer1.SplitterDistance = 325
        Me.SplitContainer1.TabIndex = 13
        '
        'cmdInspectionFlag
        '
        Me.cmdInspectionFlag.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdInspectionFlag.Location = New System.Drawing.Point(183, 184)
        Me.cmdInspectionFlag.Name = "cmdInspectionFlag"
        Me.cmdInspectionFlag.Size = New System.Drawing.Size(167, 30)
        Me.cmdInspectionFlag.TabIndex = 21
        Me.cmdInspectionFlag.Text = "Macro Inspection Flag"
        Me.cmdInspectionFlag.UseVisualStyleBackColor = True
        '
        'cmdEPPIDQueryReq
        '
        Me.cmdEPPIDQueryReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdEPPIDQueryReq.Location = New System.Drawing.Point(10, 184)
        Me.cmdEPPIDQueryReq.Name = "cmdEPPIDQueryReq"
        Me.cmdEPPIDQueryReq.Size = New System.Drawing.Size(167, 30)
        Me.cmdEPPIDQueryReq.TabIndex = 20
        Me.cmdEPPIDQueryReq.Text = "EPPID Query Request"
        Me.cmdEPPIDQueryReq.UseVisualStyleBackColor = True
        '
        'cmdEPPIDChkReq
        '
        Me.cmdEPPIDChkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdEPPIDChkReq.Location = New System.Drawing.Point(529, 148)
        Me.cmdEPPIDChkReq.Name = "cmdEPPIDChkReq"
        Me.cmdEPPIDChkReq.Size = New System.Drawing.Size(167, 30)
        Me.cmdEPPIDChkReq.TabIndex = 19
        Me.cmdEPPIDChkReq.Text = "EPPID Check Request"
        Me.cmdEPPIDChkReq.UseVisualStyleBackColor = True
        '
        'cmdGxEraseAck
        '
        Me.cmdGxEraseAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdGxEraseAck.Location = New System.Drawing.Point(356, 148)
        Me.cmdGxEraseAck.Name = "cmdGxEraseAck"
        Me.cmdGxEraseAck.Size = New System.Drawing.Size(167, 30)
        Me.cmdGxEraseAck.TabIndex = 18
        Me.cmdGxEraseAck.Text = "Glass Erase Ack"
        Me.cmdGxEraseAck.UseVisualStyleBackColor = True
        '
        'cmdTRResetReq
        '
        Me.cmdTRResetReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTRResetReq.Location = New System.Drawing.Point(183, 148)
        Me.cmdTRResetReq.Name = "cmdTRResetReq"
        Me.cmdTRResetReq.Size = New System.Drawing.Size(167, 30)
        Me.cmdTRResetReq.TabIndex = 17
        Me.cmdTRResetReq.Text = "TR Reset Request"
        Me.cmdTRResetReq.UseVisualStyleBackColor = True
        '
        'cmdEPPIDModifyAck
        '
        Me.cmdEPPIDModifyAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdEPPIDModifyAck.Location = New System.Drawing.Point(10, 148)
        Me.cmdEPPIDModifyAck.Name = "cmdEPPIDModifyAck"
        Me.cmdEPPIDModifyAck.Size = New System.Drawing.Size(167, 30)
        Me.cmdEPPIDModifyAck.TabIndex = 16
        Me.cmdEPPIDModifyAck.Text = "EPPID Modify Ack"
        Me.cmdEPPIDModifyAck.UseVisualStyleBackColor = True
        '
        'cmdExComp
        '
        Me.cmdExComp.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExComp.Location = New System.Drawing.Point(529, 112)
        Me.cmdExComp.Name = "cmdExComp"
        Me.cmdExComp.Size = New System.Drawing.Size(167, 30)
        Me.cmdExComp.TabIndex = 15
        Me.cmdExComp.Text = "Exchange Complete"
        Me.cmdExComp.UseVisualStyleBackColor = True
        '
        'cmdExPutBusy
        '
        Me.cmdExPutBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExPutBusy.Location = New System.Drawing.Point(356, 112)
        Me.cmdExPutBusy.Name = "cmdExPutBusy"
        Me.cmdExPutBusy.Size = New System.Drawing.Size(167, 30)
        Me.cmdExPutBusy.TabIndex = 14
        Me.cmdExPutBusy.Text = "Robot Put Busy"
        Me.cmdExPutBusy.UseVisualStyleBackColor = True
        '
        'cmdExGetBusy
        '
        Me.cmdExGetBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExGetBusy.Location = New System.Drawing.Point(183, 112)
        Me.cmdExGetBusy.Name = "cmdExGetBusy"
        Me.cmdExGetBusy.Size = New System.Drawing.Size(167, 30)
        Me.cmdExGetBusy.TabIndex = 13
        Me.cmdExGetBusy.Text = "Robot Get Busy"
        Me.cmdExGetBusy.UseVisualStyleBackColor = True
        '
        'cmdExTR
        '
        Me.cmdExTR.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExTR.Location = New System.Drawing.Point(10, 112)
        Me.cmdExTR.Name = "cmdExTR"
        Me.cmdExTR.Size = New System.Drawing.Size(167, 30)
        Me.cmdExTR.TabIndex = 12
        Me.cmdExTR.Text = "Transfer Request(E)"
        Me.cmdExTR.UseVisualStyleBackColor = True
        '
        'cmdUnloadComp
        '
        Me.cmdUnloadComp.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdUnloadComp.Location = New System.Drawing.Point(529, 76)
        Me.cmdUnloadComp.Name = "cmdUnloadComp"
        Me.cmdUnloadComp.Size = New System.Drawing.Size(167, 30)
        Me.cmdUnloadComp.TabIndex = 11
        Me.cmdUnloadComp.Text = "Unload Complete(U)"
        Me.cmdUnloadComp.UseVisualStyleBackColor = True
        '
        'cmdUnloadBusy
        '
        Me.cmdUnloadBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdUnloadBusy.Location = New System.Drawing.Point(356, 76)
        Me.cmdUnloadBusy.Name = "cmdUnloadBusy"
        Me.cmdUnloadBusy.Size = New System.Drawing.Size(167, 30)
        Me.cmdUnloadBusy.TabIndex = 10
        Me.cmdUnloadBusy.Text = "Robot Busy(U)"
        Me.cmdUnloadBusy.UseVisualStyleBackColor = True
        '
        'cmdUnloadTR
        '
        Me.cmdUnloadTR.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdUnloadTR.Location = New System.Drawing.Point(183, 76)
        Me.cmdUnloadTR.Name = "cmdUnloadTR"
        Me.cmdUnloadTR.Size = New System.Drawing.Size(167, 30)
        Me.cmdUnloadTR.TabIndex = 9
        Me.cmdUnloadTR.Text = "Transfer Request(U)"
        Me.cmdUnloadTR.UseVisualStyleBackColor = True
        '
        'cmdExStatus
        '
        Me.cmdExStatus.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExStatus.Location = New System.Drawing.Point(10, 76)
        Me.cmdExStatus.Name = "cmdExStatus"
        Me.cmdExStatus.Size = New System.Drawing.Size(167, 30)
        Me.cmdExStatus.TabIndex = 8
        Me.cmdExStatus.Text = "Exchange Status"
        Me.cmdExStatus.UseVisualStyleBackColor = True
        '
        'cmdLoadComp
        '
        Me.cmdLoadComp.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLoadComp.Location = New System.Drawing.Point(529, 40)
        Me.cmdLoadComp.Name = "cmdLoadComp"
        Me.cmdLoadComp.Size = New System.Drawing.Size(167, 30)
        Me.cmdLoadComp.TabIndex = 7
        Me.cmdLoadComp.Text = "Load Complete(L)"
        Me.cmdLoadComp.UseVisualStyleBackColor = True
        '
        'cmdLoadBusy
        '
        Me.cmdLoadBusy.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLoadBusy.Location = New System.Drawing.Point(356, 40)
        Me.cmdLoadBusy.Name = "cmdLoadBusy"
        Me.cmdLoadBusy.Size = New System.Drawing.Size(167, 30)
        Me.cmdLoadBusy.TabIndex = 6
        Me.cmdLoadBusy.Text = "Robot Busy(L)"
        Me.cmdLoadBusy.UseVisualStyleBackColor = True
        '
        'cmdLoadTR
        '
        Me.cmdLoadTR.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLoadTR.Location = New System.Drawing.Point(183, 40)
        Me.cmdLoadTR.Name = "cmdLoadTR"
        Me.cmdLoadTR.Size = New System.Drawing.Size(167, 30)
        Me.cmdLoadTR.TabIndex = 5
        Me.cmdLoadTR.Text = "Transfer Request(L)"
        Me.cmdLoadTR.UseVisualStyleBackColor = True
        '
        'cmdTransferMode
        '
        Me.cmdTransferMode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdTransferMode.Location = New System.Drawing.Point(10, 40)
        Me.cmdTransferMode.Name = "cmdTransferMode"
        Me.cmdTransferMode.Size = New System.Drawing.Size(167, 30)
        Me.cmdTransferMode.TabIndex = 4
        Me.cmdTransferMode.Text = "Transfer Mode"
        Me.cmdTransferMode.UseVisualStyleBackColor = True
        '
        'cmdArmMode
        '
        Me.cmdArmMode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdArmMode.Location = New System.Drawing.Point(529, 4)
        Me.cmdArmMode.Name = "cmdArmMode"
        Me.cmdArmMode.Size = New System.Drawing.Size(167, 30)
        Me.cmdArmMode.TabIndex = 3
        Me.cmdArmMode.Text = "Arm Mode"
        Me.cmdArmMode.UseVisualStyleBackColor = True
        '
        'cmdIgnoreTimeout
        '
        Me.cmdIgnoreTimeout.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdIgnoreTimeout.Location = New System.Drawing.Point(356, 4)
        Me.cmdIgnoreTimeout.Name = "cmdIgnoreTimeout"
        Me.cmdIgnoreTimeout.Size = New System.Drawing.Size(167, 30)
        Me.cmdIgnoreTimeout.TabIndex = 2
        Me.cmdIgnoreTimeout.Text = "Ignore Timeout"
        Me.cmdIgnoreTimeout.UseVisualStyleBackColor = True
        '
        'cmdLinkTest
        '
        Me.cmdLinkTest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLinkTest.Location = New System.Drawing.Point(183, 4)
        Me.cmdLinkTest.Name = "cmdLinkTest"
        Me.cmdLinkTest.Size = New System.Drawing.Size(167, 30)
        Me.cmdLinkTest.TabIndex = 1
        Me.cmdLinkTest.Text = "Link Test Request"
        Me.cmdLinkTest.UseVisualStyleBackColor = True
        '
        'cmdLinkReq
        '
        Me.cmdLinkReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdLinkReq.Location = New System.Drawing.Point(10, 4)
        Me.cmdLinkReq.Name = "cmdLinkReq"
        Me.cmdLinkReq.Size = New System.Drawing.Size(167, 30)
        Me.cmdLinkReq.TabIndex = 0
        Me.cmdLinkReq.Text = "RST Link Request"
        Me.cmdLinkReq.UseVisualStyleBackColor = True
        '
        'lblSignalEPPIDQueryAck
        '
        Me.lblSignalEPPIDQueryAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalEPPIDQueryAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalEPPIDQueryAck.Location = New System.Drawing.Point(529, 44)
        Me.lblSignalEPPIDQueryAck.Name = "lblSignalEPPIDQueryAck"
        Me.lblSignalEPPIDQueryAck.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalEPPIDQueryAck.TabIndex = 21
        Me.lblSignalEPPIDQueryAck.Text = "EPPID Query Ack"
        Me.lblSignalEPPIDQueryAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalEPPIDChkAck
        '
        Me.lblSignalEPPIDChkAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalEPPIDChkAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalEPPIDChkAck.Location = New System.Drawing.Point(356, 149)
        Me.lblSignalEPPIDChkAck.Name = "lblSignalEPPIDChkAck"
        Me.lblSignalEPPIDChkAck.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalEPPIDChkAck.TabIndex = 20
        Me.lblSignalEPPIDChkAck.Text = "EPPID Check Ack"
        Me.lblSignalEPPIDChkAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalEPPIDModifyReport
        '
        Me.lblSignalEPPIDModifyReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalEPPIDModifyReport.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalEPPIDModifyReport.Location = New System.Drawing.Point(183, 149)
        Me.lblSignalEPPIDModifyReport.Name = "lblSignalEPPIDModifyReport"
        Me.lblSignalEPPIDModifyReport.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalEPPIDModifyReport.TabIndex = 19
        Me.lblSignalEPPIDModifyReport.Text = "EPPID Modify Report"
        Me.lblSignalEPPIDModifyReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalGxEraseReport
        '
        Me.lblSignalGxEraseReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxEraseReport.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxEraseReport.Location = New System.Drawing.Point(10, 149)
        Me.lblSignalGxEraseReport.Name = "lblSignalGxEraseReport"
        Me.lblSignalGxEraseReport.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalGxEraseReport.TabIndex = 18
        Me.lblSignalGxEraseReport.Text = "Glass Erase Report"
        Me.lblSignalGxEraseReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalTRResetAck
        '
        Me.lblSignalTRResetAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalTRResetAck.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalTRResetAck.Location = New System.Drawing.Point(10, 114)
        Me.lblSignalTRResetAck.Name = "lblSignalTRResetAck"
        Me.lblSignalTRResetAck.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalTRResetAck.TabIndex = 17
        Me.lblSignalTRResetAck.Text = "Transfer Reset Ack"
        Me.lblSignalTRResetAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalExReady
        '
        Me.lblSignalExReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalExReady.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalExReady.Location = New System.Drawing.Point(356, 114)
        Me.lblSignalExReady.Name = "lblSignalExReady"
        Me.lblSignalExReady.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalExReady.TabIndex = 14
        Me.lblSignalExReady.Text = "EQ Ready(E)"
        Me.lblSignalExReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalExReq
        '
        Me.lblSignalExReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalExReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalExReq.Location = New System.Drawing.Point(183, 114)
        Me.lblSignalExReq.Name = "lblSignalExReq"
        Me.lblSignalExReq.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalExReq.TabIndex = 13
        Me.lblSignalExReq.Text = "Exchange Request"
        Me.lblSignalExReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalUnloadReady
        '
        Me.lblSignalUnloadReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalUnloadReady.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalUnloadReady.Location = New System.Drawing.Point(356, 79)
        Me.lblSignalUnloadReady.Name = "lblSignalUnloadReady"
        Me.lblSignalUnloadReady.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalUnloadReady.TabIndex = 12
        Me.lblSignalUnloadReady.Text = "EQ Ready(U)"
        Me.lblSignalUnloadReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalUnloadReq
        '
        Me.lblSignalUnloadReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalUnloadReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalUnloadReq.Location = New System.Drawing.Point(183, 79)
        Me.lblSignalUnloadReq.Name = "lblSignalUnloadReq"
        Me.lblSignalUnloadReq.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalUnloadReq.TabIndex = 11
        Me.lblSignalUnloadReq.Text = "Unload Request"
        Me.lblSignalUnloadReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalLoadReady
        '
        Me.lblSignalLoadReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalLoadReady.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalLoadReady.Location = New System.Drawing.Point(356, 44)
        Me.lblSignalLoadReady.Name = "lblSignalLoadReady"
        Me.lblSignalLoadReady.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalLoadReady.TabIndex = 10
        Me.lblSignalLoadReady.Text = "EQ Ready(L)"
        Me.lblSignalLoadReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalLoadReq
        '
        Me.lblSignalLoadReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalLoadReq.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalLoadReq.Location = New System.Drawing.Point(183, 44)
        Me.lblSignalLoadReq.Name = "lblSignalLoadReq"
        Me.lblSignalLoadReq.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalLoadReq.TabIndex = 9
        Me.lblSignalLoadReq.Text = "Load Request"
        Me.lblSignalLoadReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalAlarmOccurred
        '
        Me.lblSignalAlarmOccurred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalAlarmOccurred.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalAlarmOccurred.Location = New System.Drawing.Point(10, 79)
        Me.lblSignalAlarmOccurred.Name = "lblSignalAlarmOccurred"
        Me.lblSignalAlarmOccurred.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalAlarmOccurred.TabIndex = 8
        Me.lblSignalAlarmOccurred.Text = "Alarm Occurred"
        Me.lblSignalAlarmOccurred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalHandoff
        '
        Me.lblSignalHandoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalHandoff.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalHandoff.Location = New System.Drawing.Point(10, 44)
        Me.lblSignalHandoff.Name = "lblSignalHandoff"
        Me.lblSignalHandoff.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalHandoff.TabIndex = 5
        Me.lblSignalHandoff.Text = "Handoff Available"
        Me.lblSignalHandoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalGxInProcess
        '
        Me.lblSignalGxInProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxInProcess.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxInProcess.Location = New System.Drawing.Point(529, 9)
        Me.lblSignalGxInProcess.Name = "lblSignalGxInProcess"
        Me.lblSignalGxInProcess.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalGxInProcess.TabIndex = 4
        Me.lblSignalGxInProcess.Text = "Glass In Process"
        Me.lblSignalGxInProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalGxOnStage
        '
        Me.lblSignalGxOnStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalGxOnStage.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalGxOnStage.Location = New System.Drawing.Point(356, 9)
        Me.lblSignalGxOnStage.Name = "lblSignalGxOnStage"
        Me.lblSignalGxOnStage.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalGxOnStage.TabIndex = 3
        Me.lblSignalGxOnStage.Text = "Glass Exist on Stage"
        Me.lblSignalGxOnStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSignalLinkTest
        '
        Me.lblSignalLinkTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSignalLinkTest.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSignalLinkTest.Location = New System.Drawing.Point(183, 9)
        Me.lblSignalLinkTest.Name = "lblSignalLinkTest"
        Me.lblSignalLinkTest.Size = New System.Drawing.Size(167, 30)
        Me.lblSignalLinkTest.TabIndex = 2
        Me.lblSignalLinkTest.Text = "Link Test Response"
        Me.lblSignalLinkTest.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRepairReviewMode
        '
        Me.cmdRepairReviewMode.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdRepairReviewMode.Location = New System.Drawing.Point(356, 184)
        Me.cmdRepairReviewMode.Name = "cmdRepairReviewMode"
        Me.cmdRepairReviewMode.Size = New System.Drawing.Size(167, 30)
        Me.cmdRepairReviewMode.TabIndex = 22
        Me.cmdRepairReviewMode.Text = "Repair Review Mode"
        Me.cmdRepairReviewMode.UseVisualStyleBackColor = True
        '
        'OcxSignal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "OcxSignal"
        Me.Size = New System.Drawing.Size(900, 700)
        Me.TabControl1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents lblSignalLinkReq As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdEPPIDChkReq As System.Windows.Forms.Button
    Friend WithEvents cmdGxEraseAck As System.Windows.Forms.Button
    Friend WithEvents cmdTRResetReq As System.Windows.Forms.Button
    Friend WithEvents cmdEPPIDModifyAck As System.Windows.Forms.Button
    Friend WithEvents cmdExComp As System.Windows.Forms.Button
    Friend WithEvents cmdExPutBusy As System.Windows.Forms.Button
    Friend WithEvents cmdExGetBusy As System.Windows.Forms.Button
    Friend WithEvents cmdExTR As System.Windows.Forms.Button
    Friend WithEvents cmdUnloadComp As System.Windows.Forms.Button
    Friend WithEvents cmdUnloadBusy As System.Windows.Forms.Button
    Friend WithEvents cmdUnloadTR As System.Windows.Forms.Button
    Friend WithEvents cmdExStatus As System.Windows.Forms.Button
    Friend WithEvents cmdLoadComp As System.Windows.Forms.Button
    Friend WithEvents cmdLoadBusy As System.Windows.Forms.Button
    Friend WithEvents cmdLoadTR As System.Windows.Forms.Button
    Friend WithEvents cmdTransferMode As System.Windows.Forms.Button
    Friend WithEvents cmdArmMode As System.Windows.Forms.Button
    Friend WithEvents cmdIgnoreTimeout As System.Windows.Forms.Button
    Friend WithEvents cmdLinkTest As System.Windows.Forms.Button
    Friend WithEvents cmdLinkReq As System.Windows.Forms.Button
    Friend WithEvents lblSignalEPPIDChkAck As System.Windows.Forms.Label
    Friend WithEvents lblSignalEPPIDModifyReport As System.Windows.Forms.Label
    Friend WithEvents lblSignalGxEraseReport As System.Windows.Forms.Label
    Friend WithEvents lblSignalTRResetAck As System.Windows.Forms.Label
    Friend WithEvents lblSignalExReady As System.Windows.Forms.Label
    Friend WithEvents lblSignalExReq As System.Windows.Forms.Label
    Friend WithEvents lblSignalUnloadReady As System.Windows.Forms.Label
    Friend WithEvents lblSignalUnloadReq As System.Windows.Forms.Label
    Friend WithEvents lblSignalLoadReady As System.Windows.Forms.Label
    Friend WithEvents lblSignalLoadReq As System.Windows.Forms.Label
    Friend WithEvents lblSignalAlarmOccurred As System.Windows.Forms.Label
    Friend WithEvents lblSignalHandoff As System.Windows.Forms.Label
    Friend WithEvents lblSignalGxInProcess As System.Windows.Forms.Label
    Friend WithEvents lblSignalGxOnStage As System.Windows.Forms.Label
    Friend WithEvents lblSignalLinkTest As System.Windows.Forms.Label
    Friend WithEvents cmdInspectionFlag As System.Windows.Forms.Button
    Friend WithEvents cmdEPPIDQueryReq As System.Windows.Forms.Button
    Friend WithEvents lblSignalEPPIDQueryAck As System.Windows.Forms.Label
    Friend WithEvents cmdRepairReviewMode As System.Windows.Forms.Button

End Class
