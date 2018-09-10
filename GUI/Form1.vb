Public Class Form1

    Dim jugadorActual As BE.Jugador
    Dim partida As BE.Partida
    Dim jugar As New BLL.Generala
    Dim turnoActual As BE.Turno
    Dim puntajeBotones As New BE.Puntaje


    Dim dados As New List(Of Bitmap)
    Dim checks As New List(Of CheckBox)
    Dim botones As New List(Of Button)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usuario As New BE.Usuario
        usuario.Nombre = "pepe"

        jugadorActual = New BE.Jugador
        jugadorActual.Usuario = usuario
        jugadorActual.Puntaje = New BE.Puntaje

        partida = New BE.Partida
        partida.Jugadores.Add(jugadorActual)
        partida.Estado = True

        jugar = New BLL.Generala

        turnoActual = jugar.generarTurno()

        dados.Add(My.Resources.dado_0)
        dados.Add(My.Resources.dado_1)
        dados.Add(My.Resources.dado_2)
        dados.Add(My.Resources.dado_3)
        dados.Add(My.Resources.dado_4)
        dados.Add(My.Resources.dado_5)
        dados.Add(My.Resources.dado_6)

        checks.Add(CheckBox1)
        checks.Add(CheckBox2)
        checks.Add(CheckBox3)
        checks.Add(CheckBox4)
        checks.Add(CheckBox5)

        botones.Add(Button3)
        botones.Add(Button4)
        botones.Add(Button5)
        botones.Add(Button6)
        botones.Add(Button7)
        botones.Add(Button8)
        botones.Add(Button9)
        botones.Add(Button10)
        botones.Add(Button11)
        botones.Add(Button12)
        botones.Add(Button13)

        actualizarPantalla()
        For Each boton In botones
            boton.Enabled = False
            boton.Text = ""
        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For i = 0 To 4
            turnoActual.Dados(i).Tomado = checks.Item(i).Checked
        Next

        jugar.tirarDados(turnoActual)

        'turnoActual.Dados(0).Numero = 5
        'turnoActual.Dados(1).Numero = 3
        'turnoActual.Dados(2).Numero = 4
        'turnoActual.Dados(3).Numero = 2
        'turnoActual.Dados(4).Numero = 6

        If turnoActual.Tirada = 3 Then
            Button1.Enabled = False
        End If
        puntajeBotones = jugar.calcularPuntaje(turnoActual)
        actualizarPantalla()

    End Sub

    Private Sub terminarTurno()

        'MessageBox.Show("Turno Terminado")
        jugadorActual.tiradas.Add(turnoActual)
        For i = 0 To 4
            checks.Item(i).Checked = False
        Next
        turnoActual = jugar.generarTurno()
        actualizarPantalla()
        For Each boton In botones
            boton.Enabled = False
            boton.Text = ""
        Next
        If jugadorActual.tiradas.Count < 11 Then
            Button1.Enabled = True
        Else
            terminarPartida()
        End If

    End Sub

    Private Sub terminarPartida()
        partida.Estado = False
        partida.Ganador = jugadorActual
        For Each boton In botones
            boton.Enabled = False
            boton.Text = ""
        Next
        Button1.Enabled = False
        MessageBox.Show("El ganador es: " & partida.Ganador.Usuario.Nombre)
    End Sub

    Private Sub actualizarPantalla()

        For i = 0 To 4
            checks.Item(i).BackgroundImage = dados.Item(turnoActual.Dados(i).Numero)
        Next

        actualizarBotones()

        Label9.Text = turnoActual.Tirada

        ListBox1.DataSource = Nothing
        ListBox1.DataSource = jugadorActual.tiradas

        Dim puntajes As New List(Of String)
        puntajes.Add("Uno      " & jugadorActual.Puntaje.Uno)
        puntajes.Add("Dos      " & jugadorActual.Puntaje.Dos)
        puntajes.Add("Tres     " & jugadorActual.Puntaje.Tres)
        puntajes.Add("Cuatro   " & jugadorActual.Puntaje.Cuatro)
        puntajes.Add("Cinco    " & jugadorActual.Puntaje.Cinco)
        puntajes.Add("Seis     " & jugadorActual.Puntaje.Seis)
        puntajes.Add("Escalera " & jugadorActual.Puntaje.Escalera)
        puntajes.Add("Full     " & jugadorActual.Puntaje.Full)
        puntajes.Add("Poker    " & jugadorActual.Puntaje.Poker)
        puntajes.Add("Generala " & jugadorActual.Puntaje.Generala)
        puntajes.Add("Doble    " & jugadorActual.Puntaje.GeneralaDoble)
        ListBox2.DataSource = Nothing
        ListBox2.DataSource = puntajes
    End Sub

    Private Sub actualizarBotones()

        If puntajeBotones.Uno = 0 AndAlso jugadorActual.Puntaje.Uno = 0 Then
            Button3.Text = "Tachar Uno"
            Button3.Enabled = True
        ElseIf jugadorActual.Puntaje.Uno <> 0 Then
            Button3.Text = "Anotado"
            Button3.Enabled = False
        Else
            Button3.Text = puntajeBotones.Uno & " al Uno"
            Button3.Enabled = True
        End If

        If puntajeBotones.Dos = 0 AndAlso jugadorActual.Puntaje.Dos = 0 Then
            Button4.Text = "Tachar Dos"
            Button4.Enabled = True
        ElseIf jugadorActual.Puntaje.dos <> 0 Then
            Button4.Text = "Anotado"
            Button4.Enabled = False
        Else
            Button4.Text = puntajeBotones.Dos & " al Dos"
            Button4.Enabled = True
        End If

        If puntajeBotones.Tres = 0 AndAlso jugadorActual.Puntaje.Tres = 0 Then
            Button5.Text = "Tachar Tres"
            Button5.Enabled = True
        ElseIf jugadorActual.Puntaje.Tres <> 0 Then
            Button5.Text = "Anotado"
            Button5.Enabled = False
        Else
            Button5.Text = puntajeBotones.Tres & " al Tres"
            Button5.Enabled = True
        End If

        If puntajeBotones.Cuatro = 0 AndAlso jugadorActual.Puntaje.Cuatro = 0 Then
            Button6.Text = "Tachar Cuatro"
            Button6.Enabled = True
        ElseIf jugadorActual.Puntaje.Cuatro <> 0 Then
            Button6.Text = "Anotado"
            Button6.Enabled = False
        Else
            Button6.Text = puntajeBotones.Cuatro & " al Cuatro"
            Button6.Enabled = True
        End If

        If puntajeBotones.Cinco = 0 AndAlso jugadorActual.Puntaje.Cinco = 0 Then
            Button7.Text = "Tachar Cinco"
            Button7.Enabled = True
        ElseIf jugadorActual.Puntaje.Cinco <> 0 Then
            Button7.Text = "Anotado"
            Button7.Enabled = False
        Else
            Button7.Text = puntajeBotones.Cinco & " al Cinco"
            Button7.Enabled = True
        End If

        If puntajeBotones.Seis = 0 AndAlso jugadorActual.Puntaje.Seis = 0 Then
            Button8.Text = "Tachar Seis"
            Button8.Enabled = True
        ElseIf jugadorActual.Puntaje.Seis <> 0 Then
            Button8.Text = "Anotado"
            Button8.Enabled = False
        Else
            Button8.Text = puntajeBotones.Seis & " al Seis"
            Button8.Enabled = True
        End If


        If puntajeBotones.Escalera = 0 AndAlso jugadorActual.Puntaje.Escalera = 0 Then
            Button9.Text = "Tachar Escalera"
            Button9.Enabled = True
        ElseIf jugadorActual.Puntaje.Escalera <> 0 Then
            Button9.Text = "Anotado"
            Button9.Enabled = False
        Else
            Button9.Text = puntajeBotones.Escalera & " a Escalera"
            Button9.Enabled = True
        End If

        If puntajeBotones.Full = 0 AndAlso jugadorActual.Puntaje.Full = 0 Then
            Button10.Text = "Tachar Full"
            Button10.Enabled = True
        ElseIf jugadorActual.Puntaje.Full <> 0 Then
            Button10.Text = "Anotado"
            Button10.Enabled = False
        Else
            Button10.Text = puntajeBotones.Full & " a Full"
            Button10.Enabled = True
        End If

        If puntajeBotones.Poker = 0 AndAlso jugadorActual.Puntaje.Poker = 0 Then
            Button11.Text = "Tachar Poker"
            Button11.Enabled = True
        ElseIf jugadorActual.Puntaje.Poker <> 0 Then
            Button11.Text = "Anotado"
            Button11.Enabled = False
        Else
            Button11.Text = puntajeBotones.Poker & " a Poker"
            Button11.Enabled = True
        End If

        If puntajeBotones.Generala = 0 AndAlso jugadorActual.Puntaje.Generala = 0 Then
            Button12.Text = "Tachar Generala"
            Button12.Enabled = True
        ElseIf jugadorActual.Puntaje.Generala <> 0 Then
            Button12.Text = "Anotado"
            Button12.Enabled = False
        Else
            Button12.Text = puntajeBotones.Generala & " a Generala"
            Button12.Enabled = True
        End If

        If puntajeBotones.GeneralaDoble = 0 AndAlso jugadorActual.Puntaje.GeneralaDoble = 0 Then
            Button13.Text = "Tachar Generala Doble"
            Button13.Enabled = True
        ElseIf jugadorActual.Puntaje.GeneralaDoble <> 0 Then
            Button13.Text = "Anotado"
            Button13.Enabled = False
        Else
            Button13.Text = puntajeBotones.GeneralaDoble & " a Generala Doble"
            Button13.Enabled = True
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If puntajeBotones.Uno = 0 Then
            jugadorActual.Puntaje.Uno = -1
        Else
            jugadorActual.Puntaje.Uno = puntajeBotones.Uno
        End If
        terminarTurno()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If puntajeBotones.Dos = 0 Then
            jugadorActual.Puntaje.Dos = -1
        Else
            jugadorActual.Puntaje.Dos = puntajeBotones.Dos
        End If
        terminarTurno()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If puntajeBotones.Tres = 0 Then
            jugadorActual.Puntaje.Tres = -1
        Else
            jugadorActual.Puntaje.Tres = puntajeBotones.Tres
        End If
        terminarTurno()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If puntajeBotones.Cuatro = 0 Then
            jugadorActual.Puntaje.Cuatro = -1
        Else
            jugadorActual.Puntaje.Cuatro = puntajeBotones.Cuatro
        End If
        terminarTurno()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If puntajeBotones.Cinco = 0 Then
            jugadorActual.Puntaje.Cinco = -1
        Else
            jugadorActual.Puntaje.Cinco = puntajeBotones.Cinco
        End If
        terminarTurno()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If puntajeBotones.Seis = 0 Then
            jugadorActual.Puntaje.Seis = -1
        Else
            jugadorActual.Puntaje.Seis = puntajeBotones.Seis
        End If
        terminarTurno()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If puntajeBotones.Escalera = 0 Then
            jugadorActual.Puntaje.Escalera = -1
        Else
            jugadorActual.Puntaje.Escalera = puntajeBotones.Escalera
        End If
        terminarTurno()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If puntajeBotones.Full = 0 Then
            jugadorActual.Puntaje.Full = -1
        Else
            jugadorActual.Puntaje.Full = puntajeBotones.Full
        End If
        terminarTurno()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If puntajeBotones.Poker = 0 Then
            jugadorActual.Puntaje.Poker = -1
        Else
            jugadorActual.Puntaje.Poker = puntajeBotones.Poker
        End If
        terminarTurno()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If puntajeBotones.Generala = 0 Then
            jugadorActual.Puntaje.Generala = -1
        ElseIf puntajeBotones.Generala = 1000 Then
            terminarPartida()
            Return
        Else
            jugadorActual.Puntaje.Generala = puntajeBotones.Generala
        End If
        terminarTurno()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If puntajeBotones.GeneralaDoble = 0 Then
            jugadorActual.Puntaje.GeneralaDoble = -1
        Else
            jugadorActual.Puntaje.GeneralaDoble = puntajeBotones.GeneralaDoble
        End If
        terminarTurno()
    End Sub
End Class
