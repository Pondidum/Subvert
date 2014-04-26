using System.Reflection;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

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
			});

			For<EndpointDiscovery>()
				.Singleton();
		}
	}
}
