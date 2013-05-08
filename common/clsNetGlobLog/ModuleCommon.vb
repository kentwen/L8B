Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.IO

Module ModuleCommon
    Public g_nLogCount As Integer
    Public g_nMaxLine As Integer

    Public mvarfStopWrite As Boolean
    Public mvarfStart As Boolean
    Public mvarfAutoSaveFile As Boolean
    Public mvarfAutoCLSFile As Boolean
    Public mvarfAutoCreateFile As Boolean
    Public MyAllLogCtrl As ArrayList

    Public MyFileSystemIOSW As System.IO.StreamWriter
    Public strLogFilePath As String
    Public strLogFileName As String

    Public MyParameter As New clsLogParameter
    Public MyForm As FormMain

    Public myLogDaysKeep As Integer


    Public Class tFormFunction
        Public fClearLogAll As Boolean
        Public foptPilledCChecked As Boolean
        Public fShow As Boolean
        Public fProgramEnd As Boolean
        Public TabPageQueue As New Queue
        Public Listboxs As New Dictionary(Of Integer, Windows.Forms.ListBox)
    End Class

    Public FF As New tFormFunction
    Public LogInfo As MsgType

    Public Structure MsgType
        Public oListBox As Object
        Public LogTitle As String
        Public Str As Object
    End Structure

    Public Sub ParseLogFileName(ByVal FileName As String)

        Dim nFor As Integer
        Dim nPos As Integer

        For nFor = 1 To Len(FileName)
            If Mid(FileName, nFor, 1) = "\" Then nPos = nFor
        Next

        strLogFilePath = Mid(FileName, 1, nPos)
        If Not Directory.Exists(strLogFilePath) Then
            CreateDiretory(FileName)
        End If
        strLogFileName = Mid(FileName, nPos + 1)
    End Sub


    Public Sub ClearLogFiles()
        Static fRun As Boolean
        If fRun Then
            Exit Sub
        End If
        fRun = True
        Try
            If Directory.Exists(strLogFilePath) Then
                Dim Files() As String = Directory.GetFiles(strLogFilePath)

                If Files.Length > 0 Then
                    For i As Integer = 0 To Files.Length - 1
                        If Math.Abs(DateDiff(DateInterval.Day, My.Computer.FileSystem.GetFileInfo(Files(i)).CreationTime, Now)) > myLogDaysKeep Then
                            My.Computer.FileSystem.DeleteFile(Files(i), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                        End If
                    Next
                End If
            End If
        Catch ex As ApplicationException
            fRun = False
            Debug.Write(ex.ToString)
        End Try

        fRun = False
    End Sub

    Public Sub DriveWriteLog(ByVal strText As Object)
        SyncLock MyFileSystemIOSW
            Dim vDate As Date
            Dim strData As String
            If mvarfAutoCreateFile Then
                strData = Left(strLogFileName, 4) & "/" & Mid(strLogFileName, 5, 2) & "/" & Mid(strLogFileName, 7, 2)
                vDate = CDate(strData)
                If DateDiff("d", vDate, Now) >= 1 Then
                    strLogFileName = Format(Now(), "yyyyMMddhhmmss") & ".log"
                    MyFileSystemIOSW.WriteLine("<<< Log File Change To " & strLogFileName & " >>>")
                    MyFileSystemIOSW.Flush()
                    MyFileSystemIOSW.Close()
                    MyFileSystemIOSW = New System.IO.StreamWriter(strLogFilePath & strLogFileName)
                    ClearLogFiles()
                End If
            End If


            If MyFileSystemIOSW IsNot Nothing Then
                MyFileSystemIOSW.WriteLine(strText)
                MyFileSystemIOSW.Flush()
            Else
                strLogFileName = Format(Now(), "yyyyMMddhhmmss") & ".log"
                MyFileSystemIOSW = New System.IO.StreamWriter(strLogFilePath & strLogFileName)
                MyFileSystemIOSW.WriteLine(">>> Log File create new file " & strLogFileName & " <<<")

                MyFileSystemIOSW.WriteLine(strText)
                MyFileSystemIOSW.Flush()
            End If

        End SyncLock

    End Sub

    Public Sub SaveToFileSub(ByVal FileName As String)

        Dim SW As New System.IO.StreamWriter(FileName)
        Dim nFor As Integer

        For nFor = 0 To MyForm.lstGlobal.Items.Count - 1
            SW.WriteLine(MyForm.lstGlobal.Items.Item(nFor))
        Next
        SW.Flush()
        SW.Close()
        SW = Nothing

    End Sub


    Private Function CreateDiretory(ByVal fileName As String) As Boolean
        Dim S() As String = fileName.Split("\")
        Dim Z As String = ""

        Try
            If Not My.Computer.FileSystem.DirectoryExists(S(0)) Then
                Return False
            End If

            Z = S(0)
            For i As Integer = 1 To S.GetUpperBound(0) - 1
                Z &= "\" & S(i)
                If Not My.Computer.FileSystem.DirectoryExists(Z) Then
                    My.Computer.FileSystem.CreateDirectory(Z)
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Class CloseButton

        Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
        Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

        Private Const SC_CLOSE As Integer = &HF060
        Private Const MF_BYCOMMAND As Integer = &H0
        Private Const MF_GRAYED As Integer = &H1
        Private Const MF_ENABLED As Integer = &H0

        Private Sub New()
        End Sub

        Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
            ' The return value specifies the previous state of the menu item (it is either 
            ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.
            Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
                Case MF_ENABLED
                Case MF_GRAYED
                Case &HFFFFFFFF
                    Throw New Exception("The Close menu item does not exist.")
                Case Else
            End Select
        End Sub
    End Class

    Public LogFormThread As New Thread(AddressOf CreateNewMyForm)

    Public Sub AssignMyForm()
        Static fRunning As Boolean

        If fRunning Then
            Exit Sub
        End If
        fRunning = True
        If MyForm Is Nothing Then
            LogFormThread.SetApartmentState(ApartmentState.STA)
            LogFormThread.Start()
        End If
        WaitFormCreate()
        fRunning = False
    End Sub

    Public Sub CreateNewMyForm()
        MyForm = New FormMain
        MyForm.Show()
        MyForm.Visible = True

        While Not FF.fProgramEnd
            System.Windows.Forms.Application.DoEvents()
            Threading.Thread.Sleep(50)
        End While
    End Sub


    Public Sub WaitFormCreate()
        While MyForm Is Nothing

            System.Windows.Forms.Application.DoEvents()

        End While
    End Sub
End Module
