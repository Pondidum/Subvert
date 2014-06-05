using System;

namespace Subvert
{
	public interface IEndpointNamingConvention
	{
		string GetName(Type type);
		Boolean IsMatch(Type type);
	}
}
