using TabuleiroF;
using Xadrez;

namespace Game;

class Tela
{
    public static void ImprimirPartida(PartidaDeXadrez partida)
    {
        ImprimirTabuleiro(partida.Tabuleiro);
        System.Console.WriteLine();
        ImprimirPecasCapturadas(partida);
        System.Console.WriteLine();
        System.Console.WriteLine($"Turno: {partida.Turno}\nAguardando jogada: {partida.JogadorAtual}");

        if (!partida.Terminada)
        {
            if (partida.Xeque)
            {
                System.Console.WriteLine("XEQUE!");
            }
        }
        else
        {
            System.Console.WriteLine("XEQUEMATE!");
            System.Console.WriteLine($"Vencedor: {partida.JogadorAtual}");
        }

    }
    public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
    {
        System.Console.WriteLine("Peças capturadas:");
        Console.Write("Brancas: ");
        ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
        System.Console.WriteLine();
        Console.Write("Pretas: ");
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        Console.ForegroundColor = aux;
        System.Console.WriteLine();
    }
    public static void ImprimirConjunto(HashSet<Peca> conjunto)
    {
        Console.Write("[");
        foreach (Peca peca in conjunto)
        {
            Console.Write(peca + " ");
        }
        Console.Write("]");
    }


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