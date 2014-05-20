using System;
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
			var method = Type.GetMethod(httpMethod + name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

			return new EndpointAction(this, method);
		}
	}
}
