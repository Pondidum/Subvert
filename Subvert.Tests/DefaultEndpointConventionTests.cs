using Should;
using Xunit;

namespace Subvert.Tests.FrontControllerTests
{
	public class DefaultEndpointConventionTests
	{
		private readonly DefaultEndpointConvention _convention;

		public DefaultEndpointConventionTests()
		{
			_convention = new DefaultEndpointConvention();
		}

		[Fact]
		public void When_checking_a_public_class_suffixed_with_endpoint()
		{
			_convention.IsMatch(typeof(PublicEndpoint)).ShouldBeTrue();
		}

		[Fact]
		public void When_checking_an_internal_class_suffixed_with_endpoint()
		{
			_convention.IsMatch(typeof(InternalEndpoint)).ShouldBeFalse();
		}

		[Fact]
		public void When_checking_a_private_class_suffixed_with_endpoint()
		{
			_convention.IsMatch(typeof(PrivateEndpoint)).ShouldBeFalse();
		}

		private class PrivateEndpoint { }
	}

	public class PublicEndpoint { }
	internal class InternalEndpoint { }
}
