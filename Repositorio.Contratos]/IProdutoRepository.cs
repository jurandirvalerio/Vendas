using System.Collections.Generic;
using ObjetosNegocio;

namespace Repositorios.Contratos
{
	public interface IProdutoRepository
	{
		#region Métodos

		List<Produto> Listar();
		Produto Obter(int codigo);
		void Incluir(Produto produto);
		bool PodeIncluir(Produto produto, out string mensagem);
		void Alterar(Produto produto);
		bool PodeAlterar(Produto produto, out string mensagem);
		void Excluir(int codigo);
		bool PodeExcluir(int codigo, out string mensagem);

		#endregion
	}
}