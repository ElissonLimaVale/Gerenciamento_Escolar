using SGIEscolar.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SGIEscolar.Data.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

      public Notificador()
        {
            this._notificacoes = new List<Notificacao>();
        }

        public bool ExisteNotifcacoes()
        {
            return this._notificacoes.Any();
        }

        public void Handle(Notificacao notificacao)
        {
            this._notificacoes.Add(notificacao);
        }

        public List<Notificacao> ListarNotificacoes()
        {
            return this._notificacoes;
        }
    }
}
