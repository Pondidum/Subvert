using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Subvert
{
	public class Request : IRequest
	{
		private readonly HttpRequestMessage _request;

		public IEnumerable<KeyValuePair<string, string>> Query { get; private set; }
		public string HttpMethod { get; private set; }
		public Uri RawUrl { get; private set; }

		public Request(HttpRequestMessage request)
		{
			_request = request;
			HttpMethod = request.Method.Method;
			Query = request.GetQueryNameValuePairs().ToList();
			RawUrl = request.RequestUri;
		}

		public IEnumerable<string> GetHeader(string key)
		{
			return _request.Headers.GetValues(key) ?? Enumerable.Empty<string>();
		}

		public bool HasHeader(string key)
		{
			return _request.Headers.Contains(key);
		}
	}
}
