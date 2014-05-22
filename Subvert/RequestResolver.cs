using System;
using StructureMap;

namespace Subvert
{
	public class RequestResolver : IRequestResolver
	{
		private readonly IContainer _container;

		public RequestResolver(IContainer container)
		{
			_container = container;
		}

		public object GetInstance(Type type)
		{
			return _container.GetInstance(type);
		}
	}
}
