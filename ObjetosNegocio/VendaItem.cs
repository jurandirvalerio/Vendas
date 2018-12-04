using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjetosNegocio
{
	public class VendaItem
	{
		#region Propriedades
		[Key]
		public int Codigo { get; set; }
		[ForeignKey("Venda")]
		public int CodigoVenda { get; set; }
		public Venda Venda { get; set; }
		[ForeignKey("Produto")]
		public int CodigoProduto { get; set; }
		public Produto Produto { get; set; }
		public decimal PrecoUnitario { get; set; }
		public int Quantidade { get; set; }
		#endregion
	}
}