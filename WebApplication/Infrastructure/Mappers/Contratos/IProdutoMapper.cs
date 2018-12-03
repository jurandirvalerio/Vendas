using System.Collections.Generic;
using ObjetosNegocio;
using WebApplication.Models.Produto;

namespace WebApplication.Infrastructure.Mappers.Contratos
{
	public interface IProdutoMapper
	{
		#region Métodos

		Produto Map(ProdutoViewModel produtoViewModel);
		ProdutoViewModel Map(Produto produto);
		IEnumerable<ProdutoViewModel> Map(List<Produto> produtoSet);

		#endregion
	}
}