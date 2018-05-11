using Newtonsoft.Json;

namespace ExtSecureChat_PluginLibrary.JsonEntities
{
    public class RepositoryOwner
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("login")]
        public string Name;
    }
}
