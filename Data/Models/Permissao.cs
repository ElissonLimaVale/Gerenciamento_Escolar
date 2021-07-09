using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
    public class Permissao : BaseEntity
    {
        public string Permission { get; set; }
        public string Nivel { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }
    }
}
