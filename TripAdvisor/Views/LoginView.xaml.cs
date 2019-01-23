using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            string password = Textbox_password.Password;
            string email = Textbox_email.Text;
            if(password.Length!=0 && email.Length!=0)
            {
                using (var context = new TripAdvisorEntities())
                {
                    var result = (from c in context.Utilizatori
                                  where c.Parola == password
                                  where c.Email == email
                                  select c).Count();
                    //System.Windows.MessageBox.Show(result.ToString());
                    if (result == 1)
                    {
                        var userid = (from c in context.Utilizatori
                                        where c.Parola == password
                                        where c.Email == email
                                        select c.UserID).FirstOrDefault();
                        HomeWindow2 hw = HomeWindow2.createInstance(userid);
                        hw.Show();
                        //App.Current.MainWindow.Close();
                        Window parentWindow = Window.GetWindow(this);
                        parentWindow.Hide();
                    }
                    else
                        MessageBox.Show("Invalid email or password!", "Login failed");
                }
            }
        }

        private void Button_createAccount_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.DataContext = new CreateAccountView();
        }
    }
}
