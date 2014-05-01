using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using Subvert.ViewRendering;

namespace Subvert
{
	public class InternalRegistry : Registry
	{
		public InternalRegistry()
		{
			Scan(s =>
			{
				s.TheCallingAssembly();
				s.WithDefaultConventions();

				s.AddAllTypesOf<IViewRenderer>();
			});

			For<EndpointDiscovery>()
				.Singleton();

			For<ViewRendererFactory>()
				.Use(x => new ViewRendererFactory(x.GetAllInstances<IViewRenderer>()));
		}
	}
}
