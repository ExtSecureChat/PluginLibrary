using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ExtSecureChat_PluginLibrary
{
    public static class PluginLoader
    {
        public static List<Plugin> LoadPlugins(string path)
        {
            string[] dllFileNames = null;

            if (Directory.Exists(path))
            {
                dllFileNames = Directory.GetFiles(path, "*.dll");

                List<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
                foreach (string dllFile in dllFileNames)
                {
                    AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                    Assembly assembly = Assembly.Load(an);
                    assemblies.Add(assembly);
                }

                Type pluginType = typeof(Plugin);
                Dictionary<string, Type> pluginTypes = new Dictionary<string, Type>();
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();

                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetProperty("Name") != null)
                                {
                                    string fullName = assembly.ManifestModule.Name;
                                    pluginTypes.Add(fullName.Remove(fullName.Length - 4, 4), type);
                                }
                            }
                        }
                    }
                }

                List<Plugin> plugins = new List<Plugin>(pluginTypes.Count);
                foreach (var type in pluginTypes)
                {
                    Plugin plugin = (Plugin)Activator.CreateInstance(type.Value);
                    plugin.FullName = type.Key + "(" + plugin.Name + ")";
                    plugins.Add(plugin);
                }

                return plugins;
            }

            return null;
        }
    }
}
