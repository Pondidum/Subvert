using System;

namespace Subvert
{
	public class Router
	{
		private readonly EndpointDiscovery _endpoints;

		public Router(EndpointDiscovery endpoints)
		{
			_endpoints = endpoints;
		}

		public EndpointAction GetAction(Route route)
		{
			var endpoint = _endpoints.GetEndpointByName(route.Endpoint);

			if (endpoint == null)
			{
				return null; //return 404 action?
			}

			var action = endpoint.GetAction(route.Method, route.Action);

			if (action == null)
			{
				return null; //return 404 action?
			}

			return action;
		}
	}
}
