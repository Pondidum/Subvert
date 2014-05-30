using System;
using System.Collections.Generic;
using System.Net.Http;
using StructureMap;
using StructureMap.Graph;
using Subvert.Configuration;
using Subvert.ViewRendering;

namespace Subvert.Tests.ConfigurationTests.RendererConfigurationTests
{
	public class RendererConfigurationTestBase
	{
		private static readonly Func<Type, IViewRenderer> CreateInstance;

		static RendererConfigurationTestBase()
		{
			var container = new Container(c => c.Scan(a =>
			{
				a.TheCallingAssembly();
				a.WithDefaultConventions();
			}));

			CreateInstance = t => (IViewRenderer)container.GetInstance(t);
		}

		protected readonly List<IViewRenderer> Renderers;
		protected readonly RendererConfiguration Config;

		public RendererConfigurationTestBase()
		{
			Renderers = new List<IViewRenderer>();
			Config = new RendererConfiguration(CreateInstance, Renderers);

			AddAllRenderers();
		}

		protected void AddAllRenderers()
		{
			Renderers.Add(new FirstRenderer());
			Renderers.Add(new SecondRenderer());
			Renderers.Add(new ThirdRenderer());
			Renderers.Add(new FourthRenderer());
			Renderers.Add(new LastRenderer());
		}

		protected void AddRenderer(IViewRenderer renderer)
		{
			Renderers.Add(renderer);
		}
	}

	internal class BaseRenderer : IViewRenderer
	{
		public bool CanHandle(IRequest request)
		{
			return true;
		}

		public HttpResponseMessage Render(object viewModel)
		{
			return null;
		}
	}

	internal class FirstRenderer : BaseRenderer { }
	internal class SecondRenderer : BaseRenderer { }
	internal class ThirdRenderer : BaseRenderer { }
	internal class FourthRenderer : BaseRenderer { }
	internal class LastRenderer : BaseRenderer { }

	internal class ExtraRenderer : BaseRenderer { }
	internal class NewRenderer : BaseRenderer { }
}
