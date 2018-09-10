Public Class Dado

    Private _numero As Integer
    Public Property Numero As Integer
        Get
            Return _numero
        End Get
        Set(value As Integer)
            _numero = value
        End Set
    End Property

    Private _tomado As Boolean = False
    Public Property Tomado As Boolean
        Get
            Return _tomado
        End Get
        Set(value As Boolean)
            _tomado = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return "Dado: " & _numero
    End Function
End Class
