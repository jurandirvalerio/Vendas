using Ninject.Modules;
using Repositorios.Contratos;
using Repositorios.Implementacoes;

namespace Repositorios.Modules
{
	public class ClienteRepositoryModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IClienteRepository>().To<ClienteRepository>();
		}
	}
}