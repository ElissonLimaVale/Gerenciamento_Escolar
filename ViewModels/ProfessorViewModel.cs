using System;
using System.Collections.Generic;

namespace SGIEscolar.ViewModels
{
    public class ProfessorViewModel : BaseEntityViewModel
	{
		public string Nome { get; set;}
		public string Email { get; set;}
		public string Telefone { get; set;}
		public string Desciplina { get; set;}
		public Guid EnderecoId { get; set; }
		public virtual EnderecoViewModel Endereco { get; set; }
		public virtual IEnumerable<TurmaViewModel> Turmas { get; set; }
	}
}

