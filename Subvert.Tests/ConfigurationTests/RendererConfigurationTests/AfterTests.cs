using System;
using System.Linq;
using Should;
using Subvert.Configuration;
using Xunit;

namespace Subvert.Tests.ConfigurationTests.RendererConfigurationTests
{
	public class AfterTests : RendererConfigurationTestBase
	{
		[Fact]
		public void Adds_after_the_first_item_in_the_chain()
		{
			Config.After<FirstRenderer>().Add<NewRenderer>();

			Renderers.Skip(1).First().ShouldBeType<NewRenderer>();
		}

		[Fact]
		public void Adds_after_the_last_item_in_the_chain()
		{
			Config.After<LastRenderer>().Add<NewRenderer>();

			Renderers.Last().ShouldBeType<NewRenderer>();
		}

		[Fact]
		public void Throws_if_the_target_doesnt_exist()
		{
			Assert.Throws<RendererNotFoundException>(() => Config.After<ExtraRenderer>().Add<NewRenderer>());
		}

		[Fact]
		public void Throws_if_the_type_is_already_in_the_chain()
		{
			AddRenderer(new NewRenderer());
			Assert.Throws<Exception>(() => Config.After<LastRenderer>().Add<NewRenderer>());
		}
	}
}
