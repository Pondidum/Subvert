using System.Collections.Generic;

namespace Subvert.Spark.Configuration
{
	public interface ISparkSettings
	{
		IEnumerable<string> Templates { get; }
	}
}
