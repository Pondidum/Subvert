using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Subvert
{
	public interface IRequest
	{
		IEnumerable<KeyValuePair<string, string>> Query { get; }
		string HttpMethod { get; }

		Uri RawUrl { get; }

		IEnumerable<string> GetHeader(string key);
		bool HasHeader(string key);

		NameValueCollection Form { get; }
	}
}
