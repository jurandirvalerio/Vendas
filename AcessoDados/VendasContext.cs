using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AcessoDados.Contratos;
using ObjetosNegocio;

namespace AcessoDados.Implementacoes
{
	public class VendasContext : DbContext, IVendasContext
	{
		#region Construtores

		public VendasContext()
			:base("VendasContext")
		{
			
		}

		#endregion

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