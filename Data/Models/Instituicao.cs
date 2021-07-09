using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
    public class Instituicao: BaseEntity
    {
        public string Nome { get; set; }
        public string EmailCordenador { get; set; }
        public string TelefoneCordenador { get; set; }
        public string CelularCordenador { get; set; }
        public string DataBase { get; set; }
        //public Guid LicencaId { get; set; }
        //public Licenca Licenca { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }
    }
}
