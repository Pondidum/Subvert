using System;
using System.Linq;
using Should;
using Subvert.Configuration;
using Xunit;

namespace Subvert.Tests.ConfigurationTests.RendererConfigurationTests
{
	public class BeforeTests : RendererConfigurationTestBase
	{
		[Fact]
		public void Adds_before_the_first_item_in_the_chain()
		{
			Config.Before<FirstRenderer>().Add<NewRenderer>();

			Renderers.First().ShouldBeType<NewRenderer>();
		}

		[Fact]
		public void Adds_before_the_last_item_in_the_chain()
		{
			Config.Before<LastRenderer>().Add<NewRenderer>();

			Renderers.Reverse();
			Renderers.Skip(1).First().ShouldBeType<NewRenderer>();
		}

		[Fact]
		public void Throws_if_the_target_doesnt_exist()
		{
			Assert.Throws<RendererNotFoundException>(() => Config.Before<ExtraRenderer>().Add<NewRenderer>());
		}

		[Fact]
		public void Throws_if_the_type_is_already_in_the_chain()
		{
			AddRenderer(new NewRenderer());
			Assert.Throws<RendererAlreadyRegisteredException>(() => Config.Before<LastRenderer>().Add<NewRenderer>());
		}
	}
}
