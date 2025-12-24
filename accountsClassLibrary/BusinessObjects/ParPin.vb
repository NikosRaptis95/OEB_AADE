Imports System.ComponentModel

Public Class ItemParPinModel
    Public Sub New()

        _id = ""
        _Name = ""

    End Sub

    Public Sub New(StringToFind As String)

        _id = StringToFind
        _Name = StringToFind

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

    Private _Name As String
    Property Name As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

End Class

Public Class ParPin
    Public Sub New()
        Me.Fields = New ItemParPinModel
    End Sub

    Public Sub New(StringToFind As String)
        Me.Fields = New ItemParPinModel(StringToFind)
    End Sub

    Private _fields As ItemParPinModel
    Public Property Fields() As ItemParPinModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemParPinModel)
            _fields = value
        End Set
    End Property

    Public Enum TypeOfPar
        Status
        KindOfTax
        Kind
        Type
        web
        AADEServices
    End Enum

    Public Sub Read(K As TypeOfPar, idToFind As Integer)

        ' Write your rules here **********************

        With New Parpin_e
            .Read(K, idToFind)
            _fields = .Fields
        End With

    End Sub

    Public Function ReadZoom(K As TypeOfPar) As DataTable
        On Error Resume Next
        With New Parpin_e
            Return .ReadZoom(K)
        End With
    End Function

End Class

Friend Class Parpin_e
    Dim _DataLayer As New alphaFrameWork.datalayer

    Public Sub New()
        Me.Fields = New ItemParPinModel
    End Sub

    Private _fields As ItemParPinModel
    Public Property Fields() As ItemParPinModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemParPinModel)
            _fields = value
        End Set
    End Property


    Public Sub Read(K As ParPin.TypeOfPar, idToFind As Integer)
        On Error Resume Next
        Dim MyTable As DataTable = GetTable(K)
        _fields.id = MyTable.Rows(idToFind).Item("ID")
        _fields.Name = MyTable.Rows(idToFind).Item("Name")
    End Sub

    Public Function ReadZoom(K As ParPin.TypeOfPar) As DataTable
        Return GetTable(K)
    End Function

    Private Function GetTable(K As ParPin.TypeOfPar) As DataTable
        On Error Resume Next
        Dim MyTable As New DataTable

        With MyTable
            .Columns.Add("id")
            .Columns.Add("name")
        End With

        Dim newRow As DataRow = MyTable.NewRow()
        Select Case K
            Case ParPin.TypeOfPar.Status
                newRow("id") = "0"
                newRow("name") = "δεδομένα απο τον Server"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "1"
                newRow("name") = "τοπικά δεδομένα"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "2"
                newRow("name") = "τα δεδομένα μεταβιβάστηκαν στον Server"
                MyTable.Rows.Add(newRow)
            Case ParPin.TypeOfPar.KindOfTax
                newRow("id") = "0"
                newRow("name") = "απαλλαγή"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "1"
                newRow("name") = "κανονικό"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "2"
                newRow("name") = "ειδικό"
                MyTable.Rows.Add(newRow)
            Case ParPin.TypeOfPar.Kind
                newRow("id") = "0"
                newRow("name") = "πελάτης"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "1"
                newRow("name") = "προμηθευτής"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "2"
                newRow("name") = "πελάτης και προμηθευτής"
                MyTable.Rows.Add(newRow)
            Case ParPin.TypeOfPar.Type
                newRow("id") = "0"
                newRow("name") = "μικρή"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "1"
                newRow("name") = "μεσέα"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "2"
                newRow("name") = "μεγάλη"
                MyTable.Rows.Add(newRow)
            Case ParPin.TypeOfPar.web
                newRow("id") = ""
                newRow("name") = "local"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "1"
                newRow("name") = "web"
                MyTable.Rows.Add(newRow)
            Case ParPin.TypeOfPar.AADEServices
                newRow("id") = "0"
                newRow("name") = "retrieveKedeAmount"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "1"
                newRow("name") = "retrieveVerificationProgress"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "2"
                newRow("name") = "retrieveCloseDay"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "3"
                newRow("name") = "deleteKedeAmount"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "4"
                newRow("name") = "deleteKedeProgress"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "5"
                newRow("name") = "retrieveNames"
                MyTable.Rows.Add(newRow)
        End Select

        Return MyTable
    End Function

End Class