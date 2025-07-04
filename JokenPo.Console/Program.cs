public class Program
{

    /*
        1-Pedra  vende Tesoura
        2-Papel  vence Pedra
        3-Tesoura vence Papel
    */

    static void Main(string[] args)
    {

        IniciarJogo(false);

    }

    private static void IniciarJogo(bool contraComputador)
    {
        if (contraComputador)
            IniciarJogoContraComputador(contraComputador);
        IniciarJogoContraAdversario(contraComputador);
    }
    private static void IniciarJogoContraAdversario(bool contraComputador)
    {
        string[] opcoes = { "Pedra", "Papel", "Tesoura" };
        Console.WriteLine("Bem-vindo ao Jogo Jokenpo!");
        Console.WriteLine("Escolha uma das opções:");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("1-Pedra");
        Console.WriteLine("2-Papel");
        Console.WriteLine("3-Tesoura");
        Console.WriteLine("0-Sair");
        Console.WriteLine("----------------------------------------------");



        Console.Write("Jogador Hum: ");
        var jogadorHum = RetornarJogada(contraComputador);

        Console.Write("Jogador Dois: ");
        var jogadorDois = RetornarJogada(contraComputador);

        Console.WriteLine($"Jogador Hum escolheu: {opcoes[jogadorHum - 1]}");
        Console.WriteLine($"Jogador Dois escolheu: {opcoes[jogadorDois - 1]}");

        string resultado = VerificarVencedorContraAdversario(opcoes[jogadorHum - 1], opcoes[jogadorDois - 1]);
        Console.WriteLine(resultado);

        FimDeJogo(false);
    }
    private static void IniciarJogoContraComputador(bool contraComputador)
    {
        string[] opcoes = { "Pedra", "Papel", "Tesoura" };
        Console.WriteLine("Bem-vindo ao Jogo Jokenpo!");
        Console.WriteLine("Escolha uma das opções:");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("1-Pedra");
        Console.WriteLine("2-Papel");
        Console.WriteLine("3-Tesoura");
        Console.WriteLine("0-Sair");
        Console.WriteLine("----------------------------------------------");

        var jogadorHum = RetornarJogada(contraComputador);

        string escolhaComputador = GerarEscolhaComputador();
        Console.WriteLine($"Você escolheu: {opcoes[jogadorHum - 1]}");
        Console.WriteLine($"O computador escolheu: {escolhaComputador}");

        string resultado = VerificarVencedorContraComputador(opcoes[jogadorHum - 1], escolhaComputador);
        Console.WriteLine(resultado);

        FimDeJogo(true);
    }
    static string GerarEscolhaComputador()
    {
        Random rand = new Random();
        int escolha = rand.Next(0, 3);
        string[] opcoes = { "Pedra", "Papel", "Tesoura" };
        return opcoes[escolha];
    }
    static string VerificarVencedorContraComputador(string jogador1, string jogador2)
    {
        if (jogador1 == jogador2)
        {
            return "Deu Empate!";
        }

        if ((jogador1 == "Pedra" && jogador2 == "Tesoura") ||
            (jogador1 == "Papel" && jogador2 == "Pedra") ||
            (jogador1 == "Tesoura" && jogador2 == "Papel"))
        {
            return "Você venceu!";
        }

        return $"O Computador venceu!";
    }
    static string VerificarVencedorContraAdversario(string jogador1, string jogador2)
    {
        if (jogador1 == jogador2)
        {
            return "Empate!";
        }

        if ((jogador1 == "Pedra" && jogador2 == "Tesoura") ||
            (jogador1 == "Papel" && jogador2 == "Pedra") ||
            (jogador1 == "Tesoura" && jogador2 == "Papel"))
        {
            return "Jogador Hum Você venceu!";
        }

        return $"O Jogador Dois venceu!";
    }

    private static int RetornarJogada(bool contraComputador)
    {


        var resultado = 0;
        var jogadaAtual = Console.ReadLine();
        if (jogadaAtual == "0")
        {
            Console.WriteLine("Saindo do jogo...");
            Environment.Exit(0);
        }



        if (!int.TryParse(jogadaAtual, out resultado) || (resultado < 1 || resultado > 3))
        {
            JogadaIrregular(contraComputador);
            IniciarJogo(contraComputador);
        }

        return resultado;
    }

    private static void JogadaIrregular(bool contraComputador)
    {
        Console.WriteLine("Jogada irregular. Pressione qualquer tecla para tentar novamente...");
        Console.ReadKey();
        Console.Clear();
        if (contraComputador)
            IniciarJogoContraComputador(contraComputador);
        IniciarJogo(contraComputador);
    }

    private static void FimDeJogo(bool contraComputador)
    {
        Console.WriteLine();
        Console.WriteLine("Fim de jogo");
        Console.WriteLine("Pressione 0 para sair ou qualquer tecla para reiniciar o jogo.");

        var teclaEscolha = Console.ReadKey();

        if (teclaEscolha.Key == ConsoleKey.D0 || teclaEscolha.Key == ConsoleKey.NumPad0)
            Environment.Exit(0);

        else
        {
            Console.Clear();
            if (contraComputador)
                IniciarJogoContraComputador(contraComputador);
            IniciarJogo(contraComputador);
        }

    }
}
