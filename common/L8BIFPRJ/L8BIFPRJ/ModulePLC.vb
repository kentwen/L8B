
Module ModulePLC
    Public Const LEN_LINEID_BLOCK = 79
    Public My765LotInfoPort1(LEN_LINEID_BLOCK) As Integer
    Public My765LotInfoPort2(LEN_LINEID_BLOCK) As Integer
    Public My765LotInfoPort3(LEN_LINEID_BLOCK) As Integer

    Const LEN_MAX_SLOT_765 = 2239
    Public My765SlotInfoPort1(LEN_MAX_SLOT_765) As Integer
    Public My765SlotInfoPort2(LEN_MAX_SLOT_765) As Integer
    Public My765SlotInfoPort3(LEN_MAX_SLOT_765) As Integer

    Public Const LEN_S167_BLOCK1 = 49
    Public Const LEN_S167_BLOCK2 = 65


    Public Structure PLC_ZR_Addr
        Dim LotData() As Integer
        Dim SlotData(,) As Integer
    End Structure

    Public Structure PLC_S167_ZR_Addr
        Dim LotData() As Integer
        Dim SlotData(,) As Integer
    End Structure

    Public Structure PLC_New_WordData
        Dim m_strSlotGlassID(,) As String
        Dim m_nRDRAGE(,) As Integer
        Dim m_nDGRADE(,) As Integer
        Dim m_nGGRADE(,) As Integer
        Dim m_strPSHGroup(,) As String
        Dim m_strPTOOLID(,) As String
        Dim m_strDMQCToolID(,) As String
        Dim m_strChipGrade(,) As String
        Dim m_nFIRMFLAG(,) As Integer
        Dim m_nSCRPFLAG(,) As Integer
        Dim m_nRWKFLAG(,) As Integer
    End Structure

    Public Structure S1F67
        Dim strSlotGlassID(,) As String
        Dim nRDRAGE(,) As Integer
        Dim nDGRADE(,) As Integer
        Dim nGGRADE(,) As Integer
        Dim strPSHGroup(,) As String
        Dim strPTOOLID(,) As String
        Dim strDMQCToolID(,) As String
        Dim strChipGrade(,) As String
        Dim nFIRMFLAG(,) As Integer
        Dim nSCRPFLAG(,) As Integer
        Dim nRWKFLAG(,) As Integer



        Dim nProductCategory(,) As Integer
        Dim strCurrentRecipe(,) As String
        Dim strEQ1Tape(,) As String
        Dim strEQ2Ink(,) As String

        Dim strEQ1StartTime(,) As String
        Dim strEQ2StartTime(,) As String
        Dim strEQ3StartTime(,) As String

        Dim strEQ1EndTime(,) As String
        Dim strEQ2EndTime(,) As String
        Dim strEQ3EndTime(,) As String

    End Structure

    Public Structure PLC_NGGxToEQBufferPortAddr
        Dim nPort1StartAddr As Integer
        Dim nPort2StartAddr As Integer
        Dim nPort3StartAddr As Integer
        Dim nPort4StartAddr As Integer
    End Structure

    Public Structure PLC_BufferSlotStatusSetting
        Dim nPort1StartAddr As Integer
        Dim nPort2StartAddr As Integer
        Dim nPort3StartAddr As Integer
        Dim nPort4StartAddr As Integer
    End Structure

    Public Structure CheckTcpip
        Dim nNewConnect As Integer
        Dim nOldConnect As Integer
    End Structure

    Public MyPLC_S765_Addr As PLC_ZR_Addr
    Public MyPLC_S167_Addr As PLC_S167_ZR_Addr
    'Public MyPLC_New_WordDATA As PLC_New_WordData
    Public MyPLCBufferPortTargetBit As PLC_NGGxToEQBufferPortAddr
    Public MyPLCBufferSlotStatusSetting As PLC_BufferSlotStatusSetting

    Public MyCSTSlotInfo As S1F67
    Public MySlotInfo As S1F67

    Public MyCheckTcpip As CheckTcpip

    Private Sub ReDimArraySize()
        ReDim MyPLC_S765_Addr.LotData(MAX_PORTS)
        ReDim MyPLC_S765_Addr.SlotData(MAX_PORTS, MAX_SLOTS)

        ReDim MyPLC_S167_Addr.LotData(MAX_PORTS)
        ReDim MyPLC_S167_Addr.SlotData(MAX_PORTS, MAX_SLOTS)


        '----------------------------------------------------------------
        ReDim MyCSTSlotInfo.strSlotGlassID(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.nRDRAGE(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.nDGRADE(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.nGGRADE(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strPSHGroup(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strPTOOLID(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strDMQCToolID(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strChipGrade(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.nFIRMFLAG(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.nSCRPFLAG(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.nRWKFLAG(MAX_PORTS, MAX_SLOTS)


        ReDim MyCSTSlotInfo.nProductCategory(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strCurrentRecipe(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ1Tape(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ2Ink(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ1StartTime(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ2StartTime(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ3StartTime(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ1EndTime(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ2EndTime(MAX_PORTS, MAX_SLOTS)
        ReDim MyCSTSlotInfo.strEQ3EndTime(MAX_PORTS, MAX_SLOTS)


        '----------------------------------------------------------------

        '--------------------------------------------------------------
        ReDim MySlotInfo.strSlotGlassID(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.nRDRAGE(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.nDGRADE(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.nGGRADE(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strPSHGroup(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strPTOOLID(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strDMQCToolID(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strChipGrade(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.nFIRMFLAG(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.nSCRPFLAG(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.nRWKFLAG(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.nProductCategory(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strCurrentRecipe(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ1Tape(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ2Ink(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ1StartTime(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ2StartTime(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ3StartTime(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ1EndTime(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ2EndTime(MAX_PORTS, MAX_SLOTS)
        ReDim MySlotInfo.strEQ3EndTime(MAX_PORTS, MAX_SLOTS)


    End Sub

    Public Sub GetPLCLinkMap()
        Dim i As Short = 0
        Dim j As Short = 0
        Dim nAppendPortAddr As Integer = 0
        Dim nAppendSlotAddr As Integer = 0
        Dim nAppendS167PortAddr As Integer = 0
        Dim nAppendS167SlotAddr As Integer = 0

        Call ReDimArraySize()

        nAppendPortAddr = 3000
        nAppendSlotAddr = 40

        nAppendS167PortAddr = 5000
        nAppendS167SlotAddr = 66


        MyPLCBufferSlotStatusSetting.nPort1StartAddr = ePLC_ZR_ADDR.BUF_PORT1_SLOT_STATUS_START_ADDR
        MyPLCBufferSlotStatusSetting.nPort2StartAddr = ePLC_ZR_ADDR.BUF_PORT2_SLOT_STATUS_START_ADDR
        MyPLCBufferSlotStatusSetting.nPort3StartAddr = ePLC_ZR_ADDR.BUF_PORT3_SLOT_STATUS_START_ADDR
        MyPLCBufferSlotStatusSetting.nPort4StartAddr = ePLC_ZR_ADDR.BUF_PORT4_SLOT_STATUS_START_ADDR

        MyPLCBufferPortTargetBit.nPort1StartAddr = ePLC_ZR_ADDR.BUF_PORT1_TARGET_BIT_START_ADDR
        MyPLCBufferPortTargetBit.nPort2StartAddr = ePLC_ZR_ADDR.BUF_PORT2_TARGET_BIT_START_ADDR
        MyPLCBufferPortTargetBit.nPort3StartAddr = ePLC_ZR_ADDR.BUF_PORT3_TARGET_BIT_START_ADDR
        MyPLCBufferPortTargetBit.nPort4StartAddr = ePLC_ZR_ADDR.BUF_PORT4_TARGET_BIT_START_ADDR



        '765 and 167 
        For i = 1 To MAX_PORTS
            MyPLC_S765_Addr.LotData(i) = ePLC_ZR_ADDR.PORT1_LINEID + ((i - 1) * nAppendPortAddr)
            MyPLC_S167_Addr.LotData(i) = ePLC_ZR_ADDR.S167_PORT1_LINEID + ((i - 1) * nAppendS167PortAddr)

            For j = 1 To MAX_SLOTS
                MyPLC_S765_Addr.SlotData(i, j) = ePLC_ZR_ADDR.PORT1_GX_ID_SLOT1 + ((i - 1) * nAppendPortAddr) + ((j - 1) * nAppendSlotAddr)

                MyPLC_S167_Addr.SlotData(i, j) = ePLC_ZR_ADDR.S167_PORT1_GX_ID_SLOT1 + ((i - 1) * nAppendS167PortAddr) + ((j - 1) * nAppendS167SlotAddr)
            Next
        Next
    End Sub

End Module
