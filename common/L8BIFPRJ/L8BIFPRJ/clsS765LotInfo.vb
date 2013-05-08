Public Class clsS765LotInfo
    Private mvarSlotStructrue(0 To MAX_SLOTS) As clsS765SlotInfo
    Private mvarLineID As String
    Private mvarToolID As String
    Private mvarCassetteID As String
    Private mvarProductCode As String
    Private mvarProductCategory As clsPLC.eProductCategory
    Private mvarMeasurementID As String
    Private mvarOperationID As String
    Private mvarEPPIDEQ1 As String
    Private mvarEPPIDEQ2 As String
    Private mvarTargetPosition As Integer
    Private mvarAOIFunction As Integer
    Private mvarRunningMode As Integer
    Private mvarRobotSpeed As Integer
    Private mvarGlassType As Integer
    Private mvarVCRPosition As Integer
    Private mvarCurrentRecipe As String

    Public Property LineID() As String
        Get
            LineID = mvarLineID
        End Get
        Set(ByVal value As String)
            mvarLineID = value
        End Set
    End Property

    Public Property ToolID() As String
        Get
            ToolID = mvarToolID
        End Get
        Set(ByVal value As String)
            mvarToolID = value
        End Set
    End Property

    Public Property CassetteID() As String
        Get
            CassetteID = mvarCassetteID
        End Get
        Set(ByVal value As String)
            mvarCassetteID = value
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

    Public Property ProductCategory() As clsPLC.eProductCategory
        Get
            ProductCategory = mvarProductCategory
        End Get
        Set(ByVal value As clsPLC.eProductCategory)
            mvarProductCategory = value
        End Set
    End Property

    Public Property MeasurementID() As String
        Get
            MeasurementID = mvarMeasurementID
        End Get
        Set(ByVal value As String)
            mvarMeasurementID = value
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

    Public Property EPPIDEQ1() As String
        Get
            EPPIDEQ1 = mvarEPPIDEQ1
        End Get
        Set(ByVal value As String)
            mvarEPPIDEQ1 = value
        End Set
    End Property

    Public Property EPPIDEQ2() As String
        Get
            EPPIDEQ2 = mvarEPPIDEQ2
        End Get
        Set(ByVal value As String)
            mvarEPPIDEQ2 = value
        End Set
    End Property

    Public Property TargetPosition() As clsPLC.eTargetPosition
        Get
            TargetPosition = mvarTargetPosition
        End Get
        Set(ByVal value As clsPLC.eTargetPosition)
            mvarTargetPosition = value
        End Set
    End Property

    '1:AOI,2:CD,3:Review
    Public Property AOIFunction() As clsPLC.eAOIFunction
        Get
            AOIFunction = mvarAOIFunction
        End Get
        Set(ByVal value As clsPLC.eAOIFunction)
            mvarAOIFunction = value
        End Set
    End Property

    Public Property RunningMode() As clsPLC.eRunningMode
        Get
            RunningMode = mvarRunningMode
        End Get
        Set(ByVal value As clsPLC.eRunningMode)
            mvarRunningMode = value
        End Set
    End Property

    'Speed 1 : Low 2:Mid  3:Hi
    Public Property RobotSpeed() As clsPLC.eRobotSpeed
        Get
            RobotSpeed = mvarRobotSpeed
        End Get
        Set(ByVal value As clsPLC.eRobotSpeed)
            mvarRobotSpeed = value
        End Set
    End Property

    Public Property GlassType() As clsPLC.eGlassType
        Get
            GlassType = mvarGlassType
        End Get
        Set(ByVal value As clsPLC.eGlassType)
            mvarGlassType = value
        End Set
    End Property

    'VCR Position
    Public Property VCRPosition() As Integer
        Get
            VCRPosition = mvarVCRPosition
        End Get
        Set(ByVal value As Integer)
            mvarVCRPosition = value
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


    'Public ReadOnly Property Slots(ByVal nIndex As Integer) As clsS765SlotInfo
    '    Get
    '        Slots = mvarSlotStructrue(nIndex)
    '    End Get
    'End Property

    Public Property Slots(ByVal nIndex As Integer) As clsS765SlotInfo
        Get
            Return mvarSlotStructrue(nIndex)
        End Get
        Set(ByVal value As clsS765SlotInfo)
            mvarSlotStructrue(nIndex) = value
        End Set
    End Property

    Public Sub New()
        Dim nFor As Integer

        For nFor = 1 To MAX_SLOTS
            mvarSlotStructrue(nFor) = New clsS765SlotInfo
        Next
    End Sub
End Class
