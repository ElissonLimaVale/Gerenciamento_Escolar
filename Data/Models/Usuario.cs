using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
        public Guid InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; }
        public virtual List<Permissao> Permissoes { get; set; }
    }
}
