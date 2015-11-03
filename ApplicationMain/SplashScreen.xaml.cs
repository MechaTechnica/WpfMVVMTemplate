using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace ApplicationMain
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private Timer splashDurationTimer;
        private Action postAction;

        public SplashScreen(double slashDuration, Action postAction)
        {
            InitializeComponent();
            splashDurationTimer = new Timer(slashDuration);
            splashDurationTimer.Elapsed += RemoveSplashScreen;
            splashDurationTimer.Enabled = true;
            splashDurationTimer.AutoReset = false;
            this.postAction = postAction;
        }

        ~SplashScreen()
        {
            splashDurationTimer.Dispose();
        }

        private void RemoveSplashScreen(Object source, System.Timers.ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                this.postAction(); // start the main window
                this.Close();      // close it after the main window starts
            });
        }
    }
}
