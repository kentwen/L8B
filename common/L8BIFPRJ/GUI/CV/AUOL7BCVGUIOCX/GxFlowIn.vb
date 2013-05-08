Imports System.Drawing
Public Class GxFlowIn
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
            Case "01C8", "01C9", "01CA", "01CB", "01CC"
                If nOnOff = 1 Then
                    Me.cmdGxFlowInAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdGxFlowInAck.BackColor = BackColorForSignalOFF
                End If
            Case "1390", "1391", "1392", "1393", "1394"
                If nOnOff = 1 Then
                    Me.lblSignalGxFlowIn.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxFlowIn.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal strGxID As String, ByVal strProdCode As String, ByVal nSlotNumber As Integer)
        'Me.lblWCVGxID.Text = strGxID
        'Me.lblWProductCode.Text = strProdCode
        'Me.lblWSlotNumber.Text = strSlotNumber

        MyUpdataCVGxFlowIn.strGxID = strGxID
        MyUpdataCVGxFlowIn.strProductCode = strProdCode
        MyUpdataCVGxFlowIn.nSlotNumber = nSlotNumber
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

    Private Sub ResetSignal()
        Me.lblSignalGxFlowIn.BackColor = BackColorForSignalOFF
        Me.cmdGxFlowInAck.BackColor = BackColorForSignalOFF
        Me.lblWCVGxID.Text = ""
        Me.lblWProductCode.Text = ""
        Me.lblWSlotNumber.Text = ""
    End Sub

    Private Sub cmdGxFlowInAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGxFlowInAck.Click
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex
        If Not ENGType Then Exit Sub

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("01C8")
            Case "1"
                RaiseEvent RSTSignalClick("01C9")
            Case "2"
                RaiseEvent RSTSignalClick("01CA")
            Case "3"
                RaiseEvent RSTSignalClick("01CB")
            Case "4"
                RaiseEvent RSTSignalClick("01CC")
        End Select
    End Sub

    Public Sub ShowGUICVGxFlowIn()
        Me.lblWCVGxID.Text = MyUpdataCVGxFlowIn.strGxID
        Me.lblWProductCode.Text = MyUpdataCVGxFlowIn.strProductCode
        Me.lblWSlotNumber.Text = MyUpdataCVGxFlowIn.nSlotNumber
    End Sub
End Class
