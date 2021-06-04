using System;
using System.Collections.Generic;

namespace SGIEscolar.ViewModels
{
	public class TurmaViewModel : BaseEntityViewModel
	{
		public string Nome { get; set; }
		public string Serie { get; set; }
		public ProfessorViewModel Professor { get; set; }
		public  IEnumerable<AlunoViewModel> Alunos { get; set; }
		

	}
}
