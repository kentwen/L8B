Imports System.Drawing 
Public Class OcxPPIDModify
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
            Case "40", "C0", "140"
                If nOnOff = 1 Then
                    Me.cmdEPPIDModifyAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdEPPIDModifyAck.BackColor = BackColorForSignalOFF
                End If
            Case "340", "740", "1040"
                If nOnOff = 1 Then
                    Me.lblSignalEPPIDModifyReport.BackColor = BackColorForCVSignalON
                Else
                    Me.lblSignalEPPIDModifyReport.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal strEPPID() As String, ByVal nModifyType() As Integer)
        MyUpdataGUIEQRecipeModify.strEQ1EPPID = strEPPID(1)
        MyUpdataGUIEQRecipeModify.strEQ2EPPID = strEPPID(2)
        MyUpdataGUIEQRecipeModify.strEQ3EPPID = strEPPID(3)
        MyUpdataGUIEQRecipeModify.nEQ1ModifyType = nModifyType(1)
        MyUpdataGUIEQRecipeModify.nEQ2ModifyType = nModifyType(2)
        MyUpdataGUIEQRecipeModify.nEQ3ModifyType = nModifyType(3)
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
        Me.lblSignalEPPIDModifyReport.BackColor = BackColorForSignalOFF
        Me.cmdEPPIDModifyAck.BackColor = BackColorForSignalOFF
        Me.lblWEPPID.Text = ""
        Me.lblWModifyType.Text = ""
    End Sub

    Private Sub cmdEPPIDModifyAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEPPIDModifyAck.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("040")
            Case "1"
                RaiseEvent RSTSignalClick("0C0")
            Case "2"
                RaiseEvent RSTSignalClick("140")
        End Select
    End Sub

    Public Sub ShowGUIEQRecipeModify()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.lblWEPPID.Text = MyUpdataGUIEQRecipeModify.strEQ1EPPID
                Me.lblWModifyType.Text = MyUpdataGUIEQRecipeModify.nEQ1ModifyType
            Case 2
                Me.lblWEPPID.Text = MyUpdataGUIEQRecipeModify.strEQ2EPPID
                Me.lblWModifyType.Text = MyUpdataGUIEQRecipeModify.nEQ2ModifyType
            Case 3
                Me.lblWEPPID.Text = MyUpdataGUIEQRecipeModify.strEQ3EPPID
                Me.lblWModifyType.Text = MyUpdataGUIEQRecipeModify.nEQ3ModifyType
        End Select
    End Sub
End Class
