using System;
using System.Collections.Generic;
using System.Linq;
using Subvert.ViewRendering;

namespace Subvert.Configuration
{
	public class RendererConfiguration
	{
		private readonly Func<Type, IViewRenderer> _create;
		private readonly List<IViewRenderer> _renderers;

		public RendererConfiguration(Func<Type, IViewRenderer> createInstance, List<IViewRenderer> renderers)
		{
			_create = createInstance;
			_renderers = renderers;
		}

		public void Append<TRenderer>() where TRenderer : IViewRenderer
		{
			Add<TRenderer>(_renderers.Count);
		}

		public void Prepend<TRenderer>() where TRenderer : IViewRenderer
		{
			Add<TRenderer>(0);
		}

		public RendererExpression Before<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(this, _renderers, typeof(TRenderer), 0);
		}

		public RendererExpression After<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(this, _renderers, typeof(TRenderer), 1);
		}

		internal void Add<TRenderer>(int index)
		{
			var type = typeof(TRenderer);

			if (_renderers.Any(r => r.GetType() == type))
				throw new RendererAlreadyRegisteredException(type);

			_renderers.Insert(index, _create(type));
		}
	}
}
