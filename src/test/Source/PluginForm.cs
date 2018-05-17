using System.Windows.Forms;

namespace ExtSecureChat.PluginLibrary
{
    public class PluginForm : System.Windows.Forms, IForm
    {
        public virtual string GetName()
        {
            return "PLACEHOLDER_FORM";
        }
    }
}
