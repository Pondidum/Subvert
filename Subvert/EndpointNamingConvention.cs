using System;

namespace Subvert
{
	public class EndpointNamingConvention
	{
		public string GetName(Type type)
		{
			var name = type.Name;
			var index = name.LastIndexOf("Endpoint", StringComparison.OrdinalIgnoreCase);

			return name.Substring(index);
		}

		public Boolean IsMatch(Type type)
		{
			return type.Name.EndsWith("Endpoint", StringComparison.OrdinalIgnoreCase);
		}
	}
}
