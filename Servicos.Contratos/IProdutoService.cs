using System.Collections.Generic;
using ObjetosNegocio;

namespace Servicos.Contratos
{
	public interface IProdutoService
	{
		#region Métodos

		List<Produto> Listar();
		Produto Obter(int codigo);
		bool Incluir(Produto produto, out string mensagem);
		bool Alterar(Produto produto, out string mensagem);
		bool Excluir(int codigo, out string mensagem);

		#endregion
	}
}