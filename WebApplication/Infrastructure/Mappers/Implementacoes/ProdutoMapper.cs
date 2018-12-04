using System.Collections.Generic;
using System.Linq;
using ObjetosNegocio;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Models.Produto;

namespace WebApplication.Infrastructure.Mappers.Implementacoes
{
	public class ProdutoMapper : IProdutoMapper
	{
		#region Métodos

		public Produto Map(ProdutoViewModel produtoViewModel)
		{
			return new Produto
			{
				PrecoSugerido = produtoViewModel.PrecoSugerido,
				Codigo = produtoViewModel.Codigo,
				Descricao = produtoViewModel.Descricao
			};
		}

		public ProdutoViewModel Map(Produto produto)
		{
			return new ProdutoViewModel
			{
				PrecoSugerido = produto.PrecoSugerido,
				Descricao = produto.Descricao,
				Codigo = produto.Codigo
			};
		}

		public IEnumerable<ProdutoViewModel> Map(List<Produto> produtoSet)
		{
			return produtoSet.Select(Map);
		}

		#endregion
	}
}