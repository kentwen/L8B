Imports System.Drawing

Public Class AlarmSignal
    Private mvarSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color

    Private Sub AlarmSignal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = Me.Label512.Top + Label512.Height
    End Sub

    Public Sub IniAlarmIndex()
        Dim MyLabCap As Object
        Dim nLblIndex As Integer = 0

        For Each MyLabCap In Me.Controls
            nLblIndex = nLblIndex + 1
            If Mid(MyLabCap.name, 1, 5) = "Label" Then
                MyLabCap.text = "Alarm Exist-" & Mid(MyLabCap.name, 6)
            End If
        Next
    End Sub

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Dim objTemp As Object

        For Each objTemp In Me.Controls
            If objTemp.Name = "Label" & CStr(strSignalID) Then
                If nOnOff = 1 Then
                    objTemp.BackColor = BackColorForSignalON                     
                Else
                    objTemp.BackColor = BackColorForSignalOFF
                End If
                Exit For
            End If
        Next
    End Sub

    Public Property BackColorForSignalON() As System.Drawing.Color
        Get
            BackColorForSignalON = mvarSignalONColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSignalONColor = value
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

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        IniAlarmIndex()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class
