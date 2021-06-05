namespace SGIEscolar.Data.Notificacoes
{
    public class Notificacao
    {
        public Notificacao(string mensagem, bool state = false)
        {
            this.Mensagem = mensagem;
            this.State = state;
        }
        public string Mensagem { get; }
        public bool State { get; }
    }
}
