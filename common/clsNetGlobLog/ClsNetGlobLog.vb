Imports System
Imports System.Threading

Public Class ClsNetGlobLog
    ' Private WithEvents LogTimer As New Timers.Timer
    Dim MyLogCtrl As Object
    Public strLogTitle As String


    Public Event LogFull()

    Public Delegate Sub ParameterizedThreadStart(ByVal ThreadLog As ClsNetGlobLog)

    Delegate Sub DelgateWriteLogToGUI(ByVal strLogInfo As Object)

    Public Sub WriteLog(ByVal strLogInfo As Object)


        Dim OneMsgObject As MsgType
        OneMsgObject.oListBox = MyLogCtrl
        OneMsgObject.Str = strLogInfo
        OneMsgObject.LogTitle = strLogTitle

        If mvarfAutoSaveFile Then
            DriveWriteLog(OneMsgObject.Str)
        End If

        SyncLock MyForm.LogQueue
            MyForm.LogQueue.Enqueue(OneMsgObject)
        End SyncLock
    End Sub


    Friend Property Caption() As String
        Get
            Caption = strLogTitle
        End Get

        Set(ByVal value As String)
            strLogTitle = value
        End Set
    End Property

    Friend Sub StartLog()
        MyLogCtrl = MyForm.AddListBox(strLogTitle)
        MyAllLogCtrl.Add(MyLogCtrl)
    End Sub

    Public Sub New()
        AssignMyForm()
    End Sub
End Class

Public Class clsLogFactory
    Dim mvarLogCol As Collection
    Dim WithEvents MyLog As New clsNetGlobLog


    Public Function GetParameterObj() As clsLogParameter
        GetParameterObj = MyParameter
    End Function

    Public Sub KillLogThreadProcess()
        FF.fProgramEnd = True
    End Sub

    Public Function InitLogObj(ByVal LogCaption As String) As Integer
        On Error GoTo Err_Handle

        If Not mvarfStart Then g_nLogCount = g_nLogCount + 1
        MyLog = New clsNetGlobLog
        MyLog.Caption = LogCaption
        MyLog.StartLog()

        If Not mvarfStart Then
            With MyParameter
                '.Max = 65535
                .LogVisible = False
                .AutoClear = True
                .Hold = False
            End With
        End If

        mvarLogCol.Add(MyLog)
        InitLogObj = mvarLogCol.Count
        mvarfStart = True
        Exit Function

Err_Handle:
        MsgBox("ErrNo : " & Err.Number & vbCrLf & "Description : " & Err.Description & vbCrLf & "Error occurred at line " & Erl() & " in " & My.Application.Info.Version.ToString & ".clsLogFactory.InitLogObj", vbCritical, My.Application.Info.Version.ToString)
    End Function

    Public Sub WriteLog(ByVal szText As String, Optional ByVal nIndex As Integer = 0)

        If mvarLogCol.Count > 0 Then
            If nIndex = 0 Then
                MyLog = mvarLogCol.Item(1)
            Else
                MyLog = mvarLogCol.Item(nIndex)
            End If
        End If
        MyLog.WriteLog(szText)
    End Sub

    Public Sub New()
        AssignMyForm()

        If MyParameter Is Nothing Then
            MyParameter = New clsLogParameter
        End If

        If mvarLogCol Is Nothing Then
            mvarLogCol = New Collection
        End If

        If MyAllLogCtrl Is Nothing Then
            MyAllLogCtrl = New ArrayList
        End If
    End Sub

    Public Sub Hide()
        MyForm.HideMe()
    End Sub

    Public Sub Show()
        MyForm.ShowMe()
    End Sub

    Protected Overrides Sub Finalize()

        Dim nFor As Integer
        For nFor = 1 To mvarLogCol.Count
            mvarLogCol.Remove(1)
        Next

        g_nLogCount = g_nLogCount - 1
        If g_nLogCount = 0 Then
            MyParameter = Nothing
        End If

        If Not MyLog Is Nothing Then
            MyLog = Nothing
        End If

        MyBase.Finalize()
    End Sub

    Private Sub MyLog_LogFull1() Handles MyLog.LogFull
        MyParameter.GenerateLogFull()
    End Sub
End Class

Public Class clsLogParameter
    Public Event LogFull()

    Public Property AutoCreateLogFile() As Boolean
        Get
            AutoCreateLogFile = mvarfAutoCreateFile
        End Get

        Set(ByVal value As Boolean)
            mvarfAutoCreateFile = value
        End Set
    End Property

    Public Property AutoClear() As Boolean
        Get
            AutoClear = mvarfAutoCLSFile
        End Get

        Set(ByVal value As Boolean)
            WaitFormCreate()
            mvarfAutoCLSFile = value
            If mvarfAutoCLSFile Then
                FF.foptPilledCChecked = True
            Else
                FF.foptPilledCChecked = True
            End If

            If value And Filled Then
                ClearLogAll()
            End If

        End Set
    End Property

    Public ReadOnly Property Filled() As Boolean
        Get
            Filled = (MyForm.lstGlobal.Items.Count >= g_nMaxLine)
        End Get
    End Property

    Public Property Hold() As Boolean
        Get
            Hold = mvarfStopWrite
        End Get

        Set(ByVal value As Boolean)
            mvarfStopWrite = value
        End Set
    End Property

    Public Property LogVisible() As Boolean
        Get
            Return FF.fShow
        End Get
        Set(ByVal value As Boolean)
            FF.fShow = value
        End Set
    End Property

    Public Property Max() As Integer
        Get
            Max = g_nMaxLine
        End Get

        Set(ByVal vData As Integer)
            If vData >= 0 And vData <= 65536 Then
                g_nMaxLine = vData
            End If
        End Set
    End Property

    Friend Sub GenerateLogFull()
        RaiseEvent LogFull()

        If AutoClear Then
            ClearLogAll()
        End If
    End Sub

    Public Sub SaveToFile(ByVal FileName As String)
        SaveToFileSub(FileName)
    End Sub

    Public Sub StartAutoSaveLog(ByVal FileName As String, ByVal LogDayKeep As Integer)
        WaitFormCreate()
        mvarfAutoSaveFile = True
        ParseLogFileName(FileName)

        If LogDayKeep > 0 Then
            myLogDaysKeep = LogDayKeep
            ClearLogFiles()
        End If

        If Not MyFileSystemIOSW Is Nothing Then
            MyFileSystemIOSW.Close()
        End If

        MyFileSystemIOSW = New System.IO.StreamWriter(FileName)
    End Sub

    Public Sub EndAutoSaveLog()
        If mvarfAutoSaveFile Then
            mvarfAutoSaveFile = False
            MyFileSystemIOSW.Close()
            MyFileSystemIOSW = Nothing
            'fsAutoSave = Nothing
        End If
    End Sub

    Public Sub ClearLogAll()
        FF.fClearLogAll = True
    End Sub

    Public Sub New()
        If Not MyFileSystemIOSW Is Nothing Then
            MyFileSystemIOSW.Close()
            MyFileSystemIOSW = Nothing
        End If
    End Sub

End Class
