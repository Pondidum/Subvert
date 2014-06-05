using System;

namespace Subvert
{
	public interface IEndpointConvention
	{
		string GetName(Type type);
		Boolean IsMatch(Type type);
	}
}
