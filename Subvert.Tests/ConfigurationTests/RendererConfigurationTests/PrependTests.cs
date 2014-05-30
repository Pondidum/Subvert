using System;
using System.Linq;
using Should;
using Subvert.Configuration;
using Xunit;

namespace Subvert.Tests.ConfigurationTests.RendererConfigurationTests
{
	public class PrependTests : RendererConfigurationTestBase
	{
		[Fact]
		public void Adds_to_an_empty_chain()
		{
			Renderers.Clear();

			Config.Prepend<NewRenderer>();

			Renderers.Single().ShouldBeType<NewRenderer>();
		}

		[Fact]
		public void Adds_to_the_begining_of_the_chain()
		{
			Config.Prepend<NewRenderer>();

			Renderers.First().ShouldBeType<NewRenderer>();
		}

		[Fact]
		public void Throws_if_the_type_is_already_in_the_chain()
		{
			AddRenderer(new NewRenderer());

			Assert.Throws<RendererAlreadyRegisteredException>(() => Config.Prepend<NewRenderer>());
		}
	}
}
