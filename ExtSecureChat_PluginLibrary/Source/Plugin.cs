using static PluginLibrary.PluginHelper;

namespace PluginLibrary
{
    public abstract class Plugin
    {
        public enum PluginTypes
        {
            GUI_PLUGIN,
            EXTENSION_PLUGIN,
            GUI_AND_EXTENSION_PLUGIN
        }

        public abstract string Name { get; }
        public bool Enabled;
        public abstract PluginTypes PluginType { get; }

        public event BeforeFormTransitionEvent BeforeFormTransitionEventHandler
        {
            add { PluginHelper.BeforeFormTransitionEventHandler += value; }
            remove { PluginHelper.BeforeFormTransitionEventHandler -= value; }
        }

        public event AfterFormTransitionEvent AfterFormTransitionEventHandler
        {
            add { PluginHelper.AfterFormTransitionEventHandler += value; }
            remove { PluginHelper.AfterFormTransitionEventHandler -= value; }
        }

        public abstract void OnLoad();
    }
}
