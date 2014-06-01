namespace Subvert.Configuration
{
	public abstract class SubvertConfiguration
	{
		public RendererConfiguration Renderers { get; internal set; }
		public abstract void Configure();
	}
}
