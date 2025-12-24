Imports System.Security.Cryptography
Imports accountsClassLibrary
Imports alphaFrameWork
Public Class ItemKAEFlModel
    Public Sub New()
        _id = ""
        auditRecord = New ItemAADEFlModel()
        _Kae = ""
        _amount = 0
        _dt = New DataTable
        '_Status = New ItemParPinModel
    End Sub

    Public Sub New(StringToFind As String)
        Dim c As New alphaFrameWork.AlphaFramework
        _id = StringToFind
        _Kae = StringToFind
        _amount = c.MakeNo(StringToFind, 2)
        _auditRecord = New ItemAADEFlModel(StringToFind)
        _dt = New DataTable
        '_Status = New ItemParPinModel(StringToFind)
    End Sub
    Private _dt As DataTable
    Property dt As DataTable
        Get
            Return _dt
        End Get
        Set(ByVal value As DataTable)
            _dt = value
        End Set
    End Property

    Private _auditRecord As ItemAADEFlModel
    Property auditRecord As ItemAADEFlModel
        Get
            Return _auditRecord
        End Get
        Set(ByVal value As ItemAADEFlModel)
            _auditRecord = value
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

    Private _Kae As String
    Property Kae As String
        Get
            Return _Kae
        End Get
        Set(ByVal value As String)
            _Kae = value
        End Set
    End Property

    Private _amount As Double
    Property amount As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property

    'Private _Status As ItemParPinModel
    'Property Status As ItemParPinModel
    '    Get
    '        Return _Status
    '    End Get
    '    Set(ByVal value As ItemParPinModel)
    '        _Status = value
    '    End Set
    'End Property

End Class
Public Class KAEFl
    Public Sub New()
        Me._fields = New ItemKAEFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemKAEFlModel(StringToFind)
    End Sub

    Private _fields As ItemKAEFlModel
    Public Property Fields() As ItemKAEFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKAEFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert(auditTransactionId As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "KAEfl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        If Fields.id.Trim.Length > 0 Then
            Dim tmp As New KAEFl_e
            If tmp.Read(Fields.id) > 0 Then
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !"
                Exit Function
            End If
        Else
            Fields.id = Guid.NewGuid().ToString()
            Fields.auditRecord = New ItemAADEFlModel()
            Fields.auditRecord.auditTransactionId = auditTransactionId
        End If

        With New KAEFl_e
            .Fields = _fields
            If .Insert(auditTransactionId) = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !"
            End If
        End With

    End Function

    Public Function newCode() As String
        Return New bhtaFramework.bhtaFramework().GetDateTimeSerial()
    End Function

    Public Function Update(auditTransactionId As String) As String

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "AADE_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        If _fields.id.Trim.Length < 1 Then Return "Δεν υπάρχει Κωδικός  !"


        With New KAEFl_e
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
        Dim MyMethod As String = "KAEfl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New KAEFl_e
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
        Dim MyMethod As String = "KAEfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New KAEFl_e
            .Fields = _fields
            If .Read(id) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ReadFromKae(kae As String, auditTransactionId As String) As Boolean

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "KAEfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If
        Dim res As Boolean = False
        With New KAEFl_e
            .Fields = _fields
            If .ReadFromKae(kae, auditTransactionId) > 0 Then
                _fields = .Fields
                Return True
            Else
                'Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
                Return False
            End If
        End With

    End Function


    Public Function ReadZoom(Optional id As String = "") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New KAEFl_e
            .Fields = _fields
            MData = .ReadZoom(id)
        End With

        Return MData
    End Function
    Public Function ReadZoomCombo(Optional id As String = "") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New KAEFl_e
            .Fields = _fields
            MData = .ReadZoomCombo(id)
        End With

        Return MData
    End Function


End Class

Friend Class KAEFl_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemKAEFlModel
    End Sub

    Private _Fields As ItemKAEFlModel
    Property Fields As ItemKAEFlModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemKAEFlModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert(auditTransactionId As String) As Boolean
        Dim SQL As String = "Insert Into Kaefl (id, auditTransactionId) Values ('" + _Fields.id + "','" + auditTransactionId + "')"
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
        Dim SQL As String = "Update KaeFl Set Kae = '" + _Fields.Kae.Replace(",", ".") +
                                        "' , amount = " + _Fields.amount.ToString().Replace(",", ".") +
                                        " Where id = '" + _Fields.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
        Return False
    End Function

    Public Function Delete(id As String) As Boolean
        Dim SQL As String = "Delete From KaeFl Where id = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function ReadFromKae(kae As String, auditTransactionId As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, auditTransactionId, Kae, amount FROM KaeFl " +
                            "Where Kae = '" + kae + "' And auditTransactionId = '" + auditTransactionId + "'"
        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .auditRecord.auditTransactionId = MyTable.Rows(i).Item("auditTransactionId")
                .id = MyTable.Rows(i).Item("id")
                .Kae = MyTable.Rows(i).Item("Kae")
                .amount = MyTable.Rows(i).Item("amount")
            End With
            Dim aade = New AADEFl()
            aade.Read(MyTable.Rows(i).Item("auditTransactionId"))
            _Fields.auditRecord = aade.Fields
        Next
        _Fields.dt = MyTable
        Return MyTable.Rows.Count
    End Function

    Public Function Read(id As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, auditTransactionId, Kae, amount FROM KaeFl " +
                            "Where id = '" + id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .auditRecord.auditTransactionId = MyTable.Rows(i).Item("auditTransactionId")
                .id = MyTable.Rows(i).Item("id")
                .Kae = MyTable.Rows(i).Item("Kae")
                .amount = MyTable.Rows(i).Item("amount")
            End With
            Dim aade = New AADEFl()
            aade.Read(MyTable.Rows(i).Item("auditTransactionId"))
            _Fields.auditRecord = aade.Fields
        Next
        _Fields.dt = MyTable

        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom(id As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim SQL As String = "SELECT 0 as AA, id, auditTransactionId, kae, amount" +
                            " FROM KAEfl " +
                            "Where auditTransactionId Like '" + id + "%'"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next
        Return MyTable
    End Function

    Public Function ReadZoomCombo(id As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim SQL As String = "SELECT id, Kae As Name" +
                            " FROM KAEfl " +
                            "Where auditTransactionId Like '" + id + "%'"
        Return _DataLayer.ReadDataTable(SQL)
    End Function


End Class

