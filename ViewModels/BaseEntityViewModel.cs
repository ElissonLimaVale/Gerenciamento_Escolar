using System;

namespace SGIEscolar.ViewModels
{
    public abstract class BaseEntityViewModel
    { 
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
