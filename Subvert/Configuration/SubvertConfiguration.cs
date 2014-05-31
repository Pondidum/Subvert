using StructureMap;
using Subvert.ViewRendering;

namespace Subvert.Configuration
{

	internal class GlobalConfiguration
	{
		public static IContainer Container { get; set; }
	}

	public class SubvertConfiguration
	{
		public RendererConfiguration Renderers { get { return _renderers;  } }

		private readonly RendererConfiguration _renderers;

		public SubvertConfiguration()
		{

			var type = GetType();
			if (type == typeof(SubvertConfiguration))
			{
				//_applicationAssembly = TypePool.FindTheCallingAssembly();

			}
			else
			{
				GlobalConfiguration.Container.GetInstance<HostAssembly>().SetType(type);
				//_applicationAssembly = type.Assembly;
			}

			_renderers = GlobalConfiguration.Container.GetInstance<RendererConfiguration>();
		}
	}
}