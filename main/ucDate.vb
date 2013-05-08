Imports System.Threading

Public Class ucDate
    Dim DateThread As Thread
    Delegate Sub DelegateSetDateLable(ByVal [TEXT] As String)

    'Public Enum ShowType
    '    _Date
    '    _Time
    'End Enum

    'Private mDisplayType As ShowType
    Private bThreadRun As Boolean

    'Public Property DisplayType() As ShowType
    '    Get
    '        Return mDisplayType
    '    End Get
    '    Set(ByVal value As ShowType)
    '        mDisplayType = value
    '        bThreadRun = True
    '        If DateThread Is Nothing OrElse Not DateThread.IsAlive Then
    '            Start()
    '        End If
    '    End Set
    'End Property

    'Public Property ThreadRun() As Boolean
    '    Get
    '        Return bThreadRun
    '    End Get
    '    Set(ByVal value As Boolean)
    '        bThreadRun = value
    '        If Not value Then
    '            SetClock("Stop")
    '        End If
    '    End Set
    'End Property

    'Public Property Caption() As String
    '    Get
    '        Return LabelDate.Text
    '    End Get
    '    Set(ByVal value As String)
    '        LabelDate.Text = value
    '    End Set
    'End Property

    Public Sub ContentUpdate()
        'Select Case DisplayType
        '    Case ShowType._Date
        '        SetClock(Format(Now, "yyyy - MM - dd"))
        '    Case ShowType._Time
        '        SetClock(Format(Now, "HH : mm : ss"))
        'End Select

        SetClock(String.Format("{0:yyyy - MM - dd}" & vbCrLf & "{1:HH : mm : ss}", Now, Now))

    End Sub

    Public Sub Start()
        bThreadRun = True
        'If mDisplayType = ShowType._Date Then
        '    SetClock(Format(Now, "yyyy - MM - dd ."))
        'End If
        DateThread = New Thread(AddressOf Me.StartDateThread)
        DateThread.Start()
    End Sub

    Private Sub StartDateThread()
        While bThreadRun
            'Select Case DisplayType
            '    Case ShowType._Date
            '        SetClock(Format(Now, "yyyy - MM - dd"))
            '        'Thread.Sleep((60 - Now.Second) * 1000)
            '        Thread.Sleep((1000 - Now.Millisecond) - 1)

            '    Case ShowType._Time
            '        SetClock(Format(Now, "HH : mm : ss"))
            '        Thread.Sleep((1000 - Now.Millisecond) - 1)
            'End Select

            ContentUpdate()
            Thread.Sleep(Math.Abs(((1000 - Now.Millisecond) - 5)))
        End While
    End Sub

    Private Sub SetClock(ByVal [TEXT] As String)
        If LabelDate.Disposing OrElse LabelDate.IsDisposed OrElse Me.Disposing OrElse Me.IsDisposed Then
            bThreadRun = False
            Exit Sub
        End If

        If LabelDate.InvokeRequired Then
            Dim SetClockLable = New DelegateSetDateLable(AddressOf SetClock)
            LabelDate.BeginInvoke(SetClockLable, New Object() {[TEXT]})
            Exit Sub
        End If

        LabelDate.Text = [TEXT]
    End Sub

    Private Sub ucDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Start()
    End Sub

    Private Sub UCDate_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SizeSet()
    End Sub

    '沒用 20080603
    'Private Sub LabelDate_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelDate.Disposed
    '    If DateThread IsNot Nothing AndAlso DateThread.IsAlive Then
    '        DateThread.Abort()
    '        DateThread.Join()
    '    End If
    'End Sub

    Private Sub UCDate_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        SizeSet()
    End Sub


    Private Sub SizeSet()
        Button.Left = 0
        Button.Top = 0
        Button.Width = Me.Width
        Button.Height = Me.Height
        LabelDate.Left = Button.Left + 5
        LabelDate.Top = Button.Top + 5

        LabelDate.Width = Me.Width - 10
        LabelDate.Height = Me.Height - 10
    End Sub


End Class
