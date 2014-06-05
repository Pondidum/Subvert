using System;
using NSubstitute;
using Should;
using Xunit;

namespace Subvert.Tests.FrontControllerTests
{
	public class EndpointAssemblyScannerTests
	{
		private readonly IHostAssembly _hostAssembly;
		private readonly IEndpointConvention _namingConvention;

		public EndpointAssemblyScannerTests()
		{
			_hostAssembly = Substitute.For<IHostAssembly>();
			_namingConvention = Substitute.For<IEndpointConvention>();
		}

		[Fact]
		public void When_listing_all_endpoints_and_there_are_no_types()
		{
			_hostAssembly.AllTypes.Returns(new Type[] { });
			_namingConvention.IsMatch(Arg.Any<Type>()).Returns(true);

			var es = new EndpointAssemblyScanner(_hostAssembly, _namingConvention);

			es.GetEndpoints().ShouldBeEmpty();
		}

		[Fact]
		public void When_listing_all_endpoints_and_there_are_only_private_types()
		{
			_hostAssembly.AllTypes.Returns(new Type[] { typeof (MatchingPrivateEndpoint) });
			_namingConvention.IsMatch(Arg.Any<Type>()).Returns(true);
		}


		private class MatchingPrivateEndpoint
		{
		}
	}
}
