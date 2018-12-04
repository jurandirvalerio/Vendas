using System.Collections.Generic;
using System.Linq;
using ObjetosNegocio;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Models.Venda;

namespace WebApplication.Infrastructure.Mappers.Implementacoes
{
	public class VendaMapper : IVendaMapper
	{
		#region Campos

		private readonly IItemVendaMapper _itemVendaMapper;

		#endregion

		#region Construtores

		public VendaMapper(IItemVendaMapper itemVendaMapper)
		{
			_itemVendaMapper = itemVendaMapper;
		}

		#endregion

		#region Métodos

		public Venda Map(VendaViewModel vendaViewModel)
		{
			return new Venda
			{
				Codigo = vendaViewModel.Codigo,
				CodigoCliente = vendaViewModel.CodigoCliente,
				VendaItemSet = _itemVendaMapper.Map(vendaViewModel.ItemVendaViewModelSet).ToList()
			};
		}

		public VendaViewModel Map(Venda venda)
		{
			return new VendaViewModel
			{
				Codigo = venda.Codigo,
				CodigoCliente = venda.CodigoCliente,
				NomeCliente = venda?.Cliente.Nome,
				Total = venda.VendaItemSet.Sum(v => v.PrecoUnitario * v.Quantidade)
			};
		}

		public IEnumerable<VendaViewModel> Map(List<Venda> vendaSet)
		{
			return vendaSet.Select(Map);
		}

		#endregion
	}
}