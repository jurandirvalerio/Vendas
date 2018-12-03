using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ObjetosNegocio;

namespace AcessoDados.Contratos
{
	public interface IVendasContext
	{
		#region Propriedades

		DbSet<Produto> ProdutoSet { get; set; }
		DbSet<Cliente> ClienteSet { get; set; }
		DbSet<Venda> VendaSet { get; set; }
		DbSet<VendaItem> VendaItemSet { get; set; }
		int SaveChanges();
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

		#endregion
	}
}