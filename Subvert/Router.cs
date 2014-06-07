namespace Subvert
{
	public class Router
	{
		private readonly IEndpointStore _endpoints;

		public Router(IEndpointStore endpoints)
		{
			_endpoints = endpoints;
		}

		public IEndpointAction GetAction(RouteData route)
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
