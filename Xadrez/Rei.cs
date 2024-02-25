using TabuleiroF;

namespace Xadrez;

class Rei : Peca
{
    private PartidaDeXadrez Partida;

    public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
    {
        Partida = partida;
    }

    private bool PodeMover(Posicao posicao)
    {
        Peca peca = Tabuleiro.Peca(posicao);

        return peca == null || peca.Cor != this.Cor;
    }
    private bool TesteTorreParaRoque(Posicao posicao)
    {
        Peca peca = Tabuleiro.Peca(posicao);
        return peca != null && peca is Torre && peca.Cor == Cor && peca.QtdMovimentos == 0;
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
        //nordeste
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
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
        //sudeste
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
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
        //sudoeste
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
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
        if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // #JogadaEspecial roque
        if (QtdMovimentos == 0 && !Partida.Xeque)
        {
            // #JogadaEspecial roque pequeno
            Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
            if (TesteTorreParaRoque(posT1))
            {
                Posicao posicaoLivreRoque1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                Posicao posicaoLivreRoque2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                if (Tabuleiro.Peca(posicaoLivreRoque1) == null && Tabuleiro.Peca(posicaoLivreRoque2) == null)
                {
                    mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }
            }

            // #JogadaEspecial roque grande
            Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
            if (TesteTorreParaRoque(posT2))
            {
                Posicao posicaoLivreRoque1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                Posicao posicaoLivreRoque2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                Posicao posicaoLivreRoque3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                if (Tabuleiro.Peca(posicaoLivreRoque1) == null && Tabuleiro.Peca(posicaoLivreRoque2) == null && Tabuleiro.Peca(posicaoLivreRoque3) == null)
                {
                    mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }
        }


        return mat;
    }
    public override string ToString()
    {
        return "R";
    }
}