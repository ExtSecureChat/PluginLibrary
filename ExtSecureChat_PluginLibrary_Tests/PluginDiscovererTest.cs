using System;
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
    }
}
