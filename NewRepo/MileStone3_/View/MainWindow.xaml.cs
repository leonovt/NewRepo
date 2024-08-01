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
using IntroSE.Kanban.Backend.ServiceLayer;
using MileStone3_.Model;
using MileStone3_.ViewModel;

namespace MileStone3_.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel; // Set the DataContext for data binding 


        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Update ViewModel properties with values from the controls
            ViewModel.Username = UsernameTextBox.Text;
            ViewModel.Password = PasswordBox.Password; // Password is handled separately

            bool successful = ViewModel.Register();
            if (successful)
            {
                Boards b = new Boards(UsernameTextBox.Text, PasswordBox.Password);
                b.Show();
                this.Close();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Update ViewModel properties with values from the controls
            ViewModel.Username = UsernameTextBox.Text;
            ViewModel.Password = PasswordBox.Password; // Password is handled separately


            bool successful = ViewModel.Login();
            if (successful)
            {
                Boards b = new Boards(UsernameTextBox.Text, PasswordBox.Password);
                b.Show();
                this.Close();
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Update ViewModel.Password when the PasswordBox content changes
            ViewModel.Password = PasswordBox.Password;
        }
    }
}