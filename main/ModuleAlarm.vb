Imports Microsoft.VisualBasic.FileIO
Imports System.Data

Module ModuleAlarm

    Public MainAlarm As New ClsAlarm

    Public Sub InitAlarm()
        MainAlarm.LoadCSVFile()
        MainAlarm.LoadDbAlarm()
        _L8B.Alarm = MainAlarm
    End Sub

    Public Class ClsAlarm

        Private EQAlarmInfo(3) As Dictionary(Of Integer, String())
        Private CVAlarmInfo As Dictionary(Of Integer, String())
        Private SECSAlarmInfo As Dictionary(Of Integer, String())
        Private PLCAlarmInFo As Dictionary(Of Integer, String())

        Private EQcsv(3) As String
        Private CVcsv As String
        Private PLCcsv As String
        Private SECScsv As String

        Dim StartUpAlarmRelease As New ArrayList


        Private Structure AlarmData
            Public src As eUnitPosition
            Public code As Integer
        End Structure

        Private ReadOnly Property AlarmInfo(ByVal Source As eUnitPosition, ByVal Item As Integer) As String()
            Get
                Try
                    Select Case Source
                        Case eUnitPosition.CV
                            Return CVAlarmInfo(Item)
                        Case eUnitPosition.EQ1
                            Return EQAlarmInfo(1)(Item)
                        Case eUnitPosition.EQ2
                            Return EQAlarmInfo(2)(Item)
                        Case eUnitPosition.EQ3
                            Return EQAlarmInfo(3)(Item)
                        Case eUnitPosition.Robot
                            Return PLCAlarmInFo(Item)
                        Case Else
                            Dim str() As String = {Item, "1", "0", "Source not define", ""}
                            Return str
                    End Select
                Catch ex As Exception
                    'WriteLog("Alarm Info not found in " & Source.ToString, LogMessageType.Warn)
                    Dim str() As String = {Item, "1", "0", "Read " & Source.ToString & " csv file error", ""}
                    Return str
                End Try
            End Get

        End Property


        Public ReadOnly Property AlarmInfoEQ(ByVal index As Integer, ByVal Item As Integer) As String()
            Get
                Try
                    Return EQAlarmInfo(index)(Item)
                Catch ex As Exception
                    WriteLog("Alarm Info not found in EQ" & index, LogMessageType.Warn)
                    Dim str() As String = {Item, "1", "0", "Alarm csv file error", ""}
                    Return str
                End Try
            End Get

        End Property

        Private Function SetEQAlarmListFromCSV(ByVal Index As Integer, ByVal sAlarmFile As String) As Boolean
            WriteLog("Load EQAlarm File " & Index, LogMessageType.Info)
            EQcsv(Index) = sAlarmFile
            EQAlarmInfo(Index) = GetCSVfile(sAlarmFile)
            If sAlarmFile = "" OrElse EQAlarmInfo(Index) IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function SetCVAlarmListFromCSV(ByVal sAlarmFile As String) As Boolean
            WriteLog("Load CVAlarm File ", LogMessageType.Info)
            CVcsv = sAlarmFile
            CVAlarmInfo = GetCSVfile(sAlarmFile)
            If sAlarmFile = "" OrElse CVAlarmInfo IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function SetPLCAlarmListFromCSV(ByVal sAlarmFile As String) As Boolean
            WriteLog("Load PLCAlarm File ", LogMessageType.Info)
            PLCcsv = sAlarmFile
            PLCAlarmInFo = GetCSVfile(sAlarmFile)
            If sAlarmFile = "" OrElse PLCAlarmInFo IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function SetRobotAlarmListFromCSV(ByVal sAlarmFile As String) As Boolean
            WriteLog("Load RobotAlarm File ", LogMessageType.Info)
            PLCcsv = sAlarmFile
            PLCAlarmInFo = GetCSVfile(sAlarmFile)
            If sAlarmFile = "" OrElse PLCAlarmInFo IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function SetSECSAlarmListFromCSV(ByVal sAlarmFile As String) As Boolean
            WriteLog("Load SECSAlarm File ", LogMessageType.Info)
            SECScsv = sAlarmFile
            SECSAlarmInfo = GetCSVfile(sAlarmFile)
            If sAlarmFile = "" OrElse SECSAlarmInfo IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function LoadCSVFile() As Boolean
            Dim retEQ1 As Boolean = SetEQAlarmListFromCSV(1, _L8B.Setting.AlarmFile.EQ1)
            Dim retEQ2 As Boolean = SetEQAlarmListFromCSV(2, _L8B.Setting.AlarmFile.EQ2)
            Dim retEQ3 As Boolean = SetEQAlarmListFromCSV(3, _L8B.Setting.AlarmFile.EQ3)
            Dim retCV As Boolean = SetCVAlarmListFromCSV(_L8B.Setting.AlarmFile.CV)
            Dim retPLC As Boolean = SetPLCAlarmListFromCSV(_L8B.Setting.AlarmFile.PLC)
            Dim retSECS As Boolean = SetSECSAlarmListFromCSV(_L8B.Setting.AlarmFile.SECS)

            Return retEQ1 AndAlso retEQ2 AndAlso retEQ3 AndAlso retCV AndAlso retPLC AndAlso retSECS
        End Function

        Private Function GetCSVfile(ByVal sAlarmFile As String) As Dictionary(Of Integer, String())
            Dim LineReader As String
            Dim LineParser() As String

            Try
                If Not My.Computer.FileSystem.FileExists(sAlarmFile) Then
                    WriteLog("CSV File Not Exists " & sAlarmFile)
                    Return Nothing
                End If
                Dim fileReader = My.Computer.FileSystem.OpenTextFileReader(sAlarmFile)

                Dim DictionaryAlarm As New Dictionary(Of Integer, String())

                While Not fileReader.EndOfStream
                    LineReader = fileReader.ReadLine
                    LineParser = LineReader.Split(New [Char]() {","c})
                    If Val(LineParser(0)) > 0 Then
                        DictionaryAlarm.Add(Val(LineParser(0)), LineParser)
                    End If
                End While

                fileReader.Close()
                fileReader.Dispose()
                Return DictionaryAlarm
            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
                Return Nothing
            End Try

        End Function

        'Cassette Station
        Public Enum CSCSTATESTATUS
            [OldState] = 100
            [NONE] = 0
            [CLASSLOAD]
            [INITIALIZING]
            [INITCOMPLETE]
            [SERVERSTART]
            [CLIENTONLINE]
            [REONLINE]
            [CONNECT]
            [OFFLINE]
            [CLIENTOFFLINE]
            [SERVERDOWN]
            [CLASSUNLOAD]
        End Enum

        Public Enum SIGNALTOWERMODE
            [NONE] = 0
            [UNDERSTARTING]
            [INPRODUCTION]
            [ALARM]
            [WARNNING]
            [READY]
            [INTROUBLE]
            [BYEQUIPMENT]
            [INFO]
        End Enum

        Public Enum BUZZERTYPE
            [TYPE1]
            [TYPE2]
        End Enum

        Public Enum eUnitPosition
            [NONE] = 0
            [Port1]
            [Port2]
            [Port3]
            [Buffer1]
            [Buffer2]
            [Buffer3]
            [EQ1]
            [EQ2]
            [EQ3]
            [CV]
            [Robot]
            [SECS]
        End Enum

        Public Enum ALARMMODE
            [NA] = 0
            [DangerForHuman]
            [EquipmentError]
            [PamameterOverflowCauseProcessError]
            [PamameterOverflowCauseEquipmentCantWork]
            [CanNotRecoverTrouble]
            [EquipStatusWarning]
            [UnknownError]
        End Enum

        Public Class STRUCTURE_ALARM
            Public Source As eUnitPosition
            Public [Type] As prjSECS.clsEnumCtl.eAlarmType
            Public Status As prjSECS.clsEnumCtl.eAlarmFlag
            Public Code As Integer
            Public Message As String
            Public OccurrTime As String
            Public ReleaseTime As String
            Public DBIndex As Integer
            Public fReportRelease As Boolean
            Public fReportOccurr As Boolean
            Public Remark As String
        End Class

        Public AlarmList As New Dictionary(Of Integer, STRUCTURE_ALARM)
        Public unReportAlarmList As New ArrayList

        Public Sub SetAlarm(ByVal nSrc As eUnitPosition, ByVal nCode As Integer, ByVal eStatus As prjSECS.clsEnumCtl.eAlarmFlag)
            Dim myAlarmID As Integer = nSrc * 512 + nCode
            If eStatus = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR Then
                If AlarmList.ContainsKey(myAlarmID) Then
                    WriteLog("Alarm exist [" & myAlarmID & "]")
                Else
                    Dim vAlarm As STRUCTURE_ALARM = GetAlarmInfo(nSrc, nCode)
                    vAlarm.DBIndex = _L8B.db.InsertAlarm(nSrc.ToString, nCode, vAlarm.Message, IIf(vAlarm.Type = prjSECS.clsEnumCtl.eAlarmType.TYPE_ALARM, "Alarm", "Warn"), Now)
                    AlarmList.Add(myAlarmID, vAlarm)
                    WriteLog("Alarm Occurr for AlarmID(" & myAlarmID & ") msg{" & AlarmList(myAlarmID).Message & "}")
                    If Not _L8B.PLC.fINITAlarmComplete Then
                        RemoveStartUpAlarmList(nSrc, nCode)
                    End If
                    _L8B.CIM.Alarm(GetUnitID(nSrc), myAlarmID)
                End If
            ElseIf eStatus = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE Then
                AlarmList(myAlarmID).ReleaseTime = GetAUODateTime(Now)
                AlarmList(myAlarmID).Status = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE
                _L8B.db.UpdateAlarm(AlarmList(myAlarmID).DBIndex, AlarmList(myAlarmID).ReleaseTime)
                WriteLog("Alarm Release for AlarmID(" & myAlarmID & ") msg{" & AlarmList(myAlarmID).Message & "}")
            End If

            If eStatus = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE Then
                If _L8B.Alarm.AlarmList(myAlarmID).fReportOccurr Then
                    If _L8B.CIM.Alarm(GetUnitID(nSrc), myAlarmID) Then
                        AlarmList.Remove(myAlarmID)
                    Else
                        If eStatus = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE Then
                            unReportAlarmList.Add(AlarmList(myAlarmID))
                            AlarmList.Remove(myAlarmID)
                        End If
                    End If
                Else
                    AlarmList.Remove(myAlarmID)
                End If
            End If

            _L8B.frmMain.UpdateListViewAlarm()
            _L8B.frmMain.UpdateDataGridViewAlarm()
        End Sub

        Public Function GetAlarmInfo(ByVal eSrc As eUnitPosition, ByVal nAlarmCode As Integer) As STRUCTURE_ALARM
            Dim mAlarm As New STRUCTURE_ALARM
            'AlarmCode, Unit, Level, Description, Type
            Dim Str() As String = AlarmInfo(eSrc, nAlarmCode)

            With mAlarm
                .Source = eSrc
                .Code = nAlarmCode
                .Status = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_OCCUR
                If Str.Length > 2 Then .Type = IIf(Val(Str(2)) = 2, prjSECS.clsEnumCtl.eAlarmType.TYPE_ALARM, prjSECS.clsEnumCtl.eAlarmType.TYPE_WARNING)
                If Str.Length > 3 Then .Message = Str(3)
                If Str.Length > 4 Then .Remark = Str(4).Replace("_", vbCrLf)
                '.Type = Val(Str(4))
                .OccurrTime = GetAUODateTime(Now)
            End With
            Return mAlarm
        End Function

        Public Sub LoadDbAlarm()
            Dim dt As DataTable = _L8B.db.QueryAlarmOccurr
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim mIndex As Integer = MyTrim(RowField(dt.Rows(i), "Index"))
                    Dim mSource As eUnitPosition = System.Enum.Parse(GetType(eUnitPosition), MyTrim(RowField(dt.Rows(i), "Source")))
                    Dim mCode As Integer = Val(MyTrim(RowField(dt.Rows(i), "Code")))
                    Dim vAlarm As STRUCTURE_ALARM = GetAlarmInfo(mSource, mCode)
                    Dim mOccurrTime As String = MyTrim(RowField(dt.Rows(i), "OccurreTime"))
                    Dim mfReportOccurr As String = MyTrim(RowField(dt.Rows(i), "fReportOccurr"))
                    Dim myAlarmID As Integer = mSource * 512 + mCode

                    vAlarm.DBIndex = mIndex

                    If mOccurrTime <> "" Then
                        vAlarm.OccurrTime = mOccurrTime
                    End If
                    If mfReportOccurr = "Y" Then
                        vAlarm.fReportOccurr = True
                    End If

                    If AlarmList.ContainsKey(myAlarmID) Then
                        WriteLog("Duplicate Alarm Code DbIndex: " & mIndex & " with " & AlarmList(myAlarmID).Source.ToString & " " & AlarmList(myAlarmID).Code)
                    Else
                        AlarmList.Add(myAlarmID, vAlarm)

                        Dim AlarmStartData As AlarmData
                        AlarmStartData.src = mSource
                        AlarmStartData.code = mCode
                        StartUpAlarmRelease.Add(AlarmStartData)
                    End If
                Next
            End If

        End Sub

        Public Sub RemoveStartUpAlarmList(ByVal nSrc As eUnitPosition, ByVal nCode As Integer)
            If StartUpAlarmRelease.Count > 0 Then
                For i As Integer = StartUpAlarmRelease.Count - 1 To 0 Step -1
                    Dim AlarmData As AlarmData = StartUpAlarmRelease(i)
                    If AlarmData.src = nSrc AndAlso AlarmData.code = nCode Then
                        WriteLog("RemoveStartUpAlarm:" & nSrc.ToString & " Code=" & nCode)
                        StartUpAlarmRelease.RemoveAt(i)
                    End If
                Next
            End If

        End Sub

        Private Sub ReleaseStartUpAlarmReleaseList()        'report CIM
            If StartUpAlarmRelease.Count > 0 Then
                For i As Integer = StartUpAlarmRelease.Count - 1 To 0 Step -1
                    Dim AlarmData As AlarmData = StartUpAlarmRelease(i)
                    Dim myAlarmID As Integer = AlarmData.src * 512 + AlarmData.code
                    If AlarmList.ContainsKey(myAlarmID) Then
                        AlarmList(myAlarmID).Status = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE
                        If _L8B.CIM.Alarm(GetUnitID(AlarmData.src), myAlarmID) Then
                            StartUpAlarmRelease.RemoveAt(i)
                            WriteLog("Remove Alarm from StartUpAlarmReleaseList after report Alarm release")
                        End If
                    Else
                        StartUpAlarmRelease.RemoveAt(i)
                        WriteLog("Remove Alarm from StartUpAlarmReleaseList for alarm not exist")
                    End If
                Next
            End If
        End Sub

        Public Sub ReportAlarm()
            Dim myAlarmID As Integer

            ReleaseStartUpAlarmReleaseList()

            For Each Pair As KeyValuePair(Of Integer, STRUCTURE_ALARM) In AlarmList
                If Not Pair.Value.fReportOccurr AndAlso Not Pair.Value.fReportRelease Then
                    If Pair.Value.OccurrTime <> "" AndAlso Pair.Value.ReleaseTime <> "" Then
                        AlarmList.Remove(Pair.Key)
                    End If
                ElseIf Pair.Value.fReportOccurr AndAlso Pair.Value.fReportRelease Then
                    AlarmList.Remove(Pair.Key)
                End If
            Next

            For Each Pair As KeyValuePair(Of Integer, STRUCTURE_ALARM) In AlarmList
                myAlarmID = Pair.Value.Source * 512 + Pair.Value.Code
                If Not Pair.Value.fReportOccurr Then
                    _L8B.CIM.Alarm(GetUnitID(Pair.Value.Source), myAlarmID)
                ElseIf Pair.Value.ReleaseTime <> "" AndAlso Not Pair.Value.fReportRelease Then
                    Pair.Value.Status = prjSECS.clsEnumCtl.eAlarmFlag.TYPE_RELEASE
                    _L8B.CIM.Alarm(GetUnitID(Pair.Value.Source), myAlarmID)
                End If
            Next

        End Sub

    End Class

End Module
