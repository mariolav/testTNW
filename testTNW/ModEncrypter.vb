Imports System.Security.Cryptography
Imports System.IO

Module modEncrypter
    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform


    Public Function fnEncrypt(ByVal sPlainText As String) As String
        initCrypt()
        Dim lsTemp As String = ""
        If Not String.IsNullOrEmpty(sPlainText) Then
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(enc.GetBytes(sPlainText), 0, sPlainText.Length)
            cryptoStream.FlushFinalBlock()
            lsTemp = Convert.ToBase64String(memoryStream.ToArray())
            memoryStream.Close()
            cryptoStream.Close()
        End If
        Return lsTemp
    End Function

    Public Function fnDecrypt(ByVal sText As String) As String
        If sText = "" Then
            Return ""
            Exit Function
        End If
        initCrypt()
        Try
            Dim lsTemp As String = ""
            Dim cypherTextBytes As Byte() = Convert.FromBase64String(sText)
            Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes(cypherTextBytes.Length) As Byte
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            Return enc.GetString(plainTextBytes, 0, decryptedByteCount)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub initCrypt()
        Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        enc = New System.Text.UTF8Encoding
        encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)
        decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)

    End Sub
End Module

