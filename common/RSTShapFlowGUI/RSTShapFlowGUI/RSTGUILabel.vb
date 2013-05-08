Imports system.Drawing.Font

Public Class RSTGUILabel
    Public Enum eDisplayMode
        TYPE_TEXT
        TYPE_TIME
        TYPE_TIME_SEC
        TYPE_DATE
        TYPE_DATETIME
        TYPE_DATETIME_SEC
    End Enum

    Dim MyDisplayMode As eDisplayMode
    Dim mvarShowOuterFrame As Boolean
    Dim mvarOuterFrameColer As System.Drawing.Color
    Dim mvarInterFrameColer As System.Drawing.Color
    Dim mvarFontColor As System.Drawing.Color
    Dim mvarFontInfo As System.Drawing.Font
    Dim mvarEnableTimer As Boolean
    Dim mvarSetCaption As String

    Public Property ShowOuterFrame() As Boolean
        Get
            ShowOuterFrame = mvarShowOuterFrame
        End Get

        Set(ByVal value As Boolean)
            mvarShowOuterFrame = value
            Me.cmdOuterframe.Visible = value
        End Set
    End Property

    Public Property ChangeDisplayMode() As eDisplayMode
        Get
            ChangeDisplayMode = Me.MyDisplayMode

        End Get
        Set(ByVal value As eDisplayMode)
            MyDisplayMode = value
            DisplayModeChange()
        End Set
    End Property

    Public Property OuterFrameColer() As System.Drawing.Color
        Get
            OuterFrameColer = mvarOuterFrameColer
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarOuterFrameColer = value
            Me.cmdOuterframe.BackColor = value

        End Set
    End Property

    Public Property InterFrameColer() As System.Drawing.Color
        Get
            InterFrameColer = mvarInterFrameColer
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarInterFrameColer = value
            Me.cmdFrameInter.BackColor = value

        End Set
    End Property

    Public Property FontInfo() As System.Drawing.Font
        Get
            FontInfo = mvarFontInfo
        End Get
        Set(ByVal value As System.Drawing.Font)
            mvarFontInfo = value
            Me.cmdFrameInter.Font = value
        End Set
    End Property

    Public Property FontColor() As System.Drawing.Color
        Get
            FontColor = mvarFontColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarFontColor = value
            Me.cmdFrameInter.ForeColor = value
        End Set
    End Property

    Public Property EnableTimer() As Boolean
        Get
            EnableTimer = mvarEnableTimer
        End Get
        Set(ByVal value As Boolean)
            mvarEnableTimer = value
            If value = True And Me.MyDisplayMode <> eDisplayMode.TYPE_TEXT Then
                Me.tmrNow.Enabled = True
            Else
                Me.tmrNow.Enabled = False
            End If
        End Set
    End Property

    Public Property SetCaption() As String
        Get
            SetCaption = mvarSetCaption
        End Get
        Set(ByVal value As String)
            mvarSetCaption = value
            If Me.MyDisplayMode = eDisplayMode.TYPE_TEXT Then
                Me.cmdFrameInter.Text = value
            End If
        End Set
    End Property

    Private Sub DisplayModeChange()
        Select Case Me.MyDisplayMode
            Case eDisplayMode.TYPE_DATE, eDisplayMode.TYPE_DATETIME, eDisplayMode.TYPE_TIME
                tmrNow.Interval = 1000
                If Me.EnableTimer Then Me.tmrNow.Enabled = True
            Case eDisplayMode.TYPE_DATETIME_SEC, eDisplayMode.TYPE_TIME_SEC
                tmrNow.Interval = 10
                If Me.EnableTimer Then Me.tmrNow.Enabled = True

            Case eDisplayMode.TYPE_TEXT
                Me.tmrNow.Enabled = False
                Me.cmdFrameInter.Text = Me.SetCaption
        End Select
    End Sub

    Private Sub tmrNow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrNow.Tick
        Static fTickRun As Boolean

        tmrNow.Enabled = False

        If fTickRun Then
            If Me.EnableTimer Then tmrNow.Enabled = True
            Exit Sub
        Else
            fTickRun = True
        End If

        With Me.cmdFrameInter
            Select Case Me.MyDisplayMode
                Case eDisplayMode.TYPE_DATE
                    .Text = Format(Now, "yyyy-MM-dd")
                Case eDisplayMode.TYPE_DATETIME
                    .Text = Format(Now, "yyyy-MM-dd hh : mm : ss")
                Case eDisplayMode.TYPE_DATETIME_SEC
                    .Text = Format(Now, "yyyy-MM-dd hh : mm : ss") & "." & Microsoft.VisualBasic.Right(Format(Timer, "#0.00"), 2)
                Case eDisplayMode.TYPE_TIME
                    .Text = Format(Now, "hh : mm : ss")
                Case eDisplayMode.TYPE_TIME_SEC
                    .Text = Format(Now, "hh : mm : ss") & "." & Microsoft.VisualBasic.Right(Format(Timer, "#0.00"), 2)
            End Select
        End With

        fTickRun = False
        If EnableTimer Then tmrNow.Enabled = True
    End Sub

    Private Sub RSTGUILabel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With Me.cmdOuterframe
            .Left = 4
            .Top = 4
            .Height = Me.Height - 8
            .Width = Me.Width - 8
        End With
        'cmdOuterframe.BringToFront()

        With Me.cmdFrameInter
            .Left = 20
            .Top = 20
            .Width = Me.Width - 40
            .Height = Me.Height - 40
        End With
        'cmdFrameInter.BringToFront()
    End Sub

End Class
