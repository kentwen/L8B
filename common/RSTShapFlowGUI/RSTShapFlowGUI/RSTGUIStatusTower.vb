Imports System.Drawing
Imports System.Math

Public Class RSTGUIStatusTower
    Private mvarColorConnect As System.Drawing.Color
    Private mvarColorDisConnect As System.Drawing.Color
    Private mvarGUIBackColor As System.Drawing.Color
    Private mvarGUITowerNameBackColor As System.Drawing.Color
    Private mvarTitleFont As System.Drawing.Font

    Private mvarTowerTitle As String
    Private mvarConnect As Boolean


    Dim ControlsPosLocation As ArrayList
    Dim ShapsPosLocation As ArrayList
    Dim OldcontrolSize As ControlPL

    Public Property ColorConnect() As System.Drawing.Color
        Get
            ColorConnect = mvarColorConnect
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarColorConnect = value
        End Set
    End Property

    Public Property ColorDisConnect() As System.Drawing.Color
        Get
            ColorDisConnect = mvarColorDisConnect
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarColorDisConnect = value
        End Set
    End Property

    Public Property Connect() As Boolean
        Get
            Connect = mvarConnect
        End Get
        Set(ByVal value As Boolean)
            mvarConnect = value
            If value = True Then
                Me.TextBoxStatus.BackColor = Me.ColorConnect
            Else
                Me.TextBoxStatus.BackColor = Me.ColorDisConnect
            End If
        End Set
    End Property

    Public Property TowerTitle() As String
        Get
            TowerTitle = mvarTowerTitle
        End Get
        Set(ByVal value As String)
            mvarTowerTitle = value
            Me.lblTowerName.Text = value
        End Set
    End Property

    Public Property GUIBackColor() As System.Drawing.Color
        Get
            GUIBackColor = mvarGUIBackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarGUIBackColor = value
        End Set
    End Property

    Public Property GUITowerNameBackColor() As System.Drawing.Color
        Get
            GUITowerNameBackColor = mvarGUITowerNameBackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarGUITowerNameBackColor = value
            Me.lblTowerName.BackColor = value
        End Set
    End Property


    Public Property TitleFont() As System.Drawing.Font
        Get
            TitleFont = mvarTitleFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            mvarTitleFont = value
            Me.lblTowerName.Font = value
        End Set
    End Property

    Private Sub RSTGUIStatusTowe_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim nTowerSize As Integer
        Dim nTitleSize As Integer
        nTowerSize = Me.Width / 5

        nTitleSize = nTowerSize * 3

        TextBoxStatus.Height = Me.Height - 6 'Min(Height, nTowerSize) - 2
        TextBoxStatus.Width = TextBoxStatus.Height 'Min(Height, nTowerSize) - 2
        TextBoxStatus.Top = (Me.Height - TextBoxStatus.Height) / 2

        Me.lblTowerName.Height = Height
        Me.lblTowerName.Width = nTitleSize
        Me.lblTowerName.Left = TextBoxStatus.Width + 2

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



End Class
