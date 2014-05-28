using Spark;

namespace Subvert.Spark
{
	internal class DescriptorBuilder
	{
		private readonly ISparkSettings _settings;

		public DescriptorBuilder(ISparkSettings settings)
		{
			_settings = settings;
		}

		public SparkViewDescriptor Build(string viewName)
		{
			var descriptor = new SparkViewDescriptor();

			descriptor.AddTemplate(viewName);

			_settings
				.Templates
				.Each(t => descriptor.AddTemplate(t));
			
			return descriptor;
		}
	}
}
