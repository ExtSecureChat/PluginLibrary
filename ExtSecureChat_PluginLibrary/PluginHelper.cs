namespace PluginService
{
    public static class PluginHelper
    {
        public delegate void ChangeFormsEvent(PluginForm currentForm, string form);
        public static event ChangeFormsEvent ChangeFormsEventHandler;

        public delegate void ShowDialogFormEvent(PluginForm currentForm, string form);
        public static event ShowDialogFormEvent ShowDialogFormEventHandler;

        public delegate void BeforeFormTransitionEvent(PluginForm currentForm, ref string destinationForm);
        public static event BeforeFormTransitionEvent BeforeFormTransitionEventHandler;

        public delegate void AfterFormTransitionEvent(PluginForm currentForm, ref string destinationForm);
        public static event AfterFormTransitionEvent AfterFormTransitionEventHandler;

        public static class Forms
        {
            public const string
            PLUGIN_SELECTOR_FORM = "PLUGIN_SELECTOR_FORM",
            CONNECT_FORM = "CONNECT_FORM",
            LOGIN_FORM = "LOGIN_FORM",
            REGISTRATION_FORM = "REGISTRATION_FORM",
            MAIN_FORM = "MAIN_FORM",
            CREATE_GROUP_FORM = "CREATE_GROUP_FORM";
        }
        
        public static void ChangeForms(PluginForm currentForm, string destinationForm)
        {
            BeforeFormTransitionEventHandler?.Invoke(currentForm, ref destinationForm);
            ChangeFormsEventHandler?.Invoke(currentForm, destinationForm);
            AfterFormTransitionEventHandler?.Invoke(currentForm, ref destinationForm);
        }

        public static void ShowDialogForm(PluginForm currentForm, string destinationForm)
        {
            ShowDialogFormEventHandler?.Invoke(currentForm, destinationForm);
        }
    }
}
