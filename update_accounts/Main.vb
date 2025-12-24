Public Class Main

    Dim ProgramPath As String
    Dim UpdateDirectoryPath As String
    Dim MyProgram As String
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t = New ToolTip()
        t.SetToolTip(PictureBox2, "click για μετάβαση στο site !")

        ttl.Text = Application.StartupPath
        Try
            Dim MyMet As String = System.IO.File.ReadAllText(Application.StartupPath + "\update.txt")
            Dim i As Integer = MyMet.IndexOf(";")
            ProgramPath = MyMet.Substring(0, i)
            Dim ii As Integer = MyMet.Substring(i + 1, MyMet.Length - i - 1).IndexOf(";")
            UpdateDirectoryPath = MyMet.Substring(i + 1, ii)
            MyProgram = MyMet.Substring(i + ii + 1 + 1, MyMet.Length - i - ii - 1 - 1)

            TextBox3.Text = MyProgram
            TextBox2.Text = ProgramPath
            TextBox1.Text = UpdateDirectoryPath
        Catch ex As Exception
            MessageBox.Show("Errors !" + vbNewLine + vbNewLine + "update.txt !!!")
            Me.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            System.IO.Directory.SetCurrentDirectory(ProgramPath)
            My.Computer.FileSystem.CopyDirectory(UpdateDirectoryPath, ProgramPath, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If MessageBox.Show("I will restart application !!!", "Update completed !", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Try
                Shell(MyProgram)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Θέλετε να εγκαταλείψετε την αναβάθμιση ;" + vbNewLine + "Ακόμη δεν έγινε τίποτα, μπορείτε να αναβαθμίσετε την εφαρμογη σας μια άλλη φορά !", "Ακύρωση εγκατάστασης αναβάθμησης.", MessageBoxButtons.YesNo) = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        System.Diagnostics.Process.Start("http://www.megasoft.cc/bpr.net/updates.html")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("http://www.megasoft.cc")
    End Sub

End Class