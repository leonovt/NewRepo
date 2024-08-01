using KanBan_2024.ServiceLayer;
using MileStone3_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MileStone3_.ViewModel
{
    internal class BoardsViewModel
    {
        private string userEmail;

        private string _boardName;
        public string BoardName
        {
            get => _boardName;
            set
            {
                if (_boardName != value)
                {
                    _boardName = value;
                    OnPropertyChanged(nameof(BoardName));
                }
            }
        }

        public BoardsViewModel(string UserEmail, string password) {
            controller = new BackendController();
            userEmail = UserEmail;
            controller.login(UserEmail, password);
            updateBoards(UserEmail);
        }

        private void updateBoards(string userEmail)
        {
            string s = controller.getUserBoards(userEmail);
            Response? r = JsonSerializer.Deserialize<Response?>(s);
            if (r.ErrorMessage == null) {
                

            }
        }


        public void createBoard()
        {
            controller.createBoard(userEmail, BoardName);
        }

        private BackendController controller { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<BoardModel> _boards;

        public ObservableCollection<BoardModel> Boards
        {
            get { return _boards; }
            set
            {
                _boards = value;
                OnPropertyChanged(nameof(Boards));
            }
        }


    }
}
