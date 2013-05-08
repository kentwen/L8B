Module ModuleGeneralGUI

    Enum eGeneralGUIStartAddr
        CV1_RST_SIGNAL_START_ADDR = &H1E0
        CV1_CV_SIGNAL_START_ADDR = &H13D0

        EQ1_RST_SIGNAL_START_ADDR = &H20
        EQ1_CV_SIGNAL_START_ADDR = &H320

        EQ2_RST_SIGNAL_START_ADDR = &HA0
        EQ2_CV_SIGNAL_START_ADDR = &H720

        EQ3_RST_SIGNAL_START_ADDR = &H120
        EQ3_CV_SIGNAL_START_ADDR = &H1020
    End Enum

    Public g_afReadCVSignalRSTBit(32) As Boolean
    Public g_afReadCVSignalCVBit(32) As Boolean

    Public g_afReadEQ1SignalRSTBit(32) As Boolean
    Public g_afReadEQ1SignalCVBit(32) As Boolean

    Public g_afReadEQ2SignalRSTBit(32) As Boolean
    Public g_afReadEQ2SignalCVBit(32) As Boolean

    Public g_afReadEQ3SignalRSTBit(32) As Boolean
    Public g_afReadEQ3SignalCVBit(32) As Boolean

    Public g_fMyGeneralGUITimerStart As Boolean

    Public g_fEQInterlock(3) As Boolean


    Public Sub ScanGeneralGUIBitAddr()
        'Bit(Hex) H1E0 ~ H1FF
        ReadBAddr(eGeneralGUIStartAddr.CV1_RST_SIGNAL_START_ADDR, g_afReadCVSignalRSTBit)

        'Bit(Hex) H13D0 ~ H13EF
        ReadBAddr(eGeneralGUIStartAddr.CV1_CV_SIGNAL_START_ADDR, g_afReadCVSignalCVBit)

        'EQ1
        ReadBAddr(eGeneralGUIStartAddr.EQ1_RST_SIGNAL_START_ADDR, g_afReadEQ1SignalRSTBit)
        ReadBAddr(eGeneralGUIStartAddr.EQ1_CV_SIGNAL_START_ADDR, g_afReadEQ1SignalCVBit)

        'EQ2
        ReadBAddr(eGeneralGUIStartAddr.EQ2_RST_SIGNAL_START_ADDR, g_afReadEQ2SignalRSTBit)
        ReadBAddr(eGeneralGUIStartAddr.EQ2_CV_SIGNAL_START_ADDR, g_afReadEQ2SignalCVBit)

        'EQ3
        ReadBAddr(eGeneralGUIStartAddr.EQ3_RST_SIGNAL_START_ADDR, g_afReadEQ3SignalRSTBit)
        ReadBAddr(eGeneralGUIStartAddr.EQ3_CV_SIGNAL_START_ADDR, g_afReadEQ3SignalCVBit)
    End Sub


End Module
