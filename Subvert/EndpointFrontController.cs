using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Subvert
{
	internal class EndpointFrontController : ApiController
	{
		public EndpointFrontController()
		{

		}

		public HttpResponseMessage Handle()
		{
			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}
