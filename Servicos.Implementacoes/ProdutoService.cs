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

		public bool Incluir(Produto produto, out string mensagem)
		{
			if (_produtoRepository.PodeIncluir(produto, out mensagem))
			{
				_produtoRepository.Incluir(produto);
				return true;
			}
			return false;
		}

		public bool Alterar(Produto produto, out string mensagem)
		{
			if (_produtoRepository.PodeAlterar(produto, out mensagem))
			{
				_produtoRepository.Alterar(produto);
				return true;
			}
			return false;
		}

		public bool Excluir(int codigo, out string mensagem)
		{
			if (_produtoRepository.PodeExcluir(codigo, out mensagem))
			{
				_produtoRepository.Excluir(codigo);
				return true;
			}
			return false;
		}

		#endregion
	}
}