Public Class clsPortStructure
    Private mvarPortStatus As clsEnumCtl.ePortStatus
    Private mvarPortCategory As clsEnumCtl.ePortCategory
    Private mvarPortMode As clsEnumCtl.ePortMode
    Private mvarPortWithCassette As Boolean
    Private mvarPortPosition As Integer
    'Private mvarPortPosition As Integer
    Private mvarAGVMode As Boolean
    Private mvarCassetteID As String
    Private mvarPortType As clsEnumCtl.ePortType

    Private mvarCPPID As String

    Public Property PortStatus() As clsEnumCtl.ePortStatus
        Get
            PortStatus = mvarPortStatus
        End Get
        Set(ByVal value As clsEnumCtl.ePortStatus)
            mvarPortStatus = value
        End Set
    End Property

    Public Property PortCategory() As clsEnumCtl.ePortCategory
        Get
            PortCategory = mvarPortCategory
        End Get
        Set(ByVal value As clsEnumCtl.ePortCategory)
            mvarPortCategory = value
        End Set
    End Property

    Public Property PortMode() As clsEnumCtl.ePortMode
        Get
            PortMode = mvarPortMode
        End Get
        Set(ByVal value As clsEnumCtl.ePortMode)
            mvarPortMode = value
        End Set
    End Property

    Public Property WithCassette() As Boolean
        Get
            WithCassette = mvarPortWithCassette
        End Get
        Set(ByVal value As Boolean)
            mvarPortWithCassette = value
        End Set
    End Property

    Public Property PortPosition() As Integer
        Get
            Return mvarPortPosition
        End Get
        Set(ByVal value As Integer)
            mvarPortPosition = value
        End Set
    End Property

 
    Public Property AGVMode() As Boolean
        Get
            AGVMode = mvarAGVMode
        End Get
        Set(ByVal value As Boolean)
            mvarAGVMode = value
        End Set
    End Property

    Public Property CassetteID() As String
        Get
            CassetteID = mvarCassetteID
        End Get
        Set(ByVal value As String)
            mvarCassetteID = value
        End Set
    End Property

    Public Property PortType() As clsEnumCtl.ePortType
        Get
            PortType = mvarPortType
        End Get
        Set(ByVal value As clsEnumCtl.ePortType)
            mvarPortType = value
        End Set
    End Property





    Public Property CPPID() As String
        Get
            CPPID = mvarCPPID
        End Get
        Set(ByVal value As String)
            mvarCPPID = value
        End Set
    End Property

End Class
