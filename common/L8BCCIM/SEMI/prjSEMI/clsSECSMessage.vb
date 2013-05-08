Public Class clsSECSMessage
    Private MyMsgID As String
    Private MySECSHeader As New clsSECSHead
    Private MySECSBody As New List(Of clsSECSBody)


    'Public Sub SECSMessage(ByVal StreamID As Byte, ByVal FunctionID As Byte)
    '    Fn_SetMessageID(StreamID, FunctionID)
    '    MySECSHeader.StreamID = StreamID
    '    MySECSHeader.FunctionID = FunctionID
    'End Sub

    'Public Sub SECSMessage(ByVal StreamID As Byte, ByVal FunctionID As Byte, ByVal WBit As Boolean, ByVal SystemByte As ULong)
    '    Fn_SetMessageID(StreamID, FunctionID)
    '    MySECSHeader.StreamID = StreamID
    '    MySECSHeader.FunctionID = FunctionID
    '    MySECSHeader.WaitBit = WBit
    '    MySECSHeader.SystemByte = SystemByte
    'End Sub
    Public Enum eDataUType
        U1
        U2
        U4
        U8
    End Enum

    Public Sub Fn_SetMessageID(ByVal StreamID As Byte, ByVal FunctionID As Byte)
        MyMsgID = "S" & StreamID & "F" & FunctionID
    End Sub

    Public Sub Fn_SetMessageID(ByVal ControlMessageName As String)
        MyMsgID = ControlMessageName
    End Sub

    Public Sub Fn_Add_List(ByVal nNod As Integer, Optional ByVal strTagName As String = "")
        Dim Temp As New clsSECSBody

        Temp.FormateCode = eFormatCode.LIST
        Temp.TagName = strTagName
        Temp.List = nNod
        MySECSBody.Add(Temp)
    End Sub

    Public Sub Fn_Add_ASC(ByVal strASCII As String, ByVal nLength As Integer, Optional ByVal strTagName As String = "")
        Dim Temp As New clsSECSBody
        Dim strMyString As String = ""

        Temp.FormateCode = eFormatCode.ASCII
        Temp.ItemSize = nLength
        Temp.TagName = strTagName
        If strASCII = Nothing Then strMyString = ""

        If strASCII.Length < nLength Then
            strMyString = strASCII.PadRight(nLength)
        Else
            strMyString = strASCII.Substring(0, nLength)
        End If

        Temp.ItemValue = strMyString
        MySECSBody.Add(Temp)

    End Sub

    Public Sub Fn_Add_Binary(ByVal Value() As Byte, ByVal nSize As Integer, Optional ByVal strTagName As String = "")
        Dim nLen As Integer = nSize - Value.Length
        Dim Temp As New clsSECSBody

        Temp.FormateCode = eFormatCode.BINARY
        Temp.ItemSize = nSize
        Temp.TagName = strTagName

        If nLen >= 0 Then
            Temp.ItemValue = BitConverter.ToString(Value, 0, nSize)
        Else
            Temp.ItemValue = BitConverter.ToString(Value)
        End If

        MySECSBody.Add(Temp)
    End Sub

    Public Sub Fn_Add_UINT(ByVal nSize As Short, ByVal nType As eDataUType, ByVal Value() As Byte, Optional ByVal strTagName As String = "")
        Dim nLen As Integer = nSize - Value.Length
        Dim Temp As New clsSECSBody

        Select Case nType
            Case eDataUType.U1
                Temp.FormateCode = eFormatCode.U1
            Case eDataUType.U2
                Temp.FormateCode = eFormatCode.U2
            Case eDataUType.U4
                Temp.FormateCode = eFormatCode.U4
            Case eDataUType.U8
                Temp.FormateCode = eFormatCode.U8
        End Select
        Temp.ItemSize = nSize

        If nLen >= 0 Then
            Temp.ItemValue = BitConverter.ToString(Value, 0, nSize)
        Else
            Temp.ItemValue = BitConverter.ToString(Value)
        End If

        MySECSBody.Add(Temp)
    End Sub

    Public ReadOnly Property MessageID() As String
        Get
            MessageID = MyMsgID
        End Get
    End Property

    Public Property MessageHeader() As clsSECSHead
        Get
            MessageHeader = MySECSHeader
        End Get
        Set(ByVal value As clsSECSHead)
            MySECSHeader = value
        End Set
    End Property

    Public Property MessageBody() As List(Of clsSECSBody)
        Get
            MessageBody = MySECSBody
        End Get
        Set(ByVal value As List(Of clsSECSBody))
            MySECSBody = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal StreamID As Byte, ByVal FunctionID As Byte)
        Fn_SetMessageID(StreamID, FunctionID)
        MySECSHeader.StreamID = StreamID
        MySECSHeader.FunctionID = FunctionID
    End Sub

    Public Sub New(ByVal StreamID As Byte, ByVal FunctionID As Byte, ByVal WBit As Boolean, ByVal SystemByte As ULong)
        Fn_SetMessageID(StreamID, FunctionID)
        MySECSHeader.StreamID = StreamID
        MySECSHeader.FunctionID = FunctionID
        MySECSHeader.WaitBit = WBit
        MySECSHeader.SystemByte = SystemByte
    End Sub
End Class
