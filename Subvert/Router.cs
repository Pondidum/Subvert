using System;

namespace Subvert
{
	public class Router
	{
		private readonly EndpointDiscovery _endpoints;
		private readonly RouteConvention _convention;

		public Router(EndpointDiscovery endpoints, RouteConvention convention)
		{
			_endpoints = endpoints;
			_convention = convention;
		}

		public Type GetEndpointForRoute(Uri route)
		{
			var endpointName = _convention.GetEndpointName(route);

			return _endpoints.GetEndpointByName(endpointName);
		}
	}
}
