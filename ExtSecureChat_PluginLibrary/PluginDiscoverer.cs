using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace ExtSecureChat_PluginLibrary
{
    public static class PluginDiscoverer
    {
        private static async Task<JsonEntities.SearchRepositories> getGithubPlugins()
        {
            List<string> plugins = new List<string>();

            return await "https://api.github.com/search/repositories"
                .WithHeader("Accept", "application / vnd.github.v3 + json")
                .WithHeader("User-Agent", "Anything")
                .SetQueryParams(new
                {
                    q = "ExtSeC_Plugin_",
                    sort = "stars"
                })
                .GetJsonAsync<JsonEntities.SearchRepositories>();
        }

        public static List<JsonEntities.Repository> GetGithubPlugins()
        {
            var task = getGithubPlugins();
            var result = task.Result;
            task.Wait();

            if (result.TotalCount > 0)
            {
                List<JsonEntities.Repository> removeList = new List<JsonEntities.Repository>();
                foreach (var repo in result.Repos)
                {
                    if (repo.Private || !repo.Name.StartsWith("ExtSeC_Plugin_"))
                    {
                        removeList.Add(repo);
                    }
                }
                
                foreach (var repo in removeList)
                {
                    result.Repos.Remove(repo);
                }

                return result.Repos;
            }
            else
            {
                return null;
            }
        }
    }
}
