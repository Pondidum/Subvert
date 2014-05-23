namespace SubvertedApi.Features.Home
{
	public class HomeEndpoint
	{
		public HomeViewModel Get(HomeInputModel model)
		{
			return new HomeViewModel
			{
				ID = model.ID,
				Name = "Andy", 
				Age = 27
			};
		}
	}
}
