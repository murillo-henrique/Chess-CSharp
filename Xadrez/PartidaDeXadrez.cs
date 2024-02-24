using TabuleiroF;

namespace Xadrez;

class PartidaDeXadrez
{
    public Tabuleiro tabuleiro { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool Terminada { get; private set; }
    private HashSet<Peca> Pecas;
    private HashSet<Peca> Capturadas;
    public bool Xeque { get; private set; }

    public PartidaDeXadrez()
    {
        tabuleiro = new Tabuleiro(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        Pecas = new HashSet<Peca>();
        Capturadas = new HashSet<Peca>();
        ColocarPecas();
    }

    public Peca ExecutarMovimento(Posicao origem, Posicao destino)
    {
        Peca peca = tabuleiro.RetirarPeca(origem);
        peca.IncrementarQtdMovimentos();
        Peca pecaCapturada = tabuleiro.RetirarPeca(destino);
        tabuleiro.ColocarPeca(peca, destino);

        if (pecaCapturada != null)
        {
            Capturadas.Add(pecaCapturada);
        }

        return pecaCapturada;
    }
    public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
    {
        Peca peca = tabuleiro.RetirarPeca(destino);
        peca.DecrementarQtdMovimentos();
        if (pecaCapturada != null)
        {
            tabuleiro.ColocarPeca(pecaCapturada, destino);
            Capturadas.Remove(pecaCapturada);
        }
        tabuleiro.ColocarPeca(peca, origem);
    }
    public void RealizarJogada(Posicao origem, Posicao destino)
    {
        Peca pecaCapturada = ExecutarMovimento(origem, destino);

        if (EstaEmXeque(JogadorAtual))
        {
            DesfazerMovimento(origem, destino, pecaCapturada);
            throw new TabuleiroException("Você não pode se colocar em xeque!");
        }
        if (EstaEmXeque(Adversaria(JogadorAtual)))
        {
            Xeque = true;
        }
        else
        {
            Xeque = false;
        }

        if (EstaEmXequeMate(Adversaria(JogadorAtual)))
        {
            Terminada = true;
        }
        else
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }
    }
    public void ValidarPosicaoDeOrigem(Posicao posicao)
    {
        if (tabuleiro.Peca(posicao) == null)
        {
            throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
        }
        if (JogadorAtual != tabuleiro.Peca(posicao).Cor)
        {
            throw new TabuleiroException("A peça de origem escolhida não é sua!");
        }
        if (!tabuleiro.Peca(posicao).ExisteMovimentosPossiveis())
        {
            throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }
    }
    public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
    {
        if (!tabuleiro.Peca(origem).PodeMoverPara(destino))
        {
            throw new TabuleiroException("Posição de destino inválida!");
        }
    }
    private void MudarJogador()
    {
        if (JogadorAtual == Cor.Branca)
        {
            JogadorAtual = Cor.Preta;
        }
        else
        {
            JogadorAtual = Cor.Branca;
        }
    }

    public HashSet<Peca> PecasCapturadas(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca peca in Capturadas)
        {
            if (peca.Cor == cor)
            {
                aux.Add(peca);
            }
        }

        return aux;
    }
    public HashSet<Peca> PecasEmJogo(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca peca in Capturadas)
        {
            if (peca.Cor == cor)
            {
                aux.Add(peca);
            }
        }
        aux.ExceptWith(PecasCapturadas(cor));

        return aux;
    }
    private Cor Adversaria(Cor cor)
    {
        if (cor == Cor.Branca)
        {
            return Cor.Preta;
        }
        else
        {
            return Cor.Branca;
        }
    }
    private Peca Rei(Cor cor)
    {
        foreach (Peca peca in PecasEmJogo(cor))
        {
            if (peca is Rei)
            {
                return peca;
            }
        }

        return null;
    }
    public bool EstaEmXeque(Cor cor)
    {
        Peca rei = Rei(cor);
        if (rei == null)
        {
            throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro!");
        }

        foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
        {
            bool[,] mat = peca.MovimentosPossiveis();
            if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
            {
                return true;
            }
        }

        return false;
    }
    public bool EstaEmXequeMate(Cor cor)
    {
        if (!EstaEmXeque(cor))
        {
            return false;
        }

        foreach (Peca peca in PecasEmJogo(cor))
        {
            bool[,] mat = peca.MovimentosPossiveis();
            for (int linhas = 0; linhas < tabuleiro.Linhas; linhas++)
            {
                for (int colunas = 0; colunas < tabuleiro.Colunas; colunas++)
                {
                    if (mat[linhas, colunas])
                    {
                        Posicao origem = peca.Posicao;
                        Posicao destino = new Posicao(linhas, colunas);
                        Peca pecaCapturada = ExecutarMovimento(origem, destino);
                        bool testeXeque = EstaEmXeque(cor);
                        DesfazerMovimento(origem, destino, pecaCapturada);

                        if (!testeXeque)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    public void ColocarNovaPeca(char coluna, int linha, Peca peca)
    {
        tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
        Pecas.Add(peca);
    }
    private void ColocarPecas()
    {
        ColocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branca));
        ColocarNovaPeca('c', 2, new Torre(tabuleiro, Cor.Branca));
        ColocarNovaPeca('d', 2, new Torre(tabuleiro, Cor.Branca));
        ColocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.Branca));
        ColocarNovaPeca('e', 1, new Torre(tabuleiro, Cor.Branca));
        ColocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));

        ColocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.Preta));
        ColocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.Preta));
        ColocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.Preta));
        ColocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Preta));
        ColocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Preta));
        ColocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preta));
    }
}