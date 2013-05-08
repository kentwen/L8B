<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHSMSSetting
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtSYNC = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.cboConnectMode = New System.Windows.Forms.ComboBox
        Me.cmdAbort = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtOPIDInAGV = New System.Windows.Forms.TextBox
        Me.txtDeviceID = New System.Windows.Forms.TextBox
        Me.txtRSTTCPPort = New System.Windows.Forms.TextBox
        Me.txtRSTIP = New System.Windows.Forms.TextBox
        Me.txtHOSTTCPPort = New System.Windows.Forms.TextBox
        Me.txtHOSTIP = New System.Windows.Forms.TextBox
        Me.txtRetryCount = New System.Windows.Forms.TextBox
        Me.txtLinkTestInterval = New System.Windows.Forms.TextBox
        Me.txtT9 = New System.Windows.Forms.TextBox
        Me.txtT8 = New System.Windows.Forms.TextBox
        Me.txtT7 = New System.Windows.Forms.TextBox
        Me.txtT6 = New System.Windows.Forms.TextBox
        Me.txtT5 = New System.Windows.Forms.TextBox
        Me.txtT3 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label33.Location = New System.Drawing.Point(313, 266)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(30, 13)
        Me.Label33.TabIndex = 103
        Me.Label33.Text = "Min"
        '
        'txtSYNC
        '
        Me.txtSYNC.Location = New System.Drawing.Point(273, 263)
        Me.txtSYNC.Name = "txtSYNC"
        Me.txtSYNC.Size = New System.Drawing.Size(33, 22)
        Me.txtSYNC.TabIndex = 102
        Me.txtSYNC.Text = "60"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label32.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label32.Location = New System.Drawing.Point(11, 262)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(256, 23)
        Me.Label32.TabIndex = 101
        Me.Label32.Text = "SYNC Time"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboConnectMode
        '
        Me.cboConnectMode.FormattingEnabled = True
        Me.cboConnectMode.Location = New System.Drawing.Point(274, 292)
        Me.cboConnectMode.Name = "cboConnectMode"
        Me.cboConnectMode.Size = New System.Drawing.Size(130, 20)
        Me.cboConnectMode.TabIndex = 100
        '
        'cmdAbort
        '
        Me.cmdAbort.Location = New System.Drawing.Point(269, 517)
        Me.cmdAbort.Name = "cmdAbort"
        Me.cmdAbort.Size = New System.Drawing.Size(75, 23)
        Me.cmdAbort.TabIndex = 99
        Me.cmdAbort.Text = "Abort"
        Me.cmdAbort.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(93, 517)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 98
        Me.cmdSave.Text = "Setting"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label31.Location = New System.Drawing.Point(359, 233)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(87, 19)
        Me.Label31.TabIndex = 97
        Me.Label31.Text = "1-30 Times"
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label30.Location = New System.Drawing.Point(359, 202)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(87, 19)
        Me.Label30.TabIndex = 96
        Me.Label30.Text = "1-600 Sec"
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label29.Location = New System.Drawing.Point(359, 171)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(87, 19)
        Me.Label29.TabIndex = 95
        Me.Label29.Text = "1-240 Sec"
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label28.Location = New System.Drawing.Point(359, 140)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(87, 19)
        Me.Label28.TabIndex = 94
        Me.Label28.Text = "1-120 Sec"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label27.Location = New System.Drawing.Point(359, 109)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(87, 19)
        Me.Label27.TabIndex = 93
        Me.Label27.Text = "1-240 Sec"
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label26.Location = New System.Drawing.Point(359, 81)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(87, 19)
        Me.Label26.TabIndex = 92
        Me.Label26.Text = "1-240 Sec"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label25.Location = New System.Drawing.Point(359, 47)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(87, 19)
        Me.Label25.TabIndex = 91
        Me.Label25.Text = "1-240 Sec"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label24.Location = New System.Drawing.Point(359, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 19)
        Me.Label24.TabIndex = 90
        Me.Label24.Text = "1-120 Sec"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(313, 231)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 22)
        Me.Label23.TabIndex = 89
        Me.Label23.Text = "Times"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.Location = New System.Drawing.Point(313, 200)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 22)
        Me.Label22.TabIndex = 88
        Me.Label22.Text = "Sec"
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.Location = New System.Drawing.Point(313, 169)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 22)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "Sec"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(313, 138)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 22)
        Me.Label20.TabIndex = 86
        Me.Label20.Text = "Sec"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(313, 107)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 22)
        Me.Label19.TabIndex = 85
        Me.Label19.Text = "Sec"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(313, 79)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 22)
        Me.Label18.TabIndex = 84
        Me.Label18.Text = "Sec"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(313, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 22)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "Sec"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(313, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 22)
        Me.Label16.TabIndex = 82
        Me.Label16.Text = "Sec"
        '
        'txtOPIDInAGV
        '
        Me.txtOPIDInAGV.Location = New System.Drawing.Point(274, 478)
        Me.txtOPIDInAGV.Name = "txtOPIDInAGV"
        Me.txtOPIDInAGV.Size = New System.Drawing.Size(130, 22)
        Me.txtOPIDInAGV.TabIndex = 81
        '
        'txtDeviceID
        '
        Me.txtDeviceID.Location = New System.Drawing.Point(274, 449)
        Me.txtDeviceID.Name = "txtDeviceID"
        Me.txtDeviceID.Size = New System.Drawing.Size(130, 22)
        Me.txtDeviceID.TabIndex = 80
        Me.txtDeviceID.Text = "0"
        '
        'txtRSTTCPPort
        '
        Me.txtRSTTCPPort.Location = New System.Drawing.Point(274, 416)
        Me.txtRSTTCPPort.Name = "txtRSTTCPPort"
        Me.txtRSTTCPPort.Size = New System.Drawing.Size(130, 22)
        Me.txtRSTTCPPort.TabIndex = 79
        Me.txtRSTTCPPort.Text = "5001"
        '
        'txtRSTIP
        '
        Me.txtRSTIP.Location = New System.Drawing.Point(274, 384)
        Me.txtRSTIP.Name = "txtRSTIP"
        Me.txtRSTIP.Size = New System.Drawing.Size(130, 22)
        Me.txtRSTIP.TabIndex = 78
        Me.txtRSTIP.Text = "0.0.0.0"
        '
        'txtHOSTTCPPort
        '
        Me.txtHOSTTCPPort.Location = New System.Drawing.Point(274, 353)
        Me.txtHOSTTCPPort.Name = "txtHOSTTCPPort"
        Me.txtHOSTTCPPort.Size = New System.Drawing.Size(130, 22)
        Me.txtHOSTTCPPort.TabIndex = 77
        Me.txtHOSTTCPPort.Text = "5001"
        '
        'txtHOSTIP
        '
        Me.txtHOSTIP.Location = New System.Drawing.Point(274, 322)
        Me.txtHOSTIP.Name = "txtHOSTIP"
        Me.txtHOSTIP.Size = New System.Drawing.Size(130, 22)
        Me.txtHOSTIP.TabIndex = 76
        Me.txtHOSTIP.Text = "0.0.0.0"
        '
        'txtRetryCount
        '
        Me.txtRetryCount.Location = New System.Drawing.Point(274, 231)
        Me.txtRetryCount.Name = "txtRetryCount"
        Me.txtRetryCount.Size = New System.Drawing.Size(33, 22)
        Me.txtRetryCount.TabIndex = 75
        Me.txtRetryCount.Text = "3"
        '
        'txtLinkTestInterval
        '
        Me.txtLinkTestInterval.Location = New System.Drawing.Point(274, 200)
        Me.txtLinkTestInterval.Name = "txtLinkTestInterval"
        Me.txtLinkTestInterval.Size = New System.Drawing.Size(33, 22)
        Me.txtLinkTestInterval.TabIndex = 74
        Me.txtLinkTestInterval.Text = "30"
        '
        'txtT9
        '
        Me.txtT9.Location = New System.Drawing.Point(274, 169)
        Me.txtT9.Name = "txtT9"
        Me.txtT9.Size = New System.Drawing.Size(33, 22)
        Me.txtT9.TabIndex = 73
        Me.txtT9.Text = "45"
        '
        'txtT8
        '
        Me.txtT8.Location = New System.Drawing.Point(274, 138)
        Me.txtT8.Name = "txtT8"
        Me.txtT8.Size = New System.Drawing.Size(33, 22)
        Me.txtT8.TabIndex = 72
        Me.txtT8.Text = "5"
        '
        'txtT7
        '
        Me.txtT7.Location = New System.Drawing.Point(274, 107)
        Me.txtT7.Name = "txtT7"
        Me.txtT7.Size = New System.Drawing.Size(33, 22)
        Me.txtT7.TabIndex = 71
        Me.txtT7.Text = "10"
        '
        'txtT6
        '
        Me.txtT6.Location = New System.Drawing.Point(274, 79)
        Me.txtT6.Name = "txtT6"
        Me.txtT6.Size = New System.Drawing.Size(33, 22)
        Me.txtT6.TabIndex = 70
        Me.txtT6.Text = "5"
        '
        'txtT5
        '
        Me.txtT5.Location = New System.Drawing.Point(274, 45)
        Me.txtT5.Name = "txtT5"
        Me.txtT5.Size = New System.Drawing.Size(33, 22)
        Me.txtT5.TabIndex = 69
        Me.txtT5.Text = "10"
        '
        'txtT3
        '
        Me.txtT3.Location = New System.Drawing.Point(274, 14)
        Me.txtT3.Name = "txtT3"
        Me.txtT3.Size = New System.Drawing.Size(33, 22)
        Me.txtT3.TabIndex = 68
        Me.txtT3.Text = "120"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 477)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(256, 23)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "OPID in AGV Mode"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 446)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(256, 23)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "Device ID"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 415)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(256, 23)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "RST TCP Port Number"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 384)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(256, 23)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "RST IP Address"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 353)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(256, 23)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "HOST TCP Port Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 322)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(256, 23)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "HOST IP Address"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(256, 23)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Connect Mode"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 231)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(256, 23)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Retry Count"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(256, 23)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Link Test Interval"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(256, 23)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Conversation Timeout[T9]"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(256, 23)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Network Intercharacter Timeout[T8]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(256, 23)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Not Selected Timeout[T7]"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 23)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Control Transaction Timeout[T6]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(256, 23)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Connect Separation Timeout[T5]"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 23)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Reply Timeout[T3]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmHSMSSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 559)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtSYNC)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.cboConnectMode)
        Me.Controls.Add(Me.cmdAbort)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtOPIDInAGV)
        Me.Controls.Add(Me.txtDeviceID)
        Me.Controls.Add(Me.txtRSTTCPPort)
        Me.Controls.Add(Me.txtRSTIP)
        Me.Controls.Add(Me.txtHOSTTCPPort)
        Me.Controls.Add(Me.txtHOSTIP)
        Me.Controls.Add(Me.txtRetryCount)
        Me.Controls.Add(Me.txtLinkTestInterval)
        Me.Controls.Add(Me.txtT9)
        Me.Controls.Add(Me.txtT8)
        Me.Controls.Add(Me.txtT7)
        Me.Controls.Add(Me.txtT6)
        Me.Controls.Add(Me.txtT5)
        Me.Controls.Add(Me.txtT3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmHSMSSetting"
        Me.Text = "frmHSMSSetting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtSYNC As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cboConnectMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAbort As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtOPIDInAGV As System.Windows.Forms.TextBox
    Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
    Friend WithEvents txtRSTTCPPort As System.Windows.Forms.TextBox
    Friend WithEvents txtRSTIP As System.Windows.Forms.TextBox
    Friend WithEvents txtHOSTTCPPort As System.Windows.Forms.TextBox
    Friend WithEvents txtHOSTIP As System.Windows.Forms.TextBox
    Friend WithEvents txtRetryCount As System.Windows.Forms.TextBox
    Friend WithEvents txtLinkTestInterval As System.Windows.Forms.TextBox
    Friend WithEvents txtT9 As System.Windows.Forms.TextBox
    Friend WithEvents txtT8 As System.Windows.Forms.TextBox
    Friend WithEvents txtT7 As System.Windows.Forms.TextBox
    Friend WithEvents txtT6 As System.Windows.Forms.TextBox
    Friend WithEvents txtT5 As System.Windows.Forms.TextBox
    Friend WithEvents txtT3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
