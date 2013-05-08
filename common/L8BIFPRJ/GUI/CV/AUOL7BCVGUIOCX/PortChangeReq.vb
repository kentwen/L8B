Imports System.Drawing
Public Class PortChangeReq
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)
    Public Event WordValChange(ByVal strPortMode As String, ByVal strPortType As String, ByVal strProductCode As String)

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
            Case "01DB", "01DC", "01DD", "01DE", "01DF"
                If nOnOff = 1 Then
                    Me.cmdPortChangeReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdPortChangeReq.BackColor = BackColorForSignalOFF
                End If
            Case "13A0", "13A1", "13A2", "13A3", "13A4"
                If nOnOff = 1 Then
                    Me.lblSignalPortChangeReqAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalPortChangeReqAck.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nPortMode As Integer, ByVal nPortType As Integer, ByVal strProductCode As String, ByVal nChangeResult As Integer)
        MyUpdataCVPortChangeRequest.nPortMode = nPortMode
        MyUpdataCVPortChangeRequest.nPortType = nPortType
        MyUpdataCVPortChangeRequest.strProductCode = strProductCode

        MyUpdataCVPortChangeRequest.nChangeResult = nChangeResult
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
        Me.lblSignalPortChangeReqAck.BackColor = BackColorForSignalOFF
        Me.cmdPortChangeReq.BackColor = BackColorForSignalOFF
        Me.txtPortMode.Text = ""
        Me.txtPortType.Text = ""
        Me.txtProductCode.Text = ""
        Me.lblWChangeResult.Text = ""

    End Sub

    Private Sub cmdWriteWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWriteWord.Click
        Dim strPortMode As String
        Dim strPortType As String
        Dim strProductCode As String
        Dim strSlotNumber As String
        If Not ENGType Then Exit Sub

        strPortMode = Me.txtPortMode.Text
        strPortType = Me.txtPortType.Text
        strProductCode = Me.txtProductCode.Text
        strSlotNumber = Me.lblWChangeResult.Text
        RaiseEvent WordValChange(strPortMode, strPortType, strProductCode)
    End Sub

    Private Sub cmdPortChangeReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortChangeReq.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01DB")
            Case "1"
                RaiseEvent RSTSignalClick("01DC")
            Case "2"
                RaiseEvent RSTSignalClick("01DD")
            Case "3"
                RaiseEvent RSTSignalClick("01DE")
            Case "4"
                RaiseEvent RSTSignalClick("01DF")
        End Select
    End Sub

    Public Sub ShowGUIPortChangeRequest()
        Me.txtPortMode.Text = MyUpdataCVPortChangeRequest.nPortMode
        Me.txtPortType.Text = MyUpdataCVPortChangeRequest.nPortType
        Me.txtProductCode.Text = MyUpdataCVPortChangeRequest.strProductCode
        Me.lblWChangeResult.Text = MyUpdataCVPortChangeRequest.nChangeResult
    End Sub
End Class
