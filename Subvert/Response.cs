using System.IO;

namespace Subvert
{
	public class Response : IResponse
	{
		public HttpStatus StatusCode { get; set; }
		public Stream ContentStream { get; set; }
		public string ContentType { get; set; }
	}
}
