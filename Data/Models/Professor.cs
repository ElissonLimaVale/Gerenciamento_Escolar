using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Models
{
    public class Professor : BaseEntity
	{
		public string Nome { get; set;}
		public string Email { get; set;}
		public string Telefone { get; set;}
		public Endereco Endereco { get; set;}
		public string Desciplina { get; set;}
		public IEnumerable<Turma> Turmas { get; set;}
	}
}

