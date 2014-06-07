using System;

namespace Subvert
{
	public interface IEndpointStore
	{
		Endpoint GetEndpointByName(string name);
		Endpoint GetEndpointByType(Type type);
	}
}
