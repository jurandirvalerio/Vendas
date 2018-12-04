using Ninject.Modules;
using Repositorios.Contratos;
using Repositorios.Implementacoes;

namespace Repositorios.Modules
{
	public class ClienteValidatorModule : NinjectModule
	{
		#region Métodos

		public override void Load()
		{
			var custom = true;
			if (custom)
			{
				Bind<IClienteValidator>().To<ClienteValidatorCustom>();
			}
			else
			{
				Bind<IClienteValidator>().To<ClienteValidator>();
			}
		}

		#endregion
	}
}