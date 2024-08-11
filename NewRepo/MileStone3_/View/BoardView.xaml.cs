using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Frontend.Model;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for SpecificBoardView.xaml
    /// </summary>
    public partial class BoardView : Window
    {
        public ObservableCollection<TaskModel> Backlog { get; set; }
        public ObservableCollection<TaskModel> InProgress { get; set; }
        public ObservableCollection<TaskModel> Done { get; set; }

        public BoardView(BoardModel board)
        {
            InitializeComponent();

            BacklogTasks.ItemsSource = board.BackLog;
            InProgressTasks.ItemsSource = board.InProgress;
            DoneTasks.ItemsSource = board.Done;

            Title.Text = board.BoardName;
            Owner.Text = board.OwnerEmail;
        }
    }
}
