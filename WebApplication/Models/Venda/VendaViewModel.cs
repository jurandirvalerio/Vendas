using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication.Infrastructure.Extensions;

namespace WebApplication.Models.Venda
{
	public class VendaViewModel
	{
		#region Propriedades
		public int Codigo { get; set; }
		public int CodigoCliente { get; set; }
		public List<ItemVendaViewModel> ItemVendaViewModelSet { get; set; }
		[Display(Name = "Cliente")]
		public string NomeCliente { get; set; }
		public decimal Total { get; set; }
		[Display(Name = "Total")]
		public string TotalVisualizacao => Total.ToMoneyMask();

		#endregion
	}
}