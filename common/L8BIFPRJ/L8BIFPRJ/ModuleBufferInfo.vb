Module ModuleBufferInfo
    Public Const GLASS_INFO_WORD_LEN = 167

    Public Const BUFFER_PORT1_START_ADDR = 1800
    Public Const BUFFER_PORT2_START_ADDR = 6800
    Public Const BUFFER_PORT3_START_ADDR = 11800

    Public Const UPPER_ARM_START_ADDR = 17000
    Public Const LOWER_ARM_START_ADDR = 17200

    Public Const GLASS_MODIFY_DATA_ADDR = 55000
    Public Const GLASS_MODIFY_DATA_ADDR1 = 55001

    Public g_anBufferPort1SlotInfo(GLASS_INFO_WORD_LEN) As Integer
    Public g_anBufferPort2SlotInfo(GLASS_INFO_WORD_LEN) As Integer
    Public g_anBufferPort3SlotInfo(GLASS_INFO_WORD_LEN) As Integer
    Public g_anBufferPort4SlotInfo(GLASS_INFO_WORD_LEN) As Integer





    Public Sub ReadBufGxInfo1(ByVal nPortNo As Integer, ByRef nGlassDataRef As Integer, ByRef nSampleGlassFlag As Integer, ByRef nProductcategory As Integer, ByRef nSlotInfo As Integer, ByRef strGlassID As String, ByRef strE1PPID As String, ByRef strE2PPID As String, ByRef strMESID As String, ByRef strProductCode As String, ByRef strCurrentRecipe As String, ByRef strPOPERID As String, ByRef strPLINEID As String, ByRef strPTOOLID As String, ByRef strCSTID As String, ByRef strOperationID As String, ByRef strGxGrade As String, ByRef strDMQCGrade As String, ByRef strGlassScrapFlag As String, ByRef nAOIFUNMode As Integer, ByRef nALNflag As Integer, ByRef nFIinspectionFlag As Integer)
        Dim nFor As Integer

        Select Case nPortNo
            Case 1
                nGlassDataRef = g_anBufferPort1SlotInfo(eBufferPortDevicNo.GX_DATA_REF)
                nSampleGlassFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.SAMPLE_GXFLAGE)
                nProductcategory = g_anBufferPort1SlotInfo(eBufferPortDevicNo.PRODUCT_CATEGORY)
                nSlotInfo = g_anBufferPort1SlotInfo(eBufferPortDevicNo.SLOT_INFO)

                For nFor = eBufferPortDevicNo.GXID_W1 To eBufferPortDevicNo.GXID_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.MESID_W1 To eBufferPortDevicNo.MESID_W4
                    strMESID = strMESID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PRODUCT_CODE_W1 To eBufferPortDevicNo.PRODUCT_CODE_W13
                    strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CURRENT_RECIPE_W1 To eBufferPortDevicNo.CURRENT_RECIPE_W16
                    strCurrentRecipe = strCurrentRecipe & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.POPERID_W1 To eBufferPortDevicNo.POPERID_W13
                    strPOPERID = strPOPERID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PLINEID_W1 To eBufferPortDevicNo.PLINEID_W4
                    strPLINEID = strPLINEID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PTOOLID_W1 To eBufferPortDevicNo.PTOOLID_W4
                    strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CSTID_W1 To eBufferPortDevicNo.CSTID_W3
                    strCSTID = strCSTID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.OPERATIONID_W1 To eBufferPortDevicNo.OPERATIONID_W13
                    strOperationID = strOperationID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                strGxGrade = ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(eBufferPortDevicNo.GLASS_GRADE))

                strDMQCGrade = ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(eBufferPortDevicNo.DMQC_GRADE))

                strGlassScrapFlag = ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(eBufferPortDevicNo.GX_SCRAP_FLAG))

                nAOIFUNMode = g_anBufferPort1SlotInfo(eBufferPortDevicNo.AOI_FUNCTION_MODE)

                nALNflag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.ALNFLAG)

                nFIinspectionFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.FI_INSPECTION_FLAG)

                For nFor = eBufferPortDevicNo.EQ1PPID_W1 To eBufferPortDevicNo.EQ1PPID_W2
                    strE1PPID = strE1PPID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.EQ2PPID_W1 To eBufferPortDevicNo.EQ2PPID_W2
                    strE2PPID = strE2PPID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

            Case 2
                nGlassDataRef = g_anBufferPort2SlotInfo(eBufferPortDevicNo.GX_DATA_REF)
                nSampleGlassFlag = g_anBufferPort2SlotInfo(eBufferPortDevicNo.SAMPLE_GXFLAGE)
                nProductcategory = g_anBufferPort2SlotInfo(eBufferPortDevicNo.PRODUCT_CATEGORY)
                nSlotInfo = g_anBufferPort2SlotInfo(eBufferPortDevicNo.SLOT_INFO)

                For nFor = eBufferPortDevicNo.GXID_W1 To eBufferPortDevicNo.GXID_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.MESID_W1 To eBufferPortDevicNo.MESID_W4
                    strMESID = strMESID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PRODUCT_CODE_W1 To eBufferPortDevicNo.PRODUCT_CODE_W13
                    strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CURRENT_RECIPE_W1 To eBufferPortDevicNo.CURRENT_RECIPE_W16
                    strCurrentRecipe = strCurrentRecipe & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.POPERID_W1 To eBufferPortDevicNo.POPERID_W13
                    strPOPERID = strPOPERID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PLINEID_W1 To eBufferPortDevicNo.PLINEID_W4
                    strPLINEID = strPLINEID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PTOOLID_W1 To eBufferPortDevicNo.PTOOLID_W4
                    strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CSTID_W1 To eBufferPortDevicNo.CSTID_W3
                    strCSTID = strCSTID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.OPERATIONID_W1 To eBufferPortDevicNo.OPERATIONID_W13
                    strOperationID = strOperationID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                strGxGrade = ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(eBufferPortDevicNo.GLASS_GRADE))

                strDMQCGrade = ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(eBufferPortDevicNo.DMQC_GRADE))

                strGlassScrapFlag = ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(eBufferPortDevicNo.GX_SCRAP_FLAG))

                nAOIFUNMode = g_anBufferPort2SlotInfo(eBufferPortDevicNo.AOI_FUNCTION_MODE)

                nALNflag = g_anBufferPort2SlotInfo(eBufferPortDevicNo.ALNFLAG)

                nFIinspectionFlag = g_anBufferPort2SlotInfo(eBufferPortDevicNo.FI_INSPECTION_FLAG)

                For nFor = eBufferPortDevicNo.EQ1PPID_W1 To eBufferPortDevicNo.EQ1PPID_W2
                    strE1PPID = strE1PPID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.EQ2PPID_W1 To eBufferPortDevicNo.EQ2PPID_W2
                    strE2PPID = strE2PPID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

            Case 3
                nGlassDataRef = g_anBufferPort3SlotInfo(eBufferPortDevicNo.GX_DATA_REF)
                nSampleGlassFlag = g_anBufferPort3SlotInfo(eBufferPortDevicNo.SAMPLE_GXFLAGE)
                nProductcategory = g_anBufferPort3SlotInfo(eBufferPortDevicNo.PRODUCT_CATEGORY)
                nSlotInfo = g_anBufferPort3SlotInfo(eBufferPortDevicNo.SLOT_INFO)

                For nFor = eBufferPortDevicNo.GXID_W1 To eBufferPortDevicNo.GXID_W6
                    strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.MESID_W1 To eBufferPortDevicNo.MESID_W4
                    strMESID = strMESID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PRODUCT_CODE_W1 To eBufferPortDevicNo.PRODUCT_CODE_W13
                    strProductCode = strProductCode & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CURRENT_RECIPE_W1 To eBufferPortDevicNo.CURRENT_RECIPE_W16
                    strCurrentRecipe = strCurrentRecipe & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.POPERID_W1 To eBufferPortDevicNo.POPERID_W13
                    strPOPERID = strPOPERID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PLINEID_W1 To eBufferPortDevicNo.PLINEID_W4
                    strPLINEID = strPLINEID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.PTOOLID_W1 To eBufferPortDevicNo.PTOOLID_W4
                    strPTOOLID = strPTOOLID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CSTID_W1 To eBufferPortDevicNo.CSTID_W3
                    strCSTID = strCSTID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.OPERATIONID_W1 To eBufferPortDevicNo.OPERATIONID_W13
                    strOperationID = strOperationID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                strGxGrade = ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(eBufferPortDevicNo.GLASS_GRADE))

                strDMQCGrade = ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(eBufferPortDevicNo.DMQC_GRADE))

                strGlassScrapFlag = ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(eBufferPortDevicNo.GX_SCRAP_FLAG))

                nAOIFUNMode = g_anBufferPort3SlotInfo(eBufferPortDevicNo.AOI_FUNCTION_MODE)

                nALNflag = g_anBufferPort3SlotInfo(eBufferPortDevicNo.ALNFLAG)

                nFIinspectionFlag = g_anBufferPort3SlotInfo(eBufferPortDevicNo.FI_INSPECTION_FLAG)

                For nFor = eBufferPortDevicNo.EQ1PPID_W1 To eBufferPortDevicNo.EQ1PPID_W2
                    strE1PPID = strE1PPID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.EQ2PPID_W1 To eBufferPortDevicNo.EQ2PPID_W2
                    strE2PPID = strE2PPID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

        End Select
    End Sub

    Public Sub ReadBufGxInfo2(ByVal nPortNo As Integer, ByRef nRDGRADE As Integer, ByRef nDGRADE As Integer, ByRef nGGRADE As Integer, ByRef strPSHGrade As String, ByRef nPToolIDIdx As Integer, ByRef strDMQCToolID As String, ByRef strChipGrade As String, ByRef nFIRMFLAG As Integer, ByRef nSCRPFLAG As Integer, ByRef nRWKFLAG As Integer, ByRef nGlassPortNo As Integer, ByRef nTargetPosition As Integer, ByRef nRobotSpeed As Integer, ByRef nRepairInkFlag As Integer, ByRef nProcessFlag As Integer, ByRef nFIFCFFlag As Integer, ByRef strEQ1StartTime As String, ByRef strEQ1EndTime As String, ByRef strEQ2StartTime As String, ByRef strEQ2EndTime As String, ByRef strEQ3StartTime As String, ByRef strEQ3EndTime As String, ByRef nRepairReviewFlag As Integer)
        Dim nFor As Integer
        Dim strTemp As String = ""
        Dim strChip As String = ""
        Dim anBit(MAX_BIT) As Short

        Dim strHexData As String = ""
        Dim nfirstWord As Integer = 0
        Dim nSecondWord As Integer = 0
        Dim nThirdWord As Integer = 0
        Dim nFourthWord As Integer = 0

        Dim strEQ1StartTime1 As String = ""
        Dim strEQ1StartTime2 As String = ""
        Dim strEQ1StartTime3 As String = ""
        Dim strEQ2StartTime1 As String = ""
        Dim strEQ2StartTime2 As String = ""
        Dim strEQ2StartTime3 As String = ""
        Dim strEQ3StartTime1 As String = ""
        Dim strEQ3StartTime2 As String = ""
        Dim strEQ3StartTime3 As String = ""

        Dim strEQ1EndTime1 As String = ""
        Dim strEQ1EndTime2 As String = ""
        Dim strEQ1EndTime3 As String = ""
        Dim strEQ2EndTime1 As String = ""
        Dim strEQ2EndTime2 As String = ""
        Dim strEQ2EndTime3 As String = ""
        Dim strEQ3EndTime1 As String = ""
        Dim strEQ3EndTime2 As String = ""
        Dim strEQ3EndTime3 As String = ""
        'Dim nRepairReviewFlag As Integer



        Select Case nPortNo
            Case 1
                nRepairReviewFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.REPAIRREVIEWFLAG)
                nRDGRADE = g_anBufferPort1SlotInfo(eBufferPortDevicNo.RDGRADE)
                nDGRADE = g_anBufferPort1SlotInfo(eBufferPortDevicNo.DGRADE)
                nGGRADE = g_anBufferPort1SlotInfo(eBufferPortDevicNo.GGRADE)

                For nFor = eBufferPortDevicNo.PSH_GRADE_W1 To eBufferPortDevicNo.PSH_GRADE_W2
                    strPSHGrade = strPSHGrade & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                nPToolIDIdx = g_anBufferPort1SlotInfo(eBufferPortDevicNo.PTOOLID_IDX)

                For nFor = eBufferPortDevicNo.DMQC_TOOLID_W1 To eBufferPortDevicNo.DMQC_TOOLID_W4
                    strDMQCToolID = strDMQCToolID & ConvertHiLowASCIIToString(g_anBufferPort1SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CHIP_GRADE_W1 To eBufferPortDevicNo.CHIP_GRADE_W9
                    strTemp = WordConvertToBin(g_anBufferPort1SlotInfo(nFor), anBit)

                    strChip = strChip & ProcessChipGrade(strTemp)
                    strTemp = ""
                Next
                strChipGrade = strChip

                strHexData = HexLeadZero(g_anBufferPort1SlotInfo(eBufferPortDevicNo.FIRMFLAG_SCRPFLAG_RWKFLAG))
                GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
                nRWKFLAG = nfirstWord
                nSCRPFLAG = nSecondWord
                nFIRMFLAG = nThirdWord

                nRobotSpeed = g_anBufferPort1SlotInfo(eBufferPortDevicNo.RST_SPEED)
                nGlassPortNo = g_anBufferPort1SlotInfo(eBufferPortDevicNo.PORT_NO)

                nRepairInkFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.REPAIR_INK_FLAG)
                nProcessFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.PROCESS_FLAG)
                nFIFCFFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.FIFCF_FLAG)

                nTargetPosition = g_anBufferPort1SlotInfo(eBufferPortDevicNo.TARGET_POSITION)

                strEQ1StartTime1 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ1_START_TIME1))
                strEQ1StartTime2 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ1_START_TIME2))
                strEQ1StartTime3 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ1_START_TIME3))
                strEQ1StartTime = strEQ1StartTime1 & strEQ1StartTime2 & strEQ1StartTime3

                strEQ2StartTime1 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ2_START_TIME1))
                strEQ2StartTime2 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ2_START_TIME2))
                strEQ2StartTime3 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ2_START_TIME3))
                strEQ2StartTime = strEQ2StartTime1 & strEQ2StartTime2 & strEQ2StartTime3

                strEQ3StartTime1 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ3_START_TIME1))
                strEQ3StartTime2 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ3_START_TIME2))
                strEQ3StartTime3 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ3_START_TIME3))
                strEQ3StartTime = strEQ3StartTime1 & strEQ3StartTime2 & strEQ3StartTime3


                strEQ1EndTime1 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ1_END_TIME1))
                strEQ1EndTime2 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ1_END_TIME2))
                strEQ1EndTime3 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ1_END_TIME3))
                strEQ1EndTime = strEQ1EndTime1 & strEQ1EndTime2 & strEQ1EndTime3

                strEQ2EndTime1 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ2_END_TIME1))
                strEQ2EndTime2 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ2_END_TIME2))
                strEQ2EndTime3 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ2_END_TIME3))
                strEQ2EndTime = strEQ2EndTime1 & strEQ2EndTime2 & strEQ2EndTime3

                strEQ3EndTime1 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ3_END_TIME1))
                strEQ3EndTime2 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ3_END_TIME2))
                strEQ3EndTime3 = ConvertDataTime(g_anBufferPort1SlotInfo(eBufferPortDevicNo.EQ3_END_TIME3))
                strEQ3EndTime = strEQ3EndTime1 & strEQ3EndTime2 & strEQ3EndTime3


            Case 2
                nRepairReviewFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.REPAIRREVIEWFLAG)
                nRDGRADE = g_anBufferPort2SlotInfo(eBufferPortDevicNo.RDGRADE)
                nDGRADE = g_anBufferPort2SlotInfo(eBufferPortDevicNo.DGRADE)
                nGGRADE = g_anBufferPort2SlotInfo(eBufferPortDevicNo.GGRADE)

                For nFor = eBufferPortDevicNo.PSH_GRADE_W1 To eBufferPortDevicNo.PSH_GRADE_W2
                    strPSHGrade = strPSHGrade & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                nPToolIDIdx = g_anBufferPort2SlotInfo(eBufferPortDevicNo.PTOOLID_IDX)

                For nFor = eBufferPortDevicNo.DMQC_TOOLID_W1 To eBufferPortDevicNo.DMQC_TOOLID_W4
                    strDMQCToolID = strDMQCToolID & ConvertHiLowASCIIToString(g_anBufferPort2SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CHIP_GRADE_W1 To eBufferPortDevicNo.CHIP_GRADE_W9
                    strTemp = WordConvertToBin(g_anBufferPort2SlotInfo(nFor), anBit)

                    strChip = strChip & ProcessChipGrade(strTemp)
                    strTemp = ""
                Next
                strChipGrade = strChip

                strHexData = HexLeadZero(g_anBufferPort2SlotInfo(eBufferPortDevicNo.FIRMFLAG_SCRPFLAG_RWKFLAG))
                GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
                nRWKFLAG = nfirstWord
                nSCRPFLAG = nSecondWord
                nFIRMFLAG = nThirdWord

                nRobotSpeed = g_anBufferPort2SlotInfo(eBufferPortDevicNo.RST_SPEED)
                nGlassPortNo = g_anBufferPort2SlotInfo(eBufferPortDevicNo.PORT_NO)

                nRepairInkFlag = g_anBufferPort2SlotInfo(eBufferPortDevicNo.REPAIR_INK_FLAG)
                nProcessFlag = g_anBufferPort2SlotInfo(eBufferPortDevicNo.PROCESS_FLAG)
                nFIFCFFlag = g_anBufferPort2SlotInfo(eBufferPortDevicNo.FIFCF_FLAG)

                nTargetPosition = g_anBufferPort2SlotInfo(eBufferPortDevicNo.TARGET_POSITION)

                strEQ1StartTime1 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ1_START_TIME1))
                strEQ1StartTime2 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ1_START_TIME2))
                strEQ1StartTime3 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ1_START_TIME3))
                strEQ1StartTime = strEQ1StartTime1 & strEQ1StartTime2 & strEQ1StartTime3

                strEQ2StartTime1 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ2_START_TIME1))
                strEQ2StartTime2 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ2_START_TIME2))
                strEQ2StartTime3 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ2_START_TIME3))
                strEQ2StartTime = strEQ2StartTime1 & strEQ2StartTime2 & strEQ2StartTime3

                strEQ3StartTime1 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ3_START_TIME1))
                strEQ3StartTime2 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ3_START_TIME2))
                strEQ3StartTime3 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ3_START_TIME3))
                strEQ3StartTime = strEQ3StartTime1 & strEQ3StartTime2 & strEQ3StartTime3


                strEQ1EndTime1 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ1_END_TIME1))
                strEQ1EndTime2 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ1_END_TIME2))
                strEQ1EndTime3 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ1_END_TIME3))
                strEQ1EndTime = strEQ1EndTime1 & strEQ1EndTime2 & strEQ1EndTime3

                strEQ2EndTime1 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ2_END_TIME1))
                strEQ2EndTime2 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ2_END_TIME2))
                strEQ2EndTime3 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ2_END_TIME3))
                strEQ2EndTime = strEQ2EndTime1 & strEQ2EndTime2 & strEQ2EndTime3

                strEQ3EndTime1 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ3_END_TIME1))
                strEQ3EndTime2 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ3_END_TIME2))
                strEQ3EndTime3 = ConvertDataTime(g_anBufferPort2SlotInfo(eBufferPortDevicNo.EQ3_END_TIME3))
                strEQ3EndTime = strEQ3EndTime1 & strEQ3EndTime2 & strEQ3EndTime3

            Case 3
                nRepairReviewFlag = g_anBufferPort1SlotInfo(eBufferPortDevicNo.REPAIRREVIEWFLAG)
                nRDGRADE = g_anBufferPort3SlotInfo(eBufferPortDevicNo.RDGRADE)
                nDGRADE = g_anBufferPort3SlotInfo(eBufferPortDevicNo.DGRADE)
                nGGRADE = g_anBufferPort3SlotInfo(eBufferPortDevicNo.GGRADE)

                For nFor = eBufferPortDevicNo.PSH_GRADE_W1 To eBufferPortDevicNo.PSH_GRADE_W2
                    strPSHGrade = strPSHGrade & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                nPToolIDIdx = g_anBufferPort3SlotInfo(eBufferPortDevicNo.PTOOLID_IDX)

                For nFor = eBufferPortDevicNo.DMQC_TOOLID_W1 To eBufferPortDevicNo.DMQC_TOOLID_W4
                    strDMQCToolID = strDMQCToolID & ConvertHiLowASCIIToString(g_anBufferPort3SlotInfo(nFor))
                Next

                For nFor = eBufferPortDevicNo.CHIP_GRADE_W1 To eBufferPortDevicNo.CHIP_GRADE_W9
                    strTemp = WordConvertToBin(g_anBufferPort3SlotInfo(nFor), anBit)

                    strChip = strChip & ProcessChipGrade(strTemp)
                    strTemp = ""
                Next
                strChipGrade = strChip

                strHexData = HexLeadZero(g_anBufferPort3SlotInfo(eBufferPortDevicNo.FIRMFLAG_SCRPFLAG_RWKFLAG))
                GetWordBlock(strHexData, nfirstWord, nSecondWord, nThirdWord, nFourthWord)
                nRWKFLAG = nfirstWord
                nSCRPFLAG = nSecondWord
                nFIRMFLAG = nThirdWord

                nRobotSpeed = g_anBufferPort3SlotInfo(eBufferPortDevicNo.RST_SPEED)
                nGlassPortNo = g_anBufferPort3SlotInfo(eBufferPortDevicNo.PORT_NO)

                nRepairInkFlag = g_anBufferPort3SlotInfo(eBufferPortDevicNo.REPAIR_INK_FLAG)
                nProcessFlag = g_anBufferPort3SlotInfo(eBufferPortDevicNo.PROCESS_FLAG)
                nFIFCFFlag = g_anBufferPort3SlotInfo(eBufferPortDevicNo.FIFCF_FLAG)

                nTargetPosition = g_anBufferPort3SlotInfo(eBufferPortDevicNo.TARGET_POSITION)

                strEQ1StartTime1 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ1_START_TIME1))
                strEQ1StartTime2 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ1_START_TIME2))
                strEQ1StartTime3 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ1_START_TIME3))
                strEQ1StartTime = strEQ1StartTime1 & strEQ1StartTime2 & strEQ1StartTime3

                strEQ2StartTime1 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ2_START_TIME1))
                strEQ2StartTime2 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ2_START_TIME2))
                strEQ2StartTime3 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ2_START_TIME3))
                strEQ2StartTime = strEQ2StartTime1 & strEQ2StartTime2 & strEQ2StartTime3

                strEQ3StartTime1 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ3_START_TIME1))
                strEQ3StartTime2 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ3_START_TIME2))
                strEQ3StartTime3 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ3_START_TIME3))
                strEQ3StartTime = strEQ3StartTime1 & strEQ3StartTime2 & strEQ3StartTime3


                strEQ1EndTime1 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ1_END_TIME1))
                strEQ1EndTime2 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ1_END_TIME2))
                strEQ1EndTime3 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ1_END_TIME3))
                strEQ1EndTime = strEQ1EndTime1 & strEQ1EndTime2 & strEQ1EndTime3

                strEQ2EndTime1 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ2_END_TIME1))
                strEQ2EndTime2 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ2_END_TIME2))
                strEQ2EndTime3 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ2_END_TIME3))
                strEQ2EndTime = strEQ2EndTime1 & strEQ2EndTime2 & strEQ2EndTime3

                strEQ3EndTime1 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ3_END_TIME1))
                strEQ3EndTime2 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ3_END_TIME2))
                strEQ3EndTime3 = ConvertDataTime(g_anBufferPort3SlotInfo(eBufferPortDevicNo.EQ3_END_TIME3))
                strEQ3EndTime = strEQ3EndTime1 & strEQ3EndTime2 & strEQ3EndTime3

        End Select
    End Sub

    Private Function ConvertDataTime(ByVal nValue As Integer) As String
        Dim strData As String = ""
        Dim nGetHibyte As Integer = 0
        Dim nGetLibyte As Integer = 0

        strData = HexLeadZero(nValue)

        ConvertDataTime = Left(strData, 2) & Right(strData, 2)
    End Function

End Module
