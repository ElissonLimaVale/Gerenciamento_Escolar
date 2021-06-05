using System;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
	public class AlunoViewModel : BaseEntityViewModel
	{
		[Required(ErrorMessage = "'Nome' é obrigatório *")]
		public string Nome { get; set; }
		public string CPF { get; set; }
		[Required(ErrorMessage = "'Data de Nascimento' é obrigatório *")]
		[DataType(DataType.Date, ErrorMessage = "'Data de Nascimento em formato inválido'")]
		public DateTime DataNascimento { get; set; }
		public string NomeDaMae { get; set; }
		public string NomeDoPai { get; set; }
		public Guid EnderecoId { get; set; }
        [Required(ErrorMessage = "'Turma' é obrigatório *")]
        public Guid TurmaId { get; set; }
		public virtual EnderecoViewModel Endereco { get; set; }
		public virtual TurmaViewModel Turma { get; set; }

	}
}