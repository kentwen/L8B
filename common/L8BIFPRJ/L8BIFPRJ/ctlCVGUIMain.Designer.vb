<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlCVGUIMain
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
        Me.tab1StTimeChart = New System.Windows.Forms.TabPage
        Me.TabControl6 = New System.Windows.Forms.TabControl
        Me.tab2ndTimechartLink = New System.Windows.Forms.TabPage
        Me.TimeChart_Link1 = New WindowsControlLibrary1.TimeChart_Link
        Me.tab2ndTimechartCSTProcessCMD = New System.Windows.Forms.TabPage
        Me.TimeChart_CSTProcessReq1 = New WindowsControlLibrary1.TimeChart_CSTProcessReq
        Me.tab2ndTimechartGxDataReq = New System.Windows.Forms.TabPage
        Me.TimeChart_GxDataReq1 = New WindowsControlLibrary1.TimeChart_GxDataReq
        Me.tab2ndTimechartTRReset = New System.Windows.Forms.TabPage
        Me.TimeChart_TRReset1 = New WindowsControlLibrary1.TimeChart_TRReset
        Me.tab2ndTimechartGxAbnormal = New System.Windows.Forms.TabPage
        Me.TimeChart_GxAbnormal1 = New WindowsControlLibrary1.TimeChart_GxAbnormal
        Me.tab2ndTimechartGxInfoUnmatch = New System.Windows.Forms.TabPage
        Me.TimeChart_GxSlotUnmatch1 = New WindowsControlLibrary1.TimeChart_GxSlotUnmatch
        Me.tab2ndTimechartCSTLoadReq = New System.Windows.Forms.TabPage
        Me.TimeChart_CSTLoadreq1 = New WindowsControlLibrary1.TimeChart_CSTLoadreq
        Me.tab2ndTimechartCSTLoadComp = New System.Windows.Forms.TabPage
        Me.TimeChart_CSTLoadComp1 = New WindowsControlLibrary1.TimeChart_CSTLoadComp
        Me.tab2ndTimechartGxFlowOut = New System.Windows.Forms.TabPage
        Me.TimeChart_GxFlowOut1 = New WindowsControlLibrary1.TimeChart_GxFlowOut
        Me.tab2ndTimechartGxFlowIn = New System.Windows.Forms.TabPage
        Me.TimeChart_GxFlowIn1 = New WindowsControlLibrary1.TimeChart_GxFlowIn
        Me.tab2ndTimechartCSTUnloadByCV = New System.Windows.Forms.TabPage
        Me.TimeChart_CSTUnloadReqByCV1 = New WindowsControlLibrary1.TimeChart_CSTUnloadReqByCV
        Me.tab2ndTimechartCSTUnloadByRST = New System.Windows.Forms.TabPage
        Me.TimeChart_CSTUnloadReqByRST1 = New WindowsControlLibrary1.TimeChart_CSTUnloadReqByRST
        Me.tab2ndTimechartCSTUnloadComp = New System.Windows.Forms.TabPage
        Me.TimeChart_CSTUnloadComp1 = New WindowsControlLibrary1.TimeChart_CSTUnloadComp
        Me.tab2ndTimechartCSTDummyCancel = New System.Windows.Forms.TabPage
        Me.TimeChart_CSTDummyCancel1 = New WindowsControlLibrary1.TimeChart_CSTDummyCancel
        Me.tab2ndTimechartPortChangeReq = New System.Windows.Forms.TabPage
        Me.TimeChart_PortChangeReq1 = New WindowsControlLibrary1.TimeChart_PortChangeReq
        Me.tab2ndTimechartCVTR = New System.Windows.Forms.TabPage
        Me.TimeChart_CVTR1 = New WindowsControlLibrary1.TimeChart_CVTR
        Me.tab2ndTimechartRSTTR = New System.Windows.Forms.TabPage
        Me.TimeChart_RSTTR1 = New WindowsControlLibrary1.TimeChart_RSTTR
        Me.tab2ndStatusPort = New System.Windows.Forms.TabPage
        Me.PortStatus1 = New WindowsControlLibrary1.PortStatus
        Me.tab2ndLink = New System.Windows.Forms.TabPage
        Me.LinkStatus1 = New WindowsControlLibrary1.LinkStatus
        Me.tab2ndCVGlassDataReq = New System.Windows.Forms.TabPage
        Me.GxDataReq1 = New WindowsControlLibrary1.GxDataReq
        Me.tab2ndCSTProcessCMD = New System.Windows.Forms.TabPage
        Me.CstProcessCMD1 = New WindowsControlLibrary1.CSTProcessCMD
        Me.tab2ndCVResetSignal = New System.Windows.Forms.TabPage
        Me.TrReset1 = New WindowsControlLibrary1.TRReset
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel
        Me.CvSignal1 = New WindowsControlLibrary1.CVSignal
        Me.tab2ndConveyor = New System.Windows.Forms.TabPage
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.RstSignal1 = New WindowsControlLibrary1.RSTSignal
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.tab2ndPLCMap = New System.Windows.Forms.TabPage
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.tab1StGeneral = New System.Windows.Forms.TabPage
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.AlarmMonitor1 = New WindowsControlLibrary1.AlarmMonitor
        Me.tab2ndStatusMain = New System.Windows.Forms.TabPage
        Me.StatusReport1 = New WindowsControlLibrary1.StatusReport
        Me.tab2ndCSTLoadReq = New System.Windows.Forms.TabPage
        Me.CstLoadReq1 = New WindowsControlLibrary1.CSTLoadReq
        Me.tab2ndGxAbnormalReport = New System.Windows.Forms.TabPage
        Me.GxAbnormal1 = New WindowsControlLibrary1.GxAbnormal
        Me.tab2ndGxInfoUnmatchReport = New System.Windows.Forms.TabPage
        Me.GxInfoUnmatch1 = New WindowsControlLibrary1.GxInfoUnmatch
        Me.tab2ndCSTLoadComp = New System.Windows.Forms.TabPage
        Me.CstLoadComplete1 = New WindowsControlLibrary1.CSTLoadComplete
        Me.tab2ndGxFlowOut = New System.Windows.Forms.TabPage
        Me.GxFlowOut1 = New WindowsControlLibrary1.GxFlowOut
        Me.tab2ndGxFlowIn = New System.Windows.Forms.TabPage
        Me.GxFlowIn1 = New WindowsControlLibrary1.GxFlowIn
        Me.tab2ndCSTUnloadByCV = New System.Windows.Forms.TabPage
        Me.CstUnloadByCV1 = New WindowsControlLibrary1.CSTUnloadByCV
        Me.tab2ndCSTUnloadByRST = New System.Windows.Forms.TabPage
        Me.CstUnloadByRST1 = New WindowsControlLibrary1.CSTUnloadByRST
        Me.tab2ndCSTUnloadComp = New System.Windows.Forms.TabPage
        Me.CstUnloadComp1 = New WindowsControlLibrary1.CSTUnloadComp
        Me.tab2ndCSTDummyCancel = New System.Windows.Forms.TabPage
        Me.CstDummyCancel1 = New WindowsControlLibrary1.CSTDummyCancel
        Me.tab2ndPortResume = New System.Windows.Forms.TabPage
        Me.PortResume1 = New WindowsControlLibrary1.PortResume
        Me.TabControl3 = New System.Windows.Forms.TabControl
        Me.tab2ndPortChangeReq = New System.Windows.Forms.TabPage
        Me.PortChangeReq1 = New WindowsControlLibrary1.PortChangeReq
        Me.tab2ndCV2RSTTR = New System.Windows.Forms.TabPage
        Me.GxtR_CV2RST1 = New WindowsControlLibrary1.GXTR_CV2RST
        Me.tab2ndRST2CVTR = New System.Windows.Forms.TabPage
        Me.GxTR_RST2CV1 = New WindowsControlLibrary1.GxTR_RST2CV
        Me.tab2ndAlarm = New System.Windows.Forms.TabPage
        Me.tab2ndCSTPresent = New System.Windows.Forms.TabPage
        Me.CstPresent1 = New WindowsControlLibrary1.CSTPresent
        Me.tab2ndCSTRemoved = New System.Windows.Forms.TabPage
        Me.CstRemoved1 = New WindowsControlLibrary1.CSTRemoved
        Me.tab2ndPortPause = New System.Windows.Forms.TabPage
        Me.PortPause1 = New WindowsControlLibrary1.PortPause
        Me.tab1StConveyor = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tab1StTimeChart.SuspendLayout()
        Me.TabControl6.SuspendLayout()
        Me.tab2ndTimechartLink.SuspendLayout()
        Me.tab2ndTimechartCSTProcessCMD.SuspendLayout()
        Me.tab2ndTimechartGxDataReq.SuspendLayout()
        Me.tab2ndTimechartTRReset.SuspendLayout()
        Me.tab2ndTimechartGxAbnormal.SuspendLayout()
        Me.tab2ndTimechartGxInfoUnmatch.SuspendLayout()
        Me.tab2ndTimechartCSTLoadReq.SuspendLayout()
        Me.tab2ndTimechartCSTLoadComp.SuspendLayout()
        Me.tab2ndTimechartGxFlowOut.SuspendLayout()
        Me.tab2ndTimechartGxFlowIn.SuspendLayout()
        Me.tab2ndTimechartCSTUnloadByCV.SuspendLayout()
        Me.tab2ndTimechartCSTUnloadByRST.SuspendLayout()
        Me.tab2ndTimechartCSTUnloadComp.SuspendLayout()
        Me.tab2ndTimechartCSTDummyCancel.SuspendLayout()
        Me.tab2ndTimechartPortChangeReq.SuspendLayout()
        Me.tab2ndTimechartCVTR.SuspendLayout()
        Me.tab2ndTimechartRSTTR.SuspendLayout()
        Me.tab2ndStatusPort.SuspendLayout()
        Me.tab2ndLink.SuspendLayout()
        Me.tab2ndCVGlassDataReq.SuspendLayout()
        Me.tab2ndCSTProcessCMD.SuspendLayout()
        Me.tab2ndCVResetSignal.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.tab2ndConveyor.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tab2ndPLCMap.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab1StGeneral.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tab2ndStatusMain.SuspendLayout()
        Me.tab2ndCSTLoadReq.SuspendLayout()
        Me.tab2ndGxAbnormalReport.SuspendLayout()
        Me.tab2ndGxInfoUnmatchReport.SuspendLayout()
        Me.tab2ndCSTLoadComp.SuspendLayout()
        Me.tab2ndGxFlowOut.SuspendLayout()
        Me.tab2ndGxFlowIn.SuspendLayout()
        Me.tab2ndCSTUnloadByCV.SuspendLayout()
        Me.tab2ndCSTUnloadByRST.SuspendLayout()
        Me.tab2ndCSTUnloadComp.SuspendLayout()
        Me.tab2ndCSTDummyCancel.SuspendLayout()
        Me.tab2ndPortResume.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.tab2ndPortChangeReq.SuspendLayout()
        Me.tab2ndCV2RSTTR.SuspendLayout()
        Me.tab2ndRST2CVTR.SuspendLayout()
        Me.tab2ndAlarm.SuspendLayout()
        Me.tab2ndCSTPresent.SuspendLayout()
        Me.tab2ndCSTRemoved.SuspendLayout()
        Me.tab2ndPortPause.SuspendLayout()
        Me.tab1StConveyor.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab1StTimeChart
        '
        Me.tab1StTimeChart.Controls.Add(Me.TabControl6)
        Me.tab1StTimeChart.Location = New System.Drawing.Point(4, 22)
        Me.tab1StTimeChart.Name = "tab1StTimeChart"
        Me.tab1StTimeChart.Size = New System.Drawing.Size(976, 758)
        Me.tab1StTimeChart.TabIndex = 2
        Me.tab1StTimeChart.Text = "Time Chart"
        Me.tab1StTimeChart.UseVisualStyleBackColor = True
        '
        'TabControl6
        '
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartLink)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCSTProcessCMD)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartGxDataReq)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartTRReset)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartGxAbnormal)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartGxInfoUnmatch)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCSTLoadReq)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCSTLoadComp)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartGxFlowOut)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartGxFlowIn)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCSTUnloadByCV)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCSTUnloadByRST)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCSTUnloadComp)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCSTDummyCancel)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartPortChangeReq)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartCVTR)
        Me.TabControl6.Controls.Add(Me.tab2ndTimechartRSTTR)
        Me.TabControl6.Location = New System.Drawing.Point(0, 1)
        Me.TabControl6.Name = "TabControl6"
        Me.TabControl6.SelectedIndex = 0
        Me.TabControl6.Size = New System.Drawing.Size(960, 575)
        Me.TabControl6.TabIndex = 1
        '
        'tab2ndTimechartLink
        '
        Me.tab2ndTimechartLink.Controls.Add(Me.TimeChart_Link1)
        Me.tab2ndTimechartLink.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartLink.Name = "tab2ndTimechartLink"
        Me.tab2ndTimechartLink.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2ndTimechartLink.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartLink.TabIndex = 0
        Me.tab2ndTimechartLink.Text = "Link Establishment"
        Me.tab2ndTimechartLink.UseVisualStyleBackColor = True
        '
        'TimeChart_Link1
        '
        Me.TimeChart_Link1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_Link1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_Link1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_Link1.Location = New System.Drawing.Point(6, 6)
        Me.TimeChart_Link1.Name = "TimeChart_Link1"
        Me.TimeChart_Link1.Size = New System.Drawing.Size(693, 261)
        Me.TimeChart_Link1.TabIndex = 0
        '
        'tab2ndTimechartCSTProcessCMD
        '
        Me.tab2ndTimechartCSTProcessCMD.Controls.Add(Me.TimeChart_CSTProcessReq1)
        Me.tab2ndTimechartCSTProcessCMD.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCSTProcessCMD.Name = "tab2ndTimechartCSTProcessCMD"
        Me.tab2ndTimechartCSTProcessCMD.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCSTProcessCMD.TabIndex = 3
        Me.tab2ndTimechartCSTProcessCMD.Text = "CST Process Command"
        Me.tab2ndTimechartCSTProcessCMD.UseVisualStyleBackColor = True
        '
        'TimeChart_CSTProcessReq1
        '
        Me.TimeChart_CSTProcessReq1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTProcessReq1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTProcessReq1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CSTProcessReq1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_CSTProcessReq1.Name = "TimeChart_CSTProcessReq1"
        Me.TimeChart_CSTProcessReq1.Size = New System.Drawing.Size(694, 212)
        Me.TimeChart_CSTProcessReq1.TabIndex = 0
        '
        'tab2ndTimechartGxDataReq
        '
        Me.tab2ndTimechartGxDataReq.Controls.Add(Me.TimeChart_GxDataReq1)
        Me.tab2ndTimechartGxDataReq.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartGxDataReq.Name = "tab2ndTimechartGxDataReq"
        Me.tab2ndTimechartGxDataReq.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartGxDataReq.TabIndex = 4
        Me.tab2ndTimechartGxDataReq.Text = "Conveyor Glass Data Request"
        Me.tab2ndTimechartGxDataReq.UseVisualStyleBackColor = True
        '
        'TimeChart_GxDataReq1
        '
        Me.TimeChart_GxDataReq1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxDataReq1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxDataReq1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_GxDataReq1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_GxDataReq1.Name = "TimeChart_GxDataReq1"
        Me.TimeChart_GxDataReq1.Size = New System.Drawing.Size(688, 308)
        Me.TimeChart_GxDataReq1.TabIndex = 0
        '
        'tab2ndTimechartTRReset
        '
        Me.tab2ndTimechartTRReset.Controls.Add(Me.TimeChart_TRReset1)
        Me.tab2ndTimechartTRReset.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartTRReset.Name = "tab2ndTimechartTRReset"
        Me.tab2ndTimechartTRReset.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartTRReset.TabIndex = 5
        Me.tab2ndTimechartTRReset.Text = "Conveyor Reset Signal"
        Me.tab2ndTimechartTRReset.UseVisualStyleBackColor = True
        '
        'TimeChart_TRReset1
        '
        Me.TimeChart_TRReset1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_TRReset1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_TRReset1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_TRReset1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_TRReset1.Name = "TimeChart_TRReset1"
        Me.TimeChart_TRReset1.Size = New System.Drawing.Size(687, 174)
        Me.TimeChart_TRReset1.TabIndex = 0
        '
        'tab2ndTimechartGxAbnormal
        '
        Me.tab2ndTimechartGxAbnormal.Controls.Add(Me.TimeChart_GxAbnormal1)
        Me.tab2ndTimechartGxAbnormal.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartGxAbnormal.Name = "tab2ndTimechartGxAbnormal"
        Me.tab2ndTimechartGxAbnormal.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartGxAbnormal.TabIndex = 6
        Me.tab2ndTimechartGxAbnormal.Text = "Glass Abnormal Report"
        Me.tab2ndTimechartGxAbnormal.UseVisualStyleBackColor = True
        '
        'TimeChart_GxAbnormal1
        '
        Me.TimeChart_GxAbnormal1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxAbnormal1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxAbnormal1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_GxAbnormal1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_GxAbnormal1.Name = "TimeChart_GxAbnormal1"
        Me.TimeChart_GxAbnormal1.Size = New System.Drawing.Size(697, 209)
        Me.TimeChart_GxAbnormal1.TabIndex = 0
        '
        'tab2ndTimechartGxInfoUnmatch
        '
        Me.tab2ndTimechartGxInfoUnmatch.Controls.Add(Me.TimeChart_GxSlotUnmatch1)
        Me.tab2ndTimechartGxInfoUnmatch.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartGxInfoUnmatch.Name = "tab2ndTimechartGxInfoUnmatch"
        Me.tab2ndTimechartGxInfoUnmatch.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartGxInfoUnmatch.TabIndex = 7
        Me.tab2ndTimechartGxInfoUnmatch.Text = "Glass Info. Unmatch Report"
        Me.tab2ndTimechartGxInfoUnmatch.UseVisualStyleBackColor = True
        '
        'TimeChart_GxSlotUnmatch1
        '
        Me.TimeChart_GxSlotUnmatch1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxSlotUnmatch1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxSlotUnmatch1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_GxSlotUnmatch1.Location = New System.Drawing.Point(3, 3)
        Me.TimeChart_GxSlotUnmatch1.Name = "TimeChart_GxSlotUnmatch1"
        Me.TimeChart_GxSlotUnmatch1.Size = New System.Drawing.Size(693, 217)
        Me.TimeChart_GxSlotUnmatch1.TabIndex = 0
        '
        'tab2ndTimechartCSTLoadReq
        '
        Me.tab2ndTimechartCSTLoadReq.Controls.Add(Me.TimeChart_CSTLoadreq1)
        Me.tab2ndTimechartCSTLoadReq.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCSTLoadReq.Name = "tab2ndTimechartCSTLoadReq"
        Me.tab2ndTimechartCSTLoadReq.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCSTLoadReq.TabIndex = 8
        Me.tab2ndTimechartCSTLoadReq.Text = "Gassette Load Request"
        Me.tab2ndTimechartCSTLoadReq.UseVisualStyleBackColor = True
        '
        'TimeChart_CSTLoadreq1
        '
        Me.TimeChart_CSTLoadreq1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTLoadreq1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTLoadreq1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CSTLoadreq1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_CSTLoadreq1.Name = "TimeChart_CSTLoadreq1"
        Me.TimeChart_CSTLoadreq1.Size = New System.Drawing.Size(689, 177)
        Me.TimeChart_CSTLoadreq1.TabIndex = 0
        '
        'tab2ndTimechartCSTLoadComp
        '
        Me.tab2ndTimechartCSTLoadComp.Controls.Add(Me.TimeChart_CSTLoadComp1)
        Me.tab2ndTimechartCSTLoadComp.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCSTLoadComp.Name = "tab2ndTimechartCSTLoadComp"
        Me.tab2ndTimechartCSTLoadComp.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCSTLoadComp.TabIndex = 9
        Me.tab2ndTimechartCSTLoadComp.Text = "Cassette Load Complete"
        Me.tab2ndTimechartCSTLoadComp.UseVisualStyleBackColor = True
        '
        'TimeChart_CSTLoadComp1
        '
        Me.TimeChart_CSTLoadComp1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTLoadComp1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTLoadComp1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CSTLoadComp1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_CSTLoadComp1.Name = "TimeChart_CSTLoadComp1"
        Me.TimeChart_CSTLoadComp1.Size = New System.Drawing.Size(691, 217)
        Me.TimeChart_CSTLoadComp1.TabIndex = 0
        '
        'tab2ndTimechartGxFlowOut
        '
        Me.tab2ndTimechartGxFlowOut.Controls.Add(Me.TimeChart_GxFlowOut1)
        Me.tab2ndTimechartGxFlowOut.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartGxFlowOut.Name = "tab2ndTimechartGxFlowOut"
        Me.tab2ndTimechartGxFlowOut.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartGxFlowOut.TabIndex = 10
        Me.tab2ndTimechartGxFlowOut.Text = "Glass Flow Out"
        Me.tab2ndTimechartGxFlowOut.UseVisualStyleBackColor = True
        '
        'TimeChart_GxFlowOut1
        '
        Me.TimeChart_GxFlowOut1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxFlowOut1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxFlowOut1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_GxFlowOut1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_GxFlowOut1.Name = "TimeChart_GxFlowOut1"
        Me.TimeChart_GxFlowOut1.Size = New System.Drawing.Size(693, 252)
        Me.TimeChart_GxFlowOut1.TabIndex = 0
        '
        'tab2ndTimechartGxFlowIn
        '
        Me.tab2ndTimechartGxFlowIn.Controls.Add(Me.TimeChart_GxFlowIn1)
        Me.tab2ndTimechartGxFlowIn.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartGxFlowIn.Name = "tab2ndTimechartGxFlowIn"
        Me.tab2ndTimechartGxFlowIn.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartGxFlowIn.TabIndex = 11
        Me.tab2ndTimechartGxFlowIn.Text = "Glass Flow In"
        Me.tab2ndTimechartGxFlowIn.UseVisualStyleBackColor = True
        '
        'TimeChart_GxFlowIn1
        '
        Me.TimeChart_GxFlowIn1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxFlowIn1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_GxFlowIn1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_GxFlowIn1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_GxFlowIn1.Name = "TimeChart_GxFlowIn1"
        Me.TimeChart_GxFlowIn1.Size = New System.Drawing.Size(687, 208)
        Me.TimeChart_GxFlowIn1.TabIndex = 0
        '
        'tab2ndTimechartCSTUnloadByCV
        '
        Me.tab2ndTimechartCSTUnloadByCV.Controls.Add(Me.TimeChart_CSTUnloadReqByCV1)
        Me.tab2ndTimechartCSTUnloadByCV.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCSTUnloadByCV.Name = "tab2ndTimechartCSTUnloadByCV"
        Me.tab2ndTimechartCSTUnloadByCV.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCSTUnloadByCV.TabIndex = 12
        Me.tab2ndTimechartCSTUnloadByCV.Text = "Cassette Unload Request By Conveyor"
        Me.tab2ndTimechartCSTUnloadByCV.UseVisualStyleBackColor = True
        '
        'TimeChart_CSTUnloadReqByCV1
        '
        Me.TimeChart_CSTUnloadReqByCV1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadReqByCV1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadReqByCV1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadReqByCV1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_CSTUnloadReqByCV1.Name = "TimeChart_CSTUnloadReqByCV1"
        Me.TimeChart_CSTUnloadReqByCV1.Size = New System.Drawing.Size(690, 259)
        Me.TimeChart_CSTUnloadReqByCV1.TabIndex = 0
        '
        'tab2ndTimechartCSTUnloadByRST
        '
        Me.tab2ndTimechartCSTUnloadByRST.Controls.Add(Me.TimeChart_CSTUnloadReqByRST1)
        Me.tab2ndTimechartCSTUnloadByRST.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCSTUnloadByRST.Name = "tab2ndTimechartCSTUnloadByRST"
        Me.tab2ndTimechartCSTUnloadByRST.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCSTUnloadByRST.TabIndex = 13
        Me.tab2ndTimechartCSTUnloadByRST.Text = "Cassette Unload Request By RST"
        Me.tab2ndTimechartCSTUnloadByRST.UseVisualStyleBackColor = True
        '
        'TimeChart_CSTUnloadReqByRST1
        '
        Me.TimeChart_CSTUnloadReqByRST1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadReqByRST1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadReqByRST1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadReqByRST1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_CSTUnloadReqByRST1.Name = "TimeChart_CSTUnloadReqByRST1"
        Me.TimeChart_CSTUnloadReqByRST1.Size = New System.Drawing.Size(691, 295)
        Me.TimeChart_CSTUnloadReqByRST1.TabIndex = 0
        '
        'tab2ndTimechartCSTUnloadComp
        '
        Me.tab2ndTimechartCSTUnloadComp.Controls.Add(Me.TimeChart_CSTUnloadComp1)
        Me.tab2ndTimechartCSTUnloadComp.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCSTUnloadComp.Name = "tab2ndTimechartCSTUnloadComp"
        Me.tab2ndTimechartCSTUnloadComp.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCSTUnloadComp.TabIndex = 14
        Me.tab2ndTimechartCSTUnloadComp.Text = "Cassette Unload Complete"
        Me.tab2ndTimechartCSTUnloadComp.UseVisualStyleBackColor = True
        '
        'TimeChart_CSTUnloadComp1
        '
        Me.TimeChart_CSTUnloadComp1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadComp1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadComp1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CSTUnloadComp1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_CSTUnloadComp1.Name = "TimeChart_CSTUnloadComp1"
        Me.TimeChart_CSTUnloadComp1.Size = New System.Drawing.Size(688, 172)
        Me.TimeChart_CSTUnloadComp1.TabIndex = 0
        '
        'tab2ndTimechartCSTDummyCancel
        '
        Me.tab2ndTimechartCSTDummyCancel.Controls.Add(Me.TimeChart_CSTDummyCancel1)
        Me.tab2ndTimechartCSTDummyCancel.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCSTDummyCancel.Name = "tab2ndTimechartCSTDummyCancel"
        Me.tab2ndTimechartCSTDummyCancel.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCSTDummyCancel.TabIndex = 15
        Me.tab2ndTimechartCSTDummyCancel.Text = "Cassette Dummy Cancel"
        Me.tab2ndTimechartCSTDummyCancel.UseVisualStyleBackColor = True
        '
        'TimeChart_CSTDummyCancel1
        '
        Me.TimeChart_CSTDummyCancel1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTDummyCancel1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CSTDummyCancel1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CSTDummyCancel1.Location = New System.Drawing.Point(2, 3)
        Me.TimeChart_CSTDummyCancel1.Name = "TimeChart_CSTDummyCancel1"
        Me.TimeChart_CSTDummyCancel1.Size = New System.Drawing.Size(784, 532)
        Me.TimeChart_CSTDummyCancel1.TabIndex = 0
        '
        'tab2ndTimechartPortChangeReq
        '
        Me.tab2ndTimechartPortChangeReq.Controls.Add(Me.TimeChart_PortChangeReq1)
        Me.tab2ndTimechartPortChangeReq.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartPortChangeReq.Name = "tab2ndTimechartPortChangeReq"
        Me.tab2ndTimechartPortChangeReq.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartPortChangeReq.TabIndex = 16
        Me.tab2ndTimechartPortChangeReq.Text = "Port Change Request"
        Me.tab2ndTimechartPortChangeReq.UseVisualStyleBackColor = True
        '
        'TimeChart_PortChangeReq1
        '
        Me.TimeChart_PortChangeReq1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_PortChangeReq1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_PortChangeReq1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_PortChangeReq1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_PortChangeReq1.Name = "TimeChart_PortChangeReq1"
        Me.TimeChart_PortChangeReq1.Size = New System.Drawing.Size(693, 261)
        Me.TimeChart_PortChangeReq1.TabIndex = 0
        '
        'tab2ndTimechartCVTR
        '
        Me.tab2ndTimechartCVTR.Controls.Add(Me.TimeChart_CVTR1)
        Me.tab2ndTimechartCVTR.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartCVTR.Name = "tab2ndTimechartCVTR"
        Me.tab2ndTimechartCVTR.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartCVTR.TabIndex = 17
        Me.tab2ndTimechartCVTR.Text = "Glass Transfer[CV->RST]"
        Me.tab2ndTimechartCVTR.UseVisualStyleBackColor = True
        '
        'TimeChart_CVTR1
        '
        Me.TimeChart_CVTR1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CVTR1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_CVTR1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_CVTR1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_CVTR1.Name = "TimeChart_CVTR1"
        Me.TimeChart_CVTR1.Size = New System.Drawing.Size(692, 379)
        Me.TimeChart_CVTR1.TabIndex = 0
        '
        'tab2ndTimechartRSTTR
        '
        Me.tab2ndTimechartRSTTR.Controls.Add(Me.TimeChart_RSTTR1)
        Me.tab2ndTimechartRSTTR.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndTimechartRSTTR.Name = "tab2ndTimechartRSTTR"
        Me.tab2ndTimechartRSTTR.Size = New System.Drawing.Size(952, 549)
        Me.tab2ndTimechartRSTTR.TabIndex = 18
        Me.tab2ndTimechartRSTTR.Text = "Glass Transfer[RST->CV]"
        Me.tab2ndTimechartRSTTR.UseVisualStyleBackColor = True
        '
        'TimeChart_RSTTR1
        '
        Me.TimeChart_RSTTR1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TimeChart_RSTTR1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TimeChart_RSTTR1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TimeChart_RSTTR1.Location = New System.Drawing.Point(5, 3)
        Me.TimeChart_RSTTR1.Name = "TimeChart_RSTTR1"
        Me.TimeChart_RSTTR1.Size = New System.Drawing.Size(689, 336)
        Me.TimeChart_RSTTR1.TabIndex = 0
        '
        'tab2ndStatusPort
        '
        Me.tab2ndStatusPort.Controls.Add(Me.PortStatus1)
        Me.tab2ndStatusPort.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndStatusPort.Name = "tab2ndStatusPort"
        Me.tab2ndStatusPort.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndStatusPort.TabIndex = 2
        Me.tab2ndStatusPort.Text = "Status Report[Port]"
        Me.tab2ndStatusPort.UseVisualStyleBackColor = True
        '
        'PortStatus1
        '
        Me.PortStatus1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.PortStatus1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.PortStatus1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.PortStatus1.ENGType = False
        Me.PortStatus1.Location = New System.Drawing.Point(3, 3)
        Me.PortStatus1.Name = "PortStatus1"
        Me.PortStatus1.Size = New System.Drawing.Size(734, 429)
        Me.PortStatus1.TabIndex = 0
        '
        'tab2ndLink
        '
        Me.tab2ndLink.Controls.Add(Me.LinkStatus1)
        Me.tab2ndLink.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndLink.Name = "tab2ndLink"
        Me.tab2ndLink.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2ndLink.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndLink.TabIndex = 0
        Me.tab2ndLink.Text = "Link Establishment"
        Me.tab2ndLink.UseVisualStyleBackColor = True
        '
        'LinkStatus1
        '
        Me.LinkStatus1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.LinkStatus1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.LinkStatus1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.LinkStatus1.ENGType = False
        Me.LinkStatus1.Location = New System.Drawing.Point(0, 0)
        Me.LinkStatus1.Name = "LinkStatus1"
        Me.LinkStatus1.Size = New System.Drawing.Size(813, 524)
        Me.LinkStatus1.TabIndex = 0
        '
        'tab2ndCVGlassDataReq
        '
        Me.tab2ndCVGlassDataReq.Controls.Add(Me.GxDataReq1)
        Me.tab2ndCVGlassDataReq.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCVGlassDataReq.Name = "tab2ndCVGlassDataReq"
        Me.tab2ndCVGlassDataReq.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCVGlassDataReq.TabIndex = 4
        Me.tab2ndCVGlassDataReq.Text = "Conveyor Glass Data Request"
        Me.tab2ndCVGlassDataReq.UseVisualStyleBackColor = True
        '
        'GxDataReq1
        '
        Me.GxDataReq1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.GxDataReq1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.GxDataReq1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.GxDataReq1.ENGType = False
        Me.GxDataReq1.Location = New System.Drawing.Point(3, 3)
        Me.GxDataReq1.Name = "GxDataReq1"
        Me.GxDataReq1.Size = New System.Drawing.Size(739, 504)
        Me.GxDataReq1.TabIndex = 0
        '
        'tab2ndCSTProcessCMD
        '
        Me.tab2ndCSTProcessCMD.Controls.Add(Me.CstProcessCMD1)
        Me.tab2ndCSTProcessCMD.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTProcessCMD.Name = "tab2ndCSTProcessCMD"
        Me.tab2ndCSTProcessCMD.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTProcessCMD.TabIndex = 3
        Me.tab2ndCSTProcessCMD.Text = "CST Process Command"
        Me.tab2ndCSTProcessCMD.UseVisualStyleBackColor = True
        '
        'CstProcessCMD1
        '
        Me.CstProcessCMD1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstProcessCMD1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstProcessCMD1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstProcessCMD1.ENGType = False
        Me.CstProcessCMD1.Location = New System.Drawing.Point(3, 3)
        Me.CstProcessCMD1.Name = "CstProcessCMD1"
        Me.CstProcessCMD1.Size = New System.Drawing.Size(781, 515)
        Me.CstProcessCMD1.TabIndex = 0
        '
        'tab2ndCVResetSignal
        '
        Me.tab2ndCVResetSignal.Controls.Add(Me.TrReset1)
        Me.tab2ndCVResetSignal.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCVResetSignal.Name = "tab2ndCVResetSignal"
        Me.tab2ndCVResetSignal.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCVResetSignal.TabIndex = 5
        Me.tab2ndCVResetSignal.Text = "Conveyor Reset Signal"
        Me.tab2ndCVResetSignal.UseVisualStyleBackColor = True
        '
        'TrReset1
        '
        Me.TrReset1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.TrReset1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.TrReset1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.TrReset1.ENGType = False
        Me.TrReset1.Location = New System.Drawing.Point(3, 3)
        Me.TrReset1.Name = "TrReset1"
        Me.TrReset1.Size = New System.Drawing.Size(734, 503)
        Me.TrReset1.TabIndex = 0
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AutoScroll = True
        Me.FlowLayoutPanel3.Controls.Add(Me.CvSignal1)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(6, 301)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(950, 288)
        Me.FlowLayoutPanel3.TabIndex = 1
        '
        'CvSignal1
        '
        Me.CvSignal1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CvSignal1.BackColorForSignalON = System.Drawing.Color.Empty
        Me.CvSignal1.Location = New System.Drawing.Point(3, 3)
        Me.CvSignal1.Name = "CvSignal1"
        Me.CvSignal1.Size = New System.Drawing.Size(960, 500)
        Me.CvSignal1.TabIndex = 0
        '
        'tab2ndConveyor
        '
        Me.tab2ndConveyor.Controls.Add(Me.FlowLayoutPanel3)
        Me.tab2ndConveyor.Controls.Add(Me.FlowLayoutPanel2)
        Me.tab2ndConveyor.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndConveyor.Name = "tab2ndConveyor"
        Me.tab2ndConveyor.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2ndConveyor.Size = New System.Drawing.Size(959, 591)
        Me.tab2ndConveyor.TabIndex = 0
        Me.tab2ndConveyor.Text = "Conveyor"
        Me.tab2ndConveyor.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.Controls.Add(Me.RstSignal1)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(6, 6)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(950, 293)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'RstSignal1
        '
        Me.RstSignal1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.RstSignal1.BackColorForSignalON = System.Drawing.Color.Empty
        Me.RstSignal1.Location = New System.Drawing.Point(3, 3)
        Me.RstSignal1.Name = "RstSignal1"
        Me.RstSignal1.Size = New System.Drawing.Size(974, 667)
        Me.RstSignal1.TabIndex = 0
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tab2ndConveyor)
        Me.TabControl2.Controls.Add(Me.tab2ndPLCMap)
        Me.TabControl2.Location = New System.Drawing.Point(6, 6)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(967, 617)
        Me.TabControl2.TabIndex = 0
        '
        'tab2ndPLCMap
        '
        Me.tab2ndPLCMap.Controls.Add(Me.DGV)
        Me.tab2ndPLCMap.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndPLCMap.Name = "tab2ndPLCMap"
        Me.tab2ndPLCMap.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2ndPLCMap.Size = New System.Drawing.Size(959, 591)
        Me.tab2ndPLCMap.TabIndex = 1
        Me.tab2ndPLCMap.Text = "PLC Map"
        Me.tab2ndPLCMap.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(6, 3)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowTemplate.Height = 24
        Me.DGV.Size = New System.Drawing.Size(598, 582)
        Me.DGV.TabIndex = 1
        '
        'tab1StGeneral
        '
        Me.tab1StGeneral.Controls.Add(Me.TabControl2)
        Me.tab1StGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tab1StGeneral.Name = "tab1StGeneral"
        Me.tab1StGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tab1StGeneral.Size = New System.Drawing.Size(976, 627)
        Me.tab1StGeneral.TabIndex = 0
        Me.tab1StGeneral.Text = "General"
        Me.tab1StGeneral.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.AlarmMonitor1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(776, 542)
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
        'tab2ndStatusMain
        '
        Me.tab2ndStatusMain.Controls.Add(Me.StatusReport1)
        Me.tab2ndStatusMain.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndStatusMain.Name = "tab2ndStatusMain"
        Me.tab2ndStatusMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2ndStatusMain.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndStatusMain.TabIndex = 1
        Me.tab2ndStatusMain.Text = "Status Report[Main]"
        Me.tab2ndStatusMain.UseVisualStyleBackColor = True
        '
        'StatusReport1
        '
        Me.StatusReport1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.StatusReport1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.StatusReport1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.StatusReport1.ENGType = False
        Me.StatusReport1.Location = New System.Drawing.Point(6, 6)
        Me.StatusReport1.Name = "StatusReport1"
        Me.StatusReport1.Size = New System.Drawing.Size(736, 760)
        Me.StatusReport1.TabIndex = 0
        '
        'tab2ndCSTLoadReq
        '
        Me.tab2ndCSTLoadReq.Controls.Add(Me.CstLoadReq1)
        Me.tab2ndCSTLoadReq.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTLoadReq.Name = "tab2ndCSTLoadReq"
        Me.tab2ndCSTLoadReq.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTLoadReq.TabIndex = 8
        Me.tab2ndCSTLoadReq.Text = "Gassette Load Request"
        Me.tab2ndCSTLoadReq.UseVisualStyleBackColor = True
        '
        'CstLoadReq1
        '
        Me.CstLoadReq1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstLoadReq1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstLoadReq1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstLoadReq1.ENGType = False
        Me.CstLoadReq1.Location = New System.Drawing.Point(3, 3)
        Me.CstLoadReq1.Name = "CstLoadReq1"
        Me.CstLoadReq1.Size = New System.Drawing.Size(733, 503)
        Me.CstLoadReq1.TabIndex = 0
        '
        'tab2ndGxAbnormalReport
        '
        Me.tab2ndGxAbnormalReport.Controls.Add(Me.GxAbnormal1)
        Me.tab2ndGxAbnormalReport.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndGxAbnormalReport.Name = "tab2ndGxAbnormalReport"
        Me.tab2ndGxAbnormalReport.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndGxAbnormalReport.TabIndex = 6
        Me.tab2ndGxAbnormalReport.Text = "Glass Abnormal Report"
        Me.tab2ndGxAbnormalReport.UseVisualStyleBackColor = True
        '
        'GxAbnormal1
        '
        Me.GxAbnormal1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.GxAbnormal1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.GxAbnormal1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.GxAbnormal1.ENGType = False
        Me.GxAbnormal1.Location = New System.Drawing.Point(3, 0)
        Me.GxAbnormal1.Name = "GxAbnormal1"
        Me.GxAbnormal1.Size = New System.Drawing.Size(738, 503)
        Me.GxAbnormal1.TabIndex = 0
        '
        'tab2ndGxInfoUnmatchReport
        '
        Me.tab2ndGxInfoUnmatchReport.Controls.Add(Me.GxInfoUnmatch1)
        Me.tab2ndGxInfoUnmatchReport.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndGxInfoUnmatchReport.Name = "tab2ndGxInfoUnmatchReport"
        Me.tab2ndGxInfoUnmatchReport.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndGxInfoUnmatchReport.TabIndex = 7
        Me.tab2ndGxInfoUnmatchReport.Text = "Glass Info. Unmatch Report"
        Me.tab2ndGxInfoUnmatchReport.UseVisualStyleBackColor = True
        '
        'GxInfoUnmatch1
        '
        Me.GxInfoUnmatch1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.GxInfoUnmatch1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.GxInfoUnmatch1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.GxInfoUnmatch1.ENGType = False
        Me.GxInfoUnmatch1.Location = New System.Drawing.Point(3, 3)
        Me.GxInfoUnmatch1.Name = "GxInfoUnmatch1"
        Me.GxInfoUnmatch1.Size = New System.Drawing.Size(734, 503)
        Me.GxInfoUnmatch1.TabIndex = 0
        '
        'tab2ndCSTLoadComp
        '
        Me.tab2ndCSTLoadComp.Controls.Add(Me.CstLoadComplete1)
        Me.tab2ndCSTLoadComp.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTLoadComp.Name = "tab2ndCSTLoadComp"
        Me.tab2ndCSTLoadComp.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTLoadComp.TabIndex = 9
        Me.tab2ndCSTLoadComp.Text = "Cassette Load Complete"
        Me.tab2ndCSTLoadComp.UseVisualStyleBackColor = True
        '
        'CstLoadComplete1
        '
        Me.CstLoadComplete1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstLoadComplete1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstLoadComplete1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstLoadComplete1.ENGType = False
        Me.CstLoadComplete1.Location = New System.Drawing.Point(3, 3)
        Me.CstLoadComplete1.Name = "CstLoadComplete1"
        Me.CstLoadComplete1.Size = New System.Drawing.Size(731, 506)
        Me.CstLoadComplete1.TabIndex = 0
        '
        'tab2ndGxFlowOut
        '
        Me.tab2ndGxFlowOut.Controls.Add(Me.GxFlowOut1)
        Me.tab2ndGxFlowOut.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndGxFlowOut.Name = "tab2ndGxFlowOut"
        Me.tab2ndGxFlowOut.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndGxFlowOut.TabIndex = 10
        Me.tab2ndGxFlowOut.Text = "Glass Flow Out"
        Me.tab2ndGxFlowOut.UseVisualStyleBackColor = True
        '
        'GxFlowOut1
        '
        Me.GxFlowOut1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.GxFlowOut1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.GxFlowOut1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.GxFlowOut1.ENGType = False
        Me.GxFlowOut1.Location = New System.Drawing.Point(3, 3)
        Me.GxFlowOut1.Name = "GxFlowOut1"
        Me.GxFlowOut1.Size = New System.Drawing.Size(735, 503)
        Me.GxFlowOut1.TabIndex = 0
        '
        'tab2ndGxFlowIn
        '
        Me.tab2ndGxFlowIn.Controls.Add(Me.GxFlowIn1)
        Me.tab2ndGxFlowIn.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndGxFlowIn.Name = "tab2ndGxFlowIn"
        Me.tab2ndGxFlowIn.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndGxFlowIn.TabIndex = 11
        Me.tab2ndGxFlowIn.Text = "Glass Flow In"
        Me.tab2ndGxFlowIn.UseVisualStyleBackColor = True
        '
        'GxFlowIn1
        '
        Me.GxFlowIn1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.GxFlowIn1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.GxFlowIn1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.GxFlowIn1.ENGType = False
        Me.GxFlowIn1.Location = New System.Drawing.Point(3, 3)
        Me.GxFlowIn1.Name = "GxFlowIn1"
        Me.GxFlowIn1.Size = New System.Drawing.Size(735, 504)
        Me.GxFlowIn1.TabIndex = 0
        '
        'tab2ndCSTUnloadByCV
        '
        Me.tab2ndCSTUnloadByCV.Controls.Add(Me.CstUnloadByCV1)
        Me.tab2ndCSTUnloadByCV.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTUnloadByCV.Name = "tab2ndCSTUnloadByCV"
        Me.tab2ndCSTUnloadByCV.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTUnloadByCV.TabIndex = 12
        Me.tab2ndCSTUnloadByCV.Text = "Cassette Unload Request By Conveyor"
        Me.tab2ndCSTUnloadByCV.UseVisualStyleBackColor = True
        '
        'CstUnloadByCV1
        '
        Me.CstUnloadByCV1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstUnloadByCV1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstUnloadByCV1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstUnloadByCV1.ENGType = False
        Me.CstUnloadByCV1.Location = New System.Drawing.Point(3, 3)
        Me.CstUnloadByCV1.Name = "CstUnloadByCV1"
        Me.CstUnloadByCV1.Size = New System.Drawing.Size(734, 503)
        Me.CstUnloadByCV1.TabIndex = 0
        '
        'tab2ndCSTUnloadByRST
        '
        Me.tab2ndCSTUnloadByRST.Controls.Add(Me.CstUnloadByRST1)
        Me.tab2ndCSTUnloadByRST.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTUnloadByRST.Name = "tab2ndCSTUnloadByRST"
        Me.tab2ndCSTUnloadByRST.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTUnloadByRST.TabIndex = 13
        Me.tab2ndCSTUnloadByRST.Text = "Cassette Unload Request By RST"
        Me.tab2ndCSTUnloadByRST.UseVisualStyleBackColor = True
        '
        'CstUnloadByRST1
        '
        Me.CstUnloadByRST1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstUnloadByRST1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstUnloadByRST1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstUnloadByRST1.ENGType = False
        Me.CstUnloadByRST1.Location = New System.Drawing.Point(3, 3)
        Me.CstUnloadByRST1.Name = "CstUnloadByRST1"
        Me.CstUnloadByRST1.Size = New System.Drawing.Size(738, 504)
        Me.CstUnloadByRST1.TabIndex = 0
        '
        'tab2ndCSTUnloadComp
        '
        Me.tab2ndCSTUnloadComp.Controls.Add(Me.CstUnloadComp1)
        Me.tab2ndCSTUnloadComp.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTUnloadComp.Name = "tab2ndCSTUnloadComp"
        Me.tab2ndCSTUnloadComp.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTUnloadComp.TabIndex = 14
        Me.tab2ndCSTUnloadComp.Text = "Cassette Unload Complete"
        Me.tab2ndCSTUnloadComp.UseVisualStyleBackColor = True
        '
        'CstUnloadComp1
        '
        Me.CstUnloadComp1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstUnloadComp1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstUnloadComp1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstUnloadComp1.ENGType = False
        Me.CstUnloadComp1.Location = New System.Drawing.Point(3, 3)
        Me.CstUnloadComp1.Name = "CstUnloadComp1"
        Me.CstUnloadComp1.Size = New System.Drawing.Size(740, 506)
        Me.CstUnloadComp1.TabIndex = 0
        '
        'tab2ndCSTDummyCancel
        '
        Me.tab2ndCSTDummyCancel.Controls.Add(Me.CstDummyCancel1)
        Me.tab2ndCSTDummyCancel.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTDummyCancel.Name = "tab2ndCSTDummyCancel"
        Me.tab2ndCSTDummyCancel.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTDummyCancel.TabIndex = 15
        Me.tab2ndCSTDummyCancel.Text = "Cassette Dummy Cancel"
        Me.tab2ndCSTDummyCancel.UseVisualStyleBackColor = True
        '
        'CstDummyCancel1
        '
        Me.CstDummyCancel1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstDummyCancel1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstDummyCancel1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstDummyCancel1.ENGType = False
        Me.CstDummyCancel1.Location = New System.Drawing.Point(3, 3)
        Me.CstDummyCancel1.Name = "CstDummyCancel1"
        Me.CstDummyCancel1.Size = New System.Drawing.Size(736, 498)
        Me.CstDummyCancel1.TabIndex = 0
        '
        'tab2ndPortResume
        '
        Me.tab2ndPortResume.Controls.Add(Me.PortResume1)
        Me.tab2ndPortResume.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndPortResume.Name = "tab2ndPortResume"
        Me.tab2ndPortResume.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndPortResume.TabIndex = 23
        Me.tab2ndPortResume.Text = "Port Resume"
        Me.tab2ndPortResume.UseVisualStyleBackColor = True
        '
        'PortResume1
        '
        Me.PortResume1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.PortResume1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.PortResume1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.PortResume1.ENGType = False
        Me.PortResume1.Location = New System.Drawing.Point(3, 3)
        Me.PortResume1.Name = "PortResume1"
        Me.PortResume1.Size = New System.Drawing.Size(733, 501)
        Me.PortResume1.TabIndex = 0
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.tab2ndLink)
        Me.TabControl3.Controls.Add(Me.tab2ndStatusMain)
        Me.TabControl3.Controls.Add(Me.tab2ndStatusPort)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTProcessCMD)
        Me.TabControl3.Controls.Add(Me.tab2ndCVGlassDataReq)
        Me.TabControl3.Controls.Add(Me.tab2ndCVResetSignal)
        Me.TabControl3.Controls.Add(Me.tab2ndGxAbnormalReport)
        Me.TabControl3.Controls.Add(Me.tab2ndGxInfoUnmatchReport)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTLoadReq)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTLoadComp)
        Me.TabControl3.Controls.Add(Me.tab2ndGxFlowOut)
        Me.TabControl3.Controls.Add(Me.tab2ndGxFlowIn)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTUnloadByCV)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTUnloadByRST)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTUnloadComp)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTDummyCancel)
        Me.TabControl3.Controls.Add(Me.tab2ndPortChangeReq)
        Me.TabControl3.Controls.Add(Me.tab2ndCV2RSTTR)
        Me.TabControl3.Controls.Add(Me.tab2ndRST2CVTR)
        Me.TabControl3.Controls.Add(Me.tab2ndAlarm)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTPresent)
        Me.TabControl3.Controls.Add(Me.tab2ndCSTRemoved)
        Me.TabControl3.Controls.Add(Me.tab2ndPortPause)
        Me.TabControl3.Controls.Add(Me.tab2ndPortResume)
        Me.TabControl3.Location = New System.Drawing.Point(3, 3)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(959, 750)
        Me.TabControl3.TabIndex = 0
        '
        'tab2ndPortChangeReq
        '
        Me.tab2ndPortChangeReq.Controls.Add(Me.PortChangeReq1)
        Me.tab2ndPortChangeReq.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndPortChangeReq.Name = "tab2ndPortChangeReq"
        Me.tab2ndPortChangeReq.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndPortChangeReq.TabIndex = 16
        Me.tab2ndPortChangeReq.Text = "Port Change Request"
        Me.tab2ndPortChangeReq.UseVisualStyleBackColor = True
        '
        'PortChangeReq1
        '
        Me.PortChangeReq1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.PortChangeReq1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.PortChangeReq1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.PortChangeReq1.ENGType = False
        Me.PortChangeReq1.Location = New System.Drawing.Point(2, 3)
        Me.PortChangeReq1.Name = "PortChangeReq1"
        Me.PortChangeReq1.Size = New System.Drawing.Size(733, 501)
        Me.PortChangeReq1.TabIndex = 0
        '
        'tab2ndCV2RSTTR
        '
        Me.tab2ndCV2RSTTR.Controls.Add(Me.GxtR_CV2RST1)
        Me.tab2ndCV2RSTTR.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCV2RSTTR.Name = "tab2ndCV2RSTTR"
        Me.tab2ndCV2RSTTR.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCV2RSTTR.TabIndex = 17
        Me.tab2ndCV2RSTTR.Text = "Glass Transfer[CV->RST]"
        Me.tab2ndCV2RSTTR.UseVisualStyleBackColor = True
        '
        'GxtR_CV2RST1
        '
        Me.GxtR_CV2RST1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.GxtR_CV2RST1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.GxtR_CV2RST1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.GxtR_CV2RST1.ENGType = False
        Me.GxtR_CV2RST1.Location = New System.Drawing.Point(3, 3)
        Me.GxtR_CV2RST1.Name = "GxtR_CV2RST1"
        Me.GxtR_CV2RST1.Size = New System.Drawing.Size(733, 500)
        Me.GxtR_CV2RST1.TabIndex = 0
        '
        'tab2ndRST2CVTR
        '
        Me.tab2ndRST2CVTR.Controls.Add(Me.GxTR_RST2CV1)
        Me.tab2ndRST2CVTR.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndRST2CVTR.Name = "tab2ndRST2CVTR"
        Me.tab2ndRST2CVTR.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndRST2CVTR.TabIndex = 18
        Me.tab2ndRST2CVTR.Text = "Glass Transfer[RST->CV]"
        Me.tab2ndRST2CVTR.UseVisualStyleBackColor = True
        '
        'GxTR_RST2CV1
        '
        Me.GxTR_RST2CV1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.GxTR_RST2CV1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.GxTR_RST2CV1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.GxTR_RST2CV1.ENGType = False
        Me.GxTR_RST2CV1.Location = New System.Drawing.Point(3, 3)
        Me.GxTR_RST2CV1.Name = "GxTR_RST2CV1"
        Me.GxTR_RST2CV1.Size = New System.Drawing.Size(734, 501)
        Me.GxTR_RST2CV1.TabIndex = 0
        '
        'tab2ndAlarm
        '
        Me.tab2ndAlarm.Controls.Add(Me.FlowLayoutPanel1)
        Me.tab2ndAlarm.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndAlarm.Name = "tab2ndAlarm"
        Me.tab2ndAlarm.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndAlarm.TabIndex = 19
        Me.tab2ndAlarm.Text = "Alarm"
        Me.tab2ndAlarm.UseVisualStyleBackColor = True
        '
        'tab2ndCSTPresent
        '
        Me.tab2ndCSTPresent.Controls.Add(Me.CstPresent1)
        Me.tab2ndCSTPresent.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTPresent.Name = "tab2ndCSTPresent"
        Me.tab2ndCSTPresent.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTPresent.TabIndex = 20
        Me.tab2ndCSTPresent.Text = "Cassette Present"
        Me.tab2ndCSTPresent.UseVisualStyleBackColor = True
        '
        'CstPresent1
        '
        Me.CstPresent1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstPresent1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstPresent1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstPresent1.ENGType = False
        Me.CstPresent1.Location = New System.Drawing.Point(3, 3)
        Me.CstPresent1.Name = "CstPresent1"
        Me.CstPresent1.Size = New System.Drawing.Size(736, 507)
        Me.CstPresent1.TabIndex = 0
        '
        'tab2ndCSTRemoved
        '
        Me.tab2ndCSTRemoved.Controls.Add(Me.CstRemoved1)
        Me.tab2ndCSTRemoved.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndCSTRemoved.Name = "tab2ndCSTRemoved"
        Me.tab2ndCSTRemoved.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndCSTRemoved.TabIndex = 21
        Me.tab2ndCSTRemoved.Text = "Cassette Removed"
        Me.tab2ndCSTRemoved.UseVisualStyleBackColor = True
        '
        'CstRemoved1
        '
        Me.CstRemoved1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.CstRemoved1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.CstRemoved1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.CstRemoved1.ENGType = False
        Me.CstRemoved1.Location = New System.Drawing.Point(3, 3)
        Me.CstRemoved1.Name = "CstRemoved1"
        Me.CstRemoved1.Size = New System.Drawing.Size(736, 504)
        Me.CstRemoved1.TabIndex = 0
        '
        'tab2ndPortPause
        '
        Me.tab2ndPortPause.Controls.Add(Me.PortPause1)
        Me.tab2ndPortPause.Location = New System.Drawing.Point(4, 22)
        Me.tab2ndPortPause.Name = "tab2ndPortPause"
        Me.tab2ndPortPause.Size = New System.Drawing.Size(951, 724)
        Me.tab2ndPortPause.TabIndex = 22
        Me.tab2ndPortPause.Text = "Port Pause"
        Me.tab2ndPortPause.UseVisualStyleBackColor = True
        '
        'PortPause1
        '
        Me.PortPause1.BackColorForCVSignalON = System.Drawing.Color.Empty
        Me.PortPause1.BackColorForRSTSignalON = System.Drawing.Color.Empty
        Me.PortPause1.BackColorForSignalOFF = System.Drawing.Color.Empty
        Me.PortPause1.ENGType = False
        Me.PortPause1.Location = New System.Drawing.Point(3, 3)
        Me.PortPause1.Name = "PortPause1"
        Me.PortPause1.Size = New System.Drawing.Size(731, 500)
        Me.PortPause1.TabIndex = 0
        '
        'tab1StConveyor
        '
        Me.tab1StConveyor.Controls.Add(Me.TabControl3)
        Me.tab1StConveyor.Location = New System.Drawing.Point(4, 22)
        Me.tab1StConveyor.Name = "tab1StConveyor"
        Me.tab1StConveyor.Padding = New System.Windows.Forms.Padding(3)
        Me.tab1StConveyor.Size = New System.Drawing.Size(976, 758)
        Me.tab1StConveyor.TabIndex = 1
        Me.tab1StConveyor.Text = "Conveyor"
        Me.tab1StConveyor.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab1StGeneral)
        Me.TabControl1.Controls.Add(Me.tab1StConveyor)
        Me.TabControl1.Controls.Add(Me.tab1StTimeChart)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(984, 653)
        Me.TabControl1.TabIndex = 4
        '
        'ctlCVGUIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ctlCVGUIMain"
        Me.Size = New System.Drawing.Size(990, 790)
        Me.tab1StTimeChart.ResumeLayout(False)
        Me.TabControl6.ResumeLayout(False)
        Me.tab2ndTimechartLink.ResumeLayout(False)
        Me.tab2ndTimechartCSTProcessCMD.ResumeLayout(False)
        Me.tab2ndTimechartGxDataReq.ResumeLayout(False)
        Me.tab2ndTimechartTRReset.ResumeLayout(False)
        Me.tab2ndTimechartGxAbnormal.ResumeLayout(False)
        Me.tab2ndTimechartGxInfoUnmatch.ResumeLayout(False)
        Me.tab2ndTimechartCSTLoadReq.ResumeLayout(False)
        Me.tab2ndTimechartCSTLoadComp.ResumeLayout(False)
        Me.tab2ndTimechartGxFlowOut.ResumeLayout(False)
        Me.tab2ndTimechartGxFlowIn.ResumeLayout(False)
        Me.tab2ndTimechartCSTUnloadByCV.ResumeLayout(False)
        Me.tab2ndTimechartCSTUnloadByRST.ResumeLayout(False)
        Me.tab2ndTimechartCSTUnloadComp.ResumeLayout(False)
        Me.tab2ndTimechartCSTDummyCancel.ResumeLayout(False)
        Me.tab2ndTimechartPortChangeReq.ResumeLayout(False)
        Me.tab2ndTimechartCVTR.ResumeLayout(False)
        Me.tab2ndTimechartRSTTR.ResumeLayout(False)
        Me.tab2ndStatusPort.ResumeLayout(False)
        Me.tab2ndLink.ResumeLayout(False)
        Me.tab2ndCVGlassDataReq.ResumeLayout(False)
        Me.tab2ndCSTProcessCMD.ResumeLayout(False)
        Me.tab2ndCVResetSignal.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.tab2ndConveyor.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tab2ndPLCMap.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab1StGeneral.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.tab2ndStatusMain.ResumeLayout(False)
        Me.tab2ndCSTLoadReq.ResumeLayout(False)
        Me.tab2ndGxAbnormalReport.ResumeLayout(False)
        Me.tab2ndGxInfoUnmatchReport.ResumeLayout(False)
        Me.tab2ndCSTLoadComp.ResumeLayout(False)
        Me.tab2ndGxFlowOut.ResumeLayout(False)
        Me.tab2ndGxFlowIn.ResumeLayout(False)
        Me.tab2ndCSTUnloadByCV.ResumeLayout(False)
        Me.tab2ndCSTUnloadByRST.ResumeLayout(False)
        Me.tab2ndCSTUnloadComp.ResumeLayout(False)
        Me.tab2ndCSTDummyCancel.ResumeLayout(False)
        Me.tab2ndPortResume.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.tab2ndPortChangeReq.ResumeLayout(False)
        Me.tab2ndCV2RSTTR.ResumeLayout(False)
        Me.tab2ndRST2CVTR.ResumeLayout(False)
        Me.tab2ndAlarm.ResumeLayout(False)
        Me.tab2ndCSTPresent.ResumeLayout(False)
        Me.tab2ndCSTRemoved.ResumeLayout(False)
        Me.tab2ndPortPause.ResumeLayout(False)
        Me.tab1StConveyor.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab1StTimeChart As System.Windows.Forms.TabPage
    Friend WithEvents TabControl6 As System.Windows.Forms.TabControl
    Friend WithEvents tab2ndTimechartLink As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_Link1 As WindowsControlLibrary1.TimeChart_Link
    Friend WithEvents tab2ndTimechartCSTProcessCMD As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CSTProcessReq1 As WindowsControlLibrary1.TimeChart_CSTProcessReq
    Friend WithEvents tab2ndTimechartGxDataReq As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_GxDataReq1 As WindowsControlLibrary1.TimeChart_GxDataReq
    Friend WithEvents tab2ndTimechartTRReset As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_TRReset1 As WindowsControlLibrary1.TimeChart_TRReset
    Friend WithEvents tab2ndTimechartGxAbnormal As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_GxAbnormal1 As WindowsControlLibrary1.TimeChart_GxAbnormal
    Friend WithEvents tab2ndTimechartGxInfoUnmatch As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_GxSlotUnmatch1 As WindowsControlLibrary1.TimeChart_GxSlotUnmatch
    Friend WithEvents tab2ndTimechartCSTLoadReq As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CSTLoadreq1 As WindowsControlLibrary1.TimeChart_CSTLoadreq
    Friend WithEvents tab2ndTimechartCSTLoadComp As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CSTLoadComp1 As WindowsControlLibrary1.TimeChart_CSTLoadComp
    Friend WithEvents tab2ndTimechartGxFlowOut As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_GxFlowOut1 As WindowsControlLibrary1.TimeChart_GxFlowOut
    Friend WithEvents tab2ndTimechartGxFlowIn As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_GxFlowIn1 As WindowsControlLibrary1.TimeChart_GxFlowIn
    Friend WithEvents tab2ndTimechartCSTUnloadByCV As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CSTUnloadReqByCV1 As WindowsControlLibrary1.TimeChart_CSTUnloadReqByCV
    Friend WithEvents tab2ndTimechartCSTUnloadByRST As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CSTUnloadReqByRST1 As WindowsControlLibrary1.TimeChart_CSTUnloadReqByRST
    Friend WithEvents tab2ndTimechartCSTUnloadComp As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CSTUnloadComp1 As WindowsControlLibrary1.TimeChart_CSTUnloadComp
    Friend WithEvents tab2ndTimechartCSTDummyCancel As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CSTDummyCancel1 As WindowsControlLibrary1.TimeChart_CSTDummyCancel
    Friend WithEvents tab2ndTimechartPortChangeReq As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_PortChangeReq1 As WindowsControlLibrary1.TimeChart_PortChangeReq
    Friend WithEvents tab2ndTimechartCVTR As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_CVTR1 As WindowsControlLibrary1.TimeChart_CVTR
    Friend WithEvents tab2ndTimechartRSTTR As System.Windows.Forms.TabPage
    Friend WithEvents TimeChart_RSTTR1 As WindowsControlLibrary1.TimeChart_RSTTR
    Friend WithEvents CstLoadComplete1 As WindowsControlLibrary1.CSTLoadComplete
    Friend WithEvents tab2ndStatusPort As System.Windows.Forms.TabPage
    Friend WithEvents PortStatus1 As WindowsControlLibrary1.PortStatus
    Friend WithEvents CstLoadReq1 As WindowsControlLibrary1.CSTLoadReq
    Friend WithEvents tab2ndLink As System.Windows.Forms.TabPage
    Friend WithEvents LinkStatus1 As WindowsControlLibrary1.LinkStatus
    Friend WithEvents GxFlowOut1 As WindowsControlLibrary1.GxFlowOut
    Friend WithEvents GxFlowIn1 As WindowsControlLibrary1.GxFlowIn
    Friend WithEvents CstUnloadByRST1 As WindowsControlLibrary1.CSTUnloadByRST
    Friend WithEvents tab2ndCVGlassDataReq As System.Windows.Forms.TabPage
    Friend WithEvents GxDataReq1 As WindowsControlLibrary1.GxDataReq
    Friend WithEvents CstUnloadByCV1 As WindowsControlLibrary1.CSTUnloadByCV
    Friend WithEvents GxInfoUnmatch1 As WindowsControlLibrary1.GxInfoUnmatch
    Friend WithEvents tab2ndCSTProcessCMD As System.Windows.Forms.TabPage
    Friend WithEvents CstProcessCMD1 As WindowsControlLibrary1.CSTProcessCMD
    Friend WithEvents GxAbnormal1 As WindowsControlLibrary1.GxAbnormal
    Friend WithEvents StatusReport1 As WindowsControlLibrary1.StatusReport
    Friend WithEvents TrReset1 As WindowsControlLibrary1.TRReset
    Friend WithEvents CstUnloadComp1 As WindowsControlLibrary1.CSTUnloadComp
    Friend WithEvents tab2ndCVResetSignal As System.Windows.Forms.TabPage
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CvSignal1 As WindowsControlLibrary1.CVSignal
    Friend WithEvents CstDummyCancel1 As WindowsControlLibrary1.CSTDummyCancel
    Friend WithEvents tab2ndConveyor As System.Windows.Forms.TabPage
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents RstSignal1 As WindowsControlLibrary1.RSTSignal
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tab2ndPLCMap As System.Windows.Forms.TabPage
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents tab1StGeneral As System.Windows.Forms.TabPage
    Friend WithEvents GxTR_RST2CV1 As WindowsControlLibrary1.GxTR_RST2CV
    Friend WithEvents PortResume1 As WindowsControlLibrary1.PortResume
    Friend WithEvents GxtR_CV2RST1 As WindowsControlLibrary1.GXTR_CV2RST
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents AlarmMonitor1 As WindowsControlLibrary1.AlarmMonitor
    Friend WithEvents PortChangeReq1 As WindowsControlLibrary1.PortChangeReq
    Friend WithEvents PortPause1 As WindowsControlLibrary1.PortPause
    Friend WithEvents CstRemoved1 As WindowsControlLibrary1.CSTRemoved
    Friend WithEvents tab2ndStatusMain As System.Windows.Forms.TabPage
    Friend WithEvents CstPresent1 As WindowsControlLibrary1.CSTPresent
    Friend WithEvents tab2ndCSTLoadReq As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndGxAbnormalReport As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndGxInfoUnmatchReport As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCSTLoadComp As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndGxFlowOut As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndGxFlowIn As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCSTUnloadByCV As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCSTUnloadByRST As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCSTUnloadComp As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCSTDummyCancel As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndPortResume As System.Windows.Forms.TabPage
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents tab2ndPortChangeReq As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCV2RSTTR As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndRST2CVTR As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndAlarm As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCSTPresent As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndCSTRemoved As System.Windows.Forms.TabPage
    Friend WithEvents tab2ndPortPause As System.Windows.Forms.TabPage
    Friend WithEvents tab1StConveyor As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
End Class
