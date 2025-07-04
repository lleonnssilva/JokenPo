using JokenPo.clean.Enums;

namespace JokenPo.clean.Entities
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public Opcao Escolha { get; private set; }

        public Jogador(string nome)
        {
            Nome = nome;
        }

        public void FazerEscolha(Opcao escolha)
        {
            Escolha = escolha;
        }
    }
}
