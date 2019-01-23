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
    /// Interaction logic for ListRestaurantsView.xaml
    /// </summary>
    public partial class ListRestaurantsView : UserControl
    {
        List<getRestaurantsByFood_Result> _foodList;
        List<getRestaurants_Result> _allList;
        public ListRestaurantsView(string town,int FoodId = 0)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                if (FoodId == 0)
                {
                    _allList = db.getRestaurants(town).ToList();
                    listView_restaurants.ItemsSource = _allList;
                }
                else
                {
                    _foodList = db.getRestaurantsByFood(town, FoodId).ToList();
                    listView_restaurants.ItemsSource = _foodList;
                }
            }
        }

        private void listView_restaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_foodList != null)
                if (_foodList.Count() > 0)
                {
                    int index = listView_restaurants.SelectedIndex;
                    var usc = new ItemAccessedView(3,_foodList[index].RestaurantID);
                    HomeWindow2.Instance.GridMain.Children.Add(usc);
                }
            if(_allList != null)
                if(_allList.Count()>0)
                {
                    int index = listView_restaurants.SelectedIndex;
                    var usc = new ItemAccessedView(3,_allList[index].RestaurantID);
                    HomeWindow2.Instance.GridMain.Children.Add(usc);
                }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
