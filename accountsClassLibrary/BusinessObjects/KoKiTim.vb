Imports System.ComponentModel

Public Class ItemKoKiTimModel
    Public Sub New()

        _id = ""
        _Name = ""
        _KoKi = ""

    End Sub

    Public Sub New(StringToFind As String)

        _id = StringToFind
        _Name = StringToFind
        _KoKi = StringToFind

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

    Private _KoKi As String
    Property KoKi As String
        Get
            Return _KoKi
        End Get
        Set(ByVal value As String)
            _KoKi = value
        End Set
    End Property

End Class

Public Class KoKiTim
    Public Sub New()
        Me.Fields = New ItemKoKiTimModel
    End Sub

    Public Sub New(StringToFind As String)
        Me.Fields = New ItemKoKiTimModel(StringToFind)
    End Sub

    Private _fields As ItemKoKiTimModel
    Public Property Fields() As ItemKoKiTimModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKoKiTimModel)
            _fields = value
        End Set
    End Property

    Public Sub Read(idToFind As String)

        ' Write your rules here **********************

        With New kokitim_e
            .Read(idToFind)
            _fields = .Fields
        End With

    End Sub

    Public Function ReadZoom() As DataTable
        On Error Resume Next
        With New kokitim_e
            Return .ReadZoom()
        End With
    End Function

    Public Function ReadCashZoom() As DataTable
        On Error Resume Next
        With New kokitim_e
            Return .ReadCashZoom()
        End With
    End Function
End Class

Friend Class kokitim_e

    Public Sub New()
        Me.Fields = New ItemKoKiTimModel
    End Sub

    Private _fields As ItemKoKiTimModel
    Public Property Fields() As ItemKoKiTimModel
        Get
            Return _fields
        End Get
        Set(ByVal value As ItemKoKiTimModel)
            _fields = value
        End Set
    End Property

    Public Sub Read(idToFind As String)
        On Error Resume Next
        Dim MyTable As DataTable = GetTable(idToFind)
        _fields.id = MyTable.Rows(0).Item("ID")
        _fields.Name = MyTable.Rows(0).Item("Name")
        _fields.KoKi = MyTable.Rows(0).Item("KoKi")
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
            .Columns.Add("koki")
        End With

        Dim newRow As DataRow = MyTable.NewRow()
        Dim f As New FilPin

        Select Case K
            Case "%"

            Case Else
                newRow("id") = K
                f.Read("kk" + K)
                newRow("name") = f.Fields.Name
                f.Read("kl" + K)
                newRow("koki") = f.Fields.Name
        End Select

        Return MyTable
    End Function

End Class