using System.Windows;

namespace ApplicationMain
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            Application.Current.MainWindow = window;
            window.Show();
        }
    }
}