using System;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.Data.Models
{
	public class Aluno : BaseEntity
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
		public string NomeDaMae { get; set; }
		public string NomeDoPai { get; set; }
		public Guid EnderecoId { get; set; }
		public Guid TurmaId { get; set; }
		public virtual Endereco Endereco { get; set; }
		public virtual Turma Turma { get; set; }
	}
}