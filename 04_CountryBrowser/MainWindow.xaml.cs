using _04_CountryBrowser.ViewModels;
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

namespace _04_CountryBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // TEST 1: Da li ViewModel postoji?
            var vm = this.DataContext as CountrySearchViewModel;
            if (vm == null)
            {
                MessageBox.Show("ERROR: ViewModel is NULL!");
                return;
            }

            MessageBox.Show("ViewModel exists!");

            // TEST 2: Da li SearchCommand postoji?
            if (vm.SearchCommand == null)
            {
                MessageBox.Show("ERROR: SearchCommand is NULL!");
                return;
            }

            MessageBox.Show("SearchCommand exists!");

            // TEST 3: Postavi query i test
            vm.SearchQuery = "Germany";
            MessageBox.Show($"SearchQuery set to: {vm.SearchQuery}");

            // TEST 4: Da li može execute?
            var canExecute = vm.SearchCommand.CanExecute(null);
            MessageBox.Show($"CanExecute: {canExecute}");

            // TEST 5: Izvršit Command
            if (canExecute)
            {
                vm.SearchCommand.Execute(null);
                MessageBox.Show("Command executed!");
            }
        }
    }
}