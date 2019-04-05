using System.Threading;
using System.Windows;

namespace WindowsCredWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mutex = new Mutex(true, "WindowsCredWpfApp", out bool isNewInstance);

            if (!isNewInstance)
            {
                MessageBox.Show("Application Instance is already running.");
                Shutdown();
            }
        }
    }
}