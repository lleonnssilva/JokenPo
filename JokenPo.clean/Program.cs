using JokenPo.clean.Entities;
using JokenPo.clean.Enums;

class Programa
{
    public static void Main()
    {
        Console.WriteLine("Bem-vindo ao Jogo Jokenpô!");
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();
        Jogador jogador = new Jogador(nome);

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("0 - Pedra");
            Console.WriteLine("1 - Papel");
            Console.WriteLine("2 - Tesoura");
            Console.Write("Sua escolha: ");
            int escolhaUsuario = int.Parse(Console.ReadLine());

            jogador.FazerEscolha((Opcao)escolhaUsuario);

            Jogo jogo = new Jogo(jogador);
            string resultado = jogo.RodarJogo();

            Console.WriteLine($"\n{jogador.Nome} escolheu: {jogador.Escolha}");
            Console.WriteLine($"O computador escolheu: {jogo.ObterEscolhaComputador()}");
            Console.WriteLine(resultado);

            Console.WriteLine("\nDeseja jogar novamente? (s/n)");
            string resposta = Console.ReadLine().ToLower();
            if (resposta != "s")
                break;
            Console.Clear();
        }
    }
}