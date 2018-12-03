using System.Collections.Generic;
using System.Data;
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

		#endregion

		#region Construtores
		public ClienteRepository(IVendasContext vendasContext)
		{
			_vendasContext = vendasContext;
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

		public void Excluir(int codigo)
		{
			_vendasContext.ClienteSet.Remove(Obter(codigo));
			_vendasContext.SaveChanges();
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

		#endregion
	}
}