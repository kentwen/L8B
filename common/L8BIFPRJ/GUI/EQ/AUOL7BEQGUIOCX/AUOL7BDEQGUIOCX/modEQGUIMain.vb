Module modEQGUIMain

    Public Structure EQ_GUI_Status
        Dim nEQ1Status As Integer
        Dim nEQ2Status As Integer
        Dim nEQ3Status As Integer

        Dim strEQ1ToolID As String
        Dim strEQ2ToolID As String
        Dim strEQ3ToolID As String

        Dim nEQ1GxExistOnStage As Integer
        Dim nEQ2GxExistOnStage As Integer
        Dim nEQ3GxExistOnStage As Integer

        Dim nEQ1GxInProcess As Integer
        Dim nEQ2GxInProcess As Integer
        Dim nEQ3GxInProcess As Integer

        Dim nEQ1HandoffAvailable As Integer
        Dim nEQ2HandoffAvailable As Integer
        Dim nEQ3HandoffAvailable As Integer

        Dim nEQ1AlarmOccurred As Integer
        Dim nEQ2AlarmOccurred As Integer
        Dim nEQ3AlarmOccurred As Integer

        Dim nEQ1MPA1Stop As Integer
        Dim nEQ2MPA1Stop As Integer
        Dim nEQ3MPA1Stop As Integer

        Dim nEQ1MPA2Stop As Integer
        Dim nEQ2MPA2Stop As Integer
        Dim nEQ3MPA2Stop As Integer

        Dim nEQ1StationMode As Integer
        Dim nEQ2StationMode As Integer
        Dim nEQ3StationMode As Integer

        Dim nEQ1RemoteStatus As Integer
        Dim nEQ2RemoteStatus As Integer
        Dim nEQ3RemoteStatus As Integer
    End Structure

    Public Structure EQ_GUI_GXLoad
        Dim strEQ1CSTID As String
        Dim strEQ2CSTID As String
        Dim strEQ3CSTID As String

        Dim strEQ1CurrentRecipe As String
        Dim strEQ2CurrentRecipe As String
        Dim strEQ3CurrentRecipe As String

        Dim strEQ1DMQCGrade As String
        Dim strEQ2DMQCGrade As String
        Dim strEQ3DMQCGrade As String

        Dim strEQ1EPPID As String
        Dim strEQ2EPPID As String
        Dim strEQ3EPPID As String

        Dim strEQ1GxGrade As String
        Dim strEQ2GxGrade As String
        Dim strEQ3GxGrade As String

        Dim strEQ1GxID As String
        Dim strEQ2GxID As String
        Dim strEQ3GxID As String

        Dim strEQ1GxScrapFlag As String
        Dim strEQ2GxScrapFlag As String
        Dim strEQ3GxScrapFlag As String

        Dim strEQ1MESID As String
        Dim strEQ2MESID As String
        Dim strEQ3MESID As String

        Dim nEQ1MPAFlag As Integer
        Dim nEQ2MPAFlag As Integer
        Dim nEQ3MPAFlag As Integer

        Dim strEQ1OperationID As String
        Dim strEQ2OperationID As String
        Dim strEQ3OperationID As String

        Dim strEQ1PLineID As String
        Dim strEQ2PLineID As String
        Dim strEQ3PLineID As String

        Dim strEQ1PoperID As String
        Dim strEQ2PoperID As String
        Dim strEQ3PoperID As String

        Dim nEQ1ProductCategory As Integer
        Dim nEQ2ProductCategory As Integer
        Dim nEQ3ProductCategory As Integer

        Dim strEQ1ProductCode As String
        Dim strEQ2ProductCode As String
        Dim strEQ3ProductCode As String

        Dim strEQ1PToolID As String
        Dim strEQ2PToolID As String
        Dim strEQ3PToolID As String

        Dim nEQ1SampleGxFlag As Integer
        Dim nEQ2SampleGxFlag As Integer
        Dim nEQ3SampleGxFlag As Integer

        Dim nEQ1SlotInfo As Integer
        Dim nEQ2SlotInfo As Integer
        Dim nEQ3SlotInfo As Integer
    End Structure

    Public Structure EQ_GUI_GXUnload
        Dim strEQ1ChipGraade As String
        Dim strEQ2ChipGraade As String
        Dim strEQ3ChipGraade As String

        Dim strEQ1GxID As String
        Dim strEQ2GxID As String
        Dim strEQ3GxID As String

        Dim nEQ1ProcessResult As Integer
        Dim nEQ2ProcessResult As Integer
        Dim nEQ3ProcessResult As Integer

        Dim strEQ1PSH As String
        Dim strEQ2PSH As String
        Dim strEQ3PSH As String

        Dim nEQ1SampleGxFl As Integer
        Dim nEQ2SampleGxFl As Integer
        Dim nEQ3SampleGxFl As Integer

        Dim nEQ1SlotInfo As Integer
        Dim nEQ2SlotInfo As Integer
        Dim nEQ3SlotInfo As Integer
    End Structure

    Public Structure EQ_GUI_RecipeModify
        Dim strEQ1EPPID As String
        Dim strEQ2EPPID As String
        Dim strEQ3EPPID As String

        Dim nEQ1ModifyType As Integer
        Dim nEQ2ModifyType As Integer
        Dim nEQ3ModifyType As Integer
    End Structure

    Public Structure EQ_GUI_GlassErase
        Dim strEQ1GxID As String
        Dim strEQ2GxID As String
        Dim strEQ3GxID As String
    End Structure

    Public Structure EQ_GUI_RecipeCheck
        Dim strEQ1EPPID As String
        Dim strEQ2EPPID As String
        Dim strEQ3EPPID As String
        Dim nEQ1CheckResult As Integer
        Dim nEQ2CheckResult As Integer
        Dim nEQ3CheckResult As Integer
    End Structure

    Public MyUpdataEQStatusGUI As EQ_GUI_Status
    Public MyUpdataGUIEQGXLoad As EQ_GUI_GXLoad
    Public MyUpdataGUIEQGXUnload As EQ_GUI_GXUnload
    Public MyUpdataGUIEQRecipeModify As EQ_GUI_RecipeModify
    Public MyUpdataGUIEQGxErase As EQ_GUI_GlassErase
    Public MyUpdataGUIEQRecipeCheck As EQ_GUI_RecipeCheck
End Module
