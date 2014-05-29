using System.Collections.Generic;

namespace Subvert.Spark.Configuration
{
	public interface ISparkConfiguration
	{
		IEnumerable<string> Templates { get; }
	}
}
