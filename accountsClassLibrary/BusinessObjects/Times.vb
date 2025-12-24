Imports System.ComponentModel
Imports System.IO

Public Class ItemTimesModel
    Public Sub New()
        _PEkpt = 0
        _Price = 0
        _PriceList = New ItemFilPinModel
        _Product = ""
    End Sub

    Public Sub New(StringToFind As String)
        _PEkpt = 0
        _Price = 0
        _PriceList = New ItemFilPinModel(StringToFind)
        _Product = StringToFind
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

    Private _PriceList As ItemFilPinModel
    Public Property PriceList() As ItemFilPinModel
        Get
            Return _PriceList
        End Get
        Set(ByVal value As ItemFilPinModel)
            _PriceList = value
        End Set
    End Property

    Private _PEkpt As Double
    Public Property PEkpt() As Double
        Get
            Return _PEkpt
        End Get
        Set(ByVal value As Double)
            _PEkpt = value
        End Set
    End Property

    Private _Price As Double
    Public Property Price() As Double
        Get
            Return _Price
        End Get
        Set(ByVal value As Double)
            _Price = value
        End Set
    End Property

End Class

Public Class Times

    Public Sub New()
        Me._fields = New ItemTimesModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemTimesModel(StringToFind)
    End Sub

    Private _fields As ItemTimesModel
    Public Property Fields() As ItemTimesModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemTimesModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Times_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Times_e
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
        Dim MyMethod As String = "Times_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Times_e
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
        Dim MyMethod As String = "Times_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New Times_e
            .Fields = _fields
            If .Delete(_fields.Product, _fields.PriceList.id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Sub DeleteAllPrices(ProductId As String)
        Dim dt As DataTable
        With New Times_e
            .Fields.Product = ProductId
            dt = .ReadZoom()
        End With
        For i As Integer = 0 To dt.Rows.Count - 1
            _fields.Product = dt.Rows(i)("Product")
            _fields.PriceList.id = dt.Rows(i)("PriceList")
            Delete()
        Next
    End Sub

    Public Sub InsertAllPrices(ProductId As String)
        Dim dt As DataTable
        Dim f = New FilPin
        dt = f.ReadZoomGeneral(FilPin.TypeOfPin.PriceList)
        For i As Integer = 0 To dt.Rows.Count - 1
            _fields.Product = ProductId
            _fields.PriceList.id = dt.Rows(i)("id")
            _fields.Price = 0
            _fields.PEkpt = 0
            Insert()
        Next
    End Sub

    Public Function Read(id As String, pricelist As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Times_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Times_e
            .Fields = _fields
            If .Read(id, pricelist) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Function ReadZoom() As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New Times_e
            .Fields = _fields
            MData = .ReadZoom()
        End With

        Return MData
    End Function

    Public Function ReadZoomWinPlan(id As String) As DataTable
        With New Times_e
            Return .ReadZoomWinPlan(id)
        End With
    End Function

End Class


Friend Class Times_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemTimesModel
    End Sub


    Private _Fields As ItemTimesModel
    Property Fields As ItemTimesModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemTimesModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into Times (Product, PriceList) Values ('" + _Fields.Product + "','" + _Fields.PriceList.id + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_Fields.Product, _Fields.PriceList.id)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update Times Set PEkpt = " + _Fields.PEkpt.ToString.Replace(",", ".") +
                                        " , Price = " + _Fields.Price.ToString.Replace(",", ".") +
                                        " Where Product = '" + _Fields.Product + "' and PriceList = '" + _Fields.PriceList.id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete(Product As String, PriceList As String) As Boolean
        Dim SQL As String = "Delete From Times Where Product = '" + Product + "' and PriceList = '" + PriceList + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(Product As String, PriceList As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT Product, PriceList, PEkpt, Price FROM Times " +
                            "Where Product = '" + Product + "' And PriceList = '" + PriceList + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .Product = MyTable.Rows(i).Item("Product")
                With New FilPin
                    If .Read(MyTable.Rows(i).Item("PriceList")).Trim.Length = 0 Then
                        _Fields.PriceList = .Fields
                    Else
                        _Fields.PriceList.id = MyTable.Rows(i).Item("PriceList")
                    End If
                End With
                .PEkpt = MyTable.Rows(i).Item("PEkpt")
                .Price = MyTable.Rows(i).Item("Price")
            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom() As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        ' Dim SQL As String = "SELECT  0 as AA, Times.Product, Times.PriceList, Times.PEkpt,Times.Price, FilPin.[Name] As PriceListDescription" +
        Dim SQL As String = "SELECT  0 as AA, Times.Product, Times.PriceList, Times.PEkpt,Times.Price, FilPin.[Name] As PriceListDescription" +
                            " FROM (Times LEFT JOIN FilPin ON Times.PriceList = FilPin.ID) " +
                            "Where (" + MyA.WhereFunc(Me._Fields, "Times") +
                                MyA.WhereFuncF("[filpin].[name]", _Fields.PriceList.Name) +
                                MyA.WhereFuncF("Times.PriceList", _Fields.PriceList.id) + ")"
        SQL += " Order By Times.Product, Times.PriceList"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Dim i As Integer = 0
        Dim count As Integer = 0
        For i = 0 To MyTable.Rows.Count - 1
            count += 1
            MyTable.Rows(i)("AA") = count
        Next
        Return MyTable
    End Function

    Public Function ReadZoomWinPlan(id As String) As DataTable
        On Error Resume Next
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

        Dim sql As String = "SELECT ISNULL(CMtlTka,N'') AS Product, REPLACE(ISNULL(CTimTKa,N''), 'ΤΙ', 'ti') AS PriceList, 
                                         EkTiTKa AS PEkpt, ISNULL(ROUND(CASE LianTKa WHEN 1 THEN LTimoTka ELSE TimoTka END, 2),0) AS Price
                           FROM Adv_TKaView Where ISNULL(CMtlTka,N'') = '" + id + "'"

        Return _DataLayer.ReadDataTable(sql, CS, DE)

    End Function

End Class
