using System.Linq;

namespace Subvert.ModelBinding
{
	public class QueryBinder : IModelBinder
	{
		private readonly DictionaryBinder _binder;

		public QueryBinder(DictionaryBinder binder)
		{
			_binder = binder;
		}

		public bool CanHandle(IRequest message)
		{
			return message.Query.Any();
		}

		public void Bind(IRequest message, object model)
		{
			_binder.Bind(message.Query, model);
		}
	}
}
