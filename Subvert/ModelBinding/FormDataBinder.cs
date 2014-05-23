using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Subvert.ModelBinding
{
	public class FormDataBinder : IModelBinder
	{
		private readonly DictionaryBinder _binder;

		public FormDataBinder(DictionaryBinder binder)
		{
			_binder = binder;
		}

		public bool CanHandle(HttpRequestMessage message)
		{
			return message.Content.IsFormData();
		}

		public async void Bind(HttpRequestMessage message, object model)
		{
			var content = await message.Content.ReadAsFormDataAsync();

			var collection = content
				.Cast<string>()
				.Select(key => new KeyValuePair<string, string>(key, content[key]));

			_binder.Bind(collection, model);
		}
	}
}
