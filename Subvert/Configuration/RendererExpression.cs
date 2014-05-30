using System;
using System.Collections.Generic;
using System.Linq;
using Subvert.ViewRendering;

namespace Subvert.Configuration
{
	public class RendererExpression
	{
		private readonly RendererConfiguration _configuration;
		private readonly List<IViewRenderer> _renderers;
		private readonly Type _target;
		private readonly int _offset;

		public RendererExpression(RendererConfiguration configuration, List<IViewRenderer> renderers, Type target, int offset)
		{
			if (renderers.Any(r => r.GetType() == target) == false) 
				throw new RendererNotFoundException(target);

			_configuration = configuration;
			_renderers = renderers;
			_target = target;
			_offset = offset;
		}

		public void Add<TRenderer>() where TRenderer : IViewRenderer
		{
			var type = typeof (TRenderer);

			if (_renderers.Any(r => r.GetType() == type))
				throw new RendererAlreadyRegisteredException(type);

			var index = _renderers.FindIndex(x => x.GetType() == _target);

			_configuration.Add<TRenderer>(index + _offset);
		}
	}
}
