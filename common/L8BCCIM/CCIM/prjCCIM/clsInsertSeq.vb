Public Class clsInsertSeq
    Private mvarInsertState As Integer
    Private mvarInsertTable As Integer
    Private mvarInsertSeq As Integer

    Public Property InsertState() As Integer
        Get
            InsertState = mvarInsertState
        End Get
        Set(ByVal value As Integer)
            mvarInsertState = value
        End Set
    End Property

    Public Property InsertTable() As Integer
        Get
            InsertTable = mvarInsertTable
        End Get
        Set(ByVal value As Integer)
            mvarInsertTable = value
        End Set
    End Property

    Public Property InsertSeq() As Integer
        Get
            InsertSeq = mvarInsertSeq
        End Get
        Set(ByVal value As Integer)
            mvarInsertSeq = value
        End Set
    End Property
End Class
