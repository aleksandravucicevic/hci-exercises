using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01_LoginWindow_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Molimo unesite korisničko ime i lozinku.", "Greška", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (username == "student" && password == "1234")
            {
                MessageBox.Show("Uspješna prijava!", "Obavještenje", MessageBoxButton.OK, MessageBoxImage.Information);
                // Ovdje kasnije može ići otvaranje novog prozora (npr. Dashboard)
            }
            else
            {
                MessageBox.Show("Pogrešno korisničko ime ili lozinka.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}