using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExtSecureChat_PluginLibrary.JsonEntities
{
    public class Release
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("html_url")]
        public string HtmlUrl;

        [JsonProperty("assets")]
        public List<ReleaseAsset> Assets;
    }
}
