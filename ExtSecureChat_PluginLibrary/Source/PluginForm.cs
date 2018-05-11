using System.Windows.Forms;

namespace PluginService
{
    public class PluginForm : Form, IForm
    {
        public virtual string GetName()
        {
            return "PLACEHOLDER_FORM";
        }
    }
}
