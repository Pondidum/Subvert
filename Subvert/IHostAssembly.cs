using System;
using System.Collections.Generic;

namespace Subvert
{
	public interface IHostAssembly
	{
		IEnumerable<Type> AllTypes { get; }
	}
}
