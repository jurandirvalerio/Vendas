using Ninject.Modules;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Infrastructure.Mappers.Implementacoes;

namespace WebApplication.Infrastructure.Modules.Mappers
{
	public class ProdutoMapperModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			Bind<IProdutoMapper>().To<ProdutoMapper>();
		}

		#endregion
	}
}