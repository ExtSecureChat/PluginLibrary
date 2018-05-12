using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ExtSecureChat_PluginLibrary
{
    public static class GenericPluginLoader<T>
    {
        public static List<T> LoadPlugins(string path)
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

                Type pluginType = typeof(T);
                List<Type> pluginTypes = new List<Type>();
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
                                if (type.FullName != null && type.IsSubclassOf(typeof(T)))
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }

                List<T> plugins = new List<T>(pluginTypes.Count);
                foreach (Type type in pluginTypes)
                {
                    T plugin = (T)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }

                return plugins;
            }

            return null;
        }
    }
}
