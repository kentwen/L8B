Public Class FormCassetteInfoText
    Public PortNO As Integer

    Public Sub ShowMe()

        Dim mTmp As String = ""

        TextBoxInfo.Text = ""

        mTmp &= "Port#" & PortNO & ";  " & GetAUODateTime(Now) & vbCrLf
        Try
            mTmp &= "CassetteID: " & _L8B.CIM.LotInfo(PortNO).CassetteID & vbCrLf
            mTmp &= "ProductCode: " & _L8B.CIM.LotInfo(PortNO).ProductCode & vbCrLf
            mTmp &= "PPID: " & _L8B.CIM.LotInfo(PortNO).RecipeName & vbCrLf
        Catch ex As Exception
            mTmp &= "PPID: " & vbCrLf
        End Try


        For i As Integer = 1 To MAXCASSETTESLOT & vbCrLf
            Try
                mTmp &= "Slot#" & i & ", GlassID:" & _L8B.CIM.LotInfo(PortNO).Slots(i).GlassID & vbCrLf
            Catch ex As Exception
                mTmp &= "Slot#" & i & ", GlassID:" & vbCrLf
            End Try
        Next

        TextBoxInfo.Text = mTmp
        Me.Text = "Port" & PortNO & " Cassette Info"
        Me.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Button1.Enabled = False
            Clipboard.Clear()
            Clipboard.SetText(TextBoxInfo.Text)
            Button1.Enabled = True
        Catch ex As Exception
            Button1.Enabled = True
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Hide()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ShowMe()
        Catch ex As Exception

        End Try
    End Sub
End Class