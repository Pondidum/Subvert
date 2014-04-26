namespace Subvert
{
	public interface IJsonSerializer
	{
		string Serialize(object input);
		T Deserialize<T>(string json);
	}
}
