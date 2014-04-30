using System;
using System.Linq;

namespace Subvert
{
	public class RouteConvention
	{
		public string GetEndpointName(Uri route)
		{
			return route.Segments.Skip(1).FirstOrDefault();
		}
	}
}
