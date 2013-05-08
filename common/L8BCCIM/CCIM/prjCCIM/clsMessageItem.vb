Public Class clsMessageItem

    Private mvarStreamID As Integer
    Private mvarFunctionID As Integer
    Private mvarRelyExpected As Boolean
    Private mvarHOSTSend As Boolean


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

    Public Property RelyExpected() As Boolean
        Get
            RelyExpected = mvarRelyExpected
        End Get
        Set(ByVal value As Boolean)
            mvarRelyExpected = value
        End Set
    End Property

    Public Property HOSTSend() As Boolean
        Get
            HOSTSend = mvarHOSTSend
        End Get
        Set(ByVal value As Boolean)
            mvarHOSTSend = value
        End Set
    End Property



End Class
