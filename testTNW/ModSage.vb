Imports ACCPAC.Advantage
Module ModSage
    Public SageSess As ACCPAC.Advantage.Session
    Public Errors As String
    Public Warnings As String
    Public Messages As String
    Public AllErrors As String

    Public Sub StartSage()
        Try
            If IsNothing(SageSess) Then
                LogFile("Starting a Sage session" & vbCrLf, True)
                SageSess = New ACCPAC.Advantage.Session()
                ' ****   Change next 2 lines as needed ****
                SageSess.Init("", "XY", "XY1000", "65A")
                '                SageSess.Open(psSageUserName, psSagePassword, psSageCompany, DateTime.Today, 0)
                SageSess.Open(psSageUserName.ToUpper, psSagePassword.ToUpper, psSageCompany.ToUpper, DateTime.Today, 0)
                LogFile("Sage session started" & vbCrLf, True)
                'LogFile("Sage user:" & PsSageUserName.ToUpper)
                'LogFile("Sage pwd:" & PsSagePassword.ToUpper)

                'LogFile("Sage Company:" & PsSageCompany.ToUpper)
            End If
        Catch ex As Exception
            myErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
            'MyErrorHandler(ex)
        End Try
    End Sub

    Public Sub CreateInvoiceMetered(ByVal Progress As ProgressBar)
        StartSage()
        Progress.Maximum = AllMetered.Length
        Progress.Value = Progress.Maximum
        Progress.Value = 1
        Progress.Visible = True
        Dim LineNum As Integer = 0
        Try


            ' TODO: To increase efficiency, comment out any unused DB links.
            Dim mDBLinkCmpRW As ACCPAC.Advantage.DBLink
            mDBLinkCmpRW = SageSess.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadWrite)

            Dim mDBLinkSysRW As ACCPAC.Advantage.DBLink
            mDBLinkSysRW = SageSess.OpenDBLink(DBLinkType.System, DBLinkFlags.ReadWrite)
            Dim lsTitle As String = "Metered Water - "
            If Command.ToString <> "" Then
                lsTitle &= "** Testing ** - "
            End If

            If Not (pbIncludeMAF) Then
                lsTitle &= "(No MAF) - "
            End If
            If Not (pbIncludeInterest) Then
                lsTitle &= "(No Interest) - "
            End If

            Dim temp As Boolean
            Dim lnDay As Integer = 0
            Dim lnMonth As Integer = 0
            Dim lnYear As Integer = 0
            Dim ARINVOICE1batch As ACCPAC.Advantage.View
            Dim ARINVOICE1header As ACCPAC.Advantage.View
            Dim ARINVOICE1detail1 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail2 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail3 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail4 As ACCPAC.Advantage.View
            ARINVOICE1batch = mDBLinkCmpRW.OpenView("AR0031")
            ARINVOICE1header = mDBLinkCmpRW.OpenView("AR0032")
            ARINVOICE1detail1 = mDBLinkCmpRW.OpenView("AR0033")
            ARINVOICE1detail2 = mDBLinkCmpRW.OpenView("AR0034")
            ARINVOICE1detail3 = mDBLinkCmpRW.OpenView("AR0402")
            ARINVOICE1detail4 = mDBLinkCmpRW.OpenView("AR0401")

            ARINVOICE1batch.Compose({ARINVOICE1header})
            ARINVOICE1header.Compose({ARINVOICE1batch, ARINVOICE1detail1, ARINVOICE1detail2, ARINVOICE1detail3, Nothing})
            ARINVOICE1detail1.Compose({ARINVOICE1header, ARINVOICE1batch, ARINVOICE1detail4})
            ARINVOICE1detail2.Compose({ARINVOICE1header})
            ARINVOICE1detail3.Compose({ARINVOICE1header})
            ARINVOICE1detail4.Compose({ARINVOICE1detail1})

            ARINVOICE1batch.Browse("((BTCHSTTS = 1) OR (BTCHSTTS = 7))", 1)
            Dim ARINVCPOST2 As ACCPAC.Advantage.View
            ARINVCPOST2 = mDBLinkCmpRW.OpenView("AR0048")

            ARINVOICE1batch.RecordCreate(1)
            ARINVOICE1batch.Fields.FieldByName("PROCESSCMD").SetValue("1", False) ' Process Command


            ARINVOICE1batch.Process()
            ARINVOICE1batch.Read(False)
            ARINVOICE1header.RecordCreate(2)
            ARINVOICE1detail1.Cancel()
            ARINVOICE1batch.Fields.FieldByName("BTCHDESC").SetValue(lsTitle & Now.ToShortDateString, False) ' Description
            ARINVOICE1batch.Update()
            For x As Integer = 0 To AllMetered.Length - 1
                With AllMetered(x)
                    If .ACTREAD - .PREREAD >= 0 Then
                        Progress.Value = x + 1

                        If .FirstIdCust = True Then
                            LineNum = 0
                            ' ************************************************
                            ' Header start
                            ' ************************************************
                            ARINVOICE1header.Fields.FieldByName("IDCUST").SetValue(.IDCUST, False) ' Customer Number
                            ARINVOICE1header.Fields.FieldByName("PROCESSCMD").SetValue("4", False) ' Process Command
                            ARINVOICE1header.Process()
                            lnDay = DateSerial(.YEAR, .MONTH + 1, 0).Day
                            lnMonth = DateSerial(.YEAR, .MONTH + 1, 0).Month
                            lnYear = DateSerial(.YEAR, .MONTH + 1, 0).Year
                            ARINVOICE1header.Fields.FieldByName("DATEINVC").SetValue(DateSerial(lnYear, lnMonth, lnDay), False) ' Document Date
                            temp = ARINVOICE1detail1.Exists
                            ARINVOICE1detail1.RecordClear()
                            ' ************************************************
                            ' Header ends
                            ' ************************************************
                        End If
                        If ((.ACTREAD - .PREREAD) = 0) And (PbIncludeZeroConsumption = False) Then
                            'ignore line
                        Else
                            LineNum += 1
                            temp = ARINVOICE1detail1.Exists
                            ARINVOICE1detail1.RecordCreate(0)
                            ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                            ARINVOICE1detail1.Process()
                            ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue(.WATER, False) ' Item Number
                            ARINVOICE1detail1.Fields.FieldByName("QTYINVC").SetValue(Format(.ACTREAD - .PREREAD, "0.00000"), False) ' Quantity
                            ARINVOICE1detail1.Insert()
                            ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                            ARINVOICE1detail1.Read(False)
                        End If
                        temp = ARINVOICE1detail1.Exists
                        If .SameIDCust = False Then

                            If (.GARBAGE.ToString.ToUpper <> "GN") And (.GARBAGE.ToString.ToUpper <> "") Then
                                LineNum += 1
                                ' Has Garbage
                                ARINVOICE1detail1.RecordCreate(0)
                                'LogFile(String.Format("Cust: {0}  Garbage: {1}", .IDCUST, .GARBAGE))
                                ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                                ARINVOICE1detail1.Process()
                                ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue(.GARBAGE, False) ' Item Number
                                ARINVOICE1detail1.Insert()
                                ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                                ARINVOICE1detail1.Read(False)
                            End If
                            If pbIncludeMAF = True Then
                                ' ********************************************************************************************************
                                ' Add MAF
                                ' ignore line
                                ' CHARGE SERVICE FEE (MAF)
                                LineNum += 1
                                temp = ARINVOICE1detail1.Exists
                                ARINVOICE1detail1.RecordCreate(0)
                                ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                                ARINVOICE1detail1.Process()
                                ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue("MAF", False) ' Item Number
                                ARINVOICE1detail1.Fields.FieldByName("QTYINVC").SetValue(Format(1, "0.00000"), False) ' Quantity
                                ARINVOICE1detail1.Insert()
                                ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                                ARINVOICE1detail1.Read(False)
                                ' ********************************************************************************************************
                            End If

                            If (.MONTHLYBALANCE > 0) And (.BALANCE > 0) And .INTEREST = "Y" Then
                                LineNum += 1
                                temp = ARINVOICE1detail1.Exists
                                ARINVOICE1detail1.RecordCreate(0)
                                ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                                ARINVOICE1detail1.Process()
                                ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue("LATEPMT", False) ' Item Number
                                ARINVOICE1detail1.Fields.FieldByName("QTYINVC").SetValue(Format(.MONTHLYBALANCE, "0.00000"), False) ' Quantity
                                ARINVOICE1detail1.Insert()
                                ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                                ARINVOICE1detail1.Read(False)

                            End If


                            '' Current read
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("CURREAD", False) ' Optional Field
                            ARINVOICE1detail3.Fields.FieldByName("VALIFNUM").SetValue(.ACTREAD, False) ' Number
                            ARINVOICE1detail3.Insert()
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("CURREAD", False) ' Optional Field
                                ARINVOICE1detail3.Read(False)

                                '' Previous read
                                'ARINVOICE1detail3.Insert()
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PREREAD", False) ' Optional Field
                            ARINVOICE1detail3.Fields.FieldByName("VALIFNUM").SetValue(.PREREAD, False) ' Number
                            ARINVOICE1detail3.Insert()
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PREREAD", False) ' Optional Field
                                ARINVOICE1detail3.Read(False)
                            '' BALANCE FORWARD
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("BALANCE", False) ' Optional Field
                            ARINVOICE1detail3.Fields.FieldByName("VALIFNUM").SetValue(.BALANCE, False) ' Number
                            ARINVOICE1detail3.Insert()
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("BALANCE", False) ' Optional Field
                            ARINVOICE1detail3.Read(False)

                            '' MONTH
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("MONTH", False) ' Optional Field
                            ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(.MONTH.Trim, False) ' Text Value
                                ARINVOICE1detail3.Insert()
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("MONTH", False) ' Optional Field
                                ARINVOICE1detail3.Read(False)

                                '' Year
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("YEAR", False) ' Optional Field
                                ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(.YEAR.Trim, False) ' Text Value
                                ARINVOICE1detail3.Insert()
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("YEAR", False) ' Optional Field
                                ARINVOICE1detail3.Read(False)

                                '' Interest
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PCINT", False) ' Optional Field
                                ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(PsPenaltyPercent, False) ' Text Value
                                ARINVOICE1detail3.Insert()
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PCINT", False) ' Optional Field
                                ARINVOICE1detail3.Read(False)


                                Try
                                    ARINVOICE1header.Insert()
                                    ARINVOICE1detail1.Read(False)
                                    ARINVOICE1detail1.Read(False)
                                    ARINVOICE1batch.Read(False)
                                    ARINVOICE1header.RecordCreate(2)
                                    ARINVOICE1detail1.Cancel()
                                Catch ex2 As Exception

                                End Try

                                sqlExe(String.Format(My.Resources.UpdateMeteredUser, .IDCUST, .ACTREAD.ToString, .PREREAD.ToString, .METER))
                                'LogFile("Created invoice for : " & .IDCUST)
                            End If
                        Else
                        pbErrorFound = True
                        psErrors &= "Unable to Created invoice for : " & .IDCUST & vbCrLf & "Consumption=0 or less than 0"
                        LogFile("Unable to Created invoice for : " & .IDCUST & vbCrLf & "Consumption=0 or less than 0")
                    End If
                End With
            Next

            PnNumberOfInvoices = CInt(ARINVOICE1batch.Fields.FieldByName("CNTINVCENT").Value)
        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
            'MyErrorMsg2(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
            'MyErrorHandler(ex)

        End Try
        Progress.Value = 1
        Progress.Visible = False


    End Sub
    Public Sub CreateInvoiceTrucked(ByVal Progress As ProgressBar)
        'MsgBox("1")
        StartSage()
        'Progress.Maximum = AllTrucked.Length
        'Progress.Value = AllTrucked.Length
        Progress.Maximum = AllTrucked.Length
        Progress.Value = Progress.Maximum
        Progress.Value = 1
        Progress.Visible = True
        'MsgBox("2")
        Dim LineNum As Integer = 0

        Try


            ' TODO: To increase efficiency, comment out any unused DB links.
            Dim mDBLinkCmpRW As ACCPAC.Advantage.DBLink
            mDBLinkCmpRW = SageSess.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadWrite)

            Dim mDBLinkSysRW As ACCPAC.Advantage.DBLink
            mDBLinkSysRW = SageSess.OpenDBLink(DBLinkType.System, DBLinkFlags.ReadWrite)

            Dim lsTitle As String = "Trucked Water - "
            If Command.ToString <> "" Then
                lsTitle = "** Testing ** - "
            End If
            If Not (pbIncludeMAF) Then
                lsTitle &= "(No MAF) - "
            End If
            If Not (pbIncludeInterest) Then
                lsTitle &= "(No Interest) - "
            End If

            Dim temp As Boolean
            Dim lnDay As Integer = 0
            Dim lnMonth As Integer = 0
            Dim lnYear As Integer = 0

            Dim ARINVOICE1batch As ACCPAC.Advantage.View
            Dim ARINVOICE1header As ACCPAC.Advantage.View
            Dim ARINVOICE1detail1 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail2 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail3 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail4 As ACCPAC.Advantage.View
            ARINVOICE1batch = mDBLinkCmpRW.OpenView("AR0031")
            ARINVOICE1header = mDBLinkCmpRW.OpenView("AR0032")
            ARINVOICE1detail1 = mDBLinkCmpRW.OpenView("AR0033")
            ARINVOICE1detail2 = mDBLinkCmpRW.OpenView("AR0034")
            ARINVOICE1detail3 = mDBLinkCmpRW.OpenView("AR0402")
            ARINVOICE1detail4 = mDBLinkCmpRW.OpenView("AR0401")

            ARINVOICE1batch.Compose({ARINVOICE1header})
            ARINVOICE1header.Compose({ARINVOICE1batch, ARINVOICE1detail1, ARINVOICE1detail2, ARINVOICE1detail3, Nothing})
            ARINVOICE1detail1.Compose({ARINVOICE1header, ARINVOICE1batch, ARINVOICE1detail4})
            ARINVOICE1detail2.Compose({ARINVOICE1header})
            ARINVOICE1detail3.Compose({ARINVOICE1header})
            ARINVOICE1detail4.Compose({ARINVOICE1detail1})

            ARINVOICE1batch.Browse("((BTCHSTTS = 1) OR (BTCHSTTS = 7))", 1)
            Dim ARINVCPOST2 As ACCPAC.Advantage.View
            ARINVCPOST2 = mDBLinkCmpRW.OpenView("AR0048")

            ARINVOICE1batch.RecordCreate(1)
            ARINVOICE1batch.Fields.FieldByName("PROCESSCMD").SetValue("1", False) ' Process Command


            ARINVOICE1batch.Process()
            ARINVOICE1batch.Read(False)
            ARINVOICE1header.RecordCreate(2)
            ARINVOICE1detail1.Cancel()
            ARINVOICE1batch.Fields.FieldByName("BTCHDESC").SetValue(lsTitle & Now.ToShortDateString, False) ' Description
            ARINVOICE1batch.Update()
            ' ******************************************************
            ' * August 21, 2020
            ' Changed to acomodate groups
            '*******************************************************
            'For x As Integer = 0 To AllTrucked.Length - 1
            '    With AllTrucked(x)

            For x As Integer = 0 To AllTrucked.Length - 1
                With AllTrucked(x)
                    If .CONSUMPTION >= 0 Then
                        Progress.Value = x + 1



                        If .FirstIdCust = True Then
                            LineNum = 0

                            ' ************************************************
                            ' Header start
                            ' ************************************************
                            ARINVOICE1header.Fields.FieldByName("IDCUST").SetValue(.IDCUST, False) ' Customer Number
                            ARINVOICE1header.Fields.FieldByName("PROCESSCMD").SetValue("4", False) ' Process Command
                            ARINVOICE1header.Process()
                            '''''''ARINVOICE1header.Fields.FieldByName("DATEINVC").SetValue(DateSerial(2020, 7, 26, False) ' Document Date
                            'If .INVDESC & "" <> "" Then
                            '    ARINVOICE1header.Fields.FieldByName("INVCDESC").SetValue(.INVDESC, False) ' Document Description
                            'End If
                            lnDay = DateSerial(.YEAR, .MONTH + 1, 0).Day
                            lnMonth = DateSerial(.YEAR, .MONTH + 1, 0).Month
                            lnYear = DateSerial(.YEAR, .MONTH + 1, 0).Year
                            ARINVOICE1header.Fields.FieldByName("DATEINVC").SetValue(DateSerial(lnYear, lnMonth, lnDay), False) ' Document Date
                            temp = ARINVOICE1detail1.Exists
                            ARINVOICE1detail1.RecordClear()
                            ' ************************************************
                            ' Header end
                            ' ************************************************
                        End If
                        If (.CONSUMPTION = 0) And (PbIncludeZeroConsumption = False) Then
                            ' Ignore line
                        Else
                            LineNum += 1
                                temp = ARINVOICE1detail1.Exists
                                ARINVOICE1detail1.RecordCreate(0)
                                ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                                ARINVOICE1detail1.Process()
                                ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue(.WATER, False) ' Item Number
                                ARINVOICE1detail1.Fields.FieldByName("QTYINVC").SetValue(Format(.CONSUMPTION, "0.00000"), False) ' Quantity
                                If Not ((.SameIDCust = False) And (.FirstIdCust = True)) Then
                                    ' if it is multiple lines use the comment
                                    ARINVOICE1detail1.Fields.FieldByName("COMMENT").SetValue(.INVDESC, False) ' Quantity
                                End If

                                ARINVOICE1detail1.Insert()
                                ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                                ARINVOICE1detail1.Read(False)
                            End If
                            If .SameIDCust = False Then

                                If (.GARBAGE.ToString.ToUpper <> "GN") And (.GARBAGE.ToString.ToUpper <> "") Then
                                    ' Has Garbage
                                    LineNum += 1
                                    temp = ARINVOICE1detail1.Exists
                                    ARINVOICE1detail1.RecordCreate(0)
                                    ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                                    ARINVOICE1detail1.Process()
                                    ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue(.GARBAGE, False) ' Item Number
                                    ARINVOICE1detail1.Insert()
                                    ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                                    ARINVOICE1detail1.Read(False)
                                End If
                            ' ignore line
                            If pbIncludeMAF = True Then
                                ' ********************************************************************************************************
                                ' Add MAF
                                LineNum += 1
                                temp = ARINVOICE1detail1.Exists
                                ARINVOICE1detail1.RecordCreate(0)
                                ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                                ARINVOICE1detail1.Process()
                                ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue("MAF", False) ' Item Number
                                ARINVOICE1detail1.Fields.FieldByName("QTYINVC").SetValue(Format(1, "0.00000"), False) ' Quantity
                                ARINVOICE1detail1.Insert()
                                ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                                ARINVOICE1detail1.Read(False)
                            End If
                            ' ********************************************************************************************************
                            If (.MONTHLYBALANCE > 0) And (.BALANCE > 0) And .INTEREST = "Y" Then
                                LineNum += 1
                                temp = ARINVOICE1detail1.Exists
                                ARINVOICE1detail1.RecordCreate(0)
                                ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                                ARINVOICE1detail1.Process()
                                ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue("LATEPMT", False) ' Item Number
                                ARINVOICE1detail1.Fields.FieldByName("QTYINVC").SetValue(Format(.MONTHLYBALANCE, "0.00000"), False) ' Quantity
                                ARINVOICE1detail1.Insert()
                                ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                                ARINVOICE1detail1.Read(False)

                            End If


                            '' BALANCE FORWARD
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("BALANCE", False) ' Optional Field
                                ARINVOICE1detail3.Fields.FieldByName("VALIFNUM").SetValue(.BALANCE, False) ' Number
                                ARINVOICE1detail3.Insert()
                                ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("BALANCE", False) ' Optional Field
                                ARINVOICE1detail3.Read(False)


                            '' MONTH
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("MONTH", False) ' Optional Field
                            ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(.MONTH.ToString.Trim, False) ' Text Value
                            ARINVOICE1detail3.Insert()
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("MONTH", False) ' Optional Field
                            ARINVOICE1detail3.Read(False)

                            '' Year
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("YEAR", False) ' Optional Field
                            ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(.YEAR.ToString.Trim, False) ' Text Value
                            ARINVOICE1detail3.Insert()
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("YEAR", False) ' Optional Field
                            ARINVOICE1detail3.Read(False)

                            '' Interest
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PCINT", False) ' Optional Field
                            ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(PsPenaltyPercent, False) ' Text Value
                            ARINVOICE1detail3.Insert()
                            ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PCINT", False) ' Optional Field
                            ARINVOICE1detail3.Read(False)

                            Try
                                ARINVOICE1header.Insert()
                                ARINVOICE1detail1.Read(False)
                                ARINVOICE1detail1.Read(False)
                                ARINVOICE1batch.Read(False)
                                ARINVOICE1header.RecordCreate(2)
                                ARINVOICE1detail1.Cancel()
                            Catch ex2 As Exception

                            End Try
                            'LogFile("Created invoice for : " & .IDCUST)
                        End If
                    Else
                        pbErrorFound = True
                        psErrors &= "Unable to Created invoice for : " & .IDCUST & vbCrLf & "Consumption=0 or less than 0"
                        LogFile("Unable to Created invoice for : " & .IDCUST & vbCrLf & "Consumption=0 or less than 0")
                    End If
                End With
            Next

            PnNumberOfInvoices = CInt(ARINVOICE1batch.Fields.FieldByName("CNTINVCENT").Value)
        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
            'MyErrorMsg2(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
            'MyErrorHandler(ex)

        End Try
        Progress.Value = 1
        Progress.Visible = False


    End Sub
    Public Sub CreateInvoiceOthers(ByVal Progress As ProgressBar)
        StartSage()
        Progress.Maximum = AllOthers.Length
        Progress.Value = Progress.Maximum
        Progress.Value = 1
        Progress.Visible = True
        'MsgBox("2")
        Dim LineNum As Integer = 0

        Try


            ' TODO: To increase efficiency, comment out any unused DB links.
            Dim mDBLinkCmpRW As ACCPAC.Advantage.DBLink
            mDBLinkCmpRW = SageSess.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadWrite)

            Dim mDBLinkSysRW As ACCPAC.Advantage.DBLink
            mDBLinkSysRW = SageSess.OpenDBLink(DBLinkType.System, DBLinkFlags.ReadWrite)

            Dim lsTitle As String = "Late Payment Invoices for Others - "

            If Command.ToString <> "" Then
                lsTitle = "** Testing ** - "
            End If
            Dim temp As Boolean
            Dim lnDay As Integer = 0
            Dim lnMonth As Integer = 0
            Dim lnYear As Integer = 0

            Dim ARINVOICE1batch As ACCPAC.Advantage.View
            Dim ARINVOICE1header As ACCPAC.Advantage.View
            Dim ARINVOICE1detail1 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail2 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail3 As ACCPAC.Advantage.View
            Dim ARINVOICE1detail4 As ACCPAC.Advantage.View
            ARINVOICE1batch = mDBLinkCmpRW.OpenView("AR0031")
            ARINVOICE1header = mDBLinkCmpRW.OpenView("AR0032")
            ARINVOICE1detail1 = mDBLinkCmpRW.OpenView("AR0033")
            ARINVOICE1detail2 = mDBLinkCmpRW.OpenView("AR0034")
            ARINVOICE1detail3 = mDBLinkCmpRW.OpenView("AR0402")
            ARINVOICE1detail4 = mDBLinkCmpRW.OpenView("AR0401")

            ARINVOICE1batch.Compose({ARINVOICE1header})
            ARINVOICE1header.Compose({ARINVOICE1batch, ARINVOICE1detail1, ARINVOICE1detail2, ARINVOICE1detail3, Nothing})
            ARINVOICE1detail1.Compose({ARINVOICE1header, ARINVOICE1batch, ARINVOICE1detail4})
            ARINVOICE1detail2.Compose({ARINVOICE1header})
            ARINVOICE1detail3.Compose({ARINVOICE1header})
            ARINVOICE1detail4.Compose({ARINVOICE1detail1})

            ARINVOICE1batch.Browse("((BTCHSTTS = 1) OR (BTCHSTTS = 7))", 1)
            Dim ARINVCPOST2 As ACCPAC.Advantage.View
            ARINVCPOST2 = mDBLinkCmpRW.OpenView("AR0048")

            ARINVOICE1batch.RecordCreate(1)
            ARINVOICE1batch.Fields.FieldByName("PROCESSCMD").SetValue("1", False) ' Process Command


            ARINVOICE1batch.Process()
            ARINVOICE1batch.Read(False)
            ARINVOICE1header.RecordCreate(2)
            ARINVOICE1detail1.Cancel()
            ARINVOICE1batch.Fields.FieldByName("BTCHDESC").SetValue(lsTitle & Now.ToShortDateString, False) ' Description
            ARINVOICE1batch.Update()
            ' ******************************************************
            ' * August 21, 2020
            ' Changed to acomodate groups
            '*******************************************************
            'For x As Integer = 0 To AllTrucked.Length - 1
            '    With AllTrucked(x)

            For x As Integer = 0 To AllOthers.Length - 1
                With AllOthers(x)
                    Progress.Value = x + 1
                    LineNum = 0
                    ' ************************************************
                    ' Header start
                    ' ************************************************
                    ARINVOICE1header.Fields.FieldByName("IDCUST").SetValue(.IDCUST, False) ' Customer Number
                    ARINVOICE1header.Fields.FieldByName("PROCESSCMD").SetValue("4", False) ' Process Command
                    ARINVOICE1header.Process()
                    '''''''ARINVOICE1header.Fields.FieldByName("DATEINVC").SetValue(DateSerial(2020, 7, 26, False) ' Document Date
                    'If .INVDESC & "" <> "" Then
                    '    ARINVOICE1header.Fields.FieldByName("INVCDESC").SetValue(.INVDESC, False) ' Document Description
                    'End If
                    lnDay = DateSerial(.YEAR, .MONTH + 1, 0).Day
                    lnMonth = DateSerial(.YEAR, .MONTH + 1, 0).Month
                    lnYear = DateSerial(.YEAR, .MONTH + 1, 0).Year
                    ARINVOICE1header.Fields.FieldByName("DATEINVC").SetValue(DateSerial(lnYear, lnMonth, lnDay), False) ' Document Date
                    temp = ARINVOICE1detail1.Exists
                    ARINVOICE1detail1.RecordClear()
                    ' ************************************************
                    ' Header end
                    ' ************************************************

                    LineNum += 1
                    temp = ARINVOICE1detail1.Exists
                    ARINVOICE1detail1.RecordCreate(0)
                    ARINVOICE1detail1.Fields.FieldByName("PROCESSCMD").SetValue("0", False) ' Process Command Code
                    ARINVOICE1detail1.Process()
                    ARINVOICE1detail1.Fields.FieldByName("IDITEM").SetValue("LATEPMT", False) ' Item Number
                    ARINVOICE1detail1.Fields.FieldByName("QTYINVC").SetValue(Format(.BALANCE, "0.00000"), False) ' Quantity
                    ARINVOICE1detail1.Insert()
                    ARINVOICE1detail1.Fields.FieldByName("CNTLINE").SetValue((LineNum * -1).ToString, False) ' Line Number
                    ARINVOICE1detail1.Read(False)


                    '' BALANCE FORWARD
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("BALANCE", False) ' Optional Field
                    ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(.BALANCE.ToString.Trim, False) ' Text Value
                    ARINVOICE1detail3.Insert()
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("BALANCE", False) ' Optional Field
                    ARINVOICE1detail3.Read(False)

                    '' MONTH
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("MONTH", False) ' Optional Field
                    ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(.MONTH.ToString.Trim, False) ' Text Value
                    ARINVOICE1detail3.Insert()
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("MONTH", False) ' Optional Field
                    ARINVOICE1detail3.Read(False)

                    '' Year
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("YEAR", False) ' Optional Field
                    ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(.YEAR.ToString.Trim, False) ' Text Value
                    ARINVOICE1detail3.Insert()
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("YEAR", False) ' Optional Field
                    ARINVOICE1detail3.Read(False)

                    '' Interest
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PCINT", False) ' Optional Field
                    ARINVOICE1detail3.Fields.FieldByName("VALIFTEXT").SetValue(PsPenaltyPercent, False) ' Text Value
                    ARINVOICE1detail3.Insert()
                    ARINVOICE1detail3.Fields.FieldByName("OPTFIELD").SetValue("PCINT", False) ' Optional Field
                    ARINVOICE1detail3.Read(False)

                    Try
                        ARINVOICE1header.Insert()
                        ARINVOICE1detail1.Read(False)
                        ARINVOICE1detail1.Read(False)
                        ARINVOICE1batch.Read(False)
                        ARINVOICE1header.RecordCreate(2)
                        ARINVOICE1detail1.Cancel()
                    Catch ex2 As Exception

                    End Try
                    'LogFile("Created invoice for : " & .IDCUST)
                End With
            Next
            PnNumberOfInvoices = CInt(ARINVOICE1batch.Fields.FieldByName("CNTINVCENT").Value)
        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        End Try
        Progress.Value = 1
        Progress.Visible = False
    End Sub
    Public Sub myErrorMsg2(ByVal myex As Exception, ByVal mysub As String)
        Dim lsBuildError As String = ""
        If myex.InnerException IsNot Nothing Then
            lsBuildError = "Inner:" & myex.InnerException.Message.ToString & vbCrLf
        End If

        MsgBox(lsBuildError & myex.Message & vbCrLf & vbCrLf & "Error on Sub/Function:  " & mysub & vbCrLf & vbCrLf & myex.StackTrace)
    End Sub
    Private Sub MyErrorHandler(e As Exception)
        pbErrorFound = True
        Errors = ""
        Warnings = ""
        Messages = ""
        'MsgBox(e.Message)
        If SageSess.Errors Is Nothing Then
            Errors &= e.Message & "-"
            MsgBox("Error: " & Errors)
            LogFile("Error: " & Errors & vbCrLf, True)
        Else
            If SageSess.Errors.Count = 0 Then
                Errors &= e.Message
                MsgBox("COM Error: " & Errors)
                LogFile("COM Error: " & Errors & vbCrLf, True)
            Else
                CopyErrors()
                If Errors.Trim <> "" Then
                    MsgBox("Sage Error: " & Errors)
                    LogFile("Error: " & Errors & vbCrLf, True)
                End If
                If Warnings.Trim <> "" Then
                    MsgBox("Warnings: " & Warnings)
                    LogFile("Warnings: " & Warnings & vbCrLf, True)
                End If
                If Messages.Trim <> "" Then
                    MsgBox("Messages: " & Messages)
                    LogFile("Messages: " & Messages & vbCrLf, True)
                End If
            End If
        End If
    End Sub
    Private Sub CopyErrors()
        Dim iIndex As Integer

        For iIndex = 0 To SageSess.Errors.Count - 1
            Select Case SageSess.Errors(iIndex).Priority
                Case ErrorPriority.[Error], ErrorPriority.SevereError, ErrorPriority.Security
                    Errors &= SageSess.Errors(iIndex).Message & " - "
                    Exit Select
                Case ErrorPriority.Warning
                    Warnings &= SageSess.Errors(iIndex).Message & " - "
                    Exit Select
                Case ErrorPriority.Message
                    Messages &= SageSess.Errors(iIndex).Message & " - "
                    Exit Select
                Case Else
                    Errors &= SageSess.Errors(iIndex).Message & " - "
                    Exit Select

            End Select
            'allErrors &= SageSess.Errors(iIndex).Message
        Next
        SageSess.Errors.Clear()
    End Sub

End Module
