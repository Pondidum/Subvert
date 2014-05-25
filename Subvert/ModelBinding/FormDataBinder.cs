using System;
using System.Collections.Generic;
using System.Linq;

namespace Subvert.ModelBinding
{
	public class FormDataBinder : IModelBinder
	{
		private readonly DictionaryBinder _binder;

		public FormDataBinder(DictionaryBinder binder)
		{
			_binder = binder;
		}

		public bool CanHandle(IRequest message)
		{
			return message
				.GetHeader("Content-Type")
				.Any(header => header.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase));
		}

		public async void Bind(IRequest message, object model)
		{

			var content = message.Form;
			var collection = content
				.Cast<string>()
				.Select(key => new KeyValuePair<string, string>(key, content[key]));

			_binder.Bind(collection, model);
		}
	}
}
