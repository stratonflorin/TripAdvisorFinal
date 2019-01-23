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
    public partial class ActivitiesView : UserControl
    {
        private List<getActivities_Result> _results;
        private List<getTypes_Result> _categoryTypes;
        string _currentTown;
        public ActivitiesView(string town)
        {
            InitializeComponent();
            if (town.Count() != 0)
            {
                _currentTown = town;
                Textblock_bestActivities.DataContext = town;
                using (var db = new TripAdvisorEntities())
                {
                    _results = db.getActivities(town).ToList();
                    _categoryTypes = db.getTypes(town).ToList();
                    listView_activities.ItemsSource = _results;
                    listView_category.ItemsSource = _categoryTypes;
                }
            }
        }

        private void listView_activities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView_activities.SelectedIndex;
            var usc = new ItemAccessedView(2,_results[index].ObiectivID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }

        private void listView_category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView_category.SelectedIndex;
            var usc = new ListActivitiesView(_currentTown, _categoryTypes[index].CategorieID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }

        private void Button_seeAll_Click(object sender, RoutedEventArgs e)
        {
            var usc = new ListActivitiesView(_currentTown);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }
    }
}
