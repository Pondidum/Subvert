using System.Collections.Generic;

namespace Subvert.Spark
{
	public interface ISparkSettings
	{
		IEnumerable<string> Templates { get; }
	}
}
