using System.Collections.Generic;
using System.Linq;
using ObjetosNegocio;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Models.Venda;

namespace WebApplication.Infrastructure.Mappers.Implementacoes
{
	public class ItemVendaMapper : IItemVendaMapper
	{
		#region Métodos
		
		public VendaItem Map(ItemVendaViewModel itemVendaViewModel)
		{
			return new VendaItem
			{
				CodigoProduto = itemVendaViewModel.CodigoProduto,
				PrecoUnitario = itemVendaViewModel.PrecoUnitario,
				Quantidade = itemVendaViewModel.Quantidade
			};
		}

		public ItemVendaViewModel Map(VendaItem vendaItem)
		{
			return new ItemVendaViewModel
			{
				PrecoUnitario = vendaItem.PrecoUnitario,
				Quantidade = vendaItem.Quantidade,
				CodigoProduto = vendaItem.CodigoProduto,
				DescricaoProduto = vendaItem.Produto?.Descricao
			};
		}

		public IEnumerable<ItemVendaViewModel> Map(List<VendaItem> vendaItemSet)
		{
			return vendaItemSet.Select(Map);
		}

		public IEnumerable<VendaItem> Map(List<ItemVendaViewModel> itemVendaViewModelSet)
		{
			return itemVendaViewModelSet.Select(Map);
		}

		#endregion
	}
}