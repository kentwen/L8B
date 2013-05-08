Public Class clsEDSStructure
    Private mvarEDSName As String
    Private mvarEDSValue As String

    Public Property EDSName() As String
        Get
            EDSName = mvarEDSName
        End Get
        Set(ByVal value As String)
            mvarEDSName = value
        End Set
    End Property

    Public Property EDSValue() As String
        Get
            EDSValue = mvarEDSValue
        End Get
        Set(ByVal value As String)
            mvarEDSValue = value
        End Set
    End Property
End Class
