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
    /// Interaction logic for HotelAccessedView.xaml
    /// </summary>
    public partial class HotelAccessedView : UserControl
    {
        private List<getHotelPhotos_Result> _imageList;
        private int _imageIndex;
        public HotelAccessedView(int cazareId)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                getHotelDetails_Result details = db.getHotelDetails(cazareId).ToList()[0];
                GridHotel.DataContext = details;
                InitalizePhotos(cazareId, details.Poza);
                var reviewList = db.getHotelReviews(cazareId);
                Listview_reviews.ItemsSource = reviewList;
            }
        }
        private void InitalizePhotos(int cazareId, byte[] poza)
        {
            using (var db = new TripAdvisorEntities())
            {
                _imageList = db.getHotelPhotos(cazareId).ToList();
                var roomsList = db.getHotelRooms(cazareId).ToList();
                int i = 0;
                string rooms = "";
                while (i < roomsList.Count())
                {
                    rooms  = rooms + roomsList[i].ToString() + ", ";
                  i++;
                }
                Textblock_rooms.Text = rooms;
            }
            _imageIndex = 0;
            if (poza != null)
            {
                Image_imageSlider.Source = ConvertToImage(poza);
                var firstPhoto = new getHotelPhotos_Result("Owner", "", poza);
                _imageList.Insert(0, firstPhoto);
                Textblock_published.DataContext = "Owner";
            }
        }


        ~HotelAccessedView()
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

        

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
