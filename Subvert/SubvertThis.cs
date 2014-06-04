using System;
using Subvert.Configuration;

namespace Subvert
{
	public static class SubvertThis
	{
		public static SubvertApplication<T> Configure<T>() where T : SubvertConfiguration, new()
		{
			return Configure(() => new T());
		}

		public static SubvertApplication<T> Configure<T>(Func<T> configuration) where T : SubvertConfiguration
		{
			return new SubvertApplication<T>(configuration);
		}
	}
}
