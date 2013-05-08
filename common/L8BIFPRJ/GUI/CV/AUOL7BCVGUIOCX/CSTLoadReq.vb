Imports System.Drawing

Public Class CSTLoadReq
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
            Case "0190", "0191", "0192", "0193", "0194"
                If nOnOff = 1 Then
                    Me.cmdLoadCSTReqAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLoadCSTReqAck.BackColor = BackColorForSignalOFF
                End If
            Case "1340", "1341", "1342", "1343", "1344"
                If nOnOff = 1 Then
                    Me.lblSignalCSTLoadReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalCSTLoadReq.BackColor = BackColorForSignalOFF
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

    Private Sub ResetSignal()
        Me.lblSignalCSTLoadReq.BackColor = BackColorForSignalOFF
        Me.cmdLoadCSTReqAck.BackColor = BackColorForSignalOFF
    End Sub

    Private Sub cmdLoadCSTReqAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadCSTReqAck.Click
        Dim nConvertPortIndex As Integer
        If Not ENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("0190")
            Case "1"
                RaiseEvent RSTSignalClick("0191")
            Case "2"
                RaiseEvent RSTSignalClick("0192")
            Case "3"
                RaiseEvent RSTSignalClick("0193")
            Case "4"
                RaiseEvent RSTSignalClick("0194")
        End Select
    End Sub
End Class
