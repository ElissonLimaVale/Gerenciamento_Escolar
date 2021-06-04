using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid LicencaId { get; set; }
        public Licenca Licenca { get; set; }
        public List<Permissao> Permissoes { get; set; }
    }
}
