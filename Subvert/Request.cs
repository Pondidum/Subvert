using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Subvert
{
	public class Request : IRequest
	{
		public IEnumerable<KeyValuePair<string, string>> Query { get; private set; }
		public string HttpMethod { get; private set; }
		public Uri RawUrl { get; private set; }

		public Request(HttpRequestMessage request)
		{
			HttpMethod = request.Method.Method;
			Query = request.GetQueryNameValuePairs().ToList();
			RawUrl = request.RequestUri;
		}
	}
}
