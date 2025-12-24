Public Class reports
    Public Class Reports
        Public Sub New(reportname As String)
            _report = reportname
            Me._fromKinFl = New ItemKinFlModel
            Me._toKinFl = New ItemKinFlModel
            Me._fromSynFl = New ItemSynFlModel
            Me._toSynFl = New ItemSynFlModel
        End Sub

        Private _report As String
        Property report As String
            Get
                Return _report
            End Get
            Set(ByVal value As String)
                _report = value
            End Set
        End Property

        Private _fromKinFl As ItemKinFlModel
        Property fromKinFl As ItemKinFlModel
            Get
                Return _fromKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _fromKinFl = value
            End Set
        End Property

        Private _toKinFl As ItemKinFlModel
        Property toKinFl As ItemKinFlModel
            Get
                Return _toKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _toKinFl = value
            End Set
        End Property

        Private _fromSynFl As ItemSynFlModel
        Property fromSynFl As ItemSynFlModel
            Get
                Return _fromSynFl
            End Get
            Set(ByVal value As ItemSynFlModel)
                _fromSynFl = value
            End Set
        End Property

        Private _toSynFl As ItemSynFlModel
        Property toSynFl As ItemSynFlModel
            Get
                Return _toSynFl
            End Get
            Set(ByVal value As ItemSynFlModel)
                _toSynFl = value
            End Set
        End Property

        Public Function getData(order As String) As DataTable
            Dim mydata As New DataTable
            Select Case _report
                Case "iso"
                    With New iso
                        .fromKinFl = _fromKinFl
                        .toKinFl = _toKinFl
                        mydata = .getData(order)
                    End With
                Case "hme"
                    With New hme
                        .fromKinFl = _fromKinFl
                        .toKinFl = _toKinFl
                        mydata = .getData(order)
                    End With
                Case "kart"
                    With New kart
                        .fromKinFl = _fromKinFl
                        .toKinFl = _toKinFl
                        mydata = .getData(order)
                    End With
            End Select
            Return mydata
        End Function
        Public Function getOrder() As DataTable
            Dim mydata As New DataTable
            Select Case _report
                Case "iso"
                    With New iso
                        mydata = .getOrder()
                    End With
                Case "hme"
                    With New hme
                        mydata = .getOrder()
                    End With
                Case "kart"
                    With New kart
                        mydata = .getOrder()
                    End With
            End Select
            Return mydata
        End Function
        Public Function getReportName() As String
            Dim reportname As String=""
            Select Case _report
                Case "iso"
                    With New iso
                        reportname = .getReportName
                    End With
                Case "hme"
                    With New hme
                        reportname = .getReportName
                    End With
                Case "kart"
                    With New kart
                        reportname = .getReportName
                    End With
            End Select
            Return reportname
        End Function
        Public Function getDescF(MyForm As Object) As String
            Dim descf As String = ""
            Select Case _report
                Case "iso"
                    With New iso
                        .fromKinFl = _fromKinFl
                        .toKinFl = _toKinFl
                        descf = .getDescF(MyForm)
                    End With
                Case "hme"
                    With New hme
                        .fromKinFl = _fromKinFl
                        .toKinFl = _toKinFl
                        descf = .getDescF(MyForm)
                    End With
                Case "kart"
                    With New hme
                        .fromKinFl = _fromKinFl
                        .toKinFl = _toKinFl
                        descf = .getDescF(MyForm)
                    End With
            End Select
            Return descf
        End Function

    End Class

    Friend Class globalForReports

        Public Function getDescFT_Kin(fromKinFl As Object, toKinFl As Object, MyForm As Object) As String
            Dim r As String
            With New globalForReports
                r = .DescParametr(fromKinFl, MyForm, "fk")
                r += .DescParametr(toKinFl, MyForm, "tk")
                r += .DescParametr(fromKinFl.KoKiKin, MyForm, "k_kokikin")
                r += .DescParametr(fromKinFl.Status, MyForm, "k_status")
                r += .DescParametr(fromKinFl.idSyn, MyForm, "fs")
                r += .DescParametr(toKinFl.idSyn, MyForm, "ts")
                r += .DescParametr(fromKinFl.idSyn.Category, MyForm, "s_category")
                r += .DescParametr(fromKinFl.idSyn.Occupation, MyForm, "s_occupation")
                r += .DescParametr(fromKinFl.idSyn.PriceList, MyForm, "s_pricelist")
                r += .DescParametr(fromKinFl.idSyn.KindOfTax, MyForm, "s_kindoftax")
                r += .DescParametr(fromKinFl.idSyn.Kind, MyForm, "s_kind")
                r += .DescParametr(fromKinFl.idSyn.Status, MyForm, "s_status")
            End With
            Return r
        End Function

        Private Function DescParametr(fClass_ As Object, myForm As Object, classname As String) As String
            Dim MyParam As String = " "
            Dim Desc As String = ""

            For Each p As System.Reflection.PropertyInfo In fClass_.GetType().GetProperties()
                If p.CanRead Then
                    Try
                        If p.GetValue(fClass_, Nothing).ToString.Length > 0 And
                               p.Name.ToUpper <> "SUMMARY" And
                               p.Name.ToUpper <> "YPOLOIPO" And
                               p.Name.ToUpper <> "FLAG0" Then

                            Dim comp As String = ""
                            Try
                                comp = p.GetValue(fClass_, Nothing).ToString.Substring(0, 20).ToUpper
                            Catch ex As Exception
                                comp = p.GetValue(fClass_, Nothing).ToString
                            End Try
                            If comp <> "ACCOUNTSCLASSLIBRARY" Then
                                Desc = getDescFromForm(p.Name, myForm, classname)
                                MyParam += "(" + Desc + "=" + p.GetValue(fClass_, Nothing).ToString + ")   "
                            End If

                        End If
                    Catch ex As Exception
                        '
                    End Try
                End If
            Next

            Return MyParam
        End Function

        Private Function getDescFromForm(desc As String, myform As Object, classname As String) As String
            desc = classname + "_" + desc
            For Each t In myform.Controls
                For Each tp In t.Controls
                    For Each c In tp.Controls
                        If c.Name.ToUpper = "LABEL_" + desc.ToUpper Then
                            Try
                                desc = c.Text
                            Catch ex As Exception
                                desc = "*" + desc
                            End Try
                        End If
                    Next
                Next
            Next
            Return desc
        End Function

    End Class

    Friend Class iso
        Public Sub New()
            Me._fromKinFl = New ItemKinFlModel
            Me._toKinFl = New ItemKinFlModel
        End Sub

        Private _fromKinFl As ItemKinFlModel
        Property fromKinFl As ItemKinFlModel
            Get
                Return _fromKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _fromKinFl = value
            End Set
        End Property

        Private _toKinFl As ItemKinFlModel
        Property toKinFl As ItemKinFlModel
            Get
                Return _toKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _toKinFl = value
            End Set
        End Property
        Public Function getData(order As String) As DataTable
            On Error Resume Next
            ' make the datatable
            Dim table = New DataTable("mydt")
            With table.Columns
                .Add(New DataColumn("idSyn", Type.GetType("System.String")))
                .Add(New DataColumn("DescSyn", Type.GetType("System.String")))
                .Add(New DataColumn("prYpoloipo", Type.GetType("System.Double")))
                .Add(New DataColumn("xreosi", Type.GetType("System.Double")))
                .Add(New DataColumn("pistosi", Type.GetType("System.Double")))
                .Add(New DataColumn("ypoloipo", Type.GetType("System.Double")))
            End With
            Dim row As DataRow

            ' read dateMark
            Dim c As New alphaFrameWork.datalayer
            Dim dmark As String = c.dateMark

            ' dhmioyrgia filtrou
            Dim strWhere As String = ""
            ' kinhseis
            If _fromKinFl.Seira.Length > 0 Then strWhere += " And (KinFlQry.Seira = '" + _fromKinFl.Seira + "') "
            If _fromKinFl.AitiKin.Length > 0 Then strWhere += " And (KinFlQry.AitiKin Like '%" + _fromKinFl.AitiKin + "%') "
            If _fromKinFl.id.Length > 0 Then strWhere += " And (KinFlQry.Id >= '" + _fromKinFl.id + "' And KinFlQry.Id <= '" + _toKinFl.id + "') "
            If _fromKinFl.KoKiKin.id.Length > 0 Then strWhere += " And (KinFlQry.KoKiKin = '" + _fromKinFl.KoKiKin.id + "') "
            If _fromKinFl.Cash.Length > 0 Then strWhere += " And (KinFlQry.Cash = '" + _fromKinFl.Cash + "') "
            If _fromKinFl.Status.id.Length > 0 Then strWhere += " And (KinFlQry.Status = '" + _fromKinFl.Status.id + "') "
            If _fromKinFl.SalesPerson.Length > 0 Then strWhere += " And (KinFlQry.SalesPerson = '" + _fromKinFl.SalesPerson + "') "
            ' synallasomenos
            If _fromKinFl.idSyn.id.Length > 0 Then strWhere += " And (KinFlQry.IdSyn >= '" + _fromKinFl.idSyn.id + "' And KinFlQry.IdSyn <= '" + _toKinFl.idSyn.id + "') "
            If _fromKinFl.idSyn.Category.id.Length > 0 Then strWhere += " And (SynFl.Category = '" + _fromKinFl.idSyn.Category.id + "') "
            If _fromKinFl.idSyn.Occupation.id.Length > 0 Then strWhere += " And (SynFl.Occupation = '" + _fromKinFl.idSyn.Occupation.id + "') "
            If _fromKinFl.idSyn.PriceList.id.Length > 0 Then strWhere += " And (SynFl.PriceList = '" + _fromKinFl.idSyn.PriceList.id + "') "
            If _fromKinFl.idSyn.KindOfTax.id.Length > 0 Then strWhere += " And (SynFl.KindOfTax = '" + _fromKinFl.idSyn.KindOfTax.id + "') "
            If _fromKinFl.idSyn.Kind.id.Length > 0 Then strWhere += " And (SynFl.Kind = '" + _fromKinFl.idSyn.Kind.id + "' Or SynFl.Kind = '2') "
            If _fromKinFl.idSyn.Status.id.Length > 0 Then strWhere += " And (SynFl.Status = '" + _fromKinFl.idSyn.Status.id + "') "
            If _fromKinFl.idSyn.Name.Length > 0 Then strWhere += " And (SynFl.Name Like '%" + _fromKinFl.idSyn.Name + "%') "
            ' Παράμετρος Join 
            Dim JoinParam As String = " LEFT "
            ' ***************************************************

            ' read proygoymeno ypoloipo
            Dim sql As String = "SELECT KinFlQry.IdSyn As IdSyn, SynFl.[Name] As DescSyn, KinFlQry.KoKiKin, Sum(KinFlQry.Summary) As Summary " +
                                "FROM KinFlQry " + JoinParam + " JOIN SynFl ON KinFlQry.IdSyn = SynFl.id " +
                                "Where KinFlQry.RegistryDate < " + dmark + _fromKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark +
                                strWhere +
                                " Group By  KinFlQry.IdSyn,SynFl.[Name],KInFlQry.KoKiKin "

            Dim d As DataTable = c.ReadDataTable(sql)
            Dim i As Integer
            Dim k As New KinFl
            Dim x As Integer
            Dim sw As Boolean = False

            For i = 0 To d.Rows.Count - 1
                sw = False
                For x = 0 To table.Rows.Count - 1
                    If table.Rows(x)("idSyn") = d.Rows(i)("idSyn") Then
                        table.Rows(x)("xreosi") = 0
                        table.Rows(x)("pistosi") = 0
                        table.Rows(x)("prypoloipo") += (k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), True) - k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), False))
                        table.Rows(x)("ypoloipo") = table.Rows(x)("prypoloipo")
                        sw = True
                        Exit For
                    End If
                Next
                If sw = False Then
                    row = table.NewRow()
                    row("idSyn") = d.Rows(i)("idSyn")
                    row("DescSyn") = d.Rows(i)("DescSyn")
                    row("xreosi") = 0
                    row("pistosi") = 0
                    row("prypoloipo") = (k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), True) - k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), False))
                    row("ypoloipo") = row("prypoloipo")
                    table.Rows.Add(row)
                End If
            Next

            ' read kinhseis
            c = New alphaFrameWork.datalayer
                If order.Trim.Length > 0 Then order = " Order By " + order
                sql = "SELECT KinFlQry.IdSyn, SynFl.[Name] As DescSyn, KinFlQry.KoKiKin, Sum(KinFlQry.Summary) As Summary " +
                    "FROM KinFlQry " + JoinParam + " JOIN SynFl ON KinFlQry.IdSyn = SynFl.id " +
                    "Where KinFlQry.RegistryDate >= " + dmark + _fromKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark +
                    " And KinFlQry.RegistryDate <= " + dmark + _toKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark +
                    strWhere +
                    " Group By  KinFlQry.IdSyn,SynFl.[Name],KInFlQry.KoKiKin " + order
                d = c.ReadDataTable(sql)
                i = 0
                k = New KinFl
                x = 0
                sw = False
                For i = 0 To d.Rows.Count - 1
                    sw = False
                    For x = 0 To table.Rows.Count - 1
                        If table.Rows(x)("idSyn") = d.Rows(i)("idSyn") Then
                            table.Rows(x)("xreosi") += k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), True)
                            table.Rows(x)("pistosi") += k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), False)
                            table.Rows(x)("ypoloipo") = (table.Rows(x)("xreosi") - table.Rows(x)("pistosi")) + table.Rows(x)("prypoloipo")
                            sw = True
                            Exit For
                        End If
                    Next
                    If sw = False Then
                        row = table.NewRow()
                        row("idSyn") = d.Rows(i)("idSyn")
                        row("DescSyn") = d.Rows(i)("DescSyn")
                        row("xreosi") = k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), True)
                        row("pistosi") = k.GetXreosiPistosi(d.Rows(i)("Summary"), d.Rows(i)("KoKiKin"), False)
                        row("ypoloipo") = row("xreosi") - row("pistosi")
                        row("prypoloipo") = 0
                        table.Rows.Add(row)
                    End If
                Next


            Return table
        End Function

        Public Function getOrder() As DataTable
            Dim myObj As New List(Of String)
            myObj.Add("")
            myObj.Add("όνομα συναλλασόμενου")
            myObj.Add("κωδικό συναλλασόμενου")
            myObj.Add("συγκεντρωμένο ποσό κίνησης")
            With New alphaFrameWork.AlphaFramework
                myObj = .customizationforOrder(myObj, "iso_Report_Order")
            End With

            Dim dt = New DataTable
            dt.Columns.Add("id", System.Type.GetType("System.String"))
            dt.Columns.Add("Name", System.Type.GetType("System.String"))
            Dim row As DataRow
            row = dt.NewRow()
            row("id") = ""
            row("Name") = myObj(0)
            dt.Rows.Add(row)

            row = dt.NewRow()
            row("id") = "SynFl.[Name]"
            row("Name") = myObj(1)
            dt.Rows.Add(row)

            row = dt.NewRow()
            row("id") = "KinFlQry.IdSyn"
            row("Name") = myObj(2)
            dt.Rows.Add(row)

            row = dt.NewRow()
            row("id") = "Sum(KinFlQry.Summary)"
            row("Name") = myObj(3)
            dt.Rows.Add(row)

            Return dt
        End Function
        Public Function getReportName() As String
            Return "reports\rdlc\isοReport.rdlc"
        End Function
        Public Function getReportTitle() As String
            Return "Ισοζύγιο"
        End Function
        Public Function getDescF(MyForm As Object) As String
            With New globalForReports
                Return .getDescFT_Kin(_fromKinFl, _toKinFl, MyForm)
            End With
        End Function
    End Class

    Friend Class hme
        Public Sub New()
            Me._fromKinFl = New ItemKinFlModel
            Me._toKinFl = New ItemKinFlModel
        End Sub

        Private _fromKinFl As ItemKinFlModel
        Property fromKinFl As ItemKinFlModel
            Get
                Return _fromKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _fromKinFl = value
            End Set
        End Property

        Private _toKinFl As ItemKinFlModel
        Property toKinFl As ItemKinFlModel
            Get
                Return _toKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _toKinFl = value
            End Set
        End Property
        Public Function getData(order As String) As DataTable
            'On Error Resume Next
            ' make the datatable

            ' read dateMark
            Dim c As New alphaFrameWork.datalayer
            Dim dmark As String = c.dateMark

            ' dhmioyrgia filtrou
            Dim strWhere As String = ""
            ' kinhseis
            If _fromKinFl.Seira.Length > 0 Then strWhere += " And (KinFlQry.Seira = '" + _fromKinFl.Seira + "') "
            If _fromKinFl.AitiKin.Length > 0 Then strWhere += " And (KinFlQry.AitiKin Like '%" + _fromKinFl.AitiKin + "%') "
            If _fromKinFl.id.Length > 0 Then strWhere += " And (KinFlQry.Id >= '" + _fromKinFl.id + "' And KinFlQry.Id <= '" + _toKinFl.id + "') "
            If _fromKinFl.KoKiKin.id.Length > 0 Then strWhere += " And (KinFlQry.KoKiKin = '" + _fromKinFl.KoKiKin.id + "') "
            If _fromKinFl.Cash.Length > 0 Then strWhere += " And (KinFlQry.Cash = '" + _fromKinFl.Cash + "') "
            If _fromKinFl.Status.id.Length > 0 Then strWhere += " And (KinFlQry.Status = '" + _fromKinFl.Status.id + "') "
            If _fromKinFl.SalesPerson.Length > 0 Then strWhere += " And (KinFlQry.SalesPerson = '" + _fromKinFl.SalesPerson + "') "
            ' synallasomenos
            If _fromKinFl.idSyn.id.Length > 0 Then strWhere += " And (KinFlQry.IdSyn >= '" + _fromKinFl.idSyn.id + "' And KinFlQry.IdSyn <= '" + _toKinFl.idSyn.id + "') "
            If _fromKinFl.idSyn.Category.id.Length > 0 Then strWhere += " And (SynFl.Category = '" + _fromKinFl.idSyn.Category.id + "') "
            If _fromKinFl.idSyn.Occupation.id.Length > 0 Then strWhere += " And (SynFl.Occupation = '" + _fromKinFl.idSyn.Occupation.id + "') "
            If _fromKinFl.idSyn.PriceList.id.Length > 0 Then strWhere += " And (SynFl.PriceList = '" + _fromKinFl.idSyn.PriceList.id + "') "
            If _fromKinFl.idSyn.KindOfTax.id.Length > 0 Then strWhere += " And (SynFl.KindOfTax = '" + _fromKinFl.idSyn.KindOfTax.id + "') "
            If _fromKinFl.idSyn.Kind.id.Length > 0 Then strWhere += " And (SynFl.Kind = '" + _fromKinFl.idSyn.Kind.id + "' Or SynFl.Kind = '2') "
            If _fromKinFl.idSyn.Status.id.Length > 0 Then strWhere += " And (SynFl.Status = '" + _fromKinFl.idSyn.Status.id + "') "
            If _fromKinFl.idSyn.Name.Length > 0 Then strWhere += " And (SynFl.Name Like '%" + _fromKinFl.idSyn.Name + "%') "


            Dim sql As String = "SELECT KinFlQry.IdSyn As IdSyn, RegistryDate as RegDate, KinFlQry.Seira + ' ' + KinFlQry.id As ArPa, SynFl.[Name] As DescSyn, KinFlQry.KoKiKin As KoKiKin, KinFlQry.AitiKin, KinFlQry.Summary As Summary, 0 as xreosi, 0 As pistosi, 0 as ypoloipo " +
                                "FROM KinFlQry LEFT JOIN SynFl ON KinFlQry.IdSyn = SynFl.id " +
                                "Where KinFlQry.RegistryDate >= " + dmark + _fromKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark + " And KinFlQry.RegistryDate <= " + dmark + _toKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark +
            strWhere + " Order by RegistryDate Desc"
            Dim dt As DataTable = c.ReadDataTable(sql)

            Dim k As New KinFl
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("Summary") <> 0 Then
                    dt.Rows(i)("xreosi") = k.GetXreosiPistosi(dt.Rows(i)("Summary"), dt.Rows(i)("KoKiKin"), True)
                    dt.Rows(i)("pistosi") = k.GetXreosiPistosi(dt.Rows(i)("Summary"), dt.Rows(i)("KoKiKin"), False)
                    dt.Rows(i)("ypoloipo") = dt.Rows(i)("xreosi") - dt.Rows(i)("pistosi")
                End If

            Next

            sql = "SELECT KoKiKin, Summary As Summary FROM KinFlQry Where KinFlQry.RegistryDate < " + dmark + _fromKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark
            Dim dty As DataTable = c.ReadDataTable(sql)
            Dim ypol As Double = 0
            For i As Integer = 0 To dty.Rows.Count - 1
                If dty.Rows(i)("Summary") <> 0 Then
                    ypol += k.GetXreosiPistosi(dty.Rows(i)("Summary"), dty.Rows(i)("KoKiKin"), True)
                    ypol -= k.GetXreosiPistosi(dty.Rows(i)("Summary"), dty.Rows(i)("KoKiKin"), False)
                End If
            Next
            Dim r As DataRow
            r = dt.NewRow()
            r("RegDate") = _fromKinFl.RegistryDate.AddDays(-1)
            r("AitiKin") = "Υπόλοιπο"
            r("ypoloipo") = ypol
            dt.Rows.InsertAt(r, 0)

            Return dt
        End Function

        Public Function getOrder() As DataTable
            Dim myObj As New List(Of String)
            myObj.Add("")
            myObj.Add("Ημερομηνία")
            With New alphaFrameWork.AlphaFramework
                myObj = .customizationforOrder(myObj, "kart_Report_Order")
            End With

            Dim dt = New DataTable
            dt.Columns.Add("id", System.Type.GetType("System.String"))
            dt.Columns.Add("Name", System.Type.GetType("System.String"))
            Dim row As DataRow
            row = dt.NewRow()
            row("id") = ""
            row("Name") = myObj(0)
            dt.Rows.Add(row)

            'row = dt.NewRow()
            'row("id") = "SynFl.[Name]"
            'row("Name") = myObj(1)
            'dt.Rows.Add(row)

            'row = dt.NewRow()
            'row("id") = "KinFlQry.IdSyn"
            'row("Name") = myObj(2)
            'dt.Rows.Add(row)

            'row = dt.NewRow()
            'row("id") = "Sum(KinFlQry.Summary)"
            'row("Name") = myObj(3)
            'dt.Rows.Add(row)

            Return dt
        End Function
        Public Function getReportName() As String
            Return "reports\rdlc\hmeReport.rdlc"
        End Function
        Public Function getReportTitle() As String
            Return "Ημερολόγιο"
        End Function
        Public Function getDescF(MyForm As Object) As String
            With New globalForReports
                Return .getDescFT_Kin(_fromKinFl, _toKinFl, MyForm)
            End With
        End Function
    End Class

    Friend Class kart
        Public Sub New()
            Me._fromKinFl = New ItemKinFlModel
            Me._toKinFl = New ItemKinFlModel
        End Sub

        Private _fromKinFl As ItemKinFlModel
        Property fromKinFl As ItemKinFlModel
            Get
                Return _fromKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _fromKinFl = value
            End Set
        End Property

        Private _toKinFl As ItemKinFlModel
        Property toKinFl As ItemKinFlModel
            Get
                Return _toKinFl
            End Get
            Set(ByVal value As ItemKinFlModel)
                _toKinFl = value
            End Set
        End Property
        Public Function getData(order As String) As DataTable
            'On Error Resume Next
            ' make the datatable

            ' read dateMark
            Dim c As New alphaFrameWork.datalayer
            Dim dmark As String = c.dateMark

            ' dhmioyrgia filtrou
            Dim strWhere As String = ""
            ' kinhseis
            If _fromKinFl.Seira.Length > 0 Then strWhere += " And (KinFlQry.Seira = '" + _fromKinFl.Seira + "') "
            If _fromKinFl.AitiKin.Length > 0 Then strWhere += " And (KinFlQry.AitiKin Like '%" + _fromKinFl.AitiKin + "%') "
            If _fromKinFl.id.Length > 0 Then strWhere += " And (KinFlQry.Id >= '" + _fromKinFl.id + "' And KinFlQry.Id <= '" + _toKinFl.id + "') "
            If _fromKinFl.KoKiKin.id.Length > 0 Then strWhere += " And (KinFlQry.KoKiKin = '" + _fromKinFl.KoKiKin.id + "') "
            If _fromKinFl.Cash.Length > 0 Then strWhere += " And (KinFlQry.Cash = '" + _fromKinFl.Cash + "') "
            If _fromKinFl.Status.id.Length > 0 Then strWhere += " And (KinFlQry.Status = '" + _fromKinFl.Status.id + "') "
            If _fromKinFl.SalesPerson.Length > 0 Then strWhere += " And (KinFlQry.SalesPerson = '" + _fromKinFl.SalesPerson + "') "
            ' synallasomenos
            If _fromKinFl.idSyn.id.Length > 0 Then strWhere += " And (KinFlQry.IdSyn >= '" + _fromKinFl.idSyn.id + "' And KinFlQry.IdSyn <= '" + _toKinFl.idSyn.id + "') "
            If _fromKinFl.idSyn.Category.id.Length > 0 Then strWhere += " And (SynFl.Category = '" + _fromKinFl.idSyn.Category.id + "') "
            If _fromKinFl.idSyn.Occupation.id.Length > 0 Then strWhere += " And (SynFl.Occupation = '" + _fromKinFl.idSyn.Occupation.id + "') "
            If _fromKinFl.idSyn.PriceList.id.Length > 0 Then strWhere += " And (SynFl.PriceList = '" + _fromKinFl.idSyn.PriceList.id + "') "
            If _fromKinFl.idSyn.KindOfTax.id.Length > 0 Then strWhere += " And (SynFl.KindOfTax = '" + _fromKinFl.idSyn.KindOfTax.id + "') "
            If _fromKinFl.idSyn.Kind.id.Length > 0 Then strWhere += " And (SynFl.Kind = '" + _fromKinFl.idSyn.Kind.id + "' Or SynFl.Kind = '2') "
            If _fromKinFl.idSyn.Status.id.Length > 0 Then strWhere += " And (SynFl.Status = '" + _fromKinFl.idSyn.Status.id + "') "
            If _fromKinFl.idSyn.Name.Length > 0 Then strWhere += " And (SynFl.Name Like '%" + _fromKinFl.idSyn.Name + "%') "


            Dim sql As String = "SELECT KinFlQry.IdSyn As IdSyn, RegistryDate as RegDate, KinFlQry.Seira + ' ' + KinFlQry.id As ArPa, SynFl.[Name] As DescSyn, KinFlQry.KoKiKin As KoKiKin, KinFlQry.AitiKin, KinFlQry.Summary As Summary, 0 as xreosi, 0 As pistosi, 0 as ypoloipo " +
                                "FROM KinFlQry LEFT JOIN SynFl ON KinFlQry.IdSyn = SynFl.id " +
                                "Where KinFlQry.RegistryDate >= " + dmark + _fromKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark + " And KinFlQry.RegistryDate <= " + dmark + _toKinFl.RegistryDate.ToString("yyyy-MM-dd") + dmark +
            strWhere + " Order By RegistryDate"
            Dim dt As DataTable = c.ReadDataTable(sql)

            Dim k As New KinFl
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("Summary") <> 0 Then
                    dt.Rows(i)("xreosi") = k.GetXreosiPistosi(dt.Rows(i)("Summary"), dt.Rows(i)("KoKiKin"), True)
                    dt.Rows(i)("pistosi") = k.GetXreosiPistosi(dt.Rows(i)("Summary"), dt.Rows(i)("KoKiKin"), False)
                    dt.Rows(i)("ypoloipo") = dt.Rows(i)("xreosi") - dt.Rows(i)("pistosi")
                End If
            Next

            ' Read Προηγούμενα Υπολοιπα SynFl - Τοποθέτησετα στο dt
            Dim view = New DataView(dt)
            Dim dtSynId As DataTable = view.ToTable(True, "IdSyn", "DescSyn")
            For i As Integer = 0 To dtSynId.Rows.Count - 1
                Dim r As DataRow = dt.NewRow()
                r("RegDate") = _fromKinFl.RegistryDate.AddDays(-1)
                r("AitiKin") = "Υπόλοιπο"
                Dim s As New SynFl
                s.Fields.id = dtSynId.Rows(i)("IDSyn")
                s.ReadYpoloipo("", r("RegDate"))
                r("ypoloipo") = s.Fields.Ypoloipo
                r("IdSyn") = dtSynId.Rows(i)("IDSyn")
                r("DescSyn") = dtSynId.Rows(i)("DescSyn")
                dt.Rows.InsertAt(r, 0)
            Next

            Return dt
        End Function
        Public Function getOrder() As DataTable
            Dim myObj As New List(Of String)
            myObj.Add("")
            myObj.Add("Κωδικό")
            With New alphaFrameWork.AlphaFramework
                myObj = .customizationforOrder(myObj, "kart_Report_Order")
            End With

            Dim dt = New DataTable
            dt.Columns.Add("id", System.Type.GetType("System.String"))
            dt.Columns.Add("Name", System.Type.GetType("System.String"))
            Dim row As DataRow
            row = dt.NewRow()
            row("id") = ""
            row("Name") = myObj(0)
            dt.Rows.Add(row)

            'row = dt.NewRow()
            'row("id") = "SynFl.[Name]"
            'row("Name") = myObj(1)
            'dt.Rows.Add(row)

            'row = dt.NewRow()
            'row("id") = "KinFlQry.IdSyn"
            'row("Name") = myObj(2)
            'dt.Rows.Add(row)

            'row = dt.NewRow()
            'row("id") = "Sum(KinFlQry.Summary)"
            'row("Name") = myObj(3)
            'dt.Rows.Add(row)

            Return dt
        End Function
        Public Function getReportName() As String
            Return "reports\rdlc\kartReport.rdlc"
        End Function
        Public Function getReportTitle() As String
            Return "Καρτέλλα"
        End Function
        Public Function getDescF(MyForm As Object) As String
            With New globalForReports
                Return .getDescFT_Kin(_fromKinFl, _toKinFl, MyForm)
            End With
        End Function
    End Class



    Public Class ApoKinFl
        Public ReportPath As String = "reports\rdlc\ApoKinFl.rdlc"
        Public Function getData(KoKiKin As String, Seira As String, Id As String) As DataTable
            Dim Sql As String = "SELECT KinFl.AitiKin, 
                                        KinFl.Cash, 
                                        KinFl.id, 
                                        KinFl.IdSyn, 
                                        KinFl.KoKiKin, 
                                        KinFl.[Memo], 
                                        KinFl.RegistryDate, 
                                        KinFl.Seira, 
                                        KinFl.Status, 
                                        KinFl.Summary, 
                                        KinFl.SalesPerson, 
                                        SynFl.Name, 
                                        SynFl.Address, 
                                        SynFl.PhoneNo, 
                                        SynFl.AFM, 
                                        SynFl.DOY,
                                        SynFl.eMail, 
                                        SynFl.WebSite, 
                                        SynFl.Map, 
                                        FilPin.Name AS OccupationDescription
                                FROM ((SynFl LEFT OUTER JOIN
                                       FilPin ON SynFl.Occupation = FilPin.ID) LEFT OUTER JOIN
                                       KinFl ON SynFl.id = KinFl.IdSyn) Where KinFl.KoKiKin = '" + KoKiKin + "'
                                                                          And KinFl.Seira   = '" + Seira + "'
                                                                          And KinFl.Id      = '" + Id + "'"

            Return New alphaFrameWork.datalayer().ReadDataTable(Sql)
        End Function

    End Class

    Public Class DefaultPage
        'Public Function getData(Timo As String, Cur As String) As DataTable
        '    On Error Resume Next
        '    Dim d As New alphaFrameWork.datalayer
        '    Dim sql As String = ""


        '    sql = "SELECT ' ' as PriceVat, 
        '                  MtlFl.Description, 
        '                   '' As ADescription, 
        '                  MtlFl.id, 
        '                  ' ' AS price, 
        '                  Times.Price As Price_ , 
        '                  ' ' AS PEkptDesc, 
        '                  Times.PEkpt As PEkpt_, 
        '                  0 As PEkpt,
        '                  'images/Application/' + MtlFl.Id + '_1.jpg' As IDPicture, 
        '                  '' As PriceBeforeEkptDesc, 
        '                  '' As PriceDesc,
        '                  '' As Apothema
        '           FROM MtlFl LEFT OUTER JOIN Times 
        '           On MtlFl.id = Times.Product And Times.PriceList = '" + Timo + "' 
        '                Where MtlFl.eShop = '1' And MtlFl.ePosition >'00'
        '                Order By MtlFl.ePosition, MtlFl.Description"

        '    Dim MyTable As DataTable = d.ReadDataTable(sql)
        '    Dim _InStock As String = inStock()
        '    Dim _OutOfStock As String = OutOfStock()
        '    Dim _NoPrice As String = NoPrice()
        '    Dim PriceVat As String = ""
        '    Dim deka As Integer = 2
        '    With New FilPin
        '        .Read(Timo)
        '        If .Fields.Flag0 = False Then PriceVat = " δεν περιέχει ΦΠΑ "
        '        .Read("xr004")
        '        deka = CInt(.Fields.Name)
        '    End With

        '    Dim i As Integer = 0
        '    Dim _DataLayer As New alphaFrameWork.datalayer
        '    For i = 0 To MyTable.Rows.Count - 1

        '        If PriceVat <> "" Then MyTable.Rows(i)("PriceVat") = PriceVat

        '        MyTable.Rows(i)("ADescription") = MyTable.Rows(i)("Description").Replace(" ", "-")

        '        MyTable.Rows(i)("price") = (Math.Round(MyTable.Rows(i)("Price_"), deka)).ToString + Cur
        '        If MyTable.Rows(i)("PEkpt_") > 0 Then
        '            MyTable.Rows(i)("PriceBeforeEkptDesc") = MyTable.Rows(i)("price")
        '            MyTable.Rows(i)("PriceDesc") = (Math.Round((MyTable.Rows(i)("Price_") - (MyTable.Rows(i)("Price_") * MyTable.Rows(i)("PEkpt_") / 100)), deka)).ToString + Cur
        '            MyTable.Rows(i)("PEkptDesc") = "<div class='ribbon'><span>-" + Math.Round(MyTable.Rows(i)("PEkpt_"), 1).ToString() + "%</span></div>"
        '        Else
        '            MyTable.Rows(i)("PriceDesc") = MyTable.Rows(i)("price")
        '        End If

        '        If MyTable.Rows(i)("Price_") = 0 Then MyTable.Rows(i)("PriceDesc") = _NoPrice

        '        MyTable.Rows(i)("Apothema") = _OutOfStock
        '        Dim md As DataTable = _DataLayer.ReadDataTable("SELECT Sum(Ypoloipo) FROM Ypoloipa Where id ='" + MyTable.Rows(i)("id") + "'")
        '        If md.Rows(0)(0) > 0 Then MyTable.Rows(i)("Apothema") = _InStock

        '    Next

        '    Return MyTable

        'End Function
        'Private Function inStock() As String
        '    Dim f = New FilPin
        '    If f.Read("se001") = "" Then
        '        Return f.Fields.Name
        '    Else
        '        Return "In Stock"
        '    End If
        'End Function
        'Private Function OutOfStock() As String
        '    Dim f = New FilPin
        '    If f.Read("se002") = "" Then
        '        Return f.Fields.Name
        '    Else
        '        Return "Παράδοση σε 3 ημέρες"
        '    End If
        'End Function
        'Public Function NoPrice() As String
        '    Dim f = New FilPin
        '    If f.Read("se003") = "" Then
        '        Return f.Fields.Name
        '    Else
        '        Return "Καλέστε μας για τιμή"
        '    End If
        'End Function



        Public Function getCounters() As List(Of Integer)
            Dim r As New List(Of Integer)
            Try
                Dim d As alphaFrameWork.datalayer = New alphaFrameWork.datalayer()

                r.Add(d.ReadDataTable("Select Count(id) From MtlFl Where eShop = 1").Rows(0).Item(0))
                r.Add(d.ReadDataTable("Select Count(id) From FilPin Where id Like 'xa%'").Rows(0).Item(0))
                r.Add(d.ReadDataTable("Select Count(id) From FilPin Where id Like 'ka%'").Rows(0).Item(0))
            Catch ex As Exception

            End Try

            Return r
        End Function
    End Class
End Class