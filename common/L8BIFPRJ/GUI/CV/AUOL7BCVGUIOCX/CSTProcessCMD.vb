Imports System.Drawing
Public Class CSTProcessCMD
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)
    Public Event WordValChange(ByVal strCSTID As String, ByVal strCSTInfo As String, ByVal strPortNumber As String, ByVal strProcessCMD As String, ByVal strProcessQty As String)

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
            Case "019F"
                If nOnOff = 1 Then
                    Me.cmdCSTProcessReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdCSTProcessReq.BackColor = BackColorForSignalOFF
                End If
            Case "1360"
                If nOnOff = 1 Then
                    Me.lblSignalCSTProcessReqAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCSTProcessReqAck.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    'Public Sub SetWordData(ByVal strCSTID As String, ByVal strCSTInfo As String, ByVal strPortNumber As String, ByVal strProcessCMD As String, ByVal strProcessQty As String)
    '    Me.txtCSTID.Text = strCSTID
    '    Me.txtCSTSlotInfo.Text = strCSTInfo
    '    Me.txtPortNumber.Text = strPortNumber
    '    Me.txtProcessCMD.Text = strProcessCMD
    '    Me.txtProcessGxQTY.Text = strProcessQty

    '    g_strProssCMD_CSTID = strCSTID
    '    g_strProssCMD_SlotInfo = strCSTInfo
    '    g_strProssCMD_PortNumber = strPortNumber
    '    g_strProssCMD_ProcessCMD = strProcessCMD
    '    g_strProssCMD_GxQTY = strProcessQty

    'End Sub

    Public Sub SetWordData(ByVal nPortNo As Integer, ByVal strCSTID As String, ByVal strCSTInfo As String, ByVal strPortNumber As String, ByVal strProcessCMD As String, ByVal strProcessQty As String)
        Me.txtCSTID.Text = strCSTID
        Me.txtCSTSlotInfo.Text = strCSTInfo
        Me.txtPortNumber.Text = strPortNumber
        Me.txtProcessCMD.Text = strProcessCMD
        Me.txtProcessGxQTY.Text = strProcessQty

        m_strProssCMD_CSTID(nPortNo) = strCSTID
        m_strProssCMD_SlotInfo(nPortNo) = strCSTInfo
        m_strProssCMD_PortNumber(nPortNo) = strPortNumber
        m_strProssCMD_ProcessCMD(nPortNo) = strProcessCMD
        m_strProssCMD_GxQTY(nPortNo) = strProcessQty
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
        Me.cmdCSTProcessReq.BackColor = BackColorForSignalOFF
        Me.lblSignalCSTProcessReqAck.BackColor = BackColorForSignalOFF
        Me.txtCSTID.Text = ""
        Me.txtCSTSlotInfo.Text = ""
        Me.txtProcessCMD.Text = ""
        Me.txtProcessGxQTY.Text = ""
        Me.txtPortNumber.Text = ""
    End Sub

    Private Sub cmdCSTProcessReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSTProcessReq.Click
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("019F")
    End Sub

    Private Sub cmdWriteWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWriteWord.Click
        Dim strCSTID As String
        Dim strCSTInfo As String
        Dim strPortNumber As String
        Dim strProcessCMD As String
        Dim strProcessQty As String

        strCSTID = txtCSTID.Text
        strCSTInfo = Me.txtCSTSlotInfo.Text
        strPortNumber = Me.txtPortNumber.Text
        strProcessCMD = Me.txtProcessCMD.Text
        strProcessQty = Me.txtProcessGxQTY.Text

        RaiseEvent WordValChange(strCSTID, strCSTID, strPortNumber, strProcessCMD, strProcessQty)
    End Sub

    'Public Sub ShowGUIProcessCmd()
    '    Me.txtCSTID.Text = g_strProssCMD_CSTID
    '    Me.txtCSTSlotInfo.Text = g_strProssCMD_SlotInfo
    '    Me.txtPortNumber.Text = g_strProssCMD_PortNumber
    '    Me.txtProcessCMD.Text = g_strProssCMD_ProcessCMD
    '    Me.txtProcessGxQTY.Text = g_strProssCMD_GxQTY
    'End Sub

    Public Sub ShowGUIProcessCmd()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.txtCSTID.Text = m_strProssCMD_CSTID(1)
                Me.txtCSTSlotInfo.Text = m_strProssCMD_SlotInfo(1)
                Me.txtPortNumber.Text = m_strProssCMD_PortNumber(1)
                Me.txtProcessCMD.Text = m_strProssCMD_ProcessCMD(1)
                Me.txtProcessGxQTY.Text = m_strProssCMD_GxQTY(1)
            Case 2
                Me.txtCSTID.Text = m_strProssCMD_CSTID(2)
                Me.txtCSTSlotInfo.Text = m_strProssCMD_SlotInfo(2)
                Me.txtPortNumber.Text = m_strProssCMD_PortNumber(2)
                Me.txtProcessCMD.Text = m_strProssCMD_ProcessCMD(2)
                Me.txtProcessGxQTY.Text = m_strProssCMD_GxQTY(2)
            Case 3
                Me.txtCSTID.Text = m_strProssCMD_CSTID(3)
                Me.txtCSTSlotInfo.Text = m_strProssCMD_SlotInfo(3)
                Me.txtPortNumber.Text = m_strProssCMD_PortNumber(3)
                Me.txtProcessCMD.Text = m_strProssCMD_ProcessCMD(3)
                Me.txtProcessGxQTY.Text = m_strProssCMD_GxQTY(3)
            Case Else
                Me.txtCSTID.Text = ""
                Me.txtCSTSlotInfo.Text = ""
                Me.txtPortNumber.Text = ""
                Me.txtProcessCMD.Text = ""
                Me.txtProcessGxQTY.Text = ""
        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex + 1
        RaiseEvent PortTabChange(nConvertPortIndex)
    End Sub
End Class
