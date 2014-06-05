using System.Reflection;

namespace Subvert
{
	public interface IHostAssembly
	{
		Assembly Assembly { get; set; }
	}
}
