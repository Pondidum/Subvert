namespace Subvert.Spark.Configuration
{
	public class SparkConfiguration
	{
		public static ISparkConfiguration Default { get; private set; }

		static SparkConfiguration()
		{
			Default = new SparkDefaultConfiguration();
		}
	}

}
