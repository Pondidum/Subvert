using System;

namespace Subvert.Configuration
{
	public class RendererNotFoundException : Exception
	{
		public RendererNotFoundException(Type target)
			: base(string.Format("Unable to find a registered renderer of type '{0}'", target.Name))
		{
		}
	}
}
