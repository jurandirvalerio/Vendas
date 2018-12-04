using Ninject.Modules;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Infrastructure.Mappers.Implementacoes;

namespace WebApplication.Infrastructure.Modules.Mappers
{
	public class ClienteMapperModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			Bind<IClienteMapper>().To<ClienteMapper>();
		}

		#endregion
	}
}