Public Class GxDataReq

    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)
    Public Event WordValChange(ByVal strGxJudgement As String, ByVal strProdCode As String, ByVal strPSHGroup As String, ByVal strVCRPos As String)

    Private mvarRSTSignalONColor As System.Drawing.Color
    Private mvarCVSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarENGType As Boolean

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
            Case "01D1"
                If nOnOff = 1 Then
                    Me.cmdDataEmptyFlag.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdDataEmptyFlag.BackColor = BackColorForSignalOFF
                End If
            Case "01D0"
                If nOnOff = 1 Then
                    Me.cmdGxDataReqAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdGxDataReqAck.BackColor = BackColorForSignalOFF
                End If
            Case "13B0"
                If nOnOff = 1 Then
                    Me.lblSignalGxDataReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxDataReq.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal strGxID As String, ByVal nGxJudgement As Integer, ByVal strProdCode As String, ByVal strPSHGrade As String, ByVal nVCRPos As Integer)

        'Me.lblWGxID.Text = strGxID
        'Me.txtGxJudgment.Text = nGxJudgement
        'Me.txtProductCode.Text = strProdCode
        'Me.txtPSHGroup.Text = strPSHGroup
        'Me.txtVCRReadPos.Text = nVCRPos

        MyUpdataCVGlassDataRequest.strGxID = strGxID
        MyUpdataCVGlassDataRequest.nGxJudgement = nGxJudgement
        MyUpdataCVGlassDataRequest.strProdCode = strProdCode
        MyUpdataCVGlassDataRequest.strPSHGrade = strPSHGrade
        MyUpdataCVGlassDataRequest.nVCRPos = nVCRPos
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

    Public Sub ResetSignal()
        Me.cmdGxDataReqAck.BackColor = BackColorForSignalOFF
        Me.cmdDataEmptyFlag.BackColor = BackColorForSignalOFF
        Me.lblSignalGxDataReq.BackColor = BackColorForSignalOFF

        Me.lblWGxID.Text = ""
        Me.txtGxJudgment.Text = ""
        Me.txtProductCode.Text = ""
        Me.txtPSHGroup.Text = ""
        Me.txtVCRReadPos.Text = ""
    End Sub

    Private Sub cmdWriteWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWriteWord.Click
        If Not ENGType Then Exit Sub
        Dim strGxJudgement As String
        Dim strProdCode As String
        Dim strPSHGroup As String
        Dim strVCRPos As String

        strGxJudgement = Me.txtGxJudgment.Text
        strProdCode = Me.txtProductCode.Text
        strPSHGroup = Me.txtPSHGroup.Text
        strVCRPos = Me.txtVCRReadPos.Text

        RaiseEvent WordValChange(strGxJudgement, strProdCode, strPSHGroup, strVCRPos)
    End Sub

    Private Sub cmdGxDataReqAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGxDataReqAck.Click        
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("01D0")
    End Sub

    Private Sub cmdDataEmptyFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDataEmptyFlag.Click
        If Not ENGType Then Exit Sub         
        RaiseEvent RSTSignalClick("01D1")             
    End Sub

    Public Sub ShowGUIGlassDataRequest()
        Me.lblWGxID.Text = MyUpdataCVGlassDataRequest.strGxID
        Me.txtGxJudgment.Text = MyUpdataCVGlassDataRequest.nGxJudgement
        Me.txtProductCode.Text = MyUpdataCVGlassDataRequest.strProdCode
        Me.txtPSHGroup.Text = MyUpdataCVGlassDataRequest.strPSHGrade
        Me.txtVCRReadPos.Text = MyUpdataCVGlassDataRequest.nVCRPos
    End Sub
End Class
