using System;
using System.Linq;
using System.Reflection;

namespace Subvert
{
	public class EndpointAction : IEndpointAction
	{
		private readonly MethodInfo _method;

		public EndpointAction(Endpoint endpoint, MethodInfo method)
		{
			EndpointType = endpoint.Type;
			_method = method;

			var parameter = method
				.GetParameters()
				.SingleOrDefault();

			if (parameter != null)
			{
				InputModelType = parameter.ParameterType;
			}

		}

		public Type InputModelType { get; private set; }
		public Type EndpointType { get; private set; }

		public object Run(object instance, object inputModel)
		{
			return _method.Invoke(instance, new[] { inputModel });
		}
	}
}
