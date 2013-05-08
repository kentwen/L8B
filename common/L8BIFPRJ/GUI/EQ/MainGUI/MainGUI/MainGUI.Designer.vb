<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainGUI
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.tabMain = New System.Windows.Forms.TabControl
        Me.tab1General = New System.Windows.Forms.TabPage
        Me.tabGeneral = New System.Windows.Forms.TabControl
        Me.tab2EQ = New System.Windows.Forms.TabPage
        Me.OcxSignal1 = New AUOL7BDEQGUIOCX.OcxSignal
        Me.tab2PLCMap = New System.Windows.Forms.TabPage
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.tab1EQ = New System.Windows.Forms.TabPage
        Me.tabEq = New System.Windows.Forms.TabControl
        Me.tabSignalLink = New System.Windows.Forms.TabPage
        Me.OcxLinkState1 = New AUOL7BDEQGUIOCX.OcxLinkState
        Me.tabSignalStatus = New System.Windows.Forms.TabPage
        Me.OcxStatus1 = New AUOL7BDEQGUIOCX.OcxStatus
        Me.tabSignalLoadGx = New System.Windows.Forms.TabPage
        Me.OcxGxLoad1 = New AUOL7BDEQGUIOCX.OcxGxLoad
        Me.tabSignalUnloadGx = New System.Windows.Forms.TabPage
        Me.OcxGxUnload1 = New AUOL7BDEQGUIOCX.OcxGxUnload
        Me.tabSignalExGx = New System.Windows.Forms.TabPage
        Me.OcxGxExchange1 = New AUOL7BDEQGUIOCX.OcxGxExchange
        Me.tabSignalRecipeModify = New System.Windows.Forms.TabPage
        Me.OcxPPIDModify1 = New AUOL7BDEQGUIOCX.OcxPPIDModify
        Me.tabSignalGxErase = New System.Windows.Forms.TabPage
        Me.OcxGxErase1 = New AUOL7BDEQGUIOCX.OcxGxErase
        Me.tabSignalRecipeChk = New System.Windows.Forms.TabPage
        Me.OcxPPIDChk1 = New AUOL7BDEQGUIOCX.OcxPPIDChk
        Me.tabSignalAlarm = New System.Windows.Forms.TabPage
        Me.tabEQAlarmInfo = New System.Windows.Forms.TabControl
        Me.tabEQ1 = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabEQ2 = New System.Windows.Forms.TabPage
        Me.tabEQ3 = New System.Windows.Forms.TabPage
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.AlarmMonitor1 = New AUOL7BDEQGUIOCX.OcxAlarmMonitor
        Me.tab1TimeChart = New System.Windows.Forms.TabPage
        Me.tabTimeCht = New System.Windows.Forms.TabControl
        Me.tabFlowLink = New System.Windows.Forms.TabPage
        Me.OcxTimeCht_Link1 = New AUOL7BDEQGUIOCX.OcxTimeCht_Link
        Me.tabFlowLoadGx = New System.Windows.Forms.TabPage
        Me.OcxTimeCht_GxLoad1 = New AUOL7BDEQGUIOCX.OcxTimeCht_GxLoad
        Me.tabFlowUnloadGx = New System.Windows.Forms.TabPage
        Me.OcxTimeCht_GxUnload1 = New AUOL7BDEQGUIOCX.OcxTimeCht_GxUnload
        Me.tabFlowExGx = New System.Windows.Forms.TabPage
        Me.OcxTimeCht_GxExchange1 = New AUOL7BDEQGUIOCX.OcxTimeCht_GxExchange
        Me.tabFlowRecipeModify = New System.Windows.Forms.TabPage
        Me.OcxTimeCht_PPIDModify1 = New AUOL7BDEQGUIOCX.OcxTimeCht_PPIDModify
        Me.tabFlowGxErase = New System.Windows.Forms.TabPage
        Me.OcxTimeCht_GxErase1 = New AUOL7BDEQGUIOCX.OcxTimeCht_GxErase
        Me.tabFlowRecipeChk = New System.Windows.Forms.TabPage
        Me.OcxTimeCht_PPIDChk1 = New AUOL7BDEQGUIOCX.OcxTimeCht_PPIDChk
        Me.tabMain.SuspendLayout()
        Me.tab1General.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.tab2EQ.SuspendLayout()
        Me.tab2PLCMap.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab1EQ.SuspendLayout()
        Me.tabEq.SuspendLayout()
        Me.tabSignalLink.SuspendLayout()
        Me.tabSignalStatus.SuspendLayout()
        Me.tabSignalLoadGx.SuspendLayout()
        Me.tabSignalUnloadGx.SuspendLayout()
        Me.tabSignalExGx.SuspendLayout()
        Me.tabSignalRecipeModify.SuspendLayout()
        Me.tabSignalGxErase.SuspendLayout()
        Me.tabSignalRecipeChk.SuspendLayout()
        Me.tabSignalAlarm.SuspendLayout()
        Me.tabEQAlarmInfo.SuspendLayout()
        Me.tabEQ1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tab1TimeChart.SuspendLayout()
        Me.tabTimeCht.SuspendLayout()
        Me.tabFlowLink.SuspendLayout()
        Me.tabFlowLoadGx.SuspendLayout()
        Me.tabFlowUnloadGx.SuspendLayout()
        Me.tabFlowExGx.SuspendLayout()
        Me.tabFlowRecipeModify.SuspendLayout()
        Me.tabFlowGxErase.SuspendLayout()
        Me.tabFlowRecipeChk.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tab1General)
        Me.tabMain.Controls.Add(Me.tab1EQ)
        Me.tabMain.Controls.Add(Me.tab1TimeChart)
        Me.tabMain.Location = New System.Drawing.Point(3, 3)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(800, 600)
        Me.tabMain.TabIndex = 0
        '
        'tab1General
        '
        Me.tab1General.Controls.Add(Me.tabGeneral)
        Me.tab1General.Location = New System.Drawing.Point(4, 21)
        Me.tab1General.Name = "tab1General"
        Me.tab1General.Padding = New System.Windows.Forms.Padding(3)
        Me.tab1General.Size = New System.Drawing.Size(792, 575)
        Me.tab1General.TabIndex = 0
        Me.tab1General.Text = "General"
        Me.tab1General.UseVisualStyleBackColor = True
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.tab2EQ)
        Me.tabGeneral.Controls.Add(Me.tab2PLCMap)
        Me.tabGeneral.Location = New System.Drawing.Point(7, 7)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.SelectedIndex = 0
        Me.tabGeneral.Size = New System.Drawing.Size(790, 575)
        Me.tabGeneral.TabIndex = 0
        '
        'tab2EQ
        '
        Me.tab2EQ.Controls.Add(Me.OcxSignal1)
        Me.tab2EQ.Location = New System.Drawing.Point(4, 21)
        Me.tab2EQ.Name = "tab2EQ"
        Me.tab2EQ.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2EQ.Size = New System.Drawing.Size(782, 550)
        Me.tab2EQ.TabIndex = 0
        Me.tab2EQ.Text = "Equipment"
        Me.tab2EQ.UseVisualStyleBackColor = True
        '
        'OcxSignal1
        '
        Me.OcxSignal1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxSignal1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxSignal1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxSignal1.ENGType = False
        Me.OcxSignal1.Location = New System.Drawing.Point(6, 6)
        Me.OcxSignal1.Name = "OcxSignal1"
        Me.OcxSignal1.Size = New System.Drawing.Size(730, 500)
        Me.OcxSignal1.TabIndex = 0
        '
        'tab2PLCMap
        '
        Me.tab2PLCMap.Controls.Add(Me.DGV)
        Me.tab2PLCMap.Location = New System.Drawing.Point(4, 21)
        Me.tab2PLCMap.Name = "tab2PLCMap"
        Me.tab2PLCMap.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2PLCMap.Size = New System.Drawing.Size(782, 550)
        Me.tab2PLCMap.TabIndex = 1
        Me.tab2PLCMap.Text = "PLC Map"
        Me.tab2PLCMap.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(6, 5)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowTemplate.Height = 24
        Me.DGV.Size = New System.Drawing.Size(770, 541)
        Me.DGV.TabIndex = 2
        '
        'tab1EQ
        '
        Me.tab1EQ.Controls.Add(Me.tabEq)
        Me.tab1EQ.Location = New System.Drawing.Point(4, 21)
        Me.tab1EQ.Name = "tab1EQ"
        Me.tab1EQ.Padding = New System.Windows.Forms.Padding(3)
        Me.tab1EQ.Size = New System.Drawing.Size(792, 575)
        Me.tab1EQ.TabIndex = 1
        Me.tab1EQ.Text = "EQ"
        Me.tab1EQ.UseVisualStyleBackColor = True
        '
        'tabEq
        '
        Me.tabEq.Controls.Add(Me.tabSignalLink)
        Me.tabEq.Controls.Add(Me.tabSignalStatus)
        Me.tabEq.Controls.Add(Me.tabSignalLoadGx)
        Me.tabEq.Controls.Add(Me.tabSignalUnloadGx)
        Me.tabEq.Controls.Add(Me.tabSignalExGx)
        Me.tabEq.Controls.Add(Me.tabSignalRecipeModify)
        Me.tabEq.Controls.Add(Me.tabSignalGxErase)
        Me.tabEq.Controls.Add(Me.tabSignalRecipeChk)
        Me.tabEq.Controls.Add(Me.tabSignalAlarm)
        Me.tabEq.Location = New System.Drawing.Point(3, 3)
        Me.tabEq.Name = "tabEq"
        Me.tabEq.SelectedIndex = 0
        Me.tabEq.Size = New System.Drawing.Size(790, 575)
        Me.tabEq.TabIndex = 0
        '
        'tabSignalLink
        '
        Me.tabSignalLink.Controls.Add(Me.OcxLinkState1)
        Me.tabSignalLink.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalLink.Name = "tabSignalLink"
        Me.tabSignalLink.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSignalLink.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalLink.TabIndex = 0
        Me.tabSignalLink.Text = "Link Establishment"
        Me.tabSignalLink.UseVisualStyleBackColor = True
        '
        'OcxLinkState1
        '
        Me.OcxLinkState1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxLinkState1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxLinkState1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxLinkState1.ENGType = False
        Me.OcxLinkState1.Location = New System.Drawing.Point(6, 6)
        Me.OcxLinkState1.Name = "OcxLinkState1"
        Me.OcxLinkState1.Size = New System.Drawing.Size(730, 500)
        Me.OcxLinkState1.TabIndex = 0
        '
        'tabSignalStatus
        '
        Me.tabSignalStatus.Controls.Add(Me.OcxStatus1)
        Me.tabSignalStatus.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalStatus.Name = "tabSignalStatus"
        Me.tabSignalStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSignalStatus.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalStatus.TabIndex = 1
        Me.tabSignalStatus.Text = "Status report"
        Me.tabSignalStatus.UseVisualStyleBackColor = True
        '
        'OcxStatus1
        '
        Me.OcxStatus1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxStatus1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxStatus1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxStatus1.ENGType = False
        Me.OcxStatus1.Location = New System.Drawing.Point(6, 3)
        Me.OcxStatus1.Name = "OcxStatus1"
        Me.OcxStatus1.Size = New System.Drawing.Size(730, 500)
        Me.OcxStatus1.TabIndex = 0
        '
        'tabSignalLoadGx
        '
        Me.tabSignalLoadGx.Controls.Add(Me.OcxGxLoad1)
        Me.tabSignalLoadGx.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalLoadGx.Name = "tabSignalLoadGx"
        Me.tabSignalLoadGx.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalLoadGx.TabIndex = 2
        Me.tabSignalLoadGx.Text = "Load Glass[Robot -> EQ]"
        Me.tabSignalLoadGx.UseVisualStyleBackColor = True
        '
        'OcxGxLoad1
        '
        Me.OcxGxLoad1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxGxLoad1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxGxLoad1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxGxLoad1.ENGType = False
        Me.OcxGxLoad1.Location = New System.Drawing.Point(3, 3)
        Me.OcxGxLoad1.Name = "OcxGxLoad1"
        Me.OcxGxLoad1.Size = New System.Drawing.Size(730, 500)
        Me.OcxGxLoad1.TabIndex = 0
        '
        'tabSignalUnloadGx
        '
        Me.tabSignalUnloadGx.Controls.Add(Me.OcxGxUnload1)
        Me.tabSignalUnloadGx.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalUnloadGx.Name = "tabSignalUnloadGx"
        Me.tabSignalUnloadGx.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalUnloadGx.TabIndex = 3
        Me.tabSignalUnloadGx.Text = "Unload Glass[EQ->Robot]"
        Me.tabSignalUnloadGx.UseVisualStyleBackColor = True
        '
        'OcxGxUnload1
        '
        Me.OcxGxUnload1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxGxUnload1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxGxUnload1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxGxUnload1.ENGType = False
        Me.OcxGxUnload1.Location = New System.Drawing.Point(3, 3)
        Me.OcxGxUnload1.Name = "OcxGxUnload1"
        Me.OcxGxUnload1.Size = New System.Drawing.Size(730, 500)
        Me.OcxGxUnload1.TabIndex = 0
        '
        'tabSignalExGx
        '
        Me.tabSignalExGx.Controls.Add(Me.OcxGxExchange1)
        Me.tabSignalExGx.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalExGx.Name = "tabSignalExGx"
        Me.tabSignalExGx.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalExGx.TabIndex = 4
        Me.tabSignalExGx.Text = "Exchange Glass"
        Me.tabSignalExGx.UseVisualStyleBackColor = True
        '
        'OcxGxExchange1
        '
        Me.OcxGxExchange1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxGxExchange1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxGxExchange1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxGxExchange1.ENGType = False
        Me.OcxGxExchange1.Location = New System.Drawing.Point(3, 3)
        Me.OcxGxExchange1.Name = "OcxGxExchange1"
        Me.OcxGxExchange1.Size = New System.Drawing.Size(730, 500)
        Me.OcxGxExchange1.TabIndex = 0
        '
        'tabSignalRecipeModify
        '
        Me.tabSignalRecipeModify.Controls.Add(Me.OcxPPIDModify1)
        Me.tabSignalRecipeModify.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalRecipeModify.Name = "tabSignalRecipeModify"
        Me.tabSignalRecipeModify.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalRecipeModify.TabIndex = 5
        Me.tabSignalRecipeModify.Text = "Recipe Modification"
        Me.tabSignalRecipeModify.UseVisualStyleBackColor = True
        '
        'OcxPPIDModify1
        '
        Me.OcxPPIDModify1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxPPIDModify1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxPPIDModify1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxPPIDModify1.ENGType = False
        Me.OcxPPIDModify1.Location = New System.Drawing.Point(3, 3)
        Me.OcxPPIDModify1.Name = "OcxPPIDModify1"
        Me.OcxPPIDModify1.Size = New System.Drawing.Size(730, 500)
        Me.OcxPPIDModify1.TabIndex = 0
        '
        'tabSignalGxErase
        '
        Me.tabSignalGxErase.Controls.Add(Me.OcxGxErase1)
        Me.tabSignalGxErase.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalGxErase.Name = "tabSignalGxErase"
        Me.tabSignalGxErase.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalGxErase.TabIndex = 6
        Me.tabSignalGxErase.Text = "Glass Erase"
        Me.tabSignalGxErase.UseVisualStyleBackColor = True
        '
        'OcxGxErase1
        '
        Me.OcxGxErase1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxGxErase1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxGxErase1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxGxErase1.ENGType = False
        Me.OcxGxErase1.Location = New System.Drawing.Point(3, 3)
        Me.OcxGxErase1.Name = "OcxGxErase1"
        Me.OcxGxErase1.Size = New System.Drawing.Size(730, 500)
        Me.OcxGxErase1.TabIndex = 0
        '
        'tabSignalRecipeChk
        '
        Me.tabSignalRecipeChk.Controls.Add(Me.OcxPPIDChk1)
        Me.tabSignalRecipeChk.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalRecipeChk.Name = "tabSignalRecipeChk"
        Me.tabSignalRecipeChk.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalRecipeChk.TabIndex = 7
        Me.tabSignalRecipeChk.Text = "Recipe Check"
        Me.tabSignalRecipeChk.UseVisualStyleBackColor = True
        '
        'OcxPPIDChk1
        '
        Me.OcxPPIDChk1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxPPIDChk1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxPPIDChk1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxPPIDChk1.ENGType = False
        Me.OcxPPIDChk1.Location = New System.Drawing.Point(3, 3)
        Me.OcxPPIDChk1.Name = "OcxPPIDChk1"
        Me.OcxPPIDChk1.Size = New System.Drawing.Size(730, 500)
        Me.OcxPPIDChk1.TabIndex = 0
        '
        'tabSignalAlarm
        '
        Me.tabSignalAlarm.Controls.Add(Me.tabEQAlarmInfo)
        Me.tabSignalAlarm.Controls.Add(Me.FlowLayoutPanel1)
        Me.tabSignalAlarm.Location = New System.Drawing.Point(4, 21)
        Me.tabSignalAlarm.Name = "tabSignalAlarm"
        Me.tabSignalAlarm.Size = New System.Drawing.Size(782, 550)
        Me.tabSignalAlarm.TabIndex = 8
        Me.tabSignalAlarm.Text = "Alarm Report"
        Me.tabSignalAlarm.UseVisualStyleBackColor = True
        '
        'tabEQAlarmInfo
        '
        Me.tabEQAlarmInfo.Controls.Add(Me.tabEQ1)
        Me.tabEQAlarmInfo.Controls.Add(Me.tabEQ2)
        Me.tabEQAlarmInfo.Controls.Add(Me.tabEQ3)
        Me.tabEQAlarmInfo.Location = New System.Drawing.Point(6, 4)
        Me.tabEQAlarmInfo.Name = "tabEQAlarmInfo"
        Me.tabEQAlarmInfo.SelectedIndex = 0
        Me.tabEQAlarmInfo.Size = New System.Drawing.Size(326, 23)
        Me.tabEQAlarmInfo.TabIndex = 12
        '
        'tabEQ1
        '
        Me.tabEQ1.Controls.Add(Me.Label1)
        Me.tabEQ1.Location = New System.Drawing.Point(4, 21)
        Me.tabEQ1.Name = "tabEQ1"
        Me.tabEQ1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEQ1.Size = New System.Drawing.Size(318, 0)
        Me.tabEQ1.TabIndex = 0
        Me.tabEQ1.Text = "EQ1"
        Me.tabEQ1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.AlarmMonitor1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 30)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(779, 515)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'AlarmMonitor1
        '
        Me.AlarmMonitor1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.AlarmMonitor1.BackColorForSignalON = System.Drawing.Color.Blue
        Me.AlarmMonitor1.Location = New System.Drawing.Point(3, 3)
        Me.AlarmMonitor1.Name = "AlarmMonitor1"
        Me.AlarmMonitor1.Size = New System.Drawing.Size(730, 500)
        Me.AlarmMonitor1.TabIndex = 0
        '
        'tab1TimeChart
        '
        Me.tab1TimeChart.Controls.Add(Me.tabTimeCht)
        Me.tab1TimeChart.Location = New System.Drawing.Point(4, 21)
        Me.tab1TimeChart.Name = "tab1TimeChart"
        Me.tab1TimeChart.Size = New System.Drawing.Size(792, 575)
        Me.tab1TimeChart.TabIndex = 2
        Me.tab1TimeChart.Text = "Time Chart"
        Me.tab1TimeChart.UseVisualStyleBackColor = True
        '
        'tabTimeCht
        '
        Me.tabTimeCht.Controls.Add(Me.tabFlowLink)
        Me.tabTimeCht.Controls.Add(Me.tabFlowLoadGx)
        Me.tabTimeCht.Controls.Add(Me.tabFlowUnloadGx)
        Me.tabTimeCht.Controls.Add(Me.tabFlowExGx)
        Me.tabTimeCht.Controls.Add(Me.tabFlowRecipeModify)
        Me.tabTimeCht.Controls.Add(Me.tabFlowGxErase)
        Me.tabTimeCht.Controls.Add(Me.tabFlowRecipeChk)
        Me.tabTimeCht.Location = New System.Drawing.Point(0, 4)
        Me.tabTimeCht.Name = "tabTimeCht"
        Me.tabTimeCht.SelectedIndex = 0
        Me.tabTimeCht.Size = New System.Drawing.Size(790, 575)
        Me.tabTimeCht.TabIndex = 1
        '
        'tabFlowLink
        '
        Me.tabFlowLink.Controls.Add(Me.OcxTimeCht_Link1)
        Me.tabFlowLink.Location = New System.Drawing.Point(4, 21)
        Me.tabFlowLink.Name = "tabFlowLink"
        Me.tabFlowLink.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFlowLink.Size = New System.Drawing.Size(782, 550)
        Me.tabFlowLink.TabIndex = 0
        Me.tabFlowLink.Text = "Link Establishment"
        Me.tabFlowLink.UseVisualStyleBackColor = True
        '
        'OcxTimeCht_Link1
        '
        Me.OcxTimeCht_Link1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_Link1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_Link1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxTimeCht_Link1.Location = New System.Drawing.Point(6, 6)
        Me.OcxTimeCht_Link1.Name = "OcxTimeCht_Link1"
        Me.OcxTimeCht_Link1.Size = New System.Drawing.Size(730, 500)
        Me.OcxTimeCht_Link1.TabIndex = 0
        '
        'tabFlowLoadGx
        '
        Me.tabFlowLoadGx.Controls.Add(Me.OcxTimeCht_GxLoad1)
        Me.tabFlowLoadGx.Location = New System.Drawing.Point(4, 21)
        Me.tabFlowLoadGx.Name = "tabFlowLoadGx"
        Me.tabFlowLoadGx.Size = New System.Drawing.Size(782, 550)
        Me.tabFlowLoadGx.TabIndex = 2
        Me.tabFlowLoadGx.Text = "Load Glass[Robot -> EQ]"
        Me.tabFlowLoadGx.UseVisualStyleBackColor = True
        '
        'OcxTimeCht_GxLoad1
        '
        Me.OcxTimeCht_GxLoad1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxLoad1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxLoad1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxLoad1.ENGType = False
        Me.OcxTimeCht_GxLoad1.Location = New System.Drawing.Point(3, 3)
        Me.OcxTimeCht_GxLoad1.Name = "OcxTimeCht_GxLoad1"
        Me.OcxTimeCht_GxLoad1.Size = New System.Drawing.Size(730, 500)
        Me.OcxTimeCht_GxLoad1.TabIndex = 0
        '
        'tabFlowUnloadGx
        '
        Me.tabFlowUnloadGx.Controls.Add(Me.OcxTimeCht_GxUnload1)
        Me.tabFlowUnloadGx.Location = New System.Drawing.Point(4, 21)
        Me.tabFlowUnloadGx.Name = "tabFlowUnloadGx"
        Me.tabFlowUnloadGx.Size = New System.Drawing.Size(782, 550)
        Me.tabFlowUnloadGx.TabIndex = 3
        Me.tabFlowUnloadGx.Text = "Unload Glass[EQ->Robot]"
        Me.tabFlowUnloadGx.UseVisualStyleBackColor = True
        '
        'OcxTimeCht_GxUnload1
        '
        Me.OcxTimeCht_GxUnload1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxUnload1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxUnload1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxUnload1.ENGType = False
        Me.OcxTimeCht_GxUnload1.Location = New System.Drawing.Point(3, 3)
        Me.OcxTimeCht_GxUnload1.Name = "OcxTimeCht_GxUnload1"
        Me.OcxTimeCht_GxUnload1.Size = New System.Drawing.Size(730, 500)
        Me.OcxTimeCht_GxUnload1.TabIndex = 0
        '
        'tabFlowExGx
        '
        Me.tabFlowExGx.Controls.Add(Me.OcxTimeCht_GxExchange1)
        Me.tabFlowExGx.Location = New System.Drawing.Point(4, 21)
        Me.tabFlowExGx.Name = "tabFlowExGx"
        Me.tabFlowExGx.Size = New System.Drawing.Size(782, 550)
        Me.tabFlowExGx.TabIndex = 4
        Me.tabFlowExGx.Text = "Exchange Glass"
        Me.tabFlowExGx.UseVisualStyleBackColor = True
        '
        'OcxTimeCht_GxExchange1
        '
        Me.OcxTimeCht_GxExchange1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxExchange1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxExchange1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxExchange1.ENGType = False
        Me.OcxTimeCht_GxExchange1.Location = New System.Drawing.Point(-8, 0)
        Me.OcxTimeCht_GxExchange1.Name = "OcxTimeCht_GxExchange1"
        Me.OcxTimeCht_GxExchange1.Size = New System.Drawing.Size(730, 500)
        Me.OcxTimeCht_GxExchange1.TabIndex = 0
        '
        'tabFlowRecipeModify
        '
        Me.tabFlowRecipeModify.Controls.Add(Me.OcxTimeCht_PPIDModify1)
        Me.tabFlowRecipeModify.Location = New System.Drawing.Point(4, 21)
        Me.tabFlowRecipeModify.Name = "tabFlowRecipeModify"
        Me.tabFlowRecipeModify.Size = New System.Drawing.Size(782, 550)
        Me.tabFlowRecipeModify.TabIndex = 5
        Me.tabFlowRecipeModify.Text = "Recipe Modification"
        Me.tabFlowRecipeModify.UseVisualStyleBackColor = True
        '
        'OcxTimeCht_PPIDModify1
        '
        Me.OcxTimeCht_PPIDModify1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_PPIDModify1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_PPIDModify1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxTimeCht_PPIDModify1.Location = New System.Drawing.Point(3, 3)
        Me.OcxTimeCht_PPIDModify1.Name = "OcxTimeCht_PPIDModify1"
        Me.OcxTimeCht_PPIDModify1.Size = New System.Drawing.Size(730, 500)
        Me.OcxTimeCht_PPIDModify1.TabIndex = 0
        '
        'tabFlowGxErase
        '
        Me.tabFlowGxErase.Controls.Add(Me.OcxTimeCht_GxErase1)
        Me.tabFlowGxErase.Location = New System.Drawing.Point(4, 21)
        Me.tabFlowGxErase.Name = "tabFlowGxErase"
        Me.tabFlowGxErase.Size = New System.Drawing.Size(782, 550)
        Me.tabFlowGxErase.TabIndex = 6
        Me.tabFlowGxErase.Text = "Glass Erase"
        Me.tabFlowGxErase.UseVisualStyleBackColor = True
        '
        'OcxTimeCht_GxErase1
        '
        Me.OcxTimeCht_GxErase1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxErase1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxErase1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxTimeCht_GxErase1.Location = New System.Drawing.Point(3, 3)
        Me.OcxTimeCht_GxErase1.Name = "OcxTimeCht_GxErase1"
        Me.OcxTimeCht_GxErase1.Size = New System.Drawing.Size(730, 500)
        Me.OcxTimeCht_GxErase1.TabIndex = 0
        '
        'tabFlowRecipeChk
        '
        Me.tabFlowRecipeChk.Controls.Add(Me.OcxTimeCht_PPIDChk1)
        Me.tabFlowRecipeChk.Location = New System.Drawing.Point(4, 21)
        Me.tabFlowRecipeChk.Name = "tabFlowRecipeChk"
        Me.tabFlowRecipeChk.Size = New System.Drawing.Size(782, 550)
        Me.tabFlowRecipeChk.TabIndex = 7
        Me.tabFlowRecipeChk.Text = "Recipe Check"
        Me.tabFlowRecipeChk.UseVisualStyleBackColor = True
        '
        'OcxTimeCht_PPIDChk1
        '
        Me.OcxTimeCht_PPIDChk1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_PPIDChk1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.OcxTimeCht_PPIDChk1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.OcxTimeCht_PPIDChk1.Location = New System.Drawing.Point(3, 3)
        Me.OcxTimeCht_PPIDChk1.Name = "OcxTimeCht_PPIDChk1"
        Me.OcxTimeCht_PPIDChk1.Size = New System.Drawing.Size(730, 500)
        Me.OcxTimeCht_PPIDChk1.TabIndex = 0
        '
        'MainGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tabMain)
        Me.Name = "MainGUI"
        Me.Size = New System.Drawing.Size(805, 610)
        Me.tabMain.ResumeLayout(False)
        Me.tab1General.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.tab2EQ.ResumeLayout(False)
        Me.tab2PLCMap.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab1EQ.ResumeLayout(False)
        Me.tabEq.ResumeLayout(False)
        Me.tabSignalLink.ResumeLayout(False)
        Me.tabSignalStatus.ResumeLayout(False)
        Me.tabSignalLoadGx.ResumeLayout(False)
        Me.tabSignalUnloadGx.ResumeLayout(False)
        Me.tabSignalExGx.ResumeLayout(False)
        Me.tabSignalRecipeModify.ResumeLayout(False)
        Me.tabSignalGxErase.ResumeLayout(False)
        Me.tabSignalRecipeChk.ResumeLayout(False)
        Me.tabSignalAlarm.ResumeLayout(False)
        Me.tabEQAlarmInfo.ResumeLayout(False)
        Me.tabEQ1.ResumeLayout(False)
        Me.tabEQ1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.tab1TimeChart.ResumeLayout(False)
        Me.tabTimeCht.ResumeLayout(False)
        Me.tabFlowLink.ResumeLayout(False)
        Me.tabFlowLoadGx.ResumeLayout(False)
        Me.tabFlowUnloadGx.ResumeLayout(False)
        Me.tabFlowExGx.ResumeLayout(False)
        Me.tabFlowRecipeModify.ResumeLayout(False)
        Me.tabFlowGxErase.ResumeLayout(False)
        Me.tabFlowRecipeChk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tab1General As System.Windows.Forms.TabPage
    Friend WithEvents tab1EQ As System.Windows.Forms.TabPage
    Friend WithEvents tab1TimeChart As System.Windows.Forms.TabPage
    Friend WithEvents tabGeneral As System.Windows.Forms.TabControl
    Friend WithEvents tab2EQ As System.Windows.Forms.TabPage
    Friend WithEvents tab2PLCMap As System.Windows.Forms.TabPage
    Friend WithEvents OcxSignal1 As AUOL7BDEQGUIOCX.OcxSignal
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents tabEq As System.Windows.Forms.TabControl
    Friend WithEvents tabSignalLink As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalStatus As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalLoadGx As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalUnloadGx As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalExGx As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalRecipeModify As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalGxErase As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalRecipeChk As System.Windows.Forms.TabPage
    Friend WithEvents tabSignalAlarm As System.Windows.Forms.TabPage
    Friend WithEvents OcxLinkState1 As AUOL7BDEQGUIOCX.OcxLinkState
    Friend WithEvents OcxStatus1 As AUOL7BDEQGUIOCX.OcxStatus
    Friend WithEvents OcxGxLoad1 As AUOL7BDEQGUIOCX.OcxGxLoad
    Friend WithEvents OcxGxUnload1 As AUOL7BDEQGUIOCX.OcxGxUnload
    Friend WithEvents OcxGxExchange1 As AUOL7BDEQGUIOCX.OcxGxExchange
    Friend WithEvents OcxPPIDModify1 As AUOL7BDEQGUIOCX.OcxPPIDModify
    Friend WithEvents OcxGxErase1 As AUOL7BDEQGUIOCX.OcxGxErase
    Friend WithEvents OcxPPIDChk1 As AUOL7BDEQGUIOCX.OcxPPIDChk
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tabTimeCht As System.Windows.Forms.TabControl
    Friend WithEvents tabFlowLink As System.Windows.Forms.TabPage
    Friend WithEvents tabFlowLoadGx As System.Windows.Forms.TabPage
    Friend WithEvents tabFlowUnloadGx As System.Windows.Forms.TabPage
    Friend WithEvents tabFlowExGx As System.Windows.Forms.TabPage
    Friend WithEvents tabFlowRecipeModify As System.Windows.Forms.TabPage
    Friend WithEvents tabFlowGxErase As System.Windows.Forms.TabPage
    Friend WithEvents tabFlowRecipeChk As System.Windows.Forms.TabPage
    Friend WithEvents OcxTimeCht_Link1 As AUOL7BDEQGUIOCX.OcxTimeCht_Link
    Friend WithEvents OcxTimeCht_GxLoad1 As AUOL7BDEQGUIOCX.OcxTimeCht_GxLoad
    Friend WithEvents OcxTimeCht_GxUnload1 As AUOL7BDEQGUIOCX.OcxTimeCht_GxUnload
    Friend WithEvents OcxTimeCht_GxExchange1 As AUOL7BDEQGUIOCX.OcxTimeCht_GxExchange
    Friend WithEvents OcxTimeCht_PPIDModify1 As AUOL7BDEQGUIOCX.OcxTimeCht_PPIDModify
    Friend WithEvents OcxTimeCht_GxErase1 As AUOL7BDEQGUIOCX.OcxTimeCht_GxErase
    Friend WithEvents OcxTimeCht_PPIDChk1 As AUOL7BDEQGUIOCX.OcxTimeCht_PPIDChk
    Friend WithEvents tabEQAlarmInfo As System.Windows.Forms.TabControl
    Friend WithEvents tabEQ1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabEQ2 As System.Windows.Forms.TabPage
    Friend WithEvents tabEQ3 As System.Windows.Forms.TabPage
    Friend WithEvents AlarmMonitor1 As AUOL7BDEQGUIOCX.OcxAlarmMonitor

End Class
