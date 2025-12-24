Imports accountsClassLibrary
Imports alphaFrameWork
Public Class ItemAADEFlModel
    Public Sub New()
        _auditTransactionId = ""
        _auditTransactionDate = Now
        _auditUnit = ""
        _auditProtocol = ""
        _auditUserId = ""
        _auditUserIp = ""
        _Status = New ItemParPinModel
        _doy = ""
        _inMctCod = ""
        _inSctCod = ""
        _extOrg = ""
        _txtCod = ""
        _insFrequency = ""
        _lastDayRule = ""
        _fiscalYear = ""
        _synolo = 0
        _comments = ""
        _ypiresiaDescr = ""
        _apofNoEtos = ""
        _afmYpogr = ""
        _nameYpogr = ""
        _auditdt = New DataTable
    End Sub

    Public Sub New(StringToFind As String)
        Dim c As New alphaFrameWork.AlphaFramework
        _auditTransactionId = StringToFind
        _auditTransactionDate = c.MakeDate(StringToFind)
        _auditUnit = StringToFind
        _auditProtocol = StringToFind
        _auditUserId = StringToFind
        _auditUserIp = StringToFind
        _doy = StringToFind
        _inMctCod = StringToFind
        _inSctCod = StringToFind
        _extOrg = StringToFind
        _txtCod = StringToFind
        _insFrequency = StringToFind
        _lastDayRule = StringToFind
        _fiscalYear = StringToFind
        _synolo = c.MakeNo(StringToFind, 2)
        _comments = StringToFind
        _ypiresiaDescr = StringToFind
        _apofNoEtos = StringToFind
        _afmYpogr = StringToFind
        _nameYpogr = StringToFind
        _Status = New ItemParPinModel(StringToFind)
        _auditdt = New DataTable
    End Sub

    Private _doy As String
    Property doy As String
        Get
            Return _doy
        End Get
        Set(ByVal value As String)
            _doy = value
        End Set
    End Property
    Private _auditdt As DataTable
    Property auditdt As DataTable
        Get
            Return _auditdt
        End Get
        Set(ByVal value As DataTable)
            _auditdt = value
        End Set
    End Property

    Private _auditTransactionId As String
    Property auditTransactionId As String
        Get
            Return _auditTransactionId
        End Get
        Set(ByVal value As String)
            _auditTransactionId = value
        End Set
    End Property

    Private _auditUnit As String
    Property auditUnit As String
        Get
            Return _auditUnit
        End Get
        Set(ByVal value As String)
            _auditUnit = value
        End Set
    End Property

    Private _auditProtocol As String
    Property auditProtocol As String
        Get
            Return _auditProtocol
        End Get
        Set(ByVal value As String)
            _auditProtocol = value
        End Set
    End Property

    Private _auditTransactionDate As DateTime
    Property auditTransactionDate As DateTime
        Get
            Return _auditTransactionDate
        End Get
        Set(ByVal value As DateTime)
            _auditTransactionDate = value
        End Set
    End Property

    Private _auditUserId As String
    Property auditUserId As String
        Get
            Return _auditUserId
        End Get
        Set(ByVal value As String)
            _auditUserId = value
        End Set
    End Property

    Private _auditUserIp As String
    Property auditUserIp As String
        Get
            Return _auditUserIp
        End Get
        Set(ByVal value As String)
            _auditUserIp = value
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

    Private _synolo As Double
    Property synolo As Double
        Get
            Return _synolo
        End Get
        Set(ByVal value As Double)
            _synolo = value
        End Set
    End Property
    Private _nameYpogr As String
    Property nameYpogr As String
        Get
            Return _nameYpogr
        End Get
        Set(ByVal value As String)
            _nameYpogr = value
        End Set
    End Property
    Private _afmYpogr As String
    Property afmYpogr As String
        Get
            Return _afmYpogr
        End Get
        Set(ByVal value As String)
            _afmYpogr = value
        End Set
    End Property
    Private _apofNoEtos As String
    Property apofNoEtos As String
        Get
            Return _apofNoEtos
        End Get
        Set(ByVal value As String)
            _apofNoEtos = value
        End Set
    End Property
    Private _ypiresiaDescr As String
    Property ypiresiaDescr As String
        Get
            Return _ypiresiaDescr
        End Get
        Set(ByVal value As String)
            _ypiresiaDescr = value
        End Set
    End Property
    Private _comments As String
    Property comments As String
        Get
            Return _comments
        End Get
        Set(ByVal value As String)
            _comments = value
        End Set
    End Property

    Private _fiscalYear As String
    Property fiscalYear As String
        Get
            Return _fiscalYear
        End Get
        Set(ByVal value As String)
            _fiscalYear = value
        End Set
    End Property

    Private _inMctCod As String
    Property inMctCod As String
        Get
            Return _inMctCod
        End Get
        Set(ByVal value As String)
            _inMctCod = value
        End Set
    End Property

    Private _inSctCod As String
    Property inSctCod As String
        Get
            Return _inSctCod
        End Get
        Set(ByVal value As String)
            _inSctCod = value
        End Set
    End Property
    Private _extOrg As String
    Property extOrg As String
        Get
            Return _extOrg
        End Get
        Set(ByVal value As String)
            _extOrg = value
        End Set
    End Property

    Private _txtCod As String
    Property txtCod As String
        Get
            Return _txtCod
        End Get
        Set(ByVal value As String)
            _txtCod = value
        End Set
    End Property

    Private _insFrequency As String
    Property insFrequency As String
        Get
            Return _insFrequency
        End Get
        Set(ByVal value As String)
            _insFrequency = value
        End Set
    End Property

    Private _lastDayRule As String
    Property lastDayRule As String
        Get
            Return _lastDayRule
        End Get
        Set(ByVal value As String)
            _lastDayRule = value
        End Set
    End Property
End Class
Public Class AADEFl
    Public Sub New()
        Me._fields = New ItemAADEFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemAADEFlModel(StringToFind)
    End Sub

    Private _fields As ItemAADEFlModel
    Public Property Fields() As ItemAADEFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemAADEFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "aadeFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .auditTransactionId.Trim.Length < 1 Then .auditTransactionId = Guid.NewGuid().ToString()
            If .auditTransactionId.Trim.Length < 1 Then .auditTransactionId = System.Guid.NewGuid.ToString()
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With

        With New AADEFl_e
            .Fields = _fields
            If .Insert() = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !"
            End If
        End With

    End Function

    Public Function newCode() As String
        Return New bhtaFramework.bhtaFramework().GetDateTimeSerial()
    End Function

    Public Function Update() As String

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "AADE_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .auditTransactionId.Trim.Length < 1 Then .auditTransactionId = System.Guid.NewGuid.ToString()
            Dim cpin As New FilPin
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With


        With New AADEFl_e
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
        Dim MyMethod As String = "aadefl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New AADEFl_e
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
        Dim MyMethod As String = "AADEfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New AADEFl_e
            .Fields = _fields
            If .Read(id) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ReadZoom(Optional TopFormName As String = "") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New AADEFl_e
            .Fields = _fields
            MData = .ReadZoom(TopFormName)
        End With

        Return MData
    End Function


End Class

Friend Class AADEFl_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemAADEFlModel
    End Sub

    Private _Fields As ItemAADEFlModel
    Property Fields As ItemAADEFlModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemAADEFlModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into auditRecord (auditTransactionId) Values ('" + _Fields.auditTransactionId + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_Fields.auditTransactionId)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update auditRecord Set auditUserId = '" + _Fields.auditUserId.Replace(",", ".") +
                                        "' , auditProtocol = '" + _Fields.auditProtocol.Replace(",", ".") +
                                        "' , auditUserIp = '" + _Fields.auditUserIp.Replace(",", ".") +
                                        "' , auditUnit = '" + _Fields.auditUnit.Replace(",", ".") +
                                        "' , Status = '" + _Fields.Status.id.Replace(",", ".") +
                                        "' , inMctCod = '" + _Fields.inMctCod.Replace(",", ".") +
                                        "' , inSctCod = '" + _Fields.inSctCod.Replace(",", ".") +
                                        "' , extOrg = '" + _Fields.extOrg.Replace(",", ".") +
                                        "' , txtCod = '" + _Fields.txtCod.Replace(",", ".") +
                                        "' , doy = '" + _Fields.doy.Replace(",", ".") +
                                        "' , insFrequency = '" + _Fields.insFrequency.Replace(",", ".") +
                                        "' , lastDayRule = '" + _Fields.lastDayRule.Replace(",", ".") +
                                        "' , fiscalYear = '" + _Fields.fiscalYear.Replace(",", ".") +
                                        "' , synolo = " + _Fields.synolo.ToString().Replace(",", ".") +
                                        " , auditTransactionDate = " + _DataLayer.dateMark + _Fields.auditTransactionDate.ToString("yyyy-MM-dd") + _DataLayer.dateMark +
                                        " , comments = '" + _Fields.comments.Replace(",", ".") +
                                        "' , ypiresiaDescr = '" + _Fields.ypiresiaDescr.Replace(",", ".") +
                                        "' , apofNoEtos = '" + _Fields.apofNoEtos.Replace(",", ".") +
                                        "' , afmYpogr = '" + _Fields.afmYpogr.Replace(",", ".") +
                                        "' , nameYpogr = '" + _Fields.nameYpogr.Replace(",", ".") +
                                        "' Where auditTransactionId = '" + _Fields.auditTransactionId.Replace(",", ".") + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
        Return False
    End Function

    Public Function Delete(id As String) As Boolean
        Dim SQL As String = "Delete From auditRecord Where auditTransactionId = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT auditTransactionId, auditProtocol, auditUnit, auditTransactionDate, auditUserId, auditUserIp, Status, inMctCod, inSctCod, doy, extOrg , txtCod, insFrequency, lastDayRule, fiscalYear, synolo, comments, ypiresiaDescr, apofNoEtos, afmYpogr, nameYpogr FROM auditRecord " +
                            "Where auditTransactionId = '" + id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .auditTransactionId = MyTable.Rows(i).Item("auditTransactionId")
                .auditProtocol = MyTable.Rows(i).Item("auditProtocol")
                .auditUnit = MyTable.Rows(i).Item("auditUnit")
                .auditUserId = MyTable.Rows(i).Item("auditUserId")
                .auditUserIp = MyTable.Rows(i).Item("auditUserIp")
                With New ParPin
                    .Read(ParPin.TypeOfPar.AADEServices, MyTable.Rows(0).Item("Status"))
                    _Fields.Status = .Fields
                End With
                .auditTransactionDate = MyTable.Rows(0).Item("auditTransactionDate")
                .inMctCod = MyTable.Rows(i).Item("inMctCod")
                .inSctCod = MyTable.Rows(i).Item("inSctCod")
                .extOrg = MyTable.Rows(i).Item("extOrg")
                .txtCod = MyTable.Rows(i).Item("txtCod")
                .doy = MyTable.Rows(i).Item("doy")
                .insFrequency = MyTable.Rows(i).Item("insFrequency")
                .lastDayRule = MyTable.Rows(i).Item("lastDayRule")
                .fiscalYear = MyTable.Rows(i).Item("fiscalYear")
                .synolo = MyA.MakeNo(MyTable.Rows(i).Item("synolo"), 2)
                .comments = MyTable.Rows(i).Item("comments")
                .ypiresiaDescr = MyTable.Rows(i).Item("ypiresiaDescr")
                .apofNoEtos = MyTable.Rows(i).Item("apofNoEtos")
                .afmYpogr = MyTable.Rows(i).Item("afmYpogr")
                .nameYpogr = MyTable.Rows(i).Item("nameYpogr")
                .auditdt = MyTable
            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom(FormName As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim SQL As String = "SELECT " + MyA.GetZoomTop(FormName) + " 0 as AA, auditTransactionId as id, auditProtocol, auditUnit, auditTransactionDate, Status, AuditUserId, AuditUserIp, inMctCod, doy, inSctCod, extOrg, txtCod, insFrequency, lastDayRule, fiscalYear, synolo, comments, ypiresiaDescr, apofNoEtos, afmYpogr, nameYpogr  FROM auditRecord Where (" + MyA.WhereFunc(Me._Fields, "auditRecord") + ")"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL + " Order By auditTransactionDate Desc")
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next
        Return MyTable
    End Function

End Class

