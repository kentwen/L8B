Public Class clsWIPDataInTool
    Private mvarWIPCollection As Collection
    Private mvarToolID As String
    Private mvarToolWithGx As Boolean

    Public Property ToolID() As String
        Get
            ToolID = mvarToolID
        End Get
        Set(ByVal value As String)
            mvarToolID = SpaceCTL(value, LEN_TOOLID)
        End Set
    End Property

    Public Sub AddWIPInfo(ByVal HOSTGxID As String, ByVal VCRGxID As String, ByVal GxGrade As clsEnumCtl.eGlassGrade, ByVal DMQCGrade As clsEnumCtl.eDMQCGrade)
        Dim NewWIP As clsWIPStructure
        NewWIP = New clsWIPStructure

        NewWIP.HOSTGxID = HOSTGxID
        NewWIP.VCRGxID = VCRGxID
        NewWIP.GxGrade = GxGrade
        NewWIP.DMQCGrade = DMQCGrade

        mvarWIPCollection.Add(NewWIP)

        NewWIP = Nothing

    End Sub

    Public Property ToolWithGx() As Boolean
        Get
            ToolWithGx = mvarToolWithGx
        End Get
        Set(ByVal value As Boolean)
            mvarToolWithGx = value
        End Set
    End Property

    Public Sub RemoveWIPInfo(ByVal nIndex As VariantType)
        mvarWIPCollection.Remove(nIndex)
    End Sub
    Public ReadOnly Property WIPItem(ByVal nIndex As Integer) As clsWIPStructure
        Get
            Return mvarWIPCollection(nIndex)
        End Get
    End Property

    Public ReadOnly Property WIPItemCount() As Long
        Get
            Return mvarWIPCollection.Count
        End Get
    End Property

    Public Sub New()
        mvarWIPCollection = New Collection
    End Sub

    Protected Overrides Sub Finalize()
        Dim nFor As Integer

        For nFor = 1 To mvarWIPCollection.Count
            mvarWIPCollection.Remove(1)

        Next

        mvarWIPCollection = Nothing

        MyBase.Finalize()

    End Sub
End Class
