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
using KanBan_2024.ServiceLayer;


namespace MileStone3_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainDataContext ViewModel { get; set; }
        public ServiceFactory Service { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainDataContext();
            DataContext = ViewModel; // Set the DataContext for data binding
            Service = new ServiceFactory();

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Update ViewModel properties with values from the controls
            ViewModel.Username = UsernameTextBox.Text;
            ViewModel.Password = PasswordBox.Password; // Password is handled separately
            string s = Service.US.Register(ViewModel.Username, ViewModel.Password);
            
            

            // Display the values in a message box for verification
            MessageBox.Show($"Registering Username: {ViewModel.Username}\nPassword: {ViewModel.Password}", "Registration Info");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Update ViewModel properties with values from the controls
            ViewModel.Username = UsernameTextBox.Text;
            ViewModel.Password = PasswordBox.Password; // Password is handled separately
            string s = Service.US.Login(ViewModel.Username, ViewModel.Password);
            


            // Display the values in a message box for verification
            MessageBox.Show($"Logging in Username: {ViewModel.Username}\nPassword: {ViewModel.Password}", "Login Info");
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Update ViewModel.Password when the PasswordBox content changes
            ViewModel.Password = PasswordBox.Password;
        }
    }
}