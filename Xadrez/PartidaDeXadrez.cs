using TabuleiroF;

namespace Xadrez;

class PartidaDeXadrez
{
    public Tabuleiro tabuleiro { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool Terminada { get; private set; }

    public PartidaDeXadrez()
    {
        tabuleiro = new Tabuleiro(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        ColocarPecas();
    }

    public void ExecutarMovimento(Posicao origem, Posicao destino)
    {
        Peca peca = tabuleiro.RetirarPeca(origem);
        peca.IncrementarQtdMovimentos();
        Peca pecaCapturada = tabuleiro.RetirarPeca(destino);
        tabuleiro.ColocarPeca(peca, destino);
    }
    public void RealizarJogada(Posicao origem, Posicao destino)
    {
        ExecutarMovimento(origem, destino);
        Turno++;
        MudarJogador();
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


    private void ColocarPecas()
    {
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
        tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
        tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
    }
}