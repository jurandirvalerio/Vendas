using System.Collections.Generic;
using ObjetosNegocio;

namespace Servicos.Contratos
{
	public interface IProdutoService
	{
		#region Métodos

		List<Produto> Listar();
		Produto Obter(int codigo);
		void Incluir(Produto produto);
		void Alterar(Produto produto);
		void Excluir(int codigo);

		#endregion
	}
}