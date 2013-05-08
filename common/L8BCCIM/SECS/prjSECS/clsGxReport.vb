Public Class clsGxReport
    Private mvarToolID As String
    Private mvarPPID As String
    Private mvarGxID As String
    Private mvarProcessStartTime As String
    Private mvarProcessEndTime As String

    Public Property ToolID() As String
        Get
            ToolID = mvarToolID
        End Get
        Set(ByVal value As String)
            mvarToolID = value
        End Set
    End Property

    Public Property PPID() As String
        Get
            PPID = mvarPPID
        End Get
        Set(ByVal value As String)
            mvarPPID = value
        End Set
    End Property

    Public Property GxID() As String
        Get
            GxID = mvarGxID
        End Get
        Set(ByVal value As String)
            mvarGxID = value
        End Set
    End Property

    Public Property ProcessStartTime() As String
        Get
            ProcessStartTime = mvarProcessStartTime
        End Get
        Set(ByVal value As String)
            mvarProcessStartTime = value
        End Set
    End Property

    Public Property ProcessEndTime() As String
        Get
            ProcessEndTime = mvarProcessEndTime
        End Get
        Set(ByVal value As String)
            mvarProcessEndTime = value
        End Set
    End Property
End Class
