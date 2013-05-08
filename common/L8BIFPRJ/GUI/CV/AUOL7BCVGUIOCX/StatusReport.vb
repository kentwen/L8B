Imports System.Drawing
Public Class StatusReport
    Public Event PortTabChange(ByVal nPort As Integer)
    Public Event RSTSignalClick(ByVal strSignalID As String)
    Public Event WordValChange(ByVal strRunningMode As String)

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
            Case "0183"
                If nOnOff = 1 Then
                    Me.cmdRBT01Alive.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBT01Alive.BackColor = BackColorForSignalOFF
                End If
            Case "0184"
                If nOnOff = 1 Then
                    Me.cmdRBT02Alive.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBT02Alive.BackColor = BackColorForSignalOFF
                End If
            Case "1325"
                Me.lblWAlarmOccurred.Text = nOnOff
        End Select
    End Sub

    Public Sub SetWordData(Optional ByVal strRunningMode As String = "", Optional ByVal strAlarmOccurred As String = "", Optional ByVal strCSTProductCode1 As String = "", Optional ByVal strCSTProductCode2 As String = "", Optional ByVal strCSTProductCode3 As String = "", Optional ByVal strCSTProductCode4 As String = "", Optional ByVal strCSTProductCode5 As String = "", Optional ByVal strCVStatus As String = "", Optional ByVal strGxExistInfo1 As String = "", Optional ByVal strGxExistInfo2 As String = "", Optional ByVal strGxExistInfo3 As String = "", Optional ByVal strGxExistInfo4 As String = "", Optional ByVal strGxExistInfo5 As String = "", Optional ByVal strGxQTYInCST1 As String = "", Optional ByVal strGxQTYInCST2 As String = "", Optional ByVal strGxQTYInCST3 As String = "", Optional ByVal strGxQTYInCST4 As String = "", Optional ByVal strGxQTYInCST5 As String = "", Optional ByVal strToolId As String = "")
        'Me.txtRunningMode.Text = strRunningMode
        'Me.lblWAlarmOccurred.Text = strAlarmOccurred
        'Me.lblWCSTProductCode1.Text = strCSTProductCode1
        'Me.lblWCSTProductCode2.Text = strCSTProductCode2
        'Me.lblWCSTProductCode3.Text = strCSTProductCode3
        'Me.lblWCSTProductCode4.Text = strCSTProductCode4
        'Me.lblWCSTProductCode5.Text = strCSTProductCode5
        'Me.lblWCVStatus.Text = strCVStatus
        'Me.lblWGxExistInfo1.Text = strGxExistInfo1
        'Me.lblWGxExistInfo2.Text = strGxExistInfo2
        'Me.lblWGxExistInfo3.Text = strGxExistInfo3
        'Me.lblWGxExistInfo4.Text = strGxExistInfo4
        'Me.lblWGxExistInfo5.Text = strGxExistInfo5
        'Me.lblWGxQTYInCST1.Text = strGxQTYInCST1
        'Me.lblWGxQTYInCST2.Text = strGxQTYInCST2
        'Me.lblWGxQTYInCST3.Text = strGxQTYInCST3
        'Me.lblWGxQTYInCST4.Text = strGxQTYInCST4
        'Me.lblWGxQTYInCST5.Text = strGxQTYInCST5
        'Me.lblWToolId.Text = strToolId

        MyUpdataCVStatusGUI.strRunningMode = strRunningMode
        MyUpdataCVStatusGUI.strAlarmOccurred = strAlarmOccurred
        MyUpdataCVStatusGUI.strCSTProductCode1 = strCSTProductCode1
        MyUpdataCVStatusGUI.strCSTProductCode2 = strCSTProductCode2
        MyUpdataCVStatusGUI.strCSTProductCode3 = strCSTProductCode3
        MyUpdataCVStatusGUI.strCSTProductCode4 = strCSTProductCode4
        MyUpdataCVStatusGUI.strCSTProductCode5 = strCSTProductCode5
        MyUpdataCVStatusGUI.strCVStatus = strCVStatus
        MyUpdataCVStatusGUI.strGxExistInfo1 = strGxExistInfo1
        MyUpdataCVStatusGUI.strGxExistInfo2 = strGxExistInfo2
        MyUpdataCVStatusGUI.strGxExistInfo3 = strGxExistInfo3
        MyUpdataCVStatusGUI.strGxExistInfo4 = strGxExistInfo4
        MyUpdataCVStatusGUI.strGxExistInfo5 = strGxExistInfo5
        MyUpdataCVStatusGUI.strGxQTYInCST1 = strGxQTYInCST1
        MyUpdataCVStatusGUI.strGxQTYInCST2 = strGxQTYInCST2
        MyUpdataCVStatusGUI.strGxQTYInCST3 = strGxQTYInCST3
        MyUpdataCVStatusGUI.strGxQTYInCST4 = strGxQTYInCST4
        MyUpdataCVStatusGUI.strGxQTYInCST5 = strGxQTYInCST5
        MyUpdataCVStatusGUI.strToolId = strToolId
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
        Me.lblWAlarmOccurred.Text = ""
        Me.lblWCSTProductCode1.Text = ""
        Me.lblWCSTProductCode2.Text = ""
        Me.lblWCSTProductCode3.Text = ""
        Me.lblWCSTProductCode4.Text = ""
        Me.lblWCSTProductCode5.Text = ""
        Me.lblWCVStatus.Text = ""
        Me.lblWGxExistInfo1.Text = ""
        Me.lblWGxExistInfo2.Text = ""
        Me.lblWGxExistInfo3.Text = ""
        Me.lblWGxExistInfo4.Text = ""
        Me.lblWGxExistInfo5.Text = ""
        Me.lblWGxQTYInCST1.Text = ""
        Me.lblWGxQTYInCST2.Text = ""
        Me.lblWGxQTYInCST3.Text = ""
        Me.lblWGxQTYInCST4.Text = ""
        Me.lblWGxQTYInCST5.Text = ""
        Me.lblWToolId.Text = ""

    End Sub

    Private Sub cmdWriteWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWriteWord.Click
        Dim strRunningMode As String
        If Not ENGType Then Exit Sub

        strRunningMode = txtRunningMode.Text

        RaiseEvent WordValChange(strRunningMode)
    End Sub

    Private Sub cmdRBT01Alive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBT01Alive.Click         
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("0183")
    End Sub

    Private Sub cmdRBT02Alive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBT02Alive.Click
        If Not ENGType Then Exit Sub
        RaiseEvent RSTSignalClick("0184")
    End Sub

    Public Sub ShowGUIStatusReport()
        Me.txtRunningMode.Text = MyUpdataCVStatusGUI.strRunningMode
        Me.lblWAlarmOccurred.Text = MyUpdataCVStatusGUI.strAlarmOccurred
        Me.lblWCSTProductCode1.Text = MyUpdataCVStatusGUI.strCSTProductCode1
        Me.lblWCSTProductCode2.Text = MyUpdataCVStatusGUI.strCSTProductCode2
        Me.lblWCSTProductCode3.Text = MyUpdataCVStatusGUI.strCSTProductCode3
        Me.lblWCSTProductCode4.Text = MyUpdataCVStatusGUI.strCSTProductCode4
        Me.lblWCSTProductCode5.Text = MyUpdataCVStatusGUI.strCSTProductCode5
        Me.lblWCVStatus.Text = MyUpdataCVStatusGUI.strCVStatus
        Me.lblWGxExistInfo1.Text = MyUpdataCVStatusGUI.strGxExistInfo1
        Me.lblWGxExistInfo2.Text = MyUpdataCVStatusGUI.strGxExistInfo2
        Me.lblWGxExistInfo3.Text = MyUpdataCVStatusGUI.strGxExistInfo3
        Me.lblWGxExistInfo4.Text = MyUpdataCVStatusGUI.strGxExistInfo4
        Me.lblWGxExistInfo5.Text = MyUpdataCVStatusGUI.strGxExistInfo5
        Me.lblWGxQTYInCST1.Text = MyUpdataCVStatusGUI.strGxQTYInCST1
        Me.lblWGxQTYInCST2.Text = MyUpdataCVStatusGUI.strGxQTYInCST2
        Me.lblWGxQTYInCST3.Text = MyUpdataCVStatusGUI.strGxQTYInCST3
        Me.lblWGxQTYInCST4.Text = MyUpdataCVStatusGUI.strGxQTYInCST4
        Me.lblWGxQTYInCST5.Text = MyUpdataCVStatusGUI.strGxQTYInCST5
        Me.lblWToolId.Text = MyUpdataCVStatusGUI.strToolId
    End Sub
End Class
