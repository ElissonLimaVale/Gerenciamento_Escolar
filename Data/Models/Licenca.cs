using System;

namespace SGIEscolar.Data.Models
{
    public class Licenca : BaseEntity
    {
        public bool AutoRenovacao { get; set; }
        public string Codigo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
