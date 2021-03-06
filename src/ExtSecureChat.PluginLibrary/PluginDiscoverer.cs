﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace ExtSecureChat.PluginLibrary
{
    public static class PluginDiscoverer
    {
        #region --- Get Github Plugins ---
        private static async Task<JsonEntities.SearchRepositories> getGithubPlugins()
        {
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
            task.Wait();
            var result = task.Result;

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
        #endregion

        #region --- Get Releases ---
        private static async Task<JsonEntities.Release> getLatestRelease(JsonEntities.Repository repository)
        {
            return await "https://api.github.com/repos"
                .AppendPathSegment(repository.Owner.Name)
                .AppendPathSegment(repository.Name)
                .AppendPathSegment("releases/latest")
                .WithHeader("Accept", "application / vnd.github.v3 + json")
                .WithHeader("User-Agent", "Anything")
                .GetJsonAsync<JsonEntities.Release>();
        }

        public static JsonEntities.Release GetLatestRelease(JsonEntities.Repository repository)
        {
            var task = getLatestRelease(repository);
            task.Wait();
            return task.Result;
        }

        private static async Task<List<JsonEntities.Release>> getReleases(JsonEntities.Repository repository)
        {
            return await "https://api.github.com/repos"
                .AppendPathSegment(repository.Owner.Name)
                .AppendPathSegment(repository.Name)
                .AppendPathSegment("releases")
                .WithHeader("Accept", "application / vnd.github.v3 + json")
                .WithHeader("User-Agent", "Anything")
                .GetJsonListAsync() as List<JsonEntities.Release>;
        }

        public static List<JsonEntities.Release> GetReleases(JsonEntities.Repository repository)
        {
            var task = getReleases(repository);
            task.Wait();
            return task.Result;
        }
        #endregion

        #region --- Download Asset ---
        private static async Task<string> downloadAsset(JsonEntities.ReleaseAsset asset, string path)
        {
            return await asset.BrowserDownloadUrl
                .DownloadFileAsync(path);
        }

        public static string DownloadAsset(JsonEntities.ReleaseAsset asset, string path)
        {
            var task = downloadAsset(asset, path);
            task.Wait();
            return task.Result;
        }
        #endregion
    }
}
