Public Class clsStateControl
    Private mvarPortNo As Integer
    Private mvarStateIndex As Integer
    Private mvarProcessTableIndex As Integer
    Private mvarProcessStepIndex As Integer
    Private mvarWait2NdMSG As Boolean
    Private mvarSuspend As Boolean
    Private mvarPrevTableIndex As Integer
    Private mvarPrevStepIndex As Integer
    Private mvarACKC7 As Integer
    Private mvarCMDA As Integer
    Private mvarGrantCode As Integer
    Private mvarRemoteCMD As String
    Private mvarPortDisabled As Boolean
    Private mvarCompelCMD As Boolean
    Private mvarProcessEND As Boolean
    Private mvarLoadState As Integer
    Private mvarCSTRunningOnLine As Boolean


    Public Property nPortNo() As Integer
        Get
            nPortNo = mvarPortNo
        End Get
        Set(ByVal value As Integer)
            mvarPortNo = value
        End Set
    End Property

    Public Property idxState() As Integer
        Get
            idxState = mvarStateIndex
        End Get
        Set(ByVal value As Integer)
            mvarStateIndex = value
        End Set
    End Property

    Public Property idxTable() As Integer
        Get
            idxTable = mvarProcessTableIndex
        End Get
        Set(ByVal value As Integer)
            mvarProcessTableIndex = value
        End Set
    End Property

    Public Property nCurrStep() As Integer

        Get
            nCurrStep = mvarProcessStepIndex
        End Get
        Set(ByVal value As Integer)
            Dim a As Boolean

            mvarProcessStepIndex = value
            If value = 8 Then
                a = True
            ElseIf value = 6 Then
                a = True
            End If
        End Set
    End Property

    Public Property fWait2NdMSG() As Boolean
        Get
            fWait2NdMSG = mvarWait2NdMSG
        End Get
        Set(ByVal value As Boolean)
            mvarWait2NdMSG = value
        End Set
    End Property

    Public Property fSuspend() As Boolean
        Get
            fSuspend = mvarSuspend
        End Get
        Set(ByVal value As Boolean)
            mvarSuspend = value
        End Set
    End Property

    Public Property idxPrevTable() As Integer
        Get
            idxPrevTable = mvarPrevTableIndex
        End Get
        Set(ByVal value As Integer)
            mvarPrevTableIndex = value
        End Set
    End Property

    Public Property nPrevStep() As Integer
        Get
            nPrevStep = mvarPrevStepIndex
        End Get
        Set(ByVal value As Integer)
            mvarPrevStepIndex = value
        End Set
    End Property

    Public Property nAckC7() As Integer
        Get
            nAckC7 = mvarACKC7
        End Get
        Set(ByVal value As Integer)
            mvarACKC7 = value
        End Set
    End Property

    Public Property nCMDA() As Integer
        Get
            nCMDA = mvarCMDA
        End Get
        Set(ByVal value As Integer)
            mvarCMDA = value
        End Set
    End Property

    Public Property nGrantCode() As Integer
        Get
            nGrantCode = mvarGrantCode
        End Get
        Set(ByVal value As Integer)
            mvarGrantCode = value
        End Set
    End Property

    Public Property strRemoteCommand() As String
        Get
            strRemoteCommand = mvarRemoteCMD
        End Get
        Set(ByVal value As String)
            mvarRemoteCMD = value
        End Set
    End Property

    Public Property fDisabledReported()
        Get
            fDisabledReported = mvarPortDisabled
        End Get
        Set(ByVal value)
            mvarPortDisabled = value
        End Set
    End Property

    Public Property fForceExecute() As Boolean
        Get
            fForceExecute = mvarCompelCMD
        End Get
        Set(ByVal value As Boolean)
            mvarCompelCMD = value
        End Set
    End Property

    Public Property fProcessEnd() As Boolean
        Get
            fProcessEnd = mvarProcessEND
        End Get
        Set(ByVal value As Boolean)
            mvarProcessEND = value
        End Set
    End Property

    Public Property nLoadState() As Integer
        Get
            nLoadState = mvarLoadState
        End Get
        Set(ByVal value As Integer)
            mvarLoadState = value
        End Set
    End Property

    Public Property fCSTRunningOnLine() As Boolean
        Get
            fCSTRunningOnLine = mvarCSTRunningOnLine
        End Get
        Set(ByVal value As Boolean)
            mvarCSTRunningOnLine = value
        End Set
    End Property

End Class
