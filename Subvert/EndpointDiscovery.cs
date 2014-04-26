using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Subvert
{
	public class EndpointDiscovery
	{
		private readonly Lazy<List<Type>> _types;

		public EndpointDiscovery(HostAssembly hostAssembly)
		{
			_types = new Lazy<List<Type>>(() =>
			{
				return hostAssembly
					.Assembly
					.GetTypes()
					.Where(t => t.Name.EndsWith("Endpoint", StringComparison.OrdinalIgnoreCase))
					.ToList();
			});
		}

		public IEnumerable<Type> GetEndpoints()
		{
			return _types.Value;
		}
	}
}
