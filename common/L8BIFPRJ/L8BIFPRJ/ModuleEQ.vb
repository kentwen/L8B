Module ModuleEQ
    Public Const EQ_ALARM_WORD_LEN = 32
    Public Const MAX_EQ_ALARM_CODE = 512
    Public Const MAX_EQ = 3
    Public Const MAX_CHIP_GRADE = 9
    Public Const CHIP_GRADE_OK = "00"
    Public Const CHIP_GRADE_NG = "01"
    Public Const CHIP_GRADE_GRAY = "10"
    Public Const EQ_PARAMETER_LEN = 10

    'Private Const EQ_ADDR = 600
    'Private Const MAX_EQ_ARRAY_LEN = 199
    'Private g_anEQ_New_ZRWord(MAX_EQ_ARRAY_LEN) As Integer

    Public MyEQMAddr As EQ_M_Addr
    Public MyEQZRAddr As EQ_ZR_Addr
    Public MyEQNewWord As EQ_NEW_ZR_WordData
    Public MyEQOldWord As EQ_OLD_ZR_WordData

    Public g_strRecipeCheckPPID(MAX_EQ) As String
    Public g_strRecipeQueryPPID(MAX_EQ) As String


    Enum eEQ_ZR_ADDR
        EQ1_EPPID = 611
        EQ2_EPPID = 689
        EQ3_EPPID = 767

        EQ1_RECIPE_QUERY_REQ = 194
        EQ2_RECIPE_QUERY_REQ = 196
        EQ3_RECIPE_QUERY_REQ = 198
    End Enum

    Enum eEQStatus
        EQS_NONE = 0
        EQS_RUNNING = 1
        EQS_IDLE = 2
        EQS_DOWN = 3
        EQS_SETUP = 4
        EQS_STOPPED = 5
    End Enum



    Public Structure EQ_M_Addr
        Dim m_nRecipeCheckRequest() As Integer
        Dim m_nEQTransferReset() As Integer
        Dim m_nEQGlassEraseReportAck() As Integer
        Dim m_nEQGlassDataResultAck() As Integer
        Dim m_nEQRecipeModifyReportAck() As Integer
        Dim m_nEQRSTLinkRequest() As Integer
        Dim m_nEQDeleteStageGxData() As Integer
        Dim m_nEQRecipeQueryReq() As Integer
    End Structure

    Public Structure EQ_ZR_Addr
        Dim m_nRecipeCheck() As Integer
        Dim m_nRecipeQueryReq() As Integer
    End Structure

    Public Sub ReDimEQArraySize()
        ReDim MyEQMAddr.m_nRecipeCheckRequest(MAX_EQ)
        ReDim MyEQMAddr.m_nEQTransferReset(MAX_EQ)
        ReDim MyEQMAddr.m_nEQGlassEraseReportAck(MAX_EQ)
        ReDim MyEQMAddr.m_nEQGlassDataResultAck(MAX_EQ)
        ReDim MyEQMAddr.m_nEQRecipeModifyReportAck(MAX_EQ)
        ReDim MyEQMAddr.m_nEQRSTLinkRequest(MAX_EQ)
        ReDim MyEQMAddr.m_nEQDeleteStageGxData(MAX_EQ)
        ReDim MyEQMAddr.m_nEQRecipeQueryReq(MAX_EQ)

        '----M Addr --------------------------------------
        ReDim MyEQNewWord.mnEQGlassEraseReport(MAX_EQ)
        ReDim MyEQNewWord.mnEQRecipeCheckReport(MAX_EQ)
        ReDim MyEQNewWord.mnEQRecipeModifiedReport(MAX_EQ)
        ReDim MyEQNewWord.mnEQGlassDataResultReport(MAX_EQ)

        ReDim MyEQOldWord.mnEQGlassEraseReport(MAX_EQ)
        ReDim MyEQOldWord.mnEQRecipeCheckReport(MAX_EQ)
        ReDim MyEQOldWord.mnEQRecipeModifiedReport(MAX_EQ)
        ReDim MyEQOldWord.mnEQGlassDataResultReport(MAX_EQ)

        ReDim MyEQNewWord.mnstrGlassEraseID(MAX_EQ)
        ReDim MyEQNewWord.mnRecipeCheckResult(MAX_EQ)

        ReDim MyEQZRAddr.m_nRecipeCheck(MAX_EQ)
        ReDim MyEQZRAddr.m_nRecipeQueryReq(MAX_EQ)

        ReDim MyEQNewWord.mnSampleGlassFlag(MAX_EQ)
        ReDim MyEQNewWord.mnSlotinformation(MAX_EQ)
        ReDim MyEQNewWord.mnProcessResult(MAX_EQ)
        ReDim MyEQNewWord.strPSHGroup(MAX_EQ)
        ReDim MyEQNewWord.mnChipGrade(MAX_EQ, MAX_CHIP_GRADE)
        ReDim MyEQNewWord.mstrGlassID(MAX_EQ)

        ReDim MyEQNewWord.mnEQStatus(MAX_EQ)
        ReDim MyEQOldWord.mnEQStatus(MAX_EQ)

        ReDim MyEQNewWord.mnEQParameterReport(MAX_EQ, EQ_PARAMETER_LEN)

        ReDim MyEQNewWord.mnEQStatusReport(MAX_EQ)

        ReDim MyEQNewWord.mnEQGlassExist(MAX_EQ)
        ReDim MyEQOldWord.mnEQGlassExist(MAX_EQ)

        ReDim MyEQNewWord.mnEQInprocess(MAX_EQ)
        ReDim MyEQOldWord.mnEQInprocess(MAX_EQ)

        ReDim MyEQNewWord.mnEQHandoff(MAX_EQ)
        ReDim MyEQOldWord.mnEQHandoff(MAX_EQ)

        ReDim MyEQNewWord.mnEQMPA1Stop(MAX_EQ)
        ReDim MyEQOldWord.mnEQMPA1Stop(MAX_EQ)

        ReDim MyEQNewWord.mnMPA2Stop(MAX_EQ)
        ReDim MyEQOldWord.mnMPA2Stop(MAX_EQ)

        ReDim MyEQNewWord.mnAlarmOccured(MAX_EQ)
        ReDim MyEQOldWord.mnAlarmOccured(MAX_EQ)

        ReDim MyEQNewWord.mnEQInterlock(MAX_EQ)
        ReDim MyEQOldWord.mnEQInterlock(MAX_EQ)

        ReDim MyEQNewWord.mnEQAlarmWord(MAX_EQ, EQ_ALARM_WORD_LEN)
        ReDim MyEQOldWord.mnEQAlarmWord(MAX_EQ, EQ_ALARM_WORD_LEN)

        ReDim MyEQNewWord.mnEQAlarm(MAX_EQ, MAX_EQ_ALARM_CODE)
        ReDim MyEQOldWord.mnEQAlarm(MAX_EQ, MAX_EQ_ALARM_CODE)

        ReDim MyEQNewWord.mnEQStageGlassDataExist(MAX_EQ)
        ReDim MyEQOldWord.mnEQStageGlassDataExist(MAX_EQ)

        ReDim MyEQNewWord.mnEQinformationReport(MAX_EQ)
        ReDim MyEQOldWord.mnEQinformationReport(MAX_EQ)

        ReDim MyEQNewWord.mnEQRecipeParameterQuery(MAX_EQ)
        ReDim MyEQOldWord.mnEQRecipeParameterQuery(MAX_EQ)
    End Sub

    Public Structure EQ_NEW_ZR_WordData
        Dim mnEQGlassEraseReport() As Integer
        Dim mnEQRecipeCheckReport() As Integer
        Dim mnEQRecipeModifiedReport() As Integer
        Dim mnEQGlassDataResultReport() As Integer
        Dim mnEQStageGlassDataExist() As Integer
        Dim mnEQinformationReport() As Integer
        Dim mnEQRecipeParameterQuery() As Integer

        '----Event Bit-----------------------------
        Dim mnstrGlassEraseID() As String
        Dim mnRecipeCheckResult() As Integer

        Dim mnSampleGlassFlag() As Integer
        Dim mnSlotinformation() As Integer
        Dim mnProcessResult() As Integer
        Dim strPSHGroup() As String
        Dim mnChipGrade(,) As Integer
        Dim mstrGlassID() As String

        Dim mnEQStatus() As clsPLC.eEQStatus
        Dim mnEQParameterReport(,) As Integer

        Dim mnEQStatusReport() As Integer

        Dim mnEQGlassExist() As Integer
        Dim mnEQInprocess() As Integer
        Dim mnEQHandoff() As Integer
        Dim mnEQMPA1Stop() As Integer
        Dim mnMPA2Stop() As Integer
        Dim mnAlarmOccured() As Integer
        Dim mnEQInterlock() As Integer

        Dim mnEQAlarmWord(,) As Integer
        Dim mnEQAlarm(,) As Integer
    End Structure

    Public Structure EQ_OLD_ZR_WordData
        Dim mnEQGlassEraseReport() As Integer
        Dim mnEQRecipeCheckReport() As Integer
        Dim mnEQRecipeModifiedReport() As Integer
        Dim mnEQGlassDataResultReport() As Integer
        Dim mnEQStageGlassDataExist() As Integer
        Dim mnEQinformationReport() As Integer
        Dim mnEQRecipeParameterQuery() As Integer
        '----Event Bit-----------------------------

        Dim mnEQStatus() As clsPLC.eEQStatus

        Dim mnEQGlassExist() As Integer
        Dim mnEQInprocess() As Integer
        Dim mnEQHandoff() As Integer
        Dim mnEQMPA1Stop() As Integer
        Dim mnMPA2Stop() As Integer
        Dim mnAlarmOccured() As Integer
        Dim mnEQInterlock() As Integer

        Dim mnEQAlarmWord(,) As Integer
        Dim mnEQAlarm(,) As Integer
    End Structure

    Public Sub GetEQLinkMap()
        Dim nFor As Integer

        Call ReDimEQArraySize()

        For nFor = 1 To MAX_EQ
            MyEQMAddr.m_nRecipeCheckRequest(nFor) = eEQ_M_ADDR.EQ1_RECIPE_CHECK_REQUEST + (nFor - 1)
            MyEQMAddr.m_nEQTransferReset(nFor) = eEQ_M_ADDR.EQ1_TRANSFER_RESET + (nFor - 1)
            MyEQMAddr.m_nEQGlassEraseReportAck(nFor) = eEQ_M_ADDR.EQ1_GX_ERASE_REPORT_ACK + (nFor - 1)
            MyEQMAddr.m_nEQGlassDataResultAck(nFor) = eEQ_M_ADDR.EQ1_GX_DATA_RESULT_ACK + (nFor - 1)
            MyEQMAddr.m_nEQRecipeModifyReportAck(nFor) = eEQ_M_ADDR.EQ1_RECIPE_MODIFY_REPORT_ACK + (nFor - 1)
            MyEQMAddr.m_nEQRSTLinkRequest(nFor) = eEQ_M_ADDR.EQ1_RST_LINK_REQUEST + (nFor - 1)
        Next

        MyEQMAddr.m_nEQDeleteStageGxData(1) = eEQ_M_ADDR.EQ1_DEL_GX_DATA
        MyEQMAddr.m_nEQDeleteStageGxData(2) = eEQ_M_ADDR.EQ2_DEL_GX_DATA
        MyEQMAddr.m_nEQDeleteStageGxData(3) = eEQ_M_ADDR.EQ3_DEL_GX_DATA

        MyEQMAddr.m_nEQRecipeQueryReq(1) = eEQ_M_ADDR.EQ1_RECIPE_QUERY_REQ
        MyEQMAddr.m_nEQRecipeQueryReq(2) = eEQ_M_ADDR.EQ2_RECIPE_QUERY_REQ
        MyEQMAddr.m_nEQRecipeQueryReq(3) = eEQ_M_ADDR.EQ3_RECIPE_QUERY_REQ

        'EQRecipeCheck
        MyEQZRAddr.m_nRecipeCheck(1) = eEQ_ZR_ADDR.EQ1_EPPID
        MyEQZRAddr.m_nRecipeCheck(2) = eEQ_ZR_ADDR.EQ2_EPPID
        MyEQZRAddr.m_nRecipeCheck(3) = eEQ_ZR_ADDR.EQ3_EPPID

        MyEQZRAddr.m_nRecipeQueryReq(1) = eEQ_ZR_ADDR.EQ1_RECIPE_QUERY_REQ
        MyEQZRAddr.m_nRecipeQueryReq(2) = eEQ_ZR_ADDR.EQ2_RECIPE_QUERY_REQ
        MyEQZRAddr.m_nRecipeQueryReq(3) = eEQ_ZR_ADDR.EQ3_RECIPE_QUERY_REQ

    End Sub

    Public Sub ScanEQZRWordAddr()
        'Dim nFor As Integer
        'Dim anReadEQWordData(MAX_EQ_ARRAY_LEN) As Integer

        'Call ReadZRAddr(EQ_ADDR, anReadEQWordData)

        'For nFor = 0 To MAX_EQ_ARRAY_LEN
        '    g_anEQ_New_ZRWord(nFor) = anReadEQWordData(nFor)
        'Next

        Call ScanEQEventWord1()
        Call ScanEQEventWord2()

        Call ScanEQStatus()

        Call ScanEQStatusReport()

        Call ScanEQAlarm()

        Call ScanEQRecipeParameter()

    End Sub

#Region "Timer Scan EQ Addr Data Function"
    Private Sub ScanEQRecipeParameter()
        Dim nFor As Integer = 0

        For nFor = 1 To EQ_PARAMETER_LEN
            MyEQNewWord.mnEQParameterReport(1, nFor) = g_anCV_New_ZRWord(eCVDevicNo.EQ1_PARAMETER + (nFor - 1))

            MyEQNewWord.mnEQParameterReport(2, nFor) = g_anCV_New_ZRWord(eCVDevicNo.EQ2_PARAMETER + (nFor - 1))

            MyEQNewWord.mnEQParameterReport(3, nFor) = g_anCV_New_ZRWord(eCVDevicNo.EQ3_PARAMETER + (nFor - 1))
        Next
    End Sub

    Private Sub ScanEQAlarm()
        Dim nFor As Integer
        Dim i As Integer
        Dim nEQ1Index As Integer
        Dim nEQ2Index As Integer
        Dim nEQ3Index As Integer

        For nFor = 1 To MAX_EQ
            If nFor = 1 Then
                For i = eEQDevicNo.EQ1_ALARM_WORD1 To eEQDevicNo.EQ1_ALARM_WORD32
                    nEQ1Index = nEQ1Index + 1

                    MyEQNewWord.mnEQAlarmWord(nFor, nEQ1Index) = g_anRST_New_ZRWord(i)
                Next
            End If

            If nFor = 2 Then
                For i = eEQDevicNo.EQ2_ALARM_WORD1 To eEQDevicNo.EQ2_ALARM_WORD32
                    nEQ2Index = nEQ2Index + 1

                    MyEQNewWord.mnEQAlarmWord(nFor, nEQ2Index) = g_anRST_New_ZRWord(i)
                Next

            End If

            If nFor = 3 Then
                For i = eEQDevicNo.EQ3_ALARM_WORD1 To eEQDevicNo.EQ3_ALARM_WORD32
                    nEQ3Index = nEQ3Index + 1

                    MyEQNewWord.mnEQAlarmWord(nFor, nEQ3Index) = g_anRST_New_ZRWord(i)
                Next

            End If
        Next
    End Sub

    Private Sub ScanEQEventWord1()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eEQDevicNo.EVENT_WORD1), aBit)

        MyEQNewWord.mnEQGlassEraseReport(EQ01) = Val(Mid(strBinaryData, 16, 1))
        MyEQNewWord.mnEQGlassEraseReport(EQ02) = Val(Mid(strBinaryData, 15, 1))
        MyEQNewWord.mnEQGlassEraseReport(EQ03) = Val(Mid(strBinaryData, 14, 1))

        MyEQNewWord.mnEQRecipeCheckReport(EQ01) = Val(Mid(strBinaryData, 12, 1))
        MyEQNewWord.mnEQRecipeCheckReport(EQ02) = Val(Mid(strBinaryData, 11, 1))
        MyEQNewWord.mnEQRecipeCheckReport(EQ03) = Val(Mid(strBinaryData, 10, 1))

        MyEQNewWord.mnEQRecipeModifiedReport(EQ01) = Val(Mid(strBinaryData, 8, 1))
        MyEQNewWord.mnEQRecipeModifiedReport(EQ02) = Val(Mid(strBinaryData, 7, 1))
        MyEQNewWord.mnEQRecipeModifiedReport(EQ03) = Val(Mid(strBinaryData, 6, 1))

        MyEQNewWord.mnEQGlassDataResultReport(EQ01) = Val(Mid(strBinaryData, 4, 1))
        MyEQNewWord.mnEQGlassDataResultReport(EQ02) = Val(Mid(strBinaryData, 3, 1))
        MyEQNewWord.mnEQGlassDataResultReport(EQ03) = Val(Mid(strBinaryData, 2, 1))



    End Sub

    Private Sub ScanEQEventWord2()
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(g_anRST_New_ZRWord(eEQDevicNo.EVENT_WORD2), aBit)

        MyEQNewWord.mnEQStageGlassDataExist(1) = Val(Mid(strBinaryData, 16, 1))
        MyEQNewWord.mnEQStageGlassDataExist(2) = Val(Mid(strBinaryData, 15, 1))
        MyEQNewWord.mnEQStageGlassDataExist(3) = Val(Mid(strBinaryData, 14, 1))

        MyEQNewWord.mnEQinformationReport(1) = Val(Mid(strBinaryData, 12, 1))
        MyEQNewWord.mnEQinformationReport(2) = Val(Mid(strBinaryData, 11, 1))
        MyEQNewWord.mnEQinformationReport(3) = Val(Mid(strBinaryData, 10, 1))

        MyEQNewWord.mnEQRecipeParameterQuery(1) = Val(Mid(strBinaryData, 8, 1))
        MyEQNewWord.mnEQRecipeParameterQuery(2) = Val(Mid(strBinaryData, 7, 1))
        MyEQNewWord.mnEQRecipeParameterQuery(3) = Val(Mid(strBinaryData, 6, 1))


    End Sub

    Private Sub ScanEQStatus()
        MyEQNewWord.mnEQStatus(EQ01) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_STATUS)
        MyEQNewWord.mnEQStatus(EQ02) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_STATUS)
        MyEQNewWord.mnEQStatus(EQ03) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_STATUS)
    End Sub

    Private Sub ScanEQStatusReport()
        Dim nFor As Integer

        MyEQNewWord.mnEQStatusReport(EQ01) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_STATUS_REPORT)
        MyEQNewWord.mnEQStatusReport(EQ02) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_STATUS_REPORT)
        MyEQNewWord.mnEQStatusReport(EQ03) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_STATUS_REPORT)

        For nFor = 1 To MAX_EQ
            Call ProcessEQStatusReport(nFor)
        Next
    End Sub

    Private Sub ProcessEQStatusReport(ByVal nEQIndex As Integer)
        Dim aBit(MAX_BIT) As Short
        Dim strBinaryData As String = ""

        strBinaryData = WordConvertToBin(MyEQNewWord.mnEQStatusReport(nEQIndex), aBit)
        MyEQNewWord.mnEQGlassExist(nEQIndex) = Val(Mid(strBinaryData, 16, 1))
        MyEQNewWord.mnEQInprocess(nEQIndex) = Val(Mid(strBinaryData, 15, 1))
        MyEQNewWord.mnEQHandoff(nEQIndex) = Val(Mid(strBinaryData, 14, 1))
        MyEQNewWord.mnEQMPA1Stop(nEQIndex) = Val(Mid(strBinaryData, 13, 1))
        MyEQNewWord.mnMPA2Stop(nEQIndex) = Val(Mid(strBinaryData, 12, 1))
        MyEQNewWord.mnAlarmOccured(nEQIndex) = Val(Mid(strBinaryData, 11, 1))
        MyEQNewWord.mnEQInterlock(nEQIndex) = Val(Mid(strBinaryData, 10, 1))
    End Sub

#End Region

#Region "EQ IF ReadData Function"
    Public Function ReadRecipeQueryResult(ByVal nEQ As Integer) As Integer
        Select Case nEQ
            Case 1
                ReadRecipeQueryResult = g_anCV_New_ZRWord(eCVDevicNo.EQ1_EPPID_QUERY_RESULT)
            Case 2
                ReadRecipeQueryResult = g_anCV_New_ZRWord(eCVDevicNo.EQ2_EPPID_QUERY_RESULT)
            Case 3
                ReadRecipeQueryResult = g_anCV_New_ZRWord(eCVDevicNo.EQ3_EPPID_QUERY_RESULT)
        End Select
    End Function

    Public Function ReadProcessResultGlassID(ByVal nEQIndex As Integer) As String
        Dim strGlassID As String = ""

        Select Case nEQIndex
            Case 1
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ID1)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ID2)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ID3)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ID4)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ID5)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ID6))
            Case 2
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ID1)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ID2)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ID3)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ID4)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ID5)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ID6))
            Case 3
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ID1)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ID2)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ID3)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ID4)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ID5)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ID6))
        End Select
        ReadProcessResultGlassID = strGlassID
    End Function

    Public Function ReadProcessResultChipGrade(ByVal nEQIndex As Integer) As String
        Dim strChipGrade As String = ""
        Dim strTemp As String = ""
        Dim anBit(MAX_BIT) As Short
        Dim nFor As Integer

        Select Case nEQIndex
            Case 1
                MyEQNewWord.mnChipGrade(nEQIndex, 1) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE1)
                MyEQNewWord.mnChipGrade(nEQIndex, 2) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE2)
                MyEQNewWord.mnChipGrade(nEQIndex, 3) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE3)
                MyEQNewWord.mnChipGrade(nEQIndex, 4) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE4)
                MyEQNewWord.mnChipGrade(nEQIndex, 5) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE5)
                MyEQNewWord.mnChipGrade(nEQIndex, 6) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE6)
                MyEQNewWord.mnChipGrade(nEQIndex, 7) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE7)
                MyEQNewWord.mnChipGrade(nEQIndex, 8) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE8)
                MyEQNewWord.mnChipGrade(nEQIndex, 9) = g_anRST_New_ZRWord(eEQDevicNo.EQ1_CHIP_GRADE9)
            Case 2
                MyEQNewWord.mnChipGrade(nEQIndex, 1) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE1)
                MyEQNewWord.mnChipGrade(nEQIndex, 2) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE2)
                MyEQNewWord.mnChipGrade(nEQIndex, 3) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE3)
                MyEQNewWord.mnChipGrade(nEQIndex, 4) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE4)
                MyEQNewWord.mnChipGrade(nEQIndex, 5) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE5)
                MyEQNewWord.mnChipGrade(nEQIndex, 6) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE6)
                MyEQNewWord.mnChipGrade(nEQIndex, 7) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE7)
                MyEQNewWord.mnChipGrade(nEQIndex, 8) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE8)
                MyEQNewWord.mnChipGrade(nEQIndex, 9) = g_anRST_New_ZRWord(eEQDevicNo.EQ2_CHIP_GRADE9)
            Case 3
                MyEQNewWord.mnChipGrade(nEQIndex, 1) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE1)
                MyEQNewWord.mnChipGrade(nEQIndex, 2) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE2)
                MyEQNewWord.mnChipGrade(nEQIndex, 3) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE3)
                MyEQNewWord.mnChipGrade(nEQIndex, 4) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE4)
                MyEQNewWord.mnChipGrade(nEQIndex, 5) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE5)
                MyEQNewWord.mnChipGrade(nEQIndex, 6) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE6)
                MyEQNewWord.mnChipGrade(nEQIndex, 7) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE7)
                MyEQNewWord.mnChipGrade(nEQIndex, 8) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE8)
                MyEQNewWord.mnChipGrade(nEQIndex, 9) = g_anRST_New_ZRWord(eEQDevicNo.EQ3_CHIP_GRADE9)
        End Select

        For nFor = 1 To MAX_CHIP_GRADE
            strTemp = WordConvertToBin(MyEQNewWord.mnChipGrade(nEQIndex, nFor), anBit)
            strChipGrade = strChipGrade & ProcessChipGrade(strTemp)
            strTemp = ""
        Next

        ReadProcessResultChipGrade = strChipGrade
    End Function

    Public Function ProcessChipGrade(ByVal strValue As String) As String
        Dim strChipGrade As String = ""
        Dim astrChipGrade(8) As String '一個Word八組Chip ==>共 8*9 =72 ChipGrade
        Dim nFor As Integer

        For nFor = 1 To 8
            astrChipGrade(nFor) = Mid(strValue, (15 - ((nFor - 1) * 2)), 2)
        Next

        'For nFor = 8 To 1 Step -1
        For nFor = 1 To 8
            If astrChipGrade(nFor) = CHIP_GRADE_OK Then
                strChipGrade = strChipGrade + "O"
            ElseIf astrChipGrade(nFor) = CHIP_GRADE_NG Then
                strChipGrade = strChipGrade + "X"
            ElseIf astrChipGrade(nFor) = CHIP_GRADE_GRAY Then
                strChipGrade = strChipGrade + "G"
            Else
                strChipGrade = strChipGrade + " "
            End If
        Next

        ProcessChipGrade = strChipGrade
    End Function

    Public Function ReadProcessResultPSHGroup(ByVal nEQIndex As Integer) As String
        Dim strPSHGroup As String = ""

        Select Case nEQIndex
            Case 1
                strPSHGroup = ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_PSH_GROUP))
            Case 2
                strPSHGroup = ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_PSH_GROUP))
            Case 3
                strPSHGroup = ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_PSH_GROUP))
        End Select
        ReadProcessResultPSHGroup = strPSHGroup
    End Function

    Public Function ReadProcessResult(ByVal nEQIndex As Integer) As Integer
        Dim nProcessResult As Integer

        Select Case nEQIndex
            Case 1
                nProcessResult = g_anRST_New_ZRWord(eEQDevicNo.EQ1_PROCESS_RESULT)
            Case 2
                nProcessResult = g_anRST_New_ZRWord(eEQDevicNo.EQ2_PROCESS_RESULT)
            Case 3
                nProcessResult = g_anRST_New_ZRWord(eEQDevicNo.EQ3_PROCESS_RESULT)
        End Select
        ReadProcessResult = nProcessResult
    End Function

    Public Function ReadProcessResultSlotNo(ByVal nEQIndex As Integer) As Integer
        Dim nSlotNo As Integer

        Select Case nEQIndex
            Case 1
                nSlotNo = g_anRST_New_ZRWord(eEQDevicNo.EQ1_SLOT_INFO)
            Case 2
                nSlotNo = g_anRST_New_ZRWord(eEQDevicNo.EQ2_SLOT_INFO)
            Case 3
                nSlotNo = g_anRST_New_ZRWord(eEQDevicNo.EQ3_SLOT_INFO)
        End Select
        ReadProcessResultSlotNo = nSlotNo
    End Function

    Public Function ReadProcessResultSampleGlassFlag(ByVal nEQIndex As Integer) As Integer
        Dim nSampleGlassFlag As Integer

        Select Case nEQIndex
            Case 1
                nSampleGlassFlag = g_anRST_New_ZRWord(eEQDevicNo.EQ1_SAMPLE_GLASS_FLAG)
            Case 2
                nSampleGlassFlag = g_anRST_New_ZRWord(eEQDevicNo.EQ2_SAMPLE_GLASS_FLAG)
            Case 3
                nSampleGlassFlag = g_anRST_New_ZRWord(eEQDevicNo.EQ3_SAMPLE_GLASS_FLAG)
        End Select
        ReadProcessResultSampleGlassFlag = nSampleGlassFlag
    End Function

    Public Function ReadModifyType(ByVal nEQIndex As Integer) As Integer
        Dim nModifyType As Integer

        Select Case nEQIndex
            Case 1
                nModifyType = g_anRST_New_ZRWord(eEQDevicNo.EQ1_MODIFY_TYPE)
            Case 2
                nModifyType = g_anRST_New_ZRWord(eEQDevicNo.EQ2_MODIFY_TYPE)
            Case 3
                nModifyType = g_anRST_New_ZRWord(eEQDevicNo.EQ3_MODIFY_TYPE)
        End Select
        ReadModifyType = nModifyType
    End Function

    Public Function ReadEQRecipeModifiyID(ByVal nEQIndex As Integer) As String
        Dim strPPID As String = ""

        Select Case nEQIndex
            Case 1
                strPPID = strPPID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_EPPID_MODIFIED_REPORT1)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_EPPID_MODIFIED_REPORT2))
            Case 2
                strPPID = strPPID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_EPPID_MODIFIED_REPORT1)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_EPPID_MODIFIED_REPORT2))
            Case 3
                strPPID = strPPID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_EPPID_MODIFIED_REPORT1)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_EPPID_MODIFIED_REPORT2))
        End Select
        ReadEQRecipeModifiyID = strPPID
    End Function

    Public Function ReadRecipeCheckResult(ByVal nEQIndex As Integer) As Integer
        Dim nResult As Integer = 0

        Select Case nEQIndex
            Case 1
                nResult = g_anRST_New_ZRWord(eEQDevicNo.EQ1_RECIPE_CHECK_RESUlT)
            Case 2
                nResult = g_anRST_New_ZRWord(eEQDevicNo.EQ2_RECIPE_CHECK_RESUlT)
            Case 3
                nResult = g_anRST_New_ZRWord(eEQDevicNo.EQ3_RECIPE_CHECK_RESUlT)
        End Select

        'MyEQNewWord.mnRecipeCheckResult(nEQIndex) = nResult
        ReadRecipeCheckResult = nResult
    End Function

    Public Function ReadGlassErase(ByVal nEQIndex As Integer) As String
        Dim strGlassID As String = ""

        Select Case nEQIndex
            Case 1
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ERASE_ID1)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ERASE_ID2)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ERASE_ID3)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ERASE_ID4)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ERASE_ID5)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ1_GX_ERASE_ID6))
            Case 2
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ERASE_ID1)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ERASE_ID2)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ERASE_ID3)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ERASE_ID4)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ERASE_ID5)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ2_GX_ERASE_ID6))
            Case 3
                strGlassID = strGlassID & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ERASE_ID1)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ERASE_ID2)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ERASE_ID3)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ERASE_ID4)) & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ERASE_ID5)) _
                & ConvertHiLowASCIIToString(g_anRST_New_ZRWord(eEQDevicNo.EQ3_GX_ERASE_ID6))
        End Select
        'MyEQNewWord.mnstrGlassEraseID(nEQIndex) = strGlassID
        ReadGlassErase = strGlassID
    End Function
#End Region

End Module
