using JokenPo.clean.Enums;

namespace JokenPo.clean.Entities
{
    public class Humano : Jogador
    {
        public Humano(string nome)
        {
            Nome = nome;
        }

        public override void FazerJogada()
        {
            string escolha = Console.ReadLine();

            if(escolha =="S" || escolha == "s")
                Environment.Exit(0);

            if (!int.TryParse(escolha, out int escolhaUsuario))
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                return;
            }
            JogadaEscolhida = (OpcaoJogador)escolhaUsuario;
            Console.WriteLine($"A {Nome} escolheu {JogadaEscolhida}");
        }
       
    }
}
