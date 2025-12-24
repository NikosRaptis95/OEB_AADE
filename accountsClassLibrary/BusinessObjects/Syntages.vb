Imports System.ComponentModel
Imports System.IO

Public Class ItemSyntModel
    Public Sub New()
        _Quantity = 0
        _id = ""
        _Product = ""
    End Sub

    Public Sub New(StringToFind As String)
        _Quantity = 0
        _Product = StringToFind
        _id = StringToFind
    End Sub

    Private _Product As String
    Public Property Product() As String
        Get
            Return _Product
        End Get
        Set(ByVal value As String)
            _Product = value
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


    Private _Quantity As Double
    Public Property Quantity() As Double
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Double)
            _Quantity = value
        End Set
    End Property

End Class

Public Class Syntages

    Public Sub New()
        Me._fields = New ItemSyntModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemSyntModel(StringToFind)
    End Sub

    Private _fields As ItemSyntModel
    Public Property Fields() As ItemSyntModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemSyntModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Synt_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Syntages_e
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
        Dim MyMethod As String = "Synt_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Syntages_e
            .Fields = _fields
            If .Update() = True Then
                Return ""
            Else
                Return "Αδύνατη η ενημέρωση της εγγραφής" + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function Delete() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Synt_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New Syntages_e
            .Fields = _fields
            If .Delete(_fields.Product, _fields.id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Sub DeleteAllItems(ProductId As String)
        Dim dt As DataTable
        With New Syntages_e
            .Fields.id = ProductId
            dt = .ReadZoom(ProductId)
        End With
        For i As Integer = 0 To dt.Rows.Count - 1
            _fields.Product = dt.Rows(i)("product")
            _fields.id = dt.Rows(i)("id")
            Delete()
        Next
    End Sub


    Public Function Read(id As String, Product As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Synt_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Syntages_e
            .Fields = _fields
            If .Read(id, Product) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function



    Public Function ReadZoom(id As String) As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New Syntages_e
            .Fields = _fields
            MData = .ReadZoom(id)
        End With

        Return MData
    End Function

End Class


Friend Class Syntages_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemSyntModel
    End Sub


    Private _Fields As ItemSyntModel
    Property Fields As ItemSyntModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemSyntModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into Syntages (id, Product) Values ('" + _Fields.id + "','" + _Fields.Product + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_Fields.id, _Fields.Product)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update Syntages Set Quantity = " + _Fields.Quantity.ToString.Replace(",", ".") +
                                        " Where id = '" + _Fields.id + "' and Product = '" + _Fields.Product + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete(Product As String, id As String) As Boolean
        Dim SQL As String = "Delete From Syntages Where id = '" + id + "' and Product = '" + Product + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String, Product As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Product, Quantity FROM Syntages " +
                            "Where Product = '" + Product + "' And id = '" + id + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .Product = MyTable.Rows(i).Item("Product")
                .id = MyTable.Rows(i).Item("id")
                .Quantity = MyTable.Rows(i).Item("Quantity")
            End With
        Next

        Return MyTable.Rows.Count
    End Function


    Public Function ReadZoom(id As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "Select 0 AS AA,  dbo.Syntages.Id, dbo.Syntages.Product, dbo.Syntages.Quantity, dbo.MtlFl.Description AS ProductDescription FROM Syntages LEFT OUTER JOIN MtlFl ON MtlFl.id = Syntages.Product "
        SQL += "Where Syntages.id = '" + id + "'"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next


        Return MyTable
    End Function



End Class
