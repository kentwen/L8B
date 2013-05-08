Imports System.Drawing

Public Class GXTR_CV2RST

    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarENGType As Boolean
    Private mvarTabIdx As Integer

    Public ReadOnly Property TabIdx() As Integer
        Get
            TabIdx = Me.TabControl1.SelectedIndex
        End Get
    End Property

    Public Property ENGType() As Boolean
        Get
            ENGType = mvarENGType
        End Get
        Set(ByVal value As Boolean)
            mvarENGType = value
        End Set
    End Property


    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "01E1", "01E4", "01E7", "01EA", "01ED"
                If nOnOff = 1 Then
                    Me.cmdRBTBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBTBusy.BackColor = BackColorForSignalOFF
                End If
            Case "01E2", "01E5", "01E8", "01EB", "01EE"
                If nOnOff = 1 Then
                    Me.cmdTRComplete.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRComplete.BackColor = BackColorForSignalOFF
                End If
            Case "01E0", "01E3", "01E6", "01E9", "01EC"
                If nOnOff = 1 Then
                    Me.cmdTRRequest.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRRequest.BackColor = BackColorForSignalOFF
                End If
            Case "01D5"
                If nOnOff = 1 Then
                    Me.cmdTRResetRequest.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRResetRequest.BackColor = BackColorForSignalOFF
                End If
            Case "13D1", "13D3", "13D5", "13D7", "13D9"
                If nOnOff = 1 Then
                    Me.lblSignalCVReady.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCVReady.BackColor = BackColorForSignalOFF
                End If
            Case "1326", "1327", "1328", "1329", "132A"
                If nOnOff = 1 Then
                    Me.lblSignalHandOff.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalHandOff.BackColor = BackColorForSignalOFF
                End If
            Case "13D0", "13D2", "13D4", "13D6", "13D8"
                If nOnOff = 1 Then
                    Me.lblSignalTRReady.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalTRReady.BackColor = BackColorForSignalOFF
                End If
            Case "13C0"
                If nOnOff = 1 Then
                    Me.lblSignalTRResetAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF
                End If

        End Select
    End Sub

    Public Sub SetWordData(ByVal strCVGxID() As String, ByVal nGxJudgment() As Integer, ByVal strProductCode() As String, ByVal strPSHGroup() As String, ByVal nVCRReadPos As Integer)

        MyUpdataTransferRequestCVtoRST.strGxIDPort1 = strCVGxID(1)
        MyUpdataTransferRequestCVtoRST.strGxIDPort2 = strCVGxID(2)
        MyUpdataTransferRequestCVtoRST.strGxIDPort3 = strCVGxID(3)
        MyUpdataTransferRequestCVtoRST.strGxIDPort4 = strCVGxID(4)

        MyUpdataTransferRequestCVtoRST.nGxJudgePort1 = nGxJudgment(1)
        MyUpdataTransferRequestCVtoRST.nGxJudgePort2 = nGxJudgment(2)
        MyUpdataTransferRequestCVtoRST.nGxJudgePort3 = nGxJudgment(3)
        MyUpdataTransferRequestCVtoRST.nGxJudgePort4 = nGxJudgment(4)

        MyUpdataTransferRequestCVtoRST.strProductCodePort1 = strProductCode(1)
        MyUpdataTransferRequestCVtoRST.strProductCodePort2 = strProductCode(2)
        MyUpdataTransferRequestCVtoRST.strProductCodePort3 = strProductCode(3)
        MyUpdataTransferRequestCVtoRST.strProductCodePort4 = strProductCode(4)

        MyUpdataTransferRequestCVtoRST.strPSHGroupPort1 = strPSHGroup(1)
        MyUpdataTransferRequestCVtoRST.strPSHGroupPort2 = strPSHGroup(2)
        MyUpdataTransferRequestCVtoRST.strPSHGroupPort3 = strPSHGroup(3)
        MyUpdataTransferRequestCVtoRST.strPSHGroupPort4 = strPSHGroup(4)

        MyUpdataTransferRequestCVtoRST.nVCRPosition = nVCRReadPos
    End Sub

    Public Property BackColorForRSTSignalON() As System.Drawing.Color
        Get
            BackColorForRSTSignalON = mvarRSTSignalONColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarRSTSignalONColor = value
        End Set
    End Property

    Public Property BackColorForCVSignalON() As System.Drawing.Color
        Get
            BackColorForCVSignalON = mvarCVSignalONColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarCVSignalONColor = value
        End Set
    End Property

    Public Property BackColorForSignalOFF() As System.Drawing.Color
        Get
            BackColorForSignalOFF = mvarSignalOFFColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSignalOFFColor = value
        End Set
    End Property

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim nConvertPortIndex As Integer
        Call ResetSignal()

        nConvertPortIndex = TabControl1.SelectedIndex + 1
        RaiseEvent PortTabChange(nConvertPortIndex)
    End Sub

    Public Sub ResetSignal()
        Me.cmdRBTBusy.BackColor = BackColorForSignalOFF
        Me.cmdTRComplete.BackColor = BackColorForSignalOFF
        Me.cmdTRRequest.BackColor = BackColorForSignalOFF
        Me.cmdTRResetRequest.BackColor = BackColorForSignalOFF
        Me.lblSignalCVReady.BackColor = BackColorForSignalOFF
        Me.lblSignalHandOff.BackColor = BackColorForSignalOFF
        Me.lblSignalTRReady.BackColor = BackColorForSignalOFF
        Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF

        Me.lblWCVGxID.Text = ""
        Me.lblWGxJudgment.Text = ""
        Me.lblWProductCode.Text = ""
        Me.lblWPSHGroup.Text = ""
        Me.lblWVCRReadPos.Text = ""
    End Sub

    Private Sub cmdTRRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRRequest.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01E0")
            Case "1"
                RaiseEvent RSTSignalClick("01E3")
            Case "2"
                RaiseEvent RSTSignalClick("01E6")
            Case "3"
                RaiseEvent RSTSignalClick("01E9")
            Case "4"
                RaiseEvent RSTSignalClick("01EC")
        End Select
    End Sub

    Private Sub cmdRBTBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBTBusy.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01E1")
            Case "1"
                RaiseEvent RSTSignalClick("01E4")
            Case "2"
                RaiseEvent RSTSignalClick("01E7")
            Case "3"
                RaiseEvent RSTSignalClick("01EA")
            Case "4"
                RaiseEvent RSTSignalClick("01ED")
        End Select
    End Sub

    Private Sub cmdTRComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRComplete.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01E2")
            Case "1"
                RaiseEvent RSTSignalClick("01E5")
            Case "2"
                RaiseEvent RSTSignalClick("01E8")
            Case "3"
                RaiseEvent RSTSignalClick("01EB")
            Case "4"
                RaiseEvent RSTSignalClick("01EE")
        End Select
    End Sub

    Private Sub cmdTRResetRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRResetRequest.Click         
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("01D5")
    End Sub

    Public Sub ShowGUITransferRequestCVtoRST()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.lblWCVGxID.Text = MyUpdataTransferRequestCVtoRST.strGxIDPort1
                Me.lblWGxJudgment.Text = MyUpdataTransferRequestCVtoRST.nGxJudgePort1
                Me.lblWProductCode.Text = MyUpdataTransferRequestCVtoRST.strProductCodePort1
                Me.lblWPSHGroup.Text = MyUpdataTransferRequestCVtoRST.strPSHGroupPort1
            Case 2
                Me.lblWCVGxID.Text = MyUpdataTransferRequestCVtoRST.strGxIDPort2
                Me.lblWGxJudgment.Text = MyUpdataTransferRequestCVtoRST.nGxJudgePort2
                Me.lblWProductCode.Text = MyUpdataTransferRequestCVtoRST.strProductCodePort2
                Me.lblWPSHGroup.Text = MyUpdataTransferRequestCVtoRST.strPSHGroupPort2
            Case 3
                Me.lblWCVGxID.Text = MyUpdataTransferRequestCVtoRST.strGxIDPort3
                Me.lblWGxJudgment.Text = MyUpdataTransferRequestCVtoRST.nGxJudgePort3
                Me.lblWProductCode.Text = MyUpdataTransferRequestCVtoRST.strProductCodePort3
                Me.lblWPSHGroup.Text = MyUpdataTransferRequestCVtoRST.strPSHGroupPort3
            Case 4
                Me.lblWCVGxID.Text = MyUpdataTransferRequestCVtoRST.strGxIDPort4
                Me.lblWGxJudgment.Text = MyUpdataTransferRequestCVtoRST.nGxJudgePort4
                Me.lblWProductCode.Text = MyUpdataTransferRequestCVtoRST.strProductCodePort4
                Me.lblWPSHGroup.Text = MyUpdataTransferRequestCVtoRST.strPSHGroupPort4
        End Select

        Me.lblWVCRReadPos.Text = MyUpdataTransferRequestCVtoRST.nVCRPosition
    End Sub
End Class
