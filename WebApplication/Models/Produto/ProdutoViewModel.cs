using System.ComponentModel.DataAnnotations;
using WebApplication.Infrastructure.Extensions;

namespace WebApplication.Models.Produto
{
	public class ProdutoViewModel
	{
		#region Propriedades

		public int Codigo { get; set; }
		
		[Required]
		[Display(Name = "Descrição")]
		public string Descricao { get; set; }
		
		[Required]
		[Display(Name = "Preço")]
		public decimal PrecoSugerido { get; set; }
		
		[Display(Name = "Preço")]
		public string PrecoVisualizacao => PrecoSugerido.ToMoneyMask();

		#endregion
	}
}