using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
	public class Turma : BaseEntity
	{
		public string Nome { get; set; }
		public string Serie { get; set; }
		public Guid ProfessorId { get; set; }
		public virtual Professor Professor { get; set; }
		public virtual IEnumerable<Aluno> Alunos { get; set; }

	}
}
