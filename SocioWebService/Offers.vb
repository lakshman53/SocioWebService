Imports System.Data.SqlClient




Public Class Offers

    'Public Subject, Offer, Sent As String
    Public datatable As New DataTable

    Public Sub New(ByVal EmpId As Integer, ByVal LastOfferId As Integer)
        Dim selectStatement As String
        Dim connectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()

        selectStatement = "SELECT  Offer.subject, Offer.message, convert(nvarchar(10),Offer.sent,105) + ' ' + convert(nvarchar(5),Offer.sent,108) [SentAt] FROM OfferGroups INNER JOIN Offer ON OfferGroups.OfferId = Offer.OfferId INNER JOIN"
        selectStatement = selectStatement + " [Group] ON OfferGroups.GroupId = [Group].GroupId INNER JOIN"
        selectStatement = selectStatement + " EmpGroups ON [Group].GroupId = EmpGroups.GroupId INNER JOIN"
        selectStatement = selectStatement + " Employee ON EmpGroups.EmpId = Employee.EmpId"
        selectStatement = selectStatement + " WHERE Employee.EmpId = " + EmpId.ToString + " And Offer.OFFERID > " + LastOfferId.ToString
        selectStatement = selectStatement + " ORDER BY Offer.SENT DESC"

        Using connection As New SqlConnection(connectionString)

            Dim command As New SqlCommand(selectStatement, connection)
            connection.Open()
            Dim dataReader As SqlDataReader = command.ExecuteReader()

            Dim colCnt As Integer = dataReader.FieldCount
            datatable.Columns.Add("Subject")
            datatable.Columns.Add("Offer")
            datatable.Columns.Add("SentAt")
            datatable.TableName = "Offers"
            If dataReader.HasRows Then
                datatable.Load(dataReader)
            Else

            End If

        End Using


    End Sub
    Public Sub New()

    End Sub
End Class
