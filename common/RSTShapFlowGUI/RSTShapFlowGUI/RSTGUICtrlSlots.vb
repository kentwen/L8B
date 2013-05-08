Imports System.Drawing

Public Class RSTGUICtrlSlots
    Public Event SlotMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)
    'Public Event SlotMouseDonw(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)

    Public Event SlotDestMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)
    'Public Event SlotDestMouseDonw(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)

    Public Event SlotMouseEnter(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)
    Public Event SlotMouseLeave(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)

    Public Event SlotLBLMouseUP(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)
    'Public Event SlotLBLMouseDonw(ByVal nSlot As Integer, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)

    Dim mvarSlotIndex As String
    Dim mvarMaxSlots As Integer
    Dim mvarMaxEQs As Integer
    Dim mvarSlotTitleStep As Integer
    Dim mvarSlotTitleWidth As Integer

    Dim mvarWithoutGxColor As System.Drawing.Color
    Dim mvarWithGxColor As System.Drawing.Color
    Dim mvarSlotIndexBackColor As System.Drawing.Color
    Dim mvarSetLblFont As System.Drawing.Font

    Dim mvarBufferID As String
    Dim mvarShowBufferID As Boolean

    Dim mvarSlotIndexWidth As Integer
    Dim mvarSloIndexStep As Integer
    Dim mvarSetSlotTitle As String

    Dim mvarGxID() As String
    Dim mvarGxIDShow As Boolean
    Dim mvarType() As eSlotType
    Dim mvarDest() As eBuffDestination
    Dim mvarWithGx() As Boolean
    Dim mvarEnabled() As Boolean
    Dim mvarDisabelRemark() As String

    Dim mvarProcessed() As Integer
    Dim mvarReviewed() As Boolean
    Dim mvarExtraData As Boolean
    Dim mvarfEQDoneShown As Boolean
    Dim mvarEQ1Done() As Boolean
    Dim mvarEQ2Done() As Boolean
    Dim mvarEQ3Done() As Boolean

    Dim MySlotIndexLabel() As Windows.Forms.Label
    Dim MySlotLabel() As Windows.Forms.Label
    Dim MySlotTypeLabel() As Windows.Forms.Label
    Dim MySlotDest() As Windows.Forms.Label

    Dim MylblEQ1Done() As Windows.Forms.Label
    Dim MylblEQ2Done() As Windows.Forms.Label
    Dim MylblEQ3Done() As Windows.Forms.Label

    Public Enum eSlotType
        [NA] = 0
        [OK] = 1
        [NG] = 2
        [GRAY] = 3
        [LD] = 4
        [INK] = 5
        [CASSETTE1] = 6
        [CASSETTE2] = 7
        [CASSETTE3] = 8
        [STDGLX_EQ1] = 9
        [STDGLX_EQ2] = 10
        [STDGLX_EQ3] = 11
    End Enum

    Public Enum eBuffDestination
        NA = 0
        PORT1 = 1
        PORT2 = 2
        PORT3 = 3
        EQ1 = 4
        EQ2 = 5
        EQ3 = 6
    End Enum

    Public Property MaxEQs() As Integer
        Get
            Return mvarMaxEQs
        End Get

        Set(ByVal value As Integer)
            mvarMaxEQs = value
            IniLabel(False)
        End Set
    End Property

    Public Property EQDone(ByVal mIndex As Integer, ByVal nSlot As Integer) As Boolean
        Get
            Select Case mIndex
                Case 1
                    Return mvarEQ1Done(nSlot)
                Case 2
                    Return mvarEQ2Done(nSlot)
                Case 3
                    Return mvarEQ3Done(nSlot)
            End Select
        End Get
        Set(ByVal value As Boolean)
            Select Case mIndex
                Case 1
                    mvarEQ1Done(nSlot) = value
                    With MylblEQ1Done(nSlot)
                        .Visible = value
                        If value Then
                            .ForeColor = Color.Black
                            .BackColor = Color.Yellow
                        Else
                            .ForeColor = Color.Gray
                            .BackColor = Color.Transparent
                        End If
                    End With

                Case 2
                    mvarEQ2Done(nSlot) = value
                    With MylblEQ2Done(nSlot)
                        .Visible = value
                        If value Then
                            .ForeColor = Color.Black
                            .BackColor = Color.LightBlue
                        Else
                            .ForeColor = Color.Gray
                            .BackColor = Color.Transparent
                        End If
                    End With
                Case 3
                    mvarEQ3Done(nSlot) = value
                    With MylblEQ3Done(nSlot)
                        .Visible = value
                        If value Then
                            .ForeColor = Color.Black
                            .BackColor = Color.LightPink
                        Else
                            .ForeColor = Color.Gray
                            .BackColor = Color.Transparent
                        End If
                    End With
            End Select
        End Set
    End Property

    Public Property MaxSlots() As Integer
        Get
            MaxSlots = mvarMaxSlots
        End Get

        Set(ByVal value As Integer)
            Dim nFor As Integer

            If value > mvarMaxSlots Then
                If value > mvarMaxSlots Then
                    ReDim Preserve mvarWithGx(value)
                    ReDim Preserve mvarGxID(value)
                    ReDim Preserve mvarType(value)
                    ReDim Preserve mvarProcessed(value)
                    ReDim Preserve mvarReviewed(value)
                    ReDim Preserve MySlotIndexLabel(value)
                    ReDim Preserve MySlotLabel(value)
                    ReDim Preserve MySlotTypeLabel(value)
                    ReDim Preserve MySlotDest(value)
                    ReDim Preserve mvarEnabled(value)
                    ReDim Preserve mvarDisabelRemark(value)

                    ReDim Preserve mvarEQ1Done(value)
                    ReDim Preserve mvarEQ2Done(value)
                    ReDim Preserve mvarEQ3Done(value)
                    ReDim Preserve MylblEQ1Done(value)
                    ReDim Preserve MylblEQ2Done(value)
                    ReDim Preserve MylblEQ3Done(value)

                    For nFor = mvarMaxSlots + 1 To value
                        MySlotLabel(nFor) = New Windows.Forms.Label
                        MySlotLabel(nFor).Name = "MySlotLabel" & "_" & Format(nFor, "0#")

                        MySlotIndexLabel(nFor) = New Windows.Forms.Label
                        MySlotIndexLabel(nFor).Name = "MySlotIndexLabel" & "_" & Format(nFor, "0#")

                        MySlotTypeLabel(nFor) = New Windows.Forms.Label
                        MySlotTypeLabel(nFor).Name = "MySlotTypeLabel" & "_" & Format(nFor, "0#")

                        MySlotDest(nFor) = New Windows.Forms.Label
                        MySlotDest(nFor).Name = "MySlotDest" & "_" & Format(nFor, "0#")

                        MylblEQ1Done(nFor) = New Windows.Forms.Label
                        MylblEQ1Done(nFor).Name = "lblEQ1Done" & "_" & Format(nFor, "0#")

                        MylblEQ2Done(nFor) = New Windows.Forms.Label
                        MylblEQ2Done(nFor).Name = "lblEQ2Done" & "_" & Format(nFor, "0#")

                        MylblEQ3Done(nFor) = New Windows.Forms.Label
                        MylblEQ3Done(nFor).Name = "lblEQ3Done" & "_" & Format(nFor, "0#")

                        Me.Controls.Add(MySlotLabel(nFor))
                        Me.Controls.Add(MySlotIndexLabel(nFor))
                        Me.Controls.Add(MySlotTypeLabel(nFor))
                        Me.Controls.Add(MySlotDest(nFor))
                        Me.Controls.Add(MylblEQ1Done(nFor))
                        Me.Controls.Add(MylblEQ2Done(nFor))
                        Me.Controls.Add(MylblEQ3Done(nFor))

                        AddHandler MySlotLabel(nFor).MouseEnter, AddressOf MySlotLabelMouseEnter
                        AddHandler MySlotLabel(nFor).MouseLeave, AddressOf MySlotLabelMouseLeave
                        AddHandler MySlotLabel(nFor).MouseUp, AddressOf MySlotLabelMouseUp
                        AddHandler MySlotTypeLabel(nFor).MouseUp, AddressOf MySlotTypeMouseUp
                        AddHandler MySlotDest(nFor).MouseUp, AddressOf MySlotDestMouseUp
                    Next
                ElseIf value < mvarMaxSlots Then
                    For nFor = value + 1 To mvarMaxSlots

                        MySlotLabel(nFor).Visible = False
                        MySlotIndexLabel(nFor).Visible = False
                        MySlotTypeLabel(nFor).Visible = False
                        MySlotDest(nFor).Visible = False
                        MylblEQ1Done(nFor).Visible = False
                        MylblEQ2Done(nFor).Visible = False
                        MylblEQ3Done(nFor).Visible = False

                        MySlotLabel(nFor).Dispose()
                        MySlotIndexLabel(nFor).Dispose()
                        MySlotTypeLabel(nFor).Dispose()
                        MySlotDest(nFor).Dispose()
                        MylblEQ1Done(nFor).Dispose()
                        MylblEQ2Done(nFor).Dispose()
                        MylblEQ3Done(nFor).Dispose()

                        MySlotLabel(nFor) = Nothing
                        MySlotIndexLabel(nFor) = Nothing
                        MySlotTypeLabel(nFor) = Nothing
                        MySlotDest(nFor) = Nothing
                        MylblEQ1Done(nFor) = Nothing
                        MylblEQ2Done(nFor) = Nothing
                        MylblEQ3Done(nFor) = Nothing

                        RemoveHandler MySlotLabel(nFor).MouseEnter, AddressOf MySlotLabelMouseEnter
                        RemoveHandler MySlotLabel(nFor).MouseLeave, AddressOf MySlotLabelMouseLeave
                        RemoveHandler MySlotLabel(nFor).MouseUp, AddressOf MySlotLabelMouseUp
                        RemoveHandler MySlotTypeLabel(nFor).MouseUp, AddressOf MySlotTypeMouseUp
                        RemoveHandler MySlotDest(nFor).MouseUp, AddressOf MySlotDestMouseUp

                        Me.Controls.Remove(MySlotLabel(nFor))
                        Me.Controls.Remove(MySlotIndexLabel(nFor))
                        Me.Controls.Remove(MySlotTypeLabel(nFor))
                        Me.Controls.Remove(MySlotDest(nFor))
                        Me.Controls.Remove(MylblEQ1Done(nFor))
                        Me.Controls.Remove(MylblEQ2Done(nFor))
                        Me.Controls.Remove(MylblEQ3Done(nFor))
                    Next
                End If
            End If
            mvarMaxSlots = value
            IniLabel()
        End Set
    End Property

    Public Sub IniLabel(Optional ByVal fChangeWidth As Boolean = True)
        Dim lHeight As Double
        Dim nFor As Integer
        Dim mIndicatorWidth As Integer = 12

        If mvarMaxSlots <= 0 Then Exit Sub

        If Me.ShowBufferID Then
            lHeight = (Height - lblBufferID.Height) / mvarMaxSlots
        Else
            lHeight = Height / mvarMaxSlots
        End If

        For nFor = 1 To mvarMaxSlots

            With MySlotIndexLabel(nFor)
                .Left = 0
                .Text = nFor
                .TextAlign = Drawing.ContentAlignment.MiddleRight
                If fChangeWidth Then .Width = 17
                If nFor = 1 Then
                    .Top = Height - lHeight - Me.lblBufferID.Height
                Else
                    .Top = lHeight * (mvarMaxSlots - nFor)  'MySlotLabel(nFor - 1).Top - lHeight
                End If
                .Height = lHeight
                .Visible = True
            End With

            'SlotType(nFor) = SlotType(nFor)
            With MySlotLabel(nFor)
                If mvarExtraData Then
                    .BackColor = Me.WithoutGxColor
                Else
                    If mvarGxID(nFor) Is Nothing OrElse mvarGxID(nFor).Length = 0 Then
                        .BackColor = Color.Transparent
                    Else
                        .BackColor = MySlotTypeLabel(nFor).BackColor
                    End If
                End If
                .Visible = True
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .TextAlign = Drawing.ContentAlignment.MiddleRight
                If fChangeWidth Then
                    If mvarExtraData Then
                        .Width = Me.Width - 17 - mIndicatorWidth * 2 - 3
                    Else
                        .Width = Me.Width - 17 - 3
                    End If
                End If                
                .Left = MySlotIndexLabel(nFor).Left + MySlotIndexLabel(nFor).Width + 1
                .Top = MySlotIndexLabel(nFor).Top
                .Height = lHeight
                If mvarGxIDShow Then
                    .Text = mvarGxID(nFor)
                Else
                    .Text = nFor & "TOP=" & .Top
                End If
            End With

            With MySlotTypeLabel(nFor)
                .Visible = mvarExtraData
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .TextAlign = Drawing.ContentAlignment.MiddleCenter
                If fChangeWidth Then .Width = mIndicatorWidth
                .Left = MySlotLabel(nFor).Left + MySlotLabel(nFor).Width + 1
                .Height = lHeight
                .Top = MySlotLabel(nFor).Top
            End With

            With MySlotDest(nFor)
                .Visible = mvarExtraData
                .Left = MySlotTypeLabel(nFor).Left + MySlotTypeLabel(nFor).Width + 1
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .TextAlign = Drawing.ContentAlignment.MiddleCenter
                If fChangeWidth Then .Width = mIndicatorWidth
                .Height = lHeight
                .Top = MySlotLabel(nFor).Top
            End With


            Dim FontNormal As New Font(MylblEQ1Done(nFor).Font.FontFamily, 7, FontStyle.Regular) 'MylblEQ1Done(nFor).Font.Size
            With MylblEQ1Done(nFor)
                .Visible = mvarfEQDoneShown
                .Left = MySlotLabel(nFor).Left + 2
                .Top = MySlotLabel(nFor).Top + MySlotLabel(nFor).Height - 18
                .Text = "1"
                .BringToFront()
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .AutoSize = True
                .Font = FontNormal
                .TextAlign = Drawing.ContentAlignment.MiddleCenter
                EQDone(1, nFor) = mvarEQ1Done(nFor)
            End With

            With MylblEQ2Done(nFor)
                .Visible = mvarfEQDoneShown
                If MaxEQs < 2 Then
                    .Visible = False
                End If
                .Left = MylblEQ1Done(nFor).Left + MylblEQ1Done(nFor).Width
                .Top = MySlotLabel(nFor).Top + MySlotLabel(nFor).Height - 18
                .Text = "2"
                .BringToFront()
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .AutoSize = True
                .Font = FontNormal
                .TextAlign = Drawing.ContentAlignment.MiddleCenter
                EQDone(2, nFor) = mvarEQ2Done(nFor)
            End With

            With MylblEQ3Done(nFor)
                .Visible = mvarfEQDoneShown
                If MaxEQs < 3 Then
                    .Visible = False
                End If
                .Left = MylblEQ2Done(nFor).Left + MylblEQ2Done(nFor).Width
                .Top = MySlotLabel(nFor).Top + MySlotLabel(nFor).Height - 18
                .Text = "3"
                .BringToFront()
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .AutoSize = True
                .Font = FontNormal
                .TextAlign = Drawing.ContentAlignment.MiddleCenter
                EQDone(3, nFor) = mvarEQ3Done(nFor)
            End With

        Next

        With Me.lblBufferID
            If fChangeWidth Then .Width = MySlotLabel(mvarMaxSlots).Width
            .Left = MySlotLabel(mvarMaxSlots).Left
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
            .Top = Height - .Height
            .AutoSize = False
        End With

        WriteSlotTitle()
    End Sub

    Public Sub Reset()
        Dim nFor As Integer

        For nFor = 0 To mvarMaxSlots
            mvarWithGx(nFor) = False
            MySlotLabel(nFor).BackColor = WithoutGxColor
        Next
    End Sub

    Public Property WithGx(ByVal nSlot As Integer) As Boolean
        Get
            If nSlot <= mvarMaxSlots And nSlot > 0 Then
                WithGx = mvarWithGx(nSlot)
            End If
        End Get
        Set(ByVal value As Boolean)
            If nSlot <= mvarMaxSlots And nSlot > 0 Then
                mvarWithGx(nSlot) = value
                If GxIDShow Then
                    If Len(GxID(nSlot)) > 0 Then
                        MySlotLabel(nSlot).Text = GxID(nSlot) '"[" & GxID(nSlot) & "] / " & mvarType(nSlot).ToString
                    Else
                        MySlotLabel(nSlot).Text = "" '"[]" & " / " & mvarType(nSlot).ToString
                    End If
                Else
                    MySlotLabel(nSlot).Text = "" '"[]" & " / " & mvarType(nSlot).ToString
                End If

                If mvarExtraData Then
                    MySlotLabel(nSlot).BackColor = IIf(value, WithGxColor, WithoutGxColor)
                End If
            End If
        End Set
    End Property

    Public Property GxExtraDataShow() As Boolean
        Get
            Return mvarExtraData
        End Get
        Set(ByVal value As Boolean)
            mvarExtraData = value
            IniLabel(True)
        End Set
    End Property


    Public Property GxEQDoneShow() As Boolean
        Get
            Return mvarfEQDoneShown
        End Get
        Set(ByVal value As Boolean)
            mvarfEQDoneShown = value
            IniLabel(False)
        End Set
    End Property

    Public Property GxIDShow() As Boolean
        Get
            GxIDShow = mvarGxIDShow
        End Get
        Set(ByVal value As Boolean)
            Dim nFor As Integer

            mvarGxIDShow = value
            For nFor = 1 To mvarMaxSlots
                If value Then
                    MySlotLabel(nFor).Text = GxID(nFor) ' "[" & GxID(nFor) & "] / " & mvarType(nFor).ToString
                Else
                    MySlotLabel(nFor).Text = "" '"[]" & " / " & mvarType(nFor).ToString
                End If
            Next

        End Set
    End Property

    Public Property GxID(ByVal nSlot As Integer) As String
        Get
            If nSlot <= mvarMaxSlots And nSlot > 0 Then
                GxID = mvarGxID(nSlot)
            Else
                GxID = ""
            End If
        End Get

        Set(ByVal value As String)
            If nSlot <= mvarMaxSlots And nSlot > 0 Then
                mvarGxID(nSlot) = value
            End If

            MySlotLabel(nSlot).Text = mvarGxID(nSlot)

            If Not mvarExtraData Then
                MySlotLabel(nSlot).BackColor = MySlotTypeLabel(nSlot).BackColor
            End If
        End Set
    End Property

    '20110107
    Public Property Processed(ByVal nSlot As Integer) As Integer
        Get
            Return mvarProcessed(nSlot)
        End Get
        Set(ByVal value As Integer)
            mvarProcessed(nSlot) = value
            With MySlotLabel(nSlot)

                Select Case value
                    Case 1          'EQ1
                        .ForeColor = Color.Black
                        .BackColor = Color.Yellow
                        'EQDone(1, nSlot) = True
                        'EQDone(2, nSlot) = False
                        'EQDone(3, nSlot) = False

                    Case 2          'EQ2
                        .ForeColor = Color.Black
                        .BackColor = Color.LightBlue
                        'EQDone(1, nSlot) = False
                        'EQDone(2, nSlot) = True
                        'EQDone(3, nSlot) = False

                    Case 4          'EQ3
                        .ForeColor = Color.Black
                        .BackColor = Color.LightPink
                        'EQDone(1, nSlot) = False
                        'EQDone(2, nSlot) = False
                        'EQDone(3, nSlot) = True

                    Case (1 + 2)    'EQ1 + EQ2
                        .ForeColor = Color.Blue
                        .BackColor = Color.Yellow
                        'EQDone(1, nSlot) = True
                        'EQDone(2, nSlot) = True
                        'EQDone(3, nSlot) = False

                    Case (1 + 4)    'EQ1 + EQ3
                        .ForeColor = Color.Red
                        .BackColor = Color.Yellow
                        'EQDone(1, nSlot) = True
                        'EQDone(2, nSlot) = False
                        'EQDone(3, nSlot) = True

                    Case (2 + 4)    'EQ2 + EQ3
                        .ForeColor = Color.Red
                        .BackColor = Color.LightBlue
                        'EQDone(1, nSlot) = False
                        'EQDone(2, nSlot) = True
                        'EQDone(3, nSlot) = True

                    Case (1 + 2 + 4) 'EQ1 + EQ2 + EQ3
                        .ForeColor = Color.DarkCyan
                        .BackColor = Color.Brown
                        'EQDone(1, nSlot) = True
                        'EQDone(2, nSlot) = True
                        'EQDone(3, nSlot) = True

                    Case Else       'NA
                        .ForeColor = Color.Black
                        .BackColor = IIf(mvarWithGx(nSlot), WithGxColor, WithoutGxColor)
                        'EQDone(1, nSlot) = False
                        'EQDone(2, nSlot) = False
                        'EQDone(3, nSlot) = False
                End Select
            End With

        End Set
    End Property


    Public Property Reviewed(ByVal nSlot As Integer) As Boolean
        Get
            Return mvarReviewed(nSlot)
        End Get
        Set(ByVal value As Boolean)
            mvarReviewed(nSlot) = value

            Dim FontBold As New Font(MySlotLabel(nSlot).Font.FontFamily, MySlotLabel(nSlot).Font.Size, FontStyle.Bold)
            Dim FontNormal As New Font(MySlotLabel(nSlot).Font.FontFamily, MySlotLabel(nSlot).Font.Size, FontStyle.Regular)

            With MySlotLabel(nSlot)
                If value Then
                    .Font = FontBold
                Else
                    .Font = FontNormal
                End If
            End With

        End Set
    End Property

    Public Property SlotEnabled(ByVal nSlot As Integer) As Boolean
        Get
            Return mvarEnabled(nSlot)
        End Get
        Set(ByVal value As Boolean)
            mvarEnabled(nSlot) = value
            MySlotIndexLabel(nSlot).Enabled = value
            MySlotTypeLabel(nSlot).Enabled = value
            MySlotDest(nSlot).Enabled = value

            If value Then
                mvarDisabelRemark(nSlot) = ""
            End If
        End Set
    End Property


    Public Property SlotDisableRemark(ByVal nSlot As Integer) As String
        Get
            Try
                Return mvarDisabelRemark(nSlot)
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal value As String)
            If nSlot <= mvarDisabelRemark.GetUpperBound(0) Then
                mvarDisabelRemark(nSlot) = value
            End If
        End Set
    End Property

    Public Property WithoutGxColor() As System.Drawing.Color
        Get
            WithoutGxColor = mvarWithoutGxColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarWithoutGxColor = value
            For i As Integer = 1 To MaxSlots
                If Not mvarWithGx(i) Then
                    MySlotLabel(i).BackColor = value
                End If
            Next
        End Set
    End Property

    Public Property WithGxColor() As System.Drawing.Color
        Get
            WithGxColor = mvarWithGxColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarWithGxColor = value
            For i As Integer = 1 To MaxSlots
                If mvarWithGx(i) Then
                    MySlotLabel(i).BackColor = value
                End If
            Next
        End Set
    End Property

    Public Property SlotIndexBackColor() As System.Drawing.Color
        Get
            SlotIndexBackColor = mvarSlotIndexBackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSlotIndexBackColor = value
            For i As Integer = 1 To MaxSlots
                MySlotIndexLabel(i).BackColor = value
            Next
        End Set
    End Property

    Public Property BufferID() As String
        Get
            BufferID = mvarBufferID
        End Get
        Set(ByVal value As String)
            mvarBufferID = value
            Me.lblBufferID.Text = "Buffer " & value
        End Set
    End Property

    Public Property ShowBufferID() As Boolean
        Get
            ShowBufferID = mvarShowBufferID
        End Get
        Set(ByVal value As Boolean)
            mvarShowBufferID = value
        End Set
    End Property

    Public Property SetLblFont() As System.Drawing.Font
        Get
            SetLblFont = mvarSetLblFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            Dim nFor As Integer
            mvarSetLblFont = value
            For nFor = 1 To mvarMaxSlots
                MySlotLabel(nFor).Font = value
                'MySlotIndexLabel(nFor).Font = value
            Next
            lblBufferID.Font = value
        End Set
    End Property

    Public Property SetSlotTitle() As String
        Get
            SetSlotTitle = mvarSetSlotTitle
        End Get
        Set(ByVal value As String)
            mvarSetSlotTitle = value
        End Set
    End Property

    Public Property SloIndexStep() As Integer
        Get
            SloIndexStep = mvarSloIndexStep
        End Get
        Set(ByVal value As Integer)
            mvarSloIndexStep = value
            ControlTitelStep()
        End Set
    End Property

    Public Property SlotIndexWidth() As Integer
        Get
            SlotIndexWidth = mvarSlotIndexWidth
        End Get
        Set(ByVal value As Integer)
            mvarSlotIndexWidth = value
        End Set
    End Property

    Private Sub ReleaseSlots(ByVal nSlots As Integer)
        Dim nFor As Integer
        For nFor = 1 To nSlots
            Me.Controls.Remove(MySlotLabel(nFor))
            Me.Controls.Remove(MySlotIndexLabel(nFor))
        Next
    End Sub

    Private Sub WriteSlotTitle()
        Dim nFor As Integer
        If Len(SetSlotTitle) > 0 Then
            For nFor = 1 To mvarMaxSlots
                MySlotIndexLabel(nFor).Text = CStr(Format(nFor, mvarSetSlotTitle))
                MySlotIndexLabel(nFor).AutoSize = True
            Next
        End If
    End Sub

    Private Sub ControlTitelStep()
        Dim nFor As Integer

        For nFor = 1 To mvarMaxSlots
            MySlotIndexLabel(nFor).Visible = False
        Next

        For nFor = mvarMaxSlots To 1 Step -SloIndexStep
            MySlotIndexLabel(nFor).Visible = True
        Next
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mvarMaxSlots = 0
        mvarSlotIndexWidth = Me.lblSlotIndex.Width
        mvarSloIndexStep = 1
        mvarExtraData = True
        ShowBufferID = True

    End Sub

    Private Sub RSTGUICtrlSlots_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        IniLabel()
    End Sub


    Private Sub MySlotTypeMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim mName() As String = sender.name.split("_")
        If mName.Length > 1 Then
            RaiseEvent SlotMouseUP(Val(mName(1)), 0, sender.left + e.X, sender.top + e.Y)
        End If
    End Sub



    Private Sub MySlotLabelMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim mName() As String = sender.name.split("_")
        If mName.Length > 1 Then
            RaiseEvent SlotLBLMouseUP(Val(mName(1)), 0, sender.left + e.X, sender.top + e.Y)
        End If
    End Sub


    Private Sub MySlotDestMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim mName() As String = sender.name.split("_")
        If mName.Length > 1 Then
            RaiseEvent SlotDestMouseUP(Val(mName(1)), 0, sender.left + e.X, sender.top + e.Y)
        End If
    End Sub

    Public Property SlotType(ByVal nSlot As Integer) As eSlotType
        Get
            If nSlot <= mvarMaxSlots And nSlot > 0 Then
                Return mvarType(nSlot)
            Else
                Return eSlotType.NA
            End If
        End Get

        Set(ByVal value As eSlotType)
            If nSlot <= mvarMaxSlots And nSlot > 0 Then
                Dim mColor As System.Drawing.Color
                Dim mText As String = ""
                mvarType(nSlot) = value

                Select Case value
                    Case eSlotType.GRAY
                        mColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
                        mText = "G"

                    Case eSlotType.LD
                        mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
                        mText = "L"

                    Case eSlotType.NG
                        mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
                        mText = "N"

                    Case eSlotType.OK
                        mColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
                        mText = "O"

                    Case eSlotType.INK
                        mColor = Color.LightBlue
                        mText = "I"

                    Case eSlotType.CASSETTE1
                        mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
                        mText = "1"

                    Case eSlotType.CASSETTE2
                        mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
                        mText = "2"

                    Case eSlotType.CASSETTE3
                        mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
                        mText = "3"

                    Case eSlotType.STDGLX_EQ1
                        mColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
                        mText = "1"

                    Case eSlotType.STDGLX_EQ2
                        mColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
                        mText = "2"

                    Case eSlotType.STDGLX_EQ3
                        mColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
                        mText = "3"

                    Case Else
                        mColor = Drawing.Color.Transparent
                        mText = ""
                End Select
                MySlotTypeLabel(nSlot).BackColor = mColor
                MySlotTypeLabel(nSlot).Text = mText
            End If
        End Set
    End Property

    Public Property SlotDest(ByVal nSlot As Integer) As eBuffDestination
        Get
            Return (mvarDest(nSlot))
        End Get
        Set(ByVal value As eBuffDestination)
            Dim mColor As System.Drawing.Color
            Dim mText As String
            'mvarDest(nSlot) = value

            Select Case value
                Case eBuffDestination.EQ1
                    mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
                    mText = "1"

                Case eBuffDestination.EQ2
                    mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
                    mText = "2"

                Case eBuffDestination.EQ3
                    mColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
                    mText = "3"

                Case eBuffDestination.PORT1
                    mColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
                    mText = "1"

                Case eBuffDestination.PORT2
                    mColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
                    mText = "2"

                Case eBuffDestination.PORT3
                    mColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
                    mText = "3"
                Case Else

                    mColor = Drawing.Color.Transparent
                    mText = ""
            End Select

            MySlotDest(nSlot).BackColor = mColor
            MySlotDest(nSlot).Text = mText
        End Set
    End Property

    Private Sub MySlotLabelMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mName() As String = sender.name.split("_")
        If mName.Length > 1 Then
            RaiseEvent SlotMouseEnter(Val(mName(1)), 0, sender.left + MousePosition.X, sender.top + MousePosition.Y)
            If mvarEnabled(Val(mName(1))) Then
                ToolTip.Hide(sender)
            Else
                If Trim(mvarDisabelRemark(Val(mName(1)))) <> "" Then
                    ToolTip.Show("Slot Disable Reason:" & vbCrLf & mvarDisabelRemark(Val(mName(1))), sender)
                End If
            End If
        End If
    End Sub

    Private Sub MySlotLabelMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mName() As String = sender.name.split("_")
        If mName.Length > 1 Then
            ToolTip.Hide(sender)
            RaiseEvent SlotMouseLeave(Val(mName(1)), 0, sender.left + MousePosition.X, sender.top + MousePosition.Y)
        End If
    End Sub

End Class
