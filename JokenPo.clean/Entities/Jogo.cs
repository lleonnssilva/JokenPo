using JokenPo.clean.Enums;

namespace JokenPo.clean.Entities
{
    public class Jogo
    {
        private Jogador jogador;
        private Jogador computador;

        public Jogo(Jogador jogador)
        {
            this.jogador = jogador;
            this.computador = new Jogador("Computador");
        }

        public string RodarJogo()
        {
            computador.FazerEscolha(EscolhaAleatorio());
            string resultado = CompararEscolhas(jogador.Escolha, computador.Escolha);
            return resultado;
        }

        public Opcao ObterEscolhaComputador()
        {
            return computador.Escolha;
        }

        private Opcao EscolhaAleatorio()
        {
            Random random = new Random();
            return (Opcao)random.Next(0, 3);
        }

        private string CompararEscolhas(Opcao escolhaJogador, Opcao escolhaComputador)
        {
            if (!Enum.IsDefined(typeof(Opcao), escolhaJogador) || !Enum.IsDefined(typeof(Opcao), escolhaComputador))
            {
                return "Escolha inválida.";
            }


            if (escolhaJogador == escolhaComputador)
            {
                return "Empate!";
            }

            switch (escolhaJogador)
            {
                case Opcao.Pedra:
                    return escolhaComputador == Opcao.Tesoura ? $"{this.jogador.Nome} venceu!" : "O Computador venceu!";
                case Opcao.Papel:
                    return escolhaComputador == Opcao.Pedra ? $"{this.jogador.Nome} venceu!" : "O Computador venceu!";
                case Opcao.Tesoura:
                    return escolhaComputador == Opcao.Papel ? $"{this.jogador.Nome} venceu!" : "O Computador venceu!";
                default:
                    return "Erro ao comparar opções.";
            }
        }
    }
}
