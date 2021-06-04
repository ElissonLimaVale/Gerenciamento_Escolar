using System;

namespace SGIEscolar.ViewModels
{
    public class ProfessorViewModel : BaseEntityViewModel
	{
		public string Nome { get; set;}
		public string Email { get; set;}
		public string Telefone { get; set;}
		public EnderecoViewModel Endereco { get; set;}
		public string Desciplina { get; set;}
		public TurmaViewModel Turma { get; set;}
	}
}

