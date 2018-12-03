using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AcessoDados.Contratos;
using ObjetosNegocio;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ProdutoRepository : IProdutoRepository
	{
		#region Métodos

		public List<Produto> Listar()
		{
			return _vendasContext.ProdutoSet.ToList();
		}

		public Produto Obter(int codigo)
		{
			return _vendasContext.ProdutoSet.Single(c => c.Codigo == codigo);
		}

		public void Alterar(Produto produto)
		{
			_vendasContext.Entry(produto).State = EntityState.Modified;
			_vendasContext.SaveChanges();
		}

		public void Incluir(Produto produto)
		{
			_vendasContext.ProdutoSet.Add(produto);
			_vendasContext.SaveChanges();
		}

		public void Excluir(int codigo)
		{
			_vendasContext.ProdutoSet.Remove(Obter(codigo));
			_vendasContext.SaveChanges();
		}

		#endregion

		#region Campos

		private readonly IVendasContext _vendasContext;

		#endregion

		#region Construtores
		public ProdutoRepository(IVendasContext vendasContext)
		{
			_vendasContext = vendasContext;
		}

		#endregion
	}
}