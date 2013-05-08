Imports prjSEMI.clsHSMS

Public Module modParameter
    Public MyLog As New RainbowTech.clsLogFactory
    Public MySEMI As New prjSEMI.clsHSMS
    Public MySysByte As New ReplySysByte

    Public Const MAX_CHIPGRADE = 72
    Public Const LEN_GXID = 12
    Public Const LEN_TOOLID = 8
    Public Const LEN_LINEID = 8
    Public Const LEN_OPERATIONID = 25
    Public Const LEN_PSHGROUP = 3
    Public Const LEN_PPID = 32
    Public Const LEN_PPID16 = 16
    Public Const LEN_4 = 4
    Public Const LEN_2 = 2
    Public Const LEN_CSTID = 6
    Public Const LEN_S10F1 = 22
    Public Const LEN_DATETIME = 14
    Public Const LEN_MESID = 4
    Public Const LEN_OPID = 20
    Public Const LEN_RTNCD7 = 7
    Public Const LEV_ACKC1 = 1
    Public Const LEN_BINARY = 1

    Public Const EMPY_CST = "0040302"

    Public Const MAX_SLOTS = 56

    Public Const MSGDEF_S1F0 = "S1TRAbort"
    Public Const MSGDEF_S2F0 = "S2TRAbort"
    Public Const MSGDEF_S3F0 = "S3TRAbort"
    Public Const MSGDEF_S4F0 = "S4TRAbort"
    Public Const MSGDEF_S5F0 = "S5TRAbort"
    Public Const MSGDEF_S6F0 = "S6TRAbort"
    Public Const MSGDEF_S7F0 = "S7TRAbort"
    Public Const MSGDEF_S8F0 = "S8TRAbort"
    Public Const MSGDEF_S9F0 = "S9TRAbort"


    Public Const MSGDEF_S1F1 = "HOST Online Check"
    Public Const MSGDEF_S1F2 = "Online Req Reply"
    Public Const MSGDEF_S1F2_HOST = "HOST Reply"

    Public Const MSGDEF_S1F5 = "EQ Status Query"
    Public Const MSGDEF_S1F6_SFCD1 = "EQ Status Query Reply By ToolID"
    Public Const MSGDEF_S1F6_SFCD8 = "EQ Statue Query Reply By LineID"
    Public Const MSGDEF_S1F6_EDS = "EQ Status Query Reply By EDS"
    Public Const MSGDEF_S1F6_EDS_NOINFO = "EDS Reply Without Info"

    Public Const MSGDEF_S1F65 = "EQ Status Change report"
    Public Const MSGDEF_S1F66 = "EQ Status Change report reply"

    Public Const MSGDEF_S1F67 = "Lot status change report"
    Public Const MSGDEF_S1F67_CST_EMPTY = "Lot status change report CST Empty"

    Public Const MSGDEF_S1F68 = "Lot status change report reply"

    Public Const MSGDEF_S1F73 = "Cassette load request or complete report"
    Public Const MSGDEF_S1F74 = "Cassette load request or complete report reply"

    Public Const MSGDEF_S1F75 = "CST unload request or complete report"
    Public Const MSGDEF_S1F76 = "CST unload request or complete report reply"

    Public Const MSGDEF_S1F87 = "WIP Data Query"
    Public Const MSGDEF_S1F88 = "WIP Data Query Reply"
    Public Const MSGDEF_S1F88NGX = "WIP Data Query Reply No WIP"

    Public Const MSGDEF_S1F89 = "Online Summary Status Report"
    Public Const MSGDEF_S1F90 = "Online summary status report reply"

    Public Const MSGDEF_S1F97 = "Recipe modified report"
    Public Const MSGDEF_S1F98 = "Recipe change event report Reply"

    Public Const MSGDEF_S2F17 = "Date and Time Request"
    Public Const MSGDEF_S2F18 = "Reply for date and time request"

    Public Const MSGDEF_S2F21 = "Remote Command"
    Public Const MSGDEF_S2F22 = "Remote command reply"

    Public Const MSGDEF_S2F25 = "Loop Back Check Request"
    Public Const MSGDEF_S2F26 = "Loop Back Check Request Reply"

    Public Const MSGDEF_S2F41 = "HOST Command Send"
    Public Const MSGDEF_S2F42 = "HOST Command ACK"

    Public Const MSGDEF_S5F65 = "Alarm Occurred or Released"
    Public Const MSGDEF_S5F65_NOGX = "Alarm Occurred Without Gx"
    Public Const MSGDEF_S5F66 = "Alarm occurred or released report reply"

    Public Const MSGDEF_S6F85 = "Work Removal data report"
    Public Const MSGDEF_S6F86 = "Work Removal data report reply"

    Public Const MSGDEF_S6F87 = "Work ID Unmatch Report"
    Public Const MSGDEF_S6F88 = "Work ID Unmatch Report Reply"

    Public Const MSGDEF_S6F91 = "Glass Process Start or END date report"
    Public Const MSGDEF_S6F92 = "Glass Process Start or END date report reply"

    Public Const MSGDEF_S7F3 = "Recipe ParameterQ uery"
    Public Const MSGDEF_S7F4 = "Recipe Parameter Query Reply"
    Public Const MSGDEF_S7F4_NG = "Recipe Parameter Query Reply NG"

    Public Const MSGDEF_S7F65 = "Lot_process_data_transfer"
    Public Const MSGDEF_S7F65NG = "Lot_process_data_transfer_NG"
    Public Const MSGDEF_S7F66 = "Lot process data transfer reply"

    Public Const MSGDEF_S7F67 = "Inquire Last Modification Date Time Of Recipe ID"
    Public Const MSGDEF_S7F68 = "Reply Last Modification Date"

    Public Const MSGDEF_S7F71 = "Lot process data request"
    Public Const MSGDEF_S7F72 = "Lot process data request reply"



    Public Const MSGDEF_S9F1 = "Unrecognized Device ID"
    Public Const MSGDEF_S9F3 = "Unrecognized Stream Type"
    Public Const MSGDEF_S9F5 = "Unrecognized Function Type"
    Public Const MSGDEF_S9F7 = "Illegal Data"
    Public Const MSGDEF_S9F9 = "Transaction timer time out"
    Public Const MSGDEF_S9F13 = "Conversation time out"

    Public Const MSGDEF_S10F1 = "Terminal Request"
    Public Const MSGDEF_S10F5 = "Termianl Display"

    Public Structure ReplySysByte
        Public S1F1 As ULong
        Public S1F5 As ULong
        Public S1F65 As ULong
        Public S1F67 As ULong
        Public S1F73 As ULong
        Public S1F75 As ULong
        Public S1F87 As ULong
        Public S1F89 As ULong
        Public S1F97 As ULong

        Public S2F17 As ULong
        Public S2F21 As ULong
        Public S2F25 As ULong
        Public S2F41 As ULong

        Public S5F65 As ULong

        Public S6F85 As ULong
        Public S6F87 As ULong
        Public S6F91 As ULong

        Public S7F3 As ULong
        Public S7F65 As ULong

        Public S7F67 As ULong
        Public S7F71 As ULong

    End Structure


    Public Structure S7F65HeaderInfo
        Public z01LINEID As String
        Public z02TOOLID As String
        Public z03DATETIME As String
        Public z04RTNCD As String
        Public z05CIMMSG As String
        Public z06LDPOS As Byte
        Public z07CASID As String
        Public z08PRODCD As String
        Public z09PRODCATE As String
        Public z10MESID As String
        Public z11OPERID As String
        Public z12PPID As String
    End Structure

    Public Structure S7F65BodyInfo
        Public z01SLOTNO As String
        Public z02GLASSID As String
        Public z03POPERID As String
        Public z04PLINEID As String
        Public z05PTOOLID As String
        Public z06DMQCTOLID As String
        Public z07GGRADE As String
        Public z08DGRADE As String
        Public z09PGROUP As String
        Public z10CHIPGRAGE As String
        Public z11RWKFLAG As String
        Public z12SCRPFLAG As String
        Public z13FIRMFLAG As String
        Public z14FIFCFLAG As String
    End Structure

    Public Function GetNow() As String
        GetNow = Format(Now, "yyyyMMddHHmmss")
    End Function

    Public Function SpaceCTL(ByVal strInter As String, ByVal nDataLen As Integer) As String
        Dim nFor As Integer
        Dim strOuter As String = ""
        For nFor = Len(strInter) + 1 To nDataLen
            strOuter = strOuter & " "
        Next
        SpaceCTL = strInter & strOuter
    End Function

    Public Function ZeroCodeCTL(ByVal strInter As String, ByVal nDataLen As Integer) As String
        Dim nFor As Integer
        Dim strOuter As String = ""
        For nFor = Len(strInter) - 1 To nDataLen
            strOuter = strOuter & "0"
        Next
        ZeroCodeCTL = strInter & strOuter

    End Function

    Public Function myTrim(ByVal str As String) As String
        Dim retStr As String = ""
        Dim i As Integer = 0
        For i = 0 To str.Length - 1
            If str(i) <> " " AndAlso Asc(str(i)) > 0 Then
                retStr = retStr & str(i)
            End If
        Next
        Return retStr
    End Function

#Region "SECS Segment To String Type"
    Public Function PortCategoryToString(ByVal nPortCategory As clsEnumCtl.ePortCategory) As String
        Select Case nPortCategory
            Case clsEnumCtl.ePortCategory.CATEGORY_OK
                PortCategoryToString = "O"
            Case clsEnumCtl.ePortCategory.CATEGORY_NG
                PortCategoryToString = "N"
            Case clsEnumCtl.ePortCategory.CATEGORY_MIXED
                PortCategoryToString = "M"
            Case Else
                PortCategoryToString = "M" ' Space(1)
        End Select
    End Function
#End Region

#Region "Write Log"
    Public Sub WriteSECSStructure(ByVal strLog() As String, Optional ByVal nLogType As clsEnumCtl.eZLogType = clsEnumCtl.eZLogType.TYPE_NA)
        Dim nFor As Integer

        For nFor = 0 To UBound(strLog)
            If nFor = 0 Then
                Writelog(strLog(nFor), nLogType, True)
            Else
                Writelog(strLog(nFor), clsEnumCtl.eZLogType.TYPE_SECS_EMPTY)
            End If
        Next
    End Sub

    Public Sub WrigeExceptionLog(ByVal strCMDName As String, ByVal strException As String)
        Writelog("CMD==>" & strCMDName & " MSG==>" & strException, clsEnumCtl.eZLogType.TYPE_ERR)
    End Sub

    Public Sub Writelog(ByVal strLog As String, Optional ByVal nLogType As clsEnumCtl.eZLogType = clsEnumCtl.eZLogType.TYPE_NA, Optional ByVal fWriteTime As Boolean = False)
        Dim strLogTitle As String = Space(5)
        Dim MyTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss.ff")

        Select Case nLogType
            Case clsEnumCtl.eZLogType.TYPE_ERR
                strLogTitle = "[ERR]"
            Case clsEnumCtl.eZLogType.TYPE_EVENT
                strLogTitle = "[Event]"
            Case clsEnumCtl.eZLogType.TYPE_METHOD
                strLogTitle = "[Method]"
            Case clsEnumCtl.eZLogType.TYPE_PROPERTY
                strLogTitle = " [Receive Primary Message]"
            Case clsEnumCtl.eZLogType.TYPE_RECEIVEPRI
                strLogTitle = " [Receive Primary Message]"
            Case clsEnumCtl.eZLogType.TYPE_RECEIVESECEND
                strLogTitle = " [Receive Reply Message]"
            Case clsEnumCtl.eZLogType.TYPE_SENDPRIM
                strLogTitle = " [Send Primary Message]"
            Case clsEnumCtl.eZLogType.TYPE_SENDSECEND
                strLogTitle = " [Send Reply Message]"
            Case Else
                strLogTitle = ""
        End Select

        If fWriteTime Then
            MyLog.WriteLog(MyTime & Space(1) & "SECS      >" & strLogTitle & " " & strLog)
        Else
            If nLogType = clsEnumCtl.eZLogType.TYPE_SECS_EMPTY Then
                MyLog.WriteLog("          " & Space(14) & strLogTitle & " " & strLog)
            Else
                MyLog.WriteLog("SECS      >" & Space(14) & strLogTitle & " " & strLog)
            End If
        End If
    End Sub
#End Region
End Module
