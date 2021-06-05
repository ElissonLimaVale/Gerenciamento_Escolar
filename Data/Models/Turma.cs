using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
	public class Turma : BaseEntity
	{
		public string Nome { get; set; }
		public string Serie { get; set; }
		public virtual IEnumerable<Professor> Professores { get; set; }
		public virtual IEnumerable<Aluno> Alunos { get; set; }

	}
}
