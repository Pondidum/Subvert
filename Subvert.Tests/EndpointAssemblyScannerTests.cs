using System;
using System.Linq;
using NSubstitute;
using Should;
using Xunit;

namespace Subvert.Tests.FrontControllerTests
{
	public class EndpointAssemblyScannerTests
	{
		private readonly IHostAssembly _hostAssembly;
		private readonly IEndpointConvention _endpointConvention;

		public EndpointAssemblyScannerTests()
		{
			_hostAssembly = Substitute.For<IHostAssembly>();
			_endpointConvention = Substitute.For<IEndpointConvention>();

			_endpointConvention
				.GetName(Arg.Any<Type>())
				.Returns(call => call.Arg<Type>().Name.Replace("Endpoint", ""));
		}

		[Fact]
		public void When_listing_all_endpoints_and_there_are_no_types()
		{
			_hostAssembly.AllTypes.Returns(new Type[] { });
			_endpointConvention.IsMatch(Arg.Any<Type>()).Returns(true);

			var es = new EndpointAssemblyScanner(_hostAssembly, _endpointConvention);

			es.GetEndpoints().ShouldBeEmpty();
		}

		[Fact]
		public void When_listing_all_endpoints_and_none_match_the_convention()
		{
			_hostAssembly.AllTypes.Returns(AllEndpoints);
			_endpointConvention.IsMatch(Arg.Any<Type>()).Returns(false);

			var es = new EndpointAssemblyScanner(_hostAssembly, _endpointConvention);

			es.GetEndpoints().ShouldBeEmpty();
		}

		[Fact]
		public void When_listing_all_endpoints_and_one_matches_the_convention()
		{
			_hostAssembly.AllTypes.Returns(AllEndpoints);
			_endpointConvention.IsMatch(Arg.Any<Type>()).Returns(false);
			_endpointConvention.IsMatch(typeof(PrivateEndpoint)).Returns(true);
			
			var es = new EndpointAssemblyScanner(_hostAssembly, _endpointConvention);

			es.GetEndpoints().Single().Name.ShouldEqual("Private");
		}

		private readonly static Type[] AllEndpoints =
		{
			typeof (PrivateEndpoint), 
			typeof (SecondEndpoint),
			typeof (ThirdEndpoint)
		};

		private class PrivateEndpoint { }
		private class SecondEndpoint { }
		public class ThirdEndpoint { }

	}
}
