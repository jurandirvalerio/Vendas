using System.Collections.Generic;
using ObjetosNegocio;

namespace Servicos.Contratos
{
	public interface IClienteService
	{
		#region Métodos

		List<Cliente> Listar();
		Cliente Obter(int codigo);
		bool Incluir(Cliente cliente, out string mensagem);
		bool Alterar(Cliente cliente, out string mensagem);
		bool Excluir(int codigo, out string mensagem);

		#endregion
	}
}