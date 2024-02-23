using TabuleiroF;

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