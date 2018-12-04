using Ninject.Modules;
using Servicos.Contratos;
using Servicos.Implementacoes;

namespace Servicos.Modules
{
	public class VendaServiceModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			Bind<IVendaService>().To<VendaService>();
		}

		#endregion
	}
}