﻿using System;

namespace SGIEscolar.Data.Models
{
	public class Endereco : BaseEntity
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
