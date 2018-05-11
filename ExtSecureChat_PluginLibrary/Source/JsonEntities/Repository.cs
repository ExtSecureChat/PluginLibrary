using Newtonsoft.Json;

namespace ExtSecureChat_PluginLibrary.JsonEntities
{
    public class Repository
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("full_name")]
        public string FullName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("owner")]
        public RepositoryOwner Owner;

        [JsonProperty("private")]
        public bool Private;

        [JsonProperty("html_url")]
        public string HtmlUrl;

        [JsonProperty("url")]
        public string Url;
    }
}
