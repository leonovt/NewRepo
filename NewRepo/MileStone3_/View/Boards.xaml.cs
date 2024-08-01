using MileStone3_.ViewModel;
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

namespace MileStone3_.View
{

    /// <summary>
    /// Interaction logic for Boards.xaml
    /// </summary>
    public partial class Boards : Window
    {
        private BoardsViewModel ViewModel;
        public Boards(string UserEmail, string password)
        {
            InitializeComponent();
            ViewModel = new BoardsViewModel(UserEmail, password);
            DataContext = ViewModel;
        }
        private void boardNameChanged_boardNameBox(object sender, RoutedEventArgs e)
        {
            // Update ViewModel.Password when the PasswordBox content changes
            ViewModel.BoardName = BoardName.Text;
        }

        private void createBoard_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.createBoard();
        }
    }
}
