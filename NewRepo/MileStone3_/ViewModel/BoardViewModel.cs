using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Frontend.Model;
using MileStone3_;

namespace Frontend.ViewModel
{
    public class BoardViewModel : NotifiableObject
     {
         private Model.BackendController controller;
         private UserModel user;
        private ObservableCollection<TaskModel> _backLog;
        private ObservableCollection<TaskModel> _inProgress;
        private ObservableCollection<TaskModel> _done;

        public ObservableCollection<TaskModel> BackLogTasks {
            get => _backLog;
            set
            {
                this._backLog = value;
                RaisePropertyChanged("BackLogTasks");
            }
        }
        public ObservableCollection<TaskModel> InProgressTasks {
            get => _inProgress;
            set
            {
                this._inProgress = value;
                RaisePropertyChanged("InProgressTasks");
            }
        }public ObservableCollection<TaskModel> DoneTasks{
            get => _done;
            set
            {
                this._done = value;
                RaisePropertyChanged("DoneTasks");
            }
        }
         public SolidColorBrush BackgroundColor {
             get
             {
                 return new SolidColorBrush(user.Email.Contains("achiya") ? Colors.Blue : Colors.Red);                
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
         public UserBoardsModel boardM { get; private set; }
         public string Title { get; private set; }
         private TaskModel _selectedMessage;
         public TaskModel SelectedMessage
         {
             get
             {
                 return _selectedMessage;
             }
             set
             {
                 _selectedMessage = value;
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

         public BoardViewModel(UserModel user)
         {
             this.controller = user.Controller;
             this.user = user;
             Title = "The Bords of: " + user.Email;
             //boardM = user.
         } 
     }
}
