Imports System .Drawing 
Public Class OcxGxUnload
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
            Case "28", "A8", "128"
                If nOnOff = 1 Then
                    Me.cmdTRRequest.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRRequest.BackColor = BackColorForSignalOFF
                End If
            Case "29", "A9", "129"
                If nOnOff = 1 Then
                    Me.cmdRBTBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBTBusy.BackColor = BackColorForSignalOFF
                End If
            Case "2A", "AA", "12A"
                If nOnOff = 1 Then
                    Me.cmdUnloadComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdUnloadComp.BackColor = BackColorForSignalOFF
                End If
            
            Case "42", "C2", "142"
                If nOnOff = 1 Then
                    Me.cmdTRResetReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRResetReq.BackColor = BackColorForSignalOFF
                End If
            Case "328", "728", "1028"
                If nOnOff = 1 Then
                    Me.lblSignalUnloadReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalUnloadReq.BackColor = BackColorForSignalOFF
                End If
            Case "329", "729", "1029"
                If nOnOff = 1 Then
                    Me.lblSignalEQReady.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalEQReady.BackColor = BackColorForSignalOFF
                End If
            Case "342", "742", "1042"
                If nOnOff = 1 Then
                    Me.lblSignalTRResetAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal strChipGraade() As String, ByVal strGxID() As String, ByVal nProcessRes() As Integer, ByVal strPSH() As String, ByVal nSampleGxFl() As Integer, ByVal nSlotInfo() As Integer)
        'Me.lblWChipGraade.Text = strChipGraade
        'Me.lblWGxID.Text = strGxID
        'Me.lblWProcessResult.Text = strProcessRes
        'Me.lblWPSH.Text = strPSH
        'Me.lblWSampleGxFlag.Text = strSampleGxFl
        'Me.lblWSlotInfo.Text = strSlotInfo

        MyUpdataGUIEQGXUnload.strEQ1ChipGraade = strChipGraade(1)
        MyUpdataGUIEQGXUnload.strEQ2ChipGraade = strChipGraade(2)
        MyUpdataGUIEQGXUnload.strEQ3ChipGraade = strChipGraade(3)
        MyUpdataGUIEQGXUnload.strEQ1GxID = strGxID(1)
        MyUpdataGUIEQGXUnload.strEQ2GxID = strGxID(2)
        MyUpdataGUIEQGXUnload.strEQ3GxID = strGxID(3)
        MyUpdataGUIEQGXUnload.nEQ1ProcessResult = nProcessRes(1)
        MyUpdataGUIEQGXUnload.nEQ2ProcessResult = nProcessRes(2)
        MyUpdataGUIEQGXUnload.nEQ3ProcessResult = nProcessRes(3)
        MyUpdataGUIEQGXUnload.strEQ1PSH = strPSH(1)
        MyUpdataGUIEQGXUnload.strEQ2PSH = strPSH(2)
        MyUpdataGUIEQGXUnload.strEQ3PSH = strPSH(3)
        MyUpdataGUIEQGXUnload.nEQ1SampleGxFl = nSampleGxFl(1)
        MyUpdataGUIEQGXUnload.nEQ2SampleGxFl = nSampleGxFl(2)
        MyUpdataGUIEQGXUnload.nEQ3SampleGxFl = nSampleGxFl(3)
        MyUpdataGUIEQGXUnload.nEQ1SlotInfo = nSlotInfo(1)
        MyUpdataGUIEQGXUnload.nEQ2SlotInfo = nSlotInfo(2)
        MyUpdataGUIEQGXUnload.nEQ3SlotInfo = nSlotInfo(3)

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
        Me.cmdRBTBusy.BackColor = BackColorForSignalOFF
        Me.cmdTRRequest.BackColor = BackColorForSignalOFF
        Me.cmdTRResetReq.BackColor = BackColorForSignalOFF
        Me.cmdUnloadComp.BackColor = BackColorForSignalOFF



        Me.lblSignalEQReady.BackColor = BackColorForSignalOFF
        Me.lblSignalUnloadReq.BackColor = BackColorForSignalOFF
        Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF
        Me.lblWChipGraade.Text = ""
        Me.lblWGxID.Text = ""
        Me.lblWProcessResult.Text = ""
        Me.lblWPSH.Text = ""
        Me.lblWSlotInfo.Text = ""
        Me.lblWSlotInfo.Text = ""
        Me.lblWGxID.Text = ""
    End Sub

    Private Sub cmdTRRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRRequest.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("028")
            Case "1"
                RaiseEvent RSTSignalClick("0A8")
            Case "2"
                RaiseEvent RSTSignalClick("128")
        End Select
    End Sub

    Private Sub cmdRBTBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBTBusy.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("029")
            Case "1"
                RaiseEvent RSTSignalClick("0A98")
            Case "2"
                RaiseEvent RSTSignalClick("129")
        End Select
    End Sub

    Private Sub cmdUnloadComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnloadComp.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("02A")
            Case "1"
                RaiseEvent RSTSignalClick("0AA")
            Case "2"
                RaiseEvent RSTSignalClick("12A")
        End Select
    End Sub

    Private Sub cmdTRResetReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRResetReq.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("042")
            Case "1"
                RaiseEvent RSTSignalClick("0C2")
            Case "2"
                RaiseEvent RSTSignalClick("142")
        End Select
    End Sub

    Public Sub ShowGUIEQGxUnload()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.lblWChipGraade.Text = MyUpdataGUIEQGXUnload.strEQ1ChipGraade
                Me.lblWGxID.Text = MyUpdataGUIEQGXUnload.strEQ1GxID
                Me.lblWProcessResult.Text = MyUpdataGUIEQGXUnload.nEQ1ProcessResult
                Me.lblWPSH.Text = MyUpdataGUIEQGXUnload.strEQ1PSH
                Me.lblWSampleGxFlag.Text = MyUpdataGUIEQGXUnload.nEQ1SampleGxFl
                Me.lblWSlotInfo.Text = MyUpdataGUIEQGXUnload.nEQ1SlotInfo
            Case 2
                Me.lblWChipGraade.Text = MyUpdataGUIEQGXUnload.strEQ2ChipGraade
                Me.lblWGxID.Text = MyUpdataGUIEQGXUnload.strEQ2GxID
                Me.lblWProcessResult.Text = MyUpdataGUIEQGXUnload.nEQ2ProcessResult
                Me.lblWPSH.Text = MyUpdataGUIEQGXUnload.strEQ2PSH
                Me.lblWSampleGxFlag.Text = MyUpdataGUIEQGXUnload.nEQ2SampleGxFl
                Me.lblWSlotInfo.Text = MyUpdataGUIEQGXUnload.nEQ2SlotInfo
            Case 3
                Me.lblWChipGraade.Text = MyUpdataGUIEQGXUnload.strEQ3ChipGraade
                Me.lblWGxID.Text = MyUpdataGUIEQGXUnload.strEQ3GxID
                Me.lblWProcessResult.Text = MyUpdataGUIEQGXUnload.nEQ3ProcessResult
                Me.lblWPSH.Text = MyUpdataGUIEQGXUnload.strEQ3PSH
                Me.lblWSampleGxFlag.Text = MyUpdataGUIEQGXUnload.nEQ3SampleGxFl
                Me.lblWSlotInfo.Text = MyUpdataGUIEQGXUnload.nEQ3SlotInfo
        End Select
    End Sub
End Class
