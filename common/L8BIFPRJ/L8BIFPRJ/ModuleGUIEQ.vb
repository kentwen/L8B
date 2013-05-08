Module ModuleGUIEQ

    Public WithEvents MyctlEQGUIMain As New ctlEQGUIMain

    Private Const MAX_GUIRST_ADDR_LEN = 383
    Private Const MAX_GUIEQ_ADDR_LEN = 71
    Private Const MAX_GUI_EQ_ALARM_A_LEN = 511
    Private Const MAX_ALARM = 512

    Private Const MAX_GUI_WORD_ADDR_LEN = 127

    Public m_anGUI_RST_To_EQ_New_BIT(MAX_GUIRST_ADDR_LEN) As Integer
    Public m_anGUI_EQ1_New_BIT(MAX_GUIEQ_ADDR_LEN) As Integer
    Public m_anGUI_EQ2_New_BIT(MAX_GUIEQ_ADDR_LEN) As Integer
    Public m_anGUI_EQ3_New_BIT(MAX_GUIEQ_ADDR_LEN) As Integer

    Private m_anGUI_EQ1Alarm_New_BIT(MAX_ALARM) As Integer
    Private m_anGUI_EQ2Alarm_New_BIT(MAX_ALARM) As Integer
    Private m_anGUI_EQ3Alarm_New_BIT(MAX_ALARM) As Integer

    Private m_anGUIEQ1_RSTtoEQWord(MAX_GUI_WORD_ADDR_LEN) As Integer
    Private m_anGUIEQ1_EQtoRSTWord(MAX_GUI_WORD_ADDR_LEN) As Integer

    Private m_anGUIEQ2_RSTtoEQWord(MAX_GUI_WORD_ADDR_LEN) As Integer
    Private m_anGUIEQ2_EQtoRSTWord(MAX_GUI_WORD_ADDR_LEN) As Integer

    Private m_anGUIEQ3_RSTtoEQWord(MAX_GUI_WORD_ADDR_LEN) As Integer
    Private m_anGUIEQ3_EQtoRSTWord(MAX_GUI_WORD_ADDR_LEN) As Integer

    Public g_fMyEQGUITimerStart As Boolean



    Enum eEQStartAddr
        RST_START_ADDR = &H0
        EQ1_START_ADDR = &H300
        EQ2_START_ADDR = &H700
        EQ3_START_ADDR = &H1000
        EQ1_ALARM_START_ADDR = &H380
        EQ2_ALARM_START_ADDR = &H780
        EQ3_ALARM_START_ADDR = &H1080

        EQ1_RST_WORD_START_ADDR = &H0
        EQ1_EQ_WORD_START_ADDR = &H300

        EQ2_RST_WORD_START_ADDR = &H80
        EQ2_EQ_WORD_START_ADDR = &H700

        EQ3_RST_WORD_START_ADDR = &H100
        EQ3_EQ_WORD_START_ADDR = &H1000

    End Enum

    Enum eEQGUI_EQ_Word_DevicNo
        EQ_STATUS = 0
        EQ_TOOL_ID_W1 = 2
        EQ_TOOL_ID_W4 = 5

        GX_DATA_SAMPLE_GX_FLAG = 16
        GX_DATA_SLOT_INFO = 17
        GX_DATA_PROCESS_RESULT = 18
        GX_DATA_PSH_GROUP = 19
        GX_DATA_CHIP_GRADE_1 = 21
        GX_DATA_CHIP_GRADE_2 = 22
        GX_DATA_CHIP_GRADE_3 = 23
        GX_DATA_CHIP_GRADE_4 = 24
        GX_DATA_CHIP_GRADE_5 = 25
        GX_DATA_CHIP_GRADE_6 = 26
        GX_DATA_CHIP_GRADE_7 = 27
        GX_DATA_CHIP_GRADE_8 = 28
        GX_DATA_CHIP_GRADE_9 = 29
        GX_DATA_GXID_W1 = 32
        GX_DATA_GXID_W6 = 37

        RECIPE_MODIFY_PPID_W1 = 48
        RECIPE_MODIFY_PPID_W2 = 49
        RECIPE_MODIFY_TYPE = 50

        ERASE_GLASS_ID_W1 = 8
        ERASE_GLASS_ID_W6 = 13

        RECIPE_CHECK_RESULT = 14
    End Enum

    Enum eEQGUI_RST_Word_DevicNo
        RST_STATION_MODE = 0
        RST_REMOTE_STATUS = 1

        GX_DATA_SAMPLE_GX_FLAG = 16
        GX_DATA_PRODUCT_CATEGORY = 17
        GX_DATA_SLOT_INFO = 18
        GX_DATA_GXID_W1 = 19
        GX_DATA_GXID_W6 = 24
        GX_DATA_EPPID_W1 = 25
        GX_DATA_EPPID_W2 = 26
        GX_DATA_MESID_W1 = 28
        GX_DATA_MESID_W4 = 31
        GX_DATA_PRODUCT_CODE_W1 = 32
        GX_DATA_PRODUCT_CODE_W13 = 44
        GX_DATA_CURRENT_PRCIPE_W1 = 48
        GX_DATA_CURRENT_PRCIPE_W16 = 63
        GX_DATA_POPERID_W1 = 64
        GX_DATA_POPERID_W13 = 76
        GX_DATA_PLINEID_W1 = 80
        GX_DATA_PLINEID_W4 = 83
        GX_DATA_PTOOLID_W1 = 88
        GX_DATA_PTOOLID_W4 = 91
        GX_DATA_CSTID_W1 = 96
        GX_DATA_CSTID_W3 = 98
        GX_DATA_OPERATIONID_W1 = 100
        GX_DATA_OPERATIONID_W13 = 112
        GX_DATA_GX_GRADE = 114
        GX_DATA_DMQC_GRADE = 115
        GX_DATA_GX_SCRAP_FLAG = 116
        GX_DATA_MPA_FLAG = 120

        RECIPE_CHECK_EPPID_W1 = 14
        RECIPE_CHECK_EPPID_W2 = 15
    End Enum

    Enum eEQGUI_EQ_Bit_Word_DevicNo
        GX_EXIST_ON_STAGE = 16
        GX_IN_PROCESS = 17
        HANDOFF_AVAILAVLE = 18

        ALARM_OCCURRED = 21
        MPA1_STOP = 22
        MPA2_STOP = 23

        'AlarmOccurred
    End Enum


    Public Sub ScanGUIEQBitAddr()
        Dim nFor As Integer
        Dim afReadRSTBitData(MAX_GUIRST_ADDR_LEN) As Boolean
        Dim afReadEQ1BitData(MAX_GUIEQ_ADDR_LEN) As Boolean
        Dim afReadEQ2BitData(MAX_GUIEQ_ADDR_LEN) As Boolean
        Dim afReadEQ3BitData(MAX_GUIEQ_ADDR_LEN) As Boolean
        Dim aReadEQ1AlarmBit(MAX_GUI_EQ_ALARM_A_LEN) As Boolean
        Dim aReadEQ2AlarmBit(MAX_GUI_EQ_ALARM_A_LEN) As Boolean
        Dim aReadEQ3AlarmBit(MAX_GUI_EQ_ALARM_A_LEN) As Boolean

        Dim anReadEQ1RSTtoEQWord(MAX_GUIRST_ADDR_LEN) As Integer
        Dim anReadEQ1EQtoRSTWord(MAX_GUIRST_ADDR_LEN) As Integer

        Dim anReadEQ2RSTtoEQWord(MAX_GUIRST_ADDR_LEN) As Integer
        Dim anReadEQ2EQtoRSTWord(MAX_GUIRST_ADDR_LEN) As Integer

        Dim anReadEQ3RSTtoEQWord(MAX_GUIRST_ADDR_LEN) As Integer
        Dim anReadEQ3EQtoRSTWord(MAX_GUIRST_ADDR_LEN) As Integer

        Call ReadBAddr(eEQStartAddr.RST_START_ADDR, afReadRSTBitData)
        For nFor = 0 To MAX_GUIRST_ADDR_LEN
            If afReadRSTBitData(nFor) Then
                m_anGUI_RST_To_EQ_New_BIT(nFor) = SIGNAL_ON
            Else
                m_anGUI_RST_To_EQ_New_BIT(nFor) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eEQStartAddr.EQ1_START_ADDR, afReadEQ1BitData)
        For nFor = 0 To MAX_GUIEQ_ADDR_LEN
            If afReadEQ1BitData(nFor) Then
                m_anGUI_EQ1_New_BIT(nFor) = SIGNAL_ON
            Else
                m_anGUI_EQ1_New_BIT(nFor) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eEQStartAddr.EQ2_START_ADDR, afReadEQ2BitData)
        For nFor = 0 To MAX_GUIEQ_ADDR_LEN
            If afReadEQ2BitData(nFor) Then
                m_anGUI_EQ2_New_BIT(nFor) = SIGNAL_ON
            Else
                m_anGUI_EQ2_New_BIT(nFor) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eEQStartAddr.EQ3_START_ADDR, afReadEQ3BitData)
        For nFor = 0 To MAX_GUIEQ_ADDR_LEN
            If afReadEQ3BitData(nFor) Then
                m_anGUI_EQ3_New_BIT(nFor) = SIGNAL_ON
            Else
                m_anGUI_EQ3_New_BIT(nFor) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eEQStartAddr.EQ1_ALARM_START_ADDR, aReadEQ1AlarmBit)
        For nFor = 0 To MAX_GUI_EQ_ALARM_A_LEN
            If aReadEQ1AlarmBit(nFor) Then
                m_anGUI_EQ1Alarm_New_BIT(nFor + 1) = SIGNAL_ON
            Else
                m_anGUI_EQ1Alarm_New_BIT(nFor + 1) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eEQStartAddr.EQ2_ALARM_START_ADDR, aReadEQ2AlarmBit)
        For nFor = 0 To MAX_GUI_EQ_ALARM_A_LEN
            If aReadEQ2AlarmBit(nFor) Then
                m_anGUI_EQ2Alarm_New_BIT(nFor + 1) = SIGNAL_ON
            Else
                m_anGUI_EQ2Alarm_New_BIT(nFor + 1) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eEQStartAddr.EQ3_ALARM_START_ADDR, aReadEQ3AlarmBit)
        For nFor = 0 To MAX_GUI_EQ_ALARM_A_LEN
            If aReadEQ3AlarmBit(nFor) Then
                m_anGUI_EQ3Alarm_New_BIT(nFor + 1) = SIGNAL_ON
            Else
                m_anGUI_EQ3Alarm_New_BIT(nFor + 1) = SIGNAL_OFF
            End If
        Next

        '------------------------------------------------------------------------------
        Call ReadWAddr(eEQStartAddr.EQ1_RST_WORD_START_ADDR, anReadEQ1RSTtoEQWord)
        For nFor = 0 To MAX_GUI_WORD_ADDR_LEN
            m_anGUIEQ1_RSTtoEQWord(nFor) = anReadEQ1RSTtoEQWord(nFor)
        Next

        Call ReadWAddr(eEQStartAddr.EQ1_EQ_WORD_START_ADDR, anReadEQ1EQtoRSTWord)
        For nFor = 0 To MAX_GUI_WORD_ADDR_LEN
            m_anGUIEQ1_EQtoRSTWord(nFor) = anReadEQ1EQtoRSTWord(nFor)
        Next
        '------------------------------------------------------------------------------
        Call ReadWAddr(eEQStartAddr.EQ2_RST_WORD_START_ADDR, anReadEQ2RSTtoEQWord)
        For nFor = 0 To MAX_GUI_WORD_ADDR_LEN
            m_anGUIEQ2_RSTtoEQWord(nFor) = anReadEQ2RSTtoEQWord(nFor)
        Next

        Call ReadWAddr(eEQStartAddr.EQ2_EQ_WORD_START_ADDR, anReadEQ2EQtoRSTWord)
        For nFor = 0 To MAX_GUI_WORD_ADDR_LEN
            m_anGUIEQ2_EQtoRSTWord(nFor) = anReadEQ2EQtoRSTWord(nFor)
        Next
        '------------------------------------------------------------------------------
        Call ReadWAddr(eEQStartAddr.EQ3_RST_WORD_START_ADDR, anReadEQ3RSTtoEQWord)
        For nFor = 0 To MAX_GUI_WORD_ADDR_LEN
            m_anGUIEQ3_RSTtoEQWord(nFor) = anReadEQ3RSTtoEQWord(nFor)
        Next

        Call ReadWAddr(eEQStartAddr.EQ3_EQ_WORD_START_ADDR, anReadEQ3EQtoRSTWord)
        For nFor = 0 To MAX_GUI_WORD_ADDR_LEN
            m_anGUIEQ3_EQtoRSTWord(nFor) = anReadEQ3EQtoRSTWord(nFor)
        Next


        Call OutputEQSignalToGUI()
    End Sub

#Region "Return GUI Word Value"
    Public Sub ReadEQGUIRecipeCheck(ByRef strPPID() As String, ByRef nRecipeCheckResult() As Integer)
        Dim nFor As Integer

        For nFor = eEQGUI_RST_Word_DevicNo.RECIPE_CHECK_EPPID_W1 To eEQGUI_RST_Word_DevicNo.RECIPE_CHECK_EPPID_W2
            strPPID(1) = strPPID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.RECIPE_CHECK_EPPID_W1 To eEQGUI_RST_Word_DevicNo.RECIPE_CHECK_EPPID_W2
            strPPID(2) = strPPID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.RECIPE_CHECK_EPPID_W1 To eEQGUI_RST_Word_DevicNo.RECIPE_CHECK_EPPID_W2
            strPPID(3) = strPPID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        nRecipeCheckResult(1) = m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.RECIPE_CHECK_RESULT)
        nRecipeCheckResult(2) = m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.RECIPE_CHECK_RESULT)
        nRecipeCheckResult(3) = m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.RECIPE_CHECK_RESULT)
    End Sub

    Public Sub ReadEQGUIGxErase(ByRef strGxID() As String)
        Dim nFor As Integer

        For nFor = eEQGUI_EQ_Word_DevicNo.ERASE_GLASS_ID_W1 To eEQGUI_EQ_Word_DevicNo.ERASE_GLASS_ID_W6
            strGxID(1) = strGxID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_EQtoRSTWord(nFor))
        Next

        For nFor = eEQGUI_EQ_Word_DevicNo.ERASE_GLASS_ID_W1 To eEQGUI_EQ_Word_DevicNo.ERASE_GLASS_ID_W6
            strGxID(2) = strGxID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_EQtoRSTWord(nFor))
        Next

        For nFor = eEQGUI_EQ_Word_DevicNo.ERASE_GLASS_ID_W1 To eEQGUI_EQ_Word_DevicNo.ERASE_GLASS_ID_W6
            strGxID(3) = strGxID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_EQtoRSTWord(nFor))
        Next

    End Sub

    Public Sub ReadEQGUIRecipeModify(ByRef strPPID() As String, ByRef nModifyType() As Integer)
        Dim nFor As Integer

        For nFor = eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_PPID_W1 To eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_PPID_W2
            strPPID(1) = strPPID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_EQtoRSTWord(nFor))
        Next

        For nFor = eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_PPID_W1 To eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_PPID_W2
            strPPID(2) = strPPID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_EQtoRSTWord(nFor))
        Next

        For nFor = eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_PPID_W1 To eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_PPID_W2
            strPPID(3) = strPPID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_EQtoRSTWord(nFor))
        Next

        nModifyType(1) = m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_TYPE)
        nModifyType(2) = m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_TYPE)
        nModifyType(3) = m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.RECIPE_MODIFY_TYPE)

    End Sub

    Public Sub ReadEQGUIUnloadGx(ByRef strChipGraade() As String, ByRef strGxID() As String, ByRef nProcessResult() As Integer, ByRef strPSH() As String, ByRef nSampleGxFl() As Integer, ByRef nSlotInfo() As Integer)
        Dim strEQ1ChipGrade(9) As String
        Dim strEQ2ChipGrade(9) As String
        Dim strEQ3ChipGrade(9) As String
        Dim nFor As Integer

        strEQ1ChipGrade(1) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_1))
        strEQ1ChipGrade(2) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_2))
        strEQ1ChipGrade(3) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_3))
        strEQ1ChipGrade(4) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_4))
        strEQ1ChipGrade(5) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_5))
        strEQ1ChipGrade(6) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_6))
        strEQ1ChipGrade(7) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_7))
        strEQ1ChipGrade(8) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_8))
        strEQ1ChipGrade(9) = HexLeadZero(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_9))

        strEQ2ChipGrade(1) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_1))
        strEQ2ChipGrade(2) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_2))
        strEQ2ChipGrade(3) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_3))
        strEQ2ChipGrade(4) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_4))
        strEQ2ChipGrade(5) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_5))
        strEQ2ChipGrade(6) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_6))
        strEQ2ChipGrade(7) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_7))
        strEQ2ChipGrade(8) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_8))
        strEQ2ChipGrade(9) = HexLeadZero(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_9))

        strEQ3ChipGrade(1) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_1))
        strEQ3ChipGrade(2) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_2))
        strEQ3ChipGrade(3) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_3))
        strEQ3ChipGrade(4) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_4))
        strEQ3ChipGrade(5) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_5))
        strEQ3ChipGrade(6) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_6))
        strEQ3ChipGrade(7) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_7))
        strEQ3ChipGrade(8) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_8))
        strEQ3ChipGrade(9) = HexLeadZero(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_CHIP_GRADE_9))

        strChipGraade(1) = strEQ1ChipGrade(1) & "/" & strEQ1ChipGrade(2) & "/" & strEQ1ChipGrade(3) & "/" & strEQ1ChipGrade(4) & "/" & strEQ1ChipGrade(5) & "/" & strEQ1ChipGrade(6) & "/" & strEQ1ChipGrade(7) & "/" & strEQ1ChipGrade(8) & "/" & strEQ1ChipGrade(9)
        strChipGraade(2) = strEQ2ChipGrade(1) & "/" & strEQ2ChipGrade(2) & "/" & strEQ2ChipGrade(3) & "/" & strEQ2ChipGrade(4) & "/" & strEQ2ChipGrade(5) & "/" & strEQ2ChipGrade(6) & "/" & strEQ2ChipGrade(7) & "/" & strEQ2ChipGrade(8) & "/" & strEQ2ChipGrade(9)
        strChipGraade(3) = strEQ3ChipGrade(1) & "/" & strEQ3ChipGrade(2) & "/" & strEQ3ChipGrade(3) & "/" & strEQ3ChipGrade(4) & "/" & strEQ3ChipGrade(5) & "/" & strEQ3ChipGrade(6) & "/" & strEQ3ChipGrade(7) & "/" & strEQ3ChipGrade(8) & "/" & strEQ3ChipGrade(9)

        For nFor = eEQGUI_EQ_Word_DevicNo.GX_DATA_GXID_W1 To eEQGUI_EQ_Word_DevicNo.GX_DATA_GXID_W6
            strGxID(1) = strGxID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_EQtoRSTWord(nFor))
        Next

        For nFor = eEQGUI_EQ_Word_DevicNo.GX_DATA_GXID_W1 To eEQGUI_EQ_Word_DevicNo.GX_DATA_GXID_W6
            strGxID(2) = strGxID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_EQtoRSTWord(nFor))
        Next

        For nFor = eEQGUI_EQ_Word_DevicNo.GX_DATA_GXID_W1 To eEQGUI_EQ_Word_DevicNo.GX_DATA_GXID_W6
            strGxID(3) = strGxID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_EQtoRSTWord(nFor))
        Next

        nProcessResult(1) = m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_PROCESS_RESULT)
        nProcessResult(2) = m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_PROCESS_RESULT)
        nProcessResult(3) = m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_PROCESS_RESULT)

        strPSH(1) = ConvertHiLowASCIIToString(m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_PSH_GROUP))
        strPSH(2) = ConvertHiLowASCIIToString(m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_PSH_GROUP))
        strPSH(3) = ConvertHiLowASCIIToString(m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_PSH_GROUP))

        nSampleGxFl(1) = m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_SAMPLE_GX_FLAG)
        nSampleGxFl(2) = m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_SAMPLE_GX_FLAG)
        nSampleGxFl(3) = m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_SAMPLE_GX_FLAG)

        nSlotInfo(1) = m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_SLOT_INFO)
        nSlotInfo(2) = m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_SLOT_INFO)
        nSlotInfo(3) = m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.GX_DATA_SLOT_INFO)

    End Sub

    Public Sub ReadEQGUILoadGx3(ByRef nProductCategory() As Integer, ByRef strProductCode() As String, ByRef strPToolID() As String, ByRef nSampleGxFlag() As Integer, ByRef nSlotInfo() As Integer)
        Dim nFor As Integer

        nProductCategory(1) = m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CATEGORY)
        nProductCategory(2) = m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CATEGORY)
        nProductCategory(3) = m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CATEGORY)

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CODE_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CODE_W13
            strProductCode(1) = strProductCode(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CODE_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CODE_W13
            strProductCode(2) = strProductCode(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CODE_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PRODUCT_CODE_W13
            strProductCode(3) = strProductCode(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PTOOLID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PTOOLID_W4
            strPToolID(1) = strPToolID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PTOOLID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PTOOLID_W4
            strPToolID(2) = strPToolID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PTOOLID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PTOOLID_W4
            strPToolID(3) = strPToolID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        nSampleGxFlag(1) = m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_SAMPLE_GX_FLAG)
        nSampleGxFlag(2) = m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_SAMPLE_GX_FLAG)
        nSampleGxFlag(3) = m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_SAMPLE_GX_FLAG)

        nSlotInfo(1) = m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_SLOT_INFO)
        nSlotInfo(2) = m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_SLOT_INFO)
        nSlotInfo(3) = m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_SLOT_INFO)
    End Sub

    Public Sub ReadEQGUILoadGx2(ByRef strGxScrapFlag() As String, ByRef strMESID() As String, ByRef nMPAFlag() As Integer, ByRef strOperationID() As String, ByRef strPLineID() As String, ByRef strPoperID() As String)
        Dim nFor As Integer

        strGxScrapFlag(1) = ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_GX_SCRAP_FLAG))
        strGxScrapFlag(2) = ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_GX_SCRAP_FLAG))
        strGxScrapFlag(3) = ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_GX_SCRAP_FLAG))

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_MESID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_MESID_W4
            strMESID(1) = strMESID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_MESID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_MESID_W4
            strMESID(2) = strMESID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_MESID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_MESID_W4
            strMESID(3) = strMESID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        nMPAFlag(1) = m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_MPA_FLAG)
        nMPAFlag(2) = m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_MPA_FLAG)
        nMPAFlag(3) = m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_MPA_FLAG)

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_OPERATIONID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_OPERATIONID_W13
            strOperationID(1) = strOperationID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_OPERATIONID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_OPERATIONID_W13
            strOperationID(2) = strOperationID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_OPERATIONID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_OPERATIONID_W13
            strOperationID(3) = strOperationID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PLINEID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PLINEID_W4
            strPLineID(1) = strPLineID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PLINEID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PLINEID_W4
            strPLineID(2) = strPLineID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_PLINEID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_PLINEID_W4
            strPLineID(3) = strPLineID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_POPERID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_POPERID_W13
            strPoperID(1) = strPoperID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_POPERID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_POPERID_W13
            strPoperID(2) = strPoperID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_POPERID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_POPERID_W13
            strPoperID(3) = strPoperID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next
    End Sub

    Public Sub ReadEQGUILoadGx1(ByRef strCSTID() As String, ByRef strCurrentRecipe() As String, ByRef strDMQCGrade() As String, ByRef strEPPID() As String, ByRef strGxGrade() As String, ByRef strGxID() As String)
        Dim nFor As Integer

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_CSTID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_CSTID_W3
            strCSTID(1) = strCSTID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_CSTID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_CSTID_W3
            strCSTID(2) = strCSTID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_CSTID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_CSTID_W3
            strCSTID(3) = strCSTID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_CURRENT_PRCIPE_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_CURRENT_PRCIPE_W16
            strCurrentRecipe(1) = strCurrentRecipe(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_CURRENT_PRCIPE_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_CURRENT_PRCIPE_W16
            strCurrentRecipe(2) = strCurrentRecipe(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_CURRENT_PRCIPE_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_CURRENT_PRCIPE_W16
            strCurrentRecipe(3) = strCurrentRecipe(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        strDMQCGrade(1) = ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_DMQC_GRADE))
        strDMQCGrade(2) = ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_DMQC_GRADE))
        strDMQCGrade(3) = ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_DMQC_GRADE))

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_EPPID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_EPPID_W2
            strEPPID(1) = strEPPID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_EPPID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_EPPID_W2
            strEPPID(2) = strEPPID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_EPPID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_EPPID_W2
            strEPPID(3) = strEPPID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next

        strGxGrade(1) = ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_GX_GRADE))
        strGxGrade(2) = ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_GX_GRADE))
        strGxGrade(3) = ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.GX_DATA_GX_GRADE))

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_GXID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_GXID_W6
            strGxID(1) = strGxID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_GXID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_GXID_W6
            strGxID(2) = strGxID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_RSTtoEQWord(nFor))
        Next

        For nFor = eEQGUI_RST_Word_DevicNo.GX_DATA_GXID_W1 To eEQGUI_RST_Word_DevicNo.GX_DATA_GXID_W6
            strGxID(3) = strGxID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_RSTtoEQWord(nFor))
        Next
    End Sub

    Public Sub ReadEQGUIStatus(ByRef nEQStatus() As Integer, ByRef strToolID() As String, ByRef nGxExistOnStage() As Integer, ByRef nGxInProcess() As Integer, ByRef nHandoffAvailable() As Integer, ByRef nAlarmOccurred() As Integer, ByRef nMPA1Stop() As Integer, ByRef nMPA2Stop() As Integer, ByRef nStationMode() As Integer, ByRef nRemoteStatus() As Integer)
        Dim nFor As Integer

        'EQ Word
        nEQStatus(1) = m_anGUIEQ1_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.EQ_STATUS)
        For nFor = eEQGUI_EQ_Word_DevicNo.EQ_TOOL_ID_W1 To eEQGUI_EQ_Word_DevicNo.EQ_TOOL_ID_W4
            strToolID(1) = strToolID(1) & ConvertHiLowASCIIToString(m_anGUIEQ1_EQtoRSTWord(nFor))
        Next

        nGxExistOnStage(1) = m_anGUI_EQ1_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.GX_EXIST_ON_STAGE)
        nGxInProcess(1) = m_anGUI_EQ1_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.GX_IN_PROCESS)
        nHandoffAvailable(1) = m_anGUI_EQ1_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.HANDOFF_AVAILAVLE)
        nAlarmOccurred(1) = m_anGUI_EQ1_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.ALARM_OCCURRED)
        nMPA1Stop(1) = m_anGUI_EQ1_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.MPA1_STOP)
        nMPA2Stop(1) = m_anGUI_EQ1_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.MPA2_STOP)

        'RST Word
        nStationMode(1) = m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.RST_STATION_MODE)
        nRemoteStatus(1) = m_anGUIEQ1_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.RST_REMOTE_STATUS)
        '----------------------------------------------------------------------------------------------------
        'EQ Word
        nEQStatus(2) = m_anGUIEQ2_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.EQ_STATUS)
        For nFor = eEQGUI_EQ_Word_DevicNo.EQ_TOOL_ID_W1 To eEQGUI_EQ_Word_DevicNo.EQ_TOOL_ID_W4
            strToolID(2) = strToolID(2) & ConvertHiLowASCIIToString(m_anGUIEQ2_EQtoRSTWord(nFor))
        Next

        nGxExistOnStage(2) = m_anGUI_EQ2_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.GX_EXIST_ON_STAGE)
        nGxInProcess(2) = m_anGUI_EQ2_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.GX_IN_PROCESS)
        nHandoffAvailable(2) = m_anGUI_EQ2_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.HANDOFF_AVAILAVLE)
        nAlarmOccurred(2) = m_anGUI_EQ2_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.ALARM_OCCURRED)
        nMPA1Stop(2) = m_anGUI_EQ2_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.MPA1_STOP)
        nMPA2Stop(2) = m_anGUI_EQ2_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.MPA2_STOP)

        'RST Word
        nStationMode(2) = m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.RST_STATION_MODE)
        nRemoteStatus(2) = m_anGUIEQ2_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.RST_REMOTE_STATUS)
        '----------------------------------------------------------------------------------------------------
        'EQ Word
        nEQStatus(3) = m_anGUIEQ3_EQtoRSTWord(eEQGUI_EQ_Word_DevicNo.EQ_STATUS)
        For nFor = eEQGUI_EQ_Word_DevicNo.EQ_TOOL_ID_W1 To eEQGUI_EQ_Word_DevicNo.EQ_TOOL_ID_W4
            strToolID(3) = strToolID(3) & ConvertHiLowASCIIToString(m_anGUIEQ3_EQtoRSTWord(nFor))
        Next

        nGxExistOnStage(3) = m_anGUI_EQ3_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.GX_EXIST_ON_STAGE)
        nGxInProcess(3) = m_anGUI_EQ3_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.GX_IN_PROCESS)
        nHandoffAvailable(3) = m_anGUI_EQ3_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.HANDOFF_AVAILAVLE)
        nAlarmOccurred(3) = m_anGUI_EQ3_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.ALARM_OCCURRED)
        nMPA1Stop(3) = m_anGUI_EQ3_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.MPA1_STOP)
        nMPA2Stop(3) = m_anGUI_EQ3_New_BIT(eEQGUI_EQ_Bit_Word_DevicNo.MPA2_STOP)

        'RST Word
        nStationMode(3) = m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.RST_STATION_MODE)
        nRemoteStatus(3) = m_anGUIEQ3_RSTtoEQWord(eEQGUI_RST_Word_DevicNo.RST_REMOTE_STATUS)
    End Sub
#End Region

    Private Sub OutputEQSignalToGUI()
        Dim nFor As Integer

        For nFor = 0 To MAX_GUIRST_ADDR_LEN
            Call SetEQGUIBitOnOff((eEQStartAddr.RST_START_ADDR + nFor), m_anGUI_RST_To_EQ_New_BIT(nFor))
        Next

        For nFor = 0 To MAX_GUIEQ_ADDR_LEN
            Call SetEQGUIBitOnOff((eEQStartAddr.EQ1_START_ADDR + nFor), m_anGUI_EQ1_New_BIT(nFor))
            Call SetEQGUIBitOnOff((eEQStartAddr.EQ2_START_ADDR + nFor), m_anGUI_EQ2_New_BIT(nFor))
            Call SetEQGUIBitOnOff((eEQStartAddr.EQ3_START_ADDR + nFor), m_anGUI_EQ3_New_BIT(nFor))
        Next

        For nFor = 1 To MAX_ALARM
            Call SetEQGUIAlarmOnOff(1, nFor, m_anGUI_EQ1Alarm_New_BIT(nFor))
            Call SetEQGUIAlarmOnOff(2, nFor, m_anGUI_EQ2Alarm_New_BIT(nFor))
            Call SetEQGUIAlarmOnOff(3, nFor, m_anGUI_EQ3Alarm_New_BIT(nFor))
        Next

    End Sub

    Private Sub SetEQGUIBitOnOff(ByVal nAddr As Integer, ByVal nOnOff As Integer)
        MyctlEQGUIMain.SignalOnOff(nAddr) = nOnOff
    End Sub

    Private Sub SetEQGUIAlarmOnOff(ByVal nEQIndex As Integer, ByVal nIndex As Integer, ByVal nOnOff As Integer)
        Select Case nEQIndex
            Case 1
                MyctlEQGUIMain.AlarmOnOffEQ1(nIndex) = nOnOff
            Case 2
                MyctlEQGUIMain.AlarmOnOffEQ2(nIndex) = nOnOff
            Case 3
                MyctlEQGUIMain.AlarmOnOffEQ3(nIndex) = nOnOff
        End Select
    End Sub

#Region "EQGUI Write Signal Function"
    Public Sub EQGUIWriteSignalOnOff(ByVal nAddr As Integer)
        If g_fEQEngineerMode Then
            Select Case nAddr
                Case &H0
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(0) = SIGNAL_ON, False, True))
                Case &H1
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(1) = SIGNAL_ON, False, True))
                Case &H10
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(16) = SIGNAL_ON, False, True))
                Case &H11
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(17) = SIGNAL_ON, False, True))
                Case &H12
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(18) = SIGNAL_ON, False, True))
                Case &H20
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(32) = SIGNAL_ON, False, True))
                Case &H21
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(33) = SIGNAL_ON, False, True))
                Case &H22
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(34) = SIGNAL_ON, False, True))
                Case &H28
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(40) = SIGNAL_ON, False, True))
                Case &H29
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(41) = SIGNAL_ON, False, True))
                Case &H2A
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(42) = SIGNAL_ON, False, True))
                Case &H30
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(48) = SIGNAL_ON, False, True))
                Case &H31
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(49) = SIGNAL_ON, False, True))
                Case &H32
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(50) = SIGNAL_ON, False, True))
                Case &H33
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(51) = SIGNAL_ON, False, True))
                Case &H34
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(52) = SIGNAL_ON, False, True))
                Case &H40
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(64) = SIGNAL_ON, False, True))
                Case &H42
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(66) = SIGNAL_ON, False, True))
                Case &H43
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(67) = SIGNAL_ON, False, True))
                Case &H45
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(69) = SIGNAL_ON, False, True))
                Case &H47
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(71) = SIGNAL_ON, False, True))
                Case &H50
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(80) = SIGNAL_ON, False, True))

                    '-------------------------------------------------------------------------------
                Case &H80
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(128) = SIGNAL_ON, False, True))
                Case &H81
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(129) = SIGNAL_ON, False, True))
                Case &H90
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(144) = SIGNAL_ON, False, True))
                Case &H91
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(145) = SIGNAL_ON, False, True))
                Case &H92
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(146) = SIGNAL_ON, False, True))
                Case &HA0
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(160) = SIGNAL_ON, False, True))
                Case &HA1
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(161) = SIGNAL_ON, False, True))
                Case &HA2
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(162) = SIGNAL_ON, False, True))
                Case &HA8
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(168) = SIGNAL_ON, False, True))
                Case &HA9
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(169) = SIGNAL_ON, False, True))
                Case &HAA
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(170) = SIGNAL_ON, False, True))
                Case &HB0
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(176) = SIGNAL_ON, False, True))
                Case &HB1
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(177) = SIGNAL_ON, False, True))
                Case &HB2
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(178) = SIGNAL_ON, False, True))
                Case &HB3
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(179) = SIGNAL_ON, False, True))
                Case &HB4
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(180) = SIGNAL_ON, False, True))
                Case &HC0
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(192) = SIGNAL_ON, False, True))
                Case &HC2
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(194) = SIGNAL_ON, False, True))
                Case &HC3
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(195) = SIGNAL_ON, False, True))
                Case &HC5
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(197) = SIGNAL_ON, False, True))
                Case &HC7
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(199) = SIGNAL_ON, False, True))
                Case &HD0
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(208) = SIGNAL_ON, False, True))

                    '-------------------------------------------------------------------------------
                Case &H100
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(256) = SIGNAL_ON, False, True))
                Case &H101
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(257) = SIGNAL_ON, False, True))
                Case &H110
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(272) = SIGNAL_ON, False, True))
                Case &H111
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(273) = SIGNAL_ON, False, True))
                Case &H112
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(274) = SIGNAL_ON, False, True))
                Case &H120
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(288) = SIGNAL_ON, False, True))
                Case &H121
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(289) = SIGNAL_ON, False, True))
                Case &H122
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(290) = SIGNAL_ON, False, True))
                Case &H128
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(296) = SIGNAL_ON, False, True))
                Case &H129
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(297) = SIGNAL_ON, False, True))
                Case &H12A
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(298) = SIGNAL_ON, False, True))
                Case &H130
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(304) = SIGNAL_ON, False, True))
                Case &H131
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(305) = SIGNAL_ON, False, True))
                Case &H132
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(306) = SIGNAL_ON, False, True))
                Case &H133
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(307) = SIGNAL_ON, False, True))
                Case &H134
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(308) = SIGNAL_ON, False, True))
                Case &H140
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(320) = SIGNAL_ON, False, True))
                Case &H142
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(322) = SIGNAL_ON, False, True))
                Case &H143
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(323) = SIGNAL_ON, False, True))
                Case &H145
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(325) = SIGNAL_ON, False, True))
                Case &H147
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(327) = SIGNAL_ON, False, True))
                Case &H150
                    WriteBAddr(nAddr, IIf(m_anGUI_RST_To_EQ_New_BIT(336) = SIGNAL_ON, False, True))
            End Select
        End If
    End Sub
#End Region

End Module
