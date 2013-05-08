Public Class Form1
    Dim a As Integer
    Dim b As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        a = a + 1
        Me.RstguiCtrlCV1.InsertGlassToBuffer(a)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.RstguiCtrlCV1.RemoveGlassFromBuffer(a)
        a = a - 1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        b = b + 1
        Me.RstguiCtrlCV1.InsertGlassToCST(b)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.RstguiCtrlCV1.RemoveGlassFromCST(b)
        b = b - 1
    End Sub

    Private Sub RstguiCtrlCV1_CSTDummyCancelChange(ByVal fCancel As Boolean) Handles RstguiCtrlCV1.CSTDummyCancelChange
        MsgBox(fCancel)
    End Sub

    Private Sub RstguiLabel1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub RstguiCtrlCV1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RstguiCtrlCV1.Load

    End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    '    RstguiCtrlSlots1.WithGx(Me.TextBox1.Text) = True
    '    RstguiCtrlSlots1.GxID(Me.TextBox1.Text) = Me.TextBox1.Text
    'End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    RstguiCtrlSlots1.WithGx(Me.TextBox1.Text) = False

    'End Sub

    Private Sub RstguiCtrlSlots1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
