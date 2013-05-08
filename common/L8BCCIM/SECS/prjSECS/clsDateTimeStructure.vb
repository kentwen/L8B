Public Class clsDateTimeStructure

    Private mvarSecond As Integer
    Private mvarMinute As Integer
    Private mvarHour As Integer
    Private mvarDay As Integer
    Private mvarMonth As Integer
    Private mvarYear As Integer

    Public Property Second() As Integer
        Get
            Second = mvarSecond
        End Get
        Set(ByVal value As Integer)
            mvarSecond = value
        End Set
    End Property

    Public Property Minute() As Integer
        Get
            Minute = mvarMinute
        End Get
        Set(ByVal value As Integer)
            mvarMinute = value

        End Set
    End Property

    Public Property Hour() As Integer
        Get
            Hour = mvarHour
        End Get
        Set(ByVal value As Integer)
            mvarHour = value

        End Set
    End Property

    Public Property Day() As Integer
        Get
            Day = mvarDay
        End Get
        Set(ByVal value As Integer)
            mvarDay = value
        End Set
    End Property

    Public Property Month() As Integer
        Get
            Month = mvarMonth
        End Get
        Set(ByVal value As Integer)
            mvarMonth = value
        End Set
    End Property



    Public Property Year() As Integer
        Get
            Year = mvarYear
        End Get
        Set(ByVal value As Integer)
            mvarYear = value
        End Set
    End Property

    Friend Sub SetDateTimeValue(ByVal strDateTime As String)
        Dim strConvert As String

        strConvert = ZeroCodeCTL(strDateTime, 14)

        mvarYear = CInt(Left(strConvert, 4))
        mvarMonth = CInt(Mid(strConvert, 5, 2))
        mvarDay = CInt(Mid(strConvert, 7, 2))
        mvarHour = CInt(Mid(strConvert, 9, 2))
        mvarMinute = CInt(Mid(strConvert, 11, 2))
        mvarSecond = CInt(Mid(strConvert, 13, 2))
    End Sub

    Public ReadOnly Property GetDateTime() As String
        Get
            GetDateTime = CStr(Me.mvarYear) + CStr(Me.mvarMonth) + CStr(Me.mvarDay) + CStr(Me.mvarHour) + CStr(Me.mvarMinute) + CStr(Me.mvarSecond)

        End Get

    End Property
End Class
