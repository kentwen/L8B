Public Class OcxAlarmMonitor
    Private mvarSignalONColor As System.Drawing.Color
    Private mvarSignalOFFColor As System.Drawing.Color
    Private mvarAlarmSignal(512) As Integer

    Private Sub IniAlarmIndex()
        Dim nAlarmIdx As Integer
        Dim nTabIdx As Integer
        Dim MyLabCap As Object
        Dim nLblIndex As Integer = 0
        nTabIdx = Me.TabControl1.SelectedIndex


        For Each MyLabCap In Me.Controls
            nLblIndex = nLblIndex + 1
            If Mid(MyLabCap.name, 1, 5) = "Label" Then
                nAlarmIdx = CInt(Mid(MyLabCap.name, 6) + (50 * nTabIdx))
                If nAlarmIdx <= 512 Then
                    MyLabCap.text = "Alarm Exist-" & nAlarmIdx
                    MyLabCap.Visible = True
                    SetLabelOnOFF(CInt(Mid(MyLabCap.name, 6)), mvarAlarmSignal(nAlarmIdx))

                Else
                    MyLabCap.Visible = False
                End If
            End If
        Next
    End Sub

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        If strSignalID = "" Then strSignalID = 0

        mvarAlarmSignal(CInt(strSignalID)) = nOnOff
    End Sub

    Public Sub ShowAlarm()

        IniAlarmIndex()
    End Sub

    Private Sub SetLabelOnOFF(ByVal nLabelIdx As Integer, ByVal nOnOff As Integer)
        Dim Myobj As Object

        For Each Myobj In Me.Controls
            If Myobj.name = "Label" & nLabelIdx Then
                If nOnOff = 1 Then
                    Myobj.BackColor = BackColorForSignalON
                Else
                    Myobj.BackColor = BackColorForSignalOFF
                End If
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


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        IniAlarmIndex()
    End Sub

    Public Sub New()
        'Dim nFor As Integer
        'For nFor = 1 To 512
        '    mvarAlarmSignal(nFor) = 1
        'Next

        BackColorForSignalON = Color.Blue

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        IniAlarmIndex()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabIndexChanged
        IniAlarmIndex()
    End Sub
End Class
