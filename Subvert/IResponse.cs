using System.IO;

namespace Subvert
{
	public interface IResponse
	{
		HttpStatus StatusCode { get; set; }
		Stream ContentStream { get; set; }
		string ContentType { get; set; }
	}
}
