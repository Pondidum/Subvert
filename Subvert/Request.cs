using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;

namespace Subvert
{
	public class Request : IRequest
	{
		private readonly HttpRequestMessage _request;
		private readonly IEnumerable<KeyValuePair<string, IEnumerable<string>>> _headers;
		private readonly Lazy<NameValueCollection> _form;

		public IEnumerable<KeyValuePair<string, string>> Query { get; private set; }
		public string HttpMethod { get; private set; }
		public Uri RawUrl { get; private set; }

		public Request(HttpRequestMessage request)
		{
			_request = request;

			HttpMethod = request.Method.Method;
			Query = request.GetQueryNameValuePairs().ToList();
			RawUrl = request.RequestUri;

			var requestHeaders = request.Headers.ToDictionary(h => h.Key, h => h.Value);
			var contentHeaders = request.Content.Headers.ToDictionary(h => h.Key, h => h.Value);

			_headers = requestHeaders.Union(contentHeaders);

			_form = new Lazy<NameValueCollection>(() => _request.Content.ReadAsFormDataAsync().Result);
		}

		public bool HasHeader(string key)
		{
			return _headers.Any(h => h.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
		}

		public IEnumerable<string> GetHeader(string key)
		{
			return  _headers
				.Where(h => h.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
				.SelectMany(h => h.Value);
		}

		public NameValueCollection Form
		{
			get { return _form.Value; }
		}
	}
}
