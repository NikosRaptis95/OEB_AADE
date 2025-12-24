Imports accountsClassLibrary
Imports System.ComponentModel
Imports System.IO

Public Class ItemErgRelModel
    Public Sub New()
        _Id = ""
        _Category = New ItemFilPinModel()
        _KoKi = New ItemFilPinModel()
        _Seira = ""
    End Sub

    Public Sub New(StringToFind As String)
        _Id = StringToFind
        _Category = New ItemFilPinModel(StringToFind)
        _KoKi = New ItemFilPinModel(StringToFind)
        Seira = StringToFind
    End Sub

    Private _Id As String
    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property

    Private _Seira As String
    Public Property Seira() As String
        Get
            Return _Seira
        End Get
        Set(ByVal value As String)
            _Seira = value
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

    Private _KoKi As ItemFilPinModel
    Public Property KoKi() As ItemFilPinModel
        Get
            Return _KoKi
        End Get
        Set(ByVal value As ItemFilPinModel)
            _KoKi = value
        End Set
    End Property

End Class

Public Class ErgRel

    Public Sub New()
        Me._fields = New ItemErgRelModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemErgRelModel(StringToFind)
    End Sub

    Private _fields As ItemErgRelModel
    Public Property Fields() As ItemErgRelModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemErgRelModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************
        If (_fields.Id.Length < 1) Then _fields.Id = System.Guid.NewGuid().ToString()
        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "ErgRel_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New ErgRel_e
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
        Dim MyMethod As String = "EergRel_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New ErgRel_e
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
        Dim MyMethod As String = "ErgRel_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New ErgRel_e
            .Fields = _fields
            If .Delete(id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    'Public Sub DeleteAllRel(CategoryId As String)
    '    Dim dt As DataTable
    '    With New ErgRel_e
    '        .Fields.Category = CategoryId
    '        dt = .ReadZoom()
    '    End With
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        '_fields.Category = dt.Rows(i)("Product")
    '        '_fields.PriceList.id = dt.Rows(i)("PriceList")
    '        'Delete()
    '    Next
    'End Sub

    Public Function Read(id As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "ErgRel_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New ErgRel_e
            .Fields = _fields
            If .Read(id) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ReadZoom(CategoryId As String) As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New ErgRel_e
            .Fields = _fields
            MData = .ReadZoom(CategoryId)
        End With

        Return MData
    End Function

    Public Function ReadZoomKoKi(CategoryId As String) As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New ErgRel_e
            .Fields = _fields
            MData = .ReadZoomKoKi(CategoryId)
        End With

        Return MData
    End Function

End Class


Friend Class ErgRel_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemErgRelModel
    End Sub


    Private _Fields As ItemErgRelModel
    Property Fields As ItemErgRelModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemErgRelModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into ErgRel (Id) Values ('" + _Fields.Id + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_Fields.Id)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update ErgRel Set Category = '" + _Fields.Category.id.ToString.Replace("'", "`") +
                                        "' , KoKi = '" + _Fields.KoKi.id.ToString.Replace("'", "`") +
                                        "' , Seira = '" + _Fields.Seira.ToString.Replace("'", "`") +
                                        "' Where id = '" + _Fields.Id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete(id As String) As Boolean
        Dim SQL As String = "Delete From ErgRel Where Id = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Category, KoKi, Seira FROM ErgRel " +
                            "Where id = '" + id + "'"
        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .Id = MyTable.Rows(i).Item("id")
                With New FilPin
                    If .Read(MyTable.Rows(i).Item("Category")).Trim.Length = 0 Then
                        _Fields.Category = .Fields
                    Else
                        _Fields.Category.id = MyTable.Rows(i).Item("PriceList")
                    End If
                End With
                With New FilPin
                    If .Read(MyTable.Rows(i).Item("KoKi")).Trim.Length = 0 Then
                        _Fields.KoKi = .Fields
                    Else
                        _Fields.KoKi.id = MyTable.Rows(i).Item("PriceList")
                    End If
                End With
                .Seira = MyTable.Rows(i).Item("Seira")
            End With
        Next
        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom(CategoryId As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT  ErgRel.id, ErgRel.Seira , ErgRel.Category, ErgRel.KoKi, FilPin.Name As KoKiDesc  " +
                            " FROM (ErgRel LEFT JOIN FilPin ON ErgRel.KoKi = FilPin.ID) " +
                            "Where Category = '" + CategoryId + "'"

        Return _DataLayer.ReadDataTable(SQL + " Order By Category, Seira, KoKi")
    End Function

    Public Function ReadZoomKoKi(CategoryId As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT  FilPin.id as id, FilPin.Name As Name  " +
                            " FROM (ErgRel LEFT JOIN FilPin ON ErgRel.KoKi = FilPin.ID) " +
                            "Where Category = '" + CategoryId + "'"

        Return _DataLayer.ReadDataTable(SQL + " Order By Category, Seira, KoKi")
    End Function


End Class
