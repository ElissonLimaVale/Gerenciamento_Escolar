using System;

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
		public Endereco Endereco { get; set; }

	}
}