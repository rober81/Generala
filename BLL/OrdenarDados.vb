Imports BE

Public Class OrdenarDados
    Implements IComparer(Of BE.Dado)

    Public Function Compare(x As Dado, y As Dado) As Integer Implements IComparer(Of Dado).Compare
        Return x.Numero.CompareTo(y.Numero)
    End Function
End Class
