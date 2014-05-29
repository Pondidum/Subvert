namespace Subvert.Spark.Configuration
{
	public class SparkSettings
	{
		public static ISparkSettings Default { get; private set; }

		static SparkSettings()
		{
			Default = new SparkDefaultSettings();
		}
	}

}
