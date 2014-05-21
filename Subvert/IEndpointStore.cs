namespace Subvert
{
	public interface IEndpointStore
	{
		Endpoint GetEndpointByName(string name);
	}
}
