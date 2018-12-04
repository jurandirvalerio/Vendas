using System.Collections.Generic;
using ObjetosNegocio;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class VendaService : IVendaService
	{
		#region Campos

		private readonly IVendaRepository _vendaRepository;

		#endregion

		#region Construtores

		public VendaService(IVendaRepository vendaRepository)
		{
			_vendaRepository = vendaRepository;
		}

		#endregion

		#region Métodos

		public List<Venda> Listar()
		{
			return _vendaRepository.Listar();
		}

		public Venda Obter(int codigo)
		{
			return _vendaRepository.Obter(codigo);
		}

		public bool Incluir(Venda venda, out string mensagem)
		{
			if (_vendaRepository.PodeIncluir(venda, out mensagem))
			{
				_vendaRepository.Incluir(venda);
				return true;
			}
			return false;
		}

		public bool Alterar(Venda venda, out string mensagem)
		{
			if (_vendaRepository.PodeAlterar(venda, out mensagem))
			{
				_vendaRepository.Alterar(venda);
				return true;
			}
			return false;
		}

		public bool Excluir(int codigo, out string mensagem)
		{
			if (_vendaRepository.PodeExcluir(codigo, out mensagem))
			{
				_vendaRepository.Excluir(codigo);
				return true;
			}
			return false;
		}

		#endregion
	}
}