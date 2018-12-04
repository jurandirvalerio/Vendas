using System.Collections.Generic;
using ObjetosNegocio;
using WebApplication.Models.Cliente;

namespace WebApplication.Infrastructure.Mappers.Contratos
{
	public interface IClienteMapper
	{
		#region Métodos

		Cliente Map(ClienteViewModel clienteViewModel);
		ClienteViewModel Map(Cliente cliente);
		IEnumerable<ClienteViewModel> Map(List<Cliente> clienteSet);

		#endregion
	}
}