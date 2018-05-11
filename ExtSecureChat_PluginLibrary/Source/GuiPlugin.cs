using System.Collections.Generic;

namespace PluginService
{
    public abstract class GuiPlugin : Plugin
    {
        public abstract void OverrideForms(ref List<PluginForm> forms);
    }
}
