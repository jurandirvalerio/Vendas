using AcessoDados.Contratos;
using AcessoDados.Implementacoes;
using Ninject.Modules;

namespace AcessoDados.Modules
{
	public class VendaContextModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			Bind<IVendasContext>().To<VendasContext>();
		}

		#endregion
	}
}