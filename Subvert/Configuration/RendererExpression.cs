using System;
using System.Collections.Generic;
using StructureMap;
using Subvert.ViewRendering;

namespace Subvert.Configuration
{
	public class RendererExpression
	{
		private readonly Func<Type, IViewRenderer> _create;
		private readonly List<IViewRenderer> _renderers;
		private readonly Type _target;
		private readonly int _offset;

		public RendererExpression(Func<Type, IViewRenderer> createInstance, List<IViewRenderer> renderers, Type target, int offset)
		{
			_create = createInstance;
			_renderers = renderers;
			_target = target;
			_offset = offset;
		}

		public void Add<TRenderer>() where TRenderer : IViewRenderer
		{
			var index = _renderers.FindIndex(x => x.GetType() == _target);

			_renderers.Insert(index + _offset, _create(typeof(TRenderer)));
		}
	}
}
