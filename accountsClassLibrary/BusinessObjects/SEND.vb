Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Linq
Imports System.Guid
Imports System.DateTime
Imports System.IO
Imports System.Convert
Imports System.Uri

Public Class SendXML

    Public Class MyGlobals
        ' Endpoint για δοκιμή
        Public Shared testHostERP As String = "https://test.gsis.gr/esbpilot/kedeProgressService"
        Public Shared HostERP As String = "https://ked.gsis.gr/esb/kedeProgressService"
    End Class

    ' ----------------------------------------------------------------------
    ' Η βασική συνάρτηση για την αποστολή του SOAP XML
    ' --------------------------
    'Imports System.Net.Http
    'Imports System.Net.Http.Headers
    'Imports System.Text
    'Imports System.Threading.Tasks
    'Imports Newtonsoft.Json ' Χρειάζεται η εγκατεστημένη βιβλιοθήκη Newtonsoft.Json

    ' OAuth Constants (Αντικαταστήστε με τα δικά σας στοιχεία)
    Const AccessTokenUri As String = "https://test.gsis.gr/oauth2server/oauth/token"
    Const ClientId As String = "YOUR_CLIENT_ID_HERE"
    Const ClientSecret As String = "YOUR_CLIENT_SECRET_HERE"

    Async Function SendXML_oAuth2(bodydata As String) As Task(Of String)
        Dim rslt As String = ""
        Dim R1 As String = ""
        Dim uri As String = MyGlobals.testHostERP ' Το τελικό SOAP endpoint

        Dim accessToken As String = ""

        Try
            ' ----------------------------------------------------------------------
            ' 1. ΒΗΜΑ: ΛΗΨΗ ACCESS TOKEN (OAuth 2.0 Client Credentials Flow)
            ' ----------------------------------------------------------------------
            Using tokenClient As New HttpClient()
                Dim formContent As New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"grant_type", "client_credentials"}, ' Τυπικός τύπος για A2A κλήσεις
                {"client_id", ClientId},
                {"client_secret", ClientSecret}
            })

                Dim tokenResponse As HttpResponseMessage = Await tokenClient.PostAsync(AccessTokenUri, formContent)
                Dim tokenResponseString As String = Await tokenResponse.Content.ReadAsStringAsync()

                If tokenResponse.IsSuccessStatusCode Then
                    ' Αποκωδικοποίηση της απάντησης JSON
                    'Dim jsonResponse = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(tokenResponseString)

                    'If jsonResponse.ContainsKey("access_token") Then
                    '    accessToken = jsonResponse("access_token").ToString()
                    'Else
                    '    Throw New Exception($"OAuth Error: Access Token not found: {tokenResponseString}")
                    'End If
                Else
                    ' Σφάλμα κατά τη λήψη του token
                    Throw New Exception($"OAuth Token Failure: HTTP Status {tokenResponse.StatusCode}. Response: {tokenResponseString}")
                End If
            End Using

            ' ----------------------------------------------------------------------
            ' 2. ΒΗΜΑ: ΑΠΟΣΤΟΛΗ SOAP ΑΙΤΗΜΑΤΟΣ ΜΕ ACCESS TOKEN
            ' ----------------------------------------------------------------------

            Dim client As New HttpClient() ' Νέο client για το SOAP request

            ' ΠΡΟΣΘΗΚΗ: Προσθέτουμε το Access Token ως Bearer στο HTTP Header
            client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

            Dim finalXmlString As String = bodydata
            Dim finalBytedata As Byte() = Encoding.UTF8.GetBytes(finalXmlString)

            Using content As ByteArrayContent = New ByteArrayContent(finalBytedata)
                content.Headers.ContentType = New MediaTypeHeaderValue("text/xml")

                Dim tmpstr As String = "retrieveKedeAmount"
                content.Headers.Add("SOAPAction", tmpstr)

                Dim response As HttpResponseMessage = Await client.PostAsync(uri, content)

                R1 = Await response.Content.ReadAsStringAsync()
                If Not response.IsSuccessStatusCode Then
                    Throw New Exception($"HTTP Status: {response.StatusCode} ({response.ReasonPhrase}). " &
                                    $"ΛΕΠΤΟΜΕΡΕΙΕΣ ΣΦΑΛΜΑΤΟΣ (XML Fault Body): {R1}")
                End If
            End Using
            rslt = R1
        Catch ex As Exception
            R1 = "Error: " & ex.Message
        End Try

        Return R1
    End Function
    Async Function SendXML(bodydata As String, id As String) As Task(Of String)

        Dim rslt As String = ""
        Dim R1 As String = ""
        Dim client As New HttpClient()
        Dim typeapp As String = File.ReadAllText("params\typeapp.param")   ' Test or Release
        typeapp = typeapp.Trim().Replace("TypeApp = ", "").Replace("//Test or Release", "")
        Dim uri As String = MyGlobals.testHostERP
        If (typeapp.Equals("Release")) Then uri = MyGlobals.HostERP

        Dim service As String = ""
        Dim afm As New AFMFl
        afm.Read(id)
        service = afm.Fields.auditRecord.Status.Name


        Try
            Dim finalXmlString As String = bodydata
            Dim finalBytedata As Byte() = Encoding.UTF8.GetBytes(finalXmlString)
            Using content As ByteArrayContent = New ByteArrayContent(finalBytedata)
                content.Headers.ContentType = New MediaTypeHeaderValue("text/xml")
                'content.Headers.Add("SOAPAction", "retrieveKedeAmount")
                'content.Headers.Add("SOAPAction", "retrieveNames")
                content.Headers.Add("SOAPAction", service)
                Dim response As HttpResponseMessage = Await client.PostAsync(uri, content)

                R1 = Await response.Content.ReadAsStringAsync()
                'R1 = "<Service>" + service + "</Service>" + R1
                If Not response.IsSuccessStatusCode Then
                    ' Αν το status ΔΕΝ είναι επιτυχές, πετάμε εξαίρεση με το Fault Body
                    Throw New Exception($"HTTP Status: {response.StatusCode} ({response.ReasonPhrase}). " &
                                    $"ΛΕΠΤΟΜΕΡΕΙΕΣ ΣΦΑΛΜΑΤΟΣ (XML Fault Body): {R1}")
                End If
            End Using
            rslt = R1
        Catch ex As Exception
            R1 = "Error: " & ex.Message
        End Try
        Return R1
    End Function

    Async Function SendXML_Release(User As String, pass As String, bodydata As String) As Task(Of String)
        Dim rslt As String = ""
        Dim R1 As String = ""
        Dim client As New HttpClient()
        Dim uri As String = MyGlobals.testHostERP

        ' 1. Ορισμοί για WS-Security (Timestamp & UsernameToken)
        Dim soapNs As XNamespace = "http://schemas.xmlsoap.org/soap/envelope/"

        ' Δημιουργία μοναδικών IDs
        Dim uniqueId As String = "UT-" & Guid.NewGuid().ToString("N")
        Dim timestampId As String = "TS-" & Guid.NewGuid().ToString("N")

        ' Δημιουργία χρόνων σε μορφή UTC (ΑΠΑΡΑΙΤΗΤΟ για Timestamp)
        Dim createdTime As String = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
        Dim expiresTime As String = DateTime.UtcNow.AddMinutes(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")

        Try
            ' --------------------------------------------------------------------------------
            ' 2. Construct the WS-Security Header XML 
            ' Περιλαμβάνει: Timestamp, UsernameToken, και σωστές αλλαγές γραμμής ('_')
            ' --------------------------------------------------------------------------------
            Dim securityHeader As XElement =
<wsse:Security xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"
    xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"
    soapenv:mustUnderstand="1"
    xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/">
    
    ' !!! ΑΥΤΟ ΤΟ BLOCK ΠΡΕΠΕΙ ΝΑ ΑΦΑΙΡΕΘΕΙ ΕΝΤΕΛΩΣ Ή ΝΑ ΣΧΟΛΙΑΣΤΕΙ !!!
    ' <wsu:Timestamp wsu:Id=<%= timestampId %>>  
    '    <wsu:Created><%= createdTime %></wsu:Created>
    '    <wsu:Expires><%= expiresTime %></wsu:Expires>
    ' </wsu:Timestamp>

    <wsse:UsernameToken wsu:Id=<%= uniqueId %>>
        <wsse:Username><%= User %></wsse:Username>
        <wsse:Password Type="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText">
            <%= pass %>
        </wsse:Password>
    </wsse:UsernameToken>
</wsse:Security>

            ' 3. Προσθήκη του soapenv:mustUnderstand="1" (Δυναμικά, εκτός XML Literal)
            securityHeader.SetAttributeValue(soapNs + "mustUnderstand", "1")

            ' --------------------------------------------------------------------------------
            ' 4. Construct the full SOAP Envelope 
            ' --------------------------------------------------------------------------------
            Dim soapEnvelope As XElement =
            <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
                xmlns:ked="http://gsis.ggps.interoperability/KedeProgressInterface">
                <soapenv:Header>
                    <%= securityHeader %>
                </soapenv:Header>
                <soapenv:Body>
                    <%= XElement.Parse(bodydata) %>
                </soapenv:Body>
            </soapenv:Envelope>

            Dim finalXmlString As String = soapEnvelope.ToString()
            finalXmlString = File.ReadAllText("C:\temp\debug.txt")

            Dim finalBytedata As Byte() = Encoding.UTF8.GetBytes(finalXmlString)

            ' 5. Αποστολή του Request
            Using content As ByteArrayContent = New ByteArrayContent(finalBytedata)
                content.Headers.ContentType = New MediaTypeHeaderValue("text/xml")

                ' ΠΡΟΣΟΧΗ: Βάλτε εδώ το ακριβές όνομα της μεθόδου
                content.Headers.Add("SOAPAction", "https://ked.gsis.gr/esb/kedeProgressService")

                Dim response As HttpResponseMessage = Await client.PostAsync(uri, content)

                ' **ΚΡΙΣΙΜΗ ΔΙΟΡΘΩΣΗ ΓΙΑ ΤΟ ΣΦΑΛΜΑ 500**
                R1 = Await response.Content.ReadAsStringAsync() ' Διαβάζουμε το σώμα ΠΑΝΤΑ

                If Not response.IsSuccessStatusCode Then
                    ' Αν το status ΔΕΝ είναι επιτυχές, πετάμε εξαίρεση με το Fault Body
                    Throw New Exception($"HTTP Status: {response.StatusCode} ({response.ReasonPhrase}). " &
                                        $"ΛΕΠΤΟΜΕΡΕΙΕΣ ΣΦΑΛΜΑΤΟΣ (XML Fault Body): {R1}")
                End If
            End Using
            rslt = R1
        Catch ex As Exception
            ' Χειρισμός σφαλμάτων
            R1 = "Error: " & ex.Message
        End Try
        Return R1
    End Function


    ' ----------------------------------------------------------------------
    ' Example usage: (Χρησιμοποιήστε το για να τρέξετε τη δοκιμή)
    ' ----------------------------------------------------------------------

End Class

Public Class RestApiClient

    ''' <summary>
    ''' Πραγματοποιεί POST κλήση REST με Basic Authentication.
    ''' </summary>
    Public Async Function SendRestRequestAsync(
        fullUrl As String,
        jsonPayload As String,
        username As String,
        password As String) As Task(Of String)

        Using client As New HttpClient()

            ' Δημιουργία Basic Authentication Header
            Dim credentials As String = $"{username}:{password}"
            Dim credentialsBytes As Byte() = Encoding.UTF8.GetBytes(credentials)
            Dim base64Credentials As String = Convert.ToBase64String(credentialsBytes)

            client.DefaultRequestHeaders.Authorization =
                New AuthenticationHeaderValue("Basic", base64Credentials)

            ' Δημιουργία Content Body (JSON)
            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await client.PostAsync(fullUrl, content)

            Dim responseBody As String = Await response.Content.ReadAsStringAsync()

            If response.IsSuccessStatusCode Then
                Return responseBody
            Else
                Dim tmp As String = "Η κλήση απέτυχε με λογικό σφάλμα (errorRecord):" + responseBody
                Throw New HttpRequestException(tmp)
            End If
        End Using

    End Function

End Class

