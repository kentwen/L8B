Public Class clsS167SlotInfo

    Public SlotNo As Integer
    Private mvarGlassID As String
    Private mvarRDRAGE As Integer
    Private mvarDGRADE As Integer
    Private mvarGGRADE As Integer
    Private mvarPSHGroup As String
    Private mvarPTOOLID As String
    Private mvarDMQCToolID As String
    Private mvarChipGrade As String
    Private mvarFIRMFLAG As Integer
    Private mvarSCRPFLAG As Integer
    Private mvarRWKFLAG As Integer

    Private mvarProductCategory As Integer
    Private mvarLotRecipeID As String
    Private mvarEQ1PPID As String
    Private mvarEQ2PPID As String
    Private mvarEQStartTime(MAX_EQ) As String
    Private mvarEQEndTime(MAX_EQ) As String

    Private mvarProductCode As String
    Private mvarLastProcessLineID As String

    Public Function Clone() As clsS167SlotInfo
        Dim SlotInfo As New clsS167SlotInfo

        With SlotInfo
            .SlotNo = SlotNo
            .GlassID = MyStringTrim(mvarGlassID)
            .RDRAGE = mvarRDRAGE
            .DGRADE = mvarDGRADE
            .GGRADE = mvarGGRADE
            .PSHGroup = mvarPSHGroup
            .PTOOLID = mvarPTOOLID
            .DMQCToolID = mvarDMQCToolID
            .ChipGrade = mvarChipGrade
            .FIRMFLAG = mvarFIRMFLAG
            .SCRPFLAG = mvarSCRPFLAG
            .RWKFLAG = mvarRWKFLAG
            .ProductCode = mvarProductCode
            .LastProcessLineID = mvarLastProcessLineID

            .ProductCategory = mvarProductCategory
            .LotRecipeID = MyStringTrim(mvarLotRecipeID)
            .EQ1PPID = mvarEQ1PPID
            .EQ2PPID = mvarEQ2PPID
            .EQEndTime(1) = mvarEQEndTime(1)
            .EQEndTime(2) = mvarEQEndTime(2)
            .EQEndTime(3) = mvarEQEndTime(3)
            .EQStartTime(1) = mvarEQStartTime(1)
            .EQStartTime(2) = mvarEQStartTime(2)
            .EQStartTime(3) = mvarEQStartTime(3)
        End With

        Return SlotInfo
    End Function

    Public Sub CopyTo(ByRef vSlot As clsS167SlotInfo)
        If vSlot Is Nothing Then
            vSlot = New clsS167SlotInfo
        End If

        With vSlot
            .SlotNo = SlotNo
            .GlassID = MyStringTrim(mvarGlassID)
            .RDRAGE = mvarRDRAGE
            .DGRADE = mvarDGRADE
            .GGRADE = mvarGGRADE
            .PSHGroup = mvarPSHGroup
            .PTOOLID = mvarPTOOLID
            .DMQCToolID = mvarDMQCToolID
            .ChipGrade = mvarChipGrade
            .FIRMFLAG = mvarFIRMFLAG
            .SCRPFLAG = mvarSCRPFLAG
            .RWKFLAG = mvarRWKFLAG
            .ProductCode = mvarProductCode
            .LastProcessLineID = mvarLastProcessLineID

            .ProductCategory = mvarProductCategory
            .LotRecipeID = MyStringTrim(mvarLotRecipeID)
            .EQ1PPID = mvarEQ1PPID
            .EQ2PPID = mvarEQ2PPID
            .EQEndTime(1) = mvarEQEndTime(1)
            .EQEndTime(2) = mvarEQEndTime(2)
            .EQEndTime(3) = mvarEQEndTime(3)
            .EQStartTime(1) = mvarEQStartTime(1)
            .EQStartTime(2) = mvarEQStartTime(2)
            .EQStartTime(3) = mvarEQStartTime(3)
        End With
    End Sub

    Public Sub Clear()
        Try
            SlotNo = 0
            mvarGlassID = ""
            mvarRDRAGE = 0
            mvarDGRADE = 0
            mvarGGRADE = 0
            mvarPSHGroup = ""
            mvarPTOOLID = ""
            mvarDMQCToolID = ""
            mvarChipGrade = ""
            mvarFIRMFLAG = 0
            mvarSCRPFLAG = 0
            mvarRWKFLAG = 0
            mvarProductCode = ""
            mvarLastProcessLineID = ""

            mvarProductCategory = 0
            mvarLotRecipeID = ""
            mvarEQ1PPID = ""
            mvarEQ2PPID = ""
            mvarEQStartTime(1) = ""
            mvarEQEndTime(1) = ""
            mvarEQStartTime(2) = ""
            mvarEQEndTime(2) = ""
            mvarEQStartTime(3) = ""
            mvarEQEndTime(3) = ""
        Catch ex As Exception
            DebugLog(eIFIndex.INDEX_PLC, eLogType.EVENT, ex.ToString)
        End Try
    End Sub

    Public Property GlassID() As String
        Get
            GlassID = MyStringTrim(mvarGlassID)
        End Get
        Set(ByVal value As String)
            mvarGlassID = MyStringTrim(value)
        End Set
    End Property

    'r->1:OK,2:Review,3:NG,4:noglass/nojudge
    Public Property RDRAGE() As clsPLC.eRDGRADE
        Get
            RDRAGE = mvarRDRAGE
        End Get
        Set(ByVal value As clsPLC.eRDGRADE)
            mvarRDRAGE = value
        End Set
    End Property

    'd->1:OK,2:NG,3:Review,4:no glass/no judge
    Public Property DGRADE() As clsPLC.eDGRADE
        Get
            DGRADE = mvarDGRADE
        End Get
        Set(ByVal value As clsPLC.eDGRADE)
            mvarDGRADE = value
        End Set
    End Property

    'g->1:OK,2:NG,3:GRAY,4:no glass/no judge
    Public Property GGRADE() As clsPLC.eGGRADE
        Get
            GGRADE = mvarGGRADE
        End Get
        Set(ByVal value As clsPLC.eGGRADE)
            mvarGGRADE = value
        End Set
    End Property

    Public Property PSHGroup() As String
        Get
            PSHGroup = mvarPSHGroup
        End Get
        Set(ByVal value As String)
            mvarPSHGroup = value
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

    Public Property ChipGrade() As String
        Get
            ChipGrade = mvarChipGrade
        End Get
        Set(ByVal value As String)
            mvarChipGrade = value
        End Set
    End Property

    'f->1:Marked for FI-Macro used,2:Others
    Public Property FIRMFLAG() As clsPLC.eFIRMFLAG
        Get
            FIRMFLAG = mvarFIRMFLAG
        End Get
        Set(ByVal value As clsPLC.eFIRMFLAG)
            mvarFIRMFLAG = value
        End Set
    End Property

    's->1:MarkedScrap,2:MarkedRecycled
    Public Property SCRPFLAG() As clsPLC.eSCRPFLAG
        Get
            SCRPFLAG = mvarSCRPFLAG
        End Get
        Set(ByVal value As clsPLC.eSCRPFLAG)
            mvarSCRPFLAG = value
        End Set
    End Property

    'r->1:MarkedRework,2:NormalGlass
    Public Property RWKFLAG() As clsPLC.eRWKFLAG
        Get
            RWKFLAG = mvarRWKFLAG
        End Get
        Set(ByVal value As clsPLC.eRWKFLAG)
            mvarRWKFLAG = value
        End Set
    End Property

    '--------------------------------------------
    Public Property ProductCategory() As clsPLC.eProductCategory
        Get
            ProductCategory = mvarProductCategory
        End Get
        Set(ByVal value As clsPLC.eProductCategory)
            mvarProductCategory = value
        End Set
    End Property

    Public Property LotRecipeID() As String
        Get
            LotRecipeID = MyStringTrim(mvarLotRecipeID)
        End Get
        Set(ByVal value As String)
            mvarLotRecipeID = MyStringTrim(value)
        End Set
    End Property

    'Tape
    Public Property EQ1PPID() As String
        Get
            EQ1PPID = mvarEQ1PPID
        End Get
        Set(ByVal value As String)
            mvarEQ1PPID = value
        End Set
    End Property

    'Ink
    Public Property EQ2PPID() As String
        Get
            EQ2PPID = mvarEQ2PPID
        End Get
        Set(ByVal value As String)
            mvarEQ2PPID = value
        End Set
    End Property

    Public Property EQStartTime(ByVal nEQ As Integer) As String
        Get
            EQStartTime = mvarEQStartTime(nEQ)
        End Get
        Set(ByVal value As String)
            mvarEQStartTime(nEQ) = value
        End Set
    End Property

    Public Property EQEndTime(ByVal nEQ As Integer) As String
        Get
            EQEndTime = mvarEQEndTime(nEQ)
        End Get
        Set(ByVal value As String)
            mvarEQEndTime(nEQ) = value
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

    Public Property LastProcessLineID() As String
        Get
            Return mvarLastProcessLineID
        End Get
        Set(ByVal value As String)
            mvarLastProcessLineID = value
        End Set
    End Property
End Class
