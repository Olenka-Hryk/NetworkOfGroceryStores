using System;
using System.Windows;


namespace NetworkOfGroceryStores
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            InitializeComponent();
        }

        private void test()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            AcountWindow acount = new AcountWindow();
            acount.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            test();
        }
    }
}
