using Ninject.Modules;
using Servicos.Contratos;
using Servicos.Implementacoes;

namespace Servicos.Modules
{
	public class ProdutoServiceModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			Bind<IProdutoService>().To<ProdutoService>();
		}

		#endregion
	}
}