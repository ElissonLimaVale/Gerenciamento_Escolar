using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
	public class ProfessorViewModel : BaseEntityViewModel
	{
		[Required(ErrorMessage = "Nome é Obrigratório!")]
		public string Nome { get; set; }
		[Required(ErrorMessage = "Email é Obrigratório!")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Email está em um formato inválido!")]
		public string Email { get; set; }
		public string Telefone { get; set; }
		public string Desciplina { get; set; }
		public Guid EnderecoId { get; set; }
		public virtual EnderecoViewModel Endereco { get; set; }
		public virtual IEnumerable<TurmaViewModel> Turmas { get; set; }

	}
}

