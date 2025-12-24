Imports System.ComponentModel

Public Class ItemTimFlModel

    Public Sub New()

        _CarNo = ""
        _Cash = 0
        _Delivery = ""
        _eMail = ""
        _id = ""
        _Status = New ItemParPinModel
        _KoKiTim = New ItemKoKiTimModel
        _Memo = ""
        _Payment = ""
        _Perpose = ""
        _RegistryDate = Now
        _Seira = ""
        _Summary = 0
        _SynId = New ItemSynFlModel
        _Vat = 0
        _SalesPerson = ""
        _Metaforika = 0
        _Antikataboli = 0

        _Line = New List(Of ItemTi1FlModel)

    End Sub

    Public Sub New(StringToFind As String)

        _CarNo = StringToFind
        _Delivery = StringToFind
        _eMail = StringToFind
        _id = StringToFind
        _Status = New ItemParPinModel(StringToFind)
        _KoKiTim = New ItemKoKiTimModel(StringToFind)
        _Memo = StringToFind
        _Payment = StringToFind
        _Perpose = StringToFind
        _Seira = StringToFind
        _SynId = New ItemSynFlModel(StringToFind)
        _SalesPerson = StringToFind
        Dim c As New alphaFrameWork.AlphaFramework
        StringToFind = c.clearStringFromZ(StringToFind)
        _RegistryDate = c.MakeDate(StringToFind)
        _Cash = c.MakeNo(StringToFind, 6)
        _Summary = c.MakeNo(StringToFind, 6)
        _Vat = c.MakeNo(StringToFind, 6)

        _Metaforika = c.MakeNo(StringToFind, 6)
        _Antikataboli = c.MakeNo(StringToFind, 6)

        _Line = New List(Of ItemTi1FlModel)

    End Sub

    Private _Metaforika As Double
    Property Metaforika As Double
        Get
            Return _Metaforika
        End Get
        Set(ByVal value As Double)
            _Metaforika = value
        End Set
    End Property

    Private _Antikataboli As Double
    Property Antikataboli As Double
        Get
            Return _Antikataboli
        End Get
        Set(ByVal value As Double)
            _Antikataboli = value
        End Set
    End Property


    Private _CarNo As String
    Property CarNo As String
        Get
            Return _CarNo
        End Get
        Set(ByVal value As String)
            _CarNo = value
        End Set
    End Property

    Private _Cash As Double
    Property Cash As Double
        Get
            Return _Cash
        End Get
        Set(ByVal value As Double)
            _Cash = value
        End Set
    End Property

    Private _Delivery As String
    Property Delivery As String
        Get
            Return _Delivery
        End Get
        Set(ByVal value As String)
            _Delivery = value
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

    Private _id As String
    Property id As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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

    Private _KoKiTim As ItemKoKiTimModel
    Property KoKiTim As ItemKoKiTimModel
        Get
            Return _KoKiTim
        End Get
        Set(ByVal value As ItemKoKiTimModel)
            _KoKiTim = value
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

    Private _Payment As String
    Property Payment As String
        Get
            Return _Payment
        End Get
        Set(ByVal value As String)
            _Payment = value
        End Set
    End Property

    Private _Perpose As String
    Property Perpose As String
        Get
            Return _Perpose
        End Get
        Set(ByVal value As String)
            _Perpose = value
        End Set
    End Property

    Private _Seira As String
    Property Seira As String
        Get
            Return _Seira
        End Get
        Set(ByVal value As String)
            _Seira = value
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

    Private _SynId As ItemSynFlModel
    Property SynId As ItemSynFlModel
        Get
            Return _SynId
        End Get
        Set(ByVal value As ItemSynFlModel)
            _SynId = value
        End Set
    End Property

    Private _Vat As Double
    Property Vat As Double
        Get
            Return _Vat
        End Get
        Set(ByVal value As Double)
            _Vat = value
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

    Private _SalesPerson As String
    Property SalesPerson As String
        Get
            Return _SalesPerson
        End Get
        Set(ByVal value As String)
            _SalesPerson = value
        End Set
    End Property

    Private _Line As List(Of ItemTi1FlModel)
    Property Line As List(Of ItemTi1FlModel)
        Get
            Return _Line
        End Get
        Set(ByVal value As List(Of ItemTi1FlModel))
            _Line = value
        End Set
    End Property

End Class

Public Class ItemTi1FlModel

    Public Sub New()

        _RegDateTime = Now
        _id = ""
        _id1 = ""
        _id2 = ""
        _id3 = ""
        _Status = New ItemParPinModel
        _KoKiTim = New ItemKoKiTimModel
        _Memo = ""
        _MtlId = New ItemMtlFlModel
        _PosVat = 0
        _Price = 0
        _Quantity = 0
        _Gross = 0
        _Seira = ""
        _PEkpt = 0
        _Vat = 0
        _Summary = 0
        _dxm = New ItemYpoloipaModel

    End Sub

    Public Sub New(StringToFind As String)

        _id = StringToFind
        _id1 = StringToFind
        _id2 = StringToFind
        _id3 = StringToFind
        _Seira = StringToFind
        _Memo = StringToFind
        _Status = New ItemParPinModel(StringToFind)
        _KoKiTim = New ItemKoKiTimModel(StringToFind)
        _MtlId = New ItemMtlFlModel(StringToFind)

        Dim c As New alphaFrameWork.AlphaFramework
        StringToFind = c.clearStringFromZ(StringToFind)
        _RegDateTime = c.MakeDate(StringToFind)
        _PosVat = c.MakeNo(StringToFind, 6)
        _Price = c.MakeNo(StringToFind, 6)
        _Quantity = c.MakeNo(StringToFind, 6)
        _Gross = c.MakeNo(StringToFind, 6)
        _PEkpt = c.MakeNo(StringToFind, 6)
        _Vat = c.MakeNo(StringToFind, 6)
        _Summary = c.MakeNo(StringToFind, 6)
        _dxm = New ItemYpoloipaModel

    End Sub

    Private _RegDateTime As DateTime
    Property RegDateTime As DateTime
        Get
            Return _RegDateTime
        End Get
        Set(ByVal value As DateTime)
            _RegDateTime = value
        End Set
    End Property

    Private _id As String
    Property id As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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

    Private _KoKiTim As ItemKoKiTimModel
    Property KoKiTim As ItemKoKiTimModel
        Get
            Return _KoKiTim
        End Get
        Set(ByVal value As ItemKoKiTimModel)
            _KoKiTim = value
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

    Private _MtlId As ItemMtlFlModel
    Property MtlId As ItemMtlFlModel
        Get
            Return _MtlId
        End Get
        Set(ByVal value As ItemMtlFlModel)
            _MtlId = value
        End Set
    End Property

    Private _PosVat As Double
    Property PosVat As Double
        Get
            Return _PosVat
        End Get
        Set(ByVal value As Double)
            _PosVat = value
        End Set
    End Property

    Private _Price As Double
    Property Price As Double
        Get
            Return _Price
        End Get
        Set(ByVal value As Double)
            _Price = value
        End Set
    End Property

    Private _Quantity As Double
    Property Quantity As Double
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Double)
            _Quantity = value
        End Set
    End Property

    Private _Gross As Double
    Property Gross As Double
        Get
            Return _Gross
        End Get
        Set(ByVal value As Double)
            _Gross = value
        End Set
    End Property

    Private _Seira As String
    Property Seira As String
        Get
            Return _Seira
        End Get
        Set(ByVal value As String)
            _Seira = value
        End Set
    End Property

    Private _PEkpt As Double
    Property PEkpt As Double
        Get
            Return _PEkpt
        End Get
        Set(ByVal value As Double)
            _PEkpt = value
        End Set
    End Property

    Private _Vat As Double
    Property Vat As Double
        Get
            Return _Vat
        End Get
        Set(ByVal value As Double)
            _Vat = value
        End Set
    End Property
    Private _id1 As String
    Property id1 As String
        Get
            Return _id1
        End Get
        Set(ByVal value As String)
            _id1 = value
        End Set
    End Property

    Private _id2 As String
    Property id2 As String
        Get
            Return _id2
        End Get
        Set(ByVal value As String)
            _id2 = value
        End Set
    End Property

    Private _id3 As String
    Property id3 As String
        Get
            Return _id3
        End Get
        Set(ByVal value As String)
            _id3 = value
        End Set
    End Property

    Private _Summary As Double
    Property Summary As Double
        Get
            Return _Summary
        End Get
        Set(value As Double)
            _Summary = value
        End Set
    End Property

    Private _dxm As ItemYpoloipaModel
    Property dxm As ItemYpoloipaModel
        Get
            Return _dxm
        End Get
        Set(ByVal value As ItemYpoloipaModel)
            _dxm = value
        End Set
    End Property

End Class

Public Class TimFl

    Public Sub New()
        Me._fields = New ItemTimFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemTimFlModel(StringToFind)
    End Sub

    Private _fields As ItemTimFlModel
    Public Property Fields() As ItemTimFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemTimFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "TimFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If (.Cash < "0" Or .Cash > "1") Then Return "Η τιμή μετρητά δεν είναι σωστή !"
            If .id.Trim.Length < 1 Then Return "Δεν υπάρχει αριθμός παραστατικού !"
            Dim csyn As New SynFl
            Dim res As String = csyn.Read(_fields.SynId.id)
            If res.Length > 0 Then Return "Δεν υπάρχει συναλλασόμενος  !"
            If .SynId.id.Trim.Length < 1 Then Return "Δεν υπάρχει συναλλασόμενος  !"
            If .KoKiTim.id.Trim.Length < 1 Then Return "Δεν υπάρχει τύπος κίνησης κίνησης  !"
            If .KoKiTim.id.Substring(0, 1) = "0" And csyn.Fields.Kind.id = "1" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .KoKiTim.id.Substring(0, 1) = "1" And csyn.Fields.Kind.id = "0" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
            .Memo = .Memo.Replace(",", " ")
        End With

        With New timfl_e
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
        Dim MyMethod As String = "KinFl_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If (.Cash < "0" Or .Cash > "1") Then Return "Η τιμή μετρητά δεν είναι σωστή !"
            If .id.Trim.Length < 1 Then Return "Δεν υπάρχει αριθμό παραστατικού !"
            Dim csyn As New SynFl
            Dim res As String = csyn.Read(_fields.SynId.id)
            If res.Length > 0 Then Return "Δεν υπάρχει συναλλασόμενος  !"
            If .SynId.id.Trim.Length < 1 Then Return "Δεν υπάρχει συναλλασόμενος  !"
            If .KoKiTim.id.Trim.Length < 1 Then Return "Δεν υπάρχει τύπος κίνησης κίνησης  !"
            If .KoKiTim.id.Substring(0, 1) = "0" And csyn.Fields.Kind.id = "1" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .KoKiTim.id.Substring(0, 1) = "1" And csyn.Fields.Kind.id = "0" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With


        With New timfl_e
            .Fields = _fields
            If .Update = True Then
                Return ""
            Else
                Return "Αδύνατη η ενημέρωση της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function Delete() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "kinfl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New Timfl_e
            .Fields = _fields
            If .Delete() = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function Read(koki As String, seira As String, arpa As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "kinfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New timfl_e
            .Fields = _fields
            If .Read(koki, seira, arpa) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Enum TypeOfTim
        Paraggelia
        All
    End Enum

    Public Function ReadZoom(K As String, s As String) As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New timfl_e
            .Fields = _fields
            MData = .ReadZoom(K, s)
        End With

        Return MData
    End Function

    Public Function ReadZoomRegistryDate(K As String) As DataTable
        On Error Resume Next
        With New timfl_e
            Return .ReadZoomRegistryDate(K)
        End With
    End Function

    Public Function ReadZoomSalesPerson() As DataTable
        On Error Resume Next
        With New timfl_e
            Return .ReadZoomSalesPerson()
        End With
    End Function

    Public Function ReadZoomSeira(K As String) As DataTable
        On Error Resume Next
        With New timfl_e
            Return .ReadZoomSeira(K)
        End With
    End Function

    Public Function FindLastPlus(Optional KoKiTim As String = "100000", Optional Seira As String = "") As String
        With New timfl_e
            Return .FindLastPlus(KoKiTim, Seira)
        End With
    End Function

    Public Function ReadPosothtaPolhseis(MtlId As String) As Double
        Return New timfl_e().ReadPosothtaPolhseis(MtlId)
    End Function
End Class

Friend Class timfl_e
    Dim _DataLayer As New alphaFrameWork.datalayer

    Public Sub New()
        Me.Fields = New ItemTimFlModel
    End Sub

    Private _fields As ItemTimFlModel
    Public Property Fields() As ItemTimFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemTimFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into TimFl (id,Seira, KokiTim) Values ('" + _fields.id + "' , '" + _fields.Seira + "','" + _fields.KoKiTim.id + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                InsertLines()
                Return True
            Else
                Delete()
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub InsertLines()
        Dim i As Integer
        For i = 0 To _fields.Line.Count - 1
            Dim SQL As String = "Insert Into Ti1Fl (id, Seira, KokiTim, RegDateTime, MtlId) Values ('" + _fields.Line(i).id + "' , '" + _fields.Line(i).Seira + "','" + _fields.Line(i).KoKiTim.id + "', " +
                                                                                                         _DataLayer.dateMark + _fields.Line(i).RegDateTime.ToString("yyyy-MM-dd hh:mm:ss.fff") + _DataLayer.dateMark + ", '" +
                                                                                                         _fields.Line(i).MtlId.id.ToString.Replace("'", "`") + "')"

            If _DataLayer.ExecuteNonQuery(SQL) = True Then
                UpdateLine(_fields.Line(i))
            End If
        Next
    End Sub

    Private Function UpdateLine(t1 As accountsClassLibrary.ItemTi1FlModel) As Boolean

        Dim SQL As String = "Update Ti1Fl Set Description = '" + t1.MtlId.Description.ToString.Replace("'", "`")

        SQL += "' , id = '" + t1.id.ToString.Replace("'", "`") +
               "' , id1 = '" + t1.id1.ToString.Replace("'", "`") +
               "' , id2 = '" + t1.id2.ToString.Replace("'", "`") +
               "' , id3 = '" + t1.id3.ToString.Replace("'", "`") +
               "' , Status = '" + t1.Status.id.ToString.Replace("'", "`") +
               "' , KindOfTax = '" + t1.MtlId.KindOfTax.id.ToString.Replace("'", "`") +
               "' , Memo = '" + t1.Memo.ToString.Replace("'", "`") +
               "' , MoMe = '" + t1.MtlId.MoMe.id.ToString.Replace("'", "`") + "'"

        SQL += ", PosVat = " + t1.PosVat.ToString.Replace(",", ".") +
               ", Price = " + t1.Price.ToString.Replace(",", ".") +
               ", Quantity = " + t1.Quantity.ToString.Replace(",", ".") +
               ", Gross = " + t1.Gross.ToString.Replace(",", ".") +
               ", PEkpt = " + t1.PEkpt.ToString.Replace(",", ".") +
               ", Vat = " + t1.Vat.ToString.Replace(",", ".")

        SQL += " Where id = '" + t1.id.ToString + "' And Seira = '" + t1.Seira.ToString.Replace("'", "`") + "' And KoKiTim = '" + t1.KoKiTim.id.ToString +
                                                  "' And RegDateTime = " + _DataLayer.dateMark + t1.RegDateTime.ToString("yyyy-MM-dd hh:mm:ss.fff") + _DataLayer.dateMark +
                                                  " And MtlId = '" + t1.MtlId.id.ToString.Replace("'", "`") + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = ""
        If _fields.SynId.Address.Length > 99 Then
            _fields.SynId.Address = _fields.SynId.Address.Substring(0, 99)
        End If
        SQL = "Update TimFl Set Address = '" + _fields.SynId.Address.ToString.Replace("'", "`")

        If _fields.CarNo.Length > 20 Then
            _fields.CarNo = _fields.CarNo.Substring(0, 20)
        End If
        If _fields.SynId.Name.Length > 99 Then
            _fields.SynId.Name = _fields.SynId.Name.Substring(0, 99)
        End If
        If _fields.SynId.PhoneNo.Length > 49 Then
            _fields.SynId.PhoneNo = _fields.SynId.PhoneNo.Substring(0, 49)
        End If
        If _fields.SynId.AFM.Length > 19 Then
            _fields.SynId.AFM = _fields.SynId.AFM.Substring(0, 19)
        End If
        If _fields.SynId.DOY.Length > 49 Then
            _fields.SynId.DOY = _fields.SynId.DOY.Substring(0, 49)
        End If
        If _fields.SynId.Occupation.Name.Length > 59 Then
            _fields.SynId.Occupation.Name = _fields.SynId.Occupation.Name.Substring(0, 59)
        End If
        If _fields.Delivery.Length > 60 Then
            _fields.Delivery = _fields.Delivery.Substring(0, 60)
        End If
        If _fields.Memo.Length > 499 Then
            _fields.Memo = _fields.Memo.Substring(0, 499)
        End If

        SQL += "' , AFM = '" + _fields.SynId.AFM.Replace("'", "`") +
               "' , CarNo = '" + _fields.CarNo.Replace("'", "`") +
               "' , eMail = '" + _fields.eMail.Replace("'", "`") +
               "' , Delivery = '" + _fields.Delivery.Replace("'", "`") +
               "' , DOY = '" + _fields.SynId.DOY.Replace("'", "`") +
               "' , Status = '" + _fields.Status.id +
               "' , KindOfTax = '" + _fields.SynId.KindOfTax.id +
               "' , Memo = '" + _fields.Memo.Replace("'", "`") +
               "' , Name = '" + _fields.SynId.Name.Replace("'", "`") +
               "' , Occupation = '" + _fields.SynId.Occupation.Name.Replace("'", "`") +
               "' , Payment = '" + _fields.Payment.Replace("'", "`") +
               "' , Perpose = '" + _fields.Perpose.Replace("'", "`") +
               "' , PhoneNo = '" + _fields.SynId.PhoneNo.Replace("'", "`") +
               "' , PriceList = '" + _fields.SynId.PriceList.id +
               "' , SynId = '" + _fields.SynId.id +
               "' , SalesPerson = '" + _fields.SalesPerson.Replace("'", "`") + "'" +
               ", Cash = " + _fields.Cash.ToString.Replace(",", ".") +
               ", Summary = " + _fields.Summary.ToString.Replace(",", ".") +
               ", Metaforika = " + _fields.Metaforika.ToString.Replace(",", ".") +
               ", Antikataboli = " + _fields.Antikataboli.ToString.Replace(",", ".") +
               ", Vat = " + _fields.Vat.ToString.Replace(",", ".")

        SQL += ", RegistryDate = " + _DataLayer.dateMark + _fields.RegistryDate.ToString("yyyy-MM-dd hh:mm:ss.fff") + _DataLayer.dateMark

        SQL += " Where id = '" + _fields.id.ToString + "' And Seira = '" + _fields.Seira.ToString.Replace("'", "`") + "' And KoKiTim = '" + _fields.KoKiTim.id.ToString + "'"
        Return _DataLayer.ExecuteNonQuery(Sql)
    End Function

    Public Function Delete() As Boolean
        Dim SQL As String = "Delete From TimFl Where id = '" + _fields.id + "' And Seira = '" + _fields.Seira.Replace("'", "`") + "' And KoKiTim = '" + _fields.KoKiTim.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(koki As String, seira As String, arpa As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select Address , AFM , CarNo , Cash , Delivery , DOY , id , Status , KindOfTax , KoKiTim , Memo, Name, Occupation, Payment, Perpose, PhoneNo, PriceList, RegistryDate, Seira, Summary, SynId, Vat, SalesPerson, Metaforika, Antikataboli, eMail From TimFl Where id = '" + arpa.Replace("'", "`") + "' And Seira = '" + seira.Replace("'", "`") + "' And KoKiTim = '" + koki.Replace("'", "`") + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1

            ' read synfl
            Dim s As New SynFl
            s.Read(MyTable.Rows(i).Item("SynId"))
            s.ReadYpoloipo("")

            With _fields
                .SynId = s.Fields
                .SynId.Address = MyTable.Rows(i).Item("Address")
                .SynId.AFM = MyTable.Rows(i).Item("AFM")
                .CarNo = MyTable.Rows(i).Item("CarNo")
                .Delivery = MyTable.Rows(i).Item("Delivery")
                .SynId.DOY = MyTable.Rows(i).Item("DOY")
                .id = MyTable.Rows(i).Item("id")
                .Memo = MyTable.Rows(0).Item("Memo")
                .SynId.Name = MyTable.Rows(0).Item("Name")
                .Payment = MyTable.Rows(0).Item("Payment")
                .Perpose = MyTable.Rows(0).Item("Perpose")
                .SynId.PhoneNo = MyTable.Rows(0).Item("PhoneNo")
                .RegistryDate = MyTable.Rows(0).Item("RegistryDate")
                .Seira = MyTable.Rows(0).Item("Seira")
                .Summary = MyTable.Rows(0).Item("Summary")
                .Vat = MyTable.Rows(0).Item("Vat")
                .SalesPerson = MyTable.Rows(0).Item("SalesPerson")
                .eMail = MyTable.Rows(0).Item("eMail")
                .Metaforika = MyTable.Rows(0).Item("Metaforika")
                .Antikataboli = MyTable.Rows(0).Item("Antikataboli")
            End With
            With New ParPin
                .Read(ParPin.TypeOfPar.Status, MyTable.Rows(i).Item("Status"))
                _fields.Status = .Fields
                .Read(ParPin.TypeOfPar.KindOfTax, MyTable.Rows(i).Item("KindOfTax"))
                _fields.SynId.KindOfTax = .Fields
            End With
            With New KoKiTim
                .Read(MyTable.Rows(0).Item("KoKiTim"))
                _fields.KoKiTim = .Fields
                _fields.KoKiTim.id = MyTable.Rows(0).Item("KoKiTim")
            End With
            With New FilPin
                If .Read(MyTable.Rows(0).Item("Occupation")).Trim = 0 Then
                    _fields.SynId.Occupation = .Fields
                Else
                    _fields.SynId.Occupation.Name = MyTable.Rows(0).Item("Occupation")
                End If
                .Read(MyTable.Rows(0).Item("PriceList"))
                _fields.SynId.PriceList = .Fields
            End With

            SQL = "SELECT  Description, RegDateTime, Status, KindOfTax, Memo, MoMe, MtlId, PosVat, Price, Quantity, Gross, PEkpt, Vat, id1, id2, id3 From Ti1Fl Where KoKiTim = '" + koki + "' And Seira = '" + seira + "' And id = '" + arpa + "'"
            Dim Detail As New DataTable
            Detail = _DataLayer.ReadDataTable(SQL)

            For x As Integer = 0 To Detail.Rows.Count - 1
                Dim line As New ItemTi1FlModel
                With line
                    .Gross = Detail(x)("Gross")
                    .id = arpa
                    .id1 = Detail(x)("id1")
                    .id2 = Detail(x)("id2")
                    .id3 = Detail(x)("id3")
                    With New KoKiTim
                        .Read(koki)
                        line.KoKiTim = .Fields
                    End With
                    .Memo = Detail(x)("Memo")
                    Dim mtlid = New accountsClassLibrary.MtlFl
                    mtlid.Read(Detail(x)("MtlId"))
                    .MtlId = mtlid.Fields
                    .PEkpt = Detail(x)("PEkpt")
                    .PosVat = Detail(x)("PosVat")
                    .Price = Detail(x)("Price")
                    .Quantity = Detail(x)("Quantity")
                    .RegDateTime = Detail(x)("RegDateTime")
                    .Seira = seira
                    .Status = Detail(x)("Status")
                    .Vat = Detail(x)("Vat")
                    .Summary = .Quantity * (.Price - (.Price * .PEkpt / 100))
                    Dim ypo = New accountsClassLibrary.Ypoloipa
                    ypo.Read(.MtlId.id, .id1, .id2, .id3)
                    .dxm = ypo.Fields
                End With
                _fields.Line.Add(line)
            Next

        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ReadPosothtaPolhseis(MtlId As String) As Double
        Dim sql As String = "Select ISNULL(SUM(Quantity), 0) As SUMQuantity FROM Ti1Fl WHERE (KoKiTim = '100000') AND (MtlId = '" + MtlId + "')"
        Return _DataLayer.ReadDataTable(sql).Rows(0)(0)
    End Function

    Public Function ReadZoom(K As String, s As String) As DataTable
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select Address, 
                                    AFM, 
                                    CarNo,  
                                    Cash, 
                                    Delivery, 
                                    DOY, 
                                    id, 
                                    Status, 
                                    KindOfTax, 
                                    KoKiTim, 
                                    Memo, 
                                    Name, 
                                    Occupation, 
                                    Payment, 
                                    Perpose, 
                                    PhoneNo, 
                                    PriceList, 
                                    RegistryDate, 
                                    Seira, 
                                    Summary, 
                                    SynId, 
                                    Vat, 
                                    SalesPerson, 
                                    eMail, 
                                    Metaforika, 
                                    Antikataboli,
                                    Summary + Metaforika + Antikataboli As GSum,
                                    '' As products
                            From TimFl Where KoKiTim = '" + K + "' order by " + s

        Dim MData As DataTable = _DataLayer.ReadDataTable(SQL)

        For i As Integer = 0 To MData.Rows.Count - 1
            SQL = "SELECT  Description, Quantity From Ti1Fl Where KoKiTim = '" + MData.Rows(i)("KoKiTim") + "' And Seira = '" + MData.Rows(i)("Seira") + "' And id = '" + MData.Rows(i)("id") + "'"
            Dim Detail As New DataTable
            Detail = _DataLayer.ReadDataTable(SQL)
            For x As Integer = 0 To Detail.Rows.Count - 1
                Dim tmp As Double = Detail.Rows(x)("Quantity")

                MData.Rows(i)("products") += Detail.Rows(x)("Description") + "(" + tmp.ToString("# ###.##") + ") <br>"
            Next
        Next
        Return MData
    End Function

    Private Function ReadCash(id As String)
        Select Case id
            Case "+"
                Return "1"
            Case "%+"
                Return "%1"
            Case "+%"
                Return "1%"
            Case "%+%"
                Return "%1%"
        End Select
        Return id
    End Function

    Public Function ReadZoomSalesPerson() As DataTable
        On Error Resume Next
        Dim SQL As String = "SELECT DISTINCT SalesPerson From TimFl "
        Return _DataLayer.ReadDataTable(SQL)
    End Function

    Public Function ReadZoomSeira(K As String) As DataTable
        On Error Resume Next
        Dim SQL As String = "SELECT DISTINCT Seira From TimFl Where KoKiTim Like '" + K + "'"
        Return _DataLayer.ReadDataTable(SQL)
    End Function

    Public Function ReadZoomRegistryDate(K As String) As DataTable
        On Error Resume Next
        Dim SQL As String = "SELECT DISTINCT RegistryDate From TimFl Where KoKiTim Like '" + K + "' Order By RegistryDate Desc"
        Return _DataLayer.ReadDataTable(SQL)
    End Function


    Public Function FindLastPlus(KoKiTim As String, Seira As String) As String
        Dim Sql As String = "Select Max(Id) As Result From TimFl Where KoKiTim = '" + KoKiTim + "' and Seira = '" + Seira + "'"
        Dim Result As String = ""
        Dim mya As New alphaFrameWork.AlphaFramework
        Dim myc As New alphaFrameWork.datalayer
        Result = (mya.MakeNo(myc.ReadDataCol(Sql).ToString, 0) + 1).ToString
        Dim i As Integer = 0
        For i = Result.Length + 1 To 6
            Result = "0" + Result
        Next
        Return Result
    End Function

End Class