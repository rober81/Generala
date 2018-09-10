Public Class Turno
    Private _numero As Integer

    Private _dados As New List(Of Dado)
    Public ReadOnly Property Dados As List(Of Dado)
        Get
            Return _dados
        End Get
    End Property

    Private _tirada As Integer
    Public Property Tirada As Integer
        Get
            Return _tirada
        End Get
        Set(value As Integer)
            _tirada = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim salida As String = ""
        For Each Dado In _dados
            salida = salida & " " & Dado.ToString
        Next
        Return salida
    End Function
End Class
