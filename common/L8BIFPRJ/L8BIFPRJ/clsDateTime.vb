Public Class clsDateTime

    Private mvarYear As Integer
    Private mvarMonth As Integer
    Private mvarDay As Integer
    Private mvarHour As Integer
    Private mvarMinute As Integer
    Private mvarSecond As Integer
    Private mvarnWeek As Integer

    Public Property nWeek() As Integer
        Get
            nWeek = mvarnWeek
        End Get
        Set(ByVal value As Integer)
            mvarnWeek = value
        End Set
    End Property

    Public Property nSecond() As Integer
        Get
            nSecond = mvarSecond
        End Get
        Set(ByVal value As Integer)
            mvarSecond = value
        End Set
    End Property

    Public Property nMinute() As Integer
        Get
            nMinute = mvarMinute
        End Get
        Set(ByVal value As Integer)
            mvarMinute = value
        End Set
    End Property

    Public Property nHour() As Integer
        Get
            nHour = mvarHour
        End Get
        Set(ByVal value As Integer)
            mvarHour = value
        End Set
    End Property

    Public Property nDay() As Integer
        Get
            nDay = mvarDay
        End Get
        Set(ByVal value As Integer)
            mvarDay = value
        End Set
    End Property

    Public Property nMonth() As Integer
        Get
            nMonth = mvarMonth
        End Get
        Set(ByVal value As Integer)
            mvarMonth = value
        End Set
    End Property

    Public Property nYear() As Integer
        Get
            nYear = mvarYear
        End Get
        Set(ByVal value As Integer)
            mvarYear = value
        End Set
    End Property

End Class
