using TabuleiroF;

namespace Xadrez;

class Peao : Peca
{
    private PartidaDeXadrez Partida;
    public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
    {
        Partida = partida;
    }

    private bool PodeMover(Posicao posicao)
    {
        Peca peca = Tabuleiro.Peca(posicao);

        return peca == null || peca.Cor != this.Cor;
    }
    private bool ExisteInimigo(Posicao posicao)
    {
        Peca peca = Tabuleiro.Peca(posicao);

        return peca != null && peca.Cor != Cor;
    }
    private bool Livre(Posicao posicao)
    {
        return Tabuleiro.Peca(posicao) == null;
    }


    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

        Posicao pos = new Posicao(0, 0);

        if (Cor == Cor.Branca)
        {
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #JogadaEspecial en passant
            if (Posicao.Linha == 3)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                }

                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == Partida.VulneravelEnPassant)
                {
                    mat[direita.Linha - 1, direita.Coluna] = true;
                }
            }
        }
        else
        {
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #JogadaEspecial en passant
            if (Posicao.Linha == 4)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                }

                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == Partida.VulneravelEnPassant)
                {
                    mat[direita.Linha + 1, direita.Coluna] = true;
                }
            }
        }

        return mat;
    }
    public override string ToString()
    {
        return "P";
    }
}