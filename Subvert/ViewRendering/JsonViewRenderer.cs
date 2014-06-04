using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

		public bool CanHandle(IRequest request)
		{
			var accept = request.GetHeader("content-type").ToList();

			return _contentTypes.Any(type => accept.Contains(type, StringComparer.OrdinalIgnoreCase));
		}

		public IResponse Render(object viewModel)
		{
			var ms = new MemoryStream();
			var writer = new StreamWriter(ms);
			writer.Write(_serializer.Serialize(viewModel));

			writer.Flush();
			ms.Position = 0;

			var response = new Response
			{
				StatusCode = HttpStatus.Ok,
				ContentStream = ms,
				ContentType = "text/json"
			};

			return response;

			//return new HttpResponseMessage
			//{
			//	StatusCode = HttpStatusCode.OK,
			//	Content = new StringContent(_serializer.Serialize(viewModel), Encoding.UTF8, "text/json"),
			//};
		}
	}
}
