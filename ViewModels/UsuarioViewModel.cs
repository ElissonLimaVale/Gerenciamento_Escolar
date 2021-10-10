using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
    public class UsuarioViewModel : BaseEntityViewModel
    {
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "'Email' é obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "'Senha' é obrigatório!")]
        public string Senha { get; set; }
        [Display(Name = "Função")]
        public string Funcao { get; set; }
        [Display(Name = "Instituição")]
        [Required(ErrorMessage = "'Instituição' é Obrigatório!")]
        public Guid InstituicaoId { get; set; }
        public List<PermissaoViewModel> Permissoes { get; set; }
        public InstituicaoViewModel Instituicao { get; set; }
    }
}
