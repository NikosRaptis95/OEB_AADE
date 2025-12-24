Imports accountsClassLibrary
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms

Public Class ItemMtlFlModel

    Public Sub New()
        _id = ""
        _Description = ""
        _BCode = ""
        _BCodeBox = ""
        _Category = New ItemFilPinModel()
        _Contain = 0
        _ePosition = ""
        _eShop = ""
        _Facebook = ""
        _Family = New ItemFilPinModel()
        _KindOfTax = New ItemFilPinModel()
        _Memo = " "
        _MemoEn = " "
        _MoMe = New ItemFilPinModel()
        _Paremferi = ""
        _Status = New ItemParPinModel()
        _WebSite = ""
        _YouTube = ""
        _Pictures = New List(Of ItemMtlFl_ImagesModel)
        _PicturesAll = New List(Of ItemMtlFl_ImagesModel)
        _Prices = New List(Of ItemTimesModel)
        _Balance = 0
        _BalanceXM = New List(Of ItemYpoloipaModel)
        _Pict1Mtl = ""
        _Pict2Mtl = ""
        _ECImMtl = 0
        _DescriptionEn = ""
    End Sub

    Public Sub New(StringToFind As String)
        _id = StringToFind
        _Description = StringToFind
        _BCode = StringToFind
        _BCodeBox = StringToFind
        _Category = New ItemFilPinModel(StringToFind)
        _Contain = 0
        _ePosition = StringToFind
        _eShop = StringToFind
        _Facebook = StringToFind
        _Family = New ItemFilPinModel(StringToFind)
        _KindOfTax = New ItemFilPinModel(StringToFind)
        _Memo = StringToFind
        _MemoEn = StringToFind
        _MoMe = New ItemFilPinModel(StringToFind)
        _Paremferi = StringToFind
        _Status = New ItemParPinModel(StringToFind)
        _WebSite = StringToFind
        _YouTube = StringToFind
        _Pictures = New List(Of ItemMtlFl_ImagesModel)
        _PicturesAll = New List(Of ItemMtlFl_ImagesModel)
        _Prices = New List(Of ItemTimesModel)
        _Balance = 0
        _BalanceXM = New List(Of ItemYpoloipaModel)
        _Pict1Mtl = StringToFind
        _Pict2Mtl = StringToFind
        _ECImMtl = 0
        _DescriptionEn = StringToFind
    End Sub

    Private _Pict1Mtl As String
    Public Property Pict1Mtl() As String
        Get
            Return _Pict1Mtl
        End Get
        Set(ByVal value As String)
            _Pict1Mtl = value
        End Set
    End Property

    Private _Pict2Mtl As String
    Public Property Pict2Mtl() As String
        Get
            Return _Pict2Mtl
        End Get
        Set(ByVal value As String)
            _Pict2Mtl = value
        End Set
    End Property

    Private _ECImMtl As Integer
    Public Property ECImMtl() As Integer
        Get
            Return _ECImMtl
        End Get
        Set(ByVal value As Integer)
            _ECImMtl = value
        End Set
    End Property


    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _DescriptionEn As String
    Public Property DescriptionEn() As String
        Get
            Return _DescriptionEn
        End Get
        Set(ByVal value As String)
            _DescriptionEn = value
        End Set
    End Property

    Private _MoMe As ItemFilPinModel
    Public Property MoMe() As ItemFilPinModel
        Get
            Return _MoMe
        End Get
        Set(ByVal value As ItemFilPinModel)
            _MoMe = value
        End Set
    End Property

    Private _Family As ItemFilPinModel
    Public Property Family() As ItemFilPinModel
        Get
            Return _Family
        End Get
        Set(ByVal value As ItemFilPinModel)
            _Family = value
        End Set
    End Property

    Private _BCode As String
    Public Property BCode() As String
        Get
            Return _BCode
        End Get
        Set(ByVal value As String)
            _BCode = value
        End Set
    End Property

    Private _Category As ItemFilPinModel
    Public Property Category() As ItemFilPinModel
        Get
            Return _Category
        End Get
        Set(ByVal value As ItemFilPinModel)
            _Category = value
        End Set
    End Property

    Private _BCodeBox As String
    Public Property BCodeBox() As String
        Get
            Return _BCodeBox
        End Get
        Set(ByVal value As String)
            _BCodeBox = value
        End Set
    End Property

    Private _Contain As Double
    Public Property Contain() As Double
        Get
            Return _Contain
        End Get
        Set(ByVal value As Double)
            _Contain = value
        End Set
    End Property


    Private _Status As ItemParPinModel
    Public Property Status() As ItemParPinModel
        Get
            Return _Status
        End Get
        Set(ByVal value As ItemParPinModel)
            _Status = value
        End Set
    End Property


    Private _WebSite As String
    Public Property WebSite() As String
        Get
            Return _WebSite
        End Get
        Set(ByVal value As String)
            _WebSite = value
        End Set
    End Property

    Private _Facebook As String
    Public Property Facebook() As String
        Get
            Return _Facebook
        End Get
        Set(ByVal value As String)
            _Facebook = value
        End Set
    End Property

    Private _YouTube As String
    Public Property YouTube() As String
        Get
            Return _YouTube
        End Get
        Set(ByVal value As String)
            _YouTube = value
        End Set
    End Property

    Private _Paremferi As String
    Public Property Paremferi() As String
        Get
            Return _Paremferi
        End Get
        Set(ByVal value As String)
            _Paremferi = value
        End Set
    End Property

    Private _Memo As String
    Public Property Memo() As String
        Get
            Return _Memo
        End Get
        Set(ByVal value As String)
            _Memo = value
        End Set
    End Property
    Private _MemoEn As String
    Public Property MemoEn() As String
        Get
            Return _MemoEn
        End Get
        Set(ByVal value As String)
            _MemoEn = value
        End Set
    End Property

    Private _KindOfTax As ItemFilPinModel
    Public Property KindOfTax() As ItemFilPinModel
        Get
            Return _KindOfTax
        End Get
        Set(ByVal value As ItemFilPinModel)
            _KindOfTax = value
        End Set
    End Property

    Private _eShop As String
    Public Property eShop() As String
        Get
            Return _eShop
        End Get
        Set(ByVal value As String)
            _eShop = value
        End Set
    End Property

    Private _ePosition As String
    Public Property ePosition() As String
        Get
            Return _ePosition
        End Get
        Set(ByVal value As String)
            _ePosition = value
        End Set
    End Property

    Public _Prices As List(Of ItemTimesModel)
    Public Property Prices() As List(Of ItemTimesModel)
        Get
            Return _Prices
        End Get
        Set(ByVal value As List(Of ItemTimesModel))
            _Prices = value
        End Set
    End Property

    Public _Pictures As List(Of ItemMtlFl_ImagesModel)
    Public Property Pictures() As List(Of ItemMtlFl_ImagesModel)
        Get
            Return _Pictures
        End Get
        Set(ByVal value As List(Of ItemMtlFl_ImagesModel))
            _Pictures = value
        End Set
    End Property

    Public _PicturesAll As List(Of ItemMtlFl_ImagesModel)
    Public Property PicturesAll() As List(Of ItemMtlFl_ImagesModel)
        Get
            Return _PicturesAll
        End Get
        Set(ByVal value As List(Of ItemMtlFl_ImagesModel))
            _PicturesAll = value
        End Set
    End Property

    Private _Balance As Double
    Public Property Balance() As Double
        Get
            Return _Balance
        End Get
        Set(ByVal value As Double)
            _Balance = value
        End Set
    End Property

    Public _BalanceXM As List(Of ItemYpoloipaModel)
    Public Property BalanceXM() As List(Of ItemYpoloipaModel)
        Get
            Return _BalanceXM
        End Get
        Set(ByVal value As List(Of ItemYpoloipaModel))
            _BalanceXM = value
        End Set
    End Property
End Class


Public Class MtlFl

    Public Sub New()
        Me._fields = New ItemMtlFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemMtlFlModel(StringToFind)
    End Sub

    Private _fields As ItemMtlFlModel
    Public Property Fields() As ItemMtlFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemMtlFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "MtlFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_e
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
        Dim MyMethod As String = "MtlFl_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_e
            .Fields = _fields
            If .Update() = True Then
                Return ""
            Else
                Return "Αδύνατη η ενημέρωση της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function Delete(id As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "MtlFl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New MtlFl_e
            .Fields = _fields
            Dim t As New Times()
            t.DeleteAllPrices(id)
            If .Delete(id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Structure Price
        Dim NetPrice As Double
        Dim PEkpt As Double
        Dim Ekpt As Double
        Dim PriceEkpt As Double
        Dim VatPos As Double
        Dim Vat As Double
        Dim EndPrice As Double
    End Structure

    Public Function ReadPrice(Timo As String, KindOfTax As String) As Price
        ' Read dekadika stis ajies
        Dim deka As Integer
        With New FilPin
            Try
                .Read("xr004")
                deka = CInt(.Fields.Name)
            Catch ex As Exception
                deka = 2
            End Try
        End With

        ' Read the sosth timh from mtlfl
        Dim iP As Integer = 0
        For iP = 0 To _fields.Prices.Count - 1
            If _fields.Prices(iP).PriceList.id = Timo Then Exit For
        Next

        ' set sosth Vat Category
        Dim p As Price
        Try
            Select Case KindOfTax
                Case "1"
                    p.VatPos = CDbl(_fields.KindOfTax.Name.Substring(6, 2)) + (CDbl(_fields.KindOfTax.Name.Substring(9, 2)) / 100)
                Case "2"
                    p.VatPos = CDbl(_fields.KindOfTax.Name.Substring(12, 2)) + (CDbl(_fields.KindOfTax.Name.Substring(15, 2)) / 100)
                Case Else
                    p.VatPos = CDbl(_fields.KindOfTax.Name.Substring(0, 2)) + (CDbl(_fields.KindOfTax.Name.Substring(3, 2)) / 100)
            End Select
        Catch ex As Exception
            p.VatPos = 0
        End Try

        ' set sosth Netprice from Timo
        If _fields.Prices(iP).PriceList.Flag0 = True Then
            p.NetPrice = Math.Round(_fields.Prices(iP).Price / (1 + (p.VatPos / 100)), deka)
        Else
            p.NetPrice = Math.Round(_fields.Prices(iP).Price, deka)
        End If

        ' set rest values
        p.PEkpt = _fields.Prices(iP).PEkpt
        p.Ekpt = Math.Round(p.NetPrice * p.PEkpt / 100, deka)
        p.PriceEkpt = p.NetPrice - p.Ekpt
        p.Vat = Math.Round(p.PriceEkpt * p.VatPos / 100, deka)

        ' set sosth EndPrice from Timo
        If _fields.Prices(iP).PriceList.Flag0 = True Then
            p.EndPrice = Math.Round(_fields.Prices(iP).Price, deka)
        Else
            p.EndPrice = Math.Round(p.PriceEkpt + p.Vat, deka)
        End If

        ' Return
        Return p
    End Function

    Public Function Read(id As String, Optional lang As String = "gr") As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "MtlFl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_e
            If .Read(id, lang) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ComputePrices(id As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "MtlFl_ComputePrices"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_e
            If .ComputePrices(id) > 0 Then
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function DeletePricesToSys(id As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "MtlFl_DeletePricesToSys"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_e
            If .ComputePricesToSys(id, 0, True) > 0 Then
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ComputePricesToSys(id As String, quantity As Double) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "MtlFl_ComputePricesToSys"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_e
            If .ComputePricesToSys(id, quantity) > 0 Then
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function
    Public Function ReadIfExist(id As String) As Boolean
        With New MtlFl_e
            If .ReadIfExist(id) > 0 Then
                Return True
            Else
                Return False
            End If
        End With

    End Function

    Public Function IndexPrice(Timo) As Integer
        Dim i As Integer = 0
        For i = 0 To _fields.Prices.Count - 1
            If _fields.Prices(i).PriceList.id = Timo Then Exit For
        Next
        Return i
    End Function

    Public Enum TypeOfZoom
        DefaultWeb
        CatalogWeb
        CatalogStore
        DefaultZoom
        BestSellers
        Offers
        CatalogStoreMenu
        Paremferi
        Empty
    End Enum

    Public Function ReadZoom(t As TypeOfZoom, Optional Timo As String = "", Optional Cur As String = "", Optional Category As String = "", Optional Family As String = "", Optional Description As String = "", Optional FormName As String = "", Optional lang As String = "gr") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New MtlFl_e
            .Fields = _fields
            MData = .ReadZoom(t, Timo, Cur, Category, Family, Description, FormName, lang)
        End With

        Return MData
    End Function

    Public Function ReadZoomWeb(t As TypeOfZoom, Optional Timo As String = "", Optional Cur As String = "", Optional Category As String = "", Optional Family As String = "", Optional Description As String = "", Optional FormName As String = "", Optional lang As String = "gr") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New MtlFl_e
            .Fields = _fields
            MData = .ReadZoomWeb(t, Timo, Cur, Category, Family, Description, lang)
        End With

        Return MData
    End Function

    Public Function ReadZoomWinPlan(FormName As String) As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New MtlFl_e
            .Fields = _fields
            MData = .ReadZoomWinPlan(FormName)
        End With

        Return MData
    End Function

    Public Function ReadForSkroutz(timo As String) As String
        Return New MtlFl_e().ReadForSkroutz(timo)
    End Function

    Public Function CountMtlInFamily(FamilyId As String) As Integer
        Return New MtlFl_e().CountMtlInFamily(FamilyId)
    End Function

    Public Function ConvertEnglish(description As String)
        Return New MtlFl_e().ConvertEnglish(description)
    End Function
End Class


Friend Class MtlFl_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemMtlFlModel
    End Sub


    Private _Fields As ItemMtlFlModel
    Property Fields As ItemMtlFlModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemMtlFlModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into MtlFl (Id) Values ('" + _Fields.id.Replace("'", "`") + "')"
        If _DataLayer.ExecuteNonQuery(SQL, Nothing) = True Then
            If Update() Then
                Dim t = New Times("%")
                t.InsertAllPrices(_Fields.id)
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
        Dim SQL As String = "Update MtlFl Set BCode  = '" + _Fields.BCode.Replace("'", "`")

        SQL += "' , BCodeBox  = '" + _Fields.BCodeBox.Replace("'", "`")
        SQL += "' , Paremferi = '" + _Fields.Paremferi.Replace("'", "`")
        SQL += "' , Contain = 1"
        SQL += "  , Description  = '" + _Fields.Description.Replace("'", "`")
        SQL += "' , DescriptionEn  = '" + _Fields.DescriptionEn.Replace("'", "`")
        SQL += "' , Family = '" + _Fields.Family.id
        SQL += "' , Status = '" + _Fields.Status.id.Replace("'", "`")
        SQL += "' , KindOfTax = '" + _Fields.KindOfTax.id
        SQL += "' , Memo = '" + _Fields.Memo.Replace("'", "`").Replace("/", "^")
        SQL += "' , MemoEn = '" + _Fields.MemoEn.Replace("'", "`").Replace("/", "^")
        SQL += "' , WebSite = '" + _Fields.WebSite.Replace("'", "`")
        SQL += "' , FaceBook = '" + _Fields.Facebook.Replace("'", "`")
        SQL += "' , YouTube = '" + _Fields.YouTube.Replace("'", "`")
        SQL += "' , Pict1Mtl = '" + _Fields.Pict1Mtl.Replace("'", "`")
        SQL += "' , Pict2Mtl = '" + _Fields.Pict2Mtl.Replace("'", "`")
        SQL += "' , MoMe = '" + _Fields.MoMe.id
        SQL += "' , eShop = " + _Fields.eShop

        Dim ep As String = _Fields.ePosition.Replace("'", "`")
        SQL += " , ePosition  = " + (New alphaFrameWork.AlphaFramework().MakeNo(ep, 8)).ToString().Replace(",", ".")
        SQL += " , Category = '" + _Fields.Category.id
        'SQL += " , Category = '" + _Fields.Category.id.Replace("ka", "ΧΑ")
        SQL += "' Where id = '" + _Fields.id.Replace("'", "`") + "'"
        Try
            Return _DataLayer.ExecuteNonQuery(SQL)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Delete(idToDelete As String) As Boolean
        Dim SQL As String = "Delete From MtlFl Where id = '" + idToDelete + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function ReadIfExist(idToFind As String) As Integer
        Return _DataLayer.ReadDataTable("SELECT CodeMtl FROM Adv_MtlFl Where id = '" + idToFind + "'").Rows.Count
    End Function
    Public Function Read(idToFind As String, Optional lang As String = "gr") As Integer
        'On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT BCode, BCodeBox, Contain, Description, DescriptionEn, Family, id, Status, KindOfTax, " +
                            "[Memo], [MemoEn], WebSite, FaceBook, YouTube, Paremferi, MoMe, eShop, ePosition, Category, Pict1Mtl, Pict2Mtl " +
                            "FROM MtlFl " +
                            "Where id = '" + idToFind + "'"

        Select Case lang
            Case "en"
                Try
                    'SQL = SQL.Replace("Pict2Mtl", "Pict2Mtl, DescriptionEn, MemoEn ")
                Catch ex As Exception
                    '
                End Try

            Case Else
                '
        End Select

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                Try
                    .BCode = MyTable.Rows(i).Item("BCode")
                Catch ex As Exception
                    .BCode = ""
                End Try
                Try
                    .BCodeBox = MyTable.Rows(i).Item("BCodeBox")
                Catch ex As Exception
                    .BCode = ""
                End Try
                Try
                    .Contain = MyTable.Rows(i).Item("Contain")
                Catch ex As Exception
                    .Contain = 1
                End Try
                Try
                    .DescriptionEn = MyTable.Rows(i).Item("DescriptionEn")
                Catch ex As Exception
                    .DescriptionEn = ""
                End Try
                Try
                    .Description = MyTable.Rows(i).Item("Description")
                Catch ex As Exception
                    .Description = ""
                End Try
                Try
                    .id = MyTable.Rows(i).Item("id")
                Catch ex As Exception
                    .id = ""
                End Try
                With New ParPin
                    Dim s As Integer = 0
                    Try
                        s = Convert.ToInt16(MyTable.Rows(i).Item("Status"))
                    Catch ex As Exception
                        s = 0
                    End Try
                    .Read(ParPin.TypeOfPar.Status, s)
                    _Fields.Status = .Fields
                End With
                Dim c As String = ""
                Try
                    c = MyTable.Rows(i).Item("Category")
                Catch ex As Exception
                    c = ""
                End Try
                Dim f As String = ""
                Try
                    f = MyTable.Rows(i).Item("Family")
                Catch ex As Exception
                    f = ""
                End Try
                Dim m As String = ""
                Try
                    m = MyTable.Rows(i).Item("MoMe").ToString()
                Catch ex As Exception
                    m = ""
                End Try
                Dim k As String = ""
                Try
                    k = MyTable.Rows(i).Item("KindOfTax").ToString()
                Catch ex As Exception
                    k = ""
                End Try
                With New FilPin
                    .Read(c)
                    _Fields.Category = .Fields
                    .Read(f)
                    _Fields.Family = .Fields
                    .Read(m)
                    _Fields.MoMe = .Fields
                    .Read(k)
                    _Fields.KindOfTax = .Fields
                End With
                Try
                    .Memo = MyTable.Rows(i).Item("Memo").ToString.Replace("`", "'").Replace("^", "/")
                Catch ex As Exception
                    .Memo = ""
                End Try
                Try
                    .MemoEn = MyTable.Rows(i).Item("MemoEn").ToString.Replace("`", "'").Replace("^", "/")
                Catch ex As Exception
                    .MemoEn = ""
                End Try
                Try
                    .WebSite = MyTable.Rows(i).Item("WebSite")
                Catch ex As Exception
                    .WebSite = ""
                End Try
                Try
                    .Facebook = MyTable.Rows(i).Item("Facebook")
                Catch ex As Exception
                    .Facebook = ""
                End Try
                Try
                    .YouTube = MyTable.Rows(i).Item("YouTube")
                Catch ex As Exception
                    .YouTube = ""
                End Try
                Try
                    .Paremferi = MyTable.Rows(i).Item("Paremferi")
                Catch ex As Exception
                    .Paremferi = ""
                End Try
                Try
                    .eShop = MyTable.Rows(i).Item("eShop")
                Catch ex As Exception
                    .eShop = ""
                End Try
                Try
                    .ePosition = MyTable.Rows(i).Item("ePosition")
                Catch ex As Exception
                    .ePosition = ""
                End Try

                With New MtlFl_Images
                    .Read(_Fields.id, "0")
                    _Fields.Pictures.Add(.Fields)
                    .Read(_Fields.id, "1")
                    _Fields.Pictures.Add(.Fields)
                    .Read(_Fields.id, "2")
                    _Fields.Pictures.Add(.Fields)
                End With

                Try
                    Dim pi As New MtlFl_Images("%")
                    pi.Fields.id = MyTable.Rows(i).Item("id")
                    Dim miDt As DataTable = pi.ReadZoom(MtlFl_Images.TypeOfZoom.defaultZoom)
                    For p As Integer = 0 To miDt.Rows.Count - 1
                        Dim MyPicture As New ItemMtlFl_ImagesModel()
                        With MyPicture
                            Try
                                .id = miDt.Rows(p).Item("id")
                            Catch ex As Exception
                                .id = ""
                            End Try
                            Try
                                .Description = miDt.Rows(p).Item("Description")
                            Catch ex As Exception
                                .Description = ""
                            End Try
                            Try
                                .Picture = miDt.Rows(p).Item("Picture")
                            Catch ex As Exception
                                .Picture = Nothing
                            End Try
                            Try
                                .Type.id = miDt.Rows(p).Item("Type")
                            Catch ex As Exception
                                .Type.id = ""
                            End Try
                            .Type.Name = ""
                        End With
                        With New ParPin
                            .Read(ParPin.TypeOfPar.Status, miDt.Rows(p).Item("Status"))
                            MyPicture.Status = .Fields
                        End With
                        _Fields.PicturesAll.Add(MyPicture)
                    Next
                Catch ex As Exception

                End Try


                Try
                    Dim dt As New DataTable
                    With New FilPin("%")
                        dt = .ReadZoom(FilPin.TypeOfPin.PriceList)
                    End With
                    Dim tI As Integer
                    Dim t = New Times()
                    For tI = 0 To dt.Rows.Count - 1
                        t = New Times()
                        If t.Read(_Fields.id, dt(tI)("id").ToString).Trim.Length = 0 Then _Fields.Prices.Add(t.Fields)
                    Next
                Catch ex As Exception

                End Try


                _Fields.Balance = ReadBalance()
                Try
                    _Fields.Pict1Mtl = MyTable.Rows(i).Item("Pict1Mtl").ToString()
                Catch ex As Exception
                    _Fields.Pict1Mtl = ""
                End Try
                Try
                    _Fields.Pict2Mtl = MyTable.Rows(i).Item("Pict2Mtl").ToString()
                Catch ex As Exception
                    _Fields.Pict2Mtl = ""
                End Try
                Try
                    _Fields.ECImMtl = Convert.ToInt16(MyTable.Rows(i).Item("ECImMtl"))
                Catch ex As Exception
                    _Fields.ECImMtl = 0
                End Try

            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ComputePrices(idToFind As String) As Integer
        'On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT * FROM MtlFl " +
                            "Where id = '" + idToFind + "'"



        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        If MyTable.Rows.Count > 0 Then
            Dim t As New Times()
            Dim dtTimo As DataTable
            t.Fields.Product = idToFind
            dtTimo = t.ReadZoom()

            Dim s As New Syntages()
            Dim dtSyntagi As DataTable
            dtSyntagi = s.ReadZoom(idToFind)
            Dim quantityAll As Double = 0
            For x As Integer = 0 To dtSyntagi.Rows.Count - 1
                quantityAll += dtSyntagi.Rows(x)(3)
            Next

            For i As Integer = 0 To dtTimo.Rows.Count - 1
                Dim price As Double = 0
                Dim timo As String = dtTimo(i)(2).ToString()
                For x As Integer = 0 To dtSyntagi.Rows.Count - 1
                    Dim product As String = dtSyntagi.Rows(x)(2)
                    Dim q As String = dtSyntagi.Rows(x)(3)
                    Dim quantity As Double = New alphaFrameWork.AlphaFramework().MakeNo(q, 4)
                    Dim timos As New Times
                    timos.Read(product, timo)
                    price += ((timos.Fields.Price * quantity) - ((timos.Fields.Price * quantity) * (timos.Fields.PEkpt / 100))) / quantityAll
                Next
                t.Fields.Price = price
                t.Fields.Product = idToFind
                t.Fields.PriceList.id = timo
                t.Fields.PEkpt = 0
                t.Update()
            Next

        End If

        Return MyTable.Rows.Count
    End Function

    Public Function ComputePricesToSys(idToFind As String, quantitysum As Double, Optional Delete As Boolean = False) As Integer
        On Error Resume Next
        Dim quantitysum_ As Double = quantitysum
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT * FROM MtlFl " +
                            "Where id = '" + idToFind + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        If MyTable.Rows.Count > 0 Then
            Dim t As New Times()
            Dim dtTimo As DataTable
            t.Fields.Product = idToFind
            dtTimo = t.ReadZoom()

            Dim s As New Syntages()
            Dim dtSyntagi As DataTable
            dtSyntagi = s.ReadZoom(idToFind)
            For i As Integer = 0 To dtTimo.Rows.Count - 1
                Dim timos As New Times
                Dim timo As String = dtTimo(i)("PriceList").ToString()
                timos.Read(idToFind, timo)
                Dim priceMtl As Double = timos.Fields.Price
                Dim price As Double = priceMtl
                Dim QuantityMTL As Double = 0
                For x As Integer = 0 To dtSyntagi.Rows.Count - 1
                    Dim product As String = dtSyntagi.Rows(x)("product")
                    timos.Read(product, timo)
                    QuantityMTL += dtSyntagi.Rows(x)("Quantity")
                Next
                Dim SummaryMTL As Double = 0
                SummaryMTL = QuantityMTL * priceMtl




                For x As Integer = 0 To dtSyntagi.Rows.Count - 1
                    Dim product As String = dtSyntagi.Rows(x)("product")
                    timos.Read(product, timo)
                    If timos.Fields.Price > 0 Then
                        SummaryMTL -= (timos.Fields.Price * dtSyntagi.Rows(x)("Quantity"))
                        QuantityMTL -= dtSyntagi.Rows(x)("Quantity")
                    End If
                Next


                price = SummaryMTL / QuantityMTL
                For x As Integer = 0 To dtSyntagi.Rows.Count - 1
                    Dim q As String = dtSyntagi.Rows(x)("Quantity")
                    Dim quantity As Double = New alphaFrameWork.AlphaFramework().MakeNo(q, 4)
                    Dim product As String = dtSyntagi.Rows(x)("Product")
                    timos.Read(product, timo)
                    If timos.Fields.Price = 0 Or Delete Then
                        t.Fields.Price = price '* (quantity / quantitysum)
                        If Delete Then t.Fields.Price = 0
                        t.Fields.Product = product
                        t.Fields.PriceList.id = timo
                        t.Fields.PEkpt = 0
                        t.Update()
                    End If
                Next
                quantitysum = quantitysum_
            Next

        End If


        Return MyTable.Rows.Count
    End Function


    Public Function CountMtlInFamily(FamilyId As String) As Integer
        Return New alphaFrameWork.datalayer().ReadDataTable("SELECT Count(Id) FROM Adv_MtlFl Where Family = '" + FamilyId + "'").Rows.Count
    End Function

    Public Function ReadZoomWinPlan(FormName As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim sql As String = "Select " + MyA.GetZoomTop(FormName) + " AA, 
                                                                     BCode, 
                                                                     BCodeBox, 
                                                                     Contain, 
                                                                     Description, 
                                                                     Family,
                                                                     id, 
                                                                     KindOfTax,
                                                                     Status,
                                                                     Memo, 
                                                                     WebSite, 
                                                                     Facebook, 
                                                                     Youtube, 
                                                                     Paremferi, 
                                                                     MoMe, 
                                                                     eShop, 
                                                                     ePosition, 
                                                                     Category 
                            From (SELECT 0 As AA,
                                         ISNULL(BCodMtl, N'') AS BCode, 
                                         ISNULL(CoErMtl, '') AS BCodeBox, 
                                         1 AS Contain, 
                                         ISNULL(DescMtl, '') AS Description, 
                                         'xa' + ISNULL(KathMtl, '') AS Family, 
                                         ISNULL(CodeMtl, N'') AS id, 
                                         '1' AS Status, 
                                         REPLACE(ISNULL(KfpaMtl,N''), 'ΦΠ', 'fp') AS KindOfTax, 
                                         ISNULL(SxolMtl, N'') AS Memo, 
                                         '' AS WebSite, 
                                         '' AS FaceBook, 
                                         '' AS YouTube, 
                                         ISNULL(PareMtl, N'') AS Paremferi, 
                                         REPLACE(ISNULL(MomeMtl, N''), 'ΜΜ', 'mm') AS MoMe, 
                                         CAST(ABS(EComMtl - 1) AS varchar) AS eShop, 
                                         CAST(PlaceMtl AS varchar) AS ePosition, 
                                         REPLACE(ISNULL(XaraMtl, N''), 'ΧΑ', 'ka') AS Category, '' AS Pict1Mtl, '' AS Pict2Mtl
                        FROM Adv_MtlFl) As Adv_MtlFl Where eShop ='1' And " + MyA.WhereFunc(Me.Fields, "Adv_MtlFl")  ' Mtl_WinPlan


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

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(sql, CS, DE)
        Dim tim As New TimFl()
        Dim i As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            MyTable.Rows(i)("AA") = i + 1
        Next
        Return MyTable


    End Function

    Public Function ReadZoom(t As MtlFl.TypeOfZoom, Timo As String, Cur As String, Category As String, Family As String, Description As String, FormName As String, Optional lang As String = "gr") As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim sql As String = ""

        'Dim MtlFl_Table As String = "MtlFl"

        'MtlFl_Table = " (SELECT BCodMtl AS BCode, CoErMtl AS BCodeBox, 1 AS Contain, DescMtl AS Description, 'xa' + KathMtl AS Family, CodeMtl AS id, '1' AS Status, REPLACE(KfpaMtl, 'ΦΠ', 'fp') AS KindOfTax, SxolMtl AS Memo, '' AS WebSite, 
        '                                       '' AS FaceBook, '' AS YouTube, PareMtl AS Paremferi, REPLACE(MomeMtl, 'ΜΜ', 'mm') AS MoMe, ABS(EComMtl - 1) AS eShop, PlaceMtl AS ePosition, REPLACE(XaraMtl, 'ΧΑ', 'ka') AS Category
        '                           FROM Adv_MtlFl)"

        Select Case t
            Case MtlFl.TypeOfZoom.Empty
                sql = "SELECT 0 as AA,
                              '' as PriceVat, 
                              '' As Description,
                              '' As ADescription, 
                              '' as id, 
                              '' AS price, 
                              0.00 As Price_ , 
                              '' AS priceEkptE,
                              0.00 As PEkpt_, 
                              0.00 As PEkpt,
                             '' As IDPicture,
                             '' As Saleof, 
                             '' As PriceBeforeEkptDesc, 
                             '' As EkptDesc, 
                             '' As PriceDesc, 
                             '' As PEkptDesc, 
                             '' As Apothema, 
                             0.00 As SQP,
                             '' As Category,
                             '' As Family
                       From FilPin Where id = '^'"
                Return _DataLayer.ReadDataTable(sql)
            Case MtlFl.TypeOfZoom.DefaultWeb, MtlFl.TypeOfZoom.CatalogWeb, MtlFl.TypeOfZoom.Offers, MtlFl.TypeOfZoom.CatalogStore, MtlFl.TypeOfZoom.CatalogStoreMenu, MtlFl.TypeOfZoom.Paremferi
                sql = "Select 0 As AA," +
                              "' ' as PriceVat, " +
                              "MtlFl.Description, " +
                              "'' As ADescription, " +
                              "MtlFl.id, " +
                              "' ' AS price, " +
                              "Times.Price As Price_ , " +
                              "' ' AS priceEkptE, " +
                              "Times.PEkpt As PEkpt_, " +
                              "0 as PEkpt, " +
                              "'images/Application/' + MtlFl.Id + '_1.jpg' As IDPicture, " +
                              "'' As Saleof, " +
                              "'' As PriceBeforeEkptDesc, " +
                              "'' As EkptDesc, " +
                              "'' As PriceDesc, " +
                              "'' As PEkptDesc, " +
                              "'' As Apothema, " +
                              "0 As SQP, MtlFl.Category, MtlFl.Family " +
                       "FROM MtlFl LEFT OUTER JOIN Times " +
                       "ON MtlFl.id = Times.Product And Times.PriceList = '" + Timo + "' "
            Case MtlFl.TypeOfZoom.BestSellers
                sql = "SELECT Top 10 0 as AA
                              '' as PriceVat, 
                              MtlFl.Description, 
                              '' As ADescription, 
                              MtlFl.id, 
                              '' AS price, 
                              Times.Price As Price_ , 
                              '' AS priceEkptE, 
                              Times.PEkpt As PEkpt_, 
                              0 As PEkpt, 
                              'images/Application/' + MtlFl.Id + '_1.jpg' As IDPicture, 
                              '' As Saleof, 
                              '' As PriceBeforeEkptDesc, 
                              '' As EkptDesc, 
                              '' As PriceDesc, 
                              '' As PEkptDesc, 
                              '' As Apothema, 
                              ISNULL(SUM(Ti1Fl.Quantity),0) As SQP , MtlFl.Category, MtlFl.Family                              
                       FROM (MtlFl LEFT OUTER JOIN Times 
                       On MtlFl.id = Times.Product And Times.PriceList = '" + Timo +
                       "') LEFT OUTER JOIN Ti1Fl ON MtlFl.id = Ti1Fl.MtlId And Ti1Fl.KoKiTim = '100000' "
            Case Else
                sql = "Select " + MyA.GetZoomTop(FormName) + " 0 As AA, " +
                            "MtlFl.BCode, " +
                            "MtlFl.BCodeBox, " +
                            "MtlFl.Contain, " +
                            "MtlFl.Description, " +
                            "MtlFl.Family, " +
                            "FilPin_0.Name As FamilyDescription, " +
                            "MtlFl.id, " +
                            "MtlFl.Status, " +
                            "MtlFl.KindOfTax, " +
                            "MtlFl.[Memo], " +
                            "MtlFl.WebSite, " +
                            "MtlFl.FaceBook, " +
                            "MtlFl.YouTube, " +
                            "MtlFl.Paremferi, " +
                            "MtlFl.MoMe, " +
                            "MtlFl.eShop, " +
                            "MtlFl.ePosition, " +
                            "MtlFl.Category " +
                      "FROM ((((MtlFl LEFT JOIN FilPin On MtlFl.Category = FilPin.ID) " +
                                   "LEFT JOIN FilPin As FilPin_0 On MtlFl.Family = FilPin_0.ID) " +
                                   "LEFT JOIN FilPin As FilPin_1 On MtlFl.MoMe = FilPin_1.ID) " +
                                   "LEFT JOIN FilPin As FilPin_2 On MtlFl.KindOfTax = FilPin_2.ID) "
        End Select

        Dim table As String = "MtlFl"
        Select Case lang
            Case "en"
                If t = MtlFl.TypeOfZoom.BestSellers Then
                Else
                    sql = sql.Replace(table + ".Description,", "CASE WHEN LEN(" + table + ".DescriptionEn) < 1 THEN " + table + ".Description ELSE " + table + ".DescriptionEn END As Description,")
                End If
            Case Else
                '
        End Select

        Select Case t
            Case MtlFl.TypeOfZoom.CatalogWeb
                sql = sql +
                     "Where (MtlFl.eShop = '1' And MtlFl.Category Like '" +
                      Category + "%' And MtlFl.Family Like '" + Family + "%' And (MtlFl.Description Like '%" + Description + "%' Or MtlFl.id Like '%" + Description + "%' Or MtlFl.BCodeBox Like '%" + Description + "%' Or MtlFl.Pict2Mtl Like '%" + Description + "%') ) AND (" + MyA.WhereFunc(Me.Fields, "MtlFl") +
                      MyA.WhereFuncF("[MtlFl].MoMe", _Fields.MoMe.id) +
                      MyA.WhereFuncF("[MtlFl].KindOfTax", _Fields.KindOfTax.id) +
                      ") " +
                      "Order By [MtlFl].ePosition, [MtlFl].Description"
            Case MtlFl.TypeOfZoom.CatalogStore
                sql = sql +
                     "Where (MtlFl.Category Like '" + Category +
                     "%' And MtlFl.Family Like '" + Family +
                     "%') AND (" + MyA.WhereFunc(Me.Fields, "MtlFl") +
                      MyA.WhereFuncF("[MtlFl].MoMe", _Fields.MoMe.id) +
                      MyA.WhereFuncF("[MtlFl].KindOfTax", _Fields.KindOfTax.id) +
                      ") " +
                      "Order By [MtlFl].ePosition, [MtlFl].Pict2Mtl, [MtlFl].Description"
            Case MtlFl.TypeOfZoom.CatalogStoreMenu
                sql = sql +
                     "Where (MtlFl.Category Like '" + Category +
                     "%' And MtlFl.Family Like '" + Family +
                     "%') AND (" + MyA.WhereFunc(Me.Fields, "MtlFl") +
                      MyA.WhereFuncF("[MtlFl].MoMe", _Fields.MoMe.id) +
                      MyA.WhereFuncF("[MtlFl].KindOfTax", _Fields.KindOfTax.id) +
                      ") " +
                      "Order By [MtlFl].Pict2Mtl"
            Case MtlFl.TypeOfZoom.DefaultWeb
                sql = sql +
                     "Where (MtlFl.eShop = '1' And MtlFl.ePosition >'00') AND (" +
                      MyA.WhereFunc(Me.Fields, "MtlFl") +
                      MyA.WhereFuncF("[MtlFl].[Family]", _Fields.Family.id) +
                      MyA.WhereFuncF("[MtlFl].[Category]", _Fields.Category.id) +
                      MyA.WhereFuncF("[MtlFl].MoMe", _Fields.MoMe.id) +
                      MyA.WhereFuncF("[MtlFl].KindOfTax", _Fields.KindOfTax.id) +
                     ") " +
                     "Order By [MtlFl].ePosition, [MtlFl].Description"
            Case MtlFl.TypeOfZoom.Paremferi
                sql = sql +
                     "Where MtlFl.eShop = '1' And MtlFl.ePosition >'00' AND MtlFl.Paremferi Like '%" + _Fields.Paremferi + "%' Order By [MtlFl].ePosition, [MtlFl].Description"
            Case MtlFl.TypeOfZoom.BestSellers
                sql = sql +
                     " Where MtlFl.eShop = '1' Group By MtlFl.id, MtlFl.Description, MtlFl.Category, MtlFl.Family, Times.Price, Times.PEkpt Having ISNULL(SUM(Ti1Fl.Quantity),0) > 0" +
                      " Order By SQP DESC"

            Case MtlFl.TypeOfZoom.Offers
                Dim f As New FilPin
                Dim Pos As String = "15"
                If f.Read("se004") = "" Then Pos = CDbl(f.Fields.Name).ToString()
                sql = sql +
                     " Where MtlFl.eShop = '1' And Times.PEkpt > " + Pos +
                      " Order By Times.PEkpt Desc"
            Case Else
                sql = sql +
                       "Where (" + MyA.WhereFunc(Me.Fields, "MtlFl") +
                       MyA.WhereFuncF("[filpin].[name]", _Fields.Category.Name) +
                       MyA.WhereFuncF("[filpin_1].[name]", _Fields.MoMe.Name) +
                       MyA.WhereFuncF("filpin_2.[Name]", _Fields.KindOfTax.Name) +
                       MyA.WhereFuncF("[MtlFl].[Category]", _Fields.Category.id) +
                       MyA.WhereFuncF("[MtlFl].MoMe", _Fields.MoMe.id) +
                       MyA.WhereFuncF("[MtlFl].KindOfTax", _Fields.KindOfTax.id) + ")" +
                       " Order By [MtlFl].ePosition, [MtlFl].Description"
        End Select


        'sql = sql.Replace("MtlFl", "Adv_MtlFl")
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(sql)
        Dim tim As New TimFl()
        Dim i As Integer = 0
        Dim _inStock As String = inStock()
        Dim _OutOfStock As String = OutOfStock()
        Dim _NoPrice As String = NoPrice()
        Dim deka As Integer = 2
        Dim PriceVat As String = ""
        With New FilPin
            .Read(Timo)
            If .Fields.Flag0 = False Then PriceVat = " δεν περιέχει ΦΠΑ "
            .Read("xr004")
            deka = CInt(.Fields.Name)
        End With

        For i = 0 To MyTable.Rows.Count - 1
            MyTable.Rows(i)("AA") = i + 1
            Select Case t
                Case MtlFl.TypeOfZoom.CatalogWeb, MtlFl.TypeOfZoom.DefaultWeb, MtlFl.TypeOfZoom.Offers, MtlFl.TypeOfZoom.BestSellers
                    If PriceVat <> "" Then MyTable.Rows(i)("PriceVat") = PriceVat

                    MyTable.Rows(i)("ADescription") = MyTable.Rows(i)("Description").Replace(" ", "-")
                    MyTable.Rows(i)("price") = (Math.Round(MyTable.Rows(i)("Price_"), deka)).ToString + Cur
                    If MyTable.Rows(i)("PEkpt_") > 0 Then
                        MyTable.Rows(i)("priceEkptE") = "-" + Math.Round(MyTable.Rows(i)("PEkpt_"), deka).ToString + "%=" +
                                    (Math.Round((MyTable.Rows(i)("Price_") - (MyTable.Rows(i)("Price_") * MyTable.Rows(i)("PEkpt_") / 100)), deka)).ToString + Cur
                        MyTable.Rows(i)("Saleof") = "<img style='width:50px; height:50px; position: relative; top: 22px; left:2px;' src='Images/saleoff.png' />"
                        MyTable.Rows(i)("PriceBeforeEkptDesc") = MyTable.Rows(i)("price")
                        MyTable.Rows(i)("EkptDesc") = "<p id='rcorners4' class='display-sale'>" +
                                "<span class='display-saletext'>" +
                                "-" + Math.Round(MyTable.Rows(i)("PEkpt_"), deka).ToString + "%" +
                                "</span></p>"

                        MyTable.Rows(i)("PEkptDesc") = "<div class='ribbon'><span>-" + Math.Round(MyTable.Rows(i)("PEkpt_"), 1).ToString() + "%</span></div>"
                        MyTable.Rows(i)("PriceDesc") = (Math.Round((MyTable.Rows(i)("Price_") - (MyTable.Rows(i)("Price_") * MyTable.Rows(i)("PEkpt_") / 100)), deka)).ToString + Cur
                    Else
                        MyTable.Rows(i)("Saleof") = "<img style='width:50px; height:50px; position: relative; top: 2px; left:2px;' src='Images/normal.png' />"
                        MyTable.Rows(i)("PriceBeforeEkptDesc") = ""
                        MyTable.Rows(i)("EkptDesc") = "<p id='rcorners5' class='display-sale'>" +
                                "<span class='display-saletext'>" +
                                "&nbsp" +
                                "</span></p>"
                        MyTable.Rows(i)("PriceDesc") = MyTable.Rows(i)("price")
                    End If

                    If MyTable.Rows(i)("Price_") = 0 Then MyTable.Rows(i)("PriceDesc") = _NoPrice

                    'MyTable.Rows(i)("Apothema") = _OutOfStock
                    'Dim md As DataTable = _DataLayer.ReadDataTable("SELECT Sum(Ypoloipo) FROM Ypoloipa Where id ='" + MyTable.Rows(i)("id") + "'")
                    'Dim y As Double = md.Rows(0)(0)
                    'If y > 0 Then MyTable.Rows(i)("Apothema") = _inStock

            End Select
        Next
        Return MyTable

    End Function



    Public Function ReadZoomWeb(t As MtlFl.TypeOfZoom, Timo As String, Cur As String, Category As String, Family As String, Description As String, lang As String) As DataTable
        On Error Resume Next
        Dim sql As String = ""
        Dim table As String = "MtlFl"
        If Family.Length > 2 Then
            If Family.Substring(0, 2) = "xa" Then
                table = "MtlFl_Cat"
            End If
        End If

        Select Case t
            Case MtlFl.TypeOfZoom.Empty
                sql = "SELECT 0 as AA,
                              '' as PriceVat, 
                              '' As Description,
                              '' As ImageDescription,
                              '' As ADescription,
                              '' as id, 
                              '' AS price, 
                              0.00 As Price_ , 
                              '' AS priceEkptE,
                              0.00 As PEkpt_, 
                              0.00 As PEkpt,
                             '' As IDPicture,
                             '' As Saleof, 
                             '' As PriceBeforeEkptDesc, 
                             '' As EkptDesc, 
                             '' As PriceDesc, 
                             '' As PEkptDesc, 
                             '' As Apothema, 
                             0.00 As SQP,
                             '' As Category,
                             '' As Family
                       From FilPin Where id = '^'"
                Return _DataLayer.ReadDataTable(sql)
            Case MtlFl.TypeOfZoom.BestSellers
                sql = "SELECT Top 12 0 as AA,
                              '' as PriceVat, 
                              " + table + ".Description, 
                              " + table + ".Description As ImageDescription, 
                              '' As ADescription, 
                              " + table + ".id, 
                              '' AS price, 
                              Times.Price As Price_ , 
                              '' AS priceEkptE, 
                              Times.PEkpt As PEkpt_, 
                              0 As PEkpt, 
                              '/images/Application/' + " + table + ".Id + '_1_.jpg' As IDPicture, 
                              '' As Saleof, 
                              '' As PriceBeforeEkptDesc, 
                              '' As EkptDesc, 
                              '' As PriceDesc, 
                              '' As PEkptDesc, 
                              '' As Apothema, 
                              ISNULL(SUM(Ti1Fl.Quantity),0) As SQP , " + table + ".Category, " + table + ".Family                              
                       FROM (" + table + " LEFT OUTER JOIN Times 
                       On " + table + ".id = Times.Product And Times.PriceList = '" + Timo +
                       "') LEFT OUTER JOIN Ti1Fl ON " + table + ".id = Ti1Fl.MtlId And Ti1Fl.KoKiTim = '100000' 
                        Where " + table + ".eShop = '1' Group By " + table + ".id, " + table + ".Description, " + table + ".Category, " + table + ".Family, Times.Price, Times.PEkpt Having ISNULL(SUM(Ti1Fl.Quantity),0) > 0
                       Order By SQP DESC"
            Case Else


                sql = "Select 0 As AA," +
                          "' ' as PriceVat, " +
                          "" + table + ".Description, " +
                          "" + table + ".Description As ImageDescription, " +
                          "'' As ADescription, " +
                          "" + table + ".id, " +
                          "' ' AS price, " +
                          "Times.Price As Price_ , " +
                          "' ' AS priceEkptE, " +
                          "Times.PEkpt As PEkpt_, " +
                          "0 as PEkpt, " +
                          "'/images/Application/' + " + table + ".Id + '_1_.jpg' As IDPicture, " +
                          "'' As Saleof, " +
                          "'' As PriceBeforeEkptDesc, " +
                          "'' As EkptDesc, " +
                          "'' As PriceDesc, " +
                          "'' As PEkptDesc, " +
                          "'' As Apothema, " +
                          "0 As SQP, " + table + ".Category, " + table + ".Family " +
                   "FROM " + table + " LEFT OUTER JOIN Times " +
                   "ON " + table + ".id = Times.Product And Times.PriceList = '" + Timo + "' "

        End Select

        Select Case lang
            Case "en"
                If t = MtlFl.TypeOfZoom.BestSellers Then
                Else
                    sql = sql.Replace(table + ".Description,", "CASE WHEN LEN(" + table + ".DescriptionEn) < 1 THEN " + table + ".Description ELSE " + table + ".DescriptionEn END As Description,")
                End If
            Case Else
                '
        End Select

        Select Case t
            Case MtlFl.TypeOfZoom.Offers
                Dim f As New FilPin
                Dim Pos As String = "15"
                If f.Read("se004") = "" Then Pos = CDbl(f.Fields.Name).ToString()
                sql = sql +
                     " Where " + table + ".eShop = '1' And Times.PEkpt > " + Pos +
                      " Order By Times.PEkpt Desc "
            Case MtlFl.TypeOfZoom.DefaultWeb
                sql = sql +
                     "Where " + table + ".eShop = '1' And " + table + ".ePosition >'00'  " +
                     "Order By [" + table + "].ePosition, [" + table + "].Description "
            Case MtlFl.TypeOfZoom.CatalogWeb
                sql = sql +
                     "Where (" + table + ".eShop = '1' And " + table + ".Category Like '" +
                      Category + "%' And " + table + ".Family Like '" + Family +
                      "%' And (" + table + ".Description Like '%" + Description +
                      "%' Or " + table + ".id Like '%" + Description +
                      "%' Or " + table + ".BCodeBox Like '%" + Description +
                      "%' Or " + table + ".Pict2Mtl Like '%" + Description +
                      "%') ) Order By [" + table + "].ePosition, [" + table + "].Description "
            Case MtlFl.TypeOfZoom.Paremferi
                sql = sql +
                     " Where MtlFl.eShop = '1' AND MtlFl.Paremferi Like '%" + _Fields.Paremferi + "%' Order By [MtlFl].ePosition, [MtlFl].Description"
        End Select




        Dim MyTable As DataTable = _DataLayer.ReadDataTable(sql)
        Dim tim As New TimFl()
        Dim i As Integer = 0
        Dim _inStock As String = inStock()
        Dim _OutOfStock As String = OutOfStock()
        Dim _NoPrice As String = NoPrice()
        Dim deka As Integer = 2
        Dim PriceVat As String = ""
        With New FilPin
            .Read(Timo)
            If .Fields.Flag0 = False Then PriceVat = " δεν περιέχει ΦΠΑ "
            .Read("xr004")
            deka = CInt(.Fields.Name)
        End With

        For i = 0 To MyTable.Rows.Count - 1

            'MyTable.Rows(i)("AA") = i + 1
            If PriceVat <> "" Then MyTable.Rows(i)("PriceVat") = PriceVat
            MyTable.Rows(i)("ADescription") = ConvertEnglish(MyTable.Rows(i)("ImageDescription").ToString())
            MyTable.Rows(i)("IDPicture") = MyTable.Rows(i)("IDPicture").ToString().Replace("_1_.jpg", "_1_" + MyTable.Rows(i)("ADescription").ToString() + ".jpg")

            MyTable.Rows(i)("price") = (Math.Round(MyTable.Rows(i)("Price_"), deka)).ToString + Cur

            If MyTable.Rows(i)("PEkpt_") > 0 Then
                MyTable.Rows(i)("priceEkptE") = "-" + Math.Round(MyTable.Rows(i)("PEkpt_"), deka).ToString + "%=" +
                            (Math.Round((MyTable.Rows(i)("Price_") - (MyTable.Rows(i)("Price_") * MyTable.Rows(i)("PEkpt_") / 100)), deka)).ToString + Cur
                MyTable.Rows(i)("Saleof") = "<img style='width:50px; height:50px; position: relative; top: 22px; left:2px;' src='/Images/saleoff.png' />"
                MyTable.Rows(i)("PriceBeforeEkptDesc") = MyTable.Rows(i)("price")
                MyTable.Rows(i)("EkptDesc") = "<p id='rcorners4' class='display-sale'>" +
                        "<span class='display-saletext'>" +
                        "-" + Math.Round(MyTable.Rows(i)("PEkpt_"), deka).ToString + "%" +
                        "</span></p>"

                MyTable.Rows(i)("PEkptDesc") = "<div class='ribbon'><span>-" + Math.Round(MyTable.Rows(i)("PEkpt_"), 1).ToString() + "%</span></div>"
                MyTable.Rows(i)("PriceDesc") = (Math.Round((MyTable.Rows(i)("Price_") - (MyTable.Rows(i)("Price_") * MyTable.Rows(i)("PEkpt_") / 100)), deka)).ToString + Cur
            Else
                MyTable.Rows(i)("Saleof") = "<img style='width:50px; height:50px; position: relative; top: 2px; left:2px;' src='/Images/normal.png' />"
                MyTable.Rows(i)("PriceBeforeEkptDesc") = ""
                MyTable.Rows(i)("EkptDesc") = "<p id='rcorners5' class='display-sale'>" +
                        "<span class='display-saletext'>" +
                        "&nbsp" +
                        "</span></p>"
                MyTable.Rows(i)("PriceDesc") = MyTable.Rows(i)("price")
            End If

            If MyTable.Rows(i)("Price_") = 0 Then MyTable.Rows(i)("PriceDesc") = _NoPrice

            'MyTable.Rows(i)("Apothema") = _OutOfStock
            'Dim md As DataTable = _DataLayer.ReadDataTable("SELECT Sum(Ypoloipo) FROM Ypoloipa Where id ='" + MyTable.Rows(i)("id") + "'")
            'Dim y As Double = md.Rows(0)(0)
            'If y > 0 Then MyTable.Rows(i)("Apothema") = _inStock

        Next
        Return MyTable

    End Function
    Public Function ConvertEnglish(description As String) As String
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
    Public Function ReadForSkroutz(timo As String) As String

        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim sql As String = "Select id As id,
                                    '<![CDATA['+ description + ']]>' as name,
                                    '<![CDATA['+'http://spraygun.gr/product.aspx?id='+ id +'&description=' + description + ']]>' as link,
                                    '<![CDATA['+'http://spraygun.gr/Images/Application/' + id +'_0.jpg' + ']]>' as image,
                                    '<![CDATA['+'http://spraygun.gr/Images/Application/' + id +'_1.jpg' + ']]>' as additionalimage,
                                    '<![CDATA[' + FilPin.Name + ']]>' as category,
                                    Times.Price as price_with_vat,
                                    '<![CDATA[@manufacturer]]>' as manufacturer,
                                    '@mpn' as mpn,
                                    '@ean' as ean,
                                    '@instock' as instock,
                                    '@availability' as availability,
                                    '@size' as size,
                                    '@weight' as weight,
                                    '@color' as color 
                      FROM MtlFl LEFT OUTER JOIN Times ON MtlFl.id = Times.Product And Times.PriceList = '" + timo + "' LEFT OUTER JOIN FilPin On MtlFl.Category = FilPin.ID  
                                     Where eShop = '1'"

        '  MtlFl LEFT OUTER JOIN FilPin ON MtlFl.Family = FilPin.ID LEFT OUTER JOIN  Times ON MtlFl.id = Times.Product AND Times.PriceList = 'ti003'

        Dim result As String = ""
        Using ms As New IO.MemoryStream()
            _DataLayer.ReadDataTable(sql).WriteXml(ms, System.Data.XmlWriteMode.WriteSchema)
            result = System.Text.Encoding.UTF8.GetString(ms.ToArray)
        End Using

        Return result

    End Function


    Private Function ReadBalance() As Double
        Dim ypoloipo As Double = 0
        Try
            Dim sql As String = "SELECT ISNULL(SUM(" +
                                                  "CAST(SUBSTRING(CASE WHEN FilPin.Name Is NULL THEN '000000' ELSE FilPin.Name END, 2, 1) AS Float) * Ti1Fl.Quantity - " +
                                                  "CAST(SUBSTRING(CASE WHEN FilPin.Name Is NULL THEN '000000' ELSE FilPin.Name END, 4, 1) AS Float) * Ti1Fl.Quantity " +
                                                  "),0) AS Ypoloipo " +
                                       "FROM Ti1Fl LEFT OUTER JOIN " +
                                       "filpin ON 'kl' + dbo.Ti1Fl.KoKiTim = filpin.ID " +
                                       "Where Ti1Fl.MtlId = '" + _Fields.id + "'"
            ypoloipo = _DataLayer.ReadDataTable(sql)(0)(0)

            Dim xm As New Ypoloipa("")
            xm.Fields.id = _Fields.id
            Dim dt As DataTable = xm.ReadZoom()
            Dim bxm As ItemYpoloipaModel
            For i As Integer = 0 To dt.Rows.Count - 1
                bxm = New ItemYpoloipaModel
                With bxm
                    .Description1 = dt(i)("Description1")
                    .Description2 = dt(i)("Description2")
                    .Description3 = dt(i)("Description3")

                    .id = dt(i)("id")
                    .id1 = dt(i)("id1")
                    .id2 = dt(i)("id2")
                    .id3 = dt(i)("id3")
                    .Ypoloipo = dt(i)("Ypoloipo")
                End With
                _Fields.BalanceXM.Add(bxm)
                ypoloipo += dt(i)("Ypoloipo")
            Next
        Catch ex As Exception
            ypoloipo = 0
        End Try
        Return ypoloipo
    End Function

    Private Function inStock() As String
        Dim f = New FilPin
        If f.Read("se001") = "" Then
            Return f.Fields.Name
        Else
            Return "In Stock"
        End If
    End Function
    Private Function OutOfStock() As String
        Dim f = New FilPin
        If f.Read("se002") = "" Then
            Return f.Fields.Name
        Else
            Return "Παράδοση σε 3 ημέρες"
        End If
    End Function
    Public Function NoPrice() As String
        Dim f = New FilPin
        If f.Read("se003") = "" Then
            Return f.Fields.Name
        Else
            Return "Καλέστε μας για τιμή"
        End If
    End Function






End Class