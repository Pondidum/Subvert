namespace Subvert.ViewRendering
{
	public interface IViewRendererFactory
	{
		IViewRenderer ForContentType(IRequest request);
	}
}
