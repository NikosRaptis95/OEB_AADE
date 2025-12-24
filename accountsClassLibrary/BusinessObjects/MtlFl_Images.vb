Imports System.ComponentModel
Imports System.IO

Public Class ItemMtlFl_ImagesModel

    Public Sub New()
        _id = ""
        _Description = ""
        _Picture = Nothing
        _Status = New ItemParPinModel()
        _Type = New ItemParPinModel()
    End Sub

    Public Sub New(StringToFind As String)
        _id = StringToFind
        _Description = StringToFind
        _Picture = Nothing
        _Status = New ItemParPinModel(StringToFind)
        _Type = New ItemParPinModel(StringToFind)
    End Sub

    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _Type As ItemParPinModel
    Public Property Type() As ItemParPinModel
        Get
            Return _Type
        End Get
        Set(ByVal value As ItemParPinModel)
            _Type = value
        End Set
    End Property

    Private _Status As ItemParPinModel
    Public Property Status() As ItemParPinModel
        Get
            Return _Status
        End Get
        Set(ByVal value As ItemParPinModel)
            _Status = value
        End Set
    End Property


    Private _Picture As Byte()
    Public Property Picture() As Byte()
        Get
            Return _Picture
        End Get
        Set(ByVal value As Byte())
            _Picture = value
        End Set
    End Property
End Class


Public Class MtlFl_Images

    Public Sub New()
        Me._fields = New ItemMtlFl_ImagesModel
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemMtlFl_ImagesModel(StringToFind)
    End Sub

    Private _fields As ItemMtlFl_ImagesModel
    Public Property Fields() As ItemMtlFl_ImagesModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemMtlFl_ImagesModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "ItemMtlFl_ImagesModel_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_Images_e
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
        Dim MyMethod As String = "MtlFl_Images_e_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_Images_e
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
        Dim MyMethod As String = "MtlFl_Images_e_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New MtlFl_Images_e
            .Fields = _fields
            If .Delete(_fields.id, _fields.Type.id) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function


    Public Sub DeleteAllImages(idProduct)
        Dim dt As DataTable
        With New MtlFl_Images_e
            .Fields.id = idProduct
            dt = .ReadZoom(TypeOfZoom.defaultZoom, "", "", "", "")
        End With
        For i As Integer = 0 To dt.Rows.Count - 1
            _fields.id = dt.Rows(i)("id")
            _fields.Type.id = dt.Rows(i)("Type")
            Delete()
        Next
    End Sub


    Public Function Read(id As String, Type As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Times_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New MtlFl_Images_e
            .Fields = _fields
            If .Read(id, Type) > 0 Then
                _fields = .Fields
                Return ""
            Else
                Return "Αδύνατη η ανάγνωση ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With

    End Function

    Public Enum TypeOfZoom
        defaultPage
        catalogPage
        defaultZoom
        Sales
        BestSales
    End Enum

    Public Function ReadZoom(Optional DefaultPage As TypeOfZoom = TypeOfZoom.defaultZoom, Optional Category As String = "", Optional Family As String = "", Optional Description As String = "", Optional Timo As String = "") As DataTable
        On Error Resume Next
        Dim MData As DataTable
        With New MtlFl_Images_e
            .Fields = _fields
            MData = .ReadZoom(DefaultPage, Category, Family, Description, Timo)
        End With
        Return MData
    End Function
    Public Function ReadZoomWinPlan(id As String) As DataTable
        On Error Resume Next
        With New MtlFl_Images_e
            Return .ReadZoomWinPlan(id)
        End With
    End Function


End Class


Friend Class MtlFl_Images_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemMtlFl_ImagesModel
    End Sub


    Private _Fields As ItemMtlFl_ImagesModel
    Property Fields As ItemMtlFl_ImagesModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemMtlFl_ImagesModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into MtlFl_Images (id, Type) Values ('" + _Fields.id + "','" + _Fields.Type.id + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_Fields.id, _Fields.Type.id)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update MtlFl_Images Set Description = '" + _Fields.Description.ToString.Replace(",", ".") +
                                        "' , Status = '" + _Fields.Status.id.ToString.Replace(",", ".") +
                                        "' Where id = '" + _Fields.id + "' and Type = '" + _Fields.Type.id + "'"

        If _DataLayer.ExecuteNonQuery(SQL, _Fields.Picture) Then

            ' ***** picture ******
            SQL = "Update MtlFl_Images Set Picture = @img " +
                                  " Where id = '" + _Fields.id + "' and Type = '" + _Fields.Type.id + "'"
            _DataLayer.ExecuteNonQuery(SQL, _Fields.Picture)
            ' ********************

            Return True
        Else
            Return False
        End If
    End Function

    Public Function Delete(id As String, Type As String) As Boolean
        Dim SQL As String = "Delete From MtlFl_Images Where id = '" + id + "' and Type = '" + Type + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String, Type As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Description, Type, Status, Picture FROM MtlFl_Images " +
                            "Where id = '" + id + "' And Type = '" + Type + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .id = MyTable.Rows(i).Item("id")
                .Description = MyTable.Rows(i).Item("Description")
                With New ParPin
                    .Read(ParPin.TypeOfPar.Type, MyTable.Rows(0).Item("Type"))
                    _Fields.Type = .Fields
                    .Read(ParPin.TypeOfPar.Status, MyTable.Rows(0).Item("Status"))
                    _Fields.Status = .Fields
                End With
                .Picture = MyTable.Rows(i).Item("Picture")
            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom(DefaultPage As MtlFl_Images.TypeOfZoom, Category As String, Family As String, Description As String, Timo As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim sql As String

        Select Case DefaultPage
            Case MtlFl_Images.TypeOfZoom.defaultPage
                sql = "SELECT 0 as AA, MtlFl.id As Id, 
                      MtlFl_Images.Picture As Picture, MtlFl_Images.Type 
                      FROM MtlFl LEFT OUTER JOIN MtlFl_Images
                                  On MtlFl.id = MtlFl_Images.id 
                      Where MtlFl.eShop = '1' And MtlFl.ePosition >'00' Order By MtlFl.ePosition, MtlFl.id, MtlFl_Images.Type"
            Case MtlFl_Images.TypeOfZoom.catalogPage
                sql = "SELECT 0 as AA, MtlFl.id As Id, 
                             MtlFl_Images.Picture As Picture, MtlFl_Images.Type, MtlFl.Description As MtlFl_Description
                         FROM MtlFl LEFT OUTER JOIN MtlFl_Images 
                             On MtlFl.id = MtlFl_Images.id   
                         Where MtlFl.eShop = '1' And 
                               MtlFl.Category Like '" + Category + "%' And MtlFl.Family Like '" + Family + "%' And 
                               (MtlFl.Description Like '%" + Description + "%' Or MtlFl.id Like '%" + Description + "%' Or MtlFl.BCodeBox Like '%" + Description + "%')
                         Order By MtlFl.id, MtlFl_Images.Type"
            Case MtlFl_Images.TypeOfZoom.Sales
                sql = "SELECT 0 as AA, MtlFl_Images.id As Id, 
                        MtlFl_Images.Picture As Picture, MtlFl_Images.Type 
                        FROM (MtlFl LEFT OUTER JOIN MtlFl_Images
                        On MtlFl.id = MtlFl_Images.id) 
                        LEFT OUTER JOIN Times 
                        On MtlFl_Images.id = Times.Product And Times.PriceList = '" + Timo + "' 
                        Where MtlFl.eShop = '1' And Times.PEkpt <> 0 Order By MtlFl.id, MtlFl_Images.Type"
            Case MtlFl_Images.TypeOfZoom.BestSales
                sql = "SELECT TOP (12) 0 AS AA, MtlFl_Images.Id, MtlFl_Images.Description, MtlFl_Images.Type, MtlFl_Images.Status, MtlFl_Images.Picture, MtlFl_Images.Type
                            FROM MtlFl_Images RIGHT OUTER JOIN
                            (SELECT MtlFl_Images_1.Id FROM MtlFl_Images AS MtlFl_Images_1 LEFT OUTER JOIN
                            Ti1Fl ON MtlFl_Images_1.Id = Ti1Fl.MtlId AND Ti1Fl.KoKiTim = '100000'
                            GROUP BY MtlFl_Images_1.Id
                            HAVING (ISNULL(SUM(dbo.Ti1Fl.Quantity), 0) > 0)) AS derivedtbl_1 ON MtlFl_Images.Id = derivedtbl_1.Id"
            Case Else
                sql = "SELECT  0 as AA, MtlFl_Images.id, 
                                       MtlFl_Images.Description, 
                                       MtlFl_Images.Type, 
                                       MtlFl_Images.Status, 
                                       MtlFl_Images.Picture, 
                                       MtlFl.Description As MtlFl_Description 
                      FROM (MtlFl_Images LEFT JOIN MtlFl On MtlFl.id = MtlFl_Images.id) 
                      Where MtlFl_Images.id = '" + _Fields.id + "' Order By MtlFl.id, MtlFl_Images.Type"
        End Select

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(sql)
        'Dim i As Integer = 0
        'Dim count As Integer = 0
        'For i = 1 To MyTable.Rows.Count
        '    MyTable.Rows(i)("AA") = i
        'Next
        Return MyTable
    End Function


    Public Function ReadZoomWinPlan(id As String) As DataTable
        On Error Resume Next
        Dim sql As String = "SELECT       
                                          CMtlMtP AS Id, 
                         'small picture' AS Description, 
                                        AAAAMtP AS Type, 
                                          '1' AS Status, 
                                      PictMtP AS Picture
                                    FROM Adv_MtPFl Where CMtlMtp = '" + id + "'"

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

        Return _DataLayer.ReadDataTable(sql, CS, DE)

    End Function

End Class

