using JokenPo.clean.Enums;

namespace JokenPo.clean.Entities
{
    public abstract class Jogador
    {
        public string Nome { get; protected set; }
        public OpcaoJogador JogadaEscolhida { get; protected set; }
        public abstract void FazerJogada();

        
    }
}
