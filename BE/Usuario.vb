Public Class Usuario

    Private _nombre As String
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Private _pass As String
    Public Property Pass As String
        Get
            Return _pass
        End Get
        Set(value As String)
            _pass = value
        End Set
    End Property

End Class
