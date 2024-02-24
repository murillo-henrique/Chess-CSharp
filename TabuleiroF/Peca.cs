namespace TabuleiroF;

abstract class Peca
{
    public Posicao Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public int QtdMovimentos { get; protected set; }
    public Tabuleiro Tabuleiro { get; protected set; }

    public Peca(Tabuleiro tabuleiro, Cor cor)
    {
        Posicao = null;
        Tabuleiro = tabuleiro;
        Cor = cor;
        QtdMovimentos = 0;
    }

    public void IncrementarQtdMovimentos()
    {
        QtdMovimentos++;
    }
    public void DecrementarQtdMovimentos()
    {
        QtdMovimentos--;
    }
    public bool ExisteMovimentosPossiveis()
    {
        bool[,] mat = MovimentosPossiveis();
        for (int linhas = 0; linhas < Tabuleiro.Linhas; linhas++)
        {
            for (int colunas = 0; colunas < Tabuleiro.Colunas; colunas++)
            {
                if (mat[linhas, colunas])
                {
                    return true;
                }
            }
        }

        return false;
    }
    public bool PodeMoverPara(Posicao posicao)
    {
        return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
    }

    public abstract bool[,] MovimentosPossiveis();
}