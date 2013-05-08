Imports System.Drawing
Public Class CSTUnloadByRST

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
            Case "01A0", "01A1", "01A2", "01A3", "01A4"
                If nOnOff = 1 Then
                    Me.cmdCSTUnloadReqAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdCSTUnloadReqAck.BackColor = BackColorForSignalOFF
                End If
            Case "01AB", "01AC", "01AD", "01AE", "01AF"
                If nOnOff = 1 Then
                    Me.cmdCSTUnloadPriority.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdCSTUnloadPriority.BackColor = BackColorForSignalOFF
                End If
            Case "01B0", "01B1", "01B2", "01B3", "01B4"
                If nOnOff = 1 Then
                    Me.cmdRSTRequestUnloadCST.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRSTRequestUnloadCST.BackColor = BackColorForSignalOFF
                End If

            Case "1370", "1371", "1372", "1373", "1374"
                If nOnOff = 1 Then
                    Me.lblSignalUnloadReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalUnloadReq.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nTotalGx() As Integer, ByVal nUnloadStat() As Integer)

        MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort1 = nTotalGx(1)
        MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort2 = nTotalGx(2)
        MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort3 = nTotalGx(3)
        MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort4 = nTotalGx(4)
        MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort5 = nTotalGx(5)

        MyUpdataCVUnloadRequestByCV.nUnloadStatusPort1 = nUnloadStat(1)
        MyUpdataCVUnloadRequestByCV.nUnloadStatusPort2 = nUnloadStat(2)
        MyUpdataCVUnloadRequestByCV.nUnloadStatusPort3 = nUnloadStat(3)
        MyUpdataCVUnloadRequestByCV.nUnloadStatusPort4 = nUnloadStat(4)
        MyUpdataCVUnloadRequestByCV.nUnloadStatusPort5 = nUnloadStat(5)
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

    Private Sub ResetSignal()
        Me.lblWTotalGx.Text = ""
        Me.lblWUnloadStat.Text = ""
        Me.cmdRSTRequestUnloadCST.BackColor = BackColorForSignalOFF
        Me.cmdCSTUnloadReqAck.BackColor = BackColorForSignalOFF
        Me.cmdCSTUnloadPriority.BackColor = BackColorForSignalOFF
        Me.lblSignalUnloadReq.BackColor = BackColorForSignalOFF
    End Sub

    Private Sub cmdCSTUnloadPriority_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSTUnloadPriority.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01AB")
            Case "1"
                RaiseEvent RSTSignalClick("01AC")
            Case "2"
                RaiseEvent RSTSignalClick("01AD")
            Case "3"
                RaiseEvent RSTSignalClick("01AE")
            Case "4"
                RaiseEvent RSTSignalClick("01AF")
        End Select
    End Sub

    Private Sub cmdCSTUnloadReqAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSTUnloadReqAck.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01A0")
            Case "1"
                RaiseEvent RSTSignalClick("01A1")
            Case "2"
                RaiseEvent RSTSignalClick("01A2")
            Case "3"
                RaiseEvent RSTSignalClick("01A3")
            Case "4"
                RaiseEvent RSTSignalClick("01A4")
        End Select
    End Sub

    Private Sub cmdRSTRequestUnloadCST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRSTRequestUnloadCST.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01B0")
            Case "1"
                RaiseEvent RSTSignalClick("01B1")
            Case "2"
                RaiseEvent RSTSignalClick("01B2")
            Case "3"
                RaiseEvent RSTSignalClick("01B3")
            Case "4"
                RaiseEvent RSTSignalClick("01B4")
        End Select
    End Sub

    Public Sub ShowGUIUnloadRequestByRST()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.lblWTotalGx.Text = MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort1
                Me.lblWUnloadStat.Text = MyUpdataCVUnloadRequestByCV.nUnloadStatusPort1
            Case 2
                Me.lblWTotalGx.Text = MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort2
                Me.lblWUnloadStat.Text = MyUpdataCVUnloadRequestByCV.nUnloadStatusPort2
            Case 3
                Me.lblWTotalGx.Text = MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort3
                Me.lblWUnloadStat.Text = MyUpdataCVUnloadRequestByCV.nUnloadStatusPort3
            Case 4
                Me.lblWTotalGx.Text = MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort4
                Me.lblWUnloadStat.Text = MyUpdataCVUnloadRequestByCV.nUnloadStatusPort4
            Case 5
                Me.lblWTotalGx.Text = MyUpdataCVUnloadRequestByCV.nTotalGxQtyPort5
                Me.lblWUnloadStat.Text = MyUpdataCVUnloadRequestByCV.nUnloadStatusPort5
        End Select
    End Sub
End Class
