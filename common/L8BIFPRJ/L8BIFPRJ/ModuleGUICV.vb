

Module ModuleGUICV
    Public WithEvents MyctlCVGUIMain As New ctlCVGUIMain

    Private Const MAX_GUI_RST_TO_CV_LEN = 172
    Private Const MAX_GUI_CV_TO_RST_LEN = 240
    Private Const MAX_GUI_CV_ALARM_A_LEN = 511

    Private Const MAX_ALARM = 512
    Private Const MAX_CV_RSTWORD_LEN = 290
    Private Const MAX_CV_CVWORD_LEN = 605

    Public g_anGUI_RST_To_CV_New_BIT(MAX_GUI_RST_TO_CV_LEN) As Integer
    Public g_anGUI_CV_To_RST_New_BIT(MAX_GUI_CV_TO_RST_LEN) As Integer

    Private g_anGUI_CV_Alarm_New_BIT(MAX_ALARM) As Integer

    Private g_anGUI_RST_Word(MAX_CV_RSTWORD_LEN) As Integer
    Private g_anGUI_CV_Word_DATA(MAX_CV_CVWORD_LEN) As Integer

    Public g_fMyCVGUITimerStart As Boolean


    Enum eCVGUIStartAddr
        RST_START_ADDR = &H180
        CV_START_ADDR = &H1300
        CV_ALARM_START_ADDR = &H1400
        RST_WORD_START_ADDR = &H180
        CV_WORD_START_ADDR = &H1300
    End Enum

    Enum eCVGUI_RST_Word_DevicNo

        PROCESS_CMD_PORT_NO = 0
        PROCESS_COMMAND = 1
        PROCESS_CMD_SLOT_INFO_W1 = 2
        PROCESS_CMD_SLOT_INFO_W2 = 3
        PROCESS_CMD_SLOT_INFO_W3 = 4
        PROCESS_CMD_SLOT_INFO_W4 = 5
        PROCESS_CMD_GX_QTY = 6
        PROCESS_CMD_GST_ID_W1 = 7
        PROCESS_CMD_GST_ID_W3 = 9

        P1_PROCESS_CMD_PORT_NO = 0
        P1_PROCESS_COMMAND = 1
        P1_PROCESS_CMD_SLOT_INFO_W1 = 2
        P1_PROCESS_CMD_SLOT_INFO_W2 = 3
        P1_PROCESS_CMD_SLOT_INFO_W3 = 4
        P1_PROCESS_CMD_SLOT_INFO_W4 = 5
        P1_PROCESS_CMD_GX_QTY = 6
        P1_PROCESS_CMD_GST_ID_W1 = 7
        P1_PROCESS_CMD_GST_ID_W3 = 9

        P2_PROCESS_CMD_PORT_NO = 192
        P2_PROCESS_COMMAND = 193
        P2_PROCESS_CMD_SLOT_INFO_W1 = 194
        P2_PROCESS_CMD_SLOT_INFO_W2 = 195
        P2_PROCESS_CMD_SLOT_INFO_W3 = 196
        P2_PROCESS_CMD_SLOT_INFO_W4 = 197
        P2_PROCESS_CMD_GX_QTY = 198
        P2_PROCESS_CMD_GST_ID_W1 = 199
        P2_PROCESS_CMD_GST_ID_W3 = 201

        P3_PROCESS_CMD_PORT_NO = 240
        P3_PROCESS_COMMAND = 241
        P3_PROCESS_CMD_SLOT_INFO_W1 = 242
        P3_PROCESS_CMD_SLOT_INFO_W2 = 243
        P3_PROCESS_CMD_SLOT_INFO_W3 = 244
        P3_PROCESS_CMD_SLOT_INFO_W4 = 245
        P3_PROCESS_CMD_GX_QTY = 246
        P3_PROCESS_CMD_GST_ID_W1 = 247
        P3_PROCESS_CMD_GST_ID_W3 = 249


        CV_STATUS_RUNNING_MODE = 13

        GX_DATA_REQ_PRODUCT_W1 = 48
        GX_DATA_REQ_PRODUCT_W13 = 60
        GX_DATA_REQ_PSH_GROUP = 61
        GX_DATA_REQ_JUDGMENT = 62
        GX_DATA_VCR_READ_POS = 63

        GX_FLOW_OUT_PRODUCT_CODE_W1 = 16
        GX_FLOW_OUT_PRODUCT_CODE_W13 = 28
        GX_FLOW_OUT_GXID_W1 = 29
        GX_FLOW_OUT_GXID_W6 = 34
        GX_FLOW_OUT_GX_JUDGMENT = 35
        GX_FLOW_OUT_PSH_GROUP = 36
        GX_FLOW_OUT_VCR_READ_POS = 37


        P1_GX_FLOW_OUT_PRODUCT_CODE_W1 = 16
        P1_GX_FLOW_OUT_PRODUCT_CODE_W13 = 28
        P1_GX_FLOW_OUT_GXID_W1 = 29
        P1_GX_FLOW_OUT_GXID_W6 = 34
        P1_GX_FLOW_OUT_GX_JUDGMENT = 35
        P1_GX_FLOW_OUT_PSH_GROUP = 36
        P1_GX_FLOW_OUT_VCR_READ_POS = 37

        P2_GX_FLOW_OUT_PRODUCT_CODE_W1 = 208
        P2_GX_FLOW_OUT_PRODUCT_CODE_W13 = 220
        P2_GX_FLOW_OUT_GXID_W1 = 221
        P2_GX_FLOW_OUT_GXID_W6 = 226
        P2_GX_FLOW_OUT_GX_JUDGMENT = 227
        P2_GX_FLOW_OUT_PSH_GROUP = 228
        P2_GX_FLOW_OUT_VCR_READ_POS = 229

        P3_GX_FLOW_OUT_PRODUCT_CODE_W1 = 256
        P3_GX_FLOW_OUT_PRODUCT_CODE_W13 = 268
        P3_GX_FLOW_OUT_GXID_W1 = 269
        P3_GX_FLOW_OUT_GXID_W6 = 274
        P3_GX_FLOW_OUT_GX_JUDGMENT = 275
        P3_GX_FLOW_OUT_PSH_GROUP = 276
        P3_GX_FLOW_OUT_VCR_READ_POS = 277


        PORT_CHAGNE_PRODUCT_CODE_W1 = 64
        PORT_CHAGNE_PRODUCT_CODE_W13 = 76
        PORT_CHAGNE_MODE = 77
        PORT_CHAGNE_TYPE = 78

        TR_REQ_POS1_GX_JUDGEMENT = 80
        TR_REQ_POS1_PSH_GRADE = 81
        TR_REQ_POS1_VCR_POSITION = 82
        TR_REQ_POS1_PRODUCT_CODE_W1 = 83
        TR_REQ_POS1_PRODUCT_CODE_W13 = 95
        TR_REQ_POS1_GXID_W1 = 96
        TR_REQ_POS1_GXID_W6 = 101

        TR_REQ_POS2_GX_JUDGEMENT = 112
        TR_REQ_POS2_PSH_GRADE = 113
        TR_REQ_POS2_VCR_POSITION = 114
        TR_REQ_POS2_PRODUCT_CODE_W1 = 115
        TR_REQ_POS2_PRODUCT_CODE_W13 = 127
        TR_REQ_POS2_GXID_W1 = 128
        TR_REQ_POS2_GXID_W6 = 133

        TR_REQ_POS3_GX_JUDGEMENT = 144
        TR_REQ_POS3_PSH_GRADE = 145
        TR_REQ_POS3_VCR_POSITION = 146
        TR_REQ_POS3_PRODUCT_CODE_W1 = 147
        TR_REQ_POS3_PRODUCT_CODE_W13 = 159
        TR_REQ_POS3_GXID_W1 = 160
        TR_REQ_POS3_GXID_W6 = 165

        TR_REQ_POS4_GX_JUDGEMENT = 170
        TR_REQ_POS4_PSH_GRADE = 171
        TR_REQ_POS4_VCR_POSITION = 172
        TR_REQ_POS4_PRODUCT_CODE_W1 = 173
        TR_REQ_POS4_PRODUCT_CODE_W13 = 185
        TR_REQ_POS4_GXID_W1 = 186
        TR_REQ_POS4_GXID_W6 = 191

        'VCR Read Position
    End Enum

    Enum eCVGUI_CV_Word_DevicNo
        CV_STATUS = 0
        CV_STATUS_GX_QTY_IN_CST1 = 1
        CV_STATUS_GX_QTY_IN_CST2 = 2
        CV_STATUS_GX_QTY_IN_CST3 = 3
        CV_STATUS_GX_QTY_IN_CST4 = 4
        CV_STATUS_GX_QTY_IN_CST5 = 5

        CV_STATUS_PORT1_MODE = 6
        CV_STATUS_PORT2_MODE = 7
        CV_STATUS_PORT3_MODE = 8
        CV_STATUS_PORT4_MODE = 9
        CV_STATUS_PORT5_MODE = 10

        CV_STATUS_PORT1_TYPE = 11
        CV_STATUS_PORT2_TYPE = 12
        CV_STATUS_PORT3_TYPE = 13
        CV_STATUS_PORT4_TYPE = 14
        CV_STATUS_PORT5_TYPE = 15

        CV_STATUS_GX_EXIST1_ON_CV = 16
        CV_STATUS_GX_EXIST2_ON_CV = 17
        CV_STATUS_GX_EXIST3_ON_CV = 18
        CV_STATUS_GX_EXIST4_ON_CV = 19
        CV_STATUS_GX_EXIST5_ON_CV = 20

        CV_STATUS_TOOL_ID_W1 = 24
        CV_STATUS_TOOL_ID_W6 = 29

        CV_STATUS_CST1_PRODUCT_CODE_W1 = 32
        CV_STATUS_CST1_PRODUCT_CODE_W13 = 44

        CV_STATUS_CST2_PRODUCT_CODE_W1 = 48
        CV_STATUS_CST2_PRODUCT_CODE_W13 = 60

        CV_STATUS_CST3_PRODUCT_CODE_W1 = 64
        CV_STATUS_CST3_PRODUCT_CODE_W13 = 76

        CV_STATUS_CST4_PRODUCT_CODE_W1 = 80
        CV_STATUS_CST4_PRODUCT_CODE_W13 = 92

        CV_STATUS_CST5_PRODUCT_CODE_W1 = 96
        CV_STATUS_CST5_PRODUCT_CODE_W13 = 108

        GX_DATA_VCR_GXID_W1 = 218
        GX_DATA_VCR_GXID_W6 = 223

        GX_ABNORMAL_CASE = 192
        GX_ABNORMAL_CASE_SOURCE_GXID_W1 = 193
        GX_ABNORMAL_CASE_SOURCE_GXID_W6 = 198
        GX_ABNORMAL_CASE_VCR_GXID_W1 = 199
        GX_ABNORMAL_CASE_VCR_GXID_W6 = 204
        GX_ABNORMAL_CASE_GX_POS = 205

        GX_SLOT_UNMATCH_PORT_NUMBER = 208
        GX_SLOT_UNMATCH_SLOT_NUMBER = 209
        GX_SLOT_UNMATCH_CASE = 210

        CST_LOADCOMP_MINI_SLOT_PORT1 = 112
        CST_LOADCOMP_MINI_SLOT_PORT2 = 113
        CST_LOADCOMP_MINI_SLOT_PORT3 = 114
        CST_LOADCOMP_MINI_SLOT_PORT4 = 115
        CST_LOADCOMP_MINI_SLOT_PORT5 = 116

        CST_LOADCOMP_CSTID_PORT1_W1 = 117
        CST_LOADCOMP_CSTID_PORT1_W3 = 119

        CST_LOADCOMP_CSTID_PORT2_W1 = 120
        CST_LOADCOMP_CSTID_PORT2_W3 = 122

        CST_LOADCOMP_CSTID_PORT3_W1 = 123
        CST_LOADCOMP_CSTID_PORT3_W3 = 125

        CST_LOADCOMP_CSTID_PORT4_W1 = 126
        CST_LOADCOMP_CSTID_PORT4_W3 = 128

        CST_LOADCOMP_CSTID_PORT5_W1 = 129
        CST_LOADCOMP_CSTID_PORT5_W3 = 131

        GX_FLOW_OUT_SLOT_NUMBER_PORT1 = 183
        GX_FLOW_OUT_SLOT_NUMBER_PORT2 = 184
        GX_FLOW_OUT_SLOT_NUMBER_PORT3 = 185
        GX_FLOW_OUT_SLOT_NUMBER_PORT4 = 186
        GX_FLOW_OUT_SLOT_NUMBER_PORT5 = 187

        GX_FLOW_IN_PRODUCT_CODE_W1 = 160
        GX_FLOW_IN_PRODUCT_CODE_W13 = 172

        GX_FLOW_IN_GXID_W1 = 173
        GX_FLOW_IN_GXID_W6 = 178
        GX_FLOW_IN_SLOT_NUMBER = 179

        CST_UNLOAD_STATUS_PORT1_BYCV = 144
        CST_UNLOAD_GX_QTY_PORT1_BYCV = 145
        CST_UNLOAD_STATUS_PORT2_BYCV = 146
        CST_UNLOAD_GX_QTY_PORT2_BYCV = 147
        CST_UNLOAD_STATUS_PORT3_BYCV = 148
        CST_UNLOAD_GX_QTY_PORT3_BYCV = 149
        CST_UNLOAD_STATUS_PORT4_BYCV = 150
        CST_UNLOAD_GX_QTY_PORT4_BYCV = 151
        CST_UNLOAD_STATUS_PORT5_BYCV = 152
        CST_UNLOAD_GX_QTY_PORT5_BYCV = 153

        CV_DUMMY_CANCEL_RESULT = 138
        CV_PORT_CHANGE_RESULT = 213

        TR_REQ_POS1_GX_JUDGEMENT = 224
        TR_REQ_POS1_PSH_GRADE = 225
        TR_REQ_POS1_PRODUCT_CODE_W1 = 227
        TR_REQ_POS1_PRODUCT_CODE_W13 = 239
        TR_REQ_POS1_GXID_W1 = 240
        TR_REQ_POS1_GXID_W6 = 245

        TR_REQ_POS2_GX_JUDGEMENT = 256
        TR_REQ_POS2_PSH_GRADE = 257
        TR_REQ_POS2_PRODUCT_CODE_W1 = 259
        TR_REQ_POS2_PRODUCT_CODE_W13 = 271
        TR_REQ_POS2_GXID_W1 = 272
        TR_REQ_POS2_GXID_W6 = 277

        TR_REQ_POS3_GX_JUDGEMENT = 288
        TR_REQ_POS3_PSH_GRADE = 289
        TR_REQ_POS3_PRODUCT_CODE_W1 = 291
        TR_REQ_POS3_PRODUCT_CODE_W13 = 303
        TR_REQ_POS3_GXID_W1 = 304
        TR_REQ_POS3_GXID_W6 = 309

        TR_REQ_POS4_GX_JUDGEMENT = 320
        TR_REQ_POS4_PSH_GRADE = 321
        TR_REQ_POS4_PRODUCT_CODE_W1 = 323
        TR_REQ_POS4_PRODUCT_CODE_W13 = 335
        TR_REQ_POS4_GXID_W1 = 336
        TR_REQ_POS4_GXID_W6 = 341

        'Glass Judgement
    End Enum

    Enum eCVGUI_CV_Bit_DevicNo
        ALARM_OCCURRED = 37
    End Enum

    Public Sub ScanGUICVBitAddr()
        Dim nFor As Integer
        Dim afReadRSTBitData(MAX_GUI_RST_TO_CV_LEN) As Boolean
        Dim afReadCVBitData(MAX_GUI_CV_TO_RST_LEN) As Boolean
        Dim afReadCVAlarmBit(MAX_GUI_CV_ALARM_A_LEN) As Boolean
        Dim anReadRSTWordData(MAX_CV_RSTWORD_LEN) As Integer
        Dim anReadCVWordData(MAX_CV_CVWORD_LEN) As Integer


        Call ReadBAddr(eCVGUIStartAddr.RST_START_ADDR, afReadRSTBitData)

        For nFor = 0 To MAX_GUI_RST_TO_CV_LEN
            If afReadRSTBitData(nFor) Then
                g_anGUI_RST_To_CV_New_BIT(nFor) = SIGNAL_ON
            Else
                g_anGUI_RST_To_CV_New_BIT(nFor) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eCVGUIStartAddr.CV_START_ADDR, afReadCVBitData)

        For nFor = 0 To MAX_GUI_CV_TO_RST_LEN
            If afReadCVBitData(nFor) Then
                g_anGUI_CV_To_RST_New_BIT(nFor) = SIGNAL_ON
            Else
                g_anGUI_CV_To_RST_New_BIT(nFor) = SIGNAL_OFF
            End If
        Next

        Call ReadBAddr(eCVGUIStartAddr.CV_ALARM_START_ADDR, afReadCVAlarmBit)

        For nFor = 0 To MAX_GUI_CV_ALARM_A_LEN
            If afReadCVAlarmBit(nFor) Then
                g_anGUI_CV_Alarm_New_BIT(nFor + 1) = SIGNAL_ON '1~512
            Else
                g_anGUI_CV_Alarm_New_BIT(nFor + 1) = SIGNAL_OFF
            End If
        Next

        Call ReadWAddr(eCVGUIStartAddr.RST_WORD_START_ADDR, anReadRSTWordData)
        For nFor = 0 To MAX_CV_RSTWORD_LEN
            g_anGUI_RST_Word(nFor) = anReadRSTWordData(nFor)
        Next

        Call ReadWAddr(eCVGUIStartAddr.CV_WORD_START_ADDR, anReadCVWordData)
        For nFor = 0 To MAX_CV_CVWORD_LEN
            g_anGUI_CV_Word_DATA(nFor) = anReadCVWordData(nFor)
        Next

        Call OutputCVSignalToGUI()

    End Sub

#Region "Return GUI Word Value"
    Public Sub ReadCVGUITransferRequestRSTtoCV3(ByRef nVCRPositionPort1 As Integer, ByRef nVCRPositionPort2 As Integer, ByRef nVCRPositionPort3 As Integer, ByRef nVCRPositionPort4 As Integer)
        nVCRPositionPort1 = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS1_VCR_POSITION)
        nVCRPositionPort2 = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS2_VCR_POSITION)
        nVCRPositionPort3 = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS3_VCR_POSITION)
        nVCRPositionPort4 = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS4_VCR_POSITION)
    End Sub

    Public Sub ReadCVGUITransferRequestRSTtoCV2(ByRef strP1ProductCode As String, ByRef strP2ProductCode As String, ByRef strP3ProductCode As String, ByRef strP4ProductCode As String, ByRef strP1PSHGroup As String, ByRef strP2PSHGroup As String, ByRef strP3PSHGroup As String, ByRef strP4PSHGroup As String)
        Dim nFor As Integer

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS1_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS1_PRODUCT_CODE_W13
            strP1ProductCode = strP1ProductCode & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS2_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS2_PRODUCT_CODE_W13
            strP2ProductCode = strP2ProductCode & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS3_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS3_PRODUCT_CODE_W13
            strP3ProductCode = strP3ProductCode & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS4_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS4_PRODUCT_CODE_W13
            strP4ProductCode = strP4ProductCode & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        strP1PSHGroup = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS1_PSH_GRADE))
        strP2PSHGroup = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS2_PSH_GRADE))
        strP3PSHGroup = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS3_PSH_GRADE))
        strP4PSHGroup = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS4_PSH_GRADE))
    End Sub

    Public Sub ReadCVGUITransferRequestRSTtoCV1(ByRef strP1GxID As String, ByRef strP2GxID As String, ByRef strP3GxID As String, ByRef strP4GxID As String, ByRef nP1GxJudge As Integer, ByRef nP2GxJudge As Integer, ByRef nP3GxJudge As Integer, ByRef nP4GxJudge As Integer)
        Dim nFor As Integer

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS1_GXID_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS1_GXID_W6
            strP1GxID = strP1GxID & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS2_GXID_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS2_GXID_W6
            strP2GxID = strP2GxID & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS3_GXID_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS3_GXID_W6
            strP3GxID = strP3GxID & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        For nFor = eCVGUI_RST_Word_DevicNo.TR_REQ_POS4_GXID_W1 To eCVGUI_RST_Word_DevicNo.TR_REQ_POS4_GXID_W6
            strP4GxID = strP4GxID & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        nP1GxJudge = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS1_GX_JUDGEMENT)
        nP2GxJudge = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS2_GX_JUDGEMENT)
        nP3GxJudge = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS3_GX_JUDGEMENT)
        nP4GxJudge = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.TR_REQ_POS4_GX_JUDGEMENT)
    End Sub

    Public Sub ReadCVGUITransferRequestCVtoRST2(ByRef strP1ProductCode As String, ByRef strP2ProductCode As String, ByRef strP3ProductCode As String, ByRef strP4ProductCode As String, ByRef strP1PSHGroup As String, ByRef strP2PSHGroup As String, ByRef strP3PSHGroup As String, ByRef strP4PSHGroup As String)
        Dim nFor As Integer

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS1_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS1_PRODUCT_CODE_W13
            strP1ProductCode = strP1ProductCode & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS2_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS2_PRODUCT_CODE_W13
            strP2ProductCode = strP2ProductCode & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS3_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS3_PRODUCT_CODE_W13
            strP3ProductCode = strP3ProductCode & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS4_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS4_PRODUCT_CODE_W13
            strP4ProductCode = strP4ProductCode & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        strP1PSHGroup = ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS1_PSH_GRADE))
        strP2PSHGroup = ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS2_PSH_GRADE))
        strP3PSHGroup = ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS3_PSH_GRADE))
        strP4PSHGroup = ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS4_PSH_GRADE))
    End Sub

    Public Sub ReadCVGUITransferRequestCVtoRST1(ByRef strP1GxID As String, ByRef strP2GxID As String, ByRef strP3GxID As String, ByRef strP4GxID As String, ByRef nP1GxJudge As Integer, ByRef nP2GxJudge As Integer, ByRef nP3GxJudge As Integer, ByRef nP4GxJudge As Integer, ByRef nVCRPosition As Integer)
        Dim nFor As Integer

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS1_GXID_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS1_GXID_W6
            strP1GxID = strP1GxID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS2_GXID_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS2_GXID_W6
            strP2GxID = strP2GxID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS3_GXID_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS3_GXID_W6
            strP3GxID = strP3GxID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.TR_REQ_POS4_GXID_W1 To eCVGUI_CV_Word_DevicNo.TR_REQ_POS4_GXID_W6
            strP4GxID = strP4GxID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        nP1GxJudge = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS1_GX_JUDGEMENT)
        nP2GxJudge = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS2_GX_JUDGEMENT)
        nP3GxJudge = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS3_GX_JUDGEMENT)
        nP4GxJudge = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.TR_REQ_POS4_GX_JUDGEMENT)

        'W13CD Glass Position
        nVCRPosition = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_ABNORMAL_CASE_GX_POS)

    End Sub

    Public Sub ReadCVGUIPortChangeRequest(ByRef nPortMode As Integer, ByRef nPortType As Integer, ByRef nChangeResult As Integer, ByRef strProductCode As String)
        Dim nFor As Integer

        For nFor = eCVGUI_RST_Word_DevicNo.PORT_CHAGNE_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.PORT_CHAGNE_PRODUCT_CODE_W13
            strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        nPortMode = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PORT_CHAGNE_MODE)
        nPortType = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PORT_CHAGNE_TYPE)

        nChangeResult = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_PORT_CHANGE_RESULT)
    End Sub

    Public Sub ReadCVGUICVDummyCancelResult(ByRef nDummyCancelResult As Integer)
        nDummyCancelResult = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_DUMMY_CANCEL_RESULT)
    End Sub

    Public Sub ReadCVGUIUnloadRequestByCV(ByRef nPort1Status As Integer, ByRef nPort2Status As Integer, ByRef nPort3Status As Integer, ByRef nPort4Status As Integer, ByRef nPort5Status As Integer, ByRef nPort1GXQty As Integer, ByRef nPort2GXQty As Integer, ByRef nPort3GXQty As Integer, ByRef nPort4GXQty As Integer, ByRef nPort5GXQty As Integer)
        nPort1Status = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_STATUS_PORT1_BYCV)
        nPort2Status = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_STATUS_PORT2_BYCV)
        nPort3Status = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_STATUS_PORT3_BYCV)
        nPort4Status = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_STATUS_PORT4_BYCV)
        nPort5Status = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_STATUS_PORT5_BYCV)

        nPort1GXQty = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_GX_QTY_PORT1_BYCV)
        nPort2GXQty = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_GX_QTY_PORT2_BYCV)
        nPort3GXQty = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_GX_QTY_PORT3_BYCV)
        nPort4GXQty = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_GX_QTY_PORT4_BYCV)
        nPort5GXQty = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_UNLOAD_GX_QTY_PORT5_BYCV)
    End Sub

    Public Sub ReadCVGUIGxFlowIn(ByRef strGxID As String, ByRef strProductCode As String, ByRef nSlotNumber As Integer)
        Dim nFor As Integer

        For nFor = eCVGUI_CV_Word_DevicNo.GX_FLOW_IN_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.GX_FLOW_IN_PRODUCT_CODE_W13
            strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.GX_FLOW_IN_GXID_W1 To eCVGUI_CV_Word_DevicNo.GX_FLOW_IN_GXID_W6
            strGxID = strGxID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        nSlotNumber = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_FLOW_IN_SLOT_NUMBER)
    End Sub

    Public Sub ReadCVGUIGxFlowOut2(ByRef nSlotNumberPort1 As Integer, ByRef nSlotNumberPort2 As Integer, ByRef nSlotNumberPort3 As Integer, ByRef nSlotNumberPort4 As Integer, ByRef nSlotNumberPort5 As Integer)
        nSlotNumberPort1 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_FLOW_OUT_SLOT_NUMBER_PORT1)
        nSlotNumberPort2 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_FLOW_OUT_SLOT_NUMBER_PORT2)
        nSlotNumberPort3 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_FLOW_OUT_SLOT_NUMBER_PORT3)
        nSlotNumberPort4 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_FLOW_OUT_SLOT_NUMBER_PORT4)
        nSlotNumberPort5 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_FLOW_OUT_SLOT_NUMBER_PORT5)
    End Sub

    Public Sub ReadCVGUIGxFlowOut1(ByRef strGxID As String, ByRef strProductCode As String, ByRef strPSHGroup As String, ByRef nVCRPosition As Integer, ByRef nGxJudgement As Integer)
        Dim nFor As Integer

        For nFor = eCVGUI_RST_Word_DevicNo.GX_FLOW_OUT_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.GX_FLOW_OUT_PRODUCT_CODE_W13
            strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        For nFor = eCVGUI_RST_Word_DevicNo.GX_FLOW_OUT_GXID_W1 To eCVGUI_RST_Word_DevicNo.GX_FLOW_OUT_GXID_W6
            strGxID = strGxID & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        nGxJudgement = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.GX_FLOW_OUT_GX_JUDGMENT)
        strPSHGroup = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.GX_FLOW_OUT_PSH_GROUP))
        nVCRPosition = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.GX_FLOW_OUT_VCR_READ_POS)
    End Sub

    Public ReadOnly Property GetCVGUIGxFlowOut1(ByVal nPort As Integer) As Array
        Get
            Dim astrValue(3) As String

            Select Case nPort
                Case 1
                    For nFor = eCVGUI_RST_Word_DevicNo.P1_GX_FLOW_OUT_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.P1_GX_FLOW_OUT_PRODUCT_CODE_W13
                        astrValue(1) = astrValue(1) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next

                    For nFor = eCVGUI_RST_Word_DevicNo.P1_GX_FLOW_OUT_GXID_W1 To eCVGUI_RST_Word_DevicNo.P1_GX_FLOW_OUT_GXID_W6
                        astrValue(2) = astrValue(2) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next
                    astrValue(3) = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_GX_FLOW_OUT_PSH_GROUP))
                Case 2
                    For nFor = eCVGUI_RST_Word_DevicNo.P2_GX_FLOW_OUT_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.P2_GX_FLOW_OUT_PRODUCT_CODE_W13
                        astrValue(1) = astrValue(1) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next

                    For nFor = eCVGUI_RST_Word_DevicNo.P2_GX_FLOW_OUT_GXID_W1 To eCVGUI_RST_Word_DevicNo.P2_GX_FLOW_OUT_GXID_W6
                        astrValue(2) = astrValue(2) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next
                    astrValue(3) = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_GX_FLOW_OUT_PSH_GROUP))
                Case 3
                    For nFor = eCVGUI_RST_Word_DevicNo.P3_GX_FLOW_OUT_PRODUCT_CODE_W1 To eCVGUI_RST_Word_DevicNo.P3_GX_FLOW_OUT_PRODUCT_CODE_W13
                        astrValue(1) = astrValue(1) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next

                    For nFor = eCVGUI_RST_Word_DevicNo.P3_GX_FLOW_OUT_GXID_W1 To eCVGUI_RST_Word_DevicNo.P3_GX_FLOW_OUT_GXID_W6
                        astrValue(2) = astrValue(2) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next
                    astrValue(3) = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_GX_FLOW_OUT_PSH_GROUP))
                Case Else
                    astrValue(1) = ""
                    astrValue(2) = ""
                    astrValue(3) = ""
            End Select
            Return astrValue
        End Get
    End Property

    Public ReadOnly Property GetCVGUIGxFlowOut2(ByVal nPort As Integer) As Array
        Get
            Dim anValue(2) As Integer

            Select Case nPort
                Case 1
                    anValue(1) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_GX_FLOW_OUT_GX_JUDGMENT)
                    anValue(2) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_GX_FLOW_OUT_VCR_READ_POS)
                Case 2
                    anValue(1) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_GX_FLOW_OUT_GX_JUDGMENT)
                    anValue(2) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_GX_FLOW_OUT_VCR_READ_POS)
                Case 3
                    anValue(1) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_GX_FLOW_OUT_GX_JUDGMENT)
                    anValue(2) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_GX_FLOW_OUT_VCR_READ_POS)
            End Select
            Return anValue
        End Get
    End Property

    Public Sub ReadCVGUICSTLoadComplete(ByRef strPort1CSTID As String, ByRef strPort2CSTID As String, ByRef strPort3CSTID As String, ByRef strPort4CSTID As String, ByRef strPort5CSTID As String, ByRef nPort1MiniSlot As Integer, ByRef nPort2MiniSlot As Integer, ByRef nPort3MiniSlot As Integer, ByRef nPort4MiniSlot As Integer, ByRef nPort5MiniSlot As Integer)
        Dim nFor As Integer

        nPort1MiniSlot = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_MINI_SLOT_PORT1)
        nPort2MiniSlot = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_MINI_SLOT_PORT2)
        nPort3MiniSlot = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_MINI_SLOT_PORT3)
        nPort4MiniSlot = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_MINI_SLOT_PORT4)
        nPort5MiniSlot = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_MINI_SLOT_PORT5)

        For nFor = eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT1_W1 To eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT1_W3
            strPort1CSTID = strPort1CSTID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT2_W1 To eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT2_W3
            strPort2CSTID = strPort2CSTID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT3_W1 To eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT3_W3
            strPort3CSTID = strPort3CSTID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT4_W1 To eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT4_W3
            strPort4CSTID = strPort4CSTID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT5_W1 To eCVGUI_CV_Word_DevicNo.CST_LOADCOMP_CSTID_PORT5_W3
            strPort5CSTID = strPort5CSTID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

    End Sub

    Public Sub ReadCVGUIGxSlotUnmatch(ByRef nPortNo As Integer, ByRef nSlotNumber As Integer, ByRef nUnmatchCase As Integer)
        nPortNo = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_SLOT_UNMATCH_PORT_NUMBER)
        nSlotNumber = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_SLOT_UNMATCH_SLOT_NUMBER)
        nUnmatchCase = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_SLOT_UNMATCH_CASE)
    End Sub

    Public Sub ReadCVGUIGlassAbnormalCase(ByRef nAbnormalCase As Integer, ByRef nGxPosition As Integer, ByRef strSourceGxID As String, ByRef strVCRGxID As String)
        Dim nFor As Integer

        nAbnormalCase = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_ABNORMAL_CASE)
        nGxPosition = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.GX_ABNORMAL_CASE_GX_POS)

        For nFor = eCVGUI_CV_Word_DevicNo.GX_ABNORMAL_CASE_SOURCE_GXID_W1 To eCVGUI_CV_Word_DevicNo.GX_ABNORMAL_CASE_SOURCE_GXID_W6
            strSourceGxID = strSourceGxID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.GX_ABNORMAL_CASE_VCR_GXID_W1 To eCVGUI_CV_Word_DevicNo.GX_ABNORMAL_CASE_VCR_GXID_W6
            strVCRGxID = strVCRGxID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next
    End Sub

    Public Sub ReadCVGUIGlassDataRequest(ByRef strProductCode As String, ByRef strPSHGrade As String, ByRef nGxJudgment As Integer, ByRef nVCRPos As Integer, ByRef strGlassID As String)
        Dim nFor As Integer

        For nFor = eCVGUI_RST_Word_DevicNo.GX_DATA_REQ_PRODUCT_W1 To eCVGUI_RST_Word_DevicNo.GX_DATA_REQ_PRODUCT_W13
            strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        strPSHGrade = ConvertHiLowASCIIToString(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.GX_DATA_REQ_PSH_GROUP))

        nGxJudgment = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.GX_DATA_REQ_JUDGMENT)
        nVCRPos = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.GX_DATA_VCR_READ_POS)

        'W13DA
        For nFor = eCVGUI_CV_Word_DevicNo.GX_DATA_VCR_GXID_W1 To eCVGUI_CV_Word_DevicNo.GX_DATA_VCR_GXID_W6
            strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

    End Sub

    Public Sub ReadCVGUIPortStatus(ByRef nPortMode1 As Integer, ByRef nPortMode2 As Integer, ByRef nPortMode3 As Integer, ByRef nPortMode4 As Integer, ByRef nPortMode5 As Integer, ByRef nPortType1 As Integer, ByRef nPortType2 As Integer, ByRef nPortType3 As Integer, ByRef nPortType4 As Integer, ByRef nPortType5 As Integer)
        nPortMode1 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT1_MODE)
        nPortMode2 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT2_MODE)
        nPortMode3 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT3_MODE)
        nPortMode4 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT4_MODE)
        nPortMode5 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT5_MODE)
        nPortType1 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT1_TYPE)
        nPortType2 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT2_TYPE)
        nPortType3 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT3_TYPE)
        nPortType4 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT4_TYPE)
        nPortType5 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_PORT5_TYPE)
    End Sub

    Public Sub ReadCVGUIStatus1(ByRef strRunningMode As String, ByRef strAlarmOccurred As String, ByRef strCSTProductCode1 As String, ByRef strCSTProductCode2 As String, ByRef strCSTProductCode3 As String, ByRef strCSTProductCode4 As String, ByRef strCSTProductCode5 As String, ByRef strCVStatus As String)
        Dim nFor As Integer

        strRunningMode = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.CV_STATUS_RUNNING_MODE)
        strAlarmOccurred = g_anGUI_CV_To_RST_New_BIT(eCVGUI_CV_Bit_DevicNo.ALARM_OCCURRED)

        For nFor = eCVGUI_CV_Word_DevicNo.CV_STATUS_CST1_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.CV_STATUS_CST1_PRODUCT_CODE_W13
            strCSTProductCode1 = strCSTProductCode1 & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CV_STATUS_CST2_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.CV_STATUS_CST2_PRODUCT_CODE_W13
            strCSTProductCode2 = strCSTProductCode2 & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CV_STATUS_CST3_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.CV_STATUS_CST3_PRODUCT_CODE_W13
            strCSTProductCode3 = strCSTProductCode3 & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CV_STATUS_CST4_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.CV_STATUS_CST4_PRODUCT_CODE_W13
            strCSTProductCode4 = strCSTProductCode4 & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        For nFor = eCVGUI_CV_Word_DevicNo.CV_STATUS_CST5_PRODUCT_CODE_W1 To eCVGUI_CV_Word_DevicNo.CV_STATUS_CST5_PRODUCT_CODE_W13
            strCSTProductCode5 = strCSTProductCode5 & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

        strCVStatus = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS)
    End Sub

    Public Sub ReadCVGUIStatus2(ByRef strGxExistInfo1 As String, ByRef strGxExistInfo2 As String, ByRef strGxExistInfo3 As String, ByRef strGxExistInfo4 As String, ByRef strGxExistInfo5 As String, ByRef strGxQTYInCST1 As String, ByRef strGxQTYInCST2 As String, ByRef strGxQTYInCST3 As String, ByRef strGxQTYInCST4 As String, ByRef strGxQTYInCST5 As String, ByRef strToolId As String)
        Dim nFor As Integer

        strGxExistInfo1 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_EXIST1_ON_CV)
        strGxExistInfo2 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_EXIST2_ON_CV)
        strGxExistInfo3 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_EXIST3_ON_CV)
        strGxExistInfo4 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_EXIST4_ON_CV)
        strGxExistInfo5 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_EXIST5_ON_CV)

        strGxQTYInCST1 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_QTY_IN_CST1)
        strGxQTYInCST2 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_QTY_IN_CST2)
        strGxQTYInCST3 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_QTY_IN_CST3)
        strGxQTYInCST4 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_QTY_IN_CST4)
        strGxQTYInCST5 = g_anGUI_CV_Word_DATA(eCVGUI_CV_Word_DevicNo.CV_STATUS_GX_QTY_IN_CST5)

        For nFor = eCVGUI_CV_Word_DevicNo.CV_STATUS_TOOL_ID_W1 To eCVGUI_CV_Word_DevicNo.CV_STATUS_TOOL_ID_W6
            strToolId = strToolId & ConvertHiLowASCIIToString(g_anGUI_CV_Word_DATA(nFor))
        Next

    End Sub

    Public Sub ReadCVGUIProcessCmd(ByRef strCSTID As String, ByRef strSlotNo As String, ByRef strPortNo As String, ByRef strProcessCmd As String, ByRef strQty As String)
        Dim nFor As Integer

        For nFor = eCVGUI_RST_Word_DevicNo.PROCESS_CMD_GST_ID_W1 To eCVGUI_RST_Word_DevicNo.PROCESS_CMD_GST_ID_W3
            strCSTID = strCSTID & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
        Next

        strSlotNo = HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PROCESS_CMD_SLOT_INFO_W1)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PROCESS_CMD_SLOT_INFO_W2)) _
        & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PROCESS_CMD_SLOT_INFO_W3)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PROCESS_CMD_SLOT_INFO_W4))

        strPortNo = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PROCESS_CMD_PORT_NO)
        strProcessCmd = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PROCESS_COMMAND)
        strQty = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.PROCESS_CMD_GX_QTY)
    End Sub

    Public ReadOnly Property GetProcessComd1(ByVal nPort As Integer) As Array
        Get
            Dim strValue(2) As String
            Dim nFor As Integer

            Select Case nPort
                Case 1
                    strValue(1) = HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_SLOT_INFO_W1)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_SLOT_INFO_W2)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_SLOT_INFO_W3)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_SLOT_INFO_W4))

                    For nFor = eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_GST_ID_W1 To eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_GST_ID_W3
                        strValue(2) = strValue(2) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next
                Case 2
                    strValue(1) = HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_SLOT_INFO_W1)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_SLOT_INFO_W2)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_SLOT_INFO_W3)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_SLOT_INFO_W4))

                    For nFor = eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_GST_ID_W1 To eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_GST_ID_W3
                        strValue(2) = strValue(2) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next
                Case 3
                    strValue(1) = HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_SLOT_INFO_W1)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_SLOT_INFO_W2)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_SLOT_INFO_W3)) & "/" & HexLeadZero(g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_SLOT_INFO_W4))

                    For nFor = eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_GST_ID_W1 To eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_GST_ID_W3
                        strValue(2) = strValue(2) & ConvertHiLowASCIIToString(g_anGUI_RST_Word(nFor))
                    Next
                Case Else
                    strValue(1) = ""
                    strValue(2) = ""
            End Select
            Return strValue
        End Get
    End Property

    Public ReadOnly Property GetProcessComd2(ByVal nPort As Integer) As Array
        Get
            Dim nValue(3) As Integer

            Select Case nPort
                Case 1
                    nValue(1) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_PORT_NO)
                    nValue(2) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_PROCESS_COMMAND)
                    nValue(3) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P1_PROCESS_CMD_GX_QTY)
                Case 2
                    nValue(1) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_PORT_NO)
                    nValue(2) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_PROCESS_COMMAND)
                    nValue(3) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P2_PROCESS_CMD_GX_QTY)
                Case 3
                    nValue(1) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_PORT_NO)
                    nValue(2) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_PROCESS_COMMAND)
                    nValue(3) = g_anGUI_RST_Word(eCVGUI_RST_Word_DevicNo.P3_PROCESS_CMD_GX_QTY)
            End Select
            Return nValue
        End Get
    End Property

#End Region


    Private Sub OutputCVSignalToGUI()
        Dim nFor As Integer

        For nFor = 0 To MAX_GUI_RST_TO_CV_LEN
            Call SetCVGUIBitOnOff((eCVGUIStartAddr.RST_START_ADDR + nFor), g_anGUI_RST_To_CV_New_BIT(nFor))
        Next

        For nFor = 0 To MAX_GUI_CV_TO_RST_LEN
            Call SetCVGUIBitOnOff((eCVGUIStartAddr.CV_START_ADDR + nFor), g_anGUI_CV_To_RST_New_BIT(nFor))
        Next

        For nFor = 1 To MAX_ALARM
            Call SetCVGUIAlarmOnOff(nFor, g_anGUI_CV_Alarm_New_BIT(nFor))
        Next

    End Sub

    Private Sub SetCVGUIBitOnOff(ByVal nAddr As Integer, ByVal nOnOff As Integer)
        MyctlCVGUIMain.SignalOnOff(nAddr) = nOnOff
    End Sub

    Private Sub SetCVGUIAlarmOnOff(ByVal nIndex As Integer, ByVal nOnOff As Integer)
        MyctlCVGUIMain.AlarmOnOff(nIndex) = nOnOff
    End Sub

#Region "CVGUI Write Signal Function"

    Public Sub CVGUIWriteSignalOnOff(ByVal nAddr As Integer)
        If g_fCVEngineerMode Then
            Select Case nAddr
                Case &H180
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(0) = SIGNAL_ON, False, True))
                Case &H181
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(1) = SIGNAL_ON, False, True))
                Case &H183
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(3) = SIGNAL_ON, False, True))
                Case &H184
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(4) = SIGNAL_ON, False, True))
                Case &H190
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(16) = SIGNAL_ON, False, True))
                Case &H191
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(17) = SIGNAL_ON, False, True))
                Case &H192
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(18) = SIGNAL_ON, False, True))
                Case &H193
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(19) = SIGNAL_ON, False, True))
                Case &H194
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(20) = SIGNAL_ON, False, True))
                Case &H197
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(23) = SIGNAL_ON, False, True))
                Case &H198
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(24) = SIGNAL_ON, False, True))
                Case &H199
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(25) = SIGNAL_ON, False, True))
                Case &H19A
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(26) = SIGNAL_ON, False, True))
                Case &H19B
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(27) = SIGNAL_ON, False, True))
                Case &H19F
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(31) = SIGNAL_ON, False, True))
                Case &H1A0
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(32) = SIGNAL_ON, False, True))
                Case &H1A1
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(33) = SIGNAL_ON, False, True))
                Case &H1A2
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(34) = SIGNAL_ON, False, True))
                Case &H1A3
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(35) = SIGNAL_ON, False, True))
                Case &H1A4
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(36) = SIGNAL_ON, False, True))
                Case &H1AB
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(43) = SIGNAL_ON, False, True))
                Case &H1AC
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(44) = SIGNAL_ON, False, True))
                Case &H1AD
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(45) = SIGNAL_ON, False, True))
                Case &H1AE
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(46) = SIGNAL_ON, False, True))
                Case &H1AF
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(47) = SIGNAL_ON, False, True))
                Case &H1B0
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(48) = SIGNAL_ON, False, True))
                Case &H1B1
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(49) = SIGNAL_ON, False, True))
                Case &H1B2
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(50) = SIGNAL_ON, False, True))
                Case &H1B3
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(51) = SIGNAL_ON, False, True))
                Case &H1B4
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(52) = SIGNAL_ON, False, True))
                Case &H1B8
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(56) = SIGNAL_ON, False, True))
                Case &H1B9
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(57) = SIGNAL_ON, False, True))
                Case &H1BA
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(58) = SIGNAL_ON, False, True))
                Case &H1BB
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(59) = SIGNAL_ON, False, True))
                Case &H1BC
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(60) = SIGNAL_ON, False, True))
                Case &H1C0
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(64) = SIGNAL_ON, False, True))
                Case &H1C1
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(65) = SIGNAL_ON, False, True))
                Case &H1C2
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(66) = SIGNAL_ON, False, True))
                Case &H1C3
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(67) = SIGNAL_ON, False, True))
                Case &H1C4
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(68) = SIGNAL_ON, False, True))
                Case &H1C8
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(72) = SIGNAL_ON, False, True))
                Case &H1C9
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(73) = SIGNAL_ON, False, True))
                Case &H1CA
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(74) = SIGNAL_ON, False, True))
                Case &H1CB
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(75) = SIGNAL_ON, False, True))
                Case &H1CC
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(76) = SIGNAL_ON, False, True))
                Case &H1D0
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(80) = SIGNAL_ON, False, True))
                Case &H1D1
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(81) = SIGNAL_ON, False, True))
                Case &H1D3
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(83) = SIGNAL_ON, False, True))
                Case &H1D5
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(85) = SIGNAL_ON, False, True))
                Case &H1D7
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(87) = SIGNAL_ON, False, True))
                Case &H1DB
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(91) = SIGNAL_ON, False, True))
                Case &H1DC
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(92) = SIGNAL_ON, False, True))
                Case &H1DD
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(93) = SIGNAL_ON, False, True))
                Case &H1DE
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(94) = SIGNAL_ON, False, True))
                Case &H1DF
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(95) = SIGNAL_ON, False, True))
                Case &H1E0
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(96) = SIGNAL_ON, False, True))
                Case &H1E1
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(97) = SIGNAL_ON, False, True))
                Case &H1E2
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(98) = SIGNAL_ON, False, True))
                Case &H1E3
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(99) = SIGNAL_ON, False, True))
                Case &H1E4
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(100) = SIGNAL_ON, False, True))
                Case &H1E5
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(101) = SIGNAL_ON, False, True))
                Case &H1E6
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(102) = SIGNAL_ON, False, True))
                Case &H1E7
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(103) = SIGNAL_ON, False, True))
                Case &H1E8
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(104) = SIGNAL_ON, False, True))
                Case &H1E9
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(105) = SIGNAL_ON, False, True))
                Case &H1EA
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(106) = SIGNAL_ON, False, True))
                Case &H1EB
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(107) = SIGNAL_ON, False, True))
                Case &H1EC
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(108) = SIGNAL_ON, False, True))
                Case &H1ED
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(109) = SIGNAL_ON, False, True))
                Case &H1EE
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(110) = SIGNAL_ON, False, True))
                Case &H1F0
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(112) = SIGNAL_ON, False, True))
                Case &H1F1
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(113) = SIGNAL_ON, False, True))
                Case &H1F2
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(114) = SIGNAL_ON, False, True))
                Case &H1F3
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(115) = SIGNAL_ON, False, True))
                Case &H1F4
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(116) = SIGNAL_ON, False, True))
                Case &H1F5
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(117) = SIGNAL_ON, False, True))
                Case &H1F6
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(118) = SIGNAL_ON, False, True))
                Case &H1F7
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(119) = SIGNAL_ON, False, True))
                Case &H1F8
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(120) = SIGNAL_ON, False, True))
                Case &H1F9
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(121) = SIGNAL_ON, False, True))
                Case &H1FA
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(122) = SIGNAL_ON, False, True))
                Case &H1FB
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(123) = SIGNAL_ON, False, True))
                Case &H1FC
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(124) = SIGNAL_ON, False, True))
                Case &H1FD
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(125) = SIGNAL_ON, False, True))
                Case &H1FE
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(126) = SIGNAL_ON, False, True))
                Case &H200
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(128) = SIGNAL_ON, False, True))
                Case &H201
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(129) = SIGNAL_ON, False, True))
                Case &H202
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(130) = SIGNAL_ON, False, True))
                Case &H203
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(131) = SIGNAL_ON, False, True))
                Case &H204
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(132) = SIGNAL_ON, False, True))
                Case &H210
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(144) = SIGNAL_ON, False, True))
                Case &H211
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(145) = SIGNAL_ON, False, True))
                Case &H212
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(146) = SIGNAL_ON, False, True))
                Case &H213
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(147) = SIGNAL_ON, False, True))
                Case &H214
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(148) = SIGNAL_ON, False, True))
                Case &H218
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(152) = SIGNAL_ON, False, True))
                Case &H219
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(153) = SIGNAL_ON, False, True))
                Case &H21A
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(154) = SIGNAL_ON, False, True))
                Case &H21B
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(155) = SIGNAL_ON, False, True))
                Case &H21C
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(156) = SIGNAL_ON, False, True))
                Case &H220
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(160) = SIGNAL_ON, False, True))
                Case &H221
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(161) = SIGNAL_ON, False, True))
                Case &H222
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(162) = SIGNAL_ON, False, True))
                Case &H223
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(163) = SIGNAL_ON, False, True))
                Case &H224
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(164) = SIGNAL_ON, False, True))
                Case &H228
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(168) = SIGNAL_ON, False, True))
                Case &H229
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(169) = SIGNAL_ON, False, True))
                Case &H22A
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(170) = SIGNAL_ON, False, True))
                Case &H22B
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(171) = SIGNAL_ON, False, True))
                Case &H22C
                    WriteBAddr(nAddr, IIf(g_anGUI_RST_To_CV_New_BIT(172) = SIGNAL_ON, False, True))
            End Select
        End If

    End Sub
#End Region



End Module
