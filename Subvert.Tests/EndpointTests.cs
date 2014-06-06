using Should;
using Xunit;

namespace Subvert.Tests.FrontControllerTests
{
	public class EndpointTests
	{
		private readonly Endpoint _endpoint;

		public EndpointTests()
		{
			_endpoint = new Endpoint(typeof(TestEndpoint), "Test");
		}

		[Fact]
		public void It_finds_all_httpMethod_prefixed_methods_with_one_parameter()
		{
			_endpoint.GetAction("Get", "Index").ShouldNotBeNull();
			_endpoint.GetAction("Post", "Index").ShouldNotBeNull();
			_endpoint.GetAction("Delete", "Index").ShouldNotBeNull();
			_endpoint.GetAction("Get", "Other").ShouldNotBeNull();
		}

		[Fact]
		public void It_finds_methods_ignoring_action_case()
		{
			_endpoint.GetAction("Get", "INDEX").ShouldNotBeNull();
		}

		[Fact]
		public void It_finds_methods_ignoring_httpMethod_case()
		{
			_endpoint.GetAction("GET", "Index").ShouldNotBeNull();
		}

		[Fact]
		public void It_does_not_find_methods_with_multiple_parameters()
		{
			_endpoint.GetAction("Get", "Many").ShouldBeNull();
		}



		private class TestEndpoint
		{
			public TestViewModel GetIndex(TestInputModel input)
			{
				return new TestViewModel();
			}

			public TestViewModel GetOther(TestInputModel input)
			{
				return new TestViewModel();
			}

			public TestViewModel PostIndex(TestViewModel input)
			{
				return new TestViewModel();
			}

			public TestViewModel DeleteIndex(TestViewModel input)
			{
				return new TestViewModel();
			}

			public TestViewModel GetMany(TestViewModel input, TestViewModel other)
			{
				return new TestViewModel();
			}
		}

		private class TestViewModel
		{

		}

		private class TestInputModel
		{

		}
	}


}
