using WebApplication.Infrastructure.Extensions;

namespace WebApplication.Models.Produto
{
	public class ProdutoViewModel
	{
		#region Propriedades

		public int Codigo { get; set; }
		public string Descricao { get; set; }
		public decimal PrecoSugerido { get; set; }
		public string PrecoVisualizacao => PrecoSugerido.ToMoneyMask();

		#endregion
	}
}