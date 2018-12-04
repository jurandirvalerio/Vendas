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

		public bool Incluir(Cliente cliente, out string mensagem)
		{
			if (_clienteRepository.PodeIncluir(cliente, out mensagem))
			{
				_clienteRepository.Incluir(cliente);
				return true;
			}
			return false;
		}

		public bool Alterar(Cliente cliente, out string mensagem)
		{
			if (_clienteRepository.PodeAlterar(cliente, out mensagem))
			{
				_clienteRepository.Alterar(cliente);
				return true;
			}
			return false;
		}

		public bool Excluir(int codigo, out string mensagem)
		{
			if (_clienteRepository.PodeExcluir(codigo, out mensagem))
			{
				_clienteRepository.Excluir(codigo);
				return true;
			}
			return false;
		}

		#endregion
	}
}