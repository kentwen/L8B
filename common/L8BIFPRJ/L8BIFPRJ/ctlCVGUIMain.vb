Imports System.Drawing
Public Class ctlCVGUIMain

    Dim colAddName As New Collection
    Dim colAddressID As New Collection
    Public Event ENGSignalChange(ByVal lngSignalID As Long)


    Private mvarCurrentGUIIdx As eCVGUIIndex
    Private mvarTabConvertString As String
    Private mvarTabConvertHex As Long

    Private mvarENGMode As Boolean

    Dim WithEvents MyTimer As New Timer
    Dim WithEvents MyCheckTimer As New Timer


    Private Enum eCVGUIIndex
        IDX_1ST_SIGNAL
        IDX_1ST_MAP
        IDX_2ND_11LINK
        IDX_2ND_12STATUS_MAIN
        IDX_2ND_13STATUS_PORT
        IDX_2ND_14CST_PROCESS_CMD
        IDX_2ND_15GX_DATA_REQ
        IDX_2ND_16TR_RESET
        IDX_2ND_17GX_ABNORMAL
        IDX_2ND_18GX_INFO_UNMATCH
        IDX_2ND_19CST_LOAD_REQ
        IDX_2ND_21CST_LOAD_COMP
        IDX_2ND_22GX_FLOW_OUT
        IDX_2ND_23GX_FLOW_IN
        IDX_2ND_24CST_UNLOAD_BY_CV
        IDX_2ND_25CST_UNLOAD_BY_RST
        IDX_2ND_26CST_UNLOAD_COMP
        IDX_2ND_27CST_DUMMY_CANCEL
        IDX_2ND_28PORT_CHANGE_REQ
        IDX_2ND_29GXTR_BYCV
        IDX_2ND_31GXTR_BYRST
        IDX_2ND_32ALARM
        IDX_2ND_33CST_PRESENT
        IDX_2ND_34CST_REMOVED
        IDX_2ND_35PORT_PAUSE
        IDX_2ND_36PORT_RESUME
        IDX_3ND_11LINK
        IDX_3ND_12CST_PROCESS_CMD
        IDX_3ND_13GX_DATA_REQ
        IDX_3ND_14TR_RESET
        IDX_3ND_15GX_ABNORMAL
        IDX_3ND_16GX_INFO_UNMATCH
        IDX_3ND_17CST_LOAD_REQ
        IDX_3ND_18CST_LOAD_COMP
        IDX_3ND_19GX_FLOW_OUT
        IDX_3ND_21GX_FLOW_IN
        IDX_3ND_22CST_UNLOAD_BY_CV
        IDX_3ND_23CST_UNLOAD_BY_RST
        IDX_3ND_24CST_UNLOAD_COMP
        IDX_3ND_25DUMMY_CANCEL
        IDX_3ND_26PORT_CHANGE
        IDX_3ND_27CVTR
        IDX_3ND_28RSTTR
    End Enum


    Public Property ENGMode() As Boolean
        Get
            ENGMode = mvarENGMode
        End Get
        Set(ByVal value As Boolean)
            mvarENGMode = value
            Me.CstDummyCancel1.ENGType = value
            Me.CstLoadComplete1.ENGType = value
            Me.CstLoadReq1.ENGType = value
            Me.CstPresent1.ENGType = value
            Me.CstProcessCMD1.ENGType = value
            Me.CstRemoved1.ENGType = value
            Me.CstUnloadByCV1.ENGType = value
            Me.CstUnloadByRST1.ENGType = value
            Me.CstUnloadComp1.ENGType = value
            Me.GxAbnormal1.ENGType = value
            Me.GxDataReq1.ENGType = value
            Me.GxFlowIn1.ENGType = value
            Me.GxFlowOut1.ENGType = value
            Me.GxInfoUnmatch1.ENGType = value
            Me.GxtR_CV2RST1.ENGType = value
            Me.GxTR_RST2CV1.ENGType = value
            Me.LinkStatus1.ENGType = value
            Me.PortChangeReq1.ENGType = value
            Me.PortPause1.ENGType = value
            Me.PortResume1.ENGType = value
            Me.PortStatus1.ENGType = value
        End Set
    End Property

    Public WriteOnly Property BackColorForRSTSignalON() As System.Drawing.Color
        Set(ByVal value As System.Drawing.Color)
            Me.RstSignal1.BackColorForSignalON = value
            Me.LinkStatus1.BackColorForRSTSignalON = value
            Me.CstDummyCancel1.BackColorForRSTSignalON = value
            Me.CstLoadComplete1.BackColorForRSTSignalON = value
            Me.CstLoadReq1.BackColorForRSTSignalON = value
            Me.CstPresent1.BackColorForRSTSignalON = value
            Me.CstProcessCMD1.BackColorForRSTSignalON = value
            Me.CstRemoved1.BackColorForRSTSignalON = value
            Me.CstUnloadByCV1.BackColorForRSTSignalON = value
            Me.CstUnloadByRST1.BackColorForRSTSignalON = value
            Me.CstUnloadComp1.BackColorForRSTSignalON = value
            Me.GxAbnormal1.BackColorForRSTSignalON = value
            Me.GxDataReq1.BackColorForRSTSignalON = value
            Me.GxFlowIn1.BackColorForRSTSignalON = value
            Me.GxFlowOut1.BackColorForRSTSignalON = value
            Me.GxInfoUnmatch1.BackColorForRSTSignalON = value
            Me.GxtR_CV2RST1.BackColorForRSTSignalON = value
            Me.GxTR_RST2CV1.BackColorForRSTSignalON = value
            Me.PortChangeReq1.BackColorForRSTSignalON = value
            Me.PortPause1.BackColorForRSTSignalON = value
            Me.PortResume1.BackColorForRSTSignalON = value
            Me.PortStatus1.BackColorForRSTSignalON = value
            Me.StatusReport1.BackColorForRSTSignalON = value
            Me.TrReset1.BackColorForRSTSignalON = value


            Me.TimeChart_CSTDummyCancel1.BackColorForRSTSignalON = value
            Me.TimeChart_CSTLoadComp1.BackColorForRSTSignalON = value
            Me.TimeChart_CSTLoadreq1.BackColorForRSTSignalON = value
            Me.TimeChart_CSTProcessReq1.BackColorForRSTSignalON = value
            Me.TimeChart_CSTUnloadComp1.BackColorForRSTSignalON = value
            Me.TimeChart_CSTUnloadReqByCV1.BackColorForRSTSignalON = value
            Me.TimeChart_CSTUnloadReqByRST1.BackColorForRSTSignalON = value
            Me.TimeChart_GxSlotUnmatch1.BackColorForRSTSignalON = value
            Me.TimeChart_CVTR1.BackColorForRSTSignalON = value
            Me.TimeChart_GxAbnormal1.BackColorForRSTSignalON = value
            Me.TimeChart_GxDataReq1.BackColorForRSTSignalON = value
            Me.TimeChart_GxFlowIn1.BackColorForRSTSignalON = value
            Me.TimeChart_GxFlowOut1.BackColorForRSTSignalON = value
            Me.TimeChart_Link1.BackColorForRSTSignalON = value
            Me.TimeChart_PortChangeReq1.BackColorForRSTSignalON = value
            Me.TimeChart_RSTTR1.BackColorForRSTSignalON = value
            Me.TimeChart_TRReset1.BackColorForRSTSignalON = value
        End Set
    End Property

    Public WriteOnly Property BackColorForCVSignalON() As System.Drawing.Color
        Set(ByVal value As System.Drawing.Color)
            Me.CvSignal1.BackColorForSignalON = value
            Me.LinkStatus1.BackColorForCVSignalON = value
            Me.AlarmMonitor1.BackColorForSignalON = value
            Me.CstDummyCancel1.BackColorForCVSignalON = value
            Me.CstLoadComplete1.BackColorForCVSignalON = value
            Me.CstLoadReq1.BackColorForCVSignalON = value
            Me.CstPresent1.BackColorForCVSignalON = value
            Me.CstProcessCMD1.BackColorForCVSignalON = value
            Me.CstRemoved1.BackColorForCVSignalON = value
            Me.CstUnloadByCV1.BackColorForCVSignalON = value
            Me.CstUnloadByRST1.BackColorForCVSignalON = value
            Me.CstUnloadComp1.BackColorForCVSignalON = value
            Me.GxAbnormal1.BackColorForCVSignalON = value
            Me.GxDataReq1.BackColorForCVSignalON = value
            Me.GxFlowIn1.BackColorForCVSignalON = value
            Me.GxFlowOut1.BackColorForCVSignalON = value
            Me.GxInfoUnmatch1.BackColorForCVSignalON = value
            Me.GxtR_CV2RST1.BackColorForCVSignalON = value
            Me.GxTR_RST2CV1.BackColorForCVSignalON = value

            Me.PortChangeReq1.BackColorForCVSignalON = value
            Me.PortPause1.BackColorForCVSignalON = value
            Me.PortResume1.BackColorForCVSignalON = value
            Me.PortStatus1.BackColorForCVSignalON = value
            Me.StatusReport1.BackColorForCVSignalON = value
            Me.TrReset1.BackColorForCVSignalON = value

            Me.TimeChart_CSTDummyCancel1.BackColorForCVSignalON = value
            Me.TimeChart_CSTLoadComp1.BackColorForCVSignalON = value
            Me.TimeChart_CSTLoadreq1.BackColorForCVSignalON = value
            Me.TimeChart_CSTProcessReq1.BackColorForCVSignalON = value
            Me.TimeChart_CSTUnloadComp1.BackColorForCVSignalON = value
            Me.TimeChart_CSTUnloadReqByCV1.BackColorForCVSignalON = value
            Me.TimeChart_CSTUnloadReqByRST1.BackColorForCVSignalON = value
            Me.TimeChart_CVTR1.BackColorForCVSignalON = value
            Me.TimeChart_GxAbnormal1.BackColorForCVSignalON = value
            Me.TimeChart_GxDataReq1.BackColorForCVSignalON = value
            Me.TimeChart_GxFlowIn1.BackColorForCVSignalON = value
            Me.TimeChart_GxFlowOut1.BackColorForCVSignalON = value
            Me.TimeChart_Link1.BackColorForCVSignalON = value
            Me.TimeChart_PortChangeReq1.BackColorForCVSignalON = value
            Me.TimeChart_RSTTR1.BackColorForCVSignalON = value
            Me.TimeChart_TRReset1.BackColorForCVSignalON = value
            Me.TimeChart_GxSlotUnmatch1.BackColorForCVSignalON = value
        End Set
    End Property

    Public WriteOnly Property BackColorForSignalOff() As System.Drawing.Color
        Set(ByVal value As System.Drawing.Color)
            Me.CvSignal1.BackColorForSignalOFF = value
            Me.RstSignal1.BackColorForSignalOFF = value
            Me.LinkStatus1.BackColorForSignalOFF = value
            Me.AlarmMonitor1.BackColorForSignalOFF = value
            Me.CstDummyCancel1.BackColorForSignalOFF = value
            Me.CstLoadComplete1.BackColorForSignalOFF = value
            Me.CstLoadReq1.BackColorForSignalOFF = value
            Me.CstPresent1.BackColorForSignalOFF = value
            Me.CstProcessCMD1.BackColorForSignalOFF = value
            Me.CstRemoved1.BackColorForSignalOFF = value
            Me.CstUnloadByCV1.BackColorForSignalOFF = value
            Me.CstUnloadByRST1.BackColorForSignalOFF = value
            Me.CstUnloadComp1.BackColorForSignalOFF = value
            Me.GxAbnormal1.BackColorForSignalOFF = value
            Me.GxDataReq1.BackColorForSignalOFF = value
            Me.GxFlowIn1.BackColorForSignalOFF = value
            Me.GxFlowOut1.BackColorForSignalOFF = value
            Me.GxInfoUnmatch1.BackColorForSignalOFF = value
            Me.GxtR_CV2RST1.BackColorForSignalOFF = value
            Me.GxTR_RST2CV1.BackColorForSignalOFF = value

            Me.PortChangeReq1.BackColorForSignalOFF = value
            Me.PortPause1.BackColorForSignalOFF = value
            Me.PortResume1.BackColorForSignalOFF = value
            Me.PortStatus1.BackColorForSignalOFF = value
            Me.StatusReport1.BackColorForSignalOFF = value
            Me.TrReset1.BackColorForSignalOFF = value


            Me.TimeChart_CSTDummyCancel1.BackColorForSignalOFF = value
            Me.TimeChart_CSTLoadComp1.BackColorForSignalOFF = value
            Me.TimeChart_CSTLoadreq1.BackColorForSignalOFF = value
            Me.TimeChart_CSTProcessReq1.BackColorForSignalOFF = value
            Me.TimeChart_CSTUnloadComp1.BackColorForSignalOFF = value
            Me.TimeChart_CSTUnloadReqByCV1.BackColorForSignalOFF = value
            Me.TimeChart_CSTUnloadReqByRST1.BackColorForSignalOFF = value
            Me.TimeChart_CVTR1.BackColorForSignalOFF = value
            Me.TimeChart_GxAbnormal1.BackColorForSignalOFF = value
            Me.TimeChart_GxDataReq1.BackColorForSignalOFF = value
            Me.TimeChart_GxFlowIn1.BackColorForSignalOFF = value
            Me.TimeChart_GxFlowOut1.BackColorForSignalOFF = value
            Me.TimeChart_Link1.BackColorForSignalOFF = value
            Me.TimeChart_PortChangeReq1.BackColorForSignalOFF = value
            Me.TimeChart_RSTTR1.BackColorForSignalOFF = value
            Me.TimeChart_TRReset1.BackColorForSignalOFF = value
            Me.TimeChart_GxSlotUnmatch1.BackColorForSignalOFF = value
        End Set
    End Property

    Public Sub SimSetAllSignalON()
        test()
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColorForRSTSignalON = Color.Aqua
        BackColorForCVSignalON = Color.Red
        BackColorForSignalOff = Color.White

        IniAddressMapSignalName()
        IniSignalModifyTime()
        IniLinkMapGUI()

        MyCheckTimer.Interval = 200
        MyCheckTimer.Enabled = True

        MyTimer.Interval = 200

        GUISignalCTL()

    End Sub

    Public Property SignalOnOff(ByVal lngAddrKey As Long) As Integer
        Get
            SignalOnOff = mvarCVGUISignalOnOff(lngAddrKey)
        End Get
        Set(ByVal value As Integer)
            mvarCVGUISignalOnOff(lngAddrKey) = value
            'If Me.Visible Then
            '    GUISignalCTL()
            'End If
        End Set
    End Property

    Public Property SignalName(ByVal lngAddrKey As Long) As String
        Get
            SignalName = mvarCVGUISignalName(lngAddrKey)
        End Get
        Set(ByVal value As String)
            mvarCVGUISignalName(lngAddrKey) = value
        End Set
    End Property

    Public Property SignalModifyTime(ByVal lngAddrKey As Long) As String
        Get
            SignalModifyTime = mvarCVGUIModifyTime(lngAddrKey)
        End Get
        Set(ByVal value As String)
            mvarCVGUIModifyTime(lngAddrKey) = value
        End Set
    End Property

    Public Property AlarmOnOff(ByVal nIdx As Integer) As Integer
        Get
            AlarmOnOff = mvarCVGUIAlarmTable(nIdx)
        End Get
        Set(ByVal value As Integer)
            mvarCVGUIAlarmTable(nIdx) = value
        End Set
    End Property


#Region "Private Sub / Function"


    Private Sub IniLinkMapGUI()
        Dim vAcidTable As DataTable = New DataTable("Amino Acid")
        Dim row As DataRow
        Dim nIndex As Integer

        If DGV.DataSource IsNot Nothing Then
            nIndex = DGV.FirstDisplayedScrollingRowIndex
        End If

        'Dim C0 As New DataColumn("Signal Name")
        'Dim C1 As New DataColumn("Address ID", GetType(String))
        'Dim C2 As New DataColumn("ON/OFF", GetType(String))
        'Dim C3 As New DataColumn("SPC", GetType(String))
        'Dim C4 As New DataColumn("Modify Time", GetType(String))

        Dim C0 As New DataColumn("     ")
        Dim C1 As New DataColumn("    ", GetType(String))
        Dim C2 As New DataColumn("   ", GetType(String))
        Dim C3 As New DataColumn("  ", GetType(String))
        Dim C4 As New DataColumn(" ", GetType(String))

        C0.ReadOnly = True

        vAcidTable.Columns.Add(C0)
        vAcidTable.Columns.Add(C1)
        vAcidTable.Columns.Add(C2)
        vAcidTable.Columns.Add(C3)
        vAcidTable.Columns.Add(C4)


        For i As Integer = 1 To UBound(mvarCVGUISignalName)
            If SignalName(i) <> "" Then
                row = vAcidTable.NewRow()
                row(0) = SignalName(i)
                row(1) = "BOx " & ConvertAddrToHex(i)
                row(2) = SignalOnOff(i)
                row(3) = "N/A"
                row(4) = SignalModifyTime(i)

                vAcidTable.Rows.Add(row)
            End If
        Next
        DGV.DataSource = vAcidTable

        If nIndex < 0 Then
        Else
            DGV.FirstDisplayedScrollingRowIndex = nIndex
        End If
    End Sub

    Private Sub IniAddressMapSignalName()
        SignalName(&H180) = "RST Link Request"
        SignalName(&H181) = "RST Link Test Request"
        SignalName(&H183) = "RST Robot 01 Alive"
        SignalName(&H184) = "RST Robot 02 Alive"
        SignalName(&H190) = "RST Port1 Cassette Load Request Ack"
        SignalName(&H191) = "RST Port2 Cassette Load Request Ack"
        SignalName(&H192) = "RST Port3 Cassette Load Request Ack"
        SignalName(&H193) = "RST Port4 Cassette Load Request Ack"
        SignalName(&H194) = "RST Port5 Cassette Load Request Ack"
        SignalName(&H197) = "RST Port1 Cassette Load Complete Ack"
        SignalName(&H198) = "RST Port2 Cassette Load Complete Ack"
        SignalName(&H199) = "RST Port3 Cassette Load Complete Ack"
        SignalName(&H19A) = "RST Port4 Cassette Load Complete Ack"
        SignalName(&H19B) = "RST Port5 Cassette Load Complete Ack"
        SignalName(&H19F) = "RST Cassette Process Request"
        SignalName(&H1A0) = "RST Port1 Cassette Unload Request Ack"
        SignalName(&H1A1) = "RST Port2 Cassette Unload Request Ack"
        SignalName(&H1A2) = "RST Port3 Cassette Unload Request Ack"
        SignalName(&H1A3) = "RST Port4 Cassette Unload Request Ack"
        SignalName(&H1A4) = "RST Port5 Cassette Unload Request Ack"

        SignalName(&H1AB) = "RST Port1 Cassette Unload Priority"
        SignalName(&H1AC) = "RST Port2 Cassette Unload Priority"
        SignalName(&H1AD) = "RST Port3 Cassette Unload Priority"
        SignalName(&H1AE) = "RST Port4 Cassette Unload Priority"
        SignalName(&H1AF) = "RST Port5 Cassette Unload Priority"

        SignalName(&H1B0) = "RST Port1 RST Cassette Unload Request"
        SignalName(&H1B1) = "RST Port2 RST Cassette Unload Request"
        SignalName(&H1B2) = "RST Port3 RST Cassette Unload Request"
        SignalName(&H1B3) = "RST Port4 RST Cassette Unload Request"
        SignalName(&H1B4) = "RST Port5 RST Cassette Unload Request"

        SignalName(&H1B8) = "RST Port1 Cassette Unload Complete Ack"
        SignalName(&H1B9) = "RST Port2 Cassette Unload Complete Ack"
        SignalName(&H1BA) = "RST Port3 Cassette Unload Complete Ack"
        SignalName(&H1BB) = "RST Port4 Cassette Unload Complete Ack"
        SignalName(&H1BC) = "RST Port5 Cassette Unload Complete Ack"

        SignalName(&H1C0) = "RST Port1 Glass Flow Out Ack"
        SignalName(&H1C1) = "RST Port2 Glass Flow Out Ack"
        SignalName(&H1C2) = "RST Port3 Glass Flow Out Ack"
        SignalName(&H1C3) = "RST Port4 Glass Flow Out Ack"
        SignalName(&H1C4) = "RST Port5 Glass Flow Out Ack"

        SignalName(&H1C8) = "RST Port1 Glass Flow In Ack"
        SignalName(&H1C9) = "RST Port2 Glass Flow In Ack"
        SignalName(&H1CA) = "RST Port3 Glass Flow In Ack"
        SignalName(&H1CB) = "RST Port4 Glass Flow In Ack"
        SignalName(&H1CC) = "RST Port5 Glass Flow In Ack"

        SignalName(&H1D0) = "RST Glass Data Request Ack"
        SignalName(&H1D1) = "RST Data Empty Flag"
        SignalName(&H1D3) = "RST Glass Slot Unmatched Ack"
        SignalName(&H1D5) = "RST Transfer Reset Request"
        SignalName(&H1D7) = "RST Glass Abnormal Ack"

        SignalName(&H1DB) = "RST Port1 Port Change Request"
        SignalName(&H1DC) = "RST Port2 Port Change Request"
        SignalName(&H1DD) = "RST Port3 Port Change Request"
        SignalName(&H1DE) = "RST Port4 Port Change Request"
        SignalName(&H1DF) = "RST Port5 Port Change Request"
        SignalName(&H1E0) = "RST Transfer Request {Position 01}[CV->RBT]"
        SignalName(&H1E1) = "RST Robot Busy {Position 01}[CV->RBT]"
        SignalName(&H1E2) = "RST Transfer Complete {Position 01}[CV->RBT]"
        SignalName(&H1E3) = "RST Transfer Request {Position 02}[CV->RBT]"
        SignalName(&H1E4) = "RST Robot Busy {Position 02}[CV->RBT]"
        SignalName(&H1E5) = "RST Transfer Complete {Position 02}[CV->RBT]"
        SignalName(&H1E6) = "RST Transfer Request {Position 03}[CV->RBT]"
        SignalName(&H1E7) = "RST Robot Busy {Position 03}[CV->RBT]"
        SignalName(&H1E8) = "RST Transfer Complete {Position 03}[CV->RBT]"
        SignalName(&H1E9) = "RST Transfer Request {Position 04}[CV->RBT]"
        SignalName(&H1EA) = "RST Robot Busy {Position 04}[CV->RBT]"
        SignalName(&H1EB) = "RST Transfer Complete {Position 04}[CV->RBT]"
        SignalName(&H1EC) = "RST Transfer Request {Position 05}[CV->RBT]"
        SignalName(&H1ED) = "RST Robot Busy {Position 05}[CV->RBT]"
        SignalName(&H1EE) = "RST Transfer Complete {Position 05}[CV->RBT]"
        SignalName(&H1F0) = "RST Transfer Request {Position 01}[RBT->CV]"
        SignalName(&H1F1) = "RST Robot Busy {Position 01}[RBT->CV]"
        SignalName(&H1F2) = "RST Transfer Complete {Position 01}[RBT->CV]"
        SignalName(&H1F3) = "RST Transfer Request {Position 02}[RBT->CV]"
        SignalName(&H1F4) = "RST Robot Busy {Position 02}[RBT->CV]"
        SignalName(&H1F5) = "RST Transfer Complete {Position 02}[RBT->CV]"
        SignalName(&H1F6) = "RST Transfer Request {Position 03}[RBT->CV]"
        SignalName(&H1F7) = "RST Robot Busy {Position 03}[RBT->CV]"
        SignalName(&H1F8) = "RST Transfer Complete {Position 03}[RBT->CV]"
        SignalName(&H1F9) = "RST Transfer Request {Position 04}[RBT->CV]"
        SignalName(&H1FA) = "RST Robot Busy {Position 04}[RBT->CV]"
        SignalName(&H1FB) = "RST Transfer Complete {Position 04}[RBT->CV]"
        SignalName(&H1FC) = "RST Transfer Request {Position 05}[RBT->CV]"
        SignalName(&H1FD) = "RST Robot Busy {Position 05}[RBT->CV]"
        SignalName(&H1FE) = "RST Transfer Complete {Position 05}[RBT->CV]"
        SignalName(&H200) = "RST Port1 Dummy Cancel Request"
        SignalName(&H201) = "RST Port2 Dummy Cancel Request"
        SignalName(&H202) = "RST Port3 Dummy Cancel Request"
        SignalName(&H203) = "RST Port4 Dummy Cancel Request"
        SignalName(&H204) = "RST Port5 Dummy Cancel Request"

        SignalName(&H210) = "RST Port1 CST Present Ack"
        SignalName(&H211) = "RST Port2 CST Present Ack"
        SignalName(&H212) = "RST Port3 CST Present Ack"
        SignalName(&H213) = "RST Port4 CST Present Ack"
        SignalName(&H214) = "RST Port5 CST Present Ack"
        SignalName(&H218) = "RST Port1 CST Removed Ack"
        SignalName(&H219) = "RST Port2 CST Removed Ack"
        SignalName(&H21A) = "RST Port3 CST Removed Ack"
        SignalName(&H21B) = "RST Port4 CST Removed Ack"
        SignalName(&H21C) = "RST Port5 CST Removed Ack"
        SignalName(&H220) = "RST Port1 CST Pause Request"
        SignalName(&H221) = "RST Port2 CST Pause Request"
        SignalName(&H222) = "RST Port3 CST Pause Request"
        SignalName(&H223) = "RST Port4 CST Pause Request"
        SignalName(&H224) = "RST Port5 CST Pause Request"
        SignalName(&H228) = "RST Port1 CST Reuseme Request"
        SignalName(&H229) = "RST Port2 CST Reuseme Request"
        SignalName(&H22A) = "RST Port3 CST Reuseme Request"
        SignalName(&H22B) = "RST Port4 CST Reuseme Request"
        SignalName(&H22C) = "RST Port5 CST Reuseme Request"


        'CV's Signal
        SignalName(&H1300) = "CV Link Request"
        SignalName(&H1301) = "CV Link Test Response"
        SignalName(&H1302) = "CV OK Glass Forbiddance On Port01"
        SignalName(&H1303) = "CV OK Glass Forbiddance On Port02"
        SignalName(&H1304) = "CV OK Glass Forbiddance On Port03"
        SignalName(&H1305) = "CV OK Glass Forbiddance On Port04"
        SignalName(&H1306) = "CV OK Glass Forbiddance On Port05"
        SignalName(&H1307) = "CV NG Glass Forbiddance On Port01"
        SignalName(&H1308) = "CV NG Glass Forbiddance On Port02"
        SignalName(&H1309) = "CV NG Glass Forbiddance On Port03"
        SignalName(&H130A) = "CV NG Glass Forbiddance On Port04"
        SignalName(&H130B) = "CV NG Glass Forbiddance On Port05"
        SignalName(&H130C) = "CV MIX Glass Forbiddance On Port01"
        SignalName(&H130D) = "CV MIX Glass Forbiddance On Port02"
        SignalName(&H130E) = "CV MIX Glass Forbiddance On Port03"
        SignalName(&H130F) = "CV MIX Glass Forbiddance On Port04"
        SignalName(&H1310) = "CV MIX Glass Forbiddance On Port05"
        SignalName(&H1311) = "CV Gray Glass Forbiddance On Port01"
        SignalName(&H1312) = "CV Gray Glass Forbiddance On Port02"
        SignalName(&H1313) = "CV Gray Glass Forbiddance On Port03"
        SignalName(&H1314) = "CV Gray Glass Forbiddance On Port04"
        SignalName(&H1315) = "CV Gray Glass Forbiddance On Port05"
        SignalName(&H1316) = "CV Cassette Exist On Port01"
        SignalName(&H1317) = "CV Cassette Exist On Port02"
        SignalName(&H1318) = "CV Cassette Exist On Port03"
        SignalName(&H1319) = "CV Cassette Exist On Port04"
        SignalName(&H131A) = "CV Cassette Exist On Port05"
        SignalName(&H131B) = "CV Port01 Disable"
        SignalName(&H131C) = "CV Port02 Disable"
        SignalName(&H131D) = "CV Port03 Disable"
        SignalName(&H131E) = "CV Port04 Disable"
        SignalName(&H131F) = "CV Port05 Disable"
        SignalName(&H1320) = "CV VCR Enable Flag 01"
        SignalName(&H1321) = "CV VCR Enable Flag 02"
        SignalName(&H1322) = "CV VCR Enable Flag 03"
        SignalName(&H1323) = "CV VCR Enable Flag 04"
        SignalName(&H1324) = "CV VCR Enable Flag 05"
        SignalName(&H1325) = "CV Alarm Occurred"
        SignalName(&H1326) = "CV HandOff Available Position 01"
        SignalName(&H1327) = "CV HandOff Available Position 02"
        SignalName(&H1328) = "CV HandOff Available Position 03"
        SignalName(&H1329) = "CV HandOff Available Position 04"
        SignalName(&H132A) = "CV HandOff Available Position 05"
        SignalName(&H132B) = "CV Port01 Sub Status"
        SignalName(&H132C) = "CV Port02 Sub Status"
        SignalName(&H132D) = "CV Port03 Sub Status"
        SignalName(&H132E) = "CV Port04 Sub Status"
        SignalName(&H132F) = "CV Port05 Sub Status"
        SignalName(&H1330) = "CV Port01 Dummy Cancel Ack"
        SignalName(&H1331) = "CV Port02 Dummy Cancel Ack"
        SignalName(&H1332) = "CV Port03 Dummy Cancel Ack"
        SignalName(&H1333) = "CV Port04 Dummy Cancel Ack"
        SignalName(&H1334) = "CV Port05 Dummy Cancel Ack"
        SignalName(&H1338) = "CV Port1 CST Pause Ack"
        SignalName(&H1339) = "CV Port2 CST Pause Ack"
        SignalName(&H133A) = "CV Port3 CST Pause Ack"
        SignalName(&H133B) = "CV Port4 CST Pause Ack"
        SignalName(&H133C) = "CV Port5 CST Pause Ack"
        SignalName(&H1340) = "CV Port01 Cassette Load Request"
        SignalName(&H1341) = "CV Port02 Cassette Load Request"
        SignalName(&H1342) = "CV Port03 Cassette Load Request"
        SignalName(&H1343) = "CV Port04 Cassette Load Request"
        SignalName(&H1344) = "CV Port05 Cassette Load Request"
        SignalName(&H1348) = "CV Port1 CST Present Report"
        SignalName(&H1349) = "CV Port2 CST Present Report"
        SignalName(&H134A) = "CV Port3 CST Present Report"
        SignalName(&H134B) = "CV Port4 CST Present Report"
        SignalName(&H134C) = "CV Port5 CST Present Report"
        SignalName(&H1350) = "CV Port01 Cassette Load Complete"
        SignalName(&H1351) = "CV Port02 Cassette Load Complete"
        SignalName(&H1352) = "CV Port03 Cassette Load Complete"
        SignalName(&H1353) = "CV Port04 Cassette Load Complete"
        SignalName(&H1354) = "CV Port05 Cassette Load Complete"
        SignalName(&H1358) = "CV Port1 CST Removed Report"
        SignalName(&H1359) = "CV Port2 CST Removed Report"
        SignalName(&H135A) = "CV Port3 CST Removed Report"
        SignalName(&H135B) = "CV Port4 CST Removed Report"
        SignalName(&H135C) = "CV Port5 CST Removed Report"
        SignalName(&H1360) = "CV Cassette Process Request Ack"
        SignalName(&H1368) = "CV Port1 CST Reuseme Ack"
        SignalName(&H1369) = "CV Port2 CST Reuseme Ack"
        SignalName(&H136A) = "CV Port3 CST Reuseme Ack"
        SignalName(&H136B) = "CV Port4 CST Reuseme Ack"
        SignalName(&H136C) = "CV Port5 CST Reuseme Ack"

        SignalName(&H1370) = "CV Port01 Cassette Unload Request"
        SignalName(&H1371) = "CV Port02 Cassette Unload Request"
        SignalName(&H1372) = "CV Port03 Cassette Unload Request"
        SignalName(&H1373) = "CV Port04 Cassette Unload Request"
        SignalName(&H1374) = "CV Port05 Cassette Unload Request"
        SignalName(&H1378) = "CV Port01 Cassette Unload Complete"
        SignalName(&H1379) = "CV Port02 Cassette Unload Complete"
        SignalName(&H137A) = "CV Port03 Cassette Unload Complete"
        SignalName(&H137B) = "CV Port04 Cassette Unload Complete"
        SignalName(&H137C) = "CV Port05 Cassette Unload Complete"
        SignalName(&H1380) = "CV Port01 Glass Flow Out"
        SignalName(&H1381) = "CV Port02 Glass Flow Out"
        SignalName(&H1382) = "CV Port03 Glass Flow Out"
        SignalName(&H1383) = "CV Port04 Glass Flow Out"
        SignalName(&H1384) = "CV Port05 Glass Flow Out"
        SignalName(&H1390) = "CV Port01 Glass Flow In"
        SignalName(&H1391) = "CV Port02 Glass Flow In"
        SignalName(&H1392) = "CV Port03 Glass Flow In"
        SignalName(&H1393) = "CV Port04 Glass Flow In"
        SignalName(&H1394) = "CV Port05 Glass Flow In"
        SignalName(&H13A0) = "CV Port01 Change Request Ack"
        SignalName(&H13A1) = "CV Port02 Change Request Ack"
        SignalName(&H13A2) = "CV Port03 Change Request Ack"
        SignalName(&H13A3) = "CV Port04 Change Request Ack"
        SignalName(&H13A4) = "CV Port05 Change Request Ack"
        SignalName(&H13B0) = "CV Glass Data Request"
        SignalName(&H13B6) = "CV Glass Abnormal Report"
        SignalName(&H13BB) = "CV Glass Info. Unmatched Report"
        SignalName(&H13C0) = "CV Transfer Reset Ack"
        SignalName(&H13D0) = "CV Transfer Ready {Position 01}[CV->RBT]"
        SignalName(&H13D1) = "CV Transfer CV Ready {Position 01}[CV->RBT]"
        SignalName(&H13D2) = "CV Transfer Ready {Position 02}[CV->RBT]"
        SignalName(&H13D3) = "CV Transfer CV Ready {Position 02}[CV->RBT]"
        SignalName(&H13D4) = "CV Transfer Ready {Position 03}[CV->RBT]"
        SignalName(&H13D5) = "CV Transfer CV Ready {Position 03}[CV->RBT]"
        SignalName(&H13D6) = "CV Transfer Ready {Position 04}[CV->RBT]"
        SignalName(&H13D7) = "CV Transfer CV Ready {Position 04}[CV->RBT]"
        SignalName(&H13D8) = "CV Transfer Ready {Position 05}[CV->RBT]"
        SignalName(&H13D9) = "CV Transfer CV Ready {Position 05}[CV->RBT]"
        SignalName(&H13E0) = "CV Transfer CV Ready {Position 01}[RBT->CV]"
        SignalName(&H13E1) = "CV Transfer CV Ready {Position 02}[RBT->CV]"
        SignalName(&H13E2) = "CV Transfer CV Ready {Position 03}[RBT->CV]"
        SignalName(&H13E3) = "CV Transfer CV Ready {Position 04}[RBT->CV]"
        SignalName(&H13E4) = "CV Transfer CV Ready {Position 05}[RBT->CV]"
        'SignalName(&H13E0) = "CV Transfer CV Unload Request {Position 01}[RBT->CV]"
        'SignalName(&H13E1) = "CV Transfer CV Ready {Position 01}[RBT->CV]"
        'SignalName(&H13E2) = "CV Transfer CV Unload Request {Position 02}[RBT->CV]"
        'SignalName(&H13E3) = "CV Transfer CV Ready {Position 02}[RBT->CV]"
        'SignalName(&H13E4) = "CV Transfer CV Unload Request {Position 03}[RBT->CV]"
        'SignalName(&H13E5) = "CV Transfer CV Ready {Position 03}[RBT->CV]"
        'SignalName(&H13E6) = "CV Transfer CV Unload Request {Position 04}[RBT->CV]"
        'SignalName(&H13E7) = "CV Transfer CV Ready {Position 04}[RBT->CV]"

        SignalName(&H13F0) = "CV Glass Abnormal Report Ack"
    End Sub

    Private Sub IniSignalModifyTime()
        SignalModifyTime(&H180) = Now
        SignalModifyTime(&H181) = Now
        SignalModifyTime(&H183) = Now
        SignalModifyTime(&H184) = Now
        SignalModifyTime(&H190) = Now
        SignalModifyTime(&H191) = Now
        SignalModifyTime(&H192) = Now
        SignalModifyTime(&H193) = Now
        SignalModifyTime(&H194) = Now
        SignalModifyTime(&H197) = Now
        SignalModifyTime(&H198) = Now
        SignalModifyTime(&H199) = Now
        SignalModifyTime(&H19A) = Now
        SignalModifyTime(&H19B) = Now
        SignalModifyTime(&H19F) = Now
        SignalModifyTime(&H1A0) = Now
        SignalModifyTime(&H1A1) = Now
        SignalModifyTime(&H1A2) = Now
        SignalModifyTime(&H1A3) = Now
        SignalModifyTime(&H1A4) = Now

        SignalModifyTime(&H1AB) = Now
        SignalModifyTime(&H1AC) = Now
        SignalModifyTime(&H1AD) = Now
        SignalModifyTime(&H1AE) = Now
        SignalModifyTime(&H1AF) = Now

        SignalModifyTime(&H1B0) = Now
        SignalModifyTime(&H1B1) = Now
        SignalModifyTime(&H1B2) = Now
        SignalModifyTime(&H1B3) = Now
        SignalModifyTime(&H1B4) = Now

        SignalModifyTime(&H1B8) = Now
        SignalModifyTime(&H1B9) = Now
        SignalModifyTime(&H1BA) = Now
        SignalModifyTime(&H1BB) = Now
        SignalModifyTime(&H1BC) = Now

        SignalModifyTime(&H1C0) = Now
        SignalModifyTime(&H1C1) = Now
        SignalModifyTime(&H1C2) = Now
        SignalModifyTime(&H1C3) = Now
        SignalModifyTime(&H1C4) = Now

        SignalModifyTime(&H1C8) = Now
        SignalModifyTime(&H1C9) = Now
        SignalModifyTime(&H1CA) = Now
        SignalModifyTime(&H1CB) = Now
        SignalModifyTime(&H1CC) = Now

        SignalModifyTime(&H1D0) = Now
        SignalModifyTime(&H1D1) = Now
        SignalModifyTime(&H1D3) = Now
        SignalModifyTime(&H1D5) = Now
        SignalModifyTime(&H1D7) = Now

        SignalModifyTime(&H1DB) = Now
        SignalModifyTime(&H1DC) = Now
        SignalModifyTime(&H1DD) = Now
        SignalModifyTime(&H1DE) = Now
        SignalModifyTime(&H1DF) = Now
        SignalModifyTime(&H1E0) = Now
        SignalModifyTime(&H1E1) = Now
        SignalModifyTime(&H1E2) = Now
        SignalModifyTime(&H1E3) = Now
        SignalModifyTime(&H1E4) = Now
        SignalModifyTime(&H1E5) = Now
        SignalModifyTime(&H1E6) = Now
        SignalModifyTime(&H1E7) = Now
        SignalModifyTime(&H1E8) = Now
        SignalModifyTime(&H1E9) = Now
        SignalModifyTime(&H1EA) = Now
        SignalModifyTime(&H1EB) = Now
        SignalModifyTime(&H1EC) = Now
        SignalModifyTime(&H1ED) = Now
        SignalModifyTime(&H1EE) = Now
        SignalModifyTime(&H1F0) = Now
        SignalModifyTime(&H1F1) = Now
        SignalModifyTime(&H1F2) = Now
        SignalModifyTime(&H1F3) = Now
        SignalModifyTime(&H1F4) = Now
        SignalModifyTime(&H1F5) = Now
        SignalModifyTime(&H1F6) = Now
        SignalModifyTime(&H1F7) = Now
        SignalModifyTime(&H1F8) = Now
        SignalModifyTime(&H1F9) = Now
        SignalModifyTime(&H1FA) = Now
        SignalModifyTime(&H1FB) = Now
        SignalModifyTime(&H1FC) = Now
        SignalModifyTime(&H1FD) = Now
        SignalModifyTime(&H1FE) = Now
        SignalModifyTime(&H200) = Now
        SignalModifyTime(&H201) = Now
        SignalModifyTime(&H202) = Now
        SignalModifyTime(&H203) = Now
        SignalModifyTime(&H204) = Now

        SignalModifyTime(&H210) = Now
        SignalModifyTime(&H211) = Now
        SignalModifyTime(&H212) = Now
        SignalModifyTime(&H213) = Now
        SignalModifyTime(&H214) = Now
        SignalModifyTime(&H218) = Now
        SignalModifyTime(&H219) = Now
        SignalModifyTime(&H21A) = Now
        SignalModifyTime(&H21B) = Now
        SignalModifyTime(&H21C) = Now
        SignalModifyTime(&H220) = Now
        SignalModifyTime(&H221) = Now
        SignalModifyTime(&H222) = Now
        SignalModifyTime(&H223) = Now
        SignalModifyTime(&H224) = Now
        SignalModifyTime(&H228) = Now
        SignalModifyTime(&H229) = Now
        SignalModifyTime(&H22A) = Now
        SignalModifyTime(&H22B) = Now
        SignalModifyTime(&H22C) = Now


        'CV's Signal
        SignalModifyTime(&H1300) = Now
        SignalModifyTime(&H1301) = Now
        SignalModifyTime(&H1302) = Now
        SignalModifyTime(&H1303) = Now
        SignalModifyTime(&H1304) = Now
        SignalModifyTime(&H1305) = Now
        SignalModifyTime(&H1306) = Now
        SignalModifyTime(&H1307) = Now
        SignalModifyTime(&H1308) = Now
        SignalModifyTime(&H1309) = Now
        SignalModifyTime(&H130A) = Now
        SignalModifyTime(&H130B) = Now
        SignalModifyTime(&H130C) = Now
        SignalModifyTime(&H130D) = Now
        SignalModifyTime(&H130E) = Now
        SignalModifyTime(&H130F) = Now
        SignalModifyTime(&H1310) = Now
        SignalModifyTime(&H1311) = Now
        SignalModifyTime(&H1312) = Now
        SignalModifyTime(&H1313) = Now
        SignalModifyTime(&H1314) = Now
        SignalModifyTime(&H1315) = Now
        SignalModifyTime(&H1316) = Now
        SignalModifyTime(&H1317) = Now
        SignalModifyTime(&H1318) = Now
        SignalModifyTime(&H1319) = Now
        SignalModifyTime(&H131A) = Now
        SignalModifyTime(&H131B) = Now
        SignalModifyTime(&H131C) = Now
        SignalModifyTime(&H131D) = Now
        SignalModifyTime(&H131E) = Now
        SignalModifyTime(&H131F) = Now
        SignalModifyTime(&H1320) = Now
        SignalModifyTime(&H1321) = Now
        SignalModifyTime(&H1322) = Now
        SignalModifyTime(&H1323) = Now
        SignalModifyTime(&H1324) = Now
        SignalModifyTime(&H1325) = Now
        SignalModifyTime(&H1326) = Now
        SignalModifyTime(&H1327) = Now
        SignalModifyTime(&H1328) = Now
        SignalModifyTime(&H1329) = Now
        SignalModifyTime(&H132A) = Now
        SignalModifyTime(&H132B) = Now
        SignalModifyTime(&H132C) = Now
        SignalModifyTime(&H132D) = Now
        SignalModifyTime(&H132E) = Now
        SignalModifyTime(&H132F) = Now
        SignalModifyTime(&H1330) = Now
        SignalModifyTime(&H1331) = Now
        SignalModifyTime(&H1333) = Now
        SignalModifyTime(&H1334) = Now
        SignalModifyTime(&H1335) = Now
        SignalModifyTime(&H1338) = Now
        SignalModifyTime(&H1339) = Now
        SignalModifyTime(&H133A) = Now
        SignalModifyTime(&H133B) = Now
        SignalModifyTime(&H133C) = Now
        SignalModifyTime(&H1340) = Now
        SignalModifyTime(&H1341) = Now
        SignalModifyTime(&H1342) = Now
        SignalModifyTime(&H1343) = Now
        SignalModifyTime(&H1344) = Now
        SignalModifyTime(&H1348) = Now
        SignalModifyTime(&H1349) = Now
        SignalModifyTime(&H134A) = Now
        SignalModifyTime(&H134B) = Now
        SignalModifyTime(&H134C) = Now
        SignalModifyTime(&H1350) = Now
        SignalModifyTime(&H1351) = Now
        SignalModifyTime(&H1352) = Now
        SignalModifyTime(&H1353) = Now
        SignalModifyTime(&H1354) = Now
        SignalModifyTime(&H1358) = Now
        SignalModifyTime(&H1359) = Now
        SignalModifyTime(&H135A) = Now
        SignalModifyTime(&H135B) = Now
        SignalModifyTime(&H135C) = Now
        SignalModifyTime(&H1360) = Now
        SignalModifyTime(&H1368) = Now
        SignalModifyTime(&H1369) = Now
        SignalModifyTime(&H136A) = Now
        SignalModifyTime(&H136B) = Now
        SignalModifyTime(&H136C) = Now

        SignalModifyTime(&H1370) = Now
        SignalModifyTime(&H1371) = Now
        SignalModifyTime(&H1372) = Now
        SignalModifyTime(&H1373) = Now
        SignalModifyTime(&H1374) = Now
        SignalModifyTime(&H1378) = Now
        SignalModifyTime(&H1379) = Now
        SignalModifyTime(&H137A) = Now
        SignalModifyTime(&H137B) = Now
        SignalModifyTime(&H137C) = Now
        SignalModifyTime(&H1380) = Now
        SignalModifyTime(&H1381) = Now
        SignalModifyTime(&H1382) = Now
        SignalModifyTime(&H1383) = Now
        SignalModifyTime(&H1384) = Now
        SignalModifyTime(&H1390) = Now
        SignalModifyTime(&H1391) = Now
        SignalModifyTime(&H1392) = Now
        SignalModifyTime(&H1393) = Now
        SignalModifyTime(&H1394) = Now
        SignalModifyTime(&H13A0) = Now
        SignalModifyTime(&H13A1) = Now
        SignalModifyTime(&H13A2) = Now
        SignalModifyTime(&H13A3) = Now
        SignalModifyTime(&H13A4) = Now
        SignalModifyTime(&H13B0) = Now
        SignalModifyTime(&H13B6) = Now
        SignalModifyTime(&H13BB) = Now
        SignalModifyTime(&H13C0) = Now
        SignalModifyTime(&H13D0) = Now
        SignalModifyTime(&H13D1) = Now
        SignalModifyTime(&H13D2) = Now
        SignalModifyTime(&H13D3) = Now
        SignalModifyTime(&H13D4) = Now
        SignalModifyTime(&H13D5) = Now
        SignalModifyTime(&H13D6) = Now
        SignalModifyTime(&H13D7) = Now
        SignalModifyTime(&H13D8) = Now
        SignalModifyTime(&H13D9) = Now
        SignalModifyTime(&H13E0) = Now
        SignalModifyTime(&H13E1) = Now
        SignalModifyTime(&H13E2) = Now
        SignalModifyTime(&H13E3) = Now
        SignalModifyTime(&H13E4) = Now
        SignalModifyTime(&H13F0) = Now
    End Sub

    Private Function ConvertAddrToHex(ByVal lngKeyIndex As Long) As String

        If mvarCVGUISignalName(lngKeyIndex) <> "" Then
            ConvertAddrToHex = Hex(lngKeyIndex)
        Else
            ConvertAddrToHex = ""
        End If

    End Function

    Private ReadOnly Property CurrentGUI() As eCVGUIIndex
        Get
            CurrentGUI = mvarCurrentGUIIdx
        End Get
    End Property

    'Main General/Conveyor/Timechart
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then 'General
            GeneralGUI(TabControl2.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 1 Then 'Conveyor
            ConveyorGUI(TabControl3.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 2 Then 'TimeChart
            TimeChtGUI(TabControl6.SelectedIndex)
        End If
    End Sub

    'Init
    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabIndexChanged
        mvarCurrentGUIIdx = eCVGUIIndex.IDX_1ST_SIGNAL
        GUISignalCTL()
    End Sub

    'General All Signal/ PLC MAP
    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        GeneralGUI(TabControl2.SelectedIndex)
    End Sub

    'Conveyor
    Private Sub TabControl3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl3.SelectedIndexChanged
        ConveyorGUI(TabControl3.SelectedIndex)
    End Sub

    'Timecht
    Private Sub TabControl6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl6.SelectedIndexChanged
        TimeChtGUI(TabControl6.SelectedIndex)
    End Sub

    Private Sub GeneralGUI(ByVal nSelected As Integer)
        If nSelected = 0 Then
            mvarCurrentGUIIdx = eCVGUIIndex.IDX_1ST_SIGNAL
        Else
            mvarCurrentGUIIdx = eCVGUIIndex.IDX_1ST_MAP
        End If
        GUISignalCTL()
    End Sub

    Private Sub ConveyorGUI(ByVal nSelected As Integer)
        Select Case nSelected
            Case 0
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_11LINK
            Case 1
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_12STATUS_MAIN
            Case 2
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_13STATUS_PORT
            Case 3
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_14CST_PROCESS_CMD
            Case 4
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_15GX_DATA_REQ
            Case 5
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_16TR_RESET
            Case 6
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_17GX_ABNORMAL
            Case 7
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_18GX_INFO_UNMATCH
            Case 8
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_19CST_LOAD_REQ
            Case 9
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_21CST_LOAD_COMP
            Case 10
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_22GX_FLOW_OUT
            Case 11
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_23GX_FLOW_IN
            Case 12
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_24CST_UNLOAD_BY_CV
            Case 13
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_25CST_UNLOAD_BY_RST
            Case 14
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_26CST_UNLOAD_COMP
            Case 15
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_27CST_DUMMY_CANCEL
            Case 16
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_28PORT_CHANGE_REQ
            Case 17
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_29GXTR_BYCV
            Case 18
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_31GXTR_BYRST
            Case 19
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_32ALARM
            Case 20
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_33CST_PRESENT
            Case 21
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_34CST_REMOVED
            Case 22
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_35PORT_PAUSE
            Case 23
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_2ND_36PORT_RESUME
        End Select
        GUISignalCTL()
    End Sub

    Private Sub TimeChtGUI(ByVal nSelected As Integer)
        Select Case nSelected
            Case 0
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_11LINK
            Case 1
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_12CST_PROCESS_CMD
            Case 2
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_13GX_DATA_REQ
            Case 3
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_14TR_RESET
            Case 4
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_15GX_ABNORMAL
            Case 5
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_16GX_INFO_UNMATCH
            Case 6
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_17CST_LOAD_REQ
            Case 7
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_18CST_LOAD_COMP
            Case 8
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_19GX_FLOW_OUT
            Case 9
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_21GX_FLOW_IN
            Case 10
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_22CST_UNLOAD_BY_CV
            Case 11
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_23CST_UNLOAD_BY_RST
            Case 12
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_24CST_UNLOAD_COMP
            Case 13
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_25DUMMY_CANCEL
            Case 14
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_26PORT_CHANGE
            Case 15
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_27CVTR
            Case 16
                mvarCurrentGUIIdx = eCVGUIIndex.IDX_3ND_28RSTTR
        End Select
        GUISignalCTL()
    End Sub

    Private Sub GUISignalCTL()
        Dim nFor As Integer

        Select Case mvarCurrentGUIIdx
            Case eCVGUIIndex.IDX_1ST_SIGNAL
                For nFor = &H180 To &H22F
                    If mvarCVGUISignalName(nFor) <> "" Then
                        Me.RstSignal1.SetSignalOnOff("0" & CStr(Hex(nFor)), SignalOnOff(nFor))
                    End If
                Next

                For nFor = &H1300 To &H13FF
                    If mvarCVGUISignalName(nFor) <> "" Then
                        Me.CvSignal1.SetSignalOnOff(CStr(Hex(nFor)), SignalOnOff(nFor))
                    End If
                Next
                '========================================================================================================
            Case eCVGUIIndex.IDX_1ST_MAP
                IniLinkMapGUI()
            Case eCVGUIIndex.IDX_2ND_11LINK

                Me.LinkStatus1.SetSignalOnOff("0180", SignalOnOff(&H180))
                Me.LinkStatus1.SetSignalOnOff("0181", SignalOnOff(&H181))
                Me.LinkStatus1.SetSignalOnOff("1300", SignalOnOff(&H1300))
                Me.LinkStatus1.SetSignalOnOff("1301", SignalOnOff(&H1301))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_12STATUS_MAIN
                Me.StatusReport1.SetSignalOnOff("0183", SignalOnOff(&H183))
                Me.StatusReport1.SetSignalOnOff("0184", SignalOnOff(&H184))
                Me.StatusReport1.SetSignalOnOff("1325", SignalOnOff(&H1325))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_13STATUS_PORT

                TabConvert("1302", Me.PortStatus1.TabIdx)
                Me.PortStatus1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1307", Me.PortStatus1.TabIdx)
                Me.PortStatus1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("130C", Me.PortStatus1.TabIdx)
                Me.PortStatus1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1311", Me.PortStatus1.TabIdx)
                Me.PortStatus1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1316", Me.PortStatus1.TabIdx)
                Me.PortStatus1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("131B", Me.PortStatus1.TabIdx)
                Me.PortStatus1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1320", Me.PortStatus1.TabIdx)
                Me.PortStatus1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_14CST_PROCESS_CMD
                Me.CstProcessCMD1.SetSignalOnOff("019F", SignalOnOff(&H19F))
                Me.CstProcessCMD1.SetSignalOnOff("1360", SignalOnOff(&H1360))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_15GX_DATA_REQ
                Me.GxDataReq1.SetSignalOnOff("01D0", SignalOnOff(&H1D0))
                Me.GxDataReq1.SetSignalOnOff("01D1", SignalOnOff(&H1D1))
                Me.GxDataReq1.SetSignalOnOff("13B0", SignalOnOff(&H13B0))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_16TR_RESET
                Me.TrReset1.SetSignalOnOff("01D5", SignalOnOff(&H1D5))
                Me.TrReset1.SetSignalOnOff("13C0", SignalOnOff(&H13C0))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_17GX_ABNORMAL
                Me.GxAbnormal1.SetSignalOnOff("01D7", SignalOnOff(&H1D7))
                Me.GxAbnormal1.SetSignalOnOff("13B6", SignalOnOff(&H13B6))
                Me.GxAbnormal1.SetSignalOnOff("13F0", SignalOnOff(&H13F0))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_18GX_INFO_UNMATCH
                Me.GxInfoUnmatch1.SetSignalOnOff("01D3", SignalOnOff(&H1D3))
                Me.GxInfoUnmatch1.SetSignalOnOff("13BB", SignalOnOff(&H13BB))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_19CST_LOAD_REQ
                TabConvert("0190", Me.CstLoadReq1.TabIdx)
                Me.CstLoadReq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1340", Me.CstLoadReq1.TabIdx)
                Me.CstLoadReq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_21CST_LOAD_COMP
                TabConvert("0197", Me.CstLoadComplete1.TabIdx)
                Me.CstLoadComplete1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1350", Me.CstLoadComplete1.TabIdx)
                Me.CstLoadComplete1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_22GX_FLOW_OUT
                TabConvert("01C0", Me.GxFlowOut1.TabIdx)
                Me.GxFlowOut1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1380", Me.GxFlowOut1.TabIdx)
                Me.GxFlowOut1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_23GX_FLOW_IN
                TabConvert("01C8", Me.GxFlowIn1.TabIdx)
                Me.GxFlowIn1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1390", Me.GxFlowIn1.TabIdx)
                Me.GxFlowIn1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_24CST_UNLOAD_BY_CV
                TabConvert("01A0", Me.CstUnloadByCV1.TabIdx)
                Me.CstUnloadByCV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01AB", Me.CstUnloadByCV1.TabIdx)
                Me.CstUnloadByCV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1370", Me.CstUnloadByCV1.TabIdx)
                Me.CstUnloadByCV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_25CST_UNLOAD_BY_RST
                TabConvert("01A0", Me.CstUnloadByRST1.TabIdx)
                Me.CstUnloadByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01AB", Me.CstUnloadByRST1.TabIdx)
                Me.CstUnloadByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01B0", Me.CstUnloadByRST1.TabIdx)
                Me.CstUnloadByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1370", Me.CstUnloadByRST1.TabIdx)
                Me.CstUnloadByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_26CST_UNLOAD_COMP
                TabConvert("01B8", Me.CstUnloadComp1.TabIdx)
                Me.CstUnloadComp1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1378", Me.CstUnloadComp1.TabIdx)
                Me.CstUnloadComp1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_27CST_DUMMY_CANCEL
                TabConvert("0200", Me.CstDummyCancel1.TabIdx)
                Me.CstDummyCancel1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1330", Me.CstDummyCancel1.TabIdx)
                Me.CstDummyCancel1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_28PORT_CHANGE_REQ
                TabConvert("01DB", Me.PortChangeReq1.TabIdx)
                Me.PortChangeReq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("13A0", Me.PortChangeReq1.TabIdx)
                Me.PortChangeReq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_29GXTR_BYCV
                TabConvert("1326", GxtR_CV2RST1.TabIdx)
                Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("13C0", 0)
                Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01D5", 0)
                Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                If Me.GxtR_CV2RST1.TabIdx = 0 Then
                    TabConvert("01E0", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E1", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E2", 0)

                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D0", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D1", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                ElseIf Me.GxtR_CV2RST1.TabIdx = 1 Then
                    TabConvert("01E3", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E4", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E5", 0)

                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D2", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D3", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.GxtR_CV2RST1.TabIdx = 2 Then
                    TabConvert("01E6", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E7", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E8", 0)

                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D4", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D5", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.GxtR_CV2RST1.TabIdx = 3 Then
                    TabConvert("01E9", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01EA", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01EB", 0)

                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D6", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D7", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.GxtR_CV2RST1.TabIdx = 4 Then
                    TabConvert("01EC", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01ED", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01EE", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13D8", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D9", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                End If
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_31GXTR_BYRST
                TabConvert("1326", GxTR_RST2CV1.TabIdx)
                Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("13C0", 0)
                Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01D5", 0)
                Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                If Me.GxTR_RST2CV1.TabIdx = 0 Then
                    TabConvert("01F0", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F1", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F2", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E0", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E1", 0)
                    'Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                ElseIf Me.GxTR_RST2CV1.TabIdx = 1 Then
                    TabConvert("01F3", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F4", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F5", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E1", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E3", 0)
                    'Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.GxTR_RST2CV1.TabIdx = 2 Then
                    TabConvert("01F6", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F7", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F8", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E2", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E5", 0)
                    'Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.GxTR_RST2CV1.TabIdx = 3 Then
                    TabConvert("01F9", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FA", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FB", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E3", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E7", 0)
                    'Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.GxTR_RST2CV1.TabIdx = 4 Then
                    TabConvert("01FC", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FD", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FE", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E4", 0)
                    Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E9", 0)
                    'Me.GxTR_RST2CV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                End If
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_32ALARM
                For nFor = 1 To 512
                    AlarmMonitor1.SetSignalOnOff(nFor, Me.AlarmOnOff(nFor))
                Next
                AlarmMonitor1.ShowAlarm()
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_33CST_PRESENT
                TabConvert("0210", Me.CstPresent1.TabIdx)
                Me.CstPresent1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1348", Me.CstPresent1.TabIdx)
                Me.CstPresent1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_34CST_REMOVED
                TabConvert("0218", Me.CstRemoved1.TabIdx)
                Me.CstRemoved1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1358", Me.CstRemoved1.TabIdx)
                Me.CstRemoved1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_35PORT_PAUSE
                TabConvert("0220", Me.PortPause1.TabIdx)
                Me.PortPause1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1338", Me.PortPause1.TabIdx)
                Me.PortPause1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_2ND_36PORT_RESUME
                TabConvert("0228", Me.PortResume1.TabIdx)
                Me.PortResume1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1368", Me.PortResume1.TabIdx)
                Me.PortResume1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================



            Case eCVGUIIndex.IDX_3ND_11LINK
                Me.TimeChart_Link1.SetSignalOnOff("0180", SignalOnOff(&H180))
                Me.TimeChart_Link1.SetSignalOnOff("0181", SignalOnOff(&H181))
                Me.TimeChart_Link1.SetSignalOnOff("1300", SignalOnOff(&H1300))
                Me.TimeChart_Link1.SetSignalOnOff("1301", SignalOnOff(&H1301))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_12CST_PROCESS_CMD
                Me.TimeChart_CSTProcessReq1.SetSignalOnOff("019F", SignalOnOff(&H19F))
                Me.TimeChart_CSTProcessReq1.SetSignalOnOff("1360", SignalOnOff(&H1360))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_13GX_DATA_REQ
                Me.TimeChart_GxDataReq1.SetSignalOnOff("01D0", SignalOnOff(&H1D0))
                Me.TimeChart_GxDataReq1.SetSignalOnOff("01D1", SignalOnOff(&H1D1))
                Me.TimeChart_GxDataReq1.SetSignalOnOff("13B0", SignalOnOff(&H13B0))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_14TR_RESET
                Me.TimeChart_TRReset1.SetSignalOnOff("01D5", SignalOnOff(&H1D5))
                Me.TimeChart_TRReset1.SetSignalOnOff("13C0", SignalOnOff(&H13C0))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_15GX_ABNORMAL
                Me.TimeChart_GxAbnormal1.SetSignalOnOff("01D7", SignalOnOff(&H1D7))
                Me.TimeChart_GxAbnormal1.SetSignalOnOff("13B6", SignalOnOff(&H13B6))
                Me.TimeChart_GxAbnormal1.SetSignalOnOff("13F0", SignalOnOff(&H13F0))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_16GX_INFO_UNMATCH
                Me.TimeChart_GxSlotUnmatch1.SetSignalOnOff("01D3", SignalOnOff(&H1D3))
                Me.TimeChart_GxSlotUnmatch1.SetSignalOnOff("13BB", SignalOnOff(&H13BB))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_17CST_LOAD_REQ
                TabConvert("0190", Me.TimeChart_CSTLoadreq1.TabIdx)
                Me.TimeChart_CSTLoadreq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1340", Me.TimeChart_CSTLoadreq1.TabIdx)
                Me.TimeChart_CSTLoadreq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================            
            Case eCVGUIIndex.IDX_3ND_18CST_LOAD_COMP
                TabConvert("0197", Me.TimeChart_CSTLoadComp1.TabIdx)
                Me.TimeChart_CSTLoadComp1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1350", Me.TimeChart_CSTLoadComp1.TabIdx)
                Me.TimeChart_CSTLoadComp1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_19GX_FLOW_OUT
                TabConvert("01C0", Me.TimeChart_GxFlowOut1.TabIdx)
                Me.TimeChart_GxFlowOut1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1380", Me.TimeChart_GxFlowOut1.TabIdx)
                Me.TimeChart_GxFlowOut1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_21GX_FLOW_IN
                TabConvert("01C8", Me.TimeChart_GxFlowIn1.TabIdx)
                Me.TimeChart_GxFlowIn1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1390", Me.TimeChart_GxFlowIn1.TabIdx)
                Me.TimeChart_GxFlowIn1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_22CST_UNLOAD_BY_CV
                TabConvert("01A0", Me.TimeChart_CSTUnloadReqByCV1.TabIdx)
                Me.TimeChart_CSTUnloadReqByCV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01AB", Me.TimeChart_CSTUnloadReqByCV1.TabIdx)
                Me.TimeChart_CSTUnloadReqByCV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1370", Me.TimeChart_CSTUnloadReqByCV1.TabIdx)
                Me.TimeChart_CSTUnloadReqByCV1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_23CST_UNLOAD_BY_RST
                TabConvert("01A0", Me.TimeChart_CSTUnloadReqByRST1.TabIdx)
                Me.TimeChart_CSTUnloadReqByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01AB", Me.TimeChart_CSTUnloadReqByRST1.TabIdx)
                Me.TimeChart_CSTUnloadReqByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01B0", Me.TimeChart_CSTUnloadReqByRST1.TabIdx)
                Me.TimeChart_CSTUnloadReqByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1370", Me.TimeChart_CSTUnloadReqByRST1.TabIdx)
                Me.TimeChart_CSTUnloadReqByRST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_24CST_UNLOAD_COMP
                TabConvert("01B8", Me.TimeChart_CSTUnloadComp1.TabIdx)
                Me.TimeChart_CSTUnloadComp1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1378", Me.TimeChart_CSTUnloadComp1.TabIdx)
                Me.TimeChart_CSTUnloadComp1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_25DUMMY_CANCEL
                TabConvert("0200", Me.TimeChart_CSTDummyCancel1.TabIdx)
                Me.TimeChart_CSTDummyCancel1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("1330", Me.TimeChart_CSTDummyCancel1.TabIdx)
                Me.TimeChart_CSTDummyCancel1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_26PORT_CHANGE
                TabConvert("01DB", Me.TimeChart_PortChangeReq1.TabIdx)
                Me.TimeChart_PortChangeReq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("13A0", Me.TimeChart_PortChangeReq1.TabIdx)
                Me.TimeChart_PortChangeReq1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_27CVTR
                TabConvert("1326", TimeChart_CVTR1.TabIdx)
                Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("13C0", 0)
                Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01D5", 0)
                Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                If Me.TimeChart_CVTR1.TabIdx = 0 Then
                    TabConvert("01E0", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E1", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E2", 0)

                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D0", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D1", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                ElseIf Me.TimeChart_CVTR1.TabIdx = 1 Then
                    TabConvert("01E3", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E4", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E5", 0)

                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D2", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D3", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.TimeChart_CVTR1.TabIdx = 2 Then
                    TabConvert("01E6", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E7", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01E8", 0)

                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D4", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D5", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.TimeChart_CVTR1.TabIdx = 3 Then
                    TabConvert("01E9", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01EA", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01EB", 0)

                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D6", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D7", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.TimeChart_CVTR1.TabIdx = 4 Then
                    TabConvert("01EC", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01ED", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01EE", 0)
                    Me.GxtR_CV2RST1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13D8", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("13D9", 0)
                    Me.TimeChart_CVTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                End If
                '========================================================================================================
            Case eCVGUIIndex.IDX_3ND_28RSTTR
                TabConvert("1326", Me.TimeChart_RSTTR1.TabIdx)
                Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("13C0", 0)
                Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                TabConvert("01D5", 0)
                Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                If Me.TimeChart_RSTTR1.TabIdx = 0 Then
                    TabConvert("01F0", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F1", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F2", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E0", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E1", 0)
                    'Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.TimeChart_RSTTR1.TabIdx = 1 Then
                    TabConvert("01F3", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F4", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F5", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E1", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E3", 0)
                    'Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.TimeChart_RSTTR1.TabIdx = 2 Then
                    TabConvert("01F6", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F7", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01F8", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E2", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E5", 0)
                    'Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.TimeChart_RSTTR1.TabIdx = 3 Then
                    TabConvert("01F9", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FA", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FB", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E3", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E7", 0)
                    'Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                ElseIf Me.TimeChart_RSTTR1.TabIdx = 4 Then
                    TabConvert("01FC", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FD", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    TabConvert("01FE", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))

                    TabConvert("13E4", 0)
                    Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                    'TabConvert("13E9", 0)
                    'Me.TimeChart_RSTTR1.SetSignalOnOff(TabConvertValString, SignalOnOff(TabConvertValHex))
                End If
                '========================================================================================================
        End Select

    End Sub

    Private Sub TabConvert(ByVal strHexCode As String, ByVal nTab As Integer)
        Dim lngRet As Long

        lngRet = ("&H" & strHexCode) + nTab

        If Len(CStr(lngRet)) = 3 Then
            TabConvertValString = "0" & CStr(Hex(lngRet))
        Else
            TabConvertValString = CStr(Hex(lngRet))
        End If
        TabConvertValHex = lngRet
    End Sub

    Private Property TabConvertValString() As String
        Get
            TabConvertValString = mvarTabConvertString
        End Get
        Set(ByVal value As String)
            mvarTabConvertString = value
        End Set
    End Property

    Private Property TabConvertValHex() As Long
        Get
            TabConvertValHex = mvarTabConvertHex
        End Get
        Set(ByVal value As Long)
            mvarTabConvertHex = value
        End Set
    End Property

    Private Sub test()
        Dim nFor As Integer

        For nFor = &H180 To &H22F
            If mvarCVGUISignalName(nFor) <> "" Then
                SignalOnOff(nFor) = 1
            End If
        Next
        For nFor = &H1300 To &H13FF
            If mvarCVGUISignalName(nFor) <> "" Then
                SignalOnOff(nFor) = 1
            End If
        Next

        For nFor = 1 To 512
            AlarmOnOff(nFor) = 1
        Next
    End Sub
#End Region

    Private Sub CstDummyCancel1_PortTabChange(ByVal nPort As Integer) Handles CstDummyCancel1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub CstLoadComplete1_PortTabChange(ByVal nPort As Integer) Handles CstLoadComplete1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub CstLoadReq1_PortTabChange(ByVal nPort As Integer) Handles CstLoadReq1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub CstPresent1_PortTabChange(ByVal nPort As Integer) Handles CstPresent1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub CstRemoved1_PortTabChange(ByVal nPort As Integer) Handles CstRemoved1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub CstUnloadByCV1_PortTabChange(ByVal nPort As Integer) Handles CstUnloadByCV1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub CstUnloadByRST1_PortTabChange(ByVal nPort As Integer) Handles CstUnloadByRST1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub CstUnloadComp1_PortTabChange(ByVal nPort As Integer) Handles CstUnloadComp1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub GxFlowIn1_PortTabChange(ByVal nPort As Integer) Handles GxFlowIn1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub GxFlowOut1_PortTabChange(ByVal nPort As Integer) Handles GxFlowOut1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub GxtR_CV2RST1_PortTabChange(ByVal nPort As Integer) Handles GxtR_CV2RST1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub GxTR_RST2CV1_PortTabChange(ByVal nPort As Integer) Handles GxTR_RST2CV1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub PortChangeReq1_PortTabChange(ByVal nPort As Integer) Handles PortChangeReq1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub PortPause1_PortTabChange(ByVal nPort As Integer) Handles PortPause1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub PortResume1_PortTabChange(ByVal nPort As Integer) Handles PortResume1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub ConvertSignalChange(ByVal strSignalID As String)
        Dim lngSignalID As Integer
        lngSignalID = "&H" & strSignalID

        CVGUIWriteSignalOnOff(lngSignalID)

        RaiseEvent ENGSignalChange(lngSignalID)
    End Sub
    Private Sub CstDummyCancel1_RSTSignalClick(ByVal strSignalID As String) Handles CstDummyCancel1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstLoadComplete1_RSTSignalClick(ByVal strSignalID As String) Handles CstLoadComplete1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstLoadReq1_RSTSignalClick(ByVal strSignalID As String) Handles CstLoadReq1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstPresent1_RSTSignalClick(ByVal strSignalID As String) Handles CstPresent1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstProcessCMD1_RSTSignalClick(ByVal strSignalID As String) Handles CstProcessCMD1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstRemoved1_RSTSignalClick(ByVal strSignalID As String) Handles CstRemoved1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstUnloadByCV1_RSTSignalClick(ByVal strSignalID As String) Handles CstUnloadByCV1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstUnloadByRST1_RSTSignalClick(ByVal strSignalID As String) Handles CstUnloadByRST1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub CstUnloadComp1_RSTSignalClick(ByVal strSignalID As String) Handles CstUnloadComp1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub GxAbnormal1_RSTSignalClick(ByVal strSignalID As String) Handles GxAbnormal1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub GxDataReq1_RSTSignalClick(ByVal strSignalID As String) Handles GxDataReq1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub GxFlowIn1_RSTSignalClick(ByVal strSignalID As String) Handles GxFlowIn1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub GxFlowOut1_RSTSignalClick(ByVal strSignalID As String) Handles GxFlowOut1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub GxInfoUnmatch1_RSTSignalClick(ByVal strSignalID As String) Handles GxInfoUnmatch1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub GxtR_CV2RST1_RSTSignalClick(ByVal strSignalID As String) Handles GxtR_CV2RST1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub LinkStatus1_RSTSignalClick(ByVal strSignalID As String) Handles LinkStatus1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub GxTR_RST2CV1_RSTSignalClick(ByVal strSignalID As String) Handles GxTR_RST2CV1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub PortChangeReq1_RSTSignalClick(ByVal strSignalID As String) Handles PortChangeReq1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub PortPause1_RSTSignalClick(ByVal strSignalID As String) Handles PortPause1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub PortResume1_RSTSignalClick(ByVal strSignalID As String) Handles PortResume1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub PortStatus1_RSTSignalClick(ByVal strSignalID As String) Handles PortStatus1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub StatusReport1_RSTSignalClick(ByVal strSignalID As String) Handles StatusReport1.RSTSignalClick
        ConvertSignalChange(strSignalID)
    End Sub

    Private Sub RstSignal1_SignalClick(ByVal strSignalID As String) Handles RstSignal1.SignalClick
        ConvertSignalChange(strSignalID)
    End Sub


    Private Sub MyTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTimer.Tick
        Call GUISignalCTL()

        CstDummyCancel1.ShowGUIDummyCancelResult()
        CstProcessCMD1.ShowGUIProcessCmd()
        StatusReport1.ShowGUIStatusReport()
        PortStatus1.ShowGUIPortStatusReport()
        GxDataReq1.ShowGUIGlassDataRequest()
        GxAbnormal1.ShowGUIGlassAbnormalCaseReport()
        GxInfoUnmatch1.ShowGUIGlassSlotUnmatchedReport()
        CstLoadComplete1.ShowGUICSTLoadComplete()
        GxFlowOut1.ShowGUICVGxFlowOut()
        GxFlowIn1.ShowGUICVGxFlowIn()
        CstUnloadByCV1.ShowGUIUnloadRequestByCV()
        CstUnloadByRST1.ShowGUIUnloadRequestByRST()
        CstDummyCancel1.ShowGUIDummyCancelResult()
        PortChangeReq1.ShowGUIPortChangeRequest()
        GxtR_CV2RST1.ShowGUITransferRequestCVtoRST()
        GxTR_RST2CV1.ShowGUITransferRequestRSTtoCV()

    End Sub

    Private Sub MyCheckTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyCheckTimer.Tick
        If g_fMyCVGUITimerStart Then
            MyTimer.Enabled = True
        Else
            MyTimer.Enabled = False
        End If
    End Sub
End Class
