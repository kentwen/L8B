Imports System.Drawing

Public Class RSTGUICtrlCV2L

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

    Private Const MAX_CST_SLOTS As Integer = 60
    Private Const MAX_BUFFER_SLOTS As Integer = 3

    Public Event CSTDummyCancelChange(ByVal fCancel As Boolean)
    Public Event PortEnableChange(ByVal fChanged As Boolean)
    'Public Event GUIMouseUp(ByVal nOCXIndex As eGUICVPortButton, ByVal nDelta As Integer, ByVal X As Single, ByVal Y As Single)
    'Public Event GUIMouseDown(ByVal nOCXIndex As eGUICVPortButton, ByVal Delta As Integer, ByVal X As Single, ByVal Y As Single)
    Public Event GUIMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, ByVal vLocation As Point)
    Public Event GUIMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, ByVal vLocation As Point)

    Dim lMyWidth As Long
    Dim lMyHeight As Long
    Dim nMyMaxCSTSlots As Integer = MAX_CST_SLOTS


    Dim fMyCSTWithGlass(MAX_CST_SLOTS) As Boolean



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

    Public Property CVCaption() As String

        Get
            CVCaption = mvarCVCaption
        End Get

        Set(ByVal value As String)
            Static DefString As String
            If DefString = "" Then DefString = Me.lblConveyorIndex.Text

            mvarCVCaption = value
            lblConveyorIndex.Text = DefString & value
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

 

    Public Property BackColer() As System.Drawing.Color
        Get

        End Get

        Set(ByVal value As System.Drawing.Color)

            Me.picContainer.BackColor = value

            Me.picWireCST.BackColor = value
            Me.picParent.BackColor = value

            Me.lblPortIndex.BackColor = value
            Me.chkDummyCanecl.BackColor = value
            Me.lblConveyorIndex.BackColor = value

            Me.lblLUTip.BackColor = value
            Me.Label3.BackColor = value

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
                Me.lblPortEnableStatus.Text = "E"
            Else
                Me.lblPortEnableStatus.Text = "D"
            End If
        End Set
    End Property

    Dim ControlsPosLocation As ArrayList
    Dim OldcontrolSize As ControlPL

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
            End If
        Next
    End Sub

    'Private Sub SetDefVal()
    '    Static fSetDef As Boolean
    '    If Not fSetDef Then
    '        fSetDef = True
    '        lMyWidth = picContainer.Width
    '        lMyHeight = picContainer.Height
    '    End If
    'End Sub


 

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
                DrawRemoveGlass(picWireCST, MaxCSTSlot, nSlotNo)
            End If
        End If
    End Sub


    Private Sub DrawInsertGlass(ByRef picBox As System.Windows.Forms.PictureBox, ByVal nMaxSlots As Integer, ByVal nSlotNo As Integer)
        On Error Resume Next
        Dim nFor As Integer
        Dim nSlotHeight As Integer
        Dim TempPic As Graphics = picBox.CreateGraphics


        nSlotNo = (nMaxSlots - nSlotNo) + 1
        nSlotHeight = (picBox.Height / nMaxSlots) '- IIf(nMaxSlots = MaxCSTSlot, 1, 10)

        For nFor = (nSlotNo - 1) * nSlotHeight To nSlotHeight * nSlotNo
            If picBox.Height - nFor >= 0 Then
                TempPic.DrawLine(Pens.Red, 0, picBox.Height - nFor, picBox.Width, picBox.Height - nFor)
            End If
        Next
    End Sub

    Private Sub DrawRemoveGlass(ByRef picBox As System.Windows.Forms.PictureBox, ByVal nMaxSlots As Integer, ByVal nSlotNo As Integer)
        On Error Resume Next
        Dim nFor As Integer
        Dim nSlotHeight As Integer
        Dim TempPic As Graphics = picBox.CreateGraphics

        nSlotNo = (nMaxSlots - nSlotNo) + 1
        nSlotHeight = picBox.Height / nMaxSlots '- IIf(nMaxSlots = MaxCSTSlot, 1, 10)

        For nFor = (nSlotNo - 1) * nSlotHeight To nSlotHeight * nSlotNo
            TempPic.DrawLine(Pens.Black, 0, picBox.Height - nFor, picBox.Width, picBox.Height - nFor)
        Next
    End Sub

    Public Sub ResetCST()
        Dim nFor As Integer

        Me.picWireCST.BackColor = Me.picContainer.BackColor

        For nFor = 1 To MaxCSTSlot
            fMyCSTWithGlass(nFor) = False
        Next

        Me.lblGlassQuantity.Text = "0"
        Me.lblCSTID.Text = ""
        Me.lblRecipeID.Text = ""
        Me.lblProductCode.Text = ""
        Me.lblRunningMode.Text = ""
    End Sub

    Private Sub chkDummyCanecl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDummyCanecl.CheckedChanged
        RaiseEvent CSTDummyCancelChange(chkDummyCanecl.Checked)
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


    Private Sub ButtonMouseUpDownAddHandle()
        AddHandler lblConveyorIndex.MouseDown, AddressOf InSideFormMouseDown

        AddHandler picWireCST.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblPortIndex.MouseDown, AddressOf InSideFormMouseDown
        AddHandler picParent.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblCSTID.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblRecipeID.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblProductCode.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblRunningMode.MouseDown, AddressOf InSideFormMouseDown
        AddHandler lblCVStatus.MouseDown, AddressOf InSideFormMouseDown


        AddHandler lblConveyorIndex.MouseUp, AddressOf InSideFormMouseUp
        AddHandler picWireCST.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblPortIndex.MouseUp, AddressOf InSideFormMouseUp
        AddHandler picParent.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblCSTID.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblRecipeID.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblProductCode.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblRunningMode.MouseUp, AddressOf InSideFormMouseUp
        AddHandler lblCVStatus.MouseUp, AddressOf InSideFormMouseUp
    End Sub

    Private Sub InSideFormMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RaiseEvent GUIMouseDown(Me, e, sender.location)
    End Sub

    Private Sub InSideFormMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RaiseEvent GUIMouseUp(Me, e, sender.location)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ButtonMouseUpDownAddHandle()
        ControlsPosLocation = New ArrayList
        Dim PosLocation As ControlPL

        For Each ctl As Object In Me.Controls
            PosLocation.Location = ctl.Location
            PosLocation.Size = ctl.size
            If ctl.Font IsNot Nothing Then
                PosLocation.Font = ctl.font
            Else
                PosLocation.Font = Nothing
            End If
            ControlsPosLocation.Add(PosLocation)
        Next

        OldcontrolSize.Size = Me.Size
        OldcontrolSize.Location = Me.Location
    End Sub

End Class
