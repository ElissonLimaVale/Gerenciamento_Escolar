using System;
using System.Collections.Generic;

namespace SGIEscolar.ViewModels
{
    public class InstituicaoViewModel: BaseEntityViewModel
    {
        public string Nome { get; set; }
        public string EmailCordenador { get; set; } 
        public string TelefoneCordenador { get; set; }
        public string CelularCordenador { get; set; }
        public string DataBase { get; set; }
        //public Guid LicencaId { get; set; }
        //public LicencaViewModel Licenca { get; set; }
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}
