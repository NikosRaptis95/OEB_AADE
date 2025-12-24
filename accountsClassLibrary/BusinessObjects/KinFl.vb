Imports System.ComponentModel
Imports accountsClassLibrary
Public Class ItemKinFlModel

    Public Sub New()

        _id = ""
        _Cash = ""
        _idSyn = New ItemSynFlModel
        _KoKiKin = New ItemKoKiKinModel
        _Memo = ""
        _RegistryDate = Now
        _AitiKin = ""
        _Status = New ItemParPinModel
        _Seira = ""
        _Summary = 0
        _SalesPerson = ""

    End Sub

    Public Sub New(StringToFind As String)

        _id = StringToFind
        _AitiKin = StringToFind
        _Cash = StringToFind
        _Memo = StringToFind
        _AitiKin = StringToFind
        _Seira = StringToFind
        _SalesPerson = StringToFind
        _idSyn = New ItemSynFlModel(StringToFind)
        _KoKiKin = New ItemKoKiKinModel(StringToFind)
        _Status = New ItemParPinModel(StringToFind)
        Dim c As New alphaFrameWork.AlphaFramework
        StringToFind = c.clearStringFromZ(StringToFind)
        _RegistryDate = c.MakeDate(StringToFind)
        _Summary = c.MakeNo(StringToFind, 6)

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

    Private _AitiKin As String
    Property AitiKin As String
        Get
            Return _AitiKin
        End Get
        Set(ByVal value As String)
            _AitiKin = value
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

    Private _Cash As String
    Property Cash As String
        Get
            Return _Cash
        End Get
        Set(ByVal value As String)
            _Cash = value
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

    Private _KoKiKin As ItemKoKiKinModel
    Property KoKiKin As ItemKoKiKinModel
        Get
            Return _KoKiKin
        End Get
        Set(ByVal value As ItemKoKiKinModel)
            _KoKiKin = value
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

Public Class KinFl

    Public Sub New()
        Me._fields = New ItemKinFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemKinFlModel(StringToFind)
    End Sub

    Private _fields As ItemKinFlModel
    Public Property Fields() As ItemKinFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKinFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "KinFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If (.Cash < "0" Or .Cash > "1") Then Return "Η τιμή μετρητά δεν είναι σωστή !"
            If .id.Trim.Length < 1 Then Return "Δεν υπάρχει αριθμό παραστατικού !"
            Dim csyn As New SynFl
            Dim res As String = csyn.Read(_fields.idSyn.id)
            If res.Length > 0 Then Return "Δεν υπάρχει συναλλασόμενος  !"
            If .idSyn.id.Trim.Length < 1 Then Return "Δεν υπάρχει συναλλασόμενος  !"
            If .KoKiKin.id.Trim.Length < 1 Then Return "Δεν υπάρχει τύπος κίνησης κίνησης  !"
            If .KoKiKin.id.Substring(0, 1) = "0" And csyn.Fields.Kind.id = "1" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .KoKiKin.id.Substring(0, 1) = "1" And csyn.Fields.Kind.id = "0" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With

        With New kinfl_e
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
            Dim res As String = csyn.Read(_fields.idSyn.id)
            If res.Length > 0 Then Return "Δεν υπάρχει συναλλασόμενος !"
            If .idSyn.id.Trim.Length < 1 Then Return "Δεν υπάρχει συναλλασόμενος !"
            If .KoKiKin.id.Trim.Length < 1 Then Return "Δεν υπάρχει τύπος κίνησης κίνησης  !"
            If .KoKiKin.id.Substring(0, 1) = "0" And csyn.Fields.Kind.id = "1" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .KoKiKin.id.Substring(0, 1) = "1" And csyn.Fields.Kind.id = "0" Then Return "Ο τύπος του συναλλασόμενου δεν συμφωνεί με τον τύπο της κίνησης"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With


        With New kinfl_e
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


        With New kinfl_e
            .Fields = _fields
            If .Delete() = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function Read() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "kinfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New kinfl_e
            .Fields = _fields
            If .Read() > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Enum TypeOfKin
        RecieveFromCustomer
        CreditToCustomer
        PaymentToCustomer
        DebitToCustomer
        RecieveFromSuplier
        CreditToSuplier
        PaymentToSuplier
        DebitToSuplier
        All
    End Enum

    Public Function ReadTitle(MyType As TypeOfKin) As String
        Select Case MyType
            Case TypeOfKin.RecieveFromCustomer
                Return "Ευρετήριο Εισπράξεων απο Πελάτες"
            Case TypeOfKin.DebitToCustomer
                Return "Ευρετήριο Χρεώσεων σε Πελάτες"
            Case TypeOfKin.CreditToCustomer
                Return "Ευρετήριο Πιστώσεων σε Πελάτες"
            Case TypeOfKin.PaymentToCustomer
                Return "Ευρετήριο Πληρωμών σε Πελάτες"
            Case TypeOfKin.RecieveFromSuplier
                Return "Ευρετήριο Εισπράξεων απο Προμηθευτών"
            Case TypeOfKin.DebitToSuplier
                Return "Ευρετήριο Χρεώσεων σε Προμηθευτές"
            Case TypeOfKin.CreditToSuplier
                Return "Ευρετήριο Πιστώσεων σε Προμηθευτές"
            Case TypeOfKin.PaymentToSuplier
                Return "Ευρετήριο Πληρωμών σε Προμηθευτές"
            Case Else
                Return "Ευρετήριο Εισπράξεων - Πληρωμών - Χρεώσεων - Πιστώσεων"
        End Select
    End Function

    Public Function ReadZoom(K As TypeOfKin, Optional TableName As String = "KinFlQry") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New kinfl_e
            .Fields = _fields
            MData = .ReadZoom(K, TableName)
        End With

        Return MData
    End Function

    Public Function ReadZoomRegistryDate(K As String) As DataTable
        On Error Resume Next
        With New kinfl_e
            Return .ReadZoomRegistryDate(K)
        End With
    End Function

    Public Function ReadZoomSalesPerson() As DataTable
        On Error Resume Next
        With New kinfl_e
            Return .ReadZoomSalesPerson()
        End With
    End Function

    Public Function ReadZoomSeira(K As String) As DataTable
        On Error Resume Next
        With New kinfl_e
            Return .ReadZoomSeira(K)
        End With
    End Function

    Public Function ReadZoomAitiKin(K As String) As DataTable
        On Error Resume Next
        With New kinfl_e
            Return .ReadZoomAitiKin(K)
        End With
    End Function

    Public Function FindLastPlus(KoKiKin As String, Seira As String) As String
        With New kinfl_e
            Return .FindLastPlus(KoKiKin, Seira)
        End With
    End Function

    Public Function readKoKi(K As TypeOfKin) As String
        With New kinfl_e
            Return .readKoKi(K)
        End With
    End Function

    Public Function readTypeOfKin(K As String) As TypeOfKin
        With New kinfl_e
            Return .readTypeOfKin(K)
        End With
    End Function

    Public Function GetXreosiPistosi(s As Double, k As String, x As Boolean) As Double
        Dim c As New kinfl_e
        Return c.GetXreosiPistosi(s, k, x)
    End Function
End Class

Friend Class kinfl_e
    Dim _DataLayer As New alphaFrameWork.datalayer

    Public Sub New()
        Me.Fields = New ItemKinFlModel
    End Sub

    Private _fields As ItemKinFlModel
    Public Property Fields() As ItemKinFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKinFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into KinFl (id,Seira, KokiKin) Values ('" + _fields.id + "' , '" + _fields.Seira + "','" + _fields.KoKiKin.id + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete()
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update [KinFl] Set [KinFl].[AitiKin] = '" + _fields.AitiKin.Replace("'", "`") +
                                            "' , [KinFl].[Cash] = '" + _fields.Cash +
                                            "' , [KinFl].[idSyn] = '" + _fields.idSyn.id +
                                            "' , [KinFl].[Memo] = '" + _fields.Memo.Replace("'", "`") +
                                            "' , [KinFl].[RegistryDate] = " + _DataLayer.dateMark + _fields.RegistryDate.ToString("yyyy-MM-dd") + _DataLayer.dateMark +
                                            " , [KinFl].[Status] = '" + _fields.Status.id +
                                            "' , [KinFl].[Summary] = " + _fields.Summary.ToString.Replace(",", ".") +
                                            " , [KinFl].[SalesPerson] = '" + _fields.SalesPerson.Replace("'", "`") +
                                            "' Where [KinFl].[id] = '" + _fields.id + "' And [KinFl].[Seira] = '" + _fields.Seira.Replace("'", "`") + "' And [KinFl].[KoKiKin] = '" + _fields.KoKiKin.id + "';"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete() As Boolean
        Dim SQL As String = "Delete From KinFl Where id = '" + _fields.id + "' And Seira = '" + _fields.Seira.Replace("'", "`") + "' And KoKiKin = '" + _fields.KoKiKin.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read() As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select AitiKin , Cash , id , idSyn , KoKiKin , Memo , RegistryDate , Seira , Status , Summary , SalesPerson From KinFl Where id = '" + _fields.id + "' And Seira = '" + _fields.Seira.Replace("'", "`") + "' And KoKiKin = '" + _fields.KoKiKin.id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _fields
                .AitiKin = MyTable.Rows(0).Item("AitiKin")
                .Cash = MyTable.Rows(0).Item("Cash")
                .id = MyTable.Rows(0).Item("ID")
                .Memo = MyTable.Rows(0).Item("Memo")
                .Seira = MyTable.Rows(0).Item("Seira")
                .Summary = MyTable.Rows(0).Item("Summary")
                .SalesPerson = MyTable.Rows(0).Item("SalesPerson")
                .RegistryDate = MyTable.Rows(0).Item("RegistryDate")
            End With

            With New SynFl
                .Read(MyTable.Rows(0).Item("idSyn"))
                .ReadYpoloipo("")
                _fields.idSyn = .Fields
            End With
            With New KoKiKin
                .Read(MyTable.Rows(0).Item("KoKiKin"))
                _fields.KoKiKin = .Fields
            End With
            With New ParPin
                .Read(ParPin.TypeOfPar.Status, MyTable.Rows(0).Item("Status"))
                _fields.Status = .Fields
            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Enum TypeOfKin
        RecieveFromCustomer
        CreditToCustomer
        PaymentToCustomer
        DebitToCustomer
        RecieveFromSuplier
        CreditToSuplier
        PaymentToSuplier
        DebitToSuplier
        All
    End Enum
    Public Function readKoKi(K As TypeOfKin) As String
        On Error Resume Next
        Select Case K
            Case TypeOfKin.RecieveFromCustomer
                Return "00"
            Case TypeOfKin.DebitToCustomer
                Return "01"
            Case TypeOfKin.PaymentToCustomer
                Return "02"
            Case TypeOfKin.CreditToCustomer
                Return "03"
            Case TypeOfKin.RecieveFromSuplier
                Return "10"
            Case TypeOfKin.DebitToSuplier
                Return "11"
            Case TypeOfKin.PaymentToSuplier
                Return "12"
            Case TypeOfKin.CreditToSuplier
                Return "13"
            Case Else
                Return "%"
        End Select
    End Function


    Public Function readTypeOfKin(K As String) As TypeOfKin
        On Error Resume Next
        Select Case K
            Case "00"
                Return TypeOfKin.RecieveFromCustomer
            Case "01"
                Return TypeOfKin.DebitToCustomer
            Case "02"
                Return TypeOfKin.PaymentToCustomer
            Case "03"
                Return TypeOfKin.CreditToCustomer
            Case "10"
                Return TypeOfKin.RecieveFromSuplier
            Case "11"
                Return TypeOfKin.DebitToSuplier
            Case "12"
                Return TypeOfKin.PaymentToSuplier
            Case "13"
                Return TypeOfKin.CreditToSuplier
            Case Else
                Return TypeOfKin.All
        End Select
    End Function

    Public Function ReadZoom(K As TypeOfKin, T As String) As DataTable

        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select " + T + ".AitiKin , 
                                    " + T + ".Cash , 
                                    " + T + ".id , 
                                    " + T + ".idSyn , 
                                    " + T + ".KoKiKin, 
                                    " + T + ".[Memo], 
                                    " + T + ".RegistryDate, 
                                    " + T + ".Seira, 
                                    " + T + ".Status, 
                                    " + T + ".Summary, 
                                    " + T + ".SalesPerson, 
                                    SynFl.Category As SynFlCategory, 
                                    SynFl.[Name] As SynFlDescription, 
                                    '' As DescKoki, 
                                    0.1 As Xreosi, 
                                    0.1 As Pistosi, 
                                    0.1 As Ypoloipo, 
                                    (0.1 - 0.1) As sumXreosi, 
                                    (0.1 - 0.1) As sumPistosi 
                            FROM(" + T + " LEFT OUTER Join 
                                SynFl On " + T + ".idSyn = SynFl.id) "
        Dim WhereStr As String = ""

        Try
            WhereStr = " Where (" + T + ".KoKiKin Like '" + readKoKi(K) + "') And (" +
                                        MyA.WhereFunc(_fields, T) +
                                        MyA.WhereFuncF(T + ".[idSyn]", _fields.idSyn.id) +
                                        MyA.WhereFuncF("[SynFl].[Name]", _fields.idSyn.Name) +
                                        MyA.WhereFuncF("[SynFl].[Category]", _fields.idSyn.Category.id) +
                                        MyA.WhereFuncF(T + ".[KoKiKin]", _fields.KoKiKin.id) +
                                        MyA.WhereFuncF(T + ".[Cash]", ReadCash(_fields.Cash)) + ")"
        Catch ex As Exception
            WhereStr = ""
        End Try

        SQL = SQL + WhereStr + " Order By " + T + ".RegistryDate, " + T + ".KoKiKin, " + T + ".Seira, " + T + ".Id"
        Dim MData As DataTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        Dim sx As Double = 0.0
        Dim sp As Double = 0.0
        Try
            For i = 0 To MData.Rows.Count - 1
                With New KoKiKin
                    .Read(MData.Rows(i)("KoKiKin").ToString())
                    MData.Rows(i)("DescKoKi") = .Fields.Name
                End With
                If MData.Rows(i)("Cash").ToString() = "0" Then
                    MData.Rows(i)("Cash") = ""
                Else
                    MData.Rows(i)("Cash") = "+"
                End If
                MData.Rows(i)("Xreosi") = GetXreosiPistosi(MData.Rows(i)("Summary"), MData.Rows(i)("KoKiKin"), True)
                MData.Rows(i)("Pistosi") = GetXreosiPistosi(MData.Rows(i)("Summary"), MData.Rows(i)("KoKiKin"), False)
                sp += MData.Rows(i)("Pistosi") : MData.Rows(i)("sumPistosi") = sp
                sx += MData.Rows(i)("Xreosi") : MData.Rows(i)("sumXreosi") = sx
                MData.Rows(i)("Ypoloipo") = MData.Rows(i)("sumXreosi") - MData.Rows(i)("sumPistosi")
            Next
        Catch ex As Exception

        End Try

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
        Dim SQL As String = "SELECT DISTINCT SalesPerson From KinFl "
        Return _DataLayer.ReadDataTable(SQL)
    End Function

    Public Function ReadZoomSeira(K As String) As DataTable
        On Error Resume Next
        Dim SQL As String = "SELECT DISTINCT Seira From KinFl Where KoKiKin Like '" + K + "'"
        Return _DataLayer.ReadDataTable(SQL)
    End Function

    Public Function ReadZoomRegistryDate(K As String) As DataTable
        On Error Resume Next
        Dim SQL As String = "SELECT DISTINCT RegistryDate From KinFl Where KoKiKin Like '" + K + "' Order By RegistryDate Desc"
        Return _DataLayer.ReadDataTable(SQL)
    End Function

    Public Function ReadZoomAitiKin(K As String) As DataTable
        On Error Resume Next
        Dim SQL As String = "SELECT DISTINCT AitiKin From KinFl Where KoKiKin Like '" + K + "'"
        Return _DataLayer.ReadDataTable(SQL)
    End Function

    Public Function ReadMonthZoom(idSyn As String, AitiKin As String, sum As Boolean) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select Month(RegistryDate) As mMonth, Year(RegistryDate) As mYear, '' As DescDate, KoKiKin, '' As DescKoKi, Sum(Summary) As ss, 0.1 As Xreosi, 0.1 As Pistosi, 0.1 As sumXreosi, 0.1 As sumPistosi, 0.1 As Ypoloipo FROM KinFlQry "
        Dim WhereStr As String = " Where IdSyn Like '" + idSyn + "' And AitiKin Like '%" + AitiKin + "%'"
        Dim GroupStr As String = " group by Year(RegistryDate), Month(RegistryDate), KoKiKin"

        Dim MData As DataTable = _DataLayer.ReadDataTable(SQL + WhereStr + GroupStr)

        Dim i As Integer
        Dim sx As Double = 0.0
        Dim sp As Double = 0.0
        For i = 0 To MData.Rows.Count - 1
            With New KoKiKin
                .Read(MData.Rows(i)("KoKiKin").ToString())
                MData.Rows(i)("DescKoKi") = .Fields.Name
            End With
            MData.Rows(i)("Xreosi") = GetXreosiPistosi(MData.Rows(i)("ss"), MData.Rows(i)("KoKiKin"), True)
            MData.Rows(i)("Pistosi") = GetXreosiPistosi(MData.Rows(i)("ss"), MData.Rows(i)("KoKiKin"), False)
            sp += MData.Rows(i)("Pistosi") : MData.Rows(i)("sumPistosi") = sp
            sx += MData.Rows(i)("Xreosi") : MData.Rows(i)("sumXreosi") = sx
            MData.Rows(i)("Ypoloipo") = MData.Rows(i)("sumXreosi") - MData.Rows(i)("sumPistosi")
            With New alphaFrameWork.AlphaFramework
                MData.Rows(i)("DescDate") = .MakeMonthDesc(MData.Rows(i)("mMonth"), MData.Rows(i)("mYear"))
            End With
        Next
        If Not sum Then
            Return MData
            Exit Function
        End If

        SQL = "Select Month(RegistryDate) As mMonth, Year(RegistryDate) As mYear, '' As DescDate, (0.1 - 0.1) As Xreosi, (0.1 - 0.1) As Pistosi, 0.1 As sumXreosi, 0.1 As sumPistosi, 0.1 As Ypoloipo FROM KinFlQry "
        GroupStr = " group by Year(RegistryDate), Month(RegistryDate)"
        Dim table As DataTable = _DataLayer.ReadDataTable(SQL + WhereStr + GroupStr)
        For i = 0 To table.Rows.Count - 1
            With New alphaFrameWork.AlphaFramework
                table.Rows(i)("DescDate") = .MakeMonthDesc(table.Rows(i)("mMonth"), table.Rows(i)("mYear"))
            End With
            Dim x As Integer
            Dim xr As Double = 0.0
            Dim ps As Double = 0.0
            For x = 0 To MData.Rows.Count - 1
                If table.Rows(i)("DescDate") = MData.Rows(x)("DescDate") Then
                    xr += MData.Rows(x)("Xreosi") : table.Rows(i)("Xreosi") = xr
                    ps += MData.Rows(x)("Pistosi") : table.Rows(i)("Pistosi") = ps
                    table.Rows(i)("sumXreosi") = MData.Rows(x)("sumXreosi")
                    table.Rows(i)("sumPistosi") = MData.Rows(x)("sumPistosi")
                    table.Rows(i)("Ypoloipo") = MData.Rows(x)("Ypoloipo")
                End If
            Next
        Next

        Return table

    End Function

    Public Function ReadSumKoKiGen() As DataTable
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select KoKiKin, '' As DescKoKi, Sum(Summary) As ss, 0.1 As Xreosi, 0.1 As Pistosi, 0.1 As sumXreosi, 0.1 As sumPistosi, 0.1 As Ypoloipo FROM KinFlQry "
        Dim GroupStr As String = " group by KoKiKin"
        Dim MData As DataTable = _DataLayer.ReadDataTable(SQL + GroupStr)
        Dim i As Integer
        Dim sx As Double = 0.0
        Dim sp As Double = 0.0
        For i = 0 To MData.Rows.Count - 1
            With New KoKiKin
                .Read(MData.Rows(i)("KoKiKin").ToString())
                MData.Rows(i)("DescKoKi") = .Fields.Name
            End With
            MData.Rows(i)("Xreosi") = GetXreosiPistosi(MData.Rows(i)("ss"), MData.Rows(i)("KoKiKin"), True)
            MData.Rows(i)("Pistosi") = GetXreosiPistosi(MData.Rows(i)("ss"), MData.Rows(i)("KoKiKin"), False)
            sp += MData.Rows(i)("Pistosi") : MData.Rows(i)("sumPistosi") = sp
            sx += MData.Rows(i)("Xreosi") : MData.Rows(i)("sumXreosi") = sx
            MData.Rows(i)("Ypoloipo") = MData.Rows(i)("sumXreosi") - MData.Rows(i)("sumPistosi")
        Next
        Return MData
    End Function

    Public Function ReadYpoloipo(idSyn As String, AitiKin As String, untildt As DateTime) As Double
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select  KoKiKin,  Sum(Summary) As ss FROM KinFlQry Where IdSyn = '" + idSyn +
                            "' And AitiKin Like '%" + AitiKin + "%'" +
                            " And RegistryDate <= " + _DataLayer.dateMark + untildt.ToString("yyyy-MM-dd") + _DataLayer.dateMark +
                            " group by KoKiKin"
        Dim MData As DataTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer
        Dim Ypoloipo As Double = 0.0
        For i = 0 To MData.Rows.Count - 1
            Ypoloipo = Ypoloipo + (GetXreosiPistosi(MData.Rows(i)("ss"), MData.Rows(i)("KoKiKin"), True) -
                                   GetXreosiPistosi(MData.Rows(i)("ss"), MData.Rows(i)("KoKiKin"), False))
        Next
        Return Ypoloipo
    End Function

    Public Function GetXreosiPistosi(s As Double, k As String, x As Boolean) As Double
        Select Case k
            Case "00", "03", "10", "13"
                If x = False Then Return s
            Case Else
                If x Then Return s
        End Select
        Return 0.0
    End Function

    Public Function FindLastPlus(KoKiKin As String, Seira As String) As String
        Dim Sql As String = "Select Max(Id) As Result From KinFl Where KoKiKin = '" + KoKiKin + "' and Seira = '" + Seira + "'"
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

    'Dim a As New alphaFrameWork.AlphaFramework()
    'Dim _s As New S(a.lang)
    'Private Class S

    '    Private lang As String = "gr";
    '   Public Sub S(_lang As String)
    '        lang = _lang
    '    End Sub

    '    Public Function G(id As Int16) As String

    '        Select Case lang
    '            Case "gr"
    '                Select Case id
    '                    Case 1
    '                        Return "Πελάτης"
    '                    Case 2
    '                        Return "Πελάτες"
    '                    Case 3
    '                        Return "΄Πελατών"
    '                    Case 4
    '                        Return "Προμηθευτής"
    '                    Case 5
    '                        Return "Προμηθευτές"
    '                    Case 6
    '                        Return "Προμηθευτών"
    '                    Case Else
    '                        Return "Δεν βρέθηκε η συμβολοσειρά"
    '                End Select
    '            Case "grExEx"
    '                Select Case id
    '                    Case 1
    '                        Return "Έσοδο"
    '                    Case 2
    '                        Return "Έσοδα"
    '                    Case 3
    '                        Return "΄Εσόδων"
    '                    Case 4
    '                        Return "Έξοδο"
    '                    Case 5
    '                        Return "Έξοδα"
    '                    Case 6
    '                        Return "Εξόδων"
    '                    Case Else
    '                        Return "Δεν βρέθηκε η συμβολοσειρά"
    '                End Select
    '            Case Else
    '                Select Case id
    '                    Case 1
    '                        Return "Customer"
    '                    Case 2
    '                        Return "Customers"
    '                    Case 3
    '                        Return "Customers"
    '                    Case 4
    '                        Return "Supplier"
    '                    Case 5
    '                        Return "Suppliers"
    '                    Case 6
    '                        Return "Suppliers"
    '                    Case Else
    '                        Return "String not found"
    '                End Select
    '        End Select


    '    End Function

    'End Class

End Class