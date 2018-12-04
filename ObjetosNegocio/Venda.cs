using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjetosNegocio
{
	public class Venda
	{
		#region Propriedades

		[Key]
		public int Codigo { get; set; }
		[ForeignKey("Cliente")]
		public int CodigoCliente { get; set; }
		public Cliente Cliente { get; set; }
		public ICollection<VendaItem> VendaItemSet { get; set; } 

		#endregion
	}
}