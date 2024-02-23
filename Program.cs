using TabuleiroF;
using Xadrez;

namespace Game;

class Program
{
    static void Main(string[] args)
    {
        Tabuleiro tabuleiro = new Tabuleiro(8, 8);

        Tela.ImprimirTabuleiro(tabuleiro);


    }
}
