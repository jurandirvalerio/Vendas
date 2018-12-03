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

		public bool PodeIncluir(Produto produto, out string mensagem)
		{
			if (ProdutoJaCadastrado(produto))
			{
				mensagem = "Produto já cadastrado com esta descrição";
				return false;
			}

			mensagem = null;
			return true;
		}

		public bool PodeAlterar(Produto produto, out string mensagem)
		{
			if (ProdutoNaoEncontrado(produto.Codigo))
			{
				mensagem = "Produto não encontrado";
				return false;
			}

			mensagem = null;
			return true;
		}

		private bool ProdutoNaoEncontrado(int codigo)
		{
			return !_vendasContext.ProdutoSet.Any(p => p.Codigo == codigo);
		}

		private bool ProdutoJaCadastrado(Produto produto)
		{
			return _vendasContext.ProdutoSet.Any(p => p.Descricao == produto.Descricao);
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

		public bool PodeExcluir(int codigo, out string mensagem)
		{
			if(ProdutoNaoEncontrado(codigo))
			{
				mensagem = "Produto não encontrado";
				return false;
			}

			if (ExisteVendaRelacionada(codigo))
			{
				mensagem = "Produto não pode ser excluído pois já foi vendido";
				return false;
			}

			mensagem = null;
			return true;
		}

		private bool ExisteVendaRelacionada(int codigo)
		{
			return _vendasContext.VendaItemSet.Any(vi => vi.CodigoProduto == codigo);
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