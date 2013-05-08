Public Class clsEventItem
    Private mvarIndex As Integer
    Private mvarStreamID As Integer
    Private mvarFunctionID As Integer

    Public Property Index() As Integer
        Get
            Index = mvarIndex
        End Get
        Set(ByVal value As Integer)
            mvarIndex = value
        End Set
    End Property

    Public Property StreamID() As Integer
        Get
            StreamID = mvarStreamID
        End Get
        Set(ByVal value As Integer)
            mvarStreamID = value
        End Set
    End Property

    Public Property FunctionID() As Integer
        Get
            FunctionID = mvarFunctionID
        End Get
        Set(ByVal value As Integer)
            mvarFunctionID = value
        End Set
    End Property
End Class
