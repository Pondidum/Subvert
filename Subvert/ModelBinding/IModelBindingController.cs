using System;

namespace Subvert.ModelBinding
{
	public interface IModelBindingController
	{
		void Bind(IRequest message, Object model);
	}
}
