Public Class clsS167LotInfo

    Private mvarS167SlotStructrue(0 To MAX_SLOTS) As clsS167SlotInfo

    Private mvarLineID As String
    Private mvarToolID As String
    Private mvarProductCategory As Integer
    Private mvarCassetteStatus As Integer
    Private mvarOperationID As String
    Private mvarPortMode As Integer
    Private mvarPortType As Integer
    Private mvarTotalQtyInCassette As Integer
    Private mvarCassetteUnloadStatus As Integer
    Private mvarCassetteID As String
    Private mvarProductCode As String


    Public Property ProductCode() As String
        Get
            ProductCode = mvarProductCode
        End Get
        Set(ByVal value As String)
            mvarProductCode = value
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

    Public Property CassetteID() As String
        Get
            CassetteID = mvarCassetteID
        End Get
        Set(ByVal value As String)
            mvarCassetteID = value
        End Set
    End Property

    '1:WaitProcess,2:Processing,3:End,4:Suspending
    Public Property CassetteStatus() As clsPLC.eCassetteStatus
        Get
            CassetteStatus = mvarCassetteStatus
        End Get
        Set(ByVal value As clsPLC.eCassetteStatus)
            mvarCassetteStatus = value
        End Set
    End Property

    '1:Loader 2:Unloader
    Public Property PortMode() As clsPLC.ePortMode
        Get
            PortMode = mvarPortMode
        End Get
        Set(ByVal value As clsPLC.ePortMode)
            mvarPortMode = value
        End Set
    End Property

    '0:NotUnloader,1:Auto,2:OK,3:NG,4:Gray,5:MIX,6:MIXNG
    Public Property PortType() As clsPLC.eUnloadType
        Get
            PortType = mvarPortType
        End Get
        Set(ByVal value As clsPLC.eUnloadType)
            mvarPortType = value
        End Set
    End Property

    '1:Normal,2:Abnormal
    Public Property CassetteUnloadStatus() As clsPLC.eUnloadStatus
        Get
            CassetteUnloadStatus = mvarCassetteUnloadStatus
        End Get
        Set(ByVal value As clsPLC.eUnloadStatus)
            mvarCassetteUnloadStatus = value
        End Set
    End Property

    Public Property TotalQtyInCassette() As Integer
        Get
            TotalQtyInCassette = mvarTotalQtyInCassette
        End Get
        Set(ByVal value As Integer)
            mvarTotalQtyInCassette = value
        End Set
    End Property

    Public ReadOnly Property Slots(ByVal nIndex As Integer) As clsS167SlotInfo
        Get
            Slots = mvarS167SlotStructrue(nIndex)
        End Get
    End Property

    Public Sub New()
        Dim nFor As Integer

        For nFor = 1 To MAX_SLOTS
            mvarS167SlotStructrue(nFor) = New clsS167SlotInfo
        Next
    End Sub
End Class
