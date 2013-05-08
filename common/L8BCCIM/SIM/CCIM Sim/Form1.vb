
Public Class Form1
    Dim WithEvents MyIniLog As New RainbowTech.clsLogParameter
    Dim WithEvents MyLog As New RainbowTech.clsLogFactory

    Dim MyCCIM As New prjCCIM.clsCCIM
    Dim WithEvents MyCCIMX As prjCCIM.clsCCIM




    Dim MyPortInfo() As prjSECS.clsPortStructure
    Dim MyUnitInfo() As prjSECS.clsUnitStructure
    Dim MyLotInfo(4) As prjSECS.clsLotStructure



    Private Sub frmSim_Load1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
    End Sub

    Public Sub New()
        Me.CheckForIllegalCrossThreadCalls = False
        ' This call is required by the Windows Form Designer.
        MyCCIMX = MyCCIM

        'MyIniLog.StartAutoSaveLog(GenerateLogFile)

        MyIniLog.AutoClear = True
        MyIniLog.Max = 3000
        MyIniLog.AutoCreateLogFile = True
        MyIniLog.LogVisible = True

        MyLog.InitLogObj("MAIN")

        InitializeComponent()


    End Sub


    Private Function GenerateLogFile() As String
        Dim strLogFile As String
        Dim nYear As Integer
        Dim nMonth As Integer
        Dim nDay As Integer
        Dim nHour As Integer
        Dim nMinute As Integer
        Dim nSecond As Integer

10:     On Error GoTo GenerateLogFile_Error

20:     nYear = Microsoft.VisualBasic.DateAndTime.Year(Now)
30:     nMonth = Microsoft.VisualBasic.DateAndTime.Month(Now)
40:     nDay = Microsoft.VisualBasic.DateAndTime.Day(Now)
50:     nHour = Microsoft.VisualBasic.DateAndTime.Hour(Now)
60:     nMinute = Microsoft.VisualBasic.DateAndTime.Minute(Now)
70:     nSecond = Microsoft.VisualBasic.DateAndTime.Second(Now)

80:     strLogFile = "D:\LOG\" & CStr(nYear) & Microsoft.VisualBasic.Right("0" & CStr(nMonth), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nDay), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nHour), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nMinute), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nSecond), 2) & ".log"

        GenerateLogFile = strLogFile
        'On Error GoTo 0
100:    Exit Function

GenerateLogFile_Error:
        '110:    Globwritelog(Type_ProcessErr, "Code Err " & Err.Number & "/" & Err.Source & " (" & Err.Description & ") at Line " & Erl & " in procedure GenerateLogFile of Form frmMain")

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        MyCCIM.OpenPort()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MyCCIM.S1F73CassetteArrived(CInt(Me.txtPortNo.Text))
        MyCCIM.S1F73CassetteArrived(CInt(Me.txtPortNo.Text) + 1)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MyUnitInfo(1).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
        MyCCIM.S1F65UnitInfoChanged(MyUnitInfo(1))

        MyCCIM.S1F1GetOnLine(prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyCCIM.ShowSECSSim()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MyCCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
    End Sub

    Private Sub cmdMappingComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMappingComp.Click
        Dim nFor As Integer
        Dim nSlot(49) As Integer

        For nFor = 0 To 49
            nSlot(nFor) = 1
        Next
        MyCCIM.S7F71MappingCompleted(CInt(Me.txtPortNo.Text), nSlot)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        MyCCIM.S7F65CassetteDataConfirm(Me.txtPortNo.Text, 0)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MyCCIM.S2F22ReplyRemoteCommand(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        MyPortInfo(Me.txtPortNo.Text).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_WAITSTART
        MyPortInfo(Me.txtPortNo.Text).WithCassette = True

        MyCCIM.PortInfoChanged(MyPortInfo(Me.txtPortNo.Text))

        MyCCIM.S1F67CassetteStatusChanged(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        MyPortInfo(Me.txtPortNo.Text).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_PROCESSING
        MyPortInfo(Me.txtPortNo.Text).WithCassette = True

        MyCCIM.PortInfoChanged(MyPortInfo(Me.txtPortNo.Text))
        MyCCIM.S1F67CassetteStatusChanged(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        MyUnitInfo(Me.txtPortNo.Text).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING
        MyUnitInfo(Me.txtPortNo.Text).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
        MyUnitInfo(Me.txtPortNo.Text).UnitNo = Me.txtPortNo.Text

        MyCCIM.S1F65UnitInfoChanged(MyUnitInfo(Me.txtPortNo.Text))

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim AA(2) As prjSECS.clsGxReport
        AA(1) = New prjSECS.clsGxReport
        AA(2) = New prjSECS.clsGxReport

        AA(1).ProcessStartTime = "1"
        AA(1).ProcessEndTime = "2"
        AA(1).ToolID = "Tool1"
        AA(1).PPID = "001"
        AA(1).GxID = "Gx0001"

        AA(2).ProcessStartTime = "3"
        AA(2).ProcessEndTime = "4"
        AA(2).ToolID = "Tool2"
        AA(2).PPID = "002"
        AA(2).GxID = "Gx0002"

        MyCCIM.S6F91SlotProcessComplete(AA)

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        MyPortInfo(Me.txtPortNo.Text).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_END
        MyPortInfo(Me.txtPortNo.Text).WithCassette = True

        'MyCCIM.PortInfoChanged(MyPortInfo(Me.txtPortNo.Text))
        MyCCIM.CassetteProcessEnd(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_END)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        MyUnitInfo(Me.txtPortNo.Text).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_IDLE
        MyCCIM.S1F65UnitInfoChanged(MyUnitInfo(Me.txtPortNo.Text))
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        MyCCIM.S1F75CassetteUnclamped(Me.txtPortNo.Text)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        MyCCIM.S1F75CassetteRemoved(Me.txtPortNo.Text)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        MyCCIM.CassetteProcessEnd(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eProcessENDCode.EMPT_EMPTY)
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim MyAlarm As New prjCCIM.clsMyAlarmStructure
        Dim MyAlarmS As New prjSECS.clsAlarmStructure
        Dim GxInfo(5) As Object

        MyAlarmS.AlarmFlag = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR
        MyAlarmS.AlarmID = CInt(txtAlarmID.Text)
        MyAlarmS.AlarmText = "Alarm-" & CStr(txtAlarmID.Text)
        MyAlarmS.AlarmType = prjSECS.clsEnumCtl.eAlarmType.TYPE_ALARM
        MyAlarmS.DateTimeInfo = Format(Now, "yyyMMddHHmmss")

        MyAlarm.MyAlarmStructrue = MyAlarmS
        GxInfo(0) = "Gx001"
        GxInfo(1) = "Gx002"
        GxInfo(2) = "Gx003"
        GxInfo(3) = "Gx004"
        GxInfo(4) = "Gx005"
        GxInfo(5) = "Gx006"
        MyAlarm.GlassAffect = GxInfo
        MyAlarm.DateTimeInfo = Format(Now, "yyyMMddHHmmss")
        MyAlarm.WithGx =True 
        MyAlarm.MyUnitNo = 0
        MyCCIM.S5F65ReportAlarm(MyAlarm, MyUnitInfo(0))
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Static nFor As Integer
        nFor = nFor + 1
        If nFor > 50 Then nFor = 1

        MyCCIM.RemoveSlotFromPort(Me.txtPortNo.Text, nFor)
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim MySlot As New prjSECS.clsSlotStructure
        Static nSlotNo As Integer = 1
        MySlot.SlotNo = nSlotNo
        MySlot.GlassID = "AAAAAA"
        MySlot.ProcessToolID = "ttttt"
        MyCCIM.InsertSlotToPort(1, MySlot, True)
        nSlotNo = nSlotNo + 1

    End Sub

    Private Sub MyCCIMX_CassetteDataDownloaded(ByVal LotInfo As prjSECS.clsLotStructure) Handles MyCCIMX.S7F65CassetteDataDownloaded
        MyLotInfo(LotInfo.PortPosition) = LotInfo
    End Sub

    Private Sub MyCCIMX_ConversationTimeoutOccur(ByVal nPortPos As Integer, ByVal nStream As Integer, ByVal nFunction As Integer) Handles MyCCIMX.S9F13ConversationTimeoutOccur

        With Me.TextBox1
            .Text = .Text & vbCrLf & "S" & nStream & "F" & nFunction & "Timeout"
        End With
    End Sub

    Private Sub MyCCIMX_S1F90OnLineComplete() Handles MyCCIMX.S1F90OnLineComplete
        Dim nFor As Integer
        For nFor = 1 To MyCCIM.MaxPorts
            MyPortInfo(Me.txtPortNo.Text).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY

            'MyCCIM.PortInfoChanged(MyPortInfo(nFor))
            'MyCCIM.S1F73CSTLoadReq(nFor)
        Next
    End Sub

    Private Sub MyCCIMX_HSMSConnectChanged(ByVal fConnect As Boolean) Handles MyCCIMX.HSMSConnectChanged
        Me.Label1.Text = "Connect=" & fConnect
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MyCCIM.HOSTIP = "192.168.1.1"

        'Dim nTemp As Integer
        Dim nFor As Integer

        MyCCIM.MaxEQ = 2
        MyCCIM.MaxPorts = 2
        MyCCIM.IniCIMFilePath = "D:\AUO\L8BCCIM\hsms.ini"

        MyCCIM.LineType = prjCCIM.clsCCIM.eLineType.LTYPE_FIMACRO
        ReDim MyPortInfo(MyCCIM.MaxPorts)
        ReDim MyUnitInfo(MyCCIM.MaxEQ)

        For nFor = 1 To MyCCIM.MaxPorts
            MyLotInfo(nFor) = New prjSECS.clsLotStructure
            MyPortInfo(nFor) = New prjSECS.clsPortStructure

            If nFor Mod 2 = 0 Then
                MyPortInfo(nFor).AGVMode = True
                MyPortInfo(nFor).CassetteID = ""
                MyPortInfo(nFor).PortPosition = nFor
                MyPortInfo(nFor).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY
                MyPortInfo(nFor).PortType = prjSECS.clsEnumCtl.ePortType.TYPE_U
                MyPortInfo(nFor).WithCassette = False
                MyPortInfo(nFor).PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_UNLOADER
            Else
                MyPortInfo(nFor).AGVMode = True
                MyPortInfo(nFor).CassetteID = ""
                MyPortInfo(nFor).PortPosition = nFor
                MyPortInfo(nFor).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY
                MyPortInfo(nFor).PortType = prjSECS.clsEnumCtl.ePortType.TYPE_I
                MyPortInfo(nFor).WithCassette = False
                MyPortInfo(nFor).PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_LOADER
            End If
        Next

        For nFor = 0 To MyCCIM.MaxEQ
            MyUnitInfo(nFor) = New prjSECS.clsUnitStructure
            MyUnitInfo(nFor).ToolID = "Tool" & nFor
            MyUnitInfo(nFor).UnitNo = nFor
            MyUnitInfo(nFor).WIPCount = 0
            MyUnitInfo(nFor).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
            MyUnitInfo(nFor).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
            MyUnitInfo(nFor).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_IDLE
        Next

        MyCCIM.InitPortInfo(MyPortInfo)
        MyCCIM.InitUnitInfo(MyUnitInfo)

        For nFor = 1 To MyCCIM.MaxPorts
            MyCCIM.PortInfoChanged(MyPortInfo(nFor))
        Next
    End Sub


    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        MyCCIM.ShowHSMSSetting()
    End Sub


    Private Sub cmdOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOffline.Click
        MyCCIM.S1F1GetOnLine(prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE)
    End Sub

    Private Sub cmdShowHSMSSettin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowHSMSSettin.Click
        MyCCIM.ShowHSMSSetting()
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        MyCCIM.S7F68ReplyPPIDModifyLasTime("001", 0, "20080202121212")
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Dim MyRecipePar As New prjSECS.clsRecipeStructure
        MyRecipePar.AckCode = prjSECS.clsEnumCtl.eACKC7ReplyCMD.CMD_ACCEPTED
        MyRecipePar.RecipeName = "001"
        MyRecipePar.TotalParmeter = 4
        MyRecipePar.ParmeterName(1) = "ParA"
        MyRecipePar.ParmeterValue(1) = "1"
        MyRecipePar.ParmeterName(2) = "ParB"
        MyRecipePar.ParmeterValue(2) = "2"
        MyRecipePar.ParmeterName(3) = "ParC"
        MyRecipePar.ParmeterValue(3) = "3"
        MyRecipePar.ParmeterName(4) = "ParD"
        MyRecipePar.ParmeterValue(4) = "4"

        MyCCIM.S7F4ReportRecipeParameter(MyRecipePar)

    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        MyCCIM.SimEDS()
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Dim i As Integer
        Dim j As Integer = 1
        Dim MyWip(2) As prjSECS.clsWIPDataInTool
        Dim MyWIPItem(50) As prjSECS.clsWIPStructure

        Dim strToolID As String = ""
        MyWip(1) = New prjSECS.clsWIPDataInTool
        MyWip(2) = New prjSECS.clsWIPDataInTool
        MyWip(1).ToolID = "ToolA"
        MyWip(2).ToolID = "ToolB"
        For i = 1 To 50



            If i = 25 Then
                j = 2
            End If


            MyWip(j).AddWIPInfo("aa", "bb", prjSECS.clsEnumCtl.eGlassGrade.OK, prjSECS.clsEnumCtl.eDMQCGrade.OK)
            MyWip(j).ToolWithGx = True
        Next


        MyCCIM.S1F88ReplyWIPData(MyWip)
    End Sub

    Private Sub SimOnLimeComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimOnLimeComp.Click
        MyCCIM.CIMStepOnLineComp(prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL)
    End Sub

    Private Sub Sim765_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sim765.Click
        Dim nFor As Integer
        Dim nSlotLoop As Integer

        Dim MyLotInforT(2) As prjSECS.clsLotStructure
        Dim MyPortInforT(2) As prjSECS.clsPortStructure
        Dim MyUnit(2) As prjSECS.clsUnitStructure

        MyUnit(0) = New prjSECS.clsUnitStructure
        MyUnit(0).UnitNo = 0
        MyUnit(0).WIPCount = 50
        MyUnit(0).ToolID = "EQ" & nFor
        MyUnit(0).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
        MyUnit(0).ProcessMode = prjSECS.clsEnumCtl.ePorcessMode.MODE_NORMAL
        MyUnit(0).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
        MyUnit(0).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING
        MyUnit(0).CPPID = "123"

        MyCCIM.CIMStepFillUnitInfo(MyUnit(0))

        For nFor = 1 To 2
            MyLotInforT(nFor) = New prjSECS.clsLotStructure
            MyPortInforT(nFor) = New prjSECS.clsPortStructure
            MyUnit(nFor) = New prjSECS.clsUnitStructure


            MyPortInforT(nFor).AGVMode = True
            MyPortInforT(nFor).CassetteID = "CST00" & nFor
            MyPortInforT(nFor).CPPID = "123"
            MyPortInforT(nFor).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_OK
            MyPortInforT(nFor).PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_LDULD
            MyPortInforT(nFor).PortPosition = nFor
            MyPortInforT(nFor).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_PROCESSING
            MyPortInforT(nFor).PortType = prjSECS.clsEnumCtl.ePortType.TYPE_U
            MyPortInforT(nFor).PortPosition = nFor
            MyPortInforT(nFor).WithCassette = True


            MyCCIM.CIMStepFillPortInfo(MyPortInforT(nFor))

            MyUnit(nFor).UnitNo = nFor
            MyUnit(nFor).WIPCount = 50
            MyUnit(nFor).ToolID = "EQ" & nFor
            MyUnit(nFor).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
            MyUnit(nFor).ProcessMode = prjSECS.clsEnumCtl.ePorcessMode.MODE_NORMAL
            MyUnit(nFor).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
            MyUnit(nFor).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING
            MyUnit(nFor).CPPID = "123"
            MyCCIM.CIMStepFillUnitInfo(MyUnit(nFor))



            MyLotInforT(nFor).CassetteID = "CST00" & nFor
            MyLotInforT(nFor).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS
            MyLotInforT(nFor).MeasurementID = ""
            MyLotInforT(nFor).OperationID = ""
            MyLotInforT(nFor).OperatorID = ""
            MyLotInforT(nFor).PortPosition = nFor
            MyLotInforT(nFor).ProductCode = "00000" & nFor
            MyLotInforT(nFor).RecipeCode = "00" & nFor
            MyLotInforT(nFor).RecipeName = "00" & nFor
            For nSlotLoop = 1 To 50
                MyLotInforT(nFor).Slots(nSlotLoop).SlotNo = nSlotLoop
                MyLotInforT(nFor).Slots(nSlotLoop).ChipGradeByString = "OOOOOOOOOOOOOOOOO"
                MyLotInforT(nFor).Slots(nSlotLoop).DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.OK
                MyLotInforT(nFor).Slots(nSlotLoop).DMQCToolID = "AA"
                MyLotInforT(nFor).Slots(nSlotLoop).DMQCToolIDDownload = "TOOLD"
                MyLotInforT(nFor).Slots(nSlotLoop).FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                MyLotInforT(nFor).Slots(nSlotLoop).FIRemark = False
                MyLotInforT(nFor).Slots(nSlotLoop).GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.OK
                MyLotInforT(nFor).Slots(nSlotLoop).GlassGradeDownload = prjSECS.clsEnumCtl.eGlassGrade.OK
                MyLotInforT(nFor).Slots(nSlotLoop).GlassID = "GX" & nSlotLoop
                MyLotInforT(nFor).Slots(nSlotLoop).IsGlassProecssed = False
                MyLotInforT(nFor).Slots(nSlotLoop).LastLineID = "LTOOLID"
                MyLotInforT(nFor).Slots(nSlotLoop).LastOperationID = "LOPID"
                MyLotInforT(nFor).Slots(nSlotLoop).LastPorcessToolID = "LPTID"
                MyLotInforT(nFor).Slots(nSlotLoop).PLineID = "LL"
                MyLotInforT(nFor).Slots(nSlotLoop).ProcessToolID = "TTT"
                MyLotInforT(nFor).Slots(nSlotLoop).ProcFlag = True
                MyLotInforT(nFor).Slots(nSlotLoop).PSHGroup = "AA"
                MyLotInforT(nFor).Slots(nSlotLoop).Rework = False
                MyLotInforT(nFor).Slots(nSlotLoop).Scrap = prjSECS.clsEnumCtl.eScrapType.YES
            Next
            MyCCIM.S7F65FillLot(MyLotInforT(nFor))
        Next

    End Sub

    Private Sub SimStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimStep.Click
         
    End Sub

    Private Sub cmdS1F1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS1F1.Click
        MyUnitInfo(1).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
        MyCCIM.S1F65UnitInfoChanged(MyUnitInfo(1))

        MyCCIM.S1F1GetOnLine(prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL)
    End Sub

    Private Sub cmdS2F17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS2F17.Click
        MyCCIM.S2F17RequestDateAnadTime()
    End Sub

    Private Sub cmdS1F89_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS1F89.Click
        MyCCIM.S1F89SummaryStatusReport()
    End Sub

    Private Sub cmdS1F73CSTLoadReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS1F73CSTLoadReq.Click
        Dim nFor As Integer
        For nFor = 1 To MyCCIM.MaxPorts
            MyCCIM.S1F73CSTLoadReq(nFor)
        Next
    End Sub

    Private Sub cmdS1F75LUComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS1F75LUComp.Click

    End Sub

    Private Sub cmdS1F73LoadComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyCCIM.S1F73CassetteArrived(Me.txtPortNo.Text)

    End Sub

    Private Sub cmdS7F71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS7F71.Click
        Dim nFor As Integer
        Dim nSlot(49) As Integer

        For nFor = 0 To 49
            nSlot(nFor) = 1
        Next
        MyCCIM.S7F71MappingCompleted(CInt(Me.txtPortNo.Text), nSlot)
    End Sub

    Private Sub cmdS7F65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS7F65.Click
        MyCCIM.S7F65CassetteDataConfirm(Me.txtPortNo.Text, 0)
    End Sub

    Private Sub cmdS2F22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS2F22.Click
        MyCCIM.S2F22ReplyRemoteCommand(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        MyPortInfo(Me.txtPortNo.Text).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_WAITSTART
        MyPortInfo(Me.txtPortNo.Text).WithCassette = True

        MyCCIM.PortInfoChanged(MyPortInfo(Me.txtPortNo.Text))
        MyCCIM.S1F67CassetteStatusChanged(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT)
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        MyPortInfo(Me.txtPortNo.Text).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_PROCESSING
        MyPortInfo(Me.txtPortNo.Text).WithCassette = True

        MyCCIM.PortInfoChanged(MyPortInfo(Me.txtPortNo.Text))
        MyCCIM.S1F67CassetteStatusChanged(Me.txtPortNo.Text, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS)
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        MyUnitInfo(Me.txtPortNo.Text).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING
        MyUnitInfo(Me.txtPortNo.Text).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
        MyUnitInfo(Me.txtPortNo.Text).UnitNo = Me.txtPortNo.Text

        MyCCIM.S1F65UnitInfoChanged(MyUnitInfo(Me.txtPortNo.Text))
    End Sub

    Private Sub cmdS6F91_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS6F91.Click
        Dim AA(2) As prjSECS.clsGxReport
        AA(1) = New prjSECS.clsGxReport
        AA(2) = New prjSECS.clsGxReport

        AA(1).ProcessStartTime = "1"
        AA(1).ProcessEndTime = "2"
        AA(1).ToolID = "Tool1"
        AA(1).PPID = "001"
        AA(1).GxID = "Gx0001"

        AA(2).ProcessStartTime = "3"
        AA(2).ProcessEndTime = "4"
        AA(2).ToolID = "Tool2"
        AA(2).PPID = "002"
        AA(2).GxID = "Gx0002"

        MyCCIM.S6F91SlotProcessComplete(AA)
    End Sub
End Class
