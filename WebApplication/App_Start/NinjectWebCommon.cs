using System.Reflection;
using Ninject.Web.Common.WebHost;
using Repositorios.Modules;
using WebActivatorEx;
using WebApplication;

[assembly: PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace WebApplication
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Ninject;
	using Ninject.Web.Common;

	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper _bootstrapper = new Bootstrapper();

		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			_bootstrapper.Initialize(CreateKernel);
		}

		public static void Stop()
		{
			_bootstrapper.ShutDown();
		}

		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		private static void RegisterServices(IKernel kernel)
		{
			kernel.Load(Assembly.GetExecutingAssembly());
			kernel.Load(Assembly.GetAssembly(typeof(ClienteRepositoryModule)));
			kernel.Load(Assembly.GetAssembly(typeof(Servicos.Modules.ClienteServiceModule)));
			kernel.Load(Assembly.GetAssembly(typeof(AcessoDados.Modules.VendaContextModule)));
		}
	}
}