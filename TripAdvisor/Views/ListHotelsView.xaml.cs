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

namespace TripAdvisor.Views
{
    /// <summary>
    /// Interaction logic for ListHotelsView.xaml
    /// </summary>
    public partial class ListHotelsView : UserControl
    {
        List<getHotelsByRooms_Result> _roomList;
        List<getHotels_Result> _allList;
        public ListHotelsView(string town, int NumarPaturi=0)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                if(NumarPaturi==0)
                {
                    _allList = db.getHotels(town).ToList();
                    listView_hotels.ItemsSource = _allList;
                }
                else
                {
                    _roomList = db.getHotelsByRooms(town, NumarPaturi).ToList();
                    listView_hotels.ItemsSource = _roomList;
                }
            }
        }

        private void listView_hotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_roomList != null)
                if (_roomList.Count() > 0)
                {
                    int index = listView_hotels.SelectedIndex;
                    var usc = new ItemAccessedView(1,_roomList[index].CazareID);
                    HomeWindow2.Instance.GridMain.Children.Add(usc);
                }
            if (_allList != null)
                if (_allList.Count() > 0)
                {
                    int index = listView_hotels.SelectedIndex;
                    var usc = new ItemAccessedView(1,_allList[index].CazareID);
                    HomeWindow2.Instance.GridMain.Children.Add(usc);
                }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
