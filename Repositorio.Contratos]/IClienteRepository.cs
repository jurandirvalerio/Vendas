using System.Collections.Generic;
using ObjetosNegocio;

namespace Repositorios.Contratos
{
	public interface IClienteRepository
	{
		#region Métodos

		List<Cliente> Listar();
		Cliente Obter(int codigo);
		void Incluir(Cliente cliente);
		bool PodeIncluir(Cliente cliente, out string mensagem);
		void Alterar(Cliente cliente);
		bool PodeAlterar(Cliente cliente, out string mensagem);
		void Excluir(int codigo);
		bool PodeExcluir(int codigo, out string mensagem);

		#endregion
	}
}