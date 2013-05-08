Imports System.Windows.Forms
Imports System.Drawing

Public Class RSTGUICtrlCV

    Enum eGUICVPortButton
        BUTTON_PortEnable = 1
        BUTTON_CVStatus = 2
        BUTTON_Tip = 3
        BUTTON_RunningMode = 4
        BUTTON_ProductCode = 5
        BUTTON_RecipeID = 6
        BUTTON_CSTID = 7
        BUTTON_GxQuantity = 8
        BUTTON_WireCST = 9
        BUTTON_WireBuffer = 10
        BUTTON_CV = 11
        BUTTON_NetH = 12
        BUTTON_Port = 13
        BUTTON_Pic = 14
    End Enum

    Private Const MAX_CST_SLOTS As Integer = 56
    Private Const MAX_BUFFER_SLOTS As Integer = 3

    Public Event CSTDummyCancelChange(ByVal fCancel As Boolean)
    'Public Event PortEnableChange(ByVal fChanged As Boolean)
    Public Event GUIMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, ByVal vLocation As Point)
    Public Event GUIMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, ByVal vLocation As Point)
    Public Event PortPauseRequest(ByVal sender As Object)
    Public Event PortReleaseRequest(ByVal sender As Object)

    Dim lMyWidth As Long
    Dim lMyHeight As Long
    Dim nMyMaxCSTSlots As Integer = MAX_CST_SLOTS
    Dim nMyMaxBufferSlots As Integer = MAX_BUFFER_SLOTS

    Dim fMyCSTWithGlass(MAX_CST_SLOTS) As Boolean

    Dim fMyBufferWithGlass(MAX_BUFFER_SLOTS) As Boolean

    Dim picWireCSTGraphics As Graphics
    Dim picWireBufferGraphics As Graphics
    'Set Property
    Private mvarCVCaption As String
    Private mvarNetHCaption As String
    Private mvarPortCaption As String
    Private mvarMaxCSTSlot As Integer
    Private mvarMaxBufferSlot As Integer
    Private mvarTip As String
    Private mvarCSTStatusCaption As String
    Private mvarCVStatusCaption As String
    Private mvarPortEnableCaption As Boolean
    Private mvarCSTDummyCancel As Boolean

    Private mvarCVWithBuffer As Boolean
    Public hr1(MAX_CST_SLOTS) As horizontalRule 'draw slot in cassette 'Microsoft.VisualBasic.PowerPacks.LineShape '

    Public Property CVCaption() As String
        Get
            CVCaption = mvarCVCaption
        End Get
        Set(ByVal value As String)
            Static DefString As String
            If DefString = "" Then DefString = Me.lblConveyorIndex.Text

            mvarCVCaption = value
            lblConveyorIndex.Text = DefString & " " & value
        End Set
    End Property

    Public Property NetHCaption() As String
        Get
            NetHCaption = mvarNetHCaption
        End Get
        Set(ByVal value As String)
            Static DefString As String
            If DefString = "" Then DefString = Me.lblNetHPortIndex.Text

            mvarNetHCaption = value
            Me.lblNetHPortIndex.Text = DefString & NetHCaption
        End Set
    End Property

    Public Property PortCaption() As String
        Get
            PortCaption = mvarPortCaption
        End Get
        Set(ByVal value As String)

            Static DefString As String
            If DefString = "" Then DefString = Me.lblPortIndex.Text

            mvarPortCaption = value
            Me.lblPortIndex.Text = DefString & value
        End Set
    End Property

    Public Property MaxCSTSlot() As Integer
        Get
            MaxCSTSlot = mvarMaxCSTSlot
        End Get
        Set(ByVal value As Integer)
            mvarMaxCSTSlot = value
            nMyMaxCSTSlots = mvarMaxCSTSlot
        End Set
    End Property

    Public Property MaxBufferSlot() As Integer
        Get
            MaxBufferSlot = mvarMaxBufferSlot
        End Get
        Set(ByVal value As Integer)
            mvarMaxBufferSlot = value
            nMyMaxBufferSlots = value
        End Set
    End Property

    Public Property CVBackColer() As System.Drawing.Color
        Get
            Return picContainer.BackColor
        End Get

        Set(ByVal value As System.Drawing.Color)
            picContainer.BackColor = value
            picWireBuffer.BackColor = value
            picWireCST.BackColor = value
            picParent.BackColor = value
            lblNetHPortIndex.BackColor = value
            lblPortIndex.BackColor = value
            chkDummyCanecl.BackColor = value
            lblConveyorIndex.BackColor = value

            lblLUTip.BackColor = value
            LabelCST.BackColor = value
            LabelProductCode.BackColor = value
            LabelPPID.BackColor = value
            LabelCSTID.BackColor = value
        End Set
    End Property

    Public Property TipCaption() As String
        Get
            TipCaption = mvarTip
        End Get
        Set(ByVal value As String)
            mvarTip = value
            Me.lblLUTip.Text = value
        End Set
    End Property

    Public Property CSTStatusCaption() As String
        Get
            CSTStatusCaption = mvarCSTStatusCaption
        End Get
        Set(ByVal value As String)
            mvarCSTStatusCaption = value
            Me.lblRunningMode.Text = value
        End Set
    End Property

    Public Property CVStatusCaption() As String
        Get
            CVStatusCaption = mvarCVStatusCaption
        End Get
        Set(ByVal value As String)
            mvarCVStatusCaption = value
            Me.lblCVStatus.Text = value
        End Set
    End Property

    Public Property PortEnableCaption() As Boolean
        Get
            PortEnableCaption = mvarPortEnableCaption
        End Get
        Set(ByVal value As Boolean)
            mvarPortEnableCaption = value
            If value = True Then
                Me.lblPortEnableStatus.Text = "Enable"
                Me.lblPortEnableStatus.BackColor = Color.Transparent
            Else
                Me.lblPortEnableStatus.Text = "Disable"
                Me.lblPortEnableStatus.BackColor = Color.Red
            End If
        End Set
    End Property

    Public Property CassetteID() As String
        Get
            Return lblCSTID.Text
        End Get
        Set(ByVal value As String)
            lblCSTID.Text = value
        End Set
    End Property

    Public Property RecipeID() As String
        Get
            Return lblRecipeID.Text
        End Get
        Set(ByVal value As String)
            lblRecipeID.Text = value
        End Set
    End Property

    Public Property ProductCode() As String
        Get
            Return lblProductCode.Text
        End Get
        Set(ByVal value As String)
            lblProductCode.Text = value
        End Set
    End Property

    Public Property FlowoutGlassID() As String
        Get
            Return LabelFlowoutGlassID.Text
        End Get
        Set(ByVal value As String)
            LabelFlowoutGlassID.Text = value
        End Set
    End Property

    '==================================== GUI Mouse UP/Down Event ========================================================================================== 

    Public Sub ButtonMouseUpDownAddHandle()


        AddHandler lblConveyorIndex.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblNetHPortIndex.MouseDown, AddressOf InSideFormMouseDown
        AddHandler picWireBuffer.MouseDown, AddressOf InSideFormMouseDown
        AddHandler picWireCST.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblPortIndex.MouseDown, AddressOf InSideFormMouseDown
        AddHandler picParent.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblCSTID.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblRecipeID.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblProductCode.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblRunningMode.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblCVStatus.MouseDown, AddressOf InSideFormMouseDown

        AddHandler lblConveyorIndex.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblNetHPortIndex.MouseUp, AddressOf InSideFormMouseUp
        AddHandler picWireBuffer.MouseUp, AddressOf InSideFormMouseUp
        AddHandler picWireCST.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblPortIndex.MouseUp, AddressOf InSideFormMouseUp
        AddHandler picParent.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblCSTID.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblRecipeID.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblProductCode.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblRunningMode.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblCVStatus.MouseUp, AddressOf InSideFormMouseUp
    End Sub

    Dim ControlsPosLocation As ArrayList
    Dim OldcontrolSize As ControlPL

    Private Sub RSTGUICtrlCV_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ReDrawCSTGlass()
    End Sub


    Private Sub RSTGUICtrlCV_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If OldcontrolSize.Size.Width = 0 OrElse OldcontrolSize.Size.Height = 0 Then
            Exit Sub
        End If

        Dim lx As Double = Me.Width / OldcontrolSize.Size.Width
        Dim ly As Double = Me.Height / OldcontrolSize.Size.Height

        picContainer.Width = Me.Width
        picContainer.Height = Me.Height

        For i As Integer = 0 To Me.Controls.Count - 1
            If Me.Controls(i).Name <> "picContainer" Then
                Me.Controls(i).Width = CInt(ControlsPosLocation(i).Size.width * lx)
                Me.Controls(i).Height = CInt(ControlsPosLocation(i).Size.Height * ly)
                Me.Controls(i).Left = CInt(ControlsPosLocation(i).Location.X * lx)
                Me.Controls(i).Top = CInt(ControlsPosLocation(i).Location.Y * ly)
                'If ControlsPosLocation(i).font IsNot Nothing Then
                '    'Dim OldFont As Font = DirectCast(ControlsPosLocation(i).font, Font)
                '    'Dim tmpfont As New Font(OldFont.Name, OldFont.Size * Math.Min(lx, ly), OldFont.Style, OldFont.Unit)
                '    'Me.Controls(i).Font = tmpfont
                'End If
            End If
        Next

    End Sub

    Public Sub InsertGlassToBuffer(ByVal nSlotNo As Integer)
        If nSlotNo > 0 And nSlotNo <= MaxBufferSlot Then
            fMyBufferWithGlass(nSlotNo) = True
            'DrawInsertGlass(picWireBuffer, picWireBufferGraphics, MaxBufferSlot, nSlotNo)
        End If
    End Sub

    Public Sub RemoveGlassFromBuffer(ByVal nSlotNo As Integer)
        On Error Resume Next
        If nSlotNo > 0 And nSlotNo <= MaxBufferSlot Then
            fMyBufferWithGlass(nSlotNo) = False
            'DrawRemoveGlass(picWireBuffer, picWireBufferGraphics, MaxBufferSlot, nSlotNo)
        End If
    End Sub

    Public Sub InsertGlassToCST(ByVal nSlotNo As Integer)
        On Error Resume Next
        If nSlotNo > 0 And nSlotNo <= MaxCSTSlot Then
            If Not fMyCSTWithGlass(nSlotNo) Then
                fMyCSTWithGlass(nSlotNo) = True
                If IsNumeric(lblGlassQuantity.Text) Then
                    lblGlassQuantity.Text = CInt(lblGlassQuantity.Text) + 1
                Else
                    lblGlassQuantity.Text = "1"
                End If
                ReDrawCSTGlass()
                DrawInsertGlass(picWireCST, MaxCSTSlot, nSlotNo)
            End If
        End If
    End Sub

    Public Sub RemoveGlassFromCST(ByVal nSlotNo As Integer)
        On Error Resume Next
        If nSlotNo > 0 And nSlotNo <= MaxCSTSlot Then
            If fMyCSTWithGlass(nSlotNo) Then
                fMyCSTWithGlass(nSlotNo) = False
                lblGlassQuantity.Text = CInt(lblGlassQuantity.Text) - 1
                If lblGlassQuantity.Text = "0" Then lblGlassQuantity.Text = ""
                'DrawRemoveGlass(picWireCST, MaxCSTSlot, nSlotNo)
                ReDrawCSTGlass()
            End If
        End If
    End Sub


    Private Sub DrawInsertGlass(ByRef picBox As System.Windows.Forms.PictureBox, ByVal nMaxSlots As Integer, ByVal nSlotNo As Integer)
        On Error Resume Next
        Dim nFor As Integer
        Dim nSlotHeight As Single
        Dim picBoxHeight As Integer = picBox.Height - 3

        nSlotHeight = CSng(picBoxHeight) / nMaxSlots

        If hr1(nSlotNo) Is Nothing Then
            'hr1(nSlotNo) = New Microsoft.VisualBasic.PowerPacks.LineShape 'New horizontalRule(picBox, 0, CInt(picBoxHeight - nSlotHeight * nSlotNo), picBox.Width, CInt(nSlotHeight) + 1)
            hr1(nSlotNo) = New horizontalRule(picBox, 0, CInt(picBoxHeight - nSlotHeight * nSlotNo), picBox.Width, CInt(nSlotHeight) + 1)
        Else
            hr1(nSlotNo).Redraw(0, CInt(picBoxHeight - nSlotHeight * nSlotNo), picBox.Width, CInt(nSlotHeight) + 1)
        End If
        'With hr1(nSlotNo)
        '    .X1 = picBox.Left
        '    .X2 = picBox.Width + picBox.Left
        '    .Y1 = CInt(picBoxHeight - nSlotHeight * nSlotNo) + picBox.Top
        '    .Y2 = CInt(picBoxHeight - nSlotHeight * nSlotNo) + CInt(nSlotHeight) + 1 + picBox.Top
        '    .BorderColor = Color.Black
        '    .BorderStyle = Drawing2D.DashStyle.Solid
        '    .BorderWidth = 1
        '    .Visible = True
        'End With
    End Sub

    Private Sub DrawRemoveGlass(ByRef picBox As System.Windows.Forms.PictureBox, ByVal nMaxSlots As Integer, ByVal nSlotNo As Integer)
        On Error Resume Next
        Dim nFor As Integer
        Dim nSlotHeight As Double
        Dim picBoxHeight As Integer = picBox.Height - 3

        nSlotHeight = CSng(picBoxHeight) / nMaxSlots

        If hr1(nSlotNo) Is Nothing Then
            hr1(nSlotNo) = New horizontalRule(picBox, 0, CInt(picBox.Height - nSlotHeight * nSlotNo), picBox.Width, CInt(nSlotHeight) + 1, False)
        Else
            hr1(nSlotNo).Redraw(0, CInt(picBoxHeight - nSlotHeight * nSlotNo), picBox.Width, CInt(nSlotHeight) + 1, False)
        End If

        'With hr1(nSlotNo)
        '    .X1 = picBox.Left
        '    .X2 = picBox.Width + picBox.Left
        '    .Y1 = CInt(picBoxHeight - nSlotHeight * nSlotNo) + picBox.Top
        '    .Y2 = CInt(picBoxHeight - nSlotHeight * nSlotNo) + CInt(nSlotHeight) + 1+ picBox.Top
        '    .Visible = False
        'End With
    End Sub


    Public Sub ResetBuffer()
        Dim nFor As Integer

        Me.picWireBuffer.BackColor = Me.picContainer.BackColor

        For nFor = 1 To MaxBufferSlot
            fMyBufferWithGlass(nFor) = False
        Next
    End Sub

    Delegate Sub ResetCSTDelegate()

    Public Sub ResetCST()
        Try

            If Not Me.InvokeRequired Then
                Dim nFor As Integer

                Me.picWireCST.BackColor = Me.picContainer.BackColor

                For nFor = 1 To MaxCSTSlot
                    fMyCSTWithGlass(nFor) = False
                Next

                lblGlassQuantity.Text = "0"
                lblCSTID.Text = ""
                lblRecipeID.Text = ""
                lblProductCode.Text = ""
                lblRunningMode.Text = ""
            Else
                Dim myResetCSTDelegate = New ResetCSTDelegate(AddressOf ResetCST)
                Me.Invoke(myResetCSTDelegate)
            End If
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try
    End Sub

    Private Sub chkDummyCanecl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDummyCanecl.CheckedChanged
        chkDummyCanecl.Enabled = Not chkDummyCanecl.Checked
        If chkDummyCanecl.Checked Then
            RaiseEvent CSTDummyCancelChange(chkDummyCanecl.Checked)
        End If
    End Sub

    Public Property CSTDummyCancel() As Boolean
        Get
            CSTDummyCancel = mvarCSTDummyCancel
        End Get

        Set(ByVal value As Boolean)
            mvarCSTDummyCancel = value
            chkDummyCanecl.Checked = value
        End Set
    End Property

    Private Sub InSideFormMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then RaiseEvent GUIMouseDown(Me, e, sender.location)
    End Sub

    Private Sub InSideFormMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then RaiseEvent GUIMouseUp(Me, e, sender.location)
    End Sub

    Public Class horizontalRule
        Inherits Control

        Dim penGray As New Pen(Color.FromKnownColor(System.Drawing.KnownColor.Green), 1)
        Dim penWhite As New Pen(Color.FromKnownColor(System.Drawing.KnownColor.Control), 1)
        Dim grfx As Graphics

        Public Sub New(ByVal vGrfx As System.Windows.Forms.PictureBox, ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Height As Single, Optional ByVal bDraw As Boolean = True)
            If Width < 0 Then
                Width = 0
            End If
            grfx = vGrfx.CreateGraphics
            penGray.Width = Height
            penWhite.Width = Height

            If bDraw Then
                grfx.DrawLine(penGray, x, y, x + Width, y)
            Else
                grfx.DrawLine(penWhite, x, y, x + Width, y)
            End If

        End Sub

        Public Sub Redraw(ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Height As Single, Optional ByVal bDraw As Boolean = True)
            If Width < 0 Then
                Width = 0
            End If

            penGray.Width = Height
            penWhite.Width = Height

            If bDraw Then
                grfx.DrawLine(penGray, x, y, x + Width, y)
            Else
                grfx.DrawLine(penWhite, x, y, x + Width, y)
            End If
        End Sub

    End Class

    Private Sub ButtonPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPause.Click
        'ButtonPause.Enabled = False
        'ButtonRelease.Enabled = False
        If MsgBox("Port Puase at Port#" & mvarPortCaption & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            RaiseEvent PortPauseRequest(Me)
        End If
    End Sub

    Private Sub ButtonRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRelease.Click
        'ButtonPause.Enabled = False
        'ButtonRelease.Enabled = False
        ButtonPause.BackColor = Color.Transparent
        RaiseEvent PortReleaseRequest(Me)
    End Sub

    Public Sub PortPause()
        'ButtonPause.Enabled = False
        'ButtonRelease.Enabled = False
        ButtonPause.BackColor = Color.Red
    End Sub

    Public Sub PortRelease()
        'ButtonPause.Enabled = False
        'ButtonRelease.Enabled = False
        ButtonPause.BackColor = Color.Transparent

    End Sub


    Public Sub ReDrawCSTGlass()
        Static fRunning As Boolean
        Static fCalled As Boolean

        If fRunning Then
            fCalled = True
            Exit Sub
        End If
        If picWireCST Is Nothing Then Exit Sub

        fRunning = True
        For i As Integer = 1 To MaxCSTSlot
            If fMyCSTWithGlass(i) Then
                DrawInsertGlass(picWireCST, MaxCSTSlot, i)
            Else
                DrawRemoveGlass(picWireCST, MaxCSTSlot, i)
            End If
        Next
        fRunning = False

        If fCalled Then
            fCalled = False
            ReDrawCSTGlass()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ReDrawCSTGlass()
    End Sub

End Class
