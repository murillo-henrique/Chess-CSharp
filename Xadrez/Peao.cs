using TabuleiroF;

namespace Xadrez;

class Peao : Peca
{
    public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

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
        }

        return mat;
    }
    public override string ToString()
    {
        return "P";
    }
}