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
		bool PodeIncluir(Produto produto);
		void Alterar(Produto produto);
		void Excluir(int codigo);
		bool PodeExcluir(int codigo);

		#endregion
	}
}