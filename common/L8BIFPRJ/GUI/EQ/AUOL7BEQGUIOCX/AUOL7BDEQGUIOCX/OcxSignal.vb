Imports System.Drawing
Public Class OcxSignal
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

            Case "20", "A0", "120"
                If nOnOff = 1 Then
                    Me.cmdLoadTR.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLoadTR.BackColor = BackColorForSignalOFF
                End If

            Case "21", "A1", "121"
                If nOnOff = 1 Then
                    Me.cmdLoadBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLoadBusy.BackColor = BackColorForSignalOFF
                End If

            Case "22", "A2", "122"
                If nOnOff = 1 Then
                    Me.cmdLoadComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLoadComp.BackColor = BackColorForSignalOFF
                End If

            Case "28", "A8", "128"
                If nOnOff = 1 Then
                    Me.cmdUnloadTR.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdUnloadTR.BackColor = BackColorForSignalOFF
                End If

            Case "29", "A9", "129"
                If nOnOff = 1 Then
                    Me.cmdUnloadBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdUnloadBusy.BackColor = BackColorForSignalOFF
                End If

            Case "2A", "AA", "12A"
                If nOnOff = 1 Then
                    Me.cmdUnloadComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdUnloadComp.BackColor = BackColorForSignalOFF
                End If

            Case "30", "B0", "130"
                If nOnOff = 1 Then
                    Me.cmdExTR.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdExTR.BackColor = BackColorForSignalOFF
                End If

            Case "31", "B1", "131"
                If nOnOff = 1 Then
                    Me.cmdExGetBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdExGetBusy.BackColor = BackColorForSignalOFF
                End If

            Case "32", "B2", "132"
                If nOnOff = 1 Then
                    Me.cmdExPutBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdExPutBusy.BackColor = BackColorForSignalOFF
                End If

            Case "33", "B3", "133"
                If nOnOff = 1 Then
                    Me.cmdExComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdExComp.BackColor = BackColorForSignalOFF
                End If

            Case "34", "B4", "134"
                If nOnOff = 1 Then
                    Me.cmdExStatus.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdExStatus.BackColor = BackColorForSignalOFF
                End If

            Case "40", "C0", "140"
                If nOnOff = 1 Then
                    Me.cmdEPPIDModifyAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdEPPIDModifyAck.BackColor = BackColorForSignalOFF
                End If
            Case "42", "C2", "142"
                If nOnOff = 1 Then
                    Me.cmdTRResetReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRResetReq.BackColor = BackColorForSignalOFF
                End If

            Case "43", "C3", "143"
                If nOnOff = 1 Then
                    Me.cmdGxEraseAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdGxEraseAck.BackColor = BackColorForSignalOFF
                End If

            Case "45", "C5", "145"
                If nOnOff = 1 Then
                    Me.cmdEPPIDChkReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdEPPIDChkReq.BackColor = BackColorForSignalOFF
                End If

            Case "47", "C7", "147"
                If nOnOff = 1 Then
                    Me.cmdEPPIDQueryReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdEPPIDQueryReq.BackColor = BackColorForSignalOFF
                End If

            Case "50", "D0", "150"
                If nOnOff = 1 Then
                    Me.cmdInspectionFlag.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdInspectionFlag.BackColor = BackColorForSignalOFF
                End If

            Case "49", "C9", "149"
                If nOnOff = 1 Then
                    Me.cmdRepairReviewMode.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRepairReviewMode.BackColor = BackColorForSignalOFF
                End If

                '------------------------------------------------------------------------------

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
            Case "310", "710", "1010"
                If nOnOff = 1 Then
                    Me.lblSignalGxOnStage.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxOnStage.BackColor = BackColorForSignalOFF
                End If
            Case "311", "711", "1011"
                If nOnOff = 1 Then
                    Me.lblSignalGxInProcess.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxInProcess.BackColor = BackColorForSignalOFF
                End If
            Case "312", "712", "1012"
                If nOnOff = 1 Then
                    Me.lblSignalHandoff.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalHandoff.BackColor = BackColorForSignalOFF
                End If
            Case "315", "715", "1015"
                If nOnOff = 1 Then
                    Me.lblSignalAlarmOccurred.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalAlarmOccurred.BackColor = BackColorForSignalOFF
                End If
            Case "320", "720", "1020"
                If nOnOff = 1 Then
                    Me.lblSignalLoadReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalLoadReq.BackColor = BackColorForSignalOFF
                End If
            Case "321", "721", "1021"
                If nOnOff = 1 Then
                    Me.lblSignalLoadReady.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalLoadReady.BackColor = BackColorForSignalOFF
                End If
            Case "328", "728", "1028"
                If nOnOff = 1 Then
                    Me.lblSignalUnloadReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalUnloadReq.BackColor = BackColorForSignalOFF
                End If
            Case "329", "729", "1029"
                If nOnOff = 1 Then
                    Me.lblSignalUnloadReady.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalUnloadReady.BackColor = BackColorForSignalOFF
                End If
            Case "330", "730", "1030"
                If nOnOff = 1 Then
                    Me.lblSignalExReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalExReq.BackColor = BackColorForSignalOFF
                End If
            Case "331", "731", "1031"
                If nOnOff = 1 Then
                    Me.lblSignalExReady.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalExReady.BackColor = BackColorForSignalOFF
                End If
            Case "340", "740", "1040"
                If nOnOff = 1 Then
                    Me.lblSignalEPPIDModifyReport.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalEPPIDModifyReport.BackColor = BackColorForSignalOFF
                End If
            Case "342", "742", "1042"
                If nOnOff = 1 Then
                    Me.lblSignalTRResetAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF
                End If
            Case "343", "743", "1043"
                If nOnOff = 1 Then
                    Me.lblSignalGxEraseReport.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalGxEraseReport.BackColor = BackColorForSignalOFF
                End If
            Case "345", "745", "1045"
                If nOnOff = 1 Then
                    Me.lblSignalEPPIDChkAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalEPPIDChkAck.BackColor = BackColorForSignalOFF
                End If

            Case "347", "747", "1047"
                If nOnOff = 1 Then
                    Me.lblSignalEPPIDQueryAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalEPPIDQueryAck.BackColor = BackColorForSignalOFF
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
        Me.cmdEPPIDQueryReq.BackColor = BackColorForSignalOFF
        Me.cmdInspectionFlag.BackColor = BackColorForSignalOFF
        Me.cmdArmMode.BackColor = BackColorForSignalOFF
        Me.cmdEPPIDChkReq.BackColor = BackColorForSignalOFF
        Me.cmdEPPIDModifyAck.BackColor = BackColorForSignalOFF
        Me.cmdExComp.BackColor = BackColorForSignalOFF
        Me.cmdExGetBusy.BackColor = BackColorForSignalOFF
        Me.cmdExPutBusy.BackColor = BackColorForSignalOFF
        Me.cmdExStatus.BackColor = BackColorForSignalOFF
        Me.cmdExTR.BackColor = BackColorForSignalOFF
        Me.cmdGxEraseAck.BackColor = BackColorForSignalOFF
        Me.cmdIgnoreTimeout.BackColor = BackColorForSignalOFF
        Me.cmdLinkReq.BackColor = BackColorForSignalOFF
        Me.cmdLinkTest.BackColor = BackColorForSignalOFF
        Me.cmdLoadBusy.BackColor = BackColorForSignalOFF
        Me.cmdLoadComp.BackColor = BackColorForSignalOFF
        Me.cmdLoadTR.BackColor = BackColorForSignalOFF
        Me.cmdTransferMode.BackColor = BackColorForSignalOFF
        Me.cmdTRResetReq.BackColor = BackColorForSignalOFF
        Me.cmdUnloadBusy.BackColor = BackColorForSignalOFF
        Me.cmdUnloadComp.BackColor = BackColorForSignalOFF
        Me.cmdUnloadTR.BackColor = BackColorForSignalOFF


        Me.lblSignalAlarmOccurred.BackColor = BackColorForSignalOFF
        Me.lblSignalEPPIDChkAck.BackColor = BackColorForSignalOFF
        Me.lblSignalEPPIDModifyReport.BackColor = BackColorForSignalOFF
        Me.lblSignalExReady.BackColor = BackColorForSignalOFF
        Me.lblSignalExReq.BackColor = BackColorForSignalOFF
        Me.lblSignalGxEraseReport.BackColor = BackColorForSignalOFF
        Me.lblSignalGxInProcess.BackColor = BackColorForSignalOFF
        Me.lblSignalGxOnStage.BackColor = BackColorForSignalOFF
        Me.lblSignalHandoff.BackColor = BackColorForSignalOFF
        Me.lblSignalLinkReq.BackColor = BackColorForSignalOFF
        Me.lblSignalLinkTest.BackColor = BackColorForSignalOFF
        Me.lblSignalLoadReady.BackColor = BackColorForSignalOFF
        Me.lblSignalLoadReq.BackColor = BackColorForSignalOFF
        Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF
        Me.lblSignalUnloadReady.BackColor = BackColorForSignalOFF
        Me.lblSignalUnloadReq.BackColor = BackColorForSignalOFF

        Me.lblSignalEPPIDQueryAck.BackColor = BackColorForSignalOFF
    End Sub

    Private Sub cmdLinkReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkReq.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("0")
            Case "1"
                RaiseEvent RSTSignalClick("80")
            Case "2"
                RaiseEvent RSTSignalClick("100")
        End Select
    End Sub

    Private Sub cmdLinkTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkTest.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("1")
            Case "1"
                RaiseEvent RSTSignalClick("81")
            Case "2"
                RaiseEvent RSTSignalClick("101")
        End Select
    End Sub

    Private Sub cmdIgnoreTimeout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIgnoreTimeout.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("10")
            Case "1"
                RaiseEvent RSTSignalClick("90")
            Case "2"
                RaiseEvent RSTSignalClick("110")
        End Select
    End Sub

    Private Sub cmdArmMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArmMode.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("11")
            Case "1"
                RaiseEvent RSTSignalClick("91")
            Case "2"
                RaiseEvent RSTSignalClick("111")
        End Select
    End Sub

    Private Sub cmdTransferMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransferMode.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("12")
            Case "1"
                RaiseEvent RSTSignalClick("92")
            Case "2"
                RaiseEvent RSTSignalClick("112")
        End Select
    End Sub

    Private Sub cmdLoadTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadTR.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("20")
            Case "1"
                RaiseEvent RSTSignalClick("A0")
            Case "2"
                RaiseEvent RSTSignalClick("120")
        End Select
    End Sub

    Private Sub cmdLoadBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadBusy.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("21")
            Case "1"
                RaiseEvent RSTSignalClick("A1")
            Case "2"
                RaiseEvent RSTSignalClick("121")
        End Select
    End Sub

    Private Sub cmdLoadComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadComp.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("22")
            Case "1"
                RaiseEvent RSTSignalClick("A2")
            Case "2"
                RaiseEvent RSTSignalClick("122")
        End Select
    End Sub

    Private Sub cmdExStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExStatus.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("34")
            Case "1"
                RaiseEvent RSTSignalClick("B4")
            Case "2"
                RaiseEvent RSTSignalClick("134")
        End Select
    End Sub

    Private Sub cmdUnloadTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnloadTR.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("28")
            Case "1"
                RaiseEvent RSTSignalClick("A8")
            Case "2"
                RaiseEvent RSTSignalClick("128")
        End Select
    End Sub

    Private Sub cmdUnloadBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnloadBusy.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("29")
            Case "1"
                RaiseEvent RSTSignalClick("A9")
            Case "2"
                RaiseEvent RSTSignalClick("129")
        End Select
    End Sub

    Private Sub cmdUnloadComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnloadComp.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("2A")
            Case "1"
                RaiseEvent RSTSignalClick("AA")
            Case "2"
                RaiseEvent RSTSignalClick("12A")
        End Select
    End Sub

    Private Sub cmdExTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExTR.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("30")
            Case "1"
                RaiseEvent RSTSignalClick("B0")
            Case "2"
                RaiseEvent RSTSignalClick("130")
        End Select
    End Sub

    Private Sub cmdExGetBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExGetBusy.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("31")
            Case "1"
                RaiseEvent RSTSignalClick("B1")
            Case "2"
                RaiseEvent RSTSignalClick("131")
        End Select
    End Sub

    Private Sub cmdExPutBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExPutBusy.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("32")
            Case "1"
                RaiseEvent RSTSignalClick("B2")
            Case "2"
                RaiseEvent RSTSignalClick("132")
        End Select
    End Sub

    Private Sub cmdExComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExComp.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("33")
            Case "1"
                RaiseEvent RSTSignalClick("B3")
            Case "2"
                RaiseEvent RSTSignalClick("133")
        End Select
    End Sub

    Private Sub cmdEPPIDModifyAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEPPIDModifyAck.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("40")
            Case "1"
                RaiseEvent RSTSignalClick("C0")
            Case "2"
                RaiseEvent RSTSignalClick("140")
        End Select
    End Sub

    Private Sub cmdTRResetReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRResetReq.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("42")
            Case "1"
                RaiseEvent RSTSignalClick("C2")
            Case "2"
                RaiseEvent RSTSignalClick("142")
        End Select
    End Sub

    Private Sub cmdGxEraseAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGxEraseAck.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("43")
            Case "1"
                RaiseEvent RSTSignalClick("C3")
            Case "2"
                RaiseEvent RSTSignalClick("143")
        End Select
    End Sub

    Private Sub cmdEPPIDChkReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEPPIDChkReq.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("45")
            Case "1"
                RaiseEvent RSTSignalClick("C5")
            Case "2"
                RaiseEvent RSTSignalClick("145")
        End Select
    End Sub

    Private Sub cmdEPPIDQueryReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEPPIDQueryReq.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("47")
            Case "1"
                RaiseEvent RSTSignalClick("C7")
            Case "2"
                RaiseEvent RSTSignalClick("147")
        End Select
    End Sub

    Private Sub cmdInspectionFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInspectionFlag.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("50")
            Case "1"
                RaiseEvent RSTSignalClick("D0")
            Case "2"
                RaiseEvent RSTSignalClick("150")
        End Select
    End Sub

    Private Sub cmdRepairReviewMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRepairReviewMode.Click
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("49")
            Case "1"
                RaiseEvent RSTSignalClick("C9")
            Case "2"
                RaiseEvent RSTSignalClick("149")
        End Select
    End Sub
End Class
