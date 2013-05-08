Imports System.Drawing

Public Class CSTDummyCancel

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
            Case "0200", "0201", "0202", "0203", "0204"
                If nOnOff = 1 Then
                    Me.cmdDummyCancelReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdDummyCancelReq.BackColor = BackColorForSignalOFF
                End If
            Case "1330", "1331", "1332", "1333", "1334"
                If nOnOff = 1 Then
                    Me.lblSignalDummyCancelAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalDummyCancelAck.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nResult As String)
        MyUpdataCVDummyCancelResult.nDummyCancelResult = nResult
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
        Me.cmdDummyCancelReq.BackColor = BackColorForSignalOFF
        Me.lblSignalDummyCancelAck.BackColor = BackColorForSignalOFF
        Me.lblWDummyCancelResult.Text = ""
    End Sub

    Private Sub cmdDummyCancelReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDummyCancelReq.Click
        Dim nConvertPortIndex As Integer

        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case 0
                RaiseEvent RSTSignalClick("0200")
            Case 1
                RaiseEvent RSTSignalClick("0201")
            Case 2
                RaiseEvent RSTSignalClick("0202")
            Case 3
                RaiseEvent RSTSignalClick("0203")
            Case 4
                RaiseEvent RSTSignalClick("0204")
        End Select
    End Sub

    Public Sub ShowGUIDummyCancelResult()
        Me.lblWDummyCancelResult.Text = MyUpdataCVDummyCancelResult.nDummyCancelResult
    End Sub
End Class
