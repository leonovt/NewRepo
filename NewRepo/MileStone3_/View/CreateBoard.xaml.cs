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
using Frontend.ViewModel;
using Frontend.Model;



namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for CreateBoard.xaml
    /// </summary>
    public partial class CreateBoard : Window
    {
        private UserBoardsViewModel viewModel;


        private string _boardName;
        public string BoardName //=> BoardNameTextBox.Text;
        {
            get => _boardName;
            set
            {
                this._boardName = value;
            }
        }

        public BackendController Controller { get; private set; }

        internal CreateBoard(UserBoardsViewModel dateContext)
        {
            InitializeComponent();
            this.viewModel = dateContext;
            this.DataContext = this.viewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            BoardModel b = viewModel.AddBoard();
            if (b != null)
            {
                DialogResult = true;

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
