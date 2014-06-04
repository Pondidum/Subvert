using System.Web.Http;
using Subvert.Configuration;

namespace Subvert.WebApi
{
	public static class SubvertApplicationExtensions
	{
		public static SubvertApplication<T> HookToWebApi<T>(this SubvertApplication<T> self, HttpConfiguration config) where T : SubvertConfiguration
		{
			self.HookTo(controller => new WebApiHook(controller, config));
			return self;
		}

		public static SubvertApplication<T> HookToWebApi<T>(this SubvertApplication<T> self, HttpConfiguration config, string baseRoute) where T : SubvertConfiguration
		{
			self.HookTo(controller => new WebApiHook(controller, config, baseRoute));
			return self;
		}
	}
}
