using System;

namespace SGIEscolar.Data.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
