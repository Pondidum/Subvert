using System;
using System.Reflection;

namespace Subvert
{
	public class HostAssembly
	{
		private readonly Lazy<Assembly> _host;
		private Type _typeInHost;

		public HostAssembly()
		{
			_host = new Lazy<Assembly>(() => _typeInHost.Assembly);
		}

		public void SetType(Type typeInHost)
		{
			_typeInHost = typeInHost;
		}

		public Assembly Assembly { get { return _host.Value; }}
	}
}
