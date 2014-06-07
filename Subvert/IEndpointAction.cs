using System;

namespace Subvert
{
	public interface IEndpointAction
	{
		Type InputModelType { get; }
		Type EndpointType { get; }
		object Run(object instance, object inputModel);
	}
}
