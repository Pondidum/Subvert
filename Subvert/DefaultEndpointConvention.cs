using System;

namespace Subvert
{
	public class DefaultEndpointConvention : IEndpointConvention
	{
		public string GetName(Type type)
		{
			var name = type.Name;
			var index = name.LastIndexOf("Endpoint", StringComparison.OrdinalIgnoreCase);

			return name.Substring(0, index);
		}

		public Boolean IsMatch(Type type)
		{
			if (type.IsPublic == false)
			{
				return false;
			}

			return type.Name.EndsWith("Endpoint", StringComparison.OrdinalIgnoreCase);
		}
	}
}
