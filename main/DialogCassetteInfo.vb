Imports System.Data
Imports System.Windows.Forms

Public Class DialogCassetteInfo

    Dim LotInfo As New prjSECS.clsLotStructure
    Dim ChipGradeDict As New Dictionary(Of Integer, CheckBox)
    Dim GlassDataTable As New DataTable
    Dim fShowColumn() As Boolean

    Private myPort As Integer
    Public Property PortNo() As Integer
        Get
            Return myPort
        End Get
        Set(ByVal value As Integer)
            myPort = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ChipGradeDict.Add(1, CheckBox1)
        ChipGradeDict.Add(2, CheckBox2)
        ChipGradeDict.Add(3, CheckBox3)
        ChipGradeDict.Add(4, CheckBox4)
        ChipGradeDict.Add(5, CheckBox5)
        ChipGradeDict.Add(6, CheckBox6)
        ChipGradeDict.Add(7, CheckBox7)
        ChipGradeDict.Add(8, CheckBox8)
        ChipGradeDict.Add(9, CheckBox9)
        ChipGradeDict.Add(10, CheckBox10)
        ChipGradeDict.Add(11, CheckBox11)
        ChipGradeDict.Add(12, CheckBox12)
        ChipGradeDict.Add(13, CheckBox13)
        ChipGradeDict.Add(14, CheckBox14)
        ChipGradeDict.Add(15, CheckBox15)
        ChipGradeDict.Add(16, CheckBox16)
        ChipGradeDict.Add(17, CheckBox17)
        ChipGradeDict.Add(18, CheckBox18)
        ChipGradeDict.Add(19, CheckBox19)
        ChipGradeDict.Add(20, CheckBox20)
        ChipGradeDict.Add(21, CheckBox21)
        ChipGradeDict.Add(22, CheckBox22)
        ChipGradeDict.Add(23, CheckBox23)
        ChipGradeDict.Add(24, CheckBox24)
        ChipGradeDict.Add(25, CheckBox25)
        ChipGradeDict.Add(26, CheckBox26)
        ChipGradeDict.Add(27, CheckBox27)
        ChipGradeDict.Add(28, CheckBox28)
        ChipGradeDict.Add(29, CheckBox29)
        ChipGradeDict.Add(30, CheckBox30)
        ChipGradeDict.Add(31, CheckBox31)
        ChipGradeDict.Add(32, CheckBox32)
        ChipGradeDict.Add(33, CheckBox33)
        ChipGradeDict.Add(34, CheckBox34)
        ChipGradeDict.Add(35, CheckBox35)
        ChipGradeDict.Add(36, CheckBox36)
        ChipGradeDict.Add(37, CheckBox37)
        ChipGradeDict.Add(38, CheckBox38)
        ChipGradeDict.Add(39, CheckBox39)
        ChipGradeDict.Add(40, CheckBox40)
        ChipGradeDict.Add(41, CheckBox41)
        ChipGradeDict.Add(42, CheckBox42)
        ChipGradeDict.Add(43, CheckBox43)
        ChipGradeDict.Add(44, CheckBox44)
        ChipGradeDict.Add(45, CheckBox45)
        ChipGradeDict.Add(46, CheckBox46)
        ChipGradeDict.Add(47, CheckBox47)
        ChipGradeDict.Add(48, CheckBox48)
        ChipGradeDict.Add(49, CheckBox49)
        ChipGradeDict.Add(50, CheckBox50)
        ChipGradeDict.Add(51, CheckBox51)
        ChipGradeDict.Add(52, CheckBox52)
        ChipGradeDict.Add(53, CheckBox53)
        ChipGradeDict.Add(54, CheckBox54)
        ChipGradeDict.Add(55, CheckBox55)
        ChipGradeDict.Add(56, CheckBox56)
        ChipGradeDict.Add(57, CheckBox57)
        ChipGradeDict.Add(58, CheckBox58)
        ChipGradeDict.Add(59, CheckBox59)
        ChipGradeDict.Add(60, CheckBox60)
        ChipGradeDict.Add(61, CheckBox61)
        ChipGradeDict.Add(62, CheckBox62)
        ChipGradeDict.Add(63, CheckBox63)
        ChipGradeDict.Add(64, CheckBox64)
        ChipGradeDict.Add(65, CheckBox65)
        ChipGradeDict.Add(66, CheckBox66)
        ChipGradeDict.Add(67, CheckBox67)
        ChipGradeDict.Add(68, CheckBox68)
        ChipGradeDict.Add(69, CheckBox69)
        ChipGradeDict.Add(70, CheckBox70)
        ChipGradeDict.Add(71, CheckBox71)
        ChipGradeDict.Add(72, CheckBox72)

        GlassDataTable.Columns.Add("SlotNo")
        GlassDataTable.Columns.Add("Exist")
        GlassDataTable.Columns.Add("ProcessFlag")
        GlassDataTable.Columns.Add("GlassID")
        GlassDataTable.Columns.Add("GlassGrade")    '8
        GlassDataTable.Columns.Add("LastProcessedLineID")
        GlassDataTable.Columns.Add("ProcessToolID")
        GlassDataTable.Columns.Add("DMQCToolID")
        GlassDataTable.Columns.Add("LastProcessedOperationID") '4
        GlassDataTable.Columns.Add("DMQCGrade")
        GlassDataTable.Columns.Add("PSHGroup")
        GlassDataTable.Columns.Add("ChipGrade")
        GlassDataTable.Columns.Add("Rework")
        GlassDataTable.Columns.Add("Scrap")
        GlassDataTable.Columns.Add("FIRemark")
        GlassDataTable.Columns.Add("FIFCFlag")
        AddHandler DataGridView.DataError, AddressOf DataGridView_DataError
        CreateDataGridView()
    End Sub

    Private Sub CreateDataGridView()
        Dim C1_SlotNo As New DataGridViewTextBoxColumn
        Dim C2_GlassID As New DataGridViewTextBoxColumn
        Dim C3_LastProcessOperationID As New DataGridViewTextBoxColumn
        Dim C4_LastProcessLineID As New DataGridViewTextBoxColumn
        Dim C5_ProcessToolID As New DataGridViewTextBoxColumn
        Dim C6_DMQCToolID As New DataGridViewTextBoxColumn
        Dim C7_GlassGrade As New DataGridViewComboBoxColumn
        Dim C8_DMQCGrade As New DataGridViewComboBoxColumn
        Dim C9_PSHGroup As New DataGridViewTextBoxColumn
        Dim C10_ChipGrade As New DataGridViewTextBoxColumn
        Dim C11_ReworkFlag As New DataGridViewCheckBoxColumn
        Dim C12_ScrapFlag As New DataGridViewComboBoxColumn
        Dim C13_FIRemarkFlag As New DataGridViewCheckBoxColumn
        Dim C14_FIFCFlag As New DataGridViewComboBoxColumn
        Dim C15_Exist As New DataGridViewCheckBoxColumn
        Dim C16_PorcessFlag As New DataGridViewCheckBoxColumn

        With C1_SlotNo
            .DataPropertyName = "SlotNo"
            .HeaderText = "SlotNo"
            .ReadOnly = True
        End With

        With C2_GlassID
            .DataPropertyName = "GlassID"
            .HeaderText = "GlassID"
            .ReadOnly = False
        End With

        With C3_LastProcessOperationID
            .DataPropertyName = "LastProcessedOperationID"
            .HeaderText = "LastProcessedOperationID"
            .ReadOnly = False
        End With

        With C4_LastProcessLineID
            .DataPropertyName = "LastProcessedLineID"
            .HeaderText = "LastProcessedLineID"
            .ReadOnly = False
        End With

        With C5_ProcessToolID
            .DataPropertyName = "ProcessToolID"
            .HeaderText = "ProcessToolID"
            .ReadOnly = False
        End With

        With C6_DMQCToolID
            .DataPropertyName = "DMQCToolID"
            .HeaderText = "DMQCToolID"
            .ReadOnly = False
        End With

        With C7_GlassGrade
            'Dim GlassGradeList As New ArrayList
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.NO.ToString)
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.OK.ToString)
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.NG.ToString)
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.GRAY.ToString)
            .DataPropertyName = "GlassGrade"
            .HeaderText = "GlassGrade"
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eGlassGrade), 0) 'GlassGradeList '[Enum].GetNames(GetType(prjsecs.clsEnumCtl.eGlassGrade))
            .ReadOnly = False
        End With

        With C8_DMQCGrade
            'Dim DMQCGradeList As New ArrayList
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.NO.ToString)
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.OK.ToString)
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.NG.ToString)
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.REVIEW.ToString)
            .DataPropertyName = "DMQCGrade"
            .HeaderText = "DMQCGrade"
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eDMQCGrade), 0) 'DMQCGradeList ' [Enum].GetNames(GetType(prjsecs.clsEnumCtl.eDMQCGrade))
            .ReadOnly = False
        End With

        With C9_PSHGroup
            .DataPropertyName = "PSHGroup"
            .HeaderText = "PSHGroup"
            .ReadOnly = False
        End With

        With C10_ChipGrade
            .DataPropertyName = "ChipGrade"
            .HeaderText = "ChipGrade"
            .ReadOnly = False
        End With

        With C11_ReworkFlag
            .DataPropertyName = "Rework"
            .HeaderText = "Rework"
            .ReadOnly = False
        End With

        With C12_ScrapFlag
            'Dim ScrapList As New ArrayList
            'ScrapList.Add(prjsecs.clsEnumCtl.eScrapType.NONE.ToString)
            'ScrapList.Add(prjsecs.clsEnumCtl.eScrapType.YES.ToString)
            'ScrapList.Add(prjsecs.clsEnumCtl.eScrapType.RECYCLE.ToString)

            .DataPropertyName = "Scrap"
            .HeaderText = "Scrap"
            '.Items.Add([Enum].GetValues(GetType(prjSECS.clsEnumCtl.eScrapType)))
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eScrapType), 0) ' ScrapList '[Enum].GetNames(GetType(prjsecs.clsEnumCtl.eScrapType))
            .ReadOnly = False

        End With

        With C13_FIRemarkFlag
            .DataPropertyName = "FIRemark"
            .HeaderText = "FIRemark"
            .ReadOnly = False
        End With

        With C14_FIFCFlag

            .DataPropertyName = "FIFCFlag"
            .HeaderText = "FIFCFlag"
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eFIFCFlag), 1) 'FIFCFlagList ' [Enum].GetNames(GetType(prjsecs.clsEnumCtl.eFIFCFlag))
            .ReadOnly = False
        End With

        With C15_Exist
            .DataPropertyName = "Exist"
            .HeaderText = "Exist"
            .ReadOnly = True
        End With

        With C16_PorcessFlag
            .DataPropertyName = "ProcessFlag"
            .HeaderText = "ProcessFlag"
            '.ReadOnly = IIf(_l8b.Setting.Main.GlassFlowMode = prjsecs.clsEnumCtl.ePortType.TYPE_I, True, False)
            '.Visible = IIf(_L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U, True, False)
        End With

        DataGridView.DataSource = Nothing

        DataGridView.Columns.Clear()
        DataGridView.Columns.Add(C1_SlotNo)
        DataGridView.Columns.Add(C15_Exist)
        DataGridView.Columns.Add(C16_PorcessFlag)
        DataGridView.Columns.Add(C2_GlassID)
        DataGridView.Columns.Add(C7_GlassGrade)
        DataGridView.Columns.Add(C4_LastProcessLineID)
        DataGridView.Columns.Add(C5_ProcessToolID)
        DataGridView.Columns.Add(C6_DMQCToolID)
        DataGridView.Columns.Add(C3_LastProcessOperationID)
        DataGridView.Columns.Add(C8_DMQCGrade)
        DataGridView.Columns.Add(C9_PSHGroup)
        DataGridView.Columns.Add(C10_ChipGrade)
        DataGridView.Columns.Add(C11_ReworkFlag)
        DataGridView.Columns.Add(C12_ScrapFlag)
        DataGridView.Columns.Add(C13_FIRemarkFlag)
        DataGridView.Columns.Add(C14_FIFCFlag)


    End Sub

    Public Sub ShowMe(ByVal Parent As System.Windows.Forms.Form)
        Me.Visible = False
        Button5.Visible = True  'missing ButtonManualStart
        ButtonManualStart.Visible = True
        'OK_Button.Visible = True
        ButtonSelectAll.Visible = True
        ButtonNoGlass.Visible = True
        ButtonInverseSelect.Visible = True
        ButtonShowOnlyExistGlass.Visible = True
        ButtonAutoFill.Visible = True
        TabPage1.Enabled = True
        TabPage2.Enabled = True
        GroupBoxSampleGlassNumber.Visible = True
        GroupBox1.Enabled = True

        Me.Text = "Cassette Info Port=" & myPort
        ButtonManualStart.Enabled = True
        ComboBoxPPID.DataSource = Nothing
        ComboBoxPPID.DisplayMember = "ID"
        ComboBoxPPID.DataSource = _L8B.db.QueryRecipeList
        ' Me.Show(Parent)
        DataGridViewShowData()

        'setup I mode sample glass count
        GroupBoxSampleGlassNumber.Enabled = IIf(_L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I, True, False)
        NumericUpDownIModeSamples.Minimum = 1
        Dim FreeBufferSlot As Integer = GetFreeBufferSlotForPort(myPort)
        If FreeBufferSlot <= 0 Then
            If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Warnning, "Buffer free slot =0 (Now it can process only 1 glass), Please check the available slot for [Cassette" & myPort & "]", MsgBoxStyle.OkOnly, 60, MsgBoxResult.Ok, True)
            End If
            FreeBufferSlot = 1
        End If

        If FreeBufferSlot > mInfo.Port(myPort).GlassCount Then
            NumericUpDownIModeSamples.Maximum = mInfo.Port(myPort).GlassCount
        Else
            NumericUpDownIModeSamples.Maximum = FreeBufferSlot
        End If
        NumericUpDownIModeSamples.Value = NumericUpDownIModeSamples.Maximum


        AddHandler DataGridView.DataError, AddressOf DataGridView_DataError

        Select Case _L8B.Setting.Main.GlassFlowMode
            Case prjSECS.clsEnumCtl.ePortType.TYPE_I
                ButtonSelectAll.Enabled = False
                ButtonNoGlass.Enabled = False
                ButtonInverseSelect.Enabled = False

            Case prjSECS.clsEnumCtl.ePortType.TYPE_U
                ButtonSelectAll.Enabled = True
                ButtonNoGlass.Enabled = True
                ButtonInverseSelect.Enabled = True
        End Select
        ComboBoxGlassGrade.SelectedIndex = 1
        ComboBoxDMQCGrade.SelectedIndex = 1
        Fillout()
        Cancel_Button.Text = "Cassette Cancel"
        SyncLock _L8B.frmShowQueue
            _L8B.frmShowQueue.Enqueue(Me)
        End SyncLock
    End Sub


    Private Sub CreateCIMDataGridView()
        Dim C1_SlotNo As New DataGridViewTextBoxColumn
        Dim C2_GlassID As New DataGridViewTextBoxColumn
        Dim C3_LastProcessOperationID As New DataGridViewTextBoxColumn
        Dim C4_LastProcessLineID As New DataGridViewTextBoxColumn
        Dim C5_ProcessToolID As New DataGridViewTextBoxColumn
        Dim C6_DMQCToolID As New DataGridViewTextBoxColumn
        Dim C7_GlassGrade As New DataGridViewComboBoxColumn
        Dim C8_DMQCGrade As New DataGridViewComboBoxColumn
        Dim C9_PSHGroup As New DataGridViewTextBoxColumn
        Dim C10_ChipGrade As New DataGridViewTextBoxColumn
        Dim C11_ReworkFlag As New DataGridViewCheckBoxColumn
        Dim C12_ScrapFlag As New DataGridViewComboBoxColumn
        Dim C13_FIRemarkFlag As New DataGridViewCheckBoxColumn
        Dim C14_FIFCFlag As New DataGridViewComboBoxColumn
        Dim C15_Exist As New DataGridViewCheckBoxColumn
        Dim C16_PorcessFlag As New DataGridViewCheckBoxColumn

        With C1_SlotNo
            .DataPropertyName = "SlotNo"
            .HeaderText = "SlotNo"
            .ReadOnly = True
            .Visible = True
        End With

        With C2_GlassID
            .DataPropertyName = "GlassID"
            .HeaderText = "GlassID"
            .ReadOnly = False
            .Visible = True
        End With

        With C3_LastProcessOperationID
            .DataPropertyName = "LastProcessedOperationID"
            .HeaderText = "LastProcessedOperationID"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(3)
        End With

        With C4_LastProcessLineID
            .DataPropertyName = "LastProcessedLineID"
            .HeaderText = "LastProcessedLineID"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(4)
        End With

        With C5_ProcessToolID
            .DataPropertyName = "ProcessToolID"
            .HeaderText = "ProcessToolID"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(5)
        End With

        With C6_DMQCToolID
            .DataPropertyName = "DMQCToolID"
            .HeaderText = "DMQCToolID"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(6)
        End With

        With C7_GlassGrade
            'Dim GlassGradeList As New ArrayList
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.NO.ToString)
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.OK.ToString)
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.NG.ToString)
            'GlassGradeList.Add(prjsecs.clsEnumCtl.eGlassGrade.GRAY.ToString)
            .DataPropertyName = "GlassGrade"
            .HeaderText = "GlassGrade"
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eGlassGrade), 0) 'GlassGradeList '[Enum].GetNames(GetType(prjsecs.clsEnumCtl.eGlassGrade))
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(7)
        End With

        With C8_DMQCGrade
            'Dim DMQCGradeList As New ArrayList
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.NO.ToString)
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.OK.ToString)
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.NG.ToString)
            'DMQCGradeList.Add(prjsecs.clsEnumCtl.eDMQCGrade.REVIEW.ToString)
            .DataPropertyName = "DMQCGrade"
            .HeaderText = "DMQCGrade"
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eDMQCGrade), 0) 'DMQCGradeList ' [Enum].GetNames(GetType(prjsecs.clsEnumCtl.eDMQCGrade))
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(8)
        End With

        With C9_PSHGroup
            .DataPropertyName = "PSHGroup"
            .HeaderText = "PSHGroup"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(9)
        End With

        With C10_ChipGrade
            .DataPropertyName = "ChipGrade"
            .HeaderText = "ChipGrade"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(10)
        End With

        With C11_ReworkFlag
            .DataPropertyName = "Rework"
            .HeaderText = "Rework"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(11)
        End With

        With C12_ScrapFlag
            'Dim ScrapList As New ArrayList
            'ScrapList.Add(prjsecs.clsEnumCtl.eScrapType.NONE.ToString)
            'ScrapList.Add(prjsecs.clsEnumCtl.eScrapType.YES.ToString)
            'ScrapList.Add(prjsecs.clsEnumCtl.eScrapType.RECYCLE.ToString)

            .DataPropertyName = "Scrap"
            .HeaderText = "Scrap"
            '.Items.Add([Enum].GetValues(GetType(prjsecs.clsEnumCtl.eScrapType)))
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eScrapType), 0) ' ScrapList '[Enum].GetNames(GetType(prjsecs.clsEnumCtl.eScrapType))
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(12)
        End With

        With C13_FIRemarkFlag
            .DataPropertyName = "FIRemark"
            .HeaderText = "FIRemark"
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(13)
        End With

        With C14_FIFCFlag
            'Dim FIFCFlagList As New ArrayList
            'FIFCFlagList.Add(" ") 'prjsecs.clsEnumCtl.eFIFCFlag.FLAG_NA.ToString)
            'FIFCFlagList.Add("F") 'prjsecs.clsEnumCtl.eFIFCFlag.FLAG_F.ToString)
            'FIFCFlagList.Add("B") 'prjsecs.clsEnumCtl.eFIFCFlag.FLAG_B.ToString)

            .DataPropertyName = "FIFCFlag"
            .HeaderText = "FIFCFlag"
            .DataSource = EnumNamesList(GetType(prjSECS.clsEnumCtl.eFIFCFlag), 1) 'FIFCFlagList ' [Enum].GetNames(GetType(prjsecs.clsEnumCtl.eFIFCFlag))
            .ReadOnly = False
            .Visible = _L8B.Setting.Main.fCIMShowColumn(14)
        End With

        With C15_Exist
            .DataPropertyName = "Exist"
            .HeaderText = "Exist"
            .ReadOnly = True
            .Visible = _L8B.Setting.Main.fCIMShowColumn(15)
        End With

        With C16_PorcessFlag
            .DataPropertyName = "ProcessFlag"
            .HeaderText = "ProcessFlag"
            '.ReadOnly = IIf(_l8b.Setting.Main.GlassFlowMode = prjsecs.clsEnumCtl.ePortType.TYPE_I, True, False)
            '.Visible = IIf(_l8b.Setting.Main.GlassFlowMode = prjsecs.clsEnumCtl.ePortType.TYPE_U, True, False)
            .Visible = _L8B.Setting.Main.fCIMShowColumn(16)
        End With

        DataGridView.DataSource = Nothing

        DataGridView.Columns.Clear()
        DataGridView.Columns.Add(C1_SlotNo)
        DataGridView.Columns.Add(C15_Exist)
        DataGridView.Columns.Add(C16_PorcessFlag)
        DataGridView.Columns.Add(C2_GlassID)
        DataGridView.Columns.Add(C7_GlassGrade)
        DataGridView.Columns.Add(C4_LastProcessLineID)
        DataGridView.Columns.Add(C5_ProcessToolID)
        DataGridView.Columns.Add(C6_DMQCToolID)
        DataGridView.Columns.Add(C3_LastProcessOperationID)
        DataGridView.Columns.Add(C8_DMQCGrade)
        DataGridView.Columns.Add(C9_PSHGroup)
        DataGridView.Columns.Add(C10_ChipGrade)
        DataGridView.Columns.Add(C11_ReworkFlag)
        DataGridView.Columns.Add(C12_ScrapFlag)
        DataGridView.Columns.Add(C13_FIRemarkFlag)
        DataGridView.Columns.Add(C14_FIFCFlag)


    End Sub

    Public Sub CIMShowMe(ByVal Parent As System.Windows.Forms.Form)
        If Me.Visible Then
            Exit Sub
        End If
        ButtonManualStart.Visible = False
        OK_Button.Visible = False
        ButtonSelectAll.Visible = False
        ButtonNoGlass.Visible = False
        ButtonInverseSelect.Visible = False
        ButtonShowOnlyExistGlass.Visible = False
        ButtonAutoFill.Visible = False
        TabPage1.Enabled = False
        TabPage2.Enabled = False
        GroupBoxSampleGlassNumber.Visible = False
        GroupBox1.Enabled = False

        Me.Text = "Cassette Info Port=" & myPort
        ComboBoxPPID.DataSource = Nothing
        ComboBoxPPID.DisplayMember = "ID"
        ComboBoxPPID.DataSource = _L8B.db.QueryRecipeList

        DataGridViewCIMShowData()
        With _L8B.CIM.LotInfo(myPort)
            TextBoxCassetteID.Text = .CassetteID
            ComboBoxPPID.Text = .RecipeName
            TextBoxOperationID.Text = .OperationID
            TextBoxProductCode.Text = .ProductCode
            TextBoxMeasurementID.Text = .MeasurementID
            TextBoxProductCode.Text = .ProductCode
        End With

        Cancel_Button.Text = "Close"
        'Me.Show(Parent)
        SyncLock _L8B.frmShowQueue
            _L8B.frmShowQueue.Enqueue(Me)
        End SyncLock
        Button5.Visible = False
    End Sub

    Private Sub ButtonManualStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonManualStart.Click

    End Sub

    Private Sub DataGridView_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        Debug.WriteLine("DataGridView_CellBeginEdit")
    End Sub

    Private Sub DataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Debug.WriteLine("[Exception]DataGridView at DialogCassetteInfo.vb", e.ToString & " " & e.Context.ToString & " ")
    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Debug.WriteLine("ButtonSelect_Click")
    End Sub

    Private Sub DataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) 'Handles DataGridView.EditingControlShowing
        Debug.WriteLine("DataGridView_EditingControlShowing")
        Dim index As Integer = DataGridView.CurrentRow.Index + 1
        If mInfo.Port(myPort).fGlassExist(index) Then
        Else
            DataGridView.CancelEdit()
            DataGridView.EditingControl.Visible = False
        End If

    End Sub

    Private Sub DataGridView_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Debug.WriteLine("DataGridView_EditModeChanged")
    End Sub

    Private Sub DataGridView_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Debug.WriteLine("DataGridView_EnabledChanged")
    End Sub

    Private Sub DataGridView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Debug.WriteLine("DataGridView_GotFocus")
    End Sub

    Private Sub DataGridView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Debug.WriteLine("DataGridView_LostFocus")
    End Sub

    Private Sub DataGridView_ReadOnlyChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Debug.WriteLine("DataGridView_ReadOnlyChanged")
    End Sub

    Private Sub DataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.RowEnter
        Dim row As DataRow = GlassDataTable.Rows.Item(e.RowIndex)
        If IsDBNull(row(0)) Then
            Exit Sub
        End If
        Debug.WriteLine("DataGridView_RowEnter::" & e.RowIndex)
        Dim index As Integer = Val(row(0))

        ComboBoxSlotNo.Text = index
        TextBoxGlassID.Text = IIf(IsDBNull(row(3)), "", row(3))
        TextBoxLastOperationID.Text = IIf(IsDBNull(row(8)), "", row(8))
        TextBoxLastProcessLineID.Text = IIf(IsDBNull(row(5)), "", row(5))
        TextBoxProcessToolID.Text = IIf(IsDBNull(row(6)), "", row(6))
        TextBoxDMQCToolID.Text = IIf(IsDBNull(row(7)), "", row(7))
        If IsDBNull(row(4)) Then
            ComboBoxGlassGrade.SelectedIndex = prjSECS.clsEnumCtl.eGlassGrade.OK
        Else
            Try
                ComboBoxGlassGrade.SelectedIndex = [Enum].Parse(GetType(prjSECS.clsEnumCtl.eGlassGrade), row(4))
            Catch ex As Exception
                ComboBoxGlassGrade.SelectedIndex = 0
            End Try
        End If

        If IsDBNull(row(9)) Then
            ComboBoxGlassGrade.SelectedIndex = prjSECS.clsEnumCtl.eDMQCGrade.NO
        Else
            ComboBoxDMQCGrade.SelectedIndex = [Enum].Parse(GetType(prjSECS.clsEnumCtl.eDMQCGrade), row(9))
        End If
        ComboBoxDMQCGrade.SelectedIndex = IIf(IsDBNull(row(9)), prjSECS.clsEnumCtl.eDMQCGrade.NO, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eDMQCGrade), row(9)))
        TextBoxPSHGroup.Text = IIf(IsDBNull(row(10)), "", row(10))
        SetChipGrade(IIf(IsDBNull(row(11)), "", row(11)))
        CheckBoxRework.Checked = IIf(IsDBNull(row(12)), "", row(12))
        ComboBoxScrap.SelectedIndex = IIf(IsDBNull(row(13)), prjSECS.clsEnumCtl.eScrapType.NONE, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eScrapType), row(13)))
        CheckBoxFIRemark.Checked = IIf(IsDBNull(row(14)), "", row(14))
        If row(15) = "B" Then
            CheckBoxFIFCFlag.CheckState = CheckState.Unchecked
        ElseIf row(15) = "F" Then
            CheckBoxFIFCFlag.CheckState = CheckState.Checked
        Else
            CheckBoxFIFCFlag.CheckState = CheckState.Indeterminate
        End If
    End Sub

    Private Sub DataGridView_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Debug.WriteLine("DataGridView_RowLeave")
    End Sub

    Private Sub DataGridViewShowData(Optional ByVal bShowNotExist As Boolean = False)

        GlassDataTable.Rows.Clear()
        For i As Integer = 1 To MAXCASSETTESLOT
            If mInfo.Port(myPort).fGlassExist(i) Or (Not mInfo.Port(myPort).fGlassExist(i) And bShowNotExist) Then
                With _L8B.CIM.LotInfo(myPort).Slots(i)
                    Dim row As DataRow = GlassDataTable.Rows.Add()
                    .SlotNo = i
                    row(0) = Format(.SlotNo, "0#")
                    row(1) = IIf(mInfo.Port(myPort).fGlassExist(i), True, False)
                    row(2) = .ProcFlag
                    row(3) = MyTrim(.GlassID)
                    row(8) = MyTrim(.LastOperationID)
                    row(5) = .LastLineID
                    row(6) = MyTrim(.ProcessToolID)
                    row(7) = MyTrim(.DMQCToolID)
                    row(4) = .GlassGrade.ToString
                    row(9) = .DMQCGrade.ToString
                    row(10) = MyTrim(.PSHGroup)
                    row(11) = .ChipGradeByString
                    row(12) = .Rework
                    row(13) = .Scrap.ToString
                    row(14) = .FIRemark
                    'row(15) = .FIFCFlag.ToString
                    If .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B Then
                        row(15) = "B"
                    ElseIf .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F Then
                        row(15) = "F"
                    Else
                        row(15) = " "
                    End If
                End With
            End If
        Next
        CreateDataGridView()
        DataGridView.DataSource = Nothing
        DataGridView.DataSource = GlassDataTable
        DataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
    End Sub


    Private Sub DataGridViewCIMShowData()
        GlassDataTable.Rows.Clear()
        For i As Integer = 1 To MAXCASSETTESLOT
            If mInfo.Port(myPort).fGlassExist(i) Then
                With _L8B.CIM.LotInfo(myPort).Slots(i)
                    Dim row As DataRow = GlassDataTable.Rows.Add()
                    row(0) = Format(i, "0#")
                    row(1) = IIf(mInfo.Port(myPort).Map(i) = 1, True, False)
                    row(2) = .ProcFlag
                    row(3) = MyTrim(.GlassID)
                    row(8) = MyTrim(.LastPorcessToolID)
                    row(5) = .PLineID
                    row(6) = MyTrim(.ProcessToolID)
                    row(7) = MyTrim(.DMQCToolID)
                    row(4) = .GlassGrade.ToString
                    row(9) = .DMQCGrade.ToString
                    row(10) = MyTrim(.PSHGroup)
                    row(11) = .ChipGradeByString
                    row(12) = .Rework
                    row(13) = .Scrap.ToString
                    row(14) = .FIRemark
                    If .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B Then
                        row(15) = "B"
                    ElseIf .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F Then
                        row(15) = "F"
                    Else
                        row(15) = " "
                    End If
                End With
            Else
                If MyTrim(mInfo.Port(myPort).Glass(i).GlassID).Length > 0 Then
                    WriteLog("WARN:DataGridViewCIMShowData; mInfo.Port(" & myPort & ").GlassID(" & i & ") = " & mInfo.Port(myPort).Glass(i).GlassID, LogMessageType.Warn)
                End If
            End If
        Next
        CreateCIMDataGridView()
        DataGridView.DataSource = Nothing
        DataGridView.DataSource = GlassDataTable
        DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically
    End Sub


    Private Sub DataGridViewShowCIMData()

        GlassDataTable.Rows.Clear()
        For i As Integer = 1 To MAXCASSETTESLOT
            If mInfo.Port(myPort).fGlassExist(i) Then

                With _L8B.CIM.LotInfo(myPort).Slots(i)
                    Dim row As DataRow = GlassDataTable.Rows.Add()
                    .SlotNo = i
                    row(0) = Format(.SlotNo, "0#")
                    row(1) = mInfo.Port(myPort).fGlassExist(i)
                    row(2) = .ProcFlag
                    row(3) = MyTrim(.GlassID)
                    row(8) = MyTrim(.LastOperationID)
                    row(5) = .LastLineID
                    row(6) = MyTrim(.ProcessToolID)
                    row(7) = MyTrim(.DMQCToolID)
                    row(4) = .GlassGrade.ToString
                    row(9) = .DMQCGrade.ToString
                    row(10) = MyTrim(.PSHGroup)
                    row(11) = .ChipGradeByString
                    row(12) = .Rework
                    row(13) = .Scrap.ToString
                    row(14) = .FIRemark
                    'row(15) = .FIFCFlag.ToString
                    If .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B Then
                        row(15) = "B"
                    ElseIf .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F Then
                        row(15) = "F"
                    Else
                        row(15) = " "
                    End If
                End With
            End If
        Next
        CreateDataGridView()
        DataGridView.DataSource = Nothing
        DataGridView.DataSource = GlassDataTable
    End Sub

    Private Sub DataGridViewSaveData()
        For i As Integer = 0 To GlassDataTable.Rows.Count - 1
            Dim row As DataRow = GlassDataTable.Rows.Item(i)
            Dim index As Integer = Val(row(0))
            With _L8B.CIM.LotInfo(myPort).Slots(index)
                .SlotNo = index
                .GlassID = IIf(IsDBNull(row(3)), "", row(3))
                .LastOperationID = IIf(IsDBNull(row(8)), "", row(8))
                .LastLineID = IIf(IsDBNull(row(5)), "", row(5))
                .ProcessToolID = IIf(IsDBNull(row(6)), "", row(6))
                .DMQCToolID = IIf(IsDBNull(row(7)), "", row(7))
                .GlassGrade = IIf(IsDBNull(row(4)), prjSECS.clsEnumCtl.eGlassGrade.OK, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eGlassGrade), row(4)))
                .DMQCGrade = IIf(IsDBNull(row(9)), prjSECS.clsEnumCtl.eDMQCGrade.NO, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eDMQCGrade), row(9)))
                .PSHGroup = IIf(IsDBNull(row(10)), "", row(10))
                .ChipGradeByString = IIf(IsDBNull(row(11)), "", row(11))
                .Rework = IIf(IsDBNull(row(12)), "", row(12))
                .Scrap = IIf(IsDBNull(row(13)), prjSECS.clsEnumCtl.eScrapType.NONE, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eScrapType), row(13)))
                .FIRemark = IIf(IsDBNull(row(14)), "", row(14))
                '.FIFCFlag = IIf(IsDBNull(row(15)), prjsecs.clsEnumCtl.eFIFCFlag.FLAG_NA, [Enum].Parse(GetType(prjsecs.clsEnumCtl.eFIFCFlag), row(15)))
                If row(15) = "B" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                ElseIf row(15) = "F" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                Else
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                End If
            End With
        Next

    End Sub

    Private Sub DataGridViewSaveDataSelectAll()
        For i As Integer = 0 To GlassDataTable.Rows.Count - 1
            Dim row As DataRow = GlassDataTable.Rows.Item(i)
            Dim index As Integer = Val(row(0))
            With _L8B.CIM.LotInfo(myPort).Slots(index)
                .SlotNo = index
                .ProcFlag = True
                .GlassID = IIf(IsDBNull(row(3)), "", row(3))
                .LastOperationID = IIf(IsDBNull(row(8)), "", row(8))
                .LastLineID = IIf(IsDBNull(row(5)), "", row(5))
                .ProcessToolID = IIf(IsDBNull(row(6)), "", row(6))
                .DMQCToolID = IIf(IsDBNull(row(7)), "", row(7))
                .GlassGrade = IIf(IsDBNull(row(4)), prjSECS.clsEnumCtl.eGlassGrade.OK, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eGlassGrade), row(4)))
                .DMQCGrade = IIf(IsDBNull(row(9)), prjSECS.clsEnumCtl.eDMQCGrade.NO, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eDMQCGrade), row(9)))
                .PSHGroup = IIf(IsDBNull(row(10)), "", row(10))
                .ChipGradeByString = IIf(IsDBNull(row(11)), "", row(11))
                .Rework = IIf(IsDBNull(row(12)), "", row(12))
                .Scrap = IIf(IsDBNull(row(13)), prjSECS.clsEnumCtl.eScrapType.NONE, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eScrapType), row(13)))
                .FIRemark = IIf(IsDBNull(row(14)), "", row(14))
                '.FIFCFlag = IIf(IsDBNull(row(15)), prjsecs.clsEnumCtl.eFIFCFlag.FLAG_NA, [Enum].Parse(GetType(prjsecs.clsEnumCtl.eFIFCFlag), row(15)))
                If row(15) = "B" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                ElseIf row(15) = "F" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                Else
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                End If
            End With
        Next

    End Sub


    Private Sub DataGridViewSaveDataDeselectAll()
        For i As Integer = 0 To GlassDataTable.Rows.Count - 1
            Dim row As DataRow = GlassDataTable.Rows.Item(i)
            Dim index As Integer = Val(row(0))
            With _L8B.CIM.LotInfo(myPort).Slots(index)
                .SlotNo = index
                .ProcFlag = False
                .GlassID = IIf(IsDBNull(row(3)), "", row(3))
                .LastOperationID = IIf(IsDBNull(row(8)), "", row(8))
                .LastLineID = IIf(IsDBNull(row(5)), "", row(5))
                .ProcessToolID = IIf(IsDBNull(row(6)), "", row(6))
                .DMQCToolID = IIf(IsDBNull(row(7)), "", row(7))
                .GlassGrade = IIf(IsDBNull(row(4)), prjSECS.clsEnumCtl.eGlassGrade.OK, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eGlassGrade), row(4)))
                .DMQCGrade = IIf(IsDBNull(row(9)), prjSECS.clsEnumCtl.eDMQCGrade.NO, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eDMQCGrade), row(9)))
                .PSHGroup = IIf(IsDBNull(row(10)), "", row(10))
                .ChipGradeByString = IIf(IsDBNull(row(11)), "", row(11))
                .Rework = IIf(IsDBNull(row(12)), "", row(12))
                .Scrap = IIf(IsDBNull(row(13)), prjSECS.clsEnumCtl.eScrapType.NONE, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eScrapType), row(13)))
                .FIRemark = IIf(IsDBNull(row(14)), "", row(14))
                '.FIFCFlag = IIf(IsDBNull(row(15)), prjsecs.clsEnumCtl.eFIFCFlag.FLAG_NA, [Enum].Parse(GetType(prjsecs.clsEnumCtl.eFIFCFlag), row(15)))
                If row(15) = "B" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                ElseIf row(15) = "F" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                Else
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                End If
            End With
        Next

    End Sub



    Private Sub DataGridViewSaveDataInverseSelectAll()
        For i As Integer = 0 To GlassDataTable.Rows.Count - 1
            Dim row As DataRow = GlassDataTable.Rows.Item(i)
            Dim index As Integer = Val(row(0))
            With _L8B.CIM.LotInfo(myPort).Slots(index)
                .SlotNo = index
                .ProcFlag = Not IIf(IsDBNull(row(2)) OrElse row(2) <> "True", False, True)
                .GlassID = IIf(IsDBNull(row(3)), "", row(3))
                .LastOperationID = IIf(IsDBNull(row(8)), "", row(8))
                .LastLineID = IIf(IsDBNull(row(5)), "", row(5))
                .ProcessToolID = IIf(IsDBNull(row(6)), "", row(6))
                .DMQCToolID = IIf(IsDBNull(row(7)), "", row(7))
                .GlassGrade = IIf(IsDBNull(row(4)), prjSECS.clsEnumCtl.eGlassGrade.OK, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eGlassGrade), row(4)))
                .DMQCGrade = IIf(IsDBNull(row(9)), prjSECS.clsEnumCtl.eDMQCGrade.NO, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eDMQCGrade), row(9)))
                .PSHGroup = IIf(IsDBNull(row(10)), "", row(10))
                .ChipGradeByString = IIf(IsDBNull(row(11)), "", row(11))
                .Rework = IIf(IsDBNull(row(12)), "", row(12))
                .Scrap = IIf(IsDBNull(row(13)), prjSECS.clsEnumCtl.eScrapType.NONE, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eScrapType), row(13)))
                .FIRemark = IIf(IsDBNull(row(14)), "", row(14))
                '.FIFCFlag = IIf(IsDBNull(row(15)), prjsecs.clsEnumCtl.eFIFCFlag.FLAG_NA, [Enum].Parse(GetType(prjsecs.clsEnumCtl.eFIFCFlag), row(15)))
                If row(15) = "B" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                ElseIf row(15) = "F" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                Else
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                End If
            End With
        Next

    End Sub

    Private Sub ButtonShowOnlyExistGlass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShowOnlyExistGlass.Click
        If GlassDataTable.Rows.Count > 0 Then
            DataGridViewSaveData()
        End If
        DataGridViewShowData(False)
    End Sub

    Private Sub ButtonAutoFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAutoFill.Click
        Fillout()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If ChipGradeDict.Count = 0 Then
            Exit Sub
        End If
        If NumericUpDown1.Value < 72 Then
            For i As Integer = 1 To NumericUpDown1.Value
                If ChipGradeDict(i).CheckState = CheckState.Indeterminate Then
                    ChipGradeDict(i).CheckState = CheckState.Unchecked
                End If
                ChipGradeDict(i).Enabled = True
            Next
            For i As Integer = NumericUpDown1.Value + 1 To 72
                ChipGradeDict(i).CheckState = CheckState.Indeterminate
                ChipGradeDict(i).Enabled = False
            Next
        Else
            For i As Integer = 1 To 72
                If ChipGradeDict(i).CheckState = CheckState.Indeterminate Then
                    ChipGradeDict(i).CheckState = CheckState.Unchecked
                End If
                ChipGradeDict(i).Enabled = True
            Next
        End If
    End Sub

    Private Function GetChipGrade() As String
        Dim tmpStr As String = ""
        For i As Integer = 1 To NumericUpDown1.Value
            If ChipGradeDict(i).CheckState = CheckState.Checked Then
                tmpStr &= "O"
            ElseIf ChipGradeDict(i).CheckState = CheckState.Unchecked Then
                tmpStr &= "X"
            Else
                tmpStr &= "G"
            End If
            'tmpStr &= IIf(ChipGradeDict(i).Checked, "O", "X")
        Next
        Return tmpStr
    End Function


    Private Sub SetChipGrade(ByVal CGrade As String)

        For i As Integer = 1 To CGrade.Length ' NumericUpDown1.Value
            If i > 72 Then
                Exit For
            End If
            If CGrade(i - 1) = "O" Then
                ChipGradeDict(i).CheckState = CheckState.Checked
            ElseIf CGrade(i - 1) = "X" Then
                ChipGradeDict(i).CheckState = CheckState.Unchecked
            Else
                ChipGradeDict(i).CheckState = CheckState.Indeterminate
            End If
        Next

        For i As Integer = CGrade.Length + 1 To 72 ' NumericUpDown1.Value
            ChipGradeDict(i).CheckState = CheckState.Unchecked
        Next

        For i As Integer = NumericUpDown1.Value + 1 To 72
            ChipGradeDict(i).CheckState = CheckState.Indeterminate
            ChipGradeDict(i).Enabled = False
        Next
    End Sub

    Private Sub ButtonSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSet.Click
        For i As Integer = 1 To MAXCASSETTESLOT
            With _L8B.CIM.LotInfo(myPort).Slots(i)
                If .SlotNo = Val(ComboBoxSlotNo.Text) Then
                    .GlassID = TextBoxGlassID.Text
                    .LastOperationID = TextBoxLastOperationID.Text
                    .LastLineID = TextBoxLastProcessLineID.Text
                    .ProcessToolID = TextBoxProcessToolID.Text
                    .DMQCToolID = TextBoxDMQCToolID.Text
                    .GlassGrade = ComboBoxGlassGrade.SelectedIndex
                    .DMQCGrade = ComboBoxDMQCGrade.SelectedIndex
                    .PSHGroup = TextBoxPSHGroup.Text
                    .ChipGradeByString = GetChipGrade()
                    .Rework = CheckBoxRework.Checked
                    .Scrap = ComboBoxScrap.SelectedIndex
                    .FIRemark = CheckBoxFIRemark.Checked
                    If CheckBoxFIFCFlag.CheckState = CheckState.Checked Then
                        .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F
                    ElseIf CheckBoxFIFCFlag.CheckState = CheckState.Unchecked Then
                        .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                    Else
                        .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                    End If
                End If
            End With
        Next

        DataGridViewShowData()
    End Sub

    Private Sub DialogCassetteInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ReDim fShowColumn(16)
        ComboBoxGlassGrade.SelectedIndex = 1
        ComboBoxDMQCGrade.SelectedIndex = 1
        ComboBoxScrap.SelectedIndex = 0

        With _L8B.Setting.Main
            fShowColumn(1) = True                   'C1_SlotNo
            fShowColumn(2) = True                   'C2_GlassID
            fShowColumn(3) = .fCIMShowColumn(3)     'C3_LastProcessOperationID
            fShowColumn(4) = .fCIMShowColumn(4)     'C4_LastProcessLineID
            fShowColumn(5) = .fCIMShowColumn(5)     'C5_ProcessToolID
            fShowColumn(6) = .fCIMShowColumn(6)     'C6_DMQCToolID
            fShowColumn(7) = .fCIMShowColumn(7)     'C7_GlassGrade
            fShowColumn(8) = .fCIMShowColumn(8)     'C8_DMQCGrade
            fShowColumn(9) = .fCIMShowColumn(9)     'C9_PSHGroup
            fShowColumn(10) = .fCIMShowColumn(10)     'C10_ChipGrade
            fShowColumn(11) = .fCIMShowColumn(11)     'C11_ReworkFlag
            fShowColumn(12) = .fCIMShowColumn(12)     'C12_ScrapFlag
            fShowColumn(13) = .fCIMShowColumn(13)     'C13_FIRemarkFlag
            fShowColumn(14) = .fCIMShowColumn(14)     'C14_FIFCFlag
            fShowColumn(15) = .fCIMShowColumn(15)     'C15_Exist
            fShowColumn(16) = .fCIMShowColumn(16)     'C16_PorcessFlag
        End With


    End Sub

    Private Sub ComboBoxGlassGrade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxGlassGrade.SelectedIndexChanged
        If ComboBoxGlassGrade.SelectedIndex = 0 Then
            ComboBoxGlassGrade.SelectedIndex = 1
        End If
    End Sub

    Private Sub Fillout()
        Debug.WriteLine("ButtonAutoFill start")
        'If DebugMode() Then
        '    mInfo.Port(myPort).Map(50) = 1
        '    mInfo.Port(myPort).Map(49) = 1
        '    mInfo.Port(myPort).Map(48) = 1
        '    mInfo.Port(myPort).Map(47) = 1
        'End If

        ButtonAutoFill.Enabled = False
        GlassDataTable.Rows.Clear()
        Dim GlassCount As Integer = 0
        For i As Integer = 1 To MAXCASSETTESLOT
            If mInfo.Port(myPort).fGlassExist(i) Then
                With _L8B.CIM.LotInfo(myPort).Slots(i)
                    .SlotNo = i
                    If MyTrim(.GlassID).Length = 0 Then
                        If MyTrim(TextBoxGlassID.Text) = "" Then
                            .GlassID = TextBoxCassetteID.Text & "_" & Format(.SlotNo, "0#")
                        Else
                            GlassCount += 1
                            .GlassID = TextBoxGlassID.Text & "_" & Format(GlassCount, "0#")
                        End If
                    End If

                    .LastOperationID = TextBoxLastOperationID.Text
                    .LastLineID = TextBoxLastProcessLineID.Text
                    .ProcessToolID = TextBoxProcessToolID.Text
                    .DMQCToolID = TextBoxDMQCToolID.Text
                    .GlassGrade = IIf(ComboBoxGlassGrade.SelectedIndex <= 0, prjSECS.clsEnumCtl.eGlassGrade.OK, ComboBoxGlassGrade.SelectedIndex)
                    .DMQCGrade = IIf(ComboBoxDMQCGrade.SelectedIndex <= 0, prjSECS.clsEnumCtl.eDMQCGrade.OK, ComboBoxDMQCGrade.SelectedIndex)
                    .PSHGroup = TextBoxPSHGroup.Text
                    .ChipGradeByString = GetChipGrade()
                    .Rework = CheckBoxRework.Checked
                    .Scrap = ComboBoxScrap.SelectedIndex
                    .FIRemark = CheckBoxFIRemark.Checked
                    If CheckBoxFIFCFlag.CheckState = CheckState.Checked Then
                        .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F
                    ElseIf CheckBoxFIFCFlag.CheckState = CheckState.Unchecked Then
                        .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                    Else
                        .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                    End If
                End With
            Else
                With _L8B.CIM.LotInfo(myPort).Slots(i)
                    .SlotNo = i
                    .GlassID = ""
                    .LastOperationID = ""
                    .LastLineID = ""
                    .ProcessToolID = ""
                    .DMQCToolID = ""
                    .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.OK
                    .DMQCGrade = prjSECS.clsEnumCtl.eDMQCGrade.OK
                    .PSHGroup = ""
                    .ChipGradeByString = ""
                    .Rework = False
                    .Scrap = prjSECS.clsEnumCtl.eScrapType.NONE
                    .FIRemark = False
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                End With
            End If
        Next

        For i As Integer = 1 To MAXCASSETTESLOT
            If mInfo.Port(myPort).fGlassExist(i) Then 'Or (mInfo.Port(myPort).Map(i) = 0) Then
                With _L8B.CIM.LotInfo(myPort).Slots(i)
                    Dim row As DataRow = GlassDataTable.Rows.Add()
                    .SlotNo = i
                    row(0) = Format(.SlotNo, "0#")
                    row(1) = mInfo.Port(myPort).fGlassExist(i)
                    row(2) = IIf(_L8B.CIM.LotInfo(myPort).Slots(i).ProcFlag = 1, True, False)
                    row(3) = MyTrim(.GlassID)
                    row(8) = MyTrim(.LastOperationID)
                    row(5) = .LastLineID
                    row(6) = MyTrim(.ProcessToolID)
                    row(7) = MyTrim(.DMQCToolID)
                    row(4) = .GlassGrade.ToString
                    row(9) = .DMQCGrade.ToString
                    row(10) = MyTrim(.PSHGroup)
                    row(11) = .ChipGradeByString
                    row(12) = .Rework
                    row(13) = .Scrap.ToString
                    row(14) = .FIRemark
                    'row(15) = .FIFCFlag.ToString
                    If .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B Then
                        row(15) = "B"
                    ElseIf .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_F Then
                        row(15) = "F"
                    Else
                        row(15) = " "
                    End If
                End With
            End If
        Next
        CreateDataGridView()
        DataGridView.DataSource = Nothing
        DataGridView.DataSource = GlassDataTable
        ButtonAutoFill.Enabled = True
        Debug.WriteLine("ButtonAutoFill End")
    End Sub

    Private Sub ButtonNoGlass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNoGlass.Click
        If GlassDataTable.Rows.Count > 0 Then
            DataGridViewSaveDataDeselectAll()
            DataGridViewShowData(False)
        End If
    End Sub

    Private Sub ButtonInverseSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInverseSelect.Click
        If GlassDataTable.Rows.Count > 0 Then
            DataGridViewSaveDataInverseSelectAll()
            DataGridViewShowData(False)
        End If
    End Sub

    Private Sub ButtonSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectAll.Click
        If GlassDataTable.Rows.Count > 0 Then
            DataGridViewSaveDataSelectAll()
            DataGridViewShowData(False)
        End If
    End Sub

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Close]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        If Cancel_Button.Text = "Cassette Cancel" Then
            If _L8B.CIM.RemoteMode = prjSECS.clsEnumCtl.eRemoteStatus.MODE_OFFLINE Then
                _L8B.PLC.CassetteUnloadRequest(myPort)
            End If
        End If
        Me.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        manualStart()
    End Sub

    Private Sub manualStart()
        Dim PassTest As Boolean = True
        ButtonManualStart.Enabled = False
        _L8B.CIM.LotInfo(myPort).CassetteID = "CST" & myPort

        WriteLog("ManualStart: Port" & myPort & " Samples.Value=" & NumericUpDownIModeSamples.Value, LogMessageType.Info)
        With _L8B.CIM.LotInfo(myPort)
            .RecipeName = ComboBoxPPID.Text
            .DateTime = GetAUODateTime(Now)
            .PortPosition = myPort
            .OperationID = TextBoxOperationID.Text
            .ProductCode = MyTrim(TextBoxProductCode.Text)
            .MeasurementID = TextBoxMeasurementID.Text
            .IsLotDataReceived = False

            Select Case ComboBoxProductCategory.Text
                Case "DUMMY"
                    .ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_DUMMY
                Case "INITIAL"
                    .ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_INITIAL
                Case "MONITOR"
                    .ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_MONITOR
                Case "PRODUCT"
                    .ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_PRODUCT
                Case Else
                    .ProductCategory = prjSECS.clsEnumCtl.eProductCategory.PRODCAT_NONE
            End Select
            If .ProductCode = "" Then
                PassTest = False
            End If
            If .RecipeName = "" Then
                PassTest = False
            End If
        End With


        Dim GlassProcessCount As Integer = 0
        For i As Integer = 0 To GlassDataTable.Rows.Count - 1
            Dim row As DataRow = GlassDataTable.Rows.Item(i)
            Dim index As Integer = Val(row(0))
            With _L8B.CIM.LotInfo(myPort).Slots(index)
                .SlotNo = index
                .GlassID = IIf(IsDBNull(row(3)), "", row(3))
                .LastOperationID = IIf(IsDBNull(row(8)), "", row(8))
                .LastLineID = IIf(IsDBNull(row(5)), "", row(5))
                .ProcessToolID = IIf(IsDBNull(row(6)), "", row(6))
                .DMQCToolID = IIf(IsDBNull(row(7)), "", row(7))
                .GlassGrade = IIf(IsDBNull(row(4)), prjSECS.clsEnumCtl.eGlassGrade.OK, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eGlassGrade), row(4)))
                If .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.NO Then .GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.OK
                .DMQCGrade = IIf(IsDBNull(row(9)), prjSECS.clsEnumCtl.eDMQCGrade.NO, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eDMQCGrade), row(9)))
                .PSHGroup = IIf(IsDBNull(row(10)), "", row(10))
                .ChipGradeByString = IIf(IsDBNull(row(11)), "", row(11))
                .Rework = IIf(IsDBNull(row(12)), "", row(12))
                .Scrap = IIf(IsDBNull(row(13)), prjSECS.clsEnumCtl.eScrapType.NONE, [Enum].Parse(GetType(prjSECS.clsEnumCtl.eScrapType), row(13)))
                .FIRemark = IIf(IsDBNull(row(14)), "", row(14))

                '.FIFCFlag = IIf(IsDBNull(row(15)), prjsecs.clsEnumCtl.eFIFCFlag.FLAG_NA, [Enum].Parse(GetType(prjsecs.clsEnumCtl.eFIFCFlag), row(15)))
                If row(15) = "B" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                ElseIf row(15) = "F" Then
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_B
                Else
                    .FIFCFlag = prjSECS.clsEnumCtl.eFIFCFlag.FLAG_NA
                End If

                If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
                    .ProcFlag = IIf(IsDBNull(row(2)) OrElse row(2) <> "True", False, True)
                    GlassProcessCount += IIf(.ProcFlag, 1, 0)
                ElseIf _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
                    If GlassProcessCount <= NumericUpDownIModeSamples.Value AndAlso mInfo.Port(myPort).fGlassExist(.SlotNo) Then
                        .ProcFlag = True
                        GlassProcessCount += IIf(.ProcFlag, 1, 0)
                    End If
                End If

                If .GlassID = "" Then
                    PassTest = False
                End If
            End With
        Next

        mInfo.Port(myPort).Recipe = _L8B.db.LoadRecipe(MyTrim(_L8B.CIM.LotInfo(myPort).RecipeName))

        If _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_U Then
            'mInfo.Port(myPort).Recipe.SampleGlass = GlassProcessCount
            If GlassProcessCount <= 0 Then
                WriteLog("ManualStart Port:" & myPort & " U Mode Selected Glass count = " & GlassProcessCount)
                ButtonManualStart.Enabled = True
                _L8B.Log.Hide()
                MsgBox("Please select some glasses that need to be processed; and try Again.", MsgBoxStyle.OkOnly, "Cassette info")
                Exit Sub
            End If
            WriteLog("ManualStart Port:" & myPort & " U Mode Selected Glass count = " & GlassProcessCount)

        ElseIf _L8B.Setting.Main.GlassFlowMode = prjSECS.clsEnumCtl.ePortType.TYPE_I Then
            mInfo.Port(myPort).Recipe.SampleGlass = NumericUpDownIModeSamples.Value
            WriteLog("ManualStart(I) Port:" & myPort & " SampleGlass = " & mInfo.Port(myPort).Recipe.SampleGlass)
        End If


        Select Case _L8B.Setting.Main.MachineType
            Case ClsSetting.EMACHINETYPE.COLORREPAIR, ClsSetting.EMACHINETYPE.REPAIR
                Dim GrayGlassCount As Integer = 0
                For i As Integer = 0 To GlassDataTable.Rows.Count - 1
                    Dim row As DataRow = GlassDataTable.Rows.Item(i)
                    Dim index As Integer = Val(row(0))
                    If _L8B.CIM.LotInfo(myPort).Slots(index).GlassGrade = prjSECS.clsEnumCtl.eGlassGrade.GRAY Then
                        GrayGlassCount += 1
                    End If
                Next
                If GrayGlassCount = 0 Then
                    WriteLog("ManualStart(I) Port:" & myPort & " GrayGlassCount = " & GrayGlassCount)
                    PassTest = False
                End If
        End Select

        If PassTest Then
            Me.Hide()
        Else
            ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Error, "Some of the paramenter is wrong, please check and try again.", MsgBoxStyle.OkOnly, 0, MsgBoxResult.No, False, 1)
            ButtonManualStart.Enabled = True
            Exit Sub
        End If

        Dim ShowMsg As New DialogMessage
        ShowMsg.ShowMessage(DialogMessage.MESSAGE.None, DialogMessage.MESSAGELEVEL.Info, "Please WAIT for sending Process Data to PLC!", MsgBoxStyle.OkOnly, 20, MsgBoxResult.Ok, False, 0)
        InsertPortGlassData(myPort)
        _L8B.PLC.UploadLotData(myPort)
        'ButtonManualStart.Enabled = True
        ShowMsg.Dispose()
        Me.Hide()
    End Sub
End Class
