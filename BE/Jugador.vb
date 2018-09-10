Public Class Jugador

    Private _tiradas As New List(Of Turno)
    Private _usuario As Usuario
    Private _puntaje As Puntaje

    Public ReadOnly Property tiradas As List(Of Turno)
        Get
            Return _tiradas
        End Get
    End Property

    Public Property Usuario As Usuario
        Get
            Return _usuario
        End Get
        Set(value As Usuario)
            _usuario = value
        End Set
    End Property

    Public Property Puntaje As Puntaje
        Get
            Return _puntaje
        End Get
        Set(value As Puntaje)
            _puntaje = value
        End Set
    End Property

End Class
