﻿using System;

namespace SGIEscolar.ViewModels
{
	public class EnderecoViewModel : BaseEntityViewModel
	{
		public string Cep { get; set; }
		public string Pais { get; set; }
		public string Estado { get; set; }
		public string Cidade { get; set; }
		public string Rua { get; set; }
		public int Numero { get; set; }
		public string Complemento { get; set; }
		
	}
}