using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Subvert
{
	internal class FrontController : ApiController
	{
		public FrontController()
		{

		}

		public HttpResponseMessage Handle()
		{
			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}
