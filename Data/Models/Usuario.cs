using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.Data.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        [Required(ErrorMessage = "'Email' é obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "'Senha' é obrigatório!")]
        public string Senha { get; set; }
        public List<Permissao> Permissoes { get; set; }
        public Guid LicencaId { get; set; }
        public Licenca Licenca { get; set; }
    }
}
