Public Class clsUnitStructure


    Private mvarUnitNo As Integer
    Private mvarToolID As String
    Private mvarRemoteStatus As clsEnumCtl.eRemoteStatus
    Private mvarAlarm As New clsAlarmStructure
    Private mvarEQStatus As clsEnumCtl.eEQStatus
    Private mvarEQSubStatus As clsEnumCtl.eEQSubStatus
    Private mvarProcessMode As clsEnumCtl.ePorcessMode
    Private mvarCPPID As String
    Private mvarWIPCount As Integer

    Public Const LEN_CPPID = 32 'Current Recipe

    Public Property UnitNo() As Integer
        Get
            UnitNo = mvarUnitNo
        End Get
        Set(ByVal value As Integer)
            mvarUnitNo = value
        End Set
    End Property

    Public Property ToolID() As String
        Get
            ToolID = SpaceCTL(mvarToolID, LEN_TOOLID)
        End Get
        Set(ByVal value As String)
            mvarToolID = SpaceCTL(value, LEN_TOOLID)
        End Set
    End Property

    Public Property RemoteStatus() As clsEnumCtl.eRemoteStatus
        Get
            RemoteStatus = mvarRemoteStatus
        End Get
        Set(ByVal value As clsEnumCtl.eRemoteStatus)
            Writelog("Unit=" & mvarUnitNo & " RemoteStatus ->" & value, clsEnumCtl.eZLogType.TYPE_PROPERTY)
            mvarRemoteStatus = value
        End Set
    End Property

    Public Property RemoteStatusByString() As String
        Get

            Select Case mvarRemoteStatus
                Case clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
                    RemoteStatusByString = "A"
                Case clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
                    RemoteStatusByString = "B"
                Case clsEnumCtl.eRemoteStatus.MODE_OFFLINE
                    RemoteStatusByString = "D"
                Case Else
                    RemoteStatusByString = "D"
            End Select
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "A"
                    mvarRemoteStatus = clsEnumCtl.eRemoteStatus.MODE_ONLINECONTROL
                Case "B"
                    mvarRemoteStatus = clsEnumCtl.eRemoteStatus.MODE_ONLINEMONITOR
                Case "D"
                    mvarRemoteStatus = clsEnumCtl.eRemoteStatus.MODE_OFFLINE
            End Select
            Writelog("Unit=" & mvarUnitNo & " RemoteStatus ->" & mvarRemoteStatus, clsEnumCtl.eZLogType.TYPE_PROPERTY)
        End Set
    End Property

    Public ReadOnly Property Alarm() As clsAlarmStructure
        Get
            Alarm = mvarAlarm
        End Get
    End Property

    Public Property EQStatus() As clsEnumCtl.eEQStatus
        Get
            EQStatus = mvarEQStatus
        End Get
        Set(ByVal value As clsEnumCtl.eEQStatus)
            mvarEQStatus = value
        End Set
    End Property

    Public Property EQStatusByString() As String
        Get
            'Dim strRet As String = ""
            Select Case mvarEQStatus
                Case clsEnumCtl.eEQStatus.EQ_IDLE
                    Return "I"
                Case clsEnumCtl.eEQStatus.EQ_RUNNING
                    Return "R"
                Case clsEnumCtl.eEQStatus.EQ_DOWN
                    Return "D"
                Case clsEnumCtl.eEQStatus.EQ_SETUP
                    Return "S"
                Case clsEnumCtl.eEQStatus.EQ_STOP
                    Return "P"
                Case Else
                    Return ""
            End Select
        End Get

        Set(ByVal value As String)
            Select Case value
                Case "R"
                    mvarEQStatus = clsEnumCtl.eEQStatus.EQ_RUNNING
                Case "I"
                    mvarEQStatus = clsEnumCtl.eEQStatus.EQ_IDLE
                Case "D"
                    mvarEQStatus = clsEnumCtl.eEQStatus.EQ_DOWN
                Case "S"
                    mvarEQStatus = clsEnumCtl.eEQStatus.EQ_SETUP
                Case "P"
                    mvarEQStatus = clsEnumCtl.eEQStatus.EQ_STOP
            End Select
        End Set
    End Property

    Public Property EQSubStatus() As clsEnumCtl.eEQSubStatus
        Get
            EQSubStatus = mvarEQSubStatus
        End Get
        Set(ByVal value As clsEnumCtl.eEQSubStatus)
            mvarEQSubStatus = value
        End Set
    End Property

    Public Property EQSubStatusByString() As String
        Get
            Select Case mvarEQSubStatus
                Case clsEnumCtl.eEQSubStatus.SUBSTATUS_WARNING
                    EQSubStatusByString = "W"
                Case Else
                    EQSubStatusByString = Space(1)
            End Select
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "W"
                    mvarEQSubStatus = clsEnumCtl.eEQSubStatus.SUBSTATUS_WARNING
                Case Else
                    mvarEQSubStatus = clsEnumCtl.eEQSubStatus.SUBSTATUS_NO
            End Select
        End Set
    End Property

    Public Property ProcessMode() As clsEnumCtl.ePorcessMode
        Get
            ProcessMode = mvarProcessMode
        End Get
        Set(ByVal value As clsEnumCtl.ePorcessMode)
            mvarProcessMode = value
        End Set
    End Property

    Public Property ProcessModeByString() As String
        Get
            Select Case mvarProcessMode
                Case clsEnumCtl.ePorcessMode.MODE_NORMAL
                    Return "N"
                Case clsEnumCtl.ePorcessMode.MODE_PASS
                    Return "P"
                Case Else
                    Return ""
            End Select
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "N"
                    mvarProcessMode = clsEnumCtl.ePorcessMode.MODE_NORMAL
                Case "P"
                    mvarProcessMode = clsEnumCtl.ePorcessMode.MODE_PASS

            End Select
        End Set
    End Property
    Public Property CPPID() As String
        Get
            CPPID = SpaceCTL(mvarCPPID, LEN_CPPID)
        End Get
        Set(ByVal value As String)
            mvarCPPID = SpaceCTL(value, LEN_CPPID)
        End Set
    End Property

    Public Property WIPCount() As Integer
        Get
            WIPCount = mvarWIPCount
        End Get
        Set(ByVal value As Integer)
            mvarWIPCount = value
        End Set
    End Property
End Class
