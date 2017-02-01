using HelloSignApi.TestGui.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloSignApi.TestGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var test = ModernWpf.UIHooks.EnableHighDpiSupport();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            ModernWpf.Theme.ApplyTheme(ModernWpf.ThemeColor.Light, ModernWpf.Accent.DarkBlue);
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            Settings.Default.Save();
            base.OnExit(e);
        }
    }
}
