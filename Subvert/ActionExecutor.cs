using Subvert.ModelBinding;

namespace Subvert
{
	public class ActionExecutor
	{
		private readonly IRequestResolver _resolver;
		private readonly IModelBindingController _modelBindingController;

		public ActionExecutor(IRequestResolver resolver, IModelBindingController modelBindingController)
		{
			_resolver = resolver;
			_modelBindingController = modelBindingController;
		}

		public object Execute(IRequest request, IEndpointAction action)
		{
			var instance = _resolver.GetInstance(action.EndpointType);
			object inputModel = null;

			if (action.InputModelType != null)
			{
				inputModel = _resolver.GetInstance(action.InputModelType);
				_modelBindingController.Bind(request, inputModel);
			}

			return action.Run(instance, inputModel);
		}
	}
}
