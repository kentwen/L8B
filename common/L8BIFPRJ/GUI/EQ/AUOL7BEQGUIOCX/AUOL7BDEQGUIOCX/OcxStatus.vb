Imports System.Drawing
Public Class OcxStatus
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
            Case "10", "90", "110"
                If nOnOff = 1 Then
                    Me.cmdIgnoreTimeout.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdIgnoreTimeout.BackColor = BackColorForSignalOFF
                End If

            Case "11", "91", "111"
                If nOnOff = 1 Then
                    Me.cmdArmMode.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdArmMode.BackColor = BackColorForSignalOFF
                End If

            Case "12", "92", "112"
                If nOnOff = 1 Then
                    Me.cmdTransferMode.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTransferMode.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal nRemoteStatus() As Integer, ByVal nRSTMode() As Integer, ByVal nAlarmOccurr() As Integer, ByVal nEQStatus() As Integer, ByVal nGxInProcess() As Integer, ByVal nGxOnStage() As Integer, ByVal nHandoff() As Integer, ByVal strToolID() As String)
        MyUpdataEQStatusGUI.nEQ1RemoteStatus = nRemoteStatus(1)
        MyUpdataEQStatusGUI.nEQ1StationMode = nRSTMode(1)
        MyUpdataEQStatusGUI.nEQ1AlarmOccurred = nAlarmOccurr(1)
        MyUpdataEQStatusGUI.nEQ1Status = nEQStatus(1)
        MyUpdataEQStatusGUI.nEQ1GxInProcess = nGxInProcess(1)
        MyUpdataEQStatusGUI.nEQ1GxExistOnStage = nGxOnStage(1)
        MyUpdataEQStatusGUI.nEQ1HandoffAvailable = nHandoff(1)
        MyUpdataEQStatusGUI.strEQ1ToolID = strToolID(1)

        MyUpdataEQStatusGUI.nEQ2RemoteStatus = nRemoteStatus(2)
        MyUpdataEQStatusGUI.nEQ2StationMode = nRSTMode(2)
        MyUpdataEQStatusGUI.nEQ2AlarmOccurred = nAlarmOccurr(2)
        MyUpdataEQStatusGUI.nEQ2Status = nEQStatus(2)
        MyUpdataEQStatusGUI.nEQ2GxInProcess = nGxInProcess(2)
        MyUpdataEQStatusGUI.nEQ2GxExistOnStage = nGxOnStage(2)
        MyUpdataEQStatusGUI.nEQ2HandoffAvailable = nHandoff(2)
        MyUpdataEQStatusGUI.strEQ2ToolID = strToolID(2)

        MyUpdataEQStatusGUI.nEQ3RemoteStatus = nRemoteStatus(3)
        MyUpdataEQStatusGUI.nEQ3StationMode = nRSTMode(3)
        MyUpdataEQStatusGUI.nEQ3AlarmOccurred = nAlarmOccurr(3)
        MyUpdataEQStatusGUI.nEQ3Status = nEQStatus(3)
        MyUpdataEQStatusGUI.nEQ3GxInProcess = nGxInProcess(3)
        MyUpdataEQStatusGUI.nEQ3GxExistOnStage = nGxOnStage(3)
        MyUpdataEQStatusGUI.nEQ3HandoffAvailable = nHandoff(3)
        MyUpdataEQStatusGUI.strEQ3ToolID = strToolID(3)

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
        Me.cmdArmMode.BackColor = BackColorForSignalOFF
        Me.cmdIgnoreTimeout.BackColor = BackColorForSignalOFF
        Me.cmdTransferMode.BackColor = BackColorForSignalOFF
        Me.txtRemoteStatus.Text = ""
        Me.txtRSTMode.Text = ""

        Me.lblWAlarmOccurr.Text = ""
        Me.lblWEQStatus.Text = ""
        Me.lblWGxInProcess.Text = ""
        Me.lblWGxOnStage.Text = ""
        Me.lblWHandoff.Text = ""
        Me.lblWToolID.Text = ""
        Me.lblWAlarmOccurr.Text = ""
    End Sub

    Private Sub cmdIgnoreTimeout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIgnoreTimeout.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("010")
            Case "1"
                RaiseEvent RSTSignalClick("090")
            Case "2"
                RaiseEvent RSTSignalClick("110")
        End Select
    End Sub

    Private Sub cmdArmMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArmMode.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("011")
            Case "1"
                RaiseEvent RSTSignalClick("091")
            Case "2"
                RaiseEvent RSTSignalClick("111")
        End Select
    End Sub

    Private Sub cmdTransferMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransferMode.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("012")
            Case "1"
                RaiseEvent RSTSignalClick("092")
            Case "2"
                RaiseEvent RSTSignalClick("112")
        End Select
    End Sub

    Public Sub ShowGUIEQStatus()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.txtRemoteStatus.Text = MyUpdataEQStatusGUI.nEQ1RemoteStatus
                Me.txtRSTMode.Text = MyUpdataEQStatusGUI.nEQ1StationMode

                Me.lblWAlarmOccurr.Text = MyUpdataEQStatusGUI.nEQ1AlarmOccurred
                Me.lblWEQStatus.Text = MyUpdataEQStatusGUI.nEQ1Status
                Me.lblWGxInProcess.Text = MyUpdataEQStatusGUI.nEQ1GxInProcess
                Me.lblWGxOnStage.Text = MyUpdataEQStatusGUI.nEQ1GxExistOnStage
                Me.lblWHandoff.Text = MyUpdataEQStatusGUI.nEQ1HandoffAvailable
                Me.lblWToolID.Text = MyUpdataEQStatusGUI.strEQ1ToolID
            Case 2
                Me.txtRemoteStatus.Text = MyUpdataEQStatusGUI.nEQ2RemoteStatus
                Me.txtRSTMode.Text = MyUpdataEQStatusGUI.nEQ2StationMode

                Me.lblWAlarmOccurr.Text = MyUpdataEQStatusGUI.nEQ2AlarmOccurred
                Me.lblWEQStatus.Text = MyUpdataEQStatusGUI.nEQ2Status
                Me.lblWGxInProcess.Text = MyUpdataEQStatusGUI.nEQ2GxInProcess
                Me.lblWGxOnStage.Text = MyUpdataEQStatusGUI.nEQ2GxExistOnStage
                Me.lblWHandoff.Text = MyUpdataEQStatusGUI.nEQ2HandoffAvailable
                Me.lblWToolID.Text = MyUpdataEQStatusGUI.strEQ2ToolID
            Case 3
                Me.txtRemoteStatus.Text = MyUpdataEQStatusGUI.nEQ3RemoteStatus
                Me.txtRSTMode.Text = MyUpdataEQStatusGUI.nEQ3StationMode

                Me.lblWAlarmOccurr.Text = MyUpdataEQStatusGUI.nEQ3AlarmOccurred
                Me.lblWEQStatus.Text = MyUpdataEQStatusGUI.nEQ3Status
                Me.lblWGxInProcess.Text = MyUpdataEQStatusGUI.nEQ3GxInProcess
                Me.lblWGxOnStage.Text = MyUpdataEQStatusGUI.nEQ3GxExistOnStage
                Me.lblWHandoff.Text = MyUpdataEQStatusGUI.nEQ3HandoffAvailable
                Me.lblWToolID.Text = MyUpdataEQStatusGUI.strEQ3ToolID
        End Select
    End Sub
End Class
