Imports System.ComponentModel
Imports System.IO

Public Class ItemYpoloipaModel
    Public Sub New()
        _id = ""
        _Description1 = ""
        _Description2 = ""
        _Description3 = ""
        _Ypoloipo = 0
        _id1 = ""
        _id2 = ""
        _id3 = ""
        _Type = ""
    End Sub

    Public Sub New(StringToFind As String)
        _id = StringToFind
        _Description1 = StringToFind
        _Description2 = StringToFind
        _Description3 = StringToFind
        _Ypoloipo = 0
        _id1 = StringToFind
        _id2 = StringToFind
        _id3 = StringToFind
        _Type = StringToFind
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

    Private _Description1 As String
    Public Property Description1() As String
        Get
            Return _Description1
        End Get
        Set(ByVal value As String)
            _Description1 = value
        End Set
    End Property

    Private _Description2 As String
    Public Property Description2() As String
        Get
            Return _Description2
        End Get
        Set(ByVal value As String)
            _Description2 = value
        End Set
    End Property

    Private _Description3 As String
    Public Property Description3() As String
        Get
            Return _Description3
        End Get
        Set(ByVal value As String)
            _Description3 = value
        End Set
    End Property

    Private _Ypoloipo As Double
    Public Property Ypoloipo() As Double
        Get
            Return _Ypoloipo
        End Get
        Set(ByVal value As Double)
            _Ypoloipo = value
        End Set
    End Property

    Private _id1 As String
    Public Property id1() As String
        Get
            Return _id1
        End Get
        Set(ByVal value As String)
            _id1 = value
        End Set
    End Property

    Private _id2 As String
    Public Property id2() As String
        Get
            Return _id2
        End Get
        Set(ByVal value As String)
            _id2 = value
        End Set
    End Property

    Private _id3 As String
    Public Property id3() As String
        Get
            Return _id3
        End Get
        Set(ByVal value As String)
            _id3 = value
        End Set
    End Property

    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
End Class

Public Class Ypoloipa

    Public Sub New()
        Me._fields = New ItemYpoloipaModel()
    End Sub

    Public Sub New(StringToFind As String)
        Me._fields = New ItemYpoloipaModel(StringToFind)
    End Sub

    Private _fields As ItemYpoloipaModel
    Public Property Fields() As ItemYpoloipaModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemYpoloipaModel)
            _fields = value
        End Set
    End Property

    Public Function Insert() As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Ypoloipa_Insert"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Ypoloipa_e
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
        Dim MyMethod As String = "Ypoloipa_Update"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Ypoloipa_e
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
        Dim MyMethod As String = "Ypoloipa_Delete"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If


        With New Ypoloipa_e
            .Fields = _fields
            If .Delete(_fields.id, _fields.id1, _fields.id2) = True Then
                Return ""
            Else
                Return "Αδύνατη η διαγραφή ! " + vbNewLine + vbNewLine + "Αυτή η εγγραφή δεν υπάρχει η διαγράφηκε !"
            End If
        End With
    End Function

    Public Sub DeleteAllYpoloipa(idProduct)
        With New Ypoloipa_e
            .DeleteAll(idProduct)
        End With
    End Sub

    Public Function Read(id As String, id1 As String, id2 As String, id3 As String) As String

        ' Write your rules here **********************

        Dim myc As New alphaFrameWork.AlphaFramework
        Dim MyMethod As String = "Ypoloipa_Read"
        If myc.customizationControl(MyMethod) = False Then
            Return "Η εργασία απορρίφθηκε απο το customization -> control -> " + MyMethod + " !!"
            Exit Function
        End If

        With New Ypoloipa_e
            .Fields = _fields
            If .Read(id, id1, id2, id3) > 0 Then
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
        With New Ypoloipa_e
            .Fields = _fields
            MData = .ReadZoom()
        End With

        Return MData
    End Function

    Public Function ReadZoomDistinctId(id As String) As DataTable
        Return New Ypoloipa_e().ReadZoomDistinctId(id)
    End Function

    Public Function ReadZoomDistinctId1(id As String, id1 As String) As DataTable
        Return New Ypoloipa_e().ReadZoomDistinctId1(id, id1)
    End Function
    Public Function ReadZoomDistinctId2(id As String, id1 As String, id2 As String) As DataTable
        Return New Ypoloipa_e().ReadZoomDistinctId2(id, id1, id2)
    End Function

    Public Function ReadYpoloipo(id As String) As Double
        With New Ypoloipa_e
            Return .ReadYpoloipo(id)
        End With
    End Function

    Public Function ReadYpoloipoJust(id As String, id1 As String, id2 As String, id3 As String) As Double
        Dim r As Double = 0
        With New Ypoloipa_e
            r = .ReadYpoloipoJust(id, id1, id2, id3)
            _fields.Ypoloipo = .Fields.Ypoloipo
            _fields.Type = .Fields.Type
        End With
        Return r
    End Function

    Public Function ReadZoomWinPlan(id As String) As DataTable
        On Error Resume Next
        With New Ypoloipa_e
            Return .ReadZoomWinPlan(id)
        End With
    End Function

End Class


Friend Class Ypoloipa_e
    Private _DataLayer As New alphaFrameWork.datalayer
    Public Sub New()
        _Fields = New ItemYpoloipaModel
    End Sub


    Private _Fields As ItemYpoloipaModel
    Property Fields As ItemYpoloipaModel
        Get
            Return _Fields
        End Get
        Set(ByVal value As ItemYpoloipaModel)
            _Fields = value
        End Set
    End Property

    Public Function Insert() As Boolean
        Dim SQL As String = "Insert Into Ypoloipa (id,id1,id2,id3) Values ('" + _Fields.id + "','" + _Fields.id1 + "','" + _Fields.id2 + "','" + _Fields.id3 + "')"
        If _DataLayer.ExecuteNonQuery(SQL) = True Then
            If Update() Then
                Return True
            Else
                Delete(_Fields.id, _Fields.id1, _Fields.id2)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        Dim SQL As String = "Update Ypoloipa Set Description1 = '" + _Fields.Description1.ToString.Replace(",", ".") +
                                        "' , Description2 = '" + _Fields.Description2.ToString.Replace(",", ".") +
                                        "' , Description3 = '" + _Fields.Description3.ToString.Replace(",", ".") +
                                        "' , Type = '" + _Fields.Type.ToString.Replace(",", ".") +
                                        "' , id1 = '" + _Fields.id1.ToString.Replace(",", ".") +
                                        "' , id2 = '" + _Fields.id2.ToString.Replace(",", ".") +
                                        "' , id3 = '" + _Fields.id3.ToString.Replace(",", ".") +
                                        "' , Ypoloipo = " + _Fields.Ypoloipo.ToString.Replace(",", ".") +
                                        " Where id = '" + _Fields.id + "' And id1 = '" + _Fields.id1 + "' And id2 = '" + _Fields.id2 + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Delete(id As String, id1 As String, id2 As String) As Boolean
        Dim SQL As String = "Delete From Ypoloipa Where id = '" + id + "' And id1 = '" + id1 + "' And id2 = '" + id2 + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function DeleteAll(id As String) As Boolean
        Dim SQL As String = "Delete From Ypoloipa Where id = '" + id + "'"
        Return _DataLayer.ExecuteNonQuery(SQL)
    End Function

    Public Function Read(id As String, id1 As String, id2 As String, id3 As String) As Integer
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT id, Description1, Description2, Description3, Ypoloipo, id1, id2, id3, Type FROM Ypoloipa " +
                            "Where id = '" + id + "' And id1 = '" + id1 + "' And id2 = '" + id2 + "' And id3 = '" + id3 + "'"

        Dim MyTable As New DataTable
        MyTable = _DataLayer.ReadDataTable(SQL)

        Dim i As Integer
        For i = 0 To MyTable.Rows.Count - 1
            With _Fields
                .id = MyTable.Rows(i).Item("id")
                .Description1 = MyTable.Rows(i).Item("Description1")
                .Description2 = MyTable.Rows(i).Item("Description2")
                .Description3 = MyTable.Rows(i).Item("Description3")
                .Ypoloipo = MyTable.Rows(i).Item("Ypoloipo")
                .id1 = MyTable.Rows(i).Item("id1")
                .id2 = MyTable.Rows(i).Item("id2")
                .id3 = MyTable.Rows(i).Item("id3")
                .Type = MyTable.Rows(i).Item("Type")
            End With
        Next

        Return MyTable.Rows.Count
    End Function

    Public Function ReadZoom() As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework

        Dim SQL As String = "SELECT  0 as AA, Id, ISNULL(Description1, N'') AS Description1, ISNULL(Description2, N'') AS Description2, ISNULL(Description3, N'') AS Description3, Ypoloipo, ISNULL(Id1, N'') AS Id1, ISNULL(Id2, N'') AS Id2, ISNULL(Id3, N'') AS Id3, ISNULL(Type, N'') AS Type " +
                            "FROM Ypoloipa " +
                            "Where (" + MyA.WhereFunc(Me._Fields, "Ypoloipa") + ")"

        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL + " Order By Description1, Description2, Description3")
        'Dim i As Integer = 0
        'Dim count As Integer = 0
        'For i = 0 To MyTable.Rows.Count - 1
        '    count += 1
        '    MyTable.Rows(i)("AA") = count
        'Next
        Return MyTable
    End Function

    Public Function ReadZoomDistinctId(id As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT Distinct ISNULL(Description1, N'') AS Description, id1 FROM Ypoloipa Where id = '" + id + "' Order By Description"
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Return MyTable
    End Function

    Public Function ReadZoomDistinctId1(id As String, id1 As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT Distinct ISNULL(Description2, N'') AS Description, id2 FROM Ypoloipa Where id = '" + id + "' And id1 = '" + id1 + "' Order By Description"
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Return MyTable
    End Function

    Public Function ReadZoomDistinctId2(id As String, id1 As String, id2 As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim SQL As String = "SELECT Distinct ISNULL(Description3, N'') AS Description, id3 FROM Ypoloipa Where id = '" + id + "' And id1 = '" + id1 + "' And id2 = '" + id2 + "' Order By Description"
        Dim MyTable As DataTable = _DataLayer.ReadDataTable(SQL)
        Return MyTable
    End Function

    Public Function ReadYpoloipoJust(id As String, id1 As String, id2 As String, id3 As String) As Double
        Try
            Dim sql = "SELECT Sum(Ypoloipo), Min(Type) As Type FROM Ypoloipa Where id ='" + id + "' And id1 = '" + id1 + "' And id2 ='" + id2 + "' And id3 = '" + id3 + "'"
            Dim dt As DataTable = _DataLayer.ReadDataTable(sql)
            _Fields.Ypoloipo = dt.Rows(0)(0)
            _Fields.Type = dt.Rows(0)(1)
            Return dt.Rows(0)(0)
        Catch ex As Exception
            _Fields.Ypoloipo = 0
            _Fields.Type = "1"
            Return 0
        End Try

    End Function




    Public Function ReadYpoloipo(id As String) As Double
        Return _DataLayer.ReadDataTable("SELECT Sum(Ypoloipo) FROM Ypoloipa Where id ='" + id + "'").Rows(0)(0)
    End Function

    Public Function ReadZoomWinPlan(id As String) As DataTable
        On Error Resume Next
        Dim MyA As New alphaFrameWork.AlphaFramework
        Dim sql As String = "SELECT  
                                          Adv_DiaView.CodeMtl As id, 
                                          Adv_MtlFl.DescMtl As DesciptionMtl, 
                                          Adv_DiaView.DOT1DAH As id1, 
                                          Adv_DiaView.Des1DAH As Description1, 
                                          Adv_DiaView.DOT2DAH As id2, 
                                          Adv_DiaView.Des2DAH As Description2,
                                          Adv_DiaView.DOT3DAH As id3, 
                                          Adv_DiaView.Des3DAH As Description3,
                                          SUM(Adv_DiaView.PEis - Adv_DiaView.PExa) AS Ypoloipo
                                   FROM   Adv_DiaView INNER JOIN
                                          Adv_MtlFl ON Adv_DiaView.CodeMtl = Adv_MtlFl.CodeMtl
                                   WHERE  (Adv_MtlFl.PartMtl <> 0 OR ISNULL(Adv_MtlFl.CDOOMtl, N'') <> '') And Adv_DiaView.CodeMtl = '" + id + "'
                                   GROUP BY Adv_DiaView.CodeMtl, 
                                            Adv_MtlFl.DescMtl, 
                                            Adv_DiaView.DOT1DAH, 
                                            Adv_DiaView.Des1DAH, 
                                            Adv_DiaView.DOT2DAH, 
                                            Adv_DiaView.Des2DAH, 
                                            Adv_DiaView.DOT3DAH, 
                                            Adv_DiaView.Des3DAH

                                   UNION ALL

                                   SELECT  
                                          Adv_KpaFl.CodeKap As id, 
                                          Adv_MtlFl.DescMtl As DescriptionMtl, 
                                          '' AS id1, 
                                          'Ενα Χρώμα' As Description1, 
                                          '' AS id2, 
                                          'Ενα Μέγεθος' As Description2, 
                                          SUM(PEis - PExa) AS Ypoloipo
                                   FROM   Adv_KpaFl INNER JOIN
                                          Adv_MtlFl ON Adv_KpaFl.CodeKap = Adv_MtlFl.CodeMtl
                                   WHERE  Adv_MtlFl.PartMtl = 0 AND ISNULL(Adv_MtlFl.CDOOMtl, N'') = '' And Adv_KpaFl.CodeKap = '" + id + "'
                                   GROUP BY Adv_KpaFl.CodeKap, 
                                            Adv_MtlFl.DescMtl"


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
