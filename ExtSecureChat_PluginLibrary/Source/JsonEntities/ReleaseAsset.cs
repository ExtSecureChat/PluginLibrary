using Newtonsoft.Json;

namespace ExtSecureChat_PluginLibrary.JsonEntities
{
    public class ReleaseAsset
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("label")]
        public string Label;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("browser_download_url")]
        public string BrowserDownloadUrl;

        [JsonProperty("content_type")]
        public string ContentType;

        [JsonProperty("size")]
        public int Size;
    }
}
