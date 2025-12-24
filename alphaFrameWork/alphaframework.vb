Imports System.CodeDom.Compiler
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms

Public Class AlphaFramework

    Public Sub New()
        Dim MyFile As String = chkeckfolders("interface") + "language.txt"
        If File.Exists(MyFile) Then
            lang = File.ReadAllText(MyFile).Trim
            'Else
            '    File.WriteAllText(MyFile, "gr")
        End If
    End Sub

    Public lang As String = "gr"

    Public Function L(MyStr As String) As String
        Return MyStr
    End Function

    Public Function IsValidEmailFormat(ByVal s As String) As Boolean
        Try
            Dim a As New System.Net.Mail.MailAddress(s)
        Catch
            Return False
        End Try
        Return Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function


    Function GetProcessorId() As String
        Dim strProcessorId As String = String.Empty
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next
        Return strProcessorId
    End Function

    Function GetWindowsInfo() As String
        Dim r As String = ""
        With My.Computer.Info
            r = .OSPlatform + "-" + .OSFullName + "-" + .OSVersion
        End With
        Return r
    End Function

    Public Function ClearName(s As String) As String
        'Return s
        'Exit Function

        If s.Length > 0 Then
            Dim idx As Integer = s.IndexOf("@")
            If idx > 0 Then
                s = s.Substring(0, idx - 1)
            End If

            If s.Substring(0, 1) = "#" Then s = s.Substring(s.IndexOf("#") + 3).Trim
            If s.Length < 1 Then s = "..."
        End If

        Return s
    End Function
    Public Function SendDataToNet(buffer As Byte(), URL As String, Optional Port As Integer = 8888, Optional DelaySec As Integer = 1, Optional RecieveSw As Boolean = True) As String
        Try
            Dim Sock As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Sock.Connect(IPAddress.Parse(URL), Port)
            Sock.Send(buffer)

            Dim r As String = "OK"
            If RecieveSw Then
                Dim bufferRead(1024) As Byte
                Sock.Receive(bufferRead)
                Thread.Sleep(DelaySec * 1000)
                r = Encoding.UTF8.GetString(bufferRead, 0, bufferRead.Length).ToString.Trim
                Dim inx As Integer = r.IndexOf(vbNullChar)
                If inx > 0 Then
                    r = r.Substring(0, inx)
                Else
                    r = ""
                End If
            End If

            Sock.Shutdown(SocketShutdown.Both)

            Return r
        Catch ex As Exception
            Return "** Error Connection !!" + vbNewLine + ex.Message
            Exit Function
        End Try
    End Function

    Public Function getPageName(MyPage As String) As String
        Dim tmpName As String = System.IO.Path.GetFileName(MyPage)
        If tmpName.IndexOf(".") = -1 Then tmpName = tmpName + ".aspx"
        Return tmpName
    End Function

    Public Function StringInString(str As String, MyField As String, MetaDesc As String, Optional AlRight As Boolean = False) As String
        Dim res As Integer = -1
        res = str.Trim.IndexOf(MyField)
        If res > -1 Then
            Dim StringLength As Integer = str.Trim.Length
            Dim StopChar As Integer = -1
            Try
                Dim i As Integer
                For i = res + 3 To StringLength
                    If str.Substring(i, 1) <> " " Then
                        StopChar = i - res
                        Exit For
                    End If
                Next
            Catch ex As Exception
                StopChar = -1
            End Try

            If StopChar > 0 And MetaDesc.Length > StopChar Then
                MetaDesc = MetaDesc.Substring(0, StopChar)
            End If
            If AlRight Then
                If StopChar > 0 And MetaDesc.Length < StopChar Then
                    For i = MetaDesc.Length + 1 To StopChar
                        MetaDesc = " " + MetaDesc
                    Next
                End If
            End If
            If MetaDesc.Length = 0 Then MetaDesc = "   "
            If MetaDesc.Length = 1 Then MetaDesc = MetaDesc + "  "
            If MetaDesc.Length = 2 Then MetaDesc = MetaDesc + " "
            Dim MetaLength As Integer = MetaDesc.Length
            str = str.Trim.Substring(0, res) +
                  MetaDesc +
                  str.Trim.Substring(res + MetaLength, StringLength - (res + MetaLength))
        End If
        Return str
    End Function

    Public Function MakeNo(tmp As String, d As Integer) As Double
        Try
            tmp = tmp.Replace("%", "")
            tmp = tmp.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            tmp = tmp.Replace(",", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            Dim value As Double
            If Double.TryParse(tmp, value) Then
                Return Math.Round(CDbl(tmp), d)
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function MakeDate(dt As String) As DateTime
        Dim tmp As DateTime
        Try
            tmp = CDate(dt.Replace("%", ""))
        Catch ex As Exception
            'tmp = Now
        End Try
        Return tmp
    End Function

    Public Function ReplaceCaseNoSenc(SentenceString As String, FindString As String, ReplaceWith As String) As String
        Dim MyIndex As Integer = -1
        Dim StartString As String = ""
        Dim EndString As String = ""
        Do
            MyIndex = SentenceString.ToUpper.IndexOf(FindString.ToUpper)
            If MyIndex > 0 Then
                StartString = SentenceString.Substring(0, MyIndex)
                EndString = SentenceString.Substring(MyIndex + FindString.Length, SentenceString.Length - MyIndex - FindString.Length)
                SentenceString = StartString + ReplaceWith + EndString
            Else
                Exit Do
            End If
        Loop

        Return SentenceString
    End Function

    Public Function CSVRead(ByVal path As String) As DataTable
        Try
            Dim sr As New StreamReader(path)
            Dim fullFileStr As String = sr.ReadToEnd().Trim
            sr.Close()
            sr.Dispose()
            Dim lines As String() = fullFileStr.Split(ControlChars.Lf)
            Dim recs As New DataTable()
            Dim sArr As String() = lines(0).Split(","c)
            For Each s As String In sArr
                recs.Columns.Add(New DataColumn())
            Next
            Dim row As DataRow
            Dim finalLine As String = ""
            For Each line As String In lines
                row = recs.NewRow()
                finalLine = line.Replace(Convert.ToString(ControlChars.Cr), "")
                row.ItemArray = finalLine.Split(","c)
                recs.Rows.Add(row)
            Next
            Return recs
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CSVWrite(ByVal sourceTable As DataTable, ByVal FilePath As String, ByVal includeHeaders As Boolean, ByVal includeQuote As Boolean)

        Using writer As StreamWriter = File.CreateText(FilePath)
            If (includeHeaders) Then
                Dim headerValues As List(Of String) = New List(Of String)()
                For Each column As DataColumn In sourceTable.Columns
                    If includeQuote Then
                        headerValues.Add(QuoteValue(column.ColumnName))
                    Else
                        headerValues.Add(column.ColumnName)
                    End If
                Next
            End If

            Dim items() As String = Nothing
            For Each row As DataRow In sourceTable.Rows
                If includeQuote Then
                    items = row.ItemArray.Select(Function(obj) QuoteValue(obj.ToString())).ToArray()
                Else
                    items = row.ItemArray.Select(Function(obj) obj.ToString()).ToArray()
                End If
                writer.WriteLine(String.Join(",", items))
            Next

            writer.Flush()
        End Using


    End Sub

    Public Function QuoteValue(ByVal value As String) As String
        Return String.Concat("""", value.Replace("""", """"""), """")
    End Function

    Public Sub LoadExtProg(MyPath As String, Optional NoWait As Boolean = True)
        Dim procID As Integer
        Dim procEC As Integer = -1
        Dim newProc As Diagnostics.Process
        If Dir(MyPath).Length > 0 Then
            newProc = Diagnostics.Process.Start(MyPath)
            procID = newProc.Id
            If NoWait Then
                newProc.WaitForExit()
                If newProc.HasExited Then
                    procEC = newProc.ExitCode
                End If
            End If
        Else
            'MessageBox.Show("There is no " + MyPath + " in the alpha ....")
        End If
    End Sub

    Public Function SendEmail(to_ As String, subject_ As String, _body As String, Optional from_ As String = "megasoft@megasoft.cc", Optional pass_ As String = "mega==mega==", Optional ip_ As String = "207.180.249.126", Optional port_ As Integer = 25) As Boolean
        'Return False
        Try
            Dim MyEmail As New MailMessage(from_, to_, subject_, _body)
            MyEmail.IsBodyHtml = True
            'MyEmail.Bcc.Add(New MailAddress(from_))
            With New SmtpClient(ip_, port_)
                .UseDefaultCredentials = False
                .Credentials = New Net.NetworkCredential(from_, pass_)
                .EnableSsl = False
                .Send(MyEmail)
            End With
            Return True
        Catch error_t As Exception
            Return False
        End Try
    End Function

    Public Function SendEmailGMail(to_ As String, subject_ As String, _body As String) As Boolean
        'Return False
        Try


            Dim MyEmail As New MailMessage("tsaousidislefteris@gmail.com", to_, subject_, _body)
            MyEmail.IsBodyHtml = True
            'MyEmail.Bcc.Add(New MailAddress(from_))
            With New SmtpClient("smtp.gmail.com", 587)
                .UseDefaultCredentials = False
                .Credentials = New Net.NetworkCredential("tsaousidislefteris@gmail.com", "lefteris==leferis")
                .EnableSsl = False
                .Send(MyEmail)
            End With
            Return True
        Catch error_t As Exception
            Return False
        End Try
    End Function

    Public Function GetRndNo() As Integer
        Return GetOneNo() & GetOneNo() & GetOneNo() & GetOneNo() & GetOneNo() & GetOneNo()
    End Function

    Private Function GetOneNo() As String
        Randomize()
        Return CInt(Int((6 * Rnd()) + 1)).ToString
    End Function

    Function WriteImageToDisk(MyImage As Byte(), Optional tmpFileName As String = "") As String
        If tmpFileName = "" Then tmpFileName = System.Guid.NewGuid.ToString + ".tmp"
        Try
            Dim oFileStream As System.IO.FileStream
            oFileStream = New System.IO.FileStream(tmpFileName, System.IO.FileMode.Create)
            oFileStream.Write(MyImage, 0, MyImage.Length)
            oFileStream.Close()
            oFileStream.Dispose()
            Return tmpFileName
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function WhereFuncF(FieldName As String, FieldValue As String, Optional sqlServerIsnull As Boolean = False) As String
        Try
            If FieldValue.Trim.Length > 0 Then
                If sqlServerIsnull Then
                    Return " Or ISNULL(" + FieldName + ", N'') Like '" + FieldValue + "' "
                Else
                    Return " Or " + FieldName + " Like '" + FieldValue + "' "
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function No_(MyVal As String) As String
        On Error Resume Next
        If MyVal.ToString.Substring(0, 1) = "%" Then MyVal = MyVal.ToString.Substring(1, MyVal.ToString.Length - 1)
        If MyVal.ToString.Substring(MyVal.Length - 1, 1) = "%" Then MyVal = MyVal.ToString.Substring(0, MyVal.ToString.Length - 1)
        Return MyVal
    End Function

    Public Function WhereFunc(MyMe As Object, Table As String, Optional sqlServerIsnull As Boolean = False) As String
        Dim MyWhere As String = ""
        Dim dm As String = "'"
        With New datalayer
            dm = .dateMark
        End With

        For Each p As System.Reflection.PropertyInfo In MyMe.GetType().GetProperties()
            If p.CanRead Then
                Try
                    If p.Name.Substring(0, 2) <> "__" Then
                        Select Case p.PropertyType.Name
                            Case "String"
                                If p.GetValue(MyMe, Nothing).ToString.Length > 0 Then
                                    If sqlServerIsnull Then
                                        MyWhere += "ISNULL([" + Table + "].[" + p.Name + "], N'') Like '" + p.GetValue(MyMe, Nothing) + "' Or "
                                    Else
                                        MyWhere += "[" + Table + "].[" + p.Name + "] Like '" + p.GetValue(MyMe, Nothing) + "' Or "
                                    End If
                                End If
                            Case "DateTime"
                                If CDate(p.GetValue(MyMe, Nothing)) > CDate("1900-01-02") Then
                                    Dim dt As DateTime = CDate(p.GetValue(MyMe, Nothing))
                                    Dim enddt = dt.AddDays(1)
                                    MyWhere += "(" +
                                                "[" + Table + "].[" + p.Name + "] >= " + dm + dt.ToString("yyyy-MM-dd") + dm +
                                                " And " +
                                                "[" + Table + "].[" + p.Name + "] <= " + dm + enddt.ToString("yyyy-MM-dd") + dm +
                                        ") Or "
                                    'MyWhere += "[" + Table + "].[" + p.Name + "] = " + dm + CDate(p.GetValue(MyMe, Nothing)).ToString("yyyy-MM-dd") + dm + " Or "
                                End If
                            Case "Double"
                                If CDbl(p.GetValue(MyMe, Nothing)) > 0 Then
                                    MyWhere += "[" + Table + "].[" + p.Name + "] = " + CDbl(p.GetValue(MyMe, Nothing)).ToString + " Or "
                                End If
                        End Select
                    End If
                Catch ex As Exception
                    Dim myres As String = ex.Message
                    myres = myres
                    '
                End Try
            End If
        Next
        Try
            MyWhere = MyWhere.Substring(0, MyWhere.Length - 3)
        Catch ex As Exception
            '
        End Try

        Return MyWhere
    End Function

    Public Sub Bind(MyObj As Object, MyData As DataTable, col As List(Of Object), Fields As List(Of String), FNames As List(Of String))
        On Error Resume Next
        If MyObj.Columns.Count = 0 Then
            With MyObj
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True
                .AutoGenerateColumns = False
                .BorderStyle = 0
                .ReadOnly = True
                .SelectionMode = 1
                .Columns.Clear()
            End With
            Dim i As Integer
            For i = 0 To col.Count - 1
                If FNames(i).ToUpper = "VISIBLE=FALSE" Then
                    col(i).DataPropertyName = Fields(i)
                    col(i).Name = Fields(i)
                    col(i).HeaderText = FNames(i)
                    col(i).Visible = False
                    MyObj.Columns.Add(col(i))
                Else
                    col(i).DataPropertyName = Fields(i)
                    col(i).Name = Fields(i)
                    col(i).HeaderText = FNames(i)
                    MyObj.Columns.Add(col(i))
                End If
            Next
        End If
        If MyData.Rows.Count > 400 Then
            MyObj.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            MyObj.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Else
            MyObj.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            MyObj.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        End If
        Dim dataSource = New BindingSource(MyData, Nothing)
        MyObj.DataSource = dataSource
        'MyObj.DataSource = MyData

    End Sub

    Public Function chkeckfolders(mytype As String, Optional mydirectory As String = "customization") As String
        Dim returnstring = ""
        Dim mydir_customization As String = mydirectory
        Try
            If Directory.Exists(mydir_customization) = False Then Directory.CreateDirectory(mydir_customization)
            returnstring = mydir_customization + "\"
        Catch ex As Exception

        End Try
        Try
            If Directory.Exists(returnstring + mytype) = False Then Directory.CreateDirectory(returnstring + mytype)
            returnstring = returnstring + mytype + "\"
        Catch ex As Exception

        End Try
        Return returnstring
    End Function

    Public Function GetZoomTop(myFormName As String) As String
        If myFormName = "All" Then
            Return ""
            Exit Function
        End If

        Dim Top As Integer = 400
        If myFormName.Length > 0 Then
            Try
                Dim MyFile As String = chkeckfolders("interface") + myFormName + "_Top" + ".txt"
                If File.Exists(MyFile) Then
                    Top = CInt(File.ReadAllText(MyFile))
                Else
                    File.WriteAllText(MyFile, Top.ToString())
                End If
            Catch e As Exception
                Top = 0
            End Try
        Else
            Top = 0
        End If
        If Top <> 0 Then
            Return " TOP " + Top.ToString + " "
        Else
            Return ""
        End If
    End Function

    Public Function GetCloseAfterSelection(myFormName As String) As Boolean
        If myFormName = "All" Then
            Return True
            Exit Function
        End If

        Dim r As Boolean = True
        If myFormName.Length > 0 Then
            Try
                Dim MyFile As String = chkeckfolders("interface") + myFormName + "_Close" + ".txt"
                If File.Exists(MyFile) Then
                    r = CBool(File.ReadAllText(MyFile))
                Else
                    File.WriteAllText(MyFile, r.ToString())
                End If
            Catch e As Exception
                r = True
            End Try
        Else
            r = True
        End If
        Return r
    End Function

    Public Sub customizationforLabels(myOBJ As Object, Optional extName As String = "")
        Try
            Dim MyFile As String = chkeckfolders("interface") + myOBJ.Name + "_" + extName + ".txt"
            If File.Exists(MyFile) = False Then
                Dim objWriter As New System.IO.StreamWriter(MyFile)
                For Each c In myOBJ.Controls
                    If c.Name.ToString.Substring(0, 5).ToUpper = "LABEL" Then
                        objWriter.WriteLine(c.Text + "," + c.Text)
                    End If
                Next
                objWriter.Close()
            End If
            Dim myData = New DataTable
            myData = CSVRead(MyFile)
            Dim i As Integer
            For Each c In myOBJ.Controls
                If c.Name.ToString.Substring(0, 5).ToUpper = "LABEL" Or c.Name.ToString.Substring(0, 4).ToUpper = "MEGA" Then
                    For i = 0 To myData.Rows.Count - 1
                        Dim sw As Boolean = False
                        If c.Name.ToString.Substring(0, 5).ToUpper = "LABEL" Or c.Name.ToString.Substring(0, 4).ToUpper = "MEGA" Then
                            If c.Text.ToString.ToUpper = myData.Rows(i)(0).ToString.ToUpper Then
                                c.Text = myData.Rows(i)(1).ToString
                                If myData.Rows(i)(1).ToString.ToUpper = "VISIBLE=FALSE" Then
                                    c.Visible = False
                                    For Each cc In myOBJ.Controls
                                        Try
                                            If c.name.ToString.Substring(6, c.name.ToString.Length - 6) =
                                        cc.name.ToString.Substring(8, cc.name.ToString.Length - 8) Then
                                                cc.Visible = False
                                            End If
                                        Catch ex As Exception
                                            '
                                        End Try
                                    Next
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            '
        End Try

    End Sub

    Public Function customizationforOrder(myOBJ As List(Of String), myObj_Name As String) As List(Of String)
        Try
            Dim MyFile As String = chkeckfolders("interface") + myObj_Name + ".txt"
            If File.Exists(MyFile) = False Then
                Dim objWriter As New System.IO.StreamWriter(MyFile)

                For Each c In myOBJ
                    objWriter.WriteLine(c + "," + c)
                Next
                objWriter.Close()
            End If

            Dim myData = New DataTable
            myData = CSVRead(MyFile)
            Dim i As Integer
            Dim x As Integer
            For x = 0 To myOBJ.Count - 1
                For i = 0 To myData.Rows.Count - 1
                    Dim str As String = myData.Rows(i)(0).ToString.ToUpper
                    If myOBJ(x).ToUpper = str Then
                        str = myData.Rows(i)(1).ToString
                        myOBJ(x) = str
                    End If
                Next
            Next
        Catch ex As Exception
            '
        End Try
        Return myOBJ
    End Function

    Public Function customizationforGrid(ByVal fnames As List(Of String), ByVal MyFile As String) As List(Of String)
        On Error Resume Next
        MyFile = chkeckfolders("interface") + MyFile + ".txt"
        If File.Exists(MyFile) = False Then
            Dim objWriter As New System.IO.StreamWriter(MyFile, False, Encoding.UTF8)
            Dim l As Integer
            For l = 0 To fnames.Count - 1
                objWriter.WriteLine(fnames(l) + "," + fnames(l))
            Next
            objWriter.Close()
        End If
        Dim myData = New DataTable
        myData = CSVRead(MyFile)
        Dim i As Integer
        Dim x As Integer
        For x = 0 To fnames.Count - 1
            For i = 0 To myData.Rows.Count - 1
                If fnames(x).ToUpper = myData.Rows(i)(0).ToString.ToUpper Then
                    fnames(x) = myData.Rows(i)(1).ToString
                End If
            Next
        Next
        Return fnames
    End Function

    Public Function customizationControl(ByVal MyFile As String) As Boolean
        MyFile = chkeckfolders("control") + MyFile + ".txt"
        Try
            If File.Exists(MyFile) = False Then
                Dim objWriter As New System.IO.StreamWriter(MyFile)
                objWriter.WriteLine("True")
                objWriter.Close()
            End If
        Catch ex As Exception
            '
        End Try

        Dim line As String = ""
        Try
            Using sr As New StreamReader(MyFile)
                line = sr.ReadToEnd()
            End Using
        Catch e As Exception
            '
        End Try

        If line.ToUpper.Trim = "FALSE" Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub setSI_Combos(MyComboBox As Object, Value As String)
        On Error Resume Next
        For Each Row In MyComboBox.Items
            Dim tmp As String = Row("id").ToString()
            If tmp = Value Then
                MyComboBox.SelectedItem = Row
            End If
        Next
    End Sub


    Public Function getStr(dataGridView1 As Object, Optional FNoOfCols As Boolean = False) As String
        On Error Resume Next
        Dim tmp As String = "(" + dataGridView1.SelectedRows.Count.ToString() + " εγγραφές)" + vbNewLine + vbNewLine
        Dim Mend As Integer = 20

        If dataGridView1.SelectedRows.Count < 20 Then Mend = dataGridView1.SelectedRows.Count
        Dim i As Integer
        Dim col1 As Integer = 1
        Dim col2 As Integer = 2
        If dataGridView1.Columns.Count = 2 Then
            col1 = 0
            col2 = 1
        End If
        If FNoOfCols Then
            col1 = 2
            col2 = 3
        End If

        For i = 0 To Mend - 1
            tmp += dataGridView1.SelectedRows(i).Cells(col1).Value.ToString() +
                   "   " +
                   dataGridView1.SelectedRows(i).Cells(col2).Value.ToString() +
                   vbNewLine
        Next
        If dataGridView1.SelectedRows.Count >= 20 Then tmp += "..."
        Return tmp
    End Function

    Public Sub WriteInLogFile(MyStr As String)
        Try
            Dim MyPath As String = "app_data\log.txt"
            If File.Exists(MyPath) Then
                Dim MyStream As New StreamWriter(MyPath, True)
                MyStream.WriteLine(MyStr)
                MyStream.Close()
            End If
        Catch ex As Exception
            '
        End Try
    End Sub

    Public Function MakeMonthDesc(mMonth As Integer, mYear As Integer) As String
        Dim dMonth As String = "Ιαν "
        Select Case mMonth
            Case 2
                dMonth = "Φεβ "
            Case 3
                dMonth = "Μαρ "
            Case 4
                dMonth = "Απρ "
            Case 5
                dMonth = "Μαι "
            Case 6
                dMonth = "Ιουν "
            Case 7
                dMonth = "Ιουλ "
            Case 8
                dMonth = "Αυγ "
            Case 9
                dMonth = "Σεπ "
            Case 10
                dMonth = "Οκτ "
            Case 11
                dMonth = "Νοε "
            Case 12
                dMonth = "Δεκ "
        End Select
        Return dMonth + mYear.ToString
    End Function

    Public Function WebRetrieve(url As String) As String
        Try
            Dim webClient As New System.Net.WebClient
            Return webClient.DownloadString(url)
        Catch ex As Exception
            Dim s As String = ex.Message
            Return "xxxxxxx"
        End Try
    End Function

    Public Function WebUpload(FileName As String, Url As String, Optional UserName As String = "", Optional PassWord As String = "") As Boolean

        Try
            Url = "http://192.168.1.115:8080/Documents/megasoftAccessControl"
            Dim request As WebRequest = WebRequest.Create(Url)
            request.Credentials = New NetworkCredential(UserName, PassWord)
            request.Method = WebRequestMethods.Ftp.UploadFile

            Using fileStream As Stream = File.OpenRead(FileName),
            ftpStream As Stream = request.GetRequestStream()
                Dim read As Integer
                Do
                    Dim buffer() As Byte = New Byte(10240) {}
                    read = fileStream.Read(buffer, 0, buffer.Length)
                    If read > 0 Then
                        ftpStream.Write(buffer, 0, read)
                        'Console.WriteLine("Uploaded {0} bytes", fileStream.Position)
                    End If
                Loop While read > 0
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function WebDelete(URL As String) As Boolean
        Try
            Dim request As WebRequest = WebRequest.Create(URL)
            request.Method = "DELETE"
            Dim response As HttpWebResponse = request.GetResponse()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateSection(Application_StartupPath As String, update_version As String, myobj As Object, mypb As Object, Application_Product_Varsion As String, this As Object, myPrg As String, Exe As String) As Boolean
        Dim MyUpdatePath As String = Application.StartupPath + "\updates"
        myobj.Text = "Downloading update : " + update_version
        Try
            If Directory.Exists(MyUpdatePath) Then Directory.Delete(MyUpdatePath, True)
            If MessageBox.Show("Θέλετε να συνεχίσω με την αναβάθμιση ;", "Προσοχή !", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                mypb.Visible = False
                Return False
                Exit Function
            End If
            Directory.CreateDirectory(MyUpdatePath)
        Catch ex As Exception
            myobj.Text = "I Can't Create the Update Directory !!"
            mypb.Visible = False
            Return False
            Exit Function
        End Try

        Dim URL As String = "http://" + New bhtaFramework.bhtaFramework().SupportURL + "/bpr.net/" + myPrg + "/" + myPrg + "_" + update_version.Replace(".", "_") + ".zip"
        Dim ZipFile As String = MyUpdatePath + "\" + myPrg + "_" + update_version.Replace(".", "_") + ".zip"

        If getFileFromWeb(URL, ZipFile, mypb) Then
            myobj.Text = "Unziping Please wait"

            If UnZip(ZipFile, MyUpdatePath) = False Then
                Process.Start("explorer.exe", Application_StartupPath)
                myobj.Text = "Unzip & Copy files from the update directory"
                mypb.Visible = False
                Return False
                Exit Function
            End If

            Try
                If File.Exists(ZipFile) Then File.Delete(ZipFile)
            Catch ex As Exception
                myobj.Text = "I Can't delete the zip file"
                mypb.Visible = False
                Return False
                Exit Function
            End Try

            Try
                System.IO.File.WriteAllText(MyUpdatePath + "\update.txt",
                                                       Application_StartupPath + ";" + MyUpdatePath + ";" + Exe, Encoding.UTF8)
            Catch ex As Exception
                myobj.Text = "I Can't Write the parametr file for update"
                mypb.Visible = False
                Return False
                Exit Function
            End Try

            Try
                Shell(MyUpdatePath + "\update_desktopbusiness.exe", AppWinStyle.NormalFocus)
                mypb.Visible = False
                Return True
            Catch ex As Exception
                myobj.Text = "I Can't find the file : " + MyUpdatePath + "\update_desktopbusiness.exe"
                mypb.Visible = False
                Return False
                Exit Function
            End Try
        Else
            myobj.Text = "Download error"
            mypb.Visible = False
            Return False
            Exit Function
        End If

    End Function

    Private Function UnZip(ZipFile As String, exportDir As String) As Boolean
        Try
            Dim sc As New Shell32.Shell()
            Dim output As Shell32.Folder = sc.NameSpace(exportDir + "\")
            Dim input As Shell32.Folder = sc.NameSpace(ZipFile)
            output.CopyHere(input.Items, 4)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function getFileFromWeb(MyURL As String, SaveAsFile As String, ByVal sender As System.Object) As Boolean
        Dim theResponse As HttpWebResponse
        Dim theRequest As HttpWebRequest
        Try
            theRequest = WebRequest.Create(MyURL)
            theResponse = theRequest.GetResponse
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Try
            Dim length As Long = theResponse.ContentLength
            Dim writeStream As New IO.FileStream(SaveAsFile, IO.FileMode.Create)
            Dim nRead As Integer
            Dim speedtimer As New Stopwatch
            Dim currentspeed As Double = -1
            Dim readings As Integer = 0
            Do
                speedtimer.Start()
                Dim readBytes(4095) As Byte
                Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
                nRead += bytesread
                Dim percent As Short = (nRead * 100) / length
                sender.Value = percent
                If bytesread = 0 Then Exit Do
                writeStream.Write(readBytes, 0, bytesread)
                speedtimer.Stop()
                readings += 1
                If readings >= 5 Then
                    currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                    speedtimer.Reset()
                    readings = 0
                End If
            Loop
            theResponse.GetResponseStream.Close()
            writeStream.Close()
            sender.Value = 0
            Return True
        Catch ex As Exception
            sender.Value = 0
            Return False
        End Try
    End Function

    Public Sub setTmpDirAndClear(md As String)
        If Dir(md, FileAttribute.Directory).ToString.Length = 0 Then
            MkDir(md)
        End If

        Dim myName As String = Dir(md + "\*.*")
        Dim myFile As String
        Do While myName <> ""
            myFile = md + myName
            myName = Dir()
            Try
                Kill(myFile)
            Catch ex As Exception
                '
            End Try
        Loop
    End Sub

    Public Function clearStringFromZ(StringToFind As String) As String
        Try
            If StringToFind.Substring(0, 1) = "%" Then
                StringToFind = StringToFind.Substring(1, StringToFind.Length - 1)
            End If
            If StringToFind.Substring(StringToFind.Length - 1, 1) = "%" Then
                StringToFind = StringToFind.Substring(0, StringToFind.Length - 1)
            End If
        Catch ex As Exception

        End Try
        Return StringToFind

    End Function

    Public Function ReadLocalConnectionString() As List(Of String)
        Dim Res As New List(Of String)
        Try
            Using sr As New StreamReader("app_data\localConnectionString.txt")
                sr.ReadLine()
                Res.Add(sr.ReadLine())
                Res.Add(sr.ReadLine())
            End Using
        Catch e As Exception
            '
        End Try
        Return Res
    End Function

    Public Function GetIconName(ByVal randomText As String) As String
        randomText = Trim(randomText)
        If randomText.Length > 0 Then
            If randomText.IndexOf(" ") > -1 Then
                Dim s As String = randomText.Substring(randomText.IndexOf(" "))
                s = Trim(s)
                If s.Length > 1 Then s = s.Substring(0, 1)
                Return randomText.Substring(0, 1) + s
            Else
                Return randomText.Substring(0, 1)
            End If
        Else
            Return "X"
        End If
    End Function

    Public Class GetImageFromNameResult
        Public img As Image
        Public imgByte As Byte()
        Public txt As String
    End Class
    Public Function GetImageFromName(ByVal randomText As String) As GetImageFromNameResult
        Dim result As New GetImageFromNameResult
        result.txt = GetIconName(randomText)

        Dim height As Integer = 32
        Dim width As Integer = 32
        Dim rnd = New Random()
        Dim fonts() = {"Verdana"}
        Dim orientationAngle As Decimal = rnd.Next(0, 359)
        Dim index0 = rnd.Next(0, fonts.Length)
        Dim familyName = fonts(index0)

        Dim bmpOut As Bitmap = New Bitmap(width, height)
        Using (bmpOut)
            Dim g As Graphics = Graphics.FromImage(bmpOut)
            Dim size As SizeF = g.MeasureString(result.txt, New Font(familyName, 12))
            Dim x As Integer = Convert.ToInt32((width / 2) - (size.Width / 2))
            Dim y As Integer = Convert.ToInt32((height / 2) - (size.Height / 2))
            Dim gradientBrush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, width, height),
                                                                               Color.Red, Color.Red, orientationAngle)
            g.FillRectangle(gradientBrush, 0, 0, width, height)
            g.DrawString(result.txt, New Font(familyName, 12), New SolidBrush(Color.White), x, y)
            Dim ms As MemoryStream = New MemoryStream()
            bmpOut.Save(ms, ImageFormat.Png)
            Dim bmpBytes As Byte() = ms.GetBuffer()
            bmpOut.Dispose()
            ms.Close()
            Dim FileStream As MemoryStream = New MemoryStream(bmpBytes)
            Using (FileStream)
                result.img = Image.FromStream(FileStream)
                result.imgByte = bmpBytes
                Return result
            End Using
        End Using

    End Function


#Region " ResizeImage "
    Public Overloads Function ResizeImage(SourceImage As Drawing.Image, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Dim bmSource = New Drawing.Bitmap(SourceImage)
        Return ResizeImage(bmSource, TargetWidth, TargetHeight)
    End Function

    Public Overloads Function ResizeImageBitmap(SourceImage As Drawing.Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Return ResizeImage(SourceImage, TargetWidth, TargetHeight)
    End Function

    Private Overloads Function ResizeImage(bmSource As Drawing.Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Dim bmDest As New Drawing.Bitmap(TargetWidth, TargetHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)

        Dim nSourceAspectRatio = bmSource.Width / bmSource.Height
        Dim nDestAspectRatio = bmDest.Width / bmDest.Height

        Dim NewX = 0
        Dim NewY = 0
        Dim NewWidth = bmDest.Width
        Dim NewHeight = bmDest.Height

        If nDestAspectRatio = nSourceAspectRatio Then
            'same ratio
        ElseIf nDestAspectRatio > nSourceAspectRatio Then
            'Source is taller
            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        Else
            'Source is wider
            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        End If

        Using grDest = Drawing.Graphics.FromImage(bmDest)
            With grDest
                .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality
                .SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceOver

                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
            End With
        End Using

        Return bmDest
    End Function

    Public Function ConvertToByteArray(ByVal value As Image) As Byte()
        Dim ms = New MemoryStream()
        value.Save(ms, Imaging.ImageFormat.Png)
        Return ms.ToArray()
    End Function


#End Region
    Private Function FromHtml(colorHTML As String) As Color
        Dim result As Color = Color.Empty
        If String.IsNullOrEmpty(colorHTML) = False Then
            result = ColorTranslator.FromHtml(colorHTML)
        End If
        Return result
    End Function

    Public Function distance1(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double) As Double
        Dim p As Double = 0.017453292519943295
        Dim a As Double = 0.5 - Math.Cos((lat2 - lat1) * p) / 2 +
              Math.Cos(lat1 * p) * Math.Cos(lat2 * p) *
              (1 - Math.Cos((lon2 - lon1) * p)) / 2
        Return 12742 * Math.Asin(Math.Sqrt(a))

        ' // 2 * R; R = 6371 km
    End Function

    Public Function distance(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double) As Double
        Const RADIUS As Double = 6378.16
        Dim dlon As Double = Radians(lon2 - lon1)
        Dim dlat As Double = Radians(lat2 - lat1)

        Dim a As Double = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) +
                           Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) *
                           (Math.Sin(dlon / 2) * Math.Sin(dlon / 2))
        Dim angle As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        Return angle * RADIUS
    End Function
    Private Function Radians(x As Double) As Double
        Const PIx As Double = 3.1415926535897931
        Return x * PIx / 180
    End Function


#Region "KindOfEducation"
    Public Function KindOfEducation() As List(Of String)
        Select Case lang
            Case "gr"
                Return KindOfEducation_GR()
            Case Else
                Return KindOfEducation_EN()
        End Select
    End Function
    Private Function KindOfEducation_EN() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("")
            .Add("Primary")
            .Add("Secondary")
            .Add("Tertiary")
            .Add("Second stage tertiary")
        End With
        Return ResData
    End Function

    Private Function KindOfEducation_GR() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("")
            .Add("Πρωτοβάθμια")
            .Add("Δευτεροβάθμια")
            .Add("Τριτοβάθμια")
            .Add("Δεύτερο στάδιο τριτοβάθμιας")
        End With
        Return ResData
    End Function
#End Region

#Region "TypeOfMotos"
    Public Function TypeOfMotos() As List(Of String)
        Select Case lang
            Case "gr"
                Return TypeOfMotos_GR()
            Case Else
                Return TypeOfMotos_EN()
        End Select
    End Function

    Public Function TypeOfMotos_GR() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("")
            .Add("Αυτοκίνητο")
            .Add("Μοτοσυκλέτα")
            .Add("Ποδήλατο")
            .Add("Σπόρ στο νερό")
            .Add("Αθλητισμός")
            .Add("Τουρισμός")
            .Add("Γενικά")
        End With
        Return ResData
    End Function


    Public Function TypeOfMotos_EN() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("")
            .Add("Cars")
            .Add("Motorcycle")
            .Add("Bicycle")
            .Add("Water sports")
            .Add("Sport")
            .Add("Tourism")
            .Add("General")
        End With
        Return ResData
    End Function
#End Region

#Region "GetCountries"
    Public Function GetCountries() As List(Of String)
        Select Case lang
            Case "gr"
                Dim ResC As New List(Of String)
                ResC = GetC()
                Dim ResC_GR As New List(Of String)
                ResC_GR = GetC_GR()
                Dim i As Integer = 0
                For i = 0 To ResC.Count - 1
                    ResC(i) = ResC(i) + " - " + ResC_GR(i)
                Next
                Return ResC
            Case Else
                Return GetC()
        End Select
    End Function


    Private Function GetC() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("Afghanistan")
            .Add("Albania")
            .Add("Algeria")
            .Add("American Samoa")
            .Add("Andorra")
            .Add("Angola")
            .Add("Anguilla")
            .Add("Antigua and Barbuda")
            .Add("Argentina")
            .Add("Armenia")
            .Add("Aruba")
            .Add("Australia")
            .Add("Austria")
            .Add("Azerbaijan")
            .Add("Bahamas")
            .Add("Bahrain")
            .Add("Bangladesh")
            .Add("Barbados")
            .Add("Belarus")
            .Add("Belgium")
            .Add("Belize")
            .Add("Benin")
            .Add("Bermuda")
            .Add("Bhutan")
            .Add("Bolivia")
            .Add("Bonaire")
            .Add("Bosnia-Herzegovina")
            .Add("Botswana")
            .Add("Bouvet Island")
            .Add("Brazil")
            .Add("Brunei")
            .Add("Bulgaria")
            .Add("Burkina Faso")
            .Add("Burundi")
            .Add("Cambodia")
            .Add("Cameroon")
            .Add("Canada")
            .Add("Cape Verde")
            .Add("Cayman Islands")
            .Add("Central African Republic")
            .Add("Chad")
            .Add("Chile")
            .Add("China")
            .Add("Christmas Island")
            .Add("Cocos (Keeling) Islands")
            .Add("Colombia South")
            .Add("Comoros")
            .Add("Congo, Democratic Republic of the (Zaire)")
            .Add("Congo, Republic of")
            .Add("Cook Islands")
            .Add("Costa Rica")
            .Add("Croatia")
            .Add("Cuba")
            .Add("Curacao")
            .Add("Cyprus")
            .Add("Czech Republic")
            .Add("Denmark")
            .Add("Djibouti")
            .Add("Dominica Caribbean")
            .Add("Dominican Republic")
            .Add("Ecuador")
            .Add("Egypt")
            .Add("El Salvador")
            .Add("Equatorial Guinea")
            .Add("Eritrea")
            .Add("Estonia")
            .Add("Ethiopia")
            .Add("Falkland Islands")
            .Add("Faroe Islands")
            .Add("Fiji")
            .Add("FIROM")
            .Add("Finland")
            .Add("France")
            .Add("French Guiana")
            .Add("Gabon")
            .Add("Gambia")
            .Add("Georgia")
            .Add("Germany")
            .Add("Ghana")
            .Add("Gibraltar")
            .Add("Greece")
            .Add("Greenland")
            .Add("Grenada")
            .Add("Guadeloupe (French)")
            .Add("Guam (USA)")
            .Add("Guatemala")
            .Add("Guinea")
            .Add("Guinea Bissau")
            .Add("Guyana")
            .Add("Haiti")
            .Add("Holy See")
            .Add("Honduras")
            .Add("Hong Kong")
            .Add("Hungary")
            .Add("Iceland")
            .Add("India")
            .Add("Indonesia")
            .Add("Iran")
            .Add("Iraq")
            .Add("Ireland")
            .Add("Israel")
            .Add("Italy")
            .Add("Ivory Coast (Cote D`Ivoire)")
            .Add("Jamaica")
            .Add("Japan")
            .Add("Jordan")
            .Add("Kazakhstan")
            .Add("Kenya")
            .Add("Kiribati")
            .Add("Kosovo")
            .Add("Kuwait")
            .Add("Kyrgyzstan")
            .Add("Laos")
            .Add("Latvia")
            .Add("Lebanon")
            .Add("Lesotho")
            .Add("Liberia")
            .Add("Libya")
            .Add("Liechtenstein")
            .Add("Lithuania")
            .Add("Luxembourg")
            .Add("Macau")
            .Add("Madagascar")
            .Add("Malawi")
            .Add("Malaysia")
            .Add("Maldives")
            .Add("Mali")
            .Add("Malta")
            .Add("Marshall Islands")
            .Add("Martinique (French)")
            .Add("Mauritania")
            .Add("Mauritius")
            .Add("Mayotte")
            .Add("Mexico")
            .Add("Micronesia")
            .Add("Moldova")
            .Add("Monaco")
            .Add("Mongolia")
            .Add("Montenegro")
            .Add("Montserrat")
            .Add("Morocco")
            .Add("Mozambique")
            .Add("Myanmar")
            .Add("Namibia")
            .Add("Nauru")
            .Add("Nepal")
            .Add("Netherlands")
            .Add("Netherlands Antilles")
            .Add("New Caledonia (French)")
            .Add("New Zealand")
            .Add("Nicaragua")
            .Add("Niger")
            .Add("Nigeria")
            .Add("Niue")
            .Add("Norfolk Island")
            .Add("North Korea")
            .Add("Northern Mariana Islands")
            .Add("Norway")
            .Add("Oman")
            .Add("Pakistan")
            .Add("Palau")
            .Add("Panama")
            .Add("Papua New Guinea")
            .Add("Paraguay")
            .Add("Peru")
            .Add("Philippines")
            .Add("Pitcairn Island")
            .Add("Poland")
            .Add("Polynesia (French)")
            .Add("Portugal")
            .Add("Puerto Rico")
            .Add("Qatar")
            .Add("Reunion")
            .Add("Romania")
            .Add("Russia")
            .Add("Rwanda")
            .Add("Saint Helena")
            .Add("Saint Kitts and Nevis")
            .Add("Saint Lucia")
            .Add("Saint Pierre and Miquelon")
            .Add("Saint Vincent and Grenadines")
            .Add("Samoa")
            .Add("San Marino")
            .Add("Sao Tome and Principe")
            .Add("Saudi Arabia")
            .Add("Senegal")
            .Add("Serbia")
            .Add("Seychelles")
            .Add("Sierra Leone")
            .Add("Singapore")
            .Add("Sint Maarten")
            .Add("Slovakia")
            .Add("Slovenia")
            .Add("Solomon Islands")
            .Add("Somalia")
            .Add("South Africa")
            .Add("South Georgia and South Sandwich Islands")
            .Add("South Korea")
            .Add("South Sudan")
            .Add("Spain")
            .Add("Sri Lanka")
            .Add("Sudan")
            .Add("Suriname")
            .Add("Svalbard and Jan Mayen Islands")
            .Add("Swaziland")
            .Add("Sweden")
            .Add("Switzerland")
            .Add("Syria")
            .Add("Taiwan")
            .Add("Tajikistan")
            .Add("Tanzania")
            .Add("Thailand")
            .Add("Timor-Leste (East Timor)")
            .Add("Togo")
            .Add("Tokelau")
            .Add("Tonga")
            .Add("Trinidad and Tobago")
            .Add("Tunisia")
            .Add("Turkey")
            .Add("Turkmenistan")
            .Add("Turks and Caicos Islands")
            .Add("Tuvalu")
            .Add("Uganda")
            .Add("Ukraine")
            .Add("United Arab Emirates")
            .Add("United Kingdom")
            .Add("United States")
            .Add("Uruguay")
            .Add("Uzbekistan")
            .Add("Vanuatu")
            .Add("Venezuela")
            .Add("Vietnam")
            .Add("Virgin Islands")
            .Add("Wallis and Futuna Islands")
            .Add("Yemen")
            .Add("Zambia")
            .Add("Zimbabwe")
        End With
        Return ResData
    End Function
    Private Function GetC_GR() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("Αφγανιστάν")
            .Add("Αλβανία")
            .Add("Αλγερία")
            .Add("Αμερικανική Σαμόα")
            .Add("Ανδόρα")
            .Add("Ανγκόλα")
            .Add("Ανγκουίλα")
            .Add("Αντίγκουα και Μπαρμπούντα")
            .Add("Αργεντινή")
            .Add("Αρμενία")
            .Add("Αρούμπα")
            .Add("Αυστραλία")
            .Add("Αυστρία")
            .Add("Αζερμπαϊτζάν")
            .Add("Μπαχάμες")
            .Add("Μπαχρέιν")
            .Add("Μπανγκλαντές")
            .Add("Μπαρμπάντος")
            .Add("Λευκορωσία")
            .Add("Βέλγιο")
            .Add("Μπελίζ")
            .Add("Μπενίν")
            .Add("Βερμούδες")
            .Add("Μπουτάν")
            .Add("Βολιβία")
            .Add("Μποναίρ")
            .Add("Βοσνία και Ερζεγοβίνη")
            .Add("Μποτσουάνα")
            .Add("Νήσος Μπουβέ")
            .Add("Βραζιλία")
            .Add("Μπρουνέι")
            .Add("Βουλγαρία")
            .Add("Μπουρκίνα Φάσο")
            .Add("Μπουρούντι")
            .Add("Καμπότζη")
            .Add("Καμερούν")
            .Add("Καναδάς")
            .Add("Πράσινο Ακρωτήριο")
            .Add("Νήσοι Κέιμαν")
            .Add("Κεντροαφρικανική Δημοκρατία")
            .Add("Τσαντ")
            .Add("Χιλή")
            .Add("Κίνα")
            .Add("Νήσος των Χριστουγέννων")
            .Add("Νησιά Κόκος")
            .Add("Κολομβία")
            .Add("Κομόρες")
            .Add("Λαική Δημοκρατία Κογκό (Zaire)")
            .Add("Δημοκρατία του Κονγκό")
            .Add("Νήσοι Κουκ")
            .Add("Κόστα Ρίκα")
            .Add("Κροατία")
            .Add("Κούβα")
            .Add("Κουρασάο")
            .Add("Κύπρος")
            .Add("Τσεχία")
            .Add("Δανία")
            .Add("Τζιμπουτί")
            .Add("Δομινίκα")
            .Add("Δομινικανή Δημοκρατία")
            .Add("Ισημερινός")
            .Add("Αίγυπτος")
            .Add("Ελ Σαλβαδόρ")
            .Add("Ισημερινή Γουινέα")
            .Add("Ερυθραία")
            .Add("Εσθονία")
            .Add("Αιθιοπία")
            .Add("Νήσοι Φώκλαντ")
            .Add("Νήσοι Φερόες")
            .Add("Φίτζι")
            .Add("ΠΓΔΜ")
            .Add("Φινλανδία")
            .Add("Γαλλία")
            .Add("Γαλλική Γουιάνα")
            .Add("Γκαμπόν")
            .Add("Γκάμπια")
            .Add("Γεωργία")
            .Add("Γερμανία")
            .Add("Γκάνα")
            .Add("Γιβραλτάρ")
            .Add("Ελλάδα")
            .Add("Γροιλανδία")
            .Add("Γρενάδα")
            .Add("Γουαδελούπη")
            .Add("Γκουάμ")
            .Add("Γουατεμάλα")
            .Add("Γουινέα")
            .Add("Γουινέα-Μπισσάου")
            .Add("Γουιάνα")
            .Add("Αϊτή")
            .Add("Αγία Έδρα")
            .Add("Ονδούρα")
            .Add("Χονγκ Κονγκ")
            .Add("Ουγγαρία")
            .Add("Ισλανδία")
            .Add("Ινδία")
            .Add("Ινδονησία")
            .Add("Ιράν")
            .Add("Ιράκ")
            .Add("Ιρλανδία")
            .Add("Ισραήλ")
            .Add("Ιταλία")
            .Add("Ακτή Ελεφαντοστού")
            .Add("Τζαμάικα")
            .Add("Ιαπωνία")
            .Add("Ιορδανία")
            .Add("Καζακστάν")
            .Add("Κένυα")
            .Add("Κιριμπάτι")
            .Add("Κόσοβο")
            .Add("Κουβέιτ")
            .Add("Κιργιζία")
            .Add("Λάος")
            .Add("Λετονία")
            .Add("Λίβανος")
            .Add("Λεσότο")
            .Add("Λιβερία")
            .Add("Λιβύη")
            .Add("Λίχτενσταϊν")
            .Add("Λιθουανία")
            .Add("Λουξεμβούργο")
            .Add("Μακάο")
            .Add("Μαδαγασκάρη")
            .Add("Μαλάουι")
            .Add("Μαλαισία")
            .Add("Μαλδίβες")
            .Add("Μάλι")
            .Add("Μάλτα")
            .Add("Νήσοι Μάρσαλ")
            .Add("Μαρτινίκα")
            .Add("Μαυριτανία")
            .Add("Μαυρίκιος")
            .Add("Μαγιότ")
            .Add("Μεξικό")
            .Add("Ομόσπονδες Πολιτείες της Μικρονησίας")
            .Add("Μολδαβία")
            .Add("Μονακό")
            .Add("Μογγολία")
            .Add("Μαυροβούνιο")
            .Add("Μοντσερράτ")
            .Add("Μαρόκο")
            .Add("Μοζαμβίκη")
            .Add("Μιανμάρ")
            .Add("Ναμίμπια")
            .Add("Ναουρού")
            .Add("Νεπάλ")
            .Add("Ολλανδία")
            .Add("Ολλανδικές Αντίλλες")
            .Add("Νέα Καληδονία")
            .Add("Νέα Ζηλανδία")
            .Add("Νικαράγουα")
            .Add("Νίγηρας")
            .Add("Νιγηρία")
            .Add("Νιούε")
            .Add("Νησί Νόρφολκ")
            .Add("Βόρεια Κορέα")
            .Add("Βόρειες Μαριάνες Νήσοι")
            .Add("Νορβηγία")
            .Add("Ομάν")
            .Add("Πακιστάν")
            .Add("Παλάου")
            .Add("Παναμάς")
            .Add("Παπούα Νέα Γουινέα")
            .Add("Παραγουάη")
            .Add("Περού")
            .Add("Φιλιππίνες")
            .Add("Νήσοι Πίτκαιρν")
            .Add("Πολωνία")
            .Add("Γαλλική Πολυνησία")
            .Add("Πορτογαλία")
            .Add("Πουέρτο Ρίκο")
            .Add("Κατάρ")
            .Add("Ρεϋνιόν")
            .Add("Ρουμανία")
            .Add("Ρωσία")
            .Add("Ρουάντα")
            .Add("Νήσος Αγίας Ελένης")
            .Add("Άγιος Χριστόφορος και Νέβις")
            .Add("Αγία Λουκία")
            .Add("Νήσοι Αγίου Πέτρου και Μιχαήλ")
            .Add("Άγιος Βικέντιος και Γρεναδίνες")
            .Add("Σαμόα")
            .Add("Άγιος Μαρίνος")
            .Add("Άγιος Θωμάς και Πρίγκιπας")
            .Add("Σαουδική Αραβία")
            .Add("Σενεγάλη")
            .Add("Σερβία")
            .Add("Σεϋχέλλες")
            .Add("Σιέρα Λεόνε")
            .Add("Σιγκαπούρη")
            .Add("Άγιος Μαρτίνος")
            .Add("Σλοβακία")
            .Add("Σλοβενία")
            .Add("Νήσοι Σολομώντα")
            .Add("Σομαλία")
            .Add("Νότια Αφρική")
            .Add("Νήσοι Νότια Γεωργία και Νότιες Σάντουιτς")
            .Add("Νότια Κορέα")
            .Add("Νότιο Σουδάν")
            .Add("Ισπανία")
            .Add("Σρι Λάνκα")
            .Add("Σουδάν")
            .Add("Σουρινάμ")
            .Add("Γιαν Μαγιέν")
            .Add("Σουαζιλάνδη")
            .Add("Σουηδία")
            .Add("Ελβετία")
            .Add("Συρία")
            .Add("Ταϊβάν")
            .Add("Τατζικιστάν")
            .Add("Τανζανία")
            .Add("Ταϊλάνδη")
            .Add("Τιμόρ-Λέστε (Ανατολικό Τιμόρ)")
            .Add("Τόγκο")
            .Add("Τοκελάου")
            .Add("Τόνγκα")
            .Add("Τρινιντάντ και Τομπάγκο")
            .Add("Τυνησία")
            .Add("Τουρκία")
            .Add("Τουρκμενιστάν")
            .Add("Τερκς και Κέικος")
            .Add("Τουβαλού")
            .Add("Ουγκάντα")
            .Add("Ουκρανία")
            .Add("Ηνωμένα Αραβικά Εμιράτα")
            .Add("Ηνωμένο Βασίλειο")
            .Add("Ηνωμένες Πολιτείες Αμερικής")
            .Add("Ουρουγουάη")
            .Add("Ουζμπεκιστάν")
            .Add("Βανουάτου")
            .Add("Βενεζουέλα")
            .Add("Βιετνάμ")
            .Add("Αμερικανικές Παρθένοι Νήσοι")
            .Add("Ουαλίς και Φουτουνά")
            .Add("Υεμένη")
            .Add("Ζάμπια")
            .Add("Ζιμπάμπουε")
        End With
        Return ResData
    End Function
#End Region

#Region "GetSex"
    Public Function GetSex() As List(Of String)
        Select Case lang
            Case "gr"
                Return GetSex_GR()
            Case Else
                Return GetSex_EN()
        End Select
    End Function


    Private Function GetSex_EN() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("Male")
            .Add("Female")
        End With
        Return ResData
    End Function

    Private Function GetSex_GR() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("Άνδρας")
            .Add("Γυναίκα")
        End With
        Return ResData
    End Function
#End Region

#Region "GetaccType"
    Public Function GetAccType() As List(Of String)
        Select Case lang
            Case "gr"
                Return GetAccType_GR()
            Case Else
                Return GetAccType_EN()
        End Select
    End Function


    Private Function GetAccType_EN() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("Spectator")
            .Add("Participant")
            .Add("Organizer")
        End With
        Return ResData
    End Function

    Private Function GetAccType_GR() As List(Of String)
        Dim ResData As New List(Of String)
        With ResData
            .Add("Θεατής")
            .Add("Συμμετέχων")
            .Add("Οργανωτής")
        End With
        Return ResData
    End Function
#End Region

    Public Class CL5000

        Public Function SentToScale(Group As Integer, Department As Integer, pluNo As Integer, Description As String, Price As Double, ItemCode As Long, IP As String, port As Integer, delay As Integer)

#Region "Header"
            Dim plu As String = Hex(pluNo.ToString())
            Select Case plu.Length
                Case 0
                    plu = "00000"
                Case 1
                    plu = "0000" + plu
                Case 2
                    plu = "000" + plu
                Case 3
                    plu = "00" + plu
                Case 4
                    plu = "0" + plu
                Case Else
                    plu = plu.Substring(0, 5)
            End Select

            Dim d As String = Hex(Val(Department))
            If d.Length = 1 Then d = "0" + d
            If d.Length = 0 Then d = "00"

            Dim RB As New List(Of Byte)
            RB.Add(87)   ' W                        0
            RB.Add(48)   ' 0                        1
            RB.Add(50)   ' 2                        2
            RB.Add(65)   ' A                        3
            RB.Add(AscW(plu.Substring(0, 1)))   '   4
            RB.Add(AscW(plu.Substring(1, 1)))   '   5
            RB.Add(AscW(plu.Substring(2, 1)))   '   6
            RB.Add(AscW(plu.Substring(3, 1)))   '   7
            RB.Add(AscW(plu.Substring(4, 1)))   '   8
            RB.Add(44)   ' ,                        9
            RB.Add(AscW(d.Substring(0, 1)))     '   10
            RB.Add(AscW(d.Substring(1, 1)))     '   11
            RB.Add(76)   ' L                        12
            RB.Add(48)   ' 0                        13
            RB.Add(48)   ' 0                        14
            RB.Add(48)   ' 0                        15
            RB.Add(48)   ' 0                        16
            RB.Add(58)   ' :                        17
#End Region

#Region "Plu No"
            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0   02, Plu No
            RB.Add(50)   ' 2
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            Dim arr As List(Of Byte) = convert_CL(pluNo.ToString)
            For inx As Integer = 0 To arr.Count - 1
                RB.Add(arr(inx))
            Next
            For inx As Integer = arr.Count To 4 - 1
                RB.Add(0)
            Next
#End Region

#Region "Name"
            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0    0A=10              Name
            RB.Add(65)   ' A
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(51)   ' 3
            RB.Add(44)   ' ,
            Dim sl As String = Description.ToString
            Dim ln As String = Hex(sl.Length)
            For inx As Integer = 0 To ln.Length - 1
                RB.Add(Asc(ln.Substring(inx, 1)))
            Next
            RB.Add(Asc(":"))
            For inx As Integer = 0 To sl.Length - 1
                RB.Add(Asc(sl.Substring(inx, 1)))
            Next
#End Region

#Region "Price"
            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0   06, Price 
            RB.Add(54)   ' 6
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            arr = convert_CL((Price * 100).ToString)
            For inx As Integer = 0 To arr.Count - 1
                RB.Add(arr(inx))
            Next
            For inx As Integer = arr.Count To 4 - 1
                RB.Add(0)
            Next
#End Region

#Region "Item Code"
            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0  0B=11,   Item Code
            RB.Add(66)   ' B
            RB.Add(46)   ' .
            RB.Add(52)   ' 4   
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            arr = convert_CL(ItemCode.ToString)
            For inx As Integer = 0 To arr.Count - 1
                RB.Add(arr(inx))
            Next
            For inx As Integer = arr.Count To 4 - 1
                RB.Add(0)
            Next
#End Region

#Region "Department"
            RB.Add(70)   ' F   
            RB.Add(61)   ' =
            RB.Add(48)   ' 0   01, Department
            RB.Add(49)   ' 1
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            arr = convert_CL(Department.ToString)
            For inx As Integer = 0 To arr.Count - 1
                RB.Add(arr(inx))
            Next
            For inx As Integer = arr.Count To 2 - 1
                RB.Add(0)
            Next
#End Region

#Region "Group"
            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0   09,  Group
            RB.Add(57)   ' 9
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            arr = convert_CL(Group.ToString)
            For inx As Integer = 0 To arr.Count - 1
                RB.Add(arr(inx))
            Next
            For inx As Integer = arr.Count To 2 - 1
                RB.Add(0)
            Next
#End Region

#Region "Auxiliary Data"

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0  04, Plu Type
            RB.Add(52)   ' 4   
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(68)   ' D
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(1)   ' 

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0  05, Unit Weight
            RB.Add(53)   ' 5
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0    08, Tax Id
            RB.Add(56)   ' 8
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            'RB.Add(70)   ' F
            'RB.Add(61)   ' =
            'RB.Add(48)   ' 0   09,  Group
            'RB.Add(57)   ' 9
            'RB.Add(46)   ' .
            'RB.Add(53)   ' 5
            'RB.Add(55)   ' 7
            'RB.Add(44)   ' ,
            'RB.Add(50)   ' 2
            'RB.Add(58)   ' :
            'RB.Add(0)   '  
            'RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0   0C=12,    Tare ID 
            RB.Add(67)   ' C
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0   0D=13,     Tare
            RB.Add(68)   ' D
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0   0E=14,     PCS
            RB.Add(69)   ' E
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0  0F=15,      PCS ID
            RB.Add(70)   ' F
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1  10=16,      Sell By Date
            RB.Add(48)   ' 0
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1  11=17,       Sell By Time
            RB.Add(49)   ' 1
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1   12=18,       Packed Date
            RB.Add(50)   ' 2
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1   13=19,       Packed Time
            RB.Add(51)   ' 3
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1   14=20,       Produced Date
            RB.Add(52)   ' 4
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1  16=22,       Cook By Date
            RB.Add(54)   ' 6
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1  17=23,      Tare % limit
            RB.Add(55)   ' 7
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1   18=24,       % Tare
            RB.Add(56)   ' 8
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1   19=25,        Ingredient
            RB.Add(57)   ' 9
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1   1A=26        Fixed Price
            RB.Add(65)   ' A
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(50)   ' 2  23=35,          Traceability
            RB.Add(51)   ' 3
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(50)   ' 2  24=36,          *******************           
            RB.Add(52)   ' 4
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(51)   ' 3  32=50,         Bonus 
            RB.Add(50)   ' 2
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(51)   ' 3   37=55,        Origin
            RB.Add(55)   ' 7
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(51)   ' 3   3C=60,           # of Link PLU
            RB.Add(67)   ' C
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(51)   ' 3   3D=61,            Link Dept1
            RB.Add(68)   ' D
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(51)   ' 3   3E=62,           Link Dept2
            RB.Add(69)   ' E
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(52)   ' 4   40=64,             Coupled Dept
            RB.Add(48)   ' 0
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(52)   ' 4    41=65,             Link PLU1
            RB.Add(49)   ' 1   
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(52)   ' 4    42=66,              Link PLU2
            RB.Add(50)   ' 2
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(52)   ' 4     44=68,                Coupled  PLU
            RB.Add(52)   ' 4
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(52)   ' 4     45=69,                Reference PLU
            RB.Add(53)   ' 5
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(52)   ' 4    46=70,                NutriFact ID
            RB.Add(54)   ' 6
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(52)   ' 4     47=71,               Reference Dept
            RB.Add(55)   ' 7     
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(53)   ' 5     50=80,                1st Label ID
            RB.Add(48)   ' 0
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(53)   ' 5    51=81,                2st Label ID
            RB.Add(49)   ' 1
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(53)   ' 5    55=85,                BarCode ID
            RB.Add(53)   ' 5
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(53)   ' 5   56=86,                ***********
            RB.Add(54)   ' 6
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(55)   ' 7
            RB.Add(44)   ' ,
            RB.Add(50)   ' 2
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(53)   ' 5    5A=90,                Label Msg
            RB.Add(65)   ' A
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(50)   ' 2
            RB.Add(44)   ' ,
            RB.Add(49)   ' 1
            RB.Add(58)   ' :
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(53)   ' 5    5B=91,               Special Price
            RB.Add(66)   ' B
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(54)   ' 6    64=100,              Fixed Weight
            RB.Add(52)   ' 4
            RB.Add(46)   ' .
            RB.Add(52)   ' 4
            RB.Add(67)   ' C
            RB.Add(44)   ' ,
            RB.Add(52)   ' 4
            RB.Add(58)   ' :
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  
            RB.Add(0)   '  

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(48)   ' 0     03                 Prefix
            RB.Add(51)   ' 3
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(51)   ' 3
            RB.Add(44)   ' ,
            RB.Add(48)   ' 0
            RB.Add(58)   ' :


            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1    1E=30,              Name2
            RB.Add(69)   ' E
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(51)   ' 3
            RB.Add(44)   ' ,
            RB.Add(48)   ' 0
            RB.Add(58)   ' :

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(49)   ' 1    1F=31,              Name3
            RB.Add(70)   ' F
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(51)   ' 3
            RB.Add(44)   ' ,
            RB.Add(48)   ' 0
            RB.Add(58)   ' :

            RB.Add(70)   ' F
            RB.Add(61)   ' =
            RB.Add(51)   ' 3   31=49,             ***************
            RB.Add(49)   ' 1
            RB.Add(46)   ' .
            RB.Add(53)   ' 5
            RB.Add(51)   ' 3
            RB.Add(44)   ' ,
            RB.Add(48)   ' 0
            RB.Add(58)   ' :
#End Region

#Region "Footer"

            Dim l As String = Hex(RB.Count - 18)
            Select Case l.Length
                Case 0
                    l = "0000"
                Case 1
                    l = "000" + l
                Case 2
                    l = "00" + l
                Case 3
                    l = "0" + l
                Case Else
                    l = l.Substring(0, 4)
            End Select
            RB(13) = AscW(l.Substring(0, 1))
            RB(14) = AscW(l.Substring(1, 1))
            RB(15) = AscW(l.Substring(2, 1))
            RB(16) = AscW(l.Substring(3, 1))

            Dim resultXor As Byte = RB(18)
            For i = 19 To RB.Count - 1
                resultXor = resultXor Xor RB(i)
            Next
            RB.Add(resultXor)
            RB.Add(10)
#End Region

            With New AlphaFramework
                Return .SendDataToNet(RB.ToArray, IP, port, delay)
            End With

        End Function

        Public Function DeleteScaleData(ip As String, port As Integer) As String
            Dim B As New List(Of Byte)
            B.Add(Asc("C"))
            B.Add(Asc("4"))
            B.Add(Asc("3"))
            B.Add(Asc("A"))
            B.Add(Asc("0"))
            B.Add(Asc("2"))
            B.Add(10)
            With New AlphaFramework
                Return .SendDataToNet(B.ToArray, ip, port)
            End With
        End Function

        Public Function DeleteScaleGroup(ip As String, port As Integer) As String
            Dim B As New List(Of Byte)
            B.Add(Asc("C"))
            B.Add(Asc("4"))
            B.Add(Asc("3"))
            B.Add(Asc("A"))
            B.Add(Asc("0"))
            B.Add(Asc("2"))
            B.Add(10)
            With New AlphaFramework
                Return .SendDataToNet(B.ToArray, ip, port)
            End With
        End Function
        Private Function convert_CL(v As String) As List(Of Byte)
            Dim rv As New List(Of Byte)
            Try
                v = Hex(Val(v)).ToLower

                Do While (v.Length > 1)
                    rv.Add(Convert.ToInt32(v.Substring(v.Length - 2, 2), 16))
                    v = v.Substring(0, v.Length - 2)
                Loop
                If v.Length > 0 Then rv.Add(Convert.ToInt32(v.Substring(0, 1), 16))
            Catch ex As Exception
                rv = New List(Of Byte)
                rv.Add(0)
            End Try
            Return rv
        End Function

    End Class

End Class

Public Class Code
    Public Function CompileCode(MyCode As String, MyForm As Form, BO As String, EXE As String, Optional NoErrorMessage As Boolean = False, Optional CreateDll As Boolean = False) As Boolean
        If MyCode.ToString.Trim.Length = 0 Then
            Return True
            Exit Function
        End If

        Dim objCodeCompiler As CodeDomProvider = CodeDomProvider.CreateProvider("CSharp")


        Dim objCompilerParametrs As New CompilerParameters
        objCompilerParametrs = ReferenceSection(objCompilerParametrs, BO, EXE)
        objCompilerParametrs.GenerateInMemory = True
        Dim objCompileResults As CompilerResults = objCodeCompiler.CompileAssemblyFromSource(objCompilerParametrs, MyCode)
        If objCompileResults.Errors.HasErrors Then
            Clipboard.Clear()
            Clipboard.SetText(MyCode)
            If NoErrorMessage = False Then MessageBox.Show("Error Line " & objCompileResults.Errors(0).Line.ToString & ", " & objCompileResults.Errors(0).ErrorText)
            'Dim ProcID As Integer = Shell("Notepad.exe", AppWinStyle.MaximizedFocus)
            'AppActivate(ProcID)
            'My.Computer.Keyboard.SendKeys("^(V)", True)
            'My.Computer.Keyboard.SendKeys("^(g)", True)
            'My.Computer.Keyboard.SendKeys(objCompileResults.Errors(0).Line.ToString, True)
            'My.Computer.Keyboard.SendKeys("{ENTER}", True)
            Return False
            Exit Function
        End If

        Dim objAssemply As Assembly = objCompileResults.CompiledAssembly
        Dim objTheClass As Object = objAssemply.CreateInstance("MegaSoftClass")
        If objTheClass Is Nothing Then
            If NoErrorMessage = False Then MessageBox.Show("Can't load class...")
            Return False
            Exit Function
        End If

        Try
            If CreateDll Then

            Else
                objTheClass.GetType.InvokeMember("main", BindingFlags.InvokeMethod, Nothing, objTheClass, New [Object]() {MyForm})
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            If NoErrorMessage = False Then MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Public Function ReferenceSection(objCompilerParametrs As CompilerParameters, BO As String, EXE As String, Optional pathBO As String = "") As System.CodeDom.Compiler.CompilerParameters
        objCompilerParametrs.ReferencedAssemblies.Add("System.dll")
        objCompilerParametrs.ReferencedAssemblies.Add("System.Drawing.dll")
        objCompilerParametrs.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        objCompilerParametrs.ReferencedAssemblies.Add("System.Windows.Forms.DataVisualization.dll")
        objCompilerParametrs.ReferencedAssemblies.Add("Microsoft.CSharp.dll")
        objCompilerParametrs.ReferencedAssemblies.Add("System.Data.dll")
        objCompilerParametrs.ReferencedAssemblies.Add("System.Xml.dll")
        'objCompilerParametrs.ReferencedAssemblies.Add("Microsoft.ML.Core.dll")
        'objCompilerParametrs.ReferencedAssemblies.Add("Microsoft.ML.Data.dll")
        'objCompilerParametrs.ReferencedAssemblies.Add("Microsoft.ML.DataView.dll")

        If Dir(pathBO + "Microsoft.ML.Core.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + "Microsoft.ML.Core.dll")
        If Dir(pathBO + "Microsoft.ML.Data.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + "Microsoft.ML.Data.dll")
        If Dir(pathBO + "Microsoft.ML.DataView.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + "Microsoft.ML.DataView.dll")
        If Dir(pathBO + BO.ToString()).Length > 0 And BO.ToString().Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + BO)
        If Dir(pathBO + EXE).Length > 0 And EXE.Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + EXE)
        If Dir(pathBO + "alphaFrameWork.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + "alphaFrameWork.dll")
        If Dir(pathBO + "bhtaFrameWork.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + "bhtaFrameWork.dll")
        If Dir(pathBO + "templates.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + "templates.dll")
        If Dir(pathBO + "Syncfusion.Shared.Base.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add(pathBO + "Syncfusion.Shared.Base.dll")
        'If Dir("Syncfusion.Edit.Windows.dll").Length > 0 Then objCompilerParametrs.ReferencedAssemblies.Add("Syncfusion.Edit.Windows.dll")

        Dim MyPath As String = pathBO + "dlls\"
        Dim MyName As String = Dir(MyPath + "*.dll")
        Do While MyName <> ""
            MyName = MyPath + MyName
            objCompilerParametrs.ReferencedAssemblies.Add(MyName)
            MyName = Dir()
        Loop


        MyName = Dir(pathBO + "*ClassLibrary.dll")
        Do While MyName <> ""
            objCompilerParametrs.ReferencedAssemblies.Add(pathBO + MyName)
            MyName = Dir()
        Loop
        Return objCompilerParametrs
    End Function

    Public Function RunFunction(MyCode As String, MaVal As Double, Optional Sec As Double = -1, Optional BO As String = "", Optional EXE As String = "", Optional pathBO As String = "") As String
        Try
            Clipboard.SetText(MyCode)
        Catch ex As Exception

        End Try
        Dim r As String = ""
        Dim objCodeCompiler As CodeDomProvider = CodeDomProvider.CreateProvider("CSharp")
        Dim objCompilerParametrs As New CompilerParameters
        objCompilerParametrs.GenerateInMemory = True
        objCompilerParametrs = ReferenceSection(objCompilerParametrs, BO, EXE, pathBO)
        Dim objCompileResults As CompilerResults = objCodeCompiler.CompileAssemblyFromSource(objCompilerParametrs, MyCode)
        If objCompileResults.Errors.HasErrors Then

            Try
                Dim tmp As String = "Error Line "
                tmp += objCompileResults.Errors(0).Line.ToString
                tmp += ", "
                tmp += objCompileResults.Errors(0).ErrorText
                objCodeCompiler = Nothing
                objCompilerParametrs = Nothing
                objCompileResults = Nothing
                Return tmp
                Exit Function
            Catch ex As Exception
                objCodeCompiler = Nothing
                objCompilerParametrs = Nothing
                objCompileResults = Nothing
                Return ex.Message
                Exit Function
            End Try
        End If

        Dim objAssemply As Assembly = objCompileResults.CompiledAssembly
        Dim objTheClass As Object = objAssemply.CreateInstance("MegaSoftClass")
        If objTheClass Is Nothing Then
            objCodeCompiler = Nothing
            objCompilerParametrs = Nothing
            objCompileResults = Nothing
            objAssemply = Nothing
            objTheClass = Nothing
            Return "Can't load class..."
            Exit Function
        End If

        r = r
        Try
            If Sec = -1 Then
                r = (objTheClass.GetType.InvokeMember("main", BindingFlags.InvokeMethod, Nothing, objTheClass, New [Object]() {MaVal})).ToString()
            Else
                r = (objTheClass.GetType.InvokeMember("main", BindingFlags.InvokeMethod, Nothing, objTheClass, New [Object]() {MaVal, Sec})).ToString()
            End If
        Catch ex As Exception
            r = ex.Message
        End Try

        objCodeCompiler = Nothing
        objCompilerParametrs = Nothing
        objCompileResults = Nothing
        objAssemply = Nothing
        objTheClass = Nothing
        Return r
    End Function

End Class


