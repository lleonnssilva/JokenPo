using JokenPo.clean.Enums;

namespace JokenPo.clean.Entities
{
    public class Jogo
    {
        private Jogador _jogadorHumano;
        private Jogador _jogadorMaquina;

        public Jogo(string nomeJogador, string nomeMaquina)
        {
            _jogadorHumano = new Humano(nomeJogador);
            _jogadorMaquina = new Maquina(nomeMaquina);
        }

        private bool ValidarJogada()
        {
            return Enum.IsDefined(typeof(OpcaoJogador), _jogadorHumano.JogadaEscolhida);
        }

        public void Iniciar()
        {

            _jogadorHumano.FazerJogada();
            _jogadorMaquina.FazerJogada();

            if (!ValidarJogada())
            {
                Console.WriteLine("Jogada inválida!");
                return;
            }
            VerificarVencedor();
        }
        private void VerificarVencedor()
        {
            if (_jogadorHumano.JogadaEscolhida == _jogadorMaquina.JogadaEscolhida)
            {
                Console.WriteLine("Empate!");
            }
            else if ((_jogadorHumano.JogadaEscolhida == OpcaoJogador.Pedra && _jogadorMaquina.JogadaEscolhida == OpcaoJogador.Tesoura) ||
                     (_jogadorHumano.JogadaEscolhida == OpcaoJogador.Papel && _jogadorMaquina.JogadaEscolhida == OpcaoJogador.Pedra) ||
                     (_jogadorHumano.JogadaEscolhida == OpcaoJogador.Tesoura && _jogadorMaquina.JogadaEscolhida == OpcaoJogador.Papel))
            {
                Console.WriteLine($"{_jogadorHumano.Nome} venceu!");
            }
            else
            {
                Console.WriteLine($"{_jogadorMaquina.Nome} venceu!");
            }
        }
    }
}
