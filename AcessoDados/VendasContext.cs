using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ObjetosNegocio;

namespace AcessoDados
{
	public class VendasContext : DbContext
	{
		#region Métodos

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Properties()
				.Where(p => p.Name == "Codigo")
				.Configure(p => p.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		#endregion

		#region Propriedades

		public DbSet<Produto> ProdutoSet { get; set; }
		public DbSet<Cliente> ClienteSet { get; set; }
		public DbSet<Venda> VendaSet { get; set; }
		public DbSet<VendaItem> VendaItemSet { get; set; }

		#endregion
	}
}