Imports System.Data
Imports System.Data.Common
Imports System.Data.SQLite

Module ModuleDB


    Public DBmain As New cDataBase

    Public Sub InitDB()
        _L8B.db = DBmain
        DBOpenConnection()
    End Sub

    Public Sub DBOpenConnection()
        _L8B.db.ProviderName = _L8B.Setting.DataBaseSetting.DataProvide
        _L8B.db.SqliteDbFile = _L8B.Setting.DataBaseSetting.SqliteDbFile
        _L8B.db.OpenConnection()
    End Sub

    Public Class cDataBase
        Public DbFactory As DbProviderFactory


        Private Class DbMain
            Public WithEvents Connection As DbConnection
            Public Event ConnectionStateChange(ByVal sender As Object, ByVal e As System.Data.StateChangeEventArgs)

            Public DbFactory As DbProviderFactory
            Public InsertQueue As Queue

            Private mConnectionString As String
            Public ReadOnly Property ConnectionString() As String
                Get
                    Return mConnectionString
                End Get
            End Property

            Private mSqliteDbFile As String
            Public Property SqliteDbFile() As String
                Get
                    Return mSqliteDbFile
                End Get
                Set(ByVal value As String)
                    mSqliteDbFile = value
                    mConnectionString = "Data Source=" & mSqliteDbFile
                End Set
            End Property

            Private mProviderName As String

            Public Property ProviderName() As String
                Get
                    Return mProviderName
                End Get
                Set(ByVal value As String)
                    mProviderName = value
                    Dim dTable As DataTable = DbProviderFactories.GetFactoryClasses()

                    Dim dv As DataView = dTable.DefaultView

                    For i As Integer = 0 To dTable.Rows.Count - 1
                        'Debug.WriteLine(dTable.Rows(i)("Invariantname"))

                        If Not IsDBNull(dTable.Rows(i)("Invariantname")) Then
                            If dTable.Rows(i)("Invariantname") = mProviderName Then
                                WriteLog(mProviderName & " (" & dTable.Rows(i).Item(0) & ")")
                                Exit Property
                            End If
                        End If
                    Next

                    WriteLog("Database provider is not found:" & mProviderName, LogMessageType.SYS)
                End Set
            End Property

            Private Sub Connection_StateChange(ByVal sender As Object, ByVal e As System.Data.StateChangeEventArgs) Handles Connection.StateChange
                WriteLog("DB Connection_StateChange ->" & e.ToString, LogMessageType.SYS)
                RaiseEvent ConnectionStateChange(sender, e)
            End Sub

            Public Sub New()
                InsertQueue = New Queue
                ProviderName = ""
            End Sub

        End Class

        Dim WithEvents m As New DbMain

#Region "Property"

        Public ReadOnly Property ConnectionString() As String
            Get
                Return m.ConnectionString
            End Get
        End Property

        Public Property SqliteDbFile() As String
            Get
                Return m.SqliteDbFile
            End Get
            Set(ByVal value As String)
                m.SqliteDbFile = value
            End Set
        End Property

        Public Property ProviderName() As String
            Get
                Return m.ProviderName
            End Get
            Set(ByVal value As String)
                m.ProviderName = value
            End Set
        End Property

        Public ReadOnly Property State() As ConnectionState
            Get
                If m.Connection IsNot Nothing Then
                    Return m.Connection.State
                Else
                    Return ConnectionState.Closed
                End If
            End Get
        End Property

        Public ReadOnly Property GetDbGetFactoryClasses() As DataTable
            Get
                Return DbProviderFactories.GetFactoryClasses()
            End Get
        End Property

#End Region

#Region "DB connection"

        Public Sub OpenConnection()
            Try
                If m.Connection IsNot Nothing Then
                    If m.Connection.State = ConnectionState.Open Then Exit Sub
                End If
                WriteLog("DB connect use " & m.ProviderName & "connection String = [" & m.ConnectionString & "]", LogMessageType.SYS)
                m.DbFactory = DbProviderFactories.GetFactory(m.ProviderName)
                m.Connection = m.DbFactory.CreateConnection()
                m.Connection.ConnectionString = m.ConnectionString

                If My.Computer.FileSystem.FileExists(m.SqliteDbFile) Then
                    m.Connection.Open()
                Else
                    WriteLog("database File not exist [" & m.ConnectionString & "]", LogMessageType.SYS)
                    CreateDBFile(m.SqliteDbFile)
                    m.Connection.Open()
                    ExecuteQueryNoReturn(L8Bmain.My.Resources.DBscript)
                End If
            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
            End Try
        End Sub

        Public Function CreateDBFile(ByVal vFile As String) As Boolean
            Dim Path As String = My.Computer.FileSystem.GetFileInfo(vFile).Directory.FullName
            Try
                If My.Computer.FileSystem.DirectoryExists(Path) Then
                    SQLiteConnection.CreateFile(vFile)
                    WriteLog("Create database File OK [" & m.ConnectionString & "]", LogMessageType.SYS)
                Else
                    If CreateDiretory(My.Computer.FileSystem.GetFileInfo(vFile).Directory) Then
                        SQLiteConnection.CreateFile(vFile)
                        WriteLog("Create database File OK [" & m.ConnectionString & "]", LogMessageType.SYS)
                    End If
                End If
            Catch ex As Exception
                WriteLog("Create database File Fail [" & m.ConnectionString & "]", LogMessageType.SYS)
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
            End Try


        End Function

        Public Sub CloseConnection()
            If m.Connection.State <> ConnectionState.Closed Then
                While m.Connection.State = ConnectionState.Executing Or m.Connection.State = ConnectionState.Fetching
                    System.Windows.Forms.Application.DoEvents()
                End While
                m.Connection.Close()
                WriteLog("DB CloseConnection", LogMessageType.SYS)
            End If
        End Sub

#End Region

        Public Function ExecuteQueryNoReturn(ByVal commandText As String) As Boolean
            WriteLog(commandText)
            If m.DbFactory Is Nothing Then
                Return False
            End If
            Try
                Dim cmd As DbCommand = m.Connection.CreateCommand
                cmd.CommandText = commandText
                Dim rowCount As Integer = cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
                Return False
            End Try
        End Function

        Public Function QueryTable(ByVal SQLcmd As String) As DataTable
            WriteLog(SQLcmd)
            Dim dt As DataTable = New DataTable
            Try
                Dim da As DbDataAdapter = m.DbFactory.CreateDataAdapter()
                If m.DbFactory Is Nothing Then
                    Return dt
                End If
                da.SelectCommand = m.Connection.CreateCommand
                da.SelectCommand.CommandText = SQLcmd
                da.Fill(dt)
                Return dt
            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
                Return dt
            End Try

        End Function

        Private Function TableGetData(ByVal table As DataTable, ByVal index As Integer, ByVal vField As String) As Double
            If table.Columns.Contains(vField) Then
                If Not Convert.IsDBNull(table.DefaultView.Item(index).Row(vField)) Then
                    Return table.DefaultView.Item(index).Row(vField)
                Else
                    Return Double.NegativeInfinity
                End If
            Else
                Return Double.NegativeInfinity
            End If
        End Function

        Private Function TableGetString(ByVal table As DataTable, ByVal index As Integer, ByVal vField As String) As String
            If table.Columns.Contains(vField) Then
                If Not Convert.IsDBNull(table.DefaultView.Item(index).Row(vField)) Then
                    Return table.DefaultView.Item(index).Row(vField)
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        End Function

        Public Function CheckRecipe(ByVal rName As String) As Boolean
            Dim da As DbDataAdapter = m.DbFactory.CreateDataAdapter()
            da.SelectCommand = m.Connection.CreateCommand
            da.SelectCommand.CommandText = String.Format("SELECT * FROM ""recipe"" WHERE ID = '{0}';", rName)

            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            WriteLog(da.SelectCommand.CommandText & " Count=" & dt.Rows.Count)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function


        Public Function GetRecipeVersion(ByVal rName As String) As String
            Dim da As DbDataAdapter = m.DbFactory.CreateDataAdapter()
            da.SelectCommand = m.Connection.CreateCommand
            da.SelectCommand.CommandText = "SELECT * FROM ""recipe"" Where `Version` = '" & rName & "';"

            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim Ret As String = IIf(IsDBNull(dt.Rows(0)("Version")), "", CStr(dt.Rows(0)("Version")))
                Return Ret
            Else
                Return ""
            End If
        End Function

        Public Function GetFirstRecipe() As String
            Dim da As DbDataAdapter = m.DbFactory.CreateDataAdapter()
            da.SelectCommand = m.Connection.CreateCommand
            da.SelectCommand.CommandText = "SELECT * FROM ""recipe"";"

            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim Ret As String = IIf(IsDBNull(dt.Rows(0)("ID")), "", CStr(dt.Rows(0)("ID")))
                Return Ret
            Else
                Return ""
            End If
        End Function


        Public Function QuerySerial(ByVal TableID As String, ByVal vID As String) As Long
            If m.DbFactory Is Nothing Then
                Return -1
            End If
            Dim da As DbDataAdapter = m.DbFactory.CreateDataAdapter()
            da.SelectCommand = m.Connection.CreateCommand
            da.SelectCommand.CommandText = String.Format("SELECT (max(`" & vID & "`)) as `last_value` from `{0}`;", TableID)
            WriteLog(da.SelectCommand.CommandText)
            Dim dt As DataTable = New DataTable
            Dim dv As DataView = dt.DefaultView
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim Ret As Long = IIf(IsDBNull(dt.Rows(0)("last_value")), -1, Val(dt.Rows(0)("last_value")))
                Return Ret
            Else
                Return -1
            End If

        End Function

        Public Function QuerySerial(ByVal TableID As String, ByVal vField As String, ByVal vFieldValue As String, ByVal RetField As String) As Long
            If m.DbFactory Is Nothing Then
                Return -1
            End If
            Dim da As DbDataAdapter = m.DbFactory.CreateDataAdapter()
            da.SelectCommand = m.Connection.CreateCommand
            da.SelectCommand.CommandText = String.Format("SELECT * FROM `{0}` WHERE `{1}`='{2}';", TableID, vField, vFieldValue)
            WriteLog(da.SelectCommand.CommandText)
            Dim dt As DataTable = New DataTable
            Dim dv As DataView = dt.DefaultView
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim Ret As Long = IIf(IsDBNull(dt.Rows(0)(RetField)), -1, Val(dt.Rows(0)(RetField)))
                Return Ret
            Else
                Return -1
            End If

        End Function

        Public Enum eHOSTMESSAGETYPE
            [Broadcast]
            [Warning]
        End Enum

        Public Function InsertHostMessageHistory(ByVal vSource As String, ByVal vMessage As String, Optional ByVal vType As Integer = -1)

            Dim CommandText As String
            If vType <= 1 And vType >= 0 Then
                CommandText = String.Format("INSERT INTO ""HostMessageHistory""(""Source"", ""Type"", ""Message"") " & _
                                         "VALUES ('{0}','{1}',""{2}"");", _
                                                  vSource, CType(vType, eHOSTMESSAGETYPE).ToString, vMessage)
            Else
                CommandText = String.Format("INSERT INTO ""HostMessageHistory""(""Source"", ""Message"") " & _
                                                     "VALUES ('{0}',""{1}"");", _
                                                              vSource, vMessage)
            End If
            If ExecuteQueryNoReturn(CommandText) Then
                Return QuerySerial("HostMessageHistory", "ID")
            Else
                Return -1
            End If
        End Function

        Public Function InsertAlarm(ByVal Source As String, ByVal Code As Integer, ByVal Message As String, ByVal vType As String, ByVal vdate As Date) As Integer
            Dim CommandText As String

            CommandText = String.Format("INSERT INTO `Alarm`(`Source`, `Type`, `Code`, `Message`, `OccurreTime`) " & _
                                     "VALUES ('{0}','{1}','{2}','{3}','{4}');", _
                                              Source, vType.ToString, Code, Message, GetAUODateTime(vdate))
            If ExecuteQueryNoReturn(CommandText) Then
                Return QuerySerial("Alarm", "Index")
            Else
                Return -1
            End If
        End Function

        Public Function UpdateAlarm(ByVal mIndex As Integer, ByVal ReleaseTime As String) As Boolean
            Dim CommandText As String = "UPDATE Alarm SET `ReleaseTime`='" & ReleaseTime & "' WHERE `Index`='" & mIndex & "';"
            Return ExecuteQueryNoReturn(CommandText)
        End Function

        Public Function UpdateAlarmReportOccurr(ByVal mIndex As Integer, Optional ByVal fReport As Boolean = True) As Boolean
            Dim CommandText As String = "UPDATE Alarm SET `fReportOccurr`=" & IIf(fReport, "'Y'", "'N'") & " WHERE `Index`='" & mIndex & "';"
            Return ExecuteQueryNoReturn(CommandText)
        End Function

        Public Function UpdateAlarmReportRelease(ByVal mIndex As Integer, Optional ByVal fReport As Boolean = True) As Boolean
            Dim CommandText As String = "UPDATE Alarm SET `fReportRelease`=" & IIf(fReport, "'Y'", "'N'") & " WHERE `Index`='" & mIndex & "';"
            Return ExecuteQueryNoReturn(CommandText)
        End Function

        Public Function QueryAlarm(ByVal TimeStamp As Date) As DataTable
            Dim CommandText = String.Format("SELECT Source,code, type, OccurreTime, ReleaseTime, Message FROM Alarm Where OccurreTime < ""{1}"" and OccurreTime >= ""{0}"" ORDER by OccurreTime DESC;", Format(TimeStamp, "yyyyMMdd000000"), Format(TimeStamp.AddDays(1), "yyyyMMdd000000"))
            Return QueryTable(CommandText)
        End Function

        Public Function QueryAlarmOccurr() As DataTable
            Dim CommandText = String.Format("SELECT * FROM `Alarm` Where `ReleaseTime` ='' ORDER BY `OccurreTime` DESC")
            Return QueryTable(CommandText)
        End Function

        Public Function QueryHostMessageHistory() As DataTable
            Dim CommandText As String = "SELECT * FROM HostMessageHistory WHERE `Delete`='' ORDER BY DateTime DESC LIMIT 200;"  'DESC
            Return QueryTable(CommandText)
        End Function

        Public Function UpdateHostMessageHistoryDelete() As Boolean
            Dim CommandText As String = "UPDATE HostMessageHistory SET `Delete`='Y' WHERE `Delete`='';"  'DESC
            Return ExecuteQueryNoReturn(CommandText)
        End Function

        Public Structure EQrecipe
            Dim bAOI As Boolean
            Dim PPID As String
            Dim Mode As Integer
        End Structure

        Public Function ThreeEQRecipeUpdate(ByVal vID As String, ByVal vVersion As String, ByVal vRemark As String, ByVal vVCRPOS As String, ByVal vGlassType As String, ByVal vRobotSpeed As String, ByVal vEQSelection As Integer, ByVal vSampleGlass As String, ByVal vSelectGlass As String, ByVal Recipe() As EQrecipe, ByVal vFICIMResult As cRecipe.eFICIMGradeReport, ByVal vColorRepairMode As L8BIFPRJ.clsPLC.eColorRepairMode) As Boolean
            If CheckRecipe(vID) Then
                Dim CommandText = String.Format("UPDATE Recipe SET Version='{1}', Remark='{2}', RecipeEQ1='{3}', ModeEQ1='{4}', RecipeEQ2='{5}', ModeEQ2='{6}', VCRPOS='{7}', GlassType='{8}', RobotSpeed='{9}', SampleGlass='{10}', SelectGlass='{11}', EQSelection='{12}', FICIMResult='{13}', FICIMResult='{13}', ColorRepairMode='{14}'" _
                                    & " WHERE ID='{0}'", _
                                    vID, vVersion, vRemark, Recipe(1).PPID, Recipe(1).Mode, Recipe(2).PPID, Recipe(2).Mode, vVCRPOS, vGlassType, vRobotSpeed, vSampleGlass, vSelectGlass, vEQSelection, Val(vFICIMResult), Val(vColorRepairMode))
                If ExecuteQueryNoReturn(CommandText) Then
                    Return QuerySerial("Recipe", "ID", vID, "Index")
                Else
                    Return -1
                End If
            Else
                Dim CommandText = String.Format("INSERT INTO Recipe (ID, Version, Remark, RecipeEQ1, ModeEQ1, RecipeEQ2, ModeEQ2, VCRPOS, GlassType, RobotSpeed, EQSelection, SampleGlass, SelectGlass, FICIMResult, ColorRepairMode) " _
                                    & " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}', '{11}', '{12}','{13}','{14}')", _
                                    vID, vVersion, vRemark, Recipe(1).PPID, Recipe(1).Mode, Recipe(2).PPID, Recipe(2).Mode, vVCRPOS, vGlassType, vRobotSpeed, vEQSelection, vSampleGlass, vSelectGlass, Val(vFICIMResult), Val(vColorRepairMode))

                If ExecuteQueryNoReturn(CommandText) Then
                    Return QuerySerial("Recipe", "Index")
                Else
                    Return -1
                End If
            End If
        End Function

        Public Function OneEQRecipeUpdate(ByVal vID As String, ByVal vVersion As String, ByVal vRemark As String, ByVal vVCRPOS As Integer, ByVal vGlassType As Integer, ByVal vRobotSpeed As Integer, ByVal vEQRecipe As String, ByVal vSampleGlass As String, ByVal vSelectGlass As String, ByVal vFICIMResult As cRecipe.eFICIMGradeReport, ByVal vColorRepairMode As L8BIFPRJ.clsPLC.eColorRepairMode) As Boolean
            If CheckRecipe(vID) Then
                Dim CommandText = String.Format("UPDATE Recipe SET Version='{1}', Remark='{2}', EQRecipe='{3}', VCRPOS='{4}', GlassType='{5}', RobotSpeed='{6}', SampleGlass ='{7}', SelectGlass ='{8}', FICIMResult='{9}', EQSelection='{10}', ColorRepairMode='{11}'" _
                                    & " WHERE ID='{0}'", _
                                    vID, vVersion, vRemark, vEQRecipe, vVCRPOS, vGlassType, vRobotSpeed, vSampleGlass, vSelectGlass, Val(vFICIMResult), 1, Val(vColorRepairMode))
                If ExecuteQueryNoReturn(CommandText) Then
                    Return QuerySerial("Recipe", "ID", vID, "Index")
                Else
                    Return -1
                End If
            Else
                Dim CommandText = String.Format("INSERT INTO Recipe (ID, Version, Remark, EQRecipe, VCRPOS, GlassType, RobotSpeed, SampleGlass, SelectGlass, FICIMResult, EQSelection, ColorRepairMode) " _
                                                & " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}', '{11}')", _
                                                vID, vVersion, vRemark, vEQRecipe, vVCRPOS, vGlassType, vRobotSpeed, vSampleGlass, vSelectGlass, Val(vFICIMResult), 1, Val(vColorRepairMode))
                If ExecuteQueryNoReturn(CommandText) Then
                    Return QuerySerial("Recipe", "Index")
                Else
                    Return -1
                End If
            End If
        End Function

        Public Function AddThreeEQRecipe(ByVal vID As String, ByVal vVersion As String, ByVal vRemark As String, ByVal vVCRPOS As Integer, ByVal vGlassType As Integer, ByVal vRobotSpeed As Integer, ByVal vEQSelection As Integer, ByVal vSampleGlass As Integer, ByVal EQSelection As Integer, ByVal vSelectGlass As String, ByVal Recipe() As EQrecipe, ByVal vFICIMResult As cRecipe.eFICIMGradeReport, ByVal vColorRepairMode As L8BIFPRJ.clsPLC.eColorRepairMode) As Boolean

            Dim CommandText = String.Format("INSERT INTO Recipe (ID, Version, Remark, RecipeEQ1, ModeEQ1, RecipeEQ2, ModeEQ2, VCRPOS, GlassType, RobotSpeed, EQSelection, SampleGlass, SelectGlass, FICIMResult, ColorRepairMode) " _
                                            & " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')", _
                                            vID, vVersion, vRemark, Recipe(1).PPID, Recipe(1).Mode, Recipe(2).PPID, Recipe(2).Mode, vVCRPOS, vGlassType, vRobotSpeed, vEQSelection, vSampleGlass, vSelectGlass, Val(vFICIMResult), Val(vColorRepairMode))
            If ExecuteQueryNoReturn(CommandText) Then
                Return QuerySerial("Recipe", "Index")
            Else
                Return -1
            End If

        End Function

        Public Function AddOneEQRecipe(ByVal vID As String, ByVal vVersion As String, ByVal vRemark As String, ByVal vVCRPOS As Integer, ByVal vGlassType As Integer, ByVal vRobotSpeed As Integer, ByVal vEQRecipe As String, ByVal vSampleGlass As String, ByVal vSelectGlass As String, ByVal vFICIMResult As cRecipe.eFICIMGradeReport, ByVal vColorRepairMode As L8BIFPRJ.clsPLC.eColorRepairMode) As Boolean
            Dim CommandText = String.Format("INSERT INTO Recipe (ID, Version, Remark, EQRecipe, VCRPOS, GlassType, RobotSpeed, SampleGlass, SelectGlass, FICIMResult, ColorRepairMode) " _
                                            & " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", _
                                            vID, vVersion, vRemark, vEQRecipe, vVCRPOS, vGlassType, vRobotSpeed, vSampleGlass, vSelectGlass, Val(vFICIMResult), Val(vColorRepairMode))
            If ExecuteQueryNoReturn(CommandText) Then
                Return QuerySerial("Recipe", "Index")
            Else
                Return -1
            End If

        End Function

        Public Function QueryEQRecipeList(ByVal nEQ As Integer) As DataTable
            Dim CommandText = String.Format("SELECT EQID, PPID, Version FROM EQRecipe WHERE EQID ={0} ORDER BY PPID;", nEQ)
            Return QueryTable(CommandText)
        End Function

        Public Function QueryRecipeList() As DataTable
            Dim CommandText = String.Format("SELECT ID, Version, Remark FROM Recipe;")
            Return QueryTable(CommandText)
        End Function

        Public Function QueryRecipe(ByVal vPPID As String) As DataTable
            Dim CommandText = String.Format("SELECT * FROM ""recipe"" WHERE ID= '{0}';", vPPID)
            Return QueryTable(CommandText)
        End Function

        Public Function DeleteRecipe(ByVal vPPID As String) As Boolean
            If CheckRecipe(vPPID) Then
                Dim CommandText = String.Format("DELETE FROM Recipe WHERE ID = '{0}';", vPPID)
                Return ExecuteQueryNoReturn(CommandText)
            Else
                Return False
            End If
        End Function


        Public Function RecipeList() As ArrayList
            Dim CommandText = "SELECT * FROM Recipe;"
            Dim dt As DataTable = QueryTable(CommandText)
            Dim Temp As New ArrayList
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Temp.Add(dt.Rows(i)("ID"))
                Next
            End If
            Return Temp
        End Function

        Public Function EQRecipeList(ByVal nEQ As Integer) As ArrayList
            Dim CommandText = String.Format("SELECT EQID, PPID, Version FROM EQRecipe WHERE EQID ={0} ORDER BY PPID;", nEQ)
            Dim dt As DataTable = QueryTable(CommandText)
            Dim Temp As New ArrayList
            If dt.Rows.Count > 0 Then
                Temp.Add("")
                For i As Integer = 0 To dt.Rows.Count - 1
                    Temp.Add(dt.Rows(i)("PPID"))
                Next
            End If
            Return Temp
        End Function

        Public Function CheckEQRecipe(ByVal nEQ As Integer, ByVal PPID As String) As Boolean
            Dim EqRecipeTable As DataTable = QueryTable("SELECT * FROM EQRecipe WHERE EQID ='" & nEQ & "' AND PPID = '" & PPID & "'")

            If EqRecipeTable Is Nothing Then
                Return False
            End If
            Return IIf(EqRecipeTable.Rows.Count > 0, True, False)
        End Function

        Public Function AddEQRecipe(ByVal nEQ As Integer, ByVal PPID As String) As Boolean
            If CheckEQRecipe(nEQ, PPID) Then
                ModifyEQRecipe(nEQ, PPID)
            Else
                Dim lVersion As String = GetAUODateTime(Now)
                WriteLog("[Recipe Add] EQ" & nEQ & " PPID:" & PPID & " ver:" & lVersion, LogMessageType.Info)
                Dim commandText = String.Format("INSERT INTO EQRecipe (EQID, PPID, Version) VALUES ('{0}', '{1}', '{2}')", nEQ, PPID, lVersion)
                If ExecuteQueryNoReturn(commandText) Then
                    Return QuerySerial("EQRecipe", "Index")
                Else
                    Return -1
                End If
            End If
        End Function

        Public Function DeleteEQRecipe(ByVal nEQ As Integer, ByVal PPID As String) As Boolean
            'TableGetString
            Dim lVersion As String = GetAUODateTime(Now)
            WriteLog("[Recipe Delete] EQ" & nEQ & " PPID:" & PPID, LogMessageType.Info)
            Dim commandText = String.Format("DELETE FROM EQRecipe WHERE EQID = '{0}' AND PPID = '{1}'", nEQ, PPID)
            Return ExecuteQueryNoReturn(commandText)
        End Function

        Public Function ModifyEQRecipe(ByVal nEQ As Integer, ByVal PPID As String) As Boolean
            Dim lVersion As String = GetAUODateTime(Now)
            WriteLog("[Recipe Modify] EQ" & nEQ & " PPID:" & PPID & " ver:" & lVersion, LogMessageType.Info)
            Dim commandText = String.Format("UPDATE EQRecipe SET version = '{2}' WHERE EQID = '{0}' AND PPID = '{1}'", nEQ, PPID, lVersion)
            Return ExecuteQueryNoReturn(commandText)
        End Function

        Public Function LoadRecipe(ByVal PPID As String) As cRecipe
            Try
                PPID = MyTrim(PPID)
                Dim Recipe As New cRecipe
                Dim dt As DataTable = QueryRecipe(PPID)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    With Recipe
                        .PPID = PPID
                        .Version = IIf(IsDBNull(dt.Rows(0)("Version")), "", dt.Rows(0)("Version"))
                        .Remark = IIf(IsDBNull(dt.Rows(0)("Remark")), "", dt.Rows(0)("Remark"))
                        .VCRPosition = IIf(IsDBNull(dt.Rows(0)("VCRPOS")), "", dt.Rows(0)("VCRPOS"))
                        .GlassType = IIf(IsDBNull(dt.Rows(0)("GlassType")), "", dt.Rows(0)("GlassType"))
                        If Val(.GlassType) <= 0 Then
                            .GlassType = "1"
                        End If
                        .RobotSpeed = IIf(IsDBNull(dt.Rows(0)("RobotSpeed")), "", dt.Rows(0)("RobotSpeed"))
                        If Val(.RobotSpeed) <= 0 Then
                            .RobotSpeed = "1"
                        End If
                        .EQPPID = IIf(IsDBNull(dt.Rows(0)("EQRecipe")), "", dt.Rows(0)("EQRecipe"))
                        .EQPPID(1) = IIf(IsDBNull(dt.Rows(0)("RecipeEQ1")), "", dt.Rows(0)("RecipeEQ1"))
                        .EQPPID(2) = IIf(IsDBNull(dt.Rows(0)("RecipeEQ2")), "", dt.Rows(0)("RecipeEQ2"))
                        .SampleGlass = IIf(IsDBNull(dt.Rows(0)("SampleGlass")), 0, dt.Rows(0)("SampleGlass"))
                        .EQSelection = IIf(IsDBNull(dt.Rows(0)("EQSelection")), 0, dt.Rows(0)("EQSelection"))
                        .FICIMResult = IIf(IsDBNull(dt.Rows(0)("FICIMResult")), 0, dt.Rows(0)("FICIMResult"))

                        If .FICIMResult <= cRecipe.eFICIMGradeReport.NOTHING OrElse .FICIMResult > cRecipe.eFICIMGradeReport.DMQC Then
                            If PPID.Length = 3 AndAlso PPID.Chars(PPID.Length - 1) = _L8B.Setting.Main.FIReportGGradeRecipeEndChar Then
                                .FICIMResult = cRecipe.eFICIMGradeReport.GLASS
                            Else
                                .FICIMResult = cRecipe.eFICIMGradeReport.DMQC
                            End If
                        End If
                        Try
                            .ColorRepairMode = IIf(IsDBNull(dt.Rows(0)("ColorRepairMode")), 0, dt.Rows(0)("ColorRepairMode"))
                        Catch ex As Exception
                            WriteLog(ex.ToString)
                        End Try

                        Dim SelectGlass As String = IIf(IsDBNull(dt.Rows(0)("SelectGlass")), "", dt.Rows(0)("SelectGlass"))
                        If SelectGlass <> "" Then
                            For i As Integer = 0 To SelectGlass.Length - 1
                                .SelectGlass(i + 1) = Val(SelectGlass.Chars(i))
                            Next
                        Else
                            For i As Integer = 1 To MAXCASSETTESLOT
                                .SelectGlass(i) = 0
                            Next
                        End If

                    End With
                    Return (Recipe)
                Else
                    WriteLog("LoadRecipe fail PPID[" & PPID & "] " & PPID.Length, LogMessageType.ERR)
                    Return Nothing
                End If

            Catch ex As Exception
                WriteLog(ex.ToString, LogMessageType.EXCEPTION)
                Return Nothing
            End Try
        End Function



        Public Function FirstOKSameEQRecipe(ByVal NumberOfEQ As Integer) As String
            Dim myRecipeList As ArrayList = RecipeList()

            For Each myRecipe As String In myRecipeList
                Dim Recipe As cRecipe = LoadRecipe(myRecipe)
                If NumberOfEQ = 1 Then
                    If CheckEQRecipe(1, Recipe.EQPPID) Then
                        Return myRecipe
                    End If
                End If

                If NumberOfEQ = 2 Then
                    If CheckEQRecipe(1, Recipe.EQPPID) And CheckEQRecipe(2, Recipe.EQPPID) Then
                        Return myRecipe
                    End If
                End If
                If NumberOfEQ = 1 Then
                    If CheckEQRecipe(1, Recipe.EQPPID) And CheckEQRecipe(2, Recipe.EQPPID) And CheckEQRecipe(3, Recipe.EQPPID) Then
                        Return myRecipe
                    End If
                End If
            Next
            Return ""
        End Function

        Public Function FirstOKDiffEQRecipe() As String
            Dim myRecipeList As ArrayList = RecipeList()

            For Each myRecipe As String In myRecipeList
                Dim Recipe As cRecipe = LoadRecipe(myRecipe)
                If CheckEQRecipe(1, Recipe.EQPPID(1)) And CheckEQRecipe(2, Recipe.EQPPID(2)) Then
                    Return myRecipe
                End If
            Next
            Return ""
        End Function
    End Class


End Module
