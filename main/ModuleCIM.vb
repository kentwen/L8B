Imports prjSECS.clsEnumCtl

Module ModuleCIM


    Public MainCIM As New clsCIMMain

    Public Sub InitCIM()

        Dim nFor As Integer

        With MainCIM

            .L8BCIM.IniCIMFilePath = _L8B.Setting.ExtraIniFile.CIM
            .L8BCIM.MaxEQ = _L8B.Setting.Main.NumberEQ
            .L8BCIM.MaxPorts = _L8B.Setting.Main.NumberPort
            .L8BCIM.LineID = _L8B.Setting.ID.Line
            .L8BCIM.LoaderToolID = _L8B.Setting.ID.RST

            If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.FI Then
                .L8BCIM.LineType = prjCCIM.clsCCIM.eLineType.LTYPE_FIMACRO
            Else
                .L8BCIM.LineType = prjCCIM.clsCCIM.eLineType.LTYPE_NONE
            End If
            ReDim .PortInfo(.L8BCIM.MaxPorts)
            ReDim .PortInfoExtra(.L8BCIM.MaxPorts)
            ReDim .LotInfo(.L8BCIM.MaxPorts)
            ReDim .UnitInfo(clsCIMMain.SECSUNIT.EQ1 + _L8B.Setting.Main.NumberEQ - 1)

            For nFor = 1 To .L8BCIM.MaxPorts
                .LotInfo(nFor) = New prjSECS.clsLotStructure
                .PortInfo(nFor) = New prjSECS.clsPortStructure
                .PortInfoExtra(nFor) = New clsCIMMain.clsPortInfoExtra

                If nFor Mod 2 = 0 Then
                    .PortInfo(nFor).AGVMode = True
                    .PortInfo(nFor).CassetteID = ""
                    .PortInfo(nFor).PortPosition = nFor
                    .PortInfo(nFor).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY
                    .PortInfo(nFor).PortType = prjSECS.clsEnumCtl.ePortType.TYPE_U
                    .PortInfo(nFor).WithCassette = False
                    .PortInfo(nFor).PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_UNLOADER
                Else
                    .PortInfo(nFor).AGVMode = True
                    .PortInfo(nFor).CassetteID = ""
                    .PortInfo(nFor).PortPosition = nFor
                    .PortInfo(nFor).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_EMPTY
                    .PortInfo(nFor).PortType = prjSECS.clsEnumCtl.ePortType.TYPE_I
                    .PortInfo(nFor).WithCassette = False
                    .PortInfo(nFor).PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_LOADER
                End If
            Next

            For nFor = 0 To clsCIMMain.SECSUNIT.EQ1 + _L8B.Setting.Main.NumberEQ - 1
                .UnitInfo(nFor) = New prjSECS.clsUnitStructure
                .UnitInfo(nFor).UnitNo = nFor
                .UnitInfo(nFor).WIPCount = 0
                .UnitInfo(nFor).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
                .UnitInfo(nFor).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
                .UnitInfo(nFor).EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_IDLE
            Next
            .UnitInfo(clsCIMMain.SECSUNIT.EQ1).ToolID = _L8B.Setting.ID.EQ1
            .UnitInfo(clsCIMMain.SECSUNIT.EQ2).ToolID = _L8B.Setting.ID.EQ2
            .UnitInfo(clsCIMMain.SECSUNIT.CV).ToolID = _L8B.Setting.ID.CV
            .UnitInfo(clsCIMMain.SECSUNIT.RST).ToolID = _L8B.Setting.ID.RST
            .UnitInfo(0).ToolID = _L8B.Setting.ID.RST

            .UnitInfo(clsCIMMain.SECSUNIT.EQ1).UnitNo = clsCIMMain.SECSUNIT.EQ1
            .UnitInfo(clsCIMMain.SECSUNIT.EQ2).UnitNo = clsCIMMain.SECSUNIT.EQ2
            .UnitInfo(clsCIMMain.SECSUNIT.CV).UnitNo = clsCIMMain.SECSUNIT.CV
            .UnitInfo(clsCIMMain.SECSUNIT.RST).UnitNo = clsCIMMain.SECSUNIT.RST
            .UnitInfo(0).UnitNo = 0

            If _L8B.Setting.Main.NumberEQ >= 3 Then
                .UnitInfo(clsCIMMain.SECSUNIT.EQ3).ToolID = _L8B.Setting.ID.EQ3
                .UnitInfo(clsCIMMain.SECSUNIT.EQ3).UnitNo = clsCIMMain.SECSUNIT.EQ3
            End If

            .L8BCIM.InitPortInfo(.PortInfo)
            .L8BCIM.InitUnitInfo(.UnitInfo)

            For nFor = 1 To .L8BCIM.MaxPorts
                .L8BCIM.PortInfoChanged(.PortInfo(nFor))
            Next
            'wait PLC initial finish. 2010.11.01
            '.L8BCIM.OpenPort()
        End With
        _L8B.CIM = MainCIM

    End Sub

    Public Class clsCIMMain
        Public WithEvents L8BCIM As New prjCCIM.clsCCIM

        Public Class clsPortInfoExtra
            Public CassetteInMode As prjSECS.clsEnumCtl.eRemoteStatus
            Public PortSuspend As Boolean
        End Class

        Public PortInfo() As prjSECS.clsPortStructure
        Public PortInfoExtra() As clsPortInfoExtra
        Public UnitInfo() As prjSECS.clsUnitStructure
        Public LotInfo() As prjSECS.clsLotStructure

        Public RemoteMode As prjSECS.clsEnumCtl.eRemoteStatus
        Private mTCPIPConnect As Boolean

        Public Enum SECSUNIT
            NONE = -1
            ALL = 0
            RST = 1
            CV
            EQ1
            EQ2
            EQ3
        End Enum

        Private Enum eOnlineSequence
            NONE = 0
            S1F1
            S1F2
            S2F17
            S2F18
            S1F89
            S1F90
            S1F73
            S1F74
            S1F65
            S1F66
        End Enum

        Private Structure StepType
            Public Online As eOnlineSequence
            Public tRemoteMode As prjSECS.clsEnumCtl.eRemoteStatus
        End Structure

        Private SequenceStep As StepType
        Private Online_FirstTime As Boolean

        Public ReadOnly Property TCPIPConnect() As Boolean
            Get
                Return mTCPIPConnect
            End Get
        End Property

#Region "CCIM Event"

        Private Sub L8BCIM_EQStatusReply(ByVal nAckCode As Integer) Handles L8BCIM.EQStatusReply  'S1F66
            WriteLog("S1F66(EQStatusReply) " & nAckCode)
        End Sub

        Private Sub L8BCIM_HOSTOnLineReply() Handles L8BCIM.HOSTOnLineReply  'S1F2
            If SequenceStep.Online = eOnlineSequence.S1F1 Then
                WriteLog("Online Sequence:Receive S1F2", LogMessageType.Warn)
                SequenceStep.Online = eOnlineSequence.S2F17
                L8BCIM.S2F17RequestDateAnadTime()
            Else
                WriteLog("[Ignore] Online Sequence", LogMessageType.Warn)
            End If
        End Sub

        Private Sub L8BCIM_HOSTOnLineRequest() Handles L8BCIM.HOSTOnLineRequest 'S1F1
            L8BCIM.S1F2OnLineReply("Model No of EQ", DateVersion)
        End Sub

        Private Sub L8BCIM_HOSTReplyCode(ByVal nReplySF As prjSECS.clsEnumCtl.eSECSStatusReplyType, ByVal nCode As Integer) Handles L8BCIM.HOSTReplyCode
            Select Case nReplySF
                Case eSECSStatusReplyType.T_S1F66
                    If SequenceStep.Online = eOnlineSequence.S1F65 Then
                        SequenceStep.Online = eOnlineSequence.NONE
                        'Changeto Offline
                        RemoteMode = eRemoteStatus.MODE_OFFLINE
                    End If
                Case eSECSStatusReplyType.T_S1F74
                Case eSECSStatusReplyType.T_S1F76
                Case eSECSStatusReplyType.T_S1F90
                Case eSECSStatusReplyType.T_S1F98
                Case eSECSStatusReplyType.T_S5F66

                Case eSECSStatusReplyType.T_S6F66
                Case eSECSStatusReplyType.T_S6F70
                Case eSECSStatusReplyType.T_S6F86
                Case eSECSStatusReplyType.T_S6F88
                Case eSECSStatusReplyType.T_S6F92
                Case eSECSStatusReplyType.T_S7F72
            End Select
        End Sub

        Private Sub L8BCIM_HSMSConnectChanged(ByVal fConnect As Boolean) Handles L8BCIM.HSMSConnectChanged
            WriteLog("HSMSConnectChanged ->" & fConnect, LogMessageType.Info)
            mTCPIPConnect = fConnect
            _L8B.frmMain.RstguiStatusTowerHSMS.Connect = fConnect

            If fConnect Then
                _L8B.Alarm.ReportAlarm()
            End If
        End Sub

        Private Sub L8BCIM_OffLineComplete(ByVal nAckCode As Integer) Handles L8BCIM.OffLineComplete
            WriteLog("OffLineComplete AckCode ->" & nAckCode, LogMessageType.Info)
            If RemoteMode <> eRemoteStatus.MODE_OFFLINE Then
                WriteLog("[ERROR] OffLineComplete reject. AckCode ->" & nAckCode, LogMessageType.Info)
                UnitInfo(mInfo.Robot.UnitID).RemoteStatus = RemoteMode
                UnitInfoChange(mInfo.Robot.UnitID)
                Return
            End If
            If nAckCode = 0 Then
                'offline ok"
                RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
            Else
                'offline failure 'still offline
                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "offline failure(ACK code<>0); still offline", MsgBoxStyle.OkOnly, 10, MsgBoxResult.Ok, True)
                RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
            End If
            UpdateRemoteStatus()
            UnitInfo(mInfo.Robot.UnitID).RemoteStatus = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE
            UnitInfoChange(mInfo.Robot.UnitID)
            _L8B.PLC.RemoteModeChange()
        End Sub

        Private Sub L8BCIM_S10F5TerminalRequest(ByVal nTerminalID As prjSECS.clsEnumCtl.eTerminalID, ByVal fBuzzer As Boolean, ByVal strText As String) Handles L8BCIM.S10F5TerminalRequest
            Try
                _L8B.db.InsertHostMessageHistory("RX", strText, nTerminalID)
                _L8B.frmMain.TextBoxSendHostMessage.Clear()
                _L8B.frmMain.UpdateListViewHostMessage()
                If nTerminalID = prjSECS.clsEnumCtl.eTerminalID.TID_WARNING Then
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Host Send:" & vbCrLf & strText, MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, fBuzzer)
                Else
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Host Send:" & vbCrLf & strText, MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, fBuzzer)
                End If
            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
            End Try
        End Sub

        Private Sub L8BCIM_S1F66UnitStatusReply(ByVal nAckCode As Integer) Handles L8BCIM.S1F66UnitStatusReply
            If SequenceStep.Online = eOnlineSequence.S1F65 Then
                SequenceStep.Online = eOnlineSequence.NONE
                'Changeto Offline
                RemoteMode = eRemoteStatus.MODE_OFFLINE
            End If
            UpdateRemoteStatus()

        End Sub

        Private Sub L8BCIM_S1F68CSTStatusReply(ByVal nPortPos As Integer, ByVal nReturnCode As Integer, ByVal strNGGlassID As String) Handles L8BCIM.S1F68CSTStatusReply
            WriteLog(String.Format("CSTStatusReply Port= {0} ReturnCode = {1}", nPortPos, nReturnCode), LogMessageType.Info)

        End Sub

        Private Sub L8BCIM_S1F74LoadCompleted(ByVal nPortPos As Integer) Handles L8BCIM.S1F74LoadCompleted
            SequenceStep.Online = eOnlineSequence.NONE
        End Sub

        Private Sub L8BCIM_S1F74LoadRequestStart(ByVal nPortPos As Integer) Handles L8BCIM.S1F74LoadRequestStart
            WriteLog("[MCIM] S1F74LoadRequestStart Port=" & nPortPos, LogMessageType.Info)
            _L8B.frmMain.UpdateCVPortGUI(nPortPos)
        End Sub

        Private Sub L8BCIM_S1F76UnloadCompleted(ByVal nPortPos As Integer) Handles L8BCIM.S1F76UnloadCompleted
            SequenceStep.Online = eOnlineSequence.NONE
        End Sub

        Private Sub L8BCIM_S1F76UnloadRequestStart(ByVal nPortPos As Integer) Handles L8BCIM.S1F76UnloadRequestStart
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            WriteLog("[MCIM] S1F76UnloadRequestStart Port=" & nPortPos, LogMessageType.Info)
            'mInfo.Port(nPortPos).PortFAStatus = ePortFAStatus.UnloadRequest
            _L8B.frmMain.UpdateCVPortGUI(nPortPos)
        End Sub

        Private Sub L8BCIM_S1F87WIPRequest() Handles L8BCIM.S1F87WIPRequest
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            WriteLog("[MCIM] WIPRequest", LogMessageType.Info)
            Try
                Dim WIPData() As prjSECS.clsWIPDataInTool

                Dim CountTool As Integer = 0
                With mInfo.Robot
                    Dim bCountBuffer As Boolean = False
                    For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                        For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                            If mInfo.Buffer(i).Glass(j).GlassID.Length > 0 And mInfo.Buffer(i).fGlassExist(j) Then
                                CountTool += 1
                                bCountBuffer = True
                                Exit For
                            End If
                        Next
                        If bCountBuffer Then
                            Exit For
                        End If
                    Next
                End With

                For i As Integer = 1 To _L8B.Setting.Main.NumberEQ
                    With mInfo.EQ(i)
                        If .Glass.GlassID.Length > 0 Then
                            CountTool += 1
                        End If

                    End With
                Next

                Dim CountCv As Boolean

                With mInfo.CV
                    For j = 1 To _L8B.Setting.Main.NumberPort    'mMain .Setting .Main .NumberCV 
                        For k As Integer = 1 To 3

                            If mInfo.Port(j).GlassFlowCV(k).GlassID.Length > 0 Then
                                CountTool += 1
                                CountCv = True
                                Exit For
                            End If
                        Next

                    Next

                End With

                If Not CountCv Then
                    For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                        If Not CountCv Then
                            With mInfo.Port(i)
                                For j As Integer = 1 To MAXCASSETTESLOT
                                    If .Glass(j).GlassID.Length > 0 And .fGlassExist(j) Then
                                        CountTool += 1
                                        CountCv = True
                                        Exit For
                                    End If
                                Next
                            End With
                        End If
                    Next
                End If


                If CountTool > 0 Then
                    '' insert 
                    ReDim WIPData(CountTool)
                    Dim index As Integer = 1

                    With mInfo.Robot

                        WIPData(index) = New prjSECS.clsWIPDataInTool
                        WIPData(index).ToolID = mInfo.Robot.ToolID
                        WIPData(index).ToolWithGx = True
                        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                            For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                                If mInfo.Buffer(i).Glass(j).GlassID.Length > 0 Then
                                    Select Case _L8B.Setting.Main.MachineType
                                        Case ClsSetting.EMACHINETYPE.FI, ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                            WIPData(index).AddWIPInfo(mInfo.Buffer(i).Glass(j).GlassID, mInfo.Buffer(i).Glass(j).GlassID, mInfo.Buffer(i).Glass(j).GGRADE, prjSECS.clsEnumCtl.eGlassGrade.NO)
                                        Case Else
                                            WIPData(index).AddWIPInfo(mInfo.Buffer(i).Glass(j).GlassID, mInfo.Buffer(i).Glass(j).GlassID, prjSECS.clsEnumCtl.eGlassGrade.NO, mInfo.Buffer(i).Glass(j).DGRADE)
                                    End Select


                                End If
                            Next
                        Next

                        If .Glass(1).GlassID.Length > 0 Then
                            Select Case _L8B.Setting.Main.MachineType
                                Case ClsSetting.EMACHINETYPE.FI, ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                    WIPData(index).AddWIPInfo(.Glass(1).GlassID, .Glass(1).GlassID, .Glass(1).GGRADE, prjSECS.clsEnumCtl.eGlassGrade.NO)
                                Case Else
                                    WIPData(index).AddWIPInfo(.Glass(1).GlassID, .Glass(1).GlassID, prjSECS.clsEnumCtl.eGlassGrade.NO, .Glass(1).DGRADE)
                            End Select
                        End If

                        If .Glass(2).GlassID.Length > 0 Then
                            Select Case _L8B.Setting.Main.MachineType
                                Case ClsSetting.EMACHINETYPE.FI, ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                    WIPData(index).AddWIPInfo(.Glass(2).GlassID, .Glass(2).GlassID, .Glass(2).GGRADE, prjSECS.clsEnumCtl.eGlassGrade.NO)
                                Case Else
                                    WIPData(index).AddWIPInfo(.Glass(2).GlassID, .Glass(2).GlassID, prjSECS.clsEnumCtl.eGlassGrade.NO, .Glass(2).DGRADE)
                            End Select
                        End If


                        Dim bCountBuffer As Boolean = False
                        For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                            For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                                If mInfo.Buffer(i).Glass(j).GlassID.Length > 0 Then
                                    bCountBuffer = True
                                    index += 1
                                    Exit For
                                End If
                            Next
                            If bCountBuffer Then
                                Exit For
                            End If
                        Next
                        If Not bCountBuffer And (.Glass(1).GlassID.Length > 0 OrElse .Glass(2).GlassID.Length > 0) Then
                            index += 1
                        End If


                    End With


                    For i As Integer = 1 To _L8B.Setting.Main.NumberEQ
                        With mInfo.EQ(i)
                            If .Glass.GlassID.Length > 0 Then
                                WIPData(index) = New prjSECS.clsWIPDataInTool
                                WIPData(index).ToolID = mInfo.EQ(i).ToolID
                                WIPData(index).ToolWithGx = True
                                Select Case _L8B.Setting.Main.MachineType
                                    Case ClsSetting.EMACHINETYPE.FI, ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                        WIPData(index).AddWIPInfo(.Glass.GlassID, .Glass.GlassID, .Glass.GGRADE, prjSECS.clsEnumCtl.eGlassGrade.NO)

                                    Case Else
                                        WIPData(index).AddWIPInfo(.Glass.GlassID, .Glass.GlassID, prjSECS.clsEnumCtl.eGlassGrade.NO, .Glass.DGRADE)
                                End Select

                                index += 1
                            End If

                        End With
                    Next

                    If CountCv Then
                        With mInfo.CV
                            WIPData(index) = New prjSECS.clsWIPDataInTool
                            WIPData(index).ToolID = mInfo.CV.ToolID
                            WIPData(index).ToolWithGx = True
                            For j = 1 To _L8B.Setting.Main.NumberPort    'mMain .Setting .Main .NumberCV 
                                For k As Integer = 1 To 3
                                    If mInfo.Port(j).GlassFlowCV(j).GlassID.Length > 0 Then

                                        Select Case _L8B.Setting.Main.MachineType
                                            Case ClsSetting.EMACHINETYPE.FI, ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                                WIPData(index).AddWIPInfo(mInfo.Port(j).GlassFlowCV(j).GlassID, mInfo.Port(j).GlassFlowCV(j).GlassID, mInfo.Port(j).GlassFlowCV(j).GGRADE, prjSECS.clsEnumCtl.eGlassGrade.NO)
                                            Case Else
                                                WIPData(index).AddWIPInfo(mInfo.Port(j).GlassFlowCV(j).GlassID, mInfo.Port(j).GlassFlowCV(j).GlassID, prjSECS.clsEnumCtl.eGlassGrade.NO, mInfo.Port(j).GlassFlowCV(j).DGRADE)
                                        End Select

                                    End If

                                Next
                            Next
                        End With

                        For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                            With mInfo.Port(i)
                                For j As Integer = 1 To MAXCASSETTESLOT
                                    If .Glass(j).GlassID.Length > 0 And .fGlassExist(j) Then
                                        Select Case _L8B.Setting.Main.MachineType
                                            Case ClsSetting.EMACHINETYPE.FI, ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                                WIPData(index).AddWIPInfo(.Glass(j).GlassID, .Glass(j).GlassID, .Glass(j).GGRADE, prjSECS.clsEnumCtl.eGlassGrade.NO)
                                            Case Else
                                                WIPData(index).AddWIPInfo(.Glass(j).GlassID, .Glass(j).GlassID, prjSECS.clsEnumCtl.eGlassGrade.NO, .Glass(j).DGRADE)
                                        End Select
                                    End If
                                Next
                            End With
                        Next
                    End If
                Else
                    ReDim WIPData(1)
                    WIPData(1) = New prjSECS.clsWIPDataInTool
                    WIPData(1).ToolID = mInfo.Robot.ToolID
                    WIPData(1).ToolWithGx = False
                End If

                L8BCIM.S1F88ReplyWIPData(WIPData)
            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try
        End Sub

        Private Sub L8BCIM_S1F90OnLineComplete(ByVal nOnLineMode As Integer) Handles L8BCIM.S1F90OnLineComplete
            If nOnLineMode = -1 Then
                'online failure"
                If RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL OrElse RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Secs - Change Remote Failure", MsgBoxStyle.OkOnly, 10, MsgBoxResult.Ok, True)
                Else
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Secs - Online Failure; still offline", MsgBoxStyle.OkOnly, 10, MsgBoxResult.Ok, True)
                End If
                UpdateRemoteStatus()
                Return
            Else
                If RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                    SequenceStep.Online = eOnlineSequence.NONE
                    If nOnLineMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then
                        RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
                    ElseIf nOnLineMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                        RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
                    End If

                    For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                        Select Case _L8B.PLC.CVPortStatus(i)
                            Case L8BIFPRJ.clsPLC.eCSTCmdStatus.LOAD_COMP
                                If mInfo.Port(i).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING Then
                                    _L8B.CIM.CassetteStatusChange(i, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS, True)
                                ElseIf mInfo.Port(i).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.WAIT_PROCESS Then
                                    _L8B.CIM.CassetteStatusChange(i, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT, True)
                                End If

                            Case L8BIFPRJ.clsPLC.eCSTCmdStatus.UNLOAD_REQ
                                'PortInfoChanged(i)

                            Case L8BIFPRJ.clsPLC.eCSTCmdStatus.LOAD_REQ
                                CassetteLoadRequest(i)

                            Case L8BIFPRJ.clsPLC.eCSTCmdStatus.UNLOAD_COMP
                                CassetteUnloadRequest(i)
                        End Select
                    Next

                End If

            End If
            UnitInfo(mInfo.Robot.UnitID).RemoteStatus = RemoteMode
            UnitInfoChange(mInfo.Robot.UnitID)
            UpdateRemoteStatus()
            _L8B.PLC.RemoteModeChange()

            _L8B.Alarm.ReportAlarm()
        End Sub

        Private Sub L8BCIM_S2F18SyncDateTime(ByVal dtDateTime As String) Handles L8BCIM.S2F18SyncDateTime
            Dim cimDate As Date
            Dim myDate As Date = GetDate(dtDateTime)

            cimDate = Left(dtDateTime, 4) & "/" & Mid(dtDateTime, 5, 2) & "/" & Mid(dtDateTime, 7, 2) & " " & Mid(dtDateTime, 9, 2) & ":" & Mid(dtDateTime, 11, 2) & ":" & Mid(dtDateTime, 13, 2)

            DateString = Format(myDate, "yyyy/MM/dd")
            TimeString = Format(myDate, "HH:mm:ss")

            _L8B.PLC.SyncTime(cimDate)

            If SequenceStep.Online = eOnlineSequence.S2F17 Then
                SequenceStep.Online = eOnlineSequence.S2F18
                L8BCIM.S1F89SummaryStatusReport()
                SequenceStep.Online = eOnlineSequence.S1F89
            End If
        End Sub


        Public Function GetDate(ByVal strDateTime As String) As Date
            Dim myDate As Date

            strDateTime = MyTrim(strDateTime)
            If strDateTime.Length = 14 Then
                myDate = String.Format("{0}/{1}/{2} {3}:{4}:{5}", _
                                       CInt(Left(strDateTime, 4)), CInt(Mid(strDateTime, 5, 2)), _
                                       CInt(Mid(strDateTime, 7, 2)), CInt(Mid(strDateTime, 9, 2)), _
                                       CInt(Mid(strDateTime, 11, 2)), CInt(Right(strDateTime, 2)))
            Else
                myDate = "1999/12/31 23:59:00"
            End If

            Return myDate
        End Function

        Private Sub L8BCIM_S2F21RemoteCommand(ByVal nPortPos As Integer, ByVal strCommand As String, ByVal strCIMMsg As String) Handles L8BCIM.S2F21RemoteCommand
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If

            If nPortPos <= 0 OrElse nPortPos > _L8B.Setting.Main.NumberPort Then
                L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CMD_NO_DEFINE)
                _L8B.CIM.SendHostMessage("S2F21 PortPos<=0 incorrect.")
                Return
            End If

            Try
                SyncLock _L8B.frmCloseQueue
                    _L8B.frmCloseQueue.Enqueue(_L8B.dlg765Timeout(nPortPos))
                End SyncLock

                _L8B.PLC.Buzzer(clsMainPLC.eBuzzerMode.OFF)

                Const CMD_START = "$START"
                Const CMD_CANCEL = "$CANCEL"
                Const CMD_SUSPND = "$SUSPND"
                Const CMD_RESUME = "$RESUME"


                Select Case strCommand
                    Case CMD_START
                        If mInfo.Port(nPortPos).Status = PORTSTATUS.READYTOSTART Then
                            'cassette status -> process wait
                            If PortInfoExtra(nPortPos).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                                If LotInfo(nPortPos).RecipeNeedConfirm Then
                                    L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CANT_EXECUTE)
                                Else
                                    L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                                    SetPortStatus(nPortPos, PORTSTATUS.PROCESSWAIT)
                                End If
                            ElseIf PortInfoExtra(nPortPos).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then
                                L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                                SetPortStatus(nPortPos, PORTSTATUS.PROCESSWAIT)
                            End If
                        Else
                            WriteLog("Cassette Status not match for accept S2F21 [$Start]", LogMessageType.Warn)
                            L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_OTHER)
                        End If


                    Case CMD_CANCEL
                        ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Host Send [$Cancel], port=" & nPortPos & " Cassette cancel" & vbCrLf & "CIM Msg: [" & strCIMMsg & "]" & vbCrLf & "請 CALL CIM 值班 8665-4230.", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, False)
                        L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                        'SetPortStatus(nPortPos, PORTSTATUS.UNLOADREQUEST)
                        'cancel cassette
                        _L8B.PLC.CassetteUnloadRequest(nPortPos)
                        If mInfo.Port(nPortPos).SuspendMessage IsNot Nothing Then
                            SyncLock _L8B.frmHideQueue
                                _L8B.frmHideQueue.Enqueue(_L8B.dlgRecipeComfirm(nPortPos))
                                _L8B.frmHideQueue.Enqueue(_L8B.dlgRecipeComfirmWGS(nPortPos))
                                _L8B.frmHideQueue.Enqueue(_L8B.dlgCassetteInfo(nPortPos))

                            End SyncLock
                            Try
                                _L8B.dlg765Timeout(nPortPos).Close()
                                mInfo.Port(nPortPos).SuspendMessage.Close()
                            Catch ex As Exception
                            End Try
                        End If

                    Case CMD_SUSPND
                        _L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                        mInfo.Port(nPortPos).SuspendMessage = New DialogMessage
                        mInfo.Port(nPortPos).SuspendMessage.ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Port:" & nPortPos & " Host Send S2F21 [$SUSPND], CassetteID hold." & vbCrLf & "CIM Msg: " & strCIMMsg, MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPortPos)

                    Case CMD_RESUME
                        'SyncLock _L8B.frmCloseQueue
                        '    _L8B.frmCloseQueue.Enqueue(mInfo.Port(nPortPos).SuspendMessage)
                        'End SyncLock
                        mInfo.Port(nPortPos).SuspendMessage.Close()
                        L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                    Case Else
                        L8BCIM.S2F22ReplyRemoteCommand(nPortPos, prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CMD_NO_DEFINE)
                End Select

            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try

        End Sub

        Private Sub L8BCIM_S2F25LoopBackResult(ByVal fResult As Boolean) Handles L8BCIM.S2F25LoopBackResult
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            WriteLog("LoopBackResult " & fResult, LogMessageType.Info)
            LoopBackResult(fResult)
        End Sub

        Private Sub L8BCIM_S2F41EQRemoteCommand(ByVal strToolID As String, ByVal strCSTID As String, ByVal strCMD As String, ByVal strSaveFlag As String, ByVal strMSG As String) Handles L8BCIM.S2F41EQRemoteCommand
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            WriteLog("[MCIM] EQRemoteCommand ToolID=" & strToolID & " CMD=" & strCMD, LogMessageType.Info)
            Dim nPort As Integer = 0
            For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                If MyTrim(LotInfo(i).CassetteID) = strCSTID Then
                    nPort = i
                    Exit For
                End If
            Next

            If nPort = 0 Then
                L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CANT_EXECUTE)
                Exit Sub
            End If

            Select Case MyTrim(strCMD)
                Case "ABORT"
                    If mInfo.Port(nPort).Status = PORTSTATUS.PROCESSING Then
                        L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                        mInfo.Port(nPort).fPause = False
                        AbortProcess(nPort)
                    ElseIf mInfo.Port(nPort).Status = PORTSTATUS.PROCESSWAIT Then
                        L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                        mInfo.Port(nPort).fPause = False
                        CancelCassette(nPort)
                    Else
                        L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CANT_EXECUTE)
                    End If
                Case "HOLD"
                    If Not mInfo.Port(nPort).fPause Then 'mInfo.Port(nPort).Status = PORTSTATUS.PROCESSING AndAlso 
                        L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                        mInfo.Port(nPort).fPause = True
                        _L8B.PLC.PortPause(nPort)
                        PortInfoExtra(nPort).PortSuspend = True
                    Else
                        L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CANT_EXECUTE)
                    End If
                Case "RELEASE"
                    If mInfo.Port(nPort).fPause Then
                        L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_ACCEPTED)
                        mInfo.Port(nPort).fPause = False
                        _L8B.PLC.PortRelease(nPort)
                    Else
                        L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CANT_EXECUTE)
                    End If

                Case Else
                    L8BCIM.S2F42ReplyEQRemoteCMD(prjSECS.clsEnumCtl.eRemoteReplyCMD.CMD_CMD_NO_DEFINE)
            End Select
        End Sub

        Private Sub L8BCIM_S7F4RSTRecipeParameterQuery(ByVal strLineID As String, ByVal strToolID As String, ByVal strPPID As String) Handles L8BCIM.S7F4RSTRecipeParameterQuery
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            Dim RecipeParameterReply As New prjSECS.clsRecipeStructure
            Dim mRecipe As cRecipe = _L8B.db.LoadRecipe(MyTrim(strPPID))

            With RecipeParameterReply
                .AckCode = eACKC7ReplyCMD.CMD_ACCEPTED
                .RecipeName = strPPID
                .TotalParmeter = 5
                .ParmeterName(1) = "ver"
                .ParmeterValue(1) = mRecipe.Version

                .ParmeterName(2) = "EQ1PPID"
                .ParmeterValue(2) = mRecipe.EQPPID(1)
                .ParmeterName(3) = "EQ2PPID"
                .ParmeterValue(3) = mRecipe.EQPPID(2)
                .ParmeterName(4) = "RobotSpeed"
                .ParmeterValue(4) = mRecipe.RobotSpeed.ToString
                .ParmeterName(5) = "Remark"
                .ParmeterValue(5) = mRecipe.Remark
            End With

            L8BCIM.S7F4ReportRecipeParameter(RecipeParameterReply)
        End Sub

        Private Sub L8BCIM_S7F65CassetteDataDownloaded(ByVal vLotInfo As prjSECS.clsLotStructure) Handles L8BCIM.S7F65CassetteDataDownloaded
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            WriteLog("[MCIM] CassetteDataDownloaded CassetteID=" & vLotInfo.CassetteID, LogMessageType.Info)
            Try
                Dim nPort As Integer = vLotInfo.PortPosition
                Dim ReplyCode As Integer = 0

                If nPort <= 0 OrElse nPort > _L8B.Setting.Main.NumberPort Then
                    L8BCIM.S7F65CassetteDataConfirm(nPort, 20)
                    _L8B.CIM.SendHostMessage("S7F65 PortPos incorrect")
                    Return
                End If

                CopyLotInfo(nPort, vLotInfo)
                LotInfo(nPort).IsLotDataReceived = True
                _L8B.frmMain.UpdateCVPortGUI(nPort)
                PortInfoExtra(nPort).CassetteInMode = RemoteMode
                _L8B.Setting.SaveLotDataDownload(nPort, True)

                Dim CountGGRAD_NO As Integer = 0

                Select Case _L8B.Setting.Main.GlassFlowMode
                    Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                        If ReplyCode = 0 Then
                            Select Case LotInfo(nPort).ReturnCode
                                Case "0040302"
                                    WriteLog("Empty cassette under [I mode], cancel cassette; CassetteID=[" & vLotInfo.CassetteID & "]", LogMessageType.Info)
                                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Empty cassette under [I mode], cancel cassette", MsgBoxStyle.OkOnly)
                                    ReplyCode = 6
                                Case Else
                            End Select
                        End If
                        ' If _L8b.CIM.re

                        If ReplyCode = 0 Then
                            For i As Integer = 1 To MAXCASSETTESLOT
                                If LotInfo(nPort).Slots(i).GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO AndAlso MyTrim(LotInfo(nPort).Slots(i).GlassID).Length > 0 Then
                                    WriteLog("Port#" & nPort & " Slot=" & i & " GlassID= " & LotInfo(nPort).Slots(i).GlassID & " GGrad =" & LotInfo(nPort).Slots(i).GlassGrade.ToString & ")", LogMessageType.ERR)
                                    CountGGRAD_NO += 1
                                End If
                            Next
                            If CountGGRAD_NO > 0 Then
                                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Port#" & nPort & " CassetteID=" & LotInfo(nPort).CassetteID & " GGrad [NO] count >0 (=" & CountGGRAD_NO & ")" & vbCrLf & " Cassette Cancel", MsgBoxStyle.OkOnly)
                                ReplyCode = &H21
                                _L8B.CIM.SendHostMessage("S7F66 Reply=&H21, Process Data GGRADE found ['(space)': No Glass or no data]")
                            End If
                        End If

                        If ReplyCode = 0 Then
                            'Check PPID Exist, And Also Check EQ recipe ok or not
                            If _L8B.db.CheckRecipe(MyTrim(LotInfo(nPort).RecipeName)) Then
                                mInfo.Port(nPort).Recipe = _L8B.db.LoadRecipe(MyTrim(LotInfo(nPort).RecipeName))
                                If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.ButterFly Then
                                    If _L8B.Setting.Main.EQRecipeCheck(1) Then
                                        If Not _L8B.db.CheckEQRecipe(1, mInfo.Port(nPort).Recipe.EQPPID(1)) Then
                                            If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ1(" & _L8B.Setting.ID.EQ1 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                            ReplyCode = 4 'PPID not define
                                        End If
                                    End If
                                    If _L8B.Setting.Main.EQRecipeCheck(2) Then
                                        If Not _L8B.db.CheckEQRecipe(2, mInfo.Port(nPort).Recipe.EQPPID(2)) And ReplyCode = 0 Then
                                            If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ2(" & _L8B.Setting.ID.EQ2 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                            ReplyCode = 4 'PPID not define
                                        End If
                                    End If
                                Else
                                    For i As Integer = 1 To _L8B.Setting.Main.NumberEQ
                                        If _L8B.Setting.Main.EQRecipeCheck(i) Then
                                            If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.DIFFERENT Then
                                                If Not _L8B.db.CheckEQRecipe(i, mInfo.Port(nPort).Recipe.EQPPID(i)) And ReplyCode = 0 Then
                                                    If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ" & i & "(" & _L8B.Setting.ID.RST & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                    ReplyCode = 4 'PPID not define
                                                    Exit For
                                                End If
                                            Else
                                                If Not _L8B.db.CheckEQRecipe(i, mInfo.Port(nPort).Recipe.EQPPID) And ReplyCode = 0 Then
                                                    If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ" & i & "(" & _L8B.Setting.ID.RST & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                    ReplyCode = 4 'PPID not define
                                                    Exit For
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Else
                                If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                ReplyCode = 4 'PPID not define
                            End If
                        End If

                        If ReplyCode = 4 Then
                            WriteLog("Recipe doesnot exist {" & LotInfo(nPort).RecipeName & "}", LogMessageType.Info)
                            If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                                Dim GoodRecipe As String
                                If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.SAME Then
                                    GoodRecipe = _L8B.db.FirstOKSameEQRecipe(_L8B.Setting.Main.NumberEQ)
                                Else
                                    GoodRecipe = _L8B.db.FirstOKDiffEQRecipe()
                                End If
                                If LotInfo(nPort).RecipeName <> "" Then
                                    WriteLog("New recipe had been assigned for Port " & nPort & " PPID=" & LotInfo(nPort).RecipeName & " at [Monitor Mode]", LogMessageType.Info)
                                    LotInfo(nPort).RecipeName = GoodRecipe
                                    ReplyCode = 0
                                End If
                            End If
                        End If


                        ''Check Mpping data
                        If ReplyCode = 0 Then
                            If InsertPortGlassData(nPort) <> mInfo.Port(nPort).GlassCount Then
                                ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: map unmatch Glass number error", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                ReplyCode = 6 'map unmatch
                            End If
                        End If
                        If ReplyCode = 0 Then
                            For i As Integer = 1 To MAXCASSETTESLOT
                                With LotInfo(nPort).Slots(i)
                                    If .SlotNo > 0 Then
                                        If MyTrim(.GlassID) = "" And mInfo.Port(nPort).Map(.SlotNo) = 1 Then
                                            ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: map unmatch " & .SlotNo, MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                            ReplyCode = 6 'map unmatch
                                            Exit For
                                        ElseIf MyTrim(.GlassID) <> "" And mInfo.Port(nPort).Map(.SlotNo) = 0 Then
                                            ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: map unmatch " & .SlotNo, MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                            ReplyCode = 6 'map unmatch
                                            Exit For
                                        End If
                                    End If
                                End With
                            Next
                        End If

                        If ReplyCode = 0 Then
                            ''check MQC buffer limit
                            Dim BufferLimit As Integer = GetFreeBufferSlotForPort(nPort)
                            WriteLog("Buffer Limit for Port" & nPort & "=" & BufferLimit)
                            If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I And ReplyCode = 0 Then  'MQC mode                        
                                If mInfo.Port(nPort).Recipe.SampleGlass > BufferLimit And mInfo.Port(nPort).GlassCount > BufferLimit Then
                                    ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: sample slot out of buffer limit for MQC(I) mode", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                    ReplyCode = &H19 'MQC: sample slot out of buffer limit
                                Else
                                    If mInfo.Port(nPort).Recipe.SampleGlass > mInfo.Port(nPort).GlassCount Then
                                        WriteLog(String.Format("Port{0} Recipe:{1} SampleGlass={2} > Port{0} GlassCount={3}, set SampleGlass={3}", nPort, mInfo.Port(nPort).Recipe.PPID, mInfo.Port(nPort).Recipe.SampleGlass, mInfo.Port(nPort).GlassCount))
                                        mInfo.Port(nPort).Recipe.SampleGlass = mInfo.Port(nPort).GlassCount
                                    End If
                                End If
                            End If
                        End If

                        WriteLog("LotDataDownload Check : Replycode = " & ReplyCode, LogMessageType.Info)
                        If ReplyCode = 0 Then
                            UpdateProcessFlag(nPort)
                            If _L8B.CIM.PortInfoExtra(nPort).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then
                                _L8B.PLC.UploadLotData(nPort)
                            ElseIf _L8B.CIM.PortInfoExtra(nPort).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                                WriteLog("LotDataCheck OK, in [Online-Manual] wait recipe comfirm.", LogMessageType.Info)
                                SetPortStatus(nPort, PORTSTATUS.READYTOSTART)
                                _L8B.CIM.LotInfo(nPort).RecipeNeedConfirm = True
                                _L8BCIM.S7F65CassetteDataConfirm(nPort, 0)
                                Select Case _L8B.Setting.Main.MachineType
                                    Case ClsSetting.EMACHINETYPE.REPAIR
                                        _L8B.dlgRecipeComfirm(nPort).ShowMe(nPort)
                                    Case Else
                                        _L8B.dlgRecipeComfirmWGS(nPort).ShowMe(nPort)
                                End Select
                            End If
                        Else    'reply code <> 0
                            L8BCIM.S7F65CassetteDataConfirm(LotInfo(nPort).PortPosition, ReplyCode)
                            WriteLog("LotDataCheck Failure, Cassette cancel", LogMessageType.Info)
                            _L8B.PLC.CassetteUnloadRequest(nPort)
                        End If

                    Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                        Select Case _L8B.PLC.CVPortMode(nPort)
                            Case L8BIFPRJ.clsPLC.ePortMode.LOAD
                                If ReplyCode = 0 Then
                                    Select Case vLotInfo.ReturnCode
                                        Case "0040302"
                                            WriteLog("Empty cassette for Loader Mode, cancel cassette(" & nPort & ")", LogMessageType.Info)
                                            ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Empty cassette under [I mode], cancel cassette", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                            ReplyCode = 6
                                        Case Else
                                    End Select
                                End If

                                If ReplyCode = 0 Then
                                    For i As Integer = 1 To MAXCASSETTESLOT
                                        If LotInfo(nPort).Slots(i).GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO AndAlso MyTrim(LotInfo(nPort).Slots(i).GlassID).Length > 0 Then
                                            WriteLog("Port#" & nPort & " Slot=" & i & " GlassID= " & LotInfo(nPort).Slots(i).GlassID & " GGrad =" & LotInfo(nPort).Slots(i).GlassGrade.ToString & ")", LogMessageType.ERR)
                                            CountGGRAD_NO += 1
                                        End If
                                    Next
                                    If CountGGRAD_NO > 0 Then
                                        ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Port#" & nPort & " CassetteID=" & LotInfo(nPort).CassetteID & " GGrad [NO] count >0 (=" & CountGGRAD_NO & ")" & vbCrLf & " Cassette Cancel", MsgBoxStyle.OkOnly)
                                        ReplyCode = &H21
                                        _L8B.CIM.SendHostMessage("S7F66 Reply=&H21, Process Data GGRADE found ['(space)': No Glass or no data]")
                                    End If
                                End If

                                If ReplyCode = 0 Then
                                    'Check PPID Exist, And Also Check EQ recipe ok or not
                                    If _L8B.db.CheckRecipe(MyTrim(LotInfo(nPort).RecipeName)) Then
                                        mInfo.Port(nPort).Recipe = _L8B.db.LoadRecipe(MyTrim(LotInfo(nPort).RecipeName))
                                        If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.DIFFERENT Then
                                            Select Case _L8B.Setting.Main.MachineType
                                                'add for color repair mode (for Ink Repair)
                                                Case ClsSetting.EMACHINETYPE.COLORREPAIR
                                                    If mInfo.Port(nPort).Recipe.ColorRepairMode = L8BIFPRJ.clsPLC.eGlassType.INK And _L8B.Setting.Main.ColorRepairMode = L8BIFPRJ.clsPLC.eColorRepairMode.NORMAL_MODE Then
                                                        WriteLog("Color Repair Mode Error, Cassette cancel Recipe Repair Mode=" & mInfo.Port(nPort).Recipe.ColorRepairMode.ToString & " Current Color-Repair Mode=" & _L8B.Setting.Main.ColorRepairMode.ToString, LogMessageType.Info)
                                                        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Cassette cancel Recipe Repair Mode=(" & mInfo.Port(nPort).Recipe.ColorRepairMode.ToString & ")", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                        ReplyCode = &H16 'Repair Error(need to discuss with AUO for Error Code
                                                    Else
                                                        If _L8B.Setting.Main.ColorRepairMode = L8BIFPRJ.clsPLC.eColorRepairMode.COLOR_MODE Then
                                                            If mInfo.Port(nPort).Recipe.ColorRepairMode = L8BIFPRJ.clsPLC.eGlassType.INK Then
                                                                If _L8B.Setting.Main.EQRecipeCheck(2) Then
                                                                    If Not _L8B.db.CheckEQRecipe(2, mInfo.Port(nPort).Recipe.EQPPID(2)) And ReplyCode = 0 Then
                                                                        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ2(" & _L8B.Setting.ID.EQ2 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                                        ReplyCode = 4 'PPID not define
                                                                    End If
                                                                End If
                                                            Else
                                                                If _L8B.Setting.Main.EQRecipeCheck(1) Then
                                                                    If Not _L8B.db.CheckEQRecipe(1, mInfo.Port(nPort).Recipe.EQPPID(1)) Then
                                                                        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ1(" & _L8B.Setting.ID.EQ1 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                                        ReplyCode = 4 'PPID not define
                                                                    End If
                                                                End If
                                                                If _L8B.Setting.Main.EQRecipeCheck(2) Then
                                                                    If Not _L8B.db.CheckEQRecipe(2, mInfo.Port(nPort).Recipe.EQPPID(2)) And ReplyCode = 0 Then
                                                                        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ2(" & _L8B.Setting.ID.EQ2 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                                        ReplyCode = 4 'PPID not define
                                                                    End If
                                                                End If
                                                            End If
                                                        Else
                                                            If _L8B.Setting.Main.EQRecipeCheck(1) Then
                                                                If Not _L8B.db.CheckEQRecipe(1, mInfo.Port(nPort).Recipe.EQPPID(1)) Then
                                                                    If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ1(" & _L8B.Setting.ID.EQ1 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                                    ReplyCode = 4 'PPID not define
                                                                End If
                                                            End If
                                                            'If _L8B.Setting.Main.EQRecipeCheck(2) Then
                                                            '    If Not _L8B.db.CheckEQRecipe(2, mInfo.Port(nPort).Recipe.EQPPID(2)) And ReplyCode = 0 Then
                                                            '        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ2(" & _L8B.Setting.ID.EQ2 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                            '        ReplyCode = 4 'PPID not define
                                                            '    End If
                                                            'End If
                                                        End If
                                                    End If
                                                Case Else
                                                    If _L8B.Setting.Main.EQRecipeCheck(1) Then
                                                        If Not _L8B.db.CheckEQRecipe(1, mInfo.Port(nPort).Recipe.EQPPID(1)) Then
                                                            If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ1(" & _L8B.Setting.ID.EQ1 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                            ReplyCode = 4 'PPID not define
                                                        End If
                                                    End If
                                                    If _L8B.Setting.Main.EQRecipeCheck(2) Then
                                                        If Not _L8B.db.CheckEQRecipe(2, mInfo.Port(nPort).Recipe.EQPPID(2)) And ReplyCode = 0 Then
                                                            If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ2(" & _L8B.Setting.ID.EQ2 & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                            ReplyCode = 4 'PPID not define
                                                        End If
                                                    End If
                                            End Select


                                        Else
                                            For i As Integer = 1 To _L8B.Setting.Main.NumberEQ
                                                If _L8B.Setting.Main.EQRecipeCheck(i) Then
                                                    If Not _L8B.db.CheckEQRecipe(i, mInfo.Port(nPort).Recipe.EQPPID) And ReplyCode = 0 Then
                                                        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: EQ" & i & "(" & _L8B.Setting.ID.RST & ") PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                        ReplyCode = 4 'PPID not define
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        End If
                                    Else
                                        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: PPID not define", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                        ReplyCode = 4 'PPID not define
                                    End If

                                    If ReplyCode = 4 Then
                                        WriteLog("Recipe doesnot exist {" & LotInfo(nPort).RecipeName & "}", LogMessageType.Info)
                                        If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                                            Dim GoodRecipe As String
                                            If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.SAME Then
                                                GoodRecipe = _L8B.db.FirstOKSameEQRecipe(_L8B.Setting.Main.NumberEQ)
                                            Else
                                                GoodRecipe = _L8B.db.FirstOKDiffEQRecipe()
                                            End If
                                            If LotInfo(nPort).RecipeName <> "" Then
                                                WriteLog("New recipe had been assigned for Port " & nPort & " PPID=" & LotInfo(nPort).RecipeName & " at [Monitor Mode]", LogMessageType.Info)
                                                LotInfo(nPort).RecipeName = GoodRecipe
                                                ReplyCode = 0
                                            End If
                                        End If
                                    End If
                                End If

                                Dim GlassNumber As Integer
                                ''Check Mpping data
                                If ReplyCode = 0 Then
                                    GlassNumber = InsertPortGlassData(nPort)
                                    If GlassNumber <> mInfo.Port(nPort).GlassCount Then
                                        ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: map unmatch Glass number error", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                        ReplyCode = 6 'map unmatch
                                    End If
                                End If
                                If ReplyCode = 0 Then
                                    If ReplyCode = 0 Then
                                        For i As Integer = 1 To MAXCASSETTESLOT
                                            With LotInfo(nPort).Slots(i)
                                                If Len(MyTrim(.GlassID)) = 0 And mInfo.Port(nPort).Map(.SlotNo) = 1 Then
                                                    ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: map unmatch " & .SlotNo, MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                    ReplyCode = 6 'map unmatch
                                                    Exit For
                                                ElseIf Len(MyTrim(.GlassID)) > 0 And mInfo.Port(nPort).Map(.SlotNo) = 0 Then
                                                    ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: map unmatch " & .SlotNo, MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                                    ReplyCode = 6 'map unmatch
                                                    Exit For
                                                ElseIf Len(MyTrim(.GlassID)) > 0 Then
                                                    WriteLog("GlassID( " & nPort & ", " & .SlotNo & ")=" & .GlassID, LogMessageType.Info)
                                                End If
                                            End With
                                        Next
                                    End If
                                End If

                                'for Color Repair in MIX Mode to check LD space is >= total glass number in Cassette
                                If ReplyCode = 0 Then
                                    If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.COLORREPAIR AndAlso _L8B.PLC.ColorRepairMode = L8BIFPRJ.clsPLC.eColorRepairMode.COLOR_MODE AndAlso mInfo.Port(nPort).Recipe.ColorRepairMode = L8BIFPRJ.clsPLC.eGlassType.INK Then
                                        Dim LDBufferSpace As Integer = GetTotalBufferSlotModeNumber(L8BIFPRJ.clsPLC.eBufferStatus.INK, True)
                                        If LDBufferSpace < GlassNumber Then
                                            WriteLog("LD space is not enough for INK.  It need " & GlassNumber & " and only has " & LDBufferSpace, LogMessageType.Warn)
                                            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "[LD] buffer not enough for INK cassette. Please check and reverse [LD] for INK glass. Empty Ink Cassette[Loader] and it will automatic change to [Unloader]", MsgBoxStyle.OkOnly, 30, MsgBoxResult.Ok)
                                        End If
                                    End If
                                End If

                                If ReplyCode = 0 Then
                                    'Check Repair for gray glass
                                    If (_L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.REPAIR OrElse _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.COLORREPAIR) And ReplyCode = 0 Then
                                        Dim CountGrayGlass As Integer = 0
                                        For i As Integer = 1 To MAXCASSETTESLOT
                                            If LotInfo(nPort).Slots(i).GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.GRAY Then
                                                CountGrayGlass += 1
                                            End If
                                        Next
                                        If CountGrayGlass = 0 Then
                                            ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Error, "Lot Downloade failure: no gray glass for Repair", MsgBoxStyle.OkOnly, 0, MsgBoxResult.Ok, True, nPort)
                                            ReplyCode = &H18 'Repair: no gray glass
                                        End If
                                    End If
                                End If

                                WriteLog("DataDownload Check : Replycode = " & ReplyCode, LogMessageType.Info)
                                If ReplyCode = 0 Then
                                    UpdateProcessFlag(nPort)
                                    If _L8B.CIM.PortInfoExtra(nPort).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then
                                        _L8B.PLC.UploadLotData(nPort)
                                    ElseIf _L8B.CIM.PortInfoExtra(nPort).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                                        WriteLog("LotDataCheck OK, in [Online-Manual] wait recipe comfirm.", LogMessageType.Info)
                                        _L8B.CIM.LotInfo(nPort).RecipeNeedConfirm = True
                                        L8BCIM.S7F65CassetteDataConfirm(vLotInfo.PortPosition, ReplyCode)
                                        SetPortStatus(nPort, PORTSTATUS.READYTOSTART)
                                        Select Case _L8B.Setting.Main.MachineType
                                            Case ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                                _L8B.dlgRecipeComfirm(nPort).ShowMe(nPort)
                                            Case Else
                                                _L8B.dlgRecipeComfirmWGS(nPort).ShowMe(nPort)
                                        End Select
                                    End If
                                Else
                                    L8BCIM.S7F65CassetteDataConfirm(vLotInfo.PortPosition, ReplyCode)
                                    WriteLog("LotDataCheck Failure, Cassette cancel", LogMessageType.Info)
                                    _L8B.PLC.CassetteUnloadRequest(nPort)
                                End If

                            Case L8BIFPRJ.clsPLC.ePortMode.UNLOAD
                                ReplyCode = 0
                                Select Case LotInfo(nPort).ReturnCode
                                    Case "0040302"
                                        WriteLog("Empty cassette under UnLoader", LogMessageType.Info)
                                        ReplyCode = 0
                                        LotInfo(nPort).RecipeNeedConfirm = True
                                        _L8B.PLC.UploadLotData(nPort)
                                    Case Else
                                        ReplyCode = 6
                                        L8BCIM.S7F65CassetteDataConfirm(vLotInfo.PortPosition, ReplyCode)
                                        _L8B.PLC.CassetteUnloadRequest(nPort)
                                End Select
                        End Select

                    Case Else
                        WriteLog("CassetteDataDownload PortType Not set Cancel Cassette", LogMessageType.Warn)
                End Select

                SyncLock _L8B.frmCloseQueue
                    _L8B.frmCloseQueue.Enqueue(_L8B.dlg765Timeout(nPort))
                End SyncLock

                _L8B.PLC.Buzzer(clsMainPLC.eBuzzerMode.OFF)
                _L8B.frmMain.UpdateCVPortGUI(nPort)
            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
            End Try
        End Sub

        Private Sub L8BCIM_S7F67RecipeModifyLastTimeQuery(ByVal strPPID As String) Handles L8BCIM.S7F67RecipeModifyLastTimeQuery
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            '0:OK 4:not define
            If _L8B.db.CheckRecipe(MyTrim(strPPID)) Then
                Dim Recipe As cRecipe = _L8B.db.LoadRecipe(MyTrim(strPPID))
                _L8BCIM.S7F68ReplyPPIDModifyLasTime(strPPID, 0, Recipe.Version)
            Else
                _L8BCIM.S7F68ReplyPPIDModifyLasTime(strPPID, 4, "")
            End If
        End Sub

        Private Sub L8BCIM_S7F72ReplyCassetteDataRequest(ByVal nPortPos As Integer, ByVal nGrantCode As Integer) Handles L8BCIM.S7F72ReplyCassetteDataRequest
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            Select Case nGrantCode
                Case 0
                    WriteLog("ReplyCassetteDataRequest GrantCode = 0(Allow Request), Wait S7F65", LogMessageType.Info)

                Case 1
                    WriteLog("ReplyCassetteDataRequest GrantCode = 1(Reject Request)", LogMessageType.Warn)
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "CassetteDataRequest S7F72 reject request.", MsgBoxStyle.OkOnly, 0)
                    _L8B.PLC.CassetteUnloadRequest(nPortPos)
                Case Else
                    WriteLog("ReplyCassetteDataRequest GrantCode >1(reverse)", LogMessageType.Info)
                    _L8B.PLC.CassetteUnloadRequest(nPortPos)
            End Select
        End Sub


        '[Robot AlarmList] above 300 for SECS report
        '301,0,1,S2F21 ConversationTimeoutOccur at Port1,
        '302,0,1,S2F21 ConversationTimeoutOccur at Port2,
        '303,0,1,S2F21 ConversationTimeoutOccur at Port3,
        '304,0,1,S2F21 ConversationTimeoutOccur at Port4,

        '311,0,1,S7F65 ConversationTimeoutOccur at Port1,
        '312,0,1,S7F65 ConversationTimeoutOccur at Port2,
        '313,0,1,S7F65 ConversationTimeoutOccur at Port3,
        '314,0,1,S7F65 ConversationTimeoutOccur at Port4,

        Private Sub L8BCIM_S9F13ConversationTimeoutOccur(ByVal nPortPos As Integer, ByVal nStream As Integer, ByVal nFunction As Integer) Handles L8BCIM.S9F13ConversationTimeoutOccur
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            WriteLog(String.Format("ConversationTimeoutOccur for Port{0} on S{1}F{2}", nPortPos, nStream, nFunction), LogMessageType.ERR)
            '_L8B.PLC.CassetteUnloadRequest(nPortPos)
            _L8B.dlg765Timeout(nPortPos) = New DialogMessage
            _L8B.dlg765Timeout(nPortPos).ShowMessage(DialogMessage.MESSAGE.CancelCassette, DialogMessage.MESSAGELEVEL.Info, "S" & nStream & "F" & nFunction & " T9 time out", MsgBoxStyle.OkCancel, 0, MsgBoxResult.Ok, True, nPortPos)

            Try

                If nStream = 2 AndAlso nFunction = 21 Then
                    _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.Robot, 300 + nPortPos, eAlarmFlag.TYPE_OCCUR)
                    _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.Robot, 300 + nPortPos, eAlarmFlag.TYPE_RELEASE)
                End If

                If nStream = 7 AndAlso nFunction = 65 Then
                    _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.Robot, 310 + nPortPos, eAlarmFlag.TYPE_OCCUR)
                    _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.Robot, 310 + nPortPos, eAlarmFlag.TYPE_RELEASE)
                End If

            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try
        End Sub

#End Region

        Public Sub GetOnline()
            With _L8B.CIM
                .UnitInfo(1).RemoteStatus = eRemoteStatus.MODE_ONLINECONTROL
                .L8BCIM.S1F65UnitInfoChanged(.UnitInfo(1))
                .L8BCIM.S1F1GetOnLine(prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL)
            End With
        End Sub

        Public Sub CassetteProcessEnd(ByVal nPort As Integer, ByVal nEndCode As prjSECS.clsEnumCtl.eProcessENDCode)
            _L8B.CIM.L8BCIM.CassetteProcessEnd(nPort, nEndCode)
        End Sub

        Public Sub PortInfoChanged(ByVal nPort As Integer)
            L8BCIM.PortInfoChanged(PortInfo(nPort))
        End Sub

        Public Sub UnitInfoChange(ByVal nUnit As Integer)
            Try
                If nUnit >= 0 Then
                    WriteLog("UnitInfoChange UnitNo=" & nUnit & " " & UnitInfo(nUnit).EQStatus.ToString)
                    L8BCIM.S1F65UnitInfoChanged(UnitInfo(nUnit))
                Else
                    WriteLog("UnitInfoChange [Fail] no UnitNo <0")
                End If
            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try
        End Sub


        Private Sub CIMOnlineFirstTime()
            For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                If LotInfo(i).IsLotDataReceived Then
                    L8BCIM.CIMStepFillPortInfo(PortInfo(i))
                    L8BCIM.S7F65FillLot(LotInfo(i))
                    For j As Integer = 1 To MAXCASSETTESLOT
                        If mInfo.Port(i).fGlassExist(j) Then
                            _L8B.CIM.InserSlotToPort(i, j)
                        End If
                    Next
                End If
            Next

            For i As Integer = 1 To UnitInfo.GetUpperBound(0)
                L8BCIM.CIMStepFillUnitInfo(UnitInfo(i))
            Next
        End Sub


        Public Function SECSModeChange(ByVal vMode As prjSECS.clsEnumCtl.eRemoteStatus) As Integer
            If vMode <> RemoteMode And RemoteMode <> eRemoteStatus.MODE_OFFLINE Then
                WriteLog("SECDModeChange -> " & vMode.ToString, LogMessageType.METHOD)
                WriteLog("CIM - SECS Mode change request [" & RemoteMode.ToString & "] -> [" & vMode.ToString & "]", LogMessageType.Info)
                UnitInfo(mInfo.Robot.UnitID).RemoteStatus = vMode
                UnitInfo(mInfo.Robot.UnitID).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
                UnitInfoChange(mInfo.Robot.UnitID)
                RemoteMode = vMode
                L8BCIM.S1F89SummaryStatusReport()
                UpdateRemoteStatus()
            Else
                WriteLog("CIM - SECS Mode change ignore for [" & RemoteMode.ToString & "] -> [" & vMode.ToString & "]", LogMessageType.Info)
            End If
        End Function


        Public Sub Online(ByVal vMode As prjSECS.clsEnumCtl.eRemoteStatus, Optional ByVal fReset As Boolean = False)
            WriteLog("Online ->" & vMode.ToString, LogMessageType.METHOD)
            If RemoteMode <> eRemoteStatus.MODE_OFFLINE Then
                SECSModeChange(vMode)
            ElseIf vMode = eRemoteStatus.MODE_OFFLINE Then
                Offline()
            Else

                If Online_FirstTime Then
                    Online_FirstTime = False
                    CIMOnlineFirstTime()
                End If
                'If SequenceStep.Online <> eOnlineSequence.NONE And Not fReset Then
                '    WriteLog("CIM - SECS Online ignore for Onlining:" & SequenceStep.Online.ToString, LogMessageType.Info)
                '    Exit Sub
                'End If
                SequenceStep.Online = eOnlineSequence.S1F1
                SequenceStep.tRemoteMode = vMode

                UnitInfo(mInfo.Robot.UnitID).RemoteStatus = SequenceStep.tRemoteMode
                UnitInfo(mInfo.Robot.UnitID).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
                UnitInfoChange(mInfo.Robot.UnitID)

                L8BCIM.S1F1GetOnLine(SequenceStep.tRemoteMode)

            End If
        End Sub

        Public Sub Offline()
            WriteLog("SECSMode -> Offline", LogMessageType.METHOD)
            UnitInfo(mInfo.Robot.UnitID).RemoteStatus = eRemoteStatus.MODE_OFFLINE
            UnitInfo(mInfo.Robot.UnitID).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
            'UnitInfoChange(mInfo.Robot.UnitID)
            SequenceStep.Online = eOnlineSequence.S1F65
            SequenceStep.tRemoteMode = eRemoteStatus.MODE_OFFLINE
            RemoteMode = eRemoteStatus.MODE_OFFLINE
            L8BCIM.S1F65UnitInfoChanged(UnitInfo(mInfo.Robot.UnitID))
            _L8B.PLC.RemoteModeChange()
            UpdateRemoteStatus()
        End Sub

        Public Sub RecipeComfirm(ByVal nPort As Integer, Optional ByVal newPPID As String = "")
            LotInfo(nPort).RecipeName = newPPID

            PortInfo(nPort).CPPID = LotInfo(nPort).RecipeName
            If MyTrim(LotInfo(nPort).RecipeName).Length > 0 Then
                UnitInfo(0).CPPID = LotInfo(nPort).RecipeName
                _L8B.CIM.UnitInfoChange(0)
                UnitInfo(1).CPPID = LotInfo(nPort).RecipeName
                _L8B.CIM.UnitInfoChange(1)
            End If
            PortInfoChanged(nPort)

            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            _L8BCIM.S2F22MonitorRecipeConfirmed(nPort, newPPID)
        End Sub

        Public Function Alarm(ByVal eUnitIndex As SECSUNIT, ByVal nAlarmListCode As Integer) As Boolean 'if alarm release and has report, return true
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return False
            End If
            Try
                Dim myAlarmInfo As New prjCCIM.clsMyAlarmStructure

                With UnitInfo(eUnitIndex).Alarm
                    .AlarmFlag = _L8B.Alarm.AlarmList(nAlarmListCode).Status
                    .AlarmID = _L8B.Alarm.AlarmList(nAlarmListCode).Code
                    .AlarmText = _L8B.Alarm.AlarmList(nAlarmListCode).Message
                    .AlarmType = _L8B.Alarm.AlarmList(nAlarmListCode).Type
                    UnitInfo(eUnitIndex).EQSubStatus = prjSECS.clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
                End With

                With myAlarmInfo
                    .DateTimeInfo = GetAUODateTime(Now)
                    .MyUnitNo = eUnitIndex
                    ReDim .GlassAffect(0)
                    With .MyAlarmStructrue
                        .AlarmFlag = _L8B.Alarm.AlarmList(nAlarmListCode).Status
                        .AlarmID = _L8B.Alarm.AlarmList(nAlarmListCode).Code
                        .AlarmText = _L8B.Alarm.AlarmList(nAlarmListCode).Message
                        .AlarmType = _L8B.Alarm.AlarmList(nAlarmListCode).Type
                    End With
                    Select Case eUnitIndex
                        Case SECSUNIT.EQ1
                            If mInfo.EQ(1).fGlassExist Then
                                ReDim .GlassAffect(1)
                                .GlassAffect(1) = mInfo.EQ(1).Glass.GlassID
                                .WithGx = True
                            End If

                        Case SECSUNIT.EQ2
                            If mInfo.EQ(2).fGlassExist Then
                                ReDim .GlassAffect(1)
                                .GlassAffect(1) = mInfo.EQ(2).Glass.GlassID
                                .WithGx = True
                            End If

                        Case SECSUNIT.EQ3
                            If mInfo.EQ(3).fGlassExist Then
                                ReDim .GlassAffect(1)
                                .GlassAffect(1) = mInfo.EQ(3).Glass.GlassID
                                .WithGx = True
                            End If

                        Case SECSUNIT.CV
                            'Dim i As Integer
                            'Dim GlassCount As Integer

                            'For i = 1 To _L8B.Setting.Main.NumberPort
                            '    For j = 1 To MAXCASSETTESLOT
                            '        If mInfo.Port(i).fGlassExist(j) Then
                            '            GlassCount += 1
                            '        End If
                            '    Next
                            'Next

                            'For i = 1 To 6
                            '    If MyTrim(mInfo.CV.GlassIDCVSection(i)).Length > 0 Then
                            '        GlassCount += 1
                            '    End If
                            'Next
                            'ReDim .GlassAffect(GlassCount)
                            'Dim Index As Integer = 0
                            'For i = 1 To _L8B.Setting.Main.NumberPort
                            '    For j = 1 To MAXCASSETTESLOT
                            '        If mInfo.Port(i).fGlassExist(j) Then
                            '            .GlassAffect(Index + 1) = mInfo.Port(i).Glass(j).GlassID
                            '            .WithGx = True
                            '            Index += 1
                            '        End If
                            '    Next
                            'Next

                            'For i = 1 To 6
                            '    .GlassAffect(Index + 1) = MyTrim(mInfo.CV.GlassIDCVSection(i))
                            '    .WithGx = True
                            '    Index += 1
                            'Next

                            Dim GlxIDArray As New ArrayList
                            For i = 1 To _L8B.Setting.Main.NumberPort
                                For j = 1 To MAXCASSETTESLOT
                                    If mInfo.Port(i).fGlassExist(j) Then
                                        GlxIDArray.Add(mInfo.Port(i).Glass(j).GlassID)
                                    End If
                                Next
                            Next

                            For i = 1 To 6
                                If MyTrim(mInfo.CV.GlassIDCVSection(i)).Length > 0 Then
                                    GlxIDArray.Add(MyTrim(mInfo.CV.GlassIDCVSection(i)))
                                End If
                            Next

                            If GlxIDArray.Count > 0 Then
                                .WithGx = True
                                ReDim .GlassAffect(GlxIDArray.Count)
                                For i As Integer = 0 To GlxIDArray.Count - 1
                                    .GlassAffect(i + 1) = GlxIDArray(i)
                                Next
                            Else
                                .WithGx = False
                            End If


                        Case SECSUNIT.RST

                            Dim RobotGlXCount As Integer = 0
                            Dim GlxIDArray As New ArrayList
                            If mInfo.Robot.fGlassExist(1) Then
                                .WithGx = True
                                RobotGlXCount += 1
                                GlxIDArray.Add(mInfo.Robot.Glass(1).GlassID)
                            End If

                            If mInfo.Robot.fGlassExist(2) Then
                                .WithGx = True
                                RobotGlXCount += 1
                                GlxIDArray.Add(mInfo.Robot.Glass(2).GlassID)
                            End If

                            For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                                For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                                    If mInfo.Buffer(i).fGlassExist(j) Then
                                        .WithGx = True
                                        RobotGlXCount += 1
                                        GlxIDArray.Add(mInfo.Buffer(i).Glass(j).GlassID)
                                    End If
                                Next
                            Next

                            If RobotGlXCount > 0 Then
                                ReDim .GlassAffect(RobotGlXCount)
                                For i As Integer = 0 To GlxIDArray.Count - 1
                                    .GlassAffect(i + 1) = GlxIDArray(i)
                                Next
                            End If
                    End Select
                End With
                L8BCIM.S5F65ReportAlarm(myAlarmInfo, UnitInfo(eUnitIndex))

                If _L8B.Alarm.AlarmList(nAlarmListCode).Status = eAlarmFlag.TYPE_OCCUR Then
                    _L8B.db.UpdateAlarmReportOccurr(_L8B.Alarm.AlarmList(nAlarmListCode).DBIndex, True)
                    _L8B.Alarm.AlarmList(nAlarmListCode).fReportOccurr = True
                    _L8B.db.UpdateAlarmReportOccurr(_L8B.Alarm.AlarmList(nAlarmListCode).DBIndex)
                    Return False
                Else
                    _L8B.db.UpdateAlarmReportRelease(_L8B.Alarm.AlarmList(nAlarmListCode).DBIndex, True)
                    _L8B.Alarm.AlarmList(nAlarmListCode).fReportRelease = True
                    _L8B.db.UpdateAlarmReportRelease(_L8B.Alarm.AlarmList(nAlarmListCode).DBIndex)
                    Return True
                End If
            Catch ex As Exception
                WriteLog(ex.ToString)
                Return False
            End Try
        End Function


        Public Sub PortDisable(ByVal nPort As Integer)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            If PortInfo(nPort).PortStatus <> prjSECS.clsEnumCtl.ePortStatus.TSIP_DISABLE Then
                WriteLog("[MCIM] Port=" & nPort & " change to disable. ", LogMessageType.Warn)

                PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_DISABLE
                L8BCIM.PortInfoChanged(PortInfo(nPort))
            Else
                WriteLog("[MCIM] Port=" & nPort & " was disable. Does nor need to change to disbale.", LogMessageType.Warn)
            End If
        End Sub

        Public Sub CassetteLoadRequest(ByVal nPort As Integer)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            PortInfo(nPort).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_LOADREQ
            L8BCIM.PortInfoChanged(PortInfo(nPort))
            L8BCIM.S1F73CSTLoadReq(nPort)
        End Sub

        Public Sub CassetteArrived(ByVal nPort As Integer)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            L8BCIM.S1F73CassetteArrived(nPort)
        End Sub

        Public Sub CassetteLoadComplete(ByVal nPort As Integer, ByVal vMiniSlot As Integer)
            mInfo.Port(nPort).FirstNonEmptySlot = vMiniSlot
            Dim Tmp As String = ""

            If vMiniSlot > 1 And vMiniSlot <= MAXCASSETTESLOT Then
                For i As Integer = 1 To vMiniSlot - 1
                    mInfo.Port(nPort).Map(i) = 0
                    mInfo.Port(nPort).fGlassExist(i) = False
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).RemoveGlassFromCST(i)
                    Tmp &= "0"
                Next
                For i As Integer = vMiniSlot To MAXCASSETTESLOT
                    mInfo.Port(nPort).Map(i) = 1
                    mInfo.Port(nPort).fGlassExist(i) = True
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).InsertGlassToCST(i)
                    Tmp &= "1"
                Next
            ElseIf vMiniSlot = 1 Then
                For i As Integer = 1 To MAXCASSETTESLOT
                    mInfo.Port(nPort).Map(i) = 1
                    mInfo.Port(nPort).fGlassExist(i) = True
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).InsertGlassToCST(i)
                    Tmp &= "1"
                Next
            Else
                For i As Integer = 1 To MAXCASSETTESLOT
                    mInfo.Port(nPort).Map(i) = 0
                    mInfo.Port(nPort).fGlassExist(i) = False
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).RemoveGlassFromCST(i)
                    Tmp &= "0"
                Next
            End If

            WriteLog("CassetteLoadComplete Port=" & nPort & " MiniSlot=" & vMiniSlot & " " & Tmp)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            L8BCIM.S7F71MappingCompleted(nPort, mInfo.Port(nPort).Map)
        End Sub

        Public Sub VirtualLoadComplete(ByVal nPort As Integer, ByVal vMiniSlot As Integer)
            mInfo.Port(nPort).FirstNonEmptySlot = vMiniSlot
            Dim Tmp As String = ""

            If vMiniSlot > 1 And vMiniSlot <= MAXCASSETTESLOT Then
                For i As Integer = 1 To vMiniSlot - 1
                    mInfo.Port(nPort).fGlassExist(i) = False
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).RemoveGlassFromCST(i)
                    mInfo.Port(nPort).Map(i) = 0
                    Tmp &= mInfo.Port(nPort).Map(i)
                Next
                For i As Integer = vMiniSlot To MAXCASSETTESLOT
                    mInfo.Port(nPort).fGlassExist(i) = True
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).InsertGlassToCST(i)
                    mInfo.Port(nPort).Map(i) = 1
                    Tmp &= mInfo.Port(nPort).Map(i)
                Next
            ElseIf vMiniSlot = 1 Then
                For i As Integer = 1 To MAXCASSETTESLOT
                    mInfo.Port(nPort).fGlassExist(i) = True
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).InsertGlassToCST(i)
                    mInfo.Port(nPort).Map(i) = 1
                    Tmp &= mInfo.Port(nPort).Map(i)
                Next
            Else
                For i As Integer = 1 To MAXCASSETTESLOT
                    mInfo.Port(nPort).fGlassExist(i) = False
                    _L8B.frmMain.RSTControl.CVGUIPort(nPort).RemoveGlassFromCST(i)
                    mInfo.Port(nPort).Map(i) = 0
                    Tmp &= mInfo.Port(nPort).Map(i)
                Next
            End If
            WriteLog("VirtualLoadComplete Port=" & nPort & " MiniSlot=" & vMiniSlot & " " & Tmp)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            L8BCIM.S1F73VirtualCSTLoadComp(nPort)
        End Sub


        Public Sub CassetteUnloadRequest(ByVal nPort As Integer)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            WriteLog("Port " & nPort & " CassetteUnclamped")
            If RemoteMode <> prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                L8BCIM.S1F75CassetteUnclamped(nPort)
            End If
        End Sub

        Public Sub CassetteRemoved(ByVal nPort As Integer)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            L8BCIM.S1F75CassetteRemoved(nPort)
        End Sub

        Public Sub CassetteStatusChange(ByVal nPort As Integer, ByVal vStatus As prjSECS.clsEnumCtl.eCassetteStatus, Optional ByVal fForced As Boolean = False)
            If RemoteMode = eRemoteStatus.MODE_OFFLINE Then
                Return
            End If
            If mInfo.Port(nPort).CassetteStatus = vStatus And Not fForced Then
                WriteLog(String.Format("Port {1} CassetteStatusChange no change :: {0}", vStatus, nPort), LogMessageType.Info)
            Else
                If LotInfo(nPort).IsLotDataReceived Then
                    WriteLog(String.Format("Port {1} CassetteStatusChange -> {0} at Port status= {2}", vStatus, nPort, mInfo.Port(nPort).Status.ToString), LogMessageType.Info)
                    Dim myEndCode As prjSECS.clsEnumCtl.eProcessENDCode = prjSECS.clsEnumCtl.eProcessENDCode.NONE

                    If vStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_END Then
                        Select Case _L8B.Setting.Main.GlassFlowMode
                            Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                                If mInfo.Port(nPort).InProcess OrElse mInfo.Port(nPort).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING Then
                                    If mInfo.Port(nPort).InProcessAbort Then
                                        myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONC_REMAINWORKS
                                    Else
                                        myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONF_UNLOADER
                                    End If
                                Else
                                    '20110908
                                    If mInfo.Port(nPort).Status = PORTSTATUS.PROCESSWAIT OrElse mInfo.Port(nPort).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT Then
                                        myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                                    ElseIf _L8B.CIM.LotInfo(nPort).RecipeNeedConfirm Then
                                        myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                                    End If
                                End If
                            Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                                Select Case _L8B.PLC.CVPortMode(nPort) 'mInfo.Port(nPort).CassetteMode
                                    Case L8BIFPRJ.clsPLC.ePortMode.LOAD
                                        If mInfo.Port(nPort).InProcess OrElse mInfo.Port(nPort).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING Then
                                            If mInfo.Port(nPort).GlassCount = 0 Then
                                                myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.EMPT_EMPTY
                                            Else
                                                myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONC_REMAINWORKS
                                            End If
                                        Else
                                            '20110908;  fix 9/4 FG0225 於FKE40 有跑貨記錄, 但發現S1F67 從 W-> S ->T , T 的部份沒有上報LONF資訊!
                                            If mInfo.Port(nPort).Status = PORTSTATUS.PROCESSWAIT OrElse mInfo.Port(nPort).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT Then
                                                myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                                            ElseIf _L8B.CIM.LotInfo(nPort).RecipeNeedConfirm Then
                                                myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                                            End If
                                        End If

                                    Case L8BIFPRJ.clsPLC.ePortMode.UNLOAD
                                        If mInfo.Port(nPort).InProcess OrElse mInfo.Port(nPort).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING Then
                                            If mInfo.Port(nPort).GlassCount > 0 Then
                                                myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONF_UNLOADER
                                            Else
                                                myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                                            End If
                                        Else
                                            '20110908; ignore [SUSPENDING]
                                            If mInfo.Port(nPort).Status = PORTSTATUS.PROCESSWAIT OrElse mInfo.Port(nPort).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT Then
                                                myEndCode = prjSECS.clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                                            End If
                                        End If
                                    Case Else
                                        ''
                                        ''
                                End Select
                        End Select

                        WriteLog(String.Format("Port {1} CassetteStatusChange EndCode-> {0}", myEndCode.ToString, nPort), LogMessageType.Info)
                        If myEndCode <> prjSECS.clsEnumCtl.eProcessENDCode.NONE Then
                            mInfo.Port(nPort).CassetteStatus = vStatus
                            L8BCIM.CassetteProcessEnd(nPort, myEndCode)
                        End If
                    Else
                        mInfo.Port(nPort).CassetteStatus = vStatus
                        L8BCIM.S1F67CassetteStatusChanged(nPort, vStatus)
                    End If

                Else
                    WriteLog("No LotData downLoad for report cassette status. port=" & nPort)
                End If

            End If

        End Sub

        Public Sub SendHostMessage(ByVal vMessage As String)
            L8BCIM.S10F1TerminalSend(vMessage)
        End Sub

        Public Sub ClearLotData(ByVal nPort As Integer)

            WriteLog("Clear LotData port:" & nPort)
            With LotInfo(nPort)
                .CassetteID = ""
                .CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE
                .IsLotDataReceived = False
                .LotCancel = False
                .MeasurementID = ""
                .OperationID = ""
                .OperatorID = ""
                .ProductCode = ""
                .PortPosition = nPort
                .PPIDChanged = False
                .ProcessEndCode = prjSECS.clsEnumCtl.eProcessENDCode.NONE
                .ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_NONE
                .RecipeCode = False
                .RecipeName = ""
                .RecipeNeedConfirm = False
                .UnderSlotsSelection = False
                .CIMMessage = ""
                .DateTime = Date.MinValue
                .DuringSlotsSelection = False
                For i As Integer = 1 To MAXCASSETTESLOT
                    If .Slots(i) IsNot Nothing Then
                        With .Slots(i)
                            .SlotNo = i
                            .GlassID = ""
                            '.DMQCGradeDownload = prjsecs.clsEnumCtl.eDMQCGrade.NO
                            .DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
                            .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
                            .DMQCToolID = ""
                            .DMQCToolIDDownload = ""
                            .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                            .FIRemark = False
                            .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO
                            .GlassGradeDownload = prjSECS.clsEnumCtl.eGlassGrade.NO
                            .LastOperationID = ""
                            .LastPorcessToolID = ""
                            .PLineID = ""
                            .ProcessToolID = ""
                            .ProcFlag = False
                            .PSHGroup = ""
                            .Rework = False
                            .Scrap = prjSECS.clsEnumCtl.eScrapType.NONE
                        End With
                    End If
                Next
            End With

            With mInfo.Port(nPort)
                .FirstNonEmptySlot = 0
                .fPause = False
                .fUserCassetteUnLoadRequest = False
                For i As Integer = 1 To MAXCASSETTESLOT
                    If .Glass(i) Is Nothing Then
                        .Glass(i) = New L8BIFPRJ.clsS167SlotInfo
                    End If
                    .Glass(i).GlassID = ""
                    .fGlassExist(i) = False
                Next

            End With
            mInfo.Port(nPort).InProcess = False
            mInfo.Port(nPort).InProcessAbort = False
            mInfo.Port(nPort).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.NONE
            _L8B.Setting.SaveLotDataDownload(nPort, False)
        End Sub

        Public Sub LookBack()
            L8BCIM.S2F25LoopBackTest()
        End Sub

        Public Sub RemoveSlotFromPort(ByVal nPort As Integer, ByVal nSlot As Integer)
            WriteLog("RemoveSlotFromPort " & nPort & " " & nSlot)

            With _L8B.CIM.LotInfo(nPort).Slots(nSlot)
                .GlassID = ""
                .SlotNo = nSlot
                .ChipGradeByString = ""
                .DMQCDownload = eDMQCGrade.NO
                .DMQCGrade = eDMQCGrade.NO
                .DMQCResult = eDMQCGrade.NO
                .DMQCToolID = ""
                .DMQCToolIDDownload = ""
                .FIFCFlag = eFIFCFlag.FLAG_NA
                .FIRemark = False
                .GlassGrade = eGlassGrade.NO
                .GlassGradeDownload = eGlassGrade.NO
                .IsGlassProecssed = False
                .LastLineID = ""
                .LastOperationID = ""
                .LastPorcessToolID = ""
                .PLineID = ""
                .ProcessToolID = ""
                .ProcFlag = False
                .PSHGroup = ""
                .Rework = False
                .Scrap = eScrapType.NONE
            End With

            L8BCIM.RemoveSlotFromPort(nPort, nSlot)
        End Sub

        Public Sub CopyLotInfo(ByVal nPort As Integer, ByVal vLotInfo As prjSECS.clsLotStructure)
            If LotInfo Is Nothing Then
                LotInfo(nPort) = New prjSECS.clsLotStructure
            End If
            With LotInfo(nPort)
                .CassetteID = vLotInfo.CassetteID
                .CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE
                .CIMMessage = vLotInfo.CIMMessage
                .DateTime = vLotInfo.DateTime
                .DuringSlotsSelection = False
                .IsLotDataReceived = True
                .LotCancel = False
                .MeasurementID = vLotInfo.MeasurementID
                .OperationID = vLotInfo.OperationID
                .OperatorID = vLotInfo.OperatorID
                .PortPosition = vLotInfo.PortPosition
                If .PortPosition <> nPort Then
                    WriteLog("CopyLotInfo::PortPosition<>nPort ", LogMessageType.Info)
                End If
                .PPIDChanged = False
                .ProcessEndCode = vLotInfo.ProcessEndCode
                .ProductCategory = vLotInfo.ProductCategory
                .ProductCode = vLotInfo.ProductCode
                .RecipeCode = vLotInfo.RecipeCode
                .RecipeName = vLotInfo.RecipeName
                .RecipeNeedConfirm = False
                .ReturnCode = vLotInfo.ReturnCode
                .UnderSlotsSelection = False

                For i As Integer = 1 To MAXCASSETTESLOT
                    With .Slots(i)
                        .SlotNo = vLotInfo.Slots(i).SlotNo
                        .ChipGradeByString = vLotInfo.Slots(i).ChipGradeByString
                        .DMQCDownload = vLotInfo.Slots(i).DMQCDownload
                        .DMQCGrade = vLotInfo.Slots(i).DMQCGrade
                        .DMQCResult = vLotInfo.Slots(i).DMQCResult
                        .DMQCToolID = vLotInfo.Slots(i).DMQCToolID
                        .DMQCToolIDDownload = vLotInfo.Slots(i).DMQCToolIDDownload
                        .FIFCFlag = vLotInfo.Slots(i).FIFCFlag
                        .FIRemark = vLotInfo.Slots(i).FIRemark
                        .GlassGrade = vLotInfo.Slots(i).GlassGrade
                        .GlassGradeDownload = vLotInfo.Slots(i).GlassGradeDownload
                        .GlassID = vLotInfo.Slots(i).GlassID
                        .IsGlassProecssed = False
                        .LastLineID = vLotInfo.Slots(i).LastLineID
                        .LastOperationID = vLotInfo.Slots(i).LastOperationID
                        .LastPorcessToolID = vLotInfo.Slots(i).LastPorcessToolID
                        .PLineID = vLotInfo.Slots(i).PLineID
                        .ProcessToolID = vLotInfo.Slots(i).ProcessToolID
                        .ProcFlag = False
                        .PSHGroup = vLotInfo.Slots(i).PSHGroup
                        .Rework = vLotInfo.Slots(i).Rework
                        .Scrap = vLotInfo.Slots(i).Scrap
                    End With
                Next

            End With
            WriteLog("CopyLotInfo " & vLotInfo.ProductCategory.ToString, LogMessageType.Info)
        End Sub

        Public Sub WorkIDUnMatch(ByVal OldGlassID As String, ByVal NewGlassID As String)
            L8BCIM.S6F87WorkIDUnmatch(mInfo.CV.UnitID, OldGlassID, NewGlassID)
        End Sub

        Public Sub GlassProcessFinish(ByVal vGlass As L8BIFPRJ.clsS167SlotInfo)

            Try  ' MISSING [mInfo.GlassIDStore(vGlassID).Lot.PortPosition]

                WriteLog(String.Format("GlassProcessFinish: GlassID=[{0}]", vGlass.GlassID), LogMessageType.Info)
                Dim GxReport(0) As prjSECS.clsGxReport
                Dim nReportCount As Integer = GlassVisitEQ(vGlass)
                GxReport(0) = New prjSECS.clsGxReport
                Dim strEQID As String = ""

                If nReportCount > 0 Then
                    ReDim GxReport(nReportCount)
                    Dim Index As Integer = 1
                    For i As Integer = 1 To MaxEQ
                        If vGlass.EQStartTime(i) <> "" Then
                            GxReport(Index) = New prjSECS.clsGxReport
                            GxReport(Index).GxID = vGlass.GlassID
                            Select Case i
                                Case 1
                                    strEQID = _L8B.Setting.ID.EQ1
                                Case 2
                                    strEQID = _L8B.Setting.ID.EQ2
                                Case 3
                                    strEQID = _L8B.Setting.ID.EQ3
                            End Select
                            GxReport(Index).ToolID = strEQID  'mInfo.EQ(i).ToolID
                            GxReport(Index).PPID = MyTrim(vGlass.LotRecipeID)
                            GxReport(Index).ProcessStartTime = "20" & vGlass.EQStartTime(i)
                            GxReport(Index).ProcessEndTime = "20" & vGlass.EQEndTime(i)
                            Index += 1
                        End If
                    Next
                    L8BCIM.S6F91SlotProcessComplete(GxReport)
                End If


            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try
        End Sub

        Public Sub InserSlotToPort(ByVal nPort As Integer, ByVal nSlot As Integer)
            Try

                WriteLog("InserSlotToPort::GlxInfo [" & mInfo.Port(nPort).Glass(nSlot).GlassID & "] 'Visit EQ[" & GlassVisitEQ(mInfo.Port(nPort).Glass(nSlot)) & "] Times]")


                Dim Slot167 As L8BIFPRJ.clsS167SlotInfo = _L8B.PLC.L8BPLC.GetCSTSlotInfo(nPort, nSlot)

                mInfo.Port(nPort).Glass(nSlot).GlassID = MyTrim(mInfo.Port(nPort).Glass(nSlot).GlassID)

                If mInfo.Port(nPort).Glass(nSlot).GlassID.Length Then
                    _L8B.PLC.GetPLC167Slot(nPort, nSlot)
                ElseIf MyTrim(Slot167.GlassID) <> mInfo.Port(nPort).Glass(nSlot).GlassID Then
                    WriteLog("myPC glassID " & mInfo.Port(nPort).Glass(nSlot).GlassID & " unmatch with PLC. [" & Slot167.GlassID & "]")
                    _L8B.PLC.GetPLC167Slot(nPort, nSlot)
                Else
                    If GlassVisitEQ(Slot167) <> GlassVisitEQ(mInfo.Port(nPort).Glass(nSlot)) Then
                        For i As Integer = 1 To MaxEQ
                            mInfo.Port(nPort).Glass(nSlot).EQStartTime(i) = MyTrim(Slot167.EQStartTime(i))
                            mInfo.Port(nPort).Glass(nSlot).EQEndTime(i) = MyTrim(Slot167.EQEndTime(i))
                        Next
                    End If
                End If

                Dim mySlotInfo As New prjSECS.clsSlotStructure
                With mySlotInfo
                    .SlotNo = nSlot
                    .GlassID = mInfo.Port(nPort).Glass(nSlot).GlassID

                    If GlassVisitEQ(mInfo.Port(nPort).Glass(nSlot)) > 0 Then
                        .IsGlassProecssed = True
                    Else
                        .IsGlassProecssed = False
                    End If

                    .LastOperationID = "" 'mInfo.Port(nPort).Glass(nSlot).PTOOLID
                    .LastPorcessToolID = mInfo.Port(nPort).Glass(nSlot).PTOOLID
                    .LastLineID = "" 'mInfo.Port(nPort).Glass(nSlot).
                    .ProcessToolID = "" 'DirectCast(GlxInfo.S6F91Result(0), cGlassInfo.EQProcessData).ToolID
                    If GlassVisitEQ(mInfo.Port(nPort).Glass(nSlot)) > 0 Then
                        Select Case _L8B.Setting.Main.MachineType
                            Case ClsSetting.EMACHINETYPE.ButterFly
                                .DMQCToolID = mInfo.Port(nPort).Glass(nSlot).PTOOLID
                            Case Else
                                .DMQCToolID = ""
                        End Select
                        Dim ChipGrad = mInfo.Port(nPort).Glass(nSlot).ChipGrade
                        If ChipGrad IsNot Nothing AndAlso ChipGrad.Length > 0 Then
                            For i As Integer = 0 To ChipGrad.Length - 1
                                Select Case ChipGrad(i)
                                    Case "O"
                                        .ChipGrade(i + 1) = prjSECS.clsEnumCtl.eGlassGrade.OK
                                    Case "X"
                                        .ChipGrade(i + 1) = prjSECS.clsEnumCtl.eGlassGrade.NG
                                    Case "G"
                                        .ChipGrade(i + 1) = prjSECS.clsEnumCtl.eGlassGrade.GRAY
                                End Select
                            Next
                            WriteLog(.SlotNo & "Chipgrade[" & .ChipGradeByString & "]", LogMessageType.Info)
                        End If
                    Else
                        .DMQCToolID = ""
                        .ChipGradeByString = ""
                    End If
                    .DMQCToolIDDownload = "" 'GlxInfo.DMQCToolIDDownload
                    .PLineID = "" 'GlxInfo.LastProcessLineID
                    .PSHGroup = "" 'mInfo.Port(nPort).Glass(nSlot).PSHGroup

                    ''Update DMQCGrade and GlassGrade
                    Select Case _L8B.Setting.Main.MachineType

                        Case ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                            .DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
                            .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
                            .GlassGradeDownload = eGlassGrade.NO  'GlxInfo.GlassGradeDownload
                            .GlassGrade = mInfo.Port(nPort).Glass(nSlot).GGRADE
                            WriteLog(.SlotNo & "GlassGrade[" & .GlassGrade.ToString & "]", LogMessageType.Info)

                        Case ClsSetting.EMACHINETYPE.FI
                            Dim myRecipe As cRecipe = _L8B.db.LoadRecipe(MyTrim(mInfo.Port(nPort).Glass(nSlot).LotRecipeID))
                            If myRecipe IsNot Nothing Then
                                Select Case myRecipe.FICIMResult
                                    Case cRecipe.eFICIMGradeReport.DMQC
                                        .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO
                                        If mInfo.Port(nPort).Glass(nSlot).DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.NG Then 'OrElse GlxInfo.DMQCGradeDownload = prjsecs.clsEnumCtl.eDMQCGrade.NG Then
                                            .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NG
                                        Else
                                            .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.OK
                                        End If
                                        .DMQCGrade = mInfo.Port(nPort).Glass(nSlot).DGRADE
                                        WriteLog(.SlotNo & "DMQCGrade[" & .DMQCGrade.ToString & "]", LogMessageType.Info)
                                    Case Else
                                        .DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                        .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                        .GlassGradeDownload = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                        .GlassGrade = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                        WriteLog(.SlotNo & "GlassGrade[" & .GlassGrade.ToString & "]", LogMessageType.Info)
                                End Select
                            Else
                                .DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                .GlassGradeDownload = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                .GlassGrade = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                WriteLog(.SlotNo & "GlassGrade[" & .GlassGrade.ToString & "]", LogMessageType.Info)
                            End If

                        Case Else  'report DMQC no Review
                            'for DMQC  
                            'Result DMQC Grade  DMQC Grade of Glass from upstream 
                            'after(Downstream)
                            '(RDGRADE)          OK  NG  Review  None 
                            '        
                            '       OK          OK  NG  OK      OK 
                            ' DJUDGE of NG
                            'Measure EQ         NG  NG  NG      NG 

                            If _L8B.Setting.Main.MacroEQID > 0 And MyTrim(mInfo.Port(nPort).Glass(nSlot).EQEndTime(_L8B.Setting.Main.MacroEQID)).Length > 0 Then
                                Dim myRecipe As cRecipe = _L8B.db.LoadRecipe(MyTrim(mInfo.Port(nPort).Glass(nSlot).LotRecipeID))
                                If myRecipe IsNot Nothing Then
                                    Select Case myRecipe.FICIMResult
                                        Case cRecipe.eFICIMGradeReport.DMQC
                                            .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO
                                            If mInfo.Port(nPort).Glass(nSlot).DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.NG Then 'OrElse GlxInfo.DMQCGradeDownload = prjsecs.clsEnumCtl.eDMQCGrade.NG Then
                                                .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NG
                                            Else
                                                .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.OK
                                            End If
                                            .DMQCGrade = mInfo.Port(nPort).Glass(nSlot).DGRADE
                                            WriteLog(.SlotNo & "DMQCGrade[" & .DMQCGrade.ToString & "]", LogMessageType.Info)
                                        Case Else
                                            .DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                            .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                            .GlassGradeDownload = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                            .GlassGrade = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                            WriteLog(.SlotNo & "GlassGrade[" & .GlassGrade.ToString & "]", LogMessageType.Info)
                                    End Select
                                Else
                                    .DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                    .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NO
                                    .GlassGradeDownload = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                    .GlassGrade = mInfo.Port(nPort).Glass(nSlot).GGRADE
                                    WriteLog(.SlotNo & "GlassGrade[" & .GlassGrade.ToString & "]", LogMessageType.Info)
                                End If
                            Else
                                .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO
                                If mInfo.Port(nPort).Glass(nSlot).DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.NG Then 'OrElse GlxInfo.DMQCGradeDownload = prjsecs.clsEnumCtl.eDMQCGrade.NG Then
                                    .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.NG
                                Else
                                    .DMQCResult = prjSECS.clsEnumCtl.eDMQCGrade.OK
                                End If
                                .DMQCGrade = mInfo.Port(nPort).Glass(nSlot).DGRADE
                                WriteLog(.SlotNo & "DMQCGrade[" & .DMQCGrade.ToString & "]", LogMessageType.Info)
                            End If
                    End Select

                    'For i As Integer = 1 To 72
                    '    .ChipGrade(i) = GlxInfo.ChipGrade(i)
                    'Next
                    .Rework = False 'GlxInfo.Rework
                    .Scrap = prjSECS.clsEnumCtl.eScrapType.NONE 'GlxInfo.Scrap
                    .FIRemark = False 'GlxInfo.FIRemark
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA 'GlxInfo.FIFCFlag
                    .ProcFlag = False  'GlxInfo.ProcFlag
                    WriteLog("InserSlotToPort::GlassID {" & .GlassID & "} GGrade:" & mySlotInfo.GlassGrade.ToString & "/DGrade:" & .DMQCGrade, LogMessageType.Info)
                End With

                '20101124
                With _L8B.CIM.LotInfo(nPort).Slots(mySlotInfo.SlotNo)
                    .GlassID = mySlotInfo.GlassID
                    .SlotNo = mySlotInfo.SlotNo
                    .ChipGradeByString = mySlotInfo.ChipGradeByString
                    .DMQCDownload = mySlotInfo.DMQCDownload
                    .DMQCGrade = mySlotInfo.DMQCGrade
                    .DMQCResult = mySlotInfo.DMQCResult
                    .DMQCToolID = mySlotInfo.DMQCToolID
                    .DMQCToolIDDownload = mySlotInfo.DMQCToolIDDownload
                    .FIFCFlag = mySlotInfo.FIFCFlag
                    .FIRemark = mySlotInfo.FIRemark
                    .GlassGrade = mySlotInfo.GlassGrade
                    .GlassGradeDownload = mySlotInfo.GlassGradeDownload
                    .IsGlassProecssed = mySlotInfo.IsGlassProecssed
                    .LastLineID = mySlotInfo.LastLineID
                    .LastOperationID = mySlotInfo.LastOperationID
                    .LastPorcessToolID = mySlotInfo.LastPorcessToolID
                    .PLineID = mySlotInfo.PLineID
                    .ProcessToolID = mySlotInfo.ProcessToolID
                    .ProcFlag = mySlotInfo.ProcFlag
                    .PSHGroup = mySlotInfo.PSHGroup
                    .Rework = mySlotInfo.Rework
                    .Scrap = mySlotInfo.Scrap
                End With

                If nSlot = MAXCASSETTESLOT Then
                    WriteLog("Update product ProductCategory in Port=" & nPort & " as [" & mInfo.Port(nPort).Glass(nSlot).ProductCategory & "] ", LogMessageType.Info) ' & "ProdCode=[" & GlxInfo.Lot.ProductCode & "]", LogMessageType.Info)
                    L8BCIM.InsertSlotToPort(nPort, mySlotInfo, mySlotInfo.IsGlassProecssed, mInfo.Port(nPort).Glass(nSlot).ProductCategory, mInfo.Port(nPort).Glass(nSlot).LotRecipeID)
                Else
                    L8BCIM.InsertSlotToPort(nPort, mySlotInfo, mySlotInfo.IsGlassProecssed)
                End If

            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try
        End Sub

        Public Sub RecipeChangedReport(ByVal UnitNo As Integer, ByVal zPPID As String)
            WriteLog("RecipeChangedReport at Unit=" & UnitNo & " PPID->" & zPPID)
            L8BCIM.S1F97RecipeChanged(UnitNo, zPPID)
        End Sub

        Public Sub CassetteDataConfirm(ByVal nPort As Integer, Optional ByVal nReplyCode As Integer = 0)
            L8BCIM.S7F65CassetteDataConfirm(nPort, nReplyCode)
        End Sub

        Public Sub GlassErase(ByVal vToolID As String, ByVal vGlassID As String)
            L8BCIM.S6F85GlassErase(vToolID, vGlassID)
        End Sub

        Public Sub Setting()
            L8BCIM.ShowHSMSSetting()
        End Sub

        Public Sub New()
            Online_FirstTime = True
        End Sub
    End Class

End Module
