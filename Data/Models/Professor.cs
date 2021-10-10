using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
    public class Professor : BaseEntity
	{
		public string Nome { get; set;}
		public string Email { get; set;}
		public string Telefone { get; set;}
		public string Disciplina { get; set;}
		public Guid EnderecoId { get; set; }
		public virtual Endereco Endereco { get; set; }
		public virtual IEnumerable<Turma> Turmas { get; set;}
	}
}

