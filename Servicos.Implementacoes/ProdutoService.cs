using System.Collections.Generic;
using ObjetosNegocio;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ProdutoService : IProdutoService
	{
		#region Campos

		private readonly IProdutoRepository _produtoRepository;

		#endregion

		#region Construtores

		public ProdutoService(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		#endregion

		#region Métodos

		public List<Produto> Listar()
		{
			return _produtoRepository.Listar();
		}

		public Produto Obter(int codigo)
		{
			return _produtoRepository.Obter(codigo);
		}

		public void Incluir(Produto produto)
		{
			_produtoRepository.Incluir(produto);
		}

		public void Alterar(Produto produto)
		{
			_produtoRepository.Alterar(produto);
		}

		public void Excluir(int codigo)
		{
			_produtoRepository.Excluir(codigo);
		}

		#endregion
	}
}