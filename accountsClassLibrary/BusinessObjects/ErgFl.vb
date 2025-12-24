Imports accountsClassLibrary
Imports alphaFrameWork
Public Class ItemErgFlModel
    Public Sub New()
        _id = ""
        _Description = ""
        _idPin = New ItemFilPinModel
        _Memo = ""
        _StartDate = Now
        _EndDate = Now
        _Status = New ItemParPinModel
    End Sub

    Public Sub New(StringToFind As String)
        _id = StringToFind
        _Description = StringToFind
        _idPin = New ItemFilPinModel(StringToFind)
        _Memo = StringToFind
        Dim c As New alphaFrameWork.AlphaFramework
        _StartDate = c.MakeDate(StringToFind)
        _EndDate = c.MakeDate(StringToFind)
        _Status = New ItemParPinModel(StringToFind)
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

    Private _Description As String
    Property Description As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _idPin As ItemFilPinModel
    Property idPin As ItemFilPinModel
        Get
            Return _idPin
        End Get
        Set(ByVal value As ItemFilPinModel)
            _idPin = value
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

    Private _StartDate As DateTime
    Property StartDate As DateTime
        Get
            Return _StartDate
        End Get
        Set(ByVal value As DateTime)
            _StartDate = value
        End Set
    End Property

    Private _EndDate As DateTime
    Property EndDate As DateTime
        Get
            Return _EndDate
        End Get
        Set(ByVal value As DateTime)
            _EndDate = value
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

End Class
Public Class ErgFl


    Public Sub New()
        Me._fields = New ItemErgFlModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemErgFlModel(StringToFind)
    End Sub

    Private _fields As ItemErgFlModel
    Public Property Fields() As ItemErgFlModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemErgFlModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "ErgFl_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .id.Trim.Length < 1 Then .id = New ErgFl_e().newId()
            If .id.Trim.Length < 1 Then .id = System.Guid.NewGuid.ToString()
            Dim cpin As New FilPin
            Dim res As String = cpin.Read(_fields.idPin.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στον πίνακα  !"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With

        With New ErgFl_e
            .Fields = _fields
            If .Insert() = True Then
                Return ""
            Else
                Return "Αδύνατη η εισαγωγή της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή πιθανόν και να υπάρχει !"
            End If
        End With

    End Function

    Public Function newCode() As String
        Return New ErgFl_e().newId()
    End Function

    Public Function Update() As String

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "ErgFl_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With _fields
            If .id.Trim.Length < 1 Then .id = System.Guid.NewGuid.ToString()
            Dim cpin As New FilPin
            Dim res As String = cpin.Read(_fields.idPin.id)
            If res.Length > 0 Then Return "Δεν υπάρχει τιμή στον πίνακα !"
            If .Status.id.Trim.Length < 1 Then Return "Δεν υπάρχει status  !"
        End With


        With New ErgFl_e
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
        Dim MyMethod As String = "ergfl_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New ErgFl_e
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
        Dim MyMethod As String = "Ergfl_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New ErgFl_e
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
        With New ErgFl_e
            .Fields = _fields
            MData = .ReadZoom(TopFormName)
        End With

        Return MData
    End Function


End Class

Friend Class ErgFl_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemErgFlModel
    End Sub

    Private _Fields As ItemErgFlModel
    Property Fields As ItemErgFlModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemErgFlModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into ErgFl (id) Values ('" + _Fields.id + "')"
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
        Dim SQL As String = "Update ErgFl Set Description = '" + _Fields.Description.Replace(",", ".") +
                                        "' , IdPin = '" + _Fields.idPin.id.Replace(",", ".") +
                                        "' , [ErgFl].[Memo] = '" + _Fields.Memo.Replace(",", ".") +
                                        "' , Status = '" + _Fields.Status.id +
                                        "' , StartDate = " + _DataLayer.dateMark + _Fields.StartDate.ToString("yyyy-MM-dd") + _DataLayer.dateMark +
                                        ", EndDate = " + _DataLayer.dateMark + _Fields.EndDate.ToString("yyyy-MM-dd") + _DataLayer.dateMark +
                                        " Where Id = '" + _Fields.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete(id As String) As Boolean
        Dim SQL As String = "Delete From ErgFl Where Id = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Description, idPin, ErgFl.[Memo], StartDAte, EndDate, Status FROM ErgFl " +
                            "Where id = '" + id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .id = MyTable.Rows(i).Item("id")
                .Description = MyTable.Rows(i).Item("Description")
                With New FilPin
                    If .Read(MyTable.Rows(i).Item("idPin")).Trim.Length = 0 Then
                        _Fields.idPin = .Fields
                    Else
                        _Fields.idPin.id = MyTable.Rows(i).Item("idPin")
                    End If
                End With
                .Memo = MyTable.Rows(i).Item("Memo")
                With New ParPin
                    .Read(ParPin.TypeOfPar.Status, MyTable.Rows(0).Item("Status"))
                    _Fields.Status = .Fields
                End With
                .StartDate = MyTable.Rows(0).Item("StartDate")
                .EndDate = MyTable.Rows(0).Item("EndDate")
            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom(FormName As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim SQL As String = "SELECT " + MyA.GetZoomTop(FormName) + " 0 as AA, ErgFl.id, ErgFl.Description, ErgFl.StartDAte, ErgFl.EndDate, FilPin.[Name] As idPinDescription, ErgFl.[Memo], ErgFl.Status" +
                            " FROM (ErgFl LEFT JOIN FilPin ON ErgFl.idPin = FilPin.ID) " +
                            "Where (" + MyA.WhereFunc(Me._Fields, "ErgFl") +
                                MyA.WhereFuncF("[filpin].[name]", _Fields.idPin.Name) +
                                MyA.WhereFuncF("[filpin].[id]", _Fields.idPin.id) + ")"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL + " Order By StartDate Desc")
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next
        Return MyTable
    End Function

    Public Function newId() As String
        Dim sql As String = "SELECT MAX(LEN(id)) FROM ErgFl"
        Dim MaxLen As Integer = 0
        Dim Id As String = ""
        Try
            MaxLen = CInt(_DataLayer.ReadDataTable(sql).Rows(0)(0))
            sql = "SELECT MAX(id) FROM ErgFl Where Len(id) = " + CStr(MaxLen)
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

