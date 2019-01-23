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
    public partial class TownOverviewView : UserControl
    {
        private List<getTop3Restaurants_Result> _restaurants;
        private List<getTop3Activities_Result> _activities;
        private List<getTop3Hotels_Result> _hotels;

        public TownOverviewView(string town)
        {
            InitializeComponent();
            if(town.Count()!=0)
            {
                using (var db = new TripAdvisorEntities())
                {
                    Textblock_bestActivities.DataContext = town;
                    Textblock_bestHotels.DataContext = town;
                    Textblock_bestRestaurants.DataContext = town;

                    _hotels = db.getTop3Hotels(town).ToList();
                    _restaurants = db.getTop3Restaurants(town).ToList();
                    _activities = db.getTop3Activities(town).ToList();

                    Listview_topRestaurants.ItemsSource = _restaurants;
                    Listview_topThingstodo.ItemsSource = _activities;
                    Listview_topHotels.ItemsSource = _hotels;
                }
            }
        }

        private void Listview_topRestaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Listview_topRestaurants.SelectedIndex;
            //var usc = new RestaurantAccessedView(_restaurants[index].RestaurantID);
            //HomeWindow2.Instance.GridMain.Children.Add(usc);
            var usc = new ItemAccessedView(3, _restaurants[index].RestaurantID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }
        private void Listview_topThingstodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Listview_topThingstodo.SelectedIndex;
           // var usc = new ActivitiesAccessedView(_activities[index].ObiectivID);
           // HomeWindow2.Instance.GridMain.Children.Add(usc);
            var usc = new ItemAccessedView(2, _activities[index].ObiectivID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }

        private void Listview_topHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Listview_topHotels.SelectedIndex;
            //var usc = new HotelAccessedView(_hotels[index].CazareID);
            //HomeWindow2.Instance.GridMain.Children.Add(usc);
            var usc = new ItemAccessedView(1, _hotels[index].CazareID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }
    }
}
