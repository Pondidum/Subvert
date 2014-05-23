using System;
using System.Linq;
using System.Net.Http;

namespace Subvert.ModelBinding
{
	public class QueryBinder : IModelBinder
	{
		public bool CanHandle(HttpRequestMessage message)
		{
			return message.GetQueryNameValuePairs().Any();
		}

		public void Bind(HttpRequestMessage message, object model)
		{
			var pairs = message.GetQueryNameValuePairs();
			var properties = model.GetType().GetProperties();

			foreach (var pair in pairs)
			{
				var property = properties.FirstOrDefault(p => p.Name.Equals(pair.Key, StringComparison.OrdinalIgnoreCase));

				if (property != null)
				{
					var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

					var value = Convert.ChangeType(pair.Value, type);

					property.SetValue(model, value);
				}
			}
		}
	}
}
