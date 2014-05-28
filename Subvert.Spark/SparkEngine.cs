using System;
using System.IO;
using Spark;

namespace Subvert.Spark
{
	internal class SparkEngine
	{
		private readonly DescriptorBuilder _builder;
		private readonly SparkViewEngine _engine;

		public SparkEngine(DescriptorBuilder builder)
		{
			_builder = builder;
			_engine = new SparkViewEngine();
		}

		internal ISettableModel CreateView<TModel>(TModel model) where TModel : class
		{
			var view = GetView(typeof(TModel));
			view.SetModel(model);

			return view;
		}

		private ISettableModel GetView(Type modelType)
		{
			var modelName = modelType.Name;
			var viewName = String.Format("{0}.spark", modelName.Replace("ViewModel", ""));

			var descriptor = _builder.Build(viewName);
			var entry = _engine.CreateInstance(descriptor);

			return (ISettableModel)entry;
		} 
	}
}
