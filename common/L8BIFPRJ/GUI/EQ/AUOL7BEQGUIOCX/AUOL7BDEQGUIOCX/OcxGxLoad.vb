Imports System.Drawing
Public Class OcxGxLoad
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
            Case "20", "A0", "120"
                If nOnOff = 1 Then
                    Me.cmdTRRequest.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRRequest.BackColor = BackColorForSignalOFF
                End If
            Case "21", "A1", "121"
                If nOnOff = 1 Then
                    Me.cmdRBTBusy.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdRBTBusy.BackColor = BackColorForSignalOFF
                End If
            Case "22", "A2", "122"
                If nOnOff = 1 Then
                    Me.cmdLoadComp.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdLoadComp.BackColor = BackColorForSignalOFF
                End If
            Case "42", "C2", "142"
                If nOnOff = 1 Then
                    Me.cmdTRResetReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdTRResetReq.BackColor = BackColorForSignalOFF
                End If
            Case "320", "720", "1020"
                If nOnOff = 1 Then
                    Me.lblSignalLoadReq.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalLoadReq.BackColor = BackColorForSignalOFF
                End If
            Case "321", "721", "1021"
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

    Public Sub SetWordData(ByVal strCSTID() As String, ByVal strCurrentRecipe() As String, ByVal strDMQCGrade() As String, ByVal strEPPID() As String, ByVal strGxGrade() As String, ByVal strGxID() As String, ByVal strGxScrapFlag() As String, ByVal strMESID() As String, ByVal nMPAFlag() As Integer, ByVal strOperationID() As String, ByVal strPLineID() As String, ByVal strPoperID() As String, ByVal nProductCategory() As Integer, ByVal strProductCode() As String, ByVal strPToolID() As String, ByVal nSampleGxFlag() As Integer, ByVal nSlotInfo() As Integer)
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

        MyUpdataGUIEQGXLoad.strEQ1CSTID = strCSTID(1)
        MyUpdataGUIEQGXLoad.strEQ2CSTID = strCSTID(2)
        MyUpdataGUIEQGXLoad.strEQ3CSTID = strCSTID(3)
        MyUpdataGUIEQGXLoad.strEQ1CurrentRecipe = strCurrentRecipe(1)
        MyUpdataGUIEQGXLoad.strEQ2CurrentRecipe = strCurrentRecipe(2)
        MyUpdataGUIEQGXLoad.strEQ3CurrentRecipe = strCurrentRecipe(3)
        MyUpdataGUIEQGXLoad.strEQ1DMQCGrade = strDMQCGrade(1)
        MyUpdataGUIEQGXLoad.strEQ2DMQCGrade = strDMQCGrade(2)
        MyUpdataGUIEQGXLoad.strEQ3DMQCGrade = strDMQCGrade(3)
        MyUpdataGUIEQGXLoad.strEQ1EPPID = strEPPID(1)
        MyUpdataGUIEQGXLoad.strEQ2EPPID = strEPPID(2)
        MyUpdataGUIEQGXLoad.strEQ3EPPID = strEPPID(3)
        MyUpdataGUIEQGXLoad.strEQ1GxGrade = strGxGrade(1)
        MyUpdataGUIEQGXLoad.strEQ2GxGrade = strGxGrade(2)
        MyUpdataGUIEQGXLoad.strEQ3GxGrade = strGxGrade(3)
        MyUpdataGUIEQGXLoad.strEQ1GxID = strGxID(1)
        MyUpdataGUIEQGXLoad.strEQ2GxID = strGxID(2)
        MyUpdataGUIEQGXLoad.strEQ3GxID = strGxID(3)
        MyUpdataGUIEQGXLoad.strEQ1GxScrapFlag = strGxScrapFlag(1)
        MyUpdataGUIEQGXLoad.strEQ2GxScrapFlag = strGxScrapFlag(2)
        MyUpdataGUIEQGXLoad.strEQ3GxScrapFlag = strGxScrapFlag(3)
        MyUpdataGUIEQGXLoad.strEQ1MESID = strMESID(1)
        MyUpdataGUIEQGXLoad.strEQ2MESID = strMESID(2)
        MyUpdataGUIEQGXLoad.strEQ3MESID = strMESID(3)
        MyUpdataGUIEQGXLoad.nEQ1MPAFlag = nMPAFlag(1)
        MyUpdataGUIEQGXLoad.nEQ2MPAFlag = nMPAFlag(2)
        MyUpdataGUIEQGXLoad.nEQ3MPAFlag = nMPAFlag(3)
        MyUpdataGUIEQGXLoad.strEQ1OperationID = strOperationID(1)
        MyUpdataGUIEQGXLoad.strEQ2OperationID = strOperationID(2)
        MyUpdataGUIEQGXLoad.strEQ3OperationID = strOperationID(3)
        MyUpdataGUIEQGXLoad.strEQ1PLineID = strPLineID(1)
        MyUpdataGUIEQGXLoad.strEQ2PLineID = strPLineID(2)
        MyUpdataGUIEQGXLoad.strEQ3PLineID = strPLineID(3)
        MyUpdataGUIEQGXLoad.strEQ1PoperID = strPoperID(1)
        MyUpdataGUIEQGXLoad.strEQ2PoperID = strPoperID(2)
        MyUpdataGUIEQGXLoad.strEQ3PoperID = strPoperID(3)
        MyUpdataGUIEQGXLoad.nEQ1ProductCategory = nProductCategory(1)
        MyUpdataGUIEQGXLoad.nEQ2ProductCategory = nProductCategory(2)
        MyUpdataGUIEQGXLoad.nEQ3ProductCategory = nProductCategory(3)
        MyUpdataGUIEQGXLoad.strEQ1ProductCode = strProductCode(1)
        MyUpdataGUIEQGXLoad.strEQ2ProductCode = strProductCode(2)
        MyUpdataGUIEQGXLoad.strEQ3ProductCode = strProductCode(3)
        MyUpdataGUIEQGXLoad.strEQ1PToolID = strPToolID(1)
        MyUpdataGUIEQGXLoad.strEQ2PToolID = strPToolID(2)
        MyUpdataGUIEQGXLoad.strEQ3PToolID = strPToolID(3)
        MyUpdataGUIEQGXLoad.nEQ1SampleGxFlag = nSampleGxFlag(1)
        MyUpdataGUIEQGXLoad.nEQ2SampleGxFlag = nSampleGxFlag(2)
        MyUpdataGUIEQGXLoad.nEQ3SampleGxFlag = nSampleGxFlag(3)
        MyUpdataGUIEQGXLoad.nEQ1SlotInfo = nSlotInfo(1)
        MyUpdataGUIEQGXLoad.nEQ2SlotInfo = nSlotInfo(2)
        MyUpdataGUIEQGXLoad.nEQ3SlotInfo = nSlotInfo(3)

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
        Me.cmdLoadComp.BackColor = BackColorForSignalOFF
        Me.cmdRBTBusy.BackColor = BackColorForSignalOFF
        Me.cmdTRRequest.BackColor = BackColorForSignalOFF
        Me.cmdTRResetReq.BackColor = BackColorForSignalOFF
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
        Me.lblSignalLoadReq.BackColor = BackColorForSignalOFF
        Me.lblSignalTRResetAck.BackColor = BackColorForSignalOFF

    End Sub

    Private Sub cmdTRRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTRRequest.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("020")
            Case "1"
                RaiseEvent RSTSignalClick("0A0")
            Case "2"
                RaiseEvent RSTSignalClick("120")
        End Select
    End Sub

    Private Sub cmdRBTBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRBTBusy.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("021")
            Case "1"
                RaiseEvent RSTSignalClick("0A1")
            Case "2"
                RaiseEvent RSTSignalClick("121")
        End Select
    End Sub

    Private Sub cmdLoadComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadComp.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex

        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("022")
            Case "1"
                RaiseEvent RSTSignalClick("0A2")
            Case "2"
                RaiseEvent RSTSignalClick("122")
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

    Public Sub ShowGUIEQGxLoad()
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
        End Select
    End Sub
End Class
