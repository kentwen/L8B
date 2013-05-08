Public Class clsAlarmStructure


    Private mvarAlarmID As Integer
    Private mvarAlarmText As String
    Private mvarAlarmType As clsEnumCtl.eAlarmType
    Private mvarAlarmFlag As clsEnumCtl.eAlarmFlag

    Private mvarSECSAlarmType As String
    Private mvarSECSAlarmFlag As String
    Private mvarDateTimeInfo As String

    Private mvarfReportOccurr As Boolean
    Private mvarfReportRelease As Boolean

    Public Property DateTimeInfo() As String
        Get
            DateTimeInfo = mvarDateTimeInfo
        End Get
        Set(ByVal value As String)
            mvarDateTimeInfo = value
        End Set
    End Property

    Public Property AlarmID() As Integer
        Get
            AlarmID = mvarAlarmID
        End Get
        Set(ByVal value As Integer)
            mvarAlarmID = value
        End Set
    End Property
    Public Property AlarmText() As String
        Get
            AlarmText = mvarAlarmText
        End Get
        Set(ByVal value As String)
            mvarAlarmText = SpaceCTL(value, 80)
        End Set
    End Property


    Public Property AlarmType() As clsEnumCtl.eAlarmType
        Get
            AlarmType = mvarAlarmType
        End Get
        Set(ByVal value As clsEnumCtl.eAlarmType)
            mvarAlarmType = value

            If value = clsEnumCtl.eAlarmType.TYPE_ALARM Then
                mvarSECSAlarmType = "A"
            Else
                mvarSECSAlarmType = "W"
            End If
        End Set
    End Property

    Public Property AlarmFlag() As clsEnumCtl.eAlarmFlag
        Get
            AlarmFlag = mvarAlarmFlag
        End Get

        Set(ByVal value As clsEnumCtl.eAlarmFlag)
            mvarAlarmFlag = value
            If value = clsEnumCtl.eAlarmFlag.TYPE_OCCUR Then
                mvarSECSAlarmFlag = "1"
            Else
                mvarSECSAlarmFlag = "0"
            End If
        End Set
    End Property

    Friend ReadOnly Property GetSECSAlarmType() As String
        Get
            GetSECSAlarmType = mvarSECSAlarmType
        End Get
    End Property

    Friend ReadOnly Property GetSECSAlarmFlag() As String
        Get
            GetSECSAlarmFlag = mvarSECSAlarmFlag
        End Get
    End Property

    Public Property fReportOccurr() As Boolean
        Get
            Return mvarfReportOccurr
        End Get
        Set(ByVal value As Boolean)
            mvarfReportOccurr = value
        End Set
    End Property


    Public Property fReportRelease() As Boolean
        Get
            Return mvarfReportRelease
        End Get
        Set(ByVal value As Boolean)
            mvarfReportRelease = value
        End Set
    End Property
End Class
