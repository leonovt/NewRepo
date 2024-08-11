using Frontend.Model;
using Frontend.ViewModel;
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
using System.Windows.Shapes;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class UserBoards : Window
    {
        private UserBoardsViewModel viewModel;
        
        public UserBoards(UserModel user)
        {
            InitializeComponent();
            this.DataContext = new UserBoardsViewModel(user);
            this.viewModel = (UserBoardsViewModel)DataContext;
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            BoardModel b = viewModel.SelectedBoard;
            if (b == null)
                viewModel.Message = "No board was chosen";
            else
            {
                BoardView boardView = new BoardView(b);
                boardView.Show();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CreateBoard dialog = new CreateBoard(this.viewModel);
            dialog.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            BoardModel b = viewModel.SelectedBoard;
            viewModel.DeleteBoard();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Logout();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
