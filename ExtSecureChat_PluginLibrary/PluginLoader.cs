using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PluginLibrary
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
                List<Type> pluginTypes = new List<Type>();
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();

                        foreach (Type type in types)
                        {
                            if (type.IsInterface || !type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetProperty("Name") != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }

                List<Plugin> plugins = new List<Plugin>(pluginTypes.Count);
                foreach (Type type in pluginTypes)
                {
                    Plugin plugin = (Plugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }

                return plugins;
            }

            return null;
        }
    }
}
