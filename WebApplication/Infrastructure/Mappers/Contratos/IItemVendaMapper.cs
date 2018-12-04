using System.Collections.Generic;
using ObjetosNegocio;
using WebApplication.Models.Venda;

namespace WebApplication.Infrastructure.Mappers.Contratos
{
	public interface IItemVendaMapper
	{
		#region Métodos
		
		VendaItem Map(ItemVendaViewModel itemVendaViewModel);
		ItemVendaViewModel Map(VendaItem vendaItem);
		IEnumerable<ItemVendaViewModel> Map(List<VendaItem> vendaItemSet);
		IEnumerable<VendaItem> Map(List<ItemVendaViewModel> itemVendaViewModelSet);

		#endregion
	}
}