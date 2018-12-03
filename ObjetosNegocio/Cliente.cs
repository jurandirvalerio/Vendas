using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
	public class Cliente
	{
		#region Propriedades

		public int Codigo { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public virtual List<Venda> VendaSet { get; set; }

		#endregion
	}
}