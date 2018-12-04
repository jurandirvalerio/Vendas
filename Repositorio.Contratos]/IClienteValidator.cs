using ObjetosNegocio;

namespace Repositorios.Contratos
{
	public interface IClienteValidator
	{
		#region Métodos

		bool PodeIncluir(Cliente cliente, out string mensagem); 

		#endregion
	}
}