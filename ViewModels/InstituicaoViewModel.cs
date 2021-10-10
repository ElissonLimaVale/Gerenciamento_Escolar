using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
    public class InstituicaoViewModel: BaseEntityViewModel
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Email do Cordenador")]
        public string EmailCordenador { get; set; } 
        [Display(Name = "Telefone do Cordenador")]
        public string TelefoneCordenador { get; set; }
        [Display(Name = "Celular do Cordenador")]
        public string CelularCordenador { get; set; }
        [Display(Name = "String de Conexão do Banco de Dados")]
        public string DataBase { get; set; }
        //public Guid LicencaId { get; set; }
        //public LicencaViewModel Licenca { get; set; }
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}
