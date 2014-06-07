using System;
using NSubstitute;
using Should;
using Subvert.ModelBinding;
using Xunit;

namespace Subvert.Tests.FrontControllerTests
{
	public class ActionExecutorTests
	{
		private readonly IEndpointAction _action;
		private readonly Func<Object> _runTest;

		public ActionExecutorTests()
		{
			var resolver = Substitute.For<IRequestResolver>();
			resolver.GetInstance(Arg.Any<Type>()).Returns(new object());
			resolver.GetInstance(null).Returns(x => { throw new Exception(); });

			_action = Substitute.For<IEndpointAction>();

			_action.EndpointType.Returns(typeof(TestEndpoint));
			_action.Run(Arg.Any<object>(), Arg.Any<object>()).Returns(new TestViewModel());

			var executor = new ActionExecutor(resolver, Substitute.For<IModelBinder>());

			_runTest = () => executor.Execute(Substitute.For<IRequest>(), _action);
		}

		[Fact]
		public void When_the_action_has_no_input_model()
		{
			var model = _runTest();

			model.ShouldBeType<TestViewModel>();
		}

		[Fact]
		public void When_the_action_has_an_input_model()
		{
			_action.InputModelType.Returns(typeof(TestInputModel));

			var model = _runTest();

			model.ShouldBeType<TestViewModel>();

		}

		public class TestEndpoint { }
		public class TestInputModel { }
		public class TestViewModel { }
	}
}
