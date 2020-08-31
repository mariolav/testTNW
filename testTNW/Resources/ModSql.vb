Imports System.Data.SqlClient
Imports System.IO

Module modSql
#Region "Sql Functions and Create Database and tables"
    Public Function getValueFromSQL(ByVal lsSql As String) As String
        ' ***************************************************
        ' Get last number used
        ' *************************************************** 
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(lsSql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Dim lsTemp As String = ""
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            While mydata.Read
                If mydata.HasRows = True Then
                    lsTemp = mydata(0).ToString & ""
                End If
            End While
        Catch sqlex As SqlException
            myErrorMsg(sqlex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & lsSql)
        Catch ex As Exception
            myErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & lsSql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
        End Try
        Return lsTemp
    End Function
    Public Function getExportSQL(ByVal lsSql As String) As String
        ' ***************************************************
        ' Get last number used
        ' *************************************************** 
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(lsSql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Dim lsTemp As String = ""
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            If mydata.HasRows Then
                Using writer As StreamWriter = New StreamWriter(PsFolder & "\WaterExport.txt", False)
                    While mydata.Read
                        writer.Write(Replace(Replace(mydata(0).ToString, vbLf, " "), vbCr, " ") & "" & vbCrLf)
                    End While
                End Using

            End If
        Catch sqlex As SqlException
            myErrorMsg(sqlex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & lsSql)
        Catch ex As Exception
            myErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & lsSql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
        End Try
        Return lsTemp
    End Function
    Public Function fnSqlCheck(mySql As String) As String
        ' ***************************************************
        ' Insert a new item to temp table or delete. Use any sql
        ' ***************************************************
        Dim lsBad As String = ""
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(mySql, myConn)
        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            LogFile(ex.Message & vbCrLf & mySql & " failed check")
            lsBad = mySql & " failed check" & vbCrLf
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
        Return lsBad
    End Function
    Public Sub sqlExe(mySql As String)
        ' ***************************************************
        ' Insert a new item to temp table or delete. Use any sql
        ' ***************************************************

        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(mySql, myConn)
        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            myErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & mySql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
    End Sub
    Public Function fnsqlExe(mySql As String) As Integer
        ' ***************************************************
        ' Insert a new item to temp table or delete. Use any sql
        ' ***************************************************
        Dim x As Integer
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(mySql, myConn)
        Try
            myConn.Open()
            x = myCommand.ExecuteNonQuery()
        Catch ex As Exception
            myErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & mySql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
        Return x
    End Function
    Public Function fnNumberOfRecords(ByVal Sql As String) As Long
        ' ***************************************************
        ' Check if customers exist
        ' ***************************************************
        'MsgBox(Sql)
        Dim llFound As Long = 0
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(Sql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            While mydata.Read
                llFound += 1
            End While
        Catch sqlex As SqlException
            myErrorMsg(sqlex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & Sql)
        Catch ex As Exception
            myErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & Sql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
        End Try
        Return llFound
    End Function



    Public Function fnCheckRecordExist(ByVal Sql As String) As Boolean
        ' ***************************************************
        ' Check if customers exist
        ' ***************************************************
        'MsgBox(Sql)
        Dim lbFound As Boolean = False
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(Sql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            Dim x As Integer = 0
            'ReDim Preserve psCust(x)
            While mydata.Read
                If mydata.HasRows = True Then
                    lbFound = True
                End If
            End While
        Catch sqlex As SqlException
            myErrorMsg(sqlex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & Sql)
        Catch ex As Exception
            myErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & Sql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
        End Try
        Return lbFound
    End Function
    Public Function fnGetSqlRecords(ByVal Sql As String) As String
        ' ***************************************************
        ' Check if customers exist
        ' ***************************************************
        'MsgBox(Sql)
        Dim lsFound As String = ""
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(Sql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            Dim x As Integer = 0
            If mydata.HasRows = True Then
                While mydata.Read
                    lsFound &= mydata(0).ToString & vbCrLf
                End While
            End If
        Catch sqlex As SqlException
            MyErrorMsg(sqlex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & Sql)
        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & Sql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
        End Try
        Return lsFound
    End Function

#End Region
    Public Sub CreateMainDatabase()
        ' ***************************************************
        ' Check if Database MNP exists. 
        ' If it doesn't, create it
        ' ***************************************************
        Dim myConn As SqlConnection = New SqlConnection(connectionString)
        Dim Str As String = "if not exists (select name from master.sys.databases where name='MNP') CREATE DATABASE [MNP]"
        '
        Dim myCommand As SqlCommand = New SqlCommand(Str, myConn)
        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
        myCommand.Dispose()
        myConn.Dispose()
    End Sub
    Public Sub createTable(ByVal TestSql As String, ByVal CreateSql As String)
        ' ***************************************************
        ' Check if MANTRACATG exists. If it doesn't, create it
        ' ***************************************************
        Dim myConn As SqlConnection = New SqlConnection(connectionString)
        Dim myCommand As SqlCommand = New SqlCommand(TestSql, myConn)
        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            Try
                myCommand = New SqlCommand(CreateSql, myConn)
                myCommand.ExecuteNonQuery()
            Catch ex2 As Exception

            End Try
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
        myCommand.Dispose()
        myConn.Dispose()
    End Sub
    Public Sub GetMetered(ByVal sql As String)
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(sql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Dim x As Integer
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            AllMetered = Nothing
            While mydata.Read
                If mydata.HasRows = True Then
                    ReDim Preserve AllMetered(x)
                    With AllMetered(x)
                        .IDCUST = mydata("IDCUST").ToString.Trim
                        .OLDACC = mydata("OLDACC").ToString.Trim
                        .ACTREAD = CLng(mydata("ACTREAD").ToString)
                        .PREREAD = CLng(mydata("PREREAD").ToString)
                        .WATER = mydata("WATER").ToString.Trim
                        .GARBAGE = mydata("GARBAGE").ToString.Trim
                        .MONTH = mydata("MONTH").ToString
                        .YEAR = mydata("YEAR").ToString
                        .METER = mydata("METER").ToString
                        .BALANCE = CDbl(mydata("BALANCE").ToString)
                        .MONTHLYBALANCE = CDbl(mydata("MONTHLYBALANCE").ToString)
                        .INTEREST = mydata("INTEREST").ToString
                        .MULTITOT = CLng(mydata("MULTITOT").ToString)
                        .SameIDCust = False
                        .FirstIdCust = True
                    End With
                    x += 1
                End If
            End While
            If Not IsNothing(AllMetered) Then
                For x = 1 To AllMetered.Length - 1
                    AllMetered(x - 1).SameIDCust = (AllMetered(x - 1).IDCUST = AllMetered(x).IDCUST)
                    AllMetered(x).FirstIdCust = (AllMetered(x - 1).IDCUST <> AllMetered(x).IDCUST)
                Next
                AllMetered(AllMetered.Length - 1).SameIDCust = False

                If Command.ToString <> "" Then
                    Using writer As StreamWriter = New StreamWriter(PsFolder & "\TESTMetered.CSV", False)
                        For x = 0 To AllMetered.Length - 1
                            writer.Write(String.Format("{0},{1},{2}" & vbCrLf, AllMetered(x).IDCUST, AllMetered(x).SameIDCust, AllMetered(x).FirstIdCust))
                        Next
                    End Using
                End If
            End If

        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name & vbCrLf & sql)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
            adapter.Dispose()
        End Try
    End Sub
    Public Sub GetTrucked(ByVal sql As String)
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(sql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Dim x As Integer
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            AllTrucked = Nothing
            While mydata.Read
                If mydata.HasRows = True Then
                    ReDim Preserve AllTrucked(x)
                    With AllTrucked(x)
                        .IDCUST = mydata("IDCUST").ToString.Trim
                        .OLDACC = mydata("OLDACC").ToString.Trim
                        .CONSUMPTION = CLng(mydata("CONSUMPTION").ToString)
                        .WATER = mydata("WATER").ToString.Trim
                        .GARBAGE = mydata("GARBAGE").ToString.Trim
                        .MONTH = CByte(mydata("MONTH").ToString)
                        .YEAR = CInt(mydata("YEAR").ToString)
                        .INVDESC = mydata("INVDESC").ToString.Trim
                        .BALANCE = CDbl(mydata("BALANCE").ToString)
                        .MONTHLYBALANCE = CDbl(mydata("MONTHLYBALANCE").ToString)
                        .INTEREST = mydata("INTEREST").ToString
                        .MULTITOT = CLng(mydata("MULTITOT").ToString)
                        .SameIDCust = False
                        .FirstIdCust = True
                    End With
                    x += 1
                End If
            End While

            If Not IsNothing(AllTrucked) Then
                For x = 1 To AllTrucked.Length - 1
                    AllTrucked(x - 1).SameIDCust = (AllTrucked(x - 1).IDCUST = AllTrucked(x).IDCUST)
                    AllTrucked(x).FirstIdCust = (AllTrucked(x - 1).IDCUST <> AllTrucked(x).IDCUST)
                Next
                AllTrucked(AllTrucked.Length - 1).SameIDCust = False
                If Command.ToString <> "" Then
                    Using writer As StreamWriter = New StreamWriter(PsFolder & "\TESTTrucked.CSV", False)
                        For x = 0 To AllTrucked.Length
                            writer.Write(String.Format("{0},{1},{2}" & vbCrLf, AllTrucked(x).IDCUST, AllTrucked(x).SameIDCust, AllTrucked(x).FirstIdCust))
                        Next
                    End Using
                End If
            End If
        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
            adapter.Dispose()
        End Try
    End Sub
    Public Sub GetOthers(ByVal sql As String)
        Dim myConn As SqlConnection = New SqlConnection(CONN)
        Dim myCommand As SqlCommand = New SqlCommand(sql, myConn)
        Dim mydata As SqlDataReader
        Dim adapter As New SqlDataAdapter
        Dim x As Integer
        Try
            myConn.Open()
            adapter.SelectCommand = myCommand
            mydata = myCommand.ExecuteReader()
            AllOthers = Nothing
            While mydata.Read
                If mydata.HasRows = True Then
                    ReDim Preserve AllOthers(x)
                    With AllOthers(x)
                        .IDCUST = mydata("IDCUST").ToString.Trim
                        .MONTH = CByte(mydata("MONTH").ToString)
                        .YEAR = CInt(mydata("YEAR").ToString)
                        .BALANCE = CDbl(mydata("BALANCE").ToString)
                    End With
                    x += 1
                End If
            End While

        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
            myCommand.Dispose()
            myConn.Dispose()
            adapter.Dispose()
        End Try
    End Sub
    Public Sub populateGrid(ByVal selectCommand As String, ByVal myGrid As DataGridView, ByVal myForm As Form, ByVal myBind As BindingSource)
        If (selectCommand & "").Trim = "" Then
            Exit Sub
        End If
        'If Command.ToString.ToUpper = "DEBUG" Then
        ' Using writer As StreamWriter = New StreamWriter(Application.StartupPath & "\" & myGrid.Tag.ToString & "_" & myGrid.Name & ".txt")
        'writer.Write(selectCommand)
        'End Using
        'End If

        'myGrid.PrimaryGrid.ClearAll()
        myForm.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            Dim dataAdapter = New SqlDataAdapter(selectCommand, CONN)

            Dim commandBuilder As New SqlCommandBuilder(dataAdapter)

            ' Populate a new data table and bind it to the BindingSource.
            Dim table As New DataTable()
            table.Locale = System.Globalization.CultureInfo.InvariantCulture

            myGrid.Visible = False
            myGrid.DataSource = Nothing
            myGrid.Rows.Clear()
            myGrid.DataSource = myBind
            dataAdapter.SelectCommand.CommandTimeout = pnTimeout
            dataAdapter.Fill(table)
            myBind.DataSource = table
            dataAdapter.Dispose()
            myGrid.Visible = True
        Catch ex As SqlException
            MessageBox.Show(ex.ErrorCode.ToString & " " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                MessageBox.Show(ex.InnerException.Message)
            End If
        End Try
        myForm.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

End Module
