using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ActivitiesAccessedView.xaml
    /// </summary>
    public partial class ActivitiesAccessedView : UserControl
    {
        private List<getActivitiesPhotos_Result> _imageList;
        private int _imageIndex;
        public ActivitiesAccessedView(int actID)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                getActivitiesDetails_Result details = db.getActivitiesDetails(actID).ToList()[0];
                GridDescription.DataContext = details;
                InitalizePhotos(actID, details.Poza);
                var reviewList = db.getActivityReviews(actID);
                Listview_reviews.ItemsSource = reviewList;
            }
        }

        private void Button_imageLeft_Click(object sender, RoutedEventArgs e)
        {
            if (_imageIndex > 0)
            {
                _imageIndex--;
                Image_imageSlider.Source = ConvertToImage(_imageList[_imageIndex].Poza);
                Textblock_published.DataContext = _imageList[_imageIndex].Nume + " " + _imageList[_imageIndex].Prenume;
            }
        }
        private void Button_imageRight_Click(object sender, RoutedEventArgs e)
        {
            if (_imageIndex + 1 < _imageList.Count())
            {
                _imageIndex++;
                Image_imageSlider.Source = ConvertToImage(_imageList[_imageIndex].Poza);
                Textblock_published.DataContext = _imageList[_imageIndex].Nume + " " + _imageList[_imageIndex].Prenume;
            }
        }

        ~ActivitiesAccessedView()
        {
            _imageList.Clear();
        }

        public BitmapImage ConvertToImage(byte[] array)
        {
            BitmapImage bmpi = new BitmapImage();
            bmpi.BeginInit();
            bmpi.StreamSource = new MemoryStream(array);
            bmpi.EndInit();
            return bmpi;
        }

        private void InitalizePhotos(int actID, byte[] poza)
        {
            using (var db = new TripAdvisorEntities())
            {
                _imageList = db.getActivitiesPhotos(actID).ToList();
                var categoryList = db.getActivitiesCategory(actID).ToList();
                int i = 0;
                String category = "";
                while (i < categoryList.Count())
                {
                    category = category + categoryList[i].ToString() + ", ";
                    i++;
                }
                Textblock_category.Text = category;
            }
            _imageIndex = 0;
            if (poza != null)
            {
                Image_imageSlider.Source = ConvertToImage(poza);
                var firstPhoto = new getActivitiesPhotos_Result("Owner", "", poza);
                _imageList.Insert(0, firstPhoto);
                Textblock_published.DataContext = "Owner";
            }
        }
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
