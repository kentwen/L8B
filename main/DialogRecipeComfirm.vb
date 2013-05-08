Imports System.Windows.Forms

Public Class DialogRecipeComfirm
    Private OldPPID As String
    Private myPort As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        WriteLog(Me.Name & ": user click [OK]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If ComboBoxPPID.Text <> _L8B.CIM.LotInfo(mPortNo).RecipeName Then
            WriteLog("Recipe Comfirm: PPID Change->" & ComboBoxPPID.Text, LogMessageType.Info)
            _L8B.CIM.RecipeComfirm(mPortNo, ComboBoxPPID.Text)
            _L8B.CIM.LotInfo(mPortNo).RecipeName = ComboBoxPPID.Text
            mInfo.Port(myPort).Recipe = _L8B.db.LoadRecipe(MyTrim(_L8B.CIM.LotInfo(mPortNo).RecipeName))
        Else
            WriteLog("Recipe Comfirm: PPID no Change.", LogMessageType.Info)
            _L8B.CIM.RecipeComfirm(mPortNo)
        End If
        _L8B.PLC.UploadLotData(myPort)
        _L8B.CIM.LotInfo(mPortNo).RecipeNeedConfirm = False
        'mInfo.SetPortStatus(mPortNo, PORTSTATUS.READYTOSTART)
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        WriteLog(Me.Name & ": user click [Cancel Cassette]", LogMessageType.Info)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        _L8B.PLC.CassetteUnloadRequest(myPort)
        Me.Hide()
    End Sub

    Public Sub ShowMe(ByVal nPort As Integer, Optional ByVal Parent As System.Windows.Forms.IWin32Window = Nothing)
        _L8B.CIM.LotInfo(nPort).RecipeNeedConfirm = True
        DataGridViewRecipe.DataSource = _L8B.db.QueryRecipeList
        ComboBoxPPID.DisplayMember = "ID"
        ComboBoxPPID.DataSource = _L8B.db.QueryRecipeList
        TextBoxPort.Text = nPort
        TextBoxCSDID.Text = _L8B.CIM.LotInfo(mPortNo).CassetteID
        TextBoxLotID.Text = _L8B.CIM.LotInfo(mPortNo).CIMMessage
        ComboBoxPPID.Text = MyTrim(_L8B.CIM.LotInfo(mPortNo).RecipeName)
        OldPPID = MyTrim(_L8B.CIM.LotInfo(mPortNo).RecipeName)

        myPort = nPort
        'If Parent Is Nothing Then
        '    Me.Show()
        'Else
        '    Me.Show(Parent)
        'End If
        'Me.TopMost = True
        SyncLock _L8B.frmShowQueue
            _L8B.frmShowQueue.Enqueue(Me)
        End SyncLock
    End Sub

    Private mPortNo As Integer
    Public Property PortNo() As Integer
        Get
            Return mPortNo
        End Get
        Set(ByVal value As Integer)
            mPortNo = value
        End Set
    End Property

End Class
