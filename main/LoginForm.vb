Public Class LoginForm
    Dim bFirstTime As Boolean
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        If DebugMode() AndAlso TextBoxUserID.Text = "" Then
            TextBoxUserID.Text = "Admin"
            TextBoxPassword.Text = "123"
        End If
        Dim Section As String = "Users"
        If _L8B.Setting.CheckUser(TextBoxUserID.Text) And TextBoxPassword.Text = ReadINIString(Section, TextBoxUserID.Text & "Password") Then
            If _L8B.Setting.User.Login(TextBoxUserID.Text, TextBoxPassword.Text) Then
                _L8B.frmMain.SetupUserAutherity()
                _L8B.frmMain.Enabled = True
                _L8B.frmMain.ButtonLogout.Text = "Logout"
                _L8B.frmMain.Text = _L8B.Setting.ID.Tool & " -- " & Application.ProductVersion.ToString & " [" & TextBoxUserID.Text & "] Login " & My.Application.Info.Version.ToString & "." & DateVersion
                WriteLog("User[" & TextBoxUserID.Text & "] Login OK", LogMessageType.Info)
                Me.Hide()
                _L8B.frmMain.WindowState = FormWindowState.Normal
                If bFirstTime Then
                    bFirstTime = False
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Please Wait", MsgBoxStyle.OkOnly, 1)
                    _L8B.dlgBufferGlassInfo.ShowMe()
                End If
            Else
                WriteLog("User[" & TextBoxUserID.Text & "] Password[" & TextBoxPassword.Text & "] Login Fail", LogMessageType.Info)
            End If

        Else
            _L8B.Log.Hide()
            MsgBox("user not exists or password not correct.", MsgBoxStyle.OkOnly)
            WriteLog("User[" & TextBoxUserID.Text & "] Password[" & TextBoxPassword.Text & "] Login Fail", LogMessageType.Info)
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click

        _L8B.frmMain.SetupUserAutherity()
        _L8B.frmMain.Enabled = True
        WriteLog("Login windows user click [Cancel]", LogMessageType.Info)
        If bFirstTime Then
            End
        Else
            Me.Hide()
        End If
    End Sub

    Public Sub LoginLoad()
        TextBoxUserID.Text = ""
        TextBoxPassword.Text = ""
        If Not bFirstTime Then Cancel.Text = "&Cancel"

        Me.ShowDialog()
        Me.BringToFront()

        Me.Focus()
        Me.SetTopLevel(True)
        TextBoxUserID.Focus()

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bFirstTime = True
    End Sub

    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.BringToFront()
        Me.Focus()
        Me.SetTopLevel(True)
    End Sub
End Class
