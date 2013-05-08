Imports System


Public Class clsSECSBody
    Private mvarList As Integer
    Private mvarFormateCode As eFormatCode
    Private mvarFormateCodeDef As eFormatCode
    Private mvarSize As Integer
    Private mvarVal As String
    Private mvarTagName As String
    Private mvarItemIdx As ULong

    Public Sub SECSBody()
        mvarList = 0
        mvarSize = 0
        mvarVal = ""
    End Sub

    Public Property List() As Integer
        Get
            List = mvarList
        End Get
        Set(ByVal value As Integer)
            mvarList = value
        End Set
    End Property

    Public Property FormateCode() As eFormatCode
        Get
            FormateCode = mvarFormateCode
        End Get
        Set(ByVal value As eFormatCode)
            mvarFormateCode = value
        End Set
    End Property

     
    Public ReadOnly Property FormateMatch(ByVal nDefFormate As eFormatCode) As Boolean
        Get
            If nDefFormate = FormateCode Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Property ItemSize() As Integer
        Get
            ItemSize = mvarSize
        End Get
        Set(ByVal value As Integer)
            mvarSize = value
        End Set
    End Property

    Public ReadOnly Property ItemSizeMatch(ByVal nDefSize As Integer) As Boolean
        Get
            If nDefSize >= ItemSize Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public Property ItemValue() As String
        Get
            ItemValue = mvarVal
        End Get
        Set(ByVal value As String)
            mvarVal = value
        End Set
    End Property

    Public Property TagName() As String
        Get
            TagName = mvarTagName
        End Get
        Set(ByVal value As String)
            mvarTagName = value
        End Set
    End Property

    Public Property ItemIdx() As ULong
        Get
            ItemIdx = mvarItemIdx
        End Get
        Set(ByVal value As ULong)
            mvarItemIdx = value
        End Set
    End Property


End Class
