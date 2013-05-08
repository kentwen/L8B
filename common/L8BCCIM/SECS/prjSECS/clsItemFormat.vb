Public Class clsItemFormat
    Private mvarItemName As String
    Private mvarItemValue As String

    Public Property ItemName() As String
        Get
            ItemName = mvarItemName
        End Get
        Set(ByVal value As String)
            mvarItemName = SpaceCTL(value, 24)
        End Set
    End Property

    Public Property ItemValue() As String
        Get
            ItemValue = mvarItemValue
        End Get
        Set(ByVal value As String)
            mvarItemValue = SpaceCTL(value, 16)
        End Set
    End Property
End Class
