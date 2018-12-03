using System.Data.Entity.Migrations;

namespace AcessoDados.Implementacoes.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<VendasContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(VendasContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
		}
	}
}
