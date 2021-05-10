﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
    public class UsuarioViewModel : BaseEntityViewModel
    {
        [Required(ErrorMessage = "'Email' é obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "'Senha' é obrigatório!")]
        public string Senha { get; set; }
        public List<PermissaoViewModel> Permissoes { get; set; }
        public Guid LicencaId { get; set; }
        public LicencaViewModel Licenca { get; set; }
    }
}
