using System;

namespace SGIEscolar.ViewModels
{
	public class AlunoViewModel : BaseEntityViewModel
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
		public string NomeDaMae { get; set; }
		public string NomeDoPai { get; set; }
		public Guid EnderecoId { get; set; }
		public Guid TurmaId { get; set; }
		public virtual EnderecoViewModel Endereco { get; set; }
		public virtual TurmaViewModel Turma { get; set; }

	}
}