using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExtSecureChat.PluginLibrary.JsonEntities
{
    public class SearchRepositories
    {
        [JsonProperty("total_count")]
        public int TotalCount;

        [JsonProperty("items")]
        public List<Repository> Repos;
    }
}
