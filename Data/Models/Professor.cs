using System;

namespace SGIEscolar.Data.Models
{
    public class Professor : BaseEntity
	{
		public string Nome { get; set;}
		public string Email { get; set;}
		public string Telefone { get; set;}
		public Endereco Endereco { get; set;}
		public string Desciplina { get; set;}
		public Turma Turma { get; set;}
	}
}

