Imports System.Windows.Forms

Public Class DialogCassetteInfoColumnSelection

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        _L8B.Setting.Main.fCIMShowColumn(1) = True
        _L8B.Setting.Main.fCIMShowColumn(2) = True
        _L8B.Setting.Main.fCIMShowColumn(3) = CheckBox3.Checked
        _L8B.Setting.Main.fCIMShowColumn(4) = CheckBox4.Checked
        _L8B.Setting.Main.fCIMShowColumn(5) = CheckBox5.Checked

        _L8B.Setting.Main.fCIMShowColumn(6) = CheckBox6.Checked
        _L8B.Setting.Main.fCIMShowColumn(7) = CheckBox7.Checked
        _L8B.Setting.Main.fCIMShowColumn(8) = CheckBox8.Checked
        _L8B.Setting.Main.fCIMShowColumn(9) = CheckBox9.Checked
        _L8B.Setting.Main.fCIMShowColumn(10) = CheckBox10.Checked

        _L8B.Setting.Main.fCIMShowColumn(11) = CheckBox11.Checked
        _L8B.Setting.Main.fCIMShowColumn(12) = CheckBox12.Checked
        _L8B.Setting.Main.fCIMShowColumn(13) = CheckBox13.Checked
        _L8B.Setting.Main.fCIMShowColumn(14) = CheckBox14.Checked
        _L8B.Setting.Main.fCIMShowColumn(15) = CheckBox15.Checked

        _L8B.Setting.Main.fCIMShowColumn(16) = CheckBox16.Checked

        _L8B.Setting.IniSave()
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub


    Public Sub showMe()
        Me.Visible = False
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox3.Checked = _L8B.Setting.Main.fCIMShowColumn(3)
        CheckBox4.Checked = _L8B.Setting.Main.fCIMShowColumn(4)
        CheckBox5.Checked = _L8B.Setting.Main.fCIMShowColumn(5)

        CheckBox6.Checked = _L8B.Setting.Main.fCIMShowColumn(6)
        CheckBox7.Checked = _L8B.Setting.Main.fCIMShowColumn(7)
        CheckBox8.Checked = _L8B.Setting.Main.fCIMShowColumn(8)
        CheckBox9.Checked = _L8B.Setting.Main.fCIMShowColumn(9)
        CheckBox10.Checked = _L8B.Setting.Main.fCIMShowColumn(10)

        CheckBox11.Checked = _L8B.Setting.Main.fCIMShowColumn(11)
        CheckBox12.Checked = _L8B.Setting.Main.fCIMShowColumn(12)
        CheckBox13.Checked = _L8B.Setting.Main.fCIMShowColumn(13)
        CheckBox14.Checked = _L8B.Setting.Main.fCIMShowColumn(14)
        CheckBox15.Checked = _L8B.Setting.Main.fCIMShowColumn(15)

        CheckBox16.Checked = _L8B.Setting.Main.fCIMShowColumn(16)

        Me.Show()
    End Sub


End Class
