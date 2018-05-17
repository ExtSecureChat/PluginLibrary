using System.Collections.Generic;

namespace ExtSecureChat.PluginLibrary
{
    public abstract class GuiPlugin : Plugin
    {
        public abstract void OverrideForms(ref List<PluginForm> forms);
    }
}
