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
    Public Function isEmployeeExists(ByVal EmpId As String, ByVal MobileNo As String, ByVal Email As String) As Boolean
        Dim connectionString As String = _
            "Server=tcp:mqjkakgxkk.database.windows.net,1433;Database=sociodb;" & _
                                    "User ID=laks@mqjkakgxkk;Password=sqlPassword@123;" & _
                                            "Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"

        ' Provide the query string with a parameter placeholder. 
        Dim queryString As String = _
            "SELECT count(1) from dbo.vEmployee " _
            & "WHERE EmpId = @EmpId " _
            & "AND Email = @Email " _
            & "AND MobileNo = @MobileNo"

        ' Create and open the connection in a using block. This 
        ' ensures that all resources will be closed and disposed 
        ' when the code exits. 

        Using connection As New SqlConnection(connectionString)

            ' Create the Command and Parameter objects. 
            Dim command As New SqlCommand(queryString, connection)

            command.Parameters.AddWithValue("@EmpId", EmpId)
            command.Parameters.AddWithValue("@Email", Email)
            command.Parameters.AddWithValue("@MobileNo", MobileNo)


            ' Open the connection in a try/catch block.  
            ' Create and execute the DataReader, writing the result 
            ' set to the console window. 
            Try
                connection.Open()
                Dim dataReader As SqlDataReader = _
                 command.ExecuteReader()

                Do While dataReader.Read()
                    If dataReader(0) = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Loop
                dataReader.Close()

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Console.ReadLine()
        End Using

    End Function

End Class