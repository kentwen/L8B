Imports System.Drawing
Public Class PortStatus
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


    'Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
    '    Select Case strSignalID
    '        Case "1302", "1303", "1304", "1305", "1306"
    '            Me.txtPort1OKGx.Text = nOnOff
    '        Case "1307", "1307", "1309", "130A", "130B"
    '            Me.txtPort1NGGx.Text = nOnOff
    '        Case "130C", "130D", "130E", "130F", "1310"
    '            Me.txtPort1MixGx.Text = nOnOff
    '        Case "1311", "1312", "1313", "1314", "1315"
    '            Me.txtPort1GrayGx.Text = nOnOff
    '        Case "1316", "1317", "1318", "1319", "131A"
    '            Me.txtPort1CSTExist.Text = nOnOff
    '        Case "131B", "131C", "131D", "131E", "131F"
    '            Me.txtPort1PortDisable.Text = nOnOff
    '        Case "1320", "1321", "1322", "1323", "1324"
    '            Me.txtPort1VCREnable.Text = nOnOff
    '    End Select
    'End Sub

    Public Sub SetSignalOnOff(ByVal strSignalID As String, ByVal nOnOff As Integer)
        Select Case strSignalID
            Case "1302"
                Me.txtPort1OKGx.Text = nOnOff
            Case "1303"
                Me.txtPort2OKGx.Text = nOnOff
            Case "1304"
                Me.txtPort3OKGx.Text = nOnOff
            Case "1305"
                Me.txtPort4OKGx.Text = nOnOff
            Case "1306"
                Me.txtPort5OKGx.Text = nOnOff
            Case "1307"
                Me.txtPort1NGGx.Text = nOnOff
            Case "1308"
                Me.txtPort2NGGx.Text = nOnOff
            Case "1309"
                Me.txtPort3NGGx.Text = nOnOff
            Case "130A"
                Me.txtPort4NGGx.Text = nOnOff
            Case "130B"
                Me.txtPort5NGGx.Text = nOnOff
            Case "130C"
                Me.txtPort1MixGx.Text = nOnOff
            Case "130D"
                Me.txtPort2MixGx.Text = nOnOff
            Case "130E"
                Me.txtPort3MixGx.Text = nOnOff
            Case "130F"
                Me.txtPort4MixGx.Text = nOnOff
            Case "1310"
                Me.txtPort5MixGx.Text = nOnOff
            Case "1311"
                Me.txtPort1GrayGx.Text = nOnOff
            Case "1312"
                Me.txtPort2GrayGx.Text = nOnOff
            Case "1313"
                Me.txtPort3GrayGx.Text = nOnOff
            Case "1314"
                Me.txtPort4GrayGx.Text = nOnOff
            Case "1315"
                Me.txtPort5GrayGx.Text = nOnOff
            Case "1316"
                Me.txtPort1CSTExist.Text = nOnOff
            Case "1317"
                Me.txtPort2CSTExist.Text = nOnOff
            Case "1318"
                Me.txtPort3CSTExist.Text = nOnOff
            Case "1319"
                Me.txtPort4CSTExist.Text = nOnOff
            Case "131A"
                Me.txtPort5CSTExist.Text = nOnOff
            Case "131B"
                Me.txtPort1PortDisable.Text = nOnOff
            Case "131C"
                Me.txtPort2PortDisable.Text = nOnOff
            Case "131D"
                Me.txtPort3PortDisable.Text = nOnOff
            Case "131E"
                Me.txtPort4PortDisable.Text = nOnOff
            Case "131F"
                Me.txtPort5PortDisable.Text = nOnOff
            Case "1320"
                Me.txtPort1VCREnable.Text = nOnOff
            Case "1321"
                Me.txtPort2VCREnable.Text = nOnOff
            Case "1322"
                Me.txtPort3VCREnable.Text = nOnOff
            Case "1323"
                Me.txtPort4VCREnable.Text = nOnOff
            Case "1324"
                Me.txtPort5VCREnable.Text = nOnOff
        End Select
    End Sub

    Public Sub SetWordData(ByVal nPortMode1() As Integer, ByVal nUnloadPortType1() As Integer)
        'Me.txtPortMode.Text = strPortMode
        'Me.txtUnloadPortType.Text = strUnloadPortType

        MyUpdataCVPortStatusGUI.nPort1PortMode = nPortMode1(1)
        MyUpdataCVPortStatusGUI.nPort2PortMode = nPortMode1(2)
        MyUpdataCVPortStatusGUI.nPort3PortMode = nPortMode1(3)
        MyUpdataCVPortStatusGUI.nPort4PortMode = nPortMode1(4)
        MyUpdataCVPortStatusGUI.nPort5PortMode = nPortMode1(5)
        MyUpdataCVPortStatusGUI.nPort1UnloadPortType = nUnloadPortType1(1)
        MyUpdataCVPortStatusGUI.nPort2UnloadPortType = nUnloadPortType1(2)
        MyUpdataCVPortStatusGUI.nPort3UnloadPortType = nUnloadPortType1(3)
        MyUpdataCVPortStatusGUI.nPort4UnloadPortType = nUnloadPortType1(4)
        MyUpdataCVPortStatusGUI.nPort5UnloadPortType = nUnloadPortType1(5)
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

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nConvertPortIndex As Integer
        nConvertPortIndex = TabControl1.SelectedIndex + 1
        RaiseEvent PortTabChange(nConvertPortIndex)
    End Sub

    Public Sub ResetSignal()
        Me.txtPort1CSTExist.Text = ""
        Me.txtPort1GrayGx.Text = ""
        Me.txtPort1MixGx.Text = ""
        Me.txtPort1NGGx.Text = ""
        Me.txtPort1OKGx.Text = ""
        Me.txtPort1PortDisable.Text = ""
        Me.txtPort1PortMode.Text = ""
        Me.txtPort1UnloadPortType.Text = ""
        Me.txtPort1VCREnable.Text = ""

        Me.txtPort2CSTExist.Text = ""
        Me.txtPort2GrayGx.Text = ""
        Me.txtPort2MixGx.Text = ""
        Me.txtPort2NGGx.Text = ""
        Me.txtPort2OKGx.Text = ""
        Me.txtPort2PortDisable.Text = ""
        Me.txtPort2PortMode.Text = ""
        Me.txtPort2UnloadPortType.Text = ""
        Me.txtPort2VCREnable.Text = ""

        Me.txtPort3CSTExist.Text = ""
        Me.txtPort3GrayGx.Text = ""
        Me.txtPort3MixGx.Text = ""
        Me.txtPort3NGGx.Text = ""
        Me.txtPort3OKGx.Text = ""
        Me.txtPort3PortDisable.Text = ""
        Me.txtPort3PortMode.Text = ""
        Me.txtPort3UnloadPortType.Text = ""
        Me.txtPort3VCREnable.Text = ""

        Me.txtPort4CSTExist.Text = ""
        Me.txtPort4GrayGx.Text = ""
        Me.txtPort4MixGx.Text = ""
        Me.txtPort4NGGx.Text = ""
        Me.txtPort4OKGx.Text = ""
        Me.txtPort4PortDisable.Text = ""
        Me.txtPort4PortMode.Text = ""
        Me.txtPort4UnloadPortType.Text = ""
        Me.txtPort4VCREnable.Text = ""

        Me.txtPort5CSTExist.Text = ""
        Me.txtPort5GrayGx.Text = ""
        Me.txtPort5MixGx.Text = ""
        Me.txtPort5NGGx.Text = ""
        Me.txtPort5OKGx.Text = ""
        Me.txtPort5PortDisable.Text = ""
        Me.txtPort5PortMode.Text = ""
        Me.txtPort5UnloadPortType.Text = ""
        Me.txtPort5VCREnable.Text = ""

    End Sub

    Public Sub ShowGUIPortStatusReport()
        Me.txtPort1PortMode.Text = MyUpdataCVPortStatusGUI.nPort1PortMode
        Me.txtPort1UnloadPortType.Text = MyUpdataCVPortStatusGUI.nPort1UnloadPortType
        Me.txtPort2PortMode.Text = MyUpdataCVPortStatusGUI.nPort2PortMode
        Me.txtPort2UnloadPortType.Text = MyUpdataCVPortStatusGUI.nPort2UnloadPortType
        Me.txtPort3PortMode.Text = MyUpdataCVPortStatusGUI.nPort3PortMode
        Me.txtPort3UnloadPortType.Text = MyUpdataCVPortStatusGUI.nPort3UnloadPortType
        Me.txtPort4PortMode.Text = MyUpdataCVPortStatusGUI.nPort4PortMode
        Me.txtPort4UnloadPortType.Text = MyUpdataCVPortStatusGUI.nPort4UnloadPortType
        Me.txtPort5PortMode.Text = MyUpdataCVPortStatusGUI.nPort5PortMode
        Me.txtPort5UnloadPortType.Text = MyUpdataCVPortStatusGUI.nPort5UnloadPortType
    End Sub

End Class
