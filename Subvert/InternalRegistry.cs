using StructureMap.Configuration.DSL;
using StructureMap.Graph;
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
				.Singleton();

			For<IViewRendererFactory>()
				.Singleton();

			For<IFrontController>()
				.Use<FrontController>()
				.Singleton();
		}
	}
}
