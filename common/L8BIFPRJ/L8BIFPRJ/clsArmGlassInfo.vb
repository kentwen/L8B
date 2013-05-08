Public Class clsArmGlassInfo

    Private mvarGlassDataRef As Integer
    Private mvarSampleGlassFlag As Integer
    Private mvarProductCategory As Integer
    Private mvarSlotInfo As Integer
    Private mvarGlassID As String
    Private mvarEPPID(MAX_EQ) As String
    Private mvarMESID As String
    Private mvarProductCode As String
    Private mvarCurrentRecipe As String
    Private mvarPOPERID As String
    Private mvarPLINEID As String
    Private mvarPTOOLID As String
    Private mvarCSTID As String
    Private mvarOperationID As String
    Private mvarGxGrade As clsPLC.eGGRADE
    Private mvarDMQCGrade As clsPLC.eDGRADE
    Private mvarGlassScrapFlag As clsPLC.eSCRPFLAG
    Private mvarAOIFUNMode As Integer
    Private mvarRDGRADE As Integer
    Private mvarDGRADE As Integer
    Private mvarGGRADE As Integer
    Private mvarPSHGrade As String
    Private mvarPToolIDIdx As Integer
    Private mvarDMQCToolID As String
    Private mvarChipGrade As String
    Private mvarFIRMFLAG As Integer
    Private mvarSCRPFLAG As Integer
    Private mvarRWKFLAG As Integer
    Private mvarPortNo As Integer
    Private mvarTargetPosition As Integer
    Private mvarRobotSpeed As clsPLC.eRobotSpeed
    Private mvarRepairInkFlag As Integer
    Private mvarProcessFlag As Integer
    Private mvarFIinspectionFlag As Integer

    '2010/06/22
    Public Property FIinspectionFlag() As Integer
        Get
            FIinspectionFlag = mvarFIinspectionFlag
        End Get
        Set(ByVal value As Integer)
            mvarFIinspectionFlag = value
        End Set
    End Property

    '2010/06/22
    Public Property RepairInkFlag() As Integer
        Get
            RepairInkFlag = mvarRepairInkFlag
        End Get
        Set(ByVal value As Integer)
            mvarRepairInkFlag = value
        End Set
    End Property

    '2010/06/22
    Public Property ProcessFlag() As Integer
        Get
            ProcessFlag = mvarProcessFlag
        End Get
        Set(ByVal value As Integer)
            mvarProcessFlag = value
        End Set
    End Property

    'Public Property GlassDataRef() As Integer
    '    Get
    '        GlassDataRef = mvarGlassDataRef
    '    End Get
    '    Set(ByVal value As Integer)
    '        mvarGlassDataRef = value
    '    End Set
    'End Property

    Public Property SampleGlassFlag() As Integer
        Get
            SampleGlassFlag = mvarSampleGlassFlag
        End Get
        Set(ByVal value As Integer)
            mvarSampleGlassFlag = value
        End Set
    End Property

    Public Property ProductCategory() As clsPLC.eProductCategory
        Get
            ProductCategory = mvarProductCategory
        End Get
        Set(ByVal value As clsPLC.eProductCategory)
            mvarProductCategory = value
        End Set
    End Property

    Public Property SlotInfo() As Integer
        Get
            SlotInfo = mvarSlotInfo
        End Get
        Set(ByVal value As Integer)
            mvarSlotInfo = value
        End Set
    End Property

    Public Property GlassID() As String
        Get
            GlassID = mvarGlassID
        End Get
        Set(ByVal value As String)
            mvarGlassID = value
        End Set
    End Property

    Public Property EPPID(ByVal nEQ As Integer) As String
        Get
            EPPID = mvarEPPID(nEQ)
        End Get
        Set(ByVal value As String)
            mvarEPPID(nEQ) = value
        End Set
    End Property

    Public Property MESID() As String
        Get
            MESID = mvarMESID
        End Get
        Set(ByVal value As String)
            mvarMESID = value
        End Set
    End Property

    Public Property ProductCode() As String
        Get
            ProductCode = mvarProductCode
        End Get
        Set(ByVal value As String)
            mvarProductCode = value
        End Set
    End Property

    Public Property CurrentRecipe() As String
        Get
            CurrentRecipe = mvarCurrentRecipe
        End Get
        Set(ByVal value As String)
            mvarCurrentRecipe = value
        End Set
    End Property

    Public Property POPERID() As String
        Get
            POPERID = mvarPOPERID
        End Get
        Set(ByVal value As String)
            mvarPOPERID = value
        End Set
    End Property

    Public Property PLINEID() As String
        Get
            PLINEID = mvarPLINEID
        End Get
        Set(ByVal value As String)
            mvarPLINEID = value
        End Set
    End Property

    Public Property PTOOLID() As String
        Get
            PTOOLID = mvarPTOOLID
        End Get
        Set(ByVal value As String)
            mvarPTOOLID = value
        End Set
    End Property

    Public Property CSTID() As String
        Get
            CSTID = mvarCSTID
        End Get
        Set(ByVal value As String)
            mvarCSTID = value
        End Set
    End Property

    Public Property OperationID() As String
        Get
            OperationID = mvarOperationID
        End Get
        Set(ByVal value As String)
            mvarOperationID = value
        End Set
    End Property

    Public Property GlassGrade() As clsPLC.eGGRADE
        Get
            GlassGrade = mvarGxGrade
        End Get
        Set(ByVal value As clsPLC.eGGRADE)
            mvarGxGrade = value
        End Set
    End Property

    Public Property DMQCGrade() As clsPLC.eDGRADE
        Get
            DMQCGrade = mvarDMQCGrade
        End Get
        Set(ByVal value As clsPLC.eDGRADE)
            mvarDMQCGrade = value
        End Set
    End Property

    Public Property GlassScrapFlag() As clsPLC.eSCRPFLAG
        Get
            GlassScrapFlag = mvarGlassScrapFlag
        End Get
        Set(ByVal value As clsPLC.eSCRPFLAG)
            mvarGlassScrapFlag = value
        End Set
    End Property

    Public Property AOIFunctionMode() As clsPLC.eAOIFunction
        Get
            AOIFunctionMode = mvarAOIFUNMode
        End Get
        Set(ByVal value As clsPLC.eAOIFunction)
            mvarAOIFUNMode = value
        End Set
    End Property

    Public Property PortNo() As Integer
        Get
            PortNo = mvarPortNo
        End Get
        Set(ByVal value As Integer)
            mvarPortNo = value
        End Set
    End Property

    Public Property TargetPosition() As clsPLC.eGlassTargetPosition
        Get
            TargetPosition = mvarTargetPosition
        End Get
        Set(ByVal value As clsPLC.eGlassTargetPosition)
            mvarTargetPosition = value
        End Set
    End Property

    Public Property RobotSpeed() As clsPLC.eRobotSpeed
        Get
            RobotSpeed = mvarRobotSpeed
        End Get
        Set(ByVal value As clsPLC.eRobotSpeed)
            mvarRobotSpeed = value
        End Set
    End Property

    'Public Property RDGRADE() As clsPLC.eRDGRADE
    '    Get
    '        RDGRADE = mvarRDGRADE
    '    End Get
    '    Set(ByVal value As clsPLC.eRDGRADE)
    '        mvarRDGRADE = value
    '    End Set
    'End Property

    'Public Property DGRADE() As clsPLC.eDGRADE
    '    Get
    '        DGRADE = mvarDGRADE
    '    End Get
    '    Set(ByVal value As clsPLC.eDGRADE)
    '        mvarDGRADE = value
    '    End Set
    'End Property

    'Public Property GGRADE() As clsPLC.eGGRADE
    '    Get
    '        GGRADE = mvarGGRADE
    '    End Get
    '    Set(ByVal value As clsPLC.eGGRADE)
    '        mvarGGRADE = value
    '    End Set
    'End Property

    'Public Property PSHGrade() As String
    '    Get
    '        PSHGrade = mvarPSHGrade
    '    End Get
    '    Set(ByVal value As String)
    '        mvarPSHGrade = value
    '    End Set
    'End Property

    'Public Property PToolIDIndex() As Integer
    '    Get
    '        PToolIDIndex = mvarPToolIDIdx
    '    End Get
    '    Set(ByVal value As Integer)
    '        mvarPToolIDIdx = value
    '    End Set
    'End Property

    'Public Property DMQCToolID() As String
    '    Get
    '        DMQCToolID = mvarDMQCToolID
    '    End Get
    '    Set(ByVal value As String)
    '        mvarDMQCToolID = value
    '    End Set
    'End Property

    'Public Property ChipGrade() As String
    '    Get
    '        ChipGrade = mvarChipGrade
    '    End Get
    '    Set(ByVal value As String)
    '        mvarChipGrade = value
    '    End Set
    'End Property

    Public Property FIRMFLAG() As clsPLC.eFIRMFLAG
        Get
            FIRMFLAG = mvarFIRMFLAG
        End Get
        Set(ByVal value As clsPLC.eFIRMFLAG)
            mvarFIRMFLAG = value
        End Set
    End Property

    Public Property SCRPFLAG() As clsPLC.eSCRPFLAG
        Get
            SCRPFLAG = mvarSCRPFLAG
        End Get
        Set(ByVal value As clsPLC.eSCRPFLAG)
            mvarSCRPFLAG = value
        End Set
    End Property

    Public Property RWKFLAG() As clsPLC.eRWKFLAG
        Get
            RWKFLAG = mvarRWKFLAG
        End Get
        Set(ByVal value As clsPLC.eRWKFLAG)
            mvarRWKFLAG = value
        End Set
    End Property
End Class
