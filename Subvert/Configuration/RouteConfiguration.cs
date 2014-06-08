using System;

namespace Subvert.Configuration
{
	public class RouteConfiguration
	{
		internal Type HomeEndpoint { get; private set; }

		public void HomeIs<T>()
		{
			HomeEndpoint = typeof(T);
		}
	}
}
