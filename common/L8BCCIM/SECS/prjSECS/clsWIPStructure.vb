Public Class clsWIPStructure

    Private mvarHOSTGxID As String
    Private mvarVCRGxID As String
    Private mvarGxGrade As clsEnumCtl.eGlassGrade
    Private mvarDMQCGrade As clsEnumCtl.eDMQCGrade

    Public Property HOSTGxID() As String
        Get
            HOSTGxID = mvarHOSTGxID
        End Get
        Set(ByVal value As String)
            mvarHOSTGxID = SpaceCTL(value, LEN_GXID)
        End Set
    End Property

    Public Property VCRGxID() As String
        Get
            VCRGxID = mvarVCRGxID
        End Get
        Set(ByVal value As String)
            mvarVCRGxID = SpaceCTL(value, LEN_GXID)
        End Set
    End Property

    Public Property GxGrade() As clsEnumCtl.eGlassGrade
        Get
            GxGrade = mvarGxGrade
        End Get
        Set(ByVal value As clsEnumCtl.eGlassGrade)
            mvarGxGrade = value
        End Set
    End Property

    Public Property GxGradeByString() As String
        Get

            Select Case mvarGxGrade
                Case clsEnumCtl.eGlassGrade.NO
                    GxGradeByString = Space(1)
                Case clsEnumCtl.eGlassGrade.OK
                    GxGradeByString = "O"
                Case clsEnumCtl.eGlassGrade.NG
                    GxGradeByString = "N"
                Case clsEnumCtl.eGlassGrade.GRAY
                    GxGradeByString = "G"
                Case Else
                    GxGradeByString = Space(1)
            End Select
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "O"
                    mvarGxGrade = clsEnumCtl.eGlassGrade.OK
                Case "N"
                    mvarGxGrade = clsEnumCtl.eGlassGrade.NG
                Case "G"
                    mvarGxGrade = clsEnumCtl.eGlassGrade.GRAY
                Case Else
                    mvarGxGrade = clsEnumCtl.eGlassGrade.NO
            End Select
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

    Public Property DMQCGradeByString() As String
        Get
            Select Case mvarDMQCGrade
                Case clsEnumCtl.eDMQCGrade.NO
                    DMQCGradeByString = Space(1)
                Case clsEnumCtl.eDMQCGrade.OK
                    DMQCGradeByString = "O"
                Case clsEnumCtl.eDMQCGrade.NG
                    DMQCGradeByString = "N"
                Case clsEnumCtl.eDMQCGrade.REVIEW
                    DMQCGradeByString = "R"
                Case Else
                    DMQCGradeByString = Space(1)
            End Select
        End Get
        Set(ByVal value As String)
            Select Case value
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
End Class
