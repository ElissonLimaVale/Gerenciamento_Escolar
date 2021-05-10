
using SGIEscolar.Data.Notificacoes;
using System.Collections.Generic;

namespace SGIEscolar.Data.Interface
{
    public interface INotificador
    {
        bool ExisteNotifcacoes();
        List<Notificacao> ListarNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
