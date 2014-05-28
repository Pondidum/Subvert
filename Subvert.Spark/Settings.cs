using Spark;

namespace Subvert.Spark
{
	public class SettingsBuilder
	{
		public SparkSettings Settings { get; private set; }

		public SettingsBuilder()
		{
			Settings = new SparkSettings
			{
				PageBaseType = typeof (SubvertSparkView).FullName
			};

			AddNamespace("System.Linq");
		}

		public void AddNamespace(string ns)
		{
			Settings.AddNamespace(ns);
		}
	}
}
