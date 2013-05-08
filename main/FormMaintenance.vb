Public Class FormMaintenance
    Dim ControlsPosLocation As ArrayList
    Dim ShapsPosLocation As ArrayList
    Dim OldcontrolSize As ControlPL


    Public Sub ShowMe()
        TextBoxPhoneE.Text = _L8B.Setting.Maintain.Phone
        TextBoxPhoneC.Text = _L8B.Setting.Maintain.Phone
        TextBoxUserID.Text = ""
        TextBoxPassword.Text = ""
        ButtonExit.Visible = False
        ButtonBuzzerOff.Visible = False
        ButtonSave.Visible = False
        GroupBoxLogin.Visible = True
        TextBoxPhoneC.ReadOnly = True
        Me.Show()
    End Sub

    Private Sub FormMaintenance_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        GroupBoxLogin.Visible = True
    End Sub


    Private Sub FormMaintenance_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If OldcontrolSize.Size.Width = 0 OrElse OldcontrolSize.Size.Height = 0 Then
            Exit Sub
        End If

        Dim lx As Double = Me.Width / OldcontrolSize.Size.Width
        Dim ly As Double = Me.Height / OldcontrolSize.Size.Height

        For i As Integer = 0 To Me.Controls.Count - 1
            If Me.Controls(i).Name <> "GroupBoxLogin" Then
                Me.Controls(i).Width = CInt(ControlsPosLocation(i).Size.width * lx)
                Me.Controls(i).Height = CInt(ControlsPosLocation(i).Size.Height * ly)
                Me.Controls(i).Left = CInt(ControlsPosLocation(i).Location.X * lx)
                Me.Controls(i).Top = CInt(ControlsPosLocation(i).Location.Y * ly)
            Else
                Me.Controls(i).Left = CInt(ControlsPosLocation(i).Location.X * lx)
                Me.Controls(i).Top = CInt(ControlsPosLocation(i).Location.Y * ly)
            End If
        Next
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ControlsPosLocation = New ArrayList
        ShapsPosLocation = New ArrayList
        Dim PosLocation As ControlPL

        For Each ctl As Object In Me.Controls
            PosLocation.Location = ctl.Location
            PosLocation.Size = ctl.size
            If ctl.Font IsNot Nothing Then
                PosLocation.Font = ctl.font
            Else
                PosLocation.Font = Nothing
            End If
            ControlsPosLocation.Add(PosLocation)
        Next

        OldcontrolSize.Size = Me.Size
        OldcontrolSize.Location = Me.Location
    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        _L8B.PLC.PM(False)
        Me.Hide()
    End Sub

    Private Sub TextBoxPhoneC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxPhoneC.KeyUp
        TextBoxPhoneE.Text = TextBoxPhoneC.Text
    End Sub

    Private Sub TextBoxPhoneC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPhoneC.LostFocus
        TextBoxPhoneE.Text = TextBoxPhoneC.Text
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        _L8B.Setting.Maintain.Phone = TextBoxPhoneE.Text
        _L8B.Setting.IniSave()
    End Sub

    Private Sub ButtonLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogin.Click
        If _L8B.Setting.CheckUser(TextBoxUserID.Text, TextBoxPassword.Text) Then
            ButtonExit.Visible = True
            ButtonBuzzerOff.Visible = True
            ButtonSave.Visible = True
            GroupBoxLogin.Visible = False
            TextBoxPhoneC.ReadOnly = False
        End If
    End Sub

    Private Sub TextBoxPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPassword.KeyPress
        If _L8B.Setting.CheckUser(TextBoxUserID.Text, TextBoxPassword.Text) Then
            ButtonExit.Visible = True
            ButtonBuzzerOff.Visible = True
            ButtonSave.Visible = True
            GroupBoxLogin.Visible = False
            TextBoxPhoneC.ReadOnly = False
        End If
    End Sub

End Class