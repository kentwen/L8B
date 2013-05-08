<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSim
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnS765DataDownload = New System.Windows.Forms.Button
        Me.GB_LotData = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cobRepairmode = New System.Windows.Forms.ComboBox
        Me.txtS756Slot1 = New System.Windows.Forms.TextBox
        Me.cobRunningMode = New System.Windows.Forms.ComboBox
        Me.cobTargetPos = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtGlassID = New System.Windows.Forms.TextBox
        Me.txtPortNo = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtWeek = New System.Windows.Forms.TextBox
        Me.btnRSTInitial = New System.Windows.Forms.Button
        Me.cobRSTCMDMode = New System.Windows.Forms.ComboBox
        Me.btnRSTCMDMode = New System.Windows.Forms.Button
        Me.cobSetRSTMode = New System.Windows.Forms.ComboBox
        Me.btnSetRSTMode = New System.Windows.Forms.Button
        Me.btnGetArmGxInfo = New System.Windows.Forms.Button
        Me.cobWriteArmGxInfo = New System.Windows.Forms.ComboBox
        Me.btnWriteArmGxInfo = New System.Windows.Forms.Button
        Me.btnWriteBufferGxInfo = New System.Windows.Forms.Button
        Me.cobRSTRemoteStatus = New System.Windows.Forms.ComboBox
        Me.btnRSTRemoteStatus = New System.Windows.Forms.Button
        Me.cobRunningMode1 = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.cobArmGxErase = New System.Windows.Forms.ComboBox
        Me.btnRSTArmGxErase = New System.Windows.Forms.Button
        Me.txtBufErasePosition = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.txtBufEraseSlot = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.btnRSTBufferGlassEraseRequest = New System.Windows.Forms.Button
        Me.cobLightTowerStatus = New System.Windows.Forms.ComboBox
        Me.cobLightTower = New System.Windows.Forms.ComboBox
        Me.btnRSTLightTowerControl = New System.Windows.Forms.Button
        Me.txtBuzzerMode = New System.Windows.Forms.TextBox
        Me.btnRSTBuzzerControlOff = New System.Windows.Forms.Button
        Me.btnRSTBuzzerControl = New System.Windows.Forms.Button
        Me.cobRSTSpeed = New System.Windows.Forms.ComboBox
        Me.cobRSTPosition = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cobRobotArm = New System.Windows.Forms.ComboBox
        Me.cobRobotToGo = New System.Windows.Forms.ComboBox
        Me.cobRobotAction = New System.Windows.Forms.ComboBox
        Me.txtSecond = New System.Windows.Forms.TextBox
        Me.txtMinute = New System.Windows.Forms.TextBox
        Me.txtHour = New System.Windows.Forms.TextBox
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.btnRSTInterfaceCheckOff = New System.Windows.Forms.Button
        Me.RSTInterfaceCheck = New System.Windows.Forms.Button
        Me.btnRSTResumeRequest = New System.Windows.Forms.Button
        Me.btnRSTPauseRequest = New System.Windows.Forms.Button
        Me.btnRSTErrorReset = New System.Windows.Forms.Button
        Me.btnSyncDateTime = New System.Windows.Forms.Button
        Me.txtRSTGlassType = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtRobotSlotNo = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.btnRSTCommand = New System.Windows.Forms.Button
        Me.btnShowGUICV = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSetZRAddr = New System.Windows.Forms.Button
        Me.btnSetZRAddrArray = New System.Windows.Forms.Button
        Me.btnSetWAddrArray = New System.Windows.Forms.Button
        Me.txtArrayLen = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtSetWAddrValue = New System.Windows.Forms.TextBox
        Me.txtSetWAddr = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.btnSetWAddr = New System.Windows.Forms.Button
        Me.btnSetBAddr = New System.Windows.Forms.Button
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtSetAddr = New System.Windows.Forms.TextBox
        Me.txtSetValue = New System.Windows.Forms.TextBox
        Me.btnShowGUIEQ = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtPortChangePortNo = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.cobPortType = New System.Windows.Forms.ComboBox
        Me.cobPortMode = New System.Windows.Forms.ComboBox
        Me.btnPortChangeRequest = New System.Windows.Forms.Button
        Me.txtProcesscmdCSTID = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtnProcessCount = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtProcesscmdPort = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.btnProcessCmd = New System.Windows.Forms.Button
        Me.btnCVPortResume = New System.Windows.Forms.Button
        Me.txtPausePortNo = New System.Windows.Forms.TextBox
        Me.btnCVPortPause = New System.Windows.Forms.Button
        Me.btnCVTransferResetReqOff = New System.Windows.Forms.Button
        Me.btnCVTransferResetReq = New System.Windows.Forms.Button
        Me.txtDCPortNo = New System.Windows.Forms.TextBox
        Me.btnCVDummyCancel = New System.Windows.Forms.Button
        Me.btnCVREQUnloadCST = New System.Windows.Forms.Button
        Me.txtREQUnloadCST = New System.Windows.Forms.TextBox
        Me.btnCVOnlineOff = New System.Windows.Forms.Button
        Me.btnCVOnline = New System.Windows.Forms.Button
        Me.btnShowTimeoutSet = New System.Windows.Forms.Button
        Me.btnSetNGGlasstoMachine = New System.Windows.Forms.Button
        Me.txtSetNgGxPort = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.txtSetNgGxSlot = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.btnRecipeCheck = New System.Windows.Forms.Button
        Me.txtRecipeCheckID = New System.Windows.Forms.TextBox
        Me.btnEQRSTOnline = New System.Windows.Forms.Button
        Me.txtEQIndex = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.btnEQRSTOnlineOff = New System.Windows.Forms.Button
        Me.btnEQTransferReset = New System.Windows.Forms.Button
        Me.btnEQIgnoreTimeout = New System.Windows.Forms.Button
        Me.IgnoreTimeoutOff = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnRecipeQuery = New System.Windows.Forms.Button
        Me.btnGetEQStatus = New System.Windows.Forms.Button
        Me.btnGetToolID = New System.Windows.Forms.Button
        Me.cobArmMode = New System.Windows.Forms.ComboBox
        Me.btnEQTranfserModeOff = New System.Windows.Forms.Button
        Me.btnEQTranfserMode = New System.Windows.Forms.Button
        Me.btnEQArmMode = New System.Windows.Forms.Button
        Me.btnShowGUICVOff = New System.Windows.Forms.Button
        Me.btnShowGUIEQOff = New System.Windows.Forms.Button
        Me.btnSetBufferSlotStatus = New System.Windows.Forms.Button
        Me.btnShowGeneralGUI = New System.Windows.Forms.Button
        Me.btnCloseGeneralGUI = New System.Windows.Forms.Button
        Me.btnShowSampleGxSetting = New System.Windows.Forms.Button
        Me.cobMachine = New System.Windows.Forms.ComboBox
        Me.btnGetCSTSlotData = New System.Windows.Forms.Button
        Me.txtGCSTPort = New System.Windows.Forms.TextBox
        Me.txtGCSTSlot = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnModeChange = New System.Windows.Forms.Button
        Me.txtModeChange = New System.Windows.Forms.TextBox
        Me.txtS756Slot2 = New System.Windows.Forms.TextBox
        Me.txtProcessFlag = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GB_LotData.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(635, 634)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 28)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnS765DataDownload
        '
        Me.btnS765DataDownload.Location = New System.Drawing.Point(33, 208)
        Me.btnS765DataDownload.Name = "btnS765DataDownload"
        Me.btnS765DataDownload.Size = New System.Drawing.Size(138, 28)
        Me.btnS765DataDownload.TabIndex = 29
        Me.btnS765DataDownload.Text = "S765 Data Download"
        Me.btnS765DataDownload.UseVisualStyleBackColor = True
        '
        'GB_LotData
        '
        Me.GB_LotData.Controls.Add(Me.txtS756Slot2)
        Me.GB_LotData.Controls.Add(Me.Label3)
        Me.GB_LotData.Controls.Add(Me.cobRepairmode)
        Me.GB_LotData.Controls.Add(Me.txtS756Slot1)
        Me.GB_LotData.Controls.Add(Me.cobRunningMode)
        Me.GB_LotData.Controls.Add(Me.cobTargetPos)
        Me.GB_LotData.Controls.Add(Me.Label26)
        Me.GB_LotData.Controls.Add(Me.txtGlassID)
        Me.GB_LotData.Controls.Add(Me.txtPortNo)
        Me.GB_LotData.Controls.Add(Me.Label24)
        Me.GB_LotData.Controls.Add(Me.Label10)
        Me.GB_LotData.Controls.Add(Me.Label8)
        Me.GB_LotData.Location = New System.Drawing.Point(33, 4)
        Me.GB_LotData.Name = "GB_LotData"
        Me.GB_LotData.Size = New System.Drawing.Size(351, 194)
        Me.GB_LotData.TabIndex = 30
        Me.GB_LotData.TabStop = False
        Me.GB_LotData.Text = "Lot Data"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(210, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Tape/Ink"
        '
        'cobRepairmode
        '
        Me.cobRepairmode.FormattingEnabled = True
        Me.cobRepairmode.Items.AddRange(New Object() {"Tape", "Ink"})
        Me.cobRepairmode.Location = New System.Drawing.Point(263, 90)
        Me.cobRepairmode.Name = "cobRepairmode"
        Me.cobRepairmode.Size = New System.Drawing.Size(59, 20)
        Me.cobRepairmode.TabIndex = 96
        '
        'txtS756Slot1
        '
        Me.txtS756Slot1.Location = New System.Drawing.Point(278, 15)
        Me.txtS756Slot1.Name = "txtS756Slot1"
        Me.txtS756Slot1.Size = New System.Drawing.Size(24, 22)
        Me.txtS756Slot1.TabIndex = 95
        Me.txtS756Slot1.Text = "1"
        '
        'cobRunningMode
        '
        Me.cobRunningMode.FormattingEnabled = True
        Me.cobRunningMode.Items.AddRange(New Object() {"None", "I Mode", "U Mode"})
        Me.cobRunningMode.Location = New System.Drawing.Point(98, 148)
        Me.cobRunningMode.Name = "cobRunningMode"
        Me.cobRunningMode.Size = New System.Drawing.Size(69, 20)
        Me.cobRunningMode.TabIndex = 94
        '
        'cobTargetPos
        '
        Me.cobTargetPos.FormattingEnabled = True
        Me.cobTargetPos.Items.AddRange(New Object() {"None", "EQ1", "EQ2", "EQ3", "EQ1EQ2", "EQ1EQ3", "EQ2EQ3", "EQ1EQ2EQ3"})
        Me.cobTargetPos.Location = New System.Drawing.Point(98, 94)
        Me.cobTargetPos.Name = "cobTargetPos"
        Me.cobTargetPos.Size = New System.Drawing.Size(91, 20)
        Me.cobTargetPos.TabIndex = 92
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(12, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(76, 12)
        Me.Label26.TabIndex = 82
        Me.Label26.Text = "Running Mode"
        '
        'txtGlassID
        '
        Me.txtGlassID.Location = New System.Drawing.Point(98, 54)
        Me.txtGlassID.Name = "txtGlassID"
        Me.txtGlassID.Size = New System.Drawing.Size(87, 22)
        Me.txtGlassID.TabIndex = 68
        Me.txtGlassID.Text = "GXID"
        '
        'txtPortNo
        '
        Me.txtPortNo.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtPortNo.Location = New System.Drawing.Point(100, 18)
        Me.txtPortNo.Name = "txtPortNo"
        Me.txtPortNo.Size = New System.Drawing.Size(48, 22)
        Me.txtPortNo.TabIndex = 66
        Me.txtPortNo.Text = "1"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 12)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "PortNo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 12)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Glass ID"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 12)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Target Position"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtWeek)
        Me.GroupBox3.Controls.Add(Me.btnRSTInitial)
        Me.GroupBox3.Controls.Add(Me.cobRSTCMDMode)
        Me.GroupBox3.Controls.Add(Me.btnRSTCMDMode)
        Me.GroupBox3.Controls.Add(Me.cobSetRSTMode)
        Me.GroupBox3.Controls.Add(Me.btnSetRSTMode)
        Me.GroupBox3.Controls.Add(Me.btnGetArmGxInfo)
        Me.GroupBox3.Controls.Add(Me.cobWriteArmGxInfo)
        Me.GroupBox3.Controls.Add(Me.btnWriteArmGxInfo)
        Me.GroupBox3.Controls.Add(Me.btnWriteBufferGxInfo)
        Me.GroupBox3.Controls.Add(Me.cobRSTRemoteStatus)
        Me.GroupBox3.Controls.Add(Me.btnRSTRemoteStatus)
        Me.GroupBox3.Controls.Add(Me.cobRunningMode1)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.cobArmGxErase)
        Me.GroupBox3.Controls.Add(Me.btnRSTArmGxErase)
        Me.GroupBox3.Controls.Add(Me.txtBufErasePosition)
        Me.GroupBox3.Controls.Add(Me.Label44)
        Me.GroupBox3.Controls.Add(Me.txtBufEraseSlot)
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.btnRSTBufferGlassEraseRequest)
        Me.GroupBox3.Controls.Add(Me.cobLightTowerStatus)
        Me.GroupBox3.Controls.Add(Me.cobLightTower)
        Me.GroupBox3.Controls.Add(Me.btnRSTLightTowerControl)
        Me.GroupBox3.Controls.Add(Me.txtBuzzerMode)
        Me.GroupBox3.Controls.Add(Me.btnRSTBuzzerControlOff)
        Me.GroupBox3.Controls.Add(Me.btnRSTBuzzerControl)
        Me.GroupBox3.Controls.Add(Me.cobRSTSpeed)
        Me.GroupBox3.Controls.Add(Me.cobRSTPosition)
        Me.GroupBox3.Controls.Add(Me.Label42)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cobRobotArm)
        Me.GroupBox3.Controls.Add(Me.cobRobotToGo)
        Me.GroupBox3.Controls.Add(Me.cobRobotAction)
        Me.GroupBox3.Controls.Add(Me.txtSecond)
        Me.GroupBox3.Controls.Add(Me.txtMinute)
        Me.GroupBox3.Controls.Add(Me.txtHour)
        Me.GroupBox3.Controls.Add(Me.txtDay)
        Me.GroupBox3.Controls.Add(Me.txtMonth)
        Me.GroupBox3.Controls.Add(Me.txtYear)
        Me.GroupBox3.Controls.Add(Me.btnRSTInterfaceCheckOff)
        Me.GroupBox3.Controls.Add(Me.RSTInterfaceCheck)
        Me.GroupBox3.Controls.Add(Me.btnRSTResumeRequest)
        Me.GroupBox3.Controls.Add(Me.btnRSTPauseRequest)
        Me.GroupBox3.Controls.Add(Me.btnRSTErrorReset)
        Me.GroupBox3.Controls.Add(Me.btnSyncDateTime)
        Me.GroupBox3.Controls.Add(Me.txtRSTGlassType)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.txtRobotSlotNo)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.btnRSTCommand)
        Me.GroupBox3.Location = New System.Drawing.Point(508, 160)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(515, 433)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "RST"
        '
        'txtWeek
        '
        Me.txtWeek.Location = New System.Drawing.Point(400, 269)
        Me.txtWeek.Name = "txtWeek"
        Me.txtWeek.Size = New System.Drawing.Size(34, 22)
        Me.txtWeek.TabIndex = 60
        Me.txtWeek.Text = "5"
        '
        'btnRSTInitial
        '
        Me.btnRSTInitial.Location = New System.Drawing.Point(9, 180)
        Me.btnRSTInitial.Name = "btnRSTInitial"
        Me.btnRSTInitial.Size = New System.Drawing.Size(107, 20)
        Me.btnRSTInitial.TabIndex = 59
        Me.btnRSTInitial.Text = "RST Initial"
        Me.btnRSTInitial.UseVisualStyleBackColor = True
        '
        'cobRSTCMDMode
        '
        Me.cobRSTCMDMode.FormattingEnabled = True
        Me.cobRSTCMDMode.Items.AddRange(New Object() {"NA", "Start", "Stop"})
        Me.cobRSTCMDMode.Location = New System.Drawing.Point(294, 144)
        Me.cobRSTCMDMode.Name = "cobRSTCMDMode"
        Me.cobRSTCMDMode.Size = New System.Drawing.Size(104, 20)
        Me.cobRSTCMDMode.TabIndex = 58
        '
        'btnRSTCMDMode
        '
        Me.btnRSTCMDMode.Location = New System.Drawing.Point(212, 144)
        Me.btnRSTCMDMode.Name = "btnRSTCMDMode"
        Me.btnRSTCMDMode.Size = New System.Drawing.Size(80, 21)
        Me.btnRSTCMDMode.TabIndex = 57
        Me.btnRSTCMDMode.Text = "RSTCmdMode"
        Me.btnRSTCMDMode.UseVisualStyleBackColor = True
        '
        'cobSetRSTMode
        '
        Me.cobSetRSTMode.FormattingEnabled = True
        Me.cobSetRSTMode.Items.AddRange(New Object() {"NA", "Auto", "Manual", "Engineer"})
        Me.cobSetRSTMode.Location = New System.Drawing.Point(102, 145)
        Me.cobSetRSTMode.Name = "cobSetRSTMode"
        Me.cobSetRSTMode.Size = New System.Drawing.Size(104, 20)
        Me.cobSetRSTMode.TabIndex = 56
        '
        'btnSetRSTMode
        '
        Me.btnSetRSTMode.Location = New System.Drawing.Point(16, 145)
        Me.btnSetRSTMode.Name = "btnSetRSTMode"
        Me.btnSetRSTMode.Size = New System.Drawing.Size(80, 21)
        Me.btnSetRSTMode.TabIndex = 55
        Me.btnSetRSTMode.Text = "SetRSTMode"
        Me.btnSetRSTMode.UseVisualStyleBackColor = True
        '
        'btnGetArmGxInfo
        '
        Me.btnGetArmGxInfo.Location = New System.Drawing.Point(287, 378)
        Me.btnGetArmGxInfo.Name = "btnGetArmGxInfo"
        Me.btnGetArmGxInfo.Size = New System.Drawing.Size(107, 21)
        Me.btnGetArmGxInfo.TabIndex = 54
        Me.btnGetArmGxInfo.Text = "GetArmGxInfo"
        Me.btnGetArmGxInfo.UseVisualStyleBackColor = True
        '
        'cobWriteArmGxInfo
        '
        Me.cobWriteArmGxInfo.FormattingEnabled = True
        Me.cobWriteArmGxInfo.Items.AddRange(New Object() {"Upper", "Lower"})
        Me.cobWriteArmGxInfo.Location = New System.Drawing.Point(400, 323)
        Me.cobWriteArmGxInfo.Name = "cobWriteArmGxInfo"
        Me.cobWriteArmGxInfo.Size = New System.Drawing.Size(104, 20)
        Me.cobWriteArmGxInfo.TabIndex = 53
        '
        'btnWriteArmGxInfo
        '
        Me.btnWriteArmGxInfo.Location = New System.Drawing.Point(287, 323)
        Me.btnWriteArmGxInfo.Name = "btnWriteArmGxInfo"
        Me.btnWriteArmGxInfo.Size = New System.Drawing.Size(107, 21)
        Me.btnWriteArmGxInfo.TabIndex = 52
        Me.btnWriteArmGxInfo.Text = "WriteArmGxInfo"
        Me.btnWriteArmGxInfo.UseVisualStyleBackColor = True
        '
        'btnWriteBufferGxInfo
        '
        Me.btnWriteBufferGxInfo.Location = New System.Drawing.Point(287, 296)
        Me.btnWriteBufferGxInfo.Name = "btnWriteBufferGxInfo"
        Me.btnWriteBufferGxInfo.Size = New System.Drawing.Size(107, 21)
        Me.btnWriteBufferGxInfo.TabIndex = 51
        Me.btnWriteBufferGxInfo.Text = "WriteBufferGxInfo"
        Me.btnWriteBufferGxInfo.UseVisualStyleBackColor = True
        '
        'cobRSTRemoteStatus
        '
        Me.cobRSTRemoteStatus.FormattingEnabled = True
        Me.cobRSTRemoteStatus.Items.AddRange(New Object() {"OffLine", "OnLineCTL", "OnLineMon"})
        Me.cobRSTRemoteStatus.Location = New System.Drawing.Point(402, 233)
        Me.cobRSTRemoteStatus.Name = "cobRSTRemoteStatus"
        Me.cobRSTRemoteStatus.Size = New System.Drawing.Size(104, 20)
        Me.cobRSTRemoteStatus.TabIndex = 50
        '
        'btnRSTRemoteStatus
        '
        Me.btnRSTRemoteStatus.Location = New System.Drawing.Point(290, 232)
        Me.btnRSTRemoteStatus.Name = "btnRSTRemoteStatus"
        Me.btnRSTRemoteStatus.Size = New System.Drawing.Size(107, 21)
        Me.btnRSTRemoteStatus.TabIndex = 49
        Me.btnRSTRemoteStatus.Text = "RSTRemoteStatus"
        Me.btnRSTRemoteStatus.UseVisualStyleBackColor = True
        '
        'cobRunningMode1
        '
        Me.cobRunningMode1.FormattingEnabled = True
        Me.cobRunningMode1.Items.AddRange(New Object() {"None", "MQC Mode", "Through Mode"})
        Me.cobRunningMode1.Location = New System.Drawing.Point(145, 404)
        Me.cobRunningMode1.Name = "cobRunningMode1"
        Me.cobRunningMode1.Size = New System.Drawing.Size(104, 20)
        Me.cobRunningMode1.TabIndex = 46
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 405)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 21)
        Me.Button2.TabIndex = 45
        Me.Button2.Text = "RunningMode"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cobArmGxErase
        '
        Me.cobArmGxErase.FormattingEnabled = True
        Me.cobArmGxErase.Items.AddRange(New Object() {"Upper", "Lower"})
        Me.cobArmGxErase.Location = New System.Drawing.Point(145, 378)
        Me.cobArmGxErase.Name = "cobArmGxErase"
        Me.cobArmGxErase.Size = New System.Drawing.Size(104, 20)
        Me.cobArmGxErase.TabIndex = 44
        '
        'btnRSTArmGxErase
        '
        Me.btnRSTArmGxErase.Location = New System.Drawing.Point(9, 378)
        Me.btnRSTArmGxErase.Name = "btnRSTArmGxErase"
        Me.btnRSTArmGxErase.Size = New System.Drawing.Size(130, 21)
        Me.btnRSTArmGxErase.TabIndex = 43
        Me.btnRSTArmGxErase.Text = "RST Arm Gx Erase"
        Me.btnRSTArmGxErase.UseVisualStyleBackColor = True
        '
        'txtBufErasePosition
        '
        Me.txtBufErasePosition.Location = New System.Drawing.Point(262, 350)
        Me.txtBufErasePosition.Name = "txtBufErasePosition"
        Me.txtBufErasePosition.Size = New System.Drawing.Size(33, 22)
        Me.txtBufErasePosition.TabIndex = 42
        Me.txtBufErasePosition.Text = "2"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(214, 355)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(42, 12)
        Me.Label44.TabIndex = 41
        Me.Label44.Text = "Position"
        '
        'txtBufEraseSlot
        '
        Me.txtBufEraseSlot.Location = New System.Drawing.Point(173, 350)
        Me.txtBufEraseSlot.Name = "txtBufEraseSlot"
        Me.txtBufEraseSlot.Size = New System.Drawing.Size(33, 22)
        Me.txtBufEraseSlot.TabIndex = 40
        Me.txtBufEraseSlot.Text = "5"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(144, 353)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(23, 12)
        Me.Label43.TabIndex = 39
        Me.Label43.Text = "Slot"
        '
        'btnRSTBufferGlassEraseRequest
        '
        Me.btnRSTBufferGlassEraseRequest.Location = New System.Drawing.Point(9, 351)
        Me.btnRSTBufferGlassEraseRequest.Name = "btnRSTBufferGlassEraseRequest"
        Me.btnRSTBufferGlassEraseRequest.Size = New System.Drawing.Size(130, 21)
        Me.btnRSTBufferGlassEraseRequest.TabIndex = 38
        Me.btnRSTBufferGlassEraseRequest.Text = "RSTBuf Gx Erase Req"
        Me.btnRSTBufferGlassEraseRequest.UseVisualStyleBackColor = True
        '
        'cobLightTowerStatus
        '
        Me.cobLightTowerStatus.FormattingEnabled = True
        Me.cobLightTowerStatus.Items.AddRange(New Object() {"Off", "On", "Blink"})
        Me.cobLightTowerStatus.Location = New System.Drawing.Point(216, 325)
        Me.cobLightTowerStatus.Name = "cobLightTowerStatus"
        Me.cobLightTowerStatus.Size = New System.Drawing.Size(65, 20)
        Me.cobLightTowerStatus.TabIndex = 37
        '
        'cobLightTower
        '
        Me.cobLightTower.FormattingEnabled = True
        Me.cobLightTower.Items.AddRange(New Object() {"R", "Y", "G"})
        Me.cobLightTower.Location = New System.Drawing.Point(145, 325)
        Me.cobLightTower.Name = "cobLightTower"
        Me.cobLightTower.Size = New System.Drawing.Size(65, 20)
        Me.cobLightTower.TabIndex = 36
        '
        'btnRSTLightTowerControl
        '
        Me.btnRSTLightTowerControl.Location = New System.Drawing.Point(9, 324)
        Me.btnRSTLightTowerControl.Name = "btnRSTLightTowerControl"
        Me.btnRSTLightTowerControl.Size = New System.Drawing.Size(130, 21)
        Me.btnRSTLightTowerControl.TabIndex = 35
        Me.btnRSTLightTowerControl.Text = "RSTLightTowerControl"
        Me.btnRSTLightTowerControl.UseVisualStyleBackColor = True
        '
        'txtBuzzerMode
        '
        Me.txtBuzzerMode.Location = New System.Drawing.Point(178, 299)
        Me.txtBuzzerMode.Name = "txtBuzzerMode"
        Me.txtBuzzerMode.Size = New System.Drawing.Size(32, 22)
        Me.txtBuzzerMode.TabIndex = 34
        Me.txtBuzzerMode.Text = "1"
        '
        'btnRSTBuzzerControlOff
        '
        Me.btnRSTBuzzerControlOff.Location = New System.Drawing.Point(134, 297)
        Me.btnRSTBuzzerControlOff.Name = "btnRSTBuzzerControlOff"
        Me.btnRSTBuzzerControlOff.Size = New System.Drawing.Size(33, 20)
        Me.btnRSTBuzzerControlOff.TabIndex = 33
        Me.btnRSTBuzzerControlOff.Text = "OFF"
        Me.btnRSTBuzzerControlOff.UseVisualStyleBackColor = True
        '
        'btnRSTBuzzerControl
        '
        Me.btnRSTBuzzerControl.Location = New System.Drawing.Point(9, 297)
        Me.btnRSTBuzzerControl.Name = "btnRSTBuzzerControl"
        Me.btnRSTBuzzerControl.Size = New System.Drawing.Size(116, 21)
        Me.btnRSTBuzzerControl.TabIndex = 32
        Me.btnRSTBuzzerControl.Text = "RSTBuzzerControl"
        Me.btnRSTBuzzerControl.UseVisualStyleBackColor = True
        '
        'cobRSTSpeed
        '
        Me.cobRSTSpeed.FormattingEnabled = True
        Me.cobRSTSpeed.Items.AddRange(New Object() {"None", "Low", "Mid", "Hi"})
        Me.cobRSTSpeed.Location = New System.Drawing.Point(263, 78)
        Me.cobRSTSpeed.Name = "cobRSTSpeed"
        Me.cobRSTSpeed.Size = New System.Drawing.Size(104, 20)
        Me.cobRSTSpeed.TabIndex = 31
        '
        'cobRSTPosition
        '
        Me.cobRSTPosition.FormattingEnabled = True
        Me.cobRSTPosition.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cobRSTPosition.Location = New System.Drawing.Point(263, 48)
        Me.cobRSTPosition.Name = "cobRSTPosition"
        Me.cobRSTPosition.Size = New System.Drawing.Size(104, 20)
        Me.cobRSTPosition.TabIndex = 30
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(201, 81)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(33, 12)
        Me.Label42.TabIndex = 29
        Me.Label42.Text = "Speed"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(201, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 12)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "NO"
        '
        'cobRobotArm
        '
        Me.cobRobotArm.FormattingEnabled = True
        Me.cobRobotArm.Items.AddRange(New Object() {"Upper", "Lower"})
        Me.cobRobotArm.Location = New System.Drawing.Point(81, 78)
        Me.cobRobotArm.Name = "cobRobotArm"
        Me.cobRobotArm.Size = New System.Drawing.Size(104, 20)
        Me.cobRobotArm.TabIndex = 27
        '
        'cobRobotToGo
        '
        Me.cobRobotToGo.FormattingEnabled = True
        Me.cobRobotToGo.Items.AddRange(New Object() {"EQ", "Buffer", "CV"})
        Me.cobRobotToGo.Location = New System.Drawing.Point(81, 49)
        Me.cobRobotToGo.Name = "cobRobotToGo"
        Me.cobRobotToGo.Size = New System.Drawing.Size(104, 20)
        Me.cobRobotToGo.TabIndex = 26
        '
        'cobRobotAction
        '
        Me.cobRobotAction.FormattingEnabled = True
        Me.cobRobotAction.Items.AddRange(New Object() {"None", "Get", "Put", "Exchange", "Get Wait", "Put Wait", "Home"})
        Me.cobRobotAction.Location = New System.Drawing.Point(81, 107)
        Me.cobRobotAction.Name = "cobRobotAction"
        Me.cobRobotAction.Size = New System.Drawing.Size(104, 20)
        Me.cobRobotAction.TabIndex = 25
        '
        'txtSecond
        '
        Me.txtSecond.Location = New System.Drawing.Point(355, 269)
        Me.txtSecond.Name = "txtSecond"
        Me.txtSecond.Size = New System.Drawing.Size(34, 22)
        Me.txtSecond.TabIndex = 24
        Me.txtSecond.Text = "30"
        '
        'txtMinute
        '
        Me.txtMinute.Location = New System.Drawing.Point(315, 269)
        Me.txtMinute.Name = "txtMinute"
        Me.txtMinute.Size = New System.Drawing.Size(34, 22)
        Me.txtMinute.TabIndex = 23
        Me.txtMinute.Text = "20"
        '
        'txtHour
        '
        Me.txtHour.Location = New System.Drawing.Point(275, 269)
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(34, 22)
        Me.txtHour.TabIndex = 22
        Me.txtHour.Text = "10"
        '
        'txtDay
        '
        Me.txtDay.Location = New System.Drawing.Point(217, 269)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(34, 22)
        Me.txtDay.TabIndex = 21
        Me.txtDay.Text = "18"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(176, 269)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(35, 22)
        Me.txtMonth.TabIndex = 20
        Me.txtMonth.Text = "6"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(127, 269)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(43, 22)
        Me.txtYear.TabIndex = 19
        Me.txtYear.Text = "2010"
        '
        'btnRSTInterfaceCheckOff
        '
        Me.btnRSTInterfaceCheckOff.Location = New System.Drawing.Point(240, 243)
        Me.btnRSTInterfaceCheckOff.Name = "btnRSTInterfaceCheckOff"
        Me.btnRSTInterfaceCheckOff.Size = New System.Drawing.Size(33, 20)
        Me.btnRSTInterfaceCheckOff.TabIndex = 18
        Me.btnRSTInterfaceCheckOff.Text = "OFF"
        Me.btnRSTInterfaceCheckOff.UseVisualStyleBackColor = True
        '
        'RSTInterfaceCheck
        '
        Me.RSTInterfaceCheck.Location = New System.Drawing.Point(127, 243)
        Me.RSTInterfaceCheck.Name = "RSTInterfaceCheck"
        Me.RSTInterfaceCheck.Size = New System.Drawing.Size(107, 20)
        Me.RSTInterfaceCheck.TabIndex = 17
        Me.RSTInterfaceCheck.Text = "RSTInterfaceCheck"
        Me.RSTInterfaceCheck.UseVisualStyleBackColor = True
        '
        'btnRSTResumeRequest
        '
        Me.btnRSTResumeRequest.Location = New System.Drawing.Point(7, 232)
        Me.btnRSTResumeRequest.Name = "btnRSTResumeRequest"
        Me.btnRSTResumeRequest.Size = New System.Drawing.Size(107, 20)
        Me.btnRSTResumeRequest.TabIndex = 16
        Me.btnRSTResumeRequest.Text = "RSTResumeRequest"
        Me.btnRSTResumeRequest.UseVisualStyleBackColor = True
        '
        'btnRSTPauseRequest
        '
        Me.btnRSTPauseRequest.Location = New System.Drawing.Point(9, 206)
        Me.btnRSTPauseRequest.Name = "btnRSTPauseRequest"
        Me.btnRSTPauseRequest.Size = New System.Drawing.Size(107, 20)
        Me.btnRSTPauseRequest.TabIndex = 15
        Me.btnRSTPauseRequest.Text = "RSTPauseRequest"
        Me.btnRSTPauseRequest.UseVisualStyleBackColor = True
        '
        'btnRSTErrorReset
        '
        Me.btnRSTErrorReset.Location = New System.Drawing.Point(402, 171)
        Me.btnRSTErrorReset.Name = "btnRSTErrorReset"
        Me.btnRSTErrorReset.Size = New System.Drawing.Size(107, 20)
        Me.btnRSTErrorReset.TabIndex = 14
        Me.btnRSTErrorReset.Text = "RST AlarmReset"
        Me.btnRSTErrorReset.UseVisualStyleBackColor = True
        '
        'btnSyncDateTime
        '
        Me.btnSyncDateTime.Location = New System.Drawing.Point(12, 271)
        Me.btnSyncDateTime.Name = "btnSyncDateTime"
        Me.btnSyncDateTime.Size = New System.Drawing.Size(107, 20)
        Me.btnSyncDateTime.TabIndex = 13
        Me.btnSyncDateTime.Text = "RST SyncDateTime"
        Me.btnSyncDateTime.UseVisualStyleBackColor = True
        '
        'txtRSTGlassType
        '
        Me.txtRSTGlassType.Location = New System.Drawing.Point(454, 74)
        Me.txtRSTGlassType.Name = "txtRSTGlassType"
        Me.txtRSTGlassType.Size = New System.Drawing.Size(32, 22)
        Me.txtRSTGlassType.TabIndex = 10
        Me.txtRSTGlassType.Text = "3"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(395, 79)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 12)
        Me.Label35.TabIndex = 9
        Me.Label35.Text = "GlassType"
        '
        'txtRobotSlotNo
        '
        Me.txtRobotSlotNo.Location = New System.Drawing.Point(454, 45)
        Me.txtRobotSlotNo.Name = "txtRobotSlotNo"
        Me.txtRobotSlotNo.Size = New System.Drawing.Size(32, 22)
        Me.txtRobotSlotNo.TabIndex = 8
        Me.txtRobotSlotNo.Text = "10"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(411, 49)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(37, 12)
        Me.Label34.TabIndex = 7
        Me.Label34.Text = "SlotNo"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(10, 108)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(65, 12)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "RobotAction"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(14, 81)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(55, 12)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "RobotArm"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(14, 56)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 12)
        Me.Label31.TabIndex = 2
        Me.Label31.Text = "RobotToGo"
        '
        'btnRSTCommand
        '
        Me.btnRSTCommand.Location = New System.Drawing.Point(8, 21)
        Me.btnRSTCommand.Name = "btnRSTCommand"
        Me.btnRSTCommand.Size = New System.Drawing.Size(107, 20)
        Me.btnRSTCommand.TabIndex = 0
        Me.btnRSTCommand.Text = "RSTCommand"
        Me.btnRSTCommand.UseVisualStyleBackColor = True
        '
        'btnShowGUICV
        '
        Me.btnShowGUICV.Location = New System.Drawing.Point(506, 599)
        Me.btnShowGUICV.Name = "btnShowGUICV"
        Me.btnShowGUICV.Size = New System.Drawing.Size(75, 23)
        Me.btnShowGUICV.TabIndex = 36
        Me.btnShowGUICV.Text = "ShowGUICV"
        Me.btnShowGUICV.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSetZRAddr)
        Me.GroupBox1.Controls.Add(Me.btnSetZRAddrArray)
        Me.GroupBox1.Controls.Add(Me.btnSetWAddrArray)
        Me.GroupBox1.Controls.Add(Me.txtArrayLen)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.txtSetWAddrValue)
        Me.GroupBox1.Controls.Add(Me.txtSetWAddr)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.btnSetWAddr)
        Me.GroupBox1.Controls.Add(Me.btnSetBAddr)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.txtSetAddr)
        Me.GroupBox1.Controls.Add(Me.txtSetValue)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 574)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 120)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test "
        Me.GroupBox1.Visible = False
        '
        'btnSetZRAddr
        '
        Me.btnSetZRAddr.Location = New System.Drawing.Point(196, 91)
        Me.btnSetZRAddr.Name = "btnSetZRAddr"
        Me.btnSetZRAddr.Size = New System.Drawing.Size(75, 23)
        Me.btnSetZRAddr.TabIndex = 43
        Me.btnSetZRAddr.Text = "Set ZR"
        Me.btnSetZRAddr.UseVisualStyleBackColor = True
        '
        'btnSetZRAddrArray
        '
        Me.btnSetZRAddrArray.Location = New System.Drawing.Point(94, 91)
        Me.btnSetZRAddrArray.Name = "btnSetZRAddrArray"
        Me.btnSetZRAddrArray.Size = New System.Drawing.Size(75, 23)
        Me.btnSetZRAddrArray.TabIndex = 42
        Me.btnSetZRAddrArray.Text = "Set ZR Array"
        Me.btnSetZRAddrArray.UseVisualStyleBackColor = True
        '
        'btnSetWAddrArray
        '
        Me.btnSetWAddrArray.Location = New System.Drawing.Point(8, 55)
        Me.btnSetWAddrArray.Name = "btnSetWAddrArray"
        Me.btnSetWAddrArray.Size = New System.Drawing.Size(75, 23)
        Me.btnSetWAddrArray.TabIndex = 41
        Me.btnSetWAddrArray.Text = "Set W Array"
        Me.btnSetWAddrArray.UseVisualStyleBackColor = True
        '
        'txtArrayLen
        '
        Me.txtArrayLen.Location = New System.Drawing.Point(380, 55)
        Me.txtArrayLen.Name = "txtArrayLen"
        Me.txtArrayLen.Size = New System.Drawing.Size(29, 22)
        Me.txtArrayLen.TabIndex = 40
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(302, 60)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(81, 12)
        Me.Label39.TabIndex = 39
        Me.Label39.Text = "WordArrayLEN"
        '
        'txtSetWAddrValue
        '
        Me.txtSetWAddrValue.Location = New System.Drawing.Point(198, 55)
        Me.txtSetWAddrValue.Name = "txtSetWAddrValue"
        Me.txtSetWAddrValue.Size = New System.Drawing.Size(99, 22)
        Me.txtSetWAddrValue.TabIndex = 38
        Me.txtSetWAddrValue.Text = "ABCD01"
        '
        'txtSetWAddr
        '
        Me.txtSetWAddr.Location = New System.Drawing.Point(144, 55)
        Me.txtSetWAddr.Name = "txtSetWAddr"
        Me.txtSetWAddr.Size = New System.Drawing.Size(48, 22)
        Me.txtSetWAddr.TabIndex = 37
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(87, 60)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(59, 12)
        Me.Label36.TabIndex = 36
        Me.Label36.Text = "Word Addr"
        '
        'btnSetWAddr
        '
        Me.btnSetWAddr.Location = New System.Drawing.Point(8, 91)
        Me.btnSetWAddr.Name = "btnSetWAddr"
        Me.btnSetWAddr.Size = New System.Drawing.Size(75, 23)
        Me.btnSetWAddr.TabIndex = 35
        Me.btnSetWAddr.Text = "Set W"
        Me.btnSetWAddr.UseVisualStyleBackColor = True
        '
        'btnSetBAddr
        '
        Me.btnSetBAddr.Location = New System.Drawing.Point(8, 18)
        Me.btnSetBAddr.Name = "btnSetBAddr"
        Me.btnSetBAddr.Size = New System.Drawing.Size(75, 23)
        Me.btnSetBAddr.TabIndex = 34
        Me.btnSetBAddr.Text = "Set B"
        Me.btnSetBAddr.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(92, 23)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(29, 12)
        Me.Label37.TabIndex = 32
        Me.Label37.Text = "Addr"
        '
        'txtSetAddr
        '
        Me.txtSetAddr.Location = New System.Drawing.Point(144, 14)
        Me.txtSetAddr.Name = "txtSetAddr"
        Me.txtSetAddr.Size = New System.Drawing.Size(48, 22)
        Me.txtSetAddr.TabIndex = 31
        Me.txtSetAddr.Text = "0"
        '
        'txtSetValue
        '
        Me.txtSetValue.Location = New System.Drawing.Point(198, 14)
        Me.txtSetValue.Name = "txtSetValue"
        Me.txtSetValue.Size = New System.Drawing.Size(26, 22)
        Me.txtSetValue.TabIndex = 30
        '
        'btnShowGUIEQ
        '
        Me.btnShowGUIEQ.Location = New System.Drawing.Point(630, 600)
        Me.btnShowGUIEQ.Name = "btnShowGUIEQ"
        Me.btnShowGUIEQ.Size = New System.Drawing.Size(75, 23)
        Me.btnShowGUIEQ.TabIndex = 38
        Me.btnShowGUIEQ.Text = "ShowGUIEQ"
        Me.btnShowGUIEQ.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtProcessFlag)
        Me.GroupBox4.Controls.Add(Me.txtPortChangePortNo)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.cobPortType)
        Me.GroupBox4.Controls.Add(Me.cobPortMode)
        Me.GroupBox4.Controls.Add(Me.btnPortChangeRequest)
        Me.GroupBox4.Controls.Add(Me.txtProcesscmdCSTID)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.txtnProcessCount)
        Me.GroupBox4.Controls.Add(Me.Label41)
        Me.GroupBox4.Controls.Add(Me.txtProcesscmdPort)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.btnProcessCmd)
        Me.GroupBox4.Controls.Add(Me.btnCVPortResume)
        Me.GroupBox4.Controls.Add(Me.txtPausePortNo)
        Me.GroupBox4.Controls.Add(Me.btnCVPortPause)
        Me.GroupBox4.Controls.Add(Me.btnCVTransferResetReqOff)
        Me.GroupBox4.Controls.Add(Me.btnCVTransferResetReq)
        Me.GroupBox4.Controls.Add(Me.txtDCPortNo)
        Me.GroupBox4.Controls.Add(Me.btnCVDummyCancel)
        Me.GroupBox4.Controls.Add(Me.btnCVREQUnloadCST)
        Me.GroupBox4.Controls.Add(Me.txtREQUnloadCST)
        Me.GroupBox4.Controls.Add(Me.btnCVOnlineOff)
        Me.GroupBox4.Controls.Add(Me.btnCVOnline)
        Me.GroupBox4.Location = New System.Drawing.Point(33, 251)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(439, 227)
        Me.GroupBox4.TabIndex = 40
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CV"
        '
        'txtPortChangePortNo
        '
        Me.txtPortChangePortNo.Location = New System.Drawing.Point(129, 165)
        Me.txtPortChangePortNo.Name = "txtPortChangePortNo"
        Me.txtPortChangePortNo.Size = New System.Drawing.Size(24, 22)
        Me.txtPortChangePortNo.TabIndex = 45
        Me.txtPortChangePortNo.Text = "1"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(119, 168)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(11, 12)
        Me.Label49.TabIndex = 44
        Me.Label49.Text = "P"
        '
        'cobPortType
        '
        Me.cobPortType.FormattingEnabled = True
        Me.cobPortType.Items.AddRange(New Object() {"None", "Auto", "OK", "NG", "GRAY", "MIX", "MIX NG"})
        Me.cobPortType.Location = New System.Drawing.Point(264, 167)
        Me.cobPortType.Name = "cobPortType"
        Me.cobPortType.Size = New System.Drawing.Size(102, 20)
        Me.cobPortType.TabIndex = 43
        '
        'cobPortMode
        '
        Me.cobPortMode.FormattingEnabled = True
        Me.cobPortMode.Items.AddRange(New Object() {"None", "Loade Mode", "Unload Mode"})
        Me.cobPortMode.Location = New System.Drawing.Point(159, 166)
        Me.cobPortMode.Name = "cobPortMode"
        Me.cobPortMode.Size = New System.Drawing.Size(92, 20)
        Me.cobPortMode.TabIndex = 42
        '
        'btnPortChangeRequest
        '
        Me.btnPortChangeRequest.Location = New System.Drawing.Point(8, 164)
        Me.btnPortChangeRequest.Name = "btnPortChangeRequest"
        Me.btnPortChangeRequest.Size = New System.Drawing.Size(106, 23)
        Me.btnPortChangeRequest.TabIndex = 41
        Me.btnPortChangeRequest.Text = "Port Change Req"
        Me.btnPortChangeRequest.UseVisualStyleBackColor = True
        '
        'txtProcesscmdCSTID
        '
        Me.txtProcesscmdCSTID.Location = New System.Drawing.Point(313, 137)
        Me.txtProcesscmdCSTID.Name = "txtProcesscmdCSTID"
        Me.txtProcesscmdCSTID.Size = New System.Drawing.Size(53, 22)
        Me.txtProcesscmdCSTID.TabIndex = 40
        Me.txtProcesscmdCSTID.Text = "CSTID1"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(269, 140)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(38, 12)
        Me.Label48.TabIndex = 39
        Me.Label48.Text = "CSTID"
        '
        'txtnProcessCount
        '
        Me.txtnProcessCount.Location = New System.Drawing.Point(234, 137)
        Me.txtnProcessCount.Name = "txtnProcessCount"
        Me.txtnProcessCount.Size = New System.Drawing.Size(33, 22)
        Me.txtnProcessCount.TabIndex = 38
        Me.txtnProcessCount.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(162, 140)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(68, 12)
        Me.Label41.TabIndex = 37
        Me.Label41.Text = "ProcessCount"
        '
        'txtProcesscmdPort
        '
        Me.txtProcesscmdPort.Location = New System.Drawing.Point(129, 137)
        Me.txtProcesscmdPort.Name = "txtProcesscmdPort"
        Me.txtProcesscmdPort.Size = New System.Drawing.Size(24, 22)
        Me.txtProcesscmdPort.TabIndex = 36
        Me.txtProcesscmdPort.Text = "1"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(119, 140)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 12)
        Me.Label40.TabIndex = 35
        Me.Label40.Text = "P"
        '
        'btnProcessCmd
        '
        Me.btnProcessCmd.Location = New System.Drawing.Point(8, 135)
        Me.btnProcessCmd.Name = "btnProcessCmd"
        Me.btnProcessCmd.Size = New System.Drawing.Size(106, 23)
        Me.btnProcessCmd.TabIndex = 34
        Me.btnProcessCmd.Text = "ProcessCmd"
        Me.btnProcessCmd.UseVisualStyleBackColor = True
        '
        'btnCVPortResume
        '
        Me.btnCVPortResume.Location = New System.Drawing.Point(230, 42)
        Me.btnCVPortResume.Name = "btnCVPortResume"
        Me.btnCVPortResume.Size = New System.Drawing.Size(121, 22)
        Me.btnCVPortResume.TabIndex = 33
        Me.btnCVPortResume.Text = "CV Port Resume"
        Me.btnCVPortResume.UseVisualStyleBackColor = True
        '
        'txtPausePortNo
        '
        Me.txtPausePortNo.Location = New System.Drawing.Point(357, 26)
        Me.txtPausePortNo.Name = "txtPausePortNo"
        Me.txtPausePortNo.Size = New System.Drawing.Size(33, 22)
        Me.txtPausePortNo.TabIndex = 32
        Me.txtPausePortNo.Text = "1"
        '
        'btnCVPortPause
        '
        Me.btnCVPortPause.Location = New System.Drawing.Point(230, 16)
        Me.btnCVPortPause.Name = "btnCVPortPause"
        Me.btnCVPortPause.Size = New System.Drawing.Size(121, 22)
        Me.btnCVPortPause.TabIndex = 31
        Me.btnCVPortPause.Text = "CV Port Pause"
        Me.btnCVPortPause.UseVisualStyleBackColor = True
        '
        'btnCVTransferResetReqOff
        '
        Me.btnCVTransferResetReqOff.Location = New System.Drawing.Point(133, 109)
        Me.btnCVTransferResetReqOff.Name = "btnCVTransferResetReqOff"
        Me.btnCVTransferResetReqOff.Size = New System.Drawing.Size(33, 22)
        Me.btnCVTransferResetReqOff.TabIndex = 30
        Me.btnCVTransferResetReqOff.Text = "OFF"
        Me.btnCVTransferResetReqOff.UseVisualStyleBackColor = True
        '
        'btnCVTransferResetReq
        '
        Me.btnCVTransferResetReq.Location = New System.Drawing.Point(7, 109)
        Me.btnCVTransferResetReq.Name = "btnCVTransferResetReq"
        Me.btnCVTransferResetReq.Size = New System.Drawing.Size(121, 22)
        Me.btnCVTransferResetReq.TabIndex = 29
        Me.btnCVTransferResetReq.Text = "CVTransferResetReq"
        Me.btnCVTransferResetReq.UseVisualStyleBackColor = True
        '
        'txtDCPortNo
        '
        Me.txtDCPortNo.Location = New System.Drawing.Point(133, 81)
        Me.txtDCPortNo.Name = "txtDCPortNo"
        Me.txtDCPortNo.Size = New System.Drawing.Size(33, 22)
        Me.txtDCPortNo.TabIndex = 28
        Me.txtDCPortNo.Text = "1"
        '
        'btnCVDummyCancel
        '
        Me.btnCVDummyCancel.Location = New System.Drawing.Point(7, 81)
        Me.btnCVDummyCancel.Name = "btnCVDummyCancel"
        Me.btnCVDummyCancel.Size = New System.Drawing.Size(121, 22)
        Me.btnCVDummyCancel.TabIndex = 27
        Me.btnCVDummyCancel.Text = "CV Dummy Cancel"
        Me.btnCVDummyCancel.UseVisualStyleBackColor = True
        '
        'btnCVREQUnloadCST
        '
        Me.btnCVREQUnloadCST.Location = New System.Drawing.Point(6, 53)
        Me.btnCVREQUnloadCST.Name = "btnCVREQUnloadCST"
        Me.btnCVREQUnloadCST.Size = New System.Drawing.Size(121, 22)
        Me.btnCVREQUnloadCST.TabIndex = 4
        Me.btnCVREQUnloadCST.Text = "CV REQ Unload CST"
        Me.btnCVREQUnloadCST.UseVisualStyleBackColor = True
        '
        'txtREQUnloadCST
        '
        Me.txtREQUnloadCST.Location = New System.Drawing.Point(133, 53)
        Me.txtREQUnloadCST.Name = "txtREQUnloadCST"
        Me.txtREQUnloadCST.Size = New System.Drawing.Size(33, 22)
        Me.txtREQUnloadCST.TabIndex = 3
        Me.txtREQUnloadCST.Text = "1"
        '
        'btnCVOnlineOff
        '
        Me.btnCVOnlineOff.Location = New System.Drawing.Point(114, 21)
        Me.btnCVOnlineOff.Name = "btnCVOnlineOff"
        Me.btnCVOnlineOff.Size = New System.Drawing.Size(33, 22)
        Me.btnCVOnlineOff.TabIndex = 1
        Me.btnCVOnlineOff.Text = "OFF"
        Me.btnCVOnlineOff.UseVisualStyleBackColor = True
        '
        'btnCVOnline
        '
        Me.btnCVOnline.Location = New System.Drawing.Point(5, 21)
        Me.btnCVOnline.Name = "btnCVOnline"
        Me.btnCVOnline.Size = New System.Drawing.Size(102, 22)
        Me.btnCVOnline.TabIndex = 0
        Me.btnCVOnline.Text = "CV Online"
        Me.btnCVOnline.UseVisualStyleBackColor = True
        '
        'btnShowTimeoutSet
        '
        Me.btnShowTimeoutSet.Location = New System.Drawing.Point(797, 600)
        Me.btnShowTimeoutSet.Name = "btnShowTimeoutSet"
        Me.btnShowTimeoutSet.Size = New System.Drawing.Size(133, 23)
        Me.btnShowTimeoutSet.TabIndex = 41
        Me.btnShowTimeoutSet.Text = "ShowTimeout Setting"
        Me.btnShowTimeoutSet.UseVisualStyleBackColor = True
        '
        'btnSetNGGlasstoMachine
        '
        Me.btnSetNGGlasstoMachine.Location = New System.Drawing.Point(39, 494)
        Me.btnSetNGGlasstoMachine.Name = "btnSetNGGlasstoMachine"
        Me.btnSetNGGlasstoMachine.Size = New System.Drawing.Size(153, 24)
        Me.btnSetNGGlasstoMachine.TabIndex = 43
        Me.btnSetNGGlasstoMachine.Text = "Set BufferSlot Destination "
        Me.btnSetNGGlasstoMachine.UseVisualStyleBackColor = True
        '
        'txtSetNgGxPort
        '
        Me.txtSetNgGxPort.Location = New System.Drawing.Point(223, 496)
        Me.txtSetNgGxPort.Name = "txtSetNgGxPort"
        Me.txtSetNgGxPort.Size = New System.Drawing.Size(33, 22)
        Me.txtSetNgGxPort.TabIndex = 44
        Me.txtSetNgGxPort.Text = "1"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(207, 500)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(11, 12)
        Me.Label45.TabIndex = 45
        Me.Label45.Text = "P"
        '
        'txtSetNgGxSlot
        '
        Me.txtSetNgGxSlot.Location = New System.Drawing.Point(287, 496)
        Me.txtSetNgGxSlot.Name = "txtSetNgGxSlot"
        Me.txtSetNgGxSlot.Size = New System.Drawing.Size(33, 22)
        Me.txtSetNgGxSlot.TabIndex = 46
        Me.txtSetNgGxSlot.Text = "1"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(262, 502)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(23, 12)
        Me.Label46.TabIndex = 47
        Me.Label46.Text = "Slot"
        '
        'btnRecipeCheck
        '
        Me.btnRecipeCheck.Location = New System.Drawing.Point(9, 60)
        Me.btnRecipeCheck.Name = "btnRecipeCheck"
        Me.btnRecipeCheck.Size = New System.Drawing.Size(93, 22)
        Me.btnRecipeCheck.TabIndex = 0
        Me.btnRecipeCheck.Text = "RecipeCheck"
        Me.btnRecipeCheck.UseVisualStyleBackColor = True
        '
        'txtRecipeCheckID
        '
        Me.txtRecipeCheckID.Location = New System.Drawing.Point(218, 59)
        Me.txtRecipeCheckID.Name = "txtRecipeCheckID"
        Me.txtRecipeCheckID.Size = New System.Drawing.Size(74, 22)
        Me.txtRecipeCheckID.TabIndex = 1
        Me.txtRecipeCheckID.Text = "001"
        '
        'btnEQRSTOnline
        '
        Me.btnEQRSTOnline.Location = New System.Drawing.Point(8, 13)
        Me.btnEQRSTOnline.Name = "btnEQRSTOnline"
        Me.btnEQRSTOnline.Size = New System.Drawing.Size(93, 22)
        Me.btnEQRSTOnline.TabIndex = 2
        Me.btnEQRSTOnline.Text = "EQRST Online"
        Me.btnEQRSTOnline.UseVisualStyleBackColor = True
        '
        'txtEQIndex
        '
        Me.txtEQIndex.BackColor = System.Drawing.Color.Red
        Me.txtEQIndex.Location = New System.Drawing.Point(351, 15)
        Me.txtEQIndex.Name = "txtEQIndex"
        Me.txtEQIndex.Size = New System.Drawing.Size(32, 22)
        Me.txtEQIndex.TabIndex = 13
        Me.txtEQIndex.Text = "1"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(313, 22)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(32, 12)
        Me.Label38.TabIndex = 14
        Me.Label38.Text = "Index"
        '
        'btnEQRSTOnlineOff
        '
        Me.btnEQRSTOnlineOff.Location = New System.Drawing.Point(107, 11)
        Me.btnEQRSTOnlineOff.Name = "btnEQRSTOnlineOff"
        Me.btnEQRSTOnlineOff.Size = New System.Drawing.Size(33, 22)
        Me.btnEQRSTOnlineOff.TabIndex = 15
        Me.btnEQRSTOnlineOff.Text = "OFF"
        Me.btnEQRSTOnlineOff.UseVisualStyleBackColor = True
        '
        'btnEQTransferReset
        '
        Me.btnEQTransferReset.Location = New System.Drawing.Point(8, 37)
        Me.btnEQTransferReset.Name = "btnEQTransferReset"
        Me.btnEQTransferReset.Size = New System.Drawing.Size(107, 20)
        Me.btnEQTransferReset.TabIndex = 16
        Me.btnEQTransferReset.Text = "EQTransferReset"
        Me.btnEQTransferReset.UseVisualStyleBackColor = True
        '
        'btnEQIgnoreTimeout
        '
        Me.btnEQIgnoreTimeout.Location = New System.Drawing.Point(8, 86)
        Me.btnEQIgnoreTimeout.Name = "btnEQIgnoreTimeout"
        Me.btnEQIgnoreTimeout.Size = New System.Drawing.Size(107, 20)
        Me.btnEQIgnoreTimeout.TabIndex = 17
        Me.btnEQIgnoreTimeout.Text = "IgnoreTimeout"
        Me.btnEQIgnoreTimeout.UseVisualStyleBackColor = True
        '
        'IgnoreTimeoutOff
        '
        Me.IgnoreTimeoutOff.Location = New System.Drawing.Point(121, 86)
        Me.IgnoreTimeoutOff.Name = "IgnoreTimeoutOff"
        Me.IgnoreTimeoutOff.Size = New System.Drawing.Size(33, 22)
        Me.IgnoreTimeoutOff.TabIndex = 18
        Me.IgnoreTimeoutOff.Text = "OFF"
        Me.IgnoreTimeoutOff.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnModeChange)
        Me.GroupBox2.Controls.Add(Me.txtModeChange)
        Me.GroupBox2.Controls.Add(Me.btnRecipeQuery)
        Me.GroupBox2.Controls.Add(Me.btnGetEQStatus)
        Me.GroupBox2.Controls.Add(Me.btnGetToolID)
        Me.GroupBox2.Controls.Add(Me.cobArmMode)
        Me.GroupBox2.Controls.Add(Me.btnEQTranfserModeOff)
        Me.GroupBox2.Controls.Add(Me.btnEQTranfserMode)
        Me.GroupBox2.Controls.Add(Me.btnEQArmMode)
        Me.GroupBox2.Controls.Add(Me.IgnoreTimeoutOff)
        Me.GroupBox2.Controls.Add(Me.btnEQIgnoreTimeout)
        Me.GroupBox2.Controls.Add(Me.btnEQTransferReset)
        Me.GroupBox2.Controls.Add(Me.btnEQRSTOnlineOff)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.txtEQIndex)
        Me.GroupBox2.Controls.Add(Me.btnEQRSTOnline)
        Me.GroupBox2.Controls.Add(Me.txtRecipeCheckID)
        Me.GroupBox2.Controls.Add(Me.btnRecipeCheck)
        Me.GroupBox2.Location = New System.Drawing.Point(508, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(515, 150)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "EQ"
        '
        'btnRecipeQuery
        '
        Me.btnRecipeQuery.Location = New System.Drawing.Point(113, 60)
        Me.btnRecipeQuery.Name = "btnRecipeQuery"
        Me.btnRecipeQuery.Size = New System.Drawing.Size(93, 22)
        Me.btnRecipeQuery.TabIndex = 52
        Me.btnRecipeQuery.Text = "RecipeQuery"
        Me.btnRecipeQuery.UseVisualStyleBackColor = True
        '
        'btnGetEQStatus
        '
        Me.btnGetEQStatus.Location = New System.Drawing.Point(341, 57)
        Me.btnGetEQStatus.Name = "btnGetEQStatus"
        Me.btnGetEQStatus.Size = New System.Drawing.Size(107, 20)
        Me.btnGetEQStatus.TabIndex = 51
        Me.btnGetEQStatus.Text = "EQStatus"
        Me.btnGetEQStatus.UseVisualStyleBackColor = True
        '
        'btnGetToolID
        '
        Me.btnGetToolID.Location = New System.Drawing.Point(341, 89)
        Me.btnGetToolID.Name = "btnGetToolID"
        Me.btnGetToolID.Size = New System.Drawing.Size(107, 20)
        Me.btnGetToolID.TabIndex = 50
        Me.btnGetToolID.Text = "GetToolID"
        Me.btnGetToolID.UseVisualStyleBackColor = True
        '
        'cobArmMode
        '
        Me.cobArmMode.FormattingEnabled = True
        Me.cobArmMode.Items.AddRange(New Object() {"Nornal", "Upper Arm", "Lower Arm"})
        Me.cobArmMode.Location = New System.Drawing.Point(121, 111)
        Me.cobArmMode.Name = "cobArmMode"
        Me.cobArmMode.Size = New System.Drawing.Size(104, 20)
        Me.cobArmMode.TabIndex = 49
        '
        'btnEQTranfserModeOff
        '
        Me.btnEQTranfserModeOff.Location = New System.Drawing.Point(293, 87)
        Me.btnEQTranfserModeOff.Name = "btnEQTranfserModeOff"
        Me.btnEQTranfserModeOff.Size = New System.Drawing.Size(33, 22)
        Me.btnEQTranfserModeOff.TabIndex = 22
        Me.btnEQTranfserModeOff.Text = "OFF"
        Me.btnEQTranfserModeOff.UseVisualStyleBackColor = True
        '
        'btnEQTranfserMode
        '
        Me.btnEQTranfserMode.Location = New System.Drawing.Point(180, 87)
        Me.btnEQTranfserMode.Name = "btnEQTranfserMode"
        Me.btnEQTranfserMode.Size = New System.Drawing.Size(107, 20)
        Me.btnEQTranfserMode.TabIndex = 21
        Me.btnEQTranfserMode.Text = "TranfserMode"
        Me.btnEQTranfserMode.UseVisualStyleBackColor = True
        '
        'btnEQArmMode
        '
        Me.btnEQArmMode.Location = New System.Drawing.Point(8, 110)
        Me.btnEQArmMode.Name = "btnEQArmMode"
        Me.btnEQArmMode.Size = New System.Drawing.Size(107, 20)
        Me.btnEQArmMode.TabIndex = 19
        Me.btnEQArmMode.Text = "ArmMode"
        Me.btnEQArmMode.UseVisualStyleBackColor = True
        '
        'btnShowGUICVOff
        '
        Me.btnShowGUICVOff.Location = New System.Drawing.Point(587, 600)
        Me.btnShowGUICVOff.Name = "btnShowGUICVOff"
        Me.btnShowGUICVOff.Size = New System.Drawing.Size(33, 22)
        Me.btnShowGUICVOff.TabIndex = 48
        Me.btnShowGUICVOff.Text = "OFF"
        Me.btnShowGUICVOff.UseVisualStyleBackColor = True
        '
        'btnShowGUIEQOff
        '
        Me.btnShowGUIEQOff.Location = New System.Drawing.Point(711, 599)
        Me.btnShowGUIEQOff.Name = "btnShowGUIEQOff"
        Me.btnShowGUIEQOff.Size = New System.Drawing.Size(33, 22)
        Me.btnShowGUIEQOff.TabIndex = 49
        Me.btnShowGUIEQOff.Text = "OFF"
        Me.btnShowGUIEQOff.UseVisualStyleBackColor = True
        '
        'btnSetBufferSlotStatus
        '
        Me.btnSetBufferSlotStatus.Location = New System.Drawing.Point(40, 524)
        Me.btnSetBufferSlotStatus.Name = "btnSetBufferSlotStatus"
        Me.btnSetBufferSlotStatus.Size = New System.Drawing.Size(153, 24)
        Me.btnSetBufferSlotStatus.TabIndex = 50
        Me.btnSetBufferSlotStatus.Text = "Set Buffer Slot Status"
        Me.btnSetBufferSlotStatus.UseVisualStyleBackColor = True
        '
        'btnShowGeneralGUI
        '
        Me.btnShowGeneralGUI.Location = New System.Drawing.Point(507, 625)
        Me.btnShowGeneralGUI.Name = "btnShowGeneralGUI"
        Me.btnShowGeneralGUI.Size = New System.Drawing.Size(75, 23)
        Me.btnShowGeneralGUI.TabIndex = 51
        Me.btnShowGeneralGUI.Text = "ShowGeneralGUI"
        Me.btnShowGeneralGUI.UseVisualStyleBackColor = True
        '
        'btnCloseGeneralGUI
        '
        Me.btnCloseGeneralGUI.Location = New System.Drawing.Point(586, 625)
        Me.btnCloseGeneralGUI.Name = "btnCloseGeneralGUI"
        Me.btnCloseGeneralGUI.Size = New System.Drawing.Size(33, 22)
        Me.btnCloseGeneralGUI.TabIndex = 52
        Me.btnCloseGeneralGUI.Text = "OFF"
        Me.btnCloseGeneralGUI.UseVisualStyleBackColor = True
        '
        'btnShowSampleGxSetting
        '
        Me.btnShowSampleGxSetting.Location = New System.Drawing.Point(797, 638)
        Me.btnShowSampleGxSetting.Name = "btnShowSampleGxSetting"
        Me.btnShowSampleGxSetting.Size = New System.Drawing.Size(133, 23)
        Me.btnShowSampleGxSetting.TabIndex = 53
        Me.btnShowSampleGxSetting.Text = "ShowSampleGxSetting"
        Me.btnShowSampleGxSetting.UseVisualStyleBackColor = True
        '
        'cobMachine
        '
        Me.cobMachine.FormattingEnabled = True
        Me.cobMachine.Items.AddRange(New Object() {"NA", "PORT1", "PORT2", "PORT3", "EQ1", "EQ2", "EQ3"})
        Me.cobMachine.Location = New System.Drawing.Point(328, 496)
        Me.cobMachine.Name = "cobMachine"
        Me.cobMachine.Size = New System.Drawing.Size(104, 20)
        Me.cobMachine.TabIndex = 54
        '
        'btnGetCSTSlotData
        '
        Me.btnGetCSTSlotData.Location = New System.Drawing.Point(182, 205)
        Me.btnGetCSTSlotData.Name = "btnGetCSTSlotData"
        Me.btnGetCSTSlotData.Size = New System.Drawing.Size(138, 28)
        Me.btnGetCSTSlotData.TabIndex = 55
        Me.btnGetCSTSlotData.Text = "Get CST Slot Data"
        Me.btnGetCSTSlotData.UseVisualStyleBackColor = True
        '
        'txtGCSTPort
        '
        Me.txtGCSTPort.Location = New System.Drawing.Point(342, 209)
        Me.txtGCSTPort.Name = "txtGCSTPort"
        Me.txtGCSTPort.Size = New System.Drawing.Size(24, 22)
        Me.txtGCSTPort.TabIndex = 56
        Me.txtGCSTPort.Text = "1"
        '
        'txtGCSTSlot
        '
        Me.txtGCSTSlot.Location = New System.Drawing.Point(390, 210)
        Me.txtGCSTSlot.Name = "txtGCSTSlot"
        Me.txtGCSTSlot.Size = New System.Drawing.Size(24, 22)
        Me.txtGCSTSlot.TabIndex = 57
        Me.txtGCSTSlot.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(329, 213)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "P"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(373, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 12)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "S"
        '
        'btnModeChange
        '
        Me.btnModeChange.Location = New System.Drawing.Point(341, 118)
        Me.btnModeChange.Name = "btnModeChange"
        Me.btnModeChange.Size = New System.Drawing.Size(107, 20)
        Me.btnModeChange.TabIndex = 60
        Me.btnModeChange.Text = "ModeChange"
        Me.btnModeChange.UseVisualStyleBackColor = True
        '
        'txtModeChange
        '
        Me.txtModeChange.Location = New System.Drawing.Point(462, 118)
        Me.txtModeChange.Name = "txtModeChange"
        Me.txtModeChange.Size = New System.Drawing.Size(24, 22)
        Me.txtModeChange.TabIndex = 96
        Me.txtModeChange.Text = "0"
        '
        'txtS756Slot2
        '
        Me.txtS756Slot2.Location = New System.Drawing.Point(309, 15)
        Me.txtS756Slot2.Name = "txtS756Slot2"
        Me.txtS756Slot2.Size = New System.Drawing.Size(24, 22)
        Me.txtS756Slot2.TabIndex = 98
        Me.txtS756Slot2.Text = "56"
        '
        'txtProcessFlag
        '
        Me.txtProcessFlag.Location = New System.Drawing.Point(409, 137)
        Me.txtProcessFlag.Name = "txtProcessFlag"
        Me.txtProcessFlag.Size = New System.Drawing.Size(24, 22)
        Me.txtProcessFlag.TabIndex = 46
        Me.txtProcessFlag.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(378, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 12)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Flag"
        '
        'frmSim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 708)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGCSTSlot)
        Me.Controls.Add(Me.txtGCSTPort)
        Me.Controls.Add(Me.btnGetCSTSlotData)
        Me.Controls.Add(Me.cobMachine)
        Me.Controls.Add(Me.btnShowSampleGxSetting)
        Me.Controls.Add(Me.btnCloseGeneralGUI)
        Me.Controls.Add(Me.btnShowGeneralGUI)
        Me.Controls.Add(Me.btnSetBufferSlotStatus)
        Me.Controls.Add(Me.btnShowGUIEQOff)
        Me.Controls.Add(Me.btnShowGUICVOff)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.txtSetNgGxSlot)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.txtSetNgGxPort)
        Me.Controls.Add(Me.btnSetNGGlasstoMachine)
        Me.Controls.Add(Me.btnShowTimeoutSet)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnShowGUIEQ)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnShowGUICV)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GB_LotData)
        Me.Controls.Add(Me.btnS765DataDownload)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmSim"
        Me.Text = "Form1"
        Me.GB_LotData.ResumeLayout(False)
        Me.GB_LotData.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnS765DataDownload As System.Windows.Forms.Button
    Friend WithEvents GB_LotData As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPortNo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtGlassID As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRSTCommand As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtRobotSlotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtRSTGlassType As System.Windows.Forms.TextBox
    Friend WithEvents btnSyncDateTime As System.Windows.Forms.Button
    Friend WithEvents btnShowGUICV As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtSetAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtSetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetBAddr As System.Windows.Forms.Button
    Friend WithEvents btnShowGUIEQ As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCVOnline As System.Windows.Forms.Button
    Friend WithEvents btnCVOnlineOff As System.Windows.Forms.Button
    Friend WithEvents txtREQUnloadCST As System.Windows.Forms.TextBox
    Friend WithEvents btnCVREQUnloadCST As System.Windows.Forms.Button
    Friend WithEvents btnCVDummyCancel As System.Windows.Forms.Button
    Friend WithEvents txtDCPortNo As System.Windows.Forms.TextBox
    Friend WithEvents btnCVTransferResetReqOff As System.Windows.Forms.Button
    Friend WithEvents btnCVTransferResetReq As System.Windows.Forms.Button
    Friend WithEvents btnCVPortPause As System.Windows.Forms.Button
    Friend WithEvents txtPausePortNo As System.Windows.Forms.TextBox
    Friend WithEvents btnCVPortResume As System.Windows.Forms.Button
    Friend WithEvents btnProcessCmd As System.Windows.Forms.Button
    Friend WithEvents btnRSTErrorReset As System.Windows.Forms.Button
    Friend WithEvents btnRSTPauseRequest As System.Windows.Forms.Button
    Friend WithEvents btnRSTResumeRequest As System.Windows.Forms.Button
    Friend WithEvents RSTInterfaceCheck As System.Windows.Forms.Button
    Friend WithEvents btnRSTInterfaceCheckOff As System.Windows.Forms.Button
    Friend WithEvents btnSetWAddr As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtSetWAddrValue As System.Windows.Forms.TextBox
    Friend WithEvents txtSetWAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtArrayLen As System.Windows.Forms.TextBox
    Friend WithEvents btnSetWAddrArray As System.Windows.Forms.Button
    Friend WithEvents btnShowTimeoutSet As System.Windows.Forms.Button
    Friend WithEvents btnSetZRAddrArray As System.Windows.Forms.Button
    Friend WithEvents btnSetZRAddr As System.Windows.Forms.Button
    Friend WithEvents txtSecond As System.Windows.Forms.TextBox
    Friend WithEvents txtMinute As System.Windows.Forms.TextBox
    Friend WithEvents txtHour As System.Windows.Forms.TextBox
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtProcesscmdPort As System.Windows.Forms.TextBox
    Friend WithEvents txtnProcessCount As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cobRobotAction As System.Windows.Forms.ComboBox
    Friend WithEvents cobRobotToGo As System.Windows.Forms.ComboBox
    Friend WithEvents cobRobotArm As System.Windows.Forms.ComboBox
    Friend WithEvents cobTargetPos As System.Windows.Forms.ComboBox
    Friend WithEvents cobRunningMode As System.Windows.Forms.ComboBox
    Friend WithEvents cobRSTSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents cobRSTPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnRSTBuzzerControlOff As System.Windows.Forms.Button
    Friend WithEvents btnRSTBuzzerControl As System.Windows.Forms.Button
    Friend WithEvents txtBuzzerMode As System.Windows.Forms.TextBox
    Friend WithEvents btnRSTLightTowerControl As System.Windows.Forms.Button
    Friend WithEvents cobLightTowerStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cobLightTower As System.Windows.Forms.ComboBox
    Friend WithEvents btnRSTBufferGlassEraseRequest As System.Windows.Forms.Button
    Friend WithEvents txtBufErasePosition As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtBufEraseSlot As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents btnRSTArmGxErase As System.Windows.Forms.Button
    Friend WithEvents cobArmGxErase As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetNGGlasstoMachine As System.Windows.Forms.Button
    Friend WithEvents txtSetNgGxPort As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtSetNgGxSlot As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents btnRecipeCheck As System.Windows.Forms.Button
    Friend WithEvents txtRecipeCheckID As System.Windows.Forms.TextBox
    Friend WithEvents btnEQRSTOnline As System.Windows.Forms.Button
    Friend WithEvents txtEQIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents btnEQRSTOnlineOff As System.Windows.Forms.Button
    Friend WithEvents btnEQTransferReset As System.Windows.Forms.Button
    Friend WithEvents btnEQIgnoreTimeout As System.Windows.Forms.Button
    Friend WithEvents IgnoreTimeoutOff As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEQArmMode As System.Windows.Forms.Button
    Friend WithEvents btnEQTranfserMode As System.Windows.Forms.Button
    Friend WithEvents btnEQTranfserModeOff As System.Windows.Forms.Button
    Friend WithEvents txtProcesscmdCSTID As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents cobPortType As System.Windows.Forms.ComboBox
    Friend WithEvents cobPortMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnPortChangeRequest As System.Windows.Forms.Button
    Friend WithEvents txtPortChangePortNo As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cobRunningMode1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnShowGUICVOff As System.Windows.Forms.Button
    Friend WithEvents btnShowGUIEQOff As System.Windows.Forms.Button
    Friend WithEvents btnSetBufferSlotStatus As System.Windows.Forms.Button
    Friend WithEvents btnRSTRemoteStatus As System.Windows.Forms.Button
    Friend WithEvents cobRSTRemoteStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cobArmMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetToolID As System.Windows.Forms.Button
    Friend WithEvents btnShowGeneralGUI As System.Windows.Forms.Button
    Friend WithEvents btnCloseGeneralGUI As System.Windows.Forms.Button
    Friend WithEvents btnWriteBufferGxInfo As System.Windows.Forms.Button
    Friend WithEvents btnWriteArmGxInfo As System.Windows.Forms.Button
    Friend WithEvents cobWriteArmGxInfo As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetEQStatus As System.Windows.Forms.Button
    Friend WithEvents btnShowSampleGxSetting As System.Windows.Forms.Button
    Friend WithEvents btnGetArmGxInfo As System.Windows.Forms.Button
    Friend WithEvents btnSetRSTMode As System.Windows.Forms.Button
    Friend WithEvents cobSetRSTMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnRSTCMDMode As System.Windows.Forms.Button
    Friend WithEvents cobRSTCMDMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnRSTInitial As System.Windows.Forms.Button
    Friend WithEvents cobMachine As System.Windows.Forms.ComboBox
    Friend WithEvents txtWeek As System.Windows.Forms.TextBox
    Friend WithEvents btnGetCSTSlotData As System.Windows.Forms.Button
    Friend WithEvents txtGCSTPort As System.Windows.Forms.TextBox
    Friend WithEvents txtGCSTSlot As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtS756Slot1 As System.Windows.Forms.TextBox
    Friend WithEvents btnModeChange As System.Windows.Forms.Button
    Friend WithEvents txtModeChange As System.Windows.Forms.TextBox
    Friend WithEvents cobRepairmode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRecipeQuery As System.Windows.Forms.Button
    Friend WithEvents txtS756Slot2 As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessFlag As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
