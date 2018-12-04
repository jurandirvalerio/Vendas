using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AcessoDados.Contratos;
using ObjetosNegocio;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class VendaRepository : IVendaRepository
	{
		#region Métodos

		public List<Venda> Listar()
		{
			var vendas = _vendasContext.VendaSet
				.Include(v => v.VendaItemSet.Select(vi => vi.Venda.Cliente))
				.ToList();

			vendas.ForEach(v => v.Cliente = _vendasContext.ClienteSet.Find(v.CodigoCliente));
			return vendas;
		}

		public Venda Obter(int codigo)
		{
			return _vendasContext.VendaSet.Single(c => c.Codigo == codigo);
		}

		public bool PodeIncluir(Venda venda, out string mensagem)
		{
			mensagem = null;
			return true;
		}

		public bool PodeAlterar(Venda venda, out string mensagem)
		{
			if (VendaNaoEncontrado(venda.Codigo))
			{
				mensagem = "Venda não encontrado";
				return false;
			}

			mensagem = null;
			return true;
		}

		private bool VendaNaoEncontrado(int codigo)
		{
			return !_vendasContext.VendaSet.Any(p => p.Codigo == codigo);
		}

		public void Alterar(Venda venda)
		{
			_vendasContext.Entry(venda).State = EntityState.Modified;
			_vendasContext.SaveChanges();
		}

		public void Incluir(Venda venda)
		{
			_vendasContext.VendaSet.Add(venda);
			_vendasContext.SaveChanges();
		}

		public void Excluir(int codigo)
		{
			_vendasContext.VendaSet.Remove(Obter(codigo));
			_vendasContext.SaveChanges();
		}

		public bool PodeExcluir(int codigo, out string mensagem)
		{
			if (VendaNaoEncontrado(codigo))
			{
				mensagem = "Venda não encontrada";
				return false;
			}

			mensagem = null;
			return true;
		}

		#endregion

		#region Campos

		private readonly IVendasContext _vendasContext;

		#endregion

		#region Construtores

		public VendaRepository(IVendasContext vendasContext)
		{
			_vendasContext = vendasContext;
		}

		#endregion
	}
}