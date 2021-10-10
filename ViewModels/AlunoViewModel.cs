using System;
using System.ComponentModel.DataAnnotations;

namespace SGIEscolar.ViewModels
{
	public class AlunoViewModel : BaseEntityViewModel
	{
		[Display(Name = "Nome")]
		[Required(ErrorMessage = "'Nome' é obrigatório *")]
		public string Nome { get; set; }
		public string CPF { get; set; }
		[Display(Name = "Data de Nascimento")]
		[Required(ErrorMessage = "'Data de Nascimento' é obrigatório *")]
		[DataType(DataType.Date, ErrorMessage = "'Data de Nascimento em formato inválido'")]
		public DateTime DataNascimento { get; set; }
		[Display(Name = "Nome da Mãe")]
		public string NomeDaMae { get; set; }
		[Display(Name = "Nome do Pai")]
		public string NomeDoPai { get; set; }
		public Guid EnderecoId { get; set; }
		[Display(Name = "Turma")]
        [Required(ErrorMessage = "'Turma' é obrigatório *")]
        public Guid TurmaId { get; set; }
		public virtual EnderecoViewModel Endereco { get; set; }
		public virtual TurmaViewModel Turma { get; set; }

	}
}