Imports Nini.Config

Public Class frmTimeOutSetting

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        MyCV1TimeoutSetting.nLinkEstablishmentT1 = Val(Me.txtCV1LinkT1.Text)
        MyCV1TimeoutSetting.nRobotT1 = Val(Me.txtCV1RobotT1.Text)
        MyCV1TimeoutSetting.nRobotT5 = Val(Me.txtCV1RobotT5.Text)
        MyCV1TimeoutSetting.nCSTLoadReqT2 = Val(Me.txtCV1CSTLoadReqT2.Text)
        MyCV1TimeoutSetting.nCSTLoadCompT2 = Val(Me.txtCV1CSTLoadCompT2.Text)
        MyCV1TimeoutSetting.nCSTProcessReqT1 = Val(Me.txtCV1CSTProcessReqT1.Text)
        MyCV1TimeoutSetting.nCSTProcessReqT3 = Val(Me.txtCV1CSTProcessReqT3.Text)
        MyCV1TimeoutSetting.nGXGlowOutT2 = Val(Me.txtCV1GXGlowOutT2.Text)
        MyCV1TimeoutSetting.nGXFlowInT2 = Val(Me.txtCV1GXFlowInT2.Text)
        MyCV1TimeoutSetting.nGXDataReqT2 = Val(Me.txtCV1GXDataReqT2.Text)
        MyCV1TimeoutSetting.nCSTUnloadReqT2 = Val(Me.txtCV1CSTUnloadReqT2.Text)
        MyCV1TimeoutSetting.nCSTUnloadCompT2 = Val(Me.txtCV1CSTUnloadCompT2.Text)
        MyCV1TimeoutSetting.nPortChangeReqT1 = Val(Me.txtCV1PortChangeReqT1.Text)
        MyCV1TimeoutSetting.nPortChangeReqT3 = Val(Me.txtCV1PortChangeReqT3.Text)
        MyCV1TimeoutSetting.nGXSlotUnmatchT2 = Val(Me.txtCV1GXSlotUnmatchT2.Text)
        MyCV1TimeoutSetting.nGXAbnormalT2 = Val(Me.txtCV1GXAbnormalT2.Text)
        MyCV1TimeoutSetting.nTransferResetT1 = Val(Me.txtCV1TransferResetT1.Text)
        MyCV1TimeoutSetting.nTransferResetT3 = Val(Me.txtCV1TransferResetT3.Text)

        MyCV1TimeoutSetting.nPresentT2 = Val(Me.txtCV1PresentT2.Text)
        MyCV1TimeoutSetting.nRemoveT2 = Val(Me.txtCV1RemoveT2.Text)

        MyCV1TimeoutSetting.nCSTUnloadReqT0 = Val(Me.txtCV1CSTUnloadReqT0.Text)
        MyCV1TimeoutSetting.nPauseT1 = Val(Me.txtPauseT1.Text)
        MyCV1TimeoutSetting.nPauseT3 = Val(Me.txtPauseT3.Text)
        MyCV1TimeoutSetting.nResumeT1 = Val(Me.txtResumeT1.Text)
        MyCV1TimeoutSetting.nResumeT3 = Val(Me.txtResumeT3.Text)
        MyCV1TimeoutSetting.nDummyCancelT1 = Val(Me.txtDummyCancelT1.Text)
        MyCV1TimeoutSetting.nDummyCancelT3 = Val(Me.txtDummyCancelT3.Text)


        'MyCV2TimeoutSetting.nLinkEstablishmentT1 = Val(Me.txtCV2LinkT1.Text)
        'MyCV2TimeoutSetting.nRobotT1 = Val(Me.txtCV2RobotT1.Text)
        'MyCV2TimeoutSetting.nRobotT5 = Val(Me.txtCV2RobotT5.Text)
        'MyCV2TimeoutSetting.nCSTLoadReqT2 = Val(Me.txtCV2CSTLoadReqT2.Text)
        'MyCV2TimeoutSetting.nCSTLoadCompT2 = Val(Me.txtCV2CSTLoadCompT2.Text)
        'MyCV2TimeoutSetting.nCSTProcessReqT1 = Val(Me.txtCV2CSTProcessReqT1.Text)
        'MyCV2TimeoutSetting.nCSTProcessReqT3 = Val(Me.txtCV2CSTProcessReqT3.Text)
        'MyCV2TimeoutSetting.nGXGlowOutT2 = Val(Me.txtCV2GXGlowOutT2.Text)
        'MyCV2TimeoutSetting.nGXFlowInT2 = Val(Me.txtCV2GXFlowInT2.Text)
        'MyCV2TimeoutSetting.nGXDataReqT2 = Val(Me.txtCV2GXDataReqT2.Text)
        'MyCV2TimeoutSetting.nCSTUnloadReqT2 = Val(Me.txtCV2CSTUnloadReqT2.Text)
        'MyCV2TimeoutSetting.nCSTUnloadCompT2 = Val(Me.txtCV2CSTUnloadCompT2.Text)
        'MyCV2TimeoutSetting.nPortChangeReqT1 = Val(Me.txtCV2PortChangeReqT1.Text)
        'MyCV2TimeoutSetting.nPortChangeReqT3 = Val(Me.txtCV2PortChangeReqT3.Text)
        'MyCV2TimeoutSetting.nGXSlotUnmatchT2 = Val(Me.txtCV2GXSlotUnmatchT2.Text)
        'MyCV2TimeoutSetting.nGXAbnormalT2 = Val(Me.txtCV2GXAbnormalT2.Text)
        'MyCV2TimeoutSetting.nTransferResetT1 = Val(Me.txtCV2TransferResetT1.Text)
        'MyCV2TimeoutSetting.nTransferResetT3 = Val(Me.txtCV2TransferResetT3.Text)

        MyEQ1TimeoutSetting.nEQLinkEstablishmentT1 = Val(Me.txtEQ1LinkEstablishmentT1.Text)
        MyEQ1TimeoutSetting.nEQLoadGXT1 = Val(Me.txtEQ1LoadGXT1.Text)
        MyEQ1TimeoutSetting.nEQLoadGXT5 = Val(Me.txtEQ1LoadGXT5.Text)
        MyEQ1TimeoutSetting.nEQUnloadGXT1 = Val(Me.txtEQ1UnloadGXT1.Text)
        MyEQ1TimeoutSetting.nEQUnloadGXT5 = Val(Me.txtEQ1UnloadGXT5.Text)
        MyEQ1TimeoutSetting.nEQExchangeGXT1 = Val(Me.txtEQ1ExchangeGXT1.Text)
        MyEQ1TimeoutSetting.nEQExchangeGXT5 = Val(Me.txtEQ1ExchangeGXT5.Text)
        MyEQ1TimeoutSetting.nEQRecipeModifyT2 = Val(Me.txtEQ1RecipeModifyT2.Text)
        MyEQ1TimeoutSetting.nEQRecipeExistCheckT1 = Val(Me.txtEQ1RecipeExistCheckT1.Text)
        MyEQ1TimeoutSetting.nEQRecipeExistCheckT3 = Val(Me.txtEQ1RecipeExistCheckT3.Text)
        MyEQ1TimeoutSetting.nEQGXEraseT2 = Val(Me.txtEQ1GXEraseT2.Text)
        MyEQ1TimeoutSetting.nEQTransferResetT1 = Val(Me.txtEQ1TransferResetT1.Text)
        MyEQ1TimeoutSetting.nEQTransferResetT3 = Val(Me.txtEQ1TransferResetT3.Text)

        MyEQ1TimeoutSetting.nEQRecipeQueryT1 = Val(Me.txtEQ1RecipeQueryT1.Text)
        MyEQ1TimeoutSetting.nEQRecipeQueryT3 = Val(Me.txtEQ1RecipeQueryT3.Text)

        MyEQ2TimeoutSetting.nEQLinkEstablishmentT1 = Val(Me.txtEQ2LinkEstablishmentT1.Text)
        MyEQ2TimeoutSetting.nEQLoadGXT1 = Val(Me.txtEQ2LoadGXT1.Text)
        MyEQ2TimeoutSetting.nEQLoadGXT5 = Val(Me.txtEQ2LoadGXT5.Text)
        MyEQ2TimeoutSetting.nEQUnloadGXT1 = Val(Me.txtEQ2UnloadGXT1.Text)
        MyEQ2TimeoutSetting.nEQUnloadGXT5 = Val(Me.txtEQ2UnloadGXT5.Text)
        MyEQ2TimeoutSetting.nEQExchangeGXT1 = Val(Me.txtEQ2ExchangeGXT1.Text)
        MyEQ2TimeoutSetting.nEQExchangeGXT5 = Val(Me.txtEQ2ExchangeGXT5.Text)
        MyEQ2TimeoutSetting.nEQRecipeModifyT2 = Val(Me.txtEQ2RecipeModifyT2.Text)
        MyEQ2TimeoutSetting.nEQRecipeExistCheckT1 = Val(Me.txtEQ2RecipeExistCheckT1.Text)
        MyEQ2TimeoutSetting.nEQRecipeExistCheckT3 = Val(Me.txtEQ2RecipeExistCheckT3.Text)
        MyEQ2TimeoutSetting.nEQGXEraseT2 = Val(Me.txtEQ2GXEraseT2.Text)
        MyEQ2TimeoutSetting.nEQTransferResetT1 = Val(Me.txtEQ2TransferResetT1.Text)
        MyEQ2TimeoutSetting.nEQTransferResetT3 = Val(Me.txtEQ2TransferResetT3.Text)

        MyEQ2TimeoutSetting.nEQRecipeQueryT1 = Val(Me.txtEQ2RecipeQueryT1.Text)
        MyEQ2TimeoutSetting.nEQRecipeQueryT3 = Val(Me.txtEQ2RecipeQueryT3.Text)

        MyEQ3TimeoutSetting.nEQLinkEstablishmentT1 = Val(Me.txtEQ3LinkEstablishmentT1.Text)
        MyEQ3TimeoutSetting.nEQLoadGXT1 = Val(Me.txtEQ3LoadGXT1.Text)
        MyEQ3TimeoutSetting.nEQLoadGXT5 = Val(Me.txtEQ3LoadGXT5.Text)
        MyEQ3TimeoutSetting.nEQUnloadGXT1 = Val(Me.txtEQ3UnloadGXT1.Text)
        MyEQ3TimeoutSetting.nEQUnloadGXT5 = Val(Me.txtEQ3UnloadGXT5.Text)
        MyEQ3TimeoutSetting.nEQExchangeGXT1 = Val(Me.txtEQ3ExchangeGXT1.Text)
        MyEQ3TimeoutSetting.nEQExchangeGXT5 = Val(Me.txtEQ3ExchangeGXT5.Text)
        MyEQ3TimeoutSetting.nEQRecipeModifyT2 = Val(Me.txtEQ3RecipeModifyT2.Text)
        MyEQ3TimeoutSetting.nEQRecipeExistCheckT1 = Val(Me.txtEQ3RecipeExistCheckT1.Text)
        MyEQ3TimeoutSetting.nEQRecipeExistCheckT3 = Val(Me.txtEQ3RecipeExistCheckT3.Text)
        MyEQ3TimeoutSetting.nEQGXEraseT2 = Val(Me.txtEQ3GXEraseT2.Text)
        MyEQ3TimeoutSetting.nEQTransferResetT1 = Val(Me.txtEQ3TransferResetT1.Text)
        MyEQ3TimeoutSetting.nEQTransferResetT3 = Val(Me.txtEQ3TransferResetT3.Text)

        MyEQ3TimeoutSetting.nEQRecipeQueryT1 = Val(Me.txtEQ3RecipeQueryT1.Text)
        MyEQ3TimeoutSetting.nEQRecipeQueryT3 = Val(Me.txtEQ3RecipeQueryT3.Text)

        source.Configs(TIMEOUT_SECTION).Set("CV1Linkestablishment", Val(Me.txtCV1LinkT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1RobotT1", Val(Me.txtCV1RobotT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1RobotT5", Val(Me.txtCV1RobotT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1CSTLoadReqT2", Val(Me.txtCV1CSTLoadReqT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1CSTLoadCompT2", Val(Me.txtCV1CSTLoadCompT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1CSTProcessReqT1", Val(Me.txtCV1CSTProcessReqT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1CSTProcessReqT3", Val(Me.txtCV1CSTProcessReqT3.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1GXGlowOutT2", Val(Me.txtCV1GXGlowOutT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1GXFlowInT2", Val(Me.txtCV1GXFlowInT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1GXDataReqT2", Val(Me.txtCV1GXDataReqT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1CSTUnloadReqT2", Val(Me.txtCV1CSTUnloadReqT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1CSTUnloadCompT2", Val(Me.txtCV1CSTUnloadCompT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1PortChangeReqT1", Val(Me.txtCV1PortChangeReqT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1PortChangeReqT3", Val(Me.txtCV1PortChangeReqT3.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1GXSlotUnmatchT2", Val(Me.txtCV1GXSlotUnmatchT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1GXAbnormalT2", Val(Me.txtCV1GXAbnormalT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1TransferResetT1", Val(Me.txtCV1TransferResetT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1TransferResetT3", Val(Me.txtCV1TransferResetT3.Text))

        source.Configs(TIMEOUT_SECTION).Set("CV1PresentT2", Val(Me.txtCV1PresentT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1RemoveT2", Val(Me.txtCV1RemoveT2.Text))

        source.Configs(TIMEOUT_SECTION).Set("CV1UnoadReqT0", Val(Me.txtCV1CSTUnloadReqT0.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1PauseT1", Val(Me.txtPauseT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1PauseT3", Val(Me.txtPauseT3.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1ResumeT1", Val(Me.txtResumeT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1ResumeT3", Val(Me.txtResumeT3.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1DummyCancelT1", Val(Me.txtDummyCancelT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("CV1DummyCancelT3", Val(Me.txtDummyCancelT3.Text))

        'source.Configs(TIMEOUT_SECTION).Set("CV2Linkestablishment", Val(Me.txtCV2LinkT1.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2RobotT1", Val(Me.txtCV2RobotT1.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2RobotT5", Val(Me.txtCV2RobotT5.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2CSTLoadReqT2", Val(Me.txtCV2CSTLoadReqT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2CSTLoadCompT2", Val(Me.txtCV2CSTLoadCompT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2CSTProcessReqT1", Val(Me.txtCV2CSTProcessReqT1.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2CSTProcessReqT3", Val(Me.txtCV2CSTProcessReqT3.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2GXGlowOutT2", Val(Me.txtCV2GXGlowOutT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2GXFlowInT2", Val(Me.txtCV2GXFlowInT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2GXDataReqT2", Val(Me.txtCV2GXDataReqT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2CSTUnloadReqT2", Val(Me.txtCV2CSTUnloadReqT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2CSTUnloadCompT2", Val(Me.txtCV2CSTUnloadCompT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2PortChangeReqT1", Val(Me.txtCV2PortChangeReqT1.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2PortChangeReqT3", Val(Me.txtCV2PortChangeReqT3.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2GXSlotUnmatchT2", Val(Me.txtCV2GXSlotUnmatchT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2GXAbnormalT2", Val(Me.txtCV2GXAbnormalT2.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2TransferResetT1", Val(Me.txtCV2TransferResetT1.Text))
        'source.Configs(TIMEOUT_SECTION).Set("CV2TransferResetT3", Val(Me.txtCV2TransferResetT3.Text))

        source.Configs(TIMEOUT_SECTION).Set("EQ1LinkEstablishmentT1", Val(Me.txtEQ1LinkEstablishmentT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1LoadGXT1", Val(Me.txtEQ1LoadGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1LoadGXT5", Val(Me.txtEQ1LoadGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1UnloadGXT1", Val(Me.txtEQ1UnloadGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1UnloadGXT5", Val(Me.txtEQ1UnloadGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1ExchangeGXT1", Val(Me.txtEQ1ExchangeGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1ExchangeGXT5", Val(Me.txtEQ1ExchangeGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1RecipeModifyT2", Val(Me.txtEQ1RecipeModifyT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1RecipeExistCheckT1", Val(Me.txtEQ1RecipeExistCheckT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1RecipeExistCheckT3", Val(Me.txtEQ1RecipeExistCheckT3.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1GXEraseT2", Val(Me.txtEQ1GXEraseT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1TransferResetT1", Val(Me.txtEQ1TransferResetT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1TransferResetT3", Val(Me.txtEQ1TransferResetT3.Text))

        source.Configs(TIMEOUT_SECTION).Set("EQ1RecipeQueryT1", Val(Me.txtEQ1RecipeQueryT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ1RecipeQueryT3", Val(Me.txtEQ1RecipeQueryT3.Text))

        source.Configs(TIMEOUT_SECTION).Set("EQ2LinkEstablishmentT1", Val(Me.txtEQ2LinkEstablishmentT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2LoadGXT1", Val(Me.txtEQ2LoadGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2LoadGXT5", Val(Me.txtEQ2LoadGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2UnloadGXT1", Val(Me.txtEQ2UnloadGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2UnloadGXT5", Val(Me.txtEQ2UnloadGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2ExchangeGXT1", Val(Me.txtEQ2ExchangeGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2ExchangeGXT5", Val(Me.txtEQ2ExchangeGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2RecipeModifyT2", Val(Me.txtEQ2RecipeModifyT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2RecipeExistCheckT1", Val(Me.txtEQ2RecipeExistCheckT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2RecipeExistCheckT3", Val(Me.txtEQ2RecipeExistCheckT3.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2GXEraseT2", Val(Me.txtEQ2GXEraseT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2TransferResetT1", Val(Me.txtEQ2TransferResetT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2TransferResetT3", Val(Me.txtEQ2TransferResetT3.Text))

        source.Configs(TIMEOUT_SECTION).Set("EQ2RecipeQueryT1", Val(Me.txtEQ2RecipeQueryT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ2RecipeQueryT3", Val(Me.txtEQ2RecipeQueryT3.Text))

        source.Configs(TIMEOUT_SECTION).Set("EQ3LinkEstablishmentT1", Val(Me.txtEQ3LinkEstablishmentT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3LoadGXT1", Val(Me.txtEQ3LoadGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3LoadGXT5", Val(Me.txtEQ3LoadGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3UnloadGXT1", Val(Me.txtEQ3UnloadGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3UnloadGXT5", Val(Me.txtEQ3UnloadGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3ExchangeGXT1", Val(Me.txtEQ3ExchangeGXT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3ExchangeGXT5", Val(Me.txtEQ3ExchangeGXT5.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3RecipeModifyT2", Val(Me.txtEQ3RecipeModifyT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3RecipeExistCheckT1", Val(Me.txtEQ3RecipeExistCheckT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3RecipeExistCheckT3", Val(Me.txtEQ3RecipeExistCheckT3.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3GXEraseT2", Val(Me.txtEQ3GXEraseT2.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3TransferResetT1", Val(Me.txtEQ3TransferResetT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3TransferResetT3", Val(Me.txtEQ3TransferResetT3.Text))

        source.Configs(TIMEOUT_SECTION).Set("EQ3RecipeQueryT1", Val(Me.txtEQ3RecipeQueryT1.Text))
        source.Configs(TIMEOUT_SECTION).Set("EQ3RecipeQueryT3", Val(Me.txtEQ3RecipeQueryT3.Text))

        source.Save()

        WriteTimeOutParameter()
    End Sub

    Private Sub frmTimeOutSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCV1LinkT1.Text = MyCV1TimeoutSetting.nLinkEstablishmentT1
        Me.txtCV1RobotT1.Text = MyCV1TimeoutSetting.nRobotT1
        Me.txtCV1RobotT5.Text = MyCV1TimeoutSetting.nRobotT5
        Me.txtCV1CSTLoadReqT2.Text = MyCV1TimeoutSetting.nCSTLoadReqT2
        Me.txtCV1CSTLoadCompT2.Text = MyCV1TimeoutSetting.nCSTLoadCompT2
        Me.txtCV1CSTProcessReqT1.Text = MyCV1TimeoutSetting.nCSTProcessReqT1
        Me.txtCV1CSTProcessReqT3.Text = MyCV1TimeoutSetting.nCSTProcessReqT3
        Me.txtCV1GXGlowOutT2.Text = MyCV1TimeoutSetting.nGXGlowOutT2
        Me.txtCV1GXFlowInT2.Text = MyCV1TimeoutSetting.nGXFlowInT2
        Me.txtCV1GXDataReqT2.Text = MyCV1TimeoutSetting.nGXDataReqT2
        Me.txtCV1CSTUnloadReqT2.Text = MyCV1TimeoutSetting.nCSTUnloadReqT2
        Me.txtCV1CSTUnloadCompT2.Text = MyCV1TimeoutSetting.nCSTUnloadCompT2
        Me.txtCV1PortChangeReqT1.Text = MyCV1TimeoutSetting.nPortChangeReqT1
        Me.txtCV1PortChangeReqT3.Text = MyCV1TimeoutSetting.nPortChangeReqT3
        Me.txtCV1GXSlotUnmatchT2.Text = MyCV1TimeoutSetting.nGXSlotUnmatchT2
        Me.txtCV1GXAbnormalT2.Text = MyCV1TimeoutSetting.nGXAbnormalT2
        Me.txtCV1TransferResetT1.Text = MyCV1TimeoutSetting.nTransferResetT1
        Me.txtCV1TransferResetT3.Text = MyCV1TimeoutSetting.nTransferResetT3

        Me.txtCV1PresentT2.Text = MyCV1TimeoutSetting.nPresentT2
        Me.txtCV1RemoveT2.Text = MyCV1TimeoutSetting.nRemoveT2

        Me.txtCV1CSTUnloadReqT0.Text = MyCV1TimeoutSetting.nCSTUnloadReqT0
        Me.txtPauseT1.Text = MyCV1TimeoutSetting.nPauseT1
        Me.txtPauseT3.Text = MyCV1TimeoutSetting.nPauseT3
        Me.txtResumeT1.Text = MyCV1TimeoutSetting.nResumeT1
        Me.txtResumeT3.Text = MyCV1TimeoutSetting.nResumeT3
        Me.txtDummyCancelT1.Text = MyCV1TimeoutSetting.nDummyCancelT1
        Me.txtDummyCancelT3.Text = MyCV1TimeoutSetting.nDummyCancelT3

        'Me.txtCV2LinkT1.Text = MyCV2TimeoutSetting.nLinkEstablishmentT1
        'Me.txtCV2RobotT1.Text = MyCV2TimeoutSetting.nRobotT1
        'Me.txtCV2RobotT5.Text = MyCV2TimeoutSetting.nRobotT5
        'Me.txtCV2CSTLoadReqT2.Text = MyCV2TimeoutSetting.nCSTLoadReqT2
        'Me.txtCV2CSTLoadCompT2.Text = MyCV2TimeoutSetting.nCSTLoadCompT2
        'Me.txtCV2CSTProcessReqT1.Text = MyCV2TimeoutSetting.nCSTProcessReqT1
        'Me.txtCV2CSTProcessReqT3.Text = MyCV2TimeoutSetting.nCSTProcessReqT3
        'Me.txtCV2GXGlowOutT2.Text = MyCV2TimeoutSetting.nGXGlowOutT2
        'Me.txtCV2GXFlowInT2.Text = MyCV2TimeoutSetting.nGXFlowInT2
        'Me.txtCV2GXDataReqT2.Text = MyCV2TimeoutSetting.nGXDataReqT2
        'Me.txtCV2CSTUnloadReqT2.Text = MyCV2TimeoutSetting.nCSTUnloadReqT2
        'Me.txtCV2CSTUnloadCompT2.Text = MyCV2TimeoutSetting.nCSTUnloadCompT2
        'Me.txtCV2PortChangeReqT1.Text = MyCV2TimeoutSetting.nPortChangeReqT1
        'Me.txtCV2PortChangeReqT3.Text = MyCV2TimeoutSetting.nPortChangeReqT3
        'Me.txtCV2GXSlotUnmatchT2.Text = MyCV2TimeoutSetting.nGXSlotUnmatchT2
        'Me.txtCV2GXAbnormalT2.Text = MyCV2TimeoutSetting.nGXAbnormalT2
        'Me.txtCV2TransferResetT1.Text = MyCV2TimeoutSetting.nTransferResetT1
        'Me.txtCV2TransferResetT3.Text = MyCV2TimeoutSetting.nTransferResetT3

        Me.txtEQ1LinkEstablishmentT1.Text = MyEQ1TimeoutSetting.nEQLinkEstablishmentT1
        Me.txtEQ1LoadGXT1.Text = MyEQ1TimeoutSetting.nEQLoadGXT1
        Me.txtEQ1LoadGXT5.Text = MyEQ1TimeoutSetting.nEQLoadGXT5
        Me.txtEQ1UnloadGXT1.Text = MyEQ1TimeoutSetting.nEQUnloadGXT1
        Me.txtEQ1UnloadGXT5.Text = MyEQ1TimeoutSetting.nEQUnloadGXT5
        Me.txtEQ1ExchangeGXT1.Text = MyEQ1TimeoutSetting.nEQExchangeGXT1
        Me.txtEQ1ExchangeGXT5.Text = MyEQ1TimeoutSetting.nEQExchangeGXT5
        Me.txtEQ1RecipeModifyT2.Text = MyEQ1TimeoutSetting.nEQRecipeModifyT2
        Me.txtEQ1RecipeExistCheckT1.Text = MyEQ1TimeoutSetting.nEQRecipeExistCheckT1
        Me.txtEQ1RecipeExistCheckT3.Text = MyEQ1TimeoutSetting.nEQRecipeExistCheckT3
        Me.txtEQ1GXEraseT2.Text = MyEQ1TimeoutSetting.nEQGXEraseT2
        Me.txtEQ1TransferResetT1.Text = MyEQ1TimeoutSetting.nEQTransferResetT1
        Me.txtEQ1TransferResetT3.Text = MyEQ1TimeoutSetting.nEQTransferResetT3
        Me.txtEQ1RecipeQueryT1.Text = MyEQ1TimeoutSetting.nEQRecipeQueryT1
        Me.txtEQ1RecipeQueryT3.Text = MyEQ1TimeoutSetting.nEQRecipeQueryT3

        Me.txtEQ2LinkEstablishmentT1.Text = MyEQ2TimeoutSetting.nEQLinkEstablishmentT1
        Me.txtEQ2LoadGXT1.Text = MyEQ2TimeoutSetting.nEQLoadGXT1
        Me.txtEQ2LoadGXT5.Text = MyEQ2TimeoutSetting.nEQLoadGXT5
        Me.txtEQ2UnloadGXT1.Text = MyEQ2TimeoutSetting.nEQUnloadGXT1
        Me.txtEQ2UnloadGXT5.Text = MyEQ2TimeoutSetting.nEQUnloadGXT5
        Me.txtEQ2ExchangeGXT1.Text = MyEQ2TimeoutSetting.nEQExchangeGXT1
        Me.txtEQ2ExchangeGXT5.Text = MyEQ2TimeoutSetting.nEQExchangeGXT5
        Me.txtEQ2RecipeModifyT2.Text = MyEQ2TimeoutSetting.nEQRecipeModifyT2
        Me.txtEQ2RecipeExistCheckT1.Text = MyEQ2TimeoutSetting.nEQRecipeExistCheckT1
        Me.txtEQ2RecipeExistCheckT3.Text = MyEQ2TimeoutSetting.nEQRecipeExistCheckT3
        Me.txtEQ2GXEraseT2.Text = MyEQ2TimeoutSetting.nEQGXEraseT2
        Me.txtEQ2TransferResetT1.Text = MyEQ2TimeoutSetting.nEQTransferResetT1
        Me.txtEQ2TransferResetT3.Text = MyEQ2TimeoutSetting.nEQTransferResetT3
        Me.txtEQ2RecipeQueryT1.Text = MyEQ2TimeoutSetting.nEQRecipeQueryT1
        Me.txtEQ2RecipeQueryT3.Text = MyEQ2TimeoutSetting.nEQRecipeQueryT3

        Me.txtEQ3LinkEstablishmentT1.Text = MyEQ3TimeoutSetting.nEQLinkEstablishmentT1
        Me.txtEQ3LoadGXT1.Text = MyEQ3TimeoutSetting.nEQLoadGXT1
        Me.txtEQ3LoadGXT5.Text = MyEQ3TimeoutSetting.nEQLoadGXT5
        Me.txtEQ3UnloadGXT1.Text = MyEQ3TimeoutSetting.nEQUnloadGXT1
        Me.txtEQ3UnloadGXT5.Text = MyEQ3TimeoutSetting.nEQUnloadGXT5
        Me.txtEQ3ExchangeGXT1.Text = MyEQ3TimeoutSetting.nEQExchangeGXT1
        Me.txtEQ3ExchangeGXT5.Text = MyEQ3TimeoutSetting.nEQExchangeGXT5
        Me.txtEQ3RecipeModifyT2.Text = MyEQ3TimeoutSetting.nEQRecipeModifyT2
        Me.txtEQ3RecipeExistCheckT1.Text = MyEQ3TimeoutSetting.nEQRecipeExistCheckT1
        Me.txtEQ3RecipeExistCheckT3.Text = MyEQ3TimeoutSetting.nEQRecipeExistCheckT3
        Me.txtEQ3GXEraseT2.Text = MyEQ3TimeoutSetting.nEQGXEraseT2
        Me.txtEQ3TransferResetT1.Text = MyEQ3TimeoutSetting.nEQTransferResetT1
        Me.txtEQ3TransferResetT3.Text = MyEQ3TimeoutSetting.nEQTransferResetT3
        Me.txtEQ3RecipeQueryT1.Text = MyEQ3TimeoutSetting.nEQRecipeQueryT1
        Me.txtEQ3RecipeQueryT3.Text = MyEQ3TimeoutSetting.nEQRecipeQueryT3

    End Sub
End Class