Imports System.Drawing
Public Class OcxGxExchange
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
            Case "30", "B0", "130"
                If nOnOff = 1 Then
                    Me.cmdTRRequest.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRRequest.BackColor = BackColorForSignalOFF
                End If
            Case "31", "B1", "131"
                If nOnOff = 1 Then
                    Me.cmdRBTGetBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBTGetBusy.BackColor = BackColorForSignalOFF
                End If
            Case "32", "B2", "132"
                If nOnOff = 1 Then
                    Me.cmdRBTPutBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBTPutBusy.BackColor = BackColorForSignalOFF
                End If
            Case "33", "B3", "133"
                If nOnOff = 1 Then
                    Me.cmdExchangeComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdExchangeComp.BackColor = BackColorForSignalOFF
                End If
            Case "34", "B4", "134"
                If nOnOff = 1 Then
                    Me.cmdExchangeStatus.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdExchangeStatus.BackColor = BackColorForSignalOFF
                End If
            Case "42", "C2", "142"
                If nOnOff = 1 Then
                    Me.cmdTRReset.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRReset.BackColor = BackColorForSignalOFF
                End If
            Case "330", "730", "1030"
                If nOnOff = 1 Then
                    Me.lblSignalExchangeReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalExchangeReq.BackColor = BackColorForSignalOFF
                End If
            Case "331", "731", "1031"
                If nOnOff = 1 Then
                    Me.lblSignalEQReady.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalEQReady.BackColor = BackColorForSignalOFF
                End If
            Case "342", "742", "1042"
                If nOnOff = 1 Then
                    Me.lblSignalTRRresetAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalTRRresetAck.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordDataRST(Optional ByVal strCSTID As String = "", Optional ByVal strCurrentRecipe As String = "", Optional ByVal strDMQCGrade As String = "", Optional ByVal strEPPID As String = "", Optional ByVal strGxGrade As String = "", Optional ByVal strGxID As String = "", Optional ByVal strGxScrapFlag As String = "", Optional ByVal strMESID As String = "", Optional ByVal strMPAFlag As String = "", Optional ByVal strOperationID As String = "", Optional ByVal strPLineID As String = "", Optional ByVal strPoperID As String = "", Optional ByVal strProductCategory As String = "", Optional ByVal strProductCode As String = "", Optional ByVal strPToolID As String = "", Optional ByVal strSampleGxFlag As String = "", Optional ByVal strSlotInfo As String = "")
        'Me.txtCSTID.Text = strCSTID
        'Me.txtCurrentRecipe.Text = strCurrentRecipe
        'Me.txtDMQCGrade.Text = strDMQCGrade
        'Me.txtEPPID.Text = strEPPID
        'Me.txtGxGrade.Text = strGxGrade
        'Me.txtGxID.Text = strGxID
        'Me.txtGxScrapFlag.Text = strGxScrapFlag
        'Me.txtMESID.Text = strMESID
        'Me.txtMPAFlag.Text = strMPAFlag
        'Me.txtOperationID.Text = strOperationID
        'Me.txtPLineID.Text = strPLineID
        'Me.txtPoperID.Text = strPoperID
        'Me.txtProductCategory.Text = strProductCategory
        'Me.txtProductCode.Text = strProductCode
        'Me.txtPToolID.Text = strPToolID
        'Me.txtSampleGxFlag.Text = strSampleGxFlag
        'Me.txtSlotInfo.Text = strSlotInfo
    End Sub

    Public Sub SetWordDataEQ(Optional ByVal strChipGraade As String = "", Optional ByVal strGxID As String = "", Optional ByVal strProcessRes As String = "", Optional ByVal strPSH As String = "", Optional ByVal strSampleGxFl As String = "", Optional ByVal strSlotInfo As String = "")
        Me.lblWChipGraade.Text = strChipGraade
        Me.lblWGxID.Text = strGxID
        Me.lblWProcessResult.Text = strProcessRes
        Me.lblWPSH.Text = strPSH
        Me.lblWSampleGxFlag.Text = strSampleGxFl
        Me.lblWSlotInfo.Text = strSlotInfo
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
        Me.cmdExchangeComp.BackColor = BackColorForSignalOFF
        Me.cmdExchangeStatus.BackColor = BackColorForSignalOFF
        Me.cmdRBTGetBusy.BackColor = BackColorForSignalOFF
        Me.cmdRBTPutBusy.BackColor = BackColorForSignalOFF
        Me.cmdTRRequest.BackColor = BackColorForSignalOFF
        Me.txtCSTID.Text = ""
        Me.txtCurrentRecipe.Text = ""
        Me.txtDMQCGrade.Text = ""
        Me.txtEPPID.Text = ""
        Me.txtGxGrade.Text = ""
        Me.txtGxID.Text = ""
        Me.txtGxScrapFlag.Text = ""
        Me.txtMESID.Text = ""
        Me.txtMPAFlag.Text = ""
        Me.txtOperationID.Text = ""
        Me.txtPLineID.Text = ""
        Me.txtPoperID.Text = ""
        Me.txtProductCategory.Text = ""
        Me.txtProductCode.Text = ""
        Me.txtPToolID.Text = ""
        Me.txtSampleGxFlag.Text = ""
        Me.txtSlotInfo.Text = ""

        Me.lblSignalEQReady.BackColor = BackColorForSignalOFF
        Me.lblSignalExchangeReq.BackColor = BackColorForSignalOFF
        Me.lblSignalTRRresetAck.BackColor = BackColorForSignalOFF

        Me.lblWSampleGxFlag.Text = ""
        Me.lblWSlotInfo.Text = ""
        Me.lblWProcessResult.Text = ""
        Me.lblWPSH.Text = ""
        Me.lblWGxID.Text = ""
        Me.lblWChipGraade.Text = ""
    End Sub

    Private Sub cmdTRRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRRequest.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("030")
            Case "1"
                RaiseEvent RSTSignalClick("0B0")
            Case "2"
                RaiseEvent RSTSignalClick("130")
        End Select
    End Sub

    Private Sub cmdRBTGetBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBTGetBusy.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("031")
            Case "1"
                RaiseEvent RSTSignalClick("0B1")
            Case "2"
                RaiseEvent RSTSignalClick("131")
        End Select
    End Sub

    Private Sub cmdRBTPutBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBTPutBusy.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("032")
            Case "1"
                RaiseEvent RSTSignalClick("0B2")
            Case "2"
                RaiseEvent RSTSignalClick("132")
        End Select
    End Sub

    Private Sub cmdExchangeComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExchangeComp.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("033")
            Case "1"
                RaiseEvent RSTSignalClick("0B3")
            Case "2"
                RaiseEvent RSTSignalClick("133")
        End Select
    End Sub

    Private Sub cmdExchangeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExchangeStatus.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("034")
            Case "1"
                RaiseEvent RSTSignalClick("0B4")
            Case "2"
                RaiseEvent RSTSignalClick("134")
        End Select
    End Sub

    Private Sub cmdTRReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRReset.Click
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

    Public Sub ShowGUIEQGxExChange()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.txtCSTID.Text = MyUpdataGUIEQGXLoad.strEQ1CSTID
                Me.txtCurrentRecipe.Text = MyUpdataGUIEQGXLoad.strEQ1CurrentRecipe
                Me.txtDMQCGrade.Text = MyUpdataGUIEQGXLoad.strEQ1DMQCGrade
                Me.txtEPPID.Text = MyUpdataGUIEQGXLoad.strEQ1EPPID
                Me.txtGxGrade.Text = MyUpdataGUIEQGXLoad.strEQ1GxGrade
                Me.txtGxID.Text = MyUpdataGUIEQGXLoad.strEQ1GxID
                Me.txtGxScrapFlag.Text = MyUpdataGUIEQGXLoad.strEQ1GxScrapFlag
                Me.txtMESID.Text = MyUpdataGUIEQGXLoad.strEQ1MESID
                Me.txtMPAFlag.Text = MyUpdataGUIEQGXLoad.nEQ1MPAFlag
                Me.txtOperationID.Text = MyUpdataGUIEQGXLoad.strEQ1OperationID
                Me.txtPLineID.Text = MyUpdataGUIEQGXLoad.strEQ1PLineID
                Me.txtPoperID.Text = MyUpdataGUIEQGXLoad.strEQ1PoperID
                Me.txtProductCategory.Text = MyUpdataGUIEQGXLoad.nEQ1ProductCategory
                Me.txtProductCode.Text = MyUpdataGUIEQGXLoad.strEQ1ProductCode
                Me.txtPToolID.Text = MyUpdataGUIEQGXLoad.strEQ1PToolID
                Me.txtSampleGxFlag.Text = MyUpdataGUIEQGXLoad.nEQ1SampleGxFlag
                Me.txtSlotInfo.Text = MyUpdataGUIEQGXLoad.nEQ1SlotInfo

                Me.lblWSampleGxFlag.Text = MyUpdataGUIEQGXUnload.nEQ1SampleGxFl
                Me.lblWSlotInfo.Text = MyUpdataGUIEQGXUnload.nEQ1SlotInfo
                Me.lblWProcessResult.Text = MyUpdataGUIEQGXUnload.nEQ1ProcessResult
                Me.lblWPSH.Text = MyUpdataGUIEQGXUnload.strEQ1PSH
                Me.lblWGxID.Text = MyUpdataGUIEQGXUnload.strEQ1GxID
                Me.lblWChipGraade.Text = MyUpdataGUIEQGXUnload.strEQ1ChipGraade
            Case 2
                Me.txtCSTID.Text = MyUpdataGUIEQGXLoad.strEQ2CSTID
                Me.txtCurrentRecipe.Text = MyUpdataGUIEQGXLoad.strEQ2CurrentRecipe
                Me.txtDMQCGrade.Text = MyUpdataGUIEQGXLoad.strEQ2DMQCGrade
                Me.txtEPPID.Text = MyUpdataGUIEQGXLoad.strEQ2EPPID
                Me.txtGxGrade.Text = MyUpdataGUIEQGXLoad.strEQ2GxGrade
                Me.txtGxID.Text = MyUpdataGUIEQGXLoad.strEQ2GxID
                Me.txtGxScrapFlag.Text = MyUpdataGUIEQGXLoad.strEQ2GxScrapFlag
                Me.txtMESID.Text = MyUpdataGUIEQGXLoad.strEQ2MESID
                Me.txtMPAFlag.Text = MyUpdataGUIEQGXLoad.nEQ2MPAFlag
                Me.txtOperationID.Text = MyUpdataGUIEQGXLoad.strEQ2OperationID
                Me.txtPLineID.Text = MyUpdataGUIEQGXLoad.strEQ2PLineID
                Me.txtPoperID.Text = MyUpdataGUIEQGXLoad.strEQ2PoperID
                Me.txtProductCategory.Text = MyUpdataGUIEQGXLoad.nEQ2ProductCategory
                Me.txtProductCode.Text = MyUpdataGUIEQGXLoad.strEQ2ProductCode
                Me.txtPToolID.Text = MyUpdataGUIEQGXLoad.strEQ2PToolID
                Me.txtSampleGxFlag.Text = MyUpdataGUIEQGXLoad.nEQ2SampleGxFlag
                Me.txtSlotInfo.Text = MyUpdataGUIEQGXLoad.nEQ2SlotInfo

                Me.lblWSampleGxFlag.Text = MyUpdataGUIEQGXUnload.nEQ2SampleGxFl
                Me.lblWSlotInfo.Text = MyUpdataGUIEQGXUnload.nEQ2SlotInfo
                Me.lblWProcessResult.Text = MyUpdataGUIEQGXUnload.nEQ2ProcessResult
                Me.lblWPSH.Text = MyUpdataGUIEQGXUnload.strEQ2PSH
                Me.lblWGxID.Text = MyUpdataGUIEQGXUnload.strEQ2GxID
                Me.lblWChipGraade.Text = MyUpdataGUIEQGXUnload.strEQ2ChipGraade
            Case 3
                Me.txtCSTID.Text = MyUpdataGUIEQGXLoad.strEQ3CSTID
                Me.txtCurrentRecipe.Text = MyUpdataGUIEQGXLoad.strEQ3CurrentRecipe
                Me.txtDMQCGrade.Text = MyUpdataGUIEQGXLoad.strEQ3DMQCGrade
                Me.txtEPPID.Text = MyUpdataGUIEQGXLoad.strEQ3EPPID
                Me.txtGxGrade.Text = MyUpdataGUIEQGXLoad.strEQ3GxGrade
                Me.txtGxID.Text = MyUpdataGUIEQGXLoad.strEQ3GxID
                Me.txtGxScrapFlag.Text = MyUpdataGUIEQGXLoad.strEQ3GxScrapFlag
                Me.txtMESID.Text = MyUpdataGUIEQGXLoad.strEQ3MESID
                Me.txtMPAFlag.Text = MyUpdataGUIEQGXLoad.nEQ3MPAFlag
                Me.txtOperationID.Text = MyUpdataGUIEQGXLoad.strEQ3OperationID
                Me.txtPLineID.Text = MyUpdataGUIEQGXLoad.strEQ3PLineID
                Me.txtPoperID.Text = MyUpdataGUIEQGXLoad.strEQ3PoperID
                Me.txtProductCategory.Text = MyUpdataGUIEQGXLoad.nEQ3ProductCategory
                Me.txtProductCode.Text = MyUpdataGUIEQGXLoad.strEQ3ProductCode
                Me.txtPToolID.Text = MyUpdataGUIEQGXLoad.strEQ3PToolID
                Me.txtSampleGxFlag.Text = MyUpdataGUIEQGXLoad.nEQ3SampleGxFlag
                Me.txtSlotInfo.Text = MyUpdataGUIEQGXLoad.nEQ3SlotInfo

                Me.lblWSampleGxFlag.Text = MyUpdataGUIEQGXUnload.nEQ3SampleGxFl
                Me.lblWSlotInfo.Text = MyUpdataGUIEQGXUnload.nEQ3SlotInfo
                Me.lblWProcessResult.Text = MyUpdataGUIEQGXUnload.nEQ3ProcessResult
                Me.lblWPSH.Text = MyUpdataGUIEQGXUnload.strEQ3PSH
                Me.lblWGxID.Text = MyUpdataGUIEQGXUnload.strEQ3GxID
                Me.lblWChipGraade.Text = MyUpdataGUIEQGXUnload.strEQ3ChipGraade
        End Select
    End Sub
End Class
