Imports System.Windows.Forms

Public Class DialogRetypePassword
    Public Event ClickOK(ByVal vType As String, ByVal vPWD As String)

    Dim mType As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Hide()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        RaiseEvent ClickOK(mType, TextBoxRetypePassword.Text)
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        RaiseEvent ClickOK("", TextBoxRetypePassword.Text)
        Me.Hide()
    End Sub

    Private Sub DialogRetypePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBoxRetypePassword.Focus()
    End Sub

    Public Sub ShowMe(ByVal vType As String, Optional ByVal vCaption As String = "")
        If vCaption.Length > 0 Then
            Me.Text = vCaption
        End If
        mType = vType
        TextBoxRetypePassword.Text = ""
        Me.Show()
    End Sub

End Class
