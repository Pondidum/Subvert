namespace Subvert.ModelBinding
{
	public interface IModelBinder
	{
		bool CanHandle(IRequest message);
		void Bind(IRequest message, object model);
	}
}
