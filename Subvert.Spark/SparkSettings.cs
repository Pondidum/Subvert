namespace Subvert.Spark
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
