Imports BE
Public Class Generala
    Private _cantidadTurnos As Integer = 3
    Private _cantidadDados As Integer = 4
    Private _minimo As Integer = 1
    Private _maximo As Integer = 7

    Public Function tirarDados(turno As Turno) As Boolean
        If turno.Tirada < _cantidadTurnos Then
            For Each dado In turno.Dados
                If dado.Tomado = False Then
                    tirar(dado)
                End If
            Next
        Else
            Return False
        End If
        turno.Tirada += 1
        Return True
    End Function

    Private Function tirar(unDado As Dado) As Dado
        Static Generator As System.Random = New System.Random()
        unDado.Numero = Generator.Next(_minimo, _maximo)
        Return unDado
    End Function

    Public Function generarTurno() As Turno
        Dim turno As New Turno
        For i = 0 To _cantidadDados
            turno.Dados.Add(New Dado())
        Next
        Return turno
    End Function

    Private Function calcularNumero(unTurno As Turno, num As Integer) As Integer
        Dim total As Integer
        For Each dado In unTurno.Dados
            If dado.Numero = num Then
                total += dado.Numero
            End If
        Next
        Return total
    End Function

    Private Function calcularIguales(unTurno As Turno, num As Integer) As Integer
        Dim total As Integer
        For Each dado In unTurno.Dados
            If dado.Numero = num Then
                total += 1
            End If
        Next
        Return total
    End Function

    Private Function calcularEscalera(unTurno As Turno) As Integer
        '20 o 25
        Dim listaOrdenada As New List(Of BE.Dado)
        listaOrdenada.AddRange(unTurno.Dados)
        listaOrdenada.Sort(New OrdenarDados)
        Dim salida As String = ""
        For Each num In listaOrdenada
            salida = salida & num.Numero
        Next
        If salida = "12345" Or salida = "13456" Or salida = "23456" Then
            If unTurno.Tirada = 1 Then
                Return 25 'servida
            Else
                Return 20
            End If
        End If
        Return 0
    End Function

    Private Function calcularFull(unTurno As Turno) As Integer
        '30 o 35
        Dim tres As Boolean
        Dim dos As Boolean
        For i = 1 To 6
            If calcularIguales(unTurno, i) = 3 Then
                tres = True
            End If
            If calcularIguales(unTurno, i) = 2 Then
                dos = True
            End If
        Next
        If unTurno.Tirada = 1 AndAlso tres AndAlso dos Then
            Return 35 'servida
        ElseIf tres AndAlso dos Then
            Return 30
        End If
        Return 0
    End Function

    Private Function calcularPoker(unTurno As Turno) As Integer
        '40 o 45
        For i = 1 To 6
            If calcularIguales(unTurno, i) = 4 Then
                If unTurno.Tirada = 1 Then
                    Return 45 'servida
                Else
                    Return 40
                End If
            End If
        Next
        Return 0
    End Function

    Private Function calcularGenerala(unTurno As Turno) As Integer
        '50 o gana
        For i = 1 To 6
            If calcularIguales(unTurno, i) = 5 Then
                If unTurno.Tirada = 1 Then
                    Return 1000 'servida y gano
                Else
                    Return 50
                End If
            End If
        Next
        Return 0
    End Function

    Private Function calcularGeneralaDoble(unTurno As Turno) As Integer
        '100 
        Dim total As Integer = calcularGenerala(unTurno)
        If total > 0 Then
            total = 100
        End If
        Return total
    End Function

    Public Function calcularPuntaje(unTurno As Turno) As Puntaje

        Dim unPuntaje As New Puntaje

        If unPuntaje.Uno = 0 Then
            unPuntaje.Uno = calcularNumero(unTurno, 1)
        End If
        If unPuntaje.Dos = 0 Then
            unPuntaje.Dos = calcularNumero(unTurno, 2)
        End If
        If unPuntaje.Tres = 0 Then
            unPuntaje.Tres = calcularNumero(unTurno, 3)
        End If
        If unPuntaje.Cuatro = 0 Then
            unPuntaje.Cuatro = calcularNumero(unTurno, 4)
        End If
        If unPuntaje.Cinco = 0 Then
            unPuntaje.Cinco = calcularNumero(unTurno, 5)
        End If
        If unPuntaje.Seis = 0 Then
            unPuntaje.Seis = calcularNumero(unTurno, 6)
        End If
        If unPuntaje.Escalera = 0 Then
            unPuntaje.Escalera = calcularEscalera(unTurno)
        End If
        If unPuntaje.Full = 0 Then
            unPuntaje.Full = calcularFull(unTurno)
        End If
        If unPuntaje.Poker = 0 Then
            unPuntaje.Poker = calcularPoker(unTurno)
        End If
        If unPuntaje.Generala = 0 Then
            unPuntaje.Generala = calcularGenerala(unTurno)
        End If
        If unPuntaje.Generala > 0 Then
            unPuntaje.GeneralaDoble = calcularGeneralaDoble(unTurno)
        End If

        Return unPuntaje
    End Function

End Class
