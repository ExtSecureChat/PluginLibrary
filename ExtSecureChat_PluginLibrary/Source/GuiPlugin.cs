using System.Collections.Generic;

namespace ExtSecureChat_PluginLibrary
{
    public abstract class GuiPlugin : Plugin
    {
        public abstract void OverrideForms(ref List<PluginForm> forms);
    }
}
