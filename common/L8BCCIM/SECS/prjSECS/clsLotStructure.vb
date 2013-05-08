Public Class clsLotStructure
    Private mvarSlotStructrue(0 To MAX_SLOTS) As clsSlotStructure
    Private mvarDuringSlotsSelection As Boolean
    Private mvarISLotDataReceived As Boolean
    Private mvarLotCancel As Boolean
    Private mvarProcessEndCode As clsEnumCtl.eProcessENDCode
    Private mvarRecipeNeedConfirm As Boolean
    Private mvarPPIDChanged As Boolean
    Private mvarRecipeCode As Boolean
    Private mvarRecipeName As String
    Private mvarOperatorID As String
    Private mvarOperationID As String
    Private mvarMeasurementID As String
    Private mvarProductCategory As clsEnumCtl.eProductCategory
    Private mvarProductCode As String
    Private mvarPortPosition As Integer
    Private mvarCassetteStatus As clsEnumCtl.eCassetteStatus
    Private mvarCassetteID As String
    Private mvarUnderSlotsSelection As Boolean

    Private mvarReturnCode As String
    Private mvarCIMMessage As String
    Private mvarDateTime As String

    Public Property DateTime() As String
        Get
            Return mvarDateTime
        End Get
        Set(ByVal value As String)
            mvarDateTime = value
        End Set
    End Property


    Public Property ReturnCode() As String
        Get
            Return mvarReturnCode
        End Get
        Set(ByVal value As String)
            mvarReturnCode = value
        End Set
    End Property


    Public Property CIMMessage() As String
        Get
            Return mvarCIMMessage
        End Get
        Set(ByVal value As String)
            mvarCIMMessage = value
        End Set
    End Property

    Public ReadOnly Property Slots(ByVal nIndex As Integer) As clsSlotStructure
        Get
            Slots = mvarSlotStructrue(nIndex)
        End Get
    End Property

    Public Property DuringSlotsSelection() As Boolean
        Get
            DuringSlotsSelection = mvarDuringSlotsSelection
        End Get
        Set(ByVal value As Boolean)
            mvarDuringSlotsSelection = value
        End Set
    End Property

    Public Property IsLotDataReceived() As Boolean
        Get
            ISLotDataReceived = mvarISLotDataReceived
        End Get
        Set(ByVal value As Boolean)
            mvarISLotDataReceived = value
        End Set
    End Property

    Public Property LotCancel() As Boolean
        Get
            LotCancel = mvarLotCancel
        End Get
        Set(ByVal value As Boolean)
            mvarLotCancel = value
        End Set
    End Property

    Public Property ProcessEndCode() As clsEnumCtl.eProcessENDCode
        Get
            ProcessEndCode = mvarProcessEndCode
        End Get
        Set(ByVal value As clsEnumCtl.eProcessENDCode)
            mvarProcessEndCode = value
        End Set
    End Property

    Public Property RecipeNeedConfirm() As Boolean
        Get
            RecipeNeedConfirm = mvarRecipeNeedConfirm
        End Get
        Set(ByVal value As Boolean)
            mvarRecipeNeedConfirm = value
        End Set
    End Property

    Public Property PPIDChanged() As Boolean
        Get
            PPIDChanged = mvarPPIDChanged
        End Get
        Set(ByVal value As Boolean)
            mvarPPIDChanged = value
        End Set
    End Property

    Public Property RecipeCode() As Boolean
        Get
            RecipeCode = mvarRecipeCode
        End Get
        Set(ByVal value As Boolean)
            mvarRecipeCode = value
        End Set
    End Property

    Public Property RecipeName() As String
        Get
            RecipeName = SpaceCTL(mvarRecipeName, LEN_PPID)
        End Get
        Set(ByVal value As String)

            If mvarRecipeName <> value Then
                Writelog("LotStructure port=" & mvarPortPosition & " RecipeName Change -> " & value, clsEnumCtl.eZLogType.TYPE_PROPERTY)
            End If
            mvarRecipeName = value
        End Set
    End Property

    Public Property OperatorID() As String
        Get
            OperatorID = SpaceCTL(mvarOperatorID, LEN_OPID)
        End Get
        Set(ByVal value As String)
            mvarOperatorID = value
        End Set
    End Property

    Public Property OperationID() As String
        Get
            OperationID = SpaceCTL(mvarOperationID, LEN_OPERATIONID)
        End Get
        Set(ByVal value As String)
            mvarOperationID = value
        End Set
    End Property

    Public Property MeasurementID() As String
        Get
            MeasurementID = SpaceCTL(mvarMeasurementID, LEN_MESID)
        End Get
        Set(ByVal value As String)
            mvarMeasurementID = value
        End Set
    End Property

    Public Property ProductCategory() As clsEnumCtl.eProductCategory
        Get
            ProductCategory = mvarProductCategory
        End Get
        Set(ByVal value As clsEnumCtl.eProductCategory)
            mvarProductCategory = value
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

    Public Property PortPosition() As Integer
        Get
            PortPosition = mvarPortPosition
        End Get
        Set(ByVal value As Integer)
            mvarPortPosition = value
        End Set
    End Property

    Public Property CassetteStatus() As clsEnumCtl.eCassetteStatus
        Get
            CassetteStatus = mvarCassetteStatus
        End Get
        Set(ByVal value As clsEnumCtl.eCassetteStatus)
            mvarCassetteStatus = value
        End Set
    End Property

    Public Property CassetteStatusByString() As String
        Get
            Select Case mvarCassetteStatus
                Case clsEnumCtl.eCassetteStatus.CSTA_WAIT
                    CassetteStatusByString = "W"
                Case clsEnumCtl.eCassetteStatus.CSTA_INPROCESS
                    CassetteStatusByString = "I"
                Case clsEnumCtl.eCassetteStatus.CSTA_END
                    CassetteStatusByString = "T"
                Case clsEnumCtl.eCassetteStatus.CSTA_SUSPEND
                    CassetteStatusByString = "S"
                Case Else
                    CassetteStatusByString = Space(1)
            End Select
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "W"
                    mvarCassetteStatus = clsEnumCtl.eCassetteStatus.CSTA_WAIT
                Case "I"
                    mvarCassetteStatus = clsEnumCtl.eCassetteStatus.CSTA_INPROCESS
                Case "T"
                    mvarCassetteStatus = clsEnumCtl.eCassetteStatus.CSTA_END
                Case "S"
                    mvarCassetteStatus = clsEnumCtl.eCassetteStatus.CSTA_SUSPEND
            End Select
        End Set
    End Property

    Public Property CassetteID() As String
        Get
            CassetteID = SpaceCTL(mvarCassetteID, LEN_CSTID)
        End Get
        Set(ByVal value As String)
            mvarCassetteID = value
        End Set
    End Property

    Public Property ProcEndCodeByString() As String
        Get
            Select Case mvarProcessEndCode
                Case clsEnumCtl.eProcessENDCode.LONF_UNLOADER
                    ProcEndCodeByString = "LONF"
                Case clsEnumCtl.eProcessENDCode.LONC_REMAINWORKS
                    ProcEndCodeByString = "LONC"
                Case clsEnumCtl.eProcessENDCode.EMPT_EMPTY
                    ProcEndCodeByString = "EMPT"
                Case clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                    ProcEndCodeByString = "LONQ"
                Case Else
                    ProcEndCodeByString = Space(4)
            End Select
        End Get

        Set(ByVal value As String)
            Select Case value
                Case "LONF"
                    mvarProcessEndCode = clsEnumCtl.eProcessENDCode.LONF_UNLOADER
                Case "LONC"
                    mvarProcessEndCode = clsEnumCtl.eProcessENDCode.LONC_REMAINWORKS
                Case "EMPT"
                    mvarProcessEndCode = clsEnumCtl.eProcessENDCode.EMPT_EMPTY
                Case "LONQ"
                    mvarProcessEndCode = clsEnumCtl.eProcessENDCode.LONQ_CANCEL
                Case Else
                    mvarProcessEndCode = clsEnumCtl.eProcessENDCode.NONE
            End Select
        End Set
    End Property

    Public Property ProductCategoryByString() As String
        Get
            Select Case mvarProductCategory
                Case clsEnumCtl.eProductCategory.PRODCAT_PRODUCT
                    ProductCategoryByString = "PROD"
                Case clsEnumCtl.eProductCategory.PRODCAT_INITIAL
                    ProductCategoryByString = "INIT"
                Case clsEnumCtl.eProductCategory.PRODCAT_MONITOR
                    ProductCategoryByString = "MONI"
                Case clsEnumCtl.eProductCategory.PRODCAT_DUMMY
                    ProductCategoryByString = "DUMY"
                Case Else
                    ProductCategoryByString = Space(4)
            End Select
        End Get

        Set(ByVal value As String)
            Select Case value
                Case "PROD"
                    mvarProductCategory = clsEnumCtl.eProductCategory.PRODCAT_PRODUCT
                Case "INIT"
                    mvarProductCategory = clsEnumCtl.eProductCategory.PRODCAT_INITIAL
                Case "MONI"
                    mvarProductCategory = clsEnumCtl.eProductCategory.PRODCAT_MONITOR
                Case "DUMY"
                    mvarProductCategory = clsEnumCtl.eProductCategory.PRODCAT_DUMMY
                Case Else
                    mvarProductCategory = clsEnumCtl.eProductCategory.PRODCAT_NONE
            End Select
        End Set
    End Property

    Private Function PortTypeByString(ByVal nPortCategory As clsEnumCtl.ePortCategory) As String
        Select Case nPortCategory
            Case clsEnumCtl.ePortCategory.CATEGORY_OK
                PortTypeByString = "O"
            Case clsEnumCtl.ePortCategory.CATEGORY_NG
                PortTypeByString = "N"
            Case clsEnumCtl.ePortCategory.CATEGORY_MIXED
                PortTypeByString = "M"
            Case Else
                PortTypeByString = " "
        End Select
    End Function

    Public Property UnderSlotsSelection() As Boolean
        Get
            UnderSlotsSelection = mvarUnderSlotsSelection
        End Get
        Set(ByVal value As Boolean)
            mvarUnderSlotsSelection = value
        End Set
    End Property

    Public Sub New()
        Dim nFor As Integer

        For nFor = 1 To MAX_SLOTS
            mvarSlotStructrue(nFor) = New clsSlotStructure
        Next
    End Sub
End Class
