Public Class LoginFormChangePassword

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim Section As String = "Users"
        Dim mOPID As String = MyTrim(UsernameTextBox.Text)
        Dim mPassword As String = PasswordTextBox.Text
        Dim mNewPassword As String = NewPasswordTextBox.Text
        Dim mNewPasswordRetype As String = RetypeNewPasswordTextBox.Text

        If MyTrim(NewPasswordTextBox.Text).Length < 6 Then
            If MsgBox("New Password length < 6 !!" & vbCrLf & " Retry", MsgBoxStyle.YesNo, "Change Password fail") = MsgBoxResult.Yes Then
                NewPasswordTextBox.Focus()
                Return
            Else
                Me.Hide()
                Return
            End If
        End If

        If mNewPassword <> mNewPasswordRetype Then
            If MsgBox("New Password <> New Password Retype!! " & vbCrLf & " Retry", MsgBoxStyle.YesNo, "Change Password fail") = MsgBoxResult.Yes Then
                NewPasswordTextBox.Focus()
                Return
            Else
                Me.Hide()
                Return
            End If
        End If

        If _L8B.Setting.CheckUser(UsernameTextBox.Text) And mPassword = ReadINIString(Section, mOPID & "Password") Then
            WriteINIString(Section, mOPID & "Password", mNewPassword)
        Else
            If MsgBox("Password is not correct. " & vbCrLf & " Retry", MsgBoxStyle.YesNo, "Change Password fail") = MsgBoxResult.Yes Then
                PasswordTextBox.Focus()
                Return
            End If
        End If

        Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Hide()
    End Sub

    Public Sub LoginLoad()
        UsernameTextBox.Text = _L8B.Setting.User.Name
        PasswordTextBox.Text = ""
        NewPasswordTextBox.Text = ""
        ReTypeNewPasswordTextBox.text = ""

        Me.BringToFront()
        Me.SetTopLevel(True)
        Me.Focus()
        PasswordTextBox.Focus()
        Me.ShowDialog()
    End Sub
End Class
