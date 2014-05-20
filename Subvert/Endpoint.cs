using System;
using System.Linq;
using System.Reflection;

namespace Subvert
{
	public class Endpoint
	{
		public string Name { get; private set; }
		public Type Type { get; private set; }

		public Endpoint(Type type, string endpointName)
		{
			Type = type;
			Name = endpointName;
		}

		public EndpointAction GetAction(string httpMethod, string name)
		{
			var methods = Type
				.GetMethods(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.Name.Equals(httpMethod + name, StringComparison.OrdinalIgnoreCase))
				.Where(m => m.GetParameters().Count() == 1)
				.ToList();

			if (methods.Any() == false)
			{
				return null;
			}

			var method = methods.SingleOrDefault();

			if (method == null)
			{
				return null;
			}

			return new EndpointAction(this, method);
		}
	}
}
