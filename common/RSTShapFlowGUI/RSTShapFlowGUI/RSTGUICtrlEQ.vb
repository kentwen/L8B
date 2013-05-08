Imports system.Drawing.Font

Public Class RSTGUICtrlEQ
    Public Event GUIMouseUp(ByVal ocxName As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
    Public Event GUIMouseDown(ByVal ocxName As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)

    Dim lMyWidth As Long
    Dim lMyHeight As Long

    Dim fConnect As Boolean
    Dim fWithGx As Boolean
    Dim wGlassColor As System.Drawing.Color
    Dim woGlassColor As System.Drawing.Color

    Private mvarEQRunningMode As String
    Public Property EQRunningMode() As String
        Get
            EQRunningMode = mvarEQRunningMode
        End Get
        Set(ByVal value As String)
            mvarEQRunningMode = value
            Me.lblEQRunningMode.Text = value
        End Set
    End Property

    Public Property EQConnect() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                Me.picEQConnectStats.BackColor = ConnectColor
            Else
                Me.picEQConnectStats.BackColor = DisConnectColor
            End If
        End Set
    End Property

    Public Property EQAlias() As String
        Get
            Return LabelAlias.Text
        End Get
        Set(ByVal value As String)
            LabelAlias.Text = value
        End Set
    End Property

    Private mvarConnectColor As System.Drawing.Color
    Public Property ConnectColor() As System.Drawing.Color
        Get
            ConnectColor = mvarConnectColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarConnectColor = value
        End Set
    End Property

    Private mvarDisConnectColor As System.Drawing.Color
    Public Property DisConnectColor() As System.Drawing.Color
        Get
            DisConnectColor = mvarDisConnectColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarDisConnectColor = value
        End Set
    End Property


    Private mvarWithGlass As Boolean
    Public Property WithGlass() As Boolean
        Get
            WithGlass = mvarWithGlass
        End Get

        Set(ByVal value As Boolean)
            mvarWithGlass = value
            UpdateGlass()
        End Set
    End Property

    Public Property SetGlassColor() As System.Drawing.Color
        Get
            Return picGlass.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            wGlassColor = value
            woGlassColor = System.Drawing.SystemColors.Control
            UpdateGlass()
        End Set
    End Property

    Private mvarGlassID As String
    Public Property GlassID() As String
        Get
            GlassID = mvarGlassID
        End Get
        Set(ByVal value As String)
            value = MyTrim(value)
            mvarGlassID = value
            Me.lblGlassID.Text = value
            UpdateGlass()
        End Set
    End Property


    Private Sub UpdateGlass()
        lblGlassID.Visible = True
        If WithGlass Then
            lblGlassID.BackColor = wGlassColor
            picGlass.BackColor = wGlassColor
            picGlass.Visible = True
        Else
            If mvarGlassID.Length = 0 Then
                lblGlassID.Visible = False
                picGlass.Visible = False
            ElseIf mvarGlassID.Length > 0 Then
                lblGlassID.BackColor = woGlassColor
                picGlass.BackColor = woGlassColor
                picGlass.Visible = True
            End If
        End If

    End Sub

    Private mvarEQName As String
    Public Property EQName() As String
        Get
            EQName = mvarEQName
        End Get
        Set(ByVal value As String)
            mvarEQName = value
            Me.lblEQName.Text = value
        End Set
    End Property

    Dim objFont As System.Drawing.Font

    Public Property SetFont() As System.Drawing.Font
        Get
            SetFont = objFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            Me.lblGlassID.Font = value
            Me.lblEQName.Font = value
        End Set
    End Property

    Dim ControlsPosLocation As ArrayList
    Dim OldcontrolSize As ControlPL

    Private Sub RSTGUICtrlEQ_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '    'Dim lXPos As Single
        '    'Dim lYPos As Single

        '    'Dim ctlTemp As Object

        '    'Static fResizeStart As Boolean

        '    'SetDefVal()

        '    'If Not fResizeStart Then
        '    '    Me.Width = Me.picContainer.Width
        '    '    Me.Height = Me.picContainer.Height
        '    '    fResizeStart = True
        '    'Else
        '    '    With picContainer
        '    '        .Width = Me.Width
        '    '        .Height = Me.Height

        '    '        lXPos = CSng(.Width) / CSng(lMyWidth)
        '    '        lYPos = CSng(.Height) / CSng(lMyHeight)

        '    '        For Each ctlTemp In Me.Controls
        '    '            If ctlTemp.Name <> "picContainer" Then
        '    '                ctlTemp.Left = ctlTemp.Left * lXPos
        '    '                ctlTemp.Width = ctlTemp.Width * lXPos
        '    '                ctlTemp.Top = ctlTemp.Top * lYPos
        '    '                ctlTemp.Height = ctlTemp.Height * lYPos
        '    '            End If
        '    '        Next
        '    '        lMyWidth = Me.Width
        '    '        lMyHeight = Me.Height
        '    '    End With
        '    'End If

        myResize()
    End Sub


    Private Sub lblEQName_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEQName.MouseDown
        RaiseEvent GUIMouseDown(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub lblEQName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEQName.MouseUp
        RaiseEvent GUIMouseUp(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub picEQConnectStats_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picEQConnectStats.MouseDown
        RaiseEvent GUIMouseDown(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub picEQConnectStats_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picEQConnectStats.MouseUp
        RaiseEvent GUIMouseUp(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub picContainer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picContainer.MouseDown
        RaiseEvent GUIMouseDown(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub picContainer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picContainer.MouseUp
        RaiseEvent GUIMouseUp(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub picGlass_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picGlass.MouseDown
        RaiseEvent GUIMouseDown(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub picGlass_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picGlass.MouseUp
        RaiseEvent GUIMouseUp(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub lblGlassID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblGlassID.MouseDown
        RaiseEvent GUIMouseDown(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub lblGlassID_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblGlassID.MouseUp
        RaiseEvent GUIMouseUp(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub lblEQRunningMode_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEQRunningMode.MouseDown
        RaiseEvent GUIMouseDown(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Private Sub lblEQRunningMode_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEQRunningMode.MouseUp
        RaiseEvent GUIMouseUp(sender.ToString, e.Delta, e.X, e.Y)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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
        myResize()
    End Sub

    Private Sub myResize()
        If OldcontrolSize.Size.Width = 0 OrElse OldcontrolSize.Size.Height = 0 Then
            Exit Sub
        End If

        Dim lx As Double = Me.Width / OldcontrolSize.Size.Width
        Dim ly As Double = Me.Height / OldcontrolSize.Size.Height

        picContainer.Width = Me.Width
        picContainer.Height = Me.Height

        For i As Integer = 0 To Me.Controls.Count - 1
            'If Me.Controls(i).Name <> "picContainer" Then
            Me.Controls(i).Width = CInt(ControlsPosLocation(i).Size.width * lx)
            Me.Controls(i).Height = CInt(ControlsPosLocation(i).Size.Height * ly)
            Me.Controls(i).Left = CInt(ControlsPosLocation(i).Location.X * lx)
            Me.Controls(i).Top = CInt(ControlsPosLocation(i).Location.Y * ly)
            'End If
        Next
    End Sub
End Class
