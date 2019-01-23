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
    /// Interaction logic for CreateAccountView.xaml
    /// </summary>
    public partial class CreateAccountView : UserControl
    {
        public CreateAccountView()
        {
            InitializeComponent();
        }

        private void Button_CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string password = Textbox_password.Password;
            string confirmPassword = Textbox_confirmPassword.Password;
            string email = Textbox_email.Text;
            string firstName = Textbox_firstName.Text;
            string lastName = Textbox_lastName.Text;
            string phoneNumber = Textbox_phoneNumber.Text;

            if (password.Length==0 || confirmPassword.Length==0 || email.Length==0 ||
                firstName.Length==0 || lastName.Length==0 || phoneNumber.Length==0)
            {
                MessageBox.Show("Fields cant be empty!", "Register failed");
            }
            else
            {
                if(password!=confirmPassword)
                {
                    MessageBox.Show("Passwords must be the same!", "Register failed");
                    Textbox_password.Clear();
                    Textbox_confirmPassword.Clear();
                }
                else
                {
                    using (var context = new TripAdvisorEntities())
                    {
                        var newUser = new Utilizatori()
                        {
                            Nume = lastName,
                            Prenume = firstName,
                            Email = email,
                            NrTelefon = phoneNumber,
                            Parola = password
                        };
                        context.Utilizatori.Add(newUser);
                        context.SaveChanges();
                        MessageBox.Show("Account created","Register successfull!");
                        Window parentWindow = Window.GetWindow(this);
                        parentWindow.DataContext = new LoginView();
                    }
                }
            }
        }

        private void Button_signIn_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.DataContext = new LoginView();
        }
    }
}
