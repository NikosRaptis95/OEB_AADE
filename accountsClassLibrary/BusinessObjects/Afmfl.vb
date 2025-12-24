Imports System.Security.Cryptography
Imports accountsClassLibrary
Imports alphaFrameWork
Public Class ItemAFMFlModel
    Public Sub New()
        _id = ""
        auditRecord = New ItemAADEFlModel()
        _AFM = ""
        _amount = 0
        '_Status = New ItemParPinModel
        _dt = New DataTable
        _SynAFM = ""
        _ansXML = ""
        _sendXML = ""
        _anstext = ""
        _status = ""
        _DateTimeSend = ""
        _Sxol = ""
    End Sub

    Public Sub New(StringToFind As String)
        Dim c As New alphaFrameWork.AlphaFramework
        _id = StringToFind
        _AFM = StringToFind
        _amount = c.MakeNo(StringToFind, 2)
        _auditRecord = New ItemAADEFlModel(StringToFind)
        '_Status = New ItemParPinModel(StringToFind)
        _dt = New DataTable
        _SynAFM = StringToFind
        _ansXML = StringToFind
        _sendXML = StringToFind
        _anstext = StringToFind
        _status = StringToFind
        _DateTimeSend = StringToFind
        _Sxol = StringToFind
    End Sub

    Private _Sxol As String
    Property Sxol As String
        Get
            Return _Sxol
        End Get
        Set(ByVal value As String)
            _Sxol = value
        End Set
    End Property

    Private _DateTimeSend As String
    Property DateTimeSend As String
        Get
            Return _DateTimeSend
        End Get
        Set(ByVal value As String)
            _DateTimeSend = value
        End Set
    End Property

    Private _status As String
    Property status As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
    Private _ansXML As String
    Property ansXML As String
        Get
            Return _ansXML
        End Get
        Set(ByVal value As String)
            _ansXML = value
        End Set
    End Property
    Private _sendXML As String
    Property sendXML As String
        Get
            Return _sendXML
        End Get
        Set(ByVal value As String)
            _sendXML = value
        End Set
    End Property
    Private _anstext As String
    Property anstext As String
        Get
            Return _anstext
        End Get
        Set(ByVal value As String)
            _anstext = value
        End Set
    End Property

    Private _SynAFM As String
    Property SynAFM As String
        Get
            Return _SynAFM
        End Get
        Set(ByVal value As String)
            _SynAFM = value
        End Set
    End Property
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

    Private _AFM As String
    Property AFM As String
        Get
            Return _AFM
        End Get
        Set(ByVal value As String)
            _AFM = value
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


End Class
Public Class AFMFl
    Public Sub New()
        Me._fields = New ItemAFMFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemAFMFlModel(StringToFind)
    End Sub

    Private _fields As ItemAFMFlModel
    Public Property Fields() As ItemAFMFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemAFMFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert(auditTransactionId As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "AFMFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        If Fields.AFM.Trim.Length = 0 Then
            Fields.AFM = Now.ToString("yyyy-MM-dd-HH:mm:ss:fff")
            Dim tmp As New AFMFl_e
            If tmp.Read(Fields.id) > 0 Then
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν περιέχει ΑΦΜ !"
                Exit Function
            End If
        End If


        If Fields.id.Trim.Length > 0 Then
            Dim tmp As New AFMFl_e
            If tmp.Read(Fields.id) > 0 Then
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή υπάρχει (" + Fields.AFM + ")"
                Exit Function
            End If
        Else
            Fields.id = Guid.NewGuid().ToString()
            Fields.auditRecord = New ItemAADEFlModel()
            Fields.auditRecord.auditTransactionId = auditTransactionId
        End If


        If auditTransactionId.Trim.Length = 0 Then
            Return "Δεν υπάρχει auditTranactionId  !"
            Exit Function
        End If

        With New AFMFl_e
            .ReadWithAFM(Fields.AFM, auditTransactionId)
            If .Fields.id.Trim.Length > 0 Then
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !" + vbNewLine + vbNewLine + "Ελέξτε το ΑΦΜ (" + Fields.AFM + ")"
                Exit Function
            End If
        End With

        With New AFMFl_e
            .Fields = _fields
            If .Insert(auditTransactionId) = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !" + vbNewLine + vbNewLine + "Ελέγξτε το ΑΦΜ (" + Fields.AFM + ")"
            End If
        End With

    End Function

    Public Function newCode() As String
        Return New bhtaFramework.bhtaFramework().GetDateTimeSerial()
    End Function

    Public Function Update(auditTransactionId As String) As String

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "AFM_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        If _fields.id.Trim.Length < 1 Then Return "Δεν υπάρχει Κωδικός  !"


        With New AFMFl_e
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
        Dim MyMethod As String = "AFMfl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New AFMFl_e
            .Fields = _fields
            If .Delete(id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Function ReadByAFM(afm As String, auditTransactionId As String) As Boolean
        With New AFMFl_e
            .Fields = _fields
            If .ReadWithAFM(afm, auditTransactionId) > 0 Then
                _fields = .Fields
                Return True
            Else
                Return False
            End If
        End With
    End Function


    Public Function Read(id As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "AFMfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New AFMFl_e
            .Fields = _fields
            If .Read(id) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ReadZoom(Optional id As String = "") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New AFMFl_e
            .Fields = _fields
            MData = .ReadZoom(id)
        End With

        Return MData
    End Function
    Public Function ReadSUM(auditTransactionId As String) As Double
        On Error Resume Next

        With New AFMFl_e
            Return Convert.ToDouble(.ReadSUM(auditTransactionId))
        End With

    End Function
    Public Function UpdateAmount(id As String, s As Double)
        On Error Resume Next
        Read(id)

        With New AFMFl_e
            .Fields = _fields
            .Fields.id = id
            .Fields.amount = s
            Return .Update()
        End With
    End Function

    Public Function UpdateAns()
        On Error Resume Next

        With New AFMFl_e
            .Fields = _fields
            Return .UpdateAns()
        End With
    End Function

End Class

Friend Class AFMFl_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemAFMFlModel
    End Sub

    Private _Fields As ItemAFMFlModel
    Property Fields As ItemAFMFlModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemAFMFlModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert(auditTransactionId As String) As Boolean
        Dim SQL As String = "Insert Into AFMfl (id, auditTransactionId) Values ('" + _Fields.id + "','" + auditTransactionId + "')"
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
        Dim SQL As String = "Update AFMFl Set AFM = '" + _Fields.AFM.Replace(",", ".") +
                                        "' , amount = " + _Fields.amount.ToString().Replace(",", ".") +
                                        " , SynAFM = '" + _Fields.SynAFM.Replace(",", ".") + "'" +
                                        ", AnsXML = '" + _Fields.ansXML.Replace("'", "''") + "'" +
                                        ", SendXML = '" + _Fields.sendXML.Replace("'", "''") + "'" +
                                        ", Sxol = '" + _Fields.Sxol.Replace("'", "''") + "'" +
                                        ", AnsText = '" + _Fields.anstext.Replace("'", "''") + "'" +
                                        ", status = '" + _Fields.status.Replace("'", "''") + "'" +
                                        ", DateTimeSend = '" + _Fields.DateTimeSend.ToString() + "'" +
                                        " Where id = '" + _Fields.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
        Return False
    End Function
    Public Function UpdateAns() As Boolean
        Dim SQL As String = "Update AFMFl Set AnsXML = '" + _Fields.ansXML.Replace("'", "''") + "'" +
                                        ", status = '" + _Fields.status.Replace("'", "''") + "'" +
                                        ", SendXML = '" + _Fields.sendXML.Replace("'", "''") + "'" +
                                        ", AnsText = '" + _Fields.anstext.Replace("'", "''") + "'" +
                                        ", Sxol = '" + _Fields.Sxol.Replace("'", "''") + "'" +
                                        ", DateTimeSend = '" + _Fields.DateTimeSend.ToString() + "'" +
                                        " Where id = '" + _Fields.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
        Return False
    End Function

    Public Function Delete(id As String) As Boolean
        Dim SQL As String = "Delete From AFMFl Where id = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, auditTransactionId, afm, amount, SynAFM, AnsXML, SendXML, AnsText, Sxol, status, DateTimeSend FROM AFMFl " +
                            "Where id = '" + id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .auditRecord.auditTransactionId = MyTable.Rows(i).Item("auditTransactionId")
                .id = MyTable.Rows(i).Item("id")
                .AFM = MyTable.Rows(i).Item("AFM")
                .amount = MyTable.Rows(i).Item("amount")
                .SynAFM = MyTable.Rows(i).Item("SynAFM")
                .ansXML = MyTable.Rows(i).Item("AnsXML")
                .sendXML = MyTable.Rows(i).Item("SendXML")
                .anstext = MyTable.Rows(i).Item("AnsText")
                .status = MyTable.Rows(i).Item("status")
                .Sxol = MyTable.Rows(i).Item("Sxol")
                .DateTimeSend = Convert.ToDateTime(MyTable.Rows(i).Item("DateTimeSend")).ToString("yyyy-MM-dd HH:mm:ss").ToString()
            End With
            Dim aade = New AADEFl()
            aade.Read(MyTable.Rows(i).Item("auditTransactionId"))
            _Fields.auditRecord = aade.Fields
        Next
        _Fields.dt = MyTable

        Return MyTable.Rows.Count
    End Function

    Public Function ReadWithAFM(afm As String, auditTransactionId As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, auditTransactionId, afm, amount, SynAFM, AnsXML, SendXML, AnsText, Sxol, status, DateTimeSend FROM AFMFl " +
                            "Where afm = '" + afm + "' and auditTransactionId = '" + auditTransactionId + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .auditRecord.auditTransactionId = MyTable.Rows(i).Item("auditTransactionId")
                .id = MyTable.Rows(i).Item("id")
                .AFM = MyTable.Rows(i).Item("afm")
                .amount = MyTable.Rows(i).Item("amount")
                .SynAFM = MyTable.Rows(i).Item("SynAFM")
                .ansXML = MyTable.Rows(i).Item("AnsXML")
                .sendXML = MyTable.Rows(i).Item("SendXML")
                .anstext = MyTable.Rows(i).Item("AnsText")
                .status = MyTable.Rows(i).Item("status")
                .Sxol = MyTable.Rows(i).Item("Sxol")
                .DateTimeSend = Convert.ToDateTime(MyTable.Rows(i).Item("DateTimeSend")).ToString("yyyy-MM-dd HH:mm:ss").ToString()
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

        Dim SQL As String = "SELECT 0 as aa, id, auditTransactionId, afm, amount, SynAFM, AnsXML, SendXML, AnsText, status, Sxol, DateTimeSend" +
                            " FROM AFMfl " +
                            "Where auditTransactionId Like '" + id + "%'"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("aa") = count
        Next
        Return MyTable
    End Function

    Public Function ReadSUM(auditTransactionId As String) As Double
        'On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT SUM(amount) AS Synolo FROM AFMfl Where auditTransactionId Like '" + auditTransactionId + "%'"
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Return Convert.ToDouble(MyTable.Rows(0)(0))
    End Function

End Class

