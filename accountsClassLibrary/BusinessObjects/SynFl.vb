

Public Class ItemSynFlModel
    Inherits accountsClassLibrary_Custom.BusinessObjects.ItemSynFlModel

    Public Sub New()

        _id = ""
        _Name = ""
        _Address = ""
        _PhoneNo = ""
        _AFM = ""
        _DOY = ""
        _Line = ""
        _Status = New ItemParPinModel()
        _Category = New ItemFilPinModel()
        _Occupation = New ItemFilPinModel()
        _PriceList = New ItemFilPinModel()
        _KindOfTax = New ItemParPinModel()
        _eMail = ""
        _WebSite = ""
        _Map = ""
        _Memo = ""
        _Kind = New ItemParPinModel()
        _Ypoloipo = 0
    End Sub
    Public Sub New(StringToFind As String)

        _id = StringToFind
        _Name = StringToFind
        _Address = StringToFind
        _PhoneNo = StringToFind
        _AFM = StringToFind
        _DOY = StringToFind
        _Line = StringToFind
        _Status = New ItemParPinModel(StringToFind)
        _Category = New ItemFilPinModel(StringToFind)
        _Occupation = New ItemFilPinModel(StringToFind)
        _PriceList = New ItemFilPinModel(StringToFind)
        _KindOfTax = New ItemParPinModel(StringToFind)
        _eMail = StringToFind
        _WebSite = StringToFind
        _Map = StringToFind
        _Memo = StringToFind
        _Kind = New ItemParPinModel(StringToFind)
        _Ypoloipo = 0
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

    Private _Address As String
    Property Address As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Private _PhoneNo As String
    Property PhoneNo As String
        Get
            Return _PhoneNo
        End Get
        Set(ByVal value As String)
            _PhoneNo = value
        End Set
    End Property

    Private _AFM As String
    Property AFM As String
        Get
            Return _AFM
        End Get
        Set(ByVal value As String)
            _AFM = value
        End Set
    End Property

    Private _DOY As String
    Property DOY As String
        Get
            Return _DOY
        End Get
        Set(ByVal value As String)
            _DOY = value
        End Set
    End Property

    Private _Line As String
    Property Line As String
        Get
            Return _Line
        End Get
        Set(ByVal value As String)
            _Line = value
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

    Private _Category As ItemFilPinModel
    Property Category As ItemFilPinModel
        Get
            Return _Category
        End Get
        Set(ByVal value As ItemFilPinModel)
            _Category = value
        End Set
    End Property

    Private _Occupation As ItemFilPinModel
    Property Occupation As ItemFilPinModel
        Get
            Return _Occupation
        End Get
        Set(ByVal value As ItemFilPinModel)
            _Occupation = value
        End Set
    End Property

    Private _PriceList As ItemFilPinModel
    Property PriceList As ItemFilPinModel
        Get
            Return _PriceList
        End Get
        Set(ByVal value As ItemFilPinModel)
            _PriceList = value
        End Set
    End Property

    Private _KindOfTax As ItemParPinModel
    Property KindOfTax As ItemParPinModel
        Get
            Return _KindOfTax
        End Get
        Set(ByVal value As ItemParPinModel)
            _KindOfTax = value
        End Set
    End Property

    Private _eMail As String
    Property eMail As String
        Get
            Return _eMail
        End Get
        Set(ByVal value As String)
            _eMail = value
        End Set
    End Property

    Private _WebSite As String
    Property WebSite As String
        Get
            Return _WebSite
        End Get
        Set(ByVal value As String)
            _WebSite = value
        End Set
    End Property

    Private _Map As String
    Property Map As String
        Get
            Return _Map
        End Get
        Set(ByVal value As String)
            _Map = value
        End Set
    End Property

    Private _Memo As String
    Property Memo As String
        Get
            Return _Memo
        End Get
        Set(ByVal value As String)
            _Memo = value
        End Set
    End Property

    Private _Kind As ItemParPinModel
    Property Kind As ItemParPinModel
        Get
            Return _Kind
        End Get
        Set(ByVal value As ItemParPinModel)
            _Kind = value
        End Set
    End Property

    Private _Ypoloipo As Double
    Property Ypoloipo As Double
        Get
            Return _Ypoloipo
        End Get
        Set(ByVal value As Double)
            _Ypoloipo = value
        End Set
    End Property

End Class

Public Class SynFl

    Public Sub New(StringToFind As String)
        Me.Fields = New ItemSynFlModel(StringToFind)
    End Sub

    Public Sub New()
        Me.Fields = New ItemSynFlModel
    End Sub

    Private _fields As ItemSynFlModel
    Public Property Fields() As ItemSynFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemSynFlModel)
            _fields = value
        End Set
    End Property
    Public Function newId() As String
        Return New SynFl_e().newId()
    End Function

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "SynFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .id.Trim.Length < 1 Then .id = System.Guid.NewGuid.ToString
            Dim cp As New FilPin
            Dim res As String = cp.Read(_fields.Category.id)
            If res.Length > 0 Then Return res
            res = cp.Read(_fields.Occupation.id)
            If res.Length > 0 Then Return res
            res = cp.Read(_fields.PriceList.id)
            If res.Length > 0 Then Return res
            If .KindOfTax.id.Trim.Length < 1 Then Return "Δεν υπάρχει κατηγορία ΦΠΑ  !"
            If .Kind.id.Trim.Length < 1 Then Return "Δεν υπάρχει τύπος συναλλασόμενου  !"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With

        With New SynFl_e
            .Fields = _fields
            If .Insert = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτός ο συναλλασσόμενος πιθανόν και να υπάρχει !"
            End If
        End With

    End Function

    Public Function Update() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "SynFl_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .id.Trim.Length < 1 Then .id = System.Guid.NewGuid.ToString
            Dim cp As New FilPin
            Dim res As String = cp.Read(_fields.Category.id)
            If res.Length > 0 Then Return res
            res = cp.Read(_fields.Occupation.id)
            If res.Length > 0 Then Return res
            res = cp.Read(_fields.PriceList.id)
            If res.Length > 0 Then Return res
            If .KindOfTax.id.Trim.Length < 1 Then Return "Δεν υπάρχει κατηγορία ΦΠΑ  !"
            If .Kind.id.Trim.Length < 1 Then Return "Δεν υπάρχει τύπος συναλλασόμενου  !"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With

        With New SynFl_e
            .Fields = _fields
            If .Update = True Then
                Return ""
            Else
                Return "Αδύνατη η ενημέρωση της εγγραφής" + vbNewLine + vbNewLine + "Αυτός ο συναλλασσόμενος δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function Delete(idToDelete As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "SynFl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New KinFl(System.Guid.NewGuid.ToString)
            .Fields.idSyn.id = idToDelete
            Dim md As DataTable = .ReadZoom(KinFl.TypeOfKin.All)
            If md.Rows.Count > 0 Then
                Return "Ο κωδικός του συναλλασόμενου έχει αναφορά σε " + md.Rows.Count.ToString + " εισπράξεις - πληρωμές." + vbNewLine + "Δεν μπορεί να διαγραφεί, εάν πρώτα δεν διαγραφούν αυτές οι αναφορές !"
                Exit Function
            End If
        End With

        With New SynFl_e
            .Fields.id = idToDelete
            If .Delete(idToDelete) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτός ο συναλλασσόμενος δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function Read(idToFind As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "SynFl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New SynFl_e
            If .Read(idToFind) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτός ο συναλλασσόμενος δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Enum TypeOfSynFl
        Customers
        Supliers
        CustomersSupliers
        All
    End Enum

    Public Function ReadTitle(MyType As TypeOfSynFl) As String
        Select Case MyType
            Case TypeOfSynFl.Customers
                Return "Πελάτες"
            Case TypeOfSynFl.CustomersSupliers
                Return "Πελάτες - Προμηθευτές"
            Case TypeOfSynFl.Supliers
                Return "Προμηθευτές"
            Case Else
                Return "Όλοι οι Συναλλασόμενοι"
        End Select
    End Function

    Enum TypeOfReadZoom
        ReadZoom
        Kartella
        KinhseisAnaMhna
        KinhseisSum
    End Enum

    Public Sub ReadYpoloipo(Aiti As String, Optional untildt As DateTime = Nothing)
        If untildt = Nothing Then
            untildt = DateTime.Now.AddYears(100)
        End If
        With New kinfl_e()
            _fields.Ypoloipo = .ReadYpoloipo(_fields.id, Aiti, untildt)
        End With
    End Sub



    Public Function ReadZoom(T As TypeOfReadZoom, Optional K As TypeOfSynFl = TypeOfSynFl.Customers, Optional AitiKin As String = "", Optional sum As Boolean = True, Optional TopFormName As String = "") As DataTable
        On Error Resume Next
        Dim mydata As DataTable = Nothing
        Select Case T
            Case TypeOfReadZoom.ReadZoom
                With New SynFl_e
                    .Fields = _fields
                    mydata = .ReadZoom(K, TopFormName)
                End With
            Case TypeOfReadZoom.Kartella
                With New KinFl(System.Guid.NewGuid().ToString())
                    .Fields.idSyn.id = _fields.id
                    mydata = .ReadZoom(KinFl.TypeOfKin.All)
                    If mydata.Rows.Count > 0 Then _fields.Ypoloipo = mydata.Rows(mydata.Rows.Count - 1)("Ypoloipo")
                End With
            Case TypeOfReadZoom.KinhseisAnaMhna
                With New kinfl_e()
                    mydata = .ReadMonthZoom(_fields.id, AitiKin, sum)
                    If mydata.Rows.Count > 0 Then _fields.Ypoloipo = mydata.Rows(mydata.Rows.Count - 1)("Ypoloipo")
                End With
            Case TypeOfReadZoom.KinhseisSum
                With New kinfl_e()
                    mydata = .ReadSumKoKiGen
                    If mydata.Rows.Count > 0 Then _fields.Ypoloipo = mydata.Rows(mydata.Rows.Count - 1)("Ypoloipo")
                End With
        End Select



        Return mydata
    End Function

    Public Function ReadZoomKErFl(idErg As String) As DataTable
        On Error Resume Next
        With New SynFl_e
            .Fields = _fields
            Return .ReadZoomKErFl(idErg)
        End With
    End Function

End Class

Friend Class SynFl_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemSynFlModel
    End Sub


    Private _Fields As ItemSynFlModel
    Property Fields As ItemSynFlModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemSynFlModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into SynFl (id) Values ('" + _Fields.id + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_Fields.id)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update SynFl Set [Name] = '" + _Fields.Name.Replace("'", "`") +
                                        "' , Address = '" + _Fields.Address.Replace("'", "`") +
                                        "' , PhoneNo = '" + _Fields.PhoneNo.Replace("'", "`") +
                                        "' , AFM = '" + _Fields.AFM.Replace("'", "`") +
                                        "' , DOY = '" + _Fields.DOY.Replace("'", "`") +
                                        "' , Line = '" + _Fields.Line.Replace("'", "`") +
                                        "' , Status = '" + _Fields.Status.id +
                                        "' , Category = '" + _Fields.Category.id +
                                        "' , Occupation = '" + _Fields.Occupation.id +
                                        "' , PriceList = '" + _Fields.PriceList.id +
                                        "' , KindOfTax = '" + _Fields.KindOfTax.id +
                                        "' , eMail = '" + _Fields.eMail.Replace("'", "`") +
                                        "' , WebSite = '" + _Fields.WebSite.Replace("'", "`") +
                                        "' , Map = '" + _Fields.Map.Replace("'", "`") +
                                        "' , Kind = '" + _Fields.Kind.id +
                                        "' , [Memo] = '" + _Fields.Memo.Replace("'", "`") +
                                        "' Where id = '" + _Fields.id + "'"
        SQL = New accountsClassLibrary_Custom.BusinessObjects.SynFlCustom().Update(_Fields, SQL)
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete(idToDelete As String) As Boolean
        Dim SQL As String = "Delete From SynFl Where id = '" + idToDelete + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(idToFind As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select * FROM SynFl Where id = '" + idToFind + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .id = MyTable.Rows(i).Item("id")
                .Name = MyTable.Rows(i).Item("Name")
                .Address = MyTable.Rows(i).Item("Address")
                .PhoneNo = MyTable.Rows(i).Item("PhoneNo")
                .AFM = MyTable.Rows(i).Item("AFM")
                .DOY = MyTable.Rows(i).Item("DOY")
                .Line = MyTable.Rows(i).Item("Line")
                With New FilPin
                    .Read(MyTable.Rows(i).Item("Category"))
                    _Fields.Category = .Fields
                    .Read(MyTable.Rows(i).Item("Occupation"))
                    _Fields.Occupation = .Fields
                    .Read(MyTable.Rows(i).Item("PriceList"))
                    _Fields.PriceList = .Fields
                End With
                With New ParPin
                    .Read(ParPin.TypeOfPar.Status, MyTable.Rows(i).Item("Status"))
                    _Fields.Status = .Fields
                    .Read(ParPin.TypeOfPar.KindOfTax, MyTable.Rows(i).Item("KindOfTax"))
                    _Fields.KindOfTax = .Fields
                    .Read(ParPin.TypeOfPar.Kind, MyTable.Rows(i).Item("Kind"))
                    _Fields.Kind = .Fields
                    .Read(ParPin.TypeOfPar.Status, MyTable.Rows(i).Item("Status"))
                    _Fields.Status = .Fields
                End With
                .eMail = MyTable.Rows(i).Item("eMail")
                .WebSite = MyTable.Rows(i).Item("WebSite")
                .Map = MyTable.Rows(i).Item("Map")
                .Memo = MyTable.Rows(i).Item("Memo")
            End With
            Dim Custom = New accountsClassLibrary_Custom.BusinessObjects.SynFlCustom()
            Custom.Read(_Fields, MyTable.Rows(i))
        Next

        Return MyTable.Rows.Count
    End Function

    Enum TypeOfSynFl
        Customers
        Supliers
        CustomersSupliers
        All
    End Enum

    Public Function ReadZoom(K As TypeOfSynFl, FormName As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim ks As String = ""
        Select Case K
            Case TypeOfSynFl.Customers
                ks = "0"
            Case TypeOfSynFl.Supliers
                ks = "1"
            Case TypeOfSynFl.CustomersSupliers
                ks = "2"
            Case TypeOfSynFl.All
                ks = "%"
        End Select

        Dim SQL As String = "SELECT " + MyA.GetZoomTop(FormName) + " 0 as AA, SynFl.id, SynFl.[Name], SynFl.Address, SynFl.PhoneNo, SynFl.AFM, SynFl.DOY, SynFl.Line, SynFl.Status, " +
                                "SynFl.Category, SynFl.Occupation, SynFl.PriceList, SynFl.KindOfTax, SynFl.eMail, SynFl.WebSite, SynFl.Map, " +
                                "SynFl.Memo, SynFl.Kind, filpin.[Name] As CategoryDescription, filpin_1.[Name] As OccupationDescription,  " +
                                "filpin_2.[Name] AS PriceListDescription From " +
                                "((SynFl LEFT JOIN FilPin ON SynFl.Category = FilPin.ID) LEFT JOIN FilPin AS FilPin_1 ON SynFl.Occupation = FilPin_1.ID) LEFT JOIN FilPin AS FilPin_2 ON SynFl.PriceList = FilPin_2.ID " +
                                "Where ([Kind] Like '" + ks + "' or [Kind] = '2') And (" +
                                MyA.WhereFunc(Me._Fields, "SynFl") +
                                MyA.WhereFuncF("[SynFl].[Category]", _Fields.Category.id) +
                                MyA.WhereFuncF("[filpin].[name]", _Fields.Category.Name) +
                                MyA.WhereFuncF("[SynFl].[Occupation]", _Fields.Occupation.id) +
                                MyA.WhereFuncF("[filpin_1].[name]", _Fields.Occupation.Name) +
                                MyA.WhereFuncF("filpin_2.[Name]", _Fields.PriceList.Name) +
                                MyA.WhereFuncF("SynFl.PriceList", _Fields.PriceList.id) + ")"

        SQL = SQL + " Order By SynFl.Map, SynFl.Name"

        SQL = New accountsClassLibrary_Custom.BusinessObjects.SynFlCustom().ReadZoomSQL(SQL)

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        'Dim i As Integer = 0
        'For i = 1 To MyTable.Rows.Count
        '    MyTable.Rows(i - 1)("AA") = i
        'Next
        MyTable = New accountsClassLibrary_Custom.BusinessObjects.SynFlCustom().ReadZoomData(MyTable)
        Return MyTable
    End Function

    Public Function ReadZoomKErFl(idErg As String) As DataTable

        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework


        Dim SQL As String = "SELECT DISTINCT 0 AS AA, SynFl.id, SynFl.Name, SynFl.Address, SynFl.PhoneNo, SynFl.AFM, SynFl.DOY, SynFl.Line, SynFl.Status, SynFl.Category, SynFl.Occupation, SynFl.PriceList, 
                                    SynFl.KindOfTax, SynFl.eMail, SynFl.WebSite, SynFl.Map, SynFl.Kind, FilPin.Name AS CategoryDescription, FilPin_1.Name AS OccupationDescription, FilPin_2.Name AS PriceListDescription
                            FROM SynFl LEFT OUTER JOIN
                                    FilPin ON SynFl.Category = FilPin.ID LEFT OUTER JOIN
                                    FilPin AS FilPin_1 ON SynFl.Occupation = FilPin_1.ID LEFT OUTER JOIN
                                    FilPin AS FilPin_2 ON SynFl.PriceList = FilPin_2.ID RIGHT OUTER JOIN
                                    KErFl ON SynFl.id = KErFl.idSyn " +
                            "Where (KErFl.idErg = '" + idErg + "') And (" +
                                MyA.WhereFunc(Me._Fields, "SynFl") +
                                MyA.WhereFuncF("[SynFl].[Category]", _Fields.Category.id) +
                                MyA.WhereFuncF("[filpin].[name]", _Fields.Category.Name) +
                                MyA.WhereFuncF("[SynFl].[Occupation]", _Fields.Occupation.id) +
                                MyA.WhereFuncF("[filpin_1].[name]", _Fields.Occupation.Name) +
                                MyA.WhereFuncF("filpin_2.[Name]", _Fields.PriceList.Name) +
                                MyA.WhereFuncF("SynFl.PriceList", _Fields.PriceList.id) + ")"

        SQL = SQL + " Order By SynFl.Map, SynFl.Name"
        SQL = New accountsClassLibrary_Custom.BusinessObjects.SynFlCustom().ReadZoomSQL(SQL)
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        'Dim i As Integer = 0
        'For i = 1 To MyTable.Rows.Count
        '    MyTable.Rows(i - 1)("AA") = i
        'Next
        MyTable = New accountsClassLibrary_Custom.BusinessObjects.SynFlCustom().ReadZoomData(MyTable)
        Return MyTable
    End Function

    Public Function newId() As String
        Dim sql As String = "SELECT MAX(LEN(id)) FROM SynFl"
        Dim MaxLen As Integer = 0
        Dim Id As String = ""
        Try
            MaxLen = CInt(_DataLayer.ReadDataTable(sql).Rows(0)(0))
            sql = "SELECT MAX(id) FROM SynFl Where Len(id) = " + CStr(MaxLen)
            Id = CStr(CInt(_DataLayer.ReadDataTable(sql).Rows(0)(0)) + 1)
            For i As Integer = 1 To MaxLen - Len(Id)
                Id = "0" + Id
            Next
            Return Id
        Catch ex As Exception
            Id = ""
            For i As Integer = 1 To MaxLen - Len(Id)
                Id = "0" + Id
            Next
            Id += "1"
            Return Id
        End Try
    End Function

End Class
