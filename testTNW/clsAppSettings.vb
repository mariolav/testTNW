Imports System.Collections
Imports System.IO
Imports System.Xml
Public Class clsAppSettings
    Private _Settings As New Hashtable
    Private _fiSettingsFile As FileInfo

    Default Public Property Item(ByVal strKey As String, Optional ByVal DefaultVal As Object = Nothing) As Object
        Get
            If Not _Settings.Contains(strKey.ToLower) Then
                Return DefaultVal
            Else
                Return _Settings.Item(strKey.ToLower)
            End If
        End Get
        Set(ByVal Value As Object)
            _Settings.Item(strKey.ToLower) = Value
        End Set
    End Property

    Public Sub New(ByVal strFileName As String, Optional ByVal bReadSettings As Boolean = True)
        _fiSettingsFile = New FileInfo(strFileName)
        If bReadSettings Then ReadSettings()
    End Sub

    Public Sub ReadSettings()
        Dim xReader As XmlTextReader
        Try
            'if no file exists then just exit
            If Not _fiSettingsFile.Exists Then Exit Sub
            'else read properties

            xReader = New XmlTextReader(_fiSettingsFile.ToString)

            With xReader
                .Read()
                .ReadStartElement("Settings")
                .Read()

                'clear settings
                _Settings.Clear()
                'Dim de As DictionaryEntry
                Dim key, value As String
                Do While True
                    'loop through adding items to the internal hashtable
                    key = .GetAttribute("key")
                    value = .GetAttribute("value")
                    .ReadStartElement("Setting")
                    _Settings.Add(key, value)
                    .Read()
                    If .Name <> "Setting" Then Exit Do
                Loop
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "There was an error reading application settings")
        Finally
            If Not IsNothing(xReader) Then xReader.Close()
        End Try
    End Sub

    Public Sub WriteSettings()
        Dim XWriter As XmlTextWriter
        Try
            XWriter = New XmlTextWriter(_fiSettingsFile.ToString, System.Text.Encoding.Default)
            With XWriter
                .Indentation = 4
                .Formatting = Xml.Formatting.Indented
                'write <Settings> begin tag
                .WriteStartElement("Settings")
                Dim de As DictionaryEntry
                'loop & write out each item
                For Each de In _Settings
                    'write <Setting> tag
                    .WriteStartElement("Setting")
                    'write attributes 
                    .WriteAttributeString("key",
                                           de.Key)
                    .WriteAttributeString("value" _
                                        , de.Value)
                    .WriteEndElement()
                Next
                .WriteEndElement()
                'close streams
                .Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "There was an error saving " & "application settings")
        Finally
            If Not IsNothing(XWriter) Then
                XWriter.Close()
            End If
        End Try
    End Sub
End Class
