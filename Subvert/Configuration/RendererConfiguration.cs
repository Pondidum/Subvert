using System;
using System.Collections.Generic;
using StructureMap;
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
			_renderers.Add(_create(typeof(TRenderer)));
		}

		public void Prepend<TRenderer>() where TRenderer : IViewRenderer
		{
			_renderers.Insert(0, _create(typeof(TRenderer)));
		}

		public RendererExpression Before<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(_create, _renderers, typeof(TRenderer), 0);
		}

		public RendererExpression After<TRenderer>() where TRenderer : IViewRenderer
		{
			return new RendererExpression(_create, _renderers, typeof(TRenderer), 1);
		}

	}
	//public class TestConfiguration : Configuration
	//{
	//	public TestConfiguration()
	//	{
	//		Renderers.Append<IViewRenderer>();
	//		Renderers.Prepend<IViewRenderer>();

	//		Renderers.Before<IViewRenderer>().Add<IViewRenderer>();
	//		Renderers.After<IViewRenderer>().Add<IViewRenderer>();
	//	}
	//}

}
