Module ModuleSetting
    Public Const MaxColumnNum = 20

    ' API functions
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt Lib "kernel32.dll" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As Integer, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer

    Public SettingMain As New ClsSetting


    Public Function ReadINIString(ByVal Section As String, ByVal Key As String, Optional ByVal [Default] As String = "") As String
        ' Returns a string from your INI file
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)
        intCharCount = GetPrivateProfileString(Section, Key, [Default], objResult, objResult.Capacity, SettingMain.L8BIniFileName)
        If intCharCount > 0 Then
            Return Left(objResult.ToString, intCharCount)
        Else
            Return ""
        End If
    End Function

    Public Function WriteINIString(ByVal sSection As String, ByVal sKey As String, ByVal sValue As String) As Integer
        Dim sTemp As String = sValue
        'Replace any CR/LF characters with spaces
        For n As Integer = 1 To Len(sValue)
            If Mid$(sValue, n, 1) = vbCr Or Mid$(sValue, n, 1) = vbLf Then Mid$(sValue, n) = " "
        Next n
        Return WritePrivateProfileString(sSection, sKey, sTemp, SettingMain.L8BIniFileName)
    End Function

    Private Sub Flush()
        FlushPrivateProfileString(0, 0, 0, SettingMain.L8BIniFileName)
    End Sub

    Public Sub InitSetting()
        _L8B.Setting = SettingMain
        _L8B.Setting.InitialSetting()
        _L8B.Setting.IniLoad(INIFilePath & "\L8BRSTsa.ini")
    End Sub


    Public Class ClsSetting

        Public Class cUser
            Public Enum enumUserRight
                [NONE]
                [Recipe] = 1
                [TimeOut]
                [Log]
                [HSMS]
                [Link]
                [Others]
                [Exit]

                [General]
                [AlarmHistory]
                [ShopFloor]
                [Buffer]
                [CVIOMonitor]
                [EQIOMonitor]
                [Manual]

                [ChangeMode]
                [Initial]
                [ResetSignal]
                [GO]
                [LookBack]

                [Authority]
                [Maintain]
                [MachineSetting]

                [UIMode]
                [STDGlassSchedule]
                [BufferType]
                [BufferDest]
                [AddGlass]
                [DeleteGlass]

                [DisableBufferSlot]
                [EnableBufferSlot]
                [ColorRepairMode]

            End Enum

            Public Name As String
            Public bRight() As Boolean

            Public ReadOnly Property Right(ByVal e As enumUserRight) As Boolean
                Get
                    Try
                        If bRight Is Nothing Then
                            Return False
                        ElseIf bRight.Length = 1 Then
                            Return False
                        Else
                            Return bRight(e)
                        End If

                    Catch ex As Exception
                        Return False
                    End Try
                End Get
            End Property

            Public Function Login(ByVal mName As String, ByVal mPassword As String) As Boolean
                bRight = GetUserAutherity(mName, mPassword)
                Name = mName
                Return IIf(bRight.Length > 0, True, False)
            End Function

            Public Sub Logout()
                Name = ""
                ReDim bRight(0)
            End Sub

            Public Function GetUserAutherity(ByVal vUser As String, ByVal vPassword As String) As Boolean()
                Dim bAutherity(enumUserRight.[ColorRepairMode]) As Boolean
                Dim Section As String = "Users"
                If vPassword = ReadINIString(Section, vUser & "Password") Then
                    Dim Autherity() As String = ReadINIString(Section, vUser & "Autherity").Split(",")
                    ReDim bAutherity(Autherity.Length - 1)

                    For i As Integer = 1 To Autherity.Length - 1
                        bAutherity(i) = Autherity(i)
                    Next
                Else
                    For i As Integer = 1 To bAutherity.Length - 1
                        bAutherity(i) = False
                    Next
                End If

                Return bAutherity
            End Function
        End Class

        Public Enum eRECIPEMODE
            [NONE] = -1
            [SAME]
            [DIFFERENT]
        End Enum

        Public Enum EMACHINETYPE
            [NONE] = -1
            [ButterFly]
            [FI]
            [REPAIR]
            [COLORREPAIR]
        End Enum

        Public Structure MaintainSettingType
            Friend Shared Section As String = "Maintain"
            Public Name As String
            Public Phone As String
        End Structure

        Public Structure AlarmFileType
            Friend Shared Section As String = "AlarmFile"
            Public EQ1 As String
            Public EQ2 As String
            Public EQ3 As String
            Public CV As String
            Public SECS As String
            Public PLC As String
        End Structure

        Public Structure ExternaIniFileType
            Friend Shared Section As String = "ExternaIniFile"
            Public SECS As String
            Public CIM As String
            Public PLC As String
            Public TOEQ As String
            Public TOCV As String
        End Structure

        Public Structure TOOLIDType
            Friend Shared Section As String = "ID"
            Public Line As String
            Public Tool As String
            Public RST As String
            Public EQ1 As String
            Public EQ2 As String
            Public EQ3 As String
            Public CV As String
        End Structure

        Public Structure SettingMainType
            Friend Shared Section As String = "MainType"
            Public MachineType As EMACHINETYPE
            Public RecipeMode As eRECIPEMODE
            Public GlassFlowMode As Integer 'prjsecs.clsEnumCtl.ePortType
            Public RobotArmUse As Integer 'L8BIFPRJ.clsPLC.eArmMode
            Public NumberEQ As Integer
            Public NumberCV As Integer
            Public NumberPort As Integer
            Public NumberBuffer As Integer
            Public NumberBufferSlot() As Integer
            Public Pass As Integer
            Public TotalPass As Integer
            Public PortType() As L8BIFPRJ.clsPLC.ePortMode
            Public BufferSlotType()()() As L8BIFPRJ.clsPLC.eBufferStatus
            Public EQRecipeCheck() As Boolean
            Public fCIMShowColumn() As Boolean  'add to show show Glass Info inside cassette
            Public UnloaderOfflineAutoStart As Boolean
            Public GlassPreload As Boolean
            Public FIReportGGradeRecipeEndChar As String
            Public DisableRemark(,) As String
            Public LogDayKeep As Integer
            Public ColorRepairMode As L8BIFPRJ.clsPLC.eColorRepairMode
            Public SuperPassword As String
            Public CVSectionPort() As Integer
            Public CVSectionID() As Integer
            Public CVOutID() As Integer
            Public MacroEQID As Integer
        End Structure


        Public Structure DataBaseSettingType
            Friend Shared Section As String = "DataBaseSetting"
            Public DataProvide As String
            Public ConnectionString As String
            Public SqliteDbFile As String
        End Structure

        Public mL8BIniFileName As String
        Public Main As SettingMainType
        Public Maintain As MaintainSettingType
        Public AlarmFile As AlarmFileType
        Public ExtraIniFile As ExternaIniFileType
        Public DataBaseSetting As DataBaseSettingType
        Public ID As TOOLIDType
        Public User As New cUser

        Public Property L8BIniFileName() As String
            Get
                Return mL8BIniFileName
            End Get
            Set(ByVal value As String)
                mL8BIniFileName = value
            End Set
        End Property

        Public Property SlotType(ByVal nMode As eRunningMode, ByVal nBuffer As Integer, ByVal nSlot As Integer) As L8BIFPRJ.clsPLC.eBufferStatus
            Get
                Try
                    If nMode > eRunningMode.TAPEINK OrElse nBuffer > Main.NumberBuffer OrElse nSlot > Main.NumberBufferSlot(nBuffer) Then
                        Return L8BIFPRJ.clsPLC.eBufferStatus.NONE
                    End If
                    Return Main.BufferSlotType(nMode)(nBuffer)(nSlot)
                Catch ex As Exception
                    WriteLog(ex.ToString)
                    Return L8BIFPRJ.clsPLC.eBufferStatus.NONE
                End Try
            End Get

            Set(ByVal value As L8BIFPRJ.clsPLC.eBufferStatus)
                Try
                    If nMode > eRunningMode.TAPEINK OrElse nBuffer > Main.NumberBuffer OrElse nSlot > Main.NumberBufferSlot(nBuffer) Then
                        WriteLog("[Fail] SlotType Property set out of range", LogMessageType.ERR)
                    Else
                        Main.BufferSlotType(nMode)(nBuffer)(nSlot) = value
                    End If
                Catch ex As Exception
                    WriteLog(ex.ToString)
                End Try
            End Set
        End Property

        Public Sub IniSave()
            With Maintain
                Dim Section As String = MaintainSettingType.Section
                Dim ret = WriteINIString(Section, "Name", .Name)
                WriteINIString(Section, "Phone", .Phone)
            End With

            With _L8B.Setting.AlarmFile
                Dim Section As String = AlarmFileType.Section
                WriteINIString(Section, "EQ1", .EQ1)
                WriteINIString(Section, "EQ2", .EQ2)
                WriteINIString(Section, "EQ3", .EQ3)
                WriteINIString(Section, "CV", .CV)
                WriteINIString(Section, "PLC", .PLC)
                WriteINIString(Section, "SECS", .SECS)
            End With

            With _L8B.Setting.ExtraIniFile
                Dim Section As String = ExternaIniFileType.Section
                WriteINIString(Section, "SECSL", .SECS)
                WriteINIString(Section, "CIM", .CIM)
                WriteINIString(Section, "PLC", .PLC)
                WriteINIString(Section, "TOEQ", .TOEQ)
                WriteINIString(Section, "TOCV", .TOCV)
            End With

            With DataBaseSetting
                Dim Section As String = DataBaseSettingType.Section
                WriteINIString(Section, "DataProvide", .DataProvide)
                WriteINIString(Section, "SqliteDbFile", .SqliteDbFile)
                WriteINIString(Section, "ConnectionString", .ConnectionString)
            End With

            With ID
                Dim Section As String = TOOLIDType.Section
                WriteINIString(Section, "Line", .Line)
                WriteINIString(Section, "Tool", .Tool)
                WriteINIString(Section, "Rst", .RST)
                WriteINIString(Section, "EQ1", .EQ1)
                WriteINIString(Section, "EQ2", .EQ2)
                WriteINIString(Section, "EQ3", .EQ3)
                WriteINIString(Section, "CV", .CV)
            End With

            With Main
                Dim Section As String = SettingMainType.Section
                WriteINIString(Section, "RecipeMode", .RecipeMode)
                WriteINIString(Section, "GlassFlowMode", .GlassFlowMode)
                WriteINIString(Section, "NumberEQ", .NumberEQ)
                WriteINIString(Section, "NumberCV", .NumberCV)
                WriteINIString(Section, "NumberPort", .NumberPort)
                WriteINIString(Section, "NumberBuffer", .NumberBuffer)
                WriteINIString(Section, "NumberBufferSlot1", .NumberBufferSlot(1))
                WriteINIString(Section, "NumberBufferSlot2", .NumberBufferSlot(2))
                WriteINIString(Section, "NumberBufferSlot3", .NumberBufferSlot(3))
                WriteINIString(Section, "MachineType", .MachineType)
                WriteINIString(Section, "RobotArmUse", .RobotArmUse)
                WriteINIString(Section, "PortType1", .PortType(1))
                WriteINIString(Section, "PortType2", .PortType(2))
                WriteINIString(Section, "PortType3", .PortType(3))

                WriteINIString(Section, "EQrecipeCheck1", .EQRecipeCheck(1))
                WriteINIString(Section, "EQrecipeCheck2", .EQRecipeCheck(2))
                WriteINIString(Section, "EQrecipeCheck3", .EQRecipeCheck(3))

                WriteINIString(Section, "UnloaderOfflineAutoStart", .UnloaderOfflineAutoStart)
                WriteINIString(Section, "GlassPreload", .GlassPreload)
                WriteINIString(Section, "LogDayKeep", .LogDayKeep)
                WriteINIString(Section, "RepairMode", .RecipeMode)
                WriteINIString(Section, "SuperPassword", .SuperPassword)
                WriteINIString(Section, "ColorRepairMode", .ColorRepairMode)
                WriteINIString(Section, "CVSection1", .CVSectionPort(1))
                WriteINIString(Section, "CVSection2", .CVSectionPort(2))
                WriteINIString(Section, "CVSection3", .CVSectionPort(3))
                WriteINIString(Section, "CVSection4", .CVSectionPort(4))
                WriteINIString(Section, "CVSection5", .CVSectionPort(5))
                WriteINIString(Section, "CVSection6", .CVSectionPort(6))
                WriteINIString(Section, "CVSectionID1", .CVSectionID(1))
                WriteINIString(Section, "CVSectionID2", .CVSectionID(2))
                WriteINIString(Section, "CVSectionID3", .CVSectionID(3))
                WriteINIString(Section, "CVSectionID4", .CVSectionID(4))
                WriteINIString(Section, "CVSectionID5", .CVSectionID(5))
                WriteINIString(Section, "CVSectionID6", .CVSectionID(6))
                WriteINIString(Section, "MacroEQID", .MacroEQID)
                For i As Integer = 1 To MaxColumnNum
                    WriteINIString(Section, "CIMShowColumn" & Format(i, "0#"), .fCIMShowColumn(i))
                Next

                WriteINIString(Section, "FIReportGGradeRecipeEndChar", .FIReportGGradeRecipeEndChar)
            End With
            Flush()
            IniLoad()
        End Sub

        Public Function IniLoad(Optional ByVal IniFile As String = "") As Boolean

            If IniFile = "" Then
                IniFile = mL8BIniFileName
                If mL8BIniFileName = "" AndAlso IniFile = "" Then
                    Return False
                End If
            Else
                mL8BIniFileName = IniFile
            End If

            With Maintain
                Dim Section As String = MaintainSettingType.Section
                .Name = ReadINIString(Section, "Name")
                .Phone = ReadINIString(Section, "Phone")
            End With

            With AlarmFile
                Dim Section As String = AlarmFileType.Section
                .EQ1 = ReadINIString(Section, "EQ1")
                .EQ2 = ReadINIString(Section, "EQ2")
                .EQ3 = ReadINIString(Section, "EQ3")
                .CV = ReadINIString(Section, "CV")
                .PLC = ReadINIString(Section, "PLC")
                .SECS = ReadINIString(Section, "SECS")
            End With

            With ExtraIniFile
                Dim Section As String = ExternaIniFileType.Section
                .SECS = ReadINIString(Section, "SECS")
                .CIM = ReadINIString(Section, "CIM")
                .PLC = ReadINIString(Section, "PLC")
                .TOEQ = ReadINIString(Section, "TOEQ")
                .TOCV = ReadINIString(Section, "TOCV")
            End With

            With DataBaseSetting
                Dim Section As String = DataBaseSettingType.Section
                .DataProvide = ReadINIString(Section, "DataProvide")
                .ConnectionString = ReadINIString(Section, "ConnectionString")
                .SqliteDbFile = ReadINIString(Section, "SqliteDbFile")
            End With

            With ID
                Dim Section As String = TOOLIDType.Section
                .Line = ReadINIString(Section, "Line")
                .Tool = ReadINIString(Section, "Tool")
                .RST = ReadINIString(Section, "Rst")
                .EQ1 = ReadINIString(Section, "EQ1")
                .EQ2 = ReadINIString(Section, "EQ2")
                .EQ3 = ReadINIString(Section, "EQ3")
                .CV = ReadINIString(Section, "CV")
            End With
            LoadToolID()

            With Main
                Dim Section As String = SettingMainType.Section
                .MachineType = Val(ReadINIString(Section, "MachineType"))
                .RecipeMode = Val(ReadINIString(Section, "RecipeMode"))

                Select Case .MachineType
                    Case EMACHINETYPE.ButterFly
                        .GlassFlowMode = Val(ReadINIString(Section, "GlassFlowMode"))

                    Case EMACHINETYPE.FI
                        .GlassFlowMode = Val(ReadINIString(Section, "GlassFlowMode"))

                    Case EMACHINETYPE.REPAIR, EMACHINETYPE.COLORREPAIR
                        .GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U

                End Select

                .NumberEQ = Val(ReadINIString(Section, "NumberEQ"))
                .NumberCV = Val(ReadINIString(Section, "NumberCV"))
                .NumberPort = Val(ReadINIString(Section, "NumberPort"))
                .NumberBuffer = Val(ReadINIString(Section, "NumberBuffer"))
                .NumberBufferSlot(1) = Val(ReadINIString(Section, "NumberBufferSlot1"))
                .NumberBufferSlot(2) = Val(ReadINIString(Section, "NumberBufferSlot2"))
                .NumberBufferSlot(3) = Val(ReadINIString(Section, "NumberBufferSlot3"))
                .Pass = Val(ReadINIString(Section, "Pass"))
                .TotalPass = Val(ReadINIString(Section, "TotalPass"))
                .RobotArmUse = Val(ReadINIString(Section, "RobotArmUse"))
                .PortType(1) = Val(ReadINIString(Section, "PortType1"))
                .PortType(2) = Val(ReadINIString(Section, "PortType2"))
                .PortType(3) = Val(ReadINIString(Section, "PortType3"))
                .FIReportGGradeRecipeEndChar = ReadINIString(Section, "FIReportGGradeRecipeEndChar", "9")
                .LogDayKeep = Val(ReadINIString(Section, "LogDayKeep"))
                .RecipeMode = Val(ReadINIString(Section, "RecipeMode"))
                .SuperPassword = ReadINIString(Section, "SuperPassword")
                .ColorRepairMode = Val(ReadINIString(Section, "ColorRepairMode"))
                .CVSectionPort(1) = Val(ReadINIString(Section, "CVSection1"))
                .CVSectionPort(2) = Val(ReadINIString(Section, "CVSection2"))
                .CVSectionPort(3) = Val(ReadINIString(Section, "CVSection3"))
                .CVSectionPort(4) = Val(ReadINIString(Section, "CVSection4"))
                .CVSectionPort(5) = Val(ReadINIString(Section, "CVSection5"))
                .CVSectionPort(6) = Val(ReadINIString(Section, "CVSection6"))
                .CVSectionID(1) = Val(ReadINIString(Section, "CVSectionID1"))
                .CVSectionID(2) = Val(ReadINIString(Section, "CVSectionID2"))
                .CVSectionID(3) = Val(ReadINIString(Section, "CVSectionID3"))
                .CVSectionID(4) = Val(ReadINIString(Section, "CVSectionID4"))
                .CVSectionID(5) = Val(ReadINIString(Section, "CVSectionID5"))
                .CVSectionID(6) = Val(ReadINIString(Section, "CVSectionID6"))
                .MacroEQID = Val(ReadINIString(Section, "MacroEQID"))

                For i As Integer = 1 To 6
                    .CVOutID(.CVSectionPort(i)) = .CVSectionID(i)
                Next

                If .LogDayKeep < 30 Then
                    .LogDayKeep = 30
                End If

                If ReadINIString(Section, "EQrecipeCheck1") = "" Then
                    .EQRecipeCheck(1) = False
                Else
                    .EQRecipeCheck(1) = CBool(ReadINIString(Section, "EQrecipeCheck1"))
                End If

                If ReadINIString(Section, "EQrecipeCheck2") = "" Then
                    .EQRecipeCheck(2) = False
                Else
                    .EQRecipeCheck(2) = CBool(ReadINIString(Section, "EQrecipeCheck2"))
                End If

                If ReadINIString(Section, "EQrecipeCheck3") = "" Then
                    .EQRecipeCheck(3) = False
                Else
                    .EQRecipeCheck(3) = CBool(ReadINIString(Section, "EQrecipeCheck3"))
                End If

                For m As Integer = 1 To 4

                    For i As Integer = 1 To MaxBuffer
                        For j = 1 To MaxbufferSlot
                            .BufferSlotType(m)(i)(j) = Val(ReadINIString(Section, "BufferIType" & i & "-" & j))
                        Next
                    Next
                Next

                For i As Integer = 1 To MaxBuffer
                    For j As Integer = 1 To MaxbufferSlot
                        Try
                            .DisableRemark(i, j) = ReadINIString(Section, "BufferRemark" & Format(i, "0#") & Format(j, "0#"))
                            'FormMain.RSTControl.CVGUIBufferEdit(i).SlotDisableRemark(j) = .DisableRemark(i, j)
                        Catch ex As Exception
                            .DisableRemark(i, j) = ""
                        End Try
                    Next
                Next

                Try
                    Dim rst = ReadINIString(Section, "UnloaderOfflineAutoStart")
                    .UnloaderOfflineAutoStart = CBool(ReadINIString(Section, "UnloaderOfflineAutoStart"))
                Catch ex As Exception
                    .UnloaderOfflineAutoStart = False
                End Try

                Try
                    Dim rst = ReadINIString(Section, "GlassPreload")
                    .GlassPreload = CBool(ReadINIString(Section, "GlassPreload"))
                Catch ex As Exception
                    .GlassPreload = False
                End Try

                For i As Integer = 1 To MaxColumnNum
                    Try
                        Dim rst = ReadINIString(Section, "CIMShowColumn" & Format(i, "0#"))
                        .fCIMShowColumn(i) = CBool(ReadINIString(Section, "CIMShowColumn" & Format(i, "0#")))
                    Catch ex As Exception
                        .fCIMShowColumn(i) = False
                    End Try
                Next

            End With
            LoadBuffer()
            Return True
        End Function

        Dim dialog As DialogUserSetting

        Public Sub ShowUserSetup()
            If dialog Is Nothing Then
                dialog = New DialogUserSetting
            End If
            dialog.Showme()
        End Sub

        Public Function CheckUser(ByVal vUserID As String, ByVal vPassword As String) As Boolean
            Dim Section As String = "Users"
            If MyTrim(vUserID).Length > 0 AndAlso vPassword = ReadINIString(Section, vUserID & "Password") Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUser(ByVal mName As String) As Boolean
            Dim Section As String = "Users"
            Dim s() As String = ReadINIString(Section, "UserList").Split(",")


            If s.Length > 0 AndAlso s(0) <> "" Then
                For i As Integer = 0 To s.Length - 1
                    If s(i) = mName Then
                        Return True
                    End If
                Next
            End If

            If mName = "Admin" Then
                Return True
            End If
            Return False
        End Function

        Public Sub SavePass()
            With Main
                Dim Section As String = SettingMainType.Section
                WriteINIString(Section, "Pass", .Pass)
                WriteINIString(Section, "TotalPass", .TotalPass)
            End With
        End Sub


        Public Sub SaveLotDataDownload(ByVal nPort As Integer, ByVal fDownload As Boolean)
            With Main
                Dim Section As String = SettingMainType.Section
                WriteINIString(Section, "LotDataDownload" & nPort, Val(fDownload))
            End With
        End Sub


        Public Function LoadLotDataDownload(ByVal nPort As Integer) As Boolean
            With Main
                Dim Section As String = SettingMainType.Section
                Return IIf(Val(ReadINIString(Section, "LotDataDownload" & nPort)) <> 0, True, False)
            End With
        End Function

        Public Sub SaveBuffer(ByVal nType As eRunningMode)
            With Main
                Dim Section As String = SettingMainType.Section
                'For m = 1 To 4
                For i As Integer = 1 To MaxBuffer
                    For j = 1 To MaxbufferSlot
                        WriteINIString(Section, "BufferIType" & Val(nType) & i & "-" & j, .BufferSlotType(Val(nType))(i)(j))
                    Next
                Next
                'Next
            End With
        End Sub


        Public Sub LoadBuffer()
            With Main
                Dim Section As String = SettingMainType.Section
                For m = 1 To 4
                    For i As Integer = 1 To MaxBuffer
                        For j = 1 To MaxbufferSlot
                            .BufferSlotType(m)(i)(j) = Val(ReadINIString(Section, "BufferIType" & m & i & "-" & j))
                        Next
                    Next
                Next
            End With
        End Sub

        Public Sub InitialSetting()
            With Main
                ReDim .PortType(MaxPort)
                ReDim .NumberBufferSlot(MaxBuffer)
                ReDim .BufferSlotType(4)

                For i As Integer = 1 To 4
                    ReDim .BufferSlotType(i)(3)
                    For j As Integer = 1 To 3
                        ReDim .BufferSlotType(i)(j)(25)
                    Next
                Next


                ReDim .EQRecipeCheck(MaxEQ)
                ReDim .DisableRemark(MaxBuffer, MaxbufferSlot)
                ReDim .fCIMShowColumn(MaxColumnNum)
                ReDim .CVSectionPort(6)
                ReDim .CVSectionID(6)
                ReDim .CVOutID(MaxPort)
            End With
        End Sub

        Public Sub SaveDisableRemark(ByVal nBuffer As Integer, ByVal nSlot As Integer, ByVal zRemark As String)
            Dim Section As String = SettingMainType.Section
            WriteINIString(Section, "BufferRemark" & Format(nBuffer, "0#") & Format(nSlot, "0#"), zRemark)
            WriteLog("BufferRemark Buffer=" & nBuffer & " Slot=" & nSlot & " remark=[" & zRemark & "]", LogMessageType.Info)
        End Sub

        Public Sub LoadToolID()
            mInfo.EQ(1).ToolID = _L8B.Setting.ID.EQ1
            mInfo.EQ(2).ToolID = _L8B.Setting.ID.EQ2
            mInfo.EQ(3).ToolID = _L8B.Setting.ID.EQ3
            mInfo.CV.ToolID = _L8B.Setting.ID.CV
            mInfo.Robot.ToolID = _L8B.Setting.ID.Tool
        End Sub

    End Class
End Module
