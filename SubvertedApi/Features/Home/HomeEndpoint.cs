namespace SubvertedApi.Features.Home
{
	public class HomeEndpoint
	{
		public HomeViewModel Get(HomeInputModel model)
		{
			return new HomeViewModel
			{
				Name = "Andy", 
				Age = 27
			};
		}
	}
}
