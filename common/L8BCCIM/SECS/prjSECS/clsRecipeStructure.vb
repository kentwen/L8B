Public Class clsRecipeStructure
    Private mvarRecipeName As String
    Private mvarTotalParmeter As Integer
    Private mvarParmeterName() As String
    Private mvarParmeterValue() As String
    Private mvarAckCode As clsEnumCtl.eACKC7ReplyCMD

    Public Property RecipeName() As String
        Get
            RecipeName = SpaceCTL(mvarRecipeName, 16)
        End Get
        Set(ByVal value As String)
            mvarRecipeName = value
        End Set
    End Property

    Public Property TotalParmeter() As Integer
        Get
            TotalParmeter = mvarTotalParmeter
        End Get
        Set(ByVal value As Integer)
            mvarTotalParmeter = value
            ReDim mvarParmeterName(0 To value)
            ReDim mvarParmeterValue(0 To value)
        End Set
    End Property

    Public Property ParmeterName(ByVal nIndex As Integer) As String
        Get
            ParmeterName = SpaceCTL(mvarParmeterName(nIndex), 16)
        End Get
        Set(ByVal value As String)
            mvarParmeterName(nIndex) = value
        End Set
    End Property

    Public Property ParmeterValue(ByVal nIndex As Integer) As String
        Get
            ParmeterValue = SpaceCTL(mvarParmeterValue(nIndex), 16)
        End Get
        Set(ByVal value As String)
            mvarParmeterValue(nIndex) = value
        End Set
    End Property

    Public Property AckCode() As clsEnumCtl.eACKC7ReplyCMD
        Get
            AckCode = mvarAckCode
        End Get
        Set(ByVal value As clsEnumCtl.eACKC7ReplyCMD)
            mvarAckCode = value
        End Set
    End Property
End Class
