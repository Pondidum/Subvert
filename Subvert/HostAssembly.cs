using System;
using System.Collections.Generic;
using System.Reflection;

namespace Subvert
{
	public class HostAssembly : IHostAssembly
	{
		private readonly Assembly _assembly;

		public HostAssembly(Type typeInHost)
		{
			_assembly = typeInHost.Assembly;
		}

		public IEnumerable<Type> AllTypes { get { return _assembly.GetTypes(); } }
	}
}
