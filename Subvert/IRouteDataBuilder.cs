using System.Net.Http;

namespace Subvert
{
	public interface IRouteDataBuilder
	{
		RouteData Build(IRequest request);
	}
}
