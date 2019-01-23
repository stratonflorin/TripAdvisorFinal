using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TripAdvisor.Views
{
    public partial class RestaurantsView : UserControl
    {
        private List<getRestaurants_Result> _results;
        private List<getPreparate_Result> _foodTypes;
        string _currentTown;
        public RestaurantsView(string town)
        {
            InitializeComponent();
            if(town.Count()!=0)
            {
                _currentTown = town;
                Textblock_bestRestaurants.DataContext = town;
                using (var db = new TripAdvisorEntities())
                {
                    _results = db.getRestaurants(town).ToList();
                    _foodTypes = db.getPreparate(town).ToList();
                    listView_restaurants.ItemsSource = _results;
                    listView_food.ItemsSource = _foodTypes;
                }
            }
        }

        private void listView_restaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index=listView_restaurants.SelectedIndex;
            var usc = new ItemAccessedView(3,_results[index].RestaurantID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }

        private void listView_food_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView_food.SelectedIndex;
            var usc = new ListRestaurantsView(_currentTown,_foodTypes[index].PreparatID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }

        private void Button_seeAll_Click(object sender, RoutedEventArgs e)
        {
            var usc = new ListRestaurantsView(_currentTown);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }
    }
}
