Public Class clsStateTable
    Private mvarStreamID As Integer
    Private mvarFunctionID As Integer
    Private mvarActive As Boolean
    Private mvarReply As Boolean
    Private mvarNextStep As Integer

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

    Public Property Active() As Boolean
        Get
            Active = mvarActive
        End Get
        Set(ByVal value As Boolean)
            mvarActive = value
        End Set
    End Property

    Public Property Reply() As Boolean
        Get
            Reply = mvarReply
        End Get
        Set(ByVal value As Boolean)
            mvarReply = value
        End Set
    End Property

    Public Property NextStep() As Integer
        Get
            NextStep = mvarNextStep
        End Get
        Set(ByVal value As Integer)
            mvarNextStep = value
        End Set
    End Property
End Class
