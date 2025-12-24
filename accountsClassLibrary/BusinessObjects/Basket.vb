Imports accountsClassLibrary

'Public Class BasketSession
'    Public Class ItemBasketSession

'    End Class
'End Class




Public Class ItemBasketModel

    Public Sub New()

        _Syn = New ItemSynFlModel
        _Mtl = New ItemMtlFlModel
        _Quantity = 0
        _Gross = 0
        _Price = 0
        _Kind = New ItemParPinModel
        _PEkpt = 0
        _VatPos = 0
        _Vat = 0
        _Web = New ItemParPinModel
        _RegDateTime = Now
        _SessionID = ""
        _id1 = ""
        _id2 = ""
        _id3 = ""
    End Sub

    Public Sub New(StringToFind As String)

        _Syn = New ItemSynFlModel(StringToFind)
        _Mtl = New ItemMtlFlModel(StringToFind)

        _Kind = New ItemParPinModel(StringToFind)
        _Web = New ItemParPinModel(StringToFind)

        _SessionID = (StringToFind)
        Dim c As New alphaFrameWork.AlphaFramework
        StringToFind = c.clearStringFromZ(StringToFind)
        _RegDateTime = c.MakeDate(StringToFind)
        Dim d As Double = c.MakeNo(StringToFind, 6)
        _Quantity = d
        _Gross = d
        _Price = d
        _PEkpt = d
        _VatPos = d
        _Vat = d
        _id1 = StringToFind
        _id2 = StringToFind
        _id3 = StringToFind
    End Sub

    Private _Syn As ItemSynFlModel
    Property Syn As ItemSynFlModel
        Get
            Return _Syn
        End Get
        Set(ByVal value As ItemSynFlModel)
            _Syn = value
        End Set
    End Property

    Private _Mtl As ItemMtlFlModel
    Property Mtl As ItemMtlFlModel
        Get
            Return _Mtl
        End Get
        Set(ByVal value As ItemMtlFlModel)
            _Mtl = value
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

    Private _Price As Double
    Property Price As Double
        Get
            Return _Price
        End Get
        Set(ByVal value As Double)
            _Price = value
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

    Private _PEkpt As Double
    Property PEkpt As Double
        Get
            Return _PEkpt
        End Get
        Set(ByVal value As Double)
            _PEkpt = value
        End Set
    End Property

    Private _VatPos As Double
    Property VatPos As Double
        Get
            Return _VatPos
        End Get
        Set(ByVal value As Double)
            _VatPos = value
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

    Private _Web As ItemParPinModel
    Property Web As ItemParPinModel
        Get
            Return _Web
        End Get
        Set(ByVal value As ItemParPinModel)
            _Web = value
        End Set
    End Property

    Private _RegDateTime As DateTime
    Property RegDateTime As DateTime
        Get
            Return _RegDateTime
        End Get
        Set(ByVal value As DateTime)
            _RegDateTime = value
        End Set
    End Property

    Private _SessionID As String
    Property SessionID As String
        Get
            Return _SessionID
        End Get
        Set(ByVal value As String)
            _SessionID = value
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
End Class

Public Class Basket
    Public Sub New()
        Me._fields = New ItemBasketModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemBasketModel(StringToFind)
    End Sub

    Private _fields As ItemBasketModel
    Public Property Fields() As ItemBasketModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemBasketModel)
            _fields = value
        End Set
    End Property


    Public Function Update(Optional compute As Boolean = False, Optional characteristics As Boolean = False) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Basket_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Basket_e
            If compute Then ComputeSection(characteristics)
            .Fields = _fields
            If .Update() = True Then
                Return ""
            Else
                Return "Αδύνατη η εγγραφή" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν δέν υπάρχει !"
            End If
        End With

    End Function

    Public Function Insert(Optional compute As Boolean = True, Optional characteristics As Boolean = False) As String
        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Basket_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        If _fields.Mtl.id.Substring(0, 1).ToUpper = "C" Then Return "C" : Exit Function

        With New Basket_e
            If compute Then ComputeSection(characteristics)
            .Fields = _fields
            If .Insert() = True Then
                Return ""
            Else
                Return "Αδύνατη η ενημέρωση της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Private Sub ComputeSection(characteristics As Boolean)
        With New SynFl
            .Read(_fields.Syn.id)
            _fields.Syn = .Fields
            _fields.Kind = .Fields.Kind
        End With

        Dim price As New MtlFl.Price
        With New MtlFl
            .Read(_fields.Mtl.id)
            _fields.Mtl = .Fields
            price = .ReadPrice(_fields.Syn.PriceList.id, _fields.Syn.KindOfTax.id)
        End With

        _fields.PEkpt = price.PEkpt
        _fields.Vat = price.Vat * _fields.Quantity
        _fields.VatPos = price.VatPos
        _fields.Price = price.EndPrice

        If characteristics And _fields.Price <> 0 Then _fields.RegDateTime = _fields.RegDateTime.AddMilliseconds(10)
        'If characteristics And _fields.Price <> 0 Then _fields.RegDateTime = Now

    End Sub

    Public Function Delete(id As String, sessionId As String, regDT As DateTime, Optional DeleteOldBasket As Boolean = False) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Basket_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Basket_e
            .Fields = _fields
            If .Delete(id, sessionId, regDT, DeleteOldBasket) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function DeleteLine(regDT As String, sID As String) As String


        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Basket_DeleteLine"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Basket_e
            .Fields = _fields
            If .DeleteLine(regDT, sID) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function AddQuantityToLine(regDT As String, sID As String, quantity As Integer) As String
        Read(regDT, sID)
        Dim tmpVat As Double
        If _fields.Vat <> 0 Then tmpVat = _fields.Vat / _fields.Quantity
        _fields.Quantity += quantity
        If _fields.Quantity > 0 And _fields.Quantity < 101 Then
            _fields.Vat = Math.Round(tmpVat * _fields.Quantity, 2)
            Return Update()
        Else
            Return False
        End If
    End Function
    Public Function Read(regDT As String, sID As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Basket_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Basket_e
            .Fields = _fields
            If .Read(regDT, sID) = True Then
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function DeleteSession(Sess As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Basket_DeleteSession"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Basket_e
            .Fields = _fields
            If .DeleteSession(Sess) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function ReadQuantity(id As String, sessionId As String) As Double

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Basket_ReadQuantity"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Basket_e
            Return .ReadQuantity(id, sessionId)
        End With

    End Function

    Public Function ReadZoom(Session As String, Optional Group As Boolean = True) As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New Basket_e
            .Fields = _fields
            MData = .ReadZoom(Session, Group)
        End With

        Return MData
    End Function
End Class

Friend Class Basket_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemBasketModel
    End Sub

    Private _Fields As ItemBasketModel
    Property Fields As ItemBasketModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemBasketModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        With New alphaFrameWork.datalayer
            Dim SQL As String = "Insert Into Basket (Id, SessionId, RegDateTime) Values ('" +
                                                    _Fields.Mtl.id + "','" +
                                                    _Fields.SessionID + "'," + .dateMark +
                                                    _Fields.RegDateTime.ToString("yyyy-MM-dd hh:mm:ss:fff") + .dateMark +
                                                    ")"
            If _DataLayer.ExecuteNonQuery(Sql) = True Then
                If Update() Then
                    Return True
                Else
                    Delete(_Fields.Mtl.id, _Fields.SessionID, _Fields.RegDateTime, False)
                    Return False
                End If
            Else
                Return False
            End If
        End With
    End Function

    Public Function Update() As Boolean
        With New alphaFrameWork.datalayer
            Dim SQL As String = "Update Basket Set SynId = '" + _Fields.Syn.id + "'" +
                                        " , id1 = '" + _Fields.id1 + "'" +
                                        " , id2 = '" + _Fields.id2 + "'" +
                                        " , id3 = '" + _Fields.id3 + "'" +
                                        " , SynDesc = '" + _Fields.Syn.Name.Replace("'", "`") + "'" +
                                        " , SynKOT = '" + _Fields.Syn.KindOfTax.id + "'" +
                                        " , SynPriceList = '" + _Fields.Syn.PriceList.id + "'" +
                                        " , KindOfTax = '" + _Fields.Mtl.KindOfTax.id + "'" +
                                        " , [Name] = '" + _Fields.Mtl.Description.Replace("'", "`") + "'" +
                                        " , MoMe = '" + _Fields.Mtl.MoMe.id + "'" +
                                        " , Quantity = " + _Fields.Quantity.ToString.Replace(",", ".") +
                                        " , Gross = " + _Fields.Gross.ToString.Replace(",", ".") +
                                        " , Price = " + _Fields.Price.ToString.Replace(",", ".") +
                                        " , Kind = '" + _Fields.Syn.Kind.id + "'" +
                                        " , PEkpt = " + _Fields.PEkpt.ToString.Replace(",", ".") +
                                        " , VatPos = " + _Fields.VatPos.ToString.Replace(",", ".") +
                                        " , Vat = " + _Fields.Vat.ToString.Replace(",", ".") +
                                        " , Web = '" + _Fields.Web.id.ToString.Replace(",", ".") +
                                        "' Where Id = '" + _Fields.Mtl.id + "' And " +
                                        " SessionId = '" + _Fields.SessionID + "' And " +
                                        " RegDateTime = " + .dateMark + _Fields.RegDateTime.ToString("yyyy-MM-dd hh:mm:ss:fff") + .dateMark
            Return _DataLayer.ExecuteNonQuery(SQL)
        End With
    End Function

    Public Function DeleteLine(regDT As String, sID As String) As Boolean
        Dim fregDT As String = DateTime.Parse(regDT.Substring(0, 19)).AddMilliseconds(CDbl(regDT.Substring(20, 3))).ToString("yyyy-MM-dd hh:mm:ss:fff")
        Dim tregDT As String = DateTime.Parse(regDT.Substring(0, 19)).AddMilliseconds(CDbl(regDT.Substring(20, 3) + 10)).ToString("yyyy-MM-dd hh:mm:ss:fff")

        Dim SQL As String = "Delete From Basket Where  (RegDateTime = " + _DataLayer.dateMark + fregDT + _DataLayer.dateMark +
                                              "  or   RegDateTime = " + _DataLayer.dateMark + tregDT + _DataLayer.dateMark +
                                              ")  And   (SessionId   = '" + sID + "')"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function


    Public Function Read(regDT As String, sID As String) As Integer
        On Error Resume Next
        Dim fregDT As String = DateTime.Parse(regDT.Substring(0, 19)).AddMilliseconds(CDbl(regDT.Substring(20, 3))).ToString("yyyy-MM-dd hh:mm:ss:fff")
        Dim tregDT As String = DateTime.Parse(regDT.Substring(0, 19)).AddMilliseconds(CDbl(regDT.Substring(20, 3) + 10)).ToString("yyyy-MM-dd hh:mm:ss:fff")
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select SynId, SynDesc, SynKOT, SynPriceList, Id, KindOfTax, Name, MoMe, Quantity, Gross, Price, Kind, PEkpt, VatPos, Vat, Web, RegDateTime, SessionID, id1, id2, id3 " +
                            " FROM Basket Where  (RegDateTime = " + _DataLayer.dateMark + fregDT + _DataLayer.dateMark +
                                              "  or   RegDateTime = " + _DataLayer.dateMark + tregDT + _DataLayer.dateMark +
                                              ")  And   (SessionId   = '" + sID + "')"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .Syn.id = MyTable.Rows(i).Item("SynId")
                .Syn.Name = MyTable.Rows(i).Item("SynDesc")
                .Syn.KindOfTax = MyTable.Rows(i).Item("SynKOT")
                .Syn.PriceList.id = MyTable.Rows(i).Item("SynPriceList")
                .Mtl.id = MyTable.Rows(i).Item("Id")
                .Mtl.KindOfTax.id = MyTable.Rows(i).Item("KindOfTax")
                .Mtl.Description = MyTable.Rows(i).Item("Name")
                .Mtl.MoMe.id = MyTable.Rows(i).Item("MoMe")
                .Quantity = MyTable.Rows(i).Item("Quantity")
                .Gross = MyTable.Rows(i).Item("Gross")
                .Price = MyTable.Rows(i).Item("Price")
                .Kind = MyTable.Rows(i).Item("Kind")
                .PEkpt = MyTable.Rows(i).Item("PEkpt")
                .VatPos = MyTable.Rows(i).Item("VatPos")
                .Vat = MyTable.Rows(i).Item("Vat")
                .Web.id = MyTable.Rows(i).Item("Web")
                .RegDateTime = MyTable.Rows(i).Item("RegDateTime")
                .SessionID = MyTable.Rows(i).Item("SessionID")
                .id1 = MyTable.Rows(i).Item("id1")
                .id2 = MyTable.Rows(i).Item("id2")
                .id3 = MyTable.Rows(i).Item("id3")
            End With
            '    Dim Custom = New accountsClassLibrary_Custom.BusinessObjects.SynFlCustom()
            '    Custom.Read(_Fields, MyTable.Rows(i))
        Next

        Return MyTable.Rows.Count

    End Function

    Public Function Delete(id As String, sessionId As String, regDT As DateTime, Optional DeleteOldBasket As Boolean = False) As Boolean
        Dim SQL As String = "Delete From Basket Where Id = '" + id + "' And " +
                                             " SessionId = '" + sessionId + "' And " +
                                           " RegDateTime = " + _DataLayer.dateMark +
                                                               regDT.ToString("yyyy-MM-dd hh:mm:ss:fff") +
                                                               _DataLayer.dateMark
        If DeleteOldBasket Then SQL = "Delete From Basket Where web = '1' and RegDateTime <= '" + Now.AddDays(-1).ToString("yyyy/MM/dd hh:mm:ss") + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function DeleteSession(sessionId As String) As Boolean
        Dim SQL As String = "Delete From Basket Where  SessionId = '" + sessionId + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function ReadQuantity(id As String, sessionId As String) As Double
        Dim res As Double = 0
        Try
            res = _DataLayer.ReadDataTable("SELECT Sum(Quantity) FROM Basket Where Id Like '" + id + "' And SessionId = '" + sessionId + "'").Rows(0).Item(0)
        Catch ex As Exception
            res = 0
        End Try
        Return res
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
    Public Function ReadZoom(Session As String, Group As Boolean) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim CryteriaQuantity As String = ""
        If Group Then CryteriaQuantity = " And (Quantity * (Price-(Price*PEkpt/100))) <> 0 "
        Dim sql As String = "SELECT 0 As AA, " +
                                     "'' As deleteId, Id, Name As NameA, Name + '(id'+ Id + ')' As Name, " +
                            "Quantity, Price As Price_Or, PEkpt, Gross, VatPos, MoMe, KindOfTax, Price-(Price*PEkpt/100) As Price, 'images/Application/' + " +
                            "Id + '_1_.jpg' As IDPicture, Quantity * (Price-(Price*PEkpt/100)) As Summary, Vat, RegDateTime, id1, id2, id3, '' As dxm From Basket " +
                            "Where SessionID = '" + Session + "' " + CryteriaQuantity + " Order By SessionID, RegDateTime, Summary Desc"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(sql)

        Dim i As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            Dim dtTmp As DateTime = MyTable.Rows(i)("RegDateTime")

            If Group Then
                Dim sTmp As String = _DataLayer.dateMark + dtTmp.ToString("yyyy-MM-dd hh:mm:ss:fff") + _DataLayer.dateMark
                sql = "SELECT Name + '('+ Id + ')' As Name, Quantity From Basket  Where (Quantity * (Price-(Price*PEkpt/100))) = 0 And " +
                      " RegDateTime = " + sTmp
                Dim dt As DataTable = _DataLayer.ReadDataTable(sql)
                Dim x As Integer
                For x = 0 To dt.Rows.Count - 1
                    MyTable.Rows(i)("Name") = MyTable.Rows(i)("Name") + " + <br/>" + dt.Rows(x)("Name")
                Next
            End If

            MyTable.Rows(i)("IDPicture") = MyTable.Rows(i)("IDPicture").ToString().Replace("_1_.jpg", "_1_" + ConvertEnglish(MyTable.Rows(i)("NameA").ToString()) + ".jpg")

            MyTable.Rows(i)("deleteId") = dtTmp.ToString("yyyy-MM-dd hh:mm:ss:fff")
            MyTable.Rows(i)("AA") = i + 1
            MyTable.Rows(i)("Quantity") = Math.Round(MyTable.Rows(i)("Quantity"), 2)
            MyTable.Rows(i)("Price") = Math.Round(MyTable.Rows(i)("Price"), 2)
            MyTable.Rows(i)("Summary") = Math.Round(MyTable.Rows(i)("Summary"), 2)
            MyTable.Rows(i)("NameA") = MyTable.Rows(i)("NameA").ToString.Replace(" ", "-")
            MyTable.Rows(i)("dxm") = readDesc(MyTable.Rows(i)("id"), MyTable.Rows(i)("id1"), MyTable.Rows(i)("id2"), MyTable.Rows(i)("id3"))
        Next

        Return MyTable

    End Function

    Private Function readDesc(id As String, id1 As String, id2 As String, id3 As String) As String
        Try
            Dim y As New Ypoloipa()
            y.Read(id, id1, id2, id3)
            Return y.Fields.Description1 + " " + y.Fields.Description2 + " " + y.Fields.Description3
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class