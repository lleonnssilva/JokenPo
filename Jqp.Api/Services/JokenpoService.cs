using Jqp.Api.Entities;

namespace Jqp.Api.Services
{
    public class JokenpoService
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _opcoes = { "Pedra", "Papel", "Tesoura" };

        public Jogo Jogar(string escolhaJogador)
        {
            var escolhaComputador = _opcoes[_random.Next(_opcoes.Length)];
            var resultado = DeterminarVencedor(escolhaJogador, escolhaComputador);

            return new Jogo
            {
                JogadorEscolha = escolhaJogador,
                ComputadorEscolha = escolhaComputador,
                Resultado = resultado
            };
        }

        private string DeterminarVencedor(string jogador, string computador)
        {
            if (jogador == computador)
                return "Empate";

            if ((jogador == "Pedra" && computador == "Tesoura") ||
                (jogador == "Tesoura" && computador == "Papel") ||
                (jogador == "Papel" && computador == "Pedra"))
            {
                return "Jogador Venceu";
            }

            return "Computador Venceu";
        }
    }
}
