using System;
using Subvert.Configuration;

namespace Subvert
{
	public class DefaultEndpointStore : IEndpointStore
	{
		private readonly IEndpointStore _otherStore;
		private readonly RouteConfiguration _configuration;

		public DefaultEndpointStore(RouteConfiguration configuration, IEndpointStore otherStore)
		{
			_configuration = configuration;
			_otherStore = otherStore;
		}

		public Endpoint GetEndpointByName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				if (_configuration.HomeEndpoint != null)
				{
					return _otherStore.GetEndpointByType(_configuration.HomeEndpoint);
				}

				return _otherStore.GetEndpointByName("Home");
			}
			
			return _otherStore.GetEndpointByName(name);
		}

		public Endpoint GetEndpointByType(Type type)
		{
			return _otherStore.GetEndpointByType(type);
		}
	}
}
