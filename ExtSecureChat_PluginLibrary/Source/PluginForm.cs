using System.Windows.Forms;

namespace ExtSecureChat_PluginLibrary
{
    public class PluginForm : Form, IForm
    {
        public virtual string GetName()
        {
            return "PLACEHOLDER_FORM";
        }
    }
}
