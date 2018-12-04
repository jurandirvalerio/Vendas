using Ninject.Modules;
using Repositorios.Contratos;
using Repositorios.Implementacoes;

namespace Repositorios.Modules
{
	public class VendaRepositoryModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IVendaRepository>().To<VendaRepository>();
		}
	}
}