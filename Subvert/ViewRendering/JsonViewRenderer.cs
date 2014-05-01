using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Subvert.ViewRendering
{
	public class JsonViewRenderer : IViewRenderer
	{
		private readonly IJsonSerializer _serializer;
		private readonly IEnumerable<string> _contentTypes;

		public JsonViewRenderer(IJsonSerializer serializer)
		{
			_serializer = serializer;
			_contentTypes = new[] { "text/json" };
		}

		public bool CanHandle(string contentType)
		{
			return _contentTypes.Contains(contentType, StringComparer.OrdinalIgnoreCase);
		}

		public HttpResponseMessage Render(object viewModel)
		{
			return new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent(_serializer.Serialize(viewModel), Encoding.UTF8, "text/json"),
			};
		}
	}
}
