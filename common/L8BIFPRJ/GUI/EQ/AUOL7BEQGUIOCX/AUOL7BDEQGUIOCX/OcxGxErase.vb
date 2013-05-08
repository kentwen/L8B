Imports System.Drawing
Public Class OcxGxErase
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
            Case "43", "C3", "143"
                If nOnOff = 1 Then
                    Me.cmdGxEraseAck.BackColor = BackColorForRSTSignalON
                Else
                    Me.cmdGxEraseAck.BackColor = BackColorForSignalOFF
                End If
            Case "343", "743", "1043"
                If nOnOff = 1 Then
                    Me.llbSignalGxEraseReport.BackColor = BackColorForCVSignalON
                Else
                    Me.llbSignalGxEraseReport.BackColor = BackColorForSignalOFF
                End If
        End Select
    End Sub

    Public Sub SetWordData(ByVal strCxTID() As String)
        MyUpdataGUIEQGxErase.strEQ1GxID = strCxTID(1)
        MyUpdataGUIEQGxErase.strEQ2GxID = strCxTID(2)
        MyUpdataGUIEQGxErase.strEQ3GxID = strCxTID(3)
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
        Me.llbSignalGxEraseReport.BackColor = BackColorForSignalOFF
        Me.cmdGxEraseAck.BackColor = BackColorForSignalOFF
        Me.lblWGxID.Text = ""
    End Sub

    Private Sub cmdGxEraseAck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGxEraseAck.Click
        Dim nConvertPortIndex As Integer
        If Not mvarENGType Then Exit Sub

        nConvertPortIndex = TabControl1.SelectedIndex
        Select Case nConvertPortIndex
            Case "0"
                RaiseEvent RSTSignalClick("043")
            Case "1"
                RaiseEvent RSTSignalClick("0C3")
            Case "2"
                RaiseEvent RSTSignalClick("143")
        End Select
    End Sub

    Public Sub ShowGUIEQGlassErase()
        Dim nConvertPortIndex As Integer

        nConvertPortIndex = TabControl1.SelectedIndex + 1

        Select Case nConvertPortIndex
            Case 1
                Me.lblWGxID.Text = MyUpdataGUIEQGxErase.strEQ1GxID
            Case 2
                Me.lblWGxID.Text = MyUpdataGUIEQGxErase.strEQ2GxID
            Case 3
                Me.lblWGxID.Text = MyUpdataGUIEQGxErase.strEQ3GxID
        End Select
    End Sub
End Class
