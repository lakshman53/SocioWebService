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
    Public Function getcurrentDateTime() As String

        Dim selectStatement As String
        Dim connectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()

        selectStatement = "SELECT datename(weekday, dbo.GetLocalDate(DEFAULT) ) + ', ' + convert(nvarchar(50), dbo.GetLocalDate(DEFAULT), 100)"

        Using connection As New SqlConnection(connectionString)

            Dim command As New SqlCommand(selectStatement, connection)
            connection.Open()
            Dim dataReader As SqlDataReader = command.ExecuteReader()

            Do While dataReader.Read()
                getcurrentDateTime = dataReader.GetString(0).ToString()
            Loop

            Return getcurrentDateTime
        End Using

    End Function

    <WebMethod()> _
    Public Function logAttendance(Latitude As String, ByVal Longitude As String, ByVal GPID As String, ByVal DistanceFromStore As Integer, ByVal LogFlag As String) As Integer

        Dim sqlStatement As String
        Dim connectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()

        If LogFlag = "A" Then
            sqlStatement = "INSERT INTO [dbo].[Attendance] ([InLoginDateTime], [InLatitude], [InLongitude], [EmpId], [InDistanceFromStore]) VALUES (dbo.GetLocalDate(DEFAULT), @Latitude, @Longitude, @GPID, @DistanceFromStore)"
        Else
            sqlStatement = "UPDATE [dbo].[Attendance] SET [OutLoginDateTime] = dbo.GetLocalDate(DEFAULT), [OutLatitude] = @Latitude, [OutLongitude] = @Longitude, [OutDistanceFromStore] = @DistanceFromStore WHERE Id =  @GPID"
        End If

        Using connection As New SqlConnection(connectionString)

            Dim command As New SqlCommand(sqlStatement, connection)

            command.Parameters.AddWithValue("@Latitude", Latitude)
            command.Parameters.AddWithValue("@Longitude", Longitude)
            command.Parameters.AddWithValue("@GPID", GPID)
            command.Parameters.AddWithValue("@DistanceFromStore", DistanceFromStore)

            connection.Open()

            Try

                If LogFlag = "A" Then
                    command.ExecuteNonQuery()

                    Dim lastIdentityQueryString As String = "SELECT MAX(ID) FROM ATTENDANCE WHERE EMPID = " + GPID
                    command = New SqlCommand(lastIdentityQueryString, connection)
                    Dim dataReader As SqlDataReader = command.ExecuteReader()
                    Dim generatedId As Integer = 0
                    Do While dataReader.Read()
                        generatedId = dataReader.GetInt32(0).ToString
                    Loop

                    Return generatedId
                Else
                    Dim numRowsaffected As Integer = command.ExecuteNonQuery()
                    If numRowsaffected = 1 Then
                        Return GPID
                    Else
                        sqlStatement = "INSERT INTO [dbo].[Attendance] ([OutLoginDateTime], [OutLatitude], [OutLongitude], [EmpId], [OutDistanceFromStore]) VALUES (dbo.GetLocalDate(DEFAULT), @Latitude, @Longitude, @GPID, @DistanceFromStore)"
                        command.Parameters.AddWithValue("@Latitude", Latitude)
                        command.Parameters.AddWithValue("@Longitude", Longitude)
                        command.Parameters.AddWithValue("@GPID", GPID)
                        command.Parameters.AddWithValue("@DistanceFromStore", DistanceFromStore)

                        command.ExecuteNonQuery()

                        Dim lastIdentityQueryString As String = "SELECT SCOPE_IDENTITY()"
                        command = New SqlCommand(lastIdentityQueryString, connection)
                        Dim dataReader As SqlDataReader = command.ExecuteReader()
                        Dim generatedId As Integer = 0
                        Do While dataReader.Read()
                            generatedId = dataReader.GetInt32(0).ToString
                        Loop

                        Return generatedId

                    End If
                End If

            Catch ex As Exception
                Return -1
            End Try
        End Using
    End Function

End Class