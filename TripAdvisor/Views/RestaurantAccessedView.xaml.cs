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
    /// Interaction logic for RestaurantAccessedView.xaml
    /// </summary>
    public partial class RestaurantAccessedView : UserControl
    {
        private List<getRestaurantPhotos_Result> _imageList;
        private int _imageIndex;
        private int _restaurantId;

        public RestaurantAccessedView(int restId)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                getRestaurantDetails_Result details = db.getRestaurantDetails(restId).ToList()[0];
                GridDescription.DataContext = details;
                InitalizePhotos(restId, details.Poza);
                var reviewList = db.getRestaurantReviews(restId);
                Listview_reviews.ItemsSource = reviewList;
            }
            _restaurantId = restId;
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

        ~RestaurantAccessedView()
        {
            _imageList.Clear();
        }

        public BitmapImage ConvertToImage(byte [] array)
        {
            BitmapImage bmpi = new BitmapImage();
            bmpi.BeginInit();
            bmpi.StreamSource = new MemoryStream(array);
            bmpi.EndInit();
            return bmpi;
        }

        private void InitalizePhotos(int restId, byte[] poza)
        {
            using (var db = new TripAdvisorEntities())
            {
                _imageList = db.getRestaurantPhotos(restId).ToList();
                var menuList = db.getRestaurantMenu(restId).ToList();
                int i = 0;
                String menu = "";
                while (i < menuList.Count())
                {
                    menu = menu + menuList[i].ToString() + ", ";
                    i++;
                }
                Textblock_menu.Text = menu;
            }
            _imageIndex = 0;
            if (poza != null)
            {
                Image_imageSlider.Source = ConvertToImage(poza);
                var firstPhoto = new getRestaurantPhotos_Result("Owner", "", poza, null);
                _imageList.Insert(0, firstPhoto);
                Textblock_published.DataContext = "Owner";
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void Button_submitReview_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Bar_Review.Value.ToString());
            if (Textbox_comentariu.Text != null)
            {
                if (Bar_Review.Value != 0)
                {
                    if (Bar_Pricing.Value != 0)
                    {
                        var recenzie = new RecenziiRestaurante();
                        recenzie.Comentarii = Textbox_comentariu.Text;
                        recenzie.Data = DateTime.Now;
                        recenzie.Pret = Bar_Pricing.Value;
                        recenzie.Stele = Bar_Review.Value;
                        recenzie.UserID = HomeWindow2.Instance.getUser();
                        recenzie.RestaurantID = _restaurantId;
                        using (var db = new TripAdvisorEntities())
                        {
                            db.RecenziiRestaurante.Add(recenzie);
                            db.SaveChanges();
                            MessageBox.Show("Review added!");
                            Textbox_comentariu.Clear();
                        }

                    }
                    else MessageBox.Show("Select a pricing value!");
                }
                else MessageBox.Show("Select a rating value!");

            }
            else MessageBox.Show("Add a comment!");
        }
    }
}
