using System;
using NSubstitute;
using Should;
using Xunit;

namespace Subvert.Tests.FrontControllerTests
{
	public class EndpointActionTests
	{
		private readonly Endpoint _endpoint;
		private readonly Type _actions;

		public EndpointActionTests()
		{
			_endpoint = new Endpoint(typeof(TestActions), "TestActions");
			_actions = typeof(TestActions);
		}

		[Fact]
		public void When_passed_a_method_with_no_parameters()
		{
			var mi = _actions.GetMethod("NoParameters");
			var action = new EndpointAction(_endpoint, mi);

			action.InputModelType.ShouldBeNull();
		}

		[Fact]
		public void When_passed_a_method_with_one_parameter()
		{
			var mi = _actions.GetMethod("OneParameter");
			var action = new EndpointAction(_endpoint, mi);

			action.InputModelType.ShouldEqual(typeof(TestActions.InputModel));
		}

		[Fact]
		public void When_passed_a_method_with_multiple_parameters()
		{
			var mi = _actions.GetMethod("ManyParameters");

			Assert.Throws<InvalidOperationException>(() => new EndpointAction(_endpoint, mi));
		}


		public class TestActions
		{
			public class InputModel { }
			public class OutputModel { }

			public OutputModel NoParameters() { return new OutputModel(); }
			public OutputModel OneParameter(InputModel first) { return new OutputModel(); }
			public OutputModel ManyParameters(InputModel first, InputModel second) { return new OutputModel(); }
		}
	}
}
