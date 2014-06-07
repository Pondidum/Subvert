using System;
using System.Collections.Generic;
using System.Linq;

namespace Subvert.ModelBinding
{
	public class ModelBindingController : IModelBindingController
	{
		private readonly IEnumerable<IModelBinder> _binders;

		public ModelBindingController(IEnumerable<IModelBinder> binders)
		{
			_binders = binders;
		}

		public void Bind(IRequest message, Object model)
		{
			var binders = _binders.Where(binder => binder.CanHandle(message));

			foreach (var binder in binders)
			{
				binder.Bind(message, model);
			}
		}
	}
}
