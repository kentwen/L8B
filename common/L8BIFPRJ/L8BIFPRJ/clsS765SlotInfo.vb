Public Class clsS765SlotInfo

    Private mvarSlotNo As Integer
    Private mvarGlassID As String
    Private mvarPOPERID As String
    Private mvarPLINEID As String
    Private mvarPTOOLID As String
    Private mvarDMQCToolID As String
    Private mvarGlassGrade As String
    Private mvarDMQCGrade As String
    Private mvarPSHGroup As String
    Private mvarReworkFlag As String
    Private mvarScrapFlag As String
    Private mvarFIRemarkFlag As String
    Private mvarFIFCFlag As Integer
    Private mvarProcessedFlag As Integer

    'Public Property SlotNo() As Integer
    '    Get
    '        SlotNo = mvarSlotNo
    '    End Get
    '    Set(ByVal value As Integer)
    '        mvarSlotNo = value
    '    End Set
    'End Property

    Public Property GlassID() As String
        Get
            GlassID = mvarGlassID
        End Get
        Set(ByVal value As String)
            mvarGlassID = value
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

    Public Property DMQCToolID() As String
        Get
            DMQCToolID = mvarDMQCToolID
        End Get
        Set(ByVal value As String)
            mvarDMQCToolID = value
        End Set
    End Property

    'value =>"O","G","N"
    Public Property GlassGrade() As String
        Get
            GlassGrade = mvarGlassGrade
        End Get
        Set(ByVal value As String)
            mvarGlassGrade = value
        End Set
    End Property

    'value =>"O","R","N"
    Public Property DMQCGrade() As String
        Get
            DMQCGrade = mvarDMQCGrade
        End Get
        Set(ByVal value As String)
            mvarDMQCGrade = value
        End Set
    End Property

    'value =>"AA","AB","XX" ...
    Public Property PSHGroup() As String
        Get
            PSHGroup = mvarPSHGroup
        End Get
        Set(ByVal value As String)
            mvarPSHGroup = value
        End Set
    End Property

    'value =>"R"," "
    Public Property ReworkFlag() As String
        Get
            ReworkFlag = mvarReworkFlag
        End Get
        Set(ByVal value As String)
            mvarReworkFlag = value
        End Set
    End Property

    'value =>"S","C"
    Public Property ScrapFlag() As String
        Get
            ScrapFlag = mvarScrapFlag
        End Get
        Set(ByVal value As String)
            mvarScrapFlag = value
        End Set
    End Property

    'value =>"M"," "
    Public Property FIRemarkFlag() As String
        Get
            FIRemarkFlag = mvarFIRemarkFlag
        End Get
        Set(ByVal value As String)
            mvarFIRemarkFlag = value
        End Set
    End Property

    'value =>1:FI Force,0:By pass
    Public Property FIFCFlag() As clsPLC.eFIFCFlag
        Get
            FIFCFlag = mvarFIFCFlag
        End Get
        Set(ByVal value As clsPLC.eFIFCFlag)
            mvarFIFCFlag = value
        End Set
    End Property

    '1->NeedProcess,0->No need
    Public Property ProcessedFlag() As clsPLC.eProcessedFlag
        Get
            ProcessedFlag = mvarProcessedFlag
        End Get
        Set(ByVal value As clsPLC.eProcessedFlag)
            mvarProcessedFlag = value
        End Set
    End Property

End Class
