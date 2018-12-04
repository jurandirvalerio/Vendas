using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AcessoDados.Contratos;
using ObjetosNegocio;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ClienteRepository : IClienteRepository
	{
		#region Campos

		private readonly IVendasContext _vendasContext;
		private readonly IClienteValidator _clienteValidator;

		#endregion

		#region Construtores

		public ClienteRepository(IVendasContext vendasContext, IClienteValidator clienteValidator)
		{
			_vendasContext = vendasContext;
			_clienteValidator = clienteValidator;
		}

		#endregion

		#region Métodos

		public List<Cliente> Listar()
		{
			return _vendasContext.ClienteSet.ToList();
		}

		public Cliente Obter(int codigo)
		{
			return _vendasContext.ClienteSet.Single(c => c.Codigo == codigo);
		}

		public bool PodeIncluir(Cliente cliente, out string mensagem)
		{
			return _clienteValidator.PodeIncluir(cliente, out mensagem);
		}

		public bool PodeAlterar(Cliente cliente, out string mensagem)
		{
			if (ClienteNaoEncontrado(cliente.Codigo))
			{
				mensagem = "Cliente não encontrado";
				return false;
			}

			mensagem = null;
			return true;
		}

		private bool ClienteNaoEncontrado(int codigo)
		{
			return !_vendasContext.ClienteSet.Any(p => p.Codigo == codigo);
		}

		public void Alterar(Cliente cliente)
		{
			_vendasContext.Entry(cliente).State = EntityState.Modified;
			_vendasContext.SaveChanges();
		}

		public void Incluir(Cliente cliente)
		{
			_vendasContext.ClienteSet.Add(cliente);
			_vendasContext.SaveChanges();
		}

		public void Excluir(int codigo)
		{
			_vendasContext.ClienteSet.Remove(Obter(codigo));
			_vendasContext.SaveChanges();
		}

		public bool PodeExcluir(int codigo, out string mensagem)
		{
			if (ClienteNaoEncontrado(codigo))
			{
				mensagem = "Cliente não encontrado";
				return false;
			}

			if (ExisteVendaRelacionada(codigo))
			{
				mensagem = "Cliente não pode ser excluído pois já fez uma compra";
				return false;
			}

			mensagem = null;
			return true;
		}

		private bool ExisteVendaRelacionada(int codigo)
		{
			return _vendasContext.VendaSet.Any(v => v.CodigoCliente == codigo);
		}

		#endregion
	}
}