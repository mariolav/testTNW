Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Module ModTNW
    Const SETTINGS_PATH As String = ".\settings.xml"
    Public Settings As New clsAppSettings(SETTINGS_PATH)

    Public PnNumberOfInvoices As Integer
    Public PsExeName As String
    Public pbImported As Boolean = False
    Public pbErrorFound As Boolean = False
    Public psDBID As String = ""
    Public psDBPwd As String = ""
    Public psDatabase As String = ""
    Public psDBName As String = ""
    Public psSageUserName As String = ""
    Public psSagePassword As String = ""
    Public psSageCompany As String = ""
    Public pbAutoRun As Boolean
    Public pnTimeout As Integer
    Public psTaxGroup As String
    Public psLogFile As String
    Public PsFolder As String
    ' SMTP
    Public psMailSMTPHost As String = "smtp.gmail.com"
    Public psMailTo As String = "mlavignasse@MNP.com"
    Public psMailFrom As String = "mariolavignasse@gmail.com"
    Public psMailPassword As String = "Madrid19!"
    Public pnMailPort As Integer = 597
    Public pbMailEnableSSL As Boolean = True
    Public PsMailUserid As String = ""

    Public CONN As String = ""
    Public connectionString As String = ""
    Public psTitle As String = My.Application.Info.Description
    Public psErrors As String
    Public psBadSql As String = ""
    Public PsTable As String = ""  ' METERED or TRUCKED
    Public PbRecordsProcessed As Boolean = False
    Public PbIncludeZeroConsumption As Boolean = False
    Public PsCompanyName As String = ""
    Public PsPenaltyPercent As String = "1.8"
    Public PnYear As Integer
    Public PnMonth As Integer
    Public pbIncludeMAF As Boolean = True
    Public pbIncludeInterest As Boolean = True



    '    Public MnBadCount As Integer

    '    [IDCUST] [char](12),
    '[OLDACC] [varchar](20),
    '[METER] varchar(13) Not null,
    '[ACTREAD] [decimal](9, 0),
    '[PREREAD] [decimal](9, 0),
    '[DATEREAD] varchar(6),
    '[TIMEREAD] varchar(6),
    '[WATER] [varchar](60) Default N'',
    '[GARBAGE] [varchar](60) Default N'',
    Public Structure Metered
        Dim IDCUST As String
        Dim OLDACC As String
        Dim ACTREAD As Long
        Dim PREREAD As Long
        Dim WATER As String
        Dim GARBAGE As String
        Dim MONTH As String
        Dim YEAR As String
        Dim METER As String
        Dim BALANCE As Double
        Dim MONTHLYBALANCE As Double
        Dim INTEREST As String
        Dim MULTITOT As Long
        Dim SameIDCust As Boolean
        Dim FirstIdCust As Boolean
    End Structure
    '[IDCUST]
    '[OLDACC]
    '[CONSUMPTION]
    '[DATEFILE]
    Public Structure Trucked
        Dim IDCUST As String
        Dim OLDACC As String
        Dim CONSUMPTION As Long
        Dim WATER As String
        Dim GARBAGE As String
        Dim MONTH As Byte
        Dim YEAR As Integer
        Dim INVDESC As String
        Dim BALANCE As Double
        Dim MONTHLYBALANCE As Double
        Dim INTEREST As String
        Dim MULTITOT As Long
        Dim SameIDCust As Boolean
        Dim FirstIdCust As Boolean
    End Structure
    Public Structure Others
        Dim IDCUST As String
        Dim BALANCE As Double
        Dim MONTH As Byte
        Dim YEAR As Integer
    End Structure


    Public AllMetered() As Metered
    Public AllTrucked() As Trucked
    Public AllOthers() As Others


    Public Sub GetIds()
        ReadSettings(True)
        CONN = "uid=" & psDBID & ";pwd=" & psDBPwd & ";Persist Security Info=False;Initial Catalog=" & psDBName & ";Data Source=" & psDatabase
        connectionString = "uid=" & psDBID & ";pwd=" & psDBPwd & ";Persist Security Info=False;Initial Catalog=master;Data Source=" & psDatabase
    End Sub
    '    Public Sub GetIds2()
    Private Sub ReadSettings(ByVal bCallReadSettingMethod As Boolean)
        If bCallReadSettingMethod Then Settings.ReadSettings()

        psDBID = CStr(Settings.Item("SQLID", "sa"))
        psDBPwd = fnDecrypt(CStr(Settings.Item("SQLPW", "jg7YbyWTq1dxW2v3BTlAGQ==")))
        psDBName = CStr(Settings.Item("DBName", "TSTDAT"))
        psDatabase = CStr(Settings.Item("DataSource", "192.168.16.223"))
        psSageUserName = CStr(Settings.Item("SageID", "ADMIN"))
        psSagePassword = fnDecrypt(CStr(Settings.Item("SagePW", "mpjA5eAy8fOLgqhxz/pLcA==")))
        psSageCompany = CStr(Settings.Item("SageCompany", "TSTDAT"))
        PsFolder = CStr(Settings.Item("FileFolder", "C:\Neptune Utility\Neptune files"))
        Dim lsTimeout As String = CStr(Settings.Item("ProgramTimeout", "180"))
        pnTimeout = Integer.Parse(lsTimeout)

        psMailFrom = CStr(Settings.Item("SMTPFrom", ""))
        psMailPassword = fnDecrypt(CStr(Settings.Item("SMTPPassword", "")))
        psMailTo = CStr(Settings.Item("SMTPTo", ""))
        psMailSMTPHost = CStr(Settings.Item("SMTPServer", ""))
        pnMailPort = CInt(CStr(Settings.Item("SMTPPort", "587")))
        pbMailEnableSSL = CBool(CStr(Settings.Item("SMTPEnableSSL", "True")))
        PsMailUserid = CStr(Settings.Item("SMTPUserid", ""))
        '        PsPenaltyPercent = CStr(Settings.Item("penaltypercent", "1.8"))
        PbIncludeZeroConsumption = CBool(CStr(Settings.Item("IncludeCero", "False")))
        CONN = "uid=" & psDBID & ";pwd=" & psDBPwd & ";Persist Security Info=False;Initial Catalog=" & psDBName & ";Data Source=" & psDatabase
        connectionString = "uid=" & psDBID & ";pwd=" & psDBPwd & ";Persist Security Info=False;Initial Catalog=master;Data Source=" & psDatabase
        PsCompanyName = getValueFromSQL("SELECT '('+rtrim([ORGID])+')  - ' +rtrim([CONAME])  FROM [dbo].[CSCOM]")
    End Sub

    Public Sub LogFile(ByVal myString As String, Optional ByVal myAppend As Boolean = True)
        Dim lsfile As String = PsExeName & "_log.txt"
        If Not Directory.Exists(Application.StartupPath & "\Logs") Then
            Directory.CreateDirectory(Application.StartupPath & "\Logs")
        End If
        Using writer As StreamWriter = New StreamWriter(Application.StartupPath & "\Logs\" & lsfile, myAppend)
            'frmMainImport.putText(myString)
            writer.Write(myString & vbCrLf)
        End Using
    End Sub
#Region "Error Messages"

    Public Sub MyErrorMsg2(myex As Exception, mysub As String)
        pbErrorFound = True

        Dim lsNetwork = ""

        Dim result As String
        Dim hr As Integer = Marshal.GetHRForException(myex)
        result = myex.GetType.ToString & "(0x" & hr.ToString("X8") & "): " & myex.Message & Environment.NewLine &
                 myex.StackTrace & Environment.NewLine
        Dim st = New StackTrace(myex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then
                result &= "Line:" & sf.GetFileLineNumber() & " Filename: " & Path.GetFileName(sf.GetFileName) &
                          Environment.NewLine
            End If
        Next
        LogFile(result & lsNetwork, True)
    End Sub

    Public Sub MyErrorMsg(myex As Exception, mysub As String)
        pbErrorFound = True
        Dim lsBuildError = ""
        Dim LStEMP As String = ""
        If myex.InnerException IsNot Nothing Then
            lsBuildError = myex.InnerException.Message.ToString & vbCrLf
        End If
        LStEMP = lsBuildError & "Problem: (" & myex.Message & ")" & vbCrLf & "Error on Sub/Function:  " & mysub & vbCrLf &
            vbCrLf & myex.StackTrace
        psErrors &= LStEMP
        LogFile(Now.ToString, True)
        LogFile(LStEMP, True)
    End Sub

#End Region
    Public Sub csvExport(ByVal SGrid As DataGridView, ByVal sFileName As String)
        Dim builder As New StringBuilder
        Dim sep As String = ""
        Dim lsQuotes As String = Chr(34) & Chr(34)
        With SGrid
            sep = ""
            For x As Integer = 0 To .Columns.Count - 1
                If .Columns(x).Visible Then
                    builder.Append(sep)
                    builder.Append("""" & .Columns(x).Name & """")
                    sep = ","
                End If
            Next
            For Each row As DataGridViewRow In SGrid.Rows
                builder.AppendLine()
                sep = ""
                For x As Integer = 0 To .Columns.Count - 1
                    If .Columns(x).Visible Then
                        builder.Append(sep)
                        If Not IsNothing(row.Cells(x).Value) Then
                            If IsNumeric(row.Cells(x).Value.ToString) AndAlso row.Cells(x).Value > 100000000 Then
                                builder.Append("""" & "'" & Replace(row.Cells(x).Value.ToString, """", "''") & "" & """")
                            Else
                                builder.Append("""" & Replace(row.Cells(x).Value.ToString, """", "''") & "" & """")
                            End If
                        Else
                            builder.Append(lsQuotes)
                        End If
                        sep = ","
                    End If
                Next
            Next
        End With
        Try
            Using writer As StreamWriter = New StreamWriter(Environ("temp") & "\" & sFileName.Trim & ".csv")
                writer.Write(builder.ToString)
            End Using
            ShellExecute(Environ("temp") & "\" & sFileName.Trim & ".csv")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub ShellExecute(ByVal File As String)
        Dim myProcess As New Process
        Try
            myProcess.StartInfo.FileName = File
            myProcess.StartInfo.UseShellExecute = True
            myProcess.StartInfo.RedirectStandardOutput = False
            myProcess.Start()
            myProcess.Dispose()
        Catch ex As Exception
            Console.WriteLine("Could not start process. " & ex.Message.ToString)
        End Try
    End Sub
    Public Sub MailFile(ByVal sFile As String, Optional ByVal sMessage As String = "")

        If psMailSMTPHost = "" Then
            Exit Sub
        End If
        'PsMailUserid = psMailFrom
        Dim smtp As New System.Net.Mail.SmtpClient
        Dim data As New Net.Mail.Attachment(sFile)

        smtp.Host = psMailSMTPHost
        smtp.Port = pnMailPort
        smtp.EnableSsl = pbMailEnableSSL
        'MsgBox(PsMailUserid)
        smtp.Credentials = New Net.NetworkCredential(PsMailUserid, psMailPassword)
        Dim mMail As New System.Net.Mail.MailMessage()
        mMail.[To].Add(psMailTo)
        mMail.From = New System.Net.Mail.MailAddress(psMailFrom, "", System.Text.Encoding.UTF8)
        mMail.Subject = "Error log from program " & PsExeName 'sMessage
        If sMessage & "" <> "" Then
            mMail.Body = sMessage
        Else
            mMail.Body = "Please check attachment."
        End If
        'data = System.Net.Mail.Attachment(sFile)
        '        Dim data As New Net.Mail.Attachment(sFile)
        data.Name = System.IO.Path.GetFileName(sFile) ' "file.txt"
        mMail.Attachments.Add(data)
        Try
            smtp.Send(mMail)
            data.Dispose()
            If Not pbAutoRun Then
                MsgBox("Email sent to: " & psMailTo)
            End If
        Catch ex As System.Net.Mail.SmtpException
            If Not pbAutoRun Then
                MsgBox(ex.Message)
            End If
        End Try
    End Sub
    Public Function FnCheckAll(ByVal table As String) As String
        Dim LsMessageError As String = ""
        If Not fnCheckRecordExist(String.Format("Select IDITEM from [dbo].[ARITH] where IDITEM='{0}'", "MAF")) Then
            LsMessageError &= "Missing MAF Item." & vbCrLf
        End If
        If Not fnCheckRecordExist(String.Format("Select IDITEM from [dbo].[ARITH] where IDITEM='{0}'", "LATEPMT")) Then
            LsMessageError &= "Missing LATEPMT Item." & vbCrLf
        End If
        If fnCheckRecordExist(String.Format("SELECT top(1) trim([WATER]) FROM MNP.DBO.{0} WHERE trim([WATER])<>'' and  trim([WATER]) Not In (Select trim(IDITEM) from [dbo].[ARITH])", table)) Then
            LsMessageError &= String.Format("Missing ({0} WATER) Item.", table) & vbCrLf
        End If
        If fnCheckRecordExist(String.Format("SELECT top(1) trim([GARBAGE]) FROM MNP.DBO.{0} WHERE trim([GARBAGE])<>'' and trim([GARBAGE]) Not In (Select trim(IDITEM) from [dbo].[ARITH])", table)) Then
            LsMessageError &= String.Format("Missing ({0} GARBAGE) Item.", table) & vbCrLf
        End If
        Return LsMessageError
    End Function
End Module
