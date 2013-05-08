Imports System.Drawing
Public Class OcxLinkState
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
            Case "0", "80", "100"
                If nOnOff = 1 Then
                    Me.cmdLinkReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLinkReq.BackColor = BackColorForSignalOFF
                End If
            Case "1", "81", "101"
                If nOnOff = 1 Then
                    Me.cmdLinkTest.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLinkTest.BackColor = BackColorForSignalOFF
                End If
            Case "300", "700", "1000"
                If nOnOff = 1 Then
                    Me.lblSignalLinkReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalLinkReq.BackColor = BackColorForSignalOFF
                End If
            Case "301", "701", "1001"
                If nOnOff = 1 Then
                    Me.lblSignalLinkTest.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalLinkTest.BackColor = BackColorForSignalOFF
                End If
        End Select
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
        Me.lblSignalLinkTest.BackColor = BackColorForSignalOFF
        Me.lblSignalLinkReq.BackColor = BackColorForSignalOFF
        Me.cmdLinkTest.BackColor = BackColorForSignalOFF
        Me.cmdLinkReq.BackColor = BackColorForSignalOFF
    End Sub

    Private Sub cmdLinkReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkReq.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("000")
            Case "1"
                RaiseEvent RSTSignalClick("080")
            Case "2"
                RaiseEvent RSTSignalClick("100")
        End Select
    End Sub

    Private Sub cmdLinkTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkTest.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("001")
            Case "1"
                RaiseEvent RSTSignalClick("081")
            Case "2"
                RaiseEvent RSTSignalClick("101")
        End Select
    End Sub
End Class
