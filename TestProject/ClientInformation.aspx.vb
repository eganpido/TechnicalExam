Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException
Imports System.Configuration
Imports System.IO
Imports System.Web
Public Class ClientInformation
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=EGAN-PC;Initial Catalog=TechExam;Integrated Security=True"
        con.Open()

        cmd.CommandText = "Select * from Client"
        cmd.Connection = con

        grdViewClient.DataSource = cmd.ExecuteReader
        grdViewClient.DataBind()

        con.Close()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=EGAN-PC;Initial Catalog=TechExam;Integrated Security=True"
        con.Open()

        cmd = New SqlCommand("INSERT INTO Client VALUES('" & txtName.Text & "','" & txtPhoneNumber.Text & "','" & txtCity.Text & "','" & txtDate.Text & "')", con)

        If (txtName.Text = "" Or txtPhoneNumber.Text = "" Or txtCity.Text = "" Or txtDate.Text = "") Then
            MsgBox("Please enter all fields!", MsgBoxStyle.Information, "Client Information")
        Else
            cmd.ExecuteNonQuery()
            txtName.Text = ""
            txtPhoneNumber.Text = ""
            txtCity.Text = ""
            txtDate.Text = ""
            con.Close()

            Button1_Click(sender, e)

            MsgBox("Inserted Sucessfully", MsgBoxStyle.Information, "Client Information")
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Upload and save the file.
        Dim csvPath As String = Server.MapPath("~/Files/Upload/") + Path.GetFileName(FileUpload1.PostedFile.FileName)
        FileUpload1.SaveAs(csvPath)

        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Name", GetType(String)), New DataColumn("PhoneNumber", GetType(String)), New DataColumn("City", GetType(String)), New DataColumn("Date", GetType(Date))})

        Dim skip As Boolean = True
        Dim csvData As String = File.ReadAllText(csvPath)
        For Each row As String In csvData.Split(ControlChars.Lf)
            If skip = True Then
                skip = False
            Else
                If Not String.IsNullOrEmpty(row) Then
                    dt.Rows.Add()
                    Dim i As Integer = 0
                    For Each cell As String In row.Split(",")
                        dt.Rows(dt.Rows.Count - 1)(i) = cell
                        i += 1
                    Next
                End If
            End If
        Next



        Dim consString As String = "Data Source=EGAN-PC;Initial Catalog=TechExam;Integrated Security=True"
        Using con As New SqlConnection(consString)
            Using sqlBulkCopy As New SqlBulkCopy(con)
                'Set the database table name.
                sqlBulkCopy.DestinationTableName = "dbo.Client"
                con.Open()
                sqlBulkCopy.WriteToServer(dt)
                con.Close()
            End Using
        End Using

        Button1_Click(sender, e)

        MsgBox("Imported Successfully!", MsgBoxStyle.Information, "Import CSV File")
    End Sub
End Class