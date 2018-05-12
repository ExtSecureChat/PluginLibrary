using System;
using System.IO;
using ExtSecureChat_PluginLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtSecureChat_PluginLibrary_Tests
{
    [TestClass]
    public class PluginDiscovererTest
    {
        [TestMethod]
        public void GetGithubPluginsTest()
        {
            var repos = PluginDiscoverer.GetGithubPlugins();
            Assert.AreNotEqual(0, repos.Count);
        }

        [TestMethod]
        public void GetLatestRelease()
        {
            var repos = PluginDiscoverer.GetGithubPlugins();
            var testRepo = repos.Find(x => x.Id == 133084976);
            var latestRelease = PluginDiscoverer.GetLatestRelease(testRepo);
            Assert.AreNotEqual(null, latestRelease);
            Assert.AreNotEqual(0, latestRelease.Assets.Count);

            var firstAsset = latestRelease.Assets[0];
            Assert.AreEqual("Binaries.zip", firstAsset.Name);
        }

        [TestMethod]
        public void DownloadAsset()
        {
            var repos = PluginDiscoverer.GetGithubPlugins();
            var testRepo = repos.Find(x => x.Id == 133084976);
            var latestRelease = PluginDiscoverer.GetLatestRelease(testRepo);
            var firstAsset = latestRelease.Assets[0];

            var path = PluginDiscoverer.DownloadAsset(firstAsset, Directory.GetCurrentDirectory() + @"\temp");
            Assert.AreEqual(Directory.GetCurrentDirectory() + @"\temp\Binaries.zip", path);
        }
    }
}
