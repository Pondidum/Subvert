using System;
using System.Linq;
using System.Reflection;

namespace Subvert
{
	public class EndpointAction
	{
		private readonly MethodInfo _method;

		public EndpointAction(Endpoint endpoint,MethodInfo method)
		{
			_method = method;

			InputModelType = method
				.GetParameters()
				.Single()
				.ParameterType;

			EndpointType = endpoint.Type;
		}

		public Type InputModelType { get; private set; }
		public Type EndpointType { get; private set; }

		public object Run(object instance, object inputModel)
		{
			return _method.Invoke(instance, new[] { inputModel });
		}
	}
}
