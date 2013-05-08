Imports System.Drawing
Public Class CSTLoadComplete
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
            Case "0197", "0198", "0199", "019A", "019B"
                If nOnOff = 1 Then
                    Me.cmdCSTLoadCompAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdCSTLoadCompAck.BackColor = BackColorForSignalOFF
                End If
            Case "1350", "1351", "1352", "1353", "1354"
                If nOnOff = 1 Then
                    Me.llbSignalCSTLoadComp.BackColor = BackColorForCVSignalON
                Else
                    Me.llbSignalCSTLoadComp.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nMiniSlot() As Integer, ByVal strCSTID() As String)
        'Me.lblWMiniSlot.Text = strMiniSlot
        'Me.lblWCSTID.Text = strCSTID
        MyUpdataCVCSTLoadComplete.nPort1MiniSlot = nMiniSlot(1)
        MyUpdataCVCSTLoadComplete.nPort2MiniSlot = nMiniSlot(2)
        MyUpdataCVCSTLoadComplete.nPort3MiniSlot = nMiniSlot(3)
        MyUpdataCVCSTLoadComplete.nPort4MiniSlot = nMiniSlot(4)
        MyUpdataCVCSTLoadComplete.nPort5MiniSlot = nMiniSlot(5)

        MyUpdataCVCSTLoadComplete.strPort1CSTID = strCSTID(1)
        MyUpdataCVCSTLoadComplete.strPort2CSTID = strCSTID(2)
        MyUpdataCVCSTLoadComplete.strPort3CSTID = strCSTID(3)
        MyUpdataCVCSTLoadComplete.strPort4CSTID = strCSTID(4)
        MyUpdataCVCSTLoadComplete.strPort5CSTID = strCSTID(5)
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
        Me.llbSignalCSTLoadComp.BackColor = BackColorForSignalOFF
        Me.cmdCSTLoadCompAck.BackColor = BackColorForSignalOFF
        Me.lblWCSTID.Text = ""
        Me.lblWMiniSlot.Text = ""
    End Sub

    Private Sub cmdCSTLoadCompAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSTLoadCompAck.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("0197")
            Case "1"
                RaiseEvent RSTSignalClick("0198")
            Case "2"
                RaiseEvent RSTSignalClick("0199")
            Case "3"
                RaiseEvent RSTSignalClick("019A")
            Case "4"
                RaiseEvent RSTSignalClick("019B")
        End Select
    End Sub

    Public Sub ShowGUICSTLoadComplete()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.lblWMiniSlot.Text = MyUpdataCVCSTLoadComplete.nPort1MiniSlot
                Me.lblWCSTID.Text = MyUpdataCVCSTLoadComplete.strPort1CSTID
            Case 2
                Me.lblWMiniSlot.Text = MyUpdataCVCSTLoadComplete.nPort2MiniSlot
                Me.lblWCSTID.Text = MyUpdataCVCSTLoadComplete.strPort2CSTID
            Case 3
                Me.lblWMiniSlot.Text = MyUpdataCVCSTLoadComplete.nPort3MiniSlot
                Me.lblWCSTID.Text = MyUpdataCVCSTLoadComplete.strPort3CSTID
            Case 4
                Me.lblWMiniSlot.Text = MyUpdataCVCSTLoadComplete.nPort4MiniSlot
                Me.lblWCSTID.Text = MyUpdataCVCSTLoadComplete.strPort4CSTID
            Case 5
                Me.lblWMiniSlot.Text = MyUpdataCVCSTLoadComplete.nPort5MiniSlot
                Me.lblWCSTID.Text = MyUpdataCVCSTLoadComplete.strPort5CSTID
        End Select

    End Sub
End Class
