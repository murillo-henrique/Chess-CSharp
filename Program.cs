using TabuleiroF;
using Xadrez;

namespace Game;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        try
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.Terminada)
            {
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.tabuleiro);

                Console.WriteLine();
                Console.Write("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                bool[,] posicoesPossiveis = partida.tabuleiro.Peca(origem).movimentosPossiveis();

                Console.Clear();
                Tela.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);

                Console.WriteLine();
                Console.Write("Destino: ");
                Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                partida.ExecutarMovimento(origem, destino);
            }
        }
        catch (TabuleiroException exception)
        {
            System.Console.WriteLine(exception.Message);
        }

    }
}
