Imports System.Windows.Forms
Imports System.Data
Public Class DialogRecipeComfirmWithGlassSelection
    Private OldPPID As String
    Private myPort As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        WriteLog(Me.Name & ": user click [OK]", LogMessageType.Info)
        Select Case _L8B.Setting.Main.GlassFlowMode
            Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                If NumericUpDownSampleGlass.Value > GetTotalBufferSlotModeNumberForPort(myPort) Then
                    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Select Glass excess the buffer limit. please correct it", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                'If GetChecked() > GetTotalBufferSlotModeNumberForPort(myPort) Then
                '    ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Select Glass excess the buffer limit. please correct it", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'End If
        End Select

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If ComboBoxPPID.Text <> _L8B.CIM.LotInfo(myPort).RecipeName Then
            WriteLog("Recipe Comfirm: PPID Change->" & ComboBoxPPID.Text, LogMessageType.Info)
            _L8B.CIM.RecipeComfirm(myPort, ComboBoxPPID.Text)
            _L8B.CIM.LotInfo(myPort).RecipeName = ComboBoxPPID.Text
            mInfo.Port(myPort).Recipe = _L8B.db.LoadRecipe(MyTrim(_L8B.CIM.LotInfo(myPort).RecipeName))
            mInfo.Port(myPort).Recipe.SampleGlass = NumericUpDownSampleGlass.Value
            For i As Integer = 1 To MAXCASSETTESLOT
                mInfo.Port(myPort).Recipe.SelectGlass(i) = IIf(SelectCheckBox(i).Checked, 1, 0)
            Next
        Else
            WriteLog("Recipe Comfirm: PPID no Change.", LogMessageType.Info)
            _L8B.CIM.RecipeComfirm(myPort)
        End If

        For i As Integer = 1 To MAXCASSETTESLOT
            With _L8B.CIM.LotInfo(myPort).Slots(i)
                If .SlotNo > 0 Then
                    .ProcFlag = SelectCheckBox(.SlotNo).Checked
                    WriteLog("[Monitor mode] Recipe Comfirm for port:" & myPort & " Glass Process selection SlotNo=" & .SlotNo & "-> " & .ProcFlag)
                End If
            End With
        Next

        InsertPortGlassData(myPort)
        _L8B.PLC.UploadLotData(myPort)
        SetPortStatus(myPort, PORTSTATUS.READYTOSTART)

        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Cancel Cassette]", LogMessageType.Info)
        _L8B.Log.Hide()
        If MsgBox("Cassette Cancel", MsgBoxStyle.OkCancel, "Recipe Comfirm.") = MsgBoxResult.Ok Then
            WriteLog("Recipe Comfirm: User press Cassette Cancel.", LogMessageType.Info)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            WriteLog("RecipeComfirm: User click Abort for cancel cassette", LogMessageType.Info)
            _L8B.PLC.CassetteUnloadRequest(myPort)
            Me.Hide()
        End If
    End Sub

    Public Sub ShowMe(ByVal nPort As Integer, Optional ByVal Parent As System.Windows.Forms.IWin32Window = Nothing)
        myPort = nPort
        GroupBoxGlassSelectionI.Visible = False
        GroupBoxGlassSelectionU.Visible = False
        DataGridViewRecipe.DataSource = _L8B.db.QueryRecipeList
        If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
            GroupBoxGlassSelectionI.Visible = True
        ElseIf _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
            GroupBoxGlassSelectionU.Visible = True
        End If
        Dim dt As DataTable = _L8B.db.QueryRecipeList
        DataGridViewRecipe.DataSource = dt
        ComboBoxPPID.DisplayMember = "ID"
        ComboBoxPPID.DataSource = dt
        TextBoxPort.Text = nPort
        TextBoxCSDID.Text = _L8B.CIM.LotInfo(myPort).CassetteID
        TextBoxLotID.Text = _L8B.CIM.LotInfo(myPort).CIMMessage
        OldPPID = MyTrim(_L8B.CIM.LotInfo(myPort).RecipeName)
        ComboBoxPPID.Text = MyTrim(OldPPID)
        If mInfo.Port(nPort).Recipe IsNot Nothing Then
            NumericUpDownSampleGlass.Value = mInfo.Port(nPort).Recipe.SampleGlass
        Else
            NumericUpDownSampleGlass.Value = NumericUpDownSampleGlass.Minimum
        End If

        SetSelectCheckBox()
        ''If Parent Is Nothing Then
        ''    Me.Show()
        ''Else
        ''    Me.Show(Parent)
        ''End If
        ''Me.TopMost = True
        'ShowForm()
        SyncLock _L8B.frmShowQueue
            _L8B.frmShowQueue.Enqueue(Me)
        End SyncLock
    End Sub

    Dim SelectCheckBox As New Dictionary(Of Integer, CheckBox)
    Dim SelectGlxID As New Dictionary(Of Integer, Label)
    Dim SelectGGrade As New Dictionary(Of Integer, TextBox)

    Delegate Sub ShowFormDelegate()

    'Private Sub ShowForm()
    '    If Me.InvokeRequired Then
    '        Dim vShowFormDelegate = New ShowFormDelegate(AddressOf ShowForm)
    '        Me.Invoke(vShowFormDelegate)
    '    Else
    '        Me.Show()
    '        Me.TopMost = True
    '    End If

    'End Sub


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        SelectCheckBox.Add(1, CheckBox1)
        SelectCheckBox.Add(2, CheckBox2)
        SelectCheckBox.Add(3, CheckBox3)
        SelectCheckBox.Add(4, CheckBox4)
        SelectCheckBox.Add(5, CheckBox5)
        SelectCheckBox.Add(6, CheckBox6)
        SelectCheckBox.Add(7, CheckBox7)
        SelectCheckBox.Add(8, CheckBox8)
        SelectCheckBox.Add(9, CheckBox9)
        SelectCheckBox.Add(10, CheckBox10)
        SelectCheckBox.Add(11, CheckBox11)
        SelectCheckBox.Add(12, CheckBox12)
        SelectCheckBox.Add(13, CheckBox13)
        SelectCheckBox.Add(14, CheckBox14)
        SelectCheckBox.Add(15, CheckBox15)
        SelectCheckBox.Add(16, CheckBox16)
        SelectCheckBox.Add(17, CheckBox17)
        SelectCheckBox.Add(18, CheckBox18)
        SelectCheckBox.Add(19, CheckBox19)
        SelectCheckBox.Add(20, CheckBox20)
        SelectCheckBox.Add(21, CheckBox21)
        SelectCheckBox.Add(22, CheckBox22)
        SelectCheckBox.Add(23, CheckBox23)
        SelectCheckBox.Add(24, CheckBox24)
        SelectCheckBox.Add(25, CheckBox25)
        SelectCheckBox.Add(26, CheckBox26)
        SelectCheckBox.Add(27, CheckBox27)
        SelectCheckBox.Add(28, CheckBox28)
        SelectCheckBox.Add(29, CheckBox29)
        SelectCheckBox.Add(30, CheckBox30)
        SelectCheckBox.Add(31, CheckBox31)
        SelectCheckBox.Add(32, CheckBox32)
        SelectCheckBox.Add(33, CheckBox33)
        SelectCheckBox.Add(34, CheckBox34)
        SelectCheckBox.Add(35, CheckBox35)
        SelectCheckBox.Add(36, CheckBox36)
        SelectCheckBox.Add(37, CheckBox37)
        SelectCheckBox.Add(38, CheckBox38)
        SelectCheckBox.Add(39, CheckBox39)
        SelectCheckBox.Add(40, CheckBox40)
        SelectCheckBox.Add(41, CheckBox41)
        SelectCheckBox.Add(42, CheckBox42)
        SelectCheckBox.Add(43, CheckBox43)
        SelectCheckBox.Add(44, CheckBox44)
        SelectCheckBox.Add(45, CheckBox45)
        SelectCheckBox.Add(46, CheckBox46)
        SelectCheckBox.Add(47, CheckBox47)
        SelectCheckBox.Add(48, CheckBox48)
        SelectCheckBox.Add(49, CheckBox49)
        SelectCheckBox.Add(50, CheckBox50)
        SelectCheckBox.Add(51, CheckBox51)
        SelectCheckBox.Add(52, CheckBox52)
        SelectCheckBox.Add(53, CheckBox53)
        SelectCheckBox.Add(54, CheckBox54)
        SelectCheckBox.Add(55, CheckBox55)
        SelectCheckBox.Add(56, CheckBox56)

        SelectGlxID.Add(1, Label1)
        SelectGlxID.Add(2, Label2)
        SelectGlxID.Add(3, Label3)
        SelectGlxID.Add(4, Label4)
        SelectGlxID.Add(5, Label5)
        SelectGlxID.Add(6, Label6)
        SelectGlxID.Add(7, Label7)
        SelectGlxID.Add(8, Label8)
        SelectGlxID.Add(9, Label9)
        SelectGlxID.Add(10, Label10)
        SelectGlxID.Add(11, Label11)
        SelectGlxID.Add(12, Label12)
        SelectGlxID.Add(13, Label13)
        SelectGlxID.Add(14, Label14)
        SelectGlxID.Add(15, Label15)
        SelectGlxID.Add(16, Label16)
        SelectGlxID.Add(17, Label17)
        SelectGlxID.Add(18, Label18)
        SelectGlxID.Add(19, Label19)
        SelectGlxID.Add(20, Label20)
        SelectGlxID.Add(21, Label21)
        SelectGlxID.Add(22, Label22)
        SelectGlxID.Add(23, Label23)
        SelectGlxID.Add(24, Label24)
        SelectGlxID.Add(25, Label25)
        SelectGlxID.Add(26, Label26)
        SelectGlxID.Add(27, Label27)
        SelectGlxID.Add(28, Label28)
        SelectGlxID.Add(29, Label29)
        SelectGlxID.Add(30, Label30)
        SelectGlxID.Add(31, Label31)
        SelectGlxID.Add(32, Label32)
        SelectGlxID.Add(33, Label33)
        SelectGlxID.Add(34, Label34)
        SelectGlxID.Add(35, Label35)
        SelectGlxID.Add(36, Label36)
        SelectGlxID.Add(37, Label37)
        SelectGlxID.Add(38, Label38)
        SelectGlxID.Add(39, Label39)
        SelectGlxID.Add(40, Label40)
        SelectGlxID.Add(41, Label41)
        SelectGlxID.Add(42, Label42)
        SelectGlxID.Add(43, Label43)
        SelectGlxID.Add(44, Label44)
        SelectGlxID.Add(45, Label45)
        SelectGlxID.Add(46, Label46)
        SelectGlxID.Add(47, Label47)
        SelectGlxID.Add(48, Label48)
        SelectGlxID.Add(49, Label49)
        SelectGlxID.Add(50, Label50)
        SelectGlxID.Add(51, Label51)
        SelectGlxID.Add(52, Label52)
        SelectGlxID.Add(53, Label53)
        SelectGlxID.Add(54, Label54)
        SelectGlxID.Add(55, Label55)
        SelectGlxID.Add(56, Label56)

        SelectGGrade.Add(1, TextBox1)
        SelectGGrade.Add(2, TextBox2)
        SelectGGrade.Add(3, TextBox3)
        SelectGGrade.Add(4, TextBox4)
        SelectGGrade.Add(5, TextBox5)
        SelectGGrade.Add(6, TextBox6)
        SelectGGrade.Add(7, TextBox7)
        SelectGGrade.Add(8, TextBox8)
        SelectGGrade.Add(9, TextBox9)
        SelectGGrade.Add(10, TextBox10)
        SelectGGrade.Add(11, TextBox11)
        SelectGGrade.Add(12, TextBox12)
        SelectGGrade.Add(13, TextBox13)
        SelectGGrade.Add(14, TextBox14)
        SelectGGrade.Add(15, TextBox15)
        SelectGGrade.Add(16, TextBox16)
        SelectGGrade.Add(17, TextBox17)
        SelectGGrade.Add(18, TextBox18)
        SelectGGrade.Add(19, TextBox19)
        SelectGGrade.Add(20, TextBox20)
        SelectGGrade.Add(21, TextBox21)
        SelectGGrade.Add(22, TextBox22)
        SelectGGrade.Add(23, TextBox23)
        SelectGGrade.Add(24, TextBox24)
        SelectGGrade.Add(25, TextBox25)
        SelectGGrade.Add(26, TextBox26)
        SelectGGrade.Add(27, TextBox27)
        SelectGGrade.Add(28, TextBox28)
        SelectGGrade.Add(29, TextBox29)
        SelectGGrade.Add(30, TextBox30)
        SelectGGrade.Add(31, TextBox31)
        SelectGGrade.Add(32, TextBox32)
        SelectGGrade.Add(33, TextBox33)
        SelectGGrade.Add(34, TextBox34)
        SelectGGrade.Add(35, TextBox35)
        SelectGGrade.Add(36, TextBox36)
        SelectGGrade.Add(37, TextBox37)
        SelectGGrade.Add(38, TextBox38)
        SelectGGrade.Add(39, TextBox39)
        SelectGGrade.Add(40, TextBox40)
        SelectGGrade.Add(41, TextBox41)
        SelectGGrade.Add(42, TextBox42)
        SelectGGrade.Add(43, TextBox43)
        SelectGGrade.Add(44, TextBox44)
        SelectGGrade.Add(45, TextBox45)
        SelectGGrade.Add(46, TextBox46)
        SelectGGrade.Add(47, TextBox47)
        SelectGGrade.Add(48, TextBox48)
        SelectGGrade.Add(49, TextBox49)
        SelectGGrade.Add(50, TextBox50)
        SelectGGrade.Add(51, TextBox51)
        SelectGGrade.Add(52, TextBox52)
        SelectGGrade.Add(53, TextBox53)
        SelectGGrade.Add(54, TextBox54)
        SelectGGrade.Add(55, TextBox55)
        SelectGGrade.Add(56, TextBox56)

    End Sub

    Public Property PortNo() As Integer
        Get
            Return myPort
        End Get
        Set(ByVal value As Integer)
            myPort = value
        End Set
    End Property


    Public Function GetChecked() As Integer
        Dim CheckedNumber As Integer = 0
        For i As Integer = 1 To MAXCASSETTESLOT
            If SelectCheckBox(i).Checked Then CheckedNumber += 1
        Next
        Return CheckedNumber
    End Function

    Public Sub SetSelectCheckBox()

        For i As Integer = 1 To MAXCASSETTESLOT
            SelectCheckBox(i).Checked = False
            SelectCheckBox(i).Enabled = False
            SelectGGrade(i).Text = ""
            SelectGGrade(i).Visible = False
            SelectGlxID(i).Text = ""
            SelectGlxID(i).Visible = False
        Next

        If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
            GroupBoxGlassSelectionU.Visible = True
            GroupBoxGlassSelectionI.Visible = False

            For i As Integer = 1 To MAXCASSETTESLOT
                With _L8B.CIM.LotInfo(myPort).Slots(i)
                    Dim nSlot As Integer = .SlotNo

                    If nSlot > 0 Then

                        SelectCheckBox(nSlot).Enabled = IIf(mInfo.Port(myPort).Map(nSlot) = 1, True, False)
                        SelectCheckBox(nSlot).Checked = .ProcFlag
                        SelectGlxID(nSlot).Text = .GlassID
                        SelectGlxID(nSlot).Visible = True
                        SelectGGrade(nSlot).Visible = True
                        Select Case .GlassGrade
                            Case prjSECS.clsEnumCtl.eGlassGrade.GRAY
                                SelectGGrade(nSlot).Text = "G"
                            Case prjSECS.clsEnumCtl.eGlassGrade.NG
                                SelectGGrade(nSlot).Text = "N"
                            Case prjSECS.clsEnumCtl.eGlassGrade.NO
                                SelectGGrade(nSlot).Text = ""
                            Case prjSECS.clsEnumCtl.eGlassGrade.OK
                                SelectGGrade(nSlot).Text = "O"
                        End Select
                    End If

                End With
            Next
        Else
            GroupBoxGlassSelectionU.Visible = False
            GroupBoxGlassSelectionI.Visible = True

        End If

    End Sub

End Class
