Imports System.ComponentModel

Public Class ItemKoKiKinModel
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

Public Class KoKiKin
    Public Sub New()
        Me.Fields = New ItemKoKiKinModel
    End Sub

    Public Sub New(StringToFind As String)
        Me.Fields = New ItemKoKiKinModel(StringToFind)
    End Sub

    Private _fields As ItemKoKiKinModel
    Public Property Fields() As ItemKoKiKinModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKoKiKinModel)
            _fields = value
        End Set
    End Property

    Public Sub Read(idToFind As String)

        ' Write your rules here **********************

        With New kokikin_e
            .Read(idToFind)
            _fields = .Fields
        End With

    End Sub

    Public Function ReadZoom() As DataTable
        On Error Resume Next
        With New kokikin_e
            Return .ReadZoom()
        End With
    End Function

    Public Function ReadCashZoom() As DataTable
        On Error Resume Next
        With New kokikin_e
            Return .ReadCashZoom()
        End With
    End Function
End Class

Friend Class kokikin_e

    Public Sub New()
        Me.Fields = New ItemKoKiKinModel
    End Sub

    Private _fields As ItemKoKiKinModel
    Public Property Fields() As ItemKoKiKinModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKoKiKinModel)
            _fields = value
        End Set
    End Property

    Public Sub Read(idToFind As String)
        On Error Resume Next
        Dim MyTable As DataTable = GetTable(idToFind)
        _fields.id = MyTable.Rows(0).Item("ID")
        _fields.Name = MyTable.Rows(0).Item("Name")
    End Sub

    Public Function ReadZoom() As DataTable
        Return GetTable("%")
    End Function

    Public Function ReadCashZoom() As DataTable
        On Error Resume Next
        Dim MyTable As New DataTable

        With MyTable
            .Columns.Add("id")
            .Columns.Add("name")
        End With

        Dim newRow As DataRow = MyTable.NewRow()
        newRow("id") = "1"
        newRow("name") = "Ναί"
        MyTable.Rows.Add(newRow)

        newRow = MyTable.NewRow()
        newRow("id") = "0"
        newRow("name") = "Όχι"
        MyTable.Rows.Add(newRow)

        Return MyTable
    End Function

    Private Function GetTable(K As String) As DataTable
        On Error Resume Next
        Dim MyTable As New DataTable

        With MyTable
            .Columns.Add("id")
            .Columns.Add("name")
        End With

        Dim newRow As DataRow = MyTable.NewRow()
        newRow("id") = K
        Select Case K
            Case "00"
                newRow("name") = "Είσπραξη απο Πελάτη"
                MyTable.Rows.Add(newRow)
            Case "01"
                newRow("name") = "Χρέωση σε Πελάτη"
                MyTable.Rows.Add(newRow)
            Case "02"
                newRow("name") = "Πληρωμή σε Πελάτη"
                MyTable.Rows.Add(newRow)
            Case "03"
                newRow("name") = "Πίστωση απο Πελάτη"
                MyTable.Rows.Add(newRow)
            Case "10"
                newRow("name") = "Είσπραξη απο Προμηθευτή"
                MyTable.Rows.Add(newRow)
            Case "11"
                newRow("name") = "Χρέωση σε Προμηθευτή"
                MyTable.Rows.Add(newRow)
            Case "12"
                newRow("name") = "Πληρωμή σε Προμηθευτή"
                MyTable.Rows.Add(newRow)
            Case "13"
                newRow("name") = "Πίστωση απο Προμηθευτή"
                MyTable.Rows.Add(newRow)
            Case "%"
                newRow("id") = "00"
                newRow("name") = "Είσπραξη απο Πελάτη"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "01"
                newRow("name") = "Χρέωση σε Πελάτη"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "02"
                newRow("name") = "Ππληρωμή σε Πελάτη"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "03"
                newRow("name") = "Πίστωση απο Πελάτη"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "10"
                newRow("name") = "Είσπραξη απο Προμηθευτή"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "11"
                newRow("name") = "Χρέωση σε Προμηθευτή"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "12"
                newRow("name") = "Πληρωμή σε Προμηθευτή"
                MyTable.Rows.Add(newRow)

                newRow = MyTable.NewRow()
                newRow("id") = "13"
                newRow("name") = "Πίστωση απο Προμηθευτή"
                MyTable.Rows.Add(newRow)
        End Select

        Return MyTable
    End Function

End Class