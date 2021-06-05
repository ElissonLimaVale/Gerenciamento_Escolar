using System.Collections.Generic;

namespace SGIEscolar.ViewModels
{
	public class TurmaViewModel : BaseEntityViewModel
	{
		public string Nome { get; set; }
		public string Serie { get; set; }
		public virtual IEnumerable<ProfessorViewModel> Professores { get; set; }
		public virtual IEnumerable<AlunoViewModel> Alunos { get; set; }

	}
}
