using Ninject.Modules;
using Servicos.Contratos;
using Servicos.Implementacoes;

namespace Servicos.Modules
{
    public class ClienteServiceModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			Bind<IClienteService>().To<ClienteService>();
		}

		#endregion
	}
}