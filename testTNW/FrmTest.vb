Public Class FrmTest
    Private Sub FrmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReadImport()
    End Sub
    Sub ReadImport()
        Dim lsT As String = ""
        Dim lsTemp As String = "Route: {0} Pg: {1} IDCap: {2} Reading: {3} Date: {4} Time: {5} Acc#: {6}"
        Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\Users\mario.lavignasse\Documents\Town of Norman Wells\Neptune\Waterimport.txt")
            Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            Reader.SetFieldWidths(2, 12, 4, 23, 13, 14, 10, 57, 6, 6, 320, 40, -1)
            ' 2,12,4,23,13,14,10,57,6,6,320,40,6
            ' We will use fields 0,2,4,6,8,9,11
            Dim cRow As String()
            While Not Reader.EndOfData
                Try
                    cRow = Reader.ReadFields()
                    lsT = String.Format(lsTemp, cRow(0), cRow(2), cRow(4), cRow(6), cRow(8), cRow(9), cRow(11))
                    MsgBox(lsT)
                Catch ex As Microsoft.VisualBasic.
                        FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub

End Class