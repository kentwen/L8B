Module ModuleCommon
    Public Structure ControlPL
        Dim Location As System.Drawing.Point
        Dim Size As System.Drawing.Size
        Dim Font As System.Drawing.Font
    End Structure

    Public Function MyTrim(ByRef zStr As String) As String
        Return MyTrimStart(MyTrimEnd(zStr))
    End Function

    Public Function MyTrimStart(ByRef zStr As String) As String
        Try
            If zStr Is Nothing Then Return ""

            Dim zTmp As String = ""
            Dim Index As Integer = 0

            For i As Integer = 0 To zStr.Length - 1
                If Asc(zStr(i)) <> &H20 AndAlso Asc(zStr(i)) <> 255 AndAlso Asc(zStr(i)) > 0 Then
                    Index = i
                    Exit For
                End If
            Next

            If Index < zStr.Length - 1 Then
                For i As Integer = Index To zStr.Length - 1
                    zTmp &= zStr(i)
                Next
            End If

            Return zTmp
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Function MyTrimEnd(ByRef zStr As String) As String
        Try
            If zStr Is Nothing Then Return ""

            Dim zTmp As String = ""
            Dim Index As Integer = 0

            For i As Integer = zStr.Length - 1 To 0 Step -1
                If Asc(zStr(i)) <> &H20 AndAlso Asc(zStr(i)) <> 255 AndAlso Asc(zStr(i)) > 0 Then
                    Index = i
                    Exit For
                End If
            Next

            If Index > 0 Then
                For i As Integer = 0 To Index
                    zTmp &= zStr(i)
                Next
            End If

            Return zTmp
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Module
