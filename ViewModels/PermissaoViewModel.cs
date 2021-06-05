using System;

namespace SGIEscolar.ViewModels
{
    public class PermissaoViewModel : BaseEntityViewModel
    {
        public string Permission { get; set; }
        public string Nivel { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
