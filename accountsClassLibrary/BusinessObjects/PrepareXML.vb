Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Xml

Public Class PrepareXML

    Public Shared Function prepareXML(IDexp As String) As String
        Dim SQL As String = ""
        Dim body As String = ""
        Dim xmlTxt As String = ""
        Dim auditRecord As String = ""
        Dim afmlist As String = ""
        Dim kaelist As String = ""
        Dim Table As String = ""
        Dim tmp_Table As String = ""
        Dim tmp_Tables As String = ""
        Dim retrieveKedeAmountInputRecord As String = ""

        Dim afm = New accountsClassLibrary.AFMFl()
        afm.Read(IDexp)
        Dim ext As String = afm.Fields.auditRecord.Status.id

#Region "Load External Code"
        Try

            Dim sr As System.IO.StreamReader
            sr = New System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "params\retrieveKedeAmountRequest.param".Replace(".", ext + "."))
            body = sr.ReadToEnd()
            sr = New System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "params\auditRecord.param".Replace(".", ext + "."))
            auditRecord = sr.ReadToEnd()
            body = body.Replace("@auditRecord", auditRecord)
            sr = New System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "params\retrieveKedeAmountInputRecord.param".Replace(".", ext + "."))
            retrieveKedeAmountInputRecord = sr.ReadToEnd()
            body = body.Replace("@retrieveKedeAmountInputRecord", retrieveKedeAmountInputRecord)
            sr = New System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "params\AFMlist.param".Replace(".", ext + "."))
            afmlist = sr.ReadToEnd()
            sr = New System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "params\KAElist.param".Replace(".", ext + "."))
            kaelist = sr.ReadToEnd()
            sr = New System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "params\TABLE.param".Replace(".", ext + "."))
            Table = sr.ReadToEnd()

            sr.Close()
        Catch ex As Exception

        End Try
#End Region


        Dim kae As New accountsClassLibrary.KAEFl()
        Dim kae_dt As DataTable = kae.ReadZoom(afm.Fields.auditRecord.auditTransactionId)
        For i As Integer = 0 To kae_dt.Rows.Count - 1
            kae.Read(kae_dt.Rows(i).Item("id").ToString())
            kae.Fields.amount = 0
            kae.Update(kae.Fields.auditRecord.auditUserId)
        Next

        Dim tmp_afms As String = ""
        Dim s_amount As Double = 0.00
        For j = 0 To afm.Fields.dt.Rows.Count - 1

            Dim tmp_afm As String = afmlist
            For i As Integer = 0 To afm.Fields.dt.Columns.Count - 1
                Dim tmp As String = afm.Fields.dt.Rows(j).Item(i).ToString()
                If (afm.Fields.dt.Columns(i).ColumnName.Equals("amount")) Then
                    tmp = tmp.Replace(",", ".")
                    s_amount = s_amount + New alphaFrameWork.AlphaFramework().MakeNo(afm.Fields.dt.Rows(j).Item(i).ToString(), 2)
                End If
                tmp_afm = tmp_afm.Replace("@" + afm.Fields.dt.Columns(i).ColumnName, tmp)
                If (afm.Fields.dt.Columns(i).ColumnName.Equals("SynAFM")) Then
                    tmp_afm = tmp_afm.Replace("@SynAFM", tmp)
                End If
            Next i
            tmp_afms = tmp_afms + tmp_afm

            Dim kin As New AFMKIN()
            Dim kin_dt As DataTable = kin.ReadZoom(afm.Fields.dt.Rows(j).Item("id").ToString())
            For z = 0 To kin_dt.Rows.Count - 1
                kin.Read(kin_dt.Rows(z).Item("id").ToString())

                Dim kae_ As New accountsClassLibrary.KAEFl()
                kae_.Read(kin.Fields.KAEid.id)
                kae_.Fields.amount += kin.Fields.ammount
                kae_.Update(kae.Fields.auditRecord.auditUserId)

                tmp_Table = Table
                For i As Integer = 0 To kin_dt.Columns.Count - 1
                    Dim tmp As String = kin_dt.Rows(z).Item(i).ToString()
                    If kin_dt.Columns(i).ColumnName.Equals("dueDate") Then
                        tmp = Convert.ToDateTime(kin_dt.Rows(z).Item(i)).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).ToString()
                        'tmp += DateTime.Now.ToString("THH:mm:ss", CultureInfo.InvariantCulture).ToString() + "Z"
                    End If

                    If (kin_dt.Columns(i).ColumnName.Equals("ammount")) Then
                        tmp = (New alphaFrameWork.AlphaFramework().MakeNo(kin_dt.Rows(z).Item(i).ToString(), 2)).ToString().Replace(",", ".")
                    End If
                    tmp_Table = tmp_Table.Replace("@" + kin_dt.Columns(i).ColumnName, tmp)
                Next i
                tmp_Table = tmp_Table.Replace("@aa", (z + 1).ToString())
                tmp_Tables += tmp_Table
            Next z

        Next j
        Dim aade = New accountsClassLibrary.AADEFl()
        aade.Read(afm.Fields.auditRecord.auditTransactionId)
        aade.Fields.synolo = s_amount
        aade.Update()

        kae = New accountsClassLibrary.KAEFl()
        Dim kaes_dt As DataTable = kae.ReadZoom(afm.Fields.auditRecord.auditTransactionId)
        Dim tmp_kaes As String = ""
        For j = 0 To kaes_dt.Rows.Count - 1

            Dim tmp_kae As String = kaelist
            For i As Integer = 0 To kaes_dt.Columns.Count - 1
                Dim tmp As String = kaes_dt.Rows(j).Item(i).ToString()
                If (kaes_dt.Columns(i).ColumnName.Equals("amount")) Then
                    tmp = (New alphaFrameWork.AlphaFramework().MakeNo(kaes_dt.Rows(j).Item(i).ToString(), 2)).ToString().Replace(",", ".")
                End If
                tmp_kae = tmp_kae.Replace("@" + kaes_dt.Columns(i).ColumnName, tmp)
            Next i
            tmp_kaes = tmp_kaes + tmp_kae

        Next j

        aade = New accountsClassLibrary.AADEFl()
        aade.Read(afm.Fields.auditRecord.auditTransactionId)
        Dim dt = aade.Fields.auditdt
        For i As Integer = 0 To dt.Columns.Count - 1
            Dim tmp_ As String = dt.Rows(0).Item(i).ToString()
            If (dt.Columns(i).ColumnName.Equals("auditTransactionDate")) Then
                'Dim tmptime As String = Convert.ToDateTime(Now).ToString("HH:mm:ss", CultureInfo.InvariantCulture).ToString()
                tmp_ = Convert.ToDateTime(dt.Rows(0).Item(i)).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).ToString() '+ "T" + tmptime + "Z"
            End If
            If (dt.Columns(i).ColumnName.Equals("synolo")) Then
                Dim tmp As String = (New alphaFrameWork.AlphaFramework().MakeNo(dt.Rows(0).Item(i).ToString(), 2)).ToString()
                body = body.Replace("@sunolo", tmp.Replace(",", "."))
            Else
                body = body.Replace("@" + dt.Columns(i).ColumnName, tmp_)
            End If
        Next

        body = body.Replace("@AFMlist", tmp_afms)
        body = body.Replace("@KAElist", tmp_kaes)
        body = body.Replace("@TABLES", tmp_Tables)
        body = body.Replace("@totalAmount", s_amount.ToString().Replace(",", "."))
        body = body.Replace("@SynAFM", "")
        Dim tmp_time As String = "T" + Convert.ToDateTime(Now).ToString("HH:mm:ss", CultureInfo.InvariantCulture).ToString() + "Z"
        body = body.Replace("@time", tmp_time)

        Dim UserName As String = File.ReadAllText("params\UserName.param")
        Dim Password As String = File.ReadAllText("params\Password.param")
        If ext = "3" Or ext = "4" Then
            UserName = File.ReadAllText("params\UserNameD.param")
            Password = File.ReadAllText("params\PasswordD.param")
        End If

        body = body.Replace("@UserName", UserName)
        body = body.Replace("@Password", Password)
        Return body
    End Function

End Class


