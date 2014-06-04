using System;
using StructureMap;
using StructureMap.Graph;

namespace Subvert.Configuration
{
	public class SubvertApplication<T> where T :SubvertConfiguration
	{
		private readonly IContainer _container;

		public SubvertApplication(Func<T> configuration)
		{
			_container = new Container(c => c.Scan(a =>
			{
				a.TheCallingAssembly();
				a.LookForRegistries();

				c.For<HostAssembly>()
					.OnCreationForAll(x => x.SetType(typeof(T)))
					.Singleton();
			}));

			var builder = _container.GetInstance<ConfigurationBuilder>();
			builder.Execute(configuration);
		}

		public SubvertApplication<T> HookTo(Action<IFrontController> backendConfiguration)
		{
			backendConfiguration(_container.GetInstance<IFrontController>());

			return this;
		}
	}
}