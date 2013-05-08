
Module modIni
    Public Declare Function GetTickCount Lib "kernel32" () As Long
    Public MyLog As New RainbowTech.clsLogFactory

    Public Const STR_HSMSINI = "hsms.ini"
    Public Const STR_SYSTEMSEC = "System"

    Public Const RECIPE_SECTION = "Recipe"
    Public Const RECIPE_EXIST = "Exist"
    Public Const STR_S1F1INTERNAL = "S1F1Interval"
    Public Const STR_S2F17INTERNAL = "S2F17Interval"

    ' HSMS related section
    Public Const STR_T3 = "T3"
    Public Const STR_T5 = "T5"
    Public Const STR_T6 = "T6"
    Public Const STR_T7 = "T7"
    Public Const STR_T8 = "T8"
    Public Const STR_CT = "ConversationTimeout"
    Public Const STR_LINKTEST = "LinkTest"
    Public Const STR_RETRYLIMIT = "RetryLimit"
    Public Const STR_CONNECTMODE = "ConnectMode"
    Public Const STR_EQPIP = "EQPIP"
    Public Const STR_EQPTCP = "EQPTCP"
    Public Const STR_HOSTIP = "HostIP"
    Public Const STR_HOSTTCP = "HostTCP"
    Public Const STR_DEVICEID = "DeviceID"
    Public Const STR_AGVOPID = "AGVOPID"

    Public Const T3_DEFAULT = 45
    Public Const T5_DEFAULT = 10
    Public Const T6_DEFAULT = 5
    Public Const T7_DEFAULT = 10
    Public Const T8_DEFAULT = 5
    Public Const CT_DEFAULT = 60
    Public Const LINKTEST_DEFAULT = 30
    Public Const RETRYLIMIT_DEFAULT = 2
    Public Const EQPTCP_DEFAULT = 5000
    Public Const HOSTTCP_DEFAULT = 5000
    Public Const DEVICEID_DEFAULT = 0

    Public Const CONNECT_ACTIVE = 0
    Public Const CONNECT_PASSIVE = 1

    Public Const ASC_SPACE = 32

    Public Function AppendSpace(ByVal str As String, ByVal nMaxLen As Integer) As String
        AppendSpace = Left(str & Space(nMaxLen), nMaxLen)
    End Function

    Public Function GetNow() As String
        GetNow = Format(Now, "yyyyMMddHHmmss")
    End Function

End Module
