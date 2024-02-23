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

            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            //tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(2, 3));

            Tela.ImprimirTabuleiro(tabuleiro);
        }
        catch (TabuleiroException exception)
        {
            System.Console.WriteLine(exception.Message);
        }

    }
}
