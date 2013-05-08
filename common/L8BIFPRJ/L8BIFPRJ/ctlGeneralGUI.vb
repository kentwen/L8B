Public Class ctlGeneralGUI

    Dim WithEvents MyTimer As New Timer
    Dim WithEvents MyCheckTimer As New Timer

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        MyCheckTimer.Interval = 200
        MyCheckTimer.Enabled = True

        MyTimer.Interval = 200

    End Sub

    Private Sub MyCheckTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyCheckTimer.Tick
        If g_fMyGeneralGUITimerStart Then
            MyTimer.Enabled = True
        Else
            MyTimer.Enabled = False
        End If
    End Sub

    Private Sub MyTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTimer.Tick
        ScanGeneralGUIBitAddr()

        CheckCVSignalTRReq()
        CheckCVSiganlRobotBusy()
        CheckCVSignalTRComp()

        CheckCVSignalTRReady()
        CheckCVSignalCVReady()

        CheckEQTRReq(1)
        CheckEQTRReq(2)
        CheckEQTRReq(3)

        CheckEQRobotBusy(1)
        CheckEQRobotBusy(2)
        CheckEQRobotBusy(3)

        CheckEQTRComp(1)
        CheckEQTRComp(2)
        CheckEQTRComp(3)

        CheckEQLUEReq(1)
        CheckEQLUEReq(2)
        CheckEQLUEReq(3)

        CheckEQReady(1)
        CheckEQReady(2)
        CheckEQReady(3)

    End Sub

#Region "Signal Definition"

    '0	Transfer  Request(Position 01)
    '1	Robot Busy(Position 01)
    '2	Transfer Complete(Position 01)
    '3	Transfer  Request(Position 02)
    '4	Robot Busy(Position 02)
    '5	Transfer Complete(Position 02)
    '6	Transfer  Request(Position 03)
    '7	Robot Busy(Position 03)
    '8	Transfer Complete(Position 03)
    '9	Transfer  Request(Position 04)
    '10	Robot Busy(Position 04)
    '11	Transfer Complete(Position 04)
    '12	Transfer  Request(Position 05)
    '13	Robot Busy(Position 05)
    '14	Transfer Complete(Position 05)
    '15	
    '16	Transfer  Request(Position 01)
    '17	Robot Busy(Position 01)
    '18	Transfer Complete(Position 01)
    '19	Transfer  Request(Position 02)
    '20	Robot Busy(Position 02)
    '21	Transfer Complete(Position 02)
    '22	Transfer  Request(Position 03)
    '23	Robot Busy(Position 03)
    '24	Transfer Complete(Position 03)
    '25	Transfer  Request(Position 04)
    '26	Robot Busy(Position 04)
    '27	Transfer Complete(Position 04)
    '28	Transfer  Request(Position 05)
    '29	Robot Busy(Position 05)
    '30	Transfer Complete(Position 05)

    '0	Transfer Ready(Position 01)
    '1	CV Ready(Position 01)
    '2	Transfer Ready(Position 02)
    '3	CV Ready(Position 02)
    '4	Transfer Ready(Position 03)
    '5	CV Ready(Position 03)
    '6	Transfer Ready(Position 04)
    '7	CV Ready(Position 04)
    '8	Transfer Ready(Position 05)
    '9	CV Ready(Position 05)
    '16	CV Ready(Position 01)
    '17	CV Ready(Position 02)
    '18	CV Ready(Position 03)
    '19	CV Ready(Position 04)
    '20	CV Ready(Position 05)

#End Region

#Region "GeneralGUI EQ"
    Private Sub CheckEQReady(ByVal nEQIndex As Integer)
        Select Case nEQIndex
            Case 1
                'Load
                If g_afReadEQ1SignalCVBit(1) Then
                    Me.lblEQ1LoadReady.BackColor = Color.Red
                Else
                    Me.lblEQ1LoadReady.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ1SignalCVBit(9) Then
                    Me.lblEQ1UnloadReady.BackColor = Color.Red
                Else
                    Me.lblEQ1UnloadReady.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ1SignalCVBit(17) Then
                    Me.lblEQ1EXReady.BackColor = Color.Red
                Else
                    Me.lblEQ1EXReady.BackColor = Color.White
                End If

                If g_fEQInterlock(1) Then
                    Me.lblEQ1interlock.BackColor = Color.Red
                Else
                    Me.lblEQ1interlock.BackColor = Color.White
                End If
            Case 2
                'Load
                If g_afReadEQ2SignalCVBit(1) Then
                    Me.lblEQ2LoadReady.BackColor = Color.Red
                Else
                    Me.lblEQ2LoadReady.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ2SignalCVBit(9) Then
                    Me.lblEQ2UnloadReady.BackColor = Color.Red
                Else
                    Me.lblEQ2UnloadReady.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ2SignalCVBit(17) Then
                    Me.lblEQ2EXReady.BackColor = Color.Red
                Else
                    Me.lblEQ2EXReady.BackColor = Color.White
                End If

                If g_fEQInterlock(2) Then
                    Me.lblEQ2interlock.BackColor = Color.Red
                Else
                    Me.lblEQ2interlock.BackColor = Color.White
                End If
            Case 3
                'Load
                If g_afReadEQ3SignalCVBit(1) Then
                    Me.lblEQ3LoadReady.BackColor = Color.Red
                Else
                    Me.lblEQ3LoadReady.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ3SignalCVBit(9) Then
                    Me.lblEQ3UnloadReady.BackColor = Color.Red
                Else
                    Me.lblEQ3UnloadReady.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ3SignalCVBit(17) Then
                    Me.lblEQ3EXReady.BackColor = Color.Red
                Else
                    Me.lblEQ3EXReady.BackColor = Color.White
                End If

                If g_fEQInterlock(3) Then
                    Me.lblEQ3interlock.BackColor = Color.Red
                Else
                    Me.lblEQ3interlock.BackColor = Color.White
                End If
        End Select
    End Sub

    Private Sub CheckEQLUEReq(ByVal nEQIndex As Integer)
        Select Case nEQIndex
            Case 1
                'Load
                If g_afReadEQ1SignalCVBit(0) Then
                    Me.lblEQ1LoadReq.BackColor = Color.Red
                Else
                    Me.lblEQ1LoadReq.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ1SignalCVBit(8) Then
                    Me.lblEQ1UnloadReq.BackColor = Color.Red
                Else
                    Me.lblEQ1UnloadReq.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ1SignalCVBit(16) Then
                    Me.lblEQ1EXReq.BackColor = Color.Red
                Else
                    Me.lblEQ1EXReq.BackColor = Color.White
                End If
            Case 2
                'Load
                If g_afReadEQ2SignalCVBit(0) Then
                    Me.lblEQ2LoadReq.BackColor = Color.Red
                Else
                    Me.lblEQ2LoadReq.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ2SignalCVBit(8) Then
                    Me.lblEQ2UnloadReq.BackColor = Color.Red
                Else
                    Me.lblEQ2UnloadReq.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ2SignalCVBit(16) Then
                    Me.lblEQ2EXReq.BackColor = Color.Red
                Else
                    Me.lblEQ2EXReq.BackColor = Color.White
                End If
            Case 3
                'Load
                If g_afReadEQ3SignalCVBit(0) Then
                    Me.lblEQ3LoadReq.BackColor = Color.Red
                Else
                    Me.lblEQ3LoadReq.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ3SignalCVBit(8) Then
                    Me.lblEQ3UnloadReq.BackColor = Color.Red
                Else
                    Me.lblEQ3UnloadReq.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ3SignalCVBit(16) Then
                    Me.lblEQ3EXReq.BackColor = Color.Red
                Else
                    Me.lblEQ3EXReq.BackColor = Color.White
                End If
        End Select
    End Sub

    Private Sub CheckEQTRComp(ByVal nEQIndex As Integer)
        Select Case nEQIndex
            Case 1
                'Load
                If g_afReadEQ1SignalRSTBit(2) Then
                    Me.lblEQ1LoadComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ1LoadComp.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ1SignalRSTBit(10) Then
                    Me.lblEQ1UnloadComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ1UnloadComp.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ1SignalRSTBit(19) Then
                    Me.lblEQ1EXComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ1EXComp.BackColor = Color.White
                End If
            Case 2
                'Load
                If g_afReadEQ2SignalRSTBit(2) Then
                    Me.lblEQ2LoadComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ2LoadComp.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ2SignalRSTBit(10) Then
                    Me.lblEQ2UnloadComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ2UnloadComp.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ2SignalRSTBit(19) Then
                    Me.lblEQ2EXComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ2EXComp.BackColor = Color.White
                End If
            Case 3
                'Load
                If g_afReadEQ3SignalRSTBit(2) Then
                    Me.lblEQ3LoadComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ3LoadComp.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ3SignalRSTBit(10) Then
                    Me.lblEQ3UnloadComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ3UnloadComp.BackColor = Color.White
                End If
                'ExChange
                If g_afReadEQ3SignalRSTBit(19) Then
                    Me.lblEQ3EXComp.BackColor = Color.Aqua
                Else
                    Me.lblEQ3EXComp.BackColor = Color.White
                End If
        End Select
    End Sub

    Private Sub CheckEQRobotBusy(ByVal nEQIndex As Integer)
        Select Case nEQIndex
            Case 1
                'Load
                If g_afReadEQ1SignalRSTBit(1) Then
                    Me.lblEQ1LoadRobotBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ1LoadRobotBusy.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ1SignalRSTBit(9) Then
                    Me.lblEQ1UnloadRobotBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ1UnloadRobotBusy.BackColor = Color.White
                End If
                'Get
                If g_afReadEQ1SignalRSTBit(17) Then
                    Me.lblEQ1GetBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ1GetBusy.BackColor = Color.White
                End If
                'Put
                If g_afReadEQ1SignalRSTBit(18) Then
                    Me.lblEQ1PutBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ1PutBusy.BackColor = Color.White
                End If
            Case 2
                'Load
                If g_afReadEQ2SignalRSTBit(1) Then
                    Me.lblEQ2LoadRobotBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ2LoadRobotBusy.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ2SignalRSTBit(9) Then
                    Me.lblEQ2UnloadRobotBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ2UnloadRobotBusy.BackColor = Color.White
                End If
                'Get
                If g_afReadEQ2SignalRSTBit(17) Then
                    Me.lblEQ2GetBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ2GetBusy.BackColor = Color.White
                End If
                'Put
                If g_afReadEQ2SignalRSTBit(18) Then
                    Me.lblEQ2PutBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ2PutBusy.BackColor = Color.White
                End If
            Case 3
                'Load
                If g_afReadEQ3SignalRSTBit(1) Then
                    Me.lblEQ3LoadRobotBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ3LoadRobotBusy.BackColor = Color.White
                End If
                'Unload
                If g_afReadEQ3SignalRSTBit(9) Then
                    Me.lblEQ3UnloadRobotBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ3UnloadRobotBusy.BackColor = Color.White
                End If
                'Get
                If g_afReadEQ3SignalRSTBit(17) Then
                    Me.lblEQ3GetBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ3GetBusy.BackColor = Color.White
                End If
                'Put
                If g_afReadEQ3SignalRSTBit(18) Then
                    Me.lblEQ3PutBusy.BackColor = Color.Aqua
                Else
                    Me.lblEQ3PutBusy.BackColor = Color.White
                End If
        End Select
    End Sub

    Private Sub CheckEQTRReq(ByVal nEQIndex As Integer)
        Select Case nEQIndex
            Case 1
                'Load
                If g_afReadEQ1SignalRSTBit(0) Then
                    Me.lblEQ1LoadTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ1LoadTRRequest.BackColor = Color.White
                End If

                'Unload
                If g_afReadEQ1SignalRSTBit(8) Then
                    Me.lblEQ1UnloadTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ1UnloadTRRequest.BackColor = Color.White
                End If

                'ExChange
                If g_afReadEQ1SignalRSTBit(16) Then
                    Me.lblEQ1ExTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ1ExTRRequest.BackColor = Color.White
                End If
            Case 2
                'Load
                If g_afReadEQ2SignalRSTBit(0) Then
                    Me.lblEQ2LoadTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ2LoadTRRequest.BackColor = Color.White
                End If

                'Unload
                If g_afReadEQ2SignalRSTBit(8) Then
                    Me.lblEQ2UnloadTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ2UnloadTRRequest.BackColor = Color.White
                End If

                'ExChange
                If g_afReadEQ2SignalRSTBit(16) Then
                    Me.lblEQ2ExTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ2ExTRRequest.BackColor = Color.White
                End If
            Case 3
                'Load
                If g_afReadEQ3SignalRSTBit(0) Then
                    Me.lblEQ3LoadTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ3LoadTRRequest.BackColor = Color.White
                End If

                'Unload
                If g_afReadEQ3SignalRSTBit(8) Then
                    Me.lblEQ3UnloadTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ3UnloadTRRequest.BackColor = Color.White
                End If

                'ExChange
                If g_afReadEQ3SignalRSTBit(16) Then
                    Me.lblEQ3ExTRRequest.BackColor = Color.Aqua
                Else
                    Me.lblEQ3ExTRRequest.BackColor = Color.White
                End If
        End Select
    End Sub
#End Region

#Region "GeneralGUI CV"
    Private Sub CheckCVSignalTRReq()
        '0,3,6,9,12,16,19,22,25,18
        If g_afReadCVSignalRSTBit(0) Or g_afReadCVSignalRSTBit(3) Or g_afReadCVSignalRSTBit(6) Or g_afReadCVSignalRSTBit(9) Or g_afReadCVSignalRSTBit(12) Or g_afReadCVSignalRSTBit(16) Or g_afReadCVSignalRSTBit(19) Or g_afReadCVSignalRSTBit(22) Or g_afReadCVSignalRSTBit(25) Or g_afReadCVSignalRSTBit(28) Then
            Me.lblCV1TRRequest.BackColor = Color.Aqua
        End If

        If g_afReadCVSignalRSTBit(0) = False And g_afReadCVSignalRSTBit(3) = False And g_afReadCVSignalRSTBit(6) = False And g_afReadCVSignalRSTBit(9) = False And g_afReadCVSignalRSTBit(12) = False And g_afReadCVSignalRSTBit(16) = False And g_afReadCVSignalRSTBit(19) = False And g_afReadCVSignalRSTBit(22) = False And g_afReadCVSignalRSTBit(25) = False And g_afReadCVSignalRSTBit(28) = False Then
            Me.lblCV1TRRequest.BackColor = Color.White
        End If
    End Sub

    Private Sub CheckCVSiganlRobotBusy()
        '1,4,7,10,13,17,20,23,26,29
        If g_afReadCVSignalRSTBit(1) Or g_afReadCVSignalRSTBit(4) Or g_afReadCVSignalRSTBit(7) Or g_afReadCVSignalRSTBit(10) Or g_afReadCVSignalRSTBit(13) Or g_afReadCVSignalRSTBit(17) Or g_afReadCVSignalRSTBit(20) Or g_afReadCVSignalRSTBit(23) Or g_afReadCVSignalRSTBit(26) Or g_afReadCVSignalRSTBit(29) Then
            Me.lblCV1RobotBusy.BackColor = Color.Aqua
        End If

        If g_afReadCVSignalRSTBit(1) = False And g_afReadCVSignalRSTBit(4) = False And g_afReadCVSignalRSTBit(7) = False And g_afReadCVSignalRSTBit(10) = False And g_afReadCVSignalRSTBit(13) = False And g_afReadCVSignalRSTBit(17) = False And g_afReadCVSignalRSTBit(20) = False And g_afReadCVSignalRSTBit(23) = False And g_afReadCVSignalRSTBit(26) = False And g_afReadCVSignalRSTBit(29) = False Then
            Me.lblCV1RobotBusy.BackColor = Color.White
        End If
    End Sub

    Private Sub CheckCVSignalTRComp()
        '2,5,8,11,14,18,21,24,27,30
        If g_afReadCVSignalRSTBit(2) Or g_afReadCVSignalRSTBit(5) Or g_afReadCVSignalRSTBit(8) Or g_afReadCVSignalRSTBit(11) Or g_afReadCVSignalRSTBit(14) Or g_afReadCVSignalRSTBit(18) Or g_afReadCVSignalRSTBit(21) Or g_afReadCVSignalRSTBit(24) Or g_afReadCVSignalRSTBit(27) Or g_afReadCVSignalRSTBit(30) Then
            Me.lblCV1TRComp.BackColor = Color.Aqua
        End If

        If g_afReadCVSignalRSTBit(2) = False And g_afReadCVSignalRSTBit(5) = False And g_afReadCVSignalRSTBit(8) = False And g_afReadCVSignalRSTBit(11) = False And g_afReadCVSignalRSTBit(14) = False And g_afReadCVSignalRSTBit(18) = False And g_afReadCVSignalRSTBit(21) = False And g_afReadCVSignalRSTBit(24) = False And g_afReadCVSignalRSTBit(27) = False And g_afReadCVSignalRSTBit(30) = False Then
            Me.lblCV1TRComp.BackColor = Color.White
        End If
    End Sub

    Private Sub CheckCVSignalTRReady()
        '0,2,4,6,8
        If g_afReadCVSignalCVBit(0) Or g_afReadCVSignalCVBit(2) Or g_afReadCVSignalCVBit(4) Or g_afReadCVSignalCVBit(6) Or g_afReadCVSignalCVBit(8) Then
            Me.lblCV1TRReady.BackColor = Color.Red
        End If

        If g_afReadCVSignalCVBit(0) = False And g_afReadCVSignalCVBit(2) = False And g_afReadCVSignalCVBit(4) = False And g_afReadCVSignalCVBit(6) = False And g_afReadCVSignalCVBit(8) = False Then
            Me.lblCV1TRReady.BackColor = Color.White
        End If
    End Sub

    Private Sub CheckCVSignalCVReady()
        '1,3,5,7,9,16,17,18,19,20
        If g_afReadCVSignalCVBit(1) Or g_afReadCVSignalCVBit(3) Or g_afReadCVSignalCVBit(5) Or g_afReadCVSignalCVBit(7) Or g_afReadCVSignalCVBit(9) Or g_afReadCVSignalCVBit(16) Or g_afReadCVSignalCVBit(17) Or g_afReadCVSignalCVBit(18) Or g_afReadCVSignalCVBit(19) Or g_afReadCVSignalCVBit(20) Then
            Me.lblCV1CVReady.BackColor = Color.Red
        End If

        If g_afReadCVSignalCVBit(1) = False And g_afReadCVSignalCVBit(3) = False And g_afReadCVSignalCVBit(5) = False And g_afReadCVSignalCVBit(7) = False And g_afReadCVSignalCVBit(9) = False And g_afReadCVSignalCVBit(16) = False And g_afReadCVSignalCVBit(17) = False And g_afReadCVSignalCVBit(18) = False And g_afReadCVSignalCVBit(19) = False And g_afReadCVSignalCVBit(20) = False Then
            Me.lblCV1CVReady.BackColor = Color.White
        End If
    End Sub
#End Region
End Class
