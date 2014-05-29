using System.Collections.Generic;
using System.IO;

namespace Subvert.Spark.Configuration
{
	internal class SparkDefaultSettings : ISparkSettings
	{
		public IEnumerable<string> Templates { get; private set; }

		public SparkDefaultSettings()
		{
			Templates = new List<string>
			{
				Path.Combine("Shared", "Application.spark")
			};
		}
	}
}
