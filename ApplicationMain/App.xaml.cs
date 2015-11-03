using System;
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
            double splashDuration = 2000.0;
#if DEBUG
            splashDuration = 100.0;
#endif

            base.OnStartup(e);

            // start the main window hidden
            MainWindow mainWindow = new MainWindow();

            // this is called after the Splash Screen timer expires
            Action showMain = delegate
            {
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
            };

            SplashScreen splashScreen = new SplashScreen(splashDuration, showMain);
            Application.Current.MainWindow = splashScreen;
            splashScreen.Show();

            
        }
    }
}