using Ninject.Modules;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Infrastructure.Mappers.Implementacoes;

namespace WebApplication.Infrastructure.Modules.Mappers
{
	public class VendaMapperModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			Bind<IVendaMapper>().To<VendaMapper>();
		}

		#endregion
	}
}