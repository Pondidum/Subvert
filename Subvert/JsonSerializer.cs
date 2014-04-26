using Newtonsoft.Json;

namespace Subvert
{
	public class JsonSerializer : IJsonSerializer
	{
		public string Serialize(object input)
		{
			return JsonConvert.SerializeObject(input);
		}

		public T Deserialize<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
