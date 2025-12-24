Imports System.Security.Cryptography
Imports accountsClassLibrary
Imports alphaFrameWork
Public Class ItemAFMKINModel
    Public Sub New()
        _id = ""

        _KAEid = New ItemKAEFlModel()
        _AFMid = New ItemAFMFlModel()
        _dueDate = Now
        _ammount = 0
        '_Status = New ItemParPinModel
        _dt = New DataTable
    End Sub

    Public Sub New(StringToFind As String)
        Dim c As New alphaFrameWork.AlphaFramework
        _id = StringToFind

        _AFMid = New ItemAFMFlModel(StringToFind)
        _ammount = c.MakeNo(StringToFind, 2)
        _KAEid = New ItemKAEFlModel(StringToFind)
        '_Status = New ItemParPinModel(StringToFind)
        _dt = New DataTable
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
    Private _KAEid As ItemKAEFlModel
    Property KAEid As ItemKAEFlModel
        Get
            Return _KAEid
        End Get
        Set(ByVal value As ItemKAEFlModel)
            _KAEid = value
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

    Private _AFMid As ItemAFMFlModel
    Property AFMid As ItemAFMFlModel
        Get
            Return _AFMid
        End Get
        Set(ByVal value As ItemAFMFlModel)
            _AFMid = value
        End Set
    End Property

    Private _ammount As Double
    Property ammount As Double
        Get
            Return _ammount
        End Get
        Set(ByVal value As Double)
            _ammount = value
        End Set
    End Property

    Private _dueDate As Date
    Property dueDate As Date
        Get
            Return _dueDate
        End Get
        Set(ByVal value As Date)
            _dueDate = value
        End Set
    End Property

End Class
Public Class AFMKIN
    Public Sub New()
        Me._fields = New ItemAFMKINModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemAFMKINModel(StringToFind)
    End Sub

    Private _fields As ItemAFMKINModel
    Public Property Fields() As ItemAFMKINModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemAFMKINModel)
            _fields = value
        End Set
    End Property

    Public Function Insert(AFMId As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "AFMFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        If Fields.id.Trim.Length > 0 Then
            Dim tmp As New AFMKIN_e
            Dim idx As Integer = tmp.Read(Fields.id)
            If idx > 0 Then
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !"
                Exit Function
            End If
        Else
            Fields.id = Guid.NewGuid().ToString()
            Fields.AFMid = New ItemAFMFlModel()
            Fields.AFMid.id = AFMId
        End If

        With New AFMKIN_e
            .Fields = _fields
            If .Insert(AFMId) = True Then
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
        Dim MyMethod As String = "AFM_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        If _fields.id.Trim.Length < 1 Then Return "Δεν υπάρχει Κωδικός  !"


        With New AFMKIN_e
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

        With New AFMKIN_e
            .Fields = _fields
            If .Delete(id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function
    Public Function DeleteFromAFM(AFMid As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "AFMfl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New AFMKIN_e
            .Fields = _fields
            If .DeleteFromAFM(AFMid) = True Then
                Return ""
            Else
                Return "Αδύνατη η ενεργεια διαγραφής ! " + vbNewLine + vbNewLine + "Αυτή η διερασια παρουσίασε πρόβλημα !"
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

        With New AFMKIN_e
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
        With New AFMKIN_e
            .Fields = _fields
            MData = .ReadZoom(id)
        End With

        Return MData
    End Function
    Public Function ReadSUMAFM(AFMid As String) As Double
        On Error Resume Next

        With New AFMKIN_e
            Return Convert.ToDouble(.ReadSUMAFM(AFMid))
        End With

    End Function
    Public Function ReadSUMΚΑΕ(ΚΑΕid As String) As Double
        On Error Resume Next

        With New AFMKIN_e
            Return Convert.ToDouble(.ReadSUMKAE(ΚΑΕid))
        End With

    End Function

End Class

Friend Class AFMKIN_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemAFMKINModel()
    End Sub

    Private _Fields As ItemAFMKINModel
    Property Fields As ItemAFMKINModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemAFMKINModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert(AFMId As String) As Boolean
        Dim SQL As String = "Insert Into AFMKIN (id, AFMId) Values ('" + _Fields.id + "','" + AFMId + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            _Fields.AFMid.id = AFMId
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
        Dim SQL As String = "Update AFMKIN Set AFMid = '" + _Fields.AFMid.id.Replace(",", ".") +
                                        "', KAEid = '" + _Fields.KAEid.id.Replace(",", ".") +
                                        "' , ammount = " + _Fields.ammount.ToString().Replace(",", ".") +
                                        " , dueDate = " + _DataLayer.dateMark + _Fields.dueDate.ToString("yyyy-MM-dd") + _DataLayer.dateMark +
                                        " Where id = '" + _Fields.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
        Return False
    End Function

    Public Function Delete(id As String) As Boolean
        Dim SQL As String = "Delete From AFMKIN Where id = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function
    Public Function DeleteFromAFM(AFMid As String) As Boolean
        Dim SQL As String = "Delete From AFMKIN Where AFMid = '" + AFMid + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function
    Public Function Read(id As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, AFMid, dueDate, ammount, KAEid FROM AFMKIN " +
                            "Where id = '" + id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .id = MyTable.Rows(i).Item("id")
                .AFMid.id = MyTable.Rows(i).Item("AFMid")
                .KAEid.id = MyTable.Rows(i).Item("KAEid")
                .ammount = MyTable.Rows(i).Item("ammount")
                .dueDate = MyTable.Rows(i).Item("dueDate")
            End With

            Dim AFM = New AFMFl()
            AFM.Read(MyTable.Rows(i).Item("AFMid"))
            _Fields.AFMid = AFM.Fields
            Dim KAE = New KAEFl()
            KAE.Read(MyTable.Rows(i).Item("KAEid"))
            _Fields.KAEid = KAE.Fields
        Next

        _Fields.dt = MyTable
        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom(id As String) As DataTable
        'On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT 0 AS AA, id, AFMid, dueDate, ammount, (SELECT Kae FROM KAEfl WHERE (id = AFMKin.KAEid)) AS KAE FROM AFMKin Where AFMId Like '" + id + "%' order by dueDate"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next
        Return MyTable
    End Function
    Public Function ReadSUMAFM(AFMid As String) As Double
        'On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT SUM(ammount) AS SYNOLO FROM AFMKin Where AFMId Like '" + AFMid + "%'"
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Return Convert.ToDouble(MyTable.Rows(0)(0))
    End Function

    Public Function ReadSUMKAE(KAEid As String) As Double
        'On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT SUM(dbo.AFMKin.ammount) AS Synolo FROM AFMKin Where KAEid Like '" + KAEid + "%'"
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Return Convert.ToDouble(MyTable.Rows(0)(0))
    End Function


End Class

