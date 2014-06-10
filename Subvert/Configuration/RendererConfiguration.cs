using System.Collections.Generic;
using System.Linq;
using Subvert.ViewRendering;

namespace Subvert.Configuration
{
	public class RendererConfiguration
	{
		public List<IViewRenderer> Renderers { get; private set; }

		public RendererConfiguration(List<IViewRenderer> renderers)
		{
			Renderers = renderers;
		}

		public void Append<TRenderer>() where TRenderer : IViewRenderer, new()
		{
			Add(Renderers.Count, new TRenderer());
		}

		public void Prepend<TRenderer>() where TRenderer : IViewRenderer, new()
		{
			Add(0, new TRenderer());
		}

		public RendererExpression Before<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(this, Renderers, typeof(TRenderer), 0);
		}

		public RendererExpression After<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(this, Renderers, typeof(TRenderer), 1);
		}

		internal void Add<TRenderer>(int index, TRenderer instance) where TRenderer : IViewRenderer
		{
			var type = typeof(TRenderer);

			if (Renderers.Any(r => r.GetType() == type))
				throw new RendererAlreadyRegisteredException(type);

			Renderers.Insert(index, instance);
		}
	}
}
