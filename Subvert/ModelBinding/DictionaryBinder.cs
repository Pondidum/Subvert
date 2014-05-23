using System;
using System.Collections.Generic;
using System.Linq;

namespace Subvert.ModelBinding
{
	public class DictionaryBinder
	{
		public void Bind(IEnumerable<KeyValuePair<string, string>> source, object destination)
		{
			var properties = destination.GetType().GetProperties();

			foreach (var pair in source)
			{
				var property = properties.FirstOrDefault(p => p.Name.Equals(pair.Key, StringComparison.OrdinalIgnoreCase));

				if (property != null)
				{
					var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

					try
					{
						var value = Convert.ChangeType(pair.Value, type);
						property.SetValue(destination, value);
					}
					catch (FormatException ex)
					{
						//log it!
					}
				}
			}
		}
	}
}
