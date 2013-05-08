Public Class clsEnumCtl
    Public Enum eStatusReplyType
        T_S1F66 = 1
        T_S1F74 = 2
        T_S1F76 = 3
        T_S1F90 = 4
        T_S1F98 = 5
        T_S5F66 = 6
        T_S6F66 = 7
        T_S6F70 = 8
        T_S6F86 = 9
        T_S6F88 = 10
        T_S6F92 = 11
        T_S7F72 = 12
    End Enum

    Public Enum eGlassGrade
        NO = 0
        OK = 1
        NG = 2
        GRAY = 3
    End Enum

    Public Enum eDMQCGrade
        NO = 0
        OK = 1
        NG = 2
        REVIEW = 3
    End Enum

    Public Enum eScrapType
        NONE = 0
        YES = 1
        RECYCLE = 2
    End Enum

    Public Enum eProcessENDCode
        NONE = 0
        LONF_UNLOADER = 1
        LONC_REMAINWORKS = 2
        EMPT_EMPTY = 3
        LONQ_CANCEL = 4
    End Enum

    Public Enum eProductCategory
        PRODCAT_NONE = -1
        PRODCAT_PRODUCT = 0
        PRODCAT_INITIAL = 1
        PRODCAT_MONITOR = 2
        PRODCAT_DUMMY = 3
    End Enum

    Public Enum eCassetteStatus
        CSTA_NONE = 0
        CSTA_WAIT = 1
        CSTA_INPROCESS = 2
        CSTA_END = 3
        CSTA_SUSPEND
    End Enum

    Public Enum eRiportType
        TYPE_S1F5_SFCD8 = 1
        TYPE_S1F89 = 2
    End Enum

    Enum eTerminalID
        TID_BROADCAST = 0
        TID_WARNING = 1
    End Enum

    Public Enum eSECSStatusReplyType
        T_S1F66 = 1
        T_S1F74 = 2
        T_S1F76 = 3
        T_S1F90 = 4
        T_S1F98 = 5
        T_S5F66 = 6
        T_S6F66 = 7
        T_S6F70 = 8
        T_S6F86 = 9
        T_S6F88 = 10
        T_S6F92 = 11
        T_S7F72 = 12
    End Enum

    Public Enum eLDSTA
        CST_LOAD_REQ = 0
        CST_LOAD_COMP = 1
        CST_PORT_DISABLE = 2
    End Enum

    Public Enum eULDSTA
        CST_UNLOAD_REQ = 0
        CST_UNLOAD_COMP = 1
        CST_PORT_DISABLE = 2
    End Enum

    Public Enum ePortMode
        MODE_NODEFINE = 0
        MODE_LOADER = 1
        MODE_UNLOADER = 2
        MODE_LDULD = 3
        MODE_BUFFER = 4
    End Enum

    Public Enum ePortType
        TYPE_NODEFINE = 0
        TYPE_I = 1
        TYPE_U = 2
    End Enum

    Public Enum ePortCategory
        CATEGORY_NODEFINE = 0
        CATEGORY_OK = 1
        CATEGORY_NG = 2
        CATEGORY_MIXED = 3
    End Enum

    Enum ePortStatus
        TSIP_LOADREQ = 0
        TSIP_EMPTY = 1
        TSIP_CST_PRESENT = 2
        TSIP_WAITSTART = 3
        TSIP_PROCESSING = 4
        TSIP_END = 5
        TSIP_END_WITHUNLOAD = 6
        TSIP_DISABLE = 7
    End Enum

    Enum eRemoteReplyCMD
        CMD_ACCEPTED = 0
        CMD_CMD_NO_DEFINE = 1
        CMD_CANT_EXECUTE = 2
        CMD_PARMETER_ERR = 3
        CMD_OTHER = 4
    End Enum

    Enum eACKC7ReplyCMD
        CMD_ACCEPTED = 0
        CMD_NODEFINE = 1
        CMD_CNAT_EXECUTE = 2
        CMD_LINEID_TOOLID_ERR = 3
        CMD_OTHER = 4
    End Enum

    Public Enum eRemoteStatus
        MODE_OFFLINE = 0
        MODE_ONLINECONTROL = 1
        MODE_ONLINEMONITOR = 2
    End Enum

    Public Enum eEQStatus
        EQ_IDLE = 0
        EQ_RUNNING = 1
        EQ_DOWN = 2
        EQ_STOP = 3
        EQ_SETUP = 4
    End Enum

    Public Enum eEQSubStatus
        SUBSTATUS_NO = 0
        SUBSTATUS_WARNING = 1
    End Enum

    Public Enum ePorcessMode
        MODE_NORMAL = 0
        MODE_PASS = 1
    End Enum

    Enum eFIFCFlag
        FLAG_NA = 0
        FLAG_F = 1
        FLAG_B = 2
    End Enum

    Enum eConnectType
        TYPE_ACTIVE
        TYPE_PASSIVET
    End Enum

    Public Enum eAlarmType
        TYPE_WARNING = 0
        TYPE_ALARM = 1
    End Enum

    Public Enum eAlarmFlag
        TYPE_RELEASE = 0
        TYPE_OCCUR = 1
    End Enum

    Public Enum eZLogType
        TYPE_SENDPRIM
        TYPE_SENDSECEND
        TYPE_RECEIVEPRI
        TYPE_RECEIVESECEND
        TYPE_METHOD
        TYPE_EVENT
        TYPE_PROPERTY
        TYPE_ERR
        TYPE_SECS_EMPTY
        TYPE_NA
    End Enum
End Class
