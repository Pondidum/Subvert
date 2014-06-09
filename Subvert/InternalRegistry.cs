using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using Subvert.Configuration;
using Subvert.ModelBinding;
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
				s.AddAllTypesOf<IModelBinder>();
			});

			For<IEndpointStore>()
				.Use<EndpointAssemblyScanner>()
				.DecorateWith((c, x) => new DefaultEndpointStore(c.GetInstance<RouteConfiguration>(), x))
				.Singleton();

			For<IViewRendererFactory>()
				.Singleton();

			For<RouteConfiguration>()
				.Singleton();

			For<IEndpointConvention>()
				.Use<DefaultEndpointConvention>();
		}
	}
}
