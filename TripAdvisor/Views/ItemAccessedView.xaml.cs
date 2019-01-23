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
    /// Interaction logic for ItemAccessedView.xaml
    /// </summary>
    public partial class ItemAccessedView : UserControl
    {
        private List<getRestaurantPhotos_Result> _imageListRestaurants;
        private List<getHotelPhotos_Result> _imageListHotels;
        private List<getActivitiesPhotos_Result> _imageListActivities;
        private int _imageIndex;
        private int _id;
        private int _type;
        public ItemAccessedView(int type, int id)
        {
            _type = type;
            _id = id;

            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                switch (type)
                {
                    case 1: // hotels
                        var details = db.getHotelDetails(_id).ToList()[0];
                        GridRestaurants.Visibility = Visibility.Hidden;
                        Pricing1.Visibility = Visibility.Hidden;
                        GridHotel.Visibility = Visibility.Visible;
                        GridHotel.DataContext = details;
                        var reviewList = db.getHotelReviews(_id);
                        Listview_reviews.ItemsSource = reviewList;
                        _imageListHotels = db.getHotelPhotos(_id).ToList();
                        _imageIndex = 0;
                        Textblock_program.Text = details.Email;
                        var roomsList = db.getHotelRooms(_id).ToList();
                        int j = 0;
                        string rooms = "";
                        while (j < roomsList.Count())
                        {
                            rooms = rooms + roomsList[j].ToString() + ", ";
                            j++;
                        }
                        Textblock_rooms.Text = rooms;
                        if (details.Poza != null)
                        {
                            Image_imageSlider.Source = ConvertToImage(details.Poza);
                            var firstPhoto = new getHotelPhotos_Result("Owner", "", details.Poza);
                            _imageListHotels.Insert(0, firstPhoto);
                            Textblock_published.DataContext = "Owner";
                        }
                        Bar_Pricing.Visibility = Visibility.Hidden;
                        break;
                    case 2: // activities
                        var details2 = db.getActivitiesDetails(_id).ToList()[0];
                        //GridRestaurants.Visibility = Visibility.Hidden;
                        //GridActivities.Visibility = Visibility.Visible;
                        GridActivities.DataContext = details2;
                        var reviewList2 = db.getActivityReviews(_id).ToList();
                        Listview_reviews.ItemsSource = reviewList2;
                        _imageListActivities = db.getActivitiesPhotos(_id).ToList();
                        _imageIndex = 0;
                        if (details2.Poza != null)
                        {
                            Image_imageSlider.Source = ConvertToImage(details2.Poza);
                            var firstPhoto2 = new getActivitiesPhotos_Result("Owner", "", details2.Poza, null);
                            _imageListActivities.Insert(0, firstPhoto2);
                            Textblock_published.DataContext = "Owner";
                        }
                        Bar_Pricing.Visibility = Visibility.Hidden;
                        break; 
                    case 3: // restaurants
                        var details3 = db.getRestaurantDetails(_id).ToList()[0];
                        GridRestaurants.DataContext = details3;
                        var reviewList3 = db.getRestaurantReviews(_id);
                        Listview_reviews.ItemsSource = reviewList3;
                        _imageListRestaurants = db.getRestaurantPhotos(_id).ToList();
                        var menuList = db.getRestaurantMenu(_id).ToList();
                        int i = 0;
                        String menu = "";
                        while (i < menuList.Count())
                        {
                            menu = menu + menuList[i].ToString() + ", ";
                            i++;
                        }
                        Textblock_menu.Text = menu;
                        _imageIndex = 0;
                        if (details3.Poza != null)
                        {
                            Image_imageSlider.Source = ConvertToImage(details3.Poza);
                            var firstPhoto3 = new getRestaurantPhotos_Result("Owner", "", details3.Poza, null);
                            _imageListRestaurants.Insert(0, firstPhoto3);
                            Textblock_published.DataContext = "Owner";
                        }
                        break;
                    default:
                        break;
                }
            }
        }

            private void Button_imageLeft_Click(object sender, RoutedEventArgs e)
            {
                if (_imageIndex > 0)
                {
                    _imageIndex--;
                    switch (_type)
                    {
                        case 1: // hotels
                            Image_imageSlider.Source = ConvertToImage(_imageListHotels[_imageIndex].Poza);
                            Textblock_published.DataContext = _imageListHotels[_imageIndex].Nume + " " + _imageListHotels[_imageIndex].Prenume;
                            break;
                        case 2: // activities
                            Image_imageSlider.Source = ConvertToImage(_imageListActivities[_imageIndex].Poza);
                            Textblock_published.DataContext = _imageListActivities[_imageIndex].Nume + " " + _imageListActivities[_imageIndex].Prenume;
                            break;
                        case 3: // restaurants\
                            Image_imageSlider.Source = ConvertToImage(_imageListRestaurants[_imageIndex].Poza);
                            Textblock_published.DataContext = _imageListRestaurants[_imageIndex].Nume + " " + _imageListRestaurants[_imageIndex].Prenume;
                            break;
                        default:
                            break;
                    }
                }
            }

            private void Button_imageRight_Click(object sender, RoutedEventArgs e)
            {
                switch (_type)
                {
                    case 1: // hotels
                        if (_imageIndex + 1 < _imageListHotels.Count())
                        {
                            _imageIndex++;
                            Image_imageSlider.Source = ConvertToImage(_imageListHotels[_imageIndex].Poza);
                            Textblock_published.DataContext = _imageListHotels[_imageIndex].Nume + " " + _imageListHotels[_imageIndex].Prenume;
                        }
                        break;
                    case 2: // activities
                        if (_imageIndex + 1 < _imageListActivities.Count())
                        {
                            _imageIndex++;
                            Image_imageSlider.Source = ConvertToImage(_imageListActivities[_imageIndex].Poza);
                            Textblock_published.DataContext = _imageListActivities[_imageIndex].Nume + " " + _imageListActivities[_imageIndex].Prenume;
                        }
                        break;
                    case 3: // restaurants\
                        if (_imageIndex + 1 < _imageListRestaurants.Count())
                        {
                            _imageIndex++;
                            Image_imageSlider.Source = ConvertToImage(_imageListRestaurants[_imageIndex].Poza);
                            Textblock_published.DataContext = _imageListRestaurants[_imageIndex].Nume + " " + _imageListRestaurants[_imageIndex].Prenume;
                        }
                        break;
                    default:
                        break;
                }
            }

            ~ItemAccessedView()
            {
                /*if(_imageListHotels.Count()!=0)
                {
                    _imageListHotels.Clear();
                }
                if (_imageListRestaurants.Count()!=0)
                {
                    _imageListRestaurants.Clear();
                }
                if(_imageListHotels.Count()!=0)
                {
                    _imageListHotels.Clear();
                }*/
            }

            public BitmapImage ConvertToImage(byte[] array)
            {
                BitmapImage bmpi = new BitmapImage();
                bmpi.BeginInit();
                bmpi.StreamSource = new MemoryStream(array);
                bmpi.EndInit();
                return bmpi;
            }

            private void Button_back_Click(object sender, RoutedEventArgs e)
            {
                (this.Parent as Panel).Children.Remove(this);
            }

            private void Button_submitReview_Click(object sender, RoutedEventArgs e)
            {
                if (Textbox_comentariu.Text != null)
                {
                    if (Bar_Review.Value != 0)
                    {
                        switch(_type)
                        {
                            case 1: // hotels
                                var recenzie3 = new RecenziiHoteluri();
                                recenzie3.Comentarii = Textbox_comentariu.Text;
                                recenzie3.Data = DateTime.Now;
                                recenzie3.Stele = Bar_Review.Value;
                                recenzie3.UserID = HomeWindow2.Instance.getUser();
                                recenzie3.CazareID = _id;
                                using (var db = new TripAdvisorEntities())
                                {
                                    db.RecenziiHoteluri.Add(recenzie3);
                                    db.SaveChanges();
                                    MessageBox.Show("Review added!");
                                    Textbox_comentariu.Clear();
                                }
                                break;
                            case 2: // activities
                                var recenzie2 = new RecenziiActivitati();
                                recenzie2.Comentarii = Textbox_comentariu.Text;
                                recenzie2.Data = DateTime.Now;
                                recenzie2.Stele = Bar_Review.Value;
                                recenzie2.UserID = HomeWindow2.Instance.getUser();
                                recenzie2.ObiectivID = _id;
                                using (var db = new TripAdvisorEntities())
                                {
                                    db.RecenziiActivitati.Add(recenzie2);
                                    db.SaveChanges();
                                    MessageBox.Show("Review added!");
                                    Textbox_comentariu.Clear();
                                }
                                break;
                            case 3: // restaurant
                                if (Bar_Pricing.Value != 0)
                                {
                                    var recenzie = new RecenziiRestaurante();
                                    recenzie.Comentarii = Textbox_comentariu.Text;
                                    recenzie.Data = DateTime.Now;
                                    recenzie.Pret = Bar_Pricing.Value;
                                    recenzie.Stele = Bar_Review.Value;
                                    recenzie.UserID = HomeWindow2.Instance.getUser();
                                    recenzie.RestaurantID = _id;
                                    using (var db = new TripAdvisorEntities())
                                    {
                                        db.RecenziiRestaurante.Add(recenzie);
                                        db.SaveChanges();
                                        MessageBox.Show("Review added!");
                                        Textbox_comentariu.Clear();
                                    }
                                }
                                else MessageBox.Show("Select a pricing value!");
                                break;
                            default:
                                break;
                        }
                    }
                    else MessageBox.Show("Select a rating value!");

                }
                else MessageBox.Show("Add a comment!");
            }
        
    }
}

