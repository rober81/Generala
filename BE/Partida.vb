Imports BE

Public Class Partida

    Private _jugadores As New List(Of Jugador)
    Private _ganador As Jugador
    Private _estado As Boolean

    Public Property Jugadores As List(Of Jugador)
        Get
            Return _jugadores
        End Get
        Set(value As List(Of Jugador))
            _jugadores = value
        End Set
    End Property

    Public Property Ganador As Jugador
        Get
            Return _ganador
        End Get
        Set(value As Jugador)
            _ganador = value
        End Set
    End Property

    Public Property Estado As Boolean
        Get
            Return _estado
        End Get
        Set(value As Boolean)
            _estado = value
        End Set
    End Property
End Class
