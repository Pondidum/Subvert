using System.Collections.Generic;
using System.IO;

namespace Subvert.Spark.Configuration
{
	internal class SparkDefaultConfiguration : ISparkConfiguration
	{
		public IEnumerable<string> Templates { get; private set; }

		public SparkDefaultConfiguration()
		{
			Templates = new List<string>
			{
				Path.Combine("Shared", "Application.spark")
			};
		}
	}
}
