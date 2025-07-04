using JokenPo.clean.Entities;
using JokenPo.clean.Enums;

class Programa
{
    public static void Main()
    {
        Console.WriteLine("Bem-vindo ao Jogo Jokenpô!");
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        while (true)
        {

            Jogo jogo = new Jogo(nome,"Maquina");
            Console.WriteLine("\nEscolha uma opção:");

            foreach (var opcao in Enum.GetValues(typeof(OpcaoJogador)))
            {
                Console.WriteLine($"{(int)opcao} - {opcao}");
            }
            Console.WriteLine("S - Sair");

            jogo.Iniciar();

            Console.WriteLine("Jogo Finalizado!");
            Console.WriteLine("\nDeseja jogar novamente? (s/n)");
            string resposta = Console.ReadLine().ToLower();

            if (resposta != "s")
                break;
            Console.Clear();

        }
    }
}