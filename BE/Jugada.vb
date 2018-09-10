Public Class Jugada

    Private _dados As New List(Of Dado)
    Public ReadOnly Property Dados As List(Of Dado)
        Get
            Return _dados
        End Get
    End Property

    Private _usuario As Usuario
    Public Property Usuario As Usuario
        Get
            Return _usuario
        End Get
        Set(value As Usuario)
            _usuario = value
        End Set
    End Property

    Private uno As Integer
    Private dos As Integer
    Private tres As Integer
    Private cuatro As Integer
    Private cinco As Integer
    Private seis As Integer
    Private poker As Integer
    Private full As Integer
    Private escalera As Integer
    Private generala As Integer
    Private generalaDoble As Integer
End Class
