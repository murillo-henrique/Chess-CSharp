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
                ImprimirPeca(tabuleiro.Peca(linha, coluna));
            }
            System.Console.WriteLine();
        }

        System.Console.WriteLine("  a b c d e f g h");
    }

    public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
    {
        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

        for (int linha = 0; linha < tabuleiro.Linhas; linha++)
        {
            Console.Write(8 - linha + " ");
            for (int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
            {
                if (posicoesPossiveis[linha, coluna])
                {
                    Console.BackgroundColor = fundoAlterado;
                }
                else
                {
                    Console.BackgroundColor = fundoOriginal;
                }

                ImprimirPeca(tabuleiro.Peca(linha, coluna));
                Console.BackgroundColor = fundoOriginal;
            }

            System.Console.WriteLine();
        }

        System.Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = fundoOriginal;
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
        if (peca == null)
        {
            Console.Write("- ");
        }
        else
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
            Console.Write(" ");
        }
    }
}