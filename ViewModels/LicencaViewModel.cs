using System;

namespace SGIEscolar.ViewModels
{
    public class LicencaViewModel : BaseEntityViewModel
    { 
        public string Codigo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
