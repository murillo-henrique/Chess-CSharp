using TabuleiroF;
using Xadrez;

namespace Game;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.Terminada)
            {

                try
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tabuleiro.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDeDestino(origem, destino);

                    partida.RealizarJogada(origem, destino);
                }
                catch (TabuleiroException exception)
                {
                    System.Console.WriteLine(exception.Message);
                    Console.ReadLine();
                }
            }
        }
        catch (TabuleiroException exception)
        {
            System.Console.WriteLine(exception.Message);
        }

    }
}
