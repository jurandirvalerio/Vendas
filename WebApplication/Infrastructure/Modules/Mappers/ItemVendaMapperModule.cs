using Ninject.Modules;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Infrastructure.Mappers.Implementacoes;

namespace WebApplication.Infrastructure.Modules.Mappers
{
	public class ItemVendaMapperModule : NinjectModule
	{
		#region Métodos
		public override void Load()
		{
			Bind<IItemVendaMapper>().To<ItemVendaMapper>();
		} 

		#endregion
	}
}