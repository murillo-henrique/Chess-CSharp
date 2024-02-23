using TabuleiroF;
using Xadrez;

namespace Game;

class Tela
{
    public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
    {
        for (int linha = 0; linha < tabuleiro.Linhas; linha++)
        {
            Console.Write(8 - linha + " ");
            for (int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
            {
                if (tabuleiro.Peca(linha, coluna) == null)
                {
                    Console.Write("- ");
                }
                else
                {
                    ImprimirPeca(tabuleiro.Peca(linha, coluna));
                    Console.Write(" ");
                }
            }

            System.Console.WriteLine();
        }
        System.Console.WriteLine("  a b c d e f g h");
    }

    public static PosicaoXadrez LerPosicaoXadrez()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");

        return new PosicaoXadrez(coluna, linha);
    }

    public static void ImprimirPeca(Peca peca)
    {
        if (peca.Cor == Cor.Branca)
        {
            Console.Write(peca);
        }
        else
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(peca);
            Console.ForegroundColor = aux;
        }
    }
}