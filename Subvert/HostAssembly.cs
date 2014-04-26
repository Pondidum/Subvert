using System;
using System.Reflection;

namespace Subvert
{
	public class HostAssembly
	{
		private readonly Lazy<Assembly> _host;

		public HostAssembly(Type typeInHost)
		{
			_host = new Lazy<Assembly>(() => typeInHost.Assembly);
		}

		public Assembly Assembly { get { return _host.Value; }}
	}
}
