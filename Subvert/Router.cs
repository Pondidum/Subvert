using Subvert.Configuration;

namespace Subvert
{
	public class Router
	{
		private readonly RouteConfiguration _configuration;
		private readonly IEndpointStore _endpoints;

		public Router(RouteConfiguration configuration, IEndpointStore endpoints)
		{
			_configuration = configuration;
			_endpoints = endpoints;
		}

		public IEndpointAction GetAction(RouteData route)
		{
			var endpoint = route.Endpoint != null 
				? _endpoints.GetEndpointByName(route.Endpoint) 
				: _endpoints.GetEndpointByType(_configuration.HomeEndpoint);

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
