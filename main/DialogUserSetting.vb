Imports System.Windows.Forms

Public Class DialogUserSetting
    Dim WithEvents DialogRetypePWD As New DialogRetypePassword
    Const UserSection As String = "Users"

    Dim UserList As ArrayList

    Public Sub Showme()
        Me.Show()
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        ButtonSave.Enabled = False
        DialogRetypePWD.ShowMe("Save", "Input Super Password")
    End Sub


    Private Sub ComboBoxUser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxUser.KeyUp
        If e.KeyCode = Keys.Enter Then
            If ComboBoxUser.Text <> "" Then
                TextBoxPassword.Text = ReadINIString(UserSection, ComboBoxUser.Text & "Password")
                SetAutherity()
            End If
        End If
    End Sub

    Private Sub ComboBoxUser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxUser.LostFocus
        If ComboBoxUser.Text <> "" Then
            TextBoxPassword.Text = ReadINIString(UserSection, ComboBoxUser.Text & "Password")
            SetAutherity()
        End If
    End Sub

    Private Sub ComboBoxUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxUser.SelectedIndexChanged
        If ComboBoxUser.Text <> "" Then
            TextBoxPassword.Text = ReadINIString(UserSection, ComboBoxUser.Text & "Password")
            SetAutherity()
        End If
    End Sub

    Private Function GetAutherity() As String
        Dim s As String = "x"
        s &= "," & CheckBox1.Checked
        s &= "," & CheckBox2.Checked
        s &= "," & CheckBox3.Checked
        s &= "," & CheckBox4.Checked
        s &= "," & CheckBox5.Checked
        s &= "," & CheckBox6.Checked
        s &= "," & CheckBox7.Checked
        s &= "," & CheckBox8.Checked
        s &= "," & CheckBox9.Checked
        s &= "," & CheckBox10.Checked
        s &= "," & CheckBox11.Checked
        s &= "," & CheckBox12.Checked
        s &= "," & CheckBox13.Checked
        s &= "," & CheckBox14.Checked
        s &= "," & CheckBox15.Checked
        s &= "," & CheckBox16.Checked
        s &= "," & CheckBox17.Checked
        s &= "," & CheckBox18.Checked
        s &= "," & CheckBox19.Checked
        s &= "," & CheckBox20.Checked
        s &= "," & CheckBox21.Checked
        s &= "," & CheckBox22.Checked
        s &= "," & CheckBox23.Checked
        s &= "," & CheckBox24.Checked
        s &= "," & CheckBox25.Checked
        s &= "," & CheckBox26.Checked
        s &= "," & CheckBox27.Checked
        s &= "," & CheckBox28.Checked
        s &= "," & CheckBox29.Checked
        Return s
    End Function

    Private Sub SetAutherity()

        Dim s() As String = ReadINIString(UserSection, ComboBoxUser.Text & "Autherity").Split(",")

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False
        CheckBox12.Checked = False
        CheckBox13.Checked = False
        CheckBox14.Checked = False
        CheckBox15.Checked = False
        CheckBox16.Checked = False
        CheckBox17.Checked = False
        CheckBox18.Checked = False
        CheckBox19.Checked = False
        CheckBox20.Checked = False
        CheckBox21.Checked = False
        CheckBox22.Checked = False
        CheckBox23.Checked = False
        CheckBox24.Checked = False
        CheckBox25.Checked = False
        CheckBox26.Checked = False
        CheckBox27.Checked = False
        CheckBox28.Checked = False
        CheckBox29.Checked = False

        Try
            CheckBox1.Checked = s(1)
            CheckBox2.Checked = s(2)
            CheckBox3.Checked = s(3)
            CheckBox4.Checked = s(4)
            CheckBox5.Checked = s(5)
            CheckBox6.Checked = s(6)
            CheckBox7.Checked = s(7)
            CheckBox8.Checked = s(8)
            CheckBox9.Checked = s(9)
            CheckBox10.Checked = s(10)
            CheckBox11.Checked = s(11)
            CheckBox12.Checked = s(12)
            CheckBox13.Checked = s(13)
            CheckBox14.Checked = s(14)
            CheckBox15.Checked = s(15)
            CheckBox16.Checked = s(16)
            CheckBox17.Checked = s(17)
            CheckBox18.Checked = s(18)
            CheckBox19.Checked = s(19)
            CheckBox20.Checked = s(20)
            CheckBox21.Checked = s(21)
            CheckBox22.Checked = s(22)
            CheckBox23.Checked = s(23)
            CheckBox24.Checked = s(24)
            CheckBox25.Checked = s(25)
            CheckBox26.Checked = s(26)
            CheckBox27.Checked = s(27)
            CheckBox28.Checked = s(28)
            CheckBox29.Checked = s(29)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CreateUserList()
        Dim s() As String = ReadINIString(UserSection, "UserList").Split(",")
        UserList = New ArrayList

        If s.Length > 0 AndAlso s(0) <> "" Then
            For i As Integer = 0 To s.Length - 1
                UserList.Add(s(i))
            Next
        Else
            UserList.Add("Admin")
            UserList.Add("OP")
            UserList.Add("Engineer")
            UserList.Add("AUO")
        End If
    End Sub


    Private Function AddAnUserToList(ByVal vName As String) As Boolean
        Dim z As String = ""
        UserList.Add(vName)
        UserList.Sort()
        For Each s As String In UserList
            If z = "" Then
                z = s
            Else
                z &= "," & s
            End If
        Next
        WriteINIString(UserSection, "UserList", z)
    End Function


    Private Sub DialogUserSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CreateUserList()
        ComboBoxUser.DataSource = UserList
        ListBoxUser.DataSource = UserList
        ComboBoxUser.Focus()
        ComboBoxUser.SelectAll()
    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        'DialogRetypePWD = New DialogRetypePassword
        Me.Enabled = False
        DialogRetypePWD.ShowMe("Delete", "Please Input SuperPassword")
    End Sub

    Private Function DeleteAnUserToList(ByVal vName As String) As Boolean
        Dim z As String = ""
        If vName <> "" Then
            UserList.Remove(vName)
            UserList.Sort()
            For Each s As String In UserList
                If z = "" Then
                    z = s
                Else
                    z &= "," & s
                End If
            Next
            WriteINIString(UserSection, "UserList", z)
        End If
    End Function


    Private Sub DialogRetypePWD_ClickOK(ByVal vType As String, ByVal vPWD As String) Handles DialogRetypePWD.ClickOK
        Dim t As String = ""
        Me.Enabled = True
        If vPWD = _L8B.Setting.Main.SuperPassword Then
            If vType = "Save" Then
                t = ComboBoxUser.Text
                WriteINIString(UserSection, ComboBoxUser.Text & "Password", TextBoxPassword.Text)
                WriteINIString(UserSection, ComboBoxUser.Text & "Autherity", GetAutherity)
                If Not UserList.Contains(ComboBoxUser.Text) Then
                    AddAnUserToList(ComboBoxUser.Text)
                End If
            ElseIf vType = "Delete" Then
                DeleteAnUserToList(ComboBoxUser.Text)
            End If

            ComboBoxUser.DataSource = Nothing
            ComboBoxUser.DataSource = UserList
            ListBoxUser.DataSource = Nothing
            ListBoxUser.DataSource = UserList
            ComboBoxUser.Text = t
        Else
            MsgBox("SuperPassword not match.  Please try again.", MsgBoxStyle.OkOnly)
        End If
        ButtonSave.Enabled = True
    End Sub

End Class
