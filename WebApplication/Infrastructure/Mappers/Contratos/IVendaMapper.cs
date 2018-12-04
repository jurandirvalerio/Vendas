using System.Collections.Generic;
using ObjetosNegocio;
using WebApplication.Models.Venda;

namespace WebApplication.Infrastructure.Mappers.Contratos
{
	public interface IVendaMapper
	{
		#region Métodos

		Venda Map(VendaViewModel vendaViewModel);
		VendaViewModel Map(Venda venda);
		IEnumerable<VendaViewModel> Map(List<Venda> vendaSet);

		#endregion
	}
}