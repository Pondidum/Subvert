namespace Subvert.WebApi
{
	//I am struggling to find a way to do without this in webapi...but failing atm :(
	public class ServiceLocator
	{
		public static IFrontController FrontController { get; set; }
	}
}
