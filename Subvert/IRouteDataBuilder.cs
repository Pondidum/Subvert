namespace Subvert
{
	public interface IRouteDataBuilder
	{
		RouteData Build(IRequest request);
	}
}
