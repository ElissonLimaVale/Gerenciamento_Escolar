using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
	public class Turma : BaseEntity
	{
		public string Nome { get; set; }
		public string Serie { get; set; }
		public Professor Professor { get; set; }
		public  IEnumerable<Aluno> Alunos { get; set; }
		

	}
}
