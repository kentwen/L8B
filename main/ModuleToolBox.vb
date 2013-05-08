Module ModuleToolBox

    Public Structure ControlPL
        Dim Location As System.Drawing.Point
        Dim Size As System.Drawing.Size
        Dim Font As System.Drawing.Font
    End Structure



    Public Declare Function SetWindowPos Lib "user32" (ByVal hWnd As Long, ByVal hWndInsertAfter As Long, ByVal x As Long, ByVal y As Long, ByVal cx As Long, ByVal cy As Long, ByVal wFlags As Long) As Long
    Public Const MF_BYPOSITION = &H400
    Public Const HWND_TOPMOST = -1
    Public Const SWP_NOSIZE = &H1
    Public Const SWP_NOMOVE = &H2

    Private Sub AlwaysOnTop(ByVal hWnd As Long)
        SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE)
    End Sub

    Public Function RowField(ByVal vRow As System.Data.DataRow, ByVal vField As String) As String
        Return IIf(IsDBNull(vRow(vField)), "", vRow(vField))
    End Function

    Public Function GetAUODateTime(ByVal vdate As Date) As String
        Return Format(vdate, "yyyyMMddHHmmss")
    End Function

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

    Public Function NowString() As String
        Return String.Format("{0:yyyy/MM/dd HH:mm:ss}.{1:0##}", Now, Now.Millisecond)
    End Function

    'program Start since from the midnight in seconds
    Public Function MyTimer() As Double
        Static StartTimer As Long
        If StartTimer = 0 Then
            StartTimer = Now.Ticks
        End If
        Return CDbl(Now.Ticks - StartTimer) / 10000000
    End Function

    Public Function DebugMode() As Boolean
#If DEBUG Then
        Return True
#End If
        Return False

    End Function

    Public Function CreateDiretoryByFileName(ByVal fileName As String) As Boolean
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


    Public Function CreateDiretory(ByVal Directory As System.IO.DirectoryInfo) As Boolean
        Dim S() As String = Directory.FullName.Split("\")
        Dim Z As String = ""

        Try
            If Not My.Computer.FileSystem.DirectoryExists(S(0)) Then
                Return False
            End If

            Z = S(0)
            For i As Integer = 1 To S.GetUpperBound(0)
                Z &= "\" & S(i)
                If Not My.Computer.FileSystem.DirectoryExists(Z) Then
                    My.Computer.FileSystem.CreateDirectory(Z)
                End If
            Next
            WriteLog("CreateDiretory [" & Directory.FullName & "] OK", LogMessageType.SYS)
            Return True
        Catch ex As Exception
            WriteLog("CreateDiretory [" & Directory.FullName & "] Fail", LogMessageType.SYS)
            Return False
        End Try

    End Function

    Public Class CloseButtonRemove

        Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
        Private Declare Function GetMenuItemCount Lib "user32" (ByVal menu As Integer) As Integer
        Private Declare Function RemoveMenu Lib "user32" (ByVal menu As Integer, ByVal position As Integer, ByVal flags As Integer) As Integer
        Private Declare Function DrawMenuBar Lib "user32" (ByVal hwnd As Integer) As Integer
        Private Declare Function FormatMessageA Lib "kernel32" (ByVal flags As Integer, ByRef source As Object, ByVal messageID As Integer, ByVal languageID As Integer, ByVal buffer As String, ByVal size As Integer, ByRef arguments As Integer) As Integer

        Private Const MF_BYPOSITION As Integer = &H400
        Private Const MF_DISABLED As Integer = &H2

        Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
            ' Get handle to system menu for the form provided.
            Dim menu As Integer = GetSystemMenu(form.Handle.ToInt32, 0)
            ' Get number of items in this system menu.
            Dim count As Integer = GetMenuItemCount(menu)
            ' Remove last item from system menu (last item should be ’Close’).
            If RemoveMenu(menu, count - 1, MF_DISABLED Or MF_BYPOSITION) = 0 Then
                Throw New Exception(FormatMessage(Err.LastDllError))
            Else
                ' On success, force a redraw of the system menu.
                If DrawMenuBar(form.Handle.ToInt32) = 0 Then
                    Throw New Exception(FormatMessage(Err.LastDllError))
                End If
            End If
        End Sub

        Public Shared Function FormatMessage(ByVal [error] As Integer) As String
            Const FORMAT_MESSAGE_FROM_SYSTEM As Short = &H1000
            Const LANG_NEUTRAL As Short = &H0
            Dim buffer As String = Space(999)
            FormatMessageA(FORMAT_MESSAGE_FROM_SYSTEM, 0, [error], LANG_NEUTRAL, buffer, 999, 0)
            buffer = Replace(Replace(buffer, Chr(13), ""), Chr(10), "")
            Return buffer.Substring(0, buffer.IndexOf(Chr(0)))
        End Function
    End Class

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

    Private Function CreateDiretory(ByVal fileName As String) As Boolean
        Try
            Dim S() As String = fileName.Split("\")
            Dim Z As String = ""

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

    Public Function EnumNamesList(ByVal vEnum As System.Type, Optional ByVal nSplite As Integer = 0) As ArrayList ', Optional ByVal RemoveNone As Boolean = False

        Dim zTemp As String() = [Enum].GetNames(vEnum)
        Dim Ret As New ArrayList
        Dim zSplite As String()

        For Each S As String In zTemp
            zSplite = S.Split("_")
            Ret.Add(zSplite(nSplite))
        Next
        'If RemoveNone Then
        '    Ret.RemoveAt(0)
        'End If
        Return Ret
    End Function

    Public Function MyTrim(ByRef zStr As String) As String
        Return MyTrimStart(MyTrimEnd(zStr))
    End Function

    Public Function MyTrimStart(ByRef zStr As String) As String
        Try
            If zStr Is Nothing Then Return ""

            Dim zTmp As String = ""
            Dim Index As Integer = -1

            For i As Integer = 0 To zStr.Length - 1
                If Asc(zStr(i)) <> &H20 AndAlso Asc(zStr(i)) <> 255 AndAlso Asc(zStr(i)) > 0 Then
                    Index = i
                    Exit For
                End If
            Next

            If Index <= zStr.Length - 1 AndAlso Index >= 0 Then
                For i As Integer = Index To zStr.Length - 1
                    zTmp &= zStr(i)
                Next
            End If

            Return zTmp
        Catch ex As Exception
            Debug.WriteLine(zStr & " " & ex.ToString)
            Return ""
        End Try
    End Function


    Public Function MyTrimEnd(ByRef zStr As String) As String
        Try
            If zStr Is Nothing Then Return ""

            Dim zTmp As String = ""
            Dim Index As Integer = -1

            For i As Integer = zStr.Length - 1 To 0 Step -1
                If Asc(zStr(i)) <> &H20 AndAlso Asc(zStr(i)) <> 255 AndAlso Asc(zStr(i)) > 0 Then
                    Index = i
                    Exit For
                End If
            Next

            If Index >= 0 Then
                For i As Integer = 0 To Index
                    zTmp &= zStr(i)
                Next
            End If

            Return zTmp
        Catch ex As Exception
            Debug.WriteLine(zStr & " " & ex.ToString)
            Return ""
        End Try
    End Function

End Module

