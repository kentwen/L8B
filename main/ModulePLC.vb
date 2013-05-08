Module ModulePLC


    Public MainPLC As New clsMainPLC

    Public Sub InitPLC()
        _L8B.PLC = MainPLC
        _L8B.PLC.PLCInitial()
    End Sub

    Public Class clsMainPLC
        Public WithEvents L8BPLC As New L8BIFPRJ.clsPLC
        Public Mileage(6) As Integer
        Public RobotAlarm As New ArrayList
        Public fINITAlarmComplete As Boolean

        Private Structure FlowOutSlotStructure
            Dim Port As Integer
            Dim Slot As Integer
        End Structure

        Public Enum EmileageInfo
            Axis1   '1軸 (走心軸) 累積距離 (單位 : km)
            Axis2   '2軸 (旋轉軸) 累積距離 (單位 : Radian)
            Axis3   '3軸 (升降軸-第1段) 累積距離 (單位 : km)
            Axis4   '4軸 (升降軸-第2段) 累積距離 (單位 : km)
            Axis5   '5軸 (下手臂) 累積距離 (單位 : Radian)
            Axis6   '6軸 (上手臂) 累積距離 (單位 : Radian)
        End Enum

        Public Sub PLCInitial()
            L8BPLC.PLCInitial(_L8B.Setting.ExtraIniFile.PLC)
        End Sub

        Public ReadOnly Property RSTCommandAccept()
            Get
                Return L8BPLC.RSTCommandConfirm
            End Get
        End Property

        Private Sub PLC_CVAlarm(ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer) Handles L8BPLC.CVAlarm
            _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.CV, nAlarmCode, IIf(fOnOff, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE))
        End Sub

        Private Sub PLC_CVCassettePresent(ByVal nPortNo As Integer) Handles L8BPLC.CVCassettePresent
            If nPortNo <= _L8B.Setting.Main.NumberPort Then
                SetPortStatus(nPortNo, PORTSTATUS.PRESENT)
            Else
                WriteLog("PLC_CVCassettePresent: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
            End If
        End Sub

        Private Sub PLC_CVCSTArrived(ByVal nPortNo As Integer) Handles L8BPLC.CVCSTArrived
            If nPortNo <= _L8B.Setting.Main.NumberPort Then
                If mInfo.Port(nPortNo).Status = PORTSTATUS.LOADREQUEST Then 'mInfo.Port(nPortNo).Status = PORTSTATUS.EMPTY Or
                    SetPortStatus(nPortNo, PORTSTATUS.ARRIVAL)
                Else
                    WriteLog("[Fail] Change Port status Port=" & nPortNo & " to " & mInfo.Port(nPortNo).Status.ToString & " From " & PORTSTATUS.ARRIVAL.ToString, LogMessageType.ERR)
                End If
                _L8B.frmMain.CassetteExistUpdate(nPortNo)
            Else
                WriteLog("PLC_CVCSTArrived: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
            End If
        End Sub

        Private Sub PLC_CVCSTLoadComplete(ByVal nPortNo As Integer, ByVal nFirstNonEmptySlot As Integer, ByVal CASID As String) Handles L8BPLC.CVCSTLoadComplete
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVCSTLoadComplete: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            WriteLog("CVCSTLoadComplete Port=" & nPortNo & " CassetteID=" & CASID, LogMessageType.Info)
            mInfo.Port(nPortNo).FirstNonEmptySlot = nFirstNonEmptySlot
            mInfo.Port(nPortNo).PortFAStatus = ePortFAStatus.LoadComplete
            If mInfo.Port(nPortNo).fDummyCancel Then
                SetPortStatus(nPortNo, PORTSTATUS.VIRTUALLOAD, nFirstNonEmptySlot)
                mInfo.Port(nPortNo).fDummyCancel = False
            ElseIf mInfo.Port(nPortNo).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_NONE Then
                If mInfo.Port(nPortNo).PortFAStatus <> ePortFAStatus.NA Then
                    SetPortStatus(nPortNo, PORTSTATUS.LOADCOMPLETE, nFirstNonEmptySlot)
                Else
                    WriteLog("StartUp cassette cancel when loadComplete and CV wait process command", LogMessageType.Info)
                    'CancelCassette(nPortNo, True)
                End If
            Else
                Dim FlowOut As Integer = L8BPLC.CVFlowOutQty(nPortNo)
                Dim FlowIn As Integer = L8BPLC.CVFlowInQty(nPortNo)
                'nFirstNonEmptySlot = nFirstNonEmptySlot + FlowOut - FlowIn
                'If nFirstNonEmptySlot > MAXCASSETTESLOT Then
                '    nFirstNonEmptySlot = 0
                'End If
                If mInfo.Port(nPortNo).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.NONE OrElse mInfo.Port(nPortNo).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.END Then
                    WriteLog("CVCSTLoadComplete Port=" & nPortNo & " CassetteID=" & CASID & "with  flowin=" & FlowIn & " flowout=" & FlowOut, LogMessageType.Info)
                    _L8B.CIM.CassetteLoadComplete(nPortNo, nFirstNonEmptySlot)
                Else
                    WriteLog("CVCSTLoadComplete Port=" & nPortNo & " CassetteStatus=" & mInfo.Port(nPortNo).CassetteStatus)
                End If
            End If
            _L8B.CIM.PortInfo(nPortNo).WithCassette = True
            _L8B.frmMain.UpdateCVPortGUI(nPortNo)
        End Sub

        Private Sub PLC_CVCSTLoadRequest(ByVal nPortNo As Integer) Handles L8BPLC.CVCSTLoadRequest
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVCSTLoadRequest: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If
            SetPortStatus(nPortNo, PORTSTATUS.LOADREQUEST)
            _L8B.CIM.PortInfo(nPortNo).WithCassette = False
            mInfo.Port(nPortNo).PortFAStatus = ePortFAStatus.LoadRequest
            _L8B.frmMain.UpdateCVPortGUI(nPortNo)
        End Sub

        Private Sub PLC_CVCSTRemoved(ByVal nPortNo As Integer) Handles L8BPLC.CVCSTRemoved
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVCSTRemoved: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If
            mInfo.Port(nPortNo).Present = False
            _L8B.CIM.PortInfo(nPortNo).WithCassette = False
            _L8B.frmMain.CassetteExistUpdate(nPortNo)
            SetPortStatus(nPortNo, PORTSTATUS.REMOVE)
            mInfo.Port(nPortNo).PortFAStatus = ePortFAStatus.UnloadComplete
            _L8B.frmMain.UpdateCVPortGUI(nPortNo)
        End Sub

        Private Sub PLC_CVCSTUnloadComplete(ByVal nPortNo As Integer) Handles L8BPLC.CVCSTUnloadComplete
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVCSTUnloadComplete: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If
            SetPortStatus(nPortNo, PORTSTATUS.CVUNLOADEDCOMPLETE)
            mInfo.Port(nPortNo).PortFAStatus = ePortFAStatus.UnloadRequest
            _L8B.frmMain.UpdateCVPortGUI(nPortNo)
        End Sub

        Private Sub PLC_CVCSTUnloadRequest(ByVal nPortNo As Integer, ByVal fUnloadNormal As Boolean, ByVal nGlassQty As Integer) Handles L8BPLC.CVCSTUnloadRequest
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVCSTUnloadRequest: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            WriteLog("PLC_CVCSTUnloadRequest port=" & nPortNo & " fUnloadNormal=" & fUnloadNormal & "GlassQty=" & nGlassQty, LogMessageType.Info)
            '2011-10-05 
            _L8B.CIM.CassetteStatusChange(nPortNo, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_END)
            mInfo.Port(nPortNo).PortFAStatus = ePortFAStatus.PreUnload
            SetPortStatus(nPortNo, PORTSTATUS.CVUNLOADREQUEST)
            _L8B.frmMain.UpdateCVPortGUI(nPortNo)
        End Sub

        Private Sub PLC_CVDummyCancelResult(ByVal nPortNo As Integer, ByVal fSuccess As Boolean) Handles L8BPLC.CVDummyCancelResult
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVDummyCancelResult: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If
            Dim Message As String = String.Format("Dummy Cancel return Port({0})  =  {1}", nPortNo, fSuccess)
            WriteLog(Message, LogMessageType.Info)
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, Message, MsgBoxStyle.OkOnly, 60)
            If fSuccess Then
                SetPortStatus(nPortNo, PORTSTATUS.REMOVE)
            End If
            _L8B.frmMain.SetRstguiCtrlCVCSTDummyCancelOff(nPortNo)

        End Sub

        Private Sub PLC_CVGlassAbnormal(ByVal nAbnormal As L8BIFPRJ.clsPLC.eGlassAbnormal, ByVal nPosition As Integer, ByVal strSourceGlassID As String, ByVal strNewGlassID As String) Handles L8BPLC.CVGlassAbnormal

            strSourceGlassID = MyTrim(strSourceGlassID)
            strNewGlassID = MyTrim(strNewGlassID)

            Select Case nAbnormal
                Case L8BIFPRJ.clsPLC.eGlassAbnormal.GLASSERASE
                    'CV not suport Glass earse, 2010-07-19
                    'WriteLog("CV EraseGlass for [" & strSourceGlassID & "]")
                    'GlassDelete(eUnitPosition.CV, nPosition, strSourceGlassID)
                    'mInfo.CV.Glass(nPosition).GlassID = ""
                    'mInfo.CV.fGlassExist(nPosition) = False

                Case L8BIFPRJ.clsPLC.eGlassAbnormal.GLASSIDMODIFY
                    WriteLog("CV ModifyGlass for [" & strSourceGlassID & "] -> [" & strNewGlassID & "]")
                    _L8B.CIM.WorkIDUnMatch(strSourceGlassID, strNewGlassID)
                    'CVGlassIDVCRModify(nPosition, strSourceGlassID, strNewGlassID)
                    'mInfo.CV.Glass(nPosition).GlassID = strNewGlassID
                    mInfo.Port(_L8B.Setting.Main.CVSectionPort(nPosition)).GlassFlowCV(_L8B.Setting.Main.CVSectionID(nPosition)).GlassID = strNewGlassID

                Case L8BIFPRJ.clsPLC.eGlassAbnormal.GLASSINSERT
                    WriteLog("CV InsertGlass for Glass=[" & strSourceGlassID & "] xxx  not support!!", LogMessageType.ERR)

                Case L8BIFPRJ.clsPLC.eGlassAbnormal.VCRNG
                    WriteLog("CV for VCRNG GlassID=[" & strSourceGlassID & "]")
            End Select
        End Sub

        Private Sub L8BPLC_CVGlassFlowIn(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal strGlassID As String, ByVal strProdCode As String, ByVal strStartTime() As String, ByVal strEndTime() As String) Handles L8BPLC.CVGlassFlowIn
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("L8BPLC_CVGlassFlowIn: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            GlassTransfer(eRobotPosition.CVP1 + nPortNo - 1, nPortNo, eRobotPosition.Port1 + nPortNo - 1, nSlotNo)
            Try
                WriteLog("Glass FlowIn port =" & nPortNo & " Slot = " & nSlotNo & " with GlassID =[" & strGlassID & "] ProductCode =" & strProdCode, LogMessageType.Info)
                _L8B.frmMain.InsertGlassToCst(nPortNo, nSlotNo)
                mInfo.Port(nPortNo).Map(nSlotNo) = 1
                _L8B.CIM.InserSlotToPort(nPortNo, nSlotNo)

                'remark 20120524
                'UpdateUnitWIP(clsCIMMain.SECSUNIT.CV)
                '_L8B.CIM.UnitInfoChange(mInfo.CV.UnitID)

                _L8B.CIM.GlassProcessFinish(mInfo.Port(nPortNo).Glass(nSlotNo))

                'First Glass flow into cassette, force port status set as in process
                If nSlotNo = MAXCASSETTESLOT Then
                    'If mInfo.Port(nPortNo).Status = PORTSTATUS.PROCESSWAIT Then
                    Dim Slot167 = L8BPLC.GetCSTSlotInfo(nPortNo, MAXCASSETTESLOT)

                    'Dim GlxInfo As cGlassInfo = mInfo.GlassIDStore(strGlassID)
                    _L8B.CIM.LotInfo(nPortNo).RecipeName = Slot167.LotRecipeID ' mInfo.CV.Glass(nPortNo).LotRecipeID
                    WriteLog(String.Format("GlassID[{0}] ProductCode Flowin [{1}] GetCSTSlotInfo [{2}] GlassData [{3}]", strGlassID, strProdCode, Slot167.ProductCode, mInfo.Port(nPortNo).Glass(nSlotNo).ProductCode), LogMessageType.Info)
                    _L8B.CIM.LotInfo(nPortNo).ProductCode = Slot167.ProductCode ' strProdCode
                    _L8B.CIM.LotInfo(nPortNo).ProductCategory = Slot167.ProductCategory
                    _L8B.CIM.PortInfo(nPortNo).CPPID = Slot167.LotRecipeID
                    SetPortStatus(nPortNo, PORTSTATUS.PROCESSING)
                    _L8B.frmMain.UpdateCVPortGUI(nPortNo)
                    'End If
                Else
                    If MyTrim(_L8B.CIM.LotInfo(nPortNo).ProductCode) <> MyTrim(strProdCode) Then
                        Dim Slot167 = L8BPLC.GetCSTSlotInfo(nPortNo, MAXCASSETTESLOT)
                        WriteLog(String.Format("[FAIL] GlassID[{0}] ProductCode unmatch in port {4}; use new one. Flowin [{1}] GetCSTSlotInfo [{2}] GlassData [{3}]", strGlassID, strProdCode, Slot167.ProductCode, mInfo.Port(nPortNo).Glass(nSlotNo).ProductCode, nPortNo), LogMessageType.Info)
                        _L8B.CIM.LotInfo(nPortNo).ProductCode = strProdCode
                        _L8B.frmMain.UpdateCVPortGUI(nPortNo)
                    End If
                End If
                _L8B.frmMain.GUICVFlowUpdate()
            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try
        End Sub

        Private Sub PLC_CVGlassFlowOut(ByVal nPortNo As Integer, ByVal nSlotNo As Integer) Handles L8BPLC.CVGlassFlowOut
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVGlassFlowOut: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            Try
                WriteLog("CV Glass Flowout from Port=" & nPortNo & "  Slot=" & nSlotNo)
                ' Flow out first glass report, before glass flow out force set port status as [in-process]
                If nSlotNo = mInfo.Port(nPortNo).FirstNonEmptySlot Then
                    WriteLog("Port=" & nPortNo & " Flowout the First NonEmptySlot Cassette Status -> in-Processing", LogMessageType.SYS)
                    SetPortStatus(nPortNo, PORTSTATUS.PROCESSING)
                End If


                GlassTransfer(eRobotPosition.Port1 + nPortNo - 1, nSlotNo, eRobotPosition.CVP1 + nPortNo - 1, 1)

                mInfo.Port(nPortNo).Map(nSlotNo) = 0

                If Not nSlotNo = mInfo.Port(nPortNo).FirstNonEmptySlot Then
                    _L8B.CIM.RemoveSlotFromPort(nPortNo, nSlotNo)
                End If

                _L8B.frmMain.RemoveGlassFromCst(nPortNo, nSlotNo)
                UpdatePassGlass(1)
                UpdateUnitWIP(clsCIMMain.SECSUNIT.CV)
                _L8B.frmMain.GUICVFlowUpdate()
            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try


        End Sub

        Private Sub PLC_CVHandOffAvailable(ByVal nPosition As Integer, ByVal fOnOff As Boolean) Handles L8BPLC.CVHandOffAvailable
            If nPosition > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVHandOffAvailable: invaid Position(=" & nPosition & ")", LogMessageType.ERR)
                Exit Sub
            End If
            WriteLog("CV CVHandOffAvailable Port=" & nPosition & "  On=" & fOnOff)
            mInfo.Port(nPosition).HandOff = fOnOff
            _L8B.frmMain.UpdateCVHandOff(nPosition)
        End Sub

        Private Sub PLC_CVLinkStatus(ByVal nCVIndex As Integer, ByVal nStatus As L8BIFPRJ.clsPLC.eLinkStatus) Handles L8BPLC.CVLinkStatus
            If nCVIndex > 1 Then
                WriteLog("PLC_CVLinkStatus: invaid CV(=" & nCVIndex & ")", LogMessageType.ERR)
                Exit Sub
            End If

            WriteLog("CVLinkStatus ->" & nStatus.ToString)
            If nStatus = L8BIFPRJ.clsPLC.eLinkStatus.LINKING And mInfo.CV.Link = L8BIFPRJ.clsPLC.eLinkStatus.NA Then
                'ChangeIUMode()
                UIModeSave(_L8B.PLC.L8BPLC.EQRunningMode, False)
                RobotArmUse(_L8B.Setting.Main.RobotArmUse)
                UpdateUIModeToCv()
                _L8B.frmMain.UpdateCVStatus()
            End If
            SetCVLinkStatus(nCVIndex, nStatus)
            For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                _L8B.frmMain.UpdateCVPortGUI(i)
            Next
        End Sub

        Private Sub PLC_CVPortDisable(ByVal nPortNo As Integer, ByVal fDisable As Boolean) Handles L8BPLC.CVPortDisable
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVPortDisable: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            _L8B.frmMain.RSTControl.CVGUIPort(nPortNo).Enabled = Not fDisable

            If fDisable Then
                SetPortStatus(nPortNo, PORTSTATUS.DISABLE)
            Else
                If L8BPLC.CVWithCassette(nPortNo) Then
                    SetPortStatus(nPortNo, PORTSTATUS.PRESENT)
                Else
                    SetPortStatus(nPortNo, PORTSTATUS.LOADREQUEST)
                End If
            End If
        End Sub

        Private Sub PLC_CVPortSubStaus(ByVal nPortNo As Integer, ByVal fPortPause As Boolean) Handles L8BPLC.CVPortSubStatus
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVPortDisable: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If
            WriteLog("PLC_CVPortSubStaus Port#" & nPortNo & " Substatus change Pause->" & fPortPause)
            If fPortPause Then
                _L8B.frmMain.RSTControl.CVGUIPort(nPortNo).PortPause()
            Else
                _L8B.frmMain.RSTControl.CVGUIPort(nPortNo).PortRelease()
            End If

            If mInfo.Port(nPortNo).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS Or mInfo.Port(nPortNo).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT Then
                SetPortSubStatus(nPortNo, fPortPause)
            Else
                WriteLog("Not in Processing or Waitting Ignore Port SubStaus", LogMessageType.Info)
            End If
        End Sub

        Private Sub PLC_CVPortTypeChangeResult(ByVal nPortNo As Integer, ByVal fSuccess As Boolean, ByVal nPortMode As L8BIFPRJ.clsPLC.ePortMode, ByVal nPortType As L8BIFPRJ.clsPLC.eUnloadType) Handles L8BPLC.CVPortTypeChangeResult
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVPortTypeChangeResult: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            Try

                WriteLog(String.Format("CVPortTypeChange Port:{0} Mode:{1} Type:{2}  {3}", nPortNo, nPortMode, nPortType, fSuccess), LogMessageType.Info)
                If Not fSuccess Then
                    WriteLog(String.Format("CVPortTypeChange Failure port{0}", nPortNo), LogMessageType.ERR)
                    Exit Sub
                End If

                Dim OldPortMode As L8BIFPRJ.clsPLC.ePortMode = mInfo.Port(nPortNo).CassetteMode
                Dim OldPortCategory As prjSECS.clsEnumCtl.ePortCategory = _L8B.CIM.PortInfo(nPortNo).PortCategory

                mInfo.Port(nPortNo).CassetteMode = nPortMode

                If mInfo.Port(nPortNo).UnLoaderType <> nPortType OrElse _L8B.CIM.PortInfo(nPortNo).PortMode <> nPortMode Then
                    With _L8B.CIM.PortInfo(nPortNo)

                        Select Case _L8B.Setting.Main.GlassFlowMode
                            Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                                .PortMode = prjSECS.clsEnumCtl.ePortMode.MODE_LDULD
                                .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED

                            Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                                .PortMode = nPortMode
                                Select Case nPortType
                                    Case L8BIFPRJ.clsPLC.eUnloadType.OK
                                        .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_OK

                                    Case L8BIFPRJ.clsPLC.eUnloadType.NG, L8BIFPRJ.clsPLC.eUnloadType.MIXNG, L8BIFPRJ.clsPLC.eUnloadType.GRAY
                                        .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_NG

                                    Case Else
                                        .PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED
                                End Select
                        End Select
                    End With
                    mInfo.Port(nPortNo).UnLoaderType = nPortType


                    'for Port Type Change CIM Report
                    If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                        If CassetteInPort(nPortNo) Then
                            If mInfo.Port(nPortNo).Status = PORTSTATUS.UNLOADREQUEST Or mInfo.Port(nPortNo).Status = PORTSTATUS.CVUNLOADEDCOMPLETE Then
                                _L8B.CIM.CassetteUnloadRequest(nPortNo)
                            End If
                        Else
                            _L8B.CIM.CassetteLoadRequest(nPortNo)
                        End If
                        If OldPortMode = L8BIFPRJ.clsPLC.ePortMode.LOAD And nPortMode = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then
                            Select Case _L8B.Setting.Main.MachineType
                                Case ClsSetting.EMACHINETYPE.FI, ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                                    'virtual load
                                    Dim GlassInCassette As Boolean = False
                                    For i As Integer = 1 To MAXCASSETTESLOT
                                        If mInfo.Port(nPortNo).fGlassExist(i) Then
                                            GlassInCassette = True
                                            Exit For
                                        End If
                                    Next

                                    If _L8B.CIM.PortInfo(nPortNo).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_END Then
                                        WriteLog("CVPortTypeChange in U Mode[do virtual Load] " & GlassInCassette, LogMessageType.Info)
                                        _L8B.CIM.LotInfo(nPortNo).IsLotDataReceived = False
                                        mInfo.Port(nPortNo).FirstNonEmptySlot = 0
                                        SetPortStatus(nPortNo, PORTSTATUS.VIRTUALLOAD, 0)
                                    End If

                            End Select
                        End If
                    End If
                End If
                _L8B.CIM.PortInfoChanged(nPortNo)
                _L8B.frmMain.UpdateCVPortGUI(nPortNo)
                _L8B.frmMain.CassetteExistUpdate(nPortNo)

            Catch ex As Exception
                WriteLog(ex.ToString)
                _L8B.CIM.PortInfoChanged(nPortNo)
                _L8B.frmMain.UpdateCVPortGUI(nPortNo)
            End Try
        End Sub

        Private Sub PLC_CVPositionGxIDChange(ByVal nPosition As Integer, ByVal strNewGxID As String) Handles L8BPLC.CVPositionGxIDChange
            strNewGxID = MyTrim(strNewGxID)
            WriteLog("PLC_CVPositionGxIDChange Position=" & nPosition & " [" & strNewGxID & "]", LogMessageType.Info)
            UpdateCVPositionGlassID(nPosition, strNewGxID)
            UpdateUnitWIP(clsCIMMain.SECSUNIT.CV)
            If _L8B.Setting.Main.CVSectionPort(nPosition) > 0 AndAlso _L8B.Setting.Main.CVSectionPort(nPosition) <= _L8B.Setting.Main.NumberPort Then
                _L8B.frmMain.RSTControl.CVGUIPort(_L8B.Setting.Main.CVSectionPort(nPosition)).FlowoutGlassID = strNewGxID
            End If
            'remark 20120524
            '_L8B.CIM.UnitInfoChange(mInfo.CV.UnitID)

            Dim vPort As Integer = _L8B.Setting.Main.CVSectionPort(nPosition)
            Dim vPos As Integer = _L8B.Setting.Main.CVSectionID(nPosition)

            If vPort = 0 OrElse vPos = 0 Then
                Exit Sub
            End If

            If mInfo.Port(vPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.LOAD AndAlso MyTrim(strNewGxID).Length = 0 AndAlso vPos = 1 Then
                If mInfo.Port(vPort).FirstNonEmptySlot = mInfo.Port(vPort).GlassFlowCV(vPos).SlotNo AndAlso mInfo.Port(vPort).FirstNonEmptySlot > 0 Then
                    _L8B.CIM.RemoveSlotFromPort(vPort, mInfo.Port(vPort).FirstNonEmptySlot)
                End If
            End If

            If mInfo.Port(vPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.LOAD Then
                If vPos = 1 AndAlso strNewGxID = "" AndAlso MyTrim(mInfo.Port(vPort).GlassFlowCV(vPos).GlassID).Length > 0 Then
                    WriteLog(mInfo.Port(vPort).CassetteMode.ToString & " CV port=" & vPort & " pos=" & vPos)
                    GlassTransfer(eRobotPosition.CVP1 + vPort - 1, 1, eRobotPosition.CVP1 + vPort - 1, 2)
                End If
                If _L8B.Setting.Main.CVOutID(vPort) = 3 Then
                    If vPos = 2 AndAlso strNewGxID = "" AndAlso MyTrim(mInfo.Port(vPort).GlassFlowCV(vPos).GlassID).Length > 0 Then
                        WriteLog(mInfo.Port(vPort).CassetteMode.ToString & " CV port=" & vPort & " pos=" & vPos)
                        GlassTransfer(eRobotPosition.CVP1 + vPort - 1, 2, eRobotPosition.CVP1 + vPort - 1, 3)
                    End If
                End If

            ElseIf mInfo.Port(vPort).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then
                If vPos = 3 AndAlso strNewGxID = "" AndAlso MyTrim(mInfo.Port(vPort).GlassFlowCV(vPos).GlassID).Length > 0 Then
                    WriteLog(mInfo.Port(vPort).CassetteMode.ToString & " CV port=" & vPort & " pos=" & vPos)
                    GlassTransfer(eRobotPosition.CVP1 + vPort - 1, 3, eRobotPosition.CVP1 + vPort - 1, 2)
                End If
                If vPos = 2 AndAlso strNewGxID = "" AndAlso MyTrim(mInfo.Port(vPort).GlassFlowCV(vPos).GlassID).Length > 0 Then
                    WriteLog(mInfo.Port(vPort).CassetteMode.ToString & " CV port=" & vPort & " pos=" & vPos)
                    GlassTransfer(eRobotPosition.CVP1 + vPort - 1, 2, eRobotPosition.CVP1 + vPort - 1, 1)
                End If
            End If
            _L8B.frmMain.GUICVFlowUpdate()

        End Sub

        Private Sub PLC_CVS167dataUploadRequest(ByVal nPortNo As Integer, ByVal LotStructure As L8BIFPRJ.clsS167LotInfo) Handles L8BPLC.CVS167dataUploadRequest
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVS167dataUploadRequest: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            With LotStructure
                WriteLog("CVS167dataUploadRequest port" & nPortNo & " ->" & .CassetteStatus.ToString)
                If .CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.SUSPENDING AndAlso mInfo.Port(nPortNo).fUserCassetteUnLoadRequest Then
                    WriteLog("Ignore report S1F67 as SUSPENDING for port" & nPortNo & " PLC need to SUSPENDING cassette before call [cassetteUnloadrequest] it does not need to report this S1F67")
                    Exit Sub
                End If

                If mInfo.Port(nPortNo).Status = PORTSTATUS.PROCESSWAIT Then
                    If .CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING Then
                        SetPortStatus(nPortNo, PORTSTATUS.PROCESSING)
                    Else
                        'WriteLog("Can't change port" & nPortNo & "staus -> PROCESSING, buz current port status=" & mInfo.Port(nPortNo).Status.ToString)
                    End If
                End If
                If .CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.END Then
                    If mInfo.Port(nPortNo).Status <> PORTSTATUS.LOTFINISHED Then
                        SetPortStatus(nPortNo, PORTSTATUS.LOTFINISHED)
                    End If
                End If

                If .CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.SUSPENDING And (mInfo.Port(nPortNo).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS Or mInfo.Port(nPortNo).CassetteStatus = prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT) Then
                    _L8B.CIM.PortInfoExtra(nPortNo).PortSuspend = True
                End If

                If _L8B.CIM.PortInfoExtra(nPortNo).PortSuspend AndAlso .CassetteStatus <> L8BIFPRJ.clsPLC.eCassetteStatus.SUSPENDING Then
                    _L8B.CIM.PortInfoExtra(nPortNo).PortSuspend = False
                    mInfo.Port(nPortNo).CassetteStatus = .CassetteStatus
                    Select Case .CassetteStatus
                        Case L8BIFPRJ.clsPLC.eCassetteStatus.END

                        Case L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING
                            _L8B.CIM.CassetteStatusChange(nPortNo, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS)
                        Case L8BIFPRJ.clsPLC.eCassetteStatus.SUSPENDING
                        Case L8BIFPRJ.clsPLC.eCassetteStatus.WAIT_PROCESS
                            _L8B.CIM.CassetteStatusChange(nPortNo, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT)
                        Case Else

                    End Select
                ElseIf .CassetteStatus <> L8BIFPRJ.clsPLC.eCassetteStatus.SUSPENDING Then
                    mInfo.Port(nPortNo).CassetteStatus = .CassetteStatus

                End If

                _L8B.frmMain.UpdateCVPortGUI(nPortNo)

                WriteLog("UnloadStatus[" & .CassetteUnloadStatus.ToString & "] PortMode[" & .PortMode & "] PortType[" & .PortType & "]")
            End With
        End Sub

        Private Sub PLC_CVS765datadownloadAck(ByVal nPortNo As Object) Handles L8BPLC.CVS765datadownloadAck
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVS765datadownloadAck: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If
            WriteLog("PLC765datadownloadAck for Port:" & nPortNo)
            If _L8B.CIM.PortInfoExtra(nPortNo).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL Then
                _L8B.CIM.CassetteDataConfirm(nPortNo, 0)
                SetPortStatus(nPortNo, PORTSTATUS.READYTOSTART)
            ElseIf _L8B.CIM.PortInfoExtra(nPortNo).CassetteInMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR Then
                Select Case _L8B.PLC.CVPortMode(nPortNo)
                    Case L8BIFPRJ.clsPLC.ePortMode.LOAD
                    Case L8BIFPRJ.clsPLC.ePortMode.UNLOAD
                        _L8B.CIM.CassetteDataConfirm(nPortNo, 0)
                End Select
                _L8B.CIM.LotInfo(nPortNo).RecipeNeedConfirm = False
                SetPortStatus(nPortNo, PORTSTATUS.READYTOSTART)
            Else
                SetPortStatus(nPortNo, PORTSTATUS.PROCESSWAIT)
            End If
        End Sub

        Private Sub PLC_CVSlotNoUnmatch(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal nUnmatchStatus As L8BIFPRJ.clsPLC.eUnmatchStatus) Handles L8BPLC.CVSlotNoUnmatch
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVSlotNoUnmatch: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If

            Select Case nUnmatchStatus
                Case L8BIFPRJ.clsPLC.eUnmatchStatus.UMS_NOGLASS
                Case L8BIFPRJ.clsPLC.eUnmatchStatus.UMS_REALGLASS
            End Select
        End Sub

        Private Sub PLC_CVStatusChanged(ByVal nNewStatus As L8BIFPRJ.clsPLC.eEQStatus) Handles L8BPLC.CVStatusChanged
            SetCVStatus(nNewStatus)
        End Sub

        Private Sub PLC_CVThroughModeLoaderEmpty(ByVal nPortNo As Integer) Handles L8BPLC.CVLoaderEmpty
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVThroughModeLoaderEmpty: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Return
            End If

            If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U And mInfo.Port(nPortNo).Status = PORTSTATUS.PROCESSING Then
                SetPortStatus(nPortNo, PORTSTATUS.LOTFINISHED)
            End If
        End Sub

        Private Sub PLC_CVThroughModeUnloaderFull(ByVal nPortNo As Integer) Handles L8BPLC.CVUnloaderFull
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVThroughModeUnloaderFull: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Return
            End If
            If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I And mInfo.Port(nPortNo).Status = PORTSTATUS.PROCESSING Then
                SetPortStatus(nPortNo, PORTSTATUS.LOTFINISHED)
            End If
        End Sub

        Private Sub PLC_CVVCRStatusChange(ByVal nVCRPos As Integer, ByVal fEnabled As Boolean) Handles L8BPLC.CVVCRStatusChange
            mInfo.CV.VCREnable(nVCRPos) = fEnabled
            _L8B.frmMain.UpdateCVVCR(nVCRPos)
        End Sub

        Private Sub PLC_EQAlarm(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer) Handles L8BPLC.EQAlarm
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQAlarm: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.EQ1 + nEQIndex - 1, nAlarmCode, IIf(fOnOff, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE))
        End Sub


        ''' <summary>
        ''' EQ Events
        ''' </summary>241

        Private Sub PLC_EQGlassErase(ByVal nEQIndex As Integer, ByVal strGxID As String) Handles L8BPLC.EQGlassErase
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQGlassErase: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            strGxID = MyTrim(strGxID)
            GlassDelete(eRobotPosition.EQ1 + nEQIndex - 1, 1, strGxID)
        End Sub

        Private Sub PLC_EQGlassExistChanged(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean) Handles L8BPLC.EQGlassExistChanged
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQGlassExistChanged: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            WriteLog("PLC_EQGlassExistChanged: EQIndex(=" & nEQIndex & ")->" & fOnOff, LogMessageType.ERR)
            mInfo.EQ(nEQIndex).fGlassExistShow = fOnOff
            _L8B.frmMain.UpdateEQStatus(nEQIndex)
        End Sub

        Private Sub PLC_EQHandOffChanged(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean) Handles L8BPLC.EQHandOffChanged
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQHandOffChanged: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            mInfo.EQ(nEQIndex).HandOff = fOnOff
            _L8B.frmMain.UpdateEQHandOff(nEQIndex)
        End Sub

        Private Sub PLC_EQInProcess(ByVal nEQIndex As Integer, ByVal fOnOff As Boolean) Handles L8BPLC.EQInProcess
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQInProcess: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            mInfo.EQ(nEQIndex).InProcess = fOnOff
            WriteLog(String.Format("EQ{0} InProcess-> {1}", nEQIndex, fOnOff), LogMessageType.Info)
        End Sub

        Private Sub PLC_EQLinkStatus(ByVal nEQIndex As Integer, ByVal nStatus As L8BIFPRJ.clsPLC.eLinkStatus) Handles L8BPLC.EQLinkStatus
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQLinkStatus: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            SetEQLinkStatus(nEQIndex, nStatus)
        End Sub

        Private Sub PLC_EQProcessResult(ByVal nEQIndex As Integer, ByVal nSampleGlassFlag As Integer, ByVal nSlotInfo As Integer, ByVal nProcessResult As L8BIFPRJ.clsPLC.eGlassResult, ByVal strChipGrade As String, ByVal strPSHGroup As String, ByVal strGlassID As String) Handles L8BPLC.EQProcessResult
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQProcessResult: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            strGlassID = MyTrim(strGlassID)

            If strGlassID.Length = 0 Then
                WriteLog("EQProcessResult report Empty GlassID at EQ" & nEQIndex & ". Get self GlassID instand", LogMessageType.ERR)
                strGlassID = mInfo.EQ(nEQIndex).Glass.GlassID
            End If

            If nProcessResult = L8BIFPRJ.clsPLC.eGlassResult.UN_INSPECTION OrElse nProcessResult = L8BIFPRJ.clsPLC.eGlassResult.REVIEW Then
                WriteLog("[IGNORE] EQProcessResult EQ:" & nEQIndex & " GlassID:[" & strGlassID & "] GlassResult=" & nProcessResult.ToString & " ChipGrade=" & strChipGrade, LogMessageType.Info)
                mInfo.EQ(nEQIndex).Glass.EQStartTime(nEQIndex) = ""
                mInfo.EQ(nEQIndex).Glass.EQEndTime(nEQIndex) = ""
            Else
                'WriteLog("EQProcessResult EQ:" & nEQIndex & " GlassID:[" & strGlassID & "] GlassResult=" & nProcessResult.ToString & " ChipGrade=" & strChipGrade & " StartTime=" & mInfo.EQ(nEQIndex).Glass.EQStartTime(nEQIndex) & " EndTime=" & mInfo.EQ(nEQIndex).Glass.EQEndTime(nEQIndex), LogMessageType.Info)
                mInfo.EQ(nEQIndex).Glass.EQEndTime(nEQIndex) = NowString()
                mInfo.EQ(nEQIndex).Glass.PSHGroup = strPSHGroup

                Select Case _L8B.Setting.Main.MachineType
                    Case ClsSetting.EMACHINETYPE.FI
                        mInfo.EQ(nEQIndex).Glass.DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.NO
                        Select Case nProcessResult
                            Case L8BIFPRJ.clsPLC.eGlassResult.GRAY
                                If mInfo.EQ(nEQIndex).Glass.GGRADE = prjSECS.clsEnumCtl.eGlassGrade.OK Then
                                    mInfo.EQ(nEQIndex).Glass.GGRADE = prjSECS.clsEnumCtl.eGlassGrade.GRAY
                                End If

                            Case L8BIFPRJ.clsPLC.eGlassResult.NG
                                mInfo.EQ(nEQIndex).Glass.GGRADE = prjSECS.clsEnumCtl.eGlassGrade.NG

                            Case L8BIFPRJ.clsPLC.eGlassResult.OK
                                If mInfo.EQ(nEQIndex).Glass.GGRADE <> prjSECS.clsEnumCtl.eGlassGrade.NG Then
                                    mInfo.EQ(nEQIndex).Glass.GGRADE = prjSECS.clsEnumCtl.eGlassGrade.OK
                                End If
                        End Select
                        mInfo.EQ(nEQIndex).Glass.ChipGrade = strChipGrade
                        WriteLog("GlassID[" & strGlassID & "] EQ[" & nEQIndex & "] Process GlassGrade->" & mInfo.EQ(nEQIndex).Glass.GGRADE.ToString)

                    Case ClsSetting.EMACHINETYPE.REPAIR, ClsSetting.EMACHINETYPE.COLORREPAIR
                        mInfo.EQ(nEQIndex).Glass.DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.NO
                        mInfo.EQ(nEQIndex).Glass.GGRADE = nProcessResult
                        mInfo.EQ(nEQIndex).Glass.ChipGrade = strChipGrade
                        WriteLog("GlassID[" & strGlassID & "] EQ[" & nEQIndex & "] Process GlassGrade->" & mInfo.EQ(nEQIndex).Glass.GGRADE.ToString)

                    Case Else
                        mInfo.EQ(nEQIndex).Glass.GGRADE = prjSECS.clsEnumCtl.eGlassGrade.NO
                        Select Case nProcessResult
                            Case L8BIFPRJ.clsPLC.eGlassResult.GRAY
                                If mInfo.EQ(nEQIndex).Glass.DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.OK Then
                                    mInfo.EQ(nEQIndex).Glass.DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.REVIEW
                                End If

                            Case L8BIFPRJ.clsPLC.eGlassResult.NG
                                mInfo.EQ(nEQIndex).Glass.DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.NG

                            Case L8BIFPRJ.clsPLC.eGlassResult.OK
                                If mInfo.EQ(nEQIndex).Glass.DGRADE <> prjSECS.clsEnumCtl.eDMQCGrade.NG Then
                                    mInfo.EQ(nEQIndex).Glass.DGRADE = prjSECS.clsEnumCtl.eDMQCGrade.OK
                                End If
                        End Select
                        WriteLog("GlassID[" & strGlassID & "] EQ[" & nEQIndex & "] Process DMQCGrade->" & mInfo.EQ(nEQIndex).Glass.DGRADE.ToString)
                End Select

            End If
            WriteLog("EQProcessResult EQ:" & nEQIndex & " GlassID:[" & strGlassID & "] GlassResult=" & nProcessResult.ToString & " ChipGrade=" & strChipGrade & " StartTime=" & mInfo.EQ(nEQIndex).Glass.EQStartTime(nEQIndex) & " EndTime=" & mInfo.EQ(nEQIndex).Glass.EQEndTime(nEQIndex), LogMessageType.Info)

            _L8B.frmMain.UpdateEQStatus(nEQIndex)

            UpdateUnitWIP(clsCIMMain.SECSUNIT.EQ1 + nEQIndex - 1)
            _L8B.CIM.UnitInfoChange(mInfo.EQ(nEQIndex).UnitID)
        End Sub

        Private Sub PLC_EQProcessStart(ByVal nEQIndex As Integer, ByVal strGlassID As String) Handles L8BPLC.EQProcessStart
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQProcessStart: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            strGlassID = MyTrim(strGlassID)
            WriteLog("EQProcessStart EQ:" & nEQIndex & " GlassID:[" & strGlassID & "]", LogMessageType.Info)

            mInfo.EQ(nEQIndex).Glass.EQStartTime(nEQIndex) = NowString()
            _L8B.frmMain.UpdateEQStatus(nEQIndex)
            UpdateUnitWIP(clsCIMMain.SECSUNIT.EQ1 + nEQIndex - 1)
            _L8B.CIM.UnitInfoChange(clsCIMMain.SECSUNIT.EQ1 + nEQIndex - 1)
        End Sub

        Private Sub PLC_EQRecipeChanged(ByVal nEQIndex As Integer, ByVal nModifyType As L8BIFPRJ.clsPLC.eRecipeModify, ByVal strPPID As String) Handles L8BPLC.EQRecipeChanged
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQRecipeChanged: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            strPPID = MyTrim(strPPID)

            WriteLog("EQRecipeChanged EQ:" & nEQIndex & " PPID:[" & strPPID & "] " & nModifyType.ToString, LogMessageType.Info)
            Select Case nModifyType
                Case L8BIFPRJ.clsPLC.eRecipeModify.ADD
                    _L8B.db.AddEQRecipe(nEQIndex, strPPID)
                    _L8B.CIM.RecipeChangedReport(mInfo.EQ(nEQIndex).UnitID, strPPID)

                Case L8BIFPRJ.clsPLC.eRecipeModify.DELETE
                    _L8B.db.DeleteEQRecipe(nEQIndex, strPPID)

                Case L8BIFPRJ.clsPLC.eRecipeModify.MODIFY
                    If _L8B.db.CheckEQRecipe(nEQIndex, strPPID) Then
                        _L8B.db.ModifyEQRecipe(nEQIndex, strPPID)
                    Else
                        _L8B.db.AddEQRecipe(nEQIndex, strPPID)
                    End If
                    _L8B.CIM.RecipeChangedReport(mInfo.EQ(nEQIndex).UnitID, strPPID)
            End Select
        End Sub

        Private Sub PLC_EQRecipeCheckResult(ByVal nEQIndex As Integer, ByVal fExists As Boolean, ByVal strPPID As String) Handles L8BPLC.EQRecipeCheckResult
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQRecipeCheckResult: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            strPPID = MyTrim(strPPID)
            WriteLog(String.Format("EQRecipeCheckResult: EQ{0}  PPID:[{1}] Exist=[{2}]", nEQIndex, strPPID, fExists), LogMessageType.Info)
            If mInfo.EQ(nEQIndex).fOnCheckingPPID Then
                mInfo.EQ(nEQIndex).fOnCheckingPPID = False
                mInfo.EQ(nEQIndex).OnCheckingPPID = ""
            End If
        End Sub

        Private Sub PLC_EQStatusChanged(ByVal nEQIndex As Integer, ByVal eNewStatus As L8BIFPRJ.clsPLC.eEQStatus) Handles L8BPLC.EQStatusChanged
            If nEQIndex > _L8B.Setting.Main.NumberEQ Then
                WriteLog("PLC_EQStatusChanged: invaid EQIndex(=" & nEQIndex & ")", LogMessageType.ERR)
                Return
            End If
            SetEQStatus(nEQIndex, eNewStatus)
        End Sub

        Private Sub PLC_RobotModeChange(ByVal nMode As L8BIFPRJ.clsPLC.eRSTMode) Handles L8BPLC.RobotModeChange
            mInfo.Robot.Mode = nMode
            WriteLog("RobotModeChange -> " & nMode.ToString, LogMessageType.Info)
            _L8B.frmMain.UpdatePLCMode(mInfo.Robot.Mode.ToString)
        End Sub

        Private Sub PLC_RobotStatusChange(ByVal nNewStatus As L8BIFPRJ.clsPLC.eRSTStatus) Handles L8BPLC.RobotStatusChange
            If mInfo.Robot.Status <> nNewStatus Then
                With _L8B.CIM.UnitInfo(mInfo.Robot.UnitID)
                    Select Case nNewStatus
                        Case L8BIFPRJ.clsPLC.eRSTStatus.DOWN
                            .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_DOWN
                            _L8B.frmMain.LabelRSTstatus.Text = "Robot Down"
                            _L8B.frmMain.GroupBoxMRobot.Enabled = True

                        Case L8BIFPRJ.clsPLC.eRSTStatus.IDLE
                            .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_IDLE
                            _L8B.frmMain.GroupBoxMRobot.Enabled = True

                        Case L8BIFPRJ.clsPLC.eRSTStatus.PM
                            .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_SETUP
                            _L8B.frmMain.GroupBoxMRobot.Enabled = True
                            '_L8B.frmMain.ButtonInitial.Enabled = False
                            '_L8B.frmMain.ButtonInitial.BackColor = Color.Transparent

                        Case L8BIFPRJ.clsPLC.eRSTStatus.RUNNING
                            .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_RUNNING

                        Case L8BIFPRJ.clsPLC.eRSTStatus.SETUP
                            .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_SETUP
                            _L8B.frmMain.ButtonInitial.Enabled = False
                            _L8B.frmMain.ButtonInitial.BackColor = Color.Transparent
                            _L8B.frmMain.GroupBoxMRobot.Enabled = True

                        Case L8BIFPRJ.clsPLC.eRSTStatus.STOPPED
                            .EQStatus = prjSECS.clsEnumCtl.eEQStatus.EQ_STOP
                            _L8B.frmMain.GroupBoxMRobot.Enabled = True
                    End Select
                End With
                mInfo.Robot.Status = nNewStatus
                UpdateUnitWIP(clsCIMMain.SECSUNIT.RST)
                _L8B.CIM.UnitInfoChange(mInfo.Robot.UnitID)
                Try
                    _L8B.CIM.UnitInfo(0).EQStatus = _L8B.CIM.UnitInfo(mInfo.Robot.UnitID).EQStatus
                    _L8B.CIM.UnitInfoChange(0)
                Catch ex As Exception
                    WriteLog(ex.ToString)
                End Try
                _L8B.frmMain.UpdateRobotStatus()
            End If
        End Sub

        Private Sub PLC_RSTAlarm(ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer) Handles L8BPLC.RSTAlarm
            _L8B.Alarm.SetAlarm(ClsAlarm.eUnitPosition.Robot, nAlarmCode, IIf(fOnOff, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR, prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE))
        End Sub

        Private Sub PLC_RSTBufferPortGlassInfoChange(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal fGlassExist As Boolean) Handles L8BPLC.RSTBufferPortGlassInfoChange
            BufferSlotChange(nPortNo, nSlotNo, fGlassExist)
        End Sub

        Public Sub BufferSlotChange(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal fGlassExist As Boolean)
            Try
                Dim BufferGxInfo As L8BIFPRJ.clsBufferGlassInfo = L8BPLC.GetBufferGlassInfo(nPortNo, nSlotNo)
                BufferGxInfo.GlassID = MyTrim(BufferGxInfo.GlassID)
                ''
                mInfo.Buffer(nPortNo).fGlassReview(nSlotNo) = BufferGxInfo.RepairReviewFlag
                WriteLog("RSTBufferPortGlassInfoChange BufferID=" & nPortNo & " Slot=" & nSlotNo & " GlassID=" & BufferGxInfo.GlassID, LogMessageType.EVENT)
                mInfo.Buffer(nPortNo).fGlassExist(nSlotNo) = fGlassExist
                If mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.AUTO Then
                    If MyTrim(mInfo.Buffer(nPortNo).Glass(nSlotNo).GlassID) <> BufferGxInfo.GlassID Then
                        WriteLog("Please Check buffer Glass transfer sequence. Buffer glass unmatch PLC [" & MyTrim(BufferGxInfo.GlassID) & "] and my [" & mInfo.Buffer(nPortNo).Glass(nSlotNo).GlassID & "]")
                        With mInfo.Buffer(nPortNo).Glass(nSlotNo)
                            .GlassID = BufferGxInfo.GlassID
                            .ProductCode = MyTrim(BufferGxInfo.ProductCode)
                            .LotRecipeID = MyTrim(BufferGxInfo.CurrentRecipe)
                            .PTOOLID = MyTrim(BufferGxInfo.PTOOLID)
                            .RWKFLAG = BufferGxInfo.RWKFLAG
                            .SCRPFLAG = BufferGxInfo.SCRPFLAG
                            .EQ1PPID = MyTrim(BufferGxInfo.EPPID(1))
                            .EQ2PPID = MyTrim(BufferGxInfo.EPPID(2))
                            .ProductCategory = BufferGxInfo.ProductCategory
                            .GGRADE = BufferGxInfo.GlassGrade
                            .DGRADE = BufferGxInfo.DMQCGrade
                        End With
                        UpdateUnitWIP(clsCIMMain.SECSUNIT.RST)
                        _L8B.CIM.UnitInfoChange(mInfo.Robot.UnitID)
                    End If
                Else
                    With mInfo.Buffer(nPortNo).Glass(nSlotNo)
                        .GlassID = BufferGxInfo.GlassID
                        .ProductCode = MyTrim(BufferGxInfo.ProductCode)
                        .LotRecipeID = MyTrim(BufferGxInfo.CurrentRecipe)
                        .PTOOLID = MyTrim(BufferGxInfo.PTOOLID)
                        .RWKFLAG = BufferGxInfo.RWKFLAG
                        .SCRPFLAG = BufferGxInfo.SCRPFLAG
                        .EQ1PPID = MyTrim(BufferGxInfo.EPPID(1))
                        .EQ2PPID = MyTrim(BufferGxInfo.EPPID(2))
                        .ProductCategory = BufferGxInfo.ProductCategory
                        .GGRADE = BufferGxInfo.GlassGrade
                        .DGRADE = BufferGxInfo.DMQCGrade
                    End With
                    UpdateUnitWIP(clsCIMMain.SECSUNIT.RST)
                    _L8B.CIM.UnitInfoChange(mInfo.Robot.UnitID)
                End If

                mInfo.Buffer(nPortNo).fGlassReview(nSlotNo) = BufferGxInfo.RepairReviewFlag
                mInfo.Buffer(nPortNo).GlassIDShow(nSlotNo) = BufferGxInfo.GlassID
                mInfo.Buffer(nPortNo).fGlassExistShow(nSlotNo) = fGlassExist
                _L8B.frmMain.UpdateBufferGUI(nPortNo, nSlotNo)
            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
            End Try
        End Sub

        Public bTCPIPConnectFirstTime As Boolean

        Private Sub PLC_TCPIPConnect(ByVal fConnect As Boolean) Handles L8BPLC.TCPIPConnect
            _L8B.frmMain.UpdatePLCConnection(fConnect)
            If Not bTCPIPConnectFirstTime Then
                bTCPIPConnectFirstTime = True
                SyncTime(Now)
                '_L8B.PLC.ChangeIUMode()
                _L8B.PLC.UpdateColorRepairMode()
                _L8B.PLC.RobotArmUse(_L8B.Setting.Main.RobotArmUse)
            End If
        End Sub

        Public Enum eBuzzerMode
            [OFF]
            [BUZZER1]
            [BUZZER2]
        End Enum

        Public Sub Buzzer(ByVal vMode As eBuzzerMode)
            Select Case vMode
                Case eBuzzerMode.OFF
                    BuzzerOff()
                Case eBuzzerMode.BUZZER1
                    L8BPLC.RSTBuzzerControl(1, True)
                Case eBuzzerMode.BUZZER2
                    L8BPLC.RSTBuzzerControl(2, True)
                Case Else
            End Select
        End Sub

        Public Enum eSignalTowerMode
            [NONE]
            [INITIAL]
            [IDLE]
            [DOWN]
            [ALARM]
        End Enum

        Public Sub SECSSignalTowerRed(ByVal LightStatus As L8BIFPRJ.clsPLC.eLightTowerStatus)
            L8BPLC.RSTLightTowerControl(L8BIFPRJ.clsPLC.eLightTower.TOWER_R, LightStatus)
        End Sub

        Public Sub TimeoutSetting()
            L8BPLC.ShowTimeOutForm()
        End Sub

        Public Sub CassetteDummyCancel(ByVal nPort As Integer)
            L8BPLC.CVDummyCancel(nPort)
        End Sub


        Public Sub SyncTime(ByVal vdate As Date)
            Dim mDate As New L8BIFPRJ.clsDateTime

            With mDate
                .nYear = vdate.Year
                .nMonth = vdate.Month
                .nDay = vdate.Day
                .nHour = vdate.Hour
                .nMinute = vdate.Minute
                .nSecond = vdate.Second
                .nWeek = vdate.DayOfWeek
            End With

            L8BPLC.SyncDateTime(mDate)
        End Sub

        Public ReadOnly Property CassetteInPort(ByVal nPort As Integer) As Boolean
            Get
                Return L8BPLC.CVWithCassette(nPort)
            End Get
        End Property

        Public ReadOnly Property CassetteInPort() As Boolean
            Get
                For i As Integer = 1 To MAXPORT
                    If L8BPLC.CVWithCassette(i) Then
                        Return True
                    End If
                Next
                Return False
            End Get
        End Property

        Public Sub PortPause(ByVal nPort As Integer)
            WriteLog("PortPause portID=" & nPort, LogMessageType.Info)
            L8BPLC.CVPortPause(nPort)
        End Sub

        Public Sub PortRelease(ByVal nPort As Integer)
            WriteLog("PortRelease portID=" & nPort, LogMessageType.Info)
            L8BPLC.CVPortResume(nPort)
        End Sub

        Public Sub CVOnline(ByVal bOnline As Boolean, Optional ByVal Index As Integer = 1)
            WriteLog("CVOnline" & bOnline, LogMessageType.Info)
            L8BPLC.CVRSTOnline(bOnline)
        End Sub

        Public Sub EQOnline(ByVal index As Integer, ByVal bOnline As Boolean)
            L8BPLC.EQRSTOnline(index, bOnline)
        End Sub

        Public Sub RobotInterfaceCheck(ByVal bCheck As Boolean)
            L8BPLC.RSTInterfaceCheck(bCheck)
        End Sub

        Public Sub UploadLotData(ByVal nPort As Integer)
            Dim PLCLotInfo As New L8BIFPRJ.clsS765LotInfo

            If _L8B.PLC.CVPortMode(nPort) = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then
                _L8B.CIM.LotInfo(nPort).RecipeName = _L8B.CIM.UnitInfo(0).CPPID
                _L8B.CIM.PortInfo(nPort).CPPID = _L8B.CIM.UnitInfo(0).CPPID
            Else
                'for S1F89 PPID after online report
                _L8B.CIM.PortInfo(nPort).CPPID = _L8B.CIM.LotInfo(nPort).RecipeName
                If MyTrim(_L8B.CIM.LotInfo(nPort).RecipeName).Length > 0 Then
                    _L8B.CIM.UnitInfo(0).CPPID = _L8B.CIM.LotInfo(nPort).RecipeName
                    _L8B.CIM.UnitInfoChange(0)
                    _L8B.CIM.UnitInfo(1).CPPID = _L8B.CIM.LotInfo(nPort).RecipeName
                End If
            End If

            Select Case _L8B.Setting.Main.GlassFlowMode
                Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                    With PLCLotInfo
                        .LineID = _L8B.Setting.ID.Line
                        .ToolID = _L8B.Setting.ID.Tool
                        .CassetteID = _L8B.CIM.LotInfo(nPort).CassetteID
                        .AOIFunction = L8BIFPRJ.clsPLC.eAOIFunction.NONE
                        .CurrentRecipe = _L8B.CIM.LotInfo(nPort).RecipeName                        
                        If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.SAME Then
                            .EPPIDEQ1 = mInfo.Port(nPort).Recipe.PPID
                        Else
                            .EPPIDEQ1 = mInfo.Port(nPort).Recipe.EQRecipe(1).PPID
                            .EPPIDEQ2 = mInfo.Port(nPort).Recipe.EQRecipe(2).PPID
                        End If
                        '.GlassType = mInfo.Port(nPort).Recipe.GlassType
                        .GlassType = mInfo.Port(nPort).Recipe.ColorRepairMode

                        .MeasurementID = _L8B.CIM.LotInfo(nPort).MeasurementID
                        .OperationID = _L8B.CIM.LotInfo(nPort).OperationID
                        .ProductCategory = ProductCategoryConvertCIMToPLC(_L8B.CIM.LotInfo(nPort).ProductCategory)
                        .ProductCode = _L8B.CIM.LotInfo(nPort).ProductCode
                        .RobotSpeed = mInfo.Port(nPort).Recipe.RobotSpeed
                        .RunningMode = _L8B.Setting.Main.GlassFlowMode

                        'for PSH and standalonemacro as butterfly
                        If _L8B.Setting.Main.MachineType = ClsSetting.EMACHINETYPE.ButterFly Then
                            .TargetPosition = mInfo.Port(nPort).Recipe.EQSelection
                        Else
                            .TargetPosition = 1
                        End If

                        .VCRPosition = mInfo.Port(nPort).Recipe.VCRPosition
                    End With

                    For i As Integer = 1 To MAXCASSETTESLOT
                        PLCLotInfo.Slots(i) = New L8BIFPRJ.clsS765SlotInfo
                    Next

                    Dim SlotNo As Integer
                    For i As Integer = 1 To MAXCASSETTESLOT
                        SlotNo = _L8B.CIM.LotInfo(nPort).Slots(i).SlotNo
                        If SlotNo > 0 Then
                            With PLCLotInfo.Slots(SlotNo)
                                .DMQCGrade = _L8B.CIM.LotInfo(nPort).Slots(i).DMQCGradeByString
                                .DMQCToolID = _L8B.CIM.LotInfo(nPort).Slots(i).DMQCToolID
                                Select Case _L8B.CIM.LotInfo(nPort).Slots(i).FIFCFlag
                                    Case prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F
                                        .FIFCFlag = L8BIFPRJ.clsPLC.eFIFCFlag.FI_FORCE
                                    Case Else
                                        .FIFCFlag = L8BIFPRJ.clsPLC.eFIFCFlag.BY_PASS
                                End Select
                                .FIRemarkFlag = _L8B.CIM.LotInfo(nPort).Slots(i).FIRemark
                                .GlassGrade = _L8B.CIM.LotInfo(nPort).Slots(i).GlassGradeByString
                                .GlassID = _L8B.CIM.LotInfo(nPort).Slots(i).GlassID
                                .PLINEID = _L8B.CIM.LotInfo(nPort).Slots(i).ProcessToolID
                                .POPERID = _L8B.CIM.LotInfo(nPort).Slots(i).LastOperationID
                                .PSHGroup = _L8B.CIM.LotInfo(nPort).Slots(i).PSHGroup
                                .PTOOLID = _L8B.CIM.LotInfo(nPort).Slots(i).ProcessToolID
                                .ReworkFlag = _L8B.CIM.LotInfo(nPort).Slots(i).Rework
                                .ScrapFlag = _L8B.CIM.LotInfo(nPort).Slots(i).Scrap
                                .ProcessedFlag = IIf(_L8B.CIM.LotInfo(nPort).Slots(i).ProcFlag, L8BIFPRJ.clsPLC.eProcessedFlag.PROCESS, L8BIFPRJ.clsPLC.eProcessedFlag.NONE)
                            End With
                        End If
                    Next

                Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                    Select Case _L8B.PLC.CVPortMode(nPort)
                        Case L8BIFPRJ.clsPLC.ePortMode.LOAD
                            With PLCLotInfo
                                .LineID = _L8B.Setting.ID.Line
                                .ToolID = _L8B.Setting.ID.Tool
                                .CassetteID = _L8B.CIM.LotInfo(nPort).CassetteID
                                .AOIFunction = L8BIFPRJ.clsPLC.eAOIFunction.NONE
                                .CurrentRecipe = _L8B.CIM.LotInfo(nPort).RecipeName
                                If _L8B.Setting.Main.RecipeMode = ClsSetting.eRECIPEMODE.SAME Then
                                    .EPPIDEQ1 = mInfo.Port(nPort).Recipe.PPID
                                Else
                                    .EPPIDEQ1 = mInfo.Port(nPort).Recipe.EQRecipe(1).PPID
                                    .EPPIDEQ2 = mInfo.Port(nPort).Recipe.EQRecipe(2).PPID
                                End If
                                '.GlassType = mInfo.Port(nPort).Recipe.GlassType
                                .GlassType = mInfo.Port(nPort).Recipe.ColorRepairMode
                                .MeasurementID = _L8B.CIM.LotInfo(nPort).MeasurementID
                                .OperationID = _L8B.CIM.LotInfo(nPort).OperationID
                                .ProductCategory = ProductCategoryConvertCIMToPLC(_L8B.CIM.LotInfo(nPort).ProductCategory)
                                .ProductCode = _L8B.CIM.LotInfo(nPort).ProductCode
                                .RobotSpeed = mInfo.Port(nPort).Recipe.RobotSpeed
                                .RunningMode = _L8B.Setting.Main.GlassFlowMode
                                .TargetPosition = mInfo.Port(nPort).Recipe.EQSelection

                                .VCRPosition = mInfo.Port(nPort).Recipe.VCRPosition
                            End With

                            For i As Integer = 1 To MAXCASSETTESLOT
                                PLCLotInfo.Slots(i) = New L8BIFPRJ.clsS765SlotInfo

                            Next

                            Dim SlotNo As Integer
                            For i As Integer = 1 To MAXCASSETTESLOT
                                SlotNo = _L8B.CIM.LotInfo(nPort).Slots(i).SlotNo
                                If SlotNo > 0 Then

                                    With PLCLotInfo.Slots(SlotNo)
                                        .DMQCGrade = _L8B.CIM.LotInfo(nPort).Slots(i).DMQCGradeByString
                                        .DMQCToolID = _L8B.CIM.LotInfo(nPort).Slots(i).DMQCToolID
                                        Select Case _L8B.CIM.LotInfo(nPort).Slots(i).FIFCFlag
                                            Case prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F
                                                .FIFCFlag = L8BIFPRJ.clsPLC.eFIFCFlag.FI_FORCE
                                            Case Else
                                                .FIFCFlag = L8BIFPRJ.clsPLC.eFIFCFlag.BY_PASS
                                        End Select
                                        .FIRemarkFlag = _L8B.CIM.LotInfo(nPort).Slots(i).FIRemark
                                        .GlassGrade = _L8B.CIM.LotInfo(nPort).Slots(i).GlassGradeByString
                                        .GlassID = _L8B.CIM.LotInfo(nPort).Slots(i).GlassID
                                        .PLINEID = _L8B.CIM.LotInfo(nPort).Slots(i).ProcessToolID
                                        .POPERID = _L8B.CIM.LotInfo(nPort).Slots(i).LastOperationID
                                        .PSHGroup = _L8B.CIM.LotInfo(nPort).Slots(i).PSHGroup
                                        .PTOOLID = _L8B.CIM.LotInfo(nPort).Slots(i).ProcessToolID
                                        .ReworkFlag = _L8B.CIM.LotInfo(nPort).Slots(i).Rework
                                        .ScrapFlag = _L8B.CIM.LotInfo(nPort).Slots(i).Scrap
                                        .ProcessedFlag = IIf(_L8B.CIM.LotInfo(nPort).Slots(i).ProcFlag, L8BIFPRJ.clsPLC.eProcessedFlag.PROCESS, L8BIFPRJ.clsPLC.eProcessedFlag.NONE)
                                    End With
                                End If
                            Next
                        Case L8BIFPRJ.clsPLC.ePortMode.UNLOAD
                            With PLCLotInfo
                                .LineID = _L8B.Setting.ID.Line
                                .ToolID = _L8B.Setting.ID.Tool
                                .CassetteID = _L8B.CIM.LotInfo(nPort).CassetteID
                                WriteLog(String.Format("PLC.S765DataDownload::ProcessFlag({0}, Unloader", nPort), LogMessageType.Info)
                            End With
                    End Select
            End Select

            L8BPLC.S765DataDownload(nPort, PLCLotInfo)
        End Sub

        Public Sub LotStart(ByVal nPort As Integer)
            WriteLog("LotStart port=" & nPort)
            If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                L8BPLC.CVCSTProcessCommand(nPort, _L8B.CIM.LotInfo(nPort).CassetteID, L8BIFPRJ.clsPLC.eProcessCommand.CMD_START, mInfo.Port(nPort).Map, mInfo.Port(nPort).Recipe.SampleGlass)
            ElseIf _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                L8BPLC.CVCSTProcessCommand(nPort, _L8B.CIM.LotInfo(nPort).CassetteID, L8BIFPRJ.clsPLC.eProcessCommand.CMD_START, mInfo.Port(nPort).Map, 0)
            Else
                WriteLog("No Cassette Type Set.", LogMessageType.Warn)
            End If
        End Sub


        Public Sub RobotCommand(ByVal nUnitPos As eRobotPosition, ByVal nSlot As Integer, ByVal Arm As L8BIFPRJ.clsPLC.eRSTArm, ByVal Command As L8BIFPRJ.clsPLC.eRSTAction, ByVal GlassType As L8BIFPRJ.clsPLC.eGlassThickness, ByVal RobotSpeed As L8BIFPRJ.clsPLC.eRobotSpeed)
            Dim eUnitPos As eRobotPosition = nUnitPos
            Dim StageType As L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE
            Dim Position As Integer = 0

            Select Case eUnitPos
                Case eRobotPosition.Buffer1
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.BUFFER
                    Position = 1
                Case eRobotPosition.Buffer2
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.BUFFER
                    Position = 2
                Case eRobotPosition.Buffer3
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.BUFFER
                    Position = 3
                Case eRobotPosition.CVP1
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.CV
                    Position = 1
                Case eRobotPosition.CVP2
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.CV
                    Position = 2
                Case eRobotPosition.CVP3
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.CV
                    Position = 3
                Case eRobotPosition.EQ1
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.EQ
                    Position = 1
                Case eRobotPosition.EQ2
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.EQ
                    Position = 2
                Case eRobotPosition.EQ3
                    StageType = L8BIFPRJ.clsPLC.eRSTPOSITIONTYPE.EQ
                    Position = 3
            End Select

            L8BPLC.RSTCommand(StageType, Arm, Command, Position, nSlot, GlassType, RobotSpeed)
            _L8B.frmMain.GroupBoxMRobot.Enabled = False
        End Sub

        Public Sub RobotPause()
            L8BPLC.RSTPauseRequest()
        End Sub


        Public Sub RobotResume()
            L8BPLC.RSTResumeRequest()
        End Sub

        'Public Sub RunningMode(ByVal eRunningMode As L8BIFPRJ.clsPLC.eEQMode)
        '    L8BPLC.EQRunningMode = eRunningMode
        'End Sub


        Public ReadOnly Property PortType(ByVal nPort As Integer) As L8BIFPRJ.clsPLC.eUnloadType
            Get
                Return L8BPLC.CVPortType(nPort)
            End Get
        End Property

        Public ReadOnly Property EQStatus(ByVal nEQ As Integer) As L8BIFPRJ.clsPLC.eEQStatus
            Get
                Return L8BPLC.EQStatus(nEQ)
            End Get
        End Property

        Public Property EQGUI() As Boolean
            Get
                Return L8BPLC.OpenEQGUISignal
            End Get
            Set(ByVal value As Boolean)
                L8BPLC.OpenEQGUISignal = value
            End Set
        End Property


        Public Property CVGUI() As Boolean
            Get
                Return L8BPLC.OpenCVGUISignal
            End Get
            Set(ByVal value As Boolean)
                L8BPLC.OpenCVGUISignal = value
            End Set
        End Property

        Public Property GeneralGUI() As Boolean
            Get
                Return L8BPLC.OpenGeneralGUISignal
            End Get
            Set(ByVal value As Boolean)
                L8BPLC.OpenGeneralGUISignal = value
            End Set
        End Property

        Private Sub PLC_RSTArmWithGlass(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm, ByVal fWithGlass As Boolean, ByVal strGlassID As String) Handles L8BPLC.RSTArmWithGlass
            strGlassID = MyTrim(strGlassID)
            WriteLog("RSTArmWithGlass " & nArm.ToString & " withGlass=" & fWithGlass & " " & strGlassID)
            If mInfo.Robot.Mode = L8BIFPRJ.clsPLC.eRSTMode.AUTO Then
                mInfo.Robot.GlassIDShow(nArm + 1) = strGlassID
                mInfo.Robot.fGlassExistShow(nArm + 1) = fWithGlass
            Else
                mInfo.Robot.GlassIDShow(nArm + 1) = strGlassID
                mInfo.Robot.fGlassExistShow(nArm + 1) = fWithGlass
                If nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER Then
                    GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER)
                Else
                    GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER)
                End If
            End If

            _L8B.frmMain.UpdateRobotGUI(nArm)
            UpdateUnitWIP(clsCIMMain.SECSUNIT.RST)
            _L8B.CIM.UnitInfoChange(mInfo.Robot.UnitID)

            'For i As Integer = 1 To MaxPort
            '    If MyTrim(mInfo.Port(i).GlassID) = MyTrim(strGlassID) And MyTrim(strGlassID).Length > 0 Then
            '        WriteLog("Robot with glass match GlassID at CV convey [" & strGlassID & "]", LogMessageType.Info)
            '        'mInfo.CV.Glass(i).GlassID = ""
            '        'mInfo.CV.fGlassExist(i) = False
            '        Exit For
            '    End If
            'Next
        End Sub


        Public Sub ChangeIUMode()
            Select Case _L8B.Setting.Main.GlassFlowMode
                Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                    L8BPLC.EQRunningMode = L8BIFPRJ.clsPLC.eEQMode.EQM_MQC
                Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                    L8BPLC.EQRunningMode = L8BIFPRJ.clsPLC.eEQMode.EQM_THROUGH
            End Select
        End Sub

        Public Function CVPortMode(ByVal nPort As Integer) As L8BIFPRJ.clsPLC.ePortMode
            Return L8BPLC.CVPortMode(nPort)
        End Function

        Public Function CVPortType(ByVal nPort As Integer) As L8BIFPRJ.clsPLC.eUnloadType
            Return L8BPLC.CVPortType(nPort)
        End Function

        Public Sub RobotArmUse(ByVal eArm As L8BIFPRJ.clsPLC.eArmMode)
            WriteLog("Robot Use Arm selection " & eArm.ToString)
            L8BPLC.EQArmMode = eArm
        End Sub

        Public Function GetBufferTypeNumber(ByVal nBuffer As Integer, ByVal eBufferType As L8BIFPRJ.clsPLC.eBufferStatus) As Integer
            Dim i = L8BPLC.BufferSlotStatus(nBuffer, 1)
            Return 0
        End Function

        Public Function GetBufferType(ByVal nBuffer As Integer, ByVal nSlot As Integer) As L8BIFPRJ.clsPLC.eBufferStatus
            Return L8BPLC.BufferSlotStatus(nBuffer, nSlot)
        End Function

        Public Sub SetBufferType(ByVal nBuffer As Integer, ByVal nSlot As Integer, ByVal eBufferType As L8BIFPRJ.clsPLC.eBufferStatus)
            WriteLog("[SetBufferType] Buffer=" & nBuffer & " Slot=" & nSlot & " -> [" & eBufferType.ToString & "]")
            L8BPLC.BufferSlotStatus(nBuffer, nSlot) = eBufferType
        End Sub


        'Public Property BufferType(ByVal nBuffer As Integer, ByVal nSlot As Integer) As L8BIFPRJ.clsPLC.eBufferStatus
        '    Get
        '        Return L8BPLC.BufferSlotStatus(nBuffer, nSlot)
        '    End Get
        '    Set(ByVal value As L8BIFPRJ.clsPLC.eBufferStatus)
        '        L8BPLC.BufferSlotStatus(nBuffer, nSlot) = value
        '    End Set
        'End Property

        Public Property BufferSlotType(ByVal nBufferPortNo As Integer, ByVal nSlotNo As Integer) As L8BIFPRJ.clsPLC.eBufferStatus
            Get
                Return L8BPLC.BufferSlotStatus(nBufferPortNo, nSlotNo)
            End Get
            Set(ByVal value As L8BIFPRJ.clsPLC.eBufferStatus)
                WriteLog("Set [BufferSlotType] Buffer=" & nBufferPortNo & " Slot=" & nSlotNo & " -> [" & value.ToString & "]")
                L8BPLC.BufferSlotStatus(nBufferPortNo, nSlotNo) = value
            End Set
        End Property

        Public Property BufferSlotInfo(ByVal nBufferPortNo As Integer, ByVal nSlotNo As Integer) As L8BIFPRJ.clsBufferGlassInfo
            Get
                Return L8BPLC.GetBufferGlassInfo(nBufferPortNo, nSlotNo)
            End Get
            Set(ByVal value As L8BIFPRJ.clsBufferGlassInfo)
                L8BPLC.WriteBufferGlassInfo(nBufferPortNo, nSlotNo) = value
            End Set
        End Property

        Public Sub RSTBufferGlassEraseRequest(ByVal nBuffer As Integer, ByVal nSlot As Integer)
            L8BPLC.RSTBufferGlassEraseRequest(nBuffer, nSlot)
        End Sub

        Private Sub PLC_CVProcessCommandAck(ByVal nPortNo As Integer) Handles L8BPLC.CVProcessCommandAck
            'set timer for processcommand timeout
        End Sub

        Public ReadOnly Property CVPortStatus(ByVal nPort As Integer) As L8BIFPRJ.clsPLC.eCSTCmdStatus
            Get
                '1:loadrequest 2:loadcomplete 3:Unloadrequest 4:unloadcomplete
                Return L8BPLC.CVPortStatus(nPort)
            End Get
        End Property

        Public Sub RemoteModeChange()
            L8BPLC.RSTRemoteStatus = _L8B.CIM.RemoteMode
        End Sub

        Private Sub LightTower(ByVal nLightTower As L8BIFPRJ.clsPLC.eLightTower, ByVal nStatus As L8BIFPRJ.clsPLC.eLightTowerStatus)
            L8BPLC.RSTLightTowerControl(nLightTower, nStatus)
        End Sub

        Private Sub Buzzer(ByVal nBuzzerMode As Integer, ByVal fOnOff As Boolean)
            L8BPLC.RSTBuzzerControl(nBuzzerMode, fOnOff)
        End Sub

        Private Sub BuzzerOff()
            L8BPLC.RSTBuzzerControl(1, False)
            L8BPLC.RSTBuzzerControl(2, False)
        End Sub

        Public Sub SECSInfo(ByVal bOn As Boolean)
            If bOn Then
                LightTower(L8BIFPRJ.clsPLC.eLightTower.TOWER_R, L8BIFPRJ.clsPLC.eLightTowerStatus.TOWER_BLINK)
                Buzzer(eBuzzerMode.BUZZER1, True)
            Else
                LightTower(L8BIFPRJ.clsPLC.eLightTower.TOWER_R, L8BIFPRJ.clsPLC.eLightTowerStatus.TOWER_OFF)
                Buzzer(eBuzzerMode.BUZZER1, False)
            End If
        End Sub

        Public Function UnLoaderType(ByVal nPort As Integer) As L8BIFPRJ.clsPLC.eUnloadType
            Return L8BPLC.CVPortType(nPort)
        End Function

        Public Sub ShowStandardGlassSchedule()
            L8BPLC.ShowSampleGlassSetting()
        End Sub

        Public Sub EQSignalReset(ByVal EQIndex As Integer)
            WriteLog("EQSignalReset:" & EQIndex, LogMessageType.Info)
            L8BPLC.EQTransferReset(EQIndex, True)
        End Sub

        Public Sub CVSignalReset()
            WriteLog("CVSignalReset", LogMessageType.Info)
            L8BPLC.CVTransferReset(True)
        End Sub

        Public Sub RobotInitial()
            'If mInfo.Robot.Status = L8BIFPRJ.clsPLC.eRSTStatus.DOWN Or mInfo.Robot.Status = L8BIFPRJ.clsPLC.eRSTStatus.STOPPED Then 'And L8BPLC.RSTOperationMode <> L8BIFPRJ.clsPLC.eEQRSTMode.RSTMODE_INIT Then
            L8BPLC.RSTSetRobotInitial = True
            _L8B.fBypassInterfaceCheck = False
            'Else
            '    WriteLog("Robot satus <> Down; Does Not need Robot initial.", LogMessageType.SYS)
            'End If
        End Sub

        Public Sub RobotStop()
            WriteLog("RobotStop.", LogMessageType.SYS)
            L8BPLC.RSTSetRobotCommandMode = L8BIFPRJ.clsPLC.eRSTCommandMode.STOP
        End Sub

        Public Sub RobotStart()
            WriteLog("RobotStart.", LogMessageType.SYS)
            L8BPLC.RSTSetRobotCommandMode = L8BIFPRJ.clsPLC.eRSTCommandMode.START
        End Sub

        Public Function RSTRobotCommandMode() As L8BIFPRJ.clsPLC.eRSTCommandMode
            Return L8BPLC.RSTSetRobotCommandMode
        End Function

        Public Property EngineerMode() As Boolean
            Get
                Return L8BPLC.EQGUIEngineerMode
            End Get
            Set(ByVal value As Boolean)
                L8BPLC.CVGUIEngineerMode = value
                L8BPLC.EQGUIEngineerMode = value
            End Set
        End Property

        Public Sub BypassHandshake(ByVal b As Boolean)
            L8BPLC.RSTInterfaceCheck(b)
        End Sub

        Public Property EQIgnoreTimeOut(ByVal index As Integer) As Boolean
            Get
                Return L8BPLC.EQIgnoreTimeout(index)
            End Get
            Set(ByVal value As Boolean)
                L8BPLC.EQIgnoreTimeout(index) = value
            End Set
        End Property

        Public WriteOnly Property WriteArmGlassInfo(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm) As L8BIFPRJ.clsArmGlassInfo
            Set(ByVal value As L8BIFPRJ.clsArmGlassInfo)
                If MyTrim(value.GlassID).Length > 0 Then
                    L8BPLC.WriteArmGlassInfo(nArm) = value
                Else
                    L8BPLC.WriteArmGlassInfo(nArm) = value
                    L8BPLC.RSTArmGlassErase(nArm)
                End If
            End Set
        End Property

        Public WriteOnly Property WriteBufferGlassInfo(ByVal nBuffer As Integer, ByVal nSlot As Integer) As L8BIFPRJ.clsBufferGlassInfo
            Set(ByVal value As L8BIFPRJ.clsBufferGlassInfo)
                If MyTrim(value.GlassID).Length > 0 Then
                    L8BPLC.WriteBufferGlassInfo(nBuffer, nSlot) = value
                Else
                    L8BPLC.RSTBufferGlassEraseRequest(nBuffer, nSlot)
                End If
            End Set
        End Property

        Public Sub BufferGlassErease(ByVal nBuffer As Integer, ByVal nSlot As Integer)
            L8BPLC.RSTBufferGlassEraseRequest(nBuffer, nSlot)
        End Sub

        Public Sub RobotGlassErease(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm)
            L8BPLC.RSTArmGlassErase(nArm)
        End Sub

        Public Sub EQGlassErease(ByVal nEQIndex As Integer)
            Dim NewArmGlassInfo As New L8BIFPRJ.clsArmGlassInfo

            L8BPLC.WriteEQGlassInfo(nEQIndex) = NewArmGlassInfo
        End Sub

        Public Property EQTranfserMode(ByVal nEQindex As Integer) As L8BIFPRJ.clsPLC.eTrfMode
            Get
                Return L8BPLC.EQTranfserMode(nEQindex)
            End Get
            Set(ByVal value As L8BIFPRJ.clsPLC.eTrfMode)
                L8BPLC.EQTranfserMode(nEQindex) = value
            End Set
        End Property

        Public Function EqRecipeCheck(ByVal nEQ As Integer, ByVal zPPID As String) As Boolean
            L8BPLC.EQRecipeCheck(nEQ, zPPID)
        End Function

        Private Sub PLC_CVCassetteRemoveReport(ByVal nPortNo As Integer) Handles L8BPLC.CVCassetteRemoveReport
            WriteLog("PLC CVCassetteRemove Report", LogMessageType.Info)
        End Sub

        Public Function GetArmGlassInfo(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm) As L8BIFPRJ.clsArmGlassInfo
            Return L8BPLC.GetArmGlassInfo(nArm)
        End Function

        Public Function GetBufferGlassInfo(ByVal nBuffer As Integer, ByVal nSlot As Integer) As L8BIFPRJ.clsBufferGlassInfo
            Return L8BPLC.GetBufferGlassInfo(nBuffer, nSlot)
        End Function

        Public Sub CVPortChange(ByVal nPort As Integer, ByVal e As L8BIFPRJ.clsPLC.ePortMode, ByVal nPortType As L8BIFPRJ.clsPLC.eUnloadType)
            L8BPLC.CVPortChange(nPort, e, nPortType)
        End Sub

        Private Sub PLC_CVINIT167data(ByVal nPortNo As Integer, ByVal LotStructure As L8BIFPRJ.clsS167LotInfo) Handles L8BPLC.CVINIT167data
            If nPortNo > _L8B.Setting.Main.NumberPort Then
                WriteLog("PLC_CVCSTLoadRequest: invaid PortNo(=" & nPortNo & ")", LogMessageType.ERR)
                Exit Sub
            End If
            '20101210 for getting wrong CASSETTE ID
            'If MyTrim(LotStructure.CassetteID).Length > 0 Then
            Dim MyINIT765Data As L8BIFPRJ.clsS765LotInfo = L8BPLC.Get765LotData(nPortNo)
            mInfo.Port(nPortNo).CopyFrom167LotInfo(LotStructure, MyINIT765Data)
            mInfo.Port(nPortNo).CopyFrom765LotInfo(MyINIT765Data)
            mInfo.Port(nPortNo).CopyToLotInfo(LotStructure, MyINIT765Data)
            mInfo.Port(nPortNo).CopyToPortInfo()
            _L8B.CIM.PortInfoChanged(nPortNo)

            If mInfo.Port(nPortNo).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.PROCESSING Then
                _L8B.CIM.CassetteStatusChange(nPortNo, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_INPROCESS)
                SetPortStatus(nPortNo, PORTSTATUS.PROCESSING)
            ElseIf mInfo.Port(nPortNo).CassetteStatus = L8BIFPRJ.clsPLC.eCassetteStatus.WAIT_PROCESS Then
                mInfo.Port(nPortNo).Status = PORTSTATUS.PROCESSWAIT
                Try
                    _L8B.CIM.PortInfo(nPortNo).PortStatus = prjSECS.clsEnumCtl.ePortStatus.TSIP_WAITSTART
                    _L8B.CIM.CassetteStatusChange(nPortNo, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT)
                    If _L8B.PLC.CVPortMode(nPortNo) = L8BIFPRJ.clsPLC.ePortMode.UNLOAD Then
                        _L8B.CIM.LotInfo(nPortNo).RecipeName = _L8B.CIM.UnitInfo(0).CPPID
                        _L8B.CIM.PortInfo(nPortNo).CPPID = _L8B.CIM.UnitInfo(0).CPPID
                    Else
                        'for S1F89 PPID after online report
                        _L8B.CIM.PortInfo(nPortNo).CPPID = _L8B.CIM.LotInfo(nPortNo).RecipeName
                        If MyTrim(_L8B.CIM.LotInfo(nPortNo).RecipeName).Length > 0 Then
                            _L8B.CIM.UnitInfo(0).CPPID = _L8B.CIM.LotInfo(nPortNo).RecipeName
                            _L8B.CIM.UnitInfoChange(0)
                            _L8B.CIM.UnitInfo(1).CPPID = _L8B.CIM.LotInfo(nPortNo).RecipeName
                            _L8B.CIM.UnitInfoChange(1)
                        End If
                    End If
                    _L8B.CIM.CassetteStatusChange(nPortNo, prjSECS.clsEnumCtl.eCassetteStatus.CSTA_WAIT)
                Catch ex As Exception
                    WriteLog(ex.ToString)
                End Try
            End If
            'Else
            '    WriteLog("[Ignore] Port" & nPortNo & " CassetteID=[" & LotStructure.CassetteID & "]", LogMessageType.SYS)
            'End If

            If nPortNo = _L8B.Setting.Main.NumberPort Then

                'For i As Integer = 1 To _L8B.Setting.Main.NumberBuffer
                '    For j As Integer = 1 To _L8B.Setting.Main.NumberBufferSlot(i)
                '        GetBufferGlass(i, j)
                '        _L8B.frmMain.UpdateBufferGUI(i, j)
                '    Next
                'Next

                'GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER)
                'GetRobotGlass(L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER)
                '_L8B.frmMain.UpdateCVPortGUI(nPortNo)

                _L8B.frmMain.TimerUpdateRobotMileage.Enabled = True
                _L8B.frmMain.CheckBoxReviewMode.Checked = _L8B.PLC.RepairReviewMode

                '_L8B.Setting.Main.ColorRepairMode = L8BPLC.RSTColorRepairMode
                Static OpenPort As Boolean
                If Not OpenPort Then
                    OpenPort = True
                    _L8B.CIM.L8BCIM.OpenPort()
                End If
            End If
        End Sub

        Private Sub PLC_InterfaceInitializeComplete() Handles L8BPLC.InterfaceInitializeComplete
            WriteLog("PLC_InterfaceInitializeComplete")
            For i As Integer = 1 To _L8B.Setting.Main.NumberPort
                Dim myPortType As L8BIFPRJ.clsPLC.eUnloadType = _L8B.PLC.PortType(i)
                Select Case myPortType
                    Case L8BIFPRJ.clsPLC.eUnloadType.OK
                        _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_OK
                    Case L8BIFPRJ.clsPLC.eUnloadType.NG
                        _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_NG
                    Case L8BIFPRJ.clsPLC.eUnloadType.NA
                        _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_NODEFINE
                    Case Else
                        _L8B.CIM.PortInfo(i).PortCategory = prjSECS.clsEnumCtl.ePortCategory.CATEGORY_MIXED
                End Select
                mInfo.Port(i).UnLoaderType = myPortType
                _L8B.CIM.PortInfoChanged(i)
                _L8B.frmMain.UpdateCVPortGUI(i)
            Next

        End Sub

        Public Property ColorRepairMode() As L8BIFPRJ.clsPLC.eColorRepairMode
            Get
                Return L8BPLC.RSTColorRepairMode
            End Get
            Set(ByVal value As L8BIFPRJ.clsPLC.eColorRepairMode)
                WriteLog("Set ColorRepairRunMode = " & value.ToString, LogMessageType.Info)
                L8BPLC.RSTColorRepairMode = value
            End Set
        End Property

        Public Property BufferSlotDestination(ByVal nBufferPortNo As Integer, ByVal nSlotNo As Integer) As L8BIFPRJ.clsPLC.eNGGXToMachine
            Get
                'Return L8BPLC.getNGGlasstoMachine(nBufferPortNo, nSlotNo)
                Return L8BIFPRJ.clsPLC.eNGGXToMachine.NA
            End Get
            Set(ByVal value As L8BIFPRJ.clsPLC.eNGGXToMachine)
                'WriteLog("Set [BufferSlotDestination] Buffer=" & nBufferPortNo & " Slot=" & nSlotNo & " -> [" & value.ToString & "]")
                L8BPLC.SetNGGlasstoMachine(nBufferPortNo, nSlotNo, value)
            End Set
        End Property

        Public Sub AlarmReset()
            L8BPLC.RSTAlarmReset()
        End Sub

        Public Sub SetRobotMode(ByVal mRSTMode As L8BIFPRJ.clsPLC.eRSTMode)
            L8BPLC.RSTSetRobotMode = mRSTMode
        End Sub

        Private Sub PLC_RobotRobotInitialRequest() Handles L8BPLC.RobotRobotInitialRequest
            '2010/06/01
            mInfo.PM.Continued = False

            'If _L8B.User.Right(Ini.enumUserRight.Initial) Then
            _L8B.frmMain.ButtonInitial.Enabled = True
            _L8B.frmMain.ButtonInitial.BackColor = Color.LightCoral
            _L8B.frmMain.GroupBoxMRobot.Enabled = True
            'End If
        End Sub

        Private Sub PLC_RobotActionCommmandChange(ByVal nCommandChange As L8BIFPRJ.clsPLC.eRSTCommandMode) Handles L8BPLC.RobotActionCommmandChange
            Select Case nCommandChange
                Case L8BIFPRJ.clsPLC.eRSTCommandMode.START
                    _L8B.frmMain.ButtonAutoManual.Enabled = False
                    _L8B.frmMain.ButtonStart.Enabled = True
                    _L8B.frmMain.ButtonStart.Text = "Start"
                    _L8B.frmMain.ButtonStart.BackColor = Color.LightGreen

                Case L8BIFPRJ.clsPLC.eRSTCommandMode.STOP
                    _L8B.frmMain.ButtonAutoManual.Enabled = True
                    _L8B.frmMain.ButtonStart.Enabled = True
                    _L8B.frmMain.ButtonStart.Text = "Stop"
                    _L8B.frmMain.ButtonStart.BackColor = Color.LightPink
            End Select
        End Sub

        Private Sub PLC_EQGlassDataChange(ByVal nEQIndex As Integer, ByVal strGlassID As String) Handles L8BPLC.EQGlassDataChange
            mInfo.EQ(nEQIndex).GlassIDShow = MyTrim(strGlassID)
            _L8B.frmMain.UpdateEQStatus(nEQIndex)
        End Sub

        Public Sub PM(ByVal bOn As Boolean)
            L8BPLC.RSTSetPMMode = bOn
        End Sub

        ''SetBufferDisable   0:Enable 1:Disable
        Public Property BufferSlotEnable(ByVal nBuffer As Integer, ByVal nSlot As Integer) As Boolean
            Get
                Return Not L8BPLC.SetBufferDisable(nBuffer, nSlot)
            End Get

            Set(ByVal value As Boolean)
                WriteLog(String.Format("Set Buffer#{0} slot#{1} enable= {2}", nBuffer, nSlot, value))
                L8BPLC.SetBufferDisable(nBuffer, nSlot) = Not value
            End Set
        End Property


        Private Sub PLC_RSTBufferDisable(ByVal nPortNo As Integer, ByVal nSlotNo As Integer, ByVal fDisable As Boolean) Handles L8BPLC.RSTBufferDisable
            WriteLog(String.Format("Buffer#{0} Slot#{1} {2}", nPortNo, nSlotNo, fDisable.ToString))
            If nSlotNo <= _L8B.Setting.Main.NumberBufferSlot(nPortNo) Then
                _L8B.frmMain.RSTControl.CVGUIBuffer(nPortNo).SlotEnabled(nSlotNo) = Not fDisable
                _L8B.frmMain.RSTControl.CVGUIBufferDialog(nPortNo).SlotEnabled(nSlotNo) = Not fDisable
                _L8B.frmMain.RSTControl.CVGUIBufferEdit(nPortNo).SlotEnabled(nSlotNo) = Not fDisable
            End If
        End Sub

        Public Function RobotArmWithGlass(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm) As Boolean
            Return mInfo.Robot.fGlassExistShow(nArm + 1)
        End Function

        Public Sub SetGlassPreload(ByVal bSet As Boolean)
            WriteLog("Set Preload Glass=" & bSet, LogMessageType.Info)
            L8BPLC.SetRobotStandBy = bSet
        End Sub

        Private Sub PLC_RobotStandBy(ByVal fOnOff As Boolean) Handles L8BPLC.RobotStandBy
            WriteLog("PLC_RobotStandBy->" & fOnOff, LogMessageType.Info)
            '_L8B.frmMain.LabelGlassPreload.Visible = fOnOff
        End Sub

        Private Sub PLC_RobotIOInput(ByRef nItem As L8BIFPRJ.clsPLC.eRobotActualStatus, ByVal fOnOff As Boolean) Handles L8BPLC.RobotIOInput

            Select Case nItem
                Case L8BIFPRJ.clsPLC.eRobotActualStatus.CMD_BUSY
                    If fOnOff Then
                        _L8B.frmMain.LabelRSTstatus.Text = "Robot BUSY"
                        _L8B.frmMain.GroupBoxMRobot.Enabled = False
                    Else
                        _L8B.frmMain.LabelRSTstatus.Text = "Robot READY"
                        _L8B.frmMain.GroupBoxMRobot.Enabled = True
                    End If
                Case L8BIFPRJ.clsPLC.eRobotActualStatus.FORK_EXTEND
                    '_L8B.frmMain.LabelRSTFork.Text = IIf(fOnOff, "Fork Extended", "")

                Case L8BIFPRJ.clsPLC.eRobotActualStatus.LOW_ARM_SENSOR
                    _L8B.frmMain.RstguiCtrlRBT.Sensor(RSTShapFlowGUI.RSTGUICtrlRBT.eUIRBTArm.ARM_LOWER) = fOnOff

                Case L8BIFPRJ.clsPLC.eRobotActualStatus.LOW_ARM_VACCUM
                    _L8B.frmMain.RstguiCtrlRBT.Vacuum(RSTShapFlowGUI.RSTGUICtrlRBT.eUIRBTArm.ARM_LOWER) = fOnOff

                Case L8BIFPRJ.clsPLC.eRobotActualStatus.READY
                    'If fOnOff Then mMain.frmMain.LabelRSTstatus.Text = "Robot READY"
                    _L8B.frmMain.GroupBoxMRobot.Enabled = True

                Case L8BIFPRJ.clsPLC.eRobotActualStatus.SERVO_ON
                    'If fOnOff Then mMain.frmMain.LabelRSTstatus.Text = "Robot SERVO_ON"

                Case L8BIFPRJ.clsPLC.eRobotActualStatus.UP_ARM_SENSOR
                    _L8B.frmMain.RstguiCtrlRBT.Sensor(RSTShapFlowGUI.RSTGUICtrlRBT.eUIRBTArm.ARM_UPPER) = fOnOff

                Case L8BIFPRJ.clsPLC.eRobotActualStatus.UP_ARM_VACCUM
                    _L8B.frmMain.RstguiCtrlRBT.Vacuum(RSTShapFlowGUI.RSTGUICtrlRBT.eUIRBTArm.ARM_UPPER) = fOnOff

            End Select

        End Sub


        '20100608 update after PLC program change
        Private Sub PLC_RobotCommandAck() Handles L8BPLC.RobotCommandAck
            _L8B.frmMain.CheckBoxBypassInterfaceCheck.Checked = False
            WriteLog("PLC_RobotCommandAck", LogMessageType.EVENT)
            PMRobotStart()
        End Sub

        Private Sub PLC_RobotManualComplete() Handles L8BPLC.RobotManualComplete
            _L8B.frmMain.CheckBoxBypassInterfaceCheck.Checked = False
            _L8B.frmMain.GroupBoxMRobot.Enabled = True
            PMRobotComplete()
        End Sub

        Private Sub L8BPLC_RobotMotionStart(ByVal nTarget As L8BIFPRJ.clsPLC.eRobotTarget, ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm, ByVal nCMD As L8BIFPRJ.clsPLC.eRobotCommand, ByVal nAction As L8BIFPRJ.clsPLC.eRobotAction, ByVal nPosition As Integer, ByVal nBufferSlot As Integer) Handles L8BPLC.RobotMotionStart
            _L8B.frmMain.CheckBoxBypassInterfaceCheck.Checked = False
            WriteLog("RobotMotionStart " & nTarget.ToString & " " & nArm.ToString & " " & nCMD.ToString & " " & nAction.ToString & " Pos:" & nPosition.ToString & " Slot:" & nBufferSlot, LogMessageType.Info)
            If _L8B.fBypassInterfaceCheck Then
                '_L8B.fBypassInterfaceCheck = False
            Else
                'kent 2011-03-22
                Try
                    Dim mCMD As String = Now & " " & nTarget.ToString & " " & nArm.ToString & " " & nCMD.ToString & " " & nAction.ToString & " Pos:" & nPosition.ToString & " Slot:" & nBufferSlot
                    _L8B.frmMain.LabelRobotCommand.Text = mCMD
                    '_L8B.frmMain.LabelRobotSpeed.Text = nSpeed.ToString
                    _L8B.frmMain.LabelRobotSpeed.Text = "."
                Catch ex As Exception
                    WriteLog(ex.ToString, LogMessageType.EXCEPTION)
                End Try

                If nCMD <> L8BIFPRJ.clsPLC.eRobotCommand.DO Then
                    Exit Sub
                End If

                Select Case nAction
                    Case L8BIFPRJ.clsPLC.eRobotAction.GET
                        Select Case nTarget
                            Case L8BIFPRJ.clsPLC.eRobotTarget.CV
                                GlassTransfer(eRobotPosition.CVP1 + nPosition - 1, _L8B.Setting.Main.CVOutID(nPosition), eRobotPosition.ROBOT, nArm + 1)
                                If mInfo.Port(nPosition).CassetteMode = L8BIFPRJ.clsPLC.ePortMode.LOAD Then
                                    If mInfo.Port(nPosition).FirstNonEmptySlot = mInfo.Robot.Glass(nArm + 1).SlotNo AndAlso mInfo.Port(nPosition).FirstNonEmptySlot > 0 Then
                                        _L8B.CIM.RemoveSlotFromPort(nPosition, mInfo.Port(nPosition).FirstNonEmptySlot)
                                    End If
                                End If

                            Case L8BIFPRJ.clsPLC.eRobotTarget.EQ
                                GlassTransfer(eRobotPosition.EQ1 + nPosition - 1, 1, eRobotPosition.ROBOT, nArm + 1)

                            Case L8BIFPRJ.clsPLC.eRobotTarget.BUFFER
                                GlassTransfer(eRobotPosition.Buffer1 + nPosition - 1, nBufferSlot, eRobotPosition.ROBOT, nArm + 1)

                        End Select

                    Case L8BIFPRJ.clsPLC.eRobotAction.PUT
                        Select Case nTarget
                            Case L8BIFPRJ.clsPLC.eRobotTarget.CV
                                GlassTransfer(eRobotPosition.ROBOT, nArm + 1, eRobotPosition.CVP1 + nPosition - 1, _L8B.Setting.Main.CVOutID(nPosition))

                            Case L8BIFPRJ.clsPLC.eRobotTarget.EQ
                                GlassTransfer(eRobotPosition.ROBOT, nArm + 1, eRobotPosition.EQ1 + nPosition - 1, 1)

                            Case L8BIFPRJ.clsPLC.eRobotTarget.BUFFER
                                GlassTransfer(eRobotPosition.ROBOT, nArm + 1, eRobotPosition.Buffer1 + nPosition - 1, nBufferSlot)
                        End Select

                    Case L8BIFPRJ.clsPLC.eRobotAction.EXCHANGE
                        Select Case nTarget
                            Case L8BIFPRJ.clsPLC.eRobotTarget.CV
                                GlassTransfer(eRobotPosition.CVP1 + nPosition - 1, _L8B.Setting.Main.CVOutID(nPosition), eRobotPosition.ROBOT, nArm + 1)
                                GlassTransfer(eRobotPosition.ROBOT, AnotherArm(nArm) + 1, eRobotPosition.CVP1 + nPosition - 1, _L8B.Setting.Main.CVOutID(nPosition))

                            Case L8BIFPRJ.clsPLC.eRobotTarget.EQ
                                GlassTransfer(eRobotPosition.EQ1 + nPosition - 1, 1, eRobotPosition.ROBOT, nArm + 1)
                                GlassTransfer(eRobotPosition.ROBOT, AnotherArm(nArm) + 1, eRobotPosition.EQ1 + nPosition - 1, 1)

                            Case L8BIFPRJ.clsPLC.eRobotTarget.BUFFER
                                GlassTransfer(eRobotPosition.Buffer1 + nPosition - 1, nBufferSlot, eRobotPosition.ROBOT, nArm + 1)
                                GlassTransfer(eRobotPosition.ROBOT, AnotherArm(nArm) + 1, eRobotPosition.Buffer1 + nPosition - 1, nBufferSlot)

                        End Select
                End Select
            End If
            '_L8B.frmMain.UpdateRobotGUI(nArm)
            _L8B.frmMain.GUICVFlowUpdate()
        End Sub

        Private Sub L8BPLC_RobotMotionStartComplete(ByVal nTarget As L8BIFPRJ.clsPLC.eRobotTarget, ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm, ByVal nCMD As L8BIFPRJ.clsPLC.eRobotCommand, ByVal nAction As L8BIFPRJ.clsPLC.eRobotAction, ByVal nPosition As Integer, ByVal nBufferSlot As Integer) Handles L8BPLC.RobotMotionStartComplete
            If nCMD <> L8BIFPRJ.clsPLC.eRobotCommand.DO Then
                Exit Sub
            End If
            _L8B.frmMain.LabelRobotSpeed.Text = "."

            If _L8B.fBypassInterfaceCheck Then
                _L8B.fBypassInterfaceCheck = False
            Else
                Select Case nAction
                    Case L8BIFPRJ.clsPLC.eRobotAction.GET, L8BIFPRJ.clsPLC.eRobotAction.EXCHANGE
                        If mInfo.Robot.Glass(nArm + 1).GlassID = "" Then
                            GetRobotGlass(nArm)
                        End If

                    Case L8BIFPRJ.clsPLC.eRobotAction.PUT
                        mInfo.Robot.Glass(nArm + 1).Clear()
                        mInfo.Robot.fGlassExist(nArm + 1) = False
                End Select
            End If
        End Sub

        Private Function AnotherArm(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm) As L8BIFPRJ.clsPLC.eRSTArm
            If nArm = L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER Then
                Return L8BIFPRJ.clsPLC.eRSTArm.ARM_UPPER
            Else
                Return L8BIFPRJ.clsPLC.eRSTArm.ARM_LOWER
            End If

        End Function

        Public Sub CassetteUnloadRequest(ByVal nPort As Integer)
            mInfo.Port(nPort).fUserCassetteUnLoadRequest = True
            If mInfo.Port(nPort).InProcess Then
                mInfo.Port(nPort).InProcessAbort = True
            End If
            If mInfo.Port(nPort).PortFAStatus = ePortFAStatus.LoadComplete Then
                L8BPLC.CVRequestUnloadCST(nPort)
            End If
            '2010.11.02 too fast, wait PLC send 167 upload request to get the Cassette status
            'SetPortStatus(nPort, PORTSTATUS.CVUNLOADREQUEST)
        End Sub

        Public Sub CancelCassette(ByVal nPort As Integer, Optional ByVal bForce As Boolean = False)
            Select Case mInfo.Port(nPort).Status
                Case PORTSTATUS.PRESENT, PORTSTATUS.LOADCOMPLETE, PORTSTATUS.PROCESSING, PORTSTATUS.PROCESSWAIT, PORTSTATUS.READYTOSTART
                    CassetteUnloadRequest(nPort)
                Case Else
                    If bForce Then
                        CassetteUnloadRequest(nPort)
                    Else
                        WriteLog(String.Format("Can't perform CancelCassette({0}), since Port Status = {1}", nPort, mInfo.Port(nPort).Status.ToString), LogMessageType.Warn)
                    End If
            End Select

        End Sub

        Public Function AllOnline() As Boolean
            If Not DebugMode() Then
                For i As Integer = 1 To _L8B.Setting.Main.NumberEQ
                    If Not L8BPLC.EQLink(i) Then
                        Return False
                    End If
                Next

                If Not L8BPLC.CVLink(1) Then
                    Return False
                End If
            End If
            Return True
        End Function

        'add 2010.11.15
        Public Function AnyEQOnline() As Boolean
            If Not L8BPLC.CVLink(1) Then
                Return False
            End If
            For i As Integer = 1 To _L8B.Setting.Main.NumberEQ
                If L8BPLC.EQLink(i) Then
                    Return True
                End If
            Next
        End Function


        Public Sub GetBufferGlass(ByVal vID As Integer, ByVal vSlot As Integer)
            Dim mGlxInfo As L8BIFPRJ.clsBufferGlassInfo = GetBufferGlassInfo(vID, vSlot)

            With mInfo.Buffer(vID).Glass(vSlot)
                '.ChipGrade = mBufferGlassInfo.
                .DGRADE = mGlxInfo.GlassGrade
                '.DMQCToolID =
                .EQ1PPID = MyTrim(mGlxInfo.EPPID(1))
                .EQ2PPID = MyTrim(mGlxInfo.EPPID(2))
                .GlassID = MyTrim(mGlxInfo.GlassID)
                '.LotRecipeID
                .ProductCategory = mGlxInfo.ProductCategory
                .ProductCode = mGlxInfo.ProductCode
                '.PSHGroup =mGlxInfo.
                .RWKFLAG = mGlxInfo.RWKFLAG
                .PTOOLID = MyTrim(mGlxInfo.PTOOLID)
                .RDRAGE = mGlxInfo.DMQCGrade
                WriteLog("GetBufferGlass BufferPort = " & vID & "Slot= " & vSlot & " GlassID = " & .GlassID & " GGrade=" & .GGRADE & " DGrade=" & .DGRADE)
            End With
            mInfo.Buffer(vID).fGlassReview(vSlot) = mGlxInfo.RepairReviewFlag
            mInfo.Buffer(vID).GlassIDShow(vSlot) = MyTrim(mGlxInfo.GlassID)
            mInfo.Buffer(vID).fGlassExistShow(vSlot) = IIf(mInfo.Buffer(vID).GlassIDShow(vSlot).Length > 0, True, False)
        End Sub

        Public Sub GetRobotGlass(ByVal nArm As L8BIFPRJ.clsPLC.eRSTArm)
            Dim GlassInfo As L8BIFPRJ.clsArmGlassInfo = _L8B.PLC.GetArmGlassInfo(nArm)

            With GlassInfo
                mInfo.Robot.Glass(nArm + 1).GlassID = MyTrim(.GlassID)
                mInfo.Robot.Glass(nArm + 1).LotRecipeID = MyTrim(.CurrentRecipe)
                mInfo.Robot.Glass(nArm + 1).EQ1PPID = MyTrim(.EPPID(1))
                mInfo.Robot.Glass(nArm + 1).EQ2PPID = MyTrim(.EPPID(2))
                mInfo.Robot.Glass(nArm + 1).DGRADE = DGradeConvertPLCToCIM(.DMQCGrade)
                mInfo.Robot.Glass(nArm + 1).GGRADE = GGradeConvertPLCToCIM(.GlassGrade)
                mInfo.Robot.Glass(nArm + 1).SCRPFLAG = .GlassScrapFlag
                mInfo.Robot.Glass(nArm + 1).ProductCategory = ProductCategoryConvertPLCToCIM(.ProductCategory)
                mInfo.Robot.Glass(nArm + 1).PTOOLID = MyTrim(.PTOOLID)
                mInfo.Robot.Glass(nArm + 1).SCRPFLAG = .GlassScrapFlag
            End With
            WriteLog("GetRobotGlass Arm = " & nArm.ToString & " GlassID = " & mInfo.Robot.Glass(nArm + 1).GlassID & " GGrade=" & mInfo.Robot.Glass(nArm + 1).GGRADE & " DGrade=" & mInfo.Robot.Glass(nArm + 1).DGRADE)
        End Sub

        Public Sub GetPLC167Slot(ByVal nPort As Integer, ByVal nslot As Integer)
            L8BPLC.GetCSTSlotInfo(nPort, nslot).CopyTo(mInfo.Port(nPort).Glass(nslot))
        End Sub

        Public Function GetRobotAxisMileage() As Integer()
            Return L8BPLC.RobotMileageInfo
        End Function

        Public Sub UpdateColorRepairMode()
            L8BPLC.RSTColorRepairMode = _L8B.Setting.Main.ColorRepairMode
        End Sub

        Private Sub L8BPLC_RobotAlarm(ByVal fOnOff As Boolean, ByVal nAlarmCode As Integer) Handles L8BPLC.RobotAlarm
            If fOnOff Then
                If Not RobotAlarm.Contains(nAlarmCode) Then
                    RobotAlarm.Add(nAlarmCode)
                    RobotAlarm.Sort()
                End If
            Else
                If RobotAlarm.Contains(nAlarmCode) Then
                    RobotAlarm.Remove(nAlarmCode)
                End If
            End If

            WriteLog("Robot Alarm List={" & GetRobotAlarm() & "}")
        End Sub

        Public Function GetRobotAlarm() As String
            Dim tmpStr As String = ""

            If RobotAlarm.Count = 1 Then
                tmpStr = RobotAlarm(0)
            ElseIf RobotAlarm.Count > 1 Then
                tmpStr = RobotAlarm(0)
                For i = 1 To RobotAlarm.Count - 1
                    tmpStr = tmpStr & "," & RobotAlarm(i)
                Next
            End If
            Return tmpStr
        End Function


        Public Property RepairReviewMode() As Boolean
            Get
                If L8BPLC.RepairReviewMode = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    L8BPLC.RepairReviewMode = 1
                Else
                    L8BPLC.RepairReviewMode = 0
                End If
            End Set
        End Property

        Private Sub L8BPLC_INITAlarmComplete() Handles L8BPLC.INITAlarmComplete
            fINITAlarmComplete = True
        End Sub

        Private Sub L8BPLC_RobotCommandPossible(ByVal fOn As Boolean) Handles L8BPLC.RobotCommandPossible
            If fOn Then
                _L8B.frmMain.CheckBoxBypassInterfaceCheck.Checked = False
                _L8B.frmMain.GroupBoxMRobot.Enabled = True
                PMRobotComplete()
            Else
                _L8B.frmMain.GroupBoxMRobot.Enabled = False
            End If

        End Sub

        Private Sub L8BPLC_CVControlStatusA(ByVal nStatus As L8BIFPRJ.clsPLC.eCVControlStatus) Handles L8BPLC.CVControlStatusA
            _L8B.frmMain.UpdateCVControlStatusA(nStatus)
        End Sub

        Private Sub L8BPLC_CVControlStatusR(ByVal nStatus As L8BIFPRJ.clsPLC.eCVControlStatus) Handles L8BPLC.CVControlStatusR
            _L8B.frmMain.UpdateCVControlStatusR(nStatus)
        End Sub
    End Class
End Module

