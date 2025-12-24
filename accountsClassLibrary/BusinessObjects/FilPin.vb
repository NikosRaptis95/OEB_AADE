Imports accountsClassLibrary
Imports accountsClassLibrary.filpin_e
Imports System.IO
Imports System.Windows.Forms

Public Class ItemFilPinModel

    Public Sub New()

        _id = ""
        _Name = ""
        _Flag0 = False
        _Status = New ItemParPinModel()
        _Picture = Nothing

    End Sub

    Public Sub New(StringToFind As String)
        _id = StringToFind
        _Name = StringToFind

    End Sub

    Private _id As String
    Property id As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _Name As String
    Property Name As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property


    Private _Flag0 As Boolean
    Property Flag0 As Boolean
        Get
            Return _Flag0
        End Get
        Set(ByVal value As Boolean)
            _Flag0 = value
        End Set
    End Property

    Private _Status As ItemParPinModel
    Property Status As ItemParPinModel
        Get
            Return _Status
        End Get
        Set(ByVal value As ItemParPinModel)
            _Status = value
        End Set
    End Property

    Private _Picture As Byte()
    Property Picture As Byte()
        Get
            Return _Picture
        End Get
        Set(ByVal value As Byte())
            _Picture = value
        End Set
    End Property

End Class

Public Class FilPin

    Public Sub New()
        Me._fields = New ItemFilPinModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemFilPinModel(StringToFind)
    End Sub

    Private _fields As ItemFilPinModel
    Public Property Fields() As ItemFilPinModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemFilPinModel)
            _fields = value
        End Set
    End Property

    Public Function Insert(k As TypeOfPin) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "FilPin_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New filpin_e
            Dim MyProthema As String = .readProthema(k)
            Try
                If _fields.id.Substring(0, 2).ToUpper <> MyProthema.ToUpper Then
                    _fields.id = MyProthema + _fields.id
                End If
                If _fields.id.Length = 2 Then _fields.id += System.Guid.NewGuid.ToString
            Catch ex As Exception
                _fields.id = MyProthema + _fields.id
                If _fields.id.Length = 2 Then _fields.id += System.Guid.NewGuid.ToString
            End Try
            .Fields = _fields
            If .Insert() = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η τιμή πίνακα πιθανόν και να υπάρχει !"
            End If
        End With

    End Function

    Public Function InsertWinPlan() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "FilPin_InsertWinPlan"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New filpin_e
            .Fields = _fields
            If .Insert() = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η τιμή πίνακα πιθανόν και να υπάρχει !"
            End If
        End With

    End Function

    Public Function Update() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "FilPin_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New filpin_e
            .Fields = _fields
            If .Update = True Then
                Return ""
            Else
                Return "Αδύνατη η ενημέρωση της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η τιμή πίνακα δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function Delete(idToDelete As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "FilPin_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        Dim MyS As New SynFl()
        With MyS
            .Fields.id = Guid.NewGuid.ToString
            .Fields.Category.id = idToDelete
            .Fields.PriceList.id = idToDelete
            .Fields.Occupation.id = idToDelete
            Dim res As Integer = .ReadZoom(SynFl.TypeOfReadZoom.ReadZoom, SynFl.TypeOfSynFl.All).Rows.Count
            If res > 0 Then
                Return "Αδύνατη η διαγραφή !" + vbNewLine + vbNewLine + " Yπάρχουν " + res.ToString + "  συναλλασσόμενοι με αυτήν την τιμή πίνακα !"
            End If
        End With

        With New filpin_e
            If .Delete(idToDelete) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η τιμή πίνακα δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function DeleteWinPlan() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "FilPin_DeleteWinPlan"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New filpin_e
            If .DeleteWinPlan() = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η τιμή πίνακα δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function ReadTest() As String
        Return Application.ExecutablePath()
    End Function

    Public Function ReadTitle(ID As String, Optional lang As String = "gr") As String
        On Error Resume Next
        Select Case lang
            Case "en"
                Return New alphaFrameWork.datalayer().ReadDataCol("Select CASE WHEN LEN(NameEn) < 1 THEN [Name] ELSE NameEn END As [Name], Id From FilPin Where ID = '" + ID + "'")
            Case Else
                Return New alphaFrameWork.datalayer().ReadDataCol("Select [Name], Id From FilPin Where ID = '" + ID + "'")
        End Select

    End Function

    Public Function Read(idToFind As String, Optional lang As String = "gr") As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "FilPin_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New filpin_e
            If .Read(idToFind, lang) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η τιμή πίνακα δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ReadTitle(MyType As TypeOfPin) As String
        Select Case MyType
            Case TypeOfPin.Category
                Return "Ευρετήριο Κατηγοριών Συναλλασομένων"
            Case TypeOfPin.CategoryMtl
                Return "Ευρετήριο Κατηγοριών Ειδών"
            Case TypeOfPin.Families
                Return "Ευρετήριο Οικογενειών Ειδών"
            Case TypeOfPin.Occupation
                Return "Ευρετήριο Εππαγελμάτων"
            Case TypeOfPin.PriceList
                Return "Ευρετήριο Τιμοκαταλόγων"
            Case TypeOfPin.Users
                Return "Ευρετήριο Χρηστών"
            Case TypeOfPin.general
                Return "Ευρετήριο Γενικών Παραμέτρων"
            Case TypeOfPin.ErgaType
                Return "Ευρετήριο Κατηγοριών Υπηρεσιών"
            Case TypeOfPin.KoKiErga
                Return "Ευρετήριο Κωδ.Κιν. Εργασιών"
            Case TypeOfPin.MoMeMtl
                Return "Ευρετήριο Κωδ.Κιν. Μονάδων μέτρησης"
            Case Else
                Return "Ευρετήριο Πίνακα"
        End Select
    End Function

    Public Enum TypeOfPin
        Category
        Occupation
        PriceList
        Users
        CategoryMtl
        Families
        ErgaType
        KoKiErga
        general
        KindofTax
        MoMeMtl
    End Enum

    Public Function ReadZoom(K As TypeOfPin, Optional LenId As Integer = 0, Optional menu As String = "", Optional Or_ As Boolean = False) As DataTable
        'On Error Resume Next
        With New filpin_e
            .Fields = _fields
            Return .ReadZoom(K, LenId, menu, Or_)
        End With
    End Function

    Public Function ReadZoomFromProduct(K As TypeOfPin, idMTL As String) As DataTable
        On Error Resume Next
        With New filpin_e
            .Fields = _fields
            Return .ReadZoomFromProduct(K, idMTL)
        End With
    End Function
    Public Function ReadZoomGeneral(K As TypeOfPin) As DataTable
        On Error Resume Next
        With New filpin_e
            .Fields = _fields
            Return .ReadZoomGeneral(K)
        End With
    End Function

    Public Function ReadZoomParent(LenId As Integer, CodeParent As String) As DataTable
        'On Error Resume Next
        With New filpin_e
            .Fields = _fields
            Return .ReadZoomParent(LenId, CodeParent)
        End With
    End Function

    Public Function ReadZoomWinPlan() As DataTable
        With New filpin_e
            Return .ReadZoomWinPlan()
        End With
    End Function

    Public Function newId(prothema As String) As String
        Return New filpin_e().newId(prothema)
    End Function

    Public Function readProthema(type As TypeOfPin) As String
        Return New filpin_e().readProthema(type)
    End Function

    Public Function CreateSiteMap(Optional root As String = "https://megasoft.cc/", Optional defaultPage As String = "default", Optional category As String = "category", Optional item As String = "item", Optional timo As String = "ti003") As String
        Dim url As DataTable
        url = New DataTable("url")

        Dim loc As DataColumn = New DataColumn("loc")
        loc.DataType = System.Type.GetType("System.String")

        Dim lastmod As DataColumn = New DataColumn("lastmod")
        lastmod.DataType = System.Type.GetType("System.DateTime")

        Dim priority As DataColumn = New DataColumn("priority")
        priority.DataType = System.Type.GetType("System.String")

        url.Columns.Add(loc)
        url.Columns.Add(lastmod)
        url.Columns.Add(priority)

        Dim dt As System.DateTime = System.DateTime.Now
        Dim Row As DataRow
        Row = url.NewRow()

        Row.Item("loc") = root + "/" + defaultPage
        Row.Item("lastmod") = dt
        Row.Item("priority") = ((1).ToString("#0.00")).Replace(",", ".")

        url.Rows.Add(Row)

        Dim a = New alphaFrameWork.AlphaFramework()

        Dim dtc As New DataTable
        dtc = New FilPin("%").ReadZoom(TypeOfPin.Families)
        For i As Integer = 0 To dtc.Rows.Count - 1
            Row = url.NewRow()
            Row.Item("loc") = root + "/" + category + "/" + dtc.Rows(i).Item("id").ToString() + "/" + ConvertEnglish(a.ClearName(dtc.Rows(i).Item("Name").ToString()))
            Row.Item("lastmod") = dt
            Row.Item("priority") = ((0.8).ToString("#0.00")).Replace(",", ".")
            url.Rows.Add(Row)
        Next

        Dim dti As New DataTable
        dti = New MtlFl("%").ReadZoom(MtlFl.TypeOfZoom.CatalogWeb, timo, "E", "", "", "")
        For i As Integer = 0 To dti.Rows.Count - 1
            Row = url.NewRow()
            Row.Item("loc") = root + "/" + item + "/" + dti.Rows(i).Item("id").ToString() + "/" + ConvertEnglish(a.ClearName(dti.Rows(i).Item("Description").ToString()))
            Row.Item("lastmod") = dt
            Row.Item("priority") = ((0.64).ToString("#0.00")).Replace(",", ".")
            url.Rows.Add(Row)
        Next

        Dim ds As New DataSet("urlset")
        ds.Tables.Add(url)
        Return ds.GetXml

    End Function
    Private Function ConvertEnglish(description As String) As String
        description = description.ToLower()
        description = description.Replace("""", "'")
        description = description.Replace("^", "-").Replace("\", "-").Replace("|", "-").Replace("}", "-").Replace("{", "-").Replace("]", "-").Replace("[", "-").Replace(">", "-").Replace("<", "-").Replace("#", "-").Replace("%", "-")
        description = description.Replace("@", "-").Replace("$", "-").Replace("?", "-").Replace("=", "-").Replace(" ", "-").Replace(".", "-").Replace(":", "-").Replace("/", "-").Replace("&", "-").Replace("+", "-").Replace("~", "-")
        description = description.Replace("α", "a").Replace("β", "v").Replace("γ", "g").Replace("δ", "d").Replace("ε", "e").Replace("ζ", "z").Replace("η", "i").Replace("θ", "th").Replace("ι", "i").Replace("κ", "k")
        description = description.Replace("λ", "l").Replace("μ", "m").Replace("ν", "n").Replace("ξ", "x").Replace("ο", "o").Replace("π", "p").Replace("ρ", "r").Replace("σ", "s").Replace("τ", "t").Replace("υ", "y")
        description = description.Replace("φ", "f").Replace("χ", "x").Replace("ψ", "ps").Replace("ω", "o")
        description = description.Replace("ά", "a").Replace("έ", "e").Replace("ή", "i").Replace("ί", "i").Replace("ό", "o").Replace("ύ", "y").Replace("ώ", "o").Replace("ς", "s")
        Return description
    End Function

End Class

Public Class filpin_e
    Dim _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        Me.Fields = New ItemFilPinModel
    End Sub

    Private _fields As ItemFilPinModel
    Public Property Fields() As ItemFilPinModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemFilPinModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into filpin (ID) Values ('" + _fields.id.Replace("'", "") + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_fields.id)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim flag0 As String
        Select Case _fields.Flag0
            Case True
                flag0 = "1"
            Case Else
                flag0 = "0"
        End Select

        Try
            Dim SQL As String = "Update filpin Set Name = '" + _fields.Name.Replace("'", "`") +
                                          "' , Flag0 = " + flag0 +
                                          " , Status = '" + _fields.Status.id.Replace("'", "`") +
                                          "' Where ID = '" + _fields.id + "'"
            If _DataLayer.ExecuteNonQuery(SQL, _fields.Picture) Then

                ' ***** picture ******
                SQL = "Update filpin Set Picture = @img " +
                                      " Where ID = '" + _fields.id + "'"
                _DataLayer.ExecuteNonQuery(SQL, _fields.Picture)
                ' ********************

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Delete(idToDelete As String) As Boolean
        Dim SQL As String = "Delete From filpin Where ID = '" + idToDelete + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function DeleteWinPlan() As Boolean
        Dim SQL As String = "Delete From filpin Where (ID LIKE 'mm%') OR (ID LIKE 'xa%') OR (ID LIKE 'ka%') OR (ID LIKE 'ti%') OR (ID LIKE 'fp%')"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(idToFind As String, lang As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select ID , Name , Flag0 , Status , Picture From filpin Where ID = '" + idToFind + "'"
        Select Case lang
            Case "en"
                SQL = SQL.Replace("Picture", "Picture, NameEn ")
            Case Else
                '
        End Select

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            _fields.id = MyTable.Rows(0).Item("ID")
            Select Case lang
                Case "en"
                    _fields.Name = MyTable.Rows(0).Item("NameEn")
                Case Else
                    _fields.Name = MyTable.Rows(0).Item("Name")
            End Select
            _fields.Flag0 = MyTable.Rows(0).Item("Flag0")
            With New ParPin
                .Read(ParPin.TypeOfPar.Status, MyTable.Rows(0).Item("Status"))
                _fields.Status = .Fields
            End With
            _fields.Picture = MyTable.Rows(0).Item("Picture")
        Next

        Return MyTable.Rows.Count
    End Function


    Public Function readProthema(K As FilPin.TypeOfPin) As String
        On Error Resume Next
        Select Case K
            Case FilPin.TypeOfPin.Occupation
                Return "ep"
            Case FilPin.TypeOfPin.PriceList
                Return "ti"
            Case FilPin.TypeOfPin.Category
                Return "ks"
            Case FilPin.TypeOfPin.CategoryMtl
                Return "ka"
            Case FilPin.TypeOfPin.Families
                Return "xa"
            Case FilPin.TypeOfPin.general
                Return "xr"
            Case FilPin.TypeOfPin.ErgaType
                Return "er"
            Case FilPin.TypeOfPin.KoKiErga
                Return "ke"
            Case FilPin.TypeOfPin.KindofTax
                Return "fp"
            Case FilPin.TypeOfPin.MoMeMtl
                Return "mm"
            Case Else
                Return "us"
        End Select
    End Function


    Public Function ReadZoomFromProduct(K As FilPin.TypeOfPin, idMTL As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Name " +
                            "FROM FilPin "
        Dim Where As String = "Where "


        SQL = SQL + Where + " id Like '" + readProthema(K) + "%' order by name "


        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)


        Dim myDataTable As New DataTable()
        myDataTable.Columns.Add("id", GetType(String))
        myDataTable.Columns.Add("Name", GetType(String))
        Dim t = New Times()
        For i As Integer = 0 To MyTable.Rows.Count - 1
            If t.Read(idMTL, MyTable.Rows(i)("id").ToString()).Trim().Length <> 0 Then
                myDataTable.Rows.Add(MyTable.Rows(i)("id").ToString(), MyTable.Rows(i)("Name").ToString())
            End If
        Next i

        Return myDataTable
    End Function

    Public Function ReadZoomGeneral(K As FilPin.TypeOfPin) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Name " +
                            "FROM FilPin "
        Dim Where As String = "Where "


        SQL = SQL + Where + " id Like '" + readProthema(K) + "%' order by name "


        Dim MyTable As New DataTable
        Return _DataLayer.ReadDataTable(SQL)
    End Function
    Public Function ReadZoom(K As FilPin.TypeOfPin, LenId As Integer, menu As String, Or_ As Boolean) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Name, Flag0, Status, Picture " +
                            "FROM filpin "
        Dim Where As String = "Where ( ("

        If LenId > 0 Then Where += (" LEN(id)=" + LenId.ToString + ") And (")



        If _fields.Flag0 = True Then
            SQL = SQL + Where + MyA.WhereFunc(Me.Fields, "FilPin") + ") And (Flag0 = 1) And (id Like '" + readProthema(K) + "%') ) "
        Else
            SQL = SQL + Where + MyA.WhereFunc(Me.Fields, "FilPin") + ") And (id Like '" + readProthema(K) + "%') ) "
        End If

        SQL = SQL + " AND ([Name] NOT Like '%@Off%') "

        Dim so As String = " And "
        If Or_ Then
            so = " Or "
        End If
        If menu.Length > 0 Then SQL += (so + "( [Name] Like '%" + "@" + menu + ";%') ")

        SQL += " order by name"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Return MyTable
    End Function

    Public Function ReadZoomParent(LenId As Integer, ParentCode As String) As DataTable
        On Error Resume Next
        Dim SQL As String = "SELECT id, Name FROM filpin Where LEN(id)=" + LenId.ToString + " And id Like '" + ParentCode + "%' order by id"
        Return _DataLayer.ReadDataTable(SQL)
    End Function


    Public Function ReadZoomWinPlan() As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim sql As String = "Select  
                                    id, 
                                    [Name], 
                                    Flag0,
                                    Status,
                                    Relation,
                                    Picture 
                            From (SELECT  
                                          Replace(Replace(Replace(Replace(CodePin, 'ΧΑ', 'ka'), 'ΤΙ', 'ti'), 'ΦΠ', 'fp'), 'ΜΜ', 'mm') AS Id, 
                                          DescPin AS Name, 
                                          1 AS Flag0, 
                                          1 AS Status, 
                                          '' AS Relation, 
                                          NULL AS Picture
                                     FROM dbo.ADV_FilPin
                                 WHERE CodePin LIKE 'ΧΑ%' OR
                                       CodePin LIKE 'ΜΜ%' OR
                                       CodePin LIKE 'ΤΙ%' OR
                                       CodePin LIKE 'ΦΠ%'
                                 UNION ALL
                                 SELECT  
                                        'xa' + CodeAnh AS ID, 
                                         PeriAnh AS Name, 
                                         1 AS Flag0, 
                                         1 AS Status, 
                                         '' AS Relation, 
                                         NULL AS Picture
                                FROM ADV_AnhFl) As FilPin_WinPlan"

        Dim fn As String = "app_data\connectionstring_WinPlan.txt"
        Dim DE As String = ""
        Dim CS As String = ""
        If Dir(fn).Length > 0 Then
            Using sr As New StreamReader(fn)
                DE = sr.ReadLine()
                DE = sr.ReadLine()
                CS = sr.ReadLine()
            End Using
        End If

        Return _DataLayer.ReadDataTable(sql, CS, DE)
    End Function

    Public Function newId(prothema As String) As String
        Dim sql As String = "SELECT MAX(LEN(id)) FROM FilPin Where id Like '" + prothema + "%'"
        Dim Id As String = ""
        Try
            Dim MaxLen As Integer = 0
            MaxLen = CInt(_DataLayer.ReadDataTable(sql).Rows(0)(0))
            sql = "SELECT MAX(id) FROM FilPin Where Len(id) = " + CStr(MaxLen) + " And Id Like '" + prothema + "%'"
            Try
                Dim tmpstr As String = _DataLayer.ReadDataTable(sql).Rows(0)(0)
                tmpstr = tmpstr.Substring(2, Len(tmpstr) - 2)
                Id = CStr(CInt(tmpstr) + 1)
                For i As Integer = 1 To MaxLen - Len(Id) - 2
                    Id = "0" + Id
                Next
            Catch ex As Exception
                Id = System.Guid.NewGuid.ToString()
            End Try
            Return Id
        Catch ex As Exception
            Id = System.Guid.NewGuid.ToString()
            Return Id
        End Try
    End Function

End Class