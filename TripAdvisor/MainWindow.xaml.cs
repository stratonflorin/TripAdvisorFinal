using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TripAdvisor.Views;

namespace TripAdvisor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LoginView();
            this.Hide();
            HomeWindow2 hw;
            if (HomeWindow2.Instance == null)
                hw = HomeWindow2.createInstance(3);
            else hw = HomeWindow2.Instance;
            hw.Show();
        }

        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();

                return _instance;
            }
        }

        private void Button_minimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_closeWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_topBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
