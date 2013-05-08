Public Class clsSlotStructure

    Private mvarSlotNo As Integer
    Private mvarGlassID As String
    Private mvarDMQCGrade As clsEnumCtl.eDMQCGrade
    Private mvarDMQCResult As clsEnumCtl.eDMQCGrade
    Private mvarDMQCDownload As clsEnumCtl.eDMQCGrade
    Private mvarLastOperationID As String
    Private mvarLastPorcessToolID As String
    Private mvarLastLineID As String
    Private mvarProcessToolID As String
    Private mvarDMQCToolID As String
    Private mvarDMQCToolIDDownload As String
    Private mvarLineID As String
    Private mvarPSHGroup As String
    Private mvarGlassGrade As clsEnumCtl.eGlassGrade
    Private mvarGlassGradeDownload As clsEnumCtl.eGlassGrade
    Private mvarChipGrade(0 To MAX_CHIPGRADE) As clsEnumCtl.eGlassGrade
    Private mvarRework As Boolean
    Private mvarScrap As clsEnumCtl.eScrapType
    Private mvarFIRemark As Boolean
    Private mvarFIFCFlag As clsEnumCtl.eFIFCFlag
    Private mvarProcFlag As Boolean

    Private mvarIsGlassProecssed As Boolean

    Public Property IsGlassProecssed() As Boolean
        Get
            IsGlassProecssed = mvarIsGlassProecssed
        End Get
        Set(ByVal value As Boolean)
            mvarIsGlassProecssed = value
        End Set
    End Property

    Public Property SlotNo() As Integer
        Get
            SlotNo = mvarSlotNo
        End Get
        Set(ByVal value As Integer)
            mvarSlotNo = value
        End Set
    End Property

    Public Property GlassID() As String
        Get
            GlassID = SpaceCTL(mvarGlassID, LEN_GXID)
        End Get
        Set(ByVal value As String)
            mvarGlassID = SpaceCTL(value, LEN_GXID)
        End Set
    End Property

    Public Property DMQCGrade() As clsEnumCtl.eDMQCGrade
        Get
            DMQCGrade = mvarDMQCGrade
        End Get
        Set(ByVal value As clsEnumCtl.eDMQCGrade)
            mvarDMQCGrade = value
        End Set
    End Property

    Public Property DMQCResult() As clsEnumCtl.eDMQCGrade
        Get
            DMQCResult = mvarDMQCResult
        End Get
        Set(ByVal value As clsEnumCtl.eDMQCGrade)
            mvarDMQCResult = value
        End Set
    End Property


    Public Property DMQCDownload() As clsEnumCtl.eDMQCGrade
        Get
            DMQCDownload = mvarDMQCDownload
        End Get
        Set(ByVal value As clsEnumCtl.eDMQCGrade)
            mvarDMQCDownload = value
        End Set
    End Property

    Public Property LastLineID() As String
        Get
            LastLineID = mvarLastLineID
        End Get
        Set(ByVal value As String)
            mvarLastLineID = value
        End Set
    End Property

    Public Property LastOperationID() As String
        Get
            LastOperationID = SpaceCTL(mvarLastOperationID, LEN_OPERATIONID)
        End Get
        Set(ByVal value As String)
            mvarLastOperationID = SpaceCTL(value, LEN_OPERATIONID)
        End Set
    End Property

    Public Property LastPorcessToolID() As String
        Get
            LastPorcessToolID = mvarLastPorcessToolID
        End Get
        Set(ByVal value As String)
            mvarLastPorcessToolID = value
        End Set
    End Property

    Public Property ProcessToolID() As String
        Get
            ProcessToolID = SpaceCTL(mvarProcessToolID, LEN_TOOLID)
        End Get
        Set(ByVal value As String)
            mvarProcessToolID = SpaceCTL(value, LEN_TOOLID)
        End Set
    End Property

    Public Property DMQCToolID() As String
        Get
            DMQCToolID = SpaceCTL(mvarDMQCToolID, LEN_TOOLID)
        End Get
        Set(ByVal value As String)
            mvarDMQCToolID = SpaceCTL(value, LEN_TOOLID)
        End Set
    End Property
    Public Property PLineID() As String
        Get
            PLineID = SpaceCTL(mvarLineID, LEN_LINEID)
        End Get
        Set(ByVal value As String)
            mvarLineID = SpaceCTL(value, LEN_LINEID)
        End Set
    End Property

    Public Property DMQCToolIDDownload() As String
        Get
            DMQCToolIDDownload = SpaceCTL(mvarDMQCToolIDDownload, LEN_TOOLID)
        End Get
        Set(ByVal value As String)
            mvarDMQCToolIDDownload = SpaceCTL(value, LEN_TOOLID)
        End Set
    End Property

    Public Property PSHGroup() As String
        Get
            PSHGroup = SpaceCTL(mvarPSHGroup, LEN_PSHGROUP)
        End Get
        Set(ByVal value As String)
            mvarPSHGroup = SpaceCTL(value, LEN_PSHGROUP)
        End Set
    End Property

    Public Property GlassGrade() As clsEnumCtl.eGlassGrade
        Get
            GlassGrade = mvarGlassGrade
        End Get
        Set(ByVal value As clsEnumCtl.eGlassGrade)
            mvarGlassGrade = value
        End Set
    End Property

    Public Property GlassGradeDownload() As clsEnumCtl.eGlassGrade
        Get
            GlassGradeDownload = mvarGlassGradeDownload
        End Get
        Set(ByVal value As clsEnumCtl.eGlassGrade)
            mvarGlassGradeDownload = value
        End Set
    End Property

    Public Property GlassGradeByString() As String

        Get
            Dim strGradeCode As String
            Select Case mvarGlassGrade
                Case clsEnumCtl.eGlassGrade.NO
                    strGradeCode = Space(1)
                Case clsEnumCtl.eGlassGrade.OK
                    strGradeCode = "O"
                Case clsEnumCtl.eGlassGrade.NG
                    strGradeCode = "N"
                Case clsEnumCtl.eGlassGrade.GRAY
                    strGradeCode = "G"
                Case Else
                    strGradeCode = Space(1)
            End Select
            GlassGradeByString = strGradeCode
        End Get

        Set(ByVal value As String)
            Select Case value
                Case Space(1)
                    mvarGlassGrade = clsEnumCtl.eGlassGrade.NO
                Case "O"
                    mvarGlassGrade = clsEnumCtl.eGlassGrade.OK
                Case "N"
                    mvarGlassGrade = clsEnumCtl.eGlassGrade.NG
                Case "G"
                    mvarGlassGrade = clsEnumCtl.eGlassGrade.GRAY
                Case Else
                    mvarGlassGrade = clsEnumCtl.eGlassGrade.NO
            End Select
        End Set
    End Property

    Public Property GxGradeDownloadByString() As String
        Get
            Dim strGradeCode As String
            Select Case mvarGlassGradeDownload
                Case clsEnumCtl.eGlassGrade.NO
                    strGradeCode = Space(1)
                Case clsEnumCtl.eGlassGrade.OK
                    strGradeCode = "O"
                Case clsEnumCtl.eGlassGrade.NG
                    strGradeCode = "N"
                Case clsEnumCtl.eGlassGrade.GRAY
                    strGradeCode = "G"
                Case Else
                    strGradeCode = Space(1)
            End Select
            GxGradeDownloadByString = strGradeCode
        End Get
        Set(ByVal value As String)
            Select Case value
                Case Space(1)
                    mvarGlassGradeDownload = clsEnumCtl.eGlassGrade.NO
                Case "O"
                    mvarGlassGradeDownload = clsEnumCtl.eGlassGrade.OK
                Case "N"
                    mvarGlassGradeDownload = clsEnumCtl.eGlassGrade.NG
                Case "G"
                    mvarGlassGradeDownload = clsEnumCtl.eGlassGrade.GRAY
                Case Else
                    mvarGlassGradeDownload = clsEnumCtl.eGlassGrade.NO
            End Select
        End Set
    End Property


    Public Property DMQCGradeByString() As String
        Get
            Dim strGradeCode As String
            Select Case mvarDMQCGrade
                Case clsEnumCtl.eDMQCGrade.NO
                    strGradeCode = Space(1)
                Case clsEnumCtl.eDMQCGrade.OK
                    strGradeCode = "O"
                Case clsEnumCtl.eDMQCGrade.NG
                    strGradeCode = "N"
                Case clsEnumCtl.eDMQCGrade.REVIEW
                    strGradeCode = "R"
                Case Else
                    strGradeCode = Space(1)
            End Select
            DMQCGradeByString = strGradeCode
        End Get
        Set(ByVal value As String)
            Select Case value
                Case Space(1)
                    mvarDMQCGrade = clsEnumCtl.eDMQCGrade.NO
                Case "O"
                    mvarDMQCGrade = clsEnumCtl.eDMQCGrade.OK
                Case "N"
                    mvarDMQCGrade = clsEnumCtl.eDMQCGrade.NG
                Case "R"
                    mvarDMQCGrade = clsEnumCtl.eDMQCGrade.REVIEW
                Case Else
                    mvarDMQCGrade = clsEnumCtl.eDMQCGrade.NO
            End Select
        End Set
    End Property

    Public Property DMQCGradeDownloadByString() As String
        Get
            Dim strGradeCode As String
            Select Case mvarDMQCDownload
                Case clsEnumCtl.eDMQCGrade.NO
                    strGradeCode = Space(1)
                Case clsEnumCtl.eDMQCGrade.OK
                    strGradeCode = "O"
                Case clsEnumCtl.eDMQCGrade.NG
                    strGradeCode = "N"
                Case clsEnumCtl.eDMQCGrade.REVIEW
                    strGradeCode = "R"
                Case Else
                    strGradeCode = Space(1)
            End Select
            DMQCGradeDownloadByString = strGradeCode
        End Get
        Set(ByVal value As String)
            Select Case value
                Case Space(1)
                    mvarDMQCDownload = clsEnumCtl.eDMQCGrade.NO
                Case "O"
                    mvarDMQCDownload = clsEnumCtl.eDMQCGrade.OK
                Case "N"
                    mvarDMQCDownload = clsEnumCtl.eDMQCGrade.NG
                Case "R"
                    mvarDMQCDownload = clsEnumCtl.eDMQCGrade.REVIEW
                Case Else
                    mvarDMQCDownload = clsEnumCtl.eDMQCGrade.NO
            End Select
        End Set
    End Property

    Public Property DMQCGradeResultByString() As String
        Get
            Dim strGradeCode As String
            Select Case mvarDMQCResult
                Case clsEnumCtl.eDMQCGrade.NO
                    strGradeCode = Space(1)
                Case clsEnumCtl.eDMQCGrade.OK
                    strGradeCode = "O"
                Case clsEnumCtl.eDMQCGrade.NG
                    strGradeCode = "N"
                Case clsEnumCtl.eDMQCGrade.REVIEW
                    strGradeCode = "R"
                Case Else
                    strGradeCode = Space(1)
            End Select
            DMQCGradeResultByString = strGradeCode
        End Get
        Set(ByVal value As String)
            Select Case value
                Case Space(1)
                    mvarDMQCResult = clsEnumCtl.eDMQCGrade.NO
                Case "O"
                    mvarDMQCResult = clsEnumCtl.eDMQCGrade.OK
                Case "N"
                    mvarDMQCResult = clsEnumCtl.eDMQCGrade.NG
                Case "R"
                    mvarDMQCResult = clsEnumCtl.eDMQCGrade.REVIEW
                Case Else
                    mvarDMQCResult = clsEnumCtl.eDMQCGrade.NO
            End Select
        End Set
    End Property

    Public Property ChipGrade(ByVal nIndex As Integer) As clsEnumCtl.eGlassGrade
        Get
            ChipGrade = mvarChipGrade(nIndex)
        End Get
        Set(ByVal value As clsEnumCtl.eGlassGrade)
            mvarChipGrade(nIndex) = value
        End Set
    End Property



    Public Property ChipGradeByString() As String
        Get
            Dim nFor As Integer
            Dim strRet As String = ""

            For nFor = 1 To MAX_CHIPGRADE
                Select Case mvarChipGrade(nFor)
                    Case clsEnumCtl.eGlassGrade.NO
                        strRet = strRet & Space(1)
                    Case clsEnumCtl.eGlassGrade.OK
                        strRet = strRet & "O"
                    Case clsEnumCtl.eGlassGrade.NG
                        strRet = strRet & "X"
                    Case clsEnumCtl.eGlassGrade.GRAY
                        strRet = strRet & "G"
                    Case Else
                        strRet = strRet & Space(1)
                End Select
            Next
            ChipGradeByString = strRet
        End Get
        Set(ByVal value As String)
            Dim nFor As Integer
            Dim strRet As String

            For nFor = 1 To MAX_CHIPGRADE
                strRet = Mid(value, nFor, 1)
                Select Case strRet
                    Case Space(1)
                        mvarChipGrade(nFor) = clsEnumCtl.eGlassGrade.NO
                    Case "O"
                        mvarChipGrade(nFor) = clsEnumCtl.eGlassGrade.OK
                    Case "X"
                        mvarChipGrade(nFor) = clsEnumCtl.eGlassGrade.NG
                    Case "G"
                        mvarChipGrade(nFor) = clsEnumCtl.eGlassGrade.GRAY
                    Case Else
                        mvarChipGrade(nFor) = clsEnumCtl.eGlassGrade.NO
                End Select
            Next
        End Set
    End Property


    Public Property Rework() As Boolean
        Get
            Rework = mvarRework
        End Get
        Set(ByVal value As Boolean)
            mvarRework = value
        End Set
    End Property

    Public Property ReworkByString() As String
        Get
            If mvarRework = True Then
                ReworkByString = "R"
            Else
                ReworkByString = Space(1)
            End If
        End Get

        Set(ByVal value As String)
            Select Case value
                Case "R"
                    mvarRework = True
                Case Else
                    mvarRework = False
            End Select
        End Set
    End Property


    Public Property Scrap() As clsEnumCtl.eScrapType
        Get
            Scrap = mvarScrap
        End Get
        Set(ByVal value As clsEnumCtl.eScrapType)
            mvarScrap = value
        End Set
    End Property


    Public Property ScrapByString() As String
        Get
            Select Case mvarScrap
                Case clsEnumCtl.eScrapType.NONE
                    ScrapByString = Space(1)
                Case clsEnumCtl.eScrapType.YES
                    ScrapByString = "S"
                Case clsEnumCtl.eScrapType.RECYCLE
                    ScrapByString = "C"
                Case Else
                    ScrapByString = Space(1)
            End Select
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "S"
                    mvarScrap = clsEnumCtl.eScrapType.YES
                Case "C"
                    mvarScrap = clsEnumCtl.eScrapType.RECYCLE
                Case Else
                    mvarScrap = clsEnumCtl.eScrapType.NONE
            End Select
        End Set
    End Property

    Public Property FIRemark() As Boolean
        Get
            FIRemark = mvarFIRemark
        End Get
        Set(ByVal value As Boolean)
            mvarFIRemark = value
        End Set
    End Property

    Public Property FIRemarkByString() As String
        Get
            If mvarFIRemark Then
                FIRemarkByString = "M"
            Else
                FIRemarkByString = Space(1)
            End If

        End Get
        Set(ByVal value As String)
            Select Case value
                Case "M"
                    mvarFIRemark = True
                Case Else
                    mvarFIRemark = False
            End Select
        End Set
    End Property


    Public Property ProcFlag() As Boolean
        Get
            ProcFlag = mvarProcFlag
        End Get
        Set(ByVal value As Boolean)
            mvarProcFlag = value
        End Set
    End Property

    Public Property FIFCFlag() As clsEnumCtl.eFIFCFlag
        Get
            FIFCFlag = mvarFIFCFlag
        End Get
        Set(ByVal value As clsEnumCtl.eFIFCFlag)
            mvarFIFCFlag = value
        End Set
    End Property

    Public Property FIFCFlagByString() As String
        Get
            Select Case mvarFIFCFlag
                Case clsEnumCtl.eFIFCFlag.FLAG_F
                    FIFCFlagByString = "F"
                Case clsEnumCtl.eFIFCFlag.FLAG_B
                    FIFCFlagByString = "B"
                Case Else
                    FIFCFlagByString = Space(1)
            End Select
        End Get

        Set(ByVal value As String)
            Select Case value
                Case "F"
                    mvarFIFCFlag = clsEnumCtl.eFIFCFlag.FLAG_F
                Case "B"
                    mvarFIFCFlag = clsEnumCtl.eFIFCFlag.FLAG_B
                Case Else
                    mvarFIFCFlag = clsEnumCtl.eFIFCFlag.FLAG_NA
            End Select
        End Set
    End Property
End Class
