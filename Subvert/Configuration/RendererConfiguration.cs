using System;
using System.Collections.Generic;
using System.Linq;
using Subvert.ViewRendering;

namespace Subvert.Configuration
{
	public class RendererConfiguration
	{
		private readonly List<IViewRenderer> _renderers;

		public RendererConfiguration(List<IViewRenderer> renderers)
		{
			_renderers = renderers;
		}

		public void Append<TRenderer>() where TRenderer : IViewRenderer, new()
		{
			Add(_renderers.Count, new TRenderer());
		}

		public void Prepend<TRenderer>() where TRenderer : IViewRenderer, new()
		{
			Add(0, new TRenderer());
		}

		public RendererExpression Before<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(this, _renderers, typeof(TRenderer), 0);
		}

		public RendererExpression After<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(this, _renderers, typeof(TRenderer), 1);
		}

		internal void Add<TRenderer>(int index, TRenderer instance) where TRenderer : IViewRenderer
		{
			var type = typeof(TRenderer);

			if (_renderers.Any(r => r.GetType() == type))
				throw new RendererAlreadyRegisteredException(type);

			_renderers.Insert(index, instance);
		}
	}
}
