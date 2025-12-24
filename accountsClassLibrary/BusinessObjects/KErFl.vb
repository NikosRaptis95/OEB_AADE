Imports accountsClassLibrary
Public Class ItemKErFlModel
    Public Sub New()
        _id = ""
        _AitiKEr = ""
        _KoKiKEr = New ItemFilPinModel
        _Memo = ""
        _RegistryDate = Now
        _Summary = 0
        _Status = New ItemParPinModel
        _idSyn = New ItemSynFlModel
        _idErg = New ItemErgFlModel
        _SalesPerson = ""
    End Sub

    Public Sub New(StringToFind As String)
        _id = StringToFind
        _AitiKEr = StringToFind
        _KoKiKEr = New ItemFilPinModel(StringToFind)
        _Memo = StringToFind
        Dim c As New alphaFrameWork.AlphaFramework
        _RegistryDate = c.MakeDate(StringToFind)
        _Summary = c.MakeNo(StringToFind, 6)
        _Status = New ItemParPinModel(StringToFind)
        _idSyn = New ItemSynFlModel(StringToFind)
        _idErg = New ItemErgFlModel(StringToFind)
        _SalesPerson = ""
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

    Private _AitiKEr As String
    Property AitiKEr As String
        Get
            Return _AitiKEr
        End Get
        Set(ByVal value As String)
            _AitiKEr = value
        End Set
    End Property

    Private _KoKiKEr As ItemFilPinModel
    Property KoKiKEr As ItemFilPinModel
        Get
            Return _KoKiKEr
        End Get
        Set(ByVal value As ItemFilPinModel)
            _KoKiKEr = value
        End Set
    End Property

    Private _idErg As ItemErgFlModel
    Property idErg As ItemErgFlModel
        Get
            Return _idErg
        End Get
        Set(ByVal value As ItemErgFlModel)
            _idErg = value
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

    Private _RegistryDate As DateTime
    Property RegistryDate As DateTime
        Get
            Return _RegistryDate
        End Get
        Set(ByVal value As DateTime)
            _RegistryDate = value
        End Set
    End Property

    Private _Summary As Double
    Property Summary As Double
        Get
            Return _Summary
        End Get
        Set(ByVal value As Double)
            _Summary = value
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

    Private _idSyn As ItemSynFlModel
    Property idSyn As ItemSynFlModel
        Get
            Return _idSyn
        End Get
        Set(ByVal value As ItemSynFlModel)
            _idSyn = value
        End Set
    End Property

    Private _SalesPerson As String
    Property SalesPerson As String
        Get
            Return _SalesPerson
        End Get
        Set(ByVal value As String)
            _SalesPerson = value
        End Set
    End Property

End Class
Public Class KErFl


    Public Sub New()
        Me._fields = New ItemKErFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemKErFlModel(StringToFind)
    End Sub

    Private _fields As ItemKErFlModel
    Public Property Fields() As ItemKErFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKErFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "KErFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .id.Trim.Length < 1 Then .id = System.Guid.NewGuid.ToString()


            Dim res As String = New FilPin().Read(_fields.KoKiKEr.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στον κωδικό κίνησης !"

            res = New SynFl().Read(_fields.idSyn.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στον πελάτη !"

            res = New ErgFl().Read(_fields.idErg.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στην υπηρεσία !"

            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With

        With New KErFl_e
            .Fields = _fields
            If .Insert() = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !"
            End If
        End With

    End Function

    Public Function Update() As String

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "KErFl_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .id.Trim.Length < 1 Then .id = System.Guid.NewGuid.ToString()


            Dim res As String = New FilPin().Read(_fields.KoKiKEr.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στον κωδικό κίνησης !"

            res = New SynFl().Read(_fields.idSyn.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στον πελάτη !"

            res = New ErgFl().Read(_fields.idErg.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στην υπηρεσία !"

            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With


        With New KErFl_e
            .Fields = _fields
            If .Update = True Then
                Return ""
            Else
                Return "Αδύνατη η ενημέρωση της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function Delete(id As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "KErfl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New KErFl_e
            .Fields = _fields
            If .Delete(id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function Read(id As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "KErfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New KErFl_e
            .Fields = _fields
            If .Read(id) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ReadZoom(Optional FormName As String = "") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New KErFl_e
            .Fields = _fields
            MData = .ReadZoom(FormName)
        End With

        Return MData
    End Function

    Public Function ReadKiniseisAnaErgoAnaPelath(idSyn As String, idErg As String) As DataTable
        Return New KErFl_e().ReadKiniseisAnaErgoAnaPelath(idSyn, idErg)
    End Function

    Public Function ReadErgaPelath(id As String) As List(Of ItemErgFlModel)
        Return New KErFl_e().ReadErgaPelath(id)
    End Function

End Class

Friend Class KErFl_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemKErFlModel
    End Sub

    Private _Fields As ItemKErFlModel
    Property Fields As ItemKErFlModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemKErFlModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into KErFl (id) Values ('" + _Fields.id + "')"
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
        Dim SQL As String = "Update KErFl Set AitiKEr = '" + _Fields.AitiKEr.Replace(",", ".") +
                                        "' , KoKiKEr = '" + _Fields.KoKiKEr.id.Replace(",", ".") +
                                        "' , SalesPerson = '" + _Fields.SalesPerson.Replace(",", ".") +
                                        "' , idSyn = '" + _Fields.idSyn.id.Replace(",", ".") +
                                        "' , idErg = '" + _Fields.idErg.id.Replace(",", ".") +
                                        "' , [Memo] = '" + _Fields.Memo.Replace(",", ".") +
                                        "' , Status = '" + _Fields.Status.id +
                                        "' , RegistryDate = " + _DataLayer.dateMark + _Fields.RegistryDate.ToString("yyyy-MM-dd") + _DataLayer.dateMark +
                                        ", Summary = " + _Fields.Summary.ToString() +
                                        " Where Id = '" + _Fields.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete(id As String) As Boolean
        Dim SQL As String = "Delete From KErFl Where Id = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, AitiKEr, KoKiKEr, [Memo], RegistryDate, Summary, Status, idSyn, SalesPerson, idErg FROM KErFl " +
                            "Where id = '" + id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .id = MyTable.Rows(i).Item("id")
                .AitiKEr = MyTable.Rows(i).Item("AitiKEr")
                With New FilPin
                    If .Read(MyTable.Rows(i).Item("KoKiKEr")).Trim.Length = 0 Then
                        _Fields.KoKiKEr = .Fields
                    Else
                        _Fields.KoKiKEr.id = MyTable.Rows(i).Item("KoKiKer")
                    End If
                End With
                .Memo = MyTable.Rows(i).Item("[Memo]")
                With New ParPin
                    .Read(ParPin.TypeOfPar.Status, MyTable.Rows(0).Item("Status"))
                    _Fields.Status = .Fields
                End With
                .RegistryDate = MyTable.Rows(0).Item("RegistryDate")
                .Summary = MyTable.Rows(0).Item("Summary")
                With New SynFl
                    If .Read(MyTable.Rows(i).Item("IdSyn")).Trim.Length = 0 Then
                        _Fields.idSyn = .Fields
                    Else
                        _Fields.idSyn.id = MyTable.Rows(i).Item("idSyn")
                    End If
                End With
                .SalesPerson = MyTable.Rows(0).Item("SalesPerson")
                With New ErgFl
                    If .Read(MyTable.Rows(i).Item("IdErg")).Trim.Length = 0 Then
                        _Fields.idErg = .Fields
                    Else
                        _Fields.idErg.id = MyTable.Rows(i).Item("idErg")
                    End If
                End With
            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom(FormName As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim SQL As String = "SELECT " + MyA.GetZoomTop(FormName) + " 0 as AA, KErFl.id, KErFl.AitiKEr, KErFl.RegistryDate, KErFl.Summary, FilPin.[Name] As KoKiKErAitiKEr, KErFl.[Memo], KErFl.Status, idSyn, SynFl.[Name] As idSynName, SalesPerson, ErgFl.Description As Ergo" +
                            " FROM  ((KErFl LEFT JOIN SynFl ON KErFl.idSyn = SynFl.id) LEFT JOIN ErgFl ON KErFl.idErg = ErgFl.id) LEFT JOIN FilPin ON KErFl.KoKiKEr = FilPin.ID " +
                            "Where (" + MyA.WhereFunc(Me._Fields, "KErFl") +
                                MyA.WhereFuncF("[filpin].[name]", _Fields.KoKiKEr.Name) +
                                MyA.WhereFuncF("FilPin.id", _Fields.KoKiKEr.id) +
                                MyA.WhereFuncF("SynFl.[Name]", _Fields.idSyn.Name) +
                                MyA.WhereFuncF("SynFl.id", _Fields.idSyn.id) +
                                MyA.WhereFuncF("ErgFl.id", _Fields.idErg.id) +
                                MyA.WhereFuncF("ErgFl.Description", _Fields.idErg.Description) +
                                ")"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL + " Order By RegistryDate Desc")
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next
        Return MyTable
    End Function

    Public Function ReadKiniseisAnaErgoAnaPelath(idSyn As String, idErg As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim SQL As String = "SELECT KErFl.id, KErFl.AitiKEr, KErFl.RegistryDate, KErFl.Summary, FilPin.[Name] As KoKiKErAitiKEr, KErFl.[Memo], SalesPerson " +
                            " FROM  KErFl LEFT JOIN FilPin ON KErFl.KoKiKEr = FilPin.ID " +
                            "Where idSyn = '" + idSyn + "' And idErg = '" + idErg + "'"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL + " Order By RegistryDate Desc")
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next
        Return MyTable
    End Function



    Public Function ReadErgaPelath(id As String) As List(Of ItemErgFlModel)
        Dim ErgaBO As New accountsClassLibrary.ErgFl()
        Dim ErgaResult As New List(Of ItemErgFlModel)
        Dim Sql As String = "Select distinct KErFl.IdErg, ErgFl.EndDate, ErgFl.Description From KerFl LEFT JOIN ErgFl ON KErFl.idErg = ErgFl.id Where KerFl.idSyn = '" + id + "' Order By ErgFl.EndDate, ErgFl.Description"
        Dim ErgaFromKerFl As DataTable = _DataLayer.ReadDataTable(Sql)
        For i As Integer = 0 To ErgaFromKerFl.Rows.Count - 1
            ErgaBO = New accountsClassLibrary.ErgFl()
            ErgaBO.Read(ErgaFromKerFl.Rows(i)(0))
            ErgaResult.Add(ErgaBO.Fields)
        Next
        Return ErgaResult
    End Function





End Class

