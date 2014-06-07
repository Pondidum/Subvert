using Subvert.ModelBinding;

namespace Subvert
{
	public class ActionExecutor
	{
		private readonly IRequestResolver _resolver;
		private readonly IModelBinder _modelBinder;

		public ActionExecutor(IRequestResolver resolver, IModelBinder modelBinder)
		{
			_resolver = resolver;
			_modelBinder = modelBinder;
		}

		public object Execute(IRequest request, IEndpointAction action)
		{
			var instance = _resolver.GetInstance(action.EndpointType);
			var inputModel = _resolver.GetInstance(action.InputModelType);

			_modelBinder.Bind(request, inputModel);

			return action.Run(instance, inputModel);
		}
	}
}
