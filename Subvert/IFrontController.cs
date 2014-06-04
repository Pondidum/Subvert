namespace Subvert
{
	public interface IFrontController
	{
		IResponse Handle(IRequest request);
	}
}
