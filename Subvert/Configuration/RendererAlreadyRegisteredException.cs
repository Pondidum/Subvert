using System;

namespace Subvert.Configuration
{
	public class RendererAlreadyRegisteredException : Exception
	{
		public RendererAlreadyRegisteredException(Type type)
			:base(string.Format("The renderer '{0}' has already been registered.", type.Name))
		{
		}
	}
}
