using System;
using System.Web.Http;
using Subvert.Configuration;

namespace Subvert
{
	public static class SubvertThis
	{
		public static SubvertApplication<T> Configure<T>(HttpConfiguration config) where T : SubvertConfiguration, new()
		{
			return Configure(config, () => new T());
		}

		public static SubvertApplication<T> Configure<T>(HttpConfiguration config, Func<T> configuration) where T : SubvertConfiguration
		{
			return new SubvertApplication<T>(configuration);
		}
	}
}
