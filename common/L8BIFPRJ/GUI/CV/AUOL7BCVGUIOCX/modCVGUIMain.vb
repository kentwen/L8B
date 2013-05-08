Module modCVGUIMain
    'Public g_strDummyCancelResult As String

    Public g_strProssCMD_CSTID As String
    Public g_strProssCMD_SlotInfo As String
    Public g_strProssCMD_PortNumber As String
    Public g_strProssCMD_ProcessCMD As String
    Public g_strProssCMD_GxQTY As String

    Public m_strProssCMD_CSTID(3) As String
    Public m_strProssCMD_SlotInfo(3) As String
    Public m_strProssCMD_PortNumber(3) As String
    Public m_strProssCMD_ProcessCMD(3) As String
    Public m_strProssCMD_GxQTY(3) As String

    Public Structure CV_GUI_Status
        Dim strRunningMode As String
        Dim strAlarmOccurred As String
        Dim strCSTProductCode1 As String
        Dim strCSTProductCode2 As String
        Dim strCSTProductCode3 As String
        Dim strCSTProductCode4 As String
        Dim strCSTProductCode5 As String
        Dim strCVStatus As String
        Dim strGxExistInfo1 As String
        Dim strGxExistInfo2 As String
        Dim strGxExistInfo3 As String
        Dim strGxExistInfo4 As String
        Dim strGxExistInfo5 As String
        Dim strGxQTYInCST1 As String
        Dim strGxQTYInCST2 As String
        Dim strGxQTYInCST3 As String
        Dim strGxQTYInCST4 As String
        Dim strGxQTYInCST5 As String
        Dim strToolId As String
    End Structure

    Public Structure CV_GUI_Status_Port
        Dim nPort1PortMode As Integer
        Dim nPort2PortMode As Integer
        Dim nPort3PortMode As Integer
        Dim nPort4PortMode As Integer
        Dim nPort5PortMode As Integer
        Dim nPort1UnloadPortType As Integer
        Dim nPort2UnloadPortType As Integer
        Dim nPort3UnloadPortType As Integer
        Dim nPort4UnloadPortType As Integer
        Dim nPort5UnloadPortType As Integer
    End Structure

    Public Structure CV_GUI_Glass_Data_Request
        Dim strGxID As String
        Dim nGxJudgement As Integer
        Dim strProdCode As String
        Dim strPSHGrade As String
        Dim nVCRPos As Integer
    End Structure

    Public Structure CV_GUI_Glass_Abnormal_Case
        Dim nAbnormalCase As Integer
        Dim nGxPosition As Integer
        Dim strSourceGxID As String
        Dim strVCRGxID As String
    End Structure

    Public Structure CV_GUIGlassSlotUnmatchedReport
        Dim nPortNo As Integer
        Dim nSlotNumber As Integer
        Dim nUnmatchCase As Integer
    End Structure

    Public Structure CV_GUICSTLoadComplete
        Dim strPort1CSTID As String
        Dim strPort2CSTID As String
        Dim strPort3CSTID As String
        Dim strPort4CSTID As String
        Dim strPort5CSTID As String
        Dim nPort1MiniSlot As Integer
        Dim nPort2MiniSlot As Integer
        Dim nPort3MiniSlot As Integer
        Dim nPort4MiniSlot As Integer
        Dim nPort5MiniSlot As Integer
    End Structure

    'Public Structure CV_GUIGxFlowOut
    '    Dim strGxID As String
    '    Dim strProductCode As String
    '    Dim strPSHGroup As String
    '    Dim nVCRPosition As Integer
    '    Dim nGxJudgement As Integer

    '    Dim nSlotNumberPort1 As Integer
    '    Dim nSlotNumberPort2 As Integer
    '    Dim nSlotNumberPort3 As Integer
    '    Dim nSlotNumberPort4 As Integer
    '    Dim nSlotNumberPort5 As Integer
    'End Structure

    Public Structure CV_GUIGxFlowOut
        Dim strGxIDPort1 As String
        Dim strGxIDPort2 As String
        Dim strGxIDPort3 As String
        Dim strProductCodePort1 As String
        Dim strProductCodePort2 As String
        Dim strProductCodePort3 As String
        Dim strPSHGroupPort1 As String
        Dim strPSHGroupPort2 As String
        Dim strPSHGroupPort3 As String
        Dim nVCRPositionPort1 As Integer
        Dim nVCRPositionPort2 As Integer
        Dim nVCRPositionPort3 As Integer
        Dim nGxJudgementPort1 As Integer
        Dim nGxJudgementPort2 As Integer
        Dim nGxJudgementPort3 As Integer

        Dim nSlotNumberPort1 As Integer
        Dim nSlotNumberPort2 As Integer
        Dim nSlotNumberPort3 As Integer
        Dim nSlotNumberPort4 As Integer
        Dim nSlotNumberPort5 As Integer
    End Structure

    Public Structure CV_GUIGxFlowIn
        Dim strGxID As String
        Dim strProductCode As String
        Dim nSlotNumber As Integer
    End Structure

    Public Structure CV_GUIUnloadRequestByCV
        Dim nTotalGxQtyPort1 As Integer
        Dim nTotalGxQtyPort2 As Integer
        Dim nTotalGxQtyPort3 As Integer
        Dim nTotalGxQtyPort4 As Integer
        Dim nTotalGxQtyPort5 As Integer
        Dim nUnloadStatusPort1 As Integer
        Dim nUnloadStatusPort2 As Integer
        Dim nUnloadStatusPort3 As Integer
        Dim nUnloadStatusPort4 As Integer
        Dim nUnloadStatusPort5 As Integer
    End Structure

    Public Structure CV_GUIDummyCancelResult
        Dim nDummyCancelResult As Integer
    End Structure

    Public Structure CV_GUIPortChangeRequest
        Dim nPortMode As Integer
        Dim nPortType As Integer
        Dim strProductCode As String
        Dim nChangeResult As Integer
    End Structure

    Public Structure CV_GUITransferRequestCVtoRST
        Dim strGxIDPort1 As String
        Dim strGxIDPort2 As String
        Dim strGxIDPort3 As String
        Dim strGxIDPort4 As String
        Dim nGxJudgePort1 As Integer
        Dim nGxJudgePort2 As Integer
        Dim nGxJudgePort3 As Integer
        Dim nGxJudgePort4 As Integer
        Dim strProductCodePort1 As String
        Dim strProductCodePort2 As String
        Dim strProductCodePort3 As String
        Dim strProductCodePort4 As String
        Dim strPSHGroupPort1 As String
        Dim strPSHGroupPort2 As String
        Dim strPSHGroupPort3 As String
        Dim strPSHGroupPort4 As String
        Dim nVCRPosition As Integer
    End Structure

    Public Structure CV_GUITransferRequestRSTtoCV
        Dim strGxIDPort1 As String
        Dim strGxIDPort2 As String
        Dim strGxIDPort3 As String
        Dim strGxIDPort4 As String
        Dim nGxJudgePort1 As Integer
        Dim nGxJudgePort2 As Integer
        Dim nGxJudgePort3 As Integer
        Dim nGxJudgePort4 As Integer
        Dim strProductCodePort1 As String
        Dim strProductCodePort2 As String
        Dim strProductCodePort3 As String
        Dim strProductCodePort4 As String
        Dim strPSHGroupPort1 As String
        Dim strPSHGroupPort2 As String
        Dim strPSHGroupPort3 As String
        Dim strPSHGroupPort4 As String
        Dim nVCRPositionPort1 As Integer
        Dim nVCRPositionPort2 As Integer
        Dim nVCRPositionPort3 As Integer
        Dim nVCRPositionPort4 As Integer
    End Structure

    Public MyUpdataCVStatusGUI As CV_GUI_Status
    Public MyUpdataCVPortStatusGUI As CV_GUI_Status_Port
    Public MyUpdataCVGlassDataRequest As CV_GUI_Glass_Data_Request
    Public MyUpdataCVGlassAbnormalCase As CV_GUI_Glass_Abnormal_Case
    Public MyUpdataCVGlassSlotUnmatchedReport As CV_GUIGlassSlotUnmatchedReport
    Public MyUpdataCVCSTLoadComplete As CV_GUICSTLoadComplete
    Public MyUpdataCVGxFlowOut As CV_GUIGxFlowOut
    Public MyUpdataCVGxFlowIn As CV_GUIGxFlowIn
    Public MyUpdataCVUnloadRequestByCV As CV_GUIUnloadRequestByCV
    Public MyUpdataCVDummyCancelResult As CV_GUIDummyCancelResult
    Public MyUpdataCVPortChangeRequest As CV_GUIPortChangeRequest
    Public MyUpdataTransferRequestCVtoRST As CV_GUITransferRequestCVtoRST
    Public MyUpdataTransferRequestRSTtoCV As CV_GUITransferRequestRSTtoCV

End Module
