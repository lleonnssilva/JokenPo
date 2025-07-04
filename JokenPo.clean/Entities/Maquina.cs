using JokenPo.clean.Enums;

namespace JokenPo.clean.Entities
{
    public class Maquina : Jogador
    {
        private Random _random;
        public Maquina(string nome)
        {
            Nome = nome;
            _random = new Random();
        }

        public override void FazerJogada()
        {
            JogadaEscolhida = (OpcaoJogador)_random.Next(0, 3); 
            Console.WriteLine($"A {Nome} escolheu {JogadaEscolhida}");
        }
    }

}
