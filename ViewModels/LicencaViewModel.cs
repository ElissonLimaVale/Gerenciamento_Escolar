using System;

namespace SGIEscolar.ViewModels
{
    public class LicencaViewModel : BaseEntityViewModel
    {
        public bool AutoRenovacao { get; set; } = false;
        public string Codigo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
