using System.Collections.Generic;
using System.Linq;
using ObjetosNegocio;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Models.Cliente;

namespace WebApplication.Infrastructure.Mappers.Implementacoes
{
	public class ClienteMapper : IClienteMapper
	{
		#region Métodos

		public Cliente Map(ClienteViewModel clienteViewModel)
		{
			return new Cliente
			{
				Codigo = clienteViewModel.Codigo,
				Nome = clienteViewModel.Nome,
				DataNascimento = clienteViewModel.DataNascimento,
				Email = clienteViewModel.Email,
				Telefone = clienteViewModel.Telefone
			};
		}

		public ClienteViewModel Map(Cliente cliente)
		{
			return new ClienteViewModel
			{
				Nome = cliente.Nome,
				DataNascimento = cliente.DataNascimento,
				Codigo = cliente.Codigo,
				Telefone = cliente.Telefone,
				Email = cliente.Email
			};
		}

		public IEnumerable<ClienteViewModel> Map(List<Cliente> clienteSet)
		{
			return clienteSet.Select(Map);
		}

		#endregion
	}
}