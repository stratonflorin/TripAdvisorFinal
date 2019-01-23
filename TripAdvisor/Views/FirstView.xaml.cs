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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TripAdvisor.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class FirstView : UserControl
    {
        public FirstView(string Prenume)
        {
            InitializeComponent();
            Textblock_welcome.DataContext = Prenume;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
