Imports System.Drawing

Public Class RSTGUICtrlRBT
    Enum eUIRBTArm
        ARM_UPPER = 1
        ARM_LOWER = 2
    End Enum
    Dim mvarSetBackColor As System.Drawing.Color
    Dim mvarSetUpArmColor As System.Drawing.Color
    Dim mvarSetLowerArmColor As System.Drawing.Color
    Dim mvarSetRBTColor As System.Drawing.Color
    Dim mvarUpArmGxColor As System.Drawing.Color
    Dim mvarLowerArmGxColor As System.Drawing.Color

    Dim mvarGxID(2) As String
    Dim mvarWithGx(2) As Boolean
    Dim mvarVacuum(2) As Boolean
    Dim mvarSensor(2) As Boolean
    Dim mvarSetUIFont As System.Drawing.Font

    Dim ControlsPosLocation As ArrayList
    Dim ShapsPosLocation As ArrayList
    Dim OldcontrolSize As ControlPL

    Public Event meDoubleClick()

    Public Property SetBackColor() As System.Drawing.Color
        Get
            SetBackColor = mvarSetBackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSetBackColor = value
            Me.picFrame.BackColor = value
        End Set
    End Property

    Public Property SetUpArmColor() As System.Drawing.Color
        Get
            SetUpArmColor = mvarSetUpArmColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSetUpArmColor = value
            Me.lblUpArm.BackColor = value
            Me.lblUpArmText.BackColor = value
        End Set
    End Property

    Public Property SetLowerArmColor() As System.Drawing.Color
        Get
            SetLowerArmColor = mvarSetLowerArmColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSetLowerArmColor = value
            Me.lblLowArm.BackColor = value
            Me.lblLowArmText.BackColor = value
        End Set
    End Property

    Public Property SetRBTColor() As System.Drawing.Color
        Get
            SetRBTColor = mvarSetRBTColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarSetRBTColor = value
            Me.lblRBT.BackColor = value
            Me.lblRBTCaption.BackColor = value
        End Set
    End Property


    Public Property UpArmGxColor() As System.Drawing.Color
        Get
            UpArmGxColor = mvarUpArmGxColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarUpArmGxColor = value
            Me.lblUpArmGxID.BackColor = value
        End Set
    End Property
    

    Public Property LowerArmGxColor() As System.Drawing.Color
        Get
            LowerArmGxColor = mvarLowerArmGxColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mvarLowerArmGxColor = value
            Me.lblLowArmGxID.BackColor = value
        End Set
    End Property
    Public Property GxID(ByVal nArm As eUIRBTArm) As String
        Get
            GxID = mvarGxID(nArm)
        End Get
        Set(ByVal value As String)
            mvarGxID(nArm) = value
            If nArm = eUIRBTArm.ARM_UPPER Then
                Me.lblUpArmGxID.Text = mvarGxID(nArm)
            Else
                Me.lblLowArmGxID.Text = mvarGxID(nArm)
            End If
        End Set
    End Property

    Public Property WithGx(ByVal nArm As eUIRBTArm) As Boolean
        Get
            WithGx = mvarWithGx(nArm)
        End Get
        Set(ByVal value As Boolean)
            mvarWithGx(nArm) = value
            If nArm = eUIRBTArm.ARM_UPPER Then
                Me.lblUpArmGxID.Visible = value
            Else
                Me.lblLowArmGxID.Visible = value
            End If
        End Set
    End Property

    Public Property SetUIFont() As System.Drawing.Font
        Get
            SetUIFont = mvarSetUIFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            mvarSetUIFont = value

            Me.lblUpArmGxID.Font = value
            Me.lblUpArmText.Font = value
            Me.lblLowArmGxID.Font = value
            Me.lblLowArmText.Font = value
            Me.lblRBTCaption.Font = value
        End Set
    End Property


    Public Property Vacuum(ByVal nArm As eUIRBTArm) As Boolean
        Get
            Vacuum = mvarVacuum(nArm)
        End Get
        Set(ByVal value As Boolean)
            mvarVacuum(nArm) = value
            If nArm = eUIRBTArm.ARM_UPPER Then
                Me.LabelUVacuum.BackColor = IIf(value, Color.LightBlue, Color.Transparent)
                Me.LabelUVacuum.Visible = value
            Else
                Me.LabelLVacuum.BackColor = IIf(value, Color.LightBlue, Color.Transparent)
                Me.LabelLVacuum.Visible = value
            End If
        End Set
    End Property

    Public Property Sensor(ByVal nArm As eUIRBTArm) As Boolean
        Get
            Sensor = mvarSensor(nArm)
        End Get
        Set(ByVal value As Boolean)
            mvarSensor(nArm) = value
            If nArm = eUIRBTArm.ARM_UPPER Then
                Me.LabelUSensor.BackColor = IIf(value, Color.LightGreen, Color.Transparent)
                Me.LabelUSensor.Visible = value
            Else
                Me.LabelLSensor.BackColor = IIf(value, Color.LightGreen, Color.Transparent)
                Me.LabelLSensor.Visible = value
            End If
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        OldcontrolSize.Size = New Size(Me.Size)
        OldcontrolSize.Location = New Point(Me.Location)

        ControlsPosLocation = New ArrayList
        ShapsPosLocation = New ArrayList
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

        For Each Shape As Object In Me.ShapeContainer1.Shapes
            PosLocation.Location = Shape.Location
            PosLocation.Size = Shape.size
            PosLocation.Font = Nothing
            ShapsPosLocation.Add(PosLocation)
        Next
    End Sub

    Private Sub RSTGUICtrlRBT_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        RaiseEvent meDoubleClick()
    End Sub


    Private Sub RSTGUICtrlRBT_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If OldcontrolSize.Size.Width = 0 OrElse OldcontrolSize.Size.Height = 0 Then
            Exit Sub
        End If

        Dim lx As Double = Me.Width / OldcontrolSize.Size.Width
        Dim ly As Double = Me.Height / OldcontrolSize.Size.Height

        picFrame.Width = Me.Width
        picFrame.Height = Me.Height

        For i As Integer = 0 To Me.Controls.Count - 1
            If Me.Controls(i).Name <> "picFrame" AndAlso Me.Controls(i).Name <> "ShapeContainer1" Then
                Me.Controls(i).Width = CInt(ControlsPosLocation(i).Size.width * lx)
                Me.Controls(i).Height = CInt(ControlsPosLocation(i).Size.Height * ly)
                Me.Controls(i).Left = CInt(ControlsPosLocation(i).Location.X * lx)
                Me.Controls(i).Top = CInt(ControlsPosLocation(i).Location.Y * ly)
            End If
        Next

        For i As Integer = 0 To ShapeContainer1.Shapes.Count - 1
            Me.ShapeContainer1.Shapes.Item(i).Width = CInt(ShapsPosLocation(i).Size.width * lx)
            Me.ShapeContainer1.Shapes.Item(i).Height = CInt(ShapsPosLocation(i).Size.Height * ly)
            Me.ShapeContainer1.Shapes.Item(i).Left = CInt(ShapsPosLocation(i).Location.X * lx)
            Me.ShapeContainer1.Shapes.Item(i).Top = CInt(ShapsPosLocation(i).Location.Y * ly)

        Next
    End Sub

    Public Enum eArmMode
        DualArm
        UpArmOnly
        LowArmOnly
    End Enum
    Private mvarArmMode As eArmMode

    Public Property ArmMode() As eArmMode
        Get
            Return mvarArmMode
        End Get
        Set(ByVal value As eArmMode)
            mvarArmMode = value
            Select Case mvarArmMode
                Case eArmMode.DualArm
                    lblLowArmText.Visible = True
                    lblLowArm.Visible = True
                    lblUpArmText.Visible = True
                    lblUpArm.Visible = True

                Case eArmMode.LowArmOnly
                    lblLowArmText.Visible = True
                    lblLowArm.Visible = True
                    lblUpArmText.Visible = False
                    lblUpArm.Visible = False
                Case eArmMode.UpArmOnly
                    lblUpArmText.Visible = True
                    lblUpArm.Visible = True
                    lblLowArmText.Visible = False
                    lblLowArm.Visible = False
                Case Else
                    lblUpArmText.Visible = False
                    lblUpArm.Visible = False
                    lblLowArmText.Visible = False
                    lblLowArm.Visible = False
            End Select
        End Set
    End Property

End Class
