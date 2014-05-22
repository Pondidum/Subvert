using System;

namespace Subvert
{
	public interface IRequestResolver
	{
		object GetInstance(Type type);
	}
}
