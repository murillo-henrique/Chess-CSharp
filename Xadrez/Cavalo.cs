using TabuleiroF;

namespace Xadrez;

class Cavalo : Peca
{
    public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

    private bool PodeMover(Posicao posicao)
    {
        Peca peca = Tabuleiro.Peca(posicao);

        return peca == null || peca.Cor != this.Cor;
    }
    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

        Posicao pos = new Posicao(0, 0);

        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        return mat;
    }
    public override string ToString()
    {
        return "C";
    }
}