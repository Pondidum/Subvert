using System.Linq;
using System.Net.Http;

namespace Subvert.ModelBinding
{
	public class QueryBinder : IModelBinder
	{
		private readonly DictionaryBinder _binder;

		public QueryBinder(DictionaryBinder binder)
		{
			_binder = binder;
		}

		public bool CanHandle(HttpRequestMessage message)
		{
			return message.GetQueryNameValuePairs().Any();
		}

		public void Bind(HttpRequestMessage message, object model)
		{
			_binder.Bind(message.GetQueryNameValuePairs(), model);
		}
	}
}
