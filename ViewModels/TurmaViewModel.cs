using System;
using System.Collections.Generic;

namespace SGIEscolar.ViewModels
{
	public class TurmaViewModel : BaseEntityViewModel
	{
		public string Nome { get; set; }
		public string Serie { get; set; }
		public Guid ProfessorId { get; set; }
		public virtual ProfessorViewModel Professor { get; set; }
		public virtual IEnumerable<AlunoViewModel> Alunos { get; set; }

	}
}
