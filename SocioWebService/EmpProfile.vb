Imports System.Data.SqlClient

Public Class EmpProfile

    Public FirstName, MiddleName, LastName, Designation, StoreName, StoreAddress, Area, City, Region, StoreOpen, StoreClose As String

    Public Sub New(ByVal EmpId As Integer)
        Dim selectStatement As String
        Dim connectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()

        selectStatement = "SELECT * from vEmployee where EmpId = " + EmpId.ToString

        Using connection As New SqlConnection(connectionString)

            Dim command As New SqlCommand(selectStatement, connection)
            connection.Open()
            Dim dataReader As SqlDataReader = command.ExecuteReader()

            Dim colCnt As Integer = dataReader.FieldCount

            Do While dataReader.Read()
                FirstName = dataReader.GetString(2).ToString()
                MiddleName = dataReader.GetString(3).ToString()
                LastName = dataReader.GetString(4).ToString()
                Designation = dataReader.GetString(5).ToString()
                StoreName = dataReader.GetString(6).ToString()
                StoreAddress = dataReader.GetString(7).ToString()
                Area = dataReader.GetString(8).ToString()
                City = dataReader.GetString(9).ToString()
                Region = dataReader.GetString(10).ToString()
                StoreOpen = dataReader.GetString(11).ToString()
                StoreClose = dataReader.GetString(12).ToString()

            Loop

        End Using
    End Sub

    Public Sub New()

    End Sub
End Class
