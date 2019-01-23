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
    /// Interaction logic for ListActivitiesView.xaml
    /// </summary>


    public partial class ListActivitiesView : UserControl
    {
        List<getActivitiesbyType_Result> _typeList;
        List<getActivities_Result> _allList;
        public ListActivitiesView(string town, int CategoryId = 0)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                if (CategoryId == 0)
                {
                    _allList = db.getActivities(town).ToList();
                    listView_activities.ItemsSource = _allList;
                }
                else
                {
                    _typeList = db.getActivitiesbyType(town, CategoryId).ToList();
                    listView_activities.ItemsSource = _typeList;
                }
            }
        }

        private void listView_activities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_typeList != null)
                if (_typeList.Count() > 0)
                {
                    int index = listView_activities.SelectedIndex;
                    var usc = new ItemAccessedView(2,_typeList[index].ObiectivID);
                    HomeWindow2.Instance.GridMain.Children.Add(usc);
                }
            if (_allList != null)
                if (_allList.Count() > 0)
                {
                    int index = listView_activities.SelectedIndex;
                    var usc = new ItemAccessedView(2,_allList[index].ObiectivID);
                    HomeWindow2.Instance.GridMain.Children.Add(usc);
                }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
