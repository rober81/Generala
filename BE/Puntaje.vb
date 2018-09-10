Public Class Puntaje

    Private _uno As Integer
    Private _dos As Integer
    Private _tres As Integer
    Private _cuatro As Integer
    Private _cinco As Integer
    Private _seis As Integer
    Private _poker As Integer
    Private _full As Integer
    Private _escalera As Integer
    Private _generala As Integer
    Private _generalaDoble As Integer

    Public Property Uno As Integer
        Get
            Return _uno
        End Get
        Set(value As Integer)
            _uno = value
        End Set
    End Property

    Public Property Dos As Integer
        Get
            Return _dos
        End Get
        Set(value As Integer)
            _dos = value
        End Set
    End Property

    Public Property Tres As Integer
        Get
            Return _tres
        End Get
        Set(value As Integer)
            _tres = value
        End Set
    End Property

    Public Property Cuatro As Integer
        Get
            Return _cuatro
        End Get
        Set(value As Integer)
            _cuatro = value
        End Set
    End Property

    Public Property Cinco As Integer
        Get
            Return _cinco
        End Get
        Set(value As Integer)
            _cinco = value
        End Set
    End Property

    Public Property Seis As Integer
        Get
            Return _seis
        End Get
        Set(value As Integer)
            _seis = value
        End Set
    End Property

    Public Property Poker As Integer
        Get
            Return _poker
        End Get
        Set(value As Integer)
            _poker = value
        End Set
    End Property

    Public Property Full As Integer
        Get
            Return _full
        End Get
        Set(value As Integer)
            _full = value
        End Set
    End Property

    Public Property Escalera As Integer
        Get
            Return _escalera
        End Get
        Set(value As Integer)
            _escalera = value
        End Set
    End Property

    Public Property Generala As Integer
        Get
            Return _generala
        End Get
        Set(value As Integer)
            _generala = value
        End Set
    End Property

    Public Property GeneralaDoble As Integer
        Get
            Return _generalaDoble
        End Get
        Set(value As Integer)
            _generalaDoble = value
        End Set
    End Property
End Class
