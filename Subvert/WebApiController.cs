using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Subvert
{
	internal class WebApiController : ApiController
	{
		private readonly FrontController _controller;

		public WebApiController(FrontController controller)
		{
			_controller = controller;
		}

		public HttpResponseMessage Handle()
		{
			var request = new Request(Request);

			return BuildResponse(_controller.Handle(request));
		}

		private HttpResponseMessage BuildResponse(IResponse response)
		{
			var content = new PushStreamContent((responseStream, cont, context) =>
			{
				response.ContentStream.CopyTo(responseStream);
				responseStream.Close();
				response.ContentStream.Close();
			});

			if (string.IsNullOrWhiteSpace(response.ContentType) == false)
			{
				content.Headers.ContentType = new MediaTypeHeaderValue(response.ContentType);
			}

			var message = new HttpResponseMessage
			{
				StatusCode = (HttpStatusCode)response.StatusCode,
				Content = content,
			};

			return message;
		}
	}
}
