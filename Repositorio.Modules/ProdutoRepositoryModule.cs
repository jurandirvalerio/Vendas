using Ninject.Modules;
using Repositorios.Contratos;
using Repositorios.Implementacoes;

namespace Repositorios.Modules
{
	public class ProdutoRepositoryModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IProdutoRepository>().To<ProdutoRepository>();
		}
	}
}