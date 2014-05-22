using System.Linq;
using System.Net.Http;

namespace Subvert
{
	public class RouteDataBuilder : IRouteDataBuilder
	{
		public RouteData Build(HttpRequestMessage request)
		{
			var segments = request.RequestUri.Segments.Where(s => s != "/").ToList();

			var route = new RouteData
			{
				Endpoint = segments.FirstOrDefault(),
				Action = segments.Skip(1).FirstOrDefault(),
				Method = request.Method.Method
			};

			return route;
		}
	}
}
