Imports RainbowTech.clsLogFactory

Public Module modFormatCode
    Public MyLog As New RainBowTech.clsLogFactory

    Public Enum eFormatCode
        LIST = &H1
        BINARY = &H21
        BOOLEAN1 = &H25
        ASCII = &H41
        JIS = &H45
        I1 = &H65
        I2 = &H69
        I4 = &H71
        I8 = &H61
        U1 = &HA5
        U2 = &HA9
        U4 = &HB1
        U8 = &HA1
        F8 = &H81
        F4 = &H91
        S9F11 = &H111
    End Enum

    Public Enum eTCPMode
        Active
        Passive
    End Enum

    Public Enum eStreamType
        TYPE_GET
        TYPE_SEND
    End Enum

    Public Structure T3Body
        Public lngT3_Time As Long
        Public MsgTag As clsSECSMessage
    End Structure
End Module
