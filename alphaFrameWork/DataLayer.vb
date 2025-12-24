Imports System.IO
Imports System.Windows.Forms

Public Class datalayer
    ' Αφορά τα δεδομένα

    'Private DE As String = "SQLSERVERCE"
    'Private CS As String = "DataSource=app_data\database.sdf;"

    'Private DE As String = "OLEDB"
    'Private CS As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|database.mdb"
    'Private CS As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=app_data\database.mdb;Persist Security Info=False;"
    'Private CS As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=app_data\database.mdb;Persist Security Info=True;"

    Private DE As String = "SQLCLIENT"
    Private CS As String = "server=207.180.249.126;Initial Catalog=e-event.eu;uid=l1usr;pwd=41accb27-3922-48b3-869a-69b3d2b8bba6;"

    'Private CS As String = "server=207.180.249.126;Initial Catalog=erateino;uid=l1usr;pwd=41accb27-3922-48b3-869a-69b3d2b8bba6;"

#Region "General"

    Public Function GetPivotConnectionString() As String

        ReadConnectionString()
        Select Case DE.ToUpper
            Case "OLEDB"
                Return CS
            Case "SQLCLIENT"
                Return "Provider=SQLOLEDB.1;" + CS.Replace("SERVER=", "Data Source=").Replace("Server=", "Data Source=").Replace("server=", "Data Source=").Replace("Uid=", "User Id=").Replace("uId=", "User Id=").Replace("UId=", "User Id=").Replace("UID=", "User Id=").Replace("UiD=", "User Id=").Replace("uid=", "User Id=").Replace("pwd=", "Password=").Replace("PWD=", "Password=").Replace("Pwd=", "Password=").Replace("PwD=", "Password=").Replace("pwD=", "Password=").Replace("pWd=", "Password=")
            Case "ODBC"
                Return CS
            Case Else
                Return CS
        End Select

    End Function

    Public Function dateMark() As String
        ReadConnectionString()
        If CS.ToUpper.IndexOf(".ACCDB") > 0 Or CS.ToUpper.IndexOf(".MDB") > 0 Then
            Return "#"
        Else
            Return "'"
        End If
    End Function

    Private Sub ReadConnectionString(Optional fn As String = "app_data\connectionstring.txt")
        Try
            'fn = System.Environment.CurrentDirectory.ToUpper + "\" + fn
            'fn = System.Environment.GetFolderPath(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\" + fn
            'MessageBox.Show(fn, "beforebefore")

            'fn = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToUpper.Replace("FILE:\", "") + "\" + fn

            'MessageBox.Show(fn, "before")
            Using sr As New StreamReader(fn)
                DE = sr.ReadLine()
                DE = sr.ReadLine()
                Dim b = New bhtaFramework.bhtaFramework()
                CS = sr.ReadLine().Replace("@clouduid", b.clouduid).Replace("@cloudpwd", b.cloudpwd)
            End Using
            'MessageBox.Show(CS, "after")

        Catch e As Exception
            'MessageBox.Show(e.Message + vbNewLine + fn, e.Message)
            'File.WriteAllLines("megasoft_err.log", e.Message)
        End Try
    End Sub

    Private Function Atack(sql As String) As Boolean

        Return False

        'If sql.ToUpper.IndexOf("VIAGRA") > -1 Or
        '   sql.ToUpper.IndexOf("SUMATRIPTAN") > -1 Or
        '   sql.ToUpper.IndexOf("GABAPENTIN") > -1 Or
        '   sql.ToUpper.IndexOf("CIALIS") > -1 Or
        '   sql.ToUpper.IndexOf("DRUG") > -1 Or
        '   sql.ToUpper.IndexOf("http") > -1 Or
        '   sql.ToUpper.IndexOf("HTTP") > -1 Then
        '    Return True
        'Else
        '    Return False
        'End If

    End Function

    Public Function ExtractSubsets(ByVal inputString As String) As List(Of String)
        Dim subsets As New List(Of String)
        Dim startIndex As Integer = 0

        While startIndex < inputString.Length
            Dim openingBraceIndex As Integer = inputString.IndexOf("{"c, startIndex)
            If openingBraceIndex < 0 Then ' if no opening brace is found, exit loop
                Exit While
            End If

            Dim closingBraceIndex As Integer = inputString.IndexOf("}"c, openingBraceIndex)
            If closingBraceIndex < 0 Then ' if no closing brace is found, exit loop
                Exit While
            End If

            Dim subsetLength As Integer = closingBraceIndex - openingBraceIndex + 1
            Dim subset As String = inputString.Substring(openingBraceIndex, subsetLength)
            subsets.Add(subset)

            startIndex = closingBraceIndex + 1
        End While

        Return subsets
    End Function


#End Region

#Region "Data Functions"

    Public Function ReadDataTable(sql As String, Optional ConnectionString As String = "", Optional DataEngine As String = "") As Data.DataTable
        'If Atack(sql) Then
        '    Return Nothing
        'Else

        If ConnectionString = "" Or DataEngine = "" Then
            ReadConnectionString()
            ConnectionString = CS
            DataEngine = DE
        End If

        Dim Res As String = sql
        Dim myData As New Data.DataTable("Result")
        Try
            Select Case DataEngine.ToUpper
                Case "OLEDB"
                    Dim DataAdapterOleDb As New OleDb.OleDbDataAdapter(sql, ConnectionString)
                    DataAdapterOleDb.Fill(myData)
                    DataAdapterOleDb.Dispose()
                Case "SQLCLIENT"
                    Dim DataAdapterClientSQL As New SqlClient.SqlDataAdapter(sql, ConnectionString)
                    DataAdapterClientSQL.Fill(myData)
                    DataAdapterClientSQL.Dispose()
                Case "ODBC"
                    Dim DataAdapterOdbc As New Odbc.OdbcDataAdapter(sql, ConnectionString)
                    DataAdapterOdbc.Fill(myData)
                    DataAdapterOdbc.Dispose()
                    'Case "SQLSERVERCE"
                    '    Dim DataAdapterCE As New SqlServerCe.SqlCeDataAdapter(sql, ConnectionString)
                    '    DataAdapterCE.Fill(myData)
                    '    DataAdapterCE.Dispose()
            End Select
        Catch ex As Exception
            Res = ex.Message
            'MessageBox.Show(ConnectionString + vbNewLine + sql, Res)
            'myData = Nothing
        End Try

        'With New AlphaFramework
        '    .WriteInLogFile(Now.ToString + " *** " + Res + vbNewLine + vbNewLine)
        'End With

        Return myData
        'End If
    End Function

    Public Function ReadDataCol(sql As String, Optional ConnectionString As String = "", Optional DataEngine As String = "") As String
        'If Atack(sql) Then
        '    Return ""
        'Else
        With ReadDataTable(sql, ConnectionString, DataEngine)
            If .Rows.Count > 0 Then
                Return .Rows(0).Item(0).ToString
            Else
                Return ""
            End If
        End With
        'End If
    End Function

    Public Function ExecuteNonQuery(sql As String, Optional MyPicture As Object = Nothing, Optional ConnectionString As String = "", Optional DataEngine As String = "") As Boolean
        'If Atack(sql) Then
        '    Return False
        'Else
        If ConnectionString = "" Or DataEngine = "" Then
            ReadConnectionString()
            ConnectionString = CS
            DataEngine = DE
        End If
        If ConnectionString = "forRW" Or DataEngine = "forRW" Then
            ReadConnectionString("connectionstring_forRW.txt")
            ConnectionString = CS
            DataEngine = DE
        End If

        Dim result As Boolean = True
        Dim Res As String = sql
        Try
            Select Case DataEngine.ToUpper
                Case "OLEDB"
                    Dim MyC As New OleDb.OleDbConnection(ConnectionString)
                    MyC.Open()
                    Dim command As New OleDb.OleDbCommand(sql, MyC)

                    If sql.IndexOf("@img") > 0 Then
                        Try
                            command.Parameters.AddWithValue("@img", MyPicture)
                            command.ExecuteNonQuery()
                        Catch ex As Exception

                        End Try
                    Else
                        command.ExecuteNonQuery()
                    End If

                    MyC.Close()
                Case "SQLCLIENT"
                    Dim MyC As New SqlClient.SqlConnection(ConnectionString)

                    MyC.Open()
                    Dim command As New SqlClient.SqlCommand(sql, MyC)
                    command.CommandTimeout = 480

                    If sql.IndexOf("@img") > 0 Then
                        Try
                            command.Parameters.AddWithValue("@img", MyPicture)
                            command.ExecuteNonQuery()
                        Catch ex As Exception

                        End Try
                    Else
                        command.ExecuteNonQuery()
                    End If
                    MyC.Close()
                Case "ODBC"
                    Dim MyC As New Odbc.OdbcConnection(ConnectionString)
                    MyC.Open()
                    Dim command As New Odbc.OdbcCommand(sql, MyC)
                    If sql.IndexOf("@img") > 0 Then
                        Try
                            command.Parameters.AddWithValue("@img", MyPicture)
                            command.ExecuteNonQuery()
                        Catch ex As Exception

                        End Try
                    Else
                        command.ExecuteNonQuery()
                    End If
                    MyC.Close()
                    'Case "SQLSERVERCE"
                    '    Dim MyC As New SqlServerCe.SqlCeConnection(ConnectionString)
                    '    MyC.Open()
                    '    Dim command As New SqlServerCe.SqlCeCommand(sql, MyC)
                    '    If sql.IndexOf("@img") > 0 Then command.Parameters.AddWithValue("@img", MyPicture)
                    '    command.ExecuteNonQuery()
                    '    MyC.Close()
            End Select
        Catch ex As Exception
            result = False
            Res = ex.Message
            'MessageBox.Show(ConnectionString + vbNewLine + sql, Res)
        End Try
        '    With New AlphaFramework
        '        .WriteInLogFile(Now.ToString + " *** " + Res + vbNewLine + vbNewLine)
        '    End With
        Return result
        'End If
    End Function

#End Region

#Region "CheckDataBase"
    Public Sub GetCheckDatabase()
        Dim path As String = "app_data\checkDatabase\"
        Dim dt As DataSet

        For Each file As IO.FileInfo In Get_Files(path,
                                              IO.SearchOption.TopDirectoryOnly,
                                              "xml",
                                              "TABLE")
            dt = New DataSet()
            dt.ReadXml(path + file.Name)
            CheckTables(dt)
        Next

        For Each file As IO.FileInfo In Get_Files(path,
                                             IO.SearchOption.TopDirectoryOnly,
                                             "xml",
                                             "VIEW")
            dt = New DataSet()
            dt.ReadXml(path + file.Name)
            CheckViews(dt)
        Next

        For Each file As IO.FileInfo In Get_Files(path,
                                            IO.SearchOption.TopDirectoryOnly,
                                            "xml",
                                            "UPDATE")
            dt = New DataSet()
            dt.ReadXml(path + file.Name)
            CheckUpdate(dt)
        Next

        For Each file As IO.FileInfo In Get_Files(path,
                                            IO.SearchOption.TopDirectoryOnly,
                                            "xml",
                                            "CUSTOM")
            dt = New DataSet()
            dt.ReadXml(path + file.Name)
            CheckCustom(dt)
        Next

    End Sub
    Private Function Get_Files(ByVal directory As String,
                           ByVal recursive As IO.SearchOption,
                           ByVal ext As String,
                           ByVal with_word_in_filename As String) As List(Of IO.FileInfo)
        Try
            Return IO.Directory.GetFiles(directory, "*" & If(ext.StartsWith("*"), ext.Substring(1), ext), recursive) _
                           .Where(Function(o) o.ToLower.Contains(with_word_in_filename.ToLower)) _
                           .Select(Function(p) New IO.FileInfo(p)).ToList
        Catch ex As Exception
            Return New List(Of FileInfo)
        End Try

    End Function

    '******************** Tables
    Private Sub CheckTables(ds As DataSet)
        Dim DatabaseType As String = "SQLSERVER"
        If dateMark.Equals("#") Then DatabaseType = "MSACCESS"
        Dim TableName As String = ""
        Dim TableNameFields As String = ""
        Try
            For i_Tables As Integer = 0 To ds.Tables("Table").Rows.Count - 1
                TableName = ds.Tables("Table").Rows(i_Tables)("Name")
                TableNameFields = TableName + "_Field"
                Dim fields As List(Of Field) = New List(Of Field)()
                For i_Fields As Integer = 0 To ds.Tables(TableNameFields).Rows.Count - 1
                    If ds.Tables(TableNameFields).Rows(i_Fields)("DatabaseType").ToString().ToUpper().IndexOf(DatabaseType) > -1 Then
                        Dim field As New Field
                        With field
                            .Name = ds.Tables(TableNameFields).Rows(i_Fields)("Name")
                            .DataType = ds.Tables(TableNameFields).Rows(i_Fields)("DataType")
                            .Indexed = ds.Tables(TableNameFields).Rows(i_Fields)("Indexed")
                            .DefaultS = ds.Tables(TableNameFields).Rows(i_Fields)("Default")
                        End With
                        fields.Add(field)
                    End If
                Next
                CheckTable(TableName, fields)
            Next
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub CheckTable(table As String, fields As List(Of Field))
        ' **********************************************

        ' if table exist
        If Not ExecuteNonQuery("select 1 from " + table + " where 1 = 0") Then
            Dim Sql As String = "CREATE TABLE " + table + " ("
            For i As Integer = 0 To fields.Count - 1
                If i > 0 Then Sql += ", "
                If fields(i).Name.ToUpper.IndexOf("PRIMARY KEY") = -1 Then
                    Sql += (" [" + fields(i).Name + "] " + fields(i).DataType)
                Else
                    Sql += (fields(i).Name + fields(i).DataType)
                End If
                Select Case fields(i).Indexed
                    Case "1"
                        Sql += " NOT NULL PRIMARY KEY "
                    Case "2"
                        Sql += " NOT NULL "
                    Case "3"
                        Sql += " NOT NULL "
                    Case "4"
                        Sql += " NOT NULL "
                    Case Else
                        If fields(i).Name.ToUpper.IndexOf("PRIMARY KEY") = -1 Then Sql += " NULL "
                End Select
                If fields(i).DefaultS.Trim.Length > 0 Then Sql += ("DEFAULT " + fields(i).DefaultS)
            Next
            Sql += ")"
            ExecuteNonQuery(Sql)
        End If

        ' **********************************************
    End Sub


    '******************** Views
    Private Sub CheckViews(ds As DataSet)
        Dim DatabaseType As String = ""
        If dateMark.Equals("#") Then
            DatabaseType = "MSACCESS"
            Dim sql As String = ""
            Try
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("DatabaseType").ToString().ToUpper().IndexOf(DatabaseType) > -1 Then
                        Try
                            sql = "DROP VIEW " + ds.Tables(0).Rows(i)("Name").ToString()
                            'ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        Try
                            sql = "CREATE VIEW " + ds.Tables(0).Rows(i)("Name").ToString() + " AS " + ds.Tables(0).Rows(i)("SQL").ToString().Replace("&lt;", "<").Replace("&gt;", ">")
                            'ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        sql += ""
                    End If
                Next
            Catch ex As Exception
                '
            End Try
        Else
            DatabaseType = "SQLSERVER"
            Dim sql As String = ""
            Try
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("DatabaseType").ToString().ToUpper().IndexOf(DatabaseType) > -1 Then
                        Try
                            sql = "DROP VIEW " + ds.Tables(0).Rows(i)("Name").ToString()
                            ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        Try
                            sql = "CREATE VIEW " + ds.Tables(0).Rows(i)("Name").ToString() + " AS " + ds.Tables(0).Rows(i)("SQL").ToString().Replace("&lt;", "<").Replace("&gt;", ">")
                            ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        sql += ""
                    End If
                Next
            Catch ex As Exception
                '
            End Try
        End If

    End Sub

    '******************** Update
    Private Sub CheckUpdate(ds As DataSet)
        Dim DatabaseType As String = ""
        If dateMark.Equals("#") Then
            DatabaseType = "MSACCESS"
            Dim sql As String = ""
            Try
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("DatabaseType").ToString().ToUpper().IndexOf(DatabaseType) > -1 Then
                        Try
                            sql = ds.Tables(0).Rows(i)("SQL").ToString().Replace("&lt;", "<").Replace("&gt;", ">")
                            ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        sql += ""
                    End If
                Next
            Catch ex As Exception
                '
            End Try
        Else
            DatabaseType = "SQLSERVER"
            Dim sql As String = ""
            Try
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("DatabaseType").ToString().ToUpper().IndexOf(DatabaseType) > -1 Then
                        Try
                            sql = ds.Tables(0).Rows(i)("SQL").ToString().Replace("&lt;", "<").Replace("&gt;", ">")
                            ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        sql += ""
                    End If
                Next
            Catch ex As Exception
                '
            End Try
        End If

    End Sub


    '******************** Custom
    Private Sub CheckCustom(ds As DataSet)
        Dim DatabaseType As String = ""
        If dateMark.Equals("#") Then
            DatabaseType = "MSACCESS"
            Dim sql As String = ""
            Try
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("DatabaseType").ToString().ToUpper().IndexOf(DatabaseType) > -1 Then
                        Try
                            sql = ds.Tables(0).Rows(i)("SQL").ToString().Replace("&lt;", "<").Replace("&gt;", ">")
                            ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        sql += ""
                    End If
                Next
            Catch ex As Exception
                '
            End Try
        Else
            DatabaseType = "SQLSERVER"
            Dim sql As String = ""
            Try
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("DatabaseType").ToString().ToUpper().IndexOf(DatabaseType) > -1 Then
                        Try
                            sql = ds.Tables(0).Rows(i)("SQL").ToString().Replace("&lt;", "<").Replace("&gt;", ">")
                            ExecuteNonQuery(sql)
                        Catch ex As Exception
                            '
                        End Try
                        sql += ""
                    End If
                Next
            Catch ex As Exception
                '
            End Try
        End If

    End Sub

    Private Class Field
        Public Name As String
        Public DataType As String
        Public PrimaryKey As Boolean
        Public Indexed As Integer ' 0=No Index 1=Primary Key 2=Index No Dublicates 3=Index Dublicates
        Public DefaultS As String
    End Class

#End Region

End Class
