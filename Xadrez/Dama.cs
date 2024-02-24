using TabuleiroF;

namespace Xadrez;

class Dama : Peca
{
    public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

    private bool PodeMover(Posicao posicao)
    {
        Peca peca = Tabuleiro.Peca(posicao);

        return peca == null || peca.Cor != this.Cor;
    }
    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

        Posicao pos = new Posicao(0, 0);
        
        //acima
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        //direita
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        //abaixo
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        //esquerda
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //noroeste
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.DefinirValores(pos.Linha - 1, pos.Coluna -1);
        }

        //nordeste
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.DefinirValores(pos.Linha - 1, pos.Coluna +1);
        }

        //sudeste
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.DefinirValores(pos.Linha + 1, pos.Coluna +1);
        }

        //sudoeste
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.DefinirValores(pos.Linha + 1, pos.Coluna -1);
        }

        return mat;
    }
    public override string ToString()
    {
        return "D";
    }
}