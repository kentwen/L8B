Imports System.Drawing

Public Class OcxPPIDChk
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
            Case "45", "C5", "145"
                If nOnOff = 1 Then
                    Me.cmdEPPIDChkReq.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdEPPIDChkReq.BackColor = BackColorForSignalOFF
                End If
            Case "345", "745", "1045"
                If nOnOff = 1 Then
                    Me.lblSignalEPPIDChkAck.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalEPPIDChkAck.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal strEPPID() As String, ByVal nCheckResult() As Integer)
        MyUpdataGUIEQRecipeCheck.strEQ1EPPID = strEPPID(1)
        MyUpdataGUIEQRecipeCheck.strEQ2EPPID = strEPPID(2)
        MyUpdataGUIEQRecipeCheck.strEQ3EPPID = strEPPID(3)
        MyUpdataGUIEQRecipeCheck.nEQ1CheckResult = nCheckResult(1)
        MyUpdataGUIEQRecipeCheck.nEQ2CheckResult = nCheckResult(2)
        MyUpdataGUIEQRecipeCheck.nEQ3CheckResult = nCheckResult(3)
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
        Me.lblSignalEPPIDChkAck.BackColor = BackColorForSignalOFF
        Me.cmdEPPIDChkReq.BackColor = BackColorForSignalOFF
        Me.txtEPPID.Text = ""
        Me.lblWCheckResult.Text = ""
    End Sub

    Private Sub cmdEPPIDChkReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEPPIDChkReq.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("045")
            Case "1"
                RaiseEvent RSTSignalClick("0C5")
            Case "2"
                RaiseEvent RSTSignalClick("145")
        End Select
    End Sub

    Public Sub ShowGUIEQRecipeCheck()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.txtEPPID.Text = MyUpdataGUIEQRecipeCheck.strEQ1EPPID
                Me.lblWCheckResult.Text = MyUpdataGUIEQRecipeCheck.nEQ1CheckResult
            Case 2
                Me.txtEPPID.Text = MyUpdataGUIEQRecipeCheck.strEQ2EPPID
                Me.lblWCheckResult.Text = MyUpdataGUIEQRecipeCheck.nEQ2CheckResult
            Case 3
                Me.txtEPPID.Text = MyUpdataGUIEQRecipeCheck.strEQ3EPPID
                Me.lblWCheckResult.Text = MyUpdataGUIEQRecipeCheck.nEQ3CheckResult
        End Select
    End Sub

End Class
