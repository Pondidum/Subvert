using System;
using System.Net.Http;

namespace Subvert.ModelBinding
{
	public interface IModelBinder
	{
		bool CanHandle(HttpRequestMessage message);
		void Bind(HttpRequestMessage message, Object model);
	}
}
