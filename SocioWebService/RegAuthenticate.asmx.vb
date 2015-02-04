Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class RegAuthenticate
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String

        Return "Hello World"

    End Function

    <WebMethod()> _
    Public Function isEmployeeExists(ByVal EmpId As String, ByVal MobileNo As String, ByVal Email As String) As String

        Dim connectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()

        ' Provide the query string with a parameter placeholder. 

        Dim strempId As String = ""
        Dim randomNum As String = ""
        
        Dim queryString As String = _
            "SELECT id from dbo.Employee " _
            & "WHERE EmpId = @EmpId " _
            & "AND Email = @Email " _
            & "AND MobileNo = @MobileNo"


        Using connection As New SqlConnection(connectionString)

            Dim command As New SqlCommand(queryString, connection)

            command.Parameters.AddWithValue("@EmpId", EmpId)
            command.Parameters.AddWithValue("@Email", Email)
            command.Parameters.AddWithValue("@MobileNo", MobileNo)

            Try
                connection.Open()
                Dim dataReader As SqlDataReader = _
                 command.ExecuteReader()

                If dataReader.HasRows Then
                    Randomize()
                    randomNum = (Int(Rnd() * 10000)).ToString()
                    Do While dataReader.Read()
                        strempId = dataReader.GetInt32(0).ToString
                    Loop
                    Return strempId + "," + randomNum

                Else
                    Return "wrong"
                End If

            Catch ex As Exception
                Return ex.Message

            End Try

        End Using


    End Function

    <WebMethod()> _
    Public Function logAttendance(Latitude As String, ByVal Longitude As String, ByVal EmpId As String, ByVal LogFlag As String) As String

        Dim insertStatement As String
        Dim connectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()

        insertStatement = "INSERT INTO [dbo].[Attendance] ([LoginDateTime], [Latitude], [Longitude], [EmpId], [LogFlag]) VALUES (dbo.GetLocalDate(DEFAULT), @Latitude, @Longitude, @EmpId, @LogFlag)"

        Using connection As New SqlConnection(connectionString)

            Dim command As New SqlCommand(insertStatement, connection)

            command.Parameters.AddWithValue("@Latitude", Latitude)
            command.Parameters.AddWithValue("@Longitude", Longitude)
            command.Parameters.AddWithValue("@EmpId", EmpId)
            command.Parameters.AddWithValue("@LogFlag", LogFlag)

            connection.Open()

            Try
                command.ExecuteNonQuery()
            Catch ex As Exception
                Return ex.Message
            End Try

            Return "Success"

        End Using

    End Function

End Class