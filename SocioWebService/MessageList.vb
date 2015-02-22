Public Class MessageList

    Private lofferid, lsender As Integer
    Private lsubject, lmessage, lsent As String
    Private lempId As String, lLastMessage As Integer

    Public Sub New(ByVal empId As String, ByVal LastMessage As Integer)

        lempId = empId
        lLastMessage = LastMessage

    End Sub

    Public Property subject() As String
        Get
            Return lsubject
        End Get

        Set(ByVal subject As String)
            lsubject = subject
        End Set
    End Property

    Public Property message() As String
        Get
            Return lmessage
        End Get

        Set(ByVal message As String)
            lmessage = message
        End Set
    End Property

    Public Property sent() As String
        Get
            Return lsent
        End Get

        Set(sent As String)
            lsent = sent
        End Set
    End Property

    Public Property offerId() As Integer
        Get
            Return lofferid
        End Get

        Set(offerId As Integer)
            lofferid = offerId
        End Set

    End Property

End Class
