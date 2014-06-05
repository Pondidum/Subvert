using System;
using System.Reflection;

namespace Subvert
{
	public class HostAssembly
	{
		public Assembly Assembly { get; set; }

		public HostAssembly(Type typeInHost)
		{
			Assembly = typeInHost.Assembly;
		}
	}
}
