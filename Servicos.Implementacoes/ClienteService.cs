using System.Collections.Generic;
using ObjetosNegocio;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ClienteService : IClienteService
	{
		#region Campos

		private readonly IClienteRepository _clienteRepository;

		#endregion

		#region Construtores

		public ClienteService(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		#endregion

		#region Métodos

		public List<Cliente> Listar()
		{
			return _clienteRepository.Listar();
		}

		public Cliente Obter(int codigo)
		{
			return _clienteRepository.Obter(codigo);
		}

		public void Excluir(int codigo)
		{
			_clienteRepository.Excluir(codigo);
		}

		public void Alterar(Cliente cliente)
		{
			_clienteRepository.Alterar(cliente);
		}

		public void Incluir(Cliente cliente)
		{
			_clienteRepository.Incluir(cliente);
		} 

		#endregion
	}
}