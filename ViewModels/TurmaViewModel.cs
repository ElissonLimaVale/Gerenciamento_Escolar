using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
	public class TurmaViewModel : BaseEntityViewModel
	{
		public string Nome { get; set; }
		[Display(Name = "Série")]
		public string Serie { get; set; }
		public virtual IEnumerable<ProfessorViewModel> Professores { get; set; }
		public virtual IEnumerable<AlunoViewModel> Alunos { get; set; }

	}
}
