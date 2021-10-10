using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
    public class ProfessorViewModel : BaseEntityViewModel
	{
		[Required(ErrorMessage = "'Nome' é Obrigatório!")]
		public string Nome { get; set;}
		[Required(ErrorMessage = "'Email' é Obrigatório!")]
		[Display(Name = "E-mail")]
		public string Email { get; set;}
		public string Telefone { get; set;}
		[Required(ErrorMessage = "'Disciplina' é Obrigatório!")]
		public string Disciplina { get; set;}
		[Display(Name = "Endereço")]
		public Guid EnderecoId { get; set; }
		public virtual EnderecoViewModel Endereco { get; set; }
		public virtual IEnumerable<TurmaViewModel> Turmas { get; set; }
	}
}

