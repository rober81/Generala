Public Class Tirada
    Private _numero As Integer

    Private _dados As New List(Of Dado)
    Public ReadOnly Property Dados As List(Of Dado)
        Get
            Return _dados
        End Get
    End Property

    Public Property Numero As Integer
        Get
            Return _numero
        End Get
        Set(value As Integer)
            _numero = value
        End Set
    End Property
End Class
