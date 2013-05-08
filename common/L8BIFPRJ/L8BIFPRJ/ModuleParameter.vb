Module ModuleParameter

    '------------------OCX Parameter-------------------------
    Public mvarCVGUISignalOnOff(5119) As Integer
    Public mvarCVGUISignalName(5119) As String
    Public mvarCVGUIModifyTime(5119) As String
    Public mvarCVGUIAlarmTable(512) As Integer

    Public mvarEQGUISignalOnOff(&H104F) As Integer
    Public mvarEQGUISignalName(&H104F) As String
    Public mvarEQGUIModifyTime(&H104F) As String
    Public mvarEQGUIAlarmTable(3, 512) As Integer
    '------------------OCX Parameter-------------------------

    Public Const MAX_SLOTS = 56
    Public Const MAX_PORTS = 3

    Public Const PORTNO1 = 1
    Public Const PORTNO2 = 2
    Public Const PORTNO3 = 3
    Public Const PORTNO4 = 4
    Public Const PORTNO5 = 5
    Public Const EQ01 = 1
    Public Const EQ02 = 2
    Public Const EQ03 = 3

    Public Const SIGNAL_ON = 1
    Public Const SIGNAL_OFF = 0

    Public Const LEN_MAX_SLOT_QTY = 3695
    ' 1~10 Slot Array Len
    Public Const LEN_S1F67_SLOT_ARRAY1 = 659
    ' 51~56 Slot Array Len
    Public Const LEN_S1F67_SLOT_ARRAY2 = 395
    '--------------------------------------
    Public Const LEN_GLASS_DATA1 = 99


    Public Const MAX_CST_PORT = 5
    Public Const MAX_CIMPCPORT = 4

    Public Const MAX_BUFFER_PORT = 4
    Public Const MAX_BUFFER_SLOT = 25



    '------------------------------------

    'Public Const LEN_A_CST_STATUS = 0
    'Public Const LEN_A_PORT_MODE = 0
    Public Const LEN_A_GLASS_SLOT = 5
    'Public Const LEN_A_RD_DG_GG_GRADE = 0
    Public Const LEN_A_PSH_GROUP = 1
    Public Const LEN_A_PTOOL_ID = 0
    Public Const LEN_A_DMQC_TOOL_ID = 3
    Public Const LEN_A_CHIP_GRADE = 8
    Public Const LEN_A_FIRMFLAG_SCRPFLAG_RWKFLAG = 0

    Public Const LEN_A_LINE_ID = 3
    Public Const LEN_A_TOOL_ID = 3
    Public Const LEN_A_CST_ID = 2
    Public Const LEN_A_PRODUCT_CODE = 12
    Public Const LEN_A_PRODUCT_CATEGORY = 1
    Public Const LEN_A_MEASUREMENT_ID = 3
    Public Const LEN_A_OP_ID = 12
    Public Const LEN_A_EPPID1 = 1
    Public Const LEN_A_EPPID2 = 1
    Public Const LEN_A_TARGET_POSITION = 0
    Public Const LEN_A_AOIFUNCTION = 0
    Public Const LEN_A_RUNNING_MODE = 0
    Public Const LEN_A_ROBOT_SPEED = 0
    Public Const LEN_A_GLASS_TYPE = 0
    Public Const LEN_A_VCR_POSITION = 0

    Public Const LEN_A_CURRENT_RECIPE = 15

    Public Const LEN_A_GLASS_ID = 5
    Public Const LEN_A_POPERID = 12
    Public Const LEN_A_PLINEID = 3
    Public Const LEN_A_PTOOLID = 3
    Public Const LEN_A_DMQC_TOOLID = 3
    Public Const LEN_A_GGRADE = 0
    Public Const LEN_A_DGRADE = 0
    Public Const LEN_A_RWKFLAG = 0
    Public Const LEN_A_SCRPFLAG = 0
    Public Const LEN_A_FIRMFLAG = 0
    Public Const LEN_A_FIFCFLAG = 0
    Public Const LEN_A_PROCESSFLAG = 0

    Public Const LEN_A_EPPID = 1
    Public Const LEN_A_MESID = 3
    Public Const LEN_A_GLASS_GRADE = 0
    Public Const LEN_A_DMQC_GRADE = 0

    Public Const LEN_A_RECIPE_CHECK_REQUEST_ID = 1
    Public Const LEN_A_RECIPE_QUERY_REQUEST_ID = 1
End Module
