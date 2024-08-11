using Frontend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;
using MileStone3_;

namespace Frontend.ViewModel
{
    public class UserBoardsViewModel : NotifiableObject
    {
        private Model.BackendController controller;
        public UserModel user{get; private set;}
        private ObservableCollection<BoardModel> _boards;
        private string _newBoardName;
        public SolidColorBrush BackgroundColor
        {
            get
            {
                return new SolidColorBrush(user.Email.Contains("achiya") ? Colors.Blue : Colors.Red);
            }
        }
        public ObservableCollection<BoardModel> Boards {
            get => _boards;
            set
            {
                this._boards = value;
                RaisePropertyChanged("Boards");
            }
        }
        public string NewBoardName
        {
            get => _newBoardName;
            set
            {
                this._newBoardName = value;
                RaisePropertyChanged("BoardName");
            }
        }
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                this._message = value;
                RaisePropertyChanged("Message");
            }
        }
        public string Title { get; private set; }
        private BoardModel _selectedBoard;
        public BoardModel SelectedBoard
        {
            get
            {
                return _selectedBoard;
            }
            set
            {
                _selectedBoard = value;
                EnableForward = value != null;
                RaisePropertyChanged("SelectedTask");
            }
        }
        private bool _enableForward = false;
        public bool EnableForward
        {
            get => _enableForward;
            private set
            {
                _enableForward = value;
                RaisePropertyChanged("EnableForward");
            }
        }

        internal void Logout()
        {
            Message = "";
            try
            {
                controller.LogOut(user.Email);
                return;
            }
            catch (Exception e)
            {
                Message = e.Message;
                return;
            }
        }

        public UserBoardsViewModel(UserModel user)
        {
            this.controller = user.Controller;
            this.user = user;
            Title = "The Boards of: " + user.Email;
            this.Boards = user.GetBoards().Messages;
        }

        public void DeleteBoard()
        {

            try
            {
                if (_selectedBoard == null)
                    throw new Exception("No board was chosen");
                //controller.DeleteBoard(user.Email, SelectedBoard.BoardName);
                Boards.Remove(SelectedBoard);

            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot remove message. " + e.Message);
            }

        }

        public BoardModel AddBoard()
        {
            try
            {
                BoardModel newBoard = controller.CreateBoard(user, NewBoardName);
                Boards.Add(newBoard);
                return newBoard;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot remove message. " + e.Message);
                return null;
            }

        }
    }
}
