using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Subvert.WebApi
{
	internal class WebApiController : ApiController
	{
		private readonly IFrontController _controller;

		public WebApiController()
		{
			_controller = ServiceLocator.FrontController;
		}

		public HttpResponseMessage Handle()
		{
			var request = new Request(Request);

			return BuildResponse(_controller.Handle(request));
		}

		private HttpResponseMessage BuildResponse(IResponse response)
		{
			var message = new HttpResponseMessage();

			if (response.ContentStream != null)
			{

				var content = new PushStreamContent((responseStream, cont, context) =>
				{
					response.ContentStream.CopyTo(responseStream);
					responseStream.Close();
					response.ContentStream.Close();
				});

				content.Headers.ContentType = new MediaTypeHeaderValue(response.ContentType);

				message.Content = content;
			}

			message.StatusCode = (HttpStatusCode)response.StatusCode;

			return message;
		}
	}
}
