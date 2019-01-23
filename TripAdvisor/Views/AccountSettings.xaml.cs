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
    /// Interaction logic for AccountSettings.xaml
    /// </summary>
    public partial class AccountSettings : UserControl
    {
        private Utilizatori _user;
        public AccountSettings(Utilizatori user)
        {
            InitializeComponent();
            _user = user;
            Grid_Content.DataContext = user;
            Grid_Info.DataContext = user;
            Grid_ChangeInfo.DataContext = user;
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
        

        private void Button_changePassword_Click(object sender, RoutedEventArgs e)
        {
            Grid_Info.Visibility = Visibility.Hidden;
            Grid_ChangePassword.Visibility = Visibility.Visible;
        }

        private void Button_changeUserInfo_Click(object sender, RoutedEventArgs e)
        {
            Grid_Info.Visibility = Visibility.Hidden;
            Grid_ChangeInfo.Visibility = Visibility.Visible;
        }

        private void Button_saveChanges_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new TripAdvisorEntities())
            {
                if (Textbox_newPassword.Password == Textbox_confirmNewPassword.Password)
                {
                    Utilizatori curUser = (from c in context.Utilizatori
                                           where c.UserID == _user.UserID
                                           select c).FirstOrDefault();
                    if(curUser != null)
                    {
                        curUser.Nume = Textbox_lastName.Text;
                        curUser.Prenume = Textbox_firstName.Text;
                        curUser.NrTelefon = Textbox_phoneNumber.Text;
                        context.SaveChanges();
                        MessageBox.Show("User info succesfully changed!");
                        HomeWindow2.Instance.UpdateUser();
                    }
                    else
                    {
                        MessageBox.Show("Update failed!");
                    }
                }
            }
                ///
            Grid_Info.Visibility = Visibility.Visible;
            Grid_ChangeInfo.Visibility = Visibility.Hidden;
        }

        private void Button_submitNewPassword_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new TripAdvisorEntities())
            {
                var result = (from c in context.Utilizatori
                              where c.Parola == Textbox_oldPassword.Password
                              where c.Email == _user.Email
                              select c).Count();
                if ( result == 0 )
                {
                    MessageBox.Show("Incorrect Password!");
                    Textbox_oldPassword.Clear();
                }
                else if (result == 1)
                {
                    if (Textbox_newPassword.Password == Textbox_confirmNewPassword.Password)
                    {
                        MessageBox.Show(_user.UserID.ToString());
                        Utilizatori curUser = (from c in context.Utilizatori
                                               where c.UserID == _user.UserID
                                               select c).FirstOrDefault();
                        string newpaswd = Textbox_confirmNewPassword.Password;
                        curUser.Parola = newpaswd;
                        context.SaveChanges();
                        MessageBox.Show("Password Changed");
                    }
                    else
                    {
                        MessageBox.Show("The passwords don't match!");
                    }
                }
            }
                ///
            Grid_Info.Visibility = Visibility.Visible;
            Grid_ChangePassword.Visibility = Visibility.Hidden;
        }

        private void Button_backPw_Click(object sender, RoutedEventArgs e)
        {
            Grid_Info.Visibility = Visibility.Visible;
            Grid_ChangePassword.Visibility = Visibility.Hidden;
        }

        private void Button_backInfo_Click(object sender, RoutedEventArgs e)
        {
            Grid_Info.Visibility = Visibility.Visible;
            Grid_ChangeInfo.Visibility = Visibility.Hidden;
        }
    }
}
