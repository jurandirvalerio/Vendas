using System.Collections.Generic;

namespace ObjetosNegocio
{
	public class Venda
	{
		#region Propriedades

		public int Codigo { get; set; }
		public int CodigoCliente { get; set; }
		public Cliente Cliente { get; set; }
		public ICollection<VendaItem> VendaItemSet { get; set; } 

		#endregion
	}
}