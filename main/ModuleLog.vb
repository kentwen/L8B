Module ModuleLog
    Public WithEvents MyIniLog As New RainBowTech.clsLogParameter
    Public WithEvents Log As New RainBowTech.clsLogFactory


    Public Enum LogMessageType
        [Info]
        [Warn]
        [Manual]
        [PROPERTY]
        [SYS]
        [METHOD]
        [EVENT]
        [ERR]
        [OPSET]
        [EXCEPTION]
    End Enum

    Public Sub InitialLog()
        MyIniLog.StartAutoSaveLog(GenerateLogFile, 30)

        MyIniLog.AutoClear = True
        MyIniLog.Max = 5000
        MyIniLog.AutoCreateLogFile = True
        MyIniLog.LogVisible = False

        _L8B.Log = Log

        _L8B.Log.InitLogObj("Main")
    End Sub

    Public Function GenerateLogFile() As String
        Dim strLogFile As String
        Dim nYear As Integer
        Dim nMonth As Integer
        Dim nDay As Integer
        Dim nHour As Integer
        Dim nMinute As Integer
        Dim nSecond As Integer

        nYear = Microsoft.VisualBasic.DateAndTime.Year(Now)
        nMonth = Microsoft.VisualBasic.DateAndTime.Month(Now)
        nDay = Microsoft.VisualBasic.DateAndTime.Day(Now)
        nHour = Microsoft.VisualBasic.DateAndTime.Hour(Now)
        nMinute = Microsoft.VisualBasic.DateAndTime.Minute(Now)
        nSecond = Microsoft.VisualBasic.DateAndTime.Second(Now)

        strLogFile = LOGPATH & CStr(nYear) & Microsoft.VisualBasic.Right("0" & CStr(nMonth), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nDay), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nHour), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nMinute), 2) & _
                     Microsoft.VisualBasic.Right("0" & CStr(nSecond), 2) & ".log"

        Return strLogFile

    End Function

    Public Sub WriteLog(ByVal Msg As String, Optional ByVal vType As LogMessageType = LogMessageType.Info)
        Dim strHeader As String = String.Format("[{0}]", vType.ToString)
        Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")
        strHeader = strHeader & Space(12 - strHeader.Length)
        _L8B.Log.WriteLog(MyTime & " Main    ->" & strHeader & Space(5) & Msg)

    End Sub
End Module
