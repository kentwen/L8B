Imports System.Drawing
Public Class GxFlowOut
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)
    Public Event WordValChange(ByVal strGxID As String, ByVal strGxJudgment As String, ByVal strPSHGroup As String, ByVal strVCRPos As String, ByVal strProductCode As String)

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
            Case "01C0", "01C1", "01C2", "01C3", "01C4"
                If nOnOff = 1 Then
                    Me.cmdGxFlowOutAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdGxFlowOutAck.BackColor = BackColorForSignalOFF
                End If
            Case "1380", "1381", "1382", "1383", "1384"
                If nOnOff = 1 Then
                    Me.lblSignalGxFlowOut.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxFlowOut.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nPortNo As Integer, ByVal strGxID As String, ByVal nGxJudgment As Integer, ByVal strPSHGroup As String, ByVal nVCRPos As Integer, ByVal strProductCode As String, ByVal nSlotNumber() As Integer)
        Select Case nPortNo
            Case 1
                MyUpdataCVGxFlowOut.strGxIDPort1 = strGxID
                MyUpdataCVGxFlowOut.nGxJudgementPort1 = nGxJudgment
                MyUpdataCVGxFlowOut.strPSHGroupPort1 = strPSHGroup
                MyUpdataCVGxFlowOut.nVCRPositionPort1 = nVCRPos
                MyUpdataCVGxFlowOut.strProductCodePort1 = strProductCode

                MyUpdataCVGxFlowOut.nSlotNumberPort1 = nSlotNumber(1)
            Case 2
                MyUpdataCVGxFlowOut.strGxIDPort2 = strGxID
                MyUpdataCVGxFlowOut.nGxJudgementPort2 = nGxJudgment
                MyUpdataCVGxFlowOut.strPSHGroupPort2 = strPSHGroup
                MyUpdataCVGxFlowOut.nVCRPositionPort2 = nVCRPos
                MyUpdataCVGxFlowOut.strProductCodePort2 = strProductCode

                MyUpdataCVGxFlowOut.nSlotNumberPort2 = nSlotNumber(2)
            Case 3
                MyUpdataCVGxFlowOut.strGxIDPort3 = strGxID
                MyUpdataCVGxFlowOut.nGxJudgementPort3 = nGxJudgment
                MyUpdataCVGxFlowOut.strPSHGroupPort3 = strPSHGroup
                MyUpdataCVGxFlowOut.nVCRPositionPort3 = nVCRPos
                MyUpdataCVGxFlowOut.strProductCodePort3 = strProductCode

                MyUpdataCVGxFlowOut.nSlotNumberPort3 = nSlotNumber(3)
        End Select

        MyUpdataCVGxFlowOut.nSlotNumberPort4 = nSlotNumber(4)
        MyUpdataCVGxFlowOut.nSlotNumberPort5 = nSlotNumber(5)
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
        nConvertPortIndex = TabControl1.SelectedIndex + 1
        RaiseEvent PortTabChange(nConvertPortIndex)
    End Sub

    Public Sub ResetSignal()
        Me.lblSignalGxFlowOut.BackColor = BackColorForSignalOFF
        Me.cmdGxFlowOutAck.BackColor = BackColorForSignalOFF
        Me.txtGxID.Text = ""
        Me.txtGxJudgment.Text = ""
        Me.txtProductCode.Text = ""
        Me.txtPSHGroup.Text = ""
        Me.txtVCRPos.Text = ""
        Me.lblWSlotNumber.Text = ""
    End Sub

    Private Sub cmdWriteWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWriteWord.Click
        If Not ENGType Then Exit Sub

        Dim strGxID As String
        Dim strGxJudgment As String
        Dim strProductCode As String
        Dim strPSHGroup As String
        Dim strVCRPos As String


        strGxID = Me.txtGxID.Text
        strGxJudgment = Me.txtGxJudgment.Text
        strProductCode = Me.txtProductCode.Text
        strPSHGroup = Me.txtPSHGroup.Text
        strVCRPos = Me.txtVCRPos.Text


        RaiseEvent WordValChange(strGxID, strGxJudgment, strPSHGroup, strVCRPos, strProductCode)
    End Sub

    Private Sub cmdGxFlowOutAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGxFlowOutAck.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01C0")
            Case "1"
                RaiseEvent RSTSignalClick("01C1")
            Case "2"
                RaiseEvent RSTSignalClick("01C2")
            Case "3"
                RaiseEvent RSTSignalClick("01C3")
            Case "4"
                RaiseEvent RSTSignalClick("01C4")
        End Select
    End Sub

    Public Sub ShowGUICVGxFlowOut()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1
        Select Case nConvertPortIndex
            Case 1
                Me.txtGxID.Text = MyUpdataCVGxFlowOut.strGxIDPort1
                Me.txtGxJudgment.Text = MyUpdataCVGxFlowOut.nGxJudgementPort1
                Me.txtProductCode.Text = MyUpdataCVGxFlowOut.strProductCodePort1
                Me.txtPSHGroup.Text = MyUpdataCVGxFlowOut.strPSHGroupPort1
                Me.txtVCRPos.Text = MyUpdataCVGxFlowOut.nVCRPositionPort1

                Me.lblWSlotNumber.Text = MyUpdataCVGxFlowOut.nSlotNumberPort1
            Case 2
                Me.txtGxID.Text = MyUpdataCVGxFlowOut.strGxIDPort2
                Me.txtGxJudgment.Text = MyUpdataCVGxFlowOut.nGxJudgementPort2
                Me.txtProductCode.Text = MyUpdataCVGxFlowOut.strProductCodePort2
                Me.txtPSHGroup.Text = MyUpdataCVGxFlowOut.strPSHGroupPort2
                Me.txtVCRPos.Text = MyUpdataCVGxFlowOut.nVCRPositionPort2

                Me.lblWSlotNumber.Text = MyUpdataCVGxFlowOut.nSlotNumberPort2
            Case 3
                Me.txtGxID.Text = MyUpdataCVGxFlowOut.strGxIDPort3
                Me.txtGxJudgment.Text = MyUpdataCVGxFlowOut.nGxJudgementPort3
                Me.txtProductCode.Text = MyUpdataCVGxFlowOut.strProductCodePort3
                Me.txtPSHGroup.Text = MyUpdataCVGxFlowOut.strPSHGroupPort3
                Me.txtVCRPos.Text = MyUpdataCVGxFlowOut.nVCRPositionPort3

                Me.lblWSlotNumber.Text = MyUpdataCVGxFlowOut.nSlotNumberPort3
            Case 4
                Me.txtGxID.Text = ""
                Me.txtGxJudgment.Text = "0"
                Me.txtProductCode.Text = ""
                Me.txtPSHGroup.Text = ""
                Me.txtVCRPos.Text = "0"

                Me.lblWSlotNumber.Text = MyUpdataCVGxFlowOut.nSlotNumberPort4
            Case 5
                Me.txtGxID.Text = ""
                Me.txtGxJudgment.Text = "0"
                Me.txtProductCode.Text = ""
                Me.txtPSHGroup.Text = ""
                Me.txtVCRPos.Text = "0"

                Me.lblWSlotNumber.Text = MyUpdataCVGxFlowOut.nSlotNumberPort5
        End Select

    End Sub
End Class
