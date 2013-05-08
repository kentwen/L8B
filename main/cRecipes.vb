Public Class cRecipe

    Public Enum eFICIMGradeReport
        [NOTHING] = 0
        [GLASS] = 1
        [DMQC] = 2
    End Enum

    Public EQRecipe(MaxPort) As EQRecipeType
    Private mRecipeName As String
    Private mGlassType As String
    Private mEQPPID As String
    Private mRobotSpeed As String
    Private mVCRPosition As String
    Private mVersion As String
    Private mRemark As String
    Private mSampleGlass As Integer
    Private mFICIMResult As eFICIMGradeReport
    Private mColorRepairMode As L8BIFPRJ.clsPLC.eColorRepairMode
    Private mSelectGlass(MAXCASSETTESLOT) As Integer

    Public Structure EQRecipeType
        Dim PPID As String
        Dim AOIMode As String
        Dim bSelect As Boolean
    End Structure

    Public Property PPID() As String
        Get
            Return mRecipeName
        End Get
        Set(ByVal value As String)
            mRecipeName = value
        End Set
    End Property

    Public Property GlassType() As String
        Get
            Return mGlassType
        End Get
        Set(ByVal value As String)
            mGlassType = value
        End Set
    End Property

    Public Property RobotSpeed() As String
        Get
            Return mRobotSpeed
        End Get
        Set(ByVal value As String)
            mRobotSpeed = value
        End Set
    End Property

    Public Property VCRPosition() As String
        Get
            Return mVCRPosition
        End Get
        Set(ByVal value As String)
            mVCRPosition = value
        End Set
    End Property

    Public Property Version() As String
        Get
            Return mVersion
        End Get
        Set(ByVal value As String)
            mVersion = value
        End Set
    End Property

    Public Property Remark() As String
        Get
            Return mRemark
        End Get
        Set(ByVal value As String)
            mRemark = value
        End Set
    End Property

    Public Property SampleGlass() As Integer
        Get
            Return mSampleGlass
        End Get
        Set(ByVal value As Integer)
            mSampleGlass = value
        End Set
    End Property

    Public Property FICIMResult() As eFICIMGradeReport
        Get
            Return mFICIMResult
        End Get
        Set(ByVal value As eFICIMGradeReport)
            mFICIMResult = value
        End Set
    End Property

    Public Property ColorRepairMode() As L8BIFPRJ.clsPLC.eGlassType
        Get
            Return mColorRepairMode
        End Get
        Set(ByVal value As L8BIFPRJ.clsPLC.eGlassType)
            mColorRepairMode = value
        End Set
    End Property

    Public Property EQSelection() As Integer
        Get
            Dim tmp As Integer = 0
            If EQRecipe(1).bSelect Then
                tmp += 1
            End If
            If EQRecipe(2).bSelect Then
                tmp += 2
            End If
            Return tmp
        End Get
        Set(ByVal value As Integer)

            If value Mod 2 > 0 Then
                EQRecipe(1).bSelect = True
            Else
                EQRecipe(1).bSelect = False
            End If

            If (value \ 2) Mod 2 > 0 Then
                EQRecipe(2).bSelect = True
            Else
                EQRecipe(2).bSelect = False
            End If
        End Set
    End Property

    Public Property EQPPID() As String
        Get
            Return mEQPPID
        End Get
        Set(ByVal value As String)
            mEQPPID = value
        End Set
    End Property

    Public Property EQPPID(ByVal index As Integer) As String
        Get
            Return EQRecipe(index).PPID
        End Get
        Set(ByVal value As String)
            EQRecipe(index).PPID = value
        End Set
    End Property

    Public Property SelectGlass(ByVal GlassIndex As Integer) As Integer
        Get
            Return mSelectGlass(GlassIndex)
        End Get
        Set(ByVal value As Integer)
            mSelectGlass(GlassIndex) = value
        End Set
    End Property

End Class
