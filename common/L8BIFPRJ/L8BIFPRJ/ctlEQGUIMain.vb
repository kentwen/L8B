
Imports System.Drawing

Public Class ctlEQGUIMain
    Public Event ENGSignalChange(ByVal lngSignal As Long)

    Private mvarCurrentGUIIdx As eEQGUIIndex
    Private mvarTabConvertString As String
    Private mvarTabConvertHex As Long
    Private mvarENGMode As Boolean

    Dim WithEvents MyTimer As New Timer
    Dim WithEvents MyCheckTimer As New Timer


    Private Enum eEQGUIIndex
        IDX_1ST_10SIGNAL
        IDX_1ST_11MAP
        IDX_2ND_20LINK
        IDX_2ND_21STATUS
        IDX_2ND_22GXLOAD
        IDX_2ND_23GXUNLOAD
        IDX_2ND_24GXEX
        IDX_2ND_25RECIPE_MODIFY
        IDX_2ND_26GX_ERASE
        IDX_2ND_27RECIPE_CHK
        IDX_2ND_28ALARM
        IDX_3RD_30LINK
        IDX_3RD_31GXLOAD
        IDX_3RD_32GXUNLOAD
        IDX_3RD_33GXEX
        IDX_3RD_34RECIPE_MODIFY
        IDX_3RD_35GX_ERASE
        IDX_3RD_36RECIPE_CHK
    End Enum

    Public Property ENGMode() As Boolean
        Get
            ENGMode = mvarENGMode
        End Get
        Set(ByVal value As Boolean)
            mvarENGMode = value

            Me.OcxGxErase1.ENGType = value
            Me.OcxGxExchange1.ENGType = value
            Me.OcxGxLoad1.ENGType = value
            Me.OcxGxUnload1.ENGType = value
            Me.OcxLinkState1.ENGType = value
            Me.OcxPPIDChk1.ENGType = value
            Me.OcxPPIDModify1.ENGType = value
            Me.OcxSignal1.ENGType = value
            Me.OcxStatus1.ENGType = value

        End Set
    End Property

    Public WriteOnly Property BackColorForRSTSignalON() As System.Drawing.Color
        Set(ByVal value As System.Drawing.Color)

            Me.OcxGxErase1.BackColorForRSTSignalON = value
            Me.OcxGxLoad1.BackColorForRSTSignalON = value
            Me.OcxGxUnload1.BackColorForRSTSignalON = value
            Me.OcxGxExchange1.BackColorForRSTSignalON = value
            Me.OcxLinkState1.BackColorForRSTSignalON = value
            Me.OcxPPIDChk1.BackColorForRSTSignalON = value
            Me.OcxPPIDModify1.BackColorForRSTSignalON = value
            Me.OcxSignal1.BackColorForRSTSignalON = value
            Me.OcxStatus1.BackColorForRSTSignalON = value
            Me.OcxTimeCht_GxErase1.BackColorForRSTSignalON = value
            Me.OcxTimeCht_GxExchange1.BackColorForRSTSignalON = value
            Me.OcxTimeCht_GxLoad1.BackColorForRSTSignalON = value
            Me.OcxTimeCht_GxUnload1.BackColorForRSTSignalON = value
            Me.OcxTimeCht_Link1.BackColorForRSTSignalON = value
            Me.OcxTimeCht_PPIDChk1.BackColorForRSTSignalON = value
            Me.OcxTimeCht_PPIDModify1.BackColorForRSTSignalON = value
        End Set
    End Property

    Public WriteOnly Property BackColorForEQSignalON() As System.Drawing.Color
        Set(ByVal value As System.Drawing.Color)
            Me.AlarmMonitor1.BackColorForSignalON = value
            Me.OcxGxErase1.BackColorForCVSignalON = value
            Me.OcxGxLoad1.BackColorForCVSignalON = value
            Me.OcxGxUnload1.BackColorForCVSignalON = value
            Me.OcxGxExchange1.BackColorForCVSignalON = value
            Me.OcxLinkState1.BackColorForCVSignalON = value
            Me.OcxPPIDChk1.BackColorForCVSignalON = value
            Me.OcxPPIDModify1.BackColorForCVSignalON = value
            Me.OcxSignal1.BackColorForCVSignalON = value
            Me.OcxStatus1.BackColorForCVSignalON = value
            Me.OcxTimeCht_GxErase1.BackColorForCVSignalON = value
            Me.OcxTimeCht_GxExchange1.BackColorForCVSignalON = value
            Me.OcxTimeCht_GxLoad1.BackColorForCVSignalON = value
            Me.OcxTimeCht_GxUnload1.BackColorForCVSignalON = value
            Me.OcxTimeCht_Link1.BackColorForCVSignalON = value
            Me.OcxTimeCht_PPIDChk1.BackColorForCVSignalON = value
            Me.OcxTimeCht_PPIDModify1.BackColorForCVSignalON = value
        End Set
    End Property

    Public WriteOnly Property BackColorForSignalOff() As System.Drawing.Color
        Set(ByVal value As System.Drawing.Color)
            Me.AlarmMonitor1.BackColorForSignalOFF = value
            Me.OcxGxErase1.BackColorForSignalOFF = value
            Me.OcxGxLoad1.BackColorForSignalOFF = value
            Me.OcxGxUnload1.BackColorForSignalOFF = value
            Me.OcxGxExchange1.BackColorForSignalOFF = value
            Me.OcxLinkState1.BackColorForSignalOFF = value
            Me.OcxPPIDChk1.BackColorForSignalOFF = value
            Me.OcxPPIDModify1.BackColorForSignalOFF = value
            Me.OcxSignal1.BackColorForSignalOFF = value
            Me.OcxStatus1.BackColorForSignalOFF = value
            Me.OcxTimeCht_GxErase1.BackColorForSignalOFF = value
            Me.OcxTimeCht_GxExchange1.BackColorForSignalOFF = value
            Me.OcxTimeCht_GxLoad1.BackColorForSignalOFF = value
            Me.OcxTimeCht_GxUnload1.BackColorForSignalOFF = value
            Me.OcxTimeCht_Link1.BackColorForSignalOFF = value
            Me.OcxTimeCht_PPIDChk1.BackColorForSignalOFF = value
            Me.OcxTimeCht_PPIDModify1.BackColorForSignalOFF = value
        End Set
    End Property

    Public Sub SetAllSignalONSim()
        test()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColorForRSTSignalON = Color.Aqua
        BackColorForEQSignalON = Color.Red
        BackColorForSignalOff = Color.White
        IniAddressMapSignalName()
        IniSignalModifyTime()
        IniLinkMapGUI()

        MyCheckTimer.Interval = 200
        MyCheckTimer.Enabled = True

        MyTimer.Interval = 200

        mvarCurrentGUIIdx = eEQGUIIndex.IDX_1ST_10SIGNAL
        GUISignalCTL()
    End Sub

    Public Property SignalOnOff(ByVal lngAddrKey As Long) As Integer
        Get
            SignalOnOff = mvarEQGUISignalOnOff(lngAddrKey)
        End Get
        Set(ByVal value As Integer)
            mvarEQGUISignalOnOff(lngAddrKey) = value
        End Set
    End Property

    Public Property SignalName(ByVal lngAddrKey As Long) As String
        Get
            SignalName = mvarEQGUISignalName(lngAddrKey)
        End Get
        Set(ByVal value As String)
            mvarEQGUISignalName(lngAddrKey) = value
        End Set
    End Property

    Public Property SignalModifyTime(ByVal lngAddrKey As Long) As String
        Get
            SignalModifyTime = mvarEQGUIModifyTime(lngAddrKey)
        End Get
        Set(ByVal value As String)
            mvarEQGUIModifyTime(lngAddrKey) = value
        End Set
    End Property

    Public Property AlarmOnOffEQ1(ByVal nIdx As Integer) As Integer
        Get
            AlarmOnOffEQ1 = mvarEQGUIAlarmTable(1, nIdx)
        End Get
        Set(ByVal value As Integer)
            mvarEQGUIAlarmTable(1, nIdx) = value
        End Set
    End Property

    Public Property AlarmOnOffEQ2(ByVal nIdx As Integer) As Integer
        Get
            AlarmOnOffEQ2 = mvarEQGUIAlarmTable(2, nIdx)
        End Get
        Set(ByVal value As Integer)
            mvarEQGUIAlarmTable(2, nIdx) = value
        End Set
    End Property

    Public Property AlarmOnOffEQ3(ByVal nIdx As Integer) As Integer
        Get
            AlarmOnOffEQ3 = mvarEQGUIAlarmTable(3, nIdx)
        End Get
        Set(ByVal value As Integer)
            mvarEQGUIAlarmTable(3, nIdx) = value
        End Set
    End Property

#Region "Private Sub"
    Private Sub IniSignalModifyTime()
        Dim nFor As Integer
        Dim lngStep As Long
        Dim lngEQStep As Long
        For nFor = 0 To 2
            If nFor = 0 Then
                lngStep = 0
                lngEQStep = &H300
            ElseIf nFor = 1 Then
                lngStep = &H80
                lngEQStep = &H700
            ElseIf nFor = 2 Then
                lngStep = &H100
                lngEQStep = &H1000
            End If

            SignalModifyTime(&H0 + lngStep) = Now
            SignalModifyTime(&H1 + lngStep) = Now
            SignalModifyTime(&H10 + lngStep) = Now
            SignalModifyTime(&H11 + lngStep) = Now
            SignalModifyTime(&H12 + lngStep) = Now
            SignalModifyTime(&H20 + lngStep) = Now
            SignalModifyTime(&H21 + lngStep) = Now
            SignalModifyTime(&H22 + lngStep) = Now
            SignalModifyTime(&H28 + lngStep) = Now
            SignalModifyTime(&H29 + lngStep) = Now
            SignalModifyTime(&H2A + lngStep) = Now
            SignalModifyTime(&H30 + lngStep) = Now
            SignalModifyTime(&H31 + lngStep) = Now
            SignalModifyTime(&H32 + lngStep) = Now
            SignalModifyTime(&H33 + lngStep) = Now
            SignalModifyTime(&H34 + lngStep) = Now
            SignalModifyTime(&H40 + lngStep) = Now
            SignalModifyTime(&H42 + lngStep) = Now
            SignalModifyTime(&H43 + lngStep) = Now
            SignalModifyTime(&H45 + lngStep) = Now

            SignalModifyTime(&H0 + lngEQStep) = Now
            SignalModifyTime(&H1 + lngEQStep) = Now
            SignalModifyTime(&H10 + lngEQStep) = Now
            SignalModifyTime(&H11 + lngEQStep) = Now
            SignalModifyTime(&H12 + lngEQStep) = Now
            SignalModifyTime(&H15 + lngEQStep) = Now
            SignalModifyTime(&H20 + lngEQStep) = Now
            SignalModifyTime(&H21 + lngEQStep) = Now
            SignalModifyTime(&H28 + lngEQStep) = Now
            SignalModifyTime(&H29 + lngEQStep) = Now
            SignalModifyTime(&H30 + lngEQStep) = Now
            SignalModifyTime(&H31 + lngEQStep) = Now
            SignalModifyTime(&H40 + lngEQStep) = Now
            SignalModifyTime(&H42 + lngEQStep) = Now
            SignalModifyTime(&H43 + lngEQStep) = Now
            SignalModifyTime(&H45 + lngEQStep) = Now

        Next
    End Sub

    Private Sub IniAddressMapSignalName()
        Dim nFor As Integer
        Dim lngStep As Long
        Dim lngEQStep As Long
        For nFor = 0 To 2
            If nFor = 0 Then
                lngStep = 0
                lngEQStep = &H300
            ElseIf nFor = 1 Then
                lngStep = &H80
                lngEQStep = &H700
            ElseIf nFor = 2 Then
                lngStep = &H100
                lngEQStep = &H1000
            End If

            SignalName(&H0 + lngStep) = "EQ-" & (nFor + 1) & " RST Link Request"
            SignalName(&H1 + lngStep) = "EQ-" & (nFor + 1) & " RST Link Request"
            SignalName(&H10 + lngStep) = "EQ-" & (nFor + 1) & " RST Ignore Timeout"
            SignalName(&H11 + lngStep) = "EQ-" & (nFor + 1) & " RST Arm Mode"
            SignalName(&H12 + lngStep) = "EQ-" & (nFor + 1) & " RST Transfer Mode"
            SignalName(&H20 + lngStep) = "EQ-" & (nFor + 1) & " RST Load TR"
            SignalName(&H21 + lngStep) = "EQ-" & (nFor + 1) & " RST Load Busy"
            SignalName(&H22 + lngStep) = "EQ-" & (nFor + 1) & " RST Load Complete"
            SignalName(&H28 + lngStep) = "EQ-" & (nFor + 1) & " RST Unload TR"
            SignalName(&H29 + lngStep) = "EQ-" & (nFor + 1) & " RST Unload Busy"
            SignalName(&H2A + lngStep) = "EQ-" & (nFor + 1) & " RST Unload Complete"
            SignalName(&H30 + lngStep) = "EQ-" & (nFor + 1) & " RST Exchange TR"
            SignalName(&H31 + lngStep) = "EQ-" & (nFor + 1) & " RST Robot Get Busy"
            SignalName(&H32 + lngStep) = "EQ-" & (nFor + 1) & " RST Robot Put Busy"
            SignalName(&H33 + lngStep) = "EQ-" & (nFor + 1) & " RST Exchange Complete"
            SignalName(&H34 + lngStep) = "EQ-" & (nFor + 1) & " RST Exchange Status"
            SignalName(&H40 + lngStep) = "EQ-" & (nFor + 1) & " RST EPPID Modify Ack"
            SignalName(&H42 + lngStep) = "EQ-" & (nFor + 1) & " RST Transfer Reset Request"
            SignalName(&H43 + lngStep) = "EQ-" & (nFor + 1) & " RST Glass Erase Ack"
            SignalName(&H45 + lngStep) = "EQ-" & (nFor + 1) & " RST EPPID Check Request"
            '20100930 Add
            SignalName(&H47 + lngStep) = "EQ-" & (nFor + 1) & " EPPID Query Request"
            SignalName(&H49 + lngStep) = "EQ-" & (nFor + 1) & " Repair review mode flag"
            SignalName(&H50 + lngStep) = "EQ-" & (nFor + 1) & " Macro Inspection Flag"

            SignalName(&H0 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Link Request"
            SignalName(&H1 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Link Test Response"
            SignalName(&H10 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Exist On Stage"
            SignalName(&H11 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass In Process"
            SignalName(&H12 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Handoff Available"
            SignalName(&H15 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Alarm Occurred"
            SignalName(&H20 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Load Request"
            SignalName(&H21 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Load Ready"
            SignalName(&H28 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Unload Request"
            SignalName(&H29 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Unload Ready"
            SignalName(&H30 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Exchange Request"
            SignalName(&H31 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Exchange Ready"
            SignalName(&H40 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine EPPID Modify Report"
            SignalName(&H42 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Transfer Reset Ack"
            SignalName(&H43 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine Glass Erase Report"
            SignalName(&H45 + lngEQStep) = "EQ-" & (nFor + 1) & " Machine EPPID Check Ack"
        Next
    End Sub

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


        For i As Integer = 0 To UBound(mvarEQGUISignalName)
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

    Private Function ConvertAddrToHex(ByVal lngKeyIndex As Long) As String
        'Dim strRet As String
        If mvarEQGUISignalName(lngKeyIndex) <> "" Then
            ConvertAddrToHex = Hex(lngKeyIndex)
            'If Len(strRet) = 1 Then
            '    ConvertAddrToHex = "00" & strRet
            'ElseIf Len(strRet) = 2 Then
            '    ConvertAddrToHex = "0" & strRet
            'Else
            '    If lngKeyIndex >= &H300 Then
            '        If lngKeyIndex >= &H1000 Then

            '        Else
            '            strRet = "0" & Hex(lngKeyIndex)
            '        End If

            '    End If
            '    ConvertAddrToHex = strRet
            'End If
        Else
            ConvertAddrToHex = ""
        End If

    End Function

    Private ReadOnly Property CurrentGUI() As eEQGUIIndex
        Get
            CurrentGUI = mvarCurrentGUIIdx
        End Get
    End Property

    Private Sub test()
        Me.ENGMode = True
        Dim nFor As Integer

        For nFor = &H0 To &H4F
            If mvarEQGUISignalName(nFor) <> "" Then
                Me.SignalOnOff((nFor)) = 1
            End If
        Next

        'For nFor = &H300 To &H34F
        '    If mvarSignalName(nFor) <> "" Then
        '        Me.SignalOnOff((nFor)) = 1
        '    End If
        'Next


        For nFor = &H80 To &HCF
            If mvarEQGUISignalName(nFor) <> "" Then
                Me.SignalOnOff((nFor)) = 1
            End If
        Next

        For nFor = &H700 To &H74F
            If mvarEQGUISignalName(nFor) <> "" Then
                Me.SignalOnOff((nFor)) = 1
            End If
        Next

        For nFor = &H100 To &H14F
            If mvarEQGUISignalName(nFor) <> "" Then
                Me.SignalOnOff((nFor)) = 1
            End If
        Next

        For nFor = &H1000 To &H104F
            If mvarEQGUISignalName(nFor) <> "" Then
                Me.SignalOnOff((nFor)) = 1
            End If
        Next

        For nFor = 1 To 512
            Me.AlarmOnOffEQ1(nFor) = 1
            'Me.AlarmOnOffEQ2(nFor) = 1
            Me.AlarmOnOffEQ3(nFor) = 1
        Next

    End Sub
#End Region

    Private Sub tabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.SelectedIndexChanged
        If tabMain.SelectedIndex = 0 Then 'General
            GeneralGUI(tabGeneral.SelectedIndex)
        ElseIf tabMain.SelectedIndex = 1 Then 'Equip
            EQGUI(tabEq.SelectedIndex)
        ElseIf tabMain.SelectedIndex = 2 Then 'TimeChart
            TimeChtGUI(tabTimeCht.SelectedIndex)
        End If
    End Sub

    Private Sub GeneralGUI(ByVal nSelected As Integer)
        If nSelected = 0 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_1ST_10SIGNAL
        Else
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_1ST_11MAP
        End If
        GUISignalCTL()
    End Sub

    Private Sub EQGUI(ByVal nSelected As Integer)
        If nSelected = 0 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_20LINK
        ElseIf nSelected = 1 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_21STATUS
        ElseIf nSelected = 2 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_22GXLOAD
        ElseIf nSelected = 3 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_23GXUNLOAD
        ElseIf nSelected = 4 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_24GXEX
        ElseIf nSelected = 5 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_25RECIPE_MODIFY
        ElseIf nSelected = 6 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_26GX_ERASE
        ElseIf nSelected = 7 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_27RECIPE_CHK
        ElseIf nSelected = 8 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_2ND_28ALARM
        End If
        GUISignalCTL()
    End Sub

    Private Sub TimeChtGUI(ByVal nSelected As Integer)
        If nSelected = 0 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_3RD_30LINK
        ElseIf nSelected = 1 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_3RD_31GXLOAD
        ElseIf nSelected = 2 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_3RD_32GXUNLOAD
        ElseIf nSelected = 3 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_3RD_33GXEX
        ElseIf nSelected = 4 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_3RD_34RECIPE_MODIFY
        ElseIf nSelected = 5 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_3RD_35GX_ERASE
        ElseIf nSelected = 6 Then
            mvarCurrentGUIIdx = eEQGUIIndex.IDX_3RD_36RECIPE_CHK
        End If
        GUISignalCTL()
    End Sub

    Private Sub GUISignalCTL()
        Dim nFor As Integer

        Select Case mvarCurrentGUIIdx
            Case eEQGUIIndex.IDX_1ST_10SIGNAL
                If Me.OcxSignal1.TabIdx = 0 Then 'EQ1
                    For nFor = &H0 To &H5F
                        If mvarEQGUISignalName(nFor) <> "" Then
                            OcxSignal1.SetSignalOnOff(ConvertAddrToHex(nFor), Me.SignalOnOff(nFor))
                        End If
                    Next

                    For nFor = &H300 To &H34F
                        If mvarEQGUISignalName(nFor) <> "" Then
                            OcxSignal1.SetSignalOnOff(ConvertAddrToHex(nFor), Me.SignalOnOff(nFor))
                        End If
                    Next

                ElseIf Me.OcxSignal1.TabIdx = 1 Then 'EQ2
                    For nFor = &H80 To &HDF
                        If mvarEQGUISignalName(nFor) <> "" Then
                            OcxSignal1.SetSignalOnOff(ConvertAddrToHex(nFor), Me.SignalOnOff(nFor))
                        End If
                    Next

                    For nFor = &H700 To &H74F
                        If mvarEQGUISignalName(nFor) <> "" Then
                            OcxSignal1.SetSignalOnOff(ConvertAddrToHex(nFor), Me.SignalOnOff(nFor))
                        End If
                    Next
                ElseIf Me.OcxSignal1.TabIdx = 2 Then 'EQ3
                    For nFor = &H100 To &H15F
                        If mvarEQGUISignalName(nFor) <> "" Then
                            OcxSignal1.SetSignalOnOff(ConvertAddrToHex(nFor), Me.SignalOnOff(nFor))
                        End If
                    Next

                    For nFor = &H1000 To &H104F
                        If mvarEQGUISignalName(nFor) <> "" Then
                            OcxSignal1.SetSignalOnOff(ConvertAddrToHex(nFor), Me.SignalOnOff(nFor))
                        End If
                    Next
                End If
            Case eEQGUIIndex.IDX_1ST_11MAP
                IniLinkMapGUI()
            Case eEQGUIIndex.IDX_2ND_20LINK
                If Me.OcxLinkState1.TabIdx = 0 Then
                    OcxLinkState1.SetSignalOnOff("0", SignalOnOff(&H0))
                    OcxLinkState1.SetSignalOnOff("1", SignalOnOff(&H1))
                    OcxLinkState1.SetSignalOnOff("300", SignalOnOff(&H300))
                    OcxLinkState1.SetSignalOnOff("301", SignalOnOff(&H301))
                ElseIf Me.OcxLinkState1.TabIdx = 1 Then
                    OcxLinkState1.SetSignalOnOff("80", SignalOnOff(&H80))
                    OcxLinkState1.SetSignalOnOff("81", SignalOnOff(&H81))
                    OcxLinkState1.SetSignalOnOff("700", SignalOnOff(&H700))
                    OcxLinkState1.SetSignalOnOff("701", SignalOnOff(&H701))
                ElseIf Me.OcxLinkState1.TabIdx = 2 Then
                    OcxLinkState1.SetSignalOnOff("100", SignalOnOff(&H100))
                    OcxLinkState1.SetSignalOnOff("101", SignalOnOff(&H101))
                    OcxLinkState1.SetSignalOnOff("1000", SignalOnOff(&H1000))
                    OcxLinkState1.SetSignalOnOff("1001", SignalOnOff(&H1001))
                End If
            Case eEQGUIIndex.IDX_2ND_21STATUS
                If Me.OcxStatus1.TabIdx = 0 Then
                    OcxStatus1.SetSignalOnOff("10", SignalOnOff(&H10))
                    OcxStatus1.SetSignalOnOff("11", SignalOnOff(&H11))
                    OcxStatus1.SetSignalOnOff("12", SignalOnOff(&H12))
                ElseIf Me.OcxStatus1.TabIdx = 1 Then
                    OcxStatus1.SetSignalOnOff("90", SignalOnOff(&H90))
                    OcxStatus1.SetSignalOnOff("91", SignalOnOff(&H91))
                    OcxStatus1.SetSignalOnOff("92", SignalOnOff(&H92))
                ElseIf Me.OcxStatus1.TabIdx = 2 Then
                    OcxStatus1.SetSignalOnOff("110", SignalOnOff(&H110))
                    OcxStatus1.SetSignalOnOff("111", SignalOnOff(&H111))
                    OcxStatus1.SetSignalOnOff("112", SignalOnOff(&H112))
                End If
            Case eEQGUIIndex.IDX_2ND_22GXLOAD
                If Me.OcxGxLoad1.TabIdx = 0 Then
                    OcxGxLoad1.SetSignalOnOff("20", SignalOnOff(&H20))
                    OcxGxLoad1.SetSignalOnOff("21", SignalOnOff(&H21))
                    OcxGxLoad1.SetSignalOnOff("22", SignalOnOff(&H22))
                    OcxGxLoad1.SetSignalOnOff("42", SignalOnOff(&H42))
                    OcxGxLoad1.SetSignalOnOff("320", SignalOnOff(&H320))
                    OcxGxLoad1.SetSignalOnOff("321", SignalOnOff(&H321))
                    OcxGxLoad1.SetSignalOnOff("342", SignalOnOff(&H342))
                ElseIf Me.OcxGxLoad1.TabIdx = 1 Then
                    OcxGxLoad1.SetSignalOnOff("A0", SignalOnOff(&HA0))
                    OcxGxLoad1.SetSignalOnOff("A1", SignalOnOff(&HA1))
                    OcxGxLoad1.SetSignalOnOff("A2", SignalOnOff(&HA2))
                    OcxGxLoad1.SetSignalOnOff("C2", SignalOnOff(&HC2))
                    OcxGxLoad1.SetSignalOnOff("720", SignalOnOff(&H720))
                    OcxGxLoad1.SetSignalOnOff("721", SignalOnOff(&H721))
                    OcxGxLoad1.SetSignalOnOff("742", SignalOnOff(&H742))
                ElseIf Me.OcxGxLoad1.TabIdx = 2 Then
                    OcxGxLoad1.SetSignalOnOff("120", SignalOnOff(&H120))
                    OcxGxLoad1.SetSignalOnOff("121", SignalOnOff(&H121))
                    OcxGxLoad1.SetSignalOnOff("122", SignalOnOff(&H122))
                    OcxGxLoad1.SetSignalOnOff("142", SignalOnOff(&H142))
                    OcxGxLoad1.SetSignalOnOff("1020", SignalOnOff(&H1020))
                    OcxGxLoad1.SetSignalOnOff("1021", SignalOnOff(&H1021))
                    OcxGxLoad1.SetSignalOnOff("1042", SignalOnOff(&H1042))
                End If
            Case eEQGUIIndex.IDX_2ND_23GXUNLOAD
                If Me.OcxGxUnload1.TabIdx = 0 Then
                    OcxGxUnload1.SetSignalOnOff("28", SignalOnOff(&H28))
                    OcxGxUnload1.SetSignalOnOff("29", SignalOnOff(&H29))
                    OcxGxUnload1.SetSignalOnOff("2A", SignalOnOff(&H2A))
                    OcxGxUnload1.SetSignalOnOff("42", SignalOnOff(&H42))
                    OcxGxUnload1.SetSignalOnOff("328", SignalOnOff(&H328))
                    OcxGxUnload1.SetSignalOnOff("329", SignalOnOff(&H329))
                    OcxGxUnload1.SetSignalOnOff("342", SignalOnOff(&H342))
                ElseIf Me.OcxGxUnload1.TabIdx = 1 Then
                    OcxGxUnload1.SetSignalOnOff("A8", SignalOnOff(&HA8))
                    OcxGxUnload1.SetSignalOnOff("A9", SignalOnOff(&HA9))
                    OcxGxUnload1.SetSignalOnOff("AA", SignalOnOff(&HAA))
                    OcxGxUnload1.SetSignalOnOff("C2", SignalOnOff(&HC2))
                    OcxGxUnload1.SetSignalOnOff("728", SignalOnOff(&H728))
                    OcxGxUnload1.SetSignalOnOff("729", SignalOnOff(&H729))
                    OcxGxUnload1.SetSignalOnOff("742", SignalOnOff(&H742))
                ElseIf Me.OcxGxUnload1.TabIdx = 2 Then
                    OcxGxUnload1.SetSignalOnOff("128", SignalOnOff(&H128))
                    OcxGxUnload1.SetSignalOnOff("129", SignalOnOff(&H129))
                    OcxGxUnload1.SetSignalOnOff("12A", SignalOnOff(&H12A))
                    OcxGxUnload1.SetSignalOnOff("142", SignalOnOff(&H142))
                    OcxGxUnload1.SetSignalOnOff("1028", SignalOnOff(&H1028))
                    OcxGxUnload1.SetSignalOnOff("1029", SignalOnOff(&H1029))
                    OcxGxUnload1.SetSignalOnOff("1042", SignalOnOff(&H1042))
                End If
            Case eEQGUIIndex.IDX_2ND_24GXEX
                If Me.OcxGxExchange1.TabIdx = 0 Then
                    OcxGxExchange1.SetSignalOnOff("30", SignalOnOff(&H30))
                    OcxGxExchange1.SetSignalOnOff("31", SignalOnOff(&H31))
                    OcxGxExchange1.SetSignalOnOff("32", SignalOnOff(&H32))
                    OcxGxExchange1.SetSignalOnOff("33", SignalOnOff(&H33))
                    OcxGxExchange1.SetSignalOnOff("34", SignalOnOff(&H34))
                    OcxGxExchange1.SetSignalOnOff("42", SignalOnOff(&H42))
                    OcxGxExchange1.SetSignalOnOff("330", SignalOnOff(&H330))
                    OcxGxExchange1.SetSignalOnOff("331", SignalOnOff(&H331))
                    OcxGxExchange1.SetSignalOnOff("342", SignalOnOff(&H342))
                ElseIf Me.OcxGxExchange1.TabIdx = 1 Then
                    OcxGxExchange1.SetSignalOnOff("B0", SignalOnOff(&HB0))
                    OcxGxExchange1.SetSignalOnOff("B1", SignalOnOff(&HB1))
                    OcxGxExchange1.SetSignalOnOff("B2", SignalOnOff(&HB2))
                    OcxGxExchange1.SetSignalOnOff("B3", SignalOnOff(&HB3))
                    OcxGxExchange1.SetSignalOnOff("B4", SignalOnOff(&HB4))
                    OcxGxExchange1.SetSignalOnOff("C2", SignalOnOff(&HC2))
                    OcxGxExchange1.SetSignalOnOff("730", SignalOnOff(&H730))
                    OcxGxExchange1.SetSignalOnOff("731", SignalOnOff(&H731))
                    OcxGxExchange1.SetSignalOnOff("742", SignalOnOff(&H742))
                ElseIf Me.OcxGxExchange1.TabIdx = 2 Then
                    OcxGxExchange1.SetSignalOnOff("130", SignalOnOff(&H130))
                    OcxGxExchange1.SetSignalOnOff("131", SignalOnOff(&H131))
                    OcxGxExchange1.SetSignalOnOff("132", SignalOnOff(&H132))
                    OcxGxExchange1.SetSignalOnOff("133", SignalOnOff(&H133))
                    OcxGxExchange1.SetSignalOnOff("134", SignalOnOff(&H134))
                    OcxGxExchange1.SetSignalOnOff("142", SignalOnOff(&H142))
                    OcxGxExchange1.SetSignalOnOff("1030", SignalOnOff(&H1030))
                    OcxGxExchange1.SetSignalOnOff("1031", SignalOnOff(&H1031))
                    OcxGxExchange1.SetSignalOnOff("1042", SignalOnOff(&H1042))
                End If
            Case eEQGUIIndex.IDX_2ND_25RECIPE_MODIFY
                If Me.OcxPPIDModify1.TabIdx = 0 Then
                    OcxPPIDModify1.SetSignalOnOff("40", SignalOnOff(&H40))
                    OcxPPIDModify1.SetSignalOnOff("340", SignalOnOff(&H340))
                ElseIf Me.OcxPPIDModify1.TabIdx = 1 Then
                    OcxPPIDModify1.SetSignalOnOff("C0", SignalOnOff(&HC0))
                    OcxPPIDModify1.SetSignalOnOff("740", SignalOnOff(&H740))
                ElseIf Me.OcxPPIDModify1.TabIdx = 2 Then
                    OcxPPIDModify1.SetSignalOnOff("140", SignalOnOff(&H140))
                    OcxPPIDModify1.SetSignalOnOff("1040", SignalOnOff(&H1040))
                End If
            Case eEQGUIIndex.IDX_2ND_26GX_ERASE
                If Me.OcxGxErase1.TabIdx = 0 Then
                    OcxGxErase1.SetSignalOnOff("43", SignalOnOff(&H43))
                    OcxGxErase1.SetSignalOnOff("343", SignalOnOff(&H343))
                ElseIf Me.OcxGxErase1.TabIdx = 1 Then
                    OcxGxErase1.SetSignalOnOff("C3", SignalOnOff(&HC3))
                    OcxGxErase1.SetSignalOnOff("743", SignalOnOff(&H743))
                ElseIf Me.OcxGxErase1.TabIdx = 2 Then
                    OcxGxErase1.SetSignalOnOff("143", SignalOnOff(&H143))
                    OcxGxErase1.SetSignalOnOff("1043", SignalOnOff(&H1043))
                End If
            Case eEQGUIIndex.IDX_2ND_27RECIPE_CHK
                If Me.OcxPPIDChk1.TabIdx = 0 Then
                    OcxPPIDChk1.SetSignalOnOff("45", SignalOnOff(&H45))
                    OcxPPIDChk1.SetSignalOnOff("345", SignalOnOff(&H345))
                ElseIf Me.OcxPPIDChk1.TabIdx = 1 Then
                    OcxPPIDChk1.SetSignalOnOff("C5", SignalOnOff(&HC5))
                    OcxPPIDChk1.SetSignalOnOff("745", SignalOnOff(&H745))
                ElseIf Me.OcxPPIDChk1.TabIdx = 2 Then
                    OcxPPIDChk1.SetSignalOnOff("145", SignalOnOff(&H145))
                    OcxPPIDChk1.SetSignalOnOff("1045", SignalOnOff(&H1045))
                End If
            Case eEQGUIIndex.IDX_2ND_28ALARM
                If tabEQAlarmInfo.SelectedIndex = 0 Then
                    For nFor = 1 To 512
                        Me.AlarmMonitor1.SetSignalOnOff(nFor, Me.AlarmOnOffEQ1(nFor))
                    Next
                ElseIf tabEQAlarmInfo.SelectedIndex = 1 Then
                    For nFor = 1 To 512
                        Me.AlarmMonitor1.SetSignalOnOff(nFor, Me.AlarmOnOffEQ2(nFor))
                    Next
                ElseIf tabEQAlarmInfo.SelectedIndex = 2 Then
                    For nFor = 1 To 512
                        Me.AlarmMonitor1.SetSignalOnOff(nFor, Me.AlarmOnOffEQ3(nFor))
                    Next
                End If
                AlarmMonitor1.ShowAlarm()
            Case eEQGUIIndex.IDX_3RD_30LINK

                If Me.OcxTimeCht_Link1.TabIdx = 0 Then
                    OcxTimeCht_Link1.SetSignalOnOff("0", SignalOnOff(&H0))
                    OcxTimeCht_Link1.SetSignalOnOff("1", SignalOnOff(&H1))
                    OcxTimeCht_Link1.SetSignalOnOff("300", SignalOnOff(&H300))
                    OcxTimeCht_Link1.SetSignalOnOff("301", SignalOnOff(&H301))
                ElseIf Me.OcxTimeCht_Link1.TabIdx = 1 Then
                    OcxTimeCht_Link1.SetSignalOnOff("80", SignalOnOff(&H80))
                    OcxTimeCht_Link1.SetSignalOnOff("81", SignalOnOff(&H81))
                    OcxTimeCht_Link1.SetSignalOnOff("700", SignalOnOff(&H700))
                    OcxTimeCht_Link1.SetSignalOnOff("701", SignalOnOff(&H701))
                ElseIf Me.OcxTimeCht_Link1.TabIdx = 2 Then
                    OcxTimeCht_Link1.SetSignalOnOff("100", SignalOnOff(&H100))
                    OcxTimeCht_Link1.SetSignalOnOff("101", SignalOnOff(&H101))
                    OcxTimeCht_Link1.SetSignalOnOff("1000", SignalOnOff(&H1000))
                    OcxTimeCht_Link1.SetSignalOnOff("1001", SignalOnOff(&H1001))
                End If

            Case eEQGUIIndex.IDX_3RD_31GXLOAD
                If Me.OcxTimeCht_GxLoad1.TabIdx = 0 Then
                    OcxTimeCht_GxLoad1.SetSignalOnOff("20", SignalOnOff(&H20))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("21", SignalOnOff(&H21))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("22", SignalOnOff(&H22))

                    OcxTimeCht_GxLoad1.SetSignalOnOff("320", SignalOnOff(&H320))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("321", SignalOnOff(&H321))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("312", SignalOnOff(&H312))
                ElseIf Me.OcxTimeCht_GxLoad1.TabIdx = 1 Then
                    OcxTimeCht_GxLoad1.SetSignalOnOff("A0", SignalOnOff(&HA0))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("A1", SignalOnOff(&HA1))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("A2", SignalOnOff(&HA2))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("C2", SignalOnOff(&HC2))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("720", SignalOnOff(&H720))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("721", SignalOnOff(&H721))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("712", SignalOnOff(&H712))
                ElseIf Me.OcxTimeCht_GxLoad1.TabIdx = 2 Then
                    OcxTimeCht_GxLoad1.SetSignalOnOff("120", SignalOnOff(&H120))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("121", SignalOnOff(&H121))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("122", SignalOnOff(&H122))

                    OcxTimeCht_GxLoad1.SetSignalOnOff("1020", SignalOnOff(&H1020))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("1021", SignalOnOff(&H1021))
                    OcxTimeCht_GxLoad1.SetSignalOnOff("1012", SignalOnOff(&H1012))
                End If
            Case eEQGUIIndex.IDX_3RD_32GXUNLOAD
                If Me.OcxTimeCht_GxUnload1.TabIdx = 0 Then
                    OcxTimeCht_GxUnload1.SetSignalOnOff("28", SignalOnOff(&H28))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("29", SignalOnOff(&H29))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("2A", SignalOnOff(&H2A))

                    OcxTimeCht_GxUnload1.SetSignalOnOff("328", SignalOnOff(&H328))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("329", SignalOnOff(&H329))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("312", SignalOnOff(&H312))
                ElseIf Me.OcxTimeCht_GxUnload1.TabIdx = 1 Then
                    OcxTimeCht_GxUnload1.SetSignalOnOff("A8", SignalOnOff(&HA8))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("A9", SignalOnOff(&HA9))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("AA", SignalOnOff(&HAA))

                    OcxTimeCht_GxUnload1.SetSignalOnOff("728", SignalOnOff(&H728))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("729", SignalOnOff(&H729))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("712", SignalOnOff(&H712))
                ElseIf Me.OcxTimeCht_GxUnload1.TabIdx = 2 Then
                    OcxTimeCht_GxUnload1.SetSignalOnOff("128", SignalOnOff(&H128))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("129", SignalOnOff(&H129))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("12A", SignalOnOff(&H12A))

                    OcxTimeCht_GxUnload1.SetSignalOnOff("1028", SignalOnOff(&H1028))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("1029", SignalOnOff(&H1029))
                    OcxTimeCht_GxUnload1.SetSignalOnOff("1012", SignalOnOff(&H1012))
                End If


            Case eEQGUIIndex.IDX_3RD_33GXEX

                If Me.OcxTimeCht_GxExchange1.TabIdx = 0 Then
                    OcxTimeCht_GxExchange1.SetSignalOnOff("30", SignalOnOff(&H30))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("31", SignalOnOff(&H31))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("32", SignalOnOff(&H32))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("33", SignalOnOff(&H33))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("34", SignalOnOff(&H34))

                    OcxTimeCht_GxExchange1.SetSignalOnOff("330", SignalOnOff(&H330))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("331", SignalOnOff(&H331))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("312", SignalOnOff(&H312))
                ElseIf Me.OcxTimeCht_GxExchange1.TabIdx = 1 Then
                    OcxTimeCht_GxExchange1.SetSignalOnOff("B0", SignalOnOff(&HB0))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("B1", SignalOnOff(&HB1))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("B2", SignalOnOff(&HB2))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("B3", SignalOnOff(&HB3))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("B4", SignalOnOff(&HB4))

                    OcxTimeCht_GxExchange1.SetSignalOnOff("730", SignalOnOff(&H730))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("731", SignalOnOff(&H731))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("712", SignalOnOff(&H712))
                ElseIf Me.OcxTimeCht_GxExchange1.TabIdx = 2 Then
                    OcxTimeCht_GxExchange1.SetSignalOnOff("130", SignalOnOff(&H130))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("131", SignalOnOff(&H131))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("132", SignalOnOff(&H132))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("133", SignalOnOff(&H133))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("134", SignalOnOff(&H134))

                    OcxTimeCht_GxExchange1.SetSignalOnOff("1030", SignalOnOff(&H1030))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("1031", SignalOnOff(&H1031))
                    OcxTimeCht_GxExchange1.SetSignalOnOff("1012", SignalOnOff(&H1012))
                End If


            Case eEQGUIIndex.IDX_3RD_34RECIPE_MODIFY
                If Me.OcxTimeCht_PPIDModify1.TabIdx = 0 Then
                    OcxTimeCht_PPIDModify1.SetSignalOnOff("40", SignalOnOff(&H40))
                    OcxTimeCht_PPIDModify1.SetSignalOnOff("340", SignalOnOff(&H340))
                ElseIf Me.OcxTimeCht_PPIDModify1.TabIdx = 1 Then
                    OcxTimeCht_PPIDModify1.SetSignalOnOff("C0", SignalOnOff(&HC0))
                    OcxTimeCht_PPIDModify1.SetSignalOnOff("740", SignalOnOff(&H740))
                ElseIf Me.OcxTimeCht_PPIDModify1.TabIdx = 2 Then
                    OcxTimeCht_PPIDModify1.SetSignalOnOff("140", SignalOnOff(&H140))
                    OcxTimeCht_PPIDModify1.SetSignalOnOff("1040", SignalOnOff(&H1040))
                End If


            Case eEQGUIIndex.IDX_3RD_35GX_ERASE
                If Me.OcxTimeCht_GxErase1.TabIdx = 0 Then
                    OcxTimeCht_GxErase1.SetSignalOnOff("43", SignalOnOff(&H43))
                    OcxTimeCht_GxErase1.SetSignalOnOff("343", SignalOnOff(&H343))
                ElseIf Me.OcxTimeCht_GxErase1.TabIdx = 1 Then
                    OcxTimeCht_GxErase1.SetSignalOnOff("C3", SignalOnOff(&HC3))
                    OcxTimeCht_GxErase1.SetSignalOnOff("743", SignalOnOff(&H743))
                ElseIf Me.OcxTimeCht_GxErase1.TabIdx = 2 Then
                    OcxTimeCht_GxErase1.SetSignalOnOff("143", SignalOnOff(&H143))
                    OcxTimeCht_GxErase1.SetSignalOnOff("1043", SignalOnOff(&H1043))
                End If

            Case eEQGUIIndex.IDX_3RD_36RECIPE_CHK
                If Me.OcxTimeCht_PPIDChk1.TabIdx = 0 Then
                    OcxTimeCht_PPIDChk1.SetSignalOnOff("45", SignalOnOff(&H45))
                    OcxTimeCht_PPIDChk1.SetSignalOnOff("345", SignalOnOff(&H345))
                ElseIf Me.OcxTimeCht_PPIDChk1.TabIdx = 1 Then
                    OcxTimeCht_PPIDChk1.SetSignalOnOff("C5", SignalOnOff(&HC5))
                    OcxTimeCht_PPIDChk1.SetSignalOnOff("745", SignalOnOff(&H745))
                ElseIf Me.OcxTimeCht_PPIDChk1.TabIdx = 2 Then
                    OcxTimeCht_PPIDChk1.SetSignalOnOff("145", SignalOnOff(&H145))
                    OcxTimeCht_PPIDChk1.SetSignalOnOff("1045", SignalOnOff(&H1045))
                End If
        End Select
    End Sub

    Private Sub tabGeneral_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabGeneral.SelectedIndexChanged
        GeneralGUI(tabGeneral.SelectedIndex)
    End Sub

    Private Sub tabEq_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabEq.SelectedIndexChanged
        EQGUI(tabEq.SelectedIndex)
    End Sub

    Private Sub tabTimeCht_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTimeCht.SelectedIndexChanged
        TimeChtGUI(tabTimeCht.SelectedIndex)
    End Sub

    Private Sub OcxSignal1_PortTabChange(ByVal nPort As Integer) Handles OcxSignal1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxStatus1_PortTabChange(ByVal nPort As Integer) Handles OcxStatus1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxTimeCht_GxErase1_PortTabChange(ByVal nPort As Integer) Handles OcxTimeCht_GxErase1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxTimeCht_GxExchange1_PortTabChange(ByVal nPort As Integer) Handles OcxTimeCht_GxExchange1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxTimeCht_GxLoad1_PortTabChange(ByVal nPort As Integer) Handles OcxTimeCht_GxLoad1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxTimeCht_GxUnload1_PortTabChange(ByVal nPort As Integer) Handles OcxTimeCht_GxUnload1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxTimeCht_Link1_PortTabChange(ByVal nPort As Integer) Handles OcxTimeCht_Link1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxTimeCht_PPIDChk1_PortTabChange(ByVal nPort As Integer) Handles OcxTimeCht_PPIDChk1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxTimeCht_PPIDModify1_PortTabChange(ByVal nPort As Integer) Handles OcxTimeCht_PPIDModify1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxGxErase1_PortTabChange(ByVal nPort As Integer) Handles OcxGxErase1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxGxExchange1_PortTabChange(ByVal nPort As Integer) Handles OcxGxExchange1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxGxLoad1_PortTabChange(ByVal nPort As Integer) Handles OcxGxLoad1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxGxUnload1_PortTabChange(ByVal nPort As Integer) Handles OcxGxUnload1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxLinkState1_PortTabChange(ByVal nPort As Integer) Handles OcxLinkState1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxPPIDChk1_PortTabChange(ByVal nPort As Integer) Handles OcxPPIDChk1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub OcxPPIDModify1_PortTabChange(ByVal nPort As Integer) Handles OcxPPIDModify1.PortTabChange
        GUISignalCTL()
    End Sub

    Private Sub ConvertRSTSignal(ByVal strSignalID As String)
        Dim lngSignalID As Long
        lngSignalID = "&H" & strSignalID

        EQGUIWriteSignalOnOff(lngSignalID)
        RaiseEvent ENGSignalChange(lngSignalID)
    End Sub

    Private Sub OcxGxErase1_RSTSignalClick(ByVal strSignalID As String) Handles OcxGxErase1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxGxExchange1_RSTSignalClick(ByVal strSignalID As String) Handles OcxGxExchange1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxGxLoad1_RSTSignalClick(ByVal strSignalID As String) Handles OcxGxLoad1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxGxUnload1_RSTSignalClick(ByVal strSignalID As String) Handles OcxGxUnload1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxLinkState1_RSTSignalClick(ByVal strSignalID As String) Handles OcxLinkState1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxPPIDChk1_RSTSignalClick(ByVal strSignalID As String) Handles OcxPPIDChk1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxPPIDModify1_RSTSignalClick(ByVal strSignalID As String) Handles OcxPPIDModify1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxSignal1_RSTSignalClick(ByVal strSignalID As String) Handles OcxSignal1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub OcxStatus1_RSTSignalClick(ByVal strSignalID As String) Handles OcxStatus1.RSTSignalClick
        ConvertRSTSignal(strSignalID)
    End Sub

    Private Sub tabEQAlarmInfo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabEQAlarmInfo.SelectedIndexChanged
        GUISignalCTL()
    End Sub


    Private Sub MyTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTimer.Tick
        GUISignalCTL()

        OcxStatus1.ShowGUIEQStatus()
        OcxGxLoad1.ShowGUIEQGxLoad()
        OcxGxUnload1.ShowGUIEQGxUnload()
        OcxGxExchange1.ShowGUIEQGxExChange()
        OcxPPIDModify1.ShowGUIEQRecipeModify()
        OcxGxErase1.ShowGUIEQGlassErase()
        OcxPPIDChk1.ShowGUIEQRecipeCheck()
    End Sub

    Private Sub MyCheckTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyCheckTimer.Tick
        If g_fMyEQGUITimerStart Then
            MyTimer.Enabled = True
        Else
            MyTimer.Enabled = False
        End If
    End Sub
End Class
