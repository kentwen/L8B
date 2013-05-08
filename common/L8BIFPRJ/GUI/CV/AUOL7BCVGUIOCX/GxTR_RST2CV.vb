Imports System.Drawing
Public Class GxTR_RST2CV
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)
    Public Event WordValChange(ByVal strCVGxID As String, ByVal strGxJudgment As String, ByVal strProductCode As String, ByVal strPSHGroup As String, ByVal strVCRReadPos As String)

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
            Me.cmdWriteWord.Visible = value
        End Set
    End Property

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "01F1", "01F4", "01F7", "01FA", "01FD"
                If nOnOff = 1 Then
                    Me.cmdRBTBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBTBusy.BackColor = BackColorForSignalOFF
                End If
            Case "01F2", "01F5", "01F8", "01FB", "01FE"
                If nOnOff = 1 Then
                    Me.cmdTRComplete.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRComplete.BackColor = BackColorForSignalOFF
                End If
            Case "01F0", "01F3", "01F6", "01F9", "01FC"
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
                'Case "13E0", "13E2", "13E4", "13E6", "13E8"
                '    If nOnOff = 1 Then
                '        Me.lblSignalUnloadReq.BackColor = BackColorForCVSignalON
                '    Else
                '        Me.lblSignalUnloadReq.BackColor = BackColorForSignalOFF
                '    End If
            Case "13E0", "13E1", "13E2", "13E3", "13E4"
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
            Case "13C0"
                If nOnOff = 1 Then
                    Me.lblSignalTRResetAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF
                End If

        End Select
    End Sub

    Public Sub SetWordData(ByVal strCVGxID() As String, ByVal nGxJudgment() As Integer, ByVal strProductCode() As String, ByVal strPSHGroup() As String, ByVal nVCRReadPos() As Integer)
        'Me.txtCVGxID.Text = strCVGxID
        'Me.txtGxJudgment.Text = strGxJudgment
        'Me.txtProductCode.Text = strProductCode
        'Me.txtPSHGroup.Text = strPSHGroup
        'Me.txtVCRReadPos.Text = strVCRReadPos

        MyUpdataTransferRequestRSTtoCV.strGxIDPort1 = strCVGxID(1)
        MyUpdataTransferRequestRSTtoCV.strGxIDPort2 = strCVGxID(2)
        MyUpdataTransferRequestRSTtoCV.strGxIDPort3 = strCVGxID(3)
        MyUpdataTransferRequestRSTtoCV.strGxIDPort4 = strCVGxID(4)

        MyUpdataTransferRequestRSTtoCV.nGxJudgePort1 = nGxJudgment(1)
        MyUpdataTransferRequestRSTtoCV.nGxJudgePort2 = nGxJudgment(2)
        MyUpdataTransferRequestRSTtoCV.nGxJudgePort3 = nGxJudgment(3)
        MyUpdataTransferRequestRSTtoCV.nGxJudgePort4 = nGxJudgment(4)

        MyUpdataTransferRequestRSTtoCV.strProductCodePort1 = strProductCode(1)
        MyUpdataTransferRequestRSTtoCV.strProductCodePort2 = strProductCode(2)
        MyUpdataTransferRequestRSTtoCV.strProductCodePort3 = strProductCode(3)
        MyUpdataTransferRequestRSTtoCV.strProductCodePort4 = strProductCode(4)

        MyUpdataTransferRequestRSTtoCV.strPSHGroupPort1 = strPSHGroup(1)
        MyUpdataTransferRequestRSTtoCV.strPSHGroupPort2 = strPSHGroup(2)
        MyUpdataTransferRequestRSTtoCV.strPSHGroupPort3 = strPSHGroup(3)
        MyUpdataTransferRequestRSTtoCV.strPSHGroupPort4 = strPSHGroup(4)

        MyUpdataTransferRequestRSTtoCV.nVCRPositionPort1 = nVCRReadPos(1)
        MyUpdataTransferRequestRSTtoCV.nVCRPositionPort2 = nVCRReadPos(2)
        MyUpdataTransferRequestRSTtoCV.nVCRPositionPort3 = nVCRReadPos(3)
        MyUpdataTransferRequestRSTtoCV.nVCRPositionPort4 = nVCRReadPos(4)

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

        Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF

        Me.txtCVGxID.Text = ""
        Me.txtGxJudgment.Text = ""
        Me.txtProductCode.Text = ""
        Me.txtPSHGroup.Text = ""
        Me.txtVCRReadPos.Text = ""
    End Sub

    Private Sub cmdWriteWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWriteWord.Click
        If Not ENGType Then Exit Sub
        Dim strCVGxID As String
        Dim strGxJudgment As String
        Dim strProductCode As String
        Dim strPSHGroup As String
        Dim strVCRReadPos As String


        strCVGxID = Me.txtCVGxID.Text
        strGxJudgment = Me.txtGxJudgment.Text
        strProductCode = Me.txtProductCode.Text
        strPSHGroup = Me.txtPSHGroup.Text
        strVCRReadPos = Me.txtVCRReadPos.Text
        RaiseEvent WordValChange(strCVGxID, strGxJudgment, strProductCode, strPSHGroup, strVCRReadPos)
    End Sub

    Private Sub cmdTRResetRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRResetRequest.Click         
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("01D5")
    End Sub

    Private Sub cmdTRRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRRequest.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01F0")
            Case "1"
                RaiseEvent RSTSignalClick("01F3")
            Case "2"
                RaiseEvent RSTSignalClick("01F6")
            Case "3"
                RaiseEvent RSTSignalClick("01F9")
            Case "4"
                RaiseEvent RSTSignalClick("01FC")
        End Select
    End Sub

    Private Sub cmdRBTBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBTBusy.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01F1")
            Case "1"
                RaiseEvent RSTSignalClick("01F4")
            Case "2"
                RaiseEvent RSTSignalClick("01F7")
            Case "3"
                RaiseEvent RSTSignalClick("01FA")
            Case "4"
                RaiseEvent RSTSignalClick("01FD")
        End Select
    End Sub

    Private Sub cmdTRComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRComplete.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01F2")
            Case "1"
                RaiseEvent RSTSignalClick("01F5")
            Case "2"
                RaiseEvent RSTSignalClick("01F8")
            Case "3"
                RaiseEvent RSTSignalClick("01FB")
            Case "4"
                RaiseEvent RSTSignalClick("01FE")
        End Select
    End Sub

    Public Sub ShowGUITransferRequestRSTtoCV()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.txtCVGxID.Text = MyUpdataTransferRequestRSTtoCV.strGxIDPort1
                Me.txtGxJudgment.Text = MyUpdataTransferRequestRSTtoCV.nGxJudgePort1
                Me.txtProductCode.Text = MyUpdataTransferRequestRSTtoCV.strProductCodePort1
                Me.txtPSHGroup.Text = MyUpdataTransferRequestRSTtoCV.strPSHGroupPort1
                Me.txtVCRReadPos.Text = MyUpdataTransferRequestRSTtoCV.nVCRPositionPort1
            Case 2
                Me.txtCVGxID.Text = MyUpdataTransferRequestRSTtoCV.strGxIDPort2
                Me.txtGxJudgment.Text = MyUpdataTransferRequestRSTtoCV.nGxJudgePort2
                Me.txtProductCode.Text = MyUpdataTransferRequestRSTtoCV.strProductCodePort2
                Me.txtPSHGroup.Text = MyUpdataTransferRequestRSTtoCV.strPSHGroupPort2
                Me.txtVCRReadPos.Text = MyUpdataTransferRequestRSTtoCV.nVCRPositionPort2
            Case 3
                Me.txtCVGxID.Text = MyUpdataTransferRequestRSTtoCV.strGxIDPort3
                Me.txtGxJudgment.Text = MyUpdataTransferRequestRSTtoCV.nGxJudgePort3
                Me.txtProductCode.Text = MyUpdataTransferRequestRSTtoCV.strProductCodePort3
                Me.txtPSHGroup.Text = MyUpdataTransferRequestRSTtoCV.strPSHGroupPort3
                Me.txtVCRReadPos.Text = MyUpdataTransferRequestRSTtoCV.nVCRPositionPort3
            Case 4
                Me.txtCVGxID.Text = MyUpdataTransferRequestRSTtoCV.strGxIDPort4
                Me.txtGxJudgment.Text = MyUpdataTransferRequestRSTtoCV.nGxJudgePort4
                Me.txtProductCode.Text = MyUpdataTransferRequestRSTtoCV.strProductCodePort4
                Me.txtPSHGroup.Text = MyUpdataTransferRequestRSTtoCV.strPSHGroupPort4
                Me.txtVCRReadPos.Text = MyUpdataTransferRequestRSTtoCV.nVCRPositionPort4
        End Select
    End Sub
End Class
